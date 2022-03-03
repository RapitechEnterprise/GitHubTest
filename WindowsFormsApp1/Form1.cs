using InstrumentSystems.CAS4;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{    //TEST
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            casID = -1;
        }

        private StringBuilder sb = new StringBuilder(256);
        private int casID;
        private double[] spectrum = new double[0];
        private double[] lambdas = new double[0];
        private double spectrumMax = 0;

        private class MyComboBoxItem
        {
            public string Name { get; set; }
            public int ID { get; set; }

            public MyComboBoxItem(string AName, int AID)
            {
                Name = AName;
                ID = AID;
            }
        }
        
        private class MySpectrumResults
        {
            public string CalibrationUnit { get; set; }
            public int MaxADCValue { get; set; }
            public double DarkCurrentAge { get; set; }
            public double RadInt { get; set; }
            public string RadIntUnit { get; set; }
            public double PhotInt { get; set; }
            public string PhotIntUnit { get; set; }
            public double Centroid { get; set; }
            public double SecondMoment { get; set; }
            public double ThirdMoment { get; set; }
        }
        
        public int SelectedInterface
        {
            get
            {
                return (comboBox1.Items[comboBox1.SelectedIndex] as MyComboBoxItem).ID;
            }
        }

        public int SelectedInterfaceOption
        {
            get
            {
                if (comboBox2.SelectedIndex >= 0)
                {
                    return (comboBox2.Items[comboBox2.SelectedIndex] as MyComboBoxItem).ID;
                }
                else
                {
                    return 0;
                }
            }
        }

        public int CheckCASError(int AError)
        {
            if (AError < CAS4DLL.ErrorNoError)
            {
                CAS4DLL.casGetErrorMessage(AError, sb, sb.Capacity);
                throw new Exception(string.Format("CAS DLL error ({0}): {1}", AError, sb.ToString()));
            }
            return AError;
        }

        public void CheckCASError()
        {
            CheckCASError(CAS4DLL.casGetError(casID));
        }

        private void CasDoneWhenNeeded()
        {
            if (casID >= 0) CAS4DLL.casDoneDevice(casID);
            casID = -1;
        }

        private void FillInterfaceCombo()
        {
            int theIndex;
            int selectIdx;

            selectIdx = 0;
            comboBox1.BeginUpdate();
            try
            {
                comboBox1.Items.Clear();
                comboBox1.DisplayMember = "Name";
                theIndex = 0;
                for (int i=0; i < CAS4DLL.casGetDeviceTypes(); i++)
                {
                    CAS4DLL.casGetDeviceTypeName(i, sb, sb.Capacity);
                    if (sb.Length > 0)
                    {
                        theIndex = comboBox1.Items.Add(new MyComboBoxItem(sb.ToString(), i));
                        if (i == CAS4DLL.InterfaceTest) selectIdx = theIndex;
                    }
                }
            }
            finally
            {
                comboBox1.EndUpdate();
            }

            comboBox1.SelectedIndex = selectIdx;
        }

        private void MeasureDarkCurrent()
        {
            CAS4DLL.casSetShutter(casID, 1);
            CheckCASError();
            try
            {
                CAS4DLL.casMeasureDarkCurrent(casID);
                CheckCASError();
            }
            finally
            {
                CAS4DLL.casSetShutter(casID, 0);
            }
            CheckCASError();
        }


        private void Measure()
        {
            CAS4DLL.casMeasure(casID);
            CheckCASError();
        }

        private void GetResults()
        {
            MySpectrumResults res = new MySpectrumResults();

            CheckCASError(CAS4DLL.casGetDeviceParameterString(casID, CAS4DLL.dpidCalibrationUnit, sb, sb.Capacity));
            res.CalibrationUnit = sb.ToString();

            res.MaxADCValue = (int)Math.Round(CAS4DLL.casGetMeasurementParameter(casID, CAS4DLL.mpidMaxADCValue));
            CheckCASError();
            res.DarkCurrentAge = Math.Round(CAS4DLL.casGetMeasurementParameter(casID, CAS4DLL.mpidLastDCAge) / 60000, 1);
            CheckCASError();

            CheckCASError(CAS4DLL.casColorMetric(casID));

            double tempFloat;
            tempFloat = 0;
            CAS4DLL.casGetRadInt(casID, out tempFloat, sb, sb.Capacity);
            CheckCASError();
            res.RadInt = tempFloat;
            res.RadIntUnit = sb.ToString();

            CAS4DLL.casGetPhotInt(casID, out tempFloat, sb, sb.Capacity);
            CheckCASError();
            res.PhotInt = tempFloat;
            res.PhotIntUnit = sb.ToString();

            res.Centroid = Math.Round(CAS4DLL.casGetCentroid(casID), 2);
            CheckCASError();

            res.SecondMoment = Math.Round(GetMoment(2, res.Centroid), 2);
            res.ThirdMoment = Math.Round(GetMoment(3, res.Centroid), 2);

            propertyGrid1.SelectedObject = res;
        }

        private void GetSpectrum()
        {
            int pix;

            pix = (int)Math.Round(CAS4DLL.casGetDeviceParameter(casID, CAS4DLL.dpidVisiblePixels));
            CheckCASError(pix);

            spectrum = new double[pix];
            lambdas = new Double[pix];
            spectrumMax = -1E37;

            pix = (int)Math.Round(CAS4DLL.casGetDeviceParameter(casID, CAS4DLL.dpidDeadPixels));
            CheckCASError(pix);

            for (int i = 0; i < spectrum.Length; i++)
            {
                spectrum[i] = (float)CAS4DLL.casGetData(casID, i+pix);
                spectrumMax = Math.Max(spectrumMax, spectrum[i]);

                lambdas[i] = (float)CAS4DLL.casGetXArray(casID, i+pix);
            }
        }

        double GetMoment(int AMoment, double ACentroid)
        {
            double RadInt = 0;
            double WeighedInt = 0;
            double DeltaLambda;

            for (int i = 0; i < spectrum.Length; i++)
            {
                if (i == spectrum.Length-1)
                {
                    DeltaLambda = lambdas[i] - lambdas[i-1];
                }
                else
                {
                    DeltaLambda = lambdas[i+1] - lambdas[i];
                }

                RadInt += spectrum[i] * DeltaLambda;
                WeighedInt += spectrum[i] * Math.Pow(lambdas[i] - ACentroid, AMoment) * DeltaLambda;
            }
            if (!RadInt.Equals(0))
            {
                return WeighedInt / RadInt;
            }
            else
            {
                return 0;
            }
        }


        void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int iface;
            int option;

            iface = SelectedInterface;

            comboBox2.BeginUpdate();
            try
            {
                comboBox2.Items.Clear();
                comboBox2.DisplayMember = "Name";
                for (int i=0; i < CAS4DLL.casGetDeviceTypeOptions(iface); i++)
                {
                    option = CAS4DLL.casGetDeviceTypeOption(iface, i);
                    CAS4DLL.casGetDeviceTypeOptionName(iface, i, sb, sb.Capacity);
                    comboBox2.Items.Add(new MyComboBoxItem(sb.ToString(), option));
                }
            }
            finally
            {
                comboBox2.EndUpdate();
            }

            comboBox2.Enabled = (comboBox2.Items.Count > 1);
            if (comboBox2.Items.Count > 0) comboBox2.SelectedIndex = 0;
        }

        void Browse_Click(object sender, EventArgs e)
        {
            OFD.FileName = Config.Text;
            OFD.FilterIndex = 1;
            if (OFD.ShowDialog() == DialogResult.OK)
            {
                Config.Text = OFD.FileName;
            }
        }

        void Browse2_Click(object sender, EventArgs e)
        {
            OFD.FileName = Calibration.Text;
            OFD.FilterIndex = 2;
            if (OFD.ShowDialog() == DialogResult.OK)
            {
                Calibration.Text = OFD.FileName;
            }
        }

        void Config_TextChanged(object sender, EventArgs e)
        {
            Init.Enabled = (File.Exists(Config.Text) && File.Exists(Calibration.Text));
        }

        void Init_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked | radioButton2.Checked)
            {
                CasDoneWhenNeeded();
                try
                {
                    casID = CAS4DLL.casCreateDeviceEx(SelectedInterface, SelectedInterfaceOption);
                    CheckCASError(casID);

                    CAS4DLL.casSetDeviceParameterString(casID, CAS4DLL.dpidConfigFileName, Config.Text);
                    CAS4DLL.casSetDeviceParameterString(casID, CAS4DLL.dpidCalibFileName, Calibration.Text);

                    CheckCASError(CAS4DLL.casInitialize(casID, CAS4DLL.InitForced));

                    numericUpDown1.Minimum = (decimal)Math.Round(CAS4DLL.casGetDeviceParameter(casID, CAS4DLL.dpidIntTimeMin));
                    numericUpDown1.Maximum = (decimal)Math.Round(CAS4DLL.casGetDeviceParameter(casID, CAS4DLL.dpidIntTimeMax));

                    TOPInfo.Enabled = true;
                    DarkCurrent.Enabled = true;
                    btnMeasure.Enabled = true;
                    Done.Enabled = true;

                    Config_TextChanged(this, null);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CasDoneWhenNeeded();
                }
            }
            else
            {
                MessageBox.Show("radioButton1 or radioButton2 not Checked", "Error");
            }
        }

        void Form1FormClosed(object sender, FormClosedEventArgs e)
        {
            CasDoneWhenNeeded();
        }

        void Done_Click(object sender, EventArgs e)
        {
            CasDoneWhenNeeded();

            TOPInfo.Enabled = false;
            DarkCurrent.Enabled = false;
            btnMeasure.Enabled = false;
            Done.Enabled = false;

            Config_TextChanged(this, null);
        }

        void DarkCurrent_Click(object sender, EventArgs e)
        {
            try
            {
                CAS4DLL.casSetMeasurementParameter(casID, CAS4DLL.mpidIntegrationTime, (double)numericUpDown1.Value);
                MeasureDarkCurrent();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void btnMeasure_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                try
                {
                    CAS4DLL.casSetMeasurementParameter(casID, CAS4DLL.mpidIntegrationTime, (double)numericUpDown1.Value);

                    if ((int)Math.Round(CAS4DLL.casGetDeviceParameter(casID, CAS4DLL.dpidNeedDensityFilterChange)) != 0)
                    {
                        CAS4DLL.casSetMeasurementParameter(casID, CAS4DLL.mpidDensityFilter,
                                                           CAS4DLL.casGetMeasurementParameter(casID, CAS4DLL.mpidNewDensityFilter));
                        CheckCASError();
                    }
                    if ((int)Math.Round(CAS4DLL.casGetDeviceParameter(casID, CAS4DLL.dpidNeedDarkCurrent)) != 0)
                    {
                        MeasureDarkCurrent();
                    }
                    Measure();
                    GetSpectrum();
                    GetResults();
                    pictureBox1.Invalidate();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (radioButton2.Checked)
            {
                ;
            }
        }

        void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Rectangle rc = pictureBox1.ClientRectangle;
            e.Graphics.FillRectangle(new SolidBrush(SystemColors.Window), rc);

            int cnt = spectrum.Length;
            if ((cnt > 0) & !(spectrumMax.Equals(0)))
            {
                PointF[] points = new PointF[spectrum.Length];
                double xFactor = (double)rc.Width/cnt;

                for (int i = 0; i<cnt; i++)
                {
                    points[i].X = rc.Left+i*(float)xFactor;
                    points[i].Y = (float)(rc.Bottom - (spectrum[i]/spectrumMax)*(rc.Height));
                }

                e.Graphics.DrawLines(new Pen(Color.Blue, 1), points);
            }
        }

        void TOPInfo_Click(object sender, EventArgs e)
        {
            try
            {
                int topType = CheckCASError((int)Math.Round(CAS4DLL.casGetDeviceParameter(casID, CAS4DLL.dpidTOPType)));
                if (topType != CAS4DLL.ttNone)
                {
                    CheckCASError(CAS4DLL.casGetDeviceParameterString(casID, CAS4DLL.dpidTOPSerialEx, sb, sb.Capacity));
                    MessageBox.Show(string.Format("TOP type {0}, Serial '{1}'", topType, sb.ToString()), "TOP info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No TOP configured", "TOP info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void download_Click(object sender, EventArgs e)
        {
            CasDoneWhenNeeded();
            try
            {
                casID = CAS4DLL.casCreateDeviceEx(SelectedInterface, SelectedInterfaceOption);
                CheckCASError(casID);

                CAS4DLL.casGetSerialNumberEx(casID, CAS4DLL.casSerialDevice, sb, sb.Capacity);
                CheckCASError(casID);

                string DestPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "CASCalibDir");

                if (sb.Length > 0)
                    DestPath = Path.Combine(DestPath, sb.ToString());

                Directory.CreateDirectory(DestPath);

                CheckCASError(CAS4DLL.casSetDeviceParameterString(casID, CAS4DLL.dpidGetFilesFromDevice, DestPath));

                string[] foundConfigFiles = Directory.GetFiles(DestPath, "*.ini");
                if (foundConfigFiles.Length == 0)
                    throw new Exception("No .ini file found in directory " + DestPath);

                Config.Text = foundConfigFiles[0];
                Calibration.Text = Path.ChangeExtension(foundConfigFiles[0], ".isc");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Done_Click(this, null);
        }

        private void Form1_Shown(object sender, EventArgs e)
        {

            string dllPath;

            CAS4DLL.casGetDLLFileName(sb, sb.Capacity);
            dllPath = sb.ToString();
            CAS4DLL.casGetDLLVersionNumber(sb, sb.Capacity);
            DllPathName.Text = string.Format("{0}, Version {1}", dllPath, sb.ToString());

            FillInterfaceCombo();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            CAS4DLL.casSetOptionsOnOff(casID, CAS4DLL.coAutorangeFilter, 1);
        }
    }
}

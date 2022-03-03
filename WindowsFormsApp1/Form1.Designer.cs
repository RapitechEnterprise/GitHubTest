namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.DllPathName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.Config = new System.Windows.Forms.TextBox();
            this.Calibration = new System.Windows.Forms.TextBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.Init = new System.Windows.Forms.Button();
            this.TOPInfo = new System.Windows.Forms.Button();
            this.DarkCurrent = new System.Windows.Forms.Button();
            this.btnMeasure = new System.Windows.Forms.Button();
            this.Done = new System.Windows.Forms.Button();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.download = new System.Windows.Forms.Button();
            this.Browse = new System.Windows.Forms.Button();
            this.Browse2 = new System.Windows.Forms.Button();
            this.OFD = new System.Windows.Forms.OpenFileDialog();
            this.label7 = new System.Windows.Forms.Label();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.numericUpDown4 = new System.Windows.Forms.NumericUpDown();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.numericUpDown5 = new System.Windows.Forms.NumericUpDown();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown5)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "DLL:";
            // 
            // DllPathName
            // 
            this.DllPathName.AutoSize = true;
            this.DllPathName.Location = new System.Drawing.Point(137, 13);
            this.DllPathName.Name = "DllPathName";
            this.DllPathName.Size = new System.Drawing.Size(58, 12);
            this.DllPathName.TabIndex = 1;
            this.DllPathName.Text = "(DLL Info)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "接口:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "配置:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 98);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "校準:";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(139, 31);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(135, 20);
            this.comboBox1.TabIndex = 6;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.Enabled = false;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(280, 31);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(135, 20);
            this.comboBox2.TabIndex = 7;
            // 
            // Config
            // 
            this.Config.Location = new System.Drawing.Point(139, 60);
            this.Config.Name = "Config";
            this.Config.Size = new System.Drawing.Size(287, 22);
            this.Config.TabIndex = 8;
            this.Config.TextChanged += new System.EventHandler(this.Config_TextChanged);
            // 
            // Calibration
            // 
            this.Calibration.Location = new System.Drawing.Point(139, 95);
            this.Calibration.Name = "Calibration";
            this.Calibration.Size = new System.Drawing.Size(287, 22);
            this.Calibration.TabIndex = 9;
            this.Calibration.TextChanged += new System.EventHandler(this.Config_TextChanged);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(139, 124);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(56, 22);
            this.numericUpDown1.TabIndex = 10;
            this.numericUpDown1.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // Init
            // 
            this.Init.Enabled = false;
            this.Init.Location = new System.Drawing.Point(12, 386);
            this.Init.Name = "Init";
            this.Init.Size = new System.Drawing.Size(75, 23);
            this.Init.TabIndex = 11;
            this.Init.Text = "Init";
            this.Init.UseVisualStyleBackColor = true;
            this.Init.Click += new System.EventHandler(this.Init_Click);
            // 
            // TOPInfo
            // 
            this.TOPInfo.Enabled = false;
            this.TOPInfo.Location = new System.Drawing.Point(12, 415);
            this.TOPInfo.Name = "TOPInfo";
            this.TOPInfo.Size = new System.Drawing.Size(75, 23);
            this.TOPInfo.TabIndex = 12;
            this.TOPInfo.Text = "TOP info...";
            this.TOPInfo.UseVisualStyleBackColor = true;
            this.TOPInfo.Click += new System.EventHandler(this.TOPInfo_Click);
            // 
            // DarkCurrent
            // 
            this.DarkCurrent.Enabled = false;
            this.DarkCurrent.Location = new System.Drawing.Point(12, 444);
            this.DarkCurrent.Name = "DarkCurrent";
            this.DarkCurrent.Size = new System.Drawing.Size(75, 23);
            this.DarkCurrent.TabIndex = 13;
            this.DarkCurrent.Text = "Dark current";
            this.DarkCurrent.UseVisualStyleBackColor = true;
            this.DarkCurrent.Click += new System.EventHandler(this.DarkCurrent_Click);
            // 
            // btnMeasure
            // 
            this.btnMeasure.Enabled = false;
            this.btnMeasure.Location = new System.Drawing.Point(12, 473);
            this.btnMeasure.Name = "btnMeasure";
            this.btnMeasure.Size = new System.Drawing.Size(75, 23);
            this.btnMeasure.TabIndex = 14;
            this.btnMeasure.Text = "測量";
            this.btnMeasure.UseVisualStyleBackColor = true;
            this.btnMeasure.Click += new System.EventHandler(this.btnMeasure_Click);
            // 
            // Done
            // 
            this.Done.Enabled = false;
            this.Done.Location = new System.Drawing.Point(12, 502);
            this.Done.Name = "Done";
            this.Done.Size = new System.Drawing.Size(75, 23);
            this.Done.TabIndex = 15;
            this.Done.Text = "完畢";
            this.Done.UseVisualStyleBackColor = true;
            this.Done.Click += new System.EventHandler(this.Done_Click);
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.HelpVisible = false;
            this.propertyGrid1.Location = new System.Drawing.Point(643, 266);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(254, 246);
            this.propertyGrid1.TabIndex = 16;
            this.propertyGrid1.ToolbarVisible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(946, 266);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(331, 246);
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // download
            // 
            this.download.Location = new System.Drawing.Point(451, 60);
            this.download.Name = "download";
            this.download.Size = new System.Drawing.Size(31, 27);
            this.download.TabIndex = 18;
            this.download.UseVisualStyleBackColor = true;
            this.download.Click += new System.EventHandler(this.download_Click);
            // 
            // Browse
            // 
            this.Browse.Location = new System.Drawing.Point(488, 59);
            this.Browse.Name = "Browse";
            this.Browse.Size = new System.Drawing.Size(31, 27);
            this.Browse.TabIndex = 19;
            this.Browse.Text = "...";
            this.Browse.UseVisualStyleBackColor = true;
            this.Browse.Click += new System.EventHandler(this.Browse_Click);
            // 
            // Browse2
            // 
            this.Browse2.Location = new System.Drawing.Point(451, 95);
            this.Browse2.Name = "Browse2";
            this.Browse2.Size = new System.Drawing.Size(31, 27);
            this.Browse2.TabIndex = 20;
            this.Browse2.Text = "...";
            this.Browse2.UseVisualStyleBackColor = true;
            this.Browse2.Click += new System.EventHandler(this.Browse2_Click);
            // 
            // OFD
            // 
            this.OFD.FileName = "openFileDialog1";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(38, 226);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(103, 12);
            this.label7.TabIndex = 23;
            this.label7.Text = "Signal level between:";
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(147, 224);
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(56, 22);
            this.numericUpDown2.TabIndex = 24;
            this.numericUpDown2.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // numericUpDown3
            // 
            this.numericUpDown3.Location = new System.Drawing.Point(261, 224);
            this.numericUpDown3.Name = "numericUpDown3";
            this.numericUpDown3.Size = new System.Drawing.Size(56, 22);
            this.numericUpDown3.TabIndex = 25;
            this.numericUpDown3.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(223, 234);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(22, 12);
            this.label8.TabIndex = 26;
            this.label8.Text = "and";
            // 
            // comboBox3
            // 
            this.comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[] {
            "ms",
            "s"});
            this.comboBox3.Location = new System.Drawing.Point(209, 126);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(57, 20);
            this.comboBox3.TabIndex = 27;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(36, 266);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(105, 12);
            this.label9.TabIndex = 28;
            this.label9.Text = "Max.integration time:";
            // 
            // comboBox4
            // 
            this.comboBox4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Items.AddRange(new object[] {
            "s",
            "ms"});
            this.comboBox4.Location = new System.Drawing.Point(209, 264);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(57, 20);
            this.comboBox4.TabIndex = 27;
            // 
            // numericUpDown4
            // 
            this.numericUpDown4.Location = new System.Drawing.Point(147, 264);
            this.numericUpDown4.Name = "numericUpDown4";
            this.numericUpDown4.Size = new System.Drawing.Size(56, 22);
            this.numericUpDown4.TabIndex = 29;
            this.numericUpDown4.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(41, 296);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(100, 16);
            this.checkBox1.TabIndex = 30;
            this.checkBox1.Text = "use density filter";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(39, 329);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(79, 12);
            this.label10.TabIndex = 31;
            this.label10.Text = "Align to period:";
            // 
            // numericUpDown5
            // 
            this.numericUpDown5.Location = new System.Drawing.Point(124, 327);
            this.numericUpDown5.Name = "numericUpDown5";
            this.numericUpDown5.Size = new System.Drawing.Size(56, 22);
            this.numericUpDown5.TabIndex = 32;
            this.numericUpDown5.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(49, 126);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(49, 16);
            this.radioButton1.TabIndex = 33;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Fixed";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(49, 187);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(86, 16);
            this.radioButton2.TabIndex = 34;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "AutoRanging";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1479, 553);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.numericUpDown5);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.numericUpDown4);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.comboBox4);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.numericUpDown3);
            this.Controls.Add(this.numericUpDown2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.Browse2);
            this.Controls.Add(this.Browse);
            this.Controls.Add(this.download);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.propertyGrid1);
            this.Controls.Add(this.Done);
            this.Controls.Add(this.btnMeasure);
            this.Controls.Add(this.DarkCurrent);
            this.Controls.Add(this.TOPInfo);
            this.Controls.Add(this.Init);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.Calibration);
            this.Controls.Add(this.Config);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.DllPathName);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "CAS4 DLL C# Application";
            this.Shown += new System.EventHandler(this.Form1_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label DllPathName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.TextBox Config;
        private System.Windows.Forms.TextBox Calibration;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button Init;
        private System.Windows.Forms.Button TOPInfo;
        private System.Windows.Forms.Button DarkCurrent;
        private System.Windows.Forms.Button btnMeasure;
        private System.Windows.Forms.Button Done;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button download;
        private System.Windows.Forms.Button Browse;
        private System.Windows.Forms.Button Browse2;
        private System.Windows.Forms.OpenFileDialog OFD;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.NumericUpDown numericUpDown3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.NumericUpDown numericUpDown4;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown numericUpDown5;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
    }
}


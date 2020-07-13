namespace ComPort
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chBoxDtrEnable = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cBoxParityBits = new System.Windows.Forms.ComboBox();
            this.cBoxStopBits = new System.Windows.Forms.ComboBox();
            this.cBoxDataBits = new System.Windows.Forms.ComboBox();
            this.CBoxBaudRate = new System.Windows.Forms.ComboBox();
            this.cBoxCOMPORT = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.lblStatusCom = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.btnDateTime = new System.Windows.Forms.Button();
            this.tBoxDateTime = new System.Windows.Forms.TextBox();
            this.btnLoadConf = new System.Windows.Forms.Button();
            this.btnCleanTBox = new System.Windows.Forms.Button();
            this.label_C2 = new System.Windows.Forms.Label();
            this.tBox_C2 = new System.Windows.Forms.TextBox();
            this.label_C1 = new System.Windows.Forms.Label();
            this.tBox_C1 = new System.Windows.Forms.TextBox();
            this.label_C0 = new System.Windows.Forms.Label();
            this.tBox_C0 = new System.Windows.Forms.TextBox();
            this.label_LG = new System.Windows.Forms.Label();
            this.tBox_LG = new System.Windows.Forms.TextBox();
            this.label_LT = new System.Windows.Forms.Label();
            this.tBox_LT = new System.Windows.Forms.TextBox();
            this.label_RF = new System.Windows.Forms.Label();
            this.tBox_RF = new System.Windows.Forms.TextBox();
            this.label_LS = new System.Windows.Forms.Label();
            this.tBox_LS = new System.Windows.Forms.TextBox();
            this.label_AL = new System.Windows.Forms.Label();
            this.tBox_AL = new System.Windows.Forms.TextBox();
            this.label_IS = new System.Windows.Forms.Label();
            this.tBox_IS = new System.Windows.Forms.TextBox();
            this.label_IE = new System.Windows.Forms.Label();
            this.tBox_IE = new System.Windows.Forms.TextBox();
            this.label_AN = new System.Windows.Forms.Label();
            this.tBox_AN = new System.Windows.Forms.TextBox();
            this.label_AC = new System.Windows.Forms.Label();
            this.tBox_AC = new System.Windows.Forms.TextBox();
            this.label_TI = new System.Windows.Forms.Label();
            this.tBox_TI = new System.Windows.Forms.TextBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.btnEnter = new System.Windows.Forms.Button();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.lblDataInLength = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnClearDataIN = new System.Windows.Forms.Button();
            this.tBoxDataIN = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chBoxDtrEnable);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cBoxParityBits);
            this.groupBox1.Controls.Add(this.cBoxStopBits);
            this.groupBox1.Controls.Add(this.cBoxDataBits);
            this.groupBox1.Controls.Add(this.CBoxBaudRate);
            this.groupBox1.Controls.Add(this.cBoxCOMPORT);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(238, 192);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Com Port Control";
            // 
            // chBoxDtrEnable
            // 
            this.chBoxDtrEnable.AutoSize = true;
            this.chBoxDtrEnable.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chBoxDtrEnable.Location = new System.Drawing.Point(24, 160);
            this.chBoxDtrEnable.Name = "chBoxDtrEnable";
            this.chBoxDtrEnable.Size = new System.Drawing.Size(101, 19);
            this.chBoxDtrEnable.TabIndex = 10;
            this.chBoxDtrEnable.Text = "DTR ENABLE";
            this.chBoxDtrEnable.UseVisualStyleBackColor = true;
            this.chBoxDtrEnable.CheckedChanged += new System.EventHandler(this.chBoxDtrEnable_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 131);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "PARITY BITS";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "STOP BITS";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "DATA BITS";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "BAUD RATE";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "COM PORT";
            // 
            // cBoxParityBits
            // 
            this.cBoxParityBits.FormattingEnabled = true;
            this.cBoxParityBits.Items.AddRange(new object[] {
            "None",
            "Odd",
            "Even"});
            this.cBoxParityBits.Location = new System.Drawing.Point(101, 127);
            this.cBoxParityBits.Name = "cBoxParityBits";
            this.cBoxParityBits.Size = new System.Drawing.Size(121, 21);
            this.cBoxParityBits.TabIndex = 4;
            this.cBoxParityBits.Text = "None";
            // 
            // cBoxStopBits
            // 
            this.cBoxStopBits.FormattingEnabled = true;
            this.cBoxStopBits.Items.AddRange(new object[] {
            "One",
            "Two"});
            this.cBoxStopBits.Location = new System.Drawing.Point(101, 100);
            this.cBoxStopBits.Name = "cBoxStopBits";
            this.cBoxStopBits.Size = new System.Drawing.Size(121, 21);
            this.cBoxStopBits.TabIndex = 3;
            this.cBoxStopBits.Text = "One";
            // 
            // cBoxDataBits
            // 
            this.cBoxDataBits.FormattingEnabled = true;
            this.cBoxDataBits.Items.AddRange(new object[] {
            "6",
            "7",
            "8"});
            this.cBoxDataBits.Location = new System.Drawing.Point(101, 73);
            this.cBoxDataBits.Name = "cBoxDataBits";
            this.cBoxDataBits.Size = new System.Drawing.Size(121, 21);
            this.cBoxDataBits.TabIndex = 2;
            this.cBoxDataBits.Text = "8";
            // 
            // CBoxBaudRate
            // 
            this.CBoxBaudRate.FormattingEnabled = true;
            this.CBoxBaudRate.Items.AddRange(new object[] {
            "2400",
            "4800",
            "9600",
            "115200"});
            this.CBoxBaudRate.Location = new System.Drawing.Point(101, 46);
            this.CBoxBaudRate.Name = "CBoxBaudRate";
            this.CBoxBaudRate.Size = new System.Drawing.Size(121, 21);
            this.CBoxBaudRate.TabIndex = 1;
            this.CBoxBaudRate.Text = "9600";
            // 
            // cBoxCOMPORT
            // 
            this.cBoxCOMPORT.FormattingEnabled = true;
            this.cBoxCOMPORT.Location = new System.Drawing.Point(101, 19);
            this.cBoxCOMPORT.Name = "cBoxCOMPORT";
            this.cBoxCOMPORT.Size = new System.Drawing.Size(121, 21);
            this.cBoxCOMPORT.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox8);
            this.groupBox2.Controls.Add(this.progressBar1);
            this.groupBox2.Controls.Add(this.btnClose);
            this.groupBox2.Controls.Add(this.btnOpen);
            this.groupBox2.Location = new System.Drawing.Point(12, 204);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(238, 152);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.lblStatusCom);
            this.groupBox8.Location = new System.Drawing.Point(101, 13);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(127, 98);
            this.groupBox8.TabIndex = 3;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "COM PORT STATUS";
            // 
            // lblStatusCom
            // 
            this.lblStatusCom.AutoSize = true;
            this.lblStatusCom.Font = new System.Drawing.Font("Britannic Bold", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatusCom.Location = new System.Drawing.Point(37, 34);
            this.lblStatusCom.Name = "lblStatusCom";
            this.lblStatusCom.Size = new System.Drawing.Size(52, 27);
            this.lblStatusCom.TabIndex = 0;
            this.lblStatusCom.Text = "OFF";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(9, 117);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(218, 23);
            this.progressBar1.TabIndex = 2;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(9, 66);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(88, 45);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "CLOSE";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(9, 16);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(88, 45);
            this.btnOpen.TabIndex = 0;
            this.btnOpen.Text = "OPEN";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 264);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 13);
            this.label6.TabIndex = 39;
            this.label6.Text = "Fecha y hora:";
            // 
            // btnDateTime
            // 
            this.btnDateTime.Image = ((System.Drawing.Image)(resources.GetObject("btnDateTime.Image")));
            this.btnDateTime.Location = new System.Drawing.Point(219, 260);
            this.btnDateTime.Name = "btnDateTime";
            this.btnDateTime.Size = new System.Drawing.Size(23, 20);
            this.btnDateTime.TabIndex = 38;
            this.btnDateTime.UseVisualStyleBackColor = true;
            this.btnDateTime.Click += new System.EventHandler(this.btnDateTime_Click);
            // 
            // tBoxDateTime
            // 
            this.tBoxDateTime.Location = new System.Drawing.Point(100, 260);
            this.tBoxDateTime.Name = "tBoxDateTime";
            this.tBoxDateTime.Size = new System.Drawing.Size(113, 20);
            this.tBoxDateTime.TabIndex = 37;
            // 
            // btnLoadConf
            // 
            this.btnLoadConf.Location = new System.Drawing.Point(212, 308);
            this.btnLoadConf.Name = "btnLoadConf";
            this.btnLoadConf.Size = new System.Drawing.Size(103, 23);
            this.btnLoadConf.TabIndex = 36;
            this.btnLoadConf.Text = "Leer configuración";
            this.btnLoadConf.UseVisualStyleBackColor = true;
            this.btnLoadConf.Click += new System.EventHandler(this.btnLoadConf_Click);
            // 
            // btnCleanTBox
            // 
            this.btnCleanTBox.Location = new System.Drawing.Point(326, 308);
            this.btnCleanTBox.Name = "btnCleanTBox";
            this.btnCleanTBox.Size = new System.Drawing.Size(103, 23);
            this.btnCleanTBox.TabIndex = 35;
            this.btnCleanTBox.Text = "Limpiar Campos";
            this.btnCleanTBox.UseVisualStyleBackColor = true;
            this.btnCleanTBox.Click += new System.EventHandler(this.btnCleanTBox_Click);
            // 
            // label_C2
            // 
            this.label_C2.AutoSize = true;
            this.label_C2.Location = new System.Drawing.Point(277, 264);
            this.label_C2.Name = "label_C2";
            this.label_C2.Size = new System.Drawing.Size(42, 13);
            this.label_C2.TabIndex = 34;
            this.label_C2.Text = "CEL 3: ";
            // 
            // tBox_C2
            // 
            this.tBox_C2.Location = new System.Drawing.Point(394, 261);
            this.tBox_C2.Name = "tBox_C2";
            this.tBox_C2.Size = new System.Drawing.Size(87, 20);
            this.tBox_C2.TabIndex = 33;
            this.tBox_C2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tBox_C2_KeyDown);
            // 
            // label_C1
            // 
            this.label_C1.AutoSize = true;
            this.label_C1.Location = new System.Drawing.Point(277, 233);
            this.label_C1.Name = "label_C1";
            this.label_C1.Size = new System.Drawing.Size(42, 13);
            this.label_C1.TabIndex = 32;
            this.label_C1.Text = "CEL 2: ";
            // 
            // tBox_C1
            // 
            this.tBox_C1.Location = new System.Drawing.Point(394, 230);
            this.tBox_C1.Name = "tBox_C1";
            this.tBox_C1.Size = new System.Drawing.Size(87, 20);
            this.tBox_C1.TabIndex = 31;
            this.tBox_C1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tBox_C1_KeyDown);
            // 
            // label_C0
            // 
            this.label_C0.AutoSize = true;
            this.label_C0.Location = new System.Drawing.Point(277, 202);
            this.label_C0.Name = "label_C0";
            this.label_C0.Size = new System.Drawing.Size(42, 13);
            this.label_C0.TabIndex = 30;
            this.label_C0.Text = "CEL 1: ";
            // 
            // tBox_C0
            // 
            this.tBox_C0.Location = new System.Drawing.Point(394, 199);
            this.tBox_C0.Name = "tBox_C0";
            this.tBox_C0.Size = new System.Drawing.Size(87, 20);
            this.tBox_C0.TabIndex = 29;
            this.tBox_C0.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tBox_C0_KeyDown);
            // 
            // label_LG
            // 
            this.label_LG.AutoSize = true;
            this.label_LG.Location = new System.Drawing.Point(22, 233);
            this.label_LG.Name = "label_LG";
            this.label_LG.Size = new System.Drawing.Size(54, 13);
            this.label_LG.TabIndex = 28;
            this.label_LG.Text = "Longitud: ";
            // 
            // tBox_LG
            // 
            this.tBox_LG.Location = new System.Drawing.Point(100, 229);
            this.tBox_LG.Name = "tBox_LG";
            this.tBox_LG.Size = new System.Drawing.Size(113, 20);
            this.tBox_LG.TabIndex = 27;
            this.tBox_LG.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tBox_LG_KeyDown);
            // 
            // label_LT
            // 
            this.label_LT.AutoSize = true;
            this.label_LT.Location = new System.Drawing.Point(22, 202);
            this.label_LT.Name = "label_LT";
            this.label_LT.Size = new System.Drawing.Size(45, 13);
            this.label_LT.TabIndex = 26;
            this.label_LT.Text = "Latitud: ";
            // 
            // tBox_LT
            // 
            this.tBox_LT.Location = new System.Drawing.Point(100, 198);
            this.tBox_LT.Name = "tBox_LT";
            this.tBox_LT.Size = new System.Drawing.Size(113, 20);
            this.tBox_LT.TabIndex = 25;
            this.tBox_LT.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tBox_LT_KeyDown);
            // 
            // label_RF
            // 
            this.label_RF.AutoSize = true;
            this.label_RF.Location = new System.Drawing.Point(22, 171);
            this.label_RF.Name = "label_RF";
            this.label_RF.Size = new System.Drawing.Size(34, 13);
            this.label_RF.TabIndex = 24;
            this.label_RF.Text = "RFC: ";
            // 
            // tBox_RF
            // 
            this.tBox_RF.Location = new System.Drawing.Point(100, 167);
            this.tBox_RF.Name = "tBox_RF";
            this.tBox_RF.Size = new System.Drawing.Size(113, 20);
            this.tBox_RF.TabIndex = 23;
            this.tBox_RF.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tBox_RF_KeyDown);
            // 
            // label_LS
            // 
            this.label_LS.AutoSize = true;
            this.label_LS.Location = new System.Drawing.Point(277, 170);
            this.label_LS.Name = "label_LS";
            this.label_LS.Size = new System.Drawing.Size(108, 13);
            this.label_LS.TabIndex = 22;
            this.label_LS.Text = "Hora de envío SMS: ";
            // 
            // tBox_LS
            // 
            this.tBox_LS.Location = new System.Drawing.Point(394, 167);
            this.tBox_LS.Name = "tBox_LS";
            this.tBox_LS.Size = new System.Drawing.Size(87, 20);
            this.tBox_LS.TabIndex = 21;
            this.tBox_LS.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tBox_LS_KeyDown);
            // 
            // label_AL
            // 
            this.label_AL.AutoSize = true;
            this.label_AL.Location = new System.Drawing.Point(277, 140);
            this.label_AL.Name = "label_AL";
            this.label_AL.Size = new System.Drawing.Size(72, 13);
            this.label_AL.TabIndex = 20;
            this.label_AL.Text = "Activar SMS: ";
            // 
            // tBox_AL
            // 
            this.tBox_AL.Location = new System.Drawing.Point(394, 136);
            this.tBox_AL.Name = "tBox_AL";
            this.tBox_AL.Size = new System.Drawing.Size(87, 20);
            this.tBox_AL.TabIndex = 19;
            this.tBox_AL.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tBox_AL_KeyDown);
            // 
            // label_IS
            // 
            this.label_IS.AutoSize = true;
            this.label_IS.Location = new System.Drawing.Point(22, 109);
            this.label_IS.Name = "label_IS";
            this.label_IS.Size = new System.Drawing.Size(60, 13);
            this.label_IS.TabIndex = 18;
            this.label_IS.Text = "ID de sitio: ";
            // 
            // tBox_IS
            // 
            this.tBox_IS.Location = new System.Drawing.Point(100, 105);
            this.tBox_IS.Name = "tBox_IS";
            this.tBox_IS.Size = new System.Drawing.Size(113, 20);
            this.tBox_IS.TabIndex = 17;
            this.tBox_IS.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tBox_IS_KeyDown);
            // 
            // label_IE
            // 
            this.label_IE.AutoSize = true;
            this.label_IE.Location = new System.Drawing.Point(22, 78);
            this.label_IE.Name = "label_IE";
            this.label_IE.Size = new System.Drawing.Size(74, 13);
            this.label_IE.TabIndex = 16;
            this.label_IE.Text = "ID telemetría: ";
            // 
            // tBox_IE
            // 
            this.tBox_IE.Location = new System.Drawing.Point(102, 74);
            this.tBox_IE.Name = "tBox_IE";
            this.tBox_IE.Size = new System.Drawing.Size(111, 20);
            this.tBox_IE.TabIndex = 15;
            this.tBox_IE.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tBox_IE_KeyDown);
            // 
            // label_AN
            // 
            this.label_AN.AutoSize = true;
            this.label_AN.Location = new System.Drawing.Point(22, 140);
            this.label_AN.Name = "label_AN";
            this.label_AN.Size = new System.Drawing.Size(35, 13);
            this.label_AN.TabIndex = 14;
            this.label_AN.Text = "APN: ";
            // 
            // tBox_AN
            // 
            this.tBox_AN.Location = new System.Drawing.Point(100, 136);
            this.tBox_AN.Name = "tBox_AN";
            this.tBox_AN.Size = new System.Drawing.Size(113, 20);
            this.tBox_AN.TabIndex = 13;
            this.tBox_AN.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tBox_AN_KeyDown);
            // 
            // label_AC
            // 
            this.label_AC.AutoSize = true;
            this.label_AC.Location = new System.Drawing.Point(277, 109);
            this.label_AC.Name = "label_AC";
            this.label_AC.Size = new System.Drawing.Size(109, 13);
            this.label_AC.TabIndex = 12;
            this.label_AC.Text = "Lecturas a acumular: ";
            // 
            // tBox_AC
            // 
            this.tBox_AC.Location = new System.Drawing.Point(394, 106);
            this.tBox_AC.Name = "tBox_AC";
            this.tBox_AC.Size = new System.Drawing.Size(87, 20);
            this.tBox_AC.TabIndex = 11;
            this.tBox_AC.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tBox_AC_KeyDown);
            // 
            // label_TI
            // 
            this.label_TI.AutoSize = true;
            this.label_TI.Location = new System.Drawing.Point(277, 78);
            this.label_TI.Name = "label_TI";
            this.label_TI.Size = new System.Drawing.Size(112, 13);
            this.label_TI.TabIndex = 10;
            this.label_TI.Text = "Intervalo de muestreo:";
            // 
            // tBox_TI
            // 
            this.tBox_TI.Location = new System.Drawing.Point(394, 75);
            this.tBox_TI.Name = "tBox_TI";
            this.tBox_TI.Size = new System.Drawing.Size(87, 20);
            this.tBox_TI.TabIndex = 9;
            this.tBox_TI.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tBox_TI_KeyDown);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(183, 26);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 8;
            this.btnExit.Text = "Salir de CLI";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(102, 26);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(75, 23);
            this.btnHelp.TabIndex = 7;
            this.btnHelp.Text = "Ayuda";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // btnEnter
            // 
            this.btnEnter.Location = new System.Drawing.Point(21, 26);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(75, 23);
            this.btnEnter.TabIndex = 6;
            this.btnEnter.Text = "Entrar a CLI";
            this.btnEnter.UseMnemonic = false;
            this.btnEnter.UseVisualStyleBackColor = true;
            this.btnEnter.Click += new System.EventHandler(this.btnEnter_Click);
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.groupBox10);
            this.groupBox9.Controls.Add(this.tBoxDataIN);
            this.groupBox9.Location = new System.Drawing.Point(768, 13);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(524, 343);
            this.groupBox9.TabIndex = 5;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Receiver Control";
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.groupBox11);
            this.groupBox10.Controls.Add(this.btnClearDataIN);
            this.groupBox10.Location = new System.Drawing.Point(8, 279);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(337, 56);
            this.groupBox10.TabIndex = 8;
            this.groupBox10.TabStop = false;
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.lblDataInLength);
            this.groupBox11.Controls.Add(this.label8);
            this.groupBox11.Location = new System.Drawing.Point(122, 8);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(204, 38);
            this.groupBox11.TabIndex = 7;
            this.groupBox11.TabStop = false;
            // 
            // lblDataInLength
            // 
            this.lblDataInLength.AutoSize = true;
            this.lblDataInLength.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDataInLength.Location = new System.Drawing.Point(151, 13);
            this.lblDataInLength.Name = "lblDataInLength";
            this.lblDataInLength.Size = new System.Drawing.Size(24, 17);
            this.lblDataInLength.TabIndex = 6;
            this.lblDataInLength.Text = "00";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(16, 13);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(115, 17);
            this.label8.TabIndex = 5;
            this.label8.Text = "Data IN Length : ";
            // 
            // btnClearDataIN
            // 
            this.btnClearDataIN.Location = new System.Drawing.Point(15, 15);
            this.btnClearDataIN.Name = "btnClearDataIN";
            this.btnClearDataIN.Size = new System.Drawing.Size(93, 29);
            this.btnClearDataIN.TabIndex = 4;
            this.btnClearDataIN.Text = "Limpiar Consola";
            this.btnClearDataIN.UseVisualStyleBackColor = true;
            this.btnClearDataIN.Click += new System.EventHandler(this.btnClearDataIN_Click);
            // 
            // tBoxDataIN
            // 
            this.tBoxDataIN.BackColor = System.Drawing.SystemColors.WindowText;
            this.tBoxDataIN.ForeColor = System.Drawing.Color.White;
            this.tBoxDataIN.Location = new System.Drawing.Point(8, 18);
            this.tBoxDataIN.Multiline = true;
            this.tBoxDataIN.Name = "tBoxDataIN";
            this.tBoxDataIN.ReadOnly = true;
            this.tBoxDataIN.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tBoxDataIN.Size = new System.Drawing.Size(510, 259);
            this.tBoxDataIN.TabIndex = 6;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.btnDateTime);
            this.groupBox3.Controls.Add(this.tBoxDateTime);
            this.groupBox3.Controls.Add(this.btnLoadConf);
            this.groupBox3.Controls.Add(this.btnCleanTBox);
            this.groupBox3.Controls.Add(this.label_C2);
            this.groupBox3.Controls.Add(this.tBox_C2);
            this.groupBox3.Controls.Add(this.label_C1);
            this.groupBox3.Controls.Add(this.tBox_C1);
            this.groupBox3.Controls.Add(this.label_C0);
            this.groupBox3.Controls.Add(this.tBox_C0);
            this.groupBox3.Controls.Add(this.label_LG);
            this.groupBox3.Controls.Add(this.tBox_LG);
            this.groupBox3.Controls.Add(this.label_LT);
            this.groupBox3.Controls.Add(this.tBox_LT);
            this.groupBox3.Controls.Add(this.label_RF);
            this.groupBox3.Controls.Add(this.tBox_RF);
            this.groupBox3.Controls.Add(this.label_LS);
            this.groupBox3.Controls.Add(this.tBox_LS);
            this.groupBox3.Controls.Add(this.label_AL);
            this.groupBox3.Controls.Add(this.tBox_AL);
            this.groupBox3.Controls.Add(this.label_IS);
            this.groupBox3.Controls.Add(this.tBox_IS);
            this.groupBox3.Controls.Add(this.label_IE);
            this.groupBox3.Controls.Add(this.tBox_IE);
            this.groupBox3.Controls.Add(this.label_AN);
            this.groupBox3.Controls.Add(this.tBox_AN);
            this.groupBox3.Controls.Add(this.label_AC);
            this.groupBox3.Controls.Add(this.tBox_AC);
            this.groupBox3.Controls.Add(this.label_TI);
            this.groupBox3.Controls.Add(this.tBox_TI);
            this.groupBox3.Controls.Add(this.btnExit);
            this.groupBox3.Controls.Add(this.btnHelp);
            this.groupBox3.Controls.Add(this.btnEnter);
            this.groupBox3.Location = new System.Drawing.Point(257, 13);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(505, 343);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Transmitter Control";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1304, 372);
            this.Controls.Add(this.groupBox9);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "EAGLE CLI";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cBoxParityBits;
        private System.Windows.Forms.ComboBox cBoxStopBits;
        private System.Windows.Forms.ComboBox cBoxDataBits;
        private System.Windows.Forms.ComboBox CBoxBaudRate;
        private System.Windows.Forms.ComboBox cBoxCOMPORT;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnOpen;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.CheckBox chBoxDtrEnable;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Label lblStatusCom;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.TextBox tBoxDataIN;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.Label lblDataInLength;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnClearDataIN;
        private System.Windows.Forms.Button btnEnter;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.TextBox tBox_TI;
        private System.Windows.Forms.Label label_TI;
        private System.Windows.Forms.Label label_AC;
        private System.Windows.Forms.TextBox tBox_AC;
        private System.Windows.Forms.Label label_AN;
        private System.Windows.Forms.TextBox tBox_AN;
        private System.Windows.Forms.Label label_C2;
        private System.Windows.Forms.TextBox tBox_C2;
        private System.Windows.Forms.Label label_C1;
        private System.Windows.Forms.TextBox tBox_C1;
        private System.Windows.Forms.Label label_C0;
        private System.Windows.Forms.TextBox tBox_C0;
        private System.Windows.Forms.Label label_LG;
        private System.Windows.Forms.TextBox tBox_LG;
        private System.Windows.Forms.Label label_LT;
        private System.Windows.Forms.TextBox tBox_LT;
        private System.Windows.Forms.Label label_RF;
        private System.Windows.Forms.TextBox tBox_RF;
        private System.Windows.Forms.Label label_LS;
        private System.Windows.Forms.TextBox tBox_LS;
        private System.Windows.Forms.Label label_AL;
        private System.Windows.Forms.TextBox tBox_AL;
        private System.Windows.Forms.Label label_IS;
        private System.Windows.Forms.TextBox tBox_IS;
        private System.Windows.Forms.Label label_IE;
        private System.Windows.Forms.TextBox tBox_IE;
        private System.Windows.Forms.Button btnCleanTBox;
        private System.Windows.Forms.Button btnLoadConf;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnDateTime;
        private System.Windows.Forms.TextBox tBoxDateTime;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}


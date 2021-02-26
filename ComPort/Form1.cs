using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;


namespace ComPort
{
    public partial class Main : Form
    {
        string dataIN;
        bool disableReceiverControl;
        bool receivingData = false;
        string[] ARRAY_COMMANDS = new string[]
        {
            "AT+HH", //1. comando para introducir un nuevo host HTTP
            "AT+HU", //2. comando para introducir un nuevo path HTTP
            "AT+HT", //3. comando para introducir un nuevo port HTTP
            "AT+HG", //4. comando para introducir un nuevo path GET HTTP
            "AT+TI", //5. comando para introducir un nuevo intervalo en minutos HTTP
            "AT+AC", //6. comando para introducir un numero de lecturas a acumular
            "AT+IE", //7. comando para introducir un nuevo identificador de telemetria
            "AT+IS", //8. comando para introducir un nuevo identificador de sitio
            "AT+FH", //9. comando para introducir un nuevo host FTP
            "AT+FS", //10. comando para introducir un nuevo user FTP
            "AT+FW", //11. comando para introducir un nuevo pass FTP
            "AT+FU", //12. comando para introducir un nuevo path FTP
            "AT+FT", //13. comando para introducir un nuevo port FTP
            "AT+FL", //14. comando para activar la transmision diaria FTP
            "AT+LF", //15. comando para definir la hora de activacion de la transmision FTP
            "AT+AN", //16. comando para introducir una nueva APN de red
            "AT+US", //17. comando para introducir un nuevo user de red
            "AT+PS", //18. comando para introducir un nueva pass de red
            "AT+NM", //19. comando para introducir un nuevo NSM
            "AT+NT", //20. comando para introducir un nuevo NSUT
            "AT+NE", //21. comando para introducir un nuevo NSUE
            "AT+RF", //22. comando para definir el RFC
            "AT+LT", //23. comando para definir latitud
            "AT+LG", //24. comando para definir longitud
            "AT+AL", //25. comando para activar la transmision diaria SMS
            "AT+LS", //26. comando para definir la hora de activacion de la transmision SMS
            "AT+C0", //27. comando para definir de telefono 1 de la alerta SMS
            "AT+C1", //28. comando para definir de telefono 2 de la alerta SMS
            "AT+C2", //29. comando para definir de telefono 3 de la alerta SMS
            "AT+AA", //30. comando para activar la alarma SMS
            "AT+CA", //31. comando para definir el telefono de la alarma SMS
            "AT+HL", //32. comando para activar la transmision diaria HTTP
            "AT+FM", //33. comando para activar la transmision por minutos FTP
            "AT+AM", //34. comando para activar la transmision por minutos SMS
            "AT+HM", //35. comando para activar la transmision por minutos HTTP
            "AT+LH", //36. comando para definir la hora de activacion de la transmision HTTP
            "AT+TF", //37. comando para introducir un nuevo intervalo en minutos FTP
            "AT+TS", //38. comando para introducir un nuevo intervalo en minutos SMS
            "AT+MT", //39. comando para seleccionar medidor
            "AT+SP", //40. comando para seleccionar el puerto serie
            "AT+SB", //41. comando para cambiar el baud rate
            "AT+SC", //42. comando para cambiar la configuracion serie
            "AT+SS"  //43. comando para cambiar el numero de esclavo
        };
        string[] READ_COMMANDS = new string[]
        {
            "AT+TI", //comando para introducir un nuevo intervalo en minutos HTTP
            "AT+AC", //comando para introducir un numero de lecturas a acumular
            "AT+AN", //comando para introducir una nueva APN de red
            "AT+IE", //comando para introducir un nuevo identificador de telemetria
            "AT+IS", //comando para introducir un nuevo identificador de sitio
            "AT+RF", //comando para definir el RFC
            "AT+LT", //comando para definir latitud
            "AT+LG", //comando para definir longitud
            "AT+C0", //comando para definir de telefono 1 de la alerta SMS
            "AT+C1", //comando para definir de telefono 2 de la alerta SMS
            "AT+C2", //comando para definir de telefono 3 de la alerta SMS
            "AT+ST", //comando para cambiar fecha y hora
            "AT+HH", //comando para introducir un nuevo host HTTP
            "AT+HU", //comando para introducir un nuevo path HTTP
            "AT+HT", //comando para introducir un nuevo port HTTP
            "AT+HG", //comando para introducir un nuevo path GET HTTP           
            "AT+FH", //comando para introducir un nuevo host FTP
            "AT+FS", //comando para introducir un nuevo user FTP
            "AT+FW", //comando para introducir un nuevo pass FTP
            "AT+FU", //comando para introducir un nuevo path FTP
            "AT+FT", //comando para introducir un nuevo port FTP
            "AT+US", //comando para introducir un nuevo user de red
            "AT+PS", //comando para introducir un nueva pass de red            
            "AT+NM", //comando para introducir un nuevo NSM
            "AT+NT", //comando para introducir un nuevo NSUT
            "AT+NE", //comando para introducir un nuevo NSUE
            "AT+CA", //comando para definir el telefono de la alarma SMS
            "AT+PA", //comando para cambiar contrasena admin
            "AT+PU", //comando para cambiar contrasena user
            "AT+PV", //comando para cambiar contrasena uva
            "AT+TF", //comando para introducir un nuevo intervalo en minutos FTP
            "AT+TS", //comando para introducir un nuevo intervalo en minutos SMS
            "AT+VC", //comando para cambiar codigo de uva
            "AT+VF", //comando para leer la version de firmware
            "AT+SS", //comando para cambiar el numero de esclavo
            "AT+LS", //comando para definir la hora de activacion de la transmision SMS
            "AT+LF", //comando para definir la hora de activacion de la transmision FVTP
            "AT+LH", //comando para definir la hora de activacion de la transmision HTTP
            "AT+MT", //comando para seleccionar medidor
            "AT+SP", //comando para seleccionar el puerto serie
            "AT+SB", //comando para cambiar el baud rate
            "AT+SC", //comando para cambiar la configuracion serie
            "AT+FL", //comando para activar la transmision diaria FTP
            "AT+AL", //comando para activar la transmision diaria SMS
            "AT+AA", //comando para activar la alarma SMS            
            "AT+HL", //comando para activar la transmision diaria HTTP
            "AT+FM", //comando para activar la transmision por minutos FTP
            "AT+AM", //comando para activar la transmision por minutos SMS
            "AT+HM"  //49. comando para activar la transmision por minutos HTTP
        };
        string[] ARRAY_ANSWERS = new string[50];

        public Main()
        {
            InitializeComponent();
        }

 
        private void Form1_Load(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            cBoxCOMPORT.Items.AddRange(ports);
            btnOpen.Enabled = true;
            btnClose.Enabled = false;
            btnSaveMem.Enabled = false;
            serialPort1.DtrEnable = false;
            serialPort1.RtsEnable = true;
            serialPort1.BaudRate = 9600;
            serialPort1.DataBits = 8;
            serialPort1.StopBits = StopBits.One;
            serialPort1.Parity = Parity.None;
            serialPort1.ReadTimeout = 9000;
            serialPort1.WriteTimeout = 9000;
            disableReceiverControl = false;
            Settings.Enabled = false;
            grpBoxLConf.Enabled = false;
            grpBoxPruebas.Enabled = false;
            grpBoxAcceso.Enabled = false;
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            try
            {
                if (cBoxCOMPORT.SelectedIndex > -1)
                {
                    disableReceiverControl = false;
                    serialPort1.PortName = cBoxCOMPORT.Text;
                    serialPort1.Open();
                    btnOpen.Enabled = false;
                    btnClose.Enabled = true;
                    grpBoxAcceso.Enabled = true;
                    btnEnter.Enabled = true;
                    lblStatusCom.Text = "ON";
                }
                else
                {
                    MessageBox.Show("Seleccione un puerto serie", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }

            catch (Exception err)
            {
                MessageBox.Show(err.Message,"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnOpen.Enabled = true;
                btnClose.Enabled = false;
                lblStatusCom.Text = "OFF";
            }
        

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            disableReceiverControl = true;
            if (receivingData == false)
            {
                serialPort1.Close();
                btnOpen.Enabled = true;
                btnClose.Enabled = false;
                lblStatusCom.Text = "OFF";
                Settings.Enabled = false;
                grpBoxLConf.Enabled = false;
                grpBoxPruebas.Enabled = false;
                grpBoxAcceso.Enabled = false;
            }
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                if (disableReceiverControl == false)
                {
                    receivingData = true;
                    dataIN = serialPort1.ReadLine();
                    this.BeginInvoke(new EventHandler(ShowData));
                    receivingData = false;
                }
            }
        }

        private void ShowData(object sender, EventArgs e)
        {
            int dataINLength = dataIN.Length;
            lblDataInLength.Text = string.Format("{0:00}", dataINLength);
            if (ckBox_SC.Checked == false)
            {
                if (dataINLength > 1)
                {
                    tBoxDataIN.Text += DateTime.Now.ToString("HH:mm:ss") + "  " + dataIN + "\n";
                    tBoxDataIN.SelectionStart = tBoxDataIN.TextLength;
                    tBoxDataIN.ScrollToCaret();
                }
            }
        }

        private void btnClearDataIN_Click(object sender, EventArgs e)
        {
            if(tBoxDataIN.Text != "")
            {
                tBoxDataIN.Text = "";
            }
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                
                try
                {
                    string welcome_message = "";
                    if (sBoxUSER.SelectedIndex > -1 && tBox_PASS.Text != "")
                    {
                        serialPort1.Write(sBoxUSER.SelectedIndex.ToString() + "," + tBox_PASS.Text + "\r");
                        disableReceiverControl = true;
                        welcome_message = serialPort1.ReadLine();

                        if (welcome_message.Length > 1)
                        {
                            if (welcome_message.Contains("Bienvenido"))
                            {
                                Settings.Enabled = true;
                                grpBoxLConf.Enabled = true;
                                grpBoxPruebas.Enabled = true;
                                btnEnter.Enabled = false;
                                btnClose.Enabled = false;
                                switch (sBoxUSER.SelectedIndex)
                                {
                                    case 0:
                                        tBox_PA.Enabled = true;
                                        tBox_PU.Enabled = true;
                                        tBox_PV.Enabled = true;
                                        break;
                                    case 1:
                                        tBox_PA.Enabled = false;
                                        tBox_PU.Enabled = false;
                                        tBox_PV.Enabled = false;
                                        break;
                                    case 2:
                                        tBox_PA.Enabled = false;
                                        tBox_PU.Enabled = false;
                                        tBox_PV.Enabled = true;
                                        break;
                                }

                            }
                            else if (welcome_message.Contains("contresena incorrecta"))
                            {
                                MessageBox.Show("Contraseña incorrecta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }

                        int dataINLength = welcome_message.Length;
                        lblDataInLength.Text = string.Format("{0:00}", dataINLength);
                        if (ckBox_SC.Checked == false)
                        {
                            if (dataINLength > 1)
                            {
                                tBoxDataIN.Text += DateTime.Now.ToString("HH:mm:ss") + "  " + welcome_message + "\n";
                                tBoxDataIN.SelectionStart = tBoxDataIN.TextLength;
                                tBoxDataIN.ScrollToCaret();
                            }
                        }
                        disableReceiverControl = false;
                    }
                    else
                    {
                        MessageBox.Show("Introduzca un usuario y contraseña", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
                catch (TimeoutException err)
                {
                    MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                btnCleanTBox.PerformClick();
                serialPort1.Write("AT+CN\r");
                Settings.Enabled = false;
                grpBoxLConf.Enabled = false;
                grpBoxPruebas.Enabled = false;
                grpBoxAcceso.Enabled = false;
                btnClose.Enabled = true;
                serialPort1.ReadTimeout = -1;
                serialPort1.WriteTimeout = -1;
            }
        }

        private void tBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                TextBox XtextBox = (TextBox)sender;
                if (serialPort1.IsOpen)
                {
                    serialPort1.Write(XtextBox.AccessibleDescription + " " + XtextBox.Text + "\r");
                }

            }
        }

        private void tBox_only_numbers(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void ckBox_Click(object sender, EventArgs e)
        {
            CheckBox XcheckBox = (CheckBox)sender;
            if (serialPort1.IsOpen)
            {
                if (XcheckBox.Checked == false)
                {
                    serialPort1.Write(XcheckBox.AccessibleDescription + " 0\r");
                }
                if (XcheckBox.Checked == true)
                {
                    serialPort1.Write(XcheckBox.AccessibleDescription + " 1\r");
                }
            }
        }

        private void cbBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ComboBox XcomboBox = (ComboBox)sender;
            if (serialPort1.IsOpen)
            {
                serialPort1.Write(XcomboBox.AccessibleDescription + " " + XcomboBox.SelectedIndex + "\r");
            }
        }

        private void btn_Click(object sender, EventArgs e)
        {
            Button Xbutton = (Button)sender;
            if (serialPort1.IsOpen)
            {
                serialPort1.Write(Xbutton.AccessibleDescription + "\r");
            }
        }

        private void btnCleanTBox_Click(object sender, EventArgs e)
        {
            tBox_TI.Text = "";
            tBox_AN.Text = "";
            tBox_AC.Text = "";
            tBox_IE.Text = "";
            tBox_IS.Text = "";
            tBox_RF.Text = "";
            tBox_LT.Text = "";
            tBox_LG.Text = "";
            tBox_C0.Text = "";
            tBox_C1.Text = "";
            tBox_C2.Text = "";
            tBox_HH.Text = "";
            tBox_HU.Text = "";
            tBox_HT.Text = "";
            tBox_HG.Text = "";
            tBox_FH.Text = "";
            tBox_FS.Text = "";
            tBox_FW.Text = "";
            tBox_FU.Text = "";
            tBox_FT.Text = "";
            tBox_US.Text = "";
            tBox_PS.Text = "";
            tBox_NM.Text = "";
            tBox_NT.Text = "";
            tBox_NE.Text = "";
            tBox_CA.Text = "";
            tBox_PA.Text = "";
            tBox_PU.Text = "";
            tBox_PV.Text = "";
            tBoxDateTime.Text = "";
            tBox_TF.Text = "";
            tBox_TS.Text = "";
            tBox_VC.Text = "";
            tBox_VF.Text = "";
            tBox_SS.Text = "";
            sBox_LH.SelectedIndex = -1;
            sBox_LF.SelectedIndex = -1;
            sBox_LS.SelectedIndex = -1;
            sBox_MT.SelectedIndex = -1;
            sBox_SB.SelectedIndex = -1;
            sBox_SC.SelectedIndex = -1;
            sBox_SP.SelectedIndex = -1;
            ckBox_AA.Checked = false;
            ckBox_AL.Checked = false;
            ckBox_AM.Checked = false;
            ckBox_FL.Checked = false;
            ckBox_FM.Checked = false;
            ckBox_HL.Checked = false;
            ckBox_HM.Checked = false;
            progressBar1.Value = 0;

        }

        private void btnLoadConf_Click(object sender, EventArgs e)
        {
            try
            {
                if (serialPort1.IsOpen)
                {
                    Settings.Enabled = false;
                    disableReceiverControl = true;
                    String[] spearator = { ": ", "\r"};
                    string message = "";
                    string[] dataRcv = new string[5];
                    string[] answers = new string[50];

                    serialPort1.Write("AT+TI\r");
                    message = serialPort1.ReadLine();
                    dataRcv = message.Split(spearator, StringSplitOptions.RemoveEmptyEntries);
                    if (dataRcv.Length > 1) tBox_TI.Text = dataRcv[1];
                    else tBox_TI.Text = "";
                    progressBar1.Value = 2;

                    serialPort1.Write("AT+AC\r");
                    message = serialPort1.ReadLine();
                    dataRcv = message.Split(spearator, StringSplitOptions.RemoveEmptyEntries);
                    if (dataRcv.Length > 1) tBox_AC.Text = dataRcv[1];
                    else tBox_AC.Text = "";
                    progressBar1.Value = 4;

                    serialPort1.Write("AT+AN\r");
                    message = serialPort1.ReadLine();
                    dataRcv = message.Split(spearator, StringSplitOptions.RemoveEmptyEntries);
                    if (dataRcv.Length > 1) tBox_AN.Text = dataRcv[1];
                    else tBox_AN.Text = "";
                    progressBar1.Value = 6;

                    serialPort1.Write("AT+IE\r");
                    message = serialPort1.ReadLine();
                    dataRcv = message.Split(spearator, StringSplitOptions.RemoveEmptyEntries);
                    if (dataRcv.Length > 1) tBox_IE.Text = dataRcv[1];
                    else tBox_IE.Text = "";
                    progressBar1.Value = 8;

                    serialPort1.Write("AT+IS\r");
                    message = serialPort1.ReadLine();
                    dataRcv = message.Split(spearator, StringSplitOptions.RemoveEmptyEntries);
                    if (dataRcv.Length > 1) tBox_IS.Text = dataRcv[1];
                    else tBox_IS.Text = "";
                    progressBar1.Value = 10;

                    serialPort1.Write("AT+RF\r");
                    message = serialPort1.ReadLine();
                    dataRcv = message.Split(spearator, StringSplitOptions.RemoveEmptyEntries);
                    if (dataRcv.Length > 1) tBox_RF.Text = dataRcv[1];
                    else tBox_RF.Text = "";
                    progressBar1.Value = 12;

                    serialPort1.Write("AT+LT\r");
                    message = serialPort1.ReadLine();
                    dataRcv = message.Split(spearator, StringSplitOptions.RemoveEmptyEntries);
                    if (dataRcv.Length > 1) tBox_LT.Text = dataRcv[1];
                    else tBox_LT.Text = "";
                    progressBar1.Value = 14;

                    serialPort1.Write("AT+LG\r");
                    message = serialPort1.ReadLine();
                    dataRcv = message.Split(spearator, StringSplitOptions.RemoveEmptyEntries);
                    if (dataRcv.Length > 1) tBox_LG.Text = dataRcv[1];
                    else tBox_LG.Text = "";
                    progressBar1.Value = 16;

                    serialPort1.Write("AT+C0\r");
                    message = serialPort1.ReadLine();
                    dataRcv = message.Split(spearator, StringSplitOptions.RemoveEmptyEntries);
                    if (dataRcv.Length > 1) tBox_C0.Text = dataRcv[1];
                    else tBox_C0.Text = "";
                    progressBar1.Value = 18;

                    serialPort1.Write("AT+C1\r");
                    message = serialPort1.ReadLine();
                    dataRcv = message.Split(spearator, StringSplitOptions.RemoveEmptyEntries);
                    if (dataRcv.Length > 1) tBox_C1.Text = dataRcv[1];
                    else tBox_C1.Text = "";
                    progressBar1.Value = 20;

                    serialPort1.Write("AT+C2\r");
                    message = serialPort1.ReadLine();
                    dataRcv = message.Split(spearator, StringSplitOptions.RemoveEmptyEntries);
                    if (dataRcv.Length > 1) tBox_C2.Text = dataRcv[1];
                    else tBox_C2.Text = "";
                    progressBar1.Value = 22;

                    serialPort1.Write("AT+ST\r");
                    message = serialPort1.ReadLine();
                    dataRcv = message.Split(spearator, StringSplitOptions.RemoveEmptyEntries);
                    if (dataRcv.Length > 1) tBoxDateTime.Text = dataRcv[1];
                    else tBoxDateTime.Text = "";
                    progressBar1.Value = 24;

                    serialPort1.Write("AT+HH\r");
                    message = serialPort1.ReadLine();
                    dataRcv = message.Split(spearator, StringSplitOptions.RemoveEmptyEntries);
                    if (dataRcv.Length > 1) tBox_HH.Text = dataRcv[1];
                    else tBox_HH.Text = "";
                    progressBar1.Value = 26;

                    serialPort1.Write("AT+HU\r");
                    message = serialPort1.ReadLine();
                    dataRcv = message.Split(spearator, StringSplitOptions.RemoveEmptyEntries);
                    if (dataRcv.Length > 1) tBox_HU.Text = dataRcv[1];
                    else tBox_HU.Text = "";
                    progressBar1.Value = 28;

                    serialPort1.Write("AT+HT\r");
                    message = serialPort1.ReadLine();
                    dataRcv = message.Split(spearator, StringSplitOptions.RemoveEmptyEntries);
                    if (dataRcv.Length > 1) tBox_HT.Text = dataRcv[1];
                    else tBox_HT.Text = "";
                    progressBar1.Value = 30;

                    serialPort1.Write("AT+HG\r");
                    message = serialPort1.ReadLine();
                    dataRcv = message.Split(spearator, StringSplitOptions.RemoveEmptyEntries);
                    if (dataRcv.Length > 1) tBox_HG.Text = dataRcv[1];
                    else tBox_HG.Text = "";
                    progressBar1.Value = 32;

                    serialPort1.Write("AT+FH\r");
                    message = serialPort1.ReadLine();
                    dataRcv = message.Split(spearator, StringSplitOptions.RemoveEmptyEntries);
                    if (dataRcv.Length > 1) tBox_FH.Text = dataRcv[1];
                    else tBox_FH.Text = "";
                    progressBar1.Value = 34;

                    serialPort1.Write("AT+FS\r");
                    message = serialPort1.ReadLine();
                    dataRcv = message.Split(spearator, StringSplitOptions.RemoveEmptyEntries);
                    if (dataRcv.Length > 1) tBox_FS.Text = dataRcv[1];
                    else tBox_FS.Text = "";
                    progressBar1.Value = 36;

                    serialPort1.Write("AT+FW\r");
                    message = serialPort1.ReadLine();
                    dataRcv = message.Split(spearator, StringSplitOptions.RemoveEmptyEntries);
                    if (dataRcv.Length > 1) tBox_FW.Text = dataRcv[1];
                    else tBox_FW.Text = "";
                    progressBar1.Value = 38;

                    serialPort1.Write("AT+FU\r");
                    message = serialPort1.ReadLine();
                    dataRcv = message.Split(spearator, StringSplitOptions.RemoveEmptyEntries);
                    if (dataRcv.Length > 1) tBox_FU.Text = dataRcv[1];
                    else tBox_FU.Text = "";
                    progressBar1.Value = 40;

                    serialPort1.Write("AT+FT\r");
                    message = serialPort1.ReadLine();
                    dataRcv = message.Split(spearator, StringSplitOptions.RemoveEmptyEntries);
                    if (dataRcv.Length > 1) tBox_FT.Text = dataRcv[1];
                    else tBox_FT.Text = "";
                    progressBar1.Value = 42;

                    serialPort1.Write("AT+US\r");
                    message = serialPort1.ReadLine();
                    dataRcv = message.Split(spearator, StringSplitOptions.RemoveEmptyEntries);
                    if (dataRcv.Length > 1) tBox_US.Text = dataRcv[1];
                    else tBox_US.Text = "";
                    progressBar1.Value = 44;

                    serialPort1.Write("AT+PS\r");
                    message = serialPort1.ReadLine();
                    dataRcv = message.Split(spearator, StringSplitOptions.RemoveEmptyEntries);
                    if (dataRcv.Length > 1) tBox_PS.Text = dataRcv[1];
                    else tBox_PS.Text = "";
                    progressBar1.Value = 46;

                    serialPort1.Write("AT+NM\r");
                    message = serialPort1.ReadLine();
                    dataRcv = message.Split(spearator, StringSplitOptions.RemoveEmptyEntries);
                    if (dataRcv.Length > 1) tBox_NM.Text = dataRcv[1];
                    else tBox_NM.Text = "";
                    progressBar1.Value = 48;

                    serialPort1.Write("AT+NT\r");
                    message = serialPort1.ReadLine();
                    dataRcv = message.Split(spearator, StringSplitOptions.RemoveEmptyEntries);
                    if (dataRcv.Length > 1) tBox_NT.Text = dataRcv[1];
                    else tBox_NT.Text = "";
                    progressBar1.Value = 50;

                    serialPort1.Write("AT+NE\r");
                    message = serialPort1.ReadLine();
                    dataRcv = message.Split(spearator, StringSplitOptions.RemoveEmptyEntries);
                    if (dataRcv.Length > 1) tBox_NE.Text = dataRcv[1];
                    else tBox_NE.Text = "";
                    progressBar1.Value = 52;

                    serialPort1.Write("AT+CA\r");
                    message = serialPort1.ReadLine();
                    dataRcv = message.Split(spearator, StringSplitOptions.RemoveEmptyEntries);
                    if (dataRcv.Length > 1) tBox_CA.Text = dataRcv[1];
                    else tBox_CA.Text = "";
                    progressBar1.Value = 54;

                    serialPort1.Write("AT+PA\r");
                    message = serialPort1.ReadLine();
                    dataRcv = message.Split(spearator, StringSplitOptions.RemoveEmptyEntries);
                    if (dataRcv.Length > 1) tBox_PA.Text = dataRcv[1];
                    else tBox_PA.Text = "";
                    progressBar1.Value = 56;

                    serialPort1.Write("AT+PU\r");
                    message = serialPort1.ReadLine();
                    dataRcv = message.Split(spearator, StringSplitOptions.RemoveEmptyEntries);
                    if (dataRcv.Length > 1) tBox_PU.Text = dataRcv[1];
                    else tBox_PU.Text = "";
                    progressBar1.Value = 58;

                    serialPort1.Write("AT+PV\r");
                    message = serialPort1.ReadLine();
                    dataRcv = message.Split(spearator, StringSplitOptions.RemoveEmptyEntries);
                    if (dataRcv.Length > 1) tBox_PV.Text = dataRcv[1];
                    else tBox_PV.Text = "";
                    progressBar1.Value = 60;

                    serialPort1.Write("AT+TF\r");
                    message = serialPort1.ReadLine();
                    dataRcv = message.Split(spearator, StringSplitOptions.RemoveEmptyEntries);
                    if (dataRcv.Length > 1) tBox_TF.Text = dataRcv[1];
                    else tBox_TF.Text = "";
                    progressBar1.Value = 62;

                    serialPort1.Write("AT+TS\r");
                    message = serialPort1.ReadLine();
                    dataRcv = message.Split(spearator, StringSplitOptions.RemoveEmptyEntries);
                    if (dataRcv.Length > 1) tBox_TS.Text = dataRcv[1];
                    else tBox_TS.Text = "";
                    progressBar1.Value = 64;

                    serialPort1.Write("AT+VC\r");
                    message = serialPort1.ReadLine();
                    dataRcv = message.Split(spearator, StringSplitOptions.RemoveEmptyEntries);
                    if (dataRcv.Length > 1) tBox_VC.Text = dataRcv[1];
                    else tBox_VC.Text = "";
                    progressBar1.Value = 66;

                    serialPort1.Write("AT+VF\r");
                    message = serialPort1.ReadLine();
                    dataRcv = message.Split(spearator, StringSplitOptions.RemoveEmptyEntries);
                    if (dataRcv.Length > 1) tBox_VF.Text = dataRcv[1];
                    else tBox_VF.Text = "";
                    progressBar1.Value = 68;

                    serialPort1.Write("AT+SS\r");
                    message = serialPort1.ReadLine();
                    dataRcv = message.Split(spearator, StringSplitOptions.RemoveEmptyEntries);
                    if (dataRcv.Length > 1) tBox_SS.Text = dataRcv[1];
                    else tBox_SS.Text = "";
                    progressBar1.Value = 70;

                    serialPort1.Write("AT+LS\r");
                    message = serialPort1.ReadLine();
                    dataRcv = message.Split(spearator, StringSplitOptions.RemoveEmptyEntries);
                    if (dataRcv.Length > 1) sBox_LS.SelectedIndex = Int32.Parse(dataRcv[1]);
                    progressBar1.Value = 72;

                    serialPort1.Write("AT+LF\r");
                    message = serialPort1.ReadLine();
                    dataRcv = message.Split(spearator, StringSplitOptions.RemoveEmptyEntries);
                    if (dataRcv.Length > 1) sBox_LF.SelectedIndex = Int32.Parse(dataRcv[1]);
                    progressBar1.Value = 74;

                    serialPort1.Write("AT+LH\r");
                    message = serialPort1.ReadLine();
                    dataRcv = message.Split(spearator, StringSplitOptions.RemoveEmptyEntries);
                    if (dataRcv.Length > 1) sBox_LH.SelectedIndex = Int32.Parse(dataRcv[1]);
                    progressBar1.Value = 76;

                    serialPort1.Write("AT+MT\r");
                    message = serialPort1.ReadLine();
                    dataRcv = message.Split(spearator, StringSplitOptions.RemoveEmptyEntries);
                    if (dataRcv.Length > 1) sBox_MT.SelectedIndex = Int32.Parse(dataRcv[1]);
                    progressBar1.Value = 78;

                    serialPort1.Write("AT+SP\r");
                    message = serialPort1.ReadLine();
                    dataRcv = message.Split(spearator, StringSplitOptions.RemoveEmptyEntries);
                    if (dataRcv.Length > 1) sBox_SP.SelectedIndex = Int32.Parse(dataRcv[1]);
                    progressBar1.Value = 80;

                    serialPort1.Write("AT+SB\r");
                    message = serialPort1.ReadLine();
                    dataRcv = message.Split(spearator, StringSplitOptions.RemoveEmptyEntries);
                    if (dataRcv.Length > 1) sBox_SB.SelectedIndex = Int32.Parse(dataRcv[1]);
                    progressBar1.Value = 82;

                    serialPort1.Write("AT+SC\r");
                    message = serialPort1.ReadLine();
                    dataRcv = message.Split(spearator, StringSplitOptions.RemoveEmptyEntries);
                    if (dataRcv.Length > 1) sBox_SC.SelectedIndex = Int32.Parse(dataRcv[1]);
                    progressBar1.Value = 84;

                    serialPort1.Write("AT+FL\r");
                    message = serialPort1.ReadLine();
                    dataRcv = message.Split(spearator, StringSplitOptions.RemoveEmptyEntries);
                    if (dataRcv.Length > 1)
                    {
                        if (dataRcv[1] == "0") ckBox_FL.Checked = false;
                        if (dataRcv[1] == "1") ckBox_FL.Checked = true;
                    }
                    progressBar1.Value = 86;

                    serialPort1.Write("AT+AL\r");
                    message = serialPort1.ReadLine();
                    dataRcv = message.Split(spearator, StringSplitOptions.RemoveEmptyEntries);
                    if (dataRcv.Length > 1)
                    {
                        if (dataRcv[1] == "0") ckBox_AL.Checked = false;
                        if (dataRcv[1] == "1") ckBox_AL.Checked = true;
                    }
                    progressBar1.Value = 88;

                    serialPort1.Write("AT+AA\r");
                    message = serialPort1.ReadLine();
                    dataRcv = message.Split(spearator, StringSplitOptions.RemoveEmptyEntries);
                    if (dataRcv.Length > 1)
                    {
                        if (dataRcv[1] == "0") ckBox_AA.Checked = false;
                        if (dataRcv[1] == "1") ckBox_AA.Checked = true;
                    }
                    progressBar1.Value = 90;

                    serialPort1.Write("AT+HL\r");
                    message = serialPort1.ReadLine();
                    dataRcv = message.Split(spearator, StringSplitOptions.RemoveEmptyEntries);
                    if (dataRcv.Length > 1)
                    {
                        if (dataRcv[1] == "0") ckBox_HL.Checked = false;
                        if (dataRcv[1] == "1") ckBox_HL.Checked = true;
                    }
                    progressBar1.Value = 92;

                    serialPort1.Write("AT+FM\r");
                    message = serialPort1.ReadLine();
                    dataRcv = message.Split(spearator, StringSplitOptions.RemoveEmptyEntries);
                    if (dataRcv.Length > 1)
                    {
                        if (dataRcv[1] == "0") ckBox_FM.Checked = false;
                        if (dataRcv[1] == "1") ckBox_FM.Checked = true;
                    }
                    progressBar1.Value = 94;

                    serialPort1.Write("AT+AM\r");
                    message = serialPort1.ReadLine();
                    dataRcv = message.Split(spearator, StringSplitOptions.RemoveEmptyEntries);
                    if (dataRcv.Length > 1)
                    {
                        if (dataRcv[1] == "0") ckBox_AM.Checked = false;
                        if (dataRcv[1] == "1") ckBox_AM.Checked = true;
                    }
                    progressBar1.Value = 96;

                    serialPort1.Write("AT+HM\r");
                    message = serialPort1.ReadLine();
                    dataRcv = message.Split(spearator, StringSplitOptions.RemoveEmptyEntries);
                    if (dataRcv.Length > 1)
                    {
                        if (dataRcv[1] == "0") ckBox_HM.Checked = false;
                        if (dataRcv[1] == "1") ckBox_HM.Checked = true;
                    }
                    progressBar1.Value = 98;

                    disableReceiverControl = false;

                    if (tBox_VF.Text.Equals("IMTA.1.0.2"))
                    {
                        sBox_MT.Items[1] = "Risonic Modular";
                        sBox_MT.Items[2] = "NivusFlow 650";
                        sBox_MT.Items[3] = "Vantage 2200";
                        sBox_MT.Items[4] = "SonTek Argonat-XR";
                    }
                    if (tBox_VF.Text.Equals("BGMT.1.0.2"))
                    {
                        sBox_MT.Items[1] = "ModMAG M5000";
                        sBox_MT.Items[2] = "ModMAG M2000";
                        sBox_MT.Items[3] = "ModMAG M1000";
                        sBox_MT.Items[4] = "Sitrans MAG8000";
                    }
                    if (tBox_VF.Text.Equals("PIMT.1.0.2"))
                    {
                        sBox_MT.Items[1] = "Panametrics DF868";
                        sBox_MT.Items[2] = "ModMAG M2000";
                        sBox_MT.Items[3] = "ModMAG M1000";
                        sBox_MT.Items[4] = "Sitrans MAG8000";
                    }
                    progressBar1.Value = 100;
                    Settings.Enabled = true;
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void btnDateTime_Click(object sender, EventArgs e)
        {
            tBoxDateTime.Text = DateTime.Now.ToString("yyyy-MM-dd,HH:mm:ss");
            if (serialPort1.IsOpen)
            {
                serialPort1.Write("AT+ST " + tBoxDateTime.Text + "\r");
            }
        }

        private void btnRefreshPort_Click(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            cBoxCOMPORT.Items.Clear();
            cBoxCOMPORT.Items.AddRange(ports);
        }

        private void cargarConfiguraciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string[] fileContent =  new string[ARRAY_COMMANDS.Count()];
                int lineIndex = 0;
                var filePath = string.Empty;
                using (OpenFileDialog SetOpen = new OpenFileDialog())
                {
                    SetOpen.Filter = ".cfg File (*.cfg)|*.cfg";
                    if (SetOpen.ShowDialog() == DialogResult.OK)
                    {
                        filePath = SetOpen.FileName;
                        var fileStream = SetOpen.OpenFile();
                        using (StreamReader sr = new StreamReader(fileStream))
                        {
                            while (sr.Peek() >= 0)
                            {
                                fileContent[lineIndex] = sr.ReadLine();
                                lineIndex++;
                            }
                            sr.Close();
                            sr.Dispose();
                        }
                    }
                }

                if (serialPort1.IsOpen)
                {
                    disableReceiverControl = true;
                    string message = "";
                    for (int i = 0; i <= ARRAY_COMMANDS.Count() - 1; i++)
                    {
                        serialPort1.Write(fileContent[i] + "\r");
                        Console.WriteLine(fileContent[i] + "\r");
                        tBoxDataIN.Text += "comando: " + fileContent[i] + "\r\nrespuesta: ";
                        message = serialPort1.ReadLine();
                        Console.WriteLine(message);
                        tBoxDataIN.Text += message + "\r\n";
                    }
                    disableReceiverControl = false;
                    btnLoadConf.PerformClick();
                }
                
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void guardarConfiguraciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using (SaveFileDialog SetSave = new SaveFileDialog())
                {
                    SetSave.Title = "Salvar Config";
                    SetSave.Filter = ".cfg File (*.cfg)|*.cfg";
                    SetSave.FileName = "Configuracion_" + DateTime.Now.ToString("yy-MM-dd_H_mm_ss");
                    if (SetSave.ShowDialog() == DialogResult.OK)
                    {
                        using (StreamWriter sw = new StreamWriter(SetSave.FileName, false))
                        {
                            ReadControlsValues();
                            for (int i = 0; i <= ARRAY_COMMANDS.Count() - 1; i++)
                            {
                                sw.WriteLine(ARRAY_COMMANDS[i] + " " + ARRAY_ANSWERS[i]);
                            }
                            sw.Close();
                            sw.Dispose();
                        }
                    }
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        public void ReadControlsValues()
        {
            ARRAY_ANSWERS[0] = tBox_HH.Text;
            ARRAY_ANSWERS[1] = tBox_HU.Text;
            ARRAY_ANSWERS[2] = tBox_HT.Text;
            ARRAY_ANSWERS[3] = tBox_HG.Text;
            ARRAY_ANSWERS[4] = tBox_TI.Text;
            ARRAY_ANSWERS[5] = tBox_AC.Text;
            ARRAY_ANSWERS[6] = tBox_IE.Text;
            ARRAY_ANSWERS[7] = tBox_IS.Text;

            ARRAY_ANSWERS[8] = tBox_FH.Text;
            ARRAY_ANSWERS[9] = tBox_FS.Text;
            ARRAY_ANSWERS[10] = tBox_FW.Text;
            ARRAY_ANSWERS[11] = tBox_FU.Text;
            ARRAY_ANSWERS[12] = tBox_FT.Text;
            if (ckBox_FL.Checked == true) ARRAY_ANSWERS[13] = "1";
            else ARRAY_ANSWERS[13] = "0";
            ARRAY_ANSWERS[14] = sBox_LF.SelectedIndex.ToString();

            ARRAY_ANSWERS[15] = tBox_AN.Text;
            ARRAY_ANSWERS[16] = tBox_US.Text;
            ARRAY_ANSWERS[17] = tBox_PS.Text;

            ARRAY_ANSWERS[18] = tBox_NM.Text;
            ARRAY_ANSWERS[19] = tBox_NT.Text;
            ARRAY_ANSWERS[20] = tBox_NE.Text;
            ARRAY_ANSWERS[21] = tBox_RF.Text;
            ARRAY_ANSWERS[22] = tBox_LT.Text;
            ARRAY_ANSWERS[23] = tBox_LG.Text;

            if (ckBox_AL.Checked == true) ARRAY_ANSWERS[24] = "1";
            else ARRAY_ANSWERS[24] = "0";
            ARRAY_ANSWERS[25] = sBox_LS.SelectedIndex.ToString();

            ARRAY_ANSWERS[26] = tBox_C0.Text;
            ARRAY_ANSWERS[27] = tBox_C1.Text;
            ARRAY_ANSWERS[28] = tBox_C2.Text;

            if (ckBox_AA.Checked == true) ARRAY_ANSWERS[29] = "1";
            else ARRAY_ANSWERS[29] = "0";
            ARRAY_ANSWERS[30] = tBox_CA.Text;

            if (ckBox_HL.Checked == true) ARRAY_ANSWERS[31] = "1";
            else ARRAY_ANSWERS[31] = "0";
            if (ckBox_FM.Checked == true) ARRAY_ANSWERS[32] = "1";
            else ARRAY_ANSWERS[32] = "0";
            if (ckBox_AM.Checked == true) ARRAY_ANSWERS[33] = "1";
            else ARRAY_ANSWERS[33] = "0";
            if (ckBox_HM.Checked == true) ARRAY_ANSWERS[34] = "1";
            else ARRAY_ANSWERS[34] = "0";
            ARRAY_ANSWERS[35] = sBox_LH.SelectedIndex.ToString();
            ARRAY_ANSWERS[36] = tBox_TF.Text;
            ARRAY_ANSWERS[37] = tBox_TS.Text;
            ARRAY_ANSWERS[38] = sBox_MT.SelectedIndex.ToString();
            ARRAY_ANSWERS[39] = sBox_SP.SelectedIndex.ToString();
            ARRAY_ANSWERS[40] = sBox_SB.SelectedIndex.ToString();
            ARRAY_ANSWERS[41] = sBox_SC.SelectedIndex.ToString();
            ARRAY_ANSWERS[42] = tBox_SS.Text;
        }

        private void btnLoadMem_Click(object sender, EventArgs e)
        {
            btnLoadMem.Enabled = false;
            if (serialPort1.IsOpen)
            {
                try
                {
                    String[] spearator = { ": ", "\r" };
                    string ini_message = "";
                    bool exitRecibe = false;
                    string[] dataRcv = new string[5];
                    ulong sizeMEM = 0;
                    grdMemoria.Rows.Clear();
                    grdMemoria.Refresh();

                    disableReceiverControl = true;
                    serialPort1.Write("AT+SM\r");
                    ini_message = serialPort1.ReadLine();
                    dataRcv = ini_message.Split(spearator, StringSplitOptions.RemoveEmptyEntries);
                    if (dataRcv.Length > 1) sizeMEM = Convert.ToUInt64(dataRcv[1]);

                    if (ini_message.Length > 1)
                    {
                        if (ini_message.Contains("Descargando memoria"))
                        {
                            if (ckBox_SC.Checked == false)
                            {
                                tBoxDataIN.Text += DateTime.Now.ToString("HH:mm:ss") + "  " + ini_message + "\n";
                                tBoxDataIN.SelectionStart = tBoxDataIN.TextLength;
                                tBoxDataIN.ScrollToCaret();
                            }
                            dataIN = "";
                            progressBar1.Value = 0;
                            int rowDataCount = 0;
                            ulong recibeBytes = 0;
                            float dowloadPercent = 0;
                            while (!exitRecibe)
                            {
                                dataIN = serialPort1.ReadLine();
                                dataIN = dataIN.TrimEnd('\r');
                                if (!dataIN.Contains("Descarga finalizada")) 
                                {                                 
                                    rowDataCount++;
                                    grdMemoria.Rows.Add(rowDataCount, dataIN);
                                    recibeBytes += Convert.ToUInt64(dataIN.Length) + 2;
                                    dowloadPercent = (recibeBytes * 100) / sizeMEM;
                                    progressBar1.Value = Convert.ToInt32(dowloadPercent);
                                } 
                                else
                                {
                                    exitRecibe = true;
                                }
                            }
                        }
                        else if (ini_message.Contains("Error al abrir el archivo")) 
                        {
                            MessageBox.Show("Error en archivo de memoria", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else if (ini_message.Contains("No hay datos en memoria"))
                        {
                            MessageBox.Show("No hay datos en memoria", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    disableReceiverControl = false;              
                }
                catch (TimeoutException err)
                {
                    MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            btnLoadMem.Enabled = true;
            btnSaveMem.Enabled = true;

        }

        private void btnSaveMem_Click(object sender, EventArgs e)
        {
            if (grdMemoria.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Title = "Salvar Mem";
                sfd.Filter = "CSV (*.csv)|*.csv";
                sfd.FileName = "MEM001_" + DateTime.Now.ToString("yy-MM-dd_H_mm_ss");

                bool fileError = false;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(sfd.FileName))
                    {
                        try
                        {
                            File.Delete(sfd.FileName);
                        }
                        catch (IOException ex)
                        {
                            fileError = true;
                            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    if (!fileError)
                    {
                        try
                        {
                            int columnCount = grdMemoria.Columns.Count;
                            string columnNames = "";
                            string[] outputCsv = new string[grdMemoria.Rows.Count + 1];
                            for (int i = 0; i < columnCount; i++)
                            {
                                columnNames += grdMemoria.Columns[i].HeaderText.ToString() + ",";
                            }
                            outputCsv[0] += columnNames;

                            for (int i = 1; (i - 1) < grdMemoria.Rows.Count-1; i++)
                            {
                                for (int j = 0; j < columnCount; j++)
                                {
                                    outputCsv[i] += grdMemoria.Rows[i - 1].Cells[j].Value.ToString() + ",";
                                }
                            }

                            File.WriteAllLines(sfd.FileName, outputCsv, Encoding.UTF8);
                            MessageBox.Show("Memoria exportada correctamente", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Error: No se han exportado memoria a archivo", "Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeleteMem_Click(object sender, EventArgs e)
        {
            const string message = "¿Esta seguro que desea borrar memoria del dispostivo?";
            const string caption = "Borrar memoria";
            var result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
          
            if (result == DialogResult.Yes)
            {          
                if (serialPort1.IsOpen)
                {
                    serialPort1.Write(btnDeleteMem.AccessibleDescription + "\r");
                }
            }
        }
    }
}
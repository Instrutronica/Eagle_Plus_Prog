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
            "AT+TI", //5. comando para introducir un nuevo intervalo de muestreo
            "AT+AC", //6. comando para introducir un numero de lecturas a acumular
            "AT+IE", //7. comando para introducir un nuevo identificador de telemetria
            "AT+IS", //8. comando para introducir un nuevo identificador de sitio
            "AT+FH", //9. comando para introducir un nuevo host FTP
            "AT+FS", //10. comando para introducir un nuevo user FTP
            "AT+FW", //11. comando para introducir un nuevo pass FTP
            "AT+FU", //12. comando para introducir un nuevo path FTP
            "AT+FT", //13. comando para introducir un nuevo port FTP
            "AT+FL", //14. comando para activar la alerta FTP
            "AT+LF", //15. comando para definir la hora de activacion de la alerta FTP
            "AT+AN", //16. comando para introducir una nueva APN de red
            "AT+US", //17. comando para introducir un nuevo user de red
            "AT+PS", //18. comando para introducir un nueva pass de red
            "AT+NM", //19. comando para introducir un nuevo NSM
            "AT+NT", //20. comando para introducir un nuevo NSUT
            "AT+NE", //21. comando para introducir un nuevo NSUE
            "AT+RF", //22. comando para definir el RFC
            "AT+LT", //23. comando para definir latitud
            "AT+LG", //24. comando para definir longitud
            "AT+AL", //25. comando para activar la alerta SMS
            "AT+LS", //26. comando para definir la hora de activacion de la alerta SMS
            "AT+C0", //27. comando para definir de telefono 1 de la alerta SMS
            "AT+C1", //28. comando para definir de telefono 2 de la alerta SMS
            "AT+C2", //29. comando para definir de telefono 3 de la alerta SMS
            "AT+AA", //30. comando para activar la alarma SMS
            "AT+CA"  //31. comando para definir el telefono de la alarma SMS
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
            serialPort1.DtrEnable = false;
            serialPort1.RtsEnable = true;
            serialPort1.BaudRate = 9600;
            serialPort1.DataBits = 8;
            serialPort1.StopBits = StopBits.One;
            serialPort1.Parity = Parity.None;
            disableReceiverControl = false;

        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.PortName = cBoxCOMPORT.Text;
                serialPort1.Open();
                progressBar1.Value = 100;
                btnOpen.Enabled = false;
                btnClose.Enabled = true;
                lblStatusCom.Text = "ON";
                
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
            if (receivingData == false)
            {
                serialPort1.Close();
                progressBar1.Value = 0;
                btnOpen.Enabled = true;
                btnClose.Enabled = false;
                lblStatusCom.Text = "OFF";
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
            if (dataINLength > 1)
            {
                tBoxDataIN.Text += DateTime.Now.ToString("HH:mm:ss") + " -> " + dataIN + "\n";
                tBoxDataIN.SelectionStart = tBoxDataIN.TextLength;
                tBoxDataIN.ScrollToCaret();
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
                if (serialPort1.IsOpen)
                {
                    serialPort1.Write("12345\r");
                }
            }
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Write("AT+HP\r");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Write("AT+CN\r");
            }
        }

        private void tBox_AN_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.Write("AT+AN " + tBox_AN.Text + "\r");
                }
            }
        }

        private void tBox_RF_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.Write("AT+RF " + tBox_RF.Text + "\r");
                }
            }
        }

        private void tBox_LT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.Write("AT+LT " + tBox_LT.Text + "\r");
                }
            }
        }

        private void tBox_LG_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.Write("AT+LG " + tBox_LG.Text + "\r");
                }
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
            tBoxDateTime.Text = "";
        }

        private void btnLoadConf_Click(object sender, EventArgs e)
        {
            try
            {
                if (serialPort1.IsOpen)
                {
                    disableReceiverControl = true;
                    String[] spearator = { ": ", "\r"};

                    serialPort1.Write("AT+TI\r");
                    string message = serialPort1.ReadLine();
                    string[] dataRcv = message.Split(spearator, StringSplitOptions.RemoveEmptyEntries);
                    if (dataRcv.Length > 1) tBox_TI.Text = dataRcv[1];
                    else tBox_TI.Text = "";

                    serialPort1.Write("AT+AC\r");
                    message = serialPort1.ReadLine();
                    dataRcv = message.Split(spearator, StringSplitOptions.RemoveEmptyEntries);
                    if (dataRcv.Length > 1) tBox_AC.Text = dataRcv[1];
                    else tBox_AC.Text = "";

                    serialPort1.Write("AT+AN\r");
                    message = serialPort1.ReadLine();
                    dataRcv = message.Split(spearator, StringSplitOptions.RemoveEmptyEntries);
                    if (dataRcv.Length > 1) tBox_AN.Text = dataRcv[1];
                    else tBox_AN.Text = "";
                    
                    serialPort1.Write("AT+IE\r");
                    message = serialPort1.ReadLine();
                    dataRcv = message.Split(spearator, StringSplitOptions.RemoveEmptyEntries);
                    if (dataRcv.Length > 1) tBox_IE.Text = dataRcv[1];
                    else tBox_IE.Text = "";

                    serialPort1.Write("AT+IS\r");
                    message = serialPort1.ReadLine();
                    dataRcv = message.Split(spearator, StringSplitOptions.RemoveEmptyEntries);
                    if (dataRcv.Length > 1) tBox_IS.Text = dataRcv[1];
                    else tBox_IS.Text = "";
                    
                    serialPort1.Write("AT+AL\r");
                    message = serialPort1.ReadLine();
                    dataRcv = message.Split(spearator, StringSplitOptions.RemoveEmptyEntries);
                    if (dataRcv.Length > 1)
                    {
                        if (dataRcv[1] == "0") ckBox_AL.Checked = false;
                        if (dataRcv[1] == "1") ckBox_AL.Checked = true;
                    }

                    serialPort1.Write("AT+LS\r");
                    message = serialPort1.ReadLine();
                    dataRcv = message.Split(spearator, StringSplitOptions.RemoveEmptyEntries);
                    if (dataRcv.Length > 1) cBox_LS.SelectedIndex = Int32.Parse(dataRcv[1]);

                    serialPort1.Write("AT+RF\r");
                    message = serialPort1.ReadLine();
                    dataRcv = message.Split(spearator, StringSplitOptions.RemoveEmptyEntries);
                    if (dataRcv.Length > 1) tBox_RF.Text = dataRcv[1];
                    else tBox_RF.Text = "";

                    serialPort1.Write("AT+LT\r");
                    message = serialPort1.ReadLine();
                    dataRcv = message.Split(spearator, StringSplitOptions.RemoveEmptyEntries);
                    if (dataRcv.Length > 1) tBox_LT.Text = dataRcv[1];
                    else tBox_LT.Text = "";

                    serialPort1.Write("AT+LG\r");
                    message = serialPort1.ReadLine();
                    dataRcv = message.Split(spearator, StringSplitOptions.RemoveEmptyEntries);
                    if (dataRcv.Length > 1) tBox_LG.Text = dataRcv[1];
                    else tBox_LG.Text = "";

                    serialPort1.Write("AT+C0\r");
                    message = serialPort1.ReadLine();
                    dataRcv = message.Split(spearator, StringSplitOptions.RemoveEmptyEntries);
                    if (dataRcv.Length > 1) tBox_C0.Text = dataRcv[1];
                    else tBox_C0.Text = "";                

                    serialPort1.Write("AT+C1\r");
                    message = serialPort1.ReadLine();
                    dataRcv = message.Split(spearator, StringSplitOptions.RemoveEmptyEntries);
                    if (dataRcv.Length > 1) tBox_C1.Text = dataRcv[1];
                    else tBox_C1.Text = "";

                    serialPort1.Write("AT+C2\r");
                    message = serialPort1.ReadLine();
                    dataRcv = message.Split(spearator, StringSplitOptions.RemoveEmptyEntries);
                    if (dataRcv.Length > 1) tBox_C2.Text = dataRcv[1];
                    else tBox_C2.Text = "";

                    serialPort1.Write("AT+ST\r");
                    message = serialPort1.ReadLine();
                    dataRcv = message.Split(spearator, StringSplitOptions.RemoveEmptyEntries);
                    if (dataRcv.Length > 1) tBoxDateTime.Text = dataRcv[1];
                    else tBoxDateTime.Text = "";
                    
                    serialPort1.Write("AT+HH\r");
                    message = serialPort1.ReadLine();
                    dataRcv = message.Split(spearator, StringSplitOptions.RemoveEmptyEntries);
                    if (dataRcv.Length > 1) tBox_HH.Text = dataRcv[1];
                    else tBox_HH.Text = "";
                    
                    serialPort1.Write("AT+HU\r");
                    message = serialPort1.ReadLine();
                    dataRcv = message.Split(spearator, StringSplitOptions.RemoveEmptyEntries);
                    if (dataRcv.Length > 1) tBox_HU.Text = dataRcv[1];
                    else tBox_HU.Text = "";
                    
                    serialPort1.Write("AT+HT\r");
                    message = serialPort1.ReadLine();
                    dataRcv = message.Split(spearator, StringSplitOptions.RemoveEmptyEntries);
                    if (dataRcv.Length > 1) tBox_HT.Text = dataRcv[1];
                    else tBox_HT.Text = "";

                    serialPort1.Write("AT+HG\r");
                    message = serialPort1.ReadLine();
                    dataRcv = message.Split(spearator, StringSplitOptions.RemoveEmptyEntries);
                    if (dataRcv.Length > 1) tBox_HG.Text = dataRcv[1];
                    else tBox_HG.Text = "";

                    serialPort1.Write("AT+FH\r");
                    message = serialPort1.ReadLine();
                    dataRcv = message.Split(spearator, StringSplitOptions.RemoveEmptyEntries);
                    if (dataRcv.Length > 1) tBox_FH.Text = dataRcv[1];
                    else tBox_FH.Text = "";
                    
                    serialPort1.Write("AT+FS\r");
                    message = serialPort1.ReadLine();
                    dataRcv = message.Split(spearator, StringSplitOptions.RemoveEmptyEntries);
                    if (dataRcv.Length > 1) tBox_FS.Text = dataRcv[1];
                    else tBox_FS.Text = "";                    

                    serialPort1.Write("AT+FW\r");
                    message = serialPort1.ReadLine();
                    dataRcv = message.Split(spearator, StringSplitOptions.RemoveEmptyEntries);
                    if (dataRcv.Length > 1) tBox_FW.Text = dataRcv[1];
                    else tBox_FW.Text = "";
                    
                    serialPort1.Write("AT+FU\r");
                    message = serialPort1.ReadLine();
                    dataRcv = message.Split(spearator, StringSplitOptions.RemoveEmptyEntries);
                    if (dataRcv.Length > 1) tBox_FU.Text = dataRcv[1];
                    else tBox_FU.Text = "";

                    serialPort1.Write("AT+FT\r");
                    message = serialPort1.ReadLine();
                    dataRcv = message.Split(spearator, StringSplitOptions.RemoveEmptyEntries);
                    if (dataRcv.Length > 1) tBox_FT.Text = dataRcv[1];
                    else tBox_FT.Text = "";


                    serialPort1.Write("AT+FL\r");
                    message = serialPort1.ReadLine();
                    dataRcv = message.Split(spearator, StringSplitOptions.RemoveEmptyEntries);
                    if (dataRcv.Length > 1)
                    { 
                        if (dataRcv[1] == "0") ckBox_FL.Checked = false;
                        if (dataRcv[1] == "1") ckBox_FL.Checked = true;
                    }

                    serialPort1.Write("AT+LF\r");
                    message = serialPort1.ReadLine();
                    dataRcv = message.Split(spearator, StringSplitOptions.RemoveEmptyEntries);
                    if (dataRcv.Length > 1) cBox_LF.SelectedIndex = Int32.Parse(dataRcv[1]);

                    serialPort1.Write("AT+US\r");
                    message = serialPort1.ReadLine();
                    dataRcv = message.Split(spearator, StringSplitOptions.RemoveEmptyEntries);
                    if (dataRcv.Length > 1) tBox_US.Text = dataRcv[1];
                    else tBox_US.Text = "";
                    
                    serialPort1.Write("AT+PS\r");
                    message = serialPort1.ReadLine();
                    dataRcv = message.Split(spearator, StringSplitOptions.RemoveEmptyEntries);
                    if (dataRcv.Length > 1) tBox_PS.Text = dataRcv[1];
                    else tBox_PS.Text = "";

                    serialPort1.Write("AT+NM\r");
                    message = serialPort1.ReadLine();
                    dataRcv = message.Split(spearator, StringSplitOptions.RemoveEmptyEntries);
                    if (dataRcv.Length > 1) tBox_NM.Text = dataRcv[1];
                    else tBox_NM.Text = "";
                    
                    serialPort1.Write("AT+NT\r");
                    message = serialPort1.ReadLine();
                    dataRcv = message.Split(spearator, StringSplitOptions.RemoveEmptyEntries);
                    if (dataRcv.Length > 1) tBox_NT.Text = dataRcv[1];
                    else tBox_NT.Text = "";
                   
                    serialPort1.Write("AT+NE\r");
                    message = serialPort1.ReadLine();
                    dataRcv = message.Split(spearator, StringSplitOptions.RemoveEmptyEntries);
                    if (dataRcv.Length > 1) tBox_NE.Text = dataRcv[1];
                    else tBox_NE.Text = "";
                    
                    serialPort1.Write("AT+AA\r");
                    message = serialPort1.ReadLine();
                    dataRcv = message.Split(spearator, StringSplitOptions.RemoveEmptyEntries);
                    if (dataRcv.Length > 1)
                    {
                        if (dataRcv[1] == "0") ckBox_AA.Checked = false;
                        if (dataRcv[1] == "1") ckBox_AA.Checked = true;
                    }

                    serialPort1.Write("AT+CA\r");
                    message = serialPort1.ReadLine();
                    dataRcv = message.Split(spearator, StringSplitOptions.RemoveEmptyEntries);
                    if (dataRcv.Length > 1) tBox_CA.Text = dataRcv[1];
                    else tBox_CA.Text = "";

                    disableReceiverControl = false;
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

        private void tBox_US_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.Write("AT+US " + tBox_US.Text + "\r");
                }
            }

        }

        private void tBox_PS_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.Write("AT+PS " + tBox_PS.Text + "\r");
                }
            }
        }

        private void tBox_NM_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.Write("AT+NM " + tBox_NM.Text + "\r");
                }
            }
        }

        private void tBox_NT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.Write("AT+NT " + tBox_NT.Text + "\r");
                }
            }
        }

        private void tBox_NE_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.Write("AT+NE " + tBox_NE.Text + "\r");
                }
            }
        }

        private void tBox_HH_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.Write("AT+HH " + tBox_HH.Text + "\r");
                }
            }
        }

        private void tBox_HU_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.Write("AT+HU " + tBox_HU.Text + "\r");
                }
            }
        }

        private void tBox_HT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.Write("AT+HT " + tBox_HT.Text + "\r");
                }
            }
        }

        private void tBox_HG_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.Write("AT+HG " + tBox_HG.Text + "\r");
                }
            }   
        }

        private void tBox_FH_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.Write("AT+FH " + tBox_FH.Text + "\r");
                }
            }
        }

        private void tBox_FS_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.Write("AT+FS " + tBox_FS.Text + "\r");
                }
            }
        }

        private void tBox_FW_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.Write("AT+FW " + tBox_FW.Text + "\r");
                }
            }
        }

        private void tBox_FU_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.Write("AT+FU " + tBox_FU.Text + "\r");
                }
            }
        }

        private void tBox_FT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.Write("AT+FT " + tBox_FT.Text + "\r");
                }
            }
        }

        private void tBox_C0_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.Write("AT+C0 " + tBox_C0.Text + "\r");
                }
            }
        }

        private void tBox_C1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.Write("AT+C1 " + tBox_C1.Text + "\r");
                }
            }
        }

        private void tBox_C2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.Write("AT+C2 " + tBox_C2.Text + "\r");
                }
            }
        }

        private void btnModbus_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Write("AT+MB\r");
            }

        }

        private void ckBox_FL_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {               
                if (ckBox_FL.Checked == false)
                {
                    serialPort1.Write("AT+FL 0\r");
                } 
                if (ckBox_FL.Checked == true)
                {
                    serialPort1.Write("AT+FL 1\r");
                }
            }
        }

        private void ckBox_AL_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                if (ckBox_AL.Checked == false)
                {
                    serialPort1.Write("AT+AL 0\r");
                }
                if (ckBox_AL.Checked == true)
                {
                    serialPort1.Write("AT+AL 1\r");
                }
            }
        }

        private void cBox_LF_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Write("AT+LF " + cBox_LF.SelectedIndex + "\r");
            }
        }

        private void tBox_TI_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.Write("AT+TI " + tBox_TI.Text + "\r");
                }
            }
        }

        private void tBox_IS_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.Write("AT+IS " + tBox_IS.Text + "\r");
                }
            }
        }

        private void tBox_IE_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.Write("AT+IE " + tBox_IE.Text + "\r");
                }
            }
        }

        private void tBox_AC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.Write("AT+AC " + tBox_AC.Text + "\r");
                }
            }
        }

        private void cBox_LS_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Write("AT+LS " + cBox_LS.SelectedIndex + "\r");
            }
        }

        private void tBox_CA_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.Write("AT+CA " + tBox_CA.Text + "\r");
                }
            }
        }

        private void ckBox_AA_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                if (ckBox_AA.Checked == false)
                {
                    serialPort1.Write("AT+AA 0\r");
                }
                if (ckBox_AA.Checked == true)
                {
                    serialPort1.Write("AT+AA 1\r");
                }
            }
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
                    SetSave.Title = "Salvar";
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
            ARRAY_ANSWERS[14] = cBox_LF.SelectedIndex.ToString();

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
            ARRAY_ANSWERS[25] = cBox_LS.SelectedIndex.ToString();

            ARRAY_ANSWERS[26] = tBox_C0.Text;
            ARRAY_ANSWERS[27] = tBox_C1.Text;
            ARRAY_ANSWERS[28] = tBox_C2.Text;

            if (ckBox_AA.Checked == true) ARRAY_ANSWERS[29] = "1";
            else ARRAY_ANSWERS[29] = "0";
            ARRAY_ANSWERS[30] = tBox_CA.Text;
            
        }

    }
}

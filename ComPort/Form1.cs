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

namespace ComPort
{
    public partial class Main : Form
    {
        string dataIN;
        bool disableReceiverControl;

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
            if(serialPort1.IsOpen)
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
            if (disableReceiverControl == false)
            {
                dataIN = serialPort1.ReadLine();
                this.Invoke(new EventHandler(ShowData));
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
                serialPort1.Write("12345\r");
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
                    tBox_TI.Text = "";
                    tBox_TI.Text = dataRcv[1];

                    serialPort1.Write("AT+AC\r");
                    message = serialPort1.ReadLine();
                    dataRcv = message.Split(spearator, StringSplitOptions.RemoveEmptyEntries);
                    tBox_AC.Text = dataRcv[1];

                    serialPort1.Write("AT+AN\r");
                    message = serialPort1.ReadLine();
                    dataRcv = message.Split(spearator, StringSplitOptions.RemoveEmptyEntries);
                    tBox_AN.Text = dataRcv[1];

                    serialPort1.Write("AT+IE\r");
                    message = serialPort1.ReadLine();
                    dataRcv = message.Split(spearator, StringSplitOptions.RemoveEmptyEntries);
                    tBox_IE.Text = dataRcv[1];

                    serialPort1.Write("AT+IS\r");
                    message = serialPort1.ReadLine();
                    dataRcv = message.Split(spearator, StringSplitOptions.RemoveEmptyEntries);
                    tBox_IS.Text = dataRcv[1];

                    serialPort1.Write("AT+AL\r");
                    message = serialPort1.ReadLine();
                    dataRcv = message.Split(spearator, StringSplitOptions.RemoveEmptyEntries);
                    if (dataRcv[1] == "0")
                    {
                        ckBox_AL.Checked = false;
                    }
                    if (dataRcv[1] == "1")
                    {
                        ckBox_AL.Checked = true;
                    }

                    serialPort1.Write("AT+LS\r");
                    message = serialPort1.ReadLine();
                    dataRcv = message.Split(spearator, StringSplitOptions.RemoveEmptyEntries);
                    cBox_LS.SelectedIndex = Int32.Parse(dataRcv[1]);

                    serialPort1.Write("AT+RF\r");
                    message = serialPort1.ReadLine();
                    dataRcv = message.Split(spearator, StringSplitOptions.RemoveEmptyEntries);
                    tBox_RF.Text = dataRcv[1];

                    serialPort1.Write("AT+LT\r");
                    message = serialPort1.ReadLine();
                    dataRcv = message.Split(spearator, StringSplitOptions.RemoveEmptyEntries);
                    tBox_LT.Text = dataRcv[1];

                    serialPort1.Write("AT+LG\r");
                    message = serialPort1.ReadLine();
                    dataRcv = message.Split(spearator, StringSplitOptions.RemoveEmptyEntries);
                    tBox_LG.Text = dataRcv[1];

                    serialPort1.Write("AT+C0\r");
                    message = serialPort1.ReadLine();
                    dataRcv = message.Split(spearator, StringSplitOptions.RemoveEmptyEntries);
                    tBox_C0.Text = dataRcv[1];

                    serialPort1.Write("AT+C1\r");
                    message = serialPort1.ReadLine();
                    dataRcv = message.Split(spearator, StringSplitOptions.RemoveEmptyEntries);
                    tBox_C1.Text = dataRcv[1];

                    serialPort1.Write("AT+C2\r");
                    message = serialPort1.ReadLine();
                    dataRcv = message.Split(spearator, StringSplitOptions.RemoveEmptyEntries);
                    tBox_C2.Text = dataRcv[1];

                    serialPort1.Write("AT+ST\r");
                    message = serialPort1.ReadLine();
                    dataRcv = message.Split(spearator, StringSplitOptions.RemoveEmptyEntries);
                    tBoxDateTime.Text = dataRcv[1];

                    serialPort1.Write("AT+HH\r");
                    message = serialPort1.ReadLine();
                    dataRcv = message.Split(spearator, StringSplitOptions.RemoveEmptyEntries);
                    tBox_HH.Text = dataRcv[1];

                    serialPort1.Write("AT+HU\r");
                    message = serialPort1.ReadLine();
                    dataRcv = message.Split(spearator, StringSplitOptions.RemoveEmptyEntries);
                    tBox_HU.Text = dataRcv[1];

                    serialPort1.Write("AT+HT\r");
                    message = serialPort1.ReadLine();
                    dataRcv = message.Split(spearator, StringSplitOptions.RemoveEmptyEntries);
                    tBox_HT.Text = dataRcv[1];

                    serialPort1.Write("AT+FH\r");
                    message = serialPort1.ReadLine();
                    dataRcv = message.Split(spearator, StringSplitOptions.RemoveEmptyEntries);
                    tBox_FH.Text = dataRcv[1];

                    serialPort1.Write("AT+FS\r");
                    message = serialPort1.ReadLine();
                    dataRcv = message.Split(spearator, StringSplitOptions.RemoveEmptyEntries);
                    tBox_FS.Text = dataRcv[1];

                    serialPort1.Write("AT+FW\r");
                    message = serialPort1.ReadLine();
                    dataRcv = message.Split(spearator, StringSplitOptions.RemoveEmptyEntries);
                    tBox_FW.Text = dataRcv[1];

                    serialPort1.Write("AT+FU\r");
                    message = serialPort1.ReadLine();
                    dataRcv = message.Split(spearator, StringSplitOptions.RemoveEmptyEntries);
                    tBox_FU.Text = dataRcv[1];

                    serialPort1.Write("AT+FT\r");
                    message = serialPort1.ReadLine();
                    dataRcv = message.Split(spearator, StringSplitOptions.RemoveEmptyEntries);
                    tBox_FT.Text = dataRcv[1];

                    serialPort1.Write("AT+FL\r");
                    message = serialPort1.ReadLine();
                    dataRcv = message.Split(spearator, StringSplitOptions.RemoveEmptyEntries);
                    if (dataRcv[1] == "0") 
                    {
                        ckBox_FL.Checked = false;
                    }
                    if (dataRcv[1] == "1")
                    {
                        ckBox_FL.Checked = true;
                    }

                    serialPort1.Write("AT+LF\r");
                    message = serialPort1.ReadLine();
                    dataRcv = message.Split(spearator, StringSplitOptions.RemoveEmptyEntries);
                    cBox_LF.SelectedIndex = Int32.Parse(dataRcv[1]);

                    serialPort1.Write("AT+US\r");
                    message = serialPort1.ReadLine();
                    dataRcv = message.Split(spearator, StringSplitOptions.RemoveEmptyEntries);
                    tBox_US.Text = dataRcv[1];

                    serialPort1.Write("AT+PS\r");
                    message = serialPort1.ReadLine();
                    dataRcv = message.Split(spearator, StringSplitOptions.RemoveEmptyEntries);
                    tBox_PS.Text = dataRcv[1];

                    serialPort1.Write("AT+NM\r");
                    message = serialPort1.ReadLine();
                    dataRcv = message.Split(spearator, StringSplitOptions.RemoveEmptyEntries);
                    tBox_NM.Text = dataRcv[1];

                    serialPort1.Write("AT+NT\r");
                    message = serialPort1.ReadLine();
                    dataRcv = message.Split(spearator, StringSplitOptions.RemoveEmptyEntries);
                    tBox_NT.Text = dataRcv[1];

                    serialPort1.Write("AT+NE\r");
                    message = serialPort1.ReadLine();
                    dataRcv = message.Split(spearator, StringSplitOptions.RemoveEmptyEntries);
                    tBox_NE.Text = dataRcv[1];

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
    }
}

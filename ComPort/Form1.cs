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
    public partial class Form1 : Form
    {
        string dataIN;
        bool disableReceiverControl;

        public Form1()
        {
            InitializeComponent();
        }

 
        private void Form1_Load(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            cBoxCOMPORT.Items.AddRange(ports);
            btnOpen.Enabled = true;
            btnClose.Enabled = false;
            chBoxDtrEnable.Checked = false;
            serialPort1.DtrEnable = false;
            serialPort1.RtsEnable = true;
            disableReceiverControl = false;

        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.PortName = cBoxCOMPORT.Text;
                serialPort1.BaudRate = Convert.ToInt32(CBoxBaudRate.Text);
                serialPort1.DataBits = Convert.ToInt32(cBoxDataBits.Text);
                serialPort1.StopBits = (StopBits)Enum.Parse(typeof(StopBits), cBoxStopBits.Text);
                serialPort1.Parity = (Parity)Enum.Parse(typeof(Parity), cBoxParityBits.Text);

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


        private void chBoxDtrEnable_CheckedChanged(object sender, EventArgs e)
        {
            if(chBoxDtrEnable.Checked)
            {
                serialPort1.DtrEnable = true;
                MessageBox.Show("DTR Enable", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else { serialPort1.DtrEnable = false; }
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

        private void tBox_AL_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.Write("AT+AL " + tBox_AL.Text + "\r");
                }
            }
        }

        private void tBox_LS_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.Write("AT+LS " + tBox_LS.Text + "\r");
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

        private void btnCleanTBox_Click(object sender, EventArgs e)
        {
            tBox_TI.Text = "";
            tBox_AN.Text = "";
            tBox_AC.Text = "";
            tBox_IE.Text = "";
            tBox_IS.Text = "";
            tBox_AL.Text = "";
            tBox_LS.Text = "";
            tBox_RF.Text = "";
            tBox_LT.Text = "";
            tBox_LG.Text = "";
            tBox_C0.Text = "";
            tBox_C1.Text = "";
            tBox_C2.Text = "";
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
                    tBox_AL.Text = dataRcv[1];

                    serialPort1.Write("AT+LS\r");
                    message = serialPort1.ReadLine();
                    dataRcv = message.Split(spearator, StringSplitOptions.RemoveEmptyEntries);
                    tBox_LS.Text = dataRcv[1];

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

    }
}

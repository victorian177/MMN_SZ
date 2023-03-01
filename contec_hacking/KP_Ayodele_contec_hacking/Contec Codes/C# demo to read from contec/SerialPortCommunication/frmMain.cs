using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PCComm;
//using CenterSpace.NMath.Core;

namespace PCComm
{
    public partial class frmMain : Form
    {
        CommunicationManager comm ;
        public List<int> C3A1DataMirror;
        string transType = string.Empty;
        public frmMain()
        {
            InitializeComponent();
            comm =  new CommunicationManager(this);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
           LoadValues();
           //SetDefaults();
           SetControlState();
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private void cmdOpen_Click(object sender, EventArgs e)
        {
            comm.Parity = "None";
            comm.StopBits = "One";
            comm.DataBits = "8";
            comm.BaudRate = "921600";
            comm.CurrentTransmissionType = PCComm.CommunicationManager.TransmissionType.Hex;
            comm.PortName = cboPort.Text;
            comm.DisplayWindow = rtbDisplay;
            comm.OpenPort();
            //panel1 = comm.myPanel;
            cmdOpen.Enabled = false;
            cmdClose.Enabled = true;
            cmdSend.Enabled = true;
        }

        //---------------------------------------------------------------------------------------------------------------------------------------
        public void graphing(List<int> value, int det)
        {
            Pen greenpen;
            if(det == 1)
              greenpen   = new Pen(Color.Green, 3);
            else
               greenpen  = new Pen(Color.Red, 3);

            Graphics g = panel1.CreateGraphics();
            //g.DrawLine(greenpen, 0, 45, 67, 784);

           int k = 0;
            for (k = 0; k < value.Count-1; k++)
            {
                g.DrawLine(greenpen, k, value[k]/15, k+1, value[k+1]/15);
            }
            
            g.Dispose();            
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------
        public void graphing(List<Double> value)
        {
            Pen greenpen = new Pen(Color.Green, 3);

            int valueU;
            int valueUM;
            Graphics g = panel1.CreateGraphics();
            //g.DrawLine(greenpen, 0, 45, 67, 784);

            int k = 0;
            for (k = 0; k < value.Count - 1; k++)
            {
                valueU = int.Parse("" + value[k]);
                valueUM = int.Parse("" + value[k+1]);
                g.DrawLine(greenpen, k, valueU / 15, k + 1, valueUM / 15);
            }

            g.Dispose();


        }
        /// <summary>
        /// Method to initialize serial port
        /// values to standard defaults
        /// </summary>
        /*
        private void SetDefaults()
        {
            cboPort.SelectedIndex = 0;
            cboBaud.SelectedText = "921600";
            cboParity.SelectedIndex = 0;
            cboStop.SelectedIndex = 1;
            cboData.SelectedIndex = 1;
        }*/

        /// <summary>
        /// methos to load our serial
        /// port option values
        /// </summary>
        private void LoadValues()
        {
            comm.SetPortNameValues(cboPort);
            //comm.SetParityValues(cboParity);
            //comm.SetStopBitValues(cboStop);
        }

        /// <summary>
        /// method to set the state of controls
        /// when the form first loads
        /// </summary>
        private void SetControlState()
        {
            //rdoHex.Checked = true;
            cmdSend.Enabled = false;
            cmdClose.Enabled = false;
        }
        //-------------------------------------------------------------------------------------------------------------------------------------------
        private void cmdSend_Click(object sender, EventArgs e)
        {
            comm.WriteData("FF");
           
        }

        /*private void rdoHex_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoHex.Checked == true)
            {
                comm.CurrentTransmissionType = PCComm.CommunicationManager.TransmissionType.Hex;
            }
            else
            {
                comm.CurrentTransmissionType = PCComm.CommunicationManager.TransmissionType.Text;
            }
        }*/
        //------------------------------------------------------------------------------------------------------------------------------------------
        private void cmdClose_Click(object sender, EventArgs e)
        {
            comm.WriteData("FF");
            comm.closePort();
            cmdOpen.Enabled = true;
            cmdSend.Enabled = false;
            cmdClose.Enabled = false;
        }

        //----------------------------------------------------------------------------------------------------------------------------------------
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Pen blackpen = new Pen(Color.Black, 3);
            Pen greenpen = new Pen(Color.Green, 3);
            Pen bluepen = new Pen(Color.Blue, 1);
            Pen redpen = new Pen(Color.Red, 3);
            Graphics g = e.Graphics;
            g.DrawLine(blackpen, 0, 0, 938, 0);
            g.DrawLine(blackpen, 938, 0, 938, 255);
            g.DrawLine(blackpen, 938, 255, 0, 255);
            g.DrawLine(blackpen, 0, 255, 0, 0);
            int i = 0;
            int j = 0;
            for (i = 0; i <= 46; i++)
            {
                g.DrawLine(bluepen, i * 20, 0, i * 20, 258);
            }
            for (j = 0; j <= 12; j++)
            {
                g.DrawLine(bluepen, 0, j * 20, 938, j * 20);
            }
            g.Dispose();
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------
        private void button1_Click(object sender, EventArgs e)
        {
            //comm.readPort();
            // graphing();
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------
        private void button2_Click(object sender, EventArgs e)
        {
            comm.WriteData("83");
            comm.WriteData("88");
            mainTimer.Enabled = true;
        }
        //-------------------------------------------------------------------------------------------------------------------------------------------
        private void rtbDisplay_TextChanged(object sender, EventArgs e)
        {

        }

        private void mainTimer_Tick(object sender, EventArgs e)
        {
            if (comm.hasData)
            {
                comm.hasData = false;
               // MessageBox.Show(C3A1DataMirror.Count.ToString());
                List<int> C3A1DataMirror = new List<int>(comm.C3A1Data);
                comm.previousDataUsed = true;
                comm.C3A1Data.Clear();
                string maKay = "";
                foreach(int i in C3A1DataMirror)
                    maKay += (i.ToString()+" ");

                
                this.rtbDisplay.Text = (maKay+"\r\n");
                this.rtbDisplay.Text += (DateTime.Now.ToString()+"\r\n");   


            }
        }



    }
}
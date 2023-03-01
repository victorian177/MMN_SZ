using System;
using System.Text;
using System.Drawing;
using System.IO.Ports;
using System.Windows.Forms;
using System.Collections.Generic;
//using CenterSpace.NMath.Core;
using System.IO;
using Exocortex.DSP;
using System.Diagnostics;
 
namespace PCComm
{
    class CommunicationManager
    {
        #region Manager Enums
        /// <summary>
        /// enumeration to hold our transmission types
        /// </summary>
        public enum TransmissionType { Text, Hex }

        /// <summary>
        /// enumeration to hold our message types
        /// </summary>
        public enum MessageType { Incoming, Outgoing, Normal, Warning, Error };
        #endregion

        #region Manager Variables
        //property variables
        static int numBytesPerBlock = 38;
        private string _baudRate = string.Empty;
        private string _parity = string.Empty;
        private string _stopBits = string.Empty;
        private string _dataBits = string.Empty;
        private string _portName = string.Empty;
        private TransmissionType _transType;
        private RichTextBox _displayWindow;
        private int[] dataPacket;
        public List<int> C3A1Data;
        private List<int> C3A1DataMAF;
        private int C3A1Index = 0;
        private int reading = 0;
        public frmMain fm;
        public byte[] comBuffer = new byte[numBytesPerBlock];
        public bool hasData = false;
        public bool previousDataUsed = true;
        public string str = "";


        //global manager variables
        private Color[] MessageColor = { Color.Blue, Color.Green, Color.Black, Color.Orange, Color.Red };
        private SerialPort comPort = new SerialPort();
        Stopwatch stopwatch;
        #endregion

        #region Manager Properties
        /// <summary>
        /// Property to hold the BaudRate
        /// of our manager class
        /// </summary>
        public string BaudRate
        {
            get { return _baudRate; }
            set { _baudRate = "921600"; }
        }

        /// <summary>
        /// property to hold the Parity
        /// of our manager class
        /// </summary>
        public string Parity
        {
            get { return _parity; }
            set { _parity = value; }
        }

        /// <summary>
        /// property to hold the StopBits
        /// of our manager class
        /// </summary>
        public string StopBits
        {
            get { return _stopBits; }
            set { _stopBits = value; }
        }

        /// <summary>
        /// property to hold the DataBits
        /// of our manager class
        /// </summary>
        public string DataBits
        {
            get { return _dataBits; }
            set { _dataBits = value; }
        }

        /// <summary>
        /// property to hold the PortName
        /// of our manager class
        /// </summary>
        public string PortName
        {
            get { return _portName; }
            set { _portName = value; }
        }

        /// <summary>
        /// property to hold our TransmissionType
        /// of our manager class
        /// </summary>
        public TransmissionType CurrentTransmissionType
        {
            get { return _transType; }
            set { _transType = value; }
        }

        /// <summary>
        /// property to hold our display window
        /// value
        /// </summary>
        public RichTextBox DisplayWindow
        {
            get { return _displayWindow; }
            set { _displayWindow = value; }
        }
        #endregion

        //retrieve number of bytes in the buffer
        //comPort.BytesToRead;
        //create a byte array to hold the awaiting data

        //------------------------------------------------------------------------------------------------------------------------------------------
        #region Manager Constructors
        /// <summary>
        /// Constructor to set the properties of our Manager Class
        /// </summary>
        /// <param name="baud">Desired BaudRate</param>
        /// <param name="par">Desired Parity</param>
        /// <param name="sBits">Desired StopBits</param>
        /// <param name="dBits">Desired DataBits</param>
        /// <param name="name">Desired PortName</param>
        public CommunicationManager(string baud, string par, string sBits, string dBits, string name, RichTextBox rtb, frmMain fm)
        {
            _baudRate = baud;
            _parity = par;
            _stopBits = sBits;
            _dataBits = dBits;
            _portName = name;
            _displayWindow = rtb;
            this.fm = fm;
            //now add an event handler
            comPort.DataReceived += new SerialDataReceivedEventHandler(comPort_DataReceived);
            stopwatch = Stopwatch.StartNew();
        }

        /// <summary>
        /// Comstructor to set the properties of our
        /// serial port communicator to nothing
        /// </summary>
        public CommunicationManager(frmMain fmr)
        {
            _baudRate = string.Empty;
            _parity = string.Empty;
            _stopBits = string.Empty;
            _dataBits = string.Empty;
            _portName = "COM3";
            _displayWindow = null;
            this.fm = fmr;
            C3A1Data = new List<int>();
            C3A1DataMAF = new List<int>();
            C3A1Data.Add(0);
            C3A1Index = 1;
            //add event handler
            comPort.DataReceived += new SerialDataReceivedEventHandler(comPort_DataReceived);
            stopwatch = Stopwatch.StartNew();

        }
        #endregion
        //--------------------------------------------------------------------------------------------------------------------------------------------
        #region WriteData
        public void WriteData(string msg)
        {
            if (msg == "ff")
                reading = 2;
            switch (CurrentTransmissionType)
            {
                case TransmissionType.Text:
                    //first make sure the port is open
                    //if its not open then open it
                    if (!(comPort.IsOpen == true)) comPort.Open();
                    //send the message to the port
                    comPort.Write(msg);
                    //display the message
                    break;
                case TransmissionType.Hex:
                    try
                    {
                        //convert the message to byte array
                        byte[] newMsg = HexToByte(msg);
                        //send the message to the port
                        comPort.Write(newMsg, 0, newMsg.Length);
                        //convert back to hex and display
                    }
                    catch (FormatException ex)
                    {
                        //display error message
                    }
                    finally
                    {
                        _displayWindow.SelectAll();
                    }
                    break;
                default:
                    //first make sure the port is open
                    //if its not open then open it
                    if (!(comPort.IsOpen == true)) comPort.Open();
                    //send the message to the port
                    comPort.Write(msg);
                    break;
                    break;
            }
        }
        #endregion

        //---------------------------------------------------------------------------------------------------------------------------------------------------
        #region HexToByte
        /// <summary>
        /// method to convert hex string into a byte array
        /// </summary>
        /// <param name="msg">string to convert</param>
        /// <returns>a byte array</returns>
        private byte[] HexToByte(string msg)
        {
            //remove any spaces from the string
            msg = msg.Replace(" ", "");
            //create a byte array the length of the
            //divided by 2 (Hex is 2 characters in length)
            byte[] comBuffer = new byte[msg.Length / 2];
            //loop through the length of the provided string
            for (int i = 0; i < msg.Length; i += 2)
                //convert each set of 2 characters to a byte
                //and add to the array
                comBuffer[i / 2] = (byte)Convert.ToByte(msg.Substring(i, 2), 16);
            //return the array
            return comBuffer;
        }
        #endregion
        //---------------------------------------------------------------------------------------------------------------------------------------------------
        #region ByteToHex
        /// <summary>
        /// method to convert a byte array into a hex string
        /// </summary>
        /// <param name="comByte">byte array to convert</param>
        /// <returns>a hex string</returns>
        private string ByteToHex(byte[] comByte)
        {
            //create a new StringBuilder object
            StringBuilder builder = new StringBuilder(comByte.Length * 3);
            StringBuilder dataDisp = new StringBuilder(comByte.Length * 10);
            StringBuilder C3A1 = new StringBuilder(comByte.Length * 10);
            StringBuilder C4A2 = new StringBuilder(comByte.Length * 10);
            //loop through each byte in the array
            
                if (comByte != null)
                {
                    if (comByte[0] != 255)
                    {

                        //builder.Append("not transmitting yet");
                        return "not transmitting yet";// builder.ToString().ToUpper();
                    }
                    else
                    {
                        reading = 1;
                        int i = 0;
                        dataPacket = new int[16];
                        for (i = 0; i < 16; i++)
                        {
                            //since data is actually 12 bits, shift left by 4 the first byte then right by 4 the next byte and add
                            dataPacket[i] = comByte[2 + i * 2] * 16 + comByte[3 + i * 2] % 16;
                            dataDisp.Append(("" + dataPacket[i]).PadRight(6, ' '));
                        }
                        C3A1Data.Add(dataPacket[4]);

                       
                        /*
                        using (StreamWriter writer = new StreamWriter("loopC3S9.txt", true))
                        {
                            writer.Write(dataPacket[4]+" ");
                        }

                        using (StreamWriter writer = new StreamWriter("loopC4S9.txt", true))
                        {
                            writer.Write(dataPacket[5] + " ");
                        }
                        /*if (C3A1Data.Count >= 100)
                        {
                            //textBox1.Text = "got here";
                            int q = 0;
                            Double[] dd = new Double[C3A1Data.Count];
                            for (q = 0; q < C3A1Data.Count; q++)
                            {
                                dd[q] = C3A1Data[q];
                            }
                             DoubleVector ddres = new DoubleVector(C3A1Data.Count);
                            DoubleVector ddd = new DoubleVector(dd);
                            DoubleForward1DFFT fft1024 = new DoubleForward1DFFT(C3A1Data.Count);
                            //DoubleVector fftresult = fft1024.FFT(ddd, ref ddres);
                            fft1024.FFT(ddd, ref ddres);
                            DoubleSymmetricSignalReader reader = fft1024.GetSignalReader(ddd);
                            //C3A1Data.Add(dataPacket[4]);
                            int qw = 0;
                            List<Double> ddw = new List<Double>();
                            for (qw = 0; qw < C3A1Data.Count; qw++)
                            {
                                DoubleComplex elementI = reader[qw];
                                ddw.Add(Double.Parse(""+elementI));
                            }
                            fm.graphing(ddw);
                            //C3A1.Append(("t:" + thirdelement).PadRight(6, ' '));
                        }*/

                        /*if (C3A1Data.Count > 2)
                        {
                            C3A1DataMAF.Add((C3A1Data[C3A1Index] + C3A1Data[(C3A1Index) - 1]) / 2);
                            //fm.graphing(C3A1DataMAF, 1);
                        }
                        if (C3A1DataMAF.Count >= 1024)
                        {

                            ComplexF[] fs = new ComplexF[1024];
                            for (int iq = 0; iq < 1024; iq++)
                            {
                                fs[iq] = ComplexF.FromRealImaginary(Convert.ToSingle(C3A1DataMAF[iq]), 0F);
                            }
                            Fourier.FFT(fs, FourierDirection.Forward);

                            for (int ifq = 0; ifq < 1024; ifq++)
                            {
                                double mag = Math.Sqrt(Math.Pow((fs[ifq].Re), 2) + Math.Pow((fs[ifq].Im), 2));
                                C3A1DataMAF[ifq] = (int)(20 * Math.Log10(mag)) * 50;
                                C3A1.Append("" + (20 * Math.Log10(mag)) + ", ");
                            }
                            if (C3A1DataMAF.Count == 1024)
                                fm.graphing(C3A1DataMAF, 2);
                            C3A1.Append("now starting FFT");
                            /*int ff = 0;
                            for (int ij = 0; ij < 1024; ij++)
                            {
                                if ((Math.Pow(cf[ij].Re, 2) + Math.Pow(cf[ij].Im, 2)) > (Math.Pow(cf[ff].Re, 2) + Math.Pow(cf[ff].Im, 2)))
                                {
                                    ff = i;
                                }
                            }
                            double actualFreq = Convert.ToDouble(ff) * 2.69;*/
                       /* }*/
                       /* else
                        {*/
                            C3A1.Append("" + C3A1Index);
                       /* }*/
                        C3A1Index++;

                        //C3A1.Append(("" + dataPacket[4]).PadRight(6, ' '));
                       // C4A2.Append(("" + dataPacket[5]).PadRight(6, ' '));

                    }
                }
            
            //foreach (byte data in comByte)
                
                //convert the byte to a string and add to the stringbuilder
                //builder.Append(Convert.ToString(data, 16).PadLeft(2, '0').PadRight(3, ' '));
            //return the converted value
            return C3A1.ToString().ToUpper();
        }
        #endregion

        #region OpenPort
        public bool OpenPort()
        {
            try
            {
                //first check if the port is already open
                //if its open then close it
                if (comPort.IsOpen == true) comPort.Close();
                //myPanel = new Panel();
                /*Pen greenpen = new Pen(Color.Green, 3);
                
                Graphics g = myPanel.CreateGraphics();
                g.DrawLine(greenpen, 0, 45, 42, 634);
                g.Dispose();
                */
                
                //set the properties of our SerialPort Object
                comPort.BaudRate = int.Parse(_baudRate);    //BaudRate
                comPort.DataBits = int.Parse(_dataBits);    //DataBits
                comPort.StopBits = (StopBits)Enum.Parse(typeof(StopBits), _stopBits);    //StopBits
                comPort.Parity = (Parity)Enum.Parse(typeof(Parity), _parity);    //Parity
                comPort.PortName = _portName;   //PortName
                //now open the port
                comPort.Open();
                //return true
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion

        public void closePort()
        {
            comPort.Close();
        }

        //---------------------------------------------------------------------------------------------------------------------------------------------------
        public void readPort()
        {
            switch (CurrentTransmissionType)
            {
                //user chose string
                case TransmissionType.Text:
                    //read data waiting in the buffer
                    string msg = comPort.ReadExisting();
                    //display the data to the user
                    break;
                //user chose binary
                case TransmissionType.Hex:
                    //retrieve number of bytes in the buffer
                   // int bytes = 34;//comPort.BytesToRead;
                    //create a byte array to hold the awaiting data
                    //byte[] comBuffer = new byte[bytes];
                    //read the data and store it
                    //int i = 0;
                    //for (i = 0; i < 34; i++)
                    //{
                        //comPort.Read(comBuffer, 0, bytes);
                    //}
                    
                    //display the data to the user
                    //DisplayData(MessageType.Incoming, ByteToHex(comBuffer) + "\n");
                    break;
                default:
                    //read data waiting in the buffer
                    string str = comPort.ReadExisting();
                    //display the data to the user
                    break;
            }
            /*DisplayData(MessageType.Incoming, "listeninger");
            int bytes = comPort.ReadBufferSize;
            //create a byte array to hold the awaiting data
            byte[] comBuffer = new byte[bytes];
            //read the data and store it
            comPort.Read(comBuffer, 0, bytes);
            string portOutput = "" + comBuffer;//sp.ReadExisting();
            DisplayData(MessageType.Incoming, portOutput);*/
        }

        //---------------------------------------------------------------------------------------------------------------------------------------------------
        #region SetParityValues
        public void SetParityValues(object obj)
        {
            foreach (string str in Enum.GetNames(typeof(Parity)))
            {
                ((ComboBox)obj).Items.Add(str);
            }
        }
        #endregion
        //---------------------------------------------------------------------------------------------------------------------------------------------------
        #region SetStopBitValues
        public void SetStopBitValues(object obj)
        {
            foreach (string str in Enum.GetNames(typeof(StopBits)))
            {
                ((ComboBox)obj).Items.Add(str);
            }
        }
        #endregion
        //---------------------------------------------------------------------------------------------------------------------------------------------------

        #region SetPortNameValues
        public void SetPortNameValues(object obj)
        {

            foreach (string str in SerialPort.GetPortNames())
            {
                ((ComboBox)obj).Items.Add(str);
            }
        }
        #endregion


        //---------------------------------------------------------------------------------------------------------------------------------------------------
        #region comPort_DataReceived
        /// <summary>
        /// method that will be called when theres data waiting in the buffer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void comPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            switch (CurrentTransmissionType)
            {
                case TransmissionType.Hex:
                    //read the data and store it
                    if (previousDataUsed == true)
                    {
                        
                        comPort.Read(comBuffer, 0, numBytesPerBlock);

                        if (comBuffer[0] != 255)
                        {
                            return;         //DO SOMETHING
                        }
                        else
                        {
                            int i = 0;
                            dataPacket = new int[16];
                            for (i = 0; i < 16; i++)
                            {
                                //since data is actually 12 bits, shift left by 4 the first byte then right by 4 the next byte and add
                                C3A1Data.Add(comBuffer[2 + i * 2] * 16 + comBuffer[3 + i * 2] % 16);        //LETS BE SURE OF THIS!!!!!!!
                            }                            
                        }


                        stopwatch.Stop();
                        Console.WriteLine(stopwatch.ElapsedMilliseconds);
                        stopwatch.Start();

                        if (C3A1Data.Count >2047)        //how does count work?
                        {
                            hasData = true;
                            previousDataUsed = false;   //set this once we set the flag to use existing data
                        }
                    }

                    break;
                default:
                    //read data waiting in the buffer
                    string str = comPort.ReadExisting();
                    //display the data to the user
                    break;                    
            }
        }
        #endregion
    }
}

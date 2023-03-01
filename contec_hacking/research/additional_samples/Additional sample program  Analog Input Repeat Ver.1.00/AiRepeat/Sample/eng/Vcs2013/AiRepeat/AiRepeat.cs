using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CaioCs;

namespace AiRepeat
{
    public partial class AiRepeat : Form
    {
        //----------------------------------------
        // Create instance Caio class
        //----------------------------------------
        Caio aio = new Caio();

        //----------------------------------------
        // Declaration of global variables
        //----------------------------------------
        public short g_id;
        public ulong g_sampling_count;

        public AiRepeat()
        {
            InitializeComponent();
        }

        private void AiRepeat_Load(object sender, EventArgs e)
        {
            //----------------------------------------
            // Update the initial display of Device Name
            //----------------------------------------
            textBox_DeviceName.Text = "AIO000";
        }

        //================================================================================
        // It is the process when the Device Init button is clicked
        // Initialize the device
        //================================================================================
        private void button_Init_Click(object sender, EventArgs e)
        {
            int    ret1;            // For return value 1
            int    ret2;            // For return value 2
            String error_string;    // Error code string
            String devicename;      // Device name

            //----------------------------------------
            // Initialize the device
            //----------------------------------------
            //--------------------
            // Get device name from the textbox
            //--------------------
            devicename = textBox_DeviceName.Text;
            //--------------------
            // Device initialization
            // Caution for modify this function (if modified, the application may not work)
            //--------------------
            ret1 = aio.Init(devicename, out g_id);
            //----------------------------------------
            // Error process
            //----------------------------------------
            if (ret1 != 0){
                ret2 = aio.GetErrorString(ret1, out error_string);
                //--------------------
                // When failed to get the error string,
                // initialize the error string
                //--------------------
                if (ret2 != 0){
                    error_string = "";
                }
                textBox_Return.Text = "Initialization Process : aio.Init = " + ret1.ToString() + " : " + error_string;
                return;
            }
            //----------------------------------------
            // Reset device
            //----------------------------------------
            ret1 = aio.ResetDevice(g_id);
            //----------------------------------------
            // Error process
            //----------------------------------------
            if (ret1 != 0){
                ret2 = aio.GetErrorString(ret1, out error_string);
                //--------------------
                // When failed to get the error string,
                // initialize the error string
                //--------------------
                if (ret2 != 0){
                    error_string = "";
                }
                textBox_Return.Text = "Initialization Process : aio.ResetDevice = " + ret1.ToString() + " : " + error_string;
                return;
            }
            //----------------------------------------
            // Set the input method to Single-end
            //----------------------------------------
            ret1 = aio.SetAiInputMethod(g_id, 0);
            //----------------------------------------
            // Error process
            //----------------------------------------
            if (ret1 != 0){
                ret2 = aio.GetErrorString(ret1, out error_string);
                //--------------------
                // When failed to get the error string,
                // initialize the error string
                //--------------------
                if (ret2 != 0){
                    error_string = "";
                }
                textBox_Return.Text = "Initialization Process : aio.SetAiInputMethod = " + ret1.ToString() + " : " + error_string;
                return;
            }
            //----------------------------------------
            // Set the number of channels to 1 channel
            //----------------------------------------
            ret1 = aio.SetAiChannels(g_id, 1);
            //----------------------------------------
            // Error process
            //----------------------------------------
            if (ret1 != 0){
                ret2 = aio.GetErrorString(ret1, out error_string);
                //--------------------
                // When failed to get the error string,
                // initialize the error string
                //--------------------
                if (ret2 != 0){
                    error_string = "";
                }
                textBox_Return.Text = "Initialization Process : aio.SetAiChannels = " + ret1.ToString() + " : " + error_string;
                return;
            }
            //----------------------------------------
            // Set the input range to +/- 10V
            //----------------------------------------
            ret1 = aio.SetAiRange(g_id, 0, (short)CaioConst.PM10);
            //----------------------------------------
            // Error process
            //----------------------------------------
            if (ret1 != 0){
                ret2 = aio.GetErrorString(ret1, out error_string);
                //--------------------
                // When failed to get the error string,
                // initialize the error string
                //--------------------
                if (ret2 != 0){
                    error_string = "";
                }
                textBox_Return.Text = "Initialization Process : aio.SetAiRange = " + ret1.ToString() + " : " + error_string;
                return;
            }
            //----------------------------------------
            // Set the memory type to FIFO
            //----------------------------------------
            ret1 = aio.SetAiMemoryType(g_id, 0);
            //----------------------------------------
            // Error process
            //----------------------------------------
            if (ret1 != 0){
                ret2 = aio.GetErrorString(ret1, out error_string);
                //--------------------
                // When failed to get the error string,
                // initialize the error string
                //--------------------
                if (ret2 != 0){
                    error_string = "";
                }
                textBox_Return.Text = "Initialization Process : aio.SetAiMemoryType = " + ret1.ToString() + " : " + error_string;
                return;
            }
            //----------------------------------------
            // Set the clock type to Internal Clock
            //----------------------------------------
            ret1 = aio.SetAiClockType(g_id, 0);
            //----------------------------------------
            // Error process
            //----------------------------------------
            if (ret1 != 0){
                ret2 = aio.GetErrorString(ret1, out error_string);
                //--------------------
                // When failed to get the error string,
                // initialize the error string
                //--------------------
                if (ret2 != 0){
                    error_string = "";
                }
                textBox_Return.Text = "Initialization Process : aio.SetAiClockType = " + ret1.ToString() + " : " + error_string;
                return;
            }
            //----------------------------------------
            // Set the sampling clock to 1 msec
            //----------------------------------------
            ret1 = aio.SetAiSamplingClock(g_id, 1000);
            //----------------------------------------
            // Error process
            //----------------------------------------
            if (ret1 != 0){
                ret2 = aio.GetErrorString(ret1, out error_string);
                //--------------------
                // When failed to get the error string,
                // initialize the error string
                //--------------------
                if (ret2 != 0){
                    error_string = "";
                }
                textBox_Return.Text = "Initialization Process : aio.SetAiSamplingClock = " + ret1.ToString() + " : " + error_string;
                return;
            }
            //----------------------------------------
            // Set the start condition to External Trigger Rising Edge
            //----------------------------------------
            ret1 = aio.SetAiStartTrigger(g_id, 1);
            //----------------------------------------
            // Error process
            //----------------------------------------
            if (ret1 != 0){
                ret2 = aio.GetErrorString(ret1, out error_string);
                //--------------------
                // When failed to get the error string,
                // initialize the error string
                //--------------------
                if (ret2 != 0){
                    error_string = "";
                }
                textBox_Return.Text = "Initialization Process : aio.SetAiStartTrigger = " + ret1.ToString() + " : " + error_string;
                return;
            }
            //----------------------------------------
            // Set the stop condition to Stop Conversion by The Specified Times
            //----------------------------------------
            ret1 = aio.SetAiStopTrigger(g_id, 0);
            //----------------------------------------
            // Error process
            //----------------------------------------
            if (ret1 != 0){
                ret2 = aio.GetErrorString(ret1, out error_string);
                //--------------------
                // When failed to get the error string,
                // initialize the error string
                //--------------------
                if (ret2 != 0){
                    error_string = "";
                }
                textBox_Return.Text = "Initialization Process : aio.SetAiStopTrigger = " + ret1.ToString() + " : " + error_string;
                return;
            }
            //----------------------------------------
            // Set the sampling stop times to 1000
            //----------------------------------------
            ret1 = aio.SetAiStopTimes(g_id, 1000);
            //----------------------------------------
            // Error process
            //----------------------------------------
            if (ret1 != 0){
                ret2 = aio.GetErrorString(ret1, out error_string);
                //--------------------
                // When failed to get the error string,
                // initialize the error string
                //--------------------
                if (ret2 != 0){
                    error_string = "";
                }
                textBox_Return.Text = "Initialization Process : aio.SetAiStopTimes = " + ret1.ToString() + " : " + error_string;
                return;
            }
            //----------------------------------------
            // Set the event factor to 'Event that AD conversion start ', 'Event that repeat end' and 'Event that device operation end'
            // Caution for modify this function (if modified, the application may not work)
            //----------------------------------------
            ret1 = aio.SetAiEvent(g_id, (uint)Handle, (int)(CaioConst.AIE_START | CaioConst.AIE_RPTEND | CaioConst.AIE_END));
            //----------------------------------------
            // Error process
            //----------------------------------------
            if (ret1 != 0){
                ret2 = aio.GetErrorString(ret1, out error_string);
                //--------------------
                // When failed to get the error string,
                // initialize the error string
                //--------------------
                if (ret2 != 0){
                    error_string = "";
                }
                textBox_Return.Text = "Initialization Process : aio.SetAiEvent = " + ret1.ToString() + " : " + error_string;
                return;
            }
            //----------------------------------------
            // Display the message that initialization process is completed
            //----------------------------------------
            textBox_Return.Text = "Initialization Process : Successful completion";
        }

        //================================================================================
        // It is the process when the Repeat Times Setting button is clicked
        // Set the repeat times
        //================================================================================
        private void button_Repeat_Click(object sender, EventArgs e)
        {
            int    ret1;            // For return value 1
            int    ret2;            // For return value 2
            int    repeat_times;    // Repeat times
            String error_string;    // Error code string

            //----------------------------------------
            // Update GUI information
            //----------------------------------------
            this.Refresh();
            //----------------------------------------
            // Set the repeat times
            //----------------------------------------
            try{
                repeat_times = int.Parse(textBox_RepeatTimes.Text);
            }catch{
                repeat_times = 0;
            }
            ret1 = aio.SetAiRepeatTimes(g_id, repeat_times);
            //----------------------------------------
            // Error process
            //----------------------------------------
            if (ret1 != 0){
                ret2 = aio.GetErrorString(ret1, out error_string);
                //--------------------
                // When failed to get the error string,
                // initialize the error string
                //--------------------
                if (ret2 != 0){
                    error_string = "";
                }
                textBox_Return.Text = "Repeat Times Setting Process : aio.SetAiRepeatTimes = " + ret1.ToString() + " : " + error_string;
                return;
            }
            //----------------------------------------
            // Display the message that the repeat times setting process is completed
            //----------------------------------------
            textBox_Return.Text = "Repeat Times Setting Process : Successful completion";
        }

        //================================================================================
        // It is the process when the Sampling Start button is clicked
        // After clearing the memory and status, start sampling
        //================================================================================
        private void button_Start_Click(object sender, EventArgs e)
        {
            int    ret1;                // For return value 1
            int    ret2;                // For return value 2
            String error_string;        // Error code string
            String text_string;         // For updating the textbox
            int    aistatus;            // Analog input status
            int    airepeatcount;       // Analog input repeat times

            //----------------------------------------
            // Clear memory
            //----------------------------------------
            ret1 = aio.ResetAiMemory(g_id);
            //----------------------------------------
            // Error process
            //----------------------------------------
            if (ret1 != 0){
                ret2 = aio.GetErrorString(ret1, out error_string);
                //--------------------
                // When failed to get the error string,
                // initialize the error string
                //--------------------
                if (ret2 != 0){
                    error_string = "";
                }
                textBox_Return.Text = "Sampling Start : aio.ResetAiMemory = " + ret1.ToString() + " : " + error_string;
                return;
            }
            //----------------------------------------
            // Clear status
            //----------------------------------------
            ret1 = aio.ResetAiStatus(g_id);
            //----------------------------------------
            // Error process
            //----------------------------------------
            if (ret1 != 0){
                ret2 = aio.GetErrorString(ret1, out error_string);
                //--------------------
                // When failed to get the error string,
                // initialize the error string
                //--------------------
                if (ret2 != 0){
                    error_string = "";
                }
                textBox_Return.Text = "Sampling Start : aio.ResetAiStatus = " + ret1.ToString() + " : " + error_string;
                return;
            }
            g_sampling_count = 0;
            //----------------------------------------
            // Start sampling
            //----------------------------------------
            ret1 = aio.StartAi(g_id);
            //----------------------------------------
            // Error process
            //----------------------------------------
            if (ret1 != 0){
                ret2 = aio.GetErrorString(ret1, out error_string);
                //--------------------
                // When failed to get the error string,
                // initialize the error string
                //--------------------
                if (ret2 != 0){
                    error_string = "";
                }
                textBox_Return.Text = "Sampling Start : aio.StartAi = " + ret1.ToString() + " : " + error_string;
                return;
            }
            //----------------------------------------
            // Get status
            //----------------------------------------
            ret1 = aio.GetAiStatus(g_id, out aistatus);
            //----------------------------------------
            // Error process
            //----------------------------------------
            if (ret1 != 0){
                ret2 = aio.GetErrorString(ret1, out error_string);
                //--------------------
                // When failed to get the error string,
                // initialize the error string
                //--------------------
                if (ret2 != 0){
                    error_string = "";
                }
                textBox_Return.Text = "Sampling Start : aio.GetAiStatus = " + ret1.ToString() + " : " + error_string;
                return;
            }
            //----------------------------------------
            // Display status
            //----------------------------------------
            text_string = String.Format("{0:X8}H (", aistatus);
            //--------------------
            // When status 'Device is running' is ON
            //--------------------
            if ((aistatus & (int)CaioConst.AIS_BUSY) == (int)CaioConst.AIS_BUSY){
                text_string += "Operating";
            //--------------------
            // When status 'Device is running' is OFF
            //--------------------
            }else{
                text_string += "Stop";
            }
            //--------------------
            // When status 'Wait the start trigger' is ON
            //--------------------
            if ((aistatus & (int)CaioConst.AIS_START_TRG) == (int)CaioConst.AIS_START_TRG){
                text_string += ", Wait the start trigger";
            }
            //--------------------
            // When status 'The specified number of data are stored' is ON
            //--------------------
            if ((aistatus & (int)CaioConst.AIS_DATA_NUM) == (int)CaioConst.AIS_DATA_NUM){
                text_string += ", The specified number of data are stored";
            }
            //--------------------
            // When status 'Overflow' is ON
            //--------------------
            if ((aistatus & (int)CaioConst.AIS_OFERR) == (int)CaioConst.AIS_OFERR){
                text_string += ", Overflow";
            }
            //--------------------
            // When status 'Sampling clock error' is ON
            //--------------------
            if ((aistatus & (int)CaioConst.AIS_SCERR) == (int)CaioConst.AIS_SCERR){
                text_string += ", Sampling clock error";
            }
            //--------------------
            // When status 'AD conversion error' is ON
            //--------------------
            if ((aistatus & (int)CaioConst.AIS_AIERR) == (int)CaioConst.AIS_AIERR){
                text_string += ", AD conversion error";
            }
            //--------------------
            // When status 'Driver spec error' is ON
            //--------------------
            if ((aistatus & (int)CaioConst.AIS_DRVERR) == (int)CaioConst.AIS_DRVERR){
                text_string += ", Driver spec error";
            }
            text_string += ")";
            textBox_Status.Text = text_string;
            //----------------------------------------
            // Update the total sampling times
            //----------------------------------------
            textBox_SamplingCount.Text = g_sampling_count.ToString();
            //----------------------------------------
            // Get the current repeat times
            //----------------------------------------
            ret1 = aio.GetAiRepeatCount(g_id, out airepeatcount);
            //----------------------------------------
            // Error process
            //----------------------------------------
            if (ret1 != 0){
                ret2 = aio.GetErrorString(ret1, out error_string);
                //--------------------
                // When failed to get the error string,
                // initialize the error string
                //--------------------
                if (ret2 != 0){
                    error_string = "";
                }
                textBox_Return.Text = "Sampling Start : aio.GetAiRepeatCount = " + ret1.ToString() + " : " + error_string;
                return;
            }
            //----------------------------------------
            // Update the repeat times
            //----------------------------------------
            textBox_RepeatCount.Text = airepeatcount.ToString();
            //----------------------------------------
            // Display the message that sampling start is completed
            //----------------------------------------
            textBox_Return.Text = "Sampling Start : Successful completion";
        }

        //================================================================================
        // It is the process when the Sampling Stop button is clicked
        // Stop sampling
        //================================================================================
        private void button_Stop_Click(object sender, EventArgs e)
        {
            int    ret1;           // For return value 1
            int    ret2;           // For return value 2
            String error_string;   // Error code string

            //----------------------------------------
            // Stop sampling
            //----------------------------------------
            ret1 = aio.StopAi(g_id);
            //----------------------------------------
            // Error process
            //----------------------------------------
            if (ret1 != 0){
                ret2 = aio.GetErrorString(ret1, out error_string);
                //--------------------
                // When failed to get the error string,
                // initialize the error string
                //--------------------
                if (ret2 != 0){
                    error_string = "";
                }
                textBox_Return.Text = "Sampling Stop : aio.StopAi = " + ret1.ToString() + " : " + error_string;
                return;
            }
            //----------------------------------------
            // Display the message that sampling stop is completed
            //----------------------------------------
            textBox_Return.Text = "Sampling Stop : Successful completion";
        }

        //================================================================================
        // It is the process when the Device Exit button is clicked
        // Perform the exit process of device
        //================================================================================
        private void button_Exit_Click(object sender, EventArgs e)
        {
            int    ret1;           // For return value 1
            int    ret2;           // For return value 2
            String error_string;   // Error code string

            //----------------------------------------
            // Exit process of device
            //----------------------------------------
            ret1 = aio.Exit(g_id);
            //----------------------------------------
            // Error process
            //----------------------------------------
            if (ret1 != 0){
                ret2 = aio.GetErrorString(ret1, out error_string);
                //--------------------
                // When failed to get the error string,
                // initialize the error string
                //--------------------
                if (ret2 != 0){
                    error_string = "";
                }
                textBox_Return.Text = "Device Exit Process : aio.Exit = " + ret1.ToString() + " : " + error_string;
                return;
            }
            //----------------------------------------
            // Display the message that device exit process is completed
            //----------------------------------------
            textBox_Return.Text = "Device Exit Process : Successful completion";
        }

        //================================================================================
        // It is the process when the Close button is clicked
        // Perform the exit process of the application
        //================================================================================
        private void button_Close_Click(object sender, EventArgs e)
        {
            //----------------------------------------
            // Close dialog
            //----------------------------------------
            this.Close();
        }

        //================================================================================
        // Operation when an event occurs
        // Process for each event occurred
        //================================================================================
        [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
        protected override void WndProc(ref Message m)
        {
            int     ret1;                // For return value 1
            int     ret2;                // For return value 2
            String  error_string;        // Error code string
            String  text_string;         // For updating the textbox
            int     aisamplingcount;     // Sampling count
            float[] aidata;              // Analog data
            short   aichannels;          // Number of channels
            int     aistatus;            // Status
            int     airepeatcount;       // Repeat times
            int     i, j;

            //----------------------------------------
            // Event that AD conversion start
            // Acquire and display data
            //----------------------------------------
            if (m.Msg == (short)CaioConst.AIOM_AIE_START){
                //----------------------------------------
                // Get status
                //----------------------------------------
                ret1 = aio.GetAiStatus(g_id, out aistatus);
                //----------------------------------------
                // Error process
                //----------------------------------------
                if (ret1 != 0){
                    ret2 = aio.GetErrorString(ret1, out error_string);
                    //--------------------
                    // When failed to get the error string,
                    // initialize the error string
                    //--------------------
                    if (ret2 != 0){
                        error_string = "";
                    }
                    textBox_Return.Text = "AD Conversion Start Process : aio.GetAiStatus = " + ret1.ToString() + " : " + error_string;
                    return;
                }
                //----------------------------------------
                // Display status
                //----------------------------------------
                text_string = String.Format("{0:X8}H (", aistatus);
                //--------------------
                // When status 'Device is running' is ON
                //--------------------
                if ((aistatus & (int)CaioConst.AIS_BUSY) == (int)CaioConst.AIS_BUSY){
                    text_string += "Operating";
                //--------------------
                // When status 'Device is running' is OFF
                //--------------------
                }else{
                    text_string += "Stop";
                }
                //--------------------
                // When status 'Wait the start trigger' is ON
                //--------------------
                if ((aistatus & (int)CaioConst.AIS_START_TRG) == (int)CaioConst.AIS_START_TRG){
                    text_string += ", Wait the start trigger";
                }
                //--------------------
                // When status 'The specified number of data are stored' is ON
                //--------------------
                if ((aistatus & (int)CaioConst.AIS_DATA_NUM) == (int)CaioConst.AIS_DATA_NUM){
                    text_string += ", The specified number of data are stored";
                }
                //--------------------
                // When status 'Overflow' is ON
                //--------------------
                if ((aistatus & (int)CaioConst.AIS_OFERR) == (int)CaioConst.AIS_OFERR){
                    text_string += ", Overflow";
                }
                //--------------------
                // When status 'Sampling clock error' is ON
                //--------------------
                if ((aistatus & (int)CaioConst.AIS_SCERR) == (int)CaioConst.AIS_SCERR){
                    text_string += ", Sampling clock error";
                }
                //--------------------
                // When status 'AD conversion error' is ON
                //--------------------
                if ((aistatus & (int)CaioConst.AIS_AIERR) == (int)CaioConst.AIS_AIERR){
                    text_string += ", AD conversion error";
                }
                //--------------------
                // When status 'Driver spec error' is ON
                //--------------------
                if ((aistatus & (int)CaioConst.AIS_DRVERR) == (int)CaioConst.AIS_DRVERR){
                    text_string += ", Driver spec error";
                }
                text_string += ")";
                textBox_Status.Text = text_string;
                //----------------------------------------
                // Display the message that event process is completed
                //----------------------------------------
                textBox_Return.Text = "AD Conversion Start Process : Successful completion";
            }
            //----------------------------------------
            // Event that repeat end
            // Acquire and display data
            //----------------------------------------
            if (m.Msg == (short)CaioConst.AIOM_AIE_RPTEND){
                //----------------------------------------
                // Get status
                //----------------------------------------
                ret1 = aio.GetAiStatus(g_id, out aistatus);
                //----------------------------------------
                // Error process
                //----------------------------------------
                if (ret1 != 0){
                    ret2 = aio.GetErrorString(ret1, out error_string);
                    //--------------------
                    // When failed to get the error string,
                    // initialize the error string
                    //--------------------
                    if (ret2 != 0){
                        error_string = "";
                    }
                    textBox_Return.Text = "Repeat End Event Process : aio.GetAiStatus = " + ret1.ToString() + " : " + error_string;
                    return;
                }
                //----------------------------------------
                // Display status
                //----------------------------------------
                text_string = String.Format("{0:X8}H (", aistatus);
                //--------------------
                // When status 'Device is running' is ON
                //--------------------
                if ((aistatus & (int)CaioConst.AIS_BUSY) == (int)CaioConst.AIS_BUSY){
                    text_string += "Operating";
                //--------------------
                // When status 'Device is running' is OFF
                //--------------------
                }else{
                    text_string += "Stop";
                }
                //--------------------
                // When status 'Wait the start trigger' is ON
                //--------------------
                if ((aistatus & (int)CaioConst.AIS_START_TRG) == (int)CaioConst.AIS_START_TRG){
                    text_string += ", Wait the start trigger";
                }
                //--------------------
                // When status 'The specified number of data are stored' is ON
                //--------------------
                if ((aistatus & (int)CaioConst.AIS_DATA_NUM) == (int)CaioConst.AIS_DATA_NUM){
                    text_string += ", The specified number of data are stored";
                }
                //--------------------
                // When status 'Overflow' is ON
                //--------------------
                if ((aistatus & (int)CaioConst.AIS_OFERR) == (int)CaioConst.AIS_OFERR){
                    text_string += ", Overflow";
                }
                //--------------------
                // When status 'Sampling clock error' is ON
                //--------------------
                if ((aistatus & (int)CaioConst.AIS_SCERR) == (int)CaioConst.AIS_SCERR){
                    text_string += ", Sampling clock error";
                }
                //--------------------
                // When status 'AD conversion error' is ON
                //--------------------
                if ((aistatus & (int)CaioConst.AIS_AIERR) == (int)CaioConst.AIS_AIERR){
                    text_string += ", AD conversion error";
                }
                //--------------------
                // When status 'Driver spec error' is ON
                //--------------------
                if ((aistatus & (int)CaioConst.AIS_DRVERR) == (int)CaioConst.AIS_DRVERR){
                    text_string += ", Driver spec error";
                }
                text_string += ")";
                textBox_Status.Text = text_string;
                //----------------------------------------
                // Get the current sampling times
                //----------------------------------------
                ret1 = aio.GetAiSamplingCount(g_id, out aisamplingcount);
                //----------------------------------------
                // Error process
                //----------------------------------------
                if (ret1 != 0){
                    ret2 = aio.GetErrorString(ret1, out error_string);
                    //--------------------
                    // When failed to get the error string,
                    // initialize the error string
                    //--------------------
                    if (ret2 != 0){
                        error_string = "";
                    }
                    textBox_Return.Text = "Repeat End Event Process : aio.GetAiSamplingCount = " + ret1.ToString() + " : " + error_string;
                    return;
                }
                //----------------------------------------
                // Get the number of channels
                //----------------------------------------
                ret1 = aio.GetAiChannels(g_id, out aichannels);
                //----------------------------------------
                // Error process
                //----------------------------------------
                if (ret1 != 0){
                    ret2 = aio.GetErrorString(ret1, out error_string);
                    //--------------------
                    // When failed to get the error string,
                    // initialize the error string
                    //--------------------
                    if (ret2 != 0){
                        error_string = "";
                    }
                    textBox_Return.Text = "Repeat End Event Process : aio.GetAiChannels = " + ret1.ToString() + " : " + error_string;
                    return;
                }
                //----------------------------------------
                // Get sampling data
                //----------------------------------------
                //--------------------
                // Allocate an array for storing data
                //--------------------
                aidata = new float[aisamplingcount * aichannels];
                if (aidata == null){
                    textBox_Return.Text = "Repeat End Event Process : Failed to allocate an array for storing data";
                    return;
                }
                ret1 = aio.GetAiSamplingDataEx(g_id, ref aisamplingcount, ref aidata);
                //----------------------------------------
                // Error process
                //----------------------------------------
                if (ret1 != 0){
                    ret2 = aio.GetErrorString(ret1, out error_string);
                    //--------------------
                    // When failed to get the error string,
                    // initialize the error string
                    //--------------------
                    if (ret2 != 0){
                        error_string = "";
                    }
                    textBox_Return.Text = "Repeat End Event Process : aio.GetAiSamplingDataEx = " + ret1.ToString() + " : " + error_string;
                    aidata = null;
                    return;
                }
                g_sampling_count += (ulong)aisamplingcount;
                //----------------------------------------
                // Update the total sampling times
                //----------------------------------------
                textBox_SamplingCount.Text = g_sampling_count.ToString();
                //----------------------------------------
                // Get the current repeat times
                //----------------------------------------
                ret1 = aio.GetAiRepeatCount(g_id, out airepeatcount);
                //----------------------------------------
                // Error process
                //----------------------------------------
                if (ret1 != 0){
                    ret2 = aio.GetErrorString(ret1, out error_string);
                    //--------------------
                    // When failed to get the error string,
                    // initialize the error string
                    //--------------------
                    if (ret2 != 0){
                        error_string = "";
                    }
                    textBox_Return.Text = "Repeat End Event Process : aio.GetAiRepeatCount = " + ret1.ToString() + " : " + error_string;
                    aidata = null;
                    return;
                }
                //----------------------------------------
                // Update the repeat times
                //----------------------------------------
                textBox_RepeatCount.Text = airepeatcount.ToString();
                //----------------------------------------
                // Store a string for displaying the sampling data
                //----------------------------------------
                text_string = "";
                for (i = 0; i < aisamplingcount; i++)
                {
                    text_string += String.Format("{0,5}:     ", i);
                    for (j = 0; j < aichannels; j++)
                    {
                        text_string += String.Format(aidata[i * aichannels + j].ToString("F5"));
                    }
                    text_string += "\r\n";
                }
                //----------------------------------------
                // Display the sampling data
                //----------------------------------------
                textBox_SamplingData.Text = text_string;
                //----------------------------------------
                // Display the message that event process is completed
                //----------------------------------------
                textBox_Return.Text = "Repeat End Event Process : Successful completion";
                aidata = null;
            }
            //----------------------------------------
            // Event that device operation end
            // Acquire and display data
            //----------------------------------------
            if (m.Msg == (short)CaioConst.AIOM_AIE_END){
                //----------------------------------------
                // Get status
                //----------------------------------------
                ret1 = aio.GetAiStatus(g_id, out aistatus);
                //----------------------------------------
                // Error process
                //----------------------------------------
                if (ret1 != 0){
                    ret2 = aio.GetErrorString(ret1, out error_string);
                    //--------------------
                    // When failed to get the error string,
                    // initialize the error string
                    //--------------------
                    if (ret2 != 0){
                        error_string = "";
                    }
                    textBox_Return.Text = "Device Operation End Event Process : aio.GetAiStatus = " + ret1.ToString() + " : " + error_string;
                    return;
                }
                //----------------------------------------
                // Display status
                //----------------------------------------
                text_string = String.Format("{0:X8}H (", aistatus);
                //--------------------
                // When status 'Device is running' is ON
                //--------------------
                if ((aistatus & (int)CaioConst.AIS_BUSY) == (int)CaioConst.AIS_BUSY){
                    text_string += "Operating";
                //--------------------
                // When status 'Device is running' is OFF
                //--------------------
                }else{
                    text_string += "Stop";
                }
                //--------------------
                // When status 'Wait the start trigger' is ON
                //--------------------
                if ((aistatus & (int)CaioConst.AIS_START_TRG) == (int)CaioConst.AIS_START_TRG){
                    text_string += ", Wait the start trigger";
                }
                //--------------------
                // When status 'The specified number of data are stored' is ON
                //--------------------
                if ((aistatus & (int)CaioConst.AIS_DATA_NUM) == (int)CaioConst.AIS_DATA_NUM){
                    text_string += ", The specified number of data are stored";
                }
                //--------------------
                // When status 'Overflow' is ON
                //--------------------
                if ((aistatus & (int)CaioConst.AIS_OFERR) == (int)CaioConst.AIS_OFERR){
                    text_string += ", Overflow";
                }
                //--------------------
                // When status 'Sampling clock error' is ON
                //--------------------
                if ((aistatus & (int)CaioConst.AIS_SCERR) == (int)CaioConst.AIS_SCERR){
                    text_string += ", Sampling clock error";
                }
                //--------------------
                // When status 'AD conversion error' is ON
                //--------------------
                if ((aistatus & (int)CaioConst.AIS_AIERR) == (int)CaioConst.AIS_AIERR){
                    text_string += ", AD conversion error";
                }
                //--------------------
                // When status 'Driver spec error' is ON
                //--------------------
                if ((aistatus & (int)CaioConst.AIS_DRVERR) == (int)CaioConst.AIS_DRVERR){
                    text_string += ", Driver spec error";
                }
                text_string += ")";
                textBox_Status.Text = text_string;
                //----------------------------------------
                // Get the current sampling times
                //----------------------------------------
                ret1 = aio.GetAiSamplingCount(g_id, out aisamplingcount);
                //----------------------------------------
                // Error process
                //----------------------------------------
                if (ret1 != 0){
                    ret2 = aio.GetErrorString(ret1, out error_string);
                    //--------------------
                    // When failed to get the error string,
                    // initialize the error string
                    //--------------------
                    if (ret2 != 0){
                        error_string = "";
                    }
                    textBox_Return.Text = "Device Operation End Event Process : aio.GetAiSamplingCount = " + ret1.ToString() + " : " + error_string;
                    return;
                }
                //----------------------------------------
                // Get the number of channels
                //----------------------------------------
                ret1 = aio.GetAiChannels(g_id, out aichannels);
                //----------------------------------------
                // Error process
                //----------------------------------------
                if (ret1 != 0){
                    ret2 = aio.GetErrorString(ret1, out error_string);
                    //--------------------
                    // When failed to get the error string,
                    // initialize the error string
                    //--------------------
                    if (ret2 != 0){
                        error_string = "";
                    }
                    textBox_Return.Text = "Device Operation End Event Process : aio.GetAiChannels = " + ret1.ToString() + " : " + error_string;
                    return;
                }
                //----------------------------------------
                // Get sampling data
                //----------------------------------------
                //--------------------
                // Allocate an array for storing data
                //--------------------
                aidata = new float[aisamplingcount * aichannels];
                if (aidata == null){
                    textBox_Return.Text = "Device Operation End Event Process : Failed to allocate an array for storing data";
                    return;
                }
                ret1 = aio.GetAiSamplingDataEx(g_id, ref aisamplingcount, ref aidata);
                //----------------------------------------
                // Error process
                //----------------------------------------
                if (ret1 != 0){
                    ret2 = aio.GetErrorString(ret1, out error_string);
                    //--------------------
                    // When failed to get the error string,
                    // initialize the error string
                    //--------------------
                    if (ret2 != 0){
                        error_string = "";
                    }
                    textBox_Return.Text = "Device Operation End Event Process : aio.GetAiSamplingDataEx = " + ret1.ToString() + " : " + error_string;
                    aidata = null;
                    return;
                }
                g_sampling_count += (ulong)aisamplingcount;
                //----------------------------------------
                // Update the total sampling times
                //----------------------------------------
                textBox_SamplingCount.Text = g_sampling_count.ToString();
                //----------------------------------------
                // Get the current repeat times
                //----------------------------------------
                ret1 = aio.GetAiRepeatCount(g_id, out airepeatcount);
                //----------------------------------------
                // Error process
                //----------------------------------------
                if (ret1 != 0){
                    ret2 = aio.GetErrorString(ret1, out error_string);
                    //--------------------
                    // When failed to get the error string,
                    // initialize the error string
                    //--------------------
                    if (ret2 != 0){
                        error_string = "";
                    }
                    textBox_Return.Text = "Device Operation End Event Process : aio.GetAiRepeatCount = " + ret1.ToString() + " : " + error_string;
                    aidata = null;
                    return;
                }
                //----------------------------------------
                // Update the repeat times
                //----------------------------------------
                textBox_RepeatCount.Text = airepeatcount.ToString();
                //----------------------------------------
                // Store a string for displaying the sampling data
                //----------------------------------------
                text_string = "";
                for (i = 0; i < aisamplingcount; i++)
                {
                    text_string += String.Format("{0,5}:     ", i);
                    for (j = 0; j < aichannels; j++)
                    {
                        text_string += String.Format(aidata[i * aichannels + j].ToString("F5"));
                    }
                    text_string += "\r\n";
                }
                //----------------------------------------
                // Display the sampling data
                //----------------------------------------
                textBox_SamplingData.Text = text_string;
                //----------------------------------------
                // Display the message that event process is completed
                //----------------------------------------
                textBox_Return.Text = "Device Operation End Event Process : Successful completion";
                aidata = null;
            }
            base.WndProc(ref m);
        }
    }
}

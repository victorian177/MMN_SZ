using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;// SerialPort Settings (シリアルポート設定)

namespace ComSample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();


        }

        delegate void TextDelegate(TextBox tb,char r);

        private void UpdateText(TextBox tb, char r)
        {
            tb.Text += r;
        }

        //ポートオープン/クローズを行うボタン
        private void OpenButton_Click(object sender, EventArgs e)
        {
            //ボタンが押されたとき、処理中は連続に押されないように無効にする
            OpenButton.Enabled = false;
            
            try
            {
                if (serialPort1.IsOpen == true)//ポートがすでにオープンされているなら真、それ以外なら偽
                {
                    //すでにポートがオープンしている場合はクローズ処理を行う < Close the Port. >
                    serialPort1.Close();
                    //次回このボタンを押すときは　ポートオープンのため
                    //ボタンに対し　ポートオープンの表示を行う
                    OpenButton.Text = "Port Open";
                    //ポートクローズが正常に行えた事をテキストに表示する。
                    Text1.Text = "Port Close success.";
                }
                else
                {
                    //ポートのオープンを行う( Open the Port. )
                    serialPort1.PortName = ComboComPort1.SelectedItem.ToString();
                    serialPort1.Open();

                    //次回このボタンを押すときは　ポートクローズのため
                    //ボタンに対し　ポートクローズの表示を行う
                    OpenButton.Text = "Port Close";
                    //ポートオープンが正常に行えた事をテキストに表示する。
                    Text1.Text = "Port Open sucess.";
                }
            }
            catch (Exception ex)//例外処理
            {
                MessageBox.Show(ex.Message, "Error:Exception");
            }
            //処理が完了したため、ボタンを有効に戻す。
            OpenButton.Enabled = true;

        }

        //このサンプルがロードされたときの初期設定はここで行う
        private void Form1_Load(object sender, EventArgs e)
        {
            //ポート番号を割り振る(1から255まで)
            for (int cnt = 1; cnt < 256; cnt++)
            {
                ComboComPort1.Items.Add("COM" + cnt);
            }
            //初期設定時はCOM1を選択させておく。
            ComboComPort1.SelectedIndex = 0;

            Text1.Text = "Please select Port Number. After, push <Port Open> button.";

            //キーを押したら動作するハンドラを登録する
            //(キーを押したら送信できるように)
            this.KeyDown += new KeyEventHandler(Form1_KeyDown);
            
            //ボーレート設定(Setting Baudrate.) 
            serialPort1.BaudRate = 9600;
            //データビット設定(Setting Databits.) 
            serialPort1.DataBits = 8;
            //ストップビット設定(Setting Stopbits.)
            serialPort1.StopBits = StopBits.One;
            //パリティ設定(Setting Paritybits.)
            serialPort1.Parity = Parity.None;
            //RTS, DTRコントロール設定(Setting RTS/DTR Controls.)
            serialPort1.RtsEnable = true;
            serialPort1.DtrEnable = true;

            //ハンドシェーク設定(Setting HandShake)<Use RTS/CTS Handshake to set HalfDuplex.>
            //<半二重通信時には、ハンドシェークを設定する必要がある>
            //serialPort1.Handshake = Handshake.RequestToSend;
            
            serialPort1.ParityReplace = 63;
            //Null(00)を無視するかどうかの設定(Setting NullDiscard)
            //true ... 有効(Enable)  false ... 無効(Disable)
            serialPort1.DiscardNull = true;
            //受信トリガ<スレッショルド>の設定(Setting Receive Threshold) 
            serialPort1.ReceivedBytesThreshold = 16;
            //受信バッファサイズの設定
            serialPort1.ReadBufferSize = 8192;
            //送信バッファサイズの設定
            serialPort1.WriteBufferSize = 8192;

            //TODO:初期化設定を追加される場合はここから記述する


        }

        //キーを押したときに起動するメンバ
        void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (serialPort1.IsOpen == true)//すでにポートがオープンされている場合は、処理する。
            {
                //ほかの処理に使われないようにロックする
                lock (this)
                {
                    //押されたキーを送信する
                    switch (e.KeyData)
                    {
                        case Keys.D0:
                        case Keys.NumPad0:
                            serialPort1.Write("0");
                            break;
                        case Keys.D1:
                        case Keys.NumPad1:
                            serialPort1.Write("1");
                            break;
                        case Keys.D2:
                        case Keys.NumPad2:
                            serialPort1.Write("2");
                            break;
                        case Keys.D3:
                        case Keys.NumPad3:
                            serialPort1.Write("3");
                            break;
                        case Keys.D4:
                        case Keys.NumPad4:
                            serialPort1.Write("4");
                            break;
                        case Keys.D5:
                        case Keys.NumPad5:
                            serialPort1.Write("5");
                            break;
                        case Keys.D6:
                        case Keys.NumPad6:
                            serialPort1.Write("6");
                            break;
                        case Keys.D7:
                        case Keys.NumPad7:
                            serialPort1.Write("7");
                            break;
                        case Keys.D8:
                        case Keys.NumPad8:
                            serialPort1.Write("8");
                            break;
                        case Keys.D9:
                        case Keys.NumPad9:
                            serialPort1.Write("9");
                            break;
                        case Keys.Enter:
                            serialPort1.Write("\r\n");
                            break;
                        default:
                            serialPort1.Write(e.KeyData.ToString());
                            break;
                    }
                }
            }

//            throw new Exception("The method or operation is not implemented.");
        }

        //受信したとき起動するメンバ
        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
         char[] r_data = new char[serialPort1.ReceivedBytesThreshold+1];
         try
         {
             serialPort1.Read(r_data, 0, serialPort1.ReceivedBytesThreshold);
             for (int i = 0; i < serialPort1.ReceivedBytesThreshold; i++)
             {
                if (InvokeRequired)
                {
                    this.Invoke(new TextDelegate(UpdateText), new object[] { Text1, r_data[i] });
                }else{
                    Text1.Text += r_data[i];
                }
             }
         }
         catch (Exception ex)
         {
             MessageBox.Show(ex.Message, "Error:Exception");
         }
        }

        //ポートをクローズしてサンプルを終了する
        private void EndButton_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen == true)
            {
                serialPort1.Close();
            }
        }

        private void serialPort1_ErrorReceived(object sender, SerialErrorReceivedEventArgs e)
        {
           switch (e.EventType)
            {
               case SerialError.Frame:
               case SerialError.Overrun:
               case SerialError.RXOver:
               case SerialError.RXParity:
               case SerialError.TXFull:
//                   MessageBox.Show("Error", "Error");
                    break;
            }
        }

        private void serialPort1_PinChanged(object sender, SerialPinChangedEventArgs e)
        {
            switch (e.EventType)
            {
                case SerialPinChange.Break:
//                    MessageBox.Show("Break", "break");
                    break;
                case SerialPinChange.CtsChanged:
//                    MessageBox.Show("cts", "cts");
                    break;
                case SerialPinChange.DsrChanged:
 //                   MessageBox.Show("dsr", "dsr");
                    break;
            }
        }
       

    }
}
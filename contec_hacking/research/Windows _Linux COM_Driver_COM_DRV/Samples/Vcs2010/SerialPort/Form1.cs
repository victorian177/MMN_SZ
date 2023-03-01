using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;// SerialPort Settings (�V���A���|�[�g�ݒ�)

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

        //�|�[�g�I�[�v��/�N���[�Y���s���{�^��
        private void OpenButton_Click(object sender, EventArgs e)
        {
            //�{�^���������ꂽ�Ƃ��A�������͘A���ɉ�����Ȃ��悤�ɖ����ɂ���
            OpenButton.Enabled = false;
            
            try
            {
                if (serialPort1.IsOpen == true)//�|�[�g�����łɃI�[�v������Ă���Ȃ�^�A����ȊO�Ȃ�U
                {
                    //���łɃ|�[�g���I�[�v�����Ă���ꍇ�̓N���[�Y�������s�� < Close the Port. >
                    serialPort1.Close();
                    //���񂱂̃{�^���������Ƃ��́@�|�[�g�I�[�v���̂���
                    //�{�^���ɑ΂��@�|�[�g�I�[�v���̕\�����s��
                    OpenButton.Text = "Port Open";
                    //�|�[�g�N���[�Y������ɍs���������e�L�X�g�ɕ\������B
                    Text1.Text = "Port Close success.";
                }
                else
                {
                    //�|�[�g�̃I�[�v�����s��( Open the Port. )
                    serialPort1.PortName = ComboComPort1.SelectedItem.ToString();
                    serialPort1.Open();

                    //���񂱂̃{�^���������Ƃ��́@�|�[�g�N���[�Y�̂���
                    //�{�^���ɑ΂��@�|�[�g�N���[�Y�̕\�����s��
                    OpenButton.Text = "Port Close";
                    //�|�[�g�I�[�v��������ɍs���������e�L�X�g�ɕ\������B
                    Text1.Text = "Port Open sucess.";
                }
            }
            catch (Exception ex)//��O����
            {
                MessageBox.Show(ex.Message, "Error:Exception");
            }
            //�����������������߁A�{�^����L���ɖ߂��B
            OpenButton.Enabled = true;

        }

        //���̃T���v�������[�h���ꂽ�Ƃ��̏����ݒ�͂����ōs��
        private void Form1_Load(object sender, EventArgs e)
        {
            //�|�[�g�ԍ�������U��(1����255�܂�)
            for (int cnt = 1; cnt < 256; cnt++)
            {
                ComboComPort1.Items.Add("COM" + cnt);
            }
            //�����ݒ莞��COM1��I�������Ă����B
            ComboComPort1.SelectedIndex = 0;

            Text1.Text = "Please select Port Number. After, push <Port Open> button.";

            //�L�[���������瓮�삷��n���h����o�^����
            //(�L�[���������瑗�M�ł���悤��)
            this.KeyDown += new KeyEventHandler(Form1_KeyDown);
            
            //�{�[���[�g�ݒ�(Setting Baudrate.) 
            serialPort1.BaudRate = 9600;
            //�f�[�^�r�b�g�ݒ�(Setting Databits.) 
            serialPort1.DataBits = 8;
            //�X�g�b�v�r�b�g�ݒ�(Setting Stopbits.)
            serialPort1.StopBits = StopBits.One;
            //�p���e�B�ݒ�(Setting Paritybits.)
            serialPort1.Parity = Parity.None;
            //RTS, DTR�R���g���[���ݒ�(Setting RTS/DTR Controls.)
            serialPort1.RtsEnable = true;
            serialPort1.DtrEnable = true;

            //�n���h�V�F�[�N�ݒ�(Setting HandShake)<Use RTS/CTS Handshake to set HalfDuplex.>
            //<����d�ʐM���ɂ́A�n���h�V�F�[�N��ݒ肷��K�v������>
            //serialPort1.Handshake = Handshake.RequestToSend;
            
            serialPort1.ParityReplace = 63;
            //Null(00)�𖳎����邩�ǂ����̐ݒ�(Setting NullDiscard)
            //true ... �L��(Enable)  false ... ����(Disable)
            serialPort1.DiscardNull = true;
            //��M�g���K<�X���b�V�����h>�̐ݒ�(Setting Receive Threshold) 
            serialPort1.ReceivedBytesThreshold = 16;
            //��M�o�b�t�@�T�C�Y�̐ݒ�
            serialPort1.ReadBufferSize = 8192;
            //���M�o�b�t�@�T�C�Y�̐ݒ�
            serialPort1.WriteBufferSize = 8192;

            //TODO:�������ݒ��ǉ������ꍇ�͂�������L�q����


        }

        //�L�[���������Ƃ��ɋN�����郁���o
        void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (serialPort1.IsOpen == true)//���łɃ|�[�g���I�[�v������Ă���ꍇ�́A��������B
            {
                //�ق��̏����Ɏg���Ȃ��悤�Ƀ��b�N����
                lock (this)
                {
                    //�����ꂽ�L�[�𑗐M����
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

        //��M�����Ƃ��N�����郁���o
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

        //�|�[�g���N���[�Y���ăT���v�����I������
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
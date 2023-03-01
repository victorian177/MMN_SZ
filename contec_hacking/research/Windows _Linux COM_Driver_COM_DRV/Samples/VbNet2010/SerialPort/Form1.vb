Imports System.IO.Ports      'SerialPort Settings (�V���A���|�[�g�ݒ�)
Public Class Form1

    '�|�[�g�I�[�v��/�N���[�Y���s���{�^��
    Private Sub OpenButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenButton.Click
        '�{�^���������ꂽ�Ƃ��A�������͘A���ɉ�����Ȃ��悤�ɖ����ɂ���
        OpenButton.Enabled = False

        Try
            If SerialPort1.IsOpen = True Then '�|�[�g�����łɃI�[�v������Ă���Ȃ�^�A����ȊO�Ȃ�U
                '���łɃ|�[�g���I�[�v�����Ă���ꍇ�̓N���[�Y�������s�� < Close the Port. >
                SerialPort1.Close()
                '���񂱂̃{�^���������Ƃ��́@�|�[�g�I�[�v���̂���
                '�{�^���ɑ΂��@�|�[�g�I�[�v���̕\�����s��
                OpenButton.Text = "Port Open"
                '�|�[�g�N���[�Y������ɍs���������e�L�X�g�ɕ\������B
                Text1.Text = "Port Close success."
            Else
                '�|�[�g�̃I�[�v�����s��( Open the Port. )
                SerialPort1.PortName = ComboComPort1.SelectedItem.ToString()
                SerialPort1.Open()

                '���񂱂̃{�^���������Ƃ��́@�|�[�g�N���[�Y�̂���
                '�{�^���ɑ΂��@�|�[�g�N���[�Y�̕\�����s��
                OpenButton.Text = "Port Close"
                '�|�[�g�I�[�v��������ɍs���������e�L�X�g�ɕ\������B
                Text1.Text = "Port Open sucess."
            End If
        Catch ex As Exception               '��O����
            MsgBox(ex.Message, MsgBoxStyle.OkOnly, "Error:Exception")
        End Try

        '�����������������߁A�{�^����L���ɖ߂��B
        OpenButton.Enabled = True
    End Sub

    '���̃T���v�������[�h���ꂽ�Ƃ��̏����ݒ�͂����ōs��
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim cnt As Integer

        '�|�[�g�ԍ�������U��(1����255�܂�)
        For cnt = 1 To 255
            ComboComPort1.Items.Add("COM" + CStr(cnt))
        Next cnt
        '�����ݒ莞��COM1��I�������Ă����B
        ComboComPort1.SelectedIndex = 0

        Text1.Text = "Please select Port Number. After, push <Port Open> button."

        '�{�[���[�g�ݒ�(Setting Baudrate.) 
        SerialPort1.BaudRate = 9600
        '�f�[�^�r�b�g�ݒ�(Setting Databits.) 
        SerialPort1.DataBits = 8
        '�X�g�b�v�r�b�g�ݒ�(Setting Stopbits.)
        SerialPort1.StopBits = StopBits.One
        '�p���e�B�ݒ�(Setting Paritybits.)
        SerialPort1.Parity = Parity.None
        'RTS, DTR�R���g���[���ݒ�(Setting RTS/DTR Controls.)
        SerialPort1.RtsEnable = True
        SerialPort1.DtrEnable = True

        '�n���h�V�F�[�N�ݒ�(Setting HandShake)<Use RTS/CTS Handshake to set HalfDuplex.>
        '<����d�ʐM���ɂ́A�n���h�V�F�[�N��ݒ肷��K�v������>
        'serialPort1.Handshake = Handshake.RequestToSend

        SerialPort1.ParityReplace = 63
        'Null(00)�𖳎����邩�ǂ����̐ݒ�(Setting NullDiscard)
        'true ... �L��(Enable)  false ... ����(Disable)
        SerialPort1.DiscardNull = True
        '��M�g���K<�X���b�V�����h>�̐ݒ�(Setting Receive Threshold) 
        SerialPort1.ReceivedBytesThreshold = 16
        '��M�o�b�t�@�T�C�Y�̐ݒ�
        SerialPort1.ReadBufferSize = 8192
        '���M�o�b�t�@�T�C�Y�̐ݒ�
        SerialPort1.WriteBufferSize = 8192

    End Sub

    '�L�[���������Ƃ��ɋN�����郁���o
    Private Sub Form1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If SerialPort1.IsOpen = True Then '���łɃ|�[�g���I�[�v������Ă���ꍇ�́A��������B

            '�ق��̏����Ɏg���Ȃ��悤�Ƀ��b�N����
            SyncLock Me
                '�����ꂽ�L�[�𑗐M����
                Select Case e.KeyData
                    Case Keys.D0, Keys.NumPad0
                        SerialPort1.Write("0")
                    Case Keys.D1, Keys.NumPad1
                        SerialPort1.Write("1")
                    Case Keys.D2, Keys.NumPad2
                        SerialPort1.Write("2")
                    Case Keys.D3, Keys.NumPad3
                        SerialPort1.Write("3")
                    Case Keys.D4, Keys.NumPad4
                        SerialPort1.Write("4")
                    Case Keys.D5, Keys.NumPad5
                        SerialPort1.Write("5")
                    Case Keys.D6, Keys.NumPad6
                        SerialPort1.Write("6")
                    Case Keys.D7, Keys.NumPad7
                        SerialPort1.Write("7")
                    Case Keys.D8, Keys.NumPad8
                        SerialPort1.Write("8")
                    Case Keys.D9, Keys.NumPad9
                        SerialPort1.Write("9")
                    Case Keys.Enter
                        SerialPort1.Write(vbCrLf)
                    Case Else
                        SerialPort1.Write(e.KeyData.ToString())

                End Select

            End SyncLock
        End If

    End Sub

    '// �ԐړI��Text1��ύX���邽�� �f���Q�[�g��p�ӂ���   //
    Public Delegate Sub addString(ByVal ch As Char)

    Public Sub addStrText1(ByVal ch As Char)
        Text1.Text += ch
    End Sub
    '//////////////////////////////////////////////////////

    '��M�����Ƃ��N�����郁���o
    Private Sub SerialPort1_DataReceived(ByVal sender As System.Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles SerialPort1.DataReceived
        Dim r_data(SerialPort1.ReceivedBytesThreshold + 1) As Char
        Dim i As Integer

        Try
            '�ق��̏����Ɏg���Ȃ��悤�Ƀ��b�N����
            SyncLock Me
                SerialPort1.Read(r_data, 0, SerialPort1.ReceivedBytesThreshold)

                For i = 0 To SerialPort1.ReceivedBytesThreshold - 1
                    Invoke(New addString(AddressOf addStrText1), r_data(i))
                Next i
            End SyncLock
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.OkOnly, "Error:Exception")
        End Try

    End Sub

    '�|�[�g���N���[�Y���ăT���v�����I������
    Private Sub EndButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EndButton.Click
        If SerialPort1.IsOpen = True Then
            SerialPort1.Close()
        End If
    End Sub

    Private Sub SerialPort1_ErrorReceived(ByVal sender As System.Object, ByVal e As System.IO.Ports.SerialErrorReceivedEventArgs) Handles SerialPort1.ErrorReceived
        Select Case e.EventType
            Case SerialError.Frame
            Case SerialError.Overrun
            Case SerialError.RXOver
            Case SerialError.RXParity
            Case SerialError.TXFull
        End Select
    End Sub

    Private Sub SerialPort1_PinChanged(ByVal sender As System.Object, ByVal e As System.IO.Ports.SerialPinChangedEventArgs) Handles SerialPort1.PinChanged
        Select Case e.EventType
            Case SerialPinChange.Break
            Case SerialPinChange.CtsChanged
            Case SerialPinChange.DsrChanged
        End Select
    End Sub
End Class

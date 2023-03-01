Imports System.IO.Ports      'SerialPort Settings (シリアルポート設定)
Public Class Form1

    'ポートオープン/クローズを行うボタン
    Private Sub OpenButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenButton.Click
        'ボタンが押されたとき、処理中は連続に押されないように無効にする
        OpenButton.Enabled = False

        Try
            If SerialPort1.IsOpen = True Then 'ポートがすでにオープンされているなら真、それ以外なら偽
                'すでにポートがオープンしている場合はクローズ処理を行う < Close the Port. >
                SerialPort1.Close()
                '次回このボタンを押すときは　ポートオープンのため
                'ボタンに対し　ポートオープンの表示を行う
                OpenButton.Text = "Port Open"
                'ポートクローズが正常に行えた事をテキストに表示する。
                Text1.Text = "Port Close success."
            Else
                'ポートのオープンを行う( Open the Port. )
                SerialPort1.PortName = ComboComPort1.SelectedItem.ToString()
                SerialPort1.Open()

                '次回このボタンを押すときは　ポートクローズのため
                'ボタンに対し　ポートクローズの表示を行う
                OpenButton.Text = "Port Close"
                'ポートオープンが正常に行えた事をテキストに表示する。
                Text1.Text = "Port Open sucess."
            End If
        Catch ex As Exception               '例外処理
            MsgBox(ex.Message, MsgBoxStyle.OkOnly, "Error:Exception")
        End Try

        '処理が完了したため、ボタンを有効に戻す。
        OpenButton.Enabled = True
    End Sub

    'このサンプルがロードされたときの初期設定はここで行う
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim cnt As Integer

        'ポート番号を割り振る(1から255まで)
        For cnt = 1 To 255
            ComboComPort1.Items.Add("COM" + CStr(cnt))
        Next cnt
        '初期設定時はCOM1を選択させておく。
        ComboComPort1.SelectedIndex = 0

        Text1.Text = "Please select Port Number. After, push <Port Open> button."

        'ボーレート設定(Setting Baudrate.) 
        SerialPort1.BaudRate = 9600
        'データビット設定(Setting Databits.) 
        SerialPort1.DataBits = 8
        'ストップビット設定(Setting Stopbits.)
        SerialPort1.StopBits = StopBits.One
        'パリティ設定(Setting Paritybits.)
        SerialPort1.Parity = Parity.None
        'RTS, DTRコントロール設定(Setting RTS/DTR Controls.)
        SerialPort1.RtsEnable = True
        SerialPort1.DtrEnable = True

        'ハンドシェーク設定(Setting HandShake)<Use RTS/CTS Handshake to set HalfDuplex.>
        '<半二重通信時には、ハンドシェークを設定する必要がある>
        'serialPort1.Handshake = Handshake.RequestToSend

        SerialPort1.ParityReplace = 63
        'Null(00)を無視するかどうかの設定(Setting NullDiscard)
        'true ... 有効(Enable)  false ... 無効(Disable)
        SerialPort1.DiscardNull = True
        '受信トリガ<スレッショルド>の設定(Setting Receive Threshold) 
        SerialPort1.ReceivedBytesThreshold = 16
        '受信バッファサイズの設定
        SerialPort1.ReadBufferSize = 8192
        '送信バッファサイズの設定
        SerialPort1.WriteBufferSize = 8192

    End Sub

    'キーを押したときに起動するメンバ
    Private Sub Form1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If SerialPort1.IsOpen = True Then 'すでにポートがオープンされている場合は、処理する。

            'ほかの処理に使われないようにロックする
            SyncLock Me
                '押されたキーを送信する
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

    '// 間接的にText1を変更するため デリゲートを用意する   //
    Public Delegate Sub addString(ByVal ch As Char)

    Public Sub addStrText1(ByVal ch As Char)
        Text1.Text += ch
    End Sub
    '//////////////////////////////////////////////////////

    '受信したとき起動するメンバ
    Private Sub SerialPort1_DataReceived(ByVal sender As System.Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles SerialPort1.DataReceived
        Dim r_data(SerialPort1.ReceivedBytesThreshold + 1) As Char
        Dim i As Integer

        Try
            'ほかの処理に使われないようにロックする
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

    'ポートをクローズしてサンプルを終了する
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

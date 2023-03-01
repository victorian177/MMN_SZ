Imports System.Text

Public Class AiRepeat
    '----------------------------------------
    ' グローバル変数の宣言
    '----------------------------------------
    Dim g_id As Short
    Dim g_sampling_count As UInteger


    Private Sub AiRepeat_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '----------------------------------------
        ' デバイス名の初期表示を更新
        '----------------------------------------
        TextBox_DeviceName.Text = "AIO000"
    End Sub

    '================================================================================
    ' デバイス初期化ボタンをクリックした際の処理になります
    ' デバイスの初期化処理を行います
    '================================================================================
    Private Sub Button_Init_Click(sender As Object, e As EventArgs) Handles Button_Init.Click
        Dim ret1 As Integer                             ' 戻り値取得用1
        Dim ret2 As Integer                             ' 戻り値取得用2
        Dim error_string As New StringBuilder("", 256)  ' エラーコード文字列
        Dim devicename As String                        ' デバイス名

        '----------------------------------------
        ' デバイスを初期化
        '----------------------------------------
        '--------------------
        ' デバイス名をテキストボックスから取得
        '--------------------
        devicename = TextBox_DeviceName.Text
        '--------------------
        ' デバイス初期化
        ' 変更注意関数(変更するとアプリが動作しなくなる可能性があります)
        '--------------------
        ret1 = AioInit(devicename, g_id)
        '----------------------------------------
        ' エラー処理
        '----------------------------------------
        If (ret1 <> 0) Then
            ret2 = AioGetErrorString(ret1, error_string)
            '--------------------
            ' エラー文字列取得に失敗した場合
            ' エラー文字列を初期化
            '--------------------
            If (ret2 <> 0) Then
                error_string.Clear()
            End If
            TextBox_Return.Text = "初期化処理：AioInit = " & ret1 & ":" & error_string.ToString()
            Exit Sub
        End If
        '----------------------------------------
        ' デバイスをリセット
        '----------------------------------------
        ret1 = AioResetDevice(g_id)
        '----------------------------------------
        ' エラー処理
        '----------------------------------------
        If (ret1 <> 0) Then
            ret2 = AioGetErrorString(ret1, error_string)
            '--------------------
            ' エラー文字列取得に失敗した場合
            ' エラー文字列を初期化
            '--------------------
            If (ret2 <> 0) Then
                error_string.Clear()
            End If
            TextBox_Return.Text = "初期化処理：AioResetDevice = " & ret1 & ":" & error_string.ToString()
            Exit Sub
        End If
        '----------------------------------------
        ' 入力方式をシングルエンドに設定
        '----------------------------------------
        ret1 = AioSetAiInputMethod(g_id, 0)
        '----------------------------------------
        ' エラー処理
        '----------------------------------------
        If (ret1 <> 0) Then
            ret2 = AioGetErrorString(ret1, error_string)
            '--------------------
            ' エラー文字列取得に失敗した場合
            ' エラー文字列を初期化
            '--------------------
            If (ret2 <> 0) Then
                error_string.Clear()
            End If
            TextBox_Return.Text = "初期化処理：AioSetAiInputMethod = " & ret1 & ":" & error_string.ToString()
            Exit Sub
        End If
        '----------------------------------------
        ' チャネル数を1に設定
        '----------------------------------------
        ret1 = AioSetAiChannels(g_id, 1)
        '----------------------------------------
        ' エラー処理
        '----------------------------------------
        If (ret1 <> 0) Then
            ret2 = AioGetErrorString(ret1, error_string)
            '--------------------
            ' エラー文字列取得に失敗した場合
            ' エラー文字列を初期化
            '--------------------
            If (ret2 <> 0) Then
                error_string.Clear()
            End If
            TextBox_Return.Text = "初期化処理：AioSetAiChannels = " & ret1 & ":" & error_string.ToString()
            Exit Sub
        End If
        '----------------------------------------
        ' レンジを±10Vに設定
        '----------------------------------------
        ret1 = AioSetAiRange(g_id, 0, PM10)
        '----------------------------------------
        ' エラー処理
        '----------------------------------------
        If (ret1 <> 0) Then
            ret2 = AioGetErrorString(ret1, error_string)
            '--------------------
            ' エラー文字列取得に失敗した場合
            ' エラー文字列を初期化
            '--------------------
            If (ret2 <> 0) Then
                error_string.Clear()
            End If
            TextBox_Return.Text = "初期化処理：AioSetAiRange = " & ret1 & ":" & error_string.ToString()
            Exit Sub
        End If
        '----------------------------------------
        ' メモリタイプをFIFOに設定
        '----------------------------------------
        ret1 = AioSetAiMemoryType(g_id, 0)
        '----------------------------------------
        ' エラー処理
        '----------------------------------------
        If (ret1 <> 0) Then
            ret2 = AioGetErrorString(ret1, error_string)
            '--------------------
            ' エラー文字列取得に失敗した場合
            ' エラー文字列を初期化
            '--------------------
            If (ret2 <> 0) Then
                error_string.Clear()
            End If
            TextBox_Return.Text = "初期化処理：AioSetAiMemoryType = " & ret1 & ":" & error_string.ToString()
            Exit Sub
        End If
        '----------------------------------------
        ' クロックタイプを内部クロックに設定
        '----------------------------------------
        ret1 = AioSetAiClockType(g_id, 0)
        '----------------------------------------
        ' エラー処理
        '----------------------------------------
        If (ret1 <> 0) Then
            ret2 = AioGetErrorString(ret1, error_string)
            '--------------------
            ' エラー文字列取得に失敗した場合
            ' エラー文字列を初期化
            '--------------------
            If (ret2 <> 0) Then
                error_string.Clear()
            End If
            TextBox_Return.Text = "初期化処理：AioSetAiClockType = " & ret1 & ":" & error_string.ToString()
            Exit Sub
        End If
        '----------------------------------------
        ' サンプリングクロックを1msecに設定
        '----------------------------------------
        ret1 = AioSetAiSamplingClock(g_id, 1000)
        '----------------------------------------
        ' エラー処理
        '----------------------------------------
        If (ret1 <> 0) Then
            ret2 = AioGetErrorString(ret1, error_string)
            '--------------------
            ' エラー文字列取得に失敗した場合
            ' エラー文字列を初期化
            '--------------------
            If (ret2 <> 0) Then
                error_string.Clear()
            End If
            TextBox_Return.Text = "初期化処理：AioSetAiSamplingClock = " & ret1 & ":" & error_string.ToString()
            Exit Sub
        End If
        '----------------------------------------
        ' 開始条件を外部トリガ立ち上がりに設定
        '----------------------------------------
        ret1 = AioSetAiStartTrigger(g_id, 1)
        '----------------------------------------
        ' エラー処理
        '----------------------------------------
        If (ret1 <> 0) Then
            ret2 = AioGetErrorString(ret1, error_string)
            '--------------------
            ' エラー文字列取得に失敗した場合
            ' エラー文字列を初期化
            '--------------------
            If (ret2 <> 0) Then
                error_string.Clear()
            End If
            TextBox_Return.Text = "初期化処理：AioSetAiStartTrigger = " & ret1 & ":" & error_string.ToString()
            Exit Sub
        End If
        '----------------------------------------
        ' 停止条件を指定回数に設定
        '----------------------------------------
        ret1 = AioSetAiStopTrigger(g_id, 0)
        '----------------------------------------
        ' エラー処理
        '----------------------------------------
        If (ret1 <> 0) Then
            ret2 = AioGetErrorString(ret1, error_string)
            '--------------------
            ' エラー文字列取得に失敗した場合
            ' エラー文字列を初期化
            '--------------------
            If (ret2 <> 0) Then
                error_string.Clear()
            End If
            TextBox_Return.Text = "初期化処理：AioSetAiStopTrigger = " & ret1 & ":" & error_string.ToString()
            Exit Sub
        End If
        '----------------------------------------
        ' サンプリング停止回数を1000回に設定
        '----------------------------------------
        ret1 = AioSetAiStopTimes(g_id, 1000)
        '----------------------------------------
        ' エラー処理
        '----------------------------------------
        If (ret1 <> 0) Then
            ret2 = AioGetErrorString(ret1, error_string)
            '--------------------
            ' エラー文字列取得に失敗した場合
            ' エラー文字列を初期化
            '--------------------
            If (ret2 <> 0) Then
                error_string.Clear()
            End If
            TextBox_Return.Text = "初期化処理：AioSetAiStopTimes = " & ret1 & ":" & error_string.ToString()
            Exit Sub
        End If
        '----------------------------------------
        ' イベントにサンプリング開始、リピート終了、動作終了を設定
        ' 変更注意関数(変更するとアプリが動作しなくなる可能性があります)
        '----------------------------------------
        ret1 = AioSetAiEvent(g_id, Handle.ToInt32, (AIE_START Or AIE_RPTEND Or AIE_END))
        '----------------------------------------
        ' エラー処理
        '----------------------------------------
        If (ret1 <> 0) Then
            ret2 = AioGetErrorString(ret1, error_string)
            '--------------------
            ' エラー文字列取得に失敗した場合
            ' エラー文字列を初期化
            '--------------------
            If (ret2 <> 0) Then
                error_string.Clear()
            End If
            TextBox_Return.Text = "初期化処理：AioSetAiEvent = " & ret1 & ":" & error_string.ToString()
            Exit Sub
        End If
        '----------------------------------------
        ' 初期化処理完了のメッセ―ジ表示
        '----------------------------------------
        TextBox_Return.Text = "初期化処理：正常終了"
    End Sub

    '================================================================================
    ' リピート回数設定ボタンをクリックした際の処理になります
    ' リピート回数の設定を行います
    '================================================================================
    Private Sub Button_Repeat_Click(sender As Object, e As EventArgs) Handles Button_Repeat.Click
        Dim ret1 As Integer                             ' 戻り値取得用1
        Dim ret2 As Integer                             ' 戻り値取得用2
        Dim repeat_times As Integer                     ' リピート回数
        Dim error_string As New StringBuilder("", 256)  ' エラーコード文字列

        '----------------------------------------
        ' GUIの情報を更新
        '----------------------------------------
        Me.Refresh()
        '----------------------------------------
        ' リピート回数を設定
        '----------------------------------------
        Try
            repeat_times = Val(TextBox_RepeatTimes.Text)
        Catch ex As Exception
            repeat_times = 0
        End Try
        ret1 = AioSetAiRepeatTimes(g_id, repeat_times)
        '----------------------------------------
        ' エラー処理
        '----------------------------------------
        If (ret1 <> 0) Then
            ret2 = AioGetErrorString(ret1, error_string)
            '--------------------
            ' エラー文字列取得に失敗した場合
            ' エラー文字列を初期化
            '--------------------
            If (ret2 <> 0) Then
                error_string.Clear()
            End If
            TextBox_Return.Text = "リピート回数設定：AioSetAiRepeatTimes = " & ret1 & ":" & error_string.ToString()
            Exit Sub
        End If
        '----------------------------------------
        ' リピート回数設定完了のメッセ―ジ表示
        '----------------------------------------
        TextBox_Return.Text = "リピート回数設定：正常終了"
    End Sub

    '================================================================================
    ' サンプリング開始ボタンをクリックした際の処理になります
    ' メモリとステータスのクリアを行った後、サンプリング開始を行います
    '================================================================================
    Private Sub Button_Start_Click(sender As Object, e As EventArgs) Handles Button_Start.Click
        Dim ret1 As Integer                             ' 戻り値取得用1
        Dim ret2 As Integer                             ' 戻り値取得用2
        Dim error_string As New StringBuilder("", 256)  ' エラーコード文字列
        Dim text_string As String                       ' テキストボックス更新用
        Dim aistatus As Integer                         ' アナログ入力ステータス
        Dim airepeatcount As Integer                    ' アナログ入力リピート回数

        '----------------------------------------
        ' メモリクリア
        '----------------------------------------
        ret1 = AioResetAiMemory(g_id)
        '----------------------------------------
        ' エラー処理
        '----------------------------------------
        If (ret1 <> 0) Then
            ret2 = AioGetErrorString(ret1, error_string)
            '--------------------
            ' エラー文字列取得に失敗した場合
            ' エラー文字列を初期化
            '--------------------
            If (ret2 <> 0) Then
                error_string.Clear()
            End If
            TextBox_Return.Text = "サンプリング開始：AioResetAiMemory = " & ret1 & ":" & error_string.ToString()
            Exit Sub
        End If
        '----------------------------------------
        ' ステータスクリア
        '----------------------------------------
        ret1 = AioResetAiStatus(g_id)
        '----------------------------------------
        ' エラー処理
        '----------------------------------------
        If (ret1 <> 0) Then
            ret2 = AioGetErrorString(ret1, error_string)
            '--------------------
            ' エラー文字列取得に失敗した場合
            ' エラー文字列を初期化
            '--------------------
            If (ret2 <> 0) Then
                error_string.Clear()
            End If
            TextBox_Return.Text = "サンプリング開始：AioResetAiStatus = " & ret1 & ":" & error_string.ToString()
            Exit Sub
        End If
        g_sampling_count = 0
        '----------------------------------------
        ' サンプリング開始
        '----------------------------------------
        ret1 = AioStartAi(g_id)
        '----------------------------------------
        ' エラー処理
        '----------------------------------------
        If (ret1 <> 0) Then
            ret2 = AioGetErrorString(ret1, error_string)
            '--------------------
            ' エラー文字列取得に失敗した場合
            ' エラー文字列を初期化
            '--------------------
            If (ret2 <> 0) Then
                error_string.Clear()
            End If
            TextBox_Return.Text = "サンプリング開始：AioStartAi = " & ret1 & ":" & error_string.ToString()
            Exit Sub
        End If
        '----------------------------------------
        ' ステータスを取得
        '----------------------------------------
        ret1 = AioGetAiStatus(g_id, aistatus)
        '----------------------------------------
        ' エラー処理
        '----------------------------------------
        If (ret1 <> 0) Then
            ret2 = AioGetErrorString(ret1, error_string)
            '--------------------
            ' エラー文字列取得に失敗した場合
            ' エラー文字列を初期化
            '--------------------
            If (ret2 <> 0) Then
                error_string.Clear()
            End If
            TextBox_Return.Text = "サンプリング開始：AioGetAiStatus = " & ret1 & ":" & error_string.ToString()
            Exit Sub
        End If
        '----------------------------------------
        ' ステータスの表示
        '----------------------------------------
        text_string = String.Format("{0:X8}H (", aistatus)
        '--------------------
        ' 動作中ステータス有効時
        '--------------------
        If (aistatus And AIS_BUSY) = AIS_BUSY Then
            text_string += "動作中"
        '--------------------
        ' 動作中ステータス無効時
        '--------------------
        Else
            text_string += "停止中"
        End If
        '--------------------
        ' 開始トリガ待ちステータス有効時
        '--------------------
        If (aistatus And AIS_START_TRG) = AIS_START_TRG Then
            text_string += ", 開始トリガ待ち"
        End If
        '--------------------
        ' 指定サンプリング回数格納ステータス有効時
        '--------------------
        If (aistatus And AIS_DATA_NUM) = AIS_DATA_NUM Then
            text_string += ", 指定回数格納"
        End If
        '--------------------
        ' オーバーフローステータス有効時
        '--------------------
        If (aistatus And AIS_OFERR) = AIS_OFERR Then
            text_string += ", オーバーフロー"
        End If
        '--------------------
        ' サンプリングクロックエラーステータス有効時
        '--------------------
        If (aistatus And AIS_SCERR) = AIS_SCERR Then
            text_string += ", サンプリングクロックエラー"
        End If
        '--------------------
        ' AD変換エラーステータス有効時
        '--------------------
        If (aistatus And AIS_ADERR) = AIS_ADERR Then
            text_string += ", AD変換エラー"
        End If
        '--------------------
        ' ドライバスペックエラーステータス有効時
        '--------------------
        If (aistatus And AIS_DRVERR) = AIS_DRVERR Then
            text_string += ", ドライバスペックエラー"
        End If
        text_string += ")"
        TextBox_Status.Text = text_string
        '----------------------------------------
        ' 総サンプリング回数を更新
        '----------------------------------------
        TextBox_SamplingCount.Text = g_sampling_count.ToString()
        '----------------------------------------
        ' 現在のリピート回数を取得
        '----------------------------------------
        ret1 = AioGetAiRepeatCount(g_id, airepeatcount)
        '----------------------------------------
        ' エラー処理
        '----------------------------------------
        If (ret1 <> 0) Then
            ret2 = AioGetErrorString(ret1, error_string)
            '--------------------
            ' エラー文字列取得に失敗した場合
            ' エラー文字列を初期化
            '--------------------
            If (ret2 <> 0) Then
                error_string.Clear()
            End If
            TextBox_Return.Text = "サンプリング開始：AioGetAiRepeatCount = " & ret1 & ":" & error_string.ToString()
            Exit Sub
        End If
        '----------------------------------------
        ' リピート回数を更新
        '----------------------------------------
        TextBox_RepeatCount.Text = airepeatcount.ToString()
        '----------------------------------------
        ' サンプリング開始完了のメッセ―ジ表示
        '----------------------------------------
        TextBox_Return.Text = "サンプリング開始：正常終了"
    End Sub

    '================================================================================
    ' サンプリング停止ボタンをクリックした際の処理になります
    ' サンプリング停止を行います
    '================================================================================
    Private Sub Button_Stop_Click(sender As Object, e As EventArgs) Handles Button_Stop.Click
        Dim ret1 As Integer                             ' 戻り値取得用1
        Dim ret2 As Integer                             ' 戻り値取得用2
        Dim error_string As New StringBuilder("", 256)  ' エラーコード文字列

        '----------------------------------------
        ' サンプリング停止
        '----------------------------------------
        ret1 = AioStopAi(g_id)
        '----------------------------------------
        ' エラー処理
        '----------------------------------------
        If (ret1 <> 0) Then
            ret2 = AioGetErrorString(ret1, error_string)
            '--------------------
            ' エラー文字列取得に失敗した場合
            ' エラー文字列を初期化
            '--------------------
            If (ret2 <> 0) Then
                error_string.Clear()
            End If
            TextBox_Return.Text = "サンプリング停止：AioStopAi = " & ret1 & ":" & error_string.ToString()
            Exit Sub
        End If
        '----------------------------------------
        ' サンプリング停止完了のメッセ―ジ表示
        '----------------------------------------
        TextBox_Return.Text = "サンプリング停止：正常終了"
    End Sub

    '================================================================================
    ' デバイス終了処理ボタンをクリックした際の処理になります
    ' デバイスの終了処理を行います
    '================================================================================
    Private Sub Button_Exit_Click(sender As Object, e As EventArgs) Handles Button_Exit.Click
        Dim ret1 As Integer                             ' 戻り値取得用1
        Dim ret2 As Integer                             ' 戻り値取得用2
        Dim error_string As New StringBuilder("", 256)  ' エラーコード文字列

        '----------------------------------------
        ' デバイスの終了処理
        '----------------------------------------
        ret1 = AioExit(g_id)
        '----------------------------------------
        ' エラー処理
        '----------------------------------------
        If (ret1 <> 0) Then
            ret2 = AioGetErrorString(ret1, error_string)
            '--------------------
            ' エラー文字列取得に失敗した場合
            ' エラー文字列を初期化
            '--------------------
            If (ret2 <> 0) Then
                error_string.Clear()
            End If
            TextBox_Return.Text = "デバイス終了処理：AioExit = " & ret1 & ":" & error_string.ToString()
            Exit Sub
        End If
        '----------------------------------------
        ' デバイス終了処理完了のメッセ―ジ表示
        '----------------------------------------
        TextBox_Return.Text = "デバイス終了処理：正常終了"
    End Sub

    '================================================================================
    ' 閉じるボタンを押した際の処理になります
    ' アプリの終了処理を行います
    '================================================================================
    Private Sub Button_Close_Click(sender As Object, e As EventArgs) Handles Button_Close.Click
        '----------------------------------------
        ' ダイアログを終了する
        '----------------------------------------
        End
    End Sub

    '================================================================================
    ' イベントが発生した時の動作
    ' 各イベントが発生したとき、イベント毎に処理を行う
    '================================================================================
    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        Dim ret1 As Integer                             ' 戻り値取得用1
        Dim ret2 As Integer                             ' 戻り値取得用2
        Dim error_string As New StringBuilder("", 256)  ' エラーコード文字列
        Dim text_string As String                       ' テキストボックス更新用
        Dim aisamplingcount As Integer                  ' サンプリングカウント
        Dim aidata() As Single                          ' アナログデータ
        Dim aichannels As Short                         ' チャネル数
        Dim aistatus As Integer                         ' ステータス
        Dim airepeatcount As Integer                    ' リピート回数
        Dim i As Integer
        Dim j As Integer

        '----------------------------------------
        ' AD変換開始条件成立イベント
        ' データの取得、表示を行う
        '----------------------------------------
        If m.Msg = AIOM_AIE_START Then
            '----------------------------------------
            ' ステータスを取得
            '----------------------------------------
            ret1 = AioGetAiStatus(g_id, aistatus)
            '----------------------------------------
            ' エラー処理
            '----------------------------------------
            If (ret1 <> 0) Then
                ret2 = AioGetErrorString(ret1, error_string)
                '--------------------
                ' エラー文字列取得に失敗した場合
                ' エラー文字列を初期化
                '--------------------
                If (ret2 <> 0) Then
                    error_string.Clear()
                End If
                TextBox_Return.Text = "AD変換開始条件成立処理：AioGetAiStatus = " & ret1 & " : " & error_string.ToString()
                Exit Sub
            End If
            '----------------------------------------
            ' ステータスの表示
            '----------------------------------------
            text_string = String.Format("{0:X8}H (", aistatus)
            '--------------------
            ' 動作中ステータス有効時
            '--------------------
            If (aistatus And AIS_BUSY) = AIS_BUSY Then
                text_string += "動作中"
            '--------------------
            ' 動作中ステータス無効時
            '--------------------
            Else
                text_string += "停止中"
            End If
            '--------------------
            ' 開始トリガ待ちステータス有効時
            '--------------------
            If (aistatus And AIS_START_TRG) = AIS_START_TRG Then
                text_string += ", 開始トリガ待ち"
            End If
            '--------------------
            ' 指定サンプリング回数格納ステータス有効時
            '--------------------
            If (aistatus And AIS_DATA_NUM) = AIS_DATA_NUM Then
                text_string += ", 指定回数格納"
            End If
            '--------------------
            ' オーバーフローステータス有効時
            '--------------------
            If (aistatus And AIS_OFERR) = AIS_OFERR Then
                text_string += ", オーバーフロー"
            End If
            '--------------------
            ' サンプリングクロックエラーステータス有効時
            '--------------------
            If (aistatus And AIS_SCERR) = AIS_SCERR Then
                text_string += ", サンプリングクロックエラー"
            End If
            '--------------------
            ' AD変換エラーステータス有効時
            '--------------------
            If (aistatus And AIS_ADERR) = AIS_ADERR Then
                text_string += ", AD変換エラー"
            End If
            '--------------------
            ' ドライバスペックエラーステータス有効時
            '--------------------
            If (aistatus And AIS_DRVERR) = AIS_DRVERR Then
                text_string += ", ドライバスペックエラー"
            End If
            text_string += ")"
            TextBox_Status.Text = text_string
            '----------------------------------------
            ' イベント処理完了のメッセ―ジ表示
            '----------------------------------------
            TextBox_Return.Text = "AD変換開始条件成立処理：正常終了"
        End If
        '----------------------------------------
        ' リピート終了イベント
        ' データの取得、表示を行う
        '----------------------------------------
        If m.Msg = AIOM_AIE_RPTEND Then
            '----------------------------------------
            ' ステータスを取得
            '----------------------------------------
            ret1 = AioGetAiStatus(g_id, aistatus)
            '----------------------------------------
            ' エラー処理
            '----------------------------------------
            If (ret1 <> 0) Then
                ret2 = AioGetErrorString(ret1, error_string)
                '--------------------
                ' エラー文字列取得に失敗した場合
                ' エラー文字列を初期化
                '--------------------
                If (ret2 <> 0) Then
                    error_string.Clear()
                End If
                TextBox_Return.Text = "リピート終了イベント処理：AioGetAiStatus = " & ret1 & " : " & error_string.ToString()
                Exit Sub
            End If
            '----------------------------------------
            ' ステータスの表示
            '----------------------------------------
            text_string = String.Format("{0:X8}H (", aistatus)
            '--------------------
            ' 動作中ステータス有効時
            '--------------------
            If (aistatus And AIS_BUSY) = AIS_BUSY Then
                text_string += "動作中"
            '--------------------
            ' 動作中ステータス無効時
            '--------------------
            Else
                text_string += "停止中"
            End If
            '--------------------
            ' 開始トリガ待ちステータス有効時
            '--------------------
            If (aistatus And AIS_START_TRG) = AIS_START_TRG Then
                text_string += ", 開始トリガ待ち"
            End If
            '--------------------
            ' 指定サンプリング回数格納ステータス有効時
            '--------------------
            If (aistatus And AIS_DATA_NUM) = AIS_DATA_NUM Then
                text_string += ", 指定回数格納"
            End If
            '--------------------
            ' オーバーフローステータス有効時
            '--------------------
            If (aistatus And AIS_OFERR) = AIS_OFERR Then
                text_string += ", オーバーフロー"
            End If
            '--------------------
            ' サンプリングクロックエラーステータス有効時
            '--------------------
            If (aistatus And AIS_SCERR) = AIS_SCERR Then
                text_string += ", サンプリングクロックエラー"
            End If
            '--------------------
            ' AD変換エラーステータス有効時
            '--------------------
            If (aistatus And AIS_ADERR) = AIS_ADERR Then
                text_string += ", AD変換エラー"
            End If
            '--------------------
            ' ドライバスペックエラーステータス有効時
            '--------------------
            If (aistatus And AIS_DRVERR) = AIS_DRVERR Then
                text_string += ", ドライバスペックエラー"
            End If
            text_string += ")"
            TextBox_Status.Text = text_string
            '----------------------------------------
            ' 現在のサンプリング回数を取得
            '----------------------------------------
            ret1 = AioGetAiSamplingCount(g_id, aisamplingcount)
            '----------------------------------------
            ' エラー処理
            '----------------------------------------
            If (ret1 <> 0) Then
                ret2 = AioGetErrorString(ret1, error_string)
                '--------------------
                ' エラー文字列取得に失敗した場合
                ' エラー文字列を初期化
                '--------------------
                If (ret2 <> 0) Then
                    error_string.Clear()
                End If
                TextBox_Return.Text = "リピート終了イベント処理：AioGetAiSamplingCount = " & ret1 & " : " & error_string.ToString()
                Exit Sub
            End If
            '----------------------------------------
            ' チャネル数取得
            '----------------------------------------
            ret1 = AioGetAiChannels(g_id, aichannels)
            '----------------------------------------
            ' エラー処理
            '----------------------------------------
            If (ret1 <> 0) Then
                ret2 = AioGetErrorString(ret1, error_string)
                '--------------------
                ' エラー文字列取得に失敗した場合
                ' エラー文字列を初期化
                '--------------------
                If (ret2 <> 0) Then
                    error_string.Clear()
                End If
                TextBox_Return.Text = "リピート終了イベント処理：AioGetAiChannels = " & ret1 & " : " & error_string.ToString()
                Exit Sub
            End If
            '----------------------------------------
            ' サンプリングデータを取得
            '----------------------------------------
            '--------------------
            ' データ格納用の配列を確保
            '--------------------
            ReDim aidata(aisamplingcount * aichannels)
            If IsArray(aidata) = 0 Then
                TextBox_Return.Text = "リピート終了イベント処理：データ格納用の配列確保に失敗"
                Exit Sub
            End If
            ret1 = AioGetAiSamplingDataEx(g_id, aisamplingcount, aidata)
            '----------------------------------------
            ' エラー処理
            '----------------------------------------
            If (ret1 <> 0) Then
                ret2 = AioGetErrorString(ret1, error_string)
                '--------------------
                ' エラー文字列取得に失敗した場合
                ' エラー文字列を初期化
                '--------------------
                If (ret2 <> 0) Then
                    error_string.Clear()
                End If
                TextBox_Return.Text = "リピート終了イベント処理：AioGetAiSamplingDataEx = " & ret1 & " : " & error_string.ToString()
                Erase aidata
                Exit Sub
            End If
            g_sampling_count += aisamplingcount
            '----------------------------------------
            ' 総サンプリング回数を更新
            '----------------------------------------
            TextBox_SamplingCount.Text = g_sampling_count.ToString()
            '----------------------------------------
            ' 現在のリピート回数を取得
            '----------------------------------------
            ret1 = AioGetAiRepeatCount(g_id, airepeatcount)
            '----------------------------------------
            ' エラー処理
            '----------------------------------------
            If (ret1 <> 0) Then
                ret2 = AioGetErrorString(ret1, error_string)
                '--------------------
                ' エラー文字列取得に失敗した場合
                ' エラー文字列を初期化
                '--------------------
                If (ret2 <> 0) Then
                    error_string.Clear()
                End If
                TextBox_Return.Text = "リピート終了イベント処理：AioGetAiRepeatCount = " & ret1 & " : " & error_string.ToString()
                Erase aidata
                Exit Sub
            End If
            '----------------------------------------
            ' リピート回数を更新
            '----------------------------------------
            TextBox_RepeatCount.Text = airepeatcount.ToString()
            '----------------------------------------
            ' サンプリングデータを表示するための文字列を格納
            '----------------------------------------
            text_string = ""
            For i = 0 To (aisamplingcount - 1)
                text_string += String.Format("{0,5}:     ", i)
                For j = 0 To (aichannels - 1)
                    text_string += String.Format(aidata(i * aichannels + j).ToString("F5"))
                Next j
                text_string += vbCrLf
            Next i
            '----------------------------------------
            ' サンプリングデータを表示
            '----------------------------------------
            TextBox_SamplingData.Text = text_string
            '----------------------------------------
            ' イベント処理完了のメッセ―ジ表示
            '----------------------------------------
            TextBox_Return.Text = "リピート終了イベント処理：正常終了"
            Erase aidata
        End If
        '----------------------------------------
        ' デバイス動作終了イベント
        ' データの取得、表示を行う
        '----------------------------------------
        If m.Msg = AIOM_AIE_END Then
            '----------------------------------------
            ' ステータスを取得
            '----------------------------------------
            ret1 = AioGetAiStatus(g_id, aistatus)
            '----------------------------------------
            ' エラー処理
            '----------------------------------------
            If (ret1 <> 0) Then
                ret2 = AioGetErrorString(ret1, error_string)
                '--------------------
                ' エラー文字列取得に失敗した場合
                ' エラー文字列を初期化
                '--------------------
                If (ret2 <> 0) Then
                    error_string.Clear()
                End If
                TextBox_Return.Text = "デバイス動作終了イベント処理：AioGetAiStatus = " & ret1 & " : " & error_string.ToString()
                Exit Sub
            End If
            '----------------------------------------
            ' ステータスの表示
            '----------------------------------------
            text_string = String.Format("{0:X8}H (", aistatus)
            '--------------------
            ' 動作中ステータス有効時
            '--------------------
            If (aistatus And AIS_BUSY) = AIS_BUSY Then
                text_string += "動作中"
            '--------------------
            ' 動作中ステータス無効時
            '--------------------
            Else
                text_string += "停止中"
            End If
            '--------------------
            ' 開始トリガ待ちステータス有効時
            '--------------------
            If (aistatus And AIS_START_TRG) = AIS_START_TRG Then
                text_string += ", 開始トリガ待ち"
            End If
            '--------------------
            ' 指定サンプリング回数格納ステータス有効時
            '--------------------
            If (aistatus And AIS_DATA_NUM) = AIS_DATA_NUM Then
                text_string += ", 指定回数格納"
            End If
            '--------------------
            ' オーバーフローステータス有効時
            '--------------------
            If (aistatus And AIS_OFERR) = AIS_OFERR Then
                text_string += ", オーバーフロー"
            End If
            '--------------------
            ' サンプリングクロックエラーステータス有効時
            '--------------------
            If (aistatus And AIS_SCERR) = AIS_SCERR Then
                text_string += ", サンプリングクロックエラー"
            End If
            '--------------------
            ' AD変換エラーステータス有効時
            '--------------------
            If (aistatus And AIS_ADERR) = AIS_ADERR Then
                text_string += ", AD変換エラー"
            End If
            '--------------------
            ' ドライバスペックエラーステータス有効時
            '--------------------
            If (aistatus And AIS_DRVERR) = AIS_DRVERR Then
                text_string += ", ドライバスペックエラー"
            End If
            text_string += ")"
            TextBox_Status.Text = text_string
            '----------------------------------------
            ' 現在のサンプリング回数を取得
            '----------------------------------------
            ret1 = AioGetAiSamplingCount(g_id, aisamplingcount)
            '----------------------------------------
            ' エラー処理
            '----------------------------------------
            If (ret1 <> 0) Then
                ret2 = AioGetErrorString(ret1, error_string)
                '--------------------
                ' エラー文字列取得に失敗した場合
                ' エラー文字列を初期化
                '--------------------
                If (ret2 <> 0) Then
                    error_string.Clear()
                End If
                TextBox_Return.Text = "デバイス動作終了イベント処理：AioGetAiSamplingCount = " & ret1 & " : " & error_string.ToString()
                Exit Sub
            End If
            '----------------------------------------
            ' チャネル数取得
            '----------------------------------------
            ret1 = AioGetAiChannels(g_id, aichannels)
            '----------------------------------------
            ' エラー処理
            '----------------------------------------
            If (ret1 <> 0) Then
                ret2 = AioGetErrorString(ret1, error_string)
                '--------------------
                ' エラー文字列取得に失敗した場合
                ' エラー文字列を初期化
                '--------------------
                If (ret2 <> 0) Then
                    error_string.Clear()
                End If
                TextBox_Return.Text = "デバイス動作終了イベント処理：AioGetAiChannels = " & ret1 & " : " & error_string.ToString()
                Exit Sub
            End If
            '----------------------------------------
            ' サンプリングデータを取得
            '----------------------------------------
            '--------------------
            ' データ格納用の配列を確保
            '--------------------
            ReDim aidata(aisamplingcount * aichannels)
            If IsArray(aidata) = 0 Then
                TextBox_Return.Text = "デバイス動作終了イベント処理：データ格納用の配列確保に失敗"
                Exit Sub
            End If
            ret1 = AioGetAiSamplingDataEx(g_id, aisamplingcount, aidata)
            '----------------------------------------
            ' エラー処理
            '----------------------------------------
            If (ret1 <> 0) Then
                ret2 = AioGetErrorString(ret1, error_string)
                '--------------------
                ' エラー文字列取得に失敗した場合
                ' エラー文字列を初期化
                '--------------------
                If (ret2 <> 0) Then
                    error_string.Clear()
                End If
                TextBox_Return.Text = "デバイス動作終了イベント処理：AioGetAiSamplingDataEx = " & ret1 & " : " & error_string.ToString()
                Erase aidata
                Exit Sub
            End If
            g_sampling_count += aisamplingcount
            '----------------------------------------
            ' 総サンプリング回数を更新
            '----------------------------------------
            TextBox_SamplingCount.Text = g_sampling_count.ToString()
            '----------------------------------------
            ' 現在のリピート回数を取得
            '----------------------------------------
            ret1 = AioGetAiRepeatCount(g_id, airepeatcount)
            '----------------------------------------
            ' エラー処理
            '----------------------------------------
            If (ret1 <> 0) Then
                ret2 = AioGetErrorString(ret1, error_string)
                '--------------------
                ' エラー文字列取得に失敗した場合
                ' エラー文字列を初期化
                '--------------------
                If (ret2 <> 0) Then
                    error_string.Clear()
                End If
                TextBox_Return.Text = "デバイス動作終了イベント処理：AioGetAiRepeatCount = " & ret1 & " : " & error_string.ToString()
                Erase aidata
                Exit Sub
            End If
            '----------------------------------------
            ' リピート回数を更新
            '----------------------------------------
            TextBox_RepeatCount.Text = airepeatcount.ToString()
            '----------------------------------------
            ' サンプリングデータを表示するための文字列を格納
            '----------------------------------------
            text_string = ""
            For i = 0 To (aisamplingcount - 1)
                text_string += String.Format("{0,5}:     ", i)
                For j = 0 To (aichannels - 1)
                    text_string += String.Format(aidata(i * aichannels + j).ToString("F5"))
                Next j
                text_string += vbCrLf
            Next i
            '----------------------------------------
            ' サンプリングデータを表示
            '----------------------------------------
            TextBox_SamplingData.Text = text_string
            '----------------------------------------
            ' イベント処理完了のメッセ―ジ表示
            '----------------------------------------
            TextBox_Return.Text = "デバイス動作終了イベント処理：正常終了"
            Erase aidata
        End If
        MyBase.WndProc(m)
    End Sub
End Class

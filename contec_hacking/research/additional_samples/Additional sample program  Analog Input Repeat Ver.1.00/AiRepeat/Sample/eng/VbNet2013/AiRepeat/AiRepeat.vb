Imports System.Text

Public Class AiRepeat
    '----------------------------------------
    ' Declaration of global variables
    '----------------------------------------
    Dim g_id As Short
    Dim g_sampling_count As UInteger


    Private Sub AiRepeat_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '----------------------------------------
        ' Update the initial display of Device Name
        '----------------------------------------
        TextBox_DeviceName.Text = "AIO000"
    End Sub

    '================================================================================
    ' It is the process when the Device Init button is clicked
    ' Initialize the device
    '================================================================================
    Private Sub Button_Init_Click(sender As Object, e As EventArgs) Handles Button_Init.Click
        Dim ret1 As Integer                             ' For return value 1
        Dim ret2 As Integer                             ' For return value 2
        Dim error_string As New StringBuilder("", 256)  ' Error code string
        Dim devicename As String                        ' Device name

        '----------------------------------------
        ' Initialize the device
        '----------------------------------------
        '--------------------
        ' Get device name from the textbox
        '--------------------
        devicename = TextBox_DeviceName.Text
        '--------------------
        ' Device initialization
        ' Caution for modify this function (if modified, the application may not work)
        '--------------------
        ret1 = AioInit(devicename, g_id)
        '----------------------------------------
        ' Error process
        '----------------------------------------
        If (ret1 <> 0) Then
            ret2 = AioGetErrorString(ret1, error_string)
            '--------------------
            ' When failed to get the error string,
            ' initialize the error string
            '--------------------
            If (ret2 <> 0) Then
                error_string.Clear()
            End If
            TextBox_Return.Text = "Initialization Process : AioInit = " & ret1 & ":" & error_string.ToString()
            Exit Sub
        End If
        '----------------------------------------
        ' Reset device
        '----------------------------------------
        ret1 = AioResetDevice(g_id)
        '----------------------------------------
        ' Error process
        '----------------------------------------
        If (ret1 <> 0) Then
            ret2 = AioGetErrorString(ret1, error_string)
            '--------------------
            ' When failed to get the error string,
            ' initialize the error string
            '--------------------
            If (ret2 <> 0) Then
                error_string.Clear()
            End If
            TextBox_Return.Text = "Initialization Process : AioResetDevice = " & ret1 & ":" & error_string.ToString()
            Exit Sub
        End If
        '----------------------------------------
        ' Set the input method to Single-end
        '----------------------------------------
        ret1 = AioSetAiInputMethod(g_id, 0)
        '----------------------------------------
        ' Error process
        '----------------------------------------
        If (ret1 <> 0) Then
            ret2 = AioGetErrorString(ret1, error_string)
            '--------------------
            ' When failed to get the error string,
            ' initialize the error string
            '--------------------
            If (ret2 <> 0) Then
                error_string.Clear()
            End If
            TextBox_Return.Text = "Initialization Process : AioSetAiInputMethod = " & ret1 & ":" & error_string.ToString()
            Exit Sub
        End If
        '----------------------------------------
        ' Set the number of channels to 1 channel
        '----------------------------------------
        ret1 = AioSetAiChannels(g_id, 1)
        '----------------------------------------
        ' Error process
        '----------------------------------------
        If (ret1 <> 0) Then
            ret2 = AioGetErrorString(ret1, error_string)
            '--------------------
            ' When failed to get the error string,
            ' initialize the error string
            '--------------------
            If (ret2 <> 0) Then
                error_string.Clear()
            End If
            TextBox_Return.Text = "Initialization Process : AioSetAiChannels = " & ret1 & ":" & error_string.ToString()
            Exit Sub
        End If
        '----------------------------------------
        ' Set the input range to +/- 10V
        '----------------------------------------
        ret1 = AioSetAiRange(g_id, 0, PM10)
        '----------------------------------------
        ' Error process
        '----------------------------------------
        If (ret1 <> 0) Then
            ret2 = AioGetErrorString(ret1, error_string)
            '--------------------
            ' When failed to get the error string,
            ' initialize the error string
            '--------------------
            If (ret2 <> 0) Then
                error_string.Clear()
            End If
            TextBox_Return.Text = "Initialization Process : AioSetAiRange = " & ret1 & ":" & error_string.ToString()
            Exit Sub
        End If
        '----------------------------------------
        ' Set the memory type to FIFO
        '----------------------------------------
        ret1 = AioSetAiMemoryType(g_id, 0)
        '----------------------------------------
        ' Error process
        '----------------------------------------
        If (ret1 <> 0) Then
            ret2 = AioGetErrorString(ret1, error_string)
            '--------------------
            ' When failed to get the error string,
            ' initialize the error string
            '--------------------
            If (ret2 <> 0) Then
                error_string.Clear()
            End If
            TextBox_Return.Text = "Initialization Process : AioSetAiMemoryType = " & ret1 & ":" & error_string.ToString()
            Exit Sub
        End If
        '----------------------------------------
        ' Set the clock type to Internal Clock
        '----------------------------------------
        ret1 = AioSetAiClockType(g_id, 0)
        '----------------------------------------
        ' Error process
        '----------------------------------------
        If (ret1 <> 0) Then
            ret2 = AioGetErrorString(ret1, error_string)
            '--------------------
            ' When failed to get the error string,
            ' initialize the error string
            '--------------------
            If (ret2 <> 0) Then
                error_string.Clear()
            End If
            TextBox_Return.Text = "Initialization Process : AioSetAiClockType = " & ret1 & ":" & error_string.ToString()
            Exit Sub
        End If
        '----------------------------------------
        ' Set the sampling clock to 1 msec
        '----------------------------------------
        ret1 = AioSetAiSamplingClock(g_id, 1000)
        '----------------------------------------
        ' Error process
        '----------------------------------------
        If (ret1 <> 0) Then
            ret2 = AioGetErrorString(ret1, error_string)
            '--------------------
            ' When failed to get the error string,
            ' initialize the error string
            '--------------------
            If (ret2 <> 0) Then
                error_string.Clear()
            End If
            TextBox_Return.Text = "Initialization Process : AioSetAiSamplingClock = " & ret1 & ":" & error_string.ToString()
            Exit Sub
        End If
        '----------------------------------------
        ' Set the start condition to External Trigger Rising Edge
        '----------------------------------------
        ret1 = AioSetAiStartTrigger(g_id, 1)
        '----------------------------------------
        ' Error process
        '----------------------------------------
        If (ret1 <> 0) Then
            ret2 = AioGetErrorString(ret1, error_string)
            '--------------------
            ' When failed to get the error string,
            ' initialize the error string
            '--------------------
            If (ret2 <> 0) Then
                error_string.Clear()
            End If
            TextBox_Return.Text = "Initialization Process : AioSetAiStartTrigger = " & ret1 & ":" & error_string.ToString()
            Exit Sub
        End If
        '----------------------------------------
        ' Set the stop condition to Stop Conversion by The Specified Times
        '----------------------------------------
        ret1 = AioSetAiStopTrigger(g_id, 0)
        '----------------------------------------
        ' Error process
        '----------------------------------------
        If (ret1 <> 0) Then
            ret2 = AioGetErrorString(ret1, error_string)
            '--------------------
            ' When failed to get the error string,
            ' initialize the error string
            '--------------------
            If (ret2 <> 0) Then
                error_string.Clear()
            End If
            TextBox_Return.Text = "Initialization Process : AioSetAiStopTrigger = " & ret1 & ":" & error_string.ToString()
            Exit Sub
        End If
        '----------------------------------------
        ' Set the sampling stop times to 1000
        '----------------------------------------
        ret1 = AioSetAiStopTimes(g_id, 1000)
        '----------------------------------------
        ' Error process
        '----------------------------------------
        If (ret1 <> 0) Then
            ret2 = AioGetErrorString(ret1, error_string)
            '--------------------
            ' When failed to get the error string,
            ' initialize the error string
            '--------------------
            If (ret2 <> 0) Then
                error_string.Clear()
            End If
            TextBox_Return.Text = "Initialization Process : AioSetAiStopTimes = " & ret1 & ":" & error_string.ToString()
            Exit Sub
        End If
        '----------------------------------------
        ' Set the event factor to 'Event that AD conversion start ', 'Event that repeat end' and 'Event that device operation end'
        ' Caution for modify this function (if modified, the application may not work)
        '----------------------------------------
        ret1 = AioSetAiEvent(g_id, Handle.ToInt32, (AIE_START Or AIE_RPTEND Or AIE_END))
        '----------------------------------------
        ' Error process
        '----------------------------------------
        If (ret1 <> 0) Then
            ret2 = AioGetErrorString(ret1, error_string)
            '--------------------
            ' When failed to get the error string,
            ' initialize the error string
            '--------------------
            If (ret2 <> 0) Then
                error_string.Clear()
            End If
            TextBox_Return.Text = "Initialization Process : AioSetAiEvent = " & ret1 & ":" & error_string.ToString()
            Exit Sub
        End If
        '----------------------------------------
        ' Display the message that initialization process is completed
        '----------------------------------------
        TextBox_Return.Text = "Initialization Process : Successful completion"
    End Sub

    '================================================================================
    ' It is the process when the Repeat Times Setting button is clicked
    ' Set the repeat times
    '================================================================================
    Private Sub Button_Repeat_Click(sender As Object, e As EventArgs) Handles Button_Repeat.Click
        Dim ret1 As Integer                             ' For return value 1
        Dim ret2 As Integer                             ' For return value 2
        Dim repeat_times As Integer                     ' Repeat times
        Dim error_string As New StringBuilder("", 256)  ' Error code string

        '----------------------------------------
        ' Update GUI information
        '----------------------------------------
        Me.Refresh()
        '----------------------------------------
        ' Set the repeat times
        '----------------------------------------
        Try
            repeat_times = Val(TextBox_RepeatTimes.Text)
        Catch ex As Exception
            repeat_times = 0
        End Try
        ret1 = AioSetAiRepeatTimes(g_id, repeat_times)
        '----------------------------------------
        ' Error process
        '----------------------------------------
        If (ret1 <> 0) Then
            ret2 = AioGetErrorString(ret1, error_string)
            '--------------------
            ' When failed to get the error string,
            ' initialize the error string
            '--------------------
            If (ret2 <> 0) Then
                error_string.Clear()
            End If
            TextBox_Return.Text = "Repeat Times Setting Process : AioSetAiRepeatTimes = " & ret1 & ":" & error_string.ToString()
            Exit Sub
        End If
        '----------------------------------------
        ' Display the message that the repeat times setting process is completed
        '----------------------------------------
        TextBox_Return.Text = "Repeat Times Setting Process : Successful completion"
    End Sub

    '================================================================================
    ' It is the process when the Sampling Start button is clicked
    ' After clearing the memory and status, start sampling
    '================================================================================
    Private Sub Button_Start_Click(sender As Object, e As EventArgs) Handles Button_Start.Click
        Dim ret1 As Integer                             ' For return value 1
        Dim ret2 As Integer                             ' For return value 2
        Dim error_string As New StringBuilder("", 256)  ' Error code string
        Dim text_string As String                       ' For updating the textbox
        Dim aistatus As Integer                         ' Analog input status
        Dim airepeatcount As Integer                    ' Analog input repeat times

        '----------------------------------------
        ' Clear memory
        '----------------------------------------
        ret1 = AioResetAiMemory(g_id)
        '----------------------------------------
        ' Error process
        '----------------------------------------
        If (ret1 <> 0) Then
            ret2 = AioGetErrorString(ret1, error_string)
            '--------------------
            ' When failed to get the error string,
            ' initialize the error string
            '--------------------
            If (ret2 <> 0) Then
                error_string.Clear()
            End If
            TextBox_Return.Text = "Sampling Start : AioResetAiMemory = " & ret1 & ":" & error_string.ToString()
            Exit Sub
        End If
        '----------------------------------------
        ' Clear status
        '----------------------------------------
        ret1 = AioResetAiStatus(g_id)
        '----------------------------------------
        ' Error process
        '----------------------------------------
        If (ret1 <> 0) Then
            ret2 = AioGetErrorString(ret1, error_string)
            '--------------------
            ' When failed to get the error string,
            ' initialize the error string
            '--------------------
            If (ret2 <> 0) Then
                error_string.Clear()
            End If
            TextBox_Return.Text = "Sampling Start : AioResetAiStatus = " & ret1 & ":" & error_string.ToString()
            Exit Sub
        End If
        g_sampling_count = 0
        '----------------------------------------
        ' Start sampling
        '----------------------------------------
        ret1 = AioStartAi(g_id)
        '----------------------------------------
        ' Error process
        '----------------------------------------
        If (ret1 <> 0) Then
            ret2 = AioGetErrorString(ret1, error_string)
            '--------------------
            ' When failed to get the error string,
            ' initialize the error string
            '--------------------
            If (ret2 <> 0) Then
                error_string.Clear()
            End If
            TextBox_Return.Text = "Sampling Start : AioStartAi = " & ret1 & ":" & error_string.ToString()
            Exit Sub
        End If
        '----------------------------------------
        ' Get status
        '----------------------------------------
        ret1 = AioGetAiStatus(g_id, aistatus)
        '----------------------------------------
        ' Error process
        '----------------------------------------
        If (ret1 <> 0) Then
            ret2 = AioGetErrorString(ret1, error_string)
            '--------------------
            ' When failed to get the error string,
            ' initialize the error string
            '--------------------
            If (ret2 <> 0) Then
                error_string.Clear()
            End If
            TextBox_Return.Text = "Sampling Start : AioGetAiStatus = " & ret1 & ":" & error_string.ToString()
            Exit Sub
        End If
        '----------------------------------------
        ' Display status
        '----------------------------------------
        text_string = String.Format("{0:X8}H (", aistatus)
        '--------------------
        ' When status 'Device is running' is ON
        '--------------------
        If (aistatus And AIS_BUSY) = AIS_BUSY Then
            text_string += "Operating"
        '--------------------
        ' When status 'Device is running' is OFF
        '--------------------
        Else
            text_string += "Stop"
        End If
        '--------------------
        ' When status 'Wait the start trigger' is ON
        '--------------------
        If (aistatus And AIS_START_TRG) = AIS_START_TRG Then
            text_string += ", Wait the start trigger"
        End If
        '--------------------
        ' When status 'The specified number of data are stored' is ON
        '--------------------
        If (aistatus And AIS_DATA_NUM) = AIS_DATA_NUM Then
            text_string += ", The specified number of data are stored"
        End If
        '--------------------
        ' When status 'Overflow' is ON
        '--------------------
        If (aistatus And AIS_OFERR) = AIS_OFERR Then
            text_string += ", Overflow"
        End If
        '--------------------
        ' When status 'Sampling clock error' is ON
        '--------------------
        If (aistatus And AIS_SCERR) = AIS_SCERR Then
            text_string += ", Sampling clock error"
        End If
        '--------------------
        ' When status 'AD conversion error' is ON
        '--------------------
        If (aistatus And AIS_ADERR) = AIS_ADERR Then
            text_string += ", AD conversion error"
        End If
        '--------------------
        ' When status 'Driver spec error' is ON
        '--------------------
        If (aistatus And AIS_DRVERR) = AIS_DRVERR Then
            text_string += ", Driver spec error"
        End If
        text_string += ")"
        TextBox_Status.Text = text_string
        '----------------------------------------
        ' Update the total sampling times
        '----------------------------------------
        TextBox_SamplingCount.Text = g_sampling_count.ToString()
        '----------------------------------------
        ' Get the current repeat times
        '----------------------------------------
        ret1 = AioGetAiRepeatCount(g_id, airepeatcount)
        '----------------------------------------
        ' Error process
        '----------------------------------------
        If (ret1 <> 0) Then
            ret2 = AioGetErrorString(ret1, error_string)
            '--------------------
            ' When failed to get the error string,
            ' initialize the error string
            '--------------------
            If (ret2 <> 0) Then
                error_string.Clear()
            End If
            TextBox_Return.Text = "Sampling Start : AioGetAiRepeatCount = " & ret1 & ":" & error_string.ToString()
            Exit Sub
        End If
        '----------------------------------------
        ' Update the repeat times
        '----------------------------------------
        TextBox_RepeatCount.Text = airepeatcount.ToString()
        '----------------------------------------
        ' Display the message that sampling start is completed
        '----------------------------------------
        TextBox_Return.Text = "Sampling Start : Successful completion"
    End Sub

    '================================================================================
    ' It is the process when the Sampling Stop button is clicked
    ' Stop sampling
    '================================================================================
    Private Sub Button_Stop_Click(sender As Object, e As EventArgs) Handles Button_Stop.Click
        Dim ret1 As Integer                             ' For return value 1
        Dim ret2 As Integer                             ' For return value 2
        Dim error_string As New StringBuilder("", 256)  ' Error code string

        '----------------------------------------
        ' Stop sampling
        '----------------------------------------
        ret1 = AioStopAi(g_id)
        '----------------------------------------
        ' Error process
        '----------------------------------------
        If (ret1 <> 0) Then
            ret2 = AioGetErrorString(ret1, error_string)
            '--------------------
            ' When failed to get the error string,
            ' initialize the error string
            '--------------------
            If (ret2 <> 0) Then
                error_string.Clear()
            End If
            TextBox_Return.Text = "Sampling Stop : AioStopAi = " & ret1 & ":" & error_string.ToString()
            Exit Sub
        End If
        '----------------------------------------
        ' Display the message that sampling stop is completed
        '----------------------------------------
        TextBox_Return.Text = "Sampling Stop : Successful completion"
    End Sub

    '================================================================================
    ' It is the process when the Device Exit button is clicked
    ' Perform the exit process of device
    '================================================================================
    Private Sub Button_Exit_Click(sender As Object, e As EventArgs) Handles Button_Exit.Click
        Dim ret1 As Integer                             ' For return value 1
        Dim ret2 As Integer                             ' For return value 2
        Dim error_string As New StringBuilder("", 256)  ' Error code string

        '----------------------------------------
        ' Exit process of device
        '----------------------------------------
        ret1 = AioExit(g_id)
        '----------------------------------------
        ' Error process
        '----------------------------------------
        If (ret1 <> 0) Then
            ret2 = AioGetErrorString(ret1, error_string)
            '--------------------
            ' When failed to get the error string,
            ' initialize the error string
            '--------------------
            If (ret2 <> 0) Then
                error_string.Clear()
            End If
            TextBox_Return.Text = "Device Exit Process : AioExit = " & ret1 & ":" & error_string.ToString()
            Exit Sub
        End If
        '----------------------------------------
        ' Display the message that device exit process is completed
        '----------------------------------------
        TextBox_Return.Text = "Device Exit Process : Successful completion"
    End Sub

    '================================================================================
    ' It is the process when the Close button is clicked
    ' Perform the exit process of the application
    '================================================================================
    Private Sub Button_Close_Click(sender As Object, e As EventArgs) Handles Button_Close.Click
        '----------------------------------------
        ' Close dialog
        '----------------------------------------
        End
    End Sub

    '================================================================================
    ' Operation when an event occurs
    ' Process for each event occurred
    '================================================================================
    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        Dim ret1 As Integer                             ' For return value 1
        Dim ret2 As Integer                             ' For return value 2
        Dim error_string As New StringBuilder("", 256)  ' Error code string
        Dim text_string As String                       ' For updating the textbox
        Dim aisamplingcount As Integer                  ' Sampling count
        Dim aidata() As Single                          ' Analog data
        Dim aichannels As Short                         ' Number of channels
        Dim aistatus As Integer                         ' Status
        Dim airepeatcount As Integer                    ' Repeat times
        Dim i As Integer
        Dim j As Integer

        '----------------------------------------
        ' Event that AD conversion start
        ' Acquire and display data
        '----------------------------------------
        If m.Msg = AIOM_AIE_START Then
            '----------------------------------------
            ' Get status
            '----------------------------------------
            ret1 = AioGetAiStatus(g_id, aistatus)
            '----------------------------------------
            ' Error process
            '----------------------------------------
            If (ret1 <> 0) Then
                ret2 = AioGetErrorString(ret1, error_string)
                '--------------------
                ' When failed to get the error string,
                ' initialize the error string
                '--------------------
                If (ret2 <> 0) Then
                    error_string.Clear()
                End If
                TextBox_Return.Text = "AD Conversion Start Process : AioGetAiStatus = " & ret1 & " : " & error_string.ToString()
                Exit Sub
            End If
            '----------------------------------------
            ' Display status
            '----------------------------------------
            text_string = String.Format("{0:X8}H (", aistatus)
            '--------------------
            ' When status 'Device is running' is ON
            '--------------------
            If (aistatus And AIS_BUSY) = AIS_BUSY Then
                text_string += "Operating"
            '--------------------
            ' When status 'Device is running' is OFF
            '--------------------
            Else
                text_string += "Stop"
            End If
            '--------------------
            ' When status 'Wait the start trigger' is ON
            '--------------------
            If (aistatus And AIS_START_TRG) = AIS_START_TRG Then
                text_string += ", Wait the start trigger"
            End If
            '--------------------
            ' When status 'The specified number of data are stored' is ON
            '--------------------
            If (aistatus And AIS_DATA_NUM) = AIS_DATA_NUM Then
                text_string += ", The specified number of data are stored"
            End If
            '--------------------
            ' When status 'Overflow' is ON
            '--------------------
            If (aistatus And AIS_OFERR) = AIS_OFERR Then
                text_string += ", Overflow"
            End If
            '--------------------
            ' When status 'Sampling clock error' is ON
            '--------------------
            If (aistatus And AIS_SCERR) = AIS_SCERR Then
                text_string += ", Sampling clock error"
            End If
            '--------------------
            ' When status 'AD conversion error' is ON
            '--------------------
            If (aistatus And AIS_ADERR) = AIS_ADERR Then
                text_string += ", AD conversion error"
            End If
            '--------------------
            ' When status 'Driver spec error' is ON
            '--------------------
            If (aistatus And AIS_DRVERR) = AIS_DRVERR Then
                text_string += ", Driver spec error"
            End If
            text_string += ")"
            TextBox_Status.Text = text_string
            '----------------------------------------
            ' Display the message that event process is completed
            '----------------------------------------
            TextBox_Return.Text = "AD Conversion Start Process : Successful completion"
        End If
        '----------------------------------------
        ' Event that repeat end
        ' Acquire and display data
        '----------------------------------------
        If m.Msg = AIOM_AIE_RPTEND Then
            '----------------------------------------
            ' Get status
            '----------------------------------------
            ret1 = AioGetAiStatus(g_id, aistatus)
            '----------------------------------------
            ' Error process
            '----------------------------------------
            If (ret1 <> 0) Then
                ret2 = AioGetErrorString(ret1, error_string)
                '--------------------
                ' When failed to get the error string,
                ' initialize the error string
                '--------------------
                If (ret2 <> 0) Then
                    error_string.Clear()
                End If
                TextBox_Return.Text = "Repeat End Event Process : AioGetAiStatus = " & ret1 & " : " & error_string.ToString()
                Exit Sub
            End If
            '----------------------------------------
            ' Display status
            '----------------------------------------
            text_string = String.Format("{0:X8}H (", aistatus)
            '--------------------
            ' When status 'Device is running' is ON
            '--------------------
            If (aistatus And AIS_BUSY) = AIS_BUSY Then
                text_string += "Operating"
            '--------------------
            ' When status 'Device is running' is OFF
            '--------------------
            Else
                text_string += "Stop"
            End If
            '--------------------
            ' When status 'Wait the start trigger' is ON
            '--------------------
            If (aistatus And AIS_START_TRG) = AIS_START_TRG Then
                text_string += ", Wait the start trigger"
            End If
            '--------------------
            ' When status 'The specified number of data are stored' is ON
            '--------------------
            If (aistatus And AIS_DATA_NUM) = AIS_DATA_NUM Then
                text_string += ", The specified number of data are stored"
            End If
            '--------------------
            ' When status 'Overflow' is ON
            '--------------------
            If (aistatus And AIS_OFERR) = AIS_OFERR Then
                text_string += ", Overflow"
            End If
            '--------------------
            ' When status 'Sampling clock error' is ON
            '--------------------
            If (aistatus And AIS_SCERR) = AIS_SCERR Then
                text_string += ", Sampling clock error"
            End If
            '--------------------
            ' When status 'AD conversion error' is ON
            '--------------------
            If (aistatus And AIS_ADERR) = AIS_ADERR Then
                text_string += ", AD conversion error"
            End If
            '--------------------
            ' When status 'Driver spec error' is ON
            '--------------------
            If (aistatus And AIS_DRVERR) = AIS_DRVERR Then
                text_string += ", Driver spec error"
            End If
            text_string += ")"
            TextBox_Status.Text = text_string
            '----------------------------------------
            ' Get the current sampling times
            '----------------------------------------
            ret1 = AioGetAiSamplingCount(g_id, aisamplingcount)
            '----------------------------------------
            ' Error process
            '----------------------------------------
            If (ret1 <> 0) Then
                ret2 = AioGetErrorString(ret1, error_string)
                '--------------------
                ' When failed to get the error string,
                ' initialize the error string
                '--------------------
                If (ret2 <> 0) Then
                    error_string.Clear()
                End If
                TextBox_Return.Text = "Repeat End Event Process : AioGetAiSamplingCount = " & ret1 & " : " & error_string.ToString()
                Exit Sub
            End If
            '----------------------------------------
            ' Get the number of channels
            '----------------------------------------
            ret1 = AioGetAiChannels(g_id, aichannels)
            '----------------------------------------
            ' Error process
            '----------------------------------------
            If (ret1 <> 0) Then
                ret2 = AioGetErrorString(ret1, error_string)
                '--------------------
                ' When failed to get the error string,
                ' initialize the error string
                '--------------------
                If (ret2 <> 0) Then
                    error_string.Clear()
                End If
                TextBox_Return.Text = "Repeat End Event Process : AioGetAiChannels = " & ret1 & " : " & error_string.ToString()
                Exit Sub
            End If
            '----------------------------------------
            ' Get sampling data
            '----------------------------------------
            '--------------------
            ' Allocate an array for storing data
            '--------------------
            ReDim aidata(aisamplingcount * aichannels)
            If IsArray(aidata) = 0 Then
                TextBox_Return.Text = "Repeat End Event Process : Failed to allocate an array for storing data"
                Exit Sub
            End If
            ret1 = AioGetAiSamplingDataEx(g_id, aisamplingcount, aidata)
            '----------------------------------------
            ' Error process
            '----------------------------------------
            If (ret1 <> 0) Then
                ret2 = AioGetErrorString(ret1, error_string)
                '--------------------
                ' When failed to get the error string,
                ' initialize the error string
                '--------------------
                If (ret2 <> 0) Then
                    error_string.Clear()
                End If
                TextBox_Return.Text = "Repeat End Event Process : AioGetAiSamplingDataEx = " & ret1 & " : " & error_string.ToString()
                Erase aidata
                Exit Sub
            End If
            g_sampling_count += aisamplingcount
            '----------------------------------------
            ' Update the total sampling times
            '----------------------------------------
            TextBox_SamplingCount.Text = g_sampling_count.ToString()
            '----------------------------------------
            ' Get the current repeat times
            '----------------------------------------
            ret1 = AioGetAiRepeatCount(g_id, airepeatcount)
            '----------------------------------------
            ' Error process
            '----------------------------------------
            If (ret1 <> 0) Then
                ret2 = AioGetErrorString(ret1, error_string)
                '--------------------
                ' When failed to get the error string,
                ' initialize the error string
                '--------------------
                If (ret2 <> 0) Then
                    error_string.Clear()
                End If
                TextBox_Return.Text = "Repeat End Event Process : AioGetAiRepeatCount = " & ret1 & " : " & error_string.ToString()
                Erase aidata
                Exit Sub
            End If
            '----------------------------------------
            ' Update the repeat times
            '----------------------------------------
            TextBox_RepeatCount.Text = airepeatcount.ToString()
            '----------------------------------------
            ' Store a string for displaying the sampling data
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
            ' Display the sampling data
            '----------------------------------------
            TextBox_SamplingData.Text = text_string
            '----------------------------------------
            ' Display the message that event process is completed
            '----------------------------------------
            TextBox_Return.Text = "Repeat End Event Process : Successful completion"
            Erase aidata
        End If
        '----------------------------------------
        ' Event that device operation end
        ' Acquire and display data
        '----------------------------------------
        If m.Msg = AIOM_AIE_END Then
            '----------------------------------------
            ' Get status
            '----------------------------------------
            ret1 = AioGetAiStatus(g_id, aistatus)
            '----------------------------------------
            ' Error process
            '----------------------------------------
            If (ret1 <> 0) Then
                ret2 = AioGetErrorString(ret1, error_string)
                '--------------------
                ' When failed to get the error string,
                ' initialize the error string
                '--------------------
                If (ret2 <> 0) Then
                    error_string.Clear()
                End If
                TextBox_Return.Text = "Device Operation End Event Process : AioGetAiStatus = " & ret1 & " : " & error_string.ToString()
                Exit Sub
            End If
            '----------------------------------------
            ' Display status
            '----------------------------------------
            text_string = String.Format("{0:X8}H (", aistatus)
            '--------------------
            ' When status 'Device is running' is ON
            '--------------------
            If (aistatus And AIS_BUSY) = AIS_BUSY Then
                text_string += "Operating"
            '--------------------
            ' When status 'Device is running' is OFF
            '--------------------
            Else
                text_string += "Stop"
            End If
            '--------------------
            ' When status 'Wait the start trigger' is ON
            '--------------------
            If (aistatus And AIS_START_TRG) = AIS_START_TRG Then
                text_string += ", Wait the start trigger"
            End If
            '--------------------
            ' When status 'The specified number of data are stored' is ON
            '--------------------
            If (aistatus And AIS_DATA_NUM) = AIS_DATA_NUM Then
                text_string += ", The specified number of data are stored"
            End If
            '--------------------
            ' When status 'Overflow' is ON
            '--------------------
            If (aistatus And AIS_OFERR) = AIS_OFERR Then
                text_string += ", Overflow"
            End If
            '--------------------
            ' When status 'Sampling clock error' is ON
            '--------------------
            If (aistatus And AIS_SCERR) = AIS_SCERR Then
                text_string += ", Sampling clock error"
            End If
            '--------------------
            ' When status 'AD conversion error' is ON
            '--------------------
            If (aistatus And AIS_ADERR) = AIS_ADERR Then
                text_string += ", AD conversion error"
            End If
            '--------------------
            ' When status 'Driver spec error' is ON
            '--------------------
            If (aistatus And AIS_DRVERR) = AIS_DRVERR Then
                text_string += ", Driver spec error"
            End If
            text_string += ")"
            TextBox_Status.Text = text_string
            '----------------------------------------
            ' Get the current sampling times
            '----------------------------------------
            ret1 = AioGetAiSamplingCount(g_id, aisamplingcount)
            '----------------------------------------
            ' Error process
            '----------------------------------------
            If (ret1 <> 0) Then
                ret2 = AioGetErrorString(ret1, error_string)
                '--------------------
                ' When failed to get the error string,
                ' initialize the error string
                '--------------------
                If (ret2 <> 0) Then
                    error_string.Clear()
                End If
                TextBox_Return.Text = "Device Operation End Event Process : AioGetAiSamplingCount = " & ret1 & " : " & error_string.ToString()
                Exit Sub
            End If
            '----------------------------------------
            ' Get the number of channels
            '----------------------------------------
            ret1 = AioGetAiChannels(g_id, aichannels)
            '----------------------------------------
            ' Error process
            '----------------------------------------
            If (ret1 <> 0) Then
                ret2 = AioGetErrorString(ret1, error_string)
                '--------------------
                ' When failed to get the error string,
                ' initialize the error string
                '--------------------
                If (ret2 <> 0) Then
                    error_string.Clear()
                End If
                TextBox_Return.Text = "Device Operation End Event Process : AioGetAiChannels = " & ret1 & " : " & error_string.ToString()
                Exit Sub
            End If
            '----------------------------------------
            ' Get sampling data
            '----------------------------------------
            '--------------------
            ' Allocate an array for storing data
            '--------------------
            ReDim aidata(aisamplingcount * aichannels)
            If IsArray(aidata) = 0 Then
                TextBox_Return.Text = "Device Operation End Event Process : Failed to allocate an array for storing data"
                Exit Sub
            End If
            ret1 = AioGetAiSamplingDataEx(g_id, aisamplingcount, aidata)
            '----------------------------------------
            ' Error process
            '----------------------------------------
            If (ret1 <> 0) Then
                ret2 = AioGetErrorString(ret1, error_string)
                '--------------------
                ' When failed to get the error string,
                ' initialize the error string
                '--------------------
                If (ret2 <> 0) Then
                    error_string.Clear()
                End If
                TextBox_Return.Text = "Device Operation End Event Process : AioGetAiSamplingDataEx = " & ret1 & " : " & error_string.ToString()
                Erase aidata
                Exit Sub
            End If
            g_sampling_count += aisamplingcount
            '----------------------------------------
            ' Update the total sampling times
            '----------------------------------------
            TextBox_SamplingCount.Text = g_sampling_count.ToString()
            '----------------------------------------
            ' Get the current repeat times
            '----------------------------------------
            ret1 = AioGetAiRepeatCount(g_id, airepeatcount)
            '----------------------------------------
            ' Error process
            '----------------------------------------
            If (ret1 <> 0) Then
                ret2 = AioGetErrorString(ret1, error_string)
                '--------------------
                ' When failed to get the error string,
                ' initialize the error string
                '--------------------
                If (ret2 <> 0) Then
                    error_string.Clear()
                End If
                TextBox_Return.Text = "Device Operation End Event Process : AioGetAiRepeatCount = " & ret1 & " : " & error_string.ToString()
                Erase aidata
                Exit Sub
            End If
            '----------------------------------------
            ' Update the repeat times
            '----------------------------------------
            TextBox_RepeatCount.Text = airepeatcount.ToString()
            '----------------------------------------
            ' Store a string for displaying the sampling data
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
            ' Display the sampling data
            '----------------------------------------
            TextBox_SamplingData.Text = text_string
            '----------------------------------------
            ' Display the message that event process is completed
            '----------------------------------------
            TextBox_Return.Text = "Device Operation End Event Process : Successful completion"
            Erase aidata
        End If
        MyBase.WndProc(m)
    End Sub
End Class

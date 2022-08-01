<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AiRepeat
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Button_Close = New System.Windows.Forms.Button()
        Me.TextBox_Return = New System.Windows.Forms.TextBox()
        Me.TextBox_RepeatCount = New System.Windows.Forms.TextBox()
        Me.TextBox_Status = New System.Windows.Forms.TextBox()
        Me.TextBox_SamplingCount = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Button_Stop = New System.Windows.Forms.Button()
        Me.Button_Start = New System.Windows.Forms.Button()
        Me.TextBox_SamplingData = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Button_Repeat = New System.Windows.Forms.Button()
        Me.TextBox_RepeatTimes = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Button_Init = New System.Windows.Forms.Button()
        Me.TextBox_DeviceName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button_Exit = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button_Close
        '
        Me.Button_Close.Location = New System.Drawing.Point(354, 327)
        Me.Button_Close.Name = "Button_Close"
        Me.Button_Close.Size = New System.Drawing.Size(117, 25)
        Me.Button_Close.TabIndex = 24
        Me.Button_Close.Text = "Close"
        Me.Button_Close.UseVisualStyleBackColor = True
        '
        'TextBox_Return
        '
        Me.TextBox_Return.Location = New System.Drawing.Point(155, 392)
        Me.TextBox_Return.Name = "TextBox_Return"
        Me.TextBox_Return.Size = New System.Drawing.Size(193, 20)
        Me.TextBox_Return.TabIndex = 23
        '
        'TextBox_RepeatCount
        '
        Me.TextBox_RepeatCount.Location = New System.Drawing.Point(155, 361)
        Me.TextBox_RepeatCount.Name = "TextBox_RepeatCount"
        Me.TextBox_RepeatCount.Size = New System.Drawing.Size(193, 20)
        Me.TextBox_RepeatCount.TabIndex = 22
        Me.TextBox_RepeatCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TextBox_Status
        '
        Me.TextBox_Status.Location = New System.Drawing.Point(155, 298)
        Me.TextBox_Status.Name = "TextBox_Status"
        Me.TextBox_Status.Size = New System.Drawing.Size(193, 20)
        Me.TextBox_Status.TabIndex = 21
        '
        'TextBox_SamplingCount
        '
        Me.TextBox_SamplingCount.Location = New System.Drawing.Point(155, 329)
        Me.TextBox_SamplingCount.Name = "TextBox_SamplingCount"
        Me.TextBox_SamplingCount.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TextBox_SamplingCount.Size = New System.Drawing.Size(193, 20)
        Me.TextBox_SamplingCount.TabIndex = 20
        Me.TextBox_SamplingCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(24, 395)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(75, 13)
        Me.Label9.TabIndex = 18
        Me.Label9.Text = "Return Value: "
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(24, 364)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(131, 13)
        Me.Label8.TabIndex = 17
        Me.Label8.Text = "Number of Repeat Times: "
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(22, 332)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(113, 13)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "Number of Samplings: "
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(24, 301)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(43, 13)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "Status: "
        '
        'Button_Stop
        '
        Me.Button_Stop.Location = New System.Drawing.Point(342, 44)
        Me.Button_Stop.Name = "Button_Stop"
        Me.Button_Stop.Size = New System.Drawing.Size(117, 25)
        Me.Button_Stop.TabIndex = 5
        Me.Button_Stop.Text = "Sampling Stop"
        Me.Button_Stop.UseVisualStyleBackColor = True
        '
        'Button_Start
        '
        Me.Button_Start.Location = New System.Drawing.Point(342, 13)
        Me.Button_Start.Name = "Button_Start"
        Me.Button_Start.Size = New System.Drawing.Size(117, 25)
        Me.Button_Start.TabIndex = 4
        Me.Button_Start.Text = "Sampling Start"
        Me.Button_Start.UseVisualStyleBackColor = True
        '
        'TextBox_SamplingData
        '
        Me.TextBox_SamplingData.Location = New System.Drawing.Point(12, 51)
        Me.TextBox_SamplingData.Multiline = True
        Me.TextBox_SamplingData.Name = "TextBox_SamplingData"
        Me.TextBox_SamplingData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBox_SamplingData.Size = New System.Drawing.Size(180, 121)
        Me.TextBox_SamplingData.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(60, 35)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(43, 13)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Voltage"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 35)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(35, 13)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Count"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 13)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(74, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Samping Data"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Button_Stop)
        Me.GroupBox3.Controls.Add(Me.Button_Start)
        Me.GroupBox3.Controls.Add(Me.TextBox_SamplingData)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 110)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(471, 182)
        Me.GroupBox3.TabIndex = 14
        Me.GroupBox3.TabStop = False
        '
        'Button_Repeat
        '
        Me.Button_Repeat.Location = New System.Drawing.Point(342, 11)
        Me.Button_Repeat.Name = "Button_Repeat"
        Me.Button_Repeat.Size = New System.Drawing.Size(117, 25)
        Me.Button_Repeat.TabIndex = 3
        Me.Button_Repeat.Text = "Repeat Times Setting"
        Me.Button_Repeat.UseVisualStyleBackColor = True
        '
        'TextBox_RepeatTimes
        '
        Me.TextBox_RepeatTimes.Location = New System.Drawing.Point(92, 14)
        Me.TextBox_RepeatTimes.Name = "TextBox_RepeatTimes"
        Me.TextBox_RepeatTimes.Size = New System.Drawing.Size(100, 20)
        Me.TextBox_RepeatTimes.TabIndex = 1
        Me.TextBox_RepeatTimes.Text = "1"
        Me.TextBox_RepeatTimes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(79, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Repeat Times: "
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Button_Repeat)
        Me.GroupBox2.Controls.Add(Me.TextBox_RepeatTimes)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 62)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(471, 42)
        Me.GroupBox2.TabIndex = 13
        Me.GroupBox2.TabStop = False
        '
        'Button_Init
        '
        Me.Button_Init.Location = New System.Drawing.Point(342, 11)
        Me.Button_Init.Name = "Button_Init"
        Me.Button_Init.Size = New System.Drawing.Size(117, 25)
        Me.Button_Init.TabIndex = 2
        Me.Button_Init.Text = "Device Init"
        Me.Button_Init.UseVisualStyleBackColor = True
        '
        'TextBox_DeviceName
        '
        Me.TextBox_DeviceName.Location = New System.Drawing.Point(91, 13)
        Me.TextBox_DeviceName.Name = "TextBox_DeviceName"
        Me.TextBox_DeviceName.Size = New System.Drawing.Size(100, 20)
        Me.TextBox_DeviceName.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Device Name: "
        '
        'Button_Exit
        '
        Me.Button_Exit.Location = New System.Drawing.Point(354, 296)
        Me.Button_Exit.Name = "Button_Exit"
        Me.Button_Exit.Size = New System.Drawing.Size(117, 25)
        Me.Button_Exit.TabIndex = 19
        Me.Button_Exit.Text = "Device Exit"
        Me.Button_Exit.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Button_Init)
        Me.GroupBox1.Controls.Add(Me.TextBox_DeviceName)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 13)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(471, 42)
        Me.GroupBox1.TabIndex = 12
        Me.GroupBox1.TabStop = False
        '
        'AiRepeat
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(497, 424)
        Me.Controls.Add(Me.Button_Close)
        Me.Controls.Add(Me.TextBox_Return)
        Me.Controls.Add(Me.TextBox_RepeatCount)
        Me.Controls.Add(Me.TextBox_Status)
        Me.Controls.Add(Me.TextBox_SamplingCount)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Button_Exit)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AiRepeat"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AiRepeat"
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button_Close As System.Windows.Forms.Button
    Friend WithEvents TextBox_Return As System.Windows.Forms.TextBox
    Friend WithEvents TextBox_RepeatCount As System.Windows.Forms.TextBox
    Friend WithEvents TextBox_Status As System.Windows.Forms.TextBox
    Friend WithEvents TextBox_SamplingCount As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Button_Stop As System.Windows.Forms.Button
    Friend WithEvents Button_Start As System.Windows.Forms.Button
    Friend WithEvents TextBox_SamplingData As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Button_Repeat As System.Windows.Forms.Button
    Friend WithEvents TextBox_RepeatTimes As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Button_Init As System.Windows.Forms.Button
    Friend WithEvents TextBox_DeviceName As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button_Exit As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox

End Class

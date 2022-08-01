<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Windows フォーム デザイナで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナで必要です。
    'Windows フォーム デザイナを使用して変更できます。  
    'コード エディタを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ComboComPort1 = New System.Windows.Forms.ComboBox()
        Me.OpenButton = New System.Windows.Forms.Button()
        Me.Text1 = New System.Windows.Forms.TextBox()
        Me.EndButton = New System.Windows.Forms.Button()
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(20, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "COM Port No."
        '
        'ComboComPort1
        '
        Me.ComboComPort1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboComPort1.DropDownWidth = 78
        Me.ComboComPort1.FormattingEnabled = True
        Me.ComboComPort1.Location = New System.Drawing.Point(113, 17)
        Me.ComboComPort1.Name = "ComboComPort1"
        Me.ComboComPort1.Size = New System.Drawing.Size(78, 20)
        Me.ComboComPort1.TabIndex = 1
        '
        'OpenButton
        '
        Me.OpenButton.Location = New System.Drawing.Point(22, 51)
        Me.OpenButton.Name = "OpenButton"
        Me.OpenButton.Size = New System.Drawing.Size(90, 30)
        Me.OpenButton.TabIndex = 2
        Me.OpenButton.Text = "Port Open"
        Me.OpenButton.UseVisualStyleBackColor = True
        '
        'Text1
        '
        Me.Text1.Location = New System.Drawing.Point(22, 100)
        Me.Text1.Multiline = True
        Me.Text1.Name = "Text1"
        Me.Text1.Size = New System.Drawing.Size(349, 124)
        Me.Text1.TabIndex = 3
        '
        'EndButton
        '
        Me.EndButton.Location = New System.Drawing.Point(232, 236)
        Me.EndButton.Name = "EndButton"
        Me.EndButton.Size = New System.Drawing.Size(138, 23)
        Me.EndButton.TabIndex = 5
        Me.EndButton.Text = "Exit(&x)"
        Me.EndButton.UseVisualStyleBackColor = True
        '
        'SerialPort1
        '
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(389, 266)
        Me.Controls.Add(Me.EndButton)
        Me.Controls.Add(Me.Text1)
        Me.Controls.Add(Me.OpenButton)
        Me.Controls.Add(Me.ComboComPort1)
        Me.Controls.Add(Me.Label1)
        Me.KeyPreview = True
        Me.Name = "Form1"
        Me.Text = "ComSample"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents Label1 As System.Windows.Forms.Label
    Private WithEvents ComboComPort1 As System.Windows.Forms.ComboBox
    Private WithEvents OpenButton As System.Windows.Forms.Button
    Private WithEvents Text1 As System.Windows.Forms.TextBox
    Private WithEvents EndButton As System.Windows.Forms.Button
    Friend WithEvents SerialPort1 As System.IO.Ports.SerialPort

End Class

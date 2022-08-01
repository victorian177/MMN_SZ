namespace ComSample
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナ変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディタで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.ComboComPort1 = new System.Windows.Forms.ComboBox();
            this.OpenButton = new System.Windows.Forms.Button();
            this.Text1 = new System.Windows.Forms.TextBox();
            this.EndButton = new System.Windows.Forms.Button();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "COM Port No.";
            // 
            // ComboComPort1
            // 
            this.ComboComPort1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboComPort1.FormattingEnabled = true;
            this.ComboComPort1.Location = new System.Drawing.Point(113, 17);
            this.ComboComPort1.Name = "ComboComPort1";
            this.ComboComPort1.Size = new System.Drawing.Size(78, 20);
            this.ComboComPort1.TabIndex = 1;
            // 
            // OpenButton
            // 
            this.OpenButton.Location = new System.Drawing.Point(22, 51);
            this.OpenButton.Name = "OpenButton";
            this.OpenButton.Size = new System.Drawing.Size(90, 30);
            this.OpenButton.TabIndex = 2;
            this.OpenButton.Text = "Port Open";
            this.OpenButton.UseVisualStyleBackColor = true;
            this.OpenButton.Click += new System.EventHandler(this.OpenButton_Click);
            // 
            // Text1
            // 
            this.Text1.AcceptsReturn = true;
            this.Text1.Location = new System.Drawing.Point(22, 100);
            this.Text1.Multiline = true;
            this.Text1.Name = "Text1";
            this.Text1.Size = new System.Drawing.Size(349, 124);
            this.Text1.TabIndex = 3;
            // 
            // EndButton
            // 
            this.EndButton.Location = new System.Drawing.Point(232, 236);
            this.EndButton.Name = "EndButton";
            this.EndButton.Size = new System.Drawing.Size(138, 23);
            this.EndButton.TabIndex = 5;
            this.EndButton.Text = "Exit(&x)";
            this.EndButton.UseVisualStyleBackColor = true;
            this.EndButton.Click += new System.EventHandler(this.EndButton_Click);
            // 
            // serialPort1
            // 
            this.serialPort1.ErrorReceived += new System.IO.Ports.SerialErrorReceivedEventHandler(this.serialPort1_ErrorReceived);
            this.serialPort1.PinChanged += new System.IO.Ports.SerialPinChangedEventHandler(this.serialPort1_PinChanged);
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 266);
            this.Controls.Add(this.EndButton);
            this.Controls.Add(this.Text1);
            this.Controls.Add(this.OpenButton);
            this.Controls.Add(this.ComboComPort1);
            this.Controls.Add(this.label1);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ComboComPort1;
        private System.Windows.Forms.Button OpenButton;
        private System.Windows.Forms.TextBox Text1;
        private System.Windows.Forms.Button EndButton;
        private System.IO.Ports.SerialPort serialPort1;
    }
}


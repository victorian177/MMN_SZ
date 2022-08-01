namespace PCComm
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.cmdClose = new System.Windows.Forms.Button();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rtbDisplay = new System.Windows.Forms.RichTextBox();
            this.cmdSend = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.cboPort = new System.Windows.Forms.ComboBox();
            this.cmdOpen = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.mainTimer = new System.Windows.Forms.Timer(this.components);
            this.GroupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdClose
            // 
            this.cmdClose.Location = new System.Drawing.Point(12, 224);
            this.cmdClose.Margin = new System.Windows.Forms.Padding(4);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(112, 28);
            this.cmdClose.TabIndex = 5;
            this.cmdClose.Text = "Close";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.panel1);
            this.GroupBox1.Controls.Add(this.rtbDisplay);
            this.GroupBox1.Location = new System.Drawing.Point(16, 15);
            this.GroupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.GroupBox1.Size = new System.Drawing.Size(1218, 705);
            this.GroupBox1.TabIndex = 4;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Output Terminal";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Location = new System.Drawing.Point(8, 379);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1193, 318);
            this.panel1.TabIndex = 4;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // rtbDisplay
            // 
            this.rtbDisplay.Location = new System.Drawing.Point(9, 23);
            this.rtbDisplay.Margin = new System.Windows.Forms.Padding(4);
            this.rtbDisplay.Name = "rtbDisplay";
            this.rtbDisplay.Size = new System.Drawing.Size(1193, 348);
            this.rtbDisplay.TabIndex = 3;
            this.rtbDisplay.Text = "";
            this.rtbDisplay.TextChanged += new System.EventHandler(this.rtbDisplay_TextChanged);
            // 
            // cmdSend
            // 
            this.cmdSend.Location = new System.Drawing.Point(8, 169);
            this.cmdSend.Margin = new System.Windows.Forms.Padding(4);
            this.cmdSend.Name = "cmdSend";
            this.cmdSend.Size = new System.Drawing.Size(112, 28);
            this.cmdSend.TabIndex = 5;
            this.cmdSend.Text = "STOP";
            this.cmdSend.UseVisualStyleBackColor = true;
            this.cmdSend.Click += new System.EventHandler(this.cmdSend_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.cmdSend);
            this.groupBox2.Controls.Add(this.cmdClose);
            this.groupBox2.Controls.Add(this.Label1);
            this.groupBox2.Controls.Add(this.cboPort);
            this.groupBox2.Controls.Add(this.cmdOpen);
            this.groupBox2.Location = new System.Drawing.Point(1296, 15);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(128, 260);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Control";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(8, 22);
            this.Label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(34, 17);
            this.Label1.TabIndex = 15;
            this.Label1.Text = "Port";
            // 
            // cboPort
            // 
            this.cboPort.FormattingEnabled = true;
            this.cboPort.Location = new System.Drawing.Point(12, 42);
            this.cboPort.Margin = new System.Windows.Forms.Padding(4);
            this.cboPort.Name = "cboPort";
            this.cboPort.Size = new System.Drawing.Size(100, 24);
            this.cboPort.TabIndex = 10;
            this.cboPort.Text = "COM3";
            // 
            // cmdOpen
            // 
            this.cmdOpen.Location = new System.Drawing.Point(8, 75);
            this.cmdOpen.Margin = new System.Windows.Forms.Padding(4);
            this.cmdOpen.Name = "cmdOpen";
            this.cmdOpen.Size = new System.Drawing.Size(112, 28);
            this.cmdOpen.TabIndex = 8;
            this.cmdOpen.Text = "Open";
            this.cmdOpen.UseVisualStyleBackColor = true;
            this.cmdOpen.Click += new System.EventHandler(this.cmdOpen_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1308, 295);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 28);
            this.button1.TabIndex = 7;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(1295, 331);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(132, 123);
            this.textBox1.TabIndex = 8;
            this.textBox1.Text = "Hello";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 135);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(101, 27);
            this.button2.TabIndex = 9;
            this.button2.Text = "START";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // mainTimer
            // 
            this.mainTimer.Interval = 50;
            this.mainTimer.Tick += new System.EventHandler(this.mainTimer_Tick);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1440, 733);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.groupBox2);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Contec KT88  DAQ - Bioinstrumentation and Neuroengineering Lab";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.GroupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.GroupBox GroupBox1;
        private System.Windows.Forms.Button cmdSend;
        public System.Windows.Forms.RichTextBox rtbDisplay;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label Label1;
        private System.Windows.Forms.ComboBox cboPort;
        private System.Windows.Forms.Button cmdOpen;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Timer mainTimer;
    }
}
namespace AiRepeat
{
    partial class AiRepeat
    {
        /// <summary>
        /// 必要なデザイナー変数です。
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

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.button_Close = new System.Windows.Forms.Button();
            this.textBox_Return = new System.Windows.Forms.TextBox();
            this.textBox_RepeatCount = new System.Windows.Forms.TextBox();
            this.textBox_Status = new System.Windows.Forms.TextBox();
            this.textBox_SamplingCount = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button_Stop = new System.Windows.Forms.Button();
            this.button_Start = new System.Windows.Forms.Button();
            this.textBox_SamplingData = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button_Repeat = new System.Windows.Forms.Button();
            this.textBox_RepeatTimes = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button_Init = new System.Windows.Forms.Button();
            this.textBox_DeviceName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button_Exit = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_Close
            // 
            this.button_Close.Location = new System.Drawing.Point(315, 301);
            this.button_Close.Name = "button_Close";
            this.button_Close.Size = new System.Drawing.Size(108, 23);
            this.button_Close.TabIndex = 24;
            this.button_Close.Text = "閉じる";
            this.button_Close.UseVisualStyleBackColor = true;
            this.button_Close.Click += new System.EventHandler(this.button_Close_Click);
            // 
            // textBox_Return
            // 
            this.textBox_Return.Location = new System.Drawing.Point(116, 361);
            this.textBox_Return.Name = "textBox_Return";
            this.textBox_Return.Size = new System.Drawing.Size(193, 19);
            this.textBox_Return.TabIndex = 23;
            // 
            // textBox_RepeatCount
            // 
            this.textBox_RepeatCount.Location = new System.Drawing.Point(116, 332);
            this.textBox_RepeatCount.Name = "textBox_RepeatCount";
            this.textBox_RepeatCount.Size = new System.Drawing.Size(193, 19);
            this.textBox_RepeatCount.TabIndex = 22;
            this.textBox_RepeatCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox_Status
            // 
            this.textBox_Status.Location = new System.Drawing.Point(116, 274);
            this.textBox_Status.Name = "textBox_Status";
            this.textBox_Status.Size = new System.Drawing.Size(193, 19);
            this.textBox_Status.TabIndex = 21;
            // 
            // textBox_SamplingCount
            // 
            this.textBox_SamplingCount.Location = new System.Drawing.Point(116, 303);
            this.textBox_SamplingCount.Name = "textBox_SamplingCount";
            this.textBox_SamplingCount.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBox_SamplingCount.Size = new System.Drawing.Size(193, 19);
            this.textBox_SamplingCount.TabIndex = 20;
            this.textBox_SamplingCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(24, 364);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(43, 12);
            this.label9.TabIndex = 18;
            this.label9.Text = "戻り値：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(24, 335);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 12);
            this.label8.TabIndex = 17;
            this.label8.Text = "リピート回数：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(22, 306);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 12);
            this.label7.TabIndex = 16;
            this.label7.Text = "サンプリング回数：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 277);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 12);
            this.label6.TabIndex = 15;
            this.label6.Text = "ステータス：";
            // 
            // button_Stop
            // 
            this.button_Stop.Location = new System.Drawing.Point(303, 41);
            this.button_Stop.Name = "button_Stop";
            this.button_Stop.Size = new System.Drawing.Size(108, 23);
            this.button_Stop.TabIndex = 5;
            this.button_Stop.Text = "サンプリング停止";
            this.button_Stop.UseVisualStyleBackColor = true;
            this.button_Stop.Click += new System.EventHandler(this.button_Stop_Click);
            // 
            // button_Start
            // 
            this.button_Start.Location = new System.Drawing.Point(303, 12);
            this.button_Start.Name = "button_Start";
            this.button_Start.Size = new System.Drawing.Size(108, 23);
            this.button_Start.TabIndex = 4;
            this.button_Start.Text = "サンプリング開始";
            this.button_Start.UseVisualStyleBackColor = true;
            this.button_Start.Click += new System.EventHandler(this.button_Start_Click);
            // 
            // textBox_SamplingData
            // 
            this.textBox_SamplingData.Location = new System.Drawing.Point(12, 47);
            this.textBox_SamplingData.Multiline = true;
            this.textBox_SamplingData.Name = "textBox_SamplingData";
            this.textBox_SamplingData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_SamplingData.Size = new System.Drawing.Size(175, 112);
            this.textBox_SamplingData.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(60, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 2;
            this.label5.Text = "電圧";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "カウント";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "サンプリングデータ";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button_Stop);
            this.groupBox3.Controls.Add(this.button_Start);
            this.groupBox3.Controls.Add(this.textBox_SamplingData);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(12, 101);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(420, 168);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            // 
            // button_Repeat
            // 
            this.button_Repeat.Location = new System.Drawing.Point(303, 11);
            this.button_Repeat.Name = "button_Repeat";
            this.button_Repeat.Size = new System.Drawing.Size(108, 23);
            this.button_Repeat.TabIndex = 3;
            this.button_Repeat.Text = "リピート回数設定";
            this.button_Repeat.UseVisualStyleBackColor = true;
            this.button_Repeat.Click += new System.EventHandler(this.button_Repeat_Click);
            // 
            // textBox_RepeatTimes
            // 
            this.textBox_RepeatTimes.Location = new System.Drawing.Point(87, 13);
            this.textBox_RepeatTimes.Name = "textBox_RepeatTimes";
            this.textBox_RepeatTimes.Size = new System.Drawing.Size(100, 19);
            this.textBox_RepeatTimes.TabIndex = 1;
            this.textBox_RepeatTimes.Text = "1";
            this.textBox_RepeatTimes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "リピート回数：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button_Repeat);
            this.groupBox2.Controls.Add(this.textBox_RepeatTimes);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(12, 56);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(420, 39);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            // 
            // button_Init
            // 
            this.button_Init.Location = new System.Drawing.Point(303, 10);
            this.button_Init.Name = "button_Init";
            this.button_Init.Size = new System.Drawing.Size(108, 23);
            this.button_Init.TabIndex = 2;
            this.button_Init.Text = "デバイス初期化";
            this.button_Init.UseVisualStyleBackColor = true;
            this.button_Init.Click += new System.EventHandler(this.button_Init_Click);
            // 
            // textBox_DeviceName
            // 
            this.textBox_DeviceName.Location = new System.Drawing.Point(87, 12);
            this.textBox_DeviceName.Name = "textBox_DeviceName";
            this.textBox_DeviceName.Size = new System.Drawing.Size(100, 19);
            this.textBox_DeviceName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "デバイス名：";
            // 
            // button_Exit
            // 
            this.button_Exit.Location = new System.Drawing.Point(315, 272);
            this.button_Exit.Name = "button_Exit";
            this.button_Exit.Size = new System.Drawing.Size(108, 23);
            this.button_Exit.TabIndex = 19;
            this.button_Exit.Text = "デバイス終了処理";
            this.button_Exit.UseVisualStyleBackColor = true;
            this.button_Exit.Click += new System.EventHandler(this.button_Exit_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button_Init);
            this.groupBox1.Controls.Add(this.textBox_DeviceName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(420, 39);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            // 
            // AiRepeat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 391);
            this.Controls.Add(this.button_Close);
            this.Controls.Add(this.textBox_Return);
            this.Controls.Add(this.textBox_RepeatCount);
            this.Controls.Add(this.textBox_Status);
            this.Controls.Add(this.textBox_SamplingCount);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button_Exit);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AiRepeat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AiRepeat";
            this.Load += new System.EventHandler(this.AiRepeat_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Button button_Close;
        internal System.Windows.Forms.TextBox textBox_Return;
        internal System.Windows.Forms.TextBox textBox_RepeatCount;
        internal System.Windows.Forms.TextBox textBox_Status;
        internal System.Windows.Forms.TextBox textBox_SamplingCount;
        internal System.Windows.Forms.Label label9;
        internal System.Windows.Forms.Label label8;
        internal System.Windows.Forms.Label label7;
        internal System.Windows.Forms.Label label6;
        internal System.Windows.Forms.Button button_Stop;
        internal System.Windows.Forms.Button button_Start;
        internal System.Windows.Forms.TextBox textBox_SamplingData;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.GroupBox groupBox3;
        internal System.Windows.Forms.Button button_Repeat;
        internal System.Windows.Forms.TextBox textBox_RepeatTimes;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.GroupBox groupBox2;
        internal System.Windows.Forms.Button button_Init;
        internal System.Windows.Forms.TextBox textBox_DeviceName;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Button button_Exit;
        internal System.Windows.Forms.GroupBox groupBox1;
    }
}


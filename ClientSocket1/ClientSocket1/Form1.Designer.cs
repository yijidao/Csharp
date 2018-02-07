namespace ClientSocket1
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.tbx_IP = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbx_Port = new System.Windows.Forms.TextBox();
            this.btn_Connect = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txb_Send = new System.Windows.Forms.TextBox();
            this.btn_Send = new System.Windows.Forms.Button();
            this.rtb_Send = new System.Windows.Forms.RichTextBox();
            this.rtb_Recive = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP";
            // 
            // tbx_IP
            // 
            this.tbx_IP.Location = new System.Drawing.Point(110, 39);
            this.tbx_IP.Name = "tbx_IP";
            this.tbx_IP.Size = new System.Drawing.Size(186, 21);
            this.tbx_IP.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(314, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "端口";
            // 
            // tbx_Port
            // 
            this.tbx_Port.Location = new System.Drawing.Point(344, 39);
            this.tbx_Port.Name = "tbx_Port";
            this.tbx_Port.Size = new System.Drawing.Size(100, 21);
            this.tbx_Port.TabIndex = 3;
            // 
            // btn_Connect
            // 
            this.btn_Connect.Location = new System.Drawing.Point(462, 38);
            this.btn_Connect.Name = "btn_Connect";
            this.btn_Connect.Size = new System.Drawing.Size(75, 23);
            this.btn_Connect.TabIndex = 4;
            this.btn_Connect.Text = "连接服务端";
            this.btn_Connect.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(55, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "发送消息";
            // 
            // txb_Send
            // 
            this.txb_Send.Location = new System.Drawing.Point(111, 74);
            this.txb_Send.Name = "txb_Send";
            this.txb_Send.Size = new System.Drawing.Size(333, 21);
            this.txb_Send.TabIndex = 6;
            // 
            // btn_Send
            // 
            this.btn_Send.Location = new System.Drawing.Point(462, 73);
            this.btn_Send.Name = "btn_Send";
            this.btn_Send.Size = new System.Drawing.Size(75, 23);
            this.btn_Send.TabIndex = 7;
            this.btn_Send.Text = "发送消息";
            this.btn_Send.UseVisualStyleBackColor = true;
            // 
            // rtb_Send
            // 
            this.rtb_Send.Location = new System.Drawing.Point(57, 112);
            this.rtb_Send.Name = "rtb_Send";
            this.rtb_Send.Size = new System.Drawing.Size(480, 213);
            this.rtb_Send.TabIndex = 8;
            this.rtb_Send.Text = "";
            // 
            // rtb_Recive
            // 
            this.rtb_Recive.Location = new System.Drawing.Point(57, 360);
            this.rtb_Recive.Name = "rtb_Recive";
            this.rtb_Recive.Size = new System.Drawing.Size(480, 213);
            this.rtb_Recive.TabIndex = 9;
            this.rtb_Recive.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 625);
            this.Controls.Add(this.rtb_Recive);
            this.Controls.Add(this.rtb_Send);
            this.Controls.Add(this.btn_Send);
            this.Controls.Add(this.txb_Send);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_Connect);
            this.Controls.Add(this.tbx_Port);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbx_IP);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbx_IP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbx_Port;
        private System.Windows.Forms.Button btn_Connect;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txb_Send;
        private System.Windows.Forms.Button btn_Send;
        private System.Windows.Forms.RichTextBox rtb_Send;
        private System.Windows.Forms.RichTextBox rtb_Recive;
    }
}


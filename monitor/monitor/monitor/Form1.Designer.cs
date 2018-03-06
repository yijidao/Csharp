namespace monitor
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
            this.label2 = new System.Windows.Forms.Label();
            this.tbx_Monitor = new System.Windows.Forms.TextBox();
            this.tbx_Filter = new System.Windows.Forms.TextBox();
            this.btn_Start = new System.Windows.Forms.Button();
            this.rtb_Log = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 17);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(2, 4, 2, 5);
            this.label1.Size = new System.Drawing.Size(57, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "监控路径";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 46);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(2, 4, 2, 5);
            this.label2.Size = new System.Drawing.Size(57, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "过滤文件";
            // 
            // tbx_Monitor
            // 
            this.tbx_Monitor.Location = new System.Drawing.Point(93, 17);
            this.tbx_Monitor.Name = "tbx_Monitor";
            this.tbx_Monitor.Size = new System.Drawing.Size(249, 21);
            this.tbx_Monitor.TabIndex = 2;
            // 
            // tbx_Filter
            // 
            this.tbx_Filter.Location = new System.Drawing.Point(93, 46);
            this.tbx_Filter.Name = "tbx_Filter";
            this.tbx_Filter.Size = new System.Drawing.Size(249, 21);
            this.tbx_Filter.TabIndex = 3;
            // 
            // btn_Start
            // 
            this.btn_Start.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Start.Location = new System.Drawing.Point(384, 17);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(108, 48);
            this.btn_Start.TabIndex = 4;
            this.btn_Start.Text = "开始监控";
            this.btn_Start.UseVisualStyleBackColor = true;
            // 
            // rtb_Log
            // 
            this.rtb_Log.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtb_Log.Location = new System.Drawing.Point(38, 88);
            this.rtb_Log.Name = "rtb_Log";
            this.rtb_Log.Size = new System.Drawing.Size(454, 364);
            this.rtb_Log.TabIndex = 5;
            this.rtb_Log.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 480);
            this.Controls.Add(this.rtb_Log);
            this.Controls.Add(this.btn_Start);
            this.Controls.Add(this.tbx_Filter);
            this.Controls.Add(this.tbx_Monitor);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "监控程序";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbx_Monitor;
        private System.Windows.Forms.TextBox tbx_Filter;
        private System.Windows.Forms.Button btn_Start;
        private System.Windows.Forms.RichTextBox rtb_Log;
    }
}


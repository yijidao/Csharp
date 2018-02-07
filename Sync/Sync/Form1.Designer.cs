namespace Sync
{
    partial class FrmSync
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
            this.tbx_Source = new System.Windows.Forms.TextBox();
            this.tbx_Destination = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.rtx_Log = new System.Windows.Forms.RichTextBox();
            this.btn_Sync = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tbx_Filter = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "源目录";
            // 
            // tbx_Source
            // 
            this.tbx_Source.Location = new System.Drawing.Point(109, 32);
            this.tbx_Source.Name = "tbx_Source";
            this.tbx_Source.Size = new System.Drawing.Size(300, 21);
            this.tbx_Source.TabIndex = 1;
            // 
            // tbx_Destination
            // 
            this.tbx_Destination.Location = new System.Drawing.Point(109, 59);
            this.tbx_Destination.Name = "tbx_Destination";
            this.tbx_Destination.Size = new System.Drawing.Size(300, 21);
            this.tbx_Destination.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(53, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "目标目录";
            // 
            // rtx_Log
            // 
            this.rtx_Log.Location = new System.Drawing.Point(55, 173);
            this.rtx_Log.Name = "rtx_Log";
            this.rtx_Log.Size = new System.Drawing.Size(354, 266);
            this.rtx_Log.TabIndex = 4;
            this.rtx_Log.Text = "";
            // 
            // btn_Sync
            // 
            this.btn_Sync.Location = new System.Drawing.Point(128, 127);
            this.btn_Sync.Name = "btn_Sync";
            this.btn_Sync.Size = new System.Drawing.Size(75, 23);
            this.btn_Sync.TabIndex = 5;
            this.btn_Sync.Text = "开始同步";
            this.btn_Sync.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(53, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "过滤类型";
            // 
            // tbx_Filter
            // 
            this.tbx_Filter.Location = new System.Drawing.Point(109, 85);
            this.tbx_Filter.Name = "tbx_Filter";
            this.tbx_Filter.Size = new System.Drawing.Size(300, 21);
            this.tbx_Filter.TabIndex = 7;
            // 
            // FrmSync
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 470);
            this.Controls.Add(this.tbx_Filter);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_Sync);
            this.Controls.Add(this.rtx_Log);
            this.Controls.Add(this.tbx_Destination);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbx_Source);
            this.Controls.Add(this.label1);
            this.Name = "FrmSync";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbx_Source;
        private System.Windows.Forms.TextBox tbx_Destination;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox rtx_Log;
        private System.Windows.Forms.Button btn_Sync;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbx_Filter;
    }
}


namespace Synchronize
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
            this.tbx_Target = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbx_Local = new System.Windows.Forms.TextBox();
            this.tbx_Filter = new System.Windows.Forms.TextBox();
            this.btn_All = new System.Windows.Forms.Button();
            this.rtb_log = new System.Windows.Forms.RichTextBox();
            this.btn_Part = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(2, 4, 2, 5);
            this.label1.Size = new System.Drawing.Size(57, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "目标目录";
            // 
            // tbx_Target
            // 
            this.tbx_Target.Location = new System.Drawing.Point(69, 19);
            this.tbx_Target.Name = "tbx_Target";
            this.tbx_Target.Size = new System.Drawing.Size(306, 21);
            this.tbx_Target.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 46);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(2, 4, 2, 5);
            this.label2.Size = new System.Drawing.Size(57, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "本地目录";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 73);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(2, 4, 2, 5);
            this.label3.Size = new System.Drawing.Size(57, 21);
            this.label3.TabIndex = 3;
            this.label3.Text = "过滤条件";
            // 
            // tbx_Local
            // 
            this.tbx_Local.Location = new System.Drawing.Point(69, 46);
            this.tbx_Local.Name = "tbx_Local";
            this.tbx_Local.Size = new System.Drawing.Size(306, 21);
            this.tbx_Local.TabIndex = 4;
            // 
            // tbx_Filter
            // 
            this.tbx_Filter.Location = new System.Drawing.Point(69, 73);
            this.tbx_Filter.Name = "tbx_Filter";
            this.tbx_Filter.Size = new System.Drawing.Size(306, 21);
            this.tbx_Filter.TabIndex = 5;
            // 
            // btn_All
            // 
            this.btn_All.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_All.Location = new System.Drawing.Point(391, 19);
            this.btn_All.Name = "btn_All";
            this.btn_All.Size = new System.Drawing.Size(89, 36);
            this.btn_All.TabIndex = 6;
            this.btn_All.Text = "全部同步";
            this.btn_All.UseVisualStyleBackColor = true;
            // 
            // rtb_log
            // 
            this.rtb_log.Location = new System.Drawing.Point(14, 110);
            this.rtb_log.Name = "rtb_log";
            this.rtb_log.Size = new System.Drawing.Size(466, 327);
            this.rtb_log.TabIndex = 8;
            this.rtb_log.Text = "";
            // 
            // btn_Part
            // 
            this.btn_Part.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Part.Location = new System.Drawing.Point(391, 58);
            this.btn_Part.Name = "btn_Part";
            this.btn_Part.Size = new System.Drawing.Size(89, 36);
            this.btn_Part.TabIndex = 9;
            this.btn_Part.Text = "部分同步";
            this.btn_Part.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 451);
            this.Controls.Add(this.btn_Part);
            this.Controls.Add(this.rtb_log);
            this.Controls.Add(this.btn_All);
            this.Controls.Add(this.tbx_Filter);
            this.Controls.Add(this.tbx_Local);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbx_Target);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "同步程序";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbx_Target;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbx_Local;
        private System.Windows.Forms.TextBox tbx_Filter;
        private System.Windows.Forms.Button btn_All;
        private System.Windows.Forms.RichTextBox rtb_log;
        private System.Windows.Forms.Button btn_Part;
    }
}


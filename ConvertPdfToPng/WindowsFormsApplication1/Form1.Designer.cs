namespace WindowsFormsApplication1
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
            this.tb_Path = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rtb_Log = new System.Windows.Forms.RichTextBox();
            this.btn_Todo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tb_Path
            // 
            this.tb_Path.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_Path.Location = new System.Drawing.Point(54, 26);
            this.tb_Path.Name = "tb_Path";
            this.tb_Path.Size = new System.Drawing.Size(317, 21);
            this.tb_Path.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 26);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(2, 4, 2, 5);
            this.label1.Size = new System.Drawing.Size(33, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "路径";
            // 
            // rtb_Log
            // 
            this.rtb_Log.Location = new System.Drawing.Point(23, 65);
            this.rtb_Log.Name = "rtb_Log";
            this.rtb_Log.Size = new System.Drawing.Size(444, 351);
            this.rtb_Log.TabIndex = 2;
            this.rtb_Log.Text = "";
            // 
            // btn_Todo
            // 
            this.btn_Todo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Todo.Location = new System.Drawing.Point(392, 15);
            this.btn_Todo.Name = "btn_Todo";
            this.btn_Todo.Size = new System.Drawing.Size(75, 44);
            this.btn_Todo.TabIndex = 3;
            this.btn_Todo.Text = "开始报工";
            this.btn_Todo.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 444);
            this.Controls.Add(this.btn_Todo);
            this.Controls.Add(this.rtb_Log);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_Path);
            this.Name = "Form1";
            this.Text = "自动报工";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_Path;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox rtb_Log;
        private System.Windows.Forms.Button btn_Todo;
    }
}


namespace ReadAndWriteBinaryFile
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.WriteFileBtn = new System.Windows.Forms.Button();
            this.ShowTxt = new System.Windows.Forms.TextBox();
            this.ReadFileBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // WriteFileBtn
            // 
            this.WriteFileBtn.Location = new System.Drawing.Point(21, 12);
            this.WriteFileBtn.Name = "WriteFileBtn";
            this.WriteFileBtn.Size = new System.Drawing.Size(75, 23);
            this.WriteFileBtn.TabIndex = 0;
            this.WriteFileBtn.Text = "写入文件";
            this.WriteFileBtn.UseVisualStyleBackColor = true;
            this.WriteFileBtn.Click += new System.EventHandler(this.WriteFileBtn_Click);
            // 
            // ShowTxt
            // 
            this.ShowTxt.Location = new System.Drawing.Point(21, 33);
            this.ShowTxt.Multiline = true;
            this.ShowTxt.Name = "ShowTxt";
            this.ShowTxt.Size = new System.Drawing.Size(299, 149);
            this.ShowTxt.TabIndex = 1;
            // 
            // ReadFileBtn
            // 
            this.ReadFileBtn.Location = new System.Drawing.Point(21, 188);
            this.ReadFileBtn.Name = "ReadFileBtn";
            this.ReadFileBtn.Size = new System.Drawing.Size(75, 23);
            this.ReadFileBtn.TabIndex = 2;
            this.ReadFileBtn.Text = " 读取文件";
            this.ReadFileBtn.UseVisualStyleBackColor = true;
            this.ReadFileBtn.Click += new System.EventHandler(this.ReadFileBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 262);
            this.Controls.Add(this.ReadFileBtn);
            this.Controls.Add(this.ShowTxt);
            this.Controls.Add(this.WriteFileBtn);
            this.Name = "Form1";
            this.Text = "读写二进制文件";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button WriteFileBtn;
        private System.Windows.Forms.TextBox ShowTxt;
        private System.Windows.Forms.Button ReadFileBtn;
    }
}


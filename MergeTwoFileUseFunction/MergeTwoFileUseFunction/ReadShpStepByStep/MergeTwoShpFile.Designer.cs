namespace ReadShpStepByStep
{
    partial class MergeTwoShpFile
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
            this.label1 = new System.Windows.Forms.Label();
            this.ShpFilePath1 = new System.Windows.Forms.TextBox();
            this.CheckFileBtn1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SaveFilePath = new System.Windows.Forms.TextBox();
            this.MergeFileBtn = new System.Windows.Forms.Button();
            this.SelectSavePathBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.ShpFilePath2 = new System.Windows.Forms.TextBox();
            this.CheckFileBtn2 = new System.Windows.Forms.Button();
            this.QuitBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "请选择Shp文件1：";
            // 
            // ShpFilePath1
            // 
            this.ShpFilePath1.Location = new System.Drawing.Point(113, 6);
            this.ShpFilePath1.Name = "ShpFilePath1";
            this.ShpFilePath1.Size = new System.Drawing.Size(323, 21);
            this.ShpFilePath1.TabIndex = 1;
            // 
            // CheckFileBtn1
            // 
            this.CheckFileBtn1.Location = new System.Drawing.Point(442, 6);
            this.CheckFileBtn1.Name = "CheckFileBtn1";
            this.CheckFileBtn1.Size = new System.Drawing.Size(57, 23);
            this.CheckFileBtn1.TabIndex = 2;
            this.CheckFileBtn1.Text = "Open(&O)";
            this.CheckFileBtn1.UseVisualStyleBackColor = true;
            this.CheckFileBtn1.Click += new System.EventHandler(this.CheckFileBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "请选择保存Shp文件：";
            // 
            // SaveFilePath
            // 
            this.SaveFilePath.Location = new System.Drawing.Point(113, 90);
            this.SaveFilePath.Name = "SaveFilePath";
            this.SaveFilePath.Size = new System.Drawing.Size(323, 21);
            this.SaveFilePath.TabIndex = 6;
            // 
            // MergeFileBtn
            // 
            this.MergeFileBtn.Location = new System.Drawing.Point(157, 129);
            this.MergeFileBtn.Name = "MergeFileBtn";
            this.MergeFileBtn.Size = new System.Drawing.Size(108, 23);
            this.MergeFileBtn.TabIndex = 7;
            this.MergeFileBtn.Text = "MergeTwoFile(&M)";
            this.MergeFileBtn.UseVisualStyleBackColor = true;
            this.MergeFileBtn.Click += new System.EventHandler(this.MergeFileBtn_Click);
            // 
            // SelectSavePathBtn
            // 
            this.SelectSavePathBtn.Location = new System.Drawing.Point(442, 88);
            this.SelectSavePathBtn.Name = "SelectSavePathBtn";
            this.SelectSavePathBtn.Size = new System.Drawing.Size(57, 23);
            this.SelectSavePathBtn.TabIndex = 8;
            this.SelectSavePathBtn.Text = "Save(&S)";
            this.SelectSavePathBtn.UseVisualStyleBackColor = true;
            this.SelectSavePathBtn.Click += new System.EventHandler(this.SelectSavePathBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "请选择Shp文件2：";
            // 
            // ShpFilePath2
            // 
            this.ShpFilePath2.Location = new System.Drawing.Point(113, 45);
            this.ShpFilePath2.Name = "ShpFilePath2";
            this.ShpFilePath2.Size = new System.Drawing.Size(323, 21);
            this.ShpFilePath2.TabIndex = 10;
            // 
            // CheckFileBtn2
            // 
            this.CheckFileBtn2.Location = new System.Drawing.Point(442, 43);
            this.CheckFileBtn2.Name = "CheckFileBtn2";
            this.CheckFileBtn2.Size = new System.Drawing.Size(57, 23);
            this.CheckFileBtn2.TabIndex = 11;
            this.CheckFileBtn2.Text = "Open(&P)";
            this.CheckFileBtn2.UseVisualStyleBackColor = true;
            this.CheckFileBtn2.Click += new System.EventHandler(this.CheckFileBtn2_Click);
            // 
            // QuitBtn
            // 
            this.QuitBtn.Location = new System.Drawing.Point(297, 129);
            this.QuitBtn.Name = "QuitBtn";
            this.QuitBtn.Size = new System.Drawing.Size(75, 23);
            this.QuitBtn.TabIndex = 12;
            this.QuitBtn.Text = "Exit(&X)";
            this.QuitBtn.UseVisualStyleBackColor = true;
            this.QuitBtn.Click += new System.EventHandler(this.QuitBtn_Click);
            // 
            // MergeTwoShpFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 164);
            this.Controls.Add(this.QuitBtn);
            this.Controls.Add(this.CheckFileBtn2);
            this.Controls.Add(this.ShpFilePath2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.SelectSavePathBtn);
            this.Controls.Add(this.MergeFileBtn);
            this.Controls.Add(this.SaveFilePath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CheckFileBtn1);
            this.Controls.Add(this.ShpFilePath1);
            this.Controls.Add(this.label1);
            this.Name = "MergeTwoShpFile";
            this.Text = "读Shp文件";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ShpFilePath1;
        private System.Windows.Forms.Button CheckFileBtn1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox SaveFilePath;
        private System.Windows.Forms.Button MergeFileBtn;
        private System.Windows.Forms.Button SelectSavePathBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ShpFilePath2;
        private System.Windows.Forms.Button CheckFileBtn2;
        private System.Windows.Forms.Button QuitBtn;
    }
}


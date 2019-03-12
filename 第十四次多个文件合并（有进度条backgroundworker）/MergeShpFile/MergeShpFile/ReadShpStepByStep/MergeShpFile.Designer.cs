namespace ReadShpStepByStep
{
    partial class MergeShpFile
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.QuitBtn = new System.Windows.Forms.Button();
            this.CheckFileBtn2 = new System.Windows.Forms.Button();
            this.ShpFilePath2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SelectSavePathBtn = new System.Windows.Forms.Button();
            this.MergeFileBtn = new System.Windows.Forms.Button();
            this.SaveFilePath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CheckFileBtn1 = new System.Windows.Forms.Button();
            this.ShpFilePath1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.ExitBtn = new System.Windows.Forms.Button();
            this.MergeFolderBtn = new System.Windows.Forms.Button();
            this.SaveFileBtn = new System.Windows.Forms.Button();
            this.SaveFileName2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.OpenFolderBtn = new System.Windows.Forms.Button();
            this.OpenFolderName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label6 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.BtnCacel = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(518, 207);
            this.tabControl1.TabIndex = 13;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.QuitBtn);
            this.tabPage1.Controls.Add(this.CheckFileBtn2);
            this.tabPage1.Controls.Add(this.ShpFilePath2);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.SelectSavePathBtn);
            this.tabPage1.Controls.Add(this.MergeFileBtn);
            this.tabPage1.Controls.Add(this.SaveFilePath);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.CheckFileBtn1);
            this.tabPage1.Controls.Add(this.ShpFilePath1);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(510, 181);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "合并文件";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // QuitBtn
            // 
            this.QuitBtn.Location = new System.Drawing.Point(300, 141);
            this.QuitBtn.Name = "QuitBtn";
            this.QuitBtn.Size = new System.Drawing.Size(75, 23);
            this.QuitBtn.TabIndex = 23;
            this.QuitBtn.Text = "Exit(&X)";
            this.QuitBtn.UseVisualStyleBackColor = true;
            this.QuitBtn.Click += new System.EventHandler(this.QuitBtn_Click_1);
            // 
            // CheckFileBtn2
            // 
            this.CheckFileBtn2.Location = new System.Drawing.Point(445, 55);
            this.CheckFileBtn2.Name = "CheckFileBtn2";
            this.CheckFileBtn2.Size = new System.Drawing.Size(57, 23);
            this.CheckFileBtn2.TabIndex = 22;
            this.CheckFileBtn2.Text = "Open(&P)";
            this.CheckFileBtn2.UseVisualStyleBackColor = true;
            this.CheckFileBtn2.Click += new System.EventHandler(this.CheckFileBtn2_Click_1);
            // 
            // ShpFilePath2
            // 
            this.ShpFilePath2.Location = new System.Drawing.Point(116, 57);
            this.ShpFilePath2.Name = "ShpFilePath2";
            this.ShpFilePath2.Size = new System.Drawing.Size(323, 21);
            this.ShpFilePath2.TabIndex = 21;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 12);
            this.label3.TabIndex = 20;
            this.label3.Text = "请选择Shp文件2：";
            // 
            // SelectSavePathBtn
            // 
            this.SelectSavePathBtn.Location = new System.Drawing.Point(445, 100);
            this.SelectSavePathBtn.Name = "SelectSavePathBtn";
            this.SelectSavePathBtn.Size = new System.Drawing.Size(57, 23);
            this.SelectSavePathBtn.TabIndex = 19;
            this.SelectSavePathBtn.Text = "Save(&S)";
            this.SelectSavePathBtn.UseVisualStyleBackColor = true;
            this.SelectSavePathBtn.Click += new System.EventHandler(this.SelectSavePathBtn_Click_1);
            // 
            // MergeFileBtn
            // 
            this.MergeFileBtn.Location = new System.Drawing.Point(160, 141);
            this.MergeFileBtn.Name = "MergeFileBtn";
            this.MergeFileBtn.Size = new System.Drawing.Size(108, 23);
            this.MergeFileBtn.TabIndex = 18;
            this.MergeFileBtn.Text = "MergeTwoFile(&M)";
            this.MergeFileBtn.UseVisualStyleBackColor = true;
            this.MergeFileBtn.Click += new System.EventHandler(this.MergeFileBtn_Click_1);
            // 
            // SaveFilePath
            // 
            this.SaveFilePath.Location = new System.Drawing.Point(116, 102);
            this.SaveFilePath.Name = "SaveFilePath";
            this.SaveFilePath.Size = new System.Drawing.Size(323, 21);
            this.SaveFilePath.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 12);
            this.label2.TabIndex = 16;
            this.label2.Text = "请选择保存Shp文件：";
            // 
            // CheckFileBtn1
            // 
            this.CheckFileBtn1.Location = new System.Drawing.Point(445, 18);
            this.CheckFileBtn1.Name = "CheckFileBtn1";
            this.CheckFileBtn1.Size = new System.Drawing.Size(57, 23);
            this.CheckFileBtn1.TabIndex = 15;
            this.CheckFileBtn1.Text = "Open(&O)";
            this.CheckFileBtn1.UseVisualStyleBackColor = true;
            this.CheckFileBtn1.Click += new System.EventHandler(this.CheckFileBtn1_Click);
            // 
            // ShpFilePath1
            // 
            this.ShpFilePath1.Location = new System.Drawing.Point(116, 18);
            this.ShpFilePath1.Name = "ShpFilePath1";
            this.ShpFilePath1.Size = new System.Drawing.Size(323, 21);
            this.ShpFilePath1.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 12);
            this.label1.TabIndex = 13;
            this.label1.Text = "请选择Shp文件1：";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.BtnCacel);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.progressBar1);
            this.tabPage2.Controls.Add(this.ExitBtn);
            this.tabPage2.Controls.Add(this.MergeFolderBtn);
            this.tabPage2.Controls.Add(this.SaveFileBtn);
            this.tabPage2.Controls.Add(this.SaveFileName2);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.OpenFolderBtn);
            this.tabPage2.Controls.Add(this.OpenFolderName);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(510, 181);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "合并目录";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // ExitBtn
            // 
            this.ExitBtn.Location = new System.Drawing.Point(341, 143);
            this.ExitBtn.Name = "ExitBtn";
            this.ExitBtn.Size = new System.Drawing.Size(75, 23);
            this.ExitBtn.TabIndex = 7;
            this.ExitBtn.Text = "Exit(&X)";
            this.ExitBtn.UseVisualStyleBackColor = true;
            this.ExitBtn.Click += new System.EventHandler(this.ExitBtn_Click);
            // 
            // MergeFolderBtn
            // 
            this.MergeFolderBtn.Location = new System.Drawing.Point(111, 143);
            this.MergeFolderBtn.Name = "MergeFolderBtn";
            this.MergeFolderBtn.Size = new System.Drawing.Size(105, 23);
            this.MergeFolderBtn.TabIndex = 6;
            this.MergeFolderBtn.Text = "MergeFolder(&M)";
            this.MergeFolderBtn.UseVisualStyleBackColor = true;
            this.MergeFolderBtn.Click += new System.EventHandler(this.MergeFolderBtn_Click);
            // 
            // SaveFileBtn
            // 
            this.SaveFileBtn.Location = new System.Drawing.Point(422, 68);
            this.SaveFileBtn.Name = "SaveFileBtn";
            this.SaveFileBtn.Size = new System.Drawing.Size(75, 23);
            this.SaveFileBtn.TabIndex = 5;
            this.SaveFileBtn.Text = "Save(&S)";
            this.SaveFileBtn.UseVisualStyleBackColor = true;
            this.SaveFileBtn.Click += new System.EventHandler(this.SaveFileBtn_Click);
            // 
            // SaveFileName2
            // 
            this.SaveFileName2.Location = new System.Drawing.Point(111, 70);
            this.SaveFileName2.Name = "SaveFileName2";
            this.SaveFileName2.Size = new System.Drawing.Size(305, 21);
            this.SaveFileName2.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 12);
            this.label5.TabIndex = 3;
            this.label5.Text = "保存文件:";
            // 
            // OpenFolderBtn
            // 
            this.OpenFolderBtn.Location = new System.Drawing.Point(422, 28);
            this.OpenFolderBtn.Name = "OpenFolderBtn";
            this.OpenFolderBtn.Size = new System.Drawing.Size(75, 23);
            this.OpenFolderBtn.TabIndex = 2;
            this.OpenFolderBtn.Text = "Open(&O)";
            this.OpenFolderBtn.UseVisualStyleBackColor = true;
            this.OpenFolderBtn.Click += new System.EventHandler(this.OpenFolderBtn_Click);
            // 
            // OpenFolderName
            // 
            this.OpenFolderName.Location = new System.Drawing.Point(111, 28);
            this.OpenFolderName.Name = "OpenFolderName";
            this.OpenFolderName.Size = new System.Drawing.Size(305, 21);
            this.OpenFolderName.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "选择文件夹:";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(19, 114);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(397, 23);
            this.progressBar1.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(423, 124);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 12);
            this.label6.TabIndex = 9;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // BtnCacel
            // 
            this.BtnCacel.Location = new System.Drawing.Point(244, 142);
            this.BtnCacel.Name = "BtnCacel";
            this.BtnCacel.Size = new System.Drawing.Size(75, 23);
            this.BtnCacel.TabIndex = 10;
            this.BtnCacel.Text = "Cancel(&C)";
            this.BtnCacel.UseVisualStyleBackColor = true;
            this.BtnCacel.Click += new System.EventHandler(this.BtnCacel_Click);
            // 
            // MergeShpFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 222);
            this.Controls.Add(this.tabControl1);
            this.Name = "MergeShpFile";
            this.Text = "读Shp文件";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button QuitBtn;
        private System.Windows.Forms.Button CheckFileBtn2;
        private System.Windows.Forms.TextBox ShpFilePath2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button SelectSavePathBtn;
        private System.Windows.Forms.Button MergeFileBtn;
        private System.Windows.Forms.TextBox SaveFilePath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button CheckFileBtn1;
        private System.Windows.Forms.TextBox ShpFilePath1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button ExitBtn;
        private System.Windows.Forms.Button MergeFolderBtn;
        private System.Windows.Forms.Button SaveFileBtn;
        private System.Windows.Forms.TextBox SaveFileName2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button OpenFolderBtn;
        private System.Windows.Forms.TextBox OpenFolderName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button BtnCacel;

    }
}


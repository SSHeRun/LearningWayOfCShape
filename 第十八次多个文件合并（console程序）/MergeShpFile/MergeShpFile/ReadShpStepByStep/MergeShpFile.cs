using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections.ObjectModel;
using ShpMerger;

namespace ReadShpStepByStep
{
    public partial class MergeShpFile : Form
    {
        private String SourceFileName1 = "";
        private String SourceFileName2 = "";
        private String SaveFileName = "";
        string TargetFile;
        string[] files;
        TimeSpan ts1;
        int Progress = 0;
        string  xmlName = "FolderAndFilesName.xml";
        public MergeShpFile()
        {
            InitializeComponent();
        }

        private void OpenFolderBtn_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                FolderNameCom.Text = dialog.SelectedPath;
            }
            dialog.Dispose();

        }

        private void SaveFileBtn_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Shape Files|*.shp";
            if (dialog.ShowDialog() == DialogResult.OK)
            {

                FileNameCom.Text = dialog.FileName;
                //SaveFileName = SaveFileName2.Text;
            }
            dialog.Dispose();
        }

        private void SelectSavePathBtn_Click_1(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Shape Files|*.shp";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                SaveFilePath.Text = dialog.FileName;
                SaveFileName = SaveFilePath.Text;
            }
            dialog.Dispose();
        }

        private void CheckFileBtn1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                ShpFilePath1.Text = dialog.FileName;
                SourceFileName1 = ShpFilePath1.Text;
            }
            dialog.Dispose();
        }

        private void CheckFileBtn2_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                ShpFilePath2.Text = dialog.FileName;
                SourceFileName2 = ShpFilePath2.Text;
            }
            dialog.Dispose();
        }

        private void MergeFileBtn_Click_1(object sender, EventArgs e)
        {
            // 首先判断，文件是否已经存在
            if (!(File.Exists(SourceFileName1) && File.Exists(SourceFileName2)))
            {
                // 如果文件不存在，那么提示无法读取！
                MessageBox.Show(SourceFileName1 + "或者" + SourceFileName2 + "文件不存在！");
                return;
            }
            try
            {
                if (File.Exists(SaveFileName))
                {
                    File.Delete(SaveFileName);
                }
                ShapeFileFunction.MergeTwoShpFile(SourceFileName1, SourceFileName2, SaveFileName);
            }
            catch (Exception ex)
            {
                Console.WriteLine("在合并文件的过程中，发生了异常！");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            MessageBox.Show("合并完成！");
        }

        private void QuitBtn_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MergeFolderBtn_Click(object sender, EventArgs e)
        {
            string sourceDerectiony = FolderNameCom.Text.Trim();
            TargetFile = FileNameCom.Text.Trim();
            if (sourceDerectiony.Length <= 0 || TargetFile.Length <= 0)
            {
                MessageBox.Show("SourceFolder or TargetFile is null.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else if (!Directory.Exists(sourceDerectiony))
            {
                MessageBox.Show("SourceFolder isn't exist.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (File.Exists(TargetFile))
            {
                File.Delete(TargetFile);
            }
            files = Directory.GetFiles(sourceDerectiony, "*.shp");
            if (files.Length <= 1)
            {
                MessageBox.Show("Merge file less 1.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            ts1 = new TimeSpan(DateTime.Now.Ticks); //获取当前时间的刻度数
            Progress = 0;
            backgroundWorker1.RunWorkerAsync();


            int folderCount = 3;
            int filesCount = 3;
                       //判断xml文件是否存在
            if (!File.Exists(xmlName))
            {
                ReadAndWriteXml.CreateXmlFile(xmlName, folderCount, filesCount);
            }

            //保存合并源文件夹和目标文件名称
            ReadAndWriteXml.WriteFolderOrFileToXml(xmlName, sourceDerectiony, 1);
            ReadAndWriteXml.WriteFolderOrFileToXml(xmlName, TargetFile, 2);
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            try
            {
             //   ShapeFileFunction.MergeManyShpFile(files, TargetFile, worker, e);
                ShpFileMager sp = new ShpFileMager();
                sp.Merge(files, TargetFile, worker, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Merge error,error code:" + ex.ToString(), "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            MergeFolderBtn.Enabled = false;
            BtnCacel.Enabled = true;
            Progress = e.ProgressPercentage;
            this.progressBar1.Value = e.ProgressPercentage;
            this.label6.Text = e.ProgressPercentage.ToString() + "%";
        }

        private void BtnCacel_Click(object sender, EventArgs e)
        {
            this.backgroundWorker1.CancelAsync();
            BtnCacel.Enabled = false;
            MergeFolderBtn.Enabled = true;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
            }
            else if (e.Cancelled)
            {
                MessageBox.Show("Cancel merge，complte" + Progress.ToString() + "%.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                TimeSpan ts2 = new TimeSpan(DateTime.Now.Ticks);
                TimeSpan ts = ts2.Subtract(ts1).Duration(); //时间差的绝对值 
                String spanTime = ts.Hours.ToString() + "小时" + ts.Minutes.ToString() + "分" + ts.Seconds.ToString() + "秒" + ts.Milliseconds.ToString() + "毫秒"; //以X小时X分X秒的格式现实执行时间 
                MessageBox.Show("合并结束，耗时" + spanTime);
                progressBar1.Value = 0;
                label6.Text = "";
                BtnCacel.Enabled = false;
                MergeFolderBtn.Enabled  = true;

            }
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("You sure exit?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void MergeShpFile_Load(object sender, EventArgs e)
        {
            if (File.Exists(xmlName))
            {
                Collection<string> names = ReadAndWriteXml.LoadFileOrFolderName(xmlName, 1);
                foreach (string str in names)
                {
                    FolderNameCom.Items.Add(str);
                }
                if (FolderNameCom.Items.Count > 0)
                {
                    FolderNameCom.SelectedIndex = 0;
                }
                names = ReadAndWriteXml.LoadFileOrFolderName(xmlName, 2);
                foreach (string str in names)
                {
                    FileNameCom.Items.Add(str);
                }
                if (FileNameCom.Items.Count > 0)
                {
                    FileNameCom.SelectedIndex = 0;
                }
            }
            }
            
    }
}

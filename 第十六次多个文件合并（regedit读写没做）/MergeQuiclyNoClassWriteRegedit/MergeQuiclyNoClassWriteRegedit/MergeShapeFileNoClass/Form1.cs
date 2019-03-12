using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using Regedit;
using System.Collections.ObjectModel;
namespace MergeShapeFileNoClass
{

    public partial class Form1 : Form
    {
 
        TimeSpan ts1;
        int Progress = 0;
        string TargetFile;
        string[] files;
        delegate void Updatecontrl();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                cbxFolder.Text = dialog.SelectedPath;
            }
            dialog.Dispose();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Shape Files|*.shp";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                cbxFile.Text = dialog.FileName;
            }
            dialog.Dispose();
        }

        public void initializationFolderAndFile()
        {
            // Read the folder name  and file name to regedit. 
            RegeditReadAndWrite regeditReadAndWrite = new RegeditReadAndWrite(10);
            Collection<string> Folder = regeditReadAndWrite.ReadRegedit("Folder");
            Collection<string> File = regeditReadAndWrite.ReadRegedit("File");
            cbxFolder.Items.Clear();
            cbxFile.Items.Clear();
            if (Folder != null)
            {
                foreach (string item in Folder)
                {
                    cbxFolder.Items.Add(item);
                }
                cbxFolder.SelectedIndex = 0;
            }
            if (File != null)
            {
                foreach (string item in File)
                {
                    cbxFile.Items.Add(item);
                }
                cbxFile.SelectedIndex = 0;
            }
        }

        private void ButtonMergeTwo_Click(object sender, EventArgs e)
        {
            string sourceDerectiony = cbxFolder.Text.Trim();
            TargetFile = cbxFile.Text.Trim();
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

            files = Directory.GetFiles(sourceDerectiony, "*.shp");
            if (files.Length <= 1)
            {
                MessageBox.Show("Merge file less 1.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            Progress = 0;

            backgroundWorker1.RunWorkerAsync();
            this.lblPercent.Text = "";
            this.lblPercent.Visible = true;
            btnCancel.Enabled = true;

            ts1 = new TimeSpan(DateTime.Now.Ticks); //获取当前时间的刻度数

            // Write the folder name  and file name to regedit. 
            RegeditReadAndWrite regeditReadAndWrite = new RegeditReadAndWrite(10);
            regeditReadAndWrite.WriteRegedit("Folder", sourceDerectiony);
            regeditReadAndWrite.WriteRegedit("File", TargetFile);

            // Initialization the folder droplist and file droplist.
            initializationFolderAndFile();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("You sure exit?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ButtonMergeTwo.Enabled = false;
            btnCancel.Enabled = true;
            Progress = e.ProgressPercentage;
            this.progressBar1.Value = e.ProgressPercentage;
            this.lblPercent.Text = e.ProgressPercentage.ToString() + "%";
        }
        private void UpdatepLabel()
        {
            this.lblPercent.Text = "";
            this.lblPercent.Visible = false;
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
                //   MessageBox.Show("合并结束，耗时" + spanTime);

                MessageBox.Show("Merge success." + "耗时" + spanTime, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //If hide the progressbar use the code
                //this.progressBar1.Invoke(new Updatecontrl(Updateprogress));

                this.lblPercent.Invoke(new Updatecontrl(UpdatepLabel));
            }
            this.ButtonMergeTwo.Enabled = true;
            this.btnCancel.Enabled = false;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            try
            {
                ShapeFucntion.MergerManyShapeFile(files, TargetFile, worker, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Merge error,error code:" + ex.ToString(), "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.backgroundWorker1.CancelAsync();
            btnCancel.Enabled = false;
            ButtonMergeTwo.Enabled = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            initializationFolderAndFile();
        }
    }
}

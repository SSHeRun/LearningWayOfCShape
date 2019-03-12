using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ReadShpStepByStep
{
    public partial class MergeTwoShpFile : Form
    {

        private String SourceFileName1 = "";
        private String SourceFileName2 = "";
        private String SaveFileName = "";
        public MergeTwoShpFile()
        {
            InitializeComponent();
        }

        private void CheckFileBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                ShpFilePath1.Text = dialog.FileName;
                SourceFileName1 = ShpFilePath1.Text;
            }
            dialog.Dispose();
        }

        private void MergeFileBtn_Click(object sender, EventArgs e)
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

        private void SelectSavePathBtn_Click(object sender, EventArgs e)
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

        private void CheckFileBtn2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                ShpFilePath2.Text = dialog.FileName;
                SourceFileName2 = ShpFilePath2.Text;
            }
            dialog.Dispose();
        }

        private void QuitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}

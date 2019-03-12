using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace ReadAndWriteBinaryFile
{
    public partial class Form1 : Form
    {
        //默认文件存放位置是该项目的Debug目录下
        private String TextFileName = "TextSample.txt";
        private String TextFileName1 = "TextSample.txt";
        private String TextFileName2 = "TextSample.txt";
        private String localFilePath = "";
        //给出文件存放的绝对路径
        public Form1()
        {
            InitializeComponent();
        }
        private void ReadFileBtn_Click(object sender, EventArgs e)
        { 
            TextFileName = textBox2.Text.Trim();
            string allLine = null;
            if (!File.Exists(TextFileName))
            {               
                MessageBox.Show(TextFileName + "文件不存在！");// 如果文件不存在，那么提示无法读取！
                return;
            }
            allLine = ShpFunction.ShowString(TextFileName);
            ShowTxt.Text = allLine;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            TextFileName = localFilePath;
            string allLine = null;            
            if (!File.Exists(TextFileName))// 首先判断，文件是否已经存在
            {             
                MessageBox.Show(TextFileName + "文件不存在！"); // 如果文件不存在，那么提示无法读取！
                return;
            }
            allLine = ShpFunction.ShowString(TextFileName);
            textBox1.Text = allLine;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "SHP文件|*.shp";
            if (dialog.ShowDialog() == DialogResult.OK)
            {               
                textBox2.Text = dialog.FileName;     
            }
            dialog.Dispose();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            TextFileName = textBox2.Text.Trim();
            TextFileName1 = textBox3.Text.Trim();          
            SaveFileDialog sfd = new SaveFileDialog(); //string localFilePath, fileNameExt, newFileName, FilePath;            
            sfd.Filter = "Shp文件|*.shp";//设置文件类型            
            sfd.FilterIndex = 1;//设置默认文件类型显示顺序            
            sfd.RestoreDirectory = true;//保存对话框是否记忆上次打开的目录            
            if (sfd.ShowDialog() == DialogResult.OK) //点了保存按钮进入
            {
                localFilePath = sfd.FileName.ToString(); //获得文件路径 
                string fileNameExt = localFilePath.Substring(localFilePath.LastIndexOf("\\") + 1); //获取文件名，不带路径
            }
            
            TextFileName2 = localFilePath;          
            if (!File.Exists(TextFileName)&& !File.Exists(TextFileName1)) // 首先判断，文件是否已经存在
            {               
                MessageBox.Show(TextFileName + "文件不存在！");// 如果文件不存在，那么提示无法读取！
                return;
            }
            ShpFunction.MergeShp(TextFileName, TextFileName1, TextFileName2);
            MessageBox.Show("合并成功！");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "SHP文件|*.shp";
            if (dialog.ShowDialog() == DialogResult.OK)
            {              
                textBox3.Text = dialog.FileName;
            }
            dialog.Dispose();
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
        }
        private void ShowTxt_TextChanged(object sender, EventArgs e)
        {
        }
        private void button5_Click(object sender, EventArgs e)
        {
            TextFileName = textBox3.Text.Trim();
            string allLine = null;           
            if (!File.Exists(TextFileName))// 首先判断，文件是否已经存在
            {            
                MessageBox.Show(TextFileName + "文件不存在！"); // 如果文件不存在，那么提示无法读取！
                return;
            }
            allLine = ShpFunction.ShowString(TextFileName);
            textBox4.Text = allLine;
        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
        }
       private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string foldPath = "";
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "请选择文件路径";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                foldPath = dialog.SelectedPath;
                MessageBox.Show("已选择文件夹:" + foldPath, "选择文件夹提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }//获取文件夹名字

            string[] filenames = Directory.GetFiles(foldPath);  //获取该文件夹下面的所有文件名

            SaveFileDialog sfd = new SaveFileDialog(); //string localFilePath, fileNameExt, newFileName, FilePath;            
            sfd.Filter = "Shp文件|*.shp";//设置文件类型            
            sfd.FilterIndex = 1;//设置默认文件类型显示顺序            
            sfd.RestoreDirectory = true;//保存对话框是否记忆上次打开的目录            
            if (sfd.ShowDialog() == DialogResult.OK) //点了保存按钮进入
            {
                localFilePath = sfd.FileName.ToString(); //获得文件路径 
                string fileNameExt = localFilePath.Substring(localFilePath.LastIndexOf("\\") + 1); //获取文件名，不带路径
            }
            TextFileName2 = localFilePath;
            TextFileName1 = "d:\\hhhh.shp";
            string temp = "";
            for (int i = 0; i < filenames.Length; i++)
            {
                File.Delete(TextFileName2);
                ShpFunction.MergeShp(filenames[i],TextFileName1, TextFileName2);
                temp = TextFileName1;
                TextFileName1 = TextFileName2;
                TextFileName2 = temp;               
            }
        }
    }
}

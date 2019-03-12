using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace ReadTxtFile
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
             String TextFileName="TextSample.txt" ;
             StreamWriter  streamWriter = new StreamWriter(TextFileName, false, Encoding.UTF8);
             streamWriter.WriteLine("第一行：你好！");
             streamWriter.WriteLine("第二行：谢谢！");
             streamWriter.WriteLine("第三行：再见！");
             streamWriter.Close();
             streamWriter = null;
             MessageBox.Show("写入文件成功！");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String TextFileName = "TextSample.txt";
            FileStream fileStream = new FileStream(TextFileName, FileMode.Open, FileAccess.Read, FileShare.None);
            StreamReader streamReader = new StreamReader(fileStream, Encoding.UTF8);
            string allLine = streamReader.ReadToEnd();
            textBox1.Text = allLine;
            fileStream.Close();
            streamReader.Close();
        }
    }
}

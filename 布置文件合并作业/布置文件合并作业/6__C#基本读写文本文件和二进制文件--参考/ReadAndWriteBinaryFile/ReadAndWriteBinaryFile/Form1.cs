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
        private const String TextFileName = "TextSample.txt";

        //给出文件存放的绝对路径
        //private const String TextFileName = "D:\\TextSample.txt";
        // private const String TextFileName = @"D:\TextSample.txt";
        public Form1()
        {
            InitializeComponent();
        }

        private void WriteFileBtn_Click(object sender, EventArgs e)
        {
            FileStream fileStream = null;
            BinaryWriter binaryWriter = null;

            try
            {// 首先判断，文件是否已经存在
                if (File.Exists(TextFileName))
                {
                    File.Delete(TextFileName);// 如果文件已经存在，那么删除掉.
                }
                fileStream = new FileStream(TextFileName, FileMode.Create, FileAccess.Write, FileShare.None);
                binaryWriter = new BinaryWriter(fileStream);
                for (int i = 0; i <= 20; i++)  //写入0---20
                {
                    binaryWriter.Write(i);
                }
                binaryWriter.Write('A');
                binaryWriter.Write('B');
                binaryWriter.Write('C');
                binaryWriter.Write('D');
                binaryWriter.Write(1000);//小端格式写入1000

                //大端格式写入1000；
                byte[] bytesWriteFile;
                bytesWriteFile = BitConverter.GetBytes(1000);
                Array.Reverse(bytesWriteFile);
                binaryWriter.Write(bytesWriteFile, 0, bytesWriteFile.Length);

                binaryWriter.Close();
                fileStream.Close();
                binaryWriter = null;
                fileStream = null;
                MessageBox.Show("成功写入文件！");
            }
            catch (Exception ex)
            {
                Console.WriteLine("在写入文件的过程中，发生了异常！");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            finally
            {
                if (fileStream != null)
                {
                    try
                    {
                        fileStream.Close();
                    }
                    catch
                    {
                        // 最后关闭文件，无视关闭是否会发生错误了.
                    }
                }
            }
        }

        private void ReadFileBtn_Click(object sender, EventArgs e)
        {
            BinaryReader binaryReader = null;
            FileStream fileStream = null;
            // 首先判断，文件是否已经存在
            if (!File.Exists(TextFileName))
            {
                // 如果文件不存在，那么提示无法读取！
                MessageBox.Show(TextFileName + "文件不存在！");
                return;
            }
            try
            {
                fileStream = new FileStream(TextFileName, FileMode.Open, FileAccess.Read, FileShare.None);
                binaryReader = new BinaryReader(fileStream);
                string allLine = "我们写入的20个整数是:\r\n";
                for (int i = 0; i <= 20; i++)
                {
                    allLine = allLine + binaryReader.ReadInt32() + "   ";
                }
                allLine = allLine + "\r\n我们写入的4个字母为：\r\n";
                //allLine = allLine + binaryReader.ReadChar() + "  ";
                //allLine = allLine + binaryReader.ReadChar() + "  ";
                //allLine = allLine + binaryReader.ReadChar() + "  ";
                //allLine = allLine + binaryReader.ReadChar() + "  ";


                //上面四句用下面这句替换可以吗？
                // allLine = allLine + binaryReader.ReadChars(4);//返回是数组地址
                //char[] charArray = binaryReader.ReadChars(4);
                //allLine = allLine + charArray[0] +"  "+ charArray[1] +"  "+ charArray[2] +"  "+ charArray[3];

                allLine = allLine + "\r\n区别大小端格式写入：\r\n";
                allLine = allLine + binaryReader.ReadInt32() + "   ";//小端格式读出1000

                //大端格式读出1000
                byte[] bytes = new byte[4];
                bytes = binaryReader.ReadBytes(4);
                Array.Reverse(bytes);
                allLine = allLine + BitConverter.ToInt32(bytes, 0);
                binaryReader.Close();
                fileStream.Close();
                binaryReader = null;
                fileStream = null;
                ShowTxt.Text = allLine;
            }
            catch (Exception ex)
            {
                Console.WriteLine("在读取文件的过程中，发生了异常！");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            finally
            {
                if (fileStream != null)
                {
                    try
                    {
                        fileStream.Close();
                    }
                    catch
                    {
                        // 最后关闭文件，无视关闭是否会发生错误了.
                    }
                }
            }
        }
    }
}

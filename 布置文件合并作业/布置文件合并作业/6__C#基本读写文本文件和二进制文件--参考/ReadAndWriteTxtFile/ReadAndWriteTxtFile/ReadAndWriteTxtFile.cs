using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace ReadAndWriteTxtFile
{
    public partial class ReadAndWriteTxtFile : Form
    {
        //默认文件存放位置是该项目的Debug目录下
        private const String TextFileName = "TextSample.txt";
        //给出文件存放的绝对路径
        // private const String TextFileName = "D:\\TextSample.txt";
        // private const String TextFileName = @"D:\TextSample.txt";

        public ReadAndWriteTxtFile()
        {
            InitializeComponent();
        }

        private void WriteFileBtn_Click(object sender, EventArgs e)
        {
            StreamWriter streamWriter = null;
            try
            { // 首先判断，文件是否已经存在
                if (File.Exists(TextFileName))
                {// 如果文件已经存在，那么删除掉.
                    File.Delete(TextFileName);
                }
                streamWriter = new StreamWriter(TextFileName, false, Encoding.UTF8);
                // 写入测试数据.
                streamWriter.WriteLine("hahahhhhaha1");
                streamWriter.WriteLine("来点中文！！！！");
                streamWriter.WriteLine("没有问题了吧！！！");
                // 关闭文件.
                streamWriter.Close();
                streamWriter = null;
                MessageBox.Show("文件写入成功！！！");
            }
            catch (Exception ex)
            {
                Console.WriteLine("在写入文件的过程中，发生了异常！");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            finally
            {
                if (streamWriter != null)
                {
                    try
                    {
                        streamWriter.Close();
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
            FileStream fileStream = null;
            StreamReader streamReader = null;
            // 首先判断，文件是否已经存在
            if (!File.Exists(TextFileName))
            {
                // 如果文件不存在，那么提示无法读取！
                MessageBox.Show(TextFileName + "文件不存在！");
                return;
            }
            try
            {
                // 注意：这里使用了与上面相同的编码 UTF-8
                fileStream = new FileStream(TextFileName, FileMode.Open, FileAccess.Read, FileShare.None);
                streamReader = new StreamReader(fileStream, Encoding.UTF8);
                string allLine = streamReader.ReadToEnd();

                ////采取另外一种方法来读取
                //string allLine = null;
                //String line = null;//用于暂存文本文件数据的行.
                //int lineNo = 0;// 用于暂存行号.
                //do
                //{
                //    line = streamReader.ReadLine();// 一次读取一行数据.
                //    lineNo++;// 行号递增.
                //    if (line != null)
                //    {
                //        allLine = allLine + "第"+lineNo + "行 " + line + "\r\n";
                //    }
                //} while (line != null);

                streamReader.Close();
                fileStream.Close();
                streamReader = null;
                ShowTxt.Text = "";
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

        private void WriteAppendFileBtn_Click(object sender, EventArgs e)
        {
            StreamWriter streamWriter = null;
            try
            { // 首先判断，文件是否已经存在
                if (File.Exists(TextFileName))
                {// 如果文件已经存在
                    streamWriter = new StreamWriter(TextFileName, true, Encoding.UTF8);
                }
                else
                {
                    streamWriter = new StreamWriter(TextFileName, false, Encoding.UTF8);
                }
                // 写入测试数据.
                streamWriter.Write(ShowTxt.Text.Trim());

                // 关闭文件.
                streamWriter.Close();
                streamWriter = null;
                MessageBox.Show("追加写入文件成功！！！");
            }
            catch (Exception ex)
            {
                Console.WriteLine("在追加写入文件的过程中，发生了异常！");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            finally
            {
                if (streamWriter != null)
                {
                    try
                    {
                        streamWriter.Close();
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

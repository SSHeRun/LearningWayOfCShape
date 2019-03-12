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
        //给出文件存放的绝对路径
        //private const String TextFileName = "D:\\TextSample.txt";
        // private const String TextFileName = @"D:\TextSample.txt";
        public Form1()
        {
            InitializeComponent();
        }

        private void WriteFileBtn_Click(object sender, EventArgs e)
        {
            FileStream fileStream2 = null;
            BinaryWriter binaryWriter = null;

            try
            {// 首先判断，文件是否已经存在
                if (File.Exists(TextFileName2))
                {
                    File.Delete(TextFileName2);// 如果文件已经存在，那么删除掉.
                }
                fileStream2 = new FileStream(TextFileName2, FileMode.Create, FileAccess.Write, FileShare.None);
                binaryWriter = new BinaryWriter(fileStream2);

                //大端格式写入1000；
                byte[] bytesWriteFile;
                bytesWriteFile = BitConverter.GetBytes(1000);
                Array.Reverse(bytesWriteFile);
                binaryWriter.Write(bytesWriteFile, 0, bytesWriteFile.Length);

                binaryWriter.Close();
                fileStream2.Close();
                binaryWriter = null;
                fileStream2 = null;
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
                if (fileStream2 != null)
                {
                    try
                    {
                        fileStream2.Close();
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
            TextFileName = textBox2.Text.Trim();
          
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
                string allLine = null;

                Int32 fileCode;
                Int32 unUse1;
                Int32 unUse2;
                Int32 unUse3;
                Int32 unUse4;
                Int32 unUse5;
                Int32 fileLength;
                Int32 fileVersion;
                Int32 shapeType;
                Double xMin;
                Double yMin;
                Double xMax;
                Double yMax;
                Double zMin;
                Double zMax;
                Double mMin;
                Double mMax;

                Int32 recordNo;
                Int32 recordLength;
                byte[] recordContent;

                //大端格式读出1000
                byte[] bytes = new byte[4];
                bytes = binaryReader.ReadBytes(4);
                Array.Reverse(bytes);
                fileCode = BitConverter.ToInt32(bytes, 0);

                unUse1 = binaryReader.ReadInt32();
                unUse2 = binaryReader.ReadInt32();
                unUse3 = binaryReader.ReadInt32();
                unUse4 = binaryReader.ReadInt32();
                unUse5 = binaryReader.ReadInt32();

                //大端格式读出文件长度
                bytes = binaryReader.ReadBytes(4);
                Array.Reverse(bytes);
                fileLength = BitConverter.ToInt32(bytes, 0);

                fileVersion = binaryReader.ReadInt32();
                shapeType = binaryReader.ReadInt32();
                xMin = binaryReader.ReadDouble();
                yMin = binaryReader.ReadDouble();
                xMax = binaryReader.ReadDouble();
                yMax = binaryReader.ReadDouble();
                zMin = binaryReader.ReadDouble();
                zMax = binaryReader.ReadDouble();
                mMin = binaryReader.ReadDouble();
                mMax = binaryReader.ReadDouble();


                //写入新文件
                TextFileName2 = "d:\\hhhh.shp";
                FileStream fileStream2 = null;
                BinaryWriter binaryWriter = null;


                // 首先判断，文件是否已经存在
                if (File.Exists(TextFileName2))
                {
                    File.Delete(TextFileName2);// 如果文件已经存在，那么删除掉.
                }
                fileStream2 = new FileStream(TextFileName2, FileMode.Create, FileAccess.Write, FileShare.None);
                binaryWriter = new BinaryWriter(fileStream2);

                //大端格式写入fileCode；
                byte[] bytesWriteFile;
                bytesWriteFile = BitConverter.GetBytes(fileCode);
                Array.Reverse(bytesWriteFile);
                binaryWriter.Write(bytesWriteFile, 0, bytesWriteFile.Length);

                binaryWriter.Write(unUse1);
                binaryWriter.Write(unUse2);
                binaryWriter.Write(unUse3);
                binaryWriter.Write(unUse4);
                binaryWriter.Write(unUse5);

                bytesWriteFile = BitConverter.GetBytes(fileLength);
                Array.Reverse(bytesWriteFile);
                binaryWriter.Write(bytesWriteFile, 0, bytesWriteFile.Length);

                binaryWriter.Write(fileVersion);
                binaryWriter.Write(shapeType);

                binaryWriter.Write(xMin);
                binaryWriter.Write(yMin);
                binaryWriter.Write(xMax);
                binaryWriter.Write(yMax);
                binaryWriter.Write(zMin);
                binaryWriter.Write(zMax);
                binaryWriter.Write(mMin);
                binaryWriter.Write(mMax);

                // MessageBox.Show("成功写入文件！");


                allLine = allLine + "文件的filecode：" + fileCode + "\r\n";
                allLine = allLine + "unUse1：" + unUse1 + "\r\n";
                allLine = allLine + "unUse2：" + unUse2 + "\r\n";
                allLine = allLine + "unUse3：" + unUse3 + "\r\n";
                allLine = allLine + "unUse4：" + unUse4 + "\r\n";
                allLine = allLine + "unUse5：" + unUse5 + "\r\n";
                allLine = allLine + "fileLength：" + fileLength + "字节\r\n";
                allLine = allLine + "fileVersion：" + fileVersion + "\r\n";
                allLine = allLine + "shapeType：" + shapeType + "\r\n";
                allLine = allLine + "xMin：" + xMin + "\r\n";
                allLine = allLine + "yMin：" + yMin + "\r\n";
                allLine = allLine + "xMax：" + xMax + "\r\n";
                allLine = allLine + "yMax：" + yMax + "\r\n";
                allLine = allLine + "zMin：" + zMin + "\r\n";
                allLine = allLine + "zMax：" + zMax + "\r\n";
                allLine = allLine + "mMin：" + mMin + "\r\n";
                allLine = allLine + "mMax：" + mMax + "\r\n";

                //大端格式读出记录编号，长度
                while (binaryReader.BaseStream.Position < binaryReader.BaseStream.Length)
                {
                    bytes = binaryReader.ReadBytes(4);
                    Array.Reverse(bytes);
                    recordNo = BitConverter.ToInt32(bytes, 0);
                    bytes = binaryReader.ReadBytes(4);
                    Array.Reverse(bytes);
                    recordLength = BitConverter.ToInt32(bytes, 0);
                    recordContent=binaryReader.ReadBytes(recordLength * 2);
                    allLine = allLine + "记录编号：" + recordNo + "\r\n";
                    allLine = allLine + "记录长度：" + recordLength + "\r\n";

                    //大端格式写入
                    bytesWriteFile = BitConverter.GetBytes(recordNo);
                    Array.Reverse(bytesWriteFile);
                    binaryWriter.Write(bytesWriteFile, 0, bytesWriteFile.Length);
                    bytesWriteFile = BitConverter.GetBytes(recordLength);
                    Array.Reverse(bytesWriteFile);
                    binaryWriter.Write(bytesWriteFile, 0, bytesWriteFile.Length);
                    binaryWriter.Write(recordContent);


                }

                ShowTxt.Text = allLine;
                binaryReader.Close();
                fileStream.Close();
                binaryReader = null;
                fileStream = null;

                binaryWriter.Close();
                fileStream2.Close();
                binaryWriter = null;
                fileStream2 = null;

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

        private void button1_Click(object sender, EventArgs e)
        {
            TextFileName = "d:\\hhhh.shp";
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
                string allLine = null;

                Int32 fileCode;
                Int32 unUse1;
                Int32 unUse2;
                Int32 unUse3;
                Int32 unUse4;
                Int32 unUse5;
                Int32 fileLength;
                Int32 fileVersion;
                Int32 shapeType;
                Double xMin;
                Double yMin;
                Double xMax;
                Double yMax;
                Double zMin;
                Double zMax;
                Double mMin;
                Double mMax;

                Int32 recordNo;
                Int32 recordLength;
                byte[] recordContent;

                //大端格式读出1000
                byte[] bytes = new byte[4];
                bytes = binaryReader.ReadBytes(4);
                Array.Reverse(bytes);
                fileCode = BitConverter.ToInt32(bytes, 0);

                unUse1 = binaryReader.ReadInt32();
                unUse2 = binaryReader.ReadInt32();
                unUse3 = binaryReader.ReadInt32();
                unUse4 = binaryReader.ReadInt32();
                unUse5 = binaryReader.ReadInt32();

                //大端格式读出文件长度
                bytes = binaryReader.ReadBytes(4);
                Array.Reverse(bytes);
                fileLength = BitConverter.ToInt32(bytes, 0);

                fileVersion = binaryReader.ReadInt32();
                shapeType = binaryReader.ReadInt32();
                xMin = binaryReader.ReadDouble();
                yMin = binaryReader.ReadDouble();
                xMax = binaryReader.ReadDouble();
                yMax = binaryReader.ReadDouble();
                zMin = binaryReader.ReadDouble();
                zMax = binaryReader.ReadDouble();
                mMin = binaryReader.ReadDouble();
                mMax = binaryReader.ReadDouble();


                allLine = allLine + "文件的filecode：" + fileCode + "\r\n";
                allLine = allLine + "unUse1：" + unUse1 + "\r\n";
                allLine = allLine + "unUse2：" + unUse2 + "\r\n";
                allLine = allLine + "unUse3：" + unUse3 + "\r\n";
                allLine = allLine + "unUse4：" + unUse4 + "\r\n";
                allLine = allLine + "unUse5：" + unUse5 + "\r\n";
                allLine = allLine + "fileLength：" + fileLength + "字节\r\n";
                allLine = allLine + "fileVersion：" + fileVersion + "\r\n";
                allLine = allLine + "shapeType：" + shapeType + "\r\n";
                allLine = allLine + "xMin：" + xMin + "\r\n";
                allLine = allLine + "yMin：" + yMin + "\r\n";
                allLine = allLine + "xMax：" + xMax + "\r\n";
                allLine = allLine + "yMax：" + yMax + "\r\n";
                allLine = allLine + "zMin：" + zMin + "\r\n";
                allLine = allLine + "zMax：" + zMax + "\r\n";
                allLine = allLine + "mMin：" + mMin + "\r\n";
                allLine = allLine + "mMax：" + mMax + "\r\n";

                //大端格式读出记录编号，长度
                while (binaryReader.BaseStream.Position < binaryReader.BaseStream.Length)
                {
                    bytes = binaryReader.ReadBytes(4);
                    Array.Reverse(bytes);
                    recordNo = BitConverter.ToInt32(bytes, 0);
                    bytes = binaryReader.ReadBytes(4);
                    Array.Reverse(bytes);
                    recordLength = BitConverter.ToInt32(bytes, 0);
                    binaryReader.ReadBytes(recordLength * 2);
                    allLine = allLine + "记录编号：" + recordNo + "\r\n";
                    allLine = allLine + "记录长度：" + recordLength + "\r\n";
                }



                textBox1.Text = allLine;


                binaryReader.Close();
                fileStream.Close();
                binaryReader = null;
                fileStream = null;

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

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                // ShpFilePath.Text = dialog.FileName;
                textBox2.Text = dialog.FileName;
               
            }
            dialog.Dispose();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TextFileName = textBox2.Text.Trim();
            TextFileName1 = textBox3.Text.Trim();

            BinaryReader binaryReader = null;
            BinaryReader binaryReader1 = null;
            FileStream fileStream = null;
            FileStream fileStream1 = null;
            // 首先判断，文件是否已经存在
            if (!File.Exists(TextFileName)&& !File.Exists(TextFileName1))
            {
                // 如果文件不存在，那么提示无法读取！
                MessageBox.Show(TextFileName + "文件不存在！");
                return;
            }
            try
            {
                fileStream = new FileStream(TextFileName, FileMode.Open, FileAccess.Read, FileShare.None);
                binaryReader = new BinaryReader(fileStream);
                string allLine = null;
              
                Int32 fileCode;
                Int32 unUse1;
                Int32 unUse2;
                Int32 unUse3;
                Int32 unUse4;
                Int32 unUse5;
                Int32 fileLength;
                Int32 fileVersion;
                Int32 shapeType;
                Double xMin;
                Double yMin;
                Double xMax;
                Double yMax;
                Double zMin;
                Double zMax;
                Double mMin;
                Double mMax;

                Int32 recordNo;
                Int32 recordLength;
                byte[] recordContent;

                //大端格式读出1000
                byte[] bytes = new byte[4];
                bytes = binaryReader.ReadBytes(4);
                Array.Reverse(bytes);
                fileCode = BitConverter.ToInt32(bytes, 0);

                unUse1 = binaryReader.ReadInt32();
                unUse2 = binaryReader.ReadInt32();
                unUse3 = binaryReader.ReadInt32();
                unUse4 = binaryReader.ReadInt32();
                unUse5 = binaryReader.ReadInt32();

                //大端格式读出文件长度
                bytes = binaryReader.ReadBytes(4);
                Array.Reverse(bytes);
                fileLength = BitConverter.ToInt32(bytes, 0);

                fileVersion = binaryReader.ReadInt32();
                shapeType = binaryReader.ReadInt32();
                xMin = binaryReader.ReadDouble();
                yMin = binaryReader.ReadDouble();
                xMax = binaryReader.ReadDouble();
                yMax = binaryReader.ReadDouble();
                zMin = binaryReader.ReadDouble();
                zMax = binaryReader.ReadDouble();
                mMin = binaryReader.ReadDouble();
                mMax = binaryReader.ReadDouble();

                fileStream1 = new FileStream(TextFileName1, FileMode.Open, FileAccess.Read, FileShare.None);
                binaryReader1 = new BinaryReader(fileStream1);

                Int32 fileCode1;
                Int32 unUse11;
                Int32 unUse21;
                Int32 unUse31;
                Int32 unUse41;
                Int32 unUse51;
                Int32 fileLength1;
                Int32 fileVersion1;
                Int32 shapeType1;
                Double xMin1;
                Double yMin1;
                Double xMax1;
                Double yMax1;
                Double zMin1;
                Double zMax1;
                Double mMin1;
                Double mMax1;

                Int32 recordNo1;
                Int32 recordLength1;
                byte[] recordContent1;

                //大端格式读出1000
             
                bytes = binaryReader1.ReadBytes(4);
                Array.Reverse(bytes);
                fileCode = BitConverter.ToInt32(bytes, 0);

                unUse11 = binaryReader1.ReadInt32();
                unUse21 = binaryReader1.ReadInt32();
                unUse31 = binaryReader1.ReadInt32();
                unUse41 = binaryReader1.ReadInt32();
                unUse51 = binaryReader1.ReadInt32();

                //大端格式读出文件长度
                bytes = binaryReader1.ReadBytes(4);
                Array.Reverse(bytes);
                fileLength1 = BitConverter.ToInt32(bytes, 0);

                fileVersion1 = binaryReader1.ReadInt32();
                shapeType1 = binaryReader1.ReadInt32();
                xMin1 = binaryReader1.ReadDouble();
                yMin1 = binaryReader1.ReadDouble();
                xMax1 = binaryReader1.ReadDouble();
                yMax1 = binaryReader1.ReadDouble();
                zMin1 = binaryReader1.ReadDouble();
                zMax1 = binaryReader1.ReadDouble();
                mMin1 = binaryReader1.ReadDouble();
                mMax1 = binaryReader1.ReadDouble();

                //写入新文件
                TextFileName2 = "d:\\hhhh.shp";
                FileStream fileStream2 = null;
                BinaryWriter binaryWriter = null;


                // 首先判断，文件是否已经存在
                if (File.Exists(TextFileName2))
                {
                    File.Delete(TextFileName2);// 如果文件已经存在，那么删除掉.
                }
                fileStream2 = new FileStream(TextFileName2, FileMode.Create, FileAccess.Write, FileShare.None);
                binaryWriter = new BinaryWriter(fileStream2);

                //大端格式写入fileCode；
                byte[] bytesWriteFile;
                bytesWriteFile = BitConverter.GetBytes(fileCode);
                Array.Reverse(bytesWriteFile);
                binaryWriter.Write(bytesWriteFile, 0, bytesWriteFile.Length);

                binaryWriter.Write(unUse1);
                binaryWriter.Write(unUse2);
                binaryWriter.Write(unUse3);
                binaryWriter.Write(unUse4);
                binaryWriter.Write(unUse5);

                bytesWriteFile = BitConverter.GetBytes(fileLength+ fileLength1-50);
                Array.Reverse(bytesWriteFile);
                binaryWriter.Write(bytesWriteFile, 0, bytesWriteFile.Length);

                binaryWriter.Write(fileVersion);

                binaryWriter.Write(shapeType);

                if (xMin < xMin1)
                { binaryWriter.Write(xMin); }
                else
                { binaryWriter.Write(xMin1); }
                if (yMin < yMin1)
                { binaryWriter.Write(yMin); }
                else
                { binaryWriter.Write(yMin1); }
                if (xMax < xMax1)
                { binaryWriter.Write(xMax1); }
                else
                { binaryWriter.Write(xMax); }
                if (yMax < yMax1)
                { binaryWriter.Write(yMax1); }
                else
                { binaryWriter.Write(yMax); }
                if (zMin < zMin1)
                { binaryWriter.Write(zMin); }
                else
                { binaryWriter.Write(zMin1); }
                if (zMax < zMax1)
                { binaryWriter.Write(zMax1); }
                else
                { binaryWriter.Write(zMax); }
                if (mMin < mMin1)
                { binaryWriter.Write(mMin); }
                else
                { binaryWriter.Write(mMin1); }
                if (mMax < mMax1)
                { binaryWriter.Write(mMax1); }
                else
                { binaryWriter.Write(mMax); }

                // MessageBox.Show("成功写入文件！");


                  allLine = allLine + "文件的filecode：" + fileCode + "\r\n";
                   allLine = allLine + "unUse1：" + unUse1 + "\r\n";
                   allLine = allLine + "unUse2：" + unUse2 + "\r\n";
                   allLine = allLine + "unUse3：" + unUse3 + "\r\n";
                   allLine = allLine + "unUse4：" + unUse4 + "\r\n";
                   allLine = allLine + "unUse5：" + unUse5 + "\r\n";
                   allLine = allLine + "fileLength：" + fileLength + "字节\r\n";
                   allLine = allLine + "fileVersion：" + fileVersion + "\r\n";
                   allLine = allLine + "shapeType：" + shapeType + "\r\n";
                   allLine = allLine + "xMin：" + xMin + "\r\n";
                   allLine = allLine + "yMin：" + yMin + "\r\n";
                   allLine = allLine + "xMax：" + xMax + "\r\n";
                   allLine = allLine + "yMax：" + yMax + "\r\n";
                   allLine = allLine + "zMin：" + zMin + "\r\n";
                   allLine = allLine + "zMax：" + zMax + "\r\n";
                   allLine = allLine + "mMin：" + mMin + "\r\n";
                   allLine = allLine + "mMax：" + mMax + "\r\n";

                //大端格式读出记录编号，长度
                int k = 0;
                while (binaryReader.BaseStream.Position < binaryReader.BaseStream.Length)
                {
                    bytes = binaryReader.ReadBytes(4);
                    Array.Reverse(bytes);
                    recordNo = BitConverter.ToInt32(bytes, 0);
                    bytes = binaryReader.ReadBytes(4);
                    Array.Reverse(bytes);
                    recordLength = BitConverter.ToInt32(bytes, 0);
                    recordContent = binaryReader.ReadBytes(recordLength * 2);
                    allLine = allLine + "记录编号：" + recordNo + "\r\n";
                    allLine = allLine + "记录长度：" + recordLength + "\r\n";
                    k = recordNo;

                    //大端格式写入
                    bytesWriteFile = BitConverter.GetBytes(recordNo);
                    Array.Reverse(bytesWriteFile);
                    binaryWriter.Write(bytesWriteFile, 0, bytesWriteFile.Length);
                    bytesWriteFile = BitConverter.GetBytes(recordLength);
                    Array.Reverse(bytesWriteFile);
                    binaryWriter.Write(bytesWriteFile, 0, bytesWriteFile.Length);
                    binaryWriter.Write(recordContent);
                    recordNo = BitConverter.ToInt32(bytes, 0);
                    
                }
                
                while (binaryReader1.BaseStream.Position < binaryReader1.BaseStream.Length)
                {
                    bytes = binaryReader1.ReadBytes(4);
                    Array.Reverse(bytes);
                    recordNo1 = BitConverter.ToInt32(bytes, 0)+k;
                    bytes = binaryReader1.ReadBytes(4);
                    Array.Reverse(bytes);
                    recordLength1 = BitConverter.ToInt32(bytes, 0);
                    recordContent1 = binaryReader1.ReadBytes(recordLength1 * 2);
                    allLine = allLine + "记录编号：" + recordNo1 + "\r\n";
                    allLine = allLine + "记录长度：" + recordLength1 + "\r\n";

                    //大端格式写入
                    bytesWriteFile = BitConverter.GetBytes(recordNo1);
                    Array.Reverse(bytesWriteFile);
                    binaryWriter.Write(bytesWriteFile, 0, bytesWriteFile.Length);
                    bytesWriteFile = BitConverter.GetBytes(recordLength1);
                    Array.Reverse(bytesWriteFile);
                    binaryWriter.Write(bytesWriteFile, 0, bytesWriteFile.Length);
                    binaryWriter.Write(recordContent1);
                }
                
                /*
                while (binaryReader.BaseStream.Position < binaryReader.BaseStream.Length|| binaryReader.BaseStream.Position < binaryReader.BaseStream.Length)
                {
                    bytes = binaryReader.ReadBytes(4);
                    Array.Reverse(bytes);
                    recordNo = BitConverter.ToInt32(bytes, 0);
                    bytes = binaryReader.ReadBytes(4);
                    Array.Reverse(bytes);
                    recordLength = BitConverter.ToInt32(bytes, 0);
                    recordContent = binaryReader.ReadBytes(recordLength * 2);
                    allLine = allLine + "记录编号：" + recordNo + "\r\n";
                    allLine = allLine + "记录长度：" + recordLength + "\r\n";

                    //大端格式写入
                    bytesWriteFile = BitConverter.GetBytes(recordNo);
                    Array.Reverse(bytesWriteFile);
                    binaryWriter.Write(bytesWriteFile, 0, bytesWriteFile.Length);
                    bytesWriteFile = BitConverter.GetBytes(recordLength);
                    Array.Reverse(bytesWriteFile);
                    binaryWriter.Write(bytesWriteFile, 0, bytesWriteFile.Length);
                    binaryWriter.Write(recordContent);

                    bytes = binaryReader1.ReadBytes(4);
                    Array.Reverse(bytes);
                    recordNo1 = BitConverter.ToInt32(bytes, 0)+ recordNo;
                    bytes = binaryReader1.ReadBytes(4);
                    Array.Reverse(bytes);
                    recordLength1 = BitConverter.ToInt32(bytes, 0);
                    recordContent1 = binaryReader1.ReadBytes(recordLength1 * 2);
                    allLine = allLine + "记录编号：" + recordNo1 + "\r\n";
                    allLine = allLine + "记录长度：" + recordLength1 + "\r\n";

                    //大端格式写入
                    bytesWriteFile = BitConverter.GetBytes(recordNo1);
                    Array.Reverse(bytesWriteFile);
                    binaryWriter.Write(bytesWriteFile, 0, bytesWriteFile.Length);
                    bytesWriteFile = BitConverter.GetBytes(recordLength1);
                    Array.Reverse(bytesWriteFile);
                    binaryWriter.Write(bytesWriteFile, 0, bytesWriteFile.Length);
                    binaryWriter.Write(recordContent1);

                }
                */
                ShowTxt.Text = allLine;
                binaryReader.Close();
                binaryReader1.Close();
                fileStream.Close();
                fileStream1.Close();
                binaryReader = null;
                binaryReader1 = null;
                fileStream = null;
                fileStream1 = null;

                binaryWriter.Close();
                fileStream2.Close();
                binaryWriter = null;
                fileStream2 = null;

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

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                // ShpFilePath.Text = dialog.FileName;
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
    }
}

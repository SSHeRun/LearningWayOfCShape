using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ReadAndWriteBinaryFile
{
    class ShpHeader//定义文件头
    {
      public   Int32 fileCode;
      public   Int32 unUse1;
      public   Int32 unUse2;
      public   Int32 unUse3;
      public   Int32 unUse4;
      public   Int32 unUse5;
      public   Int32 fileLength;
      public   Int32 fileVersion;
      public   Int32 shapeType;
      public   BoundingBox boundingBox;

    }

    class  BoundingBox//定义地图参数
    {
      public Double xMin;
      public Double yMin;
      public Double xMax;
      public Double yMax;
      public Double zMin;
      public Double zMax;
      public Double mMin;
      public Double mMax;
    }
    class ShpFileBody
    {
       public  Int32 recordNo;
       public  Int32 recordLength;
       public  byte[] recordContent;
    }

    class ShpFunction
    {

        public static void WriteInt32WithBigEnduim(BinaryWriter binaryWriter, Int32 write)
        {
            byte[] bytes = new byte[4];
            bytes = BitConverter.GetBytes(write);
            Array.Reverse(bytes);
            binaryWriter.Write(bytes, 0, bytes.Length);
        }
        public static Int32 ReadInt32WithBigEnduim(BinaryReader binaryReader)
        {
            Int32 num = 0;
            byte[] bytes = new byte[4];
            bytes = binaryReader.ReadBytes(4);
            Array.Reverse(bytes);
            num = BitConverter.ToInt32(bytes, 0);
            return num;

        }
        public static ShpHeader ReadShpHeader(BinaryReader binaryReader)
        {
            ShpHeader shpHeader = new ShpHeader();
            shpHeader.fileCode = ShpFunction.ReadInt32WithBigEnduim(binaryReader);
            shpHeader.unUse1 = ShpFunction.ReadInt32WithBigEnduim(binaryReader);
            shpHeader.unUse2 = ShpFunction.ReadInt32WithBigEnduim(binaryReader);
            shpHeader.unUse3 = ShpFunction.ReadInt32WithBigEnduim(binaryReader);
            shpHeader.unUse4 = ShpFunction.ReadInt32WithBigEnduim(binaryReader);
            shpHeader.unUse5 = ShpFunction.ReadInt32WithBigEnduim(binaryReader);
            shpHeader.fileLength = ShpFunction.ReadInt32WithBigEnduim(binaryReader);
            shpHeader.fileVersion = binaryReader.ReadInt32();
            shpHeader.shapeType = binaryReader.ReadInt32();
            shpHeader.boundingBox = ShpFunction.ReadBoundingBox(binaryReader);
            //读取逻辑
            return shpHeader;
        }
        public static BoundingBox ReadBoundingBox(BinaryReader binaryReader)
        {
            BoundingBox boundingBox = new BoundingBox();
            boundingBox.xMin = binaryReader.ReadDouble();
            boundingBox.yMin = binaryReader.ReadDouble();
            boundingBox.xMax = binaryReader.ReadDouble();
            boundingBox.yMax = binaryReader.ReadDouble();
            boundingBox.zMin = binaryReader.ReadDouble();
            boundingBox.zMax = binaryReader.ReadDouble();
            boundingBox.mMin = binaryReader.ReadDouble();
            boundingBox.mMax = binaryReader.ReadDouble();
            //读取boundingBox逻辑
            return boundingBox;
        }
        public static ShpFileBody ReadShpFileBody(BinaryReader binaryReader)
        {
            ShpFileBody shpBody = new ShpFileBody();
            shpBody.recordNo = ShpFunction.ReadInt32WithBigEnduim(binaryReader);
            shpBody.recordLength = ShpFunction.ReadInt32WithBigEnduim(binaryReader);
            shpBody.recordContent = binaryReader.ReadBytes(shpBody.recordLength * 2);
            //读取逻辑
            return shpBody;
        }
        public static void WriteShpHeader(BinaryWriter binaryWriter, ShpHeader shpHeader)
        {
            ShpFunction.WriteInt32WithBigEnduim(binaryWriter, shpHeader.fileCode);
            ShpFunction.WriteInt32WithBigEnduim(binaryWriter, shpHeader.unUse1);
            ShpFunction.WriteInt32WithBigEnduim(binaryWriter, shpHeader.unUse2);
            ShpFunction.WriteInt32WithBigEnduim(binaryWriter, shpHeader.unUse3);
            ShpFunction.WriteInt32WithBigEnduim(binaryWriter, shpHeader.unUse4);
            ShpFunction.WriteInt32WithBigEnduim(binaryWriter, shpHeader.unUse5);
            ShpFunction.WriteInt32WithBigEnduim(binaryWriter, shpHeader.fileLength);
            binaryWriter.Write(shpHeader.fileVersion);
            binaryWriter.Write(shpHeader.shapeType);
            ShpFunction.WriteBoundingBox(binaryWriter, shpHeader.boundingBox);
            //写header逻辑
        }
        public static void WriteBoundingBox(BinaryWriter binaryWriter, BoundingBox boundingBox)
        {
            binaryWriter.Write(boundingBox.xMin);
            binaryWriter.Write(boundingBox.yMin);
            binaryWriter.Write(boundingBox.xMax);
            binaryWriter.Write(boundingBox.yMax);
            binaryWriter.Write(boundingBox.zMin);
            binaryWriter.Write(boundingBox.zMax);
            binaryWriter.Write(boundingBox.mMin);
            binaryWriter.Write(boundingBox.mMax);
            //写BoundingBox逻辑
        }
        public static void WriteShpBody(BinaryWriter binaryWriter, ShpFileBody shpBody)
        {
            ShpFunction.WriteInt32WithBigEnduim(binaryWriter, shpBody.recordNo);
            ShpFunction.WriteInt32WithBigEnduim(binaryWriter, shpBody.recordLength);
            binaryWriter.Write(shpBody.recordContent);
            //写Body逻辑
        }
        //string
        public static string ShpHeader_to_String(ShpHeader shpHeader)
        {
            string allLine = "";
            allLine = allLine + "文件的filecode：" + shpHeader.fileCode + "\r\n";
            allLine = allLine + "unUse1：" + shpHeader.unUse1 + "\r\n";
            allLine = allLine + "unUse2：" + shpHeader.unUse2 + "\r\n";
            allLine = allLine + "unUse3：" + shpHeader.unUse3 + "\r\n";
            allLine = allLine + "unUse4：" + shpHeader.unUse4 + "\r\n";
            allLine = allLine + "unUse5：" + shpHeader.unUse5 + "\r\n";
            allLine = allLine + "fileLength：" + shpHeader.fileLength + "字节\r\n";
            allLine = allLine + "fileVersion：" + shpHeader.fileVersion + "\r\n";
            allLine = allLine + "shapeType：" + shpHeader.shapeType + "\r\n";
            allLine = allLine + "xMin：" + shpHeader.boundingBox.xMin + "\r\n";
            allLine = allLine + "yMin：" + shpHeader.boundingBox.yMin + "\r\n";
            allLine = allLine + "xMax：" + shpHeader.boundingBox.xMax + "\r\n";
            allLine = allLine + "yMax：" + shpHeader.boundingBox.yMax + "\r\n";
            allLine = allLine + "zMin：" + shpHeader.boundingBox.zMin + "\r\n";
            allLine = allLine + "zMax：" + shpHeader.boundingBox.zMax + "\r\n";
            allLine = allLine + "mMin：" + shpHeader.boundingBox.mMin + "\r\n";
            allLine = allLine + "mMax：" + shpHeader.boundingBox.mMax + "\r\n";
            return allLine;
        }
        public static string ShpBody_to_String( ShpFileBody shpBody)
        {
            string allLine = "";
            allLine = allLine + "记录编号：" + shpBody.recordNo + "\r\n";
            allLine = allLine + "记录长度：" + shpBody.recordLength + "\r\n";
            return allLine;
        }
        public static BoundingBox MergeBoundingBox(BoundingBox boundingBox1, BoundingBox boundingBox2)
        {
            BoundingBox newBoundingBox = new BoundingBox();
            newBoundingBox.xMin = (boundingBox1.xMin < boundingBox2.xMin) ? boundingBox1.xMin : boundingBox2.xMin;
            newBoundingBox.yMin = (boundingBox1.yMin < boundingBox2.yMin) ? boundingBox1.yMin : boundingBox2.yMin;
            newBoundingBox.xMax = (boundingBox1.xMax > boundingBox2.xMax) ? boundingBox1.xMax : boundingBox2.xMax;
            newBoundingBox.yMax = (boundingBox1.yMax > boundingBox2.yMax) ? boundingBox1.yMax : boundingBox2.yMax;
            newBoundingBox.zMin = (boundingBox1.zMin < boundingBox2.zMin) ? boundingBox1.zMin : boundingBox2.zMin;
            newBoundingBox.zMax = (boundingBox1.zMax > boundingBox2.zMax) ? boundingBox1.zMax : boundingBox2.zMax;
            newBoundingBox.mMin = (boundingBox1.mMin < boundingBox2.mMin) ? boundingBox1.mMin : boundingBox2.mMin;
            newBoundingBox.mMax = (boundingBox1.mMax > boundingBox2.mMax) ? boundingBox1.mMax : boundingBox2.mMax;

            //合并BoundingBox逻辑
            return newBoundingBox;
        }
        public static ShpHeader MergeShpHeader(ShpHeader shpHeader1, ShpHeader ShpHeader2)
        {
            ShpHeader newShpHeader = new ShpHeader();
            newShpHeader.fileCode = shpHeader1.fileCode;
            newShpHeader.unUse1 = shpHeader1.unUse1;
            newShpHeader.unUse2 = shpHeader1.unUse2;
            newShpHeader.unUse3 = shpHeader1.unUse3;
            newShpHeader.unUse4 = shpHeader1.unUse4;
            newShpHeader.unUse5 = shpHeader1.unUse5;
            newShpHeader.fileLength = shpHeader1.fileLength + ShpHeader2.fileLength - 50;
            newShpHeader.fileVersion = shpHeader1.fileVersion;
            newShpHeader.shapeType = shpHeader1.shapeType;
            newShpHeader.boundingBox = ShpFunction.MergeBoundingBox(shpHeader1.boundingBox, ShpHeader2.boundingBox);
            //合并逻辑
            return newShpHeader;
        }
        public static void MergeShp(String TextFileName, String TextFileName1, String TextFileName2)
        {
           
            BinaryReader binaryReader = null;
            BinaryReader binaryReader1 = null;
            FileStream fileStream = null;
            FileStream fileStream1 = null;

            try
            {
                fileStream = new FileStream(TextFileName, FileMode.Open, FileAccess.Read, FileShare.None);
                binaryReader = new BinaryReader(fileStream);
                ShpHeader newShpHeader = new ShpHeader();//定义header
                newShpHeader = ShpFunction.ReadShpHeader(binaryReader);
                ShpFileBody newShpBody = new ShpFileBody();

                fileStream1 = new FileStream(TextFileName1, FileMode.Open, FileAccess.Read, FileShare.None);
                binaryReader1 = new BinaryReader(fileStream1);
                ShpHeader newShpHeader1 = new ShpHeader();//定义header
                newShpHeader1 = ShpFunction.ReadShpHeader(binaryReader1);
                ShpFileBody newShpBody1 = new ShpFileBody();
                //写入新文件

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
                newShpHeader = ShpFunction.MergeShpHeader(newShpHeader, newShpHeader1);
                //合并文件头
                ShpFunction.WriteShpHeader(binaryWriter, newShpHeader);
                while (binaryReader.BaseStream.Position < binaryReader.BaseStream.Length)
                {
                    newShpBody = ShpFunction.ReadShpFileBody(binaryReader);
                    ShpFunction.WriteShpBody(binaryWriter, newShpBody);
                }
                while (binaryReader1.BaseStream.Position < binaryReader1.BaseStream.Length)
                {
                    newShpBody1 = ShpFunction.ReadShpFileBody(binaryReader1);
                    newShpBody1.recordNo = newShpBody1.recordNo + newShpBody.recordNo;
                    ShpFunction.WriteShpBody(binaryWriter, newShpBody1);
                }
                //大端格式读出记录编号，长度
                ShpFunction.CloseReader(binaryReader, fileStream);
                ShpFunction.CloseReader(binaryReader1, fileStream1);
                ShpFunction.CloseWriter(binaryWriter, fileStream2);
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
            //合并逻辑

        }
        public static void CloseReader(BinaryReader binaryReader, FileStream fileStream)
        {
            binaryReader.Close();
            fileStream.Close();
            binaryReader = null;
            fileStream = null;
        }
        public static void CloseWriter(BinaryWriter binaryWriter, FileStream fileStream2)
        {
            binaryWriter.Close();
            fileStream2.Close();
            binaryWriter = null;
            fileStream2 = null;
        }
        public static string ShowString(string TextFileName)
        {
            BinaryReader binaryReader = null;
            FileStream fileStream = null;
            string allLine = null;
            try
            {
                fileStream = new FileStream(TextFileName, FileMode.Open, FileAccess.Read, FileShare.None);
                binaryReader = new BinaryReader(fileStream);
                ShpHeader newShpHeader = new ShpHeader();//定义header
                newShpHeader = ShpFunction.ReadShpHeader(binaryReader);
                ShpFileBody newShpBody = new ShpFileBody();
                allLine = allLine + ShpFunction.ShpHeader_to_String(newShpHeader);
                //大端格式读出记录编号，长度
                while (binaryReader.BaseStream.Position < binaryReader.BaseStream.Length)
                {
                    newShpBody = ShpFunction.ReadShpFileBody(binaryReader);
                    allLine = allLine + ShpFunction.ShpBody_to_String(newShpBody);
                }
                ShpFunction.CloseReader(binaryReader, fileStream);
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
            return allLine;
        }
        public static void MergeManyShpFile(string[] filenames,string tempfile, string TargetFile)
        {           
            ShpFunction.MergeShp(filenames[0], filenames[1], tempfile);
            string temp = "";
            for (int i = 2; i < filenames.Length; i++)
            {
                ShpFunction.MergeShp(filenames[i], tempfile, TargetFile);
                temp = tempfile;
                tempfile = TargetFile;
                TargetFile = temp;
            }
            File.Delete(tempfile);
        }
    }
    
}

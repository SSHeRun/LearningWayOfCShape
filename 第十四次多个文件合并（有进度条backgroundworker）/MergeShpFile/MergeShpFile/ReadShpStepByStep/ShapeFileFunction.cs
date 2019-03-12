using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.ComponentModel;
using System.Threading;


namespace ReadShpStepByStep
{
    struct BoundingBox
    {
        public double xMin;
        public double yMin;
        public double xMax;
        public double yMax;
        public double zMin;
        public double zMax;
        public double mMin;
        public double mMax;
    }
    struct Record
    {
        public Int32 recordNum;
        public Int32 recordLength;
        public byte[] recordContents;
    }
    struct ShpFileHeader
    {
        public Int32 fileCode;
        public Int32 unUsed1;
        public Int32 unUsed2;
        public Int32 unUsed3;
        public Int32 unUsed4;
        public Int32 unUsed5;
        public Int32 fileLength;
        public Int32 fileVerion;
        public Int32 shapeType;
        public BoundingBox boundingBox;
    }

    class ShapeFileFunction
    {
        public static int ReadInt32UsingBigEndian(BinaryReader binaryReader)
        {
            byte[] bytes = new byte[4];
            bytes = binaryReader.ReadBytes(4);
            Array.Reverse(bytes);
            return BitConverter.ToInt32(bytes, 0);
        }
        public static void WriteInt32UsingBigEndian(Int32 writeData, BinaryWriter binaryWriter)
        {
            Byte[] bytesWriteFile = BitConverter.GetBytes(writeData);
            Array.Reverse(bytesWriteFile);
            binaryWriter.Write(bytesWriteFile, 0, bytesWriteFile.Length);
        }
        public static BoundingBox ReadBoundingBox(BinaryReader binaryReader)
        {
            BoundingBox boudingBox;
            boudingBox.xMin = binaryReader.ReadDouble();
            boudingBox.yMin = binaryReader.ReadDouble();
            boudingBox.xMax = binaryReader.ReadDouble();
            boudingBox.yMax = binaryReader.ReadDouble();
            boudingBox.zMin = binaryReader.ReadDouble();
            boudingBox.zMax = binaryReader.ReadDouble();
            boudingBox.mMin = binaryReader.ReadDouble();
            boudingBox.mMax = binaryReader.ReadDouble();
            return boudingBox;
        }
        public static void WriteBoundingBox(BoundingBox boudingBox, BinaryWriter binaryWriter)
        {
            binaryWriter.Write(boudingBox.xMin);
            binaryWriter.Write(boudingBox.yMin);
            binaryWriter.Write(boudingBox.xMax);
            binaryWriter.Write(boudingBox.yMax);
            binaryWriter.Write(boudingBox.zMin);
            binaryWriter.Write(boudingBox.zMax);
            binaryWriter.Write(boudingBox.mMin);
            binaryWriter.Write(boudingBox.mMax);

        }

        public static ShpFileHeader ReadShpFileHeader(BinaryReader binaryReader)
        {
            ShpFileHeader shpFileHeader = new ShpFileHeader();

            shpFileHeader.fileCode = ReadInt32UsingBigEndian(binaryReader);
            shpFileHeader.unUsed1 = ReadInt32UsingBigEndian(binaryReader);
            shpFileHeader.unUsed2 = ReadInt32UsingBigEndian(binaryReader);
            shpFileHeader.unUsed3 = ReadInt32UsingBigEndian(binaryReader);
            shpFileHeader.unUsed4 = ReadInt32UsingBigEndian(binaryReader);
            shpFileHeader.unUsed5 = ReadInt32UsingBigEndian(binaryReader);
            shpFileHeader.fileLength = ReadInt32UsingBigEndian(binaryReader);
            shpFileHeader.fileVerion = binaryReader.ReadInt32();
            shpFileHeader.shapeType = binaryReader.ReadInt32();
            shpFileHeader.boundingBox = ReadBoundingBox(binaryReader);

            return shpFileHeader;
        }

        public static void WriteShpFileHeader(ShpFileHeader shpFileHeader, BinaryWriter binaryWriter)
        {
            WriteInt32UsingBigEndian(shpFileHeader.fileCode, binaryWriter);
            WriteInt32UsingBigEndian(shpFileHeader.unUsed1, binaryWriter);
            WriteInt32UsingBigEndian(shpFileHeader.unUsed2, binaryWriter);
            WriteInt32UsingBigEndian(shpFileHeader.unUsed3, binaryWriter);
            WriteInt32UsingBigEndian(shpFileHeader.unUsed4, binaryWriter);
            WriteInt32UsingBigEndian(shpFileHeader.unUsed5, binaryWriter);
            WriteInt32UsingBigEndian(shpFileHeader.fileLength, binaryWriter);

            binaryWriter.Write(shpFileHeader.fileVerion);
            binaryWriter.Write(shpFileHeader.shapeType);

            WriteBoundingBox(shpFileHeader.boundingBox, binaryWriter);
        }

        public static Record ReadRecord(BinaryReader binaryReader)
        {
            Record record = new Record();
            record.recordNum = ReadInt32UsingBigEndian(binaryReader);
            record.recordLength = ReadInt32UsingBigEndian(binaryReader);
            record.recordContents = binaryReader.ReadBytes(record.recordLength * 2);
            return record;
        }
        public static void WriteRecord(Record record, BinaryWriter binaryWriter)
        {
            WriteInt32UsingBigEndian(record.recordNum, binaryWriter);
            WriteInt32UsingBigEndian(record.recordLength, binaryWriter);
            binaryWriter.Write(record.recordContents);
        }
        public static BoundingBox MergeBoundingBox(BoundingBox boundingBox1, BoundingBox boundingBox2)
        {
            boundingBox1.xMin = boundingBox1.xMin > boundingBox2.xMin ? boundingBox2.xMin : boundingBox1.xMin;
            boundingBox1.xMax = boundingBox1.xMax > boundingBox2.xMax ? boundingBox1.xMax : boundingBox2.xMax;
            boundingBox1.yMin = boundingBox1.yMin > boundingBox2.yMin ? boundingBox2.yMin : boundingBox1.yMin;
            boundingBox1.yMax = boundingBox1.yMax > boundingBox2.yMax ? boundingBox1.yMax : boundingBox2.yMax;
            boundingBox1.zMin = boundingBox1.zMin > boundingBox2.zMin ? boundingBox2.zMin : boundingBox1.zMin;
            boundingBox1.zMax = boundingBox1.zMax > boundingBox2.zMax ? boundingBox1.zMax : boundingBox2.zMax;
            boundingBox1.mMin = boundingBox1.mMin > boundingBox2.mMin ? boundingBox2.mMin : boundingBox1.mMin;
            boundingBox1.mMax = boundingBox1.mMax > boundingBox2.mMax ? boundingBox1.mMax : boundingBox2.mMax;
            return boundingBox1;
        }
        public static ShpFileHeader MergeShpHeader(ShpFileHeader shpFileHeader1, ShpFileHeader shpFileHeader2)
        {
            shpFileHeader1.fileLength = shpFileHeader1.fileLength + shpFileHeader2.fileLength - 50;
            shpFileHeader1.boundingBox = MergeBoundingBox(shpFileHeader1.boundingBox, shpFileHeader2.boundingBox);
            return shpFileHeader1;
        }
        public static void MergeShpRecord(BinaryReader binaryReader1, BinaryReader binaryReader2, BinaryWriter binaryWriter)
        {
            Record record = new Record();
            while (binaryReader1.BaseStream.Position < binaryReader1.BaseStream.Length)
            {
                record = ShapeFileFunction.ReadRecord(binaryReader1);
                ShapeFileFunction.WriteRecord(record, binaryWriter);
            }
            int recordLastNum = record.recordNum;
            while (binaryReader2.BaseStream.Position < binaryReader2.BaseStream.Length)
            {
                record = ShapeFileFunction.ReadRecord(binaryReader2);
                record.recordNum = recordLastNum + record.recordNum;
                ShapeFileFunction.WriteRecord(record, binaryWriter);
            }
        }
        public static void MergeTwoShpFile(string sourceFileName1, string sourceFileName2, String saveFileName)
        {
            BinaryReader binaryReader1 = null;
            BinaryReader binaryReader2 = null;
            FileStream fileStream1 = null;
            FileStream fileStream2 = null;
            FileStream fileStream3 = null;
            try
            {
                fileStream1 = new FileStream(sourceFileName1, FileMode.Open, FileAccess.Read, FileShare.None);
                binaryReader1 = new BinaryReader(fileStream1);
                fileStream2 = new FileStream(sourceFileName2, FileMode.Open, FileAccess.Read, FileShare.None);
                binaryReader2 = new BinaryReader(fileStream2);

                fileStream3 = new FileStream(saveFileName, FileMode.Create, FileAccess.Write);
                BinaryWriter binaryWriter = new BinaryWriter(fileStream3);

                ShpFileHeader shpFileHeader1 = new ShpFileHeader();
                shpFileHeader1 = ShapeFileFunction.ReadShpFileHeader(binaryReader1);

                ShpFileHeader shpFileHeader2 = new ShpFileHeader();
                shpFileHeader2 = ShapeFileFunction.ReadShpFileHeader(binaryReader2);
                ShpFileHeader shpFileHeader3 = ShapeFileFunction.MergeShpHeader(shpFileHeader1, shpFileHeader2);

                ShapeFileFunction.WriteShpFileHeader(shpFileHeader3, binaryWriter);

                MergeShpRecord(binaryReader1, binaryReader2, binaryWriter);
                binaryReader1.Close();
                fileStream1.Close();
                binaryReader2.Close();
                fileStream2.Close();
                binaryReader1 = null;
                binaryReader2 = null;
                fileStream1 = null;
                fileStream2 = null;
                fileStream3 = null;
                binaryWriter.Close();
                fileStream2.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("在合并文件的过程中，发生了异常！");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            finally
            {
                if (fileStream1 != null || fileStream2 != null || fileStream3 != null)
                {
                    try
                    {
                        fileStream1.Close();
                        fileStream2.Close();
                        fileStream3.Close();
                    }
                    catch
                    {
                        // 最后关闭文件，无视关闭是否会发生错误了.
                    }
                }
            }
        }
        public static void MergeManyShpFile(string[] sourceFiles, String saveFileName, BackgroundWorker worker, DoWorkEventArgs e)
        {
            BinaryReader binaryReader1 = null;
            FileStream fileStreamRead = null;
            FileStream fileStreamWrite = null;

            fileStreamWrite = new FileStream(saveFileName, FileMode.Create, FileAccess.Write);
            BinaryWriter binaryWriter = new BinaryWriter(fileStreamWrite);
            Record record = new Record();
            int recordLastNum = 0;
            ShpFileHeader shpFileHeaderTatal = new ShpFileHeader();
            ShpFileHeader shpFileHeaderRead = new ShpFileHeader();
            for (int i = 0; i < sourceFiles.Length; i++)
            {
                fileStreamRead = new FileStream(sourceFiles[i], FileMode.Open, FileAccess.Read, FileShare.None);
                binaryReader1 = new BinaryReader(fileStreamRead);
                shpFileHeaderRead = ShapeFileFunction.ReadShpFileHeader(binaryReader1);
                if (i == 0)
                {
                    ShapeFileFunction.WriteShpFileHeader(shpFileHeaderRead, binaryWriter);
                    shpFileHeaderTatal = shpFileHeaderRead;
                }
                else
                {
                    shpFileHeaderTatal = ShapeFileFunction.MergeShpHeader(shpFileHeaderTatal, shpFileHeaderRead);
                }
                while (binaryReader1.BaseStream.Position < binaryReader1.BaseStream.Length)
                {
                    record = ShapeFileFunction.ReadRecord(binaryReader1);
                    record.recordNum = recordLastNum++;
                    ShapeFileFunction.WriteRecord(record, binaryWriter);
                }
                binaryReader1.Close();
                fileStreamRead.Close();
                worker.ReportProgress(i * 100 / (sourceFiles.Length - 1));
                Thread.Sleep(200);
                if (worker.CancellationPending)
                {
                    fileStreamWrite.Seek(0, SeekOrigin.Begin);
                    WriteShpFileHeader(shpFileHeaderTatal, binaryWriter);
                    binaryWriter.Close();
                    fileStreamWrite.Close();
                    e.Cancel = true;
                    return;
                }
            }
         
            fileStreamWrite.Seek(0, SeekOrigin.Begin);
            WriteShpFileHeader(shpFileHeaderTatal, binaryWriter);
            binaryWriter.Close();
            fileStreamWrite.Close();
        }
    }
}

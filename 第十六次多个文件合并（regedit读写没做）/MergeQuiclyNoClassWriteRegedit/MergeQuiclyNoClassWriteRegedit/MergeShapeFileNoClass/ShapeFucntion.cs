using System;
using System.IO;
using System.Threading;
using System.ComponentModel;

namespace MergeShapeFileNoClass
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
    struct ShapeHeader
    {
        public int fileCode;
        public int unUsed1;
        public int unUsed2;
        public int unUsed3;
        public int unUsed4;
        public int unUsed5;
        public int fileLenth;
        public int fileVerion;
        public int shapeType;
        public BoundingBox boundingBox;
    }
    struct Record
    {
        public int recordNumber;
        public int recordLength;
        public byte[] recordContents;
    }

    class ShapeFucntion
    {
        public delegate void Refresh(int step);
        public delegate void ContorlValue(int min, int max);
        public static int ReadInt32UsingBigEndian(BinaryReader binaryReader)
        {
            byte[] intBytes = binaryReader.ReadBytes(4);
            Array.Reverse(intBytes);
            return BitConverter.ToInt32(intBytes, 0);
        }

        public static void WriteInt32UsingBigEndian(int value, BinaryWriter binaryWriter)
        {
            byte[] intBytes = BitConverter.GetBytes(value);
            Array.Reverse(intBytes);
            binaryWriter.Write(intBytes);
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
            return boundingBox;
        }

        public static void WriteBoundingBox(BoundingBox boundingBox, BinaryWriter binaryWriter)
        {
            binaryWriter.Write(boundingBox.xMin);
            binaryWriter.Write(boundingBox.yMin);
            binaryWriter.Write(boundingBox.xMax);
            binaryWriter.Write(boundingBox.yMax);
            binaryWriter.Write(boundingBox.zMin);
            binaryWriter.Write(boundingBox.zMax);
            binaryWriter.Write(boundingBox.mMin);
            binaryWriter.Write(boundingBox.mMax);
        }

        public static ShapeHeader ReadShapeHeader(BinaryReader binaryReader)
        {
            ShapeHeader shapeHeader = new ShapeHeader();
            //// Read int32 using big Endian.
            shapeHeader.fileCode = ReadInt32UsingBigEndian(binaryReader);
            shapeHeader.unUsed1 = ReadInt32UsingBigEndian(binaryReader);
            shapeHeader.unUsed2 = ReadInt32UsingBigEndian(binaryReader);
            shapeHeader.unUsed3 = ReadInt32UsingBigEndian(binaryReader);
            shapeHeader.unUsed4 = ReadInt32UsingBigEndian(binaryReader);
            shapeHeader.unUsed5 = ReadInt32UsingBigEndian(binaryReader);
            shapeHeader.fileLenth = ReadInt32UsingBigEndian(binaryReader);

            ////Read int32  using little Endian.
            shapeHeader.fileVerion = binaryReader.ReadInt32();
            shapeHeader.shapeType = binaryReader.ReadInt32();
            shapeHeader.boundingBox = ReadBoundingBox(binaryReader);
            return shapeHeader;
        }

        public static void WriteShapeHeader(ShapeHeader shapeHeader, BinaryWriter binaryWriter)
        {
            // Write int32 using big Endian.
            WriteInt32UsingBigEndian(shapeHeader.fileCode, binaryWriter);
            WriteInt32UsingBigEndian(shapeHeader.unUsed1, binaryWriter);
            WriteInt32UsingBigEndian(shapeHeader.unUsed2, binaryWriter);
            WriteInt32UsingBigEndian(shapeHeader.unUsed3, binaryWriter);
            WriteInt32UsingBigEndian(shapeHeader.unUsed4, binaryWriter);
            WriteInt32UsingBigEndian(shapeHeader.unUsed5, binaryWriter);
            WriteInt32UsingBigEndian(shapeHeader.fileLenth, binaryWriter);

            // Write int32  using little Endian.
            binaryWriter.Write(shapeHeader.fileVerion);
            binaryWriter.Write(shapeHeader.shapeType);
            WriteBoundingBox(shapeHeader.boundingBox, binaryWriter);
        }

        public static ShapeHeader MergeShapeHeader(ShapeHeader shapeHeader1, ShapeHeader shapeHeader2)
        {
            // Two shapefiles after merge relive one header.
            shapeHeader1.fileLenth = shapeHeader1.fileLenth + shapeHeader2.fileLenth - 50;
            shapeHeader1.boundingBox = MergeBoundingBox(shapeHeader1.boundingBox, shapeHeader2.boundingBox);
            return shapeHeader1;
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

        public static Record ReadRecord(BinaryReader binaryReader)
        {
            Record record = new Record();
            record.recordNumber = ReadInt32UsingBigEndian(binaryReader);
            record.recordLength = ReadInt32UsingBigEndian(binaryReader);
            record.recordContents = binaryReader.ReadBytes(record.recordLength * 2);
            return record;
        }

        public static void WriteRecord(Record record, BinaryWriter binaryWriter)
        {
            WriteInt32UsingBigEndian(record.recordNumber, binaryWriter);
            WriteInt32UsingBigEndian(record.recordLength, binaryWriter);
            binaryWriter.Write(record.recordContents);
        }

        public static void MergerManyShapeFile(String[] files, string TargetFile, ContorlValue contorlValue, Refresh refreshProBar)
        {
            if (File.Exists(TargetFile))
            {
                File.Delete(TargetFile);
            }
            contorlValue.Invoke(0, files.Length - 1);
            File.Copy(files[0], TargetFile, true);
            FileStream fileStream1 = new FileStream(TargetFile, FileMode.Open, FileAccess.ReadWrite);
            BinaryReader binaryReader1 = new BinaryReader(fileStream1);
            BinaryWriter binaryWriter = new BinaryWriter(fileStream1);
            ShapeHeader shapeHeader1 = new ShapeHeader();
            shapeHeader1 = ShapeFucntion.ReadShapeHeader(binaryReader1);
            Record record = new Record();
            while (binaryReader1.BaseStream.Position < binaryReader1.BaseStream.Length)
            {
                record = ShapeFucntion.ReadRecord(binaryReader1);
            }
            int recordNum = record.recordNumber;
            for (int i = 1; i < files.Length; i++)
            {
                FileStream fileStream2 = new FileStream(files[i], FileMode.Open, FileAccess.Read);
                BinaryReader binaryReader2 = new BinaryReader(fileStream2);
                ShapeHeader shapeHeader2 = new ShapeHeader();
                shapeHeader2 = ShapeFucntion.ReadShapeHeader(binaryReader2);
                shapeHeader1 = ShapeFucntion.MergeShapeHeader(shapeHeader1, shapeHeader2);

                while (binaryReader2.BaseStream.Position < binaryReader2.BaseStream.Length)
                {
                    recordNum++;
                    record = ShapeFucntion.ReadRecord(binaryReader2);
                    record.recordNumber = recordNum;
                    ShapeFucntion.WriteRecord(record, binaryWriter);
                }
                binaryReader2.Close();
                fileStream2.Close();
                refreshProBar.Invoke(i);
                Thread.Sleep(500);
            }
            fileStream1.Seek(0, SeekOrigin.Begin);
            ShapeFucntion.WriteShapeHeader(shapeHeader1, binaryWriter);
            binaryReader1.Close();
            binaryWriter.Close();
            fileStream1.Close();
        }

        public static void MergerManyShapeFile(String[] files, string TargetFile, BackgroundWorker worker, DoWorkEventArgs e)
        {
            if (File.Exists(TargetFile))
            {
                File.Delete(TargetFile);
            }

            File.Copy(files[0], TargetFile, true);
            FileStream fileStream1 = new FileStream(TargetFile, FileMode.Open, FileAccess.ReadWrite);
            BinaryReader binaryReader1 = new BinaryReader(fileStream1);
            BinaryWriter binaryWriter = new BinaryWriter(fileStream1);
            ShapeHeader shapeHeader1 = new ShapeHeader();
            shapeHeader1 = ShapeFucntion.ReadShapeHeader(binaryReader1);
            Record record = new Record();
            while (binaryReader1.BaseStream.Position < binaryReader1.BaseStream.Length)
            {
                record = ShapeFucntion.ReadRecord(binaryReader1);
            }
            int recordNum = record.recordNumber;
            for (int i = 1; i < files.Length; i++)
            {
                FileStream fileStream2 = new FileStream(files[i], FileMode.Open, FileAccess.Read);
                BinaryReader binaryReader2 = new BinaryReader(fileStream2);
                ShapeHeader shapeHeader2 = new ShapeHeader();
                shapeHeader2 = ShapeFucntion.ReadShapeHeader(binaryReader2);
                shapeHeader1 = ShapeFucntion.MergeShapeHeader(shapeHeader1, shapeHeader2);

                while (binaryReader2.BaseStream.Position < binaryReader2.BaseStream.Length)
                {
                    recordNum++;
                    record = ShapeFucntion.ReadRecord(binaryReader2);
                    record.recordNumber = recordNum;
                    ShapeFucntion.WriteRecord(record, binaryWriter);
                }
                binaryReader2.Close();
                fileStream2.Close();

              //  Thread.Sleep(500);
                worker.ReportProgress(i * 100 / (files.Length - 1));
                if (worker.CancellationPending)
                {
                    fileStream1.Seek(0, SeekOrigin.Begin);
                    ShapeFucntion.WriteShapeHeader(shapeHeader1, binaryWriter);
                    binaryReader1.Close();
                    binaryWriter.Close();
                    fileStream1.Close();
                    e.Cancel = true;
                    return;
                }
            }
            fileStream1.Seek(0, SeekOrigin.Begin);
            ShapeFucntion.WriteShapeHeader(shapeHeader1, binaryWriter);
            binaryReader1.Close();
            binaryWriter.Close();
            fileStream1.Close();
        }
    }
}

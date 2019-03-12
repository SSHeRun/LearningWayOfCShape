using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
namespace ShpMerger
{
    class ShpFile
    {
        private Header header;
        private string shpFileName;
        private ExtendBinaryWriter extendBinaryWriter;
        private ExtendBinaryReader extendBinaryReader;
        private int recordNumber = 0;
        private ShapeFileOpenMode fileCurrentMode;

        public ShpFile(string fileName, ShapeFileOpenMode fileOpenMode)
        {
            this.shpFileName = fileName;

            FileStream fileStream = new FileStream(shpFileName, FileMode.Open, FileAccess.ReadWrite);
            this.extendBinaryReader = new ExtendBinaryReader(fileStream);
            this.header = new Header();
            this.header.Read(this.extendBinaryReader);
            fileCurrentMode = fileOpenMode;
            if (fileOpenMode == ShapeFileOpenMode.FileReadFirst)
            {
                while (extendBinaryReader.BaseStream.Position < extendBinaryReader.BaseStream.Length)
                {
                    Record recordCurrent = new Record();
                    recordCurrent.Read(extendBinaryReader);
                    recordNumber++;
                }

                this.extendBinaryWriter = new ExtendBinaryWriter(fileStream);
                this.extendBinaryWriter.BaseStream.Position = extendBinaryReader.BaseStream.Length;
            }
        }
        public void Close()
        {
            if (fileCurrentMode == ShapeFileOpenMode.FileReadFirst)
            {
                this.extendBinaryWriter.BaseStream.Position = 0;
                this.header.Write(extendBinaryWriter);
            }
            if (this.extendBinaryReader != null)
            {
                this.extendBinaryReader.Close();
            }
            if (this.extendBinaryWriter != null)
            {
                this.extendBinaryWriter.Close();
            }
        }
        public void Merge(ShpFile shpFile)
        {
            this.header.Merge(shpFile.header);
            while (shpFile.extendBinaryReader.BaseStream.Position < shpFile.extendBinaryReader.BaseStream.Length)
            {
                Record recordCurrent = new Record();
                recordCurrent.Read(shpFile.extendBinaryReader);
                recordNumber++;
                recordCurrent.RecordNumber = recordNumber;
                recordCurrent.Write(this.extendBinaryWriter);
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShpMerger
{
    class Record
    {
        private int recordNumber;
        private int recordLength;
        private byte[] recordContents;

        public Record()
        {
            recordNumber = 0;
        }

        public int RecordNumber
        {
            get
            {
                return recordNumber;
            }
            set
            {
                recordNumber = value;
            }
        }

        public void Read(ExtendBinaryReader extendBinaryReader)
        {
            recordNumber = extendBinaryReader.ReadInt32UsingBigEndian();
            recordLength = extendBinaryReader.ReadInt32UsingBigEndian();
            recordContents = extendBinaryReader.ReadBytes(recordLength * 2);
        }

        public void Write(ExtendBinaryWriter extendBinaryWriter)
        {
            extendBinaryWriter.WriteUsingBigEndian(recordNumber);
            extendBinaryWriter.WriteUsingBigEndian(recordLength);
            extendBinaryWriter.Write(recordContents);
        }
    }
}

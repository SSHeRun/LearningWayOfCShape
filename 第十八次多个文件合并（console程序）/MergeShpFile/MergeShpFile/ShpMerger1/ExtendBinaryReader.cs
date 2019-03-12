using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ShpMerger
{
    public class ExtendBinaryReader : BinaryReader
    {
        public ExtendBinaryReader(Stream input)
            : base(input)
        { }

        public int ReadInt32UsingBigEndian()
        {
            byte[] intBytes = this.ReadBytes(4);
            Array.Reverse(intBytes);
            return BitConverter.ToInt32(intBytes, 0);
        }
    }
}

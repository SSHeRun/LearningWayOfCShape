using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ShpMerger
{
    public class ExtendBinaryWriter:BinaryWriter
    {
        public ExtendBinaryWriter(Stream output)
            : base(output)
        { }

        public void WriteUsingBigEndian(int value)
        {
            byte[] intBytes = BitConverter.GetBytes(value);
            Array.Reverse(intBytes);
            this.Write(intBytes);
        }
    }
}

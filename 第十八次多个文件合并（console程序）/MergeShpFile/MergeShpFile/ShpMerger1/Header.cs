using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
namespace ShpMerger
{
    public class Header
    {
        private Int32 fileCode;
        private Int32 unUsed1;
        private Int32 unUsed2;
        private Int32 unUsed3;
        private Int32 unUsed4;
        private Int32 unUsed5;
        private Int32 fileLength;
        private Int32 fileVerion;
        private Int32 shapeType;
        private BoundingBox boundingBox;

        public Header()
        {
            boundingBox = new BoundingBox();
        }
        public void Read(ExtendBinaryReader extendBinaryReader)
        {
            // Read int32 using big Endian.
            fileCode = extendBinaryReader.ReadInt32UsingBigEndian();
            unUsed1 = extendBinaryReader.ReadInt32UsingBigEndian();
            unUsed2 = extendBinaryReader.ReadInt32UsingBigEndian();
            unUsed3 = extendBinaryReader.ReadInt32UsingBigEndian();
            unUsed4 = extendBinaryReader.ReadInt32UsingBigEndian();
            unUsed5 = extendBinaryReader.ReadInt32UsingBigEndian();
            fileLength = extendBinaryReader.ReadInt32UsingBigEndian();

            //Read int32  using little Endian.
            fileVerion = extendBinaryReader.ReadInt32();
            shapeType = extendBinaryReader.ReadInt32();
            boundingBox.Read(extendBinaryReader);
        }
        public void Write(ExtendBinaryWriter extendBinaryWriter)
        {
            // Write int32 using big Endian.
            extendBinaryWriter.WriteUsingBigEndian(fileCode);
            extendBinaryWriter.WriteUsingBigEndian(unUsed1);
            extendBinaryWriter.WriteUsingBigEndian(unUsed2);
            extendBinaryWriter.WriteUsingBigEndian(unUsed3);
            extendBinaryWriter.WriteUsingBigEndian(unUsed4);
            extendBinaryWriter.WriteUsingBigEndian(unUsed5);
            extendBinaryWriter.WriteUsingBigEndian(fileLength);

            // Write int32  using little Endian.
            extendBinaryWriter.Write(fileVerion);
            extendBinaryWriter.Write(shapeType);
            boundingBox.Write(extendBinaryWriter);
        }
        public void Merge(Header header)
        {
            // Two shapefiles after merge relive one header.
            fileLength = fileLength + header.fileLength - 50;
            boundingBox.Merge(header.boundingBox);
        }
    }
}

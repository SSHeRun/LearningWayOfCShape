using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ShpMerger
{
    public class BoundingBox
    {
        private double xMin;
        private double yMin;
        private double xMax;
        private double yMax;
        private double zMin;
        private double zMax;
        private double mMin;
        private double mMax;

        public BoundingBox()
        {
            ;}
         public void Read(ExtendBinaryReader binaryReader)
        {
            xMin = binaryReader.ReadDouble();
            yMin = binaryReader.ReadDouble();
            xMax = binaryReader.ReadDouble();
            yMax = binaryReader.ReadDouble();
            zMin = binaryReader.ReadDouble();
            zMax = binaryReader.ReadDouble();
            mMin = binaryReader.ReadDouble();
            mMax = binaryReader.ReadDouble();
        }
        public void Write(ExtendBinaryWriter binaryWriter)
        {
            binaryWriter.Write(xMin);
            binaryWriter.Write(yMin);
            binaryWriter.Write(xMax);
            binaryWriter.Write(yMax);
            binaryWriter.Write(zMin);
            binaryWriter.Write(zMax);
            binaryWriter.Write(mMin);
            binaryWriter.Write(mMax);
        }
        public void Merge(BoundingBox boundingBox)
        {
            xMin = boundingBox.xMin > xMin ? xMin : boundingBox.xMin;
            xMax = boundingBox.xMax > xMax ? boundingBox.xMax : xMax;
            yMin = boundingBox.yMin > yMin ? yMin : boundingBox.yMin;
            yMax = boundingBox.yMax > yMax ? boundingBox.yMax : yMax;
            zMin = boundingBox.zMin > zMin ? zMin : boundingBox.zMin;
            zMax = boundingBox.zMax > zMax ? boundingBox.zMax : zMax;
            mMin = boundingBox.mMin > mMin ? mMin : boundingBox.mMin;
            mMax = boundingBox.mMax > mMax ? boundingBox.mMax : mMax;
        }
    }
     
}


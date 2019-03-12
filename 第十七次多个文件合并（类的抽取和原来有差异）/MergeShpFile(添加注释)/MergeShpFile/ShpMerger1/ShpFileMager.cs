using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.ComponentModel;
namespace ShpMerger
{
   public class ShpFileMager
    {
  /// <summary>
  /// Merge source files to target file.
  /// </summary>
  /// <param name="SourceFiles">shp files path</param>
  /// <param name="targetFile">save merge targert shp file </param>
       public static void  Merge(string[] SourceFiles, string targetFile)
        {
            File.Copy(SourceFiles[0], targetFile, true);
           
            ShpFile outFile = new ShpFile(targetFile,ShapeFileOpenMode.FileReadFirst);
            for (int i = 1; i < SourceFiles.Length - 1; i++) 
            {
                ShpFile mergeFile = new ShpFile(SourceFiles[i],ShapeFileOpenMode.FileRead);
                outFile.Merge(mergeFile);
            }
            outFile.Close();
        }
       /// <summary>
       /// 
       /// </summary>
       /// <param name="SourceFiles"></param>
       /// <param name="targetFile"></param>
       /// <param name="worker"></param>
       /// <param name="e"></param>
        public static void Merge(string[] SourceFiles, string targetFile, BackgroundWorker worker, DoWorkEventArgs e)
        {
            File.Copy(SourceFiles[0], targetFile, true);
            ShpFile outFile = new ShpFile(targetFile,ShapeFileOpenMode.FileReadFirst);
            for (int i = 1; i < SourceFiles.Length; i++)
            {
                ShpFile mergeFile = new ShpFile(SourceFiles[i],ShapeFileOpenMode.FileRead);
                outFile.Merge(mergeFile);
                mergeFile.Close();
                int percentComplete = (int)((float)(i+1) / (float)SourceFiles.Length * 100);
                worker.ReportProgress(percentComplete);
                if (worker.CancellationPending)
                {
                    e.Cancel = true;
                    outFile.Close();
                    return;
                }
            }
            outFile.Close();
        }
    }
}

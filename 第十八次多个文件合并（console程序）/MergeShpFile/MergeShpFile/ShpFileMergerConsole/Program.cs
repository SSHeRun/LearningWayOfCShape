using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.ComponentModel;
using ShpMerger;

namespace ShpFileMergerConsole
{
    class Program
    {
        static BackgroundWorker bw;
        static int Progress = 0;
        static string[] files;
        static string outFile;
        static void Main(string[] args)
        {
            bw = new BackgroundWorker();
            bw.WorkerReportsProgress = true;
            bw.WorkerSupportsCancellation = true;
            bw.DoWork += bw_DoWork;
            bw.ProgressChanged += bw_ProgressChanged;
            bw.RunWorkerCompleted += bw_RunWorkerCompleted;

            for (int i = 0; i < args.Length; i++)
            {
                args[i] = args[i].ToLower();
            }
         //   ShapeFileMerger shapeFileMerger = new ShapeFileMerger();
            switch (args[0])
            {
                case "-v":
                    Console.WriteLine("ConsoleMergeShape Verson1.0.");
                    break;
                case "-h":
                    Console.WriteLine("ConsoleMergeShape Help.");
                    Console.WriteLine("ConsoleMergeShape -h     Show Help.");
                    Console.WriteLine("ConsoleMergeShape -v     Show Verson.");
                    Console.WriteLine("ConsoleMergeShape -d DerectionyName file2.shp   Merge DerectionyName's all file to file3.shp.");
                    break;
                case "-d":
                    if (args.Length != 3)
                    {
                        Console.WriteLine("Input error, Please check.");
                        break;
                    }
                    string sourceDerectiony = args[1];
                    outFile = args[2];
                    if (!Directory.Exists(sourceDerectiony))
                    {
                        Console.WriteLine("SourceFolder not exist.");
                        break;
                    }
                    files = Directory.GetFiles(sourceDerectiony, "*.shp");
                    if (files.Length <= 1)
                    {
                        Console.WriteLine("Merge file less 1.");
                        break;
                    }
                    bw.RunWorkerAsync();
                    break;
                default:
                    Console.WriteLine("Input error, Please check.");
                    break;
            }
            while (true)
            {
                if (Console.ReadKey(true).Key == ConsoleKey.Escape)
                {
                    bw.CancelAsync();
                }
                else
                {
                    break;
                }
            }
        }
        static void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            try
            {
                ShpFileMager shapeFileMerger = new ShpFileMager();
                Console.Write("Press ESC cancel the operration ,press other key exit.\n");
                Console.Write("Complete   ");
                shapeFileMerger.Merge(files, outFile, worker, e);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Merge error,error code:" + ex.ToString());
            }
        }
        static void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                Console.WriteLine(e.Error.Message);
            }
            else if (e.Cancelled)
            {
                Console.WriteLine("Cancel merge，complte" + Progress.ToString() + "%.");
                Console.WriteLine("Press any key exit.");
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine("Merge success.");
                Console.WriteLine("Press any key exit.");
            }
        }
        static void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Progress = e.ProgressPercentage;
            if (Progress.ToString().Length == 1)
            {
                Console.SetCursorPosition(Console.CursorLeft - 2, Console.CursorTop);
            }
            else
            {
                Console.SetCursorPosition(Console.CursorLeft - 3, Console.CursorTop);
            }
            Console.Write(Progress.ToString() + "%");
        }
    }
}

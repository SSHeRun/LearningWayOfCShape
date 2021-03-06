﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace WindowsFormsApplication1
{
    class Class1
    {
        public delegate void RefreshValue(int value);
        public delegate void ContorlMinAndMaxValue(int min, int max);
        public static void BeginCount(int count,ContorlMinAndMaxValue contorlMinAndMaxValue, RefreshValue refreshValue)
        {
            contorlMinAndMaxValue(1, count);

            for (int i = 1; i <= count; i++)
            {
                Thread.Sleep(25);
                refreshValue(i);
            }
        }

        
        public static void BeginCount2(BackgroundWorker worker, DoWorkEventArgs e)
        {

            for (int i = 1; i <= 68; i++)
            {

                worker.ReportProgress(i * 100 / 68);
                Thread.Sleep(100);
                if (worker.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }

            }
        }
    }
}

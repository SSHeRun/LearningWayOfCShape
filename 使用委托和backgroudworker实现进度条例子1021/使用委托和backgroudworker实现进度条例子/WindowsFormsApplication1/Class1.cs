using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.ComponentModel;

namespace WindowsFormsApplication1
{
    class Class1
    {
        public delegate void RefreshValue(int value);
        public delegate void ContorlMinAndMaxValue(int min, int max);
        public static void BeginCount(ContorlMinAndMaxValue contorlMinAndMaxValue, RefreshValue refreshValue)
        {
            contorlMinAndMaxValue(1, 68);

            for (int i = 1; i <= 68; i++)
            {
                Thread.Sleep(100);
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

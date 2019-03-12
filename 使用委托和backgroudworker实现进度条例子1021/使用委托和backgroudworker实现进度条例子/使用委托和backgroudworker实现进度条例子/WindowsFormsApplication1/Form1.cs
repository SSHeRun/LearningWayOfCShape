using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Collections.ObjectModel;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private delegate void SetValueDelegate(int min, int max);
        private delegate void RefreshValueDelegate(int step);
        TimeSpan ts1, ts2;
        int Progress = 0;
        private void SetValue(int min, int max)
        {
            SetValueDelegate setValueDelegate = new SetValueDelegate(SetProgressBarValue);
            progressBar1.Invoke(setValueDelegate, min, max);
            //progressBar1.Minimum = min;
            //progressBar1.Maximum = max;
        }
        private void SetProgressBarValue(int min, int max)
        {
            progressBar1.Minimum = min;
            progressBar1.Maximum = max;
        }

        private void ReFreshValueForm(int step)
        {
            RefreshValueDelegate refreshValueDelegate = new RefreshValueDelegate(ReFreshProgressBar);
            progressBar1.Invoke(refreshValueDelegate, step);
            //progressBar1.Value = step;
            //label1.Text = ((int)(step * 100 / progressBar1.Maximum)).ToString() + "%";
        }
        private void ReFreshProgressBar(int step)
        {
            progressBar1.Value = step;
            label1.Text = ((int)(step * 100 / progressBar1.Maximum)).ToString() + "%";
            //label1.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Class1.ContorlMinAndMaxValue contorlMinAndMaxValue = new Class1.ContorlMinAndMaxValue(SetValue);
            Class1.RefreshValue refreshValue = new Class1.RefreshValue(ReFreshValueForm);
            int countfiles = 68;
            //  Class1.BeginCount(contorlMinAndMaxValue, refreshValue);
            // Class1.BeginCount(countfiles,contorlMinAndMaxValue, refreshValue);
            Collection<object> args = new Collection<object>();
            args.Add(countfiles);
            args.Add(contorlMinAndMaxValue);
            args.Add(refreshValue);
            Thread thread = new Thread(BeginCount);
            ts1 = new TimeSpan(DateTime.Now.Ticks);

            thread.Start(args);


        }
        public void BeginCount(object args)
        {
            Collection<object> argCollection = (Collection<object>)args;
            int count = (int)argCollection[0];

            Class1.ContorlMinAndMaxValue contorlMinAndMaxValue = (Class1.ContorlMinAndMaxValue)argCollection[1];
            Class1.RefreshValue refreshValue = (Class1.RefreshValue)argCollection[2];
            Class1.BeginCount(count, contorlMinAndMaxValue, refreshValue);

            ts2 = new TimeSpan(DateTime.Now.Ticks);
            TimeSpan ts = ts2.Subtract(ts1).Duration(); //时间差的绝对值 
            String spanTime = ts.Hours.ToString() + "小时" + ts.Minutes.ToString() + "分" + ts.Seconds.ToString() + "秒" + ts.Milliseconds.ToString() + "毫秒"; //以X小时X分X秒的格式现实执行时间 
            MessageBox.Show("合并结束，耗时" + spanTime);

        }
        private void button2_Click(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
            ts1 = new TimeSpan(DateTime.Now.Ticks);

            button2.Enabled = false;
            button3.Enabled = true;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            Class1.BeginCount2(worker, e);
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

            Progress = e.ProgressPercentage;
            this.progressBar2.Value = e.ProgressPercentage;
            this.label2.Text = e.ProgressPercentage.ToString() + "%";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.backgroundWorker1.CancelAsync();
            button3.Enabled = false;
            button2.Enabled = true;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
            }
            else if (e.Cancelled)
            {
                MessageBox.Show("Cancel merge，complte" + Progress.ToString() + "%.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                ts2 = new TimeSpan(DateTime.Now.Ticks);
                TimeSpan ts = ts2.Subtract(ts1).Duration(); //时间差的绝对值 
                String spanTime = ts.Hours.ToString() + "小时" + ts.Minutes.ToString() + "分" + ts.Seconds.ToString() + "秒" + ts.Milliseconds.ToString() + "毫秒"; //以X小时X分X秒的格式现实执行时间 
                MessageBox.Show("合并结束，耗时" + spanTime);
                progressBar1.Value = 0;
                label1.Text = "";

            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using wintool;
using SciChart;
using SciChart.Charting2D;
using SciChart.Core.Extensions;

namespace firefox
{
    public partial class Form1 : Form
    {
        static Threads threads = new Threads();

        public static Thread bot_thread = new Thread(threads.bot);
        public static Thread action_thread = new Thread(threads.isaction);
        public Form1()
        {
            InitializeComponent();
            Console.SetOut(RichBoxWriter.Instance);
            // говорим куда выводить
            RichBoxWriter.Instance.control = label2 ;
            RichBoxWriter.Instance.richTextBox = richTextBox1;
            RichBoxWriter.Instance.pica = pictureBox1;
            // далее просто пишем
            Console.WriteLine("console out");

            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Legends.Clear();
            chart1.ChartAreas[0].AxisX.MinorGrid.Enabled = false;
            chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chart1.ChartAreas[0].AxisY.MinorGrid.Enabled = false;
            chart1.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            chart1.ChartAreas[0].AxisX.Maximum = 24;
            chart1.ChartAreas[0].AxisX.Minimum = 0;
            chart1.ChartAreas[0].AxisY.Maximum = 10;
            chart1.ChartAreas[0].AxisY.Minimum = -10;

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (!bot_thread.IsAlive)
            {
                action_thread = new Thread(threads.isaction);
                bot_thread = new Thread(threads.bot);
                action_thread.Start();
                bot_thread.Start();

                Console.WriteLine("Start!");
                return;
            }

            switch (bot_thread.ThreadState.ToString())
            {
                case "SuspendRequested, WaitSleepJoin":
                    bot_thread.Resume();
                    button1.Text = "Pause";
                    Console.WriteLine("Resume");
                    break;
                case "WaitSleepJoin":
                    bot_thread.Suspend();
                    button1.Text = "Resume";
                    Console.WriteLine("Pause");
                    break;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.TopMost = true;
        }
        public static Util u = new Util();

        private void button3_Click(object sender, EventArgs e)
        {
            //Thread.Sleep(1000);
            try
            {
                bot_thread.Abort();
                string s = bot_thread.ThreadState.ToString();
                Console.Write(s);
            } catch
            {
                string s = bot_thread.ThreadState.ToString();
                Console.Write(s);
            }


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.ExitThread();
            Application.Exit();
            bot_thread.Abort();
            action_thread.Abort();
            Environment.Exit(-1);
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
        static int ix = 1;
        static List<double> li = new List<double> {};
        private void button4_Click(object sender, EventArgs e)
        {
            label2.Text = "202"; 
            if (label2.Text == "202")
            {
                label2.Text = "209";
            }
        }
        static int hcounter = 0;
        private void label2_TextChanged(object sender, EventArgs e)
        {

            try
            {
                li.Add((label2.Text.ToDouble() - 10 * Math.Round(label2.Text.ToDouble() / 10) + 0.5));
                if (ix > 12)
                {

                    ix = 13;
                    chart1.Series[0].Points.Clear();

                    for (int z = 0; z < 13; z++)
                    {
                        chart1.Series[0].Points.AddXY(z, li[z]);

                    }
                    li.RemoveAt(0);
                    //chart1.Series[0].Points.RemoveAt(chart1.Series[0].Points.Count - 1);
                    return;
                }
                chart1.Series[0].Points.AddXY(ix, li.Last());
                ix++;
            } catch
            {
                return;
            }
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        private bool isStarted = false;
        private Random ran = new Random();
        List<Individual> unHittedList = new List<Individual>();
        List<Individual> hittedList = new List<Individual>();
        private BackgroundWorker roundWorker = new BackgroundWorker();
        int num;

        public Form1()
        {
            InitializeComponent();
            roundWorker.DoWork += roundWorker_DoWork;
            roundWorker.WorkerReportsProgress = true;
            roundWorker.ProgressChanged += roundWorker_ProgressChanged;
            roundWorker.WorkerSupportsCancellation = true;

            List<string> nameList = FileUtils.readFile("namelist.txt");
      
            foreach(string name in nameList)
            {
                unHittedList.Add(new Individual(name));
            }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            isStarted = !isStarted;
            if (isStarted)
            {
                buttonStart.Text = "停止";
                num = Convert.ToInt32(comboBoxNum.SelectedItem as string);
                roundWorker.RunWorkerAsync();
                textBoxNameList.Text = "";
            }
            else
            {
                buttonStart.Enabled = false;
            }
        }

        private Individual getNext()
        {
            int next = ran.Next(unHittedList.Count);
            return unHittedList[next];
        }

        private void roundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            int count = 0;
            int hittedNum = 0;
            while (true)
            {
                Individual next = getNext();
                roundWorker.ReportProgress(0, next);
                if (!isStarted)
                {
                    count++;
                    if (count == 20)
                    {
                        roundWorker.ReportProgress(1, next);
                        Thread.Sleep(1000);
                        hittedNum++;
                        count = 0;
                        if (hittedNum == num)
                        {
                            roundWorker.CancelAsync();
                            roundWorker.ReportProgress(2, next);
                        }
                    }
                    else
                    {
                        Thread.Sleep(50);
                    }
                }
                else
                {
                    Thread.Sleep(50);
                }
                if (roundWorker.CancellationPending == true)
                {
                    e.Cancel = true;
                    break;
                }
            }
        }

        private void roundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Individual individual = e.UserState as Individual;
            if (e.ProgressPercentage == 0)
            {
                labelRun.Text = individual.Name;
            }
            else if (e.ProgressPercentage == 1)
            {
                textBoxNameList.Text += (individual.Name + "\r\n");
                individual.IsHitted = true;
                hittedList.Add(individual);
                unHittedList.Remove(individual);
                buttonStart.Enabled = true;
            }
            else if (e.ProgressPercentage == 2)
            {
                buttonStart.Text = "开始";
                buttonStart.Enabled = true;
                List<string> list = new List<string>();
                list.Add(comboBoxGrade.SelectedItem as string);
                foreach (Individual i in hittedList)
                {
                    list.Add(i.Name);
                }
                FileUtils.writeFile("hitted.txt", list);
            }
        }
    }
}

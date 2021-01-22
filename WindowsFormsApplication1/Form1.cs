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
        List<Individual> tempHittedList = new List<Individual>();

        private BackgroundWorker roundWorker = new BackgroundWorker();
        int num;

        public Form1()
        {
            InitializeComponent();
            roundWorker.DoWork += roundWorker_DoWork;
            roundWorker.WorkerReportsProgress = true;
            roundWorker.ProgressChanged += roundWorker_ProgressChanged;
            roundWorker.WorkerSupportsCancellation = true;

            List<string> nameList = FileUtils.readFile("总名单.txt");

            if (nameList == null) 
            {
                MessageBox.Show("未找到总名单");
                System.Environment.Exit(0);
            }
      
            foreach(string name in nameList)
            {
                unHittedList.Add(new Individual(name));
            }

            nameList.Clear();
            nameList = FileUtils.readFile("中奖名单.txt");

            if (nameList != null)
            {
                foreach (string name in nameList)
                {
                    if (!name.StartsWith("--"))
                    {
                        hittedList.Add(new Individual(name));
                    }
                }
            }

            foreach(Individual i in hittedList)
            {
                foreach (Individual j in unHittedList) 
                {
                    if (i.Equals(j))
                    {
                        unHittedList.Remove(j);
                        break;
                    }
                }
            }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (comboBoxGrade.SelectedIndex == -1)
            {
                MessageBox.Show("请选择奖项");
                return;
            }
            if (comboBoxNum.SelectedIndex == -1)
            {
                MessageBox.Show("请选择数量");
                return;
            }
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
                roundWorker.ReportProgress(0, next); // 随机产生了下一个人员
                if (!isStarted)
                {
                    count++;
                    if (count == 20)
                    {
                        roundWorker.ReportProgress(1, next); // 该人员中奖
                        Thread.Sleep(1000);
                        hittedNum++;
                        count = 0;
                        if (hittedNum == num)
                        {
                            roundWorker.CancelAsync();
                            roundWorker.ReportProgress(2, next); // 完成抽奖
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
            if (e.ProgressPercentage == 0) // 随机产生了下一个名单
            {
                labelRun.Text = individual.Name;
            }
            else if (e.ProgressPercentage == 1) // 该人员中奖
            {
                textBoxNameList.Text += (individual.Name + "\r\n");
                tempHittedList.Add(individual);
                unHittedList.Remove(individual);
                buttonStart.Enabled = true;
            }
            else if (e.ProgressPercentage == 2) // 完成抽奖
            {
                buttonStart.Text = "开始";
                buttonStart.Enabled = true;
                List<string> list = new List<string>();
                list.Add("--" + comboBoxGrade.SelectedItem as string);
                foreach (Individual i in tempHittedList)
                {
                    list.Add(i.Name);
                }
                FileUtils.writeFile("中奖名单.txt", list);
                hittedList.AddRange(tempHittedList);
                tempHittedList.Clear();
            }
        }
    }
}

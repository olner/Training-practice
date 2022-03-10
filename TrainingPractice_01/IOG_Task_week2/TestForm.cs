using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IOG_Task_week2
{
    public partial class TestForm : Form
    {
        public List<Label> arrLabel = new List<Label>();
        public int currentLabelNumber;
        Thread threadF3;
        bool isPause = true;
        int counter = 1;
        int sec = 0;
        int min = 0;
        public TestForm()
        {
            InitializeComponent();
        }

        private void TestForm_Load(object sender, EventArgs e)
        {

        }
        private void newGameLabel()
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Label newlbl = new Label();
                    newlbl.Width = 50;
                    newlbl.Height = 50;
                    newlbl.Margin = new Padding(0, 0, 0, 0);
                    newlbl.BorderStyle = BorderStyle.FixedSingle;
                    newlbl.Font = new Font("Microsoft Sans Serif", 20);
                    newlbl.TextAlign = ContentAlignment.MiddleCenter;
                    string tmpString = (i * 10 + j + 1).ToString("000");
                    newlbl.Name = "lbl" + tmpString;
                    //newlbl.Location = new Point(10 + 105 * j, 40 + 105 * i);
                    newlbl.Location = new Point(20 + 51 * j, 40 + 51 * i);
                    newlbl.BackColor = Color.White;
                    newlbl.Click += LabelOnClick;
                    this.Controls.Add(newlbl);
                    this.arrLabel.Add(newlbl);
                }
            }
        }
        private void LabelOnClick(object sender, EventArgs eventArgs)
        {
            string name = (sender as Label).Name;
            name = name.Replace("lbl", "");
            if (name == counter.ToString())
            {
                foreach (Label lbl in this.arrLabel)
                {
                    if(lbl.Name.Replace("lbl", "") == counter.ToString())
                    {
                        lbl.Visible = false;
                    }
                }
                if(name == 45.ToString())
                {
                    MessageBox.Show("Ура победа");
                    timer1.Stop();
                    return;
                }
                counter++;
                label1.Text = counter.ToString();
            }
        }
        private void newGameLabelTxt()
        {
            int[] arr = InitPole.initNewGame();
            int i = 0;

            foreach (Label lbl in this.arrLabel)
            {
                lbl.Text = arr[i].ToString();
                lbl.Name = "lbl" + arr[i];
                i = i + 1;
            }
        }

        private void startButton1_Click(object sender, EventArgs e)
        {
            newGameLabel();
            newGameLabelTxt();
            label1.Text = counter.ToString();
            timer1.Start();
            startButton1.Visible = false;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
            sec++;
            if (sec == 60 )
            {
                sec = 0;
                min++;
            }
            if( min == 1 && sec == 30)
            {
                MessageBox.Show("Вы не успели");
            }
            TimerLabel.Text = min.ToString() + ":" + sec.ToString();
        }
    }
}

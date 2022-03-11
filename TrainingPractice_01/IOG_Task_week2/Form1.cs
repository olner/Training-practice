using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web.Script.Serialization;

namespace IOG_Task_week2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            using (StreamWriter sw = new StreamWriter(@"C:\Users\user\Documents\TrainingPractice_01\Training-practice\TrainingPractice_01\IOG_Task_week2\bin\Debug\players.json",true))
            {
                sw.WriteLine(textBox1.Text);
                sw.Close();
            }
            TestForm test = new TestForm();
            test.Show();
        }
    }
}

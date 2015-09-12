using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ccbatest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var client = GetService())
            {
                var msg = client.DoWork();
                Console.WriteLine(msg);
            }
        }

        private CcbaService.CcbaServiceClient GetService()
        {
            return new CcbaService.CcbaServiceClient(); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var client = GetService())
            {
                var msg = client.GetServerTime(2);
                Console.WriteLine(msg);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (var client = GetService())
            {
                var msg = client.GetTable("", 3);
                if (msg == null) return;
                Console.WriteLine(msg);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (var client = GetService())
            {
                var msg = client.ExecSQL("", 4);
                Console.WriteLine(msg);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            using (var client = GetService())
            {
                var msg = client.ExecuteScalar("", 5);
                Console.WriteLine(msg);
            }
        }
        bool timeflag = false;
        private void button6_Click(object sender, EventArgs e)
        {
            timeflag = !timeflag;
            if (timeflag)
            {
                button6.Text = "running...";
                timer1.Start();
            }
            else
            {
                button6.Text = "stop!";
                timer1.Stop();
            }
   
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Random rd = new Random();
            int num = rd.Next(1000)%6;
            switch (num)
            {
                case 1:
                    button1_Click(null, null);
                    break;
                case 2:
                    button2_Click(null, null);
                    break;
                case 3:
                    button3_Click(null, null);
                    break;
                case 4:
                    button4_Click(null, null);
                    break;
                case 5:
                    button5_Click(null, null);
                    break;
                default:
                    break;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

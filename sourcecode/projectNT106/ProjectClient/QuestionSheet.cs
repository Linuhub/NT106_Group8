using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectClient
{
    public partial class QuestionSheet : Form
    {
        bool _isBoxOptionOpen = false;

        public QuestionSheet()
        {
            InitializeComponent();
        }

        

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (_isBoxOptionOpen)
            {
                panel1.Hide();
                _isBoxOptionOpen = false;
            }
            else
            {
                panel1.Show();
                _isBoxOptionOpen = true;
            }
        }


        private void QuestionSheet_Load_1(object sender, EventArgs e)
        {
            panel1.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form result = new ResultClient();
            result.ShowDialog();
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            progressBar1.PerformStep();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Start();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            timer1.Start();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            timer1.Start();

        }
    }
}

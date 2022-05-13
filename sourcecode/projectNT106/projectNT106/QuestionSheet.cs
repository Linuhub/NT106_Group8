using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projectNT106
{
    public partial class QuestionSheet : Form
    {
        bool _isBoxOptionOpen = false;
        public QuestionSheet()
        {
            InitializeComponent();
        }

        private void QuestionSheet_Load(object sender, EventArgs e)
        {
            panel1.Hide();
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

        private void QuestionSheet_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.PerformLayout();
        }
    }
}

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
    public partial class CreateRoom : Form
    {
        public CreateRoom()
        {
            InitializeComponent();
        }

        private void gradientPanel1_Paint(object sender, PaintEventArgs e)
        {
            gradientPanel1.BackColor = Color.FromArgb(50, 0, 0, 0);

        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            Form sheet = new QuestionSheet("ok");
            sheet.ShowDialog();
        }
    }
}

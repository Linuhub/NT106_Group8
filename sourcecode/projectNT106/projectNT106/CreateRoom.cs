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
    public partial class CreateRoom : Form
    {
        public CreateRoom()
        {
            InitializeComponent();
        }

        

        private void gradientPanel1_Paint(object sender, PaintEventArgs e)
        {
            roundedPanel1.BackColor = Color.FromArgb(50, 0, 0, 0);
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            Form room = new Room();
            room.Show();
        }
    }
}

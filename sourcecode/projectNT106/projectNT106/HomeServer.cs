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
    public partial class HomeServer : Form
    {
        public HomeServer()
        {
            InitializeComponent();
        }

        private void HomeServer_Load(object sender, EventArgs e)
        {

        }

        private void btnCreateRoom_Click(object sender, EventArgs e)
        {
            Form creRoom = new CreateRoom();
            creRoom.Show();
        }

        private void gradientPanel1_Paint(object sender, PaintEventArgs e)
        {
            gradientPanel1.BackColor = Color.FromArgb(50, 0, 0, 0);

        }

        private void btnManageQuestionList_Click(object sender, EventArgs e)
        {
            Form source = new QuestionSource();
            source.Show();
        }

    }
}

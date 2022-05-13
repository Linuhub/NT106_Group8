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
        bool _isUser = false;
        public CreateRoom(bool isUser)
        {
            _isUser = isUser;
            InitializeComponent();
        }

        private void gradientPanel1_Paint(object sender, PaintEventArgs e)
        {
            roundedPanel1.BackColor = Color.FromArgb(50, 0, 0, 0);
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (_isUser)
            {
                Form questionSheet = new QuestionSheet();
                questionSheet.ShowDialog();
            }
            else
            {
                Form room = new Room();
                room.Show();
            }
        }

        private void CreateRoom_Load(object sender, EventArgs e)
        {
            if (_isUser)
            {
                txtUserID.Enabled = true;
            }
        }
    }
}

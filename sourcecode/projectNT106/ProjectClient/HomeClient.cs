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
    public partial class HomeClient : Form
    {
        bool isEnterRoom = false;

        public HomeClient()
        {
            InitializeComponent();
        }

        private void btnEnterRoom_Click(object sender, EventArgs e)
        {
            if (!isEnterRoom)
            {
                btnCreateRoom.Enabled = false;
                btnRevision.Enabled = false;
                groupBox3.Enabled = true;
                isEnterRoom = true;
            }
            else
            {
                btnCreateRoom.Enabled = true;
                btnRevision.Enabled = true;
                groupBox3.Enabled = false;
                isEnterRoom = false;
            }
        }

        private void btnCreateRoom_Click(object sender, EventArgs e)
        {
            Form createRoom = new CreateRoom();
            createRoom.ShowDialog();
        }

        private void btnJoin_Click(object sender, EventArgs e)
        {

        }
    }
}

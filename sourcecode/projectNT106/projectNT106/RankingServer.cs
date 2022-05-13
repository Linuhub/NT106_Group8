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
    public partial class RankingServer : Form
    {
        public RankingServer()
        {
            InitializeComponent();
        }

        private void RankingServer_Load(object sender, EventArgs e)
        {
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void gradientPanel1_Paint(object sender, PaintEventArgs e)
        {
            gradientPanel1.BackColor = Color.FromArgb(100, 0, 0, 0);

        }
    }
}

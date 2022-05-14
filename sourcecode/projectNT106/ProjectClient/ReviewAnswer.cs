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
    public partial class ReviewAnswer : Form
    {
        public ReviewAnswer()
        {
            InitializeComponent();
        }

        
        private void ReviewAnswer_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 20; i++)
            {
                CheckBox cb = new CheckBox();
                cb.Text = (i + 1).ToString();
                cb.Size = new Size(30, 30);
                cb.TextAlign = ContentAlignment.MiddleCenter;
                cb.Appearance = Appearance.Button;
                Random rnd = new Random();
                flowLayoutPanel1.Controls.Add(cb);

            }
        }
    }
}

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
    public partial class ResultClient : Form
    {
        public ResultClient()
        {
            InitializeComponent();
        }

        private void btnInstruction_Click(object sender, EventArgs e)
        {
            Form review = new ReviewAnswer();
            review.ShowDialog();
        }
    }
}

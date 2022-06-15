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
    public partial class Instruction : Form
    {
        static public Image[] imgaList = new Image[6];
        static public int i = 0;
        public Instruction()
        {
            InitializeComponent();
        }
        private void Instruction_Load(object sender, EventArgs e)
        {
            imgaList[0] = Image.FromFile(Application.StartupPath + "\\HD/gioithieu.png");
            imgaList[1] = Image.FromFile(Application.StartupPath + "\\HD/huongdanthi.png");
            imgaList[2] = Image.FromFile(Application.StartupPath + "\\HD/Xemketqua.png");
            imgaList[3] = Image.FromFile(Application.StartupPath + "\\HD/Xemlaibaithi.png");
            imgaList[4] = Image.FromFile(Application.StartupPath + "\\HD/Ontap.png");
            imgaList[5] = Image.FromFile(Application.StartupPath + "\\HD/Ketthuc.png");
            pictureBox1.Image = imgaList[0];
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {

            if (i <= imgaList.Length && i > 0)
            {
                i--;
                pictureBox1.Image = imgaList[i];
                btnNext.Enabled = true;
            }
            if (i == 0)
            {
                btnPrev.Enabled = false;
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            i++;
            if (i < imgaList.Length)
            {
                pictureBox1.Image = imgaList[i];
                btnPrev.Enabled = true;
            }
            if (i == imgaList.Length - 1)
            {
                btnNext.Enabled = false;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}

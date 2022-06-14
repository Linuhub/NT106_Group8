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


        private int n = 0;
        private void ReviewAnswer_Load(object sender, EventArgs e)
        {
            Fill();
        }
        private void Fill()
        {
            ResetColor();
            txtQues.Text = QuestionSheet.QuestionList[n].QuestionText;
            txtA.Text = QuestionSheet.QuestionList[n].AnsA;
            txtB.Text = QuestionSheet.QuestionList[n].AnsB;
            txtC.Text = QuestionSheet.QuestionList[n].AnsC;
            txtD.Text = QuestionSheet.QuestionList[n].AnsD;
            if(QuestionSheet.QuestionList[n].QuestionPic != "")
            {
                pictureBox1.Image = Image.FromFile(QuestionSheet.QuestionList[n].QuestionPic);
            }
        }
        private void ResetColor()
        {
            txtA.BackColor = Color.Gainsboro;
            txtB.BackColor = Color.Gainsboro;
            txtC.BackColor = Color.Gainsboro;
            txtD.BackColor = Color.Gainsboro;
            ShowChoice();
            ShowAnswer();
        }
        private void ShowChoice()
        {
            if (QuestionSheet.QuestionList[n].Choice == "")
            {
                txtA.BackColor = Color.Red;
                txtB.BackColor = Color.Red;
                txtC.BackColor = Color.Red;
                txtD.BackColor = Color.Red;
            }
            else if (QuestionSheet.QuestionList[n].Choice == "Đáp án: A")
            {
                txtA.BackColor = Color.Red;
            }
            else if (QuestionSheet.QuestionList[n].Choice == "Đáp án: B")
            {
                txtB.BackColor = Color.Red;
            }
            else if (QuestionSheet.QuestionList[n].Choice == "Đáp án: C")
            {
                txtC.BackColor = Color.Red;
            }
            else if (QuestionSheet.QuestionList[n].Choice == "Đáp án: B")
            {
                txtD.BackColor = Color.Red;
            }
        }
        private void ShowAnswer()
        {
            if (QuestionSheet.QuestionList[n].RightAns == "Đáp án: A")
            {
                txtA.BackColor = Color.Green;
            }
            else if (QuestionSheet.QuestionList[n].RightAns == "Đáp án: B")
            {
                txtB.BackColor = Color.Green;
            }
            else if (QuestionSheet.QuestionList[n].RightAns == "Đáp án: C")
            {
                txtC.BackColor = Color.Green;
            }
            else if (QuestionSheet.QuestionList[n].RightAns == "Đáp án: D")
            {
                txtD.BackColor = Color.Green;
            }
        }

        private void btnNum_Click(object sender, EventArgs e)
        {
            string txt = sender.ToString().Split(',')[1];
            string num = txt.Substring(7);
            n = Convert.ToInt32(num)-1;
            Fill();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            n++;
            if (n > 19)
            {
                n = 0;
                Fill();
            }
            else Fill();
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            n--;
            if (n < 0)
            {
                n = 19;
                Fill();
            }
            else Fill();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

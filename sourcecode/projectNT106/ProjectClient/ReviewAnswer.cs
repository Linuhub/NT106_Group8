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


        private int n = 1;
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
            ResetColor();
            txtQues.Text = QuestionSheet.QuestionList[n].QuestionText;
            txtA.Text = QuestionSheet.QuestionList[n].AnsA;
            txtB.Text = QuestionSheet.QuestionList[n].AnsB;
            txtC.Text = QuestionSheet.QuestionList[n].AnsC;
            txtD.Text = QuestionSheet.QuestionList[n].AnsD;
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
            if (QuestionSheet.QuestionList[n].Choice == "Đáp án: A")
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
            else if (QuestionSheet.QuestionList[n].RightAns == "Đáp án: B")
            {
                txtD.BackColor = Color.Green;
            }
        }
    }
}

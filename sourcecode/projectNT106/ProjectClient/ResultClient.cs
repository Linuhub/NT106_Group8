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
        private string[] MyResultInfo;
        private string[] Rank1Info;
        private string[] Rank2Info;
        private string[] Rank3Info;
        public ResultClient()
        {
            InitializeComponent();
        }
        private string[] GetPlayerResult(string result)
        {
            string[] PlayerResult= result.Split(new char[] { '|' });
            return PlayerResult;
        }
        private void btnInstruction_Click(object sender, EventArgs e)
        {
            Form review = new ReviewAnswer();
            review.Show();
        }

        private void ResultClient_Load(object sender, EventArgs e)
        {
            txtUserID.Text = HomeClient.UserName;
            txtRoomID.Text = HomeClient.RoomID;
            if(QuestionSheet.MyResult=="")
            {
                txtMyPoint.Text = "Điểm\r\n";
                txtMyRank.Text = "Xếp hạng: ";
            }
            else
            {
                ptbMyAvt.Image = Image.FromFile(Application.StartupPath + "\\icon/icon" + QuestionSheet.ReceivedAvt(QuestionSheet.myAvt) + ".png");
                MyResultInfo = GetPlayerResult(QuestionSheet.MyResult);
                txtMyPoint.Text = "\r\nĐiểm\r\n" + MyResultInfo[3];
                txtMyRank.Text = "Xếp hạng: " + MyResultInfo[4];
                txtTotalRightAns.Text = "Số câu đúng: " + QuestionSheet.TotalRightAns;
            }        
            //MessageBox.Show("Nhận: " + QuestionSheet.Rank1Result);
            if (QuestionSheet.Rank1Result == "")
            {
                labelRank1ID.Text = "...";
                labelRank1Point.Text = "Điểm:";
            }
            else
            {
                ptbAvtTop1.Image = Image.FromFile(Application.StartupPath + "\\icon/icon" + QuestionSheet.ReceivedAvt(QuestionSheet.avtTop1) + ".png");
                Rank1Info = GetPlayerResult(QuestionSheet.Rank1Result);
                labelRank1ID.Text = Rank1Info[2];
                labelRank1Point.Text = "Điểm: " + Rank1Info[3];
            }
            if (QuestionSheet.Rank2Result == "")
            {
                labelRank2ID.Text = "...";
                labelRank2Point.Text = "Điểm:";
            }
            else
            {
                ptbAvtTop2.Image = Image.FromFile(Application.StartupPath + "\\icon/icon" + QuestionSheet.ReceivedAvt(QuestionSheet.avtTop2) + ".png");
                Rank2Info = GetPlayerResult(QuestionSheet.Rank2Result);
                labelRank2ID.Text = Rank2Info[2];
                labelRank2Point.Text = "Điểm: " + Rank2Info[3];
            }
            if (QuestionSheet.Rank3Result == "")
            {
                labelRank3ID.Text = "...";
                labelRank3Point.Text = "Điểm:";
            }
            else
            {
                ptbAvtTop3.Image = Image.FromFile(Application.StartupPath + "\\icon/icon" + QuestionSheet.ReceivedAvt(QuestionSheet.avtTop3) + ".png");
                Rank3Info = GetPlayerResult(QuestionSheet.Rank3Result);
                labelRank3ID.Text = Rank3Info[2];
                labelRank3Point.Text = "Điểm: " + Rank3Info[3];
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

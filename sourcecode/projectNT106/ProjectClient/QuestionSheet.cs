using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectClient
{
    public partial class QuestionSheet : Form
    {
        private string txtQues;
        private string[] QuesContent;
        private StreamReader srReceiver;
        private StreamWriter swSender;
        private Thread thrMessaging;
        public string cmt;
        private double TimeElapsed;
        bool _isBoxOptionOpen = false;
        private System.Windows.Forms.Timer aTimer;
        private int counter = 10;
        public static Question[] QuestionList = new Question[20];
        private int i = -1;
        public static string MyResult;
        public static string Rank1Result;
        public static string Rank2Result;
        public static string Rank3Result;
        private void RunTimer()
        {
            aTimer = new System.Windows.Forms.Timer();

            aTimer.Tick += new EventHandler(aTimer_Tick);

            aTimer.Interval = 1000; // 1 second

            aTimer.Start();

            LabelTimeLeft.Text = counter.ToString();
        }
        private void aTimer_Tick(object sender, EventArgs e)

        {

            counter--;

            if (counter == 0)

                aTimer.Stop();

            LabelTimeLeft.Text = counter.ToString();

        }
        private void UpdateQuestionSheet(string strMessage)
        {
            MessageBox.Show("Update sheet: " + strMessage + "\r\n");
        }

        public QuestionSheet(string respon)
        {
            InitializeComponent();
            cmt = respon;
            //button1.Hide();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (_isBoxOptionOpen)
            {
                panel1.Hide();
                _isBoxOptionOpen = false;
            }
            else
            {
                panel1.Show();
                _isBoxOptionOpen = true;
            }
        }

        private void QuestionSheet_Load_1(object sender, EventArgs e)
        {
            panel1.Hide();
            Form.CheckForIllegalCrossThreadCalls = false;
            //this.Invoke(new HomeClient.UpdateLogCallback(this.UpdateQuestionSheet), new object[] { srReceiver.ReadLine() });
            txtQues = cmt;
            
            txtUserID.Text = HomeClient.UserName;
            txtRoomID.Text = HomeClient.RoomID;
            thrMessaging = new Thread(ReceiveMessage);
            thrMessaging.Start();
        }
        private void ReceiveMessage()
        {
            try
            {            
                srReceiver = new StreamReader(HomeClient.tcpServer.GetStream());
                string check = srReceiver.ReadLine();
                while (HomeClient.Connected)
                {
                    string Respon = srReceiver.ReadLine();
                    if (Respon[0] != '1')
                    {
                        QuesContent = Respon.Split(new char[] { '|' });
                        if (QuesContent[0] == "que")
                        {
                            ResetButton();
                            Invoke(new Action(() =>
                            {
                                ResetTimer(timer1);
                            }));

                            txtQuestion.Text = QuesContent[5];
                            btnA.Text = QuesContent[6];
                            btnB.Text = QuesContent[7];
                            if (QuesContent[8] == "")
                            {
                                btnC.Text = "C.";
                                btnC.Enabled = false;
                            }
                            else btnC.Text = QuesContent[8];
                            if (QuesContent[9] == "")
                            {
                                btnD.Text = "D.";
                                btnD.Enabled = false;
                            }
                            else btnD.Text = QuesContent[9];
                            try
                            {
                                if (QuesContent[12] == "img")
                                {
                                    //byte[] bytes = 
                                }
                            }
                        }
                        else if (QuesContent[0] == "rak")
                        {
                            btnResult.Enabled = true;
                            //MessageBox.Show(Respon);
                            if (QuesContent[2] == HomeClient.UserName)
                            {
                                MyResult = Respon;
                                if (QuesContent[4]=="1")
                                {
                                    Rank1Result = Respon;
                                }
                                else if(QuesContent[4]=="2")
                                {
                                    Rank2Result = Respon;
                                }
                            }   
                            else if (QuesContent[4]=="1")
                            {
                                Rank1Result = Respon;
                            }
                            else if (QuesContent[4] == "2")
                            {
                                Rank2Result = Respon;
                            }
                            else if (QuesContent[4] == "3")
                            {
                                Rank3Result = Respon;
                            }
                        }
                        else
                        {
                            MessageBox.Show(Respon);
                        }
                    }
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }
        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }
        private void AddQuestionList(int i, string ans)
        {
            QuestionList[i] = new Question();
            QuestionList[i].QuestionText = QuesContent[5];
            QuestionList[i].AnsA = QuesContent[6];
            QuestionList[i].AnsB = QuesContent[7];
            QuestionList[i].AnsC = QuesContent[8];
            QuestionList[i].AnsD = QuesContent[9];
            QuestionList[i].Choice = ans;
            QuestionList[i].RightAns = QuesContent[10];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form Result = new ResultClient();
            Result.Show();
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            TimeElapsed = TimeElapsed + 15;
            progressBar1.PerformStep();
        }
        private void ResetTimer(System.Windows.Forms.Timer timer)
        {
            TimeElapsed = 0;
            progressBar1.Value = 0;
            timer.Stop();
            timer.Start();
            counter = 10;
            RunTimer();
        }
        private bool SendAnswer(string ans)
        {
            if (ans == QuesContent[10] && (progressBar1.Value < progressBar1.Maximum))
            {
                swSender = new StreamWriter(HomeClient.tcpServer.GetStream());
                swSender.WriteLine("ans" + '|' + txtRoomID.Text + '|' + txtUserID.Text + '|' + QuesContent[4] + '|' + (TimeElapsed / 1000).ToString());
                swSender.Flush();
                swSender = null;
                return true;
            }
            else
            {
                swSender = new StreamWriter(HomeClient.tcpServer.GetStream());
                swSender.WriteLine("ans" + '|' + txtRoomID.Text + '|' + txtUserID.Text + '|' + QuesContent[4] + '|' + "0");
                swSender.Flush();
                swSender = null;
                return false;
            }
            //MessageBox.Show((TimeElapsed/100).ToString());
        }
        private void ResetButton()
        {
            btnA.Enabled = true;
            btnB.Enabled = true;
            btnC.Enabled = true;
            btnD.Enabled = true;
            btnA.BackColor = SystemColors.ActiveCaption;
            btnB.BackColor = SystemColors.ActiveCaption;
            btnC.BackColor = SystemColors.ActiveCaption;
            btnD.BackColor = SystemColors.ActiveCaption;
        }
        private void ShowAnswer()
        {
            if (QuesContent[10] == "Đáp án: A")
            {
                btnA.BackColor = Color.Green;
            }
            else if (QuesContent[10] == "Đáp án: B")
            {
                btnB.BackColor = Color.Green;
            }
            else if (QuesContent[10] == "Đáp án: C")
            {
                btnC.BackColor = Color.Green;
            }
            else if (QuesContent[10] == "Đáp án: B")
            {
                btnD.BackColor = Color.Green;
            }
        }
        private void btnA_Click(object sender, EventArgs e)
        {
            //txtUserID, roomID, stt câu hỏi ,thời gian trả lời câu đó (đúng thì số dương, sai thì 0)
            btnA.BackColor = Color.Green;
            btnA.Enabled = false;
            btnB.Enabled = false;
            btnC.Enabled = false;
            btnD.Enabled = false;
            string ans = "Đáp án: A";
            i = i + 1;
            AddQuestionList(i, ans);
            if (SendAnswer(ans))
            {
                btnA.BackColor = Color.Green;
            }
            else btnA.BackColor = Color.Red;
            ShowAnswer();
        }

        private void btnB_Click(object sender, EventArgs e)
        {
            btnB.BackColor = Color.Green;
            btnA.Enabled = false;
            btnB.Enabled = false;
            btnC.Enabled = false;
            btnD.Enabled = false;
            string ans = "Đáp án: B";
            i = i + 1;
            AddQuestionList(i, ans);
            if (SendAnswer(ans))
            {
                btnB.BackColor = Color.Green;
            }
            else btnB.BackColor = Color.Red;
            ShowAnswer();
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            btnA.Enabled = false;
            btnB.Enabled = false;
            btnC.Enabled = false;
            btnD.Enabled = false;
            string ans = "Đáp án: C";
            i = i + 1;
            AddQuestionList(i, ans);
            if (SendAnswer(ans))
            {
                btnC.BackColor = Color.Green;
            }
            else btnC.BackColor = Color.Red;
            ShowAnswer();
        }

        private void btnD_Click(object sender, EventArgs e)
        {
            btnD.BackColor = Color.Green;
            btnA.Enabled = false;
            btnB.Enabled = false;
            btnC.Enabled = false;
            btnD.Enabled = false;
            string ans = "Đáp án: D";
            i = i + 1;
            AddQuestionList(i, ans);
            if (SendAnswer(ans))
            {
                btnD.BackColor = Color.Green;
            }
            else btnD.BackColor = Color.Red;
            ShowAnswer();
        }

        private void btnResult_Click(object sender, EventArgs e)
        {
            ResultClient ResultForm = new ResultClient();
            ResultForm.Show();
        }
    }
}

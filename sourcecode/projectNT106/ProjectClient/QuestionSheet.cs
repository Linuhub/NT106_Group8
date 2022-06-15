using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
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
        private int counter = 20;
        public static Question[] QuestionList = new Question[20];
        private int i = -1;
        public static string MyResult="";
        public static string Rank1Result="";
        public static string Rank2Result="";
        public static string Rank3Result="";
        public static int TotalRightAns=0;
        public static int myAvt = 0;
        public static int avtTop1 = 0;
        public static int avtTop2 = 0;
        public static int avtTop3 = 0;
        private bool btnAClicked=false;
        private bool btnBClicked=false;
        private bool btnCClicked=false;
        private bool btnDClicked=false;
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
            {
                aTimer.Stop();
                btnA.Enabled = false;
                btnB.Enabled = false;
                btnC.Enabled = false;
                btnD.Enabled = false;             
            }    
            LabelTimeLeft.Text = counter.ToString();
            if (counter == 0 && btnAClicked == false && btnBClicked == false && btnCClicked == false && btnDClicked == false)
            {
                string ans = "";
                i++;
                AddQuestionList(i, ans);
                SendAnswer(ans);
            }
        }
        private void UpdateQuestionSheet(string strMessage)
        {
            MessageBox.Show("Update sheet: " + strMessage + "/r/n");
        }

        public QuestionSheet(string respon)
        {
            InitializeComponent();
            cmt = respon;
            btnResult.Enabled = false;  
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
            Form.CheckForIllegalCrossThreadCalls = false;
            txtQues = cmt;         
            txtUserID.Text = HomeClient.UserName;
            txtRoomID.Text = HomeClient.RoomID;
            thrMessaging = new Thread(ReceiveMessage);
            thrMessaging.Start();
        }
       
        public static string ReceivedAvt(int avt)
        {
            avt++;
            if (avt <= 9)
            {
                return "0" + avt.ToString();
            }
            else
            {
                return avt.ToString();
            }            
            
        }
        private void ReceiveMessage()
        {
            try
            {            
                srReceiver = new StreamReader(HomeClient.tcpServer.GetStream());
                string check = srReceiver.ReadLine();
                string[] addSuccess = check.Split(new char[] { '|' });
                myAvt = int.Parse(addSuccess[1]);
                                
                string Respon = srReceiver.ReadLine();
                while (HomeClient.Connected)
                {
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
                            int indx = int.Parse(QuesContent[3]) + 1;
                            txtQuestion.Text = "Câu số " + indx.ToString();
                            txtQuestion.Text += ": " + QuesContent[5].Substring(12);
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
                            
                            if (QuesContent[12] == "img")
                            {
                                Thread thr = new Thread(showImg);
                                thr.Start();
                            }
                            
                        }
                        else if (QuesContent[0] == "rak")
                        {
                            btnResult.BackColor = Color.Green;
                            btnResult.Enabled = true;
                            //MessageBox.Show(HomeClient.UserName + " rev:" + Respon);
                            if (QuesContent[2] == HomeClient.UserName && MyResult == "")
                            {
                                MyResult = Respon;
                                //MessageBox.Show(HomeClient.UserName + " rev:" + MyResult);
                                if (QuesContent[4] == "1")
                                {
                                    Rank1Result = Respon;
                                    avtTop1 = int.Parse(QuesContent[5]);
                                    //MessageBox.Show(HomeClient.UserName + " rev:" + Rank1Result);
                                }
                                else if (QuesContent[4] == "2")
                                {
                                    avtTop2 = int.Parse(QuesContent[5]);
                                    Rank2Result = Respon;
                                }
                                else if (QuesContent[4] == "3")
                                {
                                    avtTop3 = int.Parse(QuesContent[5]);
                                    Rank3Result = Respon;
                                }
                            }
                            else if (QuesContent[4] == "1")
                            {
                                avtTop1 = int.Parse(QuesContent[5]);
                                Rank1Result = Respon;
                            }
                            else if (QuesContent[4] == "2")
                            {
                                avtTop2 = int.Parse(QuesContent[5]);
                                Rank2Result = Respon;
                            }
                            else if (QuesContent[4] == "3")
                            {
                                avtTop3 = int.Parse(QuesContent[5]);
                                Rank3Result = Respon;
                            }
                        }
                        
                    }
                    Respon = srReceiver.ReadLine();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }
        
        public void showImg()
        {
            Image img = Image.FromFile(Application.StartupPath + "\\Image_ThiLaiXe/" + QuesContent[4] + ".png");
            ptbImage.Image = img;
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
            if (QuesContent[12]=="img")
            {
                QuestionList[i].QuestionPic= Application.StartupPath + "\\Image_ThiLaiXe/" + QuesContent[4] + ".png";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form Result = new ResultClient();
            Result.Show();
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            TimeElapsed = TimeElapsed + 15;
        }
        private void ResetTimer(System.Windows.Forms.Timer timer)
        {
            TimeElapsed = 0;
            timer.Stop();
            timer.Start();
            counter = 20;
            RunTimer();
        }
        private bool SendAnswer(string ans)
        {
            if (ans == QuesContent[10] && (counter>0))
            {
                swSender = new StreamWriter(HomeClient.tcpServer.GetStream());
                swSender.WriteLine("ans" + '|' + txtRoomID.Text + '|' + txtUserID.Text + '|' + QuesContent[4] + '|' + (TimeElapsed / 1000).ToString());
                swSender.Flush();
                swSender = null;
                TotalRightAns++;
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
            btnAClicked = false;
            btnBClicked = false;
            btnCClicked = false;
            btnDClicked = false;
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
            else if (QuesContent[10] == "Đáp án: D")
            {
                btnD.BackColor = Color.Green;
            }
        }
        private void btnA_Click(object sender, EventArgs e)
        {
            btnAClicked = true;
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
            btnBClicked = true;
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
            btnCClicked = true;
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
            btnDClicked = true;
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnInstruction_Click(object sender, EventArgs e)
        {
            Form instruction = new Instruction();
            instruction.Show();
        }
    }
}

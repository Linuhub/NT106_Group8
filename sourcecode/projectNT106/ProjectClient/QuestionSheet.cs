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

        private void UpdateQuestionSheet(string strMessage)
        {
            MessageBox.Show("Update sheet: " + strMessage + "\r\n");
        }
        
        public QuestionSheet(string respon)
        {
            InitializeComponent();
            cmt = respon;
            button1.Hide();
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
            

            thrMessaging = new Thread(ReceiveMessage);
            thrMessaging.Start();
        }
        private void ReceiveMessage()
        {
            try
            {

                srReceiver = new StreamReader(HomeClient.tcpServer.GetStream());
                txtQues = srReceiver.ReadLine();
                while (HomeClient.Connected)
                {
                    string Respon = srReceiver.ReadLine();
                    if (Respon[0] != '1')
                    {
                        Invoke(new Action(() =>
                        {
                            ResetTimer(timer1);
                        }));
                        QuesContent = Respon.Split(new char[] { '|' });
                        btnA.Enabled = true;
                        btnB.Enabled = true;
                        btnC.Enabled = true;
                        btnD.Enabled = true;
                        ResetColor();
                        txtUserID.Text = HomeClient.UserName;
                        txtRoomID.Text = HomeClient.RoomID;
                        txtQuestion.Text = QuesContent[4];
                        btnA.Text = QuesContent[5];
                        btnB.Text = QuesContent[6];
                        if (QuesContent[7] == "")
                        {
                            btnC.Text = "C.";
                            btnC.Enabled = false;
                        }
                        else btnC.Text = QuesContent[7];
                        if (QuesContent[8] == "")
                        {
                            btnD.Text = "D.";
                            btnD.Enabled = false;
                        }
                        else btnD.Text = QuesContent[8];
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            //timer1.Start();
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            TimeElapsed = TimeElapsed + 1.5;
            progressBar1.PerformStep();
        }
        private void ResetTimer(System.Windows.Forms.Timer timer)
        {
            TimeElapsed = 0;        
            progressBar1.Value = 0;
            timer.Stop();
            timer.Start();
        }
        private void SendAnswer(string ans)
        {
            if (ans == QuesContent[9] && (TimeElapsed / 100) <= 10)
            {
                swSender = new StreamWriter(HomeClient.tcpServer.GetStream());
                swSender.WriteLine("ans" + '|' + txtUserID.Text + '|' + txtRoomID.Text + '|' + QuesContent[3] + '|' + (TimeElapsed / 100).ToString());
                swSender.Flush();
                swSender = null;
            }
            else
            {
                swSender = new StreamWriter(HomeClient.tcpServer.GetStream());
                swSender.WriteLine("ans" + '|' + txtUserID.Text + '|' + txtRoomID.Text + '|' + QuesContent[3] + '|' + "0");
                swSender.Flush();
                swSender = null;
            }
            //MessageBox.Show((TimeElapsed/100).ToString());
        }
        private void ResetColor()
        {
            btnA.BackColor = SystemColors.ActiveCaption;
            btnB.BackColor = SystemColors.ActiveCaption;
            btnC.BackColor = SystemColors.ActiveCaption;
            btnD.BackColor = SystemColors.ActiveCaption;
        }

        private void btnA_Click(object sender, EventArgs e)
        {
            btnA.BackColor = Color.SteelBlue;
            btnA.Enabled = false;
            btnB.Enabled = false;
            btnC.Enabled = false;
            btnD.Enabled = false;
            string ans = "Đáp án: A";
            SendAnswer(ans);
        }

        private void btnB_Click(object sender, EventArgs e)
        {
            btnB.BackColor = Color.SteelBlue;
            btnA.Enabled = false;
            btnB.Enabled = false;
            btnC.Enabled = false;
            btnD.Enabled = false;
            string ans = "Đáp án: B";
            SendAnswer(ans);
        }
        private void btnC_Click(object sender, EventArgs e)
        {
            btnC.BackColor = Color.SteelBlue;
            btnA.Enabled = false;
            btnB.Enabled = false;
            btnC.Enabled = false;
            btnD.Enabled = false;
            string ans = "Đáp án: C";
            SendAnswer(ans);
        }
        private void btnD_Click(object sender, EventArgs e)
        {
            btnD.BackColor = Color.SteelBlue;
            btnA.Enabled = false;
            btnB.Enabled = false;
            btnC.Enabled = false;
            btnD.Enabled = false;
            string ans = "Đáp án: D";
            SendAnswer(ans);
        }
    }
}

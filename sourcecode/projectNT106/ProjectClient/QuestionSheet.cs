using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectClient
{
    public partial class QuestionSheet : Form
    {
        private string txtQues;
        private string[] QuesContent;
        private StreamReader srReceiver = new StreamReader(HomeClient.tcpServer.GetStream());
        private StreamWriter swSender;
        public string cmt;
        bool _isBoxOptionOpen = false;

        private void UpdateQuestionSheet(string strMessage)
        {
            MessageBox.Show("Update sheet: " + strMessage + "\r\n");
        }
        
        public QuestionSheet(string respon)
        {
            InitializeComponent();
            cmt = respon;
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
            this.Invoke(new HomeClient.UpdateLogCallback(this.UpdateQuestionSheet), new object[] { srReceiver.ReadLine() });
            txtQues = cmt;
            if (cmt == "1")
            {
                MessageBox.Show("Received: " + txtQues);                    
            }
            ReceiveMessage();
        }
        private void ReceiveMessage()
        {
            try
            {
                
                while (HomeClient.Connected)
                {

                    this.Invoke(new HomeClient.UpdateLogCallback(this.UpdateQuestionSheet), new object[] { srReceiver.ReadLine() });
                    txtQues = srReceiver.ReadLine();
                    string Respon = srReceiver.ReadLine();

                    if (Respon[0] != '1')                    
                    {
                        QuesContent = txtQues.Split(new char[] { '|' });
                        txtUserID.Text = HomeClient.UserName;
                        txtRoomID.Text = HomeClient.RoomID;
                        txtQuestion.Text = QuesContent[4];
                        btnA.Text = "A." + QuesContent[5];
                        btnB.Text = "B." + QuesContent[6];
                        if (QuesContent[7] == "")
                        {
                            btnC.Text = "C.";
                            btnC.Enabled = false;
                        }
                        else btnC.Text = "C." + QuesContent[7];
                        if (QuesContent[8] == "")
                        {
                            btnD.Text = "D.";
                            btnD.Enabled = false;
                        }
                        else btnD.Text = "D." + QuesContent[8];
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
            Form result = new ResultClient();
            result.ShowDialog();
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            progressBar1.PerformStep();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            timer1.Start();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            timer1.Start();

        }

        
    }
}

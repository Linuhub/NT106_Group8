using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;

namespace projectNT106
{
    public partial class Room : Form
    {
        public IPAddress localIP;
        public static string RoomID;
        public static string IDRoomUser = "";
        public static string IDUserTemp = "";
        private string CreatorID;
        private string QuestionPack;
        public static int numParticipant;
        public static bool isFull = false;
        public static bool isLock = false;
        String[] paths = { };
        private CheckBox[] cbs = new CheckBox[20];
        public Channel mainServer;
        public OleDbConnection cnn;
        public OleDbDataAdapter dar;
        public DataTable dt;
        public OleDbCommandBuilder cbr;
        public System.Timers.Timer time;
        public static InforUser[] infoUsers = new InforUser[10];
        private delegate void UpdateStatusCallback(string strMessage);

        public Room(IPAddress IPLocal, string Room, string quesPack, string NumParticipant)
        {
            InitializeComponent();
            localIP = IPLocal;
            RoomID = Room;
            CreatorID = "Server";
            QuestionPack = quesPack;
            numParticipant = int.Parse(NumParticipant);
        }
        public void UpdateStatus(string mes)
        {
            Random R = new Random();
            int icon = R.Next(1, 12);
            listView1.Items.Add("    " + mes, icon);
            Room.infoUsers[Channel.htConnections.Count - 1].setAvatar(icon);
            this.txtNumMember.Text = Channel.htUsers.Count.ToString();

        }
       
        public void mainServer_StatusChanged(object sender, StatusChangedEventArgs e)
        {                     
            this.Invoke(new UpdateStatusCallback(this.UpdateStatus), new object[] { IDUserTemp });
        
        }
        void CreateCheckBoxGroup()
        {
            for (int i = 0; i < 20; i++)
            {
                cbs[i] = new CheckBox();
                cbs[i].Text = (i + 1).ToString();
                cbs[i].Size = new Size(30, 30);
                cbs[i].TextAlign = ContentAlignment.MiddleCenter;
                cbs[i].Appearance = Appearance.Button;
                cbs[i].Enabled = false;
                flowLayoutPanel1.Controls.Add(cbs[i]);
                
            }
        }
        private void Room_Load_1(object sender, EventArgs e)
        {

            labelIDRoom.Text = "ID Phòng: " + RoomID;
            labelIP.Text = "IP Server: " + localIP.ToString();

            listView1.View = View.Details;

            listView1.Columns.Add("Người tham gia", 250);

            populate();

            CreateCheckBoxGroup();
            

            // Đưa dữ liệu lên
            

            cnn = new OleDbConnection();
            cnn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=DeThiLaiXe_3Part.mdb";
            cnn.Open();
            if (QuestionPack == "Câu hỏi kiến thức luật")
            {
                dar = new OleDbDataAdapter("select * from tbl_cauhoikienthucluat", cnn);
            }
            else if (QuestionPack == "Câu hỏi biển báo")
            {
                dar = new OleDbDataAdapter("select * from tbl_cauhoibienbao", cnn);
            }
            else if (QuestionPack == "Câu hỏi phần sa hình")
            {
                dar = new OleDbDataAdapter("select * from tbl_cauhoisahinh", cnn);
            }
            dt = new DataTable();
            dar.Fill(dt);
        }

        private void populate()
        {
            ImageList imgs = new ImageList();
            imgs.ImageSize = new Size(25, 25);

            paths = Directory.GetFiles("D:/UIT/HK4/NT106/Project/NT106_Group8/icon"); 


            try
            {
                foreach (String path in paths)
                {
                    imgs.Images.Add(Image.FromFile(path));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            listView1.SmallImageList = imgs;

            

            // Tạo phòng
            try
            {
                ListViewItem item = new ListViewItem();                
                mainServer = new Channel(localIP);
                
                Channel.StatusChanged += new StatusChangedEventHandler(mainServer_StatusChanged);
                mainServer.StartListening();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }


        }
        
        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            flowLayoutPanel1.BackColor = Color.FromArgb(100, 0, 0, 0);

        }

        public int second = 0;
        public int showAnswerTime = 0;
        public static int index = 0;

        // Bắt đầu thi
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (Channel.htUsers.Count == 0)
            {
                MessageBox.Show("The room is empty!");
                return;
            }
            btnStart.Enabled = false;
            button2.Enabled = false;
            time = new System.Timers.Timer();
            time.Interval = 1000; //1s
            time.Elapsed += OnTimeEvent;
            time.Start();
            
        }

        // Xử lý thời gian
        public void OnTimeEvent(object sender, System.Timers.ElapsedEventArgs e)
        {
            Invoke(new Action(() =>
            {
                if (second != 2)
                {
                    if (second == 0)
                    {
                        cbs[index].Checked = true;
                        SendQuestion();
                    }
                    second++;
                    textBox2.Text = second.ToString();
                }
                else if (showAnswerTime != 3)
                {
                    showAnswerTime++;
                    textBox2.Text = showAnswerTime.ToString();                 
                }
                else
                {
                    showAnswerTime = 0;
                    second = 0;
                    if (index == 20)
                    {
                        time.Stop();
                        MessageBox.Show("Finish!");
                        showResult();
                        Form finalRank = new RankingServer();
                        finalRank.Show();
                    }
                }

            }));
            
        }
        void CheckCodeQuestion(ref int start, ref int end)
        {
            if (QuestionPack == "Câu hỏi kiến thức luật")
            {
                start = 0;
                end = 99;
            }
            else if (QuestionPack == "Câu hỏi biển báo")
            {
                start = 0;
                end = 64;
            }
            else
            {
                start = 0;
                end = 34;
            }
        }
        // Gửi câu hỏi
        public void SendQuestion()
        {
            
            string question = "";
            List<int> listNumbers = new List<int>();
            int number;
            int startQuestion = 0;
            int endQuestion = 0;

            CheckCodeQuestion(ref startQuestion, ref endQuestion);
            
            Random rand = new Random();
            for (int i = 0; i < 20; i++)
            {
                do
                {
                    number = rand.Next(startQuestion, endQuestion);
                } while (listNumbers.Contains(number));
                listNumbers.Add(number);
                
            }
            foreach (DataColumn column in dt.Columns)
            {
                question += dt.Rows[listNumbers[index]][column].ToString() + '|';

            }
            string dataQuestion = "que" + '|' + RoomID + '|' + CreatorID + '|'
                                + index.ToString() + '|' + question;
            if (QuestionPack != "Câu hỏi kiến thức luật")
            {
                dataQuestion += '|' + "img";
            }
            else
            {
                dataQuestion += '|' + "noImg";
            }
            StreamWriter swSender;
            TcpClient[] tcpClients = new TcpClient[Channel.htUsers.Count];
            Channel.htUsers.Values.CopyTo(tcpClients, 0);
            for (int i = 0; i < tcpClients.Length; i++)
            {
                try
                {
                    if (dataQuestion.Trim() == "" || tcpClients[i] == null)
                    {
                        continue;
                    }
                    swSender = new StreamWriter(tcpClients[i].GetStream());
                    swSender.WriteLine(dataQuestion);
                    swSender.Flush();
                    swSender = null;
                }
                catch
                {
                    MessageBox.Show("error");
                }
            }

            index++;
        }
        // Xử lý kết quả
        public void showResult()
        {
            int t = Channel.htUsers.Count;
            int[] scoreArr = new int[t];
            
            // Tính điểm cho từng thành viên
            for (int i = 0; i < t; i++)
            {
                try
                {
                    Room.infoUsers[i].calculateMark();
                    scoreArr[i] = Room.infoUsers[i].getMark();
                }
                catch (Exception ex) { }
            }

            // Sắp xếp lại điểm
            for (int i = 0; i < t; i++)
            {
                for (int j = i; j < t; j++)
                {
                    if (scoreArr[j] > scoreArr[i])
                    {
                        (scoreArr[i], scoreArr[j]) = (scoreArr[j], scoreArr[i]);
                    }
                }
            }

            for (int i = 0; i < t; i++)
            {
                MessageBox.Show(scoreArr[i].ToString());
            }

            // Xếp hạng cho từng thành viên
            for (int i = 0; i < t; i++)
            {
                for (int j = 0; j < t; j++)
                {
                    if (Room.infoUsers[j].getRank() == 0 && scoreArr[i] == Room.infoUsers[j].getMark())
                    {
                        Room.infoUsers[j].setRank(i + 1);
                        break;
                    }
                }
            }
            

            for (int i = 0; i < Channel.htUsers.Count; i++)
            {
                try
                {
                    SendTopRank(i);
                    SendUserRank(i);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
        public void SendTopRank(int index)
        {
            for (int i = 0; i < 3; i++)
            {
                try
                {
                    StreamWriter swSender;
                    TcpClient[] tcpClients = new TcpClient[Channel.htUsers.Count];
                    Channel.htUsers.Values.CopyTo(tcpClients, 0);
                    swSender = new StreamWriter(tcpClients[index].GetStream());
                    string rankTopX = "";

                    for (int j = 0; j < Channel.htUsers.Count; j++)
                    {
                        if (Room.infoUsers[j].getRank() == i + 1)
                        {
                            rankTopX = "rak" + '|' + RoomID + '|' + Room.infoUsers[j].getIDUser() + '|' +                                                                            
                                        Room.infoUsers[j].getMark().ToString() + '|' +
                                        Room.infoUsers[j].getRank().ToString() + '|' +
                                        Room.infoUsers[j].getAvt().ToString() ;
                            swSender.WriteLine(rankTopX);
                            swSender.Flush();
                            swSender = null;
                            MessageBox.Show(Room.infoUsers[index].getIDUser() + rankTopX);
                            break;
                        }

                    }

                }
                catch (Exception ex) { }
            }
        }
        public void SendUserRank(int index)
        {
            StreamWriter swSender;
            TcpClient[] tcpClients = new TcpClient[Channel.htUsers.Count];
            Channel.htUsers.Values.CopyTo(tcpClients, 0);
            swSender = new StreamWriter(tcpClients[index].GetStream());
            string rank = "rak" + '|' + RoomID + '|' + Room.infoUsers[index].getIDUser() + '|' +
                             Room.infoUsers[index].getMark().ToString() + '|' + 
                             Room.infoUsers[index].getRank().ToString() + '|' +
                             Room.infoUsers[index].getAvt().ToString();
            swSender.WriteLine(rank);
            swSender.Flush();
            swSender = null;
            MessageBox.Show(Room.infoUsers[index].getIDUser() + rank);

        }        
        private void btnLock_Click(object sender, EventArgs e)
        {
            if (!isLock)
            {
                isLock = true;
                btnLock.Text = "Unlock";
            } 
            else
            {
                isLock = false;
                btnLock.Text = "Lock";
            }
        }

        private void buttonX_Click(object sender, EventArgs e)
        {
            string aqr = sender.ToString().Split(',')[1];
            string tre = aqr.Substring(7);
            MessageBox.Show(tre);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNumMember_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        

        private void labelIDRoom_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void roundedPanel1_Paint(object sender, PaintEventArgs e)
        {
            roundedPanel1.BottomColor = Color.Transparent;
            roundedPanel1.TopColor = Color.LightBlue;
        }
    }

    public class StatusChangedEventArgs : EventArgs
    {
        private string EventMsg;
        public string EventMessage
        {
            get
            {
                return EventMsg;
            }
            set
            {
                EventMsg = value;
            }
        }
        public StatusChangedEventArgs(string strEventMsg)
        {
            EventMsg = strEventMsg;
        }
    }
    
    public delegate void StatusChangedEventHandler(object sender, StatusChangedEventArgs e);

    public class Channel
    {
        public static Hashtable htUsers = new Hashtable(30);
        public static Hashtable htConnections = new Hashtable(30);
        public static int index = 0;
        private IPAddress ipAddress;
        public static TcpClient tcpClient;
        public static event StatusChangedEventHandler StatusChanged;
        private static StatusChangedEventArgs e;
        public Channel(IPAddress address)
        {
            ipAddress = address;
        }
        private Thread thrListener;
        private TcpListener tlsClient;
        bool ServRunning = false;
        public static void AddUser(TcpClient tcpUser, string strUsername)
        {
            Channel.htUsers.Add(strUsername, tcpUser);
            Channel.htConnections.Add(tcpUser, strUsername);
            index++;

            Room.infoUsers[htConnections.Count - 1] = new InforUser(Room.RoomID, strUsername);
            int i = 0;
            while (true)
            {
                if (Room.infoUsers[i] != null)
                {
                    i++;
                }
                else
                {
                    break;
                }
            }
            SendAdminMessage(htConnections[tcpUser] + "|");
            if (Room.numParticipant == Channel.htConnections.Count)
            {
                Room.isFull = true;
            }
        }
        
        public static void RemoveUser(TcpClient tcpUser)
        {
            if (htConnections[tcpUser] != null)
            {
                Channel.htUsers.Remove(Channel.htConnections[tcpUser]);
                Channel.htConnections.Remove(tcpUser);
            }
        }
        public static void OnStatusChanged(StatusChangedEventArgs e)
        {
            StatusChangedEventHandler statusHandler = StatusChanged;
            if (statusHandler != null)
            {
                statusHandler(null, e);
            }
        }
        public static void SendAdminMessage(string Message)
        {
            StreamWriter swSenderSender;
            e = new StatusChangedEventArgs(Message);
            OnStatusChanged(e);
            TcpClient[] tcpClients = new TcpClient[Channel.htUsers.Count];
            Channel.htUsers.Values.CopyTo(tcpClients, 0);
            for (int i = 0; i < tcpClients.Length; i++)
            {
                try
                {
                    if (Message.Trim() == "" || tcpClients[i] == null)
                    {
                        continue;
                    }
                    swSenderSender = new StreamWriter(tcpClients[i].GetStream());
                    Message += Room.infoUsers[htConnections.Count - 1].getAvt().ToString();
                    swSenderSender.WriteLine(Message);
                    swSenderSender.Flush();
                    swSenderSender = null;
                }
                catch
                {
                    RemoveUser(tcpClients[i]);
                }
            }
        }
        


        public void StartListening()
        {
            IPAddress ipaLocal = ipAddress;
            tlsClient = new TcpListener(ipaLocal, 80);
            tlsClient.Start();
            ServRunning = true;
            thrListener = new Thread(KeepListening);
            thrListener.Start();
        }

        private void KeepListening()
        {
            while (ServRunning == true)
            {
                tcpClient = tlsClient.AcceptTcpClient();
                Connection newConnection = new Connection(tcpClient);
                    
            }
        }
    }

    public class Connection
    {
        TcpClient tcpClient;
        private Thread thrSender;
        private StreamReader srReceiver;
        private StreamWriter swSender;
        private string instruction;
        private string strResponse;
        private int indexQues;
        private double timeAnswer;
        public bool _isExists = false;
        private static StatusChangedEventArgs e;
        public Connection(TcpClient tcpCon)
        {
            tcpClient = tcpCon;
            thrSender = new Thread(AcceptClient);
            thrSender.Start();
        }

        private void CloseConnection()
        {
            tcpClient.Close();
            srReceiver.Close();
            swSender.Close();
        }

        public void splitID(string message)
        {
            string[] text = message.Split('|');
            instruction = text[0];
            Room.IDRoomUser = text[1];
            Room.IDUserTemp = text[2];
            /* ADD|ABCDE|1234 */
            try
            {
                indexQues = Int32.Parse(text[3]);
                timeAnswer = Double.Parse(text[4]);
            }
            catch (Exception ex){}
        }
        private void AcceptClient()
        {
            srReceiver = new System.IO.StreamReader(tcpClient.GetStream());
            swSender = new System.IO.StreamWriter(tcpClient.GetStream());      
            strResponse = srReceiver.ReadLine();
            splitID(strResponse);
            if (instruction == "add")
            {
                if (Room.IDRoomUser != Room.RoomID)
                {
                    swSender.WriteLine("0|ID Room is not valid.");
                    swSender.Flush();
                    CloseConnection();
                    return;
                }
                else if (Room.IDRoomUser != "")
                {
                    if (Channel.htUsers.Contains(Room.IDUserTemp) == true)
                    {
                        swSender.WriteLine("0|This username already exists.");
                        swSender.Flush();
                        CloseConnection();
                        _isExists = true;
                        return;
                    }
                    else if (Room.isLock)
                    {
                        swSender.WriteLine("0|This room is lock.");
                        swSender.Flush();
                        CloseConnection();
                        return;
                    }
                    else if (Room.isFull)
                    {
                        swSender.WriteLine("0|This room is full.");
                        swSender.Flush();
                        CloseConnection();
                        return;
                    }
                    else
                    {
                        swSender.WriteLine("1");
                        swSender.Flush();
                        Channel.AddUser(tcpClient, Room.IDUserTemp);                        
                    }
                    
                }
                else
                {
                    CloseConnection();
                    return;
                }
            }
            
            // Lắng nghe đáp án
            try
            {
                while ((strResponse = srReceiver.ReadLine()) != "")
                {
                    if (strResponse == null)
                    {
                        Channel.RemoveUser(tcpClient);
                    }
                    else
                    {
                        splitID(strResponse);
                        if (instruction == "ans")
                        {
                            for (int i = 0; i < Channel.htConnections.Count; i++)
                            {
                                if (Room.IDRoomUser == Room.infoUsers[i].getIDRoom() && Room.IDUserTemp == Room.infoUsers[i].getIDUser())
                                {
                                    Room.infoUsers[i].receiveUserAnswer(Room.index, timeAnswer);
                                }
                            }
                        }
                        //Channel.SendMessage(currUser, strResponse);
                    }
                }
            }
            catch
            {
                Channel.RemoveUser(tcpClient);
            }
        }
    }
        
    
}

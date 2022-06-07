using System;
using System.Collections;
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
        public static string RoomID;
        public static string IDRoomUser = "";
        public static string IDUserTemp = "";
        private string CreatorID;
        private string QuestionPack;
        public static bool isFull = false;
        String[] paths = { };
        public Channel mainServer;
        public OleDbConnection cnn;
        public OleDbDataAdapter dar;
        public DataTable dt;
        public OleDbCommandBuilder cbr;
        public System.Timers.Timer time;
        public static InforUser[] infoUsers = new InforUser[10];
        private delegate void UpdateStatusCallback(string strMessage);
        

        public Room(string Room, string Creator, string quesPack)
        {
            InitializeComponent();
            RoomID = Room;
            CreatorID = Creator;
            QuestionPack = quesPack;
        }
        public void UpdateStatus(string mes)
        {
            Random R = new Random();
            int icon = R.Next(1, 12);
            listView1.Items.Add("    " + mes, icon);
            Room.infoUsers[Channel.htConnections.Count - 1].setAvatar(paths[icon]);
            this.txtNumMember.Text = Channel.htUsers.Count.ToString();

        }
       
        public void mainServer_StatusChanged(object sender, StatusChangedEventArgs e)
        {                     
            this.Invoke(new UpdateStatusCallback(this.UpdateStatus), new object[] { IDUserTemp });
        
        }
        private void Room_Load_1(object sender, EventArgs e)
        {

            labelIDRoom.Text = "ID Phòng: " + CreateRoom.IDRoom;

            listView1.View = View.Details;

            listView1.Columns.Add("Người tham gia", 250);

            populate();

            for (int i = 0; i < 20; i++)
            {
                CheckBox cb = new CheckBox();
                cb.Text = (i + 1).ToString();
                cb.Size = new Size(30, 30);
                cb.TextAlign = ContentAlignment.MiddleCenter;
                cb.Appearance = Appearance.Button;
                flowLayoutPanel1.Controls.Add(cb);
                
            }
            

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
                IPAddress ipAddr = IPAddress.Parse("127.0.0.1");
                mainServer = new Channel(ipAddr);
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
        int index = 0;

        // Bắt đầu thi
        private void btnStart_Click(object sender, EventArgs e)
        {
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
                if (second != 10)
                {
                    if (second == 0)
                    {
                        SendQuestion();
                    }
                    second++;
                    textBox2.Text = second.ToString();                    
                }
                else if (showAnswerTime != 5)
                {
                    showAnswerTime++;
                    textBox2.Text = showAnswerTime.ToString();
                }
                else
                {
                    showAnswerTime = 0;
                    second = 0;
                    if (index == 2)
                    {
                        time.Stop();
                        MessageBox.Show("Finish!");
                        showResult();
                    }
                }
            }));
        }
    
        // Xử lý kết quả
        public void showResult()
        {
            int t = Channel.htUsers.Count;
            int[] ranking = new int[t];

            // Tính điểm cho từng thành viên
            for (int i = 0; i < t; i++)
            {
                try
                {
                    Room.infoUsers[i].calculateMark();
                    ranking[i] = int.Parse(Room.infoUsers[i].getMark());
                }
                catch (Exception ex) { }
            }

            // Sắp xếp lại điểm
            for (int i = 0; i < t; i++)
            {
                for (int j = i; j < t; j++)
                {
                    if (ranking[j] > ranking[i])
                    {
                        (ranking[i], ranking[j]) = (ranking[j], ranking[i]);
                    }
                }
            }
            
            for (int i = 0; i < t; i++)
            {
                MessageBox.Show(ranking[i].ToString());
            }

            // Xếp hạng cho từng thành viên
            for (int i = 0; i < t; i++)
            {
                for (int j = 0; j < t; j++)
                {
                    if (ranking[i] == int.Parse(Room.infoUsers[j].getMark()))
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
                    SendTopRank();
                    SendUserRank(i);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
        public void SendTopRank()
        {
            for (int i = 0; i < 3; i++)
            {
                try
                {
                    StreamWriter swSender;
                    TcpClient[] tcpClients = new TcpClient[Channel.htUsers.Count];
                    Channel.htUsers.Values.CopyTo(tcpClients, 0);
                    swSender = new StreamWriter(tcpClients[i].GetStream());
                    string rankTopX = "";
                
                    for (int j = 0; j < Channel.htUsers.Count; j++)
                    {
                        if (Room.infoUsers[j].getRank() == i + 1) 
                        {
                            rankTopX = "rak" + '|' + RoomID + '|' + Room.infoUsers[j].getIDUser() + '|' +
                                     Room.infoUsers[j].getMark().ToString() + '|' + Room.infoUsers[j].getRank().ToString();
                            break;
                        }
                    
                    }
                
                    swSender.WriteLine(rankTopX);
                    swSender.Flush();
                    swSender = null;
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
                             Room.infoUsers[index].getMark().ToString() + '|' + Room.infoUsers[index].getRank().ToString();
            swSender.WriteLine(rank);
            swSender.Flush();
            swSender = null;
        }
        public void SendQuestion()
        {
            string question = "";
            foreach (DataColumn column in dt.Columns)
            {
                question += dt.Rows[index][column].ToString() + '|';
            }
            string dataQuestion = "que" + '|' + RoomID + '|' + CreatorID + '|'
                                + index.ToString() + '|' + question;
            if (QuestionPack != "Câu hỏi kiến thức luật")
            {
                dataQuestion += '|' + "img";
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

                    Image image = null;
                    if (QuestionPack == "Câu hỏi kiến thức luật")
                    {
                        image = null;
                    }
                    else if (QuestionPack == "Câu hỏi biển báo")
                    {
                        image = Image.FromFile("D:/UIT/HK4/NT106/Project/NT106_Group8/sourcecode/projectNT106/projectNT106/bin/Debug/Image_ThiLaiXe/bienbao/101.png");
                    }
                    else if (QuestionPack == "Câu hỏi sa hình")
                    {
                        image = Image.FromFile("D:/UIT/HK4/NT106/Project/NT106_Group8/sourcecode/projectNT106/projectNT106/bin/Debug/Image_ThiLaiXe/sahinh/166.png");

                    }

                    try
                    {
                        Bitmap tImage = new Bitmap(image);
                        byte[] bStream = ImageToByteArray(tImage);

                        NetworkStream nStream = tcpClients[i].GetStream();
                        nStream.Write(bStream, 0, bStream.Length);
                        nStream.Flush();
                        nStream = null;

                    }
                    catch (SocketException e1)
                    {
                        Console.WriteLine("SocketException: " + e1);
                    }
                    swSender = null;

                }
                catch
                {
                    MessageBox.Show("error");
                }
            }
            index++;
        }
        public byte[] ImageToByteArray(Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.ToArray();
            }
        }

        private void btnLock_Click(object sender, EventArgs e)
        {
            isFull = true;
        }

        private void buttonX_Click(object sender, EventArgs e)
        {
            string aqr = sender.ToString().Split(',')[1];
            string tre = aqr.Substring(7);
            MessageBox.Show(tre);
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
            SendAdminMessage(htConnections[tcpUser] + "");
            
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
        //public static void SendMessage(string From, string Message)
        //{
        //    StreamWriter swSenderSender;
        //    e = new StatusChangedEventArgs(From + ": " + Message);
        //    OnStatusChanged(e);
        //    TcpClient[] tcpClients = new TcpClient[Channel.htUsers.Count];
        //    Channel.htUsers.Values.CopyTo(tcpClients, 0);
        //    for (int i = 0; i < tcpClients.Length; i++)
        //    {
        //        try
        //        {
        //            if (Message.Trim() == "" || tcpClients[i] == null)
        //            {
        //                continue;
        //            }
        //            swSenderSender = new StreamWriter(tcpClients[i].GetStream());
        //            swSenderSender.WriteLine(From + ": " + Message);
        //            swSenderSender.Flush();
        //            swSenderSender = null;
        //        }
        //        catch
        //        {
        //            RemoveUser(tcpClients[i]);
        //        }
        //    }
        //}


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

        public void sliptID(string message)
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
            sliptID(strResponse);
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
                    else if (!Room.isFull)
                    {
                        swSender.WriteLine("1");
                        swSender.Flush();
                        Channel.AddUser(tcpClient, Room.IDUserTemp);
                    }
                    else
                    {
                        swSender.WriteLine("0|This room is full.");
                        swSender.Flush();
                        CloseConnection();
                        return;
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
                        sliptID(strResponse);
                        if (instruction == "ans")
                        {
                            for (int i = 0; i < Channel.htConnections.Count; i++)
                            {
                                if (Room.IDRoomUser == Room.infoUsers[i].getIDRoom() && Room.IDUserTemp == Room.infoUsers[i].getIDUser())
                                {
                                    Room.infoUsers[i].receiveUserAnswer(indexQues, timeAnswer);                                 
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

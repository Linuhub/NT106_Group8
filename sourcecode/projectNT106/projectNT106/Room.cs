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
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.Collections;
using System.Data.OleDb;
using System.Windows.Threading;

namespace projectNT106
{
    public partial class Room : Form
    {
        public static string RoomID;
        public static string IDRoomUser = "";
        public static string IDUserTemp = "";
        private string CreatorID;
        private string QuestionPack;
        String[] paths = { };
        public Channel mainServer;
        public OleDbConnection cnn;
        public OleDbDataAdapter dar;
        public DataTable dt;
        public OleDbCommandBuilder cbr;
        public System.Timers.Timer time;
        public static InfoUser[] infoUsers = new InfoUser[10];
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
            Room.infoUsers[Channel.htConnections.Count].setAvatar(paths[icon]); 
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
            dar = new OleDbDataAdapter("Select * from tbl_All", cnn);
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
                IPAddress ipAddr = IPAddress.Parse("192.168.1.9");
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
        private void button1_Click(object sender, EventArgs e)
        {
                      
            time = new System.Timers.Timer();
            time.Interval = 1000; //1s
            time.Elapsed += OnTimeEvent;
            time.Start();
            
        }

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
                    if (index == 19)
                    {
                        time.Stop();
                        MessageBox.Show("Finish!");
                    }
                }
            }));
        }
    
        public void SendQuestion()
        {
            string question = "";
            foreach (DataColumn column in dt.Columns)
            {
                question += dt.Rows[index][column].ToString() + '|';
            }
            string dataQuestion = RoomID + '|' + CreatorID + '|'
                                + index.ToString() + '|' + question;
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

        private void button2_Click(object sender, EventArgs e)
        {

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
            
            Room.infoUsers[htConnections.Count] = new InfoUser(Room.RoomID, strUsername);
             
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
                                InfoUser tempUser = Room.infoUsers[i];
                                if (Room.IDRoomUser == tempUser.getIDRoom() && Room.IDUserTemp == tempUser.getIDUser())
                                {
                                    tempUser.receiveUserAnswer(indexQues, timeAnswer);
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
        
    public class InfoUser
    {
        private static string IDUser;
        private static string IDRoom;
        private static string avatar;
        private static int mark;
        private static int rank;
        private static double[] result = new double[21];
        public InfoUser(string idRoom, string idUser)
        {
            IDRoom = idRoom;
            IDUser = idUser;
            avatar = "";
            mark = 0;
            rank = 0;
        }
        public string getIDRoom()
        {
            return IDRoom;
        }
        public string getIDUser()
        {
            return IDUser;
        }
        public void receiveUserAnswer(int indexQuestion, double time)
        {
            result[indexQuestion] = time;
        }
        public void calculateMark()
        {
            foreach (var item in result)
            {
                mark = (int)item / 60 * 1000;
            }
        }
        public void setAvatar(string path)
        {
            avatar = path;
            MessageBox.Show(avatar);
        }
    }
}

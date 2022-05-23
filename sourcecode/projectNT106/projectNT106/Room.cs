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

namespace projectNT106
{
    public partial class Room : Form
    {
        private string RoomID;
        private string CreatorID;
        public static Contest[] contests = new Contest[5];
        public Channel mainServer;
        public Room(string Room, string Creator)
        {
            InitializeComponent();
            RoomID = Room;
            CreatorID = Creator;
           
        }


        private void roundedPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

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

            
        }

        void AddListView(string name, int index)
        {
            this.Invoke(new Action(() =>
            {
                listView1.Items.Add(name, index);
            }));
        }

        private void populate()
        {
            ImageList imgs = new ImageList();
            imgs.ImageSize = new Size(25, 25);

            String[] paths = { };
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

            for (int i = 0; i < 5; i++)
            {
                if (contests[i] == null)
                {
                    contests[i] = new Contest(RoomID, CreatorID);
                    break;
                }
                if (i == 4)
                {
                    MessageBox.Show("Hết phòng!");
                }
            }

            // Tạo phòng
            try
            {
                IPAddress ipAddr = IPAddress.Parse("192.168.1.8");
                mainServer = new Channel(ipAddr);
                mainServer.StartListening();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }


        }


        private void roundedPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            flowLayoutPanel1.BackColor = Color.FromArgb(100, 0, 0, 0);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form ranking = new RankingServer();
            ranking.Show();
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
            private TcpClient tcpClient;
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
                SendAdminMessage("ADD" + index.ToString() + htConnections[tcpUser]);
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
            private string currUser;
            private string strResponse;
            public bool _isExists = false;

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

            private void AcceptClient()
            {
                srReceiver = new System.IO.StreamReader(tcpClient.GetStream());
                swSender = new System.IO.StreamWriter(tcpClient.GetStream());
                currUser = srReceiver.ReadLine();
                if (currUser != "")
                {
                    if (Channel.htUsers.Contains(currUser) == true)
                    {
                        swSender.WriteLine("0|This username already exists.");
                        swSender.Flush();
                        CloseConnection();
                        _isExists = true;
                        return;
                    }
                    else if (currUser == "Administrator")
                    {
                        swSender.WriteLine("0|This username is reserved.");
                        swSender.Flush();
                        CloseConnection();
                        return;
                    }
                    else
                    {
                        swSender.WriteLine("1");
                        swSender.Flush();
                        MessageBox.Show("OK");
                        Channel.AddUser(tcpClient, currUser);
                        
                    }
                }
                else
                {
                    CloseConnection();
                    return;
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
}

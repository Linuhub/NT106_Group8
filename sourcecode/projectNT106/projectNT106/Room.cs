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

namespace projectNT106
{
    public partial class Room : Form
    {
        public Room()
        {
            InitializeComponent();
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
                cb.Text = (i+1).ToString();
                cb.Size = new Size(30, 30);
                cb.TextAlign = ContentAlignment.MiddleCenter;
                cb.Appearance = Appearance.Button;
                flowLayoutPanel1.Controls.Add(cb);

            }

            try
            {
                CheckForIllegalCrossThreadCalls = false;
                Thread serverThread = new Thread(new ThreadStart(StartUnsafeThread));
                serverThread.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
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
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            listView1.SmallImageList = imgs;
            
            
        }

        void StartUnsafeThread()
        {
            int bytesReceived = 0;
            byte[] recv = new byte[1];
            Socket clientSocket;
            Socket listenerSocket = new Socket(
                AddressFamily.InterNetwork,
                SocketType.Stream,
                ProtocolType.Tcp
                );
            IPEndPoint ipepServer = new IPEndPoint(IPAddress.Parse("172.30.159.71"), 8080);
            listenerSocket.Bind(ipepServer);
            listenerSocket.Listen(-1);
            clientSocket = listenerSocket.Accept();
            MessageBox.Show("OK");



            while (SocketConnected(clientSocket))
            {
                string text = "";
                do
                {
                    bytesReceived = clientSocket.Receive(recv);
                    text += Encoding.ASCII.GetString(recv);
                }
                while (text[text.Length - 1] != '\n');

                string[] arr = text.Split(new[] { "," }, StringSplitOptions.None);
                str result = new str(arr[0], int.Parse(arr[1]));
                

            }


            listenerSocket.Close();

        }
        bool SocketConnected(Socket s)
        {
            bool part1 = s.Poll(1000, SelectMode.SelectRead);
            bool part2 = (s.Available == 0);
            if (part1 && part2)
                return false;
            else
                return true;
        }
        class str
        {
            public string a;
            public int b;
            public string c = "\n";
            public str(string x, int y)
            {
                a = x;
                b = y;
            }

            public override string ToString()
            {
                string strA = a + ",";
                string strB = b.ToString() + ",";
                string strC = c;
                return strA + strB + strC;
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

        class ChatServer
        {
            public static Hashtable htUsers = new Hashtable(30);
            public static Hashtable htConnections = new Hashtable(30);
            private IPAddress ipAddress;
            private TcpClient tcpClient;
            public static event StatusChangedEventHandler StatusChanged;
            private static StatusChangedEventArgs e;
            public ChatServer(IPAddress address)
            {
                ipAddress = address;
            }
            private Thread thrListener;
            private TcpListener tlsClient;
            bool ServRunning = false;
            public static void AddUser(TcpClient tcpUser, string strUsername)
            {
                ChatServer.htUsers.Add(strUsername, tcpUser);
                ChatServer.htConnections.Add(tcpUser, strUsername);
                SendAdminMessage(htConnections[tcpUser] + " has connected.");
            }
            public static void RemoveUser(TcpClient tcpUser)
            {
                if (htConnections[tcpUser] != null)
                {
                    ChatServer.htUsers.Remove(ChatServer.htConnections[tcpUser]);
                    ChatServer.htConnections.Remove(tcpUser);
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
                TcpClient[] tcpClients = new TcpClient[ChatServer.htUsers.Count];
                ChatServer.htUsers.Values.CopyTo(tcpClients, 0);
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
            public static void SendMessage(string From, string Message)
            {
                StreamWriter swSenderSender;
                e = new StatusChangedEventArgs(From + ": " + Message);
                OnStatusChanged(e);
                TcpClient[] tcpClients = new TcpClient[ChatServer.htUsers.Count];
                ChatServer.htUsers.Values.CopyTo(tcpClients, 0);
                for (int i = 0; i < tcpClients.Length; i++)
                {
                    try
                    {
                        if (Message.Trim() == "" || tcpClients[i] == null)
                        {
                            continue;
                        }
                        swSenderSender = new StreamWriter(tcpClients[i].GetStream());
                        swSenderSender.WriteLine(From + ": " + Message);
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
                    if (ChatServer.htUsers.Contains(currUser) == true)
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
                        ChatServer.AddUser(tcpClient, currUser);
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
                            ChatServer.RemoveUser(tcpClient);
                        }
                        else
                        {
                            ChatServer.SendMessage(currUser, strResponse);
                        }
                    }
                }
                catch
                {
                    ChatServer.RemoveUser(tcpClient);
                }
            }
        }
    }
}

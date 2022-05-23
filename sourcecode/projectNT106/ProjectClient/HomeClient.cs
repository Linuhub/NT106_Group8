using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;

namespace ProjectClient
{
    public partial class HomeClient : Form
    {
        private string UserName = "Unknown";
        private StreamWriter swSender;
        private StreamReader srReceiver;
        private TcpClient tcpServer;
        private delegate void UpdateLogCallback(string strMessage);
        private delegate void CloseConnectionCallback(string strReason);
        private Thread thrMessaging;
        private IPAddress ipAddr;
        private bool Connected;
        bool isEnterRoom = false;

        private TcpClient tcpClient;
        private IPAddress ipAddress;
        private IPEndPoint iPEndPoint;
        private NetworkStream ns;
        public HomeClient()
        {
            InitializeComponent();
        }

        private void btnEnterRoom_Click(object sender, EventArgs e)
        {
            if (!isEnterRoom)
            {
                btnCreateRoom.Enabled = false;
                btnRevision.Enabled = false;
                groupBox3.Enabled = true;
                isEnterRoom = true;
            }
            else
            {
                btnCreateRoom.Enabled = true;
                btnRevision.Enabled = true;
                groupBox3.Enabled = false;
                isEnterRoom = false;
            }
        }

        private void btnCreateRoom_Click(object sender, EventArgs e)
        {
            Form createRoom = new CreateRoom();
            createRoom.ShowDialog();
        }

        private void btnJoin_Click(object sender, EventArgs e)
        {
            if (Connected == false)
            {
                InitializeConnection();
            }
            else
            {
                Form room = new QuestionSheet();
                room.Show();
            }
        }

        private void InitializeConnection()
        {
            try
            {

                /*ipAddr = IPAddress.Parse("127.0.0.1");
                tcpServer = new TcpClient();
                tcpServer.Connect(ipAddr, 80);
                Connected = true;
                UserName = txtUserID.Text;
                if (txtUserID.Text.Length == 0)
                {
                    MessageBox.Show("User name is empty!");
                    this.Invoke(new Action(() =>
                    {
                        btnJoin.Enabled = true;
                    }));
                    return;
                }*/
                
                    tcpClient = new TcpClient();

                    ipAddress = IPAddress.Parse("10.45.162.106");
                    iPEndPoint = new IPEndPoint(ipAddress, 8080);
                    tcpClient.Connect(iPEndPoint);


                    ns = tcpClient.GetStream();
                    //_isCOnnected = true;

                
                Byte[] data = System.Text.Encoding.ASCII.GetBytes("Hello server \n");
                ns.Write(data, 0, data.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
    }
}

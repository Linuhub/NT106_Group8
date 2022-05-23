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
                Form room = new QuestionSheet();
                room.Show();
            }
        }

        private void InitializeConnection()
        {
            try
            {

                ipAddr = IPAddress.Parse("192.168.1.8");
                tcpServer = new TcpClient();
                tcpServer.Connect(ipAddr, 80);
                Connected = true;
                UserName = txtUserID.Text;
                if (txtUserID.Text.Length == 0)
                {
                    MessageBox.Show("User name is empty!");
                    /*this.Invoke(new Action(() =>
                    {
                        btnJoin.Enabled = true;
                    }));*/
                    return;
                }
                swSender = new StreamWriter(tcpServer.GetStream());
                swSender.WriteLine(txtUserID.Text);
                swSender.Flush();
                thrMessaging = new Thread(new ThreadStart(ReceiveMessages));
                thrMessaging.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void ReceiveMessages()
        {
            try
            {
                srReceiver = new StreamReader(tcpServer.GetStream());
                string ConResponse = srReceiver.ReadLine();
                if (ConResponse[0] == '1')
                {
                    this.Invoke(new UpdateLogCallback(this.UpdateLog), new object[] { "Connected Successfully!" });
                }
                else
                {
                    string Reason = "Not Connected: ";
                    Reason += ConResponse.Substring(2, ConResponse.Length - 2);
                    this.Invoke(new CloseConnectionCallback(this.CloseConnection), new object[] { Reason });
                    this.Invoke(new Action(() =>
                    {
                        btnJoin.Enabled = true;
                    }));
                    MessageBox.Show(Reason);

                    return;
                }
                while (Connected)
                {
                    this.Invoke(new UpdateLogCallback(this.UpdateLog), new object[] { srReceiver.ReadLine() });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void UpdateLog(string strMessage)
        {
            MessageBox.Show(strMessage + "\r\n");
        }
        private void CloseConnection(string Reason)
        {
            Connected = false;
            swSender.Close();
            srReceiver.Close();
            tcpServer.Close();
        }
    }
}
        

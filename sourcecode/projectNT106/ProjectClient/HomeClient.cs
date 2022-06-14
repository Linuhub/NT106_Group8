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
        public static string UserName = "";
        public static string RoomID = "";
        private StreamWriter swSender;
        private StreamReader srReceiver;
        public static TcpClient tcpServer;
        public delegate void UpdateLogCallback(string strMessage);
        public delegate void CloseConnectionCallback(string strReason);
        private Thread thrMessaging;
        private IPAddress ipAddr;
        public static bool Connected;
        bool isEnterRoom = false;
        private TcpClient tcpClient;
        private IPAddress ipAddress;
        private IPEndPoint iPEndPoint;
        private NetworkStream ns;
        string ConResponse;
        public HomeClient()
        {
            InitializeComponent();
        }

        private void btnEnterRoom_Click(object sender, EventArgs e)
        {
            if (!isEnterRoom)
            {
                btnRevision.Enabled = false;
                groupBox3.Enabled = true;
                isEnterRoom = true;
            }
            else
            {
                btnRevision.Enabled = true;
                groupBox3.Enabled = false;
                isEnterRoom = false;
            }
        }

        private void btnJoin_Click(object sender, EventArgs e)
        {
            if (Connected == false)
            {
                InitializeConnection();
                

            }
            else CloseConnection("");
        }
        public void InitializeConnection()
        {
            try
            {
                if (!IPAddress.TryParse(txtIPServer.Text, out ipAddr))
                {
                    MessageBox.Show("IP server is incorrect!");
                    return;
                }
                tcpServer = new TcpClient();
                tcpServer.Connect(ipAddr, 80);
                UserName = txtUserID.Text;
                RoomID = txtRoomID.Text;
                if (txtUserID.Text.Length == 0)
                {
                    MessageBox.Show("User name is empty!");
                    return;
                }
                swSender = new StreamWriter(tcpServer.GetStream());
                swSender.WriteLine("add" + '|' + txtRoomID.Text + '|' + txtUserID.Text);
                swSender.Flush();
                ReceiveMessages(); 
                if (Connected)
                {
                    Form questionSheet = new QuestionSheet(ConResponse);
                    questionSheet.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }
        }

        private void ReceiveMessages()
        {
            try
            {
                srReceiver = new StreamReader(tcpServer.GetStream());
                ConResponse = srReceiver.ReadLine();
                if (ConResponse[0] == '1')
                {                  
                    this.Invoke(new UpdateLogCallback(this.UpdateLog), new object[] { "Connected Successfully!" });
                    Connected = true;
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
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void UpdateLog(string strMessage)
        {
        }
        

        private void CloseConnection(string Reason)
        {
            Connected = false;
            swSender.Close();
            srReceiver.Close();
            tcpServer.Close();
        }

        private void btnRevision_Click(object sender, EventArgs e)
        {
            Form revison = new Revision();
            revison.Show();
        }
    }
}
        

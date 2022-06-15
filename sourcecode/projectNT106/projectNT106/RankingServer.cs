using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projectNT106
{
    public partial class RankingServer : Form
    {
        public RankingServer()
        {
            InitializeComponent();
        }

        private void RankingServer_Load(object sender, EventArgs e)
        {
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            
            for (int i = 1; i <= Channel.htUsers.Count; i++)
            {
                for (int k = 0; k < Channel.htUsers.Count; k++)
                {
                    if (Room.infoUsers[k].getRank() == i)
                    {
                        
                        ListViewItem item = new ListViewItem();
                        item.Text = i.ToString();
                        item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = Room.infoUsers[k].getIDUser() });
                        item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = Room.infoUsers[k].getMark().ToString() });
                        listView1.Items.Add(item);
                    }
                }
            }

            
            ptbTop1.Image = Image.FromFile(Application.StartupPath + "\\icon/icon" + ShowTop(1)+ ".png");
            if (listView1.Items.Count == 1)
            {
                roundedPanel2.Hide();
                roundedPanel3.Hide();
            } 
            else if (listView1.Items.Count == 2)
            {
                ptbTop2.Image = Image.FromFile(Application.StartupPath + "\\icon/icon" + ShowTop(2) + ".png");
                roundedPanel3.Hide();
            }
            else
            {
                ptbTop2.Image = Image.FromFile(Application.StartupPath + "\\icon/icon" + ShowTop(2) + ".png");
                ptbTop3.Image = Image.FromFile(Application.StartupPath + "\\icon/icon" + ShowTop(3) + ".png");
            }
        }
        string ShowTop(int topX)
        {
            for (int k = 0; k < Channel.htUsers.Count; k++)
            {
                if (Room.infoUsers[k].getRank() == topX)
                {
                    if (Room.infoUsers[k].getAvt() < 9)
                    {
                        return "0" + (Room.infoUsers[k].getAvt() + 1).ToString();
                    }                
                    else
                    {
                        return (Room.infoUsers[k].getAvt() + 1).ToString();
                    }
                }
            }
            return "0";
        }

        private void gradientPanel1_Paint(object sender, PaintEventArgs e)
        {
            gradientPanel1.BackColor = Color.FromArgb(100, 0, 0, 0);

        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            Form creatroom = new CreateRoom();
            creatroom.Show();
            TcpClient[] tcpClients = new TcpClient[Channel.htUsers.Count];
            Channel.htUsers.Values.CopyTo(tcpClients, 0);
            for (int i = 0; i < Channel.htUsers.Count; i++)
            {
                Channel.RemoveUser(tcpClients[i]);
            }
            Room.mainServer.DeleteChannel();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TcpClient[] tcpClients = new TcpClient[Channel.htUsers.Count];
            Channel.htUsers.Values.CopyTo(tcpClients, 0);
            for (int i = 0; i < Channel.htUsers.Count; i++)
            {
                Channel.RemoveUser(tcpClients[i]);
            }
            this.Close();
        }
    }
}

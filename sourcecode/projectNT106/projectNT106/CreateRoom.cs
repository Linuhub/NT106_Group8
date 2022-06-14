﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projectNT106
{
    public partial class CreateRoom : Form
    {
        public static string IDRoom = "";
        public static IPAddress ipAddress;
        static string RandomIDRoom()
        {
            string IDRoom = "";
            char[] ID = new char[5];
            Random r = new Random();
            for (int i = 0; i < ID.Length; i++)
            {
                int Numrd;
                Numrd = r.Next(65, 90);
                ID[i] = Convert.ToChar(Numrd);
                IDRoom = IDRoom + ID[i];
            }

            return IDRoom;
        }
        public static string GetLocalIP()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No internet!");
        }
        public CreateRoom()
        {
            InitializeComponent();

            txtIPLocal.Text = GetLocalIP();
            ipAddress = IPAddress.Parse(txtIPLocal.Text);
            IDRoom = RandomIDRoom();
            cbQuestionPackage.Items.Add("Câu hỏi kiến thức luật");
            cbQuestionPackage.Items.Add("Câu hỏi biển báo");
            cbQuestionPackage.Items.Add("Câu hỏi phần sa hình");
        }

        private void gradientPanel1_Paint(object sender, PaintEventArgs e)
        {
            roundedPanel1.BackColor = Color.FromArgb(50, 0, 0, 0);
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (cbQuestionPackage.SelectedItem == null)
            {
                MessageBox.Show("Chọn gói câu hỏi!");
            }
            else
            {
                Form room = new Room(ipAddress, IDRoom, cbQuestionPackage.Text, txtNumOfParticipant.Text);
                room.Show();
                this.Close();
            }
        
        }

        private void CreateRoom_Load(object sender, EventArgs e)
        {
            txtRoomID.Text = IDRoom;
        }
    }
}

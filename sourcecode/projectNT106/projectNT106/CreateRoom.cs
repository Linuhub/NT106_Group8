﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projectNT106
{
    public partial class CreateRoom : Form
    {
        public static string IDRoom = "";

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

        public CreateRoom()
        {
            InitializeComponent();
            IDRoom = RandomIDRoom();
            cbQuestionPackage.Items.Add("Câu hỏi kiến thức Luật");
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
                Form room = new Room(IDRoom, txtUserID.Text, cbQuestionPackage.Text);
                room.Show();
            }
        
        }

        private void CreateRoom_Load(object sender, EventArgs e)
        {
            txtRoomID.Text = IDRoom;
        }
    }
}

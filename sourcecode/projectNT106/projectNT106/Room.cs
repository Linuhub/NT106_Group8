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
                Random rnd = new Random();
                flowLayoutPanel1.Controls.Add(cb);

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
            
            listView1.Items.Add("1210", 0);
            listView1.Items.Add("3322", 1);
            listView1.Items.Add("1213", 2);
            listView1.Items.Add("2220", 3);
            listView1.Items.Add("8910", 4);
            listView1.Items.Add("3333", 5);
            listView1.Items.Add("1111", 6);
            listView1.Items.Add("7771", 7);
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
    }
}

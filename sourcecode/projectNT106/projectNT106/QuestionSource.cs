using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projectNT106
{
    public partial class QuestionSource : Form
    {
        public QuestionSource()
        {
            InitializeComponent();
            btnAddImg.Hide();
            
        }

        string cs = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + Application.StartupPath +"\\DeThiLaiXe_3Part.mdb";
        OleDbConnection con;
        OleDbDataAdapter da;
        DataTable dt;
        OleDbCommand cmd;
        DataSet ds;
        string str1, str2;

        void GetData()
        {
            con = new OleDbConnection(cs);
            dt = new DataTable();
            da = new OleDbDataAdapter(str1, con);
            con.Open();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
        public void DefineString()
        {

            if (comboBox1.SelectedItem.ToString() == "Câu hỏi kiến thức luật")
            {
                str1 = "SELECT * from tbl_cauhoikienthucluat";
                str2 = "tbl_cauhoikienthucluat";
            }
            else if (comboBox1.SelectedItem.ToString() == "Câu hỏi biển báo")
            {
                str1 = "SELECT * from tbl_cauhoibienbao";
                str2 = "tbl_cauhoibienbao";
            }
            else if (comboBox1.SelectedItem.ToString() == "Câu hỏi sa hình")
            {
                str1 = "SELECT * from tbl_cauhoisahinh";
                str2 = "tbl_cauhoisahinh";

            }
        }
       
        private void tb_macauhoi_TextChanged(object sender, EventArgs e)
        {
            con = new OleDbConnection(cs);
            con.Open();
            cmd = new OleDbCommand(str1 + " where STT like '" + tb_macauhoi.Text + "%'", con);
            da = new OleDbDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            con = new OleDbConnection(cs);
            con.Open();
            DefineString();
            OleDbDataAdapter da = new OleDbDataAdapter(str1, con);
            ds = new DataSet();
            da.Fill(ds, str2);
            dataGridView1.DataSource = ds.Tables[str2].DefaultView;
            con.Close();
            this.dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void tbn_Update_Click(object sender, EventArgs e)
        {
            con = new OleDbConnection(cs);
            con.Open();
            string query = "UPDATE " + str2
                + " SET [Câu hỏi] = \"" + tb_Cauhoi.Text
                + "\", [Đáp án A] = \"" + tb_DapanA.Text
                + "\", [Đáp án B] = \"" + tb_DapanB.Text
                + "\", [Đáp án C] = \"" + tb_DapanC.Text
                + "\", [Đáp án D] = \"" + tb_DapanD.Text
                + "\", [Đáp án đúng] = \"" + tb_Dapandung.Text
                + "\" WHERE [STT] = \"" + tb_Stt.Text + "\"";

            cmd = new OleDbCommand();     
            cmd.Connection = con;
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();
            con.Close();

            // Lưu ảnh
            try
            {
                string path = Application.StartupPath + "\\Image_ThiLaiXe/" + tb_Stt.Text + ".png";
                pictureBox1.Image.Dispose();
                File.Delete(path);
                File.Copy(sourcePath, path);
            }
            catch (Exception ex) { }

            MessageBox.Show("Update Success.");
            GetData();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Convert.ToInt32(tb_Stt.Text) < 201 && Convert.ToInt32(tb_Stt.Text) > 100)
            {
                Image img = Image.FromFile(Application.StartupPath + "\\Image_ThiLaiXe/" + tb_Stt.Text + ".png");
                pictureBox1.Image = img;
                btnAddImg.Show();
            }
            else
            {
                pictureBox1.Image = Image.FromFile(Application.StartupPath + "\\img/source.png");
            }
        }
        int LastNum = 201;
        Image imgNew;
        string sourcePath = "";
        private void btnAddImg_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.ShowDialog();            
                sourcePath = ofd.FileName;
                imgNew = Image.FromFile(ofd.FileName);          

            }
            catch { }
        }
        
        

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            tb_Stt.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            tb_Cauhoi.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            tb_DapanA.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            tb_DapanB.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            tb_DapanC.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            tb_DapanD.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            tb_Dapandung.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
        }
    }
}

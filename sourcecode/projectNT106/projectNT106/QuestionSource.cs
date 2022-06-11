using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
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
        }

        string cs = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = D:\UIT\HK4\NT106\Project\NT106_Group8\sourcecode\projectNT106\projectNT106\bin\Debug\DeThiLaiXe_3Part.mdb";
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
            string query = "UPDATE " + str2
                + " SET [Câu hỏi] = @cauhoi, [Đáp án A] = @dapanA, [Đáp án B] = @dapanB, [Đáp án C] = @dapanC, [Đáp án D] = @dapanD, [Đáp án đúng] = @dapandung"
                + " WHERE [STT] = @stt";

            cmd = new OleDbCommand(query, con);
            cmd.Parameters.AddWithValue("@cauhoi", tb_Cauhoi.Text);
            cmd.Parameters.AddWithValue("@dapanA", tb_DapanA.Text);
            cmd.Parameters.AddWithValue("@dapanB", tb_DapanB.Text);
            cmd.Parameters.AddWithValue("@dapanC", tb_DapanC.Text);
            cmd.Parameters.AddWithValue("@dapanD", tb_DapanD.Text);
            cmd.Parameters.AddWithValue("@dapandung", tb_Dapandung.Text);
            cmd.Parameters.AddWithValue("@stt", Convert.ToInt32(tb_Stt.Text));
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Update Success.");
            GetData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Convert.ToInt32(tb_Stt.Text) < 201 || Convert.ToInt32(tb_Stt.Text) > 100)
                pictureBox1.ImageLocation = @"D:\UIT\HK4\NT106\Project\NT106_Group8\sourcecode\projectNT106\projectNT106\bin\Debug\Image_ThiLaiXe\" + tb_Stt.Text + ".png";
            else pictureBox1.ImageLocation = null;
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            tb_Stt.Clear();
            tb_Cauhoi.Clear();
            tb_DapanA.Clear();
            tb_DapanB.Clear();
            tb_DapanC.Clear();
            tb_DapanD.Clear();
            tb_Dapandung.Clear();
        }

        int LastNum = 201;
        private void btn_Insert_Click(object sender, EventArgs e)
        {
            tb_Stt.Text = Convert.ToString(LastNum);
            con = new OleDbConnection(cs);
            string query = "INSERT INTO " + str2 + " ([STT], [Câu hỏi], [Đáp án A], [Đáp án B], [Đáp án C], [Đáp án D], [Đáp án đúng]) VALUES"
                + "(@stt,@cauhoi,@dapanA,@dapanB,@dapanC,@dapanD,@dapandung)";
            cmd = new OleDbCommand(query, con);
            cmd.Parameters.AddWithValue("@stt", Convert.ToInt32(tb_Stt.Text));
            cmd.Parameters.AddWithValue("@cauhoi", tb_Cauhoi.Text);
            cmd.Parameters.AddWithValue("@dapanA", tb_DapanA.Text);
            cmd.Parameters.AddWithValue("@dapanB", tb_DapanB.Text);
            cmd.Parameters.AddWithValue("@dapanC", tb_DapanC.Text);
            cmd.Parameters.AddWithValue("@dapanD", tb_DapanD.Text);
            cmd.Parameters.AddWithValue("@dapandung", tb_Dapandung.Text);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Insert Success.");
            GetData();
            LastNum++;
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

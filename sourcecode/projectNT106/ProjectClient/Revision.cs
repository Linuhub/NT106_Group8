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

namespace ProjectClient
{
    public partial class Revision : Form
    {
        public Revision()
        {
            InitializeComponent();
        }
        string cs = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + Application.StartupPath + "\\DeThiLaiXe_3Part.mdb";
        OleDbConnection con;
        OleDbDataAdapter da;
        DataTable dt;
        OleDbCommand cmd;
        DataSet ds;
        string str1, str2;
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
        private void ResetAnswer()
        {
            txtA.BackColor = SystemColors.ActiveCaption;
            txtB.BackColor = SystemColors.ActiveCaption;
            txtC.BackColor = SystemColors.ActiveCaption;
            txtD.BackColor = SystemColors.ActiveCaption;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ResetAnswer();
            string indexQues = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtQuestion.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtA.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtB.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtC.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtD.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            string correctAnswer = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            if (correctAnswer == "Đáp án: A")
            {
                txtA.BackColor = Color.Green;
            }
            else if (correctAnswer == "Đáp án: B")
            {
                txtB.BackColor = Color.Green;
            }
            else if (correctAnswer == "Đáp án: C")
            {
                txtC.BackColor = Color.Green;
            }
            else if (correctAnswer == "Đáp án: D")
            {
                txtD.BackColor = Color.Green;
            }

            if (Convert.ToInt32(indexQues) < 201 && Convert.ToInt32(indexQues) > 100)
            {
                Image img = Image.FromFile(Application.StartupPath + "\\Image_ThiLaiXe/" + indexQues + ".png");
                pictureBox1.Image = img;
            }
            else pictureBox1.ImageLocation = null;
        }
    }
}

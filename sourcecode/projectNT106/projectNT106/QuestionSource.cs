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

        string cs = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\UIT\HK4\NT106\Project\NT106_Group8\sourcecode\projectNT106\projectNT106\bin\Debug\DeThiLaiXe_3Part.mdb";
        OleDbConnection con;
        OleDbDataAdapter da;
        DataTable dt;
        OleDbCommand cmd;
        string str1, str2;

        public void DefineString()
        {

            if (comboBox1.SelectedItem.ToString() == "Câu hỏi kiến thức luật")
            {
                str1 = "select * from tbl_cauhoikienthucluat";
                str2 = "tbl_cauhoikienthucluat";
            }
            else if (comboBox1.SelectedItem.ToString() == "Câu hỏi biển báo")
            {
                str1 = "select * from tbl_cauhoibienbao";
                str2 = "tbl_cauhoibienbao";
            }
            else if (comboBox1.SelectedItem.ToString() == "Câu hỏi sa hình")
            {
                str1 = "select * from tbl_cauhoisahinh";
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
            DataSet ds = new DataSet();
            da.Fill(ds, str2);
            dataGridView1.DataSource = ds.Tables[str2].DefaultView;
            //con = new OleDbConnection(cs);
            //con.Open();
            //cmd = new OleDbCommand(str, con);
            //da = new OleDbDataAdapter(cmd);
            //dt = new DataTable();
            //da.Fill(dt);
            //dataGridView1.DataSource = dt;
            con.Close();
            this.dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

    }
}

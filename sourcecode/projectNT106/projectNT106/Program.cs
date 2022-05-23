using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projectNT106
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new HomeServer());

            string connectionString =
                    @"Provider=Microsoft.Jet.OLEDB.4.0;" +
                    @"Data Source=D:\UIT\HK4\NT106\Project\thamkhao\DeThiLaiXe.mdb;" +
                    @"User Id=;Password=;";

            string queryString = "SELECT * FROM table1";

            using (OleDbConnection connection = new OleDbConnection(connectionString))   //tạo lớp kết nối vào .mbd
            using (OleDbCommand command = new OleDbCommand(queryString, connection))    //tạo lớp lệnh sql sử dụng lớp kết nối trên
            {
                try
                {
                    connection.Open();  //bắt đầu kết nối
                    OleDbDataReader reader = command.ExecuteReader();  //thực thi sql và trả về kết quả

                    while (reader.Read())  //đọc kết quả
                    {
                        Console.Write(reader[0].ToString() + ",");
                        Console.Write(reader[1].ToString() + ",");
                        Console.WriteLine(reader[2].ToString());
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            Console.Read();
        }
    }
}

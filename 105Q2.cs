using System;
using System.Data.SqlClient;

namespace test5
{
    class Program
    {
        static void Main(string[] args)
        {

            connectionString = "Data Source=(local);Initial Catalog=test;User ID=sa;” + “Password=sa;Integrated Security=true";

            // (1)【5 分】SQL：依 c_no 由小到大
            string queryString ="SELECT c_no, c_name, c_points FROM curriculum ORDER BY c_no";

            Console.WriteLine("課程編號\t 課程名稱\t 學分數\t 課程編號\t 課程名稱\t 學分數");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    {
                        // (2)【15 分】兩欄輸出（每兩筆資料同列顯示）
                        string left = null; // 暫存左欄

                        while (reader.Read())
                        {
                            string row = $"{reader["c_no"]}\t {reader["c_name"]}\t {reader["c_points"]}";
                            if (left == null)
                            {
                                left = row; // 先填左欄
                            }
                            else
                            {
                                Console.WriteLine(left + "\t " + row); // 左＋右 同行輸出
                                left = null; // 清空暫存
                            }
                        }

                        // 若總筆數為奇數，最後一筆獨立成行
                        if (left != null)
                        {
                            Console.WriteLine(left);
                        }
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.ReadLine();
        }
    }
}

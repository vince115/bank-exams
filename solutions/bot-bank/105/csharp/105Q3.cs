using System;
using System.Data;
using System.Data.SqlClient;
namespace test6
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString =
            "Data Source=(local);Initial Catalog=test;User ID=sa;" +
            "Password = sa; Integrated Security = true";
            string queryString =
                    "SELECT r_result FROM results WHERE c_no = 'C0002' ORDER BY r_result DESC;";
        using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

//-------------------------- (2) 【15 分】
                    //  計算前 3 名與最後 3 名平均，並求差距
                    var scores = new List<double>();
                    while (reader.Read()) { 
                       // r_result 為浮點數 → 轉為 double
                        scores.Add(Convert.ToDouble(reader[0])); 
                    }

                    if (scores.Count < 6)
                    {
                        Console.WriteLine("資料筆數不足，需大於6筆");
                    }
                    else
                    {
                        double topAvg = scores.Take(3).Average();                                   // 由大到小排序後的前 3 名
                        double bottom3Avg = scores.Skip(scores.Count - 3).Take(3).Average();        // 最後 3 名
                        double diff = top3Avg - bottom3Avg;                                         // 差距（可視需要取絕對值）

                        Console.WriteLine($"Top 3 Avg = {top3Avg:F2}");
                        Console.WriteLine($"Bottom 3 Avg = {bottom3Avg:F2}");
                        Console.WriteLine($"Difference (Top - Bottom) = {diff:F2}");
                        Console.WriteLine($"Absolute Difference = {Math.Abs(diff):F2}");
                    }
//--------------------------

                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.ReadLine();
            }
        }
    }
}
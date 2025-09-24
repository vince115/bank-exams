
using System;
using System.Text;
using System.Security.Cryptography;
using Microsoft.Data.SqlClient;

public static class Q4
{
    public static bool ValidateUser(string username, string password)
    {
        if (string.IsNullOrWhiteSpace(username) || password is null) return false;

        // 計算 MD5（大寫16進位，與 SQL 的 CONVERT(...,2) 對應）
        string hash = Convert.ToHexString(MD5.HashData(Encoding.UTF8.GetBytes(password)));

        const string SQL = "SELECT 1 FROM dbo.Users WHERE username=@u AND password_hash=@h";
        using var conn = new SqlConnection(Config.ConnString);
        using var cmd = new SqlCommand(SQL, conn);
        cmd.Parameters.AddWithValue("@u", username);
        cmd.Parameters.AddWithValue("@h", hash);

        conn.Open();
        return cmd.ExecuteScalar() != null;   // 有資料=驗證通過
    }
}
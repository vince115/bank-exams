
// 106Q2_UpdateBalance.cs
using Microsoft.Data.SqlClient;

public static class Q2
{
    //更新餘額
    private const string SQL = @"UPDATE Accounts
        SET balance = balance + @amt
        WHERE account_id = @id AND (@amt >= 0 OR balance >= -@amt);";

    //題目要求版：自行建立連線/交易，回傳 true/false，不足額拋 OverdraftException
    public static bool UpdateBalance(int accountId, decimal amount)
    {
        using var conn = new SqlConnection(Config.ConnString);
        conn.Open();
        using var tx = conn.BeginTransaction();

        using var cmd = new SqlCommand(SQL, conn, tx);

        cmd.Parameters.AddWithValue("@id", accountId);
        cmd.Parameters.AddWithValue("@amt", amount);

        int rows = cmd.ExecuteNonQuery();
        // 成功
        if (rows == 1) { tx.Commit(); return true; } 
        // 帳戶不存在
        if (amount < 0) { tx.Rollback(); throw new OverdraftException("Insufficient funds."); }
        tx.Rollback();                                           
        return false;
    }
}
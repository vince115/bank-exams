using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;

public static class Q3
{
    public static List<decimal> QueryTransactions(int accountId, DateTime fromDate)
    {
        const string SQL = @"SELECT amount FROM dbo.Transactions
                            WHERE account_id = @id AND trans_date >= @from
                            ORDER BY trans_date DESC;";

        var list = new List<decimal>();

        using var conn = new SqlConnection(Config.ConnString);
        using var cmd  = new SqlCommand(SQL, conn);
        cmd.Parameters.AddWithValue("@id", accountId);
        cmd.Parameters.Add("@from", SqlDbType.DateTime).Value = fromDate;

        conn.Open();
        using var rd = cmd.ExecuteReader();
        while (rd.Read()) list.Add(rd.GetDecimal(0));

        return list;
    }
}

//三）說明：索引加速範圍查詢，減少掃描時間，提升效能。
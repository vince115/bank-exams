// dev/banktest/106Q1_CreateAccount.cs
using System;
using System.Data;
using System.Text.RegularExpressions;
using Microsoft.Data.SqlClient;

public class AccountExistsException : Exception
{
    public AccountExistsException(string msg) : base(msg) { }
}

public static class Q1
{
    public static int CreateAccount(string accountNo, string ownerName, decimal initialBalance)
    {
        //撰寫SQL插入帳戶（使用參數化，檢查account_no唯一）
        if (!Regex.IsMatch(accountNo, @"^\d{10}$"))
            throw new ArgumentException("accountNo 必須為 10 位數字", nameof(accountNo));
        if (initialBalance < 0)
            throw new ArgumentException("initialBalance 必須 ≥ 0");

        const string SQL = @"INSERT INTO Accounts (account_no, owner_name, initial_balance)
                            VALUES (@accountNo, @ownerName, @initialBalance);";

        using var conn = new SqlConnection(Config.ConnString);
        using var cmd = new SqlCommand(SQL, conn);
        cmd.Parameters.Add("@accountNo", SqlDbType.VarChar, 20).Value = accountNo;
        cmd.Parameters.Add("@ownerName", SqlDbType.VarChar, 50).Value = ownerName;
        cmd.Parameters.Add("@initialBalance", SqlDbType.Decimal).Value = initialBalance;
        conn.Open();
        try
        {
            //return (int)cmd.ExecuteScalar();
            return Convert.ToInt32(cmd.ExecuteScalar());

        }
        catch (SqlException ex) when (ex.Number is 2601 or 2627)
        {
            throw new AccountExistsException($"accountNo '{accountNo}' 已存在");
        }
    }

}

// 說明參數化防SQL注入
// 參數化將輸入視為資料而非程式碼，防注入如'; DROP TABLE Accounts --導致資料遺失。
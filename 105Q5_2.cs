string connetionString = null;
SqlConnection sqlCnn ;
SqlCommand sqlCmd ;
SqlDataAdapter adapter = new SqlDataAdapter();
DataSet ds = new DataSet();
int i = 0;
string sql = null;
connetionString = "Data Source=ServerName; Initial Catalog=DatabaseName; User ID=UserName; Password=Password";
sql = "Select * from Sale";
sqlCnn = new SqlConnection(connetionString);
try
{
    sqlCnn.Open(); //開啟 SQL 連線
                   //(1) ; New SQL 命令的物件
    sqlCmd = new SqlCommand(sql, sqlCnn);
    //(2) ; 設定 DataAdapter 的 Select Command
    adapter.SelectCommand = sqlCmd;
    //(3) ; 結合 DataSet 物件, 將命令執行的結果填入 DataSet 物件中
    adapter.Fill(ds);
    //下列程式片段是將 DataSet 中第一個表單的每一筆資料的第一個資料項目及
    //第二個資料項目印出.
    //(4)
    for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
    {
        MessageBox.Show(
            //(5)
            ds.Tables[0].Rows[i][0] + " -- " +
            //(6)
            ds.Tables[0].Rows[i][1]
        );
    }
    adapter.Dispose();
    sqlCmd.Dispose();
    sqlCnn.Close();
}
catch (Exception ex)
{
    MessageBox.Show("Can not open connection ! ");
}
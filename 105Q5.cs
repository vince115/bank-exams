public static string DB_NAME = "yourdb";
public static string DB_PATH = "C:\\data\\";

public bool CreateDatabase()
{
    bool stat = true;
    string sqlCreateDBQuery;
    SqlConnection myConn = new SqlConnection(
        "Server=localhost\\SQLEXPRESS;Integrated Security=SSPI;Database=master;");

    sqlCreateDBQuery =
        "CREATE DATABASE " + DB_NAME +
        " ON PRIMARY (NAME = " + DB_NAME + "_Data, " +
        " FILENAME = '" + DB_PATH + DB_NAME + ".mdf', SIZE = 2MB)"; // 其餘略

    SqlCommand myCommand = new SqlCommand(sqlCreateDBQuery, myConn); // (1)
    try
    {
        myConn.Open();                    // (2)
        myCommand.ExecuteNonQuery();      // (3)
    }
    catch (System.Exception)
    {
        stat = false;
    }
    finally
    {
        if (myConn.State == ConnectionState.Open) // (4)
        {
            myConn.Close();
        }
        myConn.Dispose();
    }
    return stat;
}

using System;
using System.Data.SqlClient;
class Program
{
    static void Main()
    {
        var conn = "Server=localhost;Database=EmpFile;Trusted_Connection=True;"
        var updateSql = @"
        UPDATE Employee
        SET Salary = Salary + CASE
            WHEN Job_Title='Manager' THEN 2000
            WHEN Job_Title='Deputy_Manager' THEN 1500
            ELSE 1000
        END";
        
    }
}
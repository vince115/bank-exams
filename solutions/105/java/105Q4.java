//departments(d_id,dname,m_id)
//employees(e_id,name,rank,salary,d_id)

// 1. 首先抓取「業務部」部門的所有員工的 name 及 salary，並依據 rank 從小到大排序。
// 2. 然後依據以下規則顯示員工的姓名及年終獎金
// rank 在前 3 名的年終獎金為薪水的 3 倍
// rank 在 4 到 6 名的年終獎金為薪水的 2 倍
// 年終獎金為 1 個月薪水

import java.sql.*;

class test1 {
    public static void main(String[] args) {
        String conUrl = "jdbc:sqlserver://loalhost;databaseName=test;user=sa;password=sa;";
        Connection con = null;
        try {
            Class.forName("com.microsoft.sqlserver.jdbc.SQLServerDriver");
            con = DriverManager.getConnection(conUrl);
            String SQL =
            //(1)[5分]
            "SELECT e.name, e.salary, e.rank " +
            "FROM employees e " +
            "JOIN departments d ON d.d_id = e.d_id " +
            "WHERE d.dname = N'業務部' " +  // SQL Server：中文字前加 N
            "ORDER BY e.rank ASC";

            Statement stmt = con.createStatement();
            ResultSet rs = stmt.executeQuery(SQL);
            System.out.println("姓名\t 年終");
            //(2) [15分]
            while (rs.next()) {
                String name = rs.getString("name");
                int salary = rs.getInt("salary");
                int rank = rs.getInt("rank");
                
                int bonus;
                if(rank<=3){
                    bonus = salary * 3;
                }else if(rank<=6){
                    bonus = salary * 2;
                }else{
                    bonus = salary;
                }
                System.out.println(name+"\t"+bonus);
            }
            rs.close();
            stmt.close();
        } catch (Exception ex) {
            ex.printStackTrace();
        }
    }
}
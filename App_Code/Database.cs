using System;
using System.CodeDom;
using System.Collections;
using System.Data;
using System.Data.SqlClient;

namespace Webstop
{
  internal class Database
  {
    public static SqlConnection GetConnection(string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\sayav\source\repos\Webstop\App_Data\Database.mdf;Integrated Security=True") => new SqlConnection(connStr);

    public static void DoQuery(string sql, string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\sayav\source\repos\Webstop\App_Data\Database.mdf;Integrated Security=True")
    {
      SqlConnection conn = GetConnection(connStr);
      conn.Open();
      SqlCommand com = new SqlCommand(sql, conn);
      com.ExecuteNonQuery();
      com.Dispose();
      conn.Close();
    }

    public static ArrayList Get(string sql, string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\sayav\source\repos\Webstop\App_Data\Database.mdf;Integrated Security=True")
    {
      /*string[,] table;
      DataTable dt = ExecuteDataTable(sql, connStr);
      table = new string[dt.Rows.Count,dt.Columns.Count];
      for (int i = 0; i < dt.Rows.Count; i++)
      {
        for (int j = 0; j < dt.Columns.Count; j++)
        {
          table[i, j] = dt.Rows[i][j].ToString();
        }
      }
      table = null;
      return table;*/
      DataTable dt = ExecuteDataTable(sql, connStr);
      ArrayList table = null;
      if (IsExist(sql, connStr)) table = new ArrayList();
      else return table;
      for (int i = 0; i < dt.Rows.Count; i++)
        table[i] = dt.Rows[i].ItemArray.Clone();
      return table;
    }
    
    public static bool IsExist(string sql, string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\sayav\source\repos\Webstop\App_Data\Database.mdf;Integrated Security=True")
    {
      SqlConnection conn = GetConnection(connStr);
      conn.Open();
      SqlCommand com = new SqlCommand(sql, conn);
      SqlDataReader reader = com.ExecuteReader();
      bool flag = reader.Read();
      conn.Close();
      return flag;
    }

    public static int RowsAffected(string sql, string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\sayav\source\repos\Webstop\App_Data\Database.mdf;Integrated Security=True")
    {
      SqlConnection conn = GetConnection(connStr);
      conn.Open();
      SqlCommand com = new SqlCommand(sql, conn);
      int rowsA = com.ExecuteNonQuery();
      conn.Close();
      return rowsA;
    }

    public static DataTable ExecuteDataTable(string sql, string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\sayav\source\repos\Webstop\App_Data\Database.mdf;Integrated Security=True")
    {
      SqlConnection conn = GetConnection(connStr);
      conn.Open();
      SqlDataAdapter tableAdapter = new SqlDataAdapter(sql, conn);
      DataTable dt = new DataTable();
      tableAdapter.Fill(dt);
      return dt;
    }

    public static void ExecuteNonQuery(string sql, string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\sayav\source\repos\Webstop\App_Data\Database.mdf;Integrated Security=True")
    {
      SqlConnection conn = GetConnection(connStr);
      conn.Open();
      SqlCommand command = new SqlCommand(sql, conn);
      command.ExecuteNonQuery();
      conn.Close();
    }

    public static string GetDataTable(string sql, string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\sayav\source\repos\Webstop\App_Data\Database.mdf;Integrated Security=True")
    {
      DataTable dt = ExecuteDataTable(sql, connStr);
      string printStr = "<table class=\"st_table\">";
      for (int i = 0; i < dt.Rows.Count; i++)
      {
        printStr += "<tr class=\"st_row\">";
        for (int j = 0; j < dt.Rows[i].ItemArray.Length; j++)
          printStr += "<td class=\"st_column\">" + dt.Rows[i].ItemArray[j].ToString() + "</td>";
        printStr += "</tr>";
      }
      return printStr + "</table>";
    }
  }
}
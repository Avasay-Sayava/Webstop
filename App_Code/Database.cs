﻿using System.Data;
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

    public static string[,] Get(string sql, string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\sayav\source\repos\Webstop\App_Data\Database.mdf;Integrated Security=True")
    {
      string[,] table;
      try
      {
        DataTable dt = ExecuteDataTable(connStr, sql);
        table = new string[dt.Rows.Count,dt.Columns.Count];
        for (int i = 0; i < dt.Rows.Count; i++)
        {
          for (int j = 0; j < dt.Columns.Count; j++)
          {
            table[i,j] = dt.Rows[i][j].ToString();
          }
        }
      }
      catch (System.Exception)
      {
        table = null;
      }
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

    public static string PrintDataTable(string sql, string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\sayav\source\repos\Webstop\App_Data\Database.mdf;Integrated Security=True")
    {
      DataTable dt = ExecuteDataTable(connStr, sql);
      string printStr = "<table>";
      foreach (DataRow row in dt.Rows)
      {
        printStr += "<tr>";
        foreach (object myItemArray in row.ItemArray)
          printStr += "<td>" + myItemArray.ToString() + "</td>";
        printStr += "</tr>";
      }
      return printStr + "</table>";
    }
  }
}
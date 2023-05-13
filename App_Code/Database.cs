using System.Data;
using System.Data.SqlClient;

namespace SQL
{
  /// <summary>
  /// Represents a class for interacting with a SQL Server SQL.Manager.
  /// </summary>
  internal class Manager
  {
    /// <summary>
    /// The default connection string for the SQL.Manager.
    /// </summary>
    private const string defaultConnStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\sayav\source\repos\Webstop\App_Data\Database.mdf;Integrated Security=True";

    /// <summary>
    /// Gets a new instance of SqlConnection using the provided or default connection string.
    /// </summary>
    /// <param name="connStr">The connection string to use (optional). If not provided, the default connection string will be used.</param>
    /// <returns>A new SqlConnection instance.</returns>
    public static SqlConnection GetConnection(string connStr = defaultConnStr) => new SqlConnection(connStr);

    /// <summary>
    /// Executes a query SQL statement on the SQL.Manager using the provided or default connection string.
    /// </summary>
    /// <param name="sql">The SQL statement to execute.</param>
    /// <param name="connStr">The connection string to use (optional). If not provided, the default connection string will be used.</param>
    /// <returns>The number of rows affected by the SQL statement.</returns>
    public static int DoQuery(string sql, string connStr = defaultConnStr)
    {
      SqlConnection conn = GetConnection(connStr);
      conn.Open();
      SqlCommand com = new SqlCommand(sql, conn);
      int rowsAffected = com.ExecuteNonQuery();
      com.Dispose();
      conn.Close();
      return rowsAffected;
    }

    /// <summary>
    /// Executes a SQL query on the SQL.Manager and returns the result as a two-dimensional object array.
    /// </summary>
    /// <param name="sql">The SQL query to execute.</param>
    /// <param name="connStr">The connection string to use (optional). If not provided, the default connection string will be used.</param>
    /// <returns>A two-dimensional object array containing the result of the SQL query.</returns>
    public static object[,] ExecuteQuery(string sql, string connStr = defaultConnStr)
    {
      DataTable dt = ExecuteDataTable(sql, connStr);
      object[,] table = null;
      if (DoesExist(sql, connStr))
      {
        table = new object[dt.Rows.Count, dt.Columns.Count];
        for (int i = 0; i < dt.Rows.Count; i++)
        {
          for (int j = 0; j < dt.Columns.Count; j++)
          {
            table[i, j] = dt.Rows[i].ItemArray[j];
          }
        }
      }
      else
      {
        return table;
      }
      return table;
    }

    /// <summary>
    /// Checks if a record exists in the SQL.Manager based on the provided SQL query.
    /// </summary>
    /// <param name="sql">The SQL query to check for existence.</param>
    /// <param name="connStr">The connection string to use (optional). If not provided, the default connection string will be used.</param>
    /// <returns>True if the record exists, False otherwise.</returns>
    public static bool DoesExist(string sql, string connStr = defaultConnStr)
    {
      SqlConnection conn = GetConnection(connStr);
      conn.Open();
      SqlCommand com = new SqlCommand(sql, conn);
      SqlDataReader reader = com.ExecuteReader();
      bool recordExists = reader.Read();
      conn.Close();
      return recordExists;
    }

    /// <summary>
    /// Executes a SQL statement and returns the result as a DataTable object.
    /// </summary>
    /// <param name="sql">The SQL statement to execute.</param>
    /// <param name="connStr">The connection string to use (optional). If not provided, the default connection string will be used.</param>
    /// <returns>A DataTable object containing the result of the SQL statement.</returns>
    public static DataTable ExecuteDataTable(string sql, string connStr = defaultConnStr)
    {
      SqlConnection conn = GetConnection(connStr);
      conn.Open();
      SqlDataAdapter tableAdapter = new SqlDataAdapter(sql, conn);
      DataTable dt = new DataTable();
      tableAdapter.Fill(dt);
      return dt;
    }

    /// <summary>
    /// Executes a non-query SQL statement and returns the number of rows affected.
    /// </summary>
    /// <param name="sql">The SQL statement to execute.</param>
    /// <param name="connStr">The connection string to use (optional). If not provided, the default connection string will be used.</param>
    /// <returns>The number of rows affected by the SQL statement.</returns>
    public static int ExecuteNonQuery(string sql, string connStr = defaultConnStr)
    {
      SqlConnection conn = GetConnection(connStr);
      conn.Open();
      SqlCommand com = new SqlCommand(sql, conn);
      int rowsAffected = com.ExecuteNonQuery();
      conn.Close();
      return rowsAffected;
    }

    /// <summary>
    /// Generates an HTML table with form elements for displaying and manipulating data from the SQL.Manager.
    /// </summary>
    /// <param name="sql">The SQL query to retrieve data from the SQL.Manager.</param>
    /// <param name="action">The action URL for the form.</param>
    /// <param name="addons">Additional attributes for the form elements (optional).</param>
    /// <param name="connStr">The connection string to use (optional). If not provided, the default connection string will be used.</param>
    /// <returns>An HTML string representing the generated table with form elements.</returns>
    public static string ExecuteTableForm(string sql, string action, string[] addons = null, string connStr = defaultConnStr)
    {
      DataTable dt = ExecuteDataTable(sql, connStr);
      if (addons == null)
      {
        addons = new string[dt.Columns.Count];
        for (int i = 0; i < addons.Length; i++)
        {
          addons[i] = "";
        }
      }
      if (addons.Length != dt.Columns.Count)
      {
        string[] tmp = addons;
        addons = new string[dt.Columns.Count];
        for (int i = 0; i < addons.Length; i++)
        {
          addons[i] = "";
        }
        tmp.CopyTo(addons, 0);
      }
      string html = $@"
<table>
  <tr>
    <form>";
      for (int i = 0; i < dt.Columns.Count; i++)
      {
        html += $@"
      <td>
        <input {addons[i].Replace("readonly", "").Replace("disabled", "")} placeHolder='{dt.Columns[i].ColumnName}' id='search-{i}' type='text' name='{dt.Columns[i].ColumnName}' />
      </td>";
      }
      html += @"
      <td>
        <input type='button' name='search' value='search' onclick='search()' />
      </td>
    </form>
  </tr>";
      foreach (DataRow row in dt.Rows)
      {
        html += $@"
  <tr>
    <form method='post' action='{action}'>";
        for (int i = 0; i < dt.Columns.Count; i++)
        {
          html += $@"
      <td>
        <input {addons[i]} placeHolder='{dt.Columns[i].ColumnName}' type='text' name='{dt.Columns[i].ColumnName.ToLower()}' value='{row.ItemArray[i]}' />
      </td>";
        }
        html += @"
      <td>
        <input type='submit' name='apply' value='apply' />
        <input type='submit' name='remove' value='remove' />
      </td>
    </form>
  </tr>";
      }
      html += $@"
  <tr>
    <form method='post' action='{action}'>";
      for (int i = 0; i < dt.Columns.Count; i++)
      {
        html += $@"
      <td>
        <input {addons[i]} placeHolder='{dt.Columns[i].ColumnName}' type='text' name='{dt.Columns[i].ColumnName.ToLower()}' value='{(dt.Columns[i].ColumnName.ToLower().Equals("id") ? $"{(int)dt.Rows[dt.Rows.Count - 1].ItemArray[i] + 1}" : "")}' />
      </td>";
      }
      return html += @"<td>
        <input type='submit' name='add' value='add' />
      </td>
    </form>
  </tr>
</table>";
    }
  }
}
using System;
using System.Linq;
using System.Data;
using System.Data.SqlClient;

namespace SQL
{
  /// <summary>
  /// Represents a SQL connection and provides methods for executing queries and statements.
  /// </summary>
  internal class Connection
  {
    /// <summary>
    /// Gets the SqlConnection object associated with this Connection instance.
    /// </summary>
    /// <value>
    /// The SqlConnection object used for establishing a connection to the SQL database.
    /// </value>
    public SqlConnection Conn { get; private set; }

    /// <summary>
    /// Initializes a new instance of the Connection class with the provided connection string.
    /// </summary>
    /// <param name="connStr">The connection string to use for the SQL connection.</param>
    public Connection(string connStr)
    {
      Conn = new SqlConnection(connStr);
    }

    /// <summary>
    /// Initializes a new instance of the Connection class with the provided SqlConnection.
    /// </summary>
    /// <param name="conn">The SqlConnection object to use for the SQL connection.</param>
    public Connection(SqlConnection conn)
    {
      Conn = conn;
    }

    /// <summary>
    /// Executes a query SQL statement on the SQL.Manager using the provided or default connection string.
    /// </summary>
    /// <param name="sql">The SQL statement to execute.</param>
    /// <returns>The number of rows affected by the SQL statement.</returns>
    public int DoQuery(string sql)
    {
      // Open the SQL connection
      Conn.Open();

      // Create a SqlCommand object with the provided SQL statement and connection
      SqlCommand com = new SqlCommand(sql, Conn);

      // Execute the SQL statement and get the number of rows affected
      int rowsAffected = com.ExecuteNonQuery();

      // Dispose the SqlCommand object and close the connection
      com.Dispose();
      Conn.Close();

      // Return the number of rows affected
      return rowsAffected;
    }

    /// <summary>
    /// Executes a SQL query on the SQL.Manager and returns the result as a two-dimensional object array.
    /// </summary>
    /// <param name="sql">The SQL query to execute.</param>
    /// <returns>A two-dimensional object array containing the result of the SQL query.</returns>
    public object[][] ExecuteQuery(string sql)
    {
      // Execute the SQL query and retrieve the result as a DataTable
      DataTable dt = ExecuteDataTable(sql);

      // Initialize a object array of object arrays to store the result
      object[][] table = new object[dt.Rows.Count][];

      // Copy the DataRow collection into table
      dt.Rows.CopyTo(table, 0);

      // Return the object array containing the result of the SQL query
      return table;
    }

    /// <summary>
    /// Checks if a record exists in the SQL.Manager based on the provided SQL query.
    /// </summary>
    /// <param name="sql">The SQL query to check for existence.</param>
    /// <returns>True if the record exists, False otherwise.</returns>
    public bool DoesExist(string sql)
    {
      // Open the SQL connection
      Conn.Open();

      // Create a SQL command object and execute the query
      SqlCommand com = new SqlCommand(sql, Conn);
      SqlDataReader reader = com.ExecuteReader();

      // Check if a record exists by attempting to read from the result set
      bool recordExists = reader.Read();

      // Close the connection to release resources
      Conn.Close();

      // Return the result indicating whether a record exists or not
      return recordExists;
    }

    /// <summary>
    /// Executes a SQL query and returns the result as a DataTable object.
    /// </summary>
    /// <param name="sql">The SQL query to execute.</param>
    /// <returns>A DataTable object containing the result of the SQL query.</returns>
    public DataTable ExecuteDataTable(string sql)
    {
      // Open the SQL connection
      Conn.Open();

      // Create a SqlDataAdapter object with the provided SQL statement and connection
      SqlDataAdapter da = new SqlDataAdapter(sql, Conn);

      // Create a DataTable object to hold the result of the SQL query
      DataTable dt = new DataTable();

      // Fill the DataTable with the result of the SQL query
      da.Fill(dt);

      // Dispose the SqlDataAdapter object and close the connection
      da.Dispose();
      Conn.Close();

      // Return the DataTable containing the result of the SQL query
      return dt;
    }

    /// <summary>
    /// Executes a non-query SQL statement and returns the number of rows affected.
    /// </summary>
    /// <param name="sql">The SQL statement to execute.</param>
    /// <returns>The number of rows affected by the SQL statement.</returns>
    public int DoNonQuery(string sql)
    {
      // Open the SQL connection
      Conn.Open();

      // Create a new SqlCommand object with the provided SQL statement and connection
      SqlCommand com = new SqlCommand(sql, Conn);

      // Execute the SQL statement and get the number of rows affected
      int rowsAffected = com.ExecuteNonQuery();

      // Close the SQL connection
      Conn.Close();

      // Return the number of rows affected by the SQL statement
      return rowsAffected;
    }
  }

  /// <summary>
  /// Represents a class that provides SQL syntax generation for MSSQL commands.
  /// </summary>
  internal class Syntax
  {
    /// <summary>
    /// Generates a SELECT query to retrieve specified columns from a table.
    /// </summary>
    /// <param name="tableName">The name of the table to select from.</param>
    /// <param name="columns">An array of column names to select.</param>
    /// <param name="condition">The condition for the select operation.</param>
    /// <returns>The SELECT query as a string.</returns>
    public static string Select(string tableName, string[] columns, string condition = null)
    {
      // Create the WHERE clause based on the condition
      condition = condition == null ? string.Empty : $"WHERE {condition}";

      // Join the column names with a comma separator
      string columnNames = string.Join(", ", columns.Select((col, index) => $"[{col}]"));

      // Generate the SELECT query string
      string query = $"SELECT {columnNames} FROM [{tableName}] {condition}";

      return query;
    }

    /// <summary>
    /// Generates an INSERT query to insert values into a table.
    /// </summary>
    /// <param name="tableName">The name of the table to insert into.</param>
    /// <param name="columns">An array of column names.</param>
    /// <param name="values">An array of corresponding values to insert.</param>
    /// <returns>The INSERT query as a string.</returns>
    public static string Insert(string tableName, string[] columns, object[] values)
    {
      // Join the column names with a comma separator
      string columnNames = string.Join(", ", columns.Select((col, index) => $"[{col}]"));

      // Format the values as parameters
      string parameterNames = string.Join(", ", columns.Select((col, index) => FormatValue(values[index])));

      // Generate the INSERT query string
      string query = $"INSERT INTO [{tableName}] ({columnNames}) VALUES ({parameterNames})";

      return query;
    }

    /// <summary>
    /// Generates an UPDATE query to update values in a table.
    /// </summary>
    /// <param name="tableName">The name of the table to update.</param>
    /// <param name="columns">An array of column names.</param>
    /// <param name="values">An array of corresponding values to update.</param>
    /// <param name="condition">The condition for the update operation.</param>
    /// <returns>The UPDATE query as a string.</returns>
    public static string Update(string tableName, string[] columns, object[] values, string condition)
    {
      // Create the SET clause with the column-value pairs
      var updateStatements = columns.Select((col, index) => $"[{col}]={FormatValue(values[index])}");
      string setClause = string.Join(", ", updateStatements);

      // Generate the UPDATE query string
      string query = $"UPDATE [{tableName}] SET {setClause} WHERE {condition}";

      return query;
    }

    /// <summary>
    /// Generates a DELETE query to delete rows from a table based on a condition.
    /// </summary>
    /// <param name="tableName">The name of the table to delete from.</param>
    /// <param name="condition">The condition for the delete operation.</param>
    /// <returns>The DELETE query as a string.</returns>
    public static string Delete(string tableName, string condition)
    {
      // Generate the DELETE query string
      string query = $"DELETE FROM [{tableName}] WHERE {condition}";

      return query;
    }

    /// <summary>
    /// Generates a SELECT query to retrieve the URL of an image from a specified URL.
    /// </summary>
    /// <param name="url">The URL of the image.</param>
    /// <returns>The SELECT query to retrieve the image URL as a string.</returns>
    public static string Image(string url)
    {
      // Generate the SELECT query string to retrieve the image URL
      string query = $"SELECT BulkColumn FROM Openrowset(Bulk '{url}', Single_Blob) AS image";

      return query;
    }

    /// <summary>
    /// Formats a value based on its type to be used in SQL queries.
    /// </summary>
    /// <param name="value">The value to format.</param>
    /// <returns>The formatted value as a string.</returns>
    private static string FormatValue(object value)
    {
      if (value == null)
      {
        return "NULL";
      }
      else if (value is string str)
      {
        return $"'{str}'";
      }
      else if (value is DateTime date)
      {
        return $@"'{date:dd/MM/yyyy HH:mm:ss.fff}'";
      }
      else
      {
        return value as string;
      }
    }
  }

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
      // Establish a SQL connection using the provided connection string
      SqlConnection conn = GetConnection(connStr);

      // Open the SQL connection
      conn.Open();

      // Create a SqlCommand object with the provided SQL statement and connection
      SqlCommand com = new SqlCommand(sql, conn);

      // Execute the SQL statement and get the number of rows affected
      int rowsAffected = com.ExecuteNonQuery();

      // Dispose the SqlCommand object and close the connection
      com.Dispose();
      conn.Close();

      // Return the number of rows affected
      return rowsAffected;
    }

    /// <summary>
    /// Executes a SQL query on the SQL.Manager and returns the result as a two-dimensional object array.
    /// </summary>
    /// <param name="sql">The SQL query to execute.</param>
    /// <param name="connStr">The connection string to use (optional). If not provided, the default connection string will be used.</param>
    /// <returns>A two-dimensional object array containing the result of the SQL query.</returns>
    public static object[][] ExecuteQuery(string sql, string connStr = defaultConnStr)
    {
      // Execute the SQL query and retrieve the result as a DataTable
      DataTable dt = ExecuteDataTable(sql, connStr);

      // Initialize a object array of object arrays to store the result
      object[][] table = new object[dt.Rows.Count][];

      // Copy the DataRow collection into table
      dt.Rows.CopyTo(table, 0);

      // Return the object array containing the result of the SQL query
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
      // Establish a SQL connection using the provided connection string
      SqlConnection conn = GetConnection(connStr);

      // Open the SQL connection
      conn.Open();

      // Create a SQL command object and execute the query
      SqlCommand com = new SqlCommand(sql, conn);
      SqlDataReader reader = com.ExecuteReader();

      // Check if a record exists by attempting to read from the result set
      bool recordExists = reader.Read();

      // Close the connection to release resources
      conn.Close();

      // Return the result indicating whether a record exists or not
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
      // Establish a SQL connection using the provided connection string
      SqlConnection conn = GetConnection(connStr);

      // Open the SQL connection
      conn.Open();

      // Create a SqlDataAdapter object with the provided SQL statement and connection
      SqlDataAdapter da = new SqlDataAdapter(sql, conn);

      // Create a DataTable object to hold the result of the SQL query
      DataTable dt = new DataTable();

      // Fill the DataTable with the result of the SQL query
      da.Fill(dt);

      // Dispose the SqlDataAdapter object and close the connection
      da.Dispose();
      conn.Close();

      // Return the DataTable containing the result of the SQL query
      return dt;
    }

    /// <summary>
    /// Executes a non-query SQL statement and returns the number of rows affected.
    /// </summary>
    /// <param name="sql">The SQL statement to execute.</param>
    /// <param name="connStr">The connection string to use (optional). If not provided, the default connection string will be used.</param>
    /// <returns>The number of rows affected by the SQL statement.</returns>
    public static int DoNonQuery(string sql, string connStr = defaultConnStr)
    {
      // Establish a SQL connection using the provided connection string
      SqlConnection conn = GetConnection(connStr);

      // Open the SQL connection
      conn.Open();

      // Create a new SqlCommand object with the provided SQL statement and connection
      SqlCommand com = new SqlCommand(sql, conn);

      // Execute the SQL statement and get the number of rows affected
      int rowsAffected = com.ExecuteNonQuery();

      // Close the SQL connection
      conn.Close();

      // Return the number of rows affected by the SQL statement
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
      // Execute the SQL query and retrieve the result set as a DataTable
      DataTable dt = ExecuteDataTable(sql, connStr);

      // If addons array is null, initialize it with empty strings for each column in the DataTable
      addons = addons ?? new string[dt.Columns.Count];

      // Adjust the length of the addons array to match the number of columns in the DataTable
      Array.Resize(ref addons, dt.Columns.Count);

      // Generate the HTML table with form elements
      string html = $@"
<table>
  <tr>
    <form>";

      // Generate the search form inputs
      foreach (DataColumn column in dt.Columns)
      {
        int index = column.Ordinal;
        string name = column.ColumnName;

        html += $@"
      <td>
        <input {addons[index].Replace("readonly", string.Empty).Replace("disabled", string.Empty)} placeholder='{name}' id='search-{index}' type='text' name='{name}' />
      </td>";
      }

      html += $@"
      <td>
        <input type='button' name='search' value='search' onclick='search()' />
      </td>
    </form>
  </tr>";

      // Generate the table rows with form elements for each row in the DataTable
      foreach (DataRow row in dt.Rows)
      {
        html += $@"
  <tr>
    <form method='post' action='{action}'>";

        // Generate the form inputs for each column in the current row
        foreach (DataColumn column in dt.Columns)
        {
          int index = column.Ordinal;
          string name = column.ColumnName;

          html += $@"
      <td>
        <input {addons[index]} placeholder='{name}' type='text' name='{name.ToLower()}' value='{row[index]}' />
      </td>";
        }

        html += $@"
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

      // Generate the form inputs for adding a new row
      foreach (DataColumn column in dt.Columns)
      {
        int index = column.Ordinal;
        string name = column.ColumnName;
        string defaultValue = name.ToLower().Equals("id")
          ? $"{(int)dt.Rows[dt.Rows.Count - 1][index] + 1}"
          : string.Empty;

        html += $@"
      <td>
        <input {addons[index]} placeholder='{name}' type='text' name='{name.ToLower()}' value='{defaultValue}' />
      </td>";
      }

      // Returns the complited form
      return html += $@"
      <td>
        <input type='submit' name='add' value='add' />
      </td>
    </form>
  </tr>
</table>";
    }
  }
}
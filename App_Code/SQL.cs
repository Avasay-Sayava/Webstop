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
    public Connection(string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\sayav\source\repos\Webstop\App_Data\Database.mdf;Integrated Security=True")
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
    /// Gets the SqlConnection object associated with this Connection instance.
    /// </summary>
    /// <returns>The SqlConnection object.</returns>
    public SqlConnection GetConnection() => Conn;

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

      // Initialize an object array of object arrays to store the result
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

    /// <summary>
    /// Retrieves the next integer value from an identity column in the specified table.
    /// </summary>
    /// <param name="tableName">The name of the table.</param>
    /// <returns>The next integer value from the identity column.</returns>
    public int ExecuteNextIdentityValue(string tableName)
    {
      int nextValue = 0;

      Conn.Open();

      // Construct the SQL query to insert a dummy row and retrieve the next identity value
      string query = $"SELECT IDENT_CURRENT('{tableName}') + 1";

      // Execute the query
      using (SqlCommand command = new SqlCommand(query, Conn))
      {
        // Retrieve the result of the query
        object result = command.ExecuteScalar();

        // Convert the result to an integer
        nextValue = Convert.ToInt32(result);
      }

      // Return the next identity value
      return nextValue;
    }

    /// <summary>
    /// Executes a SQL query and generates an HTML table with form elements based on the result set.
    /// </summary>
    /// <param name="sql">The SQL query to execute.</param>
    /// <param name="action">The action attribute of the form.</param>
    /// <param name="addons">Additional attributes to apply to the form inputs (optional).</param>
    /// <returns>The HTML table with form elements.</returns>
    public string ExecuteTableForm(string sql, string action, string[] addons = null)
    {
      // Execute the SQL query and retrieve the result set as a DataTable
      DataTable dt = ExecuteDataTable(sql);

      // If addons array is null, initialize it with empty strings for each column in the DataTable
      addons = addons ?? new string[dt.Columns.Count];

      // Adjust the length of the addons array to match the number of columns in the DataTable
      // Array.Resize(ref addons, dt.Columns.Count) wont work here
      if (addons.Length != dt.Columns.Count)
      {
        // Create a new array with the desired size
        string[] resizedAddons = new string[dt.Columns.Count];

        // Copy the elements from the original addons array to the resizedAddons array
        // We use Math.Min to ensure that we only copy up to the minimum length between the two arrays
        // This prevents an IndexOutOfRangeException if addons.Length is greater than dt.Columns.Count
        Array.Copy(addons, resizedAddons, Math.Min(addons.Length, dt.Columns.Count));

        // Assign the resizedAddons array back to addons
        // This resizes the addons array to the desired size and retains its existing values if possible
        addons = resizedAddons;
      }

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
        <input {(addons[index] ?? "").Replace("readonly", "").Replace("disabled", "")} placeholder='{name}' id='search-{index}' type='text' name='{name}' />
      </td>";
      }

      html += $@"
      <td>
        <input type='button' name='search' value='search' onclick='search()' />
      </td>
    </form>
  </tr>";

      html += $@"
  <tr>
    <form method='post' action='{action}'>";

      // Generate the form inputs for adding a new row
      foreach (DataColumn column in dt.Columns)
      {
        int index = column.Ordinal;
        string name = column.ColumnName;

        html += $@"
      <td>
        <input {addons[index] ?? ""} placeHolder='{name}' type='text' name='{name.ToLower()}' value='{(name.ToLower().Equals("id") ? ExecuteNextIdentityValue("Users").ToString() : "")}' />
      </td>";
      }

      html += $@"
      <td>
        <input type='submit' name='add' value='add' />
      </td>
    </form>
  </tr>";

      // Generate the table rows with form elements for each row in the DataTable
      foreach (DataRow row in dt.Rows)
      {
        html += $@"
  <tr>
    <form method='post' action='{action}'>";

        // Generate the form inputs for each column in the row
        foreach (DataColumn column in dt.Columns)
        {
          int index = column.Ordinal;
          string name = column.ColumnName;
          string value = row[name].ToString();

          html += $@"
      <td>
        <input {addons[index] ?? ""} id='{index}' type='text' name='{name}' value='{value}' />
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

      // Return the generated HTML table with form elements
      return html;
    }

    /// <summary>
    /// Generates an HTML form with inputs for the user to edit their password, email, and name.
    /// </summary>
    /// <param name="action">The action attribute of the form.</param>
    /// <param name="columns">An array of column names to be used as input names and IDs.</param>
    /// <param name="labels">An array of labels to be displayed for each input field.</param>
    /// <param name="id">The user's ID.</param>
    /// <returns>The HTML form for editing the user's profile.</returns>
    public string ExecuteProfileForm(string action, string[] columns, string[] labels, int id)
    {
      // Retrieve the user's data from the database
      DataTable dt = ExecuteDataTable(Syntax.Select("Users", columns, $"[Id]='{id}'"));
      // Get the first row of the retrieved data
      DataRow dr = dt.Rows[0];

      // Start building the HTML form string
      string html = $@"
<form method='post' runat='server' action='{action}'>";

      // Generate HTML form inputs based on the provided columns and labels
      for (int i = 0; i < columns.Length; i++)
      {
        // Get the current column name and label
        string columnName = columns[i];
        string label = labels[i];

        // Create an input field for the current column and populate it with the corresponding data from the DataRow
        html += $@"
  <input type='text' id='{columnName.ToLower()}' placeHolder='{columnName}' name='{columnName.ToLower()}' value='{dr[columnName]}'>";

        // Create a label for the current column (optional)
        html += $@"
  <label for='{columnName.ToLower()}'>{label}</label>";
      }

      // Add the submit button to the form
      html += $@"
  <input type='submit' id='submit' name='submit' value='Apply Changes' />
</form>";

      // Return the complete HTML form string
      return html;
    }
  }

  /// <summary>
  /// Represents a class that provides SQL syntax generation for MSSQL commands.
  /// </summary>
  internal class Syntax
  {
    public static string Select(string tableName, string column, string condition = null)
    {
      return Select(tableName, new string[] { column }, condition);
    }

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
      condition = condition == null ? "" : $"WHERE {condition}";

      // Join the column names with a comma separator
      string columnNames = string.Join(", ", columns.Select((col, index) => col.Equals("*") ? "*" : $"[{col}]"));

      // Generate the SELECT query string
      string query = $"SELECT {columnNames} FROM [{tableName}] {condition}";

      return query;
    }

    public static string Insert(string tableName, string column, object value)
    {
      return Insert(tableName, new string[] { column }, new object[] { value });
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

    public static string Update(string tableName, string column, object value, string condition)
    {
      return Update(tableName, new string[] { column }, new object[] { value }, condition);
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
        return $@"CAST('{date:dd/MM/yyyy HH:mm:ss.fff}' AS DATETIME)";
      }
      else
      {
        return value as string;
      }
    }
  }
}
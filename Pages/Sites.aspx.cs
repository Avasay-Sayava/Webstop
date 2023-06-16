using System;
using System.Data;

namespace Webstop.Pages
{
  /// <summary>
  /// Represents the sites page that displays a list of websites.
  /// </summary>
  public partial class Sites : System.Web.UI.Page
  {
    readonly SQL.Connection conn = new SQL.Connection();

    /// <summary>
    /// The results of websites displayed on the sites page.
    /// </summary>
    public string Results { get; private set; }

    /// <summary>
    /// Event handler for the Page_Load event.
    /// </summary>
    protected void Page_Load(object sender, EventArgs e)
    {
      // Handle form submission and insert new website if it doesn't exist
      if (Request.Form["dialog_submit"] != null
          && !conn.DoesExist(SQL.Syntax.Select("Websites", "*", $"[Address]='{Request.Form["dialog_input"]}'")))
      {
        conn.DoQuery(SQL.Syntax.Insert("Websites", "Address", Request.Form["dialog_input"]));
      }

      DataTable sites = conn.ExecuteDataTable(SQL.Syntax.Select("Websites", "*"));
      Results = "";

      // Generate HTML for website results
      foreach (DataRow row in sites.Rows)
      {
        int avg = conn.ExecuteDataTable($"SELECT AVG([Stars]) FROM [Reviews] WHERE [For]='{row["Id"]}'").Rows[0][0] as int? ?? 0;
        Results += $@"
<div class='result' onclick='location.href=""/Site?address={row["Address"]}""'>
  {avg}<i class='fa fa-star'></i>
  <p><d>https://</d>{row["Address"]}<d>/</d></p>
  <i class='fa {((bool)row["Security"] ? "fa-lock" : "fa-exclamation-triangle")}'></i>
</div>";
      }
    }
  }
}

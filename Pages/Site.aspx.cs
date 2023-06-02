using System;
using System.Data;
using System.Text.RegularExpressions;

namespace Webstop.Pages
{
  public partial class Site : System.Web.UI.Page
  {
    readonly SQL.Connection conn = new SQL.Connection();

    /// <summary>
    /// The content of the site page.
    /// </summary>
    public string Content { get; private set; }

    /// <summary>
    /// Event handler for the Page_Load event.
    /// </summary>
    protected void Page_Load(object sender, EventArgs e)
    {
      // Redirect to error page if not signed in
      if ((Session["Signin"] as int? ?? 0) == 0)
        Response.Redirect("/Error?code=402");

      string address = Request.QueryString["address"] ?? Session["LastSite"] as string;
      string clear = address.Replace("www.", "");

      // Generate site name based on the address
      string name = new Func<string>(() =>
      {
        string res = "";
        string[] names = clear.Split('.');
        for (var i = names.Length - 2; i >= 0; i--)
          res += names[i].ToCharArray()[0].ToString().ToUpper() + names[i].Substring(1).ToLower() + " ";
        return res.Trim();
      })();

      Page.Title = name + " - Webstop";

      // Redirect to error page if address is invalid or website does not exist
      if (!Regex.IsMatch(clear, @"^(?:(?!www\.)[A-Za-z\d]{2,}\.)+[A-Za-z\d]{2,}$")
          || !(conn.DoesExist(SQL.Syntax.Select("Websites", "*", $"[Address]='{address}'"))
          || conn.DoesExist(SQL.Syntax.Select("Websites", "*", $"[Address]='{clear}'"))))
        Response.Redirect("/Error?code=400");

      Session["LastSite"] = address;

      // Get website ID
      int id = conn.ExecuteDataTable(SQL.Syntax.Select("Websites", "Id", $"[Address]='{address}'")).Rows[0][0] as int?
          ?? conn.ExecuteDataTable(SQL.Syntax.Select("Websites", "Id", $"[Address]='{clear}'")).Rows[0][0] as int? ?? 0;

      // Calculate average rating
      int avg = conn.ExecuteDataTable($"SELECT AVG([Stars]) FROM [Reviews] WHERE [For]='{id}'").Rows[0][0] as int? ?? 0;

      DataRow website = conn.ExecuteDataTable(SQL.Syntax.Select("Websites", "*", $"[Id]='{id}'")).Rows[0];
      DataTable reviews = conn.ExecuteDataTable(SQL.Syntax.Select("Reviews", "*", $"[For]='{id}'"));

      Content = $@"
<div id='title'>
    {avg}<i class='fa fa-star'></i>
    <a href='https://{address}/'><h1>{name}</h1></a>
    <i class='fa {((bool)website["Security"] ? "fa-lock" : "fa-exclamation-triangle")}'></i>
</div>";

      // Generate HTML for reviews
      for (int i = 0; i < reviews.Rows.Count; i++)
      {
        DataRow row = reviews.Rows[i];
        string from = conn.ExecuteDataTable(SQL.Syntax.Select("Users", "Name", $"[Id]='{row["From"] as string}'")).Rows[0][0] as string;

        Content += $@"
<div class='review'>
    <h3>- {from} {row["Stars"]}<i class='fa fa-star'></i></h3>
    <p>{row["Description"]}</p>
</div>";
      }

      Content += @"
<button onclick='document.getElementById(""dialog"").showModal()'>Request Review</button>";
    }
  }
}

using System;

namespace Webstop.Pages
{
  public partial class Profile : System.Web.UI.Page
  {
    readonly SQL.Connection conn = new SQL.Connection();

    /// <summary>
    /// The profile form data.
    /// </summary>
    public string ProfileForm { get; private set; }

    /// <summary>
    /// Event handler for the Page_Load event.
    /// </summary>
    protected void Page_Load(object sender, EventArgs e)
    {
      // Redirect to error page if not signed in
      if ((Session["Signin"] as int? ?? 0) == 0)
        Response.Redirect("/Error?code=402");

      // Process form submission
      if (Request.Form["submit"] != null)
      {
        string tableName = "Users";
        string[] columns = { "*" };
        string condition1 = $"[Email]='{Request.Form["email"]}'";
        string condition2 = $"[Id]='{Session["Signin"] as int? ?? 0}'";

        // Check if email exists or matches the signed-in user's email
        if (!conn.DoesExist(SQL.Syntax.Select(tableName, columns, condition1))
        || conn.DoesExist(SQL.Syntax.Select(tableName, columns, $"{condition1} AND {condition2}")))
        {
          columns = new string[] { "Name", "Email", "Password" };
          object[] values = { Request.Form["name"], Request.Form["email"], Request.Form["password"] };

          // Update user profile information
          conn.DoQuery(SQL.Syntax.Update(tableName, columns, values, condition2));
        }
      }

      // Retrieve the profile form data
      ProfileForm = conn.ExecuteProfileForm(
          "Profile",
          new string[] { "Name", "Email", "Password" },
          new string[]
          {
                    "Invalid names. Your names must start with an uppercase letter and must contain more than 1 letter.",
                    "Invalid email.",
                    "Invalid password. Your password must contain at least eight characters (up to 16), one number, lowercase and uppercase letters, and a special character."
          },
          Session["Signin"] as int? ?? 0
      );
    }
  }
}

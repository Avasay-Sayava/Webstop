using Microsoft.Ajax.Utilities;
using System;
using System.Text.RegularExpressions;

namespace Webstop.Pages
{
  public partial class Error : System.Web.UI.Page
  {
    public string code;
    public string msg;
    protected void Page_Load(object sender, EventArgs e)
    {
      code = Regex.IsMatch(Request.QueryString["code"] ?? string.Empty, @"^\d{3}$")
        ? Request.QueryString["code"] ?? string.Empty
        : "400";
      msg = Regex.IsMatch(Request.QueryString["msg"] ?? string.Empty, @"^[A-Za-z./ ']+\.$")
        ? Request.QueryString["msg"] ?? string.Empty
          .Replace("/Pages/", string.Empty)
          .Replace(".aspx", string.Empty)
          .Replace("file", "page")
        : $"Error code {code}";
    }
  }
}
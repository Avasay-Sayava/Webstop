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
      code = Regex.IsMatch(Request.QueryString["code"] ?? "", @"^\d{3}$")
        ? Request.QueryString["code"] ?? ""
        : "400";
      msg = Regex.IsMatch(Request.QueryString["msg"] ?? "", @"^[A-Za-z./ ']+\.$")
        ? Request.QueryString["msg"] ?? ""
          .Replace("/Pages/", "")
          .Replace(".aspx", "")
          .Replace("file", "page")
        : $"Error code {code}";
    }
  }
}
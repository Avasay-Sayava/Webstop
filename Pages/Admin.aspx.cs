using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Webstop.Pages
{
  public partial class Admin : System.Web.UI.Page
  {
    public string table;
    protected void Page_Load(object sender, EventArgs e)
    {
      table = Database.GetDataTable("select * from Users");
    }
  }
}
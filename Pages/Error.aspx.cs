using Microsoft.Exchange.WebServices.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Webstop.Pages
{
  public partial class Error : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      Exception ex = Server.GetLastError();
    }
  }
}
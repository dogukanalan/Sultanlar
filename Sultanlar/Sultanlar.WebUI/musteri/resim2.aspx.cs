using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sultanlar.WebUI.musteri
{
    public partial class resim2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            imgI.Src = "resim.aspx?" + Request.QueryString["str"].Replace("-", "=");
        }
    }
}
using Sultanlar.DatabaseObject.Kenton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sultanlar.WebUI.kenton
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                uyeidMaster.Value = Session["Kenton"] != null ? ((Uyeler)Session["Kenton"]).pkID.ToString() : "0";
            }
        }
    }
}
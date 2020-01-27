using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sultanlar.WebUI
{
    public partial class isbasvurutam : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["BasvuruTamam"] != null)
            {
                if (Convert.ToInt32(Session["BasvuruTamam"]) == 1)
                {
                    Session["BasvuruTamam"] = 0;
                }
            }
            else
            {
                Response.Redirect("index.html");
            }
        }
    }
}
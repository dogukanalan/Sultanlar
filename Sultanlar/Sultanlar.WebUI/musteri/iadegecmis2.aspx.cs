using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Sultanlar.DatabaseObject.Internet;

namespace Sultanlar.WebUI.musteri
{
    public partial class iadegecmis2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                Get();
        }

        private void Get()
        {
            DataTable dt = new DataTable();
            IadeHareketleri.GetObjectByIadeID(Convert.ToInt32(Request.QueryString["id"]), dt);
            repeater1.DataSource = dt;
            repeater1.DataBind();
        }
    }
}
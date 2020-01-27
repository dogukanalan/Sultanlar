using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sultanlar.DatabaseObject;

namespace Sultanlar.WebUI
{
    public partial class insankaynaklari : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            rpArananGorevler.DataSource = ArananGorevler.GetObject(DateTime.Now);
            rpArananGorevler.DataBind();
        }
        //
        //
        protected void lbBasvuru_Click(object sender, EventArgs e)
        {
            Response.Redirect("isbasvuru.html", true);
        }
    }
}
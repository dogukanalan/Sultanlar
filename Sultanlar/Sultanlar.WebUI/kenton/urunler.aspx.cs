using Sultanlar.DatabaseObject.Kenton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sultanlar.WebUI.kenton
{
    public partial class urunler : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<KategorilerUrun> katur = new List<KategorilerUrun>();
            KategorilerUrun.GetObjects(katur);
            repe.DataSource = katur;
            repe.DataBind();
        }
    }
}
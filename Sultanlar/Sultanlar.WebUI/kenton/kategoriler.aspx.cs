using Sultanlar.DatabaseObject.Kenton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sultanlar.WebUI.kenton
{
    public partial class kategoriler : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<KategorilerTarif> kattar = new List<KategorilerTarif>();
            KategorilerTarif.GetObjects(kattar);
            repe.DataSource = kattar;
            repe.DataBind();
        }
    }
}
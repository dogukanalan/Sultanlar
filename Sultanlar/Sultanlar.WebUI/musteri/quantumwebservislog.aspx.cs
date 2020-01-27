using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sultanlar.DatabaseObject.Internet;

namespace Sultanlar.WebUI.musteri
{
    public partial class quantumwebservislog : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblYazilmayan.Text = QuantumWebServisLog.GetCount(false).ToString();
            lblYazilan.Text = QuantumWebServisLog.GetCount(true).ToString();
        }
    }
}
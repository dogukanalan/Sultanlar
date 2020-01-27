using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sultanlar.DatabaseObject.Internet;

namespace Sultanlar.WebUI.merch
{
    public partial class ucUst : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Musteri"] != null)
            {
                txtUye.Text = ((Musteriler)Session["Musteri"]).strAd + " " + ((Musteriler)Session["Musteri"]).strSoyad;
                GetOkunmamisMesaj();
            }
            else
            {
                Image1.Visible = false;
            }
        }

        private void GetOkunmamisMesaj()
        {
            if (IsPostBack)
                return;

            Image1.Visible = GonderilenMesajlar.GetObjectCount(((Musteriler)Session["Musteri"]).pkMusteriID) > 0;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sultanlar.DatabaseObject.Internet;
using Sultanlar.DatabaseObject;
using System.Collections;

namespace Sultanlar.WebUI.musteri
{
    public partial class ucYeniMesaj : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ArrayList mesaj = GonderilenMesajlar.GetLastObject(((Musteriler)Session["Musteri"]).pkMusteriID);

            lblMesajKonu.Text = mesaj[1].ToString();
            lblMesajIcerik.Text = mesaj[2].ToString();
            lblMesajZaman.Text = mesaj[3].ToString();
            lblMesajDepartman.Text = Departmanlar.GetObjectByID(Convert.ToByte(mesaj[4].ToString()));

            GonderilenMesajlar.DoUpdateOkundu(Convert.ToInt32(mesaj[0]), DateTime.Now);
        }

        protected void btnMesajCevapla_Click(object sender, EventArgs e)
        {

        }
    }
}
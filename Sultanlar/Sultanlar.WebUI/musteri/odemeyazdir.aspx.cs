using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sultanlar.DatabaseObject.Internet;

namespace Sultanlar.WebUI.musteri
{
    public partial class odemeyazdir : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);

            if (Session["OdemeAyrintiYazdir"] != null)
            {
                Odemeler odeme = (Odemeler)Session["OdemeAyrintiYazdir"];

                lblSiparisNo.Text = odeme.intSiparisID != 0 ? odeme.intSiparisID.ToString() : "-";
                lblKrediKart.Text = odeme.strMaskedPan;
                lblTutar.Text = odeme.mnTutar.ToString("C3");
                lblTarih.Text = odeme.dtOdemeZamani.ToString().Substring(0, 16);
                lblAuth.Text = odeme.strAuthCode;
                lblHostRef.Text = odeme.strHostRefNum;
                lblTransID.Text = odeme.strTransId;

                Label1.Visible = false;
                divYazdir.Visible = true;
            }
            else
            {
                Label1.Visible = true;
                divYazdir.Visible = false;
                Response.AddHeader("REFRESH", "5");
            }
        }
    }
}
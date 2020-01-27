using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sultanlar.DatabaseObject.Internet;

namespace Sultanlar.WebUI.merch
{
    public partial class konumal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(System.Web.HttpCacheability.NoCache);
            Response.Cache.SetNoStore();

            if (Session["Musteri"] == null)
                Response.Redirect("giris.aspx", true);

            if (!IsPostBack)
            {
                txtSMREF.Text = Request.QueryString["smref"];
                txtTip.Text = Request.QueryString["tip"];
                txtMusteri.Text = CariHesaplar.GetSUBEbySMREF(Convert.ToInt32(Request.QueryString["smref"]), Convert.ToInt32(Request.QueryString["tip"]));
            }
        }

        protected void btnKonum2_Click(object sender, EventArgs e)
        {
            Response.Redirect("konumal2.aspx?smref=" + txtSMREF.Text + "&tip=" + txtTip.Text, true);
        }

        protected void btnKonumKaydet_Click(object sender, EventArgs e)
        {
            SetKonum(txtSMREF.Text, txtTip.Text, txtCoords.Text, txtCoords1.Text);
        }

        protected void SetKonum(string smref, string tip, string Coords, string Coords1)
        {
            string lat = GetLat(Coords1);
            string lng = GetLng(Coords1);
            string adres = Coords;

            Rutlar.SetKonum(Convert.ToInt32(smref), Convert.ToInt32(tip), lat + "," + lng);
            Rutlar.SetKonumAdres(Convert.ToInt32(smref), Convert.ToInt32(tip), adres);

            Response.Redirect("konumlar.aspx", true);
        }

        protected string GetLat(string Ham)
        {
            return Ham.ToString().Substring(0, Ham.ToString().IndexOf(",")).Trim();
        }

        protected string GetLng(string Ham)
        {
            return Ham.Substring(Ham.IndexOf(",") + 1).Trim();
        }

        [System.Web.Services.WebMethod()]
        public static void KonumSet(string smref, string tip, string Coords, string Coords1)
        {
            string lat = Coords1.ToString().Substring(0, Coords1.ToString().IndexOf(",")).Trim();
            string lng = Coords1.Substring(Coords1.IndexOf(",") + 1).Trim();
            string adres = Coords;

            Rutlar.SetKonum(Convert.ToInt32(smref), Convert.ToInt32(tip), lat + "," + lng);
            Rutlar.SetKonumAdres(Convert.ToInt32(smref), Convert.ToInt32(tip), adres);
        }
    }
}
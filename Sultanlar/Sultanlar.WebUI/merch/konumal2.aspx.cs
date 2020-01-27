using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sultanlar.DatabaseObject.Internet;

namespace Sultanlar.WebUI.merch
{
    public partial class konumal2 : System.Web.UI.Page
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
                string konum = Rutlar.GetKonum(Convert.ToInt32(Request.QueryString["smref"]), Convert.ToInt32(Request.QueryString["tip"]));
                if (konum != string.Empty)
                {
                    inputLat.Value = konum.Substring(0, konum.IndexOf(",")).Trim();
                    inputLng.Value = konum.Substring(konum.IndexOf(",") + 1).Trim();
                }
            }
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
    }
}
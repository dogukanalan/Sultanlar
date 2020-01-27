using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sultanlar.DatabaseObject.Internet;
using System.Data;

namespace Sultanlar.WebUI.musteri
{
    public partial class ziyaret : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["smref"] != null && Request.QueryString["barkod"] != null && Request.QueryString["ziygun"] != null && Request.QueryString["mtip"] != null)
            {
                ZiyaretBaslat(Convert.ToInt32(Request.QueryString["smref"]), Request.QueryString["barkod"].ToString(), 
                    Convert.ToDateTime(Request.QueryString["ziygun"]), Convert.ToInt32(Request.QueryString["mtip"]), 
                    txtCoords.Text, txtCoords1.Text);
            }
            else
            {
                divZiyaret.Visible = true;
                lblZiyaretSubesi.Text = Rutlar.GetSube(((ZiyaretZ)Session["ZiyaretZ"]).RUT_ID);
                lblZiyaretBaslangic.Text = ((ZiyaretZ)Session["ZiyaretZ"]).ZIY_BAS_TAR.ToString();
            }
        }

        private bool ZiyaretBaslat(int SMREF, string BARKOD, DateTime ZIYGUN, int MTIP, string Coords, string Coords1)
        {
            bool donendeger = true;

            int GMREF = 0;
            if (MTIP == 1)
                GMREF = CariHesaplar.GetGMREFBySMREF(SMREF);
            else if (MTIP == 2 || MTIP == 3 || MTIP == 5)
                GMREF = CariHesapZ.GetObject(SMREF, MTIP, true).GMREF;
            else if (MTIP == 4)
                GMREF = CariHesaplarTP.GetGMREFBySMREF(SMREF);

            Rutlar.ZiyaretEkle(MTIP,
                ZIYGUN == DateTime.MinValue ? 2 : 1,
                BARKOD, GMREF, SMREF, ((Musteriler)Session["Musteri"]).intSLSREF, BARKOD,
                DateTime.Now, DateTime.Now, 0, Coords1, Coords, "", "", 0, 0, 0, 0);

            Session["ZiyaretZ"] = new ZiyaretZ(MTIP, ZIYGUN == DateTime.MinValue ? 2 : 1, BARKOD, GMREF, SMREF,
                ((Musteriler)Session["Musteri"]).intSLSREF, BARKOD, DateTime.Now, DateTime.Now, 0, Coords1, Coords, "", "", 0, "");

            HttpCookie co = new HttpCookie("sulZiyBaslangic", Rutlar.GetKonum(SMREF, MTIP));
            co.Expires = DateTime.Now.AddHours(10);
            Response.Cookies.Add(co);

            return donendeger;
        }

        protected void lbZiyaretSonlandirUst_Click(object sender, EventArgs e)
        {
            SatisTemsilcisiZiyaretler.GetZiyaretSonlandırmaSebepleri(rblZiyaretSonlandirmaSebepleri.Items, false);
            rblZiyaretSonlandirmaSebepleri.SelectedIndex = 0;
            divZiyaretSonlandirmaSebep.Visible = true;
        }

        protected void lbZiyaretSonlandirmaSebep_Click(object sender, EventArgs e)
        {
            ZiyaretZ stz = (ZiyaretZ)Session["ZiyaretZ"];
            stz.ZIY_BIT_TAR = DateTime.Now;
            stz.ZIY_NDN_ID = SatisTemsilcisiZiyaretler.GetZiyaretSonlandırmaSebepID(Guid.Parse(rblZiyaretSonlandirmaSebepleri.SelectedValue));
            stz.ZIY_NOTLARI = txtZiyaretSonlandirmaSebepAciklama.Text;

            Rutlar.ZiyaretGuncelle(stz.BARKOD, stz.ZIY_BIT_TAR,
                stz.ZIY_NDN_ID,
                txtCoords1.Text,
                txtCoords.Text,
                txtCoordsFark.Text,
                "", stz.ZIY_NOTLARI);
            Session["ZiyaretZ"] = null;

            rblZiyaretSonlandirmaSebepleri.SelectedIndex = 0;
            txtZiyaretSonlandirmaSebepAciklama.Text = string.Empty;

            divZiyaretSonlandirmaSebep.Visible = false;

            lblZiyaretSubesi.Text = string.Empty;
            lblZiyaretBaslangic.Text = string.Empty;
        }

        protected void lbZiyaretIptal_Click(object sender, EventArgs e)
        {
            Response.Cookies.Remove("sulZiyBaslangic");

            ZiyaretZ stz = (ZiyaretZ)Session["ZiyaretZ"];
            Rutlar.ZiyaretSil(stz.RUT_ID);
            Session["ZiyaretZ"] = null;

            divZiyaret.Visible = false;
            lblZiyaretSubesi.Text = string.Empty;
            lblZiyaretBaslangic.Text = string.Empty;
        }
    }
}
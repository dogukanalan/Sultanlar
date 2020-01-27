using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sultanlar.DatabaseObject.Internet;
using System.Data;

namespace Sultanlar.WebUI.merch
{
    public partial class ziyaret : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(System.Web.HttpCacheability.NoCache);
            Response.Cache.SetNoStore();

            if (Session["Musteri"] == null)
                Response.Redirect("giris.aspx", true);

            if (!IsPostBack)
            {
                if (Session["Ziy"] == null)
                    Response.Redirect("rutbugun.aspx", true);

                Ziy ziyaret = (Ziy)Session["Ziy"];
                txtCoords.Text = ziyaret.coords;
                txtCoords1.Text = ziyaret.coords1;



                //bugünkü ziyaret sonlanmamış ise o ziyareti açsın:
                bool ziyaretbaslat = true;
                DataTable dt = new DataTable();
                SatisTemsilcisiZiyaretler.GetObjectLast(dt, ((Musteriler)Session["Musteri"]).intSLSREF);
                if (dt.Rows.Count > 0)
                {
                    if (/*ziyaret.smref == Convert.ToInt32(dt.Rows[0]["intSMREF"]) && ziyaret.mtip == Convert.ToInt32(dt.Rows[0]["strMekan"].ToString()[0]) && */
                        Session["Ziyaret"] != null &&
                        dt.Rows[0]["dtZiyaretBitis"].ToString() == "" && Convert.ToDateTime(dt.Rows[0]["dtZiyaretBaslangic"]).ToShortDateString() == DateTime.Now.ToShortDateString())
                    {
                        ziyaretbaslat = false;
                        txtCoords1onceki.Text = Rutlar.GetKonum(ziyaret.smref, ziyaret.mtip).ToString();
                        divZiyaret.Visible = true;
                        lblZiyaretSubesi.Text = ziyaret.mtip == 1 ? CariHesaplar.GetMUSTERIbySMREF(ziyaret.smref) : ziyaret.mtip == 4 ? CariHesaplarTP.GetSubelerBySMREF(ziyaret.smref)[1].ToString() : CariHesapZ.GetObject(ziyaret.smref, ziyaret.mtip, true).SUBE;
                        lblZiyaretBaslangic.Text = Convert.ToDateTime(dt.Rows[0]["dtZiyaretBaslangic"]).ToShortDateString();
                    }
                }



                if (ziyaretbaslat)
                {
                    if (!ZiyaretBaslat(ziyaret.smref, ziyaret.barkod, ziyaret.ziygun, ziyaret.mtip, ziyaret.coords, ziyaret.coords1))
                    {
                        Session["Ziyaret"] = null;
                        Session["Ziy"] = null;
                        Response.Redirect("ziyarethata.aspx", true);
                    }
                }

                RutResim.GetObjectsTurler(ddlTurler.Items);
            }
        }

        private bool ZiyaretBaslat(int SMREF, string BARKOD, DateTime ZIYGUN, int MTIP, string Coords, string Coords1)
        {
            bool donendeger = true;

            int GMREF = MTIP == 4 ? CariHesaplarTP.GetGMREFBySMREF(SMREF) : MTIP == 2 || MTIP == 3 || MTIP == 5 ? CariHesapZ.GetObject(SMREF, MTIP, true).GMREF : CariHesaplar.GetGMREFBySMREF(SMREF);

            bool bugunyapildi = SatisTemsilcisiZiyaretler.GetObjectsBySLSREFSMREF(((Musteriler)Session["Musteri"]).intSLSREF, SMREF, DateTime.Now);
            BARKOD = bugunyapildi ? ((Musteriler)Session["Musteri"]).intSLSREF.ToString() + GMREF.ToString() + SMREF.ToString() + "." + DateTime.Now.ToString().Replace(" ", ".") : BARKOD;

            DataTable dt = new DataTable();
            SatisTemsilcisiZiyaretler.GetObjectLast(dt, ((Musteriler)Session["Musteri"]).intSLSREF);
            if (dt.Rows.Count > 0)
                if (dt.Rows[0]["dtZiyaretBitis"].ToString() == "" && Convert.ToDateTime(dt.Rows[0]["dtZiyaretBaslangic"]).ToShortDateString() == DateTime.Now.ToShortDateString())
                    return false;

            string koordinatlar = MTIP.ToString() + ";;;" + Coords1 + ";;;" + Coords;

            SatisTemsilcisiZiyaretler stz = new SatisTemsilcisiZiyaretler(
                ((Musteriler)Session["Musteri"]).intSLSREF,
                BARKOD,
                SMREF,
                ZIYGUN,
                DateTime.Now,
                DateTime.MinValue,
                Guid.Empty,
                koordinatlar,
                "-mobil");
            stz.DoInsert();
            Session["Ziyaret"] = stz;

            Rutlar.ZiyaretEkle(
                MTIP,
                ZIYGUN == DateTime.MinValue ? 2 : (bugunyapildi ? 2 : 1),
                BARKOD,
                GMREF,
                SMREF,
                ((Musteriler)Session["Musteri"]).intSLSREF,
                BARKOD,
                DateTime.Now,
                DateTime.Now,
                0,
                Coords1,
                Coords,
                "",
                "-mobil",
                0,
                0,
                0,
                0);

            Response.Cookies.Remove("sulZiyBaslangic");
            HttpCookie co = new HttpCookie("sulZiyBaslangic", Rutlar.GetKonum(SMREF, MTIP));
            co.Expires = DateTime.Now.AddHours(10);
            Response.Cookies.Add(co);
            txtCoords1onceki.Text = Rutlar.GetKonum(SMREF, MTIP).ToString();

            divZiyaret.Visible = true;
            lblZiyaretSubesi.Text = MTIP == 1 ? CariHesaplar.GetMUSTERIbySMREF(stz.intSMREF) : MTIP == 4 ? CariHesaplarTP.GetSubelerBySMREF(stz.intSMREF)[1].ToString() : CariHesapZ.GetObject(stz.intSMREF, MTIP, true).SUBE;
            lblZiyaretBaslangic.Text = stz.dtZiyaretBaslangic.ToString();

            return donendeger;
        }

        protected void lbZiyaretIptal_Click(object sender, EventArgs e)
        {
            SatisTemsilcisiZiyaretler stz = (SatisTemsilcisiZiyaretler)Session["Ziyaret"];
            if (!RutResim.GetResimVarMiByZiyaretID(stz.pkID))
            {
                Response.Cookies.Remove("sulZiyBaslangic");

                stz.DoDelete();
                Rutlar.ZiyaretSil(stz.strBARKOD);
                Session["Ziyaret"] = null;
                Session["Ziy"] = null;

                Response.Redirect("musteriler.aspx", true);
            }
        }

        protected void ZiyaretSonlandir_Click(object sender, EventArgs e)
        {
            SatisTemsilcisiZiyaretler.GetZiyaretSonlandırmaSebepleri(rblZiyaretSonlandirmaSebepleri.Items, false);
            rblZiyaretSonlandirmaSebepleri.SelectedIndex = 0;
            divZiyaretSonlandirmaSebep.Visible = true;
        }

        protected void lbZiyaretSonlandirmaSebep_Click(object sender, EventArgs e)
        {
            SatisTemsilcisiZiyaretler stz = (SatisTemsilcisiZiyaretler)Session["Ziyaret"];
            stz.dtZiyaretBitis = DateTime.Now;
            stz.unSebep = Guid.Parse(rblZiyaretSonlandirmaSebepleri.SelectedValue);
            stz.strAciklama = txtZiyaretSonlandirmaSebepAciklama.Text + "-mobil";
            stz.DoUpdate();

            Rutlar.ZiyaretGuncelle(stz.strBARKOD, stz.dtZiyaretBitis,
                SatisTemsilcisiZiyaretler.GetZiyaretSonlandırmaSebepID(Guid.Parse(rblZiyaretSonlandirmaSebepleri.SelectedValue)),
                txtCoords1.Text,
                txtCoords.Text,
                txtCoordsFark.Text,
                "mobil", stz.strAciklama);

            Response.Cookies.Remove("sulZiyBaslangic");

            Session["Ziyaret"] = null;
            Session["Ziy"] = null;

            Response.Redirect("rutbugun.aspx", true);
        }

        protected void lbSiparis_Click(object sender, EventArgs e)
        {
            int smref = ((Ziy)Session["Ziy"]).smref;
            Response.Redirect("siparis.aspx?smref=" + smref.ToString(), true);
        }
    }
}
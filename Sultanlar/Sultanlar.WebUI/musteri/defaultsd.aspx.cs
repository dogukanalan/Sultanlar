using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sultanlar.DatabaseObject.Internet;
using System.Data;
using System.Collections;

namespace Sultanlar.WebUI.musteri
{
    public partial class defaultsd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (((Musteriler)Session["Musteri"]).tintUyeTipiID != 8 && ((Musteriler)Session["Musteri"]).tintUyeTipiID != 9 && ((Musteriler)Session["Musteri"]).tintUyeTipiID != 2) // sd elemanı, bayi elemanı
                Response.Redirect("default.aspx", true);

            if (!IsPostBack)
                GetBayiler();
        }

        private void GetBayiler()
        {
            DataTable dt = new DataTable();
            CariHesaplarTP.GetObjects(dt, 0);

            DataRow drow = dt.NewRow();
            drow["GMREF"] = 1001327;
            drow["SMREF"] = 1001327;
            drow["MUSTERI"] = "SULTANLAR PAZARLAMA A.Ş.";
            dt.Rows.Add(drow);

            ArrayList al = new ArrayList();
            UyeBayiler.GetObjectOnlyBayiler(al, ((Musteriler)Session["Musteri"]).pkMusteriID, true);
            ArrayList silinecekler = new ArrayList();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                bool var = false;
                for (int j = 0; j < al.Count; j++)
                    if (Convert.ToInt32(dt.Rows[i]["SMREF"]) == Convert.ToInt32(al[j]))
                        var = true;

                if (!var)
                    silinecekler.Add(dt.Rows[i]);
            }

            for (int i = 0; i < silinecekler.Count; i++)
                dt.Rows.Remove((DataRow)silinecekler[i]);

            dlBayiler.DataSource = dt;
            dlBayiler.DataBind();
        }

        private void GetAltCariler(int GMREF)
        {
            DataTable dt = new DataTable();
            if (GMREF != 1001327)
            {
                CariHesaplarTP.GetObjects(dt, GMREF);
                inputBayiGibi.Value = "1";
                lblBayi.Text = "<br />" + CariHesaplarTP.GetObject(GMREF, true).MUSTERI + "<br />";
            }
            else
            {
                CariHesaplar.GetObjects(dt, true);
                inputBayiGibi.Value = "0";
                lblBayi.Text = "<br />SULTANLAR PAZARLAMA A.Ş.<br />";
            }
            dlAltCariler.DataSource = dt;
            dlAltCariler.DataBind();
        }

        protected void AltCariler_Click(object sender, EventArgs e)
        {
            lbGeri.Visible = true;
            dlBayiler.Visible = false;
            GetAltCariler(Convert.ToInt32(((LinkButton)sender).CommandArgument));
            dlAltCariler.Visible = true;
        }

        protected void Konum_Click(object sender, EventArgs e)
        {
            string koordinatlar = (inputBayiGibi.Value == "1" ? "4" : "1") + ";;;" + txtCoords1.Text + ";;;" + txtCoords.Text;
            int smref = Convert.ToInt32(((LinkButton)sender).CommandArgument);
            int slsref = ((Musteriler)Session["Musteri"]).intSLSREF;
            int gmref = (inputBayiGibi.Value == "1" ? CariHesaplarTP.GetGMREFBySMREF(smref) : CariHesaplar.GetGMREFBySMREF(smref));
            string barkod = slsref.ToString() + gmref.ToString() + smref.ToString() + "." + DateTime.Now.ToString().Replace(" ", ".");

            SatisTemsilcisiZiyaretler stz = new SatisTemsilcisiZiyaretler(
                ((Musteriler)Session["Musteri"]).intSLSREF,
                barkod,
                smref,
                DateTime.MinValue,
                DateTime.Now,
                DateTime.MinValue,
                Guid.Empty,
                koordinatlar,
                "");
            stz.DoInsert();
            Session["ZiyaretSD"] = stz;

            Rutlar.ZiyaretEkle(
                (inputBayiGibi.Value == "1" ? 4 : 1),
                2,
                barkod,
                gmref,
                smref,
                slsref,
                barkod,
                DateTime.Now,
                DateTime.Now,
                0,
                txtCoords1.Text,
                txtCoords.Text,
                "",
                "",
                0,
                0,
                0,
                0);

            HttpCookie co = new HttpCookie("sulSdZiyBaslangic", Rutlar.GetKonum(smref, (inputBayiGibi.Value == "1" ? 4 : 1)));
            co.Expires = DateTime.Now.AddHours(10);
            Response.Cookies.Add(co);

            divZiyaret.Visible = true;
            lblZiyaretSubesi.Text = inputBayiGibi.Value == "0" ? CariHesaplar.GetMUSTERIbySMREF(stz.intSMREF) : CariHesaplarTP.GetSubelerBySMREF(stz.intSMREF)[1].ToString();
            lblZiyaretBaslangic.Text = stz.dtZiyaretBaslangic.ToString();
        }

        protected void lbZiyaretSonlandirUst_Click(object sender, EventArgs e)
        {
            SatisTemsilcisiZiyaretler.GetZiyaretSonlandırmaSebepleri(rblZiyaretSonlandirmaSebepleri.Items, false);
            rblZiyaretSonlandirmaSebepleri.SelectedIndex = 0;
            divZiyaretSonlandirmaSebep.Visible = true;
        }

        protected void lbZiyaretSonlandirmaSebep_Click(object sender, EventArgs e)
        {
            SatisTemsilcisiZiyaretler stz = (SatisTemsilcisiZiyaretler)Session["ZiyaretSD"];
            stz.dtZiyaretBitis = DateTime.Now;
            stz.unSebep = Guid.Parse(rblZiyaretSonlandirmaSebepleri.SelectedValue);
            stz.strAciklama = txtZiyaretSonlandirmaSebepAciklama.Text;
            stz.DoUpdate();

            Rutlar.ZiyaretGuncelle(stz.strBARKOD, stz.dtZiyaretBitis,
                SatisTemsilcisiZiyaretler.GetZiyaretSonlandırmaSebepID(Guid.Parse(rblZiyaretSonlandirmaSebepleri.SelectedValue)),
                txtCoords1.Text,
                txtCoords.Text,
                txtCoordsFark.Text,
                "", stz.strAciklama);

            rblZiyaretSonlandirmaSebepleri.SelectedIndex = 0;
            txtZiyaretSonlandirmaSebepAciklama.Text = string.Empty;
            Session["ZiyaretSD"] = null;
            divZiyaretSonlandirmaSebep.Visible = false;

            divZiyaret.Visible = false;
            lblZiyaretSubesi.Text = string.Empty;
            lblZiyaretBaslangic.Text = string.Empty;
        }

        protected void lbGeri_Click(object sender, EventArgs e)
        {
            lbGeri.Visible = false;
            dlBayiler.Visible = true;
            lblBayi.Text = string.Empty;
            GetBayiler();
            dlAltCariler.Visible = false;
        }

        protected void Map_Click(object sender, ImageClickEventArgs e)
        {
            //Response.Redirect("https://www.google.com/maps/place//@" + ((ImageButton)sender).CommandArgument + ",16z/data=!4m2!3m1!1s0x0:0x0?hl=tr");
        }
    }
}
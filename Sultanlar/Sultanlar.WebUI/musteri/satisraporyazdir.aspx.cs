using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data;
using Sultanlar.DatabaseObject.Internet;
using System.Collections;

namespace Sultanlar.WebUI.musteri
{
    public partial class satisraporyazdir : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            
            if (Session["SatisRaporYazdirTumOzelKod"] != null)
            {
                Label1.Visible = false;
                divYazdir.Visible = true;
                GetSatisRapor();
                GetToplam();
                Session["SatisRaporYazdirTumOzelKod"] = null;
                Session["SatisRaporYazdirSLSREF"] = null;
            }
            else if (Session["SatisRaporYazdirGMREF"] != null && Session["SatisRaporYazdirSLSREF"] != null)
            {
                int GMREF = Convert.ToInt32(Session["SatisRaporYazdirGMREF"]);
                int SLSREF = Convert.ToInt32(Session["SatisRaporYazdirSLSREF"]);
                Label1.Visible = false;
                divYazdir.Visible = true;
                GetSatisRaporByGMREF(GMREF, SLSREF);
                GetSatisRaporToplamByGMREF(GMREF, SLSREF);
                Session["SatisRaporYazdirGMREF"] = null;
                Session["SatisRaporYazdirSLSREF"] = null;
            }
            else if (Session["SatisRaporYazdirSMREF"] != null && Session["SatisRaporYazdirSLSREF"] != null)
            {
                int SMREF = Convert.ToInt32(Session["SatisRaporYazdirSMREF"]);
                int SLSREF = Convert.ToInt32(Session["SatisRaporYazdirSLSREF"]);
                Label1.Visible = false;
                divYazdir.Visible = true;
                GetSatisRaporBySMREF(SMREF, SLSREF);
                GetSatisRaporToplamBySMREF(SMREF, SLSREF);
                Session["SatisRaporYazdirSMREF"] = null;
                Session["SatisRaporYazdirSLSREF"] = null;
            }
            else if (Session["SatisRaporYazdirSLSREFs"] == null && Session["SatisRaporYazdirSLSREF"] != null)
            {
                int SLSREF = Convert.ToInt32(Session["SatisRaporYazdirSLSREF"]);
                Label1.Visible = false;
                divYazdir.Visible = true;
                GetSatisRaporBySLSREF(SLSREF);
                GetToplamBySLSREF(SLSREF);
                Session["SatisRaporYazdirSLSREF"] = null;
            }
            else if (Session["SatisRaporYazdirSLSREFs"] != null && Session["SatisRaporYazdirSLSREF"] != null)
            {
                int SLSREF = Convert.ToInt32(Session["SatisRaporYazdirSLSREF"]);
                Label1.Visible = false;
                divYazdir.Visible = true;
                GetSatisRaporBySLSREFs(SLSREF);
                GetToplamBySLSREFs(SLSREF);
                Session["SatisRaporYazdirSLSREFs"] = null;
                Session["SatisRaporYazdirSLSREF"] = null;
            }
            else
            {
                Label1.Visible = true;
                divYazdir.Visible = false;
                Response.AddHeader("REFRESH", "5");
            }
        }





        private int GetSatisRaporCountBySMREF(int SMREF, int SLSREF)
        {
            bool TED = SatisTemsilcileri.GetSATKOD1BySLSREF(SLSREF).StartsWith("8");
            return SatisRapor.GetObjectCountBySMREF(SMREF, SLSREF, (ListItemCollection)Session["downloadyazdirsatisraporurunler"], (int)Session["downloadyazdirsatisraporurunlerselectedindex"],
                Session["downloadyazdirsatisraporozelkod"].ToString(), Session["downloadyazdirsatisraporfiyattip"].ToString(), (bool)Session["downloadyazdirsatisraporbedelsiz"],
                (bool)Session["downloadyazdirsatisraporiadeler"],
                ((UyeYetkileri)Session["Yetkiler"]).OzelKodlar, ((UyeYetkileri)Session["Yetkiler"]).GrupKodlar,
                (DateTime)Session["downloadyazdirsatisraportarih1"], (DateTime)Session["downloadyazdirsatisraportarih2"], TED);
        }

        private void GetSatisRaporBySMREF(int SMREF, int SLSREF)
        {
            bool TED = SatisTemsilcileri.GetSATKOD1BySLSREF(SLSREF).StartsWith("8");
            DataTable dt = new DataTable();
            SatisRapor.GetObjectsBySMREF(dt, SMREF, SLSREF, (ListItemCollection)Session["downloadyazdirsatisraporurunler"], (int)Session["downloadyazdirsatisraporurunlerselectedindex"],
                Session["downloadyazdirsatisraporozelkod"].ToString(), Session["downloadyazdirsatisraporfiyattip"].ToString(), (bool)Session["downloadyazdirsatisraporbedelsiz"],
                (bool)Session["downloadyazdirsatisraporiadeler"],
                0, GetSatisRaporCountBySMREF(SMREF, SLSREF),
                ((UyeYetkileri)Session["Yetkiler"]).OzelKodlar, ((UyeYetkileri)Session["Yetkiler"]).GrupKodlar,
                (DateTime)Session["downloadyazdirsatisraportarih1"], (DateTime)Session["downloadyazdirsatisraportarih2"], TED);
            DataList1.DataSource = dt;
            DataList1.DataBind();
        }

        private void GetSatisRaporToplamBySMREF(int SMREF, int SLSREF)
        {
            bool TED = SatisTemsilcileri.GetSATKOD1BySLSREF(SLSREF).StartsWith("8");
            ArrayList toplamlar = SatisRapor.GetToplamFiyatlarBySMREF(SMREF, SLSREF, (ListItemCollection)Session["downloadyazdirsatisraporurunler"], (int)Session["downloadyazdirsatisraporurunlerselectedindex"],
                Session["downloadyazdirsatisraporozelkod"].ToString(), Session["downloadyazdirsatisraporfiyattip"].ToString(), (bool)Session["downloadyazdirsatisraporbedelsiz"],
                (bool)Session["downloadyazdirsatisraporiadeler"],
                ((UyeYetkileri)Session["Yetkiler"]).OzelKodlar, ((UyeYetkileri)Session["Yetkiler"]).GrupKodlar,
                (DateTime)Session["downloadyazdirsatisraportarih1"], (DateTime)Session["downloadyazdirsatisraportarih2"], TED);
            lblToplamBrut.Text = Convert.ToDecimal(toplamlar[0]).ToString("C2");
            lblToplamIskonto.Text = Convert.ToDecimal(toplamlar[1]).ToString("C2");
            lblToplamNet.Text = Convert.ToDecimal(toplamlar[2]).ToString("C2");
            lblToplamNETKDV.Text = Convert.ToDecimal(toplamlar[3]).ToString("C2");
            lblToplamAdet.Text = Convert.ToInt32(toplamlar[4]).ToString();
            lblToplamKoli.Text = Convert.ToInt32(toplamlar[5]).ToString();
        }





        private int GetSatisRaporCountByGMREF(int GMREF, int SLSREF)
        {
            bool TED = SatisTemsilcileri.GetSATKOD1BySLSREF(SLSREF).StartsWith("8");

            return SatisRapor.GetObjectCountByGMREF(GMREF, SLSREF, (ListItemCollection)Session["downloadyazdirsatisraporurunler"], (int)Session["downloadyazdirsatisraporurunlerselectedindex"],
                Session["downloadyazdirsatisraporozelkod"].ToString(), Session["downloadyazdirsatisraporfiyattip"].ToString(), (bool)Session["downloadyazdirsatisraporbedelsiz"],
                (bool)Session["downloadyazdirsatisraporiadeler"],
                ((UyeYetkileri)Session["Yetkiler"]).OzelKodlar, ((UyeYetkileri)Session["Yetkiler"]).GrupKodlar,
                (DateTime)Session["downloadyazdirsatisraportarih1"], (DateTime)Session["downloadyazdirsatisraportarih2"], TED);
        }

        private void GetSatisRaporByGMREF(int GMREF, int SLSREF)
        {
            bool TED = SatisTemsilcileri.GetSATKOD1BySLSREF(SLSREF).StartsWith("8");

            DataTable dt = new DataTable();
            SatisRapor.GetObjectsByGMREF(dt, GMREF, SLSREF, (ListItemCollection)Session["downloadyazdirsatisraporurunler"], (int)Session["downloadyazdirsatisraporurunlerselectedindex"],
                Session["downloadyazdirsatisraporozelkod"].ToString(), Session["downloadyazdirsatisraporfiyattip"].ToString(), (bool)Session["downloadyazdirsatisraporbedelsiz"],
                (bool)Session["downloadyazdirsatisraporiadeler"],
                0, GetSatisRaporCountByGMREF(GMREF, SLSREF),
                ((UyeYetkileri)Session["Yetkiler"]).OzelKodlar, ((UyeYetkileri)Session["Yetkiler"]).GrupKodlar,
                (DateTime)Session["downloadyazdirsatisraportarih1"], (DateTime)Session["downloadyazdirsatisraportarih2"], TED);
            DataList1.DataSource = dt;
            DataList1.DataBind();
        }

        private void GetSatisRaporToplamByGMREF(int GMREF, int SLSREF)
        {
            bool TED = SatisTemsilcileri.GetSATKOD1BySLSREF(SLSREF).StartsWith("8");

            ArrayList toplamlar = SatisRapor.GetToplamFiyatlarByGMREF(GMREF, SLSREF, (ListItemCollection)Session["downloadyazdirsatisraporurunler"], (int)Session["downloadyazdirsatisraporurunlerselectedindex"],
                Session["downloadyazdirsatisraporozelkod"].ToString(), Session["downloadyazdirsatisraporfiyattip"].ToString(), (bool)Session["downloadyazdirsatisraporbedelsiz"],
                (bool)Session["downloadyazdirsatisraporiadeler"],
                ((UyeYetkileri)Session["Yetkiler"]).OzelKodlar, ((UyeYetkileri)Session["Yetkiler"]).GrupKodlar,
                (DateTime)Session["downloadyazdirsatisraportarih1"], (DateTime)Session["downloadyazdirsatisraportarih2"], TED);
            lblToplamBrut.Text = Convert.ToDecimal(toplamlar[0]).ToString("C2");
            lblToplamIskonto.Text = Convert.ToDecimal(toplamlar[1]).ToString("C2");
            lblToplamNet.Text = Convert.ToDecimal(toplamlar[2]).ToString("C2");
            lblToplamNETKDV.Text = Convert.ToDecimal(toplamlar[3]).ToString("C2");
            lblToplamAdet.Text = Convert.ToInt32(toplamlar[4]).ToString();
            lblToplamKoli.Text = Convert.ToInt32(toplamlar[5]).ToString();
        }



        private int GetSatisRaporCountBySLSREF(int SLSREF)
        {
            bool TED = SatisTemsilcileri.GetSATKOD1BySLSREF(SLSREF).StartsWith("8");
            return SatisRapor.GetObjectCountBySLSREF(SLSREF, (ListItemCollection)Session["downloadyazdirsatisraporurunler"], (int)Session["downloadyazdirsatisraporurunlerselectedindex"],
                Session["downloadyazdirsatisraporozelkod"].ToString(), Session["downloadyazdirsatisraporfiyattip"].ToString(), (bool)Session["downloadyazdirsatisraporbedelsiz"],
                (bool)Session["downloadyazdirsatisraporiadeler"],
                ((UyeYetkileri)Session["Yetkiler"]).OzelKodlar, ((UyeYetkileri)Session["Yetkiler"]).GrupKodlar,
                (DateTime)Session["downloadyazdirsatisraportarih1"], (DateTime)Session["downloadyazdirsatisraportarih2"], TED);
        }

        private void GetSatisRaporBySLSREF(int SLSREF)
        {
            bool TED = SatisTemsilcileri.GetSATKOD1BySLSREF(SLSREF).StartsWith("8");
            DataTable dt = new DataTable();
            SatisRapor.GetObjectsBySLSREF(dt, SLSREF, (ListItemCollection)Session["downloadyazdirsatisraporurunler"], (int)Session["downloadyazdirsatisraporurunlerselectedindex"],
                Session["downloadyazdirsatisraporozelkod"].ToString(), Session["downloadyazdirsatisraporfiyattip"].ToString(), (bool)Session["downloadyazdirsatisraporbedelsiz"],
                (bool)Session["downloadyazdirsatisraporiadeler"], 
                0, GetSatisRaporCountBySLSREF(SLSREF),
                ((UyeYetkileri)Session["Yetkiler"]).OzelKodlar, ((UyeYetkileri)Session["Yetkiler"]).GrupKodlar,
                (DateTime)Session["downloadyazdirsatisraportarih1"], (DateTime)Session["downloadyazdirsatisraportarih2"], TED);
            DataList1.DataSource = dt;
            DataList1.DataBind();
        }

        private void GetToplamBySLSREF(int SLSREF)
        {
            bool TED = SatisTemsilcileri.GetSATKOD1BySLSREF(SLSREF).StartsWith("8");
            ArrayList toplamlar = SatisRapor.GetToplamFiyatlarBySLSREF(SLSREF, (ListItemCollection)Session["downloadyazdirsatisraporurunler"], (int)Session["downloadyazdirsatisraporurunlerselectedindex"],
                Session["downloadyazdirsatisraporozelkod"].ToString(), Session["downloadyazdirsatisraporfiyattip"].ToString(), (bool)Session["downloadyazdirsatisraporbedelsiz"],
                (bool)Session["downloadyazdirsatisraporiadeler"],
                ((UyeYetkileri)Session["Yetkiler"]).OzelKodlar, ((UyeYetkileri)Session["Yetkiler"]).GrupKodlar,
                (DateTime)Session["downloadyazdirsatisraportarih1"], (DateTime)Session["downloadyazdirsatisraportarih2"], TED);
            lblToplamBrut.Text = Convert.ToDecimal(toplamlar[0]).ToString("C2");
            lblToplamIskonto.Text = Convert.ToDecimal(toplamlar[1]).ToString("C2");
            lblToplamNet.Text = Convert.ToDecimal(toplamlar[2]).ToString("C2");
            lblToplamNETKDV.Text = Convert.ToDecimal(toplamlar[3]).ToString("C2");
            lblToplamAdet.Text = Convert.ToInt32(toplamlar[4]).ToString();
            lblToplamKoli.Text = Convert.ToInt32(toplamlar[5]).ToString();
        }




        private int GetSatisRaporCountBySLSREFs(int SLSREF)
        {
            ArrayList slsrefs = SatisTemsilcileriSefler.GetAltRefler(SLSREF);
            bool TED = SatisTemsilcileri.GetSATKOD1BySLSREF(SLSREF).StartsWith("8");
            return SatisRapor.GetObjectCountBySLSREFs(slsrefs, (ListItemCollection)Session["downloadyazdirsatisraporurunler"], (int)Session["downloadyazdirsatisraporurunlerselectedindex"],
                Session["downloadyazdirsatisraporozelkod"].ToString(), Session["downloadyazdirsatisraporfiyattip"].ToString(), (bool)Session["downloadyazdirsatisraporbedelsiz"],
                (bool)Session["downloadyazdirsatisraporiadeler"],
                ((UyeYetkileri)Session["Yetkiler"]).OzelKodlar, ((UyeYetkileri)Session["Yetkiler"]).GrupKodlar,
                (DateTime)Session["downloadyazdirsatisraportarih1"], (DateTime)Session["downloadyazdirsatisraportarih2"], TED);
        }

        private void GetSatisRaporBySLSREFs(int SLSREF)
        {
            ArrayList slsrefs = SatisTemsilcileriSefler.GetAltRefler(SLSREF);
            bool TED = SatisTemsilcileri.GetSATKOD1BySLSREF(SLSREF).StartsWith("8");
            DataTable dt = new DataTable();
            SatisRapor.GetObjectsBySLSREFs(dt, slsrefs, (ListItemCollection)Session["downloadyazdirsatisraporurunler"], (int)Session["downloadyazdirsatisraporurunlerselectedindex"],
                Session["downloadyazdirsatisraporozelkod"].ToString(), Session["downloadyazdirsatisraporfiyattip"].ToString(), (bool)Session["downloadyazdirsatisraporbedelsiz"],
                (bool)Session["downloadyazdirsatisraporiadeler"], 
                0, GetSatisRaporCountBySLSREFs(SLSREF),
                ((UyeYetkileri)Session["Yetkiler"]).OzelKodlar, ((UyeYetkileri)Session["Yetkiler"]).GrupKodlar,
                (DateTime)Session["downloadyazdirsatisraportarih1"], (DateTime)Session["downloadyazdirsatisraportarih2"], TED);
            DataList1.DataSource = dt;
            DataList1.DataBind();
        }

        private void GetToplamBySLSREFs(int SLSREF)
        {
            ArrayList slsrefs = SatisTemsilcileriSefler.GetAltRefler(SLSREF);
            bool TED = SatisTemsilcileri.GetSATKOD1BySLSREF(SLSREF).StartsWith("8");
            ArrayList toplamlar = SatisRapor.GetToplamFiyatlarBySLSREFs(slsrefs, (ListItemCollection)Session["downloadyazdirsatisraporurunler"], (int)Session["downloadyazdirsatisraporurunlerselectedindex"],
                Session["downloadyazdirsatisraporozelkod"].ToString(), Session["downloadyazdirsatisraporfiyattip"].ToString(), (bool)Session["downloadyazdirsatisraporbedelsiz"],
                (bool)Session["downloadyazdirsatisraporiadeler"],
                ((UyeYetkileri)Session["Yetkiler"]).OzelKodlar, ((UyeYetkileri)Session["Yetkiler"]).GrupKodlar,
                (DateTime)Session["downloadyazdirsatisraportarih1"], (DateTime)Session["downloadyazdirsatisraportarih2"], TED);
            lblToplamBrut.Text = Convert.ToDecimal(toplamlar[0]).ToString("C2");
            lblToplamIskonto.Text = Convert.ToDecimal(toplamlar[1]).ToString("C2");
            lblToplamNet.Text = Convert.ToDecimal(toplamlar[2]).ToString("C2");
            lblToplamNETKDV.Text = Convert.ToDecimal(toplamlar[3]).ToString("C2");
            lblToplamAdet.Text = Convert.ToInt32(toplamlar[4]).ToString();
            lblToplamKoli.Text = Convert.ToInt32(toplamlar[5]).ToString();
        }



        private int GetSatisRaporCount()
        {
            return SatisRapor.GetObjectCount((ListItemCollection)Session["downloadyazdirsatisraporurunler"], (int)Session["downloadyazdirsatisraporurunlerselectedindex"],
                Session["downloadyazdirsatisraporozelkod"].ToString(), Session["downloadyazdirsatisraporfiyattip"].ToString(), (bool)Session["downloadyazdirsatisraporbedelsiz"],
                (bool)Session["downloadyazdirsatisraporiadeler"],
                ((UyeYetkileri)Session["Yetkiler"]).OzelKodlar, ((UyeYetkileri)Session["Yetkiler"]).GrupKodlar,
                (DateTime)Session["downloadyazdirsatisraportarih1"], (DateTime)Session["downloadyazdirsatisraportarih2"]);
        }

        private void GetSatisRapor()
        {
            DataTable dt = new DataTable();
            SatisRapor.GetObjects(dt, (ListItemCollection)Session["downloadyazdirsatisraporurunler"], (int)Session["downloadyazdirsatisraporurunlerselectedindex"],
                Session["downloadyazdirsatisraporozelkod"].ToString(), Session["downloadyazdirsatisraporfiyattip"].ToString(), (bool)Session["downloadyazdirsatisraporbedelsiz"],
                (bool)Session["downloadyazdirsatisraporiadeler"], 
                0, GetSatisRaporCount(),
                ((UyeYetkileri)Session["Yetkiler"]).OzelKodlar, ((UyeYetkileri)Session["Yetkiler"]).GrupKodlar,
                (DateTime)Session["downloadyazdirsatisraportarih1"], (DateTime)Session["downloadyazdirsatisraportarih2"]);
            DataList1.DataSource = dt;
            DataList1.DataBind();
        }

        private void GetToplam()
        {
            ArrayList toplamlar = SatisRapor.GetToplamFiyatlar((ListItemCollection)Session["downloadyazdirsatisraporurunler"], (int)Session["downloadyazdirsatisraporurunlerselectedindex"],
                Session["downloadyazdirsatisraporozelkod"].ToString(), Session["downloadyazdirsatisraporfiyattip"].ToString(), (bool)Session["downloadyazdirsatisraporbedelsiz"],
                (bool)Session["downloadyazdirsatisraporiadeler"],
                ((UyeYetkileri)Session["Yetkiler"]).OzelKodlar, ((UyeYetkileri)Session["Yetkiler"]).GrupKodlar,
                (DateTime)Session["downloadyazdirsatisraportarih1"], (DateTime)Session["downloadyazdirsatisraportarih2"]);
            lblToplamBrut.Text = Convert.ToDecimal(toplamlar[0]).ToString("C2");
            lblToplamIskonto.Text = Convert.ToDecimal(toplamlar[1]).ToString("C2");
            lblToplamNet.Text = Convert.ToDecimal(toplamlar[2]).ToString("C2");
            lblToplamNETKDV.Text = Convert.ToDecimal(toplamlar[3]).ToString("C2");
            lblToplamAdet.Text = Convert.ToInt32(toplamlar[4]).ToString();
            lblToplamKoli.Text = Convert.ToInt32(toplamlar[5]).ToString();
        }
    }
}
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
    public partial class ekstreyazdir : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);

            if (Session["EkstreYazdirGMREF"] != null)
            {
                int GMREF = Convert.ToInt32(Session["EkstreYazdirGMREF"]);
                Label1.Visible = false;
                divYazdir.Visible = true;
                GetEkstrelerByGMREF(GMREF);
                GetToplam(GMREF);
                lblMusteri.Text = CariHesaplar.GetMUSTERIbyGMREF(GMREF);
                Session["EkstreYazdirGMREF"] = null;
            }
            else
            {
                Label1.Visible = true;
                divYazdir.Visible = false;
                Response.AddHeader("REFRESH", "5");
            }
        }

        private int GetEkstrelerCountByGMREF(int GMREF)
        {
            return Ekstreler.GetObjectsCountByGMREF(GMREF, -1,
                (DateTime)Session["downloadyazdirekstretarih1"], (DateTime)Session["downloadyazdirekstretarih2"], (bool)Session["downloadyazdirekstrevgb"], (string)Session["downloadyazdirekstreisyeri"]);
        }

        private void GetEkstrelerByGMREF(int GMREF)
        {
            Session["EkstreGetirilecekGMREF"] = GMREF;

            DataTable dt = new DataTable();
            Ekstreler.GetObjectsByGMREF(dt, GMREF, 0, GetEkstrelerCountByGMREF(GMREF), -1,
                (DateTime)Session["downloadyazdirekstretarih1"], (DateTime)Session["downloadyazdirekstretarih2"], (bool)Session["downloadyazdirekstrevgb"], (string)Session["downloadyazdirekstreisyeri"]);
            DataList1.DataSource = dt;
            DataList1.DataBind();
        }

        private void GetToplam(int GMREF)
        {
            ArrayList toplamlar = Ekstreler.GetToplamFiyatlar(GMREF, -1,
                (DateTime)Session["downloadyazdirekstretarih1"], (DateTime)Session["downloadyazdirekstretarih2"], (bool)Session["downloadyazdirekstrevgb"]);
            lblToplamBorc.Text = ((decimal)toplamlar[0]).ToString("C2");
            lblToplamAlacak.Text = ((decimal)toplamlar[1]).ToString("C2");
            lblToplamBakiye.Text = ((decimal)toplamlar[2]).ToString("C2");
            lblToplamVGB.Text = ((decimal)toplamlar[3]).ToString("C2");
        }
    }
}
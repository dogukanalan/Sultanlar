using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Sultanlar.DatabaseObject.Internet;
using System.Collections;
using Sultanlar.Class;

namespace Sultanlar.WebUI.merch
{
    public partial class rutbugun : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(System.Web.HttpCacheability.NoCache);
            Response.Cache.SetNoStore();

            if (Session["Musteri"] == null)
                Response.Redirect("giris.aspx", true);

            if (!IsPostBack)
            {
                Musteriler musteri = new Musteriler();

                if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 2)
                {
                    SatisTemsilcileri.GetObjects(ddlTemsilciler.Items, true, false);
                    if (Request.QueryString["slsref"] != null)
                        musteri = Musteriler.GetMusteriByID(Musteriler.GetMusteriIDbySLSREF(Convert.ToInt32(Request.QueryString["slsref"])));
                }
                else
                {
                    ddlTemsilciler.Items.Add(new ListItem(((Musteriler)Session["Musteri"]).strAd + " " + ((Musteriler)Session["Musteri"]).strSoyad, ((Musteriler)Session["Musteri"]).intSLSREF.ToString()));
                    ddlTemsilciler.Visible = false;

                    musteri = (Musteriler)Session["Musteri"];
                }

                bool bayi = musteri.tintUyeTipiID == 6 ? true : false;
                DataTable dt = new DataTable();
                Rutlar.GetObjectsBySLSREF(dt, musteri.intSLSREF,
                    Convert.ToDateTime(DateTime.Now.ToShortDateString()), Convert.ToDateTime(DateTime.Now.ToShortDateString()), bayi);
                for (int i = 0; i < dt.Rows.Count; i++)
                    dt.Rows[i]["SUBE"] = StringParcalama.NoktayiBoslukla(dt.Rows[i]["SUBE"].ToString());
                dlRutlar.DataSource = dt;
                dlRutlar.DataBind();
                dlRutlar.Visible = dt.Rows.Count != 0;
                lblRutYok.Visible = dt.Rows.Count == 0;
            }
        }

        protected void ZiyaretBaslat_Click(object sender, EventArgs e)
        {
            //Ziy ziyaret = new Ziy();

            //int SMREF = 0;
            //int MTIP = 0;
            //string BARKOD = string.Empty;
            //DateTime ZIYGUN = DateTime.MinValue;

            //foreach (Control ctrl in ((LinkButton)sender).Parent.Controls) // td nin kontrolleri
            //{
            //    if (ctrl is System.Web.UI.HtmlControls.HtmlInputHidden)
            //    {
            //        if (ctrl.ID.StartsWith("SMREF") && !ctrl.ID.EndsWith("1"))
            //            SMREF = Convert.ToInt32(((System.Web.UI.HtmlControls.HtmlInputHidden)ctrl).Value);
            //        else if (ctrl.ID.StartsWith("BARKOD"))
            //            BARKOD = ((System.Web.UI.HtmlControls.HtmlInputHidden)ctrl).Value;
            //        else if (ctrl.ID.StartsWith("MTIP"))
            //            MTIP = Convert.ToInt32(((System.Web.UI.HtmlControls.HtmlInputHidden)ctrl).Value);
            //        else if (ctrl.ID.StartsWith("ZIYGUN"))
            //            ZIYGUN = Convert.ToDateTime(((System.Web.UI.HtmlControls.HtmlInputHidden)ctrl).Value);
            //    }
            //}

            //ziyaret.smref = SMREF;
            //ziyaret.barkod = BARKOD;
            //ziyaret.ziygun = ZIYGUN;
            //ziyaret.mtip = MTIP;
            //ziyaret.coords = txtCoords.Text;
            //ziyaret.coords1 = txtCoords1.Text;

            //Session["Ziy"] = ziyaret;
            //Response.Redirect("ziyaret.aspx", true);
        }
    }

    public class Ziy
    {
        public int smref { get; set; }
        public string barkod { get; set; }
        public DateTime ziygun { get; set; }
        public int mtip { get; set; }
        public string coords { get; set; }
        public string coords1 { get; set; }
    }
}
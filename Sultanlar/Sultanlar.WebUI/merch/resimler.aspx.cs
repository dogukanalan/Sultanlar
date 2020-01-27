using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Sultanlar.DatabaseObject.Internet;
using Sultanlar.DatabaseObject;

namespace Sultanlar.WebUI.merch
{
    public partial class resimler : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(System.Web.HttpCacheability.NoCache);
            Response.Cache.SetNoStore();

            if (Session["Musteri"] == null)
                Response.Redirect("giris.aspx", true);

            if (!IsPostBack)
            {
                if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 2)
                {
                    SatisTemsilcileri.GetObjects(ddlTemsilciler.Items, true, false);
                    ddlTemsilciler.Items[0].Text = "Tümü";
                    ddlTemsilciler.Items[0].Value = "0";
                }
                else
                {
                    ddlTemsilciler.Items.Add(new ListItem(((Musteriler)Session["Musteri"]).strAd + " " + ((Musteriler)Session["Musteri"]).strSoyad, ((Musteriler)Session["Musteri"]).intSLSREF.ToString()));
                    divTemsilciler.Style["display"] = "none";
                }

                RutResim.GetObjectsTurler(ddlTurler.Items);
                ddlTurler.Items[0].Text = "Tümü";
                for (int i = 0; i < ddlYil.Items.Count; i++)
                    if (ddlYil.Items[i].Value == DateTime.Now.Year.ToString())
                        ddlYil.Items[i].Selected = true;
                for (int i = 0; i < ddlAy.Items.Count; i++)
                    if (ddlAy.Items[i].Value == DateTime.Now.Month.ToString())
                        ddlAy.Items[i].Selected = true;
            }
        }

        private void GetData()
        {
            //Musteriler musteri = new Musteriler();

            //if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 2)
            //{
            //    SatisTemsilcileri.GetObjects(ddlTemsilciler.Items, true, false);
            //    ddlTemsilciler.Items[0].Text = "Tümü";
            //    ddlTemsilciler.Items[0].Value = "0";

            //    if (Request.QueryString["slsref"] != null && Request.QueryString["slsref"] != "0")
            //        musteri = Musteriler.GetMusteriByID(Musteriler.GetMusteriIDbySLSREF(Convert.ToInt32(Request.QueryString["slsref"])));
            //}
            //else
            //{
            //    ddlTemsilciler.Items.Add(new ListItem(((Sultanlar.DatabaseObject.Internet.Musteriler)Session["Musteri"]).strAd + " " + ((Sultanlar.DatabaseObject.Internet.Musteriler)Session["Musteri"]).strSoyad, ((Sultanlar.DatabaseObject.Internet.Musteriler)Session["Musteri"]).intSLSREF.ToString()));
            //    divTemsilciler.Visible = false;

            //    musteri = (Musteriler)Session["Musteri"];
            //}

            //DataTable dt1 = new DataTable();
            //RutResim.GetObjects(dt1, musteri.pkMusteriID, true);
            //rp1.DataSource = dt1;
            //rp1.DataBind();
            //lblYok.Visible = dt1.Rows.Count == 0;
        }

        [System.Web.Services.WebMethod()]
        [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        public static List<RutResim1> ResimlerGetir(int slsref, int kacincidan, string rutid, int turid, int yil, int ay)
        {
            int musteriid = slsref != 0 ? Musteriler.GetMusteriIDbySLSREF(slsref) : 0;
            List<RutResim1> donendeger = new List<RutResim1>();
            DataTable dt = new DataTable();
            RutResim.GetObjects(dt, rutid, musteriid, turid, yil, ay, kacincidan, 20);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                donendeger.Add(new RutResim1(Convert.ToInt32(dt.Rows[i][0]), dt.Rows[i][1].ToString(), dt.Rows[i][2].ToString(), dt.Rows[i][3].ToString(), dt.Rows[i][4].ToString(), dt.Rows[i][5].ToString()));
            }
            return donendeger;
        }
    }

    public class RutResim1
    {
        public int ID { get; set; }
        public string AdSoyad { get; set; }
        public string SUBE { get; set; }
        public string strTur { get; set; }
        public string dtTarih { get; set; }
        public string strAciklama { get; set; }

        public RutResim1(int ID, string AdSoyad, string SUBE, string strTur, string dtTarih, string strAciklama)
        {
            this.ID = ID;
            this.AdSoyad = AdSoyad;
            this.SUBE = SUBE;
            this.strTur = strTur;
            this.dtTarih = dtTarih;
            this.strAciklama = strAciklama;
        }
    }
}
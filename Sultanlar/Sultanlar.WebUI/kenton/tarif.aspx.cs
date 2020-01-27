using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sultanlar.DatabaseObject.Kenton;
using System.Data;
using Sultanlar.Class;

namespace Sultanlar.WebUI.kenton
{
    public partial class tarif : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(System.Web.HttpCacheability.NoCache);
            Response.Cache.SetNoStore();

            int tid = Convert.ToInt32(Request.QueryString["id"]);
            Tarifler tarif = Tarifler.GetObject(tid);
            spanBaslik.InnerHtml = tarif.strBaslik;
            spanHazirlanis.InnerHtml = tarif.strHazirlanis;
            spanMalzemeler.InnerHtml = tarif.strMalzemeler;
            imgResim.Src = "resim.aspx?tarif=" + tid.ToString();
            spanOrtPuan.InnerHtml = tarif.OrtPuan == 0 ? "<i>Henüz puanlanmadı.</i>" : tarif.OrtPuan.ToString("N1");

            if (tarif.binResimUrunler != null) //tarif.strUrunlerLink != string.Empty
            {
                imgUrunler.Src = "resim.aspx?tarifU=" + tid.ToString();
                aUrunler.HRef = "https://www.komsu.com.tr/kenton"; //"https://www.komsu.com.tr/index.php?p=search&search=" + tarif.strUrunlerLink;
            }
            else
            {
                divSatinAl.Visible = false;
            }

            tarifid.Value = tid.ToString();
            uyeid.Value = Session["Kenton"] != null ? ((Uyeler)Session["Kenton"]).pkID.ToString() : "0";
            //imgFav.Src = TarifFav.GetObjectByTarifIDUyeID(Convert.ToInt32(uyeid.Value), tid).pkID > 0 ? "images/star.png" : "images/star_bos.png";
            i1.Attributes["class"] = TarifFav.GetObjectByTarifIDUyeID(Convert.ToInt32(uyeid.Value), tid).pkID > 0 ? "fa fa-gratipay imgFav favori2" : "fa fa-gratipay imgFav favori1";
            spanOnay1.Visible = false;

            if (tarif.TarifKategoriler.Count > 0)
                digerkatid.Value = tarif.TarifKategoriler[new Random().Next(0, tarif.TarifKategoriler.Count - 1)].intKategoriID.ToString();
            else
                digerkatid.Value = "0";

            if (Session["Kenton"] != null)
            {
                TarifPuan tp = TarifPuan.GetObjectByTarifIDUyeID(((Uyeler)Session["Kenton"]).pkID, tid);
                if (tp.pkID > 0)
                {
                    if (tp.intPuan == 1) puan1.Checked = true; else if (tp.intPuan == 2) puan2.Checked = true; else if (tp.intPuan == 3) puan3.Checked = true; else if (tp.intPuan == 4) puan4.Checked = true; else if (tp.intPuan == 5) puan5.Checked = true;
                }

                spanOnay1.Visible = ((Uyeler)Session["Kenton"]).pkID == tarif.intUyeID;

                spanOnay.InnerHtml = tarif.blOnay ? "Onaylı." : "Henüz Onaylanmadı.";
                spanOnay.Style["color"] = tarif.blOnay ? "Green" : "Red";
            }

            divPuan.Visible = tarif.blOnay;
            divPaylas.Visible = tarif.blOnay;
            divFav.Visible = tarif.blOnay;
            divYorum.Visible = Session["Kenton"] != null && tarif.blOnay;

            //TarifVideo tv = TarifVideo.GetObjectByTarif(tid);
            //if (tv.intVideoID != 0)
            //{
            //    divVideo.Visible = true;
            //    divVideoI.InnerHtml = "<iframe id='iframeVideo' width='100%' height='281' src='https://www.youtube.com/embed/" + Videolar.GetObject(tv.intVideoID).strVideo + "?rel=0&amp;controls=0' frameborder='0' allow='autoplay; encrypted-media' allowfullscreen></iframe>";
            //}
            
            TarifGoruntuleme.DoInsert(Convert.ToInt32(tarifid.Value), Convert.ToInt32(uyeid.Value), HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"]);
        }

        [System.Web.Services.WebMethod()]
        [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        public static List<Yorumlarr> YorumlarGetir(int tarifid)
        {
            List<Yorumlarr> donendeger = new List<Yorumlarr>();

            DataTable dt = new DataTable();
            Yorumlar.GetObjectsByTarifID(dt, tarifid, 20);

            for (int i = 0; i < dt.Rows.Count; i++)
                donendeger.Add(new Yorumlarr(Convert.ToInt32(dt.Rows[i]["pkID"]), Convert.ToInt32(dt.Rows[i]["intTarifID"]), dt.Rows[i]["strBaslik"].ToString(), Convert.ToInt32(dt.Rows[i]["intUyeID"]), dt.Rows[i]["strAdSoyad"].ToString(), dt.Rows[i]["strYorum"].ToString(), Convert.ToDateTime(dt.Rows[i]["dtTarih"]).ToString(), Convert.ToBoolean(dt.Rows[i]["blOnayli"])));

            return donendeger;
        }

        [System.Web.Services.WebMethod()]
        public static void YorumEkle(string uyeid, string tarifid, string yorum)
        {
            Yorumlar yorum1 = new Yorumlar(Convert.ToInt32(tarifid), Convert.ToInt32(uyeid), yorum, DateTime.Now, false);
            yorum1.DoInsert();
        }

        [System.Web.Services.WebMethod()]
        public static void FavEkle(string uyeid, string tarifid, string eklecikar)
        {
            if (eklecikar == "ekle")
            {
                if (TarifFav.GetObjectByTarifIDUyeID(Convert.ToInt32(uyeid), Convert.ToInt32(tarifid)).pkID == 0)
                {
                    TarifFav tar = new TarifFav(Convert.ToInt32(uyeid), Convert.ToInt32(tarifid), DateTime.Now);
                    tar.DoInsert();
                }
            }
            else
            {
                TarifFav tar = TarifFav.GetObjectByTarifIDUyeID(Convert.ToInt32(uyeid), Convert.ToInt32(tarifid));
                tar.DoDelete();
            }
        }

        [System.Web.Services.WebMethod()]
        [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        public static Tarifler PuanEkle(string uyeid, string tarifid, int puan)
        {
            TarifPuan tp = TarifPuan.GetObjectByTarifIDUyeID(Convert.ToInt32(uyeid), Convert.ToInt32(tarifid));
            if (tp.pkID > 0)
            {
                tp.intPuan = puan;
                tp.DoUpdate();
            }
            else
            {
                TarifPuan tar = new TarifPuan(Convert.ToInt32(uyeid), Convert.ToInt32(tarifid), DateTime.Now, puan);
                tar.DoInsert();
            }

            return Tarifler.GetObject(Convert.ToInt32(tarifid));
        }

        [System.Web.Services.WebMethod()]
        [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        public static List<Tarifler> TariflerGetir(int sonid, int kactane, string action, string uyeid, string urunid, string aranan, int katid, string order) // urunid = tarifid
        {
            List<Tarifler> donendeger = new List<Tarifler>();
            if (action == "")
                donendeger = Tarifler.GetObjects(sonid, kactane, aranan, katid, order);

            for (int i = 0; i < donendeger.Count; i++)
            {
                if (Convert.ToInt32(urunid) == donendeger[i].pkID)
                {
                    donendeger.Remove(donendeger[i]);
                    break;
                }
            }
            if (donendeger.Count == 3)
            {
                donendeger.RemoveAt(new Random().Next(0,2));
            }
            return donendeger;
        }
    }

    public class Yorumlarr
    {
        public int pkID { get; set; }
        public int intTarifID { get; set; }
        public string strBaslik { get; set; }
        public int intUyeID { get; set; }
        public string strAdSoyad { get; set; }
        public string strYorum { get; set; }
        public string dtTarih { get; set; }
        public bool blOnayli { get; set; }

        public Yorumlarr(int pkID, int intTarifID, string strBaslik, int intUyeID, string strAdSoyad, string strYorum, string dtTarih, bool blOnayli)
        {
            this.pkID = pkID;
            this.intTarifID = intTarifID;
            this.strBaslik = strBaslik;
            this.intUyeID = intUyeID;
            this.strAdSoyad = strAdSoyad;
            this.strYorum = strYorum;
            this.dtTarih = dtTarih;
            this.blOnayli = blOnayli;
        }
    }
}
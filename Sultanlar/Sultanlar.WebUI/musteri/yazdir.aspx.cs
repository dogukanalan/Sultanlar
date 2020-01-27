using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Sultanlar.DatabaseObject.Internet;

namespace Sultanlar.WebUI.musteri
{
    public partial class yazdir : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);

            if (Session["yazdirsiparisid"] != null && Session["yazdirsiparisid"] != Session["oncekiyazdirsiparisid"])
            {
                Label1.Visible = false;
                divYazdir.Visible = true;
                GetSiparis((int)Session["yazdirsiparisid"]);
            }
            else if (Session["yazdiriadeid"] != null && Session["yazdiriadeid"] != Session["oncekiyazdiriadeid"])
            {
                Label1.Visible = false;
                divYazdir.Visible = true;
                GetIade((int)Session["yazdiriadeid"]);
            }
            else
            {
                Label1.Visible = true;
                divYazdir.Visible = false;
                Response.AddHeader("REFRESH", "5");
            }
        }

        private void GetIade(int IadeID)
        {
            Iadeler id = Iadeler.GetObjectsByIadeID(IadeID);
            string carihesap = string.Empty;
                carihesap = CariHesaplar.GetSubeBySMREF(id.SMREF)[1].ToString();
            string fiyattip = FiyatTipleri.GetObjectByID(2);
            string iadetarihi = id.dtOlusmaTarihi.ToShortDateString();
            string iadeonaytarihi = "";
            if (!id.blAktarilmis && id.mnToplamTutar > 0)
                iadeonaytarihi = id.dtOlusmaTarihi.ToShortDateString();
            Musteriler musteri = Musteriler.GetMusteriByID(id.intMusteriID);
            string musteriadsoyad = musteri.strAd + " " + musteri.strSoyad;
            decimal toplamtutar = id.mnToplamTutar;
            string[] aciklama = id.strAciklama.Split(new string[] { ";;;" }, StringSplitOptions.None);

            DataTable dt = new DataTable();
            IadelerDetay.GetObjectsByIadeID(dt, IadeID, 2, true);



            lblSipGir.Text = musteriadsoyad;
            lblCariHesap.Text = carihesap;
            lblFiyatTipi.Text = fiyattip;
            lblOlusmaTarihi.Text = iadetarihi;
            lblOnayTarihi.Text = iadeonaytarihi;
            lblAciklama.Text = aciklama[1] + "<br />" + aciklama[2];
            lblAciklama.Text += musteri.tintUyeTipiID == 5 ? "<br />" + musteri.strTelefon : "";
            lblToplamTutar.Text = id.mnToplamTutar.ToString("C3");
            Repeater1.DataSource = dt;
            Repeater1.DataBind();



            Session["yazdiriadeid"] = null;
        }

        private void GetSiparis(int SiparisID)
        {
            Siparisler sip = Siparisler.GetObjectsBySiparisID(SiparisID);
            string carihesap = string.Empty;
            if (sip.SMREF > 0)
                carihesap = CariHesaplar.GetSubeBySMREF(sip.SMREF)[1].ToString();
            else
                carihesap = CariHesaplar.GetSubeBySMREF(24479)[1].ToString();
            string fiyattip = FiyatTipleri.GetObjectByID(sip.sintFiyatTipiID);
            string siparistarihi = sip.dtOlusmaTarihi.ToShortDateString();
            string siparisonaytarihi = "";
            if (sip.blAktarilmis)
                siparisonaytarihi = sip.dtOlusmaTarihi.ToShortDateString();
            //string vade = TaksitPlanlari.GetOdemePlani(sip.TKSREF);
            Musteriler musteri = Musteriler.GetMusteriByID(sip.intMusteriID);
            string musteriadsoyad = musteri.strAd + " " + musteri.strSoyad;
            decimal toplamtutar = sip.mnToplamTutar;
            string[] aciklama = sip.strAciklama.Split(new string[] { ";;;" }, StringSplitOptions.None );

            DataTable dt = new DataTable();
            SiparislerDetay.GetObjectsBySiparisID(dt, SiparisID, sip.sintFiyatTipiID, true);



            lblSipGir.Text = musteriadsoyad;
            lblCariHesap.Text = carihesap;
            lblFiyatTipi.Text = fiyattip;
            lblOlusmaTarihi.Text = siparistarihi;
            lblOnayTarihi.Text = siparisonaytarihi;
            //lblVade.Text = vade;
            lblAciklama.Text = aciklama[1] + "<br />" + aciklama[2];
            lblAciklama.Text += musteri.tintUyeTipiID == 5 ? "<br />" + Musteriler.GetMusteriByID(sip.intMusteriID).strTelefon : "";
            lblToplamTutar.Text = sip.mnToplamTutar.ToString("C3");
            Repeater1.DataSource = dt;
            Repeater1.DataBind();



            Session["yazdirsiparisid"] = null;
        }
    }
}
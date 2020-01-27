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
    public partial class hizlisiparis : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["SMREF"] == null || Session["Musteri"] == null || Session["FiyatTipi"] == null)
                    Response.Redirect("default.aspx", true);

                int MusteriID = 0;
                if (Session["SiparisSahibiMusteriID"] != null)
                    MusteriID = Convert.ToInt32(Session["SiparisSahibiMusteriID"]);
                else
                    MusteriID = ((Musteriler)Session["Musteri"]).pkMusteriID;

                siparissahibimusteriid.Value = MusteriID.ToString();
                fiyattipi.Value = Session["FiyatTipi"].ToString();
                smref.Value = Session["SMREF"].ToString();
                spanUye.InnerText = Musteriler.GetMusteriByID(MusteriID).strAd + " " + Musteriler.GetMusteriByID(MusteriID).strSoyad;
                spanMusteri.InnerText = CariHesaplar.GetMUSTERIbySMREFmusterisube(Convert.ToInt32(Session["SMREF"]));
                spanFiyatTipi.InnerText = FiyatTipleri.GetObjectByID(Convert.ToInt16(Session["FiyatTipi"]));

                GetUrunler();

                GetTedarikciler();

                inputAciklama2.Value = DateTime.Now.ToShortDateString().Replace(".", "/");

                inputButunUrunler.Value = (bool)Session["OfflineButunUrunler"] ? "1" : "0";
                Session["OfflineButunUrunler"] = null;
                Session["SiparisSahibiMusteriID"] = null;
                Session["FiyatTipi"] = null;
                Session["SMREF"] = null;
                Session["RISKBAKIYE"] = null;
            }
        }

        private void GetTedarikciler()
        {
            ListItemCollection lic = new ListItemCollection();
            Urunler.GetOzelKodlar(lic, true);

            string tdb = string.Empty;
            for (int i = 1; i < lic.Count; i++) // ilk satırda tümü var
            {
                tdb += lic[i].Text + ";";
            }
            teddb.Value = tdb;
        }

        private void GetUrunler()
        {
            DataTable dt = new DataTable();
            Urunler.GetProductsHS(dt, Session["FiyatTipi"].ToString(), (bool)Session["OfflineButunUrunler"], (int)Session["SMREF"]);

            string database = string.Empty;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                database += dt.Rows[i]["UrunID"].ToString()
                    //+ dt.Rows[i]["Barkod"].ToString() + "-" + dt.Rows[i]["UrunID"].ToString() + ") "
                    + "!" + dt.Rows[i]["Ad"].ToString()
                    + " {Stok: " + dt.Rows[i]["STOK"].ToString() + "}"
                    + " [K.İç: " + dt.Rows[i]["KOLI"].ToString() + "]!"
                    + (dt.Rows[i]["Fiyat"].ToString() != string.Empty ? Convert.ToDouble(dt.Rows[i]["Fiyat"]).ToString("N3") : "0,000") + "!"
                    + dt.Rows[i]["Tedarikci"].ToString() + ";";
            }
            db.Value = database;
        }

        protected void btnSiparisTamamla_Click(object sender, EventArgs e)
        {
            string[] UrunIDs = siparisurunidler.Value.Split(new char[] { ';' }, StringSplitOptions.None);
            string[] Miktars = siparisurunmiktarlar.Value.Split(new char[] { ';' }, StringSplitOptions.None);

            if (UrunIDs.Length == 1)
                Response.Redirect("default.aspx", true);

            Siparisler sip = new Siparisler(
                    Convert.ToInt32(siparissahibimusteriid.Value),
                    Convert.ToInt32(smref.Value),
                    Convert.ToInt16(fiyattipi.Value),
                    DateTime.Now,
                    0,
                    false,
                    147,
                    DateTime.Now,
                    ((Musteriler)Session["Musteri"]).strAd + " " + ((Musteriler)Session["Musteri"]).strSoyad + ";;;" + inputAciklama1.Value.Trim() + ";;;" + inputAciklama2.Value.Trim());
            sip.DoInsert();

            Siparisler.DoInsertOffOnLog(sip.pkSiparisID, true, inputButunUrunler.Value == "1" ? true : false);

            decimal toplamtutar = 0;
            decimal vadetoplam = 0;
            for (int i = 0; i < UrunIDs.Length - 1; i++) // son satır null
            {
                if (Convert.ToInt32(Miktars[i]) > 0)
                {
                    SiparislerDetay detay = new SiparislerDetay(
                        sip.pkSiparisID,
                        Convert.ToInt32(UrunIDs[i]),
                        Urunler.GetProductName(Convert.ToInt32(UrunIDs[i])),
                        Convert.ToInt32(Miktars[i]),
                        Urunler.GetProductPrice(Convert.ToInt32(UrunIDs[i]), sip.sintFiyatTipiID),
                        Guid.Empty,
                        false,
                        Guid.Empty,
                        "ST");
                    detay.DoInsert();

                    if (sip.sintFiyatTipiID == 2)
                        Iskontolar(detay.pkSiparisDetayID);

                    SiparislerDetay sd = SiparislerDetay.GetObjectBySiparislerDetayID(detay.pkSiparisDetayID); // f2 ise ve iskontolar function unda kdv dahil fiyatı hesaplanmışsa diye tekrar alıyoruz

                    int vade = Urunler.GetProductVade(sd.intUrunID, sip.sintFiyatTipiID);
                    vadetoplam += sd.intMiktar * sd.mnFiyat * vade;
                    toplamtutar += sd.intMiktar * sd.mnFiyat;
                }
            }
            sip.mnToplamTutar = toplamtutar;
            sip.TKSREF = TaksitPlanlari.GetODMREF(Convert.ToInt32(Math.Round(vadetoplam / toplamtutar)));
            sip.DoUpdate();

            Session["SiparisTamamlaOnaylaBasildi"] = sip.SMREF;
            Session["OnaylanacakSiparisID"] = sip.pkSiparisID;

            Response.Redirect("siparisler.aspx", true);
        }

        private void Iskontolar(long siparisdetayid)
        {
            SiparislerDetay sd = SiparislerDetay.GetObjectBySiparislerDetayID(siparisdetayid);
            Siparisler sip = Siparisler.GetObjectsBySiparisID(sd.intSiparisID);
            int fiyattipi = FiyatTipleri.GetFiyatTipByGMREF(CariHesaplar.GetGMREFBySMREF(sip.SMREF));

            long ad = AktivitelerDetay.GetTarihAraligiAktivitelerDetayIDSUL(sip.SMREF, sd.intUrunID.ToString(), Convert.ToDateTime(DateTime.Now.ToShortDateString()));
            AktivitelerDetay akdet = AktivitelerDetay.GetObject(ad);

            double direkdagitimISK1 = 0;
            #region direkdagitimISK1
            if (fiyattipi.ToString().StartsWith("5"))
            {
                double i1 = Urunler.GetProductDiscountsAndPrice(sd.intUrunID, fiyattipi, DateTime.Now.Year, DateTime.Now.Month)[0];
                double i2 = Urunler.GetProductDiscountsAndPrice(sd.intUrunID, fiyattipi, DateTime.Now.Year, DateTime.Now.Month)[1];
                double birincidusulmus = 100 - i1;
                double ikincidusulmus = birincidusulmus - ((birincidusulmus / 100) * i2);
                direkdagitimISK1 = 100 - ikincidusulmus;
            }
            #endregion
            double Isk1 = fiyattipi.ToString().StartsWith("5") ? direkdagitimISK1 : 5;
            double Isk2 = fiyattipi.ToString().StartsWith("5") ? Urunler.GetProductDiscountsAndPrice(sd.intUrunID, fiyattipi, DateTime.Now.Year, DateTime.Now.Month)[2] : (Urunler.GetProductGRPKOD(sd.intUrunID) == "STG-1" ? 0 : 0);

            // anlaşması olup 500 lü olmayan fiyat tipleri için isk1 ve isk2:
            Anlasmalar anlasma = Anlasmalar.GetObject(Anlasmalar.GetSonAnlasmaID(CariHesaplar.GetGMREFBySMREF(sip.SMREF), DateTime.Now, "2"));
            if (anlasma != null)
            {
                Isk1 = Urunler.GetProductGRPKOD(sd.intUrunID) == "STG-1" ? anlasma.flTAHIsk : anlasma.flYEGIsk;
                Isk2 = Urunler.GetProductGRPKOD(sd.intUrunID) == "STG-1" ? anlasma.flTAHCiroIsk : anlasma.flYEGCiroIsk;
            }

            double Isk3 = fiyattipi.ToString().StartsWith("5") ? Urunler.GetProductDiscountsAndPrice(sd.intUrunID, fiyattipi, DateTime.Now.Year, DateTime.Now.Month)[5] : (Urunler.GetProductDiscountsAndPrice(sd.intUrunID, 7, DateTime.Now.Year, DateTime.Now.Month)[2]);
            double Isk4 = ad == 0 ? 0 : akdet.flEkIsk;
            double Fiyat = Urunler.GetProductDiscountsAndPrice(sd.intUrunID, sip.sintFiyatTipiID)[4];

            SiparislerDetay.DoInsertISKs(sd.pkSiparisDetayID, Fiyat, Isk1, Isk2, Isk3, Isk4, 0, 0, 0, 0, 0, 0);

            double para = Fiyat - (Fiyat / 100 * Isk1);
            para = para - (para / 100 * Isk2);
            para = para - (para / 100 * Isk3);
            para = para - (para / 100 * Isk4);
            para = para + (para / 100 * Urunler.GetProductKDV(sd.intUrunID));

            sd.mnFiyat = Convert.ToDecimal(para);
            sd.DoUpdate();
        }
    }
}
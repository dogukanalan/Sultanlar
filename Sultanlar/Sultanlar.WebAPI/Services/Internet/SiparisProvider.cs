using Sultanlar.DbObj.Internet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sultanlar.WebAPI.Models.Internet;
using Sultanlar.Class;
using System.Net;
using System.IO;
using System.Globalization;
using System.Linq.Dynamic.Core;

namespace Sultanlar.WebAPI.Services.Internet
{
    public class SiparisProvider
    {
        internal List<siparisler> Siparisler(int yil, int ay, object Onay) => new siparisler().GetObjects(yil, ay, Onay);

        internal siparisler Siparis(int SiparisID) => new siparisler(SiparisID).GetObject();

        internal DtAjaxResponse Siparisler(SiparisGet sget)
        {
            DtAjaxResponse donendeger = new DtAjaxResponse();
            List<siparisler> donendeger2 = new List<siparisler>();

            object Onay = sget.onay == "1" ? true : sget.onay == "0" ? false : (object)DBNull.Value;
            object Ay = sget.ay == 0 ? (object)DBNull.Value : sget.ay;

            if (sget.smref != 0)
                donendeger2 = new siparisler().GetObjectsBySMREF(sget.smref, sget.yil, Ay, Onay);
            else if (sget.gmref != 0)
                donendeger2 = new siparisler().GetObjectsByGMREF(sget.gmref, sget.yil, Ay, Onay);
            else if (sget.slsref != 0)
                donendeger2 = new siparisler().GetObjectsBySLSREF(sget.slsref, sget.yil, Ay, Onay);
            else
                donendeger2 = new siparisler().GetObjects(sget.yil, Ay, Onay);

            donendeger.recordsTotal = donendeger2.Count;
            if (sget.search.value != "")
            {
                donendeger2 = donendeger2.ToList().Where(k => 
                    k.Cari.MUSTERI.ToUpper(CultureInfo.CurrentCulture).IndexOf(sget.search.value.ToUpper(CultureInfo.CurrentCulture)) > -1 ||
                    k.Cari.SUBE.ToUpper(CultureInfo.CurrentCulture).IndexOf(sget.search.value.ToUpper(CultureInfo.CurrentCulture)) > -1 ||
                    k.Musteri.AdSoyad.ToUpper(CultureInfo.CurrentCulture).IndexOf(sget.search.value.ToUpper(CultureInfo.CurrentCulture)) > -1 ||
                    k.strAciklama.ToUpper(CultureInfo.CurrentCulture).IndexOf(sget.search.value.ToUpper(CultureInfo.CurrentCulture)) > -1 ||
                    k.FiyatTipi.ACIKLAMA.ToUpper(CultureInfo.CurrentCulture).IndexOf(sget.search.value.ToUpper(CultureInfo.CurrentCulture)) > -1
                ).ToList();
            }
            donendeger.recordsFiltered = donendeger2.Count;

            for (int i = 0; i < sget.columns.Count; i++)
                if (i == sget.order[0].column)
                    donendeger2 = donendeger2.AsQueryable().OrderBy(sget.columns[i].name + " " + sget.order[0].dir).ToList();

            int Baslangic = sget.start;
            int Kactane = sget.length;
            int sinir = (Baslangic + Kactane) < donendeger2.Count ? (Baslangic + Kactane) : donendeger2.Count;

            donendeger.json = new List<object>();
            for (int i = Baslangic; i < sinir; i++)
            {
                donendeger.json.Add(donendeger2[i]);
            }

            return donendeger;
        }

        internal string SiparisSil(int SiparisID)
        {
            string Donen = string.Empty;
            siparisler sip = new siparisler(SiparisID).GetObject();
            List<siparislerDetay> silinecekler = new siparislerDetay().GetObjects(sip.pkSiparisID);
            for (int i = 0; i < silinecekler.Count; i++)
                silinecekler[i].DoDelete();
            sip.DoDelete();
            return Donen;
        }

        internal string SiparisOnay(int SiparisID, int Bakiye, int MusteriID)
        {
            string Donen = string.Empty;
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("https://www.ittihadteknoloji.com.tr/wcf/siparis.ashx?siparisid=" + SiparisID + "&sevkref=0&depoid=0&bakiye=" + (Bakiye == 0 ? "false" : "true") + "&musteriid=" + MusteriID);
            HttpWebResponse res = (HttpWebResponse)req.GetResponse();
            Donen = new StreamReader(res.GetResponseStream()).ReadToEnd();
            return Donen;
        }

        internal string SiparisKopyala(SiparisKopya skg)
        {
            string Donen = string.Empty;

            siparisler kopyalanacak = new siparisler(skg.SiparisID).GetObject();
            for (int i = 0; i < skg.SMREFs.Count; i++)
            {
                siparisler sip = new siparisler(kopyalanacak.intMusteriID, skg.SMREFs[i].smref, kopyalanacak.sintFiyatTipiID, DateTime.Now, kopyalanacak.mnToplamTutar, false, kopyalanacak.TKSREF, DateTime.Now, kopyalanacak.strAciklama);
                sip.DoInsert();
                for (int j = 0; j < kopyalanacak.detaylar.Count; j++)
                {
                    siparislerDetay sipdet = new siparislerDetay(sip.pkSiparisID, kopyalanacak.detaylar[j].intUrunID, kopyalanacak.detaylar[j].strUrunAdi, kopyalanacak.detaylar[j].intMiktar, kopyalanacak.detaylar[j].mnFiyat, kopyalanacak.detaylar[j].unKampanyaKart, kopyalanacak.detaylar[j].blKampanyaHediye, kopyalanacak.detaylar[j].unKampanyaSatir, kopyalanacak.detaylar[j].strMiktarTur);
                    sipdet.DoInsert();
                }
            }

            return Donen;
        }

        internal string SiparisKaydet(SiparisKaydet skg)
        {
            if (skg.siparisid != 0) // sipariş güncelleniyorsa eskiyi silsin
            {
                siparisler siparis = new siparisler(skg.siparisid).GetObject();
                for (int i = 0; i < siparis.detaylar.Count; i++)
                    siparis.detaylar[i].DoDelete();
                siparis.DoDelete();
            }

            musteriler mus = new musteriler(Convert.ToInt32(Sifreleme.Decrypt(skg.musteri))).GetObject();
            int musid = new musteriler().GetMusteriBySLSREF(new cariHesaplar(skg.smref).GetObject().SLSREF).pkMusteriID;

            siparisler sip = new siparisler(musid != 0 ? musid : mus.pkMusteriID, skg.smref, skg.ftip, DateTime.Now, 0, false, 0, DateTime.Now, mus.AdSoyad + ";;;" + skg.aciklama + ";;;" + Convert.ToDateTime(skg.teslim).ToShortDateString());
            sip.DoInsert();
            double toplam = 0;
            for (int i = 0; i < skg.detaylar.Count; i++)
            {
                double fiyat = new fiyatlar(sip.sintFiyatTipiID, skg.detaylar[i].itemref).GetObject().NETKDV;
                siparislerDetay sipdet = new siparislerDetay(sip.pkSiparisID, skg.detaylar[i].itemref, skg.detaylar[i].malacik, skg.detaylar[i].miktar, fiyat, Guid.Empty, false, Guid.Empty, skg.detaylar[i].miktartur);
                sipdet.DoInsert();
                if (skg.detaylar[i].miktartur == "KI")
                {
                    fiyat = fiyat * sipdet.Malzeme.KOLI;
                    sipdet.mnFiyat = fiyat;
                    sipdet.DoUpdate();
                }
                toplam += fiyat * skg.detaylar[i].miktar;
            }
            sip.mnToplamTutar = toplam;
            sip.DoUpdate();

            return sip.pkSiparisID.ToString();
        }

        internal List<siparisRaporu> SiparisRapor(int Yil, int Ay, int Slsref)
        {
            object ay = Ay == 0 ? DBNull.Value : (object)Ay;
            return new siparisRaporu().GetObjects(Yil, ay, Slsref);
        }

        internal List<siparisDetayRaporu> SiparisDetayRapor(int Yil, int Ay, int Slsref, int Sipno)
        {
            object sipno = Sipno == 0 ? DBNull.Value : (object)Sipno;
            return new siparisDetayRaporu().GetObjects(Yil, Ay, Slsref, sipno);
        }

        internal List<siparisDurumRaporu> SiparisDurumRapor(int Yil, int Ay, int Slsref, int Sipno)
        {
            object ay = Ay == 0 ? DBNull.Value : (object)Ay;
            object sipno = Sipno == 0 ? DBNull.Value : (object)Sipno;
            return new siparisDurumRaporu().GetObjects(Yil, ay, Slsref, sipno);
        }

        internal SiparisIsks Isks(int SMREF, int ITEMREF, DateTime Tarih)
        {
            double fiyat = new fiyatlar(20, ITEMREF).GetObject().FIYAT;
            SiparisIsks donendeger = new SiparisIsks() { fiyat = fiyat, isk1 = 5, isk2 = 0, isk3 = 0, isk4 = 0 };

            malzemeler mal = new malzemeler(ITEMREF).GetObject();

            aktivitelerDetay aktd = new aktivitelerDetay().GetObjectSon(SMREF, ITEMREF, Tarih);
            if (aktd.pkID > 0)
            {
                donendeger = new SiparisIsks() { fiyat = aktd.mnBirimFiyatKDVli / ((100 + mal.KDV) / 100), isk1 = Convert.ToDouble(aktd.strAciklama1), isk2 = Convert.ToDouble(aktd.strAciklama2), isk3 = Convert.ToDouble(aktd.strAciklama3), isk4 = aktd.flEkIsk };
            }
            else
            {
                anlasmalar anl = new anlasmalar().GetObjectSon(SMREF, "2", Tarih);
                if (anl.pkID > 0)
                {
                    donendeger = new SiparisIsks()
                    {
                        fiyat = fiyat,
                        isk1 = (mal.GRUPKOD == "STG-1" ? anl.flTAHIsk : anl.flYEGIsk),
                        isk2 = (mal.GRUPKOD == "STG-1" ? anl.flTAHCiroIsk : anl.flYEGCiroIsk),
                        isk3 = 0,
                        isk4 = 0
                    };
                }
            }

            return donendeger;// new SiparisIsks() { fiyat=1, isk1=2, isk2=3, isk3=4, isk4=5 };
        }
    }
}

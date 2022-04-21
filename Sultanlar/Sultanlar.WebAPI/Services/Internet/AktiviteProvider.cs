using Sultanlar.Class;
using Sultanlar.DbObj.Internet;
using Sultanlar.WebAPI.Models.Internet;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;

namespace Sultanlar.WebAPI.Services.Internet
{
    public class AktiviteProvider
    {
        internal List<aktiviteler> Aktiviteler() => new aktiviteler().GetObjects();

        internal aktiviteler Aktivite(int AktiviteID) => new aktiviteler(AktiviteID).GetObject();

        internal DtAjaxResponse Aktiviteler(AktiviteGet aget)
        {
            DtAjaxResponse donendeger = new DtAjaxResponse();
            List<aktiviteler> donendeger2 = new List<aktiviteler>();

            object Onay = aget.onay == "1" ? true : aget.onay == "0" ? false : (object)DBNull.Value;
            object Ay = aget.ay == 0 ? (object)DBNull.Value : aget.ay;

            if (aget.smref != 0)
                donendeger2 = new aktiviteler().GetObjectsBySMREF(aget.smref, aget.tip, aget.yil, Ay, Onay);
            else if (aget.gmref != 0)
                donendeger2 = new aktiviteler().GetObjectsByGMREF(aget.gmref, aget.yil, Ay, Onay);
            else if (aget.slsref != 0)
                donendeger2 = new aktiviteler().GetObjectsBySLSREF(aget.slsref, aget.yil, Ay, Onay);
            else
                donendeger2 = new aktiviteler().GetObjects(aget.yil, Ay, Onay);
            
            donendeger.recordsTotal = donendeger2.Count;
            if (aget.search.value != "")
            {
                donendeger2 = donendeger2.ToList().Where(k =>
                    k.Cari.MUSTERI.ToUpper(CultureInfo.CurrentCulture).IndexOf(aget.search.value.ToUpper(CultureInfo.CurrentCulture)) > -1 ||
                    k.Cari.SUBE.ToUpper(CultureInfo.CurrentCulture).IndexOf(aget.search.value.ToUpper(CultureInfo.CurrentCulture)) > -1 ||
                    k.Musteri.AdSoyad.ToUpper(CultureInfo.CurrentCulture).IndexOf(aget.search.value.ToUpper(CultureInfo.CurrentCulture)) > -1 ||
                    k.strAciklama1.ToUpper(CultureInfo.CurrentCulture).IndexOf(aget.search.value.ToUpper(CultureInfo.CurrentCulture)) > -1 ||
                    k.strAciklama2.ToUpper(CultureInfo.CurrentCulture).IndexOf(aget.search.value.ToUpper(CultureInfo.CurrentCulture)) > -1 ||
                    k.strAciklama3.ToUpper(CultureInfo.CurrentCulture).IndexOf(aget.search.value.ToUpper(CultureInfo.CurrentCulture)) > -1 ||
                    k.strAciklama4.ToUpper(CultureInfo.CurrentCulture).IndexOf(aget.search.value.ToUpper(CultureInfo.CurrentCulture)) > -1
                ).ToList();
            }
            donendeger.recordsFiltered = donendeger2.Count;

            for (int i = 0; i < aget.columns.Count; i++)
                if (i == aget.order[0].column)
                    donendeger2 = donendeger2.AsQueryable().OrderBy(aget.columns[i].name + " " + aget.order[0].dir).ToList();

            int Baslangic = aget.start;
            int Kactane = aget.length;
            int sinir = (Baslangic + Kactane) < donendeger2.Count ? (Baslangic + Kactane) : donendeger2.Count;

            donendeger.json = new List<object>();
            for (int i = Baslangic; i < sinir; i++)
            {
                donendeger.json.Add(donendeger2[i]);
            }

            return donendeger;
        }

        internal string AktiviteSil(int AktiviteID)
        {
            string Donen = string.Empty;
            aktiviteler akt = new aktiviteler(AktiviteID).GetObject();
            List<aktivitelerDetay> silinecekler = new aktivitelerDetay().GetObjects(akt.pkID);
            for (int i = 0; i < silinecekler.Count; i++)
                silinecekler[i].DoDelete();
            akt.DoDelete();
            return Donen;
        }

        internal string AktiviteOnay(int AktiviteID)
        {
            string Donen = string.Empty;
            aktiviteler akt = new aktiviteler(AktiviteID).GetObject();
            akt.blAktarilmis = DBNull.Value;
            akt.DoUpdate();
            return Donen;
        }

        internal string AktiviteKopyala(AktiviteKopya akg)
        {
            string Donen = string.Empty;

            musteriler mus = new musteriler(Convert.ToInt32(Sifreleme.Decrypt(akg.musteri))).GetObject();

            aktiviteler kopyalanacak = new aktiviteler(akg.id).GetObject();
            for (int i = 0; i < akg.SMREFs.Count; i++)
            {
                double tahbedel = 0, tahciro = 0, yegbedel = 0, yegciro = 0;
                if (akg.SMREFs[i].AnlasmaID > 0)
                {
                    anlasmalar anlasma = new anlasmalar(akg.SMREFs[i].AnlasmaID).GetObject();
                    tahbedel = anlasma.tahSabitBedel; tahciro = anlasma.mnTAHToplamCiro; yegbedel = anlasma.yegSabitBedel; yegciro = anlasma.mnYEGToplamCiro;
                }
                cariHesaplar cari = new cariHesaplar().GetObject1(akg.SMREFs[i].tip, akg.SMREFs[i].smref);
                aktiviteler akt = new aktiviteler(
                    mus.pkMusteriID, 
                    akg.SMREFs[i].smref,
                    cari.TIP == 4 || cari.BayiMi ? (short)25 : (cari.fiyatTip500 > 500 ? Convert.ToInt16(cari.fiyatTip500) : (short)7), 
                    akg.SMREFs[i].AnlasmaID,
                    cari.TIP == 4 || cari.BayiMi ? 1 : 2, 
                    DateTime.Now, 
                    DateTime.Now, 
                    false,
                    Convert.ToDateTime(akg.donem),
                    akg.bitis != string.Empty ? Convert.ToDateTime(akg.bitis) : Convert.ToDateTime(akg.donem),
                    string.Empty,
                    string.Empty,
                    string.Empty,
                    akg.donem,
                    tahbedel,
                    yegbedel,
                    tahciro,
                    yegciro,
                    (kopyalanacak.sintFiyatTipiID == 25 && kopyalanacak.Cari.BayiMi) ? 1 : 0,
                    cari.BayiMi ? 1 : 0);
                akt.DoInsert();

                for (int j = 0; j < kopyalanacak.detaylar.Count; j++)
                {
                    malzemeler malzeme = new malzemeler(kopyalanacak.detaylar[j].intUrunID).GetObject();
                    fiyatlarTp fiyat = new fiyatlarTp().GetObject(akt.DonemYil, akt.DonemAy, akt.DonemGun, akt.sintFiyatTipiID, kopyalanacak.detaylar[j].intUrunID);
                    double kdv = ((fiyat.NETKDV / fiyat.NET) - 1) * 100;
                    double isk1 = akt.intAnlasmaID > 0 ? (malzeme.GRUPKOD == "STG-1" ? akt.Anlasma.flTAHIsk : akt.Anlasma.flYEGIsk) : 0;
                    double isk2 = akt.intAnlasmaID > 0 ? (malzeme.GRUPKOD == "STG-1" ? akt.Anlasma.flTAHCiroIsk : akt.Anlasma.flYEGCiroIsk) : 0;
                    double isk3 = 0;
                    double cirop = akt.intAnlasmaID > 0 ? (malzeme.GRUPKOD == "STG-1" ? akt.Anlasma.ahtCiroPrimDonusYuzdeToplam : akt.Anlasma.yegCiroPrimDonusYuzdeToplam) : 0;
                    double ekisk = kopyalanacak.detaylar[j].flEkIsk;
                    double birimfiyatkdvli = KdvEkle(fiyat.FIYAT, kdv);
                    double dusulmuskdvsiz = IskontoDus(fiyat.FIYAT, isk1, isk2, isk3, ekisk, 0);
                    double ciroprimdahil = IskontoDus(birimfiyatkdvli, isk1, isk2, isk3, ekisk, cirop);
                    double dusulmuskdvli = IskontoDus(birimfiyatkdvli, isk1, isk2, isk3, ekisk, 0);

                    aktivitelerDetay aktdet = new aktivitelerDetay(
                        akt.pkID, 
                        kopyalanacak.detaylar[j].intUrunID, 
                        kopyalanacak.detaylar[j].strUrunAdi, 
                        kopyalanacak.detaylar[j].intKoliAdet,
                        birimfiyatkdvli, 
                        kopyalanacak.detaylar[j].mnAksiyonFiyati, 
                        kopyalanacak.detaylar[j].flMusteriKarYuzde, 
                        kopyalanacak.detaylar[j].strSatisHedefi,
                        ciroprimdahil,
                        ekisk,
                        cirop,
                        ekisk,
                        dusulmuskdvli, 
                        kopyalanacak.detaylar[j].flKarZararYuzde,
                        dusulmuskdvli * Convert.ToInt32(kopyalanacak.detaylar[j].strSatisHedefi) * malzeme.KOLI, 
                        isk1.ToString("N1"),
                        isk2.ToString("N1"), 
                        isk3.ToString("N1"),
                        "0",
                        "");
                    aktdet.DoInsert();
                }
            }

            return Donen;
        }

        internal string AktiviteKaydet(AktiviteKaydet akg)
        {
            if (akg.id != 0) // aktivite güncelleniyorsa eskiyi silsin
            {
                aktiviteler aktivite = new aktiviteler(akg.id).GetObject();

                if (aktivite.blAktarilmis == DBNull.Value || Convert.ToBoolean(aktivite.blAktarilmis) == true)
                    return "hata: aktivite onaylı.";

                for (int i = 0; i < aktivite.detaylar.Count; i++)
                    aktivite.detaylar[i].DoDelete();
                aktivite.DoDelete();
            }

            musteriler mus = new musteriler(Convert.ToInt32(Sifreleme.Decrypt(akg.musteri))).GetObject();
            if (akg.anlasmaid != 0)
            {
                anlasmalar anlasma = new anlasmalar(Convert.ToInt32(akg.anlasmaid)).GetObject();
                akg.tahbedel = anlasma.tahSabitBedel;
                akg.yegbedel = anlasma.yegSabitBedel;
                akg.tahciro = anlasma.mnTAHToplamCiro;
                akg.yegciro = anlasma.mnYEGToplamCiro;
            }

            cariHesaplar ch = new cariHesaplar().GetObject1(akg.aktivitetipi, akg.smref);

            aktiviteler akt = new aktiviteler(mus.pkMusteriID, akg.smref, akg.fiyattipi, akg.anlasmaid, akg.fiyattipi == 25 ? 1 : 2, DateTime.Now, DateTime.Now, false, Convert.ToDateTime(akg.baslangic), Convert.ToDateTime(akg.bitis), akg.aciklama1, akg.aciklama2, akg.aciklama3, akg.donem, akg.tahbedel, akg.yegbedel, akg.tahciro, akg.yegciro, 0, (akg.fiyattipi == 25 && ch.BayiMi && akg.aktivitetipi == 1) ? 1 : 0);
            akt.DoInsert();
            for (int i = 0; i < akg.detaylar.Count; i++)
            {
                malzemeler malzeme = new malzemeler(akg.detaylar[i].urun).GetObject();
                fiyatlarTp fiyat = new fiyatlarTp().GetObject(akg.yil, akg.ay, akg.gun, akg.fiyattipi, akg.detaylar[i].urun);
                double kdv = ((fiyat.NETKDV / fiyat.NET) - 1) * 100;
                double isk1 = akg.detaylar[i].fatalt;
                double isk2 = akg.detaylar[i].fataltciro;
                double isk3 = akg.detaylar[i].pazisk;
                double cirop = akg.detaylar[i].ciroprim;
                double ekisk = akg.detaylar[i].ekisk;
                double birimfiyatkdvli = KdvEkle(fiyat.FIYAT, kdv);
                double dusulmuskdvsiz = IskontoDus(fiyat.FIYAT, isk1, isk2, isk3, ekisk, 0);
                double ciroprimdahil = IskontoDus(birimfiyatkdvli, isk1, isk2, isk3, ekisk, cirop);
                double dusulmuskdvli = IskontoDus(birimfiyatkdvli, isk1, isk2, isk3, ekisk, 0);

                aktivitelerDetay aktdet = new aktivitelerDetay(
                    akt.pkID, 
                    akg.detaylar[i].urun, 
                    akg.detaylar[i].urunacik,
                    Convert.ToInt32(malzeme.KOLI),
                    birimfiyatkdvli, 
                    akg.detaylar[i].aksiyon,
                    0, 
                    akg.detaylar[i].miktar,
                    ciroprimdahil,
                    ekisk,
                    cirop,
                    ekisk,
                    dusulmuskdvli, 
                    0,
                    dusulmuskdvli * Convert.ToInt32(akg.detaylar[i].miktar) * malzeme.KOLI,
                    isk1.ToString("N1"), isk2.ToString("N1"), isk3.ToString("N1"), "0", "");
                aktdet.DoInsert();
            }

            return akt.pkID.ToString();
        }

        internal double IskontoDus(double fiyat, double isk1, double isk2, double isk3, double isk4, double isk5)
        {
            double birinci = fiyat - (fiyat * isk1 / 100);
            double ikinci = birinci - (birinci * isk2 / 100);
            double ucuncu = ikinci - (ikinci * isk3 / 100);
            double dorduncu = ucuncu - (ucuncu * isk4 / 100);
            return dorduncu - (dorduncu * isk5 / 100);
        }

        internal double KdvEkle(double fiyat, double kdv)
        {
            return fiyat * (100 + kdv) / 100;
        }
    }
}

using Sultanlar.DbObj.Internet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sultanlar.WebAPI.Models.Internet;
using Sultanlar.Class;
using Sultanlar.DatabaseObject.Internet;
using System.Net;
using System.IO;
using System.Globalization;
using System.Linq.Dynamic.Core;
using System.Collections;
using Microsoft.AspNetCore.Mvc;
using Sultanlar.DatabaseObject;
using System.Data;

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

            object Onay = sget.onay == "1" || sget.onay == "3" ? true : sget.onay == "0" ? false : (object)DBNull.Value;
            object Ay = sget.ay == 0 ? (object)DBNull.Value : sget.ay;

            if (sget.smref != 0)
                donendeger2 = new siparisler().GetObjectsBySLSREFSMREF(sget.slsref, sget.smref, sget.yil, Ay, Onay);
            else if (sget.gmref != 0)
                donendeger2 = new siparisler().GetObjectsBySLSREFGMREF(sget.slsref, sget.gmref, sget.yil, Ay, Onay);
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
            List<siparislerDetay> silinecekler = new siparislerDetay().GetObjects(sip.pkSiparisID, 0);
            for (int i = 0; i < silinecekler.Count; i++)
            {
                //new siparislerDetayISKs(silinecekler[i].pkSiparisDetayID).GetObject().DoDelete(); gereksiz
                silinecekler[i].DoDelete();
            }
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
                siparisler sip = new siparisler(kopyalanacak.intMusteriID, skg.SMREFs[i].smref, kopyalanacak.sintFiyatTipiID, DateTime.Now, kopyalanacak.mnToplamTutar, false, skg.SMREFs[i].tip, DateTime.Now, kopyalanacak.strAciklama);
                sip.DoInsert();
                cariHesaplar ch = new cariHesaplar(sip.SMREF).GetObject();
                for (int j = 0; j < kopyalanacak.detaylar.Count; j++)
                {
                    siparislerDetay sipdet = new siparislerDetay(sip.pkSiparisID, kopyalanacak.detaylar[j].intUrunID, kopyalanacak.detaylar[j].strUrunAdi, kopyalanacak.detaylar[j].intMiktar, kopyalanacak.detaylar[j].mnFiyat, kopyalanacak.detaylar[j].unKampanyaKart, kopyalanacak.detaylar[j].blKampanyaHediye, kopyalanacak.detaylar[j].unKampanyaSatir, kopyalanacak.detaylar[j].strMiktarTur);
                    sipdet.DoInsert();

                    malzemeler mal = new malzemeler(sipdet.intUrunID).GetObject();

                    if (sip.sintFiyatTipiID == 2)
                    {
                        ArrayList alternatifbayiler = CariHesaplarTPEk.GetAlternatifBayiler();
                        var alternatifmi = alternatifbayiler.ToArray().Where(x => x.ToString() == sip.SMREF.ToString()).Any();
                        if (alternatifmi) // if (sip.SMREF == 1014039 || sip.SMREF == 1071782 || sip.SMREF == 1072515 || sip.SMREF == 1072228)
                        {
                            fiyatlar fiy = new fiyatlar(20, sipdet.intUrunID).GetObject();
                            double f = fiy.FIYAT;

                            CariHesaplarTPEk2 bayisart = CariHesaplarTPEk2.GetObject(sip.SMREF, DateTime.Now.Year, DateTime.Now.Month);

                            double isk = mal.REYKOD == "T2" ? bayisart.YEG_KAR : bayisart.TAH_KAR; //(sip.SMREF == 1014039 || sip.SMREF == 1071782 || sip.SMREF == 1072228 ? 15 : 12) : (sip.SMREF == 1014039 || sip.SMREF == 1071782 ? 11 : 9);
                            //double fiynet = f - ((f / 100) * isk);
                            double fiykdv = f + ((f * mal.KDV) / 100);
                            siparislerDetayISKs sipdetisks = new siparislerDetayISKs(sipdet.pkSiparisDetayID, fiy.FIYAT, isk, 0, 0, 0, 0, 0, 0, 0, 0, 0);
                            sipdetisks.DoInsert();
                            sipdet.mnFiyat = fiykdv;
                            sipdet.DoUpdate();
                        }
                        /*else if (sip.SMREF == 1072515)
                        {
                            fiyatlar fiy = new fiyatlar(20, sipdet.intUrunID).GetObject();
                            double f = fiy.FIYAT;
                            double isk = mal.REYKOD == "T2" ? 12 : 9;
                            //double fiynet = f - ((f / 100) * isk);
                            double fiykdv = f + ((f * mal.KDV) / 100);
                            siparislerDetayISKs sipdetisks = new siparislerDetayISKs(sipdet.pkSiparisDetayID, fiy.FIYAT, isk, 0, 0, 0, 0, 0, 0, 0, 0, 0);
                            sipdetisks.DoInsert();
                            sipdet.mnFiyat = fiykdv;
                            sipdet.DoUpdate();
                        }*/
                        else
                        {
                            if (sip.TKSREF > 1) // bayi alt cari
                            {
                                SiparisIsks sipisks = IsksTP(sip.SMREF, sip.TKSREF, sipdet.intUrunID, DateTime.Now);
                                siparislerDetayISKs sipdetisks = new siparislerDetayISKs(sipdet.pkSiparisDetayID, sipisks.fiyat, sipisks.isk1, sipisks.isk2, sipisks.isk3, sipisks.isk4, 0, 0, 0, 0, 0, 0);
                                sipdetisks.DoInsert();
                            }
                            else
                            {
                                fiyatlar fiy = new fiyatlar(2, sipdet.intUrunID).GetObject();
                                aktivitelerDetay aktd = new aktivitelerDetay().GetObjectSon(ch.GMREF, sipdet.intUrunID, DateTime.Now);
                                if (aktd.pkID > 0)
                                {
                                    siparislerDetayISKs sipdetisks = new siparislerDetayISKs(sipdet.pkSiparisDetayID, fiy.FIYAT, Convert.ToDouble(aktd.strAciklama1), Convert.ToDouble(aktd.strAciklama2), Convert.ToDouble(aktd.strAciklama3), aktd.flEkIsk, 0, 0, 0, 0, 0, 0);
                                    sipdetisks.DoInsert();
                                }
                                else
                                {
                                    anlasmalar anl = new anlasmalar().GetObjectSon(ch.GMREF, "2", DateTime.Now);
                                    if (anl.pkID > 0)
                                    {
                                        siparislerDetayISKs sipdetisks = new siparislerDetayISKs(sipdet.pkSiparisDetayID, fiy.FIYAT, (mal.GRUPKOD == "STG-1" ? anl.flTAHIsk : anl.flYEGIsk), (mal.GRUPKOD == "STG-1" ? anl.flTAHCiroIsk : anl.flYEGCiroIsk), 0, 0, 0, 0, 0, 0, 0, 0);
                                        sipdetisks.DoInsert();
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return Donen;
        }

        internal string SiparisKaydet(SiparisKaydet skg)
        {
            siparisler siparis = new siparisler(skg.siparisid).GetObject();
            if (Convert.ToBoolean(siparis.blAktarilmis) == true)
                return "hata: sipariş onaylı.";

            musteriler mus = new musteriler(Convert.ToInt32(Sifreleme.Decrypt(skg.musteri))).GetObject();
            int musid = mus.pkMusteriID; //new musteriler().GetMusteriBySLSREF(new cariHesaplar(skg.smref).GetObject().SLSREF).pkMusteriID;

            siparisler sip = new siparisler(musid != 0 ? musid : mus.pkMusteriID, skg.smref, skg.ftip, DateTime.Now, 0, false, skg.mtip, DateTime.Now, mus.AdSoyad + ";;;" + skg.aciklama + ";;;" + Convert.ToDateTime(skg.teslim).ToShortDateString());
            sip.DoInsert();
            double toplam = 0;
            for (int i = 0; i < skg.detaylar.Count; i++)
            {
                double fiyat = new fiyatlar(sip.sintFiyatTipiID, skg.detaylar[i].itemref).GetObject().NETKDV;
                siparislerDetay sipdet = new siparislerDetay(sip.pkSiparisID, skg.detaylar[i].itemref, skg.detaylar[i].malacik, skg.detaylar[i].miktar, fiyat, Guid.Empty, false, Guid.Empty, skg.detaylar[i].miktartur);
                sipdet.DoInsert();

                if (sip.sintFiyatTipiID == 2)
                {
                    ArrayList alternatifbayiler = CariHesaplarTPEk.GetAlternatifBayiler();
                    var alternatifmi = alternatifbayiler.ToArray().Where(x => x.ToString() == sip.SMREF.ToString()).Any();
                    if (alternatifmi) // if (sip.SMREF == 1014039 || sip.SMREF == 1071782 || sip.SMREF == 1072515 || sip.SMREF == 1072228)
                    {
                        malzemeler mal = new malzemeler(sipdet.intUrunID).GetObject();
                        fiyatlar fiy = new fiyatlar(20, sipdet.intUrunID).GetObject();
                        double f = fiy.FIYAT;

                        CariHesaplarTPEk2 bayisart = CariHesaplarTPEk2.GetObject(sip.SMREF, DateTime.Now.Year, DateTime.Now.Month);

                        double isk = mal.REYKOD == "T2" ? bayisart.YEG_KAR : bayisart.TAH_KAR; //(sip.SMREF == 1014039 || sip.SMREF == 1071782 || sip.SMREF == 1072228 ? 15 : 12) : (sip.SMREF == 1014039 || sip.SMREF == 1071782 ? 11 : 9);
                        //double fiynet = f - ((f / 100) * isk);
                        double fiykdv = f + ((f * mal.KDV) / 100); 
                        siparislerDetayISKs sipdetisks = new siparislerDetayISKs(sipdet.pkSiparisDetayID, fiy.FIYAT, isk, 0, 0, 0, 0, 0, 0, 0, 0, 0);
                        sipdetisks.DoInsert();
                        sipdet.mnFiyat = fiykdv;
                        sipdet.DoUpdate();
                    }
                    /*else if (sip.SMREF == 1072515)
                    {
                        malzemeler mal = new malzemeler(sipdet.intUrunID).GetObject();
                        fiyatlar fiy = new fiyatlar(20, sipdet.intUrunID).GetObject();
                        double f = fiy.FIYAT;
                        double isk = mal.REYKOD == "T2" ? 12 : 9;
                        //double fiynet = f - ((f / 100) * isk);
                        double fiykdv = f + ((f * mal.KDV) / 100);
                        siparislerDetayISKs sipdetisks = new siparislerDetayISKs(sipdet.pkSiparisDetayID, fiy.FIYAT, isk, 0, 0, 0, 0, 0, 0, 0, 0, 0);
                        sipdetisks.DoInsert();
                        sipdet.mnFiyat = fiykdv;
                        sipdet.DoUpdate();
                    }*/
                    else
                    {
                        fiyatlar fiy = new fiyatlar(2, sipdet.intUrunID).GetObject();
                        siparislerDetayISKs sipdetisks = new siparislerDetayISKs(sipdet.pkSiparisDetayID, fiy.FIYAT, skg.detaylar[i].isk1, skg.detaylar[i].isk2, skg.detaylar[i].isk3, skg.detaylar[i].isk4, 0, 0, 0, 0, 0, 0);
                        sipdetisks.DoInsert();
                    }
                }

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

            if (skg.siparisid != 0) // sipariş güncelleniyorsa eskiyi silsin
            {
                List<siparislerDetay> silinecekler = new siparislerDetay().GetObjects(siparis.pkSiparisID, 0);
                for (int i = 0; i < silinecekler.Count; i++)
                {
                    //new siparislerDetayISKs(silinecekler[i].pkSiparisDetayID).GetObject().DoDelete(); gereksiz
                    silinecekler[i].DoDelete();
                }
                siparis.DoDelete();
            }

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
            SiparisIsks donendeger = new SiparisIsks() { fiyat = fiyat, isk1 = 0, isk2 = 0, isk3 = 0, isk4 = 0 };

            malzemeler mal = new malzemeler(ITEMREF).GetObject();

            ArrayList alternatifbayiler = CariHesaplarTPEk.GetAlternatifBayiler();
            var alternatifmi = alternatifbayiler.ToArray().Where(x => x.ToString() == SMREF.ToString()).Any();
            if (alternatifmi) // (SMREF == 1014039 || SMREF == 1071782 || SMREF == 1072515 || SMREF == 1072228)
            {
                CariHesaplarTPEk2 bayisart = CariHesaplarTPEk2.GetObject(SMREF, DateTime.Now.Year, DateTime.Now.Month);
                return new SiparisIsks() { fiyat = fiyat, isk1 = (mal.REYKOD == "T2" ? bayisart.YEG_KAR : bayisart.TAH_KAR), isk2 = 0, isk3 = 0, isk4 = 0 };
            }

            /*if (SMREF == 1014039 || SMREF == 1071782 || SMREF == 1072228)
                return new SiparisIsks() { fiyat = fiyat, isk1 = (mal.REYKOD == "T2" ? 15 : 11), isk2 = 0, isk3 = 0, isk4 = 0 };
            else if (SMREF == 1072515)
                return new SiparisIsks() { fiyat = fiyat, isk1 = (mal.REYKOD == "T2" ? 12 : 9), isk2 = 0, isk3 = 0, isk4 = 0 };*/

            cariHesaplar ch = new cariHesaplar(SMREF).GetObject();

            ArrayList direkbayiler = CariHesaplarTPEk.GetDirekBayiler();
            var direkmi = direkbayiler.ToArray().Where(x => x.ToString() == ch.GMREF.ToString()).Any();
            int REF = direkmi ? ch.SMREF : ch.GMREF; //ch.GMREF == 1072532

            aktivitelerDetay aktd = new aktivitelerDetay().GetObjectSon(REF, ITEMREF, Tarih);
            if (aktd.pkID > 0)
            {
                donendeger = new SiparisIsks() { fiyat = aktd.mnBirimFiyatKDVli / ((100 + mal.KDV) / 100), isk1 = Convert.ToDouble(aktd.strAciklama1), isk2 = Convert.ToDouble(aktd.strAciklama2), isk3 = Convert.ToDouble(aktd.strAciklama3), isk4 = aktd.flEkIsk };
            }
            else
            {
                anlasmalar anl = new anlasmalar().GetObjectSon(REF, "2", Tarih);
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

        internal SiparisIsks Isks500(int Fiyattipi, int ITEMREF)
        {
            fiyatlar fiy = new fiyatlar(Fiyattipi, ITEMREF).GetObject();
            SiparisIsks donendeger = new SiparisIsks() { fiyat = fiy.FIYAT, isk1 = fiy.ISK1, isk2 = fiy.ISK2, isk3 = fiy.ISK3, isk4 = fiy.ISK6 };
            return donendeger;
        }

        internal SiparisIsks IsksTP(int SMREF, int TIP, int ITEMREF, DateTime Tarih)
        {
            double fiyat = new fiyatlar(20, ITEMREF).GetObject().FIYAT;
            SiparisIsks donendeger = new SiparisIsks() { fiyat = fiyat, isk1 = 0, isk2 = 0, isk3 = 0, isk4 = 0 };

            malzemeler mal = new malzemeler(ITEMREF).GetObject();
            cariHesaplar ch = new cariHesaplar().GetObject1(TIP, SMREF);

            long aktivitedetayid = AktivitelerDetay.GetTarihAraligiAktivitelerDetayID(
                SMREF,
                ITEMREF.ToString(),
                Tarih,
                25);
            aktivitelerDetay aktd = new aktivitelerDetay(aktivitedetayid).GetObject();

            if (aktivitedetayid > 0) // aktivite
            {
                donendeger = new SiparisIsks() { fiyat = aktd.mnBirimFiyatKDVli / ((100 + mal.KDV) / 100), isk1 = Convert.ToDouble(aktd.strAciklama1), isk2 = Convert.ToDouble(aktd.strAciklama2), isk3 = Convert.ToDouble(aktd.strAciklama3), isk4 = aktd.flEkIsk };
            }
            else
            {
                anlasmalar anl = new anlasmalar().GetObjectSon(SMREF, "1", Tarih);
                if (anl.pkID > 0) // anlaşma
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
                else
                {
                    long genelaktivitedetayid = AktivitelerDetay.GetTarihAraligiAktivitelerDetayID(ch.GMREF,
                            ITEMREF.ToString(),
                            Tarih,
                            25);
                    if (genelaktivitedetayid > 0) // genel anlaşmasız
                    {
                        aktivitelerDetay aktdG = new aktivitelerDetay(aktivitedetayid).GetObject();
                        donendeger.isk4 = aktdG.flEkIsk;
                    }
                    else // otoaktivite
                    {
                        int tur = ch.MTKOD == "B1" ? 2 : 1;
                        DataTable dtS = WebGenel.WCFdata("SELECT TOP 1 ISK1 FROM [Web-Fiyat-TP-Donem] WHERE TUR = @TUR AND ITEMREF = @ITEMREF AND BASLANGIC <= @FATURA AND BITIS >= @FATURA ORDER BY BASLANGIC DESC",
                                        new ArrayList() { "TUR", "ITEMREF", "FATURA" }, new SqlDbType[] { SqlDbType.Int, SqlDbType.Int, SqlDbType.DateTime }, new ArrayList() { tur, ITEMREF, Tarih }, "");

                        donendeger.isk4 = dtS.Rows.Count > 0 ? Convert.ToDouble(dtS.Rows[0][0]) : 0;
                    }
                }
            }

            return donendeger;
        }

        internal List<siparislerDetay> DetaySevksiz(int SLSREF)
        {
            return new siparislerDetay().GetObjectsSevksiz(SLSREF);
        }

        internal List<siparislerDetay> DetaySevkli(int SLSREF)
        {
            return new siparislerDetay().GetObjectsSevkli(SLSREF);
        }

        internal List<siparislerDetay> DetaySevkliAktarilmis(int SLSREF)
        {
            return new siparislerDetay().GetObjectsSevkliAktarilmis(SLSREF);
        }

        internal List<siparisler> Sevksiz(int SLSREF)
        {
            return new siparisler().GetObjectsSevksiz(SLSREF);
        }

        internal List<siparisler> Sevkli(int SLSREF)
        {
            return new siparisler().GetObjectsSevkli(SLSREF);
        }

        internal List<siparisler> SevkliAktarilmis(int SLSREF)
        {
            return new siparisler().GetObjectsSevkliAktarilmis(SLSREF);
        }

        /*internal string SevkKaydet(List<SevkKaydet> sks)
        {
            for (int i = 0; i < sks.Count; i++)
            {
                siparisler sip = new siparisler(Convert.ToInt32(sks[i].detayid)).GetObject();
                for (int j = 0; j < sip.detaylar.Count; j++)
                {

                    siparislerDetaySevk sds = new siparislerDetaySevk(sip.detaylar[j].pkSiparisDetayID).GetObject();
                    sds.DoUpdate();
                }

            }
            return "";
        }*/

        internal string DetaySevkKaydet(List<SevkKaydet> sks)
        {
            for (int i = 0; i < sks.Count; i++)
            {
                siparislerDetaySevk sds = new siparislerDetaySevk(sks[i].detayid, sks[i].miktar, false, DateTime.Now, DateTime.Now);
                sds.DoInsert();
            }
            return "";
        }

        internal string SevkIptal(List<SevkKaydet> sks)
        {
            for (int i = 0; i < sks.Count; i++)
            {
                new siparisler().DoUpdateQ(Convert.ToInt32(sks[i].detayid), Convert.ToDateTime(sks[i].fattar), true);

                siparisler sip = new siparisler(Convert.ToInt32(sks[i].detayid)).GetObject(); // önce aktar sonra iptal
                for (int j = 0; j < sip.detaylar.Count; j++)
                {
                    siparislerDetaySevk sds = new siparislerDetaySevk().GetObjectByDetayID(sip.detaylar[j].pkSiparisDetayID);
                    sds.blAktarildi = true;
                    sds.dtAktarmaTarih = DateTime.Now;
                    sds.DoUpdate();
                }
            }
            return "";
        }

        internal ContentResult SevkAktar(List<SevkKaydet> sks)
        {
            var xml = "<siparisler>";

            for (int i = 0; i < sks.Count; i++)
            {
                siparisler sip = new siparisler(Convert.ToInt32(sks[i].detayid)).GetObject();
                new siparisler().DoUpdateQ(sip.pkSiparisID, Convert.ToDateTime(sks[i].fattar), false);

                cariHesaplar cari = new cariHesaplar().GetObject1(sip.TKSREF, sip.SMREF);

                xml += "<siparis><sipno>" + sip.pkSiparisID.ToString() +
                    "</sipno><tur>" + "8" +
                    "</tur><belgeno>" + sip.QuantumNo +
                    "</belgeno><carino>" + (sip.TKSREF == 5 ? cari.NETTOP.ToString() : sip.SMREF.ToString()) +
                    "</carino><carino2>" + (sip.TKSREF == 5 ? new cariHesaplar().GetObject1(4, Convert.ToInt32(cari.NETTOP)).MUSKOD : sip.Cari.MUSKOD.ToString()) +
                    "</carino2><cari><![CDATA[" + (sip.TKSREF == 5 ? new cariHesaplar().GetObject1(4, Convert.ToInt32(cari.NETTOP)).SUBE : sip.Cari.SUBE) +
                    "]]></cari><tarih>" + sip.dtOnaylamaTarihi +
                    "</tarih>" + 
                    "<aciklama><![CDATA[" + (sip.TKSREF == 5 ? "Şube: " + sip.Cari.SUBE + " (" + sip.Cari.SMREF + ")" : "") +
                    "]]></aciklama><detaylar>";

                for (int j = 0; j < sip.detaylar.Count; j++)
                {
                    siparislerDetaySevk sds = new siparislerDetaySevk().GetObjectByDetayID(sip.detaylar[j].pkSiparisDetayID);
                    sds.blAktarildi = true;
                    sds.dtAktarmaTarih = DateTime.Now;
                    sds.DoUpdate();

                    xml += "<detay><detayno>" + sip.detaylar[j].pkSiparisDetayID.ToString() +
                        "</detayno>" + 
                        "<malzeme><malno>" + sip.detaylar[j].intUrunID.ToString() +
                        "</malno><malacik><![CDATA[" + sip.detaylar[j].Malzeme.MALACIK +
                        "]]></malacik><koli>" + sip.detaylar[j].Malzeme.KOLI.ToString("N0") +
                        "</koli></malzeme>" + 
                        "<miktartur>" + sip.detaylar[j].strMiktarTur +
                        "</miktartur><miktar>" + sds.intMiktar.ToString() +
                        "</miktar><isk1>" + sip.detaylar[j].isks.ISK1.ToString("N2") +
                        "</isk1><isk2>" + sip.detaylar[j].isks.ISK2.ToString("N2") +
                        "</isk2><isk3>" + sip.detaylar[j].isks.ISK3.ToString("N2") +
                        "</isk3><isk4>" + sip.detaylar[j].isks.ISK4.ToString("N2") +
                        "</isk4><fiyat>" + sip.detaylar[j].mnFiyat.ToString("N2") +
                        "</fiyat></detay>";
                }

                xml += "</detaylar></siparis>";
            }

            xml += "</siparisler>";

            return new ContentResult
            {
                Content = xml,
                ContentType = "application/xml",
                StatusCode = 200
            };
        }

        internal ContentResult DetaySevkAktar(List<SevkKaydet> sks)
        {
            var xml = "<siparisler>";

            siparisler sip = new siparisler(new siparislerDetay(new siparislerDetaySevk().GetObjectByDetayID(sks[0].detayid).bintSiparisDetayID).GetObject().intSiparisID).GetObject(); // hangi müşteri için
            
            xml += "<siparis><fatura_seri_no>" + sip.QuantumNo +
                "</fatura_seri_no><musteri_kod>" + sip.SMREF.ToString() +
                "</musteri_kod><musteri><![CDATA[" + sip.Cari.SUBE +
                "]]></musteri><detaylar>";

            for (int i = 0; i < sks.Count; i++)
            {
                siparislerDetaySevk sds = new siparislerDetaySevk().GetObjectByDetayID(sks[i].detayid);
                sds.blAktarildi = true;
                sds.dtAktarmaTarih = DateTime.Now;
                sds.DoUpdate();

                siparislerDetay sd = new siparislerDetay(sds.bintSiparisDetayID).GetObject();

                xml += "<detay><urun_kod>" + sd.intUrunID.ToString() +
                    "</urun_kod><urun><![CDATA[" + sd.Malzeme.MALACIK +
                    "]]></urun><koli_ici>" + sd.Malzeme.KOLI.ToString("N0") +
                    "</koli_ici><miktar_tur>" + sd.strMiktarTur + 
                    "</miktar_tur><miktar>" + sds.intMiktar.ToString() + 
                    "</miktar><fiyat>" + sd.mnFiyat.ToString("N2") +
                    "</fiyat></detay>";
            }

            xml += "</detaylar></siparis></siparisler>";

            return new ContentResult
            {
                Content = xml,
                ContentType = "application/xml",
                StatusCode = 200
            };
        }
    }
}

﻿using Sultanlar.DbObj.Internet;
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
        internal List<siparisler> Siparisler(int yil, int ay, object Onay) => new siparisler().GetObjects(yil, ay, Onay, false);

        internal siparisler Siparis(int SiparisID) => new siparisler(SiparisID).GetObject();

        internal DtAjaxResponse Siparisler(SiparisGet sget)
        {
            DtAjaxResponse donendeger = new DtAjaxResponse();
            List<siparisler> donendeger2 = new List<siparisler>();

            object Onay = sget.onay == "1" || sget.onay == "3" ? true : sget.onay == "0" ? false : (object)DBNull.Value;
            object Ay = sget.ay == 0 ? (object)DBNull.Value : sget.ay;

            if (sget.smref != 0)
                donendeger2 = new siparisler().GetObjectsBySLSREFSMREF(sget.slsref, sget.smref, sget.yil, Ay, Onay, false);
            else if (sget.gmref != 0)
                donendeger2 = new siparisler().GetObjectsBySLSREFGMREF(sget.slsref, sget.gmref, sget.yil, Ay, Onay, false);
            else if (sget.slsref != 0)
                donendeger2 = new siparisler().GetObjectsBySLSREF(sget.slsref, sget.yil, Ay, Onay, false);
            else
                donendeger2 = new siparisler().GetObjects(sget.yil, Ay, Onay, false);

            donendeger.recordsTotal = donendeger2.Count;
            if (sget.search.value != "")
            {
                donendeger2 = donendeger2.ToList().Where(k =>
                    k.pkSiparisID.ToString() == sget.search.value ||
                    k.Cari.MUSTERI.ToUpper(CultureInfo.CurrentCulture).IndexOf(sget.search.value.ToUpper(CultureInfo.CurrentCulture)) > -1 ||
                    k.Cari.SUBE.ToUpper(CultureInfo.CurrentCulture).IndexOf(sget.search.value.ToUpper(CultureInfo.CurrentCulture)) > -1 ||
                    k.Musteri.AdSoyad.ToUpper(CultureInfo.CurrentCulture).IndexOf(sget.search.value.ToUpper(CultureInfo.CurrentCulture)) > -1 ||
                    k.strAciklama.ToUpper(CultureInfo.CurrentCulture).IndexOf(sget.search.value.ToUpper(CultureInfo.CurrentCulture)) > -1 ||
                    k.FiyatTipi.ACIKLAMA.ToUpper(CultureInfo.CurrentCulture).IndexOf(sget.search.value.ToUpper(CultureInfo.CurrentCulture)) > -1 ||
                    k.QuantumNo.ToUpper(CultureInfo.CurrentCulture).IndexOf(sget.search.value.ToUpper(CultureInfo.CurrentCulture)) > -1
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
                new siparislerDetayISKs(silinecekler[i].pkSiparisDetayID).GetObject().DoDelete(); //gereksiz değil, sql de trigger var ama çalışmıyor!
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
                siparisler sip = new siparisler(kopyalanacak.intMusteriID, skg.SMREFs[i].smref, Convert.ToInt16(skg.FiyatTipi), DateTime.Now, kopyalanacak.mnToplamTutar, false, skg.SMREFs[i].tip, DateTime.Now, kopyalanacak.strAciklama);
                sip.DoInsert();
                cariHesaplar ch = new cariHesaplar(sip.SMREF).GetObject();
                double toplamtutar = 0;
                for (int j = 0; j < kopyalanacak.detaylar.Count; j++)
                {
                    siparislerDetay sipdet = new siparislerDetay(sip.pkSiparisID, kopyalanacak.detaylar[j].intUrunID, kopyalanacak.detaylar[j].strUrunAdi, kopyalanacak.detaylar[j].intMiktar, kopyalanacak.detaylar[j].mnFiyat, kopyalanacak.detaylar[j].unKampanyaKart, kopyalanacak.detaylar[j].blKampanyaHediye, kopyalanacak.detaylar[j].unKampanyaSatir, kopyalanacak.detaylar[j].strMiktarTur);
                    if (sip.TKSREF > 1 && sipdet.strMiktarTur == "KI")
                    {
                        sipdet.strMiktarTur = "ST";
                        sipdet.intMiktar = sipdet.intMiktar * Convert.ToInt32(sipdet.Malzeme.KOLI);
                    }
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
                            double fiykdv = 0;
                            if (sip.TKSREF > 1) // bayi alt cari
                            {
                                SiparisIsks sipisks = IsksTP(sip.SMREF, sip.TKSREF, sipdet.intUrunID, DateTime.Now);
                                siparislerDetayISKs sipdetisks = new siparislerDetayISKs(sipdet.pkSiparisDetayID, sipisks.fiyat, sipisks.isk1, sipisks.isk2, sipisks.isk3, sipisks.isk4, 0, 0, 0, 0, 0, 0);
                                sipdetisks.DoInsert();
                                fiykdv = sipisks.fiyat + ((sipisks.fiyat * mal.KDV) / 100);
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

                                fiykdv = fiy.FIYAT + ((fiy.FIYAT * mal.KDV) / 100);
                            }

                            sipdet.mnFiyat = fiykdv;
                            sipdet.DoUpdate();
                        }
                    }
                    else
                    {
                        fiyatlar fiy = new fiyatlar(sip.sintFiyatTipiID, sipdet.intUrunID).GetObject();
                        double fiykdv = fiy.FIYAT + ((fiy.FIYAT * mal.KDV) / 100);

                        sipdet.mnFiyat = fiykdv;
                        sipdet.DoUpdate();
                    }

                    toplamtutar += (sipdet.strMiktarTur == "KI" ? sipdet.Malzeme.KOLI : 1) * sipdet.mnFiyat * sipdet.intMiktar;
                }

                sip.mnToplamTutar = toplamtutar;
                sip.DoUpdate();
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
            if (sip.pkSiparisID == 0) // sipariş kaydedilemezse
                return "hata: sipariş kaydedilemedi.";

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
                    if (sip.TKSREF > 1)
                    {
                        sipdet.strMiktarTur = "ST";
                        sipdet.intMiktar = sipdet.intMiktar * Convert.ToInt32(sipdet.Malzeme.KOLI);
                    }
                    else
                    {
                        fiyat = fiyat * sipdet.Malzeme.KOLI;
                        //sipdet.mnFiyat = fiyat;
                    }
                    sipdet.DoUpdate();
                }
                toplam += fiyat * sipdet.intMiktar;
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

        internal List<siparisRaporu> SiparisRaporTp(int Yil, int Ay, int Slsref)
        {
            object ay = Ay == 0 ? DBNull.Value : (object)Ay;
            return new siparisRaporu().GetObjectsTp(Yil, ay, Slsref);
        }

        internal List<siparisDetayRaporu> SiparisDetayRapor(int Yil, int Ay, int Slsref, int Sipno)
        {
            object sipno = Sipno == 0 ? DBNull.Value : (object)Sipno;
            return new siparisDetayRaporu().GetObjects(Yil, Ay, Slsref, sipno);
        }

        internal List<siparisDetayRaporu> SiparisDetayRaporTp(int Yil, int Ay, int Slsref, int Sipno)
        {
            object sipno = Sipno == 0 ? DBNull.Value : (object)Sipno;
            return new siparisDetayRaporu().GetObjectsTp(Yil, Ay, Slsref, sipno);
        }

        internal List<siparisDurumRaporu> SiparisDurumRapor(int Yil, int Ay, int Slsref, int Sipno)
        {
            object ay = Ay == 0 ? DBNull.Value : (object)Ay;
            object sipno = Sipno == 0 ? DBNull.Value : (object)Sipno;
            return new siparisDurumRaporu().GetObjects(Yil, ay, Slsref, sipno);
        }

        internal SiparisIsks Isks(int SMREF, int ITEMREF, DateTime Tarih)
        {
            Tarih = Convert.ToDateTime(Tarih.ToShortDateString());
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
                donendeger = new SiparisIsks() { fiyat = fiyat, isk1 = Convert.ToDouble(aktd.strAciklama1), isk2 = Convert.ToDouble(aktd.strAciklama2), isk3 = Convert.ToDouble(aktd.strAciklama3), isk4 = aktd.flEkIsk };
                //aktd.mnBirimFiyatKDVli / ((100 + mal.KDV) / 100)
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
            Tarih = Convert.ToDateTime(Tarih.ToShortDateString());
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
                //aktiviteler akt = new aktiviteler(aktd.intAktiviteID).GetObject();
                //fiyatlarTp fyt = new fiyatlarTp().GetObject(akt.dtAktiviteBaslangic.Year, akt.dtAktiviteBaslangic.Month, akt.dtAktiviteBaslangic.Day, akt.sintFiyatTipiID, aktd.intUrunID);
                donendeger = new SiparisIsks() { fiyat = fiyat, isk1 = Convert.ToDouble(aktd.strAciklama1), isk2 = Convert.ToDouble(aktd.strAciklama2), isk3 = Convert.ToDouble(aktd.strAciklama3), isk4 = aktd.flEkIsk };
                //fiyat = aktd.mnBirimFiyatKDVli / ((100 + mal.KDV) / 100)
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
                        aktivitelerDetay aktdG = new aktivitelerDetay(genelaktivitedetayid).GetObject();
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
            return new siparisler().GetObjectsSevksiz(SLSREF, false);
        }

        internal List<siparisler> SevksizByGmref(int GMREF)
        {
            return new siparisler().GetObjectsSevksiz(GMREF, true);
        }

        internal List<siparisler> Sevkli(int SLSREF)
        {
            return new siparisler().GetObjectsSevkli(SLSREF, false);
        }

        internal List<siparisler> SevkliByGmref(int GMREF)
        {
            return new siparisler().GetObjectsSevkli(GMREF, true);
        }

        internal List<siparisler> SevkliAktarilmis(int SLSREF)
        {
            return new siparisler().GetObjectsSevkliAktarilmis(SLSREF, false);
        }

        internal List<siparisler> SevkliAktarilmisByGmref(int GMREF)
        {
            return new siparisler().GetObjectsSevkliAktarilmis(GMREF, true);
        }

        internal List<siparisler> BakiyeSiparisler(int SLSREF)
        {
            return new siparisler().GetObjectsBakiyeler(SLSREF, false);
        }

        internal List<siparisler> BakiyeSiparislerByGmref(int GMREF)
        {
            return new siparisler().GetObjectsBakiyeler(GMREF, true);
        }

        internal string SevkKaydet(List<SevkKaydet> sks)
        {
            List<siparisler> sips = new List<siparisler>();
            for (int i = 0; i < sks.Count; i++)
            {
                siparisler sip = new siparisler(Convert.ToInt32(sks[i].detayid)).GetObject();
                sips.Add(sip);
            }
            TopluSevkKaydet(sips);
            return "";
        }

        internal JsonResult SevkKamyon(List<SevkKaydet> sks)
        {
            List<siparislerDetay> sipdets = new List<siparislerDetay>();
            for (int i = 0; i < sks.Count; i++)
            {
                siparisler sip = new siparisler(Convert.ToInt32(sks[i].detayid)).GetObject();
                for (int j = 0; j < sip.detaylar.Count; j++)
                {
                    sipdets.Add(sip.detaylar[j]);
                }
            }
            var newsipdets = sipdets.GroupBy(x => new { x.intUrunID, x.strUrunAdi }).Select(g => new { malkod = g.Key.intUrunID, malzeme = g.Key.strUrunAdi, toplam = g.Sum(s => s.intMiktar) });
            var jsonr = new JsonResult(newsipdets);

            return jsonr;
        }

        internal string DetaySevkKaydet(List<SevkKaydet> sks)
        {
            siparisler sip = new siparisler(new siparislerDetay(sks[0].detayid).GetObject().intSiparisID).GetObject();

            for (int i = 0; i < sks.Count; i++) // kontrol
            {
                siparislerDetay sd = new siparislerDetay(sks[i].detayid).GetObject(sip.Cari.GMREF);
                if (sd.Malzeme.STOKDIS < sd.sevk.intMiktar)
                    return "hata: sevk adedi stoktan fazla girildi " + sd.intUrunID;
                if (sd.sevk.intMiktar < 0)
                    return "hata: sevk adedi eksi girildi " + sd.intUrunID;
            }

            /*siparisler bakiyesiparis = new siparisler();
            bool bakiyeMi = sip.QuantumBakiye;
            List<siparislerDetay> bakiyeler = new List<siparislerDetay>();
            if (bakiyeMi)
            {
                bakiyesiparis = new siparisler(sip.intMusteriID, sip.SMREF, sip.sintFiyatTipiID, DateTime.Now, 0, false, sip.TKSREF, DateTime.Now, sip.Aciklama1 + ";;;" + sip.Aciklama2 + "-BAKIYE-" + sip.pkSiparisID + ";;;" + sip.Aciklama3);
                bakiyesiparis.DoInsert();
            }*/

            int butunmiktar = 0;
            ArrayList sipdetsevkler = new ArrayList();
            for (int i = 0; i < sks.Count; i++)
            {
                butunmiktar += Convert.ToInt32(sks[i].miktar);
                siparislerDetaySevk sds = new siparislerDetaySevk(sks[i].detayid, Convert.ToInt32(sks[i].miktar), false, DateTime.Now, DateTime.Now);
                sds.DoInsert();
                sipdetsevkler.Add(sds);

                /*int bakiye = sd.intMiktar - Convert.ToInt32(sks[i].miktar);
                if (bakiyeMi)
                {
                    if (bakiye > 0)
                    {
                        bakiyeler.Add(new siparislerDetay(bakiyesiparis.pkSiparisID, sd.intUrunID, sd.strUrunAdi, bakiye, sd.mnFiyat, sd.unKampanyaKart, sd.blKampanyaHediye, sd.unKampanyaSatir, sd.strMiktarTur));
                    }
                }*/
            }

            if (butunmiktar == 0)
                for (int j = 0; j < sipdetsevkler.Count; j++)
                    ((siparislerDetaySevk)sipdetsevkler[j]).DoDelete();

            /*if (bakiyeler.Count > 0 && butunmiktar != 0)
            {
                double toplamtutar = 0;
                for (int i = 0; i < bakiyeler.Count; i++)
                {
                    toplamtutar += bakiyeler[i].intMiktar * bakiyeler[i].mnFiyat;
                    bakiyeler[i].DoInsert();
                    siparislerDetayISKs isks = new siparislerDetayISKs();
                    isks.bintSiparisDetayID = bakiyeler[i].pkSiparisDetayID;
                    isks.ISK1 = bakiyeler[i].isks.ISK1;
                    isks.ISK2 = bakiyeler[i].isks.ISK2;
                    isks.ISK3 = bakiyeler[i].isks.ISK3;
                    isks.ISK4 = bakiyeler[i].isks.ISK4;
                    isks.ISK5 = bakiyeler[i].isks.ISK5;
                    isks.ISK6 = bakiyeler[i].isks.ISK6;
                    isks.ISK7 = bakiyeler[i].isks.ISK7;
                    isks.ISK8 = bakiyeler[i].isks.ISK8;
                    isks.ISK9 = bakiyeler[i].isks.ISK9;
                    isks.ISK10 = bakiyeler[i].isks.ISK10;
                    isks.FIYAT = bakiyeler[i].isks.FIYAT;
                    isks.DoInsert();
                }
                bakiyesiparis.mnToplamTutar = toplamtutar;
                bakiyesiparis.DoUpdate();
            }
            else
            {
                if (bakiyeMi)
                    bakiyesiparis.DoDelete();
            }*/

            siparisler.ExecNQ("db_sp_bayiStokGuncelle1b", new ArrayList() { "GMREF" }, new[] { SqlDbType.Int }, new ArrayList() { sip.Cari.GMREF });

            return "";
        }

        internal string SevkIptal(List<SevkKaydet> sks)
        {
            for (int i = 0; i < sks.Count; i++)
            {
                DateTime tarih = sks[i].fattar == "" ? DateTime.Now : Convert.ToDateTime(sks[i].fattar);
                new siparisler().DoUpdateQ(Convert.ToInt32(sks[i].detayid), tarih, true);

                siparisler sip = new siparisler(Convert.ToInt32(sks[i].detayid)).GetObject(); // önce aktar sonra iptal
                for (int j = 0; j < sip.detaylar.Count; j++)
                {
                    siparislerDetaySevk sds = new siparislerDetaySevk().GetObjectByDetayID(sip.detaylar[j].pkSiparisDetayID);
                    if (sds.ID != 0) // sevk oluşmuş ise (sevk onaysızdan iptal edilenlerde sevk kaydı yok)
                    {
                        sds.blAktarildi = true;
                        sds.dtAktarmaTarih = DateTime.Now;
                        sds.DoUpdate();
                    }
                    else // sevk oluşmamış ise iptal ederken 0 adet aktarılmış sevk oluştur (sevk satırı olmazsa iptal faturalarda gözükmüyor)
                    {
                        siparislerDetaySevk sds1 = new siparislerDetaySevk(sip.detaylar[j].pkSiparisDetayID, 0, true, DateTime.Now, DateTime.Now);
                        sds1.DoInsert();
                    }
                }

                siparisler.ExecNQ("db_sp_bayiStokGuncelle1b", new ArrayList() { "GMREF" }, new[] { SqlDbType.Int }, new ArrayList() { sip.Cari.GMREF });
            }
            return "";
        }

        internal FileStreamResult SevkAktar(List<SevkKaydet> sks) //miktar apikey
        {
            var xml = "<siparisler>";

            string sipler = "";
            DateTime maxfattar = DateTime.Now;
            for (int i = 0; i < sks.Count; i++)
            {
                siparisler sip = new siparisler(Convert.ToInt32(sks[i].detayid)).GetObject();

                maxfattar = new siparisler().GetQMaxFattar(sip.Cari.GMREF).Date;
                DateTime faturatarihi = Convert.ToDateTime(sks[i].fattar).Date;
                DateTime varolanfaturatarihi = new siparisler().GetQFattar(sip.pkSiparisID); // aktarılmış ve tekrar aktar mı yapılıyor?

                if (varolanfaturatarihi != DateTime.MinValue || (faturatarihi >= DateTime.Now.Date && faturatarihi >= maxfattar))
                {
                    sipler += sks[i].detayid + ".";
                    new siparisler().DoUpdateQ(sip.pkSiparisID, Convert.ToDateTime(sks[i].fattar), false);

                    /*cariHesaplar cari = new cariHesaplar().GetObject1(sip.TKSREF, sip.SMREF);

                    xml += "<siparis><sipno>" + sip.pkSiparisID.ToString() +
                        "</sipno><tur>" + "8" +
                        "</tur><belgeno>" + sip.QuantumNo +
                        "</belgeno><carino>" + (sip.TKSREF == 5 ? cari.NETTOP.ToString() : sip.SMREF.ToString()) +
                        "</carino><carino2>" + (sip.TKSREF == 5 ? new cariHesaplar().GetObject1(4, Convert.ToInt32(cari.NETTOP)).MUSKOD : sip.Cari.MUSKOD.ToString()) +
                        "</carino2><cari><![CDATA[" + (sip.TKSREF == 5 ? new cariHesaplar().GetObject1(4, Convert.ToInt32(cari.NETTOP)).SUBE : sip.Cari.SUBE) +
                        "]]></cari><tarih>" + sip.dtOnaylamaTarihi +
                        "</tarih>" + 
                        "<aciklama><![CDATA[" + (sip.TKSREF == 5 ? "Şube: " + sip.Cari.SUBE + " (" + sip.Cari.SMREF + ")" : "") +
                        "]]></aciklama><detaylar>";*/

                    for (int j = 0; j < sip.detaylar.Count; j++)
                    {
                        siparislerDetaySevk sds = new siparislerDetaySevk().GetObjectByDetayID(sip.detaylar[j].pkSiparisDetayID);
                        sds.blAktarildi = true;
                        sds.dtAktarmaTarih = DateTime.Now;
                        sds.DoUpdate();

                        /*xml += "<detay><detayno>" + sip.detaylar[j].pkSiparisDetayID.ToString() +
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
                            "</fiyat></detay>";*/
                    }

                    //xml += "</detaylar></siparis>";
                }
            }

            xml += "</siparisler>";
            var stream = new MemoryStream();
            Stream responseStream = Stream.Null;

            if (sipler.Length > 0)
            {
                string apikey = sks[0].miktar.ToUpper();
                string erp = CariHesaplarTP.GetErpByApikey(Guid.Parse(apikey));

                System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();
                client.BaseAddress = new Uri("http://www.ittihadteknoloji.com.tr/wcf/bayiservis.svc/web/xml/fatura2/" + erp + "/" + apikey + "/" + sipler.Substring(0, sipler.Length - 1)); //http://www.ittihadteknoloji.com.tr/wcf
                client.DefaultRequestHeaders.Accept.Add(
                    new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/octet-stream"));
                Stream responseStream1 = client.GetStreamAsync("").Result;

                //WebClient wc = new WebClient();
                //string donen = wc.DownloadString("http://localhost:18006/bayiservis.svc/web/xml/fatura2/" + erp + "/" + apikey + "/" + sipler.Substring(0, sipler.Length - 1));

                /*HttpWebRequest wr = (HttpWebRequest)WebRequest.Create("http://localhost:18006/bayiservis.svc/web/xml/fatura2/" + erp + "/" + apikey + "/" + sipler.Substring(0, sipler.Length - 1)); //http://localhost:18006/bayiservis.svc/web/xml/fatura2/
                wr.Method = "GET";
                wr.ContentType = "application/octet-stream; encoding='ISO-8859-9'";
                wr.Timeout = 600000;
                wr.ReadWriteTimeout = 600000;
                HttpWebResponse response = (HttpWebResponse)wr.GetResponse();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    responseStream = response.GetResponseStream();
                    string responseStr = new StreamReader(responseStream).ReadToEnd();
                    CopyStream(responseStream, stream);
                    stream.Position = 0;

                    //byte[] gir = System.Text.Encoding.GetEncoding("ISO-8859-9").GetBytes(responseStr);
                    //string cik = System.Text.Encoding.GetEncoding("ISO-8859-9").GetString(gir);

                    //var writer = new StreamWriter(stream);
                    //writer.Write(responseStream);
                    //writer.Flush();
                    //stream.Position = 0;

                    xml = responseStr.Replace("><", ">\r\n<");
                }*/


                /*var result = new System.Net.Http.HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new System.Net.Http.ByteArrayContent(stream.ToArray())
                };*/
                return new FileStreamResult(responseStream1, "application/octet-stream");

                /*return new ContentResult
                {
                    Content = donen,
                    ContentType = "text/xml",
                    StatusCode = 200
                };*/
            }

            return new FileStreamResult(responseStream, "application/octet-stream");
        }

        public static void CopyStream(Stream input, Stream output)
        {
            byte[] buffer = new byte[16 * 1024];
            int read;
            while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
            {
                output.Write(buffer, 0, read);
            }
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

        internal string SevksizOnaydanGeri(int SiparisID)
        {
            if (new siparisler().GetQBakiyeRef(SiparisID) == 0)
            {
                siparisler sip = new siparisler(SiparisID).GetObject();
                sip.blAktarilmis = false;
                sip.DoUpdate();
                //sip.DoDeleteQ();
                return "";
            }
            else
            {
                return "Bakiye kalandan oluşturulan bir sipariş geri alınamaz.";
            }
        }

        internal string SevkTamami(int SLSREF)
        {
            List<siparisler> sips = new siparisler().GetObjectsSevksiz(SLSREF, false);
            TopluSevkKaydet(sips);
            return "";
        }

        internal string BakiyeKalanOlustur(List<SevkKaydet> sks)
        {
            List<siparisler> sips = new List<siparisler>();
            for (int i = 0; i < sks.Count; i++)
            {
                siparisler sip = new siparisler(Convert.ToInt32(sks[i].detayid)).GetObject();
                sips.Add(sip);
            }

            for (int i = 0; i < sips.Count; i++)
            {
                siparisler bakiyesiparis = new siparisler(sips[i].intMusteriID, sips[i].SMREF, sips[i].sintFiyatTipiID, DateTime.Now, 0, true, sips[i].TKSREF, DateTime.Now, sips[i].Aciklama1 + ";;;" + sips[i].Aciklama2 + "-BAKIYE-" + sips[i].pkSiparisID + ";;;" + sips[i].Aciklama3);
                bakiyesiparis.DoInsert();

                double toplamtutar = 0;
                List<siparislerDetay> sipdets = new siparislerDetay().GetObjects(sips[i].pkSiparisID, 0); //sips[i].Cari.GMREF
                for (int j = 0; j < sipdets.Count; j++)
                {
                    siparislerDetaySevk sds = new siparislerDetaySevk().GetObjectByDetayID(sipdets[j].pkSiparisDetayID);

                    int bakiye = sipdets[j].intMiktar - Convert.ToInt32(sds.intMiktar);
                    if (bakiye > 0)
                    {
                        siparislerDetay sipdet = new siparislerDetay(bakiyesiparis.pkSiparisID, sipdets[j].intUrunID, sipdets[j].strUrunAdi, bakiye, sipdets[j].mnFiyat, sipdets[j].unKampanyaKart, sipdets[j].blKampanyaHediye, sipdets[j].unKampanyaSatir, sipdets[j].strMiktarTur);
                        sipdet.DoInsert();

                        siparislerDetayISKs isksE = new siparislerDetayISKs(sipdets[j].pkSiparisDetayID).GetObject();
                        siparislerDetayISKs isks = new siparislerDetayISKs();
                        isks.bintSiparisDetayID = sipdet.pkSiparisDetayID;
                        isks.ISK1 = isksE.ISK1;
                        isks.ISK2 = isksE.ISK2;
                        isks.ISK3 = isksE.ISK3;
                        isks.ISK4 = isksE.ISK4;
                        isks.ISK5 = isksE.ISK5;
                        isks.ISK6 = isksE.ISK6;
                        isks.ISK7 = isksE.ISK7;
                        isks.ISK8 = isksE.ISK8;
                        isks.ISK9 = isksE.ISK9;
                        isks.ISK10 = isksE.ISK10;
                        isks.FIYAT = isksE.FIYAT;
                        isks.DoInsert();

                        toplamtutar += sipdet.intMiktar * sipdet.mnFiyat;
                    }
                }

                bakiyesiparis.mnToplamTutar = toplamtutar;
                bakiyesiparis.DoUpdate();

                int bakiyeref = GetBakiyeRef(sips[i].pkSiparisID);

                int bayikod = bakiyesiparis.Cari.GMREF; //CariHesaplarTP.GetGMREFBySMREF(sip.SMREF);
                int siparisno = CariHesaplarTPEk.GetBayiSiparisNo(bayikod) + 1;
                CariHesaplarTPEk.SetBayiSiparisNo(bayikod, siparisno);
                //string mtkod = new siparisler().GetQMtkod(bakiyeref);
                string mtkod = new cariHesaplar().GetObject1(sips[i].TKSREF, sips[i].SMREF).MTKOD;
                DatabaseObject.Internet.Siparisler.DoInsertQ(bakiyesiparis.pkSiparisID, DatabaseObject.Internet.Genel.BayiSiparisnoDuzeltme(siparisno), true, mtkod);

                new siparisler().DoUpdateQbakiye(sips[i].pkSiparisID, false, 0);
                new siparisler().DoUpdateQbakiye(bakiyesiparis.pkSiparisID, true, bakiyeref); //bakiyeref == bakiyesiparis.pkSiparisID ? sips[i].pkSiparisID : bakiyere

                siparisler.ExecNQ("db_sp_bayiStokGuncelle1", new ArrayList(), new SqlDbType[] { }, new ArrayList());
            }
            return "";
        }


        internal string BakiyedenKaldir(List<SevkKaydet> sks)
        {
            List<siparisler> sips = new List<siparisler>();
            for (int i = 0; i < sks.Count; i++)
            {
                siparisler sip = new siparisler(Convert.ToInt32(sks[i].detayid)).GetObject();
                sips.Add(sip);
            }

            for (int i = 0; i < sips.Count; i++)
            {
                new siparisler().DoUpdateQbakiye(sips[i].pkSiparisID, false, 0);
            }

            return "";
        }

        internal int GetBakiyeRef(int SiparisID)
        {
            int donendeger = 0;
            /*int anaref = new siparisler().GetQBakiyeRef(SiparisID);
            if (anaref != 0)
            {
                donendeger = GetBakiyeRef(anaref) == 0 ? anaref : GetBakiyeRef(anaref);
            }
            else
            {
                donendeger = SiparisID;
            }*/

            int sonraki = new siparisler().GetQBakiyeRef(SiparisID);
            while (sonraki != 0)
            {
                donendeger = sonraki;
                sonraki = new siparisler().GetQBakiyeRef(sonraki);
            }

            return donendeger == 0 ? SiparisID : donendeger;
        }

        internal void TopluSevkKaydet(List<siparisler> sips)
        {
            for (int i = 0; i < sips.Count; i++)
            {
                /*siparisler bakiyesiparis = new siparisler();
                bool bakiyeMi = sips[i].QuantumBakiye;
                List<siparislerDetay> bakiyeler = new List<siparislerDetay>();
                if (bakiyeMi)
                {
                    bakiyesiparis = new siparisler(sips[i].intMusteriID, sips[i].SMREF, sips[i].sintFiyatTipiID, DateTime.Now, 0, false, sips[i].TKSREF, DateTime.Now, sips[i].Aciklama1 + ";;;" + sips[i].Aciklama2 + "-BAKIYE-" + sips[i].pkSiparisID + ";;;" + sips[i].Aciklama3);
                    bakiyesiparis.DoInsert();
                }*/

                int butunmiktar = 0;
                ArrayList sipdetsevkler = new ArrayList();
                List<siparislerDetay> sipdets = new siparislerDetay().GetObjects(sips[i].pkSiparisID, sips[i].Cari.GMREF);
                for (int j = 0; j < sipdets.Count; j++)
                {
                    int miktar = sipdets[j].Malzeme.STOKDIS > sipdets[j].intMiktar ? sipdets[j].intMiktar : Convert.ToInt32(sipdets[j].Malzeme.STOKDIS);
                    butunmiktar += miktar;
                    siparislerDetaySevk sds = new siparislerDetaySevk(sipdets[j].pkSiparisDetayID, miktar, false, DateTime.Now, DateTime.Now);
                    sds.DoInsert();
                    sipdetsevkler.Add(sds);

                    /*int bakiye = sipdets[j].intMiktar - Convert.ToInt32(sds.intMiktar);
                    if (bakiyeMi)
                    {
                        if (bakiye > 0)
                        {
                            bakiyeler.Add(new siparislerDetay(bakiyesiparis.pkSiparisID, sipdets[j].intUrunID, sipdets[j].strUrunAdi, bakiye, sipdets[j].mnFiyat, sipdets[j].unKampanyaKart, sipdets[j].blKampanyaHediye, sipdets[j].unKampanyaSatir, sipdets[j].strMiktarTur));
                        }
                    }*/
                }

                if (butunmiktar == 0)
                    for (int j = 0; j < sipdetsevkler.Count; j++)
                        ((siparislerDetaySevk)sipdetsevkler[j]).DoDelete();

                /*if (bakiyeler.Count > 0 && butunmiktar != 0)
                {
                    double toplamtutar = 0;
                    for (int j = 0; j < bakiyeler.Count; j++)
                    {
                        toplamtutar += bakiyeler[j].intMiktar * bakiyeler[j].mnFiyat;
                        bakiyeler[j].DoInsert();
                        siparislerDetayISKs isks = new siparislerDetayISKs();
                        isks.bintSiparisDetayID = bakiyeler[j].pkSiparisDetayID;
                        isks.ISK1 = bakiyeler[j].isks.ISK1;
                        isks.ISK2 = bakiyeler[j].isks.ISK2;
                        isks.ISK3 = bakiyeler[j].isks.ISK3;
                        isks.ISK4 = bakiyeler[j].isks.ISK4;
                        isks.ISK5 = bakiyeler[j].isks.ISK5;
                        isks.ISK6 = bakiyeler[j].isks.ISK6;
                        isks.ISK7 = bakiyeler[j].isks.ISK7;
                        isks.ISK8 = bakiyeler[j].isks.ISK8;
                        isks.ISK9 = bakiyeler[j].isks.ISK9;
                        isks.ISK10 = bakiyeler[j].isks.ISK10;
                        isks.FIYAT = bakiyeler[j].isks.FIYAT;
                        isks.DoInsert();
                    }
                    bakiyesiparis.mnToplamTutar = toplamtutar;
                    bakiyesiparis.DoUpdate();
                }
                else
                {
                    if (bakiyeMi)
                        bakiyesiparis.DoDelete();
                }*/

                siparisler.ExecNQ("db_sp_bayiStokGuncelle1", new ArrayList(), new SqlDbType[] { }, new ArrayList());
            }
        }
    }
}

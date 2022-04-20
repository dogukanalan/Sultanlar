using Sultanlar.Class;
using Sultanlar.DatabaseObject.Internet;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Xml;

namespace Sultanlar.WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Direct" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Direct.svc or Direct.svc.cs at the Solution Explorer and start debugging.
    public class Direct : IDirect
    {
        public string Test()
        {
            return "Sultanlar WCF çalışıyör.";
        }

        public XmlDocument HesaplaKaydetIc(int BayiKod, int Yil, int Ay, bool Kaydet)
        {
            DataTable dt = GetSatisRapor(BayiKod, (byte)Ay, (short)Yil);
            XmlDocument donendeger = HesaplaKaydet(dt, Kaydet);
            return donendeger;
        }

        public XmlDocument HesaplaKaydetDis(XmlDocument icerik, bool Kaydet)
        {
            string xml = icerik.OuterXml;
            DataSet ds = new DataSet();
            ds.ReadXml(new MemoryStream(Encoding.UTF8.GetBytes(xml)));
            DataTable dt = ds.Tables[0];
            return HesaplaKaydet(dt, Kaydet);
        }

        private DataTable GetSatisRapor(int GMREF, byte Ay, short Yil)
        {
            DataTable dt = new DataTable();
            SatisRaporTP.GetObjects(dt, GMREF, Ay, Yil);
            return dt;
        }

        public XmlDocument HesaplaKaydet(DataTable dt, bool Kaydet)
        {
            string olmayanurunler = string.Empty;
            string fiyatiolmayanurunler = string.Empty;
            ArrayList hesaplanamayansatirlar = new ArrayList();

            XmlDocument donendeger = new XmlDocument();



            #region Hesaplama
            decimal ToplamTAH = 0;
            decimal ToplamYEG = 0;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                double kar = 0;
                double isk1 = 0;
                double isk2 = 0;
                double isk3 = 0;
                double isk4 = 0;

                object objTAH = null;
                string grupkod = Urunler.GetProductGRPKOD(dt.Rows[i]["URUNKOD"].ToString());
                if (grupkod == "STG-1")
                    objTAH = true;
                else if (grupkod == "STG-2")
                    objTAH = false;
                else if (grupkod == string.Empty)
                    olmayanurunler += "(" + dt.Rows[i]["URUNKOD"].ToString() + ") " + dt.Rows[i]["URUNAD"].ToString() + "\r\n";

                int noktasatyil = Convert.ToInt32(dt.Rows[i]["NOKTASATYIL"]);
                int noktasatay = Convert.ToInt32(dt.Rows[i]["NOKTASATAY"]);
                int noktasatgun = Convert.ToDateTime(dt.Rows[i]["NOKTAEVREKTARIH"]).Day;
                DateTime noktaevraktarih = Convert.ToDateTime(dt.Rows[i]["NOKTAEVREKTARIH"]);

                if (objTAH != null) // ürünün bizde karşılığı varsa
                {
                    bool TAH = Convert.ToBoolean(objTAH);
                    bool karTAH = Urunler.GetProductReyKod(Convert.ToInt32(dt.Rows[i]["URUNKOD"])) == "T2" ? false : true;

                    int UrunID = Convert.ToInt32(dt.Rows[i]["URUNKOD"].ToString());

                    kar = karTAH ? CariHesaplarTPEk2.GetObject(Convert.ToInt32(dt.Rows[i]["GMREF"]), noktasatyil, noktasatay).TAH_KAR : CariHesaplarTPEk2.GetObject(Convert.ToInt32(dt.Rows[i]["GMREF"]), noktasatyil, noktasatay).YEG_KAR;

                    int SMREF = dt.Rows[i]["NOKTAREF"].ToString() != string.Empty ? Convert.ToInt32(dt.Rows[i]["NOKTAREF"]) : 0;
                    if (SMREF == 0)
                        SMREF = dt.Rows[i]["NOKTAKOD"].ToString() != string.Empty ?
                            CariHesaplarTP.GetSMREFByMUSKOD(Convert.ToInt32(dt.Rows[i]["GMREF"]), dt.Rows[i]["NOKTAKOD"].ToString())
                            : CariHesaplarTP.GetSMREFBySUBE(Convert.ToInt32(dt.Rows[i]["GMREF"]), dt.Rows[i]["NOKTAAD"].ToString().ToUpper());

                    long aktivitedetayid = AktivitelerDetay.GetTarihAraligiAktivitelerDetayID(
                        SMREF,
                        dt.Rows[i]["URUNKOD"].ToString(),
                        noktaevraktarih,
                        25);
                    int anlasmaid = Anlasmalar.GetSonAnlasmaID(SMREF, noktaevraktarih, "1");

                    if (aktivitedetayid > 0)
                    {
                        if (aktivitedetayid > 1000000000) // geriye dönük ise +1000000000
                        {
                            dt.Rows[i]["blGeriyeDonuk"] = true;
                            aktivitedetayid = aktivitedetayid - 1000000000;
                        }

                        AktivitelerDetay aktlerdet = AktivitelerDetay.GetObject(aktivitedetayid);
                        isk1 = Convert.ToDouble(aktlerdet.strAciklama1);
                        isk2 = Convert.ToDouble(aktlerdet.strAciklama2);
                        isk3 = Convert.ToDouble(aktlerdet.strAciklama3);
                        isk4 = aktlerdet.flEkIsk;

                        dt.Rows[i]["intAnlasmaID"] = Aktiviteler.GetObject(aktlerdet.intAktiviteID).intAnlasmaID;
                        dt.Rows[i]["intAktiviteID"] = aktlerdet.intAktiviteID;
                    }
                    else if (anlasmaid > 0) // aktivitesiz anlaşmalı ise
                    {
                        Anlasmalar anlasma = Anlasmalar.GetObject(anlasmaid);
                        isk1 = TAH ? anlasma.flTAHIsk : anlasma.flYEGIsk;
                        isk2 = TAH ? anlasma.flTAHCiroIsk : anlasma.flYEGCiroIsk;
                        isk3 = Convert.ToDouble(
                                FiyatlarTP.GetIskFiyat(UrunID, 3, 25,
                                noktasatyil,
                                noktasatay,
                                noktasatgun));

                        dt.Rows[i]["intAnlasmaID"] = anlasma.pkID;
                        dt.Rows[i]["intAktiviteID"] = 0;

                        if (isk1 == 0 && isk2 == 0) anlasmaid = 0; // anlaşma sadece tah veya sadece yeg ise diğerini kapsamasın, alttaki genel anlaşmasıza düşsün
                        if (anlasma.flTAHIsk == 0 && anlasma.flYEGIsk == 0) anlasmaid = anlasma.pkID; // tah ve yeg yoksa anlaşma tah yada yeg için geçerlidir o yüzden genel anlaşmasıza düşmesin
                    }

                    if (aktivitedetayid == 0 && anlasmaid == 0) // genel anlaşmasız aktivite
                    {
                        int GMREF = Convert.ToInt32(dt.Rows[i]["GMREF"]);

                        aktivitedetayid = AktivitelerDetay.GetTarihAraligiAktivitelerDetayID(GMREF,
                            dt.Rows[i]["URUNKOD"].ToString(),
                            noktaevraktarih,
                            25);

                        if (aktivitedetayid > 0)
                        {
                            if (aktivitedetayid > 1000000000) // geriye dönük ise +1000000000
                            {
                                dt.Rows[i]["blGeriyeDonuk"] = true;
                                aktivitedetayid = aktivitedetayid - 1000000000;
                            }

                            AktivitelerDetay aktlerdet = AktivitelerDetay.GetObject(aktivitedetayid);
                            isk1 = Convert.ToDouble(aktlerdet.strAciklama1);
                            isk2 = Convert.ToDouble(aktlerdet.strAciklama2);
                            isk3 = Convert.ToDouble(aktlerdet.strAciklama3);
                            isk4 = aktlerdet.flEkIsk;

                            dt.Rows[i]["intAnlasmaID"] = Aktiviteler.GetObject(aktlerdet.intAktiviteID).intAnlasmaID;
                            dt.Rows[i]["intAktiviteID"] = aktlerdet.intAktiviteID;
                        }
                        else // standart uygulama
                        {
                            CariHesaplarTPEk2 chtpek = CariHesaplarTPEk2.GetObject(GMREF, noktasatyil, noktasatay);
                            isk1 = TAH ? chtpek.TAH_ISK : chtpek.YEG_ISK;
                            isk2 = 0;
                            isk3 = Convert.ToDouble(
                                FiyatlarTP.GetIskFiyat(UrunID, 3, 25,
                                noktasatyil,
                                noktasatay,
                                noktasatgun));

                            dt.Rows[i]["intAnlasmaID"] = 0;
                            dt.Rows[i]["intAktiviteID"] = 0;
                        }
                    }

                    dt.Rows[i]["flIsk1"] = isk1;
                    dt.Rows[i]["flIsk2"] = isk2;
                    dt.Rows[i]["flIsk3"] = isk3;
                    dt.Rows[i]["flIsk4"] = isk4;



                    // bayinin alımı
                    double listefiyat = Convert.ToDouble(FiyatlarTP.GetNetFiyat(
                        UrunID,
                        (short)22,
                        noktasatyil,
                        noktasatay,
                        noktasatgun));
                    if (listefiyat == 0.0)
                    {
                        listefiyat = Convert.ToDouble(Urunler.GetProductNetFiyatFULL(
                            UrunID,
                            (short)22
                            ));
                    }



                    // brüt fiyat, aktivitenin hesaplanacagi fiyat
                    double listefiyat1 = 0.0;
                    if (listefiyat1 == 0.0)
                    {
                        listefiyat1 = Convert.ToDouble(FiyatlarTP.GetFiyat(
                            UrunID,
                            (short)22,
                            noktasatyil,
                            noktasatay,
                            noktasatgun));
                    }
                    /*else */
                    if (listefiyat1 == 0.0) // dönem fiyatı yoksa şimdiki fiyatı al
                    {
                        listefiyat1 = Convert.ToDouble(Urunler.GetProductDiscountsAndPriceFULL(
                            UrunID,
                            (short)22
                            )[4]);
                    }

                    if (listefiyat == 0 || listefiyat1 == 0)
                    {
                        fiyatiolmayanurunler += "(" + dt.Rows[i]["URUNKOD"].ToString() + ") " + dt.Rows[i]["URUNAD"].ToString() + "\r\n";
                        hesaplanamayansatirlar.Add(i);
                    }

                    double karlifiyat = listefiyat * ((100 + kar) / 100);

                    double bayifiyat = Convert.ToDouble(dt.Rows[i]["NOKTASATNET"]);

                    int bayiadet = Convert.ToInt32(dt.Rows[i]["NOKTASATADET"]);

                    double olmasigereken = listefiyat1 - ((listefiyat1 / 100) * isk1);
                    olmasigereken = olmasigereken - ((olmasigereken / 100) * isk2);
                    olmasigereken = olmasigereken - ((olmasigereken / 100) * isk3);
                    olmasigereken = olmasigereken - ((olmasigereken / 100) * isk4);

                    dt.Rows[i]["mnListeFiyat"] = listefiyat;
                    dt.Rows[i]["mnListeFiyatT"] = listefiyat * bayiadet;
                    dt.Rows[i]["mnListeFiyatKarli"] = karlifiyat;
                    dt.Rows[i]["mnListeFiyatKarliT"] = karlifiyat * bayiadet;

                    dt.Rows[i]["mnNetBirimFiyat"] = olmasigereken;
                    dt.Rows[i]["mnNetToplam"] = olmasigereken * bayiadet;

                    if (UrunID > 0 && listefiyat != 0.0 && listefiyat1 != 0.0)
                    {
                        if (bayifiyat >= olmasigereken)
                        {
                            dt.Rows[i]["mnBirimFark"] = bayifiyat - karlifiyat; //olmasigereken - bayifiyat
                            dt.Rows[i]["mnToplamFark"] = (bayifiyat - karlifiyat) * bayiadet; //(olmasigereken - bayifiyat) * bayiadet
                        }
                        else if (bayifiyat < olmasigereken)
                        {
                            dt.Rows[i]["mnBirimFark"] = olmasigereken - karlifiyat; //karlifiyat - olmasigereken
                            dt.Rows[i]["mnToplamFark"] = (olmasigereken - karlifiyat) * bayiadet;
                        }
                    }
                    else
                    {
                        dt.Rows[i]["mnBirimFark"] = 0;
                        dt.Rows[i]["mnToplamFark"] = 0;
                    }

                    decimal tahtoplam = TAH ? Convert.ToDecimal(dt.Rows[i]["mnToplamFark"]) : 0;
                    decimal yegtoplam = TAH ? 0 : Convert.ToDecimal(dt.Rows[i]["mnToplamFark"]);

                    ToplamTAH += tahtoplam;
                    ToplamYEG += yegtoplam;

                    dt.Rows[i]["TAHmnToplamFark"] = tahtoplam;
                    dt.Rows[i]["YEGmnToplamFark"] = yegtoplam;
                }
            }
            #endregion



            if (Kaydet)
            {
                #region Kaydetme
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    SatisRaporTP satisrapor = SatisRaporTP.GetObject(Convert.ToInt64(dt.Rows[i]["REF"]));
                    satisrapor.intAnlasmaID = Convert.ToInt32(dt.Rows[i]["intAnlasmaID"]);
                    satisrapor.intAktiviteID = Convert.ToInt32(dt.Rows[i]["intAktiviteID"]);
                    satisrapor.flIsk1 = Convert.ToDouble(dt.Rows[i]["flIsk1"]);
                    satisrapor.flIsk2 = Convert.ToDouble(dt.Rows[i]["flIsk2"]);
                    satisrapor.flIsk3 = Convert.ToDouble(dt.Rows[i]["flIsk3"]);
                    satisrapor.flIsk4 = Convert.ToDouble(dt.Rows[i]["flIsk4"]);
                    satisrapor.mnListeFiyat = Convert.ToDecimal(dt.Rows[i]["mnListeFiyat"]);
                    satisrapor.mnListeFiyatKarli = Convert.ToDecimal(dt.Rows[i]["mnListeFiyatKarli"]);
                    satisrapor.mnNetBirimFiyat = Convert.ToDecimal(dt.Rows[i]["mnNetBirimFiyat"]);
                    satisrapor.mnNetToplam = Convert.ToDecimal(dt.Rows[i]["mnNetToplam"]);
                    satisrapor.mnBirimFark = Convert.ToDecimal(dt.Rows[i]["mnBirimFark"]);
                    satisrapor.mnToplamFark = Convert.ToDecimal(dt.Rows[i]["mnToplamFark"]);
                    satisrapor.blGeriyeDonuk = Convert.ToBoolean(dt.Rows[i]["blGeriyeDonuk"]);
                    satisrapor.mnFaturadanKapatilan = Convert.ToDecimal(dt.Rows[i]["mnFaturadanKapatilan"]);
                    satisrapor.intFaturaID = Convert.ToInt32(dt.Rows[i]["intFaturaID"]);
                    satisrapor.DoUpdate();
                }
                #endregion

                donendeger.LoadXml("<?xml version=\"1.0\" encoding=\"utf-8\"?><sonuc><basarili>true</basarili></sonuc>");
                return donendeger;
            }
            else
            {
                DataSet ds1 = new DataSet();
                ds1.Tables.Add(dt);
                donendeger.LoadXml(ds1.GetXml());
                return donendeger;
            }
        }
    }
}

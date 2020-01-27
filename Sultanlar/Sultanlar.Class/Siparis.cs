using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Sultanlar.Class
{
    public class Siparis
    {
        public static bool SiparisOnayla(/*int siparisid, int sevkref, int depoid, bool bakiye, Musteriler musteri, out string Donen*/)
        {
            //    Donen = "";
            //    Siparisler siparis = Siparisler.GetObjectsBySiparisID(siparisid);

            //    if ((CariHesaplar.GetYetkili(siparis.SMREF) == 82965 || CariHesaplar.GetYetkili(siparis.SMREF) == 82966) 
            //        && Ekstreler.GetVgbByGMREF(CariHesaplar.GetGMREFBySMREF(siparis.SMREF)) <= -250)
            //    {
            //        Donen = "Bu müşterimizin vadesi geçmiş vgb si bulunmaktadır, bu sebeple sipariş aktarılmayacaktır.";
            //        return false;
            //    }

            //    if (siparis.sintFiyatTipiID == 3 && CariHesaplar.GetMtAciklama(siparis.SMREF).IndexOf("TOPTAN") == -1)
            //    {
            //        Donen = "Toptancı olmayan bir müşteriye toptan fiyatından sipariş girilemez. Eğer müşteri toptancı ise sistemden müşteri tipi değiştirilmelidir.";
            //        return false;
            //    }

            //    if (depoid != 0)
            //    {
            //        siparis.blAktarilmis = true;
            //        siparis.dtOnaylamaTarihi = DateTime.Now;
            //        siparis.strAciklama = musteri.strAd + " " + musteri.strSoyad + ";;;" +
            //            "Siparişin gönderileceği depo: " + Depolar.GetObject(depoid) + ";;;";
            //        siparis.DoUpdate();

            //        // dönüşte bool true ise depoid 0 dan büyük ise bunları çalıştır
            //        //Session["DepoID"] = null;
            //        //Session["SiparisTamamlaOnaylaBasildi"] = null;
            //        //Session["OnaylanacakSiparisID"] = null;
            //        //divSevkYerleri.Visible = false;
            //        //Response.Redirect("siparisler.aspx", true);
            //    }

            //    bool bakiyesiparis = siparis.sintFiyatTipiID == 12 || siparis.sintFiyatTipiID == 13 ? false : bakiye;



            //    bool siparisbolundu = false;
            //    bool bolunenlerdenbiriaktarilamadi = false;


            //    #region IsyeriOzelKod bölünmesi
            //    //
            //    if (siparis.SMREF != 24479 && CariHesaplar.GetGRPBySMREF(siparis.SMREF) != "06" && siparis.sintFiyatTipiID != 9 &&
            //        siparis.sintFiyatTipiID != 14 /*&& CariHesaplar.GetYTKKODBySMREF(siparis.SMREF) != "Z1"*/)
            //    {
            //        DataTable dtIsyeriOzelKodGruplar = new DataTable();
            //        IsyeriOzelKod.GetObjects2Gruplar(dtIsyeriOzelKodGruplar);

            //        for (int i = 0; i < dtIsyeriOzelKodGruplar.Rows.Count; i++)
            //        {
            //            DataTable dtSiparistekiUrunler = new DataTable();
            //            SiparislerDetay.GetObjectsBySiparisID(dtSiparistekiUrunler, siparisid);

            //            DataTable dtIsyeriOzelKod = new DataTable();
            //            IsyeriOzelKod.GetObjects2ByGrup(dtIsyeriOzelKod, Convert.ToInt32(dtIsyeriOzelKodGruplar.Rows[i][0]));

            //            short isyerino = Convert.ToInt16(dtIsyeriOzelKod.Rows[0]["sintIsyeriKod"]);
            //            short ambarno = Convert.ToInt16(dtIsyeriOzelKod.Rows[0]["sintAmbarKod"]);

            //            Siparisler yenisiparis =
            //                new Siparisler(siparis.intMusteriID, siparis.SMREF, siparis.sintFiyatTipiID, DateTime.Now, 0, false,
            //                    siparis.TKSREF, DateTime.Now, siparis.strAciklama);
            //            ArrayList yenisiparisurunleri = new ArrayList();
            //            ArrayList eskisiparisurunleri = new ArrayList();

            //            for (int j = 0; j < dtSiparistekiUrunler.Rows.Count; j++)
            //            {
            //                for (int k = 0; k < dtIsyeriOzelKod.Rows.Count; k++)
            //                {
            //                    string isyeriozelkod = dtIsyeriOzelKod.Rows[k]["strOzelKod"].ToString();
            //                    string urunozelkod = Urunler.GetProductOzelKod(Convert.ToInt32(dtSiparistekiUrunler.Rows[j]["intUrunID"]));

            //                    if (urunozelkod == isyeriozelkod)
            //                    {
            //                        siparisbolundu = true;
            //                        yenisiparisurunleri.Add(
            //                            new SiparislerDetay(
            //                                0,
            //                                Convert.ToInt32(dtSiparistekiUrunler.Rows[j]["intUrunID"]),
            //                                dtSiparistekiUrunler.Rows[j]["strUrunAdi"].ToString(),
            //                                Convert.ToInt32(dtSiparistekiUrunler.Rows[j]["intMiktar"]),
            //                                Convert.ToDecimal(dtSiparistekiUrunler.Rows[j]["mnFiyat"]),
            //                                Guid.Parse(dtSiparistekiUrunler.Rows[j]["unKampanyaKart"].ToString()),
            //                                Convert.ToBoolean(dtSiparistekiUrunler.Rows[j]["blKampanyaHediye"]),
            //                                Guid.Parse(dtSiparistekiUrunler.Rows[j]["unKampanyaSatir"].ToString()),
            //                                dtSiparistekiUrunler.Rows[j]["strMiktarTur"].ToString()));

            //                        SiparislerDetay siplerdet = SiparislerDetay.GetObjectBySiparislerDetayID(
            //                            Convert.ToInt64(dtSiparistekiUrunler.Rows[j]["pkSiparisDetayID"]));

            //                        eskisiparisurunleri.Add(siplerdet);

            //                        siplerdet.DoDelete();
            //                        siparis.ToplamTutarGuncelle();

            //                        break;
            //                    }
            //                }
            //            }

            //            if (yenisiparisurunleri.Count > 0)
            //            {
            //                yenisiparis.DoInsert();

            //                decimal toplamtutar = 0;
            //                for (int j = 0; j < yenisiparisurunleri.Count; j++)
            //                {
            //                    SiparislerDetay siplerdet = (SiparislerDetay)yenisiparisurunleri[j];
            //                    siplerdet.intSiparisID = yenisiparis.pkSiparisID;
            //                    siplerdet.DoInsert();

            //                    SiparislerDetay.DoChangeIDISKs(((SiparislerDetay)eskisiparisurunleri[j]).pkSiparisDetayID, siplerdet.pkSiparisDetayID);

            //                    if (!siplerdet.blKampanyaHediye)
            //                        toplamtutar += siplerdet.mnFiyat * siplerdet.intMiktar;
            //                }
            //                yenisiparis.mnToplamTutar = toplamtutar;
            //                yenisiparis.DoUpdate();

            //                //if (!TaksitPlanlari.TaksitMi(siparis.TKSREF))
            //                //    yenisiparis.TKSREF = TaksitPlanlari.GetODMREF(GetSiparisOrtVade(yenisiparis));

            //                Donen = QuantumaYaz(yenisiparis.pkSiparisID, isyerino, ambarno, bakiyesiparis, sevkref, bakiye, musteri.pkMusteriID);
            //                if (Donen == string.Empty)
            //                {
            //                    yenisiparis.blAktarilmis = true;
            //                    yenisiparis.DoUpdate();
            //                }
            //                else
            //                {
            //                    bolunenlerdenbiriaktarilamadi = true;
            //                }
            //            }
            //        }
            //    }
            //    //
            //    #endregion


            //    bool siparisaktarilamadi = false;


            //    DataTable dt = new DataTable();
            //    SiparislerDetay.GetObjectsBySiparisID(dt, siparis.pkSiparisID);
            //    if (dt.Rows.Count == 0) // eski siparişte ürün kalmışsa alsat dır
            //    {
            //        siparis.DoDelete();
            //    }
            //    else
            //    {
            //        if (siparisbolundu)
            //        {
            //            decimal toplamtutar = 0;

            //            for (int i = 0; i < dt.Rows.Count; i++)
            //                if (!Convert.ToBoolean(dt.Rows[i]["blKampanyaHediye"]))
            //                    toplamtutar += Convert.ToDecimal(dt.Rows[i]["mnFiyat"]) * Convert.ToInt32(dt.Rows[i]["intMiktar"]);

            //            siparis.mnToplamTutar = toplamtutar;
            //            siparis.DoUpdate();
            //        }


            //        #region vade bölünmesi


            //        ArrayList vadeler = new ArrayList();
            //        for (int i = 0; i < dt.Rows.Count; i++)
            //        {
            //            int vade = Urunler.GetProductVade(Convert.ToInt32(dt.Rows[i]["intUrunID"]), siparis.sintFiyatTipiID);
            //            bool var = false;
            //            for (int j = 0; j < vadeler.Count; j++)
            //                if (Convert.ToInt32(vadeler[j]) == vade)
            //                    var = true;

            //            if (!var)
            //                vadeler.Add(vade);
            //        }

            //        if (vadeler.Count == 1) // vadeler hep aynıysa bölme
            //        {
            //            if (QuantumaYaz(siparisid, 0, 0, bakiyesiparis, sevkref, bakiye, musteri.pkMusteriID) == string.Empty)
            //            {
            //                siparis.blAktarilmis = true;

            //                siparis.dtOnaylamaTarihi = DateTime.Now;
            //                siparis.DoUpdate();
            //            }
            //            else
            //            {
            //                siparisaktarilamadi = true;
            //            }
            //        }
            //        else // bölünme
            //        {
            //            for (int i = 0; i < vadeler.Count; i++)
            //            {
            //                // yeni sipariş oluştur
            //                Siparisler yenisiparis = new Siparisler(siparis.intMusteriID, siparis.SMREF, siparis.sintFiyatTipiID, DateTime.Now, 0, false,
            //                    siparis.TKSREF, DateTime.Now, siparis.strAciklama);
            //                yenisiparis.DoInsert();

            //                // yeni sipariş kalemlerini vadeden yararlanarak bul
            //                ArrayList yenisipariskalemleri = new ArrayList();
            //                for (int j = 0; j < dt.Rows.Count; j++)
            //                {
            //                    int vade = Urunler.GetProductVade(Convert.ToInt32(dt.Rows[j]["intUrunID"]), siparis.sintFiyatTipiID);
            //                    if (Convert.ToInt32(vadeler[i]) == vade)
            //                    {
            //                        SiparislerDetay sipdet = SiparislerDetay.GetObjectBySiparislerDetayID(Convert.ToInt64(dt.Rows[j]["pkSiparisDetayID"]));
            //                        yenisipariskalemleri.Add(new SiparislerDetay(yenisiparis.pkSiparisID, sipdet.intUrunID, sipdet.strUrunAdi, sipdet.intMiktar, sipdet.mnFiyat, sipdet.unKampanyaKart, sipdet.blKampanyaHediye, sipdet.unKampanyaSatir, sipdet.strMiktarTur));
            //                    }
            //                }

            //                // bulunan yeni sipariş kalemlerini yeni siparişe ekle
            //                decimal toplamtutar = 0;
            //                for (int j = 0; j < yenisipariskalemleri.Count; j++)
            //                {
            //                    SiparislerDetay sipdet = ((SiparislerDetay)yenisipariskalemleri[j]);
            //                    toplamtutar += sipdet.mnFiyat * sipdet.intMiktar;
            //                    sipdet.DoInsert();
            //                }
            //                yenisiparis.mnToplamTutar = toplamtutar;

            //                if (!TaksitPlanlari.TaksitMi(siparis.TKSREF))
            //                    yenisiparis.TKSREF = TaksitPlanlari.GetODMREF(Convert.ToInt32(vadeler[i]));

            //                yenisiparis.DoUpdate();

            //                // yeni siparişi onayla
            //                if (QuantumaYaz(yenisiparis.pkSiparisID, 0, 0, bakiyesiparis, sevkref, bakiye, musteri.pkMusteriID) == string.Empty)
            //                {
            //                    yenisiparis.blAktarilmis = true;

            //                    yenisiparis.dtOnaylamaTarihi = DateTime.Now;
            //                    yenisiparis.DoUpdate();
            //                }
            //                else
            //                {
            //                    siparisaktarilamadi = true;
            //                }
            //            }

            //            siparis.DoDelete(); // eski siparişte ürün kalmadığından sil
            //        }


            //        #endregion


            //    }



            //    if (siparisaktarilamadi || bolunenlerdenbiriaktarilamadi)
            //    {
            //        // dönüşte false olursa bu div i visible true yap
            //        //divSiparisOnaylanamadi.Visible = true;
            //        //Donen = "Sipariş (veya siparişler) aktarılamadı.";
            //        return false;
            //    }

            //    return true;
            //}

            //private static int GetSiparisOrtVade(Siparisler Siparis)
            //{
            //    DataTable dt = new DataTable();
            //    SiparislerDetay.GetObjectsBySiparisID(dt, Siparis.pkSiparisID);
            //    decimal vadetoplam = 0;
            //    for (int i = 0; i < dt.Rows.Count; i++)
            //    {
            //        int vade = Urunler.GetProductVade(Convert.ToInt32(dt.Rows[i]["intUrunID"]), Siparis.sintFiyatTipiID);
            //        vadetoplam += Convert.ToInt32(dt.Rows[i]["intMiktar"]) * Convert.ToDecimal(dt.Rows[i]["mnFiyat"]) * vade;
            //    }
            //    decimal siparistoplam = Siparis.mnToplamTutar != 0 ? Siparis.mnToplamTutar : 1;
            //    return Convert.ToInt32(Math.Round(vadetoplam / siparistoplam));
            //}

            //public static string QuantumaYaz(int SiparisID, short IsyeriNo, short AmbarNo, bool BakiyeSiparis, int Sevkref, bool Bakiye, int MusteriID)
            //{
            //    Siparisler sip = Siparisler.GetObjectsBySiparisID(SiparisID);
            //    DataTable dt = new DataTable();
            //    SiparislerDetay.GetObjectsBySiparisID(dt, SiparisID);

            //    int SLSREF = CariHesaplar.GetSLSREFBySMREF(sip.SMREF);
            //    Musteriler siparisiolusturanmusteri1 = Musteriler.GetMusteriByID(sip.intMusteriID);
            //    if (siparisiolusturanmusteri1.tintUyeTipiID == 4 || siparisiolusturanmusteri1.tintUyeTipiID == 6) // satış temsilcisi ise
            //        SLSREF = siparisiolusturanmusteri1.intSLSREF;

            //    string bakiyeaciklama = Bakiye ? "*BKY*" : "";

            //    string[] aciklamalar = sip.strAciklama.Split(new string[] { ";;;" }, StringSplitOptions.None);
            //    string Aciklama2 = bakiyeaciklama + aciklamalar[1];
            //    string Aciklama3 = aciklamalar[2];
            //    DateTime tesltrh = DateTime.Now;
            //    try { tesltrh = Convert.ToDateTime(Aciklama3); } catch (Exception) { }
            //    if (tesltrh < DateTime.Now) tesltrh = DateTime.Now;

            //    SAPsendorderC.ZwebSendSalesOrderService clOrder = new SAPsendorderC.ZwebSendSalesOrderService();
            //    clOrder.Credentials = new System.Net.NetworkCredential("MISTIF", "123456q");
            //    SAPsendorderC.Zwebs010 header = new SAPsendorderC.Zwebs010();

            //    header.Ctype = "SATIS"; //IADE
            //    header.Ketdat = tesltrh.Year.ToString() + (tesltrh.Month.ToString().Length == 1 ? "0" + tesltrh.Month.ToString() : tesltrh.Month.ToString()) + (tesltrh.Day.ToString().Length == 1 ? "0" + tesltrh.Day.ToString() : tesltrh.Day.ToString());
            //    header.Kunwe = "000" + sip.SMREF.ToString();
            //    header.Pltyp = sip.sintFiyatTipiID.ToString().Length == 1 ? "0" + sip.sintFiyatTipiID.ToString() : sip.sintFiyatTipiID.ToString().Length == 3 ? "XX" : sip.sintFiyatTipiID.ToString();
            //    header.Vbeln = "";
            //    header.Xblnr = sip.pkSiparisID.ToString(); //WebGenel.DoUpdateSayac().ToString()
            //    header.Stext = Aciklama2;
            //    header.Zterm = sip.sintFiyatTipiID == 2 ? Convert.ToInt32(TaksitPlanlari.GetOdemePlani(sip.TKSREF).Substring(0, 3).Trim()).ToString() : "";

            //    if (CariHesaplar.GetSATKOD1BySLSREF(SLSREF) == "VE")
            //    {
            //        header.Pernr = SLSREF.ToString();
            //        header.PernrVw = "1530";
            //    }
            //    else if (CariHesaplar.GetSATKOD1BySLSREF(SLSREF) == "VW")
            //    {
            //        header.Pernr = "1529";
            //        header.PernrVw = SLSREF.ToString();
            //    }
            //    else
            //    {
            //        return "Müşterinin sahibi yok";
            //    }

            //    SAPsendorderC.Zwebs011[] line = new SAPsendorderC.Zwebs011[dt.Rows.Count];
            //    for (int i = 0; i < line.Length; i++)
            //    {
            //        line[i] = new SAPsendorderC.Zwebs011();
            //        line[i].Xblnr = sip.pkSiparisID.ToString();
            //        line[i].Itmid = (i + 1).ToString();
            //        line[i].Matnr = "00000000000" + dt.Rows[i]["intUrunID"].ToString();
            //        line[i].Meins = dt.Rows[i]["strMiktarTur"].ToString(); //Urunler.GetProductBirimRef(Convert.ToInt32(dt.Rows[i]["intUrunID"]));
            //        line[i].MengeSpecified = true;
            //        line[i].Menge = Convert.ToDecimal(dt.Rows[i]["intMiktar"]);
            //        line[i].Satir = Urunler.GetProductKampanyaAnaMi(Convert.ToInt32(dt.Rows[i]["intUrunID"])) ? "01" : "00";

            //        if (sip.sintFiyatTipiID == 2)
            //        {
            //            double[] isks = SiparislerDetay.GetObjectISKs(Convert.ToInt64(dt.Rows[i]["pkSiparisDetayID"]));

            //            line[i].FiyatSpecified = true;
            //            line[i].Fiyat = Convert.ToDecimal(isks[10]);
            //            line[i].Isk1Specified = true;
            //            line[i].Isk1 = Convert.ToDecimal(isks[0]);
            //            line[i].Isk2Specified = true;
            //            line[i].Isk2 = Convert.ToDecimal(isks[1]);
            //            line[i].Isk3Specified = true;
            //            line[i].Isk3 = Convert.ToDecimal(isks[2]);
            //            line[i].Isk4Specified = true;
            //            line[i].Isk4 = Convert.ToDecimal(isks[3]);
            //            line[i].Isk5Specified = true;
            //            line[i].Isk5 = Convert.ToDecimal(isks[4]);
            //            line[i].Isk6Specified = true;
            //            line[i].Isk6 = Convert.ToDecimal(isks[5]);
            //            line[i].Isk7Specified = true;
            //            line[i].Isk7 = Convert.ToDecimal(isks[6]);
            //            line[i].Isk8Specified = true;
            //            line[i].Isk8 = Convert.ToDecimal(isks[7]);
            //            line[i].Isk9Specified = true;
            //            line[i].Isk9 = Convert.ToDecimal(isks[8]);
            //            line[i].Isk10Specified = true;
            //            line[i].Isk10 = Convert.ToDecimal(isks[9]);
            //        }
            //    }

            //    string error = string.Empty;
            //    string donen = string.Empty;

            //    SAPsendorderC.Bapiret2[] donen1 = null;
            //    try { donen1 = clOrder.ZwebSendSalesOrder(header, line, out donen); }
            //    catch (Exception ex) { error = ex.Message; }

            //    if (donen1 != null)
            //    {
            //        for (int i = 0; i < donen1.Length; i++)
            //            error += donen1[i].Message + ", ";
            //    }

            //    if (donen != string.Empty)
            //    {
            //        Siparisler.DoInsertQ(sip.pkSiparisID, donen);
            //        error = string.Empty;
            //    }
            //    else
            //    {
            //        Hatalar.DoInsert("Sipariş (" + sip.pkSiparisID.ToString() + ") SAP'a gönderilemedi. " + DateTime.Now.ToString() + " --- Ayrıntı: " + error, "siparisler.aspx Quantumayaz()");
            //        error = "Ayrıntı: <br><br>" + error.Replace("SALES_HEADER_IN işlendi, ", "").Replace("SALES_ITEM_IN işlendi, ", "").Replace("Satış belgesi  değiştirilmedi, ", "").Replace("SALES_ITEM_IN", "").Replace("Teknik eksiklikler", "Ürün kullanım dışındadır. Lütfen ürünü siparişten silerek onaylayınız, ");
            //    }

            //    QuantumWebServisLog.DoInsert(error == string.Empty, sip.pkSiparisID, donen, MusteriID, "", "SATIS");

            //return error;

            return false;
        }
    }
}

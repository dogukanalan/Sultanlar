using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Net;

namespace Sultanlar.DatabaseObject.Internet
{
    class WriteSiparis
    {

    }
    public class Siparis
    {
        public static bool SiparisOnayla(int siparisid, int sevkref, int depoid, bool bakiye, Musteriler musteri, out string Donen)
        {
            Donen = "";
            Siparisler siparis = Siparisler.GetObjectsBySiparisID(siparisid);

            /*if ((CariHesaplar.GetYetkili(siparis.SMREF) == 82965 || CariHesaplar.GetYetkili(siparis.SMREF) == 82966)
                && Ekstreler.GetVgbByGMREF(CariHesaplar.GetGMREFBySMREF(siparis.SMREF)) <= -250)
            {
                Donen = "Bu müşterimizin vadesi geçmiş vgb si bulunmaktadır, bu sebeple sipariş aktarılmayacaktır.";
                return false;
            }*/

            if (siparis.sintFiyatTipiID == 3 && CariHesaplar.GetMtAciklama(siparis.SMREF).IndexOf("TOPTAN") == -1)
            {
                Donen = "Toptancı olmayan bir müşteriye toptan fiyatından sipariş girilemez. Eğer müşteri toptancı ise sistemden müşteri tipi değiştirilmelidir.";
                return false;
            }

            if (depoid != 0)
            {
                siparis.blAktarilmis = true;
                siparis.dtOnaylamaTarihi = DateTime.Now;
                siparis.strAciklama = musteri.strAd + " " + musteri.strSoyad + ";;;" +
                    "Siparişin gönderileceği depo: " + Depolar.GetObject(depoid) + ";;;";
                siparis.DoUpdate();

                // dönüşte bool true ise depoid 0 dan büyük ise bunları çalıştır
                //Session["DepoID"] = null;
                //Session["SiparisTamamlaOnaylaBasildi"] = null;
                //Session["OnaylanacakSiparisID"] = null;
                //divSevkYerleri.Visible = false;
                //Response.Redirect("siparisler.aspx", true);
            }

            bool bakiyesiparis = siparis.sintFiyatTipiID == 12 || siparis.sintFiyatTipiID == 13 ? false : bakiye;



            bool siparisbolundu = false;
            bool bolunenlerdenbiriaktarilamadi = false;


            #region IsyeriOzelKod bölünmesi
            //
            if (siparis.SMREF != 24479 && CariHesaplar.GetGRPBySMREF(siparis.SMREF) != "06" && siparis.sintFiyatTipiID != 9 &&
                siparis.sintFiyatTipiID != 14 /*&& CariHesaplar.GetYTKKODBySMREF(siparis.SMREF) != "Z1"*/)
            {
                DataTable dtIsyeriOzelKodGruplar = new DataTable();
                IsyeriOzelKod.GetObjects2Gruplar(dtIsyeriOzelKodGruplar);

                for (int i = 0; i < dtIsyeriOzelKodGruplar.Rows.Count; i++)
                {
                    DataTable dtSiparistekiUrunler = new DataTable();
                    SiparislerDetay.GetObjectsBySiparisID(dtSiparistekiUrunler, siparisid);

                    DataTable dtIsyeriOzelKod = new DataTable();
                    IsyeriOzelKod.GetObjects2ByGrup(dtIsyeriOzelKod, Convert.ToInt32(dtIsyeriOzelKodGruplar.Rows[i][0]));

                    short isyerino = Convert.ToInt16(dtIsyeriOzelKod.Rows[0]["sintIsyeriKod"]);
                    short ambarno = Convert.ToInt16(dtIsyeriOzelKod.Rows[0]["sintAmbarKod"]);

                    Siparisler yenisiparis =
                        new Siparisler(siparis.intMusteriID, siparis.SMREF, siparis.sintFiyatTipiID, DateTime.Now, 0, false,
                            siparis.TKSREF, DateTime.Now, siparis.strAciklama);
                    ArrayList yenisiparisurunleri = new ArrayList();
                    ArrayList eskisiparisurunleri = new ArrayList();

                    for (int j = 0; j < dtSiparistekiUrunler.Rows.Count; j++)
                    {
                        for (int k = 0; k < dtIsyeriOzelKod.Rows.Count; k++)
                        {
                            string isyeriozelkod = dtIsyeriOzelKod.Rows[k]["strOzelKod"].ToString();
                            string urunozelkod = Urunler.GetProductOzelKod(Convert.ToInt32(dtSiparistekiUrunler.Rows[j]["intUrunID"]));

                            if (urunozelkod == isyeriozelkod)
                            {
                                siparisbolundu = true;
                                yenisiparisurunleri.Add(
                                    new SiparislerDetay(
                                        0,
                                        Convert.ToInt32(dtSiparistekiUrunler.Rows[j]["intUrunID"]),
                                        dtSiparistekiUrunler.Rows[j]["strUrunAdi"].ToString(),
                                        Convert.ToInt32(dtSiparistekiUrunler.Rows[j]["intMiktar"]),
                                        Convert.ToDecimal(dtSiparistekiUrunler.Rows[j]["mnFiyat"]),
                                        Guid.Parse(dtSiparistekiUrunler.Rows[j]["unKampanyaKart"].ToString()),
                                        Convert.ToBoolean(dtSiparistekiUrunler.Rows[j]["blKampanyaHediye"]),
                                        Guid.Parse(dtSiparistekiUrunler.Rows[j]["unKampanyaSatir"].ToString()),
                                        dtSiparistekiUrunler.Rows[j]["strMiktarTur"].ToString()));

                                SiparislerDetay siplerdet = SiparislerDetay.GetObjectBySiparislerDetayID(
                                    Convert.ToInt64(dtSiparistekiUrunler.Rows[j]["pkSiparisDetayID"]));

                                eskisiparisurunleri.Add(siplerdet);

                                siplerdet.DoDelete();
                                siparis.ToplamTutarGuncelle();

                                break;
                            }
                        }
                    }

                    if (yenisiparisurunleri.Count > 0)
                    {
                        yenisiparis.DoInsert();

                        decimal toplamtutar = 0;
                        for (int j = 0; j < yenisiparisurunleri.Count; j++)
                        {
                            SiparislerDetay siplerdet = (SiparislerDetay)yenisiparisurunleri[j];
                            siplerdet.intSiparisID = yenisiparis.pkSiparisID;
                            siplerdet.DoInsert();

                            SiparislerDetay.DoChangeIDISKs(((SiparislerDetay)eskisiparisurunleri[j]).pkSiparisDetayID, siplerdet.pkSiparisDetayID);

                            if (!siplerdet.blKampanyaHediye)
                                toplamtutar += siplerdet.mnFiyat * siplerdet.intMiktar;
                        }
                        yenisiparis.mnToplamTutar = toplamtutar;
                        yenisiparis.DoUpdate();
                        yenisiparis.ToplamTutarGuncelle();

                        //if (!TaksitPlanlari.TaksitMi(siparis.TKSREF))
                        //    yenisiparis.TKSREF = TaksitPlanlari.GetODMREF(GetSiparisOrtVade(yenisiparis));

                        Donen = QuantumaYaz(yenisiparis.pkSiparisID, isyerino, ambarno, bakiyesiparis, sevkref, bakiye, musteri.pkMusteriID);
                        if (Donen == string.Empty)
                        {
                            yenisiparis.blAktarilmis = true;
                            yenisiparis.DoUpdate();
                        }
                        else
                        {
                            bolunenlerdenbiriaktarilamadi = true;
                        }
                    }
                }
            }
            //
            #endregion


            bool vadesiparisaktarilamadi = false;


            DataTable dt = new DataTable();
            SiparislerDetay.GetObjectsBySiparisID(dt, siparis.pkSiparisID);
            if (dt.Rows.Count == 0) // eski siparişte ürün kalmışsa alsat dır
            {
                siparis.DoDelete();
            }
            else
            {
                if (siparisbolundu)
                {
                    decimal toplamtutar = 0;

                    for (int i = 0; i < dt.Rows.Count; i++)
                        if (!Convert.ToBoolean(dt.Rows[i]["blKampanyaHediye"]))
                            toplamtutar += Convert.ToDecimal(dt.Rows[i]["mnFiyat"]) * Convert.ToInt32(dt.Rows[i]["intMiktar"]);

                    siparis.mnToplamTutar = toplamtutar;
                    siparis.DoUpdate();
                    siparis.ToplamTutarGuncelle();
                }


                #region vade bölünmesi


                ArrayList vadeler = new ArrayList();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    int vade = Urunler.GetProductVade(Convert.ToInt32(dt.Rows[i]["intUrunID"]), siparis.sintFiyatTipiID);
                    bool var = false;
                    for (int j = 0; j < vadeler.Count; j++)
                        if (Convert.ToInt32(vadeler[j]) == vade)
                            var = true;

                    if (!var)
                        vadeler.Add(vade);
                }

                if (vadeler.Count == 1) // vadeler hep aynıysa bölme
                {
                    Donen = QuantumaYaz(siparisid, 0, 0, bakiyesiparis, sevkref, bakiye, musteri.pkMusteriID);
                    if (Donen == string.Empty)
                    {
                        siparis.blAktarilmis = true;

                        siparis.dtOnaylamaTarihi = DateTime.Now;
                        siparis.DoUpdate();
                    }
                    else
                    {
                        vadesiparisaktarilamadi = true;
                    }
                }
                else // bölünme
                {
                    for (int i = 0; i < vadeler.Count; i++)
                    {
                        // yeni sipariş oluştur
                        Siparisler yenisiparis = new Siparisler(siparis.intMusteriID, siparis.SMREF, siparis.sintFiyatTipiID, DateTime.Now, 0, false,
                            siparis.TKSREF, DateTime.Now, siparis.strAciklama);
                        yenisiparis.DoInsert();

                        // yeni sipariş kalemlerini vadeden yararlanarak bul
                        ArrayList yenisipariskalemleri = new ArrayList();
                        for (int j = 0; j < dt.Rows.Count; j++)
                        {
                            int vade = Urunler.GetProductVade(Convert.ToInt32(dt.Rows[j]["intUrunID"]), siparis.sintFiyatTipiID);
                            if (Convert.ToInt32(vadeler[i]) == vade)
                            {
                                SiparislerDetay sipdet = SiparislerDetay.GetObjectBySiparislerDetayID(Convert.ToInt64(dt.Rows[j]["pkSiparisDetayID"]));
                                yenisipariskalemleri.Add(new SiparislerDetay(yenisiparis.pkSiparisID, sipdet.intUrunID, sipdet.strUrunAdi, sipdet.intMiktar, sipdet.mnFiyat, sipdet.unKampanyaKart, sipdet.blKampanyaHediye, sipdet.unKampanyaSatir, sipdet.strMiktarTur));
                            }
                        }

                        // bulunan yeni sipariş kalemlerini yeni siparişe ekle
                        decimal toplamtutar = 0;
                        for (int j = 0; j < yenisipariskalemleri.Count; j++)
                        {
                            SiparislerDetay sipdet = ((SiparislerDetay)yenisipariskalemleri[j]);
                            toplamtutar += sipdet.mnFiyat * sipdet.intMiktar;
                            sipdet.DoInsert();
                        }
                        yenisiparis.mnToplamTutar = toplamtutar;

                        if (!TaksitPlanlari.TaksitMi(siparis.TKSREF))
                            yenisiparis.TKSREF = TaksitPlanlari.GetODMREF(Convert.ToInt32(vadeler[i]));

                        yenisiparis.DoUpdate();

                        // yeni siparişi onayla
                        if (QuantumaYaz(yenisiparis.pkSiparisID, 0, 0, bakiyesiparis, sevkref, bakiye, musteri.pkMusteriID) == string.Empty)
                        {
                            yenisiparis.blAktarilmis = true;

                            yenisiparis.dtOnaylamaTarihi = DateTime.Now;
                            yenisiparis.DoUpdate();
                        }
                        else
                        {
                            vadesiparisaktarilamadi = true;
                        }

                        yenisiparis.ToplamTutarGuncelle();
                    }

                    siparis.DoDelete(); // eski siparişte ürün kalmadığından sil
                }


                #endregion


            }



            if (vadesiparisaktarilamadi || bolunenlerdenbiriaktarilamadi)
            {
                // dönüşte false olursa bu div i visible true yap
                //divSiparisOnaylanamadi.Visible = true;
                //Donen = "Sipariş (veya siparişler) aktarılamadı.";
                return false;
            }

            return true;
        }

        private static int GetSiparisOrtVade(Siparisler Siparis)
        {
            DataTable dt = new DataTable();
            SiparislerDetay.GetObjectsBySiparisID(dt, Siparis.pkSiparisID);
            decimal vadetoplam = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int vade = Urunler.GetProductVade(Convert.ToInt32(dt.Rows[i]["intUrunID"]), Siparis.sintFiyatTipiID);
                vadetoplam += Convert.ToInt32(dt.Rows[i]["intMiktar"]) * Convert.ToDecimal(dt.Rows[i]["mnFiyat"]) * vade;
            }
            decimal siparistoplam = Siparis.mnToplamTutar != 0 ? Siparis.mnToplamTutar : 1;
            return Convert.ToInt32(Math.Round(vadetoplam / siparistoplam));
        }

        public static string QuantumaYaz(int SiparisID, short IsyeriNo, short AmbarNo, bool BakiyeSiparis, int Sevkref, bool Bakiye, int MusteriID)
        {
            Siparisler sip = Siparisler.GetObjectsBySiparisID(SiparisID);
            DataTable dt = new DataTable();
            SiparislerDetay.GetObjectsBySiparisID(dt, SiparisID);

            int SMREF = sip.SMREF > 2000000 ? CariHesapZ.GetObject(sip.SMREF, 2, true).GMREF : sip.SMREF;

            int SLSREF = CariHesaplar.GetSLSREFBySMREF(SMREF);
            Musteriler siparisiolusturanmusteri1 = Musteriler.GetMusteriByID(sip.intMusteriID);
            if (siparisiolusturanmusteri1.tintUyeTipiID == 4 || siparisiolusturanmusteri1.tintUyeTipiID == 6) // satış temsilcisi ise
                SLSREF = siparisiolusturanmusteri1.intSLSREF;

            string bakiyeaciklama = Bakiye ? "*BKY*" : "";
            string subeaciklama = sip.SMREF > 2000000 ? "*" + CariHesapZ.GetObject(sip.SMREF, 2, true).SUBE + "*" : "";

            string[] aciklamalar = sip.strAciklama.Split(new string[] { ";;;" }, StringSplitOptions.None);
            string Aciklama2 = bakiyeaciklama + subeaciklama + aciklamalar[1];
            string Aciklama3 = aciklamalar[2];
            DateTime tesltrh = DateTime.Now;
            try { tesltrh = Convert.ToDateTime(Aciklama3); } catch (Exception) { }
            if (tesltrh < DateTime.Now) tesltrh = DateTime.Now;

            SAPsendorderC.ZwebSendSalesOrderService clOrder = new SAPsendorderC.ZwebSendSalesOrderService();
            clOrder.Credentials = new System.Net.NetworkCredential("MISTIF", "Ankara1923*+B");
            SAPsendorderC.Zwebs010 header = new SAPsendorderC.Zwebs010();

            header.Ctype = "SATIS"; //IADE
            header.Ketdat = tesltrh.Year.ToString() + (tesltrh.Month.ToString().Length == 1 ? "0" + tesltrh.Month.ToString() : tesltrh.Month.ToString()) + (tesltrh.Day.ToString().Length == 1 ? "0" + tesltrh.Day.ToString() : tesltrh.Day.ToString());
            header.Kunwe = "000" + SMREF.ToString();
            header.Pltyp = sip.sintFiyatTipiID.ToString().Length == 1 ? "0" + sip.sintFiyatTipiID.ToString() : sip.sintFiyatTipiID.ToString().Length == 3 ? "XX" : sip.sintFiyatTipiID.ToString();
            header.Vbeln = "";
            header.Xblnr = sip.pkSiparisID.ToString(); //WebGenel.DoUpdateSayac().ToString()
            header.Stext = Aciklama2;
            header.Zterm = FiyatlarTP.GetVade(sip.sintFiyatTipiID).ToString(); //sintFiyatTipiID == 2 ? Convert.ToInt32(TaksitPlanlari.GetOdemePlani(sip.TKSREF).Substring(0, 3).Trim()).ToString()

            if (CariHesaplar.GetSATKOD1BySLSREF(SLSREF) == "VE")
            {
                header.Pernr = SLSREF.ToString();
                header.PernrVw = "1530";
            }
            else if (CariHesaplar.GetSATKOD1BySLSREF(SLSREF) == "VW")
            {
                header.Pernr = "1529";
                header.PernrVw = SLSREF.ToString();
            }
            else if (CariHesaplar.GetSATKOD1BySLSREF(SLSREF) == "ZM")
            {
                header.Pernr = CariHesaplar.GetSLSREFBySMREF(SMREF).ToString();
                header.PernrVw = "1530";
            }
            else
            {
                return "Müşterinin sahibi yok";
            }

            SAPsendorderC.Zwebs011[] line = new SAPsendorderC.Zwebs011[dt.Rows.Count];
            for (int i = 0; i < line.Length; i++)
            {
                line[i] = new SAPsendorderC.Zwebs011();
                line[i].Xblnr = sip.pkSiparisID.ToString();
                line[i].Itmid = (i + 1).ToString();
                line[i].Matnr = "00000000000" + dt.Rows[i]["intUrunID"].ToString();
                line[i].Meins = dt.Rows[i]["strMiktarTur"].ToString(); //Urunler.GetProductBirimRef(Convert.ToInt32(dt.Rows[i]["intUrunID"]));
                line[i].MengeSpecified = true;
                line[i].Menge = Convert.ToDecimal(dt.Rows[i]["intMiktar"]);
                line[i].Satir = Urunler.GetProductKampanyaAnaMi(Convert.ToInt32(dt.Rows[i]["intUrunID"])) ? "01" : "00";

                if (sip.sintFiyatTipiID == 2)
                {
                    double[] isks = SiparislerDetay.GetObjectISKs(Convert.ToInt64(dt.Rows[i]["pkSiparisDetayID"]));

                    line[i].FiyatSpecified = true;
                    line[i].Fiyat = Convert.ToDecimal(isks[10]);
                    line[i].Isk1Specified = true;
                    line[i].Isk1 = Convert.ToDecimal(isks[0]);
                    line[i].Isk2Specified = true;
                    line[i].Isk2 = Convert.ToDecimal(isks[1]);
                    line[i].Isk3Specified = true;
                    line[i].Isk3 = Convert.ToDecimal(isks[2]);
                    line[i].Isk4Specified = true;
                    line[i].Isk4 = Convert.ToDecimal(isks[3]);
                    line[i].Isk5Specified = true;
                    line[i].Isk5 = Convert.ToDecimal(isks[4]);
                    line[i].Isk6Specified = true;
                    line[i].Isk6 = Convert.ToDecimal(isks[5]);
                    line[i].Isk7Specified = true;
                    line[i].Isk7 = Convert.ToDecimal(isks[6]);
                    line[i].Isk8Specified = true;
                    line[i].Isk8 = Convert.ToDecimal(isks[7]);
                    line[i].Isk9Specified = true;
                    line[i].Isk9 = Convert.ToDecimal(isks[8]);
                    line[i].Isk10Specified = true;
                    line[i].Isk10 = Convert.ToDecimal(isks[9]);
                }
            }

            string error = string.Empty;
            string donen = string.Empty;

            SAPsendorderC.Bapiret2[] donen1 = null;

            int tekrarcek = 0;
            while (tekrarcek < 10)
            {
                try
                {
                    donen1 = clOrder.ZwebSendSalesOrder(header, line, out donen);
                    tekrarcek = 10;
                }
                catch (Exception ex)
                {
                    if (tekrarcek < 10)
                    {
                        tekrarcek++;
                        System.Threading.Thread.Sleep(3000);
                    }
                    else
                    {
                        error = ex.Message;
                    }
                }
            }

            /*try { donen1 = clOrder.ZwebSendSalesOrder(header, line, out donen); }
            catch (Exception ex) { error = ex.Message; }*/

            if (donen1 != null)
            {
                for (int i = 0; i < donen1.Length; i++)
                    error += donen1[i].Message + ", ";
            }

            if (donen != string.Empty)
            {
                Siparisler.DoInsertQ(sip.pkSiparisID, donen, Bakiye, "");
                error = string.Empty;
            }
            else
            {
                Hatalar.DoInsert("Sipariş (" + sip.pkSiparisID.ToString() + ") SAP'a gönderilemedi. " + DateTime.Now.ToString() + " --- Ayrıntı: " + error, "siparisler.aspx Quantumayaz()");
                error = "Ayrıntı: " + error.Replace("SALES_HEADER_IN işlendi, ", "").Replace("SALES_ITEM_IN işlendi, ", "").Replace("Satış belgesi  değiştirilmedi, ", "").Replace("SALES_ITEM_IN", "").Replace("Teknik eksiklikler", "Ürün kullanım dışındadır. Lütfen ürünü siparişten silerek onaylayınız, ");
            }

            QuantumWebServisLog.DoInsert(error == string.Empty, sip.pkSiparisID, donen, MusteriID, "", "SATIS");

            return error;
        }

        public static string QuantumaYaz(string EntegraNo, int SMREF, string aciklama)
        {
            EntegraSiparis siparis = Entegra.GetSiparis(EntegraNo);
            List<EntegraSatir> satirlar = Entegra.GetSatirlar(EntegraNo);
            DateTime now = DateTime.Now;
            SAPsendorderC.ZwebSendSalesOrderService salesOrderService = new SAPsendorderC.ZwebSendSalesOrderService();
            salesOrderService.Credentials = (ICredentials)new NetworkCredential("MISTIF", "Ankara1923*+B");
            SAPsendorderC.Zwebs010 IsOrderHeader = new SAPsendorderC.Zwebs010();
            IsOrderHeader.Ctype = "SATIS";
            int num = now.Year;
            string str1 = num.ToString();
            num = now.Month;
            string str2;
            if (num.ToString().Length != 1)
            {
                num = now.Month;
                str2 = num.ToString();
            }
            else
            {
                num = now.Month;
                str2 = "0" + num.ToString();
            }
            num = now.Day;
            string str3;
            if (num.ToString().Length != 1)
            {
                num = now.Day;
                str3 = num.ToString();
            }
            else
            {
                num = now.Day;
                str3 = "0" + num.ToString();
            }
            string str4 = str1 + str2 + str3;
            IsOrderHeader.Ketdat = str4;
            IsOrderHeader.Kunwe = "000" + SMREF.ToString();
            IsOrderHeader.Pltyp = "02";
            IsOrderHeader.Vbeln = "";
            IsOrderHeader.Xblnr = EntegraNo;
            IsOrderHeader.Stext = aciklama;
            IsOrderHeader.Zterm = "0080";
            IsOrderHeader.Pernr = "1296";
            IsOrderHeader.PernrVw = "1296";
            SAPsendorderC.Zwebs011[] ItOrderItems = new SAPsendorderC.Zwebs011[satirlar.Count];
            for (int index = 0; index < ItOrderItems.Length; ++index)
            {
                ItOrderItems[index] = new SAPsendorderC.Zwebs011();
                ItOrderItems[index].Xblnr = EntegraNo;
                num = index + 1;
                string str5 = num.ToString();
                ItOrderItems[index].Itmid = str5;
                ItOrderItems[index].Matnr = "00000000000" + satirlar[index].KOD.ToString();
                ItOrderItems[index].Meins = "ST";
                ItOrderItems[index].MengeSpecified = true;
                ItOrderItems[index].Menge = satirlar[index].MIKTAR;
                ItOrderItems[index].Satir = "00";
                ItOrderItems[index].FiyatSpecified = true;
                ItOrderItems[index].Fiyat = Convert.ToDecimal(satirlar[index].FIYAT);
                ItOrderItems[index].Isk1Specified = true;
                ItOrderItems[index].Isk1 = Decimal.Zero;
                ItOrderItems[index].Isk2Specified = true;
                ItOrderItems[index].Isk2 = Decimal.Zero;
                ItOrderItems[index].Isk3Specified = true;
                ItOrderItems[index].Isk3 = Decimal.Zero;
                ItOrderItems[index].Isk4Specified = true;
                ItOrderItems[index].Isk4 = Decimal.Zero;
                ItOrderItems[index].Isk5Specified = true;
                ItOrderItems[index].Isk5 = Decimal.Zero;
                ItOrderItems[index].Isk6Specified = true;
                ItOrderItems[index].Isk6 = Decimal.Zero;
                ItOrderItems[index].Isk7Specified = true;
                ItOrderItems[index].Isk7 = Decimal.Zero;
                ItOrderItems[index].Isk8Specified = true;
                ItOrderItems[index].Isk8 = Decimal.Zero;
                ItOrderItems[index].Isk9Specified = true;
                ItOrderItems[index].Isk9 = Decimal.Zero;
                ItOrderItems[index].Isk10Specified = true;
                ItOrderItems[index].Isk10 = Decimal.Zero;
            }
            string str6 = string.Empty;
            string EvVbeln = string.Empty;
            SAPsendorderC.Bapiret2[] bapiret2Array = null;
            try
            {
                bapiret2Array = salesOrderService.ZwebSendSalesOrder(IsOrderHeader, ItOrderItems, out EvVbeln);
            }
            catch (Exception ex)
            {
                str6 = ex.Message;
            }
            if (bapiret2Array != null)
            {
                for (int index = 0; index < bapiret2Array.Length; ++index)
                    str6 = str6 + bapiret2Array[index].Message + ", ";
            }
            string str7;
            if (EvVbeln != string.Empty)
            {
                Siparisler.DoInsertQ(111, EvVbeln, false, "");
                str7 = string.Empty;
            }
            else
            {
                Hatalar.DoInsert("Entegra Sipariş (" + siparis.SIPARIS_NO + ") SAP'a gönderilemedi. " + DateTime.Now.ToString() + " --- Ayrıntı: " + str6, "siparisler.aspx Quantumayaz()");
                str7 = "Ayrıntı: " + str6.Replace("SALES_HEADER_IN işlendi, ", "").Replace("SALES_ITEM_IN işlendi, ", "").Replace("Satış belgesi  değiştirilmedi, ", "").Replace("SALES_ITEM_IN", "").Replace("Teknik eksiklikler", "Ürün kullanım dışındadır. Lütfen ürünü siparişten silerek onaylayınız, ");
            }
            QuantumWebServisLog.DoInsert(str7 == string.Empty, 111, EvVbeln, 0, "", "SATIS-ENT");
            return EvVbeln;
        }

        public static string QuantumaYaz(string EntegraNo, int SMREF, int ITEMREF, string aciklama)
        {
            EntegraSiparis siparis = Entegra.GetSiparis(EntegraNo);
            EntegraSatir satir = Entegra.GetSatir(EntegraNo, ITEMREF);
            DateTime now = DateTime.Now;
            SAPsendorderC.ZwebSendSalesOrderService salesOrderService = new SAPsendorderC.ZwebSendSalesOrderService();
            salesOrderService.Credentials = (ICredentials)new NetworkCredential("MISTIF", "Ankara1923*+B");
            SAPsendorderC.Zwebs010 IsOrderHeader = new SAPsendorderC.Zwebs010();
            IsOrderHeader.Ctype = "SATIS";
            int num = now.Year;
            string str1 = num.ToString();
            num = now.Month;
            string str2;
            if (num.ToString().Length != 1)
            {
                num = now.Month;
                str2 = num.ToString();
            }
            else
            {
                num = now.Month;
                str2 = "0" + num.ToString();
            }
            num = now.Day;
            string str3;
            if (num.ToString().Length != 1)
            {
                num = now.Day;
                str3 = num.ToString();
            }
            else
            {
                num = now.Day;
                str3 = "0" + num.ToString();
            }
            string str4 = str1 + str2 + str3;
            IsOrderHeader.Ketdat = str4;
            IsOrderHeader.Kunwe = "000" + SMREF.ToString();
            IsOrderHeader.Pltyp = "02";
            IsOrderHeader.Vbeln = "";
            IsOrderHeader.Xblnr = EntegraNo + "_" + ITEMREF.ToString();
            IsOrderHeader.Stext = aciklama;
            IsOrderHeader.Zterm = "0080";
            IsOrderHeader.Pernr = "1296";
            IsOrderHeader.PernrVw = "1296";
            SAPsendorderC.Zwebs011[] ItOrderItems = new SAPsendorderC.Zwebs011[1];
            for (int index = 0; index < ItOrderItems.Length; ++index)
            {
                ItOrderItems[index] = new SAPsendorderC.Zwebs011();
                ItOrderItems[index].Xblnr = EntegraNo + "_" + ITEMREF.ToString();
                num = index + 1;
                string str5 = num.ToString();
                ItOrderItems[index].Itmid = str5;
                ItOrderItems[index].Matnr = "00000000000" + satir.KOD.ToString();
                ItOrderItems[index].Meins = "ST";
                ItOrderItems[index].MengeSpecified = true;
                ItOrderItems[index].Menge = satir.MIKTAR;
                ItOrderItems[index].Satir = "00";
                ItOrderItems[index].FiyatSpecified = true;
                ItOrderItems[index].Fiyat = Convert.ToDecimal(satir.FIYAT);
                ItOrderItems[index].Isk1Specified = true;
                ItOrderItems[index].Isk1 = Decimal.Zero;
                ItOrderItems[index].Isk2Specified = true;
                ItOrderItems[index].Isk2 = Decimal.Zero;
                ItOrderItems[index].Isk3Specified = true;
                ItOrderItems[index].Isk3 = Decimal.Zero;
                ItOrderItems[index].Isk4Specified = true;
                ItOrderItems[index].Isk4 = Decimal.Zero;
                ItOrderItems[index].Isk5Specified = true;
                ItOrderItems[index].Isk5 = Decimal.Zero;
                ItOrderItems[index].Isk6Specified = true;
                ItOrderItems[index].Isk6 = Decimal.Zero;
                ItOrderItems[index].Isk7Specified = true;
                ItOrderItems[index].Isk7 = Decimal.Zero;
                ItOrderItems[index].Isk8Specified = true;
                ItOrderItems[index].Isk8 = Decimal.Zero;
                ItOrderItems[index].Isk9Specified = true;
                ItOrderItems[index].Isk9 = Decimal.Zero;
                ItOrderItems[index].Isk10Specified = true;
                ItOrderItems[index].Isk10 = Decimal.Zero;
            }
            string str6 = string.Empty;
            string EvVbeln = string.Empty;
            SAPsendorderC.Bapiret2[] bapiret2Array = null;
            try
            {
                bapiret2Array = salesOrderService.ZwebSendSalesOrder(IsOrderHeader, ItOrderItems, out EvVbeln);
            }
            catch (Exception ex)
            {
                str6 = ex.Message;
            }
            if (bapiret2Array != null)
            {
                for (int index = 0; index < bapiret2Array.Length; ++index)
                    str6 = str6 + bapiret2Array[index].Message + ", ";
            }
            string str7;
            if (EvVbeln != string.Empty)
            {
                Siparisler.DoInsertQ(111, EvVbeln, false, "");
                str7 = string.Empty;
            }
            else
            {
                Hatalar.DoInsert("Entegra Sipariş (" + siparis.SIPARIS_NO + ") SAP'a gönderilemedi. " + DateTime.Now.ToString() + " --- Ayrıntı: " + str6, "siparisler.aspx Quantumayaz()");
                str7 = "Ayrıntı: " + str6.Replace("SALES_HEADER_IN işlendi, ", "").Replace("SALES_ITEM_IN işlendi, ", "").Replace("Satış belgesi  değiştirilmedi, ", "").Replace("SALES_ITEM_IN", "").Replace("Teknik eksiklikler", "Ürün kullanım dışındadır. Lütfen ürünü siparişten silerek onaylayınız, ");
            }
            QuantumWebServisLog.DoInsert(str7 == string.Empty, 111, EvVbeln, 0, "", "SATIS-ENT");
            return str7;
        }
    }

    public class DisSiparis
    {
        ///// <summary>
        ///// UCZ siparişlerini kontrol edip yeni varsa yazar
        ///// </summary>
        //public void uczSiparisler()
        //{
        //    ArrayList ekleneceknolar = new ArrayList();

        //    UCZ.MAPWebServicesSultanlarTESTPortTypeClient cl = new UCZ.MAPWebServicesSultanlarTESTPortTypeClient();
        //    string cikis = string.Empty;
        //    UCZ.ORDERS[] orders = cl.SultanlarUczOrdersFunction("221133", "", "", "1", out cikis);

        //    for (int i = 0; i < orders.Length; i++)
        //    {
        //        if (!Sultanlar.DatabaseObject.Internet.DisSiparisler.VarMiByDisNo(orders[i].HEADER.OrderNumber))
        //        {
        //            bool var = false;
        //            for (int j = 0; j < ekleneceknolar.Count; j++)
        //            {
        //                if (ekleneceknolar[j].ToString() == orders[i].HEADER.OrderNumber)
        //                {
        //                    var = true;
        //                    break;
        //                }
        //            }

        //            if (!var)
        //                ekleneceknolar.Add(orders[i].HEADER.OrderNumber);
        //        }
        //    }



        //    for (int i = 0; i < ekleneceknolar.Count; i++)
        //    {
        //        Sultanlar.DatabaseObject.Internet.DisSiparisler ds = new DatabaseObject.Internet.DisSiparisler(
        //            3,
        //            "",
        //            0,
        //            ekleneceknolar[i].ToString(),
        //            DateTime.Now,
        //            DateTime.Now,
        //            0,
        //            0,
        //            0,
        //            "", orders[Convert.ToInt32(ekleneceknolar[i])].HEADER.BuyerID, "", "", "", "", "", 0, 0, 0, "", "", "", "", "", "", "", "");
        //        ds.DoInsert();

        //        ArrayList dissiparislerdetay = new ArrayList();

        //        decimal toplamtutar = 0;
        //        int satir = 0;
        //        for (int j = 0; j < orders[i].DETAILS.Length; j++)
        //        {
        //            if (orders[i].HEADER.OrderNumber.StartsWith(ekleneceknolar[i].ToString()))
        //            {
        //                satir++;

        //                decimal tutar = Urunler.GetProductPrice(Convert.ToInt32(orders[i].DETAILS[j].SupplierItemCode), 14) * Convert.ToInt32(orders[i].DETAILS[j].OrderQuantity);
        //                toplamtutar += tutar;
        //                Sultanlar.DatabaseObject.Internet.DisSiparislerDetay dsd = new DisSiparislerDetay(
        //                    ds.pkID,
        //                    satir,
        //                    orders[i].DETAILS[j].BuyerItemCode,
        //                    Convert.ToInt32(orders[i].DETAILS[j].SupplierItemCode),
        //                    orders[i].DETAILS[j].ProdName,
        //                    Convert.ToInt32(orders[i].DETAILS[j].OrderQuantity),
        //                    tutar,
        //                    0,
        //                    true);
        //                dsd.DoInsert();
        //                dissiparislerdetay.Add(dsd);
        //            }
        //        }

        //        ds.mnTutar = toplamtutar;
        //        ds.DoUpdate();

        //        uczQuantumaYaz(ds, dissiparislerdetay);
        //    }
        //}
        ///// <summary>
        ///// hepsiburada siparişlerini kontrol edip yeni varsa yazar
        ///// </summary>
        //public void hbSiparisler()
        //{
        //    ArrayList ekleneceksasnolar = new ArrayList();

        //    hepsiburada.orders osc = new hepsiburada.orders();
        //    hepsiburada.SasItem[] sas = osc.GetOpenOrders("0002004769", "SULTANLAR", "321654");
        //    for (int i = 0; i < sas.Length; i++)
        //    {
        //        if (!Sultanlar.DatabaseObject.Internet.DisSiparisler.VarMiByDisNo(sas[i].SasNo))
        //        {
        //            bool var = false;
        //            for (int j = 0; j < ekleneceksasnolar.Count; j++)
        //            {
        //                if (ekleneceksasnolar[j].ToString() == sas[i].SasNo)
        //                {
        //                    var = true;
        //                    break;
        //                }
        //            }

        //            if (!var)
        //                ekleneceksasnolar.Add(sas[i].SasNo);
        //        }
        //    }



        //    for (int i = 0; i < ekleneceksasnolar.Count; i++)
        //    {
        //        Sultanlar.DatabaseObject.Internet.DisSiparisler ds = new DatabaseObject.Internet.DisSiparisler(
        //            2,
        //            "",
        //            0,
        //            ekleneceksasnolar[i].ToString(),
        //            DateTime.Now,
        //            DateTime.Now,
        //            0,
        //            0,
        //            0,
        //            "", "", "", "", "", "", "", 0, 0, 0, "", "", "", "", "", "", "", "");
        //        ds.DoInsert();

        //        ArrayList dissiparislerdetay = new ArrayList();

        //        decimal toplamtutar = 0;
        //        int satir = 0;
        //        for (int j = 0; j < sas.Length; j++)
        //        {
        //            if (sas[j].SasNo.StartsWith(ekleneceksasnolar[i].ToString()))
        //            {
        //                satir++;

        //                string UrunID = string.Empty;
        //                for (int k = 0; k < sas[j].HBSKU.Length; k++)
        //                {
        //                    if (char.IsDigit(sas[j].HBSKU[k]))
        //                    {
        //                        UrunID += sas[j].HBSKU[k];
        //                    }
        //                }

        //                decimal tutar = Urunler.GetProductPrice(Convert.ToInt32(UrunID), 15) * sas[j].Quantity;
        //                toplamtutar += tutar;
        //                Sultanlar.DatabaseObject.Internet.DisSiparislerDetay dsd = new DisSiparislerDetay(
        //                    ds.pkID,
        //                    satir,
        //                    sas[j].HBSKU,
        //                    Convert.ToInt32(UrunID),
        //                    sas[j].ProductName,
        //                    sas[j].Quantity,
        //                    tutar,
        //                    0,
        //                    true);
        //                dsd.DoInsert();
        //                dissiparislerdetay.Add(dsd);
        //            }
        //        }

        //        ds.mnTutar = toplamtutar;
        //        ds.DoUpdate();

        //        hbQuantumaYaz(ds, dissiparislerdetay);
        //    }
        //}
        ///// <summary>
        ///// n11 siparişlerini kontrol edip yeni varsa yazar
        ///// </summary>
        //public void n11Siparisler()
        //{
        //    XmlDocument XMLresponse = this.GetN11("https://api.n11.com/rest/secure/order/list.xml", "POST", GetN11PostXmlSiparisListesi("NEW").InnerXml);

        //    XmlNodeList nodes = XMLresponse.SelectNodes("//orderList/order/id/text()");
        //    for (int i = 0; i < nodes.Count; i++)
        //        n11SiparisYaz(Convert.ToInt64(nodes[i].Value));
        //}
        ///// <summary>
        ///// n11 siparişini yazar
        ///// </summary>
        ///// <param name="diskod">n11 orderid</param>
        //private void n11SiparisYaz(long diskod)
        //{
        //    XmlDocument XMLresponse = this.GetN11("https://api.n11.com/rest/secure/order/get.xml?appkey=ee8f1e9a-c527-4971-9d43-e14bc6f635fa&appsecret=QnoN1BgndVbnCCiO&id=" + diskod.ToString(), "GET", "");

        //    //XmlNode FaturaTuru = XMLresponse.SelectSingleNode("//order/invoiceType/text()");
        //    XmlNode TC = XMLresponse.SelectSingleNode("//order/citizenshipId/text()");
        //    //XmlNode VergiNo = XMLresponse.SelectSingleNode("//order/buyer/taxId/text()");
        //    //XmlNode VergiDairesi = XMLresponse.SelectSingleNode("//order/buyer/taxOffice/text()");
        //    XmlNode DisKod = XMLresponse.SelectSingleNode("//order/id/text()");
        //    XmlNode DisNo = XMLresponse.SelectSingleNode("//order/orderNumber/text()");
        //    XmlNode DisOlusmaTarihi = XMLresponse.SelectSingleNode("//order/createDate/text()");
        //    XmlNode OdemeTipi = XMLresponse.SelectSingleNode("//order/paymentType/text()");
        //    XmlNode Durum = XMLresponse.SelectSingleNode("//order/status/text()");
        //    //XmlNode Tutar = XMLresponse.SelectSingleNode("//order/totalAmount/text()"); // tahsil edilecek tutarı veriyor o yüzden kargo bedava ise düşük tutar geliyor
        //    XmlNode Eposta = XMLresponse.SelectSingleNode("//order/buyer/email/text()");
        //    XmlNode FaturaAdresi = XMLresponse.SelectSingleNode("//order/billingAddress/address/text()");
        //    XmlNode FaturaSehir = XMLresponse.SelectSingleNode("//order/billingAddress/city/text()");
        //    XmlNode FaturaIlce = XMLresponse.SelectSingleNode("//order/billingAddress/district/text()");
        //    XmlNode FaturaPostaKodu = XMLresponse.SelectSingleNode("//order/billingAddress/postalCode/text()");
        //    XmlNode FaturaAdSoyad = XMLresponse.SelectSingleNode("//order/billingAddress/fullName/text()");
        //    XmlNode FaturaGSM = XMLresponse.SelectSingleNode("//order/billingAddress/gsm/text()");
        //    XmlNode DisMusteriKodu = XMLresponse.SelectSingleNode("//order/buyer/id/text()");
        //    XmlNode KargoKodu = XMLresponse.SelectSingleNode("//item/shipmentInfo/shipmentCode/text()");
        //    XmlNode KargoSirketiKodu = XMLresponse.SelectSingleNode("//item/shipmentInfo/shipmentCompany/id/text()");
        //    XmlNode KargoSirketi = XMLresponse.SelectSingleNode("//item/shipmentInfo/shipmentCompany/name/text()");
        //    XmlNode KargoAdresi = XMLresponse.SelectSingleNode("//order/shippingAddress/address/text()");
        //    XmlNode KargoSehir = XMLresponse.SelectSingleNode("//order/shippingAddress/city/text()");
        //    XmlNode KargoIlce = XMLresponse.SelectSingleNode("//order/shippingAddress/district/text()");
        //    XmlNode KargoPostaKodu = XMLresponse.SelectSingleNode("//order/shippingAddress/postalCode/text()");
        //    XmlNode KargoAdSoyad = XMLresponse.SelectSingleNode("//order/shippingAddress/fullName/text()");
        //    XmlNode KargoGSM = XMLresponse.SelectSingleNode("//order/shippingAddress/gsm/text()");
        //    //XmlNode KargoTakip = XMLresponse.SelectSingleNode("//item/shipmentInfo/trackingNumber/text()");

        //    bool yazildi = false;
        //    int SMREF = 0;
        //    Sultanlar.DatabaseObject.Internet.DisSiparisler ds = null;
        //    if (!Sultanlar.DatabaseObject.Internet.DisSiparisler.VarMiByDisNo(DisNo.Value))
        //    {
        //        ds = new DatabaseObject.Internet.DisSiparisler(
        //            1,
        //            TC == null ? "" : TC.Value,
        //            Convert.ToInt64(DisKod.Value),
        //            DisNo.Value,
        //            Convert.ToDateTime(DisOlusmaTarihi.Value),
        //            DateTime.Now,
        //            Convert.ToInt16(OdemeTipi.Value),
        //            Convert.ToInt16(Durum.Value),
        //            0, //Convert.ToDecimal(Tutar.Value.Replace(".", ","))
        //            Eposta.Value,
        //            FaturaAdresi.Value,
        //            FaturaSehir.Value,
        //            FaturaIlce.Value,
        //            FaturaPostaKodu == null ? "" : FaturaPostaKodu.Value,
        //            StringParcalama.IlkHarfBuyuk(FaturaAdSoyad.Value),
        //            FaturaGSM.Value,
        //            Convert.ToInt64(DisMusteriKodu.Value),
        //            Convert.ToInt64(KargoKodu.Value),
        //            Convert.ToInt64(KargoSirketiKodu.Value),
        //            KargoSirketi.Value,
        //            KargoAdresi.Value,
        //            KargoSehir.Value,
        //            KargoIlce.Value,
        //            KargoPostaKodu == null ? "" : KargoPostaKodu.Value,
        //            StringParcalama.IlkHarfBuyuk(KargoAdSoyad.Value),
        //            KargoGSM.Value,
        //            "");
        //        ds.DoInsert();

        //        decimal tutar = 0;

        //        ArrayList dsps = new ArrayList();

        //        XmlNodeList nodes = XMLresponse.SelectNodes("//order/itemList/item");
        //        for (int i = 0; i < nodes.Count; i++)
        //        {
        //            XmlDocument xd = new XmlDocument();
        //            xd.LoadXml("<root>" + nodes[i].InnerXml + "</root>");

        //            XmlNode detDisKod = xd.SelectSingleNode("//id/text()");
        //            XmlNode detDisUrunKod = xd.SelectSingleNode("//productId/text()");
        //            XmlNode detUrunID = xd.SelectSingleNode("//productSellerCode/text()");
        //            XmlNode detUrun = xd.SelectSingleNode("//productName/text()");
        //            XmlNode detMiktar = xd.SelectSingleNode("//quantity/text()");
        //            XmlNode detTutar = xd.SelectSingleNode("//sellerInvoiceAmount/text()");
        //            XmlNode detDurum = xd.SelectSingleNode("//status/text()");

        //            if (Convert.ToInt16(detDurum.Value) != 8) // satır reddedilmiş değil ise
        //            {
        //                Sultanlar.DatabaseObject.Internet.DisSiparislerDetay dsp = new DatabaseObject.Internet.DisSiparislerDetay(
        //                    ds.pkID,
        //                    Convert.ToInt64(detDisKod.Value),
        //                    detDisUrunKod.Value,
        //                    Convert.ToInt32(detUrunID.Value),
        //                    detUrun.Value,
        //                    Convert.ToInt32(detMiktar.Value),
        //                    Convert.ToDecimal(detTutar.Value) / Convert.ToInt32(detMiktar.Value), //.Replace(".", ",")
        //                    Convert.ToInt16(detDurum.Value),
        //                    false);
        //                dsp.DoInsert();

        //                tutar += Convert.ToDecimal(detTutar.Value); //.Replace(".", ",")

        //                dsps.Add(dsp);
        //            }
        //        }

        //        ds.mnTutar = tutar;
        //        ds.DoUpdate();



        //        DataTable dt = new DataTable();
        //        if (TC != null)
        //            CariHesaplar.GetObjectsByVergiNo(dt, TC.Value);

        //        if (dt.Rows.Count > 0)
        //            SMREF = Convert.ToInt32(dt.Rows[0]["GMREF"]);
        //        else
        //            SMREF = 1007689;

        //        //string qsiparisno = n11QuantumaYaz(ds, dsps, SMREF);
        //        Siparisler.DoInsertQ(1000000000 + ds.pkID, "0");

        //        yazildi = true;
        //    }

        //    if (yazildi) // yazıldı
        //    {
        //        string[] kimlere = { 
        //                               //"mtorun@sultanlar.com.tr", 
        //                               "okar@sultanlar.com.tr", 
        //                               //"zakgul@sultanlar.com.tr", 
        //                               "satis@sultanlar.com.tr", 
        //                               //"musay@sultanlar.com.tr", 
        //                               //"ndizdar@sultanlar.com.tr", 
        //                               "mistif@sultanlar.com.tr" };

        //        if (SMREF == 1007689)
        //        {
        //            Sultanlar.Class.Eposta.EpostaYolla("sultanlar@sultanlar.com.tr", "", kimlere, "Sultanlar Pazarlama A.Ş.", "Yeni N11 Siparişi",
        //                "N11 sitesinden yeni bir sipariş gelmiştir, sipariş SAP'a yazılmamıştır. Sipariş carisi sistemde kayıtlı olmadığından yeni bir şahıs carisi açılmalıdır. <br><br>Cari Hesap Bilgileri:<br><br>" + /*"Fatura Türü: " + FaturaTuru.Value == "1" ? "Bireysel" : "Kurumsal" + */"<br>İsim: " + ds.strFaturaAdSoyad.ToUpper() + "<br>Adres: " + ds.strFaturaAdresi.ToUpper() + "<br>Posta Kodu: " + ds.strFaturaPostaKodu + "<br>Şehir: " + ds.strFaturaSehir.ToUpper() + "<br>İlçe: " + ds.strFaturaIlce.ToUpper() + "<br>Telefon: " + ds.strFaturaGSM + "<br>Eposta: " + ds.strEposta + "<br>TC: " + ds.strTC + /*"<br>Vergi Dairesi: " + VergiDairesi != null ? VergiDairesi.Value : "" + "<br>Vergi No: " + VergiNo != null ? VergiNo.Value : "" + */"<br>");
        //        }
        //        else
        //        {
        //            Sultanlar.Class.Eposta.EpostaYolla("sultanlar@sultanlar.com.tr", "", kimlere, "Sultanlar Pazarlama A.Ş.", "Yeni N11 Siparişi",
        //                "N11 sitesinden yeni bir sipariş gelmiştir, sipariş SAP'a yazılmamıştır. Sipariş carisinin sistemimizde DAHA ÖNCE KAYDI AÇILDIĞINDAN TEKRAR AÇILMAMALIDIR. <br><br>Cari Hesap Bilgileri:<br><br>" + /*"Fatura Türü: " + FaturaTuru.Value == "1" ? "Bireysel" : "Kurumsal" + */"<br>İsim: " + ds.strFaturaAdSoyad.ToUpper() + "<br>Adres: " + ds.strFaturaAdresi.ToUpper() + "<br>Posta Kodu: " + ds.strFaturaPostaKodu + "<br>Şehir: " + ds.strFaturaSehir.ToUpper() + "<br>İlçe: " + ds.strFaturaIlce.ToUpper() + "<br>Telefon: " + ds.strFaturaGSM + "<br>Eposta: " + ds.strEposta + "<br>TC: " + ds.strTC + /*"<br>Vergi Dairesi: " + VergiDairesi != null ? VergiDairesi.Value : "" + "<br>Vergi No: " + VergiNo != null ? VergiNo.Value : "" + */"<br>");
        //        }

        //        //for (int i = 0; i < dsps.Count; i++) // BURAYA BİR KERE GİRMESİ GEREKEBİLİR YANİ BÜTÜN SATIRLARI KABUL GÖNDERMEKTENSE BİR SATIRI KABUL ETTİM DEMEK YETERLİ OLABİLİR
        //        //    n11SiparisiKabulEt(((DisSiparislerDetay)dsps[i]).bintDisKod);
        //    }
        //    else // yazılmadı
        //    {
        //        //ds.DoDelete();
        //        //for (int i = 0; i < dsps.Count; i++)
        //        //    ((DisSiparislerDetay)dsps[i]).DoDelete();
        //    }
        //}
        ///// <summary>
        ///// n11 siparişinin kabul edildiği bilgisini n11 e gönderir
        ///// </summary>
        ///// <param name="id">n11 orderdetailid (det.diskod)</param>
        //private void n11SiparisiKabulEt(long id)
        //{
        //    XmlDocument XMLresponse = this.GetN11("https://api.n11.com/rest/secure/order/acceptOrderItem.xml", "POST", GetN11PostXmlSiparisKabul(id).InnerXml);

        //    if (XMLresponse.SelectSingleNode("response/header/error/text()") == null && XMLresponse.SelectSingleNode("response/header/errorType/text()") != null)
        //    {
        //        Sultanlar.DatabaseObject.Internet.DisSiparislerDetay.DoUpdateKabul(id, true);
        //    }
        //    else
        //    {
        //        Sultanlar.DatabaseObject.Internet.DisSiparislerDetay.DoUpdateKabul(id, false);
        //        Hatalar.DoInsert(XMLresponse.SelectSingleNode("response/header/error/text()") != null ? XMLresponse.SelectSingleNode("response/header/error/text()").Value : "değer dönmedi", "Class dissiparisler n11SiparisiKabulEt");
        //    }
        //}
        ///// <summary>
        ///// n11 siparişinin kabul edilmediği bilgisini n11 e gönderir
        ///// </summary>
        ///// <param name="id">n11 orderdetailid (det.diskod)</param>
        ///// <param name="aciklama">red nedeni</param>
        //private void n11SiparisiRedEt(long id, string aciklama)
        //{
        //    XmlDocument XMLresponse = this.GetN11("https://api.n11.com/rest/secure/order/rejectOrderItem.xml", "POST", GetN11PostXmlSiparisRed(id, aciklama).InnerXml);

        //    if (XMLresponse.SelectSingleNode("response/header/error/text()") == null)
        //        Sultanlar.DatabaseObject.Internet.DisSiparislerDetay.DoUpdateKabul(id, false);
        //    else
        //        Hatalar.DoInsert(XMLresponse.SelectSingleNode("response/header/error/text()") != null ? XMLresponse.SelectSingleNode("response/header/error/text()").Value : "değer dönmedi", "Class dissiparisler n11SiparisiReddet");
        //}
        ///// <summary>
        ///// n11 siparişinin kargo bilgisini n11 e gönderir
        ///// </summary>
        ///// <param name="id">n11 orderdetailid (det.diskod)</param>
        ///// <param name="shippmentmethod">1 kargo, 2 diğer</param>
        ///// <param name="shipmentcompanyid">Ceva Lojistik: 401, MNG: 342, Yurtiçi: 344, Aras: 345, Sürat: 341</param>
        ///// <param name="trackingnumber">takip numarası</param>
        ///// <returns>olumlu,olumsuz</returns>
        //public bool n11KargoyaVer(long id, int shippmentmethod, long shipmentcompanyid, string trackingnumber)
        //{
        //    bool donendeger = false;

        //    DatabaseObject.Internet.DisSiparislerDetay dsd = DatabaseObject.Internet.DisSiparislerDetay.GetObject(id);
        //    DatabaseObject.Internet.DisSiparisler ds = DatabaseObject.Internet.DisSiparisler.GetObject(dsd.intDisSiparisID);

        //    XmlDocument XMLresponse = this.GetN11("https://api.n11.com/rest/secure/order/makeOrderItemShipment.xml", "POST", GetN11PostXmlKargola(id, shippmentmethod, ds.bintKargoKodu, shipmentcompanyid, trackingnumber).InnerXml);

        //    if (XMLresponse.SelectSingleNode("response/header/error/text()") == null)
        //    {
        //        donendeger = true;

        //        dsd.sintDurum = 6;
        //        dsd.DoUpdate();



        //        ds.strKargoTakip = trackingnumber;
        //        ds.bintKargoSirketiKodu = shipmentcompanyid;

        //        if (shipmentcompanyid == 401)
        //            ds.strKargoSirketi = "Ceva Lojistik";
        //        else if (shipmentcompanyid == 342)
        //            ds.strKargoSirketi = "MNG";
        //        else if (shipmentcompanyid == 344)
        //            ds.strKargoSirketi = "Yurtiçi";
        //        else if (shipmentcompanyid == 345)
        //            ds.strKargoSirketi = "Aras";
        //        else if (shipmentcompanyid == 341)
        //            ds.strKargoSirketi = "Sürat";

        //        ds.DoUpdate();
        //    }
        //    else
        //    {
        //        Hatalar.DoInsert(XMLresponse.SelectSingleNode("response/header/error/text()").Value != null ? XMLresponse.SelectSingleNode("response/header/error/text()").Value : "değer dönmedi", "Class dissiparisler n11KargoyaVer");
        //    }

        //    return donendeger;
        //}
        ///// <summary>
        ///// n11 siparişini quantuma yaz, fiyat tipi 16 olarak yazıldı, iskontolar 0
        ///// </summary>
        ///// <param name="dissiparis">DisSiparisler</param>
        ///// <param name="dissiparislerdetaylar">ArrayList DisSiparislerDetay</param>
        ///// <returns>quantum sipariş no</returns>
        //private string n11QuantumaYaz(Sultanlar.DatabaseObject.Internet.DisSiparisler dissiparis, ArrayList dissiparislerdetaylar, int SMREF)
        //{
        //    Guid SiparisRef = Guid.NewGuid();
        //    DataSet ds = new DataSet();
        //    DataTable dtSiparisDetay = new DataTable();
        //    dtSiparisDetay.Columns.Add("LOGICALREF", typeof(Guid));
        //    dtSiparisDetay.Columns.Add("SIPARIS_REF", typeof(Guid));
        //    dtSiparisDetay.Columns.Add("MALZEMEREF", typeof(int));
        //    dtSiparisDetay.Columns.Add("MIKTAR", typeof(double));
        //    dtSiparisDetay.Columns.Add("FIYAT", typeof(double));
        //    dtSiparisDetay.Columns.Add("ISK1", typeof(double));
        //    dtSiparisDetay.Columns.Add("ISK2", typeof(double));
        //    dtSiparisDetay.Columns.Add("ISK3", typeof(double));
        //    dtSiparisDetay.Columns.Add("ISK4", typeof(double));
        //    dtSiparisDetay.Columns.Add("ISK5", typeof(double));
        //    dtSiparisDetay.Columns.Add("ISK6", typeof(double));
        //    dtSiparisDetay.Columns.Add("ISK7", typeof(double));
        //    dtSiparisDetay.Columns.Add("ISK8", typeof(double));
        //    dtSiparisDetay.Columns.Add("ISK9", typeof(double));
        //    dtSiparisDetay.Columns.Add("ISK10", typeof(double));
        //    dtSiparisDetay.Columns.Add("BIRIMREF", typeof(int));
        //    dtSiparisDetay.Columns.Add("KULLANICI_ADI", typeof(string));
        //    /*dtSiparisDetay.Columns.Add("KAYIT_ZAMANI", typeof(DateTime));*/
        //    dtSiparisDetay.Columns.Add("KAMPANYAREF", typeof(Guid));
        //    dtSiparisDetay.Columns.Add("ODEME_GUN", typeof(int));
        //    dtSiparisDetay.Columns.Add("ODEME_TARIH", typeof(DateTime));
        //    dtSiparisDetay.Columns.Add("KDV", typeof(double));
        //    dtSiparisDetay.Columns.Add("SATIR_TIPI", typeof(int));
        //    ds.Tables.Add(dtSiparisDetay);

        //    for (int i = 0; i < dissiparislerdetaylar.Count; i++)
        //    {
        //        DisSiparislerDetay dsp = (DisSiparislerDetay)dissiparislerdetaylar[i];

        //        //double[] fiyatiskonto = Urunler.GetProductDiscountsAndPrice(dsp.intUrunID, 16);

        //        DataRow drow = ds.Tables[0].NewRow();
        //        drow["LOGICALREF"] = Guid.NewGuid();
        //        drow["SIPARIS_REF"] = SiparisRef;
        //        drow["MALZEMEREF"] = dsp.intUrunID;
        //        drow["MIKTAR"] = dsp.intMiktar;
        //        drow["FIYAT"] = (Convert.ToDouble(dsp.mnTutar) * 100) / (100 + Urunler.GetProductKDV(dsp.intUrunID)); //fiyatiskonto[4]
        //        drow["ISK1"] = 0; //fiyatiskonto[0]
        //        drow["ISK2"] = 0; //fiyatiskonto[1]
        //        drow["ISK3"] = 0; //fiyatiskonto[2]
        //        drow["ISK4"] = 0; //fiyatiskonto[3]
        //        drow["ISK5"] = 0;
        //        drow["ISK6"] = 0;
        //        drow["ISK7"] = 0;
        //        drow["ISK8"] = 0;
        //        drow["ISK9"] = 0;
        //        drow["ISK10"] = 0;
        //        drow["BIRIMREF"] = Urunler.GetProductBirimRef(dsp.intUrunID);
        //        drow["KULLANICI_ADI"] = "Web";
        //        drow["KAMPANYAREF"] = Guid.Empty;



        //        int odemegun = Urunler.GetProductOdemeGun(dsp.intUrunID, 16);
        //        if (odemegun > 0)
        //            drow["ODEME_GUN"] = odemegun;
        //        else
        //            drow["ODEME_GUN"] = DBNull.Value;



        //        DateTime odemetarih = Urunler.GetProductOdemeTarih(dsp.intUrunID, 16);
        //        if (odemegun <= 0 && odemetarih != DateTime.MinValue)
        //            drow["ODEME_TARIH"] = odemetarih;
        //        else
        //            drow["ODEME_TARIH"] = DBNull.Value;



        //        drow["KDV"] = Urunler.GetProductKDV(dsp.intUrunID);
        //        drow["SATIR_TIPI"] = 0;



        //        ds.Tables[0].Rows.Add(drow);
        //    }



        //    int SiparisTip = 21102;

        //    int SLSREF = CariHesaplar.GetSLSREFBySMREF(SMREF);
        //    int SEVKREF = 0;

        //    string Aciklama1 = dissiparis.strFaturaAdSoyad;
        //    string Aciklama2 = "N11 Siparişidir";
        //    string Aciklama3 = "";
        //    string Aciklama4 = "Web Sipariş No: " + (1000000000 + dissiparis.pkID).ToString();

        //    string siparisno = WebGenel.DoUpdateSayac().ToString();

        //    Quantum.svcLibraBiz svc = new Quantum.svcLibraBiz();

        //    bool yazildi = false;
        //    try
        //    {
        //        yazildi = svc.WebSiparisYaz_Ambarli
        //            (
        //                SiparisRef.ToString(),
        //                SiparisTip,
        //                SLSREF,
        //                0,
        //                0,
        //                siparisno,
        //                16,
        //                SMREF,
        //                DateTime.Now,
        //                dissiparis.mnTutar, //Convert.ToDecimal(kdvharictoplamtutar),
        //                31, // 30 gün vade
        //                Aciklama1,
        //                Aciklama2,
        //                Aciklama3,
        //                Aciklama4,
        //                SEVKREF,
        //                "Web",
        //                false, //TaksitPlanlari.TaksitMi(31),
        //                "",
        //                false,
        //                ds
        //            );
        //    }
        //    catch (Exception ex)
        //    {
        //        Hatalar.DoInsert(ex, "Class DisSiparisler quantuma yaz");
        //    }

        //    if (yazildi)
        //        Siparisler.DoInsertQ(1000000000 + dissiparis.pkID, siparisno);

        //    QuantumWebServisLog.DoInsert(yazildi, 1000000000 + dissiparis.pkID, siparisno, 0, "SERVERDB01 WinServ.", SiparisTip.ToString());

        //    return yazildi ? siparisno : "";
        //}
        ///// <summary>
        ///// hb siparişini quantuma yaz, fiyat tipi 15 ve fiyatlar 15'den alınacak
        ///// </summary>
        ///// <param name="dissiparis">DisSiparisler</param>
        ///// <param name="dissiparislerdetaylar">ArrayList DisSiparislerDetay</param>
        ///// <returns>quantum sipariş no</returns>
        //private string hbQuantumaYaz(Sultanlar.DatabaseObject.Internet.DisSiparisler dissiparis, ArrayList dissiparislerdetaylar)
        //{
        //    int SMREF = 20202; // d-market

        //    Guid SiparisRef = Guid.NewGuid();
        //    DataSet ds = new DataSet();
        //    DataTable dtSiparisDetay = new DataTable();
        //    dtSiparisDetay.Columns.Add("LOGICALREF", typeof(Guid));
        //    dtSiparisDetay.Columns.Add("SIPARIS_REF", typeof(Guid));
        //    dtSiparisDetay.Columns.Add("MALZEMEREF", typeof(int));
        //    dtSiparisDetay.Columns.Add("MIKTAR", typeof(double));
        //    dtSiparisDetay.Columns.Add("FIYAT", typeof(double));
        //    dtSiparisDetay.Columns.Add("ISK1", typeof(double));
        //    dtSiparisDetay.Columns.Add("ISK2", typeof(double));
        //    dtSiparisDetay.Columns.Add("ISK3", typeof(double));
        //    dtSiparisDetay.Columns.Add("ISK4", typeof(double));
        //    dtSiparisDetay.Columns.Add("ISK5", typeof(double));
        //    dtSiparisDetay.Columns.Add("ISK6", typeof(double));
        //    dtSiparisDetay.Columns.Add("ISK7", typeof(double));
        //    dtSiparisDetay.Columns.Add("ISK8", typeof(double));
        //    dtSiparisDetay.Columns.Add("ISK9", typeof(double));
        //    dtSiparisDetay.Columns.Add("ISK10", typeof(double));
        //    dtSiparisDetay.Columns.Add("BIRIMREF", typeof(int));
        //    dtSiparisDetay.Columns.Add("KULLANICI_ADI", typeof(string));
        //    /*dtSiparisDetay.Columns.Add("KAYIT_ZAMANI", typeof(DateTime));*/
        //    dtSiparisDetay.Columns.Add("KAMPANYAREF", typeof(Guid));
        //    dtSiparisDetay.Columns.Add("ODEME_GUN", typeof(int));
        //    dtSiparisDetay.Columns.Add("ODEME_TARIH", typeof(DateTime));
        //    dtSiparisDetay.Columns.Add("KDV", typeof(double));
        //    dtSiparisDetay.Columns.Add("SATIR_TIPI", typeof(int));
        //    ds.Tables.Add(dtSiparisDetay);

        //    decimal toplamtutar = 0;
        //    for (int i = 0; i < dissiparislerdetaylar.Count; i++)
        //    {
        //        DisSiparislerDetay dsp = (DisSiparislerDetay)dissiparislerdetaylar[i];

        //        double[] fiyatiskonto = Urunler.GetProductDiscountsAndPrice(dsp.intUrunID, 15);

        //        toplamtutar += Convert.ToDecimal(fiyatiskonto[4]) * Convert.ToDecimal((100 + Urunler.GetProductKDV(dsp.intUrunID)) / 100);

        //        DataRow drow = ds.Tables[0].NewRow();
        //        drow["LOGICALREF"] = Guid.NewGuid();
        //        drow["SIPARIS_REF"] = SiparisRef;
        //        drow["MALZEMEREF"] = dsp.intUrunID;
        //        drow["MIKTAR"] = dsp.intMiktar;
        //        drow["FIYAT"] = fiyatiskonto[4];
        //        drow["ISK1"] = fiyatiskonto[0];
        //        drow["ISK2"] = fiyatiskonto[1];
        //        drow["ISK3"] = fiyatiskonto[2];
        //        drow["ISK4"] = fiyatiskonto[3];
        //        drow["ISK5"] = fiyatiskonto[5];
        //        drow["ISK6"] = fiyatiskonto[6];
        //        drow["ISK7"] = fiyatiskonto[7];
        //        drow["ISK8"] = fiyatiskonto[8];
        //        drow["ISK9"] = fiyatiskonto[9];
        //        drow["ISK10"] = fiyatiskonto[10];
        //        drow["BIRIMREF"] = Urunler.GetProductBirimRef(dsp.intUrunID);
        //        drow["KULLANICI_ADI"] = "Web";
        //        drow["KAMPANYAREF"] = Guid.Empty;



        //        int odemegun = Urunler.GetProductOdemeGun(dsp.intUrunID, 15);
        //        if (odemegun > 0)
        //            drow["ODEME_GUN"] = odemegun;
        //        else
        //            drow["ODEME_GUN"] = DBNull.Value;



        //        DateTime odemetarih = Urunler.GetProductOdemeTarih(dsp.intUrunID, 15);
        //        if (odemegun <= 0 && odemetarih != DateTime.MinValue)
        //            drow["ODEME_TARIH"] = odemetarih;
        //        else
        //            drow["ODEME_TARIH"] = DBNull.Value;



        //        drow["KDV"] = Urunler.GetProductKDV(dsp.intUrunID);
        //        drow["SATIR_TIPI"] = 0;



        //        ds.Tables[0].Rows.Add(drow);
        //    }



        //    int SiparisTip = 21102;

        //    int SLSREF = CariHesaplar.GetSLSREFBySMREF(SMREF);
        //    int SEVKREF = 0;

        //    string Aciklama1 = "";
        //    string Aciklama2 = "hb Siparişidir";
        //    string Aciklama3 = "";
        //    string Aciklama4 = "Web Sipariş No: " + (1000000000 + dissiparis.pkID).ToString();

        //    string siparisno = WebGenel.DoUpdateSayac().ToString();

        //    Quantum.svcLibraBiz svc = new Quantum.svcLibraBiz();

        //    bool yazildi = false;
        //    try
        //    {
        //        yazildi = svc.WebSiparisYaz_Ambarli
        //            (
        //                SiparisRef.ToString(),
        //                SiparisTip,
        //                SLSREF,
        //                0,
        //                0,
        //                siparisno,
        //                15,
        //                SMREF,
        //                DateTime.Now,
        //                toplamtutar,
        //                61, // 60 gün vade
        //                Aciklama1,
        //                Aciklama2,
        //                Aciklama3,
        //                Aciklama4,
        //                SEVKREF,
        //                "Web",
        //                false, //TaksitPlanlari.TaksitMi(31),
        //                "",
        //                false,
        //                ds
        //            );
        //    }
        //    catch (Exception ex)
        //    {
        //        Hatalar.DoInsert(ex, "Class DisSiparisler quantuma yaz");
        //    }

        //    if (yazildi)
        //        Siparisler.DoInsertQ(1000000000 + dissiparis.pkID, siparisno);

        //    QuantumWebServisLog.DoInsert(yazildi, 1000000000 + dissiparis.pkID, siparisno, 0, "SERVERDB01 WinServ.", SiparisTip.ToString());

        //    return yazildi ? siparisno : "";
        //}
        ///// <summary>
        ///// ucz siparişini quantuma yaz, fiyat tipi 14 ve fiyatlar 14'ten alınacak
        ///// </summary>
        ///// <param name="ds"></param>
        ///// <param name="dissiparislerdetay"></param>
        //private string uczQuantumaYaz(DatabaseObject.Internet.DisSiparisler dissiparis, ArrayList dissiparislerdetaylar)
        //{
        //    int SMREF = 69348; // ucz

        //    Guid SiparisRef = Guid.NewGuid();
        //    DataSet ds = new DataSet();
        //    DataTable dtSiparisDetay = new DataTable();
        //    dtSiparisDetay.Columns.Add("LOGICALREF", typeof(Guid));
        //    dtSiparisDetay.Columns.Add("SIPARIS_REF", typeof(Guid));
        //    dtSiparisDetay.Columns.Add("MALZEMEREF", typeof(int));
        //    dtSiparisDetay.Columns.Add("MIKTAR", typeof(double));
        //    dtSiparisDetay.Columns.Add("FIYAT", typeof(double));
        //    dtSiparisDetay.Columns.Add("ISK1", typeof(double));
        //    dtSiparisDetay.Columns.Add("ISK2", typeof(double));
        //    dtSiparisDetay.Columns.Add("ISK3", typeof(double));
        //    dtSiparisDetay.Columns.Add("ISK4", typeof(double));
        //    dtSiparisDetay.Columns.Add("ISK5", typeof(double));
        //    dtSiparisDetay.Columns.Add("ISK6", typeof(double));
        //    dtSiparisDetay.Columns.Add("ISK7", typeof(double));
        //    dtSiparisDetay.Columns.Add("ISK8", typeof(double));
        //    dtSiparisDetay.Columns.Add("ISK9", typeof(double));
        //    dtSiparisDetay.Columns.Add("ISK10", typeof(double));
        //    dtSiparisDetay.Columns.Add("BIRIMREF", typeof(int));
        //    dtSiparisDetay.Columns.Add("KULLANICI_ADI", typeof(string));
        //    /*dtSiparisDetay.Columns.Add("KAYIT_ZAMANI", typeof(DateTime));*/
        //    dtSiparisDetay.Columns.Add("KAMPANYAREF", typeof(Guid));
        //    dtSiparisDetay.Columns.Add("ODEME_GUN", typeof(int));
        //    dtSiparisDetay.Columns.Add("ODEME_TARIH", typeof(DateTime));
        //    dtSiparisDetay.Columns.Add("KDV", typeof(double));
        //    dtSiparisDetay.Columns.Add("SATIR_TIPI", typeof(int));
        //    ds.Tables.Add(dtSiparisDetay);

        //    decimal toplamtutar = 0;
        //    for (int i = 0; i < dissiparislerdetaylar.Count; i++)
        //    {
        //        DisSiparislerDetay dsp = (DisSiparislerDetay)dissiparislerdetaylar[i];

        //        double[] fiyatiskonto = Urunler.GetProductDiscountsAndPrice(dsp.intUrunID, 14);

        //        toplamtutar += Convert.ToDecimal(fiyatiskonto[4]) * Convert.ToDecimal((100 + Urunler.GetProductKDV(dsp.intUrunID)) / 100);

        //        DataRow drow = ds.Tables[0].NewRow();
        //        drow["LOGICALREF"] = Guid.NewGuid();
        //        drow["SIPARIS_REF"] = SiparisRef;
        //        drow["MALZEMEREF"] = dsp.intUrunID;
        //        drow["MIKTAR"] = dsp.intMiktar;
        //        drow["FIYAT"] = fiyatiskonto[4];
        //        drow["ISK1"] = fiyatiskonto[0];
        //        drow["ISK2"] = fiyatiskonto[1];
        //        drow["ISK3"] = fiyatiskonto[2];
        //        drow["ISK4"] = fiyatiskonto[3];
        //        drow["ISK5"] = fiyatiskonto[5];
        //        drow["ISK6"] = fiyatiskonto[6];
        //        drow["ISK7"] = fiyatiskonto[7];
        //        drow["ISK8"] = fiyatiskonto[8];
        //        drow["ISK9"] = fiyatiskonto[9];
        //        drow["ISK10"] = fiyatiskonto[10];
        //        drow["BIRIMREF"] = Urunler.GetProductBirimRef(dsp.intUrunID);
        //        drow["KULLANICI_ADI"] = "Web";
        //        drow["KAMPANYAREF"] = Guid.Empty;



        //        int odemegun = Urunler.GetProductOdemeGun(dsp.intUrunID, 14);
        //        if (odemegun > 0)
        //            drow["ODEME_GUN"] = odemegun;
        //        else
        //            drow["ODEME_GUN"] = DBNull.Value;



        //        DateTime odemetarih = Urunler.GetProductOdemeTarih(dsp.intUrunID, 14);
        //        if (odemegun <= 0 && odemetarih != DateTime.MinValue)
        //            drow["ODEME_TARIH"] = odemetarih;
        //        else
        //            drow["ODEME_TARIH"] = DBNull.Value;



        //        drow["KDV"] = Urunler.GetProductKDV(dsp.intUrunID);
        //        drow["SATIR_TIPI"] = 0;



        //        ds.Tables[0].Rows.Add(drow);
        //    }



        //    int SiparisTip = 21102;

        //    int SLSREF = CariHesaplar.GetSLSREFBySMREF(SMREF);
        //    int SEVKREF = Convert.ToInt32(dissiparis.strFaturaAdresi); // fatura adresine sevk sube no su yazılıyor

        //    string Aciklama1 = "";
        //    string Aciklama2 = "ucz Siparişidir";
        //    string Aciklama3 = "";
        //    string Aciklama4 = "Web Sipariş No: " + (1000000000 + dissiparis.pkID).ToString();

        //    string siparisno = WebGenel.DoUpdateSayac().ToString();

        //    Quantum.svcLibraBiz svc = new Quantum.svcLibraBiz();

        //    bool yazildi = false;
        //    try
        //    {
        //        yazildi = svc.WebSiparisYaz_Ambarli
        //            (
        //                SiparisRef.ToString(),
        //                SiparisTip,
        //                SLSREF,
        //                0,
        //                0,
        //                siparisno,
        //                14,
        //                SMREF,
        //                DateTime.Now,
        //                toplamtutar,
        //                76, // 75 gün vade
        //                Aciklama1,
        //                Aciklama2,
        //                Aciklama3,
        //                Aciklama4,
        //                SEVKREF,
        //                "Web",
        //                false, //TaksitPlanlari.TaksitMi(31),
        //                "",
        //                false,
        //                ds
        //            );
        //    }
        //    catch (Exception ex)
        //    {
        //        Hatalar.DoInsert(ex, "Class DisSiparisler quantuma yaz");
        //    }

        //    if (yazildi)
        //        Siparisler.DoInsertQ(1000000000 + dissiparis.pkID, siparisno);

        //    QuantumWebServisLog.DoInsert(yazildi, 1000000000 + dissiparis.pkID, siparisno, 0, "SERVERDB01 WinServ.", SiparisTip.ToString());

        //    return yazildi ? siparisno : "";
        //}











        ///// <summary>
        ///// n11 uyumlu sipariş listesi için request post xml i
        ///// </summary>
        ///// <param name="status">NEW,APPROVED,REJECTED,SHIPPED,DELIVERED,COMPLETED</param>
        ///// <returns>xml</returns>
        //private XmlDocument GetN11PostXmlSiparisListesi(string status)
        //{
        //    XmlDocument donendeger = new XmlDocument();
        //    XmlNode xd = donendeger.CreateXmlDeclaration("1.0", "UTF-8", "yes");
        //    donendeger.AppendChild(xd);

        //    XmlNode xe = donendeger.CreateElement("order");
        //    donendeger.AppendChild(xe);

        //    XmlElement xe0 = donendeger.CreateElement("productId");
        //    donendeger.DocumentElement.InsertAfter(xe0, donendeger.DocumentElement.LastChild);

        //    XmlElement xe1 = donendeger.CreateElement("status"); xe1.InnerText = status;
        //    donendeger.DocumentElement.InsertAfter(xe1, donendeger.DocumentElement.LastChild);

        //    XmlElement xe2 = donendeger.CreateElement("buyerName");
        //    donendeger.DocumentElement.InsertAfter(xe2, donendeger.DocumentElement.LastChild);

        //    XmlElement xe3 = donendeger.CreateElement("orderNumber");
        //    donendeger.DocumentElement.InsertAfter(xe3, donendeger.DocumentElement.LastChild);

        //    XmlElement xe4 = donendeger.CreateElement("productSellerCode");
        //    donendeger.DocumentElement.InsertAfter(xe4, donendeger.DocumentElement.LastChild);

        //    XmlElement xe5 = donendeger.CreateElement("receipient");
        //    donendeger.DocumentElement.InsertAfter(xe5, donendeger.DocumentElement.LastChild);

        //    XmlElement xe6 = donendeger.CreateElement("period");
        //    donendeger.DocumentElement.InsertAfter(xe6, donendeger.DocumentElement.LastChild);

        //    XmlElement xe7 = donendeger.CreateElement("startDate");
        //    xe6.InsertAfter(xe7, xe6.LastChild);

        //    XmlElement xe8 = donendeger.CreateElement("endDate");
        //    xe6.InsertAfter(xe8, xe6.LastChild);

        //    return donendeger;
        //}
        ///// <summary>
        ///// n11 uyumlu sipariş kabul için request post xml i
        ///// </summary>
        ///// <param name="id">n11 orderdetailid (det.diskod)</param>
        ///// <returns>xml</returns>
        //public XmlDocument GetN11PostXmlSiparisKabul(long id)
        //{
        //    XmlDocument donendeger = new XmlDocument();
        //    XmlNode xd = donendeger.CreateXmlDeclaration("1.0", "UTF-8", "yes");
        //    donendeger.AppendChild(xd);

        //    XmlNode xe = donendeger.CreateElement("orderItemDataList");
        //    donendeger.AppendChild(xe);

        //    XmlElement xe00 = donendeger.CreateElement("orderItemList");
        //    donendeger.DocumentElement.InsertAfter(xe00, donendeger.DocumentElement.LastChild);

        //    XmlElement xe0 = donendeger.CreateElement("orderItem");
        //    xe00.InsertAfter(xe0, xe00.LastChild);

        //    XmlElement xe1 = donendeger.CreateElement("id"); xe1.InnerText = id.ToString();
        //    xe0.InsertAfter(xe1, xe0.LastChild);

        //    return donendeger;
        //}
        ///// <summary>
        ///// n11 uyumlu sipariş red için request post xml i
        ///// </summary>
        ///// <param name="id">n11 orderdetailid (det.diskod)</param>
        ///// <returns>xml</returns>
        //public XmlDocument GetN11PostXmlSiparisRed(long id, string aciklama)
        //{
        //    XmlDocument donendeger = new XmlDocument();
        //    XmlNode xd = donendeger.CreateXmlDeclaration("1.0", "UTF-8", "yes");
        //    donendeger.AppendChild(xd);

        //    XmlNode xe = donendeger.CreateElement("orderItemDataList");
        //    donendeger.AppendChild(xe);

        //    XmlElement xe00 = donendeger.CreateElement("orderItemList");
        //    donendeger.DocumentElement.InsertAfter(xe00, donendeger.DocumentElement.LastChild);

        //    XmlElement xe0 = donendeger.CreateElement("orderItem");
        //    xe00.InsertAfter(xe0, xe00.LastChild);

        //    XmlElement xe1 = donendeger.CreateElement("id"); xe1.InnerText = id.ToString();
        //    xe0.InsertAfter(xe1, xe0.LastChild);

        //    XmlElement xe2 = donendeger.CreateElement("rejectReason"); xe2.InnerText = aciklama;
        //    xe0.InsertAfter(xe2, xe0.LastChild);

        //    return donendeger;
        //}
        ///// <summary>
        ///// n11 siparişi kalemini kargoya vermek için request post xml i
        ///// </summary>
        ///// <param name="id">n11 orderdetailid (det.diskod)</param>
        ///// <param name="shippmentmethod">1 kargo, 2 diğer</param>
        ///// <param name="shipmentcode">siparişe (dissiparis) yazılan kargo kodu</param>
        ///// <param name="shipmentcompanyid">ceva loj: 401</param>
        ///// <param name="trackingnumber">takip numarası</param>
        ///// <returns>xml</returns>
        //private XmlDocument GetN11PostXmlKargola(long id, int shippmentmethod, long shipmentcode, long shipmentcompanyid, string trackingnumber)
        //{
        //    XmlDocument donendeger = new XmlDocument();
        //    XmlNode xd = donendeger.CreateXmlDeclaration("1.0", "UTF-8", "yes");
        //    donendeger.AppendChild(xd);

        //    XmlNode xe = donendeger.CreateElement("orderItemDataList");
        //    donendeger.AppendChild(xe);

        //    XmlElement xe00 = donendeger.CreateElement("orderItemList");
        //    donendeger.DocumentElement.InsertAfter(xe00, donendeger.DocumentElement.LastChild);

        //    XmlElement xe0 = donendeger.CreateElement("orderItem");
        //    xe00.InsertAfter(xe0, xe00.LastChild);

        //    XmlElement xe1 = donendeger.CreateElement("id"); xe1.InnerText = id.ToString();
        //    xe0.InsertAfter(xe1, xe0.LastChild);

        //    XmlElement xe2 = donendeger.CreateElement("shipmentInfo");
        //    xe0.InsertAfter(xe2, xe0.LastChild);

        //    XmlElement xe3 = donendeger.CreateElement("shipmentMethod"); xe3.InnerText = shippmentmethod.ToString();
        //    xe2.InsertAfter(xe3, xe2.LastChild);

        //    XmlElement xe4 = donendeger.CreateElement("shipmentCode"); xe4.InnerText = shipmentcode.ToString();
        //    xe2.InsertAfter(xe4, xe2.LastChild);

        //    XmlElement xe5 = donendeger.CreateElement("shipmentCompany");
        //    xe2.InsertAfter(xe5, xe2.LastChild);

        //    XmlElement xe6 = donendeger.CreateElement("id"); xe6.InnerText = shipmentcompanyid.ToString();
        //    xe5.InsertAfter(xe6, xe5.LastChild);

        //    XmlElement xe7 = donendeger.CreateElement("trackingNumber"); xe7.InnerText = trackingnumber;
        //    xe2.InsertAfter(xe7, xe2.LastChild);

        //    XmlElement xe8 = donendeger.CreateElement("campaignNumber");
        //    xe2.InsertAfter(xe8, xe2.LastChild);

        //    return donendeger;
        //}
        ///// <summary>
        ///// Get data from n11 api's
        ///// </summary>
        ///// <param name="uri">url</param>
        ///// <param name="method">GET,POST</param>
        ///// <param name="requestxml">method GET ise bu alan kullanılmıyor</param>
        ///// <returns></returns>
        //private XmlDocument GetN11(string uri, string method, string requestxml)
        //{
        //    HttpWebRequest req = (HttpWebRequest)WebRequest.Create(uri);
        //    req.Method = method;

        //    if (method == "POST")
        //    {
        //        string bound = "----------" + DateTime.Now.Ticks.ToString("x");
        //        req.ContentType = "multipart/form-data; boundary=" + bound;
        //        req.SendChunked = true;
        //        bound = "--" + bound;

        //        string appkey = "Content-Disposition: form-data; name=\"appkey\"\r\nContent-Type=text/plain\r\n\r\nee8f1e9a-c527-4971-9d43-e14bc6f635fa";
        //        string appsecret = "Content-Disposition: form-data; name=\"appsecret\"\r\nContent-Type=text/plain\r\n\r\nQnoN1BgndVbnCCiO";
        //        string XML = "Content-Disposition: form-data; name=\"data\"\r\nContent-Type: application/xml; charset=UTF-8\r\n\r\n" + requestxml;

        //        string data1 = bound + "\r\n" + appkey + "\r\n" + bound + "\r\n" + appsecret + "\r\n" + bound + "\r\n" + XML + "\r\n" + bound;
        //        byte[] data = Encoding.ASCII.GetBytes(data1);
        //        req.ContentLength = data.Length;

        //        using (Stream os = req.GetRequestStream())
        //            os.Write(data, 0, data.Length);
        //    }

        //    WebResponse resp = req.GetResponse();
        //    StreamReader sr = new StreamReader(resp.GetResponseStream());

        //    XmlDocument XMLresponse = new XmlDocument();
        //    XMLresponse.Load(sr.BaseStream);

        //    return XMLresponse;
        //}
    }
}

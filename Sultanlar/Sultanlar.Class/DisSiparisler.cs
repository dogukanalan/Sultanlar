using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Xml;
using System.Collections;
using System.Data;

namespace Sultanlar.Class
{
    public class DisSiparisler
    {
        /// <summary>
        /// UCZ siparişlerini kontrol edip yeni varsa yazar
        /// </summary>
        public void uczSiparisler()
        {
            /*ArrayList ekleneceknolar = new ArrayList();

            UCZ.MAPWebServicesSultanlarTESTPortTypeClient cl = new UCZ.MAPWebServicesSultanlarTESTPortTypeClient();
            string cikis = string.Empty;
            UCZ.ORDERS[] orders = cl.SultanlarUczOrdersFunction("221133", "", "", "1", out cikis);

            for (int i = 0; i < orders.Length; i++)
            {
                if (!Sultanlar.DatabaseObject.Internet.DisSiparisler.VarMiByDisNo(orders[i].HEADER.OrderNumber))
                {
                    bool var = false;
                    for (int j = 0; j < ekleneceknolar.Count; j++)
                    {
                        if (ekleneceknolar[j].ToString() == orders[i].HEADER.OrderNumber)
                        {
                            var = true;
                            break;
                        }
                    }

                    if (!var)
                        ekleneceknolar.Add(orders[i].HEADER.OrderNumber);
                }
            }



            for (int i = 0; i < ekleneceknolar.Count; i++)
            {
                Sultanlar.DatabaseObject.Internet.DisSiparisler ds = new DatabaseObject.Internet.DisSiparisler(
                    3,
                    "",
                    0,
                    ekleneceknolar[i].ToString(),
                    DateTime.Now,
                    DateTime.Now,
                    0,
                    0,
                    0,
                    "", orders[Convert.ToInt32(ekleneceknolar[i])].HEADER.BuyerID, "", "", "", "", "", 0, 0, 0, "", "", "", "", "", "", "", "");
                ds.DoInsert();

                ArrayList dissiparislerdetay = new ArrayList();

                decimal toplamtutar = 0;
                int satir = 0;
                for (int j = 0; j < orders[i].DETAILS.Length; j++)
                {
                    if (orders[i].HEADER.OrderNumber.StartsWith(ekleneceknolar[i].ToString()))
                    {
                        satir++;

                        decimal tutar = Urunler.GetProductPrice(Convert.ToInt32(orders[i].DETAILS[j].SupplierItemCode), 14) * Convert.ToInt32(orders[i].DETAILS[j].OrderQuantity);
                        toplamtutar += tutar;
                        Sultanlar.DatabaseObject.Internet.DisSiparislerDetay dsd = new DisSiparislerDetay(
                            ds.pkID,
                            satir,
                            orders[i].DETAILS[j].BuyerItemCode,
                            Convert.ToInt32(orders[i].DETAILS[j].SupplierItemCode),
                            orders[i].DETAILS[j].ProdName,
                            Convert.ToInt32(orders[i].DETAILS[j].OrderQuantity),
                            tutar,
                            0,
                            true);
                        dsd.DoInsert();
                        dissiparislerdetay.Add(dsd);
                    }
                }

                ds.mnTutar = toplamtutar;
                ds.DoUpdate();

                uczQuantumaYaz(ds, dissiparislerdetay);
            }*/
        }
        /// <summary>
        /// hepsiburada siparişlerini kontrol edip yeni varsa yazar
        /// </summary>
        public void hbSiparisler()
        {
            /*ArrayList ekleneceksasnolar = new ArrayList();

            hepsiburada.orders osc = new hepsiburada.orders();
            hepsiburada.SasItem[] sas = osc.GetOpenOrders("0002004769", "SULTANLAR", "321654");
            for (int i = 0; i < sas.Length; i++)
            {
                if (!Sultanlar.DatabaseObject.Internet.DisSiparisler.VarMiByDisNo(sas[i].SasNo))
                {
                    bool var = false;
                    for (int j = 0; j < ekleneceksasnolar.Count; j++)
                    {
                        if (ekleneceksasnolar[j].ToString() == sas[i].SasNo)
                        {
                            var = true;
                            break;
                        }
                    }

                    if (!var)
                        ekleneceksasnolar.Add(sas[i].SasNo);
                }
            }



            for (int i = 0; i < ekleneceksasnolar.Count; i++)
            {
                Sultanlar.DatabaseObject.Internet.DisSiparisler ds = new DatabaseObject.Internet.DisSiparisler(
                    2,
                    "",
                    0,
                    ekleneceksasnolar[i].ToString(),
                    DateTime.Now,
                    DateTime.Now,
                    0,
                    0,
                    0,
                    "", "", "", "", "", "", "", 0, 0, 0, "", "", "", "", "", "", "", "");
                ds.DoInsert();

                ArrayList dissiparislerdetay = new ArrayList();

                decimal toplamtutar = 0;
                int satir = 0;
                for (int j = 0; j < sas.Length; j++)
                {
                    if (sas[j].SasNo.StartsWith(ekleneceksasnolar[i].ToString()))
                    {
                        satir++;

                        string UrunID = string.Empty;
                        for (int k = 0; k < sas[j].HBSKU.Length; k++)
                        {
                            if (char.IsDigit(sas[j].HBSKU[k]))
                            {
                                UrunID += sas[j].HBSKU[k];
                            }
                        }

                        decimal tutar = Urunler.GetProductPrice(Convert.ToInt32(UrunID), 15) * sas[j].Quantity;
                        toplamtutar += tutar;
                        Sultanlar.DatabaseObject.Internet.DisSiparislerDetay dsd = new DisSiparislerDetay(
                            ds.pkID,
                            satir,
                            sas[j].HBSKU,
                            Convert.ToInt32(UrunID),
                            sas[j].ProductName,
                            sas[j].Quantity,
                            tutar,
                            0,
                            true);
                        dsd.DoInsert();
                        dissiparislerdetay.Add(dsd);
                    }
                }

                ds.mnTutar = toplamtutar;
                ds.DoUpdate();

                hbQuantumaYaz(ds, dissiparislerdetay);
            }*/
        }
        /// <summary>
        /// n11 siparişlerini kontrol edip yeni varsa yazar
        /// </summary>
        public void n11Siparisler()
        {
            /*XmlDocument XMLresponse = this.GetN11("https://api.n11.com/rest/secure/order/list.xml", "POST", GetN11PostXmlSiparisListesi("NEW").InnerXml);

            XmlNodeList nodes = XMLresponse.SelectNodes("//orderList/order/id/text()");
            for (int i = 0; i < nodes.Count; i++)
                n11SiparisYaz(Convert.ToInt64(nodes[i].Value));*/
        }
        /// <summary>
        /// n11 siparişini yazar
        /// </summary>
        /// <param name="diskod">n11 orderid</param>
        private void n11SiparisYaz(long diskod)
        {
            //XmlDocument XMLresponse = this.GetN11("https://api.n11.com/rest/secure/order/get.xml?appkey=ee8f1e9a-c527-4971-9d43-e14bc6f635fa&appsecret=QnoN1BgndVbnCCiO&id=" + diskod.ToString(), "GET", "");

            ////XmlNode FaturaTuru = XMLresponse.SelectSingleNode("//order/invoiceType/text()");
            //XmlNode TC = XMLresponse.SelectSingleNode("//order/citizenshipId/text()");
            ////XmlNode VergiNo = XMLresponse.SelectSingleNode("//order/buyer/taxId/text()");
            ////XmlNode VergiDairesi = XMLresponse.SelectSingleNode("//order/buyer/taxOffice/text()");
            //XmlNode DisKod = XMLresponse.SelectSingleNode("//order/id/text()");
            //XmlNode DisNo = XMLresponse.SelectSingleNode("//order/orderNumber/text()");
            //XmlNode DisOlusmaTarihi = XMLresponse.SelectSingleNode("//order/createDate/text()");
            //XmlNode OdemeTipi = XMLresponse.SelectSingleNode("//order/paymentType/text()");
            //XmlNode Durum = XMLresponse.SelectSingleNode("//order/status/text()");
            ////XmlNode Tutar = XMLresponse.SelectSingleNode("//order/totalAmount/text()"); // tahsil edilecek tutarı veriyor o yüzden kargo bedava ise düşük tutar geliyor
            //XmlNode Eposta = XMLresponse.SelectSingleNode("//order/buyer/email/text()");
            //XmlNode FaturaAdresi = XMLresponse.SelectSingleNode("//order/billingAddress/address/text()");
            //XmlNode FaturaSehir = XMLresponse.SelectSingleNode("//order/billingAddress/city/text()");
            //XmlNode FaturaIlce = XMLresponse.SelectSingleNode("//order/billingAddress/district/text()");
            //XmlNode FaturaPostaKodu = XMLresponse.SelectSingleNode("//order/billingAddress/postalCode/text()");
            //XmlNode FaturaAdSoyad = XMLresponse.SelectSingleNode("//order/billingAddress/fullName/text()");
            //XmlNode FaturaGSM = XMLresponse.SelectSingleNode("//order/billingAddress/gsm/text()");
            //XmlNode DisMusteriKodu = XMLresponse.SelectSingleNode("//order/buyer/id/text()");
            //XmlNode KargoKodu = XMLresponse.SelectSingleNode("//item/shipmentInfo/shipmentCode/text()");
            //XmlNode KargoSirketiKodu = XMLresponse.SelectSingleNode("//item/shipmentInfo/shipmentCompany/id/text()");
            //XmlNode KargoSirketi = XMLresponse.SelectSingleNode("//item/shipmentInfo/shipmentCompany/name/text()");
            //XmlNode KargoAdresi = XMLresponse.SelectSingleNode("//order/shippingAddress/address/text()");
            //XmlNode KargoSehir = XMLresponse.SelectSingleNode("//order/shippingAddress/city/text()");
            //XmlNode KargoIlce = XMLresponse.SelectSingleNode("//order/shippingAddress/district/text()");
            //XmlNode KargoPostaKodu = XMLresponse.SelectSingleNode("//order/shippingAddress/postalCode/text()");
            //XmlNode KargoAdSoyad = XMLresponse.SelectSingleNode("//order/shippingAddress/fullName/text()");
            //XmlNode KargoGSM = XMLresponse.SelectSingleNode("//order/shippingAddress/gsm/text()");
            ////XmlNode KargoTakip = XMLresponse.SelectSingleNode("//item/shipmentInfo/trackingNumber/text()");

            //bool yazildi = false;
            //int SMREF = 0;
            //Sultanlar.DatabaseObject.Internet.DisSiparisler ds = null;
            //if (!Sultanlar.DatabaseObject.Internet.DisSiparisler.VarMiByDisNo(DisNo.Value))
            //{
            //    ds = new DatabaseObject.Internet.DisSiparisler(
            //        1,
            //        TC == null ? "" : TC.Value,
            //        Convert.ToInt64(DisKod.Value),
            //        DisNo.Value,
            //        Convert.ToDateTime(DisOlusmaTarihi.Value),
            //        DateTime.Now,
            //        Convert.ToInt16(OdemeTipi.Value),
            //        Convert.ToInt16(Durum.Value),
            //        0, //Convert.ToDecimal(Tutar.Value.Replace(".", ","))
            //        Eposta.Value,
            //        FaturaAdresi.Value,
            //        FaturaSehir.Value,
            //        FaturaIlce.Value,
            //        FaturaPostaKodu == null ? "" : FaturaPostaKodu.Value,
            //        StringParcalama.IlkHarfBuyuk(FaturaAdSoyad.Value),
            //        FaturaGSM.Value,
            //        Convert.ToInt64(DisMusteriKodu.Value),
            //        Convert.ToInt64(KargoKodu.Value),
            //        Convert.ToInt64(KargoSirketiKodu.Value),
            //        KargoSirketi.Value,
            //        KargoAdresi.Value,
            //        KargoSehir.Value,
            //        KargoIlce.Value,
            //        KargoPostaKodu == null ? "" : KargoPostaKodu.Value,
            //        StringParcalama.IlkHarfBuyuk(KargoAdSoyad.Value),
            //        KargoGSM.Value,
            //        "");
            //    ds.DoInsert();

            //    decimal tutar = 0;

            //    ArrayList dsps = new ArrayList();

            //    XmlNodeList nodes = XMLresponse.SelectNodes("//order/itemList/item");
            //    for (int i = 0; i < nodes.Count; i++)
            //    {
            //        XmlDocument xd = new XmlDocument();
            //        xd.LoadXml("<root>" + nodes[i].InnerXml + "</root>");

            //        XmlNode detDisKod = xd.SelectSingleNode("//id/text()");
            //        XmlNode detDisUrunKod = xd.SelectSingleNode("//productId/text()");
            //        XmlNode detUrunID = xd.SelectSingleNode("//productSellerCode/text()");
            //        XmlNode detUrun = xd.SelectSingleNode("//productName/text()");
            //        XmlNode detMiktar = xd.SelectSingleNode("//quantity/text()");
            //        XmlNode detTutar = xd.SelectSingleNode("//sellerInvoiceAmount/text()");
            //        XmlNode detDurum = xd.SelectSingleNode("//status/text()");

            //        if (Convert.ToInt16(detDurum.Value) != 8) // satır reddedilmiş değil ise
            //        {
            //            Sultanlar.DatabaseObject.Internet.DisSiparislerDetay dsp = new DatabaseObject.Internet.DisSiparislerDetay(
            //                ds.pkID,
            //                Convert.ToInt64(detDisKod.Value),
            //                detDisUrunKod.Value,
            //                Convert.ToInt32(detUrunID.Value),
            //                detUrun.Value,
            //                Convert.ToInt32(detMiktar.Value),
            //                Convert.ToDecimal(detTutar.Value) / Convert.ToInt32(detMiktar.Value), //.Replace(".", ",")
            //                Convert.ToInt16(detDurum.Value),
            //                false);
            //            dsp.DoInsert();

            //            tutar += Convert.ToDecimal(detTutar.Value); //.Replace(".", ",")

            //            dsps.Add(dsp);
            //        }
            //    }

            //    ds.mnTutar = tutar;
            //    ds.DoUpdate();



            //    DataTable dt = new DataTable();
            //    if (TC != null)
            //        CariHesaplar.GetObjectsByVergiNo(dt, TC.Value);

            //    if (dt.Rows.Count > 0)
            //        SMREF = Convert.ToInt32(dt.Rows[0]["GMREF"]);
            //    else
            //        SMREF = 1007689;

            //    //string qsiparisno = n11QuantumaYaz(ds, dsps, SMREF);
            //    Siparisler.DoInsertQ(1000000000 + ds.pkID, "0");

            //    yazildi = true;
            //}

            //if (yazildi) // yazıldı
            //{
            //    string[] kimlere = { 
            //                           //"mtorun@sultanlar.com.tr", 
            //                           "okar@sultanlar.com.tr", 
            //                           //"zakgul@sultanlar.com.tr", 
            //                           "satis@sultanlar.com.tr", 
            //                           //"musay@sultanlar.com.tr", 
            //                           //"ndizdar@sultanlar.com.tr", 
            //                           "mistif@sultanlar.com.tr" };

            //    if (SMREF == 1007689)
            //    {
            //        Sultanlar.Class.Eposta.EpostaYolla("sultanlar@sultanlar.com.tr", "", kimlere, "Sultanlar Pazarlama A.Ş.", "Yeni N11 Siparişi",
            //            "N11 sitesinden yeni bir sipariş gelmiştir, sipariş SAP'a yazılmamıştır. Sipariş carisi sistemde kayıtlı olmadığından yeni bir şahıs carisi açılmalıdır. <br><br>Cari Hesap Bilgileri:<br><br>" + /*"Fatura Türü: " + FaturaTuru.Value == "1" ? "Bireysel" : "Kurumsal" + */"<br>İsim: " + ds.strFaturaAdSoyad.ToUpper() + "<br>Adres: " + ds.strFaturaAdresi.ToUpper() + "<br>Posta Kodu: " + ds.strFaturaPostaKodu + "<br>Şehir: " + ds.strFaturaSehir.ToUpper() + "<br>İlçe: " + ds.strFaturaIlce.ToUpper() + "<br>Telefon: " + ds.strFaturaGSM + "<br>Eposta: " + ds.strEposta + "<br>TC: " + ds.strTC + /*"<br>Vergi Dairesi: " + VergiDairesi != null ? VergiDairesi.Value : "" + "<br>Vergi No: " + VergiNo != null ? VergiNo.Value : "" + */"<br>");
            //    }
            //    else
            //    {
            //        Sultanlar.Class.Eposta.EpostaYolla("sultanlar@sultanlar.com.tr", "", kimlere, "Sultanlar Pazarlama A.Ş.", "Yeni N11 Siparişi",
            //            "N11 sitesinden yeni bir sipariş gelmiştir, sipariş SAP'a yazılmamıştır. Sipariş carisinin sistemimizde DAHA ÖNCE KAYDI AÇILDIĞINDAN TEKRAR AÇILMAMALIDIR. <br><br>Cari Hesap Bilgileri:<br><br>" + /*"Fatura Türü: " + FaturaTuru.Value == "1" ? "Bireysel" : "Kurumsal" + */"<br>İsim: " + ds.strFaturaAdSoyad.ToUpper() + "<br>Adres: " + ds.strFaturaAdresi.ToUpper() + "<br>Posta Kodu: " + ds.strFaturaPostaKodu + "<br>Şehir: " + ds.strFaturaSehir.ToUpper() + "<br>İlçe: " + ds.strFaturaIlce.ToUpper() + "<br>Telefon: " + ds.strFaturaGSM + "<br>Eposta: " + ds.strEposta + "<br>TC: " + ds.strTC + /*"<br>Vergi Dairesi: " + VergiDairesi != null ? VergiDairesi.Value : "" + "<br>Vergi No: " + VergiNo != null ? VergiNo.Value : "" + */"<br>");
            //    }

            //    //for (int i = 0; i < dsps.Count; i++) // BURAYA BİR KERE GİRMESİ GEREKEBİLİR YANİ BÜTÜN SATIRLARI KABUL GÖNDERMEKTENSE BİR SATIRI KABUL ETTİM DEMEK YETERLİ OLABİLİR
            //    //    n11SiparisiKabulEt(((DisSiparislerDetay)dsps[i]).bintDisKod);
            //}
            //else // yazılmadı
            //{
            //    //ds.DoDelete();
            //    //for (int i = 0; i < dsps.Count; i++)
            //    //    ((DisSiparislerDetay)dsps[i]).DoDelete();
            //}
        }
        /// <summary>
        /// n11 siparişinin kabul edildiği bilgisini n11 e gönderir
        /// </summary>
        /// <param name="id">n11 orderdetailid (det.diskod)</param>
        private void n11SiparisiKabulEt(long id)
        {
            /*XmlDocument XMLresponse = this.GetN11("https://api.n11.com/rest/secure/order/acceptOrderItem.xml", "POST", GetN11PostXmlSiparisKabul(id).InnerXml);

            if (XMLresponse.SelectSingleNode("response/header/error/text()") == null && XMLresponse.SelectSingleNode("response/header/errorType/text()") != null)
            {
                Sultanlar.DatabaseObject.Internet.DisSiparislerDetay.DoUpdateKabul(id, true);
            }
            else
            {
                Sultanlar.DatabaseObject.Internet.DisSiparislerDetay.DoUpdateKabul(id, false);
                Hatalar.DoInsert(XMLresponse.SelectSingleNode("response/header/error/text()") != null ? XMLresponse.SelectSingleNode("response/header/error/text()").Value : "değer dönmedi", "Class dissiparisler n11SiparisiKabulEt");
            }*/
        }
        /// <summary>
        /// n11 siparişinin kabul edilmediği bilgisini n11 e gönderir
        /// </summary>
        /// <param name="id">n11 orderdetailid (det.diskod)</param>
        /// <param name="aciklama">red nedeni</param>
        private void n11SiparisiRedEt(long id, string aciklama)
        {
            /*XmlDocument XMLresponse = this.GetN11("https://api.n11.com/rest/secure/order/rejectOrderItem.xml", "POST", GetN11PostXmlSiparisRed(id, aciklama).InnerXml);

            if (XMLresponse.SelectSingleNode("response/header/error/text()") == null)
                Sultanlar.DatabaseObject.Internet.DisSiparislerDetay.DoUpdateKabul(id, false);
            else
                Hatalar.DoInsert(XMLresponse.SelectSingleNode("response/header/error/text()") != null ? XMLresponse.SelectSingleNode("response/header/error/text()").Value : "değer dönmedi", "Class dissiparisler n11SiparisiReddet");*/
        }
        /// <summary>
        /// n11 siparişinin kargo bilgisini n11 e gönderir
        /// </summary>
        /// <param name="id">n11 orderdetailid (det.diskod)</param>
        /// <param name="shippmentmethod">1 kargo, 2 diğer</param>
        /// <param name="shipmentcompanyid">Ceva Lojistik: 401, MNG: 342, Yurtiçi: 344, Aras: 345, Sürat: 341</param>
        /// <param name="trackingnumber">takip numarası</param>
        /// <returns>olumlu,olumsuz</returns>
        public bool n11KargoyaVer(long id, int shippmentmethod, long shipmentcompanyid, string trackingnumber)
        {
            /*bool donendeger = false;

            DatabaseObject.Internet.DisSiparislerDetay dsd = DatabaseObject.Internet.DisSiparislerDetay.GetObject(id);
            DatabaseObject.Internet.DisSiparisler ds = DatabaseObject.Internet.DisSiparisler.GetObject(dsd.intDisSiparisID);

            XmlDocument XMLresponse = this.GetN11("https://api.n11.com/rest/secure/order/makeOrderItemShipment.xml", "POST", GetN11PostXmlKargola(id, shippmentmethod, ds.bintKargoKodu, shipmentcompanyid, trackingnumber).InnerXml);

            if (XMLresponse.SelectSingleNode("response/header/error/text()") == null)
            {
                donendeger = true;

                dsd.sintDurum = 6;
                dsd.DoUpdate();



                ds.strKargoTakip = trackingnumber;
                ds.bintKargoSirketiKodu = shipmentcompanyid;

                if (shipmentcompanyid == 401)
                    ds.strKargoSirketi = "Ceva Lojistik";
                else if (shipmentcompanyid == 342)
                    ds.strKargoSirketi = "MNG";
                else if (shipmentcompanyid == 344)
                    ds.strKargoSirketi = "Yurtiçi";
                else if (shipmentcompanyid == 345)
                    ds.strKargoSirketi = "Aras";
                else if (shipmentcompanyid == 341)
                    ds.strKargoSirketi = "Sürat";

                ds.DoUpdate();
            }
            else
            {
                Hatalar.DoInsert(XMLresponse.SelectSingleNode("response/header/error/text()").Value != null ? XMLresponse.SelectSingleNode("response/header/error/text()").Value : "değer dönmedi", "Class dissiparisler n11KargoyaVer");
            }

            return donendeger;*/
            return false;
        }
        /// <summary>
        /// n11 siparişini quantuma yaz, fiyat tipi 16 olarak yazıldı, iskontolar 0
        /// </summary>
        /// <param name="dissiparis">DisSiparisler</param>
        /// <param name="dissiparislerdetaylar">ArrayList DisSiparislerDetay</param>
        /// <returns>quantum sipariş no</returns>
        private string n11QuantumaYaz(ArrayList dissiparislerdetaylar, int SMREF) //Sultanlar.DatabaseObject.Internet.DisSiparisler dissiparis, 
        {
            //Guid SiparisRef = Guid.NewGuid();
            //DataSet ds = new DataSet();
            //DataTable dtSiparisDetay = new DataTable();
            //dtSiparisDetay.Columns.Add("LOGICALREF", typeof(Guid));
            //dtSiparisDetay.Columns.Add("SIPARIS_REF", typeof(Guid));
            //dtSiparisDetay.Columns.Add("MALZEMEREF", typeof(int));
            //dtSiparisDetay.Columns.Add("MIKTAR", typeof(double));
            //dtSiparisDetay.Columns.Add("FIYAT", typeof(double));
            //dtSiparisDetay.Columns.Add("ISK1", typeof(double));
            //dtSiparisDetay.Columns.Add("ISK2", typeof(double));
            //dtSiparisDetay.Columns.Add("ISK3", typeof(double));
            //dtSiparisDetay.Columns.Add("ISK4", typeof(double));
            //dtSiparisDetay.Columns.Add("ISK5", typeof(double));
            //dtSiparisDetay.Columns.Add("ISK6", typeof(double));
            //dtSiparisDetay.Columns.Add("ISK7", typeof(double));
            //dtSiparisDetay.Columns.Add("ISK8", typeof(double));
            //dtSiparisDetay.Columns.Add("ISK9", typeof(double));
            //dtSiparisDetay.Columns.Add("ISK10", typeof(double));
            //dtSiparisDetay.Columns.Add("BIRIMREF", typeof(int));
            //dtSiparisDetay.Columns.Add("KULLANICI_ADI", typeof(string));
            ///*dtSiparisDetay.Columns.Add("KAYIT_ZAMANI", typeof(DateTime));*/
            //dtSiparisDetay.Columns.Add("KAMPANYAREF", typeof(Guid));
            //dtSiparisDetay.Columns.Add("ODEME_GUN", typeof(int));
            //dtSiparisDetay.Columns.Add("ODEME_TARIH", typeof(DateTime));
            //dtSiparisDetay.Columns.Add("KDV", typeof(double));
            //dtSiparisDetay.Columns.Add("SATIR_TIPI", typeof(int));
            //ds.Tables.Add(dtSiparisDetay);

            //for (int i = 0; i < dissiparislerdetaylar.Count; i++)
            //{
            //    DisSiparislerDetay dsp = (DisSiparislerDetay)dissiparislerdetaylar[i];

            //    //double[] fiyatiskonto = Urunler.GetProductDiscountsAndPrice(dsp.intUrunID, 16);

            //    DataRow drow = ds.Tables[0].NewRow();
            //    drow["LOGICALREF"] = Guid.NewGuid();
            //    drow["SIPARIS_REF"] = SiparisRef;
            //    drow["MALZEMEREF"] = dsp.intUrunID;
            //    drow["MIKTAR"] = dsp.intMiktar;
            //    drow["FIYAT"] = (Convert.ToDouble(dsp.mnTutar) * 100) / (100 + Urunler.GetProductKDV(dsp.intUrunID)); //fiyatiskonto[4]
            //    drow["ISK1"] = 0; //fiyatiskonto[0]
            //    drow["ISK2"] = 0; //fiyatiskonto[1]
            //    drow["ISK3"] = 0; //fiyatiskonto[2]
            //    drow["ISK4"] = 0; //fiyatiskonto[3]
            //    drow["ISK5"] = 0;
            //    drow["ISK6"] = 0;
            //    drow["ISK7"] = 0;
            //    drow["ISK8"] = 0;
            //    drow["ISK9"] = 0;
            //    drow["ISK10"] = 0;
            //    drow["BIRIMREF"] = Urunler.GetProductBirimRef(dsp.intUrunID);
            //    drow["KULLANICI_ADI"] = "Web";
            //    drow["KAMPANYAREF"] = Guid.Empty;



            //    int odemegun = Urunler.GetProductOdemeGun(dsp.intUrunID, 16);
            //    if (odemegun > 0)
            //        drow["ODEME_GUN"] = odemegun;
            //    else
            //        drow["ODEME_GUN"] = DBNull.Value;



            //    DateTime odemetarih = Urunler.GetProductOdemeTarih(dsp.intUrunID, 16);
            //    if (odemegun <= 0 && odemetarih != DateTime.MinValue)
            //        drow["ODEME_TARIH"] = odemetarih;
            //    else
            //        drow["ODEME_TARIH"] = DBNull.Value;



            //    drow["KDV"] = Urunler.GetProductKDV(dsp.intUrunID);
            //    drow["SATIR_TIPI"] = 0;



            //    ds.Tables[0].Rows.Add(drow);
            //}



            //int SiparisTip = 21102;

            //int SLSREF = CariHesaplar.GetSLSREFBySMREF(SMREF);
            //int SEVKREF = 0;

            //string Aciklama1 = dissiparis.strFaturaAdSoyad;
            //string Aciklama2 = "N11 Siparişidir";
            //string Aciklama3 = "";
            //string Aciklama4 = "Web Sipariş No: " + (1000000000 + dissiparis.pkID).ToString();

            //string siparisno = WebGenel.DoUpdateSayac().ToString();

            //Quantum.svcLibraBiz svc = new Quantum.svcLibraBiz();

            //bool yazildi = false;
            //try
            //{
            //    yazildi = svc.WebSiparisYaz_Ambarli
            //        (
            //            SiparisRef.ToString(),
            //            SiparisTip,
            //            SLSREF,
            //            0,
            //            0,
            //            siparisno,
            //            16,
            //            SMREF,
            //            DateTime.Now,
            //            dissiparis.mnTutar, //Convert.ToDecimal(kdvharictoplamtutar),
            //            31, // 30 gün vade
            //            Aciklama1,
            //            Aciklama2,
            //            Aciklama3,
            //            Aciklama4,
            //            SEVKREF,
            //            "Web",
            //            false, //TaksitPlanlari.TaksitMi(31),
            //            "",
            //            false,
            //            ds
            //        );
            //}
            //catch (Exception ex)
            //{
            //    Hatalar.DoInsert(ex, "Class DisSiparisler quantuma yaz");
            //}

            //if (yazildi)
            //    Siparisler.DoInsertQ(1000000000 + dissiparis.pkID, siparisno);

            //QuantumWebServisLog.DoInsert(yazildi, 1000000000 + dissiparis.pkID, siparisno, 0, "SERVERDB01 WinServ.", SiparisTip.ToString());

            //return yazildi ? siparisno : "";
            return "";
        }
        /// <summary>
        /// hb siparişini quantuma yaz, fiyat tipi 15 ve fiyatlar 15'den alınacak
        /// </summary>
        /// <param name="dissiparis">DisSiparisler</param>
        /// <param name="dissiparislerdetaylar">ArrayList DisSiparislerDetay</param>
        /// <returns>quantum sipariş no</returns>
        private string hbQuantumaYaz(ArrayList dissiparislerdetaylar) //Sultanlar.DatabaseObject.Internet.DisSiparisler dissiparis, 
        {
            //int SMREF = 20202; // d-market

            //Guid SiparisRef = Guid.NewGuid();
            //DataSet ds = new DataSet();
            //DataTable dtSiparisDetay = new DataTable();
            //dtSiparisDetay.Columns.Add("LOGICALREF", typeof(Guid));
            //dtSiparisDetay.Columns.Add("SIPARIS_REF", typeof(Guid));
            //dtSiparisDetay.Columns.Add("MALZEMEREF", typeof(int));
            //dtSiparisDetay.Columns.Add("MIKTAR", typeof(double));
            //dtSiparisDetay.Columns.Add("FIYAT", typeof(double));
            //dtSiparisDetay.Columns.Add("ISK1", typeof(double));
            //dtSiparisDetay.Columns.Add("ISK2", typeof(double));
            //dtSiparisDetay.Columns.Add("ISK3", typeof(double));
            //dtSiparisDetay.Columns.Add("ISK4", typeof(double));
            //dtSiparisDetay.Columns.Add("ISK5", typeof(double));
            //dtSiparisDetay.Columns.Add("ISK6", typeof(double));
            //dtSiparisDetay.Columns.Add("ISK7", typeof(double));
            //dtSiparisDetay.Columns.Add("ISK8", typeof(double));
            //dtSiparisDetay.Columns.Add("ISK9", typeof(double));
            //dtSiparisDetay.Columns.Add("ISK10", typeof(double));
            //dtSiparisDetay.Columns.Add("BIRIMREF", typeof(int));
            //dtSiparisDetay.Columns.Add("KULLANICI_ADI", typeof(string));
            ///*dtSiparisDetay.Columns.Add("KAYIT_ZAMANI", typeof(DateTime));*/
            //dtSiparisDetay.Columns.Add("KAMPANYAREF", typeof(Guid));
            //dtSiparisDetay.Columns.Add("ODEME_GUN", typeof(int));
            //dtSiparisDetay.Columns.Add("ODEME_TARIH", typeof(DateTime));
            //dtSiparisDetay.Columns.Add("KDV", typeof(double));
            //dtSiparisDetay.Columns.Add("SATIR_TIPI", typeof(int));
            //ds.Tables.Add(dtSiparisDetay);

            //decimal toplamtutar = 0;
            //for (int i = 0; i < dissiparislerdetaylar.Count; i++)
            //{
            //    DisSiparislerDetay dsp = (DisSiparislerDetay)dissiparislerdetaylar[i];

            //    double[] fiyatiskonto = Urunler.GetProductDiscountsAndPrice(dsp.intUrunID, 15);

            //    toplamtutar += Convert.ToDecimal(fiyatiskonto[4]) * Convert.ToDecimal((100 + Urunler.GetProductKDV(dsp.intUrunID)) / 100);

            //    DataRow drow = ds.Tables[0].NewRow();
            //    drow["LOGICALREF"] = Guid.NewGuid();
            //    drow["SIPARIS_REF"] = SiparisRef;
            //    drow["MALZEMEREF"] = dsp.intUrunID;
            //    drow["MIKTAR"] = dsp.intMiktar;
            //    drow["FIYAT"] = fiyatiskonto[4];
            //    drow["ISK1"] = fiyatiskonto[0];
            //    drow["ISK2"] = fiyatiskonto[1];
            //    drow["ISK3"] = fiyatiskonto[2];
            //    drow["ISK4"] = fiyatiskonto[3];
            //    drow["ISK5"] = fiyatiskonto[5];
            //    drow["ISK6"] = fiyatiskonto[6];
            //    drow["ISK7"] = fiyatiskonto[7];
            //    drow["ISK8"] = fiyatiskonto[8];
            //    drow["ISK9"] = fiyatiskonto[9];
            //    drow["ISK10"] = fiyatiskonto[10];
            //    drow["BIRIMREF"] = Urunler.GetProductBirimRef(dsp.intUrunID);
            //    drow["KULLANICI_ADI"] = "Web";
            //    drow["KAMPANYAREF"] = Guid.Empty;



            //    int odemegun = Urunler.GetProductOdemeGun(dsp.intUrunID, 15);
            //    if (odemegun > 0)
            //        drow["ODEME_GUN"] = odemegun;
            //    else
            //        drow["ODEME_GUN"] = DBNull.Value;



            //    DateTime odemetarih = Urunler.GetProductOdemeTarih(dsp.intUrunID, 15);
            //    if (odemegun <= 0 && odemetarih != DateTime.MinValue)
            //        drow["ODEME_TARIH"] = odemetarih;
            //    else
            //        drow["ODEME_TARIH"] = DBNull.Value;



            //    drow["KDV"] = Urunler.GetProductKDV(dsp.intUrunID);
            //    drow["SATIR_TIPI"] = 0;



            //    ds.Tables[0].Rows.Add(drow);
            //}



            //int SiparisTip = 21102;

            //int SLSREF = CariHesaplar.GetSLSREFBySMREF(SMREF);
            //int SEVKREF = 0;

            //string Aciklama1 = "";
            //string Aciklama2 = "hb Siparişidir";
            //string Aciklama3 = "";
            //string Aciklama4 = "Web Sipariş No: " + (1000000000 + dissiparis.pkID).ToString();

            //string siparisno = WebGenel.DoUpdateSayac().ToString();

            //Quantum.svcLibraBiz svc = new Quantum.svcLibraBiz();

            //bool yazildi = false;
            //try
            //{
            //    yazildi = svc.WebSiparisYaz_Ambarli
            //        (
            //            SiparisRef.ToString(),
            //            SiparisTip,
            //            SLSREF,
            //            0,
            //            0,
            //            siparisno,
            //            15,
            //            SMREF,
            //            DateTime.Now,
            //            toplamtutar,
            //            61, // 60 gün vade
            //            Aciklama1,
            //            Aciklama2,
            //            Aciklama3,
            //            Aciklama4,
            //            SEVKREF,
            //            "Web",
            //            false, //TaksitPlanlari.TaksitMi(31),
            //            "",
            //            false,
            //            ds
            //        );
            //}
            //catch (Exception ex)
            //{
            //    Hatalar.DoInsert(ex, "Class DisSiparisler quantuma yaz");
            //}

            //if (yazildi)
            //    Siparisler.DoInsertQ(1000000000 + dissiparis.pkID, siparisno);

            //QuantumWebServisLog.DoInsert(yazildi, 1000000000 + dissiparis.pkID, siparisno, 0, "SERVERDB01 WinServ.", SiparisTip.ToString());

            //return yazildi ? siparisno : "";
            return "";
        }
        /// <summary>
        /// ucz siparişini quantuma yaz, fiyat tipi 14 ve fiyatlar 14'ten alınacak
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="dissiparislerdetay"></param>
        private string uczQuantumaYaz(ArrayList dissiparislerdetaylar) //DatabaseObject.Internet.DisSiparisler dissiparis, 
        {
            //int SMREF = 69348; // ucz

            //Guid SiparisRef = Guid.NewGuid();
            //DataSet ds = new DataSet();
            //DataTable dtSiparisDetay = new DataTable();
            //dtSiparisDetay.Columns.Add("LOGICALREF", typeof(Guid));
            //dtSiparisDetay.Columns.Add("SIPARIS_REF", typeof(Guid));
            //dtSiparisDetay.Columns.Add("MALZEMEREF", typeof(int));
            //dtSiparisDetay.Columns.Add("MIKTAR", typeof(double));
            //dtSiparisDetay.Columns.Add("FIYAT", typeof(double));
            //dtSiparisDetay.Columns.Add("ISK1", typeof(double));
            //dtSiparisDetay.Columns.Add("ISK2", typeof(double));
            //dtSiparisDetay.Columns.Add("ISK3", typeof(double));
            //dtSiparisDetay.Columns.Add("ISK4", typeof(double));
            //dtSiparisDetay.Columns.Add("ISK5", typeof(double));
            //dtSiparisDetay.Columns.Add("ISK6", typeof(double));
            //dtSiparisDetay.Columns.Add("ISK7", typeof(double));
            //dtSiparisDetay.Columns.Add("ISK8", typeof(double));
            //dtSiparisDetay.Columns.Add("ISK9", typeof(double));
            //dtSiparisDetay.Columns.Add("ISK10", typeof(double));
            //dtSiparisDetay.Columns.Add("BIRIMREF", typeof(int));
            //dtSiparisDetay.Columns.Add("KULLANICI_ADI", typeof(string));
            ///*dtSiparisDetay.Columns.Add("KAYIT_ZAMANI", typeof(DateTime));*/
            //dtSiparisDetay.Columns.Add("KAMPANYAREF", typeof(Guid));
            //dtSiparisDetay.Columns.Add("ODEME_GUN", typeof(int));
            //dtSiparisDetay.Columns.Add("ODEME_TARIH", typeof(DateTime));
            //dtSiparisDetay.Columns.Add("KDV", typeof(double));
            //dtSiparisDetay.Columns.Add("SATIR_TIPI", typeof(int));
            //ds.Tables.Add(dtSiparisDetay);

            //decimal toplamtutar = 0;
            //for (int i = 0; i < dissiparislerdetaylar.Count; i++)
            //{
            //    DisSiparislerDetay dsp = (DisSiparislerDetay)dissiparislerdetaylar[i];

            //    double[] fiyatiskonto = Urunler.GetProductDiscountsAndPrice(dsp.intUrunID, 14);

            //    toplamtutar += Convert.ToDecimal(fiyatiskonto[4]) * Convert.ToDecimal((100 + Urunler.GetProductKDV(dsp.intUrunID)) / 100);

            //    DataRow drow = ds.Tables[0].NewRow();
            //    drow["LOGICALREF"] = Guid.NewGuid();
            //    drow["SIPARIS_REF"] = SiparisRef;
            //    drow["MALZEMEREF"] = dsp.intUrunID;
            //    drow["MIKTAR"] = dsp.intMiktar;
            //    drow["FIYAT"] = fiyatiskonto[4];
            //    drow["ISK1"] = fiyatiskonto[0];
            //    drow["ISK2"] = fiyatiskonto[1];
            //    drow["ISK3"] = fiyatiskonto[2];
            //    drow["ISK4"] = fiyatiskonto[3];
            //    drow["ISK5"] = fiyatiskonto[5];
            //    drow["ISK6"] = fiyatiskonto[6];
            //    drow["ISK7"] = fiyatiskonto[7];
            //    drow["ISK8"] = fiyatiskonto[8];
            //    drow["ISK9"] = fiyatiskonto[9];
            //    drow["ISK10"] = fiyatiskonto[10];
            //    drow["BIRIMREF"] = Urunler.GetProductBirimRef(dsp.intUrunID);
            //    drow["KULLANICI_ADI"] = "Web";
            //    drow["KAMPANYAREF"] = Guid.Empty;



            //    int odemegun = Urunler.GetProductOdemeGun(dsp.intUrunID, 14);
            //    if (odemegun > 0)
            //        drow["ODEME_GUN"] = odemegun;
            //    else
            //        drow["ODEME_GUN"] = DBNull.Value;



            //    DateTime odemetarih = Urunler.GetProductOdemeTarih(dsp.intUrunID, 14);
            //    if (odemegun <= 0 && odemetarih != DateTime.MinValue)
            //        drow["ODEME_TARIH"] = odemetarih;
            //    else
            //        drow["ODEME_TARIH"] = DBNull.Value;



            //    drow["KDV"] = Urunler.GetProductKDV(dsp.intUrunID);
            //    drow["SATIR_TIPI"] = 0;



            //    ds.Tables[0].Rows.Add(drow);
            //}



            //int SiparisTip = 21102;

            //int SLSREF = CariHesaplar.GetSLSREFBySMREF(SMREF);
            //int SEVKREF = Convert.ToInt32(dissiparis.strFaturaAdresi); // fatura adresine sevk sube no su yazılıyor

            //string Aciklama1 = "";
            //string Aciklama2 = "ucz Siparişidir";
            //string Aciklama3 = "";
            //string Aciklama4 = "Web Sipariş No: " + (1000000000 + dissiparis.pkID).ToString();

            //string siparisno = WebGenel.DoUpdateSayac().ToString();

            //Quantum.svcLibraBiz svc = new Quantum.svcLibraBiz();

            //bool yazildi = false;
            //try
            //{
            //    yazildi = svc.WebSiparisYaz_Ambarli
            //        (
            //            SiparisRef.ToString(),
            //            SiparisTip,
            //            SLSREF,
            //            0,
            //            0,
            //            siparisno,
            //            14,
            //            SMREF,
            //            DateTime.Now,
            //            toplamtutar,
            //            76, // 75 gün vade
            //            Aciklama1,
            //            Aciklama2,
            //            Aciklama3,
            //            Aciklama4,
            //            SEVKREF,
            //            "Web",
            //            false, //TaksitPlanlari.TaksitMi(31),
            //            "",
            //            false,
            //            ds
            //        );
            //}
            //catch (Exception ex)
            //{
            //    Hatalar.DoInsert(ex, "Class DisSiparisler quantuma yaz");
            //}

            //if (yazildi)
            //    Siparisler.DoInsertQ(1000000000 + dissiparis.pkID, siparisno);

            //QuantumWebServisLog.DoInsert(yazildi, 1000000000 + dissiparis.pkID, siparisno, 0, "SERVERDB01 WinServ.", SiparisTip.ToString());

            //return yazildi ? siparisno : "";
            return "";
        }











        /// <summary>
        /// n11 uyumlu sipariş listesi için request post xml i
        /// </summary>
        /// <param name="status">NEW,APPROVED,REJECTED,SHIPPED,DELIVERED,COMPLETED</param>
        /// <returns>xml</returns>
        private XmlDocument GetN11PostXmlSiparisListesi(string status)
        {
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
            return new XmlDocument();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sultanlar.DatabaseObject.Internet;
using System.IO;
using System.Data;

namespace Sultanlar.WebUI.musteri
{
    public partial class fiyatlisteindir : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["fid"] != null)
            {
                bool yetkili = false;
                for (int i = 0; i < ((UyeYetkileri)Session["Yetkiler"]).FiyatTipler.Count; i++)
                {
                    short fiyattipiid = Convert.ToInt16(((UyeYetkileri)Session["Yetkiler"]).FiyatTipler[i]);

                    if (fiyattipiid== Convert.ToInt16(Request.QueryString["fid"]))
                    {
                        yetkili = true;
                        break;
                    }
                }

                if (yetkili)
                {
                    if (Request.QueryString["xml"] == "yes")
                    {
                        DataTable dt = new DataTable();
                        FiyatListeleri.GetObjectXml(dt, Convert.ToInt16(Request.QueryString["fid"]), "");
                        
                        string DosyaAdi = "FiyatListe-" + Request.QueryString["fid"] + ".XML";
                        Response.Clear();
                        Response.ClearContent();
                        Response.ClearHeaders();
                        Response.Buffer = true;
                        Response.ContentType = "application/octet-stream";
                        Response.AddHeader("content-disposition", "attachment; filename=\"" + DosyaAdi + "\"");
                        //this.EnableViewState = false;
                        System.IO.StreamWriter xmlDoc = default(System.IO.StreamWriter);
                        xmlDoc = new System.IO.StreamWriter(Response.OutputStream, System.Text.Encoding.UTF8);

                        #region XMLbasi
                        System.Text.StringBuilder XMLbasi = new System.Text.StringBuilder();
                        XMLbasi.AppendLine("<?xml version=\"1.0\" encoding=\"windows-1254\"?>");
                        XMLbasi.AppendLine("<fiyatliste no=\"" + Request.QueryString["fid"] + "\">");
                        xmlDoc.Write(XMLbasi.ToString());
                        #endregion

                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            System.Text.StringBuilder XMLorta = new System.Text.StringBuilder();

                            XMLorta.AppendLine("\t<urun itemref=\"" + dt.Rows[i]["ITEMREF"].ToString() + "\">");
                            XMLorta.AppendLine("\t\t<anagrp>" + dt.Rows[i]["ANA GRP"].ToString() + "</anagrp>");
                            XMLorta.AppendLine("\t\t<altgrp>" + dt.Rows[i]["ALT GRP"].ToString() + "</altgrp>");
                            XMLorta.AppendLine("\t\t<grup>" + dt.Rows[i]["GRUP"].ToString().Replace("&", "-") + "</grup>");
                            XMLorta.AppendLine("\t\t<reyon>" + dt.Rows[i]["REYON"].ToString() + "</reyon>");
                            XMLorta.AppendLine("\t\t<itemref>" + dt.Rows[i]["ITEMREF"].ToString() + "</itemref>");
                            XMLorta.AppendLine("\t\t<kod>" + dt.Rows[i]["KOD"].ToString() + "</kod>");
                            XMLorta.AppendLine("\t\t<malzeme>" + dt.Rows[i]["MALZEME"].ToString().Replace("&", "-") + "</malzeme>");
                            XMLorta.AppendLine("\t\t<barkod>" + dt.Rows[i]["BARKOD"].ToString() + "</barkod>");
                            XMLorta.AppendLine("\t\t<birim>" + dt.Rows[i]["BIRIM"].ToString() + "</birim>");
                            XMLorta.AppendLine("\t\t<koli>" + dt.Rows[i]["KOLI"].ToString() + "</koli>");
                            XMLorta.AppendLine("\t\t<kdv>" + dt.Rows[i]["KDV"].ToString() + "</kdv>");
                            XMLorta.AppendLine("\t\t<kmp>" + dt.Rows[i]["KMP"].ToString() + "</kmp>");
                            XMLorta.AppendLine("\t\t<facik>" + dt.Rows[i]["F ACIK"].ToString() + "</facik>");
                            XMLorta.AppendLine("\t\t<fiy>" + dt.Rows[i][" FIY"].ToString() + "</fiy>");
                            XMLorta.AppendLine("\t\t<isk1>" + dt.Rows[i]["ISK1"].ToString() + "</isk1>");
                            XMLorta.AppendLine("\t\t<isk2>" + dt.Rows[i]["ISK2"].ToString() + "</isk2>");
                            XMLorta.AppendLine("\t\t<isk3>" + dt.Rows[i]["ISK3"].ToString() + "</isk3>");
                            XMLorta.AppendLine("\t\t<isk4>" + dt.Rows[i]["ISK4"].ToString() + "</isk4>");
                            XMLorta.AppendLine("\t\t<netkdv>" + dt.Rows[i]["NET+KDV"].ToString() + "</netkdv>");
                            XMLorta.AppendLine("\t\t<vd>" + dt.Rows[i]["VD"].ToString() + "</vd>");
                            XMLorta.AppendLine("\t\t<stok>-</stok>"); //" + dt.Rows[i]["STOK"].ToString() + "
                            XMLorta.AppendLine("\t\t<urunresimlink>" + dt.Rows[i]["ITEMREF"].ToString() + ".jpg</urunresimlink>"); //http://www.sultanlar.com.tr/musteri/resim.aspx?itemref=
                            XMLorta.AppendLine("\t</urun>");

                            xmlDoc.Write(XMLorta.ToString());
                        }

                        #region XMLsonu
                        System.Text.StringBuilder XMLsonu = new System.Text.StringBuilder();
                        XMLsonu.AppendLine("</fiyatliste>");
                        xmlDoc.Write(XMLsonu.ToString());
                        #endregion

                        xmlDoc.Flush();
                        //excelDoc.Close();
                        Response.End();
                    }
                    else if (Request.QueryString["isxml"] == "yes") // ideasoft için
                    {
                        DataTable dt = new DataTable();
                        FiyatListeleri.GetObjectXml(dt, Convert.ToInt16(Request.QueryString["fid"]), "");

                        string DosyaAdi = "FiyatListe-" + Request.QueryString["fid"] + ".XML";
                        Response.Clear();
                        Response.ClearContent();
                        Response.ClearHeaders();
                        Response.Buffer = true;
                        Response.ContentType = "application/octet-stream";
                        Response.AddHeader("content-disposition", "attachment; filename=\"" + DosyaAdi + "\"");
                        //this.EnableViewState = false;
                        System.IO.StreamWriter xmlDoc = default(System.IO.StreamWriter);
                        xmlDoc = new System.IO.StreamWriter(Response.OutputStream, System.Text.Encoding.UTF8);

                        #region XMLbasi
                        System.Text.StringBuilder XMLbasi = new System.Text.StringBuilder();
                        XMLbasi.AppendLine("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
                        XMLbasi.AppendLine("<root>");
                        xmlDoc.Write(XMLbasi.ToString());
                        #endregion

                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            System.Text.StringBuilder XMLorta = new System.Text.StringBuilder();

                            XMLorta.AppendLine("\t<item>");
                            XMLorta.AppendLine("\t\t<stockCode>" + dt.Rows[i]["ITEMREF"].ToString() + "</stockCode>");
                            XMLorta.AppendLine("\t\t<label>" + dt.Rows[i]["MALZEME"].ToString().Replace("&", "-") + "</label>");
                            XMLorta.AppendLine("\t\t<status>1</status>");
                            XMLorta.AppendLine("\t\t<brand></brand>");
                            XMLorta.AppendLine("\t\t<mainCategory>" + dt.Rows[i]["REYON"].ToString() + "</mainCategory>");
                            XMLorta.AppendLine("\t\t<category></category>");
                            XMLorta.AppendLine("\t\t<subCategory></subCategory>");
                            XMLorta.AppendLine("\t\t<isOptionedProduct>0</isOptionedProduct>");
                            XMLorta.AppendLine("\t\t<isOptionOfAProduct>0</isOptionOfAProduct>");
                            XMLorta.AppendLine("\t\t<rootProductStockCode></rootProductStockCode>");
                            XMLorta.AppendLine("\t\t<price1>" + ((Convert.ToDouble(dt.Rows[i]["NET+KDV"]) * 100) / (100 + Convert.ToDouble(dt.Rows[i]["KDV"]))).ToString("N2") + "</price1>");
                            XMLorta.AppendLine("\t\t<price2></price2>");
                            XMLorta.AppendLine("\t\t<price3></price3>");
                            XMLorta.AppendLine("\t\t<price4></price4>");
                            XMLorta.AppendLine("\t\t<price5></price5>");
                            XMLorta.AppendLine("\t\t<tax>" + dt.Rows[i]["KDV"].ToString() + "</tax>");
                            XMLorta.AppendLine("\t\t<currencyAbbr>TL</currencyAbbr>");
                            XMLorta.AppendLine("\t\t<rebateType></rebateType>");
                            XMLorta.AppendLine("\t\t<rebate></rebate>");
                            XMLorta.AppendLine("\t\t<moneyOrder>0</moneyOrder>");
                            XMLorta.AppendLine("\t\t<stockAmount>-</stockAmount>"); //" + dt.Rows[i]["STOK"].ToString() + "
                            XMLorta.AppendLine("\t\t<stockType>" + dt.Rows[i]["BIRIM"].ToString() + "</stockType>");
                            XMLorta.AppendLine("\t\t<warranty>24</warranty>");
                            XMLorta.AppendLine("\t\t<picture1Path>https://www.sultanlar.com.tr/musteri/resim-" + dt.Rows[i]["Resim"].ToString() + ".html</picture1Path>"); //http://www.sultanlar.com.tr/musteri/resim.aspx?itemref=
                            XMLorta.AppendLine("\t\t<dm3></dm3>");
                            XMLorta.AppendLine("\t\t<details></details>");
                            XMLorta.AppendLine("\t</item>");

                            xmlDoc.Write(XMLorta.ToString());
                        }

                        #region XMLsonu
                        System.Text.StringBuilder XMLsonu = new System.Text.StringBuilder();
                        XMLsonu.AppendLine("</root>");
                        xmlDoc.Write(XMLsonu.ToString());
                        #endregion

                        xmlDoc.Flush();
                        //excelDoc.Close();
                        Response.End();
                    }
                    else if (Request.QueryString["ptxml"] == "yes")
                    {
                        DataTable dt = new DataTable();
                        FiyatListeleri.GetObjectXml(dt, Convert.ToInt16(Request.QueryString["fid"]), "");

                        string DosyaAdi = "FiyatListe-" + Request.QueryString["fid"] + ".XML";
                        Response.Clear();
                        Response.ClearContent();
                        Response.ClearHeaders();
                        Response.Buffer = true;
                        Response.ContentType = "application/octet-stream";
                        Response.AddHeader("content-disposition", "attachment; filename=\"" + DosyaAdi + "\"");
                        //this.EnableViewState = false;
                        System.IO.StreamWriter xmlDoc = default(System.IO.StreamWriter);
                        xmlDoc = new System.IO.StreamWriter(Response.OutputStream, System.Text.Encoding.UTF8);

                        #region XMLbasi
                        System.Text.StringBuilder XMLbasi = new System.Text.StringBuilder();
                        XMLbasi.AppendLine("<?xml version=\"1.0\" encoding=\"windows-1254\" standalone=\"yes\"?>");
                        XMLbasi.AppendLine("<root>");
                        xmlDoc.Write(XMLbasi.ToString());
                        #endregion

                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            System.Text.StringBuilder XMLorta = new System.Text.StringBuilder();

                            XMLorta.AppendLine("\t<urun>");
                            XMLorta.AppendLine("\t\t<AnaKategori>" + dt.Rows[i]["REYON"].ToString() + "</AnaKategori>");
                            XMLorta.AppendLine("\t\t<Durumu>true</Durumu>");
                            XMLorta.AppendLine("\t\t<StokKodu>" + dt.Rows[i]["ITEMREF"].ToString() + "</StokKodu>");
                            XMLorta.AppendLine("\t\t<Barkod>" + dt.Rows[i]["BARKOD"].ToString() + "</Barkod>");
                            XMLorta.AppendLine("\t\t<StokAdi>" + dt.Rows[i]["MALZEME"].ToString().Replace("&", "-") + "</StokAdi>");
                            XMLorta.AppendLine("\t\t<Kod1 />");
                            XMLorta.AppendLine("\t\t<Kod2 />");
                            XMLorta.AppendLine("\t\t<Kod3 />");
                            XMLorta.AppendLine("\t\t<Kod4 />");
                            XMLorta.AppendLine("\t\t<Kod5 />");
                            XMLorta.AppendLine("\t\t<Kod6 />");
                            XMLorta.AppendLine("\t\t<Kod7 />");
                            XMLorta.AppendLine("\t\t<Kod8 />");
                            XMLorta.AppendLine("\t\t<Kod9 />");
                            XMLorta.AppendLine("\t\t<Kod10 />");
                            XMLorta.AppendLine("\t\t<Kod11 />");
                            XMLorta.AppendLine("\t\t<Kod12 />");
                            XMLorta.AppendLine("\t\t<Kod13 />");
                            XMLorta.AppendLine("\t\t<Kod14 />");
                            XMLorta.AppendLine("\t\t<Kod15 />");
                            XMLorta.AppendLine("\t\t<Aciklama />");
                            XMLorta.AppendLine("\t\t<Detay></Detay>");
                            XMLorta.AppendLine("\t\t<Envanter>0</Envanter>");
                            XMLorta.AppendLine("\t\t<Resim>http://www.siteniz.com/" + dt.Rows[i]["ITEMREF"].ToString() + ".jpg</Resim>"); //http://www.sultanlar.com.tr/musteri/resim.aspx?itemref=
                            XMLorta.AppendLine("\t\t<MarkaAdi></MarkaAdi>");
                            XMLorta.AppendLine("\t\t<KdvOrani>" + dt.Rows[i]["KDV"].ToString() + "</KdvOrani>");
                            XMLorta.AppendLine("\t\t<BirimAdi>" + dt.Rows[i]["BIRIM"].ToString() + "</BirimAdi>");
                            XMLorta.AppendLine("\t\t<BirimCarpan></BirimCarpan>");
                            XMLorta.AppendLine("\t\t<HavaleFiyati>" + ((Convert.ToDouble(dt.Rows[i]["NET+KDV"]) * 100) / (100 + Convert.ToDouble(dt.Rows[i]["KDV"]))).ToString("N2") + "</HavaleFiyati>");
                            XMLorta.AppendLine("\t\t<HavaleFiyatiParaBirimi>TL</HavaleFiyatiParaBirimi>");
                            XMLorta.AppendLine("\t\t<SatisFiyati1>" + ((Convert.ToDouble(dt.Rows[i]["NET+KDV"]) * 100) / (100 + Convert.ToDouble(dt.Rows[i]["KDV"]))).ToString("N2") + "</SatisFiyati1>");
                            XMLorta.AppendLine("\t\t<Isk1>0</Isk1>");
                            XMLorta.AppendLine("\t\t<SatisFiyati1ParaBirimi>TL</SatisFiyati1ParaBirimi>");
                            XMLorta.AppendLine("\t\t<SatisFiyati2>0</SatisFiyati2>");
                            XMLorta.AppendLine("\t\t<Isk2>0</Isk2>");
                            XMLorta.AppendLine("\t\t<SatisFiyati2ParaBirimi>TL</SatisFiyati2ParaBirimi>");
                            XMLorta.AppendLine("\t\t<SatisFiyati3>0</SatisFiyati3>");
                            XMLorta.AppendLine("\t\t<Isk3>0</Isk3>");
                            XMLorta.AppendLine("\t\t<SatisFiyati3ParaBirimi>TL</SatisFiyati3ParaBirimi>");
                            XMLorta.AppendLine("\t\t<SatisFiyati4>0</SatisFiyati4>");
                            XMLorta.AppendLine("\t\t<Isk4>0</Isk4>");
                            XMLorta.AppendLine("\t\t<SatisFiyati4ParaBirimi>TL</SatisFiyati4ParaBirimi>");
                            XMLorta.AppendLine("\t\t<SatisFiyati5>0</SatisFiyati5>");
                            XMLorta.AppendLine("\t\t<Isk5>0</Isk5>");
                            XMLorta.AppendLine("\t\t<SatisFiyati5ParaBirimi>TL</SatisFiyati5ParaBirimi>");
                            XMLorta.AppendLine("\t\t<PiyasaFiyati>0</PiyasaFiyati>");
                            XMLorta.AppendLine("\t\t<PiyasaFiyatiParaBirimi>TL</PiyasaFiyatiParaBirimi>");
                            XMLorta.AppendLine("\t\t<AlisFiyati>0</AlisFiyati>");
                            XMLorta.AppendLine("\t\t<AlisFiyatiParaBirimi>TL</AlisFiyatiParaBirimi>");
                            XMLorta.AppendLine("\t\t<Desi></Desi>");
                            XMLorta.AppendLine("\t\t<HizliKargo></HizliKargo>");
                            XMLorta.AppendLine("\t\t<EnUcuzUrun></EnUcuzUrun>");
                            XMLorta.AppendLine("\t\t<AyniGunTeslim></AyniGunTeslim>");
                            XMLorta.AppendLine("\t\t<IndirimliUrun></IndirimliUrun>");
                            XMLorta.AppendLine("\t\t<SinirliSayidaUrun></SinirliSayidaUrun>");
                            XMLorta.AppendLine("\t\t<FirsatUrunu></FirsatUrunu>");
                            XMLorta.AppendLine("\t\t<YeniUrun></YeniUrun>");
                            XMLorta.AppendLine("\t\t<SokFiyatliUrun></SokFiyatliUrun>");
                            XMLorta.AppendLine("\t\t<HediyeliUrun></HediyeliUrun>");
                            XMLorta.AppendLine("\t\t<TedarikciAdi></TedarikciAdi>");
                            XMLorta.AppendLine("\t\t<XmlTedarikciAdi></XmlTedarikciAdi>");
                            XMLorta.AppendLine("\t\t<UreticiKodu />");
                            XMLorta.AppendLine("\t\t<SearchKeywords />");
                            XMLorta.AppendLine("\t\t<CatId></CatId>");
                            XMLorta.AppendLine("\t\t<MarkId></MarkId>");
                            XMLorta.AppendLine("\t\t<UrunId></UrunId>");
                            XMLorta.AppendLine("\t\t<url></url>");
                            XMLorta.AppendLine("\t</urun>");

                            xmlDoc.Write(XMLorta.ToString());
                        }

                        #region XMLsonu
                        System.Text.StringBuilder XMLsonu = new System.Text.StringBuilder();
                        XMLsonu.AppendLine("</root>");
                        xmlDoc.Write(XMLsonu.ToString());
                        #endregion

                        xmlDoc.Flush();
                        //excelDoc.Close();
                        Response.End();
                    }
                    else
                    {
                        //byte[] dosya = FiyatListeleri.GetObjectByFiyatTipiID(Convert.ToInt32(Request.QueryString["fid"]));
                        //Response.Clear();
                        //Response.ClearContent();
                        //Response.ClearHeaders();
                        //Response.Buffer = true;
                        ////Response.ContentType = "application/vnd.ms-excel";
                        //Response.ContentType = "application/octet-stream";
                        ////Response.AddHeader("Content-Type", "application/octet-stream");
                        //Response.AddHeader("content-disposition", "attachment; filename=\"fiyatliste" + Request.QueryString["fid"].ToString() + ".XLS\"");
                        //Response.BinaryWrite(dosya);
                        //Response.Flush();
                        //Response.End();

                        DataTable dt = new DataTable();
                        FiyatListeleri.GetObjectXml(dt, 0, "WHERE FTIP = " + Request.QueryString["fid"]);
                        
                        string DosyaAdi = "FiyatListe-" + Request.QueryString["fid"] + ".XLS";
                        Response.Clear();
                        Response.ClearContent();
                        Response.ClearHeaders();
                        Response.Buffer = true;
                        Response.ContentType = "application/octet-stream";
                        Response.AddHeader("content-disposition", "attachment; filename=\"" + DosyaAdi + "\"");
                        //this.EnableViewState = false;
                        System.IO.StreamWriter xmlDoc = default(System.IO.StreamWriter);
                        xmlDoc = new System.IO.StreamWriter(Response.OutputStream, System.Text.Encoding.UTF8);

                        #region XMLbasi
                        System.Text.StringBuilder XMLbasi = new System.Text.StringBuilder();
                        //XMLbasi.AppendLine("<?xml version=\"1.0\" encoding=\"windows-1254\"?>");
                        XMLbasi.AppendLine("<table border='1'>");
                        XMLbasi.AppendLine("<tr style='background-color:#FCF9AC;font-weight:bold;text-align:center'>");
                        XMLbasi.AppendLine("<td>ITEMREF</td>");
                        XMLbasi.AppendLine("<td style='text-align:center'>ANA GRP</td>");
                        XMLbasi.AppendLine("<td style='text-align:center'>ALT GRP</td>");
                        XMLbasi.AppendLine("<td>GRUP</td>");
                        XMLbasi.AppendLine("<td style='text-align:center'>REYON</td>");
                        XMLbasi.AppendLine("<td>ITEMREF</td>");
                        XMLbasi.AppendLine("<td>KOD</td>");
                        XMLbasi.AppendLine("<td style='width: 350px'>MALZEME</td>");
                        XMLbasi.AppendLine("<td>BARKOD</td>");
                        XMLbasi.AppendLine("<td>BIRIM</td>");
                        XMLbasi.AppendLine("<td style='text-align:center'>KOLI</td>");
                        XMLbasi.AppendLine("<td style='text-align:center'>KDV</td>");
                        XMLbasi.AppendLine("<td>KMP</td>");
                        XMLbasi.AppendLine("<td>F ACIK</td>");
                        XMLbasi.AppendLine("<td> FIY</td>");
                        XMLbasi.AppendLine("<td>ISK1</td>");
                        XMLbasi.AppendLine("<td>ISK2</td>");
                        XMLbasi.AppendLine("<td>ISK3</td>");
                        XMLbasi.AppendLine("<td>ISK4</td>");
                        XMLbasi.AppendLine("<td>ISK5</td>");
                        XMLbasi.AppendLine("<td>ISK6</td>");
                        XMLbasi.AppendLine("<td>ISK7</td>");
                        XMLbasi.AppendLine("<td>ISK8</td>");
                        XMLbasi.AppendLine("<td>ISK9</td>");
                        XMLbasi.AppendLine("<td>ISK10</td>");
                        XMLbasi.AppendLine("<td>NET+KDV</td>");
                        XMLbasi.AppendLine("<td style='text-align:center'>VD</td>");
                        XMLbasi.AppendLine("<td style='text-align:center'>STOK</td>");
                        XMLbasi.AppendLine("</tr>");
                        xmlDoc.Write(XMLbasi.ToString());
                        #endregion

                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            System.Text.StringBuilder XMLorta = new System.Text.StringBuilder();

                            XMLorta.AppendLine("<tr>");
                            XMLorta.AppendLine("<td>" + dt.Rows[i]["ITEMREF"].ToString() + "</td>");
                            XMLorta.AppendLine("<td>" + dt.Rows[i]["ANA GRP"].ToString() + "</td>");
                            XMLorta.AppendLine("<td>" + dt.Rows[i]["ALT GRP"].ToString() + "</td>");
                            XMLorta.AppendLine("<td>" + dt.Rows[i]["GRUP"].ToString().Replace("&", "-") + "</td>");
                            XMLorta.AppendLine("<td>" + dt.Rows[i]["REYON"].ToString() + "</td>");
                            XMLorta.AppendLine("<td>" + dt.Rows[i]["ITEMREF"].ToString() + "</td>");
                            XMLorta.AppendLine("<td>" + dt.Rows[i]["KOD"].ToString() + "</td>");
                            XMLorta.AppendLine("<td>" + dt.Rows[i]["MALZEME"].ToString().Replace("&", "-") + "</td>");
                            XMLorta.AppendLine("<td>" + dt.Rows[i]["BARKOD"].ToString() + "</td>");
                            XMLorta.AppendLine("<td>" + dt.Rows[i]["BIRIM"].ToString() + "</td>");
                            XMLorta.AppendLine("<td>" + dt.Rows[i]["KOLI"].ToString() + "</td>");
                            XMLorta.AppendLine("<td>" + dt.Rows[i]["KDV"].ToString() + "</td>");
                            XMLorta.AppendLine("<td>" + dt.Rows[i]["KMP"].ToString() + "</td>");
                            XMLorta.AppendLine("<td>" + dt.Rows[i]["F ACIK"].ToString() + "</td>");
                            XMLorta.AppendLine("<td>" + dt.Rows[i][" FIY"].ToString() + "</td>");
                            XMLorta.AppendLine("<td>" + dt.Rows[i]["ISK1"].ToString() + "</td>");
                            XMLorta.AppendLine("<td>" + dt.Rows[i]["ISK2"].ToString() + "</td>");
                            XMLorta.AppendLine("<td>" + dt.Rows[i]["ISK3"].ToString() + "</td>");
                            XMLorta.AppendLine("<td>" + dt.Rows[i]["ISK4"].ToString() + "</td>");
                            XMLorta.AppendLine("<td>" + dt.Rows[i]["ISK5"].ToString() + "</td>");
                            XMLorta.AppendLine("<td>" + dt.Rows[i]["ISK6"].ToString() + "</td>");
                            XMLorta.AppendLine("<td>" + dt.Rows[i]["ISK7"].ToString() + "</td>");
                            XMLorta.AppendLine("<td>" + dt.Rows[i]["ISK8"].ToString() + "</td>");
                            XMLorta.AppendLine("<td>" + dt.Rows[i]["ISK9"].ToString() + "</td>");
                            XMLorta.AppendLine("<td>" + dt.Rows[i]["ISK10"].ToString() + "</td>");
                            XMLorta.AppendLine("<td>" + dt.Rows[i]["NET+KDV"].ToString() + "</td>");
                            XMLorta.AppendLine("<td>" + dt.Rows[i]["VD"].ToString() + "</td>");
                            XMLorta.AppendLine("<td>-</td>"); //" + dt.Rows[i]["STOK"].ToString() + "
                            XMLorta.AppendLine("</tr>");

                            xmlDoc.Write(XMLorta.ToString());
                        }

                        #region XMLsonu
                        System.Text.StringBuilder XMLsonu = new System.Text.StringBuilder();
                        XMLsonu.AppendLine("</table>");
                        xmlDoc.Write(XMLsonu.ToString());
                        #endregion

                        xmlDoc.Flush();
                        //excelDoc.Close();
                        Response.End();
                    }



                    //string dosyaadi = "fiyatliste" + Request.QueryString["fid"].ToString() + ".xls";
                    ////if (File.Exists(Server.MapPath("/musteri/downtemp/" + dosyaadi)))
                    ////{

                    ////}
                    //File.WriteAllBytes(Server.MapPath("/musteri/downtemp/" + dosyaadi), dosya);
                    //Session["indirdosya"] = dosyaadi;
                    //string alert = "<script type='text/javascript'>if (navigator.appName == 'Microsoft Internet Explorer') { var param = 'toolbar=no,location=no,status=no,menubar=no,scrollbars=yes,width=100,height=100,noresize';window.open('indir.aspx', '_blank', param); } else { yenipencere = window.open('indir.aspx', 'İndirme', 'toolbar=no,location=no,status=no,menubar=no,scrollbars=yes,width=100,height=100,noresize'); } window.close(); </script>";
                    //ScriptManager.RegisterStartupScript(div, typeof(string), "scriptAc", alert, false);
                }
                else
                {
                    Response.Write("Dosya Bulunamadı.");
                }
            }
            else
            {
                Response.Write("Dosya Bulunamadı.");
            }
        }
    }
}
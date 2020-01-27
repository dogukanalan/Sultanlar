using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sultanlar.DatabaseObject.Internet;
using System.Data;
using System.Collections;

namespace Sultanlar.WebUI.musteri
{
    public partial class download : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);

            if (Session["downloadodemeid"] == null && Session["downloadsiparisid"] == null && Session["downloadekstregmref"] == null &&
                Session["downloadsatisraporgmref"] == null && Session["downloadsatisraporsmref"] == null &&
                Session["downloadsatisraporslsref"] == null && Session["downloadiadeid"] == null && Request.QueryString["efatura"] == null &&
                Session["downloadaktiviteid"] == null && Session["downloadhizmetid"] == null && Session["downloadhizmetlersmref"] == null && 
                Session["downloadhizmetlergmref"] == null)
            {
                //Label2.Visible = false;
                Label1.Visible = true;
                //ImageButton1.Visible = false;
            }
            else
            {
                Label1.Visible = false;

                if (Session["downloadsiparisid"] != null)
                {
                    ExportToExcel((int)Session["downloadsiparisid"]);
                    //Response.Write("<script type='text/javascript'>window.close()</script>");
                }
                else if (Session["downloadiadeid"] != null)
                {
                    ExportToExcelIade((int)Session["downloadiadeid"]);
                    //Response.Write("<script type='text/javascript'>window.close()</script>");
                }
                else if (Session["downloadaktiviteid"] != null)
                {
                    ExportToExcelAktivite((int)Session["downloadaktiviteid"]);
                    //Response.Write("<script type='text/javascript'>window.close()</script>");
                }
                else if (Session["downloadhizmetid"] != null)
                {
                    ExportToExcelHizmet((int)Session["downloadhizmetid"]);
                    //Response.Write("<script type='text/javascript'>window.close()</script>");
                }
                else if (Session["downloadhizmetlersmref"] != null)
                {
                    ExportToExcelHizmetler((int)Session["downloadhizmetlersmref"], (int)Session["downloadhizmetleronayli"], 
                        (DateTime)Session["downloadhizmetlertarihbaslangic"], (DateTime)Session["downloadhizmetlertarihbitis"], false);
                    //Response.Write("<script type='text/javascript'>window.history.back(-1);return false;</script>");
                }
                else if (Session["downloadhizmetlergmref"] != null)
                {
                    ExportToExcelHizmetler((int)Session["downloadhizmetlergmref"], (int)Session["downloadhizmetleronayli"],
                        (DateTime)Session["downloadhizmetlertarihbaslangic"], (DateTime)Session["downloadhizmetlertarihbitis"], true);
                    //Response.Write("<script type='text/javascript'>window.history.back(-1);return false;</script>");
                }
                else if (Session["downloadekstregmref"] != null)
                {
                    ExportToExcelEkstre((int)Session["downloadekstregmref"]);
                    //Response.Write("<script type='text/javascript'>window.close()</script>");
                }
                else if (Session["downloadodemeid"] != null)
                {
                    ExportToExcelOdeme((int)Session["downloadodemeid"]);
                    //Response.Write("<script type='text/javascript'>window.close()</script>");
                }
                else if (Session["downloadsatisraportumozelkod"] != null)
                {
                    ExportToExcelSatisRaporOzelKod();
                    //Response.Write("<script type='text/javascript'>window.close()</script>");
                }
                else if (Session["downloadsatisraporgmref"] != null && Session["downloadsatisraporslsref"] != null)
                {
                    ExportToExcelSatisRapor((int)Session["downloadsatisraporgmref"], (int)Session["downloadsatisraporslsref"], true);
                    //Response.Write("<script type='text/javascript'>window.close()</script>");
                }
                else if (Session["downloadsatisraporsmref"] != null && Session["downloadsatisraporslsref"] != null)
                {
                    ExportToExcelSatisRapor((int)Session["downloadsatisraporsmref"], (int)Session["downloadsatisraporslsref"], false);
                    //Response.Write("<script type='text/javascript'>window.close()</script>");
                }
                else if (Session["downloadsatisraporslsrefs"] == null && Session["downloadsatisraporslsref"] != null)
                {
                    ExportToExcelSatisRaporSLSREF((int)Session["downloadsatisraporslsref"]);
                    //Response.Write("<script type='text/javascript'>window.close()</script>");
                }
                else if (Session["downloadsatisraporslsrefs"] != null && Session["downloadsatisraporslsref"] != null)
                {
                    ExportToExcelSatisRaporSLSREFs((int)Session["downloadsatisraporslsref"]);
                    //Response.Write("<script type='text/javascript'>window.close()</script>");
                }
                else if (Request.QueryString["efatura"] != null)
                {
                    if (Session["EFaturaFaturaNolar"] != null)
                    {
                        EFatura();
                        //Response.Write("<script type='text/javascript'>window.close()</script>");
                    }
                    else
                    {
                        Label1.Visible = true;
                    }
                }
            }
        }

        private void ExportToExcel(int SiparisID)
        {
            Siparisler sip = Siparisler.GetObjectsBySiparisID(SiparisID);
            string carihesap = string.Empty;
            if (sip.SMREF > 0)
                carihesap = CariHesaplar.GetSubeBySMREF(sip.SMREF)[1].ToString();
            else
                carihesap = CariHesaplar.GetSubeBySMREF(24479)[1].ToString();
            string fiyattip = FiyatTipleri.GetObjectByID(sip.sintFiyatTipiID);
            string siparistarihi = sip.dtOlusmaTarihi.ToShortDateString();
            string siparisonaytarihi = "";
            if (sip.blAktarilmis)
                siparisonaytarihi = sip.dtOlusmaTarihi.ToShortDateString();
            string vade = TaksitPlanlari.GetOdemePlani(sip.TKSREF);
            Musteriler musteri = Musteriler.GetMusteriByID(sip.intMusteriID);
            string musteriadsoyad = musteri.strAd + " " + musteri.strSoyad;
            decimal toplamtutar = sip.mnToplamTutar;
            string[] aciklama = sip.strAciklama.Split(new string[] { ";;;" }, StringSplitOptions.None);
            string Aciklama = aciklama[1] + " " + aciklama[2];
            Aciklama += musteri.tintUyeTipiID == 5 ? " " + musteri.strTelefon : "";

            DataTable dt = new DataTable();
            SiparislerDetay.GetObjectsBySiparisID(dt, SiparisID, sip.sintFiyatTipiID, true);



            Session["downloadsiparisid"] = null;



            string DosyaAdi = "Siparis-" + sip.pkSiparisID.ToString() + ".XLS";
            Response.Clear();
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Buffer = true;
            Response.ContentType = "application/octet-stream";
            Response.AddHeader("content-disposition", "attachment; filename=\"" + DosyaAdi + "\"");
            this.EnableViewState = false;
            System.IO.StreamWriter excelDoc = default(System.IO.StreamWriter);
            excelDoc = new System.IO.StreamWriter(Response.OutputStream);

            #region ExcelXMLbasi
            System.Text.StringBuilder ExcelXMLbasi = new System.Text.StringBuilder();
            ExcelXMLbasi.AppendLine("<?xml version=\"1.0\"?>");
            ExcelXMLbasi.AppendLine("<?mso-application progid=\"Excel.Sheet\"?>");
            ExcelXMLbasi.AppendLine("<Workbook xmlns=\"urn:schemas-microsoft-com:office:spreadsheet\"");
            ExcelXMLbasi.AppendLine(" xmlns:o=\"urn:schemas-microsoft-com:office:office\"");
            ExcelXMLbasi.AppendLine(" xmlns:x=\"urn:schemas- microsoft-com:office:excel\"");
            ExcelXMLbasi.AppendLine(" xmlns:ss=\"urn:schemas-microsoft-com:office:spreadsheet\">");
            ExcelXMLbasi.AppendLine(" <Styles>");
            ExcelXMLbasi.AppendLine(" <Style ss:ID=\"Default\" ss:Name=\"Normal\">");
            ExcelXMLbasi.AppendLine(" <Alignment ss:Vertical=\"Bottom\"/>");
            ExcelXMLbasi.AppendLine(" <Borders/>");
            ExcelXMLbasi.AppendLine(" <Font/>");
            ExcelXMLbasi.AppendLine(" <Interior/>");
            ExcelXMLbasi.AppendLine(" <NumberFormat/>");
            ExcelXMLbasi.AppendLine(" <Protection/>");
            ExcelXMLbasi.AppendLine(" </Style>");
            ExcelXMLbasi.AppendLine(" <Style ss:ID=\"KalinBaslik\">");
            ExcelXMLbasi.AppendLine(" <Font x:Family=\"Swiss\" ss:Bold=\"1\"/>");
            ExcelXMLbasi.AppendLine(" </Style>");
            ExcelXMLbasi.AppendLine(" <Style ss:ID=\"StringLiteral\">");
            ExcelXMLbasi.AppendLine(" <NumberFormat ss:Format=\"@\"/>");
            ExcelXMLbasi.AppendLine(" </Style>");
            ExcelXMLbasi.AppendLine(" <Style ss:ID=\"Decimal\">");
            ExcelXMLbasi.AppendLine(" <NumberFormat ss:Format=\"0\"/>");
            ExcelXMLbasi.AppendLine(" </Style>");
            ExcelXMLbasi.AppendLine(" <Style ss:ID=\"Integer\">");
            ExcelXMLbasi.AppendLine(" <NumberFormat ss:Format=\"0\"/>");
            ExcelXMLbasi.AppendLine(" <Alignment ss:Horizontal=\"Center\" ss:Vertical=\"Bottom\"/>");
            ExcelXMLbasi.AppendLine(" </Style>");
            ExcelXMLbasi.AppendLine(" <Style ss:ID=\"Currency\">");
            ExcelXMLbasi.AppendLine(" <NumberFormat ss:Format=\"0.000 TL\"/>");
            ExcelXMLbasi.AppendLine(" <Alignment ss:Horizontal=\"Right\" ss:Vertical=\"Bottom\"/>");
            ExcelXMLbasi.AppendLine(" </Style>");
            ExcelXMLbasi.AppendLine(" <Style ss:ID=\"DateLiteral\">");
            ExcelXMLbasi.AppendLine(" <NumberFormat ss:Format=\"dd.mm.yyyy;@\"/>");
            ExcelXMLbasi.AppendLine(" </Style>");
            ExcelXMLbasi.AppendLine(" </Styles>");
            excelDoc.Write(ExcelXMLbasi.ToString());
            #endregion

            excelDoc.Write(" <Worksheet ss:Name=\"Rapor\">");
            excelDoc.Write("<Table>" + 
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"120.00\"/>" + 
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"220.00\"/>" + 
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"40.00\"/>" + 
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"40.00\"/>" + 
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"90.00\"/>" + 
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"60.00\"/>" + 
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"60.00\"/>" + 
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"60.00\"/>" + 
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"60.00\"/>" + 
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"90.00\"/>");


            excelDoc.Write("<Row>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Siparişi Giren:</Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\">" + musteriadsoyad + "</Data></Cell>");
            excelDoc.Write("</Row>");
            excelDoc.Write("<Row>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Cari Hesap:</Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\">" + carihesap + "</Data></Cell>");
            excelDoc.Write("</Row>");
            excelDoc.Write("<Row>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Fiyat Tipi:</Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\">" + fiyattip + "</Data></Cell>");
            excelDoc.Write("</Row>");
            excelDoc.Write("<Row>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Sipariş Oluşturma Tarihi:</Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\">" + siparistarihi + "</Data></Cell>");
            excelDoc.Write("</Row>");
            excelDoc.Write("<Row>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Sipariş Onay Tarihi:</Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\">" + siparisonaytarihi + "</Data></Cell>");
            excelDoc.Write("</Row>");
            //excelDoc.Write("<Row>");
            //excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Vade:</Data></Cell>");
            //excelDoc.Write("<Cell><Data ss:Type=\"String\">" + vade + "</Data></Cell>");
            //excelDoc.Write("</Row>");
            excelDoc.Write("<Row>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Açıklama:</Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\">" + Aciklama + "</Data></Cell>");
            excelDoc.Write("</Row>");

            excelDoc.Write("<Row>");
            //excelDoc.Write("<Cell><Data ss:Type=\"String\"></Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">::: ÜRÜNLER :::</Data></Cell>");
            excelDoc.Write("</Row>");

            excelDoc.Write("<Row>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Barkod</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Ürün Açıklama</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">KDV</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Miktar</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Brüt Fiyat</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">İskonto 1</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">İskonto 2</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">İskonto 3</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">İskonto 4</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Toplam + KDV</Data></Cell>");
            excelDoc.Write("</Row>");

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                excelDoc.Write("<Row>");
                excelDoc.Write("<Cell ss:StyleID=\"Integer\"><Data ss:Type=\"Number\">" + dt.Rows[i]["BARKOD"].ToString() + "</Data></Cell>");
                excelDoc.Write("<Cell><Data ss:Type=\"String\">" + dt.Rows[i]["strUrunAdi"].ToString() + "</Data></Cell>");
                excelDoc.Write("<Cell ss:StyleID=\"Integer\"><Data ss:Type=\"Number\">" + dt.Rows[i]["KDV"].ToString() + "</Data></Cell>");
                excelDoc.Write("<Cell ss:StyleID=\"Integer\"><Data ss:Type=\"Number\">" + dt.Rows[i]["intMiktar"].ToString() + "</Data></Cell>");
                excelDoc.Write("<Cell ss:StyleID=\"Currency\"><Data ss:Type=\"Number\">" + Convert.ToDecimal(dt.Rows[i]["FIYAT"]).ToString().Replace(".", "").Replace(",", ".") + "</Data></Cell>");
                excelDoc.Write("<Cell ss:StyleID=\"Integer\"><Data ss:Type=\"Number\">" + Convert.ToDouble(dt.Rows[i]["ISK1"]).ToString("N1").Replace(".", "").Replace(",", ".") + "</Data></Cell>");
                excelDoc.Write("<Cell ss:StyleID=\"Integer\"><Data ss:Type=\"Number\">" + Convert.ToDouble(dt.Rows[i]["ISK2"]).ToString("N1").Replace(".", "").Replace(",", ".") + "</Data></Cell>");
                excelDoc.Write("<Cell ss:StyleID=\"Integer\"><Data ss:Type=\"Number\">" + Convert.ToDouble(dt.Rows[i]["ISK3"]).ToString("N1").Replace(".", "").Replace(",", ".") + "</Data></Cell>");
                excelDoc.Write("<Cell ss:StyleID=\"Integer\"><Data ss:Type=\"Number\">" + Convert.ToDouble(dt.Rows[i]["ISK4"]).ToString("N1").Replace(".", "").Replace(",", ".") + "</Data></Cell>");
                excelDoc.Write("<Cell ss:StyleID=\"Currency\"><Data ss:Type=\"Number\">" + (Convert.ToInt32(dt.Rows[i]["intMiktar"]) * Convert.ToDecimal(dt.Rows[i]["mnFiyat"])).ToString().Replace(".", "").Replace(",", ".") + "</Data></Cell>");
                excelDoc.Write("</Row>");
            }

            excelDoc.Write("<Row>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\"></Data></Cell>");
            excelDoc.Write("</Row>");
            excelDoc.Write("<Row>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\"></Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\"></Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\"></Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\"></Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\"></Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\"></Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\"></Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Genel Toplam + KDV:</Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\"></Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"Currency\"><Data ss:Type=\"Number\">" + toplamtutar.ToString().Replace(".", "").Replace(",", ".") + "</Data></Cell>");
            excelDoc.Write("</Row>");


            excelDoc.Write("</Table>");
            excelDoc.Write("</Worksheet>");
            excelDoc.Write("</Workbook>");
            excelDoc.Flush();
            excelDoc.Close();
            Response.End();
        }

        private void ExportToExcelIade(int IadeID)
        {
            Iadeler id = Iadeler.GetObjectsByIadeID(IadeID);
            string carihesap = string.Empty;
            carihesap = CariHesaplar.GetSubeBySMREF(id.SMREF)[1].ToString();
            string fiyattip = FiyatTipleri.GetObjectByID(2);
            string iadetarihi = id.dtOlusmaTarihi.ToShortDateString();
            string iadeonaytarihi = "";
            if (!id.blAktarilmis && id.mnToplamTutar > 0)
                iadeonaytarihi = id.dtOlusmaTarihi.ToShortDateString();
            Musteriler musteri = Musteriler.GetMusteriByID(id.intMusteriID);
            string musteriadsoyad = musteri.strAd + " " + musteri.strSoyad;
            decimal toplamtutar = id.mnToplamTutar;
            string[] aciklama = id.strAciklama.Split(new string[] { ";;;" }, StringSplitOptions.None);
            string Aciklama = aciklama[1] + " " + aciklama[2];
            Aciklama += musteri.tintUyeTipiID == 5 ? " " + musteri.strTelefon : "";

            DataTable dt = new DataTable();
            IadelerDetay.GetObjectsByIadeID(dt, IadeID, 2, true);



            Session["downloadiadeid"] = null;



            string DosyaAdi = "Iade-" + id.pkIadeID.ToString() + ".XLS";
            Response.Clear();
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Buffer = true;
            Response.ContentType = "application/octet-stream";
            Response.AddHeader("content-disposition", "attachment; filename=\"" + DosyaAdi + "\"");
            this.EnableViewState = false;
            System.IO.StreamWriter excelDoc = default(System.IO.StreamWriter);
            excelDoc = new System.IO.StreamWriter(Response.OutputStream);

            #region ExcelXMLbasi
            System.Text.StringBuilder ExcelXMLbasi = new System.Text.StringBuilder();
            ExcelXMLbasi.AppendLine("<?xml version=\"1.0\"?>");
            ExcelXMLbasi.AppendLine("<?mso-application progid=\"Excel.Sheet\"?>");
            ExcelXMLbasi.AppendLine("<Workbook xmlns=\"urn:schemas-microsoft-com:office:spreadsheet\"");
            ExcelXMLbasi.AppendLine(" xmlns:o=\"urn:schemas-microsoft-com:office:office\"");
            ExcelXMLbasi.AppendLine(" xmlns:x=\"urn:schemas- microsoft-com:office:excel\"");
            ExcelXMLbasi.AppendLine(" xmlns:ss=\"urn:schemas-microsoft-com:office:spreadsheet\">");
            ExcelXMLbasi.AppendLine(" <Styles>");
            ExcelXMLbasi.AppendLine(" <Style ss:ID=\"Default\" ss:Name=\"Normal\">");
            ExcelXMLbasi.AppendLine(" <Alignment ss:Vertical=\"Bottom\"/>");
            ExcelXMLbasi.AppendLine(" <Borders/>");
            ExcelXMLbasi.AppendLine(" <Font/>");
            ExcelXMLbasi.AppendLine(" <Interior/>");
            ExcelXMLbasi.AppendLine(" <NumberFormat/>");
            ExcelXMLbasi.AppendLine(" <Protection/>");
            ExcelXMLbasi.AppendLine(" </Style>");
            ExcelXMLbasi.AppendLine(" <Style ss:ID=\"KalinBaslik\">");
            ExcelXMLbasi.AppendLine(" <Font x:Family=\"Swiss\" ss:Bold=\"1\"/>");
            ExcelXMLbasi.AppendLine(" </Style>");
            ExcelXMLbasi.AppendLine(" <Style ss:ID=\"StringLiteral\">");
            ExcelXMLbasi.AppendLine(" <NumberFormat ss:Format=\"@\"/>");
            ExcelXMLbasi.AppendLine(" </Style>");
            ExcelXMLbasi.AppendLine(" <Style ss:ID=\"Decimal\">");
            ExcelXMLbasi.AppendLine(" <NumberFormat ss:Format=\"0\"/>");
            ExcelXMLbasi.AppendLine(" </Style>");
            ExcelXMLbasi.AppendLine(" <Style ss:ID=\"Integer\">");
            ExcelXMLbasi.AppendLine(" <NumberFormat ss:Format=\"0\"/>");
            ExcelXMLbasi.AppendLine(" <Alignment ss:Horizontal=\"Center\" ss:Vertical=\"Bottom\"/>");
            ExcelXMLbasi.AppendLine(" </Style>");
            ExcelXMLbasi.AppendLine(" <Style ss:ID=\"Currency\">");
            ExcelXMLbasi.AppendLine(" <NumberFormat ss:Format=\"0.000 TL\"/>");
            ExcelXMLbasi.AppendLine(" <Alignment ss:Horizontal=\"Right\" ss:Vertical=\"Bottom\"/>");
            ExcelXMLbasi.AppendLine(" </Style>");
            ExcelXMLbasi.AppendLine(" <Style ss:ID=\"DateLiteral\">");
            ExcelXMLbasi.AppendLine(" <NumberFormat ss:Format=\"dd.mm.yyyy;@\"/>");
            ExcelXMLbasi.AppendLine(" </Style>");
            ExcelXMLbasi.AppendLine(" </Styles>");
            excelDoc.Write(ExcelXMLbasi.ToString());
            #endregion

            excelDoc.Write(" <Worksheet ss:Name=\"Rapor\">");
            excelDoc.Write("<Table>" +
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"120.00\"/>" +
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"220.00\"/>" +
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"40.00\"/>" +
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"40.00\"/>" +
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"90.00\"/>" +
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"60.00\"/>" +
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"60.00\"/>" +
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"60.00\"/>" +
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"60.00\"/>" +
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"90.00\"/>");


            excelDoc.Write("<Row>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Siparişi Giren:</Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\">" + musteriadsoyad + "</Data></Cell>");
            excelDoc.Write("</Row>");
            excelDoc.Write("<Row>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Cari Hesap:</Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\">" + carihesap + "</Data></Cell>");
            excelDoc.Write("</Row>");
            excelDoc.Write("<Row>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Fiyat Tipi:</Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\">" + fiyattip + "</Data></Cell>");
            excelDoc.Write("</Row>");
            excelDoc.Write("<Row>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Sipariş Oluşturma Tarihi:</Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\">" + iadetarihi + "</Data></Cell>");
            excelDoc.Write("</Row>");
            excelDoc.Write("<Row>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Sipariş Onay Tarihi:</Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\">" + iadeonaytarihi + "</Data></Cell>");
            excelDoc.Write("</Row>");
            //excelDoc.Write("<Row>");
            //excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Vade:</Data></Cell>");
            //excelDoc.Write("<Cell><Data ss:Type=\"String\">" + vade + "</Data></Cell>");
            //excelDoc.Write("</Row>");
            excelDoc.Write("<Row>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Açıklama:</Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\">" + Aciklama + "</Data></Cell>");
            excelDoc.Write("</Row>");

            excelDoc.Write("<Row>");
            //excelDoc.Write("<Cell><Data ss:Type=\"String\"></Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">::: ÜRÜNLER :::</Data></Cell>");
            excelDoc.Write("</Row>");

            excelDoc.Write("<Row>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Barkod</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Ürün Açıklama</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">KDV</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Miktar</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Brüt Fiyat</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">İskonto 1</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">İskonto 2</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">İskonto 3</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">İskonto 4</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Toplam + KDV</Data></Cell>");
            excelDoc.Write("</Row>");

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                excelDoc.Write("<Row>");
                excelDoc.Write("<Cell ss:StyleID=\"Integer\"><Data ss:Type=\"Number\">" + dt.Rows[i]["BARKOD"].ToString() + "</Data></Cell>");
                excelDoc.Write("<Cell><Data ss:Type=\"String\">" + dt.Rows[i]["strUrunAdi"].ToString() + "</Data></Cell>");
                excelDoc.Write("<Cell ss:StyleID=\"Integer\"><Data ss:Type=\"Number\">" + dt.Rows[i]["KDV"].ToString() + "</Data></Cell>");
                excelDoc.Write("<Cell ss:StyleID=\"Integer\"><Data ss:Type=\"Number\">" + dt.Rows[i]["intMiktar"].ToString() + "</Data></Cell>");
                excelDoc.Write("<Cell ss:StyleID=\"Currency\"><Data ss:Type=\"Number\">" + Convert.ToDecimal(dt.Rows[i]["FIYAT"]).ToString().Replace(".", "").Replace(",", ".") + "</Data></Cell>");
                excelDoc.Write("<Cell ss:StyleID=\"Integer\"><Data ss:Type=\"Number\">" + Convert.ToDouble(dt.Rows[i]["ISK1"]).ToString("N1").Replace(".", "").Replace(",", ".") + "</Data></Cell>");
                excelDoc.Write("<Cell ss:StyleID=\"Integer\"><Data ss:Type=\"Number\">" + Convert.ToDouble(dt.Rows[i]["ISK2"]).ToString("N1").Replace(".", "").Replace(",", ".") + "</Data></Cell>");
                excelDoc.Write("<Cell ss:StyleID=\"Integer\"><Data ss:Type=\"Number\">" + Convert.ToDouble(dt.Rows[i]["ISK3"]).ToString("N1").Replace(".", "").Replace(",", ".") + "</Data></Cell>");
                excelDoc.Write("<Cell ss:StyleID=\"Integer\"><Data ss:Type=\"Number\">" + Convert.ToDouble(dt.Rows[i]["ISK4"]).ToString("N1").Replace(".", "").Replace(",", ".") + "</Data></Cell>");
                excelDoc.Write("<Cell ss:StyleID=\"Currency\"><Data ss:Type=\"Number\">" + (Convert.ToInt32(dt.Rows[i]["intMiktar"]) * Convert.ToDecimal(dt.Rows[i]["mnFiyat"])).ToString().Replace(".", "").Replace(",", ".") + "</Data></Cell>");
                excelDoc.Write("</Row>");
            }

            excelDoc.Write("<Row>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\"></Data></Cell>");
            excelDoc.Write("</Row>");
            excelDoc.Write("<Row>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\"></Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\"></Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\"></Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\"></Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\"></Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\"></Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\"></Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Genel Toplam + KDV:</Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\"></Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"Currency\"><Data ss:Type=\"Number\">" + toplamtutar.ToString().Replace(".", "").Replace(",", ".") + "</Data></Cell>");
            excelDoc.Write("</Row>");


            excelDoc.Write("</Table>");
            excelDoc.Write("</Worksheet>");
            excelDoc.Write("</Workbook>");
            excelDoc.Flush();
            excelDoc.Close();
            Response.End();
        }

        private void ExportToExcelOdeme(int OdemeID)
        {
            Odemeler odeme = Odemeler.GetObject(OdemeID);



            Session["downloadodemeid"] = null;



            string DosyaAdi = "Odeme-" + OdemeID.ToString() + ".XLS";
            Response.Clear();
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Buffer = true;
            Response.ContentType = "application/octet-stream";
            Response.AddHeader("content-disposition", "attachment; filename=\"" + DosyaAdi + "\"");
            this.EnableViewState = false;
            System.IO.StreamWriter excelDoc = default(System.IO.StreamWriter);
            excelDoc = new System.IO.StreamWriter(Response.OutputStream);

            #region ExcelXMLbasi
            System.Text.StringBuilder ExcelXMLbasi = new System.Text.StringBuilder();
            ExcelXMLbasi.AppendLine("<xml version>");
            ExcelXMLbasi.AppendLine("<Workbook xmlns=\"urn:schemas-microsoft-com:office:spreadsheet\"");
            ExcelXMLbasi.AppendLine(" xmlns:o=\"urn:schemas-microsoft-com:office:office\"");
            ExcelXMLbasi.AppendLine(" xmlns:x=\"urn:schemas- microsoft-com:office:excel\"");
            ExcelXMLbasi.AppendLine(" xmlns:ss=\"urn:schemas-microsoft-com:office:spreadsheet\">");
            ExcelXMLbasi.AppendLine(" <Styles>");
            ExcelXMLbasi.AppendLine(" <Style ss:ID=\"Default\" ss:Name=\"Normal\">");
            ExcelXMLbasi.AppendLine(" <Alignment ss:Vertical=\"Bottom\"/>");
            ExcelXMLbasi.AppendLine(" <Borders/>");
            ExcelXMLbasi.AppendLine(" <Font/>");
            ExcelXMLbasi.AppendLine(" <Interior/>");
            ExcelXMLbasi.AppendLine(" <NumberFormat/>");
            ExcelXMLbasi.AppendLine(" <Protection/>");
            ExcelXMLbasi.AppendLine(" </Style>");
            ExcelXMLbasi.AppendLine(" <Style ss:ID=\"KalinBaslik\">");
            ExcelXMLbasi.AppendLine(" <Alignment ss:Horizontal=\"Center\" ss:Vertical=\"Bottom\"/>");
            ExcelXMLbasi.AppendLine(" <Font x:Family=\"Swiss\" ss:Bold=\"1\"/>");
            ExcelXMLbasi.AppendLine(" </Style>");
            ExcelXMLbasi.AppendLine(" <Style ss:ID=\"StringLiteral\">");
            ExcelXMLbasi.AppendLine(" <NumberFormat ss:Format=\"@\"/>");
            ExcelXMLbasi.AppendLine(" </Style>");
            ExcelXMLbasi.AppendLine(" <Style ss:ID=\"Decimal\">");
            ExcelXMLbasi.AppendLine(" <NumberFormat ss:Format=\"0\"/>");
            ExcelXMLbasi.AppendLine(" </Style>");
            ExcelXMLbasi.AppendLine(" <Style ss:ID=\"Integer\">");
            ExcelXMLbasi.AppendLine(" <NumberFormat ss:Format=\"0\"/>");
            ExcelXMLbasi.AppendLine(" <Alignment ss:Horizontal=\"Center\" ss:Vertical=\"Bottom\"/>");
            ExcelXMLbasi.AppendLine(" </Style>");
            ExcelXMLbasi.AppendLine(" <Style ss:ID=\"Currency\">");
            ExcelXMLbasi.AppendLine(" <NumberFormat ss:Format=\"0.000 TL\"/>");
            ExcelXMLbasi.AppendLine(" <Alignment ss:Horizontal=\"Right\" ss:Vertical=\"Bottom\"/>");
            ExcelXMLbasi.AppendLine(" </Style>");
            ExcelXMLbasi.AppendLine(" <Style ss:ID=\"Fiyat\">");
            ExcelXMLbasi.AppendLine(" <Alignment ss:Horizontal=\"Right\" ss:Vertical=\"Bottom\"/>");
            ExcelXMLbasi.AppendLine(" </Style>");
            ExcelXMLbasi.AppendLine(" <Style ss:ID=\"FiyatKalin\">");
            ExcelXMLbasi.AppendLine(" <Alignment ss:Horizontal=\"Right\" ss:Vertical=\"Bottom\"/>");
            ExcelXMLbasi.AppendLine(" <Font x:Family=\"Swiss\" ss:Bold=\"1\"/>");
            ExcelXMLbasi.AppendLine(" </Style>");
            ExcelXMLbasi.AppendLine(" <Style ss:ID=\"DateLiteral\">");
            ExcelXMLbasi.AppendLine(" <NumberFormat ss:Format=\"dd.mm.yyyy;@\"/>");
            ExcelXMLbasi.AppendLine(" </Style>");
            ExcelXMLbasi.AppendLine(" </Styles>");
            excelDoc.Write(ExcelXMLbasi.ToString());
            #endregion

            excelDoc.Write(" <Worksheet ss:Name=\"Rapor\">");
            excelDoc.Write("<Table>" +
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"70.00\"/>" +
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"120.00\"/>" +
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"100.00\"/>" +
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"120.00\"/>" +
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"100.00\"/>" +
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"100.00\"/>" +
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"120.00\"/>");

            excelDoc.Write("<Row>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Sipariş No</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Kredi Kartı</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Tutar</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Ödeme Tarihi</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Provizyon No</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Referans No</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">İşlem No</Data></Cell>");
            excelDoc.Write("</Row>");

            excelDoc.Write("<Row>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\">" + odeme.intSiparisID.ToString() + "</Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\">" + odeme.strMaskedPan + "</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"Fiyat\"><Data ss:Type=\"String\">" + odeme.mnTutar.ToString("C2") + "</Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\">" + odeme.dtOdemeZamani.ToString().Substring(0, 16) + "</Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\">" + odeme.strAuthCode + "</Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\">" + odeme.strHostRefNum + "</Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\">" + odeme.strTransId + "</Data></Cell>");
            excelDoc.Write("</Row>");

            //excelDoc.Write("<Row>");
            //excelDoc.Write("<Cell><Data ss:Type=\"String\"></Data></Cell>");
            //excelDoc.Write("<Cell><Data ss:Type=\"String\"></Data></Cell>");
            //excelDoc.Write("<Cell><Data ss:Type=\"String\"></Data></Cell>");
            //excelDoc.Write("<Cell><Data ss:Type=\"String\"></Data></Cell>");
            //excelDoc.Write("<Cell><Data ss:Type=\"String\"></Data></Cell>");
            //excelDoc.Write("<Cell><Data ss:Type=\"String\"></Data></Cell>");
            //excelDoc.Write("<Cell><Data ss:Type=\"String\"></Data></Cell>");
            //excelDoc.Write("</Row>");
            //excelDoc.Write("<Row>");
            //excelDoc.Write("<Cell><Data ss:Type=\"String\"></Data></Cell>");
            //excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Toplam:</Data></Cell>");
            //excelDoc.Write("<Cell ss:StyleID=\"Fiyat\"><Data ss:Type=\"String\">" + odeme.mnTutar + "</Data></Cell>");
            //excelDoc.Write("<Cell><Data ss:Type=\"String\"></Data></Cell>");
            //excelDoc.Write("<Cell><Data ss:Type=\"String\"></Data></Cell>");
            //excelDoc.Write("<Cell><Data ss:Type=\"String\"></Data></Cell>");
            //excelDoc.Write("<Cell><Data ss:Type=\"String\"></Data></Cell>");
            //excelDoc.Write("</Row>");


            excelDoc.Write("</Table>");
            excelDoc.Write("</Worksheet>");
            excelDoc.Write("</Workbook>");
            excelDoc.Flush();
            excelDoc.Close();
            Response.End();
        }

        private void ExportToExcelAktivite(int AktiviteID)
        {
            Aktiviteler akt = Aktiviteler.GetObject(AktiviteID);
            string bayi = string.Empty;
            string carihesap = string.Empty;
            if (akt.sintFiyatTipiID == 25)
            {
                bayi = CariHesaplarTP.GetObject(akt.SMREF, true).MUSTERI;
                carihesap = CariHesaplarTP.GetObject(akt.SMREF, false).SUBE;
            }
            else
            {
                bayi = "SULTANLAR PAZARLAMA A.Ş.";
                carihesap = CariHesaplar.GetMUSTERIbySMREFmusterisube(akt.SMREF);
            }
            string fiyattip = FiyatTipleri.GetObjectByID(akt.sintFiyatTipiID);
            string siparistarihi = akt.dtOlusmaTarihi.ToString();
            string siparisonaytarihi = "";
            if (akt.blAktarilmis)
                siparisonaytarihi = akt.dtOlusmaTarihi.ToString();
            string aktivitebaslangic = akt.dtAktiviteBaslangic.ToShortDateString();
            string aktivitebitis = akt.dtAktiviteBitis.ToShortDateString();
            Musteriler musteri = Musteriler.GetMusteriByID(akt.intMusteriID);
            string musteriadsoyad = musteri.strAd + " " + musteri.strSoyad;
            string Aciklama = akt.strAciklama1 + " - " + akt.strAciklama2 + " - " + akt.strAciklama3;

            DataTable dt = new DataTable();
            AktivitelerDetay.GetObjectsByAktiviteID(dt, AktiviteID);



            Session["downloadaktiviteid"] = null;



            string DosyaAdi = "Aktivite-" + akt.pkID.ToString() + ".XLS";
            Response.Clear();
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Buffer = true;
            Response.ContentType = "application/octet-stream";
            Response.AddHeader("content-disposition", "attachment; filename=\"" + DosyaAdi + "\"");
            this.EnableViewState = false;
            System.IO.StreamWriter excelDoc = default(System.IO.StreamWriter);
            excelDoc = new System.IO.StreamWriter(Response.OutputStream);

            #region ExcelXMLbasi
            System.Text.StringBuilder ExcelXMLbasi = new System.Text.StringBuilder();
            ExcelXMLbasi.AppendLine("<?xml version=\"1.0\"?>");
            ExcelXMLbasi.AppendLine("<?mso-application progid=\"Excel.Sheet\"?>");
            ExcelXMLbasi.AppendLine("<Workbook xmlns=\"urn:schemas-microsoft-com:office:spreadsheet\"");
            ExcelXMLbasi.AppendLine(" xmlns:o=\"urn:schemas-microsoft-com:office:office\"");
            ExcelXMLbasi.AppendLine(" xmlns:x=\"urn:schemas- microsoft-com:office:excel\"");
            ExcelXMLbasi.AppendLine(" xmlns:ss=\"urn:schemas-microsoft-com:office:spreadsheet\">");
            ExcelXMLbasi.AppendLine(" <Styles>");
            ExcelXMLbasi.AppendLine(" <Style ss:ID=\"Default\" ss:Name=\"Normal\">");
            ExcelXMLbasi.AppendLine(" <Alignment ss:Vertical=\"Bottom\"/>");
            ExcelXMLbasi.AppendLine(" <Borders/>");
            ExcelXMLbasi.AppendLine(" <Font/>");
            ExcelXMLbasi.AppendLine(" <Interior/>");
            ExcelXMLbasi.AppendLine(" <NumberFormat/>");
            ExcelXMLbasi.AppendLine(" <Protection/>");
            ExcelXMLbasi.AppendLine(" </Style>");
            ExcelXMLbasi.AppendLine(" <Style ss:ID=\"KalinBaslik\">");
            ExcelXMLbasi.AppendLine(" <Font x:Family=\"Swiss\" ss:Bold=\"1\"/>");
            ExcelXMLbasi.AppendLine(" </Style>");
            ExcelXMLbasi.AppendLine(" <Style ss:ID=\"StringLiteral\">");
            ExcelXMLbasi.AppendLine(" <NumberFormat ss:Format=\"@\"/>");
            ExcelXMLbasi.AppendLine(" </Style>");
            ExcelXMLbasi.AppendLine(" <Style ss:ID=\"Decimal\">");
            ExcelXMLbasi.AppendLine(" <NumberFormat ss:Format=\"0\"/>");
            ExcelXMLbasi.AppendLine(" </Style>");
            ExcelXMLbasi.AppendLine(" <Style ss:ID=\"Integer\">");
            ExcelXMLbasi.AppendLine(" <NumberFormat ss:Format=\"0\"/>");
            ExcelXMLbasi.AppendLine(" <Alignment ss:Horizontal=\"Center\" ss:Vertical=\"Bottom\"/>");
            ExcelXMLbasi.AppendLine(" </Style>");
            ExcelXMLbasi.AppendLine(" <Style ss:ID=\"Currency\">");
            ExcelXMLbasi.AppendLine(" <NumberFormat ss:Format=\"0.00 TL\"/>");
            ExcelXMLbasi.AppendLine(" <Alignment ss:Horizontal=\"Right\" ss:Vertical=\"Bottom\"/>");
            ExcelXMLbasi.AppendLine(" </Style>");
            ExcelXMLbasi.AppendLine(" <Style ss:ID=\"DateLiteral\">");
            ExcelXMLbasi.AppendLine(" <NumberFormat ss:Format=\"dd.mm.yyyy;@\"/>");
            ExcelXMLbasi.AppendLine(" </Style>");
            ExcelXMLbasi.AppendLine(" </Styles>");
            excelDoc.Write(ExcelXMLbasi.ToString());
            #endregion

            excelDoc.Write(" <Worksheet ss:Name=\"Aktivite\">");
            excelDoc.Write("<Table>" +
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"130.00\"/>" +
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"220.00\"/>" +
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"80.00\"/>" +
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"60.00\"/>" +
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"60.00\"/>" +
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"60.00\"/>" +
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"60.00\"/>" +
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"60.00\"/>" +
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"80.00\"/>" +
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"80.00\"/>" +
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"70.00\"/>" +
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"60.00\"/>" +
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"100.00\"/>" +
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"100.00\"/>" +
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"100.00\"/>" +
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"100.00\"/>");


            excelDoc.Write("<Row>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Aktivite No:</Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\">" + akt.pkID.ToString() + "</Data></Cell>");
            excelDoc.Write("</Row>");
            excelDoc.Write("<Row>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Aktiviteyi Giren:</Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\">" + musteriadsoyad + "</Data></Cell>");
            excelDoc.Write("</Row>");
            excelDoc.Write("<Row>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Cari Hesap:</Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\">" + bayi + "</Data></Cell>");
            excelDoc.Write("</Row>");
            excelDoc.Write("<Row>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Cari Hesap:</Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\">" + carihesap + "</Data></Cell>");
            excelDoc.Write("</Row>");
            //excelDoc.Write("<Row>");
            //excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Fiyat Tipi:</Data></Cell>");
            //excelDoc.Write("<Cell><Data ss:Type=\"String\">" + fiyattip + "</Data></Cell>");
            //excelDoc.Write("</Row>");
            excelDoc.Write("<Row>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Aktivite Oluşturma Tarihi:</Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\">" + siparistarihi + "</Data></Cell>");
            excelDoc.Write("</Row>");
            excelDoc.Write("<Row>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Aktivite Onay Tarihi:</Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\">" + siparisonaytarihi + "</Data></Cell>");
            excelDoc.Write("</Row>");
            excelDoc.Write("<Row>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Aktivite Başlangıç Tarihi:</Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\">" + aktivitebaslangic + "</Data></Cell>");
            excelDoc.Write("</Row>");
            excelDoc.Write("<Row>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Aktivite Bitiş Tarihi:</Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\">" + aktivitebitis + "</Data></Cell>");
            excelDoc.Write("</Row>");
            excelDoc.Write("<Row>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Açıklama:</Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\">" + Aciklama + "</Data></Cell>");
            excelDoc.Write("</Row>");

            excelDoc.Write("<Row>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\"></Data></Cell>");
            excelDoc.Write("</Row>");

            excelDoc.Write("<Row>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Ürt.Kod</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Ürün</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Barkod</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Koli İçi</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">F.Alt.İsk.</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">F.Alt.Ciro</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Paz.İsk.</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Ciro P.Dön.Y.</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Birim Fiyat</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Ön.Aks.Fiyatı</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Sat.Hed.Koli</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Ek İsk.</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">C.P.D.KDV D.B.F.</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Fat.Bas.Bir.F.KDV'siz</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Fat.Bas.Bir.F.KDV'li</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Toplam</Data></Cell>");
            excelDoc.Write("</Row>");

            double toplamtutar = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                double kdvsiz = dt.Rows[i]["mnDusulmusBirimFiyatKDVsiz"] != DBNull.Value ? Convert.ToDouble(dt.Rows[i]["mnDusulmusBirimFiyatKDVsiz"]) : 0;
                string urtkod = dt.Rows[i]["URTKOD"] != DBNull.Value ? dt.Rows[i]["URTKOD"].ToString() : "";

                toplamtutar += Convert.ToDouble(dt.Rows[i]["mnDusulmusBirimFiyatKDVli"]) * Convert.ToInt32(dt.Rows[i]["strSatisHedefi"]) * Convert.ToInt32(dt.Rows[i]["intKoliAdet"]);
                excelDoc.Write("<Row>");
                excelDoc.Write("<Cell ss:StyleID=\"Integer\"><Data ss:Type=\"Number\">" + urtkod + "</Data></Cell>");
                excelDoc.Write("<Cell><Data ss:Type=\"String\">" + dt.Rows[i]["strUrunAdi"].ToString() + "</Data></Cell>");
                excelDoc.Write("<Cell ss:StyleID=\"Integer\"><Data ss:Type=\"Number\">" + Urunler.GetProductBarkod(Convert.ToInt32(dt.Rows[i]["intUrunID"])) + "</Data></Cell>");
                excelDoc.Write("<Cell ss:StyleID=\"Integer\"><Data ss:Type=\"Number\">" + dt.Rows[i]["intKoliAdet"].ToString() + "</Data></Cell>");
                excelDoc.Write("<Cell ss:StyleID=\"Integer\"><Data ss:Type=\"Number\">" + Convert.ToDouble(dt.Rows[i]["strAciklama1"]).ToString("N1").Replace(".", "").Replace(",", ".") + "</Data></Cell>");
                excelDoc.Write("<Cell ss:StyleID=\"Integer\"><Data ss:Type=\"Number\">" + Convert.ToDouble(dt.Rows[i]["strAciklama2"]).ToString("N1").Replace(".", "").Replace(",", ".") + "</Data></Cell>");
                excelDoc.Write("<Cell ss:StyleID=\"Integer\"><Data ss:Type=\"Number\">" + Convert.ToDouble(dt.Rows[i]["strAciklama3"]).ToString("N1").Replace(".", "").Replace(",", ".") + "</Data></Cell>");
                excelDoc.Write("<Cell ss:StyleID=\"Integer\"><Data ss:Type=\"Number\">" + Convert.ToDouble(dt.Rows[i]["flCiroPrimDonusYuzde"]).ToString("N1").Replace(".", "").Replace(",", ".") + "</Data></Cell>");
                excelDoc.Write("<Cell ss:StyleID=\"Currency\"><Data ss:Type=\"Number\">" + Convert.ToDouble(dt.Rows[i]["mnBirimFiyatKDVli"]).ToString("N2").Replace(".", "").Replace(",", ".") + "</Data></Cell>");
                excelDoc.Write("<Cell ss:StyleID=\"Currency\"><Data ss:Type=\"Number\">" + Convert.ToDouble(dt.Rows[i]["mnAksiyonFiyati"]).ToString("N2").Replace(".", "").Replace(",", ".") + "</Data></Cell>");
                excelDoc.Write("<Cell><Data ss:Type=\"String\">" + dt.Rows[i]["strSatisHedefi"].ToString() + "</Data></Cell>");
                excelDoc.Write("<Cell ss:StyleID=\"Integer\"><Data ss:Type=\"Number\">" + Convert.ToDouble(dt.Rows[i]["flEkIsk"]).ToString("N1").Replace(".", "").Replace(",", ".") + "</Data></Cell>");
                excelDoc.Write("<Cell ss:StyleID=\"Currency\"><Data ss:Type=\"Number\">" + Convert.ToDouble(dt.Rows[i]["mnTutar"]).ToString("N2").Replace(".", "").Replace(",", ".") + "</Data></Cell>");
                excelDoc.Write("<Cell ss:StyleID=\"Currency\"><Data ss:Type=\"Number\">" + kdvsiz.ToString("N2").Replace(".", "").Replace(",", ".") + "</Data></Cell>");
                excelDoc.Write("<Cell ss:StyleID=\"Currency\"><Data ss:Type=\"Number\">" + Convert.ToDouble(dt.Rows[i]["mnDusulmusBirimFiyatKDVli"]).ToString("N2").Replace(".", "").Replace(",", ".") + "</Data></Cell>");
                excelDoc.Write("<Cell ss:StyleID=\"Currency\"><Data ss:Type=\"Number\">" + (Convert.ToDouble(dt.Rows[i]["mnDusulmusBirimFiyatKDVli"]) * Convert.ToInt32(dt.Rows[i]["strSatisHedefi"]) * Convert.ToInt32(dt.Rows[i]["intKoliAdet"])).ToString("N2").Replace(".", "").Replace(",", ".") + "</Data></Cell>");
                excelDoc.Write("</Row>");
            }

            excelDoc.Write("<Row>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\"></Data></Cell>");
            excelDoc.Write("</Row>");
            excelDoc.Write("<Row>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\"></Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\"></Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\"></Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\"></Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\"></Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\"></Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\"></Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\"></Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\"></Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\"></Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\"></Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\"></Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\"></Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\"></Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Genel Toplam:</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"Currency\"><Data ss:Type=\"Number\">" + toplamtutar.ToString().Replace(".", "").Replace(",", ".") + "</Data></Cell>");
            excelDoc.Write("</Row>");


            excelDoc.Write("</Table>");
            excelDoc.Write("</Worksheet>");
            excelDoc.Write("</Workbook>");
            excelDoc.Flush();
            excelDoc.Close();
            Response.End();
        }

        private void ExportToExcelHizmet(int HizmetID)
        {
            AnlasmaHizmetBedelleri hizmet = AnlasmaHizmetBedelleri.GetObject(HizmetID);
            string bayi = CariHesaplarTP.GetObject(hizmet.SMREF, true).MUSTERI;
            string carihesap = CariHesaplarTP.GetObject(hizmet.SMREF, false).SUBE;
            Musteriler musteri = Musteriler.GetMusteriByID(hizmet.intMusteriID);
            string musteriadsoyad = musteri.strAd + " " + musteri.strSoyad;
            //string Aciklama = hizmet.strAciklama1 + " - " + hizmet.strAciklama2 + " - " + hizmet.strAciklama3 + " - " + hizmet.strAciklama4;



            Session["downloadhizmetid"] = null;



            string DosyaAdi = "HizmetBedeli-" + hizmet.pkID.ToString() + ".XLS";
            Response.Clear();
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Buffer = true;
            Response.ContentType = "application/octet-stream";
            Response.AddHeader("content-disposition", "attachment; filename=\"" + DosyaAdi + "\"");
            this.EnableViewState = false;
            System.IO.StreamWriter excelDoc = default(System.IO.StreamWriter);
            excelDoc = new System.IO.StreamWriter(Response.OutputStream);

            #region ExcelXMLbasi
            System.Text.StringBuilder ExcelXMLbasi = new System.Text.StringBuilder();
            ExcelXMLbasi.AppendLine("<?xml version=\"1.0\"?>");
            ExcelXMLbasi.AppendLine("<?mso-application progid=\"Excel.Sheet\"?>");
            ExcelXMLbasi.AppendLine("<Workbook xmlns=\"urn:schemas-microsoft-com:office:spreadsheet\"");
            ExcelXMLbasi.AppendLine(" xmlns:o=\"urn:schemas-microsoft-com:office:office\"");
            ExcelXMLbasi.AppendLine(" xmlns:x=\"urn:schemas- microsoft-com:office:excel\"");
            ExcelXMLbasi.AppendLine(" xmlns:ss=\"urn:schemas-microsoft-com:office:spreadsheet\">");
            ExcelXMLbasi.AppendLine(" <Styles>");
            ExcelXMLbasi.AppendLine(" <Style ss:ID=\"Default\" ss:Name=\"Normal\">");
            ExcelXMLbasi.AppendLine(" <Alignment ss:Vertical=\"Bottom\"/>");
            ExcelXMLbasi.AppendLine(" <Borders/>");
            ExcelXMLbasi.AppendLine(" <Font/>");
            ExcelXMLbasi.AppendLine(" <Interior/>");
            ExcelXMLbasi.AppendLine(" <NumberFormat/>");
            ExcelXMLbasi.AppendLine(" <Protection/>");
            ExcelXMLbasi.AppendLine(" </Style>");
            ExcelXMLbasi.AppendLine(" <Style ss:ID=\"KalinBaslik\">");
            ExcelXMLbasi.AppendLine(" <Font x:Family=\"Swiss\" ss:Bold=\"1\"/>");
            ExcelXMLbasi.AppendLine(" </Style>");
            ExcelXMLbasi.AppendLine(" <Style ss:ID=\"StringLiteral\">");
            ExcelXMLbasi.AppendLine(" <NumberFormat ss:Format=\"@\"/>");
            ExcelXMLbasi.AppendLine(" </Style>");
            ExcelXMLbasi.AppendLine(" <Style ss:ID=\"Decimal\">");
            ExcelXMLbasi.AppendLine(" <NumberFormat ss:Format=\"0\"/>");
            ExcelXMLbasi.AppendLine(" </Style>");
            ExcelXMLbasi.AppendLine(" <Style ss:ID=\"Integer\">");
            ExcelXMLbasi.AppendLine(" <NumberFormat ss:Format=\"0\"/>");
            ExcelXMLbasi.AppendLine(" <Alignment ss:Horizontal=\"Center\" ss:Vertical=\"Bottom\"/>");
            ExcelXMLbasi.AppendLine(" </Style>");
            ExcelXMLbasi.AppendLine(" <Style ss:ID=\"Currency\">");
            ExcelXMLbasi.AppendLine(" <NumberFormat ss:Format=\"0.00 TL\"/>");
            ExcelXMLbasi.AppendLine(" <Alignment ss:Horizontal=\"Right\" ss:Vertical=\"Bottom\"/>");
            ExcelXMLbasi.AppendLine(" </Style>");
            ExcelXMLbasi.AppendLine(" <Style ss:ID=\"DateLiteral\">");
            ExcelXMLbasi.AppendLine(" <NumberFormat ss:Format=\"dd.mm.yyyy;@\"/>");
            ExcelXMLbasi.AppendLine(" </Style>");
            ExcelXMLbasi.AppendLine(" </Styles>");
            excelDoc.Write(ExcelXMLbasi.ToString());
            #endregion

            excelDoc.Write(" <Worksheet ss:Name=\"Hizmet Bedeli\">");
            excelDoc.Write("<Table>" +
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"130.00\"/>" +
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"250.00\"/>");

            excelDoc.Write("<Row>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Hizmet Bedelini Giren:</Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\">" + musteriadsoyad + "</Data></Cell>");
            excelDoc.Write("</Row>");
            excelDoc.Write("<Row>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Bayi:</Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\">" + bayi + "</Data></Cell>");
            excelDoc.Write("</Row>");
            excelDoc.Write("<Row>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Alt Cari:</Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\">" + carihesap + "</Data></Cell>");
            excelDoc.Write("</Row>");
            excelDoc.Write("<Row>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Dönem Yıl:</Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\">" + hizmet.intYil.ToString() + "</Data></Cell>");
            excelDoc.Write("</Row>");
            excelDoc.Write("<Row>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Dönem Ay:</Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\">" + hizmet.intAy.ToString() + "</Data></Cell>");
            excelDoc.Write("</Row>");
            excelDoc.Write("<Row>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Fatura Tarihi:</Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\">" + hizmet.dtFaturaTarih.ToShortDateString() + "</Data></Cell>");
            excelDoc.Write("</Row>");
            excelDoc.Write("<Row>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Fatura No:</Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\">" + hizmet.strFaturaNo + "</Data></Cell>");
            excelDoc.Write("</Row>");
            excelDoc.Write("<Row>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">KGT Bedel:</Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\">" + hizmet.mnTAHBedel.ToString("N2").Replace(".", "").Replace(",", ".") + "</Data></Cell>");
            excelDoc.Write("</Row>");
            excelDoc.Write("<Row>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">NF Bedel:</Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\">" + hizmet.mnYEGBedel.ToString("N2").Replace(".", "").Replace(",", ".") + "</Data></Cell>");
            excelDoc.Write("</Row>");
            excelDoc.Write("<Row>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Açıklama:</Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\">" + hizmet.strAciklama1 + "</Data></Cell>");
            excelDoc.Write("</Row>");
            excelDoc.Write("<Row>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Kapama Dönemi Yıl::</Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\">" + Convert.ToInt32(hizmet.mnMudurButce).ToString() + "</Data></Cell>");
            excelDoc.Write("</Row>");
            excelDoc.Write("<Row>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Kapama Dönemi Ay:</Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\">" + Convert.ToInt32(hizmet.mnElemanButce).ToString() + "</Data></Cell>");
            excelDoc.Write("</Row>");

            excelDoc.Write("</Table>");
            excelDoc.Write("</Worksheet>");
            excelDoc.Write("</Workbook>");
            excelDoc.Flush();
            excelDoc.Close();
            Response.End();
        }

        private void ExportToExcelHizmetler(int REF, int Onayli, DateTime Baslangic, DateTime Bitis, bool GMREF)
        {
            object onayli;
            switch (Onayli)
            {
                case 1:
                    onayli = true;
                    break;
                case 0:
                    onayli = false;
                    break;
                default:
                    onayli = DBNull.Value;
                    break;
            }

            string bayi = CariHesaplarTP.GetObject(REF, true).MUSTERI;
            string carihesap = string.Empty;

            DataTable dt = new DataTable();
            if (GMREF)
            {
                ArrayList smrefs = new ArrayList();
                CariHesaplarTP.GetSMREFsByGMREF(smrefs, REF);
                AnlasmaHizmetBedelleri.GetObjects(dt, smrefs, onayli, Baslangic, Bitis, 0, 10000);

                Session["downloadhizmetlergmref"] = null;
            }
            else
            {
                AnlasmaHizmetBedelleri.GetObjects(dt, REF, onayli, Baslangic, Bitis, 0, 10000);
                carihesap = CariHesaplarTP.GetObject(REF, false).SUBE;

                Session["downloadhizmetlersmref"] = null;
            }



            Session["downloadhizmetleronayli"] = null;
            Session["downloadhizmetlertarihbaslangic"] = null;
            Session["downloadhizmetlertarihbaslangic"] = null;



            string DosyaAdi = "HizmetBedelleri-" + carihesap + ".XLS";
            Response.Clear();
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Buffer = true;
            Response.ContentType = "application/octet-stream";
            Response.AddHeader("content-disposition", "attachment; filename=\"" + DosyaAdi + "\"");
            this.EnableViewState = false;
            System.IO.StreamWriter excelDoc = default(System.IO.StreamWriter);
            excelDoc = new System.IO.StreamWriter(Response.OutputStream);

            #region ExcelXMLbasi
            System.Text.StringBuilder ExcelXMLbasi = new System.Text.StringBuilder();
            ExcelXMLbasi.AppendLine("<?xml version=\"1.0\"?>");
            ExcelXMLbasi.AppendLine("<?mso-application progid=\"Excel.Sheet\"?>");
            ExcelXMLbasi.AppendLine("<Workbook xmlns=\"urn:schemas-microsoft-com:office:spreadsheet\"");
            ExcelXMLbasi.AppendLine(" xmlns:o=\"urn:schemas-microsoft-com:office:office\"");
            ExcelXMLbasi.AppendLine(" xmlns:x=\"urn:schemas- microsoft-com:office:excel\"");
            ExcelXMLbasi.AppendLine(" xmlns:ss=\"urn:schemas-microsoft-com:office:spreadsheet\">");
            ExcelXMLbasi.AppendLine(" <Styles>");
            ExcelXMLbasi.AppendLine(" <Style ss:ID=\"Default\" ss:Name=\"Normal\">");
            ExcelXMLbasi.AppendLine(" <Alignment ss:Vertical=\"Bottom\"/>");
            ExcelXMLbasi.AppendLine(" <Borders/>");
            ExcelXMLbasi.AppendLine(" <Font/>");
            ExcelXMLbasi.AppendLine(" <Interior/>");
            ExcelXMLbasi.AppendLine(" <NumberFormat/>");
            ExcelXMLbasi.AppendLine(" <Protection/>");
            ExcelXMLbasi.AppendLine(" </Style>");
            ExcelXMLbasi.AppendLine(" <Style ss:ID=\"KalinBaslik\">");
            ExcelXMLbasi.AppendLine(" <Font x:Family=\"Swiss\" ss:Bold=\"1\"/>");
            ExcelXMLbasi.AppendLine(" <Alignment ss:Horizontal=\"Center\" ss:Vertical=\"Bottom\"/>");
            ExcelXMLbasi.AppendLine(" </Style>");
            ExcelXMLbasi.AppendLine(" <Style ss:ID=\"StringLiteral\">");
            ExcelXMLbasi.AppendLine(" <NumberFormat ss:Format=\"@\"/>");
            ExcelXMLbasi.AppendLine(" </Style>");
            ExcelXMLbasi.AppendLine(" <Style ss:ID=\"Decimal\">");
            ExcelXMLbasi.AppendLine(" <NumberFormat ss:Format=\"0\"/>");
            ExcelXMLbasi.AppendLine(" </Style>");
            ExcelXMLbasi.AppendLine(" <Style ss:ID=\"Integer\">");
            ExcelXMLbasi.AppendLine(" <NumberFormat ss:Format=\"0\"/>");
            ExcelXMLbasi.AppendLine(" <Alignment ss:Horizontal=\"Center\" ss:Vertical=\"Bottom\"/>");
            ExcelXMLbasi.AppendLine(" </Style>");
            ExcelXMLbasi.AppendLine(" <Style ss:ID=\"Currency\">");
            ExcelXMLbasi.AppendLine(" <NumberFormat ss:Format=\"0.00 TL\"/>");
            ExcelXMLbasi.AppendLine(" <Alignment ss:Horizontal=\"Right\" ss:Vertical=\"Bottom\"/>");
            ExcelXMLbasi.AppendLine(" </Style>");
            ExcelXMLbasi.AppendLine(" <Style ss:ID=\"DateLiteral\">");
            ExcelXMLbasi.AppendLine(" <NumberFormat ss:Format=\"dd.mm.yyyy;@\"/>");
            ExcelXMLbasi.AppendLine(" </Style>");
            ExcelXMLbasi.AppendLine(" </Styles>");
            excelDoc.Write(ExcelXMLbasi.ToString());
            #endregion

            excelDoc.Write(" <Worksheet ss:Name=\"Hizmet Bedeli\">");
            excelDoc.Write("<Table>" +
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"250.00\"/>" +
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"250.00\"/>" +
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"100.00\"/>" +
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"40.00\"/>" +
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"40.00\"/>" +
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"80.00\"/>" +
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"80.00\"/>" +
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"80.00\"/>" +
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"80.00\"/>" +
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"120.00\"/>" +
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"120.00\"/>" +
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"300.00\"/>");

            excelDoc.Write("<Row>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Bayi</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Alt Cari</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Bedel</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Yıl</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Ay</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Fatura Tarihi</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Fatura No</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">KGT Bedel</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">NF Bedel</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Kapama Dönemi Yıl</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Kapama Dönemi Ay</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Açıklama</Data></Cell>");
            excelDoc.Write("</Row>");

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                excelDoc.Write("<Row>");
                excelDoc.Write("<Cell><Data ss:Type=\"String\">" + bayi + "</Data></Cell>");
                excelDoc.Write("<Cell><Data ss:Type=\"String\">" + CariHesaplarTP.GetObject(Convert.ToInt32(dt.Rows[i]["SMREF"]), false).SUBE + "</Data></Cell>");
                excelDoc.Write("<Cell><Data ss:Type=\"String\">" + dt.Rows[i]["Bedel"].ToString() + "</Data></Cell>");
                excelDoc.Write("<Cell><Data ss:Type=\"String\">" + dt.Rows[i]["intYil"].ToString() + "</Data></Cell>");
                excelDoc.Write("<Cell><Data ss:Type=\"String\">" + dt.Rows[i]["intAy"].ToString() + "</Data></Cell>");
                excelDoc.Write("<Cell><Data ss:Type=\"String\">" + Convert.ToDateTime(dt.Rows[i]["dtFaturaTarih"]).ToShortDateString() + "</Data></Cell>");
                excelDoc.Write("<Cell><Data ss:Type=\"String\">" + dt.Rows[i]["strFaturaNo"].ToString() + "</Data></Cell>");
                excelDoc.Write("<Cell ss:StyleID=\"Currency\"><Data ss:Type=\"String\">" + Convert.ToDecimal(dt.Rows[i]["mnTAHBedel"]).ToString("N2").Replace(".", "").Replace(",", ".") + "</Data></Cell>");
                excelDoc.Write("<Cell ss:StyleID=\"Currency\"><Data ss:Type=\"String\">" + Convert.ToDecimal(dt.Rows[i]["mnYEGBedel"]).ToString("N2").Replace(".", "").Replace(",", ".") + "</Data></Cell>");
                excelDoc.Write("<Cell ss:StyleID=\"Currency\"><Data ss:Type=\"String\">" + Convert.ToInt32(dt.Rows[i]["mnMudurButcesi"]).ToString() + "</Data></Cell>");
                excelDoc.Write("<Cell ss:StyleID=\"Currency\"><Data ss:Type=\"String\">" + Convert.ToInt32(dt.Rows[i]["mnElemanButcesi"]).ToString() + "</Data></Cell>");
                excelDoc.Write("<Cell><Data ss:Type=\"String\">" + dt.Rows[i]["strAciklama1"].ToString() + "</Data></Cell>");
                excelDoc.Write("</Row>");
            }

            excelDoc.Write("</Table>");
            excelDoc.Write("</Worksheet>");
            excelDoc.Write("</Workbook>");
            excelDoc.Flush();
            excelDoc.Close();
            Response.End();
        }




        private void ExportToExcelEkstre(int GMREF)
        {
            DataTable dt = GetEkstrelerByGMREF(GMREF);
            ArrayList toplamlar = GetEkstrelerToplam(GMREF);



            Session["downloadekstregmref"] = null;



            string DosyaAdi = "Ekstre-" + CariHesaplar.GetMUSTERIbyGMREF(GMREF) + ".XLS";
            Response.Clear();
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Buffer = true;
            Response.ContentType = "application/octet-stream";
            Response.AddHeader("content-disposition", "attachment; filename=\"" + DosyaAdi + "\"");
            //this.EnableViewState = false;
            System.IO.StreamWriter excelDoc = default(System.IO.StreamWriter);
            excelDoc = new System.IO.StreamWriter(Response.OutputStream);

            #region ExcelXMLbasi
            System.Text.StringBuilder ExcelXMLbasi = new System.Text.StringBuilder();
            ExcelXMLbasi.AppendLine("<xml version>");
            ExcelXMLbasi.AppendLine("<Workbook xmlns=\"urn:schemas-microsoft-com:office:spreadsheet\"");
            ExcelXMLbasi.AppendLine(" xmlns:o=\"urn:schemas-microsoft-com:office:office\"");
            ExcelXMLbasi.AppendLine(" xmlns:x=\"urn:schemas- microsoft-com:office:excel\"");
            ExcelXMLbasi.AppendLine(" xmlns:ss=\"urn:schemas-microsoft-com:office:spreadsheet\">");
            ExcelXMLbasi.AppendLine(" <Styles>");
            ExcelXMLbasi.AppendLine(" <Style ss:ID=\"Default\" ss:Name=\"Normal\">");
            ExcelXMLbasi.AppendLine(" <Alignment ss:Vertical=\"Bottom\"/>");
            ExcelXMLbasi.AppendLine(" <Borders/>");
            ExcelXMLbasi.AppendLine(" <Font/>");
            ExcelXMLbasi.AppendLine(" <Interior/>");
            ExcelXMLbasi.AppendLine(" <NumberFormat/>");
            ExcelXMLbasi.AppendLine(" <Protection/>");
            ExcelXMLbasi.AppendLine(" </Style>");
            ExcelXMLbasi.AppendLine(" <Style ss:ID=\"KalinBaslik\">");
            ExcelXMLbasi.AppendLine(" <Alignment ss:Horizontal=\"Center\" ss:Vertical=\"Bottom\"/>");
            ExcelXMLbasi.AppendLine(" <Font x:Family=\"Swiss\" ss:Bold=\"1\"/>");
            ExcelXMLbasi.AppendLine(" </Style>");
            ExcelXMLbasi.AppendLine(" <Style ss:ID=\"StringLiteral\">");
            ExcelXMLbasi.AppendLine(" <NumberFormat ss:Format=\"@\"/>");
            ExcelXMLbasi.AppendLine(" </Style>");
            ExcelXMLbasi.AppendLine(" <Style ss:ID=\"Decimal\">");
            ExcelXMLbasi.AppendLine(" <NumberFormat ss:Format=\"0\"/>");
            ExcelXMLbasi.AppendLine(" </Style>");
            ExcelXMLbasi.AppendLine(" <Style ss:ID=\"Integer\">");
            ExcelXMLbasi.AppendLine(" <NumberFormat ss:Format=\"0\"/>");
            ExcelXMLbasi.AppendLine(" <Alignment ss:Horizontal=\"Center\" ss:Vertical=\"Bottom\"/>");
            ExcelXMLbasi.AppendLine(" </Style>");
            ExcelXMLbasi.AppendLine(" <Style ss:ID=\"Currency\">");
            ExcelXMLbasi.AppendLine(" <NumberFormat ss:Format=\"0.000 TL\"/>");
            ExcelXMLbasi.AppendLine(" <Alignment ss:Horizontal=\"Right\" ss:Vertical=\"Bottom\"/>");
            ExcelXMLbasi.AppendLine(" </Style>");
            ExcelXMLbasi.AppendLine(" <Style ss:ID=\"Fiyat\">");
            ExcelXMLbasi.AppendLine(" <Alignment ss:Horizontal=\"Right\" ss:Vertical=\"Bottom\"/>");
            ExcelXMLbasi.AppendLine(" </Style>");
            ExcelXMLbasi.AppendLine(" <Style ss:ID=\"FiyatKalin\">");
            ExcelXMLbasi.AppendLine(" <Alignment ss:Horizontal=\"Right\" ss:Vertical=\"Bottom\"/>");
            ExcelXMLbasi.AppendLine(" <Font x:Family=\"Swiss\" ss:Bold=\"1\"/>");
            ExcelXMLbasi.AppendLine(" </Style>");
            ExcelXMLbasi.AppendLine(" <Style ss:ID=\"DateLiteral\">");
            ExcelXMLbasi.AppendLine(" <NumberFormat ss:Format=\"dd.mm.yyyy;@\"/>");
            ExcelXMLbasi.AppendLine(" </Style>");
            ExcelXMLbasi.AppendLine(" </Styles>");
            excelDoc.Write(ExcelXMLbasi.ToString());
            #endregion

            excelDoc.Write(" <Worksheet ss:Name=\"Rapor\">");
            excelDoc.Write("<Table>" +
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"70.00\"/>" +
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"70.00\"/>" +
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"70.00\"/>" +
                //"<Column ss:AutoFitWidth=\"0\" ss:Width=\"180.00\"/>" +
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"90.00\"/>" +
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"90.00\"/>" +
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"90.00\"/>" +
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"90.00\"/>");

            excelDoc.Write("<Row>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Tarih</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Fiş No</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Fiş Türü</Data></Cell>");
            //excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Açıklama</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Borç</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Alacak</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Bakiye</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">VGB</Data></Cell>");
            excelDoc.Write("</Row>");

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                excelDoc.Write("<Row>");
                excelDoc.Write("<Cell><Data ss:Type=\"String\">" + Convert.ToDateTime(dt.Rows[i]["FIS TAR"]).ToShortDateString() + "</Data></Cell>");
                excelDoc.Write("<Cell><Data ss:Type=\"String\">" + dt.Rows[i]["MATBU_NO"].ToString() + "</Data></Cell>");
                excelDoc.Write("<Cell><Data ss:Type=\"String\">" + dt.Rows[i]["FIS TUR"].ToString() + "</Data></Cell>");
                //excelDoc.Write("<Cell><Data ss:Type=\"String\">" + dt.Rows[i]["FIS ACIKLAMA"].ToString() + "</Data></Cell>");
                excelDoc.Write("<Cell ss:StyleID=\"Fiyat\"><Data ss:Type=\"String\">" + Convert.ToDecimal(dt.Rows[i]["BORC"]).ToString("N2").Replace(".", "").Replace(",", ".") + "</Data></Cell>");
                excelDoc.Write("<Cell ss:StyleID=\"Fiyat\"><Data ss:Type=\"String\">" + Convert.ToDecimal(dt.Rows[i]["ALACAK"]).ToString("N2").Replace(".", "").Replace(",", ".") + "</Data></Cell>");
                excelDoc.Write("<Cell ss:StyleID=\"Fiyat\"><Data ss:Type=\"String\">" + Convert.ToDecimal(dt.Rows[i]["BAKIYE"]).ToString("N2").Replace(".", "").Replace(",", ".") + "</Data></Cell>");
                excelDoc.Write("<Cell ss:StyleID=\"Fiyat\"><Data ss:Type=\"String\">" + Convert.ToDecimal(dt.Rows[i]["VGB"]).ToString("N2").Replace(".", "").Replace(",", ".") + "</Data></Cell>");
                excelDoc.Write("</Row>");
            }

            excelDoc.Write("<Row>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\"></Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\"></Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\"></Data></Cell>");
            //excelDoc.Write("<Cell ss:StyleID=\"FiyatKalin\"><Data ss:Type=\"String\">_________________________</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">_________________</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">_________________</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">_________________</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">_________________</Data></Cell>");
            excelDoc.Write("</Row>");
            excelDoc.Write("<Row>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Ort.Vade:</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">" + ((decimal)toplamlar[2] < 0 ? DateTime.Now.AddDays(Convert.ToInt32(Math.Floor((double)toplamlar[4]))).ToShortDateString() : "<i>Bakiye sıfırdan büyük</i>") + "</Data></Cell>");
            //excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\"></Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Toplam:</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"FiyatKalin\"><Data ss:Type=\"String\">" + Convert.ToDecimal(toplamlar[0]).ToString("N2").Replace(".", "").Replace(",", ".") + "</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"FiyatKalin\"><Data ss:Type=\"String\">" + Convert.ToDecimal(toplamlar[1]).ToString("N2").Replace(".", "").Replace(",", ".") + "</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"FiyatKalin\"><Data ss:Type=\"String\">" + Convert.ToDecimal(toplamlar[2]).ToString("N2").Replace(".", "").Replace(",", ".") + "</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"FiyatKalin\"><Data ss:Type=\"String\">" + Convert.ToDecimal(toplamlar[3]).ToString("N2").Replace(".", "").Replace(",", ".") + "</Data></Cell>");
            excelDoc.Write("</Row>");


            excelDoc.Write("</Table>");
            excelDoc.Write("</Worksheet>");
            excelDoc.Write("</Workbook>");
            excelDoc.Flush();
            //excelDoc.Close();
            Response.End();
        }

        private int GetEkstrelerCountByGMREF(int GMREF)
        {
            return Ekstreler.GetObjectsCountByGMREF(GMREF, -1,
                (DateTime)Session["downloadyazdirekstretarih1"], (DateTime)Session["downloadyazdirekstretarih2"], (bool)Session["downloadyazdirekstrevgb"], (string)Session["downloadyazdirekstreisyeri"]);
        }

        private DataTable GetEkstrelerByGMREF(int GMREF)
        {
            DataTable dt = new DataTable();
            Ekstreler.GetObjectsByGMREF(dt, GMREF, 0, GetEkstrelerCountByGMREF(GMREF), -1,
                (DateTime)Session["downloadyazdirekstretarih1"], (DateTime)Session["downloadyazdirekstretarih2"], (bool)Session["downloadyazdirekstrevgb"], (string)Session["downloadyazdirekstreisyeri"]);
            return dt;
        }

        private ArrayList GetEkstrelerToplam(int GMREF)
        {
            ArrayList toplamlar = Ekstreler.GetToplamFiyatlar(GMREF, -1,
                (DateTime)Session["downloadyazdirekstretarih1"], (DateTime)Session["downloadyazdirekstretarih2"], (bool)Session["downloadyazdirekstrevgb"]);
            return toplamlar;
        }




        private void ExportToExcelSatisRapor(int REF, int SLSREF, bool GMREF)
        {
            DataTable dt = new DataTable();
            ArrayList toplamlar = new ArrayList();
            if (GMREF)
            {
                dt = GetSatisRaporByGMREF(REF, SLSREF);
                toplamlar = GetSatisRaporToplamByGMREF(REF, SLSREF);
            }
            else
            {
                dt = GetSatisRaporBySMREF(REF, SLSREF);
                toplamlar = GetSatisRaporToplamBySMREF(REF, SLSREF);
            }



            Session["downloadsatisraporsmref"] = null;
            Session["downloadsatisraporgmref"] = null;
            Session["downloadsatisraporslsref"] = null;



            string DosyaAdi = "SatisRapor-";
            DosyaAdi += GMREF ? CariHesaplar.GetMUSTERIbyGMREF(REF) + ".XLS" : CariHesaplar.GetMUSTERIbySMREF(REF) + ".XLS";
            Response.Clear();
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Buffer = true;
            Response.ContentType = "application/octet-stream";
            Response.AddHeader("content-disposition", "attachment; filename=\"" + DosyaAdi + "\"");
            this.EnableViewState = false;
            System.IO.StreamWriter excelDoc = default(System.IO.StreamWriter);
            excelDoc = new System.IO.StreamWriter(Response.OutputStream);

            #region ExcelXMLbasi
            System.Text.StringBuilder ExcelXMLbasi = new System.Text.StringBuilder();
            ExcelXMLbasi.AppendLine("<xml version>");
            ExcelXMLbasi.AppendLine("<Workbook xmlns=\"urn:schemas-microsoft-com:office:spreadsheet\"");
            ExcelXMLbasi.AppendLine(" xmlns:o=\"urn:schemas-microsoft-com:office:office\"");
            ExcelXMLbasi.AppendLine(" xmlns:x=\"urn:schemas- microsoft-com:office:excel\"");
            ExcelXMLbasi.AppendLine(" xmlns:ss=\"urn:schemas-microsoft-com:office:spreadsheet\">");
            ExcelXMLbasi.AppendLine(" <Styles>");
            ExcelXMLbasi.AppendLine(" <Style ss:ID=\"Default\" ss:Name=\"Normal\">");
            ExcelXMLbasi.AppendLine(" <Alignment ss:Vertical=\"Bottom\"/>");
            ExcelXMLbasi.AppendLine(" <Borders/>");
            ExcelXMLbasi.AppendLine(" <Font/>");
            ExcelXMLbasi.AppendLine(" <Interior/>");
            ExcelXMLbasi.AppendLine(" <NumberFormat/>");
            ExcelXMLbasi.AppendLine(" <Protection/>");
            ExcelXMLbasi.AppendLine(" </Style>");
            ExcelXMLbasi.AppendLine(" <Style ss:ID=\"KalinBaslik\">");
            ExcelXMLbasi.AppendLine(" <Alignment ss:Horizontal=\"Center\" ss:Vertical=\"Bottom\"/>");
            ExcelXMLbasi.AppendLine(" <Font x:Family=\"Swiss\" ss:Bold=\"1\"/>");
            ExcelXMLbasi.AppendLine(" </Style>");
            ExcelXMLbasi.AppendLine(" <Style ss:ID=\"StringLiteral\">");
            ExcelXMLbasi.AppendLine(" <NumberFormat ss:Format=\"@\"/>");
            ExcelXMLbasi.AppendLine(" </Style>");
            ExcelXMLbasi.AppendLine(" <Style ss:ID=\"Decimal\">");
            ExcelXMLbasi.AppendLine(" <NumberFormat ss:Format=\"0\"/>");
            ExcelXMLbasi.AppendLine(" </Style>");
            ExcelXMLbasi.AppendLine(" <Style ss:ID=\"Integer\">");
            ExcelXMLbasi.AppendLine(" <NumberFormat ss:Format=\"0\"/>");
            ExcelXMLbasi.AppendLine(" <Alignment ss:Horizontal=\"Center\" ss:Vertical=\"Bottom\"/>");
            ExcelXMLbasi.AppendLine(" </Style>");
            ExcelXMLbasi.AppendLine(" <Style ss:ID=\"Currency\">");
            ExcelXMLbasi.AppendLine(" <NumberFormat ss:Format=\"0.000 TL\"/>");
            ExcelXMLbasi.AppendLine(" <Alignment ss:Horizontal=\"Right\" ss:Vertical=\"Bottom\"/>");
            ExcelXMLbasi.AppendLine(" </Style>");
            ExcelXMLbasi.AppendLine(" <Style ss:ID=\"Fiyat\">");
            ExcelXMLbasi.AppendLine(" <Alignment ss:Horizontal=\"Right\" ss:Vertical=\"Bottom\"/>");
            ExcelXMLbasi.AppendLine(" </Style>");
            ExcelXMLbasi.AppendLine(" <Style ss:ID=\"FiyatKalin\">");
            ExcelXMLbasi.AppendLine(" <Alignment ss:Horizontal=\"Right\" ss:Vertical=\"Bottom\"/>");
            ExcelXMLbasi.AppendLine(" <Font x:Family=\"Swiss\" ss:Bold=\"1\"/>");
            ExcelXMLbasi.AppendLine(" </Style>");
            ExcelXMLbasi.AppendLine(" <Style ss:ID=\"DateLiteral\">");
            ExcelXMLbasi.AppendLine(" <NumberFormat ss:Format=\"dd.mm.yyyy;@\"/>");
            ExcelXMLbasi.AppendLine(" </Style>");
            ExcelXMLbasi.AppendLine(" </Styles>");
            excelDoc.Write(ExcelXMLbasi.ToString());
            #endregion

            excelDoc.Write(" <Worksheet ss:Name=\"Rapor\">");
            excelDoc.Write("<Table>" +
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"80.00\"/>" +
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"60.00\"/>" +
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"60.00\"/>" +
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"350.00\"/>" +
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"80.00\"/>" +
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"330.00\"/>" +
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"60.00\"/>" +
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"60.00\"/>" +
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"90.00\"/>" +
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"90.00\"/>" +
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"90.00\"/>" +
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"150.00\"/>" +
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"90.00\"/>");

            excelDoc.Write("<Row>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Fatura Tarihi</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Fatura No</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Tür</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">C/H Açıklaması</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Ürt.Kod</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Ürün</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Fiyat Tipi</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Adet</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Koli</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Brüt</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">İskonto</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">İsk.%</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Net</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Net+KDV</Data></Cell>");
            excelDoc.Write("</Row>");

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                excelDoc.Write("<Row>");
                excelDoc.Write("<Cell><Data ss:Type=\"String\">" + Convert.ToDateTime(dt.Rows[i]["FAT TAR"]).ToShortDateString() + "</Data></Cell>");
                excelDoc.Write("<Cell><Data ss:Type=\"String\">" + dt.Rows[i]["FAT NO"].ToString() + "</Data></Cell>");
                excelDoc.Write("<Cell><Data ss:Type=\"String\">" + dt.Rows[i]["TUR ACK"].ToString() + "</Data></Cell>");
                excelDoc.Write("<Cell><Data ss:Type=\"String\">" + dt.Rows[i]["MUSTERI"].ToString() + "</Data></Cell>");
                excelDoc.Write("<Cell><Data ss:Type=\"String\">" + dt.Rows[i]["URT KOD"].ToString() + "</Data></Cell>");
                excelDoc.Write("<Cell><Data ss:Type=\"String\">" + dt.Rows[i]["MALZEME"].ToString() + "</Data></Cell>");
                excelDoc.Write("<Cell><Data ss:Type=\"String\">" + dt.Rows[i]["F TUR"].ToString() + "</Data></Cell>");
                excelDoc.Write("<Cell><Data ss:Type=\"String\">" + dt.Rows[i]["AD T"].ToString() + "</Data></Cell>");
                excelDoc.Write("<Cell><Data ss:Type=\"String\">" + (Convert.ToDouble(dt.Rows[i]["AD T"]) / Convert.ToDouble(dt.Rows[i]["KOLI"])).ToString("N2") + "</Data></Cell>");
                excelDoc.Write("<Cell ss:StyleID=\"Fiyat\"><Data ss:Type=\"String\">" + Convert.ToDecimal(dt.Rows[i]["BRUT T"]).ToString("C2").Replace(".", "").Replace(",", ".") + "</Data></Cell>");
                excelDoc.Write("<Cell ss:StyleID=\"Fiyat\"><Data ss:Type=\"String\">" + Convert.ToDecimal(dt.Rows[i]["ISK T"]).ToString("C2").Replace(".", "").Replace(",", ".") + "</Data></Cell>");
                excelDoc.Write("<Cell ss:StyleID=\"Fiyat\"><Data ss:Type=\"String\">" + dt.Rows[i]["GRP"].ToString() + "</Data></Cell>");
                excelDoc.Write("<Cell ss:StyleID=\"Fiyat\"><Data ss:Type=\"String\">" + Convert.ToDecimal(dt.Rows[i]["NET T"]).ToString("C2").Replace(".", "").Replace(",", ".") + "</Data></Cell>");
                excelDoc.Write("<Cell ss:StyleID=\"Fiyat\"><Data ss:Type=\"String\">" + Convert.ToDecimal(dt.Rows[i]["NET+KDV T"]).ToString("C2").Replace(".", "").Replace(",", ".") + "</Data></Cell>");
                excelDoc.Write("</Row>");
            }

            excelDoc.Write("<Row>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\"></Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\"></Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\"></Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\"></Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\"></Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\"></Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"FiyatKalin\"><Data ss:Type=\"String\">_________________________</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">_________________</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">_________________</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">_________________</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">_________________</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">_________________</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">_________________</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">_________________</Data></Cell>");
            excelDoc.Write("</Row>");
            excelDoc.Write("<Row>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\"></Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\"></Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\"></Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\"></Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\"></Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\"></Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Toplam:</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">" + Convert.ToInt32(toplamlar[4]).ToString() + "</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">" + Convert.ToInt32(toplamlar[5]).ToString() + "</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"FiyatKalin\"><Data ss:Type=\"String\">" + Convert.ToDecimal(toplamlar[0]).ToString("C2").Replace(".", "").Replace(",", ".") + "</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"FiyatKalin\"><Data ss:Type=\"String\">" + Convert.ToDecimal(toplamlar[1]).ToString("C2").Replace(".", "").Replace(",", ".") + "</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"FiyatKalin\"><Data ss:Type=\"String\">-</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"FiyatKalin\"><Data ss:Type=\"String\">" + Convert.ToDecimal(toplamlar[2]).ToString("C2").Replace(".", "").Replace(",", ".") + "</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"FiyatKalin\"><Data ss:Type=\"String\">" + Convert.ToDecimal(toplamlar[3]).ToString("C2").Replace(".", "").Replace(",", ".") + "</Data></Cell>");
            excelDoc.Write("</Row>");

            excelDoc.Write("</Table>");
            excelDoc.Write("</Worksheet>");
            excelDoc.Write("</Workbook>");
            excelDoc.Flush();
            excelDoc.Close();
            Response.End();
        }

        private void ExportToExcelSatisRaporSLSREF(int SLSREF)
        {
            DataTable dt = new DataTable();
            ArrayList toplamlar = new ArrayList();

            dt = GetSatisRaporBySLSREF(SLSREF);
            toplamlar = GetSatisRaporToplamBySLSREF(SLSREF);



            Session["downloadsatisraporslsref"] = null;



            string DosyaAdi = "SatisRapor-" + SLSREF.ToString() + ".XLS";
            Response.Clear();
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Buffer = true;
            Response.ContentType = "application/octet-stream";
            Response.AddHeader("content-disposition", "attachment; filename=\"" + DosyaAdi + "\"");
            this.EnableViewState = false;
            System.IO.StreamWriter excelDoc = default(System.IO.StreamWriter);
            excelDoc = new System.IO.StreamWriter(Response.OutputStream);

            #region ExcelXMLbasi
            System.Text.StringBuilder ExcelXMLbasi = new System.Text.StringBuilder();
            ExcelXMLbasi.AppendLine("<xml version>");
            ExcelXMLbasi.AppendLine("<Workbook xmlns=\"urn:schemas-microsoft-com:office:spreadsheet\"");
            ExcelXMLbasi.AppendLine(" xmlns:o=\"urn:schemas-microsoft-com:office:office\"");
            ExcelXMLbasi.AppendLine(" xmlns:x=\"urn:schemas- microsoft-com:office:excel\"");
            ExcelXMLbasi.AppendLine(" xmlns:ss=\"urn:schemas-microsoft-com:office:spreadsheet\">");
            ExcelXMLbasi.AppendLine(" <Styles>");
            ExcelXMLbasi.AppendLine(" <Style ss:ID=\"Default\" ss:Name=\"Normal\">");
            ExcelXMLbasi.AppendLine(" <Alignment ss:Vertical=\"Bottom\"/>");
            ExcelXMLbasi.AppendLine(" <Borders/>");
            ExcelXMLbasi.AppendLine(" <Font/>");
            ExcelXMLbasi.AppendLine(" <Interior/>");
            ExcelXMLbasi.AppendLine(" <NumberFormat/>");
            ExcelXMLbasi.AppendLine(" <Protection/>");
            ExcelXMLbasi.AppendLine(" </Style>");
            ExcelXMLbasi.AppendLine(" <Style ss:ID=\"KalinBaslik\">");
            ExcelXMLbasi.AppendLine(" <Alignment ss:Horizontal=\"Center\" ss:Vertical=\"Bottom\"/>");
            ExcelXMLbasi.AppendLine(" <Font x:Family=\"Swiss\" ss:Bold=\"1\"/>");
            ExcelXMLbasi.AppendLine(" </Style>");
            ExcelXMLbasi.AppendLine(" <Style ss:ID=\"StringLiteral\">");
            ExcelXMLbasi.AppendLine(" <NumberFormat ss:Format=\"@\"/>");
            ExcelXMLbasi.AppendLine(" </Style>");
            ExcelXMLbasi.AppendLine(" <Style ss:ID=\"Decimal\">");
            ExcelXMLbasi.AppendLine(" <NumberFormat ss:Format=\"0\"/>");
            ExcelXMLbasi.AppendLine(" </Style>");
            ExcelXMLbasi.AppendLine(" <Style ss:ID=\"Integer\">");
            ExcelXMLbasi.AppendLine(" <NumberFormat ss:Format=\"0\"/>");
            ExcelXMLbasi.AppendLine(" <Alignment ss:Horizontal=\"Center\" ss:Vertical=\"Bottom\"/>");
            ExcelXMLbasi.AppendLine(" </Style>");
            ExcelXMLbasi.AppendLine(" <Style ss:ID=\"Currency\">");
            ExcelXMLbasi.AppendLine(" <NumberFormat ss:Format=\"0.000 TL\"/>");
            ExcelXMLbasi.AppendLine(" <Alignment ss:Horizontal=\"Right\" ss:Vertical=\"Bottom\"/>");
            ExcelXMLbasi.AppendLine(" </Style>");
            ExcelXMLbasi.AppendLine(" <Style ss:ID=\"Fiyat\">");
            ExcelXMLbasi.AppendLine(" <Alignment ss:Horizontal=\"Right\" ss:Vertical=\"Bottom\"/>");
            ExcelXMLbasi.AppendLine(" </Style>");
            ExcelXMLbasi.AppendLine(" <Style ss:ID=\"FiyatKalin\">");
            ExcelXMLbasi.AppendLine(" <Alignment ss:Horizontal=\"Right\" ss:Vertical=\"Bottom\"/>");
            ExcelXMLbasi.AppendLine(" <Font x:Family=\"Swiss\" ss:Bold=\"1\"/>");
            ExcelXMLbasi.AppendLine(" </Style>");
            ExcelXMLbasi.AppendLine(" <Style ss:ID=\"DateLiteral\">");
            ExcelXMLbasi.AppendLine(" <NumberFormat ss:Format=\"dd.mm.yyyy;@\"/>");
            ExcelXMLbasi.AppendLine(" </Style>");
            ExcelXMLbasi.AppendLine(" </Styles>");
            excelDoc.Write(ExcelXMLbasi.ToString());
            #endregion

            excelDoc.Write(" <Worksheet ss:Name=\"Rapor\">");
            excelDoc.Write("<Table>" +
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"80.00\"/>" +
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"60.00\"/>" +
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"60.00\"/>" +
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"350.00\"/>" +
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"80.00\"/>" +
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"330.00\"/>" +
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"60.00\"/>" +
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"60.00\"/>" +
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"90.00\"/>" +
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"90.00\"/>" +
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"90.00\"/>" +
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"150.00\"/>" +
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"90.00\"/>");

            excelDoc.Write("<Row>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Fatura Tarihi</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Fatura No</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Tür</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">C/H Açıklaması</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Ürt.Kod</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Ürün</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Fiyat Tipi</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Adet</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Koli</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Brüt</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">İskonto</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">İsk.%</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Net</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Net+KDV</Data></Cell>");
            excelDoc.Write("</Row>");

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                excelDoc.Write("<Row>");
                excelDoc.Write("<Cell><Data ss:Type=\"String\">" + Convert.ToDateTime(dt.Rows[i]["FAT TAR"]).ToShortDateString() + "</Data></Cell>");
                excelDoc.Write("<Cell><Data ss:Type=\"String\">" + dt.Rows[i]["FAT NO"].ToString() + "</Data></Cell>");
                excelDoc.Write("<Cell><Data ss:Type=\"String\">" + dt.Rows[i]["TUR ACK"].ToString() + "</Data></Cell>");
                excelDoc.Write("<Cell><Data ss:Type=\"String\">" + dt.Rows[i]["MUSTERI"].ToString() + "</Data></Cell>");
                excelDoc.Write("<Cell><Data ss:Type=\"String\">" + dt.Rows[i]["URT KOD"].ToString() + "</Data></Cell>");
                excelDoc.Write("<Cell><Data ss:Type=\"String\">" + dt.Rows[i]["MALZEME"].ToString() + "</Data></Cell>");
                excelDoc.Write("<Cell><Data ss:Type=\"String\">" + dt.Rows[i]["F TUR"].ToString() + "</Data></Cell>");
                excelDoc.Write("<Cell><Data ss:Type=\"String\">" + dt.Rows[i]["AD T"].ToString() + "</Data></Cell>");
                excelDoc.Write("<Cell><Data ss:Type=\"String\">" + (Convert.ToDouble(dt.Rows[i]["AD T"]) / Convert.ToDouble(dt.Rows[i]["KOLI"])).ToString("N2") + "</Data></Cell>");
                excelDoc.Write("<Cell ss:StyleID=\"Fiyat\"><Data ss:Type=\"String\">" + Convert.ToDecimal(dt.Rows[i]["BRUT T"]).ToString("C2").Replace(".", "").Replace(",", ".") + "</Data></Cell>");
                excelDoc.Write("<Cell ss:StyleID=\"Fiyat\"><Data ss:Type=\"String\">" + Convert.ToDecimal(dt.Rows[i]["ISK T"]).ToString("C2").Replace(".", "").Replace(",", ".") + "</Data></Cell>");
                excelDoc.Write("<Cell ss:StyleID=\"Fiyat\"><Data ss:Type=\"String\">" + dt.Rows[i]["GRP"].ToString() + "</Data></Cell>");
                excelDoc.Write("<Cell ss:StyleID=\"Fiyat\"><Data ss:Type=\"String\">" + Convert.ToDecimal(dt.Rows[i]["NET T"]).ToString("C2").Replace(".", "").Replace(",", ".") + "</Data></Cell>");
                excelDoc.Write("<Cell ss:StyleID=\"Fiyat\"><Data ss:Type=\"String\">" + Convert.ToDecimal(dt.Rows[i]["NET+KDV T"]).ToString("C2").Replace(".", "").Replace(",", ".") + "</Data></Cell>");
                excelDoc.Write("</Row>");
            }

            excelDoc.Write("<Row>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\"></Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\"></Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\"></Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\"></Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\"></Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\"></Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"FiyatKalin\"><Data ss:Type=\"String\">_________________________</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">_________________</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">_________________</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">_________________</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">_________________</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">_________________</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">_________________</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">_________________</Data></Cell>");
            excelDoc.Write("</Row>");
            excelDoc.Write("<Row>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\"></Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\"></Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\"></Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\"></Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\"></Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\"></Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Toplam:</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">" + Convert.ToInt32(toplamlar[4]).ToString() + "</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">" + Convert.ToInt32(toplamlar[5]).ToString() + "</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"FiyatKalin\"><Data ss:Type=\"String\">" + Convert.ToDecimal(toplamlar[0]).ToString("C2").Replace(".", "").Replace(",", ".") + "</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"FiyatKalin\"><Data ss:Type=\"String\">" + Convert.ToDecimal(toplamlar[1]).ToString("C2").Replace(".", "").Replace(",", ".") + "</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"FiyatKalin\"><Data ss:Type=\"String\"></Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"FiyatKalin\"><Data ss:Type=\"String\">" + Convert.ToDecimal(toplamlar[2]).ToString("C2").Replace(".", "").Replace(",", ".") + "</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"FiyatKalin\"><Data ss:Type=\"String\">" + Convert.ToDecimal(toplamlar[3]).ToString("C2").Replace(".", "").Replace(",", ".") + "</Data></Cell>");
            excelDoc.Write("</Row>");

            excelDoc.Write("</Table>");
            excelDoc.Write("</Worksheet>");
            excelDoc.Write("</Workbook>");
            excelDoc.Flush();
            excelDoc.Close();
            Response.End();
        }

        private void ExportToExcelSatisRaporSLSREFs(int SLSREF)
        {
            DataTable dt = new DataTable();
            ArrayList toplamlar = new ArrayList();

            dt = GetSatisRaporBySLSREFs(SLSREF);
            toplamlar = GetSatisRaporToplamBySLSREFs(SLSREF);



            Session["downloadsatisraporslsrefs"] = null;
            Session["downloadsatisraporslsref"] = null;



            string DosyaAdi = "SatisRapor-" + SLSREF.ToString() + ".XLS";
            Response.Clear();
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Buffer = true;
            Response.ContentType = "application/octet-stream";
            Response.AddHeader("content-disposition", "attachment; filename=\"" + DosyaAdi + "\"");
            this.EnableViewState = false;
            System.IO.StreamWriter excelDoc = default(System.IO.StreamWriter);
            excelDoc = new System.IO.StreamWriter(Response.OutputStream);

            #region ExcelXMLbasi
            System.Text.StringBuilder ExcelXMLbasi = new System.Text.StringBuilder();
            ExcelXMLbasi.AppendLine("<xml version>");
            ExcelXMLbasi.AppendLine("<Workbook xmlns=\"urn:schemas-microsoft-com:office:spreadsheet\"");
            ExcelXMLbasi.AppendLine(" xmlns:o=\"urn:schemas-microsoft-com:office:office\"");
            ExcelXMLbasi.AppendLine(" xmlns:x=\"urn:schemas- microsoft-com:office:excel\"");
            ExcelXMLbasi.AppendLine(" xmlns:ss=\"urn:schemas-microsoft-com:office:spreadsheet\">");
            ExcelXMLbasi.AppendLine(" <Styles>");
            ExcelXMLbasi.AppendLine(" <Style ss:ID=\"Default\" ss:Name=\"Normal\">");
            ExcelXMLbasi.AppendLine(" <Alignment ss:Vertical=\"Bottom\"/>");
            ExcelXMLbasi.AppendLine(" <Borders/>");
            ExcelXMLbasi.AppendLine(" <Font/>");
            ExcelXMLbasi.AppendLine(" <Interior/>");
            ExcelXMLbasi.AppendLine(" <NumberFormat/>");
            ExcelXMLbasi.AppendLine(" <Protection/>");
            ExcelXMLbasi.AppendLine(" </Style>");
            ExcelXMLbasi.AppendLine(" <Style ss:ID=\"KalinBaslik\">");
            ExcelXMLbasi.AppendLine(" <Alignment ss:Horizontal=\"Center\" ss:Vertical=\"Bottom\"/>");
            ExcelXMLbasi.AppendLine(" <Font x:Family=\"Swiss\" ss:Bold=\"1\"/>");
            ExcelXMLbasi.AppendLine(" </Style>");
            ExcelXMLbasi.AppendLine(" <Style ss:ID=\"StringLiteral\">");
            ExcelXMLbasi.AppendLine(" <NumberFormat ss:Format=\"@\"/>");
            ExcelXMLbasi.AppendLine(" </Style>");
            ExcelXMLbasi.AppendLine(" <Style ss:ID=\"Decimal\">");
            ExcelXMLbasi.AppendLine(" <NumberFormat ss:Format=\"0\"/>");
            ExcelXMLbasi.AppendLine(" </Style>");
            ExcelXMLbasi.AppendLine(" <Style ss:ID=\"Integer\">");
            ExcelXMLbasi.AppendLine(" <NumberFormat ss:Format=\"0\"/>");
            ExcelXMLbasi.AppendLine(" <Alignment ss:Horizontal=\"Center\" ss:Vertical=\"Bottom\"/>");
            ExcelXMLbasi.AppendLine(" </Style>");
            ExcelXMLbasi.AppendLine(" <Style ss:ID=\"Currency\">");
            ExcelXMLbasi.AppendLine(" <NumberFormat ss:Format=\"0.000 TL\"/>");
            ExcelXMLbasi.AppendLine(" <Alignment ss:Horizontal=\"Right\" ss:Vertical=\"Bottom\"/>");
            ExcelXMLbasi.AppendLine(" </Style>");
            ExcelXMLbasi.AppendLine(" <Style ss:ID=\"Fiyat\">");
            ExcelXMLbasi.AppendLine(" <Alignment ss:Horizontal=\"Right\" ss:Vertical=\"Bottom\"/>");
            ExcelXMLbasi.AppendLine(" </Style>");
            ExcelXMLbasi.AppendLine(" <Style ss:ID=\"FiyatKalin\">");
            ExcelXMLbasi.AppendLine(" <Alignment ss:Horizontal=\"Right\" ss:Vertical=\"Bottom\"/>");
            ExcelXMLbasi.AppendLine(" <Font x:Family=\"Swiss\" ss:Bold=\"1\"/>");
            ExcelXMLbasi.AppendLine(" </Style>");
            ExcelXMLbasi.AppendLine(" <Style ss:ID=\"DateLiteral\">");
            ExcelXMLbasi.AppendLine(" <NumberFormat ss:Format=\"dd.mm.yyyy;@\"/>");
            ExcelXMLbasi.AppendLine(" </Style>");
            ExcelXMLbasi.AppendLine(" </Styles>");
            excelDoc.Write(ExcelXMLbasi.ToString());
            #endregion

            excelDoc.Write(" <Worksheet ss:Name=\"Rapor\">");
            excelDoc.Write("<Table>" +
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"80.00\"/>" +
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"60.00\"/>" +
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"60.00\"/>" +
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"350.00\"/>" +
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"80.00\"/>" +
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"330.00\"/>" +
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"60.00\"/>" +
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"60.00\"/>" +
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"90.00\"/>" +
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"90.00\"/>" +
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"90.00\"/>" +
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"150.00\"/>" +
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"90.00\"/>");

            excelDoc.Write("<Row>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Fatura Tarihi</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Fatura No</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Tür</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">C/H Açıklaması</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Ürt.Kod</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Ürün</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Fiyat Tipi</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Adet</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Koli</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Brüt</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">İskonto</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">İsk.%</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Net</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Net+KDV</Data></Cell>");
            excelDoc.Write("</Row>");

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                excelDoc.Write("<Row>");
                excelDoc.Write("<Cell><Data ss:Type=\"String\">" + Convert.ToDateTime(dt.Rows[i]["FAT TAR"]).ToShortDateString() + "</Data></Cell>");
                excelDoc.Write("<Cell><Data ss:Type=\"String\">" + dt.Rows[i]["FAT NO"].ToString() + "</Data></Cell>");
                excelDoc.Write("<Cell><Data ss:Type=\"String\">" + dt.Rows[i]["TUR ACK"].ToString() + "</Data></Cell>");
                excelDoc.Write("<Cell><Data ss:Type=\"String\">" + dt.Rows[i]["MUSTERI"].ToString() + "</Data></Cell>");
                excelDoc.Write("<Cell><Data ss:Type=\"String\">" + dt.Rows[i]["URT KOD"].ToString() + "</Data></Cell>");
                excelDoc.Write("<Cell><Data ss:Type=\"String\">" + dt.Rows[i]["MALZEME"].ToString() + "</Data></Cell>");
                excelDoc.Write("<Cell><Data ss:Type=\"String\">" + dt.Rows[i]["F TUR"].ToString() + "</Data></Cell>");
                excelDoc.Write("<Cell><Data ss:Type=\"String\">" + dt.Rows[i]["AD T"].ToString() + "</Data></Cell>");
                excelDoc.Write("<Cell><Data ss:Type=\"String\">" + (Convert.ToDouble(dt.Rows[i]["AD T"]) / Convert.ToDouble(dt.Rows[i]["KOLI"])).ToString("N2") + "</Data></Cell>");
                excelDoc.Write("<Cell ss:StyleID=\"Fiyat\"><Data ss:Type=\"String\">" + Convert.ToDecimal(dt.Rows[i]["BRUT T"]).ToString("C2").Replace(".", "").Replace(",", ".") + "</Data></Cell>");
                excelDoc.Write("<Cell ss:StyleID=\"Fiyat\"><Data ss:Type=\"String\">" + Convert.ToDecimal(dt.Rows[i]["ISK T"]).ToString("C2").Replace(".", "").Replace(",", ".") + "</Data></Cell>");
                excelDoc.Write("<Cell ss:StyleID=\"Fiyat\"><Data ss:Type=\"String\">" + dt.Rows[i]["GRP"].ToString() + "</Data></Cell>");
                excelDoc.Write("<Cell ss:StyleID=\"Fiyat\"><Data ss:Type=\"String\">" + Convert.ToDecimal(dt.Rows[i]["NET T"]).ToString("C2").Replace(".", "").Replace(",", ".") + "</Data></Cell>");
                excelDoc.Write("<Cell ss:StyleID=\"Fiyat\"><Data ss:Type=\"String\">" + Convert.ToDecimal(dt.Rows[i]["NET+KDV T"]).ToString("C2").Replace(".", "").Replace(",", ".") + "</Data></Cell>");
                excelDoc.Write("</Row>");
            }

            excelDoc.Write("<Row>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\"></Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\"></Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\"></Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\"></Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\"></Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\"></Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"FiyatKalin\"><Data ss:Type=\"String\">_________________________</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">_________________</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">_________________</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">_________________</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">_________________</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">_________________</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">_________________</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">_________________</Data></Cell>");
            excelDoc.Write("</Row>");
            excelDoc.Write("<Row>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\"></Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\"></Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\"></Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\"></Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\"></Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\"></Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Toplam:</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">" + Convert.ToInt32(toplamlar[4]).ToString() + "</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">" + Convert.ToInt32(toplamlar[5]).ToString() + "</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"FiyatKalin\"><Data ss:Type=\"String\">" + Convert.ToDecimal(toplamlar[0]).ToString("C2").Replace(".", "").Replace(",", ".") + "</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"FiyatKalin\"><Data ss:Type=\"String\">" + Convert.ToDecimal(toplamlar[1]).ToString("C2").Replace(".", "").Replace(",", ".") + "</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"FiyatKalin\"><Data ss:Type=\"String\"></Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"FiyatKalin\"><Data ss:Type=\"String\">" + Convert.ToDecimal(toplamlar[2]).ToString("C2").Replace(".", "").Replace(",", ".") + "</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"FiyatKalin\"><Data ss:Type=\"String\">" + Convert.ToDecimal(toplamlar[3]).ToString("C2").Replace(".", "").Replace(",", ".") + "</Data></Cell>");
            excelDoc.Write("</Row>");

            excelDoc.Write("</Table>");
            excelDoc.Write("</Worksheet>");
            excelDoc.Write("</Workbook>");
            excelDoc.Flush();
            excelDoc.Close();
            Response.End();
        }

        private void ExportToExcelSatisRaporOzelKod()
        {
            DataTable dt = new DataTable();
            ArrayList toplamlar = new ArrayList();

            dt = GetSatisRapor();
            toplamlar = GetSatisRaporToplam();



            Session["downloadsatisraportumozelkod"] = null;
            Session["downloadsatisraporslsref"] = null;



            string DosyaAdi = "SatisRapor.XLS";
            Response.Clear();
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Buffer = true;
            Response.ContentType = "application/octet-stream";
            Response.AddHeader("content-disposition", "attachment; filename=\"" + DosyaAdi + "\"");
            this.EnableViewState = false;
            System.IO.StreamWriter excelDoc = default(System.IO.StreamWriter);
            excelDoc = new System.IO.StreamWriter(Response.OutputStream);

            #region ExcelXMLbasi
            System.Text.StringBuilder ExcelXMLbasi = new System.Text.StringBuilder();
            ExcelXMLbasi.AppendLine("<xml version>");
            ExcelXMLbasi.AppendLine("<Workbook xmlns=\"urn:schemas-microsoft-com:office:spreadsheet\"");
            ExcelXMLbasi.AppendLine(" xmlns:o=\"urn:schemas-microsoft-com:office:office\"");
            ExcelXMLbasi.AppendLine(" xmlns:x=\"urn:schemas- microsoft-com:office:excel\"");
            ExcelXMLbasi.AppendLine(" xmlns:ss=\"urn:schemas-microsoft-com:office:spreadsheet\">");
            ExcelXMLbasi.AppendLine(" <Styles>");
            ExcelXMLbasi.AppendLine(" <Style ss:ID=\"Default\" ss:Name=\"Normal\">");
            ExcelXMLbasi.AppendLine(" <Alignment ss:Vertical=\"Bottom\"/>");
            ExcelXMLbasi.AppendLine(" <Borders/>");
            ExcelXMLbasi.AppendLine(" <Font/>");
            ExcelXMLbasi.AppendLine(" <Interior/>");
            ExcelXMLbasi.AppendLine(" <NumberFormat/>");
            ExcelXMLbasi.AppendLine(" <Protection/>");
            ExcelXMLbasi.AppendLine(" </Style>");
            ExcelXMLbasi.AppendLine(" <Style ss:ID=\"KalinBaslik\">");
            ExcelXMLbasi.AppendLine(" <Alignment ss:Horizontal=\"Center\" ss:Vertical=\"Bottom\"/>");
            ExcelXMLbasi.AppendLine(" <Font x:Family=\"Swiss\" ss:Bold=\"1\"/>");
            ExcelXMLbasi.AppendLine(" </Style>");
            ExcelXMLbasi.AppendLine(" <Style ss:ID=\"StringLiteral\">");
            ExcelXMLbasi.AppendLine(" <NumberFormat ss:Format=\"@\"/>");
            ExcelXMLbasi.AppendLine(" </Style>");
            ExcelXMLbasi.AppendLine(" <Style ss:ID=\"Decimal\">");
            ExcelXMLbasi.AppendLine(" <NumberFormat ss:Format=\"0\"/>");
            ExcelXMLbasi.AppendLine(" </Style>");
            ExcelXMLbasi.AppendLine(" <Style ss:ID=\"Integer\">");
            ExcelXMLbasi.AppendLine(" <NumberFormat ss:Format=\"0\"/>");
            ExcelXMLbasi.AppendLine(" <Alignment ss:Horizontal=\"Center\" ss:Vertical=\"Bottom\"/>");
            ExcelXMLbasi.AppendLine(" </Style>");
            ExcelXMLbasi.AppendLine(" <Style ss:ID=\"Currency\">");
            ExcelXMLbasi.AppendLine(" <NumberFormat ss:Format=\"0.000 TL\"/>");
            ExcelXMLbasi.AppendLine(" <Alignment ss:Horizontal=\"Right\" ss:Vertical=\"Bottom\"/>");
            ExcelXMLbasi.AppendLine(" </Style>");
            ExcelXMLbasi.AppendLine(" <Style ss:ID=\"Fiyat\">");
            ExcelXMLbasi.AppendLine(" <Alignment ss:Horizontal=\"Right\" ss:Vertical=\"Bottom\"/>");
            ExcelXMLbasi.AppendLine(" </Style>");
            ExcelXMLbasi.AppendLine(" <Style ss:ID=\"FiyatKalin\">");
            ExcelXMLbasi.AppendLine(" <Alignment ss:Horizontal=\"Right\" ss:Vertical=\"Bottom\"/>");
            ExcelXMLbasi.AppendLine(" <Font x:Family=\"Swiss\" ss:Bold=\"1\"/>");
            ExcelXMLbasi.AppendLine(" </Style>");
            ExcelXMLbasi.AppendLine(" <Style ss:ID=\"DateLiteral\">");
            ExcelXMLbasi.AppendLine(" <NumberFormat ss:Format=\"dd.mm.yyyy;@\"/>");
            ExcelXMLbasi.AppendLine(" </Style>");
            ExcelXMLbasi.AppendLine(" </Styles>");
            excelDoc.Write(ExcelXMLbasi.ToString());
            #endregion

            excelDoc.Write(" <Worksheet ss:Name=\"Rapor\">");
            excelDoc.Write("<Table>" +
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"80.00\"/>" +
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"60.00\"/>" +
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"60.00\"/>" +
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"350.00\"/>" +
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"80.00\"/>" +
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"330.00\"/>" +
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"60.00\"/>" +
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"60.00\"/>" +
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"90.00\"/>" +
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"90.00\"/>" +
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"90.00\"/>" +
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"150.00\"/>" +
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"90.00\"/>");

            excelDoc.Write("<Row>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Fatura Tarihi</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Fatura No</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Tür</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">C/H Açıklaması</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Ürt.Kod</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Ürün</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Fiyat Tipi</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Adet</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Koli</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Brüt</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">İskonto</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">İsk.%</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Net</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Net+KDV</Data></Cell>");
            excelDoc.Write("</Row>");

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                excelDoc.Write("<Row>");
                excelDoc.Write("<Cell><Data ss:Type=\"String\">" + Convert.ToDateTime(dt.Rows[i]["FAT TAR"]).ToShortDateString() + "</Data></Cell>");
                excelDoc.Write("<Cell><Data ss:Type=\"String\">" + dt.Rows[i]["FAT NO"].ToString() + "</Data></Cell>");
                excelDoc.Write("<Cell><Data ss:Type=\"String\">" + dt.Rows[i]["TUR ACK"].ToString() + "</Data></Cell>");
                excelDoc.Write("<Cell><Data ss:Type=\"String\">" + dt.Rows[i]["MUSTERI"].ToString() + "</Data></Cell>");
                excelDoc.Write("<Cell><Data ss:Type=\"String\">" + dt.Rows[i]["URT KOD"].ToString() + "</Data></Cell>");
                excelDoc.Write("<Cell><Data ss:Type=\"String\">" + dt.Rows[i]["MALZEME"].ToString() + "</Data></Cell>");
                excelDoc.Write("<Cell><Data ss:Type=\"String\">" + dt.Rows[i]["F TUR"].ToString() + "</Data></Cell>");
                excelDoc.Write("<Cell><Data ss:Type=\"String\">" + dt.Rows[i]["AD T"].ToString() + "</Data></Cell>");
                excelDoc.Write("<Cell><Data ss:Type=\"String\">" + (Convert.ToDouble(dt.Rows[i]["AD T"]) / Convert.ToDouble(dt.Rows[i]["KOLI"])).ToString("N2") + "</Data></Cell>");
                excelDoc.Write("<Cell ss:StyleID=\"Fiyat\"><Data ss:Type=\"String\">" + Convert.ToDecimal(dt.Rows[i]["BRUT T"]).ToString("C2").Replace(".", "").Replace(",", ".") + "</Data></Cell>");
                excelDoc.Write("<Cell ss:StyleID=\"Fiyat\"><Data ss:Type=\"String\">" + Convert.ToDecimal(dt.Rows[i]["ISK T"]).ToString("C2").Replace(".", "").Replace(",", ".") + "</Data></Cell>");
                excelDoc.Write("<Cell ss:StyleID=\"Fiyat\"><Data ss:Type=\"String\">" + dt.Rows[i]["GRP"].ToString() + "</Data></Cell>");
                excelDoc.Write("<Cell ss:StyleID=\"Fiyat\"><Data ss:Type=\"String\">" + Convert.ToDecimal(dt.Rows[i]["NET T"]).ToString("C2").Replace(".", "").Replace(",", ".") + "</Data></Cell>");
                excelDoc.Write("<Cell ss:StyleID=\"Fiyat\"><Data ss:Type=\"String\">" + Convert.ToDecimal(dt.Rows[i]["NET+KDV T"]).ToString("C2").Replace(".", "").Replace(",", ".") + "</Data></Cell>");
                excelDoc.Write("</Row>");
            }

            excelDoc.Write("<Row>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\"></Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\"></Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\"></Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\"></Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\"></Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\"></Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"FiyatKalin\"><Data ss:Type=\"String\">_________________________</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">_________________</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">_________________</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">_________________</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">_________________</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">_________________</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">_________________</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">_________________</Data></Cell>");
            excelDoc.Write("</Row>");
            excelDoc.Write("<Row>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\"></Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\"></Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\"></Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\"></Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\"></Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\"></Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Toplam:</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">" + Convert.ToInt32(toplamlar[4]).ToString() + "</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">" + Convert.ToInt32(toplamlar[5]).ToString() + "</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"FiyatKalin\"><Data ss:Type=\"String\">" + Convert.ToDecimal(toplamlar[0]).ToString("C2").Replace(".", "").Replace(",", ".") + "</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"FiyatKalin\"><Data ss:Type=\"String\">" + Convert.ToDecimal(toplamlar[1]).ToString("C2").Replace(".", "").Replace(",", ".") + "</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"FiyatKalin\"><Data ss:Type=\"String\"></Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"FiyatKalin\"><Data ss:Type=\"String\">" + Convert.ToDecimal(toplamlar[2]).ToString("C2").Replace(".", "").Replace(",", ".") + "</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"FiyatKalin\"><Data ss:Type=\"String\">" + Convert.ToDecimal(toplamlar[3]).ToString("C2").Replace(".", "").Replace(",", ".") + "</Data></Cell>");
            excelDoc.Write("</Row>");

            excelDoc.Write("</Table>");
            excelDoc.Write("</Worksheet>");
            excelDoc.Write("</Workbook>");
            excelDoc.Flush();
            excelDoc.Close();
            Response.End();
        }





        private int GetSatisRaporCountBySMREF(int SMREF, int SLSREF)
        {
            bool TED = SatisTemsilcileri.GetSATKOD1BySLSREF(SLSREF).StartsWith("8");

            return SatisRapor.GetObjectCountBySMREF(SMREF, SLSREF, (ListItemCollection)Session["downloadyazdirsatisraporurunler"], (int)Session["downloadyazdirsatisraporurunlerselectedindex"],
                Session["downloadyazdirsatisraporozelkod"].ToString(), Session["downloadyazdirsatisraporfiyattip"].ToString(), (bool)Session["downloadyazdirsatisraporbedelsiz"],
                (bool)Session["downloadyazdirsatisraporiadeler"],
                ((UyeYetkileri)Session["Yetkiler"]).OzelKodlar, ((UyeYetkileri)Session["Yetkiler"]).GrupKodlar,
                (DateTime)Session["downloadyazdirsatisraportarih1"], (DateTime)Session["downloadyazdirsatisraportarih2"], TED);
        }

        private DataTable GetSatisRaporBySMREF(int SMREF, int SLSREF)
        {
            bool TED = SatisTemsilcileri.GetSATKOD1BySLSREF(SLSREF).StartsWith("8");

            DataTable dt = new DataTable();
            SatisRapor.GetObjectsBySMREF(dt, SMREF, SLSREF, (ListItemCollection)Session["downloadyazdirsatisraporurunler"], (int)Session["downloadyazdirsatisraporurunlerselectedindex"],
                Session["downloadyazdirsatisraporozelkod"].ToString(), Session["downloadyazdirsatisraporfiyattip"].ToString(), (bool)Session["downloadyazdirsatisraporbedelsiz"],
                (bool)Session["downloadyazdirsatisraporiadeler"],
                0, GetSatisRaporCountBySMREF(SMREF, SLSREF),
                ((UyeYetkileri)Session["Yetkiler"]).OzelKodlar, ((UyeYetkileri)Session["Yetkiler"]).GrupKodlar,
                (DateTime)Session["downloadyazdirsatisraportarih1"], (DateTime)Session["downloadyazdirsatisraportarih2"], TED);
            return dt;
        }

        private ArrayList GetSatisRaporToplamBySMREF(int SMREF, int SLSREF)
        {
            bool TED = SatisTemsilcileri.GetSATKOD1BySLSREF(SLSREF).StartsWith("8");

            ArrayList toplamlar = SatisRapor.GetToplamFiyatlarBySMREF(SMREF, SLSREF, (ListItemCollection)Session["downloadyazdirsatisraporurunler"], (int)Session["downloadyazdirsatisraporurunlerselectedindex"],
                Session["downloadyazdirsatisraporozelkod"].ToString(), Session["downloadyazdirsatisraporfiyattip"].ToString(), (bool)Session["downloadyazdirsatisraporbedelsiz"],
                (bool)Session["downloadyazdirsatisraporiadeler"],
                ((UyeYetkileri)Session["Yetkiler"]).OzelKodlar, ((UyeYetkileri)Session["Yetkiler"]).GrupKodlar,
                (DateTime)Session["downloadyazdirsatisraportarih1"], (DateTime)Session["downloadyazdirsatisraportarih2"], TED);
            return toplamlar;
        }


        private int GetSatisRaporCountByGMREF(int GMREF, int SLSREF)
        {
            bool TED = SatisTemsilcileri.GetSATKOD1BySLSREF(SLSREF).StartsWith("8");

            return SatisRapor.GetObjectCountByGMREF(GMREF, SLSREF, (ListItemCollection)Session["downloadyazdirsatisraporurunler"], (int)Session["downloadyazdirsatisraporurunlerselectedindex"],
                Session["downloadyazdirsatisraporozelkod"].ToString(), Session["downloadyazdirsatisraporfiyattip"].ToString(), (bool)Session["downloadyazdirsatisraporbedelsiz"],
                (bool)Session["downloadyazdirsatisraporiadeler"],
                ((UyeYetkileri)Session["Yetkiler"]).OzelKodlar, ((UyeYetkileri)Session["Yetkiler"]).GrupKodlar,
                (DateTime)Session["downloadyazdirsatisraportarih1"], (DateTime)Session["downloadyazdirsatisraportarih2"], TED);
        }

        private DataTable GetSatisRaporByGMREF(int GMREF, int SLSREF)
        {
            bool TED = SatisTemsilcileri.GetSATKOD1BySLSREF(SLSREF).StartsWith("8");

            DataTable dt = new DataTable();
            SatisRapor.GetObjectsByGMREF(dt, GMREF, SLSREF, (ListItemCollection)Session["downloadyazdirsatisraporurunler"], (int)Session["downloadyazdirsatisraporurunlerselectedindex"],
                Session["downloadyazdirsatisraporozelkod"].ToString(), Session["downloadyazdirsatisraporfiyattip"].ToString(), (bool)Session["downloadyazdirsatisraporbedelsiz"],
                (bool)Session["downloadyazdirsatisraporiadeler"],
                0, GetSatisRaporCountByGMREF(GMREF, SLSREF),
                ((UyeYetkileri)Session["Yetkiler"]).OzelKodlar, ((UyeYetkileri)Session["Yetkiler"]).GrupKodlar,
                (DateTime)Session["downloadyazdirsatisraportarih1"], (DateTime)Session["downloadyazdirsatisraportarih2"], TED);
            return dt;
        }

        private ArrayList GetSatisRaporToplamByGMREF(int GMREF, int SLSREF)
        {
            bool TED = SatisTemsilcileri.GetSATKOD1BySLSREF(SLSREF).StartsWith("8");

            ArrayList toplamlar = SatisRapor.GetToplamFiyatlarByGMREF(GMREF, SLSREF, (ListItemCollection)Session["downloadyazdirsatisraporurunler"], (int)Session["downloadyazdirsatisraporurunlerselectedindex"],
                Session["downloadyazdirsatisraporozelkod"].ToString(), Session["downloadyazdirsatisraporfiyattip"].ToString(), (bool)Session["downloadyazdirsatisraporbedelsiz"], 
                (bool)Session["downloadyazdirsatisraporiadeler"],
                ((UyeYetkileri)Session["Yetkiler"]).OzelKodlar, ((UyeYetkileri)Session["Yetkiler"]).GrupKodlar,
                (DateTime)Session["downloadyazdirsatisraportarih1"], (DateTime)Session["downloadyazdirsatisraportarih2"], TED);
            return toplamlar;
        }


        private int GetSatisRaporCountBySLSREF(int SLSREF)
        {
            bool TED = SatisTemsilcileri.GetSATKOD1BySLSREF(SLSREF).StartsWith("8");

            return SatisRapor.GetObjectCountBySLSREF(SLSREF, (ListItemCollection)Session["downloadyazdirsatisraporurunler"], (int)Session["downloadyazdirsatisraporurunlerselectedindex"],
                Session["downloadyazdirsatisraporozelkod"].ToString(), Session["downloadyazdirsatisraporfiyattip"].ToString(), (bool)Session["downloadyazdirsatisraporbedelsiz"],
                (bool)Session["downloadyazdirsatisraporiadeler"],
                ((UyeYetkileri)Session["Yetkiler"]).OzelKodlar, ((UyeYetkileri)Session["Yetkiler"]).GrupKodlar,
                (DateTime)Session["downloadyazdirsatisraportarih1"], (DateTime)Session["downloadyazdirsatisraportarih2"], TED);
        }

        private DataTable GetSatisRaporBySLSREF(int SLSREF)
        {
            bool TED = SatisTemsilcileri.GetSATKOD1BySLSREF(SLSREF).StartsWith("8");

            DataTable dt = new DataTable();
            SatisRapor.GetObjectsBySLSREF(dt, SLSREF, (ListItemCollection)Session["downloadyazdirsatisraporurunler"], (int)Session["downloadyazdirsatisraporurunlerselectedindex"],
                Session["downloadyazdirsatisraporozelkod"].ToString(), Session["downloadyazdirsatisraporfiyattip"].ToString(), (bool)Session["downloadyazdirsatisraporbedelsiz"],
                (bool)Session["downloadyazdirsatisraporiadeler"],
                0, GetSatisRaporCountBySLSREF(SLSREF),
                ((UyeYetkileri)Session["Yetkiler"]).OzelKodlar, ((UyeYetkileri)Session["Yetkiler"]).GrupKodlar,
                (DateTime)Session["downloadyazdirsatisraportarih1"], (DateTime)Session["downloadyazdirsatisraportarih2"], TED);
            return dt;
        }

        private ArrayList GetSatisRaporToplamBySLSREF(int SLSREF)
        {
            bool TED = SatisTemsilcileri.GetSATKOD1BySLSREF(SLSREF).StartsWith("8");

            ArrayList toplamlar = SatisRapor.GetToplamFiyatlarBySLSREF(SLSREF, (ListItemCollection)Session["downloadyazdirsatisraporurunler"], (int)Session["downloadyazdirsatisraporurunlerselectedindex"],
                Session["downloadyazdirsatisraporozelkod"].ToString(), Session["downloadyazdirsatisraporfiyattip"].ToString(), (bool)Session["downloadyazdirsatisraporbedelsiz"],
                (bool)Session["downloadyazdirsatisraporiadeler"],
                ((UyeYetkileri)Session["Yetkiler"]).OzelKodlar, ((UyeYetkileri)Session["Yetkiler"]).GrupKodlar,
                (DateTime)Session["downloadyazdirsatisraportarih1"], (DateTime)Session["downloadyazdirsatisraportarih2"], TED);
            return toplamlar;
        }


        private int GetSatisRaporCountBySLSREFs(int SLSREF)
        {
            ArrayList slsrefs = SatisTemsilcileriSefler.GetAltRefler(SLSREF);
            bool TED = SatisTemsilcileri.GetSATKOD1BySLSREF(SLSREF).StartsWith("8");

            return SatisRapor.GetObjectCountBySLSREFs(slsrefs, (ListItemCollection)Session["downloadyazdirsatisraporurunler"], (int)Session["downloadyazdirsatisraporurunlerselectedindex"],
                Session["downloadyazdirsatisraporozelkod"].ToString(), Session["downloadyazdirsatisraporfiyattip"].ToString(), (bool)Session["downloadyazdirsatisraporbedelsiz"],
                (bool)Session["downloadyazdirsatisraporiadeler"],
                ((UyeYetkileri)Session["Yetkiler"]).OzelKodlar, ((UyeYetkileri)Session["Yetkiler"]).GrupKodlar,
                (DateTime)Session["downloadyazdirsatisraportarih1"], (DateTime)Session["downloadyazdirsatisraportarih2"], TED);
        }

        private DataTable GetSatisRaporBySLSREFs(int SLSREF)
        {
            ArrayList slsrefs = SatisTemsilcileriSefler.GetAltRefler(SLSREF);
            bool TED = SatisTemsilcileri.GetSATKOD1BySLSREF(SLSREF).StartsWith("8");

            DataTable dt = new DataTable();
            SatisRapor.GetObjectsBySLSREFs(dt, slsrefs, (ListItemCollection)Session["downloadyazdirsatisraporurunler"], (int)Session["downloadyazdirsatisraporurunlerselectedindex"],
                Session["downloadyazdirsatisraporozelkod"].ToString(), Session["downloadyazdirsatisraporfiyattip"].ToString(), (bool)Session["downloadyazdirsatisraporbedelsiz"],
                (bool)Session["downloadyazdirsatisraporiadeler"],
                0, GetSatisRaporCountBySLSREFs(SLSREF),
                ((UyeYetkileri)Session["Yetkiler"]).OzelKodlar, ((UyeYetkileri)Session["Yetkiler"]).GrupKodlar,
                (DateTime)Session["downloadyazdirsatisraportarih1"], (DateTime)Session["downloadyazdirsatisraportarih2"], TED);
            return dt;
        }

        private ArrayList GetSatisRaporToplamBySLSREFs(int SLSREF)
        {
            ArrayList slsrefs = SatisTemsilcileriSefler.GetAltRefler(SLSREF);
            bool TED = SatisTemsilcileri.GetSATKOD1BySLSREF(SLSREF).StartsWith("8");

            ArrayList toplamlar = SatisRapor.GetToplamFiyatlarBySLSREFs(slsrefs, (ListItemCollection)Session["downloadyazdirsatisraporurunler"], (int)Session["downloadyazdirsatisraporurunlerselectedindex"],
                Session["downloadyazdirsatisraporozelkod"].ToString(), Session["downloadyazdirsatisraporfiyattip"].ToString(), (bool)Session["downloadyazdirsatisraporbedelsiz"],
                (bool)Session["downloadyazdirsatisraporiadeler"],
                ((UyeYetkileri)Session["Yetkiler"]).OzelKodlar, ((UyeYetkileri)Session["Yetkiler"]).GrupKodlar,
                (DateTime)Session["downloadyazdirsatisraportarih1"], (DateTime)Session["downloadyazdirsatisraportarih2"], TED);
            return toplamlar;
        }


        private int GetSatisRaporCount()
        {
            return SatisRapor.GetObjectCount((ListItemCollection)Session["downloadyazdirsatisraporurunler"], (int)Session["downloadyazdirsatisraporurunlerselectedindex"],
                Session["downloadyazdirsatisraporozelkod"].ToString(), Session["downloadyazdirsatisraporfiyattip"].ToString(), (bool)Session["downloadyazdirsatisraporbedelsiz"],
                (bool)Session["downloadyazdirsatisraporiadeler"],
                ((UyeYetkileri)Session["Yetkiler"]).OzelKodlar, ((UyeYetkileri)Session["Yetkiler"]).GrupKodlar,
                (DateTime)Session["downloadyazdirsatisraportarih1"], (DateTime)Session["downloadyazdirsatisraportarih2"]);
        }

        private DataTable GetSatisRapor()
        {
            DataTable dt = new DataTable();
            SatisRapor.GetObjects(dt, (ListItemCollection)Session["downloadyazdirsatisraporurunler"], (int)Session["downloadyazdirsatisraporurunlerselectedindex"],
                Session["downloadyazdirsatisraporozelkod"].ToString(), Session["downloadyazdirsatisraporfiyattip"].ToString(), (bool)Session["downloadyazdirsatisraporbedelsiz"],
                (bool)Session["downloadyazdirsatisraporiadeler"],
                0, GetSatisRaporCount(),
                ((UyeYetkileri)Session["Yetkiler"]).OzelKodlar, ((UyeYetkileri)Session["Yetkiler"]).GrupKodlar,
                (DateTime)Session["downloadyazdirsatisraportarih1"], (DateTime)Session["downloadyazdirsatisraportarih2"]);
            return dt;
        }

        private ArrayList GetSatisRaporToplam()
        {
            ArrayList toplamlar = SatisRapor.GetToplamFiyatlar((ListItemCollection)Session["downloadyazdirsatisraporurunler"], (int)Session["downloadyazdirsatisraporurunlerselectedindex"],
                Session["downloadyazdirsatisraporozelkod"].ToString(), Session["downloadyazdirsatisraporfiyattip"].ToString(), (bool)Session["downloadyazdirsatisraporbedelsiz"],
                (bool)Session["downloadyazdirsatisraporiadeler"],
                ((UyeYetkileri)Session["Yetkiler"]).OzelKodlar, ((UyeYetkileri)Session["Yetkiler"]).GrupKodlar,
                (DateTime)Session["downloadyazdirsatisraportarih1"], (DateTime)Session["downloadyazdirsatisraportarih2"]);
            return toplamlar;
        }

        //protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        //{
        //    if (Session["downloadsiparisid"] != null)
        //    {
        //        ExportToExcel((int)Session["downloadsiparisid"]);
        //        Response.Write("<script type='text/javascript'>window.close()</script>");
        //    }
        //    else if (Session["downloadekstregmref"] != null)
        //    {
        //        ExportToExcelEkstre((int)Session["downloadekstregmref"]);
        //        Response.Write("<script type='text/javascript'>window.close()</script>");
        //    }
        //    else if (Session["downloadodemeid"] != null)
        //    {
        //        ExportToExcelOdeme((int)Session["downloadodemeid"]);
        //        Response.Write("<script type='text/javascript'>window.close()</script>");
        //    }
        //    else if (Session["downloadsatisraporgmref"] != null && Session["downloadsatisraporslsref"] != null)
        //    {
        //        ExportToExcelSatisRapor((int)Session["downloadsatisraporgmref"], (int)Session["downloadsatisraporslsref"], true);
        //        Response.Write("<script type='text/javascript'>window.close()</script>");
        //    }
        //    else if (Session["downloadsatisraporsmref"] != null && Session["downloadsatisraporslsref"] != null)
        //    {
        //        ExportToExcelSatisRapor((int)Session["downloadsatisraporsmref"], (int)Session["downloadsatisraporslsref"], false);
        //        Response.Write("<script type='text/javascript'>window.close()</script>");
        //    }
        //}




        private void EFatura()
        {
            string DosyaAdi = "Efatura.XML";
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
            XMLbasi.AppendLine("<?xml version=\"1.0\" encoding=\"ISO-8859-9\"?>");
            XMLbasi.AppendLine("<e_fatura>");
            XMLbasi.AppendLine("\t<sirket>SULTANLAR PAZARLAMA EV İHTİYAÇ MADDELERİ A.Ş.</sirket>");
            XMLbasi.AppendLine("\t<vergino>7820046282</vergino>");
            XMLbasi.AppendLine("\t<email>bilgi@sultanlar.com.tr</email>");
            XMLbasi.AppendLine("\t<hesapno>3416200196</hesapno>");
            XMLbasi.AppendLine("\t<versiyon>1.0.0</versiyon>");
            xmlDoc.Write(XMLbasi.ToString());
            #endregion

            #region Alias
            if (Session["EFaturaAlias"] != null)
            {
                for (int i = 0; i < ((ArrayList)Session["EFaturaFaturaNolar"]).Count; i++)
                {
                    System.Text.StringBuilder XMLorta = new System.Text.StringBuilder();

                    DataTable dt = new DataTable();
                    Efatura.GetObjectByFATNO(dt, ((ArrayList)Session["EFaturaFaturaNolar"])[i].ToString());

                    XMLorta.AppendLine("\t<fatura>");



                    EFatura efat = (EFatura)Session["EFaturaAlias"];
                    if (efat._LT != string.Empty)
                        XMLorta.AppendLine("\t\t<" + efat._LT + ">" + dt.Rows[0]["LT"].ToString() + "</" + efat._LT + ">");
                    if (efat._BOLGE != string.Empty)
                        XMLorta.AppendLine("\t\t<" + efat._BOLGE + ">" + dt.Rows[0]["BOLGE"].ToString() + "</" + efat._BOLGE + ">");
                    if (efat._GRP != string.Empty)
                        XMLorta.AppendLine("\t\t<" + efat._GRP + ">" + dt.Rows[0]["GRP"].ToString() + "</" + efat._GRP + ">");
                    if (efat._EKP != string.Empty)
                        XMLorta.AppendLine("\t\t<" + efat._EKP + ">" + dt.Rows[0]["EKP"].ToString() + "</" + efat._EKP + ">");
                    if (efat._ABRNO != string.Empty)
                        XMLorta.AppendLine("\t\t<" + efat._ABRNO + ">" + dt.Rows[0]["ABR NO"].ToString() + "</" + efat._ABRNO + ">");
                    if (efat._AMBAR != string.Empty)
                        XMLorta.AppendLine("\t\t<" + efat._AMBAR + ">" + dt.Rows[0]["AMBAR"].ToString() + "</" + efat._AMBAR + ">");
                    if (efat._AY != string.Empty)
                        XMLorta.AppendLine("\t\t<" + efat._AY + ">" + dt.Rows[0]["AY"].ToString() + "</" + efat._AY + ">");
                    if (efat._HAFTA != string.Empty)
                        XMLorta.AppendLine("\t\t<" + efat._HAFTA + ">" + dt.Rows[0]["HAFTA"].ToString() + "</" + efat._HAFTA + ">");
                    if (efat._FATTAR != string.Empty)
                        XMLorta.AppendLine("\t\t<" + efat._FATTAR + ">" + dt.Rows[0]["FAT TAR"].ToString() + "</" + efat._FATTAR + ">");
                    if (efat._FATNO != string.Empty)
                        XMLorta.AppendLine("\t\t<" + efat._FATNO + ">" + dt.Rows[0]["FAT NO"].ToString() + "</" + efat._FATNO + ">");
                    if (efat._FATVD != string.Empty)
                        XMLorta.AppendLine("\t\t<" + efat._FATVD + ">" + dt.Rows[0]["FAT VD"].ToString() + "</" + efat._FATVD + ">");
                    if (efat._TUR != string.Empty)
                        XMLorta.AppendLine("\t\t<" + efat._TUR + ">" + dt.Rows[0]["TUR"].ToString() + "</" + efat._TUR + ">");
                    if (efat._TURACK != string.Empty)
                        XMLorta.AppendLine("\t\t<" + efat._TURACK + ">" + dt.Rows[0]["TUR ACK"].ToString() + "</" + efat._TURACK + ">");
                    if (efat._FTUR != string.Empty)
                        XMLorta.AppendLine("\t\t<" + efat._FTUR + ">" + dt.Rows[0]["F TUR"].ToString() + "</" + efat._FTUR + ">");
                    if (efat._SLSREF != string.Empty)
                        XMLorta.AppendLine("\t\t<" + efat._SLSREF + ">" + dt.Rows[0]["SLSREF"].ToString() + "</" + efat._SLSREF + ">");
                    if (efat._SATKOD != string.Empty)
                        XMLorta.AppendLine("\t\t<" + efat._SATKOD + ">" + dt.Rows[0]["SAT KOD"].ToString() + "</" + efat._SATKOD + ">");
                    if (efat._SATTEM != string.Empty)
                        XMLorta.AppendLine("\t\t<" + efat._SATTEM + ">" + dt.Rows[0]["SAT TEM"].ToString() + "</" + efat._SATTEM + ">");
                    if (efat._TEDEKP != string.Empty)
                        XMLorta.AppendLine("\t\t<" + efat._TEDEKP + ">" + dt.Rows[0]["TED EKP"].ToString() + "</" + efat._TEDEKP + ">");
                    if (efat._TEDSLSREF != string.Empty)
                        XMLorta.AppendLine("\t\t<" + efat._TEDSLSREF + ">" + dt.Rows[0]["TEDSLSREF"].ToString() + "</" + efat._TEDSLSREF + ">");
                    if (efat._TEDSATTEM != string.Empty)
                        XMLorta.AppendLine("\t\t<" + efat._TEDSATTEM + ">" + dt.Rows[0]["TED SAT TEM"].ToString() + "</" + efat._TEDSATTEM + ">");
                    if (efat._IL != string.Empty)
                        XMLorta.AppendLine("\t\t<" + efat._IL + ">" + dt.Rows[0]["IL"].ToString() + "</" + efat._IL + ">");
                    if (efat._ILCE != string.Empty)
                        XMLorta.AppendLine("\t\t<" + efat._ILCE + ">" + dt.Rows[0]["ILCE"].ToString() + "</" + efat._ILCE + ">");
                    if (efat._MTACIKLAMA != string.Empty)
                        XMLorta.AppendLine("\t\t<" + efat._MTACIKLAMA + ">" + dt.Rows[0]["MT ACIKLAMA"].ToString() + "</" + efat._MTACIKLAMA + ">");
                    if (efat._GMREF != string.Empty)
                        XMLorta.AppendLine("\t\t<" + efat._GMREF + ">" + dt.Rows[0]["GMREF"].ToString() + "</" + efat._GMREF + ">");
                    if (efat._MUSKOD != string.Empty)
                        XMLorta.AppendLine("\t\t<" + efat._MUSKOD + ">" + dt.Rows[0]["MUS KOD"].ToString() + "</" + efat._MUSKOD + ">");
                    if (efat._MUSTERI != string.Empty)
                        XMLorta.AppendLine("\t\t<" + efat._MUSTERI + ">" + dt.Rows[0]["MUSTERI"].ToString() + "</" + efat._MUSTERI + ">");
                    if (efat._SMREF != string.Empty)
                        XMLorta.AppendLine("\t\t<" + efat._SMREF + ">" + dt.Rows[0]["SMREF"].ToString() + "</" + efat._SMREF + ">");
                    if (efat._SUBKOD != string.Empty)
                        XMLorta.AppendLine("\t\t<" + efat._SUBKOD + ">" + dt.Rows[0]["SUB KOD"].ToString() + "</" + efat._SUBKOD + ">");
                    if (efat._SUBE != string.Empty)
                        XMLorta.AppendLine("\t\t<" + efat._SUBE + ">" + dt.Rows[0]["SUBE"].ToString() + "</" + efat._SUBE + ">");
                    if (efat._SEVKKOD != string.Empty)
                        XMLorta.AppendLine("\t\t<" + efat._SEVKKOD + ">" + dt.Rows[0]["SEVK KOD"].ToString() + "</" + efat._SEVKKOD + ">");
                    if (efat._SEVKADRES != string.Empty)
                        XMLorta.AppendLine("\t\t<" + efat._SEVKADRES + ">" + dt.Rows[0]["SEVK ADRES"].ToString() + "</" + efat._SEVKADRES + ">");
                    if (efat._REYKOD != string.Empty)
                        XMLorta.AppendLine("\t\t<" + efat._REYKOD + ">" + dt.Rows[0]["REY KOD"].ToString() + "</" + efat._REYKOD + ">");
                    if (efat._REYON != string.Empty)
                        XMLorta.AppendLine("\t\t<" + efat._REYON + ">" + dt.Rows[0]["REYON"].ToString() + "</" + efat._REYON + ">");
                    if (efat._ANAGRP != string.Empty)
                        XMLorta.AppendLine("\t\t<" + efat._ANAGRP + ">" + dt.Rows[0]["ANA GRP"].ToString() + "</" + efat._ANAGRP + ">");
                    if (efat._GRPKOD != string.Empty)
                        XMLorta.AppendLine("\t\t<" + efat._GRPKOD + ">" + dt.Rows[0]["GRP KOD"].ToString() + "</" + efat._GRPKOD + ">");
                    if (efat._GRUP != string.Empty)
                        XMLorta.AppendLine("\t\t<" + efat._GRUP + ">" + dt.Rows[0]["GRUP"].ToString() + "</" + efat._GRUP + ">");
                    if (efat._TEDGRP != string.Empty)
                        XMLorta.AppendLine("\t\t<" + efat._TEDGRP + ">" + dt.Rows[0]["TED GRP"].ToString() + "</" + efat._TEDGRP + ">");

                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        XMLorta.AppendLine("\t\t<urun>");

                        if (efat._TEDKISAMAL != string.Empty)
                            XMLorta.AppendLine("\t\t\t<" + efat._TEDKISAMAL + ">" + dt.Rows[j]["TED KISA MAL"].ToString() + "</" + efat._TEDKISAMAL + ">");
                        if (efat._BARCODE != string.Empty)
                            XMLorta.AppendLine("\t\t\t<" + efat._BARCODE + ">" + dt.Rows[j]["BARCODE"].ToString() + "</" + efat._BARCODE + ">");
                        if (efat._ITEMREF != string.Empty)
                            XMLorta.AppendLine("\t\t\t<" + efat._ITEMREF + ">" + dt.Rows[j]["ITEMREF"].ToString() + "</" + efat._ITEMREF + ">");
                        if (efat._MALKOD != string.Empty)
                            XMLorta.AppendLine("\t\t\t<" + efat._MALKOD + ">" + dt.Rows[j]["MAL KOD"].ToString() + "</" + efat._MALKOD + ">");
                        if (efat._MALZEME != string.Empty)
                            XMLorta.AppendLine("\t\t\t<" + efat._MALZEME + ">" + dt.Rows[j]["MALZEME"].ToString() + "</" + efat._MALZEME + ">");
                        if (efat._KOLI != string.Empty)
                            XMLorta.AppendLine("\t\t\t<" + efat._KOLI + ">" + dt.Rows[j]["KOLI"].ToString() + "</" + efat._KOLI + ">");
                        if (efat._KDV != string.Empty)
                            XMLorta.AppendLine("\t\t\t<" + efat._KDV + ">" + dt.Rows[j]["KDV"].ToString() + "</" + efat._KDV + ">");
                        if (efat._BRM != string.Empty)
                            XMLorta.AppendLine("\t\t\t<" + efat._BRM + ">" + dt.Rows[j]["BRM"].ToString() + "</" + efat._BRM + ">");
                        if (efat._ADT != string.Empty)
                            XMLorta.AppendLine("\t\t\t<" + efat._ADT + ">" + dt.Rows[j]["AD T"].ToString() + "</" + efat._ADT + ">");
                        if (efat._ISK1 != string.Empty)
                            XMLorta.AppendLine("\t\t\t<" + efat._ISK1 + ">" + dt.Rows[j]["ISK1"].ToString() + "</" + efat._ISK1 + ">");
                        if (efat._ISK2 != string.Empty)
                            XMLorta.AppendLine("\t\t\t<" + efat._ISK2 + ">" + dt.Rows[j]["ISK2"].ToString() + "</" + efat._ISK2 + ">");
                        if (efat._ISK3 != string.Empty)
                            XMLorta.AppendLine("\t\t\t<" + efat._ISK3 + ">" + dt.Rows[j]["ISK3"].ToString() + "</" + efat._ISK3 + ">");
                        if (efat._ISK4 != string.Empty)
                            XMLorta.AppendLine("\t\t\t<" + efat._ISK4 + ">" + dt.Rows[j]["ISK4"].ToString() + "</" + efat._ISK4 + ">");
                        if (efat._ISK5 != string.Empty)
                            XMLorta.AppendLine("\t\t\t<" + efat._ISK5 + ">" + dt.Rows[j]["ISK5"].ToString() + "</" + efat._ISK5 + ">");
                        if (efat._ISKALT != string.Empty)
                            XMLorta.AppendLine("\t\t\t<" + efat._ISKALT + ">" + dt.Rows[j]["ISKALT"].ToString() + "</" + efat._ISKALT + ">");
                        if (efat._BRUTT != string.Empty)
                            XMLorta.AppendLine("\t\t\t<" + efat._BRUTT + ">" + dt.Rows[j]["BRUT T"].ToString() + "</" + efat._BRUTT + ">");
                        if (efat._ISKT != string.Empty)
                            XMLorta.AppendLine("\t\t\t<" + efat._ISKT + ">" + dt.Rows[j]["ISK T"].ToString() + "</" + efat._ISKT + ">");
                        if (efat._NETT != string.Empty)
                            XMLorta.AppendLine("\t\t\t<" + efat._NETT + ">" + dt.Rows[j]["NET T"].ToString() + "</" + efat._NETT + ">");
                        if (efat._KDVT != string.Empty)
                            XMLorta.AppendLine("\t\t\t<" + efat._KDVT + ">" + dt.Rows[j]["KDV T"].ToString() + "</" + efat._KDVT + ">");
                        if (efat._NETKDVT != string.Empty)
                            XMLorta.AppendLine("\t\t\t<" + efat._NETKDVT + ">" + dt.Rows[j]["NET+KDV T"].ToString() + "</" + efat._NETKDVT + ">");

                        XMLorta.AppendLine("\t\t</urun>");
                    }



                    XMLorta.AppendLine("\t</fatura>");

                    xmlDoc.Write(XMLorta.ToString());
                }
            }
            #endregion

            #region İlon, Eczanem, Tebeos
            if (Session["EFaturaAlias"] == null && (Session["EFaturaProgram"] == "ilon" || Session["EFaturaProgram"] == "eczanem" || Session["EFaturaProgram"] == "tebeos"))
            {
                for (int i = 0; i < ((ArrayList)Session["EFaturaFaturaNolar"]).Count; i++)
                {
                    System.Text.StringBuilder XMLorta = new System.Text.StringBuilder();

                    DataTable dt = new DataTable();
                    Efatura.GetObjectByFATNO(dt, ((ArrayList)Session["EFaturaFaturaNolar"])[i].ToString());

                    double toplamtutar = 0;
                    for (int j = 0; j < dt.Rows.Count; j++)
                        toplamtutar += Convert.ToDouble(dt.Rows[j]["NET+KDV T"]);

                    XMLorta.AppendLine("\t<fatura>");



                    XMLorta.AppendLine("\t\t<gln>8691014000012</gln>");
                    XMLorta.AppendLine("\t\t<sayfano>" + dt.Rows[0]["FAT NO"].ToString() + "</sayfano>");
                    XMLorta.AppendLine("\t\t<tarih>" + dt.Rows[0]["FAT TAR"].ToString().Replace(".", "/") + "</tarih>");
                    XMLorta.AppendLine("\t\t<faturatipi>NORMAL</faturatipi>");
                    XMLorta.AppendLine("\t\t<faturahazirlanmayeri>SULTANLAR DEPO</faturahazirlanmayeri>");
                    XMLorta.AppendLine("\t\t<yuvarlama>0</yuvarlama>");
                    XMLorta.AppendLine("\t\t<faturaturu>NORMAL</faturaturu>");
                    XMLorta.AppendLine("\t\t<vadeseldagilim>");
                    XMLorta.AppendLine("\t\t\t<odemetarih>" + dt.Rows[0]["FAT VD"].ToString().Replace(".", "/") + "</odemetarih>");
                    XMLorta.AppendLine("\t\t\t<vadeseltoplam>" + toplamtutar.ToString("F").Replace(".", "").Replace(",", ".") + "</vadeseltoplam>");
                    XMLorta.AppendLine("\t\t\t<mfiskonto>0</mfiskonto>");
                    XMLorta.AppendLine("\t\t\t<geneliskonto>0</geneliskonto>");
                    XMLorta.AppendLine("\t\t\t<taksitsayisi>0</taksitsayisi>");
                    XMLorta.AppendLine("\t\t\t<taksitaralik>0</taksitaralik>");
                    XMLorta.AppendLine("\t\t\t<odemeplani>");
                    XMLorta.AppendLine("\t\t\t\t<vade>");
                    XMLorta.AppendLine("\t\t\t\t\t<vadetarihi>" + dt.Rows[0]["FAT VD"].ToString().Replace(".", "/") + "</vadetarihi>");
                    XMLorta.AppendLine("\t\t\t\t\t<vadetutari>" + toplamtutar.ToString("F").Replace(".", "").Replace(",", ".") + "</vadetutari>");
                    XMLorta.AppendLine("\t\t\t\t</vade>");
                    XMLorta.AppendLine("\t\t\t</odemeplani>");

                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        XMLorta.AppendLine("\t\t\t<ilac>");

                        XMLorta.AppendLine("\t\t\t\t<isim>" + dt.Rows[j]["MALZEME"].ToString() + "</isim>");
                        XMLorta.AppendLine("\t\t\t\t<barkodu>" + dt.Rows[j]["BARCODE"].ToString() + "</barkodu>");
                        XMLorta.AppendLine("\t\t\t\t<ilackodu></ilackodu>");
                        XMLorta.AppendLine("\t\t\t\t<etiketfiyati>" + (Convert.ToDouble(dt.Rows[j]["BRUT T"]) / Convert.ToDouble(dt.Rows[j]["AD T"])).ToString("F").Replace(".", "").Replace(",", ".") + "</etiketfiyati>");
                        XMLorta.AppendLine("\t\t\t\t<depocufiyati>" + (Convert.ToDouble(dt.Rows[j]["BRUT T"]) / Convert.ToDouble(dt.Rows[j]["AD T"])).ToString("F").Replace(".", "").Replace(",", ".") + "</depocufiyati>");
                        XMLorta.AppendLine("\t\t\t\t<eczacifiyati>" + (Convert.ToDouble(dt.Rows[j]["BRUT T"]) / Convert.ToDouble(dt.Rows[j]["AD T"])).ToString("F").Replace(".", "").Replace(",", ".") + "</eczacifiyati>");
                        XMLorta.AppendLine("\t\t\t\t<miktar>" + dt.Rows[j]["AD T"].ToString() + "</miktar>");

                        //string mf = dt.Rows[j]["ISK1"].ToString().StartsWith("100") ? "1" : "0";
                        XMLorta.AppendLine("\t\t\t\t<mf>0</mf>");

                        string isk1 = dt.Rows[j]["ISK1"].ToString() == "" ? "0" : dt.Rows[j]["ISK1"].ToString();
                        XMLorta.AppendLine("\t\t\t\t<iskontoorani1>" + isk1 + "</iskontoorani1>");

                        string isk2 = dt.Rows[j]["ISK2"].ToString() == "" ? "0" : dt.Rows[j]["ISK2"].ToString();
                        XMLorta.AppendLine("\t\t\t\t<iskontoorani2>" + isk2 + "</iskontoorani2>");

                        string isk3 = dt.Rows[j]["ISK3"].ToString() == "" ? "0" : dt.Rows[j]["ISK3"].ToString();
                        XMLorta.AppendLine("\t\t\t\t<iskontoorani3>" + isk3 + "</iskontoorani3>");

                        string isk4 = dt.Rows[j]["ISK4"].ToString() == "" ? "0" : dt.Rows[j]["ISK4"].ToString();
                        XMLorta.AppendLine("\t\t\t\t<iskontoorani4>" + isk4 + "</iskontoorani4>");

                        XMLorta.AppendLine("\t\t\t\t<eczkarorani></eczkarorani>");
                        XMLorta.AppendLine("\t\t\t\t<eczkartutari></eczkartutari>");
                        XMLorta.AppendLine("\t\t\t\t<ithal>H</ithal>");
                        XMLorta.AppendLine("\t\t\t\t<kdvdus>H</kdvdus>");
                        XMLorta.AppendLine("\t\t\t\t<kdv>" + dt.Rows[j]["KDV"].ToString() + "</kdv>");
                        XMLorta.AppendLine("\t\t\t\t<aliskdv>" + dt.Rows[j]["KDV"].ToString() + "</aliskdv>");
                        XMLorta.AppendLine("\t\t\t\t<ilactipi>ITRIYAT</ilactipi>");
                        XMLorta.AppendLine("\t\t\t\t<miad></miad>");

                        XMLorta.AppendLine("\t\t\t</ilac>");
                    }



                    XMLorta.AppendLine("\t\t</vadeseldagilim>");
                    XMLorta.AppendLine("\t</fatura>");

                    xmlDoc.Write(XMLorta.ToString());
                }
            }
            #endregion

            #region XMLsonu
            System.Text.StringBuilder XMLsonu = new System.Text.StringBuilder();
            XMLsonu.AppendLine("</e_fatura>");
            xmlDoc.Write(XMLsonu.ToString());
            #endregion

            xmlDoc.Flush();
            //excelDoc.Close();
            Response.End();
        }
    }
}
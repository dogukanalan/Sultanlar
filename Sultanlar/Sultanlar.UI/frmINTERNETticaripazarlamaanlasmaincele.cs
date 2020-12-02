using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sultanlar.DatabaseObject.Internet;

namespace Sultanlar.UI
{
    public partial class frmINTERNETticaripazarlamaanlasmaincele : Form
    {
        public frmINTERNETticaripazarlamaanlasmaincele(int AnlasmaID)
        {
            InitializeComponent();
            anlasma = Anlasmalar.GetObject(AnlasmaID);
            this.Text = anlasma.strAciklama2 == "1" ?
                "Ticari Pazarlama : Anlaşma " + anlasma.pkID.ToString() + " (" + CariHesaplarTP.GetObject(anlasma.SMREF, false).SUBE + ")"
                : "Ticari Pazarlama : Anlaşma " + anlasma.pkID.ToString() + " (" + CariHesaplar.GetMUSTERIbyGMREF(anlasma.SMREF) + ")";
        }

        public Anlasmalar anlasma;

        private void frmINTERNETticaripazarlamaanlasmaincele_Load(object sender, EventArgs e)
        {
            GetAnlasma();
        }

        private void frmINTERNETticaripazarlamaanlasmaincele_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmAna frm1 = (frmAna)this.ParentForm;
            frm1.FormKapanirken(this.Name);
        }

        private void GetAnlasma()
        {
            CariHesaplarTP cari = CariHesaplarTP.GetObject(anlasma.SMREF, false);
            CariHesaplarTP bayi = CariHesaplarTP.GetObject(anlasma.SMREF, true);

            txtCari.Text = anlasma.strAciklama2 == "1" ? cari.SUBE : CariHesaplar.GetMUSTERIbyGMREF(anlasma.SMREF);
            txtIl.Text = anlasma.strAciklama2 == "1" ? cari.IL : "İSTANBUL";
            txtBayi.Text = anlasma.strAciklama2 == "1" ? bayi.MUSTERI : "SULTANLAR PAZARLAMA A.Ş.";

            txtSubeSayisi.Text = anlasma.strAciklama4;
            dtpBaslangic.Value = anlasma.dtBaslangic;
            dtpBitis.Value = anlasma.dtBitis;
            txtVadeTAH.Text = anlasma.intVadeTAH.ToString();
            txtVadeYEG.Text = anlasma.intVadeYEG.ToString();
            txtSKUTAH.Text = anlasma.intListSKUTAH.ToString();
            txtSKUYEG.Text = anlasma.intListSKUYEG.ToString();

            txtTAHIsk.Text = anlasma.flTAHIsk.ToString("N1");
            txtTAHCiro.Text = anlasma.flTAHCiro.ToString("N1");
            txtTAHCiro3.Text = anlasma.flTAHCiro3.ToString("N1");
            txtTAHCiro6.Text = anlasma.flTAHCiro6.ToString("N1");
            txtTAHCiro12.Text = anlasma.flTAHCiro12.ToString("N1");
            txtTAHCiroIsk.Text = anlasma.flTAHCiroIsk.ToString("N1");
            txtYEGIsk.Text = anlasma.flYEGIsk.ToString("N1");
            txtYEGCiro.Text = anlasma.flYEGCiro.ToString("N1");
            txtYEGCiro3.Text = anlasma.flYEGCiro3.ToString("N1");
            txtYEGCiro6.Text = anlasma.flYEGCiro6.ToString("N1");
            txtYEGCiro12.Text = anlasma.flYEGCiro12.ToString("N1");
            txtYEGCiroIsk.Text = anlasma.flYEGCiroIsk.ToString("N1");

            txtTAHAnlasmaDisi.Text = anlasma.mnTAHAnlasmaDisiBedeller.ToString("C2");
            txtYEGAnlasmaDisi.Text = anlasma.mnYEGAnlasmaDisiBedeller.ToString("C2");
            txtTAHTumBedeller.Text = (anlasma.mnTAHAnlasmaDisiBedeller + anlasma.TAHTumBedellerToplami).ToString("C2");
            txtYEGTumBedeller.Text = (anlasma.mnYEGAnlasmaDisiBedeller + anlasma.YEGTumBedellerToplami).ToString("C2");
            txtTAHToplamCiro.Text = anlasma.mnTAHToplamCiro.ToString("C2");
            txtYEGToplamCiro.Text = anlasma.mnYEGToplamCiro.ToString("C2");
            txtTAHToplamMaliyet.Text = anlasma.TAHYilSonuMaliyet.ToString("N1");
            txtYEGToplamMaliyet.Text = anlasma.YEGYilSonuMaliyet.ToString("N1");
            txtTAHCiroDahilMaliyet.Text = anlasma.TAHCiroPrimiDahilNetMaliyet.ToString("N1");
            txtYEGCiroDahilMaliyet.Text = anlasma.YEGCiroPrimiDahilNetMaliyet.ToString("N1");

            txtAciklama.Text = anlasma.strAciklama1;

            GetAnlasmaBedeller();
        }

        private void GetAnlasmaBedeller()
        {
            DataTable dt = new DataTable();
            AnlasmaBedeller.GetObjects(dt, anlasma.pkID, true);
            gridControl1.DataSource = dt;
        }

        private void sbKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }




        private System.Drawing.Printing.PrintDocument printDocument1 = new System.Drawing.Printing.PrintDocument();
        Bitmap memoryImage;

        private void CaptureScreen()
        {
            Graphics myGraphics = this.CreateGraphics();
            Size s = new Size(this.Width + 30, this.Height + 30); ;
            memoryImage = new Bitmap(s.Width, s.Height, myGraphics);
            Graphics memoryGraphics = Graphics.FromImage(memoryImage);
            memoryGraphics.CopyFromScreen(this.Location.X + 4, this.Location.Y + 52, 0, 0, s);
        }

        private void printDocument1_PrintPage(System.Object sender,
           System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(memoryImage, 0, 0);
        }

        private void sbYazdir_Click(object sender, EventArgs e)
        {
            printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(printDocument1_PrintPage);
            CaptureScreen();
            printDocument1.Print();
        }

        private void sbExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel dosyaları (*.xls)|*.xls;|Bütün Dosyalar|*.*";
            if (sfd.ShowDialog() == DialogResult.OK)
                ExportToExcelAnlasma(sfd.FileName);
        }



        private void ExportToExcelAnlasma(string DosyaYeri)
        {
            DataTable dt = new DataTable();
            AnlasmaBedeller.GetObjects(dt, anlasma.pkID);



            System.IO.StreamWriter excelDoc = default(System.IO.StreamWriter);
            excelDoc = new System.IO.StreamWriter(DosyaYeri);

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
            ExcelXMLbasi.AppendLine(" <Alignment ss:Horizontal=\"Center\" ss:Vertical=\"Bottom\"/>");
            ExcelXMLbasi.AppendLine(" </Style>");
            ExcelXMLbasi.AppendLine(" <Style ss:ID=\"DateLiteral\">");
            ExcelXMLbasi.AppendLine(" <NumberFormat ss:Format=\"dd.mm.yyyy;@\"/>");
            ExcelXMLbasi.AppendLine(" </Style>");
            ExcelXMLbasi.AppendLine(" </Styles>");
            excelDoc.Write(ExcelXMLbasi.ToString());
            #endregion

            excelDoc.Write(" <Worksheet ss:Name=\"Anlasma\">");
            excelDoc.Write("<Table>" +
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"220.00\"/>" +
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"130.00\"/>" +
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"10.00\"/>" +
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"130.00\"/>");



            excelDoc.Write("<Row>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\"></Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">ANLAŞMA</Data></Cell>");
            excelDoc.Write("</Row>");

            excelDoc.Write("<Row>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\"></Data></Cell>");
            excelDoc.Write("</Row>");

            excelDoc.Write("<Row>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Müşteri Adı:</Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\">" + txtCari.Text + "</Data></Cell>");
            excelDoc.Write("</Row>");
            excelDoc.Write("<Row>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Şube Sayısı:</Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\">" + txtSubeSayisi.Text + "</Data></Cell>");
            excelDoc.Write("</Row>");
            excelDoc.Write("<Row>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">İl:</Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\">" + txtIl.Text + "</Data></Cell>");
            excelDoc.Write("</Row>");
            excelDoc.Write("<Row>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Bayi Adı:</Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\">" + txtBayi.Text + "</Data></Cell>");
            excelDoc.Write("</Row>");
            excelDoc.Write("<Row>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Anlaşma Başlangıç Tarihi:</Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\">" + dtpBaslangic.Value.ToShortDateString() + "</Data></Cell>");
            excelDoc.Write("</Row>");
            excelDoc.Write("<Row>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Anlaşma Bitiş Tarihi:</Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\">" + dtpBitis.Value.ToShortDateString() + "</Data></Cell>");
            excelDoc.Write("</Row>");
            excelDoc.Write("<Row>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Anlaşma Vadesi KGT:</Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\">" + txtVadeTAH.Text + "</Data></Cell>");
            excelDoc.Write("</Row>");
            excelDoc.Write("<Row>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Anlaşma Vadesi NF:</Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\">" + txtVadeYEG.Text + "</Data></Cell>");
            excelDoc.Write("</Row>");
            excelDoc.Write("<Row>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Listelenecek SKU KGT:</Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\">" + txtSKUTAH.Text + "</Data></Cell>");
            excelDoc.Write("</Row>");
            excelDoc.Write("<Row>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Listelenecek SKU NF:</Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\">" + txtSKUYEG.Text + "</Data></Cell>");
            excelDoc.Write("</Row>");



            #region Önceki sene
            int AnlasmaID = Anlasmalar.GetTarihAraligiAnlasmaID(anlasma.SMREF, anlasma.dtBaslangic.AddDays(-1));
            if (AnlasmaID > 0)
            {
                Anlasmalar anlasma1 = Anlasmalar.GetObject(AnlasmaID);
                DataTable dt1 = new DataTable();
                AnlasmaBedeller.GetObjects(dt1, anlasma1.pkID);

                excelDoc.Write("<Row>");
                excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\"></Data></Cell>");
                excelDoc.Write("</Row>");

                excelDoc.Write("<Row>");
                excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\"></Data></Cell>");
                excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">BİR ÖNCEKİ ANLAŞMA</Data></Cell>");
                excelDoc.Write("</Row>");

                excelDoc.Write("<Row>");
                excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Fatura Altı İskontosu:</Data></Cell>");
                excelDoc.Write("<Cell ss:StyleID=\"Integer\"><Data ss:Type=\"String\">" + anlasma1.flTAHIsk.ToString("N1") + "</Data></Cell>");
                excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\"></Data></Cell>");
                excelDoc.Write("<Cell ss:StyleID=\"Integer\"><Data ss:Type=\"String\">" + anlasma1.flYEGIsk.ToString("N1") + "</Data></Cell>");
                excelDoc.Write("</Row>");

                excelDoc.Write("<Row>");
                excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Ciro Primi Aylık:</Data></Cell>");
                excelDoc.Write("<Cell ss:StyleID=\"Integer\"><Data ss:Type=\"String\">" + anlasma1.flTAHCiro.ToString("N1") + "</Data></Cell>");
                excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\"></Data></Cell>");
                excelDoc.Write("<Cell ss:StyleID=\"Integer\"><Data ss:Type=\"String\">" + anlasma1.flYEGCiro.ToString("N1") + "</Data></Cell>");
                excelDoc.Write("</Row>");

                excelDoc.Write("<Row>");
                excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Ciro Primi 3 Aylık:</Data></Cell>");
                excelDoc.Write("<Cell ss:StyleID=\"Integer\"><Data ss:Type=\"String\">" + anlasma1.flTAHCiro3.ToString("N1") + "</Data></Cell>");
                excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\"></Data></Cell>");
                excelDoc.Write("<Cell ss:StyleID=\"Integer\"><Data ss:Type=\"String\">" + anlasma1.flYEGCiro3.ToString("N1") + "</Data></Cell>");
                excelDoc.Write("</Row>");

                excelDoc.Write("<Row>");
                excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Ciro Primi 6 Aylık:</Data></Cell>");
                excelDoc.Write("<Cell ss:StyleID=\"Integer\"><Data ss:Type=\"String\">" + anlasma1.flTAHCiro6.ToString("N1") + "</Data></Cell>");
                excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\"></Data></Cell>");
                excelDoc.Write("<Cell ss:StyleID=\"Integer\"><Data ss:Type=\"String\">" + anlasma1.flYEGCiro6.ToString("N1") + "</Data></Cell>");
                excelDoc.Write("</Row>");

                excelDoc.Write("<Row>");
                excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Ciro Primi 12 Aylık:</Data></Cell>");
                excelDoc.Write("<Cell ss:StyleID=\"Integer\"><Data ss:Type=\"String\">" + anlasma1.flTAHCiro12.ToString("N1") + "</Data></Cell>");
                excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\"></Data></Cell>");
                excelDoc.Write("<Cell ss:StyleID=\"Integer\"><Data ss:Type=\"String\">" + anlasma1.flYEGCiro12.ToString("N1") + "</Data></Cell>");
                excelDoc.Write("</Row>");

                excelDoc.Write("<Row>");
                excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Ciro Primi Fatura Altı:</Data></Cell>");
                excelDoc.Write("<Cell ss:StyleID=\"Integer\"><Data ss:Type=\"String\">" + anlasma1.flTAHCiroIsk.ToString("N1") + "</Data></Cell>");
                excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\"></Data></Cell>");
                excelDoc.Write("<Cell ss:StyleID=\"Integer\"><Data ss:Type=\"String\">" + anlasma1.flYEGCiroIsk.ToString("N1") + "</Data></Cell>");
                excelDoc.Write("</Row>");

                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    excelDoc.Write("<Row>");
                    excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">" + dt1.Rows[i]["strBedel"].ToString() + " Adet:</Data></Cell>");
                    excelDoc.Write("<Cell ss:StyleID=\"Integer\"><Data ss:Type=\"Number\">" + dt1.Rows[i]["intTAHAdet"].ToString() + "</Data></Cell>");
                    excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\"></Data></Cell>");
                    excelDoc.Write("<Cell ss:StyleID=\"Integer\"><Data ss:Type=\"Number\">" + dt1.Rows[i]["intYEGAdet"].ToString() + "</Data></Cell>");
                    excelDoc.Write("</Row>");

                    excelDoc.Write("<Row>");
                    excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">" + dt1.Rows[i]["strBedel"].ToString() + " Bedel:</Data></Cell>");
                    excelDoc.Write("<Cell ss:StyleID=\"Currency\"><Data ss:Type=\"Number\">" + Convert.ToDecimal(dt1.Rows[i]["mnTAHBedel"]).ToString("N2").Replace(".", "").Replace(",", ".") + "</Data></Cell>");
                    excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\"></Data></Cell>");
                    excelDoc.Write("<Cell ss:StyleID=\"Currency\"><Data ss:Type=\"Number\">" + Convert.ToDecimal(dt1.Rows[i]["mnYEGBedel"]).ToString("N2").Replace(".", "").Replace(",", ".") + "</Data></Cell>");
                    excelDoc.Write("</Row>");
                }

                excelDoc.Write("<Row>");
                excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Anlaşma Dışı Bedeller:</Data></Cell>");
                excelDoc.Write("<Cell ss:StyleID=\"Currency\"><Data ss:Type=\"Number\">" + anlasma1.mnTAHAnlasmaDisiBedeller.ToString("N2").Replace(".", "").Replace(",", ".") + "</Data></Cell>");
                excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\"></Data></Cell>");
                excelDoc.Write("<Cell ss:StyleID=\"Currency\"><Data ss:Type=\"Number\">" + anlasma1.mnYEGAnlasmaDisiBedeller.ToString("N2").Replace(".", "").Replace(",", ".") + "</Data></Cell>");
                excelDoc.Write("</Row>");

                excelDoc.Write("<Row>");
                excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Tüm Bedeller Toplamı:</Data></Cell>");
                excelDoc.Write("<Cell ss:StyleID=\"Currency\"><Data ss:Type=\"Number\">" + anlasma1.TAHTumBedellerToplami.ToString("N2").Replace(".", "").Replace(",", ".") + "</Data></Cell>");
                excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\"></Data></Cell>");
                excelDoc.Write("<Cell ss:StyleID=\"Currency\"><Data ss:Type=\"Number\">" + anlasma1.YEGTumBedellerToplami.ToString("N2").Replace(".", "").Replace(",", ".") + "</Data></Cell>");
                excelDoc.Write("</Row>");

                excelDoc.Write("<Row>");
                excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Toplam Ciro:</Data></Cell>");
                excelDoc.Write("<Cell ss:StyleID=\"Currency\"><Data ss:Type=\"Number\">" + anlasma1.mnTAHToplamCiro.ToString("N2").Replace(".", "").Replace(",", ".") + "</Data></Cell>");
                excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\"></Data></Cell>");
                excelDoc.Write("<Cell ss:StyleID=\"Currency\"><Data ss:Type=\"Number\">" + anlasma1.mnYEGToplamCiro.ToString("N2").Replace(".", "").Replace(",", ".") + "</Data></Cell>");
                excelDoc.Write("</Row>");

                excelDoc.Write("<Row>");
                excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Toplam Yıl Sonu Maliyet:</Data></Cell>");
                excelDoc.Write("<Cell ss:StyleID=\"Integer\"><Data ss:Type=\"String\">" + anlasma1.TAHYilSonuMaliyet.ToString("N1") + "</Data></Cell>");
                excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\"></Data></Cell>");
                excelDoc.Write("<Cell ss:StyleID=\"Integer\"><Data ss:Type=\"String\">" + anlasma1.YEGYilSonuMaliyet.ToString("N1") + "</Data></Cell>");
                excelDoc.Write("</Row>");

                excelDoc.Write("<Row>");
                excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Ciro Primi Dahil Net Maliyet:</Data></Cell>");
                excelDoc.Write("<Cell ss:StyleID=\"Integer\"><Data ss:Type=\"String\">" + anlasma1.TAHCiroPrimiDahilNetMaliyet.ToString("N1") + "</Data></Cell>");
                excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\"></Data></Cell>");
                excelDoc.Write("<Cell ss:StyleID=\"Integer\"><Data ss:Type=\"String\">" + anlasma1.YEGCiroPrimiDahilNetMaliyet.ToString("N1") + "</Data></Cell>");
                excelDoc.Write("</Row>");

                excelDoc.Write("<Row>");
                excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\"></Data></Cell>");
                excelDoc.Write("</Row>");

                excelDoc.Write("<Row>");
                excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Açıklama:</Data></Cell>");
                excelDoc.Write("<Cell><Data ss:Type=\"String\">" + anlasma1.strAciklama1 + "</Data></Cell>");
                excelDoc.Write("</Row>");
            }
            #endregion



            excelDoc.Write("<Row>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\"></Data></Cell>");
            excelDoc.Write("</Row>");

            excelDoc.Write("<Row>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\"></Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">ŞİMDİKİ ANLAŞMA</Data></Cell>");
            excelDoc.Write("</Row>");

            excelDoc.Write("<Row>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Fatura Altı İskontosu:</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"Integer\"><Data ss:Type=\"String\">" + anlasma.flTAHIsk.ToString("N1") + "</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\"></Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"Integer\"><Data ss:Type=\"String\">" + anlasma.flYEGIsk.ToString("N1") + "</Data></Cell>");
            excelDoc.Write("</Row>");

            excelDoc.Write("<Row>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Ciro Primi Aylık:</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"Integer\"><Data ss:Type=\"String\">" + anlasma.flTAHCiro.ToString("N1") + "</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\"></Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"Integer\"><Data ss:Type=\"String\">" + anlasma.flYEGCiro.ToString("N1") + "</Data></Cell>");
            excelDoc.Write("</Row>");

            excelDoc.Write("<Row>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Ciro Primi 3 Aylık:</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"Integer\"><Data ss:Type=\"String\">" + anlasma.flTAHCiro3.ToString("N1") + "</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\"></Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"Integer\"><Data ss:Type=\"String\">" + anlasma.flYEGCiro3.ToString("N1") + "</Data></Cell>");
            excelDoc.Write("</Row>");

            excelDoc.Write("<Row>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Ciro Primi 6 Aylık:</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"Integer\"><Data ss:Type=\"String\">" + anlasma.flTAHCiro6.ToString("N1") + "</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\"></Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"Integer\"><Data ss:Type=\"String\">" + anlasma.flYEGCiro6.ToString("N1") + "</Data></Cell>");
            excelDoc.Write("</Row>");

            excelDoc.Write("<Row>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Ciro Primi 12 Aylık:</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"Integer\"><Data ss:Type=\"String\">" + anlasma.flTAHCiro12.ToString("N1") + "</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\"></Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"Integer\"><Data ss:Type=\"String\">" + anlasma.flYEGCiro12.ToString("N1") + "</Data></Cell>");
            excelDoc.Write("</Row>");

            excelDoc.Write("<Row>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Ciro Primi Fatura Altı:</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"Integer\"><Data ss:Type=\"String\">" + anlasma.flTAHCiroIsk.ToString("N1") + "</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\"></Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"Integer\"><Data ss:Type=\"String\">" + anlasma.flYEGCiroIsk.ToString("N1") + "</Data></Cell>");
            excelDoc.Write("</Row>");

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                excelDoc.Write("<Row>");
                excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">" + dt.Rows[i]["strBedel"].ToString() + " Adet:</Data></Cell>");
                excelDoc.Write("<Cell ss:StyleID=\"Integer\"><Data ss:Type=\"Number\">" + dt.Rows[i]["intTAHAdet"].ToString() + "</Data></Cell>");
                excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\"></Data></Cell>");
                excelDoc.Write("<Cell ss:StyleID=\"Integer\"><Data ss:Type=\"Number\">" + dt.Rows[i]["intYEGAdet"].ToString() + "</Data></Cell>");
                excelDoc.Write("</Row>");

                excelDoc.Write("<Row>");
                excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">" + dt.Rows[i]["strBedel"].ToString() + " Bedel:</Data></Cell>");
                excelDoc.Write("<Cell ss:StyleID=\"Currency\"><Data ss:Type=\"Number\">" + Convert.ToDecimal(dt.Rows[i]["mnTAHBedel"]).ToString("N2").Replace(".", "").Replace(",", ".") + "</Data></Cell>");
                excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\"></Data></Cell>");
                excelDoc.Write("<Cell ss:StyleID=\"Currency\"><Data ss:Type=\"Number\">" + Convert.ToDecimal(dt.Rows[i]["mnYEGBedel"]).ToString("N2").Replace(".", "").Replace(",", ".") + "</Data></Cell>");
                excelDoc.Write("</Row>");
            }

            excelDoc.Write("<Row>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Anlaşma Dışı Bedeller:</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"Currency\"><Data ss:Type=\"Number\">" + anlasma.mnTAHAnlasmaDisiBedeller.ToString("N2").Replace(".", "").Replace(",", ".") + "</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\"></Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"Currency\"><Data ss:Type=\"Number\">" + anlasma.mnYEGAnlasmaDisiBedeller.ToString("N2").Replace(".", "").Replace(",", ".") + "</Data></Cell>");
            excelDoc.Write("</Row>");

            excelDoc.Write("<Row>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Tüm Bedeller Toplamı:</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"Currency\"><Data ss:Type=\"Number\">" + anlasma.TAHTumBedellerToplami.ToString("N2").Replace(".", "").Replace(",", ".") + "</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\"></Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"Currency\"><Data ss:Type=\"Number\">" + anlasma.YEGTumBedellerToplami.ToString("N2").Replace(".", "").Replace(",", ".") + "</Data></Cell>");
            excelDoc.Write("</Row>");

            excelDoc.Write("<Row>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Toplam Ciro:</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"Currency\"><Data ss:Type=\"Number\">" + anlasma.mnTAHToplamCiro.ToString("N2").Replace(".", "").Replace(",", ".") + "</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\"></Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"Currency\"><Data ss:Type=\"Number\">" + anlasma.mnYEGToplamCiro.ToString("N2").Replace(".", "").Replace(",", ".") + "</Data></Cell>");
            excelDoc.Write("</Row>");

            excelDoc.Write("<Row>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Toplam Yıl Sonu Maliyet:</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"Integer\"><Data ss:Type=\"String\">" + anlasma.TAHYilSonuMaliyet.ToString("N1") + "</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\"></Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"Integer\"><Data ss:Type=\"String\">" + anlasma.YEGYilSonuMaliyet.ToString("N1") + "</Data></Cell>");
            excelDoc.Write("</Row>");

            excelDoc.Write("<Row>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Ciro Primi Dahil Net Maliyet:</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"Integer\"><Data ss:Type=\"String\">" + anlasma.TAHCiroPrimiDahilNetMaliyet.ToString("N1") + "</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\"></Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"Integer\"><Data ss:Type=\"String\">" + anlasma.YEGCiroPrimiDahilNetMaliyet.ToString("N1") + "</Data></Cell>");
            excelDoc.Write("</Row>");

            excelDoc.Write("<Row>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\"></Data></Cell>");
            excelDoc.Write("</Row>");

            excelDoc.Write("<Row>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Açıklama:</Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\">" + anlasma.strAciklama1 + "</Data></Cell>");
            excelDoc.Write("</Row>");



            excelDoc.Write("</Table>");
            excelDoc.Write("</Worksheet>");
            excelDoc.Write("</Workbook>");
            excelDoc.Flush();
            excelDoc.Close();
        }
    }
}

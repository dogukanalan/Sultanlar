using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Sultanlar.Class;
using System.Drawing.Imaging;
using System.Net;

namespace Sultanlar.UI
{
    public partial class frmBrosur : Form
    {
        public frmBrosur()
        {
            InitializeComponent();
        }

        string koliadedi;
        string seciliRadioButton;

        private void frmBrosur_Load(object sender, EventArgs e)
        {
            seciliRadioButton = "1";
            koliadedi = string.Empty;
            cmbRenkler.SelectedIndex = 0;
            cmbBarkodTur.SelectedIndex = 0;

            if (frmAna.KAdi == "bı04")
                cbKaynaktakiDosyalariSilme.Visible = true;
        }

        private void btnDosyaYolu_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtDosyaYolu.Text = fbd.SelectedPath;

                //try
                //{
                //    string[] dosyalar = Directory.GetFiles("https://www.sultanlar.com.tr/sultanlarui/brosur/temp");
                //    for (int i = 0; i < dosyalar.Length; i++)
                //    {
                //        File.Delete(dosyalar[i]);
                //    }
                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show(ex.Message);
                //}

                //if (rb1.Checked)
                //    txtCiktiYolu.Text = fbd.SelectedPath + "\\Brosur-1";
                //else if (rb2.Checked)
                //    txtCiktiYolu.Text = fbd.SelectedPath + "\\Brosur-2";
                //else if (rb4.Checked)
                //    txtCiktiYolu.Text = fbd.SelectedPath + "\\Brosur-4";
                //else if (rb6.Checked)
                //    txtCiktiYolu.Text = fbd.SelectedPath + "\\Brosur-6";
                //else if (rb9.Checked)
                //    txtCiktiYolu.Text = fbd.SelectedPath + "\\Brosur-9";
                //else if (rb12.Checked)
                //    txtCiktiYolu.Text = fbd.SelectedPath + "\\Brosur-12";
                //else if (rb16.Checked)
                //    txtCiktiYolu.Text = fbd.SelectedPath + "\\Brosur-16";
                //else if (rb20.Checked)
                //    txtCiktiYolu.Text = fbd.SelectedPath + "\\Brosur-20";

                //txtCiktiYolu.Text = "https://www.sultanlar.com.tr/sultanlarui/brosur/temp";
                txtCiktiYolu.Text = "c:\\windows\\temp\\brosur";
                txtExcel.Text = txtDosyaYolu.Text + "\\bilgiler.xlsx";

                webBrowser1.Navigate("https://www.sultanlar.com.tr/sultanlarui/brosur/bos.htm");
                btnKaydet.Enabled = false;
            }
        }

        private void btnOlustur_Click(object sender, EventArgs e)
        {
            if (txtDosyaYolu.Text != string.Empty && txtCiktiYolu.Text != string.Empty)
            {
                TempiTemizle();
                Directory.CreateDirectory("c:\\windows\\temp\\brosur");

                koliadedi = txtKoliAdedi.Text.Replace(" ", "&nbsp;");
                ExceldenAl(txtExcel.Text);

                if (!cbArkaplansiz.Checked)
                {
                    if (rb1.Checked)
                        Birli();
                    else if (rb2.Checked)
                        Ikili();
                    else if (rb4.Checked)
                        Dortlu();
                    else if (rb6.Checked)
                        Altili();
                    else if (rb9.Checked)
                        Dokuzlu();
                    else if (rb12.Checked)
                        Onikili();
                    else if (rb16.Checked)
                        Onaltili();
                    else if (rb20.Checked)
                        Yirmili();
                }
                else
                {
                    if (rb1.Checked)
                        BirliNoBG();
                    else if (rb2.Checked)
                        IkiliNoBG();
                    else if (rb4.Checked)
                        DortluNoBG();
                    else if (rb6.Checked)
                        AltiliNoBG();
                    else if (rb9.Checked)
                        DokuzluNoBG();
                    else if (rb12.Checked)
                        OnikiliNoBG();
                    else if (rb16.Checked)
                        OnaltiliNoBG();
                    else if (rb20.Checked)
                        YirmiliNoBG();
                }

                btnKaydet.Enabled = true;

                //BrosuruResimYap();
            }
        }

        private void Yirmili()
        {
            try
            {
                Directory.CreateDirectory(txtCiktiYolu.Text);

                string bilgi1 = string.Empty, koliadedikismi1 = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />", koliadedi1 = string.Empty, urunaciklama1 = string.Empty,
                         bilgi2 = string.Empty, koliadedikismi2 = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />", koliadedi2 = string.Empty, urunaciklama2 = string.Empty,
                         bilgi3 = string.Empty, koliadedikismi3 = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />", koliadedi3 = string.Empty, urunaciklama3 = string.Empty,
                         bilgi4 = string.Empty, koliadedikismi4 = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />", koliadedi4 = string.Empty, urunaciklama4 = string.Empty,
                         bilgi5 = string.Empty, koliadedikismi5 = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />", koliadedi5 = string.Empty, urunaciklama5 = string.Empty,
                         bilgi6 = string.Empty, koliadedikismi6 = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />", koliadedi6 = string.Empty, urunaciklama6 = string.Empty,
                         bilgi7 = string.Empty, koliadedikismi7 = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />", koliadedi7 = string.Empty, urunaciklama7 = string.Empty,
                         bilgi8 = string.Empty, koliadedikismi8 = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />", koliadedi8 = string.Empty, urunaciklama8 = string.Empty,
                         bilgi9 = string.Empty, koliadedikismi9 = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />", koliadedi9 = string.Empty, urunaciklama9 = string.Empty,
                         bilgi10 = string.Empty, koliadedikismi10 = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />", koliadedi10 = string.Empty, urunaciklama10 = string.Empty,
                         bilgi11 = string.Empty, koliadedikismi11 = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />", koliadedi11 = string.Empty, urunaciklama11 = string.Empty,
                         bilgi12 = string.Empty, koliadedikismi12 = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />", koliadedi12 = string.Empty, urunaciklama12 = string.Empty,
                         bilgi13 = string.Empty, koliadedikismi13 = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />", koliadedi13 = string.Empty, urunaciklama13 = string.Empty,
                         bilgi14 = string.Empty, koliadedikismi14 = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />", koliadedi14 = string.Empty, urunaciklama14 = string.Empty,
                         bilgi15 = string.Empty, koliadedikismi15 = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />", koliadedi15 = string.Empty, urunaciklama15 = string.Empty,
                         bilgi16 = string.Empty, koliadedikismi16 = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />", koliadedi16 = string.Empty, urunaciklama16 = string.Empty,
                         bilgi17 = string.Empty, koliadedikismi17 = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />", koliadedi17 = string.Empty, urunaciklama17 = string.Empty,
                         bilgi18 = string.Empty, koliadedikismi18 = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />", koliadedi18 = string.Empty, urunaciklama18 = string.Empty,
                         bilgi19 = string.Empty, koliadedikismi19 = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />", koliadedi19 = string.Empty, urunaciklama19 = string.Empty,
                         bilgi20 = string.Empty, koliadedikismi20 = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />", koliadedi20 = string.Empty, urunaciklama20 = string.Empty;

                // tablo gerekli resimleri
                File.Copy("https://www.sultanlar.com.tr/sultanlarui/brosur/1_sultanlar_logo.png", txtCiktiYolu.Text + "\\1_sultanlar_logo.png", true);
                File.Copy("https://www.sultanlar.com.tr/sultanlarui/brosur/header-bg.png", txtCiktiYolu.Text + "\\header-bg.png", true);
                File.Copy("https://www.sultanlar.com.tr/sultanlarui/brosur/footer-bg.png", txtCiktiYolu.Text + "\\footer-bg.png", true);

                // şablon logosu
                if (File.Exists(txtDosyaYolu.Text + "\\logo.png"))
                {
                    File.Copy(txtDosyaYolu.Text + "\\logo.png", txtCiktiYolu.Text + "\\logo.png", true);
                }
                else
                {
                    File.Copy("https://www.sultanlar.com.tr/sultanlarui/brosur/1_sultanlar_logo.png", txtCiktiYolu.Text + "\\logo.png", true);
                }

                // urun resimleri ve barkodlari
                for (int i = 1; i <= 20; i++)
                {
                    //resim
                    if (File.Exists(txtDosyaYolu.Text + "\\" + i.ToString() + ".png") || File.Exists(txtDosyaYolu.Text + "\\" + i.ToString() + ".jpg"))
                    {
                        Image img = File.Exists(txtDosyaYolu.Text + "\\" + i.ToString() + ".png") ? Image.FromFile(txtDosyaYolu.Text + "\\" + i.ToString() + ".png") : Image.FromFile(txtDosyaYolu.Text + "\\" + i.ToString() + ".jpg");
                        Image kucukimg;
                        if (img.Height > img.Width)
                        {
                            double aspectRatio = Convert.ToDouble(img.Height) / img.Width;
                            double yukseklik = 115;
                            double genislik = yukseklik / aspectRatio;
                            kucukimg = Resim.ResimKucult(img, Convert.ToInt32(genislik));
                        }
                        else
                        {
                            kucukimg = Resim.ResimKucult(img, 115);
                        }
                        kucukimg.Save(txtCiktiYolu.Text + "\\" + i.ToString() + ".png");
                    }
                    else
                    {
                        File.Copy("https://www.sultanlar.com.tr/sultanlarui/brosur/bos.png", txtCiktiYolu.Text + "\\" + i.ToString() + ".png", true);
                    }

                    // barkod
                    if (File.Exists(txtDosyaYolu.Text + "\\" + i.ToString() + "barkod.png"))
                    {
                        File.Copy(txtDosyaYolu.Text + "\\" + i.ToString() + "barkod.png", txtCiktiYolu.Text + "\\" + i.ToString() + "barkod.png", true);
                    }
                    else
                    {
                        File.Copy("https://www.sultanlar.com.tr/sultanlarui/brosur/bos.png", txtCiktiYolu.Text + "\\" + i.ToString() + "barkod.png", true);
                    }
                }

                // urun aciklamalari
                if (File.Exists(txtDosyaYolu.Text + "\\1.txt"))
                {
                    bilgi1 = File.ReadAllText(txtDosyaYolu.Text + "\\1.txt", Encoding.GetEncoding("iso-8859-9")).ToUpper();
                    koliadedikismi1 = koliadedi;
                    koliadedi1 = bilgi1.Substring(0, bilgi1.IndexOf("\r\n"));
                    urunaciklama1 = bilgi1.Substring(bilgi1.IndexOf("\r\n") + 1);
                }
                if (File.Exists(txtDosyaYolu.Text + "\\2.txt"))
                {
                    bilgi2 = File.ReadAllText(txtDosyaYolu.Text + "\\2.txt", Encoding.GetEncoding("iso-8859-9")).ToUpper();
                    koliadedikismi2 = koliadedi;
                    koliadedi2 = bilgi2.Substring(0, bilgi2.IndexOf("\r\n"));
                    urunaciklama2 = bilgi2.Substring(bilgi2.IndexOf("\r\n") + 1);
                }
                if (File.Exists(txtDosyaYolu.Text + "\\3.txt"))
                {
                    bilgi3 = File.ReadAllText(txtDosyaYolu.Text + "\\3.txt", Encoding.GetEncoding("iso-8859-9")).ToUpper();
                    koliadedikismi3 = koliadedi;
                    koliadedi3 = bilgi3.Substring(0, bilgi3.IndexOf("\r\n"));
                    urunaciklama3 = bilgi3.Substring(bilgi3.IndexOf("\r\n") + 1);
                }
                if (File.Exists(txtDosyaYolu.Text + "\\4.txt"))
                {
                    bilgi4 = File.ReadAllText(txtDosyaYolu.Text + "\\4.txt", Encoding.GetEncoding("iso-8859-9")).ToUpper();
                    koliadedikismi4 = koliadedi;
                    koliadedi4 = bilgi4.Substring(0, bilgi4.IndexOf("\r\n"));
                    urunaciklama4 = bilgi4.Substring(bilgi4.IndexOf("\r\n") + 1);
                }
                if (File.Exists(txtDosyaYolu.Text + "\\5.txt"))
                {
                    bilgi5 = File.ReadAllText(txtDosyaYolu.Text + "\\5.txt", Encoding.GetEncoding("iso-8859-9")).ToUpper();
                    koliadedikismi5 = koliadedi;
                    koliadedi5 = bilgi5.Substring(0, bilgi5.IndexOf("\r\n"));
                    urunaciklama5 = bilgi5.Substring(bilgi5.IndexOf("\r\n") + 1);
                }
                if (File.Exists(txtDosyaYolu.Text + "\\6.txt"))
                {
                    bilgi6 = File.ReadAllText(txtDosyaYolu.Text + "\\6.txt", Encoding.GetEncoding("iso-8859-9")).ToUpper();
                    koliadedikismi6 = koliadedi;
                    koliadedi6 = bilgi6.Substring(0, bilgi6.IndexOf("\r\n"));
                    urunaciklama6 = bilgi6.Substring(bilgi6.IndexOf("\r\n") + 1);
                }
                if (File.Exists(txtDosyaYolu.Text + "\\7.txt"))
                {
                    bilgi7 = File.ReadAllText(txtDosyaYolu.Text + "\\7.txt", Encoding.GetEncoding("iso-8859-9")).ToUpper();
                    koliadedikismi7 = koliadedi;
                    koliadedi7 = bilgi7.Substring(0, bilgi7.IndexOf("\r\n"));
                    urunaciklama7 = bilgi7.Substring(bilgi7.IndexOf("\r\n") + 1);
                }
                if (File.Exists(txtDosyaYolu.Text + "\\8.txt"))
                {
                    bilgi8 = File.ReadAllText(txtDosyaYolu.Text + "\\8.txt", Encoding.GetEncoding("iso-8859-9")).ToUpper();
                    koliadedikismi8 = koliadedi;
                    koliadedi8 = bilgi8.Substring(0, bilgi8.IndexOf("\r\n"));
                    urunaciklama8 = bilgi8.Substring(bilgi8.IndexOf("\r\n") + 1);
                }
                if (File.Exists(txtDosyaYolu.Text + "\\9.txt"))
                {
                    bilgi9 = File.ReadAllText(txtDosyaYolu.Text + "\\9.txt", Encoding.GetEncoding("iso-8859-9")).ToUpper();
                    koliadedikismi9 = koliadedi;
                    koliadedi9 = bilgi9.Substring(0, bilgi9.IndexOf("\r\n"));
                    urunaciklama9 = bilgi9.Substring(bilgi9.IndexOf("\r\n") + 1);
                }
                if (File.Exists(txtDosyaYolu.Text + "\\10.txt"))
                {
                    bilgi10 = File.ReadAllText(txtDosyaYolu.Text + "\\10.txt", Encoding.GetEncoding("iso-8859-9")).ToUpper();
                    koliadedikismi10 = koliadedi;
                    koliadedi10 = bilgi10.Substring(0, bilgi10.IndexOf("\r\n"));
                    urunaciklama10 = bilgi10.Substring(bilgi10.IndexOf("\r\n") + 1);
                }
                if (File.Exists(txtDosyaYolu.Text + "\\11.txt"))
                {
                    bilgi11 = File.ReadAllText(txtDosyaYolu.Text + "\\11.txt", Encoding.GetEncoding("iso-8859-9")).ToUpper();
                    koliadedikismi11 = koliadedi;
                    koliadedi11 = bilgi11.Substring(0, bilgi11.IndexOf("\r\n"));
                    urunaciklama11 = bilgi11.Substring(bilgi11.IndexOf("\r\n") + 1);
                }
                if (File.Exists(txtDosyaYolu.Text + "\\12.txt"))
                {
                    bilgi12 = File.ReadAllText(txtDosyaYolu.Text + "\\12.txt", Encoding.GetEncoding("iso-8859-9")).ToUpper();
                    koliadedikismi12 = koliadedi;
                    koliadedi12 = bilgi12.Substring(0, bilgi12.IndexOf("\r\n"));
                    urunaciklama12 = bilgi12.Substring(bilgi12.IndexOf("\r\n") + 1);
                }
                if (File.Exists(txtDosyaYolu.Text + "\\13.txt"))
                {
                    bilgi13 = File.ReadAllText(txtDosyaYolu.Text + "\\13.txt", Encoding.GetEncoding("iso-8859-9")).ToUpper();
                    koliadedikismi13 = koliadedi;
                    koliadedi13 = bilgi13.Substring(0, bilgi13.IndexOf("\r\n"));
                    urunaciklama13 = bilgi13.Substring(bilgi13.IndexOf("\r\n") + 1);
                }
                if (File.Exists(txtDosyaYolu.Text + "\\14.txt"))
                {
                    bilgi14 = File.ReadAllText(txtDosyaYolu.Text + "\\14.txt", Encoding.GetEncoding("iso-8859-9")).ToUpper();
                    koliadedikismi14 = koliadedi;
                    koliadedi14 = bilgi14.Substring(0, bilgi14.IndexOf("\r\n"));
                    urunaciklama14 = bilgi14.Substring(bilgi14.IndexOf("\r\n") + 1);
                }
                if (File.Exists(txtDosyaYolu.Text + "\\15.txt"))
                {
                    bilgi15 = File.ReadAllText(txtDosyaYolu.Text + "\\15.txt", Encoding.GetEncoding("iso-8859-9")).ToUpper();
                    koliadedikismi15 = koliadedi;
                    koliadedi15 = bilgi15.Substring(0, bilgi15.IndexOf("\r\n"));
                    urunaciklama15 = bilgi15.Substring(bilgi15.IndexOf("\r\n") + 1);
                }
                if (File.Exists(txtDosyaYolu.Text + "\\16.txt"))
                {
                    bilgi16 = File.ReadAllText(txtDosyaYolu.Text + "\\16.txt", Encoding.GetEncoding("iso-8859-9")).ToUpper();
                    koliadedikismi16 = koliadedi;
                    koliadedi16 = bilgi16.Substring(0, bilgi16.IndexOf("\r\n"));
                    urunaciklama16 = bilgi16.Substring(bilgi16.IndexOf("\r\n") + 1);
                }
                if (File.Exists(txtDosyaYolu.Text + "\\17.txt"))
                {
                    bilgi17 = File.ReadAllText(txtDosyaYolu.Text + "\\17.txt", Encoding.GetEncoding("iso-8859-9")).ToUpper();
                    koliadedikismi17 = koliadedi;
                    koliadedi17 = bilgi17.Substring(0, bilgi17.IndexOf("\r\n"));
                    urunaciklama17 = bilgi17.Substring(bilgi17.IndexOf("\r\n") + 1);
                }
                if (File.Exists(txtDosyaYolu.Text + "\\18.txt"))
                {
                    bilgi18 = File.ReadAllText(txtDosyaYolu.Text + "\\18.txt", Encoding.GetEncoding("iso-8859-9")).ToUpper();
                    koliadedikismi18 = koliadedi;
                    koliadedi18 = bilgi18.Substring(0, bilgi18.IndexOf("\r\n"));
                    urunaciklama18 = bilgi18.Substring(bilgi18.IndexOf("\r\n") + 1);
                }
                if (File.Exists(txtDosyaYolu.Text + "\\19.txt"))
                {
                    bilgi19 = File.ReadAllText(txtDosyaYolu.Text + "\\19.txt", Encoding.GetEncoding("iso-8859-9")).ToUpper();
                    koliadedikismi19 = koliadedi;
                    koliadedi19 = bilgi19.Substring(0, bilgi19.IndexOf("\r\n"));
                    urunaciklama19 = bilgi19.Substring(bilgi19.IndexOf("\r\n") + 1);
                }
                if (File.Exists(txtDosyaYolu.Text + "\\20.txt"))
                {
                    bilgi20 = File.ReadAllText(txtDosyaYolu.Text + "\\20.txt", Encoding.GetEncoding("iso-8859-9")).ToUpper();
                    koliadedikismi20 = koliadedi;
                    koliadedi20 = bilgi20.Substring(0, bilgi20.IndexOf("\r\n"));
                    urunaciklama20 = bilgi20.Substring(bilgi20.IndexOf("\r\n") + 1);
                }

                // brosuru olustur
                string brosur = "<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\"><html xmlns=\"http://www.w3.org/1999/xhtml\" ><head>    <title>Untitled Page</title>    <style type=\"text/css\">        .style1 {            width: 730px;            height: 929px;            font-family:Tahoma;             font-size: 7px;            font-weight: normal;        }        .style2        {            width: 138px;            height: 43px;        }        .style3        { background-color: " + txtRenk.Text + "; } .style4        {            width: 100px;            height: 37px;        }          </style></head><body style=\"margin: 0px 0px 0px 10px\">    <table cellpadding=\"0\" cellspacing=\"0\" class=\"style1\"         style=\"border: 1px solid #ffcea0\">        <tr>            <td style=\"background-image: url(header-bg.png); height: 60px; padding: 10px 10px 0px 100px\">            " +
                        "<img src=\"logo.png\"                     style=\"padding: 10px 3px 3px 10px; height: 48px;\" /></td>        </tr>        <tr>            <td>                <table cellpadding=\"0\" cellspacing=\"0\" class=\"style1\">                    <tr>                        <td align=\"center\">                            <table cellpadding=\"0\" cellspacing=\"0\"                                                                                                 style=\"margin: 5px; padding: 0px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: 3px; border-bottom-width: 3px; border-left-width: 3px; border-right-color: #ffcea0; border-bottom-color: #ffcea0; border-left-color: #ffcea0;\">                                <tr>                                    <td colspan=\"2\"                                         style=\"padding: 5px; text-align: center; height: 136px; width: 136px;\" class=\"style3\">                                        " +
                        "<img alt=\"\" src=\"1.png\" /></td>                                </tr>                                <tr>                                    <td style=\"padding: 5px; background-color: #663300; text-align: center; color: #FFFFCC;\">                                        " + koliadedikismi1 + "<br />                                        " +
                        koliadedi1 + "</td>                                    <td style=\"padding: 5px; background-color: #ffcea0; width: 94px; text-align: center;\">                                        " +
                        urunaciklama1 + "</td>                                </tr>                                <tr>                                    <td colspan=\"2\" style=\"padding: 5px; text-align: center;\">                                        " +
                        "<img class=\"style4\" src=\"1barkod.png\" /></td>                                </tr>                            </table>                        </td>                        " +
                        "<td align=\"center\">                            <table cellpadding=\"0\" cellspacing=\"0\"                                                                                                                                 style=\"margin: 5px; padding: 0px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: 3px; border-bottom-width: 3px; border-left-width: 3px; border-right-color: #ffcea0; border-bottom-color: #ffcea0; border-left-color: #ffcea0;\">                                <tr>                                    <td colspan=\"2\"                                         style=\"padding: 5px; text-align: center; height: 136px; width: 136px;\" class=\"style3\">                                        " +
                        "<img alt=\"\" src=\"2.png\" /></td>                                </tr>                                <tr>                                    <td style=\"padding: 5px; background-color: #663300; text-align: center; color: #FFFFCC;\">                                        " + koliadedikismi2 + "<br />                                        " +
                        koliadedi2 + "</td>                                    <td style=\"padding: 5px; background-color: #ffcea0; width: 94px; text-align: center;\">                                        " +
                        urunaciklama2 + "</td>                                </tr>                                <tr>                                    <td colspan=\"2\" style=\"padding: 5px; text-align: center;\">                                        " +
                        "<img class=\"style4\" src=\"2barkod.png\" /></td>                                </tr>                            </table>                        </td>                        " +
                        "<td align=\"center\">                            <table cellpadding=\"0\" cellspacing=\"0\"                                                                                                                                 style=\"margin: 5px; padding: 0px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: 3px; border-bottom-width: 3px; border-left-width: 3px; border-right-color: #ffcea0; border-bottom-color: #ffcea0; border-left-color: #ffcea0;\">                                <tr>                                    <td colspan=\"2\"                                         style=\"padding: 5px; text-align: center; height: 136px; width: 136px;\" class=\"style3\">                                        " +
                        "<img alt=\"\" src=\"3.png\" /></td>                                </tr>                                <tr>                                    <td style=\"padding: 5px; background-color: #663300; text-align: center; color: #FFFFCC;\">                                        " + koliadedikismi3 + "<br />                                        " +
                        koliadedi3 + "</td>                                    <td style=\"padding: 5px; background-color: #ffcea0; width: 94px; text-align: center;\">                                        " +
                        urunaciklama3 + "</td>                                </tr>                                <tr>                                    <td colspan=\"2\" style=\"padding: 5px; text-align: center;\">                                        " +
                        "<img class=\"style4\" src=\"3barkod.png\" /></td>                                </tr>                            </table>                        </td>                        " +
                        "<td align=\"center\">                            <table cellpadding=\"0\" cellspacing=\"0\"                                                                                                                                 style=\"margin: 5px; padding: 0px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: 3px; border-bottom-width: 3px; border-left-width: 3px; border-right-color: #ffcea0; border-bottom-color: #ffcea0; border-left-color: #ffcea0;\">                                <tr>                                    <td colspan=\"2\"                                         style=\"padding: 5px; text-align: center; height: 136px; width: 136px;\" class=\"style3\">                                        " +
                        "<img alt=\"\" src=\"4.png\" /></td>                                </tr>                                <tr>                                    <td style=\"padding: 5px; background-color: #663300; text-align: center; color: #FFFFCC;\">                                        " + koliadedikismi4 + "<br />                                        " +
                        koliadedi4 + "</td>                                    <td style=\"padding: 5px; background-color: #ffcea0; width: 94px; text-align: center;\">                                        " +
                        urunaciklama4 + "</td>                                </tr>                                <tr>                                    <td colspan=\"2\" style=\"padding: 5px; text-align: center;\">                                        " +
                        "<img class=\"style4\" src=\"4barkod.png\" /></td>                                </tr>                            </table>                        </td>                        " +
                        "<td align=\"center\">                            <table cellpadding=\"0\" cellspacing=\"0\"                                                                                                                                 style=\"margin: 5px; padding: 0px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: 3px; border-bottom-width: 3px; border-left-width: 3px; border-right-color: #ffcea0; border-bottom-color: #ffcea0; border-left-color: #ffcea0;\">                                <tr>                                    <td colspan=\"2\"                                         style=\"padding: 5px; text-align: center; height: 136px; width: 136px;\" class=\"style3\">                                        " +
                        "<img alt=\"\" src=\"5.png\" /></td>                                </tr>                                <tr>                                    <td style=\"padding: 5px; background-color: #663300; text-align: center; color: #FFFFCC;\">                                        " + koliadedikismi5 + "<br />                                        " +
                        koliadedi5 + "</td>                                    <td style=\"padding: 5px; background-color: #ffcea0; width: 94px; text-align: center;\">                                        " +
                        urunaciklama5 + "</td>                                </tr>                                <tr>                                    <td colspan=\"2\" style=\"padding: 5px; text-align: center;\">                                        " +
                        "<img class=\"style4\" src=\"5barkod.png\" /></td>                                </tr>                            </table>                        </td>                    </tr>                    " +
                        "<tr>                        <td align=\"center\">                            <table cellpadding=\"0\" cellspacing=\"0\"                                                                                                                                 style=\"margin: 5px; padding: 0px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: 3px; border-bottom-width: 3px; border-left-width: 3px; border-right-color: #ffcea0; border-bottom-color: #ffcea0; border-left-color: #ffcea0;\">                                <tr>                                    <td colspan=\"2\"                                         style=\"padding: 5px; text-align: center; height: 136px; width: 136px;\" class=\"style3\">                                        " +
                        "<img alt=\"\" src=\"6.png\" /></td>                                </tr>                                <tr>                                    <td style=\"padding: 5px; background-color: #663300; text-align: center; color: #FFFFCC;\">                                        " + koliadedikismi6 + "<br />                                        " +
                        koliadedi6 + "</td>                                    <td style=\"padding: 5px; background-color: #ffcea0; width: 94px; text-align: center;\">                                        " +
                        urunaciklama6 + "</td>                                </tr>                                <tr>                                    <td colspan=\"2\" style=\"padding: 5px; text-align: center;\">                                        " +
                        "<img class=\"style4\" src=\"6barkod.png\" /></td>                                </tr>                            </table>                        </td>                        " +
                        "<td align=\"center\">                            <table cellpadding=\"0\" cellspacing=\"0\"                                                                                                                                 style=\"margin: 5px; padding: 0px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: 3px; border-bottom-width: 3px; border-left-width: 3px; border-right-color: #ffcea0; border-bottom-color: #ffcea0; border-left-color: #ffcea0;\">                                <tr>                                    <td colspan=\"2\"                                         style=\"padding: 5px; text-align: center; height: 136px; width: 136px;\" class=\"style3\">                                        " +
                        "<img alt=\"\" src=\"7.png\" /></td>                                </tr>                                <tr>                                    <td style=\"padding: 5px; background-color: #663300; text-align: center; color: #FFFFCC;\">                                        " + koliadedikismi7 + "<br />                                        " +
                        koliadedi7 + "</td>                                    <td style=\"padding: 5px; background-color: #ffcea0; width: 94px; text-align: center;\">                                        " +
                        urunaciklama7 + "</td>                                </tr>                                <tr>                                    <td colspan=\"2\" style=\"padding: 5px; text-align: center;\">                                        " +
                        "<img class=\"style4\" src=\"7barkod.png\" /></td>                                </tr>                            </table>                        </td>                        " +
                        "<td align=\"center\">                            <table cellpadding=\"0\" cellspacing=\"0\"                                                                                                                                 style=\"margin: 5px; padding: 0px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: 3px; border-bottom-width: 3px; border-left-width: 3px; border-right-color: #ffcea0; border-bottom-color: #ffcea0; border-left-color: #ffcea0;\">                                <tr>                                    <td colspan=\"2\"                                         style=\"padding: 5px; text-align: center; height: 136px; width: 136px;\" class=\"style3\">                                        " +
                        "<img alt=\"\" src=\"8.png\" /></td>                                </tr>                                <tr>                                    <td style=\"padding: 5px; background-color: #663300; text-align: center; color: #FFFFCC;\">                                        " + koliadedikismi8 + "<br />                                        " +
                        koliadedi8 + "</td>                                    <td style=\"padding: 5px; background-color: #ffcea0; width: 94px; text-align: center;\">                                        " +
                        urunaciklama8 + "</td>                                </tr>                                <tr>                                    <td colspan=\"2\" style=\"padding: 5px; text-align: center;\">                                        " +
                        "<img class=\"style4\" src=\"8barkod.png\" /></td>                                </tr>                            </table>                        </td>                        " +
                        "<td align=\"center\">                            <table cellpadding=\"0\" cellspacing=\"0\"                                                                                                                                 style=\"margin: 5px; padding: 0px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: 3px; border-bottom-width: 3px; border-left-width: 3px; border-right-color: #ffcea0; border-bottom-color: #ffcea0; border-left-color: #ffcea0;\">                                <tr>                                    <td colspan=\"2\"                                         style=\"padding: 5px; text-align: center; height: 136px; width: 136px;\" class=\"style3\">                                        " +
                        "<img alt=\"\" src=\"9.png\" /></td>                                </tr>                                <tr>                                    <td style=\"padding: 5px; background-color: #663300; text-align: center; color: #FFFFCC;\">                                        " + koliadedikismi9 + "<br />                                        " +
                        koliadedi9 + "</td>                                    <td style=\"padding: 5px; background-color: #ffcea0; width: 94px; text-align: center;\">                                        " +
                        urunaciklama9 + "</td>                                </tr>                                <tr>                                    <td colspan=\"2\" style=\"padding: 5px; text-align: center;\">                                        " +
                        "<img class=\"style4\" src=\"9barkod.png\" /></td>                                </tr>                            </table>                        </td>                        " +
                        "<td align=\"center\">                            <table cellpadding=\"0\" cellspacing=\"0\"                                                                                                                                 style=\"margin: 5px; padding: 0px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: 3px; border-bottom-width: 3px; border-left-width: 3px; border-right-color: #ffcea0; border-bottom-color: #ffcea0; border-left-color: #ffcea0;\">                                <tr>                                    <td colspan=\"2\"                                         style=\"padding: 5px; text-align: center; height: 136px; width: 136px;\" class=\"style3\">                                        " +
                        "<img alt=\"\" src=\"10.png\" /></td>                                </tr>                                <tr>                                    <td style=\"padding: 5px; background-color: #663300; text-align: center; color: #FFFFCC;\">                                        " + koliadedikismi10 + "<br />                                        " +
                        koliadedi10 + "</td>                                    <td style=\"padding: 5px; background-color: #ffcea0; width: 94px; text-align: center;\">                                        " +
                        urunaciklama10 + "</td>                                </tr>                                <tr>                                    <td colspan=\"2\" style=\"padding: 5px; text-align: center;\">                                        " +
                        "<img class=\"style4\" src=\"10barkod.png\" /></td>                                </tr>                            </table>                        </td>                    </tr>                    " +
                        "<tr>                        <td align=\"center\">                            <table cellpadding=\"0\" cellspacing=\"0\"                                                                                                                                 style=\"margin: 5px; padding: 0px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: 3px; border-bottom-width: 3px; border-left-width: 3px; border-right-color: #ffcea0; border-bottom-color: #ffcea0; border-left-color: #ffcea0;\">                                <tr>                                    <td colspan=\"2\"                                         style=\"padding: 5px; text-align: center; height: 136px; width: 136px;\" class=\"style3\">                                        " +
                        "<img alt=\"\" src=\"11.png\" /></td>                                </tr>                                <tr>                                    <td style=\"padding: 5px; background-color: #663300; text-align: center; color: #FFFFCC;\">                                        " + koliadedikismi11 + "<br />                                        " +
                        koliadedi11 + "</td>                                    <td style=\"padding: 5px; background-color: #ffcea0; width: 94px; text-align: center;\">                                        " +
                        urunaciklama11 + "</td>                                </tr>                                <tr>                                    <td colspan=\"2\" style=\"padding: 5px; text-align: center;\">                                        " +
                        "<img class=\"style4\" src=\"11barkod.png\" /></td>                                </tr>                            </table>                        </td>                        " +
                        "<td align=\"center\">                            <table cellpadding=\"0\" cellspacing=\"0\"                                                                                                                                 style=\"margin: 5px; padding: 0px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: 3px; border-bottom-width: 3px; border-left-width: 3px; border-right-color: #ffcea0; border-bottom-color: #ffcea0; border-left-color: #ffcea0;\">                                <tr>                                    <td colspan=\"2\"                                         style=\"padding: 5px; text-align: center; height: 136px; width: 136px;\" class=\"style3\">                                        " +
                        "<img alt=\"\" src=\"12.png\" /></td>                                </tr>                                <tr>                                    <td style=\"padding: 5px; background-color: #663300; text-align: center; color: #FFFFCC;\">                                        " + koliadedikismi12 + "<br />                                        " +
                        koliadedi12 + "</td>                                    <td style=\"padding: 5px; background-color: #ffcea0; width: 94px; text-align: center;\">                                        " +
                        urunaciklama12 + "</td>                                </tr>                                <tr>                                    <td colspan=\"2\" style=\"padding: 5px; text-align: center;\">                                        " +
                        "<img class=\"style4\" src=\"12barkod.png\" /></td>                                </tr>                            </table>                        </td>                        " +
                        "<td align=\"center\">                            <table cellpadding=\"0\" cellspacing=\"0\"                                                                                                                                 style=\"margin: 5px; padding: 0px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: 3px; border-bottom-width: 3px; border-left-width: 3px; border-right-color: #ffcea0; border-bottom-color: #ffcea0; border-left-color: #ffcea0;\">                                <tr>                                    <td colspan=\"2\"                                         style=\"padding: 5px; text-align: center; height: 136px; width: 136px;\" class=\"style3\">                                        " +
                        "<img alt=\"\" src=\"13.png\" /></td>                                </tr>                                <tr>                                    <td style=\"padding: 5px; background-color: #663300; text-align: center; color: #FFFFCC;\">                                        " + koliadedikismi13 + "<br />                                        " +
                        koliadedi13 + "</td>                                    <td style=\"padding: 5px; background-color: #ffcea0; width: 94px; text-align: center;\">                                        " +
                        urunaciklama13 + "</td>                                </tr>                                <tr>                                    <td colspan=\"2\" style=\"padding: 5px; text-align: center;\">                                        " +
                        "<img class=\"style4\" src=\"13barkod.png\" /></td>                                </tr>                            </table>                        </td>                        " +
                        "<td align=\"center\">                            <table cellpadding=\"0\" cellspacing=\"0\"                                                                                                                                 style=\"margin: 5px; padding: 0px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: 3px; border-bottom-width: 3px; border-left-width: 3px; border-right-color: #ffcea0; border-bottom-color: #ffcea0; border-left-color: #ffcea0;\">                                <tr>                                    <td colspan=\"2\"                                         style=\"padding: 5px; text-align: center; height: 136px; width: 136px;\" class=\"style3\">                                        " +
                        "<img alt=\"\" src=\"14.png\" /></td>                                </tr>                                <tr>                                    <td style=\"padding: 5px; background-color: #663300; text-align: center; color: #FFFFCC;\">                                        " + koliadedikismi14 + "<br />                                        " +
                        koliadedi14 + "</td>                                    <td style=\"padding: 5px; background-color: #ffcea0; width: 94px; text-align: center;\">                                        " +
                        urunaciklama14 + "</td>                                </tr>                                <tr>                                    <td colspan=\"2\" style=\"padding: 5px; text-align: center;\">                                        " +
                        "<img class=\"style4\" src=\"14barkod.png\" /></td>                                </tr>                            </table>                        </td>                        " +
                        "<td align=\"center\">                            <table cellpadding=\"0\" cellspacing=\"0\"                                                                                                                                 style=\"margin: 5px; padding: 0px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: 3px; border-bottom-width: 3px; border-left-width: 3px; border-right-color: #ffcea0; border-bottom-color: #ffcea0; border-left-color: #ffcea0;\">                                <tr>                                    <td colspan=\"2\"                                         style=\"padding: 5px; text-align: center; height: 136px; width: 136px;\" class=\"style3\">                                        " +
                        "<img alt=\"\" src=\"15.png\" /></td>                                </tr>                                <tr>                                    <td style=\"padding: 5px; background-color: #663300; text-align: center; color: #FFFFCC;\">                                        " + koliadedikismi15 + "<br />                                        " +
                        koliadedi15 + "</td>                                    <td style=\"padding: 5px; background-color: #ffcea0; width: 94px; text-align: center;\">                                        " +
                        urunaciklama15 + "</td>                                </tr>                                <tr>                                    <td colspan=\"2\" style=\"padding: 5px; text-align: center;\">                                        " +
                        "<img class=\"style4\" src=\"15barkod.png\" /></td>                                </tr>                            </table>                        </td>                    </tr>                    " +
                        "<tr>                        <td align=\"center\">                            <table cellpadding=\"0\" cellspacing=\"0\"                                                                                                                                 style=\"margin: 5px; padding: 0px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: 3px; border-bottom-width: 3px; border-left-width: 3px; border-right-color: #ffcea0; border-bottom-color: #ffcea0; border-left-color: #ffcea0;\">                                <tr>                                    <td colspan=\"2\"                                         style=\"padding: 5px; text-align: center; height: 136px; width: 136px;\" class=\"style3\">                                        " +
                        "<img alt=\"\" src=\"16.png\" /></td>                                </tr>                                <tr>                                    <td style=\"padding: 5px; background-color: #663300; text-align: center; color: #FFFFCC;\">                                        " + koliadedikismi16 + "<br />                                        " +
                        koliadedi16 + "</td>                                    <td style=\"padding: 5px; background-color: #ffcea0; width: 94px; text-align: center;\">                                        " +
                        urunaciklama16 + "</td>                                </tr>                                <tr>                                    <td colspan=\"2\" style=\"padding: 5px; text-align: center;\">                                        " +
                        "<img class=\"style4\" src=\"16barkod.png\" /></td>                                </tr>                            </table>                        </td>                        " +
                        "<td align=\"center\">                            <table cellpadding=\"0\" cellspacing=\"0\"                                                                                                                                 style=\"margin: 5px; padding: 0px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: 3px; border-bottom-width: 3px; border-left-width: 3px; border-right-color: #ffcea0; border-bottom-color: #ffcea0; border-left-color: #ffcea0;\">                                <tr>                                    <td colspan=\"2\"                                         style=\"padding: 5px; text-align: center; height: 136px; width: 136px;\" class=\"style3\">                                        " +
                        "<img alt=\"\" src=\"17.png\" /></td>                                </tr>                                <tr>                                    <td style=\"padding: 5px; background-color: #663300; text-align: center; color: #FFFFCC;\">                                        " + koliadedikismi17 + "<br />                                        " +
                        koliadedi17 + "</td>                                    <td style=\"padding: 5px; background-color: #ffcea0; width: 94px; text-align: center;\">                                        " +
                        urunaciklama17 + "</td>                                </tr>                                <tr>                                    <td colspan=\"2\" style=\"padding: 5px; text-align: center;\">                                        " +
                        "<img class=\"style4\" src=\"17barkod.png\" /></td>                                </tr>                            </table>                        </td>                        " +
                        "<td align=\"center\">                            <table cellpadding=\"0\" cellspacing=\"0\"                                                                                                                                 style=\"margin: 5px; padding: 0px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: 3px; border-bottom-width: 3px; border-left-width: 3px; border-right-color: #ffcea0; border-bottom-color: #ffcea0; border-left-color: #ffcea0;\">                                <tr>                                    <td colspan=\"2\"                                         style=\"padding: 5px; text-align: center; height: 136px; width: 136px;\" class=\"style3\">                                        " +
                        "<img alt=\"\" src=\"18.png\" /></td>                                </tr>                                <tr>                                    <td style=\"padding: 5px; background-color: #663300; text-align: center; color: #FFFFCC;\">                                        " + koliadedikismi18 + "<br />                                        " +
                        koliadedi18 + "</td>                                    <td style=\"padding: 5px; background-color: #ffcea0; width: 94px; text-align: center;\">                                        " +
                        urunaciklama18 + "</td>                                </tr>                                <tr>                                    <td colspan=\"2\" style=\"padding: 5px; text-align: center;\">                                        " +
                        "<img class=\"style4\" src=\"18barkod.png\" /></td>                                </tr>                            </table>                        </td>                        " +
                        "<td align=\"center\">                            <table cellpadding=\"0\" cellspacing=\"0\"                                                                                                                                 style=\"margin: 5px; padding: 0px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: 3px; border-bottom-width: 3px; border-left-width: 3px; border-right-color: #ffcea0; border-bottom-color: #ffcea0; border-left-color: #ffcea0;\">                                <tr>                                    <td colspan=\"2\"                                         style=\"padding: 5px; text-align: center; height: 136px; width: 136px;\" class=\"style3\">                                        " +
                        "<img alt=\"\" src=\"19.png\" /></td>                                </tr>                                <tr>                                    <td style=\"padding: 5px; background-color: #663300; text-align: center; color: #FFFFCC;\">                                        " + koliadedikismi19 + "<br />                                        " +
                        koliadedi19 + "</td>                                    <td style=\"padding: 5px; background-color: #ffcea0; width: 94px; text-align: center;\">                                        " +
                        urunaciklama19 + "</td>                                </tr>                                <tr>                                    <td colspan=\"2\" style=\"padding: 5px; text-align: center;\">                                        " +
                        "<img class=\"style4\" src=\"19barkod.png\" /></td>                                </tr>                            </table>                        </td>                        " +
                        "<td align=\"center\">                            <table cellpadding=\"0\" cellspacing=\"0\"                                                                                                                                 style=\"margin: 5px; padding: 0px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: 3px; border-bottom-width: 3px; border-left-width: 3px; border-right-color: #ffcea0; border-bottom-color: #ffcea0; border-left-color: #ffcea0;\">                                <tr>                                    <td colspan=\"2\"                                         style=\"padding: 5px; text-align: center; height: 136px; width: 136px;\" class=\"style3\">                                        " +
                        "<img alt=\"\" src=\"20.png\" /></td>                                </tr>                                <tr>                                    <td style=\"padding: 5px; background-color: #663300; text-align: center; color: #FFFFCC;\">                                        " + koliadedikismi20 + "<br />                                        " +
                        koliadedi20 + "</td>                                    <td style=\"padding: 5px; background-color: #ffcea0; width: 94px; text-align: center;\">                                        " +
                        urunaciklama20 + "</td>                                </tr>                                <tr>                                    <td colspan=\"2\" style=\"padding: 5px; text-align: center;\">                                        " +
                        "<img class=\"style4\" src=\"20barkod.png\" /></td>                                </tr>                            </table>                        </td>                    </tr>                </table>            </td>        </tr>        <tr>            <td style=\"background-image: url(footer-bg.png); height: 60px; padding: 0px 10px 20px 120px\">            <table style=\"margin-top: 5px\"><tr><td style=\"padding-right: 10px\"><span style=\"font-size: 14px\">                Dağıtım </span></td>            <td style=\"border-left-style: solid; border-left-color: #ffcea0; border-left-width: 1px;\">            <img class=\"style2\" src=\"1_sultanlar_logo.png\" style=\"padding: 3px 3px 3px 10px;\" /></td>            <td style=\"padding-left: 10px\">                <span style=\"font-size: 10px\"><i>Eyüp Sultan mh. Sekmen cd. No: 14 Sancaktepe / İSTANBUL</i><br /><i>Telefon: (+90 216) 561 50 00 Pbx</i><br /><i>Eposta: satis@sultanlar.com.tr</i></span></td></tr></table></td>        </tr>    </table></body></html>";

                // brosuru yaz
                if (File.Exists(txtCiktiYolu.Text + "\\Brosur.htm"))
                {
                    File.Delete(txtCiktiYolu.Text + "\\Brosur.htm");
                }
                StreamWriter sw = new StreamWriter(txtCiktiYolu.Text + "\\Brosur.htm", false, Encoding.Unicode);
                sw.Write(brosur);
                sw.Close();
                sw.Dispose();

                if (!cbKaynaktakiDosyalariSilme.Checked)
                    KaynaktakiDosyalariSil();

                webBrowser1.Navigate(txtCiktiYolu.Text + "\\Brosur.htm");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Onaltili()
        {
            try
            {
                Directory.CreateDirectory(txtCiktiYolu.Text);

                string bilgi1 = string.Empty, koliadedikismi1 = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />", koliadedi1 = string.Empty, urunaciklama1 = string.Empty,
                         bilgi2 = string.Empty, koliadedikismi2 = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />", koliadedi2 = string.Empty, urunaciklama2 = string.Empty,
                         bilgi3 = string.Empty, koliadedikismi3 = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />", koliadedi3 = string.Empty, urunaciklama3 = string.Empty,
                         bilgi4 = string.Empty, koliadedikismi4 = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />", koliadedi4 = string.Empty, urunaciklama4 = string.Empty,
                         bilgi5 = string.Empty, koliadedikismi5 = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />", koliadedi5 = string.Empty, urunaciklama5 = string.Empty,
                         bilgi6 = string.Empty, koliadedikismi6 = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />", koliadedi6 = string.Empty, urunaciklama6 = string.Empty,
                         bilgi7 = string.Empty, koliadedikismi7 = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />", koliadedi7 = string.Empty, urunaciklama7 = string.Empty,
                         bilgi8 = string.Empty, koliadedikismi8 = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />", koliadedi8 = string.Empty, urunaciklama8 = string.Empty,
                         bilgi9 = string.Empty, koliadedikismi9 = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />", koliadedi9 = string.Empty, urunaciklama9 = string.Empty,
                         bilgi10 = string.Empty, koliadedikismi10 = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />", koliadedi10 = string.Empty, urunaciklama10 = string.Empty,
                         bilgi11 = string.Empty, koliadedikismi11 = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />", koliadedi11 = string.Empty, urunaciklama11 = string.Empty,
                         bilgi12 = string.Empty, koliadedikismi12 = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />", koliadedi12 = string.Empty, urunaciklama12 = string.Empty,
                         bilgi13 = string.Empty, koliadedikismi13 = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />", koliadedi13 = string.Empty, urunaciklama13 = string.Empty,
                         bilgi14 = string.Empty, koliadedikismi14 = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />", koliadedi14 = string.Empty, urunaciklama14 = string.Empty,
                         bilgi15 = string.Empty, koliadedikismi15 = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />", koliadedi15 = string.Empty, urunaciklama15 = string.Empty,
                         bilgi16 = string.Empty, koliadedikismi16 = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />", koliadedi16 = string.Empty, urunaciklama16 = string.Empty;

                // tablo gerekli resimleri
                File.Copy("https://www.sultanlar.com.tr/sultanlarui/brosur/1_sultanlar_logo.png", txtCiktiYolu.Text + "\\1_sultanlar_logo.png", true);
                File.Copy("https://www.sultanlar.com.tr/sultanlarui/brosur/header-bg.png", txtCiktiYolu.Text + "\\header-bg.png", true);
                File.Copy("https://www.sultanlar.com.tr/sultanlarui/brosur/footer-bg.png", txtCiktiYolu.Text + "\\footer-bg.png", true);

                // şablon logosu
                if (File.Exists(txtDosyaYolu.Text + "\\logo.png"))
                {
                    File.Copy(txtDosyaYolu.Text + "\\logo.png", txtCiktiYolu.Text + "\\logo.png", true);
                }
                else
                {
                    File.Copy("https://www.sultanlar.com.tr/sultanlarui/brosur/1_sultanlar_logo.png", txtCiktiYolu.Text + "\\logo.png", true);
                }

                // urun resimleri ve barkodlari
                for (int i = 1; i <= 16; i++)
                {
                    //resim
                    if (File.Exists(txtDosyaYolu.Text + "\\" + i.ToString() + ".png") || File.Exists(txtDosyaYolu.Text + "\\" + i.ToString() + ".jpg"))
                    {
                        Image img = File.Exists(txtDosyaYolu.Text + "\\" + i.ToString() + ".png") ? Image.FromFile(txtDosyaYolu.Text + "\\" + i.ToString() + ".png") : Image.FromFile(txtDosyaYolu.Text + "\\" + i.ToString() + ".jpg");
                        Image kucukimg;
                        if (img.Height > img.Width)
                        {
                            double aspectRatio = Convert.ToDouble(img.Height) / img.Width;
                            double yukseklik = 126;
                            double genislik = yukseklik / aspectRatio;
                            kucukimg = Resim.ResimKucult(img, Convert.ToInt32(genislik));
                        }
                        else
                        {
                            kucukimg = Resim.ResimKucult(img, 126);
                        }
                        kucukimg.Save(txtCiktiYolu.Text + "\\" + i.ToString() + ".png");
                    }
                    else
                    {
                        File.Copy("https://www.sultanlar.com.tr/sultanlarui/brosur/bos.png", txtCiktiYolu.Text + "\\" + i.ToString() + ".png", true);
                    }

                    // barkod
                    if (File.Exists(txtDosyaYolu.Text + "\\" + i.ToString() + "barkod.png"))
                    {
                        File.Copy(txtDosyaYolu.Text + "\\" + i.ToString() + "barkod.png", txtCiktiYolu.Text + "\\" + i.ToString() + "barkod.png", true);
                    }
                    else
                    {
                        File.Copy("https://www.sultanlar.com.tr/sultanlarui/brosur/bos.png", txtCiktiYolu.Text + "\\" + i.ToString() + "barkod.png", true);
                    }
                }

                // urun aciklamalari
                if (File.Exists(txtDosyaYolu.Text + "\\1.txt"))
                {
                    bilgi1 = File.ReadAllText(txtDosyaYolu.Text + "\\1.txt", Encoding.GetEncoding("iso-8859-9")).ToUpper();
                    koliadedikismi1 = koliadedi;
                    koliadedi1 = bilgi1.Substring(0, bilgi1.IndexOf("\r\n"));
                    urunaciklama1 = bilgi1.Substring(bilgi1.IndexOf("\r\n") + 1);
                }
                if (File.Exists(txtDosyaYolu.Text + "\\2.txt"))
                {
                    bilgi2 = File.ReadAllText(txtDosyaYolu.Text + "\\2.txt", Encoding.GetEncoding("iso-8859-9")).ToUpper();
                    koliadedikismi2 = koliadedi;
                    koliadedi2 = bilgi2.Substring(0, bilgi2.IndexOf("\r\n"));
                    urunaciklama2 = bilgi2.Substring(bilgi2.IndexOf("\r\n") + 1);
                }
                if (File.Exists(txtDosyaYolu.Text + "\\3.txt"))
                {
                    bilgi3 = File.ReadAllText(txtDosyaYolu.Text + "\\3.txt", Encoding.GetEncoding("iso-8859-9")).ToUpper();
                    koliadedikismi3 = koliadedi;
                    koliadedi3 = bilgi3.Substring(0, bilgi3.IndexOf("\r\n"));
                    urunaciklama3 = bilgi3.Substring(bilgi3.IndexOf("\r\n") + 1);
                }
                if (File.Exists(txtDosyaYolu.Text + "\\4.txt"))
                {
                    bilgi4 = File.ReadAllText(txtDosyaYolu.Text + "\\4.txt", Encoding.GetEncoding("iso-8859-9")).ToUpper();
                    koliadedikismi4 = koliadedi;
                    koliadedi4 = bilgi4.Substring(0, bilgi4.IndexOf("\r\n"));
                    urunaciklama4 = bilgi4.Substring(bilgi4.IndexOf("\r\n") + 1);
                }
                if (File.Exists(txtDosyaYolu.Text + "\\5.txt"))
                {
                    bilgi5 = File.ReadAllText(txtDosyaYolu.Text + "\\5.txt", Encoding.GetEncoding("iso-8859-9")).ToUpper();
                    koliadedikismi5 = koliadedi;
                    koliadedi5 = bilgi5.Substring(0, bilgi5.IndexOf("\r\n"));
                    urunaciklama5 = bilgi5.Substring(bilgi5.IndexOf("\r\n") + 1);
                }
                if (File.Exists(txtDosyaYolu.Text + "\\6.txt"))
                {
                    bilgi6 = File.ReadAllText(txtDosyaYolu.Text + "\\6.txt", Encoding.GetEncoding("iso-8859-9")).ToUpper();
                    koliadedikismi6 = koliadedi;
                    koliadedi6 = bilgi6.Substring(0, bilgi6.IndexOf("\r\n"));
                    urunaciklama6 = bilgi6.Substring(bilgi6.IndexOf("\r\n") + 1);
                }
                if (File.Exists(txtDosyaYolu.Text + "\\7.txt"))
                {
                    bilgi7 = File.ReadAllText(txtDosyaYolu.Text + "\\7.txt", Encoding.GetEncoding("iso-8859-9")).ToUpper();
                    koliadedikismi7 = koliadedi;
                    koliadedi7 = bilgi7.Substring(0, bilgi7.IndexOf("\r\n"));
                    urunaciklama7 = bilgi7.Substring(bilgi7.IndexOf("\r\n") + 1);
                }
                if (File.Exists(txtDosyaYolu.Text + "\\8.txt"))
                {
                    bilgi8 = File.ReadAllText(txtDosyaYolu.Text + "\\8.txt", Encoding.GetEncoding("iso-8859-9")).ToUpper();
                    koliadedikismi8 = koliadedi;
                    koliadedi8 = bilgi8.Substring(0, bilgi8.IndexOf("\r\n"));
                    urunaciklama8 = bilgi8.Substring(bilgi8.IndexOf("\r\n") + 1);
                }
                if (File.Exists(txtDosyaYolu.Text + "\\9.txt"))
                {
                    bilgi9 = File.ReadAllText(txtDosyaYolu.Text + "\\9.txt", Encoding.GetEncoding("iso-8859-9")).ToUpper();
                    koliadedikismi9 = koliadedi;
                    koliadedi9 = bilgi9.Substring(0, bilgi9.IndexOf("\r\n"));
                    urunaciklama9 = bilgi9.Substring(bilgi9.IndexOf("\r\n") + 1);
                }
                if (File.Exists(txtDosyaYolu.Text + "\\10.txt"))
                {
                    bilgi10 = File.ReadAllText(txtDosyaYolu.Text + "\\10.txt", Encoding.GetEncoding("iso-8859-9")).ToUpper();
                    koliadedikismi10 = koliadedi;
                    koliadedi10 = bilgi10.Substring(0, bilgi10.IndexOf("\r\n"));
                    urunaciklama10 = bilgi10.Substring(bilgi10.IndexOf("\r\n") + 1);
                }
                if (File.Exists(txtDosyaYolu.Text + "\\11.txt"))
                {
                    bilgi11 = File.ReadAllText(txtDosyaYolu.Text + "\\11.txt", Encoding.GetEncoding("iso-8859-9")).ToUpper();
                    koliadedikismi11 = koliadedi;
                    koliadedi11 = bilgi11.Substring(0, bilgi11.IndexOf("\r\n"));
                    urunaciklama11 = bilgi11.Substring(bilgi11.IndexOf("\r\n") + 1);
                }
                if (File.Exists(txtDosyaYolu.Text + "\\12.txt"))
                {
                    bilgi12 = File.ReadAllText(txtDosyaYolu.Text + "\\12.txt", Encoding.GetEncoding("iso-8859-9")).ToUpper();
                    koliadedikismi12 = koliadedi;
                    koliadedi12 = bilgi12.Substring(0, bilgi12.IndexOf("\r\n"));
                    urunaciklama12 = bilgi12.Substring(bilgi12.IndexOf("\r\n") + 1);
                }
                if (File.Exists(txtDosyaYolu.Text + "\\13.txt"))
                {
                    bilgi13 = File.ReadAllText(txtDosyaYolu.Text + "\\13.txt", Encoding.GetEncoding("iso-8859-9")).ToUpper();
                    koliadedikismi13 = koliadedi;
                    koliadedi13 = bilgi13.Substring(0, bilgi13.IndexOf("\r\n"));
                    urunaciklama13 = bilgi13.Substring(bilgi13.IndexOf("\r\n") + 1);
                }
                if (File.Exists(txtDosyaYolu.Text + "\\14.txt"))
                {
                    bilgi14 = File.ReadAllText(txtDosyaYolu.Text + "\\14.txt", Encoding.GetEncoding("iso-8859-9")).ToUpper();
                    koliadedikismi14 = koliadedi;
                    koliadedi14 = bilgi14.Substring(0, bilgi14.IndexOf("\r\n"));
                    urunaciklama14 = bilgi14.Substring(bilgi14.IndexOf("\r\n") + 1);
                }
                if (File.Exists(txtDosyaYolu.Text + "\\15.txt"))
                {
                    bilgi15 = File.ReadAllText(txtDosyaYolu.Text + "\\15.txt", Encoding.GetEncoding("iso-8859-9")).ToUpper();
                    koliadedikismi15 = koliadedi;
                    koliadedi15 = bilgi15.Substring(0, bilgi15.IndexOf("\r\n"));
                    urunaciklama15 = bilgi15.Substring(bilgi15.IndexOf("\r\n") + 1);
                }
                if (File.Exists(txtDosyaYolu.Text + "\\16.txt"))
                {
                    bilgi16 = File.ReadAllText(txtDosyaYolu.Text + "\\16.txt", Encoding.GetEncoding("iso-8859-9")).ToUpper();
                    koliadedikismi16 = koliadedi;
                    koliadedi16 = bilgi16.Substring(0, bilgi16.IndexOf("\r\n"));
                    urunaciklama16 = bilgi16.Substring(bilgi16.IndexOf("\r\n") + 1);
                }

                // brosuru olustur
                string brosur = "<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\"><html xmlns=\"http://www.w3.org/1999/xhtml\" ><head>    <title>Untitled Page</title>    <style type=\"text/css\">        .style1 {            width: 730px;            height: 929px;            font-family:Tahoma;             font-size: 7px;            font-weight: normal;        }        .style2        {            width: 138px;            height: 43px;        }        .style3        { background-color: " + txtRenk.Text + "; } .style4        {            width: 100px;            height: 37px;        }          </style></head><body style=\"margin: 0px 0px 0px 10px\">    <table cellpadding=\"0\" cellspacing=\"0\" class=\"style1\"         style=\"border: 1px solid #ffcea0\">        <tr>            <td style=\"background-image: url(header-bg.png); height: 60px; padding: 10px 10px 0px 100px\">            " +
                        "<img src=\"logo.png\"                     style=\"padding: 10px 3px 3px 10px; height: 48px;\" /></td>        </tr>        <tr>            <td>                <table cellpadding=\"0\" cellspacing=\"0\" class=\"style1\">                    <tr>                        <td align=\"center\">                            <table cellpadding=\"0\" cellspacing=\"0\"                                                                                                 style=\"margin: 5px; padding: 0px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: 3px; border-bottom-width: 3px; border-left-width: 3px; border-right-color: #ffcea0; border-bottom-color: #ffcea0; border-left-color: #ffcea0;\">                                <tr>                                    <td colspan=\"2\"                                         style=\"padding: 5px; text-align: center; height: 136px; width: 136px;\" class=\"style3\">                                        " +
                        "<img alt=\"\" src=\"1.png\" /></td>                                </tr>                                <tr>                                    <td style=\"padding: 5px; background-color: #663300; text-align: center; color: #FFFFCC;\">                                        " + koliadedikismi1 + "<br />                                        " +
                        koliadedi1 + "</td>                                    <td style=\"padding: 5px; background-color: #ffcea0; width: 94px; text-align: center;\">                                        " +
                        urunaciklama1 + "</td>                                </tr>                                <tr>                                    <td colspan=\"2\" style=\"padding: 5px; text-align: center;\">                                        " +
                        "<img class=\"style4\" src=\"1barkod.png\" /></td>                                </tr>                            </table>                        </td>                        " +
                        "<td align=\"center\">                            <table cellpadding=\"0\" cellspacing=\"0\"                                                                                                                                 style=\"margin: 5px; padding: 0px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: 3px; border-bottom-width: 3px; border-left-width: 3px; border-right-color: #ffcea0; border-bottom-color: #ffcea0; border-left-color: #ffcea0;\">                                <tr>                                    <td colspan=\"2\"                                         style=\"padding: 5px; text-align: center; height: 136px; width: 136px;\" class=\"style3\">                                        " +
                        "<img alt=\"\" src=\"2.png\" /></td>                                </tr>                                <tr>                                    <td style=\"padding: 5px; background-color: #663300; text-align: center; color: #FFFFCC;\">                                        " + koliadedikismi2 + "<br />                                        " +
                        koliadedi2 + "</td>                                    <td style=\"padding: 5px; background-color: #ffcea0; width: 94px; text-align: center;\">                                        " +
                        urunaciklama2 + "</td>                                </tr>                                <tr>                                    <td colspan=\"2\" style=\"padding: 5px; text-align: center;\">                                        " +
                        "<img class=\"style4\" src=\"2barkod.png\" /></td>                                </tr>                            </table>                        </td>                        " +
                        "<td align=\"center\">                            <table cellpadding=\"0\" cellspacing=\"0\"                                                                                                                                 style=\"margin: 5px; padding: 0px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: 3px; border-bottom-width: 3px; border-left-width: 3px; border-right-color: #ffcea0; border-bottom-color: #ffcea0; border-left-color: #ffcea0;\">                                <tr>                                    <td colspan=\"2\"                                         style=\"padding: 5px; text-align: center; height: 136px; width: 136px;\" class=\"style3\">                                        " +
                        "<img alt=\"\" src=\"3.png\" /></td>                                </tr>                                <tr>                                    <td style=\"padding: 5px; background-color: #663300; text-align: center; color: #FFFFCC;\">                                        " + koliadedikismi3 + "<br />                                        " +
                        koliadedi3 + "</td>                                    <td style=\"padding: 5px; background-color: #ffcea0; width: 94px; text-align: center;\">                                        " +
                        urunaciklama3 + "</td>                                </tr>                                <tr>                                    <td colspan=\"2\" style=\"padding: 5px; text-align: center;\">                                        " +
                        "<img class=\"style4\" src=\"3barkod.png\" /></td>                                </tr>                            </table>                        </td>                        " +
                        "<td align=\"center\">                            <table cellpadding=\"0\" cellspacing=\"0\"                                                                                                                                 style=\"margin: 5px; padding: 0px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: 3px; border-bottom-width: 3px; border-left-width: 3px; border-right-color: #ffcea0; border-bottom-color: #ffcea0; border-left-color: #ffcea0;\">                                <tr>                                    <td colspan=\"2\"                                         style=\"padding: 5px; text-align: center; height: 136px; width: 136px;\" class=\"style3\">                                        " +
                        "<img alt=\"\" src=\"4.png\" /></td>                                </tr>                                <tr>                                    <td style=\"padding: 5px; background-color: #663300; text-align: center; color: #FFFFCC;\">                                        " + koliadedikismi4 + "<br />                                        " +
                        koliadedi4+ "</td>                                    <td style=\"padding: 5px; background-color: #ffcea0; width: 94px; text-align: center;\">                                        " +
                        urunaciklama4 + "</td>                                </tr>                                <tr>                                    <td colspan=\"2\" style=\"padding: 5px; text-align: center;\">                                        " +
                        "<img class=\"style4\" src=\"4barkod.png\" /></td>                                </tr>                            </table>                        </td>                    </tr>                    " +
                        "<tr>                        <td align=\"center\">                            <table cellpadding=\"0\" cellspacing=\"0\"                                                                                                                                 style=\"margin: 5px; padding: 0px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: 3px; border-bottom-width: 3px; border-left-width: 3px; border-right-color: #ffcea0; border-bottom-color: #ffcea0; border-left-color: #ffcea0;\">                                <tr>                                    <td colspan=\"2\"                                         style=\"padding: 5px; text-align: center; height: 136px; width: 136px;\" class=\"style3\">                                        " +
                        "<img alt=\"\" src=\"5.png\" /></td>                                </tr>                                <tr>                                    <td style=\"padding: 5px; background-color: #663300; text-align: center; color: #FFFFCC;\">                                        " + koliadedikismi5 + "<br />                                        " +
                        koliadedi5 + "</td>                                    <td style=\"padding: 5px; background-color: #ffcea0; width: 94px; text-align: center;\">                                        " +
                        urunaciklama5 + "</td>                                </tr>                                <tr>                                    <td colspan=\"2\" style=\"padding: 5px; text-align: center;\">                                        " +
                        "<img class=\"style4\" src=\"5barkod.png\" /></td>                                </tr>                            </table>                        </td>                        " +
                        "<td align=\"center\">                            <table cellpadding=\"0\" cellspacing=\"0\"                                                                                                                                 style=\"margin: 5px; padding: 0px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: 3px; border-bottom-width: 3px; border-left-width: 3px; border-right-color: #ffcea0; border-bottom-color: #ffcea0; border-left-color: #ffcea0;\">                                <tr>                                    <td colspan=\"2\"                                         style=\"padding: 5px; text-align: center; height: 136px; width: 136px;\" class=\"style3\">                                        " +
                        "<img alt=\"\" src=\"6.png\" /></td>                                </tr>                                <tr>                                    <td style=\"padding: 5px; background-color: #663300; text-align: center; color: #FFFFCC;\">                                        " + koliadedikismi6 + "<br />                                        " +
                        koliadedi6 + "</td>                                    <td style=\"padding: 5px; background-color: #ffcea0; width: 94px; text-align: center;\">                                        " +
                        urunaciklama6 + "</td>                                </tr>                                <tr>                                    <td colspan=\"2\" style=\"padding: 5px; text-align: center;\">                                        " +
                        "<img class=\"style4\" src=\"6barkod.png\" /></td>                                </tr>                            </table>                        </td>                        " +
                        "<td align=\"center\">                            <table cellpadding=\"0\" cellspacing=\"0\"                                                                                                                                 style=\"margin: 5px; padding: 0px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: 3px; border-bottom-width: 3px; border-left-width: 3px; border-right-color: #ffcea0; border-bottom-color: #ffcea0; border-left-color: #ffcea0;\">                                <tr>                                    <td colspan=\"2\"                                         style=\"padding: 5px; text-align: center; height: 136px; width: 136px;\" class=\"style3\">                                        " +
                        "<img alt=\"\" src=\"7.png\" /></td>                                </tr>                                <tr>                                    <td style=\"padding: 5px; background-color: #663300; text-align: center; color: #FFFFCC;\">                                        " + koliadedikismi7 + "<br />                                        " +
                        koliadedi7 + "</td>                                    <td style=\"padding: 5px; background-color: #ffcea0; width: 94px; text-align: center;\">                                        " +
                        urunaciklama7 + "</td>                                </tr>                                <tr>                                    <td colspan=\"2\" style=\"padding: 5px; text-align: center;\">                                        " +
                        "<img class=\"style4\" src=\"7barkod.png\" /></td>                                </tr>                            </table>                        </td>                        " +
                        "<td align=\"center\">                            <table cellpadding=\"0\" cellspacing=\"0\"                                                                                                                                 style=\"margin: 5px; padding: 0px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: 3px; border-bottom-width: 3px; border-left-width: 3px; border-right-color: #ffcea0; border-bottom-color: #ffcea0; border-left-color: #ffcea0;\">                                <tr>                                    <td colspan=\"2\"                                         style=\"padding: 5px; text-align: center; height: 136px; width: 136px;\" class=\"style3\">                                        " +
                        "<img alt=\"\" src=\"8.png\" /></td>                                </tr>                                <tr>                                    <td style=\"padding: 5px; background-color: #663300; text-align: center; color: #FFFFCC;\">                                        " + koliadedikismi8 + "<br />                                        " +
                        koliadedi8 + "</td>                                    <td style=\"padding: 5px; background-color: #ffcea0; width: 94px; text-align: center;\">                                        " +
                        urunaciklama8 + "</td>                                </tr>                                <tr>                                    <td colspan=\"2\" style=\"padding: 5px; text-align: center;\">                                        " +
                        "<img class=\"style4\" src=\"8barkod.png\" /></td>                                </tr>                            </table>                        </td>                    </tr>                    " +
                        "<tr>                        <td align=\"center\">                            <table cellpadding=\"0\" cellspacing=\"0\"                                                                                                                                 style=\"margin: 5px; padding: 0px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: 3px; border-bottom-width: 3px; border-left-width: 3px; border-right-color: #ffcea0; border-bottom-color: #ffcea0; border-left-color: #ffcea0;\">                                <tr>                                    <td colspan=\"2\"                                         style=\"padding: 5px; text-align: center; height: 136px; width: 136px;\" class=\"style3\">                                        " +
                        "<img alt=\"\" src=\"9.png\" /></td>                                </tr>                                <tr>                                    <td style=\"padding: 5px; background-color: #663300; text-align: center; color: #FFFFCC;\">                                        " + koliadedikismi9 + "<br />                                        " +
                        koliadedi9 + "</td>                                    <td style=\"padding: 5px; background-color: #ffcea0; width: 94px; text-align: center;\">                                        " +
                        urunaciklama9 + "</td>                                </tr>                                <tr>                                    <td colspan=\"2\" style=\"padding: 5px; text-align: center;\">                                        " +
                        "<img class=\"style4\" src=\"9barkod.png\" /></td>                                </tr>                            </table>                        </td>                        " +
                        "<td align=\"center\">                            <table cellpadding=\"0\" cellspacing=\"0\"                                                                                                                                 style=\"margin: 5px; padding: 0px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: 3px; border-bottom-width: 3px; border-left-width: 3px; border-right-color: #ffcea0; border-bottom-color: #ffcea0; border-left-color: #ffcea0;\">                                <tr>                                    <td colspan=\"2\"                                         style=\"padding: 5px; text-align: center; height: 136px; width: 136px;\" class=\"style3\">                                        " +
                        "<img alt=\"\" src=\"10.png\" /></td>                                </tr>                                <tr>                                    <td style=\"padding: 5px; background-color: #663300; text-align: center; color: #FFFFCC;\">                                        " + koliadedikismi10 + "<br />                                        " +
                        koliadedi10 + "</td>                                    <td style=\"padding: 5px; background-color: #ffcea0; width: 94px; text-align: center;\">                                        " +
                        urunaciklama10 + "</td>                                </tr>                                <tr>                                    <td colspan=\"2\" style=\"padding: 5px; text-align: center;\">                                        " +
                        "<img class=\"style4\" src=\"10barkod.png\" /></td>                                </tr>                            </table>                        </td>                        " +
                        "<td align=\"center\">                            <table cellpadding=\"0\" cellspacing=\"0\"                                                                                                                                 style=\"margin: 5px; padding: 0px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: 3px; border-bottom-width: 3px; border-left-width: 3px; border-right-color: #ffcea0; border-bottom-color: #ffcea0; border-left-color: #ffcea0;\">                                <tr>                                    <td colspan=\"2\"                                         style=\"padding: 5px; text-align: center; height: 136px; width: 136px;\" class=\"style3\">                                        " +
                        "<img alt=\"\" src=\"11.png\" /></td>                                </tr>                                <tr>                                    <td style=\"padding: 5px; background-color: #663300; text-align: center; color: #FFFFCC;\">                                        " + koliadedikismi11 + "<br />                                        " +
                        koliadedi11 + "</td>                                    <td style=\"padding: 5px; background-color: #ffcea0; width: 94px; text-align: center;\">                                        " +
                        urunaciklama11 + "</td>                                </tr>                                <tr>                                    <td colspan=\"2\" style=\"padding: 5px; text-align: center;\">                                        " +
                        "<img class=\"style4\" src=\"11barkod.png\" /></td>                                </tr>                            </table>                        </td>                        " +
                        "<td align=\"center\">                            <table cellpadding=\"0\" cellspacing=\"0\"                                                                                                                                 style=\"margin: 5px; padding: 0px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: 3px; border-bottom-width: 3px; border-left-width: 3px; border-right-color: #ffcea0; border-bottom-color: #ffcea0; border-left-color: #ffcea0;\">                                <tr>                                    <td colspan=\"2\"                                         style=\"padding: 5px; text-align: center; height: 136px; width: 136px;\" class=\"style3\">                                        " +
                        "<img alt=\"\" src=\"12.png\" /></td>                                </tr>                                <tr>                                    <td style=\"padding: 5px; background-color: #663300; text-align: center; color: #FFFFCC;\">                                        " + koliadedikismi12 + "<br />                                        " +
                        koliadedi12 + "</td>                                    <td style=\"padding: 5px; background-color: #ffcea0; width: 94px; text-align: center;\">                                        " +
                        urunaciklama12 + "</td>                                </tr>                                <tr>                                    <td colspan=\"2\" style=\"padding: 5px; text-align: center;\">                                        " +
                        "<img class=\"style4\" src=\"12barkod.png\" /></td>                                </tr>                            </table>                        </td>                    </tr>                    " +
                        "<tr>                        <td align=\"center\">                            <table cellpadding=\"0\" cellspacing=\"0\"                                                                                                                                 style=\"margin: 5px; padding: 0px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: 3px; border-bottom-width: 3px; border-left-width: 3px; border-right-color: #ffcea0; border-bottom-color: #ffcea0; border-left-color: #ffcea0;\">                                <tr>                                    <td colspan=\"2\"                                         style=\"padding: 5px; text-align: center; height: 136px; width: 136px;\" class=\"style3\">                                        " +
                        "<img alt=\"\" src=\"13.png\" /></td>                                </tr>                                <tr>                                    <td style=\"padding: 5px; background-color: #663300; text-align: center; color: #FFFFCC;\">                                        " + koliadedikismi13 + "<br />                                        " +
                        koliadedi13 + "</td>                                    <td style=\"padding: 5px; background-color: #ffcea0; width: 94px; text-align: center;\">                                        " +
                        urunaciklama13 + "</td>                                </tr>                                <tr>                                    <td colspan=\"2\" style=\"padding: 5px; text-align: center;\">                                        " +
                        "<img class=\"style4\" src=\"13barkod.png\" /></td>                                </tr>                            </table>                        </td>                        " +
                        "<td align=\"center\">                            <table cellpadding=\"0\" cellspacing=\"0\"                                                                                                                                 style=\"margin: 5px; padding: 0px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: 3px; border-bottom-width: 3px; border-left-width: 3px; border-right-color: #ffcea0; border-bottom-color: #ffcea0; border-left-color: #ffcea0;\">                                <tr>                                    <td colspan=\"2\"                                         style=\"padding: 5px; text-align: center; height: 136px; width: 136px;\" class=\"style3\">                                        " +
                        "<img alt=\"\" src=\"14.png\" /></td>                                </tr>                                <tr>                                    <td style=\"padding: 5px; background-color: #663300; text-align: center; color: #FFFFCC;\">                                        " + koliadedikismi14 + "<br />                                        " +
                        koliadedi14 + "</td>                                    <td style=\"padding: 5px; background-color: #ffcea0; width: 94px; text-align: center;\">                                        " +
                        urunaciklama14 + "</td>                                </tr>                                <tr>                                    <td colspan=\"2\" style=\"padding: 5px; text-align: center;\">                                        " +
                        "<img class=\"style4\" src=\"14barkod.png\" /></td>                                </tr>                            </table>                        </td>                        " +
                        "<td align=\"center\">                            <table cellpadding=\"0\" cellspacing=\"0\"                                                                                                                                 style=\"margin: 5px; padding: 0px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: 3px; border-bottom-width: 3px; border-left-width: 3px; border-right-color: #ffcea0; border-bottom-color: #ffcea0; border-left-color: #ffcea0;\">                                <tr>                                    <td colspan=\"2\"                                         style=\"padding: 5px; text-align: center; height: 136px; width: 136px;\" class=\"style3\">                                        " +
                        "<img alt=\"\" src=\"15.png\" /></td>                                </tr>                                <tr>                                    <td style=\"padding: 5px; background-color: #663300; text-align: center; color: #FFFFCC;\">                                        " + koliadedikismi15 + "<br />                                        " +
                        koliadedi15 + "</td>                                    <td style=\"padding: 5px; background-color: #ffcea0; width: 94px; text-align: center;\">                                        " +
                        urunaciklama15 + "</td>                                </tr>                                <tr>                                    <td colspan=\"2\" style=\"padding: 5px; text-align: center;\">                                        " +
                        "<img class=\"style4\" src=\"15barkod.png\" /></td>                                </tr>                            </table>                        </td>                        " +
                        "<td align=\"center\">                            <table cellpadding=\"0\" cellspacing=\"0\"                                                                                                                                 style=\"margin: 5px; padding: 0px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: 3px; border-bottom-width: 3px; border-left-width: 3px; border-right-color: #ffcea0; border-bottom-color: #ffcea0; border-left-color: #ffcea0;\">                                <tr>                                    <td colspan=\"2\"                                         style=\"padding: 5px; text-align: center; height: 136px; width: 136px;\" class=\"style3\">                                        " +
                        "<img alt=\"\" src=\"16.png\" /></td>                                </tr>                                <tr>                                    <td style=\"padding: 5px; background-color: #663300; text-align: center; color: #FFFFCC;\">                                        " + koliadedikismi16 + "<br />                                        " +
                        koliadedi16 + "</td>                                    <td style=\"padding: 5px; background-color: #ffcea0; width: 94px; text-align: center;\">                                        " +
                        urunaciklama16 + "</td>                                </tr>                                <tr>                                    <td colspan=\"2\" style=\"padding: 5px; text-align: center;\">                                        " +
                        "<img class=\"style4\" src=\"16barkod.png\" /></td>                                </tr>                            </table>                        </td>                    </tr>                </table>            </td>        </tr>        <tr>            <td style=\"background-image: url(footer-bg.png); height: 60px; padding: 0px 10px 20px 120px\">            <table style=\"margin-top: 5px\"><tr><td style=\"padding-right: 10px\"><span style=\"font-size: 14px\">                Dağıtım </span></td>            <td style=\"border-left-style: solid; border-left-color: #ffcea0; border-left-width: 1px;\">            <img class=\"style2\" src=\"1_sultanlar_logo.png\" style=\"padding: 3px 3px 3px 10px;\" /></td>            <td style=\"padding-left: 10px\">                <span style=\"font-size: 10px\"><i>Eyüp Sultan mh. Sekmen cd. No: 14 Sancaktepe / İSTANBUL</i><br /><i>Telefon: (+90 216) 561 50 00 Pbx</i><br /><i>Eposta: satis@sultanlar.com.tr</i></span></td></tr></table></td>        </tr>    </table></body></html>";

                // brosuru yaz
                if (File.Exists(txtCiktiYolu.Text + "\\Brosur.htm"))
                {
                    File.Delete(txtCiktiYolu.Text + "\\Brosur.htm");
                }
                StreamWriter sw = new StreamWriter(txtCiktiYolu.Text + "\\Brosur.htm", false, Encoding.Unicode);
                sw.Write(brosur);
                sw.Close();
                sw.Dispose();

                if (!cbKaynaktakiDosyalariSilme.Checked)
                    KaynaktakiDosyalariSil();

                webBrowser1.Navigate(txtCiktiYolu.Text + "\\Brosur.htm");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Onikili()
        {
            try
            {
                Directory.CreateDirectory(txtCiktiYolu.Text);

                string bilgi1 = string.Empty, koliadedikismi1 = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />", koliadedi1 = string.Empty, urunaciklama1 = string.Empty,
                         bilgi2 = string.Empty, koliadedikismi2 = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />", koliadedi2 = string.Empty, urunaciklama2 = string.Empty,
                         bilgi3 = string.Empty, koliadedikismi3 = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />", koliadedi3 = string.Empty, urunaciklama3 = string.Empty,
                         bilgi4 = string.Empty, koliadedikismi4 = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />", koliadedi4 = string.Empty, urunaciklama4 = string.Empty,
                         bilgi5 = string.Empty, koliadedikismi5 = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />", koliadedi5 = string.Empty, urunaciklama5 = string.Empty,
                         bilgi6 = string.Empty, koliadedikismi6 = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />", koliadedi6 = string.Empty, urunaciklama6 = string.Empty,
                         bilgi7 = string.Empty, koliadedikismi7 = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />", koliadedi7 = string.Empty, urunaciklama7 = string.Empty,
                         bilgi8 = string.Empty, koliadedikismi8 = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />", koliadedi8 = string.Empty, urunaciklama8 = string.Empty,
                         bilgi9 = string.Empty, koliadedikismi9 = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />", koliadedi9 = string.Empty, urunaciklama9 = string.Empty,
                         bilgi10 = string.Empty, koliadedikismi10 = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />", koliadedi10 = string.Empty, urunaciklama10 = string.Empty,
                         bilgi11 = string.Empty, koliadedikismi11 = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />", koliadedi11 = string.Empty, urunaciklama11 = string.Empty,
                         bilgi12 = string.Empty, koliadedikismi12 = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />", koliadedi12 = string.Empty, urunaciklama12 = string.Empty;

                // tablo gerekli resimleri
                File.Copy("https://www.sultanlar.com.tr/sultanlarui/brosur/1_sultanlar_logo.png", txtCiktiYolu.Text + "\\1_sultanlar_logo.png", true);
                File.Copy("https://www.sultanlar.com.tr/sultanlarui/brosur/header-bg.png", txtCiktiYolu.Text + "\\header-bg.png", true);
                File.Copy("https://www.sultanlar.com.tr/sultanlarui/brosur/footer-bg.png", txtCiktiYolu.Text + "\\footer-bg.png", true);

                // şablon logosu
                if (File.Exists(txtDosyaYolu.Text + "\\logo.png"))
                {
                    File.Copy(txtDosyaYolu.Text + "\\logo.png", txtCiktiYolu.Text + "\\logo.png", true);
                }
                else
                {
                    File.Copy("https://www.sultanlar.com.tr/sultanlarui/brosur/1_sultanlar_logo.png", txtCiktiYolu.Text + "\\logo.png", true);
                }

                // urun resimleri ve barkodlari
                for (int i = 1; i <= 12; i++)
                {
                    //resim
                    if (File.Exists(txtDosyaYolu.Text + "\\" + i.ToString() + ".png") || File.Exists(txtDosyaYolu.Text + "\\" + i.ToString() + ".jpg"))
                    {
                        Image img = File.Exists(txtDosyaYolu.Text + "\\" + i.ToString() + ".png") ? Image.FromFile(txtDosyaYolu.Text + "\\" + i.ToString() + ".png") : Image.FromFile(txtDosyaYolu.Text + "\\" + i.ToString() + ".jpg");
                        Image kucukimg;
                        if (img.Height > img.Width)
                        {
                            double aspectRatio = Convert.ToDouble(img.Height) / img.Width;
                            double yukseklik = 126;
                            double genislik = yukseklik / aspectRatio;
                            kucukimg = Resim.ResimKucult(img, Convert.ToInt32(genislik));
                        }
                        else
                        {
                            kucukimg = Resim.ResimKucult(img, 126);
                        }
                        kucukimg.Save(txtCiktiYolu.Text + "\\" + i.ToString() + ".png");
                    }
                    else
                    {
                        File.Copy("https://www.sultanlar.com.tr/sultanlarui/brosur/bos.png", txtCiktiYolu.Text + "\\" + i.ToString() + ".png", true);
                    }

                    // barkod
                    if (File.Exists(txtDosyaYolu.Text + "\\" + i.ToString() + "barkod.png"))
                    {
                        File.Copy(txtDosyaYolu.Text + "\\" + i.ToString() + "barkod.png", txtCiktiYolu.Text + "\\" + i.ToString() + "barkod.png", true);
                    }
                    else
                    {
                        File.Copy("https://www.sultanlar.com.tr/sultanlarui/brosur/bos.png", txtCiktiYolu.Text + "\\" + i.ToString() + "barkod.png", true);
                    }
                }

                // urun aciklamalari
                if (File.Exists(txtDosyaYolu.Text + "\\1.txt"))
                {
                    bilgi1 = File.ReadAllText(txtDosyaYolu.Text + "\\1.txt", Encoding.GetEncoding("iso-8859-9")).ToUpper();
                    koliadedikismi1 = koliadedi;
                    koliadedi1 = bilgi1.Substring(0, bilgi1.IndexOf("\r\n"));
                    urunaciklama1 = bilgi1.Substring(bilgi1.IndexOf("\r\n") + 1);
                }
                if (File.Exists(txtDosyaYolu.Text + "\\2.txt"))
                {
                    bilgi2 = File.ReadAllText(txtDosyaYolu.Text + "\\2.txt", Encoding.GetEncoding("iso-8859-9")).ToUpper();
                    koliadedikismi2 = koliadedi;
                    koliadedi2 = bilgi2.Substring(0, bilgi2.IndexOf("\r\n"));
                    urunaciklama2 = bilgi2.Substring(bilgi2.IndexOf("\r\n") + 1);
                }
                if (File.Exists(txtDosyaYolu.Text + "\\3.txt"))
                {
                    bilgi3 = File.ReadAllText(txtDosyaYolu.Text + "\\3.txt", Encoding.GetEncoding("iso-8859-9")).ToUpper();
                    koliadedikismi3 = koliadedi;
                    koliadedi3 = bilgi3.Substring(0, bilgi3.IndexOf("\r\n"));
                    urunaciklama3 = bilgi3.Substring(bilgi3.IndexOf("\r\n") + 1);
                }
                if (File.Exists(txtDosyaYolu.Text + "\\4.txt"))
                {
                    bilgi4 = File.ReadAllText(txtDosyaYolu.Text + "\\4.txt", Encoding.GetEncoding("iso-8859-9")).ToUpper();
                    koliadedikismi4 = koliadedi;
                    koliadedi4 = bilgi4.Substring(0, bilgi4.IndexOf("\r\n"));
                    urunaciklama4 = bilgi4.Substring(bilgi4.IndexOf("\r\n") + 1);
                }
                if (File.Exists(txtDosyaYolu.Text + "\\5.txt"))
                {
                    bilgi5 = File.ReadAllText(txtDosyaYolu.Text + "\\5.txt", Encoding.GetEncoding("iso-8859-9")).ToUpper();
                    koliadedikismi5 = koliadedi;
                    koliadedi5 = bilgi5.Substring(0, bilgi5.IndexOf("\r\n"));
                    urunaciklama5 = bilgi5.Substring(bilgi5.IndexOf("\r\n") + 1);
                }
                if (File.Exists(txtDosyaYolu.Text + "\\6.txt"))
                {
                    bilgi6 = File.ReadAllText(txtDosyaYolu.Text + "\\6.txt", Encoding.GetEncoding("iso-8859-9")).ToUpper();
                    koliadedikismi6 = koliadedi;
                    koliadedi6 = bilgi6.Substring(0, bilgi6.IndexOf("\r\n"));
                    urunaciklama6 = bilgi6.Substring(bilgi6.IndexOf("\r\n") + 1);
                }
                if (File.Exists(txtDosyaYolu.Text + "\\7.txt"))
                {
                    bilgi7 = File.ReadAllText(txtDosyaYolu.Text + "\\7.txt", Encoding.GetEncoding("iso-8859-9")).ToUpper();
                    koliadedikismi7 = koliadedi;
                    koliadedi7 = bilgi7.Substring(0, bilgi7.IndexOf("\r\n"));
                    urunaciklama7 = bilgi7.Substring(bilgi7.IndexOf("\r\n") + 1);
                }
                if (File.Exists(txtDosyaYolu.Text + "\\8.txt"))
                {
                    bilgi8 = File.ReadAllText(txtDosyaYolu.Text + "\\8.txt", Encoding.GetEncoding("iso-8859-9")).ToUpper();
                    koliadedikismi8 = koliadedi;
                    koliadedi8 = bilgi8.Substring(0, bilgi8.IndexOf("\r\n"));
                    urunaciklama8 = bilgi8.Substring(bilgi8.IndexOf("\r\n") + 1);
                }
                if (File.Exists(txtDosyaYolu.Text + "\\9.txt"))
                {
                    bilgi9 = File.ReadAllText(txtDosyaYolu.Text + "\\9.txt", Encoding.GetEncoding("iso-8859-9")).ToUpper();
                    koliadedikismi9 = koliadedi;
                    koliadedi9 = bilgi9.Substring(0, bilgi9.IndexOf("\r\n"));
                    urunaciklama9 = bilgi9.Substring(bilgi9.IndexOf("\r\n") + 1);
                }
                if (File.Exists(txtDosyaYolu.Text + "\\10.txt"))
                {
                    bilgi10 = File.ReadAllText(txtDosyaYolu.Text + "\\10.txt", Encoding.GetEncoding("iso-8859-9")).ToUpper();
                    koliadedikismi10 = koliadedi;
                    koliadedi10 = bilgi10.Substring(0, bilgi10.IndexOf("\r\n"));
                    urunaciklama10 = bilgi10.Substring(bilgi10.IndexOf("\r\n") + 1);
                }
                if (File.Exists(txtDosyaYolu.Text + "\\11.txt"))
                {
                    bilgi11 = File.ReadAllText(txtDosyaYolu.Text + "\\11.txt", Encoding.GetEncoding("iso-8859-9")).ToUpper();
                    koliadedikismi11 = koliadedi;
                    koliadedi11 = bilgi11.Substring(0, bilgi11.IndexOf("\r\n"));
                    urunaciklama11 = bilgi11.Substring(bilgi11.IndexOf("\r\n") + 1);
                }
                if (File.Exists(txtDosyaYolu.Text + "\\12.txt"))
                {
                    bilgi12 = File.ReadAllText(txtDosyaYolu.Text + "\\12.txt", Encoding.GetEncoding("iso-8859-9")).ToUpper();
                    koliadedikismi12 = koliadedi;
                    koliadedi12 = bilgi12.Substring(0, bilgi12.IndexOf("\r\n"));
                    urunaciklama12 = bilgi12.Substring(bilgi12.IndexOf("\r\n") + 1);
                }

                // brosuru olustur
                string brosur = "<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\"><html xmlns=\"http://www.w3.org/1999/xhtml\" ><head>    <title>Untitled Page</title>    <style type=\"text/css\">        .style1 {            width: 730px;            height: 929px;            font-family:Tahoma;             font-size: 7px;            font-weight: normal;        }        .style2        {            width: 138px;            height: 43px;        }        .style3        { background-color: " + txtRenk.Text + "; } .style4        {            width: 100px;            height: 37px;        }          </style></head><body style=\"margin: 0px 0px 0px 10px\">    <table cellpadding=\"0\" cellspacing=\"0\" class=\"style1\"         style=\"border: 1px solid #ffcea0\">        <tr>            <td style=\"background-image: url(header-bg.png); height: 60px; padding: 10px 10px 0px 100px\">            " +
                        "<img src=\"logo.png\"                     style=\"padding: 10px 3px 3px 10px; height: 48px;\" /></td>        </tr>        <tr>            <td>                <table cellpadding=\"0\" cellspacing=\"0\" class=\"style1\">                    <tr>                        <td align=\"center\">                            <table cellpadding=\"0\" cellspacing=\"0\"                                                                                                 style=\"margin: 5px; padding: 0px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: 3px; border-bottom-width: 3px; border-left-width: 3px; border-right-color: #ffcea0; border-bottom-color: #ffcea0; border-left-color: #ffcea0;\">                                <tr>                                    <td colspan=\"2\"                                         style=\"padding: 5px; text-align: center; height: 136px; width: 136px;\" class=\"style3\">                                        " +
                        "<img alt=\"\" src=\"1.png\" /></td>                                </tr>                                <tr>                                    <td style=\"padding: 5px; background-color: #663300; text-align: center; color: #FFFFCC;\">                                        " + koliadedikismi1 + "<br />                                        " +
                        koliadedi1 + "</td>                                    <td style=\"padding: 5px; background-color: #ffcea0; width: 94px; text-align: center;\">                                        " +
                        urunaciklama1 + "</td>                                </tr>                                <tr>                                    <td colspan=\"2\" style=\"padding: 5px; text-align: center;\">                                        " +
                        "<img class=\"style4\" src=\"1barkod.png\" /></td>                                </tr>                            </table>                        </td>                        " +
                        "<td align=\"center\">                            <table cellpadding=\"0\" cellspacing=\"0\"                                                                                                                                 style=\"margin: 5px; padding: 0px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: 3px; border-bottom-width: 3px; border-left-width: 3px; border-right-color: #ffcea0; border-bottom-color: #ffcea0; border-left-color: #ffcea0;\">                                <tr>                                    <td colspan=\"2\"                                         style=\"padding: 5px; text-align: center; height: 136px; width: 136px;\" class=\"style3\">                                        " +
                        "<img alt=\"\" src=\"2.png\" /></td>                                </tr>                                <tr>                                    <td style=\"padding: 5px; background-color: #663300; text-align: center; color: #FFFFCC;\">                                        " + koliadedikismi2 + "<br />                                        " +
                        koliadedi2 + "</td>                                    <td style=\"padding: 5px; background-color: #ffcea0; width: 94px; text-align: center;\">                                        " +
                        urunaciklama2 + "</td>                                </tr>                                <tr>                                    <td colspan=\"2\" style=\"padding: 5px; text-align: center;\">                                        " +
                        "<img class=\"style4\" src=\"2barkod.png\" /></td>                                </tr>                            </table>                        </td>                        " +
                        "<td align=\"center\">                            <table cellpadding=\"0\" cellspacing=\"0\"                                                                                                                                 style=\"margin: 5px; padding: 0px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: 3px; border-bottom-width: 3px; border-left-width: 3px; border-right-color: #ffcea0; border-bottom-color: #ffcea0; border-left-color: #ffcea0;\">                                <tr>                                    <td colspan=\"2\"                                         style=\"padding: 5px; text-align: center; height: 136px; width: 136px;\" class=\"style3\">                                        " +
                        "<img alt=\"\" src=\"3.png\" /></td>                                </tr>                                <tr>                                    <td style=\"padding: 5px; background-color: #663300; text-align: center; color: #FFFFCC;\">                                        " + koliadedikismi3 + "<br />                                        " +
                        koliadedi3 + "</td>                                    <td style=\"padding: 5px; background-color: #ffcea0; width: 94px; text-align: center;\">                                        " +
                        urunaciklama3 + "</td>                                </tr>                                <tr>                                    <td colspan=\"2\" style=\"padding: 5px; text-align: center;\">                                        " +
                        "<img class=\"style4\" src=\"3barkod.png\" /></td>                                </tr>                            </table>                        </td>                    </tr>                    " +
                        "<tr>                        <td align=\"center\">                            <table cellpadding=\"0\" cellspacing=\"0\"                                                                                                                                 style=\"margin: 5px; padding: 0px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: 3px; border-bottom-width: 3px; border-left-width: 3px; border-right-color: #ffcea0; border-bottom-color: #ffcea0; border-left-color: #ffcea0;\">                                <tr>                                    <td colspan=\"2\"                                         style=\"padding: 5px; text-align: center; height: 136px; width: 136px;\" class=\"style3\">                                        " +
                        "<img alt=\"\" src=\"4.png\" /></td>                                </tr>                                <tr>                                    <td style=\"padding: 5px; background-color: #663300; text-align: center; color: #FFFFCC;\">                                        " + koliadedikismi4 + "<br />                                        " +
                        koliadedi4 + "</td>                                    <td style=\"padding: 5px; background-color: #ffcea0; width: 94px; text-align: center;\">                                        " +
                        urunaciklama4 + "</td>                                </tr>                                <tr>                                    <td colspan=\"2\" style=\"padding: 5px; text-align: center;\">                                        " +
                        "<img class=\"style4\" src=\"4barkod.png\" /></td>                                </tr>                            </table>                        </td>                        " +
                        "<td align=\"center\">                            <table cellpadding=\"0\" cellspacing=\"0\"                                                                                                                                 style=\"margin: 5px; padding: 0px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: 3px; border-bottom-width: 3px; border-left-width: 3px; border-right-color: #ffcea0; border-bottom-color: #ffcea0; border-left-color: #ffcea0;\">                                <tr>                                    <td colspan=\"2\"                                         style=\"padding: 5px; text-align: center; height: 136px; width: 136px;\" class=\"style3\">                                        " +
                        "<img alt=\"\" src=\"5.png\" /></td>                                </tr>                                <tr>                                    <td style=\"padding: 5px; background-color: #663300; text-align: center; color: #FFFFCC;\">                                        " + koliadedikismi5 + "<br />                                        " +
                        koliadedi5 + "</td>                                    <td style=\"padding: 5px; background-color: #ffcea0; width: 94px; text-align: center;\">                                        " +
                        urunaciklama5 + "</td>                                </tr>                                <tr>                                    <td colspan=\"2\" style=\"padding: 5px; text-align: center;\">                                        " +
                        "<img class=\"style4\" src=\"5barkod.png\" /></td>                                </tr>                            </table>                        </td>                        " +
                        "<td align=\"center\">                            <table cellpadding=\"0\" cellspacing=\"0\"                                                                                                                                 style=\"margin: 5px; padding: 0px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: 3px; border-bottom-width: 3px; border-left-width: 3px; border-right-color: #ffcea0; border-bottom-color: #ffcea0; border-left-color: #ffcea0;\">                                <tr>                                    <td colspan=\"2\"                                         style=\"padding: 5px; text-align: center; height: 136px; width: 136px;\" class=\"style3\">                                        " +
                        "<img alt=\"\" src=\"6.png\" /></td>                                </tr>                                <tr>                                    <td style=\"padding: 5px; background-color: #663300; text-align: center; color: #FFFFCC;\">                                        " + koliadedikismi6 + "<br />                                        " +
                        koliadedi6 + "</td>                                    <td style=\"padding: 5px; background-color: #ffcea0; width: 94px; text-align: center;\">                                        " +
                        urunaciklama6 + "</td>                                </tr>                                <tr>                                    <td colspan=\"2\" style=\"padding: 5px; text-align: center;\">                                        " +
                        "<img class=\"style4\" src=\"6barkod.png\" /></td>                                </tr>                            </table>                        </td>                    </tr>                    " +
                        "<tr>                        <td align=\"center\">                            <table cellpadding=\"0\" cellspacing=\"0\"                                                                                                                                 style=\"margin: 5px; padding: 0px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: 3px; border-bottom-width: 3px; border-left-width: 3px; border-right-color: #ffcea0; border-bottom-color: #ffcea0; border-left-color: #ffcea0;\">                                <tr>                                    <td colspan=\"2\"                                         style=\"padding: 5px; text-align: center; height: 136px; width: 136px;\" class=\"style3\">                                        " +
                        "<img alt=\"\" src=\"7.png\" /></td>                                </tr>                                <tr>                                    <td style=\"padding: 5px; background-color: #663300; text-align: center; color: #FFFFCC;\">                                        " + koliadedikismi7 + "<br />                                        " +
                        koliadedi7 + "</td>                                    <td style=\"padding: 5px; background-color: #ffcea0; width: 94px; text-align: center;\">                                        " +
                        urunaciklama7 + "</td>                                </tr>                                <tr>                                    <td colspan=\"2\" style=\"padding: 5px; text-align: center;\">                                        " +
                        "<img class=\"style4\" src=\"7barkod.png\" /></td>                                </tr>                            </table>                        </td>                        " +
                        "<td align=\"center\">                            <table cellpadding=\"0\" cellspacing=\"0\"                                                                                                                                 style=\"margin: 5px; padding: 0px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: 3px; border-bottom-width: 3px; border-left-width: 3px; border-right-color: #ffcea0; border-bottom-color: #ffcea0; border-left-color: #ffcea0;\">                                <tr>                                    <td colspan=\"2\"                                         style=\"padding: 5px; text-align: center; height: 136px; width: 136px;\" class=\"style3\">                                        " +
                        "<img alt=\"\" src=\"8.png\" /></td>                                </tr>                                <tr>                                    <td style=\"padding: 5px; background-color: #663300; text-align: center; color: #FFFFCC;\">                                        " + koliadedikismi8 + "<br />                                        " +
                        koliadedi8 + "</td>                                    <td style=\"padding: 5px; background-color: #ffcea0; width: 94px; text-align: center;\">                                        " +
                        urunaciklama8 + "</td>                                </tr>                                <tr>                                    <td colspan=\"2\" style=\"padding: 5px; text-align: center;\">                                        " +
                        "<img class=\"style4\" src=\"8barkod.png\" /></td>                                </tr>                            </table>                        </td>                        " +
                        "<td align=\"center\">                            <table cellpadding=\"0\" cellspacing=\"0\"                                                                                                                                 style=\"margin: 5px; padding: 0px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: 3px; border-bottom-width: 3px; border-left-width: 3px; border-right-color: #ffcea0; border-bottom-color: #ffcea0; border-left-color: #ffcea0;\">                                <tr>                                    <td colspan=\"2\"                                         style=\"padding: 5px; text-align: center; height: 136px; width: 136px;\" class=\"style3\">                                        " +
                        "<img alt=\"\" src=\"9.png\" /></td>                                </tr>                                <tr>                                    <td style=\"padding: 5px; background-color: #663300; text-align: center; color: #FFFFCC;\">                                        " + koliadedikismi9 + "<br />                                        " +
                        koliadedi9 + "</td>                                    <td style=\"padding: 5px; background-color: #ffcea0; width: 94px; text-align: center;\">                                        " +
                        urunaciklama9 + "</td>                                </tr>                                <tr>                                    <td colspan=\"2\" style=\"padding: 5px; text-align: center;\">                                        " +
                        "<img class=\"style4\" src=\"9barkod.png\" /></td>                                </tr>                            </table>                        </td>                    </tr>                    " +
                        "<tr>                        <td align=\"center\">                            <table cellpadding=\"0\" cellspacing=\"0\"                                                                                                                                 style=\"margin: 5px; padding: 0px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: 3px; border-bottom-width: 3px; border-left-width: 3px; border-right-color: #ffcea0; border-bottom-color: #ffcea0; border-left-color: #ffcea0;\">                                <tr>                                    <td colspan=\"2\"                                         style=\"padding: 5px; text-align: center; height: 136px; width: 136px;\" class=\"style3\">                                        " +
                        "<img alt=\"\" src=\"10.png\" /></td>                                </tr>                                <tr>                                    <td style=\"padding: 5px; background-color: #663300; text-align: center; color: #FFFFCC;\">                                        " + koliadedikismi10 + "<br />                                        " +
                        koliadedi10 + "</td>                                    <td style=\"padding: 5px; background-color: #ffcea0; width: 94px; text-align: center;\">                                        " +
                        urunaciklama10 + "</td>                                </tr>                                <tr>                                    <td colspan=\"2\" style=\"padding: 5px; text-align: center;\">                                        " +
                        "<img class=\"style4\" src=\"10barkod.png\" /></td>                                </tr>                            </table>                        </td>                        " +
                        "<td align=\"center\">                            <table cellpadding=\"0\" cellspacing=\"0\"                                                                                                                                 style=\"margin: 5px; padding: 0px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: 3px; border-bottom-width: 3px; border-left-width: 3px; border-right-color: #ffcea0; border-bottom-color: #ffcea0; border-left-color: #ffcea0;\">                                <tr>                                    <td colspan=\"2\"                                         style=\"padding: 5px; text-align: center; height: 136px; width: 136px;\" class=\"style3\">                                        " +
                        "<img alt=\"\" src=\"11.png\" /></td>                                </tr>                                <tr>                                    <td style=\"padding: 5px; background-color: #663300; text-align: center; color: #FFFFCC;\">                                        " + koliadedikismi11 + "<br />                                        " +
                        koliadedi11 + "</td>                                    <td style=\"padding: 5px; background-color: #ffcea0; width: 94px; text-align: center;\">                                        " +
                        urunaciklama11 + "</td>                                </tr>                                <tr>                                    <td colspan=\"2\" style=\"padding: 5px; text-align: center;\">                                        " +
                        "<img class=\"style4\" src=\"11barkod.png\" /></td>                                </tr>                            </table>                        </td>                        " +
                        "<td align=\"center\">                            <table cellpadding=\"0\" cellspacing=\"0\"                                                                                                                                 style=\"margin: 5px; padding: 0px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: 3px; border-bottom-width: 3px; border-left-width: 3px; border-right-color: #ffcea0; border-bottom-color: #ffcea0; border-left-color: #ffcea0;\">                                <tr>                                    <td colspan=\"2\"                                         style=\"padding: 5px; text-align: center; height: 136px; width: 136px;\" class=\"style3\">                                        " +
                        "<img alt=\"\" src=\"12.png\" /></td>                                </tr>                                <tr>                                    <td style=\"padding: 5px; background-color: #663300; text-align: center; color: #FFFFCC;\">                                        " + koliadedikismi12 + "<br />                                        " +
                        koliadedi12 + "</td>                                    <td style=\"padding: 5px; background-color: #ffcea0; width: 94px; text-align: center;\">                                        " +
                        urunaciklama12 + "</td>                                </tr>                                <tr>                                    <td colspan=\"2\" style=\"padding: 5px; text-align: center;\">                                        " +
                        "<img class=\"style4\" src=\"12barkod.png\" /></td>                                </tr>                            </table>                        </td>                    </tr>                </table>            </td>        </tr>        <tr>            <td style=\"background-image: url(footer-bg.png); height: 60px; padding: 0px 10px 20px 120px\">            <table style=\"margin-top: 5px\"><tr><td style=\"padding-right: 10px\"><span style=\"font-size: 14px\">                Dağıtım </span></td>            <td style=\"border-left-style: solid; border-left-color: #ffcea0; border-left-width: 1px;\">            <img class=\"style2\" src=\"1_sultanlar_logo.png\" style=\"padding: 3px 3px 3px 10px;\" /></td>            <td style=\"padding-left: 10px\">                <span style=\"font-size: 10px\"><i>Eyüp Sultan mh. Sekmen cd. No: 14 Sancaktepe / İSTANBUL</i><br /><i>Telefon: (+90 216) 561 50 00 Pbx</i><br /><i>Eposta: satis@sultanlar.com.tr</i></span></td></tr></table></td>        </tr>    </table></body></html>";

                // brosuru yaz
                if (File.Exists(txtCiktiYolu.Text + "\\Brosur.htm"))
                {
                    File.Delete(txtCiktiYolu.Text + "\\Brosur.htm");
                }
                StreamWriter sw = new StreamWriter(txtCiktiYolu.Text + "\\Brosur.htm", false, Encoding.Unicode);
                sw.Write(brosur);
                sw.Close();
                sw.Dispose();

                if (!cbKaynaktakiDosyalariSilme.Checked)
                    KaynaktakiDosyalariSil();

                webBrowser1.Navigate(txtCiktiYolu.Text + "\\Brosur.htm");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Dokuzlu()
        {
            try
            {
                Directory.CreateDirectory(txtCiktiYolu.Text);

                string bilgi1 = string.Empty, koliadedikismi1 = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />", koliadedi1 = string.Empty, urunaciklama1 = string.Empty,
                         bilgi2 = string.Empty, koliadedikismi2 = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />", koliadedi2 = string.Empty, urunaciklama2 = string.Empty,
                         bilgi3 = string.Empty, koliadedikismi3 = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />", koliadedi3 = string.Empty, urunaciklama3 = string.Empty,
                         bilgi4 = string.Empty, koliadedikismi4 = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />", koliadedi4 = string.Empty, urunaciklama4 = string.Empty,
                         bilgi5 = string.Empty, koliadedikismi5 = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />", koliadedi5 = string.Empty, urunaciklama5 = string.Empty,
                         bilgi6 = string.Empty, koliadedikismi6 = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />", koliadedi6 = string.Empty, urunaciklama6 = string.Empty,
                         bilgi7 = string.Empty, koliadedikismi7 = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />", koliadedi7 = string.Empty, urunaciklama7 = string.Empty,
                         bilgi8 = string.Empty, koliadedikismi8 = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />", koliadedi8 = string.Empty, urunaciklama8 = string.Empty,
                         bilgi9 = string.Empty, koliadedikismi9 = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />", koliadedi9 = string.Empty, urunaciklama9 = string.Empty;

                // tablo gerekli resimleri
                File.Copy("https://www.sultanlar.com.tr/sultanlarui/brosur/1_sultanlar_logo.png", txtCiktiYolu.Text + "\\1_sultanlar_logo.png", true);
                File.Copy("https://www.sultanlar.com.tr/sultanlarui/brosur/header-bg.png", txtCiktiYolu.Text + "\\header-bg.png", true);
                File.Copy("https://www.sultanlar.com.tr/sultanlarui/brosur/footer-bg.png", txtCiktiYolu.Text + "\\footer-bg.png", true);

                // şablon logosu
                if (File.Exists(txtDosyaYolu.Text + "\\logo.png"))
                {
                    File.Copy(txtDosyaYolu.Text + "\\logo.png", txtCiktiYolu.Text + "\\logo.png", true);
                }
                else
                {
                    File.Copy("https://www.sultanlar.com.tr/sultanlarui/brosur/1_sultanlar_logo.png", txtCiktiYolu.Text + "\\logo.png", true);
                }

                // urun resimleri ve barkodlari
                for (int i = 1; i <= 9; i++)
                {
                    //resim
                    if (File.Exists(txtDosyaYolu.Text + "\\" + i.ToString() + ".png") || File.Exists(txtDosyaYolu.Text + "\\" + i.ToString() + ".jpg"))
                    {
                        Image img = File.Exists(txtDosyaYolu.Text + "\\" + i.ToString() + ".png") ? Image.FromFile(txtDosyaYolu.Text + "\\" + i.ToString() + ".png") : Image.FromFile(txtDosyaYolu.Text + "\\" + i.ToString() + ".jpg");
                        Image kucukimg;
                        if (img.Height > img.Width)
                        {
                            double aspectRatio = Convert.ToDouble(img.Height) / img.Width;
                            double yukseklik = 180;
                            double genislik = yukseklik / aspectRatio;
                            kucukimg = Resim.ResimKucult(img, Convert.ToInt32(genislik));
                        }
                        else
                        {
                            kucukimg = Resim.ResimKucult(img, 180);
                        }
                        kucukimg.Save(txtCiktiYolu.Text + "\\" + i.ToString() + ".png");
                    }
                    else
                    {
                        File.Copy("https://www.sultanlar.com.tr/sultanlarui/brosur/bos.png", txtCiktiYolu.Text + "\\" + i.ToString() + ".png", true);
                    }

                    // barkod
                    if (File.Exists(txtDosyaYolu.Text + "\\" + i.ToString() + "barkod.png"))
                    {
                        File.Copy(txtDosyaYolu.Text + "\\" + i.ToString() + "barkod.png", txtCiktiYolu.Text + "\\" + i.ToString() + "barkod.png", true);
                    }
                    else
                    {
                        File.Copy("https://www.sultanlar.com.tr/sultanlarui/brosur/bos.png", txtCiktiYolu.Text + "\\" + i.ToString() + "barkod.png", true);
                    }
                }

                // urun aciklamalari
                if (File.Exists(txtDosyaYolu.Text + "\\1.txt"))
                {
                    bilgi1 = File.ReadAllText(txtDosyaYolu.Text + "\\1.txt", Encoding.GetEncoding("iso-8859-9")).ToUpper();
                    koliadedikismi1 = koliadedi;
                    koliadedi1 = bilgi1.Substring(0, bilgi1.IndexOf("\r\n"));
                    urunaciklama1 = bilgi1.Substring(bilgi1.IndexOf("\r\n") + 1);
                }
                if (File.Exists(txtDosyaYolu.Text + "\\2.txt"))
                {
                    bilgi2 = File.ReadAllText(txtDosyaYolu.Text + "\\2.txt", Encoding.GetEncoding("iso-8859-9")).ToUpper();
                    koliadedikismi2 = koliadedi;
                    koliadedi2 = bilgi2.Substring(0, bilgi2.IndexOf("\r\n"));
                    urunaciklama2 = bilgi2.Substring(bilgi2.IndexOf("\r\n") + 1);
                }
                if (File.Exists(txtDosyaYolu.Text + "\\3.txt"))
                {
                    bilgi3 = File.ReadAllText(txtDosyaYolu.Text + "\\3.txt", Encoding.GetEncoding("iso-8859-9")).ToUpper();
                    koliadedikismi3 = koliadedi;
                    koliadedi3 = bilgi3.Substring(0, bilgi3.IndexOf("\r\n"));
                    urunaciklama3 = bilgi3.Substring(bilgi3.IndexOf("\r\n") + 1);
                }
                if (File.Exists(txtDosyaYolu.Text + "\\4.txt"))
                {
                    bilgi4 = File.ReadAllText(txtDosyaYolu.Text + "\\4.txt", Encoding.GetEncoding("iso-8859-9")).ToUpper();
                    koliadedikismi4 = koliadedi;
                    koliadedi4 = bilgi4.Substring(0, bilgi4.IndexOf("\r\n"));
                    urunaciklama4 = bilgi4.Substring(bilgi4.IndexOf("\r\n") + 1);
                }
                if (File.Exists(txtDosyaYolu.Text + "\\5.txt"))
                {
                    bilgi5 = File.ReadAllText(txtDosyaYolu.Text + "\\5.txt", Encoding.GetEncoding("iso-8859-9")).ToUpper();
                    koliadedikismi5 = koliadedi;
                    koliadedi5 = bilgi5.Substring(0, bilgi5.IndexOf("\r\n"));
                    urunaciklama5 = bilgi5.Substring(bilgi5.IndexOf("\r\n") + 1);
                }
                if (File.Exists(txtDosyaYolu.Text + "\\6.txt"))
                {
                    bilgi6 = File.ReadAllText(txtDosyaYolu.Text + "\\6.txt", Encoding.GetEncoding("iso-8859-9")).ToUpper();
                    koliadedikismi6 = koliadedi;
                    koliadedi6 = bilgi6.Substring(0, bilgi6.IndexOf("\r\n"));
                    urunaciklama6 = bilgi6.Substring(bilgi6.IndexOf("\r\n") + 1);
                }
                if (File.Exists(txtDosyaYolu.Text + "\\7.txt"))
                {
                    bilgi7 = File.ReadAllText(txtDosyaYolu.Text + "\\7.txt", Encoding.GetEncoding("iso-8859-9")).ToUpper();
                    koliadedikismi7 = koliadedi;
                    koliadedi7 = bilgi7.Substring(0, bilgi7.IndexOf("\r\n"));
                    urunaciklama7 = bilgi7.Substring(bilgi7.IndexOf("\r\n") + 1);
                }
                if (File.Exists(txtDosyaYolu.Text + "\\8.txt"))
                {
                    bilgi8 = File.ReadAllText(txtDosyaYolu.Text + "\\8.txt", Encoding.GetEncoding("iso-8859-9")).ToUpper();
                    koliadedikismi8 = koliadedi;
                    koliadedi8 = bilgi8.Substring(0, bilgi8.IndexOf("\r\n"));
                    urunaciklama8 = bilgi8.Substring(bilgi8.IndexOf("\r\n") + 1);
                }
                if (File.Exists(txtDosyaYolu.Text + "\\9.txt"))
                {
                    bilgi9 = File.ReadAllText(txtDosyaYolu.Text + "\\9.txt", Encoding.GetEncoding("iso-8859-9")).ToUpper();
                    koliadedikismi9 = koliadedi;
                    koliadedi9 = bilgi9.Substring(0, bilgi9.IndexOf("\r\n"));
                    urunaciklama9 = bilgi9.Substring(bilgi9.IndexOf("\r\n") + 1);
                }

                // brosuru olustur
                string brosur = "<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\"><html xmlns=\"http://www.w3.org/1999/xhtml\" ><head>    <title>Untitled Page</title>    <style type=\"text/css\">        .style1 {            width: 730px;            height: 929px;            font-family: Tahoma;            font-size: 9px;            font-weight: normal;        }        .style2        {            width: 138px;            height: 43px;        }        .style3        { background-color: " + txtRenk.Text + "; } .style4        {            width: 120px;            height: 55px;        }        </style></head><body style=\"margin: 0px 0px 0px 10px\">    <table cellpadding=\"0\" cellspacing=\"0\" class=\"style1\"         style=\"border: 1px solid #ffcea0\">        <tr>            <td style=\"background-image: url(header-bg.png); height: 60px; padding: 10px 10px 0px 100px\">            " +
                        "<img src=\"logo.png\"                     style=\"padding: 10px 3px 3px 10px; height: 48px;\" /></td>        </tr>        <tr>            <td>                <table cellpadding=\"0\" cellspacing=\"0\" class=\"style1\">                    <tr>                        <td align=\"center\">                            <table cellpadding=\"0\" cellspacing=\"0\"                                                                                                 style=\"margin: 5px; padding: 0px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: 3px; border-bottom-width: 3px; border-left-width: 3px; border-right-color: #ffcea0; border-bottom-color: #ffcea0; border-left-color: #ffcea0;\">                                <tr>                                    <td colspan=\"2\"                                         style=\"padding: 5px; text-align: center; width: 190px; height: 190px;\" class=\"style3\">                                        " +
                        "<img alt=\"\" src=\"1.png\" /></td>                                </tr>                                <tr>                                    <td style=\"padding: 5px; background-color: #663300; text-align: center; color: #FFFFCC;\">                                        " + koliadedikismi1 + "<br />                                        " +
                        koliadedi1 + "</td>                                    <td style=\"padding: 5px; background-color: #ffcea0; width: 130px; text-align: center;\">                                        " +
                        urunaciklama1 + "</td>                                </tr>                                <tr>                                    <td colspan=\"2\" style=\"padding: 5px; text-align: center;\">                                        " +
                        "<img class=\"style4\" src=\"1barkod.png\" /></td>                                </tr>                            </table>                        </td>                        " +
                        "<td align=\"center\">                            <table cellpadding=\"0\" cellspacing=\"0\"                                                                                                                                 style=\"margin: 5px; padding: 0px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: 3px; border-bottom-width: 3px; border-left-width: 3px; border-right-color: #ffcea0; border-bottom-color: #ffcea0; border-left-color: #ffcea0;\">                                <tr>                                    <td colspan=\"2\"                                         style=\"padding: 5px; text-align: center; width: 190px; height: 190px;\" class=\"style3\">                                        " +
                        "<img alt=\"\" src=\"2.png\" /></td>                                </tr>                                <tr>                                    <td style=\"padding: 5px; background-color: #663300; text-align: center; color: #FFFFCC;\">                                        " + koliadedikismi2 + "<br />                                        " +
                        koliadedi2 + "</td>                                    <td style=\"padding: 5px; background-color: #ffcea0; width: 130px; text-align: center;\">                                        " +
                        urunaciklama2 + "</td>                                </tr>                                <tr>                                    <td colspan=\"2\" style=\"padding: 5px; text-align: center;\">                                        " +
                        "<img class=\"style4\" src=\"2barkod.png\" /></td>                                </tr>                            </table>                        </td>                        " +
                        "<td align=\"center\">                            <table cellpadding=\"0\" cellspacing=\"0\"                                                                                                                                 style=\"margin: 5px; padding: 0px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: 3px; border-bottom-width: 3px; border-left-width: 3px; border-right-color: #ffcea0; border-bottom-color: #ffcea0; border-left-color: #ffcea0;\">                                <tr>                                    <td colspan=\"2\"                                         style=\"padding: 5px; text-align: center; width: 190px; height: 190px;\" class=\"style3\">                                        " +
                        "<img alt=\"\" src=\"3.png\" /></td>                                </tr>                                <tr>                                    <td style=\"padding: 5px; background-color: #663300; text-align: center; color: #FFFFCC; \">                                        " + koliadedikismi3 + "<br />                                        " +
                        koliadedi3 + "</td>                                    <td style=\"padding: 5px; background-color: #ffcea0; text-align: center; width: 130px;\">                                        " +
                        urunaciklama3 + "</td>                                </tr>                                <tr>                                    <td colspan=\"2\" style=\"padding: 5px; text-align: center;\">                                        " +
                        "<img class=\"style4\" src=\"3barkod.png\" /></td>                                </tr>                            </table>                        </td>                    </tr>                    " +
                        "<tr>                        <td align=\"center\">                            <table cellpadding=\"0\" cellspacing=\"0\"                                                                                                                                 style=\"margin: 5px; padding: 0px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: 3px; border-bottom-width: 3px; border-left-width: 3px; border-right-color: #ffcea0; border-bottom-color: #ffcea0; border-left-color: #ffcea0;\">                                <tr>                                    <td colspan=\"2\"                                         style=\"padding: 5px; text-align: center; width: 190px; height: 190px;\" class=\"style3\">                                        " +
                        "<img alt=\"\" src=\"4.png\" /></td>                                </tr>                                <tr>                                    <td style=\"padding: 5px; background-color: #663300; text-align: center; color: #FFFFCC;\">                                        " + koliadedikismi4 + "<br />                                        " +
                        koliadedi4 + "</td>                                    <td style=\"padding: 5px; background-color: #ffcea0; width: 130px; text-align: center;\">                                        " +
                        urunaciklama4 + "</td>                                </tr>                                <tr>                                    <td colspan=\"2\" style=\"padding: 5px; text-align: center;\">                                        " +
                        "<img class=\"style4\" src=\"4barkod.png\" /></td>                                </tr>                            </table>                        </td>                        " +
                        "<td align=\"center\">                            <table cellpadding=\"0\" cellspacing=\"0\"                                                                                                                                 style=\"margin: 5px; padding: 0px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: 3px; border-bottom-width: 3px; border-left-width: 3px; border-right-color: #ffcea0; border-bottom-color: #ffcea0; border-left-color: #ffcea0;\">                                <tr>                                    <td colspan=\"2\"                                         style=\"padding: 5px; text-align: center; width: 190px; height: 190px;\" class=\"style3\">                                        " +
                        "<img alt=\"\" src=\"5.png\" /></td>                                </tr>                                <tr>                                    <td style=\"padding: 5px; background-color: #663300; text-align: center; color: #FFFFCC;\">                                        " + koliadedikismi5 + "<br />                                        " +
                        koliadedi5 + "</td>                                    <td style=\"padding: 5px; background-color: #ffcea0; width: 130px; text-align: center;\">                                        " +
                        urunaciklama5 + "</td>                                </tr>                                <tr>                                    <td colspan=\"2\" style=\"padding: 5px; text-align: center;\">                                        " +
                        "<img class=\"style4\" src=\"5barkod.png\" /></td>                                </tr>                            </table>                        </td>                        " +
                        "<td align=\"center\">                            <table cellpadding=\"0\" cellspacing=\"0\"                                                                                                                                 style=\"margin: 5px; padding: 0px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: 3px; border-bottom-width: 3px; border-left-width: 3px; border-right-color: #ffcea0; border-bottom-color: #ffcea0; border-left-color: #ffcea0;\">                                <tr>                                    <td colspan=\"2\"                                         style=\"padding: 5px; text-align: center; width: 190px; height: 190px;\" class=\"style3\">                                        " +
                        "<img alt=\"\" src=\"6.png\" /></td>                                </tr>                                <tr>                                    <td style=\"padding: 5px; background-color: #663300; text-align: center; color: #FFFFCC; \">                                        " + koliadedikismi6 + "<br />                                        " +
                        koliadedi6 + "</td>                                    <td style=\"padding: 5px; background-color: #ffcea0; text-align: center; width: 130px;\">                                        " +
                        urunaciklama6 + "</td>                                </tr>                                <tr>                                    <td colspan=\"2\" style=\"padding: 5px; text-align: center;\">                                        " +
                        "<img class=\"style4\" src=\"6barkod.png\" /></td>                                </tr>                            </table>                        </td>                    </tr>                    " +
                        "<tr>                        <td align=\"center\">                            <table cellpadding=\"0\" cellspacing=\"0\"                                                                                                                                 style=\"margin: 5px; padding: 0px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: 3px; border-bottom-width: 3px; border-left-width: 3px; border-right-color: #ffcea0; border-bottom-color: #ffcea0; border-left-color: #ffcea0;\">                                <tr>                                    <td colspan=\"2\"                                         style=\"padding: 5px; text-align: center; width: 190px; height: 190px;\" class=\"style3\">                                        " +
                        "<img alt=\"\" src=\"7.png\" /></td>                                </tr>                                <tr>                                    <td style=\"padding: 5px; background-color: #663300; text-align: center; color: #FFFFCC;\">                                        " + koliadedikismi7 + "<br />                                        " +
                        koliadedi7 + "</td>                                    <td style=\"padding: 5px; background-color: #ffcea0; width: 130px; text-align: center;\">                                        " +
                        urunaciklama7 + "</td>                                </tr>                                <tr>                                    <td colspan=\"2\" style=\"padding: 5px; text-align: center;\">                                        " +
                        "<img class=\"style4\" src=\"7barkod.png\" /></td>                                </tr>                            </table>                        </td>                        " +
                        "<td align=\"center\">                            <table cellpadding=\"0\" cellspacing=\"0\"                                                                                                                                 style=\"margin: 5px; padding: 0px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: 3px; border-bottom-width: 3px; border-left-width: 3px; border-right-color: #ffcea0; border-bottom-color: #ffcea0; border-left-color: #ffcea0;\">                                <tr>                                    <td colspan=\"2\"                                         style=\"padding: 5px; text-align: center; width: 190px; height: 190px;\" class=\"style3\">                                        " +
                        "<img alt=\"\" src=\"8.png\" /></td>                                </tr>                                <tr>                                    <td style=\"padding: 5px; background-color: #663300; text-align: center; color: #FFFFCC;\">                                        " + koliadedikismi8 + "<br />                                        " +
                        koliadedi8 + "</td>                                    <td style=\"padding: 5px; background-color: #ffcea0; width: 130px; text-align: center;\">                                        " +
                        urunaciklama8 + "</td>                                </tr>                                <tr>                                    <td colspan=\"2\" style=\"padding: 5px; text-align: center;\">                                        " +
                        "<img class=\"style4\" src=\"8barkod.png\" /></td>                                </tr>                            </table>                        </td>                        " +
                        "<td align=\"center\">                            <table cellpadding=\"0\" cellspacing=\"0\"                                                                                                                                 style=\"margin: 5px; padding: 0px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: 3px; border-bottom-width: 3px; border-left-width: 3px; border-right-color: #ffcea0; border-bottom-color: #ffcea0; border-left-color: #ffcea0;\">                                <tr>                                    <td colspan=\"2\"                                         style=\"padding: 5px; text-align: center; width: 190px; height: 190px;\" class=\"style3\">                                        " +
                        "<img alt=\"\" src=\"9.png\" /></td>                                </tr>                                <tr>                                    <td style=\"padding: 5px; background-color: #663300; text-align: center; color: #FFFFCC; \">                                        " + koliadedikismi9 + "<br />                                        " +
                        koliadedi9 + "</td>                                    <td style=\"padding: 5px; background-color: #ffcea0; text-align: center; width: 130px;\">                                        " +
                        urunaciklama9 + "</td>                                </tr>                                <tr>                                    <td colspan=\"2\" style=\"padding: 5px; text-align: center;\">                                        " +
                        "<img class=\"style4\" src=\"9barkod.png\" /></td>                                </tr>                            </table>                        </td>                    </tr>                </table>            </td>        </tr>        <tr>            <td style=\"background-image: url(footer-bg.png); height: 60px; padding: 0px 10px 20px 120px\">            <table style=\"margin-top: 5px\"><tr><td style=\"padding-right: 10px\"><span style=\"font-size: 14px\">                Dağıtım </span></td>            <td style=\"border-left-style: solid; border-left-color: #ffcea0; border-left-width: 1px;\">            <img class=\"style2\" src=\"1_sultanlar_logo.png\" style=\"padding: 3px 3px 3px 10px;\" /></td>            <td style=\"padding-left: 10px\">                <span style=\"font-size: 10px\"><i>Eyüp Sultan mh. Sekmen cd. No: 14 Sancaktepe / İSTANBUL</i><br /><i>Telefon: (+90 216) 561 50 00 Pbx</i><br /><i>Eposta: satis@sultanlar.com.tr</i></span></td></tr></table></td>        </tr>    </table></body></html>";

                // brosuru yaz
                if (File.Exists(txtCiktiYolu.Text + "\\Brosur.htm"))
                {
                    File.Delete(txtCiktiYolu.Text + "\\Brosur.htm");
                }
                StreamWriter sw = new StreamWriter(txtCiktiYolu.Text + "\\Brosur.htm", false, Encoding.Unicode);
                sw.Write(brosur);
                sw.Close();
                sw.Dispose();

                if (!cbKaynaktakiDosyalariSilme.Checked)
                    KaynaktakiDosyalariSil();

                webBrowser1.Navigate(txtCiktiYolu.Text + "\\Brosur.htm");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Altili()
        {
            try
            {
                Directory.CreateDirectory(txtCiktiYolu.Text);

                string bilgi1 = string.Empty, koliadedikismi1 = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />", koliadedi1 = string.Empty, urunaciklama1 = string.Empty,
                         bilgi2 = string.Empty, koliadedikismi2 = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />", koliadedi2 = string.Empty, urunaciklama2 = string.Empty,
                         bilgi3 = string.Empty, koliadedikismi3 = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />", koliadedi3 = string.Empty, urunaciklama3 = string.Empty,
                         bilgi4 = string.Empty, koliadedikismi4 = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />", koliadedi4 = string.Empty, urunaciklama4 = string.Empty,
                         bilgi5 = string.Empty, koliadedikismi5 = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />", koliadedi5 = string.Empty, urunaciklama5 = string.Empty,
                         bilgi6 = string.Empty, koliadedikismi6 = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />", koliadedi6 = string.Empty, urunaciklama6 = string.Empty;

                // tablo gerekli resimleri
                File.Copy("https://www.sultanlar.com.tr/sultanlarui/brosur/1_sultanlar_logo.png", txtCiktiYolu.Text + "\\1_sultanlar_logo.png", true);
                File.Copy("https://www.sultanlar.com.tr/sultanlarui/brosur/header-bg.png", txtCiktiYolu.Text + "\\header-bg.png", true);
                File.Copy("https://www.sultanlar.com.tr/sultanlarui/brosur/footer-bg.png", txtCiktiYolu.Text + "\\footer-bg.png", true);

                // şablon logosu
                if (File.Exists(txtDosyaYolu.Text + "\\logo.png"))
                {
                    File.Copy(txtDosyaYolu.Text + "\\logo.png", txtCiktiYolu.Text + "\\logo.png", true);
                }
                else
                {
                    File.Copy("https://www.sultanlar.com.tr/sultanlarui/brosur/1_sultanlar_logo.png", txtCiktiYolu.Text + "\\logo.png", true);
                }

                // urun resimleri ve barkodlari
                for (int i = 1; i <= 6; i++)
                {
                    //resim
                    if (File.Exists(txtDosyaYolu.Text + "\\" + i.ToString() + ".png") || File.Exists(txtDosyaYolu.Text + "\\" + i.ToString() + ".jpg"))
                    {
                        Image img = File.Exists(txtDosyaYolu.Text + "\\" + i.ToString() + ".png") ? Image.FromFile(txtDosyaYolu.Text + "\\" + i.ToString() + ".png") : Image.FromFile(txtDosyaYolu.Text + "\\" + i.ToString() + ".jpg");
                        Image kucukimg;
                        if (img.Height > img.Width)
                        {
                            double aspectRatio = Convert.ToDouble(img.Height) / img.Width;
                            double yukseklik = 180;
                            double genislik = yukseklik / aspectRatio;
                            kucukimg = Resim.ResimKucult(img, Convert.ToInt32(genislik));
                        }
                        else
                        {
                            kucukimg = Resim.ResimKucult(img, 180);
                        }
                        kucukimg.Save(txtCiktiYolu.Text + "\\" + i.ToString() + ".png");
                    }
                    else
                    {
                        File.Copy("https://www.sultanlar.com.tr/sultanlarui/brosur/bos.png", txtCiktiYolu.Text + "\\" + i.ToString() + ".png", true);
                    }

                    // barkod
                    if (File.Exists(txtDosyaYolu.Text + "\\" + i.ToString() + "barkod.png"))
                    {
                        File.Copy(txtDosyaYolu.Text + "\\" + i.ToString() + "barkod.png", txtCiktiYolu.Text + "\\" + i.ToString() + "barkod.png", true);
                    }
                    else
                    {
                        File.Copy("https://www.sultanlar.com.tr/sultanlarui/brosur/bos.png", txtCiktiYolu.Text + "\\" + i.ToString() + "barkod.png", true);
                    }
                }

                // urun aciklamalari
                if (File.Exists(txtDosyaYolu.Text + "\\1.txt"))
                {
                    bilgi1 = File.ReadAllText(txtDosyaYolu.Text + "\\1.txt", Encoding.GetEncoding("iso-8859-9")).ToUpper();
                    koliadedikismi1 = koliadedi;
                    koliadedi1 = bilgi1.Substring(0, bilgi1.IndexOf("\r\n"));
                    urunaciklama1 = bilgi1.Substring(bilgi1.IndexOf("\r\n") + 1);
                }
                if (File.Exists(txtDosyaYolu.Text + "\\2.txt"))
                {
                    bilgi2 = File.ReadAllText(txtDosyaYolu.Text + "\\2.txt", Encoding.GetEncoding("iso-8859-9")).ToUpper();
                    koliadedikismi2 = koliadedi;
                    koliadedi2 = bilgi2.Substring(0, bilgi2.IndexOf("\r\n"));
                    urunaciklama2 = bilgi2.Substring(bilgi2.IndexOf("\r\n") + 1);
                }
                if (File.Exists(txtDosyaYolu.Text + "\\3.txt"))
                {
                    bilgi3 = File.ReadAllText(txtDosyaYolu.Text + "\\3.txt", Encoding.GetEncoding("iso-8859-9")).ToUpper();
                    koliadedikismi3 = koliadedi;
                    koliadedi3 = bilgi3.Substring(0, bilgi3.IndexOf("\r\n"));
                    urunaciklama3 = bilgi3.Substring(bilgi3.IndexOf("\r\n") + 1);
                }
                if (File.Exists(txtDosyaYolu.Text + "\\4.txt"))
                {
                    bilgi4 = File.ReadAllText(txtDosyaYolu.Text + "\\4.txt", Encoding.GetEncoding("iso-8859-9")).ToUpper();
                    koliadedikismi4 = koliadedi;
                    koliadedi4 = bilgi4.Substring(0, bilgi4.IndexOf("\r\n"));
                    urunaciklama4 = bilgi4.Substring(bilgi4.IndexOf("\r\n") + 1);
                }
                if (File.Exists(txtDosyaYolu.Text + "\\5.txt"))
                {
                    bilgi5 = File.ReadAllText(txtDosyaYolu.Text + "\\5.txt", Encoding.GetEncoding("iso-8859-9")).ToUpper();
                    koliadedikismi5 = koliadedi;
                    koliadedi5 = bilgi5.Substring(0, bilgi5.IndexOf("\r\n"));
                    urunaciklama5 = bilgi5.Substring(bilgi5.IndexOf("\r\n") + 1);
                }
                if (File.Exists(txtDosyaYolu.Text + "\\6.txt"))
                {
                    bilgi6 = File.ReadAllText(txtDosyaYolu.Text + "\\6.txt", Encoding.GetEncoding("iso-8859-9")).ToUpper();
                    koliadedikismi6 = koliadedi;
                    koliadedi6 = bilgi6.Substring(0, bilgi6.IndexOf("\r\n"));
                    urunaciklama6 = bilgi6.Substring(bilgi6.IndexOf("\r\n") + 1);
                }

                // brosuru olustur
                string brosur = "<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\"><html xmlns=\"http://www.w3.org/1999/xhtml\" ><head>    <title>Untitled Page</title>    <style type=\"text/css\">        .style1 {            width: 730px;            height: 929px;            font-family: Tahoma;            font-size: 9px;            font-weight: normal;        }        .style2        {            width: 138px;            height: 43px;        }        .style3        { background-color: " + txtRenk.Text + "; } .style4        {            width: 120px;            height: 55px;        }        </style></head><body style=\"margin: 0px 0px 0px 10px\">    <table cellpadding=\"0\" cellspacing=\"0\" class=\"style1\"         style=\"border: 1px solid #ffcea0\">        <tr>            <td style=\"background-image: url(header-bg.png); height: 60px; padding: 10px 10px 0px 100px\">            " +
                        "<img src=\"logo.png\"                     style=\"padding: 10px 3px 3px 10px; height: 48px;\" /></td>        </tr>        <tr>            <td>                <table cellpadding=\"0\" cellspacing=\"0\" class=\"style1\">                    <tr>                        <td align=\"center\">                            <table cellpadding=\"0\" cellspacing=\"0\"                                                                                                 style=\"margin: 5px; padding: 0px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: 3px; border-bottom-width: 3px; border-left-width: 3px; border-right-color: #ffcea0; border-bottom-color: #ffcea0; border-left-color: #ffcea0;\">                                <tr>                                    <td colspan=\"2\"                                         style=\"padding: 5px; text-align: center; width: 190px; height: 190px;\" class=\"style3\">                                        " +
                        "<img alt=\"\" src=\"1.png\" /></td>                                </tr>                                <tr>                                    <td style=\"padding: 5px; background-color: #663300; text-align: center; color: #FFFFCC;\">                                        " + koliadedikismi1 + "<br />                                        " +
                        koliadedi1 + "</td>                                    <td style=\"padding: 5px; background-color: #ffcea0; width: 130px; text-align: center;\">                                        " +
                        urunaciklama1 + "</td>                                </tr>                                <tr>                                    <td colspan=\"2\" style=\"padding: 5px; text-align: center;\">                                        " +
                        "<img class=\"style4\" src=\"1barkod.png\" /></td>                                </tr>                            </table>                        </td>                        " +
                        "<td align=\"center\">                            <table cellpadding=\"0\" cellspacing=\"0\"                                                                                                                                 style=\"margin: 5px; padding: 0px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: 3px; border-bottom-width: 3px; border-left-width: 3px; border-right-color: #ffcea0; border-bottom-color: #ffcea0; border-left-color: #ffcea0;\">                                <tr>                                    <td colspan=\"2\"                                         style=\"padding: 5px; text-align: center; width: 190px; height: 190px;\" class=\"style3\">                                        " +
                        "<img alt=\"\" src=\"2.png\" /></td>                                </tr>                                <tr>                                    <td style=\"padding: 5px; background-color: #663300; text-align: center; color: #FFFFCC;\">                                        " + koliadedikismi2 + "<br />                                        " +
                        koliadedi2 + "</td>                                    <td style=\"padding: 5px; background-color: #ffcea0; width: 130px; text-align: center;\">                                        " +
                        urunaciklama2 + "</td>                                </tr>                                <tr>                                    <td colspan=\"2\" style=\"padding: 5px; text-align: center;\">                                        " +
                        "<img class=\"style4\" src=\"2barkod.png\" /></td>                                </tr>                            </table>                        </td>                    </tr>                    " +
                        "<tr>                        <td align=\"center\">                            <table cellpadding=\"0\" cellspacing=\"0\"                                                                                                                                 style=\"margin: 5px; padding: 0px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: 3px; border-bottom-width: 3px; border-left-width: 3px; border-right-color: #ffcea0; border-bottom-color: #ffcea0; border-left-color: #ffcea0;\">                                <tr>                                    <td colspan=\"2\"                                         style=\"padding: 5px; text-align: center; width: 190px; height: 190px;\" class=\"style3\">                                        " +
                        "<img alt=\"\" src=\"3.png\" /></td>                                </tr>                                <tr>                                    <td style=\"padding: 5px; background-color: #663300; text-align: center; color: #FFFFCC;\">                                        " + koliadedikismi3 + "<br />                                        " +
                        koliadedi3 + "</td>                                    <td style=\"padding: 5px; background-color: #ffcea0; width: 130px; text-align: center;\">                                        " +
                        urunaciklama3 + "</td>                                </tr>                                <tr>                                    <td colspan=\"2\" style=\"padding: 5px; text-align: center;\">                                        " +
                        "<img class=\"style4\" src=\"3barkod.png\" /></td>                                </tr>                            </table>                        </td>                        " +
                        "<td align=\"center\">                            <table cellpadding=\"0\" cellspacing=\"0\"                                                                                                                                 style=\"margin: 5px; padding: 0px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: 3px; border-bottom-width: 3px; border-left-width: 3px; border-right-color: #ffcea0; border-bottom-color: #ffcea0; border-left-color: #ffcea0;\">                                <tr>                                    <td colspan=\"2\"                                         style=\"padding: 5px; text-align: center; width: 190px; height: 190px;\" class=\"style3\">                                        " +
                        "<img alt=\"\" src=\"4.png\" /></td>                                </tr>                                <tr>                                    <td style=\"padding: 5px; background-color: #663300; text-align: center; color: #FFFFCC;\">                                        " + koliadedikismi4 + "<br />                                        " +
                        koliadedi4 + "</td>                                    <td style=\"padding: 5px; background-color: #ffcea0; width: 130px; text-align: center;\">                                        " +
                        urunaciklama4 + "</td>                                </tr>                                <tr>                                    <td colspan=\"2\" style=\"padding: 5px; text-align: center;\">                                        " +
                        "<img class=\"style4\" src=\"4barkod.png\" /></td>                                </tr>                            </table>                        </td>                    </tr>                    " +
                        "<tr>                        <td align=\"center\">                            <table cellpadding=\"0\" cellspacing=\"0\"                                                                                                                                 style=\"margin: 5px; padding: 0px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: 3px; border-bottom-width: 3px; border-left-width: 3px; border-right-color: #ffcea0; border-bottom-color: #ffcea0; border-left-color: #ffcea0;\">                                <tr>                                    <td colspan=\"2\"                                         style=\"padding: 5px; text-align: center; width: 190px; height: 190px;\" class=\"style3\">                                        " +
                        "<img alt=\"\" src=\"5.png\" /></td>                                </tr>                                <tr>                                    <td style=\"padding: 5px; background-color: #663300; text-align: center; color: #FFFFCC;\">                                        " + koliadedikismi5 + "<br />                                        " +
                        koliadedi5 + "</td>                                    <td style=\"padding: 5px; background-color: #ffcea0; width: 130px; text-align: center;\">                                        " +
                        urunaciklama5 + "</td>                                </tr>                                <tr>                                    <td colspan=\"2\" style=\"padding: 5px; text-align: center;\">                                        " +
                        "<img class=\"style4\" src=\"5barkod.png\" /></td>                                </tr>                            </table>                        </td>                        " +
                        "<td align=\"center\">                            <table cellpadding=\"0\" cellspacing=\"0\"                                                                                                                                 style=\"margin: 5px; padding: 0px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: 3px; border-bottom-width: 3px; border-left-width: 3px; border-right-color: #ffcea0; border-bottom-color: #ffcea0; border-left-color: #ffcea0;\">                                <tr>                                    <td colspan=\"2\"                                         style=\"padding: 5px; text-align: center; width: 190px; height: 190px;\" class=\"style3\">                                        " +
                        "<img alt=\"\" src=\"6.png\" /></td>                                </tr>                                <tr>                                    <td style=\"padding: 5px; background-color: #663300; text-align: center; color: #FFFFCC;\">                                        " + koliadedikismi6 + "<br />                                        " +
                        koliadedi6 + "</td>                                    <td style=\"padding: 5px; background-color: #ffcea0; width: 130px; text-align: center;\">                                        " +
                        urunaciklama6 + "</td>                                </tr>                                <tr>                                    <td colspan=\"2\" style=\"padding: 5px; text-align: center;\">                                        " +
                        "<img class=\"style4\" src=\"6barkod.png\" /></td>                                </tr>                            </table>                        </td>                    </tr>                </table>            </td>        </tr>        <tr>            <td style=\"background-image: url(footer-bg.png); height: 60px; padding: 0px 10px 20px 120px\">            <table style=\"margin-top: 5px\"><tr><td style=\"padding-right: 10px\"><span style=\"font-size: 14px\">                Dağıtım </span></td>            <td style=\"border-left-style: solid; border-left-color: #ffcea0; border-left-width: 1px;\">            <img class=\"style2\" src=\"1_sultanlar_logo.png\" style=\"padding: 3px 3px 3px 10px;\" /></td>            <td style=\"padding-left: 10px\">                <span style=\"font-size: 10px\"><i>Eyüp Sultan mh. Sekmen cd. No: 14 Sancaktepe / İSTANBUL</i><br /><i>Telefon: (+90 216) 561 50 00 Pbx</i><br /><i>Eposta: satis@sultanlar.com.tr</i></span></td></tr></table></td>        </tr>    </table></body></html>";

                // brosuru yaz
                if (File.Exists(txtCiktiYolu.Text + "\\Brosur.htm"))
                {
                    File.Delete(txtCiktiYolu.Text + "\\Brosur.htm");
                }
                StreamWriter sw = new StreamWriter(txtCiktiYolu.Text + "\\Brosur.htm", false, Encoding.Unicode);
                sw.Write(brosur);
                sw.Close();
                sw.Dispose();

                if (!cbKaynaktakiDosyalariSilme.Checked)
                    KaynaktakiDosyalariSil();

                webBrowser1.Navigate(txtCiktiYolu.Text + "\\Brosur.htm");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Dortlu()
        {
            try
            {
                Directory.CreateDirectory(txtCiktiYolu.Text);

                string bilgi1 = string.Empty, koliadedikismi1 = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />", koliadedi1 = string.Empty, urunaciklama1 = string.Empty,
                         bilgi2 = string.Empty, koliadedikismi2 = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />", koliadedi2 = string.Empty, urunaciklama2 = string.Empty,
                         bilgi3 = string.Empty, koliadedikismi3 = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />", koliadedi3 = string.Empty, urunaciklama3 = string.Empty,
                         bilgi4 = string.Empty, koliadedikismi4 = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />", koliadedi4 = string.Empty, urunaciklama4 = string.Empty;

                // tablo gerekli resimleri
                File.Copy("https://www.sultanlar.com.tr/sultanlarui/brosur/1_sultanlar_logo.png", txtCiktiYolu.Text + "\\1_sultanlar_logo.png", true);
                File.Copy("https://www.sultanlar.com.tr/sultanlarui/brosur/header-bg.png", txtCiktiYolu.Text + "\\header-bg.png", true);
                File.Copy("https://www.sultanlar.com.tr/sultanlarui/brosur/footer-bg.png", txtCiktiYolu.Text + "\\footer-bg.png", true);

                // şablon logosu
                if (File.Exists(txtDosyaYolu.Text + "\\logo.png"))
                {
                    File.Copy(txtDosyaYolu.Text + "\\logo.png", txtCiktiYolu.Text + "\\logo.png", true);
                }
                else
                {
                    File.Copy("https://www.sultanlar.com.tr/sultanlarui/brosur/1_sultanlar_logo.png", txtCiktiYolu.Text + "\\logo.png", true);
                }

                // urun resimleri ve barkodlari
                for (int i = 1; i <= 4; i++)
                {
                    //resim
                    if (File.Exists(txtDosyaYolu.Text + "\\" + i.ToString() + ".png") || File.Exists(txtDosyaYolu.Text + "\\" + i.ToString() + ".jpg"))
                    {
                        Image img = File.Exists(txtDosyaYolu.Text + "\\" + i.ToString() + ".png") ? Image.FromFile(txtDosyaYolu.Text + "\\" + i.ToString() + ".png") : Image.FromFile(txtDosyaYolu.Text + "\\" + i.ToString() + ".jpg");
                        Image kucukimg;
                        if (img.Height > img.Width)
                        {
                            double aspectRatio = Convert.ToDouble(img.Height) / img.Width;
                            double yukseklik = 270;
                            double genislik = yukseklik / aspectRatio;
                            kucukimg = Resim.ResimKucult(img, Convert.ToInt32(genislik));
                        }
                        else
                        {
                            kucukimg = Resim.ResimKucult(img, 270);
                        }
                        kucukimg.Save(txtCiktiYolu.Text + "\\" + i.ToString() + ".png");
                    }
                    else
                    {
                        File.Copy("https://www.sultanlar.com.tr/sultanlarui/brosur/bos.png", txtCiktiYolu.Text + "\\" + i.ToString() + ".png", true);
                    }

                    // barkod
                    if (File.Exists(txtDosyaYolu.Text + "\\" + i.ToString() + "barkod.png"))
                    {
                        File.Copy(txtDosyaYolu.Text + "\\" + i.ToString() + "barkod.png", txtCiktiYolu.Text + "\\" + i.ToString() + "barkod.png", true);
                    }
                    else
                    {
                        File.Copy("https://www.sultanlar.com.tr/sultanlarui/brosur/bos.png", txtCiktiYolu.Text + "\\" + i.ToString() + "barkod.png", true);
                    }
                }

                // urun aciklamalari
                if (File.Exists(txtDosyaYolu.Text + "\\1.txt"))
                {
                    bilgi1 = File.ReadAllText(txtDosyaYolu.Text + "\\1.txt", Encoding.GetEncoding("iso-8859-9")).ToUpper();
                    koliadedikismi1 = koliadedi;
                    koliadedi1 = bilgi1.Substring(0, bilgi1.IndexOf("\r\n"));
                    urunaciklama1 = bilgi1.Substring(bilgi1.IndexOf("\r\n") + 1);
                }
                if (File.Exists(txtDosyaYolu.Text + "\\2.txt"))
                {
                    bilgi2 = File.ReadAllText(txtDosyaYolu.Text + "\\2.txt", Encoding.GetEncoding("iso-8859-9")).ToUpper();
                    koliadedikismi2 = koliadedi;
                    koliadedi2 = bilgi2.Substring(0, bilgi2.IndexOf("\r\n"));
                    urunaciklama2 = bilgi2.Substring(bilgi2.IndexOf("\r\n") + 1);
                }
                if (File.Exists(txtDosyaYolu.Text + "\\3.txt"))
                {
                    bilgi3 = File.ReadAllText(txtDosyaYolu.Text + "\\3.txt", Encoding.GetEncoding("iso-8859-9")).ToUpper();
                    koliadedikismi3 = koliadedi;
                    koliadedi3 = bilgi3.Substring(0, bilgi3.IndexOf("\r\n"));
                    urunaciklama3 = bilgi3.Substring(bilgi3.IndexOf("\r\n") + 1);
                }
                if (File.Exists(txtDosyaYolu.Text + "\\4.txt"))
                {
                    bilgi4 = File.ReadAllText(txtDosyaYolu.Text + "\\4.txt", Encoding.GetEncoding("iso-8859-9")).ToUpper();
                    koliadedikismi4 = koliadedi;
                    koliadedi4 = bilgi4.Substring(0, bilgi4.IndexOf("\r\n"));
                    urunaciklama4 = bilgi4.Substring(bilgi4.IndexOf("\r\n") + 1);
                }

                // brosuru olustur
                string brosur = "<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\"><html xmlns=\"http://www.w3.org/1999/xhtml\" ><head>    <title>Untitled Page</title>    <style type=\"text/css\">        .style1 {            width: 730px;            height: 929px;            font-family: Tahoma;            font-size: 11px;            font-weight: normal;        }        .style2        {            width: 138px;            height: 43px;        }        .style3        { background-color: " + txtRenk.Text + "; } .style4        {            width: 150px;            height:  68px;        }        </style></head><body style=\"margin: 0px 0px 0px 10px\">    <table cellpadding=\"0\" cellspacing=\"0\" class=\"style1\"         style=\"border: 1px solid #ffcea0\">        <tr>            <td style=\"background-image: url(header-bg.png); height: 60px; padding: 10px 10px 0px 100px\">            " +
                        "<img src=\"logo.png\"                     style=\"padding: 10px 3px 3px 10px; height: 48px;\" /></td>        </tr>        <tr>            <td>                <table cellpadding=\"0\" cellspacing=\"0\" class=\"style1\">                    <tr>                        <td align=\"center\">                            <table cellpadding=\"0\" cellspacing=\"0\"                                                                                                 style=\"margin: 5px; padding: 0px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: 3px; border-bottom-width: 3px; border-left-width: 3px; border-right-color: #ffcea0; border-bottom-color: #ffcea0; border-left-color: #ffcea0;\">                                <tr>                                    <td colspan=\"2\"                                         style=\"padding: 5px; text-align: center; height: 280px; width: 280px;\" class=\"style3\">                                        " +
                        "<img alt=\"\" src=\"1.png\" /></td>                                </tr>                                <tr>                                    <td style=\"padding: 5px; background-color: #663300; text-align: center; color: #FFFFCC;\">                                        " + koliadedikismi1 + "<br />                                        " +
                        koliadedi1 + "</td>                                    <td style=\"padding: 5px; background-color: #ffcea0; width: 220px; text-align: center;\">                                        " +
                        urunaciklama1 + "</td>                                </tr>                                <tr>                                    <td colspan=\"2\" style=\"padding: 5px; text-align: center;\">                                        " +
                        "<img class=\"style4\" src=\"1barkod.png\" /></td>                                </tr>                            </table>                        </td>                        " +
                        "<td align=\"center\">                            <table cellpadding=\"0\" cellspacing=\"0\"                                                                                                                                 style=\"margin: 5px; padding: 0px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: 3px; border-bottom-width: 3px; border-left-width: 3px; border-right-color: #ffcea0; border-bottom-color: #ffcea0; border-left-color: #ffcea0;\">                                <tr>                                    <td colspan=\"2\"                                         style=\"padding: 5px; text-align: center; height: 280px; width: 280px;\" class=\"style3\">                                        " +
                        "<img alt=\"\" src=\"2.png\" /></td>                                </tr>                                <tr>                                    <td style=\"padding: 5px; background-color: #663300; text-align: center; color: #FFFFCC;\">                                        " + koliadedikismi2 + "<br />                                        " +
                        koliadedi2 + "</td>                                    <td style=\"padding: 5px; background-color: #ffcea0; width: 220px; text-align: center;\">                                        " +
                        urunaciklama2 + "</td>                                </tr>                                <tr>                                    <td colspan=\"2\" style=\"padding: 5px; text-align: center;\">                                        " +
                        "<img class=\"style4\" src=\"2barkod.png\" /></td>                                </tr>                            </table>                        </td>                    </tr>                    " +
                        "<tr>                        <td align=\"center\">                            <table cellpadding=\"0\" cellspacing=\"0\"                                                                                                                                 style=\"margin: 5px; padding: 0px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: 3px; border-bottom-width: 3px; border-left-width: 3px; border-right-color: #ffcea0; border-bottom-color: #ffcea0; border-left-color: #ffcea0;\">                                <tr>                                    <td colspan=\"2\"                                         style=\"padding: 5px; text-align: center; height: 280px; width: 280px;\" class=\"style3\">                                        " +
                        "<img alt=\"\" src=\"3.png\" /></td>                                </tr>                                <tr>                                    <td style=\"padding: 5px; background-color: #663300; text-align: center; color: #FFFFCC;\">                                        " + koliadedikismi3 + "<br />                                        " +
                        koliadedi3 + "</td>                                    <td style=\"padding: 5px; background-color: #ffcea0; width: 220px; text-align: center;\">                                        " +
                        urunaciklama3 + "</td>                                </tr>                                <tr>                                    <td colspan=\"2\" style=\"padding: 5px; text-align: center;\">                                        " +
                        "<img class=\"style4\" src=\"3barkod.png\" /></td>                                </tr>                            </table>                        </td>                        " +
                        "<td align=\"center\">                            <table cellpadding=\"0\" cellspacing=\"0\"                                                                                                                                 style=\"margin: 5px; padding: 0px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: 3px; border-bottom-width: 3px; border-left-width: 3px; border-right-color: #ffcea0; border-bottom-color: #ffcea0; border-left-color: #ffcea0;\">                                <tr>                                    <td colspan=\"2\"                                         style=\"padding: 5px; text-align: center; height: 280px; width: 280px;\" class=\"style3\">                                        " +
                        "<img alt=\"\" src=\"4.png\" /></td>                                </tr>                                <tr>                                    <td style=\"padding: 5px; background-color: #663300; text-align: center; color: #FFFFCC;\">                                        " + koliadedikismi4 + "<br />                                        " +
                        koliadedi4 + "</td>                                    <td style=\"padding: 5px; background-color: #ffcea0; width: 220px; text-align: center;\">                                        " +
                        urunaciklama4 + "</td>                                </tr>                                <tr>                                    <td colspan=\"2\" style=\"padding: 5px; text-align: center;\">                                        " +
                        "<img class=\"style4\" src=\"4barkod.png\" /></td>                                </tr>                            </table>                        </td>                    </tr>                </table>            </td>        </tr>        <tr>            <td style=\"background-image: url(footer-bg.png); height: 60px; padding: 0px 10px 20px 120px\">            <table style=\"margin-top: 5px\"><tr><td style=\"padding-right: 10px\"><span style=\"font-size: 11px\">                Dağıtım </span></td>            <td style=\"border-left-style: solid; border-left-color: #ffcea0; border-left-width: 1px;\">            <img class=\"style2\" src=\"1_sultanlar_logo.png\" style=\"padding: 3px 3px 3px 10px;\" /></td><td style=\"padding-left: 10px\">                <span style=\"font-size: 10px\"><i>Eyüp Sultan mh. Sekmen cd. No: 14 Sancaktepe / İSTANBUL</i><br /><i>Telefon: (+90 216) 561 50 00 Pbx</i><br /><i>Eposta: satis@sultanlar.com.tr</i></span></td></tr></table></td>        </tr>    </table></body></html>";

                // brosuru yaz
                if (File.Exists(txtCiktiYolu.Text + "\\Brosur.htm"))
                {
                    File.Delete(txtCiktiYolu.Text + "\\Brosur.htm");
                }
                StreamWriter sw = new StreamWriter(txtCiktiYolu.Text + "\\Brosur.htm", false, Encoding.Unicode);
                sw.Write(brosur);
                sw.Close();
                sw.Dispose();

                if (!cbKaynaktakiDosyalariSilme.Checked)
                    KaynaktakiDosyalariSil();

                webBrowser1.Navigate(txtCiktiYolu.Text + "\\Brosur.htm");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Ikili()
        {
            try
            {
                Directory.CreateDirectory(txtCiktiYolu.Text);

                string bilgi1 = string.Empty, koliadedikismi1 = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />", koliadedi1 = string.Empty, urunaciklama1 = string.Empty,
                         bilgi2 = string.Empty, koliadedikismi2 = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />", koliadedi2 = string.Empty, urunaciklama2 = string.Empty;

                // tablo gerekli resimleri
                File.Copy("https://www.sultanlar.com.tr/sultanlarui/brosur/1_sultanlar_logo.png", txtCiktiYolu.Text + "\\1_sultanlar_logo.png", true);
                File.Copy("https://www.sultanlar.com.tr/sultanlarui/brosur/header-bg.png", txtCiktiYolu.Text + "\\header-bg.png", true);
                File.Copy("https://www.sultanlar.com.tr/sultanlarui/brosur/footer-bg.png", txtCiktiYolu.Text + "\\footer-bg.png", true);

                // şablon logosu
                if (File.Exists(txtDosyaYolu.Text + "\\logo.png"))
                {
                    File.Copy(txtDosyaYolu.Text + "\\logo.png", txtCiktiYolu.Text + "\\logo.png", true);
                }
                else
                {
                    File.Copy("https://www.sultanlar.com.tr/sultanlarui/brosur/1_sultanlar_logo.png", txtCiktiYolu.Text + "\\logo.png", true);
                }

                // urun resimleri ve barkodlari
                for (int i = 1; i <= 2; i++)
                {
                    //resim
                    if (File.Exists(txtDosyaYolu.Text + "\\" + i.ToString() + ".png") || File.Exists(txtDosyaYolu.Text + "\\" + i.ToString() + ".jpg"))
                    {
                        Image img = File.Exists(txtDosyaYolu.Text + "\\" + i.ToString() + ".png") ? Image.FromFile(txtDosyaYolu.Text + "\\" + i.ToString() + ".png") : Image.FromFile(txtDosyaYolu.Text + "\\" + i.ToString() + ".jpg");
                        Image kucukimg;
                        if (img.Height > img.Width)
                        {
                            double aspectRatio = Convert.ToDouble(img.Height) / img.Width;
                            double yukseklik = 270;
                            double genislik = yukseklik / aspectRatio;
                            kucukimg = Resim.ResimKucult(img, Convert.ToInt32(genislik));
                        }
                        else
                        {
                            kucukimg = Resim.ResimKucult(img, 270);
                        }
                        kucukimg.Save(txtCiktiYolu.Text + "\\" + i.ToString() + ".png");
                    }
                    else
                    {
                        File.Copy("https://www.sultanlar.com.tr/sultanlarui/brosur/bos.png", txtCiktiYolu.Text + "\\" + i.ToString() + ".png", true);
                    }

                    // barkod
                    if (File.Exists(txtDosyaYolu.Text + "\\" + i.ToString() + "barkod.png"))
                    {
                        File.Copy(txtDosyaYolu.Text + "\\" + i.ToString() + "barkod.png", txtCiktiYolu.Text + "\\" + i.ToString() + "barkod.png", true);
                    }
                    else
                    {
                        File.Copy("https://www.sultanlar.com.tr/sultanlarui/brosur/bos.png", txtCiktiYolu.Text + "\\" + i.ToString() + "barkod.png", true);
                    }
                }

                // urun aciklamalari
                if (File.Exists(txtDosyaYolu.Text + "\\1.txt"))
                {
                    bilgi1 = File.ReadAllText(txtDosyaYolu.Text + "\\1.txt", Encoding.GetEncoding("iso-8859-9")).ToUpper();
                    koliadedikismi1 = koliadedi;
                    koliadedi1 = bilgi1.Substring(0, bilgi1.IndexOf("\r\n"));
                    urunaciklama1 = bilgi1.Substring(bilgi1.IndexOf("\r\n") + 1);
                }
                if (File.Exists(txtDosyaYolu.Text + "\\2.txt"))
                {
                    bilgi2 = File.ReadAllText(txtDosyaYolu.Text + "\\2.txt", Encoding.GetEncoding("iso-8859-9")).ToUpper();
                    koliadedikismi2 = koliadedi;
                    koliadedi2 = bilgi2.Substring(0, bilgi2.IndexOf("\r\n"));
                    urunaciklama2 = bilgi2.Substring(bilgi2.IndexOf("\r\n") + 1);
                }

                // brosuru olustur
                string brosur = "<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\"><html xmlns=\"http://www.w3.org/1999/xhtml\" ><head>    <title>Untitled Page</title>    <style type=\"text/css\">        .style1 {            width: 730px;            height: 929px;            font-family: Tahoma;            font-size: 11px;            font-weight: normal;        }        .style2        {            width: 138px;            height: 43px;        }        .style3        { background-color: " + txtRenk.Text + "; } .style4        {            width: 150px;            height:  68px;        }        </style></head><body style=\"margin: 0px 0px 0px 10px\">    <table cellpadding=\"0\" cellspacing=\"0\" class=\"style1\"         style=\"border: 1px solid #ffcea0\">        <tr>            <td style=\"background-image: url(header-bg.png); height: 60px; padding: 10px 10px 0px 100px\">            " +
                        "<img src=\"logo.png\"                     style=\"padding: 10px 3px 3px 10px; height: 48px;\" /></td>        </tr>        <tr>            <td>                <table cellpadding=\"0\" cellspacing=\"0\" class=\"style1\">                    <tr>                        <td align=\"center\">                            <table cellpadding=\"0\" cellspacing=\"0\"                                                                                                 style=\"margin: 5px; padding: 0px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: 3px; border-bottom-width: 3px; border-left-width: 3px; border-right-color: #ffcea0; border-bottom-color: #ffcea0; border-left-color: #ffcea0;\">                                <tr>                                    <td colspan=\"2\"                                         style=\"padding: 5px; text-align: center; height: 280px; width: 280px;\" class=\"style3\">                                        " +
                        "<img alt=\"\" src=\"1.png\" /></td>                                </tr>                                <tr>                                    <td style=\"padding: 5px; background-color: #663300; text-align: center; color: #FFFFCC;\">                                        " + koliadedikismi1 + "<br />                                        " +
                        koliadedi1 + "</td>                                    <td style=\"padding: 5px; background-color: #ffcea0; width: 220px; text-align: center;\">                                        " +
                        urunaciklama1 + "</td>                                </tr>                                <tr>                                    <td colspan=\"2\" style=\"padding: 5px; text-align: center;\">                                        " +
                        "<img class=\"style4\" src=\"1barkod.png\" /></td>                                </tr>                            </table>                        </td>                    </tr>                    " +
                        "<tr>                        <td align=\"center\">                            <table cellpadding=\"0\" cellspacing=\"0\"                                                                                                                                 style=\"margin: 5px; padding: 0px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: 3px; border-bottom-width: 3px; border-left-width: 3px; border-right-color: #ffcea0; border-bottom-color: #ffcea0; border-left-color: #ffcea0;\">                                <tr>                                    <td colspan=\"2\"                                         style=\"padding: 5px; text-align: center; height: 280px; width: 280px;\" class=\"style3\">                                        " +
                        "<img alt=\"\" src=\"2.png\" /></td>                                </tr>                                <tr>                                    <td style=\"padding: 5px; background-color: #663300; text-align: center; color: #FFFFCC;\">                                        " + koliadedikismi2 + "<br />                                        " +
                        koliadedi2 + "</td>                                    <td style=\"padding: 5px; background-color: #ffcea0; width: 220px; text-align: center;\">                                        " +
                        urunaciklama2 + "</td>                                </tr>                                <tr>                                    <td colspan=\"2\" style=\"padding: 5px; text-align: center;\">                                        " +
                        "<img class=\"style4\" src=\"2barkod.png\" /></td>                                </tr>                            </table>                        </td>                    </tr>                </table>            </td>        </tr>        <tr>            <td style=\"background-image: url(footer-bg.png); height: 60px; padding: 0px 10px 20px 120px\">            <table style=\"margin-top: 5px\"><tr><td style=\"padding-right: 10px\"><span style=\"font-size: 11px\">                Dağıtım </span></td>            <td style=\"border-left-style: solid; border-left-color: #ffcea0; border-left-width: 1px;\">            <img class=\"style2\" src=\"1_sultanlar_logo.png\" style=\"padding: 3px 3px 3px 10px;\" /></td><td style=\"padding-left: 10px\">                <span style=\"font-size: 10px\"><i>Eyüp Sultan mh. Sekmen cd. No: 14 Sancaktepe / İSTANBUL</i><br /><i>Telefon: (+90 216) 561 50 00 Pbx</i><br /><i>Eposta: satis@sultanlar.com.tr</i></span></td></tr></table></td>        </tr>    </table></body></html>";

                // brosuru yaz
                if (File.Exists(txtCiktiYolu.Text + "\\Brosur.htm"))
                {
                    File.Delete(txtCiktiYolu.Text + "\\Brosur.htm");
                }
                StreamWriter sw = new StreamWriter(txtCiktiYolu.Text + "\\Brosur.htm", false, Encoding.Unicode);
                sw.Write(brosur);
                sw.Close();
                sw.Dispose();

                if (!cbKaynaktakiDosyalariSilme.Checked)
                    KaynaktakiDosyalariSil();

                webBrowser1.Navigate(txtCiktiYolu.Text + "\\Brosur.htm");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Birli()
        {
            try
            {
                Directory.CreateDirectory(txtCiktiYolu.Text);

                // tablo gerekli resimleri
                File.Copy("https://www.sultanlar.com.tr/sultanlarui/brosur/1_sultanlar_logo.png", txtCiktiYolu.Text + "\\1_sultanlar_logo.png", true);
                File.Copy("https://www.sultanlar.com.tr/sultanlarui/brosur/header-bg.png", txtCiktiYolu.Text + "\\header-bg.png", true);
                File.Copy("https://www.sultanlar.com.tr/sultanlarui/brosur/footer-bg.png", txtCiktiYolu.Text + "\\footer-bg.png", true);

                // şablon logosu
                if (File.Exists(txtDosyaYolu.Text + "\\logo.png"))
                {
                    File.Copy(txtDosyaYolu.Text + "\\logo.png", txtCiktiYolu.Text + "\\logo.png", true);
                }
                else
                {
                    File.Copy("https://www.sultanlar.com.tr/sultanlarui/brosur/1_sultanlar_logo.png", txtCiktiYolu.Text + "\\logo.png", true);
                }

                // urun aciklamalari
                string bilgi = File.ReadAllText(txtDosyaYolu.Text + "\\1.txt", Encoding.GetEncoding("iso-8859-9")).ToUpper();
                string koliadedi1 = bilgi.Substring(0, bilgi.IndexOf("\r\n"));
                string urunaciklama1 = bilgi.Substring(bilgi.IndexOf("\r\n") + 1);

                //resim
                Image img = File.Exists(txtDosyaYolu.Text + "\\1.png") ? Image.FromFile(txtDosyaYolu.Text + "\\1.png") : Image.FromFile(txtDosyaYolu.Text + "\\1.jpg");
                Image kucukimg;
                if (img.Height > img.Width)
                {
                    double aspectRatio = Convert.ToDouble(img.Height) / img.Width;
                    double yukseklik = 520;
                    double genislik = yukseklik / aspectRatio;
                    kucukimg = Resim.ResimKucult(img, Convert.ToInt32(genislik));
                }
                else
                {
                    kucukimg = Resim.ResimKucult(img, 520);
                }
                kucukimg.Save(txtCiktiYolu.Text + "\\1.png");

                // barkod
                File.Copy(txtDosyaYolu.Text + "\\1barkod.png", txtCiktiYolu.Text + "\\1barkod.png", true);

                // brosuru olustur
                string brosur = "<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\"><html xmlns=\"http://www.w3.org/1999/xhtml\" ><head>    <title>Untitled Page</title>    <style type=\"text/css\">        .style1 {            width: 730px;            height: 929px;            font-family: Tahoma;            font-size: 18px;            font-weight: normal;        }        .style2        {            width: 138px;            height: 43px;        }        .style3        { background-color: " + txtRenk.Text + "; } .style3        { background-color: " + txtRenk.Text + "; } .style4        {            width: 150px;            height:  68px;        }         </style></head><body style=\"margin: 0px 0px 0px 10px\">    <table cellpadding=\"0\" cellspacing=\"0\" class=\"style1\"         style=\"border: 1px solid #ffcea0\">        <tr>            <td style=\"background-image: url(header-bg.png); height: 60px; padding: 10px 10px 0px 100px\">            " +
                        "<img src=\"logo.png\"                     style=\"padding: 10px 3px 3px 10px; height: 48px;\" /></td>        </tr>        <tr>            <td>                <table cellpadding=\"0\" cellspacing=\"0\" class=\"style1\">                    <tr>                        <td align=\"center\">                            <table cellpadding=\"0\" cellspacing=\"0\"                                                                                                 style=\"margin: 5px; padding: 0px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: 3px; border-bottom-width: 3px; border-left-width: 3px; border-right-color: #ffcea0; border-bottom-color: #ffcea0; border-left-color: #ffcea0;\">                                <tr>                                    <td colspan=\"2\"                                         style=\"padding: 5px; text-align: center; height: 530px; width: 530px;\" class=\"style3\">                                        " +
                        "<img alt=\"\" src=\"1.png\" /></td>                                </tr>                                <tr>                                    <td style=\"padding: 5px; background-color: #663300; text-align: center; color: #FFFFCC;\">                                        " + koliadedi + "<br />                                        " +
                        koliadedi1 + "</td>                                    <td style=\"padding: 5px; background-color: #ffcea0; width: 430px; text-align: center;\">                                        " +
                        urunaciklama1 + "</td>                                </tr>                                <tr>                                    <td colspan=\"2\" style=\"padding: 5px; text-align: center;\">                                        " +
                        "<img class=\"style4\" src=\"1barkod.png\"/></td>                                </tr>                            </table>                        </td>                    </tr>                </table>            </td>        </tr>        <tr>            <td style=\"background-image: url(footer-bg.png); height: 60px; padding: 0px 10px 20px 120px\">            <table style=\"margin-top: 5px\"><tr><td style=\"padding-right: 10px\"><span style=\"font-size: 14px\">                Dağıtım </span></td>            <td style=\"border-left-style: solid; border-left-color: #ffcea0; border-left-width: 1px;\">            <img class=\"style2\" src=\"1_sultanlar_logo.png\" style=\"padding: 3px 3px 3px 10px;\" /></td><td style=\"padding-left: 10px\">                <span style=\"font-size: 10px\"><i>Eyüp Sultan mh. Sekmen cd. No: 14 Sancaktepe / İSTANBUL</i><br /><i>Telefon: (+90 216) 561 50 00 Pbx</i><br /><i>Eposta: satis@sultanlar.com.tr</i></span></td></tr></table></td>        </tr>    </table></body></html>";

                // brosuru yaz
                if (File.Exists(txtCiktiYolu.Text + "\\Brosur.htm"))
                {
                    File.Delete(txtCiktiYolu.Text + "\\Brosur.htm");
                }
                StreamWriter sw = new StreamWriter(txtCiktiYolu.Text + "\\Brosur.htm", false, Encoding.Unicode);
                sw.Write(brosur);
                sw.Close();
                sw.Dispose();

                if (!cbKaynaktakiDosyalariSilme.Checked)
                    KaynaktakiDosyalariSil();

                webBrowser1.Navigate(txtCiktiYolu.Text + "\\Brosur.htm");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void YirmiliNoBG()
        {
            try
            {
                Directory.CreateDirectory(txtCiktiYolu.Text);

                string bilgi1 = string.Empty, koliadedikismi1 = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />", koliadedi1 = string.Empty, urunaciklama1 = string.Empty,
                         bilgi2 = string.Empty, koliadedikismi2 = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />", koliadedi2 = string.Empty, urunaciklama2 = string.Empty,
                         bilgi3 = string.Empty, koliadedikismi3 = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />", koliadedi3 = string.Empty, urunaciklama3 = string.Empty,
                         bilgi4 = string.Empty, koliadedikismi4 = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />", koliadedi4 = string.Empty, urunaciklama4 = string.Empty,
                         bilgi5 = string.Empty, koliadedikismi5 = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />", koliadedi5 = string.Empty, urunaciklama5 = string.Empty,
                         bilgi6 = string.Empty, koliadedikismi6 = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />", koliadedi6 = string.Empty, urunaciklama6 = string.Empty,
                         bilgi7 = string.Empty, koliadedikismi7 = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />", koliadedi7 = string.Empty, urunaciklama7 = string.Empty,
                         bilgi8 = string.Empty, koliadedikismi8 = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />", koliadedi8 = string.Empty, urunaciklama8 = string.Empty,
                         bilgi9 = string.Empty, koliadedikismi9 = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />", koliadedi9 = string.Empty, urunaciklama9 = string.Empty,
                         bilgi10 = string.Empty, koliadedikismi10 = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />", koliadedi10 = string.Empty, urunaciklama10 = string.Empty,
                         bilgi11 = string.Empty, koliadedikismi11 = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />", koliadedi11 = string.Empty, urunaciklama11 = string.Empty,
                         bilgi12 = string.Empty, koliadedikismi12 = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />", koliadedi12 = string.Empty, urunaciklama12 = string.Empty,
                         bilgi13 = string.Empty, koliadedikismi13 = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />", koliadedi13 = string.Empty, urunaciklama13 = string.Empty,
                         bilgi14 = string.Empty, koliadedikismi14 = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />", koliadedi14 = string.Empty, urunaciklama14 = string.Empty,
                         bilgi15 = string.Empty, koliadedikismi15 = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />", koliadedi15 = string.Empty, urunaciklama15 = string.Empty,
                         bilgi16 = string.Empty, koliadedikismi16 = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />", koliadedi16 = string.Empty, urunaciklama16 = string.Empty,
                         bilgi17 = string.Empty, koliadedikismi17 = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />", koliadedi17 = string.Empty, urunaciklama17 = string.Empty,
                         bilgi18 = string.Empty, koliadedikismi18 = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />", koliadedi18 = string.Empty, urunaciklama18 = string.Empty,
                         bilgi19 = string.Empty, koliadedikismi19 = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />", koliadedi19 = string.Empty, urunaciklama19 = string.Empty,
                         bilgi20 = string.Empty, koliadedikismi20 = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />", koliadedi20 = string.Empty, urunaciklama20 = string.Empty;

                // tablo gerekli resimleri
                File.Copy("https://www.sultanlar.com.tr/sultanlarui/brosur/1_sultanlar_logo.png", txtCiktiYolu.Text + "\\1_sultanlar_logo.png", true);
                File.Copy("https://www.sultanlar.com.tr/sultanlarui/brosur/header-bg.png", txtCiktiYolu.Text + "\\header-bg.png", true);
                File.Copy("https://www.sultanlar.com.tr/sultanlarui/brosur/footer-bg.png", txtCiktiYolu.Text + "\\footer-bg.png", true);

                // şablon logosu
                if (File.Exists(txtDosyaYolu.Text + "\\logo.png"))
                {
                    File.Copy(txtDosyaYolu.Text + "\\logo.png", txtCiktiYolu.Text + "\\logo.png", true);
                }
                else
                {
                    File.Copy("https://www.sultanlar.com.tr/sultanlarui/brosur/1_sultanlar_logo.png", txtCiktiYolu.Text + "\\logo.png", true);
                }

                // urun resimleri ve barkodlari
                for (int i = 1; i <= 20; i++)
                {
                    //resim
                    if (File.Exists(txtDosyaYolu.Text + "\\" + i.ToString() + ".png") || File.Exists(txtDosyaYolu.Text + "\\" + i.ToString() + ".jpg"))
                    {
                        Image img = File.Exists(txtDosyaYolu.Text + "\\" + i.ToString() + ".png") ? Image.FromFile(txtDosyaYolu.Text + "\\" + i.ToString() + ".png") : Image.FromFile(txtDosyaYolu.Text + "\\" + i.ToString() + ".jpg");
                        Image kucukimg;
                        if (img.Height > img.Width)
                        {
                            double aspectRatio = Convert.ToDouble(img.Height) / img.Width;
                            double yukseklik = 115;
                            double genislik = yukseklik / aspectRatio;
                            kucukimg = Resim.ResimKucult(img, Convert.ToInt32(genislik));
                        }
                        else
                        {
                            kucukimg = Resim.ResimKucult(img, 115);
                        }
                        kucukimg.Save(txtCiktiYolu.Text + "\\" + i.ToString() + ".png");
                    }
                    else
                    {
                        File.Copy("https://www.sultanlar.com.tr/sultanlarui/brosur/bos.png", txtCiktiYolu.Text + "\\" + i.ToString() + ".png", true);
                    }

                    // barkod
                    if (File.Exists(txtDosyaYolu.Text + "\\" + i.ToString() + "barkod.png"))
                    {
                        File.Copy(txtDosyaYolu.Text + "\\" + i.ToString() + "barkod.png", txtCiktiYolu.Text + "\\" + i.ToString() + "barkod.png", true);
                    }
                    else
                    {
                        File.Copy("https://www.sultanlar.com.tr/sultanlarui/brosur/bos.png", txtCiktiYolu.Text + "\\" + i.ToString() + "barkod.png", true);
                    }
                }

                // urun aciklamalari
                if (File.Exists(txtDosyaYolu.Text + "\\1.txt"))
                {
                    bilgi1 = File.ReadAllText(txtDosyaYolu.Text + "\\1.txt", Encoding.GetEncoding("iso-8859-9")).ToUpper();
                    koliadedikismi1 = koliadedi;
                    koliadedi1 = bilgi1.Substring(0, bilgi1.IndexOf("\r\n"));
                    urunaciklama1 = bilgi1.Substring(bilgi1.IndexOf("\r\n") + 1);
                }
                if (File.Exists(txtDosyaYolu.Text + "\\2.txt"))
                {
                    bilgi2 = File.ReadAllText(txtDosyaYolu.Text + "\\2.txt", Encoding.GetEncoding("iso-8859-9")).ToUpper();
                    koliadedikismi2 = koliadedi;
                    koliadedi2 = bilgi2.Substring(0, bilgi2.IndexOf("\r\n"));
                    urunaciklama2 = bilgi2.Substring(bilgi2.IndexOf("\r\n") + 1);
                }
                if (File.Exists(txtDosyaYolu.Text + "\\3.txt"))
                {
                    bilgi3 = File.ReadAllText(txtDosyaYolu.Text + "\\3.txt", Encoding.GetEncoding("iso-8859-9")).ToUpper();
                    koliadedikismi3 = koliadedi;
                    koliadedi3 = bilgi3.Substring(0, bilgi3.IndexOf("\r\n"));
                    urunaciklama3 = bilgi3.Substring(bilgi3.IndexOf("\r\n") + 1);
                }
                if (File.Exists(txtDosyaYolu.Text + "\\4.txt"))
                {
                    bilgi4 = File.ReadAllText(txtDosyaYolu.Text + "\\4.txt", Encoding.GetEncoding("iso-8859-9")).ToUpper();
                    koliadedikismi4 = koliadedi;
                    koliadedi4 = bilgi4.Substring(0, bilgi4.IndexOf("\r\n"));
                    urunaciklama4 = bilgi4.Substring(bilgi4.IndexOf("\r\n") + 1);
                }
                if (File.Exists(txtDosyaYolu.Text + "\\5.txt"))
                {
                    bilgi5 = File.ReadAllText(txtDosyaYolu.Text + "\\5.txt", Encoding.GetEncoding("iso-8859-9")).ToUpper();
                    koliadedikismi5 = koliadedi;
                    koliadedi5 = bilgi5.Substring(0, bilgi5.IndexOf("\r\n"));
                    urunaciklama5 = bilgi5.Substring(bilgi5.IndexOf("\r\n") + 1);
                }
                if (File.Exists(txtDosyaYolu.Text + "\\6.txt"))
                {
                    bilgi6 = File.ReadAllText(txtDosyaYolu.Text + "\\6.txt", Encoding.GetEncoding("iso-8859-9")).ToUpper();
                    koliadedikismi6 = koliadedi;
                    koliadedi6 = bilgi6.Substring(0, bilgi6.IndexOf("\r\n"));
                    urunaciklama6 = bilgi6.Substring(bilgi6.IndexOf("\r\n") + 1);
                }
                if (File.Exists(txtDosyaYolu.Text + "\\7.txt"))
                {
                    bilgi7 = File.ReadAllText(txtDosyaYolu.Text + "\\7.txt", Encoding.GetEncoding("iso-8859-9")).ToUpper();
                    koliadedikismi7 = koliadedi;
                    koliadedi7 = bilgi7.Substring(0, bilgi7.IndexOf("\r\n"));
                    urunaciklama7 = bilgi7.Substring(bilgi7.IndexOf("\r\n") + 1);
                }
                if (File.Exists(txtDosyaYolu.Text + "\\8.txt"))
                {
                    bilgi8 = File.ReadAllText(txtDosyaYolu.Text + "\\8.txt", Encoding.GetEncoding("iso-8859-9")).ToUpper();
                    koliadedikismi8 = koliadedi;
                    koliadedi8 = bilgi8.Substring(0, bilgi8.IndexOf("\r\n"));
                    urunaciklama8 = bilgi8.Substring(bilgi8.IndexOf("\r\n") + 1);
                }
                if (File.Exists(txtDosyaYolu.Text + "\\9.txt"))
                {
                    bilgi9 = File.ReadAllText(txtDosyaYolu.Text + "\\9.txt", Encoding.GetEncoding("iso-8859-9")).ToUpper();
                    koliadedikismi9 = koliadedi;
                    koliadedi9 = bilgi9.Substring(0, bilgi9.IndexOf("\r\n"));
                    urunaciklama9 = bilgi9.Substring(bilgi9.IndexOf("\r\n") + 1);
                }
                if (File.Exists(txtDosyaYolu.Text + "\\10.txt"))
                {
                    bilgi10 = File.ReadAllText(txtDosyaYolu.Text + "\\10.txt", Encoding.GetEncoding("iso-8859-9")).ToUpper();
                    koliadedikismi10 = koliadedi;
                    koliadedi10 = bilgi10.Substring(0, bilgi10.IndexOf("\r\n"));
                    urunaciklama10 = bilgi10.Substring(bilgi10.IndexOf("\r\n") + 1);
                }
                if (File.Exists(txtDosyaYolu.Text + "\\11.txt"))
                {
                    bilgi11 = File.ReadAllText(txtDosyaYolu.Text + "\\11.txt", Encoding.GetEncoding("iso-8859-9")).ToUpper();
                    koliadedikismi11 = koliadedi;
                    koliadedi11 = bilgi11.Substring(0, bilgi11.IndexOf("\r\n"));
                    urunaciklama11 = bilgi11.Substring(bilgi11.IndexOf("\r\n") + 1);
                }
                if (File.Exists(txtDosyaYolu.Text + "\\12.txt"))
                {
                    bilgi12 = File.ReadAllText(txtDosyaYolu.Text + "\\12.txt", Encoding.GetEncoding("iso-8859-9")).ToUpper();
                    koliadedikismi12 = koliadedi;
                    koliadedi12 = bilgi12.Substring(0, bilgi12.IndexOf("\r\n"));
                    urunaciklama12 = bilgi12.Substring(bilgi12.IndexOf("\r\n") + 1);
                }
                if (File.Exists(txtDosyaYolu.Text + "\\13.txt"))
                {
                    bilgi13 = File.ReadAllText(txtDosyaYolu.Text + "\\13.txt", Encoding.GetEncoding("iso-8859-9")).ToUpper();
                    koliadedikismi13 = koliadedi;
                    koliadedi13 = bilgi13.Substring(0, bilgi13.IndexOf("\r\n"));
                    urunaciklama13 = bilgi13.Substring(bilgi13.IndexOf("\r\n") + 1);
                }
                if (File.Exists(txtDosyaYolu.Text + "\\14.txt"))
                {
                    bilgi14 = File.ReadAllText(txtDosyaYolu.Text + "\\14.txt", Encoding.GetEncoding("iso-8859-9")).ToUpper();
                    koliadedikismi14 = koliadedi;
                    koliadedi14 = bilgi14.Substring(0, bilgi14.IndexOf("\r\n"));
                    urunaciklama14 = bilgi14.Substring(bilgi14.IndexOf("\r\n") + 1);
                }
                if (File.Exists(txtDosyaYolu.Text + "\\15.txt"))
                {
                    bilgi15 = File.ReadAllText(txtDosyaYolu.Text + "\\15.txt", Encoding.GetEncoding("iso-8859-9")).ToUpper();
                    koliadedikismi15 = koliadedi;
                    koliadedi15 = bilgi15.Substring(0, bilgi15.IndexOf("\r\n"));
                    urunaciklama15 = bilgi15.Substring(bilgi15.IndexOf("\r\n") + 1);
                }
                if (File.Exists(txtDosyaYolu.Text + "\\16.txt"))
                {
                    bilgi16 = File.ReadAllText(txtDosyaYolu.Text + "\\16.txt", Encoding.GetEncoding("iso-8859-9")).ToUpper();
                    koliadedikismi16 = koliadedi;
                    koliadedi16 = bilgi16.Substring(0, bilgi16.IndexOf("\r\n"));
                    urunaciklama16 = bilgi16.Substring(bilgi16.IndexOf("\r\n") + 1);
                }
                if (File.Exists(txtDosyaYolu.Text + "\\17.txt"))
                {
                    bilgi17 = File.ReadAllText(txtDosyaYolu.Text + "\\17.txt", Encoding.GetEncoding("iso-8859-9")).ToUpper();
                    koliadedikismi17 = koliadedi;
                    koliadedi17 = bilgi17.Substring(0, bilgi17.IndexOf("\r\n"));
                    urunaciklama17 = bilgi17.Substring(bilgi17.IndexOf("\r\n") + 1);
                }
                if (File.Exists(txtDosyaYolu.Text + "\\18.txt"))
                {
                    bilgi18 = File.ReadAllText(txtDosyaYolu.Text + "\\18.txt", Encoding.GetEncoding("iso-8859-9")).ToUpper();
                    koliadedikismi18 = koliadedi;
                    koliadedi18 = bilgi18.Substring(0, bilgi18.IndexOf("\r\n"));
                    urunaciklama18 = bilgi18.Substring(bilgi18.IndexOf("\r\n") + 1);
                }
                if (File.Exists(txtDosyaYolu.Text + "\\19.txt"))
                {
                    bilgi19 = File.ReadAllText(txtDosyaYolu.Text + "\\19.txt", Encoding.GetEncoding("iso-8859-9")).ToUpper();
                    koliadedikismi19 = koliadedi;
                    koliadedi19 = bilgi19.Substring(0, bilgi19.IndexOf("\r\n"));
                    urunaciklama19 = bilgi19.Substring(bilgi19.IndexOf("\r\n") + 1);
                }
                if (File.Exists(txtDosyaYolu.Text + "\\20.txt"))
                {
                    bilgi20 = File.ReadAllText(txtDosyaYolu.Text + "\\20.txt", Encoding.GetEncoding("iso-8859-9")).ToUpper();
                    koliadedikismi20 = koliadedi;
                    koliadedi20 = bilgi20.Substring(0, bilgi20.IndexOf("\r\n"));
                    urunaciklama20 = bilgi20.Substring(bilgi20.IndexOf("\r\n") + 1);
                }

                // brosuru olustur
                string brosur = "<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\"><html xmlns=\"http://www.w3.org/1999/xhtml\" ><head>    <title>Untitled Page</title>    <style type=\"text/css\">        .style1 {            width: 730px;            height: 929px;            font-family:Tahoma;             font-size: 7px;            font-weight: normal;        }        .style2        {            width: 138px;            height: 43px;        }        .style3        { background-color: " + txtRenk.Text + "; } .style4        {            width: 100px;            height: 37px;        }          </style></head><body style=\"margin: 0px 0px 0px 10px\">    <table cellpadding=\"0\" cellspacing=\"0\" class=\"style1\"         style=\"border: 1px solid #ffcea0\">        <tr>            <td style=\"background-image: url(header-bg.png); height: 60px; padding: 10px 10px 0px 100px\">            " +
                        "<img src=\"logo.png\"                     style=\"padding: 10px 3px 3px 10px; height: 48px;\" /></td>        </tr>        <tr>            <td>                <table cellpadding=\"0\" cellspacing=\"0\" class=\"style1\">                    <tr>                        <td align=\"center\">                            <table cellpadding=\"0\" cellspacing=\"0\"                                                                                                 style=\"margin: 5px; padding: 0px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: 3px; border-bottom-width: 3px; border-left-width: 3px; border-right-color: #ffcea0; border-bottom-color: #ffcea0; border-left-color: #ffcea0;\">                                <tr>                                    <td colspan=\"2\"                                         style=\"padding: 5px; text-align: center; height: 136px; width: 136px;\" class=\"style3\">                                        " +
                        "<img alt=\"\" src=\"1.png\" /></td>                                </tr>                                <tr>                                    " +
                        "<td style=\"border-width: 1px; border-color: #FFCEA0; padding: 5px; text-align: center; border-top-style: solid; border-bottom-style: solid;\">                                        " +
                        "<b>" + urunaciklama1 + "</b></td>                                </tr>                                <tr>                                    <td colspan=\"2\" style=\"padding: 5px; text-align: center;\">                                        " +
                        "<img class=\"style4\" src=\"1barkod.png\" /></td>                                </tr>                            </table>                        </td>                        " +
                        "<td align=\"center\">                            <table cellpadding=\"0\" cellspacing=\"0\"                                                                                                                                 style=\"margin: 5px; padding: 0px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: 3px; border-bottom-width: 3px; border-left-width: 3px; border-right-color: #ffcea0; border-bottom-color: #ffcea0; border-left-color: #ffcea0;\">                                <tr>                                    <td colspan=\"2\"                                         style=\"padding: 5px; text-align: center; height: 136px; width: 136px;\" class=\"style3\">                                        " +
                        "<img alt=\"\" src=\"2.png\" /></td>                                </tr>                                <tr>                                    " +
                        "<td style=\"border-width: 1px; border-color: #FFCEA0; padding: 5px; text-align: center; border-top-style: solid; border-bottom-style: solid;\">                                        " +
                        "<b>" + urunaciklama2 + "</b></td>                                </tr>                                <tr>                                    <td colspan=\"2\" style=\"padding: 5px; text-align: center;\">                                        " +
                        "<img class=\"style4\" src=\"2barkod.png\" /></td>                                </tr>                            </table>                        </td>                        " +
                        "<td align=\"center\">                            <table cellpadding=\"0\" cellspacing=\"0\"                                                                                                                                 style=\"margin: 5px; padding: 0px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: 3px; border-bottom-width: 3px; border-left-width: 3px; border-right-color: #ffcea0; border-bottom-color: #ffcea0; border-left-color: #ffcea0;\">                                <tr>                                    <td colspan=\"2\"                                         style=\"padding: 5px; text-align: center; height: 136px; width: 136px;\" class=\"style3\">                                        " +
                        "<img alt=\"\" src=\"3.png\" /></td>                                </tr>                                <tr>                                    " +
                        "<td style=\"border-width: 1px; border-color: #FFCEA0; padding: 5px; text-align: center; border-top-style: solid; border-bottom-style: solid;\">                                        " +
                        "<b>" + urunaciklama3 + "</b></td>                                </tr>                                <tr>                                    <td colspan=\"2\" style=\"padding: 5px; text-align: center;\">                                        " +
                        "<img class=\"style4\" src=\"3barkod.png\" /></td>                                </tr>                            </table>                        </td>                        " +
                        "<td align=\"center\">                            <table cellpadding=\"0\" cellspacing=\"0\"                                                                                                                                 style=\"margin: 5px; padding: 0px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: 3px; border-bottom-width: 3px; border-left-width: 3px; border-right-color: #ffcea0; border-bottom-color: #ffcea0; border-left-color: #ffcea0;\">                                <tr>                                    <td colspan=\"2\"                                         style=\"padding: 5px; text-align: center; height: 136px; width: 136px;\" class=\"style3\">                                        " +
                        "<img alt=\"\" src=\"4.png\" /></td>                                </tr>                                <tr>                                    " +
                        "<td style=\"border-width: 1px; border-color: #FFCEA0; padding: 5px; text-align: center; border-top-style: solid; border-bottom-style: solid;\">                                        " +
                        "<b>" + urunaciklama4 + "</b></td>                                </tr>                                <tr>                                    <td colspan=\"2\" style=\"padding: 5px; text-align: center;\">                                        " +
                        "<img class=\"style4\" src=\"4barkod.png\" /></td>                                </tr>                            </table>                        </td>                        " +
                        "<td align=\"center\">                            <table cellpadding=\"0\" cellspacing=\"0\"                                                                                                                                 style=\"margin: 5px; padding: 0px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: 3px; border-bottom-width: 3px; border-left-width: 3px; border-right-color: #ffcea0; border-bottom-color: #ffcea0; border-left-color: #ffcea0;\">                                <tr>                                    <td colspan=\"2\"                                         style=\"padding: 5px; text-align: center; height: 136px; width: 136px;\" class=\"style3\">                                        " +
                        "<img alt=\"\" src=\"5.png\" /></td>                                </tr>                                <tr>                                    " +
                        "<td style=\"border-width: 1px; border-color: #FFCEA0; padding: 5px; text-align: center; border-top-style: solid; border-bottom-style: solid;\">                                        " +
                        "<b>" + urunaciklama5 + "</b></td>                                </tr>                                <tr>                                    <td colspan=\"2\" style=\"padding: 5px; text-align: center;\">                                        " +
                        "<img class=\"style4\" src=\"5barkod.png\" /></td>                                </tr>                            </table>                        </td>                    </tr>                    " +
                        "<tr>                        <td align=\"center\">                            <table cellpadding=\"0\" cellspacing=\"0\"                                                                                                                                 style=\"margin: 5px; padding: 0px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: 3px; border-bottom-width: 3px; border-left-width: 3px; border-right-color: #ffcea0; border-bottom-color: #ffcea0; border-left-color: #ffcea0;\">                                <tr>                                    <td colspan=\"2\"                                         style=\"padding: 5px; text-align: center; height: 136px; width: 136px;\" class=\"style3\">                                        " +
                        "<img alt=\"\" src=\"6.png\" /></td>                                </tr>                                <tr>                                    " +
                        "<td style=\"border-width: 1px; border-color: #FFCEA0; padding: 5px; text-align: center; border-top-style: solid; border-bottom-style: solid;\">                                        " +
                        "<b>" + urunaciklama6 + "</b></td>                                </tr>                                <tr>                                    <td colspan=\"2\" style=\"padding: 5px; text-align: center;\">                                        " +
                        "<img class=\"style4\" src=\"6barkod.png\" /></td>                                </tr>                            </table>                        </td>                        " +
                        "<td align=\"center\">                            <table cellpadding=\"0\" cellspacing=\"0\"                                                                                                                                 style=\"margin: 5px; padding: 0px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: 3px; border-bottom-width: 3px; border-left-width: 3px; border-right-color: #ffcea0; border-bottom-color: #ffcea0; border-left-color: #ffcea0;\">                                <tr>                                    <td colspan=\"2\"                                         style=\"padding: 5px; text-align: center; height: 136px; width: 136px;\" class=\"style3\">                                        " +
                        "<img alt=\"\" src=\"7.png\" /></td>                                </tr>                                <tr>                                    " +
                        "<td style=\"border-width: 1px; border-color: #FFCEA0; padding: 5px; text-align: center; border-top-style: solid; border-bottom-style: solid;\">                                        " +
                        "<b>" + urunaciklama7 + "</b></td>                                </tr>                                <tr>                                    <td colspan=\"2\" style=\"padding: 5px; text-align: center;\">                                        " +
                        "<img class=\"style4\" src=\"7barkod.png\" /></td>                                </tr>                            </table>                        </td>                        " +
                        "<td align=\"center\">                            <table cellpadding=\"0\" cellspacing=\"0\"                                                                                                                                 style=\"margin: 5px; padding: 0px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: 3px; border-bottom-width: 3px; border-left-width: 3px; border-right-color: #ffcea0; border-bottom-color: #ffcea0; border-left-color: #ffcea0;\">                                <tr>                                    <td colspan=\"2\"                                         style=\"padding: 5px; text-align: center; height: 136px; width: 136px;\" class=\"style3\">                                        " +
                        "<img alt=\"\" src=\"8.png\" /></td>                                </tr>                                <tr>                                    " +
                        "<td style=\"border-width: 1px; border-color: #FFCEA0; padding: 5px; text-align: center; border-top-style: solid; border-bottom-style: solid;\">                                        " +
                        "<b>" + urunaciklama8 + "</b></td>                                </tr>                                <tr>                                    <td colspan=\"2\" style=\"padding: 5px; text-align: center;\">                                        " +
                        "<img class=\"style4\" src=\"8barkod.png\" /></td>                                </tr>                            </table>                        </td>                        " +
                        "<td align=\"center\">                            <table cellpadding=\"0\" cellspacing=\"0\"                                                                                                                                 style=\"margin: 5px; padding: 0px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: 3px; border-bottom-width: 3px; border-left-width: 3px; border-right-color: #ffcea0; border-bottom-color: #ffcea0; border-left-color: #ffcea0;\">                                <tr>                                    <td colspan=\"2\"                                         style=\"padding: 5px; text-align: center; height: 136px; width: 136px;\" class=\"style3\">                                        " +
                        "<img alt=\"\" src=\"9.png\" /></td>                                </tr>                                <tr>                                    " +
                        "<td style=\"border-width: 1px; border-color: #FFCEA0; padding: 5px; text-align: center; border-top-style: solid; border-bottom-style: solid;\">                                        " +
                        "<b>" + urunaciklama9 + "</b></td>                                </tr>                                <tr>                                    <td colspan=\"2\" style=\"padding: 5px; text-align: center;\">                                        " +
                        "<img class=\"style4\" src=\"9barkod.png\" /></td>                                </tr>                            </table>                        </td>                        " +
                        "<td align=\"center\">                            <table cellpadding=\"0\" cellspacing=\"0\"                                                                                                                                 style=\"margin: 5px; padding: 0px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: 3px; border-bottom-width: 3px; border-left-width: 3px; border-right-color: #ffcea0; border-bottom-color: #ffcea0; border-left-color: #ffcea0;\">                                <tr>                                    <td colspan=\"2\"                                         style=\"padding: 5px; text-align: center; height: 136px; width: 136px;\" class=\"style3\">                                        " +
                        "<img alt=\"\" src=\"10.png\" /></td>                                </tr>                                <tr>                                    " +
                        "<td style=\"border-width: 1px; border-color: #FFCEA0; padding: 5px; text-align: center; border-top-style: solid; border-bottom-style: solid;\">                                        " +
                        "<b>" + urunaciklama10 + "</b></td>                                </tr>                                <tr>                                    <td colspan=\"2\" style=\"padding: 5px; text-align: center;\">                                        " +
                        "<img class=\"style4\" src=\"10barkod.png\" /></td>                                </tr>                            </table>                        </td>                    </tr>                    " +
                        "<tr>                        <td align=\"center\">                            <table cellpadding=\"0\" cellspacing=\"0\"                                                                                                                                 style=\"margin: 5px; padding: 0px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: 3px; border-bottom-width: 3px; border-left-width: 3px; border-right-color: #ffcea0; border-bottom-color: #ffcea0; border-left-color: #ffcea0;\">                                <tr>                                    <td colspan=\"2\"                                         style=\"padding: 5px; text-align: center; height: 136px; width: 136px;\" class=\"style3\">                                        " +
                        "<img alt=\"\" src=\"11.png\" /></td>                                </tr>                                <tr>                                    " +
                        "<td style=\"border-width: 1px; border-color: #FFCEA0; padding: 5px; text-align: center; border-top-style: solid; border-bottom-style: solid;\">                                        " +
                        "<b>" + urunaciklama11 + "</b></td>                                </tr>                                <tr>                                    <td colspan=\"2\" style=\"padding: 5px; text-align: center;\">                                        " +
                        "<img class=\"style4\" src=\"11barkod.png\" /></td>                                </tr>                            </table>                        </td>                        " +
                        "<td align=\"center\">                            <table cellpadding=\"0\" cellspacing=\"0\"                                                                                                                                 style=\"margin: 5px; padding: 0px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: 3px; border-bottom-width: 3px; border-left-width: 3px; border-right-color: #ffcea0; border-bottom-color: #ffcea0; border-left-color: #ffcea0;\">                                <tr>                                    <td colspan=\"2\"                                         style=\"padding: 5px; text-align: center; height: 136px; width: 136px;\" class=\"style3\">                                        " +
                        "<img alt=\"\" src=\"12.png\" /></td>                                </tr>                                <tr>                                    " +
                        "<td style=\"border-width: 1px; border-color: #FFCEA0; padding: 5px; text-align: center; border-top-style: solid; border-bottom-style: solid;\">                                        " +
                        "<b>" + urunaciklama12 + "</b></td>                                </tr>                                <tr>                                    <td colspan=\"2\" style=\"padding: 5px; text-align: center;\">                                        " +
                        "<img class=\"style4\" src=\"12barkod.png\" /></td>                                </tr>                            </table>                        </td>                        " +
                        "<td align=\"center\">                            <table cellpadding=\"0\" cellspacing=\"0\"                                                                                                                                 style=\"margin: 5px; padding: 0px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: 3px; border-bottom-width: 3px; border-left-width: 3px; border-right-color: #ffcea0; border-bottom-color: #ffcea0; border-left-color: #ffcea0;\">                                <tr>                                    <td colspan=\"2\"                                         style=\"padding: 5px; text-align: center; height: 136px; width: 136px;\" class=\"style3\">                                        " +
                        "<img alt=\"\" src=\"13.png\" /></td>                                </tr>                                <tr>                                    " +
                        "<td style=\"border-width: 1px; border-color: #FFCEA0; padding: 5px; text-align: center; border-top-style: solid; border-bottom-style: solid;\">                                        " +
                        "<b>" + urunaciklama13 + "</b></td>                                </tr>                                <tr>                                    <td colspan=\"2\" style=\"padding: 5px; text-align: center;\">                                        " +
                        "<img class=\"style4\" src=\"13barkod.png\" /></td>                                </tr>                            </table>                        </td>                        " +
                        "<td align=\"center\">                            <table cellpadding=\"0\" cellspacing=\"0\"                                                                                                                                 style=\"margin: 5px; padding: 0px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: 3px; border-bottom-width: 3px; border-left-width: 3px; border-right-color: #ffcea0; border-bottom-color: #ffcea0; border-left-color: #ffcea0;\">                                <tr>                                    <td colspan=\"2\"                                         style=\"padding: 5px; text-align: center; height: 136px; width: 136px;\" class=\"style3\">                                        " +
                        "<img alt=\"\" src=\"14.png\" /></td>                                </tr>                                <tr>                                    " +
                        "<td style=\"border-width: 1px; border-color: #FFCEA0; padding: 5px; text-align: center; border-top-style: solid; border-bottom-style: solid;\">                                        " +
                        "<b>" + urunaciklama14 + "</b></td>                                </tr>                                <tr>                                    <td colspan=\"2\" style=\"padding: 5px; text-align: center;\">                                        " +
                        "<img class=\"style4\" src=\"14barkod.png\" /></td>                                </tr>                            </table>                        </td>                        " +
                        "<td align=\"center\">                            <table cellpadding=\"0\" cellspacing=\"0\"                                                                                                                                 style=\"margin: 5px; padding: 0px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: 3px; border-bottom-width: 3px; border-left-width: 3px; border-right-color: #ffcea0; border-bottom-color: #ffcea0; border-left-color: #ffcea0;\">                                <tr>                                    <td colspan=\"2\"                                         style=\"padding: 5px; text-align: center; height: 136px; width: 136px;\" class=\"style3\">                                        " +
                        "<img alt=\"\" src=\"15.png\" /></td>                                </tr>                                <tr>                                    " +
                        "<td style=\"border-width: 1px; border-color: #FFCEA0; padding: 5px; text-align: center; border-top-style: solid; border-bottom-style: solid;\">                                        " +
                        "<b>" + urunaciklama15 + "</b></td>                                </tr>                                <tr>                                    <td colspan=\"2\" style=\"padding: 5px; text-align: center;\">                                        " +
                        "<img class=\"style4\" src=\"15barkod.png\" /></td>                                </tr>                            </table>                        </td>                    </tr>                    " +
                        "<tr>                        <td align=\"center\">                            <table cellpadding=\"0\" cellspacing=\"0\"                                                                                                                                 style=\"margin: 5px; padding: 0px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: 3px; border-bottom-width: 3px; border-left-width: 3px; border-right-color: #ffcea0; border-bottom-color: #ffcea0; border-left-color: #ffcea0;\">                                <tr>                                    <td colspan=\"2\"                                         style=\"padding: 5px; text-align: center; height: 136px; width: 136px;\" class=\"style3\">                                        " +
                        "<img alt=\"\" src=\"16.png\" /></td>                                </tr>                                <tr>                                    " +
                        "<td style=\"border-width: 1px; border-color: #FFCEA0; padding: 5px; text-align: center; border-top-style: solid; border-bottom-style: solid;\">                                        " +
                        "<b>" + urunaciklama16 + "</b></td>                                </tr>                                <tr>                                    <td colspan=\"2\" style=\"padding: 5px; text-align: center;\">                                        " +
                        "<img class=\"style4\" src=\"16barkod.png\" /></td>                                </tr>                            </table>                        </td>                        " +
                        "<td align=\"center\">                            <table cellpadding=\"0\" cellspacing=\"0\"                                                                                                                                 style=\"margin: 5px; padding: 0px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: 3px; border-bottom-width: 3px; border-left-width: 3px; border-right-color: #ffcea0; border-bottom-color: #ffcea0; border-left-color: #ffcea0;\">                                <tr>                                    <td colspan=\"2\"                                         style=\"padding: 5px; text-align: center; height: 136px; width: 136px;\" class=\"style3\">                                        " +
                        "<img alt=\"\" src=\"17.png\" /></td>                                </tr>                                <tr>                                    " +
                        "<td style=\"border-width: 1px; border-color: #FFCEA0; padding: 5px; text-align: center; border-top-style: solid; border-bottom-style: solid;\">                                        " +
                        "<b>" + urunaciklama17 + "</b></td>                                </tr>                                <tr>                                    <td colspan=\"2\" style=\"padding: 5px; text-align: center;\">                                        " +
                        "<img class=\"style4\" src=\"17barkod.png\" /></td>                                </tr>                            </table>                        </td>                        " +
                        "<td align=\"center\">                            <table cellpadding=\"0\" cellspacing=\"0\"                                                                                                                                 style=\"margin: 5px; padding: 0px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: 3px; border-bottom-width: 3px; border-left-width: 3px; border-right-color: #ffcea0; border-bottom-color: #ffcea0; border-left-color: #ffcea0;\">                                <tr>                                    <td colspan=\"2\"                                         style=\"padding: 5px; text-align: center; height: 136px; width: 136px;\" class=\"style3\">                                        " +
                        "<img alt=\"\" src=\"18.png\" /></td>                                </tr>                                <tr>                                    " +
                        "<td style=\"border-width: 1px; border-color: #FFCEA0; padding: 5px; text-align: center; border-top-style: solid; border-bottom-style: solid;\">                                        " +
                        "<b>" + urunaciklama18 + "</b></td>                                </tr>                                <tr>                                    <td colspan=\"2\" style=\"padding: 5px; text-align: center;\">                                        " +
                        "<img class=\"style4\" src=\"18barkod.png\" /></td>                                </tr>                            </table>                        </td>                        " +
                        "<td align=\"center\">                            <table cellpadding=\"0\" cellspacing=\"0\"                                                                                                                                 style=\"margin: 5px; padding: 0px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: 3px; border-bottom-width: 3px; border-left-width: 3px; border-right-color: #ffcea0; border-bottom-color: #ffcea0; border-left-color: #ffcea0;\">                                <tr>                                    <td colspan=\"2\"                                         style=\"padding: 5px; text-align: center; height: 136px; width: 136px;\" class=\"style3\">                                        " +
                        "<img alt=\"\" src=\"19.png\" /></td>                                </tr>                                <tr>                                    " +
                        "<td style=\"border-width: 1px; border-color: #FFCEA0; padding: 5px; text-align: center; border-top-style: solid; border-bottom-style: solid;\">                                        " +
                        "<b>" + urunaciklama19 + "</b></td>                                </tr>                                <tr>                                    <td colspan=\"2\" style=\"padding: 5px; text-align: center;\">                                        " +
                        "<img class=\"style4\" src=\"19barkod.png\" /></td>                                </tr>                            </table>                        </td>                        " +
                        "<td align=\"center\">                            <table cellpadding=\"0\" cellspacing=\"0\"                                                                                                                                 style=\"margin: 5px; padding: 0px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: 3px; border-bottom-width: 3px; border-left-width: 3px; border-right-color: #ffcea0; border-bottom-color: #ffcea0; border-left-color: #ffcea0;\">                                <tr>                                    <td colspan=\"2\"                                         style=\"padding: 5px; text-align: center; height: 136px; width: 136px;\" class=\"style3\">                                        " +
                        "<img alt=\"\" src=\"20.png\" /></td>                                </tr>                                <tr>                                    " +
                        "<td style=\"border-width: 1px; border-color: #FFCEA0; padding: 5px; text-align: center; border-top-style: solid; border-bottom-style: solid;\">                                        " +
                        "<b>" + urunaciklama20 + "</b></td>                                </tr>                                <tr>                                    <td colspan=\"2\" style=\"padding: 5px; text-align: center;\">                                        " +
                        "<img class=\"style4\" src=\"20barkod.png\" /></td>                                </tr>                            </table>                        </td>                    </tr>                </table>            </td>        </tr>        <tr>            <td style=\"background-image: url(footer-bg.png); height: 60px; padding: 0px 10px 20px 120px\">            <table style=\"margin-top: 5px\"><tr><td style=\"padding-right: 10px\"><span style=\"font-size: 14px\">                Dağıtım </span></td>            <td style=\"border-left-style: solid; border-left-color: #ffcea0; border-left-width: 1px;\">            <img class=\"style2\" src=\"1_sultanlar_logo.png\" style=\"padding: 3px 3px 3px 10px;\" /></td>            <td style=\"padding-left: 10px\">                <span style=\"font-size: 10px\"><i>Eyüp Sultan mh. Sekmen cd. No: 14 Sancaktepe / İSTANBUL</i><br /><i>Telefon: (+90 216) 561 50 00 Pbx</i><br /><i>Eposta: satis@sultanlar.com.tr</i></span></td></tr></table></td>        </tr>    </table></body></html>";

                // brosuru yaz
                if (File.Exists(txtCiktiYolu.Text + "\\Brosur.htm"))
                {
                    File.Delete(txtCiktiYolu.Text + "\\Brosur.htm");
                }
                StreamWriter sw = new StreamWriter(txtCiktiYolu.Text + "\\Brosur.htm", false, Encoding.Unicode);
                sw.Write(brosur);
                sw.Close();
                sw.Dispose();

                if (!cbKaynaktakiDosyalariSilme.Checked)
                    KaynaktakiDosyalariSil();

                webBrowser1.Navigate(txtCiktiYolu.Text + "\\Brosur.htm");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OnaltiliNoBG()
        {
            try
            {
                Directory.CreateDirectory(txtCiktiYolu.Text);

                string bilgi1 = string.Empty, koliadedikismi1 = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />", koliadedi1 = string.Empty, urunaciklama1 = string.Empty,
                         bilgi2 = string.Empty, koliadedikismi2 = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />", koliadedi2 = string.Empty, urunaciklama2 = string.Empty,
                         bilgi3 = string.Empty, koliadedikismi3 = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />", koliadedi3 = string.Empty, urunaciklama3 = string.Empty,
                         bilgi4 = string.Empty, koliadedikismi4 = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />", koliadedi4 = string.Empty, urunaciklama4 = string.Empty,
                         bilgi5 = string.Empty, koliadedikismi5 = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />", koliadedi5 = string.Empty, urunaciklama5 = string.Empty,
                         bilgi6 = string.Empty, koliadedikismi6 = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />", koliadedi6 = string.Empty, urunaciklama6 = string.Empty,
                         bilgi7 = string.Empty, koliadedikismi7 = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />", koliadedi7 = string.Empty, urunaciklama7 = string.Empty,
                         bilgi8 = string.Empty, koliadedikismi8 = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />", koliadedi8 = string.Empty, urunaciklama8 = string.Empty,
                         bilgi9 = string.Empty, koliadedikismi9 = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />", koliadedi9 = string.Empty, urunaciklama9 = string.Empty,
                         bilgi10 = string.Empty, koliadedikismi10 = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />", koliadedi10 = string.Empty, urunaciklama10 = string.Empty,
                         bilgi11 = string.Empty, koliadedikismi11 = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />", koliadedi11 = string.Empty, urunaciklama11 = string.Empty,
                         bilgi12 = string.Empty, koliadedikismi12 = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />", koliadedi12 = string.Empty, urunaciklama12 = string.Empty,
                         bilgi13 = string.Empty, koliadedikismi13 = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />", koliadedi13 = string.Empty, urunaciklama13 = string.Empty,
                         bilgi14 = string.Empty, koliadedikismi14 = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />", koliadedi14 = string.Empty, urunaciklama14 = string.Empty,
                         bilgi15 = string.Empty, koliadedikismi15 = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />", koliadedi15 = string.Empty, urunaciklama15 = string.Empty,
                         bilgi16 = string.Empty, koliadedikismi16 = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />", koliadedi16 = string.Empty, urunaciklama16 = string.Empty;

                // tablo gerekli resimleri
                File.Copy("https://www.sultanlar.com.tr/sultanlarui/brosur/1_sultanlar_logo.png", txtCiktiYolu.Text + "\\1_sultanlar_logo.png", true);
                File.Copy("https://www.sultanlar.com.tr/sultanlarui/brosur/header-bg.png", txtCiktiYolu.Text + "\\header-bg.png", true);
                File.Copy("https://www.sultanlar.com.tr/sultanlarui/brosur/footer-bg.png", txtCiktiYolu.Text + "\\footer-bg.png", true);

                // şablon logosu
                if (File.Exists(txtDosyaYolu.Text + "\\logo.png"))
                {
                    File.Copy(txtDosyaYolu.Text + "\\logo.png", txtCiktiYolu.Text + "\\logo.png", true);
                }
                else
                {
                    File.Copy("https://www.sultanlar.com.tr/sultanlarui/brosur/1_sultanlar_logo.png", txtCiktiYolu.Text + "\\logo.png", true);
                }

                // urun resimleri ve barkodlari
                for (int i = 1; i <= 16; i++)
                {
                    //resim
                    if (File.Exists(txtDosyaYolu.Text + "\\" + i.ToString() + ".png") || File.Exists(txtDosyaYolu.Text + "\\" + i.ToString() + ".jpg"))
                    {
                        Image img = File.Exists(txtDosyaYolu.Text + "\\" + i.ToString() + ".png") ? Image.FromFile(txtDosyaYolu.Text + "\\" + i.ToString() + ".png") : Image.FromFile(txtDosyaYolu.Text + "\\" + i.ToString() + ".jpg");
                        Image kucukimg;
                        if (img.Height > img.Width)
                        {
                            double aspectRatio = Convert.ToDouble(img.Height) / img.Width;
                            double yukseklik = 126;
                            double genislik = yukseklik / aspectRatio;
                            kucukimg = Resim.ResimKucult(img, Convert.ToInt32(genislik));
                        }
                        else
                        {
                            kucukimg = Resim.ResimKucult(img, 126);
                        }
                        kucukimg.Save(txtCiktiYolu.Text + "\\" + i.ToString() + ".png");
                    }
                    else
                    {
                        File.Copy("https://www.sultanlar.com.tr/sultanlarui/brosur/bos.png", txtCiktiYolu.Text + "\\" + i.ToString() + ".png", true);
                    }

                    // barkod
                    if (File.Exists(txtDosyaYolu.Text + "\\" + i.ToString() + "barkod.png"))
                    {
                        File.Copy(txtDosyaYolu.Text + "\\" + i.ToString() + "barkod.png", txtCiktiYolu.Text + "\\" + i.ToString() + "barkod.png", true);
                    }
                    else
                    {
                        File.Copy("https://www.sultanlar.com.tr/sultanlarui/brosur/bos.png", txtCiktiYolu.Text + "\\" + i.ToString() + "barkod.png", true);
                    }
                }

                // urun aciklamalari
                if (File.Exists(txtDosyaYolu.Text + "\\1.txt"))
                {
                    bilgi1 = File.ReadAllText(txtDosyaYolu.Text + "\\1.txt", Encoding.GetEncoding("iso-8859-9")).ToUpper();
                    koliadedikismi1 = koliadedi;
                    koliadedi1 = bilgi1.Substring(0, bilgi1.IndexOf("\r\n"));
                    urunaciklama1 = bilgi1.Substring(bilgi1.IndexOf("\r\n") + 1);
                }
                if (File.Exists(txtDosyaYolu.Text + "\\2.txt"))
                {
                    bilgi2 = File.ReadAllText(txtDosyaYolu.Text + "\\2.txt", Encoding.GetEncoding("iso-8859-9")).ToUpper();
                    koliadedikismi2 = koliadedi;
                    koliadedi2 = bilgi2.Substring(0, bilgi2.IndexOf("\r\n"));
                    urunaciklama2 = bilgi2.Substring(bilgi2.IndexOf("\r\n") + 1);
                }
                if (File.Exists(txtDosyaYolu.Text + "\\3.txt"))
                {
                    bilgi3 = File.ReadAllText(txtDosyaYolu.Text + "\\3.txt", Encoding.GetEncoding("iso-8859-9")).ToUpper();
                    koliadedikismi3 = koliadedi;
                    koliadedi3 = bilgi3.Substring(0, bilgi3.IndexOf("\r\n"));
                    urunaciklama3 = bilgi3.Substring(bilgi3.IndexOf("\r\n") + 1);
                }
                if (File.Exists(txtDosyaYolu.Text + "\\4.txt"))
                {
                    bilgi4 = File.ReadAllText(txtDosyaYolu.Text + "\\4.txt", Encoding.GetEncoding("iso-8859-9")).ToUpper();
                    koliadedikismi4 = koliadedi;
                    koliadedi4 = bilgi4.Substring(0, bilgi4.IndexOf("\r\n"));
                    urunaciklama4 = bilgi4.Substring(bilgi4.IndexOf("\r\n") + 1);
                }
                if (File.Exists(txtDosyaYolu.Text + "\\5.txt"))
                {
                    bilgi5 = File.ReadAllText(txtDosyaYolu.Text + "\\5.txt", Encoding.GetEncoding("iso-8859-9")).ToUpper();
                    koliadedikismi5 = koliadedi;
                    koliadedi5 = bilgi5.Substring(0, bilgi5.IndexOf("\r\n"));
                    urunaciklama5 = bilgi5.Substring(bilgi5.IndexOf("\r\n") + 1);
                }
                if (File.Exists(txtDosyaYolu.Text + "\\6.txt"))
                {
                    bilgi6 = File.ReadAllText(txtDosyaYolu.Text + "\\6.txt", Encoding.GetEncoding("iso-8859-9")).ToUpper();
                    koliadedikismi6 = koliadedi;
                    koliadedi6 = bilgi6.Substring(0, bilgi6.IndexOf("\r\n"));
                    urunaciklama6 = bilgi6.Substring(bilgi6.IndexOf("\r\n") + 1);
                }
                if (File.Exists(txtDosyaYolu.Text + "\\7.txt"))
                {
                    bilgi7 = File.ReadAllText(txtDosyaYolu.Text + "\\7.txt", Encoding.GetEncoding("iso-8859-9")).ToUpper();
                    koliadedikismi7 = koliadedi;
                    koliadedi7 = bilgi7.Substring(0, bilgi7.IndexOf("\r\n"));
                    urunaciklama7 = bilgi7.Substring(bilgi7.IndexOf("\r\n") + 1);
                }
                if (File.Exists(txtDosyaYolu.Text + "\\8.txt"))
                {
                    bilgi8 = File.ReadAllText(txtDosyaYolu.Text + "\\8.txt", Encoding.GetEncoding("iso-8859-9")).ToUpper();
                    koliadedikismi8 = koliadedi;
                    koliadedi8 = bilgi8.Substring(0, bilgi8.IndexOf("\r\n"));
                    urunaciklama8 = bilgi8.Substring(bilgi8.IndexOf("\r\n") + 1);
                }
                if (File.Exists(txtDosyaYolu.Text + "\\9.txt"))
                {
                    bilgi9 = File.ReadAllText(txtDosyaYolu.Text + "\\9.txt", Encoding.GetEncoding("iso-8859-9")).ToUpper();
                    koliadedikismi9 = koliadedi;
                    koliadedi9 = bilgi9.Substring(0, bilgi9.IndexOf("\r\n"));
                    urunaciklama9 = bilgi9.Substring(bilgi9.IndexOf("\r\n") + 1);
                }
                if (File.Exists(txtDosyaYolu.Text + "\\10.txt"))
                {
                    bilgi10 = File.ReadAllText(txtDosyaYolu.Text + "\\10.txt", Encoding.GetEncoding("iso-8859-9")).ToUpper();
                    koliadedikismi10 = koliadedi;
                    koliadedi10 = bilgi10.Substring(0, bilgi10.IndexOf("\r\n"));
                    urunaciklama10 = bilgi10.Substring(bilgi10.IndexOf("\r\n") + 1);
                }
                if (File.Exists(txtDosyaYolu.Text + "\\11.txt"))
                {
                    bilgi11 = File.ReadAllText(txtDosyaYolu.Text + "\\11.txt", Encoding.GetEncoding("iso-8859-9")).ToUpper();
                    koliadedikismi11 = koliadedi;
                    koliadedi11 = bilgi11.Substring(0, bilgi11.IndexOf("\r\n"));
                    urunaciklama11 = bilgi11.Substring(bilgi11.IndexOf("\r\n") + 1);
                }
                if (File.Exists(txtDosyaYolu.Text + "\\12.txt"))
                {
                    bilgi12 = File.ReadAllText(txtDosyaYolu.Text + "\\12.txt", Encoding.GetEncoding("iso-8859-9")).ToUpper();
                    koliadedikismi12 = koliadedi;
                    koliadedi12 = bilgi12.Substring(0, bilgi12.IndexOf("\r\n"));
                    urunaciklama12 = bilgi12.Substring(bilgi12.IndexOf("\r\n") + 1);
                }
                if (File.Exists(txtDosyaYolu.Text + "\\13.txt"))
                {
                    bilgi13 = File.ReadAllText(txtDosyaYolu.Text + "\\13.txt", Encoding.GetEncoding("iso-8859-9")).ToUpper();
                    koliadedikismi13 = koliadedi;
                    koliadedi13 = bilgi13.Substring(0, bilgi13.IndexOf("\r\n"));
                    urunaciklama13 = bilgi13.Substring(bilgi13.IndexOf("\r\n") + 1);
                }
                if (File.Exists(txtDosyaYolu.Text + "\\14.txt"))
                {
                    bilgi14 = File.ReadAllText(txtDosyaYolu.Text + "\\14.txt", Encoding.GetEncoding("iso-8859-9")).ToUpper();
                    koliadedikismi14 = koliadedi;
                    koliadedi14 = bilgi14.Substring(0, bilgi14.IndexOf("\r\n"));
                    urunaciklama14 = bilgi14.Substring(bilgi14.IndexOf("\r\n") + 1);
                }
                if (File.Exists(txtDosyaYolu.Text + "\\15.txt"))
                {
                    bilgi15 = File.ReadAllText(txtDosyaYolu.Text + "\\15.txt", Encoding.GetEncoding("iso-8859-9")).ToUpper();
                    koliadedikismi15 = koliadedi;
                    koliadedi15 = bilgi15.Substring(0, bilgi15.IndexOf("\r\n"));
                    urunaciklama15 = bilgi15.Substring(bilgi15.IndexOf("\r\n") + 1);
                }
                if (File.Exists(txtDosyaYolu.Text + "\\16.txt"))
                {
                    bilgi16 = File.ReadAllText(txtDosyaYolu.Text + "\\16.txt", Encoding.GetEncoding("iso-8859-9")).ToUpper();
                    koliadedikismi16 = koliadedi;
                    koliadedi16 = bilgi16.Substring(0, bilgi16.IndexOf("\r\n"));
                    urunaciklama16 = bilgi16.Substring(bilgi16.IndexOf("\r\n") + 1);
                }

                // brosuru olustur
                string brosur = "<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\"><html xmlns=\"http://www.w3.org/1999/xhtml\" ><head>    <title>Untitled Page</title>    <style type=\"text/css\">        .style1 {            width: 730px;            height: 929px;            font-family:Tahoma;             font-size: 7px;            font-weight: normal;        }        .style2        {            width: 138px;            height: 43px;        }        .style3        { background-color: " + txtRenk.Text + "; } .style4        {            width: 100px;            height: 37px;        }          </style></head><body style=\"margin: 0px 0px 0px 10px\">    <table cellpadding=\"0\" cellspacing=\"0\" class=\"style1\"         style=\"border: 1px solid #ffcea0\">        <tr>            <td style=\"background-image: url(header-bg.png); height: 60px; padding: 10px 10px 0px 100px\">            " +
                        "<img src=\"logo.png\"                     style=\"padding: 10px 3px 3px 10px; height: 48px;\" /></td>        </tr>        <tr>            <td>                <table cellpadding=\"0\" cellspacing=\"0\" class=\"style1\">                    <tr>                        <td align=\"center\">                            <table cellpadding=\"0\" cellspacing=\"0\"                                                                                                 style=\"margin: 5px; padding: 0px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: 3px; border-bottom-width: 3px; border-left-width: 3px; border-right-color: #ffcea0; border-bottom-color: #ffcea0; border-left-color: #ffcea0;\">                                <tr>                                    <td colspan=\"2\"                                         style=\"padding: 5px; text-align: center; height: 136px; width: 136px;\" class=\"style3\">                                        " +
                        "<img alt=\"\" src=\"1.png\" /></td>                                </tr>                                <tr>                                    " +
                        "<td style=\"border-width: 1px; border-color: #FFCEA0; padding: 5px; text-align: center; border-top-style: solid; border-bottom-style: solid;\">                                        " +
                        "<b>" + urunaciklama1 + "</b></td>                                </tr>                                <tr>                                    <td colspan=\"2\" style=\"padding: 5px; text-align: center;\">                                        " +
                        "<img class=\"style4\" src=\"1barkod.png\" /></td>                                </tr>                            </table>                        </td>                        " +
                        "<td align=\"center\">                            <table cellpadding=\"0\" cellspacing=\"0\"                                                                                                                                 style=\"margin: 5px; padding: 0px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: 3px; border-bottom-width: 3px; border-left-width: 3px; border-right-color: #ffcea0; border-bottom-color: #ffcea0; border-left-color: #ffcea0;\">                                <tr>                                    <td colspan=\"2\"                                         style=\"padding: 5px; text-align: center; height: 136px; width: 136px;\" class=\"style3\">                                        " +
                        "<img alt=\"\" src=\"2.png\" /></td>                                </tr>                                <tr>                                    " +
                        "<td style=\"border-width: 1px; border-color: #FFCEA0; padding: 5px; text-align: center; border-top-style: solid; border-bottom-style: solid;\">                                        " +
                        "<b>" + urunaciklama2 + "</b></td>                                </tr>                                <tr>                                    <td colspan=\"2\" style=\"padding: 5px; text-align: center;\">                                        " +
                        "<img class=\"style4\" src=\"2barkod.png\" /></td>                                </tr>                            </table>                        </td>                        " +
                        "<td align=\"center\">                            <table cellpadding=\"0\" cellspacing=\"0\"                                                                                                                                 style=\"margin: 5px; padding: 0px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: 3px; border-bottom-width: 3px; border-left-width: 3px; border-right-color: #ffcea0; border-bottom-color: #ffcea0; border-left-color: #ffcea0;\">                                <tr>                                    <td colspan=\"2\"                                         style=\"padding: 5px; text-align: center; height: 136px; width: 136px;\" class=\"style3\">                                        " +
                        "<img alt=\"\" src=\"3.png\" /></td>                                </tr>                                <tr>                                    " +
                        "<td style=\"border-width: 1px; border-color: #FFCEA0; padding: 5px; text-align: center; border-top-style: solid; border-bottom-style: solid;\">                                        " +
                        "<b>" + urunaciklama3 + "</b></td>                                </tr>                                <tr>                                    <td colspan=\"2\" style=\"padding: 5px; text-align: center;\">                                        " +
                        "<img class=\"style4\" src=\"3barkod.png\" /></td>                                </tr>                            </table>                        </td>                        " +
                        "<td align=\"center\">                            <table cellpadding=\"0\" cellspacing=\"0\"                                                                                                                                 style=\"margin: 5px; padding: 0px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: 3px; border-bottom-width: 3px; border-left-width: 3px; border-right-color: #ffcea0; border-bottom-color: #ffcea0; border-left-color: #ffcea0;\">                                <tr>                                    <td colspan=\"2\"                                         style=\"padding: 5px; text-align: center; height: 136px; width: 136px;\" class=\"style3\">                                        " +
                        "<img alt=\"\" src=\"4.png\" /></td>                                </tr>                                <tr>                                    " +
                        "<td style=\"border-width: 1px; border-color: #FFCEA0; padding: 5px; text-align: center; border-top-style: solid; border-bottom-style: solid;\">                                        " +
                        "<b>" + urunaciklama4 + "</b></td>                                </tr>                                <tr>                                    <td colspan=\"2\" style=\"padding: 5px; text-align: center;\">                                        " +
                        "<img class=\"style4\" src=\"4barkod.png\" /></td>                                </tr>                            </table>                        </td>                    </tr>                    " +
                        "<tr>                        <td align=\"center\">                            <table cellpadding=\"0\" cellspacing=\"0\"                                                                                                                                 style=\"margin: 5px; padding: 0px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: 3px; border-bottom-width: 3px; border-left-width: 3px; border-right-color: #ffcea0; border-bottom-color: #ffcea0; border-left-color: #ffcea0;\">                                <tr>                                    <td colspan=\"2\"                                         style=\"padding: 5px; text-align: center; height: 136px; width: 136px;\" class=\"style3\">                                        " +
                        "<img alt=\"\" src=\"5.png\" /></td>                                </tr>                                <tr>                                    " +
                        "<td style=\"border-width: 1px; border-color: #FFCEA0; padding: 5px; text-align: center; border-top-style: solid; border-bottom-style: solid;\">                                        " +
                        "<b>" + urunaciklama5 + "</b></td>                                </tr>                                <tr>                                    <td colspan=\"2\" style=\"padding: 5px; text-align: center;\">                                        " +
                        "<img class=\"style4\" src=\"5barkod.png\" /></td>                                </tr>                            </table>                        </td>                        " +
                        "<td align=\"center\">                            <table cellpadding=\"0\" cellspacing=\"0\"                                                                                                                                 style=\"margin: 5px; padding: 0px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: 3px; border-bottom-width: 3px; border-left-width: 3px; border-right-color: #ffcea0; border-bottom-color: #ffcea0; border-left-color: #ffcea0;\">                                <tr>                                    <td colspan=\"2\"                                         style=\"padding: 5px; text-align: center; height: 136px; width: 136px;\" class=\"style3\">                                        " +
                        "<img alt=\"\" src=\"6.png\" /></td>                                </tr>                                <tr>                                    " +
                        "<td style=\"border-width: 1px; border-color: #FFCEA0; padding: 5px; text-align: center; border-top-style: solid; border-bottom-style: solid;\">                                        " +
                        "<b>" + urunaciklama6 + "</b></td>                                </tr>                                <tr>                                    <td colspan=\"2\" style=\"padding: 5px; text-align: center;\">                                        " +
                        "<img class=\"style4\" src=\"6barkod.png\" /></td>                                </tr>                            </table>                        </td>                        " +
                        "<td align=\"center\">                            <table cellpadding=\"0\" cellspacing=\"0\"                                                                                                                                 style=\"margin: 5px; padding: 0px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: 3px; border-bottom-width: 3px; border-left-width: 3px; border-right-color: #ffcea0; border-bottom-color: #ffcea0; border-left-color: #ffcea0;\">                                <tr>                                    <td colspan=\"2\"                                         style=\"padding: 5px; text-align: center; height: 136px; width: 136px;\" class=\"style3\">                                        " +
                        "<img alt=\"\" src=\"7.png\" /></td>                                </tr>                                <tr>                                    " +
                        "<td style=\"border-width: 1px; border-color: #FFCEA0; padding: 5px; text-align: center; border-top-style: solid; border-bottom-style: solid;\">                                        " +
                        "<b>" + urunaciklama7 + "</b></td>                                </tr>                                <tr>                                    <td colspan=\"2\" style=\"padding: 5px; text-align: center;\">                                        " +
                        "<img class=\"style4\" src=\"7barkod.png\" /></td>                                </tr>                            </table>                        </td>                        " +
                        "<td align=\"center\">                            <table cellpadding=\"0\" cellspacing=\"0\"                                                                                                                                 style=\"margin: 5px; padding: 0px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: 3px; border-bottom-width: 3px; border-left-width: 3px; border-right-color: #ffcea0; border-bottom-color: #ffcea0; border-left-color: #ffcea0;\">                                <tr>                                    <td colspan=\"2\"                                         style=\"padding: 5px; text-align: center; height: 136px; width: 136px;\" class=\"style3\">                                        " +
                        "<img alt=\"\" src=\"8.png\" /></td>                                </tr>                                <tr>                                    " +
                        "<td style=\"border-width: 1px; border-color: #FFCEA0; padding: 5px; text-align: center; border-top-style: solid; border-bottom-style: solid;\">                                        " +
                        "<b>" + urunaciklama8 + "</b></td>                                </tr>                                <tr>                                    <td colspan=\"2\" style=\"padding: 5px; text-align: center;\">                                        " +
                        "<img class=\"style4\" src=\"8barkod.png\" /></td>                                </tr>                            </table>                        </td>                    </tr>                    " +
                        "<tr>                        <td align=\"center\">                            <table cellpadding=\"0\" cellspacing=\"0\"                                                                                                                                 style=\"margin: 5px; padding: 0px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: 3px; border-bottom-width: 3px; border-left-width: 3px; border-right-color: #ffcea0; border-bottom-color: #ffcea0; border-left-color: #ffcea0;\">                                <tr>                                    <td colspan=\"2\"                                         style=\"padding: 5px; text-align: center; height: 136px; width: 136px;\" class=\"style3\">                                        " +
                        "<img alt=\"\" src=\"9.png\" /></td>                                </tr>                                <tr>                                    " +
                        "<td style=\"border-width: 1px; border-color: #FFCEA0; padding: 5px; text-align: center; border-top-style: solid; border-bottom-style: solid;\">                                        " +
                        "<b>" + urunaciklama9 + "</b></td>                                </tr>                                <tr>                                    <td colspan=\"2\" style=\"padding: 5px; text-align: center;\">                                        " +
                        "<img class=\"style4\" src=\"9barkod.png\" /></td>                                </tr>                            </table>                        </td>                        " +
                        "<td align=\"center\">                            <table cellpadding=\"0\" cellspacing=\"0\"                                                                                                                                 style=\"margin: 5px; padding: 0px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: 3px; border-bottom-width: 3px; border-left-width: 3px; border-right-color: #ffcea0; border-bottom-color: #ffcea0; border-left-color: #ffcea0;\">                                <tr>                                    <td colspan=\"2\"                                         style=\"padding: 5px; text-align: center; height: 136px; width: 136px;\" class=\"style3\">                                        " +
                        "<img alt=\"\" src=\"10.png\" /></td>                                </tr>                                <tr>                                    " +
                        "<td style=\"border-width: 1px; border-color: #FFCEA0; padding: 5px; text-align: center; border-top-style: solid; border-bottom-style: solid;\">                                        " +
                        "<b>" + urunaciklama10 + "</b></td>                                </tr>                                <tr>                                    <td colspan=\"2\" style=\"padding: 5px; text-align: center;\">                                        " +
                        "<img class=\"style4\" src=\"10barkod.png\" /></td>                                </tr>                            </table>                        </td>                        " +
                        "<td align=\"center\">                            <table cellpadding=\"0\" cellspacing=\"0\"                                                                                                                                 style=\"margin: 5px; padding: 0px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: 3px; border-bottom-width: 3px; border-left-width: 3px; border-right-color: #ffcea0; border-bottom-color: #ffcea0; border-left-color: #ffcea0;\">                                <tr>                                    <td colspan=\"2\"                                         style=\"padding: 5px; text-align: center; height: 136px; width: 136px;\" class=\"style3\">                                        " +
                        "<img alt=\"\" src=\"11.png\" /></td>                                </tr>                                <tr>                                    " +
                        "<td style=\"border-width: 1px; border-color: #FFCEA0; padding: 5px; text-align: center; border-top-style: solid; border-bottom-style: solid;\">                                        " +
                        "<b>" + urunaciklama11 + "</b></td>                                </tr>                                <tr>                                    <td colspan=\"2\" style=\"padding: 5px; text-align: center;\">                                        " +
                        "<img class=\"style4\" src=\"11barkod.png\" /></td>                                </tr>                            </table>                        </td>                        " +
                        "<td align=\"center\">                            <table cellpadding=\"0\" cellspacing=\"0\"                                                                                                                                 style=\"margin: 5px; padding: 0px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: 3px; border-bottom-width: 3px; border-left-width: 3px; border-right-color: #ffcea0; border-bottom-color: #ffcea0; border-left-color: #ffcea0;\">                                <tr>                                    <td colspan=\"2\"                                         style=\"padding: 5px; text-align: center; height: 136px; width: 136px;\" class=\"style3\">                                        " +
                        "<img alt=\"\" src=\"12.png\" /></td>                                </tr>                                <tr>                                    " +
                        "<td style=\"border-width: 1px; border-color: #FFCEA0; padding: 5px; text-align: center; border-top-style: solid; border-bottom-style: solid;\">                                        " +
                        "<b>" + urunaciklama12 + "</b></td>                                </tr>                                <tr>                                    <td colspan=\"2\" style=\"padding: 5px; text-align: center;\">                                        " +
                        "<img class=\"style4\" src=\"12barkod.png\" /></td>                                </tr>                            </table>                        </td>                    </tr>                    " +
                        "<tr>                        <td align=\"center\">                            <table cellpadding=\"0\" cellspacing=\"0\"                                                                                                                                 style=\"margin: 5px; padding: 0px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: 3px; border-bottom-width: 3px; border-left-width: 3px; border-right-color: #ffcea0; border-bottom-color: #ffcea0; border-left-color: #ffcea0;\">                                <tr>                                    <td colspan=\"2\"                                         style=\"padding: 5px; text-align: center; height: 136px; width: 136px;\" class=\"style3\">                                        " +
                        "<img alt=\"\" src=\"13.png\" /></td>                                </tr>                                <tr>                                    " +
                        "<td style=\"border-width: 1px; border-color: #FFCEA0; padding: 5px; text-align: center; border-top-style: solid; border-bottom-style: solid;\">                                        " +
                        "<b>" + urunaciklama13 + "</b></td>                                </tr>                                <tr>                                    <td colspan=\"2\" style=\"padding: 5px; text-align: center;\">                                        " +
                        "<img class=\"style4\" src=\"13barkod.png\" /></td>                                </tr>                            </table>                        </td>                        " +
                        "<td align=\"center\">                            <table cellpadding=\"0\" cellspacing=\"0\"                                                                                                                                 style=\"margin: 5px; padding: 0px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: 3px; border-bottom-width: 3px; border-left-width: 3px; border-right-color: #ffcea0; border-bottom-color: #ffcea0; border-left-color: #ffcea0;\">                                <tr>                                    <td colspan=\"2\"                                         style=\"padding: 5px; text-align: center; height: 136px; width: 136px;\" class=\"style3\">                                        " +
                        "<img alt=\"\" src=\"14.png\" /></td>                                </tr>                                <tr>                                    " +
                        "<td style=\"border-width: 1px; border-color: #FFCEA0; padding: 5px; text-align: center; border-top-style: solid; border-bottom-style: solid;\">                                        " +
                        "<b>" + urunaciklama14 + "</b></td>                                </tr>                                <tr>                                    <td colspan=\"2\" style=\"padding: 5px; text-align: center;\">                                        " +
                        "<img class=\"style4\" src=\"14barkod.png\" /></td>                                </tr>                            </table>                        </td>                        " +
                        "<td align=\"center\">                            <table cellpadding=\"0\" cellspacing=\"0\"                                                                                                                                 style=\"margin: 5px; padding: 0px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: 3px; border-bottom-width: 3px; border-left-width: 3px; border-right-color: #ffcea0; border-bottom-color: #ffcea0; border-left-color: #ffcea0;\">                                <tr>                                    <td colspan=\"2\"                                         style=\"padding: 5px; text-align: center; height: 136px; width: 136px;\" class=\"style3\">                                        " +
                        "<img alt=\"\" src=\"15.png\" /></td>                                </tr>                                <tr>                                    " +
                        "<td style=\"border-width: 1px; border-color: #FFCEA0; padding: 5px; text-align: center; border-top-style: solid; border-bottom-style: solid;\">                                        " +
                        "<b>" + urunaciklama15 + "</b></td>                                </tr>                                <tr>                                    <td colspan=\"2\" style=\"padding: 5px; text-align: center;\">                                        " +
                        "<img class=\"style4\" src=\"15barkod.png\" /></td>                                </tr>                            </table>                        </td>                        " +
                        "<td align=\"center\">                            <table cellpadding=\"0\" cellspacing=\"0\"                                                                                                                                 style=\"margin: 5px; padding: 0px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: 3px; border-bottom-width: 3px; border-left-width: 3px; border-right-color: #ffcea0; border-bottom-color: #ffcea0; border-left-color: #ffcea0;\">                                <tr>                                    <td colspan=\"2\"                                         style=\"padding: 5px; text-align: center; height: 136px; width: 136px;\" class=\"style3\">                                        " +
                        "<img alt=\"\" src=\"16.png\" /></td>                                </tr>                                <tr>                                    " +
                        "<td style=\"border-width: 1px; border-color: #FFCEA0; padding: 5px; text-align: center; border-top-style: solid; border-bottom-style: solid;\">                                        " +
                        "<b>" + urunaciklama16 + "</b></td>                                </tr>                                <tr>                                    <td colspan=\"2\" style=\"padding: 5px; text-align: center;\">                                        " +
                        "<img class=\"style4\" src=\"16barkod.png\" /></td>                                </tr>                            </table>                        </td>                    </tr>                </table>            </td>        </tr>        <tr>            <td style=\"background-image: url(footer-bg.png); height: 60px; padding: 0px 10px 20px 120px\">            <table style=\"margin-top: 5px\"><tr><td style=\"padding-right: 10px\"><span style=\"font-size: 14px\">                Dağıtım </span></td>            <td style=\"border-left-style: solid; border-left-color: #ffcea0; border-left-width: 1px;\">            <img class=\"style2\" src=\"1_sultanlar_logo.png\" style=\"padding: 3px 3px 3px 10px;\" /></td>            <td style=\"padding-left: 10px\">                <span style=\"font-size: 10px\"><i>Eyüp Sultan mh. Sekmen cd. No: 14 Sancaktepe / İSTANBUL</i><br /><i>Telefon: (+90 216) 561 50 00 Pbx</i><br /><i>Eposta: satis@sultanlar.com.tr</i></span></td></tr></table></td>        </tr>    </table></body></html>";

                // brosuru yaz
                if (File.Exists(txtCiktiYolu.Text + "\\Brosur.htm"))
                {
                    File.Delete(txtCiktiYolu.Text + "\\Brosur.htm");
                }
                StreamWriter sw = new StreamWriter(txtCiktiYolu.Text + "\\Brosur.htm", false, Encoding.Unicode);
                sw.Write(brosur);
                sw.Close();
                sw.Dispose();

                if (!cbKaynaktakiDosyalariSilme.Checked)
                    KaynaktakiDosyalariSil();

                webBrowser1.Navigate(txtCiktiYolu.Text + "\\Brosur.htm");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OnikiliNoBG()
        {
            try
            {
                Directory.CreateDirectory(txtCiktiYolu.Text);

                string bilgi1 = string.Empty, koliadedikismi1 = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />", koliadedi1 = string.Empty, urunaciklama1 = string.Empty,
                         bilgi2 = string.Empty, koliadedikismi2 = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />", koliadedi2 = string.Empty, urunaciklama2 = string.Empty,
                         bilgi3 = string.Empty, koliadedikismi3 = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />", koliadedi3 = string.Empty, urunaciklama3 = string.Empty,
                         bilgi4 = string.Empty, koliadedikismi4 = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />", koliadedi4 = string.Empty, urunaciklama4 = string.Empty,
                         bilgi5 = string.Empty, koliadedikismi5 = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />", koliadedi5 = string.Empty, urunaciklama5 = string.Empty,
                         bilgi6 = string.Empty, koliadedikismi6 = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />", koliadedi6 = string.Empty, urunaciklama6 = string.Empty,
                         bilgi7 = string.Empty, koliadedikismi7 = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />", koliadedi7 = string.Empty, urunaciklama7 = string.Empty,
                         bilgi8 = string.Empty, koliadedikismi8 = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />", koliadedi8 = string.Empty, urunaciklama8 = string.Empty,
                         bilgi9 = string.Empty, koliadedikismi9 = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />", koliadedi9 = string.Empty, urunaciklama9 = string.Empty,
                         bilgi10 = string.Empty, koliadedikismi10 = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />", koliadedi10 = string.Empty, urunaciklama10 = string.Empty,
                         bilgi11 = string.Empty, koliadedikismi11 = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />", koliadedi11 = string.Empty, urunaciklama11 = string.Empty,
                         bilgi12 = string.Empty, koliadedikismi12 = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />", koliadedi12 = string.Empty, urunaciklama12 = string.Empty;

                // tablo gerekli resimleri
                File.Copy("https://www.sultanlar.com.tr/sultanlarui/brosur/1_sultanlar_logo.png", txtCiktiYolu.Text + "\\1_sultanlar_logo.png", true);
                File.Copy("https://www.sultanlar.com.tr/sultanlarui/brosur/header-bg.png", txtCiktiYolu.Text + "\\header-bg.png", true);
                File.Copy("https://www.sultanlar.com.tr/sultanlarui/brosur/footer-bg.png", txtCiktiYolu.Text + "\\footer-bg.png", true);

                // şablon logosu
                if (File.Exists(txtDosyaYolu.Text + "\\logo.png"))
                {
                    File.Copy(txtDosyaYolu.Text + "\\logo.png", txtCiktiYolu.Text + "\\logo.png", true);
                }
                else
                {
                    File.Copy("https://www.sultanlar.com.tr/sultanlarui/brosur/1_sultanlar_logo.png", txtCiktiYolu.Text + "\\logo.png", true);
                }

                // urun resimleri ve barkodlari
                for (int i = 1; i <= 12; i++)
                {
                    //resim
                    if (File.Exists(txtDosyaYolu.Text + "\\" + i.ToString() + ".png") || File.Exists(txtDosyaYolu.Text + "\\" + i.ToString() + ".jpg"))
                    {
                        Image img = File.Exists(txtDosyaYolu.Text + "\\" + i.ToString() + ".png") ? Image.FromFile(txtDosyaYolu.Text + "\\" + i.ToString() + ".png") : Image.FromFile(txtDosyaYolu.Text + "\\" + i.ToString() + ".jpg");
                        Image kucukimg;
                        if (img.Height > img.Width)
                        {
                            double aspectRatio = Convert.ToDouble(img.Height) / img.Width;
                            double yukseklik = 126;
                            double genislik = yukseklik / aspectRatio;
                            kucukimg = Resim.ResimKucult(img, Convert.ToInt32(genislik));
                        }
                        else
                        {
                            kucukimg = Resim.ResimKucult(img, 126);
                        }
                        kucukimg.Save(txtCiktiYolu.Text + "\\" + i.ToString() + ".png");
                    }
                    else
                    {
                        File.Copy("https://www.sultanlar.com.tr/sultanlarui/brosur/bos.png", txtCiktiYolu.Text + "\\" + i.ToString() + ".png", true);
                    }

                    // barkod
                    if (File.Exists(txtDosyaYolu.Text + "\\" + i.ToString() + "barkod.png"))
                    {
                        File.Copy(txtDosyaYolu.Text + "\\" + i.ToString() + "barkod.png", txtCiktiYolu.Text + "\\" + i.ToString() + "barkod.png", true);
                    }
                    else
                    {
                        File.Copy("https://www.sultanlar.com.tr/sultanlarui/brosur/bos.png", txtCiktiYolu.Text + "\\" + i.ToString() + "barkod.png", true);
                    }
                }

                // urun aciklamalari
                if (File.Exists(txtDosyaYolu.Text + "\\1.txt"))
                {
                    bilgi1 = File.ReadAllText(txtDosyaYolu.Text + "\\1.txt", Encoding.GetEncoding("iso-8859-9")).ToUpper();
                    koliadedikismi1 = koliadedi;
                    koliadedi1 = bilgi1.Substring(0, bilgi1.IndexOf("\r\n"));
                    urunaciklama1 = bilgi1.Substring(bilgi1.IndexOf("\r\n") + 1);
                }
                if (File.Exists(txtDosyaYolu.Text + "\\2.txt"))
                {
                    bilgi2 = File.ReadAllText(txtDosyaYolu.Text + "\\2.txt", Encoding.GetEncoding("iso-8859-9")).ToUpper();
                    koliadedikismi2 = koliadedi;
                    koliadedi2 = bilgi2.Substring(0, bilgi2.IndexOf("\r\n"));
                    urunaciklama2 = bilgi2.Substring(bilgi2.IndexOf("\r\n") + 1);
                }
                if (File.Exists(txtDosyaYolu.Text + "\\3.txt"))
                {
                    bilgi3 = File.ReadAllText(txtDosyaYolu.Text + "\\3.txt", Encoding.GetEncoding("iso-8859-9")).ToUpper();
                    koliadedikismi3 = koliadedi;
                    koliadedi3 = bilgi3.Substring(0, bilgi3.IndexOf("\r\n"));
                    urunaciklama3 = bilgi3.Substring(bilgi3.IndexOf("\r\n") + 1);
                }
                if (File.Exists(txtDosyaYolu.Text + "\\4.txt"))
                {
                    bilgi4 = File.ReadAllText(txtDosyaYolu.Text + "\\4.txt", Encoding.GetEncoding("iso-8859-9")).ToUpper();
                    koliadedikismi4 = koliadedi;
                    koliadedi4 = bilgi4.Substring(0, bilgi4.IndexOf("\r\n"));
                    urunaciklama4 = bilgi4.Substring(bilgi4.IndexOf("\r\n") + 1);
                }
                if (File.Exists(txtDosyaYolu.Text + "\\5.txt"))
                {
                    bilgi5 = File.ReadAllText(txtDosyaYolu.Text + "\\5.txt", Encoding.GetEncoding("iso-8859-9")).ToUpper();
                    koliadedikismi5 = koliadedi;
                    koliadedi5 = bilgi5.Substring(0, bilgi5.IndexOf("\r\n"));
                    urunaciklama5 = bilgi5.Substring(bilgi5.IndexOf("\r\n") + 1);
                }
                if (File.Exists(txtDosyaYolu.Text + "\\6.txt"))
                {
                    bilgi6 = File.ReadAllText(txtDosyaYolu.Text + "\\6.txt", Encoding.GetEncoding("iso-8859-9")).ToUpper();
                    koliadedikismi6 = koliadedi;
                    koliadedi6 = bilgi6.Substring(0, bilgi6.IndexOf("\r\n"));
                    urunaciklama6 = bilgi6.Substring(bilgi6.IndexOf("\r\n") + 1);
                }
                if (File.Exists(txtDosyaYolu.Text + "\\7.txt"))
                {
                    bilgi7 = File.ReadAllText(txtDosyaYolu.Text + "\\7.txt", Encoding.GetEncoding("iso-8859-9")).ToUpper();
                    koliadedikismi7 = koliadedi;
                    koliadedi7 = bilgi7.Substring(0, bilgi7.IndexOf("\r\n"));
                    urunaciklama7 = bilgi7.Substring(bilgi7.IndexOf("\r\n") + 1);
                }
                if (File.Exists(txtDosyaYolu.Text + "\\8.txt"))
                {
                    bilgi8 = File.ReadAllText(txtDosyaYolu.Text + "\\8.txt", Encoding.GetEncoding("iso-8859-9")).ToUpper();
                    koliadedikismi8 = koliadedi;
                    koliadedi8 = bilgi8.Substring(0, bilgi8.IndexOf("\r\n"));
                    urunaciklama8 = bilgi8.Substring(bilgi8.IndexOf("\r\n") + 1);
                }
                if (File.Exists(txtDosyaYolu.Text + "\\9.txt"))
                {
                    bilgi9 = File.ReadAllText(txtDosyaYolu.Text + "\\9.txt", Encoding.GetEncoding("iso-8859-9")).ToUpper();
                    koliadedikismi9 = koliadedi;
                    koliadedi9 = bilgi9.Substring(0, bilgi9.IndexOf("\r\n"));
                    urunaciklama9 = bilgi9.Substring(bilgi9.IndexOf("\r\n") + 1);
                }
                if (File.Exists(txtDosyaYolu.Text + "\\10.txt"))
                {
                    bilgi10 = File.ReadAllText(txtDosyaYolu.Text + "\\10.txt", Encoding.GetEncoding("iso-8859-9")).ToUpper();
                    koliadedikismi10 = koliadedi;
                    koliadedi10 = bilgi10.Substring(0, bilgi10.IndexOf("\r\n"));
                    urunaciklama10 = bilgi10.Substring(bilgi10.IndexOf("\r\n") + 1);
                }
                if (File.Exists(txtDosyaYolu.Text + "\\11.txt"))
                {
                    bilgi11 = File.ReadAllText(txtDosyaYolu.Text + "\\11.txt", Encoding.GetEncoding("iso-8859-9")).ToUpper();
                    koliadedikismi11 = koliadedi;
                    koliadedi11 = bilgi11.Substring(0, bilgi11.IndexOf("\r\n"));
                    urunaciklama11 = bilgi11.Substring(bilgi11.IndexOf("\r\n") + 1);
                }
                if (File.Exists(txtDosyaYolu.Text + "\\12.txt"))
                {
                    bilgi12 = File.ReadAllText(txtDosyaYolu.Text + "\\12.txt", Encoding.GetEncoding("iso-8859-9")).ToUpper();
                    koliadedikismi12 = koliadedi;
                    koliadedi12 = bilgi12.Substring(0, bilgi12.IndexOf("\r\n"));
                    urunaciklama12 = bilgi12.Substring(bilgi12.IndexOf("\r\n") + 1);
                }

                // brosuru olustur
                string brosur = "<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\"><html xmlns=\"http://www.w3.org/1999/xhtml\" ><head>    <title>Untitled Page</title>    <style type=\"text/css\">        .style1 {            width: 730px;            height: 929px;            font-family:Tahoma;             font-size: 7px;            font-weight: normal;        }        .style2        {            width: 138px;            height: 43px;        }        .style3        { background-color: " + txtRenk.Text + "; } .style4        {            width: 100px;            height: 37px;        }          </style></head><body style=\"margin: 0px 0px 0px 10px\">    <table cellpadding=\"0\" cellspacing=\"0\" class=\"style1\"         style=\"border: 1px solid #ffcea0\">        <tr>            <td style=\"background-image: url(header-bg.png); height: 60px; padding: 10px 10px 0px 100px\">            " +
                        "<img src=\"logo.png\"                     style=\"padding: 10px 3px 3px 10px; height: 48px;\" /></td>        </tr>        <tr>            <td>                <table cellpadding=\"0\" cellspacing=\"0\" class=\"style1\">                    <tr>                        <td align=\"center\">                            <table cellpadding=\"0\" cellspacing=\"0\"                                                                                                 style=\"margin: 5px; padding: 0px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: 3px; border-bottom-width: 3px; border-left-width: 3px; border-right-color: #ffcea0; border-bottom-color: #ffcea0; border-left-color: #ffcea0;\">                                <tr>                                    <td colspan=\"2\"                                         style=\"padding: 5px; text-align: center; height: 136px; width: 136px;\" class=\"style3\">                                        " +
                        "<img alt=\"\" src=\"1.png\" /></td>                                </tr>                                <tr>                                    " +
                        "<td style=\"border-width: 1px; border-color: #FFCEA0; padding: 5px; text-align: center; border-top-style: solid; border-bottom-style: solid;\">                                        " +
                        "<b>" + urunaciklama1 + "</b></td>                                </tr>                                <tr>                                    <td colspan=\"2\" style=\"padding: 5px; text-align: center;\">                                        " +
                        "<img class=\"style4\" src=\"1barkod.png\" /></td>                                </tr>                            </table>                        </td>                        " +
                        "<td align=\"center\">                            <table cellpadding=\"0\" cellspacing=\"0\"                                                                                                                                 style=\"margin: 5px; padding: 0px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: 3px; border-bottom-width: 3px; border-left-width: 3px; border-right-color: #ffcea0; border-bottom-color: #ffcea0; border-left-color: #ffcea0;\">                                <tr>                                    <td colspan=\"2\"                                         style=\"padding: 5px; text-align: center; height: 136px; width: 136px;\" class=\"style3\">                                        " +
                        "<img alt=\"\" src=\"2.png\" /></td>                                </tr>                                <tr>                                    " +
                        "<td style=\"border-width: 1px; border-color: #FFCEA0; padding: 5px; text-align: center; border-top-style: solid; border-bottom-style: solid;\">                                        " +
                        "<b>" + urunaciklama2 + "</b></td>                                </tr>                                <tr>                                    <td colspan=\"2\" style=\"padding: 5px; text-align: center;\">                                        " +
                        "<img class=\"style4\" src=\"2barkod.png\" /></td>                                </tr>                            </table>                        </td>                        " +
                        "<td align=\"center\">                            <table cellpadding=\"0\" cellspacing=\"0\"                                                                                                                                 style=\"margin: 5px; padding: 0px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: 3px; border-bottom-width: 3px; border-left-width: 3px; border-right-color: #ffcea0; border-bottom-color: #ffcea0; border-left-color: #ffcea0;\">                                <tr>                                    <td colspan=\"2\"                                         style=\"padding: 5px; text-align: center; height: 136px; width: 136px;\" class=\"style3\">                                        " +
                        "<img alt=\"\" src=\"3.png\" /></td>                                </tr>                                <tr>                                    " +
                        "<td style=\"border-width: 1px; border-color: #FFCEA0; padding: 5px; text-align: center; border-top-style: solid; border-bottom-style: solid;\">                                        " +
                        "<b>" + urunaciklama3 + "</b></td>                                </tr>                                <tr>                                    <td colspan=\"2\" style=\"padding: 5px; text-align: center;\">                                        " +
                        "<img class=\"style4\" src=\"3barkod.png\" /></td>                                </tr>                            </table>                        </td>                    </tr>                    " +
                        "<tr>                        <td align=\"center\">                            <table cellpadding=\"0\" cellspacing=\"0\"                                                                                                                                 style=\"margin: 5px; padding: 0px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: 3px; border-bottom-width: 3px; border-left-width: 3px; border-right-color: #ffcea0; border-bottom-color: #ffcea0; border-left-color: #ffcea0;\">                                <tr>                                    <td colspan=\"2\"                                         style=\"padding: 5px; text-align: center; height: 136px; width: 136px;\" class=\"style3\">                                        " +
                        "<img alt=\"\" src=\"4.png\" /></td>                                </tr>                                <tr>                                    " +
                        "<td style=\"border-width: 1px; border-color: #FFCEA0; padding: 5px; text-align: center; border-top-style: solid; border-bottom-style: solid;\">                                        " +
                        "<b>" + urunaciklama4 + "</b></td>                                </tr>                                <tr>                                    <td colspan=\"2\" style=\"padding: 5px; text-align: center;\">                                        " +
                        "<img class=\"style4\" src=\"4barkod.png\" /></td>                                </tr>                            </table>                        </td>                        " +
                        "<td align=\"center\">                            <table cellpadding=\"0\" cellspacing=\"0\"                                                                                                                                 style=\"margin: 5px; padding: 0px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: 3px; border-bottom-width: 3px; border-left-width: 3px; border-right-color: #ffcea0; border-bottom-color: #ffcea0; border-left-color: #ffcea0;\">                                <tr>                                    <td colspan=\"2\"                                         style=\"padding: 5px; text-align: center; height: 136px; width: 136px;\" class=\"style3\">                                        " +
                        "<img alt=\"\" src=\"5.png\" /></td>                                </tr>                                <tr>                                    " +
                        "<td style=\"border-width: 1px; border-color: #FFCEA0; padding: 5px; text-align: center; border-top-style: solid; border-bottom-style: solid;\">                                        " +
                        "<b>" + urunaciklama5 + "</b></td>                                </tr>                                <tr>                                    <td colspan=\"2\" style=\"padding: 5px; text-align: center;\">                                        " +
                        "<img class=\"style4\" src=\"5barkod.png\" /></td>                                </tr>                            </table>                        </td>                        " +
                        "<td align=\"center\">                            <table cellpadding=\"0\" cellspacing=\"0\"                                                                                                                                 style=\"margin: 5px; padding: 0px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: 3px; border-bottom-width: 3px; border-left-width: 3px; border-right-color: #ffcea0; border-bottom-color: #ffcea0; border-left-color: #ffcea0;\">                                <tr>                                    <td colspan=\"2\"                                         style=\"padding: 5px; text-align: center; height: 136px; width: 136px;\" class=\"style3\">                                        " +
                        "<img alt=\"\" src=\"6.png\" /></td>                                </tr>                                <tr>                                    " +
                        "<td style=\"border-width: 1px; border-color: #FFCEA0; padding: 5px; text-align: center; border-top-style: solid; border-bottom-style: solid;\">                                        " +
                        "<b>" + urunaciklama6 + "</b></td>                                </tr>                                <tr>                                    <td colspan=\"2\" style=\"padding: 5px; text-align: center;\">                                        " +
                        "<img class=\"style4\" src=\"6barkod.png\" /></td>                                </tr>                            </table>                        </td>                    </tr>                    " +
                        "<tr>                        <td align=\"center\">                            <table cellpadding=\"0\" cellspacing=\"0\"                                                                                                                                 style=\"margin: 5px; padding: 0px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: 3px; border-bottom-width: 3px; border-left-width: 3px; border-right-color: #ffcea0; border-bottom-color: #ffcea0; border-left-color: #ffcea0;\">                                <tr>                                    <td colspan=\"2\"                                         style=\"padding: 5px; text-align: center; height: 136px; width: 136px;\" class=\"style3\">                                        " +
                        "<img alt=\"\" src=\"7.png\" /></td>                                </tr>                                <tr>                                    " +
                        "<td style=\"border-width: 1px; border-color: #FFCEA0; padding: 5px; text-align: center; border-top-style: solid; border-bottom-style: solid;\">                                        " +
                        "<b>" + urunaciklama7 + "</b></td>                                </tr>                                <tr>                                    <td colspan=\"2\" style=\"padding: 5px; text-align: center;\">                                        " +
                        "<img class=\"style4\" src=\"7barkod.png\" /></td>                                </tr>                            </table>                        </td>                        " +
                        "<td align=\"center\">                            <table cellpadding=\"0\" cellspacing=\"0\"                                                                                                                                 style=\"margin: 5px; padding: 0px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: 3px; border-bottom-width: 3px; border-left-width: 3px; border-right-color: #ffcea0; border-bottom-color: #ffcea0; border-left-color: #ffcea0;\">                                <tr>                                    <td colspan=\"2\"                                         style=\"padding: 5px; text-align: center; height: 136px; width: 136px;\" class=\"style3\">                                        " +
                        "<img alt=\"\" src=\"8.png\" /></td>                                </tr>                                <tr>                                    " +
                        "<td style=\"border-width: 1px; border-color: #FFCEA0; padding: 5px; text-align: center; border-top-style: solid; border-bottom-style: solid;\">                                        " +
                        "<b>" + urunaciklama8 + "</b></td>                                </tr>                                <tr>                                    <td colspan=\"2\" style=\"padding: 5px; text-align: center;\">                                        " +
                        "<img class=\"style4\" src=\"8barkod.png\" /></td>                                </tr>                            </table>                        </td>                        " +
                        "<td align=\"center\">                            <table cellpadding=\"0\" cellspacing=\"0\"                                                                                                                                 style=\"margin: 5px; padding: 0px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: 3px; border-bottom-width: 3px; border-left-width: 3px; border-right-color: #ffcea0; border-bottom-color: #ffcea0; border-left-color: #ffcea0;\">                                <tr>                                    <td colspan=\"2\"                                         style=\"padding: 5px; text-align: center; height: 136px; width: 136px;\" class=\"style3\">                                        " +
                        "<img alt=\"\" src=\"9.png\" /></td>                                </tr>                                <tr>                                    " +
                        "<td style=\"border-width: 1px; border-color: #FFCEA0; padding: 5px; text-align: center; border-top-style: solid; border-bottom-style: solid;\">                                        " +
                        "<b>" + urunaciklama9 + "</b></td>                                </tr>                                <tr>                                    <td colspan=\"2\" style=\"padding: 5px; text-align: center;\">                                        " +
                        "<img class=\"style4\" src=\"9barkod.png\" /></td>                                </tr>                            </table>                        </td>                    </tr>                    " +
                        "<tr>                        <td align=\"center\">                            <table cellpadding=\"0\" cellspacing=\"0\"                                                                                                                                 style=\"margin: 5px; padding: 0px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: 3px; border-bottom-width: 3px; border-left-width: 3px; border-right-color: #ffcea0; border-bottom-color: #ffcea0; border-left-color: #ffcea0;\">                                <tr>                                    <td colspan=\"2\"                                         style=\"padding: 5px; text-align: center; height: 136px; width: 136px;\" class=\"style3\">                                        " +
                        "<img alt=\"\" src=\"10.png\" /></td>                                </tr>                                <tr>                                    " +
                        "<td style=\"border-width: 1px; border-color: #FFCEA0; padding: 5px; text-align: center; border-top-style: solid; border-bottom-style: solid;\">                                        " +
                        "<b>" + urunaciklama10 + "</b></td>                                </tr>                                <tr>                                    <td colspan=\"2\" style=\"padding: 5px; text-align: center;\">                                        " +
                        "<img class=\"style4\" src=\"10barkod.png\" /></td>                                </tr>                            </table>                        </td>                        " +
                        "<td align=\"center\">                            <table cellpadding=\"0\" cellspacing=\"0\"                                                                                                                                 style=\"margin: 5px; padding: 0px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: 3px; border-bottom-width: 3px; border-left-width: 3px; border-right-color: #ffcea0; border-bottom-color: #ffcea0; border-left-color: #ffcea0;\">                                <tr>                                    <td colspan=\"2\"                                         style=\"padding: 5px; text-align: center; height: 136px; width: 136px;\" class=\"style3\">                                        " +
                        "<img alt=\"\" src=\"11.png\" /></td>                                </tr>                                <tr>                                    " +
                        "<td style=\"border-width: 1px; border-color: #FFCEA0; padding: 5px; text-align: center; border-top-style: solid; border-bottom-style: solid;\">                                        " +
                        "<b>" + urunaciklama11 + "</b></td>                                </tr>                                <tr>                                    <td colspan=\"2\" style=\"padding: 5px; text-align: center;\">                                        " +
                        "<img class=\"style4\" src=\"11barkod.png\" /></td>                                </tr>                            </table>                        </td>                        " +
                        "<td align=\"center\">                            <table cellpadding=\"0\" cellspacing=\"0\"                                                                                                                                 style=\"margin: 5px; padding: 0px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: 3px; border-bottom-width: 3px; border-left-width: 3px; border-right-color: #ffcea0; border-bottom-color: #ffcea0; border-left-color: #ffcea0;\">                                <tr>                                    <td colspan=\"2\"                                         style=\"padding: 5px; text-align: center; height: 136px; width: 136px;\" class=\"style3\">                                        " +
                        "<img alt=\"\" src=\"12.png\" /></td>                                </tr>                                <tr>                                    " +
                        "<td style=\"border-width: 1px; border-color: #FFCEA0; padding: 5px; text-align: center; border-top-style: solid; border-bottom-style: solid;\">                                        " +
                        "<b>" + urunaciklama12 + "</b></td>                                </tr>                                <tr>                                    <td colspan=\"2\" style=\"padding: 5px; text-align: center;\">                                        " +
                        "<img class=\"style4\" src=\"12barkod.png\" /></td>                                </tr>                            </table>                        </td>                    </tr>                </table>            </td>        </tr>        <tr>            <td style=\"background-image: url(footer-bg.png); height: 60px; padding: 0px 10px 20px 120px\">            <table style=\"margin-top: 5px\"><tr><td style=\"padding-right: 10px\"><span style=\"font-size: 14px\">                Dağıtım </span></td>            <td style=\"border-left-style: solid; border-left-color: #ffcea0; border-left-width: 1px;\">            <img class=\"style2\" src=\"1_sultanlar_logo.png\" style=\"padding: 3px 3px 3px 10px;\" /></td>            <td style=\"padding-left: 10px\">                <span style=\"font-size: 10px\"><i>Eyüp Sultan mh. Sekmen cd. No: 14 Sancaktepe / İSTANBUL</i><br /><i>Telefon: (+90 216) 561 50 00 Pbx</i><br /><i>Eposta: satis@sultanlar.com.tr</i></span></td></tr></table></td>        </tr>    </table></body></html>";

                // brosuru yaz
                if (File.Exists(txtCiktiYolu.Text + "\\Brosur.htm"))
                {
                    File.Delete(txtCiktiYolu.Text + "\\Brosur.htm");
                }
                StreamWriter sw = new StreamWriter(txtCiktiYolu.Text + "\\Brosur.htm", false, Encoding.Unicode);
                sw.Write(brosur);
                sw.Close();
                sw.Dispose();

                if (!cbKaynaktakiDosyalariSilme.Checked)
                    KaynaktakiDosyalariSil();

                webBrowser1.Navigate(txtCiktiYolu.Text + "\\Brosur.htm");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DokuzluNoBG()
        {
            try
            {
                Directory.CreateDirectory(txtCiktiYolu.Text);

                string bilgi1 = string.Empty, koliadedikismi1 = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />", koliadedi1 = string.Empty, urunaciklama1 = string.Empty,
                         bilgi2 = string.Empty, koliadedikismi2 = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />", koliadedi2 = string.Empty, urunaciklama2 = string.Empty,
                         bilgi3 = string.Empty, koliadedikismi3 = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />", koliadedi3 = string.Empty, urunaciklama3 = string.Empty,
                         bilgi4 = string.Empty, koliadedikismi4 = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />", koliadedi4 = string.Empty, urunaciklama4 = string.Empty,
                         bilgi5 = string.Empty, koliadedikismi5 = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />", koliadedi5 = string.Empty, urunaciklama5 = string.Empty,
                         bilgi6 = string.Empty, koliadedikismi6 = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />", koliadedi6 = string.Empty, urunaciklama6 = string.Empty,
                         bilgi7 = string.Empty, koliadedikismi7 = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />", koliadedi7 = string.Empty, urunaciklama7 = string.Empty,
                         bilgi8 = string.Empty, koliadedikismi8 = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />", koliadedi8 = string.Empty, urunaciklama8 = string.Empty,
                         bilgi9 = string.Empty, koliadedikismi9 = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />", koliadedi9 = string.Empty, urunaciklama9 = string.Empty;

                // tablo gerekli resimleri
                File.Copy("https://www.sultanlar.com.tr/sultanlarui/brosur/1_sultanlar_logo.png", txtCiktiYolu.Text + "\\1_sultanlar_logo.png", true);
                File.Copy("https://www.sultanlar.com.tr/sultanlarui/brosur/header-bg.png", txtCiktiYolu.Text + "\\header-bg.png", true);
                File.Copy("https://www.sultanlar.com.tr/sultanlarui/brosur/footer-bg.png", txtCiktiYolu.Text + "\\footer-bg.png", true);

                // şablon logosu
                if (File.Exists(txtDosyaYolu.Text + "\\logo.png"))
                {
                    File.Copy(txtDosyaYolu.Text + "\\logo.png", txtCiktiYolu.Text + "\\logo.png", true);
                }
                else
                {
                    File.Copy("https://www.sultanlar.com.tr/sultanlarui/brosur/1_sultanlar_logo.png", txtCiktiYolu.Text + "\\logo.png", true);
                }

                // urun resimleri ve barkodlari
                for (int i = 1; i <= 9; i++)
                {
                    //resim
                    if (File.Exists(txtDosyaYolu.Text + "\\" + i.ToString() + ".png") || File.Exists(txtDosyaYolu.Text + "\\" + i.ToString() + ".jpg"))
                    {
                        Image img = File.Exists(txtDosyaYolu.Text + "\\" + i.ToString() + ".png") ? Image.FromFile(txtDosyaYolu.Text + "\\" + i.ToString() + ".png") : Image.FromFile(txtDosyaYolu.Text + "\\" + i.ToString() + ".jpg");
                        Image kucukimg;
                        if (img.Height > img.Width)
                        {
                            double aspectRatio = Convert.ToDouble(img.Height) / img.Width;
                            double yukseklik = 180;
                            double genislik = yukseklik / aspectRatio;
                            kucukimg = Resim.ResimKucult(img, Convert.ToInt32(genislik));
                        }
                        else
                        {
                            kucukimg = Resim.ResimKucult(img, 180);
                        }
                        kucukimg.Save(txtCiktiYolu.Text + "\\" + i.ToString() + ".png");
                    }
                    else
                    {
                        File.Copy("https://www.sultanlar.com.tr/sultanlarui/brosur/bos.png", txtCiktiYolu.Text + "\\" + i.ToString() + ".png", true);
                    }

                    // barkod
                    if (File.Exists(txtDosyaYolu.Text + "\\" + i.ToString() + "barkod.png"))
                    {
                        File.Copy(txtDosyaYolu.Text + "\\" + i.ToString() + "barkod.png", txtCiktiYolu.Text + "\\" + i.ToString() + "barkod.png", true);
                    }
                    else
                    {
                        File.Copy("https://www.sultanlar.com.tr/sultanlarui/brosur/bos.png", txtCiktiYolu.Text + "\\" + i.ToString() + "barkod.png", true);
                    }
                }

                // urun aciklamalari
                if (File.Exists(txtDosyaYolu.Text + "\\1.txt"))
                {
                    bilgi1 = File.ReadAllText(txtDosyaYolu.Text + "\\1.txt", Encoding.GetEncoding("iso-8859-9")).ToUpper();
                    koliadedikismi1 = koliadedi;
                    koliadedi1 = bilgi1.Substring(0, bilgi1.IndexOf("\r\n"));
                    urunaciklama1 = bilgi1.Substring(bilgi1.IndexOf("\r\n") + 1);
                }
                if (File.Exists(txtDosyaYolu.Text + "\\2.txt"))
                {
                    bilgi2 = File.ReadAllText(txtDosyaYolu.Text + "\\2.txt", Encoding.GetEncoding("iso-8859-9")).ToUpper();
                    koliadedikismi2 = koliadedi;
                    koliadedi2 = bilgi2.Substring(0, bilgi2.IndexOf("\r\n"));
                    urunaciklama2 = bilgi2.Substring(bilgi2.IndexOf("\r\n") + 1);
                }
                if (File.Exists(txtDosyaYolu.Text + "\\3.txt"))
                {
                    bilgi3 = File.ReadAllText(txtDosyaYolu.Text + "\\3.txt", Encoding.GetEncoding("iso-8859-9")).ToUpper();
                    koliadedikismi3 = koliadedi;
                    koliadedi3 = bilgi3.Substring(0, bilgi3.IndexOf("\r\n"));
                    urunaciklama3 = bilgi3.Substring(bilgi3.IndexOf("\r\n") + 1);
                }
                if (File.Exists(txtDosyaYolu.Text + "\\4.txt"))
                {
                    bilgi4 = File.ReadAllText(txtDosyaYolu.Text + "\\4.txt", Encoding.GetEncoding("iso-8859-9")).ToUpper();
                    koliadedikismi4 = koliadedi;
                    koliadedi4 = bilgi4.Substring(0, bilgi4.IndexOf("\r\n"));
                    urunaciklama4 = bilgi4.Substring(bilgi4.IndexOf("\r\n") + 1);
                }
                if (File.Exists(txtDosyaYolu.Text + "\\5.txt"))
                {
                    bilgi5 = File.ReadAllText(txtDosyaYolu.Text + "\\5.txt", Encoding.GetEncoding("iso-8859-9")).ToUpper();
                    koliadedikismi5 = koliadedi;
                    koliadedi5 = bilgi5.Substring(0, bilgi5.IndexOf("\r\n"));
                    urunaciklama5 = bilgi5.Substring(bilgi5.IndexOf("\r\n") + 1);
                }
                if (File.Exists(txtDosyaYolu.Text + "\\6.txt"))
                {
                    bilgi6 = File.ReadAllText(txtDosyaYolu.Text + "\\6.txt", Encoding.GetEncoding("iso-8859-9")).ToUpper();
                    koliadedikismi6 = koliadedi;
                    koliadedi6 = bilgi6.Substring(0, bilgi6.IndexOf("\r\n"));
                    urunaciklama6 = bilgi6.Substring(bilgi6.IndexOf("\r\n") + 1);
                }
                if (File.Exists(txtDosyaYolu.Text + "\\7.txt"))
                {
                    bilgi7 = File.ReadAllText(txtDosyaYolu.Text + "\\7.txt", Encoding.GetEncoding("iso-8859-9")).ToUpper();
                    koliadedikismi7 = koliadedi;
                    koliadedi7 = bilgi7.Substring(0, bilgi7.IndexOf("\r\n"));
                    urunaciklama7 = bilgi7.Substring(bilgi7.IndexOf("\r\n") + 1);
                }
                if (File.Exists(txtDosyaYolu.Text + "\\8.txt"))
                {
                    bilgi8 = File.ReadAllText(txtDosyaYolu.Text + "\\8.txt", Encoding.GetEncoding("iso-8859-9")).ToUpper();
                    koliadedikismi8 = koliadedi;
                    koliadedi8 = bilgi8.Substring(0, bilgi8.IndexOf("\r\n"));
                    urunaciklama8 = bilgi8.Substring(bilgi8.IndexOf("\r\n") + 1);
                }
                if (File.Exists(txtDosyaYolu.Text + "\\9.txt"))
                {
                    bilgi9 = File.ReadAllText(txtDosyaYolu.Text + "\\9.txt", Encoding.GetEncoding("iso-8859-9")).ToUpper();
                    koliadedikismi9 = koliadedi;
                    koliadedi9 = bilgi9.Substring(0, bilgi9.IndexOf("\r\n"));
                    urunaciklama9 = bilgi9.Substring(bilgi9.IndexOf("\r\n") + 1);
                }

                // brosuru olustur
                string brosur = "<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\"><html xmlns=\"http://www.w3.org/1999/xhtml\" ><head>    <title>Untitled Page</title>    <style type=\"text/css\">        .style1 {            width: 730px;            height: 929px;            font-family: Tahoma;            font-size: 9px;            font-weight: normal;        }        .style2        {            width: 138px;            height: 43px;        }        .style3        { background-color: " + txtRenk.Text + "; } .style4        {            width: 120px;            height: 55px;        }        </style></head><body style=\"margin: 0px 0px 0px 10px\">    <table cellpadding=\"0\" cellspacing=\"0\" class=\"style1\"         style=\"border: 1px solid #ffcea0\">        <tr>            <td style=\"background-image: url(header-bg.png); height: 60px; padding: 10px 10px 0px 100px\">            " +
                        "<img src=\"logo.png\"                     style=\"padding: 10px 3px 3px 10px; height: 48px;\" /></td>        </tr>        <tr>            <td>                <table cellpadding=\"0\" cellspacing=\"0\" class=\"style1\">                    <tr>                        <td align=\"center\">                            <table cellpadding=\"0\" cellspacing=\"0\"                                                                                                 style=\"margin: 5px; padding: 0px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: 3px; border-bottom-width: 3px; border-left-width: 3px; border-right-color: #ffcea0; border-bottom-color: #ffcea0; border-left-color: #ffcea0;\">                                <tr>                                    <td colspan=\"2\"                                         style=\"padding: 5px; text-align: center; width: 190px; height: 190px;\" class=\"style3\">                                        " +
                        "<img alt=\"\" src=\"1.png\" /></td>                                </tr>                                <tr>                                    " +
                        "<td style=\"border-width: 1px; border-color: #FFCEA0; padding: 5px; text-align: center; border-top-style: solid; border-bottom-style: solid;\">                                        " +
                        "<b>" + urunaciklama1 + "</b></td>                                </tr>                                <tr>                                    <td colspan=\"2\" style=\"padding: 5px; text-align: center;\">                                        " +
                        "<img class=\"style4\" src=\"1barkod.png\" /></td>                                </tr>                            </table>                        </td>                        " +
                        "<td align=\"center\">                            <table cellpadding=\"0\" cellspacing=\"0\"                                                                                                                                 style=\"margin: 5px; padding: 0px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: 3px; border-bottom-width: 3px; border-left-width: 3px; border-right-color: #ffcea0; border-bottom-color: #ffcea0; border-left-color: #ffcea0;\">                                <tr>                                    <td colspan=\"2\"                                         style=\"padding: 5px; text-align: center; width: 190px; height: 190px;\" class=\"style3\">                                        " +
                        "<img alt=\"\" src=\"2.png\" /></td>                                </tr>                                <tr>                                    " +
                        "<td style=\"border-width: 1px; border-color: #FFCEA0; padding: 5px; text-align: center; border-top-style: solid; border-bottom-style: solid;\">                                        " +
                        "<b>" + urunaciklama2 + "</b></td>                                </tr>                                <tr>                                    <td colspan=\"2\" style=\"padding: 5px; text-align: center;\">                                        " +
                        "<img class=\"style4\" src=\"2barkod.png\" /></td>                                </tr>                            </table>                        </td>                        " +
                        "<td align=\"center\">                            <table cellpadding=\"0\" cellspacing=\"0\"                                                                                                                                 style=\"margin: 5px; padding: 0px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: 3px; border-bottom-width: 3px; border-left-width: 3px; border-right-color: #ffcea0; border-bottom-color: #ffcea0; border-left-color: #ffcea0;\">                                <tr>                                    <td colspan=\"2\"                                         style=\"padding: 5px; text-align: center; width: 190px; height: 190px;\" class=\"style3\">                                        " +
                        "<img alt=\"\" src=\"3.png\" /></td>                                </tr>                                <tr>                                    " +
                        "<td style=\"border-width: 1px; border-color: #FFCEA0; padding: 5px; text-align: center; border-top-style: solid; border-bottom-style: solid;\">                                        " +
                        "<b>" + urunaciklama3 + "</b></td>                                </tr>                                <tr>                                    <td colspan=\"2\" style=\"padding: 5px; text-align: center;\">                                        " +
                        "<img class=\"style4\" src=\"3barkod.png\" /></td>                                </tr>                            </table>                        </td>                    </tr>                    " +
                        "<tr>                        <td align=\"center\">                            <table cellpadding=\"0\" cellspacing=\"0\"                                                                                                                                 style=\"margin: 5px; padding: 0px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: 3px; border-bottom-width: 3px; border-left-width: 3px; border-right-color: #ffcea0; border-bottom-color: #ffcea0; border-left-color: #ffcea0;\">                                <tr>                                    <td colspan=\"2\"                                         style=\"padding: 5px; text-align: center; width: 190px; height: 190px;\" class=\"style3\">                                        " +
                        "<img alt=\"\" src=\"4.png\" /></td>                                </tr>                                <tr>                                    " +
                        "<td style=\"border-width: 1px; border-color: #FFCEA0; padding: 5px; text-align: center; border-top-style: solid; border-bottom-style: solid;\">                                        " +
                        "<b>" + urunaciklama4 + "</b></td>                                </tr>                                <tr>                                    <td colspan=\"2\" style=\"padding: 5px; text-align: center;\">                                        " +
                        "<img class=\"style4\" src=\"4barkod.png\" /></td>                                </tr>                            </table>                        </td>                        " +
                        "<td align=\"center\">                            <table cellpadding=\"0\" cellspacing=\"0\"                                                                                                                                 style=\"margin: 5px; padding: 0px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: 3px; border-bottom-width: 3px; border-left-width: 3px; border-right-color: #ffcea0; border-bottom-color: #ffcea0; border-left-color: #ffcea0;\">                                <tr>                                    <td colspan=\"2\"                                         style=\"padding: 5px; text-align: center; width: 190px; height: 190px;\" class=\"style3\">                                        " +
                        "<img alt=\"\" src=\"5.png\" /></td>                                </tr>                                <tr>                                    " +
                        "<td style=\"border-width: 1px; border-color: #FFCEA0; padding: 5px; text-align: center; border-top-style: solid; border-bottom-style: solid;\">                                        " +
                        "<b>" + urunaciklama5 + "</b></td>                                </tr>                                <tr>                                    <td colspan=\"2\" style=\"padding: 5px; text-align: center;\">                                        " +
                        "<img class=\"style4\" src=\"5barkod.png\" /></td>                                </tr>                            </table>                        </td>                        " +
                        "<td align=\"center\">                            <table cellpadding=\"0\" cellspacing=\"0\"                                                                                                                                 style=\"margin: 5px; padding: 0px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: 3px; border-bottom-width: 3px; border-left-width: 3px; border-right-color: #ffcea0; border-bottom-color: #ffcea0; border-left-color: #ffcea0;\">                                <tr>                                    <td colspan=\"2\"                                         style=\"padding: 5px; text-align: center; width: 190px; height: 190px;\" class=\"style3\">                                        " +
                        "<img alt=\"\" src=\"6.png\" /></td>                                </tr>                                <tr>                                    " +
                        "<td style=\"border-width: 1px; border-color: #FFCEA0; padding: 5px; text-align: center; border-top-style: solid; border-bottom-style: solid;\">                                        " +
                        "<b>" + urunaciklama6 + "</b></td>                                </tr>                                <tr>                                    <td colspan=\"2\" style=\"padding: 5px; text-align: center;\">                                        " +
                        "<img class=\"style4\" src=\"6barkod.png\" /></td>                                </tr>                            </table>                        </td>                    </tr>                    " +
                        "<tr>                        <td align=\"center\">                            <table cellpadding=\"0\" cellspacing=\"0\"                                                                                                                                 style=\"margin: 5px; padding: 0px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: 3px; border-bottom-width: 3px; border-left-width: 3px; border-right-color: #ffcea0; border-bottom-color: #ffcea0; border-left-color: #ffcea0;\">                                <tr>                                    <td colspan=\"2\"                                         style=\"padding: 5px; text-align: center; width: 190px; height: 190px;\" class=\"style3\">                                        " +
                        "<img alt=\"\" src=\"7.png\" /></td>                                </tr>                                <tr>                                    " +
                        "<td style=\"border-width: 1px; border-color: #FFCEA0; padding: 5px; text-align: center; border-top-style: solid; border-bottom-style: solid;\">                                        " +
                        "<b>" + urunaciklama7 + "</b></td>                                </tr>                                <tr>                                    <td colspan=\"2\" style=\"padding: 5px; text-align: center;\">                                        " +
                        "<img class=\"style4\" src=\"7barkod.png\" /></td>                                </tr>                            </table>                        </td>                        " +
                        "<td align=\"center\">                            <table cellpadding=\"0\" cellspacing=\"0\"                                                                                                                                 style=\"margin: 5px; padding: 0px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: 3px; border-bottom-width: 3px; border-left-width: 3px; border-right-color: #ffcea0; border-bottom-color: #ffcea0; border-left-color: #ffcea0;\">                                <tr>                                    <td colspan=\"2\"                                         style=\"padding: 5px; text-align: center; width: 190px; height: 190px;\" class=\"style3\">                                        " +
                        "<img alt=\"\" src=\"8.png\" /></td>                                </tr>                                <tr>                                    " +
                        "<td style=\"border-width: 1px; border-color: #FFCEA0; padding: 5px; text-align: center; border-top-style: solid; border-bottom-style: solid;\">                                        " +
                        "<b>" + urunaciklama8 + "</b></td>                                </tr>                                <tr>                                    <td colspan=\"2\" style=\"padding: 5px; text-align: center;\">                                        " +
                        "<img class=\"style4\" src=\"8barkod.png\" /></td>                                </tr>                            </table>                        </td>                        " +
                        "<td align=\"center\">                            <table cellpadding=\"0\" cellspacing=\"0\"                                                                                                                                 style=\"margin: 5px; padding: 0px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: 3px; border-bottom-width: 3px; border-left-width: 3px; border-right-color: #ffcea0; border-bottom-color: #ffcea0; border-left-color: #ffcea0;\">                                <tr>                                    <td colspan=\"2\"                                         style=\"padding: 5px; text-align: center; width: 190px; height: 190px;\" class=\"style3\">                                        " +
                        "<img alt=\"\" src=\"9.png\" /></td>                                </tr>                                <tr>                                    " +
                        "<td style=\"border-width: 1px; border-color: #FFCEA0; padding: 5px; text-align: center; border-top-style: solid; border-bottom-style: solid;\">                                        " +
                        "<b>" + urunaciklama9 + "</b></td>                                </tr>                                <tr>                                    <td colspan=\"2\" style=\"padding: 5px; text-align: center;\">                                        " +
                        "<img class=\"style4\" src=\"9barkod.png\" /></td>                                </tr>                            </table>                        </td>                    </tr>                </table>            </td>        </tr>        <tr>            <td style=\"background-image: url(footer-bg.png); height: 60px; padding: 0px 10px 20px 120px\">            <table style=\"margin-top: 5px\"><tr><td style=\"padding-right: 10px\"><span style=\"font-size: 14px\">                Dağıtım </span></td>            <td style=\"border-left-style: solid; border-left-color: #ffcea0; border-left-width: 1px;\">            <img class=\"style2\" src=\"1_sultanlar_logo.png\" style=\"padding: 3px 3px 3px 10px;\" /></td>            <td style=\"padding-left: 10px\">                <span style=\"font-size: 10px\"><i>Eyüp Sultan mh. Sekmen cd. No: 14 Sancaktepe / İSTANBUL</i><br /><i>Telefon: (+90 216) 561 50 00 Pbx</i><br /><i>Eposta: satis@sultanlar.com.tr</i></span></td></tr></table></td>        </tr>    </table></body></html>";

                // brosuru yaz
                if (File.Exists(txtCiktiYolu.Text + "\\Brosur.htm"))
                {
                    File.Delete(txtCiktiYolu.Text + "\\Brosur.htm");
                }
                StreamWriter sw = new StreamWriter(txtCiktiYolu.Text + "\\Brosur.htm", false, Encoding.Unicode);
                sw.Write(brosur);
                sw.Close();
                sw.Dispose();

                if (!cbKaynaktakiDosyalariSilme.Checked)
                    KaynaktakiDosyalariSil();

                webBrowser1.Navigate(txtCiktiYolu.Text + "\\Brosur.htm");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AltiliNoBG()
        {
            try
            {
                Directory.CreateDirectory(txtCiktiYolu.Text);

                string bilgi1 = string.Empty, koliadedikismi1 = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />", koliadedi1 = string.Empty, urunaciklama1 = string.Empty,
                         bilgi2 = string.Empty, koliadedikismi2 = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />", koliadedi2 = string.Empty, urunaciklama2 = string.Empty,
                         bilgi3 = string.Empty, koliadedikismi3 = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />", koliadedi3 = string.Empty, urunaciklama3 = string.Empty,
                         bilgi4 = string.Empty, koliadedikismi4 = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />", koliadedi4 = string.Empty, urunaciklama4 = string.Empty,
                         bilgi5 = string.Empty, koliadedikismi5 = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />", koliadedi5 = string.Empty, urunaciklama5 = string.Empty,
                         bilgi6 = string.Empty, koliadedikismi6 = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />", koliadedi6 = string.Empty, urunaciklama6 = string.Empty;

                // tablo gerekli resimleri
                File.Copy("https://www.sultanlar.com.tr/sultanlarui/brosur/1_sultanlar_logo.png", txtCiktiYolu.Text + "\\1_sultanlar_logo.png", true);
                File.Copy("https://www.sultanlar.com.tr/sultanlarui/brosur/header-bg.png", txtCiktiYolu.Text + "\\header-bg.png", true);
                File.Copy("https://www.sultanlar.com.tr/sultanlarui/brosur/footer-bg.png", txtCiktiYolu.Text + "\\footer-bg.png", true);

                // şablon logosu
                if (File.Exists(txtDosyaYolu.Text + "\\logo.png"))
                {
                    File.Copy(txtDosyaYolu.Text + "\\logo.png", txtCiktiYolu.Text + "\\logo.png", true);
                }
                else
                {
                    File.Copy("https://www.sultanlar.com.tr/sultanlarui/brosur/1_sultanlar_logo.png", txtCiktiYolu.Text + "\\logo.png", true);
                }

                // urun resimleri ve barkodlari
                for (int i = 1; i <= 6; i++)
                {
                    //resim
                    if (File.Exists(txtDosyaYolu.Text + "\\" + i.ToString() + ".png") || File.Exists(txtDosyaYolu.Text + "\\" + i.ToString() + ".jpg"))
                    {
                        Image img = File.Exists(txtDosyaYolu.Text + "\\" + i.ToString() + ".png") ? Image.FromFile(txtDosyaYolu.Text + "\\" + i.ToString() + ".png") : Image.FromFile(txtDosyaYolu.Text + "\\" + i.ToString() + ".jpg");
                        Image kucukimg;
                        if (img.Height > img.Width)
                        {
                            double aspectRatio = Convert.ToDouble(img.Height) / img.Width;
                            double yukseklik = 180;
                            double genislik = yukseklik / aspectRatio;
                            kucukimg = Resim.ResimKucult(img, Convert.ToInt32(genislik));
                        }
                        else
                        {
                            kucukimg = Resim.ResimKucult(img, 180);
                        }
                        kucukimg.Save(txtCiktiYolu.Text + "\\" + i.ToString() + ".png");
                    }
                    else
                    {
                        File.Copy("https://www.sultanlar.com.tr/sultanlarui/brosur/bos.png", txtCiktiYolu.Text + "\\" + i.ToString() + ".png", true);
                    }

                    // barkod
                    if (File.Exists(txtDosyaYolu.Text + "\\" + i.ToString() + "barkod.png"))
                    {
                        File.Copy(txtDosyaYolu.Text + "\\" + i.ToString() + "barkod.png", txtCiktiYolu.Text + "\\" + i.ToString() + "barkod.png", true);
                    }
                    else
                    {
                        File.Copy("https://www.sultanlar.com.tr/sultanlarui/brosur/bos.png", txtCiktiYolu.Text + "\\" + i.ToString() + "barkod.png", true);
                    }
                }

                // urun aciklamalari
                if (File.Exists(txtDosyaYolu.Text + "\\1.txt"))
                {
                    bilgi1 = File.ReadAllText(txtDosyaYolu.Text + "\\1.txt", Encoding.GetEncoding("iso-8859-9")).ToUpper();
                    koliadedikismi1 = koliadedi;
                    koliadedi1 = bilgi1.Substring(0, bilgi1.IndexOf("\r\n"));
                    urunaciklama1 = bilgi1.Substring(bilgi1.IndexOf("\r\n") + 1);
                }
                if (File.Exists(txtDosyaYolu.Text + "\\2.txt"))
                {
                    bilgi2 = File.ReadAllText(txtDosyaYolu.Text + "\\2.txt", Encoding.GetEncoding("iso-8859-9")).ToUpper();
                    koliadedikismi2 = koliadedi;
                    koliadedi2 = bilgi2.Substring(0, bilgi2.IndexOf("\r\n"));
                    urunaciklama2 = bilgi2.Substring(bilgi2.IndexOf("\r\n") + 1);
                }
                if (File.Exists(txtDosyaYolu.Text + "\\3.txt"))
                {
                    bilgi3 = File.ReadAllText(txtDosyaYolu.Text + "\\3.txt", Encoding.GetEncoding("iso-8859-9")).ToUpper();
                    koliadedikismi3 = koliadedi;
                    koliadedi3 = bilgi3.Substring(0, bilgi3.IndexOf("\r\n"));
                    urunaciklama3 = bilgi3.Substring(bilgi3.IndexOf("\r\n") + 1);
                }
                if (File.Exists(txtDosyaYolu.Text + "\\4.txt"))
                {
                    bilgi4 = File.ReadAllText(txtDosyaYolu.Text + "\\4.txt", Encoding.GetEncoding("iso-8859-9")).ToUpper();
                    koliadedikismi4 = koliadedi;
                    koliadedi4 = bilgi4.Substring(0, bilgi4.IndexOf("\r\n"));
                    urunaciklama4 = bilgi4.Substring(bilgi4.IndexOf("\r\n") + 1);
                }
                if (File.Exists(txtDosyaYolu.Text + "\\5.txt"))
                {
                    bilgi5 = File.ReadAllText(txtDosyaYolu.Text + "\\5.txt", Encoding.GetEncoding("iso-8859-9")).ToUpper();
                    koliadedikismi5 = koliadedi;
                    koliadedi5 = bilgi5.Substring(0, bilgi5.IndexOf("\r\n"));
                    urunaciklama5 = bilgi5.Substring(bilgi5.IndexOf("\r\n") + 1);
                }
                if (File.Exists(txtDosyaYolu.Text + "\\6.txt"))
                {
                    bilgi6 = File.ReadAllText(txtDosyaYolu.Text + "\\6.txt", Encoding.GetEncoding("iso-8859-9")).ToUpper();
                    koliadedikismi6 = koliadedi;
                    koliadedi6 = bilgi6.Substring(0, bilgi6.IndexOf("\r\n"));
                    urunaciklama6 = bilgi6.Substring(bilgi6.IndexOf("\r\n") + 1);
                }

                // brosuru olustur
                string brosur = "<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\"><html xmlns=\"http://www.w3.org/1999/xhtml\" ><head>    <title>Untitled Page</title>    <style type=\"text/css\">        .style1 {            width: 730px;            height: 929px;            font-family: Tahoma;            font-size: 9px;            font-weight: normal;        }        .style2        {            width: 138px;            height: 43px;        }        .style3        { background-color: " + txtRenk.Text + "; } .style4        {            width: 120px;            height: 55px;        }        </style></head><body style=\"margin: 0px 0px 0px 10px\">    <table cellpadding=\"0\" cellspacing=\"0\" class=\"style1\"         style=\"border: 1px solid #ffcea0\">        <tr>            <td style=\"background-image: url(header-bg.png); height: 60px; padding: 10px 10px 0px 100px\">            " +
                        "<img src=\"logo.png\"                     style=\"padding: 10px 3px 3px 10px; height: 48px;\" /></td>        </tr>        <tr>            <td>                <table cellpadding=\"0\" cellspacing=\"0\" class=\"style1\">                    <tr>                        <td align=\"center\">                            <table cellpadding=\"0\" cellspacing=\"0\"                                                                                                 style=\"margin: 5px; padding: 0px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: 3px; border-bottom-width: 3px; border-left-width: 3px; border-right-color: #ffcea0; border-bottom-color: #ffcea0; border-left-color: #ffcea0;\">                                <tr>                                    <td colspan=\"2\"                                         style=\"padding: 5px; text-align: center; width: 190px; height: 190px;\" class=\"style3\">                                        " +
                        "<img alt=\"\" src=\"1.png\" /></td>                                </tr>                                <tr>                                    " +
                        "<td style=\"border-width: 1px; border-color: #FFCEA0; padding: 5px; text-align: center; border-top-style: solid; border-bottom-style: solid;\">                                        " +
                        "<b>" + urunaciklama1 + "</b></td>                                </tr>                                <tr>                                    <td colspan=\"2\" style=\"padding: 5px; text-align: center;\">                                        " +
                        "<img class=\"style4\" src=\"1barkod.png\" /></td>                                </tr>                            </table>                        </td>                        " +
                        "<td align=\"center\">                            <table cellpadding=\"0\" cellspacing=\"0\"                                                                                                                                 style=\"margin: 5px; padding: 0px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: 3px; border-bottom-width: 3px; border-left-width: 3px; border-right-color: #ffcea0; border-bottom-color: #ffcea0; border-left-color: #ffcea0;\">                                <tr>                                    <td colspan=\"2\"                                         style=\"padding: 5px; text-align: center; width: 190px; height: 190px;\" class=\"style3\">                                        " +
                        "<img alt=\"\" src=\"2.png\" /></td>                                </tr>                                <tr>                                    " +
                        "<td style=\"border-width: 1px; border-color: #FFCEA0; padding: 5px; text-align: center; border-top-style: solid; border-bottom-style: solid;\">                                        " +
                        "<b>" + urunaciklama2 + "</b></td>                                </tr>                                <tr>                                    <td colspan=\"2\" style=\"padding: 5px; text-align: center;\">                                        " +
                        "<img class=\"style4\" src=\"2barkod.png\" /></td>                                </tr>                            </table>                        </td>                    </tr>                    " +
                        "<tr>                        <td align=\"center\">                            <table cellpadding=\"0\" cellspacing=\"0\"                                                                                                                                 style=\"margin: 5px; padding: 0px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: 3px; border-bottom-width: 3px; border-left-width: 3px; border-right-color: #ffcea0; border-bottom-color: #ffcea0; border-left-color: #ffcea0;\">                                <tr>                                    <td colspan=\"2\"                                         style=\"padding: 5px; text-align: center; width: 190px; height: 190px;\" class=\"style3\">                                        " +
                        "<img alt=\"\" src=\"3.png\" /></td>                                </tr>                                <tr>                                    " +
                        "<td style=\"border-width: 1px; border-color: #FFCEA0; padding: 5px; text-align: center; border-top-style: solid; border-bottom-style: solid;\">                                        " +
                        "<b>" + urunaciklama3 + "</b></td>                                </tr>                                <tr>                                    <td colspan=\"2\" style=\"padding: 5px; text-align: center;\">                                        " +
                        "<img class=\"style4\" src=\"3barkod.png\" /></td>                                </tr>                            </table>                        </td>                        " +
                        "<td align=\"center\">                            <table cellpadding=\"0\" cellspacing=\"0\"                                                                                                                                 style=\"margin: 5px; padding: 0px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: 3px; border-bottom-width: 3px; border-left-width: 3px; border-right-color: #ffcea0; border-bottom-color: #ffcea0; border-left-color: #ffcea0;\">                                <tr>                                    <td colspan=\"2\"                                         style=\"padding: 5px; text-align: center; width: 190px; height: 190px;\" class=\"style3\">                                        " +
                        "<img alt=\"\" src=\"4.png\" /></td>                                </tr>                                <tr>                                    " +
                        "<td style=\"border-width: 1px; border-color: #FFCEA0; padding: 5px; text-align: center; border-top-style: solid; border-bottom-style: solid;\">                                        " +
                        "<b>" + urunaciklama4 + "</b></td>                                </tr>                                <tr>                                    <td colspan=\"2\" style=\"padding: 5px; text-align: center;\">                                        " +
                        "<img class=\"style4\" src=\"4barkod.png\" /></td>                                </tr>                            </table>                        </td>                    </tr>                    " +
                        "<tr>                        <td align=\"center\">                            <table cellpadding=\"0\" cellspacing=\"0\"                                                                                                                                 style=\"margin: 5px; padding: 0px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: 3px; border-bottom-width: 3px; border-left-width: 3px; border-right-color: #ffcea0; border-bottom-color: #ffcea0; border-left-color: #ffcea0;\">                                <tr>                                    <td colspan=\"2\"                                         style=\"padding: 5px; text-align: center; width: 190px; height: 190px;\" class=\"style3\">                                        " +
                        "<img alt=\"\" src=\"5.png\" /></td>                                </tr>                                <tr>                                    " +
                        "<td style=\"border-width: 1px; border-color: #FFCEA0; padding: 5px; text-align: center; border-top-style: solid; border-bottom-style: solid;\">                                        " +
                        "<b>" + urunaciklama5 + "</b></td>                                </tr>                                <tr>                                    <td colspan=\"2\" style=\"padding: 5px; text-align: center;\">                                        " +
                        "<img class=\"style4\" src=\"5barkod.png\" /></td>                                </tr>                            </table>                        </td>                        " +
                        "<td align=\"center\">                            <table cellpadding=\"0\" cellspacing=\"0\"                                                                                                                                 style=\"margin: 5px; padding: 0px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: 3px; border-bottom-width: 3px; border-left-width: 3px; border-right-color: #ffcea0; border-bottom-color: #ffcea0; border-left-color: #ffcea0;\">                                <tr>                                    <td colspan=\"2\"                                         style=\"padding: 5px; text-align: center; width: 190px; height: 190px;\" class=\"style3\">                                        " +
                        "<img alt=\"\" src=\"6.png\" /></td>                                </tr>                                <tr>                                    " +
                        "<td style=\"border-width: 1px; border-color: #FFCEA0; padding: 5px; text-align: center; border-top-style: solid; border-bottom-style: solid;\">                                        " +
                        "<b>" + urunaciklama6 + "</b></td>                                </tr>                                <tr>                                    <td colspan=\"2\" style=\"padding: 5px; text-align: center;\">                                        " +
                        "<img class=\"style4\" src=\"6barkod.png\" /></td>                                </tr>                            </table>                        </td>                    </tr>                </table>            </td>        </tr>        <tr>            <td style=\"background-image: url(footer-bg.png); height: 60px; padding: 0px 10px 20px 120px\">            <table style=\"margin-top: 5px\"><tr><td style=\"padding-right: 10px\"><span style=\"font-size: 14px\">                Dağıtım </span></td>            <td style=\"border-left-style: solid; border-left-color: #ffcea0; border-left-width: 1px;\">            <img class=\"style2\" src=\"1_sultanlar_logo.png\" style=\"padding: 3px 3px 3px 10px;\" /></td>            <td style=\"padding-left: 10px\">                <span style=\"font-size: 10px\"><i>Eyüp Sultan mh. Sekmen cd. No: 14 Sancaktepe / İSTANBUL</i><br /><i>Telefon: (+90 216) 561 50 00 Pbx</i><br /><i>Eposta: satis@sultanlar.com.tr</i></span></td></tr></table></td>        </tr>    </table></body></html>";

                // brosuru yaz
                if (File.Exists(txtCiktiYolu.Text + "\\Brosur.htm"))
                {
                    File.Delete(txtCiktiYolu.Text + "\\Brosur.htm");
                }
                StreamWriter sw = new StreamWriter(txtCiktiYolu.Text + "\\Brosur.htm", false, Encoding.Unicode);
                sw.Write(brosur);
                sw.Close();
                sw.Dispose();

                if (!cbKaynaktakiDosyalariSilme.Checked)
                    KaynaktakiDosyalariSil();

                webBrowser1.Navigate(txtCiktiYolu.Text + "\\Brosur.htm");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DortluNoBG()
        {
            try
            {
                Directory.CreateDirectory(txtCiktiYolu.Text);

                string bilgi1 = string.Empty, koliadedikismi1 = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />", koliadedi1 = string.Empty, urunaciklama1 = string.Empty,
                         bilgi2 = string.Empty, koliadedikismi2 = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />", koliadedi2 = string.Empty, urunaciklama2 = string.Empty,
                         bilgi3 = string.Empty, koliadedikismi3 = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />", koliadedi3 = string.Empty, urunaciklama3 = string.Empty,
                         bilgi4 = string.Empty, koliadedikismi4 = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />", koliadedi4 = string.Empty, urunaciklama4 = string.Empty;

                // tablo gerekli resimleri
                File.Copy("https://www.sultanlar.com.tr/sultanlarui/brosur/1_sultanlar_logo.png", txtCiktiYolu.Text + "\\1_sultanlar_logo.png", true);
                File.Copy("https://www.sultanlar.com.tr/sultanlarui/brosur/header-bg.png", txtCiktiYolu.Text + "\\header-bg.png", true);
                File.Copy("https://www.sultanlar.com.tr/sultanlarui/brosur/footer-bg.png", txtCiktiYolu.Text + "\\footer-bg.png", true);

                // şablon logosu
                if (File.Exists(txtDosyaYolu.Text + "\\logo.png"))
                {
                    File.Copy(txtDosyaYolu.Text + "\\logo.png", txtCiktiYolu.Text + "\\logo.png", true);
                }
                else
                {
                    File.Copy("https://www.sultanlar.com.tr/sultanlarui/brosur/1_sultanlar_logo.png", txtCiktiYolu.Text + "\\logo.png", true);
                }

                // urun resimleri ve barkodlari
                for (int i = 1; i <= 4; i++)
                {
                    //resim
                    if (File.Exists(txtDosyaYolu.Text + "\\" + i.ToString() + ".png") || File.Exists(txtDosyaYolu.Text + "\\" + i.ToString() + ".jpg"))
                    {
                        Image img = File.Exists(txtDosyaYolu.Text + "\\" + i.ToString() + ".png") ? Image.FromFile(txtDosyaYolu.Text + "\\" + i.ToString() + ".png") : Image.FromFile(txtDosyaYolu.Text + "\\" + i.ToString() + ".jpg");
                        Image kucukimg;
                        if (img.Height > img.Width)
                        {
                            double aspectRatio = Convert.ToDouble(img.Height) / img.Width;
                            double yukseklik = 270;
                            double genislik = yukseklik / aspectRatio;
                            kucukimg = Resim.ResimKucult(img, Convert.ToInt32(genislik));
                        }
                        else
                        {
                            kucukimg = Resim.ResimKucult(img, 270);
                        }
                        kucukimg.Save(txtCiktiYolu.Text + "\\" + i.ToString() + ".png");
                    }
                    else
                    {
                        File.Copy("https://www.sultanlar.com.tr/sultanlarui/brosur/bos.png", txtCiktiYolu.Text + "\\" + i.ToString() + ".png", true);
                    }

                    // barkod
                    if (File.Exists(txtDosyaYolu.Text + "\\" + i.ToString() + "barkod.png"))
                    {
                        File.Copy(txtDosyaYolu.Text + "\\" + i.ToString() + "barkod.png", txtCiktiYolu.Text + "\\" + i.ToString() + "barkod.png", true);
                    }
                    else
                    {
                        File.Copy("https://www.sultanlar.com.tr/sultanlarui/brosur/bos.png", txtCiktiYolu.Text + "\\" + i.ToString() + "barkod.png", true);
                    }
                }

                // urun aciklamalari
                if (File.Exists(txtDosyaYolu.Text + "\\1.txt"))
                {
                    bilgi1 = File.ReadAllText(txtDosyaYolu.Text + "\\1.txt", Encoding.GetEncoding("iso-8859-9")).ToUpper();
                    koliadedikismi1 = koliadedi;
                    koliadedi1 = bilgi1.Substring(0, bilgi1.IndexOf("\r\n"));
                    urunaciklama1 = bilgi1.Substring(bilgi1.IndexOf("\r\n") + 1);
                }
                if (File.Exists(txtDosyaYolu.Text + "\\2.txt"))
                {
                    bilgi2 = File.ReadAllText(txtDosyaYolu.Text + "\\2.txt", Encoding.GetEncoding("iso-8859-9")).ToUpper();
                    koliadedikismi2 = koliadedi;
                    koliadedi2 = bilgi2.Substring(0, bilgi2.IndexOf("\r\n"));
                    urunaciklama2 = bilgi2.Substring(bilgi2.IndexOf("\r\n") + 1);
                }
                if (File.Exists(txtDosyaYolu.Text + "\\3.txt"))
                {
                    bilgi3 = File.ReadAllText(txtDosyaYolu.Text + "\\3.txt", Encoding.GetEncoding("iso-8859-9")).ToUpper();
                    koliadedikismi3 = koliadedi;
                    koliadedi3 = bilgi3.Substring(0, bilgi3.IndexOf("\r\n"));
                    urunaciklama3 = bilgi3.Substring(bilgi3.IndexOf("\r\n") + 1);
                }
                if (File.Exists(txtDosyaYolu.Text + "\\4.txt"))
                {
                    bilgi4 = File.ReadAllText(txtDosyaYolu.Text + "\\4.txt", Encoding.GetEncoding("iso-8859-9")).ToUpper();
                    koliadedikismi4 = koliadedi;
                    koliadedi4 = bilgi4.Substring(0, bilgi4.IndexOf("\r\n"));
                    urunaciklama4 = bilgi4.Substring(bilgi4.IndexOf("\r\n") + 1);
                }

                // brosuru olustur
                string brosur = "<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\"><html xmlns=\"http://www.w3.org/1999/xhtml\" ><head>    <title>Untitled Page</title>    <style type=\"text/css\">        .style1 {            width: 730px;            height: 929px;            font-family: Tahoma;            font-size: 11px;            font-weight: normal;        }        .style2        {            width: 138px;            height: 43px;        }        .style3        { background-color: " + txtRenk.Text + "; } .style4        {            width: 150px;            height:  68px;        }        </style></head><body style=\"margin: 0px 0px 0px 10px\">    <table cellpadding=\"0\" cellspacing=\"0\" class=\"style1\"         style=\"border: 1px solid #ffcea0\">        <tr>            <td style=\"background-image: url(header-bg.png); height: 60px; padding: 10px 10px 0px 100px\">            " +
                        "<img src=\"logo.png\"                     style=\"padding: 10px 3px 3px 10px; height: 48px;\" /></td>        </tr>        <tr>            <td>                <table cellpadding=\"0\" cellspacing=\"0\" class=\"style1\">                    <tr>                        <td align=\"center\">                            <table cellpadding=\"0\" cellspacing=\"0\"                                                                                                 style=\"margin: 5px; padding: 0px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: 3px; border-bottom-width: 3px; border-left-width: 3px; border-right-color: #ffcea0; border-bottom-color: #ffcea0; border-left-color: #ffcea0;\">                                <tr>                                    <td colspan=\"2\"                                         style=\"padding: 5px; text-align: center; height: 280px; width: 280px;\" class=\"style3\">                                        " +
                        "<img alt=\"\" src=\"1.png\" /></td>                                </tr>                                <tr>                                    " +
                        "<td style=\"border-width: 1px; border-color: #FFCEA0; padding: 5px; text-align: center; border-top-style: solid; border-bottom-style: solid;\">                                        " +
                        "<b>" + urunaciklama1 + "</b></td>                                </tr>                                <tr>                                    <td colspan=\"2\" style=\"padding: 5px; text-align: center;\">                                        " +
                        "<img class=\"style4\" src=\"1barkod.png\" /></td>                                </tr>                            </table>                        </td>                        " +
                        "<td align=\"center\">                            <table cellpadding=\"0\" cellspacing=\"0\"                                                                                                                                 style=\"margin: 5px; padding: 0px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: 3px; border-bottom-width: 3px; border-left-width: 3px; border-right-color: #ffcea0; border-bottom-color: #ffcea0; border-left-color: #ffcea0;\">                                <tr>                                    <td colspan=\"2\"                                         style=\"padding: 5px; text-align: center; height: 280px; width: 280px;\" class=\"style3\">                                        " +
                        "<img alt=\"\" src=\"2.png\" /></td>                                </tr>                                <tr>                                    " +
                        "<td style=\"border-width: 1px; border-color: #FFCEA0; padding: 5px; text-align: center; border-top-style: solid; border-bottom-style: solid;\">                                        " +
                        "<b>" + urunaciklama2 + "</b></td>                                </tr>                                <tr>                                    <td colspan=\"2\" style=\"padding: 5px; text-align: center;\">                                        " +
                        "<img class=\"style4\" src=\"2barkod.png\" /></td>                                </tr>                            </table>                        </td>                    </tr>                    " +
                        "<tr>                        <td align=\"center\">                            <table cellpadding=\"0\" cellspacing=\"0\"                                                                                                                                 style=\"margin: 5px; padding: 0px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: 3px; border-bottom-width: 3px; border-left-width: 3px; border-right-color: #ffcea0; border-bottom-color: #ffcea0; border-left-color: #ffcea0;\">                                <tr>                                    <td colspan=\"2\"                                         style=\"padding: 5px; text-align: center; height: 280px; width: 280px;\" class=\"style3\">                                        " +
                        "<img alt=\"\" src=\"3.png\" /></td>                                </tr>                                <tr>                                    " +
                        "<td style=\"border-width: 1px; border-color: #FFCEA0; padding: 5px; text-align: center; border-top-style: solid; border-bottom-style: solid;\">                                        " +
                        "<b>" + urunaciklama3 + "</b></td>                                </tr>                                <tr>                                    <td colspan=\"2\" style=\"padding: 5px; text-align: center;\">                                        " +
                        "<img class=\"style4\" src=\"3barkod.png\" /></td>                                </tr>                            </table>                        </td>                        " +
                        "<td align=\"center\">                            <table cellpadding=\"0\" cellspacing=\"0\"                                                                                                                                 style=\"margin: 5px; padding: 0px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: 3px; border-bottom-width: 3px; border-left-width: 3px; border-right-color: #ffcea0; border-bottom-color: #ffcea0; border-left-color: #ffcea0;\">                                <tr>                                    <td colspan=\"2\"                                         style=\"padding: 5px; text-align: center; height: 280px; width: 280px;\" class=\"style3\">                                        " +
                        "<img alt=\"\" src=\"4.png\" /></td>                                </tr>                                <tr>                                    " +
                        "<td style=\"border-width: 1px; border-color: #FFCEA0; padding: 5px; text-align: center; border-top-style: solid; border-bottom-style: solid;\">                                        " +
                        "<b>" + urunaciklama4 + "</b></td>                                </tr>                                <tr>                                    <td colspan=\"2\" style=\"padding: 5px; text-align: center;\">                                        " +
                        "<img class=\"style4\" src=\"4barkod.png\" /></td>                                </tr>                            </table>                        </td>                    </tr>                </table>            </td>        </tr>        <tr>            <td style=\"background-image: url(footer-bg.png); height: 60px; padding: 0px 10px 20px 120px\">            <table style=\"margin-top: 5px\"><tr><td style=\"padding-right: 10px\"><span style=\"font-size: 11px\">                Dağıtım </span></td>            <td style=\"border-left-style: solid; border-left-color: #ffcea0; border-left-width: 1px;\">            <img class=\"style2\" src=\"1_sultanlar_logo.png\" style=\"padding: 3px 3px 3px 10px;\" /></td><td style=\"padding-left: 10px\">                <span style=\"font-size: 10px\"><i>Eyüp Sultan mh. Sekmen cd. No: 14 Sancaktepe / İSTANBUL</i><br /><i>Telefon: (+90 216) 561 50 00 Pbx</i><br /><i>Eposta: satis@sultanlar.com.tr</i></span></td></tr></table></td>        </tr>    </table></body></html>";

                // brosuru yaz
                if (File.Exists(txtCiktiYolu.Text + "\\Brosur.htm"))
                {
                    File.Delete(txtCiktiYolu.Text + "\\Brosur.htm");
                }
                StreamWriter sw = new StreamWriter(txtCiktiYolu.Text + "\\Brosur.htm", false, Encoding.Unicode);
                sw.Write(brosur);
                sw.Close();
                sw.Dispose();

                if (!cbKaynaktakiDosyalariSilme.Checked)
                    KaynaktakiDosyalariSil();

                webBrowser1.Navigate(txtCiktiYolu.Text + "\\Brosur.htm");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void IkiliNoBG()
        {
            try
            {
                Directory.CreateDirectory(txtCiktiYolu.Text);

                string bilgi1 = string.Empty, koliadedikismi1 = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />", koliadedi1 = string.Empty, urunaciklama1 = string.Empty,
                         bilgi2 = string.Empty, koliadedikismi2 = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />", koliadedi2 = string.Empty, urunaciklama2 = string.Empty;

                // tablo gerekli resimleri
                File.Copy("https://www.sultanlar.com.tr/sultanlarui/brosur/1_sultanlar_logo.png", txtCiktiYolu.Text + "\\1_sultanlar_logo.png", true);
                File.Copy("https://www.sultanlar.com.tr/sultanlarui/brosur/header-bg.png", txtCiktiYolu.Text + "\\header-bg.png", true);
                File.Copy("https://www.sultanlar.com.tr/sultanlarui/brosur/footer-bg.png", txtCiktiYolu.Text + "\\footer-bg.png", true);

                // şablon logosu
                if (File.Exists(txtDosyaYolu.Text + "\\logo.png"))
                {
                    File.Copy(txtDosyaYolu.Text + "\\logo.png", txtCiktiYolu.Text + "\\logo.png", true);
                }
                else
                {
                    File.Copy("https://www.sultanlar.com.tr/sultanlarui/brosur/1_sultanlar_logo.png", txtCiktiYolu.Text + "\\logo.png", true);
                }

                // urun resimleri ve barkodlari
                for (int i = 1; i <= 2; i++)
                {
                    //resim
                    if (File.Exists(txtDosyaYolu.Text + "\\" + i.ToString() + ".png") || File.Exists(txtDosyaYolu.Text + "\\" + i.ToString() + ".jpg"))
                    {
                        Image img = File.Exists(txtDosyaYolu.Text + "\\" + i.ToString() + ".png") ? Image.FromFile(txtDosyaYolu.Text + "\\" + i.ToString() + ".png") : Image.FromFile(txtDosyaYolu.Text + "\\" + i.ToString() + ".jpg");
                        Image kucukimg;
                        if (img.Height > img.Width)
                        {
                            double aspectRatio = Convert.ToDouble(img.Height) / img.Width;
                            double yukseklik = 270;
                            double genislik = yukseklik / aspectRatio;
                            kucukimg = Resim.ResimKucult(img, Convert.ToInt32(genislik));
                        }
                        else
                        {
                            kucukimg = Resim.ResimKucult(img, 270);
                        }
                        kucukimg.Save(txtCiktiYolu.Text + "\\" + i.ToString() + ".png");
                    }
                    else
                    {
                        File.Copy("https://www.sultanlar.com.tr/sultanlarui/brosur/bos.png", txtCiktiYolu.Text + "\\" + i.ToString() + ".png", true);
                    }

                    // barkod
                    if (File.Exists(txtDosyaYolu.Text + "\\" + i.ToString() + "barkod.png"))
                    {
                        File.Copy(txtDosyaYolu.Text + "\\" + i.ToString() + "barkod.png", txtCiktiYolu.Text + "\\" + i.ToString() + "barkod.png", true);
                    }
                    else
                    {
                        File.Copy("https://www.sultanlar.com.tr/sultanlarui/brosur/bos.png", txtCiktiYolu.Text + "\\" + i.ToString() + "barkod.png", true);
                    }
                }

                // urun aciklamalari
                if (File.Exists(txtDosyaYolu.Text + "\\1.txt"))
                {
                    bilgi1 = File.ReadAllText(txtDosyaYolu.Text + "\\1.txt", Encoding.GetEncoding("iso-8859-9")).ToUpper();
                    koliadedikismi1 = koliadedi;
                    koliadedi1 = bilgi1.Substring(0, bilgi1.IndexOf("\r\n"));
                    urunaciklama1 = bilgi1.Substring(bilgi1.IndexOf("\r\n") + 1);
                }
                if (File.Exists(txtDosyaYolu.Text + "\\2.txt"))
                {
                    bilgi2 = File.ReadAllText(txtDosyaYolu.Text + "\\2.txt", Encoding.GetEncoding("iso-8859-9")).ToUpper();
                    koliadedikismi2 = koliadedi;
                    koliadedi2 = bilgi2.Substring(0, bilgi2.IndexOf("\r\n"));
                    urunaciklama2 = bilgi2.Substring(bilgi2.IndexOf("\r\n") + 1);
                }

                // brosuru olustur
                string brosur = "<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\"><html xmlns=\"http://www.w3.org/1999/xhtml\" ><head>    <title>Untitled Page</title>    <style type=\"text/css\">        .style1 {            width: 730px;            height: 929px;            font-family: Tahoma;            font-size: 11px;            font-weight: normal;        }        .style2        {            width: 138px;            height: 43px;        }        .style3        { background-color: " + txtRenk.Text + "; } .style4        {            width: 150px;            height:  68px;        }        </style></head><body style=\"margin: 0px 0px 0px 10px\">    <table cellpadding=\"0\" cellspacing=\"0\" class=\"style1\"         style=\"border: 1px solid #ffcea0\">        <tr>            <td style=\"background-image: url(header-bg.png); height: 60px; padding: 10px 10px 0px 100px\">            " +
                        "<img src=\"logo.png\"                     style=\"padding: 10px 3px 3px 10px; height: 48px;\" /></td>        </tr>        <tr>            <td>                <table cellpadding=\"0\" cellspacing=\"0\" class=\"style1\">                    <tr>                        <td align=\"center\">                            <table cellpadding=\"0\" cellspacing=\"0\"                                                                                                 style=\"margin: 5px; padding: 0px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: 3px; border-bottom-width: 3px; border-left-width: 3px; border-right-color: #ffcea0; border-bottom-color: #ffcea0; border-left-color: #ffcea0;\">                                <tr>                                    <td colspan=\"2\"                                         style=\"padding: 5px; text-align: center; height: 280px; width: 280px;\" class=\"style3\">                                        " +
                        "<img alt=\"\" src=\"1.png\" /></td>                                </tr>                                <tr>                                    " +
                        "<td style=\"border-width: 1px; border-color: #FFCEA0; padding: 5px; text-align: center; border-top-style: solid; border-bottom-style: solid;\">                                        " +
                        "<b>" + urunaciklama1 + "</b></td>                                </tr>                                <tr>                                    <td colspan=\"2\" style=\"padding: 5px; text-align: center;\">                                        " +
                        "<img class=\"style4\" src=\"1barkod.png\" /></td>                                </tr>                            </table>                        </td>                    </tr>                    " +
                        "<tr>                        <td align=\"center\">                            <table cellpadding=\"0\" cellspacing=\"0\"                                                                                                                                 style=\"margin: 5px; padding: 0px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: 3px; border-bottom-width: 3px; border-left-width: 3px; border-right-color: #ffcea0; border-bottom-color: #ffcea0; border-left-color: #ffcea0;\">                                <tr>                                    <td colspan=\"2\"                                         style=\"padding: 5px; text-align: center; height: 280px; width: 280px;\" class=\"style3\">                                        " +
                        "<img alt=\"\" src=\"2.png\" /></td>                                </tr>                                <tr>                                    " +
                        "<td style=\"border-width: 1px; border-color: #FFCEA0; padding: 5px; text-align: center; border-top-style: solid; border-bottom-style: solid;\">                                        " +
                        "<b>" + urunaciklama2 + "</b></td>                                </tr>                                <tr>                                    <td colspan=\"2\" style=\"padding: 5px; text-align: center;\">                                        " +
                        "<img class=\"style4\" src=\"2barkod.png\" /></td>                                </tr>                            </table>                        </td>                    </tr>                </table>            </td>        </tr>        <tr>            <td style=\"background-image: url(footer-bg.png); height: 60px; padding: 0px 10px 20px 120px\">            <table style=\"margin-top: 5px\"><tr><td style=\"padding-right: 10px\"><span style=\"font-size: 11px\">                Dağıtım </span></td>            <td style=\"border-left-style: solid; border-left-color: #ffcea0; border-left-width: 1px;\">            <img class=\"style2\" src=\"1_sultanlar_logo.png\" style=\"padding: 3px 3px 3px 10px;\" /></td><td style=\"padding-left: 10px\">                <span style=\"font-size: 10px\"><i>Eyüp Sultan mh. Sekmen cd. No: 14 Sancaktepe / İSTANBUL</i><br /><i>Telefon: (+90 216) 561 50 00 Pbx</i><br /><i>Eposta: satis@sultanlar.com.tr</i></span></td></tr></table></td>        </tr>    </table></body></html>";

                // brosuru yaz
                if (File.Exists(txtCiktiYolu.Text + "\\Brosur.htm"))
                {
                    File.Delete(txtCiktiYolu.Text + "\\Brosur.htm");
                }
                StreamWriter sw = new StreamWriter(txtCiktiYolu.Text + "\\Brosur.htm", false, Encoding.Unicode);
                sw.Write(brosur);
                sw.Close();
                sw.Dispose();

                if (!cbKaynaktakiDosyalariSilme.Checked)
                    KaynaktakiDosyalariSil();

                webBrowser1.Navigate(txtCiktiYolu.Text + "\\Brosur.htm");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BirliNoBG()
        {
            try
            {
                Directory.CreateDirectory(txtCiktiYolu.Text);

                // tablo gerekli resimleri
                File.Copy("https://www.sultanlar.com.tr/sultanlarui/brosur/1_sultanlar_logo.png", txtCiktiYolu.Text + "\\1_sultanlar_logo.png", true);
                File.Copy("https://www.sultanlar.com.tr/sultanlarui/brosur/header-bg.png", txtCiktiYolu.Text + "\\header-bg.png", true);
                File.Copy("https://www.sultanlar.com.tr/sultanlarui/brosur/footer-bg.png", txtCiktiYolu.Text + "\\footer-bg.png", true);

                // şablon logosu
                if (File.Exists(txtDosyaYolu.Text + "\\logo.png"))
                {
                    File.Copy(txtDosyaYolu.Text + "\\logo.png", txtCiktiYolu.Text + "\\logo.png", true);
                }
                else
                {
                    File.Copy("https://www.sultanlar.com.tr/sultanlarui/brosur/1_sultanlar_logo.png", txtCiktiYolu.Text + "\\logo.png", true);
                }

                // urun aciklamalari
                string bilgi = File.ReadAllText(txtDosyaYolu.Text + "\\1.txt", Encoding.GetEncoding("iso-8859-9")).ToUpper();
                string koliadedi1 = bilgi.Substring(0, bilgi.IndexOf("\r\n"));
                string urunaciklama1 = bilgi.Substring(bilgi.IndexOf("\r\n") + 1);

                //resim
                Image img = File.Exists(txtDosyaYolu.Text + "\\1.png") ? Image.FromFile(txtDosyaYolu.Text + "\\1.png") : Image.FromFile(txtDosyaYolu.Text + "\\1.jpg");
                Image kucukimg;
                if (img.Height > img.Width)
                {
                    double aspectRatio = Convert.ToDouble(img.Height) / img.Width;
                    double yukseklik = 520;
                    double genislik = yukseklik / aspectRatio;
                    kucukimg = Resim.ResimKucult(img, Convert.ToInt32(genislik));
                }
                else
                {
                    kucukimg = Resim.ResimKucult(img, 520);
                }
                kucukimg = Resim.ResimKucult(img, 520);
                kucukimg.Save(txtCiktiYolu.Text + "\\1.png");

                // barkod
                File.Copy(txtDosyaYolu.Text + "\\1barkod.png", txtCiktiYolu.Text + "\\1barkod.png", true);

                // brosuru olustur
                string brosur = "<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\"><html xmlns=\"http://www.w3.org/1999/xhtml\" ><head>    <title>Untitled Page</title>    <style type=\"text/css\">        .style1 {            width: 730px;            height: 929px;            font-family: Tahoma;            font-size: 18px;            font-weight: normal;        }        .style2        {            width: 138px;            height: 43px;        }        .style3        { background-color: " + txtRenk.Text + "; } .style3        { background-color: " + txtRenk.Text + "; } .style4        {            width: 150px;            height:  68px;        }         </style></head><body style=\"margin: 0px 0px 0px 10px\">    <table cellpadding=\"0\" cellspacing=\"0\" class=\"style1\"         style=\"border: 1px solid #ffcea0\">        <tr>            <td style=\"background-image: url(header-bg.png); height: 60px; padding: 10px 10px 0px 100px\">            " +
                        "<img src=\"logo.png\"                     style=\"padding: 10px 3px 3px 10px; height: 48px;\" /></td>        </tr>        <tr>            <td>                <table cellpadding=\"0\" cellspacing=\"0\" class=\"style1\">                    <tr>                        <td align=\"center\">                            <table cellpadding=\"0\" cellspacing=\"0\"                                                                                                 style=\"margin: 5px; padding: 0px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: 3px; border-bottom-width: 3px; border-left-width: 3px; border-right-color: #ffcea0; border-bottom-color: #ffcea0; border-left-color: #ffcea0;\">                                <tr>                                    <td colspan=\"2\"                                         style=\"padding: 5px; text-align: center; height: 530px; width: 530px;\" class=\"style3\">                                        " +
                        "<img alt=\"\" src=\"1.png\" /></td>                                </tr>                                <tr>                                    " +
                        "<td style=\"border-width: 1px; border-color: #FFCEA0; padding: 5px; text-align: center; border-top-style: solid; border-bottom-style: solid;\">                                        " +
                        "<b>" + urunaciklama1 + "</b></td>                                </tr>                                <tr>                                    <td colspan=\"2\" style=\"padding: 5px; text-align: center;\">                                        " +
                        "<img class=\"style4\" src=\"1barkod.png\"/></td>                                </tr>                            </table>                        </td>                    </tr>                </table>            </td>        </tr>        <tr>            <td style=\"background-image: url(footer-bg.png); height: 60px; padding: 0px 10px 20px 120px\">            <table style=\"margin-top: 5px\"><tr><td style=\"padding-right: 10px\"><span style=\"font-size: 14px\">                Dağıtım </span></td>            <td style=\"border-left-style: solid; border-left-color: #ffcea0; border-left-width: 1px;\">            <img class=\"style2\" src=\"1_sultanlar_logo.png\" style=\"padding: 3px 3px 3px 10px;\" /></td><td style=\"padding-left: 10px\">                <span style=\"font-size: 10px\"><i>Eyüp Sultan mh. Sekmen cd. No: 14 Sancaktepe / İSTANBUL</i><br /><i>Telefon: (+90 216) 561 50 00 Pbx</i><br /><i>Eposta: satis@sultanlar.com.tr</i></span></td></tr></table></td>        </tr>    </table></body></html>";

                // brosuru yaz
                if (File.Exists(txtCiktiYolu.Text + "\\Brosur.htm"))
                {
                    File.Delete(txtCiktiYolu.Text + "\\Brosur.htm");
                }
                StreamWriter sw = new StreamWriter(txtCiktiYolu.Text + "\\Brosur.htm", false, Encoding.Unicode);
                sw.Write(brosur);
                sw.Close();
                sw.Dispose();

                if (!cbKaynaktakiDosyalariSilme.Checked)
                    KaynaktakiDosyalariSil();

                webBrowser1.Navigate(txtCiktiYolu.Text + "\\Brosur.htm");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //private void BrosuruResimYap()
        //{
        //    HtmlCapture hc = new HtmlCapture();
        //    hc.HtmlImageCapture +=
        //       new HtmlCapture.HtmlCaptureEvent(hc_HtmlImageCapture);
        //    hc.Create(txtCiktiYolu.Text + "\\Brosur.htm");
        //}

        //private void hc_HtmlImageCapture(object sender, Uri url, Bitmap image)
        //{
        //    Bitmap bmp = new Bitmap(752, 1086);
        //    Graphics gr = Graphics.FromImage(bmp);
        //    Image img = image;
        //    gr.DrawImageUnscaled(img, 0, 0, 752, 1086);

        //    bmp.Save(txtDosyaYolu.Text + "\\brosur.png", ImageFormat.Png);

        //    string sss = "<html><body style='margin: 0 0 0 0'><img src='" + txtDosyaYolu.Text + "\\brosur.png' /></body></html>";
        //    File.WriteAllText(txtCiktiYolu.Text + "\\brosur-PR.htm", sss);
        //    webBrowser1.Navigate(txtCiktiYolu.Text + "\\brosur-PR.htm");

        //    //webBrowser1.DocumentStream = new MemoryStream(File.ReadAllBytes(txtDosyaYolu.Text + "\\brosur.png"));
        //}

        private void KaynaktakiDosyalariSil()
        {
            File.Delete(txtDosyaYolu.Text + "\\1.txt");
            File.Delete(txtDosyaYolu.Text + "\\1barkod.png");
            File.Delete(txtDosyaYolu.Text + "\\2.txt");
            File.Delete(txtDosyaYolu.Text + "\\2barkod.png");
            File.Delete(txtDosyaYolu.Text + "\\3.txt");
            File.Delete(txtDosyaYolu.Text + "\\3barkod.png");
            File.Delete(txtDosyaYolu.Text + "\\4.txt");
            File.Delete(txtDosyaYolu.Text + "\\4barkod.png");
            File.Delete(txtDosyaYolu.Text + "\\5.txt");
            File.Delete(txtDosyaYolu.Text + "\\5barkod.png");
            File.Delete(txtDosyaYolu.Text + "\\6.txt");
            File.Delete(txtDosyaYolu.Text + "\\6barkod.png");
            File.Delete(txtDosyaYolu.Text + "\\7.txt");
            File.Delete(txtDosyaYolu.Text + "\\7barkod.png");
            File.Delete(txtDosyaYolu.Text + "\\8.txt");
            File.Delete(txtDosyaYolu.Text + "\\8barkod.png");
            File.Delete(txtDosyaYolu.Text + "\\9.txt");
            File.Delete(txtDosyaYolu.Text + "\\9barkod.png");
            File.Delete(txtDosyaYolu.Text + "\\10.txt");
            File.Delete(txtDosyaYolu.Text + "\\10barkod.png");
            File.Delete(txtDosyaYolu.Text + "\\11.txt");
            File.Delete(txtDosyaYolu.Text + "\\11barkod.png");
            File.Delete(txtDosyaYolu.Text + "\\12.txt");
            File.Delete(txtDosyaYolu.Text + "\\12barkod.png");
            File.Delete(txtDosyaYolu.Text + "\\13.txt");
            File.Delete(txtDosyaYolu.Text + "\\13barkod.png");
            File.Delete(txtDosyaYolu.Text + "\\14.txt");
            File.Delete(txtDosyaYolu.Text + "\\14barkod.png");
            File.Delete(txtDosyaYolu.Text + "\\15.txt");
            File.Delete(txtDosyaYolu.Text + "\\15barkod.png");
            File.Delete(txtDosyaYolu.Text + "\\16.txt");
            File.Delete(txtDosyaYolu.Text + "\\16barkod.png");
            File.Delete(txtDosyaYolu.Text + "\\17.txt");
            File.Delete(txtDosyaYolu.Text + "\\17barkod.png");
            File.Delete(txtDosyaYolu.Text + "\\18.txt");
            File.Delete(txtDosyaYolu.Text + "\\18barkod.png");
            File.Delete(txtDosyaYolu.Text + "\\19.txt");
            File.Delete(txtDosyaYolu.Text + "\\19barkod.png");
            File.Delete(txtDosyaYolu.Text + "\\20.txt");
            File.Delete(txtDosyaYolu.Text + "\\20barkod.png");
        }

        private void TempiTemizle()
        {
            //try
            //{
            //    string[] dosyalar = Directory.GetFiles("https://www.sultanlar.com.tr/sultanlarui/brosur/temp");
            //    for (int i = 0; i < dosyalar.Length; i++)
            //    {
            //        if (!dosyalar[i].EndsWith("header-bg.png") && !dosyalar[i].EndsWith("footer-bg.png"))
            //            File.Delete(dosyalar[i]);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}

            if (Directory.Exists("c:\\windows\\temp\\brosur"))
            {
                Directory.Delete("c:\\windows\\temp\\brosur", true);
            }
        }

        private void btnCiktiYolu_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtCiktiYolu.Text = fbd.SelectedPath;
            }
        }

        private void rb1_CheckedChanged(object sender, EventArgs e)
        {
            if (txtDosyaYolu.Text != string.Empty)
            {
                if (rb1.Checked)
                {
                    //txtCiktiYolu.Text = txtDosyaYolu.Text + "\\Brosur-1";
                    seciliRadioButton = "1";
                }
                else if (rb2.Checked)
                {
                    //txtCiktiYolu.Text = txtDosyaYolu.Text + "\\Brosur-2";
                    seciliRadioButton = "2";
                }
                else if (rb4.Checked)
                {
                    //txtCiktiYolu.Text = txtDosyaYolu.Text + "\\Brosur-4";
                    seciliRadioButton = "4";
                }
                else if (rb6.Checked)
                {
                    //txtCiktiYolu.Text = txtDosyaYolu.Text + "\\Brosur-6";
                    seciliRadioButton = "6";
                }
                else if (rb9.Checked)
                {
                    //txtCiktiYolu.Text = txtDosyaYolu.Text + "\\Brosur-9";
                    seciliRadioButton = "9";
                }
                else if (rb12.Checked)
                {
                    //txtCiktiYolu.Text = txtDosyaYolu.Text + "\\Brosur-12";
                    seciliRadioButton = "12";
                }
                else if (rb16.Checked)
                {
                    //txtCiktiYolu.Text = txtDosyaYolu.Text + "\\Brosur-16";
                    seciliRadioButton = "16";
                }
                else if (rb20.Checked)
                {
                    //txtCiktiYolu.Text = txtDosyaYolu.Text + "\\Brosur-20";
                    seciliRadioButton = "20";
                }
            }
        }

        private void txtDosyaYolu_TextChanged(object sender, EventArgs e)
        {
            //rb1.Checked = true;

            if (txtDosyaYolu.Text != string.Empty && txtCiktiYolu.Text != string.Empty)
            {
                txtKoliAdedi.Enabled = true;
                btnOlustur.Enabled = true;
                rb1.Enabled = true; rb2.Enabled = true; rb4.Enabled = true; rb6.Enabled = true; rb9.Enabled = true; rb12.Enabled = true; rb16.Enabled = true; rb20.Enabled = true;
                txtRenk.Enabled = true; cmbRenkler.Enabled = true;
                txtExcel.Enabled = true; btnExcelDosyasi.Enabled = true;
                txtCiktiYolu.Enabled = true; btnCiktiYolu.Enabled = true;
                cmbBarkodTur.Enabled = true;
            }
            else
            {
                txtKoliAdedi.Enabled = false;
                btnOlustur.Enabled = false;
                rb1.Enabled = false; rb2.Enabled = false; rb4.Enabled = false; rb6.Enabled = false; rb9.Enabled = false; rb12.Enabled = false; rb16.Enabled = false; rb20.Enabled = false;
                txtRenk.Enabled = false; cmbRenkler.Enabled = false;
                txtExcel.Enabled = false; btnExcelDosyasi.Enabled = false;
                txtCiktiYolu.Enabled = false; btnCiktiYolu.Enabled = false;
                cmbBarkodTur.Enabled = false;
            }
        }

        private void btnYazdir_Click(object sender, EventArgs e)
        {
            Microsoft.Win32.RegistryKey yaziciustalt = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Internet Explorer\\PageSetup", true);
            yaziciustalt.SetValue("footer", "");
            yaziciustalt.SetValue("header", "");
            yaziciustalt.SetValue("Shrink_To_Fit", "yes");

            webBrowser1.ShowPrintPreviewDialog();

            //yaziciustalt.SetValue("footer", "&u&b&d");
            //yaziciustalt.SetValue("header", "&w&bPage &p of &P");
            //yaziciustalt.SetValue("Shrink_To_Fit", "no");
        }

        private void BarkodOlustur(string Barkod, string Yer, string Numara)
        {
            BarcodeLib.Barcode bc = new BarcodeLib.Barcode();
            bc.LabelFont = new System.Drawing.Font("Arial", 192, FontStyle.Regular);
            bc.IncludeLabel = true;
            bc.Width = 2000;
            bc.Height = 912;
            bc.ImageFormat = System.Drawing.Imaging.ImageFormat.Png;
            bc.Alignment = BarcodeLib.AlignmentPositions.CENTER;
            bc.BackColor = Color.White;
            bc.ForeColor = System.Drawing.ColorTranslator.FromHtml("#" + txtBarkodRenk.Text);

            try
            {
                if (Barkod.Trim().Length == 13 && Barkod.Trim().StartsWith("868"))
                    bc.Encode(BarcodeLib.TYPE.CODE128, Barkod);
                else if (Barkod.Trim().Length == 13)
                    bc.Encode(BarcodeLib.TYPE.EAN13, Barkod);
                else if (Barkod.Trim().Length == 8)
                    bc.Encode(BarcodeLib.TYPE.EAN8, Barkod);
                else if (Barkod.Trim().Length == 14)
                    bc.Encode(BarcodeLib.TYPE.ITF14, Barkod);
                else if (Barkod.Trim().Length == 12)
                    bc.Encode(BarcodeLib.TYPE.UPCA, Barkod);
                 
                bc.SaveImage(Yer + "\\" + Numara + "barkod.png", BarcodeLib.SaveTypes.PNG);
            }
            catch (Exception ex)
            {
                if (ex.Message == "EEAN13-3: Country assigning manufacturer code not found.")
                {
                    bc.Encode(BarcodeLib.TYPE.CODE128, Barkod);
                    bc.SaveImage(Yer + "\\" + Numara + "barkod.png", BarcodeLib.SaveTypes.PNG);
                }
                else
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void ExceldenAl(string dosya)
        {
            Microsoft.Office.Interop.Excel.Application ap = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook wb = null;
            Microsoft.Office.Interop.Excel.Worksheet ws = null;
            Microsoft.Office.Interop.Excel.Range range = null;

            object[,] values = null;

            try
            {
                wb = ap.Workbooks.Open(dosya, false, true,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing, true);

                ws = (Microsoft.Office.Interop.Excel.Worksheet)wb.Worksheets[1];

                range = ws.get_Range("A1", "C" + seciliRadioButton);

                values = (object[,])range.Value2;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            finally
            {
                range = null;
                ws = null;
                if (wb != null)
                    wb.Close(false, System.Reflection.Missing.Value, System.Reflection.Missing.Value);
                wb = null;
                if (ap != null)
                    ap.Quit();
                ap = null;
            }

            string hata = string.Empty;

            for (int i = 1; i <= values.GetLength(0); i++)
            {
                try
                { File.WriteAllText(txtDosyaYolu.Text + "\\" + i.ToString() + ".txt", values[i, 1].ToString() + Environment.NewLine + values[i, 2].ToString().ToUpper(), Encoding.GetEncoding("iso-8859-9")); }
                catch
                { hata += i.ToString() + ". ürünün bilgileri alınamadı." + Environment.NewLine; }
                try
                { BarkodOlustur(values[i, 3].ToString(), txtDosyaYolu.Text, i.ToString()); }
                catch (Exception ex)
                { hata += i.ToString() + ". ürünün barkodu oluşturulamadı." + Environment.NewLine; }
            }

            if (hata != string.Empty)
                MessageBox.Show(hata);
        }

        private void btnExcelDosyasi_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Excel dosyaları (*.xls, *.xlsx)|*.xls;*.xlsx;|Bütün Dosyalar|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtExcel.Text = ofd.FileName;
            }
        }

        private void lblAciklama_MouseHover(object sender, EventArgs e)
        {
            pnlAciklama.Visible = true;
        }

        private void lblAciklama_MouseLeave(object sender, EventArgs e)
        {
            pnlAciklama.Visible = false;
        }

        private void cmbRenkler_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbRenkler.SelectedItem.ToString() == "Beyaz")
                txtRenk.Text = "#FFFFFF";
            else if (cmbRenkler.SelectedItem.ToString() == "Gri")
                txtRenk.Text = "#C8C9C3";
        }

        private void frmBrosur_FormClosing(object sender, FormClosingEventArgs e)
        {
            TempiTemizle();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            //webBrowser1.ShowSaveAsDialog();

            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string klasor = string.Empty;

                if (!Directory.Exists(fbd.SelectedPath + "\\Brosur"))
                {
                    Directory.CreateDirectory(fbd.SelectedPath + "\\Brosur");
                    klasor = "Brosur";
                }
                else
                {
                    int i = 0;
                    while (i < 1000)
                    {
                        if (Directory.Exists(fbd.SelectedPath + "\\Brosur" + i.ToString()))
                        {
                            i++;
                        }
                        else
                        {
                            Directory.CreateDirectory(fbd.SelectedPath + "\\Brosur" + i.ToString());
                            klasor = "Brosur" + i.ToString();
                            i = 1000;
                        }
                    }
                }



                //string[] dosyalar = Directory.GetFiles("https://www.sultanlar.com.tr/sultanlarui/brosur/temp");
                string[] dosyalar = Directory.GetFiles("c:\\windows\\temp\\brosur");
                for (int i = 0; i < dosyalar.Length; i++)
                {
                    string dosyaismi = dosyalar[i].Substring(dosyalar[i].LastIndexOf("\\") + 1);
                    File.Copy(dosyalar[i], fbd.SelectedPath + "\\" + klasor + "\\" + dosyaismi, true);
                    if (dosyaismi.IndexOf("htm") < 0)
                        File.SetAttributes(fbd.SelectedPath + "\\" + klasor + "\\" + dosyaismi, FileAttributes.Hidden);
                }
            }
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmInputBox frm = new frmInputBox("Barkod oluştur");
            frm.ShowDialog();

            if (frmAna.InputBox != string.Empty)
            {
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    BarkodOlustur(frmAna.InputBox, fbd.SelectedPath, frmAna.InputBox);
                    MessageBox.Show("Barkod oluşturuldu.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                frmAna.InputBox = string.Empty;
            }
        }

        private string[] ExceldenBarkodAl(string dosya)
        {
            Microsoft.Office.Interop.Excel.Application ap = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook wb = null;
            Microsoft.Office.Interop.Excel.Worksheet ws = null;
            Microsoft.Office.Interop.Excel.Range range = null;

            object[,] values = null;

            try
            {
                wb = ap.Workbooks.Open(dosya, false, true,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing, true);

                ws = (Microsoft.Office.Interop.Excel.Worksheet)wb.Worksheets[1];

                range = ws.get_Range("A1", "A1000");

                values = (object[,])range.Value2;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                range = null;
                ws = null;
                if (wb != null)
                    wb.Close(false, System.Reflection.Missing.Value, System.Reflection.Missing.Value);
                wb = null;
                if (ap != null)
                    ap.Quit();
                ap = null;
            }

            int dizesayisi = 0;
            for (int i = 1; i < values.GetLength(0); i++)
            {
                if (values[i, 1] == null)
                    break;
                else
                    dizesayisi++;
            }

            string[] donendeger = new string[dizesayisi];
            for (int i = 1; i <= values.GetLength(0); i++)
            {
                if (values[i, 1] == null)
                    break;
                donendeger[i - 1] = values[i, 1].ToString();
            }

            return donendeger;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string[] barkodlar = null;
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Excel dosyaları (*.xls, *.xlsx)|*.xls;*.xlsx;|Bütün Dosyalar|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
                barkodlar = ExceldenBarkodAl(ofd.FileName);

            if (barkodlar != null)
            {
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    for (int i = 0; i < barkodlar.Length; i++)
                        BarkodOlustur(barkodlar[i], fbd.SelectedPath, barkodlar[i]);
                    MessageBox.Show("Barkodlar oluşturuldu.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}

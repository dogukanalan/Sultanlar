using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Sultanlar.UI
{
    public partial class frmKampanya : Form
    {
        public frmKampanya()
        {
            InitializeComponent();
        }

        object[,] bilgiler = null;

        private void frmKampanya_Load(object sender, EventArgs e)
        {
            TempiTemizle();
        }

        private void btnDosyaYolu_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtDosyaYolu.Text = fbd.SelectedPath;
                btnExcel.Enabled = true;
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Excel dosyaları (*.xls, *.xlsx)|*.xls;*.xlsx;|Bütün Dosyalar|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtExcel.Text = ofd.FileName;
                btnOlustur.Enabled = true;
            }
        }

        private void btnOlustur_Click(object sender, EventArgs e)
        {
            try
            {
                TempiTemizle();
                ExceldenAl();
                SayfaOlustur();
                webBrowser1.Navigate(Application.StartupPath + "\\temp\\Sultanlar\\kampanya\\kampanya.htm");

                btnKaydet.Enabled = true;
                btnYazdir.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu:\r\n\r\n" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void frmKampanya_FormClosing(object sender, FormClosingEventArgs e)
        {
            //TempiTemizle();
        }

        private void TempiTemizle()
        {
            if (Directory.Exists(Application.StartupPath + "\\temp\\Sultanlar\\kampanya"))
            {
                Directory.Delete(Application.StartupPath + "\\temp\\Sultanlar\\kampanya", true);
            }
        }

        private void SayfaOlustur()
        {
            for (int i = 1; i <= 11; i++)
            {
                if (bilgiler[i, 1] == null)
                    bilgiler[i, 1] = "";
                if (bilgiler[i, 2] == null)
                    bilgiler[i, 2] = "";
                if (bilgiler[i, 3] == null)
                    bilgiler[i, 3] = "";
                if (bilgiler[i, 4] == null)
                    bilgiler[i, 4] = "";

                if (i < 11 && bilgiler[i, 2] != "")
                    bilgiler[i, 2] = Convert.ToDecimal(bilgiler[i, 2].ToString().Trim()).ToString("N2");
            }

            string sayfa = File.ReadAllText("https://www.sultanlar.com.tr/sultanlarui/kampanya-templates/template8.txt");
            if (rb10.Checked)
                sayfa = File.ReadAllText("https://www.sultanlar.com.tr/sultanlarui/kampanya-templates/template10.txt");
            else if (rb7.Checked)
                sayfa = File.ReadAllText("https://www.sultanlar.com.tr/sultanlarui/kampanya-templates/template7.txt");
            else if (rb6.Checked)
                sayfa = File.ReadAllText("https://www.sultanlar.com.tr/sultanlarui/kampanya-templates/template6.txt");
            else if (rb5.Checked)
                sayfa = File.ReadAllText("https://www.sultanlar.com.tr/sultanlarui/kampanya-templates/template5.txt");
            else if (rb4.Checked)
                sayfa = File.ReadAllText("https://www.sultanlar.com.tr/sultanlarui/kampanya-templates/template4.txt");
            else if (rb3.Checked)
                sayfa = File.ReadAllText("https://www.sultanlar.com.tr/sultanlarui/kampanya-templates/template3.txt");
            else if (rb2.Checked)
                sayfa = File.ReadAllText("https://www.sultanlar.com.tr/sultanlarui/kampanya-templates/template2.txt");
            else if (rb1.Checked)
                sayfa = File.ReadAllText("https://www.sultanlar.com.tr/sultanlarui/kampanya-templates/template1.txt");

            sayfa = sayfa.Replace("<span id='solbaslik'></span>", "<span id='solbaslik'>" + bilgiler[11, 1].ToString() + "</span>");
            sayfa = sayfa.Replace("<span id='tarih'></span>", "<span id='tarih'>" + DateTime.FromOADate(Convert.ToDouble(bilgiler[11, 2])).ToShortDateString()+ "</span>");
            sayfa = sayfa.Replace("<span id='altyazi'></span>", "<span id='altyazi'>" + bilgiler[11, 3].ToString() + "</span>");
            sayfa = sayfa.Replace("<span id='sayfano'></span>", "<span id='sayfano'>" + bilgiler[11, 4].ToString() + "</span>");

            sayfa = sayfa.Replace("<span id='urun1ust'></span>", "<span id='urun1ust'>" + bilgiler[1, 1].ToString() + "</span>");
            sayfa = sayfa.Replace("<span id='urun1alt'></span>", "<span id='urun1alt'>" + bilgiler[1, 4].ToString() + "</span>");
            sayfa = sayfa.Replace("<span id='urun1gun'></span>", "<span id='urun1gun'>" + bilgiler[1, 3].ToString() + "</span>");
            sayfa = sayfa.Replace("<span id='urun1fiyat'></span>", "<span id='urun1fiyat'>" + bilgiler[1, 2].ToString() + "</span>");

            sayfa = sayfa.Replace("<span id='urun2ust'></span>", "<span id='urun2ust'>" + bilgiler[2, 1].ToString() + "</span>");
            sayfa = sayfa.Replace("<span id='urun2alt'></span>", "<span id='urun2alt'>" + bilgiler[2, 4].ToString() + "</span>");
            sayfa = sayfa.Replace("<span id='urun2gun'></span>", "<span id='urun2gun'>" + bilgiler[2, 3].ToString() + "</span>");
            sayfa = sayfa.Replace("<span id='urun2fiyat'></span>", "<span id='urun2fiyat'>" + bilgiler[2, 2].ToString() + "</span>");

            sayfa = sayfa.Replace("<span id='urun3ust'></span>", "<span id='urun3ust'>" + bilgiler[3, 1].ToString() + "</span>");
            sayfa = sayfa.Replace("<span id='urun3alt'></span>", "<span id='urun3alt'>" + bilgiler[3, 4].ToString() + "</span>");
            sayfa = sayfa.Replace("<span id='urun3gun'></span>", "<span id='urun3gun'>" + bilgiler[3, 3].ToString() + "</span>");
            sayfa = sayfa.Replace("<span id='urun3fiyat'></span>", "<span id='urun3fiyat'>" + bilgiler[3, 2].ToString() + "</span>");

            sayfa = sayfa.Replace("<span id='urun4ust'></span>", "<span id='urun4ust'>" + bilgiler[4, 1].ToString() + "</span>");
            sayfa = sayfa.Replace("<span id='urun4alt'></span>", "<span id='urun4alt'>" + bilgiler[4, 4].ToString() + "</span>");
            sayfa = sayfa.Replace("<span id='urun4gun'></span>", "<span id='urun4gun'>" + bilgiler[4, 3].ToString() + "</span>");
            sayfa = sayfa.Replace("<span id='urun4fiyat'></span>", "<span id='urun4fiyat'>" + bilgiler[4, 2].ToString() + "</span>");

            sayfa = sayfa.Replace("<span id='urun5ust'></span>", "<span id='urun5ust'>" + bilgiler[5, 1].ToString() + "</span>");
            sayfa = sayfa.Replace("<span id='urun5alt'></span>", "<span id='urun5alt'>" + bilgiler[5, 4].ToString() + "</span>");
            sayfa = sayfa.Replace("<span id='urun5gun'></span>", "<span id='urun5gun'>" + bilgiler[5, 3].ToString() + "</span>");
            sayfa = sayfa.Replace("<span id='urun5fiyat'></span>", "<span id='urun5fiyat'>" + bilgiler[5, 2].ToString() + "</span>");

            sayfa = sayfa.Replace("<span id='urun6ust'></span>", "<span id='urun6ust'>" + bilgiler[6, 1].ToString() + "</span>");
            sayfa = sayfa.Replace("<span id='urun6alt'></span>", "<span id='urun6alt'>" + bilgiler[6, 4].ToString() + "</span>");
            sayfa = sayfa.Replace("<span id='urun6gun'></span>", "<span id='urun6gun'>" + bilgiler[6, 3].ToString() + "</span>");
            sayfa = sayfa.Replace("<span id='urun6fiyat'></span>", "<span id='urun6fiyat'>" + bilgiler[6, 2].ToString() + "</span>");

            sayfa = sayfa.Replace("<span id='urun7ust'></span>", "<span id='urun7ust'>" + bilgiler[7, 1].ToString() + "</span>");
            sayfa = sayfa.Replace("<span id='urun7alt'></span>", "<span id='urun7alt'>" + bilgiler[7, 4].ToString() + "</span>");
            sayfa = sayfa.Replace("<span id='urun7gun'></span>", "<span id='urun7gun'>" + bilgiler[7, 3].ToString() + "</span>");
            sayfa = sayfa.Replace("<span id='urun7fiyat'></span>", "<span id='urun7fiyat'>" + bilgiler[7, 2].ToString() + "</span>");

            sayfa = sayfa.Replace("<span id='urun8ust'></span>", "<span id='urun8ust'>" + bilgiler[8, 1].ToString() + "</span>");
            sayfa = sayfa.Replace("<span id='urun8alt'></span>", "<span id='urun8alt'>" + bilgiler[8, 4].ToString() + "</span>");
            sayfa = sayfa.Replace("<span id='urun8gun'></span>", "<span id='urun8gun'>" + bilgiler[8, 3].ToString() + "</span>");
            sayfa = sayfa.Replace("<span id='urun8fiyat'></span>", "<span id='urun8fiyat'>" + bilgiler[8, 2].ToString() + "</span>");

            sayfa = sayfa.Replace("<span id='urun9ust'></span>", "<span id='urun9ust'>" + bilgiler[9, 1].ToString() + "</span>");
            sayfa = sayfa.Replace("<span id='urun9alt'></span>", "<span id='urun9alt'>" + bilgiler[9, 4].ToString() + "</span>");
            sayfa = sayfa.Replace("<span id='urun9gun'></span>", "<span id='urun9gun'>" + bilgiler[9, 3].ToString() + "</span>");
            sayfa = sayfa.Replace("<span id='urun9fiyat'></span>", "<span id='urun9fiyat'>" + bilgiler[9, 2].ToString() + "</span>");

            sayfa = sayfa.Replace("<span id='urun10ust'></span>", "<span id='urun10ust'>" + bilgiler[10, 1].ToString() + "</span>");
            sayfa = sayfa.Replace("<span id='urun10alt'></span>", "<span id='urun10alt'>" + bilgiler[10, 4].ToString() + "</span>");
            sayfa = sayfa.Replace("<span id='urun10gun'></span>", "<span id='urun10gun'>" + bilgiler[10, 3].ToString() + "</span>");
            sayfa = sayfa.Replace("<span id='urun10fiyat'></span>", "<span id='urun10fiyat'>" + bilgiler[10, 2].ToString() + "</span>");

            Directory.CreateDirectory(Application.StartupPath + "\\temp\\Sultanlar\\kampanya");
            File.WriteAllText(Application.StartupPath + "\\temp\\Sultanlar\\kampanya\\kampanya.htm", sayfa, Encoding.GetEncoding("iso-8859-9"));

            File.Copy("https://www.sultanlar.com.tr/sultanlarui/kampanya-resim\\logo.png", Application.StartupPath + "\\temp\\Sultanlar\\kampanya\\logo.png", true);
            File.SetAttributes(Application.StartupPath + "\\temp\\Sultanlar\\kampanya\\logo.png", FileAttributes.Hidden);
            File.Copy("https://www.sultanlar.com.tr/sultanlarui/kampanya-resim\\slogan.png", Application.StartupPath + "\\temp\\Sultanlar\\kampanya\\slogan.png", true);
            File.SetAttributes(Application.StartupPath + "\\temp\\Sultanlar\\kampanya\\slogan.png", FileAttributes.Hidden);
            File.Copy("https://www.sultanlar.com.tr/sultanlarui/kampanya-resim\\bottomleft.png", Application.StartupPath + "\\temp\\Sultanlar\\kampanya\\bottomleft.png", true);
            File.SetAttributes(Application.StartupPath + "\\temp\\Sultanlar\\kampanya\\bottomleft.png", FileAttributes.Hidden);
            File.Copy("https://www.sultanlar.com.tr/sultanlarui/kampanya-resim\\bottomleftIC.png", Application.StartupPath + "\\temp\\Sultanlar\\kampanya\\bottomleftIC.png", true);
            File.SetAttributes(Application.StartupPath + "\\temp\\Sultanlar\\kampanya\\bottomleftIC.png", FileAttributes.Hidden);
            File.Copy("https://www.sultanlar.com.tr/sultanlarui/kampanya-resim\\bottomright.png", Application.StartupPath + "\\temp\\Sultanlar\\kampanya\\bottomright.png", true);
            File.SetAttributes(Application.StartupPath + "\\temp\\Sultanlar\\kampanya\\bottomright.png", FileAttributes.Hidden);
            File.Copy("https://www.sultanlar.com.tr/sultanlarui/kampanya-resim\\bottomrightIC.png", Application.StartupPath + "\\temp\\Sultanlar\\kampanya\\bottomrightIC.png", true);
            File.SetAttributes(Application.StartupPath + "\\temp\\Sultanlar\\kampanya\\bottomrightIC.png", FileAttributes.Hidden);
            File.Copy("https://www.sultanlar.com.tr/sultanlarui/kampanya-resim\\topleft.png", Application.StartupPath + "\\temp\\Sultanlar\\kampanya\\topleft.png", true);
            File.SetAttributes(Application.StartupPath + "\\temp\\Sultanlar\\kampanya\\topleft.png", FileAttributes.Hidden);
            File.Copy("https://www.sultanlar.com.tr/sultanlarui/kampanya-resim\\topleftIC.png", Application.StartupPath + "\\temp\\Sultanlar\\kampanya\\topleftIC.png", true);
            File.SetAttributes(Application.StartupPath + "\\temp\\Sultanlar\\kampanya\\topleftIC.png", FileAttributes.Hidden);
            File.Copy("https://www.sultanlar.com.tr/sultanlarui/kampanya-resim\\topright.png", Application.StartupPath + "\\temp\\Sultanlar\\kampanya\\topright.png", true);
            File.SetAttributes(Application.StartupPath + "\\temp\\Sultanlar\\kampanya\\topright.png", FileAttributes.Hidden);
            File.Copy("https://www.sultanlar.com.tr/sultanlarui/kampanya-resim\\toprightIC.png", Application.StartupPath + "\\temp\\Sultanlar\\kampanya\\toprightIC.png", true);
            File.SetAttributes(Application.StartupPath + "\\temp\\Sultanlar\\kampanya\\toprightIC.png", FileAttributes.Hidden);

            string[] dosyalar = Directory.GetFiles(txtDosyaYolu.Text.Trim());
            for (int i = 0; i < dosyalar.Length; i++)
            {
                string dosyaismi = dosyalar[i].Substring(dosyalar[i].LastIndexOf("\\") + 1);
                if (dosyaismi.EndsWith("png") || dosyaismi.EndsWith("PNG"))
                {
                    File.Copy(dosyalar[i], Application.StartupPath + "\\temp\\Sultanlar\\kampanya\\" + dosyaismi, true);
                    File.SetAttributes(Application.StartupPath + "\\temp\\Sultanlar\\kampanya\\" + dosyaismi, FileAttributes.Hidden);
                }
            }
        }

        private void ExceldenAl()
        {
            Microsoft.Office.Interop.Excel.Application ap = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook wb = null;
            Microsoft.Office.Interop.Excel.Worksheet ws = null;
            Microsoft.Office.Interop.Excel.Range range = null;

            try
            {
                wb = ap.Workbooks.Open(txtExcel.Text.Trim(), false, true,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing, true);

                ws = (Microsoft.Office.Interop.Excel.Worksheet)wb.Worksheets[1];
                
                range = ws.get_Range("A1", "D11");

                bilgiler = (object[,])range.Value2;
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
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string klasor = string.Empty;

                if (!Directory.Exists(fbd.SelectedPath + "\\kampanya"))
                {
                    Directory.CreateDirectory(fbd.SelectedPath + "\\kampanya");
                    klasor = "kampanya";
                }
                else
                {
                    int i = 0;
                    while (i < 1000)
                    {
                        if (Directory.Exists(fbd.SelectedPath + "\\kampanya" + i.ToString()))
                        {
                            i++;
                        }
                        else
                        {
                            Directory.CreateDirectory(fbd.SelectedPath + "\\kampanya" + i.ToString());
                            klasor = "kampanya" + i.ToString();
                            i = 1000;
                        }
                    }
                }

                string[] dosyalar = Directory.GetFiles(Application.StartupPath + "\\temp\\Sultanlar\\kampanya");
                for (int i = 0; i < dosyalar.Length; i++)
                {
                    string dosyaismi = dosyalar[i].Substring(dosyalar[i].LastIndexOf("\\") + 1);
                    File.Copy(dosyalar[i], fbd.SelectedPath + "\\" + klasor + "\\" + dosyaismi, true);
                    if (dosyaismi.IndexOf("htm") < 0)
                        File.SetAttributes(fbd.SelectedPath + "\\" + klasor + "\\" + dosyaismi, FileAttributes.Hidden);
                }
            }
        }

        private void btnYazdir_Click(object sender, EventArgs e)
        {
            Microsoft.Win32.RegistryKey yaziciustalt = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Internet Explorer\\PageSetup", true);
            yaziciustalt.SetValue("footer", "");
            yaziciustalt.SetValue("header", "");
            yaziciustalt.SetValue("Shrink_To_Fit", "yes");

            webBrowser1.ShowPrintPreviewDialog();
        }

        private void btnKampanyaYardim_Click(object sender, EventArgs e)
        {
            frmFotografBilgi frm = new frmFotografBilgi(Properties.Resources.kampanyabrosuraciklama);
            frm.ShowDialog();
        }

        private void btnExcelYardim_Click(object sender, EventArgs e)
        {
            frmFotografBilgi frm = new frmFotografBilgi(Properties.Resources.kampanyaexcelaciklama2);
            frm.ShowDialog();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sultanlar.DatabaseObject.Internet;
using System.Collections;
using System.Threading;
using System.Data.SqlClient;
using Sultanlar.DatabaseObject;

namespace Sultanlar.UI
{
    public partial class frmINTERNETticaripazarlamasatisrapor : Form
    {
        public frmINTERNETticaripazarlamasatisrapor()
        {
            InitializeComponent();
        }

        ArrayList satisraporlar = new ArrayList();
        ArrayList satisraporlarolmayancariler = new ArrayList();
        Thread thr;
        bool hesaplamayapilabilir;

        private void frmINTERNETticaripazarlamasatisrapor_Load(object sender, EventArgs e)
        {
            if (System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator != ",")
            {
                MessageBox.Show("Bilgisayarın ondalık ayracı virgül (,) olmadığından bu formun içeriği açılamaz. Formun içeriğine erişmek için Denetim Masası > Bölgesel Ayarlar menüsünden ondalık ayracı virgül (,) yapınız ve formu tekrar açınız.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Enabled = false;
            }

            CheckForIllegalCrossThreadCalls = false;
            DevExpress.Data.CurrencyDataController.DisableThreadingProblemsDetection = true;

            lblTAH.Visible = false;
            lblTAH1.Visible = false;
            lblYEG.Visible = false;
            lblYEG1.Visible = false;
            lblToplam.Visible = false;
            lblToplam1.Visible = false;

            hesaplamayapilabilir = false;
            GetBayiler();
            cmbYil.SelectedIndex = 9;
            cmbAy.SelectedIndex = 0;
            GetSatisRaporBos();
        }

        private void frmINTERNETticaripazarlamasatisrapor_SizeChanged(object sender, EventArgs e)
        {
            sbHesapla.Location = new Point(sbHesapla.Location.X, lblAlt.Location.Y + 6);
            sbKaydet.Location = new Point(sbKaydet.Location.X, lblAlt.Location.Y + 6);
            sbHesaplaKaydet.Location = new Point(sbHesaplaKaydet.Location.X, lblAlt.Location.Y + 6);
            sbExceleAktar.Location = new Point(sbExceleAktar.Location.X, lblAlt.Location.Y + 6);
            sbNoktaAdDegistir.Location = new Point(sbNoktaAdDegistir.Location.X, lblAlt.Location.Y + 6);
            progressBar1.Location = new Point(progressBar1.Location.X, lblAlt.Location.Y + 6);

            lblTAH1.Location = new Point(this.Width - 289, lblAlt.Location.Y + 4);
            lblYEG1.Location = new Point(this.Width - 189, lblAlt.Location.Y + 4);
            lblToplam1.Location = new Point(this.Width - 99, lblAlt.Location.Y + 4);

            lblTAH.Location = new Point(this.Width - 322, lblAlt.Location.Y + 19);
            lblYEG.Location = new Point(this.Width - 222, lblAlt.Location.Y + 19);
            lblToplam.Location = new Point(this.Width - 122, lblAlt.Location.Y + 19);
        }

        private void gridView1_ColumnFilterChanged(object sender, EventArgs e)
        {
            this.Text = "Ticari Pazarlama : Satış Raporu (Satır sayısı: " + gridView1.RowCount.ToString() + ")";
            //sbHesapla.Enabled = gridView1.ActiveFilter.Count == 0;
            sbKaydet.Enabled = gridView1.ActiveFilter.Count == 0;
            sbHesaplaKaydet.Enabled = gridView1.ActiveFilter.Count == 0;
            //lblTAH.Visible = gridView1.ActiveFilter.Count == 0; // Convert.ToInt32(gridView1.GetRowCellValue(0, "Degistirildi")) != 0
            //lblTAH1.Visible = gridView1.ActiveFilter.Count == 0;
            //lblYEG.Visible = gridView1.ActiveFilter.Count == 0;
            //lblYEG1.Visible = gridView1.ActiveFilter.Count == 0;
            //lblToplam.Visible = gridView1.ActiveFilter.Count == 0;
            //lblToplam1.Visible = gridView1.ActiveFilter.Count == 0;
        }

        private void GetBayiler()
        {
            CariHesaplarTP.GetObjects(cmbBayiler.Items, 0);
            cmbBayiler.Items.Add("SULTANLAR PAZARLAMA A.Ş.");
        }

        private void GetSatisRaporBos()
        {
            DataTable dt = new DataTable();
            SatisRaporTP.GetObjects(dt, 100, 100, 100);
            gridControl1.DataSource = dt;

            //decimal[] toplamlar = SatisRaporTP.GetToplamlar(100, 100, 100);
            //lblTAH.Text = toplamlar[0].ToString("C2");
            //lblYEG.Text = toplamlar[1].ToString("C2");
            //lblToplam.Text = (toplamlar[0] + toplamlar[1]).ToString("C2");
        }

        private void GetSatisRapor(int GMREF, byte Ay, short Yil)
        {
            DataTable dt = new DataTable();
            SatisRaporTP.GetObjects(dt, GMREF, Ay, Yil);
            gridControl1.DataSource = dt;

            //decimal[] toplamlar = SatisRaporTP.GetToplamlar(GMREF, Ay, Yil);
            //lblTAH.Text = toplamlar[0].ToString("C2");
            //lblYEG.Text = toplamlar[1].ToString("C2");
            //lblToplam.Text = (toplamlar[0] + toplamlar[1]).ToString("C2");
        }

        private DataTable GetSatisRapor(int GMREF, byte Ay, short Yil, bool sourceyap)
        {
            DataTable dt = new DataTable();
            SatisRaporTP.GetObjects(dt, GMREF, Ay, Yil);
            if (sourceyap)
                gridControl1.DataSource = dt;
            return dt;
        }

        private void sbGetir_Click(object sender, EventArgs e)
        {
            if (cmbBayiler.SelectedIndex > -1 && cmbBayiler.SelectedItem.ToString() != "SULTANLAR PAZARLAMA A.Ş.")
            {
                byte ay = cmbAy.SelectedIndex > 0 ? Convert.ToByte(cmbAy.SelectedItem) : (byte)0;
                short yil = cmbYil.SelectedIndex > 0 ? Convert.ToInt16(cmbYil.SelectedItem) : (short)0;

                GetSatisRapor(((CariHesaplarTP)cmbBayiler.SelectedItem).GMREF, ay, yil);
                hesaplamayapilabilir = true;
            }
            else if (cmbBayiler.SelectedIndex > -1 && cmbBayiler.SelectedItem.ToString() == "SULTANLAR PAZARLAMA A.Ş.")
            {
                byte ay = cmbAy.SelectedIndex > 0 ? Convert.ToByte(cmbAy.SelectedItem) : (byte)0;
                short yil = cmbYil.SelectedIndex > 0 ? Convert.ToInt16(cmbYil.SelectedItem) : (short)0;

                GetSatisRapor(-1, ay, yil);
                hesaplamayapilabilir = true;
            }
            else if (cmbBayiler.SelectedIndex == -1)
            {
                byte ay = cmbAy.SelectedIndex > 0 ? Convert.ToByte(cmbAy.SelectedItem) : (byte)0;
                short yil = cmbYil.SelectedIndex > 0 ? Convert.ToInt16(cmbYil.SelectedItem) : (short)0;

                GetSatisRapor(0, ay, yil);
                hesaplamayapilabilir = true;
            }
            else
            {
                GetSatisRaporBos();
            }

            this.Text = "Ticari Pazarlama : Satış Raporu (Satır sayısı: " + gridView1.RowCount.ToString() + ")";
        }

        private void cmbBayiler_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cmbBayiler.SelectedIndex > -1)
            //{
            //    cmbYil.Enabled = true;
            //}
            //else
            //{
            //    cmbYil.SelectedIndex = 0;
            //    cmbYil.Enabled = false;
            //}
            hesaplamayapilabilir = false;
        }

        private void cmbYil_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cmbYil.SelectedIndex > 0)
            //{
            //    cmbAy.Enabled = true;
            //}
            //else
            //{
            //    cmbAy.SelectedIndex = 0;
            //    cmbAy.Enabled = false;
            //}
            hesaplamayapilabilir = false;
        }

        private void cmbAy_SelectedIndexChanged(object sender, EventArgs e)
        {
            hesaplamayapilabilir = false;
        }

        private void sbExcel_Click(object sender, EventArgs e)
        {
            if (cmbYil.SelectedIndex > 0 && cmbAy.SelectedIndex > 0)
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Excel dosyaları (*.xls, *.xlsx)|*.xls;*.xlsx;|Bütün Dosyalar|*.*";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    if (MessageBox.Show(cmbYil.SelectedItem.ToString() + " - " + cmbAy.SelectedItem.ToString() + " dönemi için aktarım yapmak istediğinize emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                    {
                        GetSatisRaporBos();
                        thr = new Thread(new ParameterizedThreadStart(ExceldenAl));
                        thr.Start(ofd.FileName);
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen yıl ve ay dönemi seçiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        delegate void ExcelDelegate();

        private void ExceldenAl(object dosya)
        {
            Microsoft.Office.Interop.Excel.Application ap = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook wb = null;
            Microsoft.Office.Interop.Excel.Worksheet ws = null;
            Microsoft.Office.Interop.Excel.Range range = null;

            object[,] values = null;

            try
            {
                wb = ap.Workbooks.Open(dosya.ToString(), false, true,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing, true);

                ws = (Microsoft.Office.Interop.Excel.Worksheet)wb.Worksheets[1];

                if (dosya.ToString().EndsWith(".xls"))
                    range = ws.get_Range("A1", "K65535");
                else
                    range = ws.get_Range("A1", "K1000000");

                values = (object[,])range.Value2;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                satisraporlar.Clear();
                satisraporlarolmayancariler.Clear();
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

            string oncekitext = this.Text;
            this.Enabled = false;
            //progressBar1.Visible = true;
            //progressBar1.Maximum = values.GetLength(0);
            for (int i = 2; i <= values.GetLength(0); i++) // 1.satır başlıklar
            {
                if (values[i, 1] == null) // 1.kolon boş ise bu satırdan sonrasına bakmasın
                    break;

                try
                {
                    SatisRaporTP satisrapor = new SatisRaporTP(values[i, 1].ToString().ToUpper(), values[i, 2].ToString().ToUpper(),
                        values[i, 3] != null ? values[i, 3].ToString().ToUpper() : "", DateTime.FromOADate(Convert.ToDouble(values[i, 4])), 
                        values[i, 5].ToString().ToUpper(),
                        values[i, 6] != null ? values[i, 6].ToString().ToUpper() : "", Convert.ToInt32(values[i, 7]),
                        Convert.ToDecimal(values[i, 8]) / Convert.ToInt32(values[i, 7]),
                        Convert.ToByte(DateTime.FromOADate(Convert.ToDouble(values[i, 4])).Month),
                        Convert.ToInt16(DateTime.FromOADate(Convert.ToDouble(values[i, 4])).Year),
                        0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, false, 0, 0, values[i, 9].ToString().ToUpper(), values[i, 10].ToString().ToUpper());

                    if (values[i, 5].ToString() != string.Empty && Iller.GetKODByIL(values[i, 9].ToString().ToUpper()) > 0) // üretici kodu boş değil ise ve il geçerli ise
                    {
                        if (values[i, 1].ToString() == "1001327") // sultanlar ise
                        {
                            int SMREF = Convert.ToInt32(values[i, 9]); // 9. kolona smref i yazalım (eskisi: CariHesaplar.GetSMREFBySUBE(values[i, 2].ToString().ToUpper()) )
                            satisrapor.NOKTAAD = SMREF.ToString(); // smref i yazıyoruz çünkü nokta ad değişebiliyor sürekli (.HY) falan
                            satisraporlar.Add(satisrapor);
                        }
                        else
                        {
                            int GMREF = CariHesaplarTP.GetGMREFByBAYIKOD(values[i, 1].ToString());
                            string SUBE = CariHesaplarTP.GetNoktaVarMi2(values[i, 10].ToString(), GMREF);
                            if (SUBE != string.Empty || CariHesaplarTP.GetNoktaVarMi(values[i, 2].ToString().ToUpper(), GMREF))
                            {
                                satisrapor.NOKTAAD = SUBE != string.Empty ? SUBE : satisrapor.NOKTAAD;
                                satisraporlar.Add(satisrapor);
                            }
                            else
                            {
                                bool var = false;
                                for (int j = 0; j < satisraporlarolmayancariler.Count; j++)
                                {
                                    if (((SatisRaporTP)satisraporlarolmayancariler[j]).NOKTAAD == satisrapor.NOKTAAD &&
                                        ((SatisRaporTP)satisraporlarolmayancariler[j]).BAYIKOD == satisrapor.BAYIKOD)
                                    {
                                        var = true;
                                        break;
                                    }
                                }

                                if (!var)
                                    satisraporlarolmayancariler.Add(satisrapor);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Hata oluşan satır: " + i.ToString() + "\r\nHata ayrıntısı: Üretici kodu alanı boş veya il alanı geçerli değil.");
                        satisraporlar.Clear();
                        satisraporlarolmayancariler.Clear();
                        this.Enabled = true;
                        return;
                    }

                    //progressBar1.Value++;
                    this.Text = "Ticari Pazarlama : Satış Raporu (Kontrol edilen satır: " + i.ToString() + ")";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata oluşan satır: " + i.ToString() + "\r\nHata ayrıntısı: " + ex.Message);
                    satisraporlar.Clear();
                    satisraporlarolmayancariler.Clear();
                    this.Enabled = true;
                    return;
                }
            }
            //progressBar1.Value = 0;
            //progressBar1.Visible = false;
            this.Enabled = true;
            this.Text = oncekitext;



            if (satisraporlarolmayancariler.Count > 0)
            {
                MessageBox.Show("Açık olmayan nokta isimleri var!", "Aktarım", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmINTERNETticaripazarlamasatisraporaktarim frm = new frmINTERNETticaripazarlamasatisraporaktarim(satisraporlarolmayancariler);
                frm.ShowDialog();
                satisraporlarolmayancariler.Clear();

                if (frm.aktarilmamissayisi == 0)
                {
                    //ExceldenAl(dosya);
                    thr = new Thread(new ParameterizedThreadStart(ExceldenAl));
                    thr.Start(dosya);
                }
                else
                {
                    satisraporlar.Clear();
                }

            }
            else
            {
                if (MessageBox.Show("Tüm nokta isimleri aktarım için hazır. Devam etmek istediğinize emin misiniz?", "Aktarım", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    Thread thr1 = new Thread(new ParameterizedThreadStart(AktarimYap));
                    thr1.Start(satisraporlar);
                }
            }
        }

        private void AktarimYap(object satisraporlar1)
        {
            string oncekitext = this.Text;
            this.Enabled = false;
            progressBar1.Visible = true;

            #region exceldeki bayilerin seçilen dönem verilerini silmek için hazırlama
            progressBar1.Value = 0;
            progressBar1.Maximum = ((ArrayList)satisraporlar1).Count;
            ArrayList silinecekbayikodlar = new ArrayList();
            string silinecekbayiler = string.Empty;
            for (int i = 0; i < ((ArrayList)satisraporlar1).Count; i++)
            {
                this.Text = "Ticari Pazarlama : Satış Raporu (Silinecek bayi satır kontrolü: " + i.ToString() + " / " + ((ArrayList)satisraporlar1).Count.ToString() + ")";

                bool var = false;
                for (int j = 0; j < silinecekbayikodlar.Count; j++)
                {
                    if (silinecekbayikodlar[j].ToString() == ((SatisRaporTP)((ArrayList)satisraporlar1)[i]).BAYIKOD)
                    {
                        var = true;
                        break;
                    }
                }

                if (!var)
                {
                    if (((SatisRaporTP)((ArrayList)satisraporlar1)[i]).BAYIKOD != "1001327")
                    {
                        silinecekbayikodlar.Add(((SatisRaporTP)((ArrayList)satisraporlar1)[i]).BAYIKOD);
                        silinecekbayiler += CariHesaplarTP.GetObject(CariHesaplarTP.GetGMREFByBAYIKOD(((SatisRaporTP)((ArrayList)satisraporlar1)[i]).BAYIKOD), true).MUSTERI + "\r\n";
                    }
                    else
                    {
                        silinecekbayikodlar.Add("1001327");
                        silinecekbayiler += "SULTANLAR PAZARLAMA A.Ş.";
                    }
                }

                if (progressBar1.Value < progressBar1.Maximum) progressBar1.Value++;
            }
            #endregion

            if (MessageBox.Show("Aşağıdaki bayilerin \"" + cmbYil.SelectedItem.ToString() + " - " + cmbAy.SelectedItem.ToString() +
                "\" dönemlerindeki satış verisi silinecektir.\r\n\r\n" + silinecekbayiler + "\r\n" +
                "Devam etmek istediğinize emin misiniz?" + "\r\n\r\nNot: Devam etmediğiniz takdirde excel raporu verisi aktarılmayacaktır.", "Önemli Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
            {

                #region exceldeki bayilerin seçilen dönem verilerini silme
                progressBar1.Maximum = silinecekbayikodlar.Count;
                progressBar1.Value = 0;
                for (int i = 0; i < silinecekbayikodlar.Count; i++)
                {
                    this.Text = "Ticari Pazarlama : Satış Raporu (Raporu silinen bayi sayısı: " + i.ToString() + " / " + silinecekbayikodlar.Count.ToString() + ")";

                    SatisRaporTP.DoDelete(silinecekbayikodlar[i].ToString(), Convert.ToInt16(cmbYil.SelectedItem), Convert.ToByte(cmbAy.SelectedItem));
                    //SatisRaporTP.SetToplamlar(CariHesaplarTP.GetGMREFByBAYIKOD(silinecekbayikodlar[i].ToString()), Convert.ToByte(cmbAy.SelectedItem), Convert.ToInt16(cmbYil.SelectedItem), 0, 0);

                    if (progressBar1.Value < progressBar1.Maximum) progressBar1.Value++;
                }
                #endregion

                progressBar1.Maximum = ((ArrayList)satisraporlar1).Count;
                progressBar1.Value = 0;
                for (int i = 0; i < ((ArrayList)satisraporlar1).Count; i++)
                {
                    this.Text = "Ticari Pazarlama : Satış Raporu (Aktarılan satır: " + i.ToString() + " / " + ((ArrayList)satisraporlar1).Count.ToString() + ")";
                    ((SatisRaporTP)((ArrayList)satisraporlar1)[i]).DoInsert();

                    CariHesaplarTP ch = CariHesaplarTP.GetObject(Convert.ToInt32(((SatisRaporTP)((ArrayList)satisraporlar1)[i]).BAYIKOD), ((SatisRaporTP)((ArrayList)satisraporlar1)[i]).NOKTAAD);
                    ch.IL = ((SatisRaporTP)((ArrayList)satisraporlar1)[i]).IL;
                    ch.ILKOD = Iller.GetKODByIL(ch.IL).ToString();
                    ch.DoUpdate();

                    if (progressBar1.Value < progressBar1.Maximum) progressBar1.Value++;
                }
                MessageBox.Show("Aktarım tamamlandı.", "Aktarım", MessageBoxButtons.OK, MessageBoxIcon.Information);
                progressBar1.Value = 0;
            }

            progressBar1.Visible = false;
            satisraporlar.Clear();
            this.Enabled = true;
            this.Text = oncekitext;
        }

        //delegate void HesaplaDelegate(int Kactan, int KacaKadar);

        private void sbHesapla_Click(object sender, EventArgs e)
        {
            if (hesaplamayapilabilir && cmbBayiler.SelectedIndex > -1 && cmbYil.SelectedIndex > 0 && cmbAy.SelectedIndex > 0)
            {
                if (MessageBox.Show("İşlem uzun sürebilir, bu esnada programı kapatmayınız.\r\n\r\n" + gridView1.RowCount.ToString() + " satır için işlemin TAHMİNİ bitiş zamanı: " + DateTime.Now.AddSeconds(gridView1.RowCount / 5).ToShortTimeString() + "\r\n\r\nDevam etmek istiyor musunuz?", "Hesaplama", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    DataTable dt = new DataTable();

                    if (cmbBayiler.SelectedIndex > -1 && cmbBayiler.SelectedItem.ToString() != "SULTANLAR PAZARLAMA A.Ş.")
                    {

                        byte ay = cmbAy.SelectedIndex > 0 ? Convert.ToByte(cmbAy.SelectedItem) : (byte)0;
                        short yil = cmbYil.SelectedIndex > 0 ? Convert.ToInt16(cmbYil.SelectedItem) : (short)0;

                        dt = GetSatisRapor(((CariHesaplarTP)cmbBayiler.SelectedItem).GMREF, ay, yil, true);

                        //HesaplaKaydet(dt, 0, 0, dt.Rows.Count, true, false, true);
                        //return;
                    }
                    else if (cmbBayiler.SelectedIndex > -1 && cmbBayiler.SelectedItem.ToString() == "SULTANLAR PAZARLAMA A.Ş.")
                    {
                        byte ay = cmbAy.SelectedIndex > 0 ? Convert.ToByte(cmbAy.SelectedItem) : (byte)0;
                        short yil = cmbYil.SelectedIndex > 0 ? Convert.ToInt16(cmbYil.SelectedItem) : (short)0;

                        dt = GetSatisRapor(-1, ay, yil, true);

                        //HesaplaKaydet(dt, 0, 0, dt.Rows.Count, true, true, true);
                        //return;
                    }

                    int kacakadar = dt.Rows.Count;

                    int BirinciBitis = kacakadar;
                    //int BirinciBitis = kacakadar / 4;
                    //int IkinciBitis = kacakadar - (BirinciBitis * 2);
                    //int UcuncuBitis = kacakadar - BirinciBitis;
                    //int DorduncuBitis = gridView1.RowCount;

                    progressBar1.Maximum = dt.Rows.Count;
                    progressBar1.Value = 0;
                    progressBar1.Visible = true;

                    HesaplaKaydetDelegate hesapla = new HesaplaKaydetDelegate(HesaplaKaydet);
                    //HesaplaDelegate hesapla1 = new HesaplaDelegate(Hesapla);
                    //HesaplaDelegate hesapla2 = new HesaplaDelegate(Hesapla);
                    //HesaplaDelegate hesapla3 = new HesaplaDelegate(Hesapla);
                    hesapla.BeginInvoke(dt, 0, 0, dt.Rows.Count, true, false, true, null, null);
                    //hesapla1.BeginInvoke(BirinciBitis, IkinciBitis, null, null);
                    //hesapla2.BeginInvoke(IkinciBitis, UcuncuBitis, null, null);
                    //hesapla3.BeginInvoke(UcuncuBitis, DorduncuBitis, null, null);
                }
            }
            else
            {
                MessageBox.Show("Hesaplama yapabilmeniz için öncelikle bayi, yıl, ay seçmelisiniz ve ardından 'Getir' tuşuna basmalısınız.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        delegate void KaydetDelegate();

        private void sbKaydet_Click(object sender, EventArgs e)
        {
            //Kaydet();
            KaydetDelegate kaydet = new KaydetDelegate(Kaydet);
            kaydet.BeginInvoke(null, null);
        }

        private void Kaydet()
        {
            if (gridView1.RowCount > 0 && Convert.ToInt32(gridView1.GetRowCellValue(0, "Degistirildi")) != 0) // 1. satır hesaplanmışsa hepsi hesaplanmıştır
            {
                if (MessageBox.Show("Hesaplamalar kaydedilecek, devam etmek istediğinize emin misiniz?", "Hesaplama kayıt", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    string oncekitext = this.Text;
                    this.Enabled = false;
                    progressBar1.Visible = true;
                    progressBar1.Maximum = gridView1.RowCount;
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        SatisRaporTP satisrapor = SatisRaporTP.GetObject(Convert.ToInt64(gridView1.GetRowCellValue(i, "REF")));
                        satisrapor.intAnlasmaID = Convert.ToInt32(gridView1.GetRowCellValue(i, "intAnlasmaID"));
                        satisrapor.intAktiviteID = Convert.ToInt32(gridView1.GetRowCellValue(i, "intAktiviteID"));
                        satisrapor.flIsk1 = Convert.ToDouble(gridView1.GetRowCellValue(i, "flIsk1"));
                        satisrapor.flIsk2 = Convert.ToDouble(gridView1.GetRowCellValue(i, "flIsk2"));
                        satisrapor.flIsk3 = Convert.ToDouble(gridView1.GetRowCellValue(i, "flIsk3"));
                        satisrapor.flIsk4 = Convert.ToDouble(gridView1.GetRowCellValue(i, "flIsk4"));
                        satisrapor.mnListeFiyat = Convert.ToDecimal(gridView1.GetRowCellValue(i, "mnListeFiyat"));
                        satisrapor.mnListeFiyatKarli = Convert.ToDecimal(gridView1.GetRowCellValue(i, "mnListeFiyatKarli"));
                        satisrapor.mnNetBirimFiyat = Convert.ToDecimal(gridView1.GetRowCellValue(i, "mnNetBirimFiyat"));
                        satisrapor.mnNetToplam = Convert.ToDecimal(gridView1.GetRowCellValue(i, "mnNetToplam"));
                        satisrapor.mnBirimFark = Convert.ToDecimal(gridView1.GetRowCellValue(i, "mnBirimFark"));
                        satisrapor.mnToplamFark = Convert.ToDecimal(gridView1.GetRowCellValue(i, "mnToplamFark"));
                        satisrapor.DoUpdate();

                        if (progressBar1.Value < progressBar1.Maximum) progressBar1.Value++;
                        this.Text = "Ticari Pazarlama : Satış Raporu (Kaydedilen satır: " + i.ToString() + " / " + gridView1.RowCount.ToString() + ")";
                    }
                    progressBar1.Value = 0;
                    progressBar1.Visible = false;
                    this.Enabled = true;
                    this.Text = oncekitext;

                    if (cmbBayiler.SelectedIndex > -1 && cmbBayiler.SelectedItem.ToString() != "SULTANLAR PAZARLAMA A.Ş.")
                    {
                        //SatisRaporTP.SetToplamlar(((CariHesaplarTP)cmbBayiler.SelectedItem).GMREF,
                        //    Convert.ToByte(cmbAy.SelectedItem.ToString()), Convert.ToInt16(cmbYil.SelectedItem.ToString()), 
                        //    Convert.ToDecimal(lblTAH.Text.Replace(" TL", "")), Convert.ToDecimal(lblYEG.Text.Replace(" TL", "")));
                    }
                    else if (cmbBayiler.SelectedIndex > -1 && cmbBayiler.SelectedItem.ToString() == "SULTANLAR PAZARLAMA A.Ş.")
                    {
                        //SatisRaporTP.SetToplamlar(-1,
                        //    Convert.ToByte(cmbAy.SelectedItem.ToString()), Convert.ToInt16(cmbYil.SelectedItem.ToString()),
                        //    Convert.ToDecimal(lblTAH.Text.Replace(" TL", "")), Convert.ToDecimal(lblYEG.Text.Replace(" TL", "")));
                    }

                    MessageBox.Show("Hesaplamalar başarıyla kaydedildi.", "Kaydedildi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Hesaplama yapılmadan kayıt yapılamaz.", "Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void sbDonemSil_Click(object sender, EventArgs e)
        {
            if (cmbBayiler.SelectedIndex > -1 && cmbYil.SelectedIndex > 0 && cmbAy.SelectedIndex > 0)
            {
                if (MessageBox.Show(cmbBayiler.SelectedItem.ToString() + " bayisinin \"" + cmbYil.SelectedItem.ToString() + " - " + 
                    cmbAy.SelectedItem.ToString() + "\" dönemindeki tüm satış verisini silmek istediğinize emin misiniz?", "Önemli Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    string oncekitext = this.Text;
                    if (cmbBayiler.SelectedItem.ToString() == "SULTANLAR PAZARLAMA A.Ş.")
                    {
                        SatisRaporTP.DoDelete("1001327", Convert.ToInt16(cmbYil.SelectedItem), Convert.ToByte(cmbAy.SelectedItem));
                        //SatisRaporTP.SetToplamlar(-1, Convert.ToByte(cmbAy.SelectedItem), Convert.ToInt16(cmbYil.SelectedItem), 0, 0);
                    }
                    else
                    {
                        SatisRaporTP.DoDelete(CariHesaplarTP.GetBAYIKODByGMREF(((CariHesaplarTP)cmbBayiler.SelectedItem).GMREF), Convert.ToInt16(cmbYil.SelectedItem), Convert.ToByte(cmbAy.SelectedItem));
                        //SatisRaporTP.SetToplamlar(((CariHesaplarTP)cmbBayiler.SelectedItem).GMREF, Convert.ToByte(cmbAy.SelectedItem), Convert.ToInt16(cmbYil.SelectedItem), 0, 0);
                    }

                    MessageBox.Show("Silme tamamlandı.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Text = oncekitext;
                    GetSatisRaporBos();
                }
            }
            else
            {
                MessageBox.Show("Eksik seçim var.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void sbExceleAktar_Click(object sender, EventArgs e)
        {
            gridView1.OptionsView.ShowFooter = false;
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel dosyaları (*.xlsx)|*.xlsx;|Bütün Dosyalar|*.*";
            if (sfd.ShowDialog() == DialogResult.OK)
                gridControl1.ExportToXlsx(sfd.FileName);
            gridView1.OptionsView.ShowFooter = true;
        }

        private void sbHesaplaKaydet_Click(object sender, EventArgs e)
        {
            if (/*cmbBayiler.SelectedIndex == -1 || */cmbYil.SelectedIndex < 1 || cmbAy.SelectedIndex < 1)
                return;

            if (MessageBox.Show("İşlem uzun sürebilir, bu esnada programı kapatmayınız.\r\n\r\n" + gridView1.RowCount.ToString() + " satır için işlemin TAHMİNİ bitiş zamanı: " + DateTime.Now.AddSeconds(gridView1.RowCount / 5).ToShortTimeString() + "\r\n\r\nDevam etmek istiyor musunuz?", "Hesaplama", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
            {
                DataTable dt = new DataTable();

                if (cmbBayiler.SelectedIndex > -1 && cmbBayiler.SelectedItem.ToString() != "SULTANLAR PAZARLAMA A.Ş.")
                {
                    byte ay = cmbAy.SelectedIndex > 0 ? Convert.ToByte(cmbAy.SelectedItem) : (byte)0;
                    short yil = cmbYil.SelectedIndex > 0 ? Convert.ToInt16(cmbYil.SelectedItem) : (short)0;

                    dt = GetSatisRapor(((CariHesaplarTP)cmbBayiler.SelectedItem).GMREF, ay, yil, false);
                }
                else if (cmbBayiler.SelectedIndex > -1 && cmbBayiler.SelectedItem.ToString() == "SULTANLAR PAZARLAMA A.Ş.")
                {
                    byte ay = cmbAy.SelectedIndex > 0 ? Convert.ToByte(cmbAy.SelectedItem) : (byte)0;
                    short yil = cmbYil.SelectedIndex > 0 ? Convert.ToInt16(cmbYil.SelectedItem) : (short)0;

                    dt = GetSatisRapor(-1, ay, yil, false);
                }
                else if (cmbBayiler.SelectedIndex == -1)
                {
                    byte ay = cmbAy.SelectedIndex > 0 ? Convert.ToByte(cmbAy.SelectedItem) : (byte)0;
                    short yil = cmbYil.SelectedIndex > 0 ? Convert.ToInt16(cmbYil.SelectedItem) : (short)0;

                    dt = GetSatisRapor(0, ay, yil, false);
                    hesaplamayapilabilir = true;
                }



                int kacakadar = dt.Rows.Count;

                int BirinciBitis = kacakadar / 4;
                int IkinciBitis = BirinciBitis * 2;
                int UcuncuBitis = BirinciBitis * 3;
                int DorduncuBitis = kacakadar;

                DataTable dt1 = dt.Clone();
                DataTable dt2 = dt.Clone();
                DataTable dt3 = dt.Clone();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt1.Rows.Add(dt.Rows[i].ItemArray);
                    dt2.Rows.Add(dt.Rows[i].ItemArray);
                    dt3.Rows.Add(dt.Rows[i].ItemArray);
                }



                progressBar1.Maximum = dt.Rows.Count; // hesapla kaydet *3
                progressBar1.Value = 0;
                progressBar1.Visible = true;

                //birincibitti = false; ikincibitti = false; ucuncubitti = false; dorduncubitti = false;
                //besincibitti = false; altincibitti = false; yedincibitti = false; sekizincibitti = false;

                HesaplaKaydetDelegate hesapla = new HesaplaKaydetDelegate(HesaplaKaydet);
                HesaplaKaydetDelegate hesapla1 = new HesaplaKaydetDelegate(HesaplaKaydet);
                HesaplaKaydetDelegate hesapla2 = new HesaplaKaydetDelegate(HesaplaKaydet);
                HesaplaKaydetDelegate hesapla3 = new HesaplaKaydetDelegate(HesaplaKaydet);

                //hesapla.BeginInvoke(dt, 0, 0, dt.Rows.Count, true, true, true, null, null);

                hesapla.BeginInvoke(dt, 1, 0, BirinciBitis, true, true, true, null, null);
                hesapla1.BeginInvoke(dt1, 2, BirinciBitis, IkinciBitis, true, true, true, null, null);
                hesapla2.BeginInvoke(dt2, 3, IkinciBitis, UcuncuBitis, true, true, true, null, null);
                hesapla3.BeginInvoke(dt3, 4, UcuncuBitis, DorduncuBitis, true, true, true, null, null);
            }
        }

        bool birincibitti, ikincibitti, ucuncubitti, dorduncubitti;
        string birincibilgi, ikincibilgi, ucuncubilgi, dorduncubilgi;
        delegate void HesaplaKaydetDelegate(DataTable dt, int Kacinci, int Kactan, int KacaKadar, bool Hesapla, bool Kaydet, bool textbilgi);

        private void HesaplaKaydet(DataTable dt, int Kacinci, int Kactan, int KacaKadar, bool Hesapla, bool Kaydet, bool textbilgi)
        {
            string oncekitext = this.Text;



            string olmayanurunler = string.Empty;
            string fiyatiolmayanurunler = string.Empty;
            ArrayList hesaplanamayansatirlar = new ArrayList();
            if (Hesapla)
            {
                #region Hesaplama
                decimal ToplamTAH = 0;
                decimal ToplamYEG = 0;

                this.Enabled = false;
                //progressBar1.Maximum = dt.Rows.Count;
                //progressBar1.Visible = true;
                for (int i = Kactan; i < KacaKadar; i++)
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
                        double aktivitevar = 0;
                        bool TAH = Convert.ToBoolean(objTAH);
                        bool karTAH = Urunler.GetProductReyKod(Convert.ToInt32(dt.Rows[i]["URUNKOD"])) == "T2" ? false : true;

                        int UrunID = Convert.ToInt32(dt.Rows[i]["URUNKOD"].ToString());

                        #region SULTANLAR
                        if (dt.Rows[i]["BAYIKOD"].ToString() == "1001327") // sultanlar ise
                        {
                            kar = karTAH ? 11 : 15;

                            long aktivitedetayid = AktivitelerDetay.GetTarihAraligiAktivitelerDetayIDSUL( // sul da smrefin herhangi bir smref ine aktivite girilmişse ona bakıyoruz
                                Convert.ToInt32(dt.Rows[i]["NOKTAAD"]), // satış raporunu excelden aktarırken sultanlarda smref i yazıyoruz
                                dt.Rows[i]["URUNKOD"].ToString(),
                                noktaevraktarih);
                            int anlasmaid = Anlasmalar.GetSonAnlasmaID(
                                CariHesaplar.GetGMREFBySMREF(Convert.ToInt32(dt.Rows[i]["NOKTAAD"])),
                                noktaevraktarih, "2");

                            if (aktivitedetayid > 0)
                            {
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
                                        FiyatlarTP.GetIskFiyat(Urunler.GetProductUrunID(dt.Rows[i]["URUNKOD"].ToString()), 3, 7,
                                        noktasatyil,
                                        noktasatay,
                                        noktasatgun));

                                dt.Rows[i]["intAnlasmaID"] = anlasma.pkID;
                                dt.Rows[i]["intAktiviteID"] = 0;

                                if (isk1 == 0) anlasmaid = 0; // anlaşma sadece tah veya sadece yeg ise diğerini kapsamasın, alttaki genel anlaşmasıza düşsün
                            }

                            if (aktivitedetayid == 0 && anlasmaid == 0) // genel anlaşmasız aktivite
                            {
                                double Isk1 = Convert.ToDouble(
                                    FiyatlarTP.GetIskFiyat(Urunler.GetProductUrunID(dt.Rows[i]["URUNKOD"].ToString()), 1, 7,
                                    noktasatyil,
                                    noktasatay,
                                    noktasatgun));
                                double Isk2 = Convert.ToDouble(
                                    FiyatlarTP.GetIskFiyat(Urunler.GetProductUrunID(dt.Rows[i]["URUNKOD"].ToString()), 2, 7,
                                    noktasatyil,
                                    noktasatay,
                                    noktasatgun));
                                double Isk3 = Convert.ToDouble(
                                    FiyatlarTP.GetIskFiyat(Urunler.GetProductUrunID(dt.Rows[i]["URUNKOD"].ToString()), 3, 7,
                                    noktasatyil,
                                    noktasatay, 
                                    noktasatgun));

                                isk1 = Isk1;
                                isk2 = Isk2;
                                isk3 = Isk3;
                                isk4 = 0;

                                dt.Rows[i]["intAnlasmaID"] = 0;
                                dt.Rows[i]["intAktiviteID"] = 0;
                            }
                        }
                        #endregion
                        else
                        {
                            kar = karTAH ? CariHesaplarTPEk2.GetObject(Convert.ToInt32(dt.Rows[i]["GMREF"]), noktasatyil, noktasatay).TAH_KAR : CariHesaplarTPEk2.GetObject(Convert.ToInt32(dt.Rows[i]["GMREF"]), noktasatyil, noktasatay).YEG_KAR;

                            int SMREF = dt.Rows[i]["NOKTAKOD"].ToString() != string.Empty ? 
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

                                double kdv = Urunler.GetProductKDV(aktlerdet.intUrunID);
                                aktivitevar = Convert.ToDouble(aktlerdet.mnDusulmusBirimFiyatKDVli);
                                aktivitevar = aktivitevar / ((100 + kdv) / 100);

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

                                    double kdv = Urunler.GetProductKDV(aktlerdet.intUrunID);
                                    aktivitevar = Convert.ToDouble(aktlerdet.mnDusulmusBirimFiyatKDVli);
                                    aktivitevar = aktivitevar / ((100 + kdv) / 100);

                                    dt.Rows[i]["intAnlasmaID"] = Aktiviteler.GetObject(aktlerdet.intAktiviteID).intAnlasmaID;
                                    dt.Rows[i]["intAktiviteID"] = aktlerdet.intAktiviteID;
                                }
                                else // standart uygulama
                                {
                                    CariHesaplarTPEk2 chtpek = CariHesaplarTPEk2.GetObject(GMREF, noktasatyil, noktasatay);
                                    isk1 = TAH ? chtpek.TAH_ISK : chtpek.YEG_ISK;
                                    isk2 = 0; // öztrakya veya meltem ise 2. iskonto var 7 birinci 10 ikinci iskonto genelde fiyat listesinde (7) ::: dt.Rows[i]["BAYIKOD"].ToString() == "1005405" || dt.Rows[i]["BAYIKOD"].ToString() == "1000951" ? Convert.ToDouble(FiyatlarTP.GetIskFiyat(Urunler.GetProductUrunID(dt.Rows[i]["URUNKOD"].ToString()), 2, 7, Convert.ToInt32(dt.Rows[i]["NOKTASATYIL"]), noktasatay)) : 
                                    isk3 = Convert.ToDouble(
                                        FiyatlarTP.GetIskFiyat(UrunID, 3, 25,
                                        noktasatyil,
                                        noktasatay,
                                        noktasatgun));

                                    dt.Rows[i]["intAnlasmaID"] = 0;
                                    dt.Rows[i]["intAktiviteID"] = 0;
                                }
                            }
                        }

                        dt.Rows[i]["flIsk1"] = isk1;
                        dt.Rows[i]["flIsk2"] = isk2;
                        dt.Rows[i]["flIsk3"] = isk3;
                        dt.Rows[i]["flIsk4"] = isk4;



                        // bayinin alımı
                        double listefiyat = Convert.ToDouble(FiyatlarTP.GetNetFiyat(
                            UrunID,
                            dt.Rows[i]["BAYIKOD"].ToString() == "1001327" /*|| dt.Rows[i]["BAYIKOD"].ToString() == "1005405"*/ ? (short)7 : (short)22, //sultanlar veya öztrakya ise 1 bayi ise 22 (bu satır 1000951 iken de o if bloğu açıklamaydı)
                            noktasatyil,
                            noktasatay,
                            noktasatgun));
                        if (listefiyat == 0.0)
                        {
                            listefiyat = Convert.ToDouble(Urunler.GetProductNetFiyatFULL(
                                UrunID,
                                dt.Rows[i]["BAYIKOD"].ToString() == "1001327" /*|| dt.Rows[i]["BAYIKOD"].ToString() == "1005405"*/ ? (short)7 : (short)22 //sultanlar veya öztrakya ise 1 bayi ise 22 (bu satır 1000951 iken de o if bloğu açıklamaydı)
                                ));
                        }



                        // brüt fiyat, aktivitenin hesaplanacagi fiyat
                        double listefiyat1 = 0.0 /*dt.Rows[i]["BAYISATIS"] != DBNull.Value ? Convert.ToDouble(dt.Rows[i]["BAYISATIS"]) : 0.0*/; // sultanlar öztrakya falan hariç diyordum kaldırdım, aslında buraya hiç gerek olmayabilir altta dönem fiyatını da alabiliriz ama şu anda comment... liste fiyatını her zaman alalım çünkü bundan iskonto düşerek hesaplanıyor
                        if (listefiyat1 == 0.0) // BAYISATIS dönem fiyatını getiriyor, eğer öztrakya ise dönem fiyatını getirmedi o yüzden bide burada dönem fiyatına bakıyoruz
                        {
                            listefiyat1 = Convert.ToDouble(FiyatlarTP.GetFiyat(
                                UrunID,
                                dt.Rows[i]["BAYIKOD"].ToString() == "1001327" ? (short)7 : (short)22, //sultanlar veya öztrakya ise 1 bayi ise 22
                                noktasatyil,
                                noktasatay, 
                                noktasatgun));
                        }
                        /*else */if (listefiyat1 == 0.0) // dönem fiyatı yoksa şimdiki fiyatı al
                        {
                            listefiyat1 = Convert.ToDouble(Urunler.GetProductDiscountsAndPriceFULL(
                                UrunID,
                                dt.Rows[i]["BAYIKOD"].ToString() == "1001327" ? (short)7 : (short)22 //sultanlar veya öztrakya ise 1 bayi ise 22
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

                        if (aktivitevar > 0)
                            olmasigereken = aktivitevar;

                        dt.Rows[i]["mnListeFiyat"] = listefiyat;
                        dt.Rows[i]["mnListeFiyatT"] = listefiyat * bayiadet;
                        dt.Rows[i]["mnListeFiyatKarli"] = karlifiyat;
                        dt.Rows[i]["mnListeFiyatKarliT"] = karlifiyat * bayiadet;

                        dt.Rows[i]["mnNetBirimFiyat"] = olmasigereken;
                        dt.Rows[i]["mnNetToplam"] = olmasigereken * bayiadet;

                        if (UrunID > 0 && listefiyat != 0.0 && listefiyat1 != 0.0)
                        {
                            //dt.Rows[i]["mnBirimFark"] = olmasigereken - bayifiyat;
                            //dt.Rows[i]["mnToplamFark"] = (olmasigereken - bayifiyat) * bayiadet;
                            if (bayifiyat >= olmasigereken)
                            {
                                dt.Rows[i]["mnBirimFark"] = bayifiyat - karlifiyat; //karlifiyat - bayifiyat
                                dt.Rows[i]["mnToplamFark"] = (bayifiyat - karlifiyat) * bayiadet;
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

                        ResetExceptionState(gridControl1); gridControl1.Invalidate();
                    }

                    try { if (progressBar1.Value < progressBar1.Maximum) progressBar1.Value++; } catch (Exception) { }
                    if (textbilgi)
                    {
                        if (Kacinci != 0)
                        {
                            if (Kacinci == 1)
                            {
                                birincibilgi = "(Hesaplanan satır: " + i.ToString() + " / " + KacaKadar.ToString() + ") ";
                            }
                            else if (Kacinci == 2)
                            {
                                ikincibilgi = "(Hesaplanan satır: " + i.ToString() + " / " + KacaKadar.ToString() + ") ";
                            }
                            else if (Kacinci == 3)
                            {
                                ucuncubilgi = "(Hesaplanan satır: " + i.ToString() + " / " + KacaKadar.ToString() + ") ";
                            }
                            else if (Kacinci == 4)
                            {
                                dorduncubilgi = "(Hesaplanan satır: " + i.ToString() + " / " + KacaKadar.ToString() + ") ";
                            }
                            this.Text = "Ticari Pazarlama : Satış Raporu " + birincibilgi + ikincibilgi + ucuncubilgi + dorduncubilgi;
                        }
                        else
                        {
                            this.Text = "Ticari Pazarlama : Satış Raporu (Hesaplanan satır: " + i.ToString() + " / " + dt.Rows.Count.ToString() + ")";
                        }
                    }
                }
                //progressBar1.Value = 0;

                lblTAH.Text = ToplamTAH.ToString("C2");
                lblYEG.Text = ToplamYEG.ToString("C2");
                lblToplam.Text = (ToplamTAH + ToplamYEG).ToString("C2");
                #endregion
            }



            /*for (int i = 0; i < hesaplanamayansatirlar.Count; i++)
                HesaplaKaydet(dt, 0, Convert.ToInt32(hesaplanamayansatirlar[i]), Convert.ToInt32(hesaplanamayansatirlar[i]), true, false, false);*/



            if (Kaydet)
            {
                #region Kaydetme
                //progressBar1.Maximum = dt.Rows.Count;
                for (int i = Kactan; i < KacaKadar; i++)
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

                    try { if (progressBar1.Value < progressBar1.Maximum) progressBar1.Value++; } catch (Exception) { }
                    if (textbilgi)
                    {
                        if (Kacinci != 0)
                        {
                            if (Kacinci == 1)
                            {
                                birincibilgi = "(Kaydedilen satır: " + i.ToString() + " / " + KacaKadar.ToString() + ") ";
                            }
                            else if (Kacinci == 2)
                            {
                                ikincibilgi = "(Kaydedilen satır: " + i.ToString() + " / " + KacaKadar.ToString() + ") ";
                            }
                            else if (Kacinci == 3)
                            {
                                ucuncubilgi = "(Kaydedilen satır: " + i.ToString() + " / " + KacaKadar.ToString() + ") ";
                            }
                            else if (Kacinci == 4)
                            {
                                dorduncubilgi = "(Kaydedilen satır: " + i.ToString() + " / " + KacaKadar.ToString() + ") ";
                            }
                            this.Text = "Ticari Pazarlama : Satış Raporu " + birincibilgi + ikincibilgi + ucuncubilgi + dorduncubilgi;
                        }
                        else
                        {
                            this.Text = "Ticari Pazarlama : Satış Raporu (Kaydedilen satır: " + i.ToString() + " / " + dt.Rows.Count.ToString() + ")";
                        }
                    }
                }
                #endregion
            }



            if (Kacinci != 0)
            {
                if (Kacinci == 1) birincibitti = true; else if (Kacinci == 2) ikincibitti = true; else if (Kacinci == 3) ucuncubitti = true; else if (Kacinci == 4) dorduncubitti = true;
            }

            if ((birincibitti && ikincibitti && ucuncubitti && dorduncubitti) || Kacinci == 0)
            {
                this.Enabled = true;

                if (Hesapla && olmayanurunler != string.Empty)
                    MessageBox.Show("Aşağıdaki ürünler sistemde bulunamadı:\r\n\r\n" + olmayanurunler, "Olmayan Ürünler", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //if (Hesapla && fiyatiolmayanurunler != string.Empty)
                //    MessageBox.Show("Aşağıdaki ürünlerin sistemde fiyatları bulunamadı:\r\n\r\n" + fiyatiolmayanurunler, "Fiyatı Olmayan Ürünler", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (Kaydet)
                    MessageBox.Show("Hesaplamalar başarıyla kaydedildi.", "Kaydedildi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //else
                //    MessageBox.Show("Hesaplama bitti.", "Bitti", MessageBoxButtons.OK, MessageBoxIcon.Information); gridControl1.DataSource = dt;
                if (Kaydet)
                    this.Close(); //gridControl1.DataSource = dt;

                progressBar1.Visible = false;
                this.Text = oncekitext;
            }
        }

        private void sbNoktaAdDegistir_Click(object sender, EventArgs e)
        {
            frmINTERNETticaripazarlamasatisrapornoktaaddegistirme frm = new frmINTERNETticaripazarlamasatisrapornoktaaddegistirme();
            frm.ShowDialog();
        }

        [System.Security.Permissions.ReflectionPermission(System.Security.Permissions.SecurityAction.Demand, MemberAccess = true)]
        void ResetExceptionState(Control control)
        {
            typeof(Control).InvokeMember("SetState", System.Reflection.BindingFlags.NonPublic |
             System.Reflection.BindingFlags.InvokeMethod | System.Reflection.BindingFlags.Instance, null,
             control, new object[] { 0x400000, false });
        }

        private void NumaraVerdir()
        {
            SqlConnection conn = new SqlConnection("Server=SERVERDB01; Database=KurumsalWeb; User Id=sultanlar; Password=pazarlama; Trusted_Connection=False;");
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM [Web-Musteri-TP]", conn);
            DataTable dt = new DataTable();
            conn.Open();
            da.Fill(dt);
            progressBar1.Visible = true;
            progressBar1.Maximum = dt.Rows.Count;
            progressBar1.Value = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                SqlCommand cmd = new SqlCommand("UPDATE [Web-Musteri-TP] SET SMREF = @SMREF WHERE GMREF = @GMREF AND SUBE = @SUBE", conn);
                cmd.Parameters.Add("@SMREF", SqlDbType.Int).Value = 1000000 + i;
                cmd.Parameters.Add("@GMREF", SqlDbType.Int).Value = Convert.ToInt32(dt.Rows[i]["GMREF"]);
                cmd.Parameters.Add("@SUBE", SqlDbType.VarChar, 201).Value = dt.Rows[i]["SUBE"].ToString();
                cmd.ExecuteNonQuery();
                if (progressBar1.Value < progressBar1.Maximum) progressBar1.Value++;
            }

            conn.Close();
        }
    }
}

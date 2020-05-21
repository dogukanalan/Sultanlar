using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sultanlar.DatabaseObject;
using Sultanlar.DatabaseObject.Internet;
using System.Collections;

namespace Sultanlar.UI
{
    public partial class frmINTERNETticaripazarlamamusteriler : Form
    {
        public frmINTERNETticaripazarlamamusteriler()
        {
            InitializeComponent();
        }

        private void frmINTERNETticaripazarlamamusteriler_Load(object sender, EventArgs e)
        {
            GetBayiler();
            GetIller();
            GetMusteriTurler();
            GetEsBayiler();
            cmbYil.SelectedIndex = DateTime.Now.Year - 2014;
            cmbAy.SelectedIndex = DateTime.Now.Month - 1;
        }

        private void GetEsBayiler()
        {
            CariHesaplarTP.GetObjects(cmbEsBayi.Items, 0);
        }

        private void GetMusteriTurler()
        {
            CariHesaplar.GetMusteriTurler(cmbTur.Items);
        }

        private void GetIller()
        {
            Iller.GetObject(cmbIl.Items, true);
        }

        private void GetIlceler(string IlKod)
        {
            Ilceler.GetObject(cmbIlce.Items, IlKod, true);
        }

        private void GetBayiler()
        {
            CariHesaplarTP.GetObjects(lbBayiler.Items, 0);
        }

        private int ExceldenAl(string dosya, bool bayi)
        {
            int donendeger = 0;

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

                range = ws.get_Range("A1", "L6666");

                values = (object[,])range.Value2;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
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

            ArrayList chtps = new ArrayList();
            for (int i = 1; i <= values.GetLength(0); i++)
            {
                if (values[i, 1] == null) // 1.kolon boş ise bu satırdan sonrasına bakmasın
                    break;

                try
                {
                    int SMREF = CariHesaplarTP.GetLastSMREF() + 1 + (i - 1); // for dan sonra toplu halde ekleneceği için smref ler aynı olmasın
                    int GMREF = bayi ? SMREF : ((CariHesaplarTP)lbBayiler.SelectedItem).GMREF; // bayi eklenecekse bayide gmref smref aynı
                    CariHesaplarTP Bayi = CariHesaplarTP.GetObject(GMREF, true);
                    string ILKOD = values[i, 1].ToString();
                    string IL = Iller.GetObjectByID(Convert.ToByte(values[i, 1].ToString())); // ilkod ile id aynı gidiyor 81 il
                    string ILCEKOD = values[i, 2].ToString();
                    string ilcekoduzun = (ILKOD.Length == 1 ? "0" + ILKOD : ILKOD) + ILCEKOD;
                    string ILCE = Ilceler.GetObjectByIlceKod(ilcekoduzun);

                    CariHesaplarTP chtp = new CariHesaplarTP(0, "", "", "", "", ILKOD, IL, ILCEKOD, ILCE,
                        0, "", values[i, 3].ToString().ToUpper(), "", Bayi.SLSREF, "", "", "", GMREF, "", values[i, 4].ToString().ToUpper(), SMREF, "", values[i, 4].ToString().ToUpper(),
                        values[i, 5].ToString().ToUpper(), "", values[i, 6].ToString().ToUpper(), values[i, 7].ToString().ToUpper(),
                        values[i, 8].ToString(), values[i, 9].ToString(), values[i, 10].ToString(), values[i, 11].ToString(), "", values[i, 12].ToString(), 0);
                    chtps.Add(chtp);

                    donendeger++;
                }
                catch (Exception ex)
                {
                    chtps.Clear();
                    MessageBox.Show(ex.Message);
                }
            }



            for (int i = 0; i < chtps.Count; i++)
                ((CariHesaplarTP)chtps[i]).DoInsert();

            return donendeger;
        }

        private void btnArama_Click(object sender, EventArgs e)
        {
            CariHesaplar.GetObjectsByMusteri(lbArama.Items, txtArama.Text.Trim(), true, true);
        }

        private void txtArama_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnArama.PerformClick();
        }

        private void btnAramaEkle_Click(object sender, EventArgs e)
        {
            if (lbArama.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen arama sonucu seçiniz.", "Müşteri seçilmedi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            CariHesaplar ch = (CariHesaplar)lbArama.SelectedItem;
            CariHesaplarTP chtp = new CariHesaplarTP(ch.ACTIVE, ch.BOLGE, ch.GRP, ch.EKP, ch.YTKKOD, ch.ILKOD, ch.IL, ch.ILCEKOD, ch.ILCE,
                ch.TIP, ch.MTKOD, ch.MTACIKLAMA, ch.UNVAN, ch.SLSREF, ch.SATKOD, ch.SATKOD1, ch.SATTEM, ch.GMREF, ch.MUSKOD,
                ch.MUSTERI, ch.SMREF, ch.SUBKOD, ch.SUBE, ch.ADRES, ch.SEHIR, ch.SEMT, ch.VRGDAIRE, ch.VRGNO, ch.TEL1, ch.FAX1,
                ch.EMAIL1, ch.ILGILI, ch.CEP1, ch.NETTOP);
            chtp.DoInsert();

            GetBayiler();

            lbArama.Items.Clear();
            txtArama.Text = string.Empty;
            txtArama.Focus();
        }

        private void lbArama_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            btnAramaEkle.PerformClick();
        }

        private void btnAltCariDosya_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Excel dosyaları (*.xls, *.xlsx)|*.xls;*.xlsx;|Bütün Dosyalar|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
                txtDosyaExcel.Text = ofd.FileName;
        }

        private void btnAltCariExcel_Click(object sender, EventArgs e)
        {
            if (lbBayiler.SelectedIndex == -1 && rbAltCari.Checked)
            {
                MessageBox.Show("Lütfen bir bayi seçiniz.", "Bayi seçilmedi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (txtDosyaExcel.Text == string.Empty)
                {
                    MessageBox.Show("Lütfen dosya seçimi yapınız.", "Dosya seçilmedi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    int kacsatir = ExceldenAl(txtDosyaExcel.Text, rbBayi.Checked);
                    MessageBox.Show(kacsatir.ToString() + " satır aktarılmıştır.", "İşlem başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GetBayiler();
                }
            }
        }

        private void btnAltCariEkle_Click(object sender, EventArgs e)
        {
            if (lbBayiler.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen bir bayi seçiniz.", "Bayi seçilmedi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (cmbIl.SelectedIndex == -1 || cmbIlce.SelectedIndex == -1 || txtMusteri.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Alt cari giriş bilgilerinde eksik var.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                int SMREF = CariHesaplarTP.GetLastSMREF() + 1;
                int GMREF = rbBayi.Checked ? SMREF : ((CariHesaplarTP)lbBayiler.SelectedItem).GMREF; // bayi eklenecekse bayide gmref smref aynı
                CariHesaplarTP bayi = CariHesaplarTP.GetObject(GMREF, true);
                string ILKOD = ((Iller)cmbIl.SelectedItem).strIlKod;
                string IL = ((Iller)cmbIl.SelectedItem).strIl;
                string ILCEKOD = ((Ilceler)cmbIlce.SelectedItem).strIlceKod.Substring(2); // son 2 hane
                string ILCE = ((Ilceler)cmbIlce.SelectedItem).strIlce;

                CariHesaplarTP chtp = new CariHesaplarTP(0, "", "", "", "", ILKOD, IL, ILCEKOD, ILCE,
                    0, "", txtMtAciklama.Text.Trim().ToUpper(), "", bayi.SLSREF, "", "", "", GMREF, "", txtMusteri.Text.ToUpper(), SMREF, "", txtMusteri.Text.ToUpper(),
                    txtAdres.Text.Trim().ToUpper(), "", txtSemt.Text.Trim().ToUpper(), txtVergiDairesi.Text.Trim().ToUpper(),
                    txtVergiNo.Text.Trim(), txtTelefon.Text.Trim(), txtFax.Text.Trim(), txtEmail.Text.Trim(), "", txtCep.Text.Trim(), 0);
                chtp.DoInsert();

                MessageBox.Show("İşlem başarıyla tamamlanmıştır.", "İşlem başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GetAltCariler();
            }
        }

        private void cmbIl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbIl.SelectedIndex > -1)
                GetIlceler(((Iller)cmbIl.SelectedItem).strIlKod);
        }

        private void lbBayiler_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetAltCariler();
        }

        private void GetAltCariler()
        {
            if (lbBayiler.SelectedIndex > -1)
            {
                rbSultanlar.Checked = false;
                CariHesaplarTP.GetObjects(lbAltCariler.Items, ((CariHesaplarTP)lbBayiler.SelectedItem).GMREF);
                CariHesaplarTPEk2 cariek = CariHesaplarTPEk2.GetObject(((CariHesaplarTP)lbBayiler.SelectedItem).GMREF, Convert.ToInt32(cmbYil.SelectedItem), Convert.ToInt32(cmbAy.SelectedItem));
                txtTAHKar.Text = cariek.TAH_KAR.ToString("N1");
                txtYEGKar.Text = cariek.YEG_KAR.ToString("N1");
                txtTAHIsk.Text = cariek.TAH_ISK.ToString("N1");
                txtYEGIsk.Text = cariek.YEG_ISK.ToString("N1");
                lblBayiKod.Text = CariHesaplarTP.GetBAYIKODByGMREF(((CariHesaplarTP)lbBayiler.SelectedItem).GMREF);
            }
            else
            {
                txtTAHKar.Text = 0.ToString("N1");
                txtYEGKar.Text = 0.ToString("N1");
                txtTAHIsk.Text = 0.ToString("N1");
                txtYEGIsk.Text = 0.ToString("N1");
                lblBayiKod.Text = string.Empty;
            }
        }

        private void rbSultanlar_CheckedChanged(object sender, EventArgs e)
        {
            if (rbSultanlar.Checked)
            {
                lbBayiler.SelectedIndex = -1;
                CariHesaplar.GetObjectsLikeTP(lbAltCariler.Items);

                txtTAHKar.Enabled = false;
                txtYEGKar.Enabled = false;
                txtTAHIsk.Enabled = false;
                txtYEGIsk.Enabled = false;
                btnKarIskKaydet.Enabled = false;
                lblBayiKod.Text = "1001327";
            }
            else
            {
                txtTAHKar.Enabled = true;
                txtYEGKar.Enabled = true;
                txtTAHIsk.Enabled = true;
                txtYEGIsk.Enabled = true;
                btnKarIskKaydet.Enabled = true;
            }
        }

        private void btnExcelYardim_Click(object sender, EventArgs e)
        {
            frmINTERNETticaripazarlamamusterileryardim frm = new frmINTERNETticaripazarlamamusterileryardim();
            frm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (lbBayiler.SelectedIndex > -1)
            {
                frmINTERNETticaripazarlamaanlasmalar frm = new frmINTERNETticaripazarlamaanlasmalar(((CariHesaplarTP)lbBayiler.SelectedItem).GMREF);
                frm.MdiParent = this.MdiParent;
                frm.Show();

                frmAna frm1 = (frmAna)this.ParentForm;
                ToolStripButton lll = new ToolStripButton("TP:Anlaşmalar (" + ((CariHesaplarTP)lbBayiler.SelectedItem).MUSTERI.Substring(0, 5) + "...)");
                lll.Name = "frmINTERNETticaripazarlamaanlasmalar";
                lll.MouseUp += new MouseEventHandler(frm1.lll_MouseUp);
                frm1.statusStrip1.Items.Add(lll);
            }
            else if (rbSultanlar.Checked)
            {
                frmINTERNETticaripazarlamaanlasmalar frm = new frmINTERNETticaripazarlamaanlasmalar(true);
                frm.MdiParent = this.MdiParent;
                frm.Show();

                frmAna frm1 = (frmAna)this.ParentForm;
                ToolStripButton lll = new ToolStripButton("TP:Anlaşmalar (SULTA...)");
                lll.Name = "frmINTERNETticaripazarlamaanlasmalar";
                lll.MouseUp += new MouseEventHandler(frm1.lll_MouseUp);
                frm1.statusStrip1.Items.Add(lll);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (lbAltCariler.SelectedIndex > -1)
            {
                frmINTERNETticaripazarlamaaktiviteler frm = new frmINTERNETticaripazarlamaaktiviteler(((CariHesaplarTP)lbAltCariler.SelectedItem).SMREF);
                frm.MdiParent = this.MdiParent;
                frm.Show();

                frmAna frm1 = (frmAna)this.ParentForm;
                ToolStripButton lll = new ToolStripButton("TP:Aktiviteler (" + ((CariHesaplarTP)lbAltCariler.SelectedItem).SUBE.Substring(0, 5) + "...)");
                lll.Name = "frmINTERNETticaripazarlamaaktiviteler";
                lll.MouseUp += new MouseEventHandler(frm1.lll_MouseUp);
                frm1.statusStrip1.Items.Add(lll);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (lbAltCariler.SelectedIndex > -1)
            {
                frmINTERNETticaripazarlamahizmetbedelleri frm = new frmINTERNETticaripazarlamahizmetbedelleri(((CariHesaplarTP)lbAltCariler.SelectedItem).SMREF);
                frm.MdiParent = this.MdiParent;
                frm.Show();

                frmAna frm1 = (frmAna)this.ParentForm;
                ToolStripButton lll = new ToolStripButton("TP:Hizmet Bedelleri (" + ((CariHesaplarTP)lbAltCariler.SelectedItem).SUBE.Substring(0, 5) + "...)");
                lll.Name = "frmINTERNETticaripazarlamahizmetbedelleri";
                lll.MouseUp += new MouseEventHandler(frm1.lll_MouseUp);
                frm1.statusStrip1.Items.Add(lll);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (lbAltCariler.SelectedIndex > -1)
            {
                int AnlasmaID = Anlasmalar.GetSonAnlasmaID(((CariHesaplarTP)lbAltCariler.SelectedItem).SMREF, DateTime.Now.AddYears(10), "1");
                if (AnlasmaID != 0)
                {
                    frmINTERNETticaripazarlamaanlasmaincele frm = new frmINTERNETticaripazarlamaanlasmaincele(AnlasmaID);
                    frm.MdiParent = this.MdiParent;
                    frm.Show();

                    frmAna frm1 = (frmAna)this.ParentForm;
                    string gorunenisim = rbSultanlar.Checked ? CariHesaplar.GetMUSTERIbyGMREF(frm.anlasma.SMREF).Substring(0, 5) : CariHesaplarTP.GetObject(frm.anlasma.SMREF, false).SUBE.Substring(0, 5);
                    ToolStripButton lll = new ToolStripButton("TP:Anlaşma (" + gorunenisim + "...)");
                    lll.Name = "frmINTERNETticaripazarlamaanlasmaincele";
                    lll.MouseUp += new MouseEventHandler(frm1.lll_MouseUp);
                    frm1.statusStrip1.Items.Add(lll);
                }
                else
                {
                    MessageBox.Show("Anlaşma bulunamadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void lbBayiler_DoubleClick(object sender, EventArgs e)
        {
            button1.PerformClick();
        }

        private void lbAltCariler_DoubleClick(object sender, EventArgs e)
        {
            button2.PerformClick();
        }

        private void btnKarIskKaydet_Click(object sender, EventArgs e)
        {
            if (lbBayiler.SelectedIndex > -1)
            {
                CariHesaplarTPEk2 cariek = CariHesaplarTPEk2.GetObject(((CariHesaplarTP)lbBayiler.SelectedItem).GMREF, Convert.ToInt32(cmbYil.SelectedItem), Convert.ToInt32(cmbAy.SelectedItem));
                cariek.TAH_KAR = Convert.ToDouble(txtTAHKar.Text);
                cariek.YEG_KAR = Convert.ToDouble(txtYEGKar.Text);
                cariek.TAH_ISK = Convert.ToDouble(txtTAHIsk.Text);
                cariek.YEG_ISK = Convert.ToDouble(txtYEGIsk.Text);
                cariek.DoUpdate();
                MessageBox.Show("Değişiklik kaydedildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtTAHKar_TextChanged(object sender, EventArgs e)
        {
            try { Convert.ToDouble(((TextBox)sender).Text); }
            catch (Exception) { ((TextBox)sender).Text = "0,0"; }
        }

        private void btnAltCariDuzenleGuncelle_Click(object sender, EventArgs e)
        {
            if (lbAltCariler.SelectedIndex > -1)
            {
                //if (SatisRaporTP.VarMi(CariHesaplarTP.GetBAYIKODByGMREF(((CariHesaplarTP)lbBayiler.SelectedItem).GMREF), ((CariHesaplarTP)lbAltCariler.SelectedItem).SUBE))
                //{
                //    MessageBox.Show("Alt carinin satış raporunda kaydı olduğundan ismi değiştirilemez.", "Haya", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    return;
                //}

                CariHesaplarTP cari = (CariHesaplarTP)lbAltCariler.SelectedItem;

                SatisRaporTP.DoUpdateNoktaAd(CariHesaplarTP.GetBAYIKODByGMREF(((CariHesaplarTP)lbBayiler.SelectedItem).GMREF), cari.MUSTERI, txtAltCariDuzenleIsim.Text);

                cari.MUSTERI = txtAltCariDuzenleIsim.Text;
                cari.SUBE = txtAltCariDuzenleIsim.Text;

                cari.DoUpdate();

                MessageBox.Show("Nokta adı hem altcariler kısmında hem de satış raporunda değiştirildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GetAltCariler();
                txtAltCariDuzenleIsim.Text = string.Empty;
            }
        }

        private void btnAltCariDuzenlemeSil_Click(object sender, EventArgs e)
        {
            if (lbAltCariler.SelectedIndex > -1)
            {
                if (SatisRaporTP.VarMi(CariHesaplarTP.GetBAYIKODByGMREF(((CariHesaplarTP)lbBayiler.SelectedItem).GMREF), ((CariHesaplarTP)lbAltCariler.SelectedItem).SUBE))
                {
                    MessageBox.Show("Alt carinin satış raporunda kaydı olduğundan silinemez.", "Haya", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                int SMREF = ((CariHesaplarTP)lbAltCariler.SelectedItem).SMREF;

                bool anlasmavar = false;
                bool aktivitevar = false;
                bool hizmetbedelivar = false;

                if (Aktiviteler.GetAktiviteCountBySMREF(25, SMREF, Convert.ToDateTime("01.01.2013"), DateTime.Now.AddYears(3), DBNull.Value, true) > 0)
                    aktivitevar = true;

                DataTable dt1 = new DataTable();
                Anlasmalar.GetObjects("1", dt1, SMREF, DBNull.Value, Convert.ToDateTime("01.01.2013"), DateTime.Now.AddYears(3), 0, 100);
                if (dt1.Rows.Count > 0)
                    anlasmavar = true;

                if (AnlasmaHizmetBedelleri.GetObjectCount(SMREF, DBNull.Value, Convert.ToDateTime("01.01.2013"), DateTime.Now.AddYears(3)) > 0)
                    hizmetbedelivar = true;

                if (anlasmavar || aktivitevar || hizmetbedelivar)
                {
                    if (MessageBox.Show("Silinmek istenen alt cariye ait anlaşma, aktivite veya hizmet bedeli girilmiş. Bu uygulamarı başka bir alt cariye aktarırsanız seçilen alt cariyi silebilirsiniz. Uygulamaları aktaracağınız cariyi seçerek silme işlemine devam etmek istediğinize emin misiniz?", "Önemli Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                    {
                        frmINTERNETticaripazarlamacarisecimi frm = new frmINTERNETticaripazarlamacarisecimi();
                        frm.ShowDialog();

                        if (frm.SMREF > 0)
                        {
                            if (SMREF == frm.SMREF)
                            {
                                MessageBox.Show("Silinmek istenen alt cari ile aktarılmak istenen alt cari aynı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }

                            if (aktivitevar)
                            {
                                DataTable dt = new DataTable();
                                Aktiviteler.GetObjectsBySMREF(25, dt, SMREF, Convert.ToDateTime("01.01.2014"), Convert.ToDateTime("01.01.2070"), 0, 10000, true, true);
                                for (int i = 0; i < dt.Rows.Count; i++)
                                {
                                    Aktiviteler aktivite = Aktiviteler.GetObject(Convert.ToInt32(dt.Rows[i]["pkAktiviteID"]));
                                    aktivite.SMREF = frm.SMREF;
                                    aktivite.DoUpdate(true);
                                }
                            }

                            if (anlasmavar)
                            {
                                DataTable dt = new DataTable();
                                Anlasmalar.GetObjects("1", dt, SMREF, true, Convert.ToDateTime("01.01.2014"), Convert.ToDateTime("01.01.2070"), 0, 10000);
                                for (int i = 0; i < dt.Rows.Count; i++)
                                {
                                    Anlasmalar anlasma = Anlasmalar.GetObject(Convert.ToInt32(dt.Rows[i]["pkID"]));
                                    anlasma.SMREF = frm.SMREF;
                                    anlasma.DoUpdate();
                                }
                            }

                            if (hizmetbedelivar)
                            {
                                DataTable dt = new DataTable();
                                AnlasmaHizmetBedelleri.GetObjects(dt, SMREF, DBNull.Value, Convert.ToDateTime("01.01.2013"), DateTime.Now.AddYears(3), 0, 10000);
                                for (int i = 0; i < dt.Rows.Count; i++)
                                {
                                    AnlasmaHizmetBedelleri hizmetbedeli = AnlasmaHizmetBedelleri.GetObject(Convert.ToInt32(dt.Rows[i]["pkID"]));
                                    hizmetbedeli.SMREF = frm.SMREF;
                                    hizmetbedeli.DoUpdate();
                                }
                            }

                            ((CariHesaplarTP)lbAltCariler.SelectedItem).DoDelete(true);
                            SatisRaporTP.DoUpdateNoktaref(((CariHesaplarTP)lbAltCariler.SelectedItem).SMREF, frm.SMREF);
                            MessageBox.Show("Alt cari silindi ve uygulamalar seçilen cariye aktarıldı.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            GetAltCariler();
                            txtAltCariDuzenleIsim.Text = string.Empty;
                        }
                    }
                }
                else
                {
                    ((CariHesaplarTP)lbAltCariler.SelectedItem).DoDelete(true);
                    //lbAltCariler.Items.RemoveAt(lbAltCariler.SelectedIndex);
                    MessageBox.Show("Alt cari silindi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GetAltCariler();
                    txtAltCariDuzenleIsim.Text = string.Empty;
                }
            }
        }

        private void lbAltCariler_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtAltCariDuzenleIsim.Text = ((CariHesaplarTP)lbAltCariler.SelectedItem).SUBE;

            cmbTur.SelectedIndex = -1;
            if (((CariHesaplarTP)lbAltCariler.SelectedItem).MTKOD != string.Empty)
            {
                for (int i = 0; i < cmbTur.Items.Count; i++)
                {
                    if (((CariHesaplarTP)lbAltCariler.SelectedItem).MTKOD == ((MusteriTurler)cmbTur.Items[i]).Kod)
                    {
                        cmbTur.SelectedIndex = i;
                        break;
                    }
                }
            }

            cmbIlce.SelectedIndex = -1;
            if (((CariHesaplarTP)lbAltCariler.SelectedItem).ILKOD != string.Empty)
            {
                for (int i = 0; i < cmbIl.Items.Count; i++)
                {
                    if (((CariHesaplarTP)lbAltCariler.SelectedItem).ILKOD == ((Iller)cmbIl.Items[i]).strIlKod)
                    {
                        cmbIl.SelectedIndex = i;
                        break;
                    }
                }

                if (((CariHesaplarTP)lbAltCariler.SelectedItem).ILCEKOD != string.Empty)
                {
                    for (int i = 0; i < cmbIlce.Items.Count; i++)
                    {
                        if (((CariHesaplarTP)lbAltCariler.SelectedItem).ILCEKOD == ((Ilceler)cmbIlce.Items[i]).pkIlceID.ToString())
                        {
                            cmbIlce.SelectedIndex = i;
                            break;
                        }
                    }
                }
            }
            else
            {
                cmbIl.SelectedIndex = -1;
            }



            checkBox1.Checked = ((CariHesaplarTP)lbAltCariler.SelectedItem).ACTIVE == 1;



            if (((CariHesaplarTP)lbAltCariler.SelectedItem).NETTOP != 0)
            {
                for (int i = 0; i < cmbEsBayi.Items.Count; i++)
                {
                    if (CariHesaplarTP.GetGMREFBySMREF(Convert.ToInt32(((CariHesaplarTP)lbAltCariler.SelectedItem).NETTOP)) == ((CariHesaplarTP)cmbEsBayi.Items[i]).GMREF)
                    {
                        cmbEsBayi.SelectedIndex = i;
                        break;
                    }
                }

                for (int i = 0; i < cmbEsNokta.Items.Count; i++)
                {
                    if (Convert.ToInt32(((CariHesaplarTP)lbAltCariler.SelectedItem).NETTOP) == ((CariHesaplarTP)cmbEsNokta.Items[i]).SMREF)
                    {
                        cmbEsNokta.SelectedIndex = i;
                        break;
                    }
                }
            }
            else
            {
                cmbEsBayi.SelectedIndex = -1;
                cmbEsNokta.SelectedIndex = -1;
            }
        }

        private void cmbYil_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbBayiler.SelectedIndex > -1 && cmbYil.SelectedIndex > -1 && cmbAy.SelectedIndex > -1)
            {
                CariHesaplarTPEk2 cariek = CariHesaplarTPEk2.GetObject(((CariHesaplarTP)lbBayiler.SelectedItem).GMREF, Convert.ToInt32(cmbYil.SelectedItem), Convert.ToInt32(cmbAy.SelectedItem));
                txtTAHKar.Text = cariek.TAH_KAR.ToString("N1");
                txtYEGKar.Text = cariek.YEG_KAR.ToString("N1");
                txtTAHIsk.Text = cariek.TAH_ISK.ToString("N1");
                txtYEGIsk.Text = cariek.YEG_ISK.ToString("N1");
            }
        }

        private void cmbAy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbBayiler.SelectedIndex > -1 && cmbYil.SelectedIndex > -1 && cmbAy.SelectedIndex > -1)
            {
                CariHesaplarTPEk2 cariek = CariHesaplarTPEk2.GetObject(((CariHesaplarTP)lbBayiler.SelectedItem).GMREF, Convert.ToInt32(cmbYil.SelectedItem), Convert.ToInt32(cmbAy.SelectedItem));
                txtTAHKar.Text = cariek.TAH_KAR.ToString("N1");
                txtYEGKar.Text = cariek.YEG_KAR.ToString("N1");
                txtTAHIsk.Text = cariek.TAH_ISK.ToString("N1");
                txtYEGIsk.Text = cariek.YEG_ISK.ToString("N1");
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            CariHesaplarTP cari = (CariHesaplarTP)lbAltCariler.SelectedItem;

            cari.ACTIVE = checkBox1.Checked ? (short)1 : (short)0;
            cari.ILKOD = cmbIl.SelectedIndex > -1 ? ((Iller)cmbIl.SelectedItem).strIlKod : string.Empty;
            cari.IL = cari.ILKOD != string.Empty ? Iller.GetObjectByILKOD(cari.ILKOD) : string.Empty;
            cari.ILCEKOD = cmbIlce.SelectedIndex > -1 ? ((Ilceler)cmbIlce.SelectedItem).pkIlceID.ToString() : string.Empty;
            cari.ILCE = cari.ILCEKOD != string.Empty ? Ilceler.GetObjectByID(((Ilceler)cmbIlce.SelectedItem).pkIlceID) : string.Empty;
            cari.MTKOD = cmbTur.SelectedIndex > -1 ? ((MusteriTurler)cmbTur.SelectedItem).Kod : string.Empty;
            cari.MTACIKLAMA = cmbTur.SelectedIndex > -1 ? CariHesaplar.GetMtAciklama(cari.MTKOD) : string.Empty;
            cari.NETTOP = cmbEsNokta.SelectedIndex > -1 ? ((CariHesaplarTP)cmbEsNokta.SelectedItem).SMREF : 0;

            cari.DoUpdate();

            MessageBox.Show("Kayıt güncellendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void cmbEsBayi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbEsBayi.SelectedIndex > -1)
                CariHesaplarTP.GetObjects(cmbEsNokta.Items, ((CariHesaplarTP)cmbEsBayi.SelectedItem).GMREF);
        }

        private void cmbEsNokta_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                cmbEsNokta.SelectedIndex = -1;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string dosya = "";
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Excel dosyaları (*.xls, *.xlsx)|*.xls;*.xlsx;|Bütün Dosyalar|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
                dosya = ofd.FileName;

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

                range = ws.get_Range("A1", "B6666");

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

            ArrayList chtps = new ArrayList();
            for (int i = 2; i <= values.GetLength(0); i++)
            {
                if (values[i, 1] == null) // 1.kolon boş ise bu satırdan sonrasına bakmasın
                    break;

                try
                {
                    if (Convert.ToInt32(values[i, 1]) != Convert.ToInt32(values[i, 2]))
                    {
                        CariHesaplarTP chtp = CariHesaplarTP.GetObject(Convert.ToInt32(values[i, 1]), false);

                        if (chtp.NETTOP != Convert.ToInt32(values[i, 2]))
                        {
                            chtp.NETTOP = Convert.ToInt32(values[i, 2]);
                            chtps.Add(chtp);
                        }
                    }
                }
                catch (Exception ex)
                {
                    chtps.Clear();
                    MessageBox.Show(ex.Message);
                }
            }

            for (int i = 0; i < chtps.Count; i++)
                ((CariHesaplarTP)chtps[i]).DoUpdate();

            MessageBox.Show("Aktarım tamamlandı.", "Başarılı");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string dosya = "";
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Excel dosyaları (*.xls, *.xlsx)|*.xls;*.xlsx;|Bütün Dosyalar|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
                dosya = ofd.FileName;

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

                range = ws.get_Range("A1", "B6666");

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

            ArrayList chtps = new ArrayList();
            for (int i = 2; i <= values.GetLength(0); i++)
            {
                if (values[i, 1] == null) // 1.kolon boş ise bu satırdan sonrasına bakmasın
                    break;

                try
                {
                    CariHesaplarTP chtp = CariHesaplarTP.GetObject(Convert.ToInt32(values[i, 1]), false);

                    chtp.ACTIVE = Convert.ToInt16(values[i, 2]);
                    chtps.Add(chtp);
                }
                catch (Exception ex)
                {
                    chtps.Clear();
                    MessageBox.Show(ex.Message);
                }
            }

            for (int i = 0; i < chtps.Count; i++)
                ((CariHesaplarTP)chtps[i]).DoUpdate();

            MessageBox.Show("Aktarım tamamlandı.", "Başarılı");
        }
    }
}

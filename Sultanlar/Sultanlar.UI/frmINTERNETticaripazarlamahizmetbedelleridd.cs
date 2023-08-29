using System;
using System.Collections;
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
    public partial class frmINTERNETticaripazarlamahizmetbedelleridd : Form
    {
        public frmINTERNETticaripazarlamahizmetbedelleridd()
        {
            InitializeComponent();
        }

        private void frmINTERNETticaripazarlamahizmetbedelleridd_Load(object sender, EventArgs e)
        {
            cmbBolum.Items.Clear();
            if (frmAna.KAdi.StartsWith("YEG"))
            {
                cmbBolum.Items.Add("YEG");
            }
            else if (frmAna.KAdi == "BI04" || frmAna.KAdi == "ADMİNİSTRATOR")
            {
                cmbBolum.Items.Add("AHT");
                cmbBolum.Items.Add("YEG");
                cmbBolum.Items.Add("DİĞER");
                cmbBolum.Items.Add("TEMİZLİK");
                cmbBolum.Items.Add("GIDA");
                cmbBolum.Items.Add("ARI");
            }
            else
            {
                cmbBolum.Items.Add("AHT");
                cmbBolum.Items.Add("DİĞER");
                cmbBolum.Items.Add("TEMİZLİK");
                cmbBolum.Items.Add("GIDA");
                cmbBolum.Items.Add("ARI");
            }

            GetObjects();
            FocusedRow();
        }

        private void GetBedelAdlari()
        {
            AnlasmaBedelAdlari.GetObjects(cmbTur.Items, true);
        }

        private void GetMusteriler()
        {
            CariHesaplar.GetMUSTERIs(cmbMusteri.Items, "", false);
        }

        private void GetObjects()
        {
            GetBedelAdlari();
            GetMusteriler();

            Temizle();

            DataTable dt = new DataTable();
            AnlasmaHizmetBedelleriDD.GetObjects(dt, frmAna.KAdi);
            gridControl4.DataSource = dt;
        }

        private void Temizle()
        {
            txtYil.Text = DateTime.Now.Year.ToString();
            txtAy.Text = "1";
            txtNet.Text = "0";
            txtKDV.Text = "0";
            txtFaturaNo.Text = string.Empty;
            txtAciklama.Text = string.Empty;
            txtAciklama2.Text = string.Empty;
            txtAciklama3.Text = string.Empty;
            txtAciklama4.Text = string.Empty;
            dtpFatura.Value = DateTime.Now;
            dtpMuhasebe.Value = DateTime.Now;
            cbMaliyet.Checked = true;
        }

        private void FocusedRow()
        {
            if (gridView4.SelectedRowsCount > 0 && !gridView4.IsFilterRow(gridView4.GetSelectedRows()[0]))
            {
                sbEkle.Text = "Güncelle";

                int ID = Convert.ToInt32(gridView4.GetRowCellValue(gridView4.FocusedRowHandle, "pkID"));
                AnlasmaHizmetBedelleriDD ahb = AnlasmaHizmetBedelleriDD.GetObject(ID);

                txtAciklama.Text = ahb.strAciklama1;
                txtAciklama2.Text = ahb.strAciklama2;
                txtAciklama3.Text = ahb.strAciklama3;
                txtAciklama4.Text = ahb.strAciklama4;
                txtAy.Text = ahb.intAy.ToString();
                txtFaturaNo.Text = ahb.strFaturaNo;
                txtKDV.Text = ahb.mnKDV.ToString("N2");
                txtNet.Text = ahb.mnNet.ToString("N2");
                txtYil.Text = ahb.intYil.ToString();
                cbMaliyet.Checked = ahb.blMaliyetEtki;
                dtpFatura.Value = ahb.dtFaturaTarih;
                dtpMuhasebe.Value = ahb.dtMuhasebeTeslim;

                for (int i = 0; i < cmbBolum.Items.Count; i++)
                {
                    if (cmbBolum.Items[i].ToString() == ahb.strBolum)
                    {
                        cmbBolum.SelectedIndex = i;
                        break;
                    }
                }
                for (int i = 0; i < cmbMusteri.Items.Count; i++)
                {
                    if (((CariHesaplar)cmbMusteri.Items[i]).GMREF == ahb.GMREF)
                    {
                        cmbMusteri.SelectedIndex = i;
                        break;
                    }
                }
                for (int i = 0; i < cmbTur.Items.Count; i++)
                {
                    if (((AnlasmaBedelAdlari)cmbTur.Items[i]).pkID == ahb.intAnlasmaBedelAdID)
                    {
                        cmbTur.SelectedIndex = i;
                        break;
                    }
                }
            }
            else
            {
                sbEkle.Text = "Ekle";
                Temizle();
            }
        }

        private void btnYenile_Click(object sender, EventArgs e)
        {
            GetObjects();
            FocusedRow();
        }

        private void sbEkle_Click(object sender, EventArgs e)
        {
            if (cmbMusteri.SelectedIndex == -1 || cmbBolum.SelectedIndex == -1 || cmbTur.SelectedIndex == -1)
            {
                MessageBox.Show("Eksik seçim var.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (sbEkle.Text == "Ekle")
            {
                try
                {
                    string uyari = AnlasmaHizmetBedelleriDD.VarMi(txtFaturaNo.Text.Trim()) ? "UYARI !\r\n\r\n\r\nAynı fatura numarası daha önce girilmiş. Yine de eklemek istediğinize emin misiniz?\r\n\r\n\r\n" : "Eklemek istediğinize emin misiniz?";

                    if (MessageBox.Show(uyari, "Ekleme", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                    {
                        AnlasmaHizmetBedelleriDD ahb = new AnlasmaHizmetBedelleriDD(DateTime.Now,
                            ((CariHesaplar)cmbMusteri.SelectedItem).GMREF,
                            ((AnlasmaBedelAdlari)cmbTur.SelectedItem).pkID,
                            Convert.ToInt32(txtAy.Text),
                            Convert.ToInt32(txtYil.Text),
                            txtFaturaNo.Text.Trim(),
                            dtpFatura.Value,
                            cmbBolum.SelectedItem.ToString(),
                            Convert.ToDecimal(txtNet.Text.Trim()),
                            Convert.ToDecimal(txtKDV.Text.Trim()),
                            dtpMuhasebe.Value,
                            txtAciklama.Text.Trim(), txtAciklama2.Text.Trim(), txtAciklama3.Text.Trim(), txtAciklama4.Text.Trim(),
                            cbMaliyet.Checked);
                        ahb.DoInsert();

                        MessageBox.Show("Hizmet bedeli eklendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        cmbMusteri.Focus();

                        //GetObjects();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (sbEkle.Text == "Güncelle")
            {
                if (MessageBox.Show("Güncellemek istediğinize emin misiniz?", "Güncelleme", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    try
                    {
                        int ID = Convert.ToInt32(gridView4.GetRowCellValue(gridView4.FocusedRowHandle, "pkID"));

                        AnlasmaHizmetBedelleriDD ahb = AnlasmaHizmetBedelleriDD.GetObject(ID);
                        ahb.GMREF = ((CariHesaplar)cmbMusteri.SelectedItem).GMREF;
                        ahb.intAnlasmaBedelAdID = ((AnlasmaBedelAdlari)cmbTur.SelectedItem).pkID;
                        ahb.intAy = Convert.ToInt32(txtAy.Text);
                        ahb.intYil = Convert.ToInt32(txtYil.Text);
                        ahb.strFaturaNo = txtFaturaNo.Text.Trim();
                        ahb.dtFaturaTarih = dtpFatura.Value;
                        ahb.strBolum = cmbBolum.SelectedItem.ToString();
                        ahb.mnNet = Convert.ToDecimal(txtNet.Text.Trim());
                        ahb.mnKDV = Convert.ToDecimal(txtKDV.Text.Trim());
                        ahb.dtMuhasebeTeslim = dtpMuhasebe.Value;
                        ahb.strAciklama1 = txtAciklama.Text.Trim();
                        ahb.strAciklama2 = txtAciklama2.Text.Trim();
                        ahb.strAciklama3 = txtAciklama3.Text.Trim();
                        ahb.strAciklama4 = txtAciklama4.Text.Trim();
                        ahb.blMaliyetEtki = cbMaliyet.Checked;
                        ahb.DoUpdate();

                        MessageBox.Show("Hizmet bedeli güncellendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        cmbMusteri.Focus();

                        //GetObjects();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void frmINTERNETticaripazarlamahizmetbedelleridd_SizeChanged(object sender, EventArgs e)
        {
            lblMusteri.Location = new Point(lblMusteri.Location.X, lblAlt.Location.Y + 16);
            cmbMusteri.Location = new Point(cmbMusteri.Location.X, lblAlt.Location.Y + 14);
            lblYil.Location = new Point(lblYil.Location.X, lblAlt.Location.Y + 16);
            txtYil.Location = new Point(txtYil.Location.X, lblAlt.Location.Y + 14);
            lblAy.Location = new Point(lblAy.Location.X, lblAlt.Location.Y + 16);
            txtAy.Location = new Point(txtAy.Location.X, lblAlt.Location.Y + 14);
            lblNet.Location = new Point(lblNet.Location.X, lblAlt.Location.Y + 16);
            txtNet.Location = new Point(txtNet.Location.X, lblAlt.Location.Y + 14);
            lblKDV.Location = new Point(lblKDV.Location.X, lblAlt.Location.Y + 16);
            txtKDV.Location = new Point(txtKDV.Location.X, lblAlt.Location.Y + 14);
            cbMaliyet.Location = new Point(cbMaliyet.Location.X, lblAlt.Location.Y + 16);
            lblTur.Location = new Point(lblTur.Location.X, lblAlt.Location.Y + 43);
            cmbTur.Location = new Point(cmbTur.Location.X, lblAlt.Location.Y + 41);
            lblBolum.Location = new Point(lblBolum.Location.X, lblAlt.Location.Y + 43);
            cmbBolum.Location = new Point(cmbBolum.Location.X, lblAlt.Location.Y + 41);
            lblFat.Location = new Point(lblFat.Location.X, lblAlt.Location.Y + 43);
            txtFaturaNo.Location = new Point(txtFaturaNo.Location.X, lblAlt.Location.Y + 41);
            dtpFatura.Location = new Point(dtpFatura.Location.X, lblAlt.Location.Y + 41);
            lblAciklama.Location = new Point(lblAciklama.Location.X, lblAlt.Location.Y + 43);
            txtAciklama.Location = new Point(txtAciklama.Location.X, lblAlt.Location.Y + 41);
            lblMuhasebe.Location = new Point(lblMuhasebe.Location.X, lblAlt.Location.Y + 43);
            dtpMuhasebe.Location = new Point(dtpMuhasebe.Location.X, lblAlt.Location.Y + 41);
            lblAciklama2.Location = new Point(lblAciklama2.Location.X, lblAlt.Location.Y + 71);
            txtAciklama2.Location = new Point(txtAciklama2.Location.X, lblAlt.Location.Y + 69);
            lblAciklama3.Location = new Point(lblAciklama3.Location.X, lblAlt.Location.Y + 71);
            txtAciklama3.Location = new Point(txtAciklama3.Location.X, lblAlt.Location.Y + 69);
            lblAciklama4.Location = new Point(lblAciklama4.Location.X, lblAlt.Location.Y + 71);
            txtAciklama4.Location = new Point(txtAciklama4.Location.X, lblAlt.Location.Y + 69);
            sbEkle.Location = new Point(sbEkle.Location.X, lblAlt.Location.Y + 69);
        }

        private void gridView4_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            FocusedRow();
        }

        private void btnToplu_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Excel dosyaları (*.xls, *.xlsx)|*.xls;*.xlsx;|Bütün Dosyalar|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                if (MessageBox.Show("Dosyadan aktarım yapmak istediğinize emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    ExceldenAl(ofd.FileName);
                }
            }
        }

        private void ExceldenAl(object dosya)
        {
            ArrayList veriler = new ArrayList();

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
                veriler.Clear();
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
            
            for (int i = 2; i <= values.GetLength(0); i++) // 1.satır başlıklar
            {
                if (values[i, 1] == null) // 1.kolon boş ise bu satırdan sonrasına bakmasın
                    break;

                try
                {
                    ArrayList kolonlar = new ArrayList();
                    kolonlar.Add(Convert.ToInt32(values[i, 1]));
                    kolonlar.Add(Convert.ToInt32(values[i, 2]));
                    kolonlar.Add(Convert.ToInt32(values[i, 3]));
                    kolonlar.Add(values[i, 4].ToString());
                    kolonlar.Add(Convert.ToDecimal(values[i, 5]));
                    kolonlar.Add(Convert.ToDecimal(values[i, 6]));
                    kolonlar.Add(values[i, 7].ToString());

                    veriler.Add(kolonlar);
                }
                catch (Exception ex)
                {
                    veriler.Clear();
                    MessageBox.Show("Hata oluşan satır: " + i.ToString() + "\r\nHata ayrıntısı: " + ex.Message);
                }
            }

            if (MessageBox.Show(veriler.Count.ToString() + " satır aktarım için hazır. Devam etmek istediğinize emin misiniz?", "Aktarım", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
            {
                DateTime simdi = DateTime.Now;
                for (int i = 0; i < veriler.Count; i++)
                {
                    AnlasmaHizmetBedelleriDD ahb = new AnlasmaHizmetBedelleriDD(simdi,
                        Convert.ToInt32(((ArrayList)veriler[i])[0]),
                        10,
                        Convert.ToInt32(((ArrayList)veriler[i])[1]),
                        Convert.ToInt32(((ArrayList)veriler[i])[2]),
                        "000000",
                        simdi,
                        ((ArrayList)veriler[i])[3].ToString(),
                        -1 * Convert.ToDecimal(((ArrayList)veriler[i])[4]),
                        -1 * Convert.ToDecimal(((ArrayList)veriler[i])[4]) / 100 * Convert.ToDecimal(((ArrayList)veriler[i])[5]),
                        simdi,
                        ((ArrayList)veriler[i])[6].ToString(), "", "", "", true);
                    ahb.DoInsert();
                }
                MessageBox.Show("Aktarım tamamlandı.", "Aktarım", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnToplu_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                frmYardim frm = new frmYardim(Sultanlar.UI.Properties.Resources.toplu_hiz_b_2);
                frm.ShowDialog();
            }
        }
    }
}

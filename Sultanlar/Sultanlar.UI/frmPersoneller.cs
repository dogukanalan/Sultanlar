using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sultanlar.DatabaseObject;
using Sultanlar.Class;

namespace Sultanlar.UI
{
    public partial class frmPersoneller : Form
    {
        public frmPersoneller()
        {
            InitializeComponent();
        }
        //
        //
        //
        //
        //
        bool YeniSatirEklendi = false;
        //
        //
        //
        //
        //
        private void frmPersoneller_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;

            GetObjects();

            Departmanlar.GetObjectHepsi(cmbDepartmanlar.Items, true);
            Gorevler.GetObjectHepsi(cmbGorevler.Items, true);
            KanGruplari.GetObject(cmbKanGruplari.Items, true);
            AskerlikDurumlari.GetObject(cmbAskerlikDurumlari.Items, true);
            MedeniDurumlar.GetObject(cmbMedeniDurumlar.Items, true);
            OgrenimDurumlari.GetObject(cmbOgrenimDurumlari.Items, true);
            SurucuBelgeSiniflari.GetObject(cmbSurucuBelgeSiniflari.Items, true);
            PerFirmalar.GetObject(cmbFirmalar.Items, true);
            PerSSKFirmalar.GetObject(cmbSSKFirmalar.Items, true);
        }
        //
        //
        private void GetObjects()
        {
            DataTable dt = new DataTable();
            Personeller.GetObject(dt);
            dgvPersoneller.DataSource = dt;
        }
        //
        //
        private void Temizle()
        {
            btnEkle.Enabled = true;
            btnGuncelle.Enabled = false;
            btnSil.Enabled = false;

            txtKod.Text = string.Empty;
            txtAd.Text = string.Empty;
            cmbDepartmanlar.SelectedIndex = -1;
            cmbGorevler.SelectedIndex = -1;
            txtGorevTanimi.Text = string.Empty;
            rbDurumHayir.Checked = true;
            rbCinsiyetEvet.Checked = true;
            txtTCKimlikNo.Text = string.Empty;
            txtSSKNo.Text = string.Empty;
            cmbKanGruplari.SelectedIndex = -1;
            cmbAskerlikDurumlari.SelectedIndex = -1;
            cmbMedeniDurumlar.SelectedIndex = -1;
            txtAdres.Text = string.Empty;
            txtTelefon.Text = string.Empty;
            txtCocukSayisi.Text = string.Empty;
            cmbOgrenimDurumlari.SelectedIndex = -1;
            cmbSurucuBelgeSiniflari.SelectedIndex = -1;
            cmbFirmalar.SelectedIndex = -1;
            cmbSSKFirmalar.SelectedIndex = -1;
            txtAciklama.Text = string.Empty;

            dtpGirisTarihi.Value = DateTime.Now;
            dtpGirisTarihi.Enabled = true;
            dtpCikisTarihi.Value = DateTime.Now;
            dtpCikisTarihi.Enabled = true;
            dtpDogumTarihi.Value = DateTime.Now;
            dtpDogumTarihi.Enabled = true;
            dtpEvlilikTarihi.Value = DateTime.Now;
            dtpEvlilikTarihi.Enabled = true;
        }
        //
        //
        private void btnTemizle_Click(object sender, EventArgs e)
        {
            dgvPersoneller.ClearSelection();

            Temizle();

            txtKod.Text = (Convert.ToInt16(dgvPersoneller.Rows[dgvPersoneller.Rows.Count - 1].Cells["clsintPerKod"].Value) + 1).ToString();
        }
        //
        //
        private void dtpEvlilikTarihi_ValueChanged(object sender, EventArgs e)
        {
            if (((DateTimePicker)sender).Value == DateTime.Now && txtKod.Text != string.Empty)
            {
                ((DateTimePicker)sender).Enabled = false;
            }
            else
            {
                ((DateTimePicker)sender).Enabled = true;
            }
        }
        //
        //
        private void dgvPersoneller_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            Temizle();

            if (e.RowIndex >= 0 && YeniSatirEklendi == false)
            {
                btnEkle.Enabled = false;
                btnGuncelle.Enabled = true;
                btnSil.Enabled = true;

                txtKod.Text = dgvPersoneller.Rows[e.RowIndex].Cells["clsintPerKod"].Value.ToString();
                txtAd.Text = dgvPersoneller.Rows[e.RowIndex].Cells["clstrPerAd"].Value.ToString();

                for (int i = 0; i < cmbDepartmanlar.Items.Count; i++)
                {
                    if (((Departmanlar)cmbDepartmanlar.Items[i]).strDepartman == dgvPersoneller.Rows[e.RowIndex].Cells["clstrDepartman"].Value.ToString())
                    {
                        cmbDepartmanlar.SelectedIndex = i;
                        i = cmbDepartmanlar.Items.Count;
                    }
                }

                for (int i = 0; i < cmbGorevler.Items.Count; i++)
                {
                    if (((Gorevler)cmbGorevler.Items[i]).strGorev == dgvPersoneller.Rows[e.RowIndex].Cells["clstrGorev"].Value.ToString())
                    {
                        cmbGorevler.SelectedIndex = i;
                        i = cmbGorevler.Items.Count;
                    }
                }

                txtGorevTanimi.Text = dgvPersoneller.Rows[e.RowIndex].Cells["clstrGorevTanimi"].Value.ToString();
                dtpGirisTarihi.Value = Convert.ToDateTime(dgvPersoneller.Rows[e.RowIndex].Cells["cldtPerGiris"].Value.ToString());
                if (dgvPersoneller.Rows[e.RowIndex].Cells["cldtPerCikis"].Value.ToString() != string.Empty)
                    dtpCikisTarihi.Value = Convert.ToDateTime(dgvPersoneller.Rows[e.RowIndex].Cells["cldtPerCikis"].Value.ToString());
                else
                    dtpCikisTarihi.Value = DateTime.Now;
                rbDurumEvet.Checked = Convert.ToBoolean(dgvPersoneller.Rows[e.RowIndex].Cells["clblPerDurum"].Value);
                rbDurumHayir.Checked = !Convert.ToBoolean(dgvPersoneller.Rows[e.RowIndex].Cells["clblPerDurum"].Value);
                rbCinsiyetEvet.Checked = Convert.ToBoolean(dgvPersoneller.Rows[e.RowIndex].Cells["clblPerCinsiyet"].Value);
                rbCinsiyetHayir.Checked = !Convert.ToBoolean(dgvPersoneller.Rows[e.RowIndex].Cells["clblPerCinsiyet"].Value);
                if (dgvPersoneller.Rows[e.RowIndex].Cells["cldtPerDogumTarihi"].Value.ToString() != string.Empty)
                    dtpDogumTarihi.Value = Convert.ToDateTime(dgvPersoneller.Rows[e.RowIndex].Cells["cldtPerDogumTarihi"].Value.ToString());
                else
                    dtpDogumTarihi.Value = DateTime.Now;
                txtTCKimlikNo.Text = dgvPersoneller.Rows[e.RowIndex].Cells["clstrPerTCKimlikNo"].Value.ToString();
                txtSSKNo.Text = dgvPersoneller.Rows[e.RowIndex].Cells["clstrPerSSKNo"].Value.ToString();

                for (int i = 0; i < cmbKanGruplari.Items.Count; i++)
                {
                    if (((KanGruplari)cmbKanGruplari.Items[i]).strKanGrubu == dgvPersoneller.Rows[e.RowIndex].Cells["clstrKanGrubu"].Value.ToString())
                    {
                        cmbKanGruplari.SelectedIndex = i;
                        i = cmbKanGruplari.Items.Count;
                    }
                }

                for (int i = 0; i < cmbAskerlikDurumlari.Items.Count; i++)
                {
                    if (((AskerlikDurumlari)cmbAskerlikDurumlari.Items[i]).strAskerlikDurumu == dgvPersoneller.Rows[e.RowIndex].Cells["clstrAskerlikDurumu"].Value.ToString())
                    {
                        cmbAskerlikDurumlari.SelectedIndex = i;
                        i = cmbAskerlikDurumlari.Items.Count;
                    }
                }

                for (int i = 0; i < cmbMedeniDurumlar.Items.Count; i++)
                {
                    if (((MedeniDurumlar)cmbMedeniDurumlar.Items[i]).strMedeniDurum == dgvPersoneller.Rows[e.RowIndex].Cells["clstrMedeniDurum"].Value.ToString())
                    {
                        cmbMedeniDurumlar.SelectedIndex = i;
                        i = cmbMedeniDurumlar.Items.Count;
                    }
                }

                if (dgvPersoneller.Rows[e.RowIndex].Cells["cldtPerEvlilikTarihi"].Value.ToString() != string.Empty)
                    dtpEvlilikTarihi.Value = Convert.ToDateTime(dgvPersoneller.Rows[e.RowIndex].Cells["cldtPerEvlilikTarihi"].Value.ToString());
                else
                    dtpEvlilikTarihi.Value = DateTime.Now;
                txtAdres.Text = dgvPersoneller.Rows[e.RowIndex].Cells["clstrPerAdres"].Value.ToString();
                txtTelefon.Text = dgvPersoneller.Rows[e.RowIndex].Cells["clstrPerTelefon"].Value.ToString();
                txtCocukSayisi.Text = dgvPersoneller.Rows[e.RowIndex].Cells["cltintPerCocukSayisi"].Value.ToString();

                for (int i = 0; i < cmbOgrenimDurumlari.Items.Count; i++)
                {
                    if (((OgrenimDurumlari)cmbOgrenimDurumlari.Items[i]).strOgrenimDurumu == dgvPersoneller.Rows[e.RowIndex].Cells["clstrOgrenimDurumu"].Value.ToString())
                    {
                        cmbOgrenimDurumlari.SelectedIndex = i;
                        i = cmbOgrenimDurumlari.Items.Count;
                    }
                }

                for (int i = 0; i < cmbSurucuBelgeSiniflari.Items.Count; i++)
                {
                    if (((SurucuBelgeSiniflari)cmbSurucuBelgeSiniflari.Items[i]).strSurucuBelgeSinifi == dgvPersoneller.Rows[e.RowIndex].Cells["clstrSurucuBelgeSinifi"].Value.ToString())
                    {
                        cmbSurucuBelgeSiniflari.SelectedIndex = i;
                        i = cmbSurucuBelgeSiniflari.Items.Count;
                    }
                }

                for (int i = 0; i < cmbFirmalar.Items.Count; i++)
                {
                    if (((PerFirmalar)cmbFirmalar.Items[i]).strPerFirmaAdi == dgvPersoneller.Rows[e.RowIndex].Cells["clstrPerFirmaAdi"].Value.ToString())
                    {
                        cmbFirmalar.SelectedIndex = i;
                        i = cmbFirmalar.Items.Count;
                    }
                }

                for (int i = 0; i < cmbSSKFirmalar.Items.Count; i++)
                {
                    if (((PerSSKFirmalar)cmbSSKFirmalar.Items[i]).strPerSSKFirmaAdi == dgvPersoneller.Rows[e.RowIndex].Cells["clstrPerSSKFirmaAdi"].Value.ToString())
                    {
                        cmbSSKFirmalar.SelectedIndex = i;
                        i = cmbSSKFirmalar.Items.Count;
                    }
                }

                txtAciklama.Text = dgvPersoneller.Rows[e.RowIndex].Cells["clstrPerAciklama"].Value.ToString();
            }
        }
        //
        //
        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (txtAd.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Ad girilmedi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            byte departmanid = 0;
            byte gorevid = 0;
            byte kangrubu = 0;
            byte askerlikdurumu = 0;
            byte medenidurum = 0;
            byte cocuksayisi = 0;
            byte ogrenimdurumu = 0;
            byte surucubelgesinifi = 0;
            byte firma = 0;
            byte sskfirma = 0;

            string cikistarihi = string.Empty;
            string dogumtarihi = string.Empty;
            string evliliktarihi = string.Empty;

            if (cmbDepartmanlar.SelectedIndex > -1)
                departmanid = ((Departmanlar)cmbDepartmanlar.SelectedItem).pkDepartmanID;
            if (cmbGorevler.SelectedIndex > -1)
                gorevid = ((Gorevler)cmbGorevler.SelectedItem).pkGorevID;
            if (cmbKanGruplari.SelectedIndex > -1)
                kangrubu = ((KanGruplari)cmbKanGruplari.SelectedItem).pkKanGrubuID;
            if (cmbAskerlikDurumlari.SelectedIndex > -1)
                askerlikdurumu = ((AskerlikDurumlari)cmbAskerlikDurumlari.SelectedItem).pkAskerlikDurumuID;
            if (cmbMedeniDurumlar.SelectedIndex > -1)
                medenidurum = ((MedeniDurumlar)cmbMedeniDurumlar.SelectedItem).pkMedeniDurumID;
            if (txtCocukSayisi.Text != string.Empty)
                cocuksayisi = Convert.ToByte(txtCocukSayisi.Text.Trim());
            if (cmbOgrenimDurumlari.SelectedIndex > -1)
                ogrenimdurumu = ((OgrenimDurumlari)cmbOgrenimDurumlari.SelectedItem).pkOgrenimDurumuID;
            if (cmbSurucuBelgeSiniflari.SelectedIndex > -1)
                surucubelgesinifi = ((SurucuBelgeSiniflari)cmbSurucuBelgeSiniflari.SelectedItem).pkSurucuBelgeSinifiID;
            if (cmbFirmalar.SelectedIndex > -1)
                firma = ((PerFirmalar)cmbFirmalar.SelectedItem).pkPerFirmaID;
            if (cmbSSKFirmalar.SelectedIndex > -1)
                sskfirma = ((PerSSKFirmalar)cmbSSKFirmalar.SelectedItem).pkPerSSKFirmaID;

            if (dtpCikisTarihi.Enabled == true)
            {
                cikistarihi = dtpCikisTarihi.Value.ToShortDateString();
            }
            if (dtpDogumTarihi.Enabled == true)
            {
                dogumtarihi = dtpDogumTarihi.Value.ToShortDateString();
            }
            if (dtpEvlilikTarihi.Enabled == true)
            {
                evliliktarihi = dtpEvlilikTarihi.Value.ToShortDateString();
            }

            Personeller prs = new Personeller(Convert.ToInt16(txtKod.Text.Trim()), txtAd.Text.Trim(), departmanid, gorevid, txtGorevTanimi.Text.Trim(),
                dtpGirisTarihi.Value.ToShortDateString(), cikistarihi, rbDurumEvet.Checked, rbCinsiyetEvet.Checked,
                dogumtarihi, txtTCKimlikNo.Text.Trim(), txtSSKNo.Text.Trim(), kangrubu, askerlikdurumu, medenidurum,
                evliliktarihi, cocuksayisi, txtAdres.Text.Trim(), 0, 0, txtTelefon.Text.Trim(), ogrenimdurumu, surucubelgesinifi, firma, 
                sskfirma, txtAciklama.Text.Trim());

             

            if (MessageBox.Show("Yeni bir satır eklenmek üzere. Emin misiniz?", "Ekleme", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
            {
                prs.DoInsert();
                YeniSatirEklendi = true;
                GetObjects();
                YeniSatirEklendi = false;
                btnTemizle.PerformClick();
            }
            else if (DialogResult == System.Windows.Forms.DialogResult.No)
            {
                btnTemizle.PerformClick();
            }
            else if (DialogResult == System.Windows.Forms.DialogResult.Cancel)
            {

            }
        }
        //
        //
        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            ListBox lb = new ListBox();

            Personeller.GetObjectByKod(lb.Items, Convert.ToInt16(dgvPersoneller.SelectedRows[0].Cells["clsintPerKod"].Value.ToString()));

            Personeller pers = (Personeller)lb.Items[0];

            pers.strPerAd = txtAd.Text;

            pers.tintDepartmanID = 0;
            if (cmbDepartmanlar.SelectedIndex > -1)
                pers.tintDepartmanID = ((Departmanlar)cmbDepartmanlar.SelectedItem).pkDepartmanID;

            pers.tintGorevID = 0;
            if (cmbGorevler.SelectedIndex > -1)
                pers.tintGorevID = ((Gorevler)cmbGorevler.SelectedItem).pkGorevID;

            pers.strGorevTanimi = txtGorevTanimi.Text;
            pers.dtPerGiris = dtpGirisTarihi.Value.ToShortDateString();
            if (dtpCikisTarihi.Enabled == true)
                pers.dtPerCikis = dtpCikisTarihi.Value.ToShortDateString();
            pers.blPerDurum = rbDurumEvet.Checked;
            pers.blPerCinsiyet = rbCinsiyetEvet.Checked;
            if (dtpDogumTarihi.Enabled == true)
                pers.dtPerDogumTarihi = dtpDogumTarihi.Value.ToShortDateString();
            pers.strPerTCKimlikNo = txtTCKimlikNo.Text;
            pers.strPerSSKNo = txtSSKNo.Text;

            pers.tintKanGrubuID = 0;
            if (cmbKanGruplari.SelectedIndex > -1)
                pers.tintKanGrubuID = ((KanGruplari)cmbKanGruplari.SelectedItem).pkKanGrubuID;

            pers.tintAskerlikDurumuID = 0;
            if (cmbAskerlikDurumlari.SelectedIndex > -1)
                pers.tintAskerlikDurumuID = ((AskerlikDurumlari)cmbAskerlikDurumlari.SelectedItem).pkAskerlikDurumuID;

            pers.tintMedeniDurumID = 0;
            if (cmbMedeniDurumlar.SelectedIndex > -1)
                pers.tintMedeniDurumID = ((MedeniDurumlar)cmbMedeniDurumlar.SelectedItem).pkMedeniDurumID;

            if (dtpEvlilikTarihi.Enabled == true)
                pers.dtPerEvlilikTarihi = dtpEvlilikTarihi.Value.ToShortDateString();

            pers.tintPerCocukSayisi = 0;
            if (txtCocukSayisi.Text != string.Empty)
                pers.tintPerCocukSayisi = Convert.ToByte(txtCocukSayisi.Text);

            pers.strPerAdres = txtAdres.Text;
            // il
            // ilce
            pers.strPerTelefon = txtTelefon.Text;

            pers.tintOgrenimDurumuID = 0;
            if (cmbOgrenimDurumlari.SelectedIndex > -1)
                pers.tintOgrenimDurumuID = ((OgrenimDurumlari)cmbOgrenimDurumlari.SelectedItem).pkOgrenimDurumuID;

            pers.tintSurucuBelgeSinifiID = 0;
            if (cmbSurucuBelgeSiniflari.SelectedIndex > -1)
                pers.tintSurucuBelgeSinifiID = ((SurucuBelgeSiniflari)cmbSurucuBelgeSiniflari.SelectedItem).pkSurucuBelgeSinifiID;

            pers.tintPerFirmaID = 0;
            if (cmbFirmalar.SelectedIndex > -1)
                pers.tintPerFirmaID = ((PerFirmalar)cmbFirmalar.SelectedItem).pkPerFirmaID;

            pers.tintPerSSKFirmaID = 0;
            if (cmbSSKFirmalar.SelectedIndex > -1)
                pers.tintPerSSKFirmaID = ((PerSSKFirmalar)cmbSSKFirmalar.SelectedItem).pkPerSSKFirmaID;

            if (txtAciklama.Text.Trim() != string.Empty)
                pers.strPerAciklama = txtAciklama.Text;

            pers.DoUpdate();
            YeniSatirEklendi = true;
            GetObjects();
            btnTemizle.PerformClick();
            YeniSatirEklendi = false;
        }
        //
        //
        private void txtCocukSayisi_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text != string.Empty)
            {
                for (int i = 0; i < ((TextBox)sender).Text.Length; i++)
                {
                    if (!char.IsDigit(((TextBox)sender).Text[i]))
                    {
                        ((TextBox)sender).Text = string.Empty;
                    }
                }
            }
            
        }
        //
        //
        private void cmbDepartmanlar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                ((ComboBox)sender).SelectedIndex = -1;
            }
        }
        //
        //
        private void rbDurumHayir_CheckedChanged(object sender, EventArgs e)
        {
            if (rbDurumHayir.Checked == true)
            {
                dtpCikisTarihi.Enabled = true;
            }
            else
            {
                dtpCikisTarihi.Enabled = false;
            }
        }
        //
        //
        private void rbDurumEvet_CheckedChanged(object sender, EventArgs e)
        {
            if (rbDurumEvet.Checked == true)
            {
                dtpCikisTarihi.Enabled = false;
            }
            else
            {
                dtpCikisTarihi.Enabled = true;
            }
        }
        //
        //
        private void btnDogumTarihiDegistir_Click(object sender, EventArgs e)
        {
            if (dtpDogumTarihi.Enabled == true)
            {
                dtpDogumTarihi.Enabled = false;
                btnDogumTarihiDegistir.Text = "+";
            }
            else
            {
                dtpDogumTarihi.Enabled = true;
                btnDogumTarihiDegistir.Text = "-";
            }
        }
        //
        //
        private void btnEvlilikTarihiDegistir_Click(object sender, EventArgs e)
        {
            if (dtpEvlilikTarihi.Enabled == true)
            {
                dtpEvlilikTarihi.Enabled = false;
                btnEvlilikTarihiDegistir.Text = "+";
            }
            else
            {
                dtpEvlilikTarihi.Enabled = true;
                btnEvlilikTarihiDegistir.Text = "-";
            }
        }
        //
        //
        private void btnDepartmanSifirla_Click(object sender, EventArgs e)
        {
            cmbDepartmanlar.SelectedIndex = -1;
        }
        //
        //
        private void btnGorevSifirla_Click(object sender, EventArgs e)
        {
            cmbGorevler.SelectedIndex = -1;
        }
        //
        //
        private void btnKanGrubuSifirla_Click(object sender, EventArgs e)
        {
            cmbKanGruplari.SelectedIndex = -1;
        }
        //
        //
        private void btnAskerlikDurumuSifirla_Click(object sender, EventArgs e)
        {
            cmbAskerlikDurumlari.SelectedIndex = -1;
        }
        //
        //
        private void btnMedeniDurumSifirla_Click(object sender, EventArgs e)
        {
            cmbMedeniDurumlar.SelectedIndex = -1;
        }
        //
        //
        private void btnEgitimDurumuSifirla_Click(object sender, EventArgs e)
        {
            cmbOgrenimDurumlari.SelectedIndex = -1;
        }
        //
        //
        private void btnSurucuBelgesiSifirla_Click(object sender, EventArgs e)
        {
            cmbSurucuBelgeSiniflari.SelectedIndex = -1;
        }
        //
        //
        private void btnFirmaSifirla_Click(object sender, EventArgs e)
        {
            cmbFirmalar.SelectedIndex = -1;
        }
        //
        //
        private void btnSSKFirma_Click(object sender, EventArgs e)
        {
            cmbSSKFirmalar.SelectedIndex = -1;
        }
        //
        //
        private void dtpEvlilikTarihi_EnabledChanged(object sender, EventArgs e)
        {
            if (dtpEvlilikTarihi.Enabled == true)
            {
                btnEvlilikTarihiDegistir.Text = "-";
            }
            else
            {
                btnEvlilikTarihiDegistir.Text = "+";
            }
        }
        //
        //
        private void dtpDogumTarihi_EnabledChanged(object sender, EventArgs e)
        {
            if (dtpDogumTarihi.Enabled == true)
            {
                btnDogumTarihiDegistir.Text = "-";
            }
            else
            {
                btnDogumTarihiDegistir.Text = "+";
            }
        }
        //
        //
        private void btnExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Dosyası|*.xlsx";
            //sfd.FileName = "Personeller " + DateTime.Now.ToShortDateString().Replace(".", "-");
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                System.Threading.Thread thr = new System.Threading.Thread(new System.Threading.ParameterizedThreadStart(ExceleAktar));
                thr.Start(sfd.FileName);
            }
        }
        //
        //
        private void ExceleAktar(object filename)
        {
            Microsoft.Office.Interop.Excel.Application ap = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook wb = ap.Workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
            Microsoft.Office.Interop.Excel.Worksheet ws = (Microsoft.Office.Interop.Excel.Worksheet)wb.Worksheets[1];

            ((Microsoft.Office.Interop.Excel.Range)ws.Columns["A", Type.Missing]).ColumnWidth = 4;
            ((Microsoft.Office.Interop.Excel.Range)ws.Columns["B", Type.Missing]).ColumnWidth = 36;
            ((Microsoft.Office.Interop.Excel.Range)ws.Columns["C", Type.Missing]).ColumnWidth = 25;
            ((Microsoft.Office.Interop.Excel.Range)ws.Columns["D", Type.Missing]).ColumnWidth = 25;
            ((Microsoft.Office.Interop.Excel.Range)ws.Columns["E", Type.Missing]).ColumnWidth = 52;
            ((Microsoft.Office.Interop.Excel.Range)ws.Columns["F", Type.Missing]).ColumnWidth = 10;
            ((Microsoft.Office.Interop.Excel.Range)ws.Columns["G", Type.Missing]).ColumnWidth = 10;
            ((Microsoft.Office.Interop.Excel.Range)ws.Columns["H", Type.Missing]).ColumnWidth = 10;
            ((Microsoft.Office.Interop.Excel.Range)ws.Columns["I", Type.Missing]).ColumnWidth = 8;
            ((Microsoft.Office.Interop.Excel.Range)ws.Columns["J", Type.Missing]).ColumnWidth = 12;
            ((Microsoft.Office.Interop.Excel.Range)ws.Columns["K", Type.Missing]).ColumnWidth = 11;
            ((Microsoft.Office.Interop.Excel.Range)ws.Columns["L", Type.Missing]).ColumnWidth = 11;
            ((Microsoft.Office.Interop.Excel.Range)ws.Columns["M", Type.Missing]).ColumnWidth = 9;
            ((Microsoft.Office.Interop.Excel.Range)ws.Columns["N", Type.Missing]).ColumnWidth = 18;
            ((Microsoft.Office.Interop.Excel.Range)ws.Columns["O", Type.Missing]).ColumnWidth = 13;
            ((Microsoft.Office.Interop.Excel.Range)ws.Columns["P", Type.Missing]).ColumnWidth = 11;
            ((Microsoft.Office.Interop.Excel.Range)ws.Columns["Q", Type.Missing]).ColumnWidth = 5;
            ((Microsoft.Office.Interop.Excel.Range)ws.Columns["R", Type.Missing]).ColumnWidth = 100;
            ((Microsoft.Office.Interop.Excel.Range)ws.Columns["S", Type.Missing]).ColumnWidth = 28;
            ((Microsoft.Office.Interop.Excel.Range)ws.Columns["T", Type.Missing]).ColumnWidth = 13;
            ((Microsoft.Office.Interop.Excel.Range)ws.Columns["U", Type.Missing]).ColumnWidth = 6;
            ((Microsoft.Office.Interop.Excel.Range)ws.Columns["V", Type.Missing]).ColumnWidth = 11;
            ((Microsoft.Office.Interop.Excel.Range)ws.Columns["W", Type.Missing]).ColumnWidth = 12;
            ((Microsoft.Office.Interop.Excel.Range)ws.Columns["X", Type.Missing]).ColumnWidth = 50;

            ws.Cells[1, 1] = "Kod";
            ws.Cells[1, 2] = "Ad";
            ws.Cells[1, 3] = "Bölüm";
            ws.Cells[1, 4] = "Ünvan";
            ws.Cells[1, 5] = "Görev Tanımı";
            ws.Cells[1, 6] = "Giriş Tarihi";
            ws.Cells[1, 7] = "Çıkış Tarihi";
            ws.Cells[1, 8] = "Durum";
            ws.Cells[1, 9] = "Cinsiyet";
            ws.Cells[1, 10] = "Doğum Tarihi";
            ws.Cells[1, 11] = "TC Kimlik No";
            ws.Cells[1, 12] = "SSK No";
            ws.Cells[1, 13] = "Kan Grubu";
            ws.Cells[1, 14] = "Askerlik Durumu";
            ws.Cells[1, 15] = "Medeni Durum";
            ws.Cells[1, 16] = "Evlilik Tarihi";
            ws.Cells[1, 17] = "Çocuk Sayısı";
            ws.Cells[1, 18] = "Adres";
            ws.Cells[1, 19] = "Telefon";
            ws.Cells[1, 20] = "Eğitim Durumu";
            ws.Cells[1, 21] = "Ehliyet";
            ws.Cells[1, 22] = "Firma Adı";
            ws.Cells[1, 23] = "SSK Firma Adı";
            ws.Cells[1, 24] = "Açıklama";

            progressBar1.Visible = true;
            progressBar1.Maximum = dgvPersoneller.Rows.Count;
            progressBar1.Value = 0;

            this.Enabled = false;
            for (int i = 0; i < dgvPersoneller.Rows.Count; i++)
            {
                progressBar1.Value = i;

                ws.Cells[i + 3, 1] = dgvPersoneller.Rows[i].Cells["clsintPerKod"].Value.ToString();
                ws.Cells[i + 3, 2] = dgvPersoneller.Rows[i].Cells["clstrPerAd"].Value.ToString();
                ws.Cells[i + 3, 3] = dgvPersoneller.Rows[i].Cells["clstrDepartman"].Value.ToString();
                ws.Cells[i + 3, 4] = dgvPersoneller.Rows[i].Cells["clstrGorev"].Value.ToString();
                ws.Cells[i + 3, 5] = dgvPersoneller.Rows[i].Cells["clstrGorevTanimi"].Value.ToString();

                if (dgvPersoneller.Rows[i].Cells["cldtPerGiris"].Value.ToString() != string.Empty)
                    ws.Cells[i + 3, 6] = Convert.ToDateTime(dgvPersoneller.Rows[i].Cells["cldtPerGiris"].Value).ToShortDateString();

                if (dgvPersoneller.Rows[i].Cells["cldtPerCikis"].Value.ToString() != string.Empty)
                    ws.Cells[i + 3, 7] = Convert.ToDateTime(dgvPersoneller.Rows[i].Cells["cldtPerCikis"].Value).ToShortDateString();

                ws.Cells[i + 3, 8] = "Çalışımıyor";
                if (Convert.ToBoolean(dgvPersoneller.Rows[i].Cells["clblPerDurum"].Value) == true)
                    ws.Cells[i + 3, 8] = "Çalışıyor";

                ws.Cells[i + 3, 9] = "Bayan";
                if (Convert.ToBoolean(dgvPersoneller.Rows[i].Cells["clblPerCinsiyet"].Value) == true)
                    ws.Cells[i + 3, 9] = "Erkek";

                if (dgvPersoneller.Rows[i].Cells["cldtPerDogumTarihi"].Value.ToString() != string.Empty)
                    ws.Cells[i + 3, 10] = Convert.ToDateTime(dgvPersoneller.Rows[i].Cells["cldtPerDogumTarihi"].Value).ToShortDateString();

                ws.Cells[i + 3, 11] = dgvPersoneller.Rows[i].Cells["clstrPerTCKimlikNo"].Value.ToString();
                ws.Cells[i + 3, 12] = dgvPersoneller.Rows[i].Cells["clstrPerSSKNo"].Value.ToString();
                ws.Cells[i + 3, 13] = dgvPersoneller.Rows[i].Cells["clstrKanGrubu"].Value.ToString();
                ws.Cells[i + 3, 14] = dgvPersoneller.Rows[i].Cells["clstrAskerlikDurumu"].Value.ToString();
                ws.Cells[i + 3, 15] = dgvPersoneller.Rows[i].Cells["clstrMedeniDurum"].Value.ToString();

                if (dgvPersoneller.Rows[i].Cells["cldtPerEvlilikTarihi"].Value.ToString() != string.Empty)
                    ws.Cells[i + 3, 16] = Convert.ToDateTime(dgvPersoneller.Rows[i].Cells["cldtPerEvlilikTarihi"].Value).ToShortDateString();

                ws.Cells[i + 3, 17] = dgvPersoneller.Rows[i].Cells["cltintPerCocukSayisi"].Value.ToString();
                ws.Cells[i + 3, 18] = dgvPersoneller.Rows[i].Cells["clstrPerAdres"].Value.ToString();
                ws.Cells[i + 3, 19] = dgvPersoneller.Rows[i].Cells["clstrPerTelefon"].Value.ToString();
                ws.Cells[i + 3, 20] = dgvPersoneller.Rows[i].Cells["clstrOgrenimDurumu"].Value.ToString();
                ws.Cells[i + 3, 21] = dgvPersoneller.Rows[i].Cells["clstrSurucuBelgeSinifi"].Value.ToString();
                ws.Cells[i + 3, 22] = dgvPersoneller.Rows[i].Cells["clstrPerFirmaAdi"].Value.ToString();
                ws.Cells[i + 3, 23] = dgvPersoneller.Rows[i].Cells["clstrPerSSKFirmaAdi"].Value.ToString();
                ws.Cells[i + 3, 24] = dgvPersoneller.Rows[i].Cells["clstrPerAciklama"].Value.ToString();
            }
            this.Enabled = true;

            progressBar1.Visible = false;

            ws.SaveAs(filename.ToString());
            wb.Close();
            ap.Quit();
        }
    }
}

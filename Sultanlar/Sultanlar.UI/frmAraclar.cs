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
using System.Reflection;

namespace Sultanlar.UI
{
    public partial class frmAraclar : Form
    {
        public frmAraclar()
        {
            InitializeComponent();
        }
        //
        //
        //
        //
        //
        internal static string seciliaraba = string.Empty;
        //
        //
        //
        //
        //
        private void frmAraclar_Load(object sender, EventArgs e)
        {
            ArabalariGetir();
            AT_ArabaMarkalari.GetObject(cmbMarkalar.Items, true);
            AT_YakitTurleri.GetObject(cmbYakitTurleri.Items, true);
            AT_ArabaTurleri.GetObject(cmbArabaTurleri.Items, true);
            Departmanlar.GetObject(cmbDepartmanlar.Items, true);
            AT_ArabaKimeAit.GetObject(cmbArabaKimeAit.Items, true);
            SigortaMuayeneTuslar();
        }
        //
        //
        //
        //
        //
        private void SigortaMuayeneTuslar()
        {
            DataTable dt = new DataTable();
            AT_Muayeneler.GetObjectToFinish(dt);
            btnMuayeneBitis.Text = "Muayene bitişi yaklaşan " + dt.Rows.Count + " araç var";

            dt = new DataTable();
            AT_Sigortalar.GetObjectToFinish(dt);
            btnSigortaBitis.Text = "Sigorta bitişi yaklaşan " + dt.Rows.Count + " araç var";

            dt = new DataTable();
            AT_Sigortalar.GetObjectFinished(dt);
            btnSigortaBiten.Text = "Sigortası biten " + dt.Rows.Count + " araç var";

            dt = new DataTable();
            AT_Muayeneler.GetObjectFinished(dt);
            btnMuayeneBiten.Text = "Muayenesi biten " + dt.Rows.Count + " araç var";
        }
        //
        //
        //
        //
        //
        private void ArabalariGetir()
        {
            AT_Arabalar.GetObject(lbArabalar.Items, true);
        }
        //
        //
        private void MuayeneleriGetir(int arabaid)
        {
            DataTable dt = new DataTable();
            AT_Muayeneler.GetObject(dt, arabaid);
            dgvMuayeneler.DataSource = dt;
        }
        //
        //
        private void SigortalariGetir(int arabaid)
        {
            DataTable dt = new DataTable();
            AT_Sigortalar.GetObject(dt, arabaid);
            dgvSigortalar.DataSource = dt;
        }
        //
        //
        private void Temizle()
        {
            lbArabalar.SelectedIndex = -1;

            txtArabaPlaka.Text = string.Empty;
            cmbMarkalar.SelectedIndex = -1;
            cmbYakitTurleri.SelectedIndex = -1;
            cmbArabaTurleri.SelectedIndex = -1;
            txtArabaModeli.Text = string.Empty;
            rbK2BelgeYok.Checked = true;
            cmbDepartmanlar.SelectedIndex = -1;
            rbLogoYok.Checked = true;
            cmbModelYillari.SelectedIndex = -1;
            cmbArabaKimeAit.SelectedIndex = -1;
            dtpKiraBaslangic.Enabled = false;
            dtpKiraBitis.Enabled = false;
        }
        //
        //
        //
        //
        //
        private void lbArabalar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbArabalar.SelectedIndex < 0)
            {
                return;
            }

            txtArabaPlaka.ReadOnly = true;

            btnArabaEkle.Enabled = false;
            btnMuayeneEkle.Enabled = true;
            dtpMuayeneBaslangic.Enabled = true;
            dtpMuayeneBitis.Enabled = true;
            btnSigortaEkle.Enabled = true;
            dtpSigortaBaslangic.Enabled = true;
            dtpSigortaBitis.Enabled = true;

            txtArabaPlaka.Text = lbArabalar.SelectedItem.ToString();

            for (int i = 0; i < cmbMarkalar.Items.Count; i++)
            {
                if (((AT_ArabaMarkalari)cmbMarkalar.Items[i]).pkArabaMarkaID == ((AT_Arabalar)lbArabalar.SelectedItem).sintArabaMarkaID)
                {
                    cmbMarkalar.SelectedIndex = i;
                    i = cmbMarkalar.Items.Count;
                }
            }

            for (int i = 0; i < cmbYakitTurleri.Items.Count; i++)
            {
                if (((AT_YakitTurleri)cmbYakitTurleri.Items[i]).pkYakitTuruID == ((AT_Arabalar)lbArabalar.SelectedItem).tintYakitTuruID)
                {
                    cmbYakitTurleri.SelectedIndex = i;
                    i = cmbYakitTurleri.Items.Count;
                }
            }

            for (int i = 0; i < cmbArabaTurleri.Items.Count; i++)
            {
                if (((AT_ArabaTurleri)cmbArabaTurleri.Items[i]).pkArabaTuruID == ((AT_Arabalar)lbArabalar.SelectedItem).tintArabaTuruID)
                {
                    cmbArabaTurleri.SelectedIndex = i;
                    i = cmbArabaTurleri.Items.Count;
                }
            }

            for (int i = 0; i < cmbDepartmanlar.Items.Count; i++)
            {
                if (((Departmanlar)cmbDepartmanlar.Items[i]).pkDepartmanID == ((AT_Arabalar)lbArabalar.SelectedItem).tintDepartmanID)
                {
                    cmbDepartmanlar.SelectedIndex = i;
                    i = cmbDepartmanlar.Items.Count;
                }
            }

            for (int i = 0; i < cmbArabaKimeAit.Items.Count; i++)
            {
                if (((AT_ArabaKimeAit)cmbArabaKimeAit.Items[i]).pkArabaKimeAitID == ((AT_Arabalar)lbArabalar.SelectedItem).tintArabaKimeAitID)
                {
                    cmbArabaKimeAit.SelectedIndex = i;
                    i = cmbArabaKimeAit.Items.Count;
                }
            }

            txtArabaModeli.Text = ((AT_Arabalar)lbArabalar.SelectedItem).strArabaModeli;
            rbK2BelgeVar.Checked = ((AT_Arabalar)lbArabalar.SelectedItem).blArabaK2Belge;
            rbK2BelgeYok.Checked = !((AT_Arabalar)lbArabalar.SelectedItem).blArabaK2Belge;
            rbLogoVar.Checked = ((AT_Arabalar)lbArabalar.SelectedItem).blArabaLogolu;
            rbLogoYok.Checked = !((AT_Arabalar)lbArabalar.SelectedItem).blArabaLogolu;
            cmbModelYillari.Text = ((AT_Arabalar)lbArabalar.SelectedItem).sintArabaModelYili.ToString();

            if (((AT_Arabalar)lbArabalar.SelectedItem).dtKiraBaslangic != string.Empty)
            {
                dtpKiraBaslangic.Enabled = true;
                dtpKiraBaslangic.Value = Convert.ToDateTime(((AT_Arabalar)lbArabalar.SelectedItem).dtKiraBaslangic);
            }

            if (((AT_Arabalar)lbArabalar.SelectedItem).dtKiraBitis != string.Empty)
            {
                dtpKiraBitis.Enabled = true;
                dtpKiraBitis.Value = Convert.ToDateTime(((AT_Arabalar)lbArabalar.SelectedItem).dtKiraBitis);
            }

            MuayeneleriGetir(((AT_Arabalar)lbArabalar.SelectedItem).pkArabaID);
            SigortalariGetir(((AT_Arabalar)lbArabalar.SelectedItem).pkArabaID);
        }
        //
        //
        private void btnArabaEkle_Click(object sender, EventArgs e)
        {
            if (cmbArabaTurleri.SelectedIndex < 0 || cmbDepartmanlar.SelectedIndex < 0 || cmbYakitTurleri.SelectedIndex < 0 || cmbMarkalar.SelectedIndex < 0 ||
                cmbModelYillari.SelectedIndex < 0)
            {
                MessageBox.Show("Eksik seçim var.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            AT_Arabalar araba;

            if (((AT_ArabaKimeAit)cmbArabaKimeAit.SelectedItem).pkArabaKimeAitID == 1) // 1 numaralı ID'de kira var
            {
                araba = new AT_Arabalar(txtArabaPlaka.Text, ((AT_YakitTurleri)cmbYakitTurleri.SelectedItem).pkYakitTuruID,
                ((AT_ArabaMarkalari)cmbMarkalar.SelectedItem).pkArabaMarkaID, txtArabaModeli.Text, Convert.ToInt16(cmbModelYillari.SelectedItem),
                ((AT_ArabaTurleri)cmbArabaTurleri.SelectedItem).pkArabaTuruID, rbK2BelgeVar.Checked, ((Departmanlar)cmbDepartmanlar.SelectedItem).pkDepartmanID,
                rbLogoVar.Checked, ((AT_ArabaKimeAit)cmbArabaKimeAit.SelectedItem).pkArabaKimeAitID, dtpKiraBaslangic.Value.ToShortDateString(),
                dtpKiraBitis.Value.ToShortDateString(), false);
            }
            else
            {
                araba = new AT_Arabalar(txtArabaPlaka.Text, ((AT_YakitTurleri)cmbYakitTurleri.SelectedItem).pkYakitTuruID,
                ((AT_ArabaMarkalari)cmbMarkalar.SelectedItem).pkArabaMarkaID, txtArabaModeli.Text, Convert.ToInt16(cmbModelYillari.SelectedItem),
                ((AT_ArabaTurleri)cmbArabaTurleri.SelectedItem).pkArabaTuruID, rbK2BelgeVar.Checked, ((Departmanlar)cmbDepartmanlar.SelectedItem).pkDepartmanID,
                rbLogoVar.Checked, ((AT_ArabaKimeAit)cmbArabaKimeAit.SelectedItem).pkArabaKimeAitID, string.Empty, string.Empty, false);
            }


            
            araba.DoInsert();
            ArabalariGetir();
            btnArabaTemizle.PerformClick();
        }
        //
        //
        private void btnArabaGuncelle_Click(object sender, EventArgs e)
        {
            if (lbArabalar.SelectedIndex < 0)
            {
                MessageBox.Show("Bir araba seçilmedi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int index = lbArabalar.SelectedIndex;

            AT_Arabalar araba = (AT_Arabalar)lbArabalar.SelectedItem;

            araba.strArabaPlaka = txtArabaPlaka.Text;
            araba.tintYakitTuruID = ((AT_YakitTurleri)cmbYakitTurleri.SelectedItem).pkYakitTuruID;
            araba.sintArabaMarkaID = ((AT_ArabaMarkalari)cmbMarkalar.SelectedItem).pkArabaMarkaID;
            araba.tintArabaTuruID = ((AT_ArabaTurleri)cmbArabaTurleri.SelectedItem).pkArabaTuruID;
            araba.sintArabaModelYili = Convert.ToInt16(cmbModelYillari.SelectedItem);
            araba.strArabaModeli = txtArabaModeli.Text;
            araba.blArabaK2Belge = rbK2BelgeVar.Checked;
            araba.tintDepartmanID = ((Departmanlar)cmbDepartmanlar.SelectedItem).pkDepartmanID;
            araba.blArabaLogolu = rbLogoVar.Checked;

            araba.DoUpdate();
            ArabalariGetir();
            lbArabalar.SelectedIndex = index;
            //btnArabaTemizle.PerformClick();
        }
        //
        //
        private void btnArabaSil_Click(object sender, EventArgs e)
        {
            if (lbArabalar.SelectedIndex < 0)
            {
                MessageBox.Show("Bir araba seçilmedi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            AT_Arabalar araba = (AT_Arabalar)lbArabalar.SelectedItem;
            araba.DoDelete();
        }
        //
        //
        private void btnArabaTemizle_Click(object sender, EventArgs e)
        {
            Temizle();

            txtArabaPlaka.ReadOnly = false;

            btnArabaEkle.Enabled = true;
            btnMuayeneEkle.Enabled = false;
            dtpMuayeneBaslangic.Enabled = false;
            dtpMuayeneBitis.Enabled = false;
            btnSigortaEkle.Enabled = false;
            dtpSigortaBaslangic.Enabled = false;
            dtpSigortaBitis.Enabled = false;

            int muayenesayisi = dgvMuayeneler.Rows.Count;
            int sigortasayisi = dgvSigortalar.Rows.Count;
            for (int i = 0; i < muayenesayisi; i++)
            {
                dgvMuayeneler.Rows.RemoveAt(0);
            }
            for (int i = 0; i < sigortasayisi; i++)
            {
                dgvSigortalar.Rows.RemoveAt(0);
            }
        }
        //
        //
        private void btnMuayeneEkle_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Muayene başlangıç: " + dtpMuayeneBaslangic.Value.ToShortDateString() + "\r\nMuayene bitiş: " + dtpMuayeneBitis.Value.ToShortDateString() 
                + "\r\n\r\nEmin misiniz?", "Ekleme", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
            {
                AT_Muayeneler muayene = new AT_Muayeneler(((AT_Arabalar)lbArabalar.SelectedItem).pkArabaID, dtpMuayeneBaslangic.Value.ToShortDateString(),
                dtpMuayeneBitis.Value.ToShortDateString());
                muayene.DoInsert();

                MuayeneleriGetir(((AT_Arabalar)lbArabalar.SelectedItem).pkArabaID);

                SigortaMuayeneTuslar();
            }
        }
        //
        //
        private void btnSigortaEkle_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Sigorta başlangıç: " + dtpSigortaBaslangic.Value.ToShortDateString() + "\r\nSigorta bitiş: " + dtpSigortaBitis.Value.ToShortDateString() 
                + "\r\n\r\nEmin misiniz?", "Ekleme", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
            {
                AT_Sigortalar sigorta = new AT_Sigortalar(((AT_Arabalar)lbArabalar.SelectedItem).pkArabaID, dtpSigortaBaslangic.Value.ToShortDateString(),
                    dtpSigortaBitis.Value.ToShortDateString());
                sigorta.DoInsert();

                SigortalariGetir(((AT_Arabalar)lbArabalar.SelectedItem).pkArabaID);

                SigortaMuayeneTuslar();
            }
        }
        //
        //
        private void btnArabaEkle_EnabledChanged(object sender, EventArgs e)
        {
            if (btnArabaEkle.Enabled == true)
            {
                btnArabaGuncelle.Enabled = false;
                btnArabaSil.Enabled = false;
            }
            else
            {
                btnArabaGuncelle.Enabled = true;
                btnArabaSil.Enabled = true;
            }
        }
        //
        //
        private void btnSigortaBitis_Click(object sender, EventArgs e)
        {
            frmMuayeneSigortaKontrol frm = new frmMuayeneSigortaKontrol(false, false);
            frm.ShowDialog();

            if (seciliaraba != string.Empty)
            {
                for (int i = 0; i < lbArabalar.Items.Count; i++)
                {
                    if (((AT_Arabalar)lbArabalar.Items[i]).strArabaPlaka == seciliaraba)
                    {
                        lbArabalar.SelectedIndex = i;
                        seciliaraba = string.Empty;
                        return;
                    }
                }
            }
        }
        //
        //
        private void btnMuayeneBitis_Click(object sender, EventArgs e)
        {
            frmMuayeneSigortaKontrol frm = new frmMuayeneSigortaKontrol(true, false);
            frm.ShowDialog();

            if (seciliaraba != string.Empty)
            {
                for (int i = 0; i < lbArabalar.Items.Count; i++)
                {
                    if (((AT_Arabalar)lbArabalar.Items[i]).strArabaPlaka == seciliaraba)
                    {
                        lbArabalar.SelectedIndex = i;
                        seciliaraba = string.Empty;
                        return;
                    }
                }
            }
        }
        //
        //
        private void btnSigortaBiten_Click(object sender, EventArgs e)
        {
            frmMuayeneSigortaKontrol frm = new frmMuayeneSigortaKontrol(false, true);
            frm.ShowDialog();

            if (seciliaraba != string.Empty)
            {
                for (int i = 0; i < lbArabalar.Items.Count; i++)
                {
                    if (((AT_Arabalar)lbArabalar.Items[i]).strArabaPlaka == seciliaraba)
                    {
                        lbArabalar.SelectedIndex = i;
                        seciliaraba = string.Empty;
                        return;
                    }
                }
            }
        }
        //
        //
        private void btnMuayeneBiten_Click(object sender, EventArgs e)
        {
            frmMuayeneSigortaKontrol frm = new frmMuayeneSigortaKontrol(true, true);
            frm.ShowDialog();

            if (seciliaraba != string.Empty)
            {
                for (int i = 0; i < lbArabalar.Items.Count; i++)
                {
                    if (((AT_Arabalar)lbArabalar.Items[i]).strArabaPlaka == seciliaraba)
                    {
                        lbArabalar.SelectedIndex = i;
                        seciliaraba = string.Empty;
                        return;
                    }
                }
            }
        }
        //
        //
        private void cmbArabaKimeAit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbArabaKimeAit.SelectedIndex > -1)
            {
                if (((AT_ArabaKimeAit)cmbArabaKimeAit.SelectedItem).pkArabaKimeAitID == 1) // 1 numaralı ID'de kira var
                {
                    dtpKiraBaslangic.Enabled = true;
                    dtpKiraBitis.Enabled = true;
                }
                else
                {
                    dtpKiraBaslangic.Enabled = false;
                    dtpKiraBitis.Enabled = false;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Dosyası|*.xlsx";
            //sfd.FileName = "Araç Kartı " + DateTime.Now.ToShortDateString().Replace(".", "-");
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                Microsoft.Office.Interop.Excel.Application ap = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel.Workbook wb = ap.Workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
                Microsoft.Office.Interop.Excel.Worksheet ws = (Microsoft.Office.Interop.Excel.Worksheet)wb.Worksheets[1];

                ((Microsoft.Office.Interop.Excel.Range)ws.Columns["A", Type.Missing]).ColumnWidth = 13;
                ((Microsoft.Office.Interop.Excel.Range)ws.Columns["B", Type.Missing]).ColumnWidth = 10;
                ((Microsoft.Office.Interop.Excel.Range)ws.Columns["C", Type.Missing]).ColumnWidth = 14;
                ((Microsoft.Office.Interop.Excel.Range)ws.Columns["D", Type.Missing]).ColumnWidth = 14;
                ((Microsoft.Office.Interop.Excel.Range)ws.Columns["E", Type.Missing]).ColumnWidth = 14;
                ((Microsoft.Office.Interop.Excel.Range)ws.Columns["F", Type.Missing]).ColumnWidth = 10;
                ((Microsoft.Office.Interop.Excel.Range)ws.Columns["G", Type.Missing]).ColumnWidth = 8;
                ((Microsoft.Office.Interop.Excel.Range)ws.Columns["H", Type.Missing]).ColumnWidth = 8;
                ((Microsoft.Office.Interop.Excel.Range)ws.Columns["I", Type.Missing]).ColumnWidth = 10;
                ((Microsoft.Office.Interop.Excel.Range)ws.Columns["J", Type.Missing]).ColumnWidth = 14;
                ((Microsoft.Office.Interop.Excel.Range)ws.Columns["K", Type.Missing]).ColumnWidth = 14;
                ((Microsoft.Office.Interop.Excel.Range)ws.Columns["L", Type.Missing]).ColumnWidth = 14;
                ((Microsoft.Office.Interop.Excel.Range)ws.Columns["M", Type.Missing]).ColumnWidth = 18;
                ((Microsoft.Office.Interop.Excel.Range)ws.Columns["N", Type.Missing]).ColumnWidth = 18;
                ((Microsoft.Office.Interop.Excel.Range)ws.Columns["O", Type.Missing]).ColumnWidth = 18;
                ((Microsoft.Office.Interop.Excel.Range)ws.Columns["P", Type.Missing]).ColumnWidth = 18;
                ws.Cells[1, 1] = "Araç Plakaları";
                ws.Cells[1, 2] = "Tür";
                ws.Cells[1, 3] = "Marka";
                ws.Cells[1, 4] = "Model";
                ws.Cells[1, 5] = "Departman";
                ws.Cells[1, 6] = "Yakıt Türü";
                ws.Cells[1, 7] = "K2 Belge";
                ws.Cells[1, 8] = "Logo";
                ws.Cells[1, 9] = "Model Yılı";
                ws.Cells[1, 10] = "Kime Ait";
                ws.Cells[1, 11] = "Kira Başlangıcı";
                ws.Cells[1, 12] = "Kira Bitişi";
                ws.Cells[1, 13] = "Muayene Başlangıcı";
                ws.Cells[1, 14] = "Muayene Bitişi";
                ws.Cells[1, 15] = "Sigorta Başlangıcı";
                ws.Cells[1, 16] = "Sigorta Bitişi";

                this.Enabled = false;
                for (int i = 0; i < lbArabalar.Items.Count; i++)
                {
                    lbArabalar.SelectedIndex = i;
                    ws.Cells[i + 3, 1] = lbArabalar.Items[i].ToString();
                    ws.Cells[i + 3, 2] = cmbArabaTurleri.Text;
                    ws.Cells[i + 3, 3] = cmbMarkalar.Text;
                    ws.Cells[i + 3, 4] = txtArabaModeli.Text;
                    ws.Cells[i + 3, 5] = cmbDepartmanlar.Text;
                    ws.Cells[i + 3, 6] = cmbYakitTurleri.Text;
                    ws.Cells[i + 3, 7] = "Var";
                    ws.Cells[i + 3, 8] = "Var";
                    ws.Cells[i + 3, 9] = cmbModelYillari.Text;
                    ws.Cells[i + 3, 10] = cmbArabaKimeAit.Text;

                    if (dtpKiraBaslangic.Value.ToShortDateString() != DateTime.Now.ToShortDateString())
                        ws.Cells[i + 3, 11] = dtpKiraBaslangic.Value.ToShortDateString();
                    if (dtpKiraBitis.Value.ToShortDateString() != DateTime.Now.ToShortDateString())
                        ws.Cells[i + 3, 12] = dtpKiraBitis.Value.ToShortDateString();

                    if (rbK2BelgeYok.Checked)
                        ws.Cells[i + 3, 7] = "Yok";
                    if (rbLogoYok.Checked)
                        ws.Cells[i + 3, 8] = "Yok";

                    if (dgvMuayeneler.Rows.Count != 0)
                        ws.Cells[i + 3, 13] = Convert.ToDateTime(dgvMuayeneler.Rows[0].Cells[0].Value).ToShortDateString();
                    if (dgvMuayeneler.Rows.Count != 0)
                        ws.Cells[i + 3, 14] = Convert.ToDateTime(dgvMuayeneler.Rows[0].Cells[1].Value).ToShortDateString();

                    if (dgvSigortalar.Rows.Count != 0)
                        ws.Cells[i + 3, 15] = Convert.ToDateTime(dgvSigortalar.Rows[0].Cells[0].Value).ToShortDateString();
                    if (dgvMuayeneler.Rows.Count != 0)
                        ws.Cells[i + 3, 16] = Convert.ToDateTime(dgvSigortalar.Rows[0].Cells[1].Value).ToShortDateString();
                }
                this.Enabled = true;

                lbArabalar.SelectedIndex = -1;


                ws.SaveAs(sfd.FileName);
                wb.Close();
                ap.Quit();
            }
        }
    }
}

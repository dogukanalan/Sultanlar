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
    public partial class frmAracGiderleri : Form
    {
        public frmAracGiderleri()
        {
            InitializeComponent();
        }
        //
        //
        char ayrac;
        //
        //
        private void frmAracGiderleri_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            ayrac = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0];
            GetObjects();
            btnTemizle.PerformClick();
        }
        //
        //
        private void GetObjects()
        {
            AT_Arabalar.GetObject(lbArabalar.Items, true);
            DataTable dt = new DataTable();
            AT_AracGiderleri.GetObject(dt);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["flYakit"].ToString() == "0")
                    dt.Rows[i]["flYakit"] = DBNull.Value;
                if (dt.Rows[i]["tintKDV"].ToString() == "0")
                    dt.Rows[i]["tintKDV"] = DBNull.Value;
                if (dt.Rows[i]["tintVade"].ToString() == "0")
                    dt.Rows[i]["tintVade"] = DBNull.Value;
            }

            dgvAracGiderleri.DataSource = dt;
            dgvAracGiderleri.ClearSelection();
            AT_AracFirmalari.GetObject(cmbFirmalar.Items, true);
        }
        //
        //
        private void Temizle()
        {
            cmbFirmalar.SelectedIndex = -1;
            dtpTarih.Value = DateTime.Now;
            txtYakit.Text = string.Empty;
            txtFaturaNo.Text = string.Empty;
            txtFaturaDetayi.Text = string.Empty;
            txtTutar.Text = string.Empty;
            txtKDV.Text = "18";
            txtToplamTutar.Text = string.Empty;
            txtVade.Text = string.Empty;
            dtpOdemeTarihi.Value = DateTime.Now;
        }
        //
        //
        private void ExceleAktar(object filename)
        {
            Microsoft.Office.Interop.Excel.Application ap = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook wb = ap.Workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
            Microsoft.Office.Interop.Excel.Worksheet ws = (Microsoft.Office.Interop.Excel.Worksheet)wb.Worksheets[1];

            ((Microsoft.Office.Interop.Excel.Range)ws.Columns["A", Type.Missing]).ColumnWidth = 4;
            ((Microsoft.Office.Interop.Excel.Range)ws.Columns["B", Type.Missing]).ColumnWidth = 10;
            ((Microsoft.Office.Interop.Excel.Range)ws.Columns["C", Type.Missing]).ColumnWidth = 30;
            ((Microsoft.Office.Interop.Excel.Range)ws.Columns["D", Type.Missing]).ColumnWidth = 10;
            ((Microsoft.Office.Interop.Excel.Range)ws.Columns["E", Type.Missing]).ColumnWidth = 10;
            ((Microsoft.Office.Interop.Excel.Range)ws.Columns["F", Type.Missing]).ColumnWidth = 9;
            ((Microsoft.Office.Interop.Excel.Range)ws.Columns["G", Type.Missing]).ColumnWidth = 100;
            ((Microsoft.Office.Interop.Excel.Range)ws.Columns["H", Type.Missing]).ColumnWidth = 5;
            ((Microsoft.Office.Interop.Excel.Range)ws.Columns["I", Type.Missing]).ColumnWidth = 4;
            ((Microsoft.Office.Interop.Excel.Range)ws.Columns["J", Type.Missing]).ColumnWidth = 7;
            ((Microsoft.Office.Interop.Excel.Range)ws.Columns["K", Type.Missing]).ColumnWidth = 5;
            ((Microsoft.Office.Interop.Excel.Range)ws.Columns["L", Type.Missing]).ColumnWidth = 12;

            ws.Cells[1, 1] = "ID";
            ws.Cells[1, 2] = "Araç";
            ws.Cells[1, 3] = "Firma";
            ws.Cells[1, 4] = "Tarih";
            ws.Cells[1, 5] = "Yakıt";
            ws.Cells[1, 6] = "Fatura No";
            ws.Cells[1, 7] = "Fatura Detayı";
            ws.Cells[1, 8] = "Tutar";
            ws.Cells[1, 9] = "KDV";
            ws.Cells[1, 10] = "T. Tutar";
            ws.Cells[1, 11] = "Vade";
            ws.Cells[1, 12] = "Ödeme Tarihi";

            progressBar1.Visible = true;
            progressBar1.Maximum = dgvAracGiderleri.Rows.Count;
            progressBar1.Value = 0;

            this.Enabled = false;
            for (int i = 0; i < dgvAracGiderleri.Rows.Count; i++)
            {
                progressBar1.Value = i;

                ws.Cells[i + 3, 1] = dgvAracGiderleri.Rows[i].Cells["clpkAracGiderID"].Value.ToString();
                ws.Cells[i + 3, 2] = dgvAracGiderleri.Rows[i].Cells["clstrArabaPlaka"].Value.ToString();
                ws.Cells[i + 3, 3] = dgvAracGiderleri.Rows[i].Cells["clstrAracFirma"].Value.ToString();
                if (dgvAracGiderleri.Rows[i].Cells["cldtTarih"].Value.ToString() != string.Empty)
                    ws.Cells[i + 3, 4] = Convert.ToDateTime(dgvAracGiderleri.Rows[i].Cells["cldtTarih"].Value).ToShortDateString();
                ws.Cells[i + 3, 5] = dgvAracGiderleri.Rows[i].Cells["clflYakit"].Value.ToString();
                ws.Cells[i + 3, 6] = dgvAracGiderleri.Rows[i].Cells["clstrFaturaNo"].Value.ToString();
                ws.Cells[i + 3, 7] = dgvAracGiderleri.Rows[i].Cells["clstrFaturaDetayi"].Value.ToString();
                if (dgvAracGiderleri.Rows[i].Cells["clflTutar"].Value.ToString().IndexOf(",") > 0)
                    ws.Cells[i + 3, 8] = dgvAracGiderleri.Rows[i].Cells["clflTutar"].Value.ToString().Replace(",", ".");
                else
                    ws.Cells[i + 3, 8] = dgvAracGiderleri.Rows[i].Cells["clflTutar"].Value.ToString();
                ws.Cells[i + 3, 9] = dgvAracGiderleri.Rows[i].Cells["cltintKDV"].Value.ToString();
                if (dgvAracGiderleri.Rows[i].Cells["clflToplamTutar"].Value.ToString().IndexOf(",") > 0)
                    ws.Cells[i + 3, 10] = dgvAracGiderleri.Rows[i].Cells["clflToplamTutar"].Value.ToString().Replace(",", ".");
                else
                    ws.Cells[i + 3, 10] = dgvAracGiderleri.Rows[i].Cells["clflToplamTutar"].Value.ToString();
                ws.Cells[i + 3, 11] = dgvAracGiderleri.Rows[i].Cells["cltintVade"].Value.ToString();
                if (dgvAracGiderleri.Rows[i].Cells["cldtOdemeTarihi"].Value.ToString() != string.Empty)
                    ws.Cells[i + 3, 12] = Convert.ToDateTime(dgvAracGiderleri.Rows[i].Cells["cldtOdemeTarihi"].Value).ToShortDateString();
            }
            this.Enabled = true;

            progressBar1.Visible = false;

            ws.SaveAs(filename.ToString());
            wb.Close();
            ap.Quit();
        }
        //
        //
        private void EkleSilGuncelle(bool secili)
        {
            btnEkle.Enabled = !secili;
            btnGuncelle.Enabled = secili;
            btnSil.Enabled = secili;
        }
        //
        //
        private void lbArabalar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbArabalar.SelectedIndex < 0)
                return;

            DataTable dt = new DataTable();
            AT_AracGiderleri.GetObjectByArabaID(dt, ((AT_Arabalar)lbArabalar.SelectedItem).pkArabaID);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["flYakit"].ToString() == "0")
                    dt.Rows[i]["flYakit"] = DBNull.Value;
                if (dt.Rows[i]["tintKDV"].ToString() == "0")
                    dt.Rows[i]["tintKDV"] = DBNull.Value;
                if (dt.Rows[i]["tintVade"].ToString() == "0")
                    dt.Rows[i]["tintVade"] = DBNull.Value;
            }

            dgvAracGiderleri.DataSource = dt;
            dgvAracGiderleri.ClearSelection();
            Temizle();
        }
        //
        //
        private void btnTemizle_Click(object sender, EventArgs e)
        {
            GetObjects();
            Temizle();
        }
        //
        //
        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (lbArabalar.SelectedIndex > -1)
            {
                byte FirmaID = 0;
                double yakit = 0;
                double tutar = 0;
                double toplamtutar = 0;
                byte vade = 0;
                byte KDV = 0;
                if (cmbFirmalar.SelectedIndex > -1)
                    FirmaID = ((AT_AracFirmalari)cmbFirmalar.SelectedItem).pkAracFirmaID;
                if (txtYakit.Text.Trim() != string.Empty)
                    yakit = Convert.ToDouble(txtYakit.Text.Trim().Replace(".", ","));
                if (txtTutar.Text.Trim() != string.Empty)
                    tutar = Convert.ToDouble(txtTutar.Text.Trim().Replace(".", ","));
                if (txtToplamTutar.Text.Trim() != string.Empty)
                    toplamtutar = Convert.ToDouble(txtToplamTutar.Text.Trim().Replace(".", ","));
                if (txtVade.Text.Trim() != string.Empty)
                    vade = Convert.ToByte(txtVade.Text.Trim());
                if (txtKDV.Text.Trim() != string.Empty)
                    KDV = Convert.ToByte(txtKDV.Text.Trim());

                try
                {
                    AT_AracGiderleri ag = new AT_AracGiderleri(((AT_Arabalar)lbArabalar.SelectedItem).pkArabaID, FirmaID, dtpTarih.Value.ToShortDateString(),
                        yakit, txtFaturaNo.Text.Trim().ToUpper(), txtFaturaDetayi.Text.Trim().ToUpper(), tutar, KDV,
                        toplamtutar, vade, dtpOdemeTarihi.Value.ToShortDateString());

                    ag.DoInsert();

                    btnTemizle.PerformClick();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Girilen değerlerde bir hata var!\r\n\r\nAyrıntılı hata bilgisi: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Bir araba seçilmedi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        //
        //
        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (dgvAracGiderleri.SelectedRows.Count == 0)
            {
                return;
            }

            ListBox lb = new ListBox();
            AT_AracGiderleri.GetObjectByID(lb.Items, Convert.ToInt32(dgvAracGiderleri.SelectedRows[0].Cells["clpkAracGiderID"].Value.ToString()));
            AT_AracGiderleri ag = (AT_AracGiderleri)lb.Items[0];

            byte FirmaID = 0;
            double yakit = 0;
            double tutar = 0;
            double toplamtutar = 0;
            byte vade = 0;
            byte KDV = 0;
            if (cmbFirmalar.SelectedIndex > -1)
                FirmaID = ((AT_AracFirmalari)cmbFirmalar.SelectedItem).pkAracFirmaID;
            if (txtYakit.Text.Trim() != string.Empty)
                yakit = Convert.ToDouble(txtYakit.Text.Trim().Replace(".", ","));
            if (txtTutar.Text.Trim() != string.Empty)
                tutar = Convert.ToDouble(txtTutar.Text.Trim().Replace(".", ","));
            if (txtToplamTutar.Text.Trim() != string.Empty)
                toplamtutar = Convert.ToDouble(txtToplamTutar.Text.Trim().Replace(".", ","));
            if (txtVade.Text.Trim() != string.Empty)
                vade = Convert.ToByte(txtVade.Text.Trim());
            if (txtKDV.Text.Trim() != string.Empty)
                KDV = Convert.ToByte(txtKDV.Text.Trim());

            ag.tintAracFirmaID = FirmaID;

            ag.dtTarih = dtpTarih.Value.ToShortDateString();
            dgvAracGiderleri.SelectedRows[0].Cells["cldtTarih"].Value = dtpTarih.Value.ToShortDateString();

            ag.flYakit = yakit;
            if (yakit == 0)
                dgvAracGiderleri.SelectedRows[0].Cells["clflYakit"].Value = DBNull.Value;
            else
                dgvAracGiderleri.SelectedRows[0].Cells["clflYakit"].Value = yakit;

            ag.strFaturaNo = txtFaturaNo.Text.Trim().ToUpper();
            dgvAracGiderleri.SelectedRows[0].Cells["clstrFaturaNo"].Value = txtFaturaNo.Text.Trim().ToUpper();

            ag.strFaturaDetayi = txtFaturaDetayi.Text.Trim().ToUpper();
            dgvAracGiderleri.SelectedRows[0].Cells["clstrFaturaDetayi"].Value = txtFaturaDetayi.Text.Trim().ToUpper();

            ag.flTutar = tutar;
            if (tutar == 0)
                dgvAracGiderleri.SelectedRows[0].Cells["clflTutar"].Value = DBNull.Value;
            else
                dgvAracGiderleri.SelectedRows[0].Cells["clflTutar"].Value = tutar;

            ag.tintKDV = Convert.ToByte(txtKDV.Text.Trim());
            if (KDV == 0)
                dgvAracGiderleri.SelectedRows[0].Cells["cltintKDV"].Value = DBNull.Value;
            else
                dgvAracGiderleri.SelectedRows[0].Cells["cltintKDV"].Value = KDV;

            ag.flToplamTutar = toplamtutar;
            if (toplamtutar == 0)
                dgvAracGiderleri.SelectedRows[0].Cells["clflToplamTutar"].Value = DBNull.Value;
            else
                dgvAracGiderleri.SelectedRows[0].Cells["clflToplamTutar"].Value = toplamtutar;

            ag.tintVade = vade;
            if (vade == 0)
                dgvAracGiderleri.SelectedRows[0].Cells["cltintVade"].Value = DBNull.Value;
            else
                dgvAracGiderleri.SelectedRows[0].Cells["cltintVade"].Value = vade;

            ag.dtOdemeTarihi = dtpOdemeTarihi.Value.ToShortDateString();
            dgvAracGiderleri.SelectedRows[0].Cells["cldtOdemeTarihi"].Value = dtpOdemeTarihi.Value.ToShortDateString();

            ag.DoUpdate();
        }
        //
        //
        private void btnSil_Click(object sender, EventArgs e)
        {
            if (dgvAracGiderleri.SelectedRows.Count == 0)
            {
                return;
            }

            if (MessageBox.Show("Bir kayıt silinecek. Emin misiniz?", "Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
            {
                ListBox lb = new ListBox();
                AT_AracGiderleri.GetObjectByID(lb.Items, Convert.ToInt32(dgvAracGiderleri.SelectedRows[0].Cells["clpkAracGiderID"].Value.ToString()));
                AT_AracGiderleri ag = (AT_AracGiderleri)lb.Items[0];

                ag.DoDelete();

                btnTemizle.PerformClick();
            }
        }
        //
        //
        private void frmAracGiderleri_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                dgvAracGiderleri.Columns["clstrFaturaDetayi"].Width = dgvAracGiderleri.Width - 750;
            }
            else if (this.WindowState == FormWindowState.Normal)
            {
                dgvAracGiderleri.Columns["clstrFaturaDetayi"].Width = dgvAracGiderleri.Width - 750;
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
        private void dgvAracGiderleri_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            Temizle();

            for (int i = 0; i < cmbFirmalar.Items.Count; i++)
                if (((AT_AracFirmalari)cmbFirmalar.Items[i]).strAracFirma == dgvAracGiderleri.Rows[e.RowIndex].Cells["clstrAracFirma"].Value.ToString())
                    cmbFirmalar.SelectedIndex = i;

            if (dgvAracGiderleri.Rows[e.RowIndex].Cells["cldtTarih"].Value.ToString() != string.Empty)
                dtpTarih.Value = Convert.ToDateTime(dgvAracGiderleri.Rows[e.RowIndex].Cells["cldtTarih"].Value);

            txtYakit.Text = dgvAracGiderleri.Rows[e.RowIndex].Cells["clflYakit"].Value.ToString();
            txtFaturaNo.Text = dgvAracGiderleri.Rows[e.RowIndex].Cells["clstrFaturaNo"].Value.ToString();
            txtFaturaDetayi.Text = dgvAracGiderleri.Rows[e.RowIndex].Cells["clstrFaturaDetayi"].Value.ToString();
            txtTutar.Text = dgvAracGiderleri.Rows[e.RowIndex].Cells["clflTutar"].Value.ToString();
            txtKDV.Text = dgvAracGiderleri.Rows[e.RowIndex].Cells["cltintKDV"].Value.ToString();
            txtToplamTutar.Text = dgvAracGiderleri.Rows[e.RowIndex].Cells["clflToplamTutar"].Value.ToString();
            txtVade.Text = dgvAracGiderleri.Rows[e.RowIndex].Cells["cltintVade"].Value.ToString();

            if (dgvAracGiderleri.Rows[e.RowIndex].Cells["cldtOdemeTarihi"].Value.ToString() != string.Empty)
                dtpOdemeTarihi.Value = Convert.ToDateTime(dgvAracGiderleri.Rows[e.RowIndex].Cells["cldtOdemeTarihi"].Value);
        }
        //
        //
        private void dgvAracGiderleri_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvAracGiderleri.SelectedRows.Count > 0)
                EkleSilGuncelle(true);
            else
                EkleSilGuncelle(false);
        }
        //
        //
        private void txtTutar_TextChanged(object sender, EventArgs e)
        {
            if (btnEkle.Enabled == true)
            {
                if (((TextBox)sender).Text != string.Empty)
                {
                    if (!char.IsDigit(((TextBox)sender).Text[((TextBox)sender).Text.Length - 1]) && ((TextBox)sender).Text[((TextBox)sender).Text.Length - 1] != ayrac)
                    {
                        ((TextBox)sender).Text = ((TextBox)sender).Text.Substring(0, ((TextBox)sender).Text.Length - 1);
                        ((TextBox)sender).SelectAll();
                        //((TextBox)sender).Text = string.Empty;
                    }
                    else
                    {
                        try
                        {
                            double tutar;
                            if (txtTutar.Text != string.Empty)
                                tutar = Convert.ToDouble(txtTutar.Text);
                            else
                                tutar = 1;
                            double kdv = Convert.ToDouble("1" + ayrac + txtKDV.Text);
                            double toplamtutar = tutar * kdv;
                            txtToplamTutar.Text = toplamtutar.ToString();
                        }
                        catch (Exception)
                        {
                            ((TextBox)sender).Text = string.Empty;
                        }
                    }
                }
            }
        }
        //
        //
        private void txtKDV_TextChanged(object sender, EventArgs e)
        {
            if (btnEkle.Enabled == true)
            {
                if (((TextBox)sender).Text != string.Empty)
                {
                    if (!char.IsDigit(((TextBox)sender).Text[((TextBox)sender).Text.Length - 1]))
                    {
                        ((TextBox)sender).Text = ((TextBox)sender).Text.Substring(0, ((TextBox)sender).Text.Length - 1);
                        ((TextBox)sender).SelectAll();
                    }
                    else
                    {
                        try
                        {
                            double tutar;
                            if (txtTutar.Text != string.Empty)
                                tutar = Convert.ToDouble(txtTutar.Text);
                            else
                                tutar = 1;
                            double kdv = Convert.ToDouble("1" + ayrac + txtKDV.Text);
                            double toplamtutar = tutar * kdv;
                            txtToplamTutar.Text = toplamtutar.ToString();
                        }
                        catch (Exception)
                        {
                            ((TextBox)sender).Text = string.Empty;
                        }
                    }
                }
            }
        }
        //
        //
        private void txtYakit_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text != string.Empty)
            {
                if (!char.IsDigit(((TextBox)sender).Text[((TextBox)sender).Text.Length - 1]) && ((TextBox)sender).Text[((TextBox)sender).Text.Length - 1] != ayrac)
                {
                    ((TextBox)sender).Text = ((TextBox)sender).Text.Substring(0, ((TextBox)sender).Text.Length - 1);
                    ((TextBox)sender).SelectAll();
                    //((TextBox)sender).Text = string.Empty;
                }
                else
                {
                    try
                    {
                        Convert.ToDouble(txtYakit.Text.Trim());
                    }
                    catch (Exception)
                    {
                        ((TextBox)sender).Text = string.Empty;
                    }
                }
            }
        }
        //
        //
        private void btnFirmaEkle_Click(object sender, EventArgs e)
        {
            frmAracFirmalari frm = new frmAracFirmalari();
            frm.ShowDialog();
            AT_AracFirmalari.GetObject(cmbFirmalar.Items, true);
            cmbFirmalar.SelectedIndex = 0;
        }
    }
}

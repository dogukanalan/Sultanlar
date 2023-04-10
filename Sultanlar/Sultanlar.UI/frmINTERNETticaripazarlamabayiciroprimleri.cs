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
    public partial class frmINTERNETticaripazarlamabayiciroprimleri : Form
    {
        public frmINTERNETticaripazarlamabayiciroprimleri()
        {
            InitializeComponent();
        }

        private void frmINTERNETticaripazarlamabayiciroprimleri_Load(object sender, EventArgs e)
        {
            GetObjects();
            GetBayiler();
        }

        private void GetObjects()
        {
            DataTable dt = new DataTable();
            BayiCiroPrimleri.GetObjects(dt);
            gridControl4.DataSource = dt;
        }

        private void GetBayiler()
        {
            CariHesaplarTP.GetObjects(cmbBayi.Items, 0);
            cmbBayi.SelectedIndex = 0;
        }

        private void btnYenile_Click(object sender, EventArgs e)
        {
            GetObjects();
            GetBayiler();
        }

        private void sbEkle_Click(object sender, EventArgs e)
        {
            try
            {
                /*if (BayiCiroPrimleri.VarMi(((CariHesaplarTP)cmbBayi.SelectedItem).SMREF, Convert.ToInt32(txtYil.Text.Trim()), Convert.ToInt32(txtAy.Text.Trim())))
                {
                    MessageBox.Show("Girilen bayi, yıl ve ay değerine ait ciro primleri zaten kayıtı, aynı döneme ikinci bir değer girilemez.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }*/

                BayiCiroPrimleri bcp = new BayiCiroPrimleri(((CariHesaplarTP)cmbBayi.SelectedItem).SMREF, Convert.ToInt32(txtYil.Text.Trim()),
                    Convert.ToInt32(txtAy.Text.Trim()), Convert.ToDecimal(txtTAH.Text.Trim()), Convert.ToDecimal(txtYEG.Text.Trim()), txtAciklama.Text, Convert.ToInt32(txtTAHKDV.Text.Trim()), Convert.ToInt32(txtYEGKDV.Text.Trim()));
                bcp.DoInsert();

                MessageBox.Show("Kayıt başarıyla eklendi.", "Ekleme", MessageBoxButtons.OK, MessageBoxIcon.Information);

                GetObjects();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Girilen değerlerde hata var, lütfen tekrar edip tekrar gönderin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void sbGuncelle_Click(object sender, EventArgs e)
        {
            /*if (gridView4.SelectedRowsCount > 0 && !gridView4.IsFilterRow(gridView4.GetSelectedRows()[0]))
            {
                int SMREF = Convert.ToInt32(gridView4.GetRowCellValue(gridView4.FocusedRowHandle, "SMREF"));
                int Yil = Convert.ToInt32(gridView4.GetRowCellValue(gridView4.FocusedRowHandle, "intYil"));
                int Ay = Convert.ToInt32(gridView4.GetRowCellValue(gridView4.FocusedRowHandle, "intAy"));

                BayiCiroPrimleri bcp = BayiCiroPrimleri.GetObject(SMREF, Yil, Ay);

                bcp.SMREF = ((CariHesaplarTP)cmbBayi.SelectedItem).SMREF;
                bcp.intYil = Convert.ToInt32(txtYil.Text);
                bcp.intAy = Convert.ToInt32(txtAy.Text);
                bcp.mnTAH = Convert.ToDecimal(txtTAH.Text);
                bcp.mnYEG = Convert.ToDecimal(txtYEG.Text);
                bcp.intTAHKDVoran = Convert.ToInt32(txtTAHKDV.Text);
                bcp.intYEGKDVoran = Convert.ToInt32(txtYEGKDV.Text);
                bcp.strAciklama = txtAciklama.Text;

                bcp.DoUpdate();

                MessageBox.Show("Kayıt başarıyla güncellendi.", "Güncelleme", MessageBoxButtons.OK, MessageBoxIcon.Information);

                GetObjects();
            }*/
        }

        private void sbSil_Click(object sender, EventArgs e)
        {
            if (gridView4.SelectedRowsCount > 0 && !gridView4.IsFilterRow(gridView4.GetSelectedRows()[0]))
            {
                int SMREF = Convert.ToInt32(gridView4.GetRowCellValue(gridView4.FocusedRowHandle, "SMREF"));
                int Yil = Convert.ToInt32(gridView4.GetRowCellValue(gridView4.FocusedRowHandle, "intYil"));
                int Ay = Convert.ToInt32(gridView4.GetRowCellValue(gridView4.FocusedRowHandle, "intAy"));

                BayiCiroPrimleri bcp = BayiCiroPrimleri.GetObject(SMREF, Yil, Ay);

                bcp.DoDelete();

                MessageBox.Show("Kayıt başarıyla silindi.", "Silinme", MessageBoxButtons.OK, MessageBoxIcon.Information);

                GetObjects();
            }
        }

        private void gridView4_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridView4.SelectedRowsCount > 0 && !gridView4.IsFilterRow(gridView4.GetSelectedRows()[0]))
            {
                int SMREF = Convert.ToInt32(gridView4.GetRowCellValue(gridView4.FocusedRowHandle, "SMREF"));
                int Yil = Convert.ToInt32(gridView4.GetRowCellValue(gridView4.FocusedRowHandle, "intYil"));
                int Ay = Convert.ToInt32(gridView4.GetRowCellValue(gridView4.FocusedRowHandle, "intAy"));

                BayiCiroPrimleri bcp = BayiCiroPrimleri.GetObject(SMREF, Yil, Ay);

                txtYil.Text = bcp.intYil.ToString();
                txtAy.Text = bcp.intAy.ToString();
                txtTAH.Text = bcp.mnTAH.ToString("N2");
                txtYEG.Text = bcp.mnYEG.ToString("N2");
                txtAciklama.Text = bcp.strAciklama;
                txtTAHKDV.Text = bcp.intTAHKDVoran.ToString();
                txtYEGKDV.Text = bcp.intYEGKDVoran.ToString();

                for (int i = 0; i < cmbBayi.Items.Count; i++)
                {
                    if (((CariHesaplarTP)cmbBayi.Items[i]).SMREF == bcp.SMREF)
                    {
                        cmbBayi.SelectedIndex = i;
                        break;
                    }
                }
            }
            else
            {
                txtAy.Text = DateTime.Now.Month.ToString();
                txtYil.Text = DateTime.Now.Year.ToString();
                txtTAH.Text = "0";
                txtYEG.Text = "0";
                txtTAHKDV.Text = "8";
                txtYEGKDV.Text = "18";
                txtAciklama.Text = string.Empty;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Excel dosyaları (*.xls, *.xlsx)|*.xls;*.xlsx;|Bütün Dosyalar|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                if (MessageBox.Show("Dosyadan aktarım yapmak istediğinize emin misiniz?\r\nExcel dosyası kolonları sırasıyla aşağıdaki gibi olmalı:\r\n\r\nA-Bayi Kodu, B-Yıl, C-Ay, D-KGT Bedel, E-NF Bedel, F-Açıklama, G-TAH Kdv oran H-YEG Kdv oran", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    ExceldenAl(ofd.FileName);
                }
            }
        }

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
                    BayiCiroPrimleri.DoInsert(Convert.ToInt32(values[i, 1]), Convert.ToInt32(values[i, 2]), Convert.ToInt32(values[i, 3]), Convert.ToDecimal(values[i, 4]), Convert.ToDecimal(values[i, 5]), values[i, 6].ToString(), Convert.ToInt32(values[i, 7]), Convert.ToInt32(values[i, 8]));
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata oluşan satır: " + i.ToString() + "\r\nHata ayrıntısı: " + ex.Message);
                }
            }

            MessageBox.Show("Tüm veriler aktarıldı.", "Aktarım", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnYenile.PerformClick();
        }
    }
}

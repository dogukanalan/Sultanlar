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
    public partial class frmINTERNETticaripazarlamabayinihaikapamalar : Form
    {
        public frmINTERNETticaripazarlamabayinihaikapamalar()
        {
            InitializeComponent();
        }

        private void frmINTERNETticaripazarlamabayinihaikapamalar_Load(object sender, EventArgs e)
        {
            GetObjects();
            GetBayiler();
        }

        private void GetObjects()
        {
            DataTable dt = new DataTable();
            BayiNihaiKapamalar.GetObjects(dt);
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
                if (BayiNihaiKapamalar.VarMi(((CariHesaplarTP)cmbBayi.SelectedItem).SMREF, Convert.ToInt32(txtYil.Text.Trim()), Convert.ToInt32(txtAy.Text.Trim()), txtFaturaNo.Text.Trim(), txtFaturaNoNF.Text.Trim()))
                {
                    MessageBox.Show("Girilen bayi, yıl, ay ve fatura numaralarına ait faturalar zaten kayıtı, aynı dönem ve fatura numaraları tekrar girilemez.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                BayiNihaiKapamalar bcp = new BayiNihaiKapamalar(((CariHesaplarTP)cmbBayi.SelectedItem).SMREF, Convert.ToInt32(txtYil.Text.Trim()),
                    Convert.ToInt32(txtAy.Text.Trim()), txtFaturaNo.Text.Trim(), dtpFatura.Value, txtFaturaNoNF.Text.Trim(), dtpFaturaNF.Value, Convert.ToDecimal(txtTAH.Text.Trim()), Convert.ToDecimal(txtYEG.Text.Trim()), txtAciklama.Text);
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
            if (gridView4.SelectedRowsCount > 0 && !gridView4.IsFilterRow(gridView4.GetSelectedRows()[0]))
            {
                int SMREF = Convert.ToInt32(gridView4.GetRowCellValue(gridView4.FocusedRowHandle, "SMREF"));
                int Yil = Convert.ToInt32(gridView4.GetRowCellValue(gridView4.FocusedRowHandle, "intYil"));
                int Ay = Convert.ToInt32(gridView4.GetRowCellValue(gridView4.FocusedRowHandle, "intAy"));
                string FatNo = gridView4.GetRowCellValue(gridView4.FocusedRowHandle, "strFaturaNo").ToString();
                string FatNoNF = gridView4.GetRowCellValue(gridView4.FocusedRowHandle, "strFaturaNoNF").ToString();

                BayiNihaiKapamalar bcp = BayiNihaiKapamalar.GetObject(SMREF, Yil, Ay, FatNo, FatNoNF);
                
                //if (BayiNihaiKapamalar.VarMi(((CariHesaplarTP)cmbBayi.SelectedItem).SMREF, Convert.ToInt32(txtYil.Text.Trim()), Convert.ToInt32(txtAy.Text.Trim()), txtFaturaNo.Text.Trim(), txtFaturaNoNF.Text.Trim())
                //    && Convert.ToDecimal(txtTAH.Text.Trim()) == bcp.mnTAH && Convert.ToDecimal(txtTAH.Text.Trim()) == bcp.mnYEG && dtpFatura.Value == bcp.dtFaturaTarih && dtpFaturaNF.Value == bcp.dtFaturaTarihNF && txtAciklama.Text.Trim() == bcp.strAciklama)
                //{
                //    MessageBox.Show("Girilen bayi, yıl, ay ve fatura numaralarına ait faturalar zaten kayıtı, aynı dönem ve fatura numaraları tekrar girilemez.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    return;
                //}

                bcp.SMREF = ((CariHesaplarTP)cmbBayi.SelectedItem).SMREF;
                bcp.intYil = Convert.ToInt32(txtYil.Text);
                bcp.intAy = Convert.ToInt32(txtAy.Text);
                bcp.strFaturaNo = txtFaturaNo.Text.Trim();
                bcp.dtFaturaTarih = dtpFatura.Value;
                bcp.strFaturaNoNF = txtFaturaNoNF.Text.Trim();
                bcp.dtFaturaTarihNF = dtpFaturaNF.Value;
                bcp.mnTAH = Convert.ToDecimal(txtTAH.Text);
                bcp.mnYEG = Convert.ToDecimal(txtYEG.Text);
                bcp.strAciklama = txtAciklama.Text;

                bcp.DoUpdate();

                MessageBox.Show("Kayıt başarıyla güncellendi.", "Güncelleme", MessageBoxButtons.OK, MessageBoxIcon.Information);

                GetObjects();
            }
        }

        private void sbSil_Click(object sender, EventArgs e)
        {
            if (gridView4.SelectedRowsCount > 0 && !gridView4.IsFilterRow(gridView4.GetSelectedRows()[0]))
            {
                int SMREF = Convert.ToInt32(gridView4.GetRowCellValue(gridView4.FocusedRowHandle, "SMREF"));
                int Yil = Convert.ToInt32(gridView4.GetRowCellValue(gridView4.FocusedRowHandle, "intYil"));
                int Ay = Convert.ToInt32(gridView4.GetRowCellValue(gridView4.FocusedRowHandle, "intAy"));
                string FatNo = gridView4.GetRowCellValue(gridView4.FocusedRowHandle, "strFaturaNo").ToString();
                string FatNoNF = gridView4.GetRowCellValue(gridView4.FocusedRowHandle, "strFaturaNoNF").ToString();

                BayiNihaiKapamalar bcp = BayiNihaiKapamalar.GetObject(SMREF, Yil, Ay, FatNo, FatNoNF);

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
                string FatNo = gridView4.GetRowCellValue(gridView4.FocusedRowHandle, "strFaturaNo").ToString();
                string FatNoNF = gridView4.GetRowCellValue(gridView4.FocusedRowHandle, "strFaturaNoNF").ToString();

                BayiNihaiKapamalar bcp = BayiNihaiKapamalar.GetObject(SMREF, Yil, Ay, FatNo, FatNoNF);

                txtYil.Text = bcp.intYil.ToString();
                txtAy.Text = bcp.intAy.ToString();
                txtFaturaNo.Text = bcp.strFaturaNo;
                dtpFatura.Value = bcp.dtFaturaTarih;
                txtFaturaNoNF.Text = bcp.strFaturaNoNF;
                dtpFaturaNF.Value = bcp.dtFaturaTarihNF;
                txtTAH.Text = bcp.mnTAH.ToString("N2");
                txtYEG.Text = bcp.mnYEG.ToString("N2");
                txtAciklama.Text = bcp.strAciklama;

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
                txtFaturaNo.Text = string.Empty;
                dtpFatura.Value = DateTime.Now;
                txtFaturaNoNF.Text = string.Empty;
                dtpFaturaNF.Value = DateTime.Now;
                txtTAH.Text = "0";
                txtYEG.Text = "0";
                txtAciklama.Text = string.Empty;
            }
        }
    }
}

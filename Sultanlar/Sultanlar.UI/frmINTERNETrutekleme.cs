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
    public partial class frmINTERNETrutekleme : Form
    {
        public frmINTERNETrutekleme()
        {
            InitializeComponent();
        }

        private void frmINTERNETrut_Load(object sender, EventArgs e)
        {
            CariHesapZTipler.GetObjects(cmbTipler.Items);
            cmbTipler.SelectedIndex = 0;
        }

        private void btnYenile_Click(object sender, EventArgs e)
        {
            int kacinci = radioButton1.Checked ? 1 : radioButton2.Checked ? 2 : radioButton3.Checked ? 3 : radioButton4.Checked ? 4 : radioButton5.Checked ? 5 : radioButton6.Checked ? 6 : 0;

            DataTable dt = new DataTable();
            Rutlar.GetRutlar(dt, ((CariHesapZTipler)cmbTipler.SelectedItem).TIP_KOD.ToString(), kacinci);
            gridControl1.DataSource = dt;

            DataTable dt1 = new DataTable();
            Rutlar.GetPeriyodlar(dt1);
            gridControl2.DataSource = dt1;

            DataTable dt2 = new DataTable();
            Rutlar.GetGunler(dt2);
            gridControl3.DataSource = dt2;
        }

        private void Temizle()
        {
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker1.Font = new System.Drawing.Font("Tahoma", 8, FontStyle.Regular);
            dateTimePicker2.Value = Convert.ToDateTime("09.01.2028");
            dateTimePicker2.Font = new System.Drawing.Font("Tahoma", 8, FontStyle.Regular);
            gridView2.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle;
            gridView2.FocusedColumn = gridView2.VisibleColumns[0];
            gridView3.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle;
            gridView3.FocusedColumn = gridView3.VisibleColumns[0];
        }

        private void DetayGetir()
        {
            if (gridView1.GetSelectedRows().Length == 0)
                return;

            Temizle();

            DataTable dt = new DataTable();
            int slsref = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], "intSLSREF"));
            int gmref = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], "GMREF"));
            int smref = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], "SMREF"));
            int kacinci = radioButton1.Checked ? 1 : radioButton2.Checked ? 2 : radioButton3.Checked ? 3 : radioButton4.Checked ? 4 : radioButton5.Checked ? 5 : radioButton6.Checked ? 6 : 0;

            Rutlar.GetRutDetay(dt, slsref, gmref, smref, kacinci);

            if (dt.Rows.Count > 0 && dt.Rows[0][1] != DBNull.Value && dt.Rows[0][1].ToString() != string.Empty)
            {
                for (int i = 0; i < gridView2.RowCount; i++)
                {
                    if (gridView2.GetRowCellValue(i, "RUT_PRYD_KOD").ToString().Trim() == dt.Rows[0][1].ToString().Trim())
                    {
                        gridView2.FocusedRowHandle = i;
                        gridView2.FocusedColumn = gridView2.VisibleColumns[0];
                        break;
                    }
                }
                for (int i = 0; i < gridView3.RowCount; i++)
                {
                    if (gridView3.GetRowCellValue(i, "GUN_ID").ToString().Trim() == dt.Rows[0][2].ToString().Trim())
                    {
                        gridView3.FocusedRowHandle = i;
                        gridView3.FocusedColumn = gridView3.VisibleColumns[0];
                        break;
                    }
                }
                dateTimePicker1.Value = Convert.ToDateTime(dt.Rows[0][3]);
                dateTimePicker1.Font = new System.Drawing.Font("Tahoma", 8, FontStyle.Bold);
                dateTimePicker2.Value = Convert.ToDateTime(dt.Rows[0][4]);
                dateTimePicker2.Font = new System.Drawing.Font("Tahoma", 8, FontStyle.Bold);
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (gridView2.GetSelectedRows()[0] == DevExpress.XtraGrid.GridControl.AutoFilterRowHandle || gridView3.GetSelectedRows()[0] == DevExpress.XtraGrid.GridControl.AutoFilterRowHandle)
            {
                MessageBox.Show("Eksik seçim var.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int slsref = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], "intSLSREF"));
            int gmref = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], "GMREF"));
            int smref = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], "SMREF"));
            int kacinci = radioButton1.Checked ? 1 : radioButton2.Checked ? 2 : radioButton3.Checked ? 3 : radioButton4.Checked ? 4 : radioButton5.Checked ? 5 : radioButton6.Checked ? 6 : 0;
            string rut = gridView2.GetRowCellValue(gridView2.GetSelectedRows()[0], "RUT_PRYD_KOD").ToString().Trim();
            string gun = gridView3.GetRowCellValue(gridView3.GetSelectedRows()[0], "GUN_ID").ToString().Trim();

            //if (kacinci != 1)
            //{
            //    DataTable dt = new DataTable();
            //    Rutlar.GetRutDetay(dt, slsref, gmref, smref, kacinci - 1);
            //    if (Rutlar.RutVarMi(slsref, gmref, smref, kacinci - 1))
            //    {
            //        MessageBox.Show("Bir önceki rut bilgisi girilmeden sonraki girilemez.", "Hatalı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        return;
            //    }
            //    else if (Convert.ToDateTime(dt.Rows[0][4]) < DateTime.Now && Convert.ToDateTime(dt.Rows[0][3]) != Convert.ToDateTime(dt.Rows[0][4])) // başlangıç bitişe eşit ise rut durmuş demek
            //    {
            //        MessageBox.Show("Bir önceki rut bilgisinin bitiş tarihi geçmiş. Önce onun düzeltilmesi gerekiyor.", "Hatalı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        return;
            //    }
            //}

            //if (kacinci != 6)
            //{
            //    if (Convert.ToDateTime(dateTimePicker1.Value.ToShortDateString()) == Convert.ToDateTime(dateTimePicker2.Value.ToShortDateString())) // rut durduruluyor ise
            //    {
            //        if (Rutlar.RutVarMi(slsref, gmref, smref, kacinci + 1))
            //        {
            //            MessageBox.Show("Bir sonraki rut aktifken bu rutu durduramazsınız, öncelikle bir sonraki rutun durdurulması gerekiyor.", "Hatalı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            return;
            //        }
            //    }
            //}

            if (Convert.ToDateTime(dateTimePicker1.Value.ToShortDateString()) < Convert.ToDateTime(DateTime.Now.ToShortDateString()) && Convert.ToDateTime(dateTimePicker1.Value.ToShortDateString()) != Convert.ToDateTime(dateTimePicker2.Value.ToShortDateString())) // rut durdurulmaya çalışıyorsa başlangıç bugünden küçük demesin
            {
                MessageBox.Show("Başlangıç tarihi bugünden büyük veya eşit olmalı.", "Hatalı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Rutlar.Insert(((CariHesapZTipler)cmbTipler.SelectedItem).TIP_KOD, slsref, gmref, smref, kacinci, rut, gun, Convert.ToDateTime(dateTimePicker1.Value.ToShortDateString()), Convert.ToDateTime(dateTimePicker2.Value.ToShortDateString()), frmAna.KAdi, DateTime.Now);

            MessageBox.Show("Kaydedildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridView1.GetSelectedRows().Length > 0)
                DetayGetir();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
                btnYenile.PerformClick();
        }

        private void gridView2_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.RowHandle == ((DevExpress.XtraGrid.Views.Grid.GridView)sender).FocusedRowHandle)
            {
                e.Appearance.BackColor = Color.Bisque;
                //e.Appearance.ForeColor = Color.White;
            }
        }

        private void gridView3_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.RowHandle == ((DevExpress.XtraGrid.Views.Grid.GridView)sender).FocusedRowHandle)
            {
                e.Appearance.BackColor = Color.Bisque;
                //e.Appearance.ForeColor = Color.White;
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Rutlar.JobCalistir());
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            Rutlar.GetRut5(dt);
            frmGrid frm = new frmGrid(dt);
            frm.ShowDialog();
        }

        private void sbNotlar_Click(object sender, EventArgs e)
        {
            frmINTERNETrutnotlar frm = new frmINTERNETrutnotlar();
            frm.ShowDialog();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            if (gridView2.GetSelectedRows()[0] == DevExpress.XtraGrid.GridControl.AutoFilterRowHandle || gridView3.GetSelectedRows()[0] == DevExpress.XtraGrid.GridControl.AutoFilterRowHandle)
            {
                MessageBox.Show("Eksik seçim var.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int slsref = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], "intSLSREF"));
            int gmref = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], "GMREF"));
            int smref = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], "SMREF"));
            int kacinci = radioButton1.Checked ? 1 : radioButton2.Checked ? 2 : radioButton3.Checked ? 3 : radioButton4.Checked ? 4 : radioButton5.Checked ? 5 : radioButton6.Checked ? 6 : 0;
            string rut = gridView2.GetRowCellValue(gridView2.GetSelectedRows()[0], "RUT_PRYD_KOD").ToString().Trim();
            string gun = gridView3.GetRowCellValue(gridView3.GetSelectedRows()[0], "GUN_ID").ToString().Trim();

            if (Rutlar.RutVarMi(slsref, gmref, smref, kacinci))
            {
                if (MessageBox.Show("Rutu durdurmak istediğinize emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.No)
                    return;

                dateTimePicker1.Value = DateTime.Now;
                dateTimePicker2.Value = DateTime.Now;
                simpleButton1.PerformClick();
            }
            else
            {
                MessageBox.Show("Rut seçili değil.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            if (gridView2.GetSelectedRows()[0] == DevExpress.XtraGrid.GridControl.AutoFilterRowHandle || gridView3.GetSelectedRows()[0] == DevExpress.XtraGrid.GridControl.AutoFilterRowHandle)
            {
                MessageBox.Show("Eksik seçim var.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int slsref = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], "intSLSREF"));
            int gmref = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], "GMREF"));
            int smref = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], "SMREF"));
            int kacinci = radioButton1.Checked ? 1 : radioButton2.Checked ? 2 : radioButton3.Checked ? 3 : radioButton4.Checked ? 4 : radioButton5.Checked ? 5 : radioButton6.Checked ? 6 : 0;
            string rut = gridView2.GetRowCellValue(gridView2.GetSelectedRows()[0], "RUT_PRYD_KOD").ToString().Trim();
            string gun = gridView3.GetRowCellValue(gridView3.GetSelectedRows()[0], "GUN_ID").ToString().Trim();

            if (Rutlar.RutVarMi(slsref, gmref, smref, kacinci))
            {
                if (MessageBox.Show("Rutu başlatmak istediğinize emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.No)
                    return;

                dateTimePicker1.Value = DateTime.Now;
                dateTimePicker2.Value = Convert.ToDateTime("09.01.2028");
                simpleButton1.PerformClick();
            }
            else
            {
                MessageBox.Show("Rut seçili değil.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}

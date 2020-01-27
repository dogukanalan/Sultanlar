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
    public partial class frmINTERNETiadeislem : Form
    {
        public frmINTERNETiadeislem()
        {
            InitializeComponent();
        }

        private void frmINTERNETiadeislem_Load(object sender, EventArgs e)
        {
            GetObjects();
            GetPersoneller();
        }

        private void GetObjects()
        {
            DataTable dt = new DataTable();
            IadelerIslem.GetObjects(dt);
            gridControl1.DataSource = dt;
            gridView1.FocusedRowHandle = -999997;
        }

        private void GetPersoneller()
        {
            SatisTemsilcileri.GetObjects(cmbPersoneller.Items, true);
        }

        private void btnYenile_Click(object sender, EventArgs e)
        {
            GetObjects();
            GetPersoneller();
        }

        private void cbSatici_CheckedChanged(object sender, EventArgs e)
        {
            cmbPersoneller.Enabled = cbSatici.Checked;
            cbSaticiTarih.Checked = cbSatici.Checked;
        }

        private void cbSaticiTarih_CheckedChanged(object sender, EventArgs e)
        {
            dtpSatici.Enabled = cbSaticiTarih.Checked;
        }

        private void cbMuhasebeTarihi_CheckedChanged(object sender, EventArgs e)
        {
            dtpMuhasebe.Enabled = cbMuhasebeTarihi.Checked;
        }

        private void sbKontrol_Click(object sender, EventArgs e)
        {
            if (gridView1.SelectedRowsCount > 0 && !gridView1.IsFilterRow(gridView1.GetSelectedRows()[0]))
            {
                int ID = Convert.ToInt32(gridView1.GetFocusedRowCellValue("intIadeID"));

                if (ID != 0)
                {
                    IadelerIslem ii = IadelerIslem.GetObject(ID);
                    if (cbSatici.Checked) ii.strVerilen = ((SatisTemsilcileri)cmbPersoneller.SelectedItem).SATTEM; else ii.strVerilen = string.Empty;
                    if (cbSaticiTarih.Checked) ii.dtVerilis = dtpSatici.Value; else ii.dtVerilis = DateTime.MinValue;
                    if (cbMuhasebeTarihi.Checked) ii.dtMuhasebeVerilis = dtpMuhasebe.Value; else ii.dtMuhasebeVerilis = DateTime.MinValue;
                    ii.strFatNo = txtFatNo.Text.Trim();
                    ii.DoUpdate();

                    GetObjects();
                }
            }
            else
            {
                if (MessageBox.Show("Girilen fatura numarası, satırda sadece fatura numarası gözükecek şekilde kaydedilecek. Devam etmek istediğinize emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    if (txtFatNo.Text.Trim() != string.Empty)
                    {
                        if (IadelerIslem.IsExist(txtFatNo.Text.Trim(), false))
                        {
                            MessageBox.Show("Girilen fatura numarası daha önceden girilmiş, tekrar girilemez.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        IadelerIslem ii = new IadelerIslem(0, DateTime.MinValue, string.Empty, DateTime.MinValue, DateTime.MinValue, txtFatNo.Text.Trim(), false);
                        ii.DoInsert();

                        MessageBox.Show("Fatura numarası eklendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        //GetObjects();
                    }
                }
            }
        }

        private void sbIadeDegil_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Girilen fatura numarası, ''İade faturası değil'' şekilde işaretlenecek. Devam etmek istediğinize emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
            {
                if (txtFatNo.Text.Trim() != string.Empty)
                {
                    if (IadelerIslem.IsExist(txtFatNo.Text.Trim(), true))
                    {
                        MessageBox.Show("Girilen fatura numarası daha önceden girilmiş, tekrar girilemez.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    IadelerIslem ii = new IadelerIslem(0, DateTime.MinValue, string.Empty, DateTime.MinValue, DateTime.MinValue, txtFatNo.Text.Trim(), true);
                    ii.DoInsert();

                    GetObjects();
                }
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridView1.SelectedRowsCount > 0 && !gridView1.IsFilterRow(gridView1.GetSelectedRows()[0]))
            {
                sbIadeGelmedi.Enabled = false;
                sbIadeDegil.Enabled = false;
                sbSil.Enabled = true;

                int ID = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "intIadeID"));
                IadelerIslem ii = IadelerIslem.GetObject(ID);

                if (ID == 0)
                    ii = IadelerIslem.GetObject(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "strFatNo").ToString(), Convert.ToBoolean(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "blIadeDegil")));

                txtFatNo.Text = ii.strFatNo;

                dtpSatici.Value = ii.dtVerilis == DateTime.MinValue ? DateTime.Now : ii.dtVerilis;
                dtpSatici.Enabled = ii.dtVerilis == DateTime.MinValue ? false : true;
                cbSaticiTarih.Checked = ii.dtVerilis == DateTime.MinValue ? false : true;

                dtpMuhasebe.Value = ii.dtMuhasebeVerilis == DateTime.MinValue ? DateTime.Now : ii.dtMuhasebeVerilis;
                dtpMuhasebe.Enabled = ii.dtMuhasebeVerilis == DateTime.MinValue ? false : true;
                cbMuhasebeTarihi.Checked = ii.dtMuhasebeVerilis == DateTime.MinValue ? false : true;

                for (int i = 0; i < cmbPersoneller.Items.Count; i++)
                {
                    if (cmbPersoneller.Items[i].ToString() == ii.strVerilen)
                    {
                        cmbPersoneller.SelectedIndex = i;
                        break;
                    }
                }
                cmbPersoneller.Enabled = ii.strVerilen == string.Empty ? false : true;
                cbSatici.Checked = ii.strVerilen == string.Empty ? false : true;
            }
            else
            {
                sbIadeGelmedi.Enabled = true;
                sbIadeDegil.Enabled = true;
                sbSil.Enabled = false;

                txtFatNo.Text = string.Empty;

                dtpSatici.Value = DateTime.Now;
                dtpSatici.Enabled = false;
                cbSaticiTarih.Checked = false;

                dtpMuhasebe.Value = DateTime.Now;
                dtpMuhasebe.Enabled = false;
                cbMuhasebeTarihi.Checked = false;

                cmbPersoneller.SelectedIndex = -1;
                cmbPersoneller.Enabled = false;
                cbSatici.Checked = false;
            }
        }

        private void sbSil_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(gridView1.GetFocusedRowCellValue("intIadeID")) == 0)
            {
                if (MessageBox.Show("Satırı silmek istediğinize emin misiniz?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    IadelerIslem.DoDelete(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "strFatNo").ToString());
                    GetObjects();
                }
            }
        }

        private void txtFatNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                sbKontrol.PerformClick();
            }
        }

        private void txtFatNo_KeyUp(object sender, KeyEventArgs e)
        {
            cbMuhasebeTarihi.Checked = txtFatNo.Text.Trim() != string.Empty;
        }

        private void sbIadeGelmedi_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Girilen fatura numarası, ''İade gelmedi'' şeklinde kaydedilecek. Devam etmek istediğinize emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
            {
                if (txtFatNo.Text.Trim() != string.Empty)
                {
                    if (IadelerIslem.IsExist(txtFatNo.Text.Trim().Substring(txtFatNo.Text.IndexOf("-") + 1) + "-" + txtFatNo.Text.Trim().Substring(0, txtFatNo.Text.IndexOf("-")) + " İADESİ GELMEDİ", false))
                    {
                        MessageBox.Show("Girilen fatura numarası daha önceden girilmiş, tekrar girilemez.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    IadelerIslem ii = new IadelerIslem(0, DateTime.MinValue, string.Empty, DateTime.MinValue, DateTime.MinValue, txtFatNo.Text.Trim().Substring(txtFatNo.Text.IndexOf("-") + 1) + "-" + txtFatNo.Text.Trim().Substring(0, txtFatNo.Text.IndexOf("-")) + " İADESİ GELMEDİ", false);
                    ii.DoInsert();

                    MessageBox.Show("Fatura numarası eklendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    GetObjects();
                }
            }
        }
    }
}

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
    public partial class frmINTERNETticaripazarlamahizmetbedelleri : Form
    {
        public frmINTERNETticaripazarlamahizmetbedelleri()
        {
            InitializeComponent();
            SMREF = 0;
            this.Text = "Ticari Pazarlama : Hizmet Bedelleri (Tümü)";
        }

        public frmINTERNETticaripazarlamahizmetbedelleri(int smref)
        {
            InitializeComponent();
            SMREF = smref;
            this.Text = "Ticari Pazarlama : Hizmet Bedelleri (" + CariHesaplarTP.GetObject(smref, false).SUBE + ")";
            cmbBayiler.Enabled = false;
            cmbAltCariler.Enabled = false;
            gridColumn17.Visible = false;
        }

        int SMREF;
        bool Acilis;

        private void frmINTERNETticaripazarlamahizmetbedelleri_Load(object sender, EventArgs e)
        {
            Acilis = true;
            dateTimePicker1.Value = DateTime.Now.AddYears(-1);
            dateTimePicker2.Value = DateTime.Now.AddYears(1);
            GetAnlasmaBedelAdlari();
            //GetBayiler();
            GetHizmetBedelleri();
            GetHizmetBedeli();
            Acilis = false;
        }

        private void splitContainer1_Panel2_SizeChanged(object sender, EventArgs e)
        {
            sbEkle.Location = new Point(sbEkle.Location.X, splitContainer1.Panel2.Height - 26);
            sbDuzenle.Location = new Point(sbDuzenle.Location.X, splitContainer1.Panel2.Height - 26);
            sbSil.Location = new Point(sbSil.Location.X, splitContainer1.Panel2.Height - 26);
            sbOnayla.Location = new Point(sbOnayla.Location.X, splitContainer1.Panel2.Height - 26);
            sbExcel.Location = new Point(sbExcel.Location.X, splitContainer1.Panel2.Height - 26);
        }

        private void frmINTERNETticaripazarlamahizmetbedelleri_SizeChanged(object sender, EventArgs e)
        {
            sbEkle.Location = new Point(sbEkle.Location.X, lblAlt.Location.Y + 3);
            sbDuzenle.Location = new Point(sbDuzenle.Location.X, lblAlt.Location.Y + 3);
            sbSil.Location = new Point(sbSil.Location.X, lblAlt.Location.Y + 3);
            sbOnayla.Location = new Point(sbOnayla.Location.X, lblAlt.Location.Y + 3);
            sbExcel.Location = new Point(sbExcel.Location.X, lblAlt.Location.Y + 3);

            rbHepsi.Location = new Point(this.Width - 250, rbHepsi.Location.Y);
            rbOnaylilar.Location = new Point(this.Width - 192, rbOnaylilar.Location.Y);
            rbOnaysizlar.Location = new Point(this.Width - 114, rbOnaysizlar.Location.Y);
        }

        private void frmINTERNETticaripazarlamahizmetbedelleri_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmAna frm1 = (frmAna)this.ParentForm;
            frm1.FormKapanirken(this.Name);
        }

        private void GetHizmetBedelleri()
        {
            object Onayli = DBNull.Value;
            if (rbOnaylilar.Checked)
                Onayli = true;
            else if (rbOnaysizlar.Checked)
                Onayli = false;

            DataTable dt = new DataTable();
            if (SMREF != 0)
                AnlasmaHizmetBedelleri.GetObjects(dt, SMREF, Onayli, dateTimePicker1.Value, dateTimePicker2.Value, 0, AnlasmaHizmetBedelleri.GetObjectCount(SMREF, Onayli, dateTimePicker1.Value, dateTimePicker2.Value));
            else
                AnlasmaHizmetBedelleri.GetObjects(dt, Onayli, dateTimePicker1.Value, dateTimePicker2.Value, 0, AnlasmaHizmetBedelleri.GetObjectCount(Onayli, dateTimePicker1.Value, dateTimePicker2.Value));
            gridControl4.DataSource = dt;
        }

        private void GetAnlasmaBedelAdlari()
        {
            AnlasmaBedelAdlari.GetObjects(cmbAnlasmaBedelAdlari.Items, true);
        }

        //private void GetBayiler()
        //{
        //    CariHesaplarTP.GetObjects(cmbBayiler.Items, 0);
        //}

        //private void GetAltCariler(int GMREF)
        //{
        //    CariHesaplarTP.GetObjects(cmbAltCariler.Items, GMREF);
        //}

        private void GetHizmetBedeli()
        {
            if (gridView4.SelectedRowsCount > 0 && !gridView4.IsFilterRow(gridView4.GetSelectedRows()[0]))
            {
                int AnlasmaHizmetBedelID = Convert.ToInt32(((DataRowView)gridControl4.MainView.GetRow(gridView4.GetSelectedRows()[0])).Row.ItemArray[0]);
                AnlasmaHizmetBedelleri anlasmahizmetbedeli = AnlasmaHizmetBedelleri.GetObject(AnlasmaHizmetBedelID);

                //for (int i = 0; i < cmbBayiler.Items.Count; i++)
                //    if (((CariHesaplarTP)cmbBayiler.Items[i]).GMREF == CariHesaplarTP.GetGMREFBySMREF(anlasmahizmetbedeli.SMREF))
                //        cmbBayiler.SelectedIndex = i;

                lblBayi.Text = CariHesaplarTP.GetObject(anlasmahizmetbedeli.SMREF, true).MUSTERI;

                //GetAltCariler(((CariHesaplarTP)cmbBayiler.SelectedItem).GMREF);

                //for (int i = 0; i < cmbAltCariler.Items.Count; i++)
                //    if (((CariHesaplarTP)cmbAltCariler.Items[i]).SMREF == anlasmahizmetbedeli.SMREF)
                //        cmbAltCariler.SelectedIndex = i;

                lblAltCari.Text = CariHesaplarTP.GetObject(anlasmahizmetbedeli.SMREF, false).SUBE;

                for (int i = 0; i < cmbAnlasmaBedelAdlari.Items.Count; i++)
                    if (((AnlasmaBedelAdlari)cmbAnlasmaBedelAdlari.Items[i]).pkID == anlasmahizmetbedeli.intAnlasmaBedelAdID)
                        cmbAnlasmaBedelAdlari.SelectedIndex = i;

                txtFatNo.Text = anlasmahizmetbedeli.strFaturaNo;
                dtpFatTar.Value = anlasmahizmetbedeli.dtFaturaTarih;
                txtAy.Text = anlasmahizmetbedeli.intAy.ToString();
                txtYil.Text = anlasmahizmetbedeli.intYil.ToString();
                txtAciklama1.Text = anlasmahizmetbedeli.strAciklama1;
                txtTAHBedel.Text = anlasmahizmetbedeli.mnTAHBedel.ToString();
                txtYEGBedel.Text = anlasmahizmetbedeli.mnYEGBedel.ToString();
                txtMudurButcesi.Text = anlasmahizmetbedeli.mnMudurButce.ToString("N0");
                txtElemanButcesi.Text = anlasmahizmetbedeli.mnElemanButce.ToString("N0");
                cbKapamaEtki.Checked = anlasmahizmetbedeli.blKapamaEtki;
            }
            else
            {
                Temizle();
            }
        }

        private void Temizle()
        {
            //cmbBayiler.SelectedIndex = -1;
            lblBayi.Text = string.Empty;

            //cmbAltCariler.Items.Clear();
            lblAltCari.Text = string.Empty;

            txtFatNo.Text = string.Empty;
            dtpFatTar.Value = DateTime.Now;
            txtAy.Text = string.Empty;
            txtYil.Text = string.Empty;
            txtAciklama1.Text = string.Empty;
            txtTAHBedel.Text = 0.ToString("N2");
            txtYEGBedel.Text = 0.ToString("N2");
            cbKapamaEtki.Checked = true;
        }

        private void gridControl4_Click(object sender, EventArgs e)
        {
        }

        private void cmbBayiler_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cmbBayiler.SelectedIndex > -1)
            //    GetAltCariler(((CariHesaplarTP)cmbBayiler.SelectedItem).GMREF);
        }

        private void btnYenile_Click(object sender, EventArgs e)
        {
            GetAnlasmaBedelAdlari();
            //GetBayiler();
            GetHizmetBedelleri();
            GetHizmetBedeli();
        }

        private void sbOnayla_Click(object sender, EventArgs e)
        {
            if (!Convert.ToBoolean(((DataRowView)gridControl4.MainView.GetRow(gridView4.GetSelectedRows()[0])).Row.ItemArray[1]))
            {
                int AnlasmaHizmetBedelID = Convert.ToInt32(((DataRowView)gridControl4.MainView.GetRow(gridView4.GetSelectedRows()[0])).Row.ItemArray[0]);
                int smref = Convert.ToInt32(((DataRowView)gridControl4.MainView.GetRow(gridView4.GetSelectedRows()[0])).Row.ItemArray[2]);
                frmINTERNETticaripazarlamahizmetanlasmakapama frm = new frmINTERNETticaripazarlamahizmetanlasmakapama(smref, AnlasmaHizmetBedelID);
                frm.ShowDialog();
                GetHizmetBedelleri();
            }
            else
            {
                MessageBox.Show("Bu hizmet bedeli zaten kapatılmış.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void sbEkle_Click(object sender, EventArgs e)
        {
            frmINTERNETticaripazarlamacarisecimi frm = new frmINTERNETticaripazarlamacarisecimi();
            frm.ShowDialog();

            if (frm.SMREF != 0)
            {
                if (MessageBox.Show("Hizmet bedeli eklenecek, devam etmek istediğinize emin misiniz?", "Ekleme", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    try
                    {
                        AnlasmaHizmetBedelleri anlasmahizmetbedeli = new AnlasmaHizmetBedelleri();

                        anlasmahizmetbedeli.strFaturaNo = txtFatNo.Text.Trim();
                        anlasmahizmetbedeli.dtFaturaTarih = dtpFatTar.Value;
                        anlasmahizmetbedeli.intAnlasmaBedelAdID = ((AnlasmaBedelAdlari)cmbAnlasmaBedelAdlari.SelectedItem).pkID;
                        anlasmahizmetbedeli.intAy = Convert.ToInt32(txtAy.Text);
                        anlasmahizmetbedeli.intYil = Convert.ToInt32(txtYil.Text);
                        anlasmahizmetbedeli.mnTAHBedel = Convert.ToDecimal(txtTAHBedel.Text);
                        anlasmahizmetbedeli.mnYEGBedel = Convert.ToDecimal(txtYEGBedel.Text);
                        anlasmahizmetbedeli.SMREF = frm.SMREF;
                        anlasmahizmetbedeli.strAciklama1 = txtAciklama1.Text.Trim();
                        anlasmahizmetbedeli.strAciklama2 = string.Empty;
                        anlasmahizmetbedeli.strAciklama3 = string.Empty;
                        anlasmahizmetbedeli.strAciklama4 = string.Empty;
                        anlasmahizmetbedeli.mnMudurButce = Convert.ToDecimal(txtMudurButcesi.Text.Replace(".", ""));
                        anlasmahizmetbedeli.mnElemanButce = Convert.ToDecimal(txtElemanButcesi.Text.Replace(".", ""));
                        anlasmahizmetbedeli.blKapamaEtki = cbKapamaEtki.Checked;

                        anlasmahizmetbedeli.DoInsert();

                        GetHizmetBedelleri();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Seçimlerde eksik seçim var.\r\n\r\nHata ayrıntısı: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void sbDuzenle_Click(object sender, EventArgs e)
        {
            if (gridView4.SelectedRowsCount > 0 && !gridView4.IsFilterRow(gridView4.GetSelectedRows()[0]))
            {
                int AnlasmaHizmetBedeliID = Convert.ToInt32(((DataRowView)gridControl4.MainView.GetRow(gridView4.GetSelectedRows()[0])).Row.ItemArray[0]);
                AnlasmaHizmetBedelleri anlasmahizmetbedeli = AnlasmaHizmetBedelleri.GetObject(AnlasmaHizmetBedeliID);

                if (anlasmahizmetbedeli.intAnlasmaBedelID > 0)
                {
                    MessageBox.Show("Hizmet bedeli kapatıldığından düzenlenemez.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (MessageBox.Show("Hizmet bedeli güncellenecek, devam etmek istediğinize emin misiniz?", "Güncelleme", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                    {
                        try
                        {
                            anlasmahizmetbedeli.strFaturaNo = txtFatNo.Text.Trim();
                            anlasmahizmetbedeli.dtFaturaTarih = dtpFatTar.Value;
                            anlasmahizmetbedeli.intAnlasmaBedelAdID = ((AnlasmaBedelAdlari)cmbAnlasmaBedelAdlari.SelectedItem).pkID;
                            anlasmahizmetbedeli.intAy = Convert.ToInt32(txtAy.Text);
                            anlasmahizmetbedeli.intYil = Convert.ToInt32(txtYil.Text);
                            anlasmahizmetbedeli.mnTAHBedel = Convert.ToDecimal(txtTAHBedel.Text.Replace(".", ""));
                            anlasmahizmetbedeli.mnYEGBedel = Convert.ToDecimal(txtYEGBedel.Text.Replace(".", ""));
                            //anlasmahizmetbedeli.SMREF = ((CariHesaplarTP)cmbAltCariler.SelectedItem).SMREF;
                            anlasmahizmetbedeli.strAciklama1 = txtAciklama1.Text.Trim();
                            anlasmahizmetbedeli.mnMudurButce = Convert.ToDecimal(txtMudurButcesi.Text.Replace(".", ""));
                            anlasmahizmetbedeli.mnElemanButce = Convert.ToDecimal(txtElemanButcesi.Text.Replace(".", ""));
                            anlasmahizmetbedeli.blKapamaEtki = cbKapamaEtki.Checked;

                            anlasmahizmetbedeli.DoUpdate();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Seçimlerde eksik seçim var.\r\n\r\nHata ayrıntısı: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
        }

        private void sbSil_Click(object sender, EventArgs e)
        {
            if (gridView4.SelectedRowsCount > 0 && !gridView4.IsFilterRow(gridView4.GetSelectedRows()[0]))
            {
                int AnlasmaHizmetBedeliID = Convert.ToInt32(((DataRowView)gridControl4.MainView.GetRow(gridView4.GetSelectedRows()[0])).Row.ItemArray[0]);
                AnlasmaHizmetBedelleri anlasmahizmetbedeli = AnlasmaHizmetBedelleri.GetObject(AnlasmaHizmetBedeliID);

                if (anlasmahizmetbedeli.intAnlasmaBedelID > 0)
                {
                    MessageBox.Show("Hizmet bedeli kapatıldığından silinemez.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (MessageBox.Show("Hizmet bedeli silinecek, devam etmek istediğinize emin misiniz?", "Silme", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                    {
                        anlasmahizmetbedeli.DoDelete();
                        GetHizmetBedelleri();
                    }
                }
            }
        }

        private void txtAy_TextChanged(object sender, EventArgs e)
        {
            //try { Convert.ToInt32(((TextBox)sender).Text); }
            //catch (Exception) { ((TextBox)sender).Text = "0"; }
        }

        private void txtTAHBedel_TextChanged(object sender, EventArgs e)
        {
            //try { Convert.ToDecimal(((TextBox)sender).Text); }
            //catch (Exception) { ((TextBox)sender).Text = "0,00"; }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (!Acilis)
                GetHizmetBedelleri();
        }

        private void rbHepsi_CheckedChanged(object sender, EventArgs e)
        {
            GetHizmetBedelleri();
        }

        private void gridView4_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            GetHizmetBedeli();
        }

        private void sbExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel dosyaları (*.xlsx)|*.xlsx;|Bütün Dosyalar|*.*";
            if (sfd.ShowDialog() == DialogResult.OK)
                gridControl4.ExportToXlsx(sfd.FileName);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Sultanlar.DatabaseObject.Internet;

namespace Sultanlar.UI
{
    public partial class frmINTERNETmalzemekategorimarka : DevComponents.DotNetBar.Metro.MetroAppForm
    {
        public frmINTERNETmalzemekategorimarka()
        {
            InitializeComponent();
        }

        System.Timers.Timer tmr;

        private void frmINTERNETmalzemekategorimarka_Load(object sender, EventArgs e)
        {
            GetMarkalar();
            GetCinsiyetler();
            GetKategoriler();
            GetProducts();

            KeyPreview = true;

            tmr = new System.Timers.Timer(1000);
            tmr.Elapsed += new System.Timers.ElapsedEventHandler(tmr_Elapsed);
            LabelRenk(false);
        }

        void tmr_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            LabelRenk(false);
            tmr.Stop();
        }

        private void LabelRenk(bool Yesil)
        {
            if (Yesil)
            {
                label1.BackColor = Color.SeaGreen;
                label1.ForeColor = Color.SeaGreen;
            }
            else
            {
                label1.BackColor = Color.DarkRed;
                label1.ForeColor = Color.DarkRed;
            }

            ceTumune.ForeColor = Color.White;
            splitContainer1.Panel1.BackColor = Color.White;
            splitContainer1.Panel2.BackColor = Color.White;
        }

        private void GetMarkalar()
        {
            MalzemeKategoriMarka.GetMarkalar(cbeMarkalar.Properties.Items);
            cbeMarkalar.SelectedIndex = -1;
        }

        private void GetCinsiyetler()
        {
            MalzemeKategoriMarka.GetCinsiyetler(cbeCinsiyet.Properties.Items);
            cbeCinsiyet.SelectedIndex = -1;
        }

        private void GetKategoriler()
        {
            MalzemeKategoriMarka.GetAnaKategoriler(lbcKategori1.Items);
            lbcKategori1.SelectedIndex = -1;
        }

        private void GetProducts()
        {
            DataTable dt = new DataTable();
            Urunler.GetProducts(dt);
            gridControl1.DataSource = dt;
            labelItem1.Text = "Satýr Sayýsý: " + dt.Rows.Count.ToString();
            GetFirstRowData();
        }

        private void GetFirstRowData()
        {
            DataTable dt = (DataTable)MalzemeKategoriMarka.GetBaglanti(Convert.ToInt32(((DataRowView)gridControl1.MainView.GetRow(0)).Row.ItemArray[1].ToString()));

            if (dt.Rows.Count == 1)
            {
                teAciklama.Text = dt.Rows[0]["ACIKLAMA"].ToString();

                for (int j = 0; j < cbeMarkalar.Properties.Items.Count; j++)
                    if (((Marka)cbeMarkalar.Properties.Items[j]).REF == Convert.ToInt32(dt.Rows[0]["MARKAREF"]))
                        cbeMarkalar.SelectedIndex = j;

                for (int j = 0; j < cbeCinsiyet.Properties.Items.Count; j++)
                    if (((Cinsiyet)cbeCinsiyet.Properties.Items[j]).REF == Convert.ToInt32(dt.Rows[0]["CINSIYETREF"]))
                        cbeCinsiyet.SelectedIndex = j;

                int ustref = MalzemeKategoriMarka.GetUSTREF(Convert.ToInt32(dt.Rows[0]["KATEGORIREF"]));

                for (int j = 0; j < lbcKategori1.Items.Count; j++)
                {
                    if (((ReyonKategori)lbcKategori1.Items[j]).REF == ustref)
                    {
                        lbcKategori1.SelectedIndex = j;

                        for (int i = 0; i < lbcKategori2.Items.Count; i++)
                        {
                            if (((ReyonKategori)lbcKategori2.Items[i]).REF.ToString() == dt.Rows[0]["KATEGORIREF"].ToString())
                            {
                                lbcKategori2.SelectedIndex = i;
                            }
                        }
                    }
                }
            }
        }

        private void gridView1_ColumnFilterChanged(object sender, EventArgs e)
        {
            labelItem1.Text = "Satýr Sayýsý: " + gridControl1.MainView.DataRowCount.ToString();
        }

        private void lbcKategori1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbcKategori1.SelectedIndex > -1)
                MalzemeKategoriMarka.GetAltKategoriler(lbcKategori2.Items, ((ReyonKategori)lbcKategori1.SelectedItem).REF);
            else
                lbcKategori2.Items.Clear();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            teAciklama.Text = string.Empty;
            cbeMarkalar.SelectedIndex = -1;
            cbeCinsiyet.SelectedIndex = -1;
            lbcKategori1.SelectedIndex = -1;
            lbcKategori2.Items.Clear();

            if (e.FocusedRowHandle < 0)
                return;

            DataTable dt = (DataTable)MalzemeKategoriMarka.GetBaglanti(Convert.ToInt32(((DataRowView)gridControl1.MainView.GetRow(e.FocusedRowHandle)).Row.ItemArray[1].ToString()));

            if (dt.Rows.Count == 1)
            {
                teAciklama.Text = dt.Rows[0]["ACIKLAMA"].ToString().Replace("<br>", "\r\n");

                for (int j = 0; j < cbeMarkalar.Properties.Items.Count; j++)
                    if (((Marka)cbeMarkalar.Properties.Items[j]).REF == Convert.ToInt32(dt.Rows[0]["MARKAREF"]))
                        cbeMarkalar.SelectedIndex = j;

                for (int j = 0; j < cbeCinsiyet.Properties.Items.Count; j++)
                    if (((Cinsiyet)cbeCinsiyet.Properties.Items[j]).REF == Convert.ToInt32(dt.Rows[0]["CINSIYETREF"]))
                        cbeCinsiyet.SelectedIndex = j;

                int ustref = MalzemeKategoriMarka.GetUSTREF(Convert.ToInt32(dt.Rows[0]["KATEGORIREF"]));

                for (int j = 0; j < lbcKategori1.Items.Count; j++)
                {
                    if (((ReyonKategori)lbcKategori1.Items[j]).REF == ustref)
                    {
                        lbcKategori1.SelectedIndex = j;

                        for (int i = 0; i < lbcKategori2.Items.Count; i++)
                        {
                            if (((ReyonKategori)lbcKategori2.Items[i]).REF.ToString() == dt.Rows[0]["KATEGORIREF"].ToString())
                            {
                                lbcKategori2.SelectedIndex = i;
                            }
                        }
                    }
                }
            }
        }

        private void sbKategori1Temizle_Click(object sender, EventArgs e)
        {
            lbcKategori1.SelectedIndex = -1;
        }

        private void sbKategori2Temizle_Click(object sender, EventArgs e)
        {
            lbcKategori2.SelectedIndex = -1;
        }

        private void sbMarkaTemizle_Click(object sender, EventArgs e)
        {
            cbeMarkalar.SelectedIndex = -1;
        }

        private void sbAciklamaTemizle_Click(object sender, EventArgs e)
        {
            teAciklama.Text = string.Empty;
        }

        private void sbCinsiyetTemizle_Click(object sender, EventArgs e)
        {
            cbeCinsiyet.SelectedIndex = -1;
        }

        private void sbKaydet_Click(object sender, EventArgs e)
        {
            if (!ceTumune.Checked && gridView1.GetSelectedRows()[0] < 0)
                return;

            LabelRenk(true);

            int MarkaID = cbeMarkalar.SelectedIndex == -1 ? 0 : ((Marka)cbeMarkalar.SelectedItem).REF;
            int CinsiyetID = cbeCinsiyet.SelectedIndex == -1 ? 0 : ((Cinsiyet)cbeCinsiyet.SelectedItem).REF;
            int KategoriID = lbcKategori2.SelectedIndex == -1 ? 0 : ((ReyonKategori)lbcKategori2.SelectedItem).REF;
            
            string Marka = cbeMarkalar.SelectedIndex == -1 ? "" : ((Marka)cbeMarkalar.SelectedItem).MARKA;
            string Cinsiyet = cbeCinsiyet.SelectedIndex == -1 ? "" : ((Cinsiyet)cbeCinsiyet.SelectedItem).CINSIYET;
            string AnaKategori = lbcKategori1.SelectedIndex == -1 ? "" : ((ReyonKategori)lbcKategori1.SelectedItem).KATEGORI;
            string Kategori = lbcKategori2.SelectedIndex == -1 ? "" : ((ReyonKategori)lbcKategori2.SelectedItem).KATEGORI;

            if (ceTumune.Checked)
            {
                if (DevComponents.DotNetBar.MessageBoxEx.Show("Ýþlem, ekranda olan bütün ürünlere uygulanacaktýr. Devam etmek istediðinize emin misiniz?", "Devam", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    for (int i = 0; i < gridControl1.MainView.RowCount; i++)
                    {
                        MalzemeKategoriMarka.DoInsertUpdate(
                            Convert.ToInt32(((DataRowView)gridControl1.MainView.GetRow(i)).Row.ItemArray[1]),
                            KategoriID, MarkaID, CinsiyetID, teAciklama.Text.Trim().Replace("\r\n", "<br>"), frmAna.KAdi.ToUpper());

                        gridView1.SetRowCellValue(i, "BILGILI", 1);
                        gridView1.SetRowCellValue(i, "USTKATEGORI", AnaKategori);
                        gridView1.SetRowCellValue(i, "KATEGORI", Kategori);
                        gridView1.SetRowCellValue(i, "MARKA", Marka);
                        gridView1.SetRowCellValue(i, "CINSIYET", Cinsiyet);
                    }
                }
            }
            else
            {
                MalzemeKategoriMarka.DoInsertUpdate(
                    Convert.ToInt32(((DataRowView)gridControl1.MainView.GetRow(gridView1.GetSelectedRows()[0])).Row.ItemArray[1]),
                    KategoriID, MarkaID, CinsiyetID, teAciklama.Text.Trim().Replace("\r\n", "<br>"), frmAna.KAdi.ToUpper());

                gridView1.SetRowCellValue(gridView1.GetSelectedRows()[0], "BILGILI", 1);
                gridView1.SetRowCellValue(gridView1.GetSelectedRows()[0], "USTKATEGORI", AnaKategori);
                gridView1.SetRowCellValue(gridView1.GetSelectedRows()[0], "KATEGORI", Kategori);
                gridView1.SetRowCellValue(gridView1.GetSelectedRows()[0], "MARKA", Marka);
                gridView1.SetRowCellValue(gridView1.GetSelectedRows()[0], "CINSIYET", Cinsiyet);
            }

            tmr.Start();
        }

        private void frmINTERNETmalzemekategorimarka_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
                sbKaydet.PerformClick();
        }

        private void sbAnaKategoriEkle_Click(object sender, EventArgs e)
        {
            frmINTERNETmalzemekategorimarkakategori frm = new frmINTERNETmalzemekategorimarkakategori();
            LabelRenk(false);
            frm.ShowDialog();
            this.Refresh();
            LabelRenk(false);
            GetKategoriler();
        }

        private void sbAltKategoriEkle_Click(object sender, EventArgs e)
        {
            if (lbcKategori1.SelectedIndex > -1)
            {
                frmINTERNETmalzemekategorimarkakategori frm = new frmINTERNETmalzemekategorimarkakategori(((ReyonKategori)lbcKategori1.SelectedItem).REF, ((ReyonKategori)lbcKategori1.SelectedItem).KATEGORI);
                LabelRenk(false);
                frm.ShowDialog();
                this.Refresh();
                LabelRenk(false);
                MalzemeKategoriMarka.GetAltKategoriler(lbcKategori2.Items, ((ReyonKategori)lbcKategori1.SelectedItem).REF);
            }
        }

        private void sbMarkaEkle_Click(object sender, EventArgs e)
        {
            frmINTERNETmalzemekategorimarkakategori frm = new frmINTERNETmalzemekategorimarkakategori(true);
            LabelRenk(false);
            frm.ShowDialog();
            this.Refresh();
            LabelRenk(false);
            GetMarkalar();
        }

        private void sbCinsiyetEkle_Click(object sender, EventArgs e)
        {
            frmINTERNETmalzemekategorimarkakategori frm = new frmINTERNETmalzemekategorimarkakategori(true, true);
            LabelRenk(false);
            frm.ShowDialog();
            this.Refresh();
            LabelRenk(false);
            GetCinsiyetler();
        }

        private void metroTabItem3_Click(object sender, EventArgs e)
        {
            this.Refresh();
        }

        private void frmINTERNETmalzemekategorimarka_Activated(object sender, EventArgs e)
        {
            this.Refresh();
        }

        private void buttonItem2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmINTERNETmalzemekategorimarka_SizeChanged(object sender, EventArgs e)
        {
            labelControl1.Location = new Point(this.Size.Width - 27, labelControl1.Location.Y);
            lbcKategori1.Height = this.Height - 274;
            lbcKategori2.Height = this.Height - 274;
            sbKaydet.Location = new Point(sbKaydet.Location.X, splitContainer1.Height - 25);
            label1.Location = new Point(label1.Location.X, splitContainer1.Height - 21);
        }

        private void buttonItem1_Click(object sender, EventArgs e)
        {
            if (buttonItem1.Text == "BÜYÜT")
            {
                this.WindowState = FormWindowState.Maximized;
                buttonItem1.Text = "KÜÇÜLT";

                sbKaydet.Location = new Point(sbKaydet.Location.X, splitContainer1.Height - 23);
                label1.Location = new Point(label1.Location.X, splitContainer1.Height - 19);
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                buttonItem1.Text = "BÜYÜT";
            }
        }
    }
}
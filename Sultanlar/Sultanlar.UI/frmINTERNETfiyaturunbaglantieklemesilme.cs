using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sultanlar.DatabaseObject.Internet;
using System.Collections;

namespace Sultanlar.UI
{
    public partial class frmINTERNETfiyaturunbaglantieklemesilme : Form
    {
        public frmINTERNETfiyaturunbaglantieklemesilme()
        {
            InitializeComponent();
        }

        private void frmINTERNETfiyaturunbaglantieklemesilme_Load(object sender, EventArgs e)
        {
            GetFiyatTipleri();
            comboBox1.SelectedIndex = 0;
        }

        private void GetFiyatTipleri()
        {
            FiyatTipleri.GetObject(comboBox1.Items, true);

            ArrayList silinecekler = new ArrayList();
            for (int i = 0; i < comboBox1.Items.Count; i++)
                if (((FiyatTipleri)comboBox1.Items[i]).NOSU < 500)
                    silinecekler.Add(comboBox1.Items[i]);
            for (int i = 0; i < silinecekler.Count; i++)
                comboBox1.Items.Remove(silinecekler[i]);
        }

        private void GetFiyatlar()
        {
            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();
            FiyatTipUrun.GetOlanlar(dt1, ((FiyatTipleri)comboBox1.SelectedItem).NOSU);
            FiyatTipUrun.GetOlmayanlar(dt2, ((FiyatTipleri)comboBox1.SelectedItem).NOSU);
            gridControl1.DataSource = dt1;
            gridControl2.DataSource = dt2;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetFiyatlar();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (gridView2.SelectedRowsCount > 0 && !gridView2.IsFilterRow(gridView2.GetSelectedRows()[0]))
            {
                int TIP = Convert.ToInt32(gridView2.GetFocusedRowCellValue("TIP"));
                int ITEMREF = Convert.ToInt32(gridView2.GetFocusedRowCellValue("ITEMREF"));
                FiyatTipUrun ftp = new FiyatTipUrun(TIP, ITEMREF);
                ftp.DoInsert();
                GetFiyatlar();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (gridView1.SelectedRowsCount > 0 && !gridView1.IsFilterRow(gridView1.GetSelectedRows()[0]))
            {
                int TIP = Convert.ToInt32(gridView1.GetFocusedRowCellValue("TIP"));
                int ITEMREF = Convert.ToInt32(gridView1.GetFocusedRowCellValue("ITEMREF"));
                FiyatTipUrun.DoDelete(TIP, ITEMREF);
                GetFiyatlar();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Ürünlerin tümünü eklemek istediğinize emin misiniz?", "Toplu Ekleme", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
            {
                for (int i = 0; i < gridView2.RowCount; i++)
                {
                    int TIP = Convert.ToInt32(gridView2.GetRowCellValue(i, "TIP"));
                    int ITEMREF = Convert.ToInt32(gridView2.GetRowCellValue(i, "ITEMREF"));
                    FiyatTipUrun ftp = new FiyatTipUrun(TIP, ITEMREF);
                    ftp.DoInsert();
                }
                MessageBox.Show("Bütün ürünler eklendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GetFiyatlar();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Ürünlerin tümünü çıkarmak istediğinize emin misiniz?", "Toplu Çıkarma", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
            {
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    int TIP = Convert.ToInt32(gridView1.GetRowCellValue(i, "TIP"));
                    int ITEMREF = Convert.ToInt32(gridView1.GetRowCellValue(i, "ITEMREF"));
                    FiyatTipUrun.DoDelete(TIP, ITEMREF);
                }
                MessageBox.Show("Bütün ürünler çıkarıldı.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GetFiyatlar();
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            if (gridView1.SelectedRowsCount > 0 && !gridView1.IsFilterRow(gridView1.GetSelectedRows()[0]))
            {
                button1.PerformClick();
            }
        }

        private void gridView2_DoubleClick(object sender, EventArgs e)
        {
            if (gridView2.SelectedRowsCount > 0 && !gridView2.IsFilterRow(gridView2.GetSelectedRows()[0]))
            {
                button2.PerformClick();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            frmInputBox frm = new frmInputBox("Ürün Kodu Giriniz");
            frm.ShowDialog();
            if (frmAna.InputBox != string.Empty)
            {
                if (Urunler.GetProductName(Convert.ToInt32(frmAna.InputBox), true) != string.Empty)
                {
                    for (int i = 0; i < comboBox1.Items.Count; i++)
                    {
                        decimal fiyat = Urunler.GetProductPrice(Convert.ToInt32(frmAna.InputBox), ((FiyatTipleri)comboBox1.Items[i]).NOSU);
                        if (fiyat != 0)
                        {
                            int TIP = Convert.ToInt32(((FiyatTipleri)comboBox1.Items[i]).NOSU);
                            int ITEMREF = Convert.ToInt32(frmAna.InputBox);
                            FiyatTipUrun ftp = new FiyatTipUrun(TIP, ITEMREF);
                            ftp.DoInsert();
                        }
                    }
                    GetFiyatlar();
                    MessageBox.Show("Ürün, SAP'da fiyatı girilmiş bütün fiyat tiplerine eklendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Ürün kodu geçerli değil.", "Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("İşlem iptal edildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}

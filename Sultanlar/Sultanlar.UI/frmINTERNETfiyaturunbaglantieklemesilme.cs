using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Sultanlar.DbObj.Internet;
using Sultanlar.DatabaseObject.Internet;

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
            GetBayiler();
            GetFiyatTipleri();
            comboBox1.SelectedIndex = 0;
        }

        private void GetBayiler()
        {
            List<CariHesaplarTP> list = new List<CariHesaplarTP>();
            CariHesaplarTP.GetObjects(list, 0);

            comboBox2.DataSource = list;
        }

        private void GetAltCariler()
        {
            comboBox3.Text = string.Empty;
            if (comboBox2.SelectedIndex > -1)
                CariHesaplarTP.GetObjects(comboBox3.Items, ((CariHesaplarTP)comboBox2.SelectedItem).GMREF);
        }

        private void GetAltCariSubeler()
        {
            comboBox4.Text = string.Empty;
            if (comboBox3.SelectedIndex > -1)
                CariHesapZ.GetObjects(comboBox4.Items, 5, ((CariHesaplarTP)comboBox3.SelectedItem).SMREF);
        }

        private void GetAltCariSulSubeler(int GMREF)
        {
            comboBox6.Text = string.Empty;
            CariHesaplar.GetSUBEs(comboBox6.Items, GMREF);
        }

        private void GetFiyatTipleri()
        {
            new fiyatTipleri().GetObjects(comboBox1.Items);

            ArrayList silinecekler = new ArrayList();
            for (int i = 0; i < comboBox1.Items.Count; i++)
                if (((fiyatTipleri)comboBox1.Items[i]).NOSU < 500)
                    silinecekler.Add(comboBox1.Items[i]);
            for (int i = 0; i < silinecekler.Count; i++)
                comboBox1.Items.Remove(silinecekler[i]);

            label7.Text = string.Empty;
        }

        private void GetFiyatTipleri2(int GMREF, int MTIP)
        {
            gridControl1.DataSource = null;
            gridControl2.DataSource = null;
            new fiyatTipleri().GetObjects(comboBox1.Items, GMREF, MTIP);

            button8.Visible = comboBox1.Items.Count == 0;
        }

        private void GetFiyatlar()
        {
            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();
            if (((fiyatTipleri)comboBox1.SelectedItem).NOSU < 5000)
            {
                FiyatTipUrun.GetOlanlar(dt1, ((fiyatTipleri)comboBox1.SelectedItem).NOSU);
                FiyatTipUrun.GetOlmayanlar(dt2, ((fiyatTipleri)comboBox1.SelectedItem).NOSU);
            }
            else
            {
                FiyatTipUrun.GetOlanlar5000(dt1, ((fiyatTipleri)comboBox1.SelectedItem).NOSU);
                FiyatTipUrun.GetOlmayanlar5000(dt2, ((fiyatTipleri)comboBox1.SelectedItem).NOSU, ((fiyatTipleri)comboBox1.SelectedItem).GetAnaGmrefNo());
            }
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
                int TIP = ((fiyatTipleri)comboBox1.SelectedItem).NOSU; //Convert.ToInt32(gridView2.GetFocusedRowCellValue("TIP"))
                int ITEMREF = Convert.ToInt32(gridView2.GetFocusedRowCellValue("ITEMREF"));

                if (((fiyatTipleri)comboBox1.SelectedItem).NOSU < 5000)
                {
                    FiyatTipUrun ftp = new FiyatTipUrun(TIP, ITEMREF, frmAna.KAdi);
                    ftp.DoInsert();
                }
                else
                {
                    FiyatTipUrun.DoInsert5000(TIP, ITEMREF, ((fiyatTipleri)comboBox1.SelectedItem).GetAnaGmrefNo(), frmAna.KAdi);
                }
                GetFiyatlar();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (gridView1.SelectedRowsCount > 0 && !gridView1.IsFilterRow(gridView1.GetSelectedRows()[0]))
            {
                int TIP = ((fiyatTipleri)comboBox1.SelectedItem).NOSU; //Convert.ToInt32(gridView2.GetFocusedRowCellValue("TIP"))
                int ITEMREF = Convert.ToInt32(gridView1.GetFocusedRowCellValue("ITEMREF"));
                if (((fiyatTipleri)comboBox1.SelectedItem).NOSU < 5000)
                {
                    FiyatTipUrun.DoDelete(TIP, ITEMREF, frmAna.KAdi);
                }
                else
                {
                    FiyatTipUrun.DoDelete5000(TIP, ITEMREF, frmAna.KAdi);
                }
                GetFiyatlar();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Ürünlerin tümünü eklemek istediğinize emin misiniz?", "Toplu Ekleme", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
            {
                for (int i = 0; i < gridView2.RowCount; i++)
                {
                    int TIP = ((fiyatTipleri)comboBox1.SelectedItem).NOSU; //Convert.ToInt32(gridView2.GetRowCellValue(i, "TIP"))
                    int ITEMREF = Convert.ToInt32(gridView2.GetRowCellValue(i, "ITEMREF"));
                    if (((fiyatTipleri)comboBox1.SelectedItem).NOSU < 5000)
                    {
                        FiyatTipUrun ftp = new FiyatTipUrun(TIP, ITEMREF, frmAna.KAdi);
                        ftp.DoInsert();
                    }
                    else
                    {
                        FiyatTipUrun.DoInsert5000(TIP, ITEMREF, ((fiyatTipleri)comboBox1.SelectedItem).GetAnaGmrefNo(), frmAna.KAdi);
                    }
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
                    int TIP = ((fiyatTipleri)comboBox1.SelectedItem).NOSU; //Convert.ToInt32(gridView2.GetRowCellValue(i, "TIP"))
                    int ITEMREF = Convert.ToInt32(gridView1.GetRowCellValue(i, "ITEMREF"));
                    if (((fiyatTipleri)comboBox1.SelectedItem).NOSU < 5000)
                    {
                        FiyatTipUrun.DoDelete(TIP, ITEMREF, frmAna.KAdi);
                    }
                    else
                    {
                        FiyatTipUrun.DoDelete5000(TIP, ITEMREF, frmAna.KAdi);
                    }
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
                        int TIP = ((fiyatTipleri)comboBox1.Items[i]).NOSU;
                        int ITEMREF = Convert.ToInt32(frmAna.InputBox);

                        if (((fiyatTipleri)comboBox1.Items[i]).NOSU < 5000)
                        {
                            decimal fiyat = Urunler.GetProductPrice(Convert.ToInt32(frmAna.InputBox), Convert.ToInt16(((fiyatTipleri)comboBox1.Items[i]).NOSU));
                            if (fiyat != 0)
                            {
                                FiyatTipUrun ftp = new FiyatTipUrun(TIP, ITEMREF, frmAna.KAdi);
                                ftp.DoInsert();
                            }
                        }
                        else
                        {
                            FiyatTipUrun.DoInsert5000(TIP, ITEMREF, ((fiyatTipleri)comboBox1.Items[i]).GetAnaGmrefNo(), frmAna.KAdi);
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

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetAltCariler();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetAltCariSubeler();
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox5.SelectedIndex > -1)
                GetAltCariSulSubeler(((CariHesaplar)comboBox5.SelectedItem).GMREF);
            //GetAltCariSubeler(((CariHesaplar)comboBox5.SelectedItem).GMREF, 2);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            comboBox4.SelectedIndex = -1;
            comboBox4.Items.Clear();
            comboBox3.SelectedIndex = -1;
            comboBox3.Items.Clear();
            comboBox2.SelectedIndex = -1;
            comboBox6.SelectedIndex = -1;
            comboBox6.Items.Clear();
            comboBox5.SelectedIndex = -1;

            GetFiyatTipleri();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (comboBox4.SelectedIndex > -1)
            {
                GetFiyatTipleri2(((CariHesapZ)comboBox4.SelectedItem).GMREF, ((CariHesapZ)comboBox4.SelectedItem).TIP);
                label7.Text = "(" + comboBox2.SelectedItem.ToString() + " : " + comboBox3.SelectedItem.ToString() + " : " + comboBox4.SelectedItem.ToString() + ")";
                return;
            }

            if (checkBox1.Checked)
            {
                if (comboBox6.SelectedIndex > -1)
                {
                    GetFiyatTipleri2(((CariHesaplar)comboBox6.SelectedItem).SMREF, 1);
                    label7.Text = "(SULTANLAR PAZARLAMA : " + comboBox5.SelectedItem.ToString() + " : " + comboBox6.SelectedItem.ToString() + ")";
                }
                else if (comboBox5.SelectedIndex > -1)
                {
                    GetFiyatTipleri2(((CariHesaplar)comboBox5.SelectedItem).GMREF, 1);
                    label7.Text = "(SULTANLAR PAZARLAMA : " + comboBox5.SelectedItem.ToString() + ")";
                }
            }
            else
            {
                if (comboBox3.SelectedIndex > -1)
                {
                    GetFiyatTipleri2(((CariHesaplarTP)comboBox3.SelectedItem).SMREF, 4);
                    label7.Text = "(" + comboBox2.SelectedItem.ToString() + " : " + comboBox3.SelectedItem.ToString() + ")";
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            comboBox2.Enabled = !checkBox1.Checked;
            comboBox3.Enabled = !checkBox1.Checked;
            comboBox4.Enabled = !checkBox1.Checked;
            comboBox5.Enabled = checkBox1.Checked;
            comboBox6.Enabled = checkBox1.Checked;

            if (checkBox1.Checked)
            {
                CariHesaplar.GetMUSTERIs(comboBox5.Items, "", true);
                comboBox5.Text = string.Empty;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }
    }
}

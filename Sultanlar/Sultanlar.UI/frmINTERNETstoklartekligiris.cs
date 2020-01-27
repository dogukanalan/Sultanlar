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
    public partial class frmINTERNETstoklartekligiris : Form
    {
        public frmINTERNETstoklartekligiris()
        {
            InitializeComponent();
        }

        private void frmINTERNETstoklartekligiris_Load(object sender, EventArgs e)
        {
            GetFiyatTipleri();
            for (int i = 0; i < comboBox1.Items.Count; i++)
                if (comboBox1.Items[i].ToString() == DateTime.Now.Year.ToString())
                    comboBox1.SelectedIndex = i;
            for (int i = 0; i < comboBox2.Items.Count; i++)
                if (comboBox2.Items[i].ToString() == DateTime.Now.Month.ToString())
                    comboBox2.SelectedIndex = i;
        }

        private void GetFiyatTipleri()
        {
            FiyatTipleri.GetObjectAciklamali(comboBox3.Items, true);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int itemref = Convert.ToInt32(textBox1.Text.Trim());

                decimal oncekifiyat = FiyatlarTP.GetFiyat(itemref, ((FiyatTipleri)comboBox3.SelectedItem).NOSU, Convert.ToInt32(comboBox1.SelectedItem), Convert.ToInt32(comboBox2.SelectedItem));
                if (oncekifiyat > 0)
                {
                    MessageBox.Show("Girilen döneme, ürüne ve fiyat tipine ait bir fiyat zaten var. Varolan fiyat: " + oncekifiyat.ToString("C2"), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                double fiyat = Convert.ToDouble(textBox2.Text.Trim());
                double isk1 = Convert.ToDouble(textBox3.Text.Trim());
                double isk2 = Convert.ToDouble(textBox4.Text.Trim());
                double isk3 = Convert.ToDouble(textBox5.Text.Trim());
                double isk4 = Convert.ToDouble(textBox6.Text.Trim());
                double isk5 = Convert.ToDouble(textBox7.Text.Trim());
                double isk6 = Convert.ToDouble(textBox8.Text.Trim());
                double isk7 = Convert.ToDouble(textBox9.Text.Trim());
                double isk8 = Convert.ToDouble(textBox10.Text.Trim());
                double isk9 = Convert.ToDouble(textBox11.Text.Trim());
                double isk10 = Convert.ToDouble(textBox12.Text.Trim());

                double kdv = Urunler.GetProductKDV(itemref);
                double net = fiyat;
                if (isk1 != 0)
                    net = net - ((net / 100) * isk1);
                if (isk2 != 0)
                    net = net - ((net / 100) * isk2);
                if (isk3 != 0)
                    net = net - ((net / 100) * isk3);
                if (isk4 != 0)
                    net = net - ((net / 100) * isk4);
                if (isk5 != 0)
                    net = net - ((net / 100) * isk5);
                if (isk6 != 0)
                    net = net - ((net / 100) * isk6);
                if (isk7 != 0)
                    net = net - ((net / 100) * isk7);
                if (isk8 != 0)
                    net = net - ((net / 100) * isk8);
                if (isk9 != 0)
                    net = net - ((net / 100) * isk9);
                if (isk10 != 0)
                    net = net - ((net / 100) * isk10);
                double netkdv = net + ((net / 100) * kdv);

                FiyatlarTP.DoInsert(Convert.ToInt32(comboBox1.SelectedItem), Convert.ToInt32(comboBox2.SelectedItem),
                    ((FiyatTipleri)comboBox3.SelectedItem).NOSU, 0, Urunler.GetProductGRPKOD(itemref), Urunler.GetProductOzelKod(itemref),
                    Urunler.GetProductOzelAcik(itemref)[0].ToString(), Urunler.GetProductOzelAcik(itemref), Urunler.GetProductReyKod(itemref),
                    Urunler.GetProductReyAcik(itemref)[0].ToString(), Urunler.GetProductReyAcik(itemref), itemref, Urunler.GetProductName(itemref),
                    fiyat, isk1, isk2, isk3, isk4, isk5, isk6, isk7, isk8, isk9, isk10, net, netkdv, 
                    Urunler.GetProductVade(itemref, ((FiyatTipleri)comboBox3.SelectedItem).NOSU));

                MessageBox.Show("Fiyat başarıyla girilmiştir.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Girilen değerlerde hata var. Lütfen kontrol edip tekrar deneyiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}

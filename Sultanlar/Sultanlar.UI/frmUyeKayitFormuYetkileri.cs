using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sultanlar.DatabaseObject.Internet;
using Sultanlar.Class;

namespace Sultanlar.UI
{
    public partial class frmUyeKayitFormuYetkileri : Form
    {
        public frmUyeKayitFormuYetkileri()
        {
            InitializeComponent();
        }

        private void frmUyeKayitFormuYetkileri_Load(object sender, EventArgs e)
        {
            MusteriOnayDurumlari.GetObject(cmbDurumlar.Items, true);
        }

        private void cmbDurumlar_SelectedIndexChanged(object sender, EventArgs e)
        {
            YetkisizleriGetir();
        }

        private void YetkisizleriGetir()
        {
            Ag.DomainKullanicilariGetir(lbYetkisizler.Items);
            MusteriOnayDurumYetkileri.GetObjectByDurumID
                (lbYetkililer.Items, ((MusteriOnayDurumlari)cmbDurumlar.SelectedItem).pkDurumID, true);

            int[] kaldirilacakIndexler = new int[lbYetkisizler.Items.Count];

            for (int i = 0; i < lbYetkisizler.Items.Count; i++)
            {
                for (int k = 0; k < lbYetkililer.Items.Count; k++)
                {
                    if (lbYetkisizler.Items[i].ToString() == lbYetkililer.Items[k].ToString())
                    {
                        kaldirilacakIndexler[i] = 1;
                        k = lbYetkililer.Items.Count;
                    }
                    else
                    {
                        kaldirilacakIndexler[i] = 0;
                    }
                }
            }

            int j = 0;
            for (int i = 0; i < kaldirilacakIndexler.Length; i++)
            {
                if (kaldirilacakIndexler[i] == 1)
                {
                    lbYetkisizler.Items.RemoveAt(j);
                    j--;
                }
                j++;
            }
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (lbYetkisizler.SelectedIndex > -1)
            {
                MusteriOnayDurumYetkileri mody = new MusteriOnayDurumYetkileri(
                    ((MusteriOnayDurumlari)cmbDurumlar.SelectedItem).pkDurumID, lbYetkisizler.SelectedItem.ToString());
                mody.DoInsert();
                lbYetkililer.Items.Add(mody);
                lbYetkisizler.Items.RemoveAt(lbYetkisizler.SelectedIndex);
            }
            else
            {
                MessageBox.Show("Bir kişi seçilmedi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnKaldir_Click(object sender, EventArgs e)
        {
            if (lbYetkililer.SelectedIndex > -1)
            {
                MusteriOnayDurumYetkileri mody = (MusteriOnayDurumYetkileri)lbYetkililer.SelectedItem;
                mody.DoDelete();
                YetkisizleriGetir();
            }
            else
            {
                MessageBox.Show("Bir kişi seçilmedi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void lbYetkililer_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void lbYetkisizler_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void lbYetkisizler_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            btnEkle.PerformClick();
        }

        private void lbYetkililer_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            btnKaldir.PerformClick();
        }
    }
}

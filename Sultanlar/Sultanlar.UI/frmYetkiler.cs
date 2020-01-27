using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sultanlar.DatabaseObject;
using Sultanlar.Class;

namespace Sultanlar.UI
{
    public partial class frmYetkiler : Form
    {
        public frmYetkiler()
        {
            InitializeComponent();
        }
        //
        //
        //
        //
        //
        private void Yetkiler_Load(object sender, EventArgs e)
        {
            Formlar.GetObject(cmbFormlar.Items, true);

            //WebGenel.DoUpdateHavaDurumu(StringParcalama.HavaDurumu());

            //string DOVIZ = string.Empty;

            //try
            //{
            //    string[,] doviz = Doviz.DovizGetir();
            //    string[,] doviz2 = Doviz.DovizGetirAlternatif();
            //    DOVIZ = "SPDK - US: " + doviz2[0, 1] + " - " + doviz2[0, 2] + " | EU: " + doviz2[1, 1] + " - " + doviz2[1, 2] + "<br />"
            //        + "MBDK - US: " + doviz[0, 1] + " - " + doviz[0, 2] + " | EU: " + doviz[1, 1] + " - " + doviz[1, 2] + "<br />";
            //}
            //catch (Exception)
            //{

            //}

            //WebGenel.DoUpdateDoviz(DOVIZ);
        }

        private void cmbFormlar_SelectedIndexChanged(object sender, EventArgs e)
        {
            YetkisizleriGetir();
        }

        private void YetkisizleriGetir()
        {
            //Ag.DomainKullanicilariGetir(lbYetkisizler.Items);
            Kullanicilar.Get(lbYetkisizler.Items);
            Yetkiler.GetObjectByFormID(lbYetkililer.Items, ((Formlar)cmbFormlar.SelectedItem).pkFormID, true);

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
                Yetkiler ytk = new Yetkiler(((Formlar)cmbFormlar.SelectedItem).pkFormID, lbYetkisizler.SelectedItem.ToString());
                ytk.DoInsert();
                lbYetkililer.Items.Add(ytk);
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
                Yetkiler ytk = (Yetkiler)lbYetkililer.SelectedItem;
                ytk.DoDelete();
                YetkisizleriGetir();
            }
            else
            {
                MessageBox.Show("Bir kişi seçilmedi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void lbYetkisizler_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            btnEkle.PerformClick();
        }

        private void lbYetkililer_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            btnKaldir.PerformClick();
        }

        private void frmYetkiler_SizeChanged(object sender, EventArgs e)
        {
            cmbFormlar.Size = new System.Drawing.Size(this.Size.Width - 628, cmbFormlar.Size.Height);
            btnEkle.Size = new Size(this.Size.Width - 709, btnEkle.Size.Height);
            btnKaldir.Size = new Size(this.Size.Width - 709, btnKaldir.Size.Height);
        }
    }
}

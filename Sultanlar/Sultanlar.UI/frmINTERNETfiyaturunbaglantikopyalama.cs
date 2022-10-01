using Sultanlar.DbObj.Internet;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Sultanlar.UI
{
    public partial class frmINTERNETfiyaturunbaglantikopyalama : Form
    {
        public frmINTERNETfiyaturunbaglantikopyalama()
        {
            InitializeComponent();
        }

        IList ListeLocalIlk;
        IList ListeLocal;
        IList ListeLocal2;

        private void frmINTERNETfiyaturunbaglantikopyalama_Load(object sender, EventArgs e)
        {
            GetFromDb();
            FilterFiyatTipleri();
            FilterFiyatTipleri2();
        }

        private void GetFromDb()
        {
            ListeLocalIlk = new List<fiyatTipleri>();
            new fiyatTipleri().GetObjects(ListeLocalIlk);
        }

        private void GetFromLocal()
        {
            checkedListBox1.Items.Clear();
            for (int i = 0; i < ListeLocal.Count; i++)
            {
                checkedListBox1.Items.Add(ListeLocal[i]);
            }
        }

        private void GetFromLocal2()
        {
            checkedListBox2.Items.Clear();
            for (int i = 0; i < ListeLocal2.Count; i++)
            {
                checkedListBox2.Items.Add(ListeLocal2[i]);
            }
        }

        private void FilterFiyatTipleri()
        {
            ListeLocal = new List<fiyatTipleri>();
            for (int i = 0; i < ListeLocalIlk.Count; i++)
            {
                ListeLocal.Add(ListeLocalIlk[i]);
            }

            ArrayList silinecekler = new ArrayList();
            for (int i = 0; i < ListeLocal.Count; i++)
            {
                if (((fiyatTipleri)ListeLocal[i]).NOSU < 5000)
                {
                    silinecekler.Add(ListeLocal[i]);
                }
            }
            for (int i = 0; i < ListeLocal.Count; i++)
            {
                if (textBox1.Text.Trim() != string.Empty && ((fiyatTipleri)ListeLocal[i]).ACIKLAMA.ToLower().IndexOf(textBox1.Text.ToLower().Trim()) == -1)
                {
                    silinecekler.Add(ListeLocal[i]);
                }
            }
            for (int i = 0; i < silinecekler.Count; i++)
                ListeLocal.Remove(silinecekler[i]);

            label1.Text = ListeLocal.Count.ToString();
            GetFromLocal();
        }

        private void FilterFiyatTipleri2()
        {
            ListeLocal2 = new List<fiyatTipleri>();
            for (int i = 0; i < ListeLocalIlk.Count; i++)
            {
                ListeLocal2.Add(ListeLocalIlk[i]);
            }

            ArrayList silinecekler = new ArrayList();
            for (int i = 0; i < ListeLocal2.Count; i++)
            {
                if (((fiyatTipleri)ListeLocal2[i]).NOSU < 5000)
                {
                    silinecekler.Add(ListeLocal2[i]);
                }
            }
            for (int i = 0; i < ListeLocal2.Count; i++)
            {
                if (textBox2.Text.Trim() != string.Empty && ((fiyatTipleri)ListeLocal2[i]).ACIKLAMA.ToLower().IndexOf(textBox2.Text.ToLower().Trim()) == -1)
                {
                    silinecekler.Add(ListeLocal2[i]);
                }
            }
            for (int i = 0; i < silinecekler.Count; i++)
                ListeLocal2.Remove(silinecekler[i]);

            label2.Text = ListeLocal2.Count.ToString();
            GetFromLocal2();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FilterFiyatTipleri();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FilterFiyatTipleri2();
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button2.PerformClick();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("İşaretlenen " + checkedListBox1.CheckedItems.Count.ToString() + " kod sistemden silinecektir. Devam etmek istiyor musunuz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;

            for (int i = 0; i < checkedListBox1.CheckedItems.Count; i++)
            {
                //((fiyatTipleri)checkedListBox1.CheckedItems[i]).DoDelete();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmInputBox frm = new frmInputBox();
            frm.ShowDialog();
            string kopyalanacak = frmAna.InputBox;

            if (MessageBox.Show(kopyalanacak + " nolu cariye kopyalama yapılacaktır. Devam etmek istiyor musunuz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;

            GetFromDb();
            for (int i = 0; i < ListeLocalIlk.Count; i++)
            {
                if (((fiyatTipleri)ListeLocalIlk[i]).GMREF == Convert.ToInt32(kopyalanacak))
                {
                    MessageBox.Show(kopyalanacak + " nolu cariye ait fiyat listesi sistemde zaten var.");
                    return;
                }
            }

            int secilen = checkedListBox1.SelectedIndex > -1 ? ((fiyatTipleri)checkedListBox1.SelectedItem).NOSU : 0;
            if (secilen > 0)
            {
                
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Sultanlar.DatabaseObject.Internet;
using Sultanlar.DatabaseObject;

namespace Sultanlar.UI
{
    public partial class frmINTERNETticaripazarlamasatisraporaktarim : Form
    {
        public frmINTERNETticaripazarlamasatisraporaktarim(ArrayList veri)
        {
            InitializeComponent();
            for (int i = 0; i < veri.Count; i++)
                checkedListBox1.Items.Add((SatisRaporTP)veri[i]);
        }

        public int aktarilmamissayisi;

        private void frmINTERNETticaripazarlamasatisraporaktarim_Load(object sender, EventArgs e)
        {
            aktarilmamissayisi = checkedListBox1.Items.Count;
            label1.Text = aktarilmamissayisi.ToString();
        }

        private void sbAktar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seçilen kayıtların sistemde yeni bir alt nokta olarak açılmasını istediğinize emin misiniz?", "Alt cari ekleme", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
            {
                ArrayList eklenenler = new ArrayList();

                for (int i = 0; i < checkedListBox1.CheckedItems.Count; i++)
                {
                    int GMREF = CariHesaplarTP.GetGMREFByBAYIKOD(((SatisRaporTP)checkedListBox1.CheckedItems[i]).BAYIKOD);
                    CariHesaplarTP ch = new CariHesaplarTP();
                    ch.GMREF = GMREF;
                    ch.SMREF = CariHesaplarTP.GetLastSMREF() + 1;
                    ch.MUSTERI = ((SatisRaporTP)checkedListBox1.CheckedItems[i]).NOKTAAD;
                    ch.SUBE = ((SatisRaporTP)checkedListBox1.CheckedItems[i]).NOKTAAD;
                    ch.SUBKOD = DateTime.Now.ToString();
                    ch.IL = ((SatisRaporTP)checkedListBox1.CheckedItems[i]).IL;
                    ch.ILKOD = Iller.GetKODByIL(ch.IL).ToString();
                    ch.DoInsert();

                    eklenenler.Add(checkedListBox1.CheckedItems[i]);
                }

                for (int i = 0; i < eklenenler.Count; i++)
                {
                    for (int j = 0; j < checkedListBox1.Items.Count; j++)
                    {
                        if (((SatisRaporTP)checkedListBox1.Items[j]).NOKTAAD == ((SatisRaporTP)eklenenler[i]).NOKTAAD)
                        {
                            checkedListBox1.Items.RemoveAt(j);
                            break;
                        }
                    }
                }

                aktarilmamissayisi = checkedListBox1.Items.Count;
                label1.Text = aktarilmamissayisi.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkedListBox1.SelectedIndex > -1)
            {
                int GMREF = CariHesaplarTP.GetGMREFByBAYIKOD(((SatisRaporTP)checkedListBox1.SelectedItem).BAYIKOD);
                CariHesaplarTP.GetObjects(listBox1.Items, GMREF, textBox1.Text.Trim());
            }
            else
            {
                MessageBox.Show("Alt nokta seçimi yapılmadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Sistemde kayıtlı olan nokta ismi ve önceki satış raporlarında olan nokta ismi, satış raporundan gelen nokta adı ile eşleştirilsin mi?", "Eşleştirme", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
            {
                if (checkedListBox1.SelectedIndex > -1)
                {
                    if (listBox1.SelectedIndex > -1)
                    {
                        SatisRaporTP.DoUpdateNoktaAd(CariHesaplarTP.GetBAYIKODByGMREF(((CariHesaplarTP)listBox1.SelectedItem).GMREF), ((CariHesaplarTP)listBox1.SelectedItem).MUSTERI, ((SatisRaporTP)checkedListBox1.SelectedItem).NOKTAAD);

                        CariHesaplarTP ch = (CariHesaplarTP)listBox1.SelectedItem;
                        ch.MUSTERI = ((SatisRaporTP)checkedListBox1.SelectedItem).NOKTAAD;
                        ch.SUBE = ((SatisRaporTP)checkedListBox1.SelectedItem).NOKTAAD;
                        ch.IL = ((SatisRaporTP)checkedListBox1.SelectedItem).IL;
                        ch.ILKOD = Iller.GetKODByIL(ch.IL).ToString();
                        ch.DoUpdate();

                        checkedListBox1.Items.Remove(checkedListBox1.SelectedItem);

                        aktarilmamissayisi = checkedListBox1.Items.Count;
                        label1.Text = aktarilmamissayisi.ToString();

                        textBox1.Text = string.Empty;
                        listBox1.Items.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Cari seçimi yapılmadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Alt nokta seçimi yapılmadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void frmINTERNETticaripazarlamasatisraporaktarim_SizeChanged(object sender, EventArgs e)
        {
            sbAktar.Location = new Point(sbAktar.Location.X, lblAlt.Location.Y + 6);
            checkBox1.Location = new Point(checkBox1.Location.X, lblAlt.Location.Y + 10);
            label1.Location = new Point(label1.Location.X, lblAlt.Location.Y + 6);
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
        }

        private void frmINTERNETticaripazarlamasatisraporaktarim_FormClosing(object sender, FormClosingEventArgs e)
        {
            aktarilmamissayisi = checkedListBox1.Items.Count;
            label1.Text = aktarilmamissayisi.ToString();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
                checkedListBox1.SetItemChecked(i, checkBox1.Checked);
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
            listBox1.Items.Clear();
            textBox1.Enabled = checkedListBox1.SelectedIndex > -1;
            button1.Enabled = checkedListBox1.SelectedIndex > -1;
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex > -1)
            {
                button2.PerformClick();
            }
        }
    }
}

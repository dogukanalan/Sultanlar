using Sultanlar.DatabaseObject.Internet;
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
    public partial class frmINTERNETanketler : Form
    {
        public frmINTERNETanketler()
        {
            InitializeComponent();
        }

        private void frmINTERNETanketler_Load(object sender, EventArgs e)
        {
            var anketler = Anketler.GetObjects();
            for (int i = 0; i < anketler.Count; i++)
                listBox1.Items.Add(anketler[i]);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox1.SelectedIndex = -1;
            textBox1.Text = string.Empty;
            checkBox1.Checked = true;
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            button3.Text = "Ekle";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmInputBox frm = new frmInputBox();
            frm.ShowDialog();
            if (frmAna.InputBox != string.Empty)
                listBox2.Items.Add(new AnketSecimler(0, frmAna.InputBox));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedIndex > -1)
                listBox2.Items.RemoveAt(listBox2.SelectedIndex);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (button3.Text == "Ekle")
            {
                if (listBox2.Items.Count == 0)
                {
                    MessageBox.Show("Hiç seçim eklemediniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                Anketler anket = new Anketler(textBox1.Text, DateTime.Now, frmAna.KAdi, !checkBox1.Checked);
                anket.DoInsert();
                listBox1.Items.Add(anket);

                for (int i = 0; i < listBox2.Items.Count; i++)
                {
                    ((AnketSecimler)listBox2.Items[i]).intAnketID = anket.pkID;
                    ((AnketSecimler)listBox2.Items[i]).DoInsert();
                }

                MessageBox.Show("Anket eklendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Anketler anket = (Anketler)listBox1.SelectedItem;
                if (anket.Cevaplar.Count == 0)
                {
                    if (listBox2.Items.Count == 0)
                    {
                        MessageBox.Show("Hiç seçim eklemediniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    anket.strSoru = textBox1.Text.Trim();
                    anket.blPasif = !checkBox1.Checked;
                    anket.DoUpdate();
                    listBox1.SelectedItem = anket;

                    var secimler = AnketSecimler.GetObjects(anket.pkID);
                    for (int i = 0; i < secimler.Count; i++)
                        secimler[i].DoDelete();

                    for (int i = 0; i < listBox2.Items.Count; i++)
                    {
                        ((AnketSecimler)listBox2.Items[i]).intAnketID = anket.pkID;
                        ((AnketSecimler)listBox2.Items[i]).DoInsert();
                    }

                    MessageBox.Show("Anket güncellendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Anket cevaplandığından artık değiştirilemez.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex > -1)
            {
                button3.Text = "Güncelle";

                listBox2.Items.Clear();
                listBox3.Items.Clear();

                Anketler anket = (Anketler)listBox1.SelectedItem;
                textBox1.Text = anket.strSoru;
                for (int i = 0; i < anket.Secimler.Count; i++)
                    listBox2.Items.Add(anket.Secimler[i]);
                checkBox1.Checked = !anket.blPasif;
                for (int i = 0; i < anket.Cevaplar.Count; i++)
                    listBox3.Items.Add(anket.Cevaplar[i]);
            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex > -1 && listBox2.SelectedIndex > -1)
            {
                Anketler anket = (Anketler)listBox1.SelectedItem;
                var secim = (AnketSecimler)listBox2.SelectedItem;

                listBox3.Items.Clear();

                for (int i = 0; i < anket.Cevaplar.Count; i++)
                    listBox3.Items.Add(anket.Cevaplar[i]);

                ArrayList kaldirilacaklar = new ArrayList();
                for (int i = 0; i < listBox3.Items.Count; i++)
                    if (secim.pkID != ((AnketCevaplar)listBox3.Items[i]).intSecimID)
                        kaldirilacaklar.Add((AnketCevaplar)listBox3.Items[i]);

                for (int i = 0; i < kaldirilacaklar.Count; i++)
                    listBox3.Items.Remove(kaldirilacaklar[i]);
            }
        }
    }
}

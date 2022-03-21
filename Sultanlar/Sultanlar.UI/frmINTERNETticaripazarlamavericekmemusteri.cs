using Sultanlar.DatabaseObject;
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
    public partial class frmINTERNETticaripazarlamavericekmemusteri : Form
    {
        public frmINTERNETticaripazarlamavericekmemusteri(int Smref)
        {
            InitializeComponent();
            this.SMREF = Smref;
        }

        private int SMREF;
        private string sorgu;
        private string anasorgu;

        private void frmINTERNETticaripazarlamavericekmemusteri_Load(object sender, EventArgs e)
        {
            anasorgu = "SELECT DISTINCT 'False' AS [Secim],[CH_KOD],[CH_ACIKLAMA],[MUS KOD],MUSTERI,SATIS.IL,CASE WHEN SATIS.ILCE LIKE '%Merkez%' THEN SATIS.IL ELSE SATIS.ILCE END AS ILCE,SMREF FROM [dbo].[tbl_" + SMREF.ToString() + "_Satis] AS SATIS LEFT OUTER JOIN [KurumsalWebSAP].dbo.[Web-Musteri-TP] AS CARI ON SATIS.[CH_KOD] = CARI.[MUS KOD]";
            sorgu = anasorgu;
            GetData();
        }

        private void GetData()
        {
            checkBox2.Checked = false;
            DataTable dt = DisVeri.ExecDaRe(sorgu);
            dataGridView1.DataSource = dt;
            label11.Text = dt.Rows.Count.ToString();
        }

        private bool Eslestir(bool uyariver)
        {
            if (comboBox1.SelectedIndex > -1)
            {
                CariHesaplarTP ch = (CariHesaplarTP)comboBox1.SelectedItem;

                string yeninoktaadi = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                string il = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                string ilkod = Iller.GetKODByIL(il).ToString();
                string ilcekod = Ilceler.GetIDByILIDILCE(Iller.GetKODByIL(il), dataGridView1.SelectedRows[0].Cells[6].Value.ToString()).ToString();
                string ilce = ilcekod != "0" ? dataGridView1.SelectedRows[0].Cells[6].Value.ToString() : "";
                string muskod = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();

                if (CariHesaplarTP.GetNoktaVarMi2(muskod, ch.GMREF) != string.Empty) // müşteri kodu kayıtlı
                {
                    MessageBox.Show(muskod + " müşteri kodu başka bir müşteriye ait!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return false;
                }

                if (uyariver)
                {
                    if (MessageBox.Show("Kayıtlı olan\r\n\r\nKod: " + ch.MUSKOD + "\r\nCari: " + ch.MUSTERI + "\r\n\r\nnoktası\r\n\r\nKod: " + muskod + "\r\nCari: " + yeninoktaadi + "\r\n\r\nnoktası ile eşleşecektir.\r\nDevam etmek istediğinize emin misiniz?", "Alt cari eşleştirme", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.No)
                    {
                        return false;
                    }
                }

                SatisRaporTP.DoUpdateNoktaAd(CariHesaplarTP.GetBAYIKODByGMREF(SMREF), ((CariHesaplarTP)comboBox1.SelectedItem).MUSTERI, yeninoktaadi);
                SatisRaporTP.DoUpdateNoktaKod(CariHesaplarTP.GetBAYIKODByGMREF(SMREF), ((CariHesaplarTP)comboBox1.SelectedItem).MUSKOD, muskod);

                ch.MUSTERI = yeninoktaadi;
                ch.SUBE = yeninoktaadi;
                ch.IL = il;
                ch.ILKOD = ilkod;
                ch.ILCE = ilce;
                ch.ILCEKOD = ilcekod;
                ch.MUSKOD = muskod;
                ch.DoUpdate();

                dataGridView1.SelectedRows[0].Cells[3].Value = ch.MUSKOD;
                dataGridView1.SelectedRows[0].Cells[4].Value = ch.MUSTERI;
                dataGridView1.SelectedRows[0].Cells[7].Value = ch.SMREF;

                if (uyariver)
                    MessageBox.Show("Cari eşleştirildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return true;
            }
            else
            {
                return false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seçilen kayıtların sistemde yeni bir alt nokta olarak açılmasını istediğinize emin misiniz?", "Alt cari ekleme", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    CariHesaplarTP ch = new CariHesaplarTP();
                    ch.GMREF = SMREF;
                    ch.SMREF = CariHesaplarTP.GetLastSMREF() + 1;
                    ch.MUSTERI = dataGridView1.Rows[i].Cells[2].Value.ToString();
                    ch.SUBE = dataGridView1.Rows[i].Cells[2].Value.ToString();
                    ch.SUBKOD = DateTime.Now.ToString();
                    ch.IL = dataGridView1.Rows[i].Cells[5].Value.ToString();
                    ch.ILKOD = Iller.GetKODByIL(ch.IL).ToString();
                    ch.ILCEKOD = Ilceler.GetIDByILIDILCE(Iller.GetKODByIL(ch.IL), dataGridView1.Rows[i].Cells[6].Value.ToString()).ToString();
                    ch.ILCE = ch.ILCEKOD != "0" ? dataGridView1.Rows[i].Cells[6].Value.ToString() : "";
                    ch.MUSKOD = dataGridView1.Rows[i].Cells[1].Value.ToString();
                    ch.DoInsert();
                }
            }

            MessageBox.Show("Yeni cariler açıldı.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (checkBox1.Checked)
            {
                checkBox1.Checked = false;
            }
            else
            {
                GetData();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            sorgu = anasorgu + (checkBox1.Checked ? " WHERE [MUS KOD] IS NULL" : "");
            GetData();
            button4.Enabled = checkBox1.Checked;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].Cells[0].Value = checkBox2.Checked;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CariHesaplarTP.GetObjects(comboBox1.Items, SMREF, textBox1.Text);
            if (comboBox1.Items.Count > 0)
            {
                comboBox1.SelectedIndex = 0;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Eslestir(true);
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            comboBox1.Items.Clear();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button2.PerformClick();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Aynı isimde tek karşılığı olan nokta var ise otomatik eşleşecek. Devam etmek istediğinize emin misiniz?", "Alt cari eşleştirme", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    string aranan = dataGridView1.Rows[i].Cells[2].Value.ToString();
                    textBox1.Text = aranan;
                    CariHesaplarTP.GetObjects(comboBox1.Items, SMREF, aranan);
                    if (comboBox1.Items.Count == 1)
                    {
                        comboBox1.SelectedIndex = 0;
                        //Eslestir(false);
                        MessageBox.Show(comboBox1.Text);
                    }
                }
            }
        }
    }
}

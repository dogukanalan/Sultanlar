using DgvFilterPopup;
using Sultanlar.DatabaseObject.Internet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Sultanlar.UI
{
    public partial class frmINTERNETentegra : Form
    {
        public frmINTERNETentegra()
        {
            InitializeComponent();
        }

        private DgvFilterManager dgvfm;

        private void frmINTERNETentegra_Load(object sender, EventArgs e)
        {
            GetSiparisler();
        }

        private void GetSiparisler()
        {
            DataTable dt = new DataTable();
            Entegra.GetObjects(dt);
            dataGridView1.DataSource = dt;
            dgvfm = new DgvFilterManager(dataGridView1);
            dataGridView1.Columns["Ürün"].Width = 300;
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["SAP Cari Kod"].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string EntegraNo = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["Sip.No"].Value.ToString();
            int smref = Convert.ToInt32(textBox1.Text);
            List<EntegraSatir> satirlarGercek = Entegra.GetSatirlarGercek(EntegraNo);
            for (int index = 0; index < satirlarGercek.Count; ++index)
                Entegra.DoInsertSAP(EntegraNo, satirlarGercek[index].KOD, smref);
            dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["SAP Cari Kod"].Value = textBox1.Text;
            dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["SAP Cari"].Value = CariHesaplar.GetMUSTERIbySMREF(smref);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string Site = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["Site"].Value.ToString();
            string kargo = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["Kargo Kodu"].Value.ToString();
            string EntegraNo = this.dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["Sip.No"].Value.ToString();
            int smref = Convert.ToInt32(dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["SAP Cari Kod"].Value);

            if (MessageBox.Show(EntegraNo + " nolu sipariş SAP'ye gönderilecek. Devam etmek istiyor musunuz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                return;

            string aciklama = Site.Replace("n11", "N11").Replace("hb", "Hepsiburada").Replace("eptt", "Eptt").Replace("trendyol", "Trendyol").Replace("gg", "Gittigidiyor").Replace("ak", "Akakce") + "; Sip:" + EntegraNo + "_Kargo Kodu:" + kargo;
            if (smref > 0)
            {
                if (checkBox1.Checked)
                {
                    string text = Siparis.QuantumaYaz(EntegraNo, smref, aciklama);
                    List<EntegraSatir> satirlarGercek = Entegra.GetSatirlarGercek(EntegraNo);
                    for (int index = 0; index < satirlarGercek.Count; ++index)
                        Entegra.DoSAP(EntegraNo, satirlarGercek[index].KOD, 1);
                    MessageBox.Show(text);
                    dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["SAP Gönd."].Value = "1";
                }
                else
                {
                    int kod = Convert.ToInt32(dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["Ürün Kodu"].Value);
                    Siparis.QuantumaYaz(EntegraNo, smref, kod, aciklama);
                    Entegra.DoSAP(EntegraNo, kod, 1);
                }
            }
            else
            {
                MessageBox.Show("Cari tanımlaması yapılmamış.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Entegra.EntegraSiparis();
            GetSiparisler();
            MessageBox.Show("Aktarım tamamlandı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}

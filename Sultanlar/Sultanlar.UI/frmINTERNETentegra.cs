﻿using DgvFilterPopup;
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
using System.Xml;

namespace Sultanlar.UI
{
    public partial class frmINTERNETentegra : Form
    {
        public frmINTERNETentegra()
        {
            InitializeComponent();
        }

        private DgvFilterManager dgvfm;
        private Random rnd = new Random();

        private void frmINTERNETentegra_Load(object sender, EventArgs e)
        {
            button3.PerformClick();
        }

        private void GetSiparisler()
        {
            DataTable dt = new DataTable();
            Entegra.GetObjects(dt);
            dataGridView1.DataSource = dt;
            dgvfm = new DgvFilterManager(dataGridView1);
            dataGridView1.Columns["Ürün"].Width = 300;
            dataGridView1.Columns["Color"].Visible = false;

            if (dataGridView1.Columns[0].HeaderText != "Seç")
            {
                DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
                dataGridView1.Columns.Add(chk);
                chk.HeaderText = "Seç";
                chk.Name = "Seç";
                chk.DisplayIndex = 0;
                chk.Width = 50;
                dataGridView1.Rows[0].Cells["Seç"].Value = false;
            }



            string oncekisipno = "";
            int or = 0, og = 0, ob = 0;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Cells["Seç"].Value = false;

                string sipno = row.Cells["Sip.No"].Value.ToString();

                int r = rnd.Next(235, 256), g = rnd.Next(235, 256), b = rnd.Next(235, 256);
                Color color = Color.FromArgb(r, g, b);

                if (sipno == oncekisipno)
                {
                    r = or; g = og; b = ob;
                }

                color = Color.FromArgb(r, g, b);
                row.Cells["Color"].Value = color.ToArgb();

                or = r; og = g; ob = b;
                oncekisipno = row.Cells["Sip.No"].Value.ToString();
            }
        }

        private void SapGonder(int rowIndex, bool uyari)
        {
            string Site = dataGridView1.Rows[rowIndex].Cells["Site"].Value.ToString();
            string kargo = dataGridView1.Rows[rowIndex].Cells["Kargo Kodu"].Value.ToString();
            string EntegraNo = dataGridView1.Rows[rowIndex].Cells["Sip.No"].Value.ToString();
            int smref = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells["SAP Cari Kod"].Value);

            string aciklama = Site.Replace("n11", "N11").Replace("hb", "Hepsiburada").Replace("eptt", "Eptt").Replace("trendyol", "Trendyol").Replace("gg", "Gittigidiyor").Replace("ak", "Akakce") + "; Sip:" + EntegraNo + "_Kargo Kodu:" + kargo;
            if (smref > 0)
            {
                if (uyari)
                    if (MessageBox.Show(EntegraNo + " nolu sipariş SAP'ye gönderilecek. Devam etmek istiyor musunuz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                        return;

                if (checkBox1.Checked)
                {
                    string sapsipno = Siparis.QuantumaYaz(EntegraNo, smref, aciklama);
                    List<EntegraSatir> satirlarGercek = Entegra.GetSatirlarGercek(EntegraNo);
                    for (int index = 0; index < satirlarGercek.Count; ++index)
                        Entegra.DoSAP(EntegraNo, satirlarGercek[index].KOD, Convert.ToInt32(sapsipno));
                    if (uyari)
                        MessageBox.Show("Sipariş gönderildi. SAP numarası: " + sapsipno, "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    int kod = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells["Ürün Kodu"].Value);
                    string sapsipno = Siparis.QuantumaYaz(EntegraNo, smref, kod, aciklama);
                    Entegra.DoSAP(EntegraNo, kod, Convert.ToInt32(sapsipno));
                    if (uyari)
                        MessageBox.Show("Sipariş gönderildi. SAP numarası: " + sapsipno, "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                if (uyari)
                    GetSiparisler();
            }
            else
            {
                if (uyari)
                    MessageBox.Show("Cari tanımlaması yapılmamış.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
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
                if (!Entegra.SAPcariVarMi(EntegraNo, satirlarGercek[index].KOD))
                    Entegra.DoInsertSAP(EntegraNo, satirlarGercek[index].KOD, smref);
            dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["SAP Cari Kod"].Value = textBox1.Text;
            dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["SAP Cari"].Value = CariHesaplar.GetMUSTERIbySMREF(smref);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["SAP Sip."].Value.ToString() != "0")
            {
                MessageBox.Show("Bu sipariş daha önce gönderilmiş.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SapGonder(dataGridView1.SelectedCells[0].RowIndex, true);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Entegra.EntegraSiparis())
            {
                //MessageBox.Show("Entegra bağlantısı başarılı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                GetSiparisler();
            }
            else
            {
                MessageBox.Show("Entegraya erişilemedi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Excel dosyaları (*.xls, *.xlsx)|*.xls;*.xlsx;|Bütün Dosyalar|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Microsoft.Office.Interop.Excel.Application ap = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel.Workbook wb = null;
                Microsoft.Office.Interop.Excel.Worksheet ws = null;
                Microsoft.Office.Interop.Excel.Range range = null;

                object[,] values = null;

                try
                {
                    wb = ap.Workbooks.Open(ofd.FileName, false, true,
                        Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                        Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                        Type.Missing, Type.Missing, Type.Missing, true);

                    ws = (Microsoft.Office.Interop.Excel.Worksheet)wb.Worksheets[1];

                    range = ws.get_Range("A1", "BI6666");

                    values = (object[,])range.Value2;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Hata");
                }
                finally
                {
                    range = null;
                    ws = null;
                    if (wb != null)
                        wb.Close(false, System.Reflection.Missing.Value, System.Reflection.Missing.Value);
                    wb = null;
                    if (ap != null)
                        ap.Quit();
                    ap = null;
                }

                if (values != null)
                {
                    ArrayList carikodlar = new ArrayList();
                    ArrayList siparisnolar = new ArrayList();
                    for (int i = 2; i <= values.GetLength(0); i++)
                    {
                        if (values[i, 1] == null) // 1.kolon boş ise bu satırdan sonrasına bakmasın
                            break;

                        try
                        {
                            carikodlar.Add(Convert.ToInt32(values[i, 2]));
                            siparisnolar.Add(values[i, 10].ToString().Substring(values[i, 10].ToString().LastIndexOf(":") + 1));
                        }
                        catch (Exception ex)
                        {
                            carikodlar.Clear();
                            siparisnolar.Clear();
                            MessageBox.Show(ex.Message);
                        }
                    }

                    for (int i = 0; i < carikodlar.Count; i++)
                    {
                        string EntegraNo = siparisnolar[i].ToString();
                        int smref = Convert.ToInt32(carikodlar[i]);
                        List<EntegraSatir> satirlarGercek = Entegra.GetSatirlarGercek(EntegraNo);
                        for (int index = 0; index < satirlarGercek.Count; ++index)
                            if (!Entegra.SAPcariVarMi(EntegraNo, satirlarGercek[index].KOD))
                                Entegra.DoInsertSAP(EntegraNo, satirlarGercek[index].KOD, smref);
                    }

                    MessageBox.Show("Aktarım tamamlandı.", "Bitti", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GetSiparisler();
                }
            }
        }

        private void dataGridView1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.DefaultCellStyle.BackColor = Color.FromArgb(Convert.ToInt32(row.Cells["Color"].Value));
            }
        }

        private void btnYenile_Click(object sender, EventArgs e)
        {
            GetSiparisler();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (Convert.ToBoolean(row.Cells["Seç"].Value) && row.Cells["SAP Sip."].Value.ToString() == "0")
                {
                    if (Entegra.SAPsipNo(row.Cells["Sip.No"].Value.ToString(), Convert.ToInt32(row.Cells["Ürün Kodu"].Value)) == 0)
                        SapGonder(row.Index, false);
                }
            }

            GetSiparisler();
        }
    }
}

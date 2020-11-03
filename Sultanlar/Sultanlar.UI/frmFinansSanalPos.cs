using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sultanlar.DatabaseObject.Internet;
using System.IO;
using System.Net;

namespace Sultanlar.UI
{
    public partial class frmFinansSanalPos : Form
    {
        public frmFinansSanalPos()
        {
            InitializeComponent();
        }

        private void frmFinansSanalPos_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            GetCariHesaplar();
            GetObjects();
        }

        private void GetCariHesaplar()
        {

        }

        private void GetObjects()
        {
            DataTable dt = new DataTable();

            DateTime Baslangic = DateTime.MinValue;
            DateTime Bitis = DateTime.MaxValue;
            object Aktarildi = null;
            if (cbTarih.Checked)
            {
                Baslangic = dtpBaslangic.Value;
                Bitis = dtpBitis.Value;
            }
            if (rbAktarildiAktarilan.Checked || rbAktarildiAktarilmayan.Checked)
            {
                Aktarildi = rbAktarildiAktarilan.Checked;
            }

            Odemeler.GetObjects(dt, true, 0, 0, 0, txtMusteri.Text, Baslangic, Bitis, Aktarildi);
            dataGridView1.DataSource = dt;
        }

        private void GetBilgiler()
        {
            double tahtop = 0;

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
                tahtop += Convert.ToDouble(dataGridView1.Rows[i].Cells["clmnTutar"].Value.ToString());

            lblToplam.Text = tahtop.ToString("C2");
        }

        private void ExceleAktar(object filename)
        {
            Microsoft.Office.Interop.Excel.Application ap = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook wb = ap.Workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
            Microsoft.Office.Interop.Excel.Worksheet ws = (Microsoft.Office.Interop.Excel.Worksheet)wb.Worksheets[1];

            ((Microsoft.Office.Interop.Excel.Range)ws.Columns["A", Type.Missing]).ColumnWidth = 8.71;
            ((Microsoft.Office.Interop.Excel.Range)ws.Columns["B", Type.Missing]).ColumnWidth = 12.00;
            ((Microsoft.Office.Interop.Excel.Range)ws.Columns["C", Type.Missing]).ColumnWidth = 40.00;
            ((Microsoft.Office.Interop.Excel.Range)ws.Columns["D", Type.Missing]).ColumnWidth = 20.00;
            ((Microsoft.Office.Interop.Excel.Range)ws.Columns["E", Type.Missing]).ColumnWidth = 13.00;
            ((Microsoft.Office.Interop.Excel.Range)ws.Columns["F", Type.Missing]).ColumnWidth = 17.00;
            ((Microsoft.Office.Interop.Excel.Range)ws.Columns["G", Type.Missing]).ColumnWidth = 11.57;
            ((Microsoft.Office.Interop.Excel.Range)ws.Columns["H", Type.Missing]).ColumnWidth = 11.00;
            ((Microsoft.Office.Interop.Excel.Range)ws.Columns["I", Type.Missing]).ColumnWidth = 19.00;
            ((Microsoft.Office.Interop.Excel.Range)ws.Columns["J", Type.Missing]).ColumnWidth = 13.00;
            ((Microsoft.Office.Interop.Excel.Range)ws.Columns["K", Type.Missing]).ColumnWidth = 6.00;
            ((Microsoft.Office.Interop.Excel.Range)ws.Columns["L", Type.Missing]).ColumnWidth = 17;
            ((Microsoft.Office.Interop.Excel.Range)ws.Columns["M", Type.Missing]).ColumnWidth = 17;

            ((Microsoft.Office.Interop.Excel.Range)ws.Rows[1, Type.Missing]).Font.Bold = true;
            ((Microsoft.Office.Interop.Excel.Range)ws.Columns["B", Type.Missing]).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;

            ws.Cells[1, 1] = "Web Sip. No";
            ws.Cells[1, 2] = "Tutar";
            ws.Cells[1, 3] = "C/H Açıklaması";
            ws.Cells[1, 4] = "İşlem Yapan";
            ws.Cells[1, 5] = "Telefon";
            ws.Cells[1, 6] = "Ödeme Tarihi";
            ws.Cells[1, 7] = "Provizyon No";
            ws.Cells[1, 8] = "Referans No";
            ws.Cells[1, 9] = "İşlem No";
            ws.Cells[1, 10] = "Kredi Kartı";
            ws.Cells[1, 11] = "İşlendi";
            ws.Cells[1, 12] = "İşleyen";
            ws.Cells[1, 13] = "İşlenme Tarihi";

            progressBar1.Visible = true;
            progressBar1.Maximum = dataGridView1.Rows.Count;
            progressBar1.Value = 0;

            this.Enabled = false;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                progressBar1.Value = i;

                ws.Cells[i + 2, 1] = dataGridView1.Rows[i].Cells["clintSiparisID"].Value.ToString();
                ws.Cells[i + 2, 2] = Convert.ToDouble(dataGridView1.Rows[i].Cells["clmnTutar"].Value.ToString()).ToString("C2");
                ws.Cells[i + 2, 3] = dataGridView1.Rows[i].Cells["clMUSTERI"].Value.ToString();
                ws.Cells[i + 2, 4] = dataGridView1.Rows[i].Cells["clAdSoyad"].Value.ToString();
                ws.Cells[i + 2, 5] = dataGridView1.Rows[i].Cells["clstrTelefon"].Value.ToString();
                ws.Cells[i + 2, 6] = dataGridView1.Rows[i].Cells["cldtOdemeZamani"].Value.ToString();
                ws.Cells[i + 2, 7] = dataGridView1.Rows[i].Cells["clstrAuthCode"].Value.ToString();
                ws.Cells[i + 2, 8] = dataGridView1.Rows[i].Cells["clstrHostRefNum"].Value.ToString();
                ws.Cells[i + 2, 9] = dataGridView1.Rows[i].Cells["clstrTransID"].Value.ToString();
                ws.Cells[i + 2, 10] = dataGridView1.Rows[i].Cells["clstrMaskedPan"].Value.ToString();

                if (Convert.ToBoolean(dataGridView1.Rows[i].Cells["clblAktarildi"].Value))
                    ws.Cells[i + 2, 11] = "Evet";
                else
                    ws.Cells[i + 2, 11] = "Hayır";

                ws.Cells[i + 2, 12] = dataGridView1.Rows[i].Cells["clstrAktaran"].Value.ToString();
                ws.Cells[i + 2, 13] = dataGridView1.Rows[i].Cells["cldtAktarmaZamani"].Value.ToString();
            }

            ws.Cells[dataGridView1.Rows.Count + 3, 1] = "TOPLAM:";
            ws.Cells[dataGridView1.Rows.Count + 3, 2] = lblToplam.Text;

            this.Enabled = true;
            progressBar1.Visible = false;

            ws.SaveAs(filename.ToString());
            wb.Close();
            ap.Quit();
            GC.SuppressFinalize(ap);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (dataGridView1.Rows[e.RowIndex].Cells["clblAktarildi"].Value.ToString() != "True")
                {
                    if (MessageBox.Show("Bu satır işlendi olarak işaretlenecek. Devam etmek istiyor musunuz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        Odemeler.DoUpdateAktar(Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["clpkOdemeID"].Value), frmAna.KAdi.ToUpper());
                        dataGridView1.Rows[e.RowIndex].Cells["clblAktarildi"].Value = true;
                        dataGridView1.Rows[e.RowIndex].Cells["clstrAktaran"].Value = frmAna.KAdi.ToUpper();
                        dataGridView1.Rows[e.RowIndex].Cells["cldtAktarmaZamani"].Value = DateTime.Now;
                    }
                }
            }
        }

        private void frmFinansSanalPos_SizeChanged(object sender, EventArgs e)
        {
            btnYazdir.Location = new Point(btnYazdir.Location.X, lblAlt.Location.Y + 2);
            btnExcel.Location = new Point(btnExcel.Location.X, lblAlt.Location.Y + 2);
            progressBar1.Location = new Point(progressBar1.Location.X, lblAlt.Location.Y + 2);
            btnIade.Location = new Point(btnIade.Location.X, lblAlt.Location.Y + 2);
            lblToplam1.Location = new Point(this.Width - 178, lblAlt.Location.Y + 5);
            lblToplam.Location = new Point(this.Width - 127, lblAlt.Location.Y + 5);
        }

        private void dataGridView1_DataSourceChanged(object sender, EventArgs e)
        {
            GetBilgiler();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Excel Dosyası|*.xlsx";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    System.Threading.Thread thr = new System.Threading.Thread(new System.Threading.ParameterizedThreadStart(ExceleAktar));
                    thr.Start(sfd.FileName);
                }
            }
        }

        private void cbTarih_CheckedChanged(object sender, EventArgs e)
        {
            dtpBaslangic.Enabled = cbTarih.Checked;
            dtpBitis.Enabled = cbTarih.Checked;
            GetObjects();
        }

        private void dtpBaslangic_ValueChanged(object sender, EventArgs e)
        {
            GetObjects();
        }

        private void rbAktarildiTumu_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
                GetObjects();
        }

        private void txtMusteri_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                GetObjects();
            }
        }

        private void btnYenile_Click(object sender, EventArgs e)
        {
            txtMusteri.Text = string.Empty;
            cbTarih.Checked = false;
            rbAktarildiAktarilmayan.Checked = true;
            GetObjects();
        }

        private void btnYazdir_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
                return;

            if (dataGridView1.Rows.Count > 1000)
                if (MessageBox.Show("Satır sayısı çok fazla, bu işlem uzun sürebilir. Yinede devam etmek istiyor musunuz?", "Satır Sayısı Uyarısı", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.No)
                    return;

            string html = "<html><head><title>Sultanlar UI : Web Sanal Pos İşlemleri</title></head><body style='margin: 0px 0px 0px 0px'><table cellpadding='3' cellspacing='0' style='width: 989px; font-family: Verdana; font-size: 10px'>";

            html += "<tr style='color: #D00000; text-decoration: underline;'><td align='center' style='width: 70px'>Web Sip. No</td>" +
                "<td align='center' style='width: 80px'>Tutar</td>" +
                "<td align='center' style='width: 190px'>C/H Açıklaması</td>" +
                "<td align='center' style='width: 90px'>İşlem Yapan</td>" +
                "<td align='center' style='width: 100px'>Telefon</td>" +
                "<td align='center' style='width: 90px'>Öd. Tarihi</td>" +
                "<td align='center' style='width: 50px'>Prov. No</td>" +
                "<td align='center' style='width: 95px'>Referans No</td>" +
                "<td align='center' style='width: 124px'>İşlem No</td>" +
                "<td align='center' style='width: 100px'>Kredi Kartı</td></tr>"/* +
                "<td align='center' style='width: 100px'>İşlendi</td>" +
                "<td align='center' style='width: 100px'>İşleyen</td>" +
                "<td align='center' style='width: 100px'>İşlenme Tarihi</td>"*/;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                html += "<tr style='height: 36px'><td align='center' style='border-top: 1px solid #CCCCCC; border-left: 1px solid #CCCCCC'>" + dataGridView1.Rows[i].Cells["clintSiparisID"].Value.ToString() + "</td>" +
                    "<td align='right' style='border-top: 1px solid #CCCCCC; border-left: 1px solid #CCCCCC'>" + Convert.ToDecimal(dataGridView1.Rows[i].Cells["clmnTutar"].Value).ToString("C2") + "</td>" +
                    "<td align='left' style='border-top: 1px solid #CCCCCC; border-left: 1px solid #CCCCCC'>" + dataGridView1.Rows[i].Cells["clMUSTERI"].Value.ToString() + "</td>" +
                    "<td align='left' style='border-top: 1px solid #CCCCCC; border-left: 1px solid #CCCCCC'>" + dataGridView1.Rows[i].Cells["clAdSoyad"].Value.ToString() + "</td>" +
                    "<td align='center' style='border-top: 1px solid #CCCCCC; border-left: 1px solid #CCCCCC'>" + dataGridView1.Rows[i].Cells["clstrTelefon"].Value.ToString() + "</td>" +
                    "<td align='center' style='border-top: 1px solid #CCCCCC; border-left: 1px solid #CCCCCC'>" + dataGridView1.Rows[i].Cells["cldtOdemeZamani"].Value.ToString().Substring(0, 16) + "</td>" +
                    "<td align='center' style='border-top: 1px solid #CCCCCC; border-left: 1px solid #CCCCCC'>" + dataGridView1.Rows[i].Cells["clstrAuthCode"].Value.ToString() + "</td>" +
                    "<td align='center' style='border-top: 1px solid #CCCCCC; border-left: 1px solid #CCCCCC'>" + dataGridView1.Rows[i].Cells["clstrHostRefNum"].Value.ToString() + "</td>" +
                    "<td align='center' style='border-top: 1px solid #CCCCCC; border-left: 1px solid #CCCCCC'>" + dataGridView1.Rows[i].Cells["clstrTransID"].Value.ToString() + "</td>" +
                    "<td align='center' style='border-top: 1px solid #CCCCCC; border-left: 1px solid #CCCCCC; border-right: 1px solid #CCCCCC'>" + dataGridView1.Rows[i].Cells["clstrMaskedPan"].Value.ToString() + "</td></tr>"/* +
                    "<td style='border-top: 1px solid #CCCCCC'>" + dataGridView1.Rows[i].Cells["clblAktarildi"].Value.ToString() + "</td>" +
                    "<td style='border-top: 1px solid #CCCCCC'>" + dataGridView1.Rows[i].Cells["clstrAktaran"].Value.ToString() + "</td>" +
                    "<td style='border-top: 1px solid #CCCCCC'>" + dataGridView1.Rows[i].Cells["cldtAktarmaZamani"].Value.ToString() + "</td>"*/;
            }
            html += "<tr><td align='left' style='color: #D00000; border-top: 1px solid #CCCCCC; padding-top: 10px'><b>Toplam:</b></td>" +
                "<td align='right' style='color: #D00000; border-top: 1px solid #CCCCCC; padding-top: 10px'><b>" + lblToplam.Text + "</b></td>" +
                "<td align='center' style='color: #FFFFFF; border-top: 1px solid #CCCCCC'>-</td>" +
                "<td align='center' style='color: #FFFFFF; border-top: 1px solid #CCCCCC'>-</td>" +
                "<td align='center' style='color: #FFFFFF; border-top: 1px solid #CCCCCC'>-</td>" +
                "<td align='center' style='color: #FFFFFF; border-top: 1px solid #CCCCCC'>-</td>" +
                "<td align='center' style='color: #FFFFFF; border-top: 1px solid #CCCCCC'>-</td>" +
                "<td align='center' style='color: #FFFFFF; border-top: 1px solid #CCCCCC'>-</td>" +
                "<td align='center' style='color: #FFFFFF; border-top: 1px solid #CCCCCC'>-</td>" +
                "<td align='center' style='color: #FFFFFF; border-top: 1px solid #CCCCCC'>-</td></tr>";
            html += "</table></body></html>";

            System.IO.StreamWriter sw = new System.IO.StreamWriter("C:\\sultanlar-sanalpos.htm", true, Encoding.Unicode);
            sw.Write(html);
            sw.Close();
            sw.Dispose();

            frmYazdir frm = new frmYazdir("C:\\sultanlar-sanalpos.htm");
            frm.MaximumSize = new System.Drawing.Size(1024, 500);
            frm.Size = new System.Drawing.Size(1024, 500);
            frm.MinimumSize = new System.Drawing.Size(1024, 500);
            frm.webBrowser1.Width = 1006;
            frm.ShowDialog();
            File.Delete("C:\\sultanlar-sanalpos.htm");
        }

        private void btnIade_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                if (dataGridView1.SelectedRows[0].Cells["clblAktarildi"].Value.ToString() != "True")
                {
                    if (MessageBox.Show("İptal işlemi uygulamak istediğinize emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        string Donen = string.Empty;
                        HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://95.0.47.130/SulWCF/sanalpos.ashx?hostlogkey=" + dataGridView1.SelectedRows[0].Cells["clstrHostRefNum"].Value);
                        HttpWebResponse res = (HttpWebResponse)req.GetResponse();
                        Donen = new StreamReader(res.GetResponseStream()).ReadToEnd();

                        string[] parcalar = Donen.Split(new string[] { ";;;" }, StringSplitOptions.None);
                        string approved = parcalar[0], authCode = parcalar[1], hostlogkey = parcalar[2], respCode = parcalar[3], respText = parcalar[4];

                        if (approved == "1")
                        {
                            Odemeler odeme = Odemeler.GetObject(Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["clpkOdemeID"].Value));
                            odeme.blAktarildi = true;
                            odeme.strAktaran = frmAna.KAdi.ToUpper() + "-IPTAL";
                            odeme.dtAktarmaZamani = DateTime.Now;
                            odeme.DoUpdate();

                            dataGridView1.SelectedRows[0].Cells["clblAktarildi"].Value = true;
                            dataGridView1.SelectedRows[0].Cells["clstrAktaran"].Value = frmAna.KAdi.ToUpper() + "-IPTAL";
                            dataGridView1.SelectedRows[0].Cells["cldtAktarmaZamani"].Value = DateTime.Now;

                            MessageBox.Show("İptal işlemi yapıldı.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Hata çıktı. Ayrıntı:\r\n" + respCode + " " + respText, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        /*string tutar = Convert.ToDecimal(dataGridView1.SelectedRows[0].Cells["clmnTutar"].Value).ToString("N2");
                        string siparisno = Convert.ToDecimal(dataGridView1.SelectedRows[0].Cells["clstrReturnOid"].Value).ToString();
                        frmFinansSanalPosKartIade frm = new frmFinansSanalPosKartIade(tutar, siparisno);
                        frm.ShowDialog();*/
                    }
                }
                else
                {
                    MessageBox.Show("İşlenen kayda iptal işlemi uygulanamaz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Middle)
            {
                if (e.RowIndex > -1)
                {
                    dataGridView1.Rows[e.RowIndex].Selected = true;
                    btnIade.PerformClick();
                }
            }
        }
    }
}

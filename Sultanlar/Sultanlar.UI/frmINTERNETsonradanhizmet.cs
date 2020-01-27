using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sultanlar.Class;
using Sultanlar.DatabaseObject;
using Sultanlar.DatabaseObject.Internet;
using System.Threading;
using System.Collections;

namespace Sultanlar.UI
{
    public partial class frmINTERNETsonradanhizmet : Form
    {
        public frmINTERNETsonradanhizmet()
        {
            InitializeComponent();
        }

        DataTable dt;
        Thread thr;
        bool hesaplabasildi;

        private void frmINTERNETsonradanhizmet_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;

            hesaplabasildi = false;
            dateTimePicker1.Value = Convert.ToDateTime("01.01.2012");
            dateTimePicker2.Value = DateTime.Now;

            GetObjects("", "", "");
        }

        private void GetObjects(string Musteri, string Sube, string OzelAcik)
        {
            dt = new DataTable();
            IadeFiyat.GetSonradanHizmet2(dt, Musteri, Sube, OzelAcik, dateTimePicker1.Value, dateTimePicker2.Value);
            dataGridView1.DataSource = dt;
        }

        private void Yap()
        {
            DataTable dt = new DataTable();
            IadeFiyat.GetSTRREFITEMREFGMREFforSonradanHizmet(dt);

            DataTable dtHizmetler = new DataTable();
            dtHizmetler.Columns.Add("UrunToplam", typeof(double));
            dtHizmetler.Columns.Add("GenelToplam", typeof(double));
            dtHizmetler.Columns.Add("IadeToplam", typeof(double));
            dtHizmetler.Columns.Add("ToplamYuzde", typeof(double));
            dtHizmetler.Columns.Add("ToplamOran", typeof(double));
            dtHizmetler.Columns.Add("HizmetGenel", typeof(double));
            dtHizmetler.Columns.Add("HizmetYuzdeli", typeof(double));
            dtHizmetler.Columns.Add("Hizmet", typeof(double));

            for (int i = 0; i < 100; i++)
            {
                IadeFiyat.GetSonradanHizmetByGMREFITEMREF(dtHizmetler, Convert.ToInt32(dt.Rows[i]["GMREF"]), Convert.ToInt32(dt.Rows[i]["ITEMREF"]));
            }
            dataGridView1.DataSource = dtHizmetler;
        }

        private void Hesapla()
        {
            this.Enabled = false;

            if (hesaplabasildi)
                GetObjects("", "", "");
            else
                hesaplabasildi = true;

            ArrayList silinecekler = new ArrayList();
            progressBar1.Visible = true;
            progressBar1.Maximum = dt.Rows.Count;
            for (int j = 0; j < dt.Rows.Count; j++)
            {
                progressBar1.Value = j + 1;
                double toplam = 0;
                DataTable dt1 = new DataTable();
                IadeFiyat.GetSonradanHizmetByGMREFOZELKOD(dt1, Convert.ToInt32(dt.Rows[j]["GMREF"]), dt.Rows[j]["OZEL KOD"].ToString(), "önemsiz[AD ID]", dateTimePicker1.Value, dateTimePicker2.Value);
                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    double toplamyuzde = (Convert.ToDouble(dt1.Rows[i]["UrunToplam"]) * 100) / Convert.ToDouble(dt1.Rows[i]["GenelToplam"]);
                    double toplamoran = Convert.ToDouble(dt1.Rows[i]["UrunToplam"]) / Convert.ToDouble(dt1.Rows[i]["IadeToplam"]);
                    double hizmetyuzdeli = dt1.Rows[i]["HizmetGenel"] != DBNull.Value ? (Convert.ToDouble(dt1.Rows[i]["HizmetGenel"]) / 100) * toplamyuzde : 0;
                    toplam += toplamoran == 0 ? hizmetyuzdeli : (hizmetyuzdeli / toplamoran);
                }
                toplam = toplam - IadeHizmetTutar.GetTUTTOPByGMREFOZELKOD(Convert.ToInt32(dt.Rows[j]["GMREF"]), dt.Rows[j]["OZEL KOD"].ToString(), dateTimePicker1.Value, dateTimePicker2.Value);

                if (Convert.ToInt32(toplam) <= 0)
                    silinecekler.Add(dataGridView1.Rows[j]);
                else
                    dataGridView1.Rows[j].Cells["clHizmet"].Value = toplam;
            }

            //progressBar1.Maximum = silinecekler.Count;
            //progressBar1.Value = 0;
            //for (int i = 0; i < silinecekler.Count; i++)
            //{
            //    progressBar1.Value = i + 1;
            //    dataGridView1.Rows.Remove((DataGridViewRow)silinecekler[i]);
            //}

            progressBar1.Visible = false;
            this.Enabled = true;
            lblSatirSayisi.Text = dataGridView1.Rows.Count.ToString();
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (!hesaplabasildi)
                return;

            double toplam = 0;

            //DataTable dt = new DataTable();
            //IadeFiyat.GetSonradanHizmet(dt, "", "", "");

            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    if (Convert.ToDouble(dt.Rows[i]["IadeToplam"]) != 0 && 
            //        dt.Rows[i]["GMREF"].ToString() == dataGridView1.Rows[e.RowIndex].Cells["clGMREF"].Value.ToString() &&
            //        dt.Rows[i]["OZEL KOD"].ToString() == dataGridView1.Rows[e.RowIndex].Cells["clOZELKOD"].Value.ToString())
            //    {
            //        dt.Rows[i]["ToplamYuzde"] = (Convert.ToDouble(dt.Rows[i]["UrunToplam"]) * 100) / Convert.ToDouble(dt.Rows[i]["GenelToplam"]);
            //        dt.Rows[i]["ToplamOran"] = Convert.ToDouble(dt.Rows[i]["UrunToplam"]) / Convert.ToDouble(dt.Rows[i]["IadeToplam"]);
            //        dt.Rows[i]["HizmetYuzdeli"] = (Convert.ToDouble(dt.Rows[i]["HizmetGenel"]) * Convert.ToDouble(dt.Rows[i]["ToplamYuzde"])) / 100;
            //        dt.Rows[i]["Hizmet"] = Convert.ToDouble(dt.Rows[i]["ToplamOran"]) == 0 ? Convert.ToDouble(dt.Rows[i]["HizmetYuzdeli"]) : (Convert.ToDouble(dt.Rows[i]["HizmetYuzdeli"]) / Convert.ToDouble(dt.Rows[i]["ToplamOran"])) ;

            //        toplam += Convert.ToDouble(dt.Rows[i]["Hizmet"]);
            //    }
            //}

            DataTable dt1 = new DataTable();
            IadeFiyat.GetSonradanHizmetByGMREFOZELKOD(dt1, Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["clGMREF"].Value), dataGridView1.Rows[e.RowIndex].Cells["clOZELKOD"].Value.ToString(), "önemsiz[AD ID]", dateTimePicker1.Value, dateTimePicker2.Value);
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                double toplamyuzde = (Convert.ToDouble(dt1.Rows[i]["UrunToplam"]) * 100) / Convert.ToDouble(dt1.Rows[i]["GenelToplam"]);
                double toplamoran = Convert.ToDouble(dt1.Rows[i]["UrunToplam"]) / Convert.ToDouble(dt1.Rows[i]["IadeToplam"]);
                double hizmetyuzdeli = dt1.Rows[i]["HizmetGenel"] != DBNull.Value ? (Convert.ToDouble(dt1.Rows[i]["HizmetGenel"]) / 100) * toplamyuzde : 0;
                toplam += toplamoran == 0 ? hizmetyuzdeli : (hizmetyuzdeli / toplamoran);
            }

            if (cbAnaSube.Checked)
                toplam = toplam - IadeHizmetTutar.GetTUTTOPByGMREFOZELKOD(Convert.ToInt32(dt.Rows[e.RowIndex]["GMREF"]), dt.Rows[e.RowIndex]["OZEL KOD"].ToString(), dateTimePicker1.Value, dateTimePicker2.Value);
            //else
            //    toplam = toplam - IadeHizmetTutar.GetTUTTOPByGMREFOZELKOD(Convert.ToInt32(dt.Rows[e.RowIndex]["SMREF"]), dt.Rows[e.RowIndex]["OZEL KOD"].ToString(), dateTimePicker1.Value, dateTimePicker2.Value);

            int gmref = 0;
            if (cbAnaSube.Checked)
                gmref = Convert.ToInt32(dt.Rows[e.RowIndex]["GMREF"]);

            frmINTERNETiadelerdetayhizmet frm = new frmINTERNETiadelerdetayhizmet(gmref, 0,
                dt.Rows[e.RowIndex]["OZEL KOD"].ToString(), dateTimePicker1.Value, dateTimePicker2.Value,
                toplam);
            frm.ShowDialog();
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            GetObjects(txtMusteri.Text.Trim(), txtSube.Text.Trim(), txtOzelAcik.Text.Trim());
        }

        private void txtMusteri_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAra.PerformClick();
            }
        }

        private void dataGridView1_DataSourceChanged(object sender, EventArgs e)
        {
            lblSatirSayisi.Text = dataGridView1.Rows.Count.ToString();
        }

        private void btnHesapla_Click(object sender, EventArgs e)
        {
            if (dt.Rows.Count > 0)
            {
                thr = new Thread(new ThreadStart(Hesapla));
                thr.Start();
            }
        }
    }
}

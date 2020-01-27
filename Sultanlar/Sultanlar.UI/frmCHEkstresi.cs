using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sultanlar.DatabaseObject.Internet;
using System.Collections;

namespace Sultanlar.UI
{
    public partial class frmCHEkstresi : Form
    {
        public frmCHEkstresi()
        {
            InitializeComponent();
        }

        DataTable dtEkstreler;
        DataTable dtCariHesaplar;
        DataTable dtSatTem;
        //ArrayList alSatKod;
        //ArrayList alTedSatKod;

        private void frmCHEkstresi_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;

            dtEkstreler = new DataTable();
            dtCariHesaplar = new DataTable();
            dtSatTem = new DataTable();
            //alSatKod = new ArrayList();
            //alTedSatKod = new ArrayList();
            //GetCariHesaplar(cmbMusteriler.Items, "");
            GetSatisTemsilcileri(cmbSatTem.Items, false);
            GetSatisTemsilcileri(cmbTedSatTem.Items, true);

            //GetBaslangic();

            CariHesaplar.GetCHEkstresi(dtEkstreler);
            dataGridView1.DataSource = dtEkstreler;
        }

        private void GetBaslangic()
        {
            System.Threading.Thread thr = new System.Threading.Thread(GetEkstrelerBaslangic);
            thr.Start();
        }

        private void GetEkstrelerBaslangic()
        {
            CariHesaplar.GetCHEkstresi(dtEkstreler);
            dataGridView1.DataSource = dtEkstreler;
        }

        private void GetCariHesaplar(IList List, string MusteriBaslangici)
        {
            dtCariHesaplar = new DataTable();
            List.Clear();
            CariHesaplar.GetObjectsByMusteri(dtCariHesaplar, MusteriBaslangici, true);
            for (int i = 0; i < dtCariHesaplar.Rows.Count; i++)
                List.Add(dtCariHesaplar.Rows[i]["MUSTERI"].ToString());
        }

        private void GetSatisTemsilcileri(IList List, bool Ted)
        {
            dtSatTem = new DataTable();
            List.Clear();
            SatisTemsilcileri.GetObjects(dtSatTem);

            for (int i = 0; i < dtSatTem.Rows.Count; i++)
            {
                if (Ted)
                {
                    if (dtSatTem.Rows[i]["SAT KOD1"].ToString().StartsWith("8"))
                    {
                        //alTedSatKod.Add(dtSatTem.Rows[i]["SAT KOD1"].ToString());
                        List.Add(dtSatTem.Rows[i]["SAT TEM"].ToString());
                    }
                }
                else
                {
                    if (!dtSatTem.Rows[i]["SAT KOD1"].ToString().StartsWith("8"))
                    {
                        //alSatKod.Add(dtSatTem.Rows[i]["SAT KOD1"].ToString());
                        List.Add(dtSatTem.Rows[i]["SAT TEM"].ToString());
                    }
                }
            }
        }

        private void GetSatisTemsilcileriByMusteri()
        {
            //alSatKod.Clear();
            cmbSatTem.Items.Clear();
            //alTedSatKod.Clear();
            cmbTedSatTem.Items.Clear();
            cmbTedSatTem.Items.Add("Boş");
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Cells["TED SAT TEM"].Value.ToString() != string.Empty)
                {
                    //if (cmbTedSatTem.Items.Count == 0)
                    //{
                    //    //string tedsatkod = dataGridView1.Rows[i].Cells["TED SAT KOD"].Value.ToString();
                    //    //alTedSatKod.Add(tedsatkod);
                    //    cmbTedSatTem.Items.Add(dataGridView1.Rows[i].Cells["TED SAT TEM"].Value.ToString());
                    //}
                    bool varmi = false;
                    for (int j = 0; j < cmbTedSatTem.Items.Count; j++)
                    {
                        if (cmbTedSatTem.Items[j].ToString() == dataGridView1.Rows[i].Cells["TED SAT TEM"].Value.ToString())
                        {
                            varmi = true;
                            break;
                        }
                    }
                    if (!varmi)
                    {
                        //string tedsatkod = dataGridView1.Rows[i].Cells["TED SAT KOD"].Value.ToString();
                        //alTedSatKod.Add(tedsatkod);
                        cmbTedSatTem.Items.Add(dataGridView1.Rows[i].Cells["TED SAT TEM"].Value.ToString());
                    }
                }
                else
                {
                    if (cmbSatTem.Items.Count == 0)
                    {
                        //string satkod = dataGridView1.Rows[i].Cells["SAT KOD"].Value.ToString();
                        //alSatKod.Add(satkod);
                        cmbSatTem.Items.Add(dataGridView1.Rows[i].Cells["SAT TEM"].Value.ToString());
                    }
                    bool varmi = false;
                    for (int j = 0; j < cmbSatTem.Items.Count; j++)
                    {
                        if (cmbSatTem.Items[j].ToString() == dataGridView1.Rows[i].Cells["SAT TEM"].Value.ToString())
                        {
                            varmi = true;
                            break;
                        }
                    }
                    if (!varmi)
                    {
                        //string satkod = dataGridView1.Rows[i].Cells["SAT KOD"].Value.ToString();
                        //alSatKod.Add(satkod);
                        cmbSatTem.Items.Add(dataGridView1.Rows[i].Cells["SAT TEM"].Value.ToString());
                    }
                }
            }
            //alTedSatKod.Clear();
            //cmbTedSatTem.Items.Clear();
            //for (int i = 0; i < dataGridView1.Rows.Count; i++)
            //{
            //    if (dataGridView1.Rows[i].Cells["TED SAT KOD"].Value.ToString() != string.Empty)
            //    {
            //        if (alTedSatKod.Count == 0)
            //        {
            //            string tedsatkod = dataGridView1.Rows[i].Cells["TED SAT KOD"].Value.ToString();
            //            alTedSatKod.Add(tedsatkod);
            //            cmbTedSatTem.Items.Add(SatisTemsilcileri.GetObjectBySATKOD(tedsatkod));
            //        }

            //        for (int j = 0; j < alTedSatKod.Count; j++)
            //        {
            //            if (alTedSatKod[j].ToString() != dataGridView1.Rows[i].Cells["TED SAT KOD"].Value.ToString())
            //            {
            //                string tedsatkod = dataGridView1.Rows[i].Cells["TED SAT KOD"].Value.ToString();
            //                alTedSatKod.Add(tedsatkod);
            //                cmbTedSatTem.Items.Add(SatisTemsilcileri.GetObjectBySATKOD(tedsatkod));
            //            }
            //            else
            //            {
            //                break;
            //            }
            //        }
            //    }
            //}
        }

        private void GetEkstreler()
        {
            string MusKod = string.Empty, SatTem = string.Empty, TedSatTem = string.Empty, BasTarih = string.Empty, SonTarih = string.Empty;

            if (lbMusteriler.SelectedIndex > -1)
                MusKod = dtCariHesaplar.Rows[lbMusteriler.SelectedIndex]["MUS KOD"].ToString();

            if (cmbSatTem.SelectedIndex > -1)
                SatTem = cmbSatTem.SelectedItem.ToString();

            if (cmbTedSatTem.SelectedIndex > -1)
                TedSatTem = cmbTedSatTem.SelectedItem.ToString();

            if (cbTarih.Checked)
            {
                BasTarih = dtpBas.Value.Month.ToString("N2") + "." + dtpBas.Value.Day.ToString("N2") + "." + dtpBas.Value.Year;
                SonTarih = dtpSon.Value.Month.ToString("N2") + "." + dtpSon.Value.Day.ToString("N2") + "." + dtpSon.Value.Year;
            }



            DataTable dt = new DataTable();
            if (MusKod == string.Empty && SatTem == string.Empty && TedSatTem == string.Empty)
                return;//CariHesaplar.GetCHEkstresiByMusKod(dt, "AAAAAAA", "BBBBBBB", "CCCCCC", "", "");
            else
                CariHesaplar.GetCHEkstresiByMusKod(dt, MusKod, SatTem, TedSatTem, BasTarih, SonTarih);
            dataGridView1.DataSource = dt;



            if (MusKod != string.Empty && SatTem == string.Empty && TedSatTem == string.Empty)
            {
                GetSatisTemsilcileriByMusteri();
            }
        }

        private void Suz()
        {
            string MusKod = string.Empty, SatTem = string.Empty, TedSatTem = string.Empty;
            DateTime BasTarih = DateTime.MinValue, SonTarih = DateTime.MaxValue;

            if (lbMusteriler.SelectedIndex > -1)
                MusKod = dtCariHesaplar.Rows[lbMusteriler.SelectedIndex]["MUS KOD"].ToString();

            if (cmbSatTem.SelectedIndex > -1)
                SatTem = cmbSatTem.SelectedItem.ToString();

            if (cmbTedSatTem.SelectedIndex > -1)
                TedSatTem = cmbTedSatTem.SelectedItem.ToString();

            if (cbTarih.Checked)
            {
                BasTarih = dtpBas.Value;
                SonTarih = dtpSon.Value;
            }

            DataTable dt = new DataTable();
            for (int i = 0; i < dtEkstreler.Columns.Count; i++)
                dt.Columns.Add(dtEkstreler.Columns[i].ColumnName, dtEkstreler.Columns[i].DataType);

            for (int i = 0; i < dtEkstreler.Rows.Count; i++)
            {
                if ((MusKod == string.Empty || MusKod == dtEkstreler.Rows[i]["MUS KOD"].ToString()) &&
                    (SatTem == string.Empty || SatTem == dtEkstreler.Rows[i]["SAT TEM"].ToString() || (SatTem == "Boş" && "" == dtEkstreler.Rows[i]["SAT TEM"].ToString())) &&
                    (TedSatTem == string.Empty || TedSatTem == dtEkstreler.Rows[i]["TED SAT TEM"].ToString() || (TedSatTem == "Boş" && "" == dtEkstreler.Rows[i]["TED SAT TEM"].ToString())) &&
                    BasTarih <= Convert.ToDateTime(dtEkstreler.Rows[i]["FIS TAR"]) &&
                    SonTarih >= Convert.ToDateTime(dtEkstreler.Rows[i]["FIS TAR"]))
                {
                    DataRow drow = dt.NewRow();
                    drow.ItemArray = dtEkstreler.Rows[i].ItemArray;
                    dt.Rows.Add(drow);
                }
            }
            dataGridView1.DataSource = dt;



            if (MusKod != string.Empty && SatTem == string.Empty && TedSatTem == string.Empty)
            {
                GetSatisTemsilcileriByMusteri();
            }
        }

        private void txtMusteri_TextChanged(object sender, EventArgs e)
        {
            //if (txtMusteri.Text.Length > 2)
            //{
            //    dataGridView1.DataSource = null;
            //    GetCariHesaplar(cmbMusteriler.Items, txtMusteri.Text);
            //}
            //else if (txtMusteri.Text.Length == 0)
            //{
            //    dataGridView1.DataSource = null;
            //    GetCariHesaplar(cmbMusteriler.Items, "");
            //}
        }

        private void cmbMusteriler_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cmbMusteriler.SelectedIndex > -1)
            //    GetEkstreler(dtCariHesaplar.Rows[cmbMusteriler.SelectedIndex]["MUS KOD"].ToString());
        }

        private void dataGridView1_DataSourceChanged(object sender, EventArgs e)
        {
            lblSatirSayisi.Text = dataGridView1.Rows.Count.ToString();
        }

        private void frmCHEkstresi_SizeChanged(object sender, EventArgs e)
        {
            lblSatirSayisi.Location = new Point(this.Width - 60, lblAlt.Location.Y + 5);
            lblSatirSayisi1.Location = new Point(this.Width - 127, lblAlt.Location.Y + 5);
        }

        private void txtMusteri_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtMusteri1.Visible = false;
                lbMusteriler.Visible = true;
                GetCariHesaplar(lbMusteriler.Items, txtMusteri.Text);
                lbMusteriler.Focus();
                if (lbMusteriler.Items.Count > 0)
                    lbMusteriler.SelectedIndex = 0;
            }
        }

        private void lbMusteriler_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (lbMusteriler.SelectedIndex > -1)
                {
                    //GetEkstreler();
                    Suz();
                    lbMusteriler.Visible = false;
                    txtMusteri1.Visible = true;
                    txtMusteri1.Text = dtCariHesaplar.Rows[lbMusteriler.SelectedIndex]["MUSTERI"].ToString();
                }
            }
        }

        private void cmbSatTem_SelectedIndexChanged(object sender, EventArgs e)
        {
            //GetEkstreler();
            Suz();
        }

        private void cmbTedSatTem_SelectedIndexChanged(object sender, EventArgs e)
        {
            //GetEkstreler();
            Suz();
        }

        private void cbTarih_CheckedChanged(object sender, EventArgs e)
        {
            dtpBas.Enabled = cbTarih.Checked;
            dtpSon.Enabled = cbTarih.Checked;

            if (cbTarih.Checked)
                Suz(); //GetEkstreler();
        }

        private void dtpBas_ValueChanged(object sender, EventArgs e)
        {
            //GetEkstreler();
            Suz();
        }

        private void btnMusteriTemizle_Click(object sender, EventArgs e)
        {
            lbMusteriler.Items.Clear();
            lbMusteriler.Visible = false;
            txtMusteri.Text = string.Empty;
            txtMusteri1.Text = string.Empty;
            DataTable dt = new DataTable();
            dataGridView1.DataSource = dt;
            GetSatisTemsilcileri(cmbSatTem.Items, false);
            GetSatisTemsilcileri(cmbTedSatTem.Items, true);
            dataGridView1.DataSource = dtEkstreler;
        }
    }
}

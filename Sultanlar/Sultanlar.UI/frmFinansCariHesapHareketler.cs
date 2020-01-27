using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Sultanlar.DatabaseObject;
using System.Collections;
using DgvFilterPopup;

namespace Sultanlar.UI
{
    public partial class frmFinansCariHesapHareketler : Form
    {
        public frmFinansCariHesapHareketler()
        {
            InitializeComponent();
        }

        int textlength;
        double kesintitutaronceki;
        double kesintiyuzdeonceki;
        //DgvFilterManager dgvfm;

        private void frmFinansCariHesapHareketler_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            textlength = 0;
            kesintitutaronceki = 0;
            kesintiyuzdeonceki = 0;
            GetObjects();
            GetSatTem();

            if (frmAna.KAdi.ToUpper() == "BI04")
            {
                lblSatirSayisi1.Visible = false;
                lblLOGREF.Visible = true;
                lblMod.Visible = true;
                lblTur.Visible = true;
            }
        }

        private void GetObjects()
        {
            DataTable dt = new DataTable();
            FinansCariHesapHareketler.GetObjects(dt, rb2013.Checked);
            dataGridView1.DataSource = dt;
            //dgvfm = new DgvFilterManager(dataGridView1);
        }

        private DataTable GetObjects(bool datagridviewaekleme)
        {
            DataTable dt = new DataTable();
            FinansCariHesapHareketler.GetObjects(dt, rb2013.Checked);
            return dt;
        }

        private void GetSatTem()
        {
            ArrayList eklenenler = new ArrayList();
            eklenenler.Add("Bos");

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (eklenenler[eklenenler.Count - 1].ToString() != dataGridView1.Rows[i].Cells["clSATKOD"].Value.ToString())
                {
                    eklenenler.Add(dataGridView1.Rows[i].Cells["clSATKOD"].Value.ToString());
                    cmbSatTem.Items.Add(dataGridView1.Rows[i].Cells["clSATTEM"].Value.ToString());
                }
            }
        }

        //private void GetMusteriler()
        //{
        //    ArrayList eklenenler = new ArrayList();
        //    eklenenler.Add("Bos");

        //    for (int i = 0; i < dataGridView1.Rows.Count; i++)
        //    {
        //        if (eklenenler[eklenenler.Count - 1].ToString() != dataGridView1.Rows[i].Cells["clMUSKOD"].Value.ToString())
        //        {
        //            eklenenler.Add(dataGridView1.Rows[i].Cells["clMUSKOD"].Value.ToString());
        //            cmbMusteriler.Items.Add(dataGridView1.Rows[i].Cells["clMUSTERI"].Value.ToString());
        //        }
        //    }
        //}

        private void GetBilgiler()
        {
            double tahtop = 0;
            double kestop = 0;
            double kesfarktop = 0;

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                tahtop += Convert.ToDouble(dataGridView1.Rows[i].Cells["clTAHTOP"].Value.ToString());
                if (dataGridView1.Rows[i].Cells["clKESTUTAR"].Value.ToString() != string.Empty)
                    kestop += Convert.ToDouble(dataGridView1.Rows[i].Cells["clKESTUTAR"].Value.ToString());
                if (dataGridView1.Rows[i].Cells["clKesintiFark"].Value.ToString() != string.Empty)
                    kesfarktop += Convert.ToDouble(dataGridView1.Rows[i].Cells["clKesintiFark"].Value.ToString());
            }

            lblTahTop.Text = tahtop.ToString("C2");
            lblKesTop.Text = kestop.ToString("C2");
            lblKesFarkTop.Text = kesfarktop.ToString("C2");
        }

        private void Suz()
        {
            DataTable dtYeni = new DataTable();

            bool musteriadsuz = Convert.ToBoolean(txtMusteri.Text.Length > 2); //


            if (musteriadsuz && cbTarih.Checked && cmbSatTem.SelectedIndex > -1)
            {
                DataTable dt = GetObjects(true);

                for (int i = 0; i < dt.Columns.Count; i++)
                    dtYeni.Columns.Add(dt.Columns[i].ColumnName, dt.Columns[i].DataType);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["MUSTERI"].ToString().ToUpper().StartsWith(txtMusteri.Text.ToUpper()) &&
                        Convert.ToDateTime(dt.Rows[i]["FIS TAR"]) >= dtpBaslangic.Value.AddDays(-1) &&
                        Convert.ToDateTime(dt.Rows[i]["FIS TAR"]) <= dtpBitis.Value &&
                        dt.Rows[i]["SAT TEM"].ToString().ToUpper() == cmbSatTem.SelectedItem.ToString().ToUpper())
                    {
                        dtYeni.Rows.Add(dt.Rows[i].ItemArray);
                    }
                }
            }
            else if (musteriadsuz && cbTarih.Checked)
            {
                DataTable dt = GetObjects(true);

                for (int i = 0; i < dt.Columns.Count; i++)
                    dtYeni.Columns.Add(dt.Columns[i].ColumnName, dt.Columns[i].DataType);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["MUSTERI"].ToString().ToUpper().StartsWith(txtMusteri.Text.ToUpper()) &&
                        Convert.ToDateTime(dt.Rows[i]["FIS TAR"]) >= dtpBaslangic.Value.AddDays(-1) &&
                        Convert.ToDateTime(dt.Rows[i]["FIS TAR"]) <= dtpBitis.Value)
                    {
                        dtYeni.Rows.Add(dt.Rows[i].ItemArray);
                    }
                }
            }
            else if (musteriadsuz && cmbSatTem.SelectedIndex > -1)
            {
                DataTable dt = GetObjects(true);

                for (int i = 0; i < dt.Columns.Count; i++)
                    dtYeni.Columns.Add(dt.Columns[i].ColumnName, dt.Columns[i].DataType);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["MUSTERI"].ToString().ToUpper().StartsWith(txtMusteri.Text.ToUpper()) &&
                        dt.Rows[i]["SAT TEM"].ToString().ToUpper() == cmbSatTem.SelectedItem.ToString().ToUpper())
                    {
                        dtYeni.Rows.Add(dt.Rows[i].ItemArray);
                    }
                }
            }
            else if (cbTarih.Checked && cmbSatTem.SelectedIndex > -1)
            {
                DataTable dt = GetObjects(true);

                for (int i = 0; i < dt.Columns.Count; i++)
                    dtYeni.Columns.Add(dt.Columns[i].ColumnName, dt.Columns[i].DataType);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["SAT TEM"].ToString().ToUpper() == cmbSatTem.SelectedItem.ToString().ToUpper() &&
                        Convert.ToDateTime(dt.Rows[i]["FIS TAR"]) >= dtpBaslangic.Value.AddDays(-1) &&
                        Convert.ToDateTime(dt.Rows[i]["FIS TAR"]) <= dtpBitis.Value)
                    {
                        dtYeni.Rows.Add(dt.Rows[i].ItemArray);
                    }
                }
            }
            else if (musteriadsuz)
            {
                DataTable dt = GetObjects(true);

                for (int i = 0; i < dt.Columns.Count; i++)
                    dtYeni.Columns.Add(dt.Columns[i].ColumnName, dt.Columns[i].DataType);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["MUSTERI"].ToString().ToUpper().StartsWith(txtMusteri.Text.ToUpper()))
                    {
                        dtYeni.Rows.Add(dt.Rows[i].ItemArray);
                    }
                }

                //DataTable dt = new DataTable();
                //FinansCariHesapHareketler.GetObjectsByMusteri(dt, txtMusteri.Text.ToUpper(), rb2013.Checked);
                //dataGridView1.DataSource = dt;
                //return;
            }
            else if (cbTarih.Checked)
            {
                DataTable dt = GetObjects(true);

                for (int i = 0; i < dt.Columns.Count; i++)
                    dtYeni.Columns.Add(dt.Columns[i].ColumnName, dt.Columns[i].DataType);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (Convert.ToDateTime(dt.Rows[i]["FIS TAR"]) >= dtpBaslangic.Value.AddDays(-1) &&
                        Convert.ToDateTime(dt.Rows[i]["FIS TAR"]) <= dtpBitis.Value)
                    {
                        dtYeni.Rows.Add(dt.Rows[i].ItemArray);
                    }
                }
            }
            else if (cmbSatTem.SelectedIndex > -1)
            {
                DataTable dt = GetObjects(true);

                for (int i = 0; i < dt.Columns.Count; i++)
                    dtYeni.Columns.Add(dt.Columns[i].ColumnName, dt.Columns[i].DataType);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["SAT TEM"].ToString().ToUpper() == cmbSatTem.SelectedItem.ToString().ToUpper())
                    {
                        dtYeni.Rows.Add(dt.Rows[i].ItemArray);
                    }
                }
            }
            else
            {
                return;
            }

            dataGridView1.DataSource = dtYeni;
        }

        private void Suz2()
        {
            DataTable dtYeni = new DataTable();

            FinansCariHesapHareketler.GetObjectsByMusteri(dtYeni, txtMusteri.Text, rb2013.Checked);

            dataGridView1.DataSource = dtYeni;
        }

        private void ExceleAktar(object filename)
        {
            Microsoft.Office.Interop.Excel.Application ap = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook wb = ap.Workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
            Microsoft.Office.Interop.Excel.Worksheet ws = (Microsoft.Office.Interop.Excel.Worksheet)wb.Worksheets[1];

            ((Microsoft.Office.Interop.Excel.Range)ws.Columns["A", Type.Missing]).ColumnWidth = 3.29;
            ((Microsoft.Office.Interop.Excel.Range)ws.Columns["B", Type.Missing]).ColumnWidth = 5.29;
            ((Microsoft.Office.Interop.Excel.Range)ws.Columns["C", Type.Missing]).ColumnWidth = 3.43;
            ((Microsoft.Office.Interop.Excel.Range)ws.Columns["D", Type.Missing]).ColumnWidth = 3.43;
            ((Microsoft.Office.Interop.Excel.Range)ws.Columns["E", Type.Missing]).ColumnWidth = 10.43;
            ((Microsoft.Office.Interop.Excel.Range)ws.Columns["F", Type.Missing]).ColumnWidth = 5.43;
            ((Microsoft.Office.Interop.Excel.Range)ws.Columns["G", Type.Missing]).ColumnWidth = 9.29;
            ((Microsoft.Office.Interop.Excel.Range)ws.Columns["H", Type.Missing]).ColumnWidth = 5.71;
            ((Microsoft.Office.Interop.Excel.Range)ws.Columns["I", Type.Missing]).ColumnWidth = 8.29;
            ((Microsoft.Office.Interop.Excel.Range)ws.Columns["J", Type.Missing]).ColumnWidth = 9.29;
            ((Microsoft.Office.Interop.Excel.Range)ws.Columns["K", Type.Missing]).ColumnWidth = 6.86;
            ((Microsoft.Office.Interop.Excel.Range)ws.Columns["L", Type.Missing]).ColumnWidth = 27;
            ((Microsoft.Office.Interop.Excel.Range)ws.Columns["M", Type.Missing]).ColumnWidth = 13;
            ((Microsoft.Office.Interop.Excel.Range)ws.Columns["N", Type.Missing]).ColumnWidth = 56.43;
            ((Microsoft.Office.Interop.Excel.Range)ws.Columns["O", Type.Missing]).ColumnWidth = 45;
            ((Microsoft.Office.Interop.Excel.Range)ws.Columns["P", Type.Missing]).ColumnWidth = 15.43;
            ((Microsoft.Office.Interop.Excel.Range)ws.Columns["Q", Type.Missing]).ColumnWidth = 15.43;
            ((Microsoft.Office.Interop.Excel.Range)ws.Columns["R", Type.Missing]).ColumnWidth = 15.43;
            ((Microsoft.Office.Interop.Excel.Range)ws.Columns["S", Type.Missing]).ColumnWidth = 15.43;
            ((Microsoft.Office.Interop.Excel.Range)ws.Columns["T", Type.Missing]).ColumnWidth = 16.43;
            ((Microsoft.Office.Interop.Excel.Range)ws.Columns["U", Type.Missing]).ColumnWidth = 19.86;

            ((Microsoft.Office.Interop.Excel.Range)ws.Rows[1, Type.Missing]).Font.Bold = true;
            ((Microsoft.Office.Interop.Excel.Range)ws.Columns["P", Type.Missing]).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
            ((Microsoft.Office.Interop.Excel.Range)ws.Columns["Q", Type.Missing]).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
            ((Microsoft.Office.Interop.Excel.Range)ws.Columns["R", Type.Missing]).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
            ((Microsoft.Office.Interop.Excel.Range)ws.Columns["S", Type.Missing]).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
            ((Microsoft.Office.Interop.Excel.Range)ws.Cells[1, 16]).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
            ((Microsoft.Office.Interop.Excel.Range)ws.Cells[1, 17]).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
            ((Microsoft.Office.Interop.Excel.Range)ws.Cells[1, 18]).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
            ((Microsoft.Office.Interop.Excel.Range)ws.Cells[1, 19]).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

            ws.Cells[1, 1] = "C/T";
            ws.Cells[1, 2] = "Bölge";
            ws.Cells[1, 3] = "Grp";
            ws.Cells[1, 4] = "Ekp";
            ws.Cells[1, 5] = "Fiş Tür";
            ws.Cells[1, 6] = "Fiş Ay";
            ws.Cells[1, 7] = "Fiş Tarih";
            ws.Cells[1, 8] = "Fiş No";
            ws.Cells[1, 9] = "Fiş Vd Ay";
            ws.Cells[1, 10] = "Fiş Vd";
            ws.Cells[1, 11] = "Sat Kod";
            ws.Cells[1, 12] = "Sat Tem";
            ws.Cells[1, 13] = "Müş Kod";
            ws.Cells[1, 14] = "Müşteri";
            ws.Cells[1, 15] = "Fiş Açıklama";
            ws.Cells[1, 16] = "Tah Top";
            ws.Cells[1, 17] = "Kesinti Tutar";
            ws.Cells[1, 18] = "Kesinti Yüzde";
            ws.Cells[1, 19] = "Kesinti Farkı";
            ws.Cells[1, 20] = "Son Güncelleyen";
            ws.Cells[1, 21] = "Son Güncelleme Tarihi";

            progressBar1.Visible = true;
            progressBar1.Maximum = dataGridView1.Rows.Count;
            progressBar1.Value = 0;

            this.Enabled = false;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                progressBar1.Value = i;

                ws.Cells[i + 2, 1] = dataGridView1.Rows[i].Cells["clCT"].Value.ToString();
                ws.Cells[i + 2, 2] = dataGridView1.Rows[i].Cells["clBOLGE"].Value.ToString();
                ws.Cells[i + 2, 3] = dataGridView1.Rows[i].Cells["clGRP"].Value.ToString();
                ws.Cells[i + 2, 4] = dataGridView1.Rows[i].Cells["clEKP"].Value.ToString();
                ws.Cells[i + 2, 5] = dataGridView1.Rows[i].Cells["clFISTUR"].Value.ToString();
                ws.Cells[i + 2, 6] = dataGridView1.Rows[i].Cells["clFISAY"].Value.ToString();
                ws.Cells[i + 2, 7] = dataGridView1.Rows[i].Cells["clFISTAR"].Value.ToString();
                ws.Cells[i + 2, 8] = dataGridView1.Rows[i].Cells["clFISNO"].Value.ToString();
                ws.Cells[i + 2, 9] = dataGridView1.Rows[i].Cells["clFISVDAY"].Value.ToString();
                ws.Cells[i + 2, 10] = dataGridView1.Rows[i].Cells["clFISVD"].Value.ToString();
                ws.Cells[i + 2, 11] = dataGridView1.Rows[i].Cells["clSATKOD"].Value.ToString();
                ws.Cells[i + 2, 12] = dataGridView1.Rows[i].Cells["clSATTEM"].Value.ToString();
                ws.Cells[i + 2, 13] = dataGridView1.Rows[i].Cells["clMUSKOD"].Value.ToString();
                ws.Cells[i + 2, 14] = dataGridView1.Rows[i].Cells["clMUSTERI"].Value.ToString();
                ws.Cells[i + 2, 15] = dataGridView1.Rows[i].Cells["clFISACIKLAMA"].Value.ToString();
                ws.Cells[i + 2, 16] = Convert.ToDouble(dataGridView1.Rows[i].Cells["clTAHTOP"].Value.ToString()).ToString("N2");

                if (dataGridView1.Rows[i].Cells["clKESTUTAR"].Value.ToString() != string.Empty)
                    ws.Cells[i + 2, 17] = Convert.ToDouble(dataGridView1.Rows[i].Cells["clKESTUTAR"].Value.ToString()).ToString("N2");
                if (dataGridView1.Rows[i].Cells["clKESYUZDE"].Value.ToString() != string.Empty)
                    ws.Cells[i + 2, 18] = Convert.ToDouble(dataGridView1.Rows[i].Cells["clKESYUZDE"].Value.ToString()).ToString("N2");
                if (dataGridView1.Rows[i].Cells["clKesintiFark"].Value.ToString() != string.Empty)
                    ws.Cells[i + 2, 19] = Convert.ToDouble(dataGridView1.Rows[i].Cells["clKesintiFark"].Value.ToString()).ToString("N2");
                if (dataGridView1.Rows[i].Cells["clGUNCKIM"].Value.ToString() != string.Empty)
                    ws.Cells[i + 2, 20] = dataGridView1.Rows[i].Cells["clGUNCKIM"].Value.ToString();
                if (dataGridView1.Rows[i].Cells["clGUNCTARIH"].Value.ToString() != string.Empty)
                    ws.Cells[i + 2, 21] = dataGridView1.Rows[i].Cells["clGUNCTARIH"].Value.ToString();
            }

            ws.Cells[dataGridView1.Rows.Count + 3, 15] = "TOPLAM:";
            ws.Cells[dataGridView1.Rows.Count + 3, 16] = lblTahTop.Text;
            ws.Cells[dataGridView1.Rows.Count + 3, 17] = lblKesTop.Text;
            ws.Cells[dataGridView1.Rows.Count + 3, 19] = lblKesFarkTop.Text;

            this.Enabled = true;
            progressBar1.Visible = false;

            ws.SaveAs(filename.ToString());
            wb.Close();
            ap.Quit();
            GC.SuppressFinalize(ap);
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells["clKESTUTAR"].Value.ToString() != string.Empty)
            {
                kesintitutaronceki = Convert.ToDouble(dataGridView1.Rows[e.RowIndex].Cells["clKESTUTAR"].Value.ToString());
            }
            else
            {
                kesintitutaronceki = 0;
            }

            if (dataGridView1.Rows[e.RowIndex].Cells["clKESYUZDE"].Value.ToString() != string.Empty)
            {
                kesintiyuzdeonceki = Convert.ToDouble(dataGridView1.Rows[e.RowIndex].Cells["clKESYUZDE"].Value.ToString());
            }
            else
            {
                kesintiyuzdeonceki = 0;
            }

            lblLOGREF.Text = dataGridView1.Rows[e.RowIndex].Cells["clLOGREF"].Value.ToString();
            lblMod.Text = dataGridView1.Rows[e.RowIndex].Cells["clMOD"].Value.ToString();
            lblTur.Text = dataGridView1.Rows[e.RowIndex].Cells["clTUR"].Value.ToString();
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            double kesintitutar = 0;
            double kesintiyuzde = 0;
            if (dataGridView1.Rows[e.RowIndex].Cells["clKESTUTAR"].Value.ToString() != string.Empty)
            {
                kesintitutar = Convert.ToDouble(dataGridView1.Rows[e.RowIndex].Cells["clKESTUTAR"].Value.ToString());
            }
            if (dataGridView1.Rows[e.RowIndex].Cells["clKESYUZDE"].Value.ToString() != string.Empty)
            {
                kesintiyuzde = Convert.ToDouble(dataGridView1.Rows[e.RowIndex].Cells["clKESYUZDE"].Value.ToString());
            }

            if (kesintitutar != kesintitutaronceki)
                kesintiyuzde = (kesintitutar * 100) / Convert.ToDouble(dataGridView1.Rows[e.RowIndex].Cells["clTAHTOP"].Value.ToString());
            else if (kesintiyuzde != kesintiyuzdeonceki)
                kesintitutar = (Convert.ToDouble(dataGridView1.Rows[e.RowIndex].Cells["clTAHTOP"].Value.ToString()) / 100) * kesintiyuzde;

            if (kesintitutar != kesintitutaronceki || kesintiyuzde != kesintiyuzdeonceki)
            {
                if (Convert.ToDouble(dataGridView1.Rows[e.RowIndex].Cells["clTAHTOP"].Value.ToString()) < 
                    Convert.ToDouble(kesintitutar.ToString("N2")))
                {
                    MessageBox.Show("Kesinti, tahsilattan büyük olamaz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView1.Rows[e.RowIndex].Cells["clKESTUTAR"].Value = DBNull.Value;
                    dataGridView1.Rows[e.RowIndex].Cells["clKESYUZDE"].Value = DBNull.Value;
                    return;
                }

                bool varmi = FinansCariHesapHareketler.VarMi(
                    Convert.ToInt64(dataGridView1.Rows[e.RowIndex].Cells["clLOGREF"].Value.ToString()),
                    Convert.ToInt16(dataGridView1.Rows[e.RowIndex].Cells["clMOD"].Value.ToString()),
                    Convert.ToInt16(dataGridView1.Rows[e.RowIndex].Cells["clTUR"].Value.ToString()),
                    dataGridView1.Rows[e.RowIndex].Cells["clFISNO"].Value.ToString());

                if (varmi)
                {
                    FinansCariHesapHareketler.DoUpdate(
                        Convert.ToInt64(dataGridView1.Rows[e.RowIndex].Cells["clLOGREF"].Value.ToString()),
                        Convert.ToInt16(dataGridView1.Rows[e.RowIndex].Cells["clMOD"].Value.ToString()),
                        Convert.ToInt16(dataGridView1.Rows[e.RowIndex].Cells["clTUR"].Value.ToString()),
                        dataGridView1.Rows[e.RowIndex].Cells["clFISNO"].Value.ToString(),
                        kesintitutar,
                        kesintiyuzde,
                        frmAna.KAdi.ToUpper(),
                        DateTime.Now,
                        Convert.ToBoolean(dataGridView1.Rows[e.RowIndex].Cells["clIPTAL"].Value.ToString()));
                }
                else
                {
                    FinansCariHesapHareketler fchh = new FinansCariHesapHareketler(
                        Convert.ToInt64(dataGridView1.Rows[e.RowIndex].Cells["clLOGREF"].Value.ToString()),
                        Convert.ToInt16(dataGridView1.Rows[e.RowIndex].Cells["clMOD"].Value.ToString()),
                        Convert.ToInt16(dataGridView1.Rows[e.RowIndex].Cells["clTUR"].Value.ToString()),
                        dataGridView1.Rows[e.RowIndex].Cells["clFISNO"].Value.ToString(),
                        kesintitutar,
                        kesintiyuzde,
                        frmAna.KAdi.ToUpper(),
                        DateTime.Now,
                        false);
                    fchh.DoInsert();
                    dataGridView1.Rows[e.RowIndex].Cells["clIPTAL"].Value = false;
                }
                
                dataGridView1.Rows[e.RowIndex].Cells["clKESTUTAR"].Value = kesintitutar;
                dataGridView1.Rows[e.RowIndex].Cells["clKESYUZDE"].Value = kesintiyuzde;
                dataGridView1.Rows[e.RowIndex].Cells["clKesintiFark"].Value = 
                    Convert.ToDouble(dataGridView1.Rows[e.RowIndex].Cells["clTAHTOP"].Value.ToString()) - kesintitutar;
                dataGridView1.Rows[e.RowIndex].Cells["clGUNCKIM"].Value = frmAna.KAdi.ToUpper();
                dataGridView1.Rows[e.RowIndex].Cells["clGUNCTARIH"].Value = DateTime.Now;
            }
        }

        private void txtMusteri_TextChanged(object sender, EventArgs e)
        {
            //int newtextlenght = txtMusteri.Text.Length;

            //if (newtextlenght > 2)
            //{
            //    Suz();
            //}
            //else if (textlength > 2 && newtextlenght <= 2 && (!cbTarih.Checked && cmbSatTem.SelectedIndex == -1))
            //{
            //    GetObjects();
            //}
            //else if (textlength > 2 && newtextlenght <= 2 && (cbTarih.Checked || cmbSatTem.SelectedIndex > -1))
            //{
            //    Suz();
            //}

            //textlength = newtextlenght;
        }

        private void cmbSatTem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSatTem.SelectedIndex > -1)
            {
                Suz();
            }
            else if (cbTarih.Checked || txtMusteri.Text.Length > 2)
            {
                Suz();
            }
            else
            {
                GetObjects();
            }
        }

        private void cbTarih_CheckedChanged(object sender, EventArgs e)
        {
            dtpBaslangic.Enabled = cbTarih.Checked;
            dtpBitis.Enabled = cbTarih.Checked;

            if (cbTarih.Checked)
            {
                Suz();
            }
            else if (!cbTarih.Checked && (txtMusteri.Text.Length > 2 || cmbSatTem.SelectedIndex > -1))
            {
                Suz();
            }
            else if (!cbTarih.Checked && (txtMusteri.Text.Length <= 2 && cmbSatTem.SelectedIndex == -1))
            {
                GetObjects();
            }
        }

        private void dtpBaslangic_ValueChanged(object sender, EventArgs e)
        {
            Suz();
        }

        private void btnYenile_Click(object sender, EventArgs e)
        {
            cbTarih.Checked = false;
            txtMusteri.Text = string.Empty;
            cmbSatTem.SelectedIndex = -1;
            GetObjects();
        }

        private void dataGridView1_DataSourceChanged(object sender, EventArgs e)
        {
            lblSatirSayisi.Text = dataGridView1.Rows.Count.ToString();

            if (cbToplamlar.Checked)
            {
                GetBilgiler();
            }
        }

        private void frmFinansCariHesapHareketler_SizeChanged(object sender, EventArgs e)
        {
            lblSatirSayisi.Location = new Point(this.Width - 72, lblSatirSayisi.Location.Y);
            lblSatirSayisi1.Location = new Point(this.Width - 139, lblSatirSayisi1.Location.Y);
            btnExcel.Location = new Point(btnExcel.Location.X, lblAlt.Location.Y + 2);
            progressBar1.Location = new Point(progressBar1.Location.X, lblAlt.Location.Y + 2);
            cbToplamlar.Location = new Point(this.Width - 676, lblAlt.Location.Y + 4);
            lblTahTop1.Location = new Point(this.Width - 640, lblAlt.Location.Y + 5);
            lblTahTop.Location = new Point(this.Width - 549, lblAlt.Location.Y + 5);
            lblKesTop1.Location = new Point(this.Width - 435, lblAlt.Location.Y + 5);
            lblKesTop.Location = new Point(this.Width - 350, lblAlt.Location.Y + 5);
            lblKesFarkTop1.Location = new Point(this.Width - 236, lblAlt.Location.Y + 5);
            lblKesFarkTop.Location = new Point(this.Width - 127, lblAlt.Location.Y + 5);
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

        private void cmbSatTem_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
                cmbSatTem.SelectedIndex = -1;
        }

        private void cbToplamlar_CheckedChanged(object sender, EventArgs e)
        {
            if (cbToplamlar.Checked)
                GetBilgiler();

            lblTahTop1.Visible = cbToplamlar.Checked;
            lblTahTop.Visible = cbToplamlar.Checked;
            lblKesTop1.Visible = cbToplamlar.Checked;
            lblKesTop.Visible = cbToplamlar.Checked;
            lblKesFarkTop1.Visible = cbToplamlar.Checked;
            lblKesFarkTop.Visible = cbToplamlar.Checked;
        }

        private void btnMusteriTemizle_Click(object sender, EventArgs e)
        {
            txtMusteri.Text = string.Empty;
        }

        private void btnSatTemTemizle_Click(object sender, EventArgs e)
        {
            cmbSatTem.SelectedIndex = -1;
        }

        private void txtMusteri_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnMusteriAra.PerformClick();
            }
        }

        private void btnMusteriAra_Click(object sender, EventArgs e)
        {
            //Suz();
            Suz2();
        }

        private void rb2013_CheckedChanged(object sender, EventArgs e)
        {
            btnYenile.PerformClick();
        }
    }
}

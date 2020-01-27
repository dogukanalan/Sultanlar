using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sultanlar.DatabaseObject.Internet;
using System.Threading;
using System.Collections;

namespace Sultanlar.UI
{
    public partial class frmINTERNETticaripazarlamabayistoklar : Form
    {
        public frmINTERNETticaripazarlamabayistoklar()
        {
            InitializeComponent();
        }

        Thread thr;
        ArrayList stokverileri = new ArrayList();

        private void frmINTERNETticaripazarlamabayistoklar_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            DevExpress.Data.CurrencyDataController.DisableThreadingProblemsDetection = true;
            CariHesaplarTP.GetObjects(cmbBayiler.Items, 0);
        }

        private void GetBos()
        {
            DataTable dt = new DataTable();
            BayiStoklari.GetObjects(dt, 100, 100, 100);
            gridControl1.DataSource = dt;
        }

        private void ExceldenAl(object dosya)
        {
            Microsoft.Office.Interop.Excel.Application ap = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook wb = null;
            Microsoft.Office.Interop.Excel.Worksheet ws = null;
            Microsoft.Office.Interop.Excel.Range range = null;

            object[,] values = null;

            try
            {
                wb = ap.Workbooks.Open(dosya.ToString(), false, true,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing, true);

                ws = (Microsoft.Office.Interop.Excel.Worksheet)wb.Worksheets[1];

                if (dosya.ToString().EndsWith(".xls"))
                    range = ws.get_Range("A1", "K65535");
                else
                    range = ws.get_Range("A1", "K1000000");

                values = (object[,])range.Value2;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                stokverileri.Clear();
                return;
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

            string oncekitext = this.Text;
            this.Enabled = false;
            for (int i = 2; i <= values.GetLength(0); i++) // 1.satır başlıklar
            {
                if (values[i, 1] == null) // 1.kolon boş ise bu satırdan sonrasına bakmasın
                    break;

                try
                {
                    ArrayList kolonlar = new ArrayList();
                    kolonlar.Add(Convert.ToInt32(values[i, 1]));
                    kolonlar.Add(Convert.ToInt32(values[i, 2]));
                    kolonlar.Add(Convert.ToInt32(values[i, 3]));
                    kolonlar.Add(Convert.ToInt32(values[i, 4]));
                    kolonlar.Add(Convert.ToDouble(values[i, 5]));

                    stokverileri.Add(kolonlar);

                    this.Text = "Bayi Stokları (Kontrol edilen satır: " + i.ToString() + ")";
                }
                catch (Exception ex)
                {
                    stokverileri.Clear();
                    MessageBox.Show("Hata oluşan satır: " + i.ToString() + "\r\nHata ayrıntısı: " + ex.Message);
                }
            }
            this.Enabled = true;
            this.Text = oncekitext;
           
            if (MessageBox.Show("Tüm dosya aktarım için hazır. Devam etmek istediğinize emin misiniz?", "Aktarım", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
            {
                Thread thr1 = new Thread(new ParameterizedThreadStart(AktarimYap));
                thr1.Start(stokverileri);
            }
        }

        private void AktarimYap(object stokverileri1)
        {
            string oncekitext = this.Text;
            this.Enabled = false;
            progressBar1.Visible = true;

            //if (MessageBox.Show("Seçilen bayinin \"" + cmbYil.SelectedItem.ToString() + " - " + cmbAy.SelectedItem.ToString() +
            //    "\" dönemlerindeki stok verisi silinecektir.\r\n\r\nDevam etmek istediğinize emin misiniz?\r\n\r\nNot: Devam etmediğiniz takdirde excel raporu verisi aktarılmayacaktır.", "Önemli Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
            //{
                //BayiStoklari.DoDelete(((CariHesaplarTP)cmbBayiler.SelectedItem).SMREF, Convert.ToInt32(cmbYil.SelectedItem.ToString()), Convert.ToInt32(cmbAy.SelectedItem.ToString()));

                progressBar1.Maximum = ((ArrayList)stokverileri1).Count;
                progressBar1.Value = 0;
                for (int i = 0; i < ((ArrayList)stokverileri1).Count; i++)
                {
                    this.Text = "Bayi Stokları (Aktarılan satır: " + i.ToString() + " / " + ((ArrayList)stokverileri1).Count.ToString() + ")";

                    BayiStoklari.DoInsert(
                        Convert.ToInt32(((ArrayList)((ArrayList)stokverileri1)[i])[0]),
                        Convert.ToInt32(((ArrayList)((ArrayList)stokverileri1)[i])[1]),
                        Convert.ToInt32(((ArrayList)((ArrayList)stokverileri1)[i])[2]),
                        Convert.ToInt32(((ArrayList)((ArrayList)stokverileri1)[i])[3]),
                        Convert.ToDouble(((ArrayList)((ArrayList)stokverileri1)[i])[4]),
                        DateTime.Now);

                    if (progressBar1.Value < progressBar1.Maximum) progressBar1.Value++;
                }
                MessageBox.Show("Aktarım tamamlandı.", "Aktarım", MessageBoxButtons.OK, MessageBoxIcon.Information);
                progressBar1.Value = 0;
            //}

            progressBar1.Visible = false;
            stokverileri.Clear();
            this.Enabled = true;
            this.Text = oncekitext;
        }

        private void sbGetir_Click(object sender, EventArgs e)
        {
            if (cmbBayiler.SelectedIndex > -1 && cmbYil.SelectedIndex > 0 && cmbAy.SelectedIndex > 0)
            {
                DataTable dt = new DataTable();
                BayiStoklari.GetObjects(dt, ((CariHesaplarTP)cmbBayiler.SelectedItem).GMREF, Convert.ToInt32(cmbYil.SelectedItem.ToString()), Convert.ToInt32(cmbAy.SelectedItem.ToString()));
                gridControl1.DataSource = dt;
            }
            else
            {
                MessageBox.Show("Lütfen bayi, yıl ve ay seçiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void sbExcel_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Excel dosyaları (*.xls, *.xlsx)|*.xls;*.xlsx;|Bütün Dosyalar|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                if (MessageBox.Show("Dosyadan aktarım yapmak istediğinize emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    GetBos();
                    thr = new Thread(new ParameterizedThreadStart(ExceldenAl));
                    thr.Start(ofd.FileName);
                }
            }
        }

        private void sbDonemSil_Click(object sender, EventArgs e)
        {
            if (cmbBayiler.SelectedIndex > -1 && cmbYil.SelectedIndex > 0 && cmbAy.SelectedIndex > 0)
            {
                if (MessageBox.Show(cmbBayiler.SelectedItem.ToString() + "Bayisinin " + cmbYil.SelectedItem.ToString() + " - " + cmbAy.SelectedItem.ToString() + " dönemi verileri silinecek. Devam etmek istediğinize emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    BayiStoklari.DoDelete(((CariHesaplarTP)cmbBayiler.SelectedItem).SMREF, Convert.ToInt32(cmbYil.SelectedItem.ToString()), Convert.ToInt32(cmbAy.SelectedItem.ToString()));
                }
            }
            else
            {
                MessageBox.Show("Lütfen bayi, yıl ve ay seçiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}

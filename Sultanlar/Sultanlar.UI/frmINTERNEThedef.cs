using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sultanlar.DatabaseObject.Internet;

namespace Sultanlar.UI
{
    public partial class frmINTERNEThedef : Form
    {
        public frmINTERNEThedef()
        {
            InitializeComponent();
        }

        bool ilkacilis;

        private void frmINTERNEThedef_Load(object sender, EventArgs e)
        {
            ilkacilis = true;

            numericUpDown1.Value = DateTime.Now.Month;
            txtYIL.Text = DateTime.Now.Year.ToString();

            GetPrimKategorileri();
            GetBayiler();

            ilkacilis = false;
        }

        private void GetHedefler()
        {
            DataTable dt = new DataTable();
            Urunler.GetHedefler(dt, checkBox2.Checked);
            gridControl1.DataSource = dt;
        }

        private void GetPrimKategorileri()
        {
            Urunler.GetProducts(comboBox1.Items, 0, "", "", "", "", true, false, false, true);
            comboBox1.SelectedIndex = 0;
        }

        private void GetBayiler()
        {
            CariHesaplarTP.GetObjects(listBox1.Items, 0);
            listBox1.SelectedIndex = 0;
        }

        private void GetSaticilar()
        {
            SatisTemsilcileri.GetObjects(listBox1.Items, true);
            listBox1.SelectedIndex = 0;
        }

        private void GetHedef()
        {
            if (radioButton1.Checked)
                txtPRIM.Text = Urunler.GetHedef(0, ((CariHesaplarTP)listBox1.SelectedItem).SMREF, Convert.ToInt32(txtYIL.Text.Trim()), Convert.ToInt32(numericUpDown1.Value), ((Urunler)comboBox1.SelectedItem).ITEMREF, checkBox2.Checked).ToString("N2");
            else
                txtPRIM.Text = Urunler.GetHedef(((SatisTemsilcileri)listBox1.SelectedItem).SLSREF, 0, Convert.ToInt32(txtYIL.Text.Trim()), Convert.ToInt32(numericUpDown1.Value), ((Urunler)comboBox1.SelectedItem).ITEMREF, checkBox2.Checked).ToString("N2");
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                if (radioButton1.Checked)
                    GetBayiler();
                else
                    GetSaticilar();
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!ilkacilis)
                GetHedef();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!ilkacilis)
                GetHedef();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (!ilkacilis)
                GetHedef();
        }

        private void txtYIL_TextChanged(object sender, EventArgs e)
        {
            if (!ilkacilis)
                GetHedef();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
                Urunler.SetHedef(0, ((CariHesaplarTP)listBox1.SelectedItem).SMREF, Convert.ToInt32(txtYIL.Text.Trim()), Convert.ToInt32(numericUpDown1.Value), ((Urunler)comboBox1.SelectedItem).ITEMREF, Convert.ToDouble(txtPRIM.Text.Trim()), checkBox2.Checked);
            else
                Urunler.SetHedef(((SatisTemsilcileri)listBox1.SelectedItem).SLSREF, 0, Convert.ToInt32(txtYIL.Text.Trim()), Convert.ToInt32(numericUpDown1.Value), ((Urunler)comboBox1.SelectedItem).ITEMREF, Convert.ToDouble(txtPRIM.Text.Trim()), checkBox2.Checked);

            MessageBox.Show("Yeni hedef girildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            GetHedefler();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Excel dosyaları (*.xls, *.xlsx)|*.xls;*.xlsx;|Bütün Dosyalar|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
                ExceldenAl(ofd.FileName);
        }

        private void ExceldenAl(string dosya)
        {
            Microsoft.Office.Interop.Excel.Application ap = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook wb = null;
            Microsoft.Office.Interop.Excel.Worksheet ws = null;
            Microsoft.Office.Interop.Excel.Range range = null;

            object[,] values = null;

            try
            {
                wb = ap.Workbooks.Open(dosya, false, true,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing, true);

                ws = (Microsoft.Office.Interop.Excel.Worksheet)wb.Worksheets[1];

                if (dosya.EndsWith(".xls"))
                    range = ws.get_Range("A1", "K65535");
                else
                    range = ws.get_Range("A1", "K1000000");

                values = (object[,])range.Value2;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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

            for (int i = 2; i <= values.GetLength(0); i++) // 1.satır başlıklar
            {
                if (values[i, 1] == null) // 1.kolon boş ise bu satırdan sonrasına bakmasın
                    break;

                try
                {
                    Urunler.SetHedef(Convert.ToInt32(values[i, 1]), Convert.ToInt32(values[i, 2]),
                        Convert.ToInt32(values[i, 3]), Convert.ToInt32(values[i, 4]), Convert.ToInt32(values[i, 5]), Convert.ToDouble(values[i, 6]), checkBox2.Checked);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata oluşan satır: " + i.ToString() + "\r\nHata ayrıntısı: " + ex.Message);
                }
            }

            MessageBox.Show("Tüm satırlardaki hedefler başarıyla girildi", "İşlem Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            GetHedefler();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            gridControl1.Visible = checkBox1.Checked;
            listBox1.Visible = !checkBox1.Checked;
            panel1.Visible = !checkBox1.Checked;
            if (checkBox1.Checked)
                GetHedefler();
        }

        private void btnExcelYardim_Click(object sender, EventArgs e)
        {
            frmYardim frm = new frmYardim(Sultanlar.UI.Properties.Resources.Hedef);
            frm.ShowDialog();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (!ilkacilis)
                GetHedef();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmINTERNEThedeforan frm = new frmINTERNEThedeforan();
            frm.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Hedef silinecek, emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (radioButton1.Checked)
                {
                    Urunler.SilHedef(0, Convert.ToInt32(txtBAYISIL.Text.Trim()), Convert.ToInt32(txtYILSIL.Text.Trim()), Convert.ToInt32(numericUpDown2.Value), checkBox2.Checked);
                    MessageBox.Show("Hedef silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}

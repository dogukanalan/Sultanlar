using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sultanlar.DatabaseObject.Internet;

namespace Sultanlar.UI
{
    public partial class frmINTERNETticaripazarlamavericekme : Form
    {
        public frmINTERNETticaripazarlamavericekme()
        {
            InitializeComponent();
        }

        bool satisgeldi, stokgeldi;

        private void frmINTERNETticaripazarlamavericekme_Load(object sender, EventArgs e)
        {
            CariHesaplarTP.GetObjects(comboBox1.Items, 0);
            satisgeldi = false;
            stokgeldi = false;
        }

        private void TabloOlustur(string tabloadi)
        {
            string sorgu = "IF OBJECT_ID('" + tabloadi + "', 'U') IS NOT NULL DROP TABLE " + tabloadi +
                           " CREATE TABLE " + tabloadi + " (";

            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                sorgu += "[" + dataGridView1.Columns[i].Name.Replace("+", "").Replace("-", "").Replace(" ", "").Replace(".", "").Replace("?", "").Replace("!", "") + "] " + VeriDonustur(dataGridView1.Columns[i].ValueType.Name) + " NULL,";
            }

            sorgu = sorgu.Substring(0, sorgu.Length - 1) + ")";

            DisVeri.ExecNQ(sorgu);
        }

        private void TabloYaz(string tabloadi)
        {
            bool yenimi = false;
            if (!Convert.ToBoolean(DisVeri.ExecSc("SELECT CASE WHEN OBJECT_ID('" + tabloadi + "', 'U') IS NOT NULL THEN 1 ELSE 0 END"))) // tablo oluşmuş ise
            {
                TabloOlustur(tabloadi);
                yenimi = true;
            }

            VeriYaz(tabloadi, yenimi);
        }

        private void VeriYaz(string tabloadi, bool yeniolustu)
        {
            ArrayList kolonlar = new ArrayList();
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                kolonlar.Add(dataGridView1.Columns[i].Name.Replace("+", "").Replace("-", "").Replace(" ", "").Replace(".", "").Replace("?", "").Replace("!", ""));
            }

            if (!yeniolustu) //gelen kolonlar ile yazılmış tablodaki aynı mı kontrol et
            {
                bool hatali = false;
                DataTable dt = DisVeri.ExecDaRe("SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '" + tabloadi + "'");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i][0].ToString() != kolonlar[i].ToString())
                    {
                        hatali = true;
                    }
                }
                if (hatali)
                {
                    MessageBox.Show("Gelen veri ile oluşturulmuş tablo alanları uyumlu değil.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            DisVeri.ExecNQ("DELETE FROM " + tabloadi + " WHERE " + textBox17.Text.Trim() + "=" + textBox15.Text.Trim() + " AND " + textBox18.Text.Trim() + "=" + textBox16.Text.Trim());

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                string kolonsorgu = string.Empty;
                string eklesorgu = "INSERT INTO " + tabloadi + " (";

                object[] veriler = new object[kolonlar.Count];
                for (int j = 0; j < kolonlar.Count; j++)
                {
                    kolonsorgu += "[" + kolonlar[j] + "],";
                    veriler[j] = dataGridView1.Rows[i].Cells[j].Value;
                }

                kolonsorgu = kolonsorgu.Substring(0, kolonsorgu.Length - 1);
                eklesorgu += kolonsorgu + ") VALUES (" + kolonsorgu.Replace("[", "@").Replace("]", "") + ")";

                DisVeri.ExecNQwp(eklesorgu, kolonlar, veriler);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DisVeri.DoInsert(((CariHesaplarTP)comboBox1.SelectedItem).SMREF, textBox1.Text.Trim(), textBox6.Text.Trim(), textBox2.Text.Trim(), textBox3.Text.Trim(), textBox4.Text.Trim(), textBox5.Text.Trim(), textBox7.Text.Trim(), textBox8.Text.Trim(), textBox11.Text.Trim(), textBox13.Text.Trim());
            MessageBox.Show("Kaydedildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e) // satis
        {
            try
            {
                string where = checkBox1.Checked ? " WHERE " + textBox7.Text.Trim() + "=" + textBox9.Text.Trim() + " AND " + textBox8.Text.Trim() + "=" + textBox10.Text.Trim() : "";
                SqlConnection conn = new SqlConnection("Server=" + textBox1.Text.Trim() + "; Database=" + textBox6.Text.Trim() + "; User Id=" + textBox2.Text.Trim() + "; Password=" + textBox3.Text.Trim() + "; Trusted_Connection=False;");
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM (" + textBox4.Text.Trim() + ") AS TABLO" + where, conn);
                da.SelectCommand.CommandTimeout = 1000;
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                label11.Text = dt.Rows.Count.ToString();
                textBox17.Text = textBox7.Text.Trim();
                textBox18.Text = textBox8.Text.Trim();
                textBox15.Text = textBox9.Text.Trim();
                textBox16.Text = textBox10.Text.Trim();
                label14.Text = "Satış";

                satisgeldi = true;
                stokgeldi = false;
            }
            catch (Exception ex)
            {
                satisgeldi = false;
                stokgeldi = false;
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e) // stok
        {
            try
            {
                string where = checkBox2.Checked ? " WHERE " + textBox11.Text.Trim() + " = " + textBox12.Text.Trim() + " AND " + textBox13.Text.Trim() + " = " + textBox14.Text.Trim() : "";
                SqlConnection conn = new SqlConnection("Server=" + textBox1.Text.Trim() + "; Database=" + textBox6.Text.Trim() + "; User Id=" + textBox2.Text.Trim() + "; Password=" + textBox3.Text.Trim() + "; Trusted_Connection=False;");
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM (" + textBox5.Text.Trim() + ") AS TABLO" + where, conn);
                da.SelectCommand.CommandTimeout = 1000;
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                label11.Text = dt.Rows.Count.ToString();
                textBox17.Text = textBox11.Text.Trim();
                textBox18.Text = textBox13.Text.Trim();
                textBox15.Text = textBox12.Text.Trim();
                textBox16.Text = textBox14.Text.Trim();
                label14.Text = "Stok";

                satisgeldi = false;
                stokgeldi = true;
            }
            catch (Exception ex)
            {
                satisgeldi = false;
                stokgeldi = false;
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisVeri dis = DisVeri.GetObject(((CariHesaplarTP)comboBox1.SelectedItem).SMREF);
            textBox1.Text = dis.SUNUCU;
            textBox6.Text = dis.VERITABANI;
            textBox2.Text = dis.KULLANICI;
            textBox3.Text = dis.SIFRE;
            textBox4.Text = dis.VERISORGU;
            textBox5.Text = dis.STOKSORGU;
            textBox7.Text = dis.YILKOLON;
            textBox8.Text = dis.AYKOLON;
            textBox11.Text = dis.YILKOLON1;
            textBox13.Text = dis.AYKOLON1;

            dataGridView1.DataSource = null;
            textBox9.Text = "2014";
            textBox10.Text = "1";
            textBox12.Text = "2014";
            textBox14.Text = "1";

            button1.Enabled = true;
            button2.Enabled = dis.SUNUCU != null;
            button3.Enabled = dis.SUNUCU != null;
            button4.Enabled = true;
            button5.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e) // satis olustur
        {
            if (satisgeldi)
            {
                if (MessageBox.Show("Satış tablosunu yeniden oluşturmak istediğinize emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    string tabloadi = "tbl" + ((CariHesaplarTP)comboBox1.SelectedItem).SMREF.ToString() + "_Satis";
                    TabloOlustur(tabloadi);
                }
            }
            else
            {
                MessageBox.Show("Satış tablosu veri getirilmeden oluşturulamaz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button5_Click(object sender, EventArgs e) // stok olustur
        {
            if (stokgeldi)
            {
                if (MessageBox.Show("Stok tablosunu yeniden oluşturmak istediğinize emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    string tabloadi = "tbl" + ((CariHesaplarTP)comboBox1.SelectedItem).SMREF.ToString() + "_Stok";
                    TabloOlustur(tabloadi);
                }
            }
            else
            {
                MessageBox.Show("Stok tablosu veri getirilmeden oluşturulamaz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button4_Click_1(object sender, EventArgs e) // satis yaz
        {
            if (satisgeldi)
            {
                if (MessageBox.Show("Satış tablosunda " + ((CariHesaplarTP)comboBox1.SelectedItem).MUSTERI + " (" + ((CariHesaplarTP)comboBox1.SelectedItem).SMREF.ToString() + ") " + textBox15.Text.Trim() + "-" + textBox16.Text.Trim() + " dönemi üzerine yazma yapılacak, devam etmek istediğinize emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    string tabloadi = "tbl" + ((CariHesaplarTP)comboBox1.SelectedItem).SMREF.ToString() + "_Satis";
                    TabloYaz(tabloadi);
                    MessageBox.Show("Satış verisi yazıldı:\r\n\r\n" + ((CariHesaplarTP)comboBox1.SelectedItem).MUSTERI + "\r\n(" + ((CariHesaplarTP)comboBox1.SelectedItem).SMREF.ToString() + ")\r\n\r\n" + textBox15.Text.Trim() + "-" + textBox16.Text.Trim(), "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Satış yazma işlemi veri getirilmeden yapılamaz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button5_Click_1(object sender, EventArgs e) // stok yaz
        {
            if (stokgeldi)
            {
                if (MessageBox.Show("Stok tablosunda " + ((CariHesaplarTP)comboBox1.SelectedItem).MUSTERI + " (" + ((CariHesaplarTP)comboBox1.SelectedItem).SMREF.ToString() + ") " + textBox15.Text.Trim() + "-" + textBox16.Text.Trim() + " dönemi üzerine yazma yapılacak, devam etmek istediğinize emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    string tabloadi = "tbl" + ((CariHesaplarTP)comboBox1.SelectedItem).SMREF.ToString() + "_Stok";
                    TabloYaz(tabloadi);
                    MessageBox.Show("Stok verisi yazıldı:\r\n\r\n" + ((CariHesaplarTP)comboBox1.SelectedItem).MUSTERI + "\r\n(" + ((CariHesaplarTP)comboBox1.SelectedItem).SMREF.ToString() + ")\r\n\r\n" + textBox15.Text.Trim() + "-" + textBox16.Text.Trim(), "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Stok yazma işlemi veri getirilmeden yapılamaz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private string VeriDonustur(string tip)
        {
            string donendeger = string.Empty;

            switch (tip)
            {
                case "Int16":
                    donendeger = "smallint";
                    break;
                case "Int32":
                    donendeger = "int";
                    break;
                case "String":
                    donendeger = "nvarchar(255)";
                    break;
                case "DateTime":
                    donendeger = "datetime";
                    break;
                case "Double":
                    donendeger = "float";
                    break;
                default:
                    break;
            }

            return donendeger;
        }
    }
}

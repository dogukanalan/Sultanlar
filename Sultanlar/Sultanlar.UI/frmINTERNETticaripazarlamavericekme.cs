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
        DataTable dtGelen = new DataTable();

        private void frmINTERNETticaripazarlamavericekme_Load(object sender, EventArgs e)
        {
            if (frmAna.KAdi != "BI04" && frmAna.KAdi != "ADMİNİSTRATOR")
            {
                groupBox1.Enabled = false;
                groupBox2.Enabled = false;
            }

            textBox9.Text = DateTime.Now.Year.ToString();
            textBox12.Text = DateTime.Now.Year.ToString();
            textBox21.Text = DateTime.Now.Year.ToString();
            textBox23.Text = DateTime.Now.Year.ToString();
            textBox10.Text = DateTime.Now.Month.ToString();
            textBox14.Text = DateTime.Now.Month.ToString();
            textBox22.Text = DateTime.Now.Month.ToString();
            textBox24.Text = DateTime.Now.Month.ToString();

            CariHesaplarTP.GetObjects(comboBox1.Items, 0);
            CariHesaplarTP.GetObjects(checkedListBox1.Items, 0);

            satisgeldi = false;
            stokgeldi = false;

            /*System.Xml.XmlReader xmlFile;
            xmlFile = System.Xml.XmlReader.Create(@"http://95.0.47.130/SulWCF/General.svc/web/xml/Gokw3/Stok?yil=2014&ay=1", new System.Xml.XmlReaderSettings());
            DataSet ds = new DataSet("tbl_");
            ds.ReadXml(xmlFile);
            dataGridView1.DataSource = ds.Tables[0];*/
        }

        /*private void TabloOlustur(string tabloadi)
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
                TabloOlustur(tabloadi, dtGelen);
                yenimi = true;
            }

            VeriYaz(tabloadi, yenimi, dtGelen, textBox17.Text.Trim(), textBox15.Text.Trim(), textBox18.Text.Trim(), textBox16.Text.Trim());
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
        }*/

        private void button1_Click(object sender, EventArgs e)
        {
            if ((textBox4.Text.Trim() != string.Empty && textBox19.Text.Trim() != string.Empty) || (textBox5.Text.Trim() != string.Empty && textBox20.Text.Trim() != string.Empty))
            {
                if (MessageBox.Show("Hem sql hem xml alanları dolu. Bu şekilde veri ikisinden de çekilecektir. Devam etmek istiyor musunuz?", "Önemli Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    DisVeri.DoInsert(((CariHesaplarTP)comboBox1.SelectedItem).SMREF, textBox1.Text.Trim(), textBox6.Text.Trim(), textBox2.Text.Trim(), textBox3.Text.Trim(), textBox4.Text.Trim(), textBox5.Text.Trim(), textBox7.Text.Trim(), textBox8.Text.Trim(), textBox11.Text.Trim(), textBox13.Text.Trim(), textBox19.Text.Trim(), textBox20.Text.Trim());
                    MessageBox.Show("Kaydedildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                DisVeri.DoInsert(((CariHesaplarTP)comboBox1.SelectedItem).SMREF, textBox1.Text.Trim(), textBox6.Text.Trim(), textBox2.Text.Trim(), textBox3.Text.Trim(), textBox4.Text.Trim(), textBox5.Text.Trim(), textBox7.Text.Trim(), textBox8.Text.Trim(), textBox11.Text.Trim(), textBox13.Text.Trim(), textBox19.Text.Trim(), textBox20.Text.Trim());
                MessageBox.Show("Kaydedildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button2_Click(object sender, EventArgs e) // satis sorgu
        {
            try
            {
                string where = checkBox1.Checked ? " WHERE " + textBox7.Text.Trim() + "=" + textBox9.Text.Trim() + " AND " + textBox8.Text.Trim() + "=" + textBox10.Text.Trim() : "";
                SqlConnection conn = new SqlConnection("Server=" + textBox1.Text.Trim() + "; Database=" + textBox6.Text.Trim() + "; User Id=" + textBox2.Text.Trim() + "; Password=" + textBox3.Text.Trim() + "; Trusted_Connection=False;");
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM (" + textBox4.Text.Trim() + ") AS TABLO" + where, conn);
                da.SelectCommand.CommandTimeout = 1000;
                dtGelen = new DataTable();
                da.Fill(dtGelen);
                dataGridView1.DataSource = dtGelen;

                label11.Text = dtGelen.Rows.Count.ToString();
                textBox17.Text = textBox7.Text.Trim();
                textBox18.Text = textBox8.Text.Trim();
                textBox15.Text = textBox9.Text.Trim();
                textBox16.Text = textBox10.Text.Trim();
                label14.Text = "(Satış Query Verisi)";

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

        private void button3_Click(object sender, EventArgs e) // stok sorgu
        {
            try
            {
                string where = checkBox2.Checked ? " WHERE " + textBox11.Text.Trim() + " = " + textBox12.Text.Trim() + " AND " + textBox13.Text.Trim() + " = " + textBox14.Text.Trim() : "";
                SqlConnection conn = new SqlConnection("Server=" + textBox1.Text.Trim() + "; Database=" + textBox6.Text.Trim() + "; User Id=" + textBox2.Text.Trim() + "; Password=" + textBox3.Text.Trim() + "; Trusted_Connection=False;");
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM (" + textBox5.Text.Trim() + ") AS TABLO" + where, conn);
                da.SelectCommand.CommandTimeout = 1000;
                dtGelen = new DataTable();
                da.Fill(dtGelen);
                dataGridView1.DataSource = dtGelen;

                label11.Text = dtGelen.Rows.Count.ToString();
                textBox17.Text = textBox11.Text.Trim();
                textBox18.Text = textBox13.Text.Trim();
                textBox15.Text = textBox12.Text.Trim();
                textBox16.Text = textBox14.Text.Trim();
                label14.Text = "(Stok Query Verisi)";

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

        private string XmlParams(string server, string database, string user, string password, string YILAD, string YILDEGER, string AYAD, string AYDEGER)
        {
            string sunucu = "server=" + server + "&";
            string veritabani = "database=" + database + "&";
            string kullanici = "user=" + user + "&";
            string sifre = "password=" + password + "&";
            string paramn = "paramn=" + YILAD + ";" + AYAD + "&";
            string paramv = "paramv=" + YILDEGER + ";" + AYDEGER;
            return sunucu + veritabani + kullanici + sifre + paramn + paramv;
        }

        private void button8_Click(object sender, EventArgs e) // satis xml
        {
            try
            {
                System.Xml.XmlReader xmlFile;
                xmlFile = System.Xml.XmlReader.Create(textBox19.Text.Trim() + "&" + DisVeri.XmlParams(textBox1.Text.Trim(), textBox6.Text.Trim(), textBox2.Text.Trim(), textBox3.Text.Trim(), textBox7.Text.Trim(), textBox9.Text.Trim(), textBox8.Text.Trim(), textBox10.Text.Trim()), new System.Xml.XmlReaderSettings());
                DataSet ds = new DataSet("tbl_");
                ds.ReadXml(xmlFile);
                dtGelen = ds.Tables[0];
                dataGridView1.DataSource = ds.Tables[0];

                label11.Text = ds.Tables[0].Rows.Count.ToString();
                textBox17.Text = textBox7.Text.Trim();
                textBox18.Text = textBox8.Text.Trim();
                textBox15.Text = textBox9.Text.Trim();
                textBox16.Text = textBox10.Text.Trim();
                label14.Text = "(Satış XML Verisi)";

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

        private void button9_Click(object sender, EventArgs e) // stok xml
        {
            try
            {
                System.Xml.XmlReader xmlFile;
                xmlFile = System.Xml.XmlReader.Create(textBox20.Text.Trim() + "&" + DisVeri.XmlParams(textBox1.Text.Trim(), textBox6.Text.Trim(), textBox2.Text.Trim(), textBox3.Text.Trim(), textBox11.Text.Trim(), textBox12.Text.Trim(), textBox13.Text.Trim(), textBox14.Text.Trim()), new System.Xml.XmlReaderSettings());
                DataSet ds = new DataSet("tbl_");
                ds.ReadXml(xmlFile);
                dtGelen = ds.Tables[0];
                dataGridView1.DataSource = ds.Tables[0];

                label11.Text = ds.Tables[0].Rows.Count.ToString();
                textBox17.Text = textBox11.Text.Trim();
                textBox18.Text = textBox13.Text.Trim();
                textBox15.Text = textBox12.Text.Trim();
                textBox16.Text = textBox14.Text.Trim();
                label14.Text = "(Stok XML Verisi)";

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
            textBox19.Text = dis.VERIXML;
            textBox20.Text = dis.STOKXML;

            dataGridView1.DataSource = null;

            textBox17.Text = string.Empty;
            textBox18.Text = string.Empty;
            textBox15.Text = string.Empty;
            textBox16.Text = string.Empty;
            label14.Text = string.Empty;

            button1.Enabled = true;
            button2.Enabled = dis.SUNUCU != null;
            button3.Enabled = dis.SUNUCU != null;
            button8.Enabled = dis.SUNUCU != null;
            button9.Enabled = dis.SUNUCU != null;
            button4.Enabled = true;
            button5.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e) // satis olustur
        {
            if (satisgeldi)
            {
                if (MessageBox.Show("Satış tablosunu yeniden oluşturmak istediğinize emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    string tabloadi = "tbl_" + ((CariHesaplarTP)comboBox1.SelectedItem).SMREF.ToString() + "_Satis";
                    DisVeri.TabloOlustur(tabloadi, dtGelen);
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
                    string tabloadi = "tbl_" + ((CariHesaplarTP)comboBox1.SelectedItem).SMREF.ToString() + "_Stok";
                    DisVeri.TabloOlustur(tabloadi, dtGelen);
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
                    string tabloadi = "tbl_" + ((CariHesaplarTP)comboBox1.SelectedItem).SMREF.ToString() + "_Satis";
                    if (DisVeri.TabloYaz(tabloadi, dtGelen, textBox17.Text.Trim(), textBox15.Text.Trim(), textBox18.Text.Trim(), textBox16.Text.Trim(), true))
                        MessageBox.Show("Satış verisi yazıldı:\r\n\r\n" + ((CariHesaplarTP)comboBox1.SelectedItem).MUSTERI + "\r\n(" + ((CariHesaplarTP)comboBox1.SelectedItem).SMREF.ToString() + ")\r\n\r\n" + textBox15.Text.Trim() + "-" + textBox16.Text.Trim(), "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Hata oluştu, program kayıtlarına bakın:\r\n\r\n" + ((CariHesaplarTP)comboBox1.SelectedItem).MUSTERI + "\r\n(" + ((CariHesaplarTP)comboBox1.SelectedItem).SMREF.ToString() + ")\r\n\r\n" + textBox15.Text.Trim() + "-" + textBox16.Text.Trim(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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
                    string tabloadi = "tbl_" + ((CariHesaplarTP)comboBox1.SelectedItem).SMREF.ToString() + "_Stok";
                    if (DisVeri.TabloYaz(tabloadi, dtGelen, textBox17.Text.Trim(), textBox15.Text.Trim(), textBox18.Text.Trim(), textBox16.Text.Trim(), true))
                        MessageBox.Show("Stok verisi yazıldı:\r\n\r\n" + ((CariHesaplarTP)comboBox1.SelectedItem).MUSTERI + "\r\n(" + ((CariHesaplarTP)comboBox1.SelectedItem).SMREF.ToString() + ")\r\n\r\n" + textBox15.Text.Trim() + "-" + textBox16.Text.Trim(), "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Hata oluştu, program kayıtlarına bakın:\r\n\r\n" + ((CariHesaplarTP)comboBox1.SelectedItem).MUSTERI + "\r\n(" + ((CariHesaplarTP)comboBox1.SelectedItem).SMREF.ToString() + ")\r\n\r\n" + textBox15.Text.Trim() + "-" + textBox16.Text.Trim(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            else
            {
                MessageBox.Show("Stok yazma işlemi veri getirilmeden yapılamaz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /*private string VeriDonustur(string tip)
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
        }*/

        private ArrayList SecilenBayiler(out string bayiler)
        {
            ArrayList donendeger = new ArrayList();
            bayiler = "\r\n";
            for (int i = 0; i < checkedListBox1.CheckedItems.Count; i++)
            {
                donendeger.Add(((CariHesaplarTP)checkedListBox1.CheckedItems[i]).SMREF);
                bayiler += "\r\n" + ((CariHesaplarTP)checkedListBox1.CheckedItems[i]).MUSTERI;
            }
            return donendeger;
        }


        private void button12_Click(object sender, EventArgs e)
        {
            string bayi = string.Empty;
            ArrayList bayiler = SecilenBayiler(out bayi);

            if (MessageBox.Show("Aşağıdaki bayilerin satış tablolarında " + textBox21.Text.Trim() + "-" + textBox22.Text.Trim() + " dönemi üzerine yazma yapılacak, devam etmek istediğinize emin misiniz?" + bayi, "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                if (DisVeri.BayiServis(textBox21.Text.Trim(), textBox22.Text.Trim(), true, bayiler))
                    MessageBox.Show("Yazma işlemi tamamlandı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Yazma işlemi sırasında en az bir bayide hata oluştu. Hata olmayan bayiler yazıldı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            string bayi = string.Empty;
            ArrayList bayiler = SecilenBayiler(out bayi);

            if (MessageBox.Show("Aşağıdaki bayilerin stok tablolarında " + textBox21.Text.Trim() + "-" + textBox22.Text.Trim() + " dönemi üzerine yazma yapılacak, devam etmek istediğinize emin misiniz?" + bayi, "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                if (DisVeri.BayiServis(textBox21.Text.Trim(), textBox22.Text.Trim(), false, bayiler))
                    MessageBox.Show("Yazma işlemi tamamlandı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Yazma işlemi sırasında en az bir bayide hata oluştu. Hata olmayan bayiler yazıldı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void button12_Click_1(object sender, EventArgs e)
        {
            string bayi = string.Empty;
            ArrayList bayiler = SecilenBayiler(out bayi);

            if (MessageBox.Show("Aşağıdaki bayilerin satış tablolarında " + textBox21.Text.Trim() + "-" + textBox22.Text.Trim() + " dönemi üzerine yazma yapılacak, devam etmek istediğinize emin misiniz?" + bayi, "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                if (DisVeri.BayiServisXML(textBox21.Text.Trim(), textBox22.Text.Trim(), true, bayiler))
                    MessageBox.Show("Yazma işlemi tamamlandı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Yazma işlemi sırasında en az bir bayide hata oluştu. Hata olmayan bayiler yazıldı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void button13_Click_1(object sender, EventArgs e)
        {
            string bayi = string.Empty;
            ArrayList bayiler = SecilenBayiler(out bayi);

            if (MessageBox.Show("Aşağıdaki bayilerin stok tablolarında " + textBox21.Text.Trim() + "-" + textBox22.Text.Trim() + " dönemi üzerine yazma yapılacak, devam etmek istediğinize emin misiniz?" + bayi, "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                if (DisVeri.BayiServisXML(textBox21.Text.Trim(), textBox22.Text.Trim(), false, bayiler))
                    MessageBox.Show("Yazma işlemi tamamlandı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Yazma işlemi sırasında en az bir bayide hata oluştu. Hata olmayan bayiler yazıldı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex > -1)
            {
                DisVeri dis = DisVeri.GetObject(((CariHesaplarTP)comboBox1.SelectedItem).SMREF);

                if (dis.SUNUCU != string.Empty)
                {
                    frmINTERNETticaripazarlamavericekmemusteri frm = new frmINTERNETticaripazarlamavericekmemusteri(dis.SMREF);
                    frm.ShowDialog();
                }
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex > -1)
            {
                string smref = ((CariHesaplarTP)comboBox1.SelectedItem).SMREF.ToString();
                string bayi = ((CariHesaplarTP)comboBox1.SelectedItem).MUSTERI;
                string tablo = "[tbl_" + smref + "_Satis]";
                if (MessageBox.Show("(" + smref + ") " + bayi + " bayisinin " + textBox21.Text.Trim() + "-" + textBox22.Text.Trim() + " dönemi satış verisi, " + textBox23.Text.Trim() + "-" + textBox24.Text.Trim() + " dönemi ticari pazarlama satış verisinin üzerine yazılacak. Devam etmek istiyor musunuz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    int satirsayisi = DisVeri.SatisAktar(smref, bayi, tablo, textBox23.Text.Trim(), textBox24.Text.Trim());
                    if (satirsayisi == 0)
                    {
                        MessageBox.Show("(" + smref + ") " + bayi + " bayisinin " + textBox23.Text.Trim() + "-" + textBox24.Text.Trim() + " dönemi ticari pazarlama satış tablosuna yazma işlemi tamamlandı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Eşleşmeyen cariler var. Toplam cari sayısı: " + satirsayisi.ToString(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        button18.PerformClick();
                    }
                }
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex > -1)
            {
                string smref = ((CariHesaplarTP)comboBox1.SelectedItem).SMREF.ToString();
                string bayi = ((CariHesaplarTP)comboBox1.SelectedItem).MUSTERI;
                if (MessageBox.Show("(" + smref + ") " + bayi + " bayisinin stok verisi, " + textBox23.Text.Trim() + "-" + textBox24.Text.Trim() + " dönemi ticari pazarlama stok verisinin üzerine yazılacak. Devam etmek istiyor musunuz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    string tablo = "[tbl_" + smref + "_Stok]";
                    if (DisVeri.StokAktar(smref, bayi, tablo, textBox23.Text.Trim(), textBox24.Text.Trim()))
                        MessageBox.Show("(" + smref + ") " + bayi + " bayisinin " + textBox23.Text.Trim() + "-" + textBox24.Text.Trim() + " dönemi ticari pazarlama stok tablosuna yazma işlemi tamamlandı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Stok yazma işleminde hata oluştu, veri tipleri uyuşmadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}

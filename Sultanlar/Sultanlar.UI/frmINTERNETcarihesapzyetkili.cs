using Sultanlar.DatabaseObject;
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
    public partial class frmINTERNETcarihesapzyetkili : Form
    {
        public frmINTERNETcarihesapzyetkili(int smref, int tip, string musteri, string sube)
        {
            InitializeComponent();
            SMREF = smref;
            TIP = tip;
            MUSTERI = musteri;
            SUBE = sube;
        }

        int SMREF;
        int TIP;
        string MUSTERI;
        string SUBE;

        private void frmINTERNETcarihesapzyetkili_Load(object sender, EventArgs e)
        {
            GetTurler();
            GetObjects();
            this.Text = "Yetkililer : " + MUSTERI + " - " + SUBE;
        }

        private void GetTurler()
        {
            WebGenel.SorguCl(comboBox1.Items, "SELECT KOD, ACIKLAMA FROM [Web-Musteri-Acik-Yetkili-Tur] ORDER BY ACIKLAMA");
            comboBox1.SelectedIndex = 0;
        }

        private void GetObjects()
        {
            DataTable dt = new DataTable();
            WebGenel.Sorgu(dt, "SELECT YET.KOD AS Kod, [Web-Musteri-Acik-Yetkili-Tur].ACIKLAMA AS [Tür],[ISIM] AS [Isim],[SOYISIM] AS [Soyisim],[TELEFON] AS [Telefon No],[CEP] AS [Mobil No],[EPOSTA] AS [E-posta],[UNVAN] AS [Ünvan],YET.[ACIKLAMA] AS [Açıklama] FROM [Web-Musteri-Acik-Yetkili] AS YET INNER JOIN [Web-Musteri-Acik-Yetkili-Tur] ON TUR = [Web-Musteri-Acik-Yetkili-Tur].KOD WHERE PASIF = 'False' AND YET.SMREF = " + SMREF.ToString() + "AND YET.TIP = " + TIP.ToString());
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string kod = dataGridView1.SelectedRows[0].Cells["Kod"].Value.ToString();
            WebGenel.Sorgu("UPDATE [Web-Musteri-Acik-Yetkili] SET PASIF = 'True' WHERE KOD = " + kod);
            GetObjects();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string kod = ((WebGenelClass)comboBox1.SelectedItem).Kod.ToString();
            WebGenel.Sorgu("INSERT INTO [Web-Musteri-Acik-Yetkili] ([SMREF],[TIP],[TARIH],[PASIF],[TUR],[ISIM],[SOYISIM],[TELEFON],[CEP],[EPOSTA],[UNVAN],[ACIKLAMA]) VALUES (" + SMREF.ToString() + "," + TIP.ToString() + ",getdate(),'False'," + kod + ",'" + textBox1.Text.Trim() + "','" + textBox2.Text.Trim() + "','" + textBox4.Text.Trim() + "','" + textBox5.Text.Trim() + "','" + textBox6.Text.Trim() + "','" + textBox3.Text.Trim() + "','" + textBox7.Text.Trim() + "')");
            GetObjects();
        }
    }
}

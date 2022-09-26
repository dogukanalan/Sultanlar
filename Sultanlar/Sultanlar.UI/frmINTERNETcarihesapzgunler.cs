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
    public partial class frmINTERNETcarihesapzgunler : Form
    {
        public frmINTERNETcarihesapzgunler(int smref, int tip, string musteri, string sube)
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

        private void frmINTERNETcarihesapzgunler_Load(object sender, EventArgs e)
        {
            GetGunler();
            GetObjects();
            this.Text = "Günler : " + MUSTERI + " - " + SUBE;
        }

        private void GetGunler()
        {
            WebGenel.SorguCl(comboBox1.Items, "SELECT KOD, ACIKLAMA FROM [Web-Musteri-Acik-Gun-Tur] ORDER BY ACIKLAMA");
            comboBox1.SelectedIndex = 0;
        }

        private void GetObjects()
        {
            DataTable dt = new DataTable();
            WebGenel.Sorgu(dt, "SELECT GUN.KOD AS Kod, [Web-Musteri-Acik-Gun-Tur].ACIKLAMA AS [Gün]/*,(SELECT TIP_ACIKLAMA FROM [Web-Musteri-Z-Tipler] WHERE TIP_KOD = [MTIP]) AS [Tip],[Web-Musteri-Acik-Gunler].[SMREF] AS [Müş.Kod],(SELECT TOP 1 MUSTERI FROM [Web-Musteri-1] AS MUS WHERE GMREF = MUS1.GMREF AND TIP = MUS1.TIP) AS [Ana Cari],MUS1.SUBE AS [Müşteri]*/,[BASLANGIC] AS [Başlangıç],[BITIS] AS [Bitiş],GUN.[ACIKLAMA] AS [Açıklama] FROM [Web-Musteri-Acik-Gunler] AS GUN INNER JOIN [Web-Musteri-Acik-Gun-Tur] ON GUN_KOD = [Web-Musteri-Acik-Gun-Tur].KOD INNER JOIN (SELECT DISTINCT GMREF,SMREF,TIP,SUBE FROM [Web-Musteri-1]) AS MUS1 ON MUS1.SMREF = GUN.SMREF AND MUS1.TIP = GUN.MTIP WHERE GUN.SMREF = " + SMREF.ToString() + "AND GUN.MTIP = " + TIP.ToString());
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string kod = dataGridView1.SelectedRows[0].Cells["Kod"].Value.ToString();
            WebGenel.Sorgu("DELETE FROM [Web-Musteri-Acik-Gunler] WHERE KOD = " + kod);
            GetObjects();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string kod = ((WebGenelClass)comboBox1.SelectedItem).Kod.ToString();
            string baslangic = dateTimePicker1.Value.Year + "." + dateTimePicker1.Value.Month + "." + dateTimePicker1.Value.Day;
            string bitis = dateTimePicker2.Value.Year + "." + dateTimePicker2.Value.Month + "." + dateTimePicker2.Value.Day;
            WebGenel.Sorgu("INSERT INTO [Web-Musteri-Acik-Gunler] (GUN_KOD,SMREF,MTIP,BASLANGIC,BITIS,ACIKLAMA) VALUES (" + kod + "," + SMREF.ToString() + "," + TIP.ToString() + ",'" + baslangic + "','" + bitis + "','" + textBox1.Text.Trim() + "')");
            GetObjects();
        }
    }
}

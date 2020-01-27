using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Sultanlar.DatabaseObject.Internet;

namespace Sultanlar.UI
{
    public partial class frmINTERNETmalzemekategorimarkakategori : DevComponents.DotNetBar.Metro.MetroAppForm
    {
        public frmINTERNETmalzemekategorimarkakategori()
        {
            InitializeComponent();
            ustref = 0;
        }
        public frmINTERNETmalzemekategorimarkakategori(int USTREF, string AnaKategori)
        {
            InitializeComponent();
            ustref = USTREF;
            this.Text = "Alt Kategori Ekle (Ana Kategori: " + AnaKategori + ")";
            metroTabItem1.Text = "Kategori                               Açýklama";
        }
        public frmINTERNETmalzemekategorimarkakategori(bool Marka)
        {
            InitializeComponent();
            this.Text = "Marka Ekle";
            metroTabItem1.Text = "Marka                                   Açýklama";
        }
        public frmINTERNETmalzemekategorimarkakategori(bool Cinsiyet, bool Cinsiyet1)
        {
            InitializeComponent();
            this.Text = "Cinsiyet Ekle";
            metroTabItem1.Text = "Cinsiyet                                Açýklama";
        }

        int ustref;

        private void frmINTERNETmalzemekategorimarkakategori_Load(object sender, EventArgs e)
        {
            teKategori.Focus();
        }

        private void sbEkle_Click(object sender, EventArgs e)
        {
            if (this.Text.StartsWith("Alt Kategori") || this.Text.StartsWith("Ana Kategori"))
                MalzemeKategoriMarka.KategoriDoInsert(ustref, teKategori.Text.Trim(), teAciklama.Text.Trim());
            else if (this.Text.StartsWith("Marka"))
                MalzemeKategoriMarka.MarkaDoInsert(teKategori.Text.Trim(), teAciklama.Text.Trim());
            else if (this.Text.StartsWith("Cinsiyet"))
                MalzemeKategoriMarka.CinsiyetDoInsert(teKategori.Text.Trim(), teAciklama.Text.Trim());

            this.Close();
        }
    }
}
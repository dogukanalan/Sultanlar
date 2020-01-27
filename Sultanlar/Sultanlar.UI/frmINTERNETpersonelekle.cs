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
    public partial class frmINTERNETpersonelekle : Form
    {
        public frmINTERNETpersonelekle()
        {
            InitializeComponent();
            id = 0;
            GetTurler();
        }

        public frmINTERNETpersonelekle(bool Duzenle, int ID)
        {
            InitializeComponent();
            id = ID;
            GetTurler();
            TP_Personeller per = TP_Personeller.GetObject(ID);
            this.Text = "Personel Düzenle (" + per.strAd + " " + per.strSoyad + ")";
            txtAd.Text = per.strAd;
            txtSoyad.Text = per.strSoyad;
            txtGorev.Text = per.strGorev;
            txtTelefon.Text = per.strTelefon;
            txtKod.Text = per.strKod;
            txtEposta.Text = per.strEposta;
            txtAciklama.Text = per.strAciklama;
            for (int i = 0; i < cmbTur.Items.Count; i++)
            {
                if (((TP_PersonelTurleri)cmbTur.Items[i]).pkID == per.intTur)
                {
                    cmbTur.SelectedIndex = i;
                    break;
                }
            }
            btnEkle.Text = "Güncelle";
        }

        int id;

        private void frmINTERNETpersonelekle_Load(object sender, EventArgs e)
        {

        }

        private void GetTurler()
        {
            TP_PersonelTurleri.GetObjects(cmbTur.Items, true);
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (id == 0)
            {
                TP_Personeller per = new TP_Personeller(((TP_PersonelTurleri)cmbTur.SelectedItem).pkID, txtAd.Text.Trim(), 
                    txtSoyad.Text.Trim(), txtGorev.Text.Trim(), txtTelefon.Text.Trim(), txtKod.Text.Trim(), txtEposta.Text.Trim(), txtAciklama.Text.Trim());
                per.DoInsert();

                MessageBox.Show("Personel eklendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                cmbTur.SelectedIndex = 0;
                txtAd.Text = string.Empty;
                txtSoyad.Text = string.Empty;
                txtGorev.Text = string.Empty;
                txtTelefon.Text = string.Empty;
                txtAciklama.Text = string.Empty;
            }
            else if (id != 0)
            {
                TP_Personeller per = TP_Personeller.GetObject(id);
                per.intTur = ((TP_PersonelTurleri)cmbTur.SelectedItem).pkID;
                per.strAd = txtAd.Text.Trim();
                per.strSoyad = txtSoyad.Text.Trim();
                per.strGorev = txtGorev.Text.Trim();
                per.strTelefon = txtTelefon.Text.Trim();
                per.strKod = txtKod.Text.Trim();
                per.strEposta = txtEposta.Text.Trim();
                per.strAciklama = txtAciklama.Text.Trim();
                per.DoUpdate();

                MessageBox.Show("Personel güncellendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
        }
    }
}

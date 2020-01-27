using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sultanlar.DatabaseObject.Internet;
using Sultanlar.Class;
using Sultanlar.DatabaseObject;

namespace Sultanlar.UI
{
    public partial class frmINTERNETyenimusteri : Form
    {
        public frmINTERNETyenimusteri()
        {
            InitializeComponent();
        }

        public static int SLSREF;
        public static string SATKOD1;
        public static string SATTEM;
        public static int GMREF;
        public static string MUSKOD;
        public static string MUSTERI;

        private void frmINTERNETyenimusteri_Load(object sender, EventArgs e)
        {
            GetUyeTipleri();
            GetUyeGruplari();
            GetIller();
        }

        private void GetIller()
        {
            Iller.GetObject(cmbIl.Items, true);

            for (int i = 0; i < cmbIl.Items.Count; i++)
            {
                if (((Iller)cmbIl.Items[i]).strIlKod == "34")
                {
                    cmbIl.SelectedIndex = i;
                    break;
                }
            }
        }

        private void GetUyeTipleri()
        {
            UyeTipleri.GetObject(cmbUyeTipi.Items, true);
        }

        private void GetUyeGruplari()
        {
            UyeGruplari.GetObject(cmbUyeGrubu.Items, true);
        }

        private void Temizle()
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is TextBox || ctrl is MaskedTextBox)
                {
                    ctrl.Text = string.Empty;
                }
                else if (ctrl is ComboBox)
                {
                    ((ComboBox)ctrl).SelectedIndex = -1;
                }
            }

            cbTaksit.Checked = false;
        }

        private void btnCari_Click(object sender, EventArgs e)
        {
            frmINTERNETsatistemsilcileri frm = new frmINTERNETsatistemsilcileri(true);
            frm.ShowDialog();
            if (GMREF > 0)
                txtCari.Text = MUSKOD + " - " + MUSTERI;
        }

        private void btnSatTem_Click(object sender, EventArgs e)
        {
            frmINTERNETsatistemsilcileri1 frm = new frmINTERNETsatistemsilcileri1(true);
            frm.ShowDialog();
            if (SLSREF > 0)
                txtSatTem.Text = SATKOD1 + " - " + SATTEM;
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (txtEposta.Text.Trim() == string.Empty ||
                txtSifre.Text.Trim() == string.Empty ||
                txtAd.Text.Trim() == string.Empty ||
                txtSoyad.Text.Trim() == string.Empty ||
                cmbUyeGrubu.SelectedIndex == -1 ||
                (GMREF == 0 && SLSREF == 0 && (cmbUyeTipi.SelectedIndex == 0 || cmbUyeTipi.SelectedIndex == 3)))
            {
                MessageBox.Show("Eksik seçim var.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Musteriler musteri = new Musteriler(
                ((UyeTipleri)cmbUyeTipi.SelectedItem).pkUyeTipiID,
                ((UyeGruplari)cmbUyeGrubu.SelectedItem).pkUyeGrupID,
                StringParcalama.IlkHarfBuyuk(txtAd.Text.Trim()),
                StringParcalama.IlkHarfBuyuk(txtSoyad.Text.Trim()),
                txtVergiDairesi.Text.Trim(),
                txtVergiNo.Text.Trim(),
                "0" + mtxtTelefon.Text,
                txtEposta.Text.Trim(),
                "",
                txtSifre.Text.Trim(),
                true,
                true,
                DateTime.Now,
                DateTime.Now.AddMinutes(1),
                DateTime.Now.AddMinutes(2),
                cbTaksit.Checked,
                GMREF,
                SLSREF,
                0,
                false,
                true,
                true,
                8,
                false,
                true,
                "",
                ((Iller)cmbIl.SelectedItem).pkIlID,
                15,
                false, 50, 25, 25);
            musteri.DoInsert();
            Temizle();
        }

        private void btnOtoSifre_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            string sifre = string.Empty;

            int i = 0;
            while (i < 10)
            {
                int j = rnd.Next(49, 122);
                if ((j < 58) || (j >= 65 && j < 91) || (j >= 97))
                {
                    i++;
                    sifre += char.ConvertFromUtf32(j);
                }
            }
            
            txtSifre.Text = sifre;
        }
    }
}

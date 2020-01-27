using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sultanlar.DatabaseObject;
using Sultanlar.Class;
using System.IO;

namespace Sultanlar.UI
{
    public partial class frmGorevler : Form
    {
        public frmGorevler()
        {
            InitializeComponent();
        }
        //
        //
        private void frmGorevler_Load(object sender, EventArgs e)
        {
            GetObject();
        }
        //
        //
        private void GetObject()
        {
            Gorevler.GetObjectHepsi(lbGorevler.Items, true);
            Departmanlar.GetObject(cmbDepartmanlar.Items, true);
            Departmanlar.GetObject(cmbGorevEkleDepartman.Items, true);
        }
        //
        //
        private void GorevTemizle()
        {
            txtGorev.Text = string.Empty;
            cmbDepartmanlar.SelectedIndex = -1;
        }
        //
        //
        private void GetObject(Gorevler gr)
        {
            txtGorev.Text = gr.strGorev;
            cbAyrintiWeb.Checked = gr.blGorevWeb;
            cbAyrintiListe.Checked = gr.blGorevListe;

            bool departmanbos = true;
            for (int i = 0; i < cmbDepartmanlar.Items.Count; i++)
            {
                if (gr.tintDepartmanID == ((Departmanlar)cmbDepartmanlar.Items[i]).pkDepartmanID)
                {
                    cmbDepartmanlar.SelectedIndex = i;
                    departmanbos = false;
                }
            }

            if (departmanbos == true)
            {
                cmbDepartmanlar.SelectedIndex = -1;
            }
        }
        //
        //
        //
        //
        //
        private void lbGorevler_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbGorevler.SelectedIndex > -1)
            {
                Gorevler gr = (Gorevler)lbGorevler.SelectedItem;
                GetObject(gr);
            }
        }
        //
        //
        private void btnGorevDuzelt_Click(object sender, EventArgs e)
        {
            if (lbGorevler.SelectedIndex > -1)
            {
                if (btnGorevDuzelt.Text == "Düzelt")
                {
                    btnGorevSil.Text = "İptal";
                    lbGorevler.Enabled = false;
                    txtGorev.ReadOnly = false;
                    cmbDepartmanlar.Enabled = true;
                    cbAyrintiWeb.Enabled = true;
                    cbAyrintiListe.Enabled = true;
                    btnGorevDuzelt.Text = "Güncelle";
                }
                else if (btnGorevDuzelt.Text == "Güncelle")
                {
                    int index = lbGorevler.SelectedIndex;
                    Gorevler gr = (Gorevler)lbGorevler.SelectedItem;
                    gr.strGorev = txtGorev.Text.Trim();
                    if (cmbDepartmanlar.SelectedIndex > -1)
                        gr.tintDepartmanID = ((Departmanlar)cmbDepartmanlar.SelectedItem).pkDepartmanID;
                    gr.blGorevWeb = cbAyrintiWeb.Checked;
                    gr.blGorevListe = cbAyrintiListe.Checked;
                    gr.DoUpdate();

                    btnGorevSil.Text = "Sil";
                    lbGorevler.Enabled = true;
                    txtGorev.ReadOnly = true;
                    cmbDepartmanlar.Enabled = false;
                    cbAyrintiWeb.Enabled = false;
                    cbAyrintiListe.Enabled = false;
                    btnGorevDuzelt.Text = "Düzelt";
                    GetObject();
                    lbGorevler.SelectedIndex = index;
                }
            }
            else
            {
                MessageBox.Show("Bir Görev seçilmedi!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }
        //
        //
        private void btnGorevSil_Click(object sender, EventArgs e)
        {
            Gorevler gr = (Gorevler)lbGorevler.SelectedItem;

            if (btnGorevSil.Text == "Sil")
            {
                if (lbGorevler.SelectedIndex > -1)
                {
                    if (MessageBox.Show("Geçerli kaydı silmek istediğinize emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        gr.DoDelete();
                        GetObject();
                        GorevTemizle();
                    }
                }
                else
                {
                    MessageBox.Show("Bir Görev seçilmedi!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
            }
            else if (btnGorevSil.Text == "İptal")
            {
                btnGorevSil.Text = "Sil";
                lbGorevler.Enabled = true;
                txtGorev.ReadOnly = true;
                cbAyrintiWeb.Enabled = false;
                cbAyrintiListe.Enabled = false;
                cmbDepartmanlar.Enabled = false;
                btnGorevDuzelt.Text = "Düzelt";

                GetObject(gr);
            }
        }
        //
        //
        private void btnGorevEkle_Click(object sender, EventArgs e)
        {
            if (cmbGorevEkleDepartman.SelectedIndex > -1)
            {
                Gorevler gr = new Gorevler(((Departmanlar)cmbGorevEkleDepartman.SelectedItem).pkDepartmanID, txtGorevEkleGorev.Text.Trim(),
                    cbEkleWeb.Checked, cbEkleListe.Checked);

                gr.DoInsert();
                lbGorevler.Items.Add(gr);

                btnTemizle.PerformClick();
                lbGorevler.SelectedItem = gr;
            }
            else
            {
                Gorevler gr = new Gorevler(0, txtGorevEkleGorev.Text.Trim(), cbEkleWeb.Checked, cbEkleListe.Checked);

                gr.DoInsert();
                lbGorevler.Items.Add(gr);

                btnTemizle.PerformClick();
                lbGorevler.SelectedItem = gr;
            }
        }
        //
        //
        private void btnTemizle_Click(object sender, EventArgs e)
        {
            txtGorevEkleGorev.Text = string.Empty;
            cbEkleListe.Checked = false;
            cmbGorevEkleDepartman.SelectedIndex = -1;
        }
    }
}

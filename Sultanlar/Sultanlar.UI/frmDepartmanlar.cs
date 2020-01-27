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
    public partial class frmDepartmanlar : Form
    {
        public frmDepartmanlar()
        {
            InitializeComponent();
        }
        //
        //
        private void frmDepartmanlar_Load(object sender, EventArgs e)
        {
            GetObject();
        }
        //
        //
        //
        //
        //
        private void GetObject()
        {
            Departmanlar.GetObjectHepsi(lbDepartmanlar.Items, true);
        }
        //
        //
        private void Temizle()
        {
            lbDepartmanlar.SelectedIndex = -1;
            txtDepartman.Text = string.Empty;
            txtEposta.Text = string.Empty;
            cbWeb.Enabled = false;
        }
        //
        //
        //
        //
        //
        private void btnSil_Click(object sender, EventArgs e)
        {
            if (lbDepartmanlar.SelectedIndex > -1)
            {
                if (MessageBox.Show("Geçerli kaydı silmek istediğinize emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Departmanlar dp = (Departmanlar)lbDepartmanlar.SelectedItem;
                    dp.DoDelete();
                    GetObject();
                    Temizle();
                }
            }
            else
            {
                MessageBox.Show("Bir Departman seçilmedi!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }
        //
        //
        private void btnDuzelt_Click(object sender, EventArgs e)
        {
            if (lbDepartmanlar.SelectedIndex > -1)
            {
                lbDepartmanlar.Enabled = false;
                txtDepartman.ReadOnly = false;
                txtEposta.ReadOnly = false;
                btnSil.Enabled = false;
                btnDuzelt.Enabled = false;
                btnEkle.Enabled = false;
                btnBitir.Enabled = true;
                btnIptal.Enabled = true;
                cbWeb.Enabled = true;
                groupBox2.Text = "Departman Düzenle";

                txtDepartman.Text = lbDepartmanlar.SelectedItem.ToString();
                txtEposta.Text = ((Departmanlar)lbDepartmanlar.SelectedItem).strDepartmanEposta;
            }
            else
            {
                MessageBox.Show("Bir Departman seçilmedi!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }
        //
        //
        private void btnEkle_Click(object sender, EventArgs e)
        {
            Temizle();

            lbDepartmanlar.Enabled = false;
            txtDepartman.ReadOnly = false;
            txtEposta.ReadOnly = false;
            btnSil.Enabled = false;
            btnDuzelt.Enabled = false;
            btnEkle.Enabled = false;
            btnBitir.Enabled = true;
            btnIptal.Enabled = true;
            cbWeb.Enabled = true;
            cbWeb.Checked = true;
            groupBox2.Text = "Yeni Departman Ekle";
        }
        //
        //
        private void btnIptal_Click(object sender, EventArgs e)
        {
            lbDepartmanlar.Enabled = true;
            txtDepartman.ReadOnly = true;
            txtEposta.ReadOnly = true;
            btnSil.Enabled = true;
            btnDuzelt.Enabled = true;
            btnEkle.Enabled = true;
            btnBitir.Enabled = false;
            btnIptal.Enabled = false;
            cbWeb.Enabled = false;
            groupBox2.Text = "İşlem";

            if (lbDepartmanlar.SelectedIndex > -1)
            {
                txtDepartman.Text = lbDepartmanlar.SelectedItem.ToString();
                txtEposta.Text = ((Departmanlar)lbDepartmanlar.SelectedItem).strDepartmanEposta;
                cbWeb.Checked = ((Departmanlar)lbDepartmanlar.SelectedItem).blDepartmanWeb;
            }
        }
        //
        //
        private void btnBitir_Click(object sender, EventArgs e)
        {
            if (groupBox2.Text == "Yeni Departman Ekle")
            {
                Departmanlar dp = new Departmanlar(txtDepartman.Text.Trim(), txtEposta.Text.Trim(), cbWeb.Checked);
                dp.DoInsert();
                btnIptal.PerformClick();
                GetObject();
            }
            else if (groupBox2.Text == "Departman Düzenle")
            {
                int index = lbDepartmanlar.SelectedIndex;
                Departmanlar dp = (Departmanlar)lbDepartmanlar.SelectedItem;
                dp.strDepartman = txtDepartman.Text.Trim();
                dp.strDepartmanEposta = txtEposta.Text.Trim();
                dp.blDepartmanWeb = cbWeb.Checked;
                dp.DoUpdate();
                GetObject();
                lbDepartmanlar.SelectedIndex = index;
                btnIptal.PerformClick();
            }
        }
        //
        //
        private void lbDepartmanlar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbDepartmanlar.SelectedIndex > -1)
            {
                txtDepartman.Text = lbDepartmanlar.SelectedItem.ToString();
                txtEposta.Text = ((Departmanlar)lbDepartmanlar.SelectedItem).strDepartmanEposta;
                cbWeb.Checked = ((Departmanlar)lbDepartmanlar.SelectedItem).blDepartmanWeb;
            }
        }
    }
}

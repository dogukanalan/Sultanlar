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

namespace Sultanlar.UI
{
    public partial class frmAracTurleri : Form
    {
        public frmAracTurleri()
        {
            InitializeComponent();
        }

        private void frmAracTurleri_Load(object sender, EventArgs e)
        {
            GetObjects();
        }

        private void GetObjects()
        {
            AT_ArabaTurleri.GetObject(lbTurler.Items, true);
        }

        private void Temizle()
        {
            txtTurEkle.Text = string.Empty;
            txtTurGuncelle.Text = string.Empty;
            txtTurSil.Text = string.Empty;
            lbTurler.SelectedIndex = -1;
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (txtTurEkle.Text.Trim() != string.Empty)
            {
                AT_ArabaTurleri at = new AT_ArabaTurleri(txtTurEkle.Text.Trim());
                at.DoInsert();
                GetObjects();
                Temizle();
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (lbTurler.SelectedIndex > -1)
            {
                int index = lbTurler.SelectedIndex;
                AT_ArabaTurleri at = ((AT_ArabaTurleri)lbTurler.SelectedItem);
                at.strArabaTuru = txtTurGuncelle.Text.Trim();
                at.DoUpdate();

                GetObjects();
                lbTurler.SelectedIndex = index;
            }
        }

        private void lbTurler_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbTurler.SelectedIndex > -1)
            {
                txtTurGuncelle.Text = lbTurler.SelectedItem.ToString();
                txtTurSil.Text = lbTurler.SelectedItem.ToString();
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (lbTurler.SelectedIndex > -1)
            {
                AT_ArabaTurleri at = ((AT_ArabaTurleri)lbTurler.SelectedItem);
                at.DoDelete();

                GetObjects();
                lbTurler.SelectedIndex = -1;
            }
        }
    }
}

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
    public partial class frmAracMarkalari : Form
    {
        public frmAracMarkalari()
        {
            InitializeComponent();
        }

        private void frmAracMarkalari_Load(object sender, EventArgs e)
        {
            GetObjects();
        }

        private void GetObjects()
        {
            AT_ArabaMarkalari.GetObject(lbMarkalar.Items, true);
        }

        private void Temizle()
        {
            txtMarkaEkle.Text = string.Empty;
            txtMarkaGuncelle.Text = string.Empty;
            txtMarkaSil.Text = string.Empty;
            lbMarkalar.SelectedIndex = -1;
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (txtMarkaEkle.Text.Trim() != string.Empty)
            {
                AT_ArabaMarkalari am = new AT_ArabaMarkalari(txtMarkaEkle.Text.Trim());
                am.DoInsert();
                GetObjects();
                Temizle();
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (lbMarkalar.SelectedIndex > -1)
            {
                int index = lbMarkalar.SelectedIndex;
                AT_ArabaMarkalari am = ((AT_ArabaMarkalari)lbMarkalar.SelectedItem);
                am.strArabaMarka = txtMarkaGuncelle.Text.Trim();
                am.DoUpdate();

                GetObjects();
                lbMarkalar.SelectedIndex = index;
            }
        }

        private void lbMarkalar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbMarkalar.SelectedIndex > -1)
            {
                txtMarkaGuncelle.Text = lbMarkalar.SelectedItem.ToString();
                txtMarkaSil.Text = lbMarkalar.SelectedItem.ToString();
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (lbMarkalar.SelectedIndex > -1)
            {
                AT_ArabaMarkalari am = ((AT_ArabaMarkalari)lbMarkalar.SelectedItem);
                am.DoDelete();

                GetObjects();
                lbMarkalar.SelectedIndex = -1;
            }
        }
    }
}

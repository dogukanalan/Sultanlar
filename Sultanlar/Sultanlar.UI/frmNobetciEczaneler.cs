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
using System.Net;
using System.IO;

namespace Sultanlar.UI
{
    public partial class frmNobetciEczaneler : Form
    {
        public frmNobetciEczaneler()
        {
            InitializeComponent();
        }
        //
        //
        //
        //
        //
        private void btnEczaneGuncelle_Click(object sender, EventArgs e)
        {
            if (cmbGunler.SelectedIndex > -1)
            {
                if (MessageBox.Show("Güncelleme işlemi uzun sürebilir. Bu esnada programı kapatmayınız.", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    System.Threading.Thread thr = new System.Threading.Thread(new System.Threading.ParameterizedThreadStart(EczaneGuncelle));
                    thr.Start(cmbGunler.SelectedItem.ToString());
                }
            }
            else
            {
                MessageBox.Show("Bir gün seçilmedi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        //
        //
        //
        //
        //
        private void EczaneGuncelle(object objgunekadar)
        {
            groupBox1.Enabled = false;
            cmbGunler.Enabled = false;
            btnEczaneGuncelle.Enabled = false;

            int gunekadar = Convert.ToInt32(objgunekadar);
            Eczaneler.DoDeleteAll();
            StringEczane.EczanelerEkle2(gunekadar, lblDurum);

            groupBox1.Enabled = true;
            cmbGunler.Enabled = true;
            btnEczaneGuncelle.Enabled = true;
        }
        //
        //
        //
        //
        //
        private void frmNobetciEczaneler_Load(object sender, EventArgs e)
        {
            EczaneIlceler.GetObject(cmbIlceler.Items, true);
            CheckForIllegalCrossThreadCalls = false;
        }
        //
        //
        //
        //
        //
        private void cmbIlceler_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvEczaneler.DataSource = Eczaneler.GetObject(((EczaneIlceler)cmbIlceler.SelectedItem).pkEczaneIlceID);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.istanbulsaglik.gov.tr/Index_Nobetci.asp"); 
        }
    }
}

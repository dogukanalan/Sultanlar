using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sultanlar.DatabaseObject;

namespace Sultanlar.UI
{
    public partial class frmAT2aracbedelleri : Form
    {
        public frmAT2aracbedelleri()
        {
            InitializeComponent();
            AracID = 0;
        }

        public frmAT2aracbedelleri(int aracID)
        {
            InitializeComponent();
            AracID = aracID;
            this.Text = "(" + AT2_Araclar.GetObject(AracID).strPlaka + ") Araç Kira Bedelleri";
            cmbEkleArac.Items.Add(AT2_Araclar.GetObject(AracID));
            cmbEkleArac.SelectedIndex = 0;
            cmbEkleArac.Enabled = false;
        }

        int AracID;
        private FixedSizeCache cache;
        System.Collections.ArrayList List = new System.Collections.ArrayList();

        private void frmAT2aracbedelleri_Load(object sender, EventArgs e)
        {
            cache = new FixedSizeCache(512);
            lbAracBedelleri.DrawItem += new DrawItemEventHandler(lbAracBedelleri_DrawItem);
            GetObjects();
        }

        void lbAracBedelleri_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index > -1)
            {
                String text = "";
                if (cache.Contains(e.Index))
                {
                    text = (String)cache[e.Index];
                }
                else
                {
                    text = ((AT2_AracBedeller)List[e.Index]).ToString2;
                    cache.Add(e.Index, text);
                }

                lbAracBedelleri.DefaultDrawItem(e, text);
            }
        }

        private void GetObjects()
        {
            lbAracBedelleri.Items.Clear();
            cache.Clear();
            if (AracID != 0) AT2_AracBedeller.GetObjectsByAracID(List, cbPasifler.Checked, AracID, true, false); else AT2_AracBedeller.GetObjects(List, cbPasifler.Checked, true, false);
            lbAracBedelleri.Count = List.Count;

            if (AracID == 0) AT2_Araclar.GetObjects(cmbEkleArac.Items, false, true);
            AT2_Bolgeler.GetObjects(cmbEkleBolge.Items, false, true);
            AT2_Bolgeler.GetObjects(cmbGuncelle.Items, false, true);
        }

        private void Temizle()
        {
            cmbEkleBolge.SelectedIndex = -1;
            txtEkle.Text = string.Empty;
            cmbGuncelle.SelectedIndex = -1;
            txtGuncelle.Text = string.Empty;
            dtpGuncelleBaslangic.Value = DateTime.Now;
            dtpGuncelleBitis.Value = DateTime.Now;
            txtSil.Text = string.Empty;
            lbAracBedelleri.SelectedIndex = -1;
            groupBox2.Enabled = false;
            groupBox3.Enabled = false;
            btnKopyala.Text = "Kopyalama";
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (cmbEkleArac.SelectedIndex > -1 && cmbEkleBolge.SelectedIndex > -1 && txtEkle.Text.Trim() != string.Empty)
            {
                if (AT2_AracBedeller.IsExist(((AT2_Araclar)cmbEkleArac.SelectedItem).pkID, ((AT2_Bolgeler)cmbEkleBolge.SelectedItem).pkID)) { MessageBox.Show("Bu araç için bu bölgede bedel zaten girilmiş.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }

                try { Convert.ToDecimal(txtEkle.Text.Trim()); }
                catch (Exception) { MessageBox.Show("Girilen bedel hatalı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }

                AT2_AracBedeller ab = new AT2_AracBedeller(((AT2_Araclar)cmbEkleArac.SelectedItem).pkID, 
                    ((AT2_Bolgeler)cmbEkleBolge.SelectedItem).pkID, false, Convert.ToDecimal(txtEkle.Text.Trim()), false, 
                    dtpEkleBaslangic.Value, dtpEkleBitis.Value);
                ab.DoInsert();

                MessageBox.Show("Ekleme işlemi başarılı.", "Sonuç", MessageBoxButtons.OK, MessageBoxIcon.Information);

                GetObjects();
                Temizle();
            }
            else
            {
                MessageBox.Show("Eksik seçim var.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (lbAracBedelleri.SelectedIndex > -1)
            {
                //if (AT2_AracBedeller.IsExist(((AT2_AracBedeller)List[lbAracBedelleri.SelectedIndex]).intAracID, ((AT2_Bolgeler)cmbGuncelle.SelectedItem).pkID)) { MessageBox.Show("Bu araç için bu bölgede bedel zaten girilmiş.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }

                try { Convert.ToDecimal(txtGuncelle.Text.Trim()); }
                catch (Exception) { MessageBox.Show("Girilen bedel hatalı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }

                int index = lbAracBedelleri.SelectedIndex;
                AT2_AracBedeller ab = ((AT2_AracBedeller)List[lbAracBedelleri.SelectedIndex]);
                ab.intBolgeID = ((AT2_Bolgeler)cmbGuncelle.SelectedItem).pkID;
                ab.mnBedel = Convert.ToDecimal(txtGuncelle.Text.Trim());
                ab.dtBaslangic = dtpGuncelleBaslangic.Value;
                ab.dtBitis = dtpGuncelleBitis.Value;
                ab.DoUpdate();

                MessageBox.Show("Güncelleme işlemi başarılı.", "Sonuç", MessageBoxButtons.OK, MessageBoxIcon.Information);

                GetObjects();
                lbAracBedelleri.SelectedIndex = index;
            }
            else
            {
                MessageBox.Show("Eksik seçim var.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void lbAracBedelleri_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbAracBedelleri.SelectedIndex > -1)
            {
                groupBox2.Enabled = true;
                groupBox3.Enabled = true;

                AT2_AracBedeller ab = ((AT2_AracBedeller)List[lbAracBedelleri.SelectedIndex]);
                for (int i = 0; i < cmbGuncelle.Items.Count; i++)
                {
                    if (((AT2_Bolgeler)cmbGuncelle.Items[i]).pkID == ab.intBolgeID)
                    {
                        cmbGuncelle.SelectedIndex = i;
                        break;
                    }
                }
                dtpGuncelleBaslangic.Value = ab.dtBaslangic;
                dtpGuncelleBitis.Value = ab.dtBitis;
                txtGuncelle.Text = ab.mnBedel.ToString("N2");
                txtSil.Text = ((AT2_AracBedeller)List[lbAracBedelleri.SelectedIndex]).ToString2;
                btnKopyala.Text = "Kopyalama (" + txtSil.Text + ")";
                btnSil.Text = ab.blPasif ? "Geri Al" : "Sil";
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (lbAracBedelleri.SelectedIndex > -1)
            {
                if (MessageBox.Show("Devam etmek istediğinize emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    AT2_AracBedeller ab = ((AT2_AracBedeller)List[lbAracBedelleri.SelectedIndex]);

                    if (ab.blPasif && (AT2_Araclar.GetObject(ab.intAracID).blPasif || AT2_Bolgeler.GetObject(ab.intBolgeID).blPasif)) // bedel geri alınıyorsa ve araç veya bölge pasif ise
                    {
                        MessageBox.Show("Araç veya bölgeden birisi silinmiş olduğundan bedel geri alınamaz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    ab.blPasif = !ab.blPasif;
                    ab.DoUpdate();

                    MessageBox.Show("İşlem başarılı.", "Sonuç", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    GetObjects();
                    Temizle();
                }
            }
            else
            {
                MessageBox.Show("Eksik seçim var.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnYenile_Click(object sender, EventArgs e)
        {
            GetObjects();
            Temizle();
        }

        private void btnKopyala_Click(object sender, EventArgs e)
        {
            /*if (AracID != 0)
            {
                frmAT2aracbedellerikopyala frm = new frmAT2aracbedellerikopyala(AracID);
                frm.ShowDialog();
                GetObjects();
                Temizle();
            }
            else */if (lbAracBedelleri.SelectedIndex > -1)
            {
                int aracid = ((AT2_AracBedeller)List[lbAracBedelleri.SelectedIndex]).intAracID;
                frmAT2aracbedellerikopyala frm = new frmAT2aracbedellerikopyala(aracid);
                frm.ShowDialog();
                GetObjects();
                Temizle();
            }
            else
            {
                frmAT2aracbedellerikopyala frm = new frmAT2aracbedellerikopyala();
                frm.ShowDialog();
                GetObjects();
                Temizle();
            }
        }

        private void frmAT2aracbedelleri_SizeChanged(object sender, EventArgs e)
        {
            btnYenile.Location = new Point(this.Width - 40, btnYenile.Location.Y);
            cbPasifler.Location = new Point(this.Width - 115, cbPasifler.Location.Y);
            groupBox1.Location = new Point(this.Width - 240, groupBox1.Location.Y);
            groupBox2.Location = new Point(this.Width - 240, groupBox2.Location.Y);
            groupBox3.Location = new Point(this.Width - 240, groupBox3.Location.Y);
            lbAracBedelleri.Width = this.Width - 246;
            btnKopyala.Width = this.Width - 246;
        }
    }
}

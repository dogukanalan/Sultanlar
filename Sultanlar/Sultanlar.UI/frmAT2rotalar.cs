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
    public partial class frmAT2rotalar : Form
    {
        public frmAT2rotalar()
        {
            InitializeComponent();
        }

        private void frmAT2rotalar_Load(object sender, EventArgs e)
        {
            GetObjects();
            Temizle();
        }

        private void GetObjects()
        {
            AT2_Rotalar.GetObjects(lbRotalar.Items, cbPasifler.Checked, true);
            AT2_Bolgeler.GetObjects(cmbEkleBolgeler.Items, false, true);
            AT2_Bolgeler.GetObjects(cmbGuncelleBolgeler.Items, false, true);
            AT2_Araclar.GetObjects(cmbEkleAraclar.Items, false, 0, 0, string.Empty, true);
            AT2_Araclar.GetObjects(cmbGuncelleAraclar.Items, false, 0, 0, string.Empty, true);
        }

        private void Temizle()
        {
            lbRotalar.SelectedIndex = -1;

            groupBox1.Enabled = true;
            groupBox2.Enabled = false;
            groupBox3.Enabled = false;

            cmbEkleBolgeler.SelectedIndex = -1;
            cmbEkleAraclar.SelectedIndex = -1;
            txtEkleRota.Text = string.Empty;
            cmbGuncelleBolgeler.SelectedIndex = -1;
            cmbGuncelleAraclar.SelectedIndex = -1;
            txtGuncelleRota.Text = string.Empty;
            txtSil.Text = string.Empty;
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (cmbEkleBolgeler.SelectedIndex > -1 && txtEkleRota.Text.Trim() != string.Empty)
            {
                AT2_Rotalar rota = new AT2_Rotalar(
                    ((AT2_Bolgeler)cmbEkleBolgeler.SelectedItem).pkID,
                    cmbEkleAraclar.SelectedIndex > -1 ? ((AT2_Araclar)cmbEkleAraclar.SelectedItem).pkID : 0,
                    false,
                    txtEkleRota.Text.Trim());
                rota.DoInsert();

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
            if (cmbGuncelleBolgeler.SelectedIndex > -1 && txtGuncelleRota.Text.Trim() != string.Empty)
            {
                int index = lbRotalar.SelectedIndex;

                AT2_Rotalar rota = (AT2_Rotalar)lbRotalar.SelectedItem;
                rota.intBolgeID = ((AT2_Bolgeler)cmbGuncelleBolgeler.SelectedItem).pkID;
                rota.intAracID = cmbGuncelleAraclar.SelectedIndex > -1 ? ((AT2_Araclar)cmbGuncelleAraclar.SelectedItem).pkID : 0;
                rota.strRota = txtGuncelleRota.Text.Trim();
                rota.DoUpdate();

                MessageBox.Show("Güncelleme işlemi başarılı.", "Sonuç", MessageBoxButtons.OK, MessageBoxIcon.Information);

                GetObjects();
                lbRotalar.SelectedIndex = index;
            }
            else
            {
                MessageBox.Show("Eksik seçim var.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void lbRotalar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbRotalar.SelectedIndex > -1)
            {
                groupBox1.Enabled = false;
                groupBox2.Enabled = true;
                groupBox3.Enabled = true;

                AT2_Rotalar rota = (AT2_Rotalar)lbRotalar.SelectedItem;

                bool bolgegirdi = false;
                for (int i = 0; i < cmbGuncelleBolgeler.Items.Count; i++)
                {
                    if (((AT2_Bolgeler)cmbGuncelleBolgeler.Items[i]).pkID == rota.intBolgeID)
                    {
                        cmbGuncelleBolgeler.SelectedIndex = i;
                        bolgegirdi = true;
                        break;
                    }
                }
                if (!bolgegirdi) cmbGuncelleBolgeler.SelectedIndex = -1;

                bool aracgirdi = false;
                for (int i = 0; i < cmbGuncelleAraclar.Items.Count; i++)
                {
                    if (((AT2_Araclar)cmbGuncelleAraclar.Items[i]).pkID == rota.intAracID)
                    {
                        cmbGuncelleAraclar.SelectedIndex = i;
                        aracgirdi = true;
                        break;
                    }
                }
                if (!aracgirdi) cmbGuncelleAraclar.SelectedIndex = -1;

                txtGuncelleRota.Text = rota.strRota;

                txtSil.Text = lbRotalar.SelectedItem.ToString();
                btnSil.Text = rota.blPasif ? "Geri Al" : "Sil";
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (lbRotalar.SelectedIndex > -1)
            {
                if (MessageBox.Show("Devam etmek istediğinize emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    AT2_Rotalar rota = ((AT2_Rotalar)lbRotalar.SelectedItem);
                    rota.blPasif = !rota.blPasif;
                    rota.DoUpdate();

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

        private void frmAT2rotalar_SizeChanged(object sender, EventArgs e)
        {
            btnYenile.Location = new Point(this.Width - 40, btnYenile.Location.Y);
            groupBox1.Location = new Point(this.Width - 240, groupBox1.Location.Y);
            groupBox2.Location = new Point(this.Width - 240, groupBox2.Location.Y);
            groupBox3.Location = new Point(this.Width - 240, groupBox3.Location.Y);
            cbPasifler.Location = new Point(this.Width - 240, cbPasifler.Location.Y);
            lbRotalar.Width = this.Width - 246;
        }

        private void label22_MouseHover(object sender, EventArgs e)
        {
            lblYardim.Visible = true;
        }

        private void label22_MouseLeave(object sender, EventArgs e)
        {
            lblYardim.Visible = false;
        }

        private void cmbEkleAraclar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
                ((ComboBox)sender).SelectedIndex = -1;
        }
    }
}

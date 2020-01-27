using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sultanlar.DatabaseObject;
using Sultanlar.DatabaseObject.Internet;
using System.Collections;

namespace Sultanlar.UI
{
    public partial class frmINTERNETiadelersevk : Form
    {
        public frmINTERNETiadelersevk(int iadeid)
        {
            InitializeComponent();
            IadeID = iadeid;
        }

        int IadeID;

        private void frmINTERNETiadelersevk_Load(object sender, EventArgs e)
        {
            DoYetkiler();
            GetObjects();
        }

        private void DoYetkiler()
        {
            if (frmAna.KAdi.ToUpper() == "BI04" || frmAna.KAdi.ToUpper() == "ADMİNİSTRATOR")
            {
                txtAciklama.ReadOnly = false;
                btnAciklama.Enabled = true;
                btnSil.Enabled = true;
                gbEkleme.Enabled = true;
                gbGuncelleme.Enabled = true;

                btnSil.Visible = true;
            }
            else if (frmAna.KAdi.ToUpper() == "ST12") // mtorun
            {
                txtAciklama.ReadOnly = false;
                btnAciklama.Enabled = true;
                btnSil.Enabled = true;
                gbEkleme.Enabled = true;
                gbGuncelleme.Enabled = true;
            }
            else if (frmAna.KAdi.ToUpper() == "LK07" || frmAna.KAdi.ToUpper() == "LK06" || frmAna.KAdi.ToUpper() == "SUL02" || frmAna.KAdi.ToUpper() == "FT09") // arzu bayram, ibrahim ergün, lütfü akın ak
            {
                txtAciklama.ReadOnly = false;
                btnAciklama.Enabled = true;
                btnSil.Enabled = true;
                gbEkleme.Enabled = true;
                gbGuncelleme.Enabled = true;
            }
            else if (frmAna.KAdi.ToUpper() == "LK12" || frmAna.KAdi.ToUpper() == "LK02" || frmAna.KAdi.ToUpper() == "LK04" || frmAna.KAdi.ToUpper() == "LK09") // şeyda arslan
            {
                txtAciklama.ReadOnly = false;
                btnAciklama.Enabled = true;
                btnSil.Enabled = true;
                gbEkleme.Enabled = true;
                gbGuncelleme.Enabled = true;
            }
            else if (frmAna.KAdi.ToUpper() == "ST08") // ünal yıldırım
            {
                txtAciklama.ReadOnly = false;
                btnAciklama.Enabled = true;
                btnSil.Enabled = true;
                gbEkleme.Enabled = true;
                gbGuncelleme.Enabled = true;
            }
        }

        private void GetObjects()
        {
            DataTable dt = new DataTable();
            Iadeler.GetSevkBilgileri(dt, IadeID);
            dataGridView1.DataSource = dt;
        }

        private void btnGelis_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count < 1)
                return;

            //DateTime Gelis = DateTime.Parse(dtpTarihGelis.Value.ToShortDateString() + " " + dtpSaatGelis.Value.ToShortTimeString());
            Iadeler.DoUpdateSevkBilgisi(Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["clpkID"].Value), DateTime.Now);

            IadeHareketleri.DoInsert(IadeID, 9, frmAna.KAdi.ToUpper(), "Sevkten geldi"); // sevk bilgisi girildi

            GetObjects();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count < 1)
                return;

            Iadeler.DoDeleteSevkBilgisi(Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["clpkID"].Value));
            GetObjects();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            DateTime Gidis = DateTime.Parse(dtpTarihGidis.Value.ToShortDateString() + " " + dtpSaatGidis.Value.ToShortTimeString());
            Iadeler.DoInsertSevkBilgisi(IadeID, txtSofor.Text.Trim(), txtMuavin.Text.Trim(), Gidis);

            IadeHareketleri.DoInsert(IadeID, 9, frmAna.KAdi.ToUpper(), "Sevke gönderildi"); // sevk bilgisi girildi

            GetObjects();
            txtSofor.Text = string.Empty;
            txtMuavin.Text = string.Empty;

            this.Close();
        }

        private void btnAciklama_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count < 1)
                return;

            Iadeler.DoUpdateSevkBilgisi(Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["clpkID"].Value), txtAciklama.Text.Trim());
            GetObjects();

            IadeHareketleri.DoInsert(IadeID, 15, frmAna.KAdi.ToUpper(), ""); // sevk bilgisi açıklaması güncellendi
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            txtAciklama.Text = dataGridView1.Rows[e.RowIndex].Cells["clstrAciklama"].Value.ToString();
            txtSofor.Text = dataGridView1.Rows[e.RowIndex].Cells["clstrSofor"].Value.ToString();
            txtMuavin.Text = dataGridView1.Rows[e.RowIndex].Cells["clstrMuavin"].Value.ToString();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            DateTime Gidis = DateTime.Parse(dtpTarihGidis.Value.ToShortDateString() + " " + dtpSaatGidis.Value.ToShortTimeString());
            Iadeler.DoUpdateSevkBilgisi(Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["clpkID"].Value),
                txtSofor.Text.Trim(), txtMuavin.Text.Trim(), Gidis);

            IadeHareketleri.DoInsert(IadeID, 14, frmAna.KAdi.ToUpper(), ""); // sevk bilgisi güncellendi

            this.Close();
        }
    }
}

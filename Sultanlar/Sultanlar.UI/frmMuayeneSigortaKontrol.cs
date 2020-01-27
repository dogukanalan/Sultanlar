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
    public partial class frmMuayeneSigortaKontrol : Form
    {
        public frmMuayeneSigortaKontrol(bool Muayene, bool Biten)
        {
            InitializeComponent();

            muayene = Muayene;
            biten = Biten;
        }

        bool muayene;
        bool biten;

        private void frmMuayeneSigortaKontrol_Load(object sender, EventArgs e)
        {
            if (muayene == false)
            {
                dgvMuayeneler.Visible = false;
                dgvSigortalar.Visible = true;

                if (biten == false)
                {
                    this.Text = "Sigortası Bitecek Araçlar";

                    DataTable dt = new DataTable();
                    AT_Sigortalar.GetObjectToFinish(dt);
                    dgvSigortalar.DataSource = dt;
                }
                else
                {
                    this.Text = "Sigortası Biten Araçlar";

                    DataTable dt = new DataTable();
                    AT_Sigortalar.GetObjectFinished(dt);
                    dgvSigortalar.DataSource = dt;
                }
            }
            else
            {
                dgvMuayeneler.Visible = true;
                dgvSigortalar.Visible = false;

                if (biten == false)
                {
                    this.Text = "Muayenesi Bitecek Araçlar";

                    DataTable dt = new DataTable();
                    AT_Muayeneler.GetObjectToFinish(dt);
                    dgvMuayeneler.DataSource = dt;
                }
                else
                {
                    this.Text = "Muayenesi Biten Araçlar";

                    DataTable dt = new DataTable();
                    AT_Muayeneler.GetObjectFinished(dt);
                    dgvMuayeneler.DataSource = dt;
                }
            }

            dgvSigortalar.ClearSelection();
            dgvMuayeneler.ClearSelection();
        }

        private void dgvSigortalar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvSigortalar.SelectedRows.Count != 0)
            {
                frmAraclar.seciliaraba = dgvSigortalar.SelectedRows[0].Cells["clstrArabaPlaka2"].Value.ToString();
                this.Close();
            }
        }

        private void dgvMuayeneler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvMuayeneler.SelectedRows.Count != 0)
            {
                frmAraclar.seciliaraba = dgvMuayeneler.SelectedRows[0].Cells["clstrArabaPlaka"].Value.ToString();
                this.Close();
            }
        }
    }
}

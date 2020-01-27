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

namespace Sultanlar.UI
{
    public partial class frmHatalar : Form
    {
        public frmHatalar()
        {
            InitializeComponent();
        }

        private void dgvHatalar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Hatalar.DoDelete(dgvHatalar.Rows[e.RowIndex].Cells["clpkHataID"].Value.ToString());
                GetObject();
            }
        }

        private void frmHatalar_Load(object sender, EventArgs e)
        {
            GetObject();
        }

        private void GetObject()
        {
            dgvHatalar.DataSource = Hatalar.GetObject();
            dgvPDA.DataSource = LogTabloGuncellemeler.GetObject();
            dgvErisimler.DataSource = FormErisimleri.GetObject();
        }
    }
}

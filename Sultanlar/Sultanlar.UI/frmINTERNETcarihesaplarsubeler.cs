using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sultanlar.DatabaseObject.Internet;

namespace Sultanlar.UI
{
    public partial class frmINTERNETcarihesaplarsubeler : Form
    {
        public frmINTERNETcarihesaplarsubeler()
        {
            InitializeComponent();
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            CariHesaplar.GetObjectsByMusteriSube(dt, txtMUSTERI.Text.Trim().ToUpper(), txtSUBE.Text.Trim().ToUpper());
            dataGridView1.DataSource = dt;
            dataGridView1.ClearSelection();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                frmINTERNETiadeler.SubeDegistirmeSMREF = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["clSMREF"].Value);
                this.Close();
            }
        }

        private void txtSUBE_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnAra.PerformClick();
        }
    }
}

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
    public partial class frmINTERNETsatistemsilcileri1 : Form
    {
        public frmINTERNETsatistemsilcileri1()
        {
            InitializeComponent();

            DataTable dt = new DataTable();
            SatisTemsilcileri.GetObjects(dt);
            dataGridView1.DataSource = dt;
        }
        public frmINTERNETsatistemsilcileri1(bool UyeKaydindan)
        {
            InitializeComponent();

            uyekaydindan = true;
            DataTable dt = new DataTable();
            SatisTemsilcileri.GetObjects(dt);
            dataGridView1.DataSource = dt;
        }

        bool uyekaydindan;

        private void frmINTERNETsatistemsilcileri1_Load(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SatisTemsilcileri.GetObjectsBySatisTemsilcisi(dt, txtSATTEM.Text.Trim().ToUpper());
            dataGridView1.DataSource = dt;
            dataGridView1.ClearSelection();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex > -1)
            {
                if (uyekaydindan)
                {
                    frmINTERNETyenimusteri.SLSREF = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["clSLSMANREF"].Value);
                    frmINTERNETyenimusteri.SATKOD1 = dataGridView1.Rows[e.RowIndex].Cells["clSATKOD1"].Value.ToString();
                    frmINTERNETyenimusteri.SATTEM = dataGridView1.Rows[e.RowIndex].Cells["clSATTEM"].Value.ToString();
                }
                else
                {
                    frmINTERNETmusteriler.SLSREF = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["clSLSMANREF"].Value);
                    frmINTERNETmusteriler.SATKOD1 = dataGridView1.Rows[e.RowIndex].Cells["clSATKOD1"].Value.ToString();
                    frmINTERNETmusteriler.SATTEM = dataGridView1.Rows[e.RowIndex].Cells["clSATTEM"].Value.ToString();
                }
                this.Close();
            }
        }

        private void txtSATTEM_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnAra.PerformClick();
        }
    }
}

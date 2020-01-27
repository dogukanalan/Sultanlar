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
    public partial class frmINTERNETsatistemsilcileri : Form
    {
        public frmINTERNETsatistemsilcileri()
        {
            InitializeComponent();

            DataTable dt = new DataTable();
            CariHesaplar.GetObjects(dt, true);
            dataGridView1.DataSource = dt;
        }

        public frmINTERNETsatistemsilcileri(bool UyeKaydindan)
        {
            InitializeComponent();

            uyekaydindan = true;
            DataTable dt = new DataTable();
            CariHesaplar.GetObjectsByVergiNo(dt, "");
            dataGridView1.DataSource = dt;
        }

        bool uyekaydindan;
        bool altCari;

        public frmINTERNETsatistemsilcileri(string VergiNo)
        {
            InitializeComponent();

            altCari = false;
            DataTable dt = new DataTable();
            CariHesaplar.GetObjectsByVergiNo(dt, VergiNo);
            dataGridView1.DataSource = dt;
        }

        public frmINTERNETsatistemsilcileri(string AltCari, bool altcari)
        {
            InitializeComponent();

            altCari = true;
            DataTable dt = new DataTable();
            CariHesaplarTP.GetObjectsEslestirmeIcin(dt, AltCari);
            dataGridView1.DataSource = dt;
        }

        private void frmINTERNETcarihesaplar_Load(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            if (!altCari)
            {
                DataTable dt = new DataTable();
                CariHesaplar.GetObjectsByMusteri(dt, txtMUSTERI.Text.Trim().ToUpper());
                dataGridView1.DataSource = dt;
                dataGridView1.ClearSelection();
            }
            else
            {
                DataTable dt = new DataTable();
                CariHesaplarTP.GetObjectsEslestirmeIcin(dt, txtMUSTERI.Text.Trim().ToUpper());
                dataGridView1.DataSource = dt;
                dataGridView1.ClearSelection();
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (uyekaydindan)
                {
                    frmINTERNETyenimusteri.GMREF = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["clGMREF"].Value);
                    frmINTERNETyenimusteri.MUSKOD = dataGridView1.Rows[e.RowIndex].Cells["clMUSKOD"].Value.ToString();
                    frmINTERNETyenimusteri.MUSTERI = dataGridView1.Rows[e.RowIndex].Cells["clMUSTERI"].Value.ToString();
                }
                else
                {
                    if (!altCari)
                    {
                        frmINTERNETmusteriler.GMREF = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["clGMREF"].Value);
                        frmINTERNETmusteriler.MUSKOD = dataGridView1.Rows[e.RowIndex].Cells["clMUSKOD"].Value.ToString();
                        frmINTERNETmusteriler.MUSTERI = dataGridView1.Rows[e.RowIndex].Cells["clMUSTERI"].Value.ToString();
                    }
                    else
                    {
                        frmINTERNETmusteriler.SMREF = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["clGMREF"].Value); // SMREF GMREF adında geliyor
                        frmINTERNETmusteriler.MUSKOD = string.Empty;
                        frmINTERNETmusteriler.MUSTERI = dataGridView1.Rows[e.RowIndex].Cells["clMUSTERI"].Value.ToString();
                    }
                }
                this.Close();
            }
        }

        private void txtMUSTERI_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnAra.PerformClick();
        }
    }
}

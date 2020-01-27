using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sultanlar.DatabaseObject.Internet;
using System.Collections;

namespace Sultanlar.UI
{
    public partial class frmINTERNETurunaktifpasif : Form
    {
        public frmINTERNETurunaktifpasif()
        {
            InitializeComponent();
        }

        private void frmINTERNETurunaktifpasif_Load(object sender, EventArgs e)
        {
            GetObjects();
        }

        private void GetObjects()
        {
            DataTable dt = new DataTable();
            Urunler.GetProductsKullanimdakiler(dt, true);
            gridControl1.DataSource = dt;

            DataTable dt1 = new DataTable();
            Urunler.GetProductsKullanimdakiler(dt1, false);
            gridControl2.DataSource = dt1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int ITEMREF = Convert.ToInt32(gridView2.GetFocusedRowCellValue("ITEMREF"));
            Urunler.SetKullanimda(ITEMREF, true, frmAna.KAdi);
            GetObjects();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int ITEMREF = Convert.ToInt32(gridView1.GetFocusedRowCellValue("ITEMREF"));
            Urunler.SetKullanimda(ITEMREF, false, frmAna.KAdi);
            GetObjects();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            button1.PerformClick();
        }

        private void gridView2_DoubleClick(object sender, EventArgs e)
        {
            button2.PerformClick();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            int ITEMREF = Convert.ToInt32(gridView1.GetFocusedRowCellValue("ITEMREF"));
            frmINTERNETurunaktifpasiflog frm = new frmINTERNETurunaktifpasiflog(ITEMREF);
            frm.ShowDialog();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            int ITEMREF = Convert.ToInt32(gridView2.GetFocusedRowCellValue("ITEMREF"));
            frmINTERNETurunaktifpasiflog frm = new frmINTERNETurunaktifpasiflog(ITEMREF);
            frm.ShowDialog();
        }
    }
}

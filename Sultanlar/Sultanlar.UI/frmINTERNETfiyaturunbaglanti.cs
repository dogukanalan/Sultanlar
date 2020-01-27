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
    public partial class frmINTERNETfiyaturunbaglanti : Form
    {
        public frmINTERNETfiyaturunbaglanti()
        {
            InitializeComponent();
        }

        private void frmINTERNETfiyaturunbaglanti_Load(object sender, EventArgs e)
        {
            GetObjects();
        }

        private void GetObjects()
        {
            DataTable dt = new DataTable();
            FiyatTipUrun.GetObjects(dt);
            gridControl1.DataSource = dt;
        }

        private void btnYenile_Click(object sender, EventArgs e)
        {
            GetObjects();
        }

        private void frmINTERNETfiyaturunbaglanti_SizeChanged(object sender, EventArgs e)
        {
            sbEkle.Location = new Point(sbEkle.Location.X, lblAlt.Location.Y + 3);
            sbHizliSil.Location = new Point(sbHizliSil.Location.X, lblAlt.Location.Y + 3);
        }

        private void sbEkle_Click(object sender, EventArgs e)
        {
            frmINTERNETfiyaturunbaglantieklemesilme frm = new frmINTERNETfiyaturunbaglantieklemesilme();
            frm.ShowDialog();
            GetObjects();
        }

        private void sbHizliSil_Click(object sender, EventArgs e)
        {
            if (gridView1.SelectedRowsCount > 0 && !gridView1.IsFilterRow(gridView1.GetSelectedRows()[0]))
            {
                int TIP = Convert.ToInt32(gridView1.GetFocusedRowCellValue("TIP"));
                int ITEMREF = Convert.ToInt32(gridView1.GetFocusedRowCellValue("ITEMREF"));
                FiyatTipUrun.DoDelete(TIP, ITEMREF);
                GetObjects();
            }
        }

        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                sbHizliSil.PerformClick();
            }
        }
    }
}

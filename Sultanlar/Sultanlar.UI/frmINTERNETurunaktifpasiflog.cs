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
    public partial class frmINTERNETurunaktifpasiflog : Form
    {
        public frmINTERNETurunaktifpasiflog(int itemref)
        {
            InitializeComponent();
            ITEMREF = itemref;
        }

        int ITEMREF;

        private void frmINTERNETurunaktifpasiflog_Load(object sender, EventArgs e)
        {
            this.Text = Urunler.GetProductName(ITEMREF) + " (" + ITEMREF.ToString() + ")";
            DataTable dt = new DataTable();
            Urunler.GetProductsKullanimdakilerLog(dt, ITEMREF);
            gridControl1.DataSource = dt;
        }
    }
}

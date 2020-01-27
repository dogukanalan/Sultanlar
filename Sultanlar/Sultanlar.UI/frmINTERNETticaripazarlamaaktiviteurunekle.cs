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
    public partial class frmINTERNETticaripazarlamaaktiviteurunekle : Form
    {
        public frmINTERNETticaripazarlamaaktiviteurunekle(short fiyattipi)
        {
            InitializeComponent();
            FiyatTipi = fiyattipi;
        }

        short FiyatTipi;
        public int UrunID;

        private void frmINTERNETticaripazarlamaaktiviteurunekle_Load(object sender, EventArgs e)
        {
            UrunID = 0;
            DataTable dt = new DataTable();
            Urunler.GetProducts(dt, 0, 50000, FiyatTipi.ToString(), "IS", "NOT NULL", "IS", "NOT NULL", "", "", "TedarikciAdi", "ASC", new ArrayList(), new ArrayList(), false);
            gridControl1.DataSource = dt;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            UrunID = Convert.ToInt32(((DataRowView)gridControl1.MainView.GetRow(gridView1.GetSelectedRows()[0])).Row.ItemArray[1]);
            this.Close();
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            simpleButton1.PerformClick();
        }
    }
}

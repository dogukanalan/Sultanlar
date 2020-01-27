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
    public partial class frmINTERNETrutnotlar : Form
    {
        public frmINTERNETrutnotlar()
        {
            InitializeComponent();
        }

        private void frmINTERNETrutnotlar_Load(object sender, EventArgs e)
        {
            GetTemsilciler();
            GetRutlar();
        }

        private void GetTemsilciler()
        {
            SatisTemsilcileri.GetObjects(cmbTemsilciler.Items, true);
            cmbTemsilciler.SelectedIndex = 0;
        }

        private void GetRutlar()
        {
            textBox1.Text = string.Empty;
            DataTable dt = new DataTable();
            Rutlar.GetRutlar4Liste(dt, ((SatisTemsilcileri)cmbTemsilciler.SelectedItem).SLSREF, Convert.ToDateTime(dateTimePicker1.Value.ToShortDateString()));
            gridControl1.DataSource = dt;
        }

        private void btnYenile_Click(object sender, EventArgs e)
        {
            GetRutlar();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string id = gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], "ID").ToString();
            string text = textBox1.Text.Trim();

            Rutlar.SetRutNot4Liste(id, text);

            GetRutlar();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridView1.GetSelectedRows()[0] != DevExpress.XtraGrid.GridControl.AutoFilterRowHandle && gridView1.GetSelectedRows().Length > 0)
                DetayGetir();
        }

        private void DetayGetir()
        {
            if (gridView1.GetSelectedRows().Length == 0)
                return;

            string id = gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], "ID").ToString();
            textBox1.Text = Rutlar.GetRutNot4Liste(id);
        }
    }
}

using Sultanlar.DatabaseObject.Internet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Sultanlar.UI
{
    public partial class frmRakipUrunler : Form
    {
        public frmRakipUrunler()
        {
            InitializeComponent();
        }

        private void frmRakipUrunler_Load(object sender, EventArgs e)
        {
            GetMalzemeler();
        }

        private void GetMalzemeler()
        {
            DataTable dt = new DataTable();
            Malzeme2.GetObjects(dt);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
        }

        private void dataGridView1_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            MessageBox.Show("added");
        }
    }
}

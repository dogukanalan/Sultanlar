using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using Sultanlar.DatabaseObject;
using Sultanlar.DatabaseObject.Internet;

namespace Sultanlar.UI
{
    public partial class frmINTERNETmusterionaydurumharaketleri : Form
    {
        public frmINTERNETmusterionaydurumharaketleri()
        {
            InitializeComponent();
        }

        public frmINTERNETmusterionaydurumharaketleri(int MusteriID)
        {
            InitializeComponent();
            GetObject(MusteriID);
        }

        private void frmINTERNETmusterionaydurumharaketleri_Load(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
        }

        private void GetObject(int MusteriID)
        {
            DataTable dt = new System.Data.DataTable();
            MusteriOnayDurumHareketleri.GetObject(dt, MusteriID);
            dataGridView1.DataSource = dt;
        }
    }
}

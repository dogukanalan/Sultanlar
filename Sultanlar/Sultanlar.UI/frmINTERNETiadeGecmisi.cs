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
    public partial class frmINTERNETiadeGecmisi : Form
    {
        public frmINTERNETiadeGecmisi()
        {
            InitializeComponent();
        }
        public frmINTERNETiadeGecmisi(int IadeID)
        {
            InitializeComponent();
            iadeid = IadeID;
        }

        int iadeid;

        private void frmIadeGecmisi_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            IadeHareketleri.GetObjectByIadeID(iadeid, dt);
            dataGridView1.DataSource = dt;
        }
    }
}

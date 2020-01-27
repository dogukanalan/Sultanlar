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
    public partial class frmINTERNETresimistatistik : Form
    {
        public frmINTERNETresimistatistik()
        {
            InitializeComponent();
        }

        private void frmINTERNETresimistatistik_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            UrunResim.GetIstatistik(dt);
            dgv.DataSource = dt;
            dgv.ClearSelection();
        }
    }
}

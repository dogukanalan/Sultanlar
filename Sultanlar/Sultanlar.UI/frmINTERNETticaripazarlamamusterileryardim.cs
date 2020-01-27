using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sultanlar.DatabaseObject;

namespace Sultanlar.UI
{
    public partial class frmINTERNETticaripazarlamamusterileryardim : Form
    {
        public frmINTERNETticaripazarlamamusterileryardim()
        {
            InitializeComponent();
        }

        private void frmINTERNETticaripazarlamamusterileryardim_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            Ilceler.GetObjectIllerIlceler(dt);
            dataGridView1.DataSource = dt;
        }
    }
}

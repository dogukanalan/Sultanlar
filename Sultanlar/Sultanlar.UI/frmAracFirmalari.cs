using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sultanlar.DatabaseObject;
using Sultanlar.Class;

namespace Sultanlar.UI
{
    public partial class frmAracFirmalari : Form
    {
        public frmAracFirmalari()
        {
            InitializeComponent();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (txtFirmaEkle.Text.Trim() != string.Empty)
            {
                AT_AracFirmalari af = new AT_AracFirmalari(txtFirmaEkle.Text.Trim());
                af.DoInsert();
                this.Close();
            }
        }

        private void txtFirmaEkle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnEkle.PerformClick();
            }
        }
    }
}

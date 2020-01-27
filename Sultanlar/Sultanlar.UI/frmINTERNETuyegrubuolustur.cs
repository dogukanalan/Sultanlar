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
    public partial class frmINTERNETuyegrubuolustur : Form
    {
        public frmINTERNETuyegrubuolustur()
        {
            InitializeComponent();
        }

        private void btnOlustur_Click(object sender, EventArgs e)
        {
            UyeGruplari ug = new UyeGruplari(txtUyeGrubu.Text.Trim(), false);
            ug.DoInsert();
            this.Close();
        }
    }
}

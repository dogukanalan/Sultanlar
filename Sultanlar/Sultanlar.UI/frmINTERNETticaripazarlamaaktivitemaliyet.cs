using Sultanlar.DatabaseObject;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Sultanlar.UI
{
    public partial class frmINTERNETticaripazarlamaaktivitemaliyet : Form
    {
        public frmINTERNETticaripazarlamaaktivitemaliyet(int AktiviteID)
        {
            InitializeComponent();
            Aktivite = AktiviteID;
        }

        int Aktivite;

        private void frmINTERNETticaripazarlamaaktivitemaliyet_Load(object sender, EventArgs e)
        {
            DataTable dt = WebGenel.WCFdata("sp_INTERNET_AktiviteMarkaMaliyet", new ArrayList() { "pkID" }, new ArrayList() { Aktivite }, "");
            dataGridView1.DataSource = dt;
        }
    }
}

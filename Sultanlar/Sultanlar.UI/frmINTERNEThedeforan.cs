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
    public partial class frmINTERNEThedeforan : Form
    {
        public frmINTERNEThedeforan()
        {
            InitializeComponent();
        }

        private void frmINTERNEThedeforan_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'kurumsalWebSAPDataSet1._Web_Hedef_3' table. You can move, or remove it, as needed.
            this.web_Hedef_3TableAdapter.Fill(this.kurumsalWebSAPDataSet1._Web_Hedef_3);

        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

            this.Validate();
            this.webHedef3BindingSource.EndEdit();
            web_Hedef_3TableAdapter.Update(kurumsalWebSAPDataSet1);
        }
    }
}

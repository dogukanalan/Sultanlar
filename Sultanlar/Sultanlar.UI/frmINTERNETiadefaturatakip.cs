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
    public partial class frmINTERNETiadefaturatakip : Form
    {
        public frmINTERNETiadefaturatakip()
        {
            InitializeComponent();
        }

        private void frmINTERNETiadefaturatakip_Load(object sender, EventArgs e)
        {
            DoYetkiler();
            GetObjects();
        }

        private void DoYetkiler()
        {
            if (frmAna.KAdi.ToUpper() == "YN02") // fahrettin kaya
            {
                sbKontrol.Enabled = true;
            }
            else if (frmAna.KAdi.ToUpper() == "ST08" || frmAna.KAdi.ToUpper() == "ST01" || frmAna.KAdi.ToUpper() == "ST06" || frmAna.KAdi.ToUpper() == "ST09") // ünal yıldırım, volkan gazanfer, tuba polat, zehra akgül
            {
                sbPazarlama.Enabled = true;
            }
            else if (frmAna.KAdi.ToUpper() == "BI04" || frmAna.KAdi.ToUpper() == "ADMİNİSTRATOR")
            {
                sbKontrol.Enabled = true;
                sbPazarlama.Enabled = true;
            }
        }

        private void GetObjects()
        {
            DataTable dt = new DataTable();
            IadeFaturaTakip.GetObjects(dt);
            gridControl1.DataSource = dt;
        }

        private void frmINTERNETiadefaturatakip_SizeChanged(object sender, EventArgs e)
        {
            label1.Location = new Point(label1.Location.X, lblAlt.Location.Y + 6);
            txtKontrol.Location = new Point(txtKontrol.Location.X, lblAlt.Location.Y + 4);
            sbKontrol.Location = new Point(sbKontrol.Location.X, lblAlt.Location.Y + 3);
            label2.Location = new Point(label2.Location.X, lblAlt.Location.Y + 6);
            txtPazarlama.Location = new Point(txtPazarlama.Location.X, lblAlt.Location.Y + 4);
            sbPazarlama.Location = new Point(sbPazarlama.Location.X, lblAlt.Location.Y + 3);
        }

        private void sbKontrol_Click(object sender, EventArgs e)
        {
            if (gridView1.SelectedRowsCount > 0 && !gridView1.IsFilterRow(gridView1.GetSelectedRows()[0]))
            {
                int ID = Convert.ToInt32(gridView1.GetFocusedRowCellValue("pkID"));
                IadeFaturaTakip.DoUpdate(ID, true, DateTime.Now, txtKontrol.Text.Trim());
                GetObjects();
                txtKontrol.Text = string.Empty;
            }
        }

        private void sbPazarlama_Click(object sender, EventArgs e)
        {
            if (gridView1.SelectedRowsCount > 0 && !gridView1.IsFilterRow(gridView1.GetSelectedRows()[0]))
            {
                int ID = Convert.ToInt32(gridView1.GetFocusedRowCellValue("pkID"));
                IadeFaturaTakip.DoUpdate(ID, true, DateTime.Now, txtPazarlama.Text.Trim(), true);
                GetObjects();
                txtPazarlama.Text = string.Empty;
            }
        }

        private void btnYenile_Click(object sender, EventArgs e)
        {
            GetObjects();
        }
    }
}

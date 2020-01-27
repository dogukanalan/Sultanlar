using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sultanlar.DatabaseObject;
using System.Collections;

namespace Sultanlar.UI
{
    public partial class frmAT2rotamusterisecim : Form
    {
        public frmAT2rotamusterisecim()
        {
            InitializeComponent();
        }

        private void frmAT2rotamusterisecim_Load(object sender, EventArgs e)
        {
            GetMusteriler();
        }

        private void GetMusteriler()
        {
            DataTable dt = new DataTable();
            AT2_RotaMusteri.GetObjectsWithCustomers(dt);
            gridControl2.DataSource = dt;
        }

        private void sbDetay_Click(object sender, EventArgs e)
        {
            ArrayList smrefs = new ArrayList();

            for (int i = 0; i < gridView2.RowCount; i++)
            {
                if (Convert.ToBoolean(gridView2.GetRowCellValue(i, "SECIM")))
                {
                    int SMREF = Convert.ToInt32(gridView2.GetRowCellValue(i, "SMREF"));
                    smrefs.Add(SMREF);
                }
            }

            if (smrefs.Count > 0)
            {
                frmAT2rotamusteri.ekleSMREF = smrefs;
            }

            this.Close();
        }

        private void gridView2_DoubleClick(object sender, EventArgs e)
        {

        }
    }
}

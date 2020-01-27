using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sultanlar.DatabaseObject.Kenton;

namespace Sultanlar.UI
{
    public partial class frmKENTON_Yorumlar : Form
    {
        public frmKENTON_Yorumlar()
        {
            InitializeComponent();
        }

        private void frmKENTON_Yorumlar_Load(object sender, EventArgs e)
        {
            GetYorumlar();
        }

        private void GetYorumlar()
        {
            DataTable dt = new DataTable();
            Yorumlar.GetObjects(dt, 1000000, 1000000);
            gridControl1.DataSource = dt;
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridView1.SelectedRowsCount > 0 && !gridView1.IsFilterRow(gridView1.GetSelectedRows()[0]))
            {
                int ID = Convert.ToInt32(gridView1.GetFocusedRowCellValue("pkID"));
                Yorumlar yorum = Yorumlar.GetObject(ID);
                textBox1.Text = gridView1.GetFocusedRowCellValue("strYorum").ToString();
                checkBox1.Checked = Convert.ToBoolean(gridView1.GetFocusedRowCellValue("blOnayli"));
            }
            else
            {
                textBox1.Text = string.Empty;
                checkBox1.Checked = false;
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(gridView1.GetFocusedRowCellValue("pkID"));
            Yorumlar yorum = Yorumlar.GetObject(ID);
            //yorum.strYorum = textBox1.Text;
            yorum.blOnayli = checkBox1.Checked;
            yorum.DoUpdate();
            gridView1.SetFocusedRowCellValue("blOnayli", yorum.blOnayli);
            MessageBox.Show("Yorum güncellendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}

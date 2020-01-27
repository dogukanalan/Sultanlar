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
    public partial class frmINTERNETresimlerrapor : Form
    {
        public frmINTERNETresimlerrapor()
        {
            InitializeComponent();
        }

        private void frmINTERNETresimlerrapor_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            UrunResim.GetTedarikciResimSayisi(dt);
            dgv.DataSource = dt;

            int toplamurun = 0;
            int resimliurun = 0;
            int resimsizurun = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                toplamurun += Convert.ToInt32(dt.Rows[i]["ToplamUrunSayisi"]);
                resimliurun += Convert.ToInt32(dt.Rows[i]["ResimliUrunSayisi"]);
                resimsizurun += Convert.ToInt32(dt.Rows[i]["ResimsizUrunSayisi"]);
            }
            lblToplamUrun.Text = toplamurun.ToString();
            lblResimliUrun.Text = resimliurun.ToString();
            lblResimsizUrun.Text = resimsizurun.ToString();
            lblYuzde.Text = "%" + ((resimliurun * 100) / toplamurun).ToString();
        }

        private void btnResimsizTedarikciler_Click(object sender, EventArgs e)
        {
            frmINTERNETmusterilersistemde frm = new frmINTERNETmusterilersistemde(true);
            frm.Text = "Resim Eklenmemiş Tedarikçiler";
            frm.ShowDialog();
        }

        private void btnIstatistik_Click(object sender, EventArgs e)
        {
            frmINTERNETresimistatistik frm = new frmINTERNETresimistatistik();
            frm.ShowDialog();
        }
    }
}

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
    public partial class frmINTERNETpersonelbaglantilari : Form
    {
        public frmINTERNETpersonelbaglantilari()
        {
            InitializeComponent();
        }

        private void frmINTERNETpersonelbaglantilari_Load(object sender, EventArgs e)
        {
            GetObjects();
        }

        private void GetObjects()
        {
            GetPersoneller();
            lbPersoneller.SelectedIndex = 0;
        }

        private void GetMusteriler()
        {
            DataTable dt = new DataTable();
            TP_PersonelBaglantilari.GetObjects(dt, ((TP_Personeller)lbPersoneller.SelectedItem).pkID);
            gridControl1.DataSource = dt;
        }

        private void GetPersoneller()
        {
            TP_Personeller.GetObjects(lbPersoneller.Items, true);
        }

        private void lbPersoneller_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbPersoneller.SelectedIndex > -1)
                GetMusteriler();
        }

        private void btnPerEkle_Click(object sender, EventArgs e)
        {
            frmINTERNETpersonelekle frm = new frmINTERNETpersonelekle();
            frm.ShowDialog();
            GetObjects();
        }

        private void btnPerDuzenle_Click(object sender, EventArgs e)
        {
            if (lbPersoneller.SelectedIndex > -1)
            {
                frmINTERNETpersonelekle frm = new frmINTERNETpersonelekle(true, ((TP_Personeller)lbPersoneller.SelectedItem).pkID);
                frm.ShowDialog();
            }
        }

        private void btnPerSil_Click(object sender, EventArgs e)
        {
            if (lbPersoneller.SelectedIndex > -1)
            {
                if (MessageBox.Show("Personeli silmek istediğinize emin misiniz?", "Silme", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    TP_Personeller per = TP_Personeller.GetObject(((TP_Personeller)lbPersoneller.SelectedItem).pkID);
                    TP_PersonelBaglantilari.DoDelete(per.pkID);
                    per.DoDelete();
                    GetObjects();
                }
            }
        }

        private void btnPerBaglanti_Click(object sender, EventArgs e)
        {
            frmINTERNETpersonelbaglantiyap frm = new frmINTERNETpersonelbaglantiyap();
            frm.ShowDialog();
            GetObjects();
        }

        private void btnPerBaglantiKaldir_Click(object sender, EventArgs e)
        {
            if (gridView1.FocusedRowHandle > -1)
            {
                if (MessageBox.Show("Seçili bağlantıyı silmek istediğinize emin misiniz?", "Silme", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    TP_PersonelBaglantilari.DoDelete(Convert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SMREF")),
                        Convert.ToBoolean(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "blBayi")),
                        ((TP_Personeller)lbPersoneller.SelectedItem).pkID);
                    GetObjects();
                }
            }
        }
    }
}

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
    public partial class frmINTERNETpersonelbaglantiyap : Form
    {
        public frmINTERNETpersonelbaglantiyap()
        {
            InitializeComponent();
        }

        private void frmINTERNETpersonelbaglantiyap_Load(object sender, EventArgs e)
        {
            GetPersoneller();
            GetBayiler();
        }

        private void GetBayiler()
        {
            CariHesaplarTP.GetObjects(cmbBayiler.Items, 0);
            cmbBayiler.Items.Add("SULTANLAR PAZARLAMA A.Ş.");
            cmbBayiler.SelectedIndex = 0;
        }

        private void GetMusteriler()
        {
            if (cmbBayiler.SelectedIndex > -1 && cmbBayiler.SelectedItem.ToString() != "SULTANLAR PAZARLAMA A.Ş.")
                CariHesaplarTP.GetObjects(clbMusteriler.Items, ((CariHesaplarTP)cmbBayiler.SelectedItem).GMREF);
            else if (cmbBayiler.SelectedItem.ToString() == "SULTANLAR PAZARLAMA A.Ş.")
                CariHesaplar.GetObjects(clbMusteriler.Items, true);
        }

        private void GetPersoneller()
        {
            TP_Personeller.GetObjects(clbPersoneller.Items, true);
        }

        private void cmbBayiler_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetMusteriler();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < clbPersoneller.CheckedItems.Count; i++)
            {
                for (int j = 0; j < clbMusteriler.CheckedItems.Count; j++)
                {
                    if (cmbBayiler.SelectedItem.ToString() != "SULTANLAR PAZARLAMA A.Ş.")
                        TP_PersonelBaglantilari.DoInsert(((CariHesaplarTP)clbMusteriler.CheckedItems[j]).SMREF, true, ((TP_Personeller)clbPersoneller.CheckedItems[i]).pkID, string.Empty);
                    else
                        TP_PersonelBaglantilari.DoInsert(((CariHesaplar)clbMusteriler.CheckedItems[j]).SMREF, false, ((TP_Personeller)clbPersoneller.CheckedItems[i]).pkID, string.Empty);
                }
            }

            MessageBox.Show("Seçilen personeller seçilen müşterilere bağlandı.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            GetPersoneller();
            GetBayiler();
        }

        private void cbTumu_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < clbMusteriler.Items.Count; i++)
                clbMusteriler.SetItemChecked(i, cbTumu.Checked);
        }
    }
}

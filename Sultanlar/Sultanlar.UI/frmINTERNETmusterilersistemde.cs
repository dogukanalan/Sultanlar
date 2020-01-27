using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sultanlar.DatabaseObject;
using Sultanlar.DatabaseObject.Internet;
using System.Collections;

namespace Sultanlar.UI
{
    public partial class frmINTERNETmusterilersistemde : Form
    {
        public frmINTERNETmusterilersistemde()
        {
            InitializeComponent();
            Musteriler.GetObjectsSistemde(listBox1.Items);
            label1.Text = "Üye Sayısı: " + listBox1.Items.Count.ToString();
        }

        public frmINTERNETmusterilersistemde(bool ResimsizTedarikciler)
        {
            InitializeComponent();
            Urunler.GetResimsizTedarikciler(listBox1.Items);
            label1.Text = "Tedarikçi Sayısı: " + listBox1.Items.Count.ToString();
        }

        Iadeler iade;

        public frmINTERNETmusterilersistemde(int IadeninMusterisiDegismekIcinIadeID)
        {
            InitializeComponent();
            iade = Iadeler.GetObjectsByIadeID(IadeninMusterisiDegismekIcinIadeID);
            Musteriler.GetObjectsOnlySattemsAndYoneticis(listBox1.Items, true);
            label1.Text = "Üye Sayısı: " + listBox1.Items.Count.ToString();
            bool bulundu = false;
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                if (((Musteriler)listBox1.Items[i]).pkMusteriID == iade.intMusteriID)
                {
                    listBox1.SelectedIndex = i;
                    bulundu = true;
                    break;
                }
            }
            if (!bulundu)
            {
                listBox1.SelectedIndex = -1;
            }
        }

        private void frmINTERNETmusterilersistemde_Load(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (iade != null && listBox1.SelectedIndex != -1)
            {
                if (iade.intMusteriID != ((Musteriler)listBox1.SelectedItem).pkMusteriID)
                {
                    iade.intMusteriID = ((Musteriler)listBox1.SelectedItem).pkMusteriID;
                    iade.DoUpdate();

                    IadeHareketleri.DoInsert(iade.pkIadeID, 12, frmAna.KAdi.ToUpper(), ""); // üye değiştirildi
                }
            }
        }
    }
}

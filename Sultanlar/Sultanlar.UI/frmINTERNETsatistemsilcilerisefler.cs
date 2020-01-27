using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Sultanlar.DatabaseObject.Internet;

namespace Sultanlar.UI
{
    public partial class frmINTERNETsatistemsilcilerisefler : Form
    {
        public frmINTERNETsatistemsilcilerisefler()
        {
            InitializeComponent();
        }

        private void frmINTERNETsatistemsilcilerisefler_Load(object sender, EventArgs e)
        {
            GetSefler();
        }

        private void GetSefler()
        {
            SatisTemsilcileriSefler.GetUstler(lbSefler.Items, true);
            lbAltlar.Items.Clear();
        }

        private void lbSefler_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbSefler.SelectedIndex > -1)
            {
                lbAltlar.Items.Clear();
                ArrayList altlar = SatisTemsilcileriSefler.GetAltlar(((SatisTemsilcileriSefler)lbSefler.SelectedItem).ustSLSREF);
                for (int i = 0; i < altlar.Count; i++)
                    lbAltlar.Items.Add(altlar[i].ToString());
            }
            else
            {
                lbAltlar.Items.Clear();
            }
        }

        private void btnSefDuzenle_Click(object sender, EventArgs e)
        {
            frmINTERNETsatistemsilcileriseflerekleme frm = new frmINTERNETsatistemsilcileriseflerekleme();
            frm.Text = "Şefler : Düzenleme";
            frm.ShowDialog();

            GetSefler();
        }

        private void btnAltDuzenle_Click(object sender, EventArgs e)
        {
            if (lbSefler.SelectedIndex > -1)
            {
                frmINTERNETsatistemsilcileriseflerekleme frm = new frmINTERNETsatistemsilcileriseflerekleme(((SatisTemsilcileriSefler)lbSefler.SelectedItem).ustSLSREF);
                frm.Text = lbSefler.SelectedItem.ToString() + " : Düzenleme";
                frm.ShowDialog();
            }

            GetSefler();
        }
    }
}

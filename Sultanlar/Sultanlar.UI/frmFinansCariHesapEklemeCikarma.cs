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

namespace Sultanlar.UI
{
    public partial class frmFinansCariHesapEklemeCikarma : Form
    {
        public frmFinansCariHesapEklemeCikarma()
        {
            InitializeComponent();
        }

        private void frmFinansCariHesapEklemeCikarma_Load(object sender, EventArgs e)
        {
            GetAlinacaklar();
            GetAktarilacaklar();
        }

        private void GetAlinacaklar()
        {
            SatisTemsilcileri.GetObjectsFromCariHesaplar(cmbAlinacak.Items, true);
        }

        private void GetAktarilacaklar()
        {
            SatisTemsilcileri.GetObjects(clbAktarilacaklar.Items, true);
        }

        private void Temizle()
        {
            txtLog.Text = "Henüz aktarım yapılmadı...";
            GetAlinacaklar();
            GetAktarilacaklar();
            clbCariHesaplar.Items.Clear();
        }

        private void cmbAlinacak_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbTumu.Checked = false;
            CariHesaplar.GetObjectsBySLSREF(clbCariHesaplar.Items, ((SatisTemsilcileri)cmbAlinacak.SelectedItem).SLSREF);
        }

        private void cbTumu_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < clbCariHesaplar.Items.Count; i++)
                clbCariHesaplar.SetItemChecked(i, cbTumu.Checked);
        }

        private void btnAktar_Click(object sender, EventArgs e)
        {
            string log = string.Empty;

            for (int j = 0; j < clbAktarilacaklar.CheckedItems.Count; j++)
            {
                for (int i = 0; i < clbCariHesaplar.CheckedItems.Count; i++)
                {
                    SatTemMusteriTalepleriLog stmtl = new SatTemMusteriTalepleriLog(
                        ((CariHesaplar)clbCariHesaplar.CheckedItems[i]).SMREF,
                        ((SatisTemsilcileri)clbAktarilacaklar.CheckedItems[j]).SLSREF,
                        0,
                        false,
                        DateTime.Now,
                        ((SatisTemsilcileri)cmbAlinacak.SelectedItem).SLSREF,
                        frmAna.KAdi);
                    stmtl.DoInsert();

                    SatTemMusteriTalepleri smt = new SatTemMusteriTalepleri(
                        ((CariHesaplar)clbCariHesaplar.CheckedItems[i]).SMREF,
                        ((SatisTemsilcileri)clbAktarilacaklar.CheckedItems[j]).SLSREF,
                        false,
                        ((SatisTemsilcileri)cmbAlinacak.SelectedItem).SLSREF,
                        stmtl.pkID);
                    log += ((SatisTemsilcileri)clbAktarilacaklar.CheckedItems[j]).SATTEM + " - ";
                    log += ((CariHesaplar)clbCariHesaplar.CheckedItems[i]).SUBE == string.Empty ? ((CariHesaplar)clbCariHesaplar.CheckedItems[i]).MUSTERI : ((CariHesaplar)clbCariHesaplar.CheckedItems[i]).SUBE;
                    log += "\r\n";
                    smt.DoInsert();
                }
            }

            txtLog.Text = log;

            MessageBox.Show("Aktarım kaydı alındı.", "Aktarım", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnAktar.Enabled = false;
            btnTemizle.Focus();
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
            btnAktar.Enabled = true;
        }
    }
}

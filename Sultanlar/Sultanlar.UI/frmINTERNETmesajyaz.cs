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
    public partial class frmINTERNETmesajyaz : Form
    {
        public frmINTERNETmesajyaz(byte DepartmanID)
        {
            InitializeComponent();
            departmanid = DepartmanID;
            ilkMusteriler = new ArrayList();
            GetMusteriler();
            MusterilerSuz();
            oncekimesaj = 0;
        }

        public frmINTERNETmesajyaz(byte DepartmanID, int MusteriID, int MesajID)
        {
            InitializeComponent();
            departmanid = DepartmanID;
            ilkMusteriler = new ArrayList();
            GetMusteriler();
            MusterilerSuz();
            for (int i = 0; i < clbMusteriler.Items.Count; i++)
            {
                if (((Musteriler)clbMusteriler.Items[i]).pkMusteriID == MusteriID)
                {
                    clbMusteriler.SetItemChecked(i, true);
                    break;
                }
            }
            clbMusteriler.Enabled = false;
            rbMusteri.Enabled = false;
            rbPerakende.Enabled = false;
            rbSatTem.Enabled = false;
            rbTumu.Enabled = false;
            cbHepsini.Enabled = false;
            txtUnvan.Enabled = false;
            btnAra.Enabled = false;

            ArrayList mesaj = AlinanMesajlar.GetObject(MesajID);
            txtKonu.Text = "Re: " + mesaj[0].ToString();
            txtMesaj.Text = "---- Bir önceki mesaj ----\r\nTarih: " + mesaj[2].ToString() + "\r\n" + mesaj[1].ToString().Replace("<br />", "\r\n") + "\r\n--------------------------\r\n";
            txtMesaj.SelectionStart = txtMesaj.MaxLength;
            oncekimesaj = MesajID;
        }

        byte departmanid;
        ArrayList ilkMusteriler;
        int oncekimesaj;

        private void GetMusteriler()
        {
            Musteriler.GetObjectsAktifler(ilkMusteriler, true);
        }

        private void MusterilerSuz()
        {
            clbMusteriler.Items.Clear();
            int UyeTipiID = 0;

            if (rbMusteri.Checked)
                UyeTipiID = 1;
            else if (rbSatTem.Checked)
                UyeTipiID = 4;
            else if (rbPerakende.Checked)
                UyeTipiID = 5;
            else if (rbBayiYon.Checked)
                UyeTipiID = 6;
            else if (rbMusterilerHaricTumu.Checked)
                UyeTipiID = 100;
            else if (rbButunSatis.Checked)
                UyeTipiID = 200;

            for (int i = 0; i < ilkMusteriler.Count; i++)
            {
                if (!((Musteriler)ilkMusteriler[i]).blPasif)
                {
                    if (txtUnvan.Text.Trim() == string.Empty ||
                        ((Musteriler)ilkMusteriler[i]).strAd.ToUpper().IndexOf(txtUnvan.Text.Trim().ToUpper()) > -1)
                    {
                        if (UyeTipiID == 100)
                        {
                            if (((Musteriler)ilkMusteriler[i]).tintUyeTipiID != 1 && ((Musteriler)ilkMusteriler[i]).tintUyeTipiID != 5 && ((Musteriler)ilkMusteriler[i]).tintUyeTipiID != 7) // müşteriler ve per. müşteriler hariç tümü
                                clbMusteriler.Items.Add(ilkMusteriler[i]);
                        }
                        else if (UyeTipiID == 5)
                        {
                            if (((Musteriler)ilkMusteriler[i]).blSicakSatis) // sde ler
                                clbMusteriler.Items.Add(ilkMusteriler[i]);
                        }
                        else if (UyeTipiID == 200)
                        {
                            if (((Musteriler)ilkMusteriler[i]).tintUyeTipiID != 1 && ((Musteriler)ilkMusteriler[i]).tintUyeTipiID != 5 && ((Musteriler)ilkMusteriler[i]).tintUyeTipiID != 2 && ((Musteriler)ilkMusteriler[i]).tintUyeTipiID != 7) // bütün satış ekibi
                                clbMusteriler.Items.Add(ilkMusteriler[i]);
                        }
                        else if (!rbTumu.Checked && ((Musteriler)ilkMusteriler[i]).tintUyeTipiID == Convert.ToByte(UyeTipiID) && !((Musteriler)ilkMusteriler[i]).blSicakSatis)
                        {
                            clbMusteriler.Items.Add(ilkMusteriler[i]);
                        }
                        else if (rbTumu.Checked)
                        {
                            clbMusteriler.Items.Add(ilkMusteriler[i]);
                        }
                    }
                }
            }

            lblMusteriSayisi.Text = clbMusteriler.Items.Count.ToString();
        }

        private void btnGonder_Click(object sender, EventArgs e)
        {
            if (clbMusteriler.CheckedItems.Count > 0 && txtMesaj.Text != string.Empty)
            {
                for (int i = 0; i < clbMusteriler.CheckedItems.Count; i++)
                {
                    string konu = "-Konu Yok-";
                    if (txtKonu.Text.Trim() != string.Empty)
                        konu = txtKonu.Text.Trim();

                    GonderilenMesajlar gm = new GonderilenMesajlar(
                        ((Musteriler)clbMusteriler.CheckedItems[i]).pkMusteriID,
                        departmanid,
                        konu,
                        txtMesaj.Text.Trim().Replace("\r\n", "<br />"),
                        DateTime.Now,
                        DateTime.MinValue,
                        false,
                        false,
                        false);
                    gm.DoInsert();

                    if (oncekimesaj != 0)
                    {
                        MesajlarCevaplar mc = new MesajlarCevaplar(oncekimesaj, true, gm.pkMesajID);
                        mc.DoInsert();
                    }
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("Eksik seçim var.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void frmINTERNETmesajyaz_Load(object sender, EventArgs e)
        {
            
        }

        private void rbTumu_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cbHepsini_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < clbMusteriler.Items.Count; i++)
                clbMusteriler.SetItemChecked(i, cbHepsini.Checked);
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            MusterilerSuz();
            cbHepsini.Checked = false;
        }

        private void clbMusteriler_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (clbMusteriler.SelectedIndex > -1)
            {
                lblUnvan.Text = ((Musteriler)clbMusteriler.SelectedItem).strUnvan;
            }
        }

        private void txtUnvan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAra.PerformClick();
            }
        }
    }
}

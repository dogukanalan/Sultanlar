using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sultanlar.DatabaseObject.Internet;
using System.Collections;

namespace Sultanlar.UI
{
    public partial class frmINTERNETticaripazarlamaaktiviteler : Form
    {
        public frmINTERNETticaripazarlamaaktiviteler()
        {
            InitializeComponent();
            SMREF = 0;
            this.Text = "Ticari Pazarlama : Aktiviteler (Tümü)";
        }

        public frmINTERNETticaripazarlamaaktiviteler(int smref)
        {
            InitializeComponent();
            SMREF = smref;
            this.Text = CariHesaplarTP.GetObject(smref, false).SUBE != null ? 
                "Ticari Pazarlama : Aktiviteler (" + CariHesaplarTP.GetObject(smref, false).SUBE + ")"
                : "Ticari Pazarlama : Aktiviteler (" + CariHesaplar.GetMUSTERIbyGMREF(smref) + ")";
            gridColumn6.Visible = false;
            gridColumn46.Visible = false;
        }

        int SMREF;
        bool Acilis;

        private void frmINTERNETticaripazarlamaaktiviteler_Load(object sender, EventArgs e)
        {
            Acilis = true;
            dateTimePicker1.Value = Convert.ToDateTime("01." + DateTime.Now.Month + "." + DateTime.Now.Year);
            dateTimePicker2.Value = dateTimePicker1.Value.AddMonths(1);
            //GetMusteriler();
            //GetBayiler();
            //GetFiyatTipleri();
            //GetAktiviteTipleri();
            GetAktiviteler();
            Acilis = false;
        }

        private void splitContainer1_Panel2_SizeChanged(object sender, EventArgs e)
        {
            sbEkle.Location = new Point(sbEkle.Location.X, splitContainer1.Panel2.Height - 26);
            sbDuzenle.Location = new Point(sbDuzenle.Location.X, splitContainer1.Panel2.Height - 26);
            sbSil.Location = new Point(sbSil.Location.X, splitContainer1.Panel2.Height - 26);
            sbOnayla.Location = new Point(sbOnayla.Location.X, splitContainer1.Panel2.Height - 26);
            sbReddet.Location = new Point(sbReddet.Location.X, splitContainer1.Panel2.Height - 26);
            sbGeriAl.Location = new Point(sbGeriAl.Location.X, splitContainer1.Panel2.Height - 26);
            sbYazdir.Location = new Point(sbYazdir.Location.X, splitContainer1.Panel2.Height - 26);
            sbExcel2.Location = new Point(sbExcel2.Location.X, splitContainer1.Panel2.Height - 26);
            btnFiyatExcel.Location = new Point(btnFiyatExcel.Location.X, splitContainer1.Panel2.Height - 26);

            lblSatirSayisi.Location = new Point(this.Width - 69, lblAlt.Location.Y + 7);
            lblSatirSayisi2.Location = new Point(this.Width - 109, lblAlt.Location.Y + 7);
        }

        private void frmINTERNETticaripazarlamaaktiviteler_SizeChanged(object sender, EventArgs e)
        {
            sbEkle.Location = new Point(sbEkle.Location.X, lblAlt.Location.Y + 3);
            sbDuzenle.Location = new Point(sbDuzenle.Location.X, lblAlt.Location.Y + 3);
            sbSil.Location = new Point(sbSil.Location.X, lblAlt.Location.Y + 3);
            sbOnayla.Location = new Point(sbOnayla.Location.X, lblAlt.Location.Y + 3);
            sbReddet.Location = new Point(sbReddet.Location.X, lblAlt.Location.Y + 3);
            sbGeriAl.Location = new Point(sbGeriAl.Location.X, lblAlt.Location.Y + 3);
            sbYazdir.Location = new Point(sbYazdir.Location.X, lblAlt.Location.Y + 3);
            sbExcel2.Location = new Point(sbExcel2.Location.X, lblAlt.Location.Y + 3);
            btnFiyatExcel.Location = new Point(btnFiyatExcel.Location.X, lblAlt.Location.Y + 3);

            rbHepsi.Location = new Point(this.Width - 383, rbHepsi.Location.Y);
            rbOnaylilar.Location = new Point(this.Width - 325, rbOnaylilar.Location.Y);
            rbRedler.Location = new Point(this.Width - 240, rbRedler.Location.Y);
            rbOnaysizlar.Location = new Point(this.Width - 131, rbOnaysizlar.Location.Y);

            lblSatirSayisi.Location = new Point(this.Width - 69, lblAlt.Location.Y + 7);
            lblSatirSayisi2.Location = new Point(this.Width - 109, lblAlt.Location.Y + 7);

            txtAciklama1.Width = this.Width - 774;
            txtAciklama2.Width = this.Width - 774;
            txtAciklama3.Width = this.Width - 774;
            txtAciklama4.Width = this.Width - 774;
        }

        private void frmINTERNETticaripazarlamaaktiviteler_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmAna frm1 = (frmAna)this.ParentForm;
            frm1.FormKapanirken(this.Name);
        }

        private void GetAktiviteler()
        {
            object Onayli = DBNull.Value;
            bool Hepsi = false;
            if (rbOnaylilar.Checked)
                Onayli = true;
            else if (rbOnaysizlar.Checked)
                Onayli = false;
            else if (rbHepsi.Checked)
                Hepsi = true;

            if (SMREF == 0)
            {
                int sayi = 10000; //Aktiviteler.GetAktiviteCount(dateTimePicker1.Value, dateTimePicker2.Value, Onayli, Hepsi);
                DataTable dt = new DataTable();
                Aktiviteler.GetObjects(dt, dateTimePicker1.Value, dateTimePicker2.Value, 0, sayi, Onayli, Hepsi, frmAna.KAdi);
                gridControl4.DataSource = dt;
            }
            else
            {
                int sayi = Aktiviteler.GetAktiviteCountBySMREF(0, SMREF, dateTimePicker1.Value, dateTimePicker2.Value, Onayli, Hepsi);
                DataTable dt = new DataTable();
                Aktiviteler.GetObjectsBySMREF(0, dt, SMREF, dateTimePicker1.Value, dateTimePicker2.Value, 0, sayi, Onayli, Hepsi);
                gridControl4.DataSource = dt;
            }
            lblSatirSayisi.Text = gridView4.RowCount.ToString();

            try
            {
                int AktiviteID = Convert.ToInt32(((DataRowView)gridControl4.MainView.GetRow(gridView4.GetSelectedRows()[0])).Row.ItemArray[0]);
                AktiviteGetir();
            }
            catch (Exception)
            {
                Temizle();
            }
        }

        private void GetAktiviteDetaylar()
        {
            int AktiviteID = Convert.ToInt32(((DataRowView)gridControl4.MainView.GetRow(gridView4.GetSelectedRows()[0])).Row.ItemArray[0]);
            DataTable dt = new DataTable();
            AktivitelerDetay.GetObjectsByAktiviteID(dt, AktiviteID);
            gridControl1.DataSource = dt;
        }

        private void GetBayiler()
        {
            CariHesaplarTP.GetObjects(cmbBayiler.Items, 0);
        }

        private void GetAltCariler(int GMREF)
        {
            CariHesaplarTP.GetObjects(cmbAltCariler.Items, GMREF);
        }

        //private void GetMusteriler()
        //{
        //    Musteriler.GetObjectsOnlySattemsYoneticisBayiYoneticis(cmbUyeler.Items, true);
        //}

        //private void GetFiyatTipleri()
        //{
        //    FiyatTipleri.GetObjectAciklamali(cmbFiyatTipleri.Items, true);
        //}

        //private void GetAktiviteTipleri()
        //{
        //    AktiviteTipleri.GetObjects(cmbAktiviteTipleri.Items, true);
        //}

        //private void GetAnlasmalar(int SMREF)
        //{
        //    Anlasmalar.GetObjects(cmbAnlasmalar.Items, SMREF);
        //    if (cmbAnlasmalar.Items.Count > 0)
        //        cmbAnlasmalar.SelectedIndex = 0;
        //}

        private void AktiviteGetir()
        {
            if (gridView4.SelectedRowsCount > 0 && !gridView4.IsFilterRow(gridView4.GetSelectedRows()[0]))
            {
                int AktiviteID = Convert.ToInt32(((DataRowView)gridControl4.MainView.GetRow(gridView4.GetSelectedRows()[0])).Row.ItemArray[0]);

                Aktiviteler aktivite = Aktiviteler.GetObject(AktiviteID);

                //for (int i = 0; i < cmbUyeler.Items.Count; i++)
                //    if (((Musteriler)cmbUyeler.Items[i]).pkMusteriID == aktivite.intMusteriID)
                //        cmbUyeler.SelectedIndex = i;

                lblAktiviteUye.Text = Musteriler.GetMusteriByID(aktivite.intMusteriID).strAd + " " + Musteriler.GetMusteriByID(aktivite.intMusteriID).strSoyad;

                //for (int i = 0; i < cmbBayiler.Items.Count; i++)
                //    if (((CariHesaplarTP)cmbBayiler.Items[i]).GMREF == CariHesaplarTP.GetGMREFBySMREF(aktivite.SMREF))
                //        cmbBayiler.SelectedIndex = i;

                lblAktiviteBayi.Text = aktivite.intAktiviteTipiID == 1 ? CariHesaplarTP.GetObject(aktivite.SMREF, true).MUSTERI : "SULTANLAR PAZARLAMA A.Ş.";

                //GetAltCariler(((CariHesaplarTP)cmbBayiler.SelectedItem).GMREF);

                //for (int i = 0; i < cmbAltCariler.Items.Count; i++)
                //    if (((CariHesaplarTP)cmbAltCariler.Items[i]).SMREF == aktivite.SMREF)
                //        cmbAltCariler.SelectedIndex = i;

                lblAktiviteAltCari.Text = aktivite.intAktiviteTipiID == 1 ? CariHesaplarTP.GetObject(aktivite.SMREF, false).SUBE : CariHesaplar.GetMUSTERIbySMREF(aktivite.SMREF);

                //for (int i = 0; i < cmbFiyatTipleri.Items.Count; i++)
                //    if (((FiyatTipleri)cmbFiyatTipleri.Items[i]).NOSU == aktivite.sintFiyatTipiID)
                //        cmbFiyatTipleri.SelectedIndex = i;

                lblAktiviteFiyatTipi.Text = aktivite.sintFiyatTipiID.ToString();

                //for (int i = 0; i < cmbAktiviteTipleri.Items.Count; i++)
                //    if (((AktiviteTipleri)cmbAktiviteTipleri.Items[i]).pkID == aktivite.intAktiviteTipiID)
                //        cmbAktiviteTipleri.SelectedIndex = i;

                lblAktiviteAktiviteTipi.Text = AktiviteTipleri.GetObject(aktivite.intAktiviteTipiID).strAktiviteTipi;

                //GetAnlasmalar(aktivite.SMREF);

                //for (int i = 0; i < cmbAnlasmalar.Items.Count; i++)
                //    if (((Anlasmalar)cmbAnlasmalar.Items[i]).pkID == aktivite.intAnlasmaID)
                //        cmbAnlasmalar.SelectedIndex = i;

                lblAktiviteAnlasma.Text = aktivite.intAnlasmaID.ToString();

                lblUyari.Text = string.Empty;

                if (aktivite.intAnlasmaID > 0)
                {
                    txtTAHHedefCiro.ReadOnly = true;
                    txtYEGHedefCiro.ReadOnly = true;
                    txtTAHSabitBedel.ReadOnly = true;
                    txtYEGSabitBedel.ReadOnly = true;

                    Anlasmalar anlas = Anlasmalar.GetObject(aktivite.intAnlasmaID);
                    if (anlas != null)
                    {
                        if (aktivite.dtAktiviteBitis > anlas.dtBitis)
                        {
                            lblUyari.Text = "ÖNEMLİ UYARI!\r\nAktivitenin bitiş tarihi anlaşmanın bitiş tarihinden daha ilerde!";
                        }

                        if (Anlasmalar.GetObjectCount("2", aktivite.SMREF, true, DateTime.Now, DateTime.Now) > 1)
                        {
                            if (anlas != null)
                            {
                                lblUyari.Text = "Aktivite alınan cariye ait onaylı ve geçerli birden fazla anlaşma bulunuyor. "
                                    + "\r\nAktivtedeki anlaşmanın koşulları şu şekildedir: KGT fatura altı: " + anlas.flTAHIsk.ToString("N1") + " NF fatura altı: " + anlas.flYEGIsk.ToString("N1")
                                    + " KGT fatura altı crio: " + anlas.flTAHCiroIsk.ToString("N1") + " NF fatura altı ciro: " + anlas.flYEGCiroIsk.ToString("N1") + " şeklindedir."
                                    + "\r\nAyrıca anlaşmanın açıklaması şu şekildedir: [" + anlas.strAciklama1 + "]";
                            }
                        }
                    }
                }
                else
                {
                    txtTAHHedefCiro.ReadOnly = false;
                    txtYEGHedefCiro.ReadOnly = false;
                    txtTAHSabitBedel.ReadOnly = false;
                    txtYEGSabitBedel.ReadOnly = false;

                    int smref = aktivite.intAktiviteTipiID == 2 ? CariHesaplar.GetGMREFBySMREF(aktivite.SMREF) : aktivite.SMREF;

                    int sononaysizanlasmaid = Anlasmalar.GetSonOnaylanmamisAnlasmaID(smref, aktivite.intAktiviteTipiID == 1 ? "1" : "2");
                    if (sononaysizanlasmaid > 0)
                        MessageBox.Show("Aktivite alınan cariye ait onaylanmamış anlaşma bulunuyor.\r\n\r\nAnlaşma numarası: " + sononaysizanlasmaid.ToString(), "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    int sonanlasmaid = Anlasmalar.GetSonAnlasmaID(smref, aktivite.intAktiviteTipiID == 1 ? "1" : "2");
                    if (sonanlasmaid > 0)
                    {
                        Anlasmalar anlasma = Anlasmalar.GetObject(sonanlasmaid);
                        if (anlasma.dtBitis > DateTime.Now.AddYears(-1) && anlasma.dtBitis < DateTime.Now)
                            MessageBox.Show("Aktivite alınan cariye ait son 1 senede bitmiş bir anlaşma bulunuyor.\r\n\r\nAnlaşma numarası: " + sonanlasmaid.ToString(), "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                dtpBaslangic.Value = aktivite.dtAktiviteBaslangic;
                dtpBitis.Value = aktivite.dtAktiviteBitis;
                lblOnayTarihi.Text = aktivite.dtOnaylamaTarihi.ToString();
                txtAciklama1.Text = aktivite.strAciklama1;
                txtAciklama2.Text = aktivite.strAciklama2;
                txtAciklama3.Text = aktivite.strAciklama3;
                txtAciklama4.Text = aktivite.strAciklama4;
                txtTAHSabitBedel.Text = aktivite.mnTahSabitBedel.ToString("N2");
                txtYEGSabitBedel.Text = aktivite.mnYegSabitBedel.ToString("N2");
                txtTAHHedefCiro.Text = aktivite.mnTahHedefCiro.ToString("N2");
                txtYEGHedefCiro.Text = aktivite.mnYegHedefCiro.ToString("N2");
                txtAktiviteKarZarar.Text = aktivite.mnAktiviteKarZarar.ToString("N2");
                txtAktiviteKarZararYuzde.Text = aktivite.flAktiviteKarZararYuzde.ToString("N1");

                GetAktiviteDetaylar();
                lblSatirSayisi2.Text = gridView1.RowCount.ToString();
                gridView1.ViewCaption = "(Aktivite No: " + aktivite.pkID.ToString() + ")       " + lblAktiviteBayi.Text + " : " + lblAktiviteAltCari.Text + " [" + CariHesaplar.GetGMREFBySMREF(aktivite.SMREF).ToString() + "]" + "       (" + aktivite.dtAktiviteBaslangic.ToShortDateString() + " - " + aktivite.dtAktiviteBitis.ToShortDateString() + ")";

                AktiviteEnableDisable(aktivite);
            }
            else
            {
                Temizle();
            }
        }

        private void Temizle()
        {
            //cmbUyeler.SelectedIndex = 0;
            lblAktiviteUye.Text = string.Empty;
            //cmbFiyatTipleri.SelectedIndex = 0;
            lblAktiviteFiyatTipi.Text = string.Empty;
            //cmbAktiviteTipleri.SelectedIndex = 0;
            lblAktiviteAktiviteTipi.Text = string.Empty;
            //cmbBayiler.SelectedIndex = -1;
            lblAktiviteBayi.Text = string.Empty;

            //cmbAnlasmalar.Items.Clear();
            lblAktiviteAnlasma.Text = string.Empty;
            //cmbAltCariler.Items.Clear();
            lblAktiviteAltCari.Text = string.Empty;

            dtpBaslangic.Value = DateTime.Now;
            dtpBitis.Value = DateTime.Now;
            lblOnayTarihi.Text = string.Empty;
            txtAciklama1.Text = string.Empty;
            txtAciklama2.Text = string.Empty;
            txtAciklama3.Text = string.Empty;
            txtAciklama4.Text = string.Empty;
            txtTAHSabitBedel.Text = 0.ToString("N2");
            txtYEGSabitBedel.Text = 0.ToString("N2");
            txtTAHHedefCiro.Text = 0.ToString("N2");
            txtYEGHedefCiro.Text = 0.ToString("N2");
            txtAktiviteKarZarar.Text = 0.ToString("N2");
            txtAktiviteKarZararYuzde.Text = 0.ToString("N1");

            DataTable dt = new DataTable();
            AktivitelerDetay.GetObjectsByAktiviteID(dt, -1);
            gridControl1.DataSource = dt;
            AktiviteEnableDisable(true);
        }

        private void AktiviteEnableDisable(Aktiviteler aktivite)
        {
            for (int i = 0; i < gridView1.Columns.Count; i++)
                gridView1.Columns[i].OptionsColumn.AllowEdit = !aktivite.blAktarilmis;

            gridColumn45.OptionsColumn.AllowEdit = false;
            gridColumn29.OptionsColumn.AllowEdit = false;
            gridColumn30.OptionsColumn.AllowEdit = false;
            gridColumn31.OptionsColumn.AllowEdit = false;
            gridColumn41.OptionsColumn.AllowEdit = false;
            gridColumn42.OptionsColumn.AllowEdit = false;
            gridColumn43.OptionsColumn.AllowEdit = false;
            gridColumn37.OptionsColumn.AllowEdit = false;
            //gridColumn39.OptionsColumn.AllowEdit = false;
            //gridColumn35.OptionsColumn.AllowEdit = false;
            gridColumn51.OptionsColumn.AllowEdit = false;
            gridColumn47.OptionsColumn.AllowEdit = false;
            gridColumn49.OptionsColumn.AllowEdit = false;
            gridColumn50.OptionsColumn.AllowEdit = false;
            gridColumn53.OptionsColumn.AllowEdit = false;
            gridColumn54.OptionsColumn.AllowEdit = false;
            gridColumn55.OptionsColumn.AllowEdit = false;
        }

        private void AktiviteEnableDisable(bool Aktif)
        {
            for (int i = 0; i < gridView1.Columns.Count; i++)
            {
                gridView1.Columns[i].OptionsColumn.AllowEdit = Aktif;
            }

            gridColumn30.OptionsColumn.AllowEdit = false;
            gridColumn31.OptionsColumn.AllowEdit = false;
        }

        private void btnYenile_Click(object sender, EventArgs e)
        {
            //GetMusteriler();
            //GetBayiler();
            //GetFiyatTipleri();
            //GetAktiviteTipleri();
            GetAktiviteler();
        }

        private void rbHepsi_CheckedChanged(object sender, EventArgs e)
        {
            if (!Acilis)
                if (((RadioButton)sender).Checked)
                    GetAktiviteler();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (!Acilis)
                GetAktiviteler();
        }

        private void cmbBayiler_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBayiler.SelectedIndex > -1)
                GetAltCariler(((CariHesaplarTP)cmbBayiler.SelectedItem).GMREF);
        }

        private void cmbAltCariler_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cmbAltCariler.SelectedIndex > -1)
            //    GetAnlasmalar(((CariHesaplarTP)cmbAltCariler.SelectedItem).SMREF);
        }

        private void gridControl4_Click(object sender, EventArgs e)
        {
        }

        private void sbEkle_Click(object sender, EventArgs e)
        {
            frmINTERNETticaripazarlamaaktiviteekle frm = new frmINTERNETticaripazarlamaaktiviteekle();
            frm.ShowDialog();
            GetAktiviteler();
        }

        private void sbDuzenle_Click(object sender, EventArgs e)
        {
            if (gridView4.SelectedRowsCount > 0 && !gridView4.IsFilterRow(gridView4.GetSelectedRows()[0]))
            {
                int AktiviteID = Convert.ToInt32(((DataRowView)gridControl4.MainView.GetRow(gridView4.GetSelectedRows()[0])).Row.ItemArray[0]);
                Aktiviteler aktivite = Aktiviteler.GetObject(AktiviteID);
                if (aktivite.blAktarilmis)
                {
                    MessageBox.Show("Aktivite onaylandığından (veya reddedildiğinden) düzenlenemez.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (MessageBox.Show("Aktivite güncellenecek, devam etmek istediğinize emin misiniz?", "Güncelleme", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                    {
                        try
                        {
                            aktivite.dtAktiviteBaslangic = dtpBaslangic.Value;
                            aktivite.dtAktiviteBitis = dtpBitis.Value;
                            //aktivite.dtOnaylamaTarihi = DateTime.Now;
                            //aktivite.intAktiviteTipiID = ((AktiviteTipleri)cmbAktiviteTipleri.SelectedItem).pkID;
                            //aktivite.intAnlasmaID = cmbAnlasmalar.SelectedIndex > -1 ? ((Anlasmalar)cmbAnlasmalar.SelectedItem).pkID : 0;
                            //aktivite.intMusteriID = ((Musteriler)cmbUyeler.SelectedItem).pkMusteriID;
                            aktivite.mnAktiviteKarZarar = Convert.ToDecimal(txtAktiviteKarZarar.Text.Replace(".", ""));
                            aktivite.flAktiviteKarZararYuzde = Convert.ToDouble(txtAktiviteKarZararYuzde.Text);
                            aktivite.mnTahHedefCiro = Convert.ToDecimal(txtTAHHedefCiro.Text.Replace(".", ""));
                            aktivite.mnTahSabitBedel = Convert.ToDecimal(txtTAHSabitBedel.Text.Replace(".", ""));
                            aktivite.mnYegHedefCiro = Convert.ToDecimal(txtYEGHedefCiro.Text.Replace(".", ""));
                            aktivite.mnYegSabitBedel = Convert.ToDecimal(txtYEGSabitBedel.Text.Replace(".", ""));
                            //aktivite.sintFiyatTipiID = ((FiyatTipleri)cmbFiyatTipleri.SelectedItem).NOSU;
                            //aktivite.SMREF = ((CariHesaplarTP)cmbAltCariler.SelectedItem).SMREF;
                            aktivite.strAciklama1 = txtAciklama1.Text.Trim();
                            aktivite.strAciklama2 = txtAciklama2.Text.Trim();
                            aktivite.strAciklama3 = txtAciklama3.Text.Trim();
                            //aktivite.strAciklama4 = txtAciklama4.Text.Trim();

                            aktivite.DoUpdate();
                            aktivite.DoReddet();

                            DataTable dt = new DataTable();
                            AktivitelerDetay.GetObjectsByAktiviteID(dt, aktivite.pkID);
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                long AktiviteDetayIDonceki = Convert.ToInt64(dt.Rows[i]["pkID"]);

                                for (int j = 0; j < gridView1.RowCount; j++)
                                {
                                    long AktiviteDetayID = gridControl1.MainView.GetRow(j) != null ? Convert.ToInt64(gridView1.GetRowCellValue(j, "pkID")) : 0;

                                    if (AktiviteDetayID == AktiviteDetayIDonceki) // düzenleme
                                    {
                                        int KoliAdedi = Convert.ToInt32(gridView1.GetRowCellValue(j, "intKoliAdet"));
                                        decimal Fiyat = Convert.ToDecimal(gridView1.GetRowCellValue(j, "mnBirimFiyatKDVli"));

                                        int satishedefi = gridView1.GetRowCellValue(j, "strSatisHedefi").ToString() != string.Empty ? Convert.ToInt32(gridView1.GetRowCellValue(j, "strSatisHedefi")) : 0;
                                        double ekisk = gridView1.GetRowCellValue(j, "flEkIsk").ToString() != string.Empty ? Convert.ToDouble(gridView1.GetRowCellValue(j, "flEkIsk")) : 0;
                                        decimal aksiyon = gridView1.GetRowCellValue(j, "mnAksiyonFiyati").ToString() != string.Empty ? Convert.ToDecimal(gridView1.GetRowCellValue(j, "mnAksiyonFiyati")) : 0;

                                        double FatAltIsk = Convert.ToDouble(gridView1.GetRowCellValue(j, "strAciklama1"));
                                        double FatAltCiro = Convert.ToDouble(gridView1.GetRowCellValue(j, "strAciklama2"));
                                        double PazIsk = Convert.ToDouble(gridView1.GetRowCellValue(j, "strAciklama3"));
                                        double CiroPrimDonusYuzde = Convert.ToDouble(gridView1.GetRowCellValue(j, "flCiroPrimDonusYuzde"));

                                        double para1 = Convert.ToDouble(Fiyat) - ((Convert.ToDouble(Fiyat) / 100) * FatAltIsk);
                                        double para2 = Convert.ToDouble(para1) - ((Convert.ToDouble(para1) / 100) * FatAltCiro);
                                        double para3 = Convert.ToDouble(para2) - ((Convert.ToDouble(para2) / 100) * PazIsk);
                                        double DusulmusBirimFiyatKDVli = Convert.ToDouble(para3) - ((Convert.ToDouble(para3) / 100) * ekisk);

                                        double tutar = Convert.ToDouble(DusulmusBirimFiyatKDVli) - ((Convert.ToDouble(DusulmusBirimFiyatKDVli) / 100) * CiroPrimDonusYuzde);



                                        if (!girdi)
                                        {
                                            girdi = true;
                                            gridView1.SetRowCellValue(j, "mnDusulmusBirimFiyatKDVli", DusulmusBirimFiyatKDVli);
                                            gridView1.SetRowCellValue(j, "mnTutar", tutar);
                                            gridView1.SetRowCellValue(j, "mnToplam", DusulmusBirimFiyatKDVli * satishedefi * KoliAdedi);
                                            girdi = false;
                                        }



                                        AktivitelerDetay aktivitelerdetay = AktivitelerDetay.GetObject(AktiviteDetayIDonceki);
                                        //aktivitelerdetay.flMusteriKarYuzde = Convert.ToDouble(gridView1.GetRowCellValue(j, "flMusteriKarYuzde"));
                                        //aktivitelerdetay.flKarZararYuzde = Convert.ToDouble(gridView1.GetRowCellValue(j, "flKarZararYuzde"));
                                        aktivitelerdetay.mnAksiyonFiyati = Convert.ToDecimal(gridView1.GetRowCellValue(j, "mnAksiyonFiyati"));
                                        aktivitelerdetay.strSatisHedefi = gridView1.GetRowCellValue(j, "strSatisHedefi").ToString();
                                        aktivitelerdetay.mnTutar = Convert.ToDecimal(tutar);

                                        if (aktivitelerdetay.flEkIsk != Convert.ToDouble(gridView1.GetRowCellValue(j, "flEkIsk")))
                                        {
                                            if (aktivitelerdetay.strAciklama4 != "1") // ilk istenen iskonto
                                                aktivitelerdetay.mnBayiMaliyet = Convert.ToDecimal(aktivitelerdetay.flEkIsk);
                                            aktivitelerdetay.strAciklama4 = "1";

                                            aktivitelerdetay.strAciklama5 = frmAna.KAdi + "-" + DateTime.Now.ToString();
                                        }
                                        aktivitelerdetay.flEkIsk = Convert.ToDouble(gridView1.GetRowCellValue(j, "flEkIsk"));

                                        //aktivitelerdetay.flCiroPrimDonusYuzde = Convert.ToDouble(gridView1.GetRowCellValue(j, "flCiroPrimDonusYuzde"));
                                        //aktivitelerdetay.mnBayiMaliyet = Convert.ToDecimal(gridView1.GetRowCellValue(j, "mnBayiMaliyet"));
                                        aktivitelerdetay.mnDusulmusBirimFiyatKDVli = Convert.ToDecimal(DusulmusBirimFiyatKDVli);
                                        aktivitelerdetay.mnToplam = Convert.ToDecimal(DusulmusBirimFiyatKDVli * satishedefi * KoliAdedi);
                                        aktivitelerdetay.DoUpdate();
                                        break;
                                    }
                                }
                            }

                            MesajAt(aktivite, 3);

                            MessageBox.Show("Aktivite güncellendi.", "Güncellendi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Seçimlerde eksik seçim var.\r\n\r\nHata ayrıntısı: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
        }

        private void sbSil_Click(object sender, EventArgs e)
        {
            if (gridView4.SelectedRowsCount > 0 && !gridView4.IsFilterRow(gridView4.GetSelectedRows()[0]))
            {
                int AktiviteID = Convert.ToInt32(((DataRowView)gridControl4.MainView.GetRow(gridView4.GetSelectedRows()[0])).Row.ItemArray[0]);
                Aktiviteler aktivite = Aktiviteler.GetObject(AktiviteID);

                if (aktivite.blAktarilmis)
                {
                    MessageBox.Show("Aktivite onaylandığından silinemez.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (MessageBox.Show("Aktivite silinecek, devam etmek istediğinize emin misiniz?", "Silme", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                    {
                        aktivite.DoDelete();

                        DataTable dt = new DataTable();
                        AktivitelerDetay.GetObjectsByAktiviteID(dt, AktiviteID);
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            AktivitelerDetay aktivitedetay = AktivitelerDetay.GetObject(Convert.ToInt64(dt.Rows[i]["pkID"]));
                            aktivitedetay.DoDelete();
                        }

                        MesajAt(aktivite, 4);

                        GetAktiviteler();
                    }
                }
            }
        }

        private void sbOnayla_Click(object sender, EventArgs e)
        {
            if (gridView4.SelectedRowsCount > 0 && !gridView4.IsFilterRow(gridView4.GetSelectedRows()[0]))
            {
                if (MessageBox.Show("Aktivite onaylanacak, devam etmek istediğinize emin misiniz?", "Onaylama", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    int AktiviteID = Convert.ToInt32(((DataRowView)gridControl4.MainView.GetRow(gridView4.GetSelectedRows()[0])).Row.ItemArray[0]);
                    Aktiviteler aktivite = Aktiviteler.GetObject(AktiviteID);

                    if (aktivite.blAktarilmis)
                    {
                        MessageBox.Show("Aktivite zaten onaylanmış.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    //aktivite.dtOnaylamaTarihi = DateTime.Now;
                    aktivite.blAktarilmis = true;
                    aktivite.DoUpdate();

                    MesajAt(aktivite, 1);

                    GetAktiviteler();
                }
            }
        }

        private void sbReddet_Click(object sender, EventArgs e)
        {
            if (gridView4.SelectedRowsCount > 0 && !gridView4.IsFilterRow(gridView4.GetSelectedRows()[0]))
            {
                if (MessageBox.Show("Aktivite iptal edilip satıcıya gönderilecek, devam etmek istediğinize emin misiniz?", "Reddetme", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    int AktiviteID = Convert.ToInt32(((DataRowView)gridControl4.MainView.GetRow(gridView4.GetSelectedRows()[0])).Row.ItemArray[0]);
                    Aktiviteler aktivite = Aktiviteler.GetObject(AktiviteID);

                    aktivite.blAktarilmis = false;
                    aktivite.DoUpdate();

                    MesajAt(aktivite, 2);

                    GetAktiviteler();
                }
            }
        }

        private void sbGeriAl_Click(object sender, EventArgs e)
        {
            if (gridView4.SelectedRowsCount > 0 && !gridView4.IsFilterRow(gridView4.GetSelectedRows()[0]))
            {
                if (MessageBox.Show("Aktivite geri alınacak, devam etmek istediğinize emin misiniz?", "Geri alma", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    int AktiviteID = Convert.ToInt32(((DataRowView)gridControl4.MainView.GetRow(gridView4.GetSelectedRows()[0])).Row.ItemArray[0]);
                    Aktiviteler aktivite = Aktiviteler.GetObject(AktiviteID);

                    aktivite.DoReddet();

                    MesajAt(aktivite, 5);

                    GetAktiviteler();
                }
            }
        }

        private void MesajAt(Aktiviteler aktivite, int Durum)
        {
            if (Durum == 1)
            {
                GonderilenMesajlar gm = new GonderilenMesajlar(aktivite.intMusteriID, 10,
                    "Onaylanan aktivite: " + aktivite.pkID.ToString(),
                    aktivite.pkID.ToString() + " nolu aktivite onaylanmıştır. Onaylanan aktivitenin içeriği güncellenmiş olabilir, aktiviteyi görmek için Aktiviteler ekranına bakabilirsiniz.",
                    DateTime.Now, DateTime.MinValue, false, false, false);
                gm.DoInsert();
            }
            else if (Durum == 2)
            {
                GonderilenMesajlar gm = new GonderilenMesajlar(aktivite.intMusteriID, 10,
                    "Geri gönderilen aktivite: " + aktivite.pkID.ToString(),
                    aktivite.pkID.ToString() + " nolu aktivite onay talepten geri gönderilmiştir. Geri gönderilen aktiviteyi Aktiviteler ekranında görebilirsiniz.",
                    DateTime.Now, DateTime.MinValue, false, false, false);
                gm.DoInsert();
            }
            else if (Durum == 3)
            {
                GonderilenMesajlar gm = new GonderilenMesajlar(aktivite.intMusteriID, 10,
                    "Düzeltilen aktivite: " + aktivite.pkID.ToString(),
                    aktivite.pkID.ToString() + " nolu aktivite güncellenmiştir. Düzenlenen halini görmek için Aktiviteler ekranına bakabilirsiniz.",
                    DateTime.Now, DateTime.MinValue, false, false, false);
                gm.DoInsert();
            }
            else if (Durum == 4)
            {
                GonderilenMesajlar gm = new GonderilenMesajlar(aktivite.intMusteriID, 10,
                    "Silinen aktivite: " + aktivite.pkID.ToString(),
                    aktivite.pkID.ToString() + " nolu aktivite silinmiştir.",
                    DateTime.Now, DateTime.MinValue, false, false, false);
                gm.DoInsert();
            }
            else if (Durum == 5)
            {
                GonderilenMesajlar gm = new GonderilenMesajlar(aktivite.intMusteriID, 10,
                    "Onaydan geri alınan aktivite: " + aktivite.pkID.ToString(),
                    aktivite.pkID.ToString() + " nolu aktivite onaydan geri alınmıştır.",
                    DateTime.Now, DateTime.MinValue, false, false, false);
                gm.DoInsert();
            }
        }

        private void txtTAHHedefCiro_TextChanged(object sender, EventArgs e)
        {
            try { Convert.ToDecimal(((TextBox)sender).Text); }
            catch (Exception) { ((TextBox)sender).Text = "0,00"; }
        }

        private void txtAktiviteKarZararYuzde_TextChanged(object sender, EventArgs e)
        {
            try { Convert.ToDouble(((TextBox)sender).Text); }
            catch (Exception) { ((TextBox)sender).Text = "0,0"; }
        }

        bool girdi = false;

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            //if (e.Column.Name == "gridColumn29")
            //{
            //    Urunler.GetProducts(repositoryItemComboBox1.Items, e.Value.ToString(), ((FiyatTipleri)cmbFiyatTipleri.SelectedItem).NOSU); //Convert.ToInt16(((DataRowView)gridControl4.MainView.GetRow(gridView4.GetSelectedRows()[0])).Row.ItemArray[6])
            //}
            
            int KoliAdedi = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], "intKoliAdet"));
            decimal Fiyat = Convert.ToDecimal(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], "mnBirimFiyatKDVli"));

            int satishedefi = gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], "strSatisHedefi").ToString() != string.Empty ? Convert.ToInt32(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], "strSatisHedefi")) : 0;
            decimal aksiyon = gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], "mnAksiyonFiyati").ToString() != string.Empty ? Convert.ToDecimal(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], "mnAksiyonFiyati")) : 0;

            double FatAltIsk = Convert.ToDouble(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], "strAciklama1"));
            double FatAltCiro = Convert.ToDouble(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], "strAciklama2"));
            double PazIsk = Convert.ToDouble(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], "strAciklama3"));
            double CiroPrimDonusYuzde = Convert.ToDouble(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], "flCiroPrimDonusYuzde"));

            double para1 = Convert.ToDouble(Fiyat) - ((Convert.ToDouble(Fiyat) / 100) * FatAltIsk);
            double para2 = para1 - ((para1 / 100) * FatAltCiro);
            double para3 = para2 - ((para2 / 100) * PazIsk);

            double ekisk = 0;
            double DusulmusBirimFiyatKDVli = 0;
            double tutar = 0;

            if (e.Column.Name == "gridColumn36") // ek isk
            {
                ekisk = gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], "flEkIsk").ToString() != string.Empty ? Convert.ToDouble(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], "flEkIsk")) : 0;
                DusulmusBirimFiyatKDVli = para3 - ((para3 / 100) * ekisk);
                tutar = Convert.ToDouble(DusulmusBirimFiyatKDVli) - ((Convert.ToDouble(DusulmusBirimFiyatKDVli) / 100) * CiroPrimDonusYuzde);
            }
            else if (e.Column.Name == "gridColumn39") // düşülmüş kdvli
            {
                DusulmusBirimFiyatKDVli = gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], "mnDusulmusBirimFiyatKDVli").ToString() != string.Empty ? Convert.ToDouble(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], "mnDusulmusBirimFiyatKDVli")) : 0;
                ekisk = para3 != 0 ? (100 * (para3 - DusulmusBirimFiyatKDVli) / para3) : 0;
                tutar = Convert.ToDouble(DusulmusBirimFiyatKDVli) - ((Convert.ToDouble(DusulmusBirimFiyatKDVli) / 100) * CiroPrimDonusYuzde);
            }
            else if (e.Column.Name == "gridColumn35") // ciro primi düşülmüş kdvli
            {
                tutar = gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], "mnTutar").ToString() != string.Empty ? Convert.ToDouble(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], "mnTutar")) : 0;
                DusulmusBirimFiyatKDVli = (tutar * 100) / (100 - CiroPrimDonusYuzde);
                ekisk = para3 != 0 ? (100 * (para3 - DusulmusBirimFiyatKDVli) / para3) : 0;
            }
            else // satış hedefi veya başka birşey değişirse ekisk dan gitsin
            {
                ekisk = gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], "flEkIsk").ToString() != string.Empty ? Convert.ToDouble(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], "flEkIsk")) : 0;
                DusulmusBirimFiyatKDVli = para3 - ((para3 / 100) * ekisk);
                tutar = Convert.ToDouble(DusulmusBirimFiyatKDVli) - ((Convert.ToDouble(DusulmusBirimFiyatKDVli) / 100) * CiroPrimDonusYuzde);
            }

            double DusulmusBirimFiyatKDVsiz = DusulmusBirimFiyatKDVli / ((100 + Urunler.GetProductKDV(Convert.ToInt32(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], "intUrunID")))) / 100);



            int urunid = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], "intUrunID"));
            double ciro = Urunler.GetProductGRPKOD(urunid) == "STG-1" ? Convert.ToDouble(txtTAHHedefCiro.Text) : Convert.ToDouble(txtYEGHedefCiro.Text);
            double bedel = Urunler.GetProductGRPKOD(urunid) == "STG-1" ? Convert.ToDouble(txtTAHSabitBedel.Text) : Convert.ToDouble(txtYEGSabitBedel.Text);

            double maliyet = 100 *
                (
                (ciro != 0 ? bedel / ciro : 0) +
                (Convert.ToDouble(Fiyat) != 0 ? 1 - tutar / Convert.ToDouble(Fiyat) : 0)
                );

            if (!girdi)
            {
                girdi = true;
                gridView1.SetRowCellValue(gridView1.GetSelectedRows()[0], "flEkIsk", Convert.ToDouble(ekisk.ToString("N4")));
                gridView1.SetRowCellValue(gridView1.GetSelectedRows()[0], "mnDusulmusBirimFiyatKDVli", Convert.ToDouble(DusulmusBirimFiyatKDVli.ToString("N4")));
                gridView1.SetRowCellValue(gridView1.GetSelectedRows()[0], "mnDusulmusBirimFiyatKDVsiz", DusulmusBirimFiyatKDVsiz);
                gridView1.SetRowCellValue(gridView1.GetSelectedRows()[0], "mnTutar", tutar);
                gridView1.SetRowCellValue(gridView1.GetSelectedRows()[0], "mnToplam", DusulmusBirimFiyatKDVli * satishedefi * KoliAdedi);
                gridView1.SetRowCellValue(gridView1.GetSelectedRows()[0], "Maliyet", maliyet);

                girdi = false;
            }
        }

        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (MessageBox.Show("Ürünü silmek istediğinize emin misiniz?", "Ürün Silme", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    AktivitelerDetay aktivitedetay = AktivitelerDetay.GetObject(Convert.ToInt64(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], "pkID")));
                    aktivitedetay.DoDelete();

                    gridView1.DeleteRow(gridView1.GetSelectedRows()[0]);
                }
            }
        }

        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e) // getselectedrows()[0] bir sonraki row u alıyor
        {

        }

        private void gridView1_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            ////if (e.Column.Name == "gridColumn29" && e.Value.ToString() == " ")
            ////{
            ////    Urunler.GetProducts(repositoryItemComboBox1.Items, "", Convert.ToInt16(((DataRowView)gridControl4.MainView.GetRow(gridView4.GetSelectedRows()[0])).Row.ItemArray[6]));
            ////}
        }

        private void gridView4_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                int AktiviteID = Convert.ToInt32(((DataRowView)gridControl4.MainView.GetRow(gridView4.GetSelectedRows()[0])).Row.ItemArray[0]);
                AktiviteGetir();
            }
            catch (Exception)
            {
                Temizle();
            }
        }

        private void sbYazdir_Click(object sender, EventArgs e)
        {
            gridControl1.PrintDialog();
        }

        private void sbExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel dosyaları (*.xlsx)|*.xlsx;|Bütün Dosyalar|*.*";
            if (sfd.ShowDialog() == DialogResult.OK)
                gridControl1.ExportToXlsx(sfd.FileName, new DevExpress.XtraPrinting.XlsxExportOptions(DevExpress.XtraPrinting.TextExportMode.Text, true)); //ExportToExcelAktivite(Convert.ToInt32(((DataRowView)gridControl4.MainView.GetRow(gridView4.GetSelectedRows()[0])).Row.ItemArray[0]), sfd.FileName);
        }



        private void ExportToExcelAktivite(int AktiviteID, string DosyaYeri)
        {
            Aktiviteler akt = Aktiviteler.GetObject(AktiviteID);
            string bayi = string.Empty;
            string carihesap = string.Empty;
            if (akt.sintFiyatTipiID == 25)
            {
                bayi = CariHesaplarTP.GetObject(akt.SMREF, true).MUSTERI;
                carihesap = CariHesaplarTP.GetObject(akt.SMREF, false).SUBE;
            }
            else
            {
                bayi = "SULTANLAR PAZARLAMA A.Ş.";
                carihesap = CariHesaplar.GetMUSTERIbySMREFmusterisube(akt.SMREF);
            }
            string fiyattip = FiyatTipleri.GetObjectByID(akt.sintFiyatTipiID);
            string siparistarihi = akt.dtOlusmaTarihi.ToString();
            string siparisonaytarihi = "";
            if (akt.blAktarilmis)
                siparisonaytarihi = akt.dtOlusmaTarihi.ToString();
            string aktivitebaslangic = akt.dtAktiviteBaslangic.ToShortDateString();
            string aktivitebitis = akt.dtAktiviteBitis.ToShortDateString();
            Musteriler musteri = Musteriler.GetMusteriByID(akt.intMusteriID);
            string musteriadsoyad = musteri.strAd + " " + musteri.strSoyad;
            string Aciklama = akt.strAciklama1 + " - " + akt.strAciklama2 + " - " + akt.strAciklama3;

            DataTable dt = new DataTable();
            AktivitelerDetay.GetObjectsByAktiviteID(dt, AktiviteID);



            //string DosyaAdi = "Aktivite-" + akt.pkID.ToString() + ".XLS";
            System.IO.StreamWriter excelDoc = default(System.IO.StreamWriter);
            excelDoc = new System.IO.StreamWriter(DosyaYeri);

            #region ExcelXMLbasi
            System.Text.StringBuilder ExcelXMLbasi = new System.Text.StringBuilder();
            ExcelXMLbasi.AppendLine("<?xml version=\"1.0\"?>");
            ExcelXMLbasi.AppendLine("<?mso-application progid=\"Excel.Sheet\"?>");
            ExcelXMLbasi.AppendLine("<Workbook xmlns=\"urn:schemas-microsoft-com:office:spreadsheet\"");
            ExcelXMLbasi.AppendLine(" xmlns:o=\"urn:schemas-microsoft-com:office:office\"");
            ExcelXMLbasi.AppendLine(" xmlns:x=\"urn:schemas- microsoft-com:office:excel\"");
            ExcelXMLbasi.AppendLine(" xmlns:ss=\"urn:schemas-microsoft-com:office:spreadsheet\">");
            ExcelXMLbasi.AppendLine(" <Styles>");
            ExcelXMLbasi.AppendLine(" <Style ss:ID=\"Default\" ss:Name=\"Normal\">");
            ExcelXMLbasi.AppendLine(" <Alignment ss:Vertical=\"Bottom\"/>");
            ExcelXMLbasi.AppendLine(" <Borders/>");
            ExcelXMLbasi.AppendLine(" <Font/>");
            ExcelXMLbasi.AppendLine(" <Interior/>");
            ExcelXMLbasi.AppendLine(" <NumberFormat/>");
            ExcelXMLbasi.AppendLine(" <Protection/>");
            ExcelXMLbasi.AppendLine(" </Style>");
            ExcelXMLbasi.AppendLine(" <Style ss:ID=\"KalinBaslik\">");
            ExcelXMLbasi.AppendLine(" <Font x:Family=\"Swiss\" ss:Bold=\"1\"/>");
            ExcelXMLbasi.AppendLine(" </Style>");
            ExcelXMLbasi.AppendLine(" <Style ss:ID=\"StringLiteral\">");
            ExcelXMLbasi.AppendLine(" <NumberFormat ss:Format=\"@\"/>");
            ExcelXMLbasi.AppendLine(" </Style>");
            ExcelXMLbasi.AppendLine(" <Style ss:ID=\"Decimal\">");
            ExcelXMLbasi.AppendLine(" <NumberFormat ss:Format=\"0\"/>");
            ExcelXMLbasi.AppendLine(" </Style>");
            ExcelXMLbasi.AppendLine(" <Style ss:ID=\"Integer\">");
            ExcelXMLbasi.AppendLine(" <NumberFormat ss:Format=\"0\"/>");
            ExcelXMLbasi.AppendLine(" <Alignment ss:Horizontal=\"Center\" ss:Vertical=\"Bottom\"/>");
            ExcelXMLbasi.AppendLine(" </Style>");
            ExcelXMLbasi.AppendLine(" <Style ss:ID=\"Currency\">");
            ExcelXMLbasi.AppendLine(" <NumberFormat ss:Format=\"0.00 TL\"/>");
            ExcelXMLbasi.AppendLine(" <Alignment ss:Horizontal=\"Right\" ss:Vertical=\"Bottom\"/>");
            ExcelXMLbasi.AppendLine(" </Style>");
            ExcelXMLbasi.AppendLine(" <Style ss:ID=\"DateLiteral\">");
            ExcelXMLbasi.AppendLine(" <NumberFormat ss:Format=\"dd.mm.yyyy;@\"/>");
            ExcelXMLbasi.AppendLine(" </Style>");
            ExcelXMLbasi.AppendLine(" </Styles>");
            excelDoc.Write(ExcelXMLbasi.ToString());
            #endregion

            excelDoc.Write(" <Worksheet ss:Name=\"Aktivite\">");
            excelDoc.Write("<Table>" +
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"130.00\"/>" +
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"220.00\"/>" +
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"60.00\"/>" +
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"60.00\"/>" +
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"60.00\"/>" +
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"60.00\"/>" +
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"60.00\"/>" +
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"80.00\"/>" +
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"80.00\"/>" +
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"70.00\"/>" +
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"60.00\"/>" +
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"100.00\"/>" +
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"100.00\"/>" +
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"100.00\"/>" +
                "<Column ss:AutoFitWidth=\"0\" ss:Width=\"100.00\"/>");


            excelDoc.Write("<Row>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Aktiviteyi Giren:</Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\">" + musteriadsoyad + "</Data></Cell>");
            excelDoc.Write("</Row>");
            excelDoc.Write("<Row>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Bayi:</Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\">" + bayi + "</Data></Cell>");
            excelDoc.Write("</Row>");
            excelDoc.Write("<Row>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Nokta:</Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\">" + carihesap + "</Data></Cell>");
            excelDoc.Write("</Row>");
            //excelDoc.Write("<Row>");
            //excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Fiyat Tipi:</Data></Cell>");
            //excelDoc.Write("<Cell><Data ss:Type=\"String\">" + fiyattip + "</Data></Cell>");
            //excelDoc.Write("</Row>");
            excelDoc.Write("<Row>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Aktivite Oluşturma Tarihi:</Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\">" + siparistarihi + "</Data></Cell>");
            excelDoc.Write("</Row>");
            excelDoc.Write("<Row>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Aktivite Onay Tarihi:</Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\">" + siparisonaytarihi + "</Data></Cell>");
            excelDoc.Write("</Row>");
            excelDoc.Write("<Row>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Aktivite Başlangıç Tarihi:</Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\">" + aktivitebaslangic + "</Data></Cell>");
            excelDoc.Write("</Row>");
            excelDoc.Write("<Row>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Aktivite Bitiş Tarihi:</Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\">" + aktivitebitis + "</Data></Cell>");
            excelDoc.Write("</Row>");
            excelDoc.Write("<Row>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Açıklama:</Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\">" + Aciklama + "</Data></Cell>");
            excelDoc.Write("</Row>");

            excelDoc.Write("<Row>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\"></Data></Cell>");
            excelDoc.Write("</Row>");

            excelDoc.Write("<Row>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Ürt.Kod</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Ürün</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Koli İçi</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">F.Alt.İsk.</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">F.Alt.Ciro</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Paz.İsk.</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Ciro P.Dön.Y.</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Birim Fiyat</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Ön.Aks.Fiyatı</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Sat.Hed.Koli</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Ek İsk.</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">C.P.D.KDV D.B.F.</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Fat.Bas.Bir.F.KDV'siz</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Fat.Bas.Bir.F.KDV'li</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Toplam</Data></Cell>");
            excelDoc.Write("</Row>");

            double toplamtutar = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                toplamtutar += Convert.ToDouble(dt.Rows[i]["mnDusulmusBirimFiyatKDVli"]) * Convert.ToInt32(dt.Rows[i]["strSatisHedefi"]) * Convert.ToInt32(dt.Rows[i]["intKoliAdet"]);
                excelDoc.Write("<Row>");
                excelDoc.Write("<Cell ss:StyleID=\"Integer\"><Data ss:Type=\"Number\">" + dt.Rows[i]["URTKOD"].ToString() + "</Data></Cell>");
                excelDoc.Write("<Cell><Data ss:Type=\"String\">" + dt.Rows[i]["strUrunAdi"].ToString() + "</Data></Cell>");
                excelDoc.Write("<Cell ss:StyleID=\"Integer\"><Data ss:Type=\"Number\">" + dt.Rows[i]["intKoliAdet"].ToString() + "</Data></Cell>");
                excelDoc.Write("<Cell ss:StyleID=\"Integer\"><Data ss:Type=\"Number\">" + Convert.ToDouble(dt.Rows[i]["strAciklama1"]).ToString("N1").Replace(".", "").Replace(",", ".") + "</Data></Cell>");
                excelDoc.Write("<Cell ss:StyleID=\"Integer\"><Data ss:Type=\"Number\">" + Convert.ToDouble(dt.Rows[i]["strAciklama2"]).ToString("N1").Replace(".", "").Replace(",", ".") + "</Data></Cell>");
                excelDoc.Write("<Cell ss:StyleID=\"Integer\"><Data ss:Type=\"Number\">" + Convert.ToDouble(dt.Rows[i]["strAciklama3"]).ToString("N1").Replace(".", "").Replace(",", ".") + "</Data></Cell>");
                excelDoc.Write("<Cell ss:StyleID=\"Integer\"><Data ss:Type=\"Number\">" + Convert.ToDouble(dt.Rows[i]["flCiroPrimDonusYuzde"]).ToString("N1").Replace(".", "").Replace(",", ".") + "</Data></Cell>");
                excelDoc.Write("<Cell ss:StyleID=\"Currency\"><Data ss:Type=\"Number\">" + Convert.ToDouble(dt.Rows[i]["mnBirimFiyatKDVli"]).ToString("N2").Replace(".", "").Replace(",", ".") + "</Data></Cell>");
                excelDoc.Write("<Cell ss:StyleID=\"Currency\"><Data ss:Type=\"Number\">" + Convert.ToDouble(dt.Rows[i]["mnAksiyonFiyati"]).ToString("N2").Replace(".", "").Replace(",", ".") + "</Data></Cell>");
                excelDoc.Write("<Cell><Data ss:Type=\"String\">" + dt.Rows[i]["strSatisHedefi"].ToString() + "</Data></Cell>");
                excelDoc.Write("<Cell ss:StyleID=\"Integer\"><Data ss:Type=\"Number\">" + Convert.ToDouble(dt.Rows[i]["flEkIsk"]).ToString("N1").Replace(".", "").Replace(",", ".") + "</Data></Cell>");
                excelDoc.Write("<Cell ss:StyleID=\"Currency\"><Data ss:Type=\"Number\">" + Convert.ToDouble(dt.Rows[i]["mnTutar"]).ToString("N2").Replace(".", "").Replace(",", ".") + "</Data></Cell>");
                excelDoc.Write("<Cell ss:StyleID=\"Currency\"><Data ss:Type=\"Number\">" + Convert.ToDouble(dt.Rows[i]["mnDusulmusBirimFiyatKDVsiz"]).ToString("N2").Replace(".", "").Replace(",", ".") + "</Data></Cell>");
                excelDoc.Write("<Cell ss:StyleID=\"Currency\"><Data ss:Type=\"Number\">" + Convert.ToDouble(dt.Rows[i]["mnDusulmusBirimFiyatKDVli"]).ToString("N2").Replace(".", "").Replace(",", ".") + "</Data></Cell>");
                excelDoc.Write("<Cell ss:StyleID=\"Currency\"><Data ss:Type=\"Number\">" + (Convert.ToDouble(dt.Rows[i]["mnDusulmusBirimFiyatKDVli"]) * Convert.ToInt32(dt.Rows[i]["strSatisHedefi"]) * Convert.ToInt32(dt.Rows[i]["intKoliAdet"])).ToString("N2").Replace(".", "").Replace(",", ".") + "</Data></Cell>");
                excelDoc.Write("</Row>");
            }

            excelDoc.Write("<Row>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\"></Data></Cell>");
            excelDoc.Write("</Row>");
            excelDoc.Write("<Row>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\"></Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\"></Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\"></Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\"></Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\"></Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\"></Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\"></Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\"></Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\"></Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\"></Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\"></Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\"></Data></Cell>");
            excelDoc.Write("<Cell><Data ss:Type=\"String\"></Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"KalinBaslik\"><Data ss:Type=\"String\">Genel Toplam:</Data></Cell>");
            excelDoc.Write("<Cell ss:StyleID=\"Currency\"><Data ss:Type=\"Number\">" + toplamtutar.ToString().Replace(".", "").Replace(",", ".") + "</Data></Cell>");
            excelDoc.Write("</Row>");


            excelDoc.Write("</Table>");
            excelDoc.Write("</Worksheet>");
            excelDoc.Write("</Workbook>");
            excelDoc.Flush();
            excelDoc.Close();
        }

        private void sbExcel2_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel dosyaları (*.xls, *.xlsx)|*.xls;*.xlsx;|Bütün Dosyalar|*.*";
            if (sfd.ShowDialog() == DialogResult.OK)
                gridControl4.ExportToXls(sfd.FileName);
        }

        private void gridView4_ColumnFilterChanged(object sender, EventArgs e)
        {
            lblSatirSayisi.Text = gridView4.RowCount.ToString();
        }

        private void gridView1_ColumnFilterChanged(object sender, EventArgs e)
        {
            lblSatirSayisi2.Text = gridView1.RowCount.ToString();
        }

        private void btnFiyatExcel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Excel dosyasında kolonlar şu sıra ile olmalı:\r\nÜrün Kodu, Fiyat, Yıl, Ay, Müdür Kodu", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);

            string dosya = "";
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Excel dosyaları (*.xls, *.xlsx)|*.xls;*.xlsx;|Bütün Dosyalar|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
                dosya = ofd.FileName;
            else
                return;

            Microsoft.Office.Interop.Excel.Application ap = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook wb = null;
            Microsoft.Office.Interop.Excel.Worksheet ws = null;
            Microsoft.Office.Interop.Excel.Range range = null;

            object[,] values = null;

            try
            {
                wb = ap.Workbooks.Open(dosya, false, true,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing, true);

                ws = (Microsoft.Office.Interop.Excel.Worksheet)wb.Worksheets[1];

                range = ws.get_Range("A1", "E6666");

                values = (object[,])range.Value2;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                range = null;
                ws = null;
                if (wb != null)
                    wb.Close(false, System.Reflection.Missing.Value, System.Reflection.Missing.Value);
                wb = null;
                if (ap != null)
                    ap.Quit();
                ap = null;
            }

            ArrayList kodlar = new ArrayList();
            ArrayList fiyatlar = new ArrayList();
            ArrayList yillar = new ArrayList();
            ArrayList aylar = new ArrayList();
            ArrayList mudurler = new ArrayList();
            for (int i = 2; i <= values.GetLength(0); i++)
            {
                if (values[i, 1] == null) // 1.kolon boş ise bu satırdan sonrasına bakmasın
                    break;

                try
                {
                    if (Urunler.GetProductName(Convert.ToInt32(values[i, 1])) == string.Empty)
                    {
                        MessageBox.Show(i.ToString() + ". satırda ürün kodu yanlış. Düzeltip tekrar deneyin", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        kodlar.Clear();
                        fiyatlar.Clear();
                        yillar.Clear();
                        aylar.Clear();
                        mudurler.Clear();
                        return;
                    }

                    kodlar.Add(Convert.ToInt32(values[i, 1]));
                    fiyatlar.Add(Convert.ToDouble(values[i, 2]));
                    yillar.Add(Convert.ToInt32(values[i, 3]));
                    aylar.Add(Convert.ToInt32(values[i, 4]));
                    mudurler.Add(Convert.ToInt32(values[i, 5]));
                }
                catch (Exception ex)
                {
                    kodlar.Clear();
                    fiyatlar.Clear();
                    yillar.Clear();
                    aylar.Clear();
                    mudurler.Clear();
                    MessageBox.Show(ex.Message);
                    return;
                }
            }

            for (int i = 0; i < kodlar.Count; i++)
                Aktiviteler.FiyatKontrolEkle(Convert.ToInt32(kodlar[i]), Convert.ToDouble(fiyatlar[i]), Convert.ToInt32(yillar[i]), Convert.ToInt32(aylar[i]), Convert.ToInt32(mudurler[i]));

            MessageBox.Show("Aktarım tamamlandı.", "Başarılı");
        }
    }
}

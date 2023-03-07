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
    public partial class frmINTERNETticaripazarlamaaktiviteekle : Form
    {
        public frmINTERNETticaripazarlamaaktiviteekle()
        {
            InitializeComponent();
        }

        //int AktiviteID;
        DataTable dt;

        private void frmINTERNETticaripazarlamaaktiviteekle_Load(object sender, EventArgs e)
        {
            CariHesaplarTP.GetObjects(listBox1.Items, 0);
            GetFiyatTipleri();
            GetAktiviteTipleri();

            dt = new DataTable();
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("intAktiviteID", typeof(int));
            dt.Columns.Add("intUrunID", typeof(int));
            dt.Columns.Add("URTKOD", typeof(string));
            dt.Columns.Add("strUrunAdi", typeof(string));
            dt.Columns.Add("intKoliAdet", typeof(int));
            dt.Columns.Add("mnBirimFiyatKDVli", typeof(decimal));
            dt.Columns.Add("mnAksiyonFiyati", typeof(decimal));
            dt.Columns.Add("flMusteriKarYuzde", typeof(double));
            dt.Columns.Add("strSatisHedefi", typeof(string));
            dt.Columns.Add("strAciklama1", typeof(double));
            dt.Columns.Add("strAciklama2", typeof(double));
            dt.Columns.Add("strAciklama3", typeof(double));
            dt.Columns.Add("flEkIsk", typeof(double));
            dt.Columns.Add("flCiroPrimDonusYuzde", typeof(double));
            dt.Columns.Add("mnBayiMaliyet", typeof(decimal));
            dt.Columns.Add("mnDusulmusBirimFiyatKDVli", typeof(decimal));
            dt.Columns.Add("mnTutar", typeof(decimal));
            dt.Columns.Add("flKarZararYuzde", typeof(double));
            dt.Columns.Add("mnToplam", typeof(decimal));
            dt.Columns.Add("strAciklama4", typeof(string));
        }

        private void GetFiyatTipleri()
        {
            FiyatTipleri.GetObjectAciklamali(cmbFiyatTipleri.Items, true);
            cmbFiyatTipleri.SelectedIndex = 21;
        }

        private void GetAktiviteTipleri()
        {
            AktiviteTipleri.GetObjects(cmbAktiviteTipleri.Items, true);
            cmbAktiviteTipleri.SelectedIndex = 0;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex > -1)
            {
                radioButton1.Checked = false;
                CariHesaplarTP.GetObjects(listBox2.Items, ((CariHesaplarTP)listBox1.SelectedItem).GMREF);
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                listBox1.SelectedIndex = -1;
                CariHesaplar.GetObjectsLikeTP(listBox2.Items);
            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Anlasmalar.GetObjects(cmbAnlasmalar.Items, ((CariHesaplarTP)listBox2.SelectedItem).SMREF);

            cmbAnlasmalar.Items.Clear();
            Anlasmalar anlasma = Anlasmalar.GetObject(Anlasmalar.GetSonAnlasmaID(((CariHesaplarTP)listBox2.SelectedItem).SMREF, DateTime.Now, (radioButton1.Checked ? "2" : "1")));
            
            if (anlasma != null)
                cmbAnlasmalar.Items.Add(anlasma);

            ArrayList silinecekler = new ArrayList();
            for (int i = 0; i < cmbAnlasmalar.Items.Count; i++)
                if (((Anlasmalar)cmbAnlasmalar.Items[i]).intOnay == 0)
                    silinecekler.Add(cmbAnlasmalar.Items[i]);
            for (int i = 0; i < silinecekler.Count; i++)
                cmbAnlasmalar.Items.Remove((Anlasmalar)silinecekler[i]);
            if (cmbAnlasmalar.Items.Count > 0)
            {
                cmbAnlasmalar.SelectedIndex = 0;
            }
            else
            {
                Temizle();
            }
        }

        private void Temizle()
        {
            //cmbFiyatTipleri.SelectedIndex = 0;
            //cmbAktiviteTipleri.SelectedIndex = 0;

            cmbAnlasmalar.Items.Clear();

            dtpBaslangic.Value = DateTime.Now;
            dtpBitis.Value = DateTime.Now;
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
        }

        private void cmbAnlasmalar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbAnlasmalar.SelectedIndex > -1)
            {
                Anlasmalar anlasma = (Anlasmalar)cmbAnlasmalar.SelectedItem;
                txtTAHHedefCiro.Text = anlasma.mnTAHToplamCiro.ToString("N2").Replace(".", "");
                txtYEGHedefCiro.Text = anlasma.mnYEGToplamCiro.ToString("N2").Replace(".", "");
                txtTAHSabitBedel.Text = anlasma.TAHTumBedellerToplami.ToString("N2").Replace(".", "");
                txtYEGSabitBedel.Text = anlasma.YEGTumBedellerToplami.ToString("N2").Replace(".", "");

                txtTAHHedefCiro.ReadOnly = true;
                txtYEGHedefCiro.ReadOnly = true;
                txtTAHSabitBedel.ReadOnly = true;
                txtYEGSabitBedel.ReadOnly = true;
            }
            else
            {
                txtTAHHedefCiro.ReadOnly = false;
                txtYEGHedefCiro.ReadOnly = false;
                txtTAHSabitBedel.ReadOnly = false;
                txtYEGSabitBedel.ReadOnly = false;
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Yeni aktivite eklenecek, devam etmek istediğinize emin misiniz?", "Ekleme", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    Aktiviteler aktivite = new Aktiviteler();

                    aktivite.SMREF = ((CariHesaplarTP)listBox2.SelectedItem).SMREF;
                    aktivite.blAktarilmis = false;
                    aktivite.dtAktiviteBaslangic = dtpBaslangic.Value;
                    aktivite.dtAktiviteBitis = dtpBitis.Value;
                    aktivite.dtOlusmaTarihi = DateTime.Now;
                    aktivite.dtOnaylamaTarihi = DateTime.Now;
                    aktivite.intAktiviteTipiID = ((AktiviteTipleri)cmbAktiviteTipleri.SelectedItem).pkID;
                    aktivite.intAnlasmaID = cmbAnlasmalar.SelectedIndex > -1 ? ((Anlasmalar)cmbAnlasmalar.SelectedItem).pkID : 0;
                    aktivite.intMusteriID = 1;
                    aktivite.mnAktiviteKarZarar = Convert.ToDecimal(txtAktiviteKarZarar.Text.Replace(".", ""));
                    aktivite.flAktiviteKarZararYuzde = Convert.ToDouble(txtAktiviteKarZararYuzde.Text);
                    aktivite.mnTahHedefCiro = Convert.ToDecimal(txtTAHHedefCiro.Text.Replace(".", ""));
                    aktivite.mnTahSabitBedel = Convert.ToDecimal(txtTAHSabitBedel.Text.Replace(".", ""));
                    aktivite.mnYegHedefCiro = Convert.ToDecimal(txtYEGHedefCiro.Text.Replace(".", ""));
                    aktivite.mnYegSabitBedel = Convert.ToDecimal(txtYEGSabitBedel.Text.Replace(".", ""));
                    aktivite.sintFiyatTipiID = ((FiyatTipleri)cmbFiyatTipleri.SelectedItem).NOSU;
                    aktivite.strAciklama1 = txtAciklama1.Text.Trim();
                    aktivite.strAciklama2 = txtAciklama2.Text.Trim();
                    aktivite.strAciklama3 = txtAciklama3.Text.Trim();
                    aktivite.strAciklama4 = string.Empty;

                    aktivite.DoInsert();

                    for (int j = 0; j < gridView1.RowCount; j++)
                    {
                        AktivitelerDetay aktivitelerdetay = new AktivitelerDetay
                        (
                            aktivite.pkID,
                            Convert.ToInt32(gridView1.GetRowCellValue(j, "intUrunID")),
                            gridView1.GetRowCellValue(j, "strUrunAdi").ToString(),
                            Convert.ToInt32(gridView1.GetRowCellValue(j, "intKoliAdet")),
                            Convert.ToDecimal(gridView1.GetRowCellValue(j, "mnBirimFiyatKDVli")),
                            Convert.ToDecimal(gridView1.GetRowCellValue(j, "mnAksiyonFiyati")),
                            Convert.ToDouble(gridView1.GetRowCellValue(j, "flMusteriKarYuzde")),
                            gridView1.GetRowCellValue(j, "strSatisHedefi").ToString(),
                            Convert.ToDecimal(gridView1.GetRowCellValue(j, "mnTutar")),
                            Convert.ToDouble(gridView1.GetRowCellValue(j, "flEkIsk")),
                            Convert.ToDouble(gridView1.GetRowCellValue(j, "flCiroPrimDonusYuzde")),
                            Convert.ToDecimal(gridView1.GetRowCellValue(j, "mnBayiMaliyet")),
                            Convert.ToDecimal(gridView1.GetRowCellValue(j, "mnDusulmusBirimFiyatKDVli")),
                            Convert.ToDouble(gridView1.GetRowCellValue(j, "flKarZararYuzde")),
                            Convert.ToDecimal(gridView1.GetRowCellValue(j, "mnToplam")),
                            gridView1.GetRowCellValue(j, "strAciklama1").ToString(),
                            gridView1.GetRowCellValue(j, "strAciklama2").ToString(),
                            gridView1.GetRowCellValue(j, "strAciklama3").ToString(),
                            gridView1.GetRowCellValue(j, "strAciklama4").ToString(),
                            gridView1.GetRowCellValue(j, "strAciklama5").ToString(),
                            ""
                        );
                        aktivitelerdetay.DoInsert();
                    }

                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Seçimlerde eksik seçim var.\r\n\r\nHata ayrıntısı: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void sbUrunEkle_Click(object sender, EventArgs e)
        {
            if (cmbFiyatTipleri.SelectedIndex > -1)
            {
                frmINTERNETticaripazarlamaaktiviteurunekle frm = new frmINTERNETticaripazarlamaaktiviteurunekle(((FiyatTipleri)cmbFiyatTipleri.SelectedItem).NOSU);
                frm.ShowDialog();

                if (frm.UrunID != 0)
                {
                    int UrunID = frm.UrunID;
                    int KoliAdedi = Convert.ToInt32(Urunler.GetKoliAdedi(UrunID));
                    decimal Fiyat = Urunler.GetProductPrice(UrunID, ((FiyatTipleri)cmbFiyatTipleri.SelectedItem).NOSU);

                    DataRow drow = dt.NewRow();



                    double FatAltIsk = 0;
                    int sonanlasmaid = Anlasmalar.GetSonAnlasmaID(((CariHesaplarTP)listBox2.SelectedItem).SMREF, DateTime.Now, ((FiyatTipleri)cmbFiyatTipleri.SelectedItem).NOSU == 25 ? "1" : "2");
                    if (sonanlasmaid != 0)
                    {
                        Anlasmalar anlasma = Anlasmalar.GetObject(sonanlasmaid);
                        if (Urunler.GetProductGRPKOD(UrunID) == "STG-1")
                            FatAltIsk = anlasma.flTAHIsk;
                        else if (Urunler.GetProductGRPKOD(UrunID) == "STG-2")
                            FatAltIsk = anlasma.flYEGIsk;
                    }
                    else
                    {
                        double[] fiyatiskonto = Urunler.GetProductDiscountsAndPrice(UrunID, 25); // anlaşma yoksa 25. fiyat tipindeki 1. iskonto
                        FatAltIsk = fiyatiskonto[0];
                    }



                    double FatAltCiro = 0;
                    if (sonanlasmaid != 0)
                    {
                        Anlasmalar anlasma = Anlasmalar.GetObject(sonanlasmaid);
                        if (Urunler.GetProductGRPKOD(UrunID) == "STG-1")
                            FatAltCiro = anlasma.flTAHCiroIsk;
                        else if (Urunler.GetProductGRPKOD(UrunID) == "STG-2")
                            FatAltCiro = anlasma.flYEGCiroIsk;
                    }



                    double CiroPrimDonusYuzde = 0;
                    if (sonanlasmaid != 0)
                    {
                        Anlasmalar anlasma = Anlasmalar.GetObject(sonanlasmaid);
                        if (Urunler.GetProductGRPKOD(UrunID) == "STG-1")
                            CiroPrimDonusYuzde = anlasma.flTAHCiro + anlasma.flTAHCiro3 + anlasma.flTAHCiro6 + anlasma.flTAHCiro12;
                        else if (Urunler.GetProductGRPKOD(UrunID) == "STG-2")
                            CiroPrimDonusYuzde = anlasma.flYEGCiro + anlasma.flYEGCiro3 + anlasma.flYEGCiro6 + anlasma.flYEGCiro12;
                    }



                    double para1 = Convert.ToDouble(Fiyat) - ((Convert.ToDouble(Fiyat) / 100) * FatAltIsk);
                    double para2 = Convert.ToDouble(para1) - ((Convert.ToDouble(para1) / 100) * FatAltCiro);
                    double para3 = Convert.ToDouble(para2) - ((Convert.ToDouble(para2) / 100) * Urunler.GetProductDiscountsAndPrice(UrunID, 25)[2]);
                    double DusulmusBirimFiyatKDVli = Convert.ToDouble(para3) - ((Convert.ToDouble(para3) / 100) * 0);



                    drow["ID"] = 0;
                    drow["intAktiviteID"] = 0;
                    drow["intUrunID"] = UrunID;
                    drow["URTKOD"] = Urunler.GetProductUrtKod(UrunID);
                    drow["strUrunAdi"] = Urunler.GetProductName(UrunID);
                    drow["intKoliAdet"] = KoliAdedi;
                    drow["mnBirimFiyatKDVli"] = Fiyat;
                    drow["mnAksiyonFiyati"] = Fiyat;
                    drow["flMusteriKarYuzde"] = 0;
                    drow["strSatisHedefi"] = "1";
                    drow["strAciklama1"] = FatAltIsk;
                    drow["strAciklama2"] = FatAltCiro;
                    drow["strAciklama3"] = Urunler.GetProductDiscountsAndPrice(UrunID, 25)[2];
                    drow["flEkIsk"] = 0;
                    drow["flCiroPrimDonusYuzde"] = CiroPrimDonusYuzde;
                    drow["mnBayiMaliyet"] = 0;
                    drow["mnDusulmusBirimFiyatKDVli"] = DusulmusBirimFiyatKDVli;
                    drow["mnTutar"] = Convert.ToDouble(DusulmusBirimFiyatKDVli) - ((Convert.ToDouble(DusulmusBirimFiyatKDVli) / 100) * CiroPrimDonusYuzde);
                    drow["flKarZararYuzde"] = 0;
                    drow["mnToplam"] = KoliAdedi * DusulmusBirimFiyatKDVli;
                    drow["strAciklama4"] = "";

                    dt.Rows.Add(drow);
                    gridControl1.DataSource = dt;
                }
            }
        }

        bool girdi = false;

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            int KoliAdedi = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], "intKoliAdet"));
            decimal Fiyat = Convert.ToDecimal(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], "mnBirimFiyatKDVli"));

            int satishedefi = gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], "strSatisHedefi").ToString() != string.Empty ? Convert.ToInt32(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], "strSatisHedefi")) : 0;
            double ekisk = gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], "flEkIsk").ToString() != string.Empty ? Convert.ToDouble(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], "flEkIsk")) : 0;
            decimal aksiyon = gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], "mnAksiyonFiyati").ToString() != string.Empty ? Convert.ToDecimal(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], "mnAksiyonFiyati")) : 0;

            double FatAltIsk = Convert.ToDouble(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], "strAciklama1"));
            double FatAltCiro = Convert.ToDouble(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], "strAciklama2"));
            double PazIsk = Convert.ToDouble(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], "strAciklama3"));
            double CiroPrimDonusYuzde = Convert.ToDouble(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], "flCiroPrimDonusYuzde"));

            double para1 = Convert.ToDouble(Fiyat) - ((Convert.ToDouble(Fiyat) / 100) * FatAltIsk);
            double para2 = Convert.ToDouble(para1) - ((Convert.ToDouble(para1) / 100) * FatAltCiro);
            double para3 = Convert.ToDouble(para2) - ((Convert.ToDouble(para2) / 100) * PazIsk);
            double DusulmusBirimFiyatKDVli = Convert.ToDouble(para3) - ((Convert.ToDouble(para3) / 100) * ekisk);

            double tutar = Convert.ToDouble(DusulmusBirimFiyatKDVli) - ((Convert.ToDouble(DusulmusBirimFiyatKDVli) / 100) * CiroPrimDonusYuzde);



            //dt.Rows[gridView1.GetSelectedRows()[0]]["mnDusulmusBirimFiyatKDVli"] = DusulmusBirimFiyatKDVli;
            //dt.Rows[gridView1.GetSelectedRows()[0]]["mnTutar"] = tutar;
            //dt.Rows[gridView1.GetSelectedRows()[0]]["mnToplam"] = DusulmusBirimFiyatKDVli * satishedefi * KoliAdedi;
            if (!girdi)
            {
                girdi = true;
                gridView1.SetRowCellValue(gridView1.GetSelectedRows()[0], "mnDusulmusBirimFiyatKDVli", DusulmusBirimFiyatKDVli);
                gridView1.SetRowCellValue(gridView1.GetSelectedRows()[0], "mnTutar", tutar);
                gridView1.SetRowCellValue(gridView1.GetSelectedRows()[0], "mnToplam", DusulmusBirimFiyatKDVli * satishedefi * KoliAdedi);
                girdi = false;
            }

            //gridControl1.DataSource = dt;
        }

        private void frmINTERNETticaripazarlamaaktiviteekle_SizeChanged(object sender, EventArgs e)
        {
            gridControl1.Height = this.Height - 309;
        }
    }
}

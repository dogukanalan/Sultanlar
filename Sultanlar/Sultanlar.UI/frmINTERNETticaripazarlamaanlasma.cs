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
    public partial class frmINTERNETticaripazarlamaanlasma : Form
    {
        public frmINTERNETticaripazarlamaanlasma(int SMREF, bool Yeni)
        {
            InitializeComponent();
            Acilis = true;
            GetAnlasmaBedelAdlari();
            anlasma = new Anlasmalar(SMREF, 0, DateTime.Now, DateTime.Now, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "", "", "", "", 0);
            anlasma.DoInsert();
            this.Text = anlasma.strAciklama2 == "1" ?
                "Ticari Pazarlama : Anlaşma " + anlasma.pkID.ToString() + " (" + CariHesaplarTP.GetObject(anlasma.SMREF, false).SUBE + ")"
                : "Ticari Pazarlama : Anlaşma " + anlasma.pkID.ToString() + " (" + CariHesaplar.GetMUSTERIbyGMREF(anlasma.SMREF) + ")";
        }

        public frmINTERNETticaripazarlamaanlasma(int AnlasmaID)
        {
            InitializeComponent();
            Acilis = true;
            GetAnlasmaBedelAdlari();
            anlasma = Anlasmalar.GetObject(AnlasmaID);
            this.Text = anlasma.strAciklama2 == "1" ?
                "Ticari Pazarlama : Anlaşma " + anlasma.pkID.ToString() + " (" + CariHesaplarTP.GetObject(anlasma.SMREF, false).SUBE + ")"
                : "Ticari Pazarlama : Anlaşma " + anlasma.pkID.ToString() + " (" + CariHesaplar.GetMUSTERIbyGMREF(anlasma.SMREF) + ")";
        }

        public Anlasmalar anlasma;
        bool Acilis;

        private void frmINTERNETticaripazarlamaanlasma_Load(object sender, EventArgs e)
        {
            GetAnlasma();
            Acilis = false;
            txtCari.Focus();
        }

        private void frmINTERNETticaripazarlamaanlasma_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmAna frm1 = (frmAna)this.ParentForm;
            frm1.FormKapanirken(this.Name);

            for (int i = 0; i < this.MdiParent.MdiChildren.Length; i++)
                if (this.MdiParent.MdiChildren[i].Name == "frmINTERNETticaripazarlamaanlasmalar")
                    ((frmINTERNETticaripazarlamaanlasmalar)this.MdiParent.MdiChildren[i]).GetAnlasmalar();
        }

        private void GetAnlasma()
        {
            CariHesaplarTP cari = CariHesaplarTP.GetObject(anlasma.SMREF, false);
            CariHesaplarTP bayi = CariHesaplarTP.GetObject(anlasma.SMREF, true);

            txtCari.Text = anlasma.strAciklama2 == "1" ? cari.SUBE : CariHesaplar.GetMUSTERIbyGMREF(anlasma.SMREF);
            txtIl.Text = anlasma.strAciklama2 == "1" ? cari.IL : "İSTANBUL";
            txtBayi.Text = anlasma.strAciklama2 == "1" ? bayi.MUSTERI : "SULTANLAR PAZARLAMA A.Ş.";

            txtSubeSayisi.Text = anlasma.strAciklama4;
            dtpBaslangic.Value = anlasma.dtBaslangic;
            dtpBitis.Value = anlasma.dtBitis;
            txtVadeTAH.Text = anlasma.intVadeTAH.ToString();
            txtVadeYEG.Text = anlasma.intVadeYEG.ToString();
            txtSKUTAH.Text = anlasma.intListSKUTAH.ToString();
            txtSKUYEG.Text = anlasma.intListSKUYEG.ToString();

            txtTAHIsk.Text = anlasma.flTAHIsk.ToString("N1");
            txtTAHCiro.Text = anlasma.flTAHCiro.ToString("N1");
            txtTAHCiro3.Text = anlasma.flTAHCiro3.ToString("N1");
            txtTAHCiro6.Text = anlasma.flTAHCiro6.ToString("N1");
            txtTAHCiro12.Text = anlasma.flTAHCiro12.ToString("N1");
            txtTAHCiroIsk.Text = anlasma.flTAHCiroIsk.ToString("N1");
            txtYEGIsk.Text = anlasma.flYEGIsk.ToString("N1");
            txtYEGCiro.Text = anlasma.flYEGCiro.ToString("N1");
            txtYEGCiro3.Text = anlasma.flYEGCiro3.ToString("N1");
            txtYEGCiro6.Text = anlasma.flYEGCiro6.ToString("N1");
            txtYEGCiro12.Text = anlasma.flYEGCiro12.ToString("N1");
            txtYEGCiroIsk.Text = anlasma.flYEGCiroIsk.ToString("N1");

            txtTAHAnlasmaDisi.Text = anlasma.mnTAHAnlasmaDisiBedeller.ToString();
            txtYEGAnlasmaDisi.Text = anlasma.mnYEGAnlasmaDisiBedeller.ToString();
            txtTAHTumBedeller.Text = (anlasma.mnTAHAnlasmaDisiBedeller + anlasma.TAHTumBedellerToplami).ToString();
            txtYEGTumBedeller.Text = (anlasma.mnYEGAnlasmaDisiBedeller + anlasma.YEGTumBedellerToplami).ToString();
            txtTAHToplamCiro.Text = anlasma.mnTAHToplamCiro.ToString();
            txtYEGToplamCiro.Text = anlasma.mnYEGToplamCiro.ToString();
            txtTAHToplamMaliyet.Text = anlasma.TAHYilSonuMaliyet.ToString("N1");
            txtYEGToplamMaliyet.Text = anlasma.YEGYilSonuMaliyet.ToString("N1");
            txtTAHCiroDahilMaliyet.Text = anlasma.TAHCiroPrimiDahilNetMaliyet.ToString("N1");
            txtYEGCiroDahilMaliyet.Text = anlasma.YEGCiroPrimiDahilNetMaliyet.ToString("N1");

            txtAciklama.Text = anlasma.strAciklama1;

            GetAnlasmaBedeller();
        }

        private void GetAnlasmaBedeller()
        {
            DataTable dt = new DataTable();
            AnlasmaBedeller.GetObjects(dt, anlasma.pkID);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < clbAnlasmaBedelAdlari.Items.Count; j++)
                {
                    if (dt.Rows[i]["intAnlasmaBedelAdID"].ToString() == ((AnlasmaBedelAdlari)clbAnlasmaBedelAdlari.Items[j]).pkID.ToString())
                    {
                        clbAnlasmaBedelAdlari.SetItemChecked(j, true);
                        break;
                    }
                }
            }
        }

        private void GetAnlasmaBedelAdlari()
        {
            AnlasmaBedelAdlari.GetObjects(clbAnlasmaBedelAdlari.Items, true);
        }

        private AnlasmaBedeller GetAnlasmaBedel(int AnlasmaBedelAdID)
        {
            AnlasmaBedeller donendeger = null;

            DataTable dt = new DataTable();
            AnlasmaBedeller.GetObjects(dt, anlasma.pkID);
            for (int j = 0; j < dt.Rows.Count; j++)
                if (dt.Rows[j]["intAnlasmaBedelAdID"].ToString() == AnlasmaBedelAdID.ToString())
                    donendeger = AnlasmaBedeller.GetObject(Convert.ToInt32(dt.Rows[j]["pkID"]));

            return donendeger;
        }

        private void clbAnlasmaBedelAdlari_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtBedelTAHAdet.Text = 0.ToString();
            txtBedelTAHBedel.Text = 0.ToString();
            //txtBedelTAHIsk.Text = 0.ToString("N1");
            txtBedelYEGAdet.Text = 0.ToString();
            txtBedelYEGBedel.Text = 0.ToString();
            //txtBedelYEGIsk.Text = 0.ToString("N1");

            if (!Acilis)
            {
                if (clbAnlasmaBedelAdlari.GetItemChecked(clbAnlasmaBedelAdlari.SelectedIndex))
                {
                    AnlasmaBedeller ab = GetAnlasmaBedel(((AnlasmaBedelAdlari)clbAnlasmaBedelAdlari.SelectedItem).pkID);
                    txtBedelTAHAdet.Text = ab.intTAHAdet.ToString();
                    txtBedelTAHBedel.Text = ab.mnTAHBedel.ToString();
                    //txtBedelTAHIsk.Text = ab.flTAHIsk.ToString("N1");
                    txtBedelYEGAdet.Text = ab.intYEGAdet.ToString();
                    txtBedelYEGBedel.Text = ab.mnYEGBedel.ToString();
                    //txtBedelYEGIsk.Text = ab.flYEGIsk.ToString("N1");
                }
            }
        }

        bool bedeleklemecikarma = true;

        private void clbAnlasmaBedelAdlari_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (!Acilis)
            {
                if (clbAnlasmaBedelAdlari.GetItemChecked(e.Index))
                {
                        if (MessageBox.Show("Bedel kaldırılacak, devam etmek istediğinize emin misiniz?", "Silme", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                        {
                            AnlasmaBedeller anlasmabedel = GetAnlasmaBedel(((AnlasmaBedelAdlari)clbAnlasmaBedelAdlari.Items[e.Index]).pkID);
                            anlasmabedel.DoDelete();
                        }
                }
                else
                {
                        if (MessageBox.Show("Bedel eklenecek, devam etmek istediğinize emin misiniz?", "Oluşturma", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                        {
                            AnlasmaBedeller anlasmabedel = new AnlasmaBedeller(anlasma.pkID, ((AnlasmaBedelAdlari)clbAnlasmaBedelAdlari.SelectedItem).pkID,
                                0, 0, 0, 0, 0, 0, "", "", "", "");
                            anlasmabedel.DoInsert();
                        }
                }
            }
        }

        private void sbBedelGuncelle_Click(object sender, EventArgs e)
        {
            AnlasmaBedeller anlasmabedel = GetAnlasmaBedel(((AnlasmaBedelAdlari)clbAnlasmaBedelAdlari.SelectedItem).pkID);
            anlasmabedel.intTAHAdet = Convert.ToInt32(txtBedelTAHAdet.Text.Trim());
            anlasmabedel.mnTAHBedel = Convert.ToDecimal(txtBedelTAHBedel.Text.Trim().Replace(".", ""));
            //anlasmabedel.flTAHIsk = Convert.ToDouble(txtBedelTAHIsk.Text.Trim());
            anlasmabedel.intYEGAdet = Convert.ToInt32(txtBedelYEGAdet.Text.Trim());
            anlasmabedel.mnYEGBedel = Convert.ToDecimal(txtBedelYEGBedel.Text.Trim().Replace(".", ""));
            //anlasmabedel.flYEGIsk = Convert.ToDouble(txtBedelYEGIsk.Text.Trim());
            anlasmabedel.DoUpdate();
        }

        private void sbDuzenle_Click(object sender, EventArgs e)
        {
            CariHesaplarTP cari = CariHesaplarTP.GetObject(anlasma.SMREF, false);
            CariHesaplarTP bayi = CariHesaplarTP.GetObject(anlasma.SMREF, true);

            anlasma.strAciklama4 = txtSubeSayisi.Text.Trim();
            anlasma.dtBaslangic = dtpBaslangic.Value;
            anlasma.dtBitis = dtpBitis.Value;
            anlasma.intVadeTAH = Convert.ToInt32(txtVadeTAH.Text);
            anlasma.intVadeYEG = Convert.ToInt32(txtVadeYEG.Text);
            anlasma.intListSKUTAH = Convert.ToInt32(txtSKUTAH.Text);
            anlasma.intListSKUYEG = Convert.ToInt32(txtSKUYEG.Text);

            anlasma.flTAHIsk = Convert.ToDouble(txtTAHIsk.Text);
            anlasma.flTAHCiro = Convert.ToDouble(txtTAHCiro.Text);
            anlasma.flTAHCiro3 = Convert.ToDouble(txtTAHCiro3.Text);
            anlasma.flTAHCiro6 = Convert.ToDouble(txtTAHCiro6.Text);
            anlasma.flTAHCiro12 = Convert.ToDouble(txtTAHCiro12.Text);
            anlasma.flTAHCiroIsk = Convert.ToDouble(txtTAHCiroIsk.Text);
            anlasma.flYEGIsk = Convert.ToDouble(txtYEGIsk.Text);
            anlasma.flYEGCiro = Convert.ToDouble(txtYEGCiro.Text);
            anlasma.flYEGCiro3 = Convert.ToDouble(txtYEGCiro3.Text);
            anlasma.flYEGCiro6 = Convert.ToDouble(txtYEGCiro6.Text);
            anlasma.flYEGCiro12 = Convert.ToDouble(txtYEGCiro12.Text);
            anlasma.flYEGCiroIsk = Convert.ToDouble(txtYEGCiroIsk.Text);

            anlasma.mnTAHAnlasmaDisiBedeller = Convert.ToDecimal(txtTAHAnlasmaDisi.Text.Replace(".", ""));
            anlasma.mnYEGAnlasmaDisiBedeller = Convert.ToDecimal(txtYEGAnlasmaDisi.Text.Replace(".", ""));
            anlasma.mnTAHToplamCiro = Convert.ToDecimal(txtTAHToplamCiro.Text.Replace(".", ""));
            anlasma.mnYEGToplamCiro = Convert.ToDecimal(txtYEGToplamCiro.Text.Replace(".", ""));

            anlasma.strAciklama1 = txtAciklama.Text.Trim();

            anlasma.DoUpdate();
            MesajAt(anlasma, 3);
            MessageBox.Show("Anlaşma düzenlendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void sbSil_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Anlaşma silinecek, devam etmek istediğinize emin misiniz?", "Silme", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
            {
                DataTable dt = new DataTable();
                AnlasmaBedeller.GetObjects(dt, anlasma.pkID);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    AnlasmaBedeller anlasmabedel = AnlasmaBedeller.GetObject(Convert.ToInt32(dt.Rows[i]["pkID"]));
                    anlasmabedel.DoDelete();
                }
                anlasma.DoDelete();
                MesajAt(anlasma, 4);
                this.Close();
            }
        }

        private void MesajAt(Anlasmalar anlasma, int Durum)
        {
            if (Durum == 1)
            {
                GonderilenMesajlar gm = new GonderilenMesajlar(anlasma.intMusteriID, 10,
                    "Onaylanan anlaşma: " + anlasma.pkID.ToString(),
                    anlasma.pkID.ToString() + " nolu anlaşma onaylanmıştır.",
                    DateTime.Now, DateTime.MinValue, false, false, false);
                gm.DoInsert();
            }
            else if (Durum == 2)
            {
                GonderilenMesajlar gm = new GonderilenMesajlar(anlasma.intMusteriID, 10,
                    "Geri gönderilen anlaşma: " + anlasma.pkID.ToString(),
                    anlasma.pkID.ToString() + " nolu anlaşma onay talepten geri gönderilmiştir.",
                    DateTime.Now, DateTime.MinValue, false, false, false);
                gm.DoInsert();
            }
            else if (Durum == 3)
            {
                GonderilenMesajlar gm = new GonderilenMesajlar(anlasma.intMusteriID, 10,
                    "Düzeltilen anlaşma: " + anlasma.pkID.ToString(),
                    anlasma.pkID.ToString() + " nolu anlaşma güncellenmiştir.",
                    DateTime.Now, DateTime.MinValue, false, false, false);
                gm.DoInsert();
            }
            else if (Durum == 4)
            {
                GonderilenMesajlar gm = new GonderilenMesajlar(anlasma.intMusteriID, 10,
                    "Silinen anlaşma: " + anlasma.pkID.ToString(),
                    anlasma.pkID.ToString() + " nolu anlaşma silinmiştir.",
                    DateTime.Now, DateTime.MinValue, false, false, false);
                gm.DoInsert();
            }
            else if (Durum == 5)
            {
                GonderilenMesajlar gm = new GonderilenMesajlar(anlasma.intMusteriID, 10,
                    "Onaydan geri alınan anlaşma: " + anlasma.pkID.ToString(),
                    anlasma.pkID.ToString() + " nolu anlaşma onaydan geri alınmıştır.",
                    DateTime.Now, DateTime.MinValue, false, false, false);
                gm.DoInsert();
            }
        }

        private void txtSubeSayisi_TextChanged(object sender, EventArgs e)
        {
            try { Convert.ToInt32(((TextBox)sender).Text); }
            catch (Exception) { ((TextBox)sender).Text = "0"; }
        }

        private void txtTAHIsk_TextChanged(object sender, EventArgs e)
        {
            try { Convert.ToDouble(((TextBox)sender).Text); }
            catch (Exception) { ((TextBox)sender).Text = "0,0"; }
        }

        private void txtTAHAnlasmaDisi_TextChanged(object sender, EventArgs e)
        {
            try { Convert.ToDecimal(((TextBox)sender).Text); }
            catch (Exception) { ((TextBox)sender).Text = "0,00"; }
        }




        private System.Drawing.Printing.PrintDocument printDocument1 = new System.Drawing.Printing.PrintDocument();
        Bitmap memoryImage;

        private void CaptureScreen()
        {
            Graphics myGraphics = this.CreateGraphics();
            Size s = new Size(this.Width + 20, this.Height + 20); ;
            memoryImage = new Bitmap(s.Width, s.Height, myGraphics);
            Graphics memoryGraphics = Graphics.FromImage(memoryImage);
            memoryGraphics.CopyFromScreen(this.Location.X + 4, this.Location.Y + 52, 0, 0, s);
        }

        private void printDocument1_PrintPage(System.Object sender,
           System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(memoryImage, 0, 0);
        }

        private void sbYazdir_Click(object sender, EventArgs e)
        {
            printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(printDocument1_PrintPage);
            CaptureScreen();
            printDocument1.Print();
        }
    }
}

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
    public partial class frmINTERNETticaripazarlamaanlasmalar : Form
    {
        public frmINTERNETticaripazarlamaanlasmalar()
        {
            InitializeComponent();
            GMREF = 0;
            this.Text = "Ticari Pazarlama : Anlaşmalar (TÜMÜ)";
            gcanBAYI.Visible = true;
        }
        public frmINTERNETticaripazarlamaanlasmalar(bool sultanlar)
        {
            InitializeComponent();
            GMREF = 1;
            this.Text = "Ticari Pazarlama : Anlaşmalar (SULTANLAR PAZARLAMA A.Ş.)";
            gcanBAYI.Visible = false;
        }
        public frmINTERNETticaripazarlamaanlasmalar(int gmref)
        {
            InitializeComponent();
            GMREF = gmref;
            this.Text = "Ticari Pazarlama : Anlaşmalar (" + CariHesaplarTP.GetObject(gmref, true).MUSTERI + ")";
            gcanBAYI.Visible = false;
        }

        int GMREF;

        private void frmINTERNETticaripazarlamaanlasmalar_Load(object sender, EventArgs e)
        {
            if (GMREF == 0)
            {
                lblBayi.Text = "";
                //GetMusteriler();
                GetAnlasmalar();
            }
            else if (GMREF != 1)
            {
                lblBayi.Text = CariHesaplarTP.GetObjectBySMREF(GMREF)[1].ToString(); // gmref = smref ise zaten ana caridir, tektir
                //GetMusteriler();
                GetAnlasmalar();
            }
            else
            {
                lblBayi.Text = "SULTANLAR PAZARLAMA A.Ş.";
                //DataTable dt = new DataTable();
                //CariHesaplar.GetObjectsLikeTP(dt);
                //gridControl4.DataSource = dt;
                GetAnlasmalar();
            }
        }

        private void splitContainer1_Panel2_SizeChanged(object sender, EventArgs e)
        {
            sbIncele.Location = new Point(sbIncele.Location.X, splitContainer1.Panel2.Height - 26);
            sbEkle.Location = new Point(sbEkle.Location.X, splitContainer1.Panel2.Height - 26);
            sbDuzenle.Location = new Point(sbDuzenle.Location.X, splitContainer1.Panel2.Height - 26);
            sbSil.Location = new Point(sbSil.Location.X, splitContainer1.Panel2.Height - 26);
            sbOnayla.Location = new Point(sbOnayla.Location.X, splitContainer1.Panel2.Height - 26);
            sbGeriAl.Location = new Point(sbGeriAl.Location.X, splitContainer1.Panel2.Height - 26);
            sbPasif.Location = new Point(sbPasif.Location.X, splitContainer1.Panel2.Height - 26);
        }

        private void frmINTERNETticaripazarlamaanlasmalar_SizeChanged(object sender, EventArgs e)
        {
            sbIncele.Location = new Point(sbIncele.Location.X, lblAlt.Location.Y + 3);
            sbEkle.Location = new Point(sbEkle.Location.X, lblAlt.Location.Y + 3);
            sbDuzenle.Location = new Point(sbDuzenle.Location.X, lblAlt.Location.Y + 3);
            sbSil.Location = new Point(sbSil.Location.X, lblAlt.Location.Y + 3);
            sbOnayla.Location = new Point(sbOnayla.Location.X, lblAlt.Location.Y + 3);
            sbGeriAl.Location = new Point(sbGeriAl.Location.X, lblAlt.Location.Y + 3);
            sbPasif.Location = new Point(sbPasif.Location.X, lblAlt.Location.Y + 3);
            sbYazdir.Location = new Point(sbYazdir.Location.X, lblAlt.Location.Y + 3);
            sbExcel.Location = new Point(sbExcel.Location.X, lblAlt.Location.Y + 3);
            btnKat.Location = new Point(btnKat.Location.X, lblAlt.Location.Y + 3);

            rbHepsi.Location = new Point(this.Width - 383, rbHepsi.Location.Y);
            rbOnaylilar.Location = new Point(this.Width - 325, rbOnaylilar.Location.Y);
            rbOnaysizlar.Location = new Point(this.Width - 240, rbOnaysizlar.Location.Y);

            lblSatirSayisi.Location = new Point(this.Width - 60, lblAlt.Location.Y + 7);
        }

        private void frmINTERNETticaripazarlamaanlasmalar_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmAna frm1 = (frmAna)this.ParentForm;
            frm1.FormKapanirken(this.Name);
        }

        private void GetMusteriler()
        {
            DataTable dt = new DataTable();
            CariHesaplarTP.GetObjects(dt, GMREF);
            gridControl4.DataSource = dt;
        }

        public void GetAnlasmalar()
        {
            //if (gridView4.SelectedRowsCount > 0 && !gridView4.IsFilterRow(gridView4.GetSelectedRows()[0]))
            //{
            //    int SMREF = Convert.ToInt32(((DataRowView)gridControl4.MainView.GetRow(gridView4.GetSelectedRows()[0])).Row.ItemArray[20]);
            //    DataTable dt = new DataTable();
            //    Anlasmalar.GetObjects(dt, SMREF);
            //    gridControl1.DataSource = dt;
            //}

            object Onayli = DBNull.Value;
            if (rbOnaylilar.Checked)
                Onayli = true;
            else if (rbOnaysizlar.Checked)
                Onayli = false;

            DataTable dt = new DataTable();
            if (GMREF == 0)
                Anlasmalar.GetObjects(dt, Onayli, frmAna.KAdi);
            else
                Anlasmalar.GetObjects(dt, GMREF, Onayli, true);
            gridControl1.DataSource = dt;
            lblSatirSayisi.Text = dt.Rows.Count.ToString();
        }

        private void gridControl4_Click(object sender, EventArgs e)
        {
            if (gridView4.SelectedRowsCount > 0 && !gridView4.IsFilterRow(gridView4.GetSelectedRows()[0]))
            {
                GetAnlasmalar();
            }
        }

        private void sbIncele_Click(object sender, EventArgs e)
        {
            if (gridView1.SelectedRowsCount > 0 && !gridView1.IsFilterRow(gridView1.GetSelectedRows()[0]))
            {
                int AnlasmaID = Convert.ToInt32(((DataRowView)gridControl1.MainView.GetRow(gridView1.GetSelectedRows()[0])).Row.ItemArray[0]);
                frmINTERNETticaripazarlamaanlasmaincele frm = new frmINTERNETticaripazarlamaanlasmaincele(AnlasmaID);
                frm.MdiParent = this.MdiParent;
                frm.Show();

                frmAna frm1 = (frmAna)this.ParentForm;
                string gorunenisim = GMREF == 1 ? CariHesaplar.GetMUSTERIbyGMREF(frm.anlasma.SMREF).Substring(0, 5) : (frm.anlasma.strAciklama2 == "1" ? CariHesaplarTP.GetObject(frm.anlasma.SMREF, false).SUBE.Substring(0, 5) : CariHesaplar.GetMUSTERIbyGMREF(frm.anlasma.SMREF).Substring(0, 5));
                ToolStripButton lll = new ToolStripButton("TP:Anlaşma (" + gorunenisim + "...)");
                lll.Name = "frmINTERNETticaripazarlamaanlasmaincele";
                lll.MouseUp += new MouseEventHandler(frm1.lll_MouseUp);
                frm1.statusStrip1.Items.Add(lll);
            }
        }

        private void sbEkle_Click(object sender, EventArgs e)
        {
            frmINTERNETticaripazarlamacarisecimi frm2 = new frmINTERNETticaripazarlamacarisecimi();
            frm2.ShowDialog();

            if (frm2.SMREF != 0)
            {
                frmINTERNETticaripazarlamaanlasma frm = new frmINTERNETticaripazarlamaanlasma(frm2.SMREF, true);
                frm.MdiParent = this.MdiParent;
                frm.Show();

                frmAna frm1 = (frmAna)this.ParentForm;
                string gorunenisim = GMREF == 1 ? CariHesaplar.GetMUSTERIbyGMREF(frm.anlasma.SMREF).Substring(0, 5) : (frm.anlasma.strAciklama2 == "1" ? CariHesaplarTP.GetObject(frm.anlasma.SMREF, false).SUBE.Substring(0, 5) : CariHesaplar.GetMUSTERIbyGMREF(frm.anlasma.SMREF).Substring(0, 5));
                ToolStripButton lll = new ToolStripButton("TP:Anlaşma (" + gorunenisim + "...)");
                lll.Name = "frmINTERNETticaripazarlamaanlasma";
                lll.MouseUp += new MouseEventHandler(frm1.lll_MouseUp);
                frm1.statusStrip1.Items.Add(lll);
            }
        }

        private void sbDuzenle_Click(object sender, EventArgs e)
        {
            if (gridView1.SelectedRowsCount > 0 && !gridView1.IsFilterRow(gridView1.GetSelectedRows()[0]))
            {
                int AnlasmaID = Convert.ToInt32(((DataRowView)gridControl1.MainView.GetRow(gridView1.GetSelectedRows()[0])).Row.ItemArray[0]);

                if (Anlasmalar.GetObject(AnlasmaID).intOnay == 1)
                {
                    MessageBox.Show("Anlaşma onaylanmış. Onaylanmış anlaşma düzenlenemez.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                frmINTERNETticaripazarlamaanlasma frm = new frmINTERNETticaripazarlamaanlasma(AnlasmaID);
                frm.MdiParent = this.MdiParent;
                frm.Show();

                frmAna frm1 = (frmAna)this.ParentForm;
                string gorunenisim = GMREF == 1 ? CariHesaplar.GetMUSTERIbyGMREF(frm.anlasma.SMREF).Substring(0, 5) : (frm.anlasma.strAciklama2 == "1" ? CariHesaplarTP.GetObject(frm.anlasma.SMREF, false).SUBE.Substring(0, 5) : CariHesaplar.GetMUSTERIbyGMREF(frm.anlasma.SMREF).Substring(0, 5));
                ToolStripButton lll = new ToolStripButton("TP:Anlaşma (" + gorunenisim + "...)");
                lll.Name = "frmINTERNETticaripazarlamaanlasma";
                lll.MouseUp += new MouseEventHandler(frm1.lll_MouseUp);
                frm1.statusStrip1.Items.Add(lll);
            }
        }

        private void sbSil_Click(object sender, EventArgs e)
        {
            if (gridView1.SelectedRowsCount > 0 && !gridView1.IsFilterRow(gridView1.GetSelectedRows()[0]))
            {
                int AnlasmaID = Convert.ToInt32(((DataRowView)gridControl1.MainView.GetRow(gridView1.GetSelectedRows()[0])).Row.ItemArray[0]);

                if (Aktiviteler.GetAktiviteCountByAnlasmaID(AnlasmaID) > 0)
                {
                    MessageBox.Show("Anlaşma onlaylanmış aktivitelerde kullanılmış olduğundan silinemez.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (SatisRaporTP.GetSatirSayisiByAnlasmaID(AnlasmaID) > 0)
                {
                    MessageBox.Show("Anlaşma satış raporundaki hesaplamalarda kullanıldığından silinemez.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (Anlasmalar.GetObject(AnlasmaID).intOnay == 1)
                {
                    MessageBox.Show("Anlaşma onaylanmış. Onaylanmış anlaşma silinemez.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (MessageBox.Show("Anlaşma silinecek, devam etmek istediğinize emin misiniz?", "Silme", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    Anlasmalar anlasma = Anlasmalar.GetObject(AnlasmaID);
                    DataTable dt = new DataTable();
                    AnlasmaBedeller.GetObjects(dt, AnlasmaID);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        AnlasmaBedeller anlasmabedel = AnlasmaBedeller.GetObject(Convert.ToInt32(dt.Rows[i]["pkID"]));
                        anlasmabedel.DoDelete();
                    }
                    anlasma.DoDelete();
                    MesajAt(anlasma, 4);
                    GetAnlasmalar();
                }
            }
        }

        private void sbOnayla_Click(object sender, EventArgs e)
        {
            if (gridView1.SelectedRowsCount > 0 && !gridView1.IsFilterRow(gridView1.GetSelectedRows()[0]))
            {
                int AnlasmaID = Convert.ToInt32(((DataRowView)gridControl1.MainView.GetRow(gridView1.GetSelectedRows()[0])).Row.ItemArray[0]);
                Anlasmalar anlasma = Anlasmalar.GetObject(AnlasmaID);

                if (frmAna.KAdi == "ST47" || frmAna.KAdi == "nermincelik" || frmAna.KAdi == "ST01")
                {
                    if (MessageBox.Show("Anlaşma onaylanacak, devam etmek istediğinize emin misiniz?", "Onaylama", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                    {
                        if (Anlasmalar.GetObject(AnlasmaID).intOnay == 1)
                        {
                            MessageBox.Show("Anlaşma zaten onaylanmış.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        if (Anlasmalar.GetSonAnlasmaID(anlasma.SMREF, anlasma.dtBaslangic, anlasma.strAciklama2) > 0)
                            if (MessageBox.Show("Anlaşmanın başlangıç tarihini içeren onaylanmış bir anlaşma zaten var. Devam etmek istediğinize emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.No)
                                return;

                        anlasma.intOnay = 1;
                        anlasma.DoUpdate();
                        MesajAt(anlasma, 1);
                        GetAnlasmalar();
                    }
                }
                else
                {
                    MessageBox.Show("Yetkiniz bulunmamaktadır. Ticari pazarlama ile görüşün.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void sbGeriAl_Click(object sender, EventArgs e)
        {
            if (gridView1.SelectedRowsCount > 0 && !gridView1.IsFilterRow(gridView1.GetSelectedRows()[0]))
            {
                int AnlasmaID = Convert.ToInt32(((DataRowView)gridControl1.MainView.GetRow(gridView1.GetSelectedRows()[0])).Row.ItemArray[0]);
                Anlasmalar anlasma = Anlasmalar.GetObject(AnlasmaID);

                if (frmAna.KAdi == "ST47" || frmAna.KAdi == "nermincelik" || frmAna.KAdi == "ST01")
                {
                    if (MessageBox.Show("Anlaşma onaysız duruma getirilecek, devam etmek istediğinize emin misiniz?", "Geri alma", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                    {
                        if (Anlasmalar.GetObject(AnlasmaID).intOnay == 0)
                        {
                            MessageBox.Show("Anlaşma zaten onaylanmamış.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        anlasma.intOnay = 0;
                        anlasma.DoUpdate();
                        MesajAt(anlasma, 5);
                        GetAnlasmalar();
                    }
                }
                else
                {
                    MessageBox.Show("Yetkiniz bulunmamaktadır. Ticari pazarlama ile görüşün.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
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

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            sbIncele.PerformClick();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {

        }

        private void btnYenile_Click(object sender, EventArgs e)
        {
            GetAnlasmalar();
        }

        private void rbHepsi_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
                GetAnlasmalar();
        }

        private void sbYazdir_Click(object sender, EventArgs e)
        {
            gridControl1.PrintDialog();
        }

        private void sbExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel dosyaları (*.xls, *.xlsx)|*.xls;*.xlsx;|Bütün Dosyalar|*.*";
            if (sfd.ShowDialog() == DialogResult.OK)
                gridControl1.ExportToXls(sfd.FileName);
        }

        private void gridView1_ColumnFilterChanged(object sender, EventArgs e)
        {
            lblSatirSayisi.Text = gridView1.RowCount.ToString();
        }

        private void sbPasif_Click(object sender, EventArgs e)
        {
            if (gridView1.SelectedRowsCount > 0 && !gridView1.IsFilterRow(gridView1.GetSelectedRows()[0]))
            {
                int AnlasmaID = Convert.ToInt32(((DataRowView)gridControl1.MainView.GetRow(gridView1.GetSelectedRows()[0])).Row.ItemArray[0]);

                if (Anlasmalar.GetObject(AnlasmaID).intOnay != 1)
                {
                    MessageBox.Show("Anlaşma onaysız durumda. Pasife almak için onaylı olması gerekiyor.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (MessageBox.Show("Anlaşma pasife alınacak, devam etmek istediğinize emin misiniz?", "Pasif", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    Anlasmalar anlasma = Anlasmalar.GetObject(AnlasmaID);
                    anlasma.strAciklama3 = "PASİF";
                    anlasma.DoUpdate();
                    GetAnlasmalar();
                }
            }
        }

        private void btnKat_Click(object sender, EventArgs e)
        {
            int AnlasmaID = Convert.ToInt32(((DataRowView)gridControl1.MainView.GetRow(gridView1.GetSelectedRows()[0])).Row.ItemArray[0]);
            
            frmInputBox frm = new frmInputBox("Anlaşma Kategorisi (" + AnlasmaID.ToString() + ")", Anlasmalar.GetKat(AnlasmaID));
            frm.ShowDialog();

            Anlasmalar.SetKat(AnlasmaID, frmAna.InputBox);
            frmAna.InputBox = string.Empty;
        }
    }
}

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
    public partial class frmAT2rotamusteri : Form
    {
        public frmAT2rotamusteri()
        {
            InitializeComponent();
        }

        public static ArrayList ekleSMREF;

        private void frmAT2rotamusteri_Load(object sender, EventArgs e)
        {
            ekleSMREF = new ArrayList();

            gridControl2.Enabled = false;
            sbEkle.Enabled = false;
            sbSil.Enabled = false;
            sbDetay.Enabled = false;
            sbAsagi.Enabled = false;
            sbYukari.Enabled = false;

            GetRotalar();
        }

        private void GetRotalar()
        {
            DataTable dt = new DataTable();
            AT2_Rotalar.GetObjects(dt, false);
            gridControl1.DataSource = dt;
        }

        private void GetRotaMusteriler(int RotaID)
        {
            DataTable dt = new DataTable();
            AT2_RotaMusteri.GetObjects(dt, RotaID);
            gridControl2.DataSource = dt;
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridView1.GetSelectedRows()[0] != -999997) // filtreleme satırı seçili değilse
            {
                int RotaID = Convert.ToInt32(((DataRowView)gridControl1.MainView.GetRow(gridView1.GetSelectedRows()[0])).Row.ItemArray[0]);
                GetRotaMusteriler(RotaID);

                gridControl2.Enabled = true;
                sbEkle.Enabled = true;
                sbSil.Enabled = true;
                sbDetay.Enabled = true;
                sbAsagi.Enabled = true;
                sbYukari.Enabled = true;
            }
            else
            {
                gridControl2.Enabled = false;
                sbEkle.Enabled = false;
                sbSil.Enabled = false;
                sbDetay.Enabled = false;
                sbAsagi.Enabled = false;
                sbYukari.Enabled = false;
            }
        }

        private void sbEkle_Click(object sender, EventArgs e)
        {
            frmAT2rotamusterisecim frm = new frmAT2rotamusterisecim();
            frm.ShowDialog();

            int RotaID = Convert.ToInt32(((DataRowView)gridControl1.MainView.GetRow(gridView1.GetSelectedRows()[0])).Row.ItemArray[0]);

            for (int i = 0; i < ekleSMREF.Count; i++)
            {
                if (AT2_RotaMusteri.IsExist(Convert.ToInt32(ekleSMREF[i])))
                {
                    MessageBox.Show(ekleSMREF[i] + " nolu müşteri (" + CariHesaplar.GetObject(Convert.ToInt32(ekleSMREF[i])).SUBE + ") bir rotada zaten var, tekrar eklenemez.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    AT2_RotaMusteri rm = new AT2_RotaMusteri(Convert.ToInt32(ekleSMREF[i]), RotaID, AT2_RotaMusteri.MaxSira(RotaID) + 1);
                    rm.DoInsert();
                }
            }

            ekleSMREF = new ArrayList();
            GetRotaMusteriler(RotaID);
        }

        private void sbSil_Click(object sender, EventArgs e)
        {
            if (gridView2.GetSelectedRows().Length > 0) // bir satır seçili ise
            {
                if (gridView2.GetSelectedRows()[0] != -999997) // filtreleme satırı seçili değilse
                {
                    if (MessageBox.Show("Silmek istediğinize emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                    {
                        int RotaMusteriID = Convert.ToInt32(((DataRowView)gridControl2.MainView.GetRow(gridView2.GetSelectedRows()[0])).Row.ItemArray[0]);
                        AT2_RotaMusteri rm = AT2_RotaMusteri.GetObject(RotaMusteriID);
                        rm.DoDelete();

                        DataTable dt = new DataTable();
                        AT2_RotaMusteri.GetObjects(dt, rm.intRotaID);
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            AT2_RotaMusteri rm1 = AT2_RotaMusteri.GetObject(Convert.ToInt32(dt.Rows[i]["pkID"]));
                            rm1.intSira = i + 1;
                            rm1.DoUpdate();
                        }

                        GetRotaMusteriler(rm.intRotaID);
                    }
                }
            }
        }

        private void sbDetay_Click(object sender, EventArgs e)
        {

        }

        private void btnYenile_Click(object sender, EventArgs e)
        {
            GetRotalar();
        }

        private void sbYukari_Click(object sender, EventArgs e)
        {
            if (gridView2.GetSelectedRows().Length > 0) // bir satır seçili ise
            {
                if (gridView2.GetSelectedRows()[0] != -999997) // filtreleme satırı seçili değilse
                {
                    int RotaMusteriID = Convert.ToInt32(((DataRowView)gridControl2.MainView.GetRow(gridView2.GetSelectedRows()[0])).Row.ItemArray[0]);
                    AT2_RotaMusteri rm = AT2_RotaMusteri.GetObject(RotaMusteriID);

                    if (rm.intSira > 1)
                    {
                        AT2_RotaMusteri rmOnceki = AT2_RotaMusteri.GetObject(rm.intRotaID, rm.intSira - 1);
                        rmOnceki.intSira++;
                        rmOnceki.DoUpdate();
                        rm.intSira--;
                        rm.DoUpdate();

                        int indx = gridView2.FocusedRowHandle;
                        GetRotaMusteriler(rm.intRotaID);
                        gridView2.FocusedRowHandle = indx - 1;
                    }
                }
            }
        }

        private void sbAsagi_Click(object sender, EventArgs e)
        {
            if (gridView2.GetSelectedRows().Length > 0) // bir satır seçili ise
            {
                if (gridView2.GetSelectedRows()[0] != -999997) // filtreleme satırı seçili değilse
                {
                    int RotaMusteriID = Convert.ToInt32(((DataRowView)gridControl2.MainView.GetRow(gridView2.GetSelectedRows()[0])).Row.ItemArray[0]);
                    AT2_RotaMusteri rm = AT2_RotaMusteri.GetObject(RotaMusteriID);

                    if (rm.intSira < AT2_RotaMusteri.MaxSira(rm.intRotaID))
                    {
                        AT2_RotaMusteri rmSonraki = AT2_RotaMusteri.GetObject(rm.intRotaID, rm.intSira + 1);
                        rmSonraki.intSira--;
                        rmSonraki.DoUpdate();
                        rm.intSira++;
                        rm.DoUpdate();

                        int indx = gridView2.FocusedRowHandle;
                        GetRotaMusteriler(rm.intRotaID);
                        gridView2.FocusedRowHandle = indx + 1;
                    }
                }
            }
        }

        private void frmAT2rotamusteri_SizeChanged(object sender, EventArgs e)
        {
            gridControl1.Width = this.Width - 525;
            sbEkle.Location = new Point(this.Width - 518, sbEkle.Location.Y);
            sbSil.Location = new Point(this.Width - 360, sbSil.Location.Y);
            sbDetay.Location = new Point(this.Width - 202, sbDetay.Location.Y);
            btnYenile.Location = new Point(this.Width - 46, btnYenile.Location.Y);
            sbYukari.Location = new Point(this.Width - 45, sbYukari.Location.Y);
            sbAsagi.Location = new Point(this.Width - 45, sbAsagi.Location.Y);
            gridControl2.Location = new Point(this.Width - 518, gridControl2.Location.Y);
            gridControl2.Height = this.Height - 84;
        }
    }
}

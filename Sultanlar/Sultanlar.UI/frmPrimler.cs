using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Sultanlar.DatabaseObject.Internet;
using DgvFilterPopup;
using System.Threading;

namespace Sultanlar.UI
{
    public partial class frmPrimler : DevComponents.DotNetBar.Metro.MetroAppForm
    {
        public frmPrimler()
        {
            InitializeComponent();
        }

        Thread thr;

        private void frmPrimler_Load(object sender, EventArgs e)
        {
            DevExpress.Data.CurrencyDataController.DisableThreadingProblemsDetection = true;
            CheckForIllegalCrossThreadCalls = false;
            GetCariTip();
            WindowState = FormWindowState.Maximized;
        }

        private void GetObjects()
        {
            GetMTB();
            GetCariTip();
            GetSatTem();
            GetCH();
            GetTF();
            GetF();
        }
        private void GetMTB()
        {
            DataTable dt = new DataTable();
            Primler.GetObjectsMTBIIKod(dt);
            gridControl1.DataSource = dt;
            SatirSayisi();
        }
        private void GetCariTip()
        {
            DataTable dt = new DataTable();
            Primler.GetObjectsCariTip(dt);
            gridControl2.DataSource = dt;
            SatirSayisi();
        }
        private void GetSatTem()
        {
            DataTable dt = new DataTable();
            Primler.GetObjectsSatTem(dt);
            gridControl3.DataSource = dt;
            SatirSayisi();
        }
        private void GetCH()
        {
            DataTable dt = new DataTable();
            Primler.GetObjectsCH(dt);
            gridControl4.DataSource = dt;
            SatirSayisi();
        }
        private void GetTF()
        {
            DataTable dt = new DataTable();
            Primler.GetObjectsTF(dt);
            gridControl5.DataSource = dt;
            SatirSayisi();
        }
        private void GetF()
        {
            DataTable dt = new DataTable();
            Primler.GetObjectsF(dt);
            gridControl6.DataSource = dt;
            SatirSayisi();
        }

        private void SatirSayisi()
        {
            if (metroShell1.SelectedTab.Name == "metroTabItem1")
            {
                liSatirSayisi.Text = gridControl1.MainView.DataRowCount.ToString();
            }
            else if (metroShell1.SelectedTab.Name == "metroTabItem2")
            {
                liSatirSayisi.Text = gridControl2.MainView.DataRowCount.ToString();
            }
            else if (metroShell1.SelectedTab.Name == "metroTabItem3")
            {
                liSatirSayisi.Text = gridControl3.MainView.DataRowCount.ToString();
            }
            else if (metroShell1.SelectedTab.Name == "metroTabItem4")
            {
                liSatirSayisi.Text = gridControl4.MainView.DataRowCount.ToString();
            }
            else if (metroShell1.SelectedTab.Name == "metroTabItem5")
            {
                liSatirSayisi.Text = gridControl5.MainView.DataRowCount.ToString();
            }
            else if (metroShell1.SelectedTab.Name == "metroTabItem6")
            {
                liSatirSayisi.Text = gridControl6.MainView.DataRowCount.ToString();
            }
        }

        private void EnableDisable(bool enable)
        {
            gridControl1.Enabled = enable;
            gridControl2.Enabled = enable;
            gridControl3.Enabled = enable;
            gridControl4.Enabled = enable;
            gridControl5.Enabled = enable;
            gridControl6.Enabled = enable;
            sbchTopluVeri.Enabled = enable;
            sbctAltlaraAktar.Enabled = enable;
            sbctbTopluVeri.Enabled = enable;
            sbctTopluVeri.Enabled = enable;
            sbftTopluVeri.Enabled = enable;
            sbstTopluVeri.Enabled = enable;
            sbtgTopluVeri.Enabled = enable;
            metroTabItem1.Enabled = enable;
            metroTabItem2.Enabled = enable;
            metroTabItem3.Enabled = enable;
            metroTabItem4.Enabled = enable;
            metroTabItem5.Enabled = enable;
            metroTabItem6.Enabled = enable;
        }

        private void metroTabItem1_Click(object sender, EventArgs e)
        {
            GetMTB();
        }

        private void metroTabItem2_Click(object sender, EventArgs e)
        {
            GetCariTip();
        }

        private void metroTabItem3_Click(object sender, EventArgs e)
        {
            GetSatTem();
        }

        private void metroTabItem4_Click(object sender, EventArgs e)
        {
            GetCH();
        }

        private void metroTabItem5_Click(object sender, EventArgs e)
        {
            GetTF();
        }

        private void metroTabItem6_Click(object sender, EventArgs e)
        {
            GetF();
        }

        private void gridView1_ColumnFilterChanged(object sender, EventArgs e)
        {
            SatirSayisi();
        }

        private void gridView2_ColumnFilterChanged(object sender, EventArgs e)
        {
            SatirSayisi();
        }

        private void gridView3_ColumnFilterChanged(object sender, EventArgs e)
        {
            SatirSayisi();
        }

        private void gridView4_ColumnFilterChanged(object sender, EventArgs e)
        {
            SatirSayisi();
        }

        private void gridView6_ColumnFilterChanged(object sender, EventArgs e)
        {
            SatirSayisi();
        }

        private void gridView5_ColumnFilterChanged(object sender, EventArgs e)
        {
            SatirSayisi();
        }

        private void buttonItem1_Click(object sender, EventArgs e)
        {
            this.WindowState = this.WindowState == FormWindowState.Maximized ? FormWindowState.Normal : FormWindowState.Maximized;
        }

        private void buttonItem2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPrimler_SizeChanged(object sender, EventArgs e)
        {
            buttonItem1.Text = this.WindowState == FormWindowState.Maximized ? "KÜÇÜLT" : "BÜYÜT";
        }

        #region Cari Tip

        private void CT_TopluVeri()
        {
            metroShell1.Enabled = false;

            if (cectBoslariGirme.Checked)
            {
                if (tect1.Text.Trim() != string.Empty)
                {
                    progressBarControl1.Text = string.Empty;
                    progressBarControl1.Properties.Maximum = gridControl2.MainView.RowCount;
                    lcProgress.Text = "1. veri giriliyor...";

                    for (int i = 0; i < gridControl2.MainView.RowCount; i++)
                    {
                        Primler.SetCariTipTah(((DataRowView)gridControl2.MainView.GetRow(i)).Row.ItemArray[0].ToString(), Convert.ToDouble(tect1.Text.Trim()));

                        ((DevExpress.XtraGrid.Views.Grid.GridView)gridControl2.MainView).SetRowCellValue(i, "PRM_TAH", Convert.ToDouble(tect1.Text.Trim()));

                        progressBarControl1.PerformStep();
                        progressBarControl1.Update();
                        lcProgress.Text = "1. veri giriliyor... " + (i + 1).ToString() + " / " + gridControl2.MainView.RowCount.ToString();
                    }
                }
                if (tect2.Text.Trim() != string.Empty)
                {
                    progressBarControl1.Text = string.Empty;
                    progressBarControl1.Properties.Maximum = gridControl2.MainView.RowCount;
                    lcProgress.Text = "2. veri giriliyor...";

                    for (int i = 0; i < gridControl2.MainView.RowCount; i++)
                    {
                        Primler.SetCariTipSat(((DataRowView)gridControl2.MainView.GetRow(i)).Row.ItemArray[0].ToString(), Convert.ToDouble(tect2.Text.Trim()));

                        ((DevExpress.XtraGrid.Views.Grid.GridView)gridControl2.MainView).SetRowCellValue(i, "PRM_SAT", Convert.ToDouble(tect2.Text.Trim()));

                        progressBarControl1.PerformStep();
                        progressBarControl1.Update();
                        lcProgress.Text = "2. veri giriliyor... " + (i + 1).ToString() + " / " + gridControl2.MainView.RowCount.ToString();
                    }
                }
                if (tect3.Text.Trim() != string.Empty)
                {
                    progressBarControl1.Text = string.Empty;
                    progressBarControl1.Properties.Maximum = gridControl2.MainView.RowCount;
                    lcProgress.Text = "3. veri giriliyor...";

                    for (int i = 0; i < gridControl2.MainView.RowCount; i++)
                    {
                        Primler.SetCariTipNok(((DataRowView)gridControl2.MainView.GetRow(i)).Row.ItemArray[0].ToString(), Convert.ToDouble(tect3.Text.Trim()));

                        ((DevExpress.XtraGrid.Views.Grid.GridView)gridControl2.MainView).SetRowCellValue(i, "PRM_NOK", Convert.ToDouble(tect3.Text.Trim()));

                        progressBarControl1.PerformStep();
                        progressBarControl1.Update();
                        lcProgress.Text = "3. veri giriliyor... " + (i + 1).ToString() + " / " + gridControl2.MainView.RowCount.ToString();
                    }
                }
                if (tect4.Text.Trim() != string.Empty)
                {
                    progressBarControl1.Text = string.Empty;
                    progressBarControl1.Properties.Maximum = gridControl2.MainView.RowCount;
                    lcProgress.Text = "4. veri giriliyor...";

                    for (int i = 0; i < gridControl2.MainView.RowCount; i++)
                    {
                        Primler.SetCariTip4(((DataRowView)gridControl2.MainView.GetRow(i)).Row.ItemArray[0].ToString(), Convert.ToDouble(tect4.Text.Trim()));

                        ((DevExpress.XtraGrid.Views.Grid.GridView)gridControl2.MainView).SetRowCellValue(i, "PRM_4", Convert.ToDouble(tect4.Text.Trim()));

                        progressBarControl1.PerformStep();
                        progressBarControl1.Update();
                        lcProgress.Text = "4. veri giriliyor... " + (i + 1).ToString() + " / " + gridControl2.MainView.RowCount.ToString();
                    }
                }
                if (tect5.Text.Trim() != string.Empty)
                {
                    progressBarControl1.Text = string.Empty;
                    progressBarControl1.Properties.Maximum = gridControl2.MainView.RowCount;
                    progressBarControl1.Properties.Step = 1;
                    lcProgress.Text = "5. veri giriliyor...";

                    for (int i = 0; i < gridControl2.MainView.RowCount; i++)
                    {
                        Primler.SetCariTip5(((DataRowView)gridControl2.MainView.GetRow(i)).Row.ItemArray[0].ToString(), Convert.ToDouble(tect5.Text.Trim()));

                        ((DevExpress.XtraGrid.Views.Grid.GridView)gridControl2.MainView).SetRowCellValue(i, "PRM_5", Convert.ToDouble(tect5.Text.Trim()));
                        
                        progressBarControl1.PerformStep();
                        progressBarControl1.Update();
                        lcProgress.Text = "5. veri giriliyor... " + (i + 1).ToString() + " / " + gridControl2.MainView.RowCount.ToString();
                    }
                }
            }
            else
            {
                //progressBarControl1.Text = string.Empty;
                //progressBarControl1.Properties.Maximum = gridControl2.MainView.RowCount;
                //lcProgress.Text = "Aktarým yapýlýyor...";

                //for (int i = 0; i < gridControl2.MainView.RowCount; i++)
                //{
                //    Primler.SetCariTip(
                //        ((DataRowView)gridControl2.MainView.GetRow(i)).Row.ItemArray[0].ToString(),
                //        Convert.ToDouble(tect1.Text.Trim()),
                //        Convert.ToDouble(tect2.Text.Trim()),
                //        Convert.ToDouble(tect3.Text.Trim()),
                //        Convert.ToDouble(tect4.Text.Trim()),
                //        Convert.ToDouble(tect5.Text.Trim()));

                //    ((DevExpress.XtraGrid.Views.Grid.GridView)gridControl2.MainView).SetRowCellValue(i, "PRM_TAH", Convert.ToDouble(tect1.Text.Trim()));
                //    ((DevExpress.XtraGrid.Views.Grid.GridView)gridControl2.MainView).SetRowCellValue(i, "PRM_SAT", Convert.ToDouble(tect2.Text.Trim()));
                //    ((DevExpress.XtraGrid.Views.Grid.GridView)gridControl2.MainView).SetRowCellValue(i, "PRM_NOK", Convert.ToDouble(tect3.Text.Trim()));
                //    ((DevExpress.XtraGrid.Views.Grid.GridView)gridControl2.MainView).SetRowCellValue(i, "PRM_4", Convert.ToDouble(tect4.Text.Trim()));
                //    ((DevExpress.XtraGrid.Views.Grid.GridView)gridControl2.MainView).SetRowCellValue(i, "PRM_5", Convert.ToDouble(tect5.Text.Trim()));

                //    progressBarControl1.PerformStep();
                //    progressBarControl1.Update();
                //}
            }

            tect1.Text = string.Empty; tect2.Text = string.Empty; tect3.Text = string.Empty; tect4.Text = string.Empty; tect5.Text = string.Empty;

            progressBarControl1.PerformStep();
            lcProgress.Text = "Form hazýr.";
            metroShell1.Enabled = true;

            DevComponents.DotNetBar.MessageBoxEx.Show("Ýþlem tamamlandý.", "Baþarýlý", MessageBoxButtons.OK, MessageBoxIcon.Information);
            progressBarControl1.Text = string.Empty;
        }

        private void CT_AltlaraAktar()
        {
            metroShell1.Enabled = false;
            progressBarControl1.Text = string.Empty;
            progressBarControl1.Properties.Maximum = gridControl2.MainView.RowCount;
            lcProgress.Text = "Aktarým yapýlýyor...";

            for (int i = 0; i < gridControl2.MainView.RowCount; i++)
            {
                Primler.SetMTBIIKodByCariTip(
                    ((DataRowView)gridControl2.MainView.GetRow(i)).Row.ItemArray[0].ToString(),
                    Convert.ToDouble(((DataRowView)gridControl2.MainView.GetRow(i)).Row.ItemArray[2].ToString()),
                    Convert.ToDouble(((DataRowView)gridControl2.MainView.GetRow(i)).Row.ItemArray[3].ToString()),
                    Convert.ToDouble(((DataRowView)gridControl2.MainView.GetRow(i)).Row.ItemArray[4].ToString()),
                    Convert.ToDouble(((DataRowView)gridControl2.MainView.GetRow(i)).Row.ItemArray[5].ToString()),
                    Convert.ToDouble(((DataRowView)gridControl2.MainView.GetRow(i)).Row.ItemArray[6].ToString()));

                Primler.SetCariHesapByCariTip(
                    ((DataRowView)gridControl2.MainView.GetRow(i)).Row.ItemArray[0].ToString(),
                    Convert.ToDouble(((DataRowView)gridControl2.MainView.GetRow(i)).Row.ItemArray[2].ToString()),
                    Convert.ToDouble(((DataRowView)gridControl2.MainView.GetRow(i)).Row.ItemArray[3].ToString()),
                    Convert.ToDouble(((DataRowView)gridControl2.MainView.GetRow(i)).Row.ItemArray[4].ToString()),
                    Convert.ToDouble(((DataRowView)gridControl2.MainView.GetRow(i)).Row.ItemArray[5].ToString()),
                    Convert.ToDouble(((DataRowView)gridControl2.MainView.GetRow(i)).Row.ItemArray[6].ToString()));

                //Primler.SetSatTemByCariTip(
                //    ((DataRowView)gridControl2.MainView.GetRow(i)).Row.ItemArray[0].ToString(),
                //    Convert.ToDouble(((DataRowView)gridControl2.MainView.GetRow(i)).Row.ItemArray[2].ToString()),
                //    Convert.ToDouble(((DataRowView)gridControl2.MainView.GetRow(i)).Row.ItemArray[3].ToString()),
                //    Convert.ToDouble(((DataRowView)gridControl2.MainView.GetRow(i)).Row.ItemArray[4].ToString()),
                //    Convert.ToDouble(((DataRowView)gridControl2.MainView.GetRow(i)).Row.ItemArray[5].ToString()),
                //    Convert.ToDouble(((DataRowView)gridControl2.MainView.GetRow(i)).Row.ItemArray[6].ToString()));

                progressBarControl1.PerformStep();
                progressBarControl1.Update();
                lcProgress.Text = "Aktarým yapýlýyor... " + (i + 1).ToString() + " / " + gridControl2.MainView.RowCount.ToString();
            }

            metroShell1.Enabled = true;
            lcProgress.Text = "Form hazýr.";
            DevComponents.DotNetBar.MessageBoxEx.Show("Aktarým tamamlandý.", "Baþarýlý", MessageBoxButtons.OK, MessageBoxIcon.Information);
            progressBarControl1.Text = string.Empty;
        }

        private void gridView2_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            switch (e.Column.Name)
            {
                case "gcctPRM_TAH":
                    Primler.SetCariTipTah(((DataRowView)gridControl2.MainView.GetRow(e.RowHandle)).Row.ItemArray[0].ToString(), Convert.ToDouble(e.Value));
                    break;
                case "gcctPRM_SAT":
                    Primler.SetCariTipSat(((DataRowView)gridControl2.MainView.GetRow(e.RowHandle)).Row.ItemArray[0].ToString(), Convert.ToDouble(e.Value));
                    break;
                case "gcctPRM_NOK":
                    Primler.SetCariTipNok(((DataRowView)gridControl2.MainView.GetRow(e.RowHandle)).Row.ItemArray[0].ToString(), Convert.ToDouble(e.Value));
                    break;
                case "gcctPRM_4":
                    Primler.SetCariTip4(((DataRowView)gridControl2.MainView.GetRow(e.RowHandle)).Row.ItemArray[0].ToString(), Convert.ToDouble(e.Value));
                    break;
                case "gcctPRM_5":
                    Primler.SetCariTip5(((DataRowView)gridControl2.MainView.GetRow(e.RowHandle)).Row.ItemArray[0].ToString(), Convert.ToDouble(e.Value));
                    break;
            }
        }

        private void sbctTopluVeri_Click(object sender, EventArgs e)
        {
            if (!cectBoslariGirme.Checked && tect1.Text.Trim() != string.Empty && tect2.Text.Trim() != string.Empty &&
                 tect3.Text.Trim() != string.Empty && tect4.Text.Trim() != string.Empty && tect5.Text.Trim() != string.Empty)
            {
                thr = new Thread(new ThreadStart(CT_TopluVeri));
                thr.Start();
            }
            else if (cectBoslariGirme.Checked)
            {
                try
                {
                    if (tect1.Text.Trim() != string.Empty) Convert.ToDouble(tect1.Text.Trim());
                    if (tect2.Text.Trim() != string.Empty) Convert.ToDouble(tect2.Text.Trim());
                    if (tect3.Text.Trim() != string.Empty) Convert.ToDouble(tect3.Text.Trim());
                    if (tect4.Text.Trim() != string.Empty) Convert.ToDouble(tect4.Text.Trim());
                    if (tect5.Text.Trim() != string.Empty) Convert.ToDouble(tect5.Text.Trim());
                }
                catch (Exception)
                {
                    DevComponents.DotNetBar.MessageBoxEx.Show("Girilen verilerde hata var.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (DevComponents.DotNetBar.MessageBoxEx.Show("Ýþlem uzun sürebilir, bu esnada programý kapatmayýnýz. Devam etmek istediðinize emin misiniz?", "Devam", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    thr = new Thread(new ThreadStart(CT_TopluVeri));
                    thr.Start();
                }
            }
            else
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Eksik veri girildi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        
        private void sbctAltlaraAktar_Click(object sender, EventArgs e)
        {
            if (DevComponents.DotNetBar.MessageBoxEx.Show("Devam etmek istediðinize emin misiniz?", "Devam", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
            {
                thr = new Thread(new ThreadStart(CT_AltlaraAktar));
                thr.Start();
            }
        }

        #endregion

        #region Cari Tip Bölge

        private void CTB_TopluVeri()
        {
            metroShell1.Enabled = false;

            if (tectb1.Text.Trim() != string.Empty)
            {
                progressBarControl1.Text = string.Empty;
                progressBarControl1.Properties.Maximum = gridControl1.MainView.RowCount;
                lcProgress.Text = "1. veri giriliyor...";

                for (int i = 0; i < gridControl1.MainView.RowCount; i++)
                {
                    Primler.SetMTBIIKodTah(((DataRowView)gridControl1.MainView.GetRow(i)).Row.ItemArray[0].ToString(), Convert.ToDouble(tectb1.Text.Trim()));

                    ((DevExpress.XtraGrid.Views.Grid.GridView)gridControl1.MainView).SetRowCellValue(i, "PRM_TAH", Convert.ToDouble(tectb1.Text.Trim()));

                    progressBarControl1.PerformStep();
                    progressBarControl1.Update();
                    lcProgress.Text = "1. veri giriliyor... " + (i + 1).ToString() + " / " + gridControl1.MainView.RowCount.ToString();
                }
            }
            if (tectb2.Text.Trim() != string.Empty)
            {
                progressBarControl1.Text = string.Empty;
                progressBarControl1.Properties.Maximum = gridControl1.MainView.RowCount;
                lcProgress.Text = "2. veri giriliyor...";

                for (int i = 0; i < gridControl1.MainView.RowCount; i++)
                {
                    Primler.SetMTBIIKodSat(((DataRowView)gridControl1.MainView.GetRow(i)).Row.ItemArray[0].ToString(), Convert.ToDouble(tectb2.Text.Trim()));

                    ((DevExpress.XtraGrid.Views.Grid.GridView)gridControl1.MainView).SetRowCellValue(i, "PRM_SAT", Convert.ToDouble(tectb2.Text.Trim()));

                    progressBarControl1.PerformStep();
                    progressBarControl1.Update();
                    lcProgress.Text = "2. veri giriliyor... " + (i + 1).ToString() + " / " + gridControl1.MainView.RowCount.ToString();
                }
            }
            if (tectb3.Text.Trim() != string.Empty)
            {
                progressBarControl1.Text = string.Empty;
                progressBarControl1.Properties.Maximum = gridControl1.MainView.RowCount;
                lcProgress.Text = "3. veri giriliyor...";

                for (int i = 0; i < gridControl1.MainView.RowCount; i++)
                {
                    Primler.SetMTBIIKodNok(((DataRowView)gridControl1.MainView.GetRow(i)).Row.ItemArray[0].ToString(), Convert.ToDouble(tectb3.Text.Trim()));

                    ((DevExpress.XtraGrid.Views.Grid.GridView)gridControl1.MainView).SetRowCellValue(i, "PRM_NOK", Convert.ToDouble(tectb3.Text.Trim()));

                    progressBarControl1.PerformStep();
                    progressBarControl1.Update();
                    lcProgress.Text = "3. veri giriliyor... " + (i + 1).ToString() + " / " + gridControl1.MainView.RowCount.ToString();
                }
            }
            if (tectb4.Text.Trim() != string.Empty)
            {
                progressBarControl1.Text = string.Empty;
                progressBarControl1.Properties.Maximum = gridControl1.MainView.RowCount;
                lcProgress.Text = "4. veri giriliyor...";

                for (int i = 0; i < gridControl1.MainView.RowCount; i++)
                {
                    Primler.SetMTBIIKod4(((DataRowView)gridControl1.MainView.GetRow(i)).Row.ItemArray[0].ToString(), Convert.ToDouble(tectb4.Text.Trim()));

                    ((DevExpress.XtraGrid.Views.Grid.GridView)gridControl1.MainView).SetRowCellValue(i, "PRM_4", Convert.ToDouble(tectb4.Text.Trim()));

                    progressBarControl1.PerformStep();
                    progressBarControl1.Update();
                    lcProgress.Text = "4. veri giriliyor... " + (i + 1).ToString() + " / " + gridControl1.MainView.RowCount.ToString();
                }
            }
            if (tectb5.Text.Trim() != string.Empty)
            {
                progressBarControl1.Text = string.Empty;
                progressBarControl1.Properties.Maximum = gridControl1.MainView.RowCount;
                lcProgress.Text = "5. veri giriliyor...";

                for (int i = 0; i < gridControl1.MainView.RowCount; i++)
                {
                    Primler.SetMTBIIKod5(((DataRowView)gridControl1.MainView.GetRow(i)).Row.ItemArray[0].ToString(), Convert.ToDouble(tectb5.Text.Trim()));

                    ((DevExpress.XtraGrid.Views.Grid.GridView)gridControl1.MainView).SetRowCellValue(i, "PRM_5", Convert.ToDouble(tectb5.Text.Trim()));

                    progressBarControl1.PerformStep();
                    progressBarControl1.Update();
                    lcProgress.Text = "5. veri giriliyor... " + (i + 1).ToString() + " / " + gridControl1.MainView.RowCount.ToString();
                }
            }

            tectb1.Text = string.Empty; tectb2.Text = string.Empty; tectb3.Text = string.Empty; tectb4.Text = string.Empty; tectb5.Text = string.Empty;

            progressBarControl1.PerformStep();
            lcProgress.Text = "Form hazýr.";
            metroShell1.Enabled = true;

            DevComponents.DotNetBar.MessageBoxEx.Show("Ýþlem tamamlandý.", "Baþarýlý", MessageBoxButtons.OK, MessageBoxIcon.Information);
            progressBarControl1.Text = string.Empty;
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            switch (e.Column.Name)
            {
                case "gcONC1":
                    Primler.SetMTBIIKodONC(((DataRowView)gridControl1.MainView.GetRow(e.RowHandle)).Row.ItemArray[0].ToString(), "1", Convert.ToInt32(e.Value));
                    break;
                case "gcPRM_TAH":
                    Primler.SetMTBIIKodTah(((DataRowView)gridControl1.MainView.GetRow(e.RowHandle)).Row.ItemArray[0].ToString(), Convert.ToDouble(e.Value));
                    break;
                case "gcONC2":
                    Primler.SetMTBIIKodONC(((DataRowView)gridControl1.MainView.GetRow(e.RowHandle)).Row.ItemArray[0].ToString(), "2", Convert.ToInt32(e.Value));
                    break;
                case "gcPRM_SAT":
                    Primler.SetMTBIIKodSat(((DataRowView)gridControl1.MainView.GetRow(e.RowHandle)).Row.ItemArray[0].ToString(), Convert.ToDouble(e.Value));
                    break;
                case "gcONC3":
                    Primler.SetMTBIIKodONC(((DataRowView)gridControl1.MainView.GetRow(e.RowHandle)).Row.ItemArray[0].ToString(), "3", Convert.ToInt32(e.Value));
                    break;
                case "gcPRM_NOK":
                    Primler.SetMTBIIKodNok(((DataRowView)gridControl1.MainView.GetRow(e.RowHandle)).Row.ItemArray[0].ToString(), Convert.ToDouble(e.Value));
                    break;
                case "gcONC4":
                    Primler.SetMTBIIKodONC(((DataRowView)gridControl1.MainView.GetRow(e.RowHandle)).Row.ItemArray[0].ToString(), "4", Convert.ToInt32(e.Value));
                    break;
                case "gcPRM_4":
                    Primler.SetMTBIIKod4(((DataRowView)gridControl1.MainView.GetRow(e.RowHandle)).Row.ItemArray[0].ToString(), Convert.ToDouble(e.Value));
                    break;
                case "gcONC5":
                    Primler.SetMTBIIKodONC(((DataRowView)gridControl1.MainView.GetRow(e.RowHandle)).Row.ItemArray[0].ToString(), "5", Convert.ToInt32(e.Value));
                    break;
                case "gcPRM_5":
                    Primler.SetMTBIIKod5(((DataRowView)gridControl1.MainView.GetRow(e.RowHandle)).Row.ItemArray[0].ToString(), Convert.ToDouble(e.Value));
                    break;
            }
        }

        private void sbctbTopluVeri_Click(object sender, EventArgs e)
        {
            try
            {
                if (tectb1.Text.Trim() != string.Empty) Convert.ToDouble(tectb1.Text.Trim());
                if (tectb2.Text.Trim() != string.Empty) Convert.ToDouble(tectb2.Text.Trim());
                if (tectb3.Text.Trim() != string.Empty) Convert.ToDouble(tectb3.Text.Trim());
                if (tectb4.Text.Trim() != string.Empty) Convert.ToDouble(tectb4.Text.Trim());
                if (tectb5.Text.Trim() != string.Empty) Convert.ToDouble(tectb5.Text.Trim());
            }
            catch (Exception)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Girilen verilerde hata var.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (DevComponents.DotNetBar.MessageBoxEx.Show("Ýþlem uzun sürebilir, bu esnada programý kapatmayýnýz. Devam etmek istediðinize emin misiniz?", "Devam", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
            {
                thr = new Thread(new ThreadStart(CTB_TopluVeri));
                thr.Start();
            }
        }

        #endregion

        #region Satýþ Temsilcisi

        private void ST_TopluVeri()
        {
            metroShell1.Enabled = false;

            if (test1.Text.Trim() != string.Empty)
            {
                progressBarControl1.Text = string.Empty;
                progressBarControl1.Properties.Maximum = gridControl3.MainView.RowCount;
                lcProgress.Text = "1. veri giriliyor...";

                for (int i = 0; i < gridControl3.MainView.RowCount; i++)
                {
                    Primler.SetSatTemTah(Convert.ToInt32(((DataRowView)gridControl3.MainView.GetRow(i)).Row.ItemArray[0]), Convert.ToDouble(test1.Text.Trim()));

                    ((DevExpress.XtraGrid.Views.Grid.GridView)gridControl3.MainView).SetRowCellValue(i, "PRM_TAH", Convert.ToDouble(test1.Text.Trim()));

                    progressBarControl1.PerformStep();
                    progressBarControl1.Update();
                    lcProgress.Text = "1. veri giriliyor... " + (i + 1).ToString() + " / " + gridControl3.MainView.RowCount.ToString();
                }
            }
            if (test2.Text.Trim() != string.Empty)
            {
                progressBarControl1.Text = string.Empty;
                progressBarControl1.Properties.Maximum = gridControl3.MainView.RowCount;
                lcProgress.Text = "2. veri giriliyor...";

                for (int i = 0; i < gridControl3.MainView.RowCount; i++)
                {
                    Primler.SetSatTemSat(Convert.ToInt32(((DataRowView)gridControl3.MainView.GetRow(i)).Row.ItemArray[0]), Convert.ToDouble(test2.Text.Trim()));

                    ((DevExpress.XtraGrid.Views.Grid.GridView)gridControl3.MainView).SetRowCellValue(i, "PRM_SAT", Convert.ToDouble(test2.Text.Trim()));

                    progressBarControl1.PerformStep();
                    progressBarControl1.Update();
                    lcProgress.Text = "2. veri giriliyor... " + (i + 1).ToString() + " / " + gridControl3.MainView.RowCount.ToString();
                }
            }
            if (test3.Text.Trim() != string.Empty)
            {
                progressBarControl1.Text = string.Empty;
                progressBarControl1.Properties.Maximum = gridControl3.MainView.RowCount;
                lcProgress.Text = "3. veri giriliyor...";

                for (int i = 0; i < gridControl3.MainView.RowCount; i++)
                {
                    Primler.SetSatTemNok(Convert.ToInt32(((DataRowView)gridControl3.MainView.GetRow(i)).Row.ItemArray[0]), Convert.ToDouble(test3.Text.Trim()));

                    ((DevExpress.XtraGrid.Views.Grid.GridView)gridControl3.MainView).SetRowCellValue(i, "PRM_NOK", Convert.ToDouble(test3.Text.Trim()));

                    progressBarControl1.PerformStep();
                    progressBarControl1.Update();
                    lcProgress.Text = "3. veri giriliyor... " + (i + 1).ToString() + " / " + gridControl3.MainView.RowCount.ToString();
                }
            }
            if (test4.Text.Trim() != string.Empty)
            {
                progressBarControl1.Text = string.Empty;
                progressBarControl1.Properties.Maximum = gridControl3.MainView.RowCount;
                lcProgress.Text = "4. veri giriliyor...";

                for (int i = 0; i < gridControl3.MainView.RowCount; i++)
                {
                    Primler.SetSatTem4(Convert.ToInt32(((DataRowView)gridControl3.MainView.GetRow(i)).Row.ItemArray[0]), Convert.ToDouble(test4.Text.Trim()));

                    ((DevExpress.XtraGrid.Views.Grid.GridView)gridControl3.MainView).SetRowCellValue(i, "PRM_4", Convert.ToDouble(test4.Text.Trim()));

                    progressBarControl1.PerformStep();
                    progressBarControl1.Update();
                    lcProgress.Text = "4. veri giriliyor... " + (i + 1).ToString() + " / " + gridControl3.MainView.RowCount.ToString();
                }
            }
            if (test5.Text.Trim() != string.Empty)
            {
                progressBarControl1.Text = string.Empty;
                progressBarControl1.Properties.Maximum = gridControl3.MainView.RowCount;
                lcProgress.Text = "5. veri giriliyor...";

                for (int i = 0; i < gridControl3.MainView.RowCount; i++)
                {
                    Primler.SetSatTem5(Convert.ToInt32(((DataRowView)gridControl3.MainView.GetRow(i)).Row.ItemArray[0]), Convert.ToDouble(test5.Text.Trim()));

                    ((DevExpress.XtraGrid.Views.Grid.GridView)gridControl3.MainView).SetRowCellValue(i, "PRM_5", Convert.ToDouble(test5.Text.Trim()));

                    progressBarControl1.PerformStep();
                    progressBarControl1.Update();
                    lcProgress.Text = "5. veri giriliyor... " + (i + 1).ToString() + " / " + gridControl3.MainView.RowCount.ToString();
                }
            }

            test1.Text = string.Empty; test2.Text = string.Empty; test3.Text = string.Empty; test4.Text = string.Empty; test5.Text = string.Empty;

            progressBarControl1.PerformStep();
            lcProgress.Text = "Form hazýr.";
            metroShell1.Enabled = true;

            DevComponents.DotNetBar.MessageBoxEx.Show("Ýþlem tamamlandý.", "Baþarýlý", MessageBoxButtons.OK, MessageBoxIcon.Information);
            progressBarControl1.Text = string.Empty;
        }

        private void gridView3_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            switch (e.Column.Name)
            {
                case "gcstARC_CRP":
                    Primler.SetSatTemARC_CRP(Convert.ToInt32(((DataRowView)gridControl3.MainView.GetRow(e.RowHandle)).Row.ItemArray[0]), Convert.ToDouble(e.Value));
                    break;
                case "gcstONC1":
                    Primler.SetSatTemONC(Convert.ToInt32(((DataRowView)gridControl3.MainView.GetRow(e.RowHandle)).Row.ItemArray[0]), "1", Convert.ToInt32(e.Value));
                    break;
                case "gcstPRM_TAH":
                    Primler.SetSatTemTah(Convert.ToInt32(((DataRowView)gridControl3.MainView.GetRow(e.RowHandle)).Row.ItemArray[0]), Convert.ToDouble(e.Value));
                    break;
                case "gcstONC2":
                    Primler.SetSatTemONC(Convert.ToInt32(((DataRowView)gridControl3.MainView.GetRow(e.RowHandle)).Row.ItemArray[0]), "2", Convert.ToInt32(e.Value));
                    break;
                case "gcstPRM_SAT":
                    Primler.SetSatTemSat(Convert.ToInt32(((DataRowView)gridControl3.MainView.GetRow(e.RowHandle)).Row.ItemArray[0]), Convert.ToDouble(e.Value));
                    break;
                case "gcstONC3":
                    Primler.SetSatTemONC(Convert.ToInt32(((DataRowView)gridControl3.MainView.GetRow(e.RowHandle)).Row.ItemArray[0]), "3", Convert.ToInt32(e.Value));
                    break;
                case "gcstPRM_NOK":
                    Primler.SetSatTemNok(Convert.ToInt32(((DataRowView)gridControl3.MainView.GetRow(e.RowHandle)).Row.ItemArray[0]), Convert.ToDouble(e.Value));
                    break;
                case "gcstONC4":
                    Primler.SetSatTemONC(Convert.ToInt32(((DataRowView)gridControl3.MainView.GetRow(e.RowHandle)).Row.ItemArray[0]), "4", Convert.ToInt32(e.Value));
                    break;
                case "gcstPRM_4":
                    Primler.SetSatTem4(Convert.ToInt32(((DataRowView)gridControl3.MainView.GetRow(e.RowHandle)).Row.ItemArray[0]), Convert.ToDouble(e.Value));
                    break;
                case "gcstONC5":
                    Primler.SetSatTemONC(Convert.ToInt32(((DataRowView)gridControl3.MainView.GetRow(e.RowHandle)).Row.ItemArray[0]), "5", Convert.ToInt32(e.Value));
                    break;
                case "gcstPRM_5":
                    Primler.SetSatTem5(Convert.ToInt32(((DataRowView)gridControl3.MainView.GetRow(e.RowHandle)).Row.ItemArray[0]), Convert.ToDouble(e.Value));
                    break;
            }
        }

        private void sbstTopluVeri_Click(object sender, EventArgs e)
        {
            try
            {
                if (test1.Text.Trim() != string.Empty) Convert.ToDouble(test1.Text.Trim());
                if (test2.Text.Trim() != string.Empty) Convert.ToDouble(test2.Text.Trim());
                if (test3.Text.Trim() != string.Empty) Convert.ToDouble(test3.Text.Trim());
                if (test4.Text.Trim() != string.Empty) Convert.ToDouble(test4.Text.Trim());
                if (test5.Text.Trim() != string.Empty) Convert.ToDouble(test5.Text.Trim());
            }
            catch (Exception)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Girilen verilerde hata var.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (DevComponents.DotNetBar.MessageBoxEx.Show("Ýþlem uzun sürebilir, bu esnada programý kapatmayýnýz. Devam etmek istediðinize emin misiniz?", "Devam", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
            {
                thr = new Thread(new ThreadStart(ST_TopluVeri));
                thr.Start();
            }
        }

        #endregion

        #region Cari Hesap

        private void CH_TopluVeri()
        {
            metroShell1.Enabled = false;

            if (tech1.Text.Trim() != string.Empty)
            {
                progressBarControl1.Text = string.Empty;
                progressBarControl1.Properties.Maximum = gridControl4.MainView.RowCount;
                lcProgress.Text = "1. veri giriliyor...";

                for (int i = 0; i < gridControl4.MainView.RowCount; i++)
                {
                    Primler.SetCariHesapTah(Convert.ToInt32(((DataRowView)gridControl4.MainView.GetRow(i)).Row.ItemArray[0]), Convert.ToDouble(tech1.Text.Trim()));

                    ((DevExpress.XtraGrid.Views.Grid.GridView)gridControl4.MainView).SetRowCellValue(i, "PRM_TAH", Convert.ToDouble(tech1.Text.Trim()));

                    progressBarControl1.PerformStep();
                    progressBarControl1.Update();
                    lcProgress.Text = "1. veri giriliyor... " + (i + 1).ToString() + " / " + gridControl4.MainView.RowCount.ToString();
                }
            }
            if (tech2.Text.Trim() != string.Empty)
            {
                progressBarControl1.Text = string.Empty;
                progressBarControl1.Properties.Maximum = gridControl4.MainView.RowCount;
                lcProgress.Text = "2. veri giriliyor...";

                for (int i = 0; i < gridControl4.MainView.RowCount; i++)
                {
                    Primler.SetCariHesapSat(Convert.ToInt32(((DataRowView)gridControl4.MainView.GetRow(i)).Row.ItemArray[0]), Convert.ToDouble(tech2.Text.Trim()));

                    ((DevExpress.XtraGrid.Views.Grid.GridView)gridControl4.MainView).SetRowCellValue(i, "PRM_SAT", Convert.ToDouble(tech2.Text.Trim()));

                    progressBarControl1.PerformStep();
                    progressBarControl1.Update();
                    lcProgress.Text = "2. veri giriliyor... " + (i + 1).ToString() + " / " + gridControl4.MainView.RowCount.ToString();
                }
            }
            if (tech3.Text.Trim() != string.Empty)
            {
                progressBarControl1.Text = string.Empty;
                progressBarControl1.Properties.Maximum = gridControl4.MainView.RowCount;
                lcProgress.Text = "3. veri giriliyor...";

                for (int i = 0; i < gridControl4.MainView.RowCount; i++)
                {
                    Primler.SetCariHesapNok(Convert.ToInt32(((DataRowView)gridControl4.MainView.GetRow(i)).Row.ItemArray[0]), Convert.ToDouble(tech3.Text.Trim()));

                    ((DevExpress.XtraGrid.Views.Grid.GridView)gridControl4.MainView).SetRowCellValue(i, "PRM_NOK", Convert.ToDouble(tech3.Text.Trim()));

                    progressBarControl1.PerformStep();
                    progressBarControl1.Update();
                    lcProgress.Text = "3. veri giriliyor... " + (i + 1).ToString() + " / " + gridControl4.MainView.RowCount.ToString();
                }
            }
            if (tech4.Text.Trim() != string.Empty)
            {
                progressBarControl1.Text = string.Empty;
                progressBarControl1.Properties.Maximum = gridControl4.MainView.RowCount;
                lcProgress.Text = "4. veri giriliyor...";

                for (int i = 0; i < gridControl4.MainView.RowCount; i++)
                {
                    Primler.SetCariHesap4(Convert.ToInt32(((DataRowView)gridControl4.MainView.GetRow(i)).Row.ItemArray[0]), Convert.ToDouble(tech4.Text.Trim()));

                    ((DevExpress.XtraGrid.Views.Grid.GridView)gridControl4.MainView).SetRowCellValue(i, "PRM_4", Convert.ToDouble(tech4.Text.Trim()));

                    progressBarControl1.PerformStep();
                    progressBarControl1.Update();
                    lcProgress.Text = "4. veri giriliyor... " + (i + 1).ToString() + " / " + gridControl4.MainView.RowCount.ToString();
                }
            }
            if (tech5.Text.Trim() != string.Empty)
            {
                progressBarControl1.Text = string.Empty;
                progressBarControl1.Properties.Maximum = gridControl4.MainView.RowCount;
                lcProgress.Text = "5. veri giriliyor...";

                for (int i = 0; i < gridControl4.MainView.RowCount; i++)
                {
                    Primler.SetCariHesap5(Convert.ToInt32(((DataRowView)gridControl4.MainView.GetRow(i)).Row.ItemArray[0]), Convert.ToDouble(tech5.Text.Trim()));

                    ((DevExpress.XtraGrid.Views.Grid.GridView)gridControl4.MainView).SetRowCellValue(i, "PRM_5", Convert.ToDouble(tech5.Text.Trim()));

                    progressBarControl1.PerformStep();
                    progressBarControl1.Update();
                    lcProgress.Text = "5. veri giriliyor... " + (i + 1).ToString() + " / " + gridControl4.MainView.RowCount.ToString();
                }
            }

            tech1.Text = string.Empty; tech2.Text = string.Empty; tech3.Text = string.Empty; tech4.Text = string.Empty; tech5.Text = string.Empty;

            progressBarControl1.PerformStep();
            lcProgress.Text = "Form hazýr.";
            metroShell1.Enabled = true;

            DevComponents.DotNetBar.MessageBoxEx.Show("Ýþlem tamamlandý.", "Baþarýlý", MessageBoxButtons.OK, MessageBoxIcon.Information);
            progressBarControl1.Text = string.Empty;
        }

        private void gridView4_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            switch (e.Column.Name)
            {
                case "gcchARC_CRP":
                    Primler.SetCariHesapARC_CRP(Convert.ToInt32(((DataRowView)gridControl4.MainView.GetRow(e.RowHandle)).Row.ItemArray[0]), Convert.ToDouble(e.Value));
                    break;
                case "gcchONC1":
                    Primler.SetCariHesapONC(Convert.ToInt32(((DataRowView)gridControl4.MainView.GetRow(e.RowHandle)).Row.ItemArray[0]), "1", Convert.ToInt32(e.Value));
                    break;
                case "gcchPRM_TAH":
                    Primler.SetCariHesapTah(Convert.ToInt32(((DataRowView)gridControl4.MainView.GetRow(e.RowHandle)).Row.ItemArray[0]), Convert.ToDouble(e.Value));
                    break;
                case "gcchONC2":
                    Primler.SetCariHesapONC(Convert.ToInt32(((DataRowView)gridControl4.MainView.GetRow(e.RowHandle)).Row.ItemArray[0]), "2", Convert.ToInt32(e.Value));
                    break;
                case "gcchPRM_SAT":
                    Primler.SetCariHesapSat(Convert.ToInt32(((DataRowView)gridControl4.MainView.GetRow(e.RowHandle)).Row.ItemArray[0]), Convert.ToDouble(e.Value));
                    break;
                case "gcchONC3":
                    Primler.SetCariHesapONC(Convert.ToInt32(((DataRowView)gridControl4.MainView.GetRow(e.RowHandle)).Row.ItemArray[0]), "3", Convert.ToInt32(e.Value));
                    break;
                case "gcchPRM_NOK":
                    Primler.SetCariHesapNok(Convert.ToInt32(((DataRowView)gridControl4.MainView.GetRow(e.RowHandle)).Row.ItemArray[0]), Convert.ToDouble(e.Value));
                    break;
                case "gcchONC4":
                    Primler.SetCariHesapONC(Convert.ToInt32(((DataRowView)gridControl4.MainView.GetRow(e.RowHandle)).Row.ItemArray[0]), "4", Convert.ToInt32(e.Value));
                    break;
                case "gcchPRM_4":
                    Primler.SetCariHesap4(Convert.ToInt32(((DataRowView)gridControl4.MainView.GetRow(e.RowHandle)).Row.ItemArray[0]), Convert.ToDouble(e.Value));
                    break;
                case "gcchONC5":
                    Primler.SetCariHesapONC(Convert.ToInt32(((DataRowView)gridControl4.MainView.GetRow(e.RowHandle)).Row.ItemArray[0]), "5", Convert.ToInt32(e.Value));
                    break;
                case "gcchPRM_5":
                    Primler.SetCariHesap5(Convert.ToInt32(((DataRowView)gridControl4.MainView.GetRow(e.RowHandle)).Row.ItemArray[0]), Convert.ToDouble(e.Value));
                    break;
            }
        }

        private void sbchTopluVeri_Click(object sender, EventArgs e)
        {
            try
            {
                if (tech1.Text.Trim() != string.Empty) Convert.ToDouble(tech1.Text.Trim());
                if (tech2.Text.Trim() != string.Empty) Convert.ToDouble(tech2.Text.Trim());
                if (tech3.Text.Trim() != string.Empty) Convert.ToDouble(tech3.Text.Trim());
                if (tech4.Text.Trim() != string.Empty) Convert.ToDouble(tech4.Text.Trim());
                if (tech5.Text.Trim() != string.Empty) Convert.ToDouble(tech5.Text.Trim());
            }
            catch (Exception)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Girilen verilerde hata var.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (DevComponents.DotNetBar.MessageBoxEx.Show("Ýþlem uzun sürebilir, bu esnada programý kapatmayýnýz. Devam etmek istediðinize emin misiniz?", "Devam", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
            {
                thr = new Thread(new ThreadStart(CH_TopluVeri));
                thr.Start();
            }
        }

        #endregion

        #region Fiyat Tip

        private void FT_TopluVeri()
        {
            metroShell1.Enabled = false;

            if (teft1.Text.Trim() != string.Empty)
            {
                progressBarControl1.Text = string.Empty;
                progressBarControl1.Properties.Maximum = gridControl6.MainView.RowCount;
                lcProgress.Text = "1. veri giriliyor...";

                for (int i = 0; i < gridControl6.MainView.RowCount; i++)
                {
                    Primler.SetFiyatTipTah(((DataRowView)gridControl6.MainView.GetRow(i)).Row.ItemArray[0].ToString(), Convert.ToDouble(teft1.Text.Trim()));

                    ((DevExpress.XtraGrid.Views.Grid.GridView)gridControl6.MainView).SetRowCellValue(i, "PRM_TAH", Convert.ToDouble(teft1.Text.Trim()));

                    progressBarControl1.PerformStep();
                    progressBarControl1.Update();
                    lcProgress.Text = "1. veri giriliyor... " + (i + 1).ToString() + " / " + gridControl6.MainView.RowCount.ToString();
                }
            }
            if (teft2.Text.Trim() != string.Empty)
            {
                progressBarControl1.Text = string.Empty;
                progressBarControl1.Properties.Maximum = gridControl6.MainView.RowCount;
                lcProgress.Text = "2. veri giriliyor...";

                for (int i = 0; i < gridControl6.MainView.RowCount; i++)
                {
                    Primler.SetFiyatTipSat(((DataRowView)gridControl6.MainView.GetRow(i)).Row.ItemArray[0].ToString(), Convert.ToDouble(teft2.Text.Trim()));

                    ((DevExpress.XtraGrid.Views.Grid.GridView)gridControl6.MainView).SetRowCellValue(i, "PRM_SAT", Convert.ToDouble(teft2.Text.Trim()));

                    progressBarControl1.PerformStep();
                    progressBarControl1.Update();
                    lcProgress.Text = "2. veri giriliyor... " + (i + 1).ToString() + " / " + gridControl6.MainView.RowCount.ToString();
                }
            }
            if (teft3.Text.Trim() != string.Empty)
            {
                progressBarControl1.Text = string.Empty;
                progressBarControl1.Properties.Maximum = gridControl6.MainView.RowCount;
                lcProgress.Text = "3. veri giriliyor...";

                for (int i = 0; i < gridControl6.MainView.RowCount; i++)
                {
                    Primler.SetFiyatTipNok(((DataRowView)gridControl6.MainView.GetRow(i)).Row.ItemArray[0].ToString(), Convert.ToDouble(teft3.Text.Trim()));

                    ((DevExpress.XtraGrid.Views.Grid.GridView)gridControl6.MainView).SetRowCellValue(i, "PRM_NOK", Convert.ToDouble(teft3.Text.Trim()));

                    progressBarControl1.PerformStep();
                    progressBarControl1.Update();
                    lcProgress.Text = "3. veri giriliyor... " + (i + 1).ToString() + " / " + gridControl6.MainView.RowCount.ToString();
                }
            }
            if (teft4.Text.Trim() != string.Empty)
            {
                progressBarControl1.Text = string.Empty;
                progressBarControl1.Properties.Maximum = gridControl6.MainView.RowCount;
                lcProgress.Text = "4. veri giriliyor...";

                for (int i = 0; i < gridControl6.MainView.RowCount; i++)
                {
                    Primler.SetFiyatTip4(((DataRowView)gridControl6.MainView.GetRow(i)).Row.ItemArray[0].ToString(), Convert.ToDouble(teft4.Text.Trim()));

                    ((DevExpress.XtraGrid.Views.Grid.GridView)gridControl6.MainView).SetRowCellValue(i, "PRM_4", Convert.ToDouble(teft4.Text.Trim()));

                    progressBarControl1.PerformStep();
                    progressBarControl1.Update();
                    lcProgress.Text = "4. veri giriliyor... " + (i + 1).ToString() + " / " + gridControl6.MainView.RowCount.ToString();
                }
            }
            if (teft5.Text.Trim() != string.Empty)
            {
                progressBarControl1.Text = string.Empty;
                progressBarControl1.Properties.Maximum = gridControl6.MainView.RowCount;
                lcProgress.Text = "5. veri giriliyor...";

                for (int i = 0; i < gridControl6.MainView.RowCount; i++)
                {
                    Primler.SetFiyatTip5(((DataRowView)gridControl6.MainView.GetRow(i)).Row.ItemArray[0].ToString(), Convert.ToDouble(teft5.Text.Trim()));

                    ((DevExpress.XtraGrid.Views.Grid.GridView)gridControl6.MainView).SetRowCellValue(i, "PRM_5", Convert.ToDouble(teft5.Text.Trim()));

                    progressBarControl1.PerformStep();
                    progressBarControl1.Update();
                    lcProgress.Text = "5. veri giriliyor... " + (i + 1).ToString() + " / " + gridControl6.MainView.RowCount.ToString();
                }
            }

            teft1.Text = string.Empty; teft2.Text = string.Empty; teft3.Text = string.Empty; teft4.Text = string.Empty; teft5.Text = string.Empty;

            progressBarControl1.PerformStep();
            lcProgress.Text = "Form hazýr.";
            metroShell1.Enabled = true;

            DevComponents.DotNetBar.MessageBoxEx.Show("Ýþlem tamamlandý.", "Baþarýlý", MessageBoxButtons.OK, MessageBoxIcon.Information);
            progressBarControl1.Text = string.Empty;
        }

        private void gridView6_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            switch (e.Column.Name)
            {
                case "gcftPRM_TAH":
                    Primler.SetFiyatTipTah(((DataRowView)gridControl6.MainView.GetRow(e.RowHandle)).Row.ItemArray[0].ToString(), Convert.ToDouble(e.Value));
                    break;
                case "gcftPRM_SAT":
                    Primler.SetFiyatTipSat(((DataRowView)gridControl6.MainView.GetRow(e.RowHandle)).Row.ItemArray[0].ToString(), Convert.ToDouble(e.Value));
                    break;
                case "gcftPRM_NOK":
                    Primler.SetFiyatTipNok(((DataRowView)gridControl6.MainView.GetRow(e.RowHandle)).Row.ItemArray[0].ToString(), Convert.ToDouble(e.Value));
                    break;
                case "gcftPRM_4":
                    Primler.SetFiyatTip4(((DataRowView)gridControl6.MainView.GetRow(e.RowHandle)).Row.ItemArray[0].ToString(), Convert.ToDouble(e.Value));
                    break;
                case "gcftPRM_5":
                    Primler.SetFiyatTip5(((DataRowView)gridControl6.MainView.GetRow(e.RowHandle)).Row.ItemArray[0].ToString(), Convert.ToDouble(e.Value));
                    break;
            }
        }

        private void sbftTopluVeri_Click(object sender, EventArgs e)
        {
            try
            {
                if (teft1.Text.Trim() != string.Empty) Convert.ToDouble(teft1.Text.Trim());
                if (teft2.Text.Trim() != string.Empty) Convert.ToDouble(teft2.Text.Trim());
                if (teft3.Text.Trim() != string.Empty) Convert.ToDouble(teft3.Text.Trim());
                if (teft4.Text.Trim() != string.Empty) Convert.ToDouble(teft4.Text.Trim());
                if (teft5.Text.Trim() != string.Empty) Convert.ToDouble(teft5.Text.Trim());
            }
            catch (Exception)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Girilen verilerde hata var.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (DevComponents.DotNetBar.MessageBoxEx.Show("Ýþlem uzun sürebilir, bu esnada programý kapatmayýnýz. Devam etmek istediðinize emin misiniz?", "Devam", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
            {
                thr = new Thread(new ThreadStart(FT_TopluVeri));
                thr.Start();
            }
        }

        #endregion

        #region Tedarik Gruplarý

        private void TG_TopluVeri()
        {
            metroShell1.Enabled = false;

            if (tetg1.Text.Trim() != string.Empty)
            {
                progressBarControl1.Text = string.Empty;
                progressBarControl1.Properties.Maximum = gridControl5.MainView.RowCount;
                lcProgress.Text = "1. veri giriliyor...";

                for (int i = 0; i < gridControl5.MainView.RowCount; i++)
                {
                    Primler.SetTedarikGrupTah(((DataRowView)gridControl5.MainView.GetRow(i)).Row.ItemArray[0].ToString(), ((DataRowView)gridControl5.MainView.GetRow(i)).Row.ItemArray[1].ToString(), Convert.ToDouble(tetg1.Text.Trim()));

                    ((DevExpress.XtraGrid.Views.Grid.GridView)gridControl5.MainView).SetRowCellValue(i, "PRM_TAH", Convert.ToDouble(tetg1.Text.Trim()));

                    progressBarControl1.PerformStep();
                    progressBarControl1.Update();
                    lcProgress.Text = "1. veri giriliyor... " + (i + 1).ToString() + " / " + gridControl5.MainView.RowCount.ToString();
                }
            }
            if (tetg2.Text.Trim() != string.Empty)
            {
                progressBarControl1.Text = string.Empty;
                progressBarControl1.Properties.Maximum = gridControl5.MainView.RowCount;
                lcProgress.Text = "2. veri giriliyor...";

                for (int i = 0; i < gridControl5.MainView.RowCount; i++)
                {
                    Primler.SetTedarikGrupSat(((DataRowView)gridControl5.MainView.GetRow(i)).Row.ItemArray[0].ToString(), ((DataRowView)gridControl5.MainView.GetRow(i)).Row.ItemArray[1].ToString(), Convert.ToDouble(tetg2.Text.Trim()));

                    ((DevExpress.XtraGrid.Views.Grid.GridView)gridControl5.MainView).SetRowCellValue(i, "PRM_SAT", Convert.ToDouble(tetg2.Text.Trim()));

                    progressBarControl1.PerformStep();
                    progressBarControl1.Update();
                    lcProgress.Text = "2. veri giriliyor... " + (i + 1).ToString() + " / " + gridControl5.MainView.RowCount.ToString();
                }
            }
            if (tetg3.Text.Trim() != string.Empty)
            {
                progressBarControl1.Text = string.Empty;
                progressBarControl1.Properties.Maximum = gridControl5.MainView.RowCount;
                lcProgress.Text = "3. veri giriliyor...";

                for (int i = 0; i < gridControl5.MainView.RowCount; i++)
                {
                    Primler.SetTedarikGrupNok(((DataRowView)gridControl5.MainView.GetRow(i)).Row.ItemArray[0].ToString(), ((DataRowView)gridControl5.MainView.GetRow(i)).Row.ItemArray[1].ToString(), Convert.ToDouble(tetg3.Text.Trim()));

                    ((DevExpress.XtraGrid.Views.Grid.GridView)gridControl5.MainView).SetRowCellValue(i, "PRM_NOK", Convert.ToDouble(tetg3.Text.Trim()));

                    progressBarControl1.PerformStep();
                    progressBarControl1.Update();
                    lcProgress.Text = "3. veri giriliyor... " + (i + 1).ToString() + " / " + gridControl5.MainView.RowCount.ToString();
                }
            }
            if (tetg4.Text.Trim() != string.Empty)
            {
                progressBarControl1.Text = string.Empty;
                progressBarControl1.Properties.Maximum = gridControl5.MainView.RowCount;
                lcProgress.Text = "4. veri giriliyor...";

                for (int i = 0; i < gridControl5.MainView.RowCount; i++)
                {
                    Primler.SetTedarikGrup4(((DataRowView)gridControl5.MainView.GetRow(i)).Row.ItemArray[0].ToString(), ((DataRowView)gridControl5.MainView.GetRow(i)).Row.ItemArray[1].ToString(), Convert.ToDouble(tetg4.Text.Trim()));

                    ((DevExpress.XtraGrid.Views.Grid.GridView)gridControl5.MainView).SetRowCellValue(i, "PRM_4", Convert.ToDouble(tetg4.Text.Trim()));

                    progressBarControl1.PerformStep();
                    progressBarControl1.Update();
                    lcProgress.Text = "4. veri giriliyor... " + (i + 1).ToString() + " / " + gridControl5.MainView.RowCount.ToString();
                }
            }
            if (tetg5.Text.Trim() != string.Empty)
            {
                progressBarControl1.Text = string.Empty;
                progressBarControl1.Properties.Maximum = gridControl5.MainView.RowCount;
                lcProgress.Text = "5. veri giriliyor...";

                for (int i = 0; i < gridControl5.MainView.RowCount; i++)
                {
                    Primler.SetTedarikGrup5(((DataRowView)gridControl5.MainView.GetRow(i)).Row.ItemArray[0].ToString(), ((DataRowView)gridControl5.MainView.GetRow(i)).Row.ItemArray[1].ToString(), Convert.ToDouble(tetg5.Text.Trim()));

                    ((DevExpress.XtraGrid.Views.Grid.GridView)gridControl5.MainView).SetRowCellValue(i, "PRM_5", Convert.ToDouble(tetg5.Text.Trim()));

                    progressBarControl1.PerformStep();
                    progressBarControl1.Update();
                    lcProgress.Text = "5. veri giriliyor... " + (i + 1).ToString() + " / " + gridControl5.MainView.RowCount.ToString();
                }
            }

            tetg1.Text = string.Empty; tetg2.Text = string.Empty; tetg3.Text = string.Empty; tetg4.Text = string.Empty; tetg5.Text = string.Empty;

            progressBarControl1.PerformStep();
            lcProgress.Text = "Form hazýr.";
            metroShell1.Enabled = true;

            DevComponents.DotNetBar.MessageBoxEx.Show("Ýþlem tamamlandý.", "Baþarýlý", MessageBoxButtons.OK, MessageBoxIcon.Information);
            progressBarControl1.Text = string.Empty;
        }

        private void gridView5_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            switch (e.Column.Name)
            {
                case "gctgONC1":
                    Primler.SetTedarikGrupONC(((DataRowView)gridControl5.MainView.GetRow(e.RowHandle)).Row.ItemArray[0].ToString(), ((DataRowView)gridControl5.MainView.GetRow(e.RowHandle)).Row.ItemArray[1].ToString(), "1", Convert.ToInt32(e.Value));
                    break;
                case "gctgPRM_TAH":
                    Primler.SetTedarikGrupTah(((DataRowView)gridControl5.MainView.GetRow(e.RowHandle)).Row.ItemArray[0].ToString(), ((DataRowView)gridControl5.MainView.GetRow(e.RowHandle)).Row.ItemArray[1].ToString(), Convert.ToDouble(e.Value));
                    break;
                case "gctgONC2":
                    Primler.SetTedarikGrupONC(((DataRowView)gridControl5.MainView.GetRow(e.RowHandle)).Row.ItemArray[0].ToString(), ((DataRowView)gridControl5.MainView.GetRow(e.RowHandle)).Row.ItemArray[1].ToString(), "2", Convert.ToInt32(e.Value));
                    break;
                case "gctgPRM_SAT":
                    Primler.SetTedarikGrupSat(((DataRowView)gridControl5.MainView.GetRow(e.RowHandle)).Row.ItemArray[0].ToString(), ((DataRowView)gridControl5.MainView.GetRow(e.RowHandle)).Row.ItemArray[1].ToString(), Convert.ToDouble(e.Value));
                    break;
                case "gctgONC3":
                    Primler.SetTedarikGrupONC(((DataRowView)gridControl5.MainView.GetRow(e.RowHandle)).Row.ItemArray[0].ToString(), ((DataRowView)gridControl5.MainView.GetRow(e.RowHandle)).Row.ItemArray[1].ToString(), "3", Convert.ToInt32(e.Value));
                    break;
                case "gctgPRM_NOK":
                    Primler.SetTedarikGrupNok(((DataRowView)gridControl5.MainView.GetRow(e.RowHandle)).Row.ItemArray[0].ToString(), ((DataRowView)gridControl5.MainView.GetRow(e.RowHandle)).Row.ItemArray[1].ToString(), Convert.ToDouble(e.Value));
                    break;
                case "gctgONC4":
                    Primler.SetTedarikGrupONC(((DataRowView)gridControl5.MainView.GetRow(e.RowHandle)).Row.ItemArray[0].ToString(), ((DataRowView)gridControl5.MainView.GetRow(e.RowHandle)).Row.ItemArray[1].ToString(), "4", Convert.ToInt32(e.Value));
                    break;
                case "gctgPRM_4":
                    Primler.SetTedarikGrup4(((DataRowView)gridControl5.MainView.GetRow(e.RowHandle)).Row.ItemArray[0].ToString(), ((DataRowView)gridControl5.MainView.GetRow(e.RowHandle)).Row.ItemArray[1].ToString(), Convert.ToDouble(e.Value));
                    break;
                case "gctgONC5":
                    Primler.SetTedarikGrupONC(((DataRowView)gridControl5.MainView.GetRow(e.RowHandle)).Row.ItemArray[0].ToString(), ((DataRowView)gridControl5.MainView.GetRow(e.RowHandle)).Row.ItemArray[1].ToString(), "5", Convert.ToInt32(e.Value));
                    break;
                case "gctgPRM_5":
                    Primler.SetTedarikGrup5(((DataRowView)gridControl5.MainView.GetRow(e.RowHandle)).Row.ItemArray[0].ToString(), ((DataRowView)gridControl5.MainView.GetRow(e.RowHandle)).Row.ItemArray[1].ToString(), Convert.ToDouble(e.Value));
                    break;
            }
        }

        private void sbtgTopluVeri_Click(object sender, EventArgs e)
        {
            try
            {
                if (tetg1.Text.Trim() != string.Empty) Convert.ToDouble(tetg1.Text.Trim());
                if (tetg2.Text.Trim() != string.Empty) Convert.ToDouble(tetg2.Text.Trim());
                if (tetg3.Text.Trim() != string.Empty) Convert.ToDouble(tetg3.Text.Trim());
                if (tetg4.Text.Trim() != string.Empty) Convert.ToDouble(tetg4.Text.Trim());
                if (tetg5.Text.Trim() != string.Empty) Convert.ToDouble(tetg5.Text.Trim());
            }
            catch (Exception)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Girilen verilerde hata var.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (DevComponents.DotNetBar.MessageBoxEx.Show("Ýþlem uzun sürebilir, bu esnada programý kapatmayýnýz. Devam etmek istediðinize emin misiniz?", "Devam", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
            {
                thr = new Thread(new ThreadStart(TG_TopluVeri));
                thr.Start();
            }
        }

        #endregion
    }
}
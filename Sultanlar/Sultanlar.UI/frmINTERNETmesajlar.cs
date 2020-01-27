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
using DgvFilterPopup;
using System.Runtime.InteropServices;

namespace Sultanlar.UI
{
    public partial class frmINTERNETmesajlar : Form
    {
        public frmINTERNETmesajlar()
        {
            InitializeComponent();
        }

        DgvFilterManager dgvfm;
        Timer tmr;

        private void frmINTERNETmesajlar_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Value = Convert.ToDateTime("01.01." + DateTime.Now.Year.ToString() + " 00:00:00");
            GetDepartmanlar();
            cmbDepartmanlar.SelectedIndex = 0;

            tmr = new Timer();
            tmr.Interval = 300000;
            tmr.Tick += new EventHandler(tmr_Tick);
            tmr.Start();
        }

        private void tmr_Tick(object sender, EventArgs e)
        {
            bool var = false;

            for (int i = 0; i < cmbDepartmanlar.Items.Count; i++)
            {
                DataTable dt = new DataTable();
                AlinanMesajlar.GetObjects(dt, ((Departmanlar)cmbDepartmanlar.Items[i]).pkDepartmanID, dateTimePicker1.Value);

                for (int j = 0; j < dt.Rows.Count; i++)
                {
                    if (!(bool)dt.Rows[j]["blOkundu"])
                    {
                        var = true;
                        break;
                    }
                }

                if (var)
                    break;
            }

            if (var)
                FlashWindowEx((frmAna)this.MdiParent);
        }

        private void Temizle()
        {
            txtKonu.Text = string.Empty;
            txtMesaj.Text = string.Empty;
            lblZaman.Text = string.Empty;
        }

        private void GetDepartmanlar()
        {
            Departmanlar.GetObject(cmbDepartmanlar.Items, true);

            ArrayList silinecekler = new ArrayList();
            silinecekler.Add("Depo");
            silinecekler.Add("Mali İşler");

            for (int i = 0; i < silinecekler.Count; i++)
            {
                for (int j = 0; j < cmbDepartmanlar.Items.Count; j++)
                {
                    if (cmbDepartmanlar.Items[j].ToString() == silinecekler[i].ToString())
                    {
                        cmbDepartmanlar.Items.RemoveAt(j);
                        break;
                    }
                }
            }

            YetkiBelirle();
        }

        private void YetkiBelirle()
        {
            string KAdi = frmAna.KAdi;

            ArrayList silinecekler = new ArrayList();
            silinecekler.Add("Bilgi İşlem");
            silinecekler.Add("Finans");
            silinecekler.Add("İade Fiyatlandırma");
            silinecekler.Add("İade Kabul");
            silinecekler.Add("İdari İşler");
            silinecekler.Add("Lojistik");
            silinecekler.Add("Müşteri İlişkileri");
            silinecekler.Add("Satış");
            silinecekler.Add("Yönetim");
            silinecekler.Add("Satın Alma");
            silinecekler.Add("Pazarlama");
            silinecekler.Add("İnsan Kaynakları ve Eğitim");
            silinecekler.Add("Raporlama");
            silinecekler.Add("Ticari Pazarlama");

            if (KAdi.ToUpper() == "BI04" || KAdi.ToUpper() == "ADMİNİSTRATOR")
            {
                silinecekler.Remove("Bilgi İşlem");
                silinecekler.Remove("Finans");
                silinecekler.Remove("İade Fiyatlandırma");
                silinecekler.Remove("İade Kabul");
                silinecekler.Remove("İdari İşler");
                silinecekler.Remove("Lojistik");
                silinecekler.Remove("Müşteri İlişkileri");
                silinecekler.Remove("Satış");
                silinecekler.Remove("Yönetim");
                silinecekler.Remove("Satın Alma");
                silinecekler.Remove("Pazarlama");
                silinecekler.Remove("İnsan Kaynakları ve Eğitim");
                silinecekler.Remove("Raporlama");
                silinecekler.Remove("Ticari Pazarlama");
            }
            else if (KAdi.ToUpper() == "MI05" || KAdi.ToUpper() == "FN03" || KAdi.ToUpper() == "FN09")
            {
                silinecekler.Remove("Finans");
            }
            else if (KAdi.ToUpper() == "IH03")
            {
                silinecekler.Remove("İdari İşler");
            }
            else if (KAdi.ToUpper() == "SUL02" || KAdi.ToUpper() == "FT01" || KAdi.ToUpper() == "LK06")
            {
                silinecekler.Remove("Lojistik");
            }
            else if (KAdi.ToUpper() == "ST16")
            {
                silinecekler.Remove("Müşteri İlişkileri");
                silinecekler.Remove("İade Fiyatlandırma");
            }
            else if (KAdi.ToUpper() == "SA05")
            {
                silinecekler.Remove("Müşteri İlişkileri");
            }
            else if (KAdi.ToUpper() == "ST03")
            {
                silinecekler.Remove("İade Fiyatlandırma");
            }
            else if (KAdi.ToUpper() == "LK12")
            {
                silinecekler.Remove("İade Kabul");
            }
            else if (KAdi.ToUpper() == "ST12" || KAdi.ToUpper() == "ST09")
            {
                silinecekler.Remove("Satış");
            }
            else if (KAdi.ToUpper() == "YN03" || KAdi.ToUpper() == "YN02")
            {
                silinecekler.Remove("Yönetim");
            }
            else if (KAdi.ToUpper() == "SA08" || KAdi.ToUpper() == "SA06" || KAdi.ToUpper() == "SA03")
            {
                silinecekler.Remove("Satın Alma");
            }
            else if (KAdi.ToUpper() == "ST04")
            {
                silinecekler.Remove("Satış");
            }
            else if (KAdi.ToUpper() == "İSLAMYİLDİZ")
            {
                silinecekler.Remove("Müşteri İlişkileri");
                silinecekler.Remove("Yönetim");
            }
            else if (KAdi.ToUpper() == "ESİNSETOL")
            {
                silinecekler.Remove("Pazarlama");
            }

            for (int i = 0; i < silinecekler.Count; i++)
            {
                for (int j = 0; j < cmbDepartmanlar.Items.Count; j++)
                {
                    if (cmbDepartmanlar.Items[j].ToString() == silinecekler[i].ToString())
                    {
                        cmbDepartmanlar.Items.RemoveAt(j);
                        break;
                    }
                }
            }
        }

        private void GetGelenMesajlar()
        {
            KolonIsimler();

            DataTable dt = new DataTable();
            AlinanMesajlar.GetObjects(dt, ((Departmanlar)cmbDepartmanlar.SelectedItem).pkDepartmanID, dateTimePicker1.Value);
            dataGridView1.DataSource = dt;

            dgvfm = new DgvFilterManager(dataGridView1);

            KolonIsimler();
        }

        private void GetGidenMesajlar()
        {
            KolonIsimler();

            DataTable dt = new DataTable();
            GonderilenMesajlar.GetObjects(dt, ((Departmanlar)cmbDepartmanlar.SelectedItem).pkDepartmanID, dateTimePicker1.Value);
            dataGridView1.DataSource = dt;

            dgvfm = new DgvFilterManager(dataGridView1);

            KolonIsimler();
        }

        private void KolonIsimler()
        {
            dataGridView1.Columns["clpkMesajID"].HeaderText = "Mesaj No";
            dataGridView1.Columns["clstrMusteri"].HeaderText = "Üye";
            dataGridView1.Columns["clstrKonu"].HeaderText = "Konu";
            dataGridView1.Columns["cldtGondermeZamani"].HeaderText = "Gönderme Zamanı";
            dataGridView1.Columns["clblOkundu"].HeaderText = "Okundu";
        }

        private void cmbDepartmanlar_SelectedIndexChanged(object sender, EventArgs e)
        {
            Temizle();
            if (rbGelenKutusu.Checked)
            {
                dataGridView1.Columns["clCevapla"].Visible = true;
                GetGelenMesajlar();
            }
            else if (rbGidenKutusu.Checked)
            {
                dataGridView1.Columns["clCevapla"].Visible = false;
                GetGidenMesajlar();
            }
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Mesaj silinecek. Devam etmek istediğinize emin misiniz?", "Mesaj Silme", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    Temizle();

                    if (rbGelenKutusu.Checked)
                    {
                        AlinanMesajlar.DoDelete(Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["clpkMesajID"].Value), false);
                        dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
                    }
                    else if (rbGidenKutusu.Checked)
                    {
                        GonderilenMesajlar.DoDelete(Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["clpkMesajID"].Value), true);
                        dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
                    }
                }
            }
        }

        private void rbGelenKutusu_CheckedChanged(object sender, EventArgs e)
        {
            if (cmbDepartmanlar.SelectedIndex > -1)
            {
                Temizle();
                dataGridView1.Columns["clCevapla"].Visible = true;
                GetGelenMesajlar();
            }
        }

        private void rbGidenKutusu_CheckedChanged(object sender, EventArgs e)
        {
            if (cmbDepartmanlar.SelectedIndex > -1)
            {
                Temizle();
                dataGridView1.Columns["clCevapla"].Visible = false;
                GetGidenMesajlar();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            if (dataGridView1.Columns[e.ColumnIndex].Name == "clCevapla")
            {
                int MesajID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["clpkMesajID"].Value);
                AlinanMesajlar.DoUpdateOkundu(MesajID, DateTime.Now);
                dataGridView1.Rows[e.RowIndex].Cells["clblOkundu"].Value = true;

                //int index = dataGridView1.SelectedRows[0].Index;

                frmINTERNETmesajyaz frm = new frmINTERNETmesajyaz(
                    ((Departmanlar)cmbDepartmanlar.SelectedItem).pkDepartmanID,
                    Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["clintMusteriID"].Value),
                    Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["clpkMesajID"].Value));
                frm.ShowDialog();

                //if (cmbDepartmanlar.SelectedIndex > -1)
                //{
                //    Temizle();
                //    if (rbGelenKutusu.Checked)
                //    {
                //        dataGridView1.Columns["clCevapla"].Visible = true;
                //        GetGelenMesajlar();
                //    }
                //    else if (rbGidenKutusu.Checked)
                //    {
                //        dataGridView1.Columns["clCevapla"].Visible = false;
                //        GetGidenMesajlar();
                //    }

                //    dataGridView1.Rows[index].Selected = true;
                //}
            }
        }

        private void btnMesajYaz_Click(object sender, EventArgs e)
        {
            if (cmbDepartmanlar.SelectedIndex > -1)
            {
                frmINTERNETmesajyaz frm = new frmINTERNETmesajyaz(((Departmanlar)cmbDepartmanlar.SelectedItem).pkDepartmanID);
                frm.ShowDialog();

                if (cmbDepartmanlar.SelectedIndex > -1)
                {
                    Temizle();
                    if (rbGelenKutusu.Checked)
                    {
                        dataGridView1.Columns["clCevapla"].Visible = true;
                        GetGelenMesajlar();
                    }
                    else if (rbGidenKutusu.Checked)
                    {
                        dataGridView1.Columns["clCevapla"].Visible = false;
                        GetGidenMesajlar();
                    }
                }
            }
        }

        private void btnYenile_Click(object sender, EventArgs e)
        {
            Temizle();
            if (rbGelenKutusu.Checked)
            {
                dataGridView1.Columns["clCevapla"].Visible = true;
                GetGelenMesajlar();
            }
            else if (rbGidenKutusu.Checked)
            {
                dataGridView1.Columns["clCevapla"].Visible = false;
                GetGidenMesajlar();
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (rbGelenKutusu.Checked)
            {
                int MesajID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["clpkMesajID"].Value);
                AlinanMesajlar.DoUpdateOkundu(MesajID, DateTime.Now);
                dataGridView1.Rows[e.RowIndex].Cells["clblOkundu"].Value = true;
            }

            txtKonu.Text = dataGridView1.Rows[e.RowIndex].Cells["clstrKonu"].Value.ToString();
            txtMesaj.Text = dataGridView1.Rows[e.RowIndex].Cells["clstrIcerik"].Value.ToString();
            lblZaman.Text = dataGridView1.Rows[e.RowIndex].Cells["cldtGondermeZamani"].Value.ToString();
        }

        private void dataGridView1_DataSourceChanged(object sender, EventArgs e)
        {
            lblMesajSayisi.Text = dataGridView1.Rows.Count.ToString();
        }

        private void frmINTERNETmesajlar_FormClosing(object sender, FormClosingEventArgs e)
        {
            tmr.Stop();
            GC.SuppressFinalize(tmr);
            tmr.Dispose();
        }

        // Do the flashing - this does not involve a raincoat.
        public static bool FlashWindowEx(Form form)
        {
            IntPtr hWnd = form.Handle;
            FLASHWINFO fInfo = new FLASHWINFO();

            fInfo.cbSize = Convert.ToUInt32(Marshal.SizeOf(fInfo));
            fInfo.hwnd = hWnd;
            fInfo.dwFlags = FLASHW_ALL | FLASHW_TIMERNOFG;
            fInfo.uCount = UInt32.MaxValue;
            fInfo.dwTimeout = 0;

            return FlashWindowEx(ref fInfo);
        }
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool FlashWindowEx(ref FLASHWINFO pwfi);

        //Flash both the window caption and taskbar button.
        //This is equivalent to setting the FLASHW_CAPTION | FLASHW_TRAY flags. 
        public const UInt32 FLASHW_ALL = 3;

        // Flash continuously until the window comes to the foreground. 
        public const UInt32 FLASHW_TIMERNOFG = 12;

        [StructLayout(LayoutKind.Sequential)]
        public struct FLASHWINFO
        {
            public UInt32 cbSize;
            public IntPtr hwnd;
            public UInt32 dwFlags;
            public UInt32 uCount;
            public UInt32 dwTimeout;
        }
    }
}

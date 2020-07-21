using System;
using System.Collections;
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
    public partial class frmINTERNETpersonelbaglantilari : Form
    {
        public frmINTERNETpersonelbaglantilari()
        {
            InitializeComponent();
        }

        private void frmINTERNETpersonelbaglantilari_Load(object sender, EventArgs e)
        {
            GetObjects();
        }

        private void GetObjects()
        {
            GetPersoneller();
            lbPersoneller.SelectedIndex = 0;
        }

        private void GetMusteriler()
        {
            DataTable dt = new DataTable();
            TP_PersonelBaglantilari.GetObjects(dt, ((TP_Personeller)lbPersoneller.SelectedItem).pkID);
            gridControl1.DataSource = dt;
        }

        private void GetPersoneller()
        {
            TP_Personeller.GetObjects(lbPersoneller.Items, true);
        }

        private void lbPersoneller_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbPersoneller.SelectedIndex > -1)
                GetMusteriler();
        }

        private void btnPerEkle_Click(object sender, EventArgs e)
        {
            frmINTERNETpersonelekle frm = new frmINTERNETpersonelekle();
            frm.ShowDialog();
            GetObjects();
        }

        private void btnPerDuzenle_Click(object sender, EventArgs e)
        {
            if (lbPersoneller.SelectedIndex > -1)
            {
                frmINTERNETpersonelekle frm = new frmINTERNETpersonelekle(true, ((TP_Personeller)lbPersoneller.SelectedItem).pkID);
                frm.ShowDialog();
            }
        }

        private void btnPerSil_Click(object sender, EventArgs e)
        {
            if (lbPersoneller.SelectedIndex > -1)
            {
                if (MessageBox.Show("Personeli silmek istediğinize emin misiniz?", "Silme", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    TP_Personeller per = TP_Personeller.GetObject(((TP_Personeller)lbPersoneller.SelectedItem).pkID);
                    TP_PersonelBaglantilari.DoDelete(per.pkID);
                    per.DoDelete();
                    GetObjects();
                }
            }
        }

        private void btnPerBaglanti_Click(object sender, EventArgs e)
        {
            frmINTERNETpersonelbaglantiyap frm = new frmINTERNETpersonelbaglantiyap();
            frm.ShowDialog();
            GetObjects();
        }

        private void btnPerBaglantiKaldir_Click(object sender, EventArgs e)
        {
            if (gridView1.FocusedRowHandle > -1)
            {
                if (MessageBox.Show("Seçili bağlantıyı silmek istediğinize emin misiniz?", "Silme", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    TP_PersonelBaglantilari.DoDelete(Convert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SMREF")),
                        Convert.ToBoolean(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "blBayi")),
                        ((TP_Personeller)lbPersoneller.SelectedItem).pkID);
                    GetObjects();
                }
            }
        }

        private void btnToplu_Click(object sender, EventArgs e)
        {
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

                range = ws.get_Range("A1", "C6666");

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
            ArrayList personeller = new ArrayList();
            for (int i = 2; i <= values.GetLength(0); i++)
            {
                if (values[i, 1] == null) // 1.kolon boş ise bu satırdan sonrasına bakmasın
                    break;

                try
                {
                    if (CariHesaplarTP.GetGMREFBySMREF(Convert.ToInt32(values[i, 1])) != 0)
                    {
                        kodlar.Add(Convert.ToInt32(values[i, 1]));
                    }
                    else
                    {
                        MessageBox.Show(i.ToString() + ". satırda hata var, nokta bulunamadı.", "Hata");
                        return;
                    }



                    TP_Personeller per = TP_Personeller.GetObject(values[i, 2].ToString().Trim(), values[i, 3].ToString().Trim());
                    if (per != null && per.pkID != 0)
                    {
                        personeller.Add(per);
                    }
                    else
                    {
                        MessageBox.Show(i.ToString() + ". satırda hata var, personel bulunamadı.", "Hata");
                        return;
                    }
                }
                catch (Exception ex)
                {
                    kodlar.Clear();
                    personeller.Clear();
                    MessageBox.Show(ex.Message);
                }
            }

            if (MessageBox.Show("Dosya aktarım için hazır, devam edilsin mi?", "Aktarım", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                for (int i = 0; i < kodlar.Count; i++)
                    TP_PersonelBaglantilari.DoInsert(Convert.ToInt32(kodlar[i]), true, ((TP_Personeller)personeller[i]).pkID, string.Empty);

                MessageBox.Show("Aktarım tamamlandı.", "Başarılı");
            }
        }
    }
}

using Sultanlar.DatabaseObject;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Sultanlar.UI
{
    public partial class frmINTERNETticaripazarlamaaktivitetoptan : Form
    {
        public frmINTERNETticaripazarlamaaktivitetoptan()
        {
            InitializeComponent();
        }

        private void frmINTERNETticaripazarlamaaktivitetoptan_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Value = Convert.ToDateTime(DateTime.Now.Year.ToString() + "." + DateTime.Now.Month.ToString() + ".01");
            dateTimePicker2.Value = Convert.ToDateTime(DateTime.Now.Year.ToString() + "." + DateTime.Now.Month.ToString() + "." + DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month).ToString());
            GetVeri(1, dateTimePicker1.Value, dateTimePicker2.Value, "");
        }

        private void GetVeri(int TUR, DateTime BASLANGIC, DateTime BITIS, string ITEMREF)
        {
            string malzeme = ITEMREF == string.Empty ? string.Empty : " AND [Web-Malzeme-Full].ITEMREF = " + ITEMREF;

            if (ITEMREF != string.Empty)
            {
                if (ITEMREF.Length < 7)
                {
                    return;
                }
            }

            DataTable dt = new DataTable();
            WebGenel.Sorgu(dt, @" 
SELECT pkID,TUR,BASLANGIC,BITIS,[Web-Malzeme-Full].[ITEMREF],HIY2.METIN AS [KAT],HIY1.METIN AS [ALTKAT],HYRS_TANIM AS [MARKA],[GRUP ACIK] AS [ANABOLUM],[OZEL ACIK] AS [BOLUM],dbo.YeniBolum(PRIMB) AS [GRUP],[MAL ACIK] AS [MALZEME],[BRUT],[ISK1],dbo.IskontoDus([BRUT],[ISK1]) AS [FIYAT] 
FROM [Web-Fiyat-TP-Donem] 
INNER JOIN [Web-Malzeme-Full] ON [Web-Malzeme-Full].ITEMREF = [Web-Fiyat-TP-Donem].ITEMREF 
INNER JOIN [Web-Malzeme-Hiyerarsi] AS HIY1 ON [Web-Malzeme-Full].HYRS = HIY1.KOD 
INNER JOIN [Web-Malzeme-Hiyerarsi] AS HIY2 ON LEFT([Web-Malzeme-Full].HYRS,8) = HIY2.KOD 
WHERE TUR = " + TUR.ToString() + " AND BASLANGIC <='" + Datecevir(BASLANGIC) + "' AND BITIS >= '" + Datecevir(BITIS) + "'" + malzeme + " ORDER BY [KAT],[ALTKAT],[Malzeme]");
            gridControl4.DataSource = dt;
            gridView4.BestFitColumns();
            label2.Text = " Satır Sayısı: " + gridView4.RowCount.ToString();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                textBox1.Text = string.Empty;
                GetVeri(radioButton1.Checked ? 1 : 2, dateTimePicker1.Value, dateTimePicker2.Value, "");
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
            GetVeri(radioButton1.Checked ? 1 : 2, dateTimePicker1.Value, dateTimePicker2.Value, "");
        }

        private string Datecevir(DateTime date)
        {
            return date.Year.ToString() + "." + date.Month + "." + date.Day;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 7 || textBox1.Text.Length == 0)
            {
                //GetVeri(radioButton1.Checked ? 1 : 2, dateTimePicker1.Value, dateTimePicker2.Value, textBox1.Text);
            }
        }

        private void btnToptanAltkanal_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Başlangıç: " + dateTimePicker1.Value.ToShortDateString() + "\r\nBitiş: " + dateTimePicker2.Value.ToShortDateString() + "\r\nTür: " + (radioButton1.Checked ? "Alt Kanal" : "Toptan") + "\r\n\r\nAktarım bu şekilde olacaktır. Devam etmek istiyor musunuz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
            {
                return;
            }

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

                range = ws.get_Range("A1", "M1000");

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

            ArrayList wfd = new ArrayList();
            for (int i = 2; i <= values.GetLength(0); i++)
            {
                if (values[i, 1] != null)
                {
                    try
                    {
                        if (values[i, 1].ToString().Length == 7 && values[i, 1].ToString().StartsWith("1"))
                        {
                            FiyatDonem fd = new FiyatDonem();
                            fd.TUR = 1;
                            fd.ITEMREF = Convert.ToInt32(values[i, 1].ToString().Trim());
                            fd.BRUT = Convert.ToDouble(values[i, 7].ToString());
                            fd.ISK1 = Convert.ToDouble(values[i, 10].ToString()) * 100;
                            fd.BASLANGIC = dateTimePicker1.Value;
                            fd.BITIS = dateTimePicker2.Value;

                            FiyatDonem fd1 = new FiyatDonem();
                            fd1.TUR = 2;
                            fd1.ITEMREF = Convert.ToInt32(values[i, 1].ToString().Trim());
                            fd1.BRUT = Convert.ToDouble(values[i, 7].ToString());
                            fd1.ISK1 = Convert.ToDouble(values[i, 12].ToString()) * 100;
                            fd1.BASLANGIC = dateTimePicker1.Value;
                            fd1.BITIS = dateTimePicker2.Value;

                            wfd.Add(fd); wfd.Add(fd1);
                        }
                    }
                    catch (Exception ex)
                    {
                        wfd.Clear();
                        MessageBox.Show(ex.Message);
                        return;
                    }
                }
            }

            for (int i = 0; i < wfd.Count; i++)
            {
                WebGenel.Sorgu(@"
DELETE 
FROM [Web-Fiyat-TP-Donem] 
WHERE ITEMREF = " + ((FiyatDonem)wfd[i]).ITEMREF.ToString() + " AND TUR = " + ((FiyatDonem)wfd[i]).TUR.ToString() + " AND BASLANGIC = '" + Datecevir(((FiyatDonem)wfd[i]).BASLANGIC) + "' AND BITIS = '" + Datecevir(((FiyatDonem)wfd[i]).BITIS) + "'");
                
                WebGenel.Sorgu(@"INSERT INTO [Web-Fiyat-TP-Donem] ([TUR],[BASLANGIC],[BITIS],[ITEMREF],[BRUT],[ISK1],[ISK2],[ISK3],[ISK4]) VALUES
(" + ((FiyatDonem)wfd[i]).TUR.ToString() + ",'" + Datecevir(((FiyatDonem)wfd[i]).BASLANGIC) + "','" + Datecevir(((FiyatDonem)wfd[i]).BITIS) + "'," + ((FiyatDonem)wfd[i]).ITEMREF.ToString() + "," + ((FiyatDonem)wfd[i]).BRUT.ToString().Replace(",", ".") + "," + ((FiyatDonem)wfd[i]).ISK1.ToString().Replace(",", ".") + ",0,0,0)");
            }

            MessageBox.Show("Aktarım tamamlandı.", "Başarılı");
            GetVeri(radioButton1.Checked ? 1 : 2, dateTimePicker1.Value, dateTimePicker2.Value, "");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "")
            {
                return;
            }

            string ITEMREF = "";
            string BRUT = "";
            string UYG = "";
            try
            {
                ITEMREF = Convert.ToInt32(textBox1.Text.Trim()).ToString();
                BRUT = Convert.ToDouble(textBox2.Text.Trim().Replace(".", ",")).ToString().Replace(",", ".");
                UYG = Convert.ToDouble(textBox3.Text.Trim().Replace(".", ",")).ToString().Replace(",", ".");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            if (MessageBox.Show("Başlangıç: " + dateTimePicker1.Value.ToShortDateString() + "\r\nBitiş: " + dateTimePicker2.Value.ToShortDateString() + "\r\nTür: " + (radioButton1.Checked ? "Alt Kanal" : "Toptan") + "\r\nMalzeme: " + ITEMREF + "\r\nBrüt Fiyat: " + BRUT + "\r\nUygulama İskontosu: " + UYG + "\r\n\r\nAktarım bu şekilde olacaktır. Devam etmek istiyor musunuz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
            {
                return;
            }

            WebGenel.Sorgu(@"
DELETE 
FROM [Web-Fiyat-TP-Donem] 
WHERE ITEMREF = " + ITEMREF + " AND TUR = " + (radioButton1.Checked ? "1" : "2") + " AND BASLANGIC = '" + Datecevir(dateTimePicker1.Value) + "' AND BITIS = '" + Datecevir(dateTimePicker2.Value) + "'");

            WebGenel.Sorgu(@"INSERT INTO [Web-Fiyat-TP-Donem] ([TUR],[BASLANGIC],[BITIS],[ITEMREF],[BRUT],[ISK1],[ISK2],[ISK3],[ISK4]) VALUES
(" + (radioButton1.Checked ? "1" : "2") + ",'" + Datecevir(dateTimePicker1.Value) + "','" + Datecevir(dateTimePicker2.Value) + "'," + ITEMREF + "," + BRUT + "," + UYG + ",0,0,0)");

            MessageBox.Show("Aktarım tamamlandı.", "Başarılı");
            GetVeri(radioButton1.Checked ? 1 : 2, dateTimePicker1.Value, dateTimePicker2.Value, "");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (gridView4.SelectedRowsCount == 0 || gridView4.IsFilterRow(gridView4.GetSelectedRows()[0]))
            {
                return;
            }

            int ITEMREF = Convert.ToInt32(gridView4.GetRowCellValue(gridView4.GetSelectedRows()[0], "ITEMREF"));
            int TUR = Convert.ToInt32(gridView4.GetRowCellValue(gridView4.GetSelectedRows()[0], "TUR"));
            DateTime BASLANGIC = Convert.ToDateTime(gridView4.GetRowCellValue(gridView4.GetSelectedRows()[0], "BASLANGIC"));
            DateTime BITIS = Convert.ToDateTime(gridView4.GetRowCellValue(gridView4.GetSelectedRows()[0], "BITIS"));
            int ID = Convert.ToInt32(gridView4.GetRowCellValue(gridView4.GetSelectedRows()[0], "pkID"));

            if (MessageBox.Show("Seçilen satır silinecektir. Devam etmek istiyor musunuz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
            {
                return;
            }

            WebGenel.Sorgu(@"
DELETE 
FROM [Web-Fiyat-TP-Donem] 
WHERE pkID = " + ID.ToString());

            MessageBox.Show("Satır silindi.", "Başarılı");
            GetVeri(radioButton1.Checked ? 1 : 2, dateTimePicker1.Value, dateTimePicker2.Value, "");

        }

        private void gridView4_ColumnFilterChanged(object sender, EventArgs e)
        {
            label2.Text = " Satır Sayısı: " + gridView4.RowCount.ToString();
        }
    }

    public class FiyatDonem
    {
        public int TUR { get; set; }
        public DateTime BASLANGIC { get; set; }
        public DateTime BITIS { get; set; }
        public int ITEMREF { get; set; }
        public double BRUT { get; set; }
        public double ISK1 { get; set; }
        public double ISK2 { get; set; }
        public double ISK3 { get; set; }
        public double ISK4 { get; set; }
    }
}

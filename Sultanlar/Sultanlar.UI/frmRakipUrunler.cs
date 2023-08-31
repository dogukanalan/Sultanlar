using Sultanlar.DatabaseObject.Internet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Sultanlar.UI
{
    public partial class frmRakipUrunler : Form
    {
        public frmRakipUrunler()
        {
            InitializeComponent();
        }

        private void frmRakipUrunler_Load(object sender, EventArgs e)
        {
            GetMalzemeler();
        }

        private void GetMalzemeler()
        {
            DataTable dt = new DataTable();
            Malzeme2.GetObjects(dt);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
        }

        private void dataGridView1_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                string malacik = dataGridView1.Rows[i].Cells["Column2"].Value != null ? dataGridView1.Rows[i].Cells["Column2"].Value.ToString() : string.Empty;
                double kdv = dataGridView1.Rows[i].Cells["Column3"].Value != null && dataGridView1.Rows[i].Cells["Column3"].Value.ToString() != string.Empty ? Convert.ToDouble(dataGridView1.Rows[i].Cells["Column3"].Value) : 0;
                string barkod = dataGridView1.Rows[i].Cells["Column4"].Value != null ? dataGridView1.Rows[i].Cells["Column4"].Value.ToString() : string.Empty;
                string urtkod = dataGridView1.Rows[i].Cells["Column7"].Value != null ? dataGridView1.Rows[i].Cells["Column7"].Value.ToString() : string.Empty;
                string bolum = dataGridView1.Rows[i].Cells["Column13"].Value != null ? dataGridView1.Rows[i].Cells["Column13"].Value.ToString() : string.Empty;
                string ozelacik = string.Empty; string reykod = string.Empty; string hk = string.Empty;
                if (bolum != string.Empty)
                {
                    ozelacik = bolum == "T1" ? "TİBET" : bolum == "T2" ? "YEG" : bolum == "T3" ? "HAYAT" : bolum == "T4" ? "ARI" : "";
                    reykod = bolum;
                    hk = bolum == "T1" ? "T" : bolum == "T2" ? "Y" : bolum == "T3" ? "H" : bolum == "T4" ? "A" : "";
                }

                if (malacik != string.Empty || kdv != 0 || barkod != string.Empty || bolum != string.Empty || urtkod != string.Empty)
                {
                    if (!dataGridView1.Rows[i].IsNewRow && dataGridView1.Rows[i].Cells["Column1"].Value.ToString() == "")
                    {
                        Malzeme2 mal = new Malzeme2(0, "", malacik, urtkod, "", "ST", "1", "RKP", "RAKİP", bolum, hk, ozelacik, reykod, "R", "RAKİP", kdv, 0, barkod, 0, 0, 0, 0, 0, "700070007000", "DİĞER", 0, 0, 0);
                        mal.DoInsert();
                    }
                    else if (!dataGridView1.Rows[i].IsNewRow && dataGridView1.Rows[i].Cells["Column1"].Value.ToString() != "")
                    {
                        Malzeme2 mal = Malzeme2.GetObject(Convert.ToInt32(dataGridView1.Rows[i].Cells["Column1"].Value));
                        mal.MALACIK = malacik;
                        mal.KDV = kdv;
                        mal.BARKOD = barkod;
                        mal.OZELKOD = bolum;
                        mal.OZELACIK = ozelacik;
                        mal.HK = hk;
                        mal.REYKOD = reykod;
                        mal.URTKOD = urtkod;
                        mal.DoUpdate();
                    }
                }
            }
            GetMalzemeler();
        }

        private void btnYenile_Click(object sender, EventArgs e)
        {
            GetMalzemeler();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0 && MessageBox.Show("Seçilen malzeme silinecek, emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                Malzeme2 mal = Malzeme2.GetObject(Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Column1"].Value));
                mal.AP = 1;
                mal.DoUpdate();
                GetMalzemeler();
            }
        }
    }
}

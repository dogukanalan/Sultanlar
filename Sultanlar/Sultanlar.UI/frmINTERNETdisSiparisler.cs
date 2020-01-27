using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sultanlar.DatabaseObject.Internet;
using DgvFilterPopup;

namespace Sultanlar.UI
{
    public partial class frmINTERNETdisSiparisler : Form
    {
        public frmINTERNETdisSiparisler()
        {
            InitializeComponent();
        }

        DgvFilterManager dgvfm;

        private void frmDisSiparisler_Load(object sender, EventArgs e)
        {
            GetObjects();
        }

        private void GetObjects()
        {
            DataTable dt = new DataTable();
            DisSiparisler.GetObjectAyrintili(dt);
            dataGridView1.DataSource = dt;
            dgvfm = new DgvFilterManager(dataGridView1);
            dataGridView1.ColumnHeadersHeight = 40;
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].HeaderText == "Kargo Takip No")
            {
                bool hataolusmadi = false;
                bool vazgecildi = false;

                DisSiparisler ds = DisSiparisler.GetObject(Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["clpkID"].Value));

                if (dataGridView1.Rows[e.RowIndex].Cells["clstrKargoSirketi"].Value != null)
                {
                    if (ds.strKargoTakip == string.Empty)
                    {
                        if (MessageBox.Show("Kargo takip numarası girildikten sonra değiştirilemez. İşleme devam etmek istediğinize emin misiniz?", "Devam", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                        {
                            ds.strKargoTakip = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                            ds.DoUpdate(); //n11KargoyaVer de de güncelliyoruz

                            DataTable dt = new DataTable();
                            DisSiparislerDetay.GetObject(dt, ds.pkID);
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                Sultanlar.Class.DisSiparisler cds = new Sultanlar.Class.DisSiparisler();

                                if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "-") // kargosuz gönderilirse diye
                                {
                                    //ds.DoUpdate();
                                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = ds.strKargoTakip;

                                    if (ds.tintSirketID == 1)
                                        hataolusmadi = cds.n11KargoyaVer(Convert.ToInt64(dt.Rows[i]["bintDisKod"]), 2, 401, dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                                    else
                                        hataolusmadi = true;
                                }
                                else
                                {
                                    long kargosirketikodu = 0;
                                    if (dataGridView1.Rows[e.RowIndex].Cells["clstrKargoSirketi"].Value.ToString() == "Ceva Lojistik")
                                        kargosirketikodu = 401;
                                    else if (dataGridView1.Rows[e.RowIndex].Cells["clstrKargoSirketi"].Value.ToString() == "MNG")
                                        kargosirketikodu = 342;
                                    else if (dataGridView1.Rows[e.RowIndex].Cells["clstrKargoSirketi"].Value.ToString() == "Yurtiçi")
                                        kargosirketikodu = 344;
                                    else if (dataGridView1.Rows[e.RowIndex].Cells["clstrKargoSirketi"].Value.ToString() == "Aras")
                                        kargosirketikodu = 345;
                                    else if (dataGridView1.Rows[e.RowIndex].Cells["clstrKargoSirketi"].Value.ToString() == "Sürat")
                                        kargosirketikodu = 341;

                                    if (ds.tintSirketID == 1)
                                        hataolusmadi = cds.n11KargoyaVer(Convert.ToInt64(dt.Rows[i]["bintDisKod"]), 1, kargosirketikodu, dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                                    else
                                        hataolusmadi = true;
                                }
                            }
                        }
                        else
                        {
                            vazgecildi = true;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Kargolanmış bir siparişin takip numarası değiştirilemez.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        vazgecildi = true;
                    }
                }
                else
                {
                    MessageBox.Show("Kargo şirketi seçilmedi", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                if (hataolusmadi && !vazgecildi)
                {
                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = ds.strKargoTakip;
                    MessageBox.Show("Kargo bilgisi başarıyla gönderildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (vazgecildi)
                {
                    
                }
                else
                {
                    MessageBox.Show("Bir hata oluştu, lütfen daha sonra tekrar deneyiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnYenile_Click(object sender, EventArgs e)
        {
            GetObjects();
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Siparişi silme işlemine devam etmek istediğinize emin misiniz?", "Devam", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
            {
                DisSiparisler ds = DisSiparisler.GetObject(Convert.ToInt32(dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["clpkID"].Value));

                if (ds.strKargoTakip == string.Empty)
                {
                    ds.sintDurum = 3;
                    ds.DoUpdate();
                    dataGridView1.Rows.Remove(dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex]);
                }
                else
                {
                    MessageBox.Show("Kargolanmış bir sipariş iptal edilemez.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void frmINTERNETdisSiparisler_SizeChanged(object sender, EventArgs e)
        {
            btnIptal.Location = new Point(btnIptal.Location.X, lblAlt.Location.Y + 8);
        }
    }
}

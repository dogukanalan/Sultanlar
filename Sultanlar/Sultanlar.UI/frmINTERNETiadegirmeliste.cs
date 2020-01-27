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
    public partial class frmINTERNETiadegirmeliste : Form
    {
        public frmINTERNETiadegirmeliste(int iadeid, string Bolum)
        {
            InitializeComponent();
            IadeID = iadeid;
            bolum = Bolum;
        }

        int IadeID;
        DataTable dt;
        MyTextBox mtxt;
        string bolum;

        private void frmINTERNETiadegirmeliste_Load(object sender, EventArgs e)
        {
            GetObjects();

            mtxt = new MyTextBox();
            mtxt.Location = new Point(139, 8);
            mtxt.Size = new Size(143, 20);
            mtxt.KeyDown += new KeyEventHandler(mtxt_KeyDown);
            panel1.Controls.Add(mtxt);
        }

        void mtxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab) btnBarkod.PerformClick();
        }

        public void GetObjects()
        {
            dt = new DataTable();
            IadelerDetay.GetObjectsByIadeID(dt, IadeID);
            dataGridView1.DataSource = dt;
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            if (cbAramadanAktar.Checked)
                btnGuncelle.PerformClick();

            this.Close();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            bool yanlisgirisvar = false;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                try { Convert.ToInt32(dataGridView1.Rows[i].Cells["clintMiktar"].Value); }
                catch (Exception) { yanlisgirisvar = true; break; }

                if (Convert.ToInt32(dataGridView1.Rows[i].Cells["clintMiktar"].Value) > 0)
                {
                    IadelerDetay id = IadelerDetay.GetObjectByIadelerDetayID(Convert.ToInt64(dt.Rows[i]["pkIadeDetayID"]));
                    id.intMiktar = Convert.ToInt32(dataGridView1.Rows[i].Cells["clintMiktar"].Value);
                    id.DoUpdate();



                    DataTable dt1 = new DataTable();
                    decimal toplamtutar = 0;
                    IadelerDetay.GetObjectsByIadeID(dt1, id.intIadeID);
                    for (int j = 0; j < dt1.Rows.Count; j++)
                        toplamtutar += Convert.ToDecimal(dt1.Rows[j]["mnFiyat"]) * Convert.ToInt32(dt1.Rows[j]["intMiktar"]);
                    Iadeler iade = Iadeler.GetObjectsByIadeID(id.intIadeID);
                    iade.mnToplamTutar = toplamtutar;
                    iade.DoUpdate();
                }
            }

            if (yanlisgirisvar)
                MessageBox.Show("Hatalı miktar girildi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                GetObjects();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            if (dataGridView1.Columns[e.ColumnIndex].Name == "clSil")
            {
                if (MessageBox.Show("Bu satır silinsin mi?", "Silme", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    IadelerDetay id = IadelerDetay.GetObjectByIadelerDetayID(Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["clpkIadeDetayID"].Value));
                    id.DoDelete();
                    GetObjects();
                }
            }
        }

        private void btnBarkod_Click(object sender, EventArgs e)
        {
            if (cbAramadanAktar.Checked)
                btnGuncelle.PerformClick();

            lblBarkodBulunamadi.Visible = false;
            lblBarkodBulundu.Visible = false;

            DataTable dt1 = new DataTable();
            Urunler.GetProducts(dt1, mtxt.Text.Trim(), new ArrayList(), new ArrayList(), true);

            if (dt1.Rows.Count > 0)
            {
                lblBarkodBulundu.Visible = true;
                long iadedetayid = 0;

                if (bolum != "S1" && Urunler.GetProductOzelKod(Convert.ToInt32(dt1.Rows[0]["UrunID"]), true) != bolum)
                {
                    MessageBox.Show("İade girişi için seçilen bölüm ile eklenmek istenen ürünün bölümü aynı değil.", "Bölüm hatası", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else if (bolum == "S1" && !Urunler.GetProductOzelKod(Convert.ToInt32(dt1.Rows[0]["UrunID"]), true).StartsWith("S"))
                {
                    MessageBox.Show("İade girişi için seçilen bölüm ile eklenmek istenen ürünün bölümü aynı değil.", "Bölüm hatası", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    if (Convert.ToInt32(dt1.Rows[0]["UrunID"]) == Convert.ToInt32(dt.Rows[j]["intUrunID"]))
                    {
                        iadedetayid = Convert.ToInt64(dt.Rows[j]["pkIadeDetayID"]);
                        break;
                    }
                }

                if (iadedetayid > 0)
                {
                    IadelerDetay id = IadelerDetay.GetObjectByIadelerDetayID(iadedetayid);
                    id.intMiktar += 1;
                    id.DoUpdate();
                }
                else
                {
                    IadelerDetay id = new IadelerDetay(IadeID, Convert.ToInt32(dt1.Rows[0]["UrunID"]),
                        dt1.Rows[0]["Ad"].ToString(), 1, 0);
                    id.DoInsert();
                }

                GetObjects();
            }
            else
            {
                lblBarkodBulunamadi.Visible = true;
            }

            mtxt.Text = string.Empty;
            mtxt.Focus();
        }

        private void txtBarkod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                btnBarkod.PerformClick();
            }
        }

        private void frmINTERNETiadegirmeliste_FormClosing(object sender, FormClosingEventArgs e)
        {
            //frmINTERNETiadegirme.listeacik = false;
        }

        private void cbAramadanAktar_MouseHover(object sender, EventArgs e)
        {
            lblAramadanAktar.Visible = true;
        }

        private void cbAramadanAktar_MouseLeave(object sender, EventArgs e)
        {
            lblAramadanAktar.Visible = false;
        }
    }

    public class MyTextBox : TextBox
    {
        protected override bool IsInputKey(Keys keyData)
        {
            if (keyData == Keys.Tab || keyData == (Keys.Shift | Keys.Tab)) return true;
            return base.IsInputKey(keyData);
        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
        }
    }
}

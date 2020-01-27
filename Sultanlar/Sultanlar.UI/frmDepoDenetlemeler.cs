using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Sultanlar.Class;
using Sultanlar.DatabaseObject;
using Sultanlar.DatabaseObject.Internet;
using System.Collections;

namespace Sultanlar.UI
{
    public partial class frmDepoDenetlemeler : Form
    {
        public frmDepoDenetlemeler()
        {
            InitializeComponent();
        }

        ArrayList resimler = new ArrayList();

        private void frmDepoDenetlemeler_Load(object sender, EventArgs e)
        {
            GetObjects();
            GetMusteriler();
        }

        private void GetMusteriler()
        {
            CariHesaplar.GetMUSTERIs(cmbMusteriler.Items, "", false);
        }

        private void GetObjects()
        {
            DataTable dt = new DataTable();
            DepoDenetleme.GetObjects(dt);
            gridControl1.DataSource = dt;
        }

        private void Temizle()
        {
            cmbMusteriler.SelectedIndex = -1;
            txtDenetleyen.Text = string.Empty;
            txtTespitler.Text = string.Empty;
            txtUnvan.Text = string.Empty;
            sbResimTemizle.PerformClick();
        }

        private void sbResimEkle_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = true;
            ofd.Filter = "Desteklenen Resim Dosyaları|*.jpeg;*.jpg;*.bmp;*.png;*.gif|JPG Dosyaları|*.jpeg;*.jpg|BMP Dosyaları|*.bmp|PNG Dosyaları|*.png|GIF Dosyaları|*.gif";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                for (int i = 0; i < ofd.FileNames.Length; i++)
                {
                    Image resim = Resim.ByteToImage(File.ReadAllBytes(ofd.FileNames[i]));
                    resimler.Add(resim);
                }
                lblResimSayisi.Text = resimler.Count.ToString() + " resim eklendi";
            }
        }

        private void sbResimTemizle_Click(object sender, EventArgs e)
        {
            resimler.Clear();
            lblResimSayisi.Text = resimler.Count.ToString() + " resim eklendi";
        }

        private void sbGonder_Click(object sender, EventArgs e)
        {
            if (cmbMusteriler.SelectedIndex > -1)
            {
                DepoDenetleme dd = new DepoDenetleme(((CariHesaplar)cmbMusteriler.SelectedItem).GMREF, DateTime.Now, txtDenetleyen.Text.Trim(),
                    txtUnvan.Text.Trim(), txtTespitler.Text.Trim());
                dd.DoInsert();

                for (int i = 0; i < resimler.Count; i++)
                {
                    DepoDenetlemeResimler ddr = new DepoDenetlemeResimler(dd.pkID, Resim.ImageToByte((Image)resimler[i]), string.Empty);
                    ddr.DoInsert();
                }

                Temizle();
                GetObjects();
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            if (gridView1.SelectedRowsCount > 0 && !gridView1.IsFilterRow(gridView1.GetSelectedRows()[0]))
            {
                int ID = Convert.ToInt32(gridView1.GetFocusedRowCellValue("pkID"));
                ArrayList al = DepoDenetlemeResimler.GetResimlerByDepoDenetlemeID(ID);
                Image[] resimler = new Image[al.Count];
                for (int i = 0; i < al.Count; i++)
                    resimler[i] = Resim.ByteToImage(((DepoDenetlemeResimler)al[i]).binResim);
                frmDepoDenetlemeResim frm = new frmDepoDenetlemeResim(resimler);
                frm.ShowDialog();
            }
        }

        private void frmDepoDenetlemeler_SizeChanged(object sender, EventArgs e)
        {
            lblYeniGiris.Location = new Point(lblYeniGiris.Location.X, lblAlt.Location.Y + 17);

            lblMusteri.Location = new Point(lblMusteri.Location.X, lblAlt.Location.Y + 10);
            lblDenetleyen.Location = new Point(lblDenetleyen.Location.X, lblAlt.Location.Y + 10);
            lblTespitler.Location = new Point(lblTespitler.Location.X, lblAlt.Location.Y + 10);

            lblResimler.Location = new Point(lblResimler.Location.X, lblAlt.Location.Y + 35);
            lblResimSayisi.Location = new Point(lblResimSayisi.Location.X, lblAlt.Location.Y + 35);
            lblUnvan.Location = new Point(lblUnvan.Location.X, lblAlt.Location.Y + 35);

            cmbMusteriler.Location = new Point(cmbMusteriler.Location.X, lblAlt.Location.Y + 7);
            txtDenetleyen.Location = new Point(txtDenetleyen.Location.X, lblAlt.Location.Y + 7);
            txtTespitler.Location = new Point(txtTespitler.Location.X, lblAlt.Location.Y + 7);
            sbGonder.Location = new Point(sbGonder.Location.X, lblAlt.Location.Y + 7);

            sbResimEkle.Location = new Point(sbResimEkle.Location.X, lblAlt.Location.Y + 32);
            sbResimTemizle.Location = new Point(sbResimTemizle.Location.X, lblAlt.Location.Y + 32);
            txtUnvan.Location = new Point(txtUnvan.Location.X, lblAlt.Location.Y + 32);
        }
    }
}

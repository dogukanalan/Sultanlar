using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sultanlar.DatabaseObject;
using Sultanlar.Class;
using System.IO;

namespace Sultanlar.UI
{
    public partial class frmArananGorevler : Form
    {
        public frmArananGorevler()
        {
            InitializeComponent();
        }
        public frmArananGorevler(int ArananGorevID)
        {
            InitializeComponent();

            index = ArananGorevID;
        }
        //
        //
        int index = 0;
        //
        //
        private void frmArananGorevler_Load(object sender, EventArgs e)
        {
            GetObjects();
        }
        //
        //
        private void GetObjects()
        {
            dgvTecrubeler.DataSource = ArananGorevler.GetObject(true);
            Gorevler.GetObject(cmbGorevler.Items, true);
            OgrenimDurumlari.GetObject(cmbOgrenimDurumlari.Items, true);
            AskerlikDurumlari.GetObject(cmbAskerlikDurumlari.Items, true);
            MedeniDurumlar.GetObject(cmbMedeniDurumlar.Items, true);
            Iller.GetObject(cmbIller.Items, true);

            if (index != 0)
            {
                for (int i = 0; i < dgvTecrubeler.Rows.Count; i++)
                {

                }
            }
        }
        //
        //
        private void cmbIller_SelectedIndexChanged(object sender, EventArgs e)
        {
            Ilceler.GetObject(cmbIlceler.Items, ((Iller)cmbIller.SelectedItem).strIlKod, true);
            cmbIlceler.Items.Add("Tümü");
        }
        //
        //
        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (cmbGorevler.SelectedIndex > -1)
            {
                byte OgrenimDurumu = 0;
                byte AskerlikDurumu = 0;
                byte MedeniDurum = 0;
                byte Il = 0;
                if (cmbOgrenimDurumlari.SelectedIndex > -1)
                    OgrenimDurumu = ((OgrenimDurumlari)cmbOgrenimDurumlari.SelectedItem).pkOgrenimDurumuID;
                if (cmbAskerlikDurumlari.SelectedIndex > -1)
                    AskerlikDurumu = ((AskerlikDurumlari)cmbAskerlikDurumlari.SelectedItem).pkAskerlikDurumuID;
                if (cmbMedeniDurumlar.SelectedIndex > -1)
                    MedeniDurum = ((MedeniDurumlar)cmbMedeniDurumlar.SelectedItem).pkMedeniDurumID;
                if (cmbIller.SelectedIndex > -1)
                    Il = ((Iller)cmbIller.SelectedItem).pkIlID;

                ArananGorevler ag;

                if (cmbIlceler.SelectedIndex < 0 || cmbIlceler.SelectedItem.ToString() == "Tümü")
                {
                    ag = new ArananGorevler(
                    ((Gorevler)cmbGorevler.SelectedItem).pkGorevID, OgrenimDurumu, AskerlikDurumu, MedeniDurum, Il, 
                    975, txtTecrube.Text.Trim(), false, DateTime.Parse(dtpSonTarih.Value.ToShortDateString())); //975 bos ilce
                }
                else if (cmbIlceler.SelectedIndex > -1)
                {
                    ag = new ArananGorevler(
                    ((Gorevler)cmbGorevler.SelectedItem).pkGorevID, OgrenimDurumu, AskerlikDurumu, MedeniDurum, Il,
                    ((Ilceler)cmbIlceler.SelectedItem).pkIlceID, txtTecrube.Text.Trim(), false, DateTime.Parse(dtpSonTarih.Value.ToShortDateString()));
                }
                else
                {
                    ag = new ArananGorevler(
                    ((Gorevler)cmbGorevler.SelectedItem).pkGorevID, OgrenimDurumu, AskerlikDurumu, MedeniDurum, Il,
                    975, txtTecrube.Text.Trim(), false, DateTime.Parse(dtpSonTarih.Value.ToShortDateString())); //975 bos ilce
                }

                ag.DoInsert();
                dgvTecrubeler.DataSource = ArananGorevler.GetObject(true);
            }
            else
            {
                MessageBox.Show("Görev Seçilmedi!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }
        //
        //
        private void dgvTecrubeler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0) // buttonun oldugu kolonu 0 goruyor
            {
                if (dgvTecrubeler.Rows[e.RowIndex].Cells[9].Value.ToString() == "True") // checkbox ın kolonunu 9 goruyor
                {
                    ArananGorevler.DoUndoDelete(Convert.ToInt32(dgvTecrubeler.Rows[e.RowIndex].Cells[1].Value)); // ID nin oldugu kolonu 1 goruyor
                }
                else
                {
                    ArananGorevler.DoLikeDelete(Convert.ToInt32(dgvTecrubeler.Rows[e.RowIndex].Cells[1].Value)); // ID nin oldugu kolonu 1 goruyor
                }
                //dgvTecrubeler.Rows.RemoveAt(e.RowIndex);
                GetObjects();
            }
        }
    }
}

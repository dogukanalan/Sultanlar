using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sultanlar.DatabaseObject.Internet;
using System.Collections;

namespace Sultanlar.UI
{
    public partial class frmINTERNETticaripazarlamahizmetanlasmakapama : Form
    {
        public frmINTERNETticaripazarlamahizmetanlasmakapama(int smref, int AnlasmaHizmetBedelID)
        {
            InitializeComponent();
            SMREF = smref;
            anlasmahizmetbedeli = AnlasmaHizmetBedelleri.GetObject(AnlasmaHizmetBedelID);
        }

        int SMREF;
        AnlasmaHizmetBedelleri anlasmahizmetbedeli;

        private void frmINTERNETticaripazarlamahizmetanlasmakapama_Load(object sender, EventArgs e)
        {
            GetAnlasmalar();
            GetAnlasmaBedeller();
        }

        private void GetAnlasmalar()
        {
            DataTable dt = new DataTable();
            Anlasmalar.GetObjects(dt, SMREF);
            ArrayList silinecekler = new ArrayList();
            for (int i = 0; i < dt.Rows.Count; i++)
                if (dt.Rows[i]["intOnay"].ToString() == "0")
                    silinecekler.Add(dt.Rows[i]);
            for (int i = 0; i < silinecekler.Count; i++)
                dt.Rows.Remove((DataRow)silinecekler[i]);
            gridControl1.DataSource = dt;
        }

        private void GetAnlasmaBedeller()
        {
            if (gridView1.SelectedRowsCount > 0 && !gridView1.IsFilterRow(gridView1.GetSelectedRows()[0]))
            {
                int AnlasmaID = Convert.ToInt32(((DataRowView)gridControl1.MainView.GetRow(gridView1.GetSelectedRows()[0])).Row.ItemArray[0]);
                AnlasmaBedeller.GetObjects(listBox1.Items, AnlasmaID);
            }
        }

        private void frmINTERNETticaripazarlamahizmetanlasmakapama_SizeChanged_1(object sender, EventArgs e)
        {
            sbSec.Location = new Point(sbSec.Location.X, lblAlt.Location.Y + 3);
        }

        private void sbSec_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex > -1)
            {
                anlasmahizmetbedeli.intAnlasmaBedelID = ((AnlasmaBedeller)listBox1.SelectedItem).pkID;
                anlasmahizmetbedeli.DoUpdate();
                this.Close();
            }
            else
            {
                MessageBox.Show("Bir hizmet bedeli seçilmedi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex > -1)
            {
                AnlasmaBedeller anlasmabedel = (AnlasmaBedeller)listBox1.SelectedItem;
                txtTAHAdet.Text = anlasmabedel.intTAHAdet.ToString();
                txtTAHBedel.Text = anlasmabedel.mnTAHBedel.ToString("C2");
                txtTAHIsk.Text = anlasmabedel.flTAHIsk.ToString("N1");
                txtYEGAdet.Text = anlasmabedel.intYEGAdet.ToString();
                txtYEGBedel.Text = anlasmabedel.mnYEGBedel.ToString("C2");
                txtYEGIsk.Text = anlasmabedel.flYEGIsk.ToString("N1");
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            GetAnlasmaBedeller();
        }
    }
}

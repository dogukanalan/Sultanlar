using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TekUrun.DatabaseObjects;

namespace Sultanlar.UI
{
    public partial class frmTekUrunHareketEkle : Form
    {
        public frmTekUrunHareketEkle(long SiparisID, byte EnDusukID)
        {
            InitializeComponent();
            siparisid = SiparisID;
            endusukid = EnDusukID;
        }

        long siparisid;
        byte endusukid;

        private void frmTekUrunHareketEkle_Load(object sender, EventArgs e)
        {
            ComboBox cmb = new ComboBox();
            SiparisDurumlari.GetObjects(cmb.Items, true);

            for (int i = 0; i < cmb.Items.Count; i++)
            {
                if (endusukid < ((SiparisDurumlari)cmb.Items[i]).pkSiparisDurumuID)
                {
                    cmbSiparisDurumlari.Items.Add(cmb.Items[i]);
                }
            }
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (cmbSiparisDurumlari.SelectedIndex > -1)
            {
                Hareketler har = new Hareketler(siparisid, ((SiparisDurumlari)cmbSiparisDurumlari.SelectedItem).pkSiparisDurumuID, DateTime.Now);
                har.DoInsert();
                this.Close();
            }
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

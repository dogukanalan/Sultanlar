using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sultanlar.DatabaseObject.Kenton;

namespace Sultanlar.UI
{
    public partial class frmKENTON_Uyeler : Form
    {
        public frmKENTON_Uyeler()
        {
            InitializeComponent();
        }

        private void frmKENTON_Uyeler_Load(object sender, EventArgs e)
        {
            GetUyeler();
        }

        private void GetUyeler()
        {
            Uyeler.GetObjects(listBoxControl1.Items, true);
        }

        private void GetUyeDetay()
        {
            if (listBoxControl1.SelectedIndex > -1)
            {
                textBox1.Text = ((Uyeler)listBoxControl1.SelectedItem).strAd;
                textBox2.Text = ((Uyeler)listBoxControl1.SelectedItem).strSoyad;
                textBox3.Text = ((Uyeler)listBoxControl1.SelectedItem).strEposta;
                dateTimePicker1.Value = ((Uyeler)listBoxControl1.SelectedItem).dtDogum;
                dateTimePicker2.Value = ((Uyeler)listBoxControl1.SelectedItem).dtTarih;
                checkBox1.Checked = ((Uyeler)listBoxControl1.SelectedItem).blPasif;
            }
        }

        private void listBoxControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetUyeDetay();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Uyeler uye = (Uyeler)listBoxControl1.SelectedItem;
            uye.blPasif = checkBox1.Checked;
            uye.DoUpdate();
            listBoxControl1.SelectedItem = uye;
        }
    }
}

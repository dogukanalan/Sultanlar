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
    public partial class frmINTERNETticaripazarlamasatisrapornoktaaddegistirme : Form
    {
        public frmINTERNETticaripazarlamasatisrapornoktaaddegistirme()
        {
            InitializeComponent();
        }

        private void frmINTERNETticaripazarlamasatisrapornoktaaddegistirme_Load(object sender, EventArgs e)
        {
            GetBayiler();
            //comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
        }

        private void GetBayiler()
        {
            CariHesaplarTP.GetObjects(comboBox1.Items, 0);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (comboBox1.SelectedIndex > -1 &&comboBox2.SelectedIndex > -1 &&comboBox3.SelectedIndex > -1)
            //{
            //    SatisRaporTP.GetNoktalar(listBox1.Items, CariHesaplarTP.GetBAYIKODByGMREF(((CariHesaplarTP)comboBox1.SelectedItem).GMREF),
            //        Convert.ToInt16(comboBox2.SelectedItem.ToString()), Convert.ToByte(comboBox3.SelectedItem.ToString()), string.Empty);
            //    textBox1.Text = string.Empty;
            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex > -1 &&comboBox2.SelectedIndex > -1 &&comboBox3.SelectedIndex > -1)
            {
                SatisRaporTP.GetNoktalar(listBox1.Items, CariHesaplarTP.GetBAYIKODByGMREF(((CariHesaplarTP)comboBox1.SelectedItem).GMREF),
                    Convert.ToInt16(comboBox2.SelectedItem.ToString()), Convert.ToByte(comboBox3.SelectedItem.ToString()), textBox1.Text.Trim());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex > -1)
            {
                ArrayList ctp = CariHesaplarTP.GetObjectBySMREF(Convert.ToInt32(numericUpDown1.Value));
                if (ctp.Count == 0)
                {
                    MessageBox.Show("Yeni nokta kodu sistemde kayıtlı değil.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (MessageBox.Show("Nokta adı, seçilen bayi için satış raporundaki tüm dönemlerde değiştirelecek. Devam etmek istediğinize emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    SatisRaporTP.DoUpdateNoktaAd(
                        ((SatisRaporTP)listBox1.SelectedItem).BAYIKOD,
                        ((SatisRaporTP)listBox1.SelectedItem).NOKTAKOD,
                        ((SatisRaporTP)listBox1.SelectedItem).NOKTAAD,
                        Convert.ToInt32(numericUpDown1.Value), 
                        textBox4.Text,
                        textBox2.Text
                        );
                    MessageBox.Show("Nokta adı satış raporunda değiştirildi", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
        }
    }
}

using System;
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
    public partial class frmINTERNETiadelersatisoperasyon : Form
    {
        public frmINTERNETiadelersatisoperasyon()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 0: iade kabulden, 1: sat.op.'dan, 2: s.t.'den, 3: c/h'dan, 10: mkasaroğlu, üyıldırım hepsi
        /// </summary>
        /// <param name="Nereden"></param>
        public frmINTERNETiadelersatisoperasyon(int Nereden)
        {
            InitializeComponent();

            if (Nereden == 0)
            {
                comboBox1.Items.Add("Sat.Op. - İade Kabul'den geldi.");
            }
            else if (Nereden == 1)
            {
                comboBox1.Items.Add("S.T. - Sat.Op.'dan geldi.");
            }
            else if (Nereden == 2)
            {
                comboBox1.Items.Add("C/H - S.T.'den geldi.");
            }
            else if (Nereden == 3)
            {
                comboBox1.Items.Add("Son - C/H'dan düşüldü.");
            }
            else if (Nereden == 10) // mkasaroğlu, üyıldırım, fahrettin kaya, neslihan demirbaş
            {
                comboBox1.Items.Add("İade  Kabul - Geri gönderildi.");
                comboBox1.Items.Add("Sat.Op. - İade Kabul'den geldi.");
                comboBox1.Items.Add("S.T. - Sat.Op.'dan geldi.");
                comboBox1.Items.Add("C/H - S.T.'den geldi.");
                comboBox1.Items.Add("Son - C/H'dan düşüldü.");
            }
        }

        private void frmINTERNETiadelersatisoperasyon_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex > -1)
                frmINTERNETiadeler.SatisOperasyon = comboBox1.SelectedItem.ToString();
            this.Close();
        }
    }
}

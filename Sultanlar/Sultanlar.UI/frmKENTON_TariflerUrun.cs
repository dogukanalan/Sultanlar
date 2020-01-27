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
    public partial class frmKENTON_TariflerUrun : Form
    {
        public frmKENTON_TariflerUrun()
        {
            InitializeComponent();
            urunid = 0;
        }

        public int urunid;

        private void frmKENTON_TariflerUrun_Load(object sender, EventArgs e)
        {
            Urunler.GetProducts(listBox1.Items, 0, "KENTON", "", "", "", true, true, false, true, true);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex > -1)
            {
                urunid = ((Urunler)listBox1.SelectedItem).ITEMREF;
                this.Close();
            }
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listBox1.SelectedIndex > -1)
            {
                urunid = ((Urunler)listBox1.SelectedItem).ITEMREF;
                this.Close();
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Urunler.GetProducts(listBox1.Items, 0, textBox1.Text, "", "", "", true, true, false, true, true);
            }
        }
    }
}

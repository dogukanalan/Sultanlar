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
    public partial class frmINTERNETticaripazarlamacarisecimi : Form
    {
        public frmINTERNETticaripazarlamacarisecimi()
        {
            InitializeComponent();
        }

        public int SMREF;

        private void frmINTERNETticaripazarlamacarisecimi_Load(object sender, EventArgs e)
        {
            SMREF = 0;
            GetBayiler();
        }

        private void GetBayiler()
        {
            CariHesaplarTP.GetObjects(listBox1.Items, 0);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                listBox1.SelectedIndex = -1;
                CariHesaplar.GetObjectsLikeTP(listBox2.Items);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex > -1)
            {
                radioButton1.Checked = false;
                CariHesaplarTP.GetObjects(listBox2.Items, ((CariHesaplarTP)listBox1.SelectedItem).GMREF);
            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedIndex > -1)
                SMREF = ((CariHesaplarTP)listBox2.SelectedItem).SMREF;
            else if (radioButton1.Checked)
                SMREF = ((CariHesaplarTP)listBox2.SelectedItem).GMREF;
            else
                SMREF = 0;

            this.Close();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Sultanlar.UI
{
    public partial class frmInputBox : Form
    {
        public frmInputBox()
        {
            InitializeComponent();
        }

        public frmInputBox(string Baslik)
        {
            InitializeComponent();
            this.Text = Baslik;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmAna.InputBox = textBox1.Text;
            this.Close();
        }
    }
}

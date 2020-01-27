using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

namespace Sultanlar.UI
{
    public partial class frmYazdir : Form
    {
        public frmYazdir(string sayfa)
        {
            InitializeComponent();
            yazdir = sayfa;
        }

        string yazdir;

        private void frmYazdir_Load(object sender, EventArgs e)
        {
            webBrowser1.Navigate(yazdir);

            RegistryKey yaziciustalt = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Internet Explorer\\PageSetup", true);
            yaziciustalt.SetValue("footer", "");
            yaziciustalt.SetValue("header", "");
            yaziciustalt.SetValue("Shrink_To_Fit", "yes");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            webBrowser1.ShowPrintPreviewDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            webBrowser1.ShowPrintDialog();
        }
    }
}

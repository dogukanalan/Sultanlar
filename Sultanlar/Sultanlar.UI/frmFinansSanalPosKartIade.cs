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
    public partial class frmFinansSanalPosKartIade : Form
    {
        public frmFinansSanalPosKartIade(string Tutar, string SiparisNo)
        {
            InitializeComponent();

            tutar = Tutar;
            siparisno = SiparisNo;
        }

        string tutar;
        string siparisno;

        private void frmFinansSanalPosKartIade_Load(object sender, EventArgs e)
        {
            txtSipNo.Text = siparisno;
            txtTutar.Text = tutar;

            //webBrowser1.Navigate("https://www.sultanlar.com.tr/musteri/kartiade1.aspx?tutar=" + tutar + "&sipno=" + siparisno);
        }

        private void btnYap_Click(object sender, EventArgs e)
        {
            ePayment.cc5payment cc5 = new ePayment.cc5payment();
            cc5.host = "https://sanalpos.teb.com.tr/servlet/cc5ApiServer";
            //cc5.host = "https://testvpos.est.com.tr/servlet/cc5ApiServer";
            cc5.name = "sultanlarclient";
            //cc5.name = "isim";
            cc5.password = "clienTSultanlar1";
            //cc5.password = "pass";
            cc5.clientid = "400359354";
            //cc5.clientid = "4444";
            cc5.orderresult = 0;
            //cc5.orderresult = 1;

            cc5.chargetype = "Credit";
            cc5.currency = "949";
            cc5.cardnumber = txtKartNo.Text;
            cc5.expmonth = txtAy.Text;
            cc5.expyear = txtYil.Text;
            cc5.cv2 = txtCv2.Text;
            cc5.subtotal = tutar;
            cc5.oid = siparisno;

            string str = cc5.processorder();

            MessageBox.Show("Sonuç: " + str + "\r\nİşlem Kodu: " + cc5.err + "\r\nHata Mesajı: " + cc5.errmsg);
        }
    }
}

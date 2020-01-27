using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sultanlar.DatabaseObject;
using Sultanlar.DatabaseObject.Internet;
using System.Net.Mail;
using System.Net;

namespace Sultanlar.UI
{
    public partial class frmINTERNETmusterisifresifirlamatalepleri : Form
    {
        public frmINTERNETmusterisifresifirlamatalepleri()
        {
            InitializeComponent();
        }

        private void frmINTERNETmusterisifresifirlamatalepleri_Load(object sender, EventArgs e)
        {
            GetTalepler();
        }

        private void GetTalepler()
        {
            MusteriSifreSifirlamaTalepler.GetObjects(lbTalepler.Items, rbTaleplerPasif.Checked, true);
        }

        private string SifreOlustur()
        {
            Random rnd = new Random();
            string donendeger = string.Empty;

            int i = 0;
            while (i < 10)
            {
                int j = rnd.Next(49, 122);
                if ((j < 58) || (j >= 65 && j < 91) || (j >= 97))
                {
                    i++;
                    donendeger += char.ConvertFromUtf32(j);
                }
            }

            return donendeger;
        }

        private void EpostaGonder(string Eposta, string Konu, string Icerik)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                //Microsoft.Office.Interop.Outlook.Application oApp = new Microsoft.Office.Interop.Outlook.Application();
                //Microsoft.Office.Interop.Outlook.NameSpace onS = (Microsoft.Office.Interop.Outlook.NameSpace)oApp.GetNamespace("mapi");
                //onS.Logon(null, null, true, true);
                //Microsoft.Office.Interop.Outlook.MailItem oMsg =
                //    (Microsoft.Office.Interop.Outlook.MailItem)oApp.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem);

                //oMsg.To = Eposta;
                //oMsg.Subject = Konu;
                //oMsg.HTMLBody = Icerik;

                //oMsg.Send();

                //onS.Logoff();

                //oMsg = null;
                //onS = null;
                //oApp = null;
                //GC.Collect();
                
                MailMessage mail = new MailMessage("bilgi@sultanlar.com.tr", Eposta);
                mail.To.Add("bilgi@sultanlar.com.tr");
                SmtpClient client = new SmtpClient();
                client.Port = 587;
                client.EnableSsl = false;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential("bilgi@sultan", "987456");
                client.Host = "mail.sultanlar.com.tr";
                mail.Subject = Konu;
                mail.Body = Icerik;
                mail.IsBodyHtml = true;
                client.Send(mail);
            }
            catch (Exception ex)
            {
                Hatalar.DoInsert(ex, "Üye Şifre Sıfırlama Eposta Gönderimi");
            }
            Cursor.Current = Cursors.AppStarting;
        }

        private void rbTalepler_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                btnSifreGonder.Enabled = rbTalepler.Checked;
                GetTalepler();
            }
        }

        private void btnSifreGonder_Click(object sender, EventArgs e)
        {
            if (lbTalepler.SelectedIndex > -1)
            {
                if (MessageBox.Show("Seçilen müşterinin şifresi sıfırlansın mı?", "Şifre Sıfırlama", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    MusteriSifreSifirlamaTalepler msst = (MusteriSifreSifirlamaTalepler)lbTalepler.SelectedItem;
                    msst.blPasif = true;
                    msst.DoUpdate();

                    Musteriler mus = Musteriler.GetMusteriByID(msst.intMusteriID);
                    mus.binSifre = SifreOlustur();
                    mus.DoUpdate();

                    EpostaGonder(
                        mus.strEposta,
                        "Sultanlar Web Sitesi Şifre Sıfırlama",
                        "Yeni şifreniz: " + mus.binSifre + "<br><br>Eposta adresiniz ve şifrenizle sisteme giriş yapabilirsiniz.<br><br> https://www.sultanlar.com.tr/musteri/giris.aspx");

                    lbTalepler.Items.Remove(lbTalepler.SelectedItem);
                    MessageBox.Show("Şifre sıfırlandı ve üyeye yeni şifresi gönderildi.", "Şifre Sıfırlama", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}

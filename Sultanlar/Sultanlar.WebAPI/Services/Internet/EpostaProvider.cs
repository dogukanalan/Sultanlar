using Sultanlar.DbObj.Internet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Sultanlar.WebAPI.Services.Internet
{
    public class EpostaProvider
    {
        public void EpostaGonder(string EpostaFromDisplayName, string EpostaTo, string Konu, string Icerik)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient client = new SmtpClient();
                client.EnableSsl = false;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential("sultanlar", "Rz17Av+63*");
                client.Host = "webmail.sultanlar.com.tr";
                mail.Subject = Konu;
                mail.Body = Icerik;
                mail.IsBodyHtml = true;
                mail.From = new MailAddress("sultanlar@sultanlar.com.tr", EpostaFromDisplayName);
                mail.To.Add(new MailAddress(EpostaTo));
                client.Send(mail);
            }
            catch (Exception ex)
            {
                hatalar.DoInsert(ex, "api epostagonder");
            }
        }
    }
}

﻿using Sultanlar.DbObj.Internet;
using Sultanlar.DatabaseObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Collections;

namespace Sultanlar.WebAPI.Services.Internet
{
    public class EpostaProvider
    {
        public void EpostaGonder(string EpostaFromDisplayName, ArrayList EpostaTo, string Konu, string Icerik)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient client = new SmtpClient();
                //client.Port = 25;
                client.EnableSsl = false;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential("sultanlar", WebGenel.SultanlarEpostaSifre());
                client.Host = "webmail.sultanlar.com.tr";
                mail.Subject = Konu;
                mail.Body = Icerik;
                mail.IsBodyHtml = true;
                mail.From = new MailAddress("sultanlar@sultanlar.com.tr", EpostaFromDisplayName);
                for (int i = 0; i < EpostaTo.Count; i++)
                {
                    mail.To.Add(new MailAddress(EpostaTo[i].ToString()));
                }
                client.Send(mail);
            }
            catch (Exception ex)
            {
                hatalar.DoInsert(ex, "api epostagonder");
            }
        }
    }
}

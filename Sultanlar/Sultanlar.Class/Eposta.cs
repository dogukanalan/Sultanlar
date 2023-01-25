using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Net;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using Sultanlar.DatabaseObject;

namespace Sultanlar.Class
{
    public class Eposta
    {
        //
        //
        //
        //
        //
        public static void EpostaAl(string kimden, string[] kimlere, string gonderenadsoyad, string konu, string ileti)
        {
            MailMessage mm = new MailMessage();
            mm.From = new MailAddress(kimden, gonderenadsoyad);

            for (int i = 0; i < kimlere.Length; i++)
            {
                mm.To.Add(kimlere[i]);
            }

            mm.Subject = konu;
            mm.Body = ileti;
            mm.IsBodyHtml = true;
            SmtpClient sc = new SmtpClient("webmail.sultanlar.com.tr");

            try
            {
                sc.Send(mm);
            }
            catch (SmtpException ex)
            {
                EventLog eventLog = new EventLog("Application");
                eventLog.WriteEntry(ex.Message + "Sultanlar.Class.Eposta.EpostaAl");
                //Hatalar.DoInsert(ex, "Sultanlar.Class.Eposta.EpostaAl");
            }
        }
        /// <summary>
        /// kullanma
        /// </summary>
        public static void EpostaYolla(string kimden, string sifre, string[] kimlere, string yollayanadsoyad, string konu, string ileti)
        {
            MailMessage mm = new MailMessage();
            mm.From = new MailAddress(kimden, yollayanadsoyad);

            for (int i = 0; i < kimlere.Length; i++)
            {
                mm.To.Add(kimlere[i]);
            }
            
            mm.Subject = konu;
            mm.Body = ileti;
            mm.Sender = new MailAddress(kimden, yollayanadsoyad);
            mm.IsBodyHtml = true;
            SmtpClient sc = new SmtpClient();
            sc.Host = "webmail.sultanlar.com.tr";
            NetworkCredential cr = new NetworkCredential(kimden, sifre);

            if (kimden == "sultanlar")
            {
                cr = new NetworkCredential(kimden, WebGenel.SultanlarEpostaSifre()); // sultanlar@sultanlar.com.tr şifresi
            }

            //sc.DeliveryMethod = SmtpDeliveryMethod.Network;
            sc.Port = 25;
            sc.Credentials = cr;
            sc.UseDefaultCredentials = true;
            try
            {
                sc.Send(mm);
            }
            catch (SmtpException ex)
            {
                EventLog eventLog = new EventLog("Application");
                eventLog.WriteEntry(ex.Message + "Sultanlar.Class.Eposta.EpostaYolla");
            }
        }
        /// <summary>
        /// kullanma
        /// </summary>
        public static void EpostaYolla(string kimden, string sifre, string[] kimlere, string[] CCs, string yollayanadsoyad, string konu, string ileti)
        {
            MailMessage mm = new MailMessage();
            mm.From = new MailAddress(kimden, yollayanadsoyad);

            for (int i = 0; i < kimlere.Length; i++)
            {
                mm.To.Add(kimlere[i]);
            }

            for (int i = 0; i < CCs.Length; i++)
            {
                mm.CC.Add(CCs[i]);
            }

            mm.Subject = konu;
            mm.Body = ileti;
            mm.Sender = new MailAddress(kimden, yollayanadsoyad);
            mm.IsBodyHtml = true;
            SmtpClient sc = new SmtpClient();
            sc.Host = "webmail.sultanlar.com.tr";
            NetworkCredential cr = new NetworkCredential(kimden, sifre);

            if (kimden == "sultanlar")
            {
                cr = new NetworkCredential(kimden, WebGenel.SultanlarEpostaSifre()); // sultanlar@sultanlar.com.tr şifresi
            }

            //sc.DeliveryMethod = SmtpDeliveryMethod.Network;
            sc.Port = 25;
            sc.Credentials = cr;
            sc.UseDefaultCredentials = true;
            try
            {
                sc.Send(mm);
            }
            catch (SmtpException ex)
            {
                EventLog eventLog = new EventLog("Application");
                eventLog.WriteEntry(ex.Message + "Sultanlar.Class.Eposta.EpostaYolla");
            }
        }
        /// <summary>
        /// kullanma
        /// </summary>
        public static void EpostaYolla(string kimden, string sifre, string[] kimlere, string yollayanadsoyad, string konu, string ileti, string attachement)
        {
            MailMessage mm = new MailMessage();
            mm.From = new MailAddress(kimden, yollayanadsoyad);

            for (int i = 0; i < kimlere.Length; i++)
            {
                mm.To.Add(kimlere[i]);
            }

            Attachment at = new Attachment(attachement);
            mm.Attachments.Add(at);
            mm.Subject = konu;
            mm.Body = ileti;
            mm.Sender = new MailAddress(kimden, yollayanadsoyad);
            mm.IsBodyHtml = true;
            SmtpClient sc = new SmtpClient();
            sc.Host = "webmail.sultanlar.com.tr";
            NetworkCredential cr = new NetworkCredential(kimden, sifre);

            if (kimden == "sultanlar")
            {
                cr = new NetworkCredential(kimden, WebGenel.SultanlarEpostaSifre()); // sultanlar@sultanlar.com.tr şifresi
            }

            sc.Credentials = cr;
            sc.UseDefaultCredentials = true;
            try
            {
                sc.Send(mm);
                at.Dispose();
            }
            catch (SmtpException ex)
            {
                EventLog eventLog = new EventLog("Application");
                eventLog.WriteEntry(ex.Message + "Sultanlar.Class.Eposta.EpostaYolla");
            }
        }
        //
        //
        //
        //
        //
        public static void EpostaGonder(string Host, string EpostaFrom, string EpostaFromSifre, string EpostaFromDisplayName, string EpostaTo, int Port, bool Ssl, string Konu, string Icerik)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient client = new SmtpClient();
                client.Port = Port;
                client.EnableSsl = Ssl;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(EpostaFrom, EpostaFromSifre);
                client.Host = Host;
                mail.Subject = Konu;
                mail.Body = Icerik;
                mail.IsBodyHtml = true;
                mail.From = new MailAddress(EpostaFrom, EpostaFromDisplayName);
                mail.To.Add(new MailAddress(EpostaTo));
                client.Send(mail);
            }
            catch (Exception ex)
            {
                EventLog eventLog = new EventLog("Application");
                eventLog.WriteEntry(ex.Message + "Genel Eposta Gönderimi");
            }
        }
        //
        //
        //
        //
        //
        public static void EpostaGonder(string EpostaFromDisplayName, string EpostaTo, string Konu, string Icerik)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient client = new SmtpClient();
                //client.Port = 587;
                client.EnableSsl = false;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential("sultanlar", WebGenel.SultanlarEpostaSifre());
                client.Host = "webmail.sultanlar.com.tr";
                mail.Subject = Konu;
                mail.Body = Icerik;
                mail.IsBodyHtml = true;
                mail.From = new MailAddress("sultanlar@sultanlar.com.tr", EpostaFromDisplayName);
                mail.To.Add(new MailAddress(EpostaTo));
                //CertificateValidation();
                client.Send(mail);
            }
            catch (Exception ex)
            {
                EventLog eventLog = new EventLog("Application");
                eventLog.WriteEntry(ex.Message + "Genel Eposta Gönderimi");
            }
        }
        //
        //
        //
        //
        //
        public static void GmailGonder(string EpostaFromDisplayName, string EpostaTo, string Konu, string Icerik)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient client = new SmtpClient("smtp.gmail.com");
                client.Port = 587;
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential("mistif.sultanlar@gmail.com", WebGenel.MistifGmailEpostaSifre());
                mail.Subject = Konu;
                mail.Body = Icerik;
                mail.IsBodyHtml = true;
                mail.From = new MailAddress("mistif.sultanlar@gmail.com", EpostaFromDisplayName);
                mail.To.Add(new MailAddress(EpostaTo));
                client.Send(mail);
            }
            catch (Exception ex)
            {
                EventLog eventLog = new EventLog("Application");
                eventLog.WriteEntry(ex.Message + "Genel Eposta Gönderimi");
            }
        }
        //
        //
        //
        //
        //
        public static void GmailGonder(string EpostaFromDisplayName, string EpostaTo, string Konu, string Icerik, byte[] attach, string attach_name)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient client = new SmtpClient("smtp.gmail.com");
                client.Port = 587;
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential("mistif.sultanlar@gmail.com", WebGenel.MistifGmailEpostaSifre());
                mail.Subject = Konu;
                mail.Body = Icerik;
                mail.IsBodyHtml = true;
                mail.From = new MailAddress("mistif.sultanlar@gmail.com", EpostaFromDisplayName);
                mail.To.Add(new MailAddress(EpostaTo));
                mail.Attachments.Add(new Attachment(new MemoryStream(attach), attach_name));
                client.Send(mail);
            }
            catch (Exception ex)
            {
                EventLog eventLog = new EventLog("Application");
                eventLog.WriteEntry(ex.Message + "Genel Eposta Gönderimi");
            }
        }
        //
        //
        //
        //
        //
        public static void EpostaGonder(string EpostaFromDisplayName, string EpostaTo, string Konu, string Icerik, byte[] attach, string attach_name)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient client = new SmtpClient();
                //client.Port = 587;
                client.EnableSsl = false;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential("sultanlar", WebGenel.SultanlarEpostaSifre());
                client.Host = "webmail.sultanlar.com.tr";
                mail.Subject = Konu;
                mail.Body = Icerik;
                mail.IsBodyHtml = true;
                mail.From = new MailAddress("sultanlar@sultanlar.com.tr", EpostaFromDisplayName);
                mail.To.Add(new MailAddress(EpostaTo));
                mail.Attachments.Add(new Attachment(new MemoryStream(attach), attach_name));
                client.Send(mail);
            }
            catch (Exception ex)
            {
                EventLog eventLog = new EventLog("Application");
                eventLog.WriteEntry(ex.Message + "Genel Eposta Gönderimi");
            }
        }

        [Obsolete("Do not use this in Production code!!!", false)]
        static void CertificateValidation()
        {
            // Disabling certificate validation can expose you to a man-in-the-middle attack
            // which may allow your encrypted message to be read by an attacker
            // https://stackoverflow.com/a/14907718/740639
            ServicePointManager.ServerCertificateValidationCallback =
                delegate (
                    object s,
                    X509Certificate certificate,
                    X509Chain chain,
                    SslPolicyErrors sslPolicyErrors
                ) {
                    return true;
                };
        }
    }
}

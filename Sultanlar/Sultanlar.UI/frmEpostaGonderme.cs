using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sultanlar.DatabaseObject;
using System.IO;
using System.Collections;
using Design;
using mshtml;
using System.Net.Mail;
using System.Net;

namespace Sultanlar.UI
{
    public partial class frmEpostaGonderme : Form
    {
        public frmEpostaGonderme()
        {
            InitializeComponent();
        }

        System.Timers.Timer tmr;
        System.Timers.Timer tmrVakit;
        string ExcelDosya;
        int Kacinci;
        ArrayList Epostalar;
        ArrayList Isimler;
        ArrayList Dosyalar;
        ArrayList Resimler;
        DateTime BaslangicSuresi;
        Editor edAciklama;
        string Icerik;

        private void frmEpostaGonderme_Load(object sender, EventArgs e)
        {
            Isimler = new ArrayList();

            if (frmAna.KAdi.ToUpper() == "BI04" || frmAna.KAdi.ToUpper() == "ADMİNİSTRATOR" || frmAna.KAdi.ToUpper() == "ADMINISTRATOR")
            {
                txtSaniye.Enabled = true; txtDakikada.Enabled = true;
            }

            edAciklama = new Editor();
            edAciklama.Size = new Size(822, 250);
            edAciklama.Location = new Point(60, 99);
            this.Controls.Add(edAciklama);
            edAciklama.SendToBack();
            Icerik = string.Empty;



            CheckForIllegalCrossThreadCalls = false;
            ExcelDosya = string.Empty;
            Kacinci = 0;
            tmr = new System.Timers.Timer(60000);
            tmrVakit = new System.Timers.Timer(1000);
            tmr.Elapsed += new System.Timers.ElapsedEventHandler(tmr_Elapsed);
            tmrVakit.Elapsed += new System.Timers.ElapsedEventHandler(tmrVakit_Elapsed);
        }
        //
        //
        // Methods
        //
        private void Islem()
        {
            int dakikada = Convert.ToInt32(txtDakikada.Text);

            if (Kacinci + dakikada > Epostalar.Count)
                dakikada = Epostalar.Count - Kacinci;

            lbSonGonderilenler.Items.Clear();

            ArrayList simdikiEpostalar = new ArrayList();
            ArrayList simdikiIsimler = new ArrayList();
            for (int i = Kacinci; i < Kacinci + dakikada; i++)
            {
                simdikiEpostalar.Add(Epostalar[i].ToString());
                simdikiIsimler.Add(Isimler[i].ToString());

                lblSonGonderilen.Text = Epostalar[i].ToString();
                lbSonGonderilenler.Items.Add(Epostalar[i].ToString());
                lbGonderilenler.Items.Add(Epostalar[i].ToString());
            }

            Kacinci += dakikada;
            EpostaGonder(simdikiEpostalar, txtKonu.Text.Trim(), Icerik, Dosyalar, Resimler, simdikiIsimler);

            if (Kacinci == Epostalar.Count)
            {
                tmr.Stop();
                tmrVakit.Stop();
                MessageBox.Show("Epostalar gönderildi.", "İşlem Tamamlandı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //btnEkle.Enabled = true;
                //btnExcel.Enabled = true;
                //txtExcel.Text = string.Empty;
            }
        }
        //
        private void EpostaGonder(ArrayList Eposta, string Konu, string Icerik, ArrayList DosyaYerleri, ArrayList ResimYerleri, ArrayList Isimler)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                //Microsoft.Office.Interop.Outlook.Application oApp = new Microsoft.Office.Interop.Outlook.Application();
                //Microsoft.Office.Interop.Outlook.NameSpace onS = (Microsoft.Office.Interop.Outlook.NameSpace)oApp.GetNamespace("mapi");
                //onS.Logon(null, null, true, true);
                //Microsoft.Office.Interop.Outlook.MailItem oMsg =
                //    (Microsoft.Office.Interop.Outlook.MailItem)oApp.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem);

                //oMsg.To = eposta;
                //oMsg.Subject = Konu;
                //oMsg.HTMLBody = (Eposta.Count == 1 ? "Sayın " + Isimler[0].ToString() + ",<br><br>" : "") + Icerik;


                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("sultanlar@sultanlar.com.tr", "Sultanlar Pazarlama A.Ş.");

                for (int i = 0; i < Eposta.Count; i++)
                    mail.To.Add(Eposta[i].ToString());

                SmtpClient client = new SmtpClient();
                client.Port = 587;
                client.EnableSsl = false;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential("sultanlar@sultan", "987456");
                client.Host = "mail.sultanlar.com.tr";
                mail.Subject = Konu;
                mail.IsBodyHtml = true;
                mail.Body = (Eposta.Count == 1 ? "Sayın " + Isimler[0].ToString() + ",<br><br>" : "") + Icerik;

                int j = 0;
                for (int i = 0; i < DosyaYerleri.Count; i++)
                {
                    //oMsg.Attachments.Add(DosyaYerleri[i].ToString(), Microsoft.Office.Interop.Outlook.OlAttachmentType.olByValue, 1, "Ek" + j.ToString());
                    mail.Attachments.Add(new Attachment(DosyaYerleri[i].ToString()));
                    j++;
                }

                for (int i = 0; i < ResimYerleri.Count; i++)
                {
                    //Microsoft.Office.Interop.Outlook.Attachment attachment = oMsg.Attachments.Add(ResimYerleri[i].ToString(), Microsoft.Office.Interop.Outlook.OlAttachmentType.olEmbeddeditem, null, "Ek" + j.ToString());
                    //string imageCid = "image00" + (i + 1).ToString() + ".jpg@123";
                    //attachment.PropertyAccessor.SetProperty("http://schemas.microsoft.com/mapi/proptag/0x3712001E", imageCid);

                    //if (txtLink.Text.Trim() != string.Empty)
                    //    oMsg.HTMLBody += String.Format("<br><br><center><a href='" + txtLink.Text.Trim() + "'><img src=\"cid:{0}\" border=\"0\"></a></center>", imageCid);
                    //else
                    //    oMsg.HTMLBody += String.Format("<br><br><center><img src=\"cid:{0}\"></center>", imageCid);

                    Attachment att = new Attachment(ResimYerleri[i].ToString());
                    att.ContentDisposition.Inline = true;
                    att.ContentId = Guid.NewGuid().ToString();
                    mail.Body += String.Format(@"<br><br><center><img src=""cid:{0}"" /></center>", att.ContentId);
                    mail.Attachments.Add(att);

                    j++;
                }


                //oMsg.Send();

                //onS.Logoff();

                //oMsg = null;
                //onS = null;
                //oApp = null;
                //GC.Collect();


                client.Send(mail);
            }
            catch (Exception ex)
            {
                Hatalar.DoInsert(ex, "Çoklu Eposta Gönderimi");
            }
            Cursor.Current = Cursors.AppStarting;
        }
        //
        private ArrayList ExceldenAl(string dosya, string satirsayisi)
        {
            ArrayList donendeger = new ArrayList();

            Microsoft.Office.Interop.Excel.Application ap = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook wb = null;
            Microsoft.Office.Interop.Excel.Worksheet ws = null;
            Microsoft.Office.Interop.Excel.Range range = null;

            object[,] values = null;

            try
            {
                wb = ap.Workbooks.Open(dosya, false, true,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing, true);

                ws = (Microsoft.Office.Interop.Excel.Worksheet)wb.Worksheets[1];

                range = ws.get_Range("A1", "B" + satirsayisi);

                values = (object[,])range.Value2;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata");
                return new ArrayList();
            }
            finally
            {
                range = null;
                ws = null;
                if (wb != null)
                    wb.Close(false, System.Reflection.Missing.Value, System.Reflection.Missing.Value);
                wb = null;
                if (ap != null)
                    ap.Quit();
                ap = null;
            }

            try
            {
                string hatalisatirlar = string.Empty;
                for (int i = 1; i <= values.GetLength(0); i++)
                {
                    int atindex = values[i, 1].ToString().IndexOf("@");
                    int noktaindex = atindex > 0 ? noktaindex = values[i, 1].ToString().IndexOf(".", atindex) : -1;

                    if (atindex > 0 && noktaindex != -1)
                    {
                        donendeger.Add(values[i, 1].ToString());
                        Isimler.Add(values[i, 2].ToString());
                    }
                    else
                    {
                        hatalisatirlar += i.ToString() + ". Satır:\t\t" + values[i, 1].ToString() + "\r\n";
                    }
                }

                if (hatalisatirlar.Length > 0)
                {
                    //hatalisatirlar = hatalisatirlar.Substring(0, hatalisatirlar.Length - 2);
                    MessageBox.Show("Şu satırlarda hata var:\r\n\r\n" + hatalisatirlar, "Hatalı satırlar var", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    donendeger = new ArrayList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata");
            }

            return donendeger;
        }
        //
        //
        // Events
        //
        private void btnExcel_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Excel dosyaları (*.xls, *.xlsx)|*.xls;*.xlsx;|Bütün Dosyalar|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtExcel.Text = ofd.FileName;
                panel1.Visible = true;
                panel1.Location = new Point(0, 0);
                panel1.Size = new System.Drawing.Size(this.Width, this.Height);
            }
        }
        //
        private void btnSatirSayisi_Click(object sender, EventArgs e)
        {
            Epostalar = ExceldenAl(txtExcel.Text, txtSatirSayisi.Text.Trim());
            panel1.Visible = false;
            if (Epostalar.Count != 0)
                btnGonder.Enabled = true;
        }
        //
        private void btnYardim_Click(object sender, EventArgs e)
        {
            frmYardim frm = new frmYardim(Sultanlar.UI.Properties.Resources.ornekeposta);
            frm.ShowDialog();
        }
        //
        private void btnEkle_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Bütün Dosyalar|*.*";
            ofd.Multiselect = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                for (int i = 0; i < ofd.FileNames.Length; i++)
                {
                    cblDosyalar.Items.Add(ofd.FileNames[i], CheckState.Checked);
                }
            }
        }
        //
        private void btnResimEkle_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Desteklenen Resim Dosyaları|*.jpeg;*.jpg;*.bmp;*.png;*.gif|JPG Dosyaları|*.jpeg;*.jpg|BMP Dosyaları|*.bmp|PNG Dosyaları|*.png|GIF Dosyaları|*.gif";
            ofd.Multiselect = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                for (int i = 0; i < ofd.FileNames.Length; i++)
                {
                    cblResimler.Items.Add(ofd.FileNames[i], CheckState.Checked);
                }
            }
        }
        //
        private void btnGonder_Click(object sender, EventArgs e)
        {
            if (txtDakikada.Text == string.Empty)
            {
                MessageBox.Show("Kaç adet eposta gönderileceği girilmedi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtSaniye.Text == string.Empty)
            {
                MessageBox.Show("Kaç saniye aralıkla eposta gönderileceği girilmedi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Göndermeye başlansın mı?", "Eposta Gönderme", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.No)
            {
                return;
            }

            //btnEkle.Enabled = false;
            //btnExcel.Enabled = false;
            //btnGonder.Enabled = false;

            panel2.Visible = true;
            panel2.Location = new Point(0, 0);
            panel2.Size = new System.Drawing.Size(this.Width, this.Height);

            lblSonGonderilen.Text = string.Empty;
            lbSonGonderilenler.Items.Clear();
            lbGonderilenler.Items.Clear();

            Icerik = edAciklama.BodyHtml;

            Dosyalar = new ArrayList();
            for (int i = 0; i < cblDosyalar.CheckedItems.Count; i++)
                Dosyalar.Add(cblDosyalar.CheckedItems[i].ToString());

            Resimler = new ArrayList();
            for (int i = 0; i < cblResimler.CheckedItems.Count; i++)
                Resimler.Add(cblResimler.CheckedItems[i].ToString());

            tmr.Interval = Convert.ToDouble(txtSaniye.Text) * 1000;

            Islem();

            BaslangicSuresi = DateTime.Now;
            tmrVakit.Enabled = true;
            tmrVakit.Start();

            tmr.Enabled = true;
            tmr.Start();
        }
        //
        private void tmr_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            Islem();
        }
        //
        private void tmrVakit_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            string sure = (DateTime.Now.AddSeconds(1) - BaslangicSuresi).ToString();
            lblSure.Text = sure.Substring(0, sure.IndexOf("."));
        }
        //
        private void txtDakikada_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < ((TextBox)sender).Text.Length; i++)
            {
                if (!char.IsNumber(((TextBox)sender).Text[i]))
                    ((TextBox)sender).Text = string.Empty;
            }
        }
        //
        private void txtSatirSayisi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSatirSayisi.PerformClick();
            }
        }
    }
}

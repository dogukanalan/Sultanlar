using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sultanlar.DatabaseObject;
using Microsoft.Win32;
using System.Xml;
using System.IO;
using Sultanlar.DatabaseObject.Internet;
using System.Data.SqlClient;
using Sultanlar.Class;
using Sultanlar.DatabaseObject.Kenton;
using System.Net.NetworkInformation;
using System.Deployment.Application;
using System.Net;
using System.Diagnostics;

namespace Sultanlar.UI
{
    public partial class frmAna : Form
    {
        public frmAna()
        {
            InitializeComponent();
        }
        //
        //
        //
        //
        //
        internal static string KAdi;
        internal static string InputBox;
        FormErisimleri fe;
        Timer tmr;
        //
        //
        //
        //
        //
        private void frmAna_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;

            InputBox = string.Empty;

            AcilisSecenekleri();

            treeView1.ExpandAll();

            //for (int i = 0; i < treeView1.Nodes.Count; i++)
            //{
            //    MessageBox.Show(treeView1.Nodes[i].Name);
            //    for (int j = 0; j < treeView1.Nodes[i].Nodes.Count; j++)
            //    {
            //        MessageBox.Show(treeView1.Nodes[i].Nodes[j].Name);
            //    }
            //}

            fe = null;

            //System.Net.ServicePointManager.Expect100Continue = true;
            //System.Net.ServicePointManager.SecurityProtocol = (System.Net.SecurityProtocolType)3072;
            //RssKenton("https://www.kenton.com.tr/kategori/tarifler/feed/");
            //RssKenton("https://www.kenton.com.tr/kategori/tatli-tarifleri/feed/");
            //RssVideo("https://www.kenton.com.tr/kategori/kenton-video/feed/");
            //RssVideo("https://www.kenton.com.tr/kategori/tatli-sefi-video/feed/");

            if (ApplicationDeployment.IsNetworkDeployed) // yeni sürüm kontrolu
            {
                tmr = new Timer();
                tmr.Interval = 300000;
                tmr.Tick += new EventHandler(tmr_Tick);
                tmr.Start();
            }
        }

        private void tmr_Tick(object sender, EventArgs e)
        {
            try
            {
                WebResponse wr = WebRequest.Create("https://www.sultanlar.com.tr/sultanlarui/index.htm").GetResponse();
                Stream stream = wr.GetResponseStream();
                StreamReader strR = new StreamReader(stream, Encoding.GetEncoding("iso-8859-9"));
                string sayfa = strR.ReadToEnd();
                strR.Close();
                wr.Close();

                int baslangic = sayfa.IndexOf("<TR><TD><B>Version:</B></TD><TD WIDTH=\"5\"><SPACER TYPE=\"block\" WIDTH=\"10\" /></TD><TD>") + 85;
                int bitis = sayfa.IndexOf("</TD>", baslangic);
                string surum = string.Empty;
                if (baslangic > 84 && bitis > 85)
                    surum = sayfa.Substring(baslangic, bitis - baslangic);

                string programsurum = ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString(4);

                if (surum != programsurum)
                {
                    this.Text = this.Text.Substring(0, 23) + " [Yeni sürüm mevcut]";
                    MessageBox.Show("Uygulamanın daha yeni bir sürümü mevcut, lütfen uygulamayı kapatın. Tekrar açtığınızda otomatik güncellenecektir.", "Güncelleme Uyarısı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                Hatalar.DoInsert(ex, "frmAna sürüm kontrol");
            }
        }

        private void RssKenton(string url)
        {
            List<Tarifler> tarifler = new List<Tarifler>();
            Tarifler trf = new Tarifler();

            string tur = url == "https://www.kenton.com.tr/kategori/tarifler/feed/" ? "<span id='rssfeedtarifxml'></span>" : "<span id='rssfeedtatlitarifxml'></span>";

            XmlTextReader reader = new XmlTextReader(url);
            bool oku = false;
            bool itemicinde = false;
            bool baslik = true;
            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element:
                        //while (reader.MoveToNextAttribute())
                        //    MessageBox.Show(" " + reader.Name + "='" + reader.Value + "'");
                        if (reader.Name == "item")
                            itemicinde = true;
                        if (reader.Name == "title" || reader.Name == "pubDate" || reader.Name == "content:encoded")
                            oku = true;
                        break;

                    case XmlNodeType.CDATA: // içindekiler
                        if (oku && itemicinde)
                        {
                            string malzemeler = string.Empty;
                            string icerik = string.Empty;
                            string img = string.Empty;
                            string img2 = string.Empty;

                            int malzemeBas = reader.Value.IndexOf("<div class=\"wpb_wrapper\">", reader.Value.IndexOf("tarif-ozel")) + 25;
                            int malzemeBit = reader.Value.IndexOf("</div>", malzemeBas);
                            malzemeler = reader.Value.Substring(malzemeBas, malzemeBit - malzemeBas).Trim();
                            trf.strMalzemeler = tur + malzemeler;

                            int icerikBas = reader.Value.IndexOf("<div class=\"wpb_wrapper\">", reader.Value.IndexOf("justify")) + 25;
                            int icerikBit = reader.Value.IndexOf("</div>", icerikBas);
                            icerik = reader.Value.Substring(icerikBas, icerikBit - icerikBas).Trim();
                            trf.strHazirlanis = icerik;

                            int baskaimgvarmi = reader.Value.IndexOf("title=\"satınal\"");
                            int imgBas1 = 0;
                            if (baskaimgvarmi > -1)
                                imgBas1 = reader.Value.IndexOf("<img ", baskaimgvarmi);
                            else
                                imgBas1 = reader.Value.IndexOf("<img ");
                            int imgBas = reader.Value.IndexOf("src=\"", imgBas1) + 5;
                            int imgBit = reader.Value.IndexOf("\"", imgBas);
                            img = reader.Value.Substring(imgBas, imgBit - imgBas).Trim();
                            //trf.binResim = Resim.ImageToByte(Resim.ResimKucult(Resim.ByteToImage(new WebClient().DownloadData(img)), 400));

                            int img2Bas1 = reader.Value.IndexOf("<img ", imgBit);
                            if (img2Bas1 > -1)
                            {
                                int img2Bas = reader.Value.IndexOf("src=\"", img2Bas1) + 5;
                                int img2Bit = reader.Value.IndexOf("\"", img2Bas);
                                img2 = reader.Value.Substring(img2Bas, img2Bit - img2Bas).Trim();
                                //trf.binResimUrunler = Resim.ImageToByte(Resim.ResimKucult(Resim.ByteToImage(new WebClient().DownloadData(img2)), 400));
                            }

                            oku = false;
                        }
                        break;

                    case XmlNodeType.Text: // birincisi başlık ikincisi tarif
                        if (oku && itemicinde)
                        {
                            if (baslik)
                            {
                                trf.strBaslik = StringParcalama.IlkHarfBuyuk(reader.Value);
                                baslik = false;
                            }
                            else
                            {
                                trf.dtTarih = Convert.ToDateTime(reader.Value);
                                baslik = true;
                            }
                            oku = false;
                        }
                        break;

                    case XmlNodeType.EndElement:
                        if (reader.Name == "item")
                        {
                            if (trf.dtTarih <= Tarifler.GetLastObjectTime(url == "https://www.kenton.com.tr/kategori/tatli-tarifleri/feed/"))
                            {
                                //return;
                            }
                            else
                            {
                                trf.strUrunlerLink = string.Empty;
                                trf.blOnay = true;
                                trf.intUyeID = 1;
                                //trf.DoInsert();
                                tarifler.Add(trf);
                            }
                            trf = new Tarifler();
                        }
                        break;
                }
            }

            for (int i = 0; i < tarifler.Count; i++)
                MessageBox.Show(tarifler[i].strBaslik);
        }

        private void RssVideo(string url)
        {
            List<Videolar> tarifler = new List<Videolar>();
            Videolar trf = new Videolar();

            XmlTextReader reader = new XmlTextReader(url);
            bool oku = false;
            bool itemicinde = false;
            string nerede = "baslik";
            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element:
                        if (reader.Name == "item")
                            itemicinde = true;
                        if (reader.Name == "title" || reader.Name == "link" || reader.Name == "pubDate" || reader.Name == "content:encoded")
                            oku = true;
                        break;

                    case XmlNodeType.CDATA: // içindekiler
                        if (oku && itemicinde)
                        {
                            string video = string.Empty;

                            int videoBas = reader.Value.IndexOf("https://www.youtube.com/embed/") + 30;
                            video = reader.Value.Substring(videoBas, 11).Trim();
                            trf.strVideo = video;

                            oku = false;
                        }
                        break;

                    case XmlNodeType.Text: // birincisi başlık ikincisi tarih
                        if (oku && itemicinde)
                        {
                            if (nerede == "baslik")
                            {
                                trf.strBaslik = StringParcalama.IlkHarfBuyuk(reader.Value);
                                nerede = "link";
                            }
                            else if (nerede == "link")
                            {
                                trf.strLink = StringParcalama.IlkHarfBuyuk(reader.Value);
                                nerede = "";
                            }
                            else
                            {
                                trf.dtTarih = Convert.ToDateTime(reader.Value);
                                nerede = "baslik";
                            }
                            oku = false;
                        }
                        break;

                    case XmlNodeType.EndElement:
                        if (reader.Name == "item")
                        {
                            trf.intTarifID = 0;
                            trf.intUyeID = 1;
                            //trf.DoInsert();
                            tarifler.Add(trf);
                            trf = new Videolar();
                        }

                        break;
                }
            }

            for (int i = 0; i < tarifler.Count; i++)
                MessageBox.Show(tarifler[i].strBaslik + " " + tarifler[i].dtTarih.ToShortDateString());
        }



        private void cetinkaya(int AktiviteID, int Ay, int Yil)
        {
            DataTable dt = new DataTable();
            AktivitelerDetay.GetObjectsByAktiviteID(dt, AktiviteID);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                decimal fiyat = FiyatlarTP.GetFiyat(Convert.ToInt32(dt.Rows[i]["intUrunID"]), 22, Yil, Ay);
                double kdv = Urunler.GetProductKDV(Convert.ToInt32(dt.Rows[i]["intUrunID"]));
                dt.Rows[i]["mnBirimFiyatKDVli"] = fiyat * ((Convert.ToDecimal(kdv) + 100) / 100);
                decimal dusulmusfiyat = Convert.ToDecimal(dt.Rows[i]["mnBirimFiyatKDVli"]) - ((Convert.ToDecimal(dt.Rows[i]["mnBirimFiyatKDVli"]) / 100) * Convert.ToDecimal(dt.Rows[i]["strAciklama1"]));
                decimal dusulmusfiyat1 = dusulmusfiyat - ((dusulmusfiyat / 100) * Convert.ToDecimal(dt.Rows[i]["strAciklama2"]));
                decimal dusulmusfiyat2 = dusulmusfiyat1 - ((dusulmusfiyat1 / 100) * Convert.ToDecimal(dt.Rows[i]["strAciklama3"]));
                if (dusulmusfiyat2 == 0)
                    dt.Rows[i]["flEkIsk"] = 0.0;
                else
                    dt.Rows[i]["flEkIsk"] = (1 - (Convert.ToDouble(dt.Rows[i]["mnDusulmusBirimFiyatKDVli"]) / Convert.ToDouble(dusulmusfiyat2))) * 100;

                //decimal saglama = dusulmusfiyat2 - ((dusulmusfiyat2 / 100) * Convert.ToDecimal(dt.Rows[i]["flEkIsk"]));

                //MessageBox.Show("birim fiyat: " + dt.Rows[i]["mnBirimFiyatKDVli"].ToString() + " ek isk: " + dt.Rows[i]["flEkIsk"] + " saglama: " + saglama.ToString());

                AktivitelerDetay aktdet = AktivitelerDetay.GetObject(Convert.ToInt64(dt.Rows[i]["pkID"]));
                aktdet.mnBirimFiyatKDVli = Convert.ToDecimal(dt.Rows[i]["mnBirimFiyatKDVli"]);
                aktdet.flEkIsk = Convert.ToDouble(dt.Rows[i]["flEkIsk"]);
                aktdet.strAciklama4 = "0";
                aktdet.DoUpdate();
            }
        }

        private void AcilisSecenekleri()
        {
            /*RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Sultanlar", true);

            if (key != null)
            {
                if (key.GetValue("SolMenu").ToString() == "evet")
                {
                    treeView1.Visible = true;
                    cbSolMenu.Checked = true;
                }
                else if (key.GetValue("SolMenu").ToString() == "hayir")
                {
                    treeView1.Visible = false;
                    cbSolMenu.Checked = false;
                }
            }
            else
            {
                RegistryKey key1 = Registry.CurrentUser.CreateSubKey(@"Software\Sultanlar");
                RegistryKey key2 = Registry.CurrentUser.OpenSubKey(@"Software\Sultanlar", true);
                key2.SetValue("SolMenu", "evet");
                treeView1.Visible = true;
            }*/

            if (ApplicationDeployment.IsNetworkDeployed)
            {
                lblSurum.Text = ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString();
                this.Text = "Sultanlar UI - " + lblSurum.Text;
            }
            
            if (!Directory.Exists(Application.StartupPath + "\\temp"))
                Directory.CreateDirectory(Application.StartupPath + "\\temp");
            if (!Directory.Exists(Application.StartupPath + "\\temp\\Sultanlar"))
                Directory.CreateDirectory(Application.StartupPath + "\\temp\\Sultanlar");
        }
        //
        //
        private void FormuAktifEt(string formadi)
        {
            for (int i = 0; i < menuStrip1.Items.Count; i++)
            {
                if (menuStrip1.Items[i].Name == formadi)
                {
                    menuStrip1.Items[i].Enabled = true;
                }
                ToolStripMenuItem tsmi = (ToolStripMenuItem)menuStrip1.Items[i];

                if (tsmi.DropDownItems.Count > 0)
                {
                    for (int j = 0; j < tsmi.DropDownItems.Count; j++)
                    {
                        if (tsmi.DropDownItems[j].Name == formadi)
                        {
                            tsmi.DropDownItems[j].Enabled = true;
                        }
                        ToolStripMenuItem tsmi2 = (ToolStripMenuItem)tsmi.DropDownItems[j];

                        if (tsmi2.DropDownItems.Count > 0)
                        {
                            for (int k = 0; k < tsmi2.DropDownItems.Count; k++)
                            {
                                if (tsmi2.DropDownItems[k].Name == formadi)
                                {
                                    tsmi2.DropDownItems[k].Enabled = true;
                                }
                                //ToolStripMenuItem tsmi3 = (ToolStripMenuItem)tsmi2.DropDownItems[k];
                            }
                        }
                    }
                }
            }
        }
        //
        //
        public void FormKapanirken(string formadi)
        {
            foreach (ToolStripItem tsi in statusStrip1.Items)
            {
                if (tsi.Name == formadi)
                {
                    statusStrip1.Items.Remove(tsi);
                    return;
                }
            }
        }
        //
        //
        //
        // Olaylar:
        //
        private void frm_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormKapanirken(((Form)sender).Name);
        }
        //
        //
        #region MenuItemClick
        private void haberlerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmHaberler")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmHaberler frm = new frmHaberler();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();
            frm.BringToFront();

            ToolStripButton lll = new ToolStripButton("Haberler");
            lll.Name = "frmHaberler";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void tedarikçilerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmTedarikciler")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmTedarikciler frm = new frmTedarikciler();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();

            ToolStripButton lll = new ToolStripButton("Tedarikçiler");
            lll.Name = "frmTedarikciler";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void başvurularToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmBasvurular")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmBasvurular frm = new frmBasvurular(KAdi);
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();

            ToolStripButton lll = new ToolStripButton("Başvurular");
            lll.Name = "frmBasvurular";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void işİstekleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmArananGorevler")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmArananGorevler frm = new frmArananGorevler();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();

            ToolStripButton lll = new ToolStripButton("Eleman Talepleri");
            lll.Name = "frmArananGorevler";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void görevlerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmGorevler")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmGorevler frm = new frmGorevler();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();

            ToolStripButton lll = new ToolStripButton("Görevler");
            lll.Name = "frmGorevler";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void departmanlarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmDepartmanlar")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmDepartmanlar frm = new frmDepartmanlar();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();

            ToolStripButton lll = new ToolStripButton("Departmanlar");
            lll.Name = "frmDepartmanlar";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void yetkilerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmYetkiler")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmYetkiler frm = new frmYetkiler();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();

            ToolStripButton lll = new ToolStripButton("Yetkiler");
            lll.Name = "frmYetkiler";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void hatalarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmHatalar")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmHatalar frm = new frmHatalar();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();

            ToolStripButton lll = new ToolStripButton("Loglar");
            lll.Name = "frmHatalar";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void nöbetçiEczanelerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmNobetciEczaneler")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmNobetciEczaneler frm = new frmNobetciEczaneler();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();

            ToolStripButton lll = new ToolStripButton("Nöbetçi Eczaneler");
            lll.Name = "frmNobetciEczaneler";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void araçlarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmAraclar")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmAraclar frm = new frmAraclar();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();

            ToolStripButton lll = new ToolStripButton("Araçlar");
            lll.Name = "frmAraclar";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void personellerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmPersoneller")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmPersoneller frm = new frmPersoneller();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();

            ToolStripButton lll = new ToolStripButton("Personeller");
            lll.Name = "frmPersoneller";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void araçGiderleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmAracGiderleri")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmAracGiderleri frm = new frmAracGiderleri();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();

            ToolStripButton lll = new ToolStripButton("Araç Giderleri");
            lll.Name = "frmAracGiderleri";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void broşürHazırlamaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmBrosur")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmBrosur frm = new frmBrosur();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();

            ToolStripButton lll = new ToolStripButton("Broşür Hazırlama");
            lll.Name = "frmBrosur";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void kampanyaHazırlamaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmKampanya")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmKampanya frm = new frmKampanya();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();

            ToolStripButton lll = new ToolStripButton("Kampanya Hazırlama");
            lll.Name = "frmKampanya";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void markalarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmAracMarkalari")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmAracMarkalari frm = new frmAracMarkalari();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();

            ToolStripButton lll = new ToolStripButton("Markalar");
            lll.Name = "frmAracMarkalari";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void türlerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmAracTurleri")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmAracTurleri frm = new frmAracTurleri();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();

            ToolStripButton lll = new ToolStripButton("Türler");
            lll.Name = "frmAracTurleri";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void siparişlerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmTekUrunSiparisler")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmTekUrunSiparisler frm = new frmTekUrunSiparisler();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();

            ToolStripButton lll = new ToolStripButton("Tek Ürün Satışı : Siparişler");
            lll.Name = "frmTekUrunSiparisler";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void genelBilgilerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmTekUrunGenel")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmTekUrunGenel frm = new frmTekUrunGenel();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();

            ToolStripButton lll = new ToolStripButton("Tek Ürün Satışı : Genel Bilgiler");
            lll.Name = "frmTekUrunGenel";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void siparişDurumlarıListesiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmTekUrunSiparisDurumlari")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmTekUrunSiparisDurumlari frm = new frmTekUrunSiparisDurumlari();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();

            ToolStripButton lll = new ToolStripButton("Tek Ürün Satışı : Sipariş Durumları Listesi");
            lll.Name = "frmTekUrunSiparisDurumlari";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void kargoŞirketleriListesiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmTekUrunKargoSirketleri")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmTekUrunKargoSirketleri frm = new frmTekUrunKargoSirketleri();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();

            ToolStripButton lll = new ToolStripButton("Tek Ürün Satışı : Kargo Şirketleri Listesi");
            lll.Name = "frmTekUrunKargoSirketleri";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void üyelerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmINTERNETmusteriler")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmINTERNETmusteriler frm = new frmINTERNETmusteriler();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();

            ToolStripButton lll = new ToolStripButton("Üyeler");
            lll.Name = "frmINTERNETmusteriler";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void üyeGruplarıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmINTERNETuyegruplari")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmINTERNETuyegruplari frm = new frmINTERNETuyegruplari();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();

            ToolStripButton lll = new ToolStripButton("Üye Grupları");
            lll.Name = "frmINTERNETuyegruplari";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void cariHesapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmFinansCariHesapHareketler")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmFinansCariHesapHareketler frm = new frmFinansCariHesapHareketler();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();

            ToolStripButton lll = new ToolStripButton("Finans : Tahsilat Hareketleri");
            lll.Name = "frmFinansCariHesapHareketler";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void cHEkstresiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmCHEkstresi")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmCHEkstresi frm = new frmCHEkstresi();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();

            ToolStripButton lll = new ToolStripButton("Finans : C/H Ekstresi");
            lll.Name = "frmCHEkstresi";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void fiyatListeleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmINTERNETfiyatlisteleri")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmINTERNETfiyatlisteleri frm = new frmINTERNETfiyatlisteleri();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();

            ToolStripButton lll = new ToolStripButton("Web Satış Bölümü : Fiyat Listeleri");
            lll.Name = "frmINTERNETfiyatlisteleri";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void üyeKayıtFormuYetkileriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmUyeKayitFormuYetkileri")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmUyeKayitFormuYetkileri frm = new frmUyeKayitFormuYetkileri();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();

            ToolStripButton lll = new ToolStripButton("Üye Kayıt Formu Yetkileri");
            lll.Name = "frmUyeKayitFormuYetkileri";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void resimlerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmINTERNETresimler")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmINTERNETresimler frm = new frmINTERNETresimler();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();

            ToolStripButton lll = new ToolStripButton("Resimler");
            lll.Name = "frmINTERNETresimler";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void epostaGöndermeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmEpostaGonderme")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmEpostaGonderme frm = new frmEpostaGonderme();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();

            ToolStripButton lll = new ToolStripButton("Eposta Gönderme");
            lll.Name = "frmEpostaGonderme";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void mesajlarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmINTERNETmesajlar")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmINTERNETmesajlar frm = new frmINTERNETmesajlar();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();

            ToolStripButton lll = new ToolStripButton("Mesajlar");
            lll.Name = "frmINTERNETmesajlar";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void şifreSıfırlamaTalepleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmINTERNETmusterisifresifirlamatalepleri")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmINTERNETmusterisifresifirlamatalepleri frm = new frmINTERNETmusterisifresifirlamatalepleri();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();

            ToolStripButton lll = new ToolStripButton("Şifre Sıfırlama Talepleri");
            lll.Name = "frmINTERNETmusterisifresifirlamatalepleri";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void iadelerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmINTERNETiadeler")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmINTERNETiadeler frm = new frmINTERNETiadeler();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();

            ToolStripButton lll = new ToolStripButton("İadeler");
            lll.Name = "frmINTERNETiadeler";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void webSanalPosİşlemleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmFinansSanalPos")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmFinansSanalPos frm = new frmFinansSanalPos();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();

            ToolStripButton lll = new ToolStripButton("Finans : Web Sanal Pos İşlemleri");
            lll.Name = "frmFinansSanalPos";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void satışTemsilcisiŞeflerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmINTERNETsatistemsilcilerisefler")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmINTERNETsatistemsilcilerisefler frm = new frmINTERNETsatistemsilcilerisefler();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();

            ToolStripButton lll = new ToolStripButton("Satış Temsilcisi Şefler");
            lll.Name = "frmINTERNETsatistemsilcilerisefler";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void hizmetlerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmINTERNETsonradanhizmet")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmINTERNETsonradanhizmet frm = new frmINTERNETsonradanhizmet();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();

            ToolStripButton lll = new ToolStripButton("Hizmetler");
            lll.Name = "frmINTERNETsonradanhizmet";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void satışTemsilcisiCariHesapEklemeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmFinansCariHesapEklemeCikarma")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmFinansCariHesapEklemeCikarma frm = new frmFinansCariHesapEklemeCikarma();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();

            ToolStripButton lll = new ToolStripButton("Satış Temsilcisi Cari Hesap Ekleme");
            lll.Name = "frmFinansCariHesapEklemeCikarma";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void primOranlarıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmPrimler")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmPrimler frm = new frmPrimler();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();
            frm.BringToFront();

            ToolStripButton lll = new ToolStripButton("Primler");
            lll.Name = "frmPrimler";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void malzemeKategoriMarkaSeçimleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmINTERNETmalzemekategorimarka")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmINTERNETmalzemekategorimarka frm = new frmINTERNETmalzemekategorimarka();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();
            frm.BringToFront();

            ToolStripButton lll = new ToolStripButton("Malzeme Kategori Marka Seçimleri");
            lll.Name = "frmINTERNETmalzemekategorimarka";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void eTicaretSiparişleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmINTERNETentegra")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmINTERNETentegra frm = new frmINTERNETentegra();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();
            frm.BringToFront();

            ToolStripButton lll = new ToolStripButton("E-Ticaret Siparişleri");
            lll.Name = "frmINTERNETentegra";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void müşterilerVeAltCarilerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmINTERNETticaripazarlamamusteriler")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmINTERNETticaripazarlamamusteriler frm = new frmINTERNETticaripazarlamamusteriler();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();
            frm.BringToFront();

            ToolStripButton lll = new ToolStripButton("Ticari Pazarlama : Müşteriler ve Alt Cariler");
            lll.Name = "frmINTERNETticaripazarlamamusteriler";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void stokKartlarıVeFiyatlarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmINTERNETticaripazarlamastoklar")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmINTERNETticaripazarlamastoklar frm = new frmINTERNETticaripazarlamastoklar();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();
            frm.BringToFront();

            ToolStripButton lll = new ToolStripButton("Ticari Pazarlama : Stok Kartları ve Fiyatlar");
            lll.Name = "frmINTERNETticaripazarlamastoklar";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void aktivitelerToolStripMenuItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmINTERNETticaripazarlamaaktiviteler")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmINTERNETticaripazarlamaaktiviteler frm = new frmINTERNETticaripazarlamaaktiviteler();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();
            frm.BringToFront();

            ToolStripButton lll = new ToolStripButton("TP:Aktiviteler (TÜMÜ)");
            lll.Name = "frmINTERNETticaripazarlamaaktiviteler";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void hizmetBedelleriToolStripMenuItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmINTERNETticaripazarlamahizmetbedelleri")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmINTERNETticaripazarlamahizmetbedelleri frm = new frmINTERNETticaripazarlamahizmetbedelleri();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();
            frm.BringToFront();

            ToolStripButton lll = new ToolStripButton("TP:Hizmet Bedelleri (TÜMÜ)");
            lll.Name = "frmINTERNETticaripazarlamahizmetbedelleri";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void satışRaporuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmINTERNETticaripazarlamasatisrapor")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmINTERNETticaripazarlamasatisrapor frm = new frmINTERNETticaripazarlamasatisrapor();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();
            frm.BringToFront();

            ToolStripButton lll = new ToolStripButton("TP:Satış Raporu");
            lll.Name = "frmINTERNETticaripazarlamasatisrapor";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void anlaşmalarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmINTERNETticaripazarlamaanlasmalar")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmINTERNETticaripazarlamaanlasmalar frm = new frmINTERNETticaripazarlamaanlasmalar();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();
            frm.BringToFront();

            ToolStripButton lll = new ToolStripButton("TP:Anlaşmalar (TÜMÜ)");
            lll.Name = "frmINTERNETticaripazarlamaanlasmalar";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void lojistikFirmalarıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmAT2lojistikfirmalar")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmAT2lojistikfirmalar frm = new frmAT2lojistikfirmalar();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();
            frm.BringToFront();

            ToolStripButton lll = new ToolStripButton("Lojistik Firmaları");
            lll.Name = "frmAT2lojistikfirmalar";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void bölgelerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmAT2bolgeler")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmAT2bolgeler frm = new frmAT2bolgeler();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();
            frm.BringToFront();

            ToolStripButton lll = new ToolStripButton("Bölgeler");
            lll.Name = "frmAT2bolgeler";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void araçTipleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmAT2aractipler")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmAT2aractipler frm = new frmAT2aractipler();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();
            frm.BringToFront();

            ToolStripButton lll = new ToolStripButton("Araç Tipleri");
            lll.Name = "frmAT2aractipler";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void şoförVeMuavinlerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmAT2soforlermuavinler")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmAT2soforlermuavinler frm = new frmAT2soforlermuavinler();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();
            frm.BringToFront();

            ToolStripButton lll = new ToolStripButton("Şoför ve Muavinler");
            lll.Name = "frmAT2soforlermuavinler";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void araçlarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmAT2araclar")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmAT2araclar frm = new frmAT2araclar();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();
            frm.BringToFront();

            ToolStripButton lll = new ToolStripButton("Araçlar");
            lll.Name = "frmAT2araclar";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void araçBedelleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmAT2aracbedelleri")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmAT2aracbedelleri frm = new frmAT2aracbedelleri();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();
            frm.BringToFront();

            ToolStripButton lll = new ToolStripButton("Araç Bedelleri");
            lll.Name = "frmAT2aracbedelleri";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void siparişToplamaPersonelleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmAT2personeller")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmAT2personeller frm = new frmAT2personeller();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();
            frm.BringToFront();

            ToolStripButton lll = new ToolStripButton("Sipariş Toplama Personelleri");
            lll.Name = "frmAT2personeller";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void rotalarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmAT2rotalar")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmAT2rotalar frm = new frmAT2rotalar();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();
            frm.BringToFront();

            ToolStripButton lll = new ToolStripButton("Rotalar");
            lll.Name = "frmAT2rotalar";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void rotamusteribağlantılarıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmAT2rotamusteri")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmAT2rotamusteri frm = new frmAT2rotamusteri();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();
            frm.BringToFront();

            ToolStripButton lll = new ToolStripButton("Rota Müşteri Bağlantıları");
            lll.Name = "frmAT2rotamusteri";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void ürünFiyatTipiBağlantılarıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmINTERNETfiyaturunbaglanti")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmINTERNETfiyaturunbaglanti frm = new frmINTERNETfiyaturunbaglanti();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();
            frm.BringToFront();

            ToolStripButton lll = new ToolStripButton("Ürün Fiyat Tipi Bağlantıları");
            lll.Name = "frmINTERNETfiyaturunbaglanti";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void depoDenetlemeleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmDepoDenetlemeler")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmDepoDenetlemeler frm = new frmDepoDenetlemeler();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();
            frm.BringToFront();

            ToolStripButton lll = new ToolStripButton("Depo Denetlemeleri");
            lll.Name = "frmDepoDenetlemeler";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void ürünAktifPasifSeçimiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmINTERNETurunaktifpasif")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmINTERNETurunaktifpasif frm = new frmINTERNETurunaktifpasif();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();
            frm.BringToFront();

            ToolStripButton lll = new ToolStripButton("Ürün Aktif-Pasif Seçimi");
            lll.Name = "frmINTERNETurunaktifpasif";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void bayiCiroPrimleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmINTERNETticaripazarlamabayiciroprimleri")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmINTERNETticaripazarlamabayiciroprimleri frm = new frmINTERNETticaripazarlamabayiciroprimleri();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();
            frm.BringToFront();

            ToolStripButton lll = new ToolStripButton("Bayi Ciro Primleri");
            lll.Name = "frmINTERNETticaripazarlamabayiciroprimleri";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void hedeflerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmINTERNEThedef")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmINTERNEThedef frm = new frmINTERNEThedef();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();
            frm.BringToFront();

            ToolStripButton lll = new ToolStripButton("Hedefler");
            lll.Name = "frmINTERNEThedef";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void hizmetBedelleri2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmINTERNETticaripazarlamahizmetbedelleridd")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmINTERNETticaripazarlamahizmetbedelleridd frm = new frmINTERNETticaripazarlamahizmetbedelleridd();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();
            frm.BringToFront();

            ToolStripButton lll = new ToolStripButton("Hizmet Bedelleri 2");
            lll.Name = "frmINTERNETticaripazarlamahizmetbedelleridd";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void personelBağlantılarıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmINTERNETpersonelbaglantilari")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmINTERNETpersonelbaglantilari frm = new frmINTERNETpersonelbaglantilari();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();
            frm.BringToFront();

            ToolStripButton lll = new ToolStripButton("Personel Bağlantıları");
            lll.Name = "frmINTERNETpersonelbaglantilari";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void bayiNihaiKapamaFaturalarıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmINTERNETticaripazarlamabayinihaikapamalar")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmINTERNETticaripazarlamabayinihaikapamalar frm = new frmINTERNETticaripazarlamabayinihaikapamalar();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();
            frm.BringToFront();

            ToolStripButton lll = new ToolStripButton("Bayi Nihai Kapamaları");
            lll.Name = "frmINTERNETticaripazarlamabayinihaikapamalar";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void bayiStoklarıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmINTERNETticaripazarlamabayistoklar")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmINTERNETticaripazarlamabayistoklar frm = new frmINTERNETticaripazarlamabayistoklar();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();
            frm.BringToFront();

            ToolStripButton lll = new ToolStripButton("Bayi Stokları");
            lll.Name = "frmINTERNETticaripazarlamabayistoklar";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void iadeİşlemSüreciToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmINTERNETiadeislem")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmINTERNETiadeislem frm = new frmINTERNETiadeislem();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();
            frm.BringToFront();

            ToolStripButton lll = new ToolStripButton("İadeler İşlem Süreci");
            lll.Name = "frmINTERNETiadeislem";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void diğerMüşterilerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmINTERNETcarihesapz")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmINTERNETcarihesapz frm = new frmINTERNETcarihesapz();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();
            frm.BringToFront();

            ToolStripButton lll = new ToolStripButton("Diğer Müşteriler");
            lll.Name = "frmINTERNETcarihesapz";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void görsellerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmINTERNETresimler2")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmINTERNETresimler2 frm = new frmINTERNETresimler2();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();
            frm.BringToFront();

            ToolStripButton lll = new ToolStripButton("Görseller");
            lll.Name = "frmINTERNETresimler2";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void üyelerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmKENTON_Uyeler")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmKENTON_Uyeler frm = new frmKENTON_Uyeler();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();
            frm.BringToFront();

            ToolStripButton lll = new ToolStripButton("Kenton : Üyeler");
            lll.Name = "frmKENTON_Uyeler";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void tariflerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmKENTON_Tarifler")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmKENTON_Tarifler frm = new frmKENTON_Tarifler();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();
            frm.BringToFront();

            ToolStripButton lll = new ToolStripButton("Kenton : Tarifler");
            lll.Name = "frmKENTON_Tarifler";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void yorumlarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmKENTON_Yorumlar")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmKENTON_Yorumlar frm = new frmKENTON_Yorumlar();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();
            frm.BringToFront();

            ToolStripButton lll = new ToolStripButton("Kenton : Yorumlar");
            lll.Name = "frmKENTON_Yorumlar";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void kütüphaneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmINTERNETkutuphane")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmINTERNETkutuphane frm = new frmINTERNETkutuphane();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();
            frm.BringToFront();

            ToolStripButton lll = new ToolStripButton("Kütüphane");
            lll.Name = "frmINTERNETkutuphane";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void kütüphane2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmINTERNETkutuphane2")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmINTERNETkutuphane2 frm = new frmINTERNETkutuphane2();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();
            frm.BringToFront();

            ToolStripButton lll = new ToolStripButton("Kütüphane 2");
            lll.Name = "frmINTERNETkutuphane2";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void anketlerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmINTERNETanketler")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmINTERNETanketler frm = new frmINTERNETanketler();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();
            frm.BringToFront();

            ToolStripButton lll = new ToolStripButton("Anketler");
            lll.Name = "frmINTERNETanketler";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void şirketlerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmSirketler")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmSirketler frm = new frmSirketler();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();
            frm.BringToFront();

            ToolStripButton lll = new ToolStripButton("Şirketler");
            lll.Name = "frmSirketler";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void tatilGünleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmTatiller")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmTatiller frm = new frmTatiller();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();
            frm.BringToFront();

            ToolStripButton lll = new ToolStripButton("Tatil Günleri");
            lll.Name = "frmTatiller";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void çokluMalzemeXMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmINTERNETmalzemeharic")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmINTERNETmalzemeharic frm = new frmINTERNETmalzemeharic();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();
            frm.BringToFront();

            ToolStripButton lll = new ToolStripButton("Çoklu Malzeme XML");
            lll.Name = "frmINTERNETmalzemeharic";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        #endregion
        //
        //
        #region treeView1_AfterSelect
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (treeView1.SelectedNode.Name == "ndHaberler")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmHaberler")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndTedarikciler")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmTedarikciler")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndNobetciEczaneler")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmNobetciEczaneler")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndBasvurular")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmBasvurular")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndGorevler")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmGorevler")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndDepartmanlar")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmDepartmanlar")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndIsIstekleri")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmArananGorevler")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndPersoneller")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmPersoneller")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndCariHesapHareketler")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmFinansCariHesapHareketler")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndCHEkstresi")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmCHEkstresi")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndAraclar")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmAraclar")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndAracGiderleri")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmAracGiderleri")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndAracMarkalari")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmAracMarkalari")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndAracTurleri")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmAracTurleri")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndBrosurHazirlama")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmBrosur")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndKampanyaHazirlama")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmKampanya")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndTekUrunSiparisler")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmTekUrunSiparisler")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndTekUrunGenelBilgiler")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmTekUrunGenel")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndTekUrunSiparisDurumlari")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmTekUrunSiparisDurumlari")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndTekUrunKargoSirketleri")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmTekUrunKargoSirketleri")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndYetkiler")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmYetkiler")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndHatalar")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmHatalar")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndUyeler")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmINTERNETmusteriler")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndUyeGruplari")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmINTERNETuyegruplari")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndFiyatListeleri")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmINTERNETfiyatlisteleri")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndUyeKayitFormuYetkileri")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmUyeKayitFormuYetkileri")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndResimler")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmINTERNETresimler")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndEpostaGonderme")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmEpostaGonderme")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndMesajlar")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmINTERNETmesajlar")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndSifreSifirlamaTalepleri")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmINTERNETmusterisifresifirlamatalepleri")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndIadeler")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmINTERNETiadeler")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndSanalPos")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmFinansSanalPos")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndSatisTemsilcisiSefler")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmINTERNETsatistemsilcilerisefler")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndHizmetler")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmINTERNETsonradanhizmet")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndFinansCariHesapEklemeCikarma")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmFinansCariHesapEklemeCikarma")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndPrimler")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmPrimler")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndMalzemeKategoriMarka")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmINTERNETmalzemekategorimarka")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndDisSiparisler")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmINTERNETentegra")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndTicariPazarlamaMusteriler")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmINTERNETticaripazarlamamusteriler")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndTicariPazarlamaStoklar")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmINTERNETticaripazarlamastoklar")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndTicariPazarlamaAktiviteler")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmINTERNETticaripazarlamaaktiviteler")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndTicariPazarlamaHizmetBedelleri")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmINTERNETticaripazarlamahizmetbedelleri")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndTicariPazarlamaSatisRaporu")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmINTERNETticaripazarlamasatisrapor")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndTicariPazarlamaAnlasmalar")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmINTERNETticaripazarlamaanlasmalar")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndLojistikFirmalar")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmAT2lojistikfirmalar")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndBolgeler")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmAT2bolgeler")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndAracTipleri")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmAT2aractipler")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndSoforlerMuavinler")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmAT2soforlermuavinler")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndAraclar")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmAT2araclar")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndAracBedelleri")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmAT2aracbedelleri")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndSiparisToplamaPersonelleri")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmAT2personeller")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndRotalar")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmAT2rotalar")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndRotaMusteri")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmAT2rotamusteri")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndUrunFiyatTipiBaglantilari")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmINTERNETfiyaturunbaglanti")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndDepoDenetlemeleri")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmDepoDenetlemeler")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndUrunAktifPasif")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmINTERNETurunaktifpasif")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndBayiCiroPrimleri")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmINTERNETticaripazarlamabayiciroprimleri")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndHedefler")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmINTERNEThedef")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndHizmetBedelleri2")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmINTERNETticaripazarlamahizmetbedelleridd")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndBayiNihaiKapama")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmINTERNETticaripazarlamabayinihaikapamalar")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndPersonelBaglantilari")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmINTERNETpersonelbaglantilari")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndBayiStoklari")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmINTERNETticaripazarlamabayistoklar")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndIadeIslem")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmINTERNETiadeislem")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndDigerMusteriler")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmINTERNETcarihesapz")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndGorseller")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmINTERNETresimler2")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndKentonUyeler")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmKENTON_Uyeler")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndKentonTarifler")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmKENTON_Tarifler")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndKentonYorumlar")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmKENTON_Yorumlar")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndKutuphane")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmINTERNETkutuphane")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndAnketler")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmINTERNETanketler")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndSirketler")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmSirketler")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndTatiller")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmTatiller")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndMalzemeHaric")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmINTERNETmalzemeharic")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
        }
        #endregion
        //
        //
        #region treeView1_DoubleClick
        private void treeView1_DoubleClick(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode.Name == "ndHaberler")
            {
                if (haberlerToolStripMenuItem.Enabled)
                    haberlerToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndTedarikciler")
            {
                if (tedarikçilerToolStripMenuItem.Enabled)
                    tedarikçilerToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndNobetciEczaneler")
            {
                if (nöbetçiEczanelerToolStripMenuItem.Enabled)
                    nöbetçiEczanelerToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndBasvurular")
            {
                if (başvurularToolStripMenuItem.Enabled)
                    başvurularToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndGorevler")
            {
                if (görevlerToolStripMenuItem.Enabled)
                    görevlerToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndDepartmanlar")
            {
                if (departmanlarToolStripMenuItem.Enabled)
                    departmanlarToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndIsIstekleri")
            {
                if (işİstekleriToolStripMenuItem.Enabled)
                    işİstekleriToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndPersoneller")
            {
                if (personellerToolStripMenuItem.Enabled)
                    personellerToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndCariHesapHareketler")
            {
                if (cariHesapToolStripMenuItem.Enabled)
                    cariHesapToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndCHEkstresi")
            {
                if (cHEkstresiToolStripMenuItem.Enabled)
                    cHEkstresiToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndAraclar")
            {
                if (araçTakipToolStripMenuItem.Enabled)
                    araçlarToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndAracGiderleri")
            {
                if (araçTakipToolStripMenuItem.Enabled)
                    araçGiderleriToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndAracMarkalari")
            {
                if (araçTakipToolStripMenuItem.Enabled)
                    markalarToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndAracTurleri")
            {
                if (araçTakipToolStripMenuItem.Enabled)
                    türlerToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndBrosurHazirlama")
            {
                if (tasarımToolStripMenuItem.Enabled)
                    broşürHazırlamaToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndKampanyaHazirlama")
            {
                if (tasarımToolStripMenuItem.Enabled)
                    kampanyaHazırlamaToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndTekUrunSiparisler")
            {
                if (tekÜrünSatışıToolStripMenuItem.Enabled)
                    siparişlerToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndTekUrunGenelBilgiler")
            {
                if (tekÜrünSatışıToolStripMenuItem.Enabled)
                    genelBilgilerToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndTekUrunSiparisDurumlari")
            {
                if (tekÜrünSatışıToolStripMenuItem.Enabled)
                    siparişDurumlarıListesiToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndTekUrunKargoSirketleri")
            {
                if (tekÜrünSatışıToolStripMenuItem.Enabled)
                    kargoŞirketleriListesiToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndYetkiler")
            {
                if (yetkilerToolStripMenuItem.Enabled)
                    yetkilerToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndHatalar")
            {
                if (hatalarToolStripMenuItem.Enabled)
                    hatalarToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndUyeKayitFormuYetkileri")
            {
                if (üyeKayıtFormuYetkileriToolStripMenuItem.Enabled)
                    üyeKayıtFormuYetkileriToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndUyeler")
            {
                if (üyelerToolStripMenuItem.Enabled)
                    üyelerToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndUyeGruplari")
            {
                if (üyeGruplarıToolStripMenuItem.Enabled)
                    üyeGruplarıToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndFiyatListeleri")
            {
                if (fiyatListeleriToolStripMenuItem.Enabled)
                    fiyatListeleriToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndResimler")
            {
                if (resimlerToolStripMenuItem.Enabled)
                    resimlerToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndEpostaGonderme")
            {
                if (epostaGöndermeToolStripMenuItem.Enabled)
                    epostaGöndermeToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndMesajlar")
            {
                if (mesajlarToolStripMenuItem.Enabled)
                    mesajlarToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndSifreSifirlamaTalepleri")
            {
                if (şifreSıfırlamaTalepleriToolStripMenuItem.Enabled)
                    şifreSıfırlamaTalepleriToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndIadeler")
            {
                if (iadelerToolStripMenuItem.Enabled)
                    iadelerToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndSanalPos")
            {
                if (webSanalPosİşlemleriToolStripMenuItem.Enabled)
                    webSanalPosİşlemleriToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndSatisTemsilcisiSefler")
            {
                if (satışTemsilcisiŞeflerToolStripMenuItem.Enabled)
                    satışTemsilcisiŞeflerToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndHizmetler")
            {
                if (hizmetlerToolStripMenuItem.Enabled)
                    hizmetlerToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndFinansCariHesapEklemeCikarma")
            {
                if (satışTemsilcisiCariHesapEklemeToolStripMenuItem.Enabled)
                    satışTemsilcisiCariHesapEklemeToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndPrimler")
            {
                if (primOranlarıToolStripMenuItem.Enabled)
                    primOranlarıToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndMalzemeKategoriMarka")
            {
                if (malzemeKategoriMarkaSeçimleriToolStripMenuItem.Enabled)
                    malzemeKategoriMarkaSeçimleriToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndDisSiparisler")
            {
                if (eTicaretSiparişleriToolStripMenuItem.Enabled)
                    eTicaretSiparişleriToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndTicariPazarlamaMusteriler")
            {
                if (müşterilerVeAltCarilerToolStripMenuItem.Enabled)
                    müşterilerVeAltCarilerToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndTicariPazarlamaMusteriler")
            {
                if (müşterilerVeAltCarilerToolStripMenuItem.Enabled)
                    müşterilerVeAltCarilerToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndTicariPazarlamaStoklar")
            {
                if (stokKartlarıVeFiyatlarToolStripMenuItem.Enabled)
                    stokKartlarıVeFiyatlarToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndTicariPazarlamaAktiviteler")
            {
                if (aktivitelerToolStripMenuItem.Enabled)
                    aktivitelerToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndTicariPazarlamaHizmetBedelleri")
            {
                if (hizmetBedelleriToolStripMenuItem.Enabled)
                    hizmetBedelleriToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndTicariPazarlamaSatisRaporu")
            {
                if (satışRaporuToolStripMenuItem.Enabled)
                    satışRaporuToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndTicariPazarlamaAnlasmalar")
            {
                if (anlaşmalarToolStripMenuItem.Enabled)
                    anlaşmalarToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndLojistikFirmalar")
            {
                if (lojistikFirmalarıToolStripMenuItem.Enabled)
                    lojistikFirmalarıToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndBolgeler")
            {
                if (bölgelerToolStripMenuItem.Enabled)
                    bölgelerToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndAracTipleri")
            {
                if (araçTipleriToolStripMenuItem.Enabled)
                    araçTipleriToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndSoforlerMuavinler")
            {
                if (şoförVeMuavinlerToolStripMenuItem.Enabled)
                    şoförVeMuavinlerToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndAraclar")
            {
                if (araçlarToolStripMenuItem.Enabled)
                    araçlarToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndAracBedelleri")
            {
                if (araçBedelleriToolStripMenuItem.Enabled)
                    araçBedelleriToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndSiparisToplamaPersonelleri")
            {
                if (siparişToplamaPersonelleriToolStripMenuItem.Enabled)
                    siparişToplamaPersonelleriToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndRotalar")
            {
                if (rotalarToolStripMenuItem.Enabled)
                    rotalarToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndRotaMusteri")
            {
                if (rotaMüşteriBağlantılarıToolStripMenuItem.Enabled)
                    rotaMüşteriBağlantılarıToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndUrunFiyatTipiBaglantilari")
            {
                if (ürünFiyatTipiBağlantılarıToolStripMenuItem.Enabled)
                    ürünFiyatTipiBağlantılarıToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndDepoDenetlemeleri")
            {
                if (depoDenetlemeleriToolStripMenuItem.Enabled)
                    depoDenetlemeleriToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndUrunAktifPasif")
            {
                if (ürünAktifPasifSeçimiToolStripMenuItem.Enabled)
                    ürünAktifPasifSeçimiToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndBayiCiroPrimleri")
            {
                if (bayiCiroPrimleriToolStripMenuItem.Enabled)
                    bayiCiroPrimleriToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndHedefler")
            {
                if (hedeflerToolStripMenuItem.Enabled)
                    hedeflerToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndHizmetBedelleri2")
            {
                if (hizmetBedelleri2ToolStripMenuItem.Enabled)
                    hizmetBedelleri2ToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndBayiNihaiKapama")
            {
                if (bayiNihaiKapamaFaturalarıToolStripMenuItem.Enabled)
                    bayiNihaiKapamaFaturalarıToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndPersonelBaglantilari")
            {
                if (personelBağlantılarıToolStripMenuItem.Enabled)
                    personelBağlantılarıToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndBayiStoklari")
            {
                if (bayiStoklarıToolStripMenuItem.Enabled)
                    bayiStoklarıToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndIadeIslem")
            {
                if (iadeİşlemSüreciToolStripMenuItem.Enabled)
                    iadeİşlemSüreciToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndDigerMusteriler")
            {
                if (diğerMüşterilerToolStripMenuItem.Enabled)
                    diğerMüşterilerToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndGorseller")
            {
                if (görsellerToolStripMenuItem.Enabled)
                    görsellerToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndKentonUyeler")
            {
                if (üyelerToolStripMenuItem1.Enabled)
                    üyelerToolStripMenuItem1.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndKentonTarifler")
            {
                if (tariflerToolStripMenuItem.Enabled)
                    tariflerToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndKentonYorumlar")
            {
                if (yorumlarToolStripMenuItem.Enabled)
                    yorumlarToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndKutuphane")
            {
                if (kütüphaneToolStripMenuItem.Enabled)
                    kütüphaneToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndAnketler")
            {
                if (anketlerToolStripMenuItem.Enabled)
                    anketlerToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndSirketler")
            {
                if (şirketlerToolStripMenuItem.Enabled)
                    şirketlerToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndTatiller")
            {
                if (tatilGünleriToolStripMenuItem.Enabled)
                    tatilGünleriToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndMalzemeHaric")
            {
                if (çokluMalzemeXMLToolStripMenuItem.Enabled)
                    çokluMalzemeXMLToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion
        //
        //
        public void lll_MouseUp(object sender, MouseEventArgs e)
        {
            /*if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == ((ToolStripButton)sender).Name)
                    {
                        f.Dispose();
                        statusStrip1.Items.Remove(((ToolStripButton)sender));
                    }
                }
            }
            else */
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == ((ToolStripButton)sender).Name)
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
        }
        //
        //
        private void cbSolMenu_CheckedChanged(object sender, EventArgs e)
        {
            /*RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Sultanlar", true);
            if (cbSolMenu.Checked)
                key.SetValue("SolMenu", "evet");
            else
                key.SetValue("SolMenu", "hayir");

            treeView1.Visible = cbSolMenu.Checked;*/
        }
        //
        //
        private void btnSeceneklerKapat_Click(object sender, EventArgs e)
        {
            pnlSecenekler.Visible = false;
        }
        //
        //
        private void pnlSecenekler_SizeChanged(object sender, EventArgs e)
        {
            btnSeceneklerKapat.Location = new Point(pnlSecenekler.Size.Width - btnSeceneklerKapat.Size.Width - 12, 
                pnlSecenekler.Size.Height - btnSeceneklerKapat.Size.Height - 12);
            lblSeceneklerKapat.Location = new Point(pnlSecenekler.Size.Width - lblSeceneklerKapat.Size.Width - 11,
                lblSeceneklerKapat.Location.Y);
        }
        //
        //
        private void lblSeceneklerKapat_MouseHover(object sender, EventArgs e)
        {
            lblSeceneklerKapat.ForeColor = Color.Red;
        }
        //
        //
        private void lblSeceneklerKapat_MouseLeave(object sender, EventArgs e)
        {
            lblSeceneklerKapat.ForeColor = Color.Black;
        }
        //
        //
        private void lblSeceneklerKapat_Click(object sender, EventArgs e)
        {
            pnlSecenekler.Visible = false;
        }
        //
        //
        //private void cbIadeSagTusMenu_CheckedChanged(object sender, EventArgs e)
        //{
        //    RegistryKey key = Registry.LocalMachine.OpenSubKey(@"Software\Sultanlar", true);
        //    if (cbIadeSagTusMenu.Checked)
        //        key.SetValue("IadeSagTusMenu", "evet");
        //    else
        //        key.SetValue("IadeSagTusMenu", "hayir");
        //}
        //
        //
        private void seçeneklerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            pnlSecenekler.Visible = true;
        }
        //
        //
        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //
        //
        private void frmAna_Activated(object sender, EventArgs e)
        {
            foreach (Form form in this.MdiChildren)
            {
                if (form.Name == "frmINTERNETmalzemekategorimarka" || form.Name == "frmPrimler")
                {
                    form.Refresh();
                }
            }
        }
        //
        //
        private void txtSifre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnGiris.PerformClick();
            }
        }
        //
        //
        private void btnGiris_Click(object sender, EventArgs e)
        {
            if (Kullanicilar.Login(txtKAdi.Text.Trim(), txtSifre.Text))
            {
                ListBox lbFormlar = new ListBox();
                ListBox lbYetkiler = new ListBox();
                KAdi = txtKAdi.Text.Trim().ToUpper();
                lblKAdi.Text = KAdi.ToUpper();
                IList listFormlar = lbFormlar.Items;
                IList listYetkiler = lbYetkiler.Items;
                Formlar.GetObject(listFormlar, true);
                Yetkiler.GetObject(listYetkiler, true);

                for (int i = 0; i < listFormlar.Count; i++)
                    for (int j = 0; j < listYetkiler.Count; j++)
                        if (((Formlar)listFormlar[i]).pkFormID == ((Yetkiler)listYetkiler[j]).sintFormID && KAdi == ((Yetkiler)listYetkiler[j]).strKAdi)
                            FormuAktifEt(((Formlar)listFormlar[i]).strFormAdi);

                pnlLogin.Visible = false;

                fe = new FormErisimleri(KAdi.ToUpper(), DateTime.Now, DateTime.MinValue);
                fe.DoInsert();
            }
        }
        //
        //
        private void frmAna_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (fe != null)
            {
                fe.dtCikisTarihi = DateTime.Now;
                fe.DoUpdate();
            }
        }
    }
}

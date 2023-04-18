using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using Sultanlar.Class;
using Sultanlar.DatabaseObject;
using System.Timers;
using System.IO;
using System.Data.SqlClient;
using System.Net;
using Sultanlar.DatabaseObject.Internet;
using Sultanlar.DatabaseObject.Kenton;
using System.Xml;
using System.Collections;

namespace Sultanlar.WindowsServiceIslemler
{
    partial class srvServis : ServiceBase
    {
        public srvServis()
        {
            InitializeComponent();
        }

        Timer tmr;
        bool eczaneleregirdi;
        bool androidveritabanigirdi;
        bool iademailgirdi;
        bool tpfiyatlaragirdi;

        Timer tmrSAPcustomers;
        Timer tmrSAPprices;
        Timer tmrSAP;
        Timer tmrSAPekstre;
        Timer tmrSAPekstre2;

        protected override void OnStart(string[] args)
        {
            System.Diagnostics.EventLog.WriteEntry("Sultanlar-Windows Servis", "başladı");

            eczaneleregirdi = false;
            androidveritabanigirdi = false;
            iademailgirdi = false;
            tpfiyatlaragirdi = false;

            tmr = new Timer(2400000);
            tmr.Elapsed += new System.Timers.ElapsedEventHandler(tmr_Elapsed);
            tmr.Enabled = true;
            tmr.Start();

            tmrSAPcustomers = new Timer(300000);
            tmrSAPcustomers.Elapsed += new ElapsedEventHandler(tmrSAPcustomers_Elapsed);
            tmrSAPcustomers.Enabled = true;
            tmrSAPcustomers.Start();

            tmrSAPprices = new Timer(300000);
            tmrSAPprices.Elapsed += new ElapsedEventHandler(tmrSAPprices_Elapsed);
            tmrSAPprices.Enabled = true;
            tmrSAPprices.Start();

            tmrSAP = new Timer(300000); //3600000
            tmrSAP.Elapsed += new ElapsedEventHandler(tmrSAP_Elapsed);
            tmrSAP.Enabled = true;
            tmrSAP.Start();

            tmrSAPekstre = new Timer(300000);
            tmrSAPekstre.Elapsed += new ElapsedEventHandler(tmrSAPekstre_Elapsed);
            tmrSAPekstre.Enabled = true;
            tmrSAPekstre.Start();

            tmrSAPekstre2 = new Timer(300000);
            tmrSAPekstre2.Elapsed += new ElapsedEventHandler(tmrSAPekstre2_Elapsed);
            tmrSAPekstre2.Enabled = true;
            tmrSAPekstre2.Start();

            //ilk başta çalıştır
            //GetSAP();
        }

        protected override void OnStop()
        {
            tmr.Stop();
            tmrSAPprices.Stop();
            tmrSAPcustomers.Stop();
            tmrSAP.Stop();
            tmrSAPekstre.Stop();
            tmrSAPekstre2.Stop();

            tmr.Enabled = false;
            tmrSAPprices.Enabled = false;
            tmrSAPcustomers.Enabled = false;
        }

        #region tmrelapsed
        void tmrSAPprices_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (
                (DateTime.Now.Hour == 5 || DateTime.Now.Hour == 6 || DateTime.Now.Hour == 7 || DateTime.Now.Hour == 8 || DateTime.Now.Hour == 9 || DateTime.Now.Hour == 10 ||
                DateTime.Now.Hour == 11 || DateTime.Now.Hour == 12 || DateTime.Now.Hour == 13 || DateTime.Now.Hour == 14 ||
                DateTime.Now.Hour == 15 || DateTime.Now.Hour == 16 || DateTime.Now.Hour == 17)
                )
            {
                if ((DateTime.Now.Minute > 10 && DateTime.Now.Minute <= 15))
                {
                    Sap.KampanyalarC();
                    Sap.MalzemelerC(true, false);
                    Sap.FiyatlarC();
                }
            }
        }

        void tmrSAPcustomers_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (
                (DateTime.Now.Hour == 7 || DateTime.Now.Hour == 8 || DateTime.Now.Hour == 9 || DateTime.Now.Hour == 10 ||
                DateTime.Now.Hour == 11 || DateTime.Now.Hour == 12 || DateTime.Now.Hour == 13 || DateTime.Now.Hour == 14 ||
                DateTime.Now.Hour == 15 || DateTime.Now.Hour == 16 || DateTime.Now.Hour == 17)
                )
            {
                if ((DateTime.Now.Minute > 35 && DateTime.Now.Minute <= 40))
                {
                    Sap.PersonellerC();
                    Sap.MusterilerC();
                }
            }
        }

        void tmrSAP_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (
                (DateTime.Now.Hour == 7 || DateTime.Now.Hour == 8 || DateTime.Now.Hour == 9 || DateTime.Now.Hour == 10 ||
                DateTime.Now.Hour == 11 || DateTime.Now.Hour == 12 || DateTime.Now.Hour == 13 || DateTime.Now.Hour == 14 ||
                DateTime.Now.Hour == 15 || DateTime.Now.Hour == 16 || DateTime.Now.Hour == 17 || DateTime.Now.Hour == 18/* ||
                    DateTime.Now.Hour == 19 || DateTime.Now.Hour == 20 || DateTime.Now.Hour == 21 || DateTime.Now.Hour == 22 ||
                    DateTime.Now.Hour == 23*/)
                )
            {
                if ((DateTime.Now.Minute > 50 && DateTime.Now.Minute <= 55))
                {
                    Sap.GetSAP(true, true, true, true, true, true, true, true);
                }
                //EntegraSiparis();
            }
            //else if (DateTime.Now.Hour == 23 && DateTime.Now.Minute >= 30 && DateTime.Now.Minute < 40) // 10 dakikada bir çalıştığı için günde iki kez düşecek buraya
            //{
            //    GetSAPgece();
            //}
            else if (DateTime.Now.Hour == 6 /*&& DateTime.Now.Minute >= 30 && DateTime.Now.Minute < 40*/) // 10 dakikada bir çalıştığı için günde iki kez düşecek buraya
            {
                if ((DateTime.Now.Minute > 50 && DateTime.Now.Minute <= 55))
                {
                    Sap.GetSAPgece(true);
                }
            }
            //else if (DateTime.Now.Hour == 6 && DateTime.Now.Minute >= 10 && DateTime.Now.Minute < 20) // 10 dakikada bir çalıştığı için günde iki kez düşecek buraya
            //{
            //    GetSAPgece(false);
            //}
            //else if (DateTime.Now.Hour == 6 /*&& DateTime.Now.Minute >= 30 && DateTime.Now.Minute < 40*/) // 10 dakikada bir çalıştığı için günde iki kez düşecek buraya
            //{
            //    GetSAPgece(true);
            //}
        }

        void tmrSAPekstre_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (DateTime.Now.DayOfWeek != DayOfWeek.Sunday)
            {
                if (DateTime.Now.Hour == 22)
                {
                    if (DateTime.Now.Minute > 40 && DateTime.Now.Minute <= 45)
                    {
                        Sap.GetEkstre(Convert.ToDateTime("01.01.2014")); // Convert.ToDateTime("01.01.2014")
                        Sap.GetEkstre2();
                        //GetSatisJob();
                    }
                }
                else if (DateTime.Now.Hour == 3)
                {
                    if (DateTime.Now.Minute > 5 && DateTime.Now.Minute <= 10)
                    {
                        Sap.Satis();
                        Sap.SatisIade();
                    }
                }
                else if (DateTime.Now.Hour == 12 || DateTime.Now.Hour == 20)
                {
                    if (DateTime.Now.Minute > 50 && DateTime.Now.Minute <= 55)
                    {
                        //ServicePointManager.Expect100Continue = true;
                        //ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;

                        ////RssKenton("https://www.kenton.com.tr/kategori/tarifler/feed/");
                        //RssKenton("https://www.kenton.com.tr/kategori/tatli-tarifleri/feed/");
                        //RssVideo("https://www.kenton.com.tr/kategori/kenton-video/feed/");
                        ////RssVideo("https://www.kenton.com.tr/kategori/tatli-sefi-video/feed/");

                        BayiServis(DateTime.Now.Year.ToString(), DateTime.Now.Month.ToString(), true, new ArrayList());
                        BayiServis(DateTime.Now.Year.ToString(), DateTime.Now.Month.ToString(), false, new ArrayList());
                    }
                }
            }
            else
            {
                if (DateTime.Now.Hour == 22)
                {
                    if (DateTime.Now.Minute > 40 && DateTime.Now.Minute <= 45)
                    {
                        Sap.GetEkstre(Convert.ToDateTime("01.01.2014")); // Convert.ToDateTime("01.01.2014")
                        Sap.GetEkstre2();
                        //GetSatisJob();
                    }
                }
            }
        }

        void tmrSAPekstre2_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (DateTime.Now.DayOfWeek != DayOfWeek.Sunday)
            {
                if (DateTime.Now.Hour == 9 || DateTime.Now.Hour == 12 || DateTime.Now.Hour == 15 || DateTime.Now.Hour == 18)
                {
                    if (DateTime.Now.Minute > 33 && DateTime.Now.Minute <= 38)
                    {
                        Sap.GetEkstre(Convert.ToDateTime("01.01.2014")); //Convert.ToDateTime("01.01.2014")
                        Sap.GetEkstre2();
                    }
                }
            }
        }

        void tmr_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            IslemYap();
        }
        #endregion

        #region IslemYap
        void IslemYap()
        {
            //WebGenel.DoUpdateHavaDurumu(StringParcalama.HavaDurumu());

            //string DOVIZ = string.Empty;

            //try
            //{
            //    string[,] doviz = Doviz.DovizGetir();
            //    string[,] doviz2 = Doviz.DovizGetirAlternatif();
            //    DOVIZ = "SPDK - US: " + doviz2[0, 1] + " - " + doviz2[0, 2] + " | EU: " + doviz2[1, 1] + " - " + doviz2[1, 2] + "<br />"
            //        + "MBDK - US: " + doviz[0, 1] + " - " + doviz[0, 2] + " | EU: " + doviz[1, 1] + " - " + doviz[1, 2] + "<br />";
            //}
            //catch (Exception ex)
            //{
            //    System.Diagnostics.EventLog.WriteEntry("Sultanlar-Web Sitesi Güncelleme", ex.Message);
            //}

            //WebGenel.DoUpdateDoviz(DOVIZ);

            Sultanlar.Class.DisSiparisler ds = new Sultanlar.Class.DisSiparisler();
            //try { ds.n11Siparisler(); } catch (Exception) { }
            //try { ds.hbSiparisler(); } catch (Exception) { }

            if (DateTime.Now.Day == 1 && !eczaneleregirdi)
            {
                if (DateTime.Now.Hour == 1)
                {
                    //Eczaneler.DoDeleteAll();
                    //int kacgun = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
                    //StringEczane.EczanelerEkle2(kacgun, new System.Windows.Forms.Label());

                    eczaneleregirdi = true;
                }
            }

            if (DateTime.Now.Hour == 5 && !androidveritabanigirdi)
            {
                //Sqlite();

                androidveritabanigirdi = true;
            }

            if ((DateTime.Now.Hour == 7 || DateTime.Now.Hour == 8) && !iademailgirdi)
            {
                //string stiadesahipleri = Sultanlar.DatabaseObject.Internet.Iadeler.STIadeleriSahiplerineMesaj();

                //Eposta.EpostaYolla("sultanlar@sultanlar.com.tr", "", 
                //    new string[] { 
                //        "mtorun@sultanlar.com.tr", "eozel@sultanlar.com.tr", "gcelik@sultanlar.com.tr", "afettah@sultanlar.com.tr", 
                //        "iade@sultanlar.com.tr", "uyildirim@sultanlar.com.tr", "mistif@sultanlar.com.tr"
                //    }, 
                //    new string[] {
                //        "my@sultanlar.com.tr", "farukyildiz@sultanlar.com.tr", "rbagdatli@sultanlar.com.tr", "fmehmetoglu@sultanlar.com.tr", 
                //        "hozpoyraz@sultanlar.com.tr"
                //    },
                //    "Sultanlar Pazarlama A.Ş.", "2014 yılı itibariyle iade uygulaması günlük bölüm satır sayıları",
                //    Sultanlar.DatabaseObject.Internet.Iadeler.GetIadelerTabsRowCount().Replace("\r\n", "<br>")
                //    .Replace("Fiyatlandırılmamış:", "<b>Emre Özel / Hediye Çetli / Fiyatlandırılmamış:</b>")
                //    .Replace("Fiyatlandırılmış:", "<b>Fikret Yıldırıcı / Ünal Yıldırım / Fiyatlandırılmış:</b>")
                //    //.Replace("Sevk Bekleyen Tümü:", "<b>Ahmet Fettah / Arzu Bayram / Sevk Bekleyen Tümü:</b>")
                //    .Replace("Sevk Bekleyen Araca Verilecek:", "<b>Ahmet Fettah / Ertuğrul Duysak - Olgun Kaya / Sevk Bekleyen Araca Verilecek:</b>")
                //    .Replace("Sevk Bekleyen Araçta:", "<b>Ahmet Fettah / Ertuğrul Duysak - Olgun Kaya / Sevk Bekleyen Araçta:</b>")
                //    .Replace("Sevkten Gelen:", "<b>Ahmet Fettah / Erkan Karakurt - Şeyda Aslan / Sevkten Gelen:</b>")
                //    .Replace("İade Girilen:", "<b>Ahmet Fettah / Erkan Karakurt - Şeyda Aslan / İade Girilen:</b>")
                //    .Replace("İade Kabul:", "<b>Ahmet Fettah / Erkan Karakurt - Şeyda Aslan / İade Kabul:</b>")
                //    .Replace("Sat.Op.:", "<b>Fikret Yıldırıcı / Ünal Yıldırım / Sat.Op.:</b>")
                //    .Replace("S.T.:", "<b>Fikret Yıldırıcı / Ünal Yıldırım / S.T.:</b>")
                //    .Replace("C/H:", "<b>Emre Özel / Hediye Çetli / C/H:</b>")
                //    .Replace("Son:", "<b>İşlemi Biten:</b>")
                //    .Replace("Reddedilen:", "<b>Reddedilen:</b>")
                //    .Replace("Değişim:", "<b>Değişim:</b>")
                //    .Replace("Önemsiz:", "<b>Önemsiz:</b>")
                //    + "<br>" + "<i> Gönderim tarihi: " + DateTime.Now.ToString() + "</i>"
                //    + "<br><br><br><br><i><b>S.T. Bölümündeki Satıcıların Dosyalarındaki İade Sayısı:</b></i><br><br>"
                //    + (stiadesahipleri == string.Empty ? "- Görüntülenecek bilgi yoktur. -" : stiadesahipleri));

                iademailgirdi = true;
            }

            if ((DateTime.Now.Hour == 8) && !tpfiyatlaragirdi)
            {
                tpfiyatlaragirdi = true;

                DataTable dt = new DataTable();
                FiyatTipleri.GetObjects(dt);

                for (int i = 0; i < dt.Rows.Count; i++)
                    if ((dt.Rows[i]["NOSU"].ToString().StartsWith("5") || dt.Rows[i]["NOSU"].ToString().StartsWith("6")) && dt.Rows[i]["NOSU"].ToString().Length == 3)
                        FiyatlarTP.Update(Convert.ToInt16(dt.Rows[i]["NOSU"].ToString()), DateTime.Now.Year, DateTime.Now.Month);

                FiyatlarTP.Update((short)1, DateTime.Now.Year, DateTime.Now.Month);
                FiyatlarTP.Update((short)7, DateTime.Now.Year, DateTime.Now.Month);
                FiyatlarTP.Update((short)20, DateTime.Now.Year, DateTime.Now.Month);
                FiyatlarTP.Update((short)22, DateTime.Now.Year, DateTime.Now.Month);
                FiyatlarTP.Update((short)25, DateTime.Now.Year, DateTime.Now.Month);
                //FiyatlarTP.Update((short)33, DateTime.Now.Year, DateTime.Now.Month);
            }

            if (DateTime.Now.Hour == 23)
            {
                eczaneleregirdi = false;
                androidveritabanigirdi = false;
                iademailgirdi = false;
                tpfiyatlaragirdi = false;
            }
        }
        #endregion

        #region tarifsepeti
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
                            trf.binResim = Resim.ImageToByte(Resim.ResimKucult(Resim.ByteToImage(new WebClient().DownloadData(img)), 400));

                            int img2Bas1 = reader.Value.IndexOf("<img ", imgBit);
                            if (img2Bas1 > -1)
                            {
                                int img2Bas = reader.Value.IndexOf("src=\"", img2Bas1) + 5;
                                int img2Bit = reader.Value.IndexOf("\"", img2Bas);
                                img2 = reader.Value.Substring(img2Bas, img2Bit - img2Bas).Trim();
                                trf.binResimUrunler = Resim.ImageToByte(Resim.ResimKucult(Resim.ByteToImage(new WebClient().DownloadData(img2)), 400));
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
                tarifler[i].DoInsert();
        }

        private void RssVideo(string url)
        {
            List<Videolar> videolar = new List<Videolar>();
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
                            if (trf.dtTarih <= Videolar.GetLastObjectTime())
                            {
                                //return;
                            }
                            else
                            {
                                trf.intTarifID = 0;
                                trf.intUyeID = 1;
                                //trf.DoInsert();
                                videolar.Add(trf);
                            }
                            trf = new Videolar();
                        }
                        break;
                }
            }

            for (int i = 0; i < videolar.Count; i++)
                videolar[i].DoInsert();
        }
        #endregion

        #region sqlite
        /*
        SQLiteConnection conn;

        private void Sqlite()
        {
            try
            {
                if (System.IO.File.Exists(@"c:\Program Files\Sultanlar\Web Sistesi Guncelleme\temp\sultanlarsqlitedb.rar"))
                    System.IO.File.Delete(@"c:\Program Files\Sultanlar\Web Sistesi Guncelleme\temp\sultanlarsqlitedb.rar");
                conn = new SQLiteConnection(@"Data Source=c:\Program Files\Sultanlar\Web Sistesi Guncelleme\temp\sultanlarsqlitedb.rar;Version=3;New=True;");
                SQLiteCommand cmd = new SQLiteCommand(
                    "CREATE TABLE OZELLIKLER (EPOSTA TEXT,SIFRE TEXT,SLSREF INTEGER,SONGUNCELLEME TEXT); " +
                    "CREATE TABLE MUSTERILER (SMREF INTEGER,MUSTERI TEXT,RISKLIMIT REAL); " +
                    "CREATE TABLE FIYATLAR (ITEMREF INTEGER,FTIP INTEGER,FIYAT REAL); " +
                    "CREATE TABLE FIYATTIPLERI (FTIP INTEGER); " +
                    "CREATE TABLE URUNLER (ITEMREF INTEGER,MALZEME TEXT,BARKOD TEXT,STOK INTEGER); " +

                    "CREATE TABLE SIPARISLER (ID INTEGER PRIMARY KEY AUTOINCREMENT,SLSREF INTEGER,SMREF INTEGER,FTIP INTEGER,TUTAR REAL); " +
                    "CREATE TABLE SIPARISDETAY (ID INTEGER PRIMARY KEY AUTOINCREMENT,SIPARISID INTEGER,ITEMREF INTEGER,ADET INTEGER,FIYAT REAL); " +
                    "CREATE TABLE IADELER (ID INTEGER PRIMARY KEY AUTOINCREMENT,SLSREF INTEGER,SMREF INTEGER); " +
                    "CREATE TABLE IADEDETAY (ID INTEGER PRIMARY KEY AUTOINCREMENT,IADEID INTEGER,ITEMREF INTEGER,ADET INTEGER);", conn);

                conn.Open();
                cmd.ExecuteNonQuery();

                // MUSTERILER
                //MUSTERILER(conn);

                // FIYATTIPLERI
                //FIYATTIPLERI(conn);

                // URUNLER
                URUNLER(conn);

                // FIYATLAR
                FIYATLAR(conn);

                cmd.Dispose();
                conn.Close();
                conn.Dispose();
                GC.SuppressFinalize(conn);
                GC.Collect();
                File.Copy(@"c:\Program Files\Sultanlar\Web Sistesi Guncelleme\temp\sultanlarsqlitedb.rar", @"\\serverts02\c$\inetpub\wwwroot\sultanlar2011\tempdown\sultanlarsqlitedb.rar", true);
                System.IO.File.Delete(@"c:\Program Files\Sultanlar\Web Sistesi Guncelleme\temp\sultanlarsqlitedb.rar");
            }
            catch (Exception ex)
            {
                if (conn != null)
                    conn.Close();
                System.Diagnostics.EventLog.WriteEntry("Sultanlar-Web Sitesi Güncelleme-Sqlite", ex.Message);
            }
        }

        private void MUSTERILER(SQLiteConnection conn)
        {
            DataTable dt = new DataTable();
            string commandtext = string.Empty;
            SQLiteCommand cmd = null;

            Sultanlar.DatabaseObject.Internet.CariHesaplar.GetObjectsWS(dt, true);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                commandtext = "INSERT INTO MUSTERILER (SMREF,MUSTERI,RISKLIMIT) VALUES (" +
                    "" + dt.Rows[i][1].ToString() + "," +
                    "'" + dt.Rows[i][2].ToString().Replace("'", "") + "'," +
                    "" + dt.Rows[i][3].ToString().Replace(",", ".") + "); ";
                cmd = new SQLiteCommand(commandtext, conn);
                cmd.ExecuteNonQuery();
            }
            cmd.Dispose();
        }

        private void FIYATTIPLERI(SQLiteConnection conn)
        {
            DataTable dt = new DataTable();
            string commandtext = string.Empty;
            SQLiteCommand cmd = null;

            Sultanlar.DatabaseObject.Internet.FiyatTipleri.GetObjectWS(dt);
            commandtext = string.Empty;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                commandtext = "INSERT INTO FIYATTIPLERI (FTIP) VALUES (" +
                    "" + dt.Rows[i][0].ToString() + "); ";
                cmd = new SQLiteCommand(commandtext, conn);
                cmd.ExecuteNonQuery();
            }
            cmd.Dispose();
        }

        private void URUNLER(SQLiteConnection conn)
        {
            DataTable dt = new DataTable();
            string commandtext = string.Empty;
            SQLiteCommand cmd = null;

            dt = new DataTable();
            Sultanlar.DatabaseObject.Internet.Urunler.GetProductsWS(dt);
            commandtext = string.Empty;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                commandtext = "INSERT INTO URUNLER (ITEMREF,MALZEME,BARKOD,STOK) VALUES (" +
                    "" + dt.Rows[i][0].ToString() + "," +
                    "'" + dt.Rows[i][1].ToString().Replace("'", "") + "'," +
                    "'" + dt.Rows[i][2].ToString() + "'," +
                    "" + dt.Rows[i][3].ToString() + "); ";
                cmd = new SQLiteCommand(commandtext, conn);
                cmd.ExecuteNonQuery();
            }
            cmd.Dispose();
        }

        private void FIYATLAR(SQLiteConnection conn)
        {
            DataTable dt = new DataTable();
            string commandtext = string.Empty;
            SQLiteCommand cmd = null;

            dt = new DataTable();
            Sultanlar.DatabaseObject.Internet.Urunler.GetPricesWS(dt);
            commandtext = string.Empty;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                commandtext = "INSERT INTO FIYATLAR (ITEMREF,FTIP,FIYAT) VALUES (" +
                    "" + dt.Rows[i][0].ToString() + "," +
                    "" + dt.Rows[i][1].ToString() + "," +
                    "" + dt.Rows[i][2].ToString().Replace(",", ".") + "); ";
                cmd = new SQLiteCommand(commandtext, conn);
                cmd.ExecuteNonQuery();
            }
            cmd.Dispose();
        }


        */
        #endregion

        #region bayi web services
        /// <summary>
        /// bayiler boş ise hepsi
        /// </summary>
        /// <param name="YIL"></param>
        /// <param name="AY"></param>
        /// <param name="satis"></param>
        /// <param name="bayiler"></param>
        private void BayiServis(string YIL, string AY, bool satis, ArrayList bayiler)
        {
            //DisVeri.BayiServis(YIL, AY, satis, bayiler);
            DisVeri.BayiServisXML(YIL, AY, satis, bayiler);
            //DisVeri.VeriAktar(satis, YIL, AY, bayiler);
        }
        #endregion

        private void EntegraSiparis()
        {
            if (Entegra.EntegraSiparis2())
                EventLog.WriteEntry("Sultanlar Windows Service", "Entegra güncellemesi yapıldı.", EventLogEntryType.Information);
        }
    }
}

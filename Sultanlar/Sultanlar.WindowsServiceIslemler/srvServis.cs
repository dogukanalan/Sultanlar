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
        bool musteriguncelleniyor;
        bool tpfiyatlaragirdi;
        int tekrarcekilecek = 5;

        Timer tmrSAPcustomers;
        Timer tmrSAPprices;
        Timer tmrSAP;
        Timer tmrSAPekstre;
        Timer tmrSAPekstre2;

        NetworkCredential nc1;

        protected override void OnStart(string[] args)
        {
            System.Diagnostics.EventLog.WriteEntry("Sultanlar-Windows Servis", "başladı");
            nc1 = new NetworkCredential("MISTIF", "Ankara1923*+B");

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

            tmrSAP = new Timer(3600000);
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
                (DateTime.Now.Hour == 7 || DateTime.Now.Hour == 8 || DateTime.Now.Hour == 9 || DateTime.Now.Hour == 10 ||
                DateTime.Now.Hour == 11 || DateTime.Now.Hour == 12 || DateTime.Now.Hour == 13 || DateTime.Now.Hour == 14 ||
                DateTime.Now.Hour == 15 || DateTime.Now.Hour == 16 || DateTime.Now.Hour == 17)
                )
            {
                if ((DateTime.Now.Minute > 10 && DateTime.Now.Minute <= 15))
                {
                    KampanyalarC();
                    MalzemelerC(true, false);
                    FiyatlarC();
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
                    PersonellerC();
                    MusterilerC();
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
                GetSAP();
                //EntegraSiparis();
            }
            //else if (DateTime.Now.Hour == 23 && DateTime.Now.Minute >= 30 && DateTime.Now.Minute < 40) // 10 dakikada bir çalıştığı için günde iki kez düşecek buraya
            //{
            //    GetSAPgece();
            //}
            else if (DateTime.Now.Hour == 6 /*&& DateTime.Now.Minute >= 30 && DateTime.Now.Minute < 40*/) // 10 dakikada bir çalıştığı için günde iki kez düşecek buraya
            {
                GetSAPgece(true);
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
                        GetEkstre(Convert.ToDateTime("01.01.2014")); // Convert.ToDateTime("01.01.2014") 
                        //GetSatisJob();
                    }
                }
                else if (DateTime.Now.Hour == 3)
                {
                    if (DateTime.Now.Minute > 5 && DateTime.Now.Minute <= 10)
                    {
                        Satis();
                        SatisIade();
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
                        GetEkstre(Convert.ToDateTime("01.01.2014")); // Convert.ToDateTime("01.01.2014")
                        //GetSatisJob();
                    }
                }
            }
        }

        void tmrSAPekstre2_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (DateTime.Now.DayOfWeek != DayOfWeek.Sunday)
            {
                if (/*DateTime.Now.Hour == 9 || */DateTime.Now.Hour == 15 || DateTime.Now.Hour == 18)
                {
                    if (DateTime.Now.Minute > 33 && DateTime.Now.Minute <= 38)
                    {
                        GetEkstre(Convert.ToDateTime("01.01.2014")); //Convert.ToDateTime("01.01.2014")
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
            try { ds.n11Siparisler(); } catch (Exception) { }
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

        #region sap canlı anaveriler

        #region KampanyalarC
        private void KampanyalarC()
        {
            SqlConnection conn = new SqlConnection(General.ConnectionString);

            SqlCommand cmdLog = new SqlCommand("INSERT INTO [KurumsalWebSAP].[dbo].[tblINTERNET_LogTabloGuncellemeler] ([dtBaslangic],[dtBitis],[strYer],[strLog]) VALUES (@dtBaslangic,@dtBitis,@strYer,@strLog)", conn);
            cmdLog.Parameters.AddWithValue("@dtBaslangic", DateTime.Now); cmdLog.Parameters.AddWithValue("@strYer", "SAP Kampanyalar");




            getcampaignsC.ZwebGetCampaignsService clCampaigns = new getcampaignsC.ZwebGetCampaignsService();
            clCampaigns.Timeout = 6000000;
            clCampaigns.Credentials = nc1;
            getcampaignsC.Zwebt902[] listAna = null;
            getcampaignsC.Zwebt903[] listHed = null;
            getcampaignsC.Zwebt901[] listKart = null;

            int tekrarcek = 0;
            while (tekrarcek < tekrarcekilecek)
            {
                try
                {
                    listKart = clCampaigns.ZwebGetCampaigns(out listAna, out listHed);
                    tekrarcek = tekrarcekilecek;
                }
                catch (Exception ex)
                {
                    if (tekrarcek < tekrarcekilecek)
                    {
                        tekrarcek++;
                        System.Threading.Thread.Sleep(3000);
                    }
                    else
                    {
                        cmdLog.Parameters.AddWithValue("@strLog", ex.Message);
                        conn.Open(); cmdLog.Parameters.AddWithValue("@dtBitis", DateTime.Now); cmdLog.ExecuteNonQuery(); conn.Close();
                        return;
                    }
                }
            }

            cmdLog.Parameters.AddWithValue("@strLog", listKart.Length.ToString() + " Satır");

            SqlCommand cmd1 = new SqlCommand("DELETE FROM [Web-Kampanya-1] DELETE FROM [Web-Kampanya-2] DELETE FROM [Web-Kampanya-3]", conn);
            cmd1.CommandTimeout = 1000;
            conn.Open();
            cmd1.ExecuteNonQuery();
            conn.Close();

            for (int i = 0; i < listKart.Length; i++)
            {
                Guid kamkartref = new Guid(listKart[i].GuidRef);
                string kampno = listKart[i].Knumh;
                int ftip = 0; try { ftip = Convert.ToInt32(listKart[i].Pltyp); }
                catch { }
                string aciklama = listKart[i].Knumh;
                DateTime baslangic = Convert.ToDateTime(listKart[i].Datab);
                DateTime bitis = Convert.ToDateTime(listKart[i].Datbi);
                int kytk = 0; try { kytk = Convert.ToInt32((DateTime.Now - Convert.ToDateTime(listKart[i].Datab)).TotalDays); }
                catch { }

                SqlCommand cmd = new SqlCommand("INSERT INTO [Web-Kampanya-1] " +
                    "([KAMKARTREF],[KAMPNO],[FIYAT_TIPI],ACIKLAMA,BASLANGIC_TARIHI,BITIS_TARIHI,KYTK)" +
                    "VALUES (@KAMKARTREF,@KAMPNO,@FIYAT_TIPI,@ACIKLAMA,@BASLANGIC_TARIHI,@BITIS_TARIHI,@KYTK)", conn);
                cmd.CommandTimeout = 1000;
                cmd.Parameters.AddWithValue("@KAMKARTREF", kamkartref);
                cmd.Parameters.AddWithValue("@KAMPNO", kampno);
                cmd.Parameters.AddWithValue("@FIYAT_TIPI", ftip);
                cmd.Parameters.AddWithValue("@ACIKLAMA", aciklama);
                cmd.Parameters.AddWithValue("@BASLANGIC_TARIHI", baslangic);
                cmd.Parameters.AddWithValue("@BITIS_TARIHI", bitis);
                cmd.Parameters.AddWithValue("@KYTK", kytk);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Hatalar.DoInsert(ex, "windows servis SAP kampanyalar");
                }
                finally
                {
                    conn.Close();
                }
            }

            for (int i = 0; i < listAna.Length; i++)
            {
                Guid kamkartref = new Guid(listAna[i].GuidRef);
                Guid kampanasatref = new Guid(listAna[i].Guid);
                int itemref = 0; try { itemref = Convert.ToInt32(listAna[i].Matnr.Substring(11)); }
                catch { }
                double miktar = 0; try { miktar = Convert.ToDouble(listAna[i].Menge); }
                catch { }

                SqlCommand cmd = new SqlCommand("INSERT INTO [Web-Kampanya-2] " +
                    "([KAMKARTREF],[KAMPANASATREF],[ITEMREF],MIKTAR)" +
                    "VALUES (@KAMKARTREF,@KAMPANASATREF,@ITEMREF,@MIKTAR)", conn);
                cmd.CommandTimeout = 1000;
                cmd.Parameters.AddWithValue("@KAMKARTREF", kamkartref);
                cmd.Parameters.AddWithValue("@KAMPANASATREF", kampanasatref);
                cmd.Parameters.AddWithValue("@ITEMREF", itemref);
                cmd.Parameters.AddWithValue("@MIKTAR", miktar);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Hatalar.DoInsert(ex, "windows servis SAP kampanyalar ana");
                }
                finally
                {
                    conn.Close();
                }
            }

            for (int i = 0; i < listHed.Length; i++)
            {
                Guid kamkartref = new Guid(listHed[i].GuidRef);
                Guid kamphedsatref = new Guid(listHed[i].Guid);
                int itemref = 0; try { itemref = Convert.ToInt32(listHed[i].Matnr.Substring(11)); }
                catch { }
                double miktar = 0; try { miktar = Convert.ToDouble(listHed[i].Menge); }
                catch { }

                SqlCommand cmd = new SqlCommand("INSERT INTO [Web-Kampanya-3] " +
                    "([KAMKARTREF],[KAMPHEDSATREF],[ITEMREF],MIKTAR)" +
                    "VALUES (@KAMKARTREF,@KAMPHEDSATREF,@ITEMREF,@MIKTAR)", conn);
                cmd.CommandTimeout = 1000;
                cmd.Parameters.AddWithValue("@KAMKARTREF", kamkartref);
                cmd.Parameters.AddWithValue("@KAMPHEDSATREF", kamphedsatref);
                cmd.Parameters.AddWithValue("@ITEMREF", itemref);
                cmd.Parameters.AddWithValue("@MIKTAR", miktar);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Hatalar.DoInsert(ex, "windows servis SAP kampanyalar hed");
                }
                finally
                {
                    conn.Close();
                }
            }

            SqlCommand cmd2 = new SqlCommand("", conn);
            cmd2.CommandText = "UPDATE [Web-Kampanya-2] SET [KAMPNO] = [Web-Kampanya-1].KAMPNO,[TIP] = [Web-Kampanya-1].FIYAT_TIPI,[GRUP KOD] = [Web-Malzeme].[GRUP KOD],[OZEL KOD] = [Web-Malzeme].[OZEL KOD],[HK] = [Web-Malzeme].HK,[OZEL ACIK] = [Web-Malzeme].[OZEL ACIK],[REY KOD] = [Web-Malzeme].[REY KOD],[RK] = [Web-Malzeme].RK,[REY ACIK] = [Web-Malzeme].[REY ACIK],[MAL ACIK] = [Web-Malzeme].[MAL ACIK],[KOLI] = [Web-Malzeme].KOLI,[KYTK] = [Web-Kampanya-1].KYTK FROM [Web-Kampanya-2] INNER JOIN [Web-Malzeme] ON [Web-Kampanya-2].ITEMREF = [Web-Malzeme].ITEMREF INNER JOIN [Web-Kampanya-1] ON [Web-Kampanya-2].[KAMKARTREF] = [Web-Kampanya-1].[KAMKARTREF] UPDATE [Web-Kampanya-2] SET [KAMP.NET+KDV] = (SELECT [NET+KDV] FROM [Web-Fiyat] WHERE TIP = [Web-Kampanya-2].TIP AND ITEMREF = [Web-Kampanya-2].ITEMREF) * MIKTAR ";
            cmd2.CommandText += "UPDATE [Web-Kampanya-3] SET [KAMPNO] = [Web-Kampanya-1].KAMPNO,[TIP] = [Web-Kampanya-1].FIYAT_TIPI,[GRUP KOD] = [Web-Malzeme].[GRUP KOD],[OZEL KOD] = [Web-Malzeme].[OZEL KOD],[HK] = [Web-Malzeme].HK,[OZEL ACIK] = [Web-Malzeme].[OZEL ACIK],[REY KOD] = [Web-Malzeme].[REY KOD],[RK] = [Web-Malzeme].RK,[REY ACIK] = [Web-Malzeme].[REY ACIK],[MAL ACIK] = [Web-Malzeme].[MAL ACIK],[KOLI] = [Web-Malzeme].KOLI,[KYTK] = [Web-Kampanya-1].KYTK FROM [Web-Kampanya-3] INNER JOIN [Web-Malzeme] ON [Web-Kampanya-3].ITEMREF = [Web-Malzeme].ITEMREF INNER JOIN [Web-Kampanya-1] ON [Web-Kampanya-3].[KAMKARTREF] = [Web-Kampanya-1].[KAMKARTREF] UPDATE [Web-Kampanya-3] SET [HED.NET+KDV] = (SELECT [NET+KDV] FROM [Web-Fiyat] WHERE TIP = [Web-Kampanya-3].TIP AND ITEMREF = [Web-Kampanya-3].ITEMREF) * MIKTAR ";
            cmd2.CommandText += "UPDATE [Web-Kampanya-1] SET ACIKLAMA = (SELECT [OZEL ACIK] FROM [Web-Kampanya-2] WHERE KAMKARTREF = [Web-Kampanya-1].KAMKARTREF),[KAMP.NET+KDV] = (SELECT [KAMP.NET+KDV] FROM [Web-Kampanya-2] WHERE KAMKARTREF = [Web-Kampanya-1].KAMKARTREF),[HED.NET+KDV] = (SELECT [HED.NET+KDV] FROM [Web-Kampanya-3] WHERE KAMKARTREF = [Web-Kampanya-1].KAMKARTREF) UPDATE [KurumsalWebSAP].[dbo].[Web-Kampanya-1] SET [ISK-%] = ([HED.NET+KDV] * 100) / [KAMP.NET+KDV]";
            cmd2.CommandTimeout = 1000;
            conn.Open();
            cmd2.ExecuteNonQuery();
            conn.Close();



            conn.Open(); cmdLog.Parameters.AddWithValue("@dtBitis", DateTime.Now); cmdLog.ExecuteNonQuery(); conn.Close();
        }
        #endregion

        #region FiyatlarC
        private void FiyatlarC()
        {
            FiyatlarCsap();
            return;

            SqlConnection conn = new SqlConnection(General.ConnectionString);

            SqlCommand cmdLog = new SqlCommand("INSERT INTO [KurumsalWebSAP].[dbo].[tblINTERNET_LogTabloGuncellemeler] ([dtBaslangic],[dtBitis],[strYer],[strLog]) VALUES (@dtBaslangic,@dtBitis,@strYer,@strLog)", conn);
            cmdLog.Parameters.AddWithValue("@dtBaslangic", DateTime.Now); cmdLog.Parameters.AddWithValue("@strYer", "SAP Fiyatlar"); cmdLog.Parameters.AddWithValue("@strLog", "");




            getmaterialpricesC.ZwebGetMaterialPricesService clMaterialPrices = new getmaterialpricesC.ZwebGetMaterialPricesService();
            clMaterialPrices.Timeout = 6000000;
            clMaterialPrices.Credentials = nc1;
            getmaterialpricesC.Zwebt004[] listMaterialPrices = clMaterialPrices.ZwebGetMaterialPrices();

            SqlCommand cmd1 = new SqlCommand("DELETE FROM [Web_Fiyat]", conn);
            cmd1.CommandTimeout = 1000;
            conn.Open();
            cmd1.ExecuteNonQuery();
            conn.Close();

            for (int i = 0; i < listMaterialPrices.Length; i++)
            {
                if ((listMaterialPrices[i].Kschl == "ZT01" && listMaterialPrices[i].Pltyp != "02") || (listMaterialPrices[i].Kschl == "ZT22" && listMaterialPrices[i].Pltyp == "02"))
                {
                    int tip = 0; try { tip = Convert.ToInt32(listMaterialPrices[i].Pltyp); }
                    catch { }
                    int itemref = 0; try { itemref = Convert.ToInt32(listMaterialPrices[i].Matnr.Substring(11)); }
                    catch { }
                    double fiyat = 0; try { fiyat = Convert.ToDouble(listMaterialPrices[i].Kbetr) / (listMaterialPrices[i].Kpein > 0 ? Convert.ToDouble(listMaterialPrices[i].Kpein) : 10); }
                    catch { }

                    int vade = 0; try { vade = Convert.ToInt32(listMaterialPrices[i].Zterm); }
                    catch { }
                    if (vade == 0)
                    {
                        try { vade = Convert.ToInt32((Convert.ToDateTime(listMaterialPrices[i].Valdt) - DateTime.Now).TotalDays); }
                        catch { }
                    }

                    int gmref = 0;

                    if (tip == 0)
                    {
                        try { gmref = Convert.ToInt32(listMaterialPrices[i].Kunnr); }
                        catch { }
                        tip = GetFiyatTipiFromGMREF(gmref);
                    }

                    SqlCommand cmd = new SqlCommand("INSERT INTO [Web_Fiyat] " +
                    "([TIP],GMREF,[ITEMREF],[FIYAT],ISK1,ISK2,ISK3,ISK4,ISK5,ISK6,ISK7,ISK8,ISK9,ISK10,[VADE])" +
                    "VALUES (@TIP,@GMREF,@ITEMREF,@FIYAT,0,0,0,0,0,0,0,0,0,0,@VADE)", conn);
                    cmd.CommandTimeout = 1000;
                    cmd.Parameters.AddWithValue("@TIP", tip);
                    cmd.Parameters.AddWithValue("@GMREF", gmref);
                    cmd.Parameters.AddWithValue("@ITEMREF", itemref);
                    cmd.Parameters.AddWithValue("@FIYAT", fiyat);
                    cmd.Parameters.AddWithValue("@VADE", vade);
                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Hatalar.DoInsert(ex, "windows servis SAP fiyatlar");
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }

            for (int i = 0; i < listMaterialPrices.Length; i++)
            {
                string kosul = listMaterialPrices[i].Kschl;
                int tip = 0; try { tip = Convert.ToInt32(listMaterialPrices[i].Pltyp); }
                catch { }
                int itemref = 0; try { itemref = Convert.ToInt32(listMaterialPrices[i].Matnr.Substring(11)); }
                catch { }
                int gmref = 0;

                if (tip == 0)
                {
                    try { gmref = Convert.ToInt32(listMaterialPrices[i].Kunnr); }
                    catch { }
                    tip = GetFiyatTipiFromGMREF(gmref);
                }

                SqlCommand cmd = new SqlCommand();
                cmd.CommandTimeout = 1000;
                cmd.Connection = conn; cmd.CommandText = "";
                cmd.Parameters.AddWithValue("@TIP", tip);
                cmd.Parameters.AddWithValue("@GMREF", gmref);
                cmd.Parameters.AddWithValue("@ITEMREF", itemref);

                if (listMaterialPrices[i].Kschl == "ZT03") // isk1
                {
                    double isk = 0; try { isk = -1 * Convert.ToDouble(listMaterialPrices[i].Kbetr) / (listMaterialPrices[i].Kpein > 0 ? Convert.ToDouble(listMaterialPrices[i].Kpein) : 10); }
                    catch { }
                    cmd.CommandText = "UPDATE [Web_Fiyat] SET ISK1 = @ISK1 WHERE TIP = @TIP AND GMREF = @GMREF AND ITEMREF = @ITEMREF";
                    cmd.Parameters.AddWithValue("@ISK1", isk);
                }
                else if (listMaterialPrices[i].Kschl == "ZT04") // isk2
                {
                    double isk = 0; try { isk = -1 * Convert.ToDouble(listMaterialPrices[i].Kbetr) / (listMaterialPrices[i].Kpein > 0 ? Convert.ToDouble(listMaterialPrices[i].Kpein) : 10); }
                    catch { }
                    cmd.CommandText = "UPDATE [Web_Fiyat] SET ISK2 = @ISK2 WHERE TIP = @TIP AND GMREF = @GMREF AND ITEMREF = @ITEMREF";
                    cmd.Parameters.AddWithValue("@ISK2", isk);
                }
                else if (listMaterialPrices[i].Kschl == "ZT05") // isk3
                {
                    double isk = 0; try { isk = -1 * Convert.ToDouble(listMaterialPrices[i].Kbetr) / (listMaterialPrices[i].Kpein > 0 ? Convert.ToDouble(listMaterialPrices[i].Kpein) : 10); }
                    catch { }
                    cmd.CommandText = "UPDATE [Web_Fiyat] SET ISK3 = @ISK3 WHERE TIP = @TIP AND GMREF = @GMREF AND ITEMREF = @ITEMREF";
                    cmd.Parameters.AddWithValue("@ISK3", isk);
                }
                else if (listMaterialPrices[i].Kschl == "ZT07") // isk4
                {
                    double isk = 0; try { isk = -1 * Convert.ToDouble(listMaterialPrices[i].Kbetr) / (listMaterialPrices[i].Kpein > 0 ? Convert.ToDouble(listMaterialPrices[i].Kpein) : 10); }
                    catch { }
                    cmd.CommandText = "UPDATE [Web_Fiyat] SET ISK4 = @ISK4 WHERE TIP = @TIP AND GMREF = @GMREF AND ITEMREF = @ITEMREF";
                    cmd.Parameters.AddWithValue("@ISK4", isk);
                }
                else if (listMaterialPrices[i].Kschl == "ZT13") // isk5
                {
                    double isk = 0; try { isk = -1 * Convert.ToDouble(listMaterialPrices[i].Kbetr) / (listMaterialPrices[i].Kpein > 0 ? Convert.ToDouble(listMaterialPrices[i].Kpein) : 10); }
                    catch { }
                    cmd.CommandText = "UPDATE [Web_Fiyat] SET ISK5 = @ISK5 WHERE TIP = @TIP AND GMREF = @GMREF AND ITEMREF = @ITEMREF";
                    cmd.Parameters.AddWithValue("@ISK5", isk);
                }
                else if (listMaterialPrices[i].Kschl == "ZT16") // isk6
                {
                    double isk = 0; try { isk = -1 * Convert.ToDouble(listMaterialPrices[i].Kbetr) / (listMaterialPrices[i].Kpein > 0 ? Convert.ToDouble(listMaterialPrices[i].Kpein) : 10); }
                    catch { }
                    cmd.CommandText = "UPDATE [Web_Fiyat] SET ISK6 = @ISK6 WHERE TIP = @TIP AND GMREF = @GMREF AND ITEMREF = @ITEMREF";
                    cmd.Parameters.AddWithValue("@ISK6", isk);
                }
                else if (listMaterialPrices[i].Kschl == "ZT06") // isk7
                {
                    double isk = 0; try { isk = -1 * Convert.ToDouble(listMaterialPrices[i].Kbetr) / (listMaterialPrices[i].Kpein > 0 ? Convert.ToDouble(listMaterialPrices[i].Kpein) : 10); }
                    catch { }
                    cmd.CommandText = "UPDATE [Web_Fiyat] SET ISK7 = @ISK7 WHERE TIP = @TIP AND GMREF = @GMREF AND ITEMREF = @ITEMREF";
                    cmd.Parameters.AddWithValue("@ISK7", isk);
                }
                else if (listMaterialPrices[i].Kschl == "ZT11") // isk8
                {
                    double isk = 0; try { isk = -1 * Convert.ToDouble(listMaterialPrices[i].Kbetr) / (listMaterialPrices[i].Kpein > 0 ? Convert.ToDouble(listMaterialPrices[i].Kpein) : 10); }
                    catch { }
                    cmd.CommandText = "UPDATE [Web_Fiyat] SET ISK8 = @ISK8 WHERE TIP = @TIP AND GMREF = @GMREF AND ITEMREF = @ITEMREF";
                    cmd.Parameters.AddWithValue("@ISK8", isk);
                }
                else if (listMaterialPrices[i].Kschl == "ZT17") // isk9
                {
                    double isk = 0; try { isk = -1 * Convert.ToDouble(listMaterialPrices[i].Kbetr) / (listMaterialPrices[i].Kpein > 0 ? Convert.ToDouble(listMaterialPrices[i].Kpein) : 10); }
                    catch { }
                    cmd.CommandText = "UPDATE [Web_Fiyat] SET ISK9 = @ISK9 WHERE TIP = @TIP AND GMREF = @GMREF AND ITEMREF = @ITEMREF";
                    cmd.Parameters.AddWithValue("@ISK9", isk);
                }
                else if (listMaterialPrices[i].Kschl == "ZT18") // isk10
                {
                    double isk = 0; try { isk = -1 * Convert.ToDouble(listMaterialPrices[i].Kbetr) / (listMaterialPrices[i].Kpein > 0 ? Convert.ToDouble(listMaterialPrices[i].Kpein) : 10); }
                    catch { }
                    cmd.CommandText = "UPDATE [Web_Fiyat] SET ISK10 = @ISK10 WHERE TIP = @TIP AND GMREF = @GMREF AND ITEMREF = @ITEMREF";
                    cmd.Parameters.AddWithValue("@ISK10", isk);
                }

                if (cmd.CommandText != "")
                {
                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Hatalar.DoInsert(ex, "windows servis SAP fiyatlar");
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }



            #region eski usül iskonto ve malzeme bilgileri yazma
            //DataTable dt = new DataTable();
            //SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM [Web_Fiyat]", conn);
            //da.Fill(dt);
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    DataTable dt1 = new DataTable();
            //    SqlDataAdapter da1 = new SqlDataAdapter("SELECT * FROM [Web-Malzeme-Full] WHERE ITEMREF = " + dt.Rows[i]["ITEMREF"].ToString(), conn);
            //    da1.Fill(dt1);

            //    if (dt1.Rows.Count > 0) // ürün varsa
            //    {
            //        double fiyat = Convert.ToDouble(dt.Rows[i]["FIYAT"]);
            //        double isk1 = fiyat - ((fiyat / 100) * Convert.ToDouble(dt.Rows[i]["ISK1"]));
            //        double isk2 = isk1 - ((isk1 / 100) * Convert.ToDouble(dt.Rows[i]["ISK2"]));
            //        double isk3 = isk2 - ((isk2 / 100) * Convert.ToDouble(dt.Rows[i]["ISK3"]));
            //        double isk4 = isk3 - ((isk3 / 100) * Convert.ToDouble(dt.Rows[i]["ISK4"]));
            //        double isk5 = isk4 - ((isk4 / 100) * Convert.ToDouble(dt.Rows[i]["ISK5"]));
            //        double isk6 = isk5 - ((isk5 / 100) * Convert.ToDouble(dt.Rows[i]["ISK6"]));
            //        double isk7 = isk6 - ((isk6 / 100) * Convert.ToDouble(dt.Rows[i]["ISK7"]));
            //        double isk8 = isk7 - ((isk7 / 100) * Convert.ToDouble(dt.Rows[i]["ISK8"]));
            //        double isk9 = isk8 - ((isk8 / 100) * Convert.ToDouble(dt.Rows[i]["ISK9"]));
            //        double isk10 = isk9 - ((isk9 / 100) * Convert.ToDouble(dt.Rows[i]["ISK10"]));
            //        double netkdv = isk10 * ((100.0 + Convert.ToDouble(dt1.Rows[0]["KDV"])) / 100.0);

            //        SqlCommand cmd = new SqlCommand("UPDATE [Web_Fiyat] " +
            //                "SET [GRUP KOD] = @GRUPKOD,[OZEL KOD] = @OZELKOD,[HK] = @HK,[OZEL ACIK] = @OZELACIK,[REY KOD] = @REYKOD,[RK] = @RK,[REY ACIK] = @REYACIK,[MAL ACIK] = @MALACIK,[NET] = @NET,[NET+KDV] = @NETKDV" +
            //                " WHERE TIP = @TIP AND GMREF = @GMREF AND ITEMREF = @ITEMREF", conn);
            //        cmd.CommandTimeout = 1000;

            //        cmd.Parameters.AddWithValue("@GRUPKOD", dt1.Rows[0]["GRUP KOD"].ToString());
            //        cmd.Parameters.AddWithValue("@OZELKOD", dt1.Rows[0]["OZEL KOD"].ToString());
            //        cmd.Parameters.AddWithValue("@HK", dt1.Rows[0]["HK"].ToString());
            //        cmd.Parameters.AddWithValue("@OZELACIK", dt1.Rows[0]["OZEL ACIK"].ToString());
            //        cmd.Parameters.AddWithValue("@REYKOD", dt1.Rows[0]["OZEL KOD"].ToString());
            //        cmd.Parameters.AddWithValue("@RK", dt1.Rows[0]["RK"].ToString());
            //        cmd.Parameters.AddWithValue("@REYACIK", dt1.Rows[0]["REY ACIK"].ToString());
            //        cmd.Parameters.AddWithValue("@MALACIK", dt1.Rows[0]["MAL ACIK"].ToString());
            //        cmd.Parameters.AddWithValue("@NET", isk10);
            //        cmd.Parameters.AddWithValue("@NETKDV", netkdv);
            //        cmd.Parameters.AddWithValue("@TIP", Convert.ToInt32(dt.Rows[i]["TIP"]));
            //        cmd.Parameters.AddWithValue("@GMREF", Convert.ToInt32(dt.Rows[i]["GMREF"]));
            //        cmd.Parameters.AddWithValue("@ITEMREF", Convert.ToInt32(dt.Rows[i]["ITEMREF"]));
            //        try
            //        {
            //            conn.Open();
            //            cmd.ExecuteNonQuery();
            //        }
            //        catch (Exception ex)
            //        {
            //            Hatalar.DoInsert(ex, "windows servis SAP fiyatlar");
            //        }
            //        finally
            //        {
            //            conn.Close();
            //        }
            //    }
            //}
            #endregion

            #region yeni usül
            SqlCommand cmdBilgiler = new SqlCommand("UPDATE [Web_Fiyat] SET [Web_Fiyat].[GRUP KOD] = [Web-Malzeme-Full].[GRUP KOD],[Web_Fiyat].[OZEL KOD] = [Web-Malzeme-Full].[OZEL KOD],[Web_Fiyat].[HK] = [Web-Malzeme-Full].[HK],[Web_Fiyat].[OZEL ACIK] = [Web-Malzeme-Full].[OZEL ACIK],[Web_Fiyat].[REY KOD] = [Web-Malzeme-Full].[REY KOD],[Web_Fiyat].[RK] = [Web-Malzeme-Full].[RK],[Web_Fiyat].[REY ACIK] = [Web-Malzeme-Full].[REY ACIK],[Web_Fiyat].[MAL ACIK] = [Web-Malzeme-Full].[MAL ACIK],[Web_Fiyat].[NET] = dbo.IskontoDusCoklu([Web_Fiyat].FIYAT, [Web_Fiyat].ISK1, [Web_Fiyat].ISK2, [Web_Fiyat].ISK3, [Web_Fiyat].ISK4, [Web_Fiyat].ISK5, [Web_Fiyat].ISK6, [Web_Fiyat].ISK7, [Web_Fiyat].ISK8, [Web_Fiyat].ISK9, [Web_Fiyat].ISK10),[Web_Fiyat].[NET+KDV] = dbo.IskontoDusCoklu([Web_Fiyat].FIYAT, [Web_Fiyat].ISK1, [Web_Fiyat].ISK2, [Web_Fiyat].ISK3, [Web_Fiyat].ISK4, [Web_Fiyat].ISK5, [Web_Fiyat].ISK6, [Web_Fiyat].ISK7, [Web_Fiyat].ISK8, [Web_Fiyat].ISK9, [Web_Fiyat].ISK10) * ((100 + [Web-Malzeme-Full].KDV) / 100) FROM [Web_Fiyat] INNER JOIN [Web-Malzeme-Full] ON [Web_Fiyat].[ITEMREF] = [Web-Malzeme-Full].[ITEMREF]", conn);
            cmdBilgiler.CommandTimeout = 1000;
            conn.Open();
            cmdBilgiler.ExecuteNonQuery();
            conn.Close();
            #endregion



            SqlCommand cmd4 = new SqlCommand("DELETE FROM [Web_Fiyat] WHERE [NET] IS NULL", conn);
            cmd4.CommandTimeout = 1000;
            conn.Open();
            cmd4.ExecuteNonQuery();
            conn.Close();

            SqlCommand cmd2 = new SqlCommand("BEGIN TRANSACTION t_Transaction TRUNCATE TABLE [Web-Fiyat] INSERT INTO [Web-Fiyat] SELECT * FROM [Web_Fiyat] WITH (HOLDLOCK) COMMIT TRANSACTION t_Transaction", conn);
            cmd2.CommandTimeout = 1000;
            conn.Open();
            cmd2.ExecuteNonQuery();
            conn.Close();

            SqlCommand cmd3 = new SqlCommand("DELETE FROM [Web-Fiyat] WHERE TIP = 21" +

                "INSERT INTO [Web-Fiyat] ([TIP],[GMREF],[GRUP KOD],[OZEL KOD],[HK],[OZEL ACIK],[REY KOD],[RK],[REY ACIK],[ITEMREF],[MAL ACIK],[FIYAT],[ISK1],[ISK2],[ISK3],[ISK4],[ISK5],[ISK6],[ISK7],[ISK8],[ISK9],[ISK10],[NET],[NET+KDV],[VADE],[KAMKARTREF],[ODEME_GUN],[ODEME_TARIH])" +
                "SELECT 21,0,[Web-Fiyat].[GRUP KOD],[Web-Fiyat].[OZEL KOD],[Web-Fiyat].[HK],[Web-Fiyat].[OZEL ACIK],[Web-Fiyat].[REY KOD],[Web-Fiyat].[RK],[Web-Fiyat].[REY ACIK],[Web-Fiyat].[ITEMREF],[Web-Fiyat].[MAL ACIK]," +
                "(SELECT FIYAT FROM [Web-Fiyat] AS FIY WHERE TIP = 7 AND ITEMREF = [Web-Fiyat].ITEMREF)" +
                ",0,0,0,0,0,0,0,0,0,0" +
                ",(SELECT FIYAT FROM [Web-Fiyat] AS FIY WHERE TIP = 7 AND ITEMREF = [Web-Fiyat].ITEMREF) - ((SELECT FIYAT FROM [Web-Fiyat] AS FIY WHERE TIP = 7 AND ITEMREF = [Web-Fiyat].ITEMREF) / 100 * (SELECT Xml_Haric_Kar FROM tblWebGenel))" +
                ",((SELECT FIYAT FROM [Web-Fiyat] AS FIY WHERE TIP = 7 AND ITEMREF = [Web-Fiyat].ITEMREF) - ((SELECT FIYAT FROM [Web-Fiyat] AS FIY WHERE TIP = 7 AND ITEMREF = [Web-Fiyat].ITEMREF) / 100 * (SELECT Xml_Haric_Kar FROM tblWebGenel))) * ((100 + KDV) / 100)" +
                ",[VADE],[KAMKARTREF],[ODEME_GUN],[ODEME_TARIH]" +

                "FROM [Web-Fiyat] INNER JOIN [Web-Malzeme-Full] ON [Web-Fiyat].ITEMREF = [Web-Malzeme-Full].ITEMREF WHERE TIP = 7", conn);
            cmd3.CommandTimeout = 1000;
            conn.Open();
            cmd3.ExecuteNonQuery();
            conn.Close();



            conn.Open(); cmdLog.Parameters.AddWithValue("@dtBitis", DateTime.Now); cmdLog.ExecuteNonQuery(); conn.Close();
        }
        #endregion

        #region FiyatlarCsap
        private void FiyatlarCsap()
        {
            SqlConnection conn = new SqlConnection(General.ConnectionString);

            SqlCommand cmdLog = new SqlCommand("INSERT INTO [KurumsalWebSAP].[dbo].[tblINTERNET_LogTabloGuncellemeler] ([dtBaslangic],[dtBitis],[strYer],[strLog]) VALUES (@dtBaslangic,@dtBitis,@strYer,@strLog)", conn);
            cmdLog.Parameters.AddWithValue("@dtBaslangic", DateTime.Now); cmdLog.Parameters.AddWithValue("@strYer", "SAP Fiyatlar");



            SqlCommand cmd11 = new SqlCommand("SELECT count(*) FROM [Web_Fiyat_SAP]", conn);
            cmd11.CommandTimeout = 1000;
            conn.Open();
            int oncekifiyatsayisi = Convert.ToInt32(cmd11.ExecuteScalar());
            conn.Close();

            getmaterialpricesC.ZwebGetMaterialPricesService clMaterialPrices = new getmaterialpricesC.ZwebGetMaterialPricesService();
            clMaterialPrices.Timeout = 6000000;
            clMaterialPrices.Credentials = nc1;
            getmaterialpricesC.Zwebt004[] listMaterialPrices = null;

            int tekrarcek = 0;
            while (tekrarcek < tekrarcekilecek)
            {
                try
                {
                    listMaterialPrices = clMaterialPrices.ZwebGetMaterialPrices();
                    tekrarcek = tekrarcekilecek;
                }
                catch (Exception ex)
                {
                    if (tekrarcek < tekrarcekilecek)
                    {
                        tekrarcek++;
                        System.Threading.Thread.Sleep(3000);
                    }
                    else
                    {
                        cmdLog.Parameters.AddWithValue("@strLog", ex.Message);
                        conn.Open(); cmdLog.Parameters.AddWithValue("@dtBitis", DateTime.Now); cmdLog.ExecuteNonQuery(); conn.Close();
                        return;
                    }
                }
            }



            if (oncekifiyatsayisi - 5000 < listMaterialPrices.Length)
            {
                SqlCommand cmd1 = new SqlCommand("DELETE FROM [Web_Fiyat_SAP]", conn);
                cmd1.CommandTimeout = 1000;
                conn.Open();
                cmd1.ExecuteNonQuery();
                conn.Close();

                for (int i = 0; i < listMaterialPrices.Length; i++)
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO [Web_Fiyat_SAP] " +
                    "(Aedat,Aezet,Kbetr,Kdgrp,Kmein,Konwa,Kpein,Kschl,Kunnr,Mandt,Matnr,Pltyp,Valdt,Zterm)" +
                    "VALUES (@Aedat,@Aezet,@Kbetr,@Kdgrp,@Kmein,@Konwa,@Kpein,@Kschl,@Kunnr,@Mandt,@Matnr,@Pltyp,@Valdt,@Zterm)", conn);
                    cmd.CommandTimeout = 1000;
                    cmd.Parameters.AddWithValue("@Aedat", listMaterialPrices[i].Aedat);
                    cmd.Parameters.AddWithValue("@Aezet", listMaterialPrices[i].Aezet);
                    cmd.Parameters.AddWithValue("@Kbetr", listMaterialPrices[i].Kbetr);
                    cmd.Parameters.AddWithValue("@Kdgrp", listMaterialPrices[i].Kdgrp);
                    cmd.Parameters.AddWithValue("@Kmein", listMaterialPrices[i].Kmein);
                    cmd.Parameters.AddWithValue("@Konwa", listMaterialPrices[i].Konwa);
                    cmd.Parameters.AddWithValue("@Kpein", listMaterialPrices[i].Kpein);
                    cmd.Parameters.AddWithValue("@Kschl", listMaterialPrices[i].Kschl);
                    cmd.Parameters.AddWithValue("@Kunnr", listMaterialPrices[i].Kunnr);
                    cmd.Parameters.AddWithValue("@Mandt", listMaterialPrices[i].Mandt);
                    cmd.Parameters.AddWithValue("@Matnr", listMaterialPrices[i].Matnr);
                    cmd.Parameters.AddWithValue("@Pltyp", listMaterialPrices[i].Pltyp);
                    cmd.Parameters.AddWithValue("@Valdt", listMaterialPrices[i].Valdt);
                    cmd.Parameters.AddWithValue("@Zterm", listMaterialPrices[i].Zterm);
                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Hatalar.DoInsert(ex, "windows servis SAP fiyatlar");
                    }
                    finally
                    {
                        conn.Close();
                    }
                }



                /*SqlCommand cmd5 = new SqlCommand("INSERT INTO [Web_Fiyat] SELECT *,NULL,NULL,NULL FROM [Web_Fiyat_SAP_aktarim]", conn);
                cmd5.CommandTimeout = 1000;
                conn.Open();
                cmd5.ExecuteNonQuery();
                conn.Close();*/

                /*SqlCommand cmd4 = new SqlCommand("DELETE FROM [Web_Fiyat] WHERE [NET] IS NULL", conn);
                cmd4.CommandTimeout = 1000;
                conn.Open();
                cmd4.ExecuteNonQuery();
                conn.Close();*/

                SqlCommand cmd10 = new SqlCommand("DROP TABLE [Web-Fiyat-Onceki] SELECT * INTO [Web-Fiyat-Onceki] FROM [dbo].[Web-Fiyat]", conn);
                cmd10.CommandTimeout = 1000;
                conn.Open();
                cmd10.ExecuteNonQuery();
                conn.Close();

                SqlCommand cmd2 = new SqlCommand("BEGIN TRANSACTION t_Transaction TRUNCATE TABLE [Web-Fiyat] INSERT INTO [Web-Fiyat] SELECT *,NULL,NULL,NULL FROM [Web_Fiyat_SAP_aktarim] WITH (HOLDLOCK) COMMIT TRANSACTION t_Transaction", conn);
                cmd2.CommandTimeout = 1000;
                conn.Open();
                cmd2.ExecuteNonQuery();
                conn.Close();

                SqlCommand cmd3 = new SqlCommand("DELETE FROM [Web-Fiyat] WHERE TIP = 21 " +

                    "INSERT INTO [Web-Fiyat] ([TIP],[GMREF],[GRUP KOD],[OZEL KOD],[HK],[OZEL ACIK],[REY KOD],[RK],[REY ACIK],[ITEMREF],[MAL ACIK],[FIYAT],[ISK1],[ISK2],[ISK3],[ISK4],[ISK5],[ISK6],[ISK7],[ISK8],[ISK9],[ISK10],[NET],[NET+KDV],[VADE],[KAMKARTREF],[ODEME_GUN],[ODEME_TARIH])" +

                    "SELECT 21,0,[Web-Fiyat].[GRUP KOD],[Web-Fiyat].[OZEL KOD],[Web-Fiyat].[HK],[Web-Fiyat].[OZEL ACIK],[Web-Fiyat].[REY KOD],[Web-Fiyat].[RK],[Web-Fiyat].[REY ACIK],[Web-Fiyat].[ITEMREF],[Web-Fiyat].[MAL ACIK],FIYAT,0,0,0,0,0,0,0,0,0,0,FIYAT - (FIYAT / 100 * (SELECT Xml_Haric_Kar FROM tblWebGenel)),(FIYAT - (FIYAT / 100 * (SELECT Xml_Haric_Kar FROM tblWebGenel))) * ((100 + KDV) / 100),[VADE],[KAMKARTREF],[ODEME_GUN],[ODEME_TARIH]FROM [Web-Fiyat] INNER JOIN [Web-Malzeme-Full] ON [Web-Fiyat].ITEMREF = [Web-Malzeme-Full].ITEMREF WHERE TIP = 7"

                    /*"SELECT 21,0,[Web-Fiyat].[GRUP KOD],[Web-Fiyat].[OZEL KOD],[Web-Fiyat].[HK],[Web-Fiyat].[OZEL ACIK],[Web-Fiyat].[REY KOD],[Web-Fiyat].[RK],[Web-Fiyat].[REY ACIK],[Web-Fiyat].[ITEMREF],[Web-Fiyat].[MAL ACIK]," +
                    "(SELECT FIYAT FROM [Web-Fiyat] AS FIY WHERE TIP = 7 AND ITEMREF = [Web-Fiyat].ITEMREF)" +
                    ",0,0,0,0,0,0,0,0,0,0" +
                    ",(SELECT FIYAT FROM [Web-Fiyat] AS FIY WHERE TIP = 7 AND ITEMREF = [Web-Fiyat].ITEMREF) - ((SELECT FIYAT FROM [Web-Fiyat] AS FIY WHERE TIP = 7 AND ITEMREF = [Web-Fiyat].ITEMREF) / 100 * (SELECT Xml_Haric_Kar FROM tblWebGenel))" +
                    ",((SELECT FIYAT FROM [Web-Fiyat] AS FIY WHERE TIP = 7 AND ITEMREF = [Web-Fiyat].ITEMREF) - ((SELECT FIYAT FROM [Web-Fiyat] AS FIY WHERE TIP = 7 AND ITEMREF = [Web-Fiyat].ITEMREF) / 100 * (SELECT Xml_Haric_Kar FROM tblWebGenel))) * ((100 + KDV) / 100)" +
                    ",[VADE],[KAMKARTREF],[ODEME_GUN],[ODEME_TARIH]" +

                    "FROM [Web-Fiyat] INNER JOIN [Web-Malzeme-Full] ON [Web-Fiyat].ITEMREF = [Web-Malzeme-Full].ITEMREF WHERE TIP = 7"*/
                    , conn);
                cmd3.CommandTimeout = 1000;
                conn.Open();
                cmd3.ExecuteNonQuery();
                conn.Close();

                cmdLog.Parameters.AddWithValue("@strLog", listMaterialPrices.Length.ToString() + " Satır");
            }
            else
            {
                cmdLog.Parameters.AddWithValue("@strLog", listMaterialPrices.Length.ToString() + " Satır" + " (Yazma yapılmadı)");
            }



            conn.Open(); cmdLog.Parameters.AddWithValue("@dtBitis", DateTime.Now); cmdLog.ExecuteNonQuery(); conn.Close();
        }
        #endregion

        #region multithread fiyatlar (kullanılmıyor)
        bool Fiyatbirbitti = false, Fiyatikibitti = false, Fiyatucbitti = false, Fiyatdortbitti = false;

        private void FiyatlarCmt()
        {
            SqlConnection conn = new SqlConnection("Server=95.0.47.133; Database=KurumsalWebSAP; User Id=sa; Password=sdl580g5p9+-; Trusted_Connection=False;");

            SqlCommand cmdLog = new SqlCommand("INSERT INTO [KurumsalWebSAP].[dbo].[tblINTERNET_LogTabloGuncellemeler] ([dtBaslangic],[dtBitis],[strYer],[strLog]) VALUES (@dtBaslangic,@dtBitis,@strYer,@strLog)", conn);
            cmdLog.Parameters.AddWithValue("@dtBaslangic", DateTime.Now); cmdLog.Parameters.AddWithValue("@strYer", "SAP Fiyatlar"); cmdLog.Parameters.AddWithValue("@strLog", "");



            getmaterialpricesC.ZwebGetMaterialPricesService clMaterialPrices = new getmaterialpricesC.ZwebGetMaterialPricesService();
            clMaterialPrices.Timeout = 6000000;
            clMaterialPrices.Credentials = nc1;
            getmaterialpricesC.Zwebt004[] listMaterialPrices = clMaterialPrices.ZwebGetMaterialPrices();

            SqlCommand cmd1 = new SqlCommand("DELETE FROM [Web_Fiyat]", conn);
            cmd1.CommandTimeout = 1000;
            conn.Open();
            cmd1.ExecuteNonQuery();
            conn.Close();


            System.Threading.Thread thr1 = new System.Threading.Thread(new System.Threading.ParameterizedThreadStart(FiyatlarCmtIslem));
            System.Threading.Thread thr2 = new System.Threading.Thread(new System.Threading.ParameterizedThreadStart(FiyatlarCmtIslem));
            System.Threading.Thread thr3 = new System.Threading.Thread(new System.Threading.ParameterizedThreadStart(FiyatlarCmtIslem));
            System.Threading.Thread thr4 = new System.Threading.Thread(new System.Threading.ParameterizedThreadStart(FiyatlarCmtIslem));
            int bir = listMaterialPrices.Length / 4;
            int iki = bir * 2;
            int uc = bir * 3;
            int dort = listMaterialPrices.Length;
            FiyatlarCmtParametre par1 = new FiyatlarCmtParametre() { listMaterialPrices = listMaterialPrices, baslangic = 0, bitis = bir, kacinci = 1, cmdLog = cmdLog };
            FiyatlarCmtParametre par2 = new FiyatlarCmtParametre() { listMaterialPrices = listMaterialPrices, baslangic = bir, bitis = iki, kacinci = 2, cmdLog = cmdLog };
            FiyatlarCmtParametre par3 = new FiyatlarCmtParametre() { listMaterialPrices = listMaterialPrices, baslangic = iki, bitis = uc, kacinci = 3, cmdLog = cmdLog };
            FiyatlarCmtParametre par4 = new FiyatlarCmtParametre() { listMaterialPrices = listMaterialPrices, baslangic = uc, bitis = dort, kacinci = 4, cmdLog = cmdLog };
            thr1.Start(par1);
            thr2.Start(par2);
            thr3.Start(par3);
            thr4.Start(par4);
        }

        private void FiyatlarCmtBitis(SqlCommand cmdLog)
        {
            if (Fiyatbirbitti && Fiyatikibitti && Fiyatucbitti && Fiyatdortbitti)
            {
                SqlConnection conn = new SqlConnection("Server=95.0.47.133; Database=KurumsalWebSAP; User Id=sa; Password=sdl580g5p9+-; Trusted_Connection=False;");

                SqlCommand cmdBilgiler = new SqlCommand("UPDATE [Web_Fiyat] SET [Web_Fiyat].[GRUP KOD] = [Web-Malzeme-Full].[GRUP KOD],[Web_Fiyat].[OZEL KOD] = [Web-Malzeme-Full].[OZEL KOD],[Web_Fiyat].[HK] = [Web-Malzeme-Full].[HK],[Web_Fiyat].[OZEL ACIK] = [Web-Malzeme-Full].[OZEL ACIK],[Web_Fiyat].[REY KOD] = [Web-Malzeme-Full].[REY KOD],[Web_Fiyat].[RK] = [Web-Malzeme-Full].[RK],[Web_Fiyat].[REY ACIK] = [Web-Malzeme-Full].[REY ACIK],[Web_Fiyat].[MAL ACIK] = [Web-Malzeme-Full].[MAL ACIK],[Web_Fiyat].[NET] = dbo.IskontoDusCoklu([Web_Fiyat].FIYAT, [Web_Fiyat].ISK1, [Web_Fiyat].ISK2, [Web_Fiyat].ISK3, [Web_Fiyat].ISK4, [Web_Fiyat].ISK5, [Web_Fiyat].ISK6, [Web_Fiyat].ISK7, [Web_Fiyat].ISK8, [Web_Fiyat].ISK9, [Web_Fiyat].ISK10),[Web_Fiyat].[NET+KDV] = dbo.IskontoDusCoklu([Web_Fiyat].FIYAT, [Web_Fiyat].ISK1, [Web_Fiyat].ISK2, [Web_Fiyat].ISK3, [Web_Fiyat].ISK4, [Web_Fiyat].ISK5, [Web_Fiyat].ISK6, [Web_Fiyat].ISK7, [Web_Fiyat].ISK8, [Web_Fiyat].ISK9, [Web_Fiyat].ISK10) * ((100 + [Web-Malzeme-Full].KDV) / 100) FROM [Web_Fiyat] INNER JOIN [Web-Malzeme-Full] ON [Web_Fiyat].[ITEMREF] = [Web-Malzeme-Full].[ITEMREF]", conn);
                cmdBilgiler.CommandTimeout = 1000;
                conn.Open();
                cmdBilgiler.ExecuteNonQuery();
                conn.Close();



                SqlCommand cmd4 = new SqlCommand("DELETE FROM [Web_Fiyat] WHERE [NET] IS NULL", conn);
                cmd4.CommandTimeout = 1000;
                conn.Open();
                cmd4.ExecuteNonQuery();
                conn.Close();

                SqlCommand cmd2 = new SqlCommand("BEGIN TRANSACTION t_Transaction TRUNCATE TABLE [Web-Fiyat] INSERT INTO [Web-Fiyat] SELECT * FROM [Web_Fiyat] WITH (HOLDLOCK) COMMIT TRANSACTION t_Transaction", conn);
                cmd2.CommandTimeout = 1000;
                conn.Open();
                cmd2.ExecuteNonQuery();
                conn.Close();

                SqlCommand cmd3 = new SqlCommand("DELETE FROM [Web-Fiyat] WHERE TIP = 21 " +

                    "INSERT INTO [Web-Fiyat] ([TIP],[GMREF],[GRUP KOD],[OZEL KOD],[HK],[OZEL ACIK],[REY KOD],[RK],[REY ACIK],[ITEMREF],[MAL ACIK],[FIYAT],[ISK1],[ISK2],[ISK3],[ISK4],[ISK5],[ISK6],[ISK7],[ISK8],[ISK9],[ISK10],[NET],[NET+KDV],[VADE],[KAMKARTREF],[ODEME_GUN],[ODEME_TARIH])" +
                    "SELECT 21,0,[Web-Fiyat].[GRUP KOD],[Web-Fiyat].[OZEL KOD],[Web-Fiyat].[HK],[Web-Fiyat].[OZEL ACIK],[Web-Fiyat].[REY KOD],[Web-Fiyat].[RK],[Web-Fiyat].[REY ACIK],[Web-Fiyat].[ITEMREF],[Web-Fiyat].[MAL ACIK]," +
                    "(SELECT FIYAT FROM [Web-Fiyat] AS FIY WHERE TIP = 7 AND ITEMREF = [Web-Fiyat].ITEMREF)" +
                    ",0,0,0,0,0,0,0,0,0,0" +
                    ",(SELECT FIYAT FROM [Web-Fiyat] AS FIY WHERE TIP = 7 AND ITEMREF = [Web-Fiyat].ITEMREF) - ((SELECT FIYAT FROM [Web-Fiyat] AS FIY WHERE TIP = 7 AND ITEMREF = [Web-Fiyat].ITEMREF) / 100 * (SELECT Xml_Haric_Kar FROM tblWebGenel))" +
                    ",((SELECT FIYAT FROM [Web-Fiyat] AS FIY WHERE TIP = 7 AND ITEMREF = [Web-Fiyat].ITEMREF) - ((SELECT FIYAT FROM [Web-Fiyat] AS FIY WHERE TIP = 7 AND ITEMREF = [Web-Fiyat].ITEMREF) / 100 * (SELECT Xml_Haric_Kar FROM tblWebGenel))) * ((100 + KDV) / 100)" +
                    ",[VADE],[KAMKARTREF],[ODEME_GUN],[ODEME_TARIH]" +

                    "FROM [Web-Fiyat] INNER JOIN [Web-Malzeme-Full] ON [Web-Fiyat].ITEMREF = [Web-Malzeme-Full].ITEMREF WHERE TIP = 7", conn);
                cmd3.CommandTimeout = 1000;
                conn.Open();
                cmd3.ExecuteNonQuery();
                conn.Close();



                conn.Open(); cmdLog.Parameters.AddWithValue("@dtBitis", DateTime.Now); cmdLog.ExecuteNonQuery(); conn.Close();

                Fiyatbirbitti = false;
                Fiyatikibitti = false;
                Fiyatucbitti = false;
                Fiyatdortbitti = false;
            }
        }

        private void FiyatlarCmtIslem(object para)
        {
            FiyatlarCmtParametre gelen = (FiyatlarCmtParametre)para;
            getmaterialpricesC.Zwebt004[] listMaterialPrices = gelen.listMaterialPrices;
            int baslangic = gelen.baslangic;
            int bitis = gelen.bitis;
            int kacinci = gelen.kacinci;
            SqlCommand cmdLog = gelen.cmdLog;
            SqlConnection conn = new SqlConnection("Server=95.0.47.133; Database=KurumsalWebSAP; User Id=sa; Password=sdl580g5p9+-; Trusted_Connection=False;");



            for (int i = baslangic; i < bitis; i++)
            {
                if ((listMaterialPrices[i].Kschl == "ZT01" && listMaterialPrices[i].Pltyp != "02") || (listMaterialPrices[i].Kschl == "ZT22" && listMaterialPrices[i].Pltyp == "02"))
                {
                    int tip = 0; try { tip = Convert.ToInt32(listMaterialPrices[i].Pltyp); }
                    catch { }
                    int itemref = 0; try { itemref = Convert.ToInt32(listMaterialPrices[i].Matnr.Substring(11)); }
                    catch { }
                    double fiyat = 0; try { fiyat = Convert.ToDouble(listMaterialPrices[i].Kbetr) / (listMaterialPrices[i].Kpein > 0 ? Convert.ToDouble(listMaterialPrices[i].Kpein) : 10); }
                    catch { }

                    int vade = 0; try { vade = Convert.ToInt32(listMaterialPrices[i].Zterm); }
                    catch { }
                    if (vade == 0)
                    {
                        try { vade = Convert.ToInt32((Convert.ToDateTime(listMaterialPrices[i].Valdt) - DateTime.Now).TotalDays); }
                        catch { }
                    }

                    int gmref = 0;

                    if (tip == 0)
                    {
                        try { gmref = Convert.ToInt32(listMaterialPrices[i].Kunnr); }
                        catch { }
                        tip = GetFiyatTipiFromGMREF(gmref);
                    }

                    SqlCommand cmd = new SqlCommand("INSERT INTO [Web_Fiyat] " +
                    "([TIP],GMREF,[ITEMREF],[FIYAT],ISK1,ISK2,ISK3,ISK4,ISK5,ISK6,ISK7,ISK8,ISK9,ISK10,[VADE])" +
                    "VALUES (@TIP,@GMREF,@ITEMREF,@FIYAT,0,0,0,0,0,0,0,0,0,0,@VADE)", conn);
                    cmd.CommandTimeout = 1000;
                    cmd.Parameters.AddWithValue("@TIP", tip);
                    cmd.Parameters.AddWithValue("@GMREF", gmref);
                    cmd.Parameters.AddWithValue("@ITEMREF", itemref);
                    cmd.Parameters.AddWithValue("@FIYAT", fiyat);
                    cmd.Parameters.AddWithValue("@VADE", vade);
                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Hatalar.DoInsert(ex, "windows servis SAP fiyatlar");
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }

            for (int i = baslangic; i < bitis; i++)
            {
                string kosul = listMaterialPrices[i].Kschl;
                int tip = 0; try { tip = Convert.ToInt32(listMaterialPrices[i].Pltyp); }
                catch { }
                int itemref = 0; try { itemref = Convert.ToInt32(listMaterialPrices[i].Matnr.Substring(11)); }
                catch { }
                int gmref = 0;

                if (tip == 0)
                {
                    try { gmref = Convert.ToInt32(listMaterialPrices[i].Kunnr); }
                    catch { }
                    tip = GetFiyatTipiFromGMREF(gmref);
                }

                SqlCommand cmd = new SqlCommand();
                cmd.CommandTimeout = 1000;
                cmd.Connection = conn; cmd.CommandText = "";
                cmd.Parameters.AddWithValue("@TIP", tip);
                cmd.Parameters.AddWithValue("@GMREF", gmref);
                cmd.Parameters.AddWithValue("@ITEMREF", itemref);

                if (listMaterialPrices[i].Kschl == "ZT03") // isk1
                {
                    double isk = 0; try { isk = -1 * Convert.ToDouble(listMaterialPrices[i].Kbetr) / (listMaterialPrices[i].Kpein > 0 ? Convert.ToDouble(listMaterialPrices[i].Kpein) : 10); }
                    catch { }
                    cmd.CommandText = "UPDATE [Web_Fiyat] SET ISK1 = @ISK1 WHERE TIP = @TIP AND GMREF = @GMREF AND ITEMREF = @ITEMREF";
                    cmd.Parameters.AddWithValue("@ISK1", isk);
                }
                else if (listMaterialPrices[i].Kschl == "ZT04") // isk2
                {
                    double isk = 0; try { isk = -1 * Convert.ToDouble(listMaterialPrices[i].Kbetr) / (listMaterialPrices[i].Kpein > 0 ? Convert.ToDouble(listMaterialPrices[i].Kpein) : 10); }
                    catch { }
                    cmd.CommandText = "UPDATE [Web_Fiyat] SET ISK2 = @ISK2 WHERE TIP = @TIP AND GMREF = @GMREF AND ITEMREF = @ITEMREF";
                    cmd.Parameters.AddWithValue("@ISK2", isk);
                }
                else if (listMaterialPrices[i].Kschl == "ZT05") // isk3
                {
                    double isk = 0; try { isk = -1 * Convert.ToDouble(listMaterialPrices[i].Kbetr) / (listMaterialPrices[i].Kpein > 0 ? Convert.ToDouble(listMaterialPrices[i].Kpein) : 10); }
                    catch { }
                    cmd.CommandText = "UPDATE [Web_Fiyat] SET ISK3 = @ISK3 WHERE TIP = @TIP AND GMREF = @GMREF AND ITEMREF = @ITEMREF";
                    cmd.Parameters.AddWithValue("@ISK3", isk);
                }
                else if (listMaterialPrices[i].Kschl == "ZT07") // isk4
                {
                    double isk = 0; try { isk = -1 * Convert.ToDouble(listMaterialPrices[i].Kbetr) / (listMaterialPrices[i].Kpein > 0 ? Convert.ToDouble(listMaterialPrices[i].Kpein) : 10); }
                    catch { }
                    cmd.CommandText = "UPDATE [Web_Fiyat] SET ISK4 = @ISK4 WHERE TIP = @TIP AND GMREF = @GMREF AND ITEMREF = @ITEMREF";
                    cmd.Parameters.AddWithValue("@ISK4", isk);
                }
                else if (listMaterialPrices[i].Kschl == "ZT13") // isk5
                {
                    double isk = 0; try { isk = -1 * Convert.ToDouble(listMaterialPrices[i].Kbetr) / (listMaterialPrices[i].Kpein > 0 ? Convert.ToDouble(listMaterialPrices[i].Kpein) : 10); }
                    catch { }
                    cmd.CommandText = "UPDATE [Web_Fiyat] SET ISK5 = @ISK5 WHERE TIP = @TIP AND GMREF = @GMREF AND ITEMREF = @ITEMREF";
                    cmd.Parameters.AddWithValue("@ISK5", isk);
                }
                else if (listMaterialPrices[i].Kschl == "ZT16") // isk6
                {
                    double isk = 0; try { isk = -1 * Convert.ToDouble(listMaterialPrices[i].Kbetr) / (listMaterialPrices[i].Kpein > 0 ? Convert.ToDouble(listMaterialPrices[i].Kpein) : 10); }
                    catch { }
                    cmd.CommandText = "UPDATE [Web_Fiyat] SET ISK6 = @ISK6 WHERE TIP = @TIP AND GMREF = @GMREF AND ITEMREF = @ITEMREF";
                    cmd.Parameters.AddWithValue("@ISK6", isk);
                }
                else if (listMaterialPrices[i].Kschl == "ZT06") // isk7
                {
                    double isk = 0; try { isk = -1 * Convert.ToDouble(listMaterialPrices[i].Kbetr) / (listMaterialPrices[i].Kpein > 0 ? Convert.ToDouble(listMaterialPrices[i].Kpein) : 10); }
                    catch { }
                    cmd.CommandText = "UPDATE [Web_Fiyat] SET ISK7 = @ISK7 WHERE TIP = @TIP AND GMREF = @GMREF AND ITEMREF = @ITEMREF";
                    cmd.Parameters.AddWithValue("@ISK7", isk);
                }
                else if (listMaterialPrices[i].Kschl == "ZT11") // isk8
                {
                    double isk = 0; try { isk = -1 * Convert.ToDouble(listMaterialPrices[i].Kbetr) / (listMaterialPrices[i].Kpein > 0 ? Convert.ToDouble(listMaterialPrices[i].Kpein) : 10); }
                    catch { }
                    cmd.CommandText = "UPDATE [Web_Fiyat] SET ISK8 = @ISK8 WHERE TIP = @TIP AND GMREF = @GMREF AND ITEMREF = @ITEMREF";
                    cmd.Parameters.AddWithValue("@ISK8", isk);
                }
                else if (listMaterialPrices[i].Kschl == "ZT17") // isk9
                {
                    double isk = 0; try { isk = -1 * Convert.ToDouble(listMaterialPrices[i].Kbetr) / (listMaterialPrices[i].Kpein > 0 ? Convert.ToDouble(listMaterialPrices[i].Kpein) : 10); }
                    catch { }
                    cmd.CommandText = "UPDATE [Web_Fiyat] SET ISK9 = @ISK9 WHERE TIP = @TIP AND GMREF = @GMREF AND ITEMREF = @ITEMREF";
                    cmd.Parameters.AddWithValue("@ISK9", isk);
                }
                else if (listMaterialPrices[i].Kschl == "ZT18") // isk10
                {
                    double isk = 0; try { isk = -1 * Convert.ToDouble(listMaterialPrices[i].Kbetr) / (listMaterialPrices[i].Kpein > 0 ? Convert.ToDouble(listMaterialPrices[i].Kpein) : 10); }
                    catch { }
                    cmd.CommandText = "UPDATE [Web_Fiyat] SET ISK10 = @ISK10 WHERE TIP = @TIP AND GMREF = @GMREF AND ITEMREF = @ITEMREF";
                    cmd.Parameters.AddWithValue("@ISK10", isk);
                }

                if (cmd.CommandText != "")
                {
                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Hatalar.DoInsert(ex, "windows servis SAP fiyatlar");
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }

            if (kacinci == 1)
                Fiyatbirbitti = true;
            else if (kacinci == 2)
                Fiyatikibitti = true;
            else if (kacinci == 3)
                Fiyatucbitti = true;
            else if (kacinci == 4)
                Fiyatdortbitti = true;

            FiyatlarCmtBitis(cmdLog);
        }
        #endregion

        #region MalzemelerC
        private void MalzemelerC(bool malzeme, bool olcubirim)
        {
            SqlConnection conn = new SqlConnection(General.ConnectionString);

            SqlCommand cmdLog = new SqlCommand("INSERT INTO [KurumsalWebSAP].[dbo].[tblINTERNET_LogTabloGuncellemeler] ([dtBaslangic],[dtBitis],[strYer],[strLog]) VALUES (@dtBaslangic,@dtBitis,@strYer,@strLog)", conn);
            cmdLog.Parameters.AddWithValue("@dtBaslangic", DateTime.Now); cmdLog.Parameters.AddWithValue("@strYer", "SAP Malzemeler");



            getmaterialsC.ZwebGetMaterialsService clMaterials = new getmaterialsC.ZwebGetMaterialsService();
            clMaterials.Timeout = 6000000;
            clMaterials.Credentials = nc1;
            getmaterialsC.Zwebs025[] yirmibes = null;
            getmaterialsC.Zwebt001St[] birst = null;
            getmaterialsC.Zwebt001[] listMaterials = null;

            int tekrarcek = 0;
            while (tekrarcek < tekrarcekilecek)
            {
                try
                {
                    listMaterials = clMaterials.ZwebGetMaterials(out yirmibes, out birst);
                    tekrarcek = tekrarcekilecek;
                }
                catch (Exception ex)
                {
                    if (tekrarcek < tekrarcekilecek)
                    {
                        tekrarcek++;
                        System.Threading.Thread.Sleep(3000);
                    }
                    else
                    {
                        cmdLog.Parameters.AddWithValue("@strLog", ex.Message);
                        conn.Open(); cmdLog.Parameters.AddWithValue("@dtBitis", DateTime.Now); cmdLog.ExecuteNonQuery(); conn.Close();
                        return;
                    }
                }
            }

            cmdLog.Parameters.AddWithValue("@strLog", listMaterials.Length.ToString() + " Satır");

            if (malzeme)
            {
                SqlCommand cmd1 = new SqlCommand("DELETE FROM [Web_Malzeme] DELETE FROM [Web_Malzeme_Stock]", conn);
                cmd1.CommandTimeout = 1000;
                conn.Open();
                cmd1.ExecuteNonQuery();
                conn.Close();

                for (int i = 0; i < birst.Length; i++)
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO [Web_Malzeme_Stock] (Charg,Clabs,Lgort,Matnr,Meins,Werks) VALUES (@Charg,@Clabs,@Lgort,@Matnr,@Meins,@Werks)", conn);
                    cmd.CommandTimeout = 1000;
                    cmd.Parameters.AddWithValue("@Charg", birst[i].Charg);
                    cmd.Parameters.AddWithValue("@Clabs", birst[i].Clabs);
                    cmd.Parameters.AddWithValue("@Lgort", birst[i].Lgort);
                    try { cmd.Parameters.AddWithValue("@Matnr", Convert.ToInt32(birst[i].Matnr.Substring(11))); }
                    catch { cmd.Parameters.AddWithValue("@Matnr", 0); }
                    cmd.Parameters.AddWithValue("@Meins", birst[i].Meins);
                    cmd.Parameters.AddWithValue("@Werks", birst[i].Werks);
                    conn.Open();
                    try { cmd.ExecuteNonQuery(); }
                    catch (Exception ex) { Hatalar.DoInsert(ex, "windows servis SAP malzemeler stock"); }
                    conn.Close();
                }

                for (int i = 0; i < listMaterials.Length; i++)
                {
                    string ap = listMaterials[i].Vmsta;
                    int itemref = 0; try { itemref = Convert.ToInt32(listMaterials[i].Matnr.Substring(11)); }
                    catch { }
                    string malkod = listMaterials[i].Bismt;
                    string malacik = listMaterials[i].Zzumetin == string.Empty ? listMaterials[i].Maktx : listMaterials[i].Zzumetin;
                    string eskod = string.Empty; try { eskod = listMaterials[i].Zzyedurnum.Substring(11); }
                    catch { }
                    string birimref = listMaterials[i].Meins;
                    string birim = listMaterials[i].Pakad.ToString("N0");
                    string grupkod = listMaterials[i].Spart == "T1" || listMaterials[i].Spart == "T3" || listMaterials[i].Spart == "T4" ? "STG-1" : listMaterials[i].Spart == "T2" ? "STG-2" : listMaterials[i].Spart == "S1" ? "AL-SAT" : "DİĞER";
                    string grupacik = listMaterials[i].Spart == "T1" || listMaterials[i].Spart == "T3" || listMaterials[i].Spart == "T4" ? "AHT" : listMaterials[i].Spart == "T2" ? "YEG" : listMaterials[i].Spart == "S1" ? "AL-SAT GRUBU" : "DİĞER";
                    string ozelkod = listMaterials[i].Spart.StartsWith("T") ? listMaterials[i].Spart : listMaterials[i].Matkl;
                    string hk = listMaterials[i].Spart.StartsWith("T") ? (listMaterials[i].Spart == "T1" ? "T" : listMaterials[i].Spart == "T2" ? "Y" : listMaterials[i].Spart == "T3" ? "H" : listMaterials[i].Spart == "T4" ? "A" : "D") : listMaterials[i].Wgbez.Length > 0 ? listMaterials[i].Wgbez[0].ToString() : "";
                    string ozelacik = listMaterials[i].Spart.StartsWith("T") ? (listMaterials[i].Spart == "T1" ? "TİBET" : listMaterials[i].Spart == "T2" ? "YEG" : listMaterials[i].Spart == "T3" ? "HAYAT" : listMaterials[i].Spart == "T4" ? "ARI" : "DİĞER") : listMaterials[i].Wgbez;
                    string reykod = listMaterials[i].Extwg != string.Empty ? listMaterials[i].Extwg : "T";
                    string rk = listMaterials[i].Ewbez.Length > 0 ? listMaterials[i].Ewbez[0].ToString() : "T";
                    string reyacik = listMaterials[i].Ewbez != string.Empty ? listMaterials[i].Ewbez : "TİBET DİĞER";
                    double kdv = 0; try { kdv = Convert.ToDouble(listMaterials[i].Kbetr); }
                    catch { }
                    double koli = 0; try { koli = Convert.ToDouble(listMaterials[i].Kolad); }
                    catch { }
                    string barkod = listMaterials[i].Ean11;
                    double stok = 0; try { stok = Convert.ToDouble(listMaterials[i].Menge); }
                    catch { }
                    int kytm = 0; try { kytm = Convert.ToInt32((DateTime.Now - Convert.ToDateTime(listMaterials[i].Ersda)).TotalDays); }
                    catch { }
                    int kanal = 0; try { kanal = Convert.ToInt32(listMaterials[i].Zzmkanal); }
                    catch { }
                    int primt = 0; try { primt = Convert.ToInt32(listMaterials[i].Zzpirgt); }
                    catch { }
                    int primb = 0; try { primb = Convert.ToInt32(listMaterials[i].Zzpirbz); }
                    catch { }
                    string hyrs = listMaterials[i].Prdha;
                    string hyrstanim = listMaterials[i].Vtext;
                    int donusum = listMaterials[i].Zzmaldonusumno != string.Empty ? Convert.ToInt32(listMaterials[i].Zzmaldonusumno) : itemref;
                    int mhdhb = 0; try { mhdhb = Convert.ToInt32(listMaterials[i].Mhdhb); }
                    catch { }
                    int mhdrz = 0; try { mhdrz = Convert.ToInt32(listMaterials[i].Mhdrz); }
                    catch { }
                    string frm = listMaterials[i].Vkorg;

                    SqlCommand cmd = new SqlCommand("INSERT INTO [Web_Malzeme] " +
                        "([AP],[ITEMREF],[MAL KOD],[MAL ACIK],[URT KOD],[ES KOD],[BIRIMREF],[BIRIM],[GRUP KOD],[GRUP ACIK],[OZEL KOD],[HK],[OZEL ACIK],[REY KOD],[RK],[REY ACIK],[KDV],KOLI,BARKOD,STOK,[KYTM],KANAL,PRIMT,PRIMB,HYRS,HYRS_TANIM,DONUSUM,MHDHB,MHDRZ,FRM)" +
                        "VALUES (@AP,@ITEMREF,@MALKOD,@MALACIK,@URTKOD,@ESKOD,@BIRIMREF,@BIRIM,@GRUPKOD,@GRUPACIK,@OZELKOD,@HK,@OZELACIK,@REYKOD,@RK,@REYACIK,@KDV,@KOLI,@BARKOD,@STOK,@KYTM,@KANAL,@PRIMT,@PRIMB,@HYRS,@HYRS_TANIM,@DONUSUM,@MHDHB,@MHDRZ,@FRM)", conn);
                    cmd.CommandTimeout = 1000;
                    cmd.Parameters.AddWithValue("@AP", Convert.ToInt32(ap == string.Empty || ap == "A" ? "0" : "1"));
                    cmd.Parameters.AddWithValue("@ITEMREF", itemref);
                    cmd.Parameters.AddWithValue("@MALKOD", malkod);
                    cmd.Parameters.AddWithValue("@MALACIK", malacik.Trim().Replace("     ", " ").Replace("    ", " ").Replace("   ", " ").Replace("  ", " ").Trim());
                    cmd.Parameters.AddWithValue("@URTKOD", itemref);
                    cmd.Parameters.AddWithValue("@ESKOD", eskod == string.Empty ? itemref.ToString() : eskod);
                    cmd.Parameters.AddWithValue("@BIRIMREF", birimref);
                    cmd.Parameters.AddWithValue("@BIRIM", birim);
                    cmd.Parameters.AddWithValue("@GRUPKOD", grupkod);
                    cmd.Parameters.AddWithValue("@GRUPACIK", grupacik);
                    cmd.Parameters.AddWithValue("@OZELKOD", ozelkod);
                    cmd.Parameters.AddWithValue("@HK", hk);
                    cmd.Parameters.AddWithValue("@OZELACIK", ozelacik);
                    cmd.Parameters.AddWithValue("@REYKOD", ozelkod);
                    cmd.Parameters.AddWithValue("@RK", rk);
                    cmd.Parameters.AddWithValue("@REYACIK", reyacik);
                    cmd.Parameters.AddWithValue("@KDV", kdv);
                    cmd.Parameters.AddWithValue("@KOLI", koli);
                    cmd.Parameters.AddWithValue("@BARKOD", barkod);
                    cmd.Parameters.AddWithValue("@STOK", stok);
                    cmd.Parameters.AddWithValue("@KYTM", kytm);
                    cmd.Parameters.AddWithValue("@KANAL", kanal);
                    cmd.Parameters.AddWithValue("@PRIMT", primt);
                    cmd.Parameters.AddWithValue("@PRIMB", primb);
                    cmd.Parameters.AddWithValue("@HYRS", hyrs);
                    cmd.Parameters.AddWithValue("@HYRS_TANIM", hyrstanim);
                    cmd.Parameters.AddWithValue("@DONUSUM", donusum);
                    cmd.Parameters.AddWithValue("@MHDHB", mhdhb);
                    cmd.Parameters.AddWithValue("@MHDRZ", mhdrz);
                    cmd.Parameters.AddWithValue("@FRM", frm);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Hatalar.DoInsert(ex, "windows servis SAP malzemeler");
                    }
                    finally
                    {
                        conn.Close();
                    }
                }

                /*SqlCommand cmd12 = new SqlCommand("DROP TABLE [Web-Malzeme-Full-Onceki] SELECT * INTO [Web-Malzeme-Full-Onceki] FROM [dbo].[Web-Malzeme-Full] DROP TABLE [Web-Malzeme-Onceki] SELECT * INTO [Web-Malzeme-Onceki] FROM [dbo].[Web-Malzeme]", conn);
                cmd12.CommandTimeout = 600;
                conn.Open();
                cmd12.ExecuteNonQuery();
                conn.Close();*/

                SqlCommand cmd2 = new SqlCommand(@"BEGIN TRANSACTION t_Transaction 

TRUNCATE TABLE [Web-Malzeme-Full] 
INSERT INTO [Web-Malzeme-Full] SELECT * FROM [Web_Malzeme] WITH (HOLDLOCK) WHERE FRM = 'TB80'
INSERT INTO [Web-Malzeme-Full] 
SELECT min([AP]),[ITEMREF],[MAL KOD],[MAL ACIK],[URT KOD],[ES KOD],[BIRIMREF],[BIRIM],[GRUP KOD],[GRUP ACIK],[OZEL KOD],[HK],[OZEL ACIK],[REY KOD],[RK],[REY ACIK],[KDV],[KOLI],[BARKOD],[STOK],[KYTM],[KANAL],[PRIMT],[PRIMB],[HYRS],[HYRS_TANIM],[DONUSUM],[MHDHB],[MHDRZ],[STOKE]
,min([FRM]) AS FRM FROM [dbo].[Web_Malzeme]  WITH (HOLDLOCK) WHERE FRM != 'TB80' AND ITEMREF NOT IN (SELECT ITEMREF FROM [Web-Malzeme-Full])
GROUP BY [ITEMREF],[MAL KOD],[MAL ACIK],[URT KOD],[ES KOD],[BIRIMREF],[BIRIM],[GRUP KOD],[GRUP ACIK],[OZEL KOD],[HK],[OZEL ACIK],[REY KOD],[RK],[REY ACIK],[KDV],[KOLI],[BARKOD],[STOK],[KYTM],[KANAL],[PRIMT],[PRIMB],[HYRS],[HYRS_TANIM],[DONUSUM],[MHDHB],[MHDRZ],[STOKE]

COMMIT TRANSACTION t_Transaction
", conn);
                cmd2.CommandTimeout = 1000;
                SqlCommand cmd3 = new SqlCommand("DELETE FROM [Web-GrupKodlar] INSERT INTO [Web-GrupKodlar] SELECT DISTINCT [GRUP KOD],[GRUP ACIK] FROM [Web_Malzeme]   DELETE FROM [Web-OzelKodlar] INSERT INTO [Web-OzelKodlar] SELECT DISTINCT [OZEL KOD],[HK],[OZEL ACIK],[GRUP KOD] FROM [Web_Malzeme]   DELETE FROM [Web-Kategoriler] INSERT INTO [Web-Kategoriler] SELECT DISTINCT [REY KOD] AS CODE,[RK],[REY ACIK] AS NAME FROM [Web_Malzeme]", conn);
                cmd3.CommandTimeout = 1000;

                //SqlCommand cmd5 = new SqlCommand("INSERT INTO [Web-Malzeme-AP] SELECT ITEMREF,AP FROM [Web-Malzeme-Full] WHERE ITEMREF NOT IN (SELECT ITEMREF FROM [Web-Malzeme-AP])", conn);
                //cmd5.CommandTimeout = 1000;
                //SqlCommand cmd6 = new SqlCommand("UPDATE [Web-Malzeme-Full] SET [AP] = [Web-Malzeme-AP].AP FROM [Web-Malzeme-Full] INNER JOIN [Web-Malzeme-AP] ON [Web-Malzeme-Full].ITEMREF = [Web-Malzeme-AP].ITEMREF", conn);
                //cmd6.CommandTimeout = 1000;

                SqlCommand cmd4 = new SqlCommand("BEGIN TRANSACTION t_Transaction TRUNCATE TABLE [Web-Malzeme] INSERT INTO [Web-Malzeme] ([ITEMREF],[MAL KOD],[MAL ACIK],[URT KOD],[ES KOD],[BIRIMREF],[BIRIM],[GRUP KOD],[GRUP ACIK],[OZEL KOD],[HK],[OZEL ACIK],[REY KOD],[RK],[REY ACIK],[KDV],[KOLI],[BARKOD],[STOK],[KYTM],KANAL,PRIMT,PRIMB,HYRS,HYRS_TANIM,DONUSUM,MHDHB,MHDRZ,FRM) SELECT [ITEMREF],[MAL KOD],[MAL ACIK],[URT KOD],[ES KOD],[BIRIMREF],[BIRIM],[GRUP KOD],[GRUP ACIK],[OZEL KOD],[HK],[OZEL ACIK],[REY KOD],[RK],[REY ACIK],[KDV],[KOLI],[BARKOD],[STOK],[KYTM],KANAL,PRIMT,PRIMB,HYRS,HYRS_TANIM,DONUSUM,MHDHB,MHDRZ,FRM FROM [Web-Malzeme-Full] WITH (HOLDLOCK) WHERE AP = 0 AND FRM = 'TB80' COMMIT TRANSACTION t_Transaction", conn);
                cmd4.CommandTimeout = 1000;

                SqlCommand cmd7 = new SqlCommand("UPDATE [Web-Malzeme] SET [REY KOD] = (SELECT [OZEL KOD] FROM [Web-Malzeme-DOK] WHERE ITEMREF = [Web-Malzeme].ITEMREF) WHERE ITEMREF IN (SELECT ITEMREF FROM [Web-Malzeme-DOK])", conn);
                //SqlCommand cmd7 = new SqlCommand("UPDATE [Web-Malzeme] SET [OZEL KOD] = (SELECT [OZEL KOD] FROM [Web-Malzeme-DOK] WHERE ITEMREF = [Web-Malzeme].ITEMREF),[GRUP KOD] = 'STG-1',[GRUP ACIK] = 'AHT',HK = CASE WHEN (SELECT [OZEL KOD] FROM [Web-Malzeme-DOK] WHERE ITEMREF = [Web-Malzeme].ITEMREF) = 'T3' THEN 'H' ELSE 'T' END,[OZEL ACIK] = CASE WHEN (SELECT [OZEL KOD] FROM [Web-Malzeme-DOK] WHERE ITEMREF = [Web-Malzeme].ITEMREF) = 'T3' THEN 'HAYAT' ELSE 'TİBET' END WHERE ITEMREF IN (SELECT ITEMREF FROM [Web-Malzeme-DOK])", conn);
                cmd7.CommandTimeout = 1000;

                SqlCommand cmd8 = new SqlCommand("UPDATE [Web-Malzeme-Full] SET [REY KOD] = (SELECT [OZEL KOD] FROM [Web-Malzeme-DOK] WHERE ITEMREF = [Web-Malzeme-Full].ITEMREF) WHERE ITEMREF IN (SELECT ITEMREF FROM [Web-Malzeme-DOK])", conn);
                //SqlCommand cmd8 = new SqlCommand("UPDATE [Web-Malzeme-Full] SET [OZEL KOD] = (SELECT [OZEL KOD] FROM [Web-Malzeme-DOK] WHERE ITEMREF = [Web-Malzeme-Full].ITEMREF),[GRUP KOD] = 'STG-1',[GRUP ACIK] = 'AHT',HK = CASE WHEN (SELECT [OZEL KOD] FROM [Web-Malzeme-DOK] WHERE ITEMREF = [Web-Malzeme-Full].ITEMREF) = 'T3' THEN 'H' ELSE 'T' END,[OZEL ACIK] = CASE WHEN (SELECT [OZEL KOD] FROM [Web-Malzeme-DOK] WHERE ITEMREF = [Web-Malzeme-Full].ITEMREF) = 'T3' THEN 'HAYAT' ELSE 'TİBET' END WHERE ITEMREF IN (SELECT ITEMREF FROM [Web-Malzeme-DOK])", conn);
                cmd8.CommandTimeout = 1000;

                SqlCommand cmd9 = new SqlCommand("UPDATE [Web-Fiyat] SET [REY KOD] = (SELECT [OZEL KOD] FROM [Web-Malzeme-DOK] WHERE ITEMREF = [Web-Fiyat].ITEMREF) WHERE ITEMREF IN (SELECT ITEMREF FROM [Web-Malzeme-DOK])", conn);
                //SqlCommand cmd9 = new SqlCommand("UPDATE [Web-Fiyat] SET [OZEL KOD] = (SELECT [OZEL KOD] FROM [Web-Malzeme-DOK] WHERE ITEMREF = [Web-Fiyat].ITEMREF),[GRUP KOD] = 'STG-1',HK = CASE WHEN (SELECT [OZEL KOD] FROM [Web-Malzeme-DOK] WHERE ITEMREF = [Web-Fiyat].ITEMREF) = 'T3' THEN 'H' ELSE 'T' END,[OZEL ACIK] = CASE WHEN (SELECT [OZEL KOD] FROM [Web-Malzeme-DOK] WHERE ITEMREF = [Web-Fiyat].ITEMREF) = 'T3' THEN 'HAYAT' ELSE 'TİBET' END WHERE ITEMREF IN (SELECT ITEMREF FROM [Web-Malzeme-DOK])", conn);
                cmd9.CommandTimeout = 1000;

                SqlCommand cmd10 = new SqlCommand("UPDATE [Web-Fiyat-Full] SET [REY KOD] = (SELECT [OZEL KOD] FROM [Web-Malzeme-DOK] WHERE ITEMREF = [Web-Fiyat-Full].ITEMREF) WHERE ITEMREF IN (SELECT ITEMREF FROM [Web-Malzeme-DOK])", conn);
                //SqlCommand cmd10 = new SqlCommand("UPDATE [Web-Fiyat-Full] SET [OZEL KOD] = (SELECT [OZEL KOD] FROM [Web-Malzeme-DOK] WHERE ITEMREF = [Web-Fiyat-Full].ITEMREF),[GRUP KOD] = 'STG-1',HK = CASE WHEN (SELECT [OZEL KOD] FROM [Web-Malzeme-DOK] WHERE ITEMREF = [Web-Fiyat-Full].ITEMREF) = 'T3' THEN 'H' ELSE 'T' END,[OZEL ACIK] = CASE WHEN (SELECT [OZEL KOD] FROM [Web-Malzeme-DOK] WHERE ITEMREF = [Web-Fiyat-Full].ITEMREF) = 'T3' THEN 'HAYAT' ELSE 'TİBET' END WHERE ITEMREF IN (SELECT ITEMREF FROM [Web-Malzeme-DOK])", conn);
                cmd10.CommandTimeout = 1000;

                SqlCommand cmd11 = new SqlCommand("UPDATE [Web-Malzeme] SET STOKE = (SELECT sum([Clabs]) FROM [Web_Malzeme_Stock] WHERE Matnr = [Web-Malzeme].ITEMREF) FROM [Web-Malzeme] UPDATE [Web-Malzeme-Full] SET STOKE = (SELECT sum([Clabs]) FROM [Web_Malzeme_Stock] WHERE Matnr = [Web-Malzeme-Full].ITEMREF) FROM [Web-Malzeme-Full]", conn);
                cmd11.CommandTimeout = 1000;

                conn.Open();
                cmd2.ExecuteNonQuery();
                cmd3.ExecuteNonQuery();
                //cmd5.ExecuteNonQuery();
                //cmd6.ExecuteNonQuery();
                cmd4.ExecuteNonQuery();
                cmd7.ExecuteNonQuery();
                cmd8.ExecuteNonQuery();
                cmd9.ExecuteNonQuery();
                cmd10.ExecuteNonQuery();
                cmd11.ExecuteNonQuery();
                conn.Close();



                conn.Open(); cmdLog.Parameters.AddWithValue("@dtBitis", DateTime.Now); cmdLog.ExecuteNonQuery(); conn.Close();
            }



            gett179tC.ZwebGetT179tService t179t = new gett179tC.ZwebGetT179tService();
            t179t.Timeout = 6000000;
            t179t.Credentials = nc1;
            gett179tC.Zwebt179t[] t179 = t179t.ZwebGetT179t();
            SqlCommand cmdDelT179T = new SqlCommand("DELETE FROM [Web-Malzeme-Hiyerarsi]", conn);
            conn.Open(); cmdDelT179T.ExecuteNonQuery(); conn.Close();

            conn.Open();
            for (int i = 0; i < t179.Length; i++)
            {
                SqlCommand cmdT179T = new SqlCommand("INSERT INTO [Web-Malzeme-Hiyerarsi] ([KOD],[METIN]) VALUES (@KOD,@METIN)", conn);
                cmdT179T.Parameters.Add("@KOD", SqlDbType.VarChar, 18).Value = t179[i].Prodh;
                cmdT179T.Parameters.Add("@METIN", SqlDbType.NVarChar, 50).Value = t179[i].Vtext;
                cmdT179T.ExecuteNonQuery();
            }
            conn.Close();



            if (olcubirim)
            {
                conn.Open();
                SqlCommand cmdSilOlcuBirim = new SqlCommand("DELETE FROM [SAP_OLCUBIRIM_]", conn);
                cmdSilOlcuBirim.ExecuteNonQuery();

                for (int i = 0; i < yirmibes.Length; i++)
                {
                    string Matnr = yirmibes[i].Matnr;
                    string Meinh = yirmibes[i].Meinh;
                    double Umrez = Convert.ToDouble(yirmibes[i].Umrez);
                    double Umren = Convert.ToDouble(yirmibes[i].Umren);
                    string Eannr = yirmibes[i].Eannr;
                    string Ean11 = yirmibes[i].Ean11;
                    string Numtp = yirmibes[i].Numtp;
                    double Laeng = Convert.ToDouble(yirmibes[i].Laeng);
                    double Breit = Convert.ToDouble(yirmibes[i].Breit);
                    double Hoehe = Convert.ToDouble(yirmibes[i].Hoehe);
                    string Meabm = yirmibes[i].Meabm;
                    double Volum = Convert.ToDouble(yirmibes[i].Volum);
                    string Voleh = yirmibes[i].Voleh;
                    double Brgew = Convert.ToDouble(yirmibes[i].Brgew);
                    string Gewei = yirmibes[i].Gewei;
                    string Mesub = yirmibes[i].Mesub;
                    string Atinn = yirmibes[i].Atinn;
                    string Mesrt = yirmibes[i].Mesrt;
                    string Xfhdw = yirmibes[i].Xfhdw;
                    string Xbeww = yirmibes[i].Xbeww;
                    string Kzwso = yirmibes[i].Kzwso;
                    string Msehi = yirmibes[i].Msehi;
                    string BflmeMarm = yirmibes[i].BflmeMarm;
                    string GtinVariant = yirmibes[i].GtinVariant;
                    double NestFtr = Convert.ToDouble(yirmibes[i].NestFtr);
                    byte MaxStack = Convert.ToByte(yirmibes[i].MaxStack);
                    double Capause = Convert.ToDouble(yirmibes[i].Capause);
                    string Ty2tq = yirmibes[i].Ty2tq;

                    SqlCommand cmdOlcuBirim = new SqlCommand("INSERT INTO [SAP_OLCUBIRIM_] " +
                        "([Matnr],[Meinh],[Umrez],[Umren],[Eannr],[Ean11],[Numtp],[Laeng],[Breit],[Hoehe],[Meabm],[Volum],[Voleh],[Brgew],[Gewei],[Mesub],[Atinn],[Mesrt],[Xfhdw],[Xbeww],[Kzwso],[Msehi],[BflmeMarm],[GtinVariant],[NestFtr],[MaxStack],[Capause],[Ty2tq]) " +
                        "VALUES (@Matnr,@Meinh,@Umrez,@Umren,@Eannr,@Ean11,@Numtp,@Laeng,@Breit,@Hoehe,@Meabm,@Volum,@Voleh,@Brgew,@Gewei,@Mesub,@Atinn,@Mesrt,@Xfhdw,@Xbeww,@Kzwso,@Msehi,@BflmeMarm,@GtinVariant,@NestFtr,@MaxStack,@Capause,@Ty2tq)", conn);
                    cmdOlcuBirim.CommandTimeout = 1000;
                    cmdOlcuBirim.Parameters.AddWithValue("@Matnr", Matnr);
                    cmdOlcuBirim.Parameters.AddWithValue("@Meinh", Meinh);
                    cmdOlcuBirim.Parameters.AddWithValue("@Umrez", Umrez);
                    cmdOlcuBirim.Parameters.AddWithValue("@Umren", Umren);
                    cmdOlcuBirim.Parameters.AddWithValue("@Eannr", Eannr);
                    cmdOlcuBirim.Parameters.AddWithValue("@Ean11", Ean11);
                    cmdOlcuBirim.Parameters.AddWithValue("@Numtp", Numtp);
                    cmdOlcuBirim.Parameters.AddWithValue("@Laeng", Laeng);
                    cmdOlcuBirim.Parameters.AddWithValue("@Breit", Breit);
                    cmdOlcuBirim.Parameters.AddWithValue("@Hoehe", Hoehe);
                    cmdOlcuBirim.Parameters.AddWithValue("@Meabm", Meabm);
                    cmdOlcuBirim.Parameters.AddWithValue("@Volum", Volum);
                    cmdOlcuBirim.Parameters.AddWithValue("@Voleh", Voleh);
                    cmdOlcuBirim.Parameters.AddWithValue("@Brgew", Brgew);
                    cmdOlcuBirim.Parameters.AddWithValue("@Gewei", Gewei);
                    cmdOlcuBirim.Parameters.AddWithValue("@Mesub", Mesub);
                    cmdOlcuBirim.Parameters.AddWithValue("@Atinn", Atinn);
                    cmdOlcuBirim.Parameters.AddWithValue("@Mesrt", Mesrt);
                    cmdOlcuBirim.Parameters.AddWithValue("@Xfhdw", Xfhdw);
                    cmdOlcuBirim.Parameters.AddWithValue("@Xbeww", Xbeww);
                    cmdOlcuBirim.Parameters.AddWithValue("@Kzwso", Kzwso);
                    cmdOlcuBirim.Parameters.AddWithValue("@Msehi", Msehi);
                    cmdOlcuBirim.Parameters.AddWithValue("@BflmeMarm", BflmeMarm);
                    cmdOlcuBirim.Parameters.AddWithValue("@GtinVariant", GtinVariant);
                    cmdOlcuBirim.Parameters.AddWithValue("@NestFtr", NestFtr);
                    cmdOlcuBirim.Parameters.AddWithValue("@MaxStack", MaxStack);
                    cmdOlcuBirim.Parameters.AddWithValue("@Capause", Capause);
                    cmdOlcuBirim.Parameters.AddWithValue("@Ty2tq", Ty2tq);

                    try
                    {
                        cmdOlcuBirim.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        conn.Close();
                        Hatalar.DoInsert(ex, "windows servis SAP malzemeler olcubirim");
                        conn.Open();
                    }
                }

                SqlCommand cmdOlcuG = new SqlCommand("BEGIN TRANSACTION t_Transaction TRUNCATE TABLE [SAP_OLCUBIRIM] INSERT INTO [SAP_OLCUBIRIM] ([Matnr],[Meinh],[Umrez],[Umren],[Eannr],[Ean11],[Numtp],[Laeng],[Breit],[Hoehe],[Meabm],[Volum],[Voleh],[Brgew],[Gewei],[Mesub],[Atinn],[Mesrt],[Xfhdw],[Xbeww],[Kzwso],[Msehi],[BflmeMarm],[GtinVariant],[NestFtr],[MaxStack],[Capause],[Ty2tq]) SELECT DISTINCT [Matnr],[Meinh],[Umrez],[Umren],[Eannr],[Ean11],[Numtp],[Laeng],[Breit],[Hoehe],[Meabm],[Volum],[Voleh],[Brgew],[Gewei],[Mesub],[Atinn],[Mesrt],[Xfhdw],[Xbeww],[Kzwso],[Msehi],[BflmeMarm],[GtinVariant],[NestFtr],[MaxStack],[Capause],[Ty2tq] FROM [SAP_OLCUBIRIM_] WITH (HOLDLOCK) COMMIT TRANSACTION t_Transaction", conn);
                cmdOlcuG.CommandTimeout = 1000;
                try
                {
                    cmdOlcuG.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Hatalar.DoInsert(ex, "windows servis SAP malzemeler olcubirimG");
                }

                conn.Close();
            }
        }
        #endregion

        #region PersonellerC
        private void PersonellerC()
        {
            SqlConnection conn = new SqlConnection(General.ConnectionString);

            SqlCommand cmdLog = new SqlCommand("INSERT INTO [KurumsalWebSAP].[dbo].[tblINTERNET_LogTabloGuncellemeler] ([dtBaslangic],[dtBitis],[strYer],[strLog]) VALUES (@dtBaslangic,@dtBitis,@strYer,@strLog)", conn);
            cmdLog.Parameters.AddWithValue("@dtBaslangic", DateTime.Now); cmdLog.Parameters.AddWithValue("@strYer", "SAP Personeller");



            getpersonalsC.ZwebGetPersonalsService clPersonals = new getpersonalsC.ZwebGetPersonalsService();
            clPersonals.Timeout = 6000000;
            clPersonals.Credentials = nc1;
            getpersonalsC.Zwebt003[] listPersonals = null;

            int tekrarcek = 0;
            while (tekrarcek < tekrarcekilecek)
            {
                try
                {
                    listPersonals = clPersonals.ZwebGetPersonals();
                    tekrarcek = tekrarcekilecek;
                }
                catch (Exception ex)
                {
                    if (tekrarcek < tekrarcekilecek)
                    {
                        tekrarcek++;
                        System.Threading.Thread.Sleep(3000);
                    }
                    else
                    {
                        cmdLog.Parameters.AddWithValue("@strLog", ex.Message);
                        conn.Open(); cmdLog.Parameters.AddWithValue("@dtBitis", DateTime.Now); cmdLog.ExecuteNonQuery(); conn.Close();
                        return;
                    }
                }
            }

            cmdLog.Parameters.AddWithValue("@strLog", listPersonals.Length.ToString() + " Satır");

            SqlCommand cmd1 = new SqlCommand("DELETE FROM [Web-SatisTemsilcileri]", conn);
            cmd1.CommandTimeout = 1000;
            conn.Open();
            cmd1.ExecuteNonQuery();
            conn.Close();

            for (int i = 0; i < listPersonals.Length; i++)
            {
                int slsmanref = 0; try { slsmanref = Convert.ToInt32(listPersonals[i].Pernr); }
                catch { }
                string sattem = listPersonals[i].Vorna + " " + listPersonals[i].Nachn;

                SqlCommand cmd = new SqlCommand("INSERT INTO [Web-SatisTemsilcileri] " +
                    "([ACTIVE],[SLSMANREF],[SAT TEM])" +
                    "VALUES (0,@SLSMANREF,@SATTEM)", conn);
                cmd.CommandTimeout = 1000;
                cmd.Parameters.AddWithValue("@SLSMANREF", slsmanref);
                cmd.Parameters.AddWithValue("@SATTEM", sattem);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Hatalar.DoInsert(ex, "windows servis SAP personeller");
                }
                finally
                {
                    conn.Close();
                }
            }

            SqlCommand cmd2 = new SqlCommand("UPDATE [Web-SatisTemsilcileri] SET [SAT KOD1] = (SELECT TOP 1 [SAT KOD1] FROM [Web-Musteri] WHERE SLSREF = [Web-SatisTemsilcileri].SLSMANREF ORDER BY [SAT KOD1])", conn);
            cmd2.CommandTimeout = 1000;
            conn.Open();
            cmd2.ExecuteNonQuery();
            conn.Close();

            //SqlCommand cmd3 = new SqlCommand("DELETE FROM [Web-SatisTemsilcileri] WHERE [SAT KOD1] IS NULL", conn);
            //cmd3.CommandTimeout = 1000;
            //conn.Open();
            //cmd3.ExecuteNonQuery();
            //conn.Close();



            conn.Open(); cmdLog.Parameters.AddWithValue("@dtBitis", DateTime.Now); cmdLog.ExecuteNonQuery(); conn.Close();
        }
        #endregion

        #region MusterilerC
        private void MusterilerC()
        {
            SqlConnection conn = new SqlConnection(General.ConnectionString);

            SqlCommand cmdLog = new SqlCommand("INSERT INTO [KurumsalWebSAP].[dbo].[tblINTERNET_LogTabloGuncellemeler] ([dtBaslangic],[dtBitis],[strYer],[strLog]) VALUES (@dtBaslangic,@dtBitis,@strYer,@strLog)", conn);
            cmdLog.Parameters.AddWithValue("@dtBaslangic", DateTime.Now);

            SqlCommand cmd11 = new SqlCommand("SELECT count(*) FROM [Web-Musteri]", conn);
            conn.Open();
            int oncekimusterisayisi = Convert.ToInt32(cmd11.ExecuteScalar());
            conn.Close();

            getcustomersC.ZwebGetCustomersService clCustomers = new getcustomersC.ZwebGetCustomersService();
            clCustomers.Timeout = 6000000;
            clCustomers.Credentials = nc1;
            getcustomersC.Zwebt002[] listCustomers = null;

            int tekrarcek = 0;
            while (tekrarcek < tekrarcekilecek)
            {
                try
                {
                    listCustomers = clCustomers.ZwebGetCustomers();
                    tekrarcek = tekrarcekilecek;
                }
                catch (Exception ex)
                {
                    if (tekrarcek < tekrarcekilecek)
                    {
                        tekrarcek++;
                        System.Threading.Thread.Sleep(3000);
                    }
                    else
                    {
                        cmdLog.Parameters.AddWithValue("@strLog", ex.Message);
                        conn.Open(); cmdLog.Parameters.AddWithValue("@dtBitis", DateTime.Now); cmdLog.ExecuteNonQuery(); conn.Close();
                        return;
                    }
                }
            }


            if (oncekimusterisayisi - 2000 < listCustomers.Length)
            {
                SqlCommand cmd1 = new SqlCommand("DELETE FROM [Web_Musteri] DELETE FROM [Web-Risk]", conn);
                cmd1.CommandTimeout = 600;
                conn.Open();
                cmd1.ExecuteNonQuery();
                conn.Close();

                for (int i = 0; i < listCustomers.Length; i++)
                {
                    string active = listCustomers[i].Aufsd == string.Empty ? "0" : "1";
                    string bolgekod = listCustomers[i].Bzirk;
                    string bolge = listCustomers[i].Bztxt;
                    string ytkkod = listCustomers[i].Kdgrp;
                    string ilkod = listCustomers[i].Regio;
                    string il = listCustomers[i].Bezei;
                    string ilcekod = listCustomers[i].PostCode1;
                    string ilce = listCustomers[i].City1;
                    string mtkod = listCustomers[i].Kdgrp;
                    string mtaciklama = listCustomers[i].Kdgtx;
                    int slsref = 0; try { slsref = Convert.ToInt32(listCustomers[i].Pernr); }
                    catch { }
                    string satkod = Convert.ToInt32(listCustomers[i].Perno).ToString();
                    string satkod1 = listCustomers[i].Parvw;
                    int gmref = 0; try { gmref = Convert.ToInt32(listCustomers[i].Kunag); }
                    catch { }
                    string musteri = listCustomers[i].Namag;
                    int smref = 0; try { smref = Convert.ToInt32(listCustomers[i].Kunwe); }
                    catch { }
                    string sube = listCustomers[i].Namwe;
                    string adres = listCustomers[i].Adres;
                    string sehir = listCustomers[i].CommText;
                    string semt = listCustomers[i].Name3;
                    string vrgdaire = listCustomers[i].Stcd1;
                    string vrgno = listCustomers[i].Stcd2;
                    string tel = listCustomers[i].Telno;
                    string fax = listCustomers[i].Faxno;
                    string email = listCustomers[i].Email;
                    string cep = listCustomers[i].Mobno;
                    double risklimit = Convert.ToDouble(listCustomers[i].Klimk);
                    int muskod = 0; try { muskod = listCustomers[i].Altkn != string.Empty ? Convert.ToInt32(listCustomers[i].Altkn) : 0; }
                    catch { }

                    SqlCommand cmd = new SqlCommand("INSERT INTO [Web_Musteri] " +
                        "([ACTIVE],BOLGE,[YTK KOD],[IL KOD],[IL],[ILCE KOD],[ILCE],[MT KOD],[MT ACIKLAMA],[SLSREF],[SAT KOD],[SAT KOD1],[GMREF],[MUS KOD],[SAT TEM],[MUSTERI],[SMREF],[SUB KOD],[SUBE],[ADRES],[SEHIR],SEMT,[VRG DAIRE],[VRG NO],[TEL-1],[FAX-1],[EMAIL-1],ILGILI,[CEP-1],[NETTOP])" +
                        "VALUES (@ACTIVE,@BOLGE,@YTKKOD,@ILKOD,@IL,@ILCEKOD,@ILCE,@MTKOD,@MTACIKLAMA,@SLSREF,@SATKOD,@SATKOD1,@GMREF,@MUSKOD,@SATTEM,@MUSTERI,@SMREF,@SUBKOD,@SUBE,@ADRES,@SEHIR,@SEMT,@VRGDAIRE,@VRGNO,@TEL,@FAX,@EMAIL,@ILGILI,@CEP,0)", conn);
                    //cmd.CommandTimeout = 1000;
                    cmd.Parameters.AddWithValue("@ACTIVE", active);
                    cmd.Parameters.AddWithValue("@BOLGE", bolgekod);
                    cmd.Parameters.AddWithValue("@YTKKOD", ytkkod);
                    cmd.Parameters.AddWithValue("@ILKOD", ilkod);
                    cmd.Parameters.AddWithValue("@IL", il);
                    cmd.Parameters.AddWithValue("@ILCEKOD", ilcekod);
                    cmd.Parameters.AddWithValue("@ILCE", ilce);
                    cmd.Parameters.AddWithValue("@MTKOD", mtkod);
                    cmd.Parameters.AddWithValue("@MTACIKLAMA", mtaciklama);
                    cmd.Parameters.AddWithValue("@SLSREF", slsref);
                    cmd.Parameters.AddWithValue("@SATKOD", satkod);
                    cmd.Parameters.AddWithValue("@SATKOD1", satkod1);
                    cmd.Parameters.AddWithValue("@GMREF", gmref);
                    cmd.Parameters.AddWithValue("@MUSKOD", muskod);
                    cmd.Parameters.AddWithValue("@MUSTERI", musteri);
                    cmd.Parameters.AddWithValue("@SMREF", smref);
                    cmd.Parameters.AddWithValue("@SUBKOD", muskod);
                    cmd.Parameters.AddWithValue("@SUBE", sube);
                    cmd.Parameters.AddWithValue("@ADRES", adres);
                    cmd.Parameters.AddWithValue("@SEHIR", sehir);
                    cmd.Parameters.AddWithValue("@SEMT", semt);
                    cmd.Parameters.AddWithValue("@VRGDAIRE", vrgdaire);
                    cmd.Parameters.AddWithValue("@VRGNO", vrgno);
                    cmd.Parameters.AddWithValue("@TEL", tel);
                    cmd.Parameters.AddWithValue("@FAX", fax);
                    cmd.Parameters.AddWithValue("@EMAIL", email);
                    cmd.Parameters.AddWithValue("@ILGILI", bolge);
                    cmd.Parameters.AddWithValue("@CEP", cep);

                    SqlCommand cmd2 = new SqlCommand("SELECT count(GMREF) FROM [Web-Risk] WHERE GMREF = @GMREF", conn);
                    cmd2.Parameters.AddWithValue("@GMREF", gmref);

                    SqlCommand cmd3 = new SqlCommand("INSERT INTO [Web-Risk] ([SLSREF],[GMREF],[MUS KOD],[MUSTERI],[RISK LMT],[RISK TOP],[RISK BKY],[BAKIYE],[ACK GUN],[ACK TOP],[VB GUN],[VB TOP],[VGB GUN],[VGB TOP],[IRS TOP],[C/S TOP],[SIP TOPL],[SIP TOPLB],[SIP TOPQ]) VALUES (@SLSREF,@GMREF,@GMREF,@MUSTERI,@RISKLMT,0,@RISKBKY,0,0,0,0,0,0,0,0,0,0,0,0)", conn);
                    //cmd3.CommandTimeout = 1000;
                    cmd3.Parameters.AddWithValue("@SLSREF", slsref);
                    cmd3.Parameters.AddWithValue("@GMREF", gmref);
                    cmd3.Parameters.AddWithValue("@MUSTERI", musteri);
                    cmd3.Parameters.AddWithValue("@RISKLMT", risklimit);
                    cmd3.Parameters.AddWithValue("@RISKBKY", risklimit);

                    SqlCommand cmd4 = new SqlCommand("SELECT [SAT TEM] FROM [Web-SatisTemsilcileri] WHERE SLSMANREF = @SLSMANREF", conn);
                    cmd4.Parameters.AddWithValue("@SLSMANREF", slsref);

                    try
                    {
                        conn.Open();

                        string sattemgelen = string.Empty;
                        object obj = cmd4.ExecuteScalar();
                        if (obj != null)
                            sattemgelen = obj.ToString();
                        cmd.Parameters.AddWithValue("@SATTEM", sattemgelen);

                        cmd.ExecuteNonQuery();
                        if (!Convert.ToBoolean(cmd2.ExecuteScalar())) // risktablosunda yok ise
                        {
                            cmd3.ExecuteNonQuery();
                        }
                    }
                    catch (Exception ex)
                    {
                        Hatalar.DoInsert(ex, "windows servis SAP musteriler");
                    }
                    finally
                    {
                        conn.Close();
                    }
                }

                SqlCommand cmd10 = new SqlCommand("DROP TABLE [Web-Musteri-Onceki] SELECT * INTO [Web-Musteri-Onceki] FROM [dbo].[Web-Musteri]", conn);
                cmd10.CommandTimeout = 600;
                conn.Open();
                cmd10.ExecuteNonQuery();
                conn.Close();

                SqlCommand cmd5 = new SqlCommand("BEGIN TRANSACTION t_Transaction TRUNCATE TABLE [Web-Musteri] INSERT INTO [Web-Musteri] SELECT [ACTIVE],[BOLGE],[GRP],[EKP],[YTK KOD],[IL KOD],[IL],[ILCE KOD],[ILCE],[TIP],(SELECT DISTINCT [MT KOD] FROM [Web_Musteri] AS MUS WHERE GMREF = SMREF AND GMREF = [Web_Musteri].GMREF) AS [MT KOD],(SELECT DISTINCT [MT ACIKLAMA] FROM [Web_Musteri] AS MUS WHERE GMREF = SMREF AND GMREF = [Web_Musteri].GMREF) AS [MT ACIKLAMA],[UNVAN],[SLSREF],(SELECT DISTINCT [SAT KOD] FROM [Web_Musteri] AS MUS WHERE GMREF = SMREF AND GMREF = [Web_Musteri].GMREF) AS [SAT KOD],[SAT KOD1],[SAT TEM],[GMREF],[MUS KOD],[MUSTERI],[SMREF],[SUB KOD],[SUBE],[ADRES],[SEHIR],[SEMT],[VRG DAIRE],[VRG NO],[TEL-1],[FAX-1],[EMAIL-1],[ILGILI],[CEP-1],[NETTOP] FROM [Web_Musteri] WITH (HOLDLOCK) COMMIT TRANSACTION t_Transaction", conn);
                cmd5.CommandTimeout = 600;
                conn.Open();
                cmd5.ExecuteNonQuery();
                conn.Close();

                //üşengeçlik
                SqlCommand cmd6 = new SqlCommand("UPDATE [KurumsalWebSAP].[dbo].[Web-Musteri] SET [GRP] = '',[EKP] = '',[TIP] = 0,UNVAN=''", conn);
                conn.Open();
                cmd6.ExecuteNonQuery();
                conn.Close();

                try
                {
                    SqlCommand cmd7 = new SqlCommand("TRUNCATE TABLE [Web-Risk-2] INSERT INTO [Web-Risk-2] ([SLSREF],[GMREF],[MUS KOD],[MUSTERI],[RISK LMT],[RISK TOP],[RISK BKY],[BAKIYE],[ACK GUN],[ACK TOP],[VB GUN],[VB TOP],[VGB GUN],[VGB TOP],[IRS TOP],[C/S TOP],[SIP TOPL],[SIP TOPLB],[SIP TOPQ]) SELECT [SAT KOD],[MUS KOD],[MUS KOD],[MUSTERI],[RISK LMT],0,[RISK LMT],[BAKIYE],0,0,0,0,0,0,[BORC],0,[ALACAK],0,0 FROM [SAP_B_A_2017] WHERE [SAT KOD] IS NOT NULL", conn);
                    cmd7.CommandTimeout = 60;
                    SqlCommand cmd8 = new SqlCommand("UPDATE [Web-Risk] SET [RISK TOP] = SAP_B_A_2017.[RISK_TOP], [BAKIYE] = SAP_B_A_2017.[BAKIYE], [VGB GUN] = SAP_B_A_2017.[VGB_VD], [VGB TOP] = SAP_B_A_2017.[VGB], [C/S TOP] = SAP_B_A_2017.[CEK] + SAP_B_A_2017.[SNT] FROM [Web-Risk] INNER JOIN SAP_B_A_2017 ON [Web-Risk].GMREF = SAP_B_A_2017.[MUS KOD]", conn);
                    cmd8.CommandTimeout = 60;
                    conn.Open();
                    cmd7.ExecuteNonQuery();
                    cmd8.ExecuteNonQuery();
                    conn.Close();
                    cmdLog.Parameters.AddWithValue("@strYer", "SAP Musteriler");
                }
                catch (Exception ex)
                {
                    cmdLog.Parameters.AddWithValue("@strYer", "SAP Musteriler (web-risk-2 yazılamadı)");
                    Hatalar.DoInsert(ex, "windows servis SAP musteriler web-risk-2");
                }

                /*SqlCommand cmd8 = new SqlCommand("UPDATE [Web-Musteri] SET [Web-Musteri].BOLGE = ISNULL(SATRAP.BLG_KOD,''),[Web-Musteri].ILGILI = ISNULL(SATRAP.[BOLGE],'') FROM [Web-Musteri] LEFT OUTER JOIN (SELECT DISTINCT SMREF,BLG_KOD,[BOLGE] FROM [KurumsalWebSAP].[dbo].[Web-Satis-Rapor-1] WHERE YIL > YEAR(getdate()) - 4) AS SATRAP ON [Web-Musteri].SMREF = SATRAP.SMREF", conn);
                cmd8.CommandTimeout = 1000;
                conn.Open();
                cmd8.ExecuteNonQuery();
                conn.Close();*/

                cmdLog.Parameters.AddWithValue("@strLog", listCustomers.Length.ToString() + " Satır");

                WebRutJob();
            }
            else
            {
                cmdLog.Parameters.AddWithValue("@strYer", "SAP Musteriler");
                cmdLog.Parameters.AddWithValue("@strLog", listCustomers.Length.ToString() + " Satır" + " (Yazma yapılmadı)");
            }

            conn.Open(); cmdLog.Parameters.AddWithValue("@dtBitis", DateTime.Now); cmdLog.ExecuteNonQuery(); conn.Close();
        }
        #endregion

        private int GetFiyatTipiFromGMREF(int GMREF)
        {
            int donendeger = 0;

            DataTable dt = new DataTable();
            FiyatTipleri.GetObjects(dt, true);
            for (int i = 0; i < dt.Rows.Count; i++)
                if (dt.Rows[i]["GMREF"] != DBNull.Value && Convert.ToInt32(dt.Rows[i]["GMREF"]) == GMREF)
                    donendeger = Convert.ToInt32(dt.Rows[i]["NOSU"]);

            #region eskimethod

            /*switch (GMREF)
            {
                case 1000020:
                    donendeger = 501;
                    break;
                case 1000072:
                    donendeger = 502;
                    break;
                case 1000106:
                    donendeger = 503;
                    break;
                //case 1000158:
                //    donendeger = 504;
                //    break;
                case 1012916:
                    donendeger = 505;
                    break;
                case 1000239:
                    donendeger = 506;
                    break;
                case 1000254:
                    donendeger = 507;
                    break;
                case 1000352:
                    donendeger = 508;
                    break;
                case 1000368:
                    donendeger = 509;
                    break;
                case 1002747:
                    donendeger = 510;
                    break;
                case 1000460:
                    donendeger = 511;
                    break;
                case 1002166:
                    donendeger = 512;
                    break;
                case 1000599:
                    donendeger = 513;
                    break;
                case 1000680:
                    donendeger = 514;
                    break;
                case 1000694:
                    donendeger = 515;
                    break;
                case 1018373: //1000700
                    donendeger = 516;
                    break;
                case 1000740:
                    donendeger = 517;
                    break;
                case 1000742:
                    donendeger = 518;
                    break;
                case 1000787:
                    donendeger = 519;
                    break;
                case 1000788:
                    donendeger = 520;
                    break;
                case 1000867:
                    donendeger = 521;
                    break;
                case 1002967:
                    donendeger = 522;
                    break;
                case 1002969:
                    donendeger = 523;
                    break;
                case 1000922:
                    donendeger = 524;
                    break;
                case 1001365:
                    donendeger = 525;
                    break;
                case 1004078:
                    donendeger = 526;
                    break;
                case 1000996:
                    donendeger = 527;
                    break;
                case 1001012:
                    donendeger = 528;
                    break;
                case 1002656:
                    donendeger = 529;
                    break;
                case 1001089:
                    donendeger = 530;
                    break;
                case 1011602:
                    donendeger = 531;
                    break;
                case 1001152:
                    donendeger = 532;
                    break;
                case 1012117:
                    donendeger = 533;
                    break;
                case 1012435:
                    donendeger = 534;
                    break;
                case 1011410:
                    donendeger = 535;
                    break;
                case 1001226:
                    donendeger = 536;
                    break;
                case 1001253:
                    donendeger = 537;
                    break;
                case 1001281:
                    donendeger = 538;
                    break;
                case 1002745:
                    donendeger = 539;
                    break;
                case 1002637:
                    donendeger = 540;
                    break;
                case 1002012:
                    donendeger = 541;
                    break;
                case 1001408:
                    donendeger = 542;
                    break;
                case 1002902:
                    donendeger = 543;
                    break;
                case 1001511:
                    donendeger = 544;
                    break;
                case 1001912:
                    donendeger = 545;
                    break;
                case 1013695:
                    donendeger = 546;
                    break;
                //case 1001470:
                //    donendeger = 547;
                //    break;
                case 1004289:
                    donendeger = 548;
                    break;
                case 1000124:
                    donendeger = 549;
                    break;
                case 1001393:
                    donendeger = 550;
                    break;
                case 1001230: //
                    donendeger = 551;
                    break;
                case 1002909:
                    donendeger = 552;
                    break;
                case 1000421:
                    donendeger = 553;
                    break;
                //case 1001374:
                //    donendeger = 554;
                //    break;
                case 1011351:
                    donendeger = 555;
                    break;
                case 1009918:
                    donendeger = 556;
                    break;
                //case 1001470:
                //    donendeger = 557;
                //    break;
                case 1010137:
                    donendeger = 558;
                    break;
                case 1011510:
                    donendeger = 559;
                    break;
                case 1000097:
                    donendeger = 560;
                    break;
                case 1000482:
                    donendeger = 561;
                    break;
                case 1002076:
                    donendeger = 562;
                    break;
                case 1000517:
                    donendeger = 563;
                    break;
                //case 1006697:
                //    donendeger = 564; // grup kar
                //    break;
                //case 1001286:
                //    donendeger = 565; // grup serra
                //    break;
                //case 1011425:
                //    donendeger = 566; // karma gıda
                //    break;
                case 1000967:
                    donendeger = 567;
                    break;
                case 1006468:
                    donendeger = 568;
                    break;
                case 1006425:
                    donendeger = 569;
                    break;
                case 1006851:
                    donendeger = 570;
                    break;
                case 1001519:
                    donendeger = 571;
                    break;
                case 1001494:
                    donendeger = 572;
                    break;
                case 1002131:
                    donendeger = 573;
                    break;
                //case 1007301:
                //    donendeger = 574; // mitra
                //    break;
                case 1006584:
                    donendeger = 575;
                    break;
                case 1000057:
                    donendeger = 576;
                    break;
                case 1002683:
                    donendeger = 577;
                    break;
                case 1001222:
                    donendeger = 578;
                    break;
                case 1001375:
                    donendeger = 579;
                    break;
                case 1000176:
                    donendeger = 580;
                    break;
                //case 1012812:
                //    donendeger = 581;
                //    break;
                case 1005349:
                    donendeger = 582;
                    break;
                case 1005229:
                    donendeger = 583;
                    break;
                case 1013092:
                    donendeger = 584;
                    break;
                case 1013068:
                    donendeger = 585;
                    break;
                case 1013069:
                    donendeger = 586;
                    break;
                case 1013070:
                    donendeger = 587;
                    break;
                case 1013419:
                    donendeger = 588;
                    break;
                case 1013148:
                    donendeger = 589;
                    break;
                case 1013418:
                    donendeger = 590;
                    break;
                case 1013420:
                    donendeger = 591;
                    break;
                case 1006224:
                    donendeger = 592;
                    break;
                case 1000711:
                    donendeger = 593;
                    break;
                case 1006772:
                    donendeger = 594;
                    break;
                case 1001461:
                    donendeger = 595;
                    break;
                case 1017282:
                    donendeger = 596;
                    break;
                case 1017321:
                    donendeger = 597;
                    break;
                case 1017360:
                    donendeger = 598;
                    break;
                case 1006960:
                    donendeger = 599;
                    break;
                case 1005510:
                    donendeger = 600;
                    break;
                case 1006959:
                    donendeger = 601;
                    break;
                case 1003066:
                    donendeger = 602;
                    break;
                case 1019741:
                    donendeger = 603;
                    break;
                case 1011919:
                    donendeger = 604;
                    break;
                case 1005328:
                    donendeger = 605;
                    break;
                case 1027198:
                    donendeger = 606;
                    break;
                case 1027499:
                    donendeger = 607;
                    break;
                case 1027689:
                    donendeger = 608;
                    break;
                case 1010244:
                    donendeger = 609;
                    break;
                default:
                    break;
            }*/
            #endregion

            return donendeger;
        }
        #endregion



        #region getekstre
        void GetEkstre(DateTime Baslangic)
        {
            string hata = string.Empty;
            string hata2 = string.Empty;
            DateTime baslangic = DateTime.Now;

            /*string baslangicsap = Baslangic.Year.ToString()
                + (Baslangic.Month.ToString().Length == 1 ? "0" + Baslangic.Month.ToString() : Baslangic.Month.ToString())
                + (Baslangic.Day.ToString().Length == 1 ? "0" + Baslangic.Day.ToString() : Baslangic.Day.ToString());*/
            //string baslangicsilme = (Baslangic.Month.ToString().Length == 1 ? "0" + Baslangic.Month.ToString() : Baslangic.Month.ToString()) + "."
            //    + (Baslangic.Day.ToString().Length == 1 ? "0" + Baslangic.Day.ToString() : Baslangic.Day.ToString()) + "."
            //    + Baslangic.Year.ToString();

            List<int> yillar = new List<int>();
            for (int i = 0; i < DateTime.Now.Year - Baslangic.Year + 1; i++)
                yillar.Add(Baslangic.Year + i);

            SqlConnection conn = new SqlConnection(General.ConnectionString);
            int ayniyiltekrar = 0;
            for (int j = 0; j < yillar.Count; j++)
            {
                //Baslangic = Convert.ToDateTime("01.01." + yillar[j].ToString());
                DateTime bas = DateTime.Now;
                bool buyilhatayok = true;


                selectekstreC.ZwebSelectEkstreService ekstre = new selectekstreC.ZwebSelectEkstreService();
                ekstre.Timeout = 6000000;
                selectekstreC.Zwebs023[] yirmiuc = null;
                selectekstreC.Zwebs023[] yirmiuc2 = null;
                ekstre.Credentials = nc1;

                //SAPs.LogYaz("ekstre oncesi", true, "sap ile bağlantı kuruluyor", DateTime.Now, DateTime.Now);
                try
                {
                    yirmiuc = ekstre.ZwebSelectEkstre("", yillar[j].ToString(), "", out yirmiuc2); // 20160101
                    SAPs.LogYaz("ekstre sonrasi", true, "sap yanıt verdi, " + yillar[j].ToString() + " yılı verisi alındı, " + (yirmiuc.Length + yirmiuc2.Length).ToString() + " satır", DateTime.Now, DateTime.Now);
                    ayniyiltekrar = 0;
                }
                catch (Exception ex)
                {
                    SAPs.LogYaz("ekstre", true, "sap hata döndürdü " + yillar[j].ToString() + ":" + ex.Message, DateTime.Now, DateTime.Now);
                    buyilhatayok = false;
                    if (ayniyiltekrar < 3)
                    {
                        j--;
                        ayniyiltekrar++;
                    }
                    else
                    {
                        ayniyiltekrar = 0;
                    }
                }


                if (buyilhatayok)
                {
                    #region DataTable
                    DataTable dt = new DataTable();
                    dt.Columns.Add("Tur", typeof(string));
                    dt.Columns.Add("Bukrs", typeof(string));
                    dt.Columns.Add("Kunnr", typeof(int));
                    dt.Columns.Add("Umsks", typeof(string));
                    dt.Columns.Add("Umskz", typeof(string));
                    dt.Columns.Add("Gjahr", typeof(int));
                    dt.Columns.Add("Belnr", typeof(string));
                    dt.Columns.Add("Buzei", typeof(int));
                    dt.Columns.Add("Augdt", typeof(DateTime));
                    dt.Columns.Add("Augbl", typeof(string));
                    dt.Columns.Add("Zuonr", typeof(string));
                    dt.Columns.Add("Budat", typeof(DateTime));
                    dt.Columns.Add("Blart", typeof(string));
                    dt.Columns.Add("Ltext", typeof(string));
                    dt.Columns.Add("Sgtxt", typeof(string));
                    dt.Columns.Add("Borc", typeof(double));
                    dt.Columns.Add("Alacak", typeof(double));
                    dt.Columns.Add("Shkzg", typeof(string));
                    dt.Columns.Add("Waers", typeof(string));
                    dt.Columns.Add("Lifnr", typeof(string));
                    dt.Columns.Add("Awkey", typeof(string));
                    dt.Columns.Add("Zfbdt", typeof(DateTime));
                    dt.Columns.Add("Zbd1t", typeof(int));
                    dt.Columns.Add("Xref1", typeof(string));
                    dt.Columns.Add("Xref2", typeof(string));
                    dt.Columns.Add("Kidno", typeof(string));
                    dt.Columns.Add("Vbeln", typeof(int));
                    dt.Columns.Add("Kunag", typeof(int));
                    dt.Columns.Add("Ernam", typeof(string));
                    dt.Columns.Add("Erdat", typeof(DateTime));
                    dt.Columns.Add("Erzet", typeof(string));
                    dt.Columns.Add("Xblnr", typeof(string));
                    dt.Columns.Add("Rebzg", typeof(string));
                    dt.Columns.Add("Rebzj", typeof(int));
                    dt.Columns.Add("Rebzz", typeof(int));
                    dt.Columns.Add("Hkont", typeof(string));
                    #endregion

                    #region Musteri
                    for (int i = 0; i < yirmiuc.Length; i++)
                    {
                        try
                        {
                            DataRow drow = dt.NewRow();
                            drow["Tur"] = "M";
                            drow["Bukrs"] = yirmiuc[i].Bukrs;
                            try { drow["Kunnr"] = Convert.ToInt32(yirmiuc[i].Kunnr); }
                            catch (Exception) { drow["Kunnr"] = 10; }
                            drow["Umsks"] = yirmiuc[i].Umsks;
                            drow["Umskz"] = yirmiuc[i].Umskz;
                            drow["Gjahr"] = yirmiuc[i].Gjahr;
                            drow["Belnr"] = yirmiuc[i].Belnr;
                            drow["Buzei"] = yirmiuc[i].Buzei;
                            if (yirmiuc[i].Augdt.StartsWith("00")) drow["Augdt"] = Convert.ToDateTime("01.01.1900"); else drow["Augdt"] = Convert.ToDateTime(yirmiuc[i].Augdt);
                            drow["Augbl"] = yirmiuc[i].Augbl;
                            drow["Zuonr"] = yirmiuc[i].Zuonr;
                            if (yirmiuc[i].Budat.StartsWith("00")) drow["Budat"] = Convert.ToDateTime("01.01.1900"); else drow["Budat"] = Convert.ToDateTime(yirmiuc[i].Budat);
                            drow["Blart"] = yirmiuc[i].Blart;
                            drow["Ltext"] = yirmiuc[i].Ltext;
                            drow["Sgtxt"] = yirmiuc[i].Sgtxt;
                            drow["Borc"] = yirmiuc[i].Borc;
                            drow["Alacak"] = yirmiuc[i].Alacak;
                            drow["Shkzg"] = yirmiuc[i].Shkzg;
                            drow["Waers"] = yirmiuc[i].Waers;
                            drow["Lifnr"] = yirmiuc[i].Lifnr;
                            drow["Awkey"] = yirmiuc[i].Awkey;
                            if (yirmiuc[i].Zfbdt.StartsWith("00")) drow["Zfbdt"] = Convert.ToDateTime("01.01.1900"); else drow["Zfbdt"] = Convert.ToDateTime(yirmiuc[i].Zfbdt);
                            drow["Zbd1t"] = yirmiuc[i].Zbd1t;
                            drow["Xref1"] = yirmiuc[i].Xref1;
                            drow["Xref2"] = yirmiuc[i].Xref2;
                            drow["Kidno"] = yirmiuc[i].Kidno;
                            try { drow["Vbeln"] = Convert.ToInt32(yirmiuc[i].Vbeln); }
                            catch (Exception) { drow["Vbeln"] = DBNull.Value; }
                            try { drow["Kunag"] = Convert.ToInt32(yirmiuc[i].Kunag); }
                            catch (Exception) { drow["Kunag"] = 10; }
                            drow["Ernam"] = yirmiuc[i].Ernam;
                            drow["Erdat"] = Convert.ToDateTime(yirmiuc[i].Erdat + " " + yirmiuc[i].Erzet);
                            drow["Erzet"] = yirmiuc[i].Erzet;
                            drow["Xblnr"] = yirmiuc[i].Xblnr;
                            drow["Rebzg"] = yirmiuc[i].Rebzg;
                            drow["Rebzj"] = yirmiuc[i].Rebzj == string.Empty ? 0 : Convert.ToInt32(yirmiuc[i].Rebzj);
                            drow["Rebzz"] = yirmiuc[i].Rebzz == string.Empty ? 0 : Convert.ToInt32(yirmiuc[i].Rebzz);
                            drow["Hkont"] = yirmiuc[i].Hkont;
                            dt.Rows.Add(drow);
                        }
                        catch (Exception ex)
                        {
                            hata = ex.Message;
                            SAPs.LogYaz("ekstre sonrasi", true, "musteri ekstresi bellege alinirken bir satirda hata olustu: " + ex.Message, DateTime.Now, DateTime.Now);
                        }
                    }

                    //if (hata == string.Empty)
                    //{
                    //    try
                    //    {
                    //        SqlDataAdapter da = new SqlDataAdapter();
                    //        da.InsertCommand = new SqlCommand("INSERT INTO [SAP_EKSTRE] (Tur,[Bukrs],[Kunnr],[Umsks],[Umskz],[Gjahr],[Belnr],[Buzei],[Augdt],[Augbl],[Zuonr],[Budat],[Blart],[Ltext],[Sgtxt],[Borc],[Alacak],[Shkzg],[Waers],[Lifnr],[Awkey],[Zfbdt],[Zbd1t],[Xref1],[Xref2],[Kidno],[Vbeln],[Kunag],Ernam,Erdat,Erzet,Xblnr,Rebzg,Rebzj,Rebzz,Hkont) VALUES (@Tur,@Bukrs,@Kunnr,@Umsks,@Umskz,@Gjahr,@Belnr,@Buzei,@Augdt,@Augbl,@Zuonr,@Budat,@Blart,@Ltext,@Sgtxt,@Borc,@Alacak,@Shkzg,@Waers,@Lifnr,@Awkey,@Zfbdt,@Zbd1t,@Xref1,@Xref2,@Kidno,@Vbeln,@Kunag,@Ernam,@Erdat,@Erzet,@Xblnr,@Rebzg,@Rebzj,@Rebzz,@Hkont)", conn);
                    //        da.InsertCommand.Parameters.Add("@Tur", SqlDbType.Char, 1, "Tur");
                    //        da.InsertCommand.Parameters.Add("@Bukrs", SqlDbType.VarChar, 4, "Bukrs");
                    //        da.InsertCommand.Parameters.Add("@Kunnr", SqlDbType.Int, 4, "Kunnr");
                    //        da.InsertCommand.Parameters.Add("@Umsks", SqlDbType.VarChar, 1, "Umsks");
                    //        da.InsertCommand.Parameters.Add("@Umskz", SqlDbType.VarChar, 1, "Umskz");
                    //        da.InsertCommand.Parameters.Add("@Gjahr", SqlDbType.Int, 4, "Gjahr");
                    //        da.InsertCommand.Parameters.Add("@Belnr", SqlDbType.VarChar, 10, "Belnr");
                    //        da.InsertCommand.Parameters.Add("@Buzei", SqlDbType.Int, 4, "Buzei");
                    //        da.InsertCommand.Parameters.Add("@Augdt", SqlDbType.DateTime, 8, "Augdt");
                    //        da.InsertCommand.Parameters.Add("@Augbl", SqlDbType.VarChar, 10, "Augbl");
                    //        da.InsertCommand.Parameters.Add("@Zuonr", SqlDbType.VarChar, 18, "Zuonr");
                    //        da.InsertCommand.Parameters.Add("@Budat", SqlDbType.DateTime, 8, "Budat");
                    //        da.InsertCommand.Parameters.Add("@Blart", SqlDbType.VarChar, 2, "Blart");
                    //        da.InsertCommand.Parameters.Add("@Ltext", SqlDbType.NVarChar, 40, "Ltext");
                    //        da.InsertCommand.Parameters.Add("@Sgtxt", SqlDbType.NVarChar, 50, "Sgtxt");
                    //        da.InsertCommand.Parameters.Add("@Borc", SqlDbType.Float, 8, "Borc");
                    //        da.InsertCommand.Parameters.Add("@Alacak", SqlDbType.Float, 8, "Alacak");
                    //        da.InsertCommand.Parameters.Add("@Shkzg", SqlDbType.VarChar, 1, "Shkzg");
                    //        da.InsertCommand.Parameters.Add("@Waers", SqlDbType.NVarChar, 50, "Waers");
                    //        da.InsertCommand.Parameters.Add("@Lifnr", SqlDbType.VarChar, 10, "Lifnr");
                    //        da.InsertCommand.Parameters.Add("@Awkey", SqlDbType.VarChar, 20, "Awkey");
                    //        da.InsertCommand.Parameters.Add("@Zfbdt", SqlDbType.DateTime, 8, "Zfbdt");
                    //        da.InsertCommand.Parameters.Add("@Zbd1t", SqlDbType.Int, 4, "Zbd1t");
                    //        da.InsertCommand.Parameters.Add("@Xref1", SqlDbType.VarChar, 12, "Xref1");
                    //        da.InsertCommand.Parameters.Add("@Xref2", SqlDbType.NVarChar, 12, "Xref2");
                    //        da.InsertCommand.Parameters.Add("@Kidno", SqlDbType.VarChar, 30, "Kidno");
                    //        da.InsertCommand.Parameters.Add("@Vbeln", SqlDbType.Int, 4, "Vbeln");
                    //        da.InsertCommand.Parameters.Add("@Kunag", SqlDbType.Int, 4, "Kunag");
                    //        da.InsertCommand.Parameters.Add("@Ernam", SqlDbType.NVarChar, 12, "Ernam");
                    //        da.InsertCommand.Parameters.Add("@Erdat", SqlDbType.DateTime, 8, "Erdat");
                    //        da.InsertCommand.Parameters.Add("@Erzet", SqlDbType.NVarChar, 8, "Erzet");
                    //        da.InsertCommand.Parameters.Add("@Xblnr", SqlDbType.NVarChar, 16, "Xblnr");
                    //        da.InsertCommand.Parameters.Add("@Rebzg", SqlDbType.NVarChar, 10, "Rebzg");
                    //        da.InsertCommand.Parameters.Add("@Rebzj", SqlDbType.Int, 4, "Rebzj");
                    //        da.InsertCommand.Parameters.Add("@Rebzz", SqlDbType.Int, 4, "Rebzz");
                    //        da.InsertCommand.Parameters.Add("@Hkont", SqlDbType.NVarChar, 10, "Hkont");
                    //        da.Update(dt);
                    //    }
                    //    catch (Exception ex)
                    //    {
                    //        hata = ex.Message;
                    //    }
                    //}
                    #endregion

                    //SAPs.LogYaz("ekstre sonrasi", true, "müşteri ekstresi bellege alindi", DateTime.Now, DateTime.Now);

                    //dt.Rows.Clear();

                    #region Tedarikci
                    for (int i = 0; i < yirmiuc2.Length; i++)
                    {
                        try
                        {
                            DataRow drow = dt.NewRow();
                            drow["Tur"] = "T";
                            drow["Bukrs"] = yirmiuc2[i].Bukrs;
                            try { drow["Kunnr"] = Convert.ToInt32(yirmiuc2[i].Kunnr); }
                            catch (Exception) { drow["Kunnr"] = 10; }
                            drow["Umsks"] = yirmiuc2[i].Umsks;
                            drow["Umskz"] = yirmiuc2[i].Umskz;
                            drow["Gjahr"] = yirmiuc2[i].Gjahr;
                            drow["Belnr"] = yirmiuc2[i].Belnr;
                            drow["Buzei"] = yirmiuc2[i].Buzei;
                            if (yirmiuc2[i].Augdt.StartsWith("00")) drow["Augdt"] = Convert.ToDateTime("01.01.1900"); else drow["Augdt"] = Convert.ToDateTime(yirmiuc2[i].Augdt);
                            drow["Augbl"] = yirmiuc2[i].Augbl;
                            drow["Zuonr"] = yirmiuc2[i].Zuonr;
                            if (yirmiuc2[i].Budat.StartsWith("00")) drow["Budat"] = Convert.ToDateTime("01.01.1900"); else drow["Budat"] = Convert.ToDateTime(yirmiuc2[i].Budat);
                            drow["Blart"] = yirmiuc2[i].Blart;
                            drow["Ltext"] = yirmiuc2[i].Ltext;
                            drow["Sgtxt"] = yirmiuc2[i].Sgtxt;
                            drow["Borc"] = yirmiuc2[i].Borc;
                            drow["Alacak"] = yirmiuc2[i].Alacak;
                            drow["Shkzg"] = yirmiuc2[i].Shkzg;
                            drow["Waers"] = yirmiuc2[i].Waers;
                            drow["Lifnr"] = yirmiuc2[i].Lifnr;
                            drow["Awkey"] = yirmiuc2[i].Awkey;
                            if (yirmiuc2[i].Zfbdt.StartsWith("00")) drow["Zfbdt"] = Convert.ToDateTime("01.01.1900"); else drow["Zfbdt"] = Convert.ToDateTime(yirmiuc2[i].Zfbdt);
                            drow["Zbd1t"] = yirmiuc2[i].Zbd1t;
                            drow["Xref1"] = yirmiuc2[i].Xref1;
                            drow["Xref2"] = yirmiuc2[i].Xref2;
                            drow["Kidno"] = yirmiuc2[i].Kidno;
                            try { drow["Vbeln"] = Convert.ToInt32(yirmiuc2[i].Vbeln); }
                            catch (Exception) { drow["Vbeln"] = DBNull.Value; }
                            try { drow["Kunag"] = Convert.ToInt32(yirmiuc2[i].Kunag); }
                            catch (Exception) { drow["Kunag"] = 10; }
                            drow["Ernam"] = yirmiuc2[i].Ernam;
                            drow["Erdat"] = Convert.ToDateTime(yirmiuc2[i].Erdat + " " + yirmiuc2[i].Erzet);
                            drow["Erzet"] = yirmiuc2[i].Erzet;
                            drow["Xblnr"] = yirmiuc2[i].Xblnr;
                            drow["Rebzg"] = yirmiuc2[i].Rebzg;
                            drow["Rebzj"] = yirmiuc2[i].Rebzj == string.Empty ? 0 : Convert.ToInt32(yirmiuc[i].Rebzj);
                            drow["Rebzz"] = yirmiuc2[i].Rebzz == string.Empty ? 0 : Convert.ToInt32(yirmiuc[i].Rebzz);
                            drow["Hkont"] = yirmiuc2[i].Hkont;
                            dt.Rows.Add(drow);
                        }
                        catch (Exception ex)
                        {
                            hata2 = ex.Message;
                            SAPs.LogYaz("ekstre sonrasi", true, "tedarikci ekstresi bellege alinirken bir satirda hata olustu: " + ex.Message, DateTime.Now, DateTime.Now);
                        }
                    }
                    #endregion

                    //SAPs.LogYaz("ekstre sonrasi", true, "tedarikci ekstresi bellege alindi", DateTime.Now, DateTime.Now);

                    #region silme ve yazma
                    if (hata == string.Empty && hata2 == string.Empty)
                    {
                        SqlCommand cmd1 = new SqlCommand("DELETE FROM [SAP_EKSTRE] WHERE Gjahr = @Gjahr", conn);
                        cmd1.Parameters.Add("@Gjahr", SqlDbType.Int).Value = yillar[j];
                        cmd1.CommandTimeout = 1000;
                        conn.Open(); cmd1.ExecuteNonQuery(); conn.Close();

                        SAPs.LogYaz("ekstre sonrasi", true, "sap_ekstre tablosu " + yillar[j].ToString() + " yılı silindi", DateTime.Now, DateTime.Now);

                        try
                        {
                            SqlDataAdapter da = new SqlDataAdapter();
                            da.InsertCommand = new SqlCommand("INSERT INTO [SAP_EKSTRE] (Tur,[Bukrs],[Kunnr],[Umsks],[Umskz],[Gjahr],[Belnr],[Buzei],[Augdt],[Augbl],[Zuonr],[Budat],[Blart],[Ltext],[Sgtxt],[Borc],[Alacak],[Shkzg],[Waers],[Lifnr],[Awkey],[Zfbdt],[Zbd1t],[Xref1],[Xref2],[Kidno],[Vbeln],[Kunag],Ernam,Erdat,Erzet,Xblnr,Rebzg,Rebzj,Rebzz,Hkont) VALUES (@Tur,@Bukrs,@Kunnr,@Umsks,@Umskz,@Gjahr,@Belnr,@Buzei,@Augdt,@Augbl,@Zuonr,@Budat,@Blart,@Ltext,@Sgtxt,@Borc,@Alacak,@Shkzg,@Waers,@Lifnr,@Awkey,@Zfbdt,@Zbd1t,@Xref1,@Xref2,@Kidno,@Vbeln,@Kunag,@Ernam,@Erdat,@Erzet,@Xblnr,@Rebzg,@Rebzj,@Rebzz,@Hkont)", conn);
                            da.InsertCommand.Parameters.Add("@Tur", SqlDbType.Char, 1, "Tur");
                            da.InsertCommand.Parameters.Add("@Bukrs", SqlDbType.VarChar, 4, "Bukrs");
                            da.InsertCommand.Parameters.Add("@Kunnr", SqlDbType.Int, 4, "Kunnr");
                            da.InsertCommand.Parameters.Add("@Umsks", SqlDbType.VarChar, 1, "Umsks");
                            da.InsertCommand.Parameters.Add("@Umskz", SqlDbType.VarChar, 1, "Umskz");
                            da.InsertCommand.Parameters.Add("@Gjahr", SqlDbType.Int, 4, "Gjahr");
                            da.InsertCommand.Parameters.Add("@Belnr", SqlDbType.VarChar, 10, "Belnr");
                            da.InsertCommand.Parameters.Add("@Buzei", SqlDbType.Int, 4, "Buzei");
                            da.InsertCommand.Parameters.Add("@Augdt", SqlDbType.DateTime, 8, "Augdt");
                            da.InsertCommand.Parameters.Add("@Augbl", SqlDbType.VarChar, 10, "Augbl");
                            da.InsertCommand.Parameters.Add("@Zuonr", SqlDbType.VarChar, 18, "Zuonr");
                            da.InsertCommand.Parameters.Add("@Budat", SqlDbType.DateTime, 8, "Budat");
                            da.InsertCommand.Parameters.Add("@Blart", SqlDbType.VarChar, 2, "Blart");
                            da.InsertCommand.Parameters.Add("@Ltext", SqlDbType.NVarChar, 40, "Ltext");
                            da.InsertCommand.Parameters.Add("@Sgtxt", SqlDbType.NVarChar, 50, "Sgtxt");
                            da.InsertCommand.Parameters.Add("@Borc", SqlDbType.Float, 8, "Borc");
                            da.InsertCommand.Parameters.Add("@Alacak", SqlDbType.Float, 8, "Alacak");
                            da.InsertCommand.Parameters.Add("@Shkzg", SqlDbType.VarChar, 1, "Shkzg");
                            da.InsertCommand.Parameters.Add("@Waers", SqlDbType.NVarChar, 50, "Waers");
                            da.InsertCommand.Parameters.Add("@Lifnr", SqlDbType.VarChar, 10, "Lifnr");
                            da.InsertCommand.Parameters.Add("@Awkey", SqlDbType.VarChar, 20, "Awkey");
                            da.InsertCommand.Parameters.Add("@Zfbdt", SqlDbType.DateTime, 8, "Zfbdt");
                            da.InsertCommand.Parameters.Add("@Zbd1t", SqlDbType.Int, 4, "Zbd1t");
                            da.InsertCommand.Parameters.Add("@Xref1", SqlDbType.VarChar, 12, "Xref1");
                            da.InsertCommand.Parameters.Add("@Xref2", SqlDbType.NVarChar, 12, "Xref2");
                            da.InsertCommand.Parameters.Add("@Kidno", SqlDbType.VarChar, 30, "Kidno");
                            da.InsertCommand.Parameters.Add("@Vbeln", SqlDbType.Int, 4, "Vbeln");
                            da.InsertCommand.Parameters.Add("@Kunag", SqlDbType.Int, 4, "Kunag");
                            da.InsertCommand.Parameters.Add("@Ernam", SqlDbType.NVarChar, 12, "Ernam");
                            da.InsertCommand.Parameters.Add("@Erdat", SqlDbType.DateTime, 8, "Erdat");
                            da.InsertCommand.Parameters.Add("@Erzet", SqlDbType.NVarChar, 8, "Erzet");
                            da.InsertCommand.Parameters.Add("@Xblnr", SqlDbType.NVarChar, 16, "Xblnr");
                            da.InsertCommand.Parameters.Add("@Rebzg", SqlDbType.NVarChar, 10, "Rebzg");
                            da.InsertCommand.Parameters.Add("@Rebzj", SqlDbType.Int, 4, "Rebzj");
                            da.InsertCommand.Parameters.Add("@Rebzz", SqlDbType.Int, 4, "Rebzz");
                            da.InsertCommand.Parameters.Add("@Hkont", SqlDbType.NVarChar, 10, "Hkont");
                            da.Update(dt);

                            SAPs.LogYaz("ekstre sonrasi", true, "sap_ekstre tablosu dolduruldu", DateTime.Now, DateTime.Now);
                        }
                        catch (Exception ex)
                        {
                            hata2 = ex.Message;
                            SAPs.LogYaz("ekstre sonrasi", true, "sap_ekstre tablosu doldurulurken hata olustu: " + ex.Message, DateTime.Now, DateTime.Now);
                        }
                    }
                    #endregion

                    SAPs.LogYaz("ekstre", true, yillar[j].ToString() + " mali yılı silindi ve yazıldı", bas, DateTime.Now);
                }
            }



            SAPs.LogYaz("ekstre", hata != string.Empty && hata2 != string.Empty ? false : true, (hata + " " + hata2).Trim(), baslangic, DateTime.Now);




            if (hata == string.Empty && hata2 == string.Empty)
            {
                SqlCommand cmdEkstreJob = new SqlCommand("msdb.dbo.sp_start_job", conn);
                cmdEkstreJob.CommandTimeout = 1000;
                cmdEkstreJob.CommandType = CommandType.StoredProcedure;
                cmdEkstreJob.Parameters.AddWithValue("@job_name", "Web_Ekstre");

                DateTime bastarih = DateTime.Now;
                string hataa = string.Empty;
                try
                {
                    conn.Open();
                    cmdEkstreJob.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    hataa = ex.Message;
                }
                finally
                {
                    conn.Close();
                    SAPs.LogYaz("ekstre yeni", hataa != string.Empty ? false : true, hataa, bastarih, DateTime.Now);
                }
            }
        }
        #endregion

        #region getsap
        void GetSAP()
        {
            SqlConnection conn = new SqlConnection(General.ConnectionString);

            bool vbfa = true;
            bool siparis = true;
            bool teslimat = true;
            bool nakilmalfatura = true;
            bool nakilsiparis = true;
            bool malcikis = true;
            bool fatura = true;
            bool kolietiket = true;
            bool accounting = false;
            bool efatura = false;
            bool ekstre = DateTime.Now.Hour == 12;



            #region VBFA
            if (vbfa)
            {
                DateTime maxtarih = MaxTarihGetir(conn, "SAP_Vbfa");
                DateTime bitistarih = DateTime.Now;
                bool hatavar = false;

                selectsalesvbfaC.ZwebSelectSalesVbfaService client = new selectsalesvbfaC.ZwebSelectSalesVbfaService();
                client.Timeout = 6000000;
                client.Credentials = nc1;

                DateTime cekilecektarih = maxtarih;
                DateTime simdikitarih = DateTime.Now;
                while (Convert.ToDateTime(cekilecektarih.ToShortDateString()) <= Convert.ToDateTime(simdikitarih.ToShortDateString()))
                {
                    selectsalesvbfaC.Zwebs009[] dokuz = null;

                    string hata = string.Empty;
                    string tarih = "";
                    string saat = "00:00:00";

                    int tekrarcek = 0;
                    while (tekrarcek < tekrarcekilecek)
                    {
                        try
                        {
                            TarihSaat(maxtarih, cekilecektarih, out tarih, out saat);
                            dokuz = client.ZwebSelectSalesVbfa(tarih, saat);
                            tekrarcek = tekrarcekilecek;
                        }
                        catch (Exception ex)
                        {
                            SAPs.LogYaz("select sales vbfa", true, cekilecektarih.ToShortDateString() + " " + (tekrarcek + 1).ToString() + ".deneme sap hata döndürdü: " + ex.Message, DateTime.Now, DateTime.Now);
                            if (tekrarcek < tekrarcekilecek)
                            {
                                tekrarcek++;
                                System.Threading.Thread.Sleep(3000);
                            }
                            else
                            {
                                hata = ex.Message;
                                hatavar = true;
                                cekilecektarih = DateTime.Now; // while dan çıksın bir sonraki günü almasın max tarihi yenilemesin
                            }
                        }
                    }

                    SAPs.LogYaz("select sales vbfa", hata != string.Empty ? false : true, hata, Convert.ToDateTime(cekilecektarih.ToShortDateString() + " " + saat), Convert.ToDateTime(cekilecektarih.ToShortDateString()) == Convert.ToDateTime(simdikitarih.ToShortDateString()) ? DateTime.Now : Convert.ToDateTime(cekilecektarih.AddDays(1).ToShortDateString() + " 00:00:00"));



                    if (dokuz != null)
                    {
                        for (int j = 0; j < dokuz.Length; j++)
                        {
                            try
                            {
                                conn.Open();
                                SqlCommand cmd = new SqlCommand(
                                    "DELETE FROM [SAP_VBFA] WHERE Vbelv = @Vbelv AND Posnv = @Posnv AND Vbeln = @Vbeln AND Posnn = @Posnn AND [Vbtyp N] = @VbtypN " +
                                    "INSERT INTO [SAP_VBFA] (KAYIT_TARIHI,[Vbelv],[Posnv],[Vbeln],[Posnn],[Vbtyp N],[Rfmng],[Meins],[Rfwrt],[Waers],[Vbtyp V],[Plmin],[Taqui],[Erdat],[Erzet],[Matnr],[Bwart],[Bdart],[Plart],[Stufe],[Lgnum],[Aedat],[Fktyp],[Brgew],[Gewei],[Volum],[Voleh],[Fplnr],[Fpltr],[Rfmng Flo],[Rfmng Flt],[Vrkme],[Abges],[Sobkz],[Sonum],[Kzbef],[Ntgew],[Logsys],[Wbsta],[Cmeth],[Mjahr],Vkorg,Spart) VALUES (@KAYIT_TARIHI,@Vbelv,@Posnv,@Vbeln,@Posnn,@VbtypN,@Rfmng,@Meins,@Rfwrt,@Waers,@VbtypV,@Plmin,@Taqui,@Erdat,@Erzet,@Matnr,@Bwart,@Bdart,@Plart,@Stufe,@Lgnum,@Aedat,@Fktyp,@Brgew,@Gewei,@Volum,@Voleh,@Fplnr,@Fpltr,@RfmngFlo,@RfmngFlt,@Vrkme,@Abges,@Sobkz,@Sonum,@Kzbef,@Ntgew,@Logsys,@Wbsta,@Cmeth,@Mjahr,@Vkorg,@Spart)", conn);
                                #region parameters
                                cmd.Parameters.AddWithValue("@KAYIT_TARIHI", DateTime.Now);
                                cmd.Parameters.AddWithValue("@Vbelv", Convert.ToInt64(dokuz[j].Vbelv));
                                cmd.Parameters.AddWithValue("@Posnv", Convert.ToInt32(dokuz[j].Posnv));
                                cmd.Parameters.AddWithValue("@Vbeln", Convert.ToInt64(dokuz[j].Vbeln));
                                cmd.Parameters.AddWithValue("@Posnn", Convert.ToInt32(dokuz[j].Posnn));
                                cmd.Parameters.AddWithValue("@VbtypN", dokuz[j].VbtypN);
                                cmd.Parameters.AddWithValue("@Rfmng", dokuz[j].Rfmng);
                                cmd.Parameters.AddWithValue("@Meins", dokuz[j].Meins);
                                cmd.Parameters.AddWithValue("@Rfwrt", dokuz[j].Rfwrt);
                                cmd.Parameters.AddWithValue("@Waers", dokuz[j].Waers);
                                cmd.Parameters.AddWithValue("@VbtypV", dokuz[j].VbtypV);
                                cmd.Parameters.AddWithValue("@Plmin", dokuz[j].Plmin);
                                cmd.Parameters.AddWithValue("@Taqui", dokuz[j].Taqui);
                                cmd.Parameters.AddWithValue("@Erdat", Convert.ToDateTime(dokuz[j].Erdat + " " + dokuz[j].Erzet));
                                cmd.Parameters.AddWithValue("@Erzet", dokuz[j].Erzet);
                                cmd.Parameters.AddWithValue("@Matnr", dokuz[j].Matnr == string.Empty ? 0 : Convert.ToInt32(dokuz[j].Matnr));
                                cmd.Parameters.AddWithValue("@Bwart", dokuz[j].Bwart);
                                cmd.Parameters.AddWithValue("@Bdart", dokuz[j].Bdart);
                                cmd.Parameters.AddWithValue("@Plart", dokuz[j].Plart);
                                cmd.Parameters.AddWithValue("@Stufe", dokuz[j].Stufe);
                                cmd.Parameters.AddWithValue("@Lgnum", dokuz[j].Lgnum);
                                cmd.Parameters.AddWithValue("@Aedat", dokuz[j].Aedat.StartsWith("0000") ? Convert.ToDateTime("01.01.1900") : Convert.ToDateTime(dokuz[j].Aedat));
                                cmd.Parameters.AddWithValue("@Fktyp", dokuz[j].Fktyp);
                                cmd.Parameters.AddWithValue("@Brgew", dokuz[j].Brgew);
                                cmd.Parameters.AddWithValue("@Gewei", dokuz[j].Gewei);
                                cmd.Parameters.AddWithValue("@Volum", dokuz[j].Volum);
                                cmd.Parameters.AddWithValue("@Voleh", dokuz[j].Voleh);
                                cmd.Parameters.AddWithValue("@Fplnr", dokuz[j].Fplnr);
                                cmd.Parameters.AddWithValue("@Fpltr", dokuz[j].Fpltr);
                                cmd.Parameters.AddWithValue("@RfmngFlo", dokuz[j].RfmngFlo);
                                cmd.Parameters.AddWithValue("@RfmngFlt", dokuz[j].RfmngFlt);
                                cmd.Parameters.AddWithValue("@Vrkme", dokuz[j].Vrkme);
                                cmd.Parameters.AddWithValue("@Abges", dokuz[j].Abges);
                                cmd.Parameters.AddWithValue("@Sobkz", dokuz[j].Sobkz);
                                cmd.Parameters.AddWithValue("@Sonum", dokuz[j].Sonum);
                                cmd.Parameters.AddWithValue("@Kzbef", dokuz[j].Kzbef);
                                cmd.Parameters.AddWithValue("@Ntgew", dokuz[j].Ntgew);
                                cmd.Parameters.AddWithValue("@Logsys", dokuz[j].Logsys);
                                cmd.Parameters.AddWithValue("@Wbsta", dokuz[j].Wbsta);
                                cmd.Parameters.AddWithValue("@Cmeth", dokuz[j].Cmeth);
                                cmd.Parameters.AddWithValue("@Mjahr", dokuz[j].Mjahr);
                                cmd.Parameters.AddWithValue("@Vkorg", dokuz[j].Vkorg);
                                cmd.Parameters.AddWithValue("@Spart", dokuz[j].Spart);
                                #endregion
                                cmd.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                SAPs.HataYaz("SAP_VBFA", Convert.ToInt64(dokuz[j].Vbelv).ToString(), Convert.ToInt32(dokuz[j].Posnv).ToString(), Convert.ToInt64(dokuz[j].Vbeln).ToString(), Convert.ToInt32(dokuz[j].Posnn).ToString(), dokuz[j].VbtypN, ex.Message, cekilecektarih, cekilecektarih.AddDays(1));
                            }
                            conn.Close();
                        }
                    }

                    cekilecektarih = cekilecektarih.AddDays(1);
                }

                if (!hatavar)
                    MaxTarihYaz(conn, "SAP_Vbfa", bitistarih);
            }
            #endregion



            #region SIPARIS
            if (siparis)
            {
                DateTime maxtarih = MaxTarihGetir(conn, "SAP_Siparis");
                DateTime bitistarih = DateTime.Now;
                bool hatavar = false;

                selectsalesorderC.ZwebSelectSalesOrderService client2 = new selectsalesorderC.ZwebSelectSalesOrderService();
                client2.Timeout = 6000000;
                client2.Credentials = nc1;

                DateTime cekilecektarih = maxtarih;
                DateTime simdikitarih = DateTime.Now;
                while (Convert.ToDateTime(cekilecektarih.ToShortDateString()) <= Convert.ToDateTime(simdikitarih.ToShortDateString()))
                {
                    selectsalesorderC.Zwebs009[] dokuz = null; // vbfa
                    selectsalesorderC.Zwebs005[] bes = null; // head
                    selectsalesorderC.Zwebs012[] oniki = null; // item
                    selectsalesorderC.Zwebs021[] yirmibir = null; // logdel

                    string hata = string.Empty;
                    string tarih = "";
                    string saat = "00:00:00";

                    int tekrarcek = 0;
                    while (tekrarcek < tekrarcekilecek)
                    {
                        try
                        {
                            TarihSaat(maxtarih, cekilecektarih, out tarih, out saat);
                            yirmibir = client2.ZwebSelectSalesOrder(tarih, "", saat, out bes, out oniki, out dokuz);
                            tekrarcek = tekrarcekilecek;
                        }
                        catch (Exception ex)
                        {
                            SAPs.LogYaz("select sales order", true, cekilecektarih.ToShortDateString() + " " + (tekrarcek + 1).ToString() + ".deneme sap hata döndürdü: " + ex.Message, DateTime.Now, DateTime.Now);
                            if (tekrarcek < tekrarcekilecek)
                            {
                                tekrarcek++;
                                System.Threading.Thread.Sleep(3000);
                            }
                            else
                            {
                                hata = ex.Message;
                                hatavar = true;
                                cekilecektarih = DateTime.Now; // while dan çıksın bir sonraki günü almasın max tarihi yenilemesin
                            }
                        }
                    }

                    SAPs.LogYaz("select sales order", hata != string.Empty ? false : true, hata, Convert.ToDateTime(cekilecektarih.ToShortDateString() + " " + saat), Convert.ToDateTime(cekilecektarih.ToShortDateString()) == Convert.ToDateTime(simdikitarih.ToShortDateString()) ? DateTime.Now : Convert.ToDateTime(cekilecektarih.AddDays(1).ToShortDateString() + " 00:00:00"));

                    #region logdel
                    if (yirmibir != null)
                    {
                        for (int j = 0; j < yirmibir.Length; j++)
                        {
                            try
                            {
                                conn.Open();
                                SqlCommand cmd = new SqlCommand("DELETE FROM [SAP_SIPARIS_BASLIK] WHERE Vbeln = @Vbeln DELETE FROM [SAP_SIPARIS_DETAY] WHERE Vbeln = @Vbeln DELETE FROM [SAP_VBFA] WHERE Vbelv = @Vbeln", conn);
                                cmd.Parameters.AddWithValue("@Vbeln", Convert.ToInt64(yirmibir[j].Vbeln));
                                cmd.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                SAPs.HataYaz("SAP_SIPARIS_BASLIK", Convert.ToInt64(yirmibir[j].Vbeln).ToString(), "", "", "", "", "(LOGDEL) - " + ex.Message, cekilecektarih, cekilecektarih.AddDays(1));
                            }
                            conn.Close();
                        }
                    }
                    #endregion

                    #region head
                    if (bes != null)
                    {
                        for (int j = 0; j < bes.Length; j++)
                        {
                            try
                            {
                                conn.Open();
                                SqlCommand cmd = new SqlCommand(
                                    "DELETE FROM [SAP_SIPARIS_BASLIK] WHERE Vbeln = @Vbeln " +
                                    "DELETE FROM [SAP_SIPARIS_DETAY] WHERE Vbeln = @Vbeln " +
                                    "DELETE FROM [SAP_VBFA] WHERE Vbeln = @Vbeln " +
                                    "INSERT INTO [SAP_SIPARIS_BASLIK] (KAYIT_TARIHI,[Vbeln],[Auart],[Bezei],[Audat],[Erdat],[Erzet],[Ernam],[Netwr],[Waerk],[Vkorg],[Vtext],[Vtweg],[Bzirk],[Bztxt],[Bstnk],[Kunnr],[Aedat],[Spart],[Vtext2],[Vkgrp],[Vkbur],[Kdgrp],[Ktext],[Name1],[Name2],[Name3],[Name4],[Name Text],[Name Co],[City1],[City2],[Street],[Region],[Sort1],[Deflt Comm],[Comm Text],[Tel Number],[Fax Number],[Stcd1],[Stcd2],[Post Code1],[Smtp Addr],[Pltyp],[Ptext],[OKunnr],[OStcd1],[OStcd2],[OName1],[ODeflt Comm],[OSmtp Addr],[OComm Text],[Yetkili],[Sip Aciklama],[Netpr],[Knumv],[Yetkili Kod],[Yetkili Ad],[Yetkili Tel],[Satsor Kod],[Satsor Ad],[Satsor Tel],[Sipalan Kod],[Sipalan Ad],[Sipalan Tel],[NamaSatici],[NamaSaticiAd],Vdatu,Bstkd) VALUES (@KAYIT_TARIHI,@Vbeln,@Auart,@Bezei,@Audat,@Erdat,@Erzet,@Ernam,@Netwr,@Waerk,@Vkorg,@Vtext,@Vtweg,@Bzirk,@Bztxt,@Bstnk,@Kunnr,@Aedat,@Spart,@Vtext2,@Vkgrp,@Vkbur,@Kdgrp,@Ktext,@Name1,@Name2,@Name3,@Name4,@NameText,@NameCo,@City1,@City2,@Street,@Region,@Sort1,@DefltComm,@CommText,@TelNumber,@FaxNumber,@Stcd1,@Stcd2,@PostCode1,@SmtpAddr,@Pltyp,@Ptext,@OKunnr,@OStcd1,@OStcd2,@OName1,@ODefltComm,@OSmtpAddr,@OCommText,@Yetkili,@SipAciklama,@Netpr,@Knumv,@YetkiliKod,@YetkiliAd,@YetkiliTel,@SatsorKod,@SatsorAd,@SatsorTel,@SipalanKod,@SipalanAd,@SipalanTel,@NamaSatici,@NamaSaticiAd,@Vdatu,@Bstkd)", conn);
                                #region parameters
                                cmd.Parameters.AddWithValue("@KAYIT_TARIHI", DateTime.Now);
                                cmd.Parameters.AddWithValue("@Vbeln", Convert.ToInt64(bes[j].Vbeln));
                                cmd.Parameters.AddWithValue("@Auart", bes[j].Auart);
                                cmd.Parameters.AddWithValue("@Bezei", bes[j].Bezei);
                                cmd.Parameters.AddWithValue("@Audat", Convert.ToDateTime(bes[j].Audat));
                                cmd.Parameters.AddWithValue("@Erdat", Convert.ToDateTime(bes[j].Erdat + " " + bes[j].Erzet));
                                cmd.Parameters.AddWithValue("@Erzet", bes[j].Erzet);
                                cmd.Parameters.AddWithValue("@Ernam", bes[j].Ernam);
                                cmd.Parameters.AddWithValue("@Netwr", bes[j].Netwr);
                                cmd.Parameters.AddWithValue("@Waerk", bes[j].Waerk);
                                cmd.Parameters.AddWithValue("@Vkorg", bes[j].Vkorg);
                                cmd.Parameters.AddWithValue("@Vtext", bes[j].Vtext);
                                cmd.Parameters.AddWithValue("@Vtweg", bes[j].Vtweg);
                                cmd.Parameters.AddWithValue("@Bzirk", bes[j].Bzirk);
                                cmd.Parameters.AddWithValue("@Bztxt", bes[j].Bztxt);
                                cmd.Parameters.AddWithValue("@Bstnk", bes[j].Bstnk);
                                cmd.Parameters.AddWithValue("@Kunnr", bes[j].Kunnr.StartsWith("T") || bes[j].Kunnr == "" ? 10 : Convert.ToInt32(bes[j].Kunnr));
                                cmd.Parameters.AddWithValue("@Aedat", bes[j].Aedat.StartsWith("0000") ? Convert.ToDateTime(bes[j].Audat) : Convert.ToDateTime(bes[j].Aedat));
                                cmd.Parameters.AddWithValue("@Spart", bes[j].Spart);
                                cmd.Parameters.AddWithValue("@Vtext2", bes[j].Vtext2);
                                cmd.Parameters.AddWithValue("@Vkgrp", bes[j].Vkgrp);
                                cmd.Parameters.AddWithValue("@Vkbur", bes[j].Vkbur);
                                cmd.Parameters.AddWithValue("@Kdgrp", bes[j].Kdgrp);
                                cmd.Parameters.AddWithValue("@Ktext", bes[j].Ktext);
                                cmd.Parameters.AddWithValue("@Name1", bes[j].Name1);
                                cmd.Parameters.AddWithValue("@Name2", bes[j].Name2);
                                cmd.Parameters.AddWithValue("@Name3", bes[j].Name3);
                                cmd.Parameters.AddWithValue("@Name4", bes[j].Name4);
                                cmd.Parameters.AddWithValue("@NameText", bes[j].NameText);
                                cmd.Parameters.AddWithValue("@NameCo", bes[j].NameCo);
                                cmd.Parameters.AddWithValue("@City1", bes[j].City1);
                                cmd.Parameters.AddWithValue("@City2", bes[j].City2);
                                cmd.Parameters.AddWithValue("@Street", bes[j].Street);
                                cmd.Parameters.AddWithValue("@Region", bes[j].Region);
                                cmd.Parameters.AddWithValue("@Sort1", bes[j].Sort1);
                                cmd.Parameters.AddWithValue("@DefltComm", bes[j].DefltComm);
                                cmd.Parameters.AddWithValue("@CommText", bes[j].CommText);
                                cmd.Parameters.AddWithValue("@TelNumber", bes[j].TelNumber);
                                cmd.Parameters.AddWithValue("@FaxNumber", bes[j].FaxNumber);
                                cmd.Parameters.AddWithValue("@Stcd1", bes[j].Stcd1);
                                cmd.Parameters.AddWithValue("@Stcd2", bes[j].Stcd2);
                                cmd.Parameters.AddWithValue("@PostCode1", bes[j].PostCode1);
                                cmd.Parameters.AddWithValue("@SmtpAddr", bes[j].SmtpAddr);
                                cmd.Parameters.AddWithValue("@Pltyp", bes[j].Pltyp);
                                cmd.Parameters.AddWithValue("@Ptext", bes[j].Ptext);
                                cmd.Parameters.AddWithValue("@OKunnr", bes[j].OKunnr.StartsWith("T") || bes[j].OKunnr == "" ? 10 : Convert.ToInt32(bes[j].OKunnr));
                                cmd.Parameters.AddWithValue("@OStcd1", bes[j].OStcd1);
                                cmd.Parameters.AddWithValue("@OStcd2", bes[j].OStcd2);
                                cmd.Parameters.AddWithValue("@OName1", bes[j].OName1);
                                cmd.Parameters.AddWithValue("@ODefltComm", bes[j].ODefltComm);
                                cmd.Parameters.AddWithValue("@OSmtpAddr", bes[j].OSmtpAddr);
                                cmd.Parameters.AddWithValue("@OCommText", bes[j].OCommText);
                                cmd.Parameters.AddWithValue("@Yetkili", bes[j].Yetkili);
                                cmd.Parameters.AddWithValue("@SipAciklama", bes[j].SipAciklama);
                                cmd.Parameters.AddWithValue("@Netpr", bes[j].Netpr);
                                cmd.Parameters.AddWithValue("@Knumv", bes[j].Knumv.StartsWith("T") || bes[j].Knumv == "" ? 10 : Convert.ToInt32(bes[j].Knumv));
                                cmd.Parameters.AddWithValue("@YetkiliKod", Convert.ToInt32(bes[j].YetkiliKod));
                                cmd.Parameters.AddWithValue("@YetkiliAd", bes[j].YetkiliAd);
                                cmd.Parameters.AddWithValue("@YetkiliTel", bes[j].YetkiliTel);
                                cmd.Parameters.AddWithValue("@SatsorKod", Convert.ToInt32(bes[j].SatsorKod));
                                cmd.Parameters.AddWithValue("@SatsorAd", bes[j].SatsorAd);
                                cmd.Parameters.AddWithValue("@SatsorTel", bes[j].SatsorTel);
                                cmd.Parameters.AddWithValue("@SipalanKod", Convert.ToInt32(bes[j].SipalanKod));
                                cmd.Parameters.AddWithValue("@SipalanAd", bes[j].SipalanAd);
                                cmd.Parameters.AddWithValue("@SipalanTel", bes[j].SipalanTel);
                                cmd.Parameters.AddWithValue("@NamaSatici", bes[j].NamaSatici);
                                cmd.Parameters.AddWithValue("@NamaSaticiAd", bes[j].NamaSaticiAd);
                                cmd.Parameters.AddWithValue("@Vdatu", bes[j].Vdatu);
                                cmd.Parameters.AddWithValue("@Bstkd", bes[j].Bstkd);
                                #endregion
                                cmd.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                SAPs.HataYaz("SAP_SIPARIS_BASLIK", Convert.ToInt64(bes[j].Vbeln).ToString(), "", "", "", "", ex.Message, cekilecektarih, cekilecektarih.AddDays(1));
                            }
                            conn.Close();
                        }
                    }
                    #endregion

                    #region item
                    if (oniki != null)
                    {
                        for (int j = 0; j < oniki.Length; j++)
                        {
                            try
                            {
                                conn.Open();
                                SqlCommand cmd = new SqlCommand(
                                    "DELETE FROM [SAP_SIPARIS_DETAY] WHERE Vbeln = @Vbeln AND Posnr = @Posnr " +
                                    "INSERT INTO [SAP_SIPARIS_DETAY] (KAYIT_TARIHI,[Vbeln],[Posnr],[Matnr],[Arktx],[Pltyp],[Ptext],[Zterm],[Netdt],[Matkl],[Wgbez],[Spart],[Vtext2],[Ean11],[Kwmeng],[Vrkme],[Vrkme Text],[Kwmeng2],[Vrkme2],[Vrkme2Text],[Ean112],[Yuz1],[Yuz2],[Yuz3],[Yuz4],[Yuz5],[Yuz6],[Yuz7],[Yuz8],[Yuz9],[Yuz10],[Brtpr],[Netpr],[Netwr],[Kzwi1],[Kdvoran],[Mwsbp],[Waerk],[Brgew],[Ntgew],[Gewei],[Volum],[Voleh],[Ksc1],[Ksc2],[Ksc3],[Ksc4],[Ksc5],[Ksc6],[Ksc7],[Ksc8],[Ksc9],[Ksc10],[Zzpirbz],[Zzpirgt],[Abgru],[Bezei_ab]) VALUES (@KAYIT_TARIHI,@Vbeln,@Posnr,@Matnr,@Arktx,@Pltyp,@Ptext,@Zterm,@Netdt,@Matkl,@Wgbez,@Spart,@Vtext2,@Ean11,@Kwmeng,@Vrkme,@VrkmeText,@Kwmeng2,@Vrkme2,@Vrkme2Text,@Ean112,@Yuz1,@Yuz2,@Yuz3,@Yuz4,@Yuz5,@Yuz6,@Yuz7,@Yuz8,@Yuz9,@Yuz10,@Brtpr,@Netpr,@Netwr,@Kzwi1,@Kdvoran,@Mwsbp,@Waerk,@Brgew,@Ntgew,@Gewei,@Volum,@Voleh,@Ksc1,@Ksc2,@Ksc3,@Ksc4,@Ksc5,@Ksc6,@Ksc7,@Ksc8,@Ksc9,@Ksc10,@Zzpirbz,@Zzpirgt,@Abgru,@Bezei_ab)", conn);
                                #region parameters
                                cmd.Parameters.AddWithValue("@KAYIT_TARIHI", DateTime.Now);
                                cmd.Parameters.AddWithValue("@Vbeln", Convert.ToInt64(oniki[j].Vbeln));
                                cmd.Parameters.AddWithValue("@Posnr", Convert.ToInt32(oniki[j].Posnr));
                                cmd.Parameters.AddWithValue("@Matnr", oniki[j].Matnr == string.Empty ? 0 : Convert.ToInt32(oniki[j].Matnr));
                                cmd.Parameters.AddWithValue("@Arktx", oniki[j].Arktx);
                                cmd.Parameters.AddWithValue("@Pltyp", oniki[j].Pltyp);
                                cmd.Parameters.AddWithValue("@Ptext", oniki[j].Ptext);
                                cmd.Parameters.AddWithValue("@Zterm", oniki[j].Zterm == string.Empty ? 0 : Convert.ToInt32(oniki[j].Zterm));
                                cmd.Parameters.AddWithValue("@Netdt", oniki[j].Netdt.StartsWith("0000") ? Convert.ToDateTime("01.01.1900") : Convert.ToDateTime(oniki[j].Netdt));
                                cmd.Parameters.AddWithValue("@Matkl", oniki[j].Matkl);
                                cmd.Parameters.AddWithValue("@Wgbez", oniki[j].Wgbez);
                                cmd.Parameters.AddWithValue("@Spart", oniki[j].Spart);
                                cmd.Parameters.AddWithValue("@Vtext2", oniki[j].Vtext2);
                                cmd.Parameters.AddWithValue("@Ean11", oniki[j].Ean11);
                                cmd.Parameters.AddWithValue("@Kwmeng", oniki[j].Kwmeng);
                                cmd.Parameters.AddWithValue("@Vrkme", oniki[j].Vrkme);
                                cmd.Parameters.AddWithValue("@VrkmeText", oniki[j].VrkmeText);
                                cmd.Parameters.AddWithValue("@Kwmeng2", oniki[j].Kwmeng2);
                                cmd.Parameters.AddWithValue("@Vrkme2", oniki[j].Vrkme2);
                                cmd.Parameters.AddWithValue("@Vrkme2Text", oniki[j].Vrkme2Text);
                                cmd.Parameters.AddWithValue("@Ean112", oniki[j].Ean112);
                                cmd.Parameters.AddWithValue("@Yuz1", oniki[j].Yuz1);
                                cmd.Parameters.AddWithValue("@Yuz2", oniki[j].Yuz2);
                                cmd.Parameters.AddWithValue("@Yuz3", oniki[j].Yuz3);
                                cmd.Parameters.AddWithValue("@Yuz4", oniki[j].Yuz4);
                                cmd.Parameters.AddWithValue("@Yuz5", oniki[j].Yuz5);
                                cmd.Parameters.AddWithValue("@Yuz6", oniki[j].Yuz6);
                                cmd.Parameters.AddWithValue("@Yuz7", oniki[j].Yuz7);
                                cmd.Parameters.AddWithValue("@Yuz8", oniki[j].Yuz8);
                                cmd.Parameters.AddWithValue("@Yuz9", oniki[j].Yuz9);
                                cmd.Parameters.AddWithValue("@Yuz10", oniki[j].Yuz10);
                                cmd.Parameters.AddWithValue("@Brtpr", oniki[j].Brtpr);
                                cmd.Parameters.AddWithValue("@Netpr", oniki[j].Netpr);
                                cmd.Parameters.AddWithValue("@Netwr", oniki[j].Netwr);
                                cmd.Parameters.AddWithValue("@Kzwi1", oniki[j].Kzwi1);
                                cmd.Parameters.AddWithValue("@Kdvoran", Convert.ToInt32(oniki[j].Kdvoran));
                                cmd.Parameters.AddWithValue("@Mwsbp", oniki[j].Mwsbp);
                                cmd.Parameters.AddWithValue("@Waerk", oniki[j].Waerk);
                                cmd.Parameters.AddWithValue("@Brgew", oniki[j].Brgew);
                                cmd.Parameters.AddWithValue("@Ntgew", oniki[j].Ntgew);
                                cmd.Parameters.AddWithValue("@Gewei", oniki[j].Gewei);
                                cmd.Parameters.AddWithValue("@Volum", oniki[j].Volum);
                                cmd.Parameters.AddWithValue("@Voleh", oniki[j].Voleh);
                                cmd.Parameters.AddWithValue("@Ksc1", oniki[j].Ksc1);
                                cmd.Parameters.AddWithValue("@Ksc2", oniki[j].Ksc2);
                                cmd.Parameters.AddWithValue("@Ksc3", oniki[j].Ksc3);
                                cmd.Parameters.AddWithValue("@Ksc4", oniki[j].Ksc4);
                                cmd.Parameters.AddWithValue("@Ksc5", oniki[j].Ksc5);
                                cmd.Parameters.AddWithValue("@Ksc6", oniki[j].Ksc6);
                                cmd.Parameters.AddWithValue("@Ksc7", oniki[j].Ksc7);
                                cmd.Parameters.AddWithValue("@Ksc8", oniki[j].Ksc8);
                                cmd.Parameters.AddWithValue("@Ksc9", oniki[j].Ksc9);
                                cmd.Parameters.AddWithValue("@Ksc10", oniki[j].Ksc10);
                                cmd.Parameters.AddWithValue("@Zzpirbz", oniki[j].Zzpirbz);
                                cmd.Parameters.AddWithValue("@Zzpirgt", oniki[j].Zzpirgt);
                                cmd.Parameters.AddWithValue("@Abgru", oniki[j].Abgru);
                                cmd.Parameters.AddWithValue("@Bezei_ab", oniki[j].BezeiAb);
                                #endregion
                                cmd.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                SAPs.HataYaz("SAP_SIPARIS_DETAY", Convert.ToInt64(oniki[j].Vbeln).ToString(), Convert.ToInt32(oniki[j].Posnr).ToString(), "", "", "", ex.Message, cekilecektarih, cekilecektarih.AddDays(1));
                            }
                            conn.Close();
                        }
                    }
                    #endregion

                    #region vbfa
                    if (dokuz != null)
                    {
                        for (int j = 0; j < dokuz.Length; j++)
                        {
                            try
                            {
                                conn.Open();
                                SqlCommand cmd = new SqlCommand("sp_SAP_VBFA_InsertUpdate2", conn);
                                cmd.CommandType = CommandType.StoredProcedure;
                                #region parameters
                                cmd.Parameters.AddWithValue("@KAYIT_TARIHI", DateTime.Now);
                                cmd.Parameters.AddWithValue("@Vbelv", Convert.ToInt64(dokuz[j].Vbelv));
                                cmd.Parameters.AddWithValue("@Posnv", Convert.ToInt32(dokuz[j].Posnv));
                                cmd.Parameters.AddWithValue("@Vbeln", Convert.ToInt64(dokuz[j].Vbeln));
                                cmd.Parameters.AddWithValue("@Posnn", Convert.ToInt32(dokuz[j].Posnn));
                                cmd.Parameters.AddWithValue("@VbtypN", dokuz[j].VbtypN);
                                cmd.Parameters.AddWithValue("@Rfmng", dokuz[j].Rfmng);
                                cmd.Parameters.AddWithValue("@Meins", dokuz[j].Meins);
                                cmd.Parameters.AddWithValue("@Rfwrt", dokuz[j].Rfwrt);
                                cmd.Parameters.AddWithValue("@Waers", dokuz[j].Waers);
                                cmd.Parameters.AddWithValue("@VbtypV", dokuz[j].VbtypV);
                                cmd.Parameters.AddWithValue("@Plmin", dokuz[j].Plmin);
                                cmd.Parameters.AddWithValue("@Taqui", dokuz[j].Taqui);
                                cmd.Parameters.AddWithValue("@Erdat", Convert.ToDateTime(dokuz[j].Erdat + " " + dokuz[j].Erzet));
                                cmd.Parameters.AddWithValue("@Erzet", dokuz[j].Erzet);
                                cmd.Parameters.AddWithValue("@Matnr", dokuz[j].Matnr == string.Empty ? 0 : Convert.ToInt32(dokuz[j].Matnr));
                                cmd.Parameters.AddWithValue("@Bwart", dokuz[j].Bwart);
                                cmd.Parameters.AddWithValue("@Bdart", dokuz[j].Bdart);
                                cmd.Parameters.AddWithValue("@Plart", dokuz[j].Plart);
                                cmd.Parameters.AddWithValue("@Stufe", dokuz[j].Stufe);
                                cmd.Parameters.AddWithValue("@Lgnum", dokuz[j].Lgnum);
                                cmd.Parameters.AddWithValue("@Aedat", dokuz[j].Aedat.StartsWith("0000") ? Convert.ToDateTime("01.01.1900") : Convert.ToDateTime(dokuz[j].Aedat));
                                cmd.Parameters.AddWithValue("@Fktyp", dokuz[j].Fktyp);
                                cmd.Parameters.AddWithValue("@Brgew", dokuz[j].Brgew);
                                cmd.Parameters.AddWithValue("@Gewei", dokuz[j].Gewei);
                                cmd.Parameters.AddWithValue("@Volum", dokuz[j].Volum);
                                cmd.Parameters.AddWithValue("@Voleh", dokuz[j].Voleh);
                                cmd.Parameters.AddWithValue("@Fplnr", dokuz[j].Fplnr);
                                cmd.Parameters.AddWithValue("@Fpltr", dokuz[j].Fpltr);
                                cmd.Parameters.AddWithValue("@RfmngFlo", dokuz[j].RfmngFlo);
                                cmd.Parameters.AddWithValue("@RfmngFlt", dokuz[j].RfmngFlt);
                                cmd.Parameters.AddWithValue("@Vrkme", dokuz[j].Vrkme);
                                cmd.Parameters.AddWithValue("@Abges", dokuz[j].Abges);
                                cmd.Parameters.AddWithValue("@Sobkz", dokuz[j].Sobkz);
                                cmd.Parameters.AddWithValue("@Sonum", dokuz[j].Sonum);
                                cmd.Parameters.AddWithValue("@Kzbef", dokuz[j].Kzbef);
                                cmd.Parameters.AddWithValue("@Ntgew", dokuz[j].Ntgew);
                                cmd.Parameters.AddWithValue("@Logsys", dokuz[j].Logsys);
                                cmd.Parameters.AddWithValue("@Wbsta", dokuz[j].Wbsta);
                                cmd.Parameters.AddWithValue("@Cmeth", dokuz[j].Cmeth);
                                cmd.Parameters.AddWithValue("@Mjahr", dokuz[j].Mjahr);
                                cmd.Parameters.AddWithValue("@Vkorg", dokuz[j].Vkorg);
                                cmd.Parameters.AddWithValue("@Spart", dokuz[j].Spart);
                                #endregion
                                cmd.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                SAPs.HataYaz("SAP_VBFA", Convert.ToInt64(dokuz[j].Vbelv).ToString(), Convert.ToInt32(dokuz[j].Posnv).ToString(), Convert.ToInt64(dokuz[j].Vbeln).ToString(), Convert.ToInt32(dokuz[j].Posnn).ToString(), dokuz[j].VbtypN, "(SIPARIS) - " + ex.Message, cekilecektarih, cekilecektarih.AddDays(1));
                            }
                            conn.Close();
                        }
                    }
                    #endregion

                    cekilecektarih = cekilecektarih.AddDays(1);
                }

                if (!hatavar)
                    MaxTarihYaz(conn, "SAP_Siparis", bitistarih);
            }
            #endregion



            #region TESLIMAT
            if (teslimat)
            {
                DateTime maxtarih = MaxTarihGetir(conn, "SAP_Teslimat");
                DateTime bitistarih = DateTime.Now;
                bool hatavar = false;

                selectsalesdeliveryC.ZwebSelectSalesDeliveryService client3 = new selectsalesdeliveryC.ZwebSelectSalesDeliveryService();
                client3.Timeout = 6000000;
                client3.Credentials = nc1;

                DateTime cekilecektarih = maxtarih;
                DateTime simdikitarih = DateTime.Now;
                while (Convert.ToDateTime(cekilecektarih.ToShortDateString()) <= Convert.ToDateTime(simdikitarih.ToShortDateString()))
                {
                    selectsalesdeliveryC.Zwebs009[] dokuz = null; // vbfa
                    selectsalesdeliveryC.Zwebs006[] alti = null; // head
                    selectsalesdeliveryC.Zwebs013[] onuc = null; // item
                    selectsalesdeliveryC.Zwebs021[] yirmibir = null; // logdel

                    string hata = string.Empty;
                    string tarih = "";
                    string saat = "00:00:00";

                    int tekrarcek = 0;
                    while (tekrarcek < tekrarcekilecek)
                    {
                        try
                        {
                            TarihSaat(maxtarih, cekilecektarih, out tarih, out saat);
                            alti = client3.ZwebSelectSalesDelivery(tarih, "", saat, out onuc, out yirmibir, out dokuz);
                            tekrarcek = tekrarcekilecek;
                        }
                        catch (Exception ex)
                        {
                            SAPs.LogYaz("select sales delivery", true, cekilecektarih.ToShortDateString() + " " + (tekrarcek + 1).ToString() + ".deneme sap hata döndürdü: " + ex.Message, DateTime.Now, DateTime.Now);
                            if (tekrarcek < tekrarcekilecek)
                            {
                                tekrarcek++;
                                System.Threading.Thread.Sleep(3000);
                            }
                            else
                            {
                                hata = ex.Message;
                                hatavar = true;
                                cekilecektarih = DateTime.Now; // while dan çıksın bir sonraki günü almasın max tarihi yenilemesin
                            }
                        }
                    }

                    SAPs.LogYaz("select sales delivery", hata != string.Empty ? false : true, hata, Convert.ToDateTime(cekilecektarih.ToShortDateString() + " " + saat), Convert.ToDateTime(cekilecektarih.ToShortDateString()) == Convert.ToDateTime(simdikitarih.ToShortDateString()) ? DateTime.Now : Convert.ToDateTime(cekilecektarih.AddDays(1).ToShortDateString() + " 00:00:00"));

                    #region logdel
                    if (yirmibir != null)
                    {
                        for (int j = 0; j < yirmibir.Length; j++)
                        {
                            try
                            {
                                conn.Open();
                                SqlCommand cmd = new SqlCommand("DELETE FROM [SAP_TESLIMAT_BASLIK] WHERE Vbeln = @Vbeln DELETE FROM [SAP_TESLIMAT_DETAY] WHERE Vbeln = @Vbeln DELETE FROM [SAP_VBFA] WHERE Vbelv = @Vbeln DELETE FROM [SAP_VBFA] WHERE Vbeln = @Vbeln", conn);
                                cmd.Parameters.AddWithValue("@Vbeln", Convert.ToInt64(yirmibir[j].Vbeln));
                                cmd.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                SAPs.HataYaz("SAP_TESLIMAT_BASLIK", Convert.ToInt64(yirmibir[j].Vbeln).ToString(), "", "", "", "", "(LOGDEL) - " + ex.Message, cekilecektarih, cekilecektarih.AddDays(1));
                            }
                            conn.Close();
                        }
                    }
                    #endregion

                    #region head
                    if (alti != null)
                    {
                        for (int j = 0; j < alti.Length; j++)
                        {
                            try
                            {
                                conn.Open();
                                SqlCommand cmd = new SqlCommand(
                                    "DELETE FROM [SAP_TESLIMAT_BASLIK] WHERE Vbeln = @Vbeln " +
                                    "DELETE FROM [SAP_TESLIMAT_DETAY] WHERE Vbeln = @Vbeln " +
                                    "DELETE FROM [SAP_VBFA] WHERE Vbeln = @Vbeln " +
                                    "DELETE FROM [SAP_VBFA] WHERE Vbelv = @Vbeln " +
                                    "INSERT INTO [SAP_TESLIMAT_BASLIK] (KAYIT_TARIHI,[Lfart],[Vtext],[Vbeln],[Ernam],[Erzet],[Erdat],[Sevkalani],[Sevkyeri],[Teslimat Aciklama],[Volum],[Btgew],[Voleh],[Gewei],[Lifex],Vkorg) VALUES (@KAYIT_TARIHI,@Lfart,@Vtext,@Vbeln,@Ernam,@Erzet,@Erdat,@Sevkalani,@Sevkyeri,@TeslimatAciklama,@Volum,@Btgew,@Voleh,@Gewei,@Lifex,@Vkorg)", conn);
                                #region parameters
                                cmd.Parameters.AddWithValue("@KAYIT_TARIHI", DateTime.Now);
                                cmd.Parameters.AddWithValue("@Lfart", alti[j].Lfart);
                                cmd.Parameters.AddWithValue("@Vtext", alti[j].Vtext);
                                cmd.Parameters.AddWithValue("@Vbeln", Convert.ToInt64(alti[j].Vbeln));
                                cmd.Parameters.AddWithValue("@Ernam", alti[j].Ernam);
                                cmd.Parameters.AddWithValue("@Erzet", alti[j].Erzet);
                                cmd.Parameters.AddWithValue("@Erdat", Convert.ToDateTime(alti[j].Erdat + " " + alti[j].Erzet));
                                cmd.Parameters.AddWithValue("@Sevkalani", alti[j].Sevkalani);
                                cmd.Parameters.AddWithValue("@Sevkyeri", alti[j].Sevkyeri);
                                cmd.Parameters.AddWithValue("@TeslimatAciklama", alti[j].TeslimatAciklama);
                                cmd.Parameters.AddWithValue("@Volum", alti[j].Volum);
                                cmd.Parameters.AddWithValue("@Btgew", alti[j].Btgew);
                                cmd.Parameters.AddWithValue("@Voleh", alti[j].Voleh);
                                cmd.Parameters.AddWithValue("@Gewei", alti[j].Gewei);
                                cmd.Parameters.AddWithValue("@Lifex", alti[j].Lifex);
                                cmd.Parameters.AddWithValue("@Vkorg", alti[j].Vkorg);
                                #endregion
                                cmd.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                SAPs.HataYaz("SAP_TESLIMAT_BASLIK", Convert.ToInt64(alti[j].Vbeln).ToString(), "", "", "", "", ex.Message, cekilecektarih, cekilecektarih.AddDays(1));
                            }
                            conn.Close();
                        }
                    }
                    #endregion

                    #region item
                    if (onuc != null)
                    {
                        for (int j = 0; j < onuc.Length; j++)
                        {
                            try
                            {
                                conn.Open();
                                SqlCommand cmd = new SqlCommand(
                                    "DELETE FROM [SAP_TESLIMAT_DETAY] WHERE Vbeln = @Vbeln AND Posnr = @Posnr " +
                                    "INSERT INTO [SAP_TESLIMAT_DETAY] (KAYIT_TARIHI,[Vbeln],[Posnr],[Matnr],[Ernam],[Erzet],[Erdat],[Matkl],[Werks],[Lgort],[Charg],[Lfimg],[Meins],[Meins Text],[Ntgew],[Brgew],[Gewei],[Volum],[Voleh],Hsdat,Spart) VALUES (@KAYIT_TARIHI,@Vbeln,@Posnr,@Matnr,@Ernam,@Erzet,@Erdat,@Matkl,@Werks,@Lgort,@Charg,@Lfimg,@Meins,@MeinsText,@Ntgew,@Brgew,@Gewei,@Volum,@Voleh,@Hsdat,@Spart)", conn);
                                #region parameters
                                cmd.Parameters.AddWithValue("@KAYIT_TARIHI", DateTime.Now);
                                cmd.Parameters.AddWithValue("@Vbeln", Convert.ToInt64(onuc[j].Vbeln));
                                cmd.Parameters.AddWithValue("@Posnr", Convert.ToInt32(onuc[j].Posnr));
                                cmd.Parameters.AddWithValue("@Matnr", onuc[j].Matnr == string.Empty ? 0 : Convert.ToInt32(onuc[j].Matnr));
                                cmd.Parameters.AddWithValue("@Ernam", onuc[j].Ernam);
                                cmd.Parameters.AddWithValue("@Erzet", onuc[j].Erzet);
                                cmd.Parameters.AddWithValue("@Erdat", Convert.ToDateTime(onuc[j].Erdat + " " + onuc[j].Erzet));
                                cmd.Parameters.AddWithValue("@Matkl", onuc[j].Matkl);
                                cmd.Parameters.AddWithValue("@Werks", onuc[j].Werks);
                                cmd.Parameters.AddWithValue("@Lgort", onuc[j].Lgort);
                                cmd.Parameters.AddWithValue("@Charg", onuc[j].Charg);
                                cmd.Parameters.AddWithValue("@Lfimg", onuc[j].Lfimg);
                                cmd.Parameters.AddWithValue("@Meins", onuc[j].Meins);
                                cmd.Parameters.AddWithValue("@MeinsText", onuc[j].MeinsText);
                                cmd.Parameters.AddWithValue("@Ntgew", onuc[j].Ntgew);
                                cmd.Parameters.AddWithValue("@Brgew", onuc[j].Brgew);
                                cmd.Parameters.AddWithValue("@Gewei", onuc[j].Gewei);
                                cmd.Parameters.AddWithValue("@Volum", onuc[j].Volum);
                                cmd.Parameters.AddWithValue("@Voleh", onuc[j].Voleh);
                                cmd.Parameters.AddWithValue("@Hsdat", (onuc[j].Hsdat != "0000-00-00" ? (Convert.ToDateTime(onuc[j].Hsdat) < Convert.ToDateTime("01.01.1900") ? Convert.ToDateTime("01.01.1900") : Convert.ToDateTime(onuc[j].Hsdat)) : Convert.ToDateTime("01.01.1900")));
                                cmd.Parameters.AddWithValue("@Spart", onuc[j].Spart);
                                #endregion
                                cmd.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                SAPs.HataYaz("SAP_TESLIMAT_DETAY", Convert.ToInt64(onuc[j].Vbeln).ToString(), Convert.ToInt32(onuc[j].Posnr).ToString(), "", "", "", ex.Message, cekilecektarih, cekilecektarih.AddDays(1));
                            }
                            conn.Close();
                        }
                    }
                    #endregion

                    #region vbfa
                    if (dokuz != null)
                    {
                        for (int j = 0; j < dokuz.Length; j++)
                        {
                            try
                            {
                                conn.Open();
                                SqlCommand cmd = new SqlCommand("sp_SAP_VBFA_InsertUpdate2", conn);
                                cmd.CommandType = CommandType.StoredProcedure;
                                #region parameters
                                cmd.Parameters.AddWithValue("@KAYIT_TARIHI", DateTime.Now);
                                cmd.Parameters.AddWithValue("@Vbelv", Convert.ToInt64(dokuz[j].Vbelv));
                                cmd.Parameters.AddWithValue("@Posnv", Convert.ToInt32(dokuz[j].Posnv));
                                cmd.Parameters.AddWithValue("@Vbeln", Convert.ToInt64(dokuz[j].Vbeln));
                                cmd.Parameters.AddWithValue("@Posnn", Convert.ToInt32(dokuz[j].Posnn));
                                cmd.Parameters.AddWithValue("@VbtypN", dokuz[j].VbtypN);
                                cmd.Parameters.AddWithValue("@Rfmng", dokuz[j].Rfmng);
                                cmd.Parameters.AddWithValue("@Meins", dokuz[j].Meins);
                                cmd.Parameters.AddWithValue("@Rfwrt", dokuz[j].Rfwrt);
                                cmd.Parameters.AddWithValue("@Waers", dokuz[j].Waers);
                                cmd.Parameters.AddWithValue("@VbtypV", dokuz[j].VbtypV);
                                cmd.Parameters.AddWithValue("@Plmin", dokuz[j].Plmin);
                                cmd.Parameters.AddWithValue("@Taqui", dokuz[j].Taqui);
                                cmd.Parameters.AddWithValue("@Erdat", Convert.ToDateTime(dokuz[j].Erdat + " " + dokuz[j].Erzet));
                                cmd.Parameters.AddWithValue("@Erzet", dokuz[j].Erzet);
                                cmd.Parameters.AddWithValue("@Matnr", dokuz[j].Matnr == string.Empty ? 0 : Convert.ToInt32(dokuz[j].Matnr));
                                cmd.Parameters.AddWithValue("@Bwart", dokuz[j].Bwart);
                                cmd.Parameters.AddWithValue("@Bdart", dokuz[j].Bdart);
                                cmd.Parameters.AddWithValue("@Plart", dokuz[j].Plart);
                                cmd.Parameters.AddWithValue("@Stufe", dokuz[j].Stufe);
                                cmd.Parameters.AddWithValue("@Lgnum", dokuz[j].Lgnum);
                                cmd.Parameters.AddWithValue("@Aedat", dokuz[j].Aedat.StartsWith("0000") ? Convert.ToDateTime("01.01.1900") : Convert.ToDateTime(dokuz[j].Aedat));
                                cmd.Parameters.AddWithValue("@Fktyp", dokuz[j].Fktyp);
                                cmd.Parameters.AddWithValue("@Brgew", dokuz[j].Brgew);
                                cmd.Parameters.AddWithValue("@Gewei", dokuz[j].Gewei);
                                cmd.Parameters.AddWithValue("@Volum", dokuz[j].Volum);
                                cmd.Parameters.AddWithValue("@Voleh", dokuz[j].Voleh);
                                cmd.Parameters.AddWithValue("@Fplnr", dokuz[j].Fplnr);
                                cmd.Parameters.AddWithValue("@Fpltr", dokuz[j].Fpltr);
                                cmd.Parameters.AddWithValue("@RfmngFlo", dokuz[j].RfmngFlo);
                                cmd.Parameters.AddWithValue("@RfmngFlt", dokuz[j].RfmngFlt);
                                cmd.Parameters.AddWithValue("@Vrkme", dokuz[j].Vrkme);
                                cmd.Parameters.AddWithValue("@Abges", dokuz[j].Abges);
                                cmd.Parameters.AddWithValue("@Sobkz", dokuz[j].Sobkz);
                                cmd.Parameters.AddWithValue("@Sonum", dokuz[j].Sonum);
                                cmd.Parameters.AddWithValue("@Kzbef", dokuz[j].Kzbef);
                                cmd.Parameters.AddWithValue("@Ntgew", dokuz[j].Ntgew);
                                cmd.Parameters.AddWithValue("@Logsys", dokuz[j].Logsys);
                                cmd.Parameters.AddWithValue("@Wbsta", dokuz[j].Wbsta);
                                cmd.Parameters.AddWithValue("@Cmeth", dokuz[j].Cmeth);
                                cmd.Parameters.AddWithValue("@Mjahr", dokuz[j].Mjahr);
                                cmd.Parameters.AddWithValue("@Vkorg", dokuz[j].Vkorg);
                                cmd.Parameters.AddWithValue("@Spart", dokuz[j].Spart);
                                #endregion
                                cmd.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                SAPs.HataYaz("SAP_VBFA", Convert.ToInt64(dokuz[j].Vbelv).ToString(), Convert.ToInt32(dokuz[j].Posnv).ToString(), Convert.ToInt64(dokuz[j].Vbeln).ToString(), Convert.ToInt32(dokuz[j].Posnn).ToString(), dokuz[j].VbtypN, "(TESLIMAT) - " + ex.Message, cekilecektarih, cekilecektarih.AddDays(1));
                            }
                            conn.Close();
                        }
                    }
                    #endregion

                    cekilecektarih = cekilecektarih.AddDays(1);
                }

                if (!hatavar)
                    MaxTarihYaz(conn, "SAP_Teslimat", bitistarih);
            }
            #endregion



            #region NAKILSIPARIS MALCIKIS FATURA
            if (nakilmalfatura)
            {
                DateTime maxtarih = MaxTarihGetir(conn, "SAP_NakilMalFatura");
                DateTime bitistarih = DateTime.Now;
                bool hatavar = false;

                selectsalestransportC.ZwebSelectSalesTransportService client4 = new selectsalestransportC.ZwebSelectSalesTransportService();
                client4.Timeout = 6000000;
                client4.Credentials = nc1;

                DateTime cekilecektarih = maxtarih;
                DateTime simdikitarih = DateTime.Now;
                while (Convert.ToDateTime(cekilecektarih.ToShortDateString()) <= Convert.ToDateTime(simdikitarih.ToShortDateString()))
                {
                    selectsalestransportC.Zwebs007[] yedi = null;
                    selectsalestransportC.Zwebs014[] ondort = null;
                    selectsalestransportC.Zwebs015[] onbes = null;
                    selectsalestransportC.Zwebs016[] onalti = null;
                    selectsalestransportC.Zwebs017[] onyedi = null;
                    selectsalestransportC.Zwebs018[] onsekiz = null;

                    string hata = string.Empty;
                    string tarih = "";
                    string saat = "00:00:00";

                    int tekrarcek = 0;
                    while (tekrarcek < tekrarcekilecek)
                    {
                        try
                        {
                            TarihSaat(maxtarih, cekilecektarih, out tarih, out saat);
                            onbes = client4.ZwebSelectSalesTransport(tarih, saat, out onalti, out onyedi, out onsekiz, out yedi, out ondort);
                            tekrarcek = tekrarcekilecek;
                        }
                        catch (Exception ex)
                        {
                            SAPs.LogYaz("select sales transport", true, cekilecektarih.ToShortDateString() + " " + (tekrarcek + 1).ToString() + ".deneme sap hata döndürdü: " + ex.Message, DateTime.Now, DateTime.Now);
                            if (tekrarcek < tekrarcekilecek)
                            {
                                tekrarcek++;
                                System.Threading.Thread.Sleep(3000);
                            }
                            else
                            {
                                hata = ex.Message;
                                hatavar = true;
                                cekilecektarih = DateTime.Now; // while dan çıksın bir sonraki günü almasın max tarihi yenilemesin
                            }
                        }
                    }

                    SAPs.LogYaz("select sales transport", hata != string.Empty ? false : true, hata, Convert.ToDateTime(cekilecektarih.ToShortDateString() + " " + saat), Convert.ToDateTime(cekilecektarih.ToShortDateString()) == Convert.ToDateTime(simdikitarih.ToShortDateString()) ? DateTime.Now : Convert.ToDateTime(cekilecektarih.AddDays(1).ToShortDateString() + " 00:00:00"));

                    #region nakilsiparis

                    #region head
                    if (nakilsiparis && yedi != null)
                    {
                        for (int j = 0; j < yedi.Length; j++)
                        {
                            try
                            {
                                conn.Open();
                                SqlCommand cmd = new SqlCommand(
                                    "DELETE FROM [SAP_NAKILSIPARIS_BASLIK] WHERE Lgnum = @Lgnum AND Tanum = @Tanum " +
                                    "INSERT INTO [SAP_NAKILSIPARIS_BASLIK] (KAYIT_TARIHI,[Lgnum],[Tanum],[Qdatu],[Lgtor],[Koliadet]) VALUES (@KAYIT_TARIHI,@Lgnum,@Tanum,@Qdatu,@Lgtor,@Koliadet)", conn);
                                #region parameters
                                cmd.Parameters.AddWithValue("@KAYIT_TARIHI", DateTime.Now);
                                cmd.Parameters.AddWithValue("@Lgnum", yedi[j].Lgnum);
                                cmd.Parameters.AddWithValue("@Tanum", Convert.ToInt32(yedi[j].Tanum));
                                cmd.Parameters.AddWithValue("@Qdatu", yedi[j].Qdatu.StartsWith("0000") ? Convert.ToDateTime("01.01.1900") : Convert.ToDateTime(yedi[j].Qdatu));
                                cmd.Parameters.AddWithValue("@Lgtor", yedi[j].Lgtor);
                                cmd.Parameters.AddWithValue("@Koliadet", yedi[j].Koliadet);
                                #endregion
                                cmd.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                SAPs.HataYaz("SAP_NAKILSIPARIS_BASLIK", yedi[j].Lgnum, yedi[j].Tanum, "", "", "", ex.Message, cekilecektarih, cekilecektarih.AddDays(1));
                            }
                            conn.Close();
                        }
                    }
                    #endregion

                    #region item
                    if (nakilsiparis && ondort != null)
                    {
                        for (int j = 0; j < ondort.Length; j++)
                        {
                            try
                            {
                                conn.Open();
                                SqlCommand cmd = new SqlCommand(
                                    "DELETE FROM [SAP_NAKILSIPARIS_DETAY] WHERE Lgnum = @Lgnum AND Tanum = @Tanum AND Tapos = @Tapos " +
                                    "INSERT INTO [SAP_NAKILSIPARIS_DETAY] (KAYIT_TARIHI,[Lgnum],[Tanum],[Tapos],[Matnr],[Maktx],[Werks],[Charg],[Pquit],[Qdatu],[Qzeit],[Qname],[Brgew],[Gewei],[Ablad],[Volum],[Voleh],[Vbeln],[Vsolm],[Vistm],[Vdifm],[Meins],[Meins Text],[Vlber],[Vlpla],[Nlber],[Nlpla]) VALUES (@KAYIT_TARIHI,@Lgnum,@Tanum,@Tapos,@Matnr,@Maktx,@Werks,@Charg,@Pquit,@Qdatu,@Qzeit,@Qname,@Brgew,@Gewei,@Ablad,@Volum,@Voleh,@Vbeln,@Vsolm,@Vistm,@Vdifm,@Meins,@MeinsText,@Vlber,@Vlpla,@Nlber,@Nlpla)", conn);
                                #region parameters
                                cmd.Parameters.AddWithValue("@KAYIT_TARIHI", DateTime.Now);
                                cmd.Parameters.AddWithValue("@Lgnum", ondort[j].Lgnum);
                                cmd.Parameters.AddWithValue("@Tanum", Convert.ToInt32(ondort[j].Tanum));
                                cmd.Parameters.AddWithValue("@Tapos", Convert.ToInt32(ondort[j].Tapos));
                                cmd.Parameters.AddWithValue("@Matnr", ondort[j].Matnr == string.Empty ? 0 : Convert.ToInt32(ondort[j].Matnr));
                                cmd.Parameters.AddWithValue("@Maktx", ondort[j].Maktx);
                                cmd.Parameters.AddWithValue("@Werks", ondort[j].Werks);
                                cmd.Parameters.AddWithValue("@Charg", ondort[j].Charg);
                                cmd.Parameters.AddWithValue("@Pquit", ondort[j].Pquit);
                                cmd.Parameters.AddWithValue("@Qdatu", ondort[j].Qdatu.StartsWith("0000") ? Convert.ToDateTime("01.01.1900") : Convert.ToDateTime(ondort[j].Qdatu));
                                cmd.Parameters.AddWithValue("@Qzeit", ondort[j].Qzeit);
                                cmd.Parameters.AddWithValue("@Qname", ondort[j].Qname);
                                cmd.Parameters.AddWithValue("@Brgew", ondort[j].Brgew);
                                cmd.Parameters.AddWithValue("@Gewei", ondort[j].Gewei);
                                cmd.Parameters.AddWithValue("@Ablad", ondort[j].Ablad);
                                cmd.Parameters.AddWithValue("@Volum", ondort[j].Volum);
                                cmd.Parameters.AddWithValue("@Voleh", ondort[j].Voleh);
                                cmd.Parameters.AddWithValue("@Vbeln", ondort[j].Vbeln == string.Empty ? 0 : Convert.ToInt64(ondort[j].Vbeln));
                                cmd.Parameters.AddWithValue("@Vsolm", ondort[j].Vsolm);
                                cmd.Parameters.AddWithValue("@Vistm", ondort[j].Vistm);
                                cmd.Parameters.AddWithValue("@Vdifm", ondort[j].Vdifm);
                                cmd.Parameters.AddWithValue("@Meins", ondort[j].Meins);
                                cmd.Parameters.AddWithValue("@MeinsText", ondort[j].MeinsText);
                                cmd.Parameters.AddWithValue("@Vlber", ondort[j].Vlber);
                                cmd.Parameters.AddWithValue("@Vlpla", ondort[j].Vlpla);
                                cmd.Parameters.AddWithValue("@Nlber", ondort[j].Nlber);
                                cmd.Parameters.AddWithValue("@Nlpla", ondort[j].Nlpla);
                                #endregion
                                cmd.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                SAPs.HataYaz("SAP_NAKILSIPARIS_DETAY", ondort[j].Lgnum, ondort[j].Tanum, ondort[j].Tapos, "", "", ex.Message, cekilecektarih, cekilecektarih.AddDays(1));
                            }
                            conn.Close();
                        }
                    }
                    #endregion

                    #endregion

                    #region malcikis

                    #region head
                    if (malcikis && onbes != null)
                    {
                        for (int j = 0; j < onbes.Length; j++)
                        {
                            try
                            {
                                conn.Open();
                                SqlCommand cmd = new SqlCommand(
                                    "DELETE FROM [SAP_MALCIKIS_BASLIK] WHERE Mblnr = @Mblnr AND Mjahr = @Mjahr " +
                                    "INSERT INTO [SAP_MALCIKIS_BASLIK] (KAYIT_TARIHI,[Mblnr],[Mjahr],[Blart],[Ltext],[Vgart],[Ltext2],[Bldat],[Budat],[Le Vbeln]) VALUES (@KAYIT_TARIHI,@Mblnr,@Mjahr,@Blart,@Ltext,@Vgart,@Ltext2,@Bldat,@Budat,@LeVbeln)", conn);
                                #region parameters
                                cmd.Parameters.AddWithValue("@KAYIT_TARIHI", DateTime.Now);
                                cmd.Parameters.AddWithValue("@Mblnr", Convert.ToInt64(onbes[j].Mblnr));
                                cmd.Parameters.AddWithValue("@Mjahr", Convert.ToInt32(onbes[j].Mjahr));
                                cmd.Parameters.AddWithValue("@Blart", onbes[j].Blart);
                                cmd.Parameters.AddWithValue("@Ltext", onbes[j].Ltext);
                                cmd.Parameters.AddWithValue("@Vgart", onbes[j].Vgart);
                                cmd.Parameters.AddWithValue("@Ltext2", onbes[j].Ltext2);
                                cmd.Parameters.AddWithValue("@Bldat", onbes[j].Bldat.StartsWith("0000") ? Convert.ToDateTime("01.01.1900") : Convert.ToDateTime(onbes[j].Bldat));
                                cmd.Parameters.AddWithValue("@Budat", onbes[j].Budat.StartsWith("0000") ? Convert.ToDateTime("01.01.1900") : Convert.ToDateTime(onbes[j].Budat));
                                cmd.Parameters.AddWithValue("@LeVbeln", onbes[j].LeVbeln);
                                #endregion
                                cmd.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                SAPs.HataYaz("SAP_MALCIKIS_BASLIK", onbes[j].Mblnr, onbes[j].Mjahr, "", "", "", ex.Message, cekilecektarih, cekilecektarih.AddDays(1));
                            }
                            conn.Close();
                        }
                    }
                    #endregion

                    #region item
                    if (malcikis && onalti != null)
                    {
                        for (int j = 0; j < onalti.Length; j++)
                        {
                            try
                            {
                                conn.Open();
                                SqlCommand cmd = new SqlCommand(
                                    "DELETE FROM [SAP_MALCIKIS_DETAY] WHERE Mblnr = @Mblnr AND Mjahr = @Mjahr AND Zeile = @Zeile " +
                                    "INSERT INTO [SAP_MALCIKIS_DETAY] (KAYIT_TARIHI,[Mblnr],[Mjahr],[Zeile],[Matnr],[Werks],[Lgort],[Charg],[Kunnr],[Menge],[Meins],[Meins Text],[Lgnum],[Lgtyp],[Lgpla],[Sjahr],[Smbln],[Smblp],[Vbeln Vl],[Posnr Vl],[Vbeln],[Posnr]) VALUES (@KAYIT_TARIHI,@Mblnr,@Mjahr,@Zeile,@Matnr,@Werks,@Lgort,@Charg,@Kunnr,@Menge,@Meins,@MeinsText,@Lgnum,@Lgtyp,@Lgpla,@Sjahr,@Smbln,@Smblp,@VbelnVl,@PosnrVl,@Vbeln,@Posnr)", conn);
                                #region parameters
                                cmd.Parameters.AddWithValue("@KAYIT_TARIHI", DateTime.Now);
                                cmd.Parameters.AddWithValue("@Mblnr", Convert.ToInt64(onalti[j].Mblnr));
                                cmd.Parameters.AddWithValue("@Mjahr", Convert.ToInt32(onalti[j].Mjahr));
                                cmd.Parameters.AddWithValue("@Zeile", Convert.ToInt32(onalti[j].Zeile));
                                cmd.Parameters.AddWithValue("@Matnr", onalti[j].Matnr == string.Empty ? 0 : Convert.ToInt32(onalti[j].Matnr));
                                cmd.Parameters.AddWithValue("@Werks", onalti[j].Werks);
                                cmd.Parameters.AddWithValue("@Lgort", onalti[j].Lgort);
                                cmd.Parameters.AddWithValue("@Charg", onalti[j].Charg);
                                cmd.Parameters.AddWithValue("@Kunnr", onalti[j].Kunnr.StartsWith("T") || onalti[j].Kunnr == "" ? 10 : Convert.ToInt32(onalti[j].Kunnr));
                                cmd.Parameters.AddWithValue("@Menge", onalti[j].Menge);
                                cmd.Parameters.AddWithValue("@Meins", onalti[j].Meins);
                                cmd.Parameters.AddWithValue("@MeinsText", onalti[j].MeinsText);
                                cmd.Parameters.AddWithValue("@Lgnum", onalti[j].Lgnum);
                                cmd.Parameters.AddWithValue("@Lgtyp", onalti[j].Lgtyp);
                                int don = 0; cmd.Parameters.AddWithValue("@Lgpla", int.TryParse(onalti[j].Lgpla, out don) ? Convert.ToInt32(onalti[j].Lgpla) : 0);
                                cmd.Parameters.AddWithValue("@Sjahr", onalti[j].Sjahr);
                                cmd.Parameters.AddWithValue("@Smbln", onalti[j].Smbln);
                                cmd.Parameters.AddWithValue("@Smblp", onalti[j].Smblp);
                                cmd.Parameters.AddWithValue("@VbelnVl", onalti[j].VbelnVl);
                                cmd.Parameters.AddWithValue("@PosnrVl", onalti[j].PosnrVl);
                                cmd.Parameters.AddWithValue("@Vbeln", onalti[j].Vbeln);
                                cmd.Parameters.AddWithValue("@Posnr", onalti[j].Posnr);
                                #endregion
                                cmd.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                SAPs.HataYaz("SAP_MALCIKIS_DETAY", onalti[j].Mblnr, onalti[j].Mjahr, onalti[j].Zeile, "", "", ex.Message, cekilecektarih, cekilecektarih.AddDays(1));
                            }
                            conn.Close();
                        }
                    }
                    #endregion

                    #endregion

                    #region fatura

                    #region head
                    if (fatura && onyedi != null)
                    {
                        for (int j = 0; j < onyedi.Length; j++)
                        {
                            try
                            {
                                conn.Open();
                                SqlCommand cmd = new SqlCommand(
                                    "DELETE FROM [SAP_FATURA_BASLIK] WHERE Vbeln = @Vbeln " +
                                    "INSERT INTO [SAP_FATURA_BASLIK] (KAYIT_TARIHI,[Vbeln],[Fkart],[Vtext],[Fktyp],[Fktyp Text],[Vbtyp],[Vbtyp Text],[Waerk],[Vkorg],[Vtweg],[Kalsm],[Knumv],[Vsbed],[Fkdat],[Bukrs],[Belnr],[Gjahr],[Poper],[Ernam],[Erzet],[Erdat],[Kunrg],[Sfakn],[Fksto],[Xblnr],[Zuonr]) VALUES (@KAYIT_TARIHI,@Vbeln,@Fkart,@Vtext,@Fktyp,@FktypText,@Vbtyp,@VbtypText,@Waerk,@Vkorg,@Vtweg,@Kalsm,@Knumv,@Vsbed,@Fkdat,@Bukrs,@Belnr,@Gjahr,@Poper,@Ernam,@Erzet,@Erdat,@Kunrg,@Sfakn,@Fksto,@Xblnr,@Zuonr)", conn);
                                #region parameters
                                cmd.Parameters.AddWithValue("@KAYIT_TARIHI", DateTime.Now);
                                cmd.Parameters.AddWithValue("@Vbeln", Convert.ToInt64(onyedi[j].Vbeln));
                                cmd.Parameters.AddWithValue("@Fkart", onyedi[j].Fkart);
                                cmd.Parameters.AddWithValue("@Vtext", onyedi[j].Vtext);
                                cmd.Parameters.AddWithValue("@Fktyp", onyedi[j].Fktyp);
                                cmd.Parameters.AddWithValue("@FktypText", onyedi[j].FktypText);
                                cmd.Parameters.AddWithValue("@Vbtyp", onyedi[j].Vbtyp);
                                cmd.Parameters.AddWithValue("@VbtypText", onyedi[j].VbtypText);
                                cmd.Parameters.AddWithValue("@Waerk", onyedi[j].Waerk);
                                cmd.Parameters.AddWithValue("@Vkorg", onyedi[j].Vkorg);
                                cmd.Parameters.AddWithValue("@Vtweg", onyedi[j].Vtweg);
                                cmd.Parameters.AddWithValue("@Kalsm", onyedi[j].Kalsm);
                                cmd.Parameters.AddWithValue("@Knumv", onyedi[j].Knumv.StartsWith("T") || onyedi[j].Knumv == "" ? 10 : Convert.ToInt32(onyedi[j].Knumv));
                                cmd.Parameters.AddWithValue("@Vsbed", onyedi[j].Vsbed);
                                cmd.Parameters.AddWithValue("@Fkdat", onyedi[j].Fkdat.StartsWith("0000") ? Convert.ToDateTime("01.01.1900") : Convert.ToDateTime(onyedi[j].Fkdat));
                                cmd.Parameters.AddWithValue("@Bukrs", onyedi[j].Bukrs);
                                cmd.Parameters.AddWithValue("@Belnr", onyedi[j].Belnr);
                                cmd.Parameters.AddWithValue("@Gjahr", onyedi[j].Gjahr);
                                cmd.Parameters.AddWithValue("@Poper", onyedi[j].Poper);
                                cmd.Parameters.AddWithValue("@Ernam", onyedi[j].Ernam);
                                cmd.Parameters.AddWithValue("@Erzet", onyedi[j].Erzet);
                                cmd.Parameters.AddWithValue("@Erdat", Convert.ToDateTime(onyedi[j].Erdat + " " + onyedi[j].Erzet));
                                cmd.Parameters.AddWithValue("@Kunrg", onyedi[j].Kunrg);
                                cmd.Parameters.AddWithValue("@Sfakn", onyedi[j].Sfakn);
                                cmd.Parameters.AddWithValue("@Fksto", onyedi[j].Fksto);
                                cmd.Parameters.AddWithValue("@Xblnr", onyedi[j].Xblnr);
                                cmd.Parameters.AddWithValue("@Zuonr", onyedi[j].Zuonr);
                                #endregion
                                cmd.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                SAPs.HataYaz("SAP_FATURA_BASLIK", onyedi[j].Vbeln, "", "", "", "", ex.Message, cekilecektarih, cekilecektarih.AddDays(1));
                            }
                            conn.Close();
                        }
                    }
                    #endregion

                    #region item
                    if (fatura && onsekiz != null)
                    {
                        for (int j = 0; j < onsekiz.Length; j++)
                        {
                            try
                            {
                                conn.Open();
                                SqlCommand cmd = new SqlCommand(
                                    "DELETE FROM [SAP_FATURA_DETAY] WHERE Vbeln = @Vbeln AND Posnr = @Posnr " +
                                    "INSERT INTO [SAP_FATURA_DETAY] (KAYIT_TARIHI,[Vbeln],[Posnr],[Fkimg],[Vrkme],[Vrkme Text],[Ntgew],[Brgew],[Gewei],[Volum],[Voleh],[Vgbel],[Vgpos],[Vgtyp],[Aubel],[Aupos],[Auref],[Matnr],[Arktx],[Charg],[Netwr],[Brtwr],[Mwskz],[Sgtxt],[Kzwi1],[Kzwi4],[Lgort],Spart) VALUES (@KAYIT_TARIHI,@Vbeln,@Posnr,@Fkimg,@Vrkme,@VrkmeText,@Ntgew,@Brgew,@Gewei,@Volum,@Voleh,@Vgbel,@Vgpos,@Vgtyp,@Aubel,@Aupos,@Auref,@Matnr,@Arktx,@Charg,@Netwr,@Brtwr,@Mwskz,@Sgtxt,@Kzwi1,@Kzwi4,@Lgort,@Spart)", conn);
                                #region parameters
                                cmd.Parameters.AddWithValue("@KAYIT_TARIHI", DateTime.Now);
                                cmd.Parameters.AddWithValue("@Vbeln", Convert.ToInt64(onsekiz[j].Vbeln));
                                cmd.Parameters.AddWithValue("@Posnr", Convert.ToInt32(onsekiz[j].Posnr));
                                cmd.Parameters.AddWithValue("@Fkimg", onsekiz[j].Fkimg);
                                cmd.Parameters.AddWithValue("@Vrkme", onsekiz[j].Vrkme);
                                cmd.Parameters.AddWithValue("@VrkmeText", onsekiz[j].VrkmeText);
                                cmd.Parameters.AddWithValue("@Ntgew", onsekiz[j].Ntgew);
                                cmd.Parameters.AddWithValue("@Brgew", onsekiz[j].Brgew);
                                cmd.Parameters.AddWithValue("@Gewei", onsekiz[j].Gewei);
                                cmd.Parameters.AddWithValue("@Volum", onsekiz[j].Volum);
                                cmd.Parameters.AddWithValue("@Voleh", onsekiz[j].Voleh);
                                cmd.Parameters.AddWithValue("@Vgbel", onsekiz[j].Vgbel);
                                cmd.Parameters.AddWithValue("@Vgpos", onsekiz[j].Vgpos);
                                cmd.Parameters.AddWithValue("@Vgtyp", onsekiz[j].Vgtyp);
                                cmd.Parameters.AddWithValue("@Aubel", onsekiz[j].Aubel);
                                cmd.Parameters.AddWithValue("@Aupos", onsekiz[j].Aupos);
                                cmd.Parameters.AddWithValue("@Auref", onsekiz[j].Auref);
                                cmd.Parameters.AddWithValue("@Matnr", onsekiz[j].Matnr == string.Empty ? 0 : Convert.ToInt32(onsekiz[j].Matnr));
                                cmd.Parameters.AddWithValue("@Arktx", onsekiz[j].Arktx);
                                cmd.Parameters.AddWithValue("@Charg", onsekiz[j].Charg);
                                cmd.Parameters.AddWithValue("@Netwr", onsekiz[j].Netwr);
                                cmd.Parameters.AddWithValue("@Brtwr", onsekiz[j].Brtwr);
                                cmd.Parameters.AddWithValue("@Mwskz", onsekiz[j].Mwskz);
                                cmd.Parameters.AddWithValue("@Sgtxt", onsekiz[j].Sgtxt);
                                cmd.Parameters.AddWithValue("@Kzwi1", onsekiz[j].Kzwi1);
                                cmd.Parameters.AddWithValue("@Kzwi4", onsekiz[j].Kzwi4);
                                cmd.Parameters.AddWithValue("@Lgort", onsekiz[j].Lgort);
                                cmd.Parameters.AddWithValue("@Spart", onsekiz[j].Spart);
                                #endregion
                                cmd.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                SAPs.HataYaz("SAP_FATURA_DETAY", onsekiz[j].Vbeln, onsekiz[j].Posnr, "", "", "", ex.Message, cekilecektarih, cekilecektarih.AddDays(1));
                            }
                            conn.Close();
                        }
                    }
                    #endregion

                    #endregion

                    cekilecektarih = cekilecektarih.AddDays(1);
                }

                if (!hatavar)
                    MaxTarihYaz(conn, "SAP_NakilMalFatura", bitistarih);
            }
            #endregion



            #region KOLIETIKET
            if (kolietiket)
            {
                DateTime maxtarih = MaxTarihGetir(conn, "SAP_KoliEtiket");
                DateTime bitistarih = DateTime.Now;
                bool hatavar = false;

                selectkolietiketC.ZwebSelectKoliEtiketService client5 = new selectkolietiketC.ZwebSelectKoliEtiketService();
                client5.Timeout = 6000000;
                client5.Credentials = nc1;

                DateTime cekilecektarih = maxtarih;
                DateTime simdikitarih = DateTime.Now;
                while (Convert.ToDateTime(cekilecektarih.ToShortDateString()) <= Convert.ToDateTime(simdikitarih.ToShortDateString()))
                {
                    selectkolietiketC.Zwebs019[] ondokuz = null;

                    string hata = string.Empty;
                    string tarih = "";
                    string saat = "00:00:00";

                    int tekrarcek = 0;
                    while (tekrarcek < tekrarcekilecek)
                    {
                        try
                        {
                            TarihSaat(maxtarih, cekilecektarih, out tarih, out saat);
                            ondokuz = client5.ZwebSelectKoliEtiket(tarih, saat);
                            tekrarcek = tekrarcekilecek;
                        }
                        catch (Exception ex)
                        {
                            SAPs.LogYaz("select koli etiket", true, cekilecektarih.ToShortDateString() + " " + (tekrarcek + 1).ToString() + ".deneme sap hata döndürdü: " + ex.Message, DateTime.Now, DateTime.Now);
                            if (tekrarcek < tekrarcekilecek)
                            {
                                tekrarcek++;
                                System.Threading.Thread.Sleep(3000);
                            }
                            else
                            {
                                hata = ex.Message;
                                hatavar = true;
                                cekilecektarih = DateTime.Now; // while dan çıksın bir sonraki günü almasın max tarihi yenilemesin
                            }
                        }
                    }

                    SAPs.LogYaz("select koli etiket", hata != string.Empty ? false : true, hata, Convert.ToDateTime(cekilecektarih.ToShortDateString() + " " + saat), Convert.ToDateTime(cekilecektarih.ToShortDateString()) == Convert.ToDateTime(simdikitarih.ToShortDateString()) ? DateTime.Now : Convert.ToDateTime(cekilecektarih.AddDays(1).ToShortDateString() + " 00:00:00"));

                    if (ondokuz != null)
                    {
                        for (int j = 0; j < ondokuz.Length; j++)
                        {
                            try
                            {
                                conn.Open();
                                SqlCommand cmd = new SqlCommand(
                                    "DELETE FROM [SAP_KOLIETIKET] WHERE Kolietiketno = @Kolietiketno " +
                                    "INSERT INTO [SAP_KOLIETIKET] (KAYIT_TARIHI,[Kolietiketno],[Kolisira],[Koliadet],[Vbeln],[Erdat],[Erzet],[Ernam],[Deleted]) VALUES (@KAYIT_TARIHI,@Kolietiketno,@Kolisira,@Koliadet,@Vbeln,@Erdat,@Erzet,@Ernam,@Deleted)", conn);
                                #region parameters
                                cmd.Parameters.AddWithValue("@KAYIT_TARIHI", DateTime.Now);
                                cmd.Parameters.AddWithValue("@Kolietiketno", ondokuz[j].Kolietiketno);
                                cmd.Parameters.AddWithValue("@Kolisira", ondokuz[j].Kolisira);
                                cmd.Parameters.AddWithValue("@Koliadet", ondokuz[j].Koliadet);
                                cmd.Parameters.AddWithValue("@Vbeln", Convert.ToInt64(ondokuz[j].Vbeln));
                                cmd.Parameters.AddWithValue("@Erdat", Convert.ToDateTime(ondokuz[j].Erdat + " " + ondokuz[j].Erzet));
                                cmd.Parameters.AddWithValue("@Erzet", ondokuz[j].Erzet);
                                cmd.Parameters.AddWithValue("@Ernam", ondokuz[j].Ernam);
                                cmd.Parameters.AddWithValue("@Deleted", ondokuz[j].Deleted);
                                #endregion
                                cmd.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                SAPs.HataYaz("SAP_KOLIETIKET", ondokuz[j].Kolietiketno, "", "", "", "", ex.Message, cekilecektarih, cekilecektarih.AddDays(1));
                            }
                            conn.Close();
                        }
                    }

                    cekilecektarih = cekilecektarih.AddDays(1);
                }

                if (!hatavar)
                    MaxTarihYaz(conn, "SAP_KoliEtiket", bitistarih);
            }
            #endregion



            #region ACCOUNTING
            if (accounting)
            {
                DateTime maxtarih = MaxTarihGetir(conn, "SAP_Accounting");
                DateTime bitistarih = DateTime.Now;
                bool hatavar = false;

                selectaccountingC.ZwebSelectAccountingService client6 = new selectaccountingC.ZwebSelectAccountingService();
                //for (int i = maxtarih.Day; i <= DateTime.Now.Day; i++)
                //{
                selectaccountingC.Zwebs020[] yirmi = null;
                client6.Timeout = 6000000;
                client6.Credentials = nc1;

                string hata = string.Empty;

                int tekrarcek = 0;
                while (tekrarcek < tekrarcekilecek)
                {
                    try
                    {
                        yirmi = client6.ZwebSelectAccounting(
                            maxtarih.Year.ToString() + (maxtarih.Month.ToString().Length == 1 ? "0" + maxtarih.Month.ToString() : maxtarih.Month.ToString()) + (maxtarih.Day.ToString().Length == 1 ? "0" + maxtarih.Day.ToString() : maxtarih.Day.ToString()),
                            DateTime.Now.AddDays(1).Year.ToString() + (DateTime.Now.AddDays(1).Month.ToString().Length == 1 ? "0" + DateTime.Now.AddDays(1).Month.ToString() : DateTime.Now.AddDays(1).Month.ToString()) + (DateTime.Now.AddDays(1).Day.ToString().Length == 1 ? "0" + DateTime.Now.AddDays(1).Day.ToString() : DateTime.Now.AddDays(1).Day.ToString()));
                        tekrarcek = tekrarcekilecek;
                    }
                    catch (Exception ex)
                    {
                        SAPs.LogYaz("select accounting", true, (tekrarcek + 1).ToString() + ".deneme sap hata döndürdü: " + ex.Message, DateTime.Now, DateTime.Now);
                        if (tekrarcek < tekrarcekilecek)
                        {
                            tekrarcek++;
                            System.Threading.Thread.Sleep(3000);
                        }
                        else
                        {
                            hata = ex.Message;
                            hatavar = true;
                        }
                    }
                }

                SAPs.LogYaz("select accounting", hata != string.Empty ? false : true, hata, maxtarih, DateTime.Now);

                if (yirmi != null)
                {
                    for (int j = 0; j < yirmi.Length; j++)
                    {
                        try
                        {
                            conn.Open();
                            SqlCommand cmd = new SqlCommand(
                                "DELETE FROM [SAP_ACCOUNTING] WHERE Bukrs = @Bukrs AND Belnr = @Belnr AND Gjahr = @Gjahr " +
                                "INSERT INTO [SAP_ACCOUNTING] (KAYIT_TARIHI,[Bukrs],[Belnr],[Gjahr],[Blart],[Bldat],[Budat],[Monat],[Cpudt],[Cputm],[Aedat],[Upddt],[Wwert],[Usnam],[Xblnr],[Stblg],[Stjah],[Bktxt],[Waers],[Awtyp],[Awkey],[Zzikincibelgeno],[Zzislemkd],[Zzreferans]) VALUES (@KAYIT_TARIHI,@Bukrs,@Belnr,@Gjahr,@Blart,@Bldat,@Budat,@Monat,@Cpudt,@Cputm,@Aedat,@Upddt,@Wwert,@Usnam,@Xblnr,@Stblg,@Stjah,@Bktxt,@Waers,@Awtyp,@Awkey,@Zzikincibelgeno,@Zzislemkd,@Zzreferans)", conn);
                            #region parameters
                            cmd.Parameters.AddWithValue("@KAYIT_TARIHI", DateTime.Now);
                            cmd.Parameters.AddWithValue("@Bukrs", yirmi[j].Bukrs);
                            cmd.Parameters.AddWithValue("@Belnr", yirmi[j].Belnr);
                            cmd.Parameters.AddWithValue("@Gjahr", Convert.ToInt32(yirmi[j].Gjahr));
                            cmd.Parameters.AddWithValue("@Blart", yirmi[j].Blart);
                            cmd.Parameters.AddWithValue("@Bldat", yirmi[j].Bldat.StartsWith("0000") ? Convert.ToDateTime("01.01.1900") : Convert.ToDateTime(yirmi[j].Bldat));
                            cmd.Parameters.AddWithValue("@Budat", yirmi[j].Budat.StartsWith("0000") ? Convert.ToDateTime("01.01.1900") : Convert.ToDateTime(yirmi[j].Budat));
                            cmd.Parameters.AddWithValue("@Monat", yirmi[j].Monat);
                            cmd.Parameters.AddWithValue("@Cpudt", yirmi[j].Cpudt.StartsWith("0000") ? Convert.ToDateTime("01.01.1900") : Convert.ToDateTime(yirmi[j].Cpudt + " " + yirmi[j].Cputm));
                            cmd.Parameters.AddWithValue("@Cputm", yirmi[j].Cputm);
                            cmd.Parameters.AddWithValue("@Aedat", yirmi[j].Aedat.StartsWith("0000") ? Convert.ToDateTime("01.01.1900") : Convert.ToDateTime(yirmi[j].Aedat));
                            cmd.Parameters.AddWithValue("@Upddt", yirmi[j].Upddt.StartsWith("0000") ? Convert.ToDateTime("01.01.1900") : Convert.ToDateTime(yirmi[j].Upddt));
                            cmd.Parameters.AddWithValue("@Wwert", yirmi[j].Wwert.StartsWith("0000") ? Convert.ToDateTime("01.01.1900") : Convert.ToDateTime(yirmi[j].Wwert));
                            cmd.Parameters.AddWithValue("@Usnam", yirmi[j].Usnam);
                            cmd.Parameters.AddWithValue("@Xblnr", yirmi[j].Xblnr);
                            cmd.Parameters.AddWithValue("@Stblg", yirmi[j].Stblg);
                            cmd.Parameters.AddWithValue("@Stjah", yirmi[j].Stjah);
                            cmd.Parameters.AddWithValue("@Bktxt", yirmi[j].Bktxt);
                            cmd.Parameters.AddWithValue("@Waers", yirmi[j].Waers);
                            cmd.Parameters.AddWithValue("@Awtyp", yirmi[j].Awtyp);
                            cmd.Parameters.AddWithValue("@Awkey", yirmi[j].Awkey);
                            cmd.Parameters.AddWithValue("@Zzikincibelgeno", yirmi[j].Zzikincibelgeno);
                            cmd.Parameters.AddWithValue("@Zzislemkd", yirmi[j].Zzislemkd);
                            cmd.Parameters.AddWithValue("@Zzreferans", yirmi[j].Zzreferans);
                            #endregion
                            cmd.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            hatavar = true;
                            SAPs.HataYaz("SAP_ACCOUNTING", yirmi[j].Bukrs, yirmi[j].Belnr, yirmi[j].Gjahr, "", "", ex.Message, maxtarih, DateTime.Now);
                        }
                        conn.Close();
                    }
                }

                if (!hatavar)
                    MaxTarihYaz(conn, "SAP_Accounting", bitistarih);
                //}
            }
            #endregion



            #region EFATURA
            if (efatura)
            {
                DateTime maxtarih = MaxTarihGetir(conn, "SAP_Efatura");
                DateTime bitistarih = DateTime.Now;
                bool hatavar = false;

                efaturaC.EFaturaInfoService clnt = new efaturaC.EFaturaInfoService();
                clnt.Timeout = 6000000;
                efaturaC.tibetCustomBean[] donen = null;

                string hata = string.Empty;
                try
                {
                    donen = clnt.getTibetGidenList(
                        maxtarih.Year.ToString() +
                        (maxtarih.Month.ToString().Length == 1 ? "0" + maxtarih.Month.ToString() : maxtarih.Month.ToString()) +
                        (maxtarih.Day.ToString().Length == 1 ? "0" + maxtarih.Day.ToString() : maxtarih.Day.ToString()),
                        (maxtarih.Hour.ToString().Length == 1 ? "0" + maxtarih.Hour.ToString() : maxtarih.Hour.ToString()) +
                        ((maxtarih.Minute).ToString().Length == 1 ? "0" + (maxtarih.Minute).ToString() : (maxtarih.Minute).ToString()) +
                        (maxtarih.Second.ToString().Length == 1 ? "0" + maxtarih.Second.ToString() : maxtarih.Second.ToString()),

                        bitistarih.Year.ToString() +
                        (bitistarih.Month.ToString().Length == 1 ? "0" + bitistarih.Month.ToString() : bitistarih.Month.ToString()) +
                        (bitistarih.Day.ToString().Length == 1 ? "0" + bitistarih.Day.ToString() : bitistarih.Day.ToString()),
                        (bitistarih.Hour.ToString().Length == 1 ? "0" + bitistarih.Hour.ToString() : bitistarih.Hour.ToString()) +
                        ((bitistarih.Minute).ToString().Length == 1 ? "0" + (bitistarih.Minute).ToString() : (bitistarih.Minute).ToString()) +
                        (bitistarih.Second.ToString().Length == 1 ? "0" + bitistarih.Second.ToString() : bitistarih.Second.ToString()));
                }
                catch (Exception ex)
                {
                    hata = ex.Message;
                    hatavar = true;
                }
                finally
                {
                    SAPs.LogYaz("efatura", hata != string.Empty ? false : true, hata, maxtarih, DateTime.Now);
                }

                if (donen != null)
                {
                    for (int j = 0; j < donen.Length; j++)
                    {
                        try
                        {
                            conn.Open();
                            SqlCommand cmd = new SqlCommand("INSERT INTO [SAP_EFATURA] (KAYIT_TARIHI,[ETTN],[mali Yil],[onay Red Saati],[onay Red Tarihi],[sap Fatura No],[sap Modul],[senaryo],[sender VKN],[sirket Kodu],[son Durum Aciklamasi],[son Durum Kodu],[e Fatura No],[e Fatura Saat],[e Fatura Tarihi],currentCode,gross,net,valueAddedTax,invoiceDate,invoiceType,invoiceTypeAck) VALUES (@KAYIT_TARIHI,@ETTN,@maliYil,@onayRedSaati,@onayRedTarihi,@sapFaturaNo,@sapModul,@senaryo,@senderVKN,@sirketKodu,@sonDurumAciklamasi,@sonDurumKodu,@eFaturaNo,@eFaturaSaat,@eFaturaTarihi,@currentCode,@gross,@net,@valueAddedTax,@invoiceDate,@invoiceType,@invoiceTypeAck)", conn);
                            #region parameters
                            cmd.Parameters.AddWithValue("@KAYIT_TARIHI", DateTime.Now);
                            cmd.Parameters.AddWithValue("@ETTN", donen[j].ETTN);
                            cmd.Parameters.AddWithValue("@maliYil", donen[j].maliYil);
                            cmd.Parameters.AddWithValue("@onayRedSaati", donen[j].onayRedSaati);
                            cmd.Parameters.AddWithValue("@onayRedTarihi", Convert.ToDateTime(donen[j].onayRedTarihi + " " + donen[j].onayRedSaati));
                            cmd.Parameters.AddWithValue("@sapFaturaNo", Convert.ToInt64(donen[j].sapFaturaNo));
                            cmd.Parameters.AddWithValue("@sapModul", donen[j].sapModul);
                            cmd.Parameters.AddWithValue("@senaryo", donen[j].senaryo);
                            cmd.Parameters.AddWithValue("@senderVKN", donen[j].senderVKN);
                            cmd.Parameters.AddWithValue("@sirketKodu", donen[j].sirketKodu);
                            cmd.Parameters.AddWithValue("@sonDurumAciklamasi", donen[j].sonDurumAciklamasi);
                            cmd.Parameters.AddWithValue("@sonDurumKodu", donen[j].sonDurumKodu);
                            cmd.Parameters.AddWithValue("@eFaturaNo", donen[j].eFaturaNo);
                            cmd.Parameters.AddWithValue("@eFaturaSaat", donen[j].eFaturaSaat);
                            cmd.Parameters.AddWithValue("@eFaturaTarihi", Convert.ToDateTime(donen[j].eFaturaTarihi + " " + donen[j].eFaturaSaat));
                            cmd.Parameters.AddWithValue("@currentCode", donen[j].currentCode.StartsWith("T") || donen[j].currentCode == "" ? 10 : Convert.ToInt32(donen[j].currentCode));
                            cmd.Parameters.AddWithValue("@gross", Convert.ToDouble(donen[j].gross));
                            cmd.Parameters.AddWithValue("@net", Convert.ToDouble(donen[j].net));
                            cmd.Parameters.AddWithValue("@valueAddedTax", Convert.ToDouble(donen[j].valueAddedTax));
                            cmd.Parameters.AddWithValue("@invoiceDate", Convert.ToDateTime(donen[j].invoiceDate));
                            cmd.Parameters.AddWithValue("@invoiceType", donen[j].invoiceType);
                            cmd.Parameters.AddWithValue("@invoiceTypeAck", donen[j].invoiceTypeAck);
                            #endregion
                            cmd.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            SAPs.HataYaz("SAP_EFATURA", donen[j].ETTN, donen[j].eFaturaNo, donen[j].sonDurumKodu, donen[j].onayRedTarihi, donen[j].onayRedSaati, ex.Message, maxtarih, DateTime.Now);
                        }
                        conn.Close();
                    }
                }

                if (!hatavar)
                    MaxTarihYaz(conn, "SAP_Efatura", bitistarih);
            }
            #endregion



            SatisUpdate(conn);



            MalzemelerC(false, true); // ölçü birim tablo yenilemesi satisupdate ile çakışmaması için



            if (ekstre)
            {
                if (DateTime.Now.Minute > 30) // sap deki ekstre job u 15 geçe başlıyor 10dk sürüyor
                {
                    GetEkstre(Convert.ToDateTime("01.01.2014")); // Convert.ToDateTime("01.01.2014")
                    //GetSatisJob();
                }
            }
        }

        /*private void GetSatisJob()
        {
            SqlConnection conn = new SqlConnection(General.ConnectionString);
            SqlCommand cmdSatisJob = new SqlCommand("msdb.dbo.sp_start_job", conn);
            cmdSatisJob.CommandTimeout = 1000;
            cmdSatisJob.CommandType = CommandType.StoredProcedure;
            cmdSatisJob.Parameters.AddWithValue("@job_name", "Web_Satis_Yeni");

            DateTime bastarih = DateTime.Now;
            string hataa = string.Empty;
            try
            {
                conn.Open();
                cmdSatisJob.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                hataa = ex.Message;
            }
            finally
            {
                conn.Close();
                SAPs.LogYaz("satis yeni", hataa != string.Empty ? false : true, hataa, bastarih, DateTime.Now);
            }
        }*/

        private void Satis()
        {
            SqlConnection conn = new SqlConnection(General.ConnectionString);
            SqlCommand cmd = new SqlCommand("sp_SAP_SATIS_YENI", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 3000;

            DateTime bastarih = DateTime.Now;
            string hataa = string.Empty;
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Hatalar.DoInsert(ex, "sp_SAP_SATIS_YENI");
                hataa = ex.Message;
            }
            finally
            {
                conn.Close();
                SAPs.LogYaz("satis yeni ikinci", hataa != string.Empty ? false : true, hataa, bastarih, DateTime.Now);
            }
        }

        private void SatisIade()
        {
            SqlConnection conn = new SqlConnection(General.ConnectionString);
            SqlCommand cmd = new SqlCommand("sp_SAP_IADE_YENI", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 3000;

            DateTime bastarih = DateTime.Now;
            string hataa = string.Empty;
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Hatalar.DoInsert(ex, "sp_SAP_IADE_YENI");
                hataa = ex.Message;
            }
            finally
            {
                conn.Close();
                SAPs.LogYaz("iade yeni", hataa != string.Empty ? false : true, hataa, bastarih, DateTime.Now);
            }
        }

        void GetSAPgece(bool satisupdate)
        {
            SqlConnection conn = new SqlConnection(General.ConnectionString);

            bool vbfa = true;
            bool siparis = true;
            bool teslimat = true;
            bool nakilmalfatura = true;
            bool nakilsiparis = true;
            bool malcikis = true;
            bool fatura = true;
            bool kolietiket = true;
            bool accounting = false;



            #region VBFA
            if (vbfa)
            {
                DateTime maxtarih = Convert.ToDateTime(DateTime.Now.AddDays(-2).ToShortDateString() + " 00:30:00");
                DateTime bitistarih = DateTime.Now;
                bool hatavar = false;

                selectsalesvbfaC.ZwebSelectSalesVbfaService client = new selectsalesvbfaC.ZwebSelectSalesVbfaService();
                client.Timeout = 6000000;
                client.Credentials = nc1;

                DateTime cekilecektarih = maxtarih;
                DateTime simdikitarih = DateTime.Now;
                while (Convert.ToDateTime(cekilecektarih.ToShortDateString()) <= Convert.ToDateTime(simdikitarih.ToShortDateString()))
                {
                    selectsalesvbfaC.Zwebs009[] dokuz = null;

                    string hata = string.Empty;
                    string tarih = "";
                    string saat = "00:00:00";

                    int tekrarcek = 0;
                    while (tekrarcek < tekrarcekilecek)
                    {
                        try
                        {
                            TarihSaat(maxtarih, cekilecektarih, out tarih, out saat);
                            dokuz = client.ZwebSelectSalesVbfa(tarih, saat);
                            tekrarcek = tekrarcekilecek;
                        }
                        catch (Exception ex)
                        {
                            SAPs.LogYaz("select sales vbfa", true, cekilecektarih.ToShortDateString() + " " + (tekrarcek + 1).ToString() + ".deneme sap hata döndürdü: " + ex.Message, DateTime.Now, DateTime.Now);
                            if (tekrarcek < tekrarcekilecek)
                            {
                                tekrarcek++;
                                System.Threading.Thread.Sleep(3000);
                            }
                            else
                            {
                                hata = ex.Message;
                                hatavar = true;
                                cekilecektarih = DateTime.Now; // while dan çıksın bir sonraki günü almasın max tarihi yenilemesin
                            }
                        }
                    }

                    SAPs.LogYaz("select sales vbfa", hata != string.Empty ? false : true, hata, Convert.ToDateTime(cekilecektarih.ToShortDateString() + " " + saat), Convert.ToDateTime(cekilecektarih.ToShortDateString()) == Convert.ToDateTime(simdikitarih.ToShortDateString()) ? DateTime.Now : Convert.ToDateTime(cekilecektarih.AddDays(1).ToShortDateString() + " 00:00:00"));

                    if (dokuz != null)
                    {
                        for (int j = 0; j < dokuz.Length; j++)
                        {
                            try
                            {
                                conn.Open();
                                SqlCommand cmd = new SqlCommand(
                                    "DELETE FROM [SAP_VBFA] WHERE Vbelv = @Vbelv AND Posnv = @Posnv AND Vbeln = @Vbeln AND Posnn = @Posnn AND [Vbtyp N] = @VbtypN " +
                                    "INSERT INTO [SAP_VBFA] (KAYIT_TARIHI,[Vbelv],[Posnv],[Vbeln],[Posnn],[Vbtyp N],[Rfmng],[Meins],[Rfwrt],[Waers],[Vbtyp V],[Plmin],[Taqui],[Erdat],[Erzet],[Matnr],[Bwart],[Bdart],[Plart],[Stufe],[Lgnum],[Aedat],[Fktyp],[Brgew],[Gewei],[Volum],[Voleh],[Fplnr],[Fpltr],[Rfmng Flo],[Rfmng Flt],[Vrkme],[Abges],[Sobkz],[Sonum],[Kzbef],[Ntgew],[Logsys],[Wbsta],[Cmeth],[Mjahr]) VALUES (@KAYIT_TARIHI,@Vbelv,@Posnv,@Vbeln,@Posnn,@VbtypN,@Rfmng,@Meins,@Rfwrt,@Waers,@VbtypV,@Plmin,@Taqui,@Erdat,@Erzet,@Matnr,@Bwart,@Bdart,@Plart,@Stufe,@Lgnum,@Aedat,@Fktyp,@Brgew,@Gewei,@Volum,@Voleh,@Fplnr,@Fpltr,@RfmngFlo,@RfmngFlt,@Vrkme,@Abges,@Sobkz,@Sonum,@Kzbef,@Ntgew,@Logsys,@Wbsta,@Cmeth,@Mjahr)", conn);
                                #region parameters
                                cmd.Parameters.AddWithValue("@KAYIT_TARIHI", DateTime.Now);
                                cmd.Parameters.AddWithValue("@Vbelv", Convert.ToInt64(dokuz[j].Vbelv));
                                cmd.Parameters.AddWithValue("@Posnv", Convert.ToInt32(dokuz[j].Posnv));
                                cmd.Parameters.AddWithValue("@Vbeln", Convert.ToInt64(dokuz[j].Vbeln));
                                cmd.Parameters.AddWithValue("@Posnn", Convert.ToInt32(dokuz[j].Posnn));
                                cmd.Parameters.AddWithValue("@VbtypN", dokuz[j].VbtypN);
                                cmd.Parameters.AddWithValue("@Rfmng", dokuz[j].Rfmng);
                                cmd.Parameters.AddWithValue("@Meins", dokuz[j].Meins);
                                cmd.Parameters.AddWithValue("@Rfwrt", dokuz[j].Rfwrt);
                                cmd.Parameters.AddWithValue("@Waers", dokuz[j].Waers);
                                cmd.Parameters.AddWithValue("@VbtypV", dokuz[j].VbtypV);
                                cmd.Parameters.AddWithValue("@Plmin", dokuz[j].Plmin);
                                cmd.Parameters.AddWithValue("@Taqui", dokuz[j].Taqui);
                                cmd.Parameters.AddWithValue("@Erdat", Convert.ToDateTime(dokuz[j].Erdat + " " + dokuz[j].Erzet));
                                cmd.Parameters.AddWithValue("@Erzet", dokuz[j].Erzet);
                                cmd.Parameters.AddWithValue("@Matnr", dokuz[j].Matnr == string.Empty ? 0 : Convert.ToInt32(dokuz[j].Matnr));
                                cmd.Parameters.AddWithValue("@Bwart", dokuz[j].Bwart);
                                cmd.Parameters.AddWithValue("@Bdart", dokuz[j].Bdart);
                                cmd.Parameters.AddWithValue("@Plart", dokuz[j].Plart);
                                cmd.Parameters.AddWithValue("@Stufe", dokuz[j].Stufe);
                                cmd.Parameters.AddWithValue("@Lgnum", dokuz[j].Lgnum);
                                cmd.Parameters.AddWithValue("@Aedat", dokuz[j].Aedat.StartsWith("0000") ? Convert.ToDateTime("01.01.1900") : Convert.ToDateTime(dokuz[j].Aedat));
                                cmd.Parameters.AddWithValue("@Fktyp", dokuz[j].Fktyp);
                                cmd.Parameters.AddWithValue("@Brgew", dokuz[j].Brgew);
                                cmd.Parameters.AddWithValue("@Gewei", dokuz[j].Gewei);
                                cmd.Parameters.AddWithValue("@Volum", dokuz[j].Volum);
                                cmd.Parameters.AddWithValue("@Voleh", dokuz[j].Voleh);
                                cmd.Parameters.AddWithValue("@Fplnr", dokuz[j].Fplnr);
                                cmd.Parameters.AddWithValue("@Fpltr", dokuz[j].Fpltr);
                                cmd.Parameters.AddWithValue("@RfmngFlo", dokuz[j].RfmngFlo);
                                cmd.Parameters.AddWithValue("@RfmngFlt", dokuz[j].RfmngFlt);
                                cmd.Parameters.AddWithValue("@Vrkme", dokuz[j].Vrkme);
                                cmd.Parameters.AddWithValue("@Abges", dokuz[j].Abges);
                                cmd.Parameters.AddWithValue("@Sobkz", dokuz[j].Sobkz);
                                cmd.Parameters.AddWithValue("@Sonum", dokuz[j].Sonum);
                                cmd.Parameters.AddWithValue("@Kzbef", dokuz[j].Kzbef);
                                cmd.Parameters.AddWithValue("@Ntgew", dokuz[j].Ntgew);
                                cmd.Parameters.AddWithValue("@Logsys", dokuz[j].Logsys);
                                cmd.Parameters.AddWithValue("@Wbsta", dokuz[j].Wbsta);
                                cmd.Parameters.AddWithValue("@Cmeth", dokuz[j].Cmeth);
                                cmd.Parameters.AddWithValue("@Mjahr", dokuz[j].Mjahr);
                                #endregion
                                cmd.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                SAPs.HataYaz("SAP_VBFA", Convert.ToInt64(dokuz[j].Vbelv).ToString(), Convert.ToInt32(dokuz[j].Posnv).ToString(), Convert.ToInt64(dokuz[j].Vbeln).ToString(), Convert.ToInt32(dokuz[j].Posnn).ToString(), dokuz[j].VbtypN, ex.Message, cekilecektarih, cekilecektarih.AddDays(1));
                            }
                            conn.Close();
                        }
                    }

                    cekilecektarih = cekilecektarih.AddDays(1);
                }

                if (!hatavar)
                    MaxTarihYaz(conn, "SAP_Vbfa", bitistarih);
            }
            #endregion



            #region SIPARIS
            if (siparis)
            {
                DateTime maxtarih = Convert.ToDateTime(DateTime.Now.AddDays(-2).ToShortDateString() + " 00:30:00");
                DateTime bitistarih = DateTime.Now;
                bool hatavar = false;

                selectsalesorderC.ZwebSelectSalesOrderService client2 = new selectsalesorderC.ZwebSelectSalesOrderService();
                client2.Timeout = 6000000;
                client2.Credentials = nc1;

                DateTime cekilecektarih = maxtarih;
                DateTime simdikitarih = DateTime.Now;
                while (Convert.ToDateTime(cekilecektarih.ToShortDateString()) <= Convert.ToDateTime(simdikitarih.ToShortDateString()))
                {
                    selectsalesorderC.Zwebs009[] dokuz = null; // vbfa
                    selectsalesorderC.Zwebs005[] bes = null; // head
                    selectsalesorderC.Zwebs012[] oniki = null; // item
                    selectsalesorderC.Zwebs021[] yirmibir = null; // logdel

                    string hata = string.Empty;
                    string tarih = "";
                    string saat = "00:00:00";

                    int tekrarcek = 0;
                    while (tekrarcek < tekrarcekilecek)
                    {
                        try
                        {
                            TarihSaat(maxtarih, cekilecektarih, out tarih, out saat);
                            yirmibir = client2.ZwebSelectSalesOrder(tarih, "", saat, out bes, out oniki, out dokuz);
                            tekrarcek = tekrarcekilecek;
                        }
                        catch (Exception ex)
                        {
                            SAPs.LogYaz("select sales order", true, cekilecektarih.ToShortDateString() + " " + (tekrarcek + 1).ToString() + ".deneme sap hata döndürdü: " + ex.Message, DateTime.Now, DateTime.Now);
                            if (tekrarcek < tekrarcekilecek)
                            {
                                tekrarcek++;
                                System.Threading.Thread.Sleep(3000);
                            }
                            else
                            {
                                hata = ex.Message;
                                hatavar = true;
                                cekilecektarih = DateTime.Now; // while dan çıksın bir sonraki günü almasın max tarihi yenilemesin
                            }
                        }
                    }

                    SAPs.LogYaz("select sales order", hata != string.Empty ? false : true, hata, Convert.ToDateTime(cekilecektarih.ToShortDateString() + " " + saat), Convert.ToDateTime(cekilecektarih.ToShortDateString()) == Convert.ToDateTime(simdikitarih.ToShortDateString()) ? DateTime.Now : Convert.ToDateTime(cekilecektarih.AddDays(1).ToShortDateString() + " 00:00:00"));

                    #region logdel
                    if (yirmibir != null)
                    {
                        for (int j = 0; j < yirmibir.Length; j++)
                        {
                            try
                            {
                                conn.Open();
                                SqlCommand cmd = new SqlCommand("DELETE FROM [SAP_SIPARIS_BASLIK] WHERE Vbeln = @Vbeln DELETE FROM [SAP_SIPARIS_DETAY] WHERE Vbeln = @Vbeln DELETE FROM [SAP_VBFA] WHERE Vbelv = @Vbeln", conn);
                                cmd.Parameters.AddWithValue("@Vbeln", Convert.ToInt64(yirmibir[j].Vbeln));
                                cmd.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                SAPs.HataYaz("SAP_SIPARIS_BASLIK", Convert.ToInt64(yirmibir[j].Vbeln).ToString(), "", "", "", "", "(LOGDEL) - " + ex.Message, cekilecektarih, cekilecektarih.AddDays(1));
                            }
                            conn.Close();
                        }
                    }
                    #endregion

                    #region head
                    if (bes != null)
                    {
                        for (int j = 0; j < bes.Length; j++)
                        {
                            try
                            {
                                conn.Open();
                                SqlCommand cmd = new SqlCommand(
                                    "DELETE FROM [SAP_SIPARIS_BASLIK] WHERE Vbeln = @Vbeln " +
                                    "DELETE FROM [SAP_SIPARIS_DETAY] WHERE Vbeln = @Vbeln " +
                                    "DELETE FROM [SAP_VBFA] WHERE Vbeln = @Vbeln " +
                                    "INSERT INTO [SAP_SIPARIS_BASLIK] (KAYIT_TARIHI,[Vbeln],[Auart],[Bezei],[Audat],[Erdat],[Erzet],[Ernam],[Netwr],[Waerk],[Vkorg],[Vtext],[Vtweg],[Bzirk],[Bztxt],[Bstnk],[Kunnr],[Aedat],[Spart],[Vtext2],[Vkgrp],[Vkbur],[Kdgrp],[Ktext],[Name1],[Name2],[Name3],[Name4],[Name Text],[Name Co],[City1],[City2],[Street],[Region],[Sort1],[Deflt Comm],[Comm Text],[Tel Number],[Fax Number],[Stcd1],[Stcd2],[Post Code1],[Smtp Addr],[Pltyp],[Ptext],[OKunnr],[OStcd1],[OStcd2],[OName1],[ODeflt Comm],[OSmtp Addr],[OComm Text],[Yetkili],[Sip Aciklama],[Netpr],[Knumv],[Yetkili Kod],[Yetkili Ad],[Yetkili Tel],[Satsor Kod],[Satsor Ad],[Satsor Tel],[Sipalan Kod],[Sipalan Ad],[Sipalan Tel],[NamaSatici],[NamaSaticiAd],Vdatu,Bstkd) VALUES (@KAYIT_TARIHI,@Vbeln,@Auart,@Bezei,@Audat,@Erdat,@Erzet,@Ernam,@Netwr,@Waerk,@Vkorg,@Vtext,@Vtweg,@Bzirk,@Bztxt,@Bstnk,@Kunnr,@Aedat,@Spart,@Vtext2,@Vkgrp,@Vkbur,@Kdgrp,@Ktext,@Name1,@Name2,@Name3,@Name4,@NameText,@NameCo,@City1,@City2,@Street,@Region,@Sort1,@DefltComm,@CommText,@TelNumber,@FaxNumber,@Stcd1,@Stcd2,@PostCode1,@SmtpAddr,@Pltyp,@Ptext,@OKunnr,@OStcd1,@OStcd2,@OName1,@ODefltComm,@OSmtpAddr,@OCommText,@Yetkili,@SipAciklama,@Netpr,@Knumv,@YetkiliKod,@YetkiliAd,@YetkiliTel,@SatsorKod,@SatsorAd,@SatsorTel,@SipalanKod,@SipalanAd,@SipalanTel,@NamaSatici,@NamaSaticiAd,@Vdatu,@Bstkd)", conn);
                                #region parameters
                                cmd.Parameters.AddWithValue("@KAYIT_TARIHI", DateTime.Now);
                                cmd.Parameters.AddWithValue("@Vbeln", Convert.ToInt64(bes[j].Vbeln));
                                cmd.Parameters.AddWithValue("@Auart", bes[j].Auart);
                                cmd.Parameters.AddWithValue("@Bezei", bes[j].Bezei);
                                cmd.Parameters.AddWithValue("@Audat", Convert.ToDateTime(bes[j].Audat));
                                cmd.Parameters.AddWithValue("@Erdat", Convert.ToDateTime(bes[j].Erdat + " " + bes[j].Erzet));
                                cmd.Parameters.AddWithValue("@Erzet", bes[j].Erzet);
                                cmd.Parameters.AddWithValue("@Ernam", bes[j].Ernam);
                                cmd.Parameters.AddWithValue("@Netwr", bes[j].Netwr);
                                cmd.Parameters.AddWithValue("@Waerk", bes[j].Waerk);
                                cmd.Parameters.AddWithValue("@Vkorg", bes[j].Vkorg);
                                cmd.Parameters.AddWithValue("@Vtext", bes[j].Vtext);
                                cmd.Parameters.AddWithValue("@Vtweg", bes[j].Vtweg);
                                cmd.Parameters.AddWithValue("@Bzirk", bes[j].Bzirk);
                                cmd.Parameters.AddWithValue("@Bztxt", bes[j].Bztxt);
                                cmd.Parameters.AddWithValue("@Bstnk", bes[j].Bstnk);
                                cmd.Parameters.AddWithValue("@Kunnr", bes[j].Kunnr.StartsWith("T") || bes[j].Kunnr == "" ? 10 : Convert.ToInt32(bes[j].Kunnr));
                                cmd.Parameters.AddWithValue("@Aedat", bes[j].Aedat.StartsWith("0000") ? Convert.ToDateTime(bes[j].Audat) : Convert.ToDateTime(bes[j].Aedat));
                                cmd.Parameters.AddWithValue("@Spart", bes[j].Spart);
                                cmd.Parameters.AddWithValue("@Vtext2", bes[j].Vtext2);
                                cmd.Parameters.AddWithValue("@Vkgrp", bes[j].Vkgrp);
                                cmd.Parameters.AddWithValue("@Vkbur", bes[j].Vkbur);
                                cmd.Parameters.AddWithValue("@Kdgrp", bes[j].Kdgrp);
                                cmd.Parameters.AddWithValue("@Ktext", bes[j].Ktext);
                                cmd.Parameters.AddWithValue("@Name1", bes[j].Name1);
                                cmd.Parameters.AddWithValue("@Name2", bes[j].Name2);
                                cmd.Parameters.AddWithValue("@Name3", bes[j].Name3);
                                cmd.Parameters.AddWithValue("@Name4", bes[j].Name4);
                                cmd.Parameters.AddWithValue("@NameText", bes[j].NameText);
                                cmd.Parameters.AddWithValue("@NameCo", bes[j].NameCo);
                                cmd.Parameters.AddWithValue("@City1", bes[j].City1);
                                cmd.Parameters.AddWithValue("@City2", bes[j].City2);
                                cmd.Parameters.AddWithValue("@Street", bes[j].Street);
                                cmd.Parameters.AddWithValue("@Region", bes[j].Region);
                                cmd.Parameters.AddWithValue("@Sort1", bes[j].Sort1);
                                cmd.Parameters.AddWithValue("@DefltComm", bes[j].DefltComm);
                                cmd.Parameters.AddWithValue("@CommText", bes[j].CommText);
                                cmd.Parameters.AddWithValue("@TelNumber", bes[j].TelNumber);
                                cmd.Parameters.AddWithValue("@FaxNumber", bes[j].FaxNumber);
                                cmd.Parameters.AddWithValue("@Stcd1", bes[j].Stcd1);
                                cmd.Parameters.AddWithValue("@Stcd2", bes[j].Stcd2);
                                cmd.Parameters.AddWithValue("@PostCode1", bes[j].PostCode1);
                                cmd.Parameters.AddWithValue("@SmtpAddr", bes[j].SmtpAddr);
                                cmd.Parameters.AddWithValue("@Pltyp", bes[j].Pltyp);
                                cmd.Parameters.AddWithValue("@Ptext", bes[j].Ptext);
                                cmd.Parameters.AddWithValue("@OKunnr", bes[j].OKunnr.StartsWith("T") || bes[j].OKunnr == "" ? 10 : Convert.ToInt32(bes[j].OKunnr));
                                cmd.Parameters.AddWithValue("@OStcd1", bes[j].OStcd1);
                                cmd.Parameters.AddWithValue("@OStcd2", bes[j].OStcd2);
                                cmd.Parameters.AddWithValue("@OName1", bes[j].OName1);
                                cmd.Parameters.AddWithValue("@ODefltComm", bes[j].ODefltComm);
                                cmd.Parameters.AddWithValue("@OSmtpAddr", bes[j].OSmtpAddr);
                                cmd.Parameters.AddWithValue("@OCommText", bes[j].OCommText);
                                cmd.Parameters.AddWithValue("@Yetkili", bes[j].Yetkili);
                                cmd.Parameters.AddWithValue("@SipAciklama", bes[j].SipAciklama);
                                cmd.Parameters.AddWithValue("@Netpr", bes[j].Netpr);
                                cmd.Parameters.AddWithValue("@Knumv", bes[j].Knumv.StartsWith("T") || bes[j].Knumv == "" ? 10 : Convert.ToInt32(bes[j].Knumv));
                                cmd.Parameters.AddWithValue("@YetkiliKod", Convert.ToInt32(bes[j].YetkiliKod));
                                cmd.Parameters.AddWithValue("@YetkiliAd", bes[j].YetkiliAd);
                                cmd.Parameters.AddWithValue("@YetkiliTel", bes[j].YetkiliTel);
                                cmd.Parameters.AddWithValue("@SatsorKod", Convert.ToInt32(bes[j].SatsorKod));
                                cmd.Parameters.AddWithValue("@SatsorAd", bes[j].SatsorAd);
                                cmd.Parameters.AddWithValue("@SatsorTel", bes[j].SatsorTel);
                                cmd.Parameters.AddWithValue("@SipalanKod", Convert.ToInt32(bes[j].SipalanKod));
                                cmd.Parameters.AddWithValue("@SipalanAd", bes[j].SipalanAd);
                                cmd.Parameters.AddWithValue("@SipalanTel", bes[j].SipalanTel);
                                cmd.Parameters.AddWithValue("@NamaSatici", bes[j].NamaSatici);
                                cmd.Parameters.AddWithValue("@NamaSaticiAd", bes[j].NamaSaticiAd);
                                cmd.Parameters.AddWithValue("@Vdatu", bes[j].Vdatu);
                                cmd.Parameters.AddWithValue("@Bstkd", bes[j].Bstkd);
                                #endregion
                                cmd.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                SAPs.HataYaz("SAP_SIPARIS_BASLIK", Convert.ToInt64(bes[j].Vbeln).ToString(), "", "", "", "", ex.Message, cekilecektarih, cekilecektarih.AddDays(1));
                            }
                            conn.Close();
                        }
                    }
                    #endregion

                    #region item
                    if (oniki != null)
                    {
                        for (int j = 0; j < oniki.Length; j++)
                        {
                            try
                            {
                                conn.Open();
                                SqlCommand cmd = new SqlCommand(
                                    "DELETE FROM [SAP_SIPARIS_DETAY] WHERE Vbeln = @Vbeln AND Posnr = @Posnr " +
                                    "INSERT INTO [SAP_SIPARIS_DETAY] (KAYIT_TARIHI,[Vbeln],[Posnr],[Matnr],[Arktx],[Pltyp],[Ptext],[Zterm],[Netdt],[Matkl],[Wgbez],[Spart],[Vtext2],[Ean11],[Kwmeng],[Vrkme],[Vrkme Text],[Kwmeng2],[Vrkme2],[Vrkme2Text],[Ean112],[Yuz1],[Yuz2],[Yuz3],[Yuz4],[Yuz5],[Yuz6],[Yuz7],[Yuz8],[Yuz9],[Yuz10],[Brtpr],[Netpr],[Netwr],[Kzwi1],[Kdvoran],[Mwsbp],[Waerk],[Brgew],[Ntgew],[Gewei],[Volum],[Voleh],[Ksc1],[Ksc2],[Ksc3],[Ksc4],[Ksc5],[Ksc6],[Ksc7],[Ksc8],[Ksc9],[Ksc10],[Zzpirbz],[Zzpirgt],[Abgru],[Bezei_ab]) VALUES (@KAYIT_TARIHI,@Vbeln,@Posnr,@Matnr,@Arktx,@Pltyp,@Ptext,@Zterm,@Netdt,@Matkl,@Wgbez,@Spart,@Vtext2,@Ean11,@Kwmeng,@Vrkme,@VrkmeText,@Kwmeng2,@Vrkme2,@Vrkme2Text,@Ean112,@Yuz1,@Yuz2,@Yuz3,@Yuz4,@Yuz5,@Yuz6,@Yuz7,@Yuz8,@Yuz9,@Yuz10,@Brtpr,@Netpr,@Netwr,@Kzwi1,@Kdvoran,@Mwsbp,@Waerk,@Brgew,@Ntgew,@Gewei,@Volum,@Voleh,@Ksc1,@Ksc2,@Ksc3,@Ksc4,@Ksc5,@Ksc6,@Ksc7,@Ksc8,@Ksc9,@Ksc10,@Zzpirbz,@Zzpirgt,@Abgru,@Bezei_ab)", conn);
                                #region parameters
                                cmd.Parameters.AddWithValue("@KAYIT_TARIHI", DateTime.Now);
                                cmd.Parameters.AddWithValue("@Vbeln", Convert.ToInt64(oniki[j].Vbeln));
                                cmd.Parameters.AddWithValue("@Posnr", Convert.ToInt32(oniki[j].Posnr));
                                cmd.Parameters.AddWithValue("@Matnr", oniki[j].Matnr == string.Empty ? 0 : Convert.ToInt32(oniki[j].Matnr));
                                cmd.Parameters.AddWithValue("@Arktx", oniki[j].Arktx);
                                cmd.Parameters.AddWithValue("@Pltyp", oniki[j].Pltyp);
                                cmd.Parameters.AddWithValue("@Ptext", oniki[j].Ptext);
                                cmd.Parameters.AddWithValue("@Zterm", oniki[j].Zterm == string.Empty ? 0 : Convert.ToInt32(oniki[j].Zterm));
                                cmd.Parameters.AddWithValue("@Netdt", oniki[j].Netdt.StartsWith("0000") ? Convert.ToDateTime("01.01.1900") : Convert.ToDateTime(oniki[j].Netdt));
                                cmd.Parameters.AddWithValue("@Matkl", oniki[j].Matkl);
                                cmd.Parameters.AddWithValue("@Wgbez", oniki[j].Wgbez);
                                cmd.Parameters.AddWithValue("@Spart", oniki[j].Spart);
                                cmd.Parameters.AddWithValue("@Vtext2", oniki[j].Vtext2);
                                cmd.Parameters.AddWithValue("@Ean11", oniki[j].Ean11);
                                cmd.Parameters.AddWithValue("@Kwmeng", oniki[j].Kwmeng);
                                cmd.Parameters.AddWithValue("@Vrkme", oniki[j].Vrkme);
                                cmd.Parameters.AddWithValue("@VrkmeText", oniki[j].VrkmeText);
                                cmd.Parameters.AddWithValue("@Kwmeng2", oniki[j].Kwmeng2);
                                cmd.Parameters.AddWithValue("@Vrkme2", oniki[j].Vrkme2);
                                cmd.Parameters.AddWithValue("@Vrkme2Text", oniki[j].Vrkme2Text);
                                cmd.Parameters.AddWithValue("@Ean112", oniki[j].Ean112);
                                cmd.Parameters.AddWithValue("@Yuz1", oniki[j].Yuz1);
                                cmd.Parameters.AddWithValue("@Yuz2", oniki[j].Yuz2);
                                cmd.Parameters.AddWithValue("@Yuz3", oniki[j].Yuz3);
                                cmd.Parameters.AddWithValue("@Yuz4", oniki[j].Yuz4);
                                cmd.Parameters.AddWithValue("@Yuz5", oniki[j].Yuz5);
                                cmd.Parameters.AddWithValue("@Yuz6", oniki[j].Yuz6);
                                cmd.Parameters.AddWithValue("@Yuz7", oniki[j].Yuz7);
                                cmd.Parameters.AddWithValue("@Yuz8", oniki[j].Yuz8);
                                cmd.Parameters.AddWithValue("@Yuz9", oniki[j].Yuz9);
                                cmd.Parameters.AddWithValue("@Yuz10", oniki[j].Yuz10);
                                cmd.Parameters.AddWithValue("@Brtpr", oniki[j].Brtpr);
                                cmd.Parameters.AddWithValue("@Netpr", oniki[j].Netpr);
                                cmd.Parameters.AddWithValue("@Netwr", oniki[j].Netwr);
                                cmd.Parameters.AddWithValue("@Kzwi1", oniki[j].Kzwi1);
                                cmd.Parameters.AddWithValue("@Kdvoran", Convert.ToInt32(oniki[j].Kdvoran));
                                cmd.Parameters.AddWithValue("@Mwsbp", oniki[j].Mwsbp);
                                cmd.Parameters.AddWithValue("@Waerk", oniki[j].Waerk);
                                cmd.Parameters.AddWithValue("@Brgew", oniki[j].Brgew);
                                cmd.Parameters.AddWithValue("@Ntgew", oniki[j].Ntgew);
                                cmd.Parameters.AddWithValue("@Gewei", oniki[j].Gewei);
                                cmd.Parameters.AddWithValue("@Volum", oniki[j].Volum);
                                cmd.Parameters.AddWithValue("@Voleh", oniki[j].Voleh);
                                cmd.Parameters.AddWithValue("@Ksc1", oniki[j].Ksc1);
                                cmd.Parameters.AddWithValue("@Ksc2", oniki[j].Ksc2);
                                cmd.Parameters.AddWithValue("@Ksc3", oniki[j].Ksc3);
                                cmd.Parameters.AddWithValue("@Ksc4", oniki[j].Ksc4);
                                cmd.Parameters.AddWithValue("@Ksc5", oniki[j].Ksc5);
                                cmd.Parameters.AddWithValue("@Ksc6", oniki[j].Ksc6);
                                cmd.Parameters.AddWithValue("@Ksc7", oniki[j].Ksc7);
                                cmd.Parameters.AddWithValue("@Ksc8", oniki[j].Ksc8);
                                cmd.Parameters.AddWithValue("@Ksc9", oniki[j].Ksc9);
                                cmd.Parameters.AddWithValue("@Ksc10", oniki[j].Ksc10);
                                cmd.Parameters.AddWithValue("@Zzpirbz", oniki[j].Zzpirbz);
                                cmd.Parameters.AddWithValue("@Zzpirgt", oniki[j].Zzpirgt);
                                cmd.Parameters.AddWithValue("@Abgru", oniki[j].Abgru);
                                cmd.Parameters.AddWithValue("@Bezei_ab", oniki[j].BezeiAb);
                                #endregion
                                cmd.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                SAPs.HataYaz("SAP_SIPARIS_DETAY", Convert.ToInt64(oniki[j].Vbeln).ToString(), Convert.ToInt32(oniki[j].Posnr).ToString(), "", "", "", ex.Message, cekilecektarih, cekilecektarih.AddDays(1));
                            }
                            conn.Close();
                        }
                    }
                    #endregion

                    #region vbfa
                    if (dokuz != null)
                    {
                        for (int j = 0; j < dokuz.Length; j++)
                        {
                            try
                            {
                                conn.Open();
                                SqlCommand cmd = new SqlCommand("sp_SAP_VBFA_InsertUpdate", conn);
                                cmd.CommandType = CommandType.StoredProcedure;
                                #region parameters
                                cmd.Parameters.AddWithValue("@KAYIT_TARIHI", DateTime.Now);
                                cmd.Parameters.AddWithValue("@Vbelv", Convert.ToInt64(dokuz[j].Vbelv));
                                cmd.Parameters.AddWithValue("@Posnv", Convert.ToInt32(dokuz[j].Posnv));
                                cmd.Parameters.AddWithValue("@Vbeln", Convert.ToInt64(dokuz[j].Vbeln));
                                cmd.Parameters.AddWithValue("@Posnn", Convert.ToInt32(dokuz[j].Posnn));
                                cmd.Parameters.AddWithValue("@VbtypN", dokuz[j].VbtypN);
                                cmd.Parameters.AddWithValue("@Rfmng", dokuz[j].Rfmng);
                                cmd.Parameters.AddWithValue("@Meins", dokuz[j].Meins);
                                cmd.Parameters.AddWithValue("@Rfwrt", dokuz[j].Rfwrt);
                                cmd.Parameters.AddWithValue("@Waers", dokuz[j].Waers);
                                cmd.Parameters.AddWithValue("@VbtypV", dokuz[j].VbtypV);
                                cmd.Parameters.AddWithValue("@Plmin", dokuz[j].Plmin);
                                cmd.Parameters.AddWithValue("@Taqui", dokuz[j].Taqui);
                                cmd.Parameters.AddWithValue("@Erdat", Convert.ToDateTime(dokuz[j].Erdat + " " + dokuz[j].Erzet));
                                cmd.Parameters.AddWithValue("@Erzet", dokuz[j].Erzet);
                                cmd.Parameters.AddWithValue("@Matnr", dokuz[j].Matnr == string.Empty ? 0 : Convert.ToInt32(dokuz[j].Matnr));
                                cmd.Parameters.AddWithValue("@Bwart", dokuz[j].Bwart);
                                cmd.Parameters.AddWithValue("@Bdart", dokuz[j].Bdart);
                                cmd.Parameters.AddWithValue("@Plart", dokuz[j].Plart);
                                cmd.Parameters.AddWithValue("@Stufe", dokuz[j].Stufe);
                                cmd.Parameters.AddWithValue("@Lgnum", dokuz[j].Lgnum);
                                cmd.Parameters.AddWithValue("@Aedat", dokuz[j].Aedat.StartsWith("0000") ? Convert.ToDateTime("01.01.1900") : Convert.ToDateTime(dokuz[j].Aedat));
                                cmd.Parameters.AddWithValue("@Fktyp", dokuz[j].Fktyp);
                                cmd.Parameters.AddWithValue("@Brgew", dokuz[j].Brgew);
                                cmd.Parameters.AddWithValue("@Gewei", dokuz[j].Gewei);
                                cmd.Parameters.AddWithValue("@Volum", dokuz[j].Volum);
                                cmd.Parameters.AddWithValue("@Voleh", dokuz[j].Voleh);
                                cmd.Parameters.AddWithValue("@Fplnr", dokuz[j].Fplnr);
                                cmd.Parameters.AddWithValue("@Fpltr", dokuz[j].Fpltr);
                                cmd.Parameters.AddWithValue("@RfmngFlo", dokuz[j].RfmngFlo);
                                cmd.Parameters.AddWithValue("@RfmngFlt", dokuz[j].RfmngFlt);
                                cmd.Parameters.AddWithValue("@Vrkme", dokuz[j].Vrkme);
                                cmd.Parameters.AddWithValue("@Abges", dokuz[j].Abges);
                                cmd.Parameters.AddWithValue("@Sobkz", dokuz[j].Sobkz);
                                cmd.Parameters.AddWithValue("@Sonum", dokuz[j].Sonum);
                                cmd.Parameters.AddWithValue("@Kzbef", dokuz[j].Kzbef);
                                cmd.Parameters.AddWithValue("@Ntgew", dokuz[j].Ntgew);
                                cmd.Parameters.AddWithValue("@Logsys", dokuz[j].Logsys);
                                cmd.Parameters.AddWithValue("@Wbsta", dokuz[j].Wbsta);
                                cmd.Parameters.AddWithValue("@Cmeth", dokuz[j].Cmeth);
                                cmd.Parameters.AddWithValue("@Mjahr", dokuz[j].Mjahr);
                                #endregion
                                cmd.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                SAPs.HataYaz("SAP_VBFA", Convert.ToInt64(dokuz[j].Vbelv).ToString(), Convert.ToInt32(dokuz[j].Posnv).ToString(), Convert.ToInt64(dokuz[j].Vbeln).ToString(), Convert.ToInt32(dokuz[j].Posnn).ToString(), dokuz[j].VbtypN, "(SIPARIS) - " + ex.Message, cekilecektarih, cekilecektarih.AddDays(1));
                            }
                            conn.Close();
                        }
                    }
                    #endregion

                    cekilecektarih = cekilecektarih.AddDays(1);
                }

                if (!hatavar)
                    MaxTarihYaz(conn, "SAP_Siparis", bitistarih);
            }
            #endregion



            #region TESLIMAT
            if (teslimat)
            {
                DateTime maxtarih = Convert.ToDateTime(DateTime.Now.AddDays(-2).ToShortDateString() + " 00:30:00");
                DateTime bitistarih = DateTime.Now;
                bool hatavar = false;

                selectsalesdeliveryC.ZwebSelectSalesDeliveryService client3 = new selectsalesdeliveryC.ZwebSelectSalesDeliveryService();
                client3.Timeout = 6000000;
                client3.Credentials = nc1;

                DateTime cekilecektarih = maxtarih;
                DateTime simdikitarih = DateTime.Now;
                while (Convert.ToDateTime(cekilecektarih.ToShortDateString()) <= Convert.ToDateTime(simdikitarih.ToShortDateString()))
                {
                    selectsalesdeliveryC.Zwebs009[] dokuz = null; // vbfa
                    selectsalesdeliveryC.Zwebs006[] alti = null; // head
                    selectsalesdeliveryC.Zwebs013[] onuc = null; // item
                    selectsalesdeliveryC.Zwebs021[] yirmibir = null; // logdel

                    string hata = string.Empty;
                    string tarih = "";
                    string saat = "00:00:00";

                    int tekrarcek = 0;
                    while (tekrarcek < tekrarcekilecek)
                    {
                        try
                        {
                            TarihSaat(maxtarih, cekilecektarih, out tarih, out saat);
                            alti = client3.ZwebSelectSalesDelivery(tarih, "", saat, out onuc, out yirmibir, out dokuz);
                            tekrarcek = tekrarcekilecek;
                        }
                        catch (Exception ex)
                        {
                            SAPs.LogYaz("select sales delivery", true, cekilecektarih.ToShortDateString() + " " + (tekrarcek + 1).ToString() + ".deneme sap hata döndürdü: " + ex.Message, DateTime.Now, DateTime.Now);
                            if (tekrarcek < tekrarcekilecek)
                            {
                                tekrarcek++;
                                System.Threading.Thread.Sleep(3000);
                            }
                            else
                            {
                                hata = ex.Message;
                                hatavar = true;
                                cekilecektarih = DateTime.Now; // while dan çıksın bir sonraki günü almasın max tarihi yenilemesin
                            }
                        }
                    }

                    SAPs.LogYaz("select sales delivery", hata != string.Empty ? false : true, hata, Convert.ToDateTime(cekilecektarih.ToShortDateString() + " " + saat), Convert.ToDateTime(cekilecektarih.ToShortDateString()) == Convert.ToDateTime(simdikitarih.ToShortDateString()) ? DateTime.Now : Convert.ToDateTime(cekilecektarih.AddDays(1).ToShortDateString() + " 00:00:00"));

                    #region logdel
                    if (yirmibir != null)
                    {
                        for (int j = 0; j < yirmibir.Length; j++)
                        {
                            try
                            {
                                conn.Open();
                                SqlCommand cmd = new SqlCommand("DELETE FROM [SAP_TESLIMAT_BASLIK] WHERE Vbeln = @Vbeln DELETE FROM [SAP_TESLIMAT_DETAY] WHERE Vbeln = @Vbeln DELETE FROM [SAP_VBFA] WHERE Vbelv = @Vbeln DELETE FROM [SAP_VBFA] WHERE Vbeln = @Vbeln", conn);
                                cmd.Parameters.AddWithValue("@Vbeln", Convert.ToInt64(yirmibir[j].Vbeln));
                                cmd.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                SAPs.HataYaz("SAP_TESLIMAT_BASLIK", Convert.ToInt64(yirmibir[j].Vbeln).ToString(), "", "", "", "", "(LOGDEL) - " + ex.Message, cekilecektarih, cekilecektarih.AddDays(1));
                            }
                            conn.Close();
                        }
                    }
                    #endregion

                    #region head
                    if (alti != null)
                    {
                        for (int j = 0; j < alti.Length; j++)
                        {
                            try
                            {
                                conn.Open();
                                SqlCommand cmd = new SqlCommand(
                                    "DELETE FROM [SAP_TESLIMAT_BASLIK] WHERE Vbeln = @Vbeln " +
                                    "DELETE FROM [SAP_TESLIMAT_DETAY] WHERE Vbeln = @Vbeln " +
                                    "DELETE FROM [SAP_VBFA] WHERE Vbeln = @Vbeln " +
                                    "DELETE FROM [SAP_VBFA] WHERE Vbelv = @Vbeln " +
                                    "INSERT INTO [SAP_TESLIMAT_BASLIK] (KAYIT_TARIHI,[Lfart],[Vtext],[Vbeln],[Ernam],[Erzet],[Erdat],[Sevkalani],[Sevkyeri],[Teslimat Aciklama],[Volum],[Btgew],[Voleh],[Gewei],[Lifex]) VALUES (@KAYIT_TARIHI,@Lfart,@Vtext,@Vbeln,@Ernam,@Erzet,@Erdat,@Sevkalani,@Sevkyeri,@TeslimatAciklama,@Volum,@Btgew,@Voleh,@Gewei,@Lifex)", conn);
                                #region parameters
                                cmd.Parameters.AddWithValue("@KAYIT_TARIHI", DateTime.Now);
                                cmd.Parameters.AddWithValue("@Lfart", alti[j].Lfart);
                                cmd.Parameters.AddWithValue("@Vtext", alti[j].Vtext);
                                cmd.Parameters.AddWithValue("@Vbeln", Convert.ToInt64(alti[j].Vbeln));
                                cmd.Parameters.AddWithValue("@Ernam", alti[j].Ernam);
                                cmd.Parameters.AddWithValue("@Erzet", alti[j].Erzet);
                                cmd.Parameters.AddWithValue("@Erdat", Convert.ToDateTime(alti[j].Erdat + " " + alti[j].Erzet));
                                cmd.Parameters.AddWithValue("@Sevkalani", alti[j].Sevkalani);
                                cmd.Parameters.AddWithValue("@Sevkyeri", alti[j].Sevkyeri);
                                cmd.Parameters.AddWithValue("@TeslimatAciklama", alti[j].TeslimatAciklama);
                                cmd.Parameters.AddWithValue("@Volum", alti[j].Volum);
                                cmd.Parameters.AddWithValue("@Btgew", alti[j].Btgew);
                                cmd.Parameters.AddWithValue("@Voleh", alti[j].Voleh);
                                cmd.Parameters.AddWithValue("@Gewei", alti[j].Gewei);
                                cmd.Parameters.AddWithValue("@Lifex", alti[j].Lifex);
                                #endregion
                                cmd.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                SAPs.HataYaz("SAP_TESLIMAT_BASLIK", Convert.ToInt64(alti[j].Vbeln).ToString(), "", "", "", "", ex.Message, cekilecektarih, cekilecektarih.AddDays(1));
                            }
                            conn.Close();
                        }
                    }
                    #endregion

                    #region item
                    if (onuc != null)
                    {
                        for (int j = 0; j < onuc.Length; j++)
                        {
                            try
                            {
                                conn.Open();
                                SqlCommand cmd = new SqlCommand(
                                    "DELETE FROM [SAP_TESLIMAT_DETAY] WHERE Vbeln = @Vbeln AND Posnr = @Posnr " +
                                    "INSERT INTO [SAP_TESLIMAT_DETAY] (KAYIT_TARIHI,[Vbeln],[Posnr],[Matnr],[Ernam],[Erzet],[Erdat],[Matkl],[Werks],[Lgort],[Charg],[Lfimg],[Meins],[Meins Text],[Ntgew],[Brgew],[Gewei],[Volum],[Voleh],Hsdat) VALUES (@KAYIT_TARIHI,@Vbeln,@Posnr,@Matnr,@Ernam,@Erzet,@Erdat,@Matkl,@Werks,@Lgort,@Charg,@Lfimg,@Meins,@MeinsText,@Ntgew,@Brgew,@Gewei,@Volum,@Voleh,@Hsdat)", conn);
                                #region parameters
                                cmd.Parameters.AddWithValue("@KAYIT_TARIHI", DateTime.Now);
                                cmd.Parameters.AddWithValue("@Vbeln", Convert.ToInt64(onuc[j].Vbeln));
                                cmd.Parameters.AddWithValue("@Posnr", Convert.ToInt32(onuc[j].Posnr));
                                cmd.Parameters.AddWithValue("@Matnr", onuc[j].Matnr == string.Empty ? 0 : Convert.ToInt32(onuc[j].Matnr));
                                cmd.Parameters.AddWithValue("@Ernam", onuc[j].Ernam);
                                cmd.Parameters.AddWithValue("@Erzet", onuc[j].Erzet);
                                cmd.Parameters.AddWithValue("@Erdat", Convert.ToDateTime(onuc[j].Erdat + " " + onuc[j].Erzet));
                                cmd.Parameters.AddWithValue("@Matkl", onuc[j].Matkl);
                                cmd.Parameters.AddWithValue("@Werks", onuc[j].Werks);
                                cmd.Parameters.AddWithValue("@Lgort", onuc[j].Lgort);
                                cmd.Parameters.AddWithValue("@Charg", onuc[j].Charg);
                                cmd.Parameters.AddWithValue("@Lfimg", onuc[j].Lfimg);
                                cmd.Parameters.AddWithValue("@Meins", onuc[j].Meins);
                                cmd.Parameters.AddWithValue("@MeinsText", onuc[j].MeinsText);
                                cmd.Parameters.AddWithValue("@Ntgew", onuc[j].Ntgew);
                                cmd.Parameters.AddWithValue("@Brgew", onuc[j].Brgew);
                                cmd.Parameters.AddWithValue("@Gewei", onuc[j].Gewei);
                                cmd.Parameters.AddWithValue("@Volum", onuc[j].Volum);
                                cmd.Parameters.AddWithValue("@Voleh", onuc[j].Voleh);
                                cmd.Parameters.AddWithValue("@Hsdat", (onuc[j].Hsdat != "0000-00-00" ? (Convert.ToDateTime(onuc[j].Hsdat) < Convert.ToDateTime("01.01.1900") ? Convert.ToDateTime("01.01.1900") : Convert.ToDateTime(onuc[j].Hsdat)) : Convert.ToDateTime("01.01.1900")));
                                #endregion
                                cmd.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                SAPs.HataYaz("SAP_TESLIMAT_DETAY", Convert.ToInt64(onuc[j].Vbeln).ToString(), Convert.ToInt32(onuc[j].Posnr).ToString(), "", "", "", ex.Message, cekilecektarih, cekilecektarih.AddDays(1));
                            }
                            conn.Close();
                        }
                    }
                    #endregion

                    #region vbfa
                    if (dokuz != null)
                    {
                        for (int j = 0; j < dokuz.Length; j++)
                        {
                            try
                            {
                                conn.Open();
                                SqlCommand cmd = new SqlCommand("sp_SAP_VBFA_InsertUpdate", conn);
                                cmd.CommandType = CommandType.StoredProcedure;
                                #region parameters
                                cmd.Parameters.AddWithValue("@KAYIT_TARIHI", DateTime.Now);
                                cmd.Parameters.AddWithValue("@Vbelv", Convert.ToInt64(dokuz[j].Vbelv));
                                cmd.Parameters.AddWithValue("@Posnv", Convert.ToInt32(dokuz[j].Posnv));
                                cmd.Parameters.AddWithValue("@Vbeln", Convert.ToInt64(dokuz[j].Vbeln));
                                cmd.Parameters.AddWithValue("@Posnn", Convert.ToInt32(dokuz[j].Posnn));
                                cmd.Parameters.AddWithValue("@VbtypN", dokuz[j].VbtypN);
                                cmd.Parameters.AddWithValue("@Rfmng", dokuz[j].Rfmng);
                                cmd.Parameters.AddWithValue("@Meins", dokuz[j].Meins);
                                cmd.Parameters.AddWithValue("@Rfwrt", dokuz[j].Rfwrt);
                                cmd.Parameters.AddWithValue("@Waers", dokuz[j].Waers);
                                cmd.Parameters.AddWithValue("@VbtypV", dokuz[j].VbtypV);
                                cmd.Parameters.AddWithValue("@Plmin", dokuz[j].Plmin);
                                cmd.Parameters.AddWithValue("@Taqui", dokuz[j].Taqui);
                                cmd.Parameters.AddWithValue("@Erdat", Convert.ToDateTime(dokuz[j].Erdat + " " + dokuz[j].Erzet));
                                cmd.Parameters.AddWithValue("@Erzet", dokuz[j].Erzet);
                                cmd.Parameters.AddWithValue("@Matnr", dokuz[j].Matnr == string.Empty ? 0 : Convert.ToInt32(dokuz[j].Matnr));
                                cmd.Parameters.AddWithValue("@Bwart", dokuz[j].Bwart);
                                cmd.Parameters.AddWithValue("@Bdart", dokuz[j].Bdart);
                                cmd.Parameters.AddWithValue("@Plart", dokuz[j].Plart);
                                cmd.Parameters.AddWithValue("@Stufe", dokuz[j].Stufe);
                                cmd.Parameters.AddWithValue("@Lgnum", dokuz[j].Lgnum);
                                cmd.Parameters.AddWithValue("@Aedat", dokuz[j].Aedat.StartsWith("0000") ? Convert.ToDateTime("01.01.1900") : Convert.ToDateTime(dokuz[j].Aedat));
                                cmd.Parameters.AddWithValue("@Fktyp", dokuz[j].Fktyp);
                                cmd.Parameters.AddWithValue("@Brgew", dokuz[j].Brgew);
                                cmd.Parameters.AddWithValue("@Gewei", dokuz[j].Gewei);
                                cmd.Parameters.AddWithValue("@Volum", dokuz[j].Volum);
                                cmd.Parameters.AddWithValue("@Voleh", dokuz[j].Voleh);
                                cmd.Parameters.AddWithValue("@Fplnr", dokuz[j].Fplnr);
                                cmd.Parameters.AddWithValue("@Fpltr", dokuz[j].Fpltr);
                                cmd.Parameters.AddWithValue("@RfmngFlo", dokuz[j].RfmngFlo);
                                cmd.Parameters.AddWithValue("@RfmngFlt", dokuz[j].RfmngFlt);
                                cmd.Parameters.AddWithValue("@Vrkme", dokuz[j].Vrkme);
                                cmd.Parameters.AddWithValue("@Abges", dokuz[j].Abges);
                                cmd.Parameters.AddWithValue("@Sobkz", dokuz[j].Sobkz);
                                cmd.Parameters.AddWithValue("@Sonum", dokuz[j].Sonum);
                                cmd.Parameters.AddWithValue("@Kzbef", dokuz[j].Kzbef);
                                cmd.Parameters.AddWithValue("@Ntgew", dokuz[j].Ntgew);
                                cmd.Parameters.AddWithValue("@Logsys", dokuz[j].Logsys);
                                cmd.Parameters.AddWithValue("@Wbsta", dokuz[j].Wbsta);
                                cmd.Parameters.AddWithValue("@Cmeth", dokuz[j].Cmeth);
                                cmd.Parameters.AddWithValue("@Mjahr", dokuz[j].Mjahr);
                                #endregion
                                cmd.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                SAPs.HataYaz("SAP_VBFA", Convert.ToInt64(dokuz[j].Vbelv).ToString(), Convert.ToInt32(dokuz[j].Posnv).ToString(), Convert.ToInt64(dokuz[j].Vbeln).ToString(), Convert.ToInt32(dokuz[j].Posnn).ToString(), dokuz[j].VbtypN, "(TESLIMAT) - " + ex.Message, cekilecektarih, cekilecektarih.AddDays(1));
                            }
                            conn.Close();
                        }
                    }
                    #endregion

                    cekilecektarih = cekilecektarih.AddDays(1);
                }

                if (!hatavar)
                    MaxTarihYaz(conn, "SAP_Teslimat", bitistarih);
            }
            #endregion



            #region NAKILSIPARIS MALCIKIS FATURA
            if (nakilmalfatura)
            {
                DateTime maxtarih = Convert.ToDateTime(DateTime.Now.AddDays(-2).ToShortDateString() + " 00:30:00");
                DateTime bitistarih = DateTime.Now;
                bool hatavar = false;

                selectsalestransportC.ZwebSelectSalesTransportService client4 = new selectsalestransportC.ZwebSelectSalesTransportService();
                client4.Timeout = 6000000;
                client4.Credentials = nc1;

                DateTime cekilecektarih = maxtarih;
                DateTime simdikitarih = DateTime.Now;
                while (Convert.ToDateTime(cekilecektarih.ToShortDateString()) <= Convert.ToDateTime(simdikitarih.ToShortDateString()))
                {
                    selectsalestransportC.Zwebs007[] yedi = null;
                    selectsalestransportC.Zwebs014[] ondort = null;
                    selectsalestransportC.Zwebs015[] onbes = null;
                    selectsalestransportC.Zwebs016[] onalti = null;
                    selectsalestransportC.Zwebs017[] onyedi = null;
                    selectsalestransportC.Zwebs018[] onsekiz = null;

                    string hata = string.Empty;
                    string tarih = "";
                    string saat = "00:00:00";

                    int tekrarcek = 0;
                    while (tekrarcek < tekrarcekilecek)
                    {
                        try
                        {
                            TarihSaat(maxtarih, cekilecektarih, out tarih, out saat);
                            onbes = client4.ZwebSelectSalesTransport(tarih, saat, out onalti, out onyedi, out onsekiz, out yedi, out ondort);
                            tekrarcek = tekrarcekilecek;
                        }
                        catch (Exception ex)
                        {
                            SAPs.LogYaz("select sales transport", true, cekilecektarih.ToShortDateString() + " " + (tekrarcek + 1).ToString() + ".deneme sap hata döndürdü: " + ex.Message, DateTime.Now, DateTime.Now);
                            if (tekrarcek < tekrarcekilecek)
                            {
                                tekrarcek++;
                                System.Threading.Thread.Sleep(3000);
                            }
                            else
                            {
                                hata = ex.Message;
                                hatavar = true;
                                cekilecektarih = DateTime.Now; // while dan çıksın bir sonraki günü almasın max tarihi yenilemesin
                            }
                        }
                    }

                    SAPs.LogYaz("select sales transport", hata != string.Empty ? false : true, hata, Convert.ToDateTime(cekilecektarih.ToShortDateString() + " " + saat), Convert.ToDateTime(cekilecektarih.ToShortDateString()) == Convert.ToDateTime(simdikitarih.ToShortDateString()) ? DateTime.Now : Convert.ToDateTime(cekilecektarih.AddDays(1).ToShortDateString() + " 00:00:00"));

                    #region nakilsiparis

                    #region head
                    if (nakilsiparis && yedi != null)
                    {
                        for (int j = 0; j < yedi.Length; j++)
                        {
                            try
                            {
                                conn.Open();
                                SqlCommand cmd = new SqlCommand(
                                    "DELETE FROM [SAP_NAKILSIPARIS_BASLIK] WHERE Lgnum = @Lgnum AND Tanum = @Tanum " +
                                    "INSERT INTO [SAP_NAKILSIPARIS_BASLIK] (KAYIT_TARIHI,[Lgnum],[Tanum],[Qdatu],[Lgtor],[Koliadet]) VALUES (@KAYIT_TARIHI,@Lgnum,@Tanum,@Qdatu,@Lgtor,@Koliadet)", conn);
                                #region parameters
                                cmd.Parameters.AddWithValue("@KAYIT_TARIHI", DateTime.Now);
                                cmd.Parameters.AddWithValue("@Lgnum", yedi[j].Lgnum);
                                cmd.Parameters.AddWithValue("@Tanum", Convert.ToInt32(yedi[j].Tanum));
                                cmd.Parameters.AddWithValue("@Qdatu", yedi[j].Qdatu.StartsWith("0000") ? Convert.ToDateTime("01.01.1900") : Convert.ToDateTime(yedi[j].Qdatu));
                                cmd.Parameters.AddWithValue("@Lgtor", yedi[j].Lgtor);
                                cmd.Parameters.AddWithValue("@Koliadet", yedi[j].Koliadet);
                                #endregion
                                cmd.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                SAPs.HataYaz("SAP_NAKILSIPARIS_BASLIK", yedi[j].Lgnum, yedi[j].Tanum, "", "", "", ex.Message, cekilecektarih, cekilecektarih.AddDays(1));
                            }
                            conn.Close();
                        }
                    }
                    #endregion

                    #region item
                    if (nakilsiparis && ondort != null)
                    {
                        for (int j = 0; j < ondort.Length; j++)
                        {
                            try
                            {
                                conn.Open();
                                SqlCommand cmd = new SqlCommand(
                                    "DELETE FROM [SAP_NAKILSIPARIS_DETAY] WHERE Lgnum = @Lgnum AND Tanum = @Tanum AND Tapos = @Tapos " +
                                    "INSERT INTO [SAP_NAKILSIPARIS_DETAY] (KAYIT_TARIHI,[Lgnum],[Tanum],[Tapos],[Matnr],[Maktx],[Werks],[Charg],[Pquit],[Qdatu],[Qzeit],[Qname],[Brgew],[Gewei],[Ablad],[Volum],[Voleh],[Vbeln],[Vsolm],[Vistm],[Vdifm],[Meins],[Meins Text],[Vlber],[Vlpla],[Nlber],[Nlpla]) VALUES (@KAYIT_TARIHI,@Lgnum,@Tanum,@Tapos,@Matnr,@Maktx,@Werks,@Charg,@Pquit,@Qdatu,@Qzeit,@Qname,@Brgew,@Gewei,@Ablad,@Volum,@Voleh,@Vbeln,@Vsolm,@Vistm,@Vdifm,@Meins,@MeinsText,@Vlber,@Vlpla,@Nlber,@Nlpla)", conn);
                                #region parameters
                                cmd.Parameters.AddWithValue("@KAYIT_TARIHI", DateTime.Now);
                                cmd.Parameters.AddWithValue("@Lgnum", ondort[j].Lgnum);
                                cmd.Parameters.AddWithValue("@Tanum", Convert.ToInt32(ondort[j].Tanum));
                                cmd.Parameters.AddWithValue("@Tapos", Convert.ToInt32(ondort[j].Tapos));
                                cmd.Parameters.AddWithValue("@Matnr", ondort[j].Matnr == string.Empty ? 0 : Convert.ToInt32(ondort[j].Matnr));
                                cmd.Parameters.AddWithValue("@Maktx", ondort[j].Maktx);
                                cmd.Parameters.AddWithValue("@Werks", ondort[j].Werks);
                                cmd.Parameters.AddWithValue("@Charg", ondort[j].Charg);
                                cmd.Parameters.AddWithValue("@Pquit", ondort[j].Pquit);
                                cmd.Parameters.AddWithValue("@Qdatu", ondort[j].Qdatu.StartsWith("0000") ? Convert.ToDateTime("01.01.1900") : Convert.ToDateTime(ondort[j].Qdatu));
                                cmd.Parameters.AddWithValue("@Qzeit", ondort[j].Qzeit);
                                cmd.Parameters.AddWithValue("@Qname", ondort[j].Qname);
                                cmd.Parameters.AddWithValue("@Brgew", ondort[j].Brgew);
                                cmd.Parameters.AddWithValue("@Gewei", ondort[j].Gewei);
                                cmd.Parameters.AddWithValue("@Ablad", ondort[j].Ablad);
                                cmd.Parameters.AddWithValue("@Volum", ondort[j].Volum);
                                cmd.Parameters.AddWithValue("@Voleh", ondort[j].Voleh);
                                cmd.Parameters.AddWithValue("@Vbeln", ondort[j].Vbeln == string.Empty ? 0 : Convert.ToInt64(ondort[j].Vbeln));
                                cmd.Parameters.AddWithValue("@Vsolm", ondort[j].Vsolm);
                                cmd.Parameters.AddWithValue("@Vistm", ondort[j].Vistm);
                                cmd.Parameters.AddWithValue("@Vdifm", ondort[j].Vdifm);
                                cmd.Parameters.AddWithValue("@Meins", ondort[j].Meins);
                                cmd.Parameters.AddWithValue("@MeinsText", ondort[j].MeinsText);
                                cmd.Parameters.AddWithValue("@Vlber", ondort[j].Vlber);
                                cmd.Parameters.AddWithValue("@Vlpla", ondort[j].Vlpla);
                                cmd.Parameters.AddWithValue("@Nlber", ondort[j].Nlber);
                                cmd.Parameters.AddWithValue("@Nlpla", ondort[j].Nlpla);
                                #endregion
                                cmd.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                SAPs.HataYaz("SAP_NAKILSIPARIS_DETAY", ondort[j].Lgnum, ondort[j].Tanum, ondort[j].Tapos, "", "", ex.Message, cekilecektarih, cekilecektarih.AddDays(1));
                            }
                            conn.Close();
                        }
                    }
                    #endregion

                    #endregion

                    #region malcikis

                    #region head
                    if (malcikis && onbes != null)
                    {
                        for (int j = 0; j < onbes.Length; j++)
                        {
                            try
                            {
                                conn.Open();
                                SqlCommand cmd = new SqlCommand(
                                    "DELETE FROM [SAP_MALCIKIS_BASLIK] WHERE Mblnr = @Mblnr AND Mjahr = @Mjahr " +
                                    "INSERT INTO [SAP_MALCIKIS_BASLIK] (KAYIT_TARIHI,[Mblnr],[Mjahr],[Blart],[Ltext],[Vgart],[Ltext2],[Bldat],[Budat],[Le Vbeln]) VALUES (@KAYIT_TARIHI,@Mblnr,@Mjahr,@Blart,@Ltext,@Vgart,@Ltext2,@Bldat,@Budat,@LeVbeln)", conn);
                                #region parameters
                                cmd.Parameters.AddWithValue("@KAYIT_TARIHI", DateTime.Now);
                                cmd.Parameters.AddWithValue("@Mblnr", Convert.ToInt64(onbes[j].Mblnr));
                                cmd.Parameters.AddWithValue("@Mjahr", Convert.ToInt32(onbes[j].Mjahr));
                                cmd.Parameters.AddWithValue("@Blart", onbes[j].Blart);
                                cmd.Parameters.AddWithValue("@Ltext", onbes[j].Ltext);
                                cmd.Parameters.AddWithValue("@Vgart", onbes[j].Vgart);
                                cmd.Parameters.AddWithValue("@Ltext2", onbes[j].Ltext2);
                                cmd.Parameters.AddWithValue("@Bldat", onbes[j].Bldat.StartsWith("0000") ? Convert.ToDateTime("01.01.1900") : Convert.ToDateTime(onbes[j].Bldat));
                                cmd.Parameters.AddWithValue("@Budat", onbes[j].Budat.StartsWith("0000") ? Convert.ToDateTime("01.01.1900") : Convert.ToDateTime(onbes[j].Budat));
                                cmd.Parameters.AddWithValue("@LeVbeln", onbes[j].LeVbeln);
                                #endregion
                                cmd.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                SAPs.HataYaz("SAP_MALCIKIS_BASLIK", onbes[j].Mblnr, onbes[j].Mjahr, "", "", "", ex.Message, cekilecektarih, cekilecektarih.AddDays(1));
                            }
                            conn.Close();
                        }
                    }
                    #endregion

                    #region item
                    if (malcikis && onalti != null)
                    {
                        for (int j = 0; j < onalti.Length; j++)
                        {
                            try
                            {
                                conn.Open();
                                SqlCommand cmd = new SqlCommand(
                                    "DELETE FROM [SAP_MALCIKIS_DETAY] WHERE Mblnr = @Mblnr AND Mjahr = @Mjahr AND Zeile = @Zeile " +
                                    "INSERT INTO [SAP_MALCIKIS_DETAY] (KAYIT_TARIHI,[Mblnr],[Mjahr],[Zeile],[Matnr],[Werks],[Lgort],[Charg],[Kunnr],[Menge],[Meins],[Meins Text],[Lgnum],[Lgtyp],[Lgpla],[Sjahr],[Smbln],[Smblp],[Vbeln Vl],[Posnr Vl],[Vbeln],[Posnr]) VALUES (@KAYIT_TARIHI,@Mblnr,@Mjahr,@Zeile,@Matnr,@Werks,@Lgort,@Charg,@Kunnr,@Menge,@Meins,@MeinsText,@Lgnum,@Lgtyp,@Lgpla,@Sjahr,@Smbln,@Smblp,@VbelnVl,@PosnrVl,@Vbeln,@Posnr)", conn);
                                #region parameters
                                cmd.Parameters.AddWithValue("@KAYIT_TARIHI", DateTime.Now);
                                cmd.Parameters.AddWithValue("@Mblnr", Convert.ToInt64(onalti[j].Mblnr));
                                cmd.Parameters.AddWithValue("@Mjahr", Convert.ToInt32(onalti[j].Mjahr));
                                cmd.Parameters.AddWithValue("@Zeile", Convert.ToInt32(onalti[j].Zeile));
                                cmd.Parameters.AddWithValue("@Matnr", onalti[j].Matnr == string.Empty ? 0 : Convert.ToInt32(onalti[j].Matnr));
                                cmd.Parameters.AddWithValue("@Werks", onalti[j].Werks);
                                cmd.Parameters.AddWithValue("@Lgort", onalti[j].Lgort);
                                cmd.Parameters.AddWithValue("@Charg", onalti[j].Charg);
                                cmd.Parameters.AddWithValue("@Kunnr", onalti[j].Kunnr.StartsWith("T") || onalti[j].Kunnr == "" ? 10 : Convert.ToInt32(onalti[j].Kunnr));
                                cmd.Parameters.AddWithValue("@Menge", onalti[j].Menge);
                                cmd.Parameters.AddWithValue("@Meins", onalti[j].Meins);
                                cmd.Parameters.AddWithValue("@MeinsText", onalti[j].MeinsText);
                                cmd.Parameters.AddWithValue("@Lgnum", onalti[j].Lgnum);
                                cmd.Parameters.AddWithValue("@Lgtyp", onalti[j].Lgtyp);
                                cmd.Parameters.AddWithValue("@Lgpla", onalti[j].Lgpla);
                                cmd.Parameters.AddWithValue("@Sjahr", onalti[j].Sjahr);
                                cmd.Parameters.AddWithValue("@Smbln", onalti[j].Smbln);
                                cmd.Parameters.AddWithValue("@Smblp", onalti[j].Smblp);
                                cmd.Parameters.AddWithValue("@VbelnVl", onalti[j].VbelnVl);
                                cmd.Parameters.AddWithValue("@PosnrVl", onalti[j].PosnrVl);
                                cmd.Parameters.AddWithValue("@Vbeln", onalti[j].Vbeln);
                                cmd.Parameters.AddWithValue("@Posnr", onalti[j].Posnr);
                                #endregion
                                cmd.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                SAPs.HataYaz("SAP_MALCIKIS_DETAY", onalti[j].Mblnr, onalti[j].Mjahr, onalti[j].Zeile, "", "", ex.Message, cekilecektarih, cekilecektarih.AddDays(1));
                            }
                            conn.Close();
                        }
                    }
                    #endregion

                    #endregion

                    #region fatura

                    #region head
                    if (fatura && onyedi != null)
                    {
                        for (int j = 0; j < onyedi.Length; j++)
                        {
                            try
                            {
                                conn.Open();
                                SqlCommand cmd = new SqlCommand(
                                    "DELETE FROM [SAP_FATURA_BASLIK] WHERE Vbeln = @Vbeln " +
                                    "INSERT INTO [SAP_FATURA_BASLIK] (KAYIT_TARIHI,[Vbeln],[Fkart],[Vtext],[Fktyp],[Fktyp Text],[Vbtyp],[Vbtyp Text],[Waerk],[Vkorg],[Vtweg],[Kalsm],[Knumv],[Vsbed],[Fkdat],[Bukrs],[Belnr],[Gjahr],[Poper],[Ernam],[Erzet],[Erdat],[Kunrg],[Sfakn],[Fksto],[Xblnr],[Zuonr]) VALUES (@KAYIT_TARIHI,@Vbeln,@Fkart,@Vtext,@Fktyp,@FktypText,@Vbtyp,@VbtypText,@Waerk,@Vkorg,@Vtweg,@Kalsm,@Knumv,@Vsbed,@Fkdat,@Bukrs,@Belnr,@Gjahr,@Poper,@Ernam,@Erzet,@Erdat,@Kunrg,@Sfakn,@Fksto,@Xblnr,@Zuonr)", conn);
                                #region parameters
                                cmd.Parameters.AddWithValue("@KAYIT_TARIHI", DateTime.Now);
                                cmd.Parameters.AddWithValue("@Vbeln", Convert.ToInt64(onyedi[j].Vbeln));
                                cmd.Parameters.AddWithValue("@Fkart", onyedi[j].Fkart);
                                cmd.Parameters.AddWithValue("@Vtext", onyedi[j].Vtext);
                                cmd.Parameters.AddWithValue("@Fktyp", onyedi[j].Fktyp);
                                cmd.Parameters.AddWithValue("@FktypText", onyedi[j].FktypText);
                                cmd.Parameters.AddWithValue("@Vbtyp", onyedi[j].Vbtyp);
                                cmd.Parameters.AddWithValue("@VbtypText", onyedi[j].VbtypText);
                                cmd.Parameters.AddWithValue("@Waerk", onyedi[j].Waerk);
                                cmd.Parameters.AddWithValue("@Vkorg", onyedi[j].Vkorg);
                                cmd.Parameters.AddWithValue("@Vtweg", onyedi[j].Vtweg);
                                cmd.Parameters.AddWithValue("@Kalsm", onyedi[j].Kalsm);
                                cmd.Parameters.AddWithValue("@Knumv", onyedi[j].Knumv.StartsWith("T") || onyedi[j].Knumv == "" ? 10 : Convert.ToInt32(onyedi[j].Knumv));
                                cmd.Parameters.AddWithValue("@Vsbed", onyedi[j].Vsbed);
                                cmd.Parameters.AddWithValue("@Fkdat", onyedi[j].Fkdat.StartsWith("0000") ? Convert.ToDateTime("01.01.1900") : Convert.ToDateTime(onyedi[j].Fkdat));
                                cmd.Parameters.AddWithValue("@Bukrs", onyedi[j].Bukrs);
                                cmd.Parameters.AddWithValue("@Belnr", onyedi[j].Belnr);
                                cmd.Parameters.AddWithValue("@Gjahr", onyedi[j].Gjahr);
                                cmd.Parameters.AddWithValue("@Poper", onyedi[j].Poper);
                                cmd.Parameters.AddWithValue("@Ernam", onyedi[j].Ernam);
                                cmd.Parameters.AddWithValue("@Erzet", onyedi[j].Erzet);
                                cmd.Parameters.AddWithValue("@Erdat", Convert.ToDateTime(onyedi[j].Erdat + " " + onyedi[j].Erzet));
                                cmd.Parameters.AddWithValue("@Kunrg", onyedi[j].Kunrg);
                                cmd.Parameters.AddWithValue("@Sfakn", onyedi[j].Sfakn);
                                cmd.Parameters.AddWithValue("@Fksto", onyedi[j].Fksto);
                                cmd.Parameters.AddWithValue("@Xblnr", onyedi[j].Xblnr);
                                cmd.Parameters.AddWithValue("@Zuonr", onyedi[j].Zuonr);
                                #endregion
                                cmd.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                SAPs.HataYaz("SAP_FATURA_BASLIK", onyedi[j].Vbeln, "", "", "", "", ex.Message, cekilecektarih, cekilecektarih.AddDays(1));
                            }
                            conn.Close();
                        }
                    }
                    #endregion

                    #region item
                    if (fatura && onsekiz != null)
                    {
                        for (int j = 0; j < onsekiz.Length; j++)
                        {
                            try
                            {
                                conn.Open();
                                SqlCommand cmd = new SqlCommand(
                                    "DELETE FROM [SAP_FATURA_DETAY] WHERE Vbeln = @Vbeln AND Posnr = @Posnr " +
                                    "INSERT INTO [SAP_FATURA_DETAY] (KAYIT_TARIHI,[Vbeln],[Posnr],[Fkimg],[Vrkme],[Vrkme Text],[Ntgew],[Brgew],[Gewei],[Volum],[Voleh],[Vgbel],[Vgpos],[Vgtyp],[Aubel],[Aupos],[Auref],[Matnr],[Arktx],[Charg],[Netwr],[Brtwr],[Mwskz],[Sgtxt],[Kzwi1],[Kzwi4]) VALUES (@KAYIT_TARIHI,@Vbeln,@Posnr,@Fkimg,@Vrkme,@VrkmeText,@Ntgew,@Brgew,@Gewei,@Volum,@Voleh,@Vgbel,@Vgpos,@Vgtyp,@Aubel,@Aupos,@Auref,@Matnr,@Arktx,@Charg,@Netwr,@Brtwr,@Mwskz,@Sgtxt,@Kzwi1,@Kzwi4)", conn);
                                #region parameters
                                cmd.Parameters.AddWithValue("@KAYIT_TARIHI", DateTime.Now);
                                cmd.Parameters.AddWithValue("@Vbeln", Convert.ToInt64(onsekiz[j].Vbeln));
                                cmd.Parameters.AddWithValue("@Posnr", Convert.ToInt32(onsekiz[j].Posnr));
                                cmd.Parameters.AddWithValue("@Fkimg", onsekiz[j].Fkimg);
                                cmd.Parameters.AddWithValue("@Vrkme", onsekiz[j].Vrkme);
                                cmd.Parameters.AddWithValue("@VrkmeText", onsekiz[j].VrkmeText);
                                cmd.Parameters.AddWithValue("@Ntgew", onsekiz[j].Ntgew);
                                cmd.Parameters.AddWithValue("@Brgew", onsekiz[j].Brgew);
                                cmd.Parameters.AddWithValue("@Gewei", onsekiz[j].Gewei);
                                cmd.Parameters.AddWithValue("@Volum", onsekiz[j].Volum);
                                cmd.Parameters.AddWithValue("@Voleh", onsekiz[j].Voleh);
                                cmd.Parameters.AddWithValue("@Vgbel", onsekiz[j].Vgbel);
                                cmd.Parameters.AddWithValue("@Vgpos", onsekiz[j].Vgpos);
                                cmd.Parameters.AddWithValue("@Vgtyp", onsekiz[j].Vgtyp);
                                cmd.Parameters.AddWithValue("@Aubel", onsekiz[j].Aubel);
                                cmd.Parameters.AddWithValue("@Aupos", onsekiz[j].Aupos);
                                cmd.Parameters.AddWithValue("@Auref", onsekiz[j].Auref);
                                cmd.Parameters.AddWithValue("@Matnr", onsekiz[j].Matnr == string.Empty ? 0 : Convert.ToInt32(onsekiz[j].Matnr));
                                cmd.Parameters.AddWithValue("@Arktx", onsekiz[j].Arktx);
                                cmd.Parameters.AddWithValue("@Charg", onsekiz[j].Charg);
                                cmd.Parameters.AddWithValue("@Netwr", onsekiz[j].Netwr);
                                cmd.Parameters.AddWithValue("@Brtwr", onsekiz[j].Brtwr);
                                cmd.Parameters.AddWithValue("@Mwskz", onsekiz[j].Mwskz);
                                cmd.Parameters.AddWithValue("@Sgtxt", onsekiz[j].Sgtxt);
                                cmd.Parameters.AddWithValue("@Kzwi1", onsekiz[j].Kzwi1);
                                cmd.Parameters.AddWithValue("@Kzwi4", onsekiz[j].Kzwi4);
                                #endregion
                                cmd.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                SAPs.HataYaz("SAP_FATURA_DETAY", onsekiz[j].Vbeln, onsekiz[j].Posnr, "", "", "", ex.Message, cekilecektarih, cekilecektarih.AddDays(1));
                            }
                            conn.Close();
                        }
                    }
                    #endregion

                    #endregion

                    cekilecektarih = cekilecektarih.AddDays(1);
                }

                if (!hatavar)
                    MaxTarihYaz(conn, "SAP_NakilMalFatura", bitistarih);
            }
            #endregion



            #region KOLIETIKET
            if (kolietiket)
            {
                DateTime maxtarih = Convert.ToDateTime(DateTime.Now.AddDays(-2).ToShortDateString() + " 00:30:00");
                DateTime bitistarih = DateTime.Now;
                bool hatavar = false;

                selectkolietiketC.ZwebSelectKoliEtiketService client5 = new selectkolietiketC.ZwebSelectKoliEtiketService();
                client5.Timeout = 6000000;
                client5.Credentials = nc1;

                DateTime cekilecektarih = maxtarih;
                DateTime simdikitarih = DateTime.Now;
                while (Convert.ToDateTime(cekilecektarih.ToShortDateString()) <= Convert.ToDateTime(simdikitarih.ToShortDateString()))
                {
                    selectkolietiketC.Zwebs019[] ondokuz = null;

                    string hata = string.Empty;
                    string tarih = "";
                    string saat = "00:00:00";

                    int tekrarcek = 0;
                    while (tekrarcek < tekrarcekilecek)
                    {
                        try
                        {
                            TarihSaat(maxtarih, cekilecektarih, out tarih, out saat);
                            ondokuz = client5.ZwebSelectKoliEtiket(tarih, saat);
                            tekrarcek = tekrarcekilecek;
                        }
                        catch (Exception ex)
                        {
                            SAPs.LogYaz("select koli etiket", true, cekilecektarih.ToShortDateString() + " " + (tekrarcek + 1).ToString() + ".deneme sap hata döndürdü: " + ex.Message, DateTime.Now, DateTime.Now);
                            if (tekrarcek < tekrarcekilecek)
                            {
                                tekrarcek++;
                                System.Threading.Thread.Sleep(3000);
                            }
                            else
                            {
                                hata = ex.Message;
                                hatavar = true;
                                cekilecektarih = DateTime.Now; // while dan çıksın bir sonraki günü almasın max tarihi yenilemesin
                            }
                        }
                    }

                    SAPs.LogYaz("select koli etiket", hata != string.Empty ? false : true, hata, Convert.ToDateTime(cekilecektarih.ToShortDateString() + " " + saat), Convert.ToDateTime(cekilecektarih.ToShortDateString()) == Convert.ToDateTime(simdikitarih.ToShortDateString()) ? DateTime.Now : Convert.ToDateTime(cekilecektarih.AddDays(1).ToShortDateString() + " 00:00:00"));

                    if (ondokuz != null)
                    {
                        for (int j = 0; j < ondokuz.Length; j++)
                        {
                            try
                            {
                                conn.Open();
                                SqlCommand cmd = new SqlCommand(
                                    "DELETE FROM [SAP_KOLIETIKET] WHERE Kolietiketno = @Kolietiketno " +
                                    "INSERT INTO [SAP_KOLIETIKET] (KAYIT_TARIHI,[Kolietiketno],[Kolisira],[Koliadet],[Vbeln],[Erdat],[Erzet],[Ernam],[Deleted]) VALUES (@KAYIT_TARIHI,@Kolietiketno,@Kolisira,@Koliadet,@Vbeln,@Erdat,@Erzet,@Ernam,@Deleted)", conn);
                                #region parameters
                                cmd.Parameters.AddWithValue("@KAYIT_TARIHI", DateTime.Now);
                                cmd.Parameters.AddWithValue("@Kolietiketno", ondokuz[j].Kolietiketno);
                                cmd.Parameters.AddWithValue("@Kolisira", ondokuz[j].Kolisira);
                                cmd.Parameters.AddWithValue("@Koliadet", ondokuz[j].Koliadet);
                                cmd.Parameters.AddWithValue("@Vbeln", Convert.ToInt64(ondokuz[j].Vbeln));
                                cmd.Parameters.AddWithValue("@Erdat", Convert.ToDateTime(ondokuz[j].Erdat + " " + ondokuz[j].Erzet));
                                cmd.Parameters.AddWithValue("@Erzet", ondokuz[j].Erzet);
                                cmd.Parameters.AddWithValue("@Ernam", ondokuz[j].Ernam);
                                cmd.Parameters.AddWithValue("@Deleted", ondokuz[j].Deleted);
                                #endregion
                                cmd.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                SAPs.HataYaz("SAP_KOLIETIKET", ondokuz[j].Kolietiketno, "", "", "", "", ex.Message, cekilecektarih, cekilecektarih.AddDays(1));
                            }
                            conn.Close();
                        }
                    }

                    cekilecektarih = cekilecektarih.AddDays(1);
                }

                if (!hatavar)
                    MaxTarihYaz(conn, "SAP_KoliEtiket", bitistarih);
            }
            #endregion



            #region ACCOUNTING
            if (accounting)
            {
                DateTime maxtarih = Convert.ToDateTime(DateTime.Now.AddDays(-2).ToShortDateString() + " 00:00:00");
                DateTime bitistarih = DateTime.Now;
                bool hatavar = false;

                selectaccountingC.ZwebSelectAccountingService client6 = new selectaccountingC.ZwebSelectAccountingService();
                //for (int i = maxtarih.Day; i <= DateTime.Now.Day; i++)
                //{
                selectaccountingC.Zwebs020[] yirmi = null;
                client6.Timeout = 6000000;
                client6.Credentials = nc1;

                string hata = string.Empty;

                int tekrarcek = 0;
                while (tekrarcek < tekrarcekilecek)
                {
                    try
                    {
                        yirmi = client6.ZwebSelectAccounting(
                            maxtarih.Year.ToString() + (maxtarih.Month.ToString().Length == 1 ? "0" + maxtarih.Month.ToString() : maxtarih.Month.ToString()) + (maxtarih.Day.ToString().Length == 1 ? "0" + maxtarih.Day.ToString() : maxtarih.Day.ToString()),
                            DateTime.Now.AddDays(1).Year.ToString() + (DateTime.Now.AddDays(1).Month.ToString().Length == 1 ? "0" + DateTime.Now.AddDays(1).Month.ToString() : DateTime.Now.AddDays(1).Month.ToString()) + (DateTime.Now.AddDays(1).Day.ToString().Length == 1 ? "0" + DateTime.Now.AddDays(1).Day.ToString() : DateTime.Now.AddDays(1).Day.ToString()));
                        tekrarcek = tekrarcekilecek;
                    }
                    catch (Exception ex)
                    {
                        SAPs.LogYaz("select accounting", true, (tekrarcek + 1).ToString() + ".deneme sap hata döndürdü: " + ex.Message, DateTime.Now, DateTime.Now);
                        if (tekrarcek < tekrarcekilecek)
                        {
                            tekrarcek++;
                            System.Threading.Thread.Sleep(3000);
                        }
                        else
                        {
                            hata = ex.Message;
                            hatavar = true;
                        }
                    }
                }

                SAPs.LogYaz("select accounting", hata != string.Empty ? false : true, hata, maxtarih, DateTime.Now);

                if (yirmi != null)
                {
                    for (int j = 0; j < yirmi.Length; j++)
                    {
                        try
                        {
                            conn.Open();
                            SqlCommand cmd = new SqlCommand(
                                "DELETE FROM [SAP_ACCOUNTING] WHERE Bukrs = @Bukrs AND Belnr = @Belnr AND Gjahr = @Gjahr " +
                                "INSERT INTO [SAP_ACCOUNTING] (KAYIT_TARIHI,[Bukrs],[Belnr],[Gjahr],[Blart],[Bldat],[Budat],[Monat],[Cpudt],[Cputm],[Aedat],[Upddt],[Wwert],[Usnam],[Xblnr],[Stblg],[Stjah],[Bktxt],[Waers],[Awtyp],[Awkey],[Zzikincibelgeno],[Zzislemkd],[Zzreferans]) VALUES (@KAYIT_TARIHI,@Bukrs,@Belnr,@Gjahr,@Blart,@Bldat,@Budat,@Monat,@Cpudt,@Cputm,@Aedat,@Upddt,@Wwert,@Usnam,@Xblnr,@Stblg,@Stjah,@Bktxt,@Waers,@Awtyp,@Awkey,@Zzikincibelgeno,@Zzislemkd,@Zzreferans)", conn);
                            #region parameters
                            cmd.Parameters.AddWithValue("@KAYIT_TARIHI", DateTime.Now);
                            cmd.Parameters.AddWithValue("@Bukrs", yirmi[j].Bukrs);
                            cmd.Parameters.AddWithValue("@Belnr", yirmi[j].Belnr);
                            cmd.Parameters.AddWithValue("@Gjahr", Convert.ToInt32(yirmi[j].Gjahr));
                            cmd.Parameters.AddWithValue("@Blart", yirmi[j].Blart);
                            cmd.Parameters.AddWithValue("@Bldat", yirmi[j].Bldat.StartsWith("0000") ? Convert.ToDateTime("01.01.1900") : Convert.ToDateTime(yirmi[j].Bldat));
                            cmd.Parameters.AddWithValue("@Budat", yirmi[j].Budat.StartsWith("0000") ? Convert.ToDateTime("01.01.1900") : Convert.ToDateTime(yirmi[j].Budat));
                            cmd.Parameters.AddWithValue("@Monat", yirmi[j].Monat);
                            cmd.Parameters.AddWithValue("@Cpudt", yirmi[j].Cpudt.StartsWith("0000") ? Convert.ToDateTime("01.01.1900") : Convert.ToDateTime(yirmi[j].Cpudt + " " + yirmi[j].Cputm));
                            cmd.Parameters.AddWithValue("@Cputm", yirmi[j].Cputm);
                            cmd.Parameters.AddWithValue("@Aedat", yirmi[j].Aedat.StartsWith("0000") ? Convert.ToDateTime("01.01.1900") : Convert.ToDateTime(yirmi[j].Aedat));
                            cmd.Parameters.AddWithValue("@Upddt", yirmi[j].Upddt.StartsWith("0000") ? Convert.ToDateTime("01.01.1900") : Convert.ToDateTime(yirmi[j].Upddt));
                            cmd.Parameters.AddWithValue("@Wwert", yirmi[j].Wwert.StartsWith("0000") ? Convert.ToDateTime("01.01.1900") : Convert.ToDateTime(yirmi[j].Wwert));
                            cmd.Parameters.AddWithValue("@Usnam", yirmi[j].Usnam);
                            cmd.Parameters.AddWithValue("@Xblnr", yirmi[j].Xblnr);
                            cmd.Parameters.AddWithValue("@Stblg", yirmi[j].Stblg);
                            cmd.Parameters.AddWithValue("@Stjah", yirmi[j].Stjah);
                            cmd.Parameters.AddWithValue("@Bktxt", yirmi[j].Bktxt);
                            cmd.Parameters.AddWithValue("@Waers", yirmi[j].Waers);
                            cmd.Parameters.AddWithValue("@Awtyp", yirmi[j].Awtyp);
                            cmd.Parameters.AddWithValue("@Awkey", yirmi[j].Awkey);
                            cmd.Parameters.AddWithValue("@Zzikincibelgeno", yirmi[j].Zzikincibelgeno);
                            cmd.Parameters.AddWithValue("@Zzislemkd", yirmi[j].Zzislemkd);
                            cmd.Parameters.AddWithValue("@Zzreferans", yirmi[j].Zzreferans);
                            #endregion
                            cmd.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            hatavar = true;
                            SAPs.HataYaz("SAP_ACCOUNTING", yirmi[j].Bukrs, yirmi[j].Belnr, yirmi[j].Gjahr, "", "", ex.Message, maxtarih, DateTime.Now);
                        }
                        conn.Close();
                    }
                }

                if (!hatavar)
                    MaxTarihYaz(conn, "SAP_Accounting", bitistarih);
                //}
            }
            #endregion



            if (satisupdate)
                SatisUpdate(conn);
        }
        #endregion

        #region sap yardımcılar
        private void TarihSaat(DateTime maxtarih, DateTime cekilecektarih, out string tarih, out string saat)
        {
            tarih = cekilecektarih.Year.ToString() +
                (cekilecektarih.Month.ToString().Length == 1 ? "0" + cekilecektarih.Month.ToString() : cekilecektarih.Month.ToString()) +
                (cekilecektarih.Day.ToString().Length == 1 ? "0" + cekilecektarih.Day.ToString() : cekilecektarih.Day.ToString());

            if (Convert.ToDateTime(maxtarih.ToShortDateString()) == Convert.ToDateTime(cekilecektarih.ToShortDateString()))
                saat = cekilecektarih.AddMinutes(-30).ToShortTimeString() + ":00"; // -30 değişirse gece fonksiyonunun saati olan 00:30:00 ıda değiştir
            else
                saat = "00:00:00";
        }

        /*private void HataYaz(SqlConnection conn, string tablo, string key1, string key2, string key3, string key4, string key5, string log, DateTime baslangic, DateTime bitis)
        {
            SqlCommand cmdLog = new SqlCommand("INSERT INTO [SAP_HATA_LOG] ([dtZaman],[strTablo],[strKey1],[strKey2],[strKey3],[strKey4],[strKey5],[strLog],dtBaslangic,dtBitis) VALUES (@dtZaman,@strTablo,@strKey1,@strKey2,@strKey3,@strKey4,@strKey5,@strLog,@dtBaslangic,@dtBitis)", conn);
            cmdLog.Parameters.AddWithValue("@dtZaman", DateTime.Now);
            cmdLog.Parameters.AddWithValue("@strTablo", tablo);
            cmdLog.Parameters.AddWithValue("@strKey1", key1);
            cmdLog.Parameters.AddWithValue("@strKey2", key2);
            cmdLog.Parameters.AddWithValue("@strKey3", key3);
            cmdLog.Parameters.AddWithValue("@strKey4", key4);
            cmdLog.Parameters.AddWithValue("@strKey5", key5);
            cmdLog.Parameters.AddWithValue("@strLog", log);
            cmdLog.Parameters.AddWithValue("@dtBaslangic", baslangic);
            cmdLog.Parameters.AddWithValue("@dtBitis", bitis);
            cmdLog.ExecuteNonQuery();
        }

        private void LogYaz(SqlConnection conn, string servis, bool basarili, string log, DateTime baslangic, DateTime bitis)
        {
            SqlCommand cmdLog = new SqlCommand("INSERT INTO [SAP_SERVIS_LOG] ([dtZaman],[strServis],blBasarili,[strLog],dtBaslangic,dtBitis) VALUES (@dtZaman,@strServis,@blBasarili,@strLog,@dtBaslangic,@dtBitis)", conn);
            cmdLog.Parameters.AddWithValue("@dtZaman", DateTime.Now);
            cmdLog.Parameters.AddWithValue("@strServis", servis);
            cmdLog.Parameters.AddWithValue("@blBasarili", basarili);
            cmdLog.Parameters.AddWithValue("@strLog", log);
            cmdLog.Parameters.AddWithValue("@dtBaslangic", baslangic);
            cmdLog.Parameters.AddWithValue("@dtBitis", bitis);
            conn.Open();
            cmdLog.ExecuteNonQuery();
            conn.Close();
        }*/

        private DateTime MaxTarihGetir(SqlConnection conn, string alan)
        {
            SqlCommand cmd = new SqlCommand("SELECT " + alan + " FROM [tblWebGenel]", conn);
            conn.Open();
            DateTime donendeger = Convert.ToDateTime(cmd.ExecuteScalar());
            conn.Close();

            return donendeger;
        }

        private void MaxTarihYaz(SqlConnection conn, string alan, DateTime bitistarih)
        {
            SqlCommand cmd = new SqlCommand("UPDATE [tblWebGenel] SET " + alan + " = @Deger", conn);
            cmd.Parameters.Add("@Deger", SqlDbType.DateTime).Value = bitistarih;
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        private void SatisUpdate(SqlConnection conn)
        {
            DateTime baslangic = DateTime.Now;
            string hata = string.Empty;

            SAPs.LogYaz("satis update basladi", true, "", DateTime.Now, DateTime.Now);

            try
            {
                SqlCommand cmd = new SqlCommand("sp_SAP_UPDATE", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 3600;
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                hata = ex.Message;
                conn.Close();
            }

            SAPs.LogYaz("satis update", hata == string.Empty ? true : false, hata, baslangic, DateTime.Now);

            if (DateTime.Now.Hour == 9 || DateTime.Now.Hour == 12 || DateTime.Now.Hour == 15 || DateTime.Now.Hour == 18)
                GetSatisJob2();
        }

        private void GetSatisJob2()
        {
            SqlConnection conn = new SqlConnection(General.ConnectionString);
            SqlCommand cmdSatisJob = new SqlCommand("msdb.dbo.sp_start_job", conn);
            cmdSatisJob.CommandTimeout = 1000;
            cmdSatisJob.CommandType = CommandType.StoredProcedure;
            cmdSatisJob.Parameters.AddWithValue("@job_name", "SatisRapor");

            DateTime bastarih = DateTime.Now;
            string hataa = string.Empty;
            try
            {
                conn.Open();
                cmdSatisJob.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                hataa = ex.Message;
            }
            finally
            {
                conn.Close();
                SAPs.LogYaz("satis yeni", hataa != string.Empty ? false : true, hataa, bastarih, DateTime.Now);
            }
        }

        private void WebRutJob()
        {
            SqlConnection conn = new SqlConnection(General.ConnectionString);
            SqlCommand cmd = new SqlCommand("msdb.dbo.sp_start_job", conn);
            cmd.CommandTimeout = 1000;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@job_name", "Web_Rut");

            DateTime bastarih = DateTime.Now;
            string hataa = string.Empty;
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                hataa = ex.Message;
            }
            finally
            {
                conn.Close();
                SAPs.LogYaz("Web_Rut", hataa != string.Empty ? false : true, hataa, bastarih, DateTime.Now);
            }
        }
        #endregion

        private void EntegraSiparis()
        {
            if (Entegra.EntegraSiparis2())
                EventLog.WriteEntry("Sultanlar Windows Service", "Entegra güncellemesi yapıldı.", EventLogEntryType.Information);
        }
    }



    public class FiyatlarCmtParametre
    {
        public getmaterialpricesC.Zwebt004[] listMaterialPrices { get; set; }
        public int baslangic { get; set; }
        public int bitis { get; set; }
        public int kacinci { get; set; }
        public SqlCommand cmdLog { get; set; }
    }
}

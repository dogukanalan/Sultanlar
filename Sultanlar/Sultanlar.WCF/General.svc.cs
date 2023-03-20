using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data;
//using System.Data.DataSetExtensions;
using Sultanlar.DatabaseObject;
using Sultanlar.DatabaseObject.Internet;
using System.Xml;
using System.ServiceModel.Web;
using System.Collections;
using System.IO;
using System.Xml.Serialization;
using System.Drawing;
using Sultanlar.Model.Xml;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Sultanlar.WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "General" in code, svc and config file together.
    public class General : IGeneral
    {
        private string getClientIP()
        {
            //WebOperationContext webContext = WebOperationContext.Current;

            OperationContext context = OperationContext.Current;

            System.ServiceModel.Channels.MessageProperties messageProperties = context.IncomingMessageProperties;

            System.ServiceModel.Channels.RemoteEndpointMessageProperty endpointProperty =

                messageProperties[System.ServiceModel.Channels.RemoteEndpointMessageProperty.Name]

                as System.ServiceModel.Channels.RemoteEndpointMessageProperty;
            return endpointProperty.Address;
        }
        /// <summary>
        /// Test
        /// </summary>
        public string Test()
        {
            return "Sultanlar WCF çalışıyör. " + getClientIP();
        }

        #region sqllite
        /*
        /// <summary>
        /// Tüm veritabanı, kullanıcıya özel, sqlite3 için, rar dosyası olarak kaydoluyor. 
        /// url dönüyor.
        /// </summary>
        public string androidGetSqliteDb(string Eposta, string Sifre)
        {
            string guid = Guid.NewGuid().ToString();
            string donendeger = "http://www.sultanlar.com.tr/tempdown/" + guid + ".rar";

            SQLiteConnection conn = new SQLiteConnection("Data Source=c:\\inetpub\\wwwroot\\sultanlar2011\\tempdown\\" + guid + ".rar;Version=3;New=True;");

            try
            {
                SQLiteCommand cmd = new SQLiteCommand(
                    "CREATE TABLE OZELLIKLER (EPOSTA TEXT,SIFRE TEXT,SLSREF INTEGER,SONGUNCELLEME TEXT); " +
                    "CREATE TABLE MUSTERILER (SMREF INTEGER,MUSTERI TEXT,RISKLIMIT REAL); " +
                    "CREATE TABLE FIYATLAR (ITEMREF INTEGER,FTIP INTEGER,FIYAT REAL); " +
                    "CREATE TABLE FIYATTIPLERI (FTIP INTEGER); " +
                    "CREATE TABLE URUNLER (ITEMREF INTEGER,MALZEME TEXT,BARKOD TEXT,STOK INTEGER); " +

                    "CREATE TABLE SIPARISLER (ID INTEGER PRIMARY KEY AUTOINCREMENT,SLSREF INTEGER,SMREF INTEGER,FTIP INTEGER,TUTAR REAL); " +
                    "CREATE TABLE SIPARISDETAY (SIPARISID INTEGER,ITEMREF INTEGER,ADET INTEGER,FIYAT REAL); " +
                    "CREATE TABLE IADELER (ID INTEGER PRIMARY KEY AUTOINCREMENT,SLSREF INTEGER,SMREF INTEGER); " +
                    "CREATE TABLE IADEDETAY (IADEID INTEGER,ITEMREF INTEGER,ADET INTEGER);", conn);

                conn.Open();
                cmd.ExecuteNonQuery();

                ArrayList musteri = Musteriler.ValidateCustomer(Eposta, Sifre);

                if (Convert.ToBoolean(musteri[0]))
                {
                    DataTable dt = new DataTable();
                    string commandtext = string.Empty;
                    UyeYetkileri uy = new UyeYetkileri(Convert.ToInt32(musteri[5]));

                    // MUSTERILER
                    int SLSREF = Musteriler.GetSLSREFbyMusteriID(Convert.ToInt32(musteri[5]));
                    if (SLSREF != 0)
                        CariHesaplar.GetObjectsWS(dt, SLSREF, true);

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        commandtext = "INSERT INTO MUSTERILER (SMREF,MUSTERI,RISKLIMIT) VALUES (" +
                            "" + dt.Rows[i][1].ToString() + "," +
                            "'" + dt.Rows[i][2].ToString() + "'," +
                            "" + dt.Rows[i][3].ToString().Replace(",", ".") + "); ";
                        cmd = new SQLiteCommand(commandtext, conn);
                        cmd.ExecuteNonQuery();
                    }



                    // FIYATTIPLERI
                    commandtext = string.Empty;
                    for (int i = 0; i < uy.FiyatTipler.Count; i++)
                    {
                        commandtext = "INSERT INTO FIYATTIPLERI (FTIP) VALUES (" +
                            "" + uy.FiyatTipler[i].ToString() + "); ";
                        cmd = new SQLiteCommand(commandtext, conn);
                        cmd.ExecuteNonQuery();
                    }



                    // URUNLER
                    dt = new DataTable();
                    Urunler.GetProductsWS(dt);
                    commandtext = string.Empty;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        commandtext = "INSERT INTO URUNLER (ITEMREF,MALZEME,BARKOD,STOK) VALUES (" +
                            "" + dt.Rows[i][0].ToString() + "," +
                            "'" + dt.Rows[i][1].ToString() + "'," +
                            "'" + dt.Rows[i][2].ToString() + "'," +
                            "" + dt.Rows[i][3].ToString() + "); ";
                        cmd = new SQLiteCommand(commandtext, conn);
                        cmd.ExecuteNonQuery();
                    }



                    // FIYATLAR
                    dt = new DataTable();
                    Urunler.GetPricesWS(dt, uy.FiyatTipler);
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
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                return ex.Message;
            }

            return donendeger;
        }
        /// <summary>
        /// Tüm veritabanı, sqlite3 için, rar dosyası olarak kaydoluyor. 
        /// url dönüyor.
        /// </summary>
        public string androidGetSqliteDbFull(string Eposta, string Sifre)
        {
            string guid = Guid.NewGuid().ToString();
            string donendeger = "http://www.sultanlar.com.tr/tempdown/" + guid + ".rar";

            SQLiteConnection conn = new SQLiteConnection("Data Source=c:\\inetpub\\wwwroot\\sultanlar2011\\tempdown\\" + guid + ".rar;Version=3;New=True;");

            try
            {
                SQLiteCommand cmd = new SQLiteCommand(
                    "CREATE TABLE OZELLIKLER (EPOSTA TEXT,SIFRE TEXT,SLSREF INTEGER,SONGUNCELLEME TEXT); " +
                    "CREATE TABLE MUSTERILER (SMREF INTEGER,MUSTERI TEXT,RISKLIMIT REAL); " +
                    "CREATE TABLE FIYATLAR (ITEMREF INTEGER,FTIP INTEGER,FIYAT REAL); " +
                    "CREATE TABLE FIYATTIPLERI (FTIP INTEGER); " +
                    "CREATE TABLE URUNLER (ITEMREF INTEGER,MALZEME TEXT,BARKOD TEXT,STOK INTEGER); " +

                    "CREATE TABLE SIPARISLER (ID INTEGER PRIMARY KEY AUTOINCREMENT,SLSREF INTEGER,SMREF INTEGER,FTIP INTEGER,TUTAR REAL); " +
                    "CREATE TABLE SIPARISDETAY (SIPARISID INTEGER,ITEMREF INTEGER,ADET INTEGER,FIYAT REAL); " +
                    "CREATE TABLE IADELER (ID INTEGER PRIMARY KEY AUTOINCREMENT,SLSREF INTEGER,SMREF INTEGER); " +
                    "CREATE TABLE IADEDETAY (IADEID INTEGER,ITEMREF INTEGER,ADET INTEGER);", conn);

                conn.Open();
                cmd.ExecuteNonQuery();

                ArrayList musteri = Musteriler.ValidateCustomer(Eposta, Sifre);

                if (Convert.ToBoolean(musteri[0]))
                {
                    DataTable dt = new DataTable();
                    string commandtext = string.Empty;
                    UyeYetkileri uy = new UyeYetkileri(Convert.ToInt32(musteri[5]));

                    // MUSTERILER
                    CariHesaplar.GetObjectsWS(dt, true);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        commandtext = "INSERT INTO MUSTERILER (SMREF,MUSTERI,RISKLIMIT) VALUES (" +
                            "" + dt.Rows[i][1].ToString() + "," +
                            "'" + dt.Rows[i][2].ToString() + "'," +
                            "" + dt.Rows[i][3].ToString().Replace(",", ".") + "); ";
                        cmd = new SQLiteCommand(commandtext, conn);
                        cmd.ExecuteNonQuery();
                    }



                    // FIYATTIPLERI
                    dt = new DataTable();
                    FiyatTipleri.GetObjectWS(dt);
                    commandtext = string.Empty;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        commandtext = "INSERT INTO FIYATTIPLERI (FTIP) VALUES (" +
                            "" + dt.Rows[i][0].ToString() + "); ";
                        cmd = new SQLiteCommand(commandtext, conn);
                        cmd.ExecuteNonQuery();
                    }



                    // URUNLER
                    dt = new DataTable();
                    Urunler.GetProductsWS(dt);
                    commandtext = string.Empty;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        commandtext = "INSERT INTO URUNLER (ITEMREF,MALZEME,BARKOD,STOK) VALUES (" +
                            "" + dt.Rows[i][0].ToString() + "," +
                            "'" + dt.Rows[i][1].ToString() + "'," +
                            "'" + dt.Rows[i][2].ToString() + "'," +
                            "" + dt.Rows[i][3].ToString() + "); ";
                        cmd = new SQLiteCommand(commandtext, conn);
                        cmd.ExecuteNonQuery();
                    }



                    // FIYATLAR
                    dt = new DataTable();
                    Urunler.GetPricesWS(dt);
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
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                return ex.Message;
            }

            return donendeger;
        }*/
        #endregion

        /// <summary>
        /// Üyenin bütün müşterileri. 
        /// düzen=salesman_ref:::substation_ref:::substation:::risklimit
        /// </summary>
        public XmlDocument androidGetClients(string Eposta, string Sifre)
        {
            XmlDocument donendeger = new XmlDocument();
            DataSet ds = new DataSet("Clients");
            DataTable dt = new DataTable("client");

            ArrayList musteri = Musteriler.ValidateCustomer(Eposta, Sifre);

            if (Convert.ToBoolean(musteri[0]))
            {
                int SLSREF = Musteriler.GetSLSREFbyMusteriID(Convert.ToInt32(musteri[5]));
                if (SLSREF != 0)
                    CariHesaplar.GetObjectsWS(dt, SLSREF, true);
            }

            ds.Tables.Add(dt);
            donendeger.LoadXml(ds.GetXml());

            return donendeger;
        }
        /// <summary>
        /// Üyenin yetkili fiyat tipleri. 
        /// düzen=typeofprice_ref
        /// </summary>
        public XmlDocument androidGetTypeOfPrices(string Eposta, string Sifre)
        {
            XmlDocument donendeger = new XmlDocument();
            DataSet ds = new DataSet("TypeOfPrices");
            DataTable dt = new DataTable("typeofprice");

            ArrayList musteri = Musteriler.ValidateCustomer(Eposta, Sifre);

            if (Convert.ToBoolean(musteri[0]))
            {
                dt.Columns.Add("typeofprice_ref", typeof(int));
                UyeYetkileri uy = new UyeYetkileri(Convert.ToInt32(musteri[5]));
                for (int i = 0; i < uy.FiyatTipler.Count; i++)
                {
                    DataRow drow = dt.NewRow();
                    drow[0] = Convert.ToInt32(uy.FiyatTipler[i]);
                    dt.Rows.Add(drow);
                }
            }

            ds.Tables.Add(dt);
            donendeger.LoadXml(ds.GetXml());

            return donendeger;
        }
        /// <summary>
        /// Bütün ürünler bütün fiyattipleriyle geliyor mesela A ürünü için birden çok satır gelecek her bir fiyat tipi için ayrı fiyat ayrı satır. 
        /// düzen=ir:::tr:::pr (item_ref:::typeofprice_ref:::price)
        /// </summary>
        public XmlDocument androidGetPrices(string Eposta, string Sifre)
        {
            XmlDocument donendeger = new XmlDocument();
            DataSet ds = new DataSet("Prices");
            DataTable dt = new DataTable("p");

            ArrayList musteri = Musteriler.ValidateCustomer(Eposta, Sifre);

            if (Convert.ToBoolean(musteri[0]))
            {
                UyeYetkileri uy = new UyeYetkileri(Convert.ToInt32(musteri[5]));
                Urunler.GetPricesWS(dt, uy.FiyatTipler);
            }

            ds.Tables.Add(dt);
            donendeger.LoadXml(ds.GetXml());

            return donendeger;
        }
        /// <summary>
        /// Bütün ürünler fiyatsız. 
        /// düzen=item_ref:::item:::barcode:::stock
        /// </summary>
        public XmlDocument androidGetProducts(string Eposta, string Sifre)
        {
            XmlDocument donendeger = new XmlDocument();
            DataSet ds = new DataSet("Products");
            DataTable dt = new DataTable("product");

            ArrayList musteri = Musteriler.ValidateCustomer(Eposta, Sifre);

            if (Convert.ToBoolean(musteri[0]))
            {
                Urunler.GetProductsWS(dt);
            }

            ds.Tables.Add(dt);
            donendeger.LoadXml(ds.GetXml());

            return donendeger;
        }
        /// <summary>
        /// Bütün satış temsilcileri. 
        /// düzen=salesman_ref:::salesman
        /// </summary>
        public XmlDocument GetSalesmen(string Sifre)
        {
            XmlDocument donendeger = new XmlDocument();
            DataSet ds = new DataSet("Salesmen");
            DataTable dt = new DataTable("salesman");

            if (Sifre == "morgen")
            {
                SatisTemsilcileri.GetObjectsWS(dt);
            }

            ds.Tables.Add(dt);
            donendeger.LoadXml(ds.GetXml());

            return donendeger;
        }
        /// <summary>
        /// Bütün müşteri kayıtları. 
        /// düzen=salesman_ref:::substation_ref:::client:::substation
        /// </summary>
        public XmlDocument GetClients(string Sifre)
        {
            XmlDocument donendeger = new XmlDocument();
            DataSet ds = new DataSet("Clients");
            DataTable dt = new DataTable("client");

            if (Sifre == "morgen")
            {
                CariHesaplar.GetObjectsWS(dt, true);
            }

            ds.Tables.Add(dt);
            donendeger.LoadXml(ds.GetXml());

            return donendeger;
        }
        /// <summary>
        /// Bütün fiyattipleri. 
        /// düzen=typeofprice_ref
        /// </summary>
        public XmlDocument GetTypeOfPrices(string Sifre)
        {
            XmlDocument donendeger = new XmlDocument();
            DataSet ds = new DataSet("TypeOfPrices");
            DataTable dt = new DataTable("typeofprice");

            if (Sifre == "morgen")
            {
                FiyatTipleri.GetObjectWS(dt);
            }

            ds.Tables.Add(dt);
            donendeger.LoadXml(ds.GetXml());

            return donendeger;
        }
        /// <summary>
        /// Bütün ürünler fiyatsız. 
        /// düzen=item_ref:::item:::barcode:::stock
        /// </summary>
        public XmlDocument GetProducts(string Sifre)
        {
            XmlDocument donendeger = new XmlDocument();
            DataSet ds = new DataSet("Products");
            DataTable dt = new DataTable("product");

            if (Sifre == "morgen")
            {
                Urunler.GetProductsWS(dt);
            }

            ds.Tables.Add(dt);
            donendeger.LoadXml(ds.GetXml());

            return donendeger;
        }
        /// <summary>
        /// Bütün ürünler bütün fiyattipleriyle geliyor mesela A ürünü için birden çok satır gelecek her bir fiyat tipi için ayrı fiyat ayrı satır. 
        /// düzen=ir:::tr:::pr (item_ref:::typeofprice_ref:::price)
        /// </summary>
        public XmlDocument GetPrices(string Sifre)
        {
            XmlDocument donendeger = new XmlDocument();
            DataSet ds = new DataSet("Prices");
            DataTable dt = new DataTable("price");

            if (Sifre == "morgen")
            {
                Urunler.GetPricesWS(dt);
            }

            ds.Tables.Add(dt);
            donendeger.LoadXml(ds.GetXml());

            return donendeger;
        }
        /// <summary>
        /// Hepsiburada için bütün ürünler. 
        /// fiyat tipi 15
        /// </summary>
        public XmlDocument hbGetProducts(string KAdi, string Sifre)
        {
            XmlDocument donendeger = new XmlDocument();
            DataSet ds = new DataSet("Urunler");
            DataTable dt = new DataTable("Urun");

            if (KAdi == "hepsiburada" && Sifre == WebGenel.GetHBsifre())
                FiyatListeleri.GetObjectXml(dt, 7, "hepsiburada");

            ds.Tables.Add(dt);
            donendeger.LoadXml(ds.GetXml());

            return donendeger;
        }
        /// <summary>
        /// n11 için bütün ürünler.
        /// </summary>
        public XmlDocument n11GetProducts(string KAdi, string Sifre)
        {
            XmlDocument donendeger = new XmlDocument();
            DataSet ds = new DataSet("Urunler");
            DataTable dt = new DataTable("Urun");

            if (KAdi == "n11" && Sifre == WebGenel.GetN11sifre())
                FiyatListeleri.GetObjectXml(dt, 3, "n11");

            ds.Tables.Add(dt);
            donendeger.LoadXml(ds.GetXml());

            return donendeger;
        }
        /// <summary>
        /// shupsy için bütün ürünler.
        /// </summary>
        public XmlDocument shupsyGetProducts(string Sifre)
        {
            XmlDocument donendeger = new XmlDocument();
            DataSet ds = new DataSet("Urunler");
            DataTable dt = new DataTable("Urun");

            if (Sifre == "shupsy1")
                FiyatListeleri.GetObjectXml(dt, 3, "shupsy");

            ds.Tables.Add(dt);
            donendeger.LoadXml(ds.GetXml());

            return donendeger;
        }
        /// <summary>
        /// sefamerve için bütün ürünler.
        /// </summary>
        public XmlDocument sefamerveGetProducts(string Sifre)
        {
            XmlDocument donendeger = new XmlDocument();
            DataSet ds = new DataSet("Urunler");
            DataTable dt = new DataTable("Urun");

            if (Sifre == "sefamerve1")
                FiyatListeleri.GetObjectXml(dt, 3, "sefamerve");

            ds.Tables.Add(dt);
            donendeger.LoadXml(ds.GetXml());

            return donendeger;
        }
        /// <summary>
        /// amazon için bütün ürünler.
        /// </summary>
        public XmlDocument amazonGetProducts(string Sifre)
        {
            XmlDocument donendeger = new XmlDocument();
            DataSet ds = new DataSet("Urunler");
            DataTable dt = new DataTable("Urun");

            if (Sifre == "amazon1")
                FiyatListeleri.GetObjectXml(dt, 3, "amazon");

            ds.Tables.Add(dt);
            donendeger.LoadXml(ds.GetXml());

            return donendeger;
        }
        /// <summary>
        /// n11pro için bütün ürünler.
        /// </summary>
        public XmlDocument n11proGetProducts(string Sifre)
        {
            XmlDocument donendeger = new XmlDocument();
            DataSet ds = new DataSet("Urunler");
            DataTable dt = new DataTable("Urun");

            if (Sifre == "n11pro1")
                FiyatListeleri.GetObjectXml(dt, 3, "n11pro");

            ds.Tables.Add(dt);
            donendeger.LoadXml(ds.GetXml());

            return donendeger;
        }
        /// <summary>
        /// 
        /// </summary>
        public XmlDocument delaGetProducts(string KAdi, string Sifre)
        {
            XmlDocument donendeger = new XmlDocument();
            DataSet ds = new DataSet("Urunler");
            DataTable dt = new DataTable("Urun");

            if (KAdi == "dela" && Sifre == "111245933")
                FiyatListeleri.GetObjectXml(dt, 3, "n11");

            ds.Tables.Add(dt);
            donendeger.LoadXml(ds.GetXml());

            return donendeger;
        }
        /// <summary>
        /// 
        /// fiyat tipi 16
        /// </summary>
        public XmlDocument komsuGetProducts(string KAdi, string Sifre)
        {
            XmlDocument donendeger = new XmlDocument();
            DataSet ds = new DataSet("Urunler");
            DataTable dt = new DataTable("Urun");

            if (KAdi == "komsu" && Sifre == "100152763")
                FiyatListeleri.GetObjectXml(dt, 7, "komsu");

            ds.Tables.Add(dt);
            donendeger.LoadXml(ds.GetXml());

            return donendeger;
        }
        /// <summary>
        /// gittigidiyor için bütün ürünler.
        /// fiyat tipi 21
        /// </summary>
        public XmlDocument ggGetProducts(string KAdi, string Sifre)
        {
            XmlDocument donendeger = new XmlDocument();
            DataSet ds = new DataSet("Urunler");
            DataTable dt = new DataTable("Urun");

            if (KAdi == "gg" && Sifre == WebGenel.GetGGsifre())
                FiyatListeleri.GetObjectXml(dt, 7, "gg");

            ds.Tables.Add(dt);
            donendeger.LoadXml(ds.GetXml());

            return donendeger;
        }
        /// <summary>
        /// sanalpazar için bütün ürünler.
        /// fiyat tipi 17
        /// </summary>
        public XmlDocument sanalpazarGetProducts(string KAdi, string Sifre)
        {
            XmlDocument donendeger = new XmlDocument();
            DataSet ds = new DataSet("Products");
            DataTable dt = new DataTable("Product");

            if (KAdi == "sanalpazar" && Sifre == WebGenel.GetSPsifre())
                FiyatListeleri.GetObjectXml(dt, 19, "sanalpazar");

            ds.Tables.Add(dt);
            donendeger.LoadXml(ds.GetXml());

            return donendeger;
        }
        /// <summary>
        /// BRL için ürünler
        /// </summary>
        public XmlDocument brlGetProducts(string KAdi, string Sifre)
        {
            ArrayList ozelkodlar = new ArrayList();
            ozelkodlar.Add("S056"); // girişim pazarlama
            ozelkodlar.Add("S018"); // girişim pazarlama
            ozelkodlar.Add("S003"); // kopaş kozmetik
            ozelkodlar.Add("S042"); // uçkan medikal
            ozelkodlar.Add("S019"); // ataman ecza
            ozelkodlar.Add("S111"); // colgate
            //ozelkodlar.Add("630"); // doğan ecz.
            ozelkodlar.Add("S068"); // johnson&johnson
            ozelkodlar.Add("S092"); // kosan kozmetik
            //ozelkodlar.Add("484"); // lansinoh lab.
            //ozelkodlar.Add("202"); // lever
            //ozelkodlar.Add("423"); // repline dış tic.
            ozelkodlar.Add("S012"); // vepa fırça

            string where = ozelkodlar.Count > 0 ? "WHERE" : "";
            for (int i = 0; i < ozelkodlar.Count; i++)
            {
                where += " [ALT GRP] = '" + ozelkodlar[i].ToString() + "' OR ";
            }
            where = ozelkodlar.Count > 0 ? where.Substring(0, where.Length - 3) : "";

            XmlDocument donendeger = new XmlDocument();
            DataSet ds = new DataSet("Urunler");
            DataTable dt = new DataTable("Urun");

            if (KAdi == "brl" && Sifre == "654923110")
                FiyatListeleri.GetObjectXml(dt, 4, where);

            ds.Tables.Add(dt);
            donendeger.LoadXml(ds.GetXml());

            return donendeger;
        }
        /// <summary>
        /// fiyat tipi 6 için ürünler
        /// </summary>
        public XmlDocument GetProducts6()
        {
            XmlDocument donendeger = new XmlDocument();
            DataSet ds = new DataSet("Urunler");
            DataTable dt = new DataTable("Urun");

            FiyatListeleri.GetObjectXml(dt, 6, "");

            ds.Tables.Add(dt);
            donendeger.LoadXml(ds.GetXml());

            return donendeger;
        }
        /// <summary>
        /// fiyat tipi 17 için ürünler
        /// </summary>
        public XmlDocument GetProducts17()
        {
            XmlDocument donendeger = new XmlDocument();
            DataSet ds = new DataSet("Urunler");
            DataTable dt = new DataTable("Urun");

            FiyatListeleri.GetObjectXml(dt, 17, "");

            ds.Tables.Add(dt);
            donendeger.LoadXml(ds.GetXml());

            return donendeger;
        }
        /// <summary>
        /// fiyat tipi 18 için ürünler
        /// </summary>
        public XmlDocument GetProducts18()
        {
            XmlDocument donendeger = new XmlDocument();
            DataSet ds = new DataSet("Urunler");
            DataTable dt = new DataTable("Urun");

            FiyatListeleri.GetObjectXml(dt, 18, "");

            ds.Tables.Add(dt);
            donendeger.LoadXml(ds.GetXml());

            return donendeger;
        }
        /// <summary>
        /// fiyat tipi 19 için ürünler
        /// </summary>
        public XmlDocument GetProducts19()
        {
            XmlDocument donendeger = new XmlDocument();
            DataSet ds = new DataSet("Urunler");
            DataTable dt = new DataTable("Urun");

            FiyatListeleri.GetObjectXml(dt, 19, "");

            ds.Tables.Add(dt);
            donendeger.LoadXml(ds.GetXml());

            return donendeger;
        }
        /// <summary>
        /// fiyat tipi 19 için ürünler
        /// </summary>
        public XmlDocument GetProductsUrun()
        {
            XmlDocument donendeger = new XmlDocument();
            DataSet ds = new DataSet("Urunler");
            DataTable dt = new DataTable("Urun");

            FiyatListeleri.GetObjectXml(dt, 7, "");

            ds.Tables.Add(dt);
            donendeger.LoadXml(ds.GetXml());

            return donendeger;
        }
        /// <summary>
        /// fiyat tipi 22 için ürünler
        /// </summary>
        public XmlDocument GetProducts22()
        {
            XmlDocument donendeger = new XmlDocument();
            DataSet ds = new DataSet("Urunler");
            DataTable dt = new DataTable("Urun");

            FiyatListeleri.GetObjectXml(dt, 22, "");

            ds.Tables.Add(dt);
            donendeger.LoadXml(ds.GetXml());

            return donendeger;
        }
        public List<ProductsF22> JSONGetProducts22()
        {
            List<ProductsF22> donendeger = new List<ProductsF22>();

            DataTable dt = new DataTable();
            FiyatListeleri.GetObjectXml(dt, 22, "");

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                donendeger.Add(new ProductsF22(dt.Rows[i]["GRUP"].ToString(), dt.Rows[i]["KOD"].ToString(), dt.Rows[i]["MALZEME"].ToString(),
                    dt.Rows[i]["BARKOD"].ToString(), dt.Rows[i]["PAKET"].ToString(), dt.Rows[i]["KOLI"].ToString(),
                    Convert.ToDouble(dt.Rows[i]["KDV"]), Convert.ToDouble(dt.Rows[i]["FIYAT"]), Convert.ToDouble(dt.Rows[i]["ISK1"]),
                    Convert.ToDouble(dt.Rows[i]["ISK2"]), Convert.ToDouble(dt.Rows[i]["ISK3"]), Convert.ToDouble(dt.Rows[i]["ISK4"]),
                    Convert.ToDouble(dt.Rows[i]["ISK5"]), Convert.ToDouble(dt.Rows[i]["ISK6"]), Convert.ToDouble(dt.Rows[i]["ISK7"]),
                    Convert.ToDouble(dt.Rows[i]["ISK8"]), Convert.ToDouble(dt.Rows[i]["ISK9"]), Convert.ToDouble(dt.Rows[i]["ISK10"]),
                    Convert.ToDouble(dt.Rows[i]["NETKDV"]), dt.Rows[i]["VD"].ToString(), dt.Rows[i]["STOK"].ToString(),
                    dt.Rows[i]["KG"].ToString(), dt.Rows[i]["DM3"].ToString(), dt.Rows[i]["Resim"].ToString()));
            }

            return donendeger;
        }
        /// <summary>
        /// Mobilgi Ürünler
        /// </summary>
        public XmlDocument MobilgiGetProducts(string Sifre)
        {
            XmlDocument donendeger = new XmlDocument();
            DataSet ds = new DataSet("Urunler");
            DataTable dt = new DataTable("Urun");

            if (Sifre == "mobilgi123")
                dt = WebGenel.WCFdata("SELECT [Web-Malzeme].[ITEMREF] AS UrunKod,[Web-Malzeme].[MAL ACIK] AS UrunAd,'Tibet' AS Firma,METIN AS 'Kategori',METIN AS 'Grup',(FIYAT - (FIYAT * 0.35)) * ((100 + KDV) / 100) AS MinFiyat,(FIYAT + (FIYAT * 0.35)) * ((100 + KDV) / 100) AS MaxFiyat,'' AS Kisaltma,CASE [BIRIMREF] WHEN 'ST' THEN 'Adet' END AS Birim,'' AS Adet,[KOLI] AS 'KoliIciAdet' FROM [Web-Malzeme] INNER JOIN [Web-Fiyat] ON [Web-Malzeme].[ITEMREF] = [Web-Fiyat].[ITEMREF] LEFT OUTER JOIN [Web-Malzeme-Hiyerarsi] ON [Web-Malzeme].HYRS = [Web-Malzeme-Hiyerarsi].KOD WHERE ([Web-Fiyat].[GRUP KOD] = 'STG-1' OR [Web-Fiyat].[GRUP KOD] = 'STG-2') AND TIP = 7 ORDER BY UrunAd", new ArrayList(), new SqlDbType[] { }, new ArrayList(), "Urunler");

            ds.Tables.Add(dt);
            donendeger.LoadXml(ds.GetXml());

            return donendeger;
        }
        /// <summary>
        /// Mobilgi Ürünler
        /// </summary>
        public XmlDocument MobilgiGetCustomers(string Sifre)
        {
            XmlDocument donendeger = new XmlDocument();
            DataSet ds = new DataSet("Musteriler");
            DataTable dt = new DataTable("Musteri");

            if (Sifre == "mobilgi123")
                dt = WebGenel.WCFdata("SELECT DISTINCT 'S' + CONVERT(varchar(7),[SMREF]) AS MagazaKod,[SUBE] AS MagazaAd,dbo.IlkKelime([SUBE]) AS Zincir,[MT ACIKLAMA] AS Sinif,dbo.BolgeGetirTP(UPPER([IL])) AS Bolge,[IL] AS Il,[ILCE] AS Ilce,ISNULL(CONVERT(varchar(10),(SELECT DISTINCT SLSREF FROM [Web-Musteri] AS MUSTERILER WHERE [SAT KOD1] = 'VW' AND SMREF = [Web-Musteri].SMREF AND (GMREF = SMREF OR SLSREF NOT IN (SELECT DISTINCT SLSREF FROM [Web-Musteri] AS MUSTERILER2 WHERE GMREF = SMREF AND GMREF = MUSTERILER.GMREF)))) + ',' + (SELECT DISTINCT [SAT TEM] FROM [Web-Musteri] AS MUSTERILER3 WHERE [SAT KOD1] = 'VW' AND SMREF = [Web-Musteri].SMREF AND (GMREF = SMREF OR SLSREF NOT IN (SELECT DISTINCT SLSREF FROM [Web-Musteri] AS MUSTERILER4 WHERE GMREF = SMREF AND GMREF = MUSTERILER3.GMREF))),'') AS SDEKod,CONVERT(varchar(10),(SELECT DISTINCT [SAT KOD] FROM [Web-Musteri] AS MUSTERILER WHERE SMREF = [Web-Musteri].SMREF)) + ',' + (SELECT [SAT TEM] FROM [Web-SatisTemsilcileri] WHERE SLSMANREF = (SELECT DISTINCT [SAT KOD] FROM [Web-Musteri] AS MUSTERILER4 WHERE GMREF = SMREF AND GMREF = [Web-Musteri].GMREF)) AS Satici FROM [Web-Musteri] WHERE ACTIVE = 0 ORDER BY MagazaAd", new ArrayList(), new SqlDbType[] { }, new ArrayList(), "Musteriler");

            ds.Tables.Add(dt);
            donendeger.LoadXml(ds.GetXml());

            return donendeger;
        }
        /// <summary>
        /// Mobilgi Ürünler
        /// </summary>
        public XmlDocument MobilgiGetCustomerProduct(string Sifre, string Kod)
        {
            XmlDocument donendeger = new XmlDocument();
            DataSet ds = new DataSet("MusteriUrunBaglantilari");
            DataTable dt = new DataTable("MusteriUrun");

            if (Sifre == "mobilgi123")
                dt = WebGenel.WCFdata("SELECT [GMREF] AS MagazaKod,[Web-Fiyat].[ITEMREF] AS UrunKod FROM [Web-Fiyat] INNER JOIN [Web-Malzeme] ON [Web-Fiyat].ITEMREF = [Web-Malzeme].ITEMREF WHERE GMREF != 0 AND ([Web-Fiyat].[GRUP KOD] = 'STG-1' OR [Web-Fiyat].[GRUP KOD] = 'STG-2') AND GMREF = @Kod ORDER BY MagazaKod,UrunKod", new ArrayList() { "@Kod" }, new SqlDbType[] { SqlDbType.Int }, new ArrayList() { Kod }, "MusteriUrunBaglantilari");

            ds.Tables.Add(dt);
            donendeger.LoadXml(ds.GetXml());

            return donendeger;
        }
        /// <summary>
        /// Bayiler satış raporu
        /// </summary>
        public XmlDocument GetBayiSatisRapor(string Sifre, string Bayikod, string Yil, string Ay)
        {
            XmlDocument donendeger = new XmlDocument();

            if (Sifre == "morgen")
            {
                DataSet ds = new DataSet("Satis_Raporu");
                DataTable dt = WebGenel.WCFdata(
                    "SELECT [vw_Web-Satis-Rapor-TP].[BAYIKOD] AS 'Bayi Kod',BAYIUNVAN AS 'Bayi Ünvan',BOLGE AS 'Bölge',SEHIR AS 'Şehir',CASE WHEN BAYIKOD != '1001327' THEN [NOKTAAD] ELSE (SELECT TOP 1 MUSTERI FROM [Web-Musteri] WHERE SMREF = CONVERT(int,[NOKTAAD])) END AS 'Nokta',[NOKTAEVRAKNO] AS 'Nokta Evrak No',convert(varchar(10), [NOKTAEVREKTARIH],120) AS 'Nokta Evrak Tarih',[URUNKOD] AS 'Ürt.Kod',CASE WHEN GRUPKOD = 'STG-1' THEN 'KGT' WHEN GRUPKOD = 'STG-2' THEN 'NF' ELSE 'DİĞER' END AS 'Grup',CASE WHEN OZELKOD LIKE '1011%' OR OZELKOD LIKE '01011%' THEN 'ARI' WHEN OZELKOD LIKE '1012%' OR OZELKOD LIKE '01012%' THEN 'TİBET' WHEN OZELKOD LIKE '1013%' OR OZELKOD LIKE '01013%' THEN 'HAYAT' WHEN OZELKOD LIKE '102%' OR OZELKOD LIKE '0102%' THEN 'YEG' ELSE 'DİĞER' END AS 'Kategori',[URUNAD] AS 'Ürün',KDV,KOLI AS 'Koli İçi',[NOKTASATADET] AS 'Nokta Adet',[NOKTASATADET] / KOLI AS 'Nokta Koli',[NOKTASATAY] AS 'Ay',[NOKTASATYIL] AS 'Yıl',[NOKTASATNET] AS 'Nokta Net Birim Fiyat',[NOKTASATNET] * [NOKTASATADET] AS 'Nokta Net Toplam Fiyat'," +
                    "CASE WHEN (SELECT FIYAT FROM [Web-Fiyat-TP] WHERE TIP = (CASE WHEN [BAYIKOD] = '1001327' OR BAYIKOD = '1000951' THEN 7 ELSE 22 END) AND YIL = [vw_Web-Satis-Rapor-TP].[NOKTASATYIL] AND AY = [vw_Web-Satis-Rapor-TP].[NOKTASATAY] AND ITEMREF = [vw_Web-Satis-Rapor-TP].ITEMREF) IS NOT NULL THEN (SELECT FIYAT FROM [Web-Fiyat-TP] WHERE TIP = (CASE WHEN [BAYIKOD] = '1001327' OR BAYIKOD = '1000951' THEN 7 ELSE 22 END) AND YIL = [vw_Web-Satis-Rapor-TP].[NOKTASATYIL] AND AY = [vw_Web-Satis-Rapor-TP].[NOKTASATAY] AND ITEMREF = [vw_Web-Satis-Rapor-TP].ITEMREF) ELSE (SELECT TOP 1 FIYAT FROM [Web-Fiyat-Full] WHERE TIP = (CASE WHEN [BAYIKOD] = '1001327' OR BAYIKOD = '1000951' THEN 7 ELSE 22 END) AND ITEMREF = [vw_Web-Satis-Rapor-TP].ITEMREF ORDER BY FIYAT DESC) END AS 'Brüt Liste Fiyati',[NOKTASATADET] * CASE WHEN (SELECT FIYAT FROM [Web-Fiyat-TP] WHERE TIP = (CASE WHEN [BAYIKOD] = '1001327' OR BAYIKOD = '1000951' THEN 7 ELSE 22 END) AND YIL = [vw_Web-Satis-Rapor-TP].[NOKTASATYIL] AND AY = [vw_Web-Satis-Rapor-TP].[NOKTASATAY] AND ITEMREF = [vw_Web-Satis-Rapor-TP].ITEMREF) IS NOT NULL THEN (SELECT FIYAT FROM [Web-Fiyat-TP] WHERE TIP = (CASE WHEN [BAYIKOD] = '1001327' OR BAYIKOD = '1000951' THEN 7 ELSE 22 END) AND YIL = [vw_Web-Satis-Rapor-TP].[NOKTASATYIL] AND AY = [vw_Web-Satis-Rapor-TP].[NOKTASATAY] AND ITEMREF = [vw_Web-Satis-Rapor-TP].ITEMREF) ELSE (SELECT TOP 1 FIYAT FROM [Web-Fiyat-Full] WHERE TIP = (CASE WHEN [BAYIKOD] = '1001327' OR BAYIKOD = '1000951' THEN 7 ELSE 22 END) AND ITEMREF = [vw_Web-Satis-Rapor-TP].ITEMREF ORDER BY FIYAT DESC) END AS 'Brüt Toplam Tutar'," +
                    "mnListeFiyat AS 'Bayi Net Alım',mnListeFiyat * [NOKTASATADET] AS 'Bayi Alım Maliyeti',([NOKTASATNET] * [NOKTASATADET]) - (mnListeFiyat * [NOKTASATADET]) AS 'Bütçe',(mnListeFiyat * [NOKTASATADET]) * CASE WHEN GRUPKOD = 'STG-1' THEN (SELECT flTAHKar FROM [Web-Musteri-TP-Ek] WHERE GMREF = [vw_Web-Satis-Rapor-TP].GMREF) ELSE (SELECT flYEGKar FROM [Web-Musteri-TP-Ek] WHERE GMREF = [vw_Web-Satis-Rapor-TP].GMREF) END / 100 AS 'Bayi Karlılık',([NOKTASATNET] * [NOKTASATADET]) - (mnListeFiyat * [NOKTASATADET]) - ((mnListeFiyat * [NOKTASATADET]) * CASE WHEN GRUPKOD = 'STG-1' THEN (SELECT flTAHKar FROM [Web-Musteri-TP-Ek] WHERE GMREF = [vw_Web-Satis-Rapor-TP].GMREF) ELSE (SELECT flYEGKar FROM [Web-Musteri-TP-Ek] WHERE GMREF = [vw_Web-Satis-Rapor-TP].GMREF) END / 100) AS 'Kalan Bütçe',mnListeFiyatKarli AS 'Kar Dahil Liste Fiyati',mnListeFiyatKarli * [NOKTASATADET] AS 'Kar Dahil Toplam Tutar',intAnlasmaID AS 'Anlaşma No',intAktiviteID AS 'Aktivite No',flIsk1 AS 'İsk.1',flIsk2 AS 'İsk.2',flIsk3 AS 'İsk.3',flIsk4 AS 'İsk.4',mnNetBirimFiyat AS 'İskontolar Düşülmüş Net Birim Fiyat',mnNetToplam AS 'İskontolar Düşülmüş Net Toplam Tutar',/*CASE WHEN [NOKTASATNET] < mnNetBirimFiyat THEN BAYIFIYATFARK ELSE 0 END AS 'Karşılanmayan Fark',CASE WHEN [NOKTASATNET] < mnNetBirimFiyat THEN BAYIFIYATFARK * [NOKTASATADET] ELSE 0 END AS 'Karşılanmayan Fark Toplam',CASE WHEN [NOKTASATNET] < mnNetBirimFiyat AND mnNetBirimFiyat != 0 THEN (BAYIFIYATFARK * 100 / mnNetBirimFiyat) / 100 ELSE 0 END AS 'Karşılanmayan Fark Yüzde',*/CASE WHEN [NOKTASATNET] > mnNetBirimFiyat AND [NOKTASATADET] > 0 THEN BAYIFIYATFARK * -1 ELSE 0 END AS 'Fiyat Farkı Faturası Girilmesi Gereken Tutar',CASE WHEN [NOKTASATNET] > mnNetBirimFiyat AND [NOKTASATADET] > 0 THEN BAYIFIYATFARK * -1 * [NOKTASATADET] ELSE 0 END AS 'Fiyat Farkı Faturası Girilmesi Gereken Toplam',BAYIFIYATFARK AS 'Bayi Satışı İle İskontolar Düşülmüş Fiyat Farkı',BAYIFIYATFARK * [NOKTASATADET] AS 'Bayi Satışı İle İskontolar Düşülmüş Fiyat Fark Toplamı',CASE WHEN [NOKTASATADET] > 0 AND mnNetBirimFiyat >= [NOKTASATNET] THEN BAYIFIYATFARK * [NOKTASATADET] ELSE 0 END AS 'Uygulama Fiyatı Altında Net Satış Toplam',CASE WHEN [NOKTASATADET] > 0 AND mnNetBirimFiyat < [NOKTASATNET] THEN BAYIFIYATFARK * [NOKTASATADET] ELSE 0 END AS 'Uygulama Fiyatı Üstünde Net Satış Toplam',/*mnBirimFark AS 'Birim Fark',CASE WHEN GRUPKOD = 'STG-1' THEN mnToplamFark ELSE 0 END AS 'KGT Toplam Fark',CASE WHEN GRUPKOD = 'STG-2' THEN mnToplamFark ELSE 0 END AS 'NF Toplam Fark',mnToplamFark AS 'Toplam Fark',*/blGeriyeDonuk AS 'Geriye Dönük Aktivite' FROM [vw_Web-Satis-Rapor-TP] WHERE [vw_Web-Satis-Rapor-TP].[BAYIKOD] = @BAYIKOD AND NOKTASATYIL = @NOKTASATYIL AND NOKTASATAY = @NOKTASATAY ORDER BY BOLGE,BAYIUNVAN,NOKTAAD,URUNAD",
                    new ArrayList() { "@BAYIKOD", "@NOKTASATYIL", "@NOKTASATAY" },
                    new SqlDbType[] { SqlDbType.NVarChar, SqlDbType.SmallInt, SqlDbType.TinyInt },
                    new ArrayList() { Bayikod, Yil, Ay },
                    "Rapor_Satiri");
                ds.Tables.Add(dt);
                donendeger.LoadXml(ds.GetXml());
            }

            return donendeger;
        }
        /// <summary>
        /// Emüsiad Ürünler
        /// </summary>
        public XmlDocument EmusiadGetProducts(string Sifre, string Grup)
        {
            XmlDocument donendeger = new XmlDocument();

            if (Sifre == "emusiad123")
            {
                DataTable dt = new DataTable();
                FiyatListeleri.GetObjectXml(dt, 7, "komsu");

                Sultanlar.Class.XmlEmusiad emusiad = new Class.XmlEmusiad();
                emusiad.title = "Tibet A.Ş.";
                emusiad.updated = DateTime.Now.ToString("r");
                emusiad.lastBuildDate = DateTime.Now.ToString("r");
                emusiad.entry = new List<Class.Entry>();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Sultanlar.Class.Entry entry = new Class.Entry();
                    if (Grup == "ari" && Urunler.GetProductOzelKod(Convert.ToInt32(dt.Rows[i]["Kod"])) == "T4")
                    {
                        EmusiadDoldur(dt, i, entry);
                        emusiad.entry.Add(entry);
                    }
                    else if (Grup == "kenton" && Urunler.GetProductOzelKod(Convert.ToInt32(dt.Rows[i]["Kod"])) == "T3")
                    {
                        EmusiadDoldur(dt, i, entry);
                        emusiad.entry.Add(entry);
                    }
                    else if (Grup == "temizlik" && (Urunler.GetProductOzelKod(Convert.ToInt32(dt.Rows[i]["Kod"])) == "T1" || Urunler.GetProductOzelKod(Convert.ToInt32(dt.Rows[i]["Kod"])) == "T2"))
                    {
                        EmusiadDoldur(dt, i, entry);
                        emusiad.entry.Add(entry);
                    }
                }

                XmlSerializerNamespaces xsn = new XmlSerializerNamespaces();
                xsn.Add("g", "http://base.google.com/ns/1.0");
                XmlSerializer MySerializer = new XmlSerializer(typeof(Sultanlar.Class.XmlEmusiad), "http://www.w3.org/2005/Atom");

                TextWriter TW = new StringWriter();
                //var settings = new XmlWriterSettings();
                //settings.OmitXmlDeclaration = true;
                //var writer = XmlWriter.Create(TW, settings);


                MySerializer.Serialize(TW, emusiad, xsn);

                donendeger.LoadXml(TW.ToString());
            }

            return donendeger;
        }
        /// <summary>
        /// View
        /// </summary>
        public XmlDocument GetView(string Sifre, string Name, string ParamNames, string ParamValues)
        {
            XmlDocument donendeger = new XmlDocument();

            DataSet ds = new DataSet("Views");
            DataTable dt = new DataTable(Name);

            ArrayList paramn = new ArrayList();
            ArrayList paramv = new ArrayList();
            string[] paramN = ParamNames.Split(new string[] { ";" }, StringSplitOptions.None);
            string[] paramV = ParamValues.Split(new string[] { ";" }, StringSplitOptions.None);
            for (int i = 0; i < paramN.Length; i++)
            {
                paramn.Add(paramN[i]);
                paramv.Add(paramV[i]);
            }

            if (Sifre == "rapor2020")
                dt = WebGenel.WCFdata("SELECT * FROM [" + Name + "] ", paramn, paramv, Name);

            ds.Tables.Add(dt);
            donendeger.LoadXml(ds.GetXml());

            return donendeger;
        }
        /// <summary>
        /// View
        /// </summary>
        public Stream GetViewJson(string Sifre, string Name, string ParamNames, string ParamValues)
        {
            DataSet ds = new DataSet("Views");
            DataTable dt = new DataTable(Name);

            ArrayList paramn = new ArrayList();
            ArrayList paramv = new ArrayList();
            string[] paramN = ParamNames.Split(new string[] { ";" }, StringSplitOptions.None);
            string[] paramV = ParamValues.Split(new string[] { ";" }, StringSplitOptions.None);
            for (int i = 0; i < paramN.Length; i++)
            {
                paramn.Add(paramN[i]);
                paramv.Add(paramV[i]);
            }

            if (Sifre == "rapor2020")
                dt = WebGenel.WCFdata("SELECT * FROM [" + Name + "] ", paramn, paramv, Name);

            ds.Tables.Add(dt);

            List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
            Dictionary<string, object> row;
            foreach (DataRow dr in dt.Rows)
            {
                row = new Dictionary<string, object>();
                foreach (DataColumn col in dt.Columns)
                {
                    row.Add(col.ColumnName, dr[col]);
                }
                rows.Add(row);
            }

            //JsonSerializerSettings jss = new JsonSerializerSettings();
            //jss.MaxDepth = int.MaxValue;
            //System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();
            //js.MaxJsonLength = int.MaxValue;
            /*return JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(donendeger);*/
            //return Newtonsoft.Json.JsonConvert.SerializeObject(rows, Newtonsoft.Json.Formatting.None);
            //return js.Serialize(rows);
            string donendeger = JsonConvert.SerializeObject(dt, new DataTableConverter());
            return new MemoryStream(Encoding.UTF8.GetBytes(donendeger));
            //return JsonConvert.SerializeObject(dt.AsEnumerable().Select(r => r.ItemArray));
        }
        /// <summary>
        /// 
        /// </summary>
        public XmlDocument GetOrdersPirpa()
        {
            XmlDocument donendeger = new XmlDocument();



            DataTable dt = WebGenel.WCFdata("SELECT TOP (1000) [pkSiparisID] AS SipNo,sintFiyatTipiID, intSLSREF AS [PlasiyerKodu], strAd + ' ' + strSoyad AS [PlasiyerAdi],strTelefon AS Telefon,BOLGE AS [Bölge],[SMREF] AS MusKod"
+ " ,[dtOlusmaTarihi] AS Tarih,[mnToplamTutar] AS Tutar, strAciklama "
+ "FROM[tblINTERNET_Siparisler] "
+ "INNER JOIN tblINTERNET_Musteriler ON[tblINTERNET_Siparisler].intMusteriID = pkMusteriID "
+ "INNER JOIN tblINTERNET_Musteriler_Ek ON tblINTERNET_Musteriler_Ek.intMusteriID = pkMusteriID "
+ "INNER JOIN[Web-Dis-Siparis] ON [pkSiparisID] = intSiparisID "
+ "WHERE blAktarilmis = 'True' "
+ "AND (intSLSREF = 830222 OR intSLSREF = 830226 OR intSLSREF = 830227 OR intSLSREF = 830223 OR intSLSREF = 830107 OR intSLSREF = 830228 OR intSLSREF = 830224 OR intSLSREF = 830225 OR intSLSREF = 830229 OR intSLSREF = 830221) "
+ "ORDER BY pkSiparisID DESC", new ArrayList(), new ArrayList(), "Orders");



            XmlSiparislerDis siparisler = new XmlSiparislerDis();
            siparisler.Siparisler = new List<XmlSiparisDis>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                XmlSiparisDis siparis = new XmlSiparisDis();

                DataTable dt2 = WebGenel.WCFdata("SELECT DISTINCT [IL] AS Sehir,[ILCE] AS Ilce,[GMREF] AS BayiKod,[MUSTERI] AS BayiUnvan,[SMREF] AS Kod,[SUBE] AS Unvan,[MT ACIKLAMA] AS Aciklama,SEHIR AS FaturaTip,[VRG DAIRE] AS VergiDaire,[VRG NO] AS VergiNo,[ADRES] AS Adres,[TEL-1] AS Telefon,[CEP-1] AS Mobil,[FAX-1] AS Fax,[EMAIL-1] AS Eposta FROM [Web-Musteri]", new ArrayList() { "SMREF" }, new ArrayList() { dt.Rows[i]["MusKod"].ToString() }, "Musteri");
                siparis.Musteri = new XmlSiparisMusteri();
                siparis.Musteri.Sehir = dt2.Rows[0]["Sehir"].ToString();
                siparis.Musteri.Ilce = dt2.Rows[0]["Ilce"].ToString();
                siparis.Musteri.BayiKod = dt2.Rows[0]["BayiKod"].ToString();
                siparis.Musteri.BayiUnvan = dt2.Rows[0]["BayiUnvan"].ToString();
                siparis.Musteri.Kod = dt2.Rows[0]["Kod"].ToString();
                siparis.Musteri.Unvan = dt2.Rows[0]["Unvan"].ToString();
                siparis.Musteri.Aciklama = dt2.Rows[0]["Aciklama"].ToString();
                siparis.Musteri.FaturaTip = dt2.Rows[0]["FaturaTip"].ToString();
                siparis.Musteri.VergiDaire = dt2.Rows[0]["VergiDaire"].ToString();
                siparis.Musteri.VergiNo = dt2.Rows[0]["VergiNo"].ToString();
                siparis.Musteri.Adres = dt2.Rows[0]["Adres"].ToString();
                siparis.Musteri.Telefon = dt2.Rows[0]["Telefon"].ToString();
                siparis.Musteri.Mobil = dt2.Rows[0]["Mobil"].ToString();
                siparis.Musteri.Fax = dt2.Rows[0]["Fax"].ToString();
                siparis.Musteri.Eposta = dt2.Rows[0]["Eposta"].ToString();

                siparis.SipNo = dt.Rows[i]["SipNo"].ToString();
                siparis.PlasiyerKodu = dt.Rows[i]["PlasiyerKodu"].ToString();
                siparis.PlasiyerAdi = dt.Rows[i]["PlasiyerAdi"].ToString();
                siparis.Telefon = dt.Rows[i]["Telefon"].ToString();
                siparis.Bolge = dt.Rows[i]["Bölge"].ToString();
                siparis.Tarih = Convert.ToDateTime(dt.Rows[i]["Tarih"]);
                //siparis.Tutar = Convert.ToDouble(dt.Rows[i]["Tutar"]);
                siparis.Aciklama = dt.Rows[i]["strAciklama"].ToString().Split(new string[] { ";;;" }, StringSplitOptions.None)[1];
                siparis.Kalemler = new List<XmlSiparisDisDetay>();

                DataTable dt1 = WebGenel.WCFdata("" +

                    "SELECT UrunKod,Bolum,Barkod,KdvOran,KoliAdet,UrunAd,Adet,ISNULL(BrutFiyat,0) AS BrutFiyat,ISNULL(Isk1,0) AS Isk1,ISNULL(Isk2,0) AS Isk2,ISNULL(Isk3,0) AS Isk3,ISNULL(Isk4,0) AS Isk4" +
",CONVERT(decimal(18,3),ISNULL(dbo.IskontoDusCoklu(BrutFiyat,Isk1,Isk2,Isk3,Isk4,0,0,0,0,0,0),0)) AS NetFiyat" +
",CONVERT(decimal(18,3),ISNULL(dbo.IskontoDusCoklu(BrutFiyat,Isk1,Isk2,Isk3,Isk4,0,0,0,0,0,0) / 100 * KdvOran,0)) AS Kdv" +
",CONVERT(decimal(18,3),ISNULL(dbo.IskontoDusCoklu(BrutFiyat,Isk1,Isk2,Isk3,Isk4,0,0,0,0,0,0) + (dbo.IskontoDusCoklu(BrutFiyat,Isk1,Isk2,Isk3,Isk4,0,0,0,0,0,0) / 100 * KdvOran),0)) AS KdvDahilNet " +
"FROM " +
"(" +
"SELECT intSiparisID,[intUrunID] AS UrunKod,[OZEL ACIK] AS Bolum,BARKOD AS Barkod,KDV AS KdvOran,KOLI AS KoliAdet,[strUrunAdi] AS UrunAd,[intMiktar] AS Adet" +
",ISNULL(FIYAT,(SELECT FIYAT FROM [Web-Fiyat-TP] WHERE TIP = tblINTERNET_Siparisler.sintFiyatTipiID AND YIL = YEAR(dtOnaylamaTarihi) AND AY = MONTH(dtOnaylamaTarihi) AND ITEMREF = intUrunID)) AS BrutFiyat" +
",ISNULL(ISK1,(SELECT ISK1 FROM [Web-Fiyat-TP] WHERE TIP = tblINTERNET_Siparisler.sintFiyatTipiID AND YIL = YEAR(dtOnaylamaTarihi) AND AY = MONTH(dtOnaylamaTarihi) AND ITEMREF = intUrunID)) AS Isk1" +
",ISNULL(ISK2,(SELECT ISK2 FROM [Web-Fiyat-TP] WHERE TIP = tblINTERNET_Siparisler.sintFiyatTipiID AND YIL = YEAR(dtOnaylamaTarihi) AND AY = MONTH(dtOnaylamaTarihi) AND ITEMREF = intUrunID)) AS Isk2" +
",ISNULL(ISK3,(SELECT ISK3 FROM [Web-Fiyat-TP] WHERE TIP = tblINTERNET_Siparisler.sintFiyatTipiID AND YIL = YEAR(dtOnaylamaTarihi) AND AY = MONTH(dtOnaylamaTarihi) AND ITEMREF = intUrunID)) AS Isk3" +
",ISNULL(ISK4,(SELECT ISK6 FROM [Web-Fiyat-TP] WHERE TIP = tblINTERNET_Siparisler.sintFiyatTipiID AND YIL = YEAR(dtOnaylamaTarihi) AND AY = MONTH(dtOnaylamaTarihi) AND ITEMREF = intUrunID)) AS Isk4 " +
"FROM [tblINTERNET_SiparislerDetay] " +
"INNER JOIN tblINTERNET_Siparisler ON intSiparisID = pkSiparisID " +
"INNER JOIN [Web-Malzeme-Full] ON ITEMREF = intUrunID LEFT OUTER JOIN tblINTERNET_SiparislerDetayISK ON pkSiparisDetayID = bintSiparisDetayID" +
") AS TABLO1" +

                    "", new ArrayList() { "intSiparisID" }, new ArrayList() { siparis.SipNo }, "OrderDetail");

                double toplambrut = 0;
                double toplamiskonto = 0;
                double toplamkdv = 0;
                double toplamnet = 0;
                double toplamnetkdv = 0;
                for (int j = 0; j < dt1.Rows.Count; j++)
                {
                    XmlSiparisDisDetay detay = new XmlSiparisDisDetay();
                    detay.UrunKod = dt1.Rows[j]["UrunKod"].ToString();
                    detay.Bolum = dt1.Rows[j]["Bolum"].ToString();
                    detay.Barkod = dt1.Rows[j]["Barkod"].ToString();
                    detay.KdvOran = dt1.Rows[j]["KdvOran"].ToString();
                    detay.KoliAdet = dt1.Rows[j]["KoliAdet"].ToString();
                    detay.UrunAd = dt1.Rows[j]["UrunAd"].ToString();
                    detay.Adet = Convert.ToInt32(dt1.Rows[j]["Adet"]);
                    detay.BrutFiyat = Convert.ToDouble(dt1.Rows[j]["BrutFiyat"]);
                    detay.Isk1 = Convert.ToDouble(dt1.Rows[j]["Isk1"]);
                    detay.Isk2 = Convert.ToDouble(dt1.Rows[j]["Isk2"]);
                    detay.Isk3 = Convert.ToDouble(dt1.Rows[j]["Isk3"]);
                    detay.Isk4 = Convert.ToDouble(dt1.Rows[j]["Isk4"]);
                    detay.NetFiyat = Convert.ToDouble(dt1.Rows[j]["NetFiyat"]);
                    detay.Kdv = Convert.ToDouble(dt1.Rows[j]["Kdv"]);
                    detay.KdvDahilNet = Convert.ToDouble(dt1.Rows[j]["KdvDahilNet"]);
                    siparis.Kalemler.Add(detay);

                    toplambrut += detay.BrutFiyat * detay.Adet;
                    toplamiskonto += (detay.BrutFiyat - detay.NetFiyat) * detay.Adet;
                    toplamkdv += (detay.KdvDahilNet - detay.NetFiyat) * detay.Adet;
                    toplamnet += detay.NetFiyat * detay.Adet;
                    toplamnetkdv += detay.KdvDahilNet * detay.Adet;
                }
                siparis.ToplamBrut = Convert.ToDouble(toplambrut.ToString("N3"));
                siparis.ToplamIskonto = Convert.ToDouble(toplamiskonto.ToString("N3"));
                siparis.ToplamKDV = Convert.ToDouble(toplamkdv.ToString("N3"));
                siparis.ToplamNet = Convert.ToDouble(toplamnet.ToString("N3"));
                siparis.ToplamNetKDV = Convert.ToDouble(toplamnetkdv.ToString("N3"));

                siparisler.Siparisler.Add(siparis);
            }


            XmlSerializerNamespaces xsn = new XmlSerializerNamespaces();
            xsn.Add("g", "http://base.google.com/ns/1.0");
            XmlSerializer MySerializer = new XmlSerializer(typeof(XmlSiparislerDis), "http://www.w3.org/2005/Atom");

            TextWriter TW = new StringWriter();


            MySerializer.Serialize(TW, siparisler, xsn);



            donendeger.LoadXml(TW.ToString());

            return donendeger;
        }
        /// <summary>
        /// 
        /// </summary>
        public class gokw3stoklar
        {
            [XmlElement(ElementName = "Stok", Order = 1)]
            public List<gokw3stok> Stoklar { get; set; }
        }
        /// <summary>
        /// 
        /// </summary>
        public class gokw3stok
        {
            public short A_P { get; set; } public short AMB_NO { get; set; } public string AMBAR { get; set; } public string STGRPCODE { get; set; } public string SPECODE { get; set; } public string CYPHCODE { get; set; } public string MARK_C { get; set; } public string MARK_A { get; set; } public string PRODUCERCODE { get; set; } public string CODE_M { get; set; } public string NAME_M { get; set; } public double STOK { get; set; } public DateTime LASTTRDATE { get; set; } public int YIL { get; set; } public int AY { get; set; }
        }
        /// <summary>
        /// 
        /// </summary>
        public XmlDocument Gokw3stok(string YIL, string AY)
        {
            XmlDocument donendeger = new XmlDocument();



            ArrayList paramn = new ArrayList() { "YIL", "AY" };
            ArrayList paramv = new ArrayList() { YIL, AY };
            DataTable dt = WebGenel.WCFdata("SELECT * FROM (SELECT TOP (100) PERCENT GOKW3.dbo.LG_400_ITEMS.ACTIVE AS A_P, GOKW3.dbo.L_CAPIWHOUSE.NR AS AMB_NO, GOKW3.dbo.L_CAPIWHOUSE.NAME AS AMBAR, GOKW3.dbo.LG_400_ITEMS.STGRPCODE, GOKW3.dbo.LG_400_ITEMS.SPECODE, GOKW3.dbo.LG_400_ITEMS.CYPHCODE, GOKW3.dbo.LG_400_MARK.CODE AS MARK_C, GOKW3.dbo.LG_400_MARK.DESCR AS MARK_A, GOKW3.dbo.LG_400_ITEMS.PRODUCERCODE, GOKW3.dbo.LG_400_ITEMS.CODE AS CODE_M, GOKW3.dbo.LG_400_ITEMS.NAME AS NAME_M, SUM(GOKW3.dbo.LV_400_01_GNTOTST.ONHAND) AS STOK, GOKW3.dbo.LV_400_01_GNTOTST.LASTTRDATE, YEAR(GOKW3.dbo.LV_400_01_GNTOTST.LASTTRDATE) AS YIL, MONTH(GOKW3.dbo.LV_400_01_GNTOTST.LASTTRDATE) AS AY FROM GOKW3.dbo.LV_400_01_GNTOTST INNER JOIN GOKW3.dbo.L_CAPIWHOUSE ON GOKW3.dbo.LV_400_01_GNTOTST.INVENNO = GOKW3.dbo.L_CAPIWHOUSE.NR RIGHT OUTER JOIN GOKW3.dbo.LG_400_ITEMS ON GOKW3.dbo.LV_400_01_GNTOTST.STOCKREF = GOKW3.dbo.LG_400_ITEMS.LOGICALREF LEFT OUTER JOIN GOKW3.dbo.LG_400_MARK ON GOKW3.dbo.LG_400_ITEMS.MARKREF = GOKW3.dbo.LG_400_MARK.LOGICALREF WHERE (GOKW3.dbo.L_CAPIWHOUSE.FIRMNR = 400) AND (GOKW3.dbo.LV_400_01_GNTOTST.INVENNO <> - 1) AND (GOKW3.dbo.LG_400_ITEMS.STGRPCODE <> 'DB') GROUP BY GOKW3.dbo.LG_400_ITEMS.NAME, GOKW3.dbo.LG_400_ITEMS.CODE, GOKW3.dbo.L_CAPIWHOUSE.NAME, GOKW3.dbo.LG_400_ITEMS.STGRPCODE, GOKW3.dbo.LG_400_ITEMS.SPECODE, GOKW3.dbo.LG_400_ITEMS.ACTIVE, GOKW3.dbo.L_CAPIWHOUSE.NR, GOKW3.dbo.LG_400_MARK.CODE, GOKW3.dbo.LG_400_MARK.DESCR, GOKW3.dbo.LG_400_ITEMS.PRODUCERCODE, GOKW3.dbo.LG_400_ITEMS.CYPHCODE, GOKW3.dbo.LV_400_01_GNTOTST.LASTTRDATE HAVING (GOKW3.dbo.LG_400_ITEMS.STGRPCODE LIKE 'STG%') ORDER BY AMB_NO, GOKW3.dbo.LG_400_ITEMS.STGRPCODE, NAME_M) AS TABLO1", paramn, paramv, "Stok");

            gokw3stoklar goklar = new gokw3stoklar();
            goklar.Stoklar = new List<gokw3stok>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                gokw3stok gok = new gokw3stok()
                {
                    A_P = Convert.ToInt16(dt.Rows[i]["A_P"]), 
                    AMB_NO = Convert.ToInt16(dt.Rows[i]["AMB_NO"]),
                    AMBAR = dt.Rows[i]["AMBAR"].ToString(),
                    STGRPCODE = dt.Rows[i]["STGRPCODE"].ToString(),
                    SPECODE = dt.Rows[i]["SPECODE"].ToString(),
                    CYPHCODE = dt.Rows[i]["CYPHCODE"].ToString(),
                    MARK_C = dt.Rows[i]["MARK_C"].ToString(),
                    MARK_A = dt.Rows[i]["MARK_A"].ToString(),
                    PRODUCERCODE = dt.Rows[i]["PRODUCERCODE"].ToString(),
                    CODE_M = dt.Rows[i]["CODE_M"].ToString(),
                    NAME_M = dt.Rows[i]["NAME_M"].ToString(),
                    STOK = Convert.ToInt32(dt.Rows[i]["STOK"]),
                    LASTTRDATE = Convert.ToDateTime(dt.Rows[i]["LASTTRDATE"]),
                    YIL = Convert.ToInt32(dt.Rows[i]["YIL"]),
                    AY = Convert.ToInt32(dt.Rows[i]["AY"]),
                };
                goklar.Stoklar.Add(gok);
            }
            

            XmlSerializerNamespaces xsn = new XmlSerializerNamespaces();
            xsn.Add("g", "http://base.google.com/ns/1.0");
            XmlSerializer MySerializer = new XmlSerializer(typeof(gokw3stoklar), "http://www.w3.org/2005/Atom");

            TextWriter TW = new StringWriter();


            MySerializer.Serialize(TW, goklar, xsn);



            donendeger.LoadXml(TW.ToString());

            return donendeger;
        }
        public class gokw3satislar
        {
            [XmlElement(ElementName = "Satis", Order = 1)]
            public List<gokw3satis> Satislar { get; set; }
        }
        public class gokw3satis
        { 
            public short IOCODE { get; set; }public string ANA_ISLEM { get; set; }public short TRCODE { get; set; }public string TUR_ACK { get; set; }public short YON { get; set; }public short IPT { get; set; }public short FF { get; set; }public short TRCODE_I { get; set; }public int YIL { get; set; }public int AY { get; set; }public DateTime DATE__I { get; set; }public string FICHENO_I { get; set; }public string DOCODE_I { get; set; }public string INVNO_I { get; set; }public string SPECODE_I { get; set; }public string CYPHCODE_I { get; set; }public short BILLED { get; set; }public short TRCODE_F { get; set; }public DateTime DATE__F { get; set; }public string FICHENO_F { get; set; }public string DOCODE_F { get; set; }public string SPECODE_F { get; set; }public string CYPHCODE_F { get; set; }public string TRADINGGRP_F { get; set; }public int CLIENTREF_F { get; set; }public string TAXOFFICE_C { get; set; }public string TAXNR_C { get; set; }public string CODE_G { get; set; }public string DEFINITION_G { get; set; }public string CODE_SB { get; set; }public string DEFINITION_SB { get; set; }public string SPECODE_C { get; set; }public string CYPHCODE_C { get; set; }public string CODE_S { get; set; }public string DEFINITION__S { get; set; }public string SPECODE_S { get; set; }public string CYPHCODE_S { get; set; }public string STGRPCODE_S { get; set; }public string PRODUCERCODE_S { get; set; }public string MARK_C { get; set; }public string MARK_A { get; set; }public double AMOUNT { get; set; }public double PRICE { get; set; }public double TOTAL { get; set; }public double DISTCOST { get; set; }public double DISTDISC { get; set; }public double DISTEXP { get; set; }public double DISTPROM { get; set; }public double DISCPER { get; set; }public double VAT { get; set; }public double VATAMNT { get; set; }public double VATMATRAH { get; set; }public double NETKDV { get; set; }
        }
        /// <summary>
        /// 
        /// </summary>
        public XmlDocument Gokw3satis(string YIL, string AY)
        {
            XmlDocument donendeger = new XmlDocument();



            ArrayList paramn = new ArrayList() { "YIL", "AY" };
            ArrayList paramv = new ArrayList() { YIL, AY };
            DataTable dt = WebGenel.WCFdata("SELECT * FROM (SELECT     TOP (100) PERCENT GOKW3.dbo.LG_400_01_STLINE.IOCODE, GOKW3.dbo.HareketYon.ANA_ISLEM, GOKW3.dbo.LG_400_01_STLINE.TRCODE, GOKW3.dbo.HareketYon.TUR_ACK, GOKW3.dbo.HareketYon.YON, GOKW3.dbo.LG_400_01_STLINE.CANCELLED AS IPT, GOKW3.dbo.LG_400_01_STLINE.DECPRDIFF AS FF, ISNULL(GOKW3.dbo.LG_400_01_STFICHE.TRCODE,0) AS TRCODE_I, YEAR(ISNULL(GOKW3.dbo.LG_400_01_INVOICE.DATE_, GOKW3.dbo.LG_400_01_STFICHE.DATE_)) AS YIL, MONTH(ISNULL(GOKW3.dbo.LG_400_01_INVOICE.DATE_, GOKW3.dbo.LG_400_01_STFICHE.DATE_)) AS AY, ISNULL(GOKW3.dbo.LG_400_01_STFICHE.DATE_,getdate()) AS DATE__I, ISNULL(GOKW3.dbo.LG_400_01_STFICHE.FICHENO,'') AS FICHENO_I, ISNULL(GOKW3.dbo.LG_400_01_STFICHE.DOCODE,'') AS DOCODE_I, ISNULL(GOKW3.dbo.LG_400_01_STFICHE.INVNO,'') AS INVNO_I, ISNULL(GOKW3.dbo.LG_400_01_STFICHE.SPECODE,'') AS SPECODE_I, ISNULL(GOKW3.dbo.LG_400_01_STFICHE.CYPHCODE,'') AS CYPHCODE_I, GOKW3.dbo.LG_400_01_STLINE.BILLED, ISNULL(GOKW3.dbo.LG_400_01_INVOICE.TRCODE,0) AS TRCODE_F, ISNULL(GOKW3.dbo.LG_400_01_INVOICE.DATE_,getdate()) AS DATE__F, ISNULL(GOKW3.dbo.LG_400_01_INVOICE.FICHENO,'') AS FICHENO_F, ISNULL(GOKW3.dbo.LG_400_01_INVOICE.DOCODE,'') AS DOCODE_F, ISNULL(GOKW3.dbo.LG_400_01_INVOICE.SPECODE,'') AS SPECODE_F, ISNULL(GOKW3.dbo.LG_400_01_INVOICE.CYPHCODE,'') AS CYPHCODE_F, ISNULL(GOKW3.dbo.LG_400_01_INVOICE.TRADINGGRP,'') AS TRADINGGRP_F, ISNULL(GOKW3.dbo.LG_400_01_INVOICE.CLIENTREF,0) AS CLIENTREF_F, GOKW3.dbo.LG_400_CLCARD.TAXOFFICE AS TAXOFFICE_C, GOKW3.dbo.LG_400_CLCARD.TAXNR AS TAXNR_C, ISNULL(LG_400_CLCARD_1.CODE, GOKW3.dbo.LG_400_CLCARD.CODE) AS CODE_G, ISNULL(LG_400_CLCARD_1.DEFINITION_, GOKW3.dbo.LG_400_CLCARD.DEFINITION_) AS DEFINITION_G, GOKW3.dbo.LG_400_CLCARD.CODE AS CODE_SB, GOKW3.dbo.LG_400_CLCARD.DEFINITION_ AS DEFINITION_SB, GOKW3.dbo.LG_400_CLCARD.SPECODE AS SPECODE_C, GOKW3.dbo.LG_400_CLCARD.CYPHCODE AS CYPHCODE_C, ISNULL(CASE GOKW3.dbo.LG_400_01_STLINE.LINETYPE WHEN 4 THEN GOKW3.dbo.LG_400_SRVCARD.CODE ELSE GOKW3.dbo.LG_400_ITEMS.CODE END, GOKW3.dbo.LG_400_DECARDS.CODE) AS CODE_S, ISNULL(CASE GOKW3.dbo.LG_400_01_STLINE.LINETYPE WHEN 4 THEN GOKW3.dbo.LG_400_SRVCARD.DEFINITION_ ELSE GOKW3.dbo.LG_400_ITEMS.NAME END, GOKW3.dbo.LG_400_DECARDS.DEFINITION_) AS DEFINITION__S, ISNULL(GOKW3.dbo.LG_400_ITEMS.SPECODE,'') AS SPECODE_S, ISNULL(GOKW3.dbo.LG_400_ITEMS.CYPHCODE,'') AS CYPHCODE_S, ISNULL(GOKW3.dbo.LG_400_ITEMS.STGRPCODE,'') AS STGRPCODE_S, ISNULL(GOKW3.dbo.LG_400_ITEMS.PRODUCERCODE,'') AS PRODUCERCODE_S, ISNULL(GOKW3.dbo.LG_400_MARK.CODE,'') AS MARK_C, ISNULL(GOKW3.dbo.LG_400_MARK.DESCR,'') AS MARK_A, CASE GOKW3.dbo.LG_400_01_STLINE.TRCODE WHEN 13 THEN 0 WHEN 14 THEN 0 ELSE GOKW3.dbo.LG_400_01_STLINE.AMOUNT END AS AMOUNT, SUM(GOKW3.dbo.LG_400_01_STLINE.PRICE) AS PRICE, SUM(GOKW3.dbo.LG_400_01_STLINE.TOTAL * GOKW3.dbo.HareketYon.YON) AS TOTAL, SUM(GOKW3.dbo.LG_400_01_STLINE.DISTCOST * GOKW3.dbo.HareketYon.YON) AS DISTCOST, SUM(GOKW3.dbo.LG_400_01_STLINE.DISTDISC * GOKW3.dbo.HareketYon.YON) AS DISTDISC, SUM(GOKW3.dbo.LG_400_01_STLINE.DISTEXP * GOKW3.dbo.HareketYon.YON) AS DISTEXP, SUM(GOKW3.dbo.LG_400_01_STLINE.DISTPROM * GOKW3.dbo.HareketYon.YON) AS DISTPROM, SUM(GOKW3.dbo.LG_400_01_STLINE.DISCPER * GOKW3.dbo.HareketYon.YON) AS DISCPER, GOKW3.dbo.LG_400_01_STLINE.VAT, SUM(GOKW3.dbo.LG_400_01_STLINE.VATAMNT * GOKW3.dbo.HareketYon.YON) AS VATAMNT, SUM(CASE GOKW3.dbo.LG_400_01_STLINE.LINETYPE WHEN 1 THEN 0 ELSE GOKW3.dbo.LG_400_01_STLINE.VATMATRAH END * GOKW3.dbo.HareketYon.YON) AS VATMATRAH, SUM((CASE GOKW3.dbo.LG_400_01_STLINE.LINETYPE WHEN 1 THEN 0 ELSE GOKW3.dbo.LG_400_01_STLINE.VATMATRAH END + GOKW3.dbo.LG_400_01_STLINE.VATAMNT) * GOKW3.dbo.HareketYon.YON) AS [NETKDV] FROM         GOKW3.dbo.LG_400_CLCARD AS LG_400_CLCARD_1 RIGHT OUTER JOIN GOKW3.dbo.LG_400_CLCARD ON LG_400_CLCARD_1.LOGICALREF = GOKW3.dbo.LG_400_CLCARD.PARENTCLREF RIGHT OUTER JOIN GOKW3.dbo.LG_400_MARK RIGHT OUTER JOIN GOKW3.dbo.LG_400_ITEMS ON GOKW3.dbo.LG_400_MARK.LOGICALREF = GOKW3.dbo.LG_400_ITEMS.MARKREF RIGHT OUTER JOIN GOKW3.dbo.LG_400_DECARDS RIGHT OUTER JOIN GOKW3.dbo.LG_400_01_STLINE ON GOKW3.dbo.LG_400_DECARDS.LOGICALREF = GOKW3.dbo.LG_400_01_STLINE.STOCKREF ON GOKW3.dbo.LG_400_ITEMS.LOGICALREF = GOKW3.dbo.LG_400_01_STLINE.STOCKREF LEFT OUTER JOIN GOKW3.dbo.HareketYon ON GOKW3.dbo.LG_400_01_STLINE.TRCODE = GOKW3.dbo.HareketYon.TUR_KOD AND GOKW3.dbo.LG_400_01_STLINE.DECPRDIFF = GOKW3.dbo.HareketYon.FF LEFT OUTER JOIN GOKW3.dbo.LG_400_SRVCARD ON GOKW3.dbo.LG_400_01_STLINE.STOCKREF = GOKW3.dbo.LG_400_SRVCARD.LOGICALREF ON GOKW3.dbo.LG_400_CLCARD.LOGICALREF = GOKW3.dbo.LG_400_01_STLINE.CLIENTREF LEFT OUTER JOIN GOKW3.dbo.LG_400_01_STFICHE ON GOKW3.dbo.LG_400_01_STLINE.STFICHEREF = GOKW3.dbo.LG_400_01_STFICHE.LOGICALREF AND GOKW3.dbo.HareketYon.TUR_KODI = GOKW3.dbo.LG_400_01_STFICHE.TRCODE LEFT OUTER JOIN GOKW3.dbo.LG_400_01_INVOICE ON GOKW3.dbo.LG_400_01_STLINE.INVOICEREF = GOKW3.dbo.LG_400_01_INVOICE.LOGICALREF AND GOKW3.dbo.HareketYon.TUR_KODF = GOKW3.dbo.LG_400_01_INVOICE.TRCODE WHERE     (NOT (GOKW3.dbo.LG_400_01_STLINE.STOCKREF IS NULL)) AND (GOKW3.dbo.LG_400_01_STLINE.STOCKREF <> 0) OR (NOT (GOKW3.dbo.LG_400_01_STLINE.STOCKREF IS NULL)) AND (GOKW3.dbo.LG_400_01_STLINE.STOCKREF <> 0) OR (NOT (GOKW3.dbo.LG_400_01_STLINE.STOCKREF IS NULL)) AND (GOKW3.dbo.LG_400_01_STLINE.STOCKREF <> 0) GROUP BY GOKW3.dbo.LG_400_01_STFICHE.TRCODE, MONTH(ISNULL(GOKW3.dbo.LG_400_01_INVOICE.DATE_, GOKW3.dbo.LG_400_01_STFICHE.DATE_)), YEAR(ISNULL(GOKW3.dbo.LG_400_01_INVOICE.DATE_, GOKW3.dbo.LG_400_01_STFICHE.DATE_)), GOKW3.dbo.LG_400_01_STFICHE.DATE_, GOKW3.dbo.LG_400_01_STFICHE.FICHENO, GOKW3.dbo.LG_400_01_STFICHE.DOCODE, GOKW3.dbo.LG_400_01_STFICHE.INVNO, GOKW3.dbo.LG_400_01_STFICHE.SPECODE, GOKW3.dbo.LG_400_01_STFICHE.CYPHCODE, GOKW3.dbo.LG_400_01_INVOICE.TRCODE, GOKW3.dbo.LG_400_01_INVOICE.DATE_, GOKW3.dbo.LG_400_01_INVOICE.FICHENO, GOKW3.dbo.LG_400_01_INVOICE.DOCODE, GOKW3.dbo.LG_400_01_INVOICE.SPECODE, GOKW3.dbo.LG_400_01_INVOICE.CYPHCODE, GOKW3.dbo.LG_400_CLCARD.CODE, GOKW3.dbo.LG_400_CLCARD.DEFINITION_, GOKW3.dbo.LG_400_CLCARD.SPECODE, GOKW3.dbo.LG_400_CLCARD.CYPHCODE, ISNULL(CASE GOKW3.dbo.LG_400_01_STLINE.LINETYPE WHEN 4 THEN GOKW3.dbo.LG_400_SRVCARD.DEFINITION_ ELSE GOKW3.dbo.LG_400_ITEMS.NAME END, GOKW3.dbo.LG_400_DECARDS.DEFINITION_), ISNULL(CASE GOKW3.dbo.LG_400_01_STLINE.LINETYPE WHEN 4 THEN GOKW3.dbo.LG_400_SRVCARD.CODE ELSE GOKW3.dbo.LG_400_ITEMS.CODE END, GOKW3.dbo.LG_400_DECARDS.CODE), GOKW3.dbo.LG_400_ITEMS.SPECODE, GOKW3.dbo.LG_400_ITEMS.CYPHCODE, GOKW3.dbo.LG_400_01_INVOICE.CLIENTREF, CASE GOKW3.dbo.LG_400_01_STLINE.TRCODE WHEN 13 THEN 0 WHEN 14 THEN 0 ELSE GOKW3.dbo.LG_400_01_STLINE.AMOUNT END, GOKW3.dbo.LG_400_01_STLINE.VAT, GOKW3.dbo.LG_400_01_STLINE.BILLED, GOKW3.dbo.LG_400_CLCARD.TAXOFFICE, GOKW3.dbo.LG_400_CLCARD.TAXNR, GOKW3.dbo.LG_400_01_STLINE.IOCODE, GOKW3.dbo.LG_400_ITEMS.STGRPCODE, GOKW3.dbo.LG_400_01_STLINE.CANCELLED, GOKW3.dbo.LG_400_01_STLINE.DECPRDIFF, GOKW3.dbo.LG_400_01_STLINE.TRCODE, GOKW3.dbo.HareketYon.YON, GOKW3.dbo.HareketYon.TUR_ACK, GOKW3.dbo.HareketYon.ANA_ISLEM, GOKW3.dbo.LG_400_01_INVOICE.TRADINGGRP, GOKW3.dbo.LG_400_MARK.CODE, GOKW3.dbo.LG_400_MARK.DESCR, ISNULL(LG_400_CLCARD_1.CODE, GOKW3.dbo.LG_400_CLCARD.CODE), ISNULL(LG_400_CLCARD_1.DEFINITION_, GOKW3.dbo.LG_400_CLCARD.DEFINITION_), GOKW3.dbo.LG_400_ITEMS.PRODUCERCODE HAVING      (GOKW3.dbo.LG_400_01_STFICHE.DATE_ >= CONVERT(DATETIME, '2014-01-01 00:00:00', 102)) AND (GOKW3.dbo.LG_400_01_STFICHE.DATE_ < CONVERT(DATETIME, '2014-01-02 00:00:00', 102)) AND (GOKW3.dbo.LG_400_01_INVOICE.DATE_ < CONVERT(DATETIME, '2014-01-02 00:00:00', 102)) AND (GOKW3.dbo.LG_400_01_STFICHE.TRCODE = 1 OR GOKW3.dbo.LG_400_01_STFICHE.TRCODE = 2 OR GOKW3.dbo.LG_400_01_STFICHE.TRCODE = 3 OR GOKW3.dbo.LG_400_01_STFICHE.TRCODE = 4 OR GOKW3.dbo.LG_400_01_STFICHE.TRCODE = 5 OR GOKW3.dbo.LG_400_01_STFICHE.TRCODE = 6 OR GOKW3.dbo.LG_400_01_STFICHE.TRCODE = 7 OR GOKW3.dbo.LG_400_01_STFICHE.TRCODE = 8 OR GOKW3.dbo.LG_400_01_STFICHE.TRCODE = 9 OR GOKW3.dbo.LG_400_01_STFICHE.TRCODE = 10) AND (GOKW3.dbo.LG_400_01_INVOICE.TRCODE = 1 OR GOKW3.dbo.LG_400_01_INVOICE.TRCODE = 2 OR GOKW3.dbo.LG_400_01_INVOICE.TRCODE = 3 OR GOKW3.dbo.LG_400_01_INVOICE.TRCODE = 4 OR GOKW3.dbo.LG_400_01_INVOICE.TRCODE = 5 OR GOKW3.dbo.LG_400_01_INVOICE.TRCODE = 6 OR GOKW3.dbo.LG_400_01_INVOICE.TRCODE = 7 OR GOKW3.dbo.LG_400_01_INVOICE.TRCODE = 8 OR GOKW3.dbo.LG_400_01_INVOICE.TRCODE = 9 OR GOKW3.dbo.LG_400_01_INVOICE.TRCODE = 10 OR GOKW3.dbo.LG_400_01_INVOICE.TRCODE = 13 OR GOKW3.dbo.LG_400_01_INVOICE.TRCODE = 14) AND (NOT (GOKW3.dbo.LG_400_CLCARD.CODE IS NULL)) AND (GOKW3.dbo.LG_400_01_INVOICE.DATE_ >= CONVERT(DATETIME, '2014-01-01 00:00:00', 102)) OR (GOKW3.dbo.LG_400_01_STFICHE.DATE_ IS NULL) AND (GOKW3.dbo.LG_400_01_INVOICE.DATE_ < CONVERT(DATETIME, '2014-01-02 00:00:00', 102)) AND (GOKW3.dbo.LG_400_01_STFICHE.TRCODE IS NULL) AND (GOKW3.dbo.LG_400_01_INVOICE.TRCODE = 1 OR GOKW3.dbo.LG_400_01_INVOICE.TRCODE = 2 OR GOKW3.dbo.LG_400_01_INVOICE.TRCODE = 3 OR GOKW3.dbo.LG_400_01_INVOICE.TRCODE = 4 OR GOKW3.dbo.LG_400_01_INVOICE.TRCODE = 5 OR GOKW3.dbo.LG_400_01_INVOICE.TRCODE = 6 OR GOKW3.dbo.LG_400_01_INVOICE.TRCODE = 7 OR GOKW3.dbo.LG_400_01_INVOICE.TRCODE = 8 OR GOKW3.dbo.LG_400_01_INVOICE.TRCODE = 9 OR GOKW3.dbo.LG_400_01_INVOICE.TRCODE = 10 OR GOKW3.dbo.LG_400_01_INVOICE.TRCODE = 13 OR GOKW3.dbo.LG_400_01_INVOICE.TRCODE = 14) AND (NOT (GOKW3.dbo.LG_400_CLCARD.CODE IS NULL)) AND (GOKW3.dbo.LG_400_01_INVOICE.DATE_ >= CONVERT(DATETIME, '2014-01-01 00:00:00', 102)) OR (GOKW3.dbo.LG_400_01_STFICHE.DATE_ >= CONVERT(DATETIME, '2014-01-01 00:00:00', 102)) AND (GOKW3.dbo.LG_400_01_STFICHE.DATE_ < CONVERT(DATETIME, '2014-01-02 00:00:00', 102)) AND (GOKW3.dbo.LG_400_01_INVOICE.DATE_ IS NULL) AND (GOKW3.dbo.LG_400_01_STFICHE.TRCODE = 1 OR GOKW3.dbo.LG_400_01_STFICHE.TRCODE = 2 OR GOKW3.dbo.LG_400_01_STFICHE.TRCODE = 3 OR GOKW3.dbo.LG_400_01_STFICHE.TRCODE = 4 OR GOKW3.dbo.LG_400_01_STFICHE.TRCODE = 5 OR GOKW3.dbo.LG_400_01_STFICHE.TRCODE = 6 OR GOKW3.dbo.LG_400_01_STFICHE.TRCODE = 7 OR GOKW3.dbo.LG_400_01_STFICHE.TRCODE = 8 OR GOKW3.dbo.LG_400_01_STFICHE.TRCODE = 9 OR GOKW3.dbo.LG_400_01_STFICHE.TRCODE = 10) AND (GOKW3.dbo.LG_400_01_INVOICE.TRCODE IS NULL) AND (NOT (GOKW3.dbo.LG_400_CLCARD.CODE IS NULL)) ORDER BY DATE__I, DATE__F) AS TABLO1", paramn, paramv, "Satis");

            gokw3satislar goklar = new gokw3satislar();
            goklar.Satislar = new List<gokw3satis>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                gokw3satis gok = new gokw3satis()
                {
                    IOCODE = Convert.ToInt16(dt.Rows[i]["IOCODE"]),
                    ANA_ISLEM = dt.Rows[i]["ANA_ISLEM"].ToString(),
                    TRCODE = Convert.ToInt16(dt.Rows[i]["TRCODE"]),
                    TUR_ACK = dt.Rows[i]["TUR_ACK"].ToString(),
                    YON = Convert.ToInt16(dt.Rows[i]["YON"]),
                    IPT = Convert.ToInt16(dt.Rows[i]["IPT"]),
                    FF = Convert.ToInt16(dt.Rows[i]["FF"]),
                    TRCODE_I = Convert.ToInt16(dt.Rows[i]["TRCODE_I"]),
                    YIL = Convert.ToInt32(dt.Rows[i]["YIL"]),
                    AY = Convert.ToInt32(dt.Rows[i]["AY"]),
                    DATE__I = Convert.ToDateTime(dt.Rows[i]["DATE__I"]),
                    FICHENO_I = dt.Rows[i]["FICHENO_I"].ToString(),
                    DOCODE_I = dt.Rows[i]["DOCODE_I"].ToString(),
                    INVNO_I = dt.Rows[i]["INVNO_I"].ToString(),
                    SPECODE_I = dt.Rows[i]["SPECODE_I"].ToString(),
                    CYPHCODE_I = dt.Rows[i]["CYPHCODE_I"].ToString(),
                    BILLED = Convert.ToInt16(dt.Rows[i]["BILLED"]),
                    TRCODE_F = Convert.ToInt16(dt.Rows[i]["TRCODE_F"]),
                    DATE__F = Convert.ToDateTime(dt.Rows[i]["DATE__F"]),
                    FICHENO_F = dt.Rows[i]["FICHENO_F"].ToString(),
                    DOCODE_F = dt.Rows[i]["DOCODE_F"].ToString(),
                    SPECODE_F = dt.Rows[i]["SPECODE_F"].ToString(),
                    CYPHCODE_F = dt.Rows[i]["CYPHCODE_F"].ToString(),
                    TRADINGGRP_F = dt.Rows[i]["TRADINGGRP_F"].ToString(),
                    CLIENTREF_F = Convert.ToInt32(dt.Rows[i]["CLIENTREF_F"]),
                    TAXOFFICE_C = dt.Rows[i]["TAXOFFICE_C"].ToString(),
                    TAXNR_C = dt.Rows[i]["TAXNR_C"].ToString(),
                    CODE_G = dt.Rows[i]["CODE_G"].ToString(),
                    DEFINITION_G = dt.Rows[i]["DEFINITION_G"].ToString(),
                    CODE_SB = dt.Rows[i]["CODE_SB"].ToString(),
                    DEFINITION_SB = dt.Rows[i]["DEFINITION_SB"].ToString(),
                    SPECODE_C = dt.Rows[i]["SPECODE_C"].ToString(),
                    CYPHCODE_C = dt.Rows[i]["CYPHCODE_C"].ToString(),
                    CODE_S = dt.Rows[i]["CODE_S"].ToString(),
                    DEFINITION__S = dt.Rows[i]["DEFINITION__S"].ToString(),
                    SPECODE_S = dt.Rows[i]["SPECODE_S"].ToString(),
                    CYPHCODE_S = dt.Rows[i]["CYPHCODE_S"].ToString(),
                    STGRPCODE_S = dt.Rows[i]["STGRPCODE_S"].ToString(),
                    PRODUCERCODE_S = dt.Rows[i]["PRODUCERCODE_S"].ToString(),
                    MARK_C = dt.Rows[i]["MARK_C"].ToString(),
                    MARK_A = dt.Rows[i]["MARK_A"].ToString(),
                    AMOUNT = Convert.ToDouble(dt.Rows[i]["AMOUNT"]),
                    PRICE = Convert.ToDouble(dt.Rows[i]["PRICE"]),
                    TOTAL = Convert.ToDouble(dt.Rows[i]["TOTAL"]),
                    DISTCOST = Convert.ToDouble(dt.Rows[i]["DISTCOST"]),
                    DISTDISC = Convert.ToDouble(dt.Rows[i]["DISTDISC"]),
                    DISTEXP = Convert.ToDouble(dt.Rows[i]["DISTEXP"]),
                    DISTPROM = Convert.ToDouble(dt.Rows[i]["DISTPROM"]),
                    DISCPER = Convert.ToDouble(dt.Rows[i]["DISCPER"]),
                    VAT = Convert.ToDouble(dt.Rows[i]["VAT"]),
                    VATAMNT = Convert.ToDouble(dt.Rows[i]["VATAMNT"]),
                    VATMATRAH = Convert.ToDouble(dt.Rows[i]["VATMATRAH"]),
                    NETKDV = Convert.ToDouble(dt.Rows[i]["NETKDV"])
                };
                goklar.Satislar.Add(gok);
            }


            XmlSerializerNamespaces xsn = new XmlSerializerNamespaces();
            xsn.Add("g", "http://base.google.com/ns/1.0");
            XmlSerializer MySerializer = new XmlSerializer(typeof(gokw3satislar), "http://www.w3.org/2005/Atom");

            TextWriter TW = new StringWriter();


            MySerializer.Serialize(TW, goklar, xsn);



            donendeger.LoadXml(TW.ToString());

            return donendeger;
        }
        private void EmusiadDoldur(DataTable dt, int i, Sultanlar.Class.Entry entry)
        {
            entry.id = Convert.ToInt32(dt.Rows[i]["Kod"]);
            entry.title = dt.Rows[i]["AltBaslik"].ToString();
            entry.brand = dt.Rows[i]["Marka"].ToString();
            entry.google_product_category = "";
            entry.quantity = 1;
            entry.condition = "new";
            entry.price = Convert.ToDouble(dt.Rows[i]["Fiyat"]) + " TRY";
            entry.link = "";
            entry.image_link = dt.Rows[i]["Resim"].ToString();
            entry.availability = Convert.ToInt32(dt.Rows[i]["Stoklar"]) > 0 ? "in stock" : "out of stock";
            entry.summary = "<![CDATA[ " + dt.Rows[i]["Aciklama"].ToString() + " ]]>";

            entry.emusiad = new Class.Emusiad();
            entry.emusiad.site_category = dt.Rows[i]["KategoriAdi1"].ToString();
            entry.emusiad.is_service = "yes";
            entry.emusiad.is_enabled = "yes";
            entry.emusiad.is_purchasable = "yes";
            entry.emusiad.is_onsale = "yes";
            entry.emusiad.special_price = Convert.ToDouble(dt.Rows[i]["Fiyat"]) + " TRY";
            entry.emusiad.reseller_price = Convert.ToDouble(dt.Rows[i]["Fiyat"]) + " TRY";
            entry.emusiad.tax_included = "yes";
            entry.emusiad.tax_rate = Math.Round(((100 + Convert.ToDouble(dt.Rows[i]["Kdv"])) / 100) - 1, 2);
            entry.emusiad.short_title = dt.Rows[i]["Baslik"].ToString();
            entry.emusiad.short_description = "<![CDATA[ " + dt.Rows[i]["Aciklama"].ToString() + " ]]>";
            entry.emusiad.seo_description = "";
            entry.emusiad.seo_keywords = dt.Rows[i]["AltBaslik"].ToString() + "," + dt.Rows[i]["KategoriAdi1"].ToString() + "," + dt.Rows[i]["Marka"].ToString();
        }
        /// <summary>
        /// 
        /// </summary>
        public XmlDocument Efatura(string Sifre, string VRGNO, string Baslangic, string Bitis)
        {
            XmlDocument donendeger = new XmlDocument();
            XmlNode xd = donendeger.CreateXmlDeclaration("1.0", "ISO-8859-9", "yes");
            donendeger.AppendChild(xd);



            if (Sifre != "morgen")
                return donendeger;



            DataTable dtFatNolar = new DataTable();
            //Sultanlar.DatabaseObject.Internet.Efatura.GetFATNOFATTARByGMREF(dtFatNolar, Convert.ToInt32(GMREF));
            Sultanlar.DatabaseObject.Internet.Efatura.GetFATNOFATTARByVRGNO(dtFatNolar, VRGNO, Convert.ToDateTime(Baslangic), Convert.ToDateTime(Bitis));

            if (dtFatNolar.Rows.Count > 75)
            {
                XmlNode xeh = donendeger.CreateElement("errors");
                donendeger.AppendChild(xeh);

                XmlElement xeh0 = donendeger.CreateElement("error");
                donendeger.DocumentElement.InsertAfter(xeh0, donendeger.DocumentElement.LastChild);

                XmlElement xeh1 = donendeger.CreateElement("errorType"); xeh1.InnerText = "0";
                xeh0.InsertAfter(xeh1, xeh0.LastChild);

                XmlElement xeh2 = donendeger.CreateElement("errorDescription"); xeh2.InnerText = "Fatura sayısı çok fazla, işlem uzun süreceğinden dolayı iptal edildi.";
                xeh0.InsertAfter(xeh2, xeh0.LastChild);

                return donendeger;
            }



            XmlNode xe = donendeger.CreateElement("e_fatura");
            donendeger.AppendChild(xe);

            XmlElement xe0 = donendeger.CreateElement("sirket"); xe0.InnerText = "SULTANLAR PAZARLAMA EV İHTİYAÇ MADDELERİ A.Ş.";
            donendeger.DocumentElement.InsertAfter(xe0, donendeger.DocumentElement.LastChild);

            XmlElement xe1 = donendeger.CreateElement("vergino"); xe1.InnerText = "7820046282";
            donendeger.DocumentElement.InsertAfter(xe1, donendeger.DocumentElement.LastChild);

            XmlElement xe2 = donendeger.CreateElement("email"); xe2.InnerText = "bilgi@sultanlar.com.tr";
            donendeger.DocumentElement.InsertAfter(xe2, donendeger.DocumentElement.LastChild);

            XmlElement xe3 = donendeger.CreateElement("hesapno"); xe3.InnerText = "3416200196";
            donendeger.DocumentElement.InsertAfter(xe3, donendeger.DocumentElement.LastChild);

            XmlElement xe4 = donendeger.CreateElement("versiyon"); xe4.InnerText = "1.0.0";
            donendeger.DocumentElement.InsertAfter(xe4, donendeger.DocumentElement.LastChild);



            for (int j = 0; j < dtFatNolar.Rows.Count; j++)
            {
                DataTable dt = new DataTable();
                Sultanlar.DatabaseObject.Internet.Efatura.GetObjectByFATNO(dt, dtFatNolar.Rows[j]["FAT NO"].ToString());

                double toplamtutar = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                    toplamtutar += Convert.ToDouble(dt.Rows[i]["NET+KDV T"]);




                XmlNode xe5 = donendeger.CreateElement("fatura");
                donendeger.DocumentElement.InsertAfter(xe5, donendeger.DocumentElement.LastChild);

                XmlElement xe6 = donendeger.CreateElement("gln"); xe6.InnerText = "8691014000012";
                xe5.InsertAfter(xe6, xe5.LastChild);

                XmlElement xe7 = donendeger.CreateElement("sayfano"); xe7.InnerText = dt.Rows[0]["FAT NO"].ToString();
                xe5.InsertAfter(xe7, xe5.LastChild);

                XmlElement xe8 = donendeger.CreateElement("tarih"); xe8.InnerText = dt.Rows[0]["FAT TAR"].ToString().Replace(".", "/");
                xe5.InsertAfter(xe8, xe5.LastChild);

                XmlElement xe9 = donendeger.CreateElement("faturatipi"); xe9.InnerText = "NORMAL";
                xe5.InsertAfter(xe9, xe5.LastChild);

                XmlElement xe10 = donendeger.CreateElement("faturahazirlanmayeri"); xe10.InnerText = "SULTANLAR DEPO";
                xe5.InsertAfter(xe10, xe5.LastChild);

                XmlElement xe11 = donendeger.CreateElement("yuvarlama"); xe11.InnerText = "0";
                xe5.InsertAfter(xe11, xe5.LastChild);

                XmlElement xe12 = donendeger.CreateElement("faturaturu"); xe12.InnerText = "NORMAL";
                xe5.InsertAfter(xe12, xe5.LastChild);

                XmlNode xe13 = donendeger.CreateElement("vadeseldagilim");
                xe5.InsertAfter(xe13, xe5.LastChild);

                XmlElement xe14 = donendeger.CreateElement("odemetarih"); xe14.InnerText = dt.Rows[0]["FAT VD"].ToString().Replace(".", "/");
                xe13.InsertAfter(xe14, xe13.LastChild);

                XmlElement xe15 = donendeger.CreateElement("vadeseltoplam"); xe15.InnerText = toplamtutar.ToString("N2").Replace(".", "").Replace(",", ".");
                xe13.InsertAfter(xe15, xe13.LastChild);

                XmlElement xe16 = donendeger.CreateElement("mfiskonto"); xe16.InnerText = "0";
                xe13.InsertAfter(xe16, xe13.LastChild);

                XmlElement xe17 = donendeger.CreateElement("geneliskonto"); xe17.InnerText = "0";
                xe13.InsertAfter(xe17, xe13.LastChild);

                XmlElement xe18 = donendeger.CreateElement("taksitsayisi"); xe18.InnerText = "0";
                xe13.InsertAfter(xe18, xe13.LastChild);

                XmlElement xe19 = donendeger.CreateElement("taksitaralik"); xe19.InnerText = "0";
                xe13.InsertAfter(xe19, xe13.LastChild);

                XmlNode xe20 = donendeger.CreateElement("odemeplani");
                xe13.InsertAfter(xe20, xe13.LastChild);

                XmlNode xe21 = donendeger.CreateElement("vade");
                xe20.InsertAfter(xe21, xe20.LastChild);

                XmlElement xe22 = donendeger.CreateElement("vadetarihi"); xe22.InnerText = dt.Rows[0]["FAT VD"].ToString().Replace(".", "/");
                xe21.InsertAfter(xe22, xe21.LastChild);

                XmlElement xe23 = donendeger.CreateElement("vadetutari"); xe23.InnerText = toplamtutar.ToString("N2").Replace(".", "").Replace(",", ".");
                xe21.InsertAfter(xe23, xe21.LastChild);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    XmlNode xe24 = donendeger.CreateElement("ilac");
                    xe13.InsertAfter(xe24, xe13.LastChild);

                    XmlElement xe25 = donendeger.CreateElement("isim"); xe25.InnerText = dt.Rows[i]["MALZEME"].ToString();
                    xe24.InsertAfter(xe25, xe24.LastChild);

                    XmlElement xe26 = donendeger.CreateElement("barkodu"); xe26.InnerText = dt.Rows[i]["BARCODE"].ToString();
                    xe24.InsertAfter(xe26, xe24.LastChild);

                    XmlElement xe27 = donendeger.CreateElement("ilackodu");
                    xe24.InsertAfter(xe27, xe24.LastChild);

                    XmlElement xe28 = donendeger.CreateElement("etiketfiyati"); xe28.InnerText = (Convert.ToDouble(dt.Rows[i]["BRUT T"]) / Convert.ToDouble(dt.Rows[i]["AD T"])).ToString("N2").Replace(".", "").Replace(",", ".");
                    xe24.InsertAfter(xe28, xe24.LastChild);

                    XmlElement xe29 = donendeger.CreateElement("depocufiyati"); xe29.InnerText = (Convert.ToDouble(dt.Rows[i]["BRUT T"]) / Convert.ToDouble(dt.Rows[i]["AD T"])).ToString("N2").Replace(".", "").Replace(",", ".");
                    xe24.InsertAfter(xe29, xe24.LastChild);

                    XmlElement xe30 = donendeger.CreateElement("eczacifiyati"); xe30.InnerText = (Convert.ToDouble(dt.Rows[i]["BRUT T"]) / Convert.ToDouble(dt.Rows[i]["AD T"])).ToString("N2").Replace(".", "").Replace(",", ".");
                    xe24.InsertAfter(xe30, xe24.LastChild);

                    XmlElement xe31 = donendeger.CreateElement("miktar"); xe31.InnerText = dt.Rows[i]["AD T"].ToString();
                    xe24.InsertAfter(xe31, xe24.LastChild);

                    XmlElement xe32 = donendeger.CreateElement("mf");
                    xe24.InsertAfter(xe32, xe24.LastChild);

                    XmlElement xe33 = donendeger.CreateElement("iskontoorani1"); xe33.InnerText = dt.Rows[i]["ISK1"].ToString() == "" ? "0" : dt.Rows[i]["ISK1"].ToString();
                    xe24.InsertAfter(xe33, xe24.LastChild);

                    XmlElement xe34 = donendeger.CreateElement("iskontoorani2"); xe34.InnerText = dt.Rows[i]["ISK2"].ToString() == "" ? "0" : dt.Rows[i]["ISK2"].ToString();
                    xe24.InsertAfter(xe34, xe24.LastChild);

                    XmlElement xe35 = donendeger.CreateElement("iskontoorani3"); xe35.InnerText = dt.Rows[i]["ISK3"].ToString() == "" ? "0" : dt.Rows[i]["ISK3"].ToString();
                    xe24.InsertAfter(xe35, xe24.LastChild);

                    XmlElement xe36 = donendeger.CreateElement("iskontoorani4"); xe36.InnerText = dt.Rows[i]["ISK4"].ToString() == "" ? "0" : dt.Rows[i]["ISK4"].ToString();
                    xe24.InsertAfter(xe36, xe24.LastChild);

                    XmlElement xe37 = donendeger.CreateElement("eczkarorani");
                    xe24.InsertAfter(xe37, xe24.LastChild);

                    XmlElement xe38 = donendeger.CreateElement("eczkartutari");
                    xe24.InsertAfter(xe38, xe24.LastChild);

                    XmlElement xe39 = donendeger.CreateElement("ithal");
                    xe24.InsertAfter(xe39, xe24.LastChild);

                    XmlElement xe40 = donendeger.CreateElement("kdvdus");
                    xe24.InsertAfter(xe40, xe24.LastChild);

                    XmlElement xe41 = donendeger.CreateElement("kdv"); xe41.InnerText = dt.Rows[i]["KDV"].ToString();
                    xe24.InsertAfter(xe41, xe24.LastChild);

                    XmlElement xe42 = donendeger.CreateElement("aliskdv"); xe42.InnerText = dt.Rows[i]["KDV"].ToString();
                    xe24.InsertAfter(xe42, xe24.LastChild);

                    XmlElement xe43 = donendeger.CreateElement("ilactipi"); xe43.InnerText = "ITRIYAT";
                    xe24.InsertAfter(xe43, xe24.LastChild);

                    XmlElement xe44 = donendeger.CreateElement("miad");
                    xe24.InsertAfter(xe44, xe24.LastChild);
                }
            }

            return donendeger;
        }
        /// <summary>
        /// 
        /// </summary>
        public XmlDocument EfaturaPost1(XmlDocument icerik)
        {
            XmlDocument donendeger = new XmlDocument();
            XmlNode xd = donendeger.CreateXmlDeclaration("1.0", "ISO-8859-9", "yes");
            donendeger.AppendChild(xd);



            if (icerik.ChildNodes.Count > 30)
            {
                XmlNode xeh = donendeger.CreateElement("errors");
                donendeger.AppendChild(xeh);

                XmlElement xeh0 = donendeger.CreateElement("error");
                donendeger.DocumentElement.InsertAfter(xeh0, donendeger.DocumentElement.LastChild);

                XmlElement xeh1 = donendeger.CreateElement("errorType"); xeh1.InnerText = "0";
                xeh0.InsertAfter(xeh1, xeh0.LastChild);

                XmlElement xeh2 = donendeger.CreateElement("errorDescription"); xeh2.InnerText = "Fatura sayısı çok fazla, işlem uzun süreceğinden dolayı iptal edildi.";
                xeh0.InsertAfter(xeh2, xeh0.LastChild);

                return donendeger;
            }



            XmlNode xe = donendeger.CreateElement("e_fatura");
            donendeger.AppendChild(xe);

            XmlElement xe0 = donendeger.CreateElement("sirket"); xe0.InnerText = "SULTANLAR PAZARLAMA EV İHTİYAÇ MADDELERİ A.Ş.";
            donendeger.DocumentElement.InsertAfter(xe0, donendeger.DocumentElement.LastChild);

            XmlElement xe1 = donendeger.CreateElement("vergino"); xe1.InnerText = "7820046282";
            donendeger.DocumentElement.InsertAfter(xe1, donendeger.DocumentElement.LastChild);

            XmlElement xe2 = donendeger.CreateElement("email"); xe2.InnerText = "bilgi@sultanlar.com.tr";
            donendeger.DocumentElement.InsertAfter(xe2, donendeger.DocumentElement.LastChild);

            XmlElement xe3 = donendeger.CreateElement("hesapno"); xe3.InnerText = "3416200196";
            donendeger.DocumentElement.InsertAfter(xe3, donendeger.DocumentElement.LastChild);

            XmlElement xe4 = donendeger.CreateElement("versiyon"); xe4.InnerText = "1.0.0";
            donendeger.DocumentElement.InsertAfter(xe4, donendeger.DocumentElement.LastChild);



            for (int j = 0; j < icerik.ChildNodes.Count; j++)
            {
                DataTable dt = new DataTable();
                Sultanlar.DatabaseObject.Internet.Efatura.GetObjectByFATNO(dt, icerik.ChildNodes[j].InnerText);

                double toplamtutar = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                    toplamtutar += Convert.ToDouble(dt.Rows[i]["NET+KDV T"]);




                XmlNode xe5 = donendeger.CreateElement("fatura");
                donendeger.DocumentElement.InsertAfter(xe5, donendeger.DocumentElement.LastChild);

                XmlElement xe6 = donendeger.CreateElement("gln"); xe6.InnerText = "8691014000012";
                xe5.InsertAfter(xe6, xe5.LastChild);

                XmlElement xe7 = donendeger.CreateElement("sayfano"); xe7.InnerText = dt.Rows[0]["FAT NO"].ToString();
                xe5.InsertAfter(xe7, xe5.LastChild);

                XmlElement xe8 = donendeger.CreateElement("tarih"); xe8.InnerText = dt.Rows[0]["FAT TAR"].ToString().Replace(".", "/");
                xe5.InsertAfter(xe8, xe5.LastChild);

                XmlElement xe9 = donendeger.CreateElement("faturatipi"); xe9.InnerText = "NORMAL";
                xe5.InsertAfter(xe9, xe5.LastChild);

                XmlElement xe10 = donendeger.CreateElement("faturahazirlanmayeri"); xe10.InnerText = "SULTANLAR DEPO";
                xe5.InsertAfter(xe10, xe5.LastChild);

                XmlElement xe11 = donendeger.CreateElement("yuvarlama"); xe11.InnerText = "0";
                xe5.InsertAfter(xe11, xe5.LastChild);

                XmlElement xe12 = donendeger.CreateElement("faturaturu"); xe12.InnerText = "NORMAL";
                xe5.InsertAfter(xe12, xe5.LastChild);

                XmlNode xe13 = donendeger.CreateElement("vadeseldagilim");
                xe5.InsertAfter(xe13, xe5.LastChild);

                XmlElement xe14 = donendeger.CreateElement("odemetarih"); xe14.InnerText = dt.Rows[0]["FAT VD"].ToString().Replace(".", "/");
                xe13.InsertAfter(xe14, xe13.LastChild);

                XmlElement xe15 = donendeger.CreateElement("vadeseltoplam"); xe15.InnerText = toplamtutar.ToString("N2").Replace(".", "").Replace(",", ".");
                xe13.InsertAfter(xe15, xe13.LastChild);

                XmlElement xe16 = donendeger.CreateElement("mfiskonto"); xe16.InnerText = "0";
                xe13.InsertAfter(xe16, xe13.LastChild);

                XmlElement xe17 = donendeger.CreateElement("geneliskonto"); xe17.InnerText = "0";
                xe13.InsertAfter(xe17, xe13.LastChild);

                XmlElement xe18 = donendeger.CreateElement("taksitsayisi"); xe18.InnerText = "0";
                xe13.InsertAfter(xe18, xe13.LastChild);

                XmlElement xe19 = donendeger.CreateElement("taksitaralik"); xe19.InnerText = "0";
                xe13.InsertAfter(xe19, xe13.LastChild);

                XmlNode xe20 = donendeger.CreateElement("odemeplani");
                xe13.InsertAfter(xe20, xe13.LastChild);

                XmlNode xe21 = donendeger.CreateElement("vade");
                xe20.InsertAfter(xe21, xe20.LastChild);

                XmlElement xe22 = donendeger.CreateElement("vadetarihi"); xe22.InnerText = dt.Rows[0]["FAT VD"].ToString().Replace(".", "/");
                xe21.InsertAfter(xe22, xe21.LastChild);

                XmlElement xe23 = donendeger.CreateElement("vadetutari"); xe23.InnerText = toplamtutar.ToString("N2").Replace(".", "").Replace(",", ".");
                xe21.InsertAfter(xe23, xe21.LastChild);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    XmlNode xe24 = donendeger.CreateElement("ilac");
                    xe13.InsertAfter(xe24, xe13.LastChild);

                    XmlElement xe25 = donendeger.CreateElement("isim"); xe25.InnerText = dt.Rows[i]["MALZEME"].ToString();
                    xe24.InsertAfter(xe25, xe24.LastChild);

                    XmlElement xe26 = donendeger.CreateElement("barkodu"); xe26.InnerText = dt.Rows[i]["BARCODE"].ToString();
                    xe24.InsertAfter(xe26, xe24.LastChild);

                    XmlElement xe27 = donendeger.CreateElement("ilackodu");
                    xe24.InsertAfter(xe27, xe24.LastChild);

                    XmlElement xe28 = donendeger.CreateElement("etiketfiyati"); xe28.InnerText = (Convert.ToDouble(dt.Rows[i]["BRUT T"]) / Convert.ToDouble(dt.Rows[i]["AD T"])).ToString("N2").Replace(".", "").Replace(",", ".");
                    xe24.InsertAfter(xe28, xe24.LastChild);

                    XmlElement xe29 = donendeger.CreateElement("depocufiyati"); xe29.InnerText = (Convert.ToDouble(dt.Rows[i]["BRUT T"]) / Convert.ToDouble(dt.Rows[i]["AD T"])).ToString("N2").Replace(".", "").Replace(",", ".");
                    xe24.InsertAfter(xe29, xe24.LastChild);

                    XmlElement xe30 = donendeger.CreateElement("eczacifiyati"); xe30.InnerText = (Convert.ToDouble(dt.Rows[i]["BRUT T"]) / Convert.ToDouble(dt.Rows[i]["AD T"])).ToString("N2").Replace(".", "").Replace(",", ".");
                    xe24.InsertAfter(xe30, xe24.LastChild);

                    XmlElement xe31 = donendeger.CreateElement("miktar"); xe31.InnerText = dt.Rows[i]["AD T"].ToString();
                    xe24.InsertAfter(xe31, xe24.LastChild);

                    XmlElement xe32 = donendeger.CreateElement("mf");
                    xe24.InsertAfter(xe32, xe24.LastChild);

                    XmlElement xe33 = donendeger.CreateElement("iskontoorani1"); xe33.InnerText = dt.Rows[i]["ISK1"].ToString() == "" ? "0" : dt.Rows[i]["ISK1"].ToString();
                    xe24.InsertAfter(xe33, xe24.LastChild);

                    XmlElement xe34 = donendeger.CreateElement("iskontoorani2"); xe34.InnerText = dt.Rows[i]["ISK2"].ToString() == "" ? "0" : dt.Rows[i]["ISK2"].ToString();
                    xe24.InsertAfter(xe34, xe24.LastChild);

                    XmlElement xe35 = donendeger.CreateElement("iskontoorani3"); xe35.InnerText = dt.Rows[i]["ISK3"].ToString() == "" ? "0" : dt.Rows[i]["ISK3"].ToString();
                    xe24.InsertAfter(xe35, xe24.LastChild);

                    XmlElement xe36 = donendeger.CreateElement("iskontoorani4"); xe36.InnerText = dt.Rows[i]["ISK4"].ToString() == "" ? "0" : dt.Rows[i]["ISK4"].ToString();
                    xe24.InsertAfter(xe36, xe24.LastChild);

                    XmlElement xe37 = donendeger.CreateElement("eczkarorani");
                    xe24.InsertAfter(xe37, xe24.LastChild);

                    XmlElement xe38 = donendeger.CreateElement("eczkartutari");
                    xe24.InsertAfter(xe38, xe24.LastChild);

                    XmlElement xe39 = donendeger.CreateElement("ithal");
                    xe24.InsertAfter(xe39, xe24.LastChild);

                    XmlElement xe40 = donendeger.CreateElement("kdvdus");
                    xe24.InsertAfter(xe40, xe24.LastChild);

                    XmlElement xe41 = donendeger.CreateElement("kdv"); xe41.InnerText = dt.Rows[i]["KDV"].ToString();
                    xe24.InsertAfter(xe41, xe24.LastChild);

                    XmlElement xe42 = donendeger.CreateElement("aliskdv"); xe42.InnerText = dt.Rows[i]["KDV"].ToString();
                    xe24.InsertAfter(xe42, xe24.LastChild);

                    XmlElement xe43 = donendeger.CreateElement("ilactipi"); xe43.InnerText = "ITRIYAT";
                    xe24.InsertAfter(xe43, xe24.LastChild);

                    XmlElement xe44 = donendeger.CreateElement("miad");
                    xe24.InsertAfter(xe44, xe24.LastChild);
                }
            }

            return donendeger;
        }
        /// <summary>
        /// 
        /// </summary>
        public XmlDocument EfaturaPost(XmlDocument icerik)
        {
            XmlNode firmakodu = icerik.SelectSingleNode("//GetXmlByDateEczanem/FIRMA_KODU/text()");
            XmlNode kadi = icerik.SelectSingleNode("//GetXmlByDateEczanem/KULLANICI_ADI/text()");
            XmlNode sifre = icerik.SelectSingleNode("//GetXmlByDateEczanem/KULLANICI_SIFRE/text()");
            XmlNode baslangic = icerik.SelectSingleNode("//GetXmlByDateEczanem/BAS_TARIH/text()");
            XmlNode bitis = icerik.SelectSingleNode("//GetXmlByDateEczanem/BIT_TARIH/text()");



            XmlDocument donendeger = new XmlDocument();
            XmlNode xd = donendeger.CreateXmlDeclaration("1.0", "ISO-8859-9", "yes");
            donendeger.AppendChild(xd);



            int GMREF = Musteriler.GetGMREFByEpostaSifre(kadi.Value, sifre.Value);

            if (GMREF == 0) // kadi şifre hatalı ise
            {
                XmlNode xeh = donendeger.CreateElement("errors");
                donendeger.AppendChild(xeh);

                XmlElement xeh0 = donendeger.CreateElement("error");
                donendeger.DocumentElement.InsertAfter(xeh0, donendeger.DocumentElement.LastChild);

                XmlElement xeh1 = donendeger.CreateElement("errorType"); xeh1.InnerText = "1";
                xeh0.InsertAfter(xeh1, xeh0.LastChild);

                XmlElement xeh2 = donendeger.CreateElement("errorDescription"); xeh2.InnerText = "Kullanıcı girişi doğrulanamadı.";
                xeh0.InsertAfter(xeh2, xeh0.LastChild);

                return donendeger;
            }



            if (WebGenel.WebSatisRaporCalisiyorMu()) // satış raporu güncelleniyorsa
            {
                XmlNode xeh = donendeger.CreateElement("errors");
                donendeger.AppendChild(xeh);

                XmlElement xeh0 = donendeger.CreateElement("error");
                donendeger.DocumentElement.InsertAfter(xeh0, donendeger.DocumentElement.LastChild);

                XmlElement xeh1 = donendeger.CreateElement("errorType"); xeh1.InnerText = "1";
                xeh0.InsertAfter(xeh1, xeh0.LastChild);

                XmlElement xeh2 = donendeger.CreateElement("errorDescription"); xeh2.InnerText = "Sistem güncellendiğinden e-fatura alınamadı, lütfen bir kaç dakika sonra tekrar deneyiniz.";
                xeh0.InsertAfter(xeh2, xeh0.LastChild);

                return donendeger;
            }



            DataTable dtFatNolar = new DataTable();
            Sultanlar.DatabaseObject.Internet.Efatura.GetFATNOFATTARByGMREF(dtFatNolar, GMREF, Convert.ToDateTime(baslangic.Value), Convert.ToDateTime(bitis.Value));

            if (dtFatNolar.Rows.Count > 75) // fatura sayısı 75'ten fazla ise
            {
                XmlNode xeh = donendeger.CreateElement("errors");
                donendeger.AppendChild(xeh);

                XmlElement xeh0 = donendeger.CreateElement("error");
                donendeger.DocumentElement.InsertAfter(xeh0, donendeger.DocumentElement.LastChild);

                XmlElement xeh1 = donendeger.CreateElement("errorType"); xeh1.InnerText = "0";
                xeh0.InsertAfter(xeh1, xeh0.LastChild);

                XmlElement xeh2 = donendeger.CreateElement("errorDescription"); xeh2.InnerText = "Fatura sayısı 75 adetten daha fazla, işlem çok uzun süreceğinden dolayı iptal edildi.";
                xeh0.InsertAfter(xeh2, xeh0.LastChild);

                return donendeger;
            }



            XmlNode xe = donendeger.CreateElement("e_fatura");
            donendeger.AppendChild(xe);

            XmlElement xe0 = donendeger.CreateElement("sirket"); xe0.InnerText = "SULTANLAR PAZARLAMA EV İHTİYAÇ MADDELERİ A.Ş.";
            donendeger.DocumentElement.InsertAfter(xe0, donendeger.DocumentElement.LastChild);

            XmlElement xe1 = donendeger.CreateElement("vergino"); xe1.InnerText = "7820046282";
            donendeger.DocumentElement.InsertAfter(xe1, donendeger.DocumentElement.LastChild);

            XmlElement xe2 = donendeger.CreateElement("email"); xe2.InnerText = "bilgi@sultanlar.com.tr";
            donendeger.DocumentElement.InsertAfter(xe2, donendeger.DocumentElement.LastChild);

            XmlElement xe3 = donendeger.CreateElement("hesapno"); xe3.InnerText = "3416200196";
            donendeger.DocumentElement.InsertAfter(xe3, donendeger.DocumentElement.LastChild);

            XmlElement xe4 = donendeger.CreateElement("versiyon"); xe4.InnerText = "1.0.0";
            donendeger.DocumentElement.InsertAfter(xe4, donendeger.DocumentElement.LastChild);



            for (int j = 0; j < dtFatNolar.Rows.Count; j++)
            {
                DataTable dt = new DataTable();
                Sultanlar.DatabaseObject.Internet.Efatura.GetObjectByFATNO(dt, dtFatNolar.Rows[j]["FAT NO"].ToString());

                double toplamtutar = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                    toplamtutar += Convert.ToDouble(dt.Rows[i]["NET+KDV T"]);




                XmlNode xe5 = donendeger.CreateElement("fatura");
                donendeger.DocumentElement.InsertAfter(xe5, donendeger.DocumentElement.LastChild);

                XmlElement xe6 = donendeger.CreateElement("gln"); xe6.InnerText = "8691014000012";
                xe5.InsertAfter(xe6, xe5.LastChild);

                XmlElement xe7 = donendeger.CreateElement("sayfano"); xe7.InnerText = dt.Rows[0]["FAT NO"].ToString();
                xe5.InsertAfter(xe7, xe5.LastChild);

                XmlElement xe8 = donendeger.CreateElement("tarih"); xe8.InnerText = dt.Rows[0]["FAT TAR"].ToString().Replace(".", "/");
                xe5.InsertAfter(xe8, xe5.LastChild);

                XmlElement xe9 = donendeger.CreateElement("faturatipi"); xe9.InnerText = "NORMAL";
                xe5.InsertAfter(xe9, xe5.LastChild);

                XmlElement xe10 = donendeger.CreateElement("faturahazirlanmayeri"); xe10.InnerText = "SULTANLAR DEPO";
                xe5.InsertAfter(xe10, xe5.LastChild);

                XmlElement xe11 = donendeger.CreateElement("yuvarlama"); xe11.InnerText = "0";
                xe5.InsertAfter(xe11, xe5.LastChild);

                XmlElement xe12 = donendeger.CreateElement("faturaturu"); xe12.InnerText = "NORMAL";
                xe5.InsertAfter(xe12, xe5.LastChild);

                XmlNode xe13 = donendeger.CreateElement("vadeseldagilim");
                xe5.InsertAfter(xe13, xe5.LastChild);

                XmlElement xe14 = donendeger.CreateElement("odemetarih"); xe14.InnerText = dt.Rows[0]["FAT VD"].ToString().Replace(".", "/");
                xe13.InsertAfter(xe14, xe13.LastChild);

                XmlElement xe15 = donendeger.CreateElement("vadeseltoplam"); xe15.InnerText = toplamtutar.ToString("N2").Replace(".", "").Replace(",", ".");
                xe13.InsertAfter(xe15, xe13.LastChild);

                XmlElement xe16 = donendeger.CreateElement("mfiskonto"); xe16.InnerText = "0";
                xe13.InsertAfter(xe16, xe13.LastChild);

                XmlElement xe17 = donendeger.CreateElement("geneliskonto"); xe17.InnerText = "0";
                xe13.InsertAfter(xe17, xe13.LastChild);

                XmlElement xe18 = donendeger.CreateElement("taksitsayisi"); xe18.InnerText = "0";
                xe13.InsertAfter(xe18, xe13.LastChild);

                XmlElement xe19 = donendeger.CreateElement("taksitaralik"); xe19.InnerText = "0";
                xe13.InsertAfter(xe19, xe13.LastChild);

                XmlNode xe20 = donendeger.CreateElement("odemeplani");
                xe13.InsertAfter(xe20, xe13.LastChild);

                XmlNode xe21 = donendeger.CreateElement("vade");
                xe20.InsertAfter(xe21, xe20.LastChild);

                XmlElement xe22 = donendeger.CreateElement("vadetarihi"); xe22.InnerText = dt.Rows[0]["FAT VD"].ToString().Replace(".", "/");
                xe21.InsertAfter(xe22, xe21.LastChild);

                XmlElement xe23 = donendeger.CreateElement("vadetutari"); xe23.InnerText = toplamtutar.ToString("N2").Replace(".", "").Replace(",", ".");
                xe21.InsertAfter(xe23, xe21.LastChild);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    XmlNode xe24 = donendeger.CreateElement("ilac");
                    xe13.InsertAfter(xe24, xe13.LastChild);

                    XmlElement xe25 = donendeger.CreateElement("isim"); xe25.InnerText = dt.Rows[i]["MALZEME"].ToString();
                    xe24.InsertAfter(xe25, xe24.LastChild);

                    XmlElement xe26 = donendeger.CreateElement("barkodu"); xe26.InnerText = dt.Rows[i]["BARCODE"].ToString();
                    xe24.InsertAfter(xe26, xe24.LastChild);

                    XmlElement xe27 = donendeger.CreateElement("ilackodu");
                    xe24.InsertAfter(xe27, xe24.LastChild);

                    XmlElement xe28 = donendeger.CreateElement("etiketfiyati"); xe28.InnerText = (Convert.ToDouble(dt.Rows[i]["BRUT T"]) / Convert.ToDouble(dt.Rows[i]["AD T"])).ToString("N2").Replace(".", "").Replace(",", ".");
                    xe24.InsertAfter(xe28, xe24.LastChild);

                    XmlElement xe29 = donendeger.CreateElement("depocufiyati"); xe29.InnerText = (Convert.ToDouble(dt.Rows[i]["BRUT T"]) / Convert.ToDouble(dt.Rows[i]["AD T"])).ToString("N2").Replace(".", "").Replace(",", ".");
                    xe24.InsertAfter(xe29, xe24.LastChild);

                    XmlElement xe30 = donendeger.CreateElement("eczacifiyati"); xe30.InnerText = (Convert.ToDouble(dt.Rows[i]["BRUT T"]) / Convert.ToDouble(dt.Rows[i]["AD T"])).ToString("N2").Replace(".", "").Replace(",", ".");
                    xe24.InsertAfter(xe30, xe24.LastChild);

                    XmlElement xe31 = donendeger.CreateElement("miktar"); xe31.InnerText = dt.Rows[i]["AD T"].ToString();
                    xe24.InsertAfter(xe31, xe24.LastChild);

                    XmlElement xe32 = donendeger.CreateElement("mf");
                    xe24.InsertAfter(xe32, xe24.LastChild);

                    XmlElement xe33 = donendeger.CreateElement("iskontoorani1"); xe33.InnerText = dt.Rows[i]["ISK1"].ToString() == "" ? "0" : dt.Rows[i]["ISK1"].ToString();
                    xe24.InsertAfter(xe33, xe24.LastChild);

                    XmlElement xe34 = donendeger.CreateElement("iskontoorani2"); xe34.InnerText = dt.Rows[i]["ISK2"].ToString() == "" ? "0" : dt.Rows[i]["ISK2"].ToString();
                    xe24.InsertAfter(xe34, xe24.LastChild);

                    XmlElement xe35 = donendeger.CreateElement("iskontoorani3"); xe35.InnerText = dt.Rows[i]["ISK3"].ToString() == "" ? "0" : dt.Rows[i]["ISK3"].ToString();
                    xe24.InsertAfter(xe35, xe24.LastChild);

                    XmlElement xe36 = donendeger.CreateElement("iskontoorani4"); xe36.InnerText = dt.Rows[i]["ISK4"].ToString() == "" ? "0" : dt.Rows[i]["ISK4"].ToString();
                    xe24.InsertAfter(xe36, xe24.LastChild);

                    XmlElement xe37 = donendeger.CreateElement("eczkarorani");
                    xe24.InsertAfter(xe37, xe24.LastChild);

                    XmlElement xe38 = donendeger.CreateElement("eczkartutari");
                    xe24.InsertAfter(xe38, xe24.LastChild);

                    XmlElement xe39 = donendeger.CreateElement("ithal");
                    xe24.InsertAfter(xe39, xe24.LastChild);

                    XmlElement xe40 = donendeger.CreateElement("kdvdus");
                    xe24.InsertAfter(xe40, xe24.LastChild);

                    XmlElement xe41 = donendeger.CreateElement("kdv"); xe41.InnerText = dt.Rows[i]["KDV"].ToString();
                    xe24.InsertAfter(xe41, xe24.LastChild);

                    XmlElement xe42 = donendeger.CreateElement("aliskdv"); xe42.InnerText = dt.Rows[i]["KDV"].ToString();
                    xe24.InsertAfter(xe42, xe24.LastChild);

                    XmlElement xe43 = donendeger.CreateElement("ilactipi"); xe43.InnerText = "ITRIYAT";
                    xe24.InsertAfter(xe43, xe24.LastChild);

                    XmlElement xe44 = donendeger.CreateElement("miad");
                    xe24.InsertAfter(xe44, xe24.LastChild);
                }
            }

            return donendeger;
        }
        /// <summary>
        /// 
        /// </summary>
        public SDEpictures SDEpicturePost(SDEpictures icerik)
        {
            RutResim rr = new RutResim(icerik.smref, icerik.tip, icerik.musteri, icerik.tur, icerik.rut, icerik.ziyaret, DateTime.Now,
                Convert.FromBase64String(icerik.resim), icerik.aciklama, icerik.not);
            rr.DoInsert();
            icerik.resim = "";
            return icerik;
        }

        public List<Salesmen> DenemePost(List<Salesmen> icerik)
        {
            return icerik;
        }
        //
        //
        //
        //
        // JSON:
        //
        /// <summary>
        /// Bütün satış temsilcileri. 
        /// düzen=salesman_ref:::salesman
        /// </summary>
        public List<Salesmen> JSONGetSalesmen(string Sifre)
        {
            List<Salesmen> donendeger = new List<Salesmen>();

            if (Sifre == "morgen")
            {
                DataTable dt = new DataTable();
                SatisTemsilcileri.GetObjectsWS(dt);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    donendeger.Add(new Salesmen(Convert.ToInt32(dt.Rows[i]["salesman_ref"]), dt.Rows[i]["salesman"].ToString()));
                }
            }
            else
            {
                donendeger.Add(new Salesmen(0, ""));
            }

            return donendeger;
        }
        /// <summary>
        /// Bütün müşteri kayıtları. 
        /// düzen=salesman_ref:::substation_ref:::client:::substation
        /// </summary>
        public List<Clients> JSONGetClients(string Sifre)
        {
            List<Clients> donendeger = new List<Clients>();

            if (Sifre == "morgen")
            {
                DataTable dt = new DataTable();
                CariHesaplar.GetObjectsWS(dt, true);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    donendeger.Add(new Clients(Convert.ToInt32(dt.Rows[i]["substation_ref"]), Convert.ToInt32(dt.Rows[i]["salesman_ref"]),
                        dt.Rows[i]["substation"].ToString()));
                }
            }
            else
            {
                donendeger.Add(new Clients(0, 0, ""));
            }

            return donendeger;
        }
        /// <summary>
        /// Bütün fiyattipleri. 
        /// düzen=typeofprice_ref
        /// </summary>
        public List<TypeOfPrices> JSONGetTypeOfPrices(string Sifre)
        {
            List<TypeOfPrices> donendeger = new List<TypeOfPrices>();

            if (Sifre == "morgen")
            {
                DataTable dt = new DataTable();
                FiyatTipleri.GetObjectWS(dt);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    donendeger.Add(new TypeOfPrices(Convert.ToInt32(dt.Rows[i]["typeofprice_ref"])));
                }
            }
            else
            {
                donendeger.Add(new TypeOfPrices(0));
            }

            return donendeger;
        }
        /// <summary>
        /// Bütün ürünler fiyatsız. 
        /// düzen=item_ref:::item:::barcode:::stock
        /// </summary>
        public List<Products> JSONGetProducts(string Sifre)
        {
            List<Products> donendeger = new List<Products>();

            if (Sifre == "morgen")
            {
                DataTable dt = new DataTable();
                Urunler.GetProductsWS(dt);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    donendeger.Add(new Products(Convert.ToInt32(dt.Rows[i]["item_ref"]), dt.Rows[i]["item"].ToString(),
                        dt.Rows[i]["barcode"].ToString(), dt.Rows[i]["stock"].ToString()));
                }
            }
            else
            {
                donendeger.Add(new Products(0, "", "", ""));
            }

            return donendeger;
        }
        /// <summary>
        /// Bütün ürünler bütün fiyattipleriyle geliyor mesela A ürünü için birden çok satır gelecek her bir fiyat tipi için ayrı fiyat ayrı satır. 
        /// düzen=item_ref:::typeofprice_ref:::price
        /// </summary>
        public List<Prices> JSONGetPrices(string Sifre)
        {
            List<Prices> donendeger = new List<Prices>();

            if (Sifre == "morgen")
            {
                DataTable dt = new DataTable();
                Urunler.GetPricesWS(dt);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    donendeger.Add(new Prices(Convert.ToInt32(dt.Rows[i]["item_ref"]), Convert.ToInt32(dt.Rows[i]["typeofprice_ref"]),
                        dt.Rows[i]["price"].ToString()));
                }
            }
            else
            {
                donendeger.Add(new Prices(0, 0, ""));
            }

            return donendeger;
        }
        /// <summary>
        /// Hepsiburada için bütün ürünler. 
        /// fiyat tipi 15
        /// </summary>
        public List<hbProducts> JSONhbGetProducts(string KAdi, string Sifre)
        {
            List<hbProducts> donendeger = new List<hbProducts>();

            if (KAdi == "hepsiburada" && Sifre == WebGenel.GetHBsifre())
            {
                DataTable dt = new DataTable();
                FiyatListeleri.GetObjectXml(dt, 15, "");

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    donendeger.Add(new hbProducts(dt.Rows[i]["UrunID"].ToString(), dt.Rows[i]["UrunAdi"].ToString(), dt.Rows[i]["KDV"].ToString(),
                        dt.Rows[i]["OzelFiyat"].ToString().Replace(",", "."), dt.Rows[i]["ListeFiyat"].ToString().Replace(",", "."),
                        dt.Rows[i]["Kur"].ToString(), dt.Rows[i]["StokAdedi"].ToString(), dt.Rows[i]["Barcode"].ToString(),
                        dt.Rows[i]["ImageName1"].ToString()));
                }
            }
            else
            {
                donendeger.Add(new hbProducts("HATA", "HATA", "0", "0", "0", "HATA", "0", "0", "HATA"));
            }

            return donendeger;
        }
        /// <summary>
        /// n11 için bütün ürünler. 
        /// fiyat tipi 16
        /// </summary>
        public List<n11Products> JSONn11GetProducts(string KAdi, string Sifre)
        {
            List<n11Products> donendeger = new List<n11Products>();

            if (KAdi == "n11" && Sifre == WebGenel.GetN11sifre())
            {
                DataTable dt = new DataTable();
                FiyatListeleri.GetObjectXml(dt, 16, "");

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    donendeger.Add(new n11Products(dt.Rows[i]["UrunID"].ToString(), dt.Rows[i]["UrunAdi"].ToString(), dt.Rows[i]["KDV"].ToString(),
                        dt.Rows[i]["OzelFiyat"].ToString().Replace(",", "."), dt.Rows[i]["ListeFiyat"].ToString().Replace(",", "."),
                        dt.Rows[i]["Kur"].ToString(), dt.Rows[i]["StokAdedi"].ToString(), dt.Rows[i]["Barcode"].ToString(),
                        dt.Rows[i]["ImageName1"].ToString()));
                }
            }
            else
            {
                donendeger.Add(new n11Products("HATA", "HATA", "0", "0", "0", "HATA", "0", "0", "HATA"));
            }

            return donendeger;
        }
    }

    [Serializable]
    public class SAPSatisRaporu
    {
        public string SIPTUR_KOD, SIPTUR_ACK, FATTUR_KOD, FATTUR_ACK, BLM_KOD, BLM_ACK, TED_KOD, TED_ACK, PG_T, PG_T_ACIKLAMA, PG_B_Z, PG_B_Z_ACIKLAMA, BLG_KOD, BLG_ACK, SRM_ACK, SIPALN_ACK;
        public int SRM_KOD, SIPALN_KOD;
        public double NET, KOLI;
    }
  
}

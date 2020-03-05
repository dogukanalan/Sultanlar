using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Xml;

namespace Sultanlar.DatabaseObject.Internet
{
    public class Entegra
    {
        public static void GetObjects(DataTable dt)
        {
            using (SqlConnection selectConnection = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("sp_entegra", selectConnection);
                sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlDataAdapter.Fill(dt);
            }
        }

        public static EntegraSiparis GetSiparis(string EntegraNo)
        {
            EntegraSiparis entegraSiparis = new EntegraSiparis();
            using (SqlConnection connection = new SqlConnection(General.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("sp_entegra_siparis", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("SIPARIS_NO", (object)EntegraNo);
                connection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                if (sqlDataReader.Read())
                    entegraSiparis = new EntegraSiparis()
                    {
                        SIPARIS_NO = sqlDataReader[0].ToString(),
                        PAZARYERI_KARGOKODU = sqlDataReader[1].ToString(),
                        CariHesapKodu = sqlDataReader[2].ToString(),
                        CariHesapOzelKodu = sqlDataReader[3].ToString(),
                        POSTA = sqlDataReader[4].ToString(),
                        TARIH = Convert.ToDateTime(sqlDataReader[5]),
                        ISKONTO = Convert.ToDouble(sqlDataReader[6]),
                        NET_TOPLAM = Convert.ToDouble(sqlDataReader[7]),
                        TeslimAlici = sqlDataReader[8].ToString(),
                        TeslimAdresi = sqlDataReader[9].ToString(),
                        TeslimTelefon = sqlDataReader[10].ToString(),
                        teslimsekli = sqlDataReader[11].ToString(),
                        tasiyicifirma = sqlDataReader[12].ToString(),
                        teslimkod1 = sqlDataReader[13].ToString(),
                        teslimkod4 = sqlDataReader[14].ToString(),
                        teslimil = sqlDataReader[15].ToString(),
                        teslimilce = sqlDataReader[16].ToString(),
                        faturaalici = sqlDataReader[17].ToString(),
                        faturaAdresi = sqlDataReader[18].ToString(),
                        faturaTelefon = sqlDataReader[19].ToString(),
                        faturavergino = sqlDataReader[20].ToString(),
                        faturavergidairesi = sqlDataReader[21].ToString(),
                        faturail = sqlDataReader[22].ToString(),
                        faturailce = sqlDataReader[23].ToString(),
                        kargokodu = sqlDataReader[24].ToString(),
                        ODEME_SEKLI = sqlDataReader[25].ToString()
                    };
                connection.Close();
            }
            return entegraSiparis;
        }

        public static List<EntegraSatir> GetSatirlar(string EntegraNo)
        {
            List<EntegraSatir> entegraSatirList = new List<EntegraSatir>();
            using (SqlConnection connection = new SqlConnection(General.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("sp_entegra_satirlar", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("SIPARIS_NO", (object)EntegraNo);
                connection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                    entegraSatirList.Add(new EntegraSatir()
                    {
                        KOD = Convert.ToInt32(sqlDataReader[0]),
                        MIKTAR = Convert.ToInt32(sqlDataReader[1]),
                        BIRIM = sqlDataReader[2].ToString(),
                        FIYAT = Convert.ToDouble(sqlDataReader[3]),
                        KDV = Convert.ToInt32(sqlDataReader[4]),
                        SIPARIS_NO = sqlDataReader[5].ToString()
                    });
                connection.Close();
            }
            return entegraSatirList;
        }

        public static List<EntegraSatir> GetSatirlarGercek(string EntegraNo)
        {
            List<EntegraSatir> entegraSatirList = new List<EntegraSatir>();
            using (SqlConnection connection = new SqlConnection(General.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("sp_entegra_satirlar_gercek", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("SIPARIS_NO", (object)EntegraNo);
                connection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                    entegraSatirList.Add(new EntegraSatir()
                    {
                        KOD = Convert.ToInt32(sqlDataReader[0]),
                        MIKTAR = Convert.ToInt32(sqlDataReader[1]),
                        BIRIM = sqlDataReader[2].ToString(),
                        FIYAT = Convert.ToDouble(sqlDataReader[3]),
                        KDV = Convert.ToInt32(sqlDataReader[4]),
                        SIPARIS_NO = sqlDataReader[5].ToString()
                    });
                connection.Close();
            }
            return entegraSatirList;
        }

        public static EntegraSatir GetSatir(string EntegraNo, int KOD)
        {
            EntegraSatir entegraSatir = new EntegraSatir();
            using (SqlConnection connection = new SqlConnection(General.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("sp_entegra_satir", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("SIPARIS_NO", (object)EntegraNo);
                sqlCommand.Parameters.AddWithValue(nameof(KOD), (object)KOD);
                connection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                if (sqlDataReader.Read())
                    entegraSatir = new EntegraSatir()
                    {
                        KOD = Convert.ToInt32(sqlDataReader[0]),
                        MIKTAR = Convert.ToInt32(sqlDataReader[1]),
                        BIRIM = sqlDataReader[2].ToString(),
                        FIYAT = Convert.ToDouble(sqlDataReader[3]),
                        KDV = Convert.ToInt32(sqlDataReader[4]),
                        SIPARIS_NO = sqlDataReader[5].ToString()
                    };
                connection.Close();
            }
            return entegraSatir;
        }

        public static int SAPsipNo(string EntegraNo, int KOD)
        {
            int flag = 0;
            using (SqlConnection connection = new SqlConnection(General.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("SELECT GONDERILDI FROM [Web-Entegra-Siparis-SAP] WHERE [SIPARIS_NO] = @SIPARIS_NO AND [KOD] = @KOD", connection);
                sqlCommand.Parameters.AddWithValue("SIPARIS_NO", (object)EntegraNo);
                sqlCommand.Parameters.AddWithValue(nameof(KOD), (object)KOD);
                connection.Open();
                flag = Convert.ToInt32(sqlCommand.ExecuteScalar());
                connection.Close();
            }
            return flag;
        }

        public static int GetITEMREF(int KOD)
        {
            int flag = 0;
            using (SqlConnection connection = new SqlConnection(General.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("SELECT ITEMREF FROM [Web-Malzeme-Haric] WHERE [ID] = @KOD AND SIRA = 1", connection);
                sqlCommand.Parameters.AddWithValue(nameof(KOD), (object)KOD);
                connection.Open();
                flag = Convert.ToInt32(sqlCommand.ExecuteScalar());
                connection.Close();
            }
            return flag;
        }

        public static bool SAPcariVarMi(string EntegraNo, int KOD)
        {
            bool flag = false;
            using (SqlConnection connection = new SqlConnection(General.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("SELECT count(*) FROM [Web-Entegra-Siparis-SAP] WHERE [SIPARIS_NO] = @SIPARIS_NO AND [KOD] = @KOD", connection);
                sqlCommand.Parameters.AddWithValue("SIPARIS_NO", (object)EntegraNo);
                sqlCommand.Parameters.AddWithValue(nameof(KOD), (object)KOD);
                connection.Open();
                flag = Convert.ToBoolean(sqlCommand.ExecuteScalar());
                connection.Close();
            }
            return flag;
        }

        public static bool SAPcariVarMi(string EntegraNo, int KOD, int SAP_CARI)
        {
            bool flag = false;
            using (SqlConnection connection = new SqlConnection(General.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("SELECT count(*) FROM [Web-Entegra-Siparis-SAP] WHERE SAP_CARI = @SAP_CARI AND [SIPARIS_NO] = @SIPARIS_NO AND [KOD] = @KOD", connection);
                sqlCommand.Parameters.AddWithValue("SIPARIS_NO", (object)EntegraNo);
                sqlCommand.Parameters.AddWithValue(nameof(KOD), (object)KOD);
                sqlCommand.Parameters.AddWithValue(nameof(SAP_CARI), (object)SAP_CARI);
                connection.Open();
                flag = Convert.ToBoolean(sqlCommand.ExecuteScalar());
                connection.Close();
            }
            return flag;
        }

        public static void DoInsertSAP(string EntegraNo, int KOD, int CARI)
        {
            using (SqlConnection connection = new SqlConnection(General.ConnectionString))
            {
                SqlCommand sqlCommand1 = new SqlCommand();
                SqlCommand sqlCommand2 = !Entegra.SAPcariVarMi(EntegraNo, KOD, CARI) ? new SqlCommand("INSERT INTO [Web-Entegra-Siparis-SAP] ([SIPARIS_NO],[KOD],[SAP_CARI],[GONDERILDI]) VALUES (@SIPARIS_NO,@KOD,@SAP_CARI,0)", connection) : new SqlCommand("UPDATE [Web-Entegra-Siparis-SAP] SET [SAP_CARI] = @SAP_CARI WHERE [SIPARIS_NO] = @SIPARIS_NO AND [KOD] = @KOD", connection);
                sqlCommand2.Parameters.AddWithValue("SIPARIS_NO", (object)EntegraNo);
                sqlCommand2.Parameters.AddWithValue(nameof(KOD), (object)KOD);
                sqlCommand2.Parameters.AddWithValue("SAP_CARI", (object)CARI);
                connection.Open();
                sqlCommand2.ExecuteNonQuery();
                connection.Close();
            }
        }

        public static void DoSAP(string EntegraNo, int KOD, int GONDERILDI)
        {
            using (SqlConnection connection = new SqlConnection(General.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("UPDATE [Web-Entegra-Siparis-SAP] SET [GONDERILDI] = @GONDERILDI WHERE [SIPARIS_NO] = @SIPARIS_NO AND [KOD] = @KOD", connection);
                sqlCommand.Parameters.AddWithValue("SIPARIS_NO", (object)EntegraNo);
                sqlCommand.Parameters.AddWithValue(nameof(KOD), (object)KOD);
                sqlCommand.Parameters.AddWithValue(nameof(GONDERILDI), (object)GONDERILDI);
                connection.Open();
                sqlCommand.ExecuteNonQuery();
                connection.Close();
            }
        }

        public static bool EntegraSiparis()
        {
            XmlDocument xml = new XmlDocument();
            try
            {
                xml.Load("http://sultanlar.xmlbankasi.com/image/data/xml/siparis.xml");
            }
            catch (Exception ex)
            {
                return false;
            }

            List<EntegraSiparis> siparisler = new List<EntegraSiparis>();
            foreach (XmlNode xNode in xml.SelectNodes("SIPARISLER/SIPARIS"))
            {
                EntegraSiparis sip = new EntegraSiparis();
                sip.CariHesapKodu = xNode.SelectSingleNode("CariHesapKodu").InnerText;
                sip.CariHesapOzelKodu = xNode.SelectSingleNode("CariHesapOzelKodu").InnerText;
                sip.faturaAdresi = xNode.SelectSingleNode("faturaAdresi").InnerText;
                sip.faturaalici = xNode.SelectSingleNode("faturaalici").InnerText;
                sip.faturail = xNode.SelectSingleNode("faturail").InnerText;
                sip.faturailce = xNode.SelectSingleNode("faturailce").InnerText;
                sip.faturaTelefon = xNode.SelectSingleNode("faturaTelefon").InnerText;
                sip.faturavergidairesi = xNode.SelectSingleNode("faturavergidairesi").InnerText;
                sip.faturavergino = xNode.SelectSingleNode("faturavergino").InnerText;
                sip.ISKONTO = Convert.ToDouble(xNode.SelectSingleNode("ISKONTO").InnerText);
                sip.kargokodu = xNode.SelectSingleNode("kargokodu").InnerText;
                sip.NET_TOPLAM = Convert.ToDouble(xNode.SelectSingleNode("NET_TOPLAM").InnerText.Replace(".", ","));
                sip.ODEME_SEKLI = xNode.SelectSingleNode("ODEME_SEKLI").InnerText;
                sip.PAZARYERI_KARGOKODU = xNode.SelectSingleNode("PAZARYERI_KARGOKODU").InnerText;
                sip.POSTA = xNode.SelectSingleNode("POSTA").InnerText;
                sip.SIPARIS_NO = xNode.SelectSingleNode("SIPARIS_NO").InnerText.Replace("MRKZ-", "");
                sip.TARIH = Convert.ToDateTime(xNode.SelectSingleNode("TARIH").InnerText + " " + xNode.SelectSingleNode("sipariszaman").InnerText);
                sip.tasiyicifirma = xNode.SelectSingleNode("tasiyicifirma").InnerText;
                sip.TeslimAdresi = xNode.SelectSingleNode("TeslimAdresi").InnerText;
                sip.TeslimAlici = xNode.SelectSingleNode("TeslimAlici").InnerText;
                sip.teslimil = xNode.SelectSingleNode("teslimil").InnerText;
                sip.teslimilce = xNode.SelectSingleNode("teslimilce").InnerText;
                sip.teslimkod1 = xNode.SelectSingleNode("teslimkod1").InnerText;
                sip.teslimkod4 = xNode.SelectSingleNode("teslimkod4").InnerText;
                sip.teslimsekli = xNode.SelectSingleNode("teslimsekli").InnerText;
                sip.TeslimTelefon = xNode.SelectSingleNode("TeslimTelefon").InnerText;
                sip.status = xNode.SelectSingleNode("status").InnerText;

                List<EntegraSatir> satirlar = new List<EntegraSatir>();
                foreach (XmlNode xNode1 in xNode.SelectNodes("SATIRLAR/SATIR"))
                {
                    EntegraSatir sat = new EntegraSatir();
                    sat.SIPARIS_NO = sip.SIPARIS_NO;
                    sat.BIRIM = xNode1.SelectSingleNode("BIRIM").InnerText;
                    sat.FIYAT = Convert.ToDouble(xNode1.SelectSingleNode("FIYAT").InnerText.Replace(".", ","));
                    sat.KDV = Convert.ToInt32(xNode1.SelectSingleNode("KDV").InnerText);
                    sat.KOD = int.TryParse(xNode1.SelectSingleNode("KOD").InnerText, out sat.KOD) ? Convert.ToInt32(xNode1.SelectSingleNode("KOD").InnerText) : 0;
                    sat.MIKTAR = Convert.ToInt32(xNode1.SelectSingleNode("MIKTAR").InnerText);
                    satirlar.Add(sat);
                }
                sip.Satirlar = satirlar;

                siparisler.Add(sip);
            }

            /*XmlSerializer xsSubmit = new XmlSerializer(typeof(List<Siparis>));
            var xml1 = "";

            using (var sww = new StringWriter())
            {
                using (XmlWriter writer = XmlWriter.Create(sww))
                {
                    xsSubmit.Serialize(writer, siparisler);
                    xml1 = sww.ToString();
                }
            }

            textBox1.Text = xml1;*/

            DbYaz(siparisler);

            return true;
        }

        public static bool EntegraSiparis2()
        {
            XmlDocument xml = new XmlDocument();
            try
            {
                xml.Load("http://sultanlar.xmlbankasi.com/image/data/xml/siparis.xml");
            }
            catch (Exception ex)
            {
                return false;
            }

            List<EntegraSiparis> siparisler = new List<EntegraSiparis>();
            foreach (XmlNode xNode in xml.SelectNodes("SIPARISLER/SIPARIS"))
            {
                string sipno = xNode.SelectSingleNode("SIPARIS_NO").InnerText.Replace("MRKZ-", "");

                EntegraSiparis sipT1 = new EntegraSiparis();
                EntegraSiparis sipT2 = new EntegraSiparis();
                EntegraSiparis sipT3 = new EntegraSiparis();
                EntegraSiparis sipT4 = new EntegraSiparis();

                sipT1.CariHesapKodu = xNode.SelectSingleNode("CariHesapKodu").InnerText;
                sipT1.CariHesapOzelKodu = xNode.SelectSingleNode("CariHesapOzelKodu").InnerText;
                sipT1.faturaAdresi = xNode.SelectSingleNode("faturaAdresi").InnerText;
                sipT1.faturaalici = xNode.SelectSingleNode("faturaalici").InnerText;
                sipT1.faturail = xNode.SelectSingleNode("faturail").InnerText;
                sipT1.faturailce = xNode.SelectSingleNode("faturailce").InnerText;
                sipT1.faturaTelefon = xNode.SelectSingleNode("faturaTelefon").InnerText;
                sipT1.faturavergidairesi = xNode.SelectSingleNode("faturavergidairesi").InnerText;
                sipT1.faturavergino = xNode.SelectSingleNode("faturavergino").InnerText;
                sipT1.ISKONTO = Convert.ToDouble(xNode.SelectSingleNode("ISKONTO").InnerText);
                sipT1.kargokodu = xNode.SelectSingleNode("kargokodu").InnerText;
                sipT1.NET_TOPLAM = Convert.ToDouble(xNode.SelectSingleNode("NET_TOPLAM").InnerText.Replace(".", ","));
                sipT1.ODEME_SEKLI = xNode.SelectSingleNode("ODEME_SEKLI").InnerText;
                sipT1.PAZARYERI_KARGOKODU = xNode.SelectSingleNode("PAZARYERI_KARGOKODU").InnerText;
                sipT1.POSTA = xNode.SelectSingleNode("POSTA").InnerText;
                sipT1.SIPARIS_NO = sipno;
                sipT1.TARIH = Convert.ToDateTime(xNode.SelectSingleNode("TARIH").InnerText + " " + xNode.SelectSingleNode("sipariszaman").InnerText);
                sipT1.tasiyicifirma = xNode.SelectSingleNode("tasiyicifirma").InnerText;
                sipT1.TeslimAdresi = xNode.SelectSingleNode("TeslimAdresi").InnerText;
                sipT1.TeslimAlici = xNode.SelectSingleNode("TeslimAlici").InnerText;
                sipT1.teslimil = xNode.SelectSingleNode("teslimil").InnerText;
                sipT1.teslimilce = xNode.SelectSingleNode("teslimilce").InnerText;
                sipT1.teslimkod1 = xNode.SelectSingleNode("teslimkod1").InnerText;
                sipT1.teslimkod4 = xNode.SelectSingleNode("teslimkod4").InnerText;
                sipT1.teslimsekli = xNode.SelectSingleNode("teslimsekli").InnerText;
                sipT1.TeslimTelefon = xNode.SelectSingleNode("TeslimTelefon").InnerText;
                sipT1.status = xNode.SelectSingleNode("status").InnerText;

                sipT1.SIPARIS_NO = sipno + "-T1";
                sipT2 = SiparisKopyala(sipT1, sipno + "-T2");
                sipT3 = SiparisKopyala(sipT1, sipno + "-T3");
                sipT4 = SiparisKopyala(sipT1, sipno + "-T4");

                ArrayList bolumler = new ArrayList();
                List<EntegraSatir> satirlar = new List<EntegraSatir>();
                List<EntegraSatir> satirlarT1 = new List<EntegraSatir>();
                List<EntegraSatir> satirlarT2 = new List<EntegraSatir>();
                List<EntegraSatir> satirlarT3 = new List<EntegraSatir>();
                List<EntegraSatir> satirlarT4 = new List<EntegraSatir>();
                foreach (XmlNode xNode1 in xNode.SelectNodes("SATIRLAR/SATIR"))
                {
                    int itemref = int.TryParse(xNode1.SelectSingleNode("KOD").InnerText, out itemref) ? Convert.ToInt32(xNode1.SelectSingleNode("KOD").InnerText) : 0;
                    string bolum = Urunler.GetProductOzelKod(GetITEMREF(itemref));

                    EntegraSatir sat = new EntegraSatir();

                    sat.SIPARIS_NO = sipno + "-" + bolum;
                    sat.BIRIM = xNode1.SelectSingleNode("BIRIM").InnerText;
                    sat.FIYAT = Convert.ToDouble(xNode1.SelectSingleNode("FIYAT").InnerText.Replace(".", ","));
                    sat.KDV = Convert.ToInt32(xNode1.SelectSingleNode("KDV").InnerText);
                    sat.KOD = itemref;
                    sat.MIKTAR = Convert.ToInt32(xNode1.SelectSingleNode("MIKTAR").InnerText);
                    satirlar.Add(sat);

                    bolumler.Add(bolum);
                }

                for (int i = 0; i < bolumler.Count; i++)
                {
                    if (bolumler[i].ToString() == "T1")
                        satirlarT1.Add(SatirKopyala(satirlar[i], sipT1.SIPARIS_NO));
                    else if (bolumler[i].ToString() == "T2")
                        satirlarT2.Add(SatirKopyala(satirlar[i], sipT2.SIPARIS_NO));
                    else if (bolumler[i].ToString() == "T3")
                        satirlarT3.Add(SatirKopyala(satirlar[i], sipT3.SIPARIS_NO));
                    else if (bolumler[i].ToString() == "T4")
                        satirlarT4.Add(SatirKopyala(satirlar[i], sipT4.SIPARIS_NO));
                }

                sipT1.Satirlar = satirlarT1;
                sipT2.Satirlar = satirlarT2;
                sipT3.Satirlar = satirlarT3;
                sipT4.Satirlar = satirlarT4;

                if (sipT1.Satirlar.Count > 0)
                    siparisler.Add(sipT1);
                if (sipT2.Satirlar.Count > 0)
                    siparisler.Add(sipT2);
                if (sipT3.Satirlar.Count > 0)
                    siparisler.Add(sipT3);
                if (sipT4.Satirlar.Count > 0)
                    siparisler.Add(sipT4);
            }

            DbYaz(siparisler);

            return true;
        }

        private static void DbYaz(List<EntegraSiparis> siparisler)
        {
            SqlConnection conn = new SqlConnection(General.ConnectionString);
            conn.Open();
            for (int i = 0; i < siparisler.Count; i++)
            {
                SqlCommand cmd2 = new SqlCommand("SELECT count(*) FROM [Web-Entegra-Siparis] WHERE REPLACE(REPLACE(REPLACE(REPLACE([SIPARIS_NO],'-T1',''),'-T2',''),'-T3',''),'-T4','') = @SIPARIS_NO", conn);
                cmd2.Parameters.AddWithValue("SIPARIS_NO", siparisler[i].SIPARIS_NO.Replace("-T1", "").Replace("-T2", "").Replace("-T3", "").Replace("-T4", ""));
                bool var = Convert.ToBoolean(cmd2.ExecuteScalar());

                SqlCommand cmd = new SqlCommand();
                if (var)
                {
                    cmd = new SqlCommand("UPDATE [Web-Entegra-Siparis] SET [PAZARYERI_KARGOKODU]=@PAZARYERI_KARGOKODU,[CariHesapKodu]=@CariHesapKodu,[CariHesapOzelKodu]=@CariHesapOzelKodu,[POSTA]=@POSTA,[TARIH]=@TARIH,[ISKONTO]=@ISKONTO,[NET_TOPLAM]=@NET_TOPLAM,[TeslimAlici]=@TeslimAlici,[TeslimAdresi]=@TeslimAdresi,[TeslimTelefon]=@TeslimTelefon,[teslimsekli]=@teslimsekli,[tasiyicifirma]=@tasiyicifirma,[teslimkod1]=@teslimkod1,[teslimkod4]=@teslimkod4,[teslimil]=@teslimil,[teslimilce]=@teslimilce,[faturaalici]=@faturaalici,[faturaAdresi]=@faturaAdresi,[faturaTelefon]=@faturaTelefon,[faturavergino]=@faturavergino,[faturavergidairesi]=@faturavergidairesi,[faturail]=@faturail,[faturailce]=@faturailce,[kargokodu]=@kargokodu,[ODEME_SEKLI]=@ODEME_SEKLI,[status]=@status WHERE [SIPARIS_NO] = @SIPARIS_NO", conn);
                }
                else
                {
                    cmd = new SqlCommand("INSERT INTO [Web-Entegra-Siparis] ([SIPARIS_NO],[PAZARYERI_KARGOKODU],[CariHesapKodu],[CariHesapOzelKodu],[POSTA],[TARIH],[ISKONTO],[NET_TOPLAM],[TeslimAlici],[TeslimAdresi],[TeslimTelefon],[teslimsekli],[tasiyicifirma],[teslimkod1],[teslimkod4],[teslimil],[teslimilce],[faturaalici],[faturaAdresi],[faturaTelefon],[faturavergino],[faturavergidairesi],[faturail],[faturailce],[kargokodu],[ODEME_SEKLI],status) VALUES (@SIPARIS_NO,@PAZARYERI_KARGOKODU,@CariHesapKodu,@CariHesapOzelKodu,@POSTA,@TARIH,@ISKONTO,@NET_TOPLAM,@TeslimAlici,@TeslimAdresi,@TeslimTelefon,@teslimsekli,@tasiyicifirma,@teslimkod1,@teslimkod4,@teslimil,@teslimilce,@faturaalici,@faturaAdresi,@faturaTelefon,@faturavergino,@faturavergidairesi,@faturail,@faturailce,@kargokodu,@ODEME_SEKLI,@status)", conn);
                }
                cmd.Parameters.AddWithValue("CariHesapKodu", siparisler[i].CariHesapKodu);
                cmd.Parameters.AddWithValue("CariHesapOzelKodu", siparisler[i].CariHesapOzelKodu);
                cmd.Parameters.AddWithValue("faturaAdresi", siparisler[i].faturaAdresi);
                cmd.Parameters.AddWithValue("faturaalici", siparisler[i].faturaalici);
                cmd.Parameters.AddWithValue("faturail", siparisler[i].faturail);
                cmd.Parameters.AddWithValue("faturailce", siparisler[i].faturailce);
                cmd.Parameters.AddWithValue("faturaTelefon", siparisler[i].faturaTelefon);
                cmd.Parameters.AddWithValue("faturavergidairesi", siparisler[i].faturavergidairesi);
                cmd.Parameters.AddWithValue("faturavergino", siparisler[i].faturavergino);
                cmd.Parameters.AddWithValue("ISKONTO", siparisler[i].ISKONTO);
                cmd.Parameters.AddWithValue("kargokodu", siparisler[i].kargokodu);
                cmd.Parameters.AddWithValue("NET_TOPLAM", siparisler[i].NET_TOPLAM);
                cmd.Parameters.AddWithValue("ODEME_SEKLI", siparisler[i].ODEME_SEKLI);
                cmd.Parameters.AddWithValue("PAZARYERI_KARGOKODU", siparisler[i].PAZARYERI_KARGOKODU);
                cmd.Parameters.AddWithValue("POSTA", siparisler[i].POSTA);
                cmd.Parameters.AddWithValue("SIPARIS_NO", siparisler[i].SIPARIS_NO);
                cmd.Parameters.AddWithValue("TARIH", siparisler[i].TARIH);
                cmd.Parameters.AddWithValue("tasiyicifirma", siparisler[i].tasiyicifirma);
                cmd.Parameters.AddWithValue("TeslimAdresi", siparisler[i].TeslimAdresi);
                cmd.Parameters.AddWithValue("TeslimAlici", siparisler[i].TeslimAlici);
                cmd.Parameters.AddWithValue("teslimil", siparisler[i].teslimil);
                cmd.Parameters.AddWithValue("teslimilce", siparisler[i].teslimilce);
                cmd.Parameters.AddWithValue("teslimkod1", siparisler[i].teslimkod1);
                cmd.Parameters.AddWithValue("teslimkod4", siparisler[i].teslimkod4);
                cmd.Parameters.AddWithValue("teslimsekli", siparisler[i].teslimsekli);
                cmd.Parameters.AddWithValue("TeslimTelefon", siparisler[i].TeslimTelefon);
                cmd.Parameters.AddWithValue("status", siparisler[i].status);

                bool basarili = false;
                try { cmd.ExecuteNonQuery(); basarili = true; }
                catch (Exception ex) { Hatalar.DoInsert(ex, "entegra siparis (" + (var ? "Guncelleme" : "Ekleme") + "). siparis no: " + siparisler[i].SIPARIS_NO); }
                if (basarili && !var)
                {
                    for (int j = 0; j < siparisler[i].Satirlar.Count; j++)
                    {
                        SqlCommand cmd1 = new SqlCommand("INSERT INTO [Web-Entegra-Siparis-Detay] ([KOD],[MIKTAR],[BIRIM],[FIYAT],[KDV],[SIPARIS_NO]) VALUES (@KOD,@MIKTAR,@BIRIM,@FIYAT,@KDV,@SIPARIS_NO)", conn);
                        cmd1.Parameters.AddWithValue("BIRIM", siparisler[i].Satirlar[j].BIRIM);
                        cmd1.Parameters.AddWithValue("FIYAT", siparisler[i].Satirlar[j].FIYAT);
                        cmd1.Parameters.AddWithValue("KDV", siparisler[i].Satirlar[j].KDV);
                        cmd1.Parameters.AddWithValue("KOD", siparisler[i].Satirlar[j].KOD);
                        cmd1.Parameters.AddWithValue("MIKTAR", siparisler[i].Satirlar[j].MIKTAR);
                        cmd1.Parameters.AddWithValue("SIPARIS_NO", siparisler[i].Satirlar[j].SIPARIS_NO);
                        cmd1.ExecuteNonQuery();
                    }
                }
            }
            conn.Close();
        }

        private static void DbYazTest(List<EntegraSiparis> siparisler)
        {
            SqlConnection conn = new SqlConnection(General.ConnectionString);
            conn.Open();
            for (int i = 0; i < siparisler.Count; i++)
            {
                SqlCommand cmd2 = new SqlCommand("SELECT count(*) FROM [Web-Entegra-Siparis-Test] WHERE REPLACE(REPLACE(REPLACE(REPLACE([SIPARIS_NO],'-T1',''),'-T2',''),'-T3',''),'-T4','') = @SIPARIS_NO", conn);
                cmd2.Parameters.AddWithValue("SIPARIS_NO", siparisler[i].SIPARIS_NO.Replace("-T1", "").Replace("-T2", "").Replace("-T3", "").Replace("-T4", ""));
                bool var = Convert.ToBoolean(cmd2.ExecuteScalar());

                SqlCommand cmd = new SqlCommand();
                if (var)
                {
                    cmd = new SqlCommand("UPDATE [Web-Entegra-Siparis-Test] SET [PAZARYERI_KARGOKODU]=@PAZARYERI_KARGOKODU,[CariHesapKodu]=@CariHesapKodu,[CariHesapOzelKodu]=@CariHesapOzelKodu,[POSTA]=@POSTA,[TARIH]=@TARIH,[ISKONTO]=@ISKONTO,[NET_TOPLAM]=@NET_TOPLAM,[TeslimAlici]=@TeslimAlici,[TeslimAdresi]=@TeslimAdresi,[TeslimTelefon]=@TeslimTelefon,[teslimsekli]=@teslimsekli,[tasiyicifirma]=@tasiyicifirma,[teslimkod1]=@teslimkod1,[teslimkod4]=@teslimkod4,[teslimil]=@teslimil,[teslimilce]=@teslimilce,[faturaalici]=@faturaalici,[faturaAdresi]=@faturaAdresi,[faturaTelefon]=@faturaTelefon,[faturavergino]=@faturavergino,[faturavergidairesi]=@faturavergidairesi,[faturail]=@faturail,[faturailce]=@faturailce,[kargokodu]=@kargokodu,[ODEME_SEKLI]=@ODEME_SEKLI,[status]=@status WHERE [SIPARIS_NO] = @SIPARIS_NO", conn);
                }
                else
                {
                    cmd = new SqlCommand("INSERT INTO [Web-Entegra-Siparis-Test] ([SIPARIS_NO],[PAZARYERI_KARGOKODU],[CariHesapKodu],[CariHesapOzelKodu],[POSTA],[TARIH],[ISKONTO],[NET_TOPLAM],[TeslimAlici],[TeslimAdresi],[TeslimTelefon],[teslimsekli],[tasiyicifirma],[teslimkod1],[teslimkod4],[teslimil],[teslimilce],[faturaalici],[faturaAdresi],[faturaTelefon],[faturavergino],[faturavergidairesi],[faturail],[faturailce],[kargokodu],[ODEME_SEKLI],status) VALUES (@SIPARIS_NO,@PAZARYERI_KARGOKODU,@CariHesapKodu,@CariHesapOzelKodu,@POSTA,@TARIH,@ISKONTO,@NET_TOPLAM,@TeslimAlici,@TeslimAdresi,@TeslimTelefon,@teslimsekli,@tasiyicifirma,@teslimkod1,@teslimkod4,@teslimil,@teslimilce,@faturaalici,@faturaAdresi,@faturaTelefon,@faturavergino,@faturavergidairesi,@faturail,@faturailce,@kargokodu,@ODEME_SEKLI,@status)", conn);
                }
                cmd.Parameters.AddWithValue("CariHesapKodu", siparisler[i].CariHesapKodu);
                cmd.Parameters.AddWithValue("CariHesapOzelKodu", siparisler[i].CariHesapOzelKodu);
                cmd.Parameters.AddWithValue("faturaAdresi", siparisler[i].faturaAdresi);
                cmd.Parameters.AddWithValue("faturaalici", siparisler[i].faturaalici);
                cmd.Parameters.AddWithValue("faturail", siparisler[i].faturail);
                cmd.Parameters.AddWithValue("faturailce", siparisler[i].faturailce);
                cmd.Parameters.AddWithValue("faturaTelefon", siparisler[i].faturaTelefon);
                cmd.Parameters.AddWithValue("faturavergidairesi", siparisler[i].faturavergidairesi);
                cmd.Parameters.AddWithValue("faturavergino", siparisler[i].faturavergino);
                cmd.Parameters.AddWithValue("ISKONTO", siparisler[i].ISKONTO);
                cmd.Parameters.AddWithValue("kargokodu", siparisler[i].kargokodu);
                cmd.Parameters.AddWithValue("NET_TOPLAM", siparisler[i].NET_TOPLAM);
                cmd.Parameters.AddWithValue("ODEME_SEKLI", siparisler[i].ODEME_SEKLI);
                cmd.Parameters.AddWithValue("PAZARYERI_KARGOKODU", siparisler[i].PAZARYERI_KARGOKODU);
                cmd.Parameters.AddWithValue("POSTA", siparisler[i].POSTA);
                cmd.Parameters.AddWithValue("SIPARIS_NO", siparisler[i].SIPARIS_NO);
                cmd.Parameters.AddWithValue("TARIH", siparisler[i].TARIH);
                cmd.Parameters.AddWithValue("tasiyicifirma", siparisler[i].tasiyicifirma);
                cmd.Parameters.AddWithValue("TeslimAdresi", siparisler[i].TeslimAdresi);
                cmd.Parameters.AddWithValue("TeslimAlici", siparisler[i].TeslimAlici);
                cmd.Parameters.AddWithValue("teslimil", siparisler[i].teslimil);
                cmd.Parameters.AddWithValue("teslimilce", siparisler[i].teslimilce);
                cmd.Parameters.AddWithValue("teslimkod1", siparisler[i].teslimkod1);
                cmd.Parameters.AddWithValue("teslimkod4", siparisler[i].teslimkod4);
                cmd.Parameters.AddWithValue("teslimsekli", siparisler[i].teslimsekli);
                cmd.Parameters.AddWithValue("TeslimTelefon", siparisler[i].TeslimTelefon);
                cmd.Parameters.AddWithValue("status", siparisler[i].status);

                bool basarili = false;
                try { cmd.ExecuteNonQuery(); basarili = true; }
                catch (Exception ex) { Hatalar.DoInsert(ex, "entegra siparis (" + (var ? "Guncelleme" : "Ekleme") + "). siparis no: " + siparisler[i].SIPARIS_NO); }
                if (basarili && !var)
                {
                    for (int j = 0; j < siparisler[i].Satirlar.Count; j++)
                    {
                        SqlCommand cmd1 = new SqlCommand("INSERT INTO [Web-Entegra-Siparis-Detay-Test] ([KOD],[MIKTAR],[BIRIM],[FIYAT],[KDV],[SIPARIS_NO]) VALUES (@KOD,@MIKTAR,@BIRIM,@FIYAT,@KDV,@SIPARIS_NO)", conn);
                        cmd1.Parameters.AddWithValue("BIRIM", siparisler[i].Satirlar[j].BIRIM);
                        cmd1.Parameters.AddWithValue("FIYAT", siparisler[i].Satirlar[j].FIYAT);
                        cmd1.Parameters.AddWithValue("KDV", siparisler[i].Satirlar[j].KDV);
                        cmd1.Parameters.AddWithValue("KOD", siparisler[i].Satirlar[j].KOD);
                        cmd1.Parameters.AddWithValue("MIKTAR", siparisler[i].Satirlar[j].MIKTAR);
                        cmd1.Parameters.AddWithValue("SIPARIS_NO", siparisler[i].Satirlar[j].SIPARIS_NO);
                        cmd1.ExecuteNonQuery();
                    }
                }
            }
            conn.Close();
        }

        private static EntegraSiparis SiparisKopyala(EntegraSiparis sip, string siparisno)
        {
            EntegraSiparis donendeger = new EntegraSiparis();

            donendeger.SIPARIS_NO = siparisno;
            donendeger.CariHesapKodu = sip.CariHesapKodu;
            donendeger.CariHesapOzelKodu = sip.CariHesapOzelKodu;
            donendeger.faturaAdresi = sip.faturaAdresi;
            donendeger.faturaalici = sip.faturaalici;
            donendeger.faturail = sip.faturail;
            donendeger.faturailce = sip.faturailce;
            donendeger.faturaTelefon = sip.faturaTelefon;
            donendeger.faturavergidairesi = sip.faturavergidairesi;
            donendeger.faturavergino = sip.faturavergino;
            donendeger.ISKONTO = sip.ISKONTO;
            donendeger.kargokodu = sip.kargokodu;
            donendeger.NET_TOPLAM = sip.NET_TOPLAM;
            donendeger.ODEME_SEKLI = sip.ODEME_SEKLI;
            donendeger.PAZARYERI_KARGOKODU = sip.PAZARYERI_KARGOKODU;
            donendeger.POSTA = sip.POSTA;
            donendeger.TARIH = sip.TARIH;
            donendeger.tasiyicifirma = sip.tasiyicifirma;
            donendeger.TeslimAdresi = sip.TeslimAdresi;
            donendeger.TeslimAlici = sip.TeslimAlici;
            donendeger.teslimil = sip.teslimil;
            donendeger.teslimilce = sip.teslimilce;
            donendeger.teslimkod1 = sip.teslimkod1;
            donendeger.teslimkod4 = sip.teslimkod4;
            donendeger.teslimsekli = sip.teslimsekli;
            donendeger.TeslimTelefon = sip.TeslimTelefon;
            donendeger.status = sip.status;

            return donendeger;
        }

        private static EntegraSatir SatirKopyala(EntegraSatir sat, string siparisno)
        {
            EntegraSatir donendeger = new EntegraSatir();

            donendeger.SIPARIS_NO = siparisno;
            donendeger.BIRIM = sat.BIRIM;
            donendeger.FIYAT = sat.FIYAT;
            donendeger.KDV = sat.KDV;
            donendeger.KOD = sat.KOD;
            donendeger.MIKTAR = sat.MIKTAR;

            return donendeger;
        }
    }

    public class EntegraSiparis
    {
        public string SIPARIS_NO;
        public string PAZARYERI_KARGOKODU;
        public string CariHesapKodu;
        public string CariHesapOzelKodu;
        public string POSTA;
        public DateTime TARIH;
        public double ISKONTO;
        public double NET_TOPLAM;
        public string TeslimAlici;
        public string TeslimAdresi;
        public string TeslimTelefon;
        public string teslimsekli;
        public string tasiyicifirma;
        public string teslimkod1;
        public string teslimkod4;
        public string teslimil;
        public string teslimilce;
        public string faturaalici;
        public string faturaAdresi;
        public string faturaTelefon;
        public string faturavergino;
        public string faturavergidairesi;
        public string faturail;
        public string faturailce;
        public string kargokodu;
        public string ODEME_SEKLI;
        public string status;
        public List<EntegraSatir> Satirlar;
    }

    public class EntegraSatir
    {
        public string SIPARIS_NO;
        public int KOD;
        public int MIKTAR;
        public string BIRIM;
        public double FIYAT;
        public int KDV;
    }

    public class EntegraSAP
    {
        public string SIPARIS_NO;
        public int KOD;
        public int SAP_CARI;
        public int GONDERILDI;
    }
}

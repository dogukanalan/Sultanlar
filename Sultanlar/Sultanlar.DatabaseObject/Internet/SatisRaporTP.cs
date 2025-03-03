﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace Sultanlar.DatabaseObject.Internet
{
    public class SatisRaporTP : IDisposable, ISultanlar
    {
        //
        //
        //
        // Alanlar:
        //
        private long _REF;
        private string _BAYIKOD;
        private string _NOKTAAD;
        private string _NOKTAEVRAKNO;
        private DateTime _NOKTAEVREKTARIH;
        private string _URUNKOD;
        private string _URUNAD;
        private int _NOKTASATADET;
        private decimal _NOKTASATNET;
        private byte _NOKTASATAY;
        private short _NOKTASATYIL;
        private int _intAnlasmaID;
        private int _intAktiviteID;
        private double _flIsk1;
        private double _flIsk2;
        private double _flIsk3;
        private double _flIsk4;
        private decimal _mnListeFiyat;
        private decimal _mnListeFiyatKarli;
        private decimal _mnNetBirimFiyat;
        private decimal _mnNetToplam;
        private decimal _mnBirimFark;
        private decimal _mnToplamFark;
        private bool _blGeriyeDonuk;
        private decimal _mnFaturadanKapatilan;
        private int _intFaturaID;
        private string _IL;
        private string _NOKTAKOD;
        //
        //
        //
        // Constracter lar:
        //
        private SatisRaporTP()
        {

        }
        //
        //
        private SatisRaporTP(long REF, string BAYIKOD, string NOKTAAD, string NOKTAEVRAKNO, DateTime NOKTAEVREKTARIH, string URUNKOD,
            string URUNAD, int NOKTASATADET, decimal NOKTASATNET, byte NOKTASATAY, short NOKTASATYIL, 
            int intAnlasmaID, int intAktiviteID, double flIsk1, double flIsk2, double flIsk3, double flIsk4, decimal mnListeFiyat, decimal mnListeFiyatKarli, 
            decimal mnNetBirimFiyat, decimal mnNetToplam, decimal mnBirimFark, decimal mnToplamFark,
            bool blGeriyeDonuk, decimal mnFaturadanKapatilan, int intFaturaID, string IL, string NOKTAKOD)
        {
            this._REF = REF;
            this._BAYIKOD = BAYIKOD;
            this._NOKTAAD = NOKTAAD;
            this._NOKTAEVRAKNO = NOKTAEVRAKNO;
            this._NOKTAEVREKTARIH = NOKTAEVREKTARIH;
            this._URUNKOD = URUNKOD;
            this._URUNAD = URUNAD;
            this._NOKTASATADET = NOKTASATADET;
            this._NOKTASATNET = NOKTASATNET;
            this._NOKTASATAY = NOKTASATAY;
            this._NOKTASATYIL = NOKTASATYIL;
            this._intAnlasmaID = intAnlasmaID;
            this._intAktiviteID = intAktiviteID;
            this._flIsk1 = flIsk1;
            this._flIsk2 = flIsk2;
            this._flIsk3 = flIsk3;
            this._flIsk4 = flIsk4;
            this._mnListeFiyat = mnListeFiyat;
            this._mnListeFiyatKarli = mnListeFiyatKarli;
            this._mnNetBirimFiyat = mnNetBirimFiyat;
            this._mnNetToplam = mnNetToplam;
            this._mnBirimFark = mnBirimFark;
            this._mnToplamFark = mnToplamFark;
            this._blGeriyeDonuk = blGeriyeDonuk;
            this._mnFaturadanKapatilan = mnFaturadanKapatilan;
            this._intFaturaID = intFaturaID;
            this._IL = IL;
            this._NOKTAKOD = NOKTAKOD;
        }
        //
        //
        public SatisRaporTP(string BAYIKOD, string NOKTAAD, string NOKTAEVRAKNO, DateTime NOKTAEVREKTARIH, string URUNKOD,
            string URUNAD, int NOKTASATADET, decimal NOKTASATNET, byte NOKTASATAY, short NOKTASATYIL, 
            int intAnlasmaID, int intAktiviteID, double flIsk1, double flIsk2, double flIsk3, double flIsk4, decimal mnListeFiyat, decimal mnListeFiyatKarli,
            decimal mnNetBirimFiyat, decimal mnNetToplam, decimal mnBirimFark, decimal mnToplamFark,
            bool blGeriyeDonuk, decimal mnFaturadanKapatilan, int intFaturaID, string IL, string NOKTAKOD)
        {
            this._BAYIKOD = BAYIKOD;
            this._NOKTAAD = NOKTAAD;
            this._NOKTAEVRAKNO = NOKTAEVRAKNO;
            this._NOKTAEVREKTARIH = NOKTAEVREKTARIH;
            this._URUNKOD = URUNKOD;
            this._URUNAD = URUNAD;
            this._NOKTASATADET = NOKTASATADET;
            this._NOKTASATNET = NOKTASATNET;
            this._NOKTASATAY = NOKTASATAY;
            this._NOKTASATYIL = NOKTASATYIL;
            this._intAnlasmaID = intAnlasmaID;
            this._intAktiviteID = intAktiviteID;
            this._flIsk1 = flIsk1;
            this._flIsk2 = flIsk2;
            this._flIsk3 = flIsk3;
            this._flIsk4 = flIsk4;
            this._mnListeFiyat = mnListeFiyat;
            this._mnListeFiyatKarli = mnListeFiyatKarli;
            this._mnNetBirimFiyat = mnNetBirimFiyat;
            this._mnNetToplam = mnNetToplam;
            this._mnBirimFark = mnBirimFark;
            this._mnToplamFark = mnToplamFark;
            this._blGeriyeDonuk = blGeriyeDonuk;
            this._mnFaturadanKapatilan = mnFaturadanKapatilan;
            this._intFaturaID = intFaturaID;
            this._IL = IL;
            this._NOKTAKOD = NOKTAKOD;
        }
        //
        //
        //
        // Özellikler:
        //
        public long REF { get { return this._REF; } set { this._REF = value; } }
        public string BAYIKOD { get { return this._BAYIKOD; } set { this._BAYIKOD = value; } }
        public string NOKTAAD { get { return this._NOKTAAD; } set { this._NOKTAAD = value; } }
        public string NOKTAEVRAKNO { get { return this._NOKTAEVRAKNO; } set { this._NOKTAEVRAKNO = value; } }
        public DateTime NOKTAEVREKTARIH { get { return this._NOKTAEVREKTARIH; } set { this._NOKTAEVREKTARIH = value; } }
        public string URUNKOD { get { return this._URUNKOD; } set { this._URUNKOD = value; } }
        public string URUNAD { get { return this._URUNAD; } set { this._URUNAD = value; } }
        public int NOKTASATADET { get { return this._NOKTASATADET; } set { this._NOKTASATADET = value; } }
        public decimal NOKTASATNET { get { return this._NOKTASATNET; } set { this._NOKTASATNET = value; } }
        public byte NOKTASATAY { get { return this._NOKTASATAY; } set { this._NOKTASATAY = value; } }
        public short NOKTASATYIL { get { return this._NOKTASATYIL; } set { this._NOKTASATYIL = value; } }
        public int intAnlasmaID { get { return this._intAnlasmaID; } set { this._intAnlasmaID = value; } }
        public int intAktiviteID { get { return this._intAktiviteID; } set { this._intAktiviteID = value; } }
        public double flIsk1 { get { return this._flIsk1; } set { this._flIsk1 = value; } }
        public double flIsk2 { get { return this._flIsk2; } set { this._flIsk2 = value; } }
        public double flIsk3 { get { return this._flIsk3; } set { this._flIsk3 = value; } }
        public double flIsk4 { get { return this._flIsk4; } set { this._flIsk4 = value; } }
        public decimal mnListeFiyat { get { return this._mnListeFiyat; } set { this._mnListeFiyat = value; } }
        public decimal mnListeFiyatKarli { get { return this._mnListeFiyatKarli; } set { this._mnListeFiyatKarli = value; } }
        public decimal mnNetBirimFiyat { get { return this._mnNetBirimFiyat; } set { this._mnNetBirimFiyat = value; } }
        public decimal mnNetToplam { get { return this._mnNetToplam; } set { this._mnNetToplam = value; } }
        public decimal mnBirimFark { get { return this._mnBirimFark; } set { this._mnBirimFark = value; } }
        public decimal mnToplamFark { get { return this._mnToplamFark; } set { this._mnToplamFark = value; } }
        public bool blGeriyeDonuk { get { return this._blGeriyeDonuk; } set { this._blGeriyeDonuk = value; } }
        public decimal mnFaturadanKapatilan { get { return this._mnFaturadanKapatilan; } set { this._mnFaturadanKapatilan = value; } }
        public int intFaturaID { get { return this._intFaturaID; } set { this._intFaturaID = value; } }
        public string IL { get { return this._IL; } set { this._IL = value; } }
        public string NOKTAKOD { get { return this._NOKTAKOD; } set { this._NOKTAKOD = value; } }
        //
        //
        //
        // Yoketme metodu:
        //
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        //
        //
        //
        // Yoketme metodu:
        //
        public override string ToString()
        {
            return "(" + this._BAYIKOD + ") (" + this._NOKTAKOD + ") " + this._NOKTAAD.ToString();
        }
        //
        //
        //
        // Metodlar:
        //
        public void DoInsert()
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO [Web-Satis-Rapor-TP] ([BAYIKOD],[NOKTAAD],[NOKTAEVRAKNO],[NOKTAEVREKTARIH],[URUNKOD],[URUNAD],[NOKTASATADET],[NOKTASATNET],[NOKTASATAY],[NOKTASATYIL],intAnlasmaID,intAktiviteID,flIsk1,flIsk2,flIsk3,flIsk4,mnListeFiyat,mnListeFiyatKarli,mnNetBirimFiyat,mnNetToplam,mnBirimFark,mnToplamFark,blGeriyeDonuk,mnFaturadanKapatilan,intFaturaID,NOKTAKOD) VALUES (@BAYIKOD,@NOKTAAD,@NOKTAEVRAKNO,DATEADD(dd, 0, DATEDIFF(dd, 0, @NOKTAEVREKTARIH)),@URUNKOD,@URUNAD,@NOKTASATADET,@NOKTASATNET,@NOKTASATAY,@NOKTASATYIL,@intAnlasmaID,@intAktiviteID,@flIsk1,@flIsk2,@flIsk3,@flIsk4,@mnListeFiyat,@mnListeFiyatKarli,@mnNetBirimFiyat,@mnNetToplam,@mnBirimFark,@mnToplamFark,@blGeriyeDonuk,@mnFaturadanKapatilan,@intFaturaID,@NOKTAKOD) SELECT @REF = SCOPE_IDENTITY()", conn);
                cmd.Parameters.Add("@BAYIKOD", SqlDbType.NVarChar).Value = this._BAYIKOD;
                cmd.Parameters.Add("@NOKTAAD", SqlDbType.NVarChar).Value = this._NOKTAAD;
                cmd.Parameters.Add("@NOKTAEVRAKNO", SqlDbType.NVarChar).Value = this._NOKTAEVRAKNO;
                cmd.Parameters.Add("@NOKTAEVREKTARIH", SqlDbType.SmallDateTime).Value = this._NOKTAEVREKTARIH;
                cmd.Parameters.Add("@URUNKOD", SqlDbType.NVarChar).Value = this._URUNKOD;
                cmd.Parameters.Add("@URUNAD", SqlDbType.NVarChar).Value = this._URUNAD;
                cmd.Parameters.Add("@NOKTASATADET", SqlDbType.Int).Value = this._NOKTASATADET;
                cmd.Parameters.Add("@NOKTASATNET", SqlDbType.Money).Value = this._NOKTASATNET;
                cmd.Parameters.Add("@NOKTASATAY", SqlDbType.TinyInt).Value = this._NOKTASATAY;
                cmd.Parameters.Add("@NOKTASATYIL", SqlDbType.SmallInt).Value = this._NOKTASATYIL;
                cmd.Parameters.Add("@intAnlasmaID", SqlDbType.Int).Value = this._intAnlasmaID;
                cmd.Parameters.Add("@intAktiviteID", SqlDbType.Int).Value = this._intAktiviteID;
                cmd.Parameters.Add("@flIsk1", SqlDbType.Float).Value = this._flIsk1;
                cmd.Parameters.Add("@flIsk2", SqlDbType.Float).Value = this._flIsk2;
                cmd.Parameters.Add("@flIsk3", SqlDbType.Float).Value = this._flIsk3;
                cmd.Parameters.Add("@flIsk4", SqlDbType.Float).Value = this._flIsk4;
                cmd.Parameters.Add("@mnListeFiyat", SqlDbType.Money).Value = this._mnListeFiyat;
                cmd.Parameters.Add("@mnListeFiyatKarli", SqlDbType.Money).Value = this._mnListeFiyatKarli;
                cmd.Parameters.Add("@mnNetBirimFiyat", SqlDbType.Money).Value = this._mnNetBirimFiyat;
                cmd.Parameters.Add("@mnNetToplam", SqlDbType.Money).Value = this._mnNetToplam;
                cmd.Parameters.Add("@mnBirimFark", SqlDbType.Money).Value = this._mnBirimFark;
                cmd.Parameters.Add("@mnToplamFark", SqlDbType.Money).Value = this._mnToplamFark;
                cmd.Parameters.Add("@blGeriyeDonuk", SqlDbType.Bit).Value = this._blGeriyeDonuk;
                cmd.Parameters.Add("@mnFaturadanKapatilan", SqlDbType.Money).Value = this._mnFaturadanKapatilan;
                cmd.Parameters.Add("@intFaturaID", SqlDbType.Int).Value = this._intFaturaID;
                cmd.Parameters.Add("@NOKTAKOD", SqlDbType.NVarChar).Value = this._NOKTAKOD;
                cmd.Parameters.Add("@REF", SqlDbType.BigInt).Direction = ParameterDirection.Output;
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    this._REF = Convert.ToInt64(cmd.Parameters["@REF"].Value);
                }
                catch (SqlException ex)
                {
                    Hatalar.DoInsert(ex);
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        //
        //
        public void DoUpdate()
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UPDATE [Web-Satis-Rapor-TP] SET [BAYIKOD] = @BAYIKOD,[NOKTAAD] = @NOKTAAD,[NOKTAEVRAKNO] = @NOKTAEVRAKNO,[NOKTAEVREKTARIH] = @NOKTAEVREKTARIH,[URUNKOD] = @URUNKOD,[URUNAD] = @URUNAD,[NOKTASATADET] = @NOKTASATADET,[NOKTASATNET] = @NOKTASATNET,[NOKTASATAY] = @NOKTASATAY,[NOKTASATYIL] = @NOKTASATYIL, intAnlasmaID = @intAnlasmaID, intAktiviteID = @intAktiviteID, flIsk1 = @flIsk1, flIsk2 = @flIsk2, flIsk3 = @flIsk3, flIsk4 = @flIsk4,mnListeFiyat=@mnListeFiyat,mnListeFiyatKarli=@mnListeFiyatKarli,mnNetBirimFiyat=@mnNetBirimFiyat,mnNetToplam=@mnNetToplam,mnBirimFark=@mnBirimFark,mnToplamFark=@mnToplamFark,blGeriyeDonuk=@blGeriyeDonuk,mnFaturadanKapatilan=@mnFaturadanKapatilan,intFaturaID=@intFaturaID,NOKTAKOD=@NOKTAKOD WHERE [REF] = @REF", conn);
                cmd.Parameters.Add("@REF", SqlDbType.BigInt).Value = this._REF;
                cmd.Parameters.Add("@BAYIKOD", SqlDbType.NVarChar).Value = this._BAYIKOD;
                cmd.Parameters.Add("@NOKTAAD", SqlDbType.NVarChar).Value = this._NOKTAAD;
                cmd.Parameters.Add("@NOKTAEVRAKNO", SqlDbType.NVarChar).Value = this._NOKTAEVRAKNO;
                cmd.Parameters.Add("@NOKTAEVREKTARIH", SqlDbType.SmallDateTime).Value = this._NOKTAEVREKTARIH;
                cmd.Parameters.Add("@URUNKOD", SqlDbType.NVarChar).Value = this._URUNKOD;
                cmd.Parameters.Add("@URUNAD", SqlDbType.NVarChar).Value = this._URUNAD;
                cmd.Parameters.Add("@NOKTASATADET", SqlDbType.Int).Value = this._NOKTASATADET;
                cmd.Parameters.Add("@NOKTASATNET", SqlDbType.Money).Value = this._NOKTASATNET;
                cmd.Parameters.Add("@NOKTASATAY", SqlDbType.TinyInt).Value = this._NOKTASATAY;
                cmd.Parameters.Add("@NOKTASATYIL", SqlDbType.SmallInt).Value = this._NOKTASATYIL;
                cmd.Parameters.Add("@intAnlasmaID", SqlDbType.Int).Value = this._intAnlasmaID;
                cmd.Parameters.Add("@intAktiviteID", SqlDbType.Int).Value = this._intAktiviteID;
                cmd.Parameters.Add("@flIsk1", SqlDbType.Float).Value = this._flIsk1;
                cmd.Parameters.Add("@flIsk2", SqlDbType.Float).Value = this._flIsk2;
                cmd.Parameters.Add("@flIsk3", SqlDbType.Float).Value = this._flIsk3;
                cmd.Parameters.Add("@flIsk4", SqlDbType.Float).Value = this._flIsk4;
                cmd.Parameters.Add("@mnListeFiyat", SqlDbType.Money).Value = this._mnListeFiyat;
                cmd.Parameters.Add("@mnListeFiyatKarli", SqlDbType.Money).Value = this._mnListeFiyatKarli;
                cmd.Parameters.Add("@mnNetBirimFiyat", SqlDbType.Money).Value = this._mnNetBirimFiyat;
                cmd.Parameters.Add("@mnNetToplam", SqlDbType.Money).Value = this._mnNetToplam;
                cmd.Parameters.Add("@mnBirimFark", SqlDbType.Money).Value = this._mnBirimFark;
                cmd.Parameters.Add("@mnToplamFark", SqlDbType.Money).Value = this._mnToplamFark;
                cmd.Parameters.Add("@blGeriyeDonuk", SqlDbType.Bit).Value = this._blGeriyeDonuk;
                cmd.Parameters.Add("@mnFaturadanKapatilan", SqlDbType.Money).Value = this._mnFaturadanKapatilan;
                cmd.Parameters.Add("@intFaturaID", SqlDbType.Int).Value = this._intFaturaID;
                cmd.Parameters.Add("@NOKTAKOD", SqlDbType.NVarChar).Value = this._NOKTAKOD;
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    Hatalar.DoInsert(ex);
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        //
        //
        public void DoDelete()
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM [Web-Satis-Rapor-TP] WHERE [REF] = @REF", conn);
                cmd.Parameters.Add("@REF", SqlDbType.BigInt).Value = this._REF;
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    Hatalar.DoInsert(ex);
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        //
        //
        /// <summary>
        /// 
        /// </summary>
        /// <param name="BAYIKOD"></param>
        /// <param name="Yil"></param>
        /// <param name="Ay"></param>
        /// <param name="Bolum">1: YEG, 2: TAH, 3:hepsi</param>
        public static void DoDelete(string BAYIKOD, short Yil, byte Ay, int Bolum)
        {
            string bolum = Bolum == 1 ? " AND [REY KOD] = 'T2'" : Bolum == 2 ? " AND [REY KOD] != 'T2'" : "";

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("DELETE [Web-Satis-Rapor-TP] FROM [Web-Satis-Rapor-TP] INNER JOIN [Web-Malzeme-Full] ON URUNKOD = ITEMREF WHERE BAYIKOD=@BAYIKOD AND NOKTASATYIL=@NOKTASATYIL AND NOKTASATAY=@NOKTASATAY" + bolum, conn);
                cmd.Parameters.Add("@BAYIKOD", SqlDbType.VarChar, 7).Value = BAYIKOD;
                cmd.Parameters.Add("@NOKTASATYIL", SqlDbType.SmallInt).Value = Yil;
                cmd.Parameters.Add("@NOKTASATAY", SqlDbType.TinyInt).Value = Ay;
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    Hatalar.DoInsert(ex);
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        //
        //
        public static void DoUpdateNoktaAd(string BAYIKOD, string NoktaAd, string YeniNoktaAd)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UPDATE [Web-Satis-Rapor-TP] SET NOKTAAD = @YENINOKTAAD WHERE BAYIKOD = @BAYIKOD AND NOKTAAD = @NOKTAAD", conn);
                cmd.Parameters.Add("@BAYIKOD", SqlDbType.NVarChar, 7).Value = BAYIKOD;
                cmd.Parameters.Add("@YENINOKTAAD", SqlDbType.NVarChar).Value = YeniNoktaAd;
                cmd.Parameters.Add("@NOKTAAD", SqlDbType.NVarChar).Value = NoktaAd;
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    Hatalar.DoInsert(ex);
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        //
        //
        public static void DoUpdateNoktaAd(string BAYIKOD, string NoktaKod, string NoktaAd, int YeniNoktaRef, string YeniNoktaKod, string YeniNoktaAd)
        {
            string paramNoktaKod = NoktaKod != string.Empty ? " AND NOKTAKOD = '" + NoktaKod + "'": "";
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UPDATE [Web-Satis-Rapor-TP] SET NOKTAAD = @YENINOKTAAD,NOKTAREF = @YENINOKTAREF,NOKTAKOD = @YENINOKTAKOD WHERE BAYIKOD = @BAYIKOD AND NOKTAAD = @NOKTAAD" + paramNoktaKod, conn);
                cmd.Parameters.Add("@BAYIKOD", SqlDbType.NVarChar, 7).Value = BAYIKOD;
                cmd.Parameters.Add("@YENINOKTAREF", SqlDbType.Int).Value = YeniNoktaRef;
                cmd.Parameters.Add("@YENINOKTAKOD", SqlDbType.NVarChar).Value = YeniNoktaKod;
                cmd.Parameters.Add("@YENINOKTAAD", SqlDbType.NVarChar).Value = YeniNoktaAd;
                cmd.Parameters.Add("@NOKTAAD", SqlDbType.NVarChar).Value = NoktaAd;
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    Hatalar.DoInsert(ex);
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        //
        //
        public static void DoUpdateNoktaKod(string BAYIKOD, string NoktaKod, string YeniNoktaKod)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UPDATE [Web-Satis-Rapor-TP] SET NOKTAKOD = @YENINOKTAKOD WHERE BAYIKOD = @BAYIKOD AND NOKTAKOD = @NOKTAKOD", conn);
                cmd.Parameters.Add("@BAYIKOD", SqlDbType.NVarChar, 7).Value = BAYIKOD;
                cmd.Parameters.Add("@YENINOKTAKOD", SqlDbType.NVarChar).Value = YeniNoktaKod;
                cmd.Parameters.Add("@NOKTAKOD", SqlDbType.NVarChar).Value = NoktaKod;
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    Hatalar.DoInsert(ex);
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        //
        //
        public static void DoUpdateNoktaref(int ESKI, int YENI)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UPDATE [Web-Satis-Rapor-TP] SET NOKTAREF = @YENI WHERE NOKTAREF = @ESKI", conn);
                cmd.Parameters.Add("@ESKI", SqlDbType.Int).Value = ESKI;
                cmd.Parameters.Add("@YENI", SqlDbType.Int).Value = YENI;
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    Hatalar.DoInsert(ex);
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        /// <summary>
        /// GMREF = 0 ise dahil değil -1 ise sultanlar, Ay = 0 ise dahil değil, Yil = 0 ise dahil değil
        /// </summary>
        public static void GetObjects(DataTable dt, int GMREF, byte Ay, short Yil, int Bolum)
        {
            string noktaad = string.Empty;
            string bayikod = string.Empty;
            if (GMREF == -1) // sultanlar
            {
                noktaad = "(SELECT DISTINCT MUSTERI FROM [Web-Musteri] WHERE SMREF = [vw_Web-Satis-Rapor-TP].[NOKTAAD]) AS NOKTAAD2";
                bayikod = " BAYIKOD = '1001327' AND";
            }
            else if (GMREF != 0)
            {
                noktaad = "[NOKTAAD] AS NOKTAAD2";
                bayikod = " GMREF = " + GMREF.ToString() + " AND";
            }
            else
            {
                noktaad = "[NOKTAAD] AS NOKTAAD2";
                bayikod = " ";
            }

            string ay = string.Empty;
            if (Ay != 0)
                ay = " NOKTASATAY = " + Ay.ToString() + " AND";

            string yil = string.Empty;
            if (Yil != 0)
                yil = " NOKTASATYIL = " + Yil.ToString() + " AND";

            string reykod = Bolum == 0 ? string.Empty : Bolum == 1 ? " [REY KOD] = 'T2' AND" : " [REY KOD] != 'T2' AND";

            string where = bayikod != string.Empty || ay != string.Empty || yil != string.Empty || reykod != string.Empty ? " WHERE" + (bayikod + ay + yil + reykod).Substring(0, (bayikod + ay + yil + reykod).Length - 4) : string.Empty;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    "SELECT REF,GMREF,[BAYIKOD],BAYIUNVAN,BOLGE,SEHIR,[NOKTAAD]," + noktaad + ",[NOKTAEVRAKNO],[NOKTAEVREKTARIH],[URUNKOD],CASE WHEN GRUPKOD = 'STG-1' THEN 'KGT' WHEN GRUPKOD = 'STG-2' THEN 'NF' ELSE 'DİĞER' END AS GRUPKOD,CASE WHEN OZELKOD = 'T4' THEN 'ARI' WHEN OZELKOD = 'T1' THEN 'TİBET' WHEN OZELKOD = 'T3' THEN 'HAYAT' WHEN OZELKOD = 'T2' THEN 'NON-FOOD' ELSE 'DİĞER' END AS KATEGORI,[URUNAD],KDV,KOLI,[NOKTASATADET],[NOKTASATADET] / KOLI AS NOKTASATKOLI,[NOKTASATAY],[NOKTASATYIL],intAnlasmaID,intAktiviteID,[NOKTASATNET],[NOKTASATNET] * [NOKTASATADET] AS NOKTASATNETT,flIsk1,flIsk2,flIsk3,flIsk4,mnListeFiyat,mnListeFiyat * [NOKTASATADET] AS mnListeFiyatT," +
                    "dbo.ListeFiyatiGetirTP(22, [NOKTASATYIL], NOKTASATAY, DAY(NOKTAEVREKTARIH), [URUNKOD]) AS BAYISATIS," +
                    "dbo.ListeFiyatiGetirTP(22, [NOKTASATYIL], NOKTASATAY, DAY(NOKTAEVREKTARIH), [URUNKOD]) AS BAYISATIST," +
                    "([NOKTASATNET] * [NOKTASATADET]) - (mnListeFiyat * [NOKTASATADET]) AS BUTCE,(mnListeFiyat * [NOKTASATADET]) * CASE WHEN GRUPKOD = 'STG-1' THEN (SELECT TAH_KAR FROM [Web-Musteri-TP-Ek2] WHERE GMREF = [vw_Web-Satis-Rapor-TP].GMREF AND YIL = " + Yil.ToString() + " AND AY = " + Ay.ToString() + ") ELSE (SELECT YEG_KAR FROM [Web-Musteri-TP-Ek2] WHERE GMREF = [vw_Web-Satis-Rapor-TP].GMREF AND YIL = " + Yil.ToString() + " AND AY = " + Ay.ToString() + ") END / 100 AS BAYIKAR,([NOKTASATNET] * [NOKTASATADET]) - (mnListeFiyat * [NOKTASATADET]) - ((mnListeFiyat * [NOKTASATADET]) * CASE WHEN GRUPKOD = 'STG-1' THEN (SELECT TAH_KAR FROM [Web-Musteri-TP-Ek2] WHERE GMREF = [vw_Web-Satis-Rapor-TP].GMREF AND YIL = " + Yil.ToString() + " AND AY = " + Ay.ToString() + ") ELSE (SELECT YEG_KAR FROM [Web-Musteri-TP-Ek2] WHERE GMREF = [vw_Web-Satis-Rapor-TP].GMREF AND YIL = " + Yil.ToString() + " AND AY = " + Ay.ToString() + ") END / 100) AS KALANBUTCE,mnListeFiyatKarli,mnListeFiyatKarli * [NOKTASATADET] AS mnListeFiyatKarliT,mnNetBirimFiyat,mnNetToplam,CASE WHEN [NOKTASATNET] < mnNetBirimFiyat THEN mnNetBirimFiyat - [NOKTASATNET] ELSE 0 END AS KARSFARK,CASE WHEN [NOKTASATNET] < mnNetBirimFiyat THEN (mnNetBirimFiyat - [NOKTASATNET]) * [NOKTASATADET] ELSE 0 END AS KARSFARKTOPLAM,CASE WHEN [NOKTASATNET] < mnNetBirimFiyat AND mnNetBirimFiyat != 0 THEN ((mnNetBirimFiyat - [NOKTASATNET]) * 100 / mnNetBirimFiyat) / 100 ELSE 0 END AS KARSFARKYUZDE,CASE WHEN [NOKTASATNET] > mnNetBirimFiyat AND [NOKTASATADET] > 0 THEN BAYIFIYATFARK * -1 ELSE 0 END AS KARSFARK1,CASE WHEN [NOKTASATNET] > mnNetBirimFiyat AND [NOKTASATADET] > 0 THEN BAYIFIYATFARK * -1 * [NOKTASATADET] ELSE 0 END AS KARSFARK1TOPLAM,BAYIFIYATFARK AS FARK,BAYIFIYATFARK * [NOKTASATADET] AS FARKTOPLAM,CASE WHEN [NOKTASATADET] > 0 AND mnNetBirimFiyat >= [NOKTASATNET] THEN BAYIFIYATFARK * [NOKTASATADET] ELSE 0 END AS ALTINDA,CASE WHEN [NOKTASATADET] > 0 AND mnNetBirimFiyat < [NOKTASATNET] THEN BAYIFIYATFARK * [NOKTASATADET] ELSE 0 END AS USTUNDE,mnBirimFark,CASE WHEN GRUPKOD = 'STG-1' THEN mnToplamFark ELSE 0 END AS TAHmnToplamFark,CASE WHEN GRUPKOD = 'STG-2' THEN mnToplamFark ELSE 0 END AS YEGmnToplamFark,mnToplamFark,blGeriyeDonuk,mnFaturadanKapatilan,intFaturaID,NOKTAREF,NOKTAKOD,0 AS Degistirildi,NOKTAREF FROM [vw_Web-Satis-Rapor-TP]" + where + " ORDER BY BOLGE,BAYIUNVAN,NOKTAAD,URUNAD", conn);
                da.SelectCommand.CommandTimeout = 200;
                try
                {
                    conn.Open();
                    da.Fill(dt);
                }
                catch (SqlException ex)
                {
                    Hatalar.DoInsert(ex);
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        ///// <summary>
        ///// GMREF = 0 ise dahil değil -1 ise sultanlar
        ///// </summary>
        ///// <returns>0 tahtoplam, 1 yegtoplam</returns>
        //public static decimal[] GetToplamlar(int GMREF, byte Ay, short Yil)
        //{
        //    decimal[] donendeger = new decimal[2];
        //    donendeger[0] = 0;
        //    donendeger[1] = 0;

        //    string bayikod = string.Empty;
        //    if (GMREF == -1) // sultanlar
        //        bayikod = " BAYIKOD = '1001327'";
        //    else if (GMREF != 0)
        //        bayikod = " BAYIKOD = '" + CariHesaplarTP.GetBAYIKODByGMREF(GMREF) + "'";

        //    string ay = string.Empty;
        //    if (Ay != 0)
        //        ay = " AND AY = " + Ay.ToString();

        //    string yil = string.Empty;
        //    if (Yil != 0)
        //        yil = " AND YIL = " + Yil.ToString();

        //    using (SqlConnection conn = new SqlConnection(General.ConnectionString))
        //    {
        //        SqlCommand cmd = new SqlCommand("SELECT sum(TAHTOPLAM),sum(YEGTOPLAM) FROM [Web-Satis-Rapor-TP-BayiToplamlar] WHERE " + bayikod + ay + yil, conn);
        //        SqlDataReader dr;
        //        try
        //        {
        //            conn.Open();
        //            dr = cmd.ExecuteReader();
        //            if (dr.Read())
        //            {
        //                donendeger[0] = dr[0] != DBNull.Value ? Convert.ToDecimal(dr[0]) : 0;
        //                donendeger[1] = dr[1] != DBNull.Value ? Convert.ToDecimal(dr[1]) : 0;
        //            }
        //        }
        //        catch (SqlException ex)
        //        {
        //            Hatalar.DoInsert(ex);
        //        }
        //        finally
        //        {
        //            conn.Close();
        //        }
        //    }

        //    return donendeger;
        //}
        ///// <summary>
        ///// GMREF = 0 ise dahil değil -1 ise sultanlar
        ///// </summary>
        //public static void SetToplamlar(int GMREF, byte Ay, short Yil, decimal TAHTOPLAM, decimal YEGTOPLAM)
        //{
        //    string bayikod = GMREF != -1 ? CariHesaplarTP.GetBAYIKODByGMREF(GMREF) : "1001327";

        //    using (SqlConnection conn = new SqlConnection(General.ConnectionString))
        //    {
        //        SqlCommand cmd = new SqlCommand("", conn);

        //        if (ExistToplamlar(GMREF, Ay, Yil))
        //            cmd.CommandText = "UPDATE [Web-Satis-Rapor-TP-BayiToplamlar] SET TAHTOPLAM=@TAHTOPLAM,YEGTOPLAM=@YEGTOPLAM WHERE GMREF=@GMREF AND BAYIKOD = @BAYIKOD AND YIL=@YIL AND AY=@AY";
        //        else
        //            cmd.CommandText = "INSERT INTO [Web-Satis-Rapor-TP-BayiToplamlar] (GMREF,BAYIKOD,YIL,AY,TAHTOPLAM,YEGTOPLAM) VALUES (@GMREF,@BAYIKOD,@YIL,@AY,@TAHTOPLAM,@YEGTOPLAM)";

        //        cmd.Parameters.Add("@GMREF", SqlDbType.Int).Value = GMREF;
        //        cmd.Parameters.Add("@BAYIKOD", SqlDbType.NVarChar).Value = bayikod;
        //        cmd.Parameters.Add("@YIL", SqlDbType.SmallInt).Value = Yil;
        //        cmd.Parameters.Add("@AY", SqlDbType.TinyInt).Value = Ay;
        //        cmd.Parameters.Add("@TAHTOPLAM", SqlDbType.Money).Value = TAHTOPLAM;
        //        cmd.Parameters.Add("@YEGTOPLAM", SqlDbType.Money).Value = YEGTOPLAM;
        //        try
        //        {
        //            conn.Open();
        //            cmd.ExecuteNonQuery();
        //        }
        //        catch (SqlException ex)
        //        {
        //            Hatalar.DoInsert(ex);
        //        }
        //        finally
        //        {
        //            conn.Close();
        //        }
        //    }
        //}
        ///// <summary>
        ///// 
        ///// </summary>
        //private static bool ExistToplamlar(int GMREF, byte Ay, short Yil)
        //{
        //    bool donendeger = false;

        //    string bayikod = GMREF != -1 ? CariHesaplarTP.GetBAYIKODByGMREF(GMREF) : "1001327";

        //    using (SqlConnection conn = new SqlConnection(General.ConnectionString))
        //    {
        //        SqlCommand cmd = new SqlCommand("SELECT count(*) FROM [Web-Satis-Rapor-TP-BayiToplamlar] WHERE GMREF = @GMREF AND BAYIKOD = @BAYIKOD AND YIL = @YIL AND AY = @AY", conn);
        //        cmd.Parameters.Add("@GMREF", SqlDbType.Int).Value = GMREF;
        //        cmd.Parameters.Add("@BAYIKOD", SqlDbType.NVarChar).Value = bayikod;
        //        cmd.Parameters.Add("@YIL", SqlDbType.SmallInt).Value = Yil;
        //        cmd.Parameters.Add("@AY", SqlDbType.TinyInt).Value = Ay;
        //        try
        //        {
        //            conn.Open();
        //            object obj = cmd.ExecuteScalar();
        //            if (obj != null)
        //                donendeger = Convert.ToBoolean(obj);
        //        }
        //        catch (SqlException ex)
        //        {
        //            Hatalar.DoInsert(ex);
        //        }
        //        finally
        //        {
        //            conn.Close();
        //        }
        //    }

        //    return donendeger;
        //}
        //
        //
        public static SatisRaporTP GetObject(long REF)
        {
            SatisRaporTP donendeger = new SatisRaporTP();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT REF,[BAYIKOD],[NOKTAAD],[NOKTAEVRAKNO],[NOKTAEVREKTARIH],[URUNKOD],[URUNAD],[NOKTASATADET],[NOKTASATNET],[NOKTASATAY],[NOKTASATYIL],intAnlasmaID,intAktiviteID,flIsk1,flIsk2,flIsk3,flIsk4,mnListeFiyat,mnListeFiyatKarli,mnNetBirimFiyat,mnNetToplam,mnBirimFark,mnToplamFark,blGeriyeDonuk,mnFaturadanKapatilan,intFaturaID,NOKTAKOD FROM [Web-Satis-Rapor-TP] WHERE [REF] = @REF", conn);
                cmd.Parameters.Add("@REF", SqlDbType.BigInt).Value = REF;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        donendeger = new SatisRaporTP(Convert.ToInt64(dr[0]), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(),
                            Convert.ToDateTime(dr[4]),
                            dr[5].ToString(), dr[6].ToString(), Convert.ToInt32(dr[7]), Convert.ToDecimal(dr[8]), Convert.ToByte(dr[9]),
                            Convert.ToInt16(dr[10]), Convert.ToInt32(dr[11]), Convert.ToInt32(dr[12]), Convert.ToDouble(dr[13]),
                            Convert.ToDouble(dr[14]), Convert.ToDouble(dr[15]), Convert.ToDouble(dr[16]), Convert.ToDecimal(dr[17]), 
                            Convert.ToDecimal(dr[18]), Convert.ToDecimal(dr[19]),
                            Convert.ToDecimal(dr[20]), Convert.ToDecimal(dr[21]), Convert.ToDecimal(dr[22]),
                            Convert.ToBoolean(dr[23]), Convert.ToDecimal(dr[24]), Convert.ToInt32(dr[25]), "", dr[26].ToString());
                    }
                }
                catch (SqlException ex)
                {
                    Hatalar.DoInsert(ex);
                }
                finally
                {
                    conn.Close();
                }
            }

            return donendeger;
        }
        //
        public static void GetNoktalar(IList List, string BAYIKOD, short Yil, byte Ay, string Nokta)
        {
            List.Clear();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT DISTINCT [BAYIKOD],[NOKTAAD],NOKTAKOD FROM [Web-Satis-Rapor-TP] WHERE BAYIKOD = @BAYIKOD AND NOKTAAD LIKE '%" + Nokta + "%' ORDER BY [NOKTAAD]", conn);
                cmd.Parameters.Add("@BAYIKOD", SqlDbType.NVarChar).Value = BAYIKOD;
                //cmd.Parameters.Add("@NOKTASATAY", SqlDbType.TinyInt).Value = Ay;
                //cmd.Parameters.Add("@NOKTASATYIL", SqlDbType.SmallInt).Value = Yil;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        List.Add(new SatisRaporTP(0, dr[0].ToString(), dr[1].ToString(), "", DateTime.Now,
                            "", "", 0, 0, 0, 0,0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, false, 0, 0, "", dr[2].ToString()));
                    }
                }
                catch (SqlException ex)
                {
                    Hatalar.DoInsert(ex);
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        //
        public static void GetNoktalar(IList List, int Noktaref)
        {
            List.Clear();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT DISTINCT [BAYIKOD],[NOKTAAD],NOKTAKOD FROM [Web-Satis-Rapor-TP] WHERE NOKTAREF = " + Noktaref + " ORDER BY [NOKTAAD]", conn);
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        List.Add(new SatisRaporTP(0, dr[0].ToString(), dr[1].ToString(), "", DateTime.Now,
                            "", "", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, false, 0, 0, "", dr[2].ToString()));
                    }
                }
                catch (SqlException ex)
                {
                    Hatalar.DoInsert(ex);
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        //
        //
        public static bool VarMi(string BAYIKOD, string NOKTAAD)
        {
            bool donendeger = false;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT count(*) FROM [Web-Satis-Rapor-TP] WHERE BAYIKOD = @BAYIKOD AND NOKTAAD = @NOKTAAD", conn);
                cmd.Parameters.Add("@BAYIKOD", SqlDbType.NVarChar, 7).Value = BAYIKOD;
                cmd.Parameters.Add("@NOKTAAD", SqlDbType.NVarChar).Value = NOKTAAD;
                try
                {
                    conn.Open();
                    donendeger = Convert.ToBoolean(cmd.ExecuteScalar());
                }
                catch (SqlException ex)
                {
                    Hatalar.DoInsert(ex);
                }
                finally
                {
                    conn.Close();
                }
            }

            return donendeger;
        }
        //
        //
        public static bool VarMi(string NOKTAKOD)
        {
            bool donendeger = false;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT count(*) FROM [Web-Satis-Rapor-TP] WHERE NOKTAKOD = @NOKTAKOD", conn);
                cmd.Parameters.Add("@NOKTAKOD", SqlDbType.NVarChar).Value = NOKTAKOD;
                try
                {
                    conn.Open();
                    donendeger = Convert.ToBoolean(cmd.ExecuteScalar());
                }
                catch (SqlException ex)
                {
                    Hatalar.DoInsert(ex);
                }
                finally
                {
                    conn.Close();
                }
            }

            return donendeger;
        }
        //
        //
        public static bool VarMi(int NOKTAREF)
        {
            bool donendeger = false;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT count(*) FROM [Web-Satis-Rapor-TP] WHERE NOKTAREF = @NOKTAREF", conn);
                cmd.Parameters.Add("@NOKTAREF", SqlDbType.Int).Value = NOKTAREF;
                try
                {
                    conn.Open();
                    donendeger = Convert.ToBoolean(cmd.ExecuteScalar());
                }
                catch (SqlException ex)
                {
                    Hatalar.DoInsert(ex);
                }
                finally
                {
                    conn.Close();
                }
            }

            return donendeger;
        }
        //
        //
        public static int GetSatirSayisiByAnlasmaID(int AnlasmaID)
        {
            int donendeger = 0;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT count(*) FROM [Web-Satis-Rapor-TP] WHERE intAnlasmaID = @intAnlasmaID", conn);
                cmd.Parameters.Add("@intAnlasmaID", SqlDbType.Int).Value = AnlasmaID;
                try
                {
                    conn.Open();
                    object obj = cmd.ExecuteScalar();
                    if (obj != null)
                        donendeger = Convert.ToInt32(obj);
                }
                catch (SqlException ex)
                {
                    Hatalar.DoInsert(ex);
                }
                finally
                {
                    conn.Close();
                }
            }

            return donendeger;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="Kactan"></param>
        /// <param name="KacaKadar"></param>
        /// <param name="YEG">1: YEG, 2: TAH, 0: hepsi</param>
        public static void Hesapla(DataTable dt, int Kactan, int KacaKadar, int YEG)
        {
            string olmayanurunler = string.Empty;
            string fiyatiolmayanurunler = string.Empty;
            ArrayList hesaplanamayansatirlar = new ArrayList();

            decimal ToplamTAH = 0;
            decimal ToplamYEG = 0;

            for (int i = Kactan; i < KacaKadar; i++)
            {
                double kar = 0;
                double isk1 = 0;
                double isk2 = 0;
                double isk3 = 0;
                double isk4 = 0;

                object objTAH = null;
                int UrunID = Convert.ToInt32(dt.Rows[i]["URUNKOD"].ToString());

                string grupkod = Urunler.GetProductGRPKOD(UrunID.ToString());
                string reykod = Urunler.GetProductReyKod(UrunID);
                if (grupkod == "STG-1")
                    objTAH = true;
                else if (grupkod == "STG-2")
                    objTAH = false;
                else if (grupkod == string.Empty)
                    olmayanurunler += "(" + UrunID.ToString() + ") " + dt.Rows[i]["URUNAD"].ToString() + "\r\n";

                int noktasatyil = Convert.ToInt32(dt.Rows[i]["NOKTASATYIL"]);
                int noktasatay = Convert.ToInt32(dt.Rows[i]["NOKTASATAY"]);
                int noktasatgun = Convert.ToDateTime(dt.Rows[i]["NOKTAEVREKTARIH"]).Day;
                DateTime noktaevraktarih = Convert.ToDateTime(dt.Rows[i]["NOKTAEVREKTARIH"]);

                bool otobayi = false;
                DataTable dtOtoBayiler = new DataTable();
                WebGenel.Sorgu(dtOtoBayiler, "SELECT [BAYIKOD] FROM [Web-Musteri-TP-Bayikodlar] WHERE TAMOTO = 1");
                for (int j = 0; j < dtOtoBayiler.Rows.Count; j++)
                {
                    if (dtOtoBayiler.Rows[j]["BAYIKOD"].ToString() == dt.Rows[i]["GMREF"].ToString())
                    {
                        otobayi = true;
                        isk1 = Convert.ToDouble(dt.Rows[i]["flIsk1"]);
                        isk2 = Convert.ToDouble(dt.Rows[i]["flIsk2"]);
                        isk3 = Convert.ToDouble(dt.Rows[i]["flIsk3"]);
                        isk4 = Convert.ToDouble(dt.Rows[i]["flIsk4"]);
                        break;
                    }
                }

                if (otobayi == false)
                {
                    bool TAH = objTAH != null ? Convert.ToBoolean(objTAH) : false;
                    if (objTAH != null && ((reykod == "T2" && YEG == 1) || (reykod != "T2" && YEG == 2) || YEG == 0)) // ürünün bizde karşılığı varsa, ve yeg mi aht mi hesaplamasi yapılıyorsa
                    {
                        bool karTAH = Urunler.GetProductReyKod(UrunID) == "T2" ? false : true;

                        kar = karTAH ? CariHesaplarTPEk2.GetObject(Convert.ToInt32(dt.Rows[i]["GMREF"]), noktasatyil, noktasatay).TAH_KAR : CariHesaplarTPEk2.GetObject(Convert.ToInt32(dt.Rows[i]["GMREF"]), noktasatyil, noktasatay).YEG_KAR;

                        int SMREF = dt.Rows[i]["NOKTAREF"].ToString() != string.Empty ? Convert.ToInt32(dt.Rows[i]["NOKTAREF"]) : 0;
                        if (SMREF == 0)
                            SMREF = dt.Rows[i]["NOKTAKOD"].ToString() != string.Empty ?
                                CariHesaplarTP.GetSMREFByMUSKOD(Convert.ToInt32(dt.Rows[i]["GMREF"]), dt.Rows[i]["NOKTAKOD"].ToString())
                                : CariHesaplarTP.GetSMREFBySUBE(Convert.ToInt32(dt.Rows[i]["GMREF"]), dt.Rows[i]["NOKTAAD"].ToString().ToUpper());

                        long aktivitedetayid = AktivitelerDetay.GetTarihAraligiAktivitelerDetayID(
                            SMREF,
                            UrunID.ToString(),
                            noktaevraktarih,
                            25);
                        int anlasmaid = Anlasmalar.GetSonAnlasmaID(SMREF, noktaevraktarih, "1");

                        if (aktivitedetayid > 0)
                        {
                            if (aktivitedetayid > 1000000000) // geriye dönük ise +1000000000
                            {
                                dt.Rows[i]["blGeriyeDonuk"] = true;
                                aktivitedetayid = aktivitedetayid - 1000000000;
                            }

                            AktivitelerDetay aktlerdet = AktivitelerDetay.GetObject(aktivitedetayid);
                            isk1 = Convert.ToDouble(aktlerdet.strAciklama1);
                            isk2 = Convert.ToDouble(aktlerdet.strAciklama2);
                            isk3 = Convert.ToDouble(aktlerdet.strAciklama3);
                            isk4 = aktlerdet.flEkIsk;

                            dt.Rows[i]["intAnlasmaID"] = Aktiviteler.GetObject(aktlerdet.intAktiviteID).intAnlasmaID;
                            dt.Rows[i]["intAktiviteID"] = aktlerdet.intAktiviteID;
                        }
                        else if (anlasmaid > 0) // aktivitesiz anlaşmalı ise
                        {
                            Anlasmalar anlasma = Anlasmalar.GetObject(anlasmaid);
                            isk1 = TAH ? anlasma.flTAHIsk : anlasma.flYEGIsk;
                            isk2 = TAH ? anlasma.flTAHCiroIsk : anlasma.flYEGCiroIsk;
                            isk3 = Convert.ToDouble(
                                    FiyatlarTP.GetIskFiyat(UrunID, 3, 25,
                                    noktasatyil,
                                    noktasatay,
                                    noktasatgun));

                            dt.Rows[i]["intAnlasmaID"] = anlasma.pkID;
                            dt.Rows[i]["intAktiviteID"] = 0;

                            if (isk1 == 0 && isk2 == 0) anlasmaid = 0; // anlaşma sadece tah veya sadece yeg ise diğerini kapsamasın, alttaki genel anlaşmasıza düşsün
                            if (anlasma.flTAHIsk == 0 && anlasma.flYEGIsk == 0) anlasmaid = anlasma.pkID; // tah ve yeg yoksa anlaşma tah yada yeg için geçerlidir o yüzden genel anlaşmasıza düşmesin
                        }

                        if (aktivitedetayid == 0 && anlasmaid == 0) // genel anlaşmasız aktivite
                        {
                            int GMREF = Convert.ToInt32(dt.Rows[i]["GMREF"]);

                            aktivitedetayid = AktivitelerDetay.GetTarihAraligiAktivitelerDetayID(GMREF,
                                UrunID.ToString(),
                                noktaevraktarih,
                                25);

                            if (aktivitedetayid > 0)
                            {
                                if (aktivitedetayid > 1000000000) // geriye dönük ise +1000000000
                                {
                                    dt.Rows[i]["blGeriyeDonuk"] = true;
                                    aktivitedetayid = aktivitedetayid - 1000000000;
                                }

                                AktivitelerDetay aktlerdet = AktivitelerDetay.GetObject(aktivitedetayid);
                                isk1 = Convert.ToDouble(aktlerdet.strAciklama1);
                                isk2 = Convert.ToDouble(aktlerdet.strAciklama2);
                                isk3 = Convert.ToDouble(aktlerdet.strAciklama3);
                                isk4 = aktlerdet.flEkIsk;

                                dt.Rows[i]["intAnlasmaID"] = Aktiviteler.GetObject(aktlerdet.intAktiviteID).intAnlasmaID;
                                dt.Rows[i]["intAktiviteID"] = aktlerdet.intAktiviteID;
                            }
                            else // standart uygulama
                            {
                                CariHesaplarTP cari = CariHesaplarTP.GetObject(SMREF, false);
                                int tur = cari.MTKOD == "B1" ? 2 : 1;

                                bool otoiskonto = true;
                                DataTable dtHaricBayiler = new DataTable();
                                WebGenel.Sorgu(dtHaricBayiler, "SELECT BAYIKOD FROM [Web-Fiyat-Aktivite-Kontrol-Haric]");
                                for (int j = 0; j < dtHaricBayiler.Rows.Count; j++)
                                {
                                    if (dtHaricBayiler.Rows[j]["BAYIKOD"].ToString() == dt.Rows[i]["GMREF"].ToString())
                                    {
                                        otoiskonto = false;
                                        break;
                                    }
                                }

                                if (otoiskonto)
                                {
                                    DataTable dtS = WebGenel.WCFdata("SELECT TOP 1 ISK1 FROM [Web-Fiyat-TP-Donem] WHERE TUR = @TUR AND ITEMREF = @ITEMREF AND BASLANGIC <= @FATURA AND BITIS >= @FATURA ORDER BY BASLANGIC DESC",
                                        new ArrayList() { "TUR", "ITEMREF", "FATURA" }, new SqlDbType[] { SqlDbType.Int, SqlDbType.Int, SqlDbType.DateTime }, new ArrayList() { tur, UrunID, noktaevraktarih }, "");
                                    isk4 = dtS.Rows.Count > 0 ? Convert.ToDouble(dtS.Rows[0][0]) : 0;
                                }


                                CariHesaplarTPEk2 chtpek = CariHesaplarTPEk2.GetObject(GMREF, noktasatyil, noktasatay);
                                isk1 = TAH ? chtpek.TAH_ISK : chtpek.YEG_ISK;
                                isk2 = 0;
                                isk3 = Convert.ToDouble(
                                    FiyatlarTP.GetIskFiyat(UrunID, 3, 25,
                                    noktasatyil,
                                    noktasatay,
                                    noktasatgun));

                                dt.Rows[i]["intAnlasmaID"] = 0;
                                dt.Rows[i]["intAktiviteID"] = 0;
                            }
                        }



                        dt.Rows[i]["flIsk1"] = isk1;
                        dt.Rows[i]["flIsk2"] = isk2;
                        dt.Rows[i]["flIsk3"] = isk3;
                        dt.Rows[i]["flIsk4"] = isk4;



                        // bayinin alımı
                        double listefiyat = Convert.ToDouble(FiyatlarTP.GetNetFiyat(
                            UrunID,
                            (short)22,
                            noktasatyil,
                            noktasatay,
                            noktasatgun));
                        if (listefiyat == 0.0)
                        {
                            listefiyat = Convert.ToDouble(Urunler.GetProductNetFiyatFULL(
                                UrunID,
                                (short)22
                                ));
                        }



                        // brüt fiyat, aktivitenin hesaplanacagi fiyat
                        double listefiyat1 = 0.0;
                        if (listefiyat1 == 0.0)
                        {
                            listefiyat1 = Convert.ToDouble(FiyatlarTP.GetFiyat(
                                UrunID,
                                (short)22,
                                noktasatyil,
                                noktasatay,
                                noktasatgun));
                        }
                        /*else */
                        if (listefiyat1 == 0.0) // dönem fiyatı yoksa şimdiki fiyatı al
                        {
                            listefiyat1 = Convert.ToDouble(Urunler.GetProductDiscountsAndPriceFULL(
                                UrunID,
                                (short)22
                                )[4]);
                        }

                        if (listefiyat == 0 || listefiyat1 == 0)
                        {
                            fiyatiolmayanurunler += "(" + UrunID.ToString() + ") " + dt.Rows[i]["URUNAD"].ToString() + "\r\n";
                            hesaplanamayansatirlar.Add(i);
                        }

                        double karlifiyat = listefiyat * ((100 + kar) / 100);

                        double bayifiyat = Convert.ToDouble(dt.Rows[i]["NOKTASATNET"]);

                        int bayiadet = Convert.ToInt32(dt.Rows[i]["NOKTASATADET"]);

                        double olmasigereken = listefiyat1 - ((listefiyat1 / 100) * isk1);
                        olmasigereken = olmasigereken - ((olmasigereken / 100) * isk2);
                        olmasigereken = olmasigereken - ((olmasigereken / 100) * isk3);
                        olmasigereken = olmasigereken - ((olmasigereken / 100) * isk4);

                        dt.Rows[i]["mnListeFiyat"] = listefiyat;
                        dt.Rows[i]["mnListeFiyatT"] = listefiyat * bayiadet;
                        dt.Rows[i]["mnListeFiyatKarli"] = karlifiyat;
                        dt.Rows[i]["mnListeFiyatKarliT"] = karlifiyat * bayiadet;

                        dt.Rows[i]["mnNetBirimFiyat"] = olmasigereken;
                        dt.Rows[i]["mnNetToplam"] = olmasigereken * bayiadet;

                        if (UrunID > 0 && listefiyat != 0.0 && listefiyat1 != 0.0)
                        {
                            if (bayifiyat >= olmasigereken)
                            {
                                dt.Rows[i]["mnBirimFark"] = bayifiyat - karlifiyat; //olmasigereken - bayifiyat
                                dt.Rows[i]["mnToplamFark"] = (bayifiyat - karlifiyat) * bayiadet; //(olmasigereken - bayifiyat) * bayiadet
                            }
                            else if (bayifiyat < olmasigereken)
                            {
                                dt.Rows[i]["mnBirimFark"] = olmasigereken - karlifiyat; //karlifiyat - olmasigereken
                                dt.Rows[i]["mnToplamFark"] = (olmasigereken - karlifiyat) * bayiadet;
                            }
                        }
                        else
                        {
                            dt.Rows[i]["mnBirimFark"] = 0;
                            dt.Rows[i]["mnToplamFark"] = 0;
                        }

                        decimal tahtoplam = TAH ? Convert.ToDecimal(dt.Rows[i]["mnToplamFark"]) : 0;
                        decimal yegtoplam = TAH ? 0 : Convert.ToDecimal(dt.Rows[i]["mnToplamFark"]);

                        ToplamTAH += tahtoplam;
                        ToplamYEG += yegtoplam;

                        dt.Rows[i]["TAHmnToplamFark"] = tahtoplam;
                        dt.Rows[i]["YEGmnToplamFark"] = yegtoplam;
                    }
                }
            }
        }

        public static void Kaydet(DataTable dt, int Kactan, int KacaKadar, int YEG)
        {
            for (int i = Kactan; i < KacaKadar; i++)
            {
                SatisRaporTP satisrapor = SatisRaporTP.GetObject(Convert.ToInt64(dt.Rows[i]["REF"]));
                string bolum = Urunler.GetProductReyKod(Convert.ToInt32(satisrapor.URUNKOD));
                if ((YEG == 1 && bolum == "T2") || (YEG == 2 && bolum != "T2") || (YEG == 0))
                {
                    satisrapor.intAnlasmaID = Convert.ToInt32(dt.Rows[i]["intAnlasmaID"]);
                    satisrapor.intAktiviteID = Convert.ToInt32(dt.Rows[i]["intAktiviteID"]);
                    satisrapor.flIsk1 = Convert.ToDouble(dt.Rows[i]["flIsk1"]);
                    satisrapor.flIsk2 = Convert.ToDouble(dt.Rows[i]["flIsk2"]);
                    satisrapor.flIsk3 = Convert.ToDouble(dt.Rows[i]["flIsk3"]);
                    satisrapor.flIsk4 = Convert.ToDouble(dt.Rows[i]["flIsk4"]);
                    satisrapor.mnListeFiyat = Convert.ToDecimal(dt.Rows[i]["mnListeFiyat"]);
                    satisrapor.mnListeFiyatKarli = Convert.ToDecimal(dt.Rows[i]["mnListeFiyatKarli"]);
                    satisrapor.mnNetBirimFiyat = Convert.ToDecimal(dt.Rows[i]["mnNetBirimFiyat"]);
                    satisrapor.mnNetToplam = Convert.ToDecimal(dt.Rows[i]["mnNetToplam"]);
                    satisrapor.mnBirimFark = Convert.ToDecimal(dt.Rows[i]["mnBirimFark"]);
                    satisrapor.mnToplamFark = Convert.ToDecimal(dt.Rows[i]["mnToplamFark"]);
                    satisrapor.blGeriyeDonuk = Convert.ToBoolean(dt.Rows[i]["blGeriyeDonuk"]);
                    satisrapor.mnFaturadanKapatilan = Convert.ToDecimal(dt.Rows[i]["mnFaturadanKapatilan"]);
                    satisrapor.intFaturaID = Convert.ToInt32(dt.Rows[i]["intFaturaID"]);
                    satisrapor.DoUpdate();
                }
            }
        }
    }
}

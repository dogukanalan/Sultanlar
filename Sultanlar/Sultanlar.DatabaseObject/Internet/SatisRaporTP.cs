using System;
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
            bool blGeriyeDonuk, decimal mnFaturadanKapatilan, int intFaturaID, string IL)
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
        }
        //
        //
        public SatisRaporTP(string BAYIKOD, string NOKTAAD, string NOKTAEVRAKNO, DateTime NOKTAEVREKTARIH, string URUNKOD,
            string URUNAD, int NOKTASATADET, decimal NOKTASATNET, byte NOKTASATAY, short NOKTASATYIL, 
            int intAnlasmaID, int intAktiviteID, double flIsk1, double flIsk2, double flIsk3, double flIsk4, decimal mnListeFiyat, decimal mnListeFiyatKarli,
            decimal mnNetBirimFiyat, decimal mnNetToplam, decimal mnBirimFark, decimal mnToplamFark,
            bool blGeriyeDonuk, decimal mnFaturadanKapatilan, int intFaturaID, string IL)
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
            return "(" + this._BAYIKOD + ") "+ this._NOKTAAD.ToString();
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
                SqlCommand cmd = new SqlCommand("INSERT INTO [Web-Satis-Rapor-TP] ([BAYIKOD],[NOKTAAD],[NOKTAEVRAKNO],[NOKTAEVREKTARIH],[URUNKOD],[URUNAD],[NOKTASATADET],[NOKTASATNET],[NOKTASATAY],[NOKTASATYIL],intAnlasmaID,intAktiviteID,flIsk1,flIsk2,flIsk3,flIsk4,mnListeFiyat,mnListeFiyatKarli,mnNetBirimFiyat,mnNetToplam,mnBirimFark,mnToplamFark,blGeriyeDonuk,mnFaturadanKapatilan,intFaturaID) VALUES (@BAYIKOD,@NOKTAAD,@NOKTAEVRAKNO,@NOKTAEVREKTARIH,@URUNKOD,@URUNAD,@NOKTASATADET,@NOKTASATNET,@NOKTASATAY,@NOKTASATYIL,@intAnlasmaID,@intAktiviteID,@flIsk1,@flIsk2,@flIsk3,@flIsk4,@mnListeFiyat,@mnListeFiyatKarli,@mnNetBirimFiyat,@mnNetToplam,@mnBirimFark,@mnToplamFark,@blGeriyeDonuk,@mnFaturadanKapatilan,@intFaturaID) SELECT @REF = SCOPE_IDENTITY()", conn);
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
                SqlCommand cmd = new SqlCommand("UPDATE [Web-Satis-Rapor-TP] SET [BAYIKOD] = @BAYIKOD,[NOKTAAD] = @NOKTAAD,[NOKTAEVRAKNO] = @NOKTAEVRAKNO,[NOKTAEVREKTARIH] = @NOKTAEVREKTARIH,[URUNKOD] = @URUNKOD,[URUNAD] = @URUNAD,[NOKTASATADET] = @NOKTASATADET,[NOKTASATNET] = @NOKTASATNET,[NOKTASATAY] = @NOKTASATAY,[NOKTASATYIL] = @NOKTASATYIL, intAnlasmaID = @intAnlasmaID, intAktiviteID = @intAktiviteID, flIsk1 = @flIsk1, flIsk2 = @flIsk2, flIsk3 = @flIsk3, flIsk4 = @flIsk4,mnListeFiyat=@mnListeFiyat,mnListeFiyatKarli=@mnListeFiyatKarli,mnNetBirimFiyat=@mnNetBirimFiyat,mnNetToplam=@mnNetToplam,mnBirimFark=@mnBirimFark,mnToplamFark=@mnToplamFark,blGeriyeDonuk=@blGeriyeDonuk,mnFaturadanKapatilan=@mnFaturadanKapatilan,intFaturaID=@intFaturaID WHERE [REF] = @REF", conn);
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
        public static void DoDelete(string BAYIKOD, short Yil, byte Ay)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM [Web-Satis-Rapor-TP] WHERE BAYIKOD=@BAYIKOD AND NOKTASATYIL=@NOKTASATYIL AND NOKTASATAY=@NOKTASATAY", conn);
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
        public static void GetObjects(DataTable dt, int GMREF, byte Ay, short Yil)
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
                bayikod = " BAYIKOD != '1001327'  AND";
            }

            string ay = string.Empty;
            if (Ay != 0)
                ay = " NOKTASATAY = " + Ay.ToString() + " AND";

            string yil = string.Empty;
            if (Yil != 0)
                yil = " NOKTASATYIL = " + Yil.ToString() + " AND";

            string where = bayikod != string.Empty || ay != string.Empty || yil != string.Empty ? " WHERE" + (bayikod + ay + yil).Substring(0, (bayikod + ay + yil).Length - 4) : string.Empty;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                // 5. ay fiyatları 5. günden önce 4. ay fiyatlarını alsın diye alttakini yaptım tek fark o
                SqlDataAdapter da = new SqlDataAdapter(
                    "SELECT REF,GMREF,[BAYIKOD],BAYIUNVAN,BOLGE,SEHIR,[NOKTAAD]," + noktaad + ",[NOKTAEVRAKNO],[NOKTAEVREKTARIH],[URUNKOD],CASE WHEN GRUPKOD = 'STG-1' THEN 'KGT' WHEN GRUPKOD = 'STG-2' THEN 'NF' ELSE 'DİĞER' END AS GRUPKOD,CASE WHEN OZELKOD = 'T4' THEN 'ARI' WHEN OZELKOD = 'T1' THEN 'TİBET' WHEN OZELKOD = 'T3' THEN 'HAYAT' WHEN OZELKOD = 'T2' THEN 'NON-FOOD' ELSE 'DİĞER' END AS KATEGORI,[URUNAD],KDV,KOLI,[NOKTASATADET],[NOKTASATADET] / KOLI AS NOKTASATKOLI,[NOKTASATAY],[NOKTASATYIL],intAnlasmaID,intAktiviteID,[NOKTASATNET],[NOKTASATNET] * [NOKTASATADET] AS NOKTASATNETT,flIsk1,flIsk2,flIsk3,flIsk4,mnListeFiyat,mnListeFiyat * [NOKTASATADET] AS mnListeFiyatT," +
                    "CASE WHEN (SELECT FIYAT FROM [Web-Fiyat-TP] WHERE TIP = (CASE WHEN [BAYIKOD] = '1001327' OR BAYIKOD = '1000951' OR BAYIKOD = '1005405' THEN 7 ELSE 22 END) AND YIL = [vw_Web-Satis-Rapor-TP].[NOKTASATYIL] AND AY = [vw_Web-Satis-Rapor-TP].[NOKTASATAY] AND ITEMREF = [vw_Web-Satis-Rapor-TP].ITEMREF) IS NOT NULL THEN (SELECT FIYAT FROM [Web-Fiyat-TP] WHERE TIP = (CASE WHEN [BAYIKOD] = '1001327' OR BAYIKOD = '1000951' OR BAYIKOD = '1005405' THEN 7 ELSE 22 END) AND YIL = [vw_Web-Satis-Rapor-TP].[NOKTASATYIL] AND AY = [vw_Web-Satis-Rapor-TP].[NOKTASATAY] AND ITEMREF = [vw_Web-Satis-Rapor-TP].ITEMREF) ELSE (SELECT TOP 1 FIYAT FROM [Web-Fiyat-Full] WHERE TIP = (CASE WHEN [BAYIKOD] = '1001327' OR BAYIKOD = '1000951' OR BAYIKOD = '1005405' THEN 7 ELSE 22 END) AND ITEMREF = [vw_Web-Satis-Rapor-TP].ITEMREF ORDER BY FIYAT DESC) END AS BAYISATIS," +
                    "[NOKTASATADET] * CASE WHEN (SELECT FIYAT FROM [Web-Fiyat-TP] WHERE TIP = (CASE WHEN [BAYIKOD] = '1001327' OR BAYIKOD = '1000951' OR BAYIKOD = '1005405' THEN 7 ELSE 22 END) AND YIL = [vw_Web-Satis-Rapor-TP].[NOKTASATYIL] AND AY = [vw_Web-Satis-Rapor-TP].[NOKTASATAY] AND ITEMREF = [vw_Web-Satis-Rapor-TP].ITEMREF) IS NOT NULL THEN (SELECT FIYAT FROM [Web-Fiyat-TP] WHERE TIP = (CASE WHEN [BAYIKOD] = '1001327' OR BAYIKOD = '1000951' OR BAYIKOD = '1005405' THEN 7 ELSE 22 END) AND YIL = [vw_Web-Satis-Rapor-TP].[NOKTASATYIL] AND AY = [vw_Web-Satis-Rapor-TP].[NOKTASATAY] AND ITEMREF = [vw_Web-Satis-Rapor-TP].ITEMREF) ELSE (SELECT TOP 1 FIYAT FROM [Web-Fiyat-Full] WHERE TIP = (CASE WHEN [BAYIKOD] = '1001327' OR BAYIKOD = '1000951' OR BAYIKOD = '1005405' THEN 7 ELSE 22 END) AND ITEMREF = [vw_Web-Satis-Rapor-TP].ITEMREF ORDER BY FIYAT DESC) END AS BAYISATIST," +
                    "([NOKTASATNET] * [NOKTASATADET]) - (mnListeFiyat * [NOKTASATADET]) AS BUTCE,(mnListeFiyat * [NOKTASATADET]) * CASE WHEN GRUPKOD = 'STG-1' THEN (SELECT TAH_KAR FROM [Web-Musteri-TP-Ek2] WHERE GMREF = [vw_Web-Satis-Rapor-TP].GMREF AND YIL = " + Yil.ToString() + " AND AY = " + Ay.ToString() + ") ELSE (SELECT YEG_KAR FROM [Web-Musteri-TP-Ek2] WHERE GMREF = [vw_Web-Satis-Rapor-TP].GMREF AND YIL = " + Yil.ToString() + " AND AY = " + Ay.ToString() + ") END / 100 AS BAYIKAR,([NOKTASATNET] * [NOKTASATADET]) - (mnListeFiyat * [NOKTASATADET]) - ((mnListeFiyat * [NOKTASATADET]) * CASE WHEN GRUPKOD = 'STG-1' THEN (SELECT TAH_KAR FROM [Web-Musteri-TP-Ek2] WHERE GMREF = [vw_Web-Satis-Rapor-TP].GMREF AND YIL = " + Yil.ToString() + " AND AY = " + Ay.ToString() + ") ELSE (SELECT YEG_KAR FROM [Web-Musteri-TP-Ek2] WHERE GMREF = [vw_Web-Satis-Rapor-TP].GMREF AND YIL = " + Yil.ToString() + " AND AY = " + Ay.ToString() + ") END / 100) AS KALANBUTCE,mnListeFiyatKarli,mnListeFiyatKarli * [NOKTASATADET] AS mnListeFiyatKarliT,mnNetBirimFiyat,mnNetToplam,CASE WHEN [NOKTASATNET] < mnNetBirimFiyat THEN mnNetBirimFiyat - [NOKTASATNET] ELSE 0 END AS KARSFARK,CASE WHEN [NOKTASATNET] < mnNetBirimFiyat THEN (mnNetBirimFiyat - [NOKTASATNET]) * [NOKTASATADET] ELSE 0 END AS KARSFARKTOPLAM,CASE WHEN [NOKTASATNET] < mnNetBirimFiyat AND mnNetBirimFiyat != 0 THEN ((mnNetBirimFiyat - [NOKTASATNET]) * 100 / mnNetBirimFiyat) / 100 ELSE 0 END AS KARSFARKYUZDE,CASE WHEN [NOKTASATNET] > mnNetBirimFiyat AND [NOKTASATADET] > 0 THEN BAYIFIYATFARK * -1 ELSE 0 END AS KARSFARK1,CASE WHEN [NOKTASATNET] > mnNetBirimFiyat AND [NOKTASATADET] > 0 THEN BAYIFIYATFARK * -1 * [NOKTASATADET] ELSE 0 END AS KARSFARK1TOPLAM,BAYIFIYATFARK AS FARK,BAYIFIYATFARK * [NOKTASATADET] AS FARKTOPLAM,CASE WHEN [NOKTASATADET] > 0 AND mnNetBirimFiyat >= [NOKTASATNET] THEN BAYIFIYATFARK * [NOKTASATADET] ELSE 0 END AS ALTINDA,CASE WHEN [NOKTASATADET] > 0 AND mnNetBirimFiyat < [NOKTASATNET] THEN BAYIFIYATFARK * [NOKTASATADET] ELSE 0 END AS USTUNDE,mnBirimFark,CASE WHEN GRUPKOD = 'STG-1' THEN mnToplamFark ELSE 0 END AS TAHmnToplamFark,CASE WHEN GRUPKOD = 'STG-2' THEN mnToplamFark ELSE 0 END AS YEGmnToplamFark,mnToplamFark,blGeriyeDonuk,mnFaturadanKapatilan,intFaturaID,0 AS Degistirildi FROM [vw_Web-Satis-Rapor-TP]" + where + " ORDER BY BOLGE,BAYIUNVAN,NOKTAAD,URUNAD", conn);
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
                SqlCommand cmd = new SqlCommand("SELECT REF,[BAYIKOD],[NOKTAAD],[NOKTAEVRAKNO],[NOKTAEVREKTARIH],[URUNKOD],[URUNAD],[NOKTASATADET],[NOKTASATNET],[NOKTASATAY],[NOKTASATYIL],intAnlasmaID,intAktiviteID,flIsk1,flIsk2,flIsk3,flIsk4,mnListeFiyat,mnListeFiyatKarli,mnNetBirimFiyat,mnNetToplam,mnBirimFark,mnToplamFark,blGeriyeDonuk,mnFaturadanKapatilan,intFaturaID FROM [Web-Satis-Rapor-TP] WHERE [REF] = @REF", conn);
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
                            Convert.ToBoolean(dr[23]), Convert.ToDecimal(dr[24]), Convert.ToInt32(dr[25]), "");
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
                SqlCommand cmd = new SqlCommand("SELECT DISTINCT [NOKTAAD] FROM [Web-Satis-Rapor-TP] WHERE BAYIKOD = @BAYIKOD AND NOKTAAD LIKE '%" + Nokta + "%' ORDER BY [NOKTAAD]", conn);
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
                        List.Add(dr[0].ToString());
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
    }
}

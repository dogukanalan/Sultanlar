using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Collections;

namespace Sultanlar.DatabaseObject.Internet
{
    public class AktivitelerDetay : ISultanlar, IDisposable
    {
        //
        //
        //
        // Alanlar:
        //
        private long _pkID;
        private int _intAktiviteID;
        private int _intUrunID;
        private string _strUrunAdi;
        private int _intKoliAdet;
        private decimal _mnBirimFiyatKDVli;
        private decimal _mnAksiyonFiyati;
        private double _flMusteriKarYuzde;
        private string _strSatisHedefi;
        private decimal _mnTutar;
        private double _flEkIsk;
        private double _flCiroPrimDonusYuzde;
        private decimal _mnBayiMaliyet;
        private decimal _mnDusulmusBirimFiyatKDVli;
        private double _flKarZararYuzde;
        private decimal _mnToplam;
        private string _strAciklama1; //fatalt isk
        private string _strAciklama2; //fatalt ciro isk
        private string _strAciklama3; //paz isk
        private string _strAciklama4; //değiştirilmişse 1
        private string _strAciklama5; //değişiklik yapan ve tarih
        private string _strAciklama6; //değişiklik yapan ve tarih
        //
        //
        //
        // Constracter lar:
        //
        private AktivitelerDetay(long pkID, int intAktiviteID, int intUrunID, string strUrunAdi, int intKoliAdet, decimal mnBirimFiyatKDVli,
            decimal mnAksiyonFiyati, double flMusteriKarYuzde, string strSatisHedefi, decimal mnTutar, double flEkIsk, double flCiroPrimDonusYuzde,
            decimal mnBayiMaliyet, decimal mnDusulmusBirimFiyatKDVli, double flKarZararYuzde, decimal mnToplam, string strAciklama1,
            string strAciklama2, string strAciklama3, string strAciklama4, string strAciklama5, string strAciklama6)
        {
            this._pkID = pkID;
            this._intAktiviteID = intAktiviteID;
            this._intUrunID = intUrunID;
            this._strUrunAdi = strUrunAdi;
            this._intKoliAdet = intKoliAdet;
            this._mnBirimFiyatKDVli = mnBirimFiyatKDVli;
            this._mnAksiyonFiyati = mnAksiyonFiyati;
            this._flMusteriKarYuzde = flMusteriKarYuzde;
            this._strSatisHedefi = strSatisHedefi;
            this._mnTutar = mnTutar;
            this._flEkIsk = flEkIsk;
            this._flCiroPrimDonusYuzde = flCiroPrimDonusYuzde;
            this._mnBayiMaliyet = mnBayiMaliyet;
            this._mnDusulmusBirimFiyatKDVli = mnDusulmusBirimFiyatKDVli;
            this._flKarZararYuzde = flKarZararYuzde;
            this._mnToplam = mnToplam;
            this._strAciklama1 = strAciklama1;
            this._strAciklama2 = strAciklama2;
            this._strAciklama3 = strAciklama3;
            this._strAciklama4 = strAciklama4;
            this._strAciklama5 = strAciklama5;
            this._strAciklama6 = strAciklama6;
        }
        //
        //
        public AktivitelerDetay(int intAktiviteID, int intUrunID, string strUrunAdi, int intKoliAdet, decimal mnBirimFiyatKDVli,
            decimal mnAksiyonFiyati, double flMusteriKarYuzde, string strSatisHedefi, decimal mnTutar, double flEkIsk, double flCiroPrimDonusYuzde,
            decimal mnBayiMaliyet, decimal mnDusulmusBirimFiyatKDVli, double flKarZararYuzde, decimal mnToplam, string strAciklama1,
            string strAciklama2, string strAciklama3, string strAciklama4, string strAciklama5, string strAciklama6)
        {
            this._intAktiviteID = intAktiviteID;
            this._intUrunID = intUrunID;
            this._strUrunAdi = strUrunAdi;
            this._intKoliAdet = intKoliAdet;
            this._mnBirimFiyatKDVli = mnBirimFiyatKDVli;
            this._mnAksiyonFiyati = mnAksiyonFiyati;
            this._flMusteriKarYuzde = flMusteriKarYuzde;
            this._strSatisHedefi = strSatisHedefi;
            this._mnTutar = mnTutar;
            this._flEkIsk = flEkIsk;
            this._flCiroPrimDonusYuzde = flCiroPrimDonusYuzde;
            this._mnBayiMaliyet = mnBayiMaliyet;
            this._mnDusulmusBirimFiyatKDVli = mnDusulmusBirimFiyatKDVli;
            this._flKarZararYuzde = flKarZararYuzde;
            this._mnToplam = mnToplam;
            this._strAciklama1 = strAciklama1;
            this._strAciklama2 = strAciklama2;
            this._strAciklama3 = strAciklama3;
            this._strAciklama4 = strAciklama4;
            this._strAciklama5 = strAciklama5;
            this._strAciklama6 = strAciklama6;
        }
        //
        //
        //
        // Özellikler:
        //
        public long pkID { get { return this._pkID; } }
        public int intAktiviteID { get { return this._intAktiviteID; } set { this._intAktiviteID = value; } }
        public int intUrunID { get { return this._intUrunID; } set { this._intUrunID = value; } }
        public string strUrunAdi { get { return this._strUrunAdi; } set { this._strUrunAdi = value; } }
        public int intKoliAdet { get { return this._intKoliAdet; } set { this._intKoliAdet = value; } }
        public decimal mnBirimFiyatKDVli { get { return this._mnBirimFiyatKDVli; } set { this._mnBirimFiyatKDVli = value; } }
        public decimal mnAksiyonFiyati { get { return this._mnAksiyonFiyati; } set { this._mnAksiyonFiyati = value; } }
        public double flMusteriKarYuzde { get { return this._flMusteriKarYuzde; } set { this._flMusteriKarYuzde = value; } }
        public string strSatisHedefi { get { return this._strSatisHedefi; } set { this._strSatisHedefi = value; } }
        public decimal mnTutar { get { return this._mnTutar; } set { this._mnTutar = value; } }
        public double flEkIsk { get { return this._flEkIsk; } set { this._flEkIsk = value; } }
        public double flCiroPrimDonusYuzde { get { return this._flCiroPrimDonusYuzde; } set { this._flCiroPrimDonusYuzde = value; } }
        public decimal mnBayiMaliyet { get { return this._mnBayiMaliyet; } set { this._mnBayiMaliyet = value; } }
        public decimal mnDusulmusBirimFiyatKDVli { get { return this._mnDusulmusBirimFiyatKDVli; } set { this._mnDusulmusBirimFiyatKDVli = value; } }
        public double flKarZararYuzde { get { return this._flKarZararYuzde; } set { this._flKarZararYuzde = value; } }
        public decimal mnToplam { get { return this._mnToplam; } set { this._mnToplam = value; } }
        public string strAciklama1 { get { return this._strAciklama1; } set { this._strAciklama1 = value; } }
        public string strAciklama2 { get { return this._strAciklama2; } set { this._strAciklama2 = value; } }
        public string strAciklama3 { get { return this._strAciklama3; } set { this._strAciklama3 = value; } }
        public string strAciklama4 { get { return this._strAciklama4; } set { this._strAciklama4 = value; } }
        public string strAciklama5 { get { return this._strAciklama5; } set { this._strAciklama5 = value; } }
        public string strAciklama6 { get { return this._strAciklama6; } set { this._strAciklama6 = value; } }
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
        // ToString:
        //
        public override string ToString()
        {
            return this._strUrunAdi.ToString();
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
                SqlCommand cmd = new SqlCommand("sp_INTERNET_AktivitelerDetayEkle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@intAktiviteID", SqlDbType.Int).Value = this._intAktiviteID;
                cmd.Parameters.Add("@intUrunID", SqlDbType.Int).Value = this._intUrunID;
                cmd.Parameters.Add("@strUrunAdi", SqlDbType.NVarChar).Value = this._strUrunAdi;
                cmd.Parameters.Add("@intKoliAdet", SqlDbType.Int).Value = this._intKoliAdet;
                cmd.Parameters.Add("@mnBirimFiyatKDVli", SqlDbType.Money).Value = this._mnBirimFiyatKDVli;
                cmd.Parameters.Add("@mnAksiyonFiyati", SqlDbType.Money).Value = this._mnAksiyonFiyati;
                cmd.Parameters.Add("@flMusteriKarYuzde", SqlDbType.Float).Value = this._flMusteriKarYuzde;
                cmd.Parameters.Add("@strSatisHedefi", SqlDbType.NVarChar).Value = this._strSatisHedefi;
                cmd.Parameters.Add("@mnTutar", SqlDbType.Money).Value = this._mnTutar;
                cmd.Parameters.Add("@flEkIsk", SqlDbType.Float).Value = this._flEkIsk;
                cmd.Parameters.Add("@flCiroPrimDonusYuzde", SqlDbType.Float).Value = this._flCiroPrimDonusYuzde;
                cmd.Parameters.Add("@mnBayiMaliyet", SqlDbType.Money).Value = this._mnBayiMaliyet;
                cmd.Parameters.Add("@mnDusulmusBirimFiyatKDVli", SqlDbType.Money).Value = this._mnDusulmusBirimFiyatKDVli;
                cmd.Parameters.Add("@flKarZararYuzde", SqlDbType.Float).Value = this._flKarZararYuzde;
                cmd.Parameters.Add("@mnToplam", SqlDbType.Money).Value = this._mnToplam;
                cmd.Parameters.Add("@strAciklama1", SqlDbType.NVarChar).Value = this._strAciklama1;
                cmd.Parameters.Add("@strAciklama2", SqlDbType.NVarChar).Value = this._strAciklama2;
                cmd.Parameters.Add("@strAciklama3", SqlDbType.NVarChar).Value = this._strAciklama3;
                cmd.Parameters.Add("@strAciklama4", SqlDbType.NVarChar).Value = this._strAciklama4;
                cmd.Parameters.Add("@strAciklama5", SqlDbType.NVarChar).Value = this._strAciklama5;
                cmd.Parameters.Add("@strAciklama6", SqlDbType.NVarChar).Value = this._strAciklama6;
                cmd.Parameters.Add("@pkID", SqlDbType.BigInt).Direction = ParameterDirection.Output;
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    this._pkID = Convert.ToInt64(cmd.Parameters["@pkID"].Value);
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
                SqlCommand cmd = new SqlCommand("sp_INTERNET_AktivitelerDetayGuncelle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkID", SqlDbType.BigInt).Value = this._pkID;
                cmd.Parameters.Add("@intAktiviteID", SqlDbType.Int).Value = this._intAktiviteID;
                cmd.Parameters.Add("@intUrunID", SqlDbType.Int).Value = this._intUrunID;
                cmd.Parameters.Add("@strUrunAdi", SqlDbType.NVarChar).Value = this._strUrunAdi;
                cmd.Parameters.Add("@intKoliAdet", SqlDbType.Int).Value = this._intKoliAdet;
                cmd.Parameters.Add("@mnBirimFiyatKDVli", SqlDbType.Money).Value = this._mnBirimFiyatKDVli;
                cmd.Parameters.Add("@mnAksiyonFiyati", SqlDbType.Money).Value = this._mnAksiyonFiyati;
                cmd.Parameters.Add("@flMusteriKarYuzde", SqlDbType.Float).Value = this._flMusteriKarYuzde;
                cmd.Parameters.Add("@strSatisHedefi", SqlDbType.NVarChar).Value = this._strSatisHedefi;
                cmd.Parameters.Add("@mnTutar", SqlDbType.Money).Value = this._mnTutar;
                cmd.Parameters.Add("@flEkIsk", SqlDbType.Float).Value = this._flEkIsk; //(!double.IsNegativeInfinity(this._flEkIsk) && !double.IsPositiveInfinity(this._flEkIsk)) ? this._flEkIsk : 0
                cmd.Parameters.Add("@flCiroPrimDonusYuzde", SqlDbType.Float).Value = this._flCiroPrimDonusYuzde;
                cmd.Parameters.Add("@mnBayiMaliyet", SqlDbType.Money).Value = this._mnBayiMaliyet;
                cmd.Parameters.Add("@mnDusulmusBirimFiyatKDVli", SqlDbType.Money).Value = this._mnDusulmusBirimFiyatKDVli;
                cmd.Parameters.Add("@flKarZararYuzde", SqlDbType.Float).Value = this._flKarZararYuzde;
                cmd.Parameters.Add("@mnToplam", SqlDbType.Money).Value = this._mnToplam;
                cmd.Parameters.Add("@strAciklama1", SqlDbType.NVarChar).Value = this._strAciklama1;
                cmd.Parameters.Add("@strAciklama2", SqlDbType.NVarChar).Value = this._strAciklama2;
                cmd.Parameters.Add("@strAciklama3", SqlDbType.NVarChar).Value = this._strAciklama3;
                cmd.Parameters.Add("@strAciklama4", SqlDbType.NVarChar).Value = this._strAciklama4;
                cmd.Parameters.Add("@strAciklama5", SqlDbType.NVarChar).Value = this._strAciklama5;
                cmd.Parameters.Add("@strAciklama6", SqlDbType.NVarChar).Value = this._strAciklama6;
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
                SqlCommand cmd = new SqlCommand("sp_INTERNET_AktivitelerDetaySil", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkID", SqlDbType.BigInt).Value = this._pkID;
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
        public static void DoDelete(long ID)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_INTERNET_AktivitelerDetaySil", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkID", SqlDbType.BigInt).Value = ID;
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
        /// Aktiviteye ait bütün detayları silmek için
        /// </summary>
        public static void DoDelete(int AktiviteID)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_INTERNET_AktivitelerDetaySilByAktiviteID", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@intAktiviteID", SqlDbType.Int).Value = AktiviteID;
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
        public static void GetObjectsByAktiviteID(DataTable dt, int AktiviteID)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_INTERNET_AktivitelerDetayGetirByAktiviteID", conn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@intAktiviteID", SqlDbType.Int).Value = AktiviteID;
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
        //
        //
        public static AktivitelerDetay GetObject(long ID)
        {
            AktivitelerDetay aktivitedetay = null;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_INTERNET_AktivitelerDetayGetirByID", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkID", SqlDbType.BigInt).Value = ID;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        aktivitedetay = new AktivitelerDetay(Convert.ToInt64(dr[0]), Convert.ToInt32(dr[1]), Convert.ToInt32(dr[2]), 
                            dr[3].ToString(),
                            Convert.ToInt32(dr[4]), Convert.ToDecimal(dr[5]), Convert.ToDecimal(dr[6]), Convert.ToDouble(dr[7]), dr[8].ToString(),
                            Convert.ToDecimal(dr[9]), Convert.ToDouble(dr[10]), Convert.ToDouble(dr[11]), Convert.ToDecimal(dr[12]),
                            Convert.ToDecimal(dr[13]), Convert.ToDouble(dr[14]), Convert.ToDecimal(dr[15]), dr[16].ToString(), dr[17].ToString(),
                            dr[18].ToString(), dr[19].ToString(), dr[20].ToString(), dr[21].ToString());
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

            return aktivitedetay;
        }
        //
        //
        public static long GetTarihAraligiAktivitelerDetayID(int SMREF, string URTKOD, DateTime Tarih, short FiyatTipi)
        {
            long donendeger = 0;

            string urtkod = "(";
            //ArrayList esitemrefler = Urunler.GetProductEsKodITEMREFs(UrunID);
            ArrayList esurtkodlar = Urunler.GetProductEsKodURTKODs(URTKOD);

            for (int i = 0; i < esurtkodlar.Count; i++)
                urtkod += "[ITEMREF] = " + esurtkodlar[i].ToString() + " OR ";
            urtkod = urtkod.Substring(0, urtkod.Length - 4) + ")";

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                //SqlCommand cmd = new SqlCommand("SELECT TOP 1 tblINTERNET_AktivitelerDetay.pkID + CASE WHEN DATEPART(mm,dtOnaylamaTarihi) > DATEPART(mm,dtAktiviteBaslangic) OR DATEPART(mm,dtOnaylamaTarihi) > DATEPART(mm,dtAktiviteBitis) THEN 1000000000 ELSE 0 END FROM tblINTERNET_AktivitelerDetay INNER JOIN tblINTERNET_Aktiviteler ON tblINTERNET_AktivitelerDetay.intAktiviteID = tblINTERNET_Aktiviteler.pkID WHERE " + urunid + " AND SMREF = @SMREF AND dtAktiviteBaslangic <= @Tarih AND dtAktiviteBitis >= @Tarih ORDER BY mnDusulmusBirimFiyatKDVli ASC", conn);
                SqlCommand cmd = new SqlCommand("SELECT TOP 1 tblINTERNET_AktivitelerDetay.pkID + CASE WHEN DATEPART(mm,dtOnaylamaTarihi) > DATEPART(mm,dtAktiviteBaslangic) OR DATEPART(mm,dtOnaylamaTarihi) > DATEPART(mm,dtAktiviteBitis) THEN 1000000000 ELSE 0 END FROM tblINTERNET_AktivitelerDetay INNER JOIN tblINTERNET_Aktiviteler ON tblINTERNET_AktivitelerDetay.intAktiviteID = tblINTERNET_Aktiviteler.pkID INNER JOIN [Web-Malzeme-Full] ON tblINTERNET_AktivitelerDetay.intUrunID = [Web-Malzeme-Full].ITEMREF WHERE " + urtkod + " AND blAktarilmis = 'True' AND SMREF = @SMREF AND DATEADD(day,-1,dtAktiviteBaslangic) <= @Tarih AND DATEADD(day,1,dtAktiviteBitis) >= @Tarih AND (DATEPART(mm,dtAktiviteBaslangic) <= DATEPART(mm,@Tarih) OR DATEPART(mm,dtAktiviteBitis) >= DATEPART(mm,@Tarih)) AND sintFiyatTipiID = @sintFiyatTipiID ORDER BY flEkIsk DESC", conn);
                cmd.Parameters.Add("@SMREF", SqlDbType.Int).Value = SMREF;
                cmd.Parameters.Add("@Tarih", SqlDbType.SmallDateTime).Value = Tarih;
                cmd.Parameters.Add("@sintFiyatTipiID", SqlDbType.SmallInt).Value = FiyatTipi;
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
        //
        //
        public static long GetTarihAraligiAktivitelerDetayIDSUL(int SMREF, string URTKOD, DateTime Tarih) // geçmişe dönük aktivitelerde 1000000000 var onu kaldırabiliriz geçmişe dönük alınınca sorun çıkıyor... kaldırdım:  + CASE WHEN DATEPART(mm,dtOnaylamaTarihi) > DATEPART(mm,dtAktiviteBaslangic) OR DATEPART(mm,dtOnaylamaTarihi) > DATEPART(mm,dtAktiviteBitis) THEN 1000000000 ELSE 0 END
        {
            long donendeger = 0;

            string urtkod = "(";
            //ArrayList esitemrefler = Urunler.GetProductEsKodITEMREFs(UrunID);
            ArrayList esurtkodlar = Urunler.GetProductEsKodURTKODs(URTKOD);

            for (int i = 0; i < esurtkodlar.Count; i++)
                urtkod += "[ITEMREF] = " + esurtkodlar[i].ToString() + " OR ";
            urtkod = urtkod.Substring(0, urtkod.Length - 4) + ")";

            string smrefs = "(";
            DataTable dt = new DataTable();
            CariHesaplar.GetSubelerTUMU(dt, CariHesaplar.GetGMREFBySMREF(SMREF));
            for (int i = 0; i < dt.Rows.Count; i++)
                smrefs += "SMREF = " + dt.Rows[i]["SMREF"].ToString() + " OR ";
            smrefs = dt.Rows.Count > 0 ? smrefs.Substring(0, smrefs.Length - 4) + ") AND" : "";

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                //SqlCommand cmd = new SqlCommand("SELECT TOP 1 tblINTERNET_AktivitelerDetay.pkID + CASE WHEN DATEPART(mm,dtOnaylamaTarihi) > DATEPART(mm,dtAktiviteBaslangic) OR DATEPART(mm,dtOnaylamaTarihi) > DATEPART(mm,dtAktiviteBitis) THEN 1000000000 ELSE 0 END FROM tblINTERNET_AktivitelerDetay INNER JOIN tblINTERNET_Aktiviteler ON tblINTERNET_AktivitelerDetay.intAktiviteID = tblINTERNET_Aktiviteler.pkID WHERE " + urunid + " AND SMREF = @SMREF AND dtAktiviteBaslangic <= @Tarih AND dtAktiviteBitis >= @Tarih ORDER BY mnDusulmusBirimFiyatKDVli ASC", conn);
                SqlCommand cmd = new SqlCommand("SELECT TOP 1 tblINTERNET_AktivitelerDetay.pkID FROM tblINTERNET_AktivitelerDetay INNER JOIN tblINTERNET_Aktiviteler ON tblINTERNET_AktivitelerDetay.intAktiviteID = tblINTERNET_Aktiviteler.pkID INNER JOIN [Web-Malzeme-Full] ON tblINTERNET_AktivitelerDetay.intUrunID = [Web-Malzeme-Full].ITEMREF WHERE [intAktiviteTipiID] = 2 AND " + urtkod + " AND " + smrefs + " blAktarilmis = 'True' AND DATEADD(day,-1,dtAktiviteBaslangic) <= @Tarih AND DATEADD(day,1,dtAktiviteBitis) >= @Tarih AND DATEPART(mm,dtAktiviteBaslangic) <= DATEPART(mm,@Tarih) AND DATEPART(mm,dtAktiviteBitis) >= DATEPART(mm,@Tarih) ORDER BY tblINTERNET_AktivitelerDetay.pkID DESC", conn);
                //cmd.Parameters.Add("@SMREF", SqlDbType.Int).Value = SMREF;
                cmd.Parameters.Add("@Tarih", SqlDbType.SmallDateTime).Value = Tarih;
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
        //
        //
        public static long GetSonAktivitelerDetayID(int SMREF, string URTKOD, short FiyatTipi)
        {
            long donendeger = 0;

            string urtkod = "(";
            //ArrayList esitemrefler = Urunler.GetProductEsKodITEMREFs(UrunID);
            ArrayList esurtkodlar = Urunler.GetProductEsKodURTKODs(URTKOD);

            for (int i = 0; i < esurtkodlar.Count; i++)
                urtkod += "[ITEMREF] = " + esurtkodlar[i].ToString() + " OR ";
            urtkod = urtkod.Substring(0, urtkod.Length - 4) + ")";

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                //SqlCommand cmd = new SqlCommand("SELECT TOP 1 tblINTERNET_AktivitelerDetay.pkID + CASE WHEN DATEPART(mm,dtOnaylamaTarihi) > DATEPART(mm,dtAktiviteBaslangic) OR DATEPART(mm,dtOnaylamaTarihi) > DATEPART(mm,dtAktiviteBitis) THEN 1000000000 ELSE 0 END FROM tblINTERNET_AktivitelerDetay INNER JOIN tblINTERNET_Aktiviteler ON tblINTERNET_AktivitelerDetay.intAktiviteID = tblINTERNET_Aktiviteler.pkID WHERE " + urunid + " AND SMREF = @SMREF AND dtAktiviteBaslangic <= @Tarih AND dtAktiviteBitis >= @Tarih ORDER BY mnDusulmusBirimFiyatKDVli ASC", conn);
                SqlCommand cmd = new SqlCommand("SELECT TOP 1 tblINTERNET_AktivitelerDetay.pkID FROM tblINTERNET_AktivitelerDetay INNER JOIN tblINTERNET_Aktiviteler ON tblINTERNET_AktivitelerDetay.intAktiviteID = tblINTERNET_Aktiviteler.pkID INNER JOIN [Web-Malzeme-Full] ON tblINTERNET_AktivitelerDetay.intUrunID = [Web-Malzeme-Full].ITEMREF WHERE " + urtkod + " AND blAktarilmis = 'True' AND SMREF = @SMREF AND sintFiyatTipiID = @sintFiyatTipiID ORDER BY pkID DESC", conn);
                cmd.Parameters.Add("@SMREF", SqlDbType.Int).Value = SMREF;
                cmd.Parameters.Add("@sintFiyatTipiID", SqlDbType.SmallInt).Value = FiyatTipi;
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

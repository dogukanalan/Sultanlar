using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Collections;

namespace Sultanlar.DatabaseObject.Internet
{
    /// <summary>
    /// Buradaki SMREF aslında GMREF demek çünkü ödeme ancak GMREF'te yapılır
    /// </summary>
    public class Odemeler : ISultanlar, IDisposable
    {
        //
        //
        //
        // Alanlar:
        //
        private long _pkOdemeID;
        private int _SMREF;
        private int _intMusteriID;
        private int _intSiparisID;
        decimal _mnTutar;
        private DateTime _dtOdemeZamani;
        private string _strAuthCode;
        private string _strResponse;
        private string _strHostRefNum;
        private string _strProcReturnCode;
        private string _strTransId;
        private string _strErrMsg;
        private string _strmdStatus;
        private string _strReturnOid;
        private string _strMaskedPan;
        private bool _blAktarildi;
        private string _strAktaran;
        private DateTime _dtAktarmaZamani;
        //
        //
        //
        // Constracter lar:
        //
        private Odemeler(long pkOdemeID, int SMREF, int intMusteriID, int intSiparisID, decimal mnTutar, DateTime dtOdemeZamani, 
            string strAuthCode, string strResponse, string strHostRefNum,
            string strProcReturnCode, string strTransId, string strErrMsg, string strmdStatus, string strReturnOid, string strMaskedPan,
            bool blAktarildi, string strAktaran, DateTime dtAktarmaZamani)
        {
            this._pkOdemeID = pkOdemeID;
            this._SMREF = SMREF;
            this._intMusteriID = intMusteriID;
            this._intSiparisID = intSiparisID;
            this._mnTutar = mnTutar;
            this._dtOdemeZamani = dtOdemeZamani;
            this._strAuthCode = strAuthCode;
            this._strResponse = strResponse;
            this._strHostRefNum = strHostRefNum;
            this._strProcReturnCode = strProcReturnCode;
            this._strTransId = strTransId;
            this._strErrMsg = strErrMsg;
            this._strmdStatus = strmdStatus;
            this._strReturnOid = strReturnOid;
            this._strMaskedPan = strMaskedPan;
            this._blAktarildi = blAktarildi;
            this._strAktaran = strAktaran;
            this._dtAktarmaZamani = dtAktarmaZamani;
        }
        //
        //
        public Odemeler(int SMREF, int intMusteriID, int intSiparisID, decimal mnTutar, DateTime dtOdemeZamani, 
            string strAuthCode, string strResponse, string strHostRefNum,
            string strProcReturnCode, string strTransId, string strErrMsg, string strmdStatus, string strReturnOid, string strMaskedPan,
            bool blAktarildi, string strAktaran, DateTime dtAktarmaZamani)
        {
            this._SMREF = SMREF;
            this._intMusteriID = intMusteriID;
            this._intSiparisID = intSiparisID;
            this._mnTutar = mnTutar;
            this._dtOdemeZamani = dtOdemeZamani;
            this._strAuthCode = strAuthCode;
            this._strResponse = strResponse;
            this._strHostRefNum = strHostRefNum;
            this._strProcReturnCode = strProcReturnCode;
            this._strTransId = strTransId;
            this._strErrMsg = strErrMsg;
            this._strmdStatus = strmdStatus;
            this._strReturnOid = strReturnOid;
            this._strMaskedPan = strMaskedPan;
            this._blAktarildi = blAktarildi;
            this._strAktaran = strAktaran;
            this._dtAktarmaZamani = dtAktarmaZamani;
        }
        //
        //
        public Odemeler(int SMREF, int intMusteriID, int intSiparisID, decimal mnTutar, DateTime dtOdemeZamani)
        {
            this._SMREF = SMREF;
            this._intMusteriID = intMusteriID;
            this._intSiparisID = intSiparisID;
            this._mnTutar = mnTutar;
            this._dtOdemeZamani = dtOdemeZamani;

            this._strAuthCode = "-Bankayla iletişim kurulamadı-";
            this._strResponse = "-Bankayla iletişim kurulamadı-";
            this._strHostRefNum = "-Bankayla iletişim kurulamadı-";
            this._strProcReturnCode = "-Bankayla iletişim kurulamadı-";
            this._strTransId = "-Bankayla iletişim kurulamadı-";
            this._strErrMsg = "-Bankayla iletişim kurulamadı-";
            this._strmdStatus = "-Bankayla iletişim kurulamadı-";
            this._strReturnOid = "-Bankayla iletişim kurulamadı-";
            this._strMaskedPan = "-Bankayla iletişim kurulamadı-";

            this._blAktarildi = false;
            this._strAktaran = string.Empty;
            this._dtAktarmaZamani = DateTime.MinValue;
        }
        //
        //
        //
        // Özellikler:
        //
        public long pkOdemeID { get { return this._pkOdemeID; } }
        public int SMREF { get { return this._SMREF; } set { this._SMREF = value; } }
        public int intMusteriID { get { return this._intMusteriID; } set { this._intMusteriID = value; } }
        public int intSiparisID { get { return this._intSiparisID; } set { this._intSiparisID = value; } }
        public decimal mnTutar { get { return this._mnTutar; } set { this._mnTutar = value; } }
        public DateTime dtOdemeZamani { get { return this._dtOdemeZamani; } set { this._dtOdemeZamani = value; } }
        public string strAuthCode { get { return this._strAuthCode; } set { this._strAuthCode = value; } }
        public string strResponse { get { return this._strResponse; } set { this._strResponse = value; } }
        public string strHostRefNum { get { return this._strHostRefNum; } set { this._strHostRefNum = value; } }
        public string strProcReturnCode { get { return this._strProcReturnCode; } set { this._strProcReturnCode = value; } }
        public string strTransId { get { return this._strTransId; } set { this._strTransId = value; } }
        public string strErrMsg { get { return this._strErrMsg; } set { this._strErrMsg = value; } }
        public string strmdStatus { get { return this._strmdStatus; } set { this._strmdStatus = value; } }
        public string strReturnOid { get { return this._strReturnOid; } set { this._strReturnOid = value; } }
        public string strMaskedPan { get { return this._strMaskedPan; } set { this._strMaskedPan = value; } }
        public bool blAktarildi { get { return this._blAktarildi; } set { this._blAktarildi = value; } }
        public string strAktaran { get { return this._strAktaran; } set { this._strAktaran = value; } }
        public DateTime dtAktarmaZamani { get { return this._dtAktarmaZamani; } set { this._dtAktarmaZamani = value; } }
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
            return this._pkOdemeID.ToString();
        }
        //
        //
        //
        // Metodlar:
        //
        public void DoInsert()
        {
            object OdemeZamani = DBNull.Value;
            object AktarmaZamani = DBNull.Value;
            if (_dtOdemeZamani != DateTime.MinValue)
                OdemeZamani = this._dtOdemeZamani;
            if (_dtAktarmaZamani != DateTime.MinValue)
                AktarmaZamani = this._dtAktarmaZamani;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_INTERNET_OdemeEkle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@SMREF", SqlDbType.Int).Value = this._SMREF;
                cmd.Parameters.Add("@intMusteriID", SqlDbType.Int).Value = this._intMusteriID;
                cmd.Parameters.Add("@intSiparisID", SqlDbType.Int).Value = this._intSiparisID;
                cmd.Parameters.Add("@mnTutar", SqlDbType.Money).Value = this._mnTutar;
                cmd.Parameters.Add("@dtOdemeZamani", SqlDbType.DateTime).Value = OdemeZamani;
                cmd.Parameters.Add("@strAuthCode", SqlDbType.NVarChar).Value = this._strAuthCode != null ? this._strAuthCode : "";
                cmd.Parameters.Add("@strResponse", SqlDbType.NVarChar).Value = this._strResponse != null ? this._strResponse : "";
                cmd.Parameters.Add("@strHostRefNum", SqlDbType.NVarChar).Value = this._strHostRefNum != null ? this._strHostRefNum : "";
                cmd.Parameters.Add("@strProcReturnCode", SqlDbType.NVarChar).Value = this._strProcReturnCode != null ? this._strProcReturnCode : "";
                cmd.Parameters.Add("@strTransId", SqlDbType.NVarChar).Value = this._strTransId != null ? this._strTransId : "";
                cmd.Parameters.Add("@strErrMsg", SqlDbType.NVarChar).Value = this._strErrMsg != null ? this._strErrMsg : "";
                cmd.Parameters.Add("@strmdStatus", SqlDbType.NVarChar).Value = this._strmdStatus != null ? this._strmdStatus : "";
                cmd.Parameters.Add("@strReturnOid", SqlDbType.NVarChar).Value = this._strReturnOid != null ? this._strReturnOid : "";
                cmd.Parameters.Add("@strMaskedPan", SqlDbType.NVarChar).Value = this._strMaskedPan != null ? this._strMaskedPan : "";
                cmd.Parameters.Add("@blAktarildi", SqlDbType.Bit).Value = this._blAktarildi;
                cmd.Parameters.Add("@strAktaran", SqlDbType.NVarChar).Value = this._strAktaran;
                cmd.Parameters.Add("@dtAktarmaZamani", SqlDbType.DateTime).Value = AktarmaZamani;
                cmd.Parameters.Add("@pkOdemeID", SqlDbType.BigInt).Direction = ParameterDirection.Output;
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    this._pkOdemeID = Convert.ToInt32(cmd.Parameters["@pkOdemeID"].Value);
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
            object OdemeZamani = DBNull.Value;
            object AktarmaZamani = DBNull.Value;
            if (_dtOdemeZamani != DateTime.MinValue)
                OdemeZamani = this._dtOdemeZamani;
            if (_dtAktarmaZamani != DateTime.MinValue)
                AktarmaZamani = this._dtAktarmaZamani;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_INTERNET_OdemeGuncelle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkOdemeID", SqlDbType.BigInt).Value = this._pkOdemeID;
                cmd.Parameters.Add("@SMREF", SqlDbType.Int).Value = this._SMREF;
                cmd.Parameters.Add("@intMusteriID", SqlDbType.Int).Value = this._intMusteriID;
                cmd.Parameters.Add("@intSiparisID", SqlDbType.Int).Value = this._intSiparisID;
                cmd.Parameters.Add("@mnTutar", SqlDbType.Money).Value = this._mnTutar;
                cmd.Parameters.Add("@dtOdemeZamani", SqlDbType.DateTime).Value = OdemeZamani;
                cmd.Parameters.Add("@strAuthCode", SqlDbType.NVarChar).Value = this._strAuthCode;
                cmd.Parameters.Add("@strResponse", SqlDbType.NVarChar).Value = this._strResponse;
                cmd.Parameters.Add("@strHostRefNum", SqlDbType.NVarChar).Value = this._strHostRefNum;
                cmd.Parameters.Add("@strProcReturnCode", SqlDbType.NVarChar).Value = this._strProcReturnCode;
                cmd.Parameters.Add("@strTransId", SqlDbType.NVarChar).Value = this._strTransId;
                cmd.Parameters.Add("@strErrMsg", SqlDbType.NVarChar).Value = this._strErrMsg;
                cmd.Parameters.Add("@strmdStatus", SqlDbType.NVarChar).Value = this._strmdStatus;
                cmd.Parameters.Add("@strReturnOid", SqlDbType.NVarChar).Value = this._strReturnOid;
                cmd.Parameters.Add("@strMaskedPan", SqlDbType.NVarChar).Value = this._strMaskedPan;
                cmd.Parameters.Add("@blAktarildi", SqlDbType.Bit).Value = this._blAktarildi;
                cmd.Parameters.Add("@strAktaran", SqlDbType.NVarChar).Value = this._strAktaran;
                cmd.Parameters.Add("@dtAktarmaZamani", SqlDbType.DateTime).Value = AktarmaZamani;
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
        public static void DoUpdateAktar(int OdemeID, string Aktaran)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UPDATE tblINTERNET_Odemeler SET blAktarildi = @blAktarildi, strAktaran = @strAktaran, dtAktarmaZamani = @dtAktarmaZamani WHERE pkOdemeID = @pkOdemeID", conn);
                cmd.Parameters.Add("@pkOdemeID", SqlDbType.BigInt).Value = OdemeID;
                cmd.Parameters.Add("@blAktarildi", SqlDbType.Bit).Value = true;
                cmd.Parameters.Add("@strAktaran", SqlDbType.NVarChar).Value = Aktaran;
                cmd.Parameters.Add("@dtAktarmaZamani", SqlDbType.DateTime).Value = DateTime.Now;
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
                SqlCommand cmd = new SqlCommand("sp_INTERNET_OdemeSil", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkOdemeID", SqlDbType.BigInt).Value = this._pkOdemeID;
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
        public static void GetObjects(IList List, bool UI)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                List.Clear();

                SqlCommand cmd = new SqlCommand("sp_INTERNET_OdemelerGetir", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        DateTime OdemeZamani = DateTime.MinValue;
                        DateTime AktarmaZamani = DateTime.MinValue;
                        if (dr[5] != DBNull.Value)
                            OdemeZamani = Convert.ToDateTime(dr[5]);
                        if (dr[17] != DBNull.Value)
                            AktarmaZamani = Convert.ToDateTime(dr[17]);

                        List.Add(new Odemeler(
                            Convert.ToInt64(dr[0]), Convert.ToInt32(dr[1]), Convert.ToInt32(dr[2]), Convert.ToInt32(dr[3]), 
                            Convert.ToDecimal(dr[4]),
                            OdemeZamani, dr[6].ToString(), dr[7].ToString(), dr[8].ToString(), dr[9].ToString(), dr[10].ToString(),
                            dr[11].ToString(), dr[12].ToString(), dr[13].ToString(), dr[14].ToString(), Convert.ToBoolean(dr[15]),
                            dr[16].ToString(), AktarmaZamani));
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
        public static void GetObjects(DataTable dt, int MusteriID)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_INTERNET_OdemelerGetirByMusteriID", conn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@intMusteriID", SqlDbType.Int).Value = MusteriID;
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
        public static void GetObjects(DataTable dt, int SMREF, bool smref)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_INTERNET_OdemelerGetirBySMREF", conn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@SMREF", SqlDbType.Int).Value = SMREF;
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
        public static void GetObjects(DataTable dt, bool VW)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_INTERNET_OdemelerGetirVW", conn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
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
        /// <summary>
        /// Finans : Web Sanal Pos İşlemleri altındaki formda kullanılmak için
        /// </summary>
        /// <param name="dt">Dolacak Table</param>
        /// <param name="VW">View'den geldiğini belirtmek için</param>
        /// <param name="SiparisID">0 ise dahil değil</param>
        /// <param name="SMREF">0 ise dahil değil</param>
        /// <param name="MusteriID">0 ise dahil değil</param>
        /// <param name="CariHesap">string.Empty ise dahil değil</param>
        /// <param name="BasTarih">DateTime.MinValue ise dahil değil</param>
        /// <param name="BitTarih">DateTime.MaxValue ise dahil değil</param>
        /// <param name="Aktarildi">null ise dahil değil</param>
        public static void GetObjects(DataTable dt, bool VW, int SiparisID, int SMREF, int MusteriID, string CariHesap, 
            DateTime BasTarih, DateTime BitTarih, object Aktarildi)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                string where = string.Empty;
                if (SiparisID != 0 || SMREF != 0 || MusteriID != 0 || CariHesap != string.Empty || 
                    BasTarih != DateTime.MinValue || BitTarih != DateTime.MaxValue || Aktarildi != null)
                    where = "WHERE ";

                string siparisid = string.Empty;
                string smref = string.Empty;
                string musteriid = string.Empty;
                string carihesap = string.Empty;
                string baslangictarih = string.Empty;
                string bitistarih = string.Empty;
                string aktarildi = string.Empty;
                if (SiparisID != 0)
                    where += "intSiparisID = " + SiparisID.ToString() + " AND ";
                if (SMREF != 0)
                    where += "SMREF = " + SMREF.ToString() + " AND ";
                if (MusteriID != 0)
                    where += "intMusteriID = " + MusteriID.ToString() + " AND ";
                if (CariHesap != string.Empty)
                    where += "MUSTERI LIKE '%" + CariHesap + "%' AND ";
                if (BasTarih != DateTime.MinValue)
                    where += "dtOdemeZamani >= '" + BasTarih.ToUniversalTime().ToShortDateString() + "' AND ";
                if (BitTarih != DateTime.MaxValue)
                    where += "dtOdemeZamani <= '" + BitTarih.ToUniversalTime().ToShortDateString() + "' AND ";
                if (Aktarildi != null)
                    where += "blAktarildi = '" + Convert.ToBoolean(Aktarildi).ToString() + "' AND ";

                if (SiparisID != 0 || SMREF != 0 || MusteriID != 0 || CariHesap != string.Empty || 
                    BasTarih != DateTime.MinValue || BitTarih != DateTime.MaxValue || Aktarildi != null)
                    where = where.Substring(0, where.Length - 5);

                SqlDataAdapter da = new SqlDataAdapter("SELECT [pkOdemeID],[intSiparisID],[SMREF],[MUSTERI],[intMusteriID]," + 
                    "[mnTutar],[AdSoyad],[strTelefon],[strEposta],[dtOdemeZamani],[strAuthCode],[strResponse],[strHostRefNum]," + 
                    "[strProcReturnCode],[strTransId],[strErrMsg],[strmdStatus],[strReturnOid],[strMaskedPan],[blAktarildi],[strAktaran]," + 
                    "[dtAktarmaZamani] FROM [KurumsalWebSAP].[dbo].[vw_INTERNET_Odemeler] "+
                    where + 
                    "ORDER BY pkOdemeID DESC", conn);
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
        public static Odemeler GetObjectBySiparisID(int SiparisID)
        {
            Odemeler odeme = null;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_INTERNET_OdemeGetirBySiparisID", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@intSiparisID", SqlDbType.Int).Value = SiparisID;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        DateTime OdemeZamani = DateTime.MinValue;
                        DateTime AktarmaZamani = DateTime.MinValue;
                        if (dr[5] != DBNull.Value)
                            OdemeZamani = Convert.ToDateTime(dr[5]);
                        if (dr[17] != DBNull.Value)
                            AktarmaZamani = Convert.ToDateTime(dr[17]);

                        odeme = new Odemeler(
                            Convert.ToInt64(dr[0]), Convert.ToInt32(dr[1]), Convert.ToInt32(dr[2]), Convert.ToInt32(dr[3]),
                            Convert.ToDecimal(dr[4]),
                            OdemeZamani, dr[6].ToString(), dr[7].ToString(), dr[8].ToString(), dr[9].ToString(), dr[10].ToString(),
                            dr[11].ToString(), dr[12].ToString(), dr[13].ToString(), dr[14].ToString(), Convert.ToBoolean(dr[15]),
                            dr[16].ToString(), AktarmaZamani);
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

            return odeme;
        }
        //
        //
        public static Odemeler GetObject(int OdemeID)
        {
            Odemeler odeme = null;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_INTERNET_OdemeGetirByOdemeID", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkOdemeID", SqlDbType.Int).Value = OdemeID;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        DateTime OdemeZamani = DateTime.MinValue;
                        DateTime AktarmaZamani = DateTime.MinValue;
                        if (dr[5] != DBNull.Value)
                            OdemeZamani = Convert.ToDateTime(dr[5]);
                        if (dr[17] != DBNull.Value)
                            AktarmaZamani = Convert.ToDateTime(dr[17]);

                        odeme = new Odemeler(
                            Convert.ToInt64(dr[0]), Convert.ToInt32(dr[1]), Convert.ToInt32(dr[2]), Convert.ToInt32(dr[3]),
                            Convert.ToDecimal(dr[4]),
                            OdemeZamani, dr[6].ToString(), dr[7].ToString(), dr[8].ToString(), dr[9].ToString(), dr[10].ToString(),
                            dr[11].ToString(), dr[12].ToString(), dr[13].ToString(), dr[14].ToString(), Convert.ToBoolean(dr[15]),
                            dr[16].ToString(), AktarmaZamani);
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

            return odeme;
        }
        //
        //
        public static int GetOdemeCountByMusteriID(int MusteriID, bool VW)
        {
            int donendeger = 0;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_INTERNET_OdemeCountByMusteriIDVW", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@intMusteriID", SqlDbType.Int).Value = MusteriID;
                try
                {
                    conn.Open();
                    donendeger = Convert.ToInt32(cmd.ExecuteScalar());
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
        public static void GetObjectsByMusteriID(DataTable dt, int MusteriID, int Baslangic, int Adet, bool VW, bool VW2)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_INTERNET_OdemelerGetirByMusteriIDVW", conn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@intMusteriID", SqlDbType.Int).Value = MusteriID;
                try
                {
                    conn.Open();
                    da.Fill(Baslangic, Adet, dt);
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
        public static int GetOdemeCountBySMREF(int SMREF, bool VW)
        {
            int donendeger = 0;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_INTERNET_OdemeCountBySMREFVW", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@SMREF", SqlDbType.Int).Value = SMREF;
                try
                {
                    conn.Open();
                    donendeger = Convert.ToInt32(cmd.ExecuteScalar());
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
        public static void GetObjectsBySMREF(DataTable dt, int SMREF, int Baslangic, int Adet, bool VW)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_INTERNET_OdemelerGetirBySMREFVW", conn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@SMREF", SqlDbType.Int).Value = SMREF;
                try
                {
                    conn.Open();
                    da.Fill(Baslangic, Adet, dt);
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
        public static int GetOdemeCountBySMREFs(ArrayList SMREF/*, DateTime BaslangicTarih, DateTime BitisTarih*/)
        {
            int donendeger = 0;

            string smrefs = string.Empty;
            for (int i = 0; i < SMREF.Count; i++)
                smrefs += "SMREF = " + SMREF[i].ToString() + " OR ";
            smrefs = smrefs.Substring(0, smrefs.Length - 3);

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT count(pkOdemeID) FROM vw_INTERNET_Odemeler " +
                    "WHERE" + /*" tblINTERNET_Siparisler.dtOlusmaTarihi >= @BaslangicTarih AND " +
                    "tblINTERNET_Siparisler.dtOlusmaTarihi <= @BitisTarih AND" + */" (" + smrefs + ")", conn);
                //cmd.Parameters.Add("@BaslangicTarih", SqlDbType.SmallDateTime).Value = BaslangicTarih;
                //cmd.Parameters.Add("@BitisTarih", SqlDbType.SmallDateTime).Value = BitisTarih;
                try
                {
                    conn.Open();
                    donendeger = Convert.ToInt32(cmd.ExecuteScalar());
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
        public static void GetObjectsBySMREFs(DataTable dt, ArrayList SMREF, /*DateTime BaslangicTarih, DateTime BitisTarih, */int Baslangic, int Adet, bool VW)
        {
            string smrefs = string.Empty;
            for (int i = 0; i < SMREF.Count; i++)
                smrefs += "SMREF = " + SMREF[i].ToString() + " OR ";
            smrefs = smrefs.Substring(0, smrefs.Length - 3);

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT [pkOdemeID],[intSiparisID],[mnTutar],[SMREF],[MUSTERI],[intMusteriID],[AdSoyad],[strTelefon],[strEposta],[dtOdemeZamani],[strAuthCode],[strResponse],[strHostRefNum],[strProcReturnCode],[strTransId],[strErrMsg],[strmdStatus],[strReturnOid],[strMaskedPan],[blAktarildi],[strAktaran],[dtAktarmaZamani] FROM [KurumsalWebSAP].[dbo].[vw_INTERNET_Odemeler] " +
                    "WHERE" + /*" tblINTERNET_Siparisler.dtOlusmaTarihi >= @BaslangicTarih AND " +
                    "tblINTERNET_Siparisler.dtOlusmaTarihi <= @BitisTarih AND" + */" ("
                    + smrefs +
                    ") ORDER BY [pkOdemeID] DESC", conn);
                //da.SelectCommand.Parameters.Add("@BaslangicTarih", SqlDbType.SmallDateTime).Value = BaslangicTarih;
                //da.SelectCommand.Parameters.Add("@BitisTarih", SqlDbType.SmallDateTime).Value = BitisTarih;
                try
                {
                    conn.Open();
                    da.Fill(Baslangic, Adet, dt);
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
        public static int GetOdemeCount()
        {
            int donendeger = 0;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT count(pkOdemeID) FROM vw_INTERNET_Odemeler", conn);
                try
                {
                    conn.Open();
                    donendeger = Convert.ToInt32(cmd.ExecuteScalar());
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
        public static void GetObjects(DataTable dt, int Baslangic, int Adet, bool VW)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_INTERNET_OdemelerGetirVW", conn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                try
                {
                    conn.Open();
                    da.Fill(Baslangic, Adet, dt);
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
        public static bool GetSiparisOdemeYapildiMi(int SiparisID)
        {
            bool donendeger = false;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT count(pkOdemeID) FROM tblINTERNET_Odemeler WHERE intSiparisID = @SiparisID AND strResponse = 'Approved'", conn);
                cmd.Parameters.Add("@SiparisID", SqlDbType.Int).Value = SiparisID;
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
    }
}

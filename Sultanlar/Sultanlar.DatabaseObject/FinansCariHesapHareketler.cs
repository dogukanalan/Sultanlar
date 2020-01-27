using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Sultanlar.DatabaseObject
{
    public class FinansCariHesapHareketler : ISultanlar, IDisposable
    {
        //
        //
        //
        // Alanlar:
        //
        private long _LOGREF;
        private short _MOD;
        private short _TUR;
        private string _FISNO;
        private double _KESTUTAR;
        private double _KESYUZDE;
        private string _GUNCKIM;
        private DateTime _GUNCTARIH;
        private bool _IPTAL;
        //
        //
        //
        // Constracter lar:
        //
        public FinansCariHesapHareketler(long LOGREF, short MOD, short TUR, string FISNO, double KESTUTAR, double KESYUZDE, string GUNCKIM,
            DateTime GUNCTARIH, bool IPTAL)
        {
            this._LOGREF = LOGREF;
            this._MOD = MOD;
            this._TUR = TUR;
            this._FISNO = FISNO;
            this._KESTUTAR = KESTUTAR;
            this._KESYUZDE = KESYUZDE;
            this._GUNCKIM = GUNCKIM;
            this._GUNCTARIH = GUNCTARIH;
            this._IPTAL = IPTAL;
        }
        //
        //
        //
        // Özellikler:
        //
        public long LOGREF { get { return this._LOGREF; } set { this._LOGREF = value; } }
        public short MOD { get { return this._MOD; } set { this._MOD = value; } }
        public short TUR { get { return this._TUR; } set { this._TUR = value; } }
        public string FISNO { get { return this._FISNO; } set { this._FISNO = value; } }
        public double KESTUTAR { get { return this._KESTUTAR; } set { this._KESTUTAR = value; } }
        public double KESYUZDE { get { return this._KESYUZDE; } set { this._KESYUZDE = value; } }
        public string GUNCKIM { get { return this._GUNCKIM; } set { this._GUNCKIM = value; } }
        public DateTime GUNCTARIH { get { return this._GUNCTARIH; } set { this._GUNCTARIH = value; } }
        //public object GUNCTARIH 
        //{ 
        //    get 
        //    { 
        //        return this._GUNCTARIH;
        //    } 
        //    set 
        //    {
        //        if (value != DBNull.Value)
        //            this._GUNCTARIH = DateTime.Parse(value.ToString());
        //    } 
        //}
        public bool IPTAL { get { return this._IPTAL; } set { this._IPTAL = value; } }
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
            return this._LOGREF.ToString();
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
                SqlCommand cmd = new SqlCommand("sp_FinansCariHesapHareketEkle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@LOGREF", SqlDbType.BigInt).Value = this._LOGREF;
                cmd.Parameters.Add("@MOD", SqlDbType.SmallInt).Value = this._MOD;
                cmd.Parameters.Add("@TUR", SqlDbType.SmallInt).Value = this._TUR;
                cmd.Parameters.Add("@FISNO", SqlDbType.VarChar, 9).Value = this._FISNO;
                cmd.Parameters.Add("@KESTUTAR", SqlDbType.Float).Value = this._KESTUTAR;
                cmd.Parameters.Add("@KESYUZDE", SqlDbType.Float).Value = this._KESYUZDE;
                cmd.Parameters.Add("@GUNCKIM", SqlDbType.NVarChar).Value = this._GUNCKIM;
                cmd.Parameters.Add("@GUNCTARIH", SqlDbType.SmallDateTime).Value = this._GUNCTARIH;
                cmd.Parameters.Add("@IPTAL", SqlDbType.Bit).Value = this._IPTAL;
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
        public void DoUpdate()
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_FinansCariHesapHareketGuncelle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@LOGREF", SqlDbType.BigInt).Value = this._LOGREF;
                cmd.Parameters.Add("@MOD", SqlDbType.SmallInt).Value = this._MOD;
                cmd.Parameters.Add("@TUR", SqlDbType.SmallInt).Value = this._TUR;
                cmd.Parameters.Add("@FISNO", SqlDbType.VarChar, 9).Value = this._FISNO;
                cmd.Parameters.Add("@KESTUTAR", SqlDbType.Float).Value = this._KESTUTAR;
                cmd.Parameters.Add("@KESYUZDE", SqlDbType.Float).Value = this._KESYUZDE;
                cmd.Parameters.Add("@GUNCKIM", SqlDbType.NVarChar).Value = this._GUNCKIM;
                cmd.Parameters.Add("@GUNCTARIH", SqlDbType.SmallDateTime).Value = this._GUNCTARIH;
                cmd.Parameters.Add("@IPTAL", SqlDbType.Bit).Value = this._IPTAL;
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
        public static void DoUpdate(long LOGREF, short MOD, short TUR, string FISNO, double KESTUTAR, double KESYUZDE, 
            string GUNCKIM, DateTime GUNCTARIH, bool IPTAL)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_FinansCariHesapHareketGuncelle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@LOGREF", SqlDbType.BigInt).Value = LOGREF;
                cmd.Parameters.Add("@MOD", SqlDbType.SmallInt).Value = MOD;
                cmd.Parameters.Add("@TUR", SqlDbType.SmallInt).Value = TUR;
                cmd.Parameters.Add("@FISNO", SqlDbType.VarChar, 9).Value = FISNO;
                cmd.Parameters.Add("@KESTUTAR", SqlDbType.Float).Value = KESTUTAR;
                cmd.Parameters.Add("@KESYUZDE", SqlDbType.Float).Value = KESYUZDE;
                cmd.Parameters.Add("@GUNCKIM", SqlDbType.NVarChar).Value = GUNCKIM;
                cmd.Parameters.Add("@GUNCTARIH", SqlDbType.SmallDateTime).Value = GUNCTARIH;
                cmd.Parameters.Add("@IPTAL", SqlDbType.Bit).Value = IPTAL;
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
                SqlCommand cmd = new SqlCommand("sp_FinansCariHesapHareketSil", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@LOGREF", SqlDbType.BigInt).Value = this._LOGREF;
                cmd.Parameters.Add("@MOD", SqlDbType.SmallInt).Value = this._MOD;
                cmd.Parameters.Add("@TUR", SqlDbType.SmallInt).Value = this._TUR;
                cmd.Parameters.Add("@FISNO", SqlDbType.VarChar, 9).Value = this._FISNO;
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
        public static void GetObjects(DataTable dt, bool Yeni)
        {
            string tablo = Yeni ? "vw_FinansCariHesapHareketler" : "vw_FinansCariHesapHareketler380";
            
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT [LOGREF],[MOD],[TUR],[ISY],[C/T],[BOLGE],[GRP],[EKP],[FIS TUR],[FIS AY],[FIS TAR],[MUSTERI],[FIS ACIKLAMA],[TAH TOP],[KES TUTAR],[KES YUZDE],[KES FARK],[FIS NO],[FIS VD],[FIS VD AY],[SAT KOD],[SAT TEM],[NST],[MUS KOD],[GUNC KIM],[GUNC TARIH],[IPTAL] FROM " + tablo + " ORDER BY [SAT TEM],[MUS KOD],[FIS TAR],[FIS TUR],[FIS NO]", conn);
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
        public static void GetObjectsByMusteri(DataTable dt, string Musteri, bool Yeni)
        {
            string tablo = Yeni ? "vw_FinansCariHesapHareketler" : "vw_FinansCariHesapHareketler380";

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT [LOGREF],[MOD],[TUR],[ISY],[C/T],[BOLGE],[GRP],[EKP],[FIS TUR],[FIS AY],[FIS TAR],[FIS ACIKLAMA],[TAH TOP],[KES TUTAR],[KES YUZDE],[KES FARK],[FIS NO],[FIS VD],[FIS VD AY],[SAT KOD],[SAT TEM],[NST],[MUS KOD],[MUSTERI],[GUNC KIM],[GUNC TARIH],[IPTAL] FROM " + tablo + " " + 
                    "WHERE MUSTERI LIKE '%" + Musteri + "%' " +
                    "ORDER BY [SAT TEM],[MUS KOD],[FIS TAR],[FIS TUR],[FIS NO]", conn);
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
        public static void GetObjects(DataTable dt)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_FinansCariHesapHareketlerGetir", conn);
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
        //
        //
        public static FinansCariHesapHareketler GetObject(long LOGREF, short MOD, short TUR, string FISNO)
        {
            FinansCariHesapHareketler fchh = null;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_FinansCariHesapHareketGetir", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@LOGREF", SqlDbType.BigInt).Value = LOGREF;
                cmd.Parameters.Add("@MOD", SqlDbType.SmallInt).Value = MOD;
                cmd.Parameters.Add("@TUR", SqlDbType.SmallInt).Value = TUR;
                cmd.Parameters.Add("@FISNO", SqlDbType.VarChar, 9).Value = FISNO;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        if (dr[0].ToString() != "")
                        fchh = new FinansCariHesapHareketler(LOGREF, MOD, TUR, FISNO, Convert.ToDouble(dr[3]), Convert.ToDouble(dr[4]),
                            dr[5].ToString(), DateTime.MinValue, Convert.ToBoolean(dr[7]));
                        else
                            fchh = new FinansCariHesapHareketler(LOGREF, MOD, TUR, FISNO, Convert.ToDouble(dr[3]), Convert.ToDouble(dr[4]),
                                dr[5].ToString(), DateTime.Parse(dr[6].ToString()), Convert.ToBoolean(dr[7]));
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

            return fchh;
        }
        //
        //
        public static bool VarMi(long LOGREF, short MOD, short TUR, string FISNO)
        {
            bool donendeger = false;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_FinansCariHesapHareketVarMi", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@LOGREF", SqlDbType.BigInt).Value = LOGREF;
                cmd.Parameters.Add("@MOD", SqlDbType.SmallInt).Value = MOD;
                cmd.Parameters.Add("@TUR", SqlDbType.SmallInt).Value = TUR;
                cmd.Parameters.Add("@FISNO", SqlDbType.VarChar, 9).Value = FISNO;
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

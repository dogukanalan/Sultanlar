using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Collections;

namespace Sultanlar.DatabaseObject.Internet
{
    public class SiparislerDetay : ISultanlar, IDisposable
    {
        //
        //
        //
        // Alanlar:
        //
        private long _pkSiparisDetayID;
        private int _intSiparisID;
        private int _intUrunID;
        private string  _strUrunAdi;
        private int _intMiktar;
        private decimal _mnFiyat;
        private Guid _unKampanyaKart;
        private bool _blKampanyaHediye;
        private Guid _unKampanyaSatir;
        private string _strMiktarTur;
        //
        //
        //
        // Constracter lar:
        //
        private SiparislerDetay(long pkSiparisDetayID, int intSiparisID, int intUrunID, string strUrunAdi, int intMiktar, decimal mnFiyat,
            Guid unKampanyaKart, bool blKampanyaHediye, Guid unKampanyaSatir, string strMiktarTur)
        {
            this._pkSiparisDetayID = pkSiparisDetayID;
            this._intSiparisID = intSiparisID;
            this._intUrunID = intUrunID;
            this._strUrunAdi = strUrunAdi;
            this._intMiktar = intMiktar;
            this._mnFiyat = mnFiyat;
            this._unKampanyaKart = unKampanyaKart;
            this._blKampanyaHediye = blKampanyaHediye;
            this._unKampanyaSatir = unKampanyaSatir;
            this._strMiktarTur = strMiktarTur;
        }
        //
        //
        public SiparislerDetay(int intSiparisID, int intUrunID, string strUrunAdi, int intMiktar, decimal mnFiyat, Guid unKampanyaKart,
            bool blKampanyaHediye, Guid unKampanyaSatir, string strMiktarTur)
        {
            this._intSiparisID = intSiparisID;
            this._intUrunID = intUrunID;
            this._strUrunAdi = strUrunAdi;
            this._intMiktar = intMiktar;
            this._mnFiyat = mnFiyat;
            this._unKampanyaKart = unKampanyaKart;
            this._blKampanyaHediye = blKampanyaHediye;
            this._unKampanyaSatir = unKampanyaSatir;
            this._strMiktarTur = strMiktarTur;
        }
        //
        //
        //
        // Özellikler:
        //
        public long pkSiparisDetayID { get { return this._pkSiparisDetayID; } }
        public int intSiparisID { get { return this._intSiparisID; } set { this._intSiparisID = value; } }
        public int intUrunID { get { return this._intUrunID; } set { this._intUrunID = value; } }
        public string strUrunAdi { get { return this._strUrunAdi; } set { this._strUrunAdi = value; } }
        public int intMiktar { get { return this._intMiktar; } set { this._intMiktar = value; } }
        public decimal mnFiyat { get { return this._mnFiyat; } set { this._mnFiyat = value; } }
        public Guid unKampanyaKart { get { return this._unKampanyaKart; } set { this._unKampanyaKart = value; } }
        public bool blKampanyaHediye { get { return this._blKampanyaHediye; } set { this._blKampanyaHediye = value; } }
        public Guid unKampanyaSatir { get { return this._unKampanyaSatir; } set { this._unKampanyaSatir = value; } }
        public string strMiktarTur { get { return this._strMiktarTur; } set { this._strMiktarTur = value; } }
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
            return this._intSiparisID.ToString();
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
                SqlCommand cmd = new SqlCommand("sp_INTERNET_SiparislerDetayEkle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@intSiparisID", SqlDbType.Int).Value = this._intSiparisID;
                cmd.Parameters.Add("@intUrunID", SqlDbType.Int).Value = this._intUrunID;
                cmd.Parameters.Add("@strUrunAdi", SqlDbType.NVarChar).Value = this._strUrunAdi;
                cmd.Parameters.Add("@intMiktar", SqlDbType.Int).Value = this._intMiktar;
                cmd.Parameters.Add("@mnFiyat", SqlDbType.Money).Value = this._mnFiyat;
                cmd.Parameters.Add("@unKampanyaKart", SqlDbType.UniqueIdentifier).Value = this._unKampanyaKart;
                cmd.Parameters.Add("@blKampanyaHediye", SqlDbType.Bit).Value = this._blKampanyaHediye;
                cmd.Parameters.Add("@unKampanyaSatir", SqlDbType.UniqueIdentifier).Value = this._unKampanyaSatir;
                cmd.Parameters.Add("@pkSiparisDetayID", SqlDbType.BigInt).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@strMiktarTur", SqlDbType.NVarChar, 5).Value = this._strMiktarTur;
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    this._pkSiparisDetayID = Convert.ToInt64(cmd.Parameters["@pkSiparisDetayID"].Value);
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
                SqlCommand cmd = new SqlCommand("sp_INTERNET_SiparislerDetayGuncelle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkSiparisDetayID", SqlDbType.BigInt).Value = this._pkSiparisDetayID;
                cmd.Parameters.Add("@intSiparisID", SqlDbType.Int).Value = this._intSiparisID;
                cmd.Parameters.Add("@intUrunID", SqlDbType.Int).Value = this._intUrunID;
                cmd.Parameters.Add("@strUrunAdi", SqlDbType.NVarChar).Value = this._strUrunAdi;
                cmd.Parameters.Add("@intMiktar", SqlDbType.Int).Value = this._intMiktar;
                cmd.Parameters.Add("@mnFiyat", SqlDbType.Money).Value = this._mnFiyat;
                cmd.Parameters.Add("@unKampanyaKart", SqlDbType.UniqueIdentifier).Value = this._unKampanyaKart;
                cmd.Parameters.Add("@blKampanyaHediye", SqlDbType.Bit).Value = this._blKampanyaHediye;
                cmd.Parameters.Add("@unKampanyaSatir", SqlDbType.UniqueIdentifier).Value = this._unKampanyaSatir;
                cmd.Parameters.Add("@strMiktarTur", SqlDbType.NVarChar, 5).Value = this._strMiktarTur;
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
                SqlCommand cmd = new SqlCommand("sp_INTERNET_SiparislerDetaySil", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkSiparisDetayID", SqlDbType.BigInt).Value = this._pkSiparisDetayID;
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
        public static void DoDelete(long SiparisDetayID)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_INTERNET_SiparislerDetaySil", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkSiparisDetayID", SqlDbType.BigInt).Value = SiparisDetayID;
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
        public static void DoDelete(int SiparisID, Guid KamKartRef)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_INTERNET_SiparislerDetaySilBySiparisIDandKamKartRef", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@intSiparisID", SqlDbType.Int).Value = SiparisID;
                cmd.Parameters.Add("@unKampanyaKart", SqlDbType.UniqueIdentifier).Value = KamKartRef;
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
        /// Siparişe ait bütün siparişlerdetayları silmek için
        /// </summary>
        public static void DoDelete(int SiparisID)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_INTERNET_SiparislerDetaySilBySiparisID", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@intSiparisID", SqlDbType.Int).Value = SiparisID;
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
        public static void GetObjectsBySiparisID(IList List, int SiparisID, bool UI)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                List.Clear();

                SqlCommand cmd = new SqlCommand("sp_INTERNET_SiparislerDetayGetirBySiparisID", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@intSiparisID", SqlDbType.Int).Value = SiparisID;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        List.Add(new SiparislerDetay(Convert.ToInt64(dr[0]), Convert.ToInt32(dr[1]), Convert.ToInt32(dr[2]), dr[3].ToString(),
                            Convert.ToInt32(dr[4]), Convert.ToDecimal(dr[5]), (Guid)dr[6], Convert.ToBoolean(dr[7]), 
                            Guid.Parse(dr[8].ToString()), dr[9].ToString()));
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
        public static void GetObjectsBySiparisID(DataTable dt, int SiparisID)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_INTERNET_SiparislerDetayGetirBySiparisID", conn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@intSiparisID", SqlDbType.Int).Value = SiparisID;
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
        public static void GetObjectsBySiparisID(DataTable dt, int SiparisID, int FiyatTipi, bool SiparisKaydetIcin)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_INTERNET_SiparislerDetayGetirBySiparisID", conn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@intSiparisID", SqlDbType.Int).Value = SiparisID;
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

            // barkod, fiyat ve iskontolar
            dt.Columns.Add("BARKOD", typeof(string));
            dt.Columns.Add("KDV", typeof(double));
            dt.Columns.Add("FIYAT", typeof(double));
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["BARKOD"] = Urunler.GetProductBarkod(Convert.ToInt32(dt.Rows[i]["intUrunID"]));
                dt.Rows[i]["KDV"] = Urunler.GetProductKDV(Convert.ToInt32(dt.Rows[i]["intUrunID"]));
                double[] ddd = Urunler.GetProductDiscountsAndPrice(Convert.ToInt32(dt.Rows[i]["intUrunID"]), FiyatTipi);
                dt.Rows[i]["FIYAT"] = ddd[4];

                if (FiyatTipi == 2)
                {
                    //if (Convert.ToDecimal(dt.Rows[i]["mnFiyat"]) == 0)
                    //{
                    //    dt.Rows[i]["ISK1"] = 100; dt.Rows[i]["ISK2"] = 0; dt.Rows[i]["ISK3"] = 0; dt.Rows[i]["ISK4"] = 0;
                    //}
                    //else if (ddd[4] > 0)
                    //{
                    //    double girilenbirimfiyat = Convert.ToDouble(dt.Rows[i]["mnFiyat"]);
                    //    double kdv = Convert.ToDouble(dt.Rows[i]["KDV"]);

                    //    double yazilacakfiyat = (100 * girilenbirimfiyat) / (100 + kdv);
                    //    dt.Rows[i]["FIYAT"] = yazilacakfiyat;
                    //    dt.Rows[i]["ISK1"] = 0; dt.Rows[i]["ISK2"] = 0; dt.Rows[i]["ISK3"] = 0; dt.Rows[i]["ISK4"] = 0;
                    //}
                }
                else if (Convert.ToBoolean(dt.Rows[i]["blKampanyaHediye"]))
                {
                    dt.Rows[i]["mnFiyat"] = 0;
                    dt.Rows[i]["ISK1"] = 100; dt.Rows[i]["ISK2"] = 0; dt.Rows[i]["ISK3"] = 0; dt.Rows[i]["ISK4"] = 0;
                }
                else
                {
                    dt.Rows[i]["ISK1"] = ddd[0];
                    dt.Rows[i]["ISK2"] = ddd[1];
                    dt.Rows[i]["ISK3"] = ddd[2];
                    dt.Rows[i]["ISK4"] = ddd[3];
                }
            }
        }
        //
        //
        public static SiparislerDetay GetObjectBySiparislerDetayID(long SiparislerDetayID)
        {
            SiparislerDetay siplerdetay = null;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_INTERNET_SiparislerDetayGetirBySiparislerDetayID", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkSiparisDetayID", SqlDbType.BigInt).Value = SiparislerDetayID;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        siplerdetay = new SiparislerDetay(Convert.ToInt64(dr[0]), Convert.ToInt32(dr[1]), Convert.ToInt32(dr[2]), dr[3].ToString(),
                            Convert.ToInt32(dr[4]), Convert.ToDecimal(dr[5]), (Guid)dr[6], Convert.ToBoolean(dr[7]),
                            Guid.Parse(dr[8].ToString()), dr[9].ToString());
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

            return siplerdetay;
        }
        /// <summary>
        /// Öneri siparişini çabuk eklemek için
        /// </summary>
        public static void DoInsertToplu(DataTable dt, int SiparisID, short FiyatTipi)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    int ITEMREF = Convert.ToInt32(dt.Rows[i]["ITEMREF"]);
                    SqlCommand cmd = new SqlCommand("INSERT INTO [tblINTERNET_SiparislerDetay] ([intSiparisID],[intUrunID],[strUrunAdi],[intMiktar],[mnFiyat],[unKampanyaKart],[blKampanyaHediye],[unKampanyaSatir],strMiktarTur) VALUES (@intSiparisID,@intUrunID,@strUrunAdi,@intMiktar,@mnFiyat,@unKampanyaKart,@blKampanyaHediye,@unKampanyaSatir,@strMiktarTur)", conn);
                    cmd.CommandTimeout = 500;
                    cmd.Parameters.Add("@intSiparisID", SqlDbType.Int).Value = SiparisID;
                    cmd.Parameters.Add("@intUrunID", SqlDbType.Int).Value = ITEMREF;
                    cmd.Parameters.Add("@strUrunAdi", SqlDbType.NVarChar).Value = dt.Rows[i]["MALZEME"].ToString();
                    cmd.Parameters.Add("@intMiktar", SqlDbType.Int).Value = 1;
                    cmd.Parameters.Add("@mnFiyat", SqlDbType.Money).Value = Urunler.GetProductPrice(ITEMREF, FiyatTipi);
                    cmd.Parameters.Add("@unKampanyaKart", SqlDbType.UniqueIdentifier).Value = Guid.Empty;
                    cmd.Parameters.Add("@blKampanyaHediye", SqlDbType.Bit).Value = false;
                    cmd.Parameters.Add("@unKampanyaSatir", SqlDbType.UniqueIdentifier).Value = Guid.Empty;
                    cmd.Parameters.Add("@strMiktarTur", SqlDbType.NVarChar).Value = "ST";
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
        }
        /// <summary>
        /// ISKONTOLAR, fiyat 10 da
        /// </summary>
        public static double[] GetObjectISKs(long SiparisDetayID)
        {
            double[] donendeger = new double[11];
            donendeger[0] = 0;
            donendeger[1] = 0;
            donendeger[2] = 0;
            donendeger[3] = 0;
            donendeger[4] = 0;
            donendeger[5] = 0;
            donendeger[6] = 0;
            donendeger[7] = 0;
            donendeger[8] = 0;
            donendeger[9] = 0;
            donendeger[10] = 0;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT [ISK1],[ISK2],[ISK3],[ISK4],[ISK5],[ISK6],[ISK7],[ISK8],[ISK9],[ISK10],[FIYAT] FROM [tblINTERNET_SiparislerDetayISK] WHERE bintSiparisDetayID = @bintSiparisDetayID", conn);
                cmd.Parameters.Add("@bintSiparisDetayID", SqlDbType.BigInt).Value = SiparisDetayID;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        object obj1 = dr[0];
                        object obj2 = dr[1];
                        object obj3 = dr[2];
                        object obj4 = dr[3];
                        object obj5 = dr[4];
                        object obj6 = dr[5];
                        object obj7 = dr[6];
                        object obj8 = dr[7];
                        object obj9 = dr[8];
                        object obj10 = dr[9];
                        object obj11 = dr[10];

                        if (obj1 != null)
                        {
                            donendeger[0] = Convert.ToDouble(dr[0]);
                            donendeger[1] = Convert.ToDouble(dr[1]);
                            donendeger[2] = Convert.ToDouble(dr[2]);
                            donendeger[3] = Convert.ToDouble(dr[3]);
                            donendeger[4] = Convert.ToDouble(dr[4]);
                            donendeger[5] = Convert.ToDouble(dr[5]);
                            donendeger[6] = Convert.ToDouble(dr[6]);
                            donendeger[7] = Convert.ToDouble(dr[7]);
                            donendeger[8] = Convert.ToDouble(dr[8]);
                            donendeger[9] = Convert.ToDouble(dr[9]);
                            donendeger[10] = Convert.ToDouble(dr[10]);
                        }
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
        /// <summary>
        /// ISKONTOLAR
        /// </summary>
        public static void DoInsertISKs(long SiparisDetayID, double FIYAT, double ISK1, double ISK2, double ISK3, double ISK4, double ISK5, double ISK6, double ISK7, double ISK8, double ISK9, double ISK10)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd1 = new SqlCommand("SELECT count(*) FROM [tblINTERNET_SiparislerDetayISK] WHERE bintSiparisDetayID = @bintSiparisDetayID", conn);
                cmd1.Parameters.Add("@bintSiparisDetayID", SqlDbType.BigInt).Value = SiparisDetayID;
                conn.Open();
                bool var = Convert.ToBoolean(cmd1.ExecuteScalar());
                conn.Close();

                SqlCommand cmd = new SqlCommand();
                if (var)
                    cmd = new SqlCommand("UPDATE [tblINTERNET_SiparislerDetayISK] SET [FIYAT] = @FIYAT,[ISK1] = @ISK1,[ISK2] = @ISK2,[ISK3] = @ISK3,[ISK4] = @ISK4,[ISK5] = @ISK5,[ISK6] = @ISK6,[ISK7] = @ISK7,[ISK8] = @ISK8,[ISK9] = @ISK9,[ISK10] = @ISK10 WHERE bintSiparisDetayID = @bintSiparisDetayID", conn);
                else
                    cmd = new SqlCommand("INSERT INTO [tblINTERNET_SiparislerDetayISK] ([bintSiparisDetayID],[FIYAT],[ISK1],[ISK2],[ISK3],[ISK4],[ISK5],[ISK6],[ISK7],[ISK8],[ISK9],[ISK10]) VALUES (@bintSiparisDetayID,@FIYAT,@ISK1,@ISK2,@ISK3,@ISK4,@ISK5,@ISK6,@ISK7,@ISK8,@ISK9,@ISK10)", conn);

                cmd.Parameters.Add("@bintSiparisDetayID", SqlDbType.BigInt).Value = SiparisDetayID;
                cmd.Parameters.Add("@FIYAT", SqlDbType.Float).Value = FIYAT;
                cmd.Parameters.Add("@ISK1", SqlDbType.Float).Value = ISK1;
                cmd.Parameters.Add("@ISK2", SqlDbType.Float).Value = ISK2;
                cmd.Parameters.Add("@ISK3", SqlDbType.Float).Value = ISK3;
                cmd.Parameters.Add("@ISK4", SqlDbType.Float).Value = ISK4;
                cmd.Parameters.Add("@ISK5", SqlDbType.Float).Value = ISK5;
                cmd.Parameters.Add("@ISK6", SqlDbType.Float).Value = ISK6;
                cmd.Parameters.Add("@ISK7", SqlDbType.Float).Value = ISK7;
                cmd.Parameters.Add("@ISK8", SqlDbType.Float).Value = ISK8;
                cmd.Parameters.Add("@ISK9", SqlDbType.Float).Value = ISK9;
                cmd.Parameters.Add("@ISK10", SqlDbType.Float).Value = ISK10;

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
        /// ISKONTOLAR
        /// </summary>
        public static void DoDeleteISKs(long SiparisDetayID)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd1 = new SqlCommand("SELECT count(*) FROM [tblINTERNET_SiparislerDetayISK] WHERE bintSiparisDetayID = @bintSiparisDetayID", conn);
                cmd1.Parameters.Add("@bintSiparisDetayID", SqlDbType.BigInt).Value = SiparisDetayID;
                conn.Open();
                bool var = Convert.ToBoolean(cmd1.ExecuteScalar());
                conn.Close();

                if (!var)
                    return;

                SqlCommand cmd = new SqlCommand("DELETE FROM [tblINTERNET_SiparislerDetayISK] WHERE bintSiparisDetayID = @bintSiparisDetayID", conn);
                cmd.Parameters.Add("@bintSiparisDetayID", SqlDbType.BigInt).Value = SiparisDetayID;
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
        /// ISKONTOLAR
        /// </summary>
        public static void DoChangeIDISKs(long EskiSiparisDetayID, long YeniSiparisDetayID)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UPDATE [tblINTERNET_SiparislerDetayISK] SET bintSiparisDetayID = @YeniSiparisDetayID WHERE bintSiparisDetayID = @EskiSiparisDetayID", conn);
                cmd.Parameters.Add("@EskiSiparisDetayID", SqlDbType.BigInt).Value = EskiSiparisDetayID;
                cmd.Parameters.Add("@YeniSiparisDetayID", SqlDbType.BigInt).Value = YeniSiparisDetayID;
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
        public static double GetKoliToplam(long SiparisDetayID)
        {
            double donendeger = 0;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT sum(CASE strMiktarTur WHEN 'KI' THEN [intMiktar] WHEN 'ST' THEN intMiktar / KOLI ELSE 0 END) AS Koli FROM [tblINTERNET_SiparislerDetay] INNER JOIN [Web-Malzeme-Full] ON [tblINTERNET_SiparislerDetay].[intUrunID] = [Web-Malzeme-Full].ITEMREF WHERE [pkSiparisDetayID] = @SiparisDetayID", conn);
                cmd.Parameters.Add("@SiparisDetayID", SqlDbType.BigInt).Value = SiparisDetayID;
                try
                {
                    conn.Open();
                    donendeger = Convert.ToDouble(cmd.ExecuteScalar());
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

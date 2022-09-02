using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Collections;

namespace Sultanlar.DatabaseObject.Internet
{
    public class IadelerDetay : ISultanlar, IDisposable
    {
        //
        //
        //
        // Alanlar:
        //
        private long _pkIadeDetayID;
        private int _intIadeID;
        private int _intUrunID;
        private string  _strUrunAdi;
        private int _intMiktar;
        private decimal _mnFiyat;
        //
        //
        //
        // Constracter lar:
        //
        private IadelerDetay(long pkIadeDetayID, int intIadeID, int intUrunID, string strUrunAdi, int intMiktar, decimal mnFiyat)
        {
            this._pkIadeDetayID = pkIadeDetayID;
            this._intIadeID = intIadeID;
            this._intUrunID = intUrunID;
            this._strUrunAdi = strUrunAdi;
            this._intMiktar = intMiktar;
            this._mnFiyat = mnFiyat;
        }
        //
        //
        public IadelerDetay(int intIadeID, int intUrunID, string strUrunAdi, int intMiktar, decimal mnFiyat)
        {
            this._intIadeID = intIadeID;
            this._intUrunID = intUrunID;
            this._strUrunAdi = strUrunAdi;
            this._intMiktar = intMiktar;
            this._mnFiyat = mnFiyat;
        }
        //
        //
        //
        // Özellikler:
        //
        public long pkIadeDetayID { get { return this._pkIadeDetayID; } }
        public int intIadeID { get { return this._intIadeID; } set { this._intIadeID = value; } }
        public int intUrunID { get { return this._intUrunID; } set { this._intUrunID = value; } }
        public string strUrunAdi { get { return this._strUrunAdi; } set { this._strUrunAdi = value; } }
        public int intMiktar { get { return this._intMiktar; } set { this._intMiktar = value; } }
        public decimal mnFiyat { get { return this._mnFiyat; } set { this._mnFiyat = value; } }
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
            return this._intIadeID.ToString();
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
                SqlCommand cmd = new SqlCommand("sp_INTERNET_IadelerDetayEkle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@intIadeID", SqlDbType.Int).Value = this._intIadeID;
                cmd.Parameters.Add("@intUrunID", SqlDbType.Int).Value = this._intUrunID;
                cmd.Parameters.Add("@strUrunAdi", SqlDbType.NVarChar).Value = this._strUrunAdi;
                cmd.Parameters.Add("@intMiktar", SqlDbType.Int).Value = this._intMiktar;
                cmd.Parameters.Add("@mnFiyat", SqlDbType.Money).Value = this._mnFiyat;
                cmd.Parameters.Add("@pkIadeDetayID", SqlDbType.BigInt).Direction = ParameterDirection.Output;
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    this._pkIadeDetayID = Convert.ToInt64(cmd.Parameters["@pkIadeDetayID"].Value);
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
                SqlCommand cmd = new SqlCommand("sp_INTERNET_IadelerDetayGuncelle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkIadeDetayID", SqlDbType.BigInt).Value = this._pkIadeDetayID;
                cmd.Parameters.Add("@intIadeID", SqlDbType.Int).Value = this._intIadeID;
                cmd.Parameters.Add("@intUrunID", SqlDbType.Int).Value = this._intUrunID;
                cmd.Parameters.Add("@strUrunAdi", SqlDbType.NVarChar).Value = this._strUrunAdi;
                cmd.Parameters.Add("@intMiktar", SqlDbType.Int).Value = this._intMiktar;
                cmd.Parameters.Add("@mnFiyat", SqlDbType.Money).Value = this._mnFiyat;
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
                SqlCommand cmd = new SqlCommand("sp_INTERNET_IadelerDetaySil", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkIadeDetayID", SqlDbType.BigInt).Value = this._pkIadeDetayID;
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
        public static void DoDelete(long IadeDetayID)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_INTERNET_IadelerDetaySil", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkIadeDetayID", SqlDbType.BigInt).Value = IadeDetayID;
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
        public static void DoDelete(int IadeID)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_INTERNET_IadelerDetaySilByIadeID", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@intIadeID", SqlDbType.Int).Value = IadeID;
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
        public static void GetObjectsByIadeID(IList List, int IadeID, bool UI)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                List.Clear();

                SqlCommand cmd = new SqlCommand("sp_INTERNET_IadelerDetayGetirByIadeID", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@intIadeID", SqlDbType.Int).Value = IadeID;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        List.Add(new IadelerDetay(Convert.ToInt64(dr[0]), Convert.ToInt32(dr[1]), Convert.ToInt32(dr[2]), dr[3].ToString(),
                            Convert.ToInt32(dr[4]), Convert.ToDecimal(dr[5])));
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
        public static void GetObjectsByIadeID(DataTable dt, int IadeID)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_INTERNET_IadelerDetayGetirByIadeID", conn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@intIadeID", SqlDbType.Int).Value = IadeID;
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

            dt.Columns.Add("BARKOD", typeof(string));
            dt.Columns.Add("mnToplam", typeof(decimal));
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["BARKOD"] = Urunler.GetProductBarkod(Convert.ToInt32(dt.Rows[i]["intUrunID"]));
                dt.Rows[i]["mnToplam"] = Convert.ToInt32(dt.Rows[i]["intMiktar"]) * Convert.ToDecimal(dt.Rows[i]["mnFiyat"]);
            }
        }
        //
        //
        public static void GetObjectsByIadeID(DataTable dt, int IadeID, int FiyatTipi, bool IadeKaydetIcin)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT pkIadeDetayID,intIadeID,intUrunID,strUrunAdi,intMiktar,mnFiyat,[Web-Malzeme-Full].BARKOD,[Web-Malzeme-Full].KDV,((mnFiyat * 100) / ([Web-Malzeme-Full].KDV + 100)) AS FIYAT,0 AS ISK1,0 AS ISK2,0 AS ISK3,0 AS ISK4 FROM tblINTERNET_IadelerDetay INNER JOIN [Web-Malzeme-Full] ON tblINTERNET_IadelerDetay.intUrunID = [Web-Malzeme-Full].ITEMREF WHERE intIadeID = @intIadeID", conn);
                //da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@intIadeID", SqlDbType.Int).Value = IadeID;
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

            //// barkod, kdv ve fiyat
            //dt.Columns.Add("BARKOD", typeof(string));
            //dt.Columns.Add("KDV", typeof(double));
            //dt.Columns.Add("FIYAT", typeof(double));
            //dt.Columns.Add("ISK1", typeof(double));
            //dt.Columns.Add("ISK2", typeof(double));
            //dt.Columns.Add("ISK3", typeof(double));
            //dt.Columns.Add("ISK4", typeof(double));
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    dt.Rows[i]["BARKOD"] = Urunler.GetProductBarkod(Convert.ToInt32(dt.Rows[i]["intUrunID"]), true);
            //    dt.Rows[i]["KDV"] = Urunler.GetProductKDV(Convert.ToInt32(dt.Rows[i]["intUrunID"]), true);
            //    dt.Rows[i]["FIYAT"] = (Convert.ToDouble(dt.Rows[i]["mnFiyat"]) * 100) / (Convert.ToDouble(dt.Rows[i]["KDV"]) + 100);

            //    dt.Rows[i]["ISK1"] = 0;
            //    dt.Rows[i]["ISK2"] = 0;
            //    dt.Rows[i]["ISK3"] = 0;
            //    dt.Rows[i]["ISK4"] = 0;
            //}
        }
        //
        //
        public static IadelerDetay GetObjectByIadelerDetayID(long IadelerDetayID)
        {
            IadelerDetay siplerdetay = null;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_INTERNET_IadelerDetayGetirByIadelerDetayID", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkIadeDetayID", SqlDbType.BigInt).Value = IadelerDetayID;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        siplerdetay = new IadelerDetay(Convert.ToInt64(dr[0]), Convert.ToInt32(dr[1]), Convert.ToInt32(dr[2]), dr[3].ToString(),
                            Convert.ToInt32(dr[4]), Convert.ToDecimal(dr[5]));
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
        //
        //
        public static void GetObjectsByIadeID_Fiy(DataTable dt, int IadeID)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT tblINTERNET_IadelerDetay.pkIadeDetayID,tblINTERNET_IadelerDetay.intIadeID,CASE WHEN (SELECT count(ITEMREF) FROM [Web-Malzeme] WHERE ITEMREF = tblINTERNET_IadelerDetay.intUrunID) = 0 THEN 'Hayır' ELSE 'Evet' END AS blKullanimda,tblINTERNET_IadelerDetay.intUrunID,tblINTERNET_IadelerDetay.strUrunAdi,(SELECT TOP 1 BARKOD FROM [Web-Malzeme-Full] WHERE ITEMREF = tblINTERNET_IadelerDetay.intUrunID) AS BARKOD,tblINTERNET_IadelerDetay.intMiktar,tblINTERNET_IadelerDetay.mnFiyat,tblINTERNET_IadelerDetay_Fiy.mnIadeToplam,(tblINTERNET_IadelerDetay_Fiy.mnHizmetToplam / tblINTERNET_IadelerDetay.intMiktar) AS mnHizmet,tblINTERNET_IadelerDetay_Fiy.mnHizmetToplam,(tblINTERNET_IadelerDetay.mnFiyat - (tblINTERNET_IadelerDetay_Fiy.mnHizmetToplam / tblINTERNET_IadelerDetay.intMiktar)) AS mnTutar,(tblINTERNET_IadelerDetay_Fiy.mnIadeToplam - tblINTERNET_IadelerDetay_Fiy.mnHizmetToplam) AS mnToplam,tblINTERNET_IadelerDetay_Fiy.dtFiyatlandirmaTarihi,tblINTERNET_IadelerDetay_Fiy.strFiyatlandiran,tblINTERNET_IadelerDetay_Fiy.dtHizmetTarihi,tblINTERNET_IadelerDetay_Fiy.strHizmetleyen FROM tblINTERNET_IadelerDetay LEFT OUTER JOIN tblINTERNET_IadelerDetay_Fiy ON tblINTERNET_IadelerDetay.pkIadeDetayID = tblINTERNET_IadelerDetay_Fiy.bintIadeDetayID WHERE intIadeID = @intIadeID ORDER BY tblINTERNET_IadelerDetay.strUrunAdi", conn);
                // dibine:  AND tblINTERNET_IadelerDetay.mnFiyat >= 0
                da.SelectCommand.Parameters.Add("@intIadeID", SqlDbType.Int).Value = IadeID;
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
        public static void SetSapDepo(string Depo, string UY, string PartiNo, long IadeDetayID)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UPDATE tblINTERNET_IadelerDetay SET strDepoKod = @strDepoKod, strDepoUY = @strDepoUY, strPartiNo = @strPartiNo WHERE pkIadeDetayID = @IadeDetayID", conn);
                cmd.Parameters.Add("@strDepoKod", SqlDbType.NVarChar, 50).Value = Depo;
                cmd.Parameters.Add("@strDepoUY", SqlDbType.NVarChar, 50).Value = UY;
                cmd.Parameters.Add("@strPartiNo", SqlDbType.VarChar, 10).Value = PartiNo;
                cmd.Parameters.Add("@IadeDetayID", SqlDbType.BigInt).Value = IadeDetayID;
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
        /// UY, Depo, Parti
        /// </summary>
        /// <returns></returns>
        public static string[] GetSapDepo(long IadeDetayID)
        {
            string[] donendeger = new string[3];

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT strDepoUY, strDepoKod, strPartiNo FROM tblINTERNET_IadelerDetay WHERE pkIadeDetayID = @IadeDetayID", conn);
                cmd.Parameters.Add("@IadeDetayID", SqlDbType.BigInt).Value = IadeDetayID;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        donendeger[0] = dr[0].ToString();
                        donendeger[1] = dr[1].ToString();
                        donendeger[2] = dr[2].ToString();
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
    }
}

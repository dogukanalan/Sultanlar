using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Collections;

namespace Sultanlar.DatabaseObject.Internet
{
    public class IadelerDetayFiy : ISultanlar, IDisposable
    {
        //
        //
        //
        // Alanlar:
        //
        private long _bintIadeDetayID;
        private decimal _mnIadeToplam;
        private decimal _mnHizmetToplam;
        private DateTime _dtFiyatlandirmaTarihi;
        private string _strFiyatlandiran;
        private DateTime _dtHizmetTarihi;
        private string _strHizmetleyen;
        //
        //
        //
        // Constracter lar:
        //
        public IadelerDetayFiy(long bintIadeDetayID, decimal mnIadeToplam, decimal mnHizmetToplam, DateTime dtFiyatlandirmaTarihi,
            string strFiyatlandiran, DateTime dtHizmetTarihi, string strHizmetleyen)
        {
            this._bintIadeDetayID = bintIadeDetayID;
            this._mnIadeToplam = mnIadeToplam;
            this._mnHizmetToplam = mnHizmetToplam;
            this._dtFiyatlandirmaTarihi = dtFiyatlandirmaTarihi;
            this._strFiyatlandiran = strFiyatlandiran;
            this._dtHizmetTarihi = dtHizmetTarihi;
            this._strHizmetleyen = strHizmetleyen;
        }
        //
        //
        public IadelerDetayFiy()
        {
            this._bintIadeDetayID = 0;
            this._mnIadeToplam = 0;
            this._mnHizmetToplam = 0;
            this._dtFiyatlandirmaTarihi = DateTime.MinValue;
            this._strFiyatlandiran = string.Empty;
            this._dtHizmetTarihi = DateTime.MinValue;
            this._strHizmetleyen = string.Empty;
        }
        //
        //
        //
        // Özellikler:
        //
        public long bintIadeDetayID { get { return this._bintIadeDetayID; } }
        public decimal mnIadeToplam { get { return this._mnIadeToplam; } set { this._mnIadeToplam = value; } }
        public decimal mnHizmetToplam { get { return this._mnHizmetToplam; } set { this._mnHizmetToplam = value; } }
        public DateTime dtFiyatlandirmaTarihi { get { return this._dtFiyatlandirmaTarihi; } set { this._dtFiyatlandirmaTarihi = value; } }
        public string strFiyatlandiran { get { return this._strFiyatlandiran; } set { this._strFiyatlandiran = value; } }
        public DateTime dtHizmetTarihi { get { return this._dtHizmetTarihi; } set { this._dtHizmetTarihi = value; } }
        public string strHizmetleyen { get { return this._strHizmetleyen; } set { this._strHizmetleyen = value; } }
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
            return this._bintIadeDetayID.ToString();
        }
        //
        //
        //
        // Metodlar:
        //
        public void DoInsert()
        {
            object HizmetTarihi = DBNull.Value;
            if (this._dtHizmetTarihi != DateTime.MinValue)
                HizmetTarihi = this._dtHizmetTarihi;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO tblINTERNET_IadelerDetay_Fiy ([bintIadeDetayID],[mnIadeToplam],[mnHizmetToplam],[dtFiyatlandirmaTarihi],[strFiyatlandiran],[dtHizmetTarihi],[strHizmetleyen]) VALUES (@bintIadeDetayID,@mnIadeToplam,@mnHizmetToplam,@dtFiyatlandirmaTarihi,@strFiyatlandiran,@dtHizmetTarihi,@strHizmetleyen)", conn);
                cmd.Parameters.Add("@bintIadeDetayID", SqlDbType.BigInt).Value = this._bintIadeDetayID;
                cmd.Parameters.Add("@mnIadeToplam", SqlDbType.Money).Value = this._mnIadeToplam;
                cmd.Parameters.Add("@mnHizmetToplam", SqlDbType.Money).Value = this._mnHizmetToplam;
                cmd.Parameters.Add("@dtFiyatlandirmaTarihi", SqlDbType.DateTime).Value = this._dtFiyatlandirmaTarihi;
                cmd.Parameters.Add("@strFiyatlandiran", SqlDbType.NVarChar).Value = this._strFiyatlandiran;
                cmd.Parameters.Add("@dtHizmetTarihi", SqlDbType.DateTime).Value = HizmetTarihi;
                cmd.Parameters.Add("@strHizmetleyen", SqlDbType.NVarChar).Value = this._strHizmetleyen;
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
            object HizmetTarihi = DBNull.Value;
            if (this._dtHizmetTarihi != DateTime.MinValue)
                HizmetTarihi = this._dtHizmetTarihi;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UPDATE tblINTERNET_IadelerDetay_Fiy SET [mnIadeToplam] = @mnIadeToplam,[mnHizmetToplam] = @mnHizmetToplam,[dtFiyatlandirmaTarihi] = @dtFiyatlandirmaTarihi,[strFiyatlandiran] = @strFiyatlandiran,[dtHizmetTarihi] = @dtHizmetTarihi,[strHizmetleyen] = @strHizmetleyen WHERE bintIadeDetayID = @bintIadeDetayID", conn);
                cmd.Parameters.Add("@bintIadeDetayID", SqlDbType.BigInt).Value = this._bintIadeDetayID;
                cmd.Parameters.Add("@mnIadeToplam", SqlDbType.Money).Value = this._mnIadeToplam;
                cmd.Parameters.Add("@mnHizmetToplam", SqlDbType.Money).Value = this._mnHizmetToplam;
                cmd.Parameters.Add("@dtFiyatlandirmaTarihi", SqlDbType.DateTime).Value = this._dtFiyatlandirmaTarihi;
                cmd.Parameters.Add("@strFiyatlandiran", SqlDbType.NVarChar).Value = this._strFiyatlandiran;
                cmd.Parameters.Add("@dtHizmetTarihi", SqlDbType.DateTime).Value = HizmetTarihi;
                cmd.Parameters.Add("@strHizmetleyen", SqlDbType.NVarChar).Value = this._strHizmetleyen;
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
                SqlCommand cmd = new SqlCommand("DELETE FROM tblINTERNET_IadelerDetay_Fiy WHERE bintIadeDetayID = @bintIadeDetayID", conn);
                cmd.Parameters.Add("@bintIadeDetayID", SqlDbType.BigInt).Value = this._bintIadeDetayID;
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
        public static IadelerDetayFiy GetObjectByIadelerDetayID(long IadeDetayID)
        {
            IadelerDetayFiy siplerdetay = null;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT [bintIadeDetayID],[mnIadeToplam],[mnHizmetToplam],[dtFiyatlandirmaTarihi],[strFiyatlandiran],[dtHizmetTarihi],[strHizmetleyen] FROM [tblINTERNET_IadelerDetay_Fiy] WHERE bintIadeDetayID = @bintIadeDetayID", conn);
                cmd.Parameters.Add("@bintIadeDetayID", SqlDbType.BigInt).Value = IadeDetayID;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        DateTime HizmetTarihi = dr[5] != DBNull.Value ? Convert.ToDateTime(dr[5]) : DateTime.MinValue;

                        siplerdetay = new IadelerDetayFiy(Convert.ToInt64(dr[0]), Convert.ToDecimal(dr[1]), Convert.ToDecimal(dr[2]),
                            Convert.ToDateTime(dr[3]), dr[4].ToString(), HizmetTarihi, dr[6].ToString());
                    }
                    else
                    {
                        siplerdetay = new IadelerDetayFiy();
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
    }
}

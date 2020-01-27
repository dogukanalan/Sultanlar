using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Sultanlar.DatabaseObject.Internet
{
    public class IadeFaturaTakip : ISultanlar, IDisposable
    {
        //
        //
        //
        // Alanlar:
        //
        private int _pkID;
        private int _intMusteriID;
        private int _SMREF;
        private string _strFatNo;
        private DateTime _dtGiris;
        private string _strAciklama;
        private bool _blKontrol;
        private DateTime _dtKontrol;
        private string _strKontrol;
        private bool _blPazarlama;
        private DateTime _dtPazarlama;
        private string _strPazarlama;
        //
        //
        //
        // Constracter lar:
        //
        private IadeFaturaTakip(int pkID, int intMusteriID, int SMREF, string strFatNo, DateTime dtGiris, string strAciklama, bool blKontrol, DateTime dtKontrol, 
            string strKontrol, bool blPazarlama, DateTime dtPazarlama, string strPazarlama)
        {
            this._pkID = pkID;
            this._intMusteriID = intMusteriID;
            this._SMREF = SMREF;
            this._strFatNo = strFatNo;
            this._dtGiris = dtGiris;
            this._strAciklama = strAciklama;
            this._blKontrol = blKontrol;
            this._dtKontrol = dtKontrol;
            this._strKontrol = strKontrol;
            this._blPazarlama = blPazarlama;
            this._dtPazarlama = dtPazarlama;
            this._strPazarlama = strPazarlama;
        }
        //
        //
        public IadeFaturaTakip(int intMusteriID, int SMREF, string strFatNo, DateTime dtGiris, string strAciklama, bool blKontrol, DateTime dtKontrol,
            string strKontrol, bool blPazarlama, DateTime dtPazarlama, string strPazarlama)
        {
            this._intMusteriID = intMusteriID;
            this._SMREF = SMREF;
            this._strFatNo = strFatNo;
            this._dtGiris = dtGiris;
            this._strAciklama = strAciklama;
            this._blKontrol = blKontrol;
            this._dtKontrol = dtKontrol;
            this._strKontrol = strKontrol;
            this._blPazarlama = blPazarlama;
            this._dtPazarlama = dtPazarlama;
            this._strPazarlama = strPazarlama;
        }
        //
        //
        private IadeFaturaTakip()
        {
            this._pkID = 0;
        }
        //
        //
        //
        // Özellikler:
        //
        public int pkID { get { return this._pkID; } }
        public int intMusteriID { get { return this._intMusteriID; } set { this._intMusteriID = value; } }
        public int SMREF { get { return this._SMREF; } set { this._SMREF = value; } }
        public string strFatNo { get { return this._strFatNo; } set { this._strFatNo = value; } }
        public DateTime dtGiris { get { return this._dtGiris; } set { this._dtGiris = value; } }
        public string strAciklama { get { return this._strAciklama; } set { this._strAciklama = value; } }
        public bool blKontrol { get { return this._blKontrol; } set { this._blKontrol = value; } }
        public DateTime dtKontrol { get { return this._dtKontrol; } set { this._dtKontrol = value; } }
        public string strKontrol { get { return this._strKontrol; } set { this._strKontrol = value; } }
        public bool blPazarlama { get { return this._blPazarlama; } set { this._blPazarlama = value; } }
        public DateTime dtPazarlama { get { return this._dtPazarlama; } set { this._dtPazarlama = value; } }
        public string strPazarlama { get { return this._strPazarlama; } set { this._strPazarlama = value; } }
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
            return this._strFatNo;
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
                SqlCommand cmd = new SqlCommand("INSERT INTO [tblINTERNET_IadeFaturaTakip] ([intMusteriID],[SMREF],[strFatNo],[dtGiris],[strAciklama],[blKontrol],[dtKontrol],[strKontrol],[blPazarlama],[dtPazarlama],[strPazarlama]) VALUES (@intMusteriID,@SMREF,@strFatNo,@dtGiris,@strAciklama,@blKontrol,@dtKontrol,@strKontrol,@blPazarlama,@dtPazarlama,@strPazarlama) SELECT @pkID = SCOPE_IDENTITY()", conn);
                cmd.Parameters.Add("@intMusteriID", SqlDbType.Int).Value = this._intMusteriID;
                cmd.Parameters.Add("@SMREF", SqlDbType.Int).Value = this._SMREF;
                cmd.Parameters.Add("@strFatNo", SqlDbType.NVarChar, 20).Value = this._strFatNo;
                cmd.Parameters.Add("@dtGiris", SqlDbType.DateTime).Value = this._dtGiris;
                cmd.Parameters.Add("@strAciklama", SqlDbType.NVarChar).Value = this._strAciklama;
                cmd.Parameters.Add("@blKontrol", SqlDbType.Bit).Value = false;
                cmd.Parameters.Add("@dtKontrol", SqlDbType.DateTime).Value = DBNull.Value;
                cmd.Parameters.Add("@strKontrol", SqlDbType.NVarChar).Value = string.Empty;
                cmd.Parameters.Add("@blPazarlama", SqlDbType.Bit).Value = false;
                cmd.Parameters.Add("@dtPazarlama", SqlDbType.DateTime).Value = DBNull.Value;
                cmd.Parameters.Add("@strPazarlama", SqlDbType.NVarChar).Value = string.Empty;
                cmd.Parameters.Add("@pkID", SqlDbType.Int).Direction = ParameterDirection.Output;
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    this._pkID = Convert.ToInt32(cmd.Parameters["@pkID"].Value);
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
                SqlCommand cmd = new SqlCommand("UPDATE [tblINTERNET_IadeFaturaTakip] SET [intMusteriID] = @intMusteriID,SMREF = @SMREF,[strFatNo] = @strFatNo,[dtGiris] = @dtGiris,[strAciklama] = @strAciklama,[blKontrol] = @blKontrol,[dtKontrol] = @dtKontrol,[strKontrol] = @strKontrol,[blPazarlama] = @blPazarlama,[dtPazarlama] = @dtPazarlama,[strPazarlama] = @strPazarlama WHERE pkID = @pkID", conn);
                cmd.Parameters.Add("@pkID", SqlDbType.Int).Value = this._pkID;
                cmd.Parameters.Add("@intMusteriID", SqlDbType.Int).Value = this._intMusteriID;
                cmd.Parameters.Add("@SMREF", SqlDbType.Int).Value = this._SMREF;
                cmd.Parameters.Add("@strFatNo", SqlDbType.NVarChar, 20).Value = this._strFatNo;
                cmd.Parameters.Add("@dtGiris", SqlDbType.DateTime).Value = this._dtGiris;
                cmd.Parameters.Add("@strAciklama", SqlDbType.NVarChar).Value = this._strAciklama;
                cmd.Parameters.Add("@blKontrol", SqlDbType.Bit).Value = this._blKontrol;
                cmd.Parameters.Add("@dtKontrol", SqlDbType.DateTime).Value = this._dtKontrol;
                cmd.Parameters.Add("@strKontrol", SqlDbType.NVarChar).Value = this._strKontrol;
                cmd.Parameters.Add("@blPazarlama", SqlDbType.Bit).Value = this._blPazarlama;
                cmd.Parameters.Add("@dtPazarlama", SqlDbType.DateTime).Value = this._dtPazarlama;
                cmd.Parameters.Add("@strPazarlama", SqlDbType.NVarChar).Value = this._strPazarlama;
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
        public static void DoUpdate(int pkID, bool blKontrol, DateTime dtKontrol, string strKontrol)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UPDATE [tblINTERNET_IadeFaturaTakip] SET [blKontrol] = @blKontrol,[dtKontrol] = @dtKontrol,[strKontrol] = @strKontrol WHERE pkID = @pkID", conn);
                cmd.Parameters.Add("@pkID", SqlDbType.Int).Value = pkID;
                cmd.Parameters.Add("@blKontrol", SqlDbType.Bit).Value = blKontrol;
                cmd.Parameters.Add("@dtKontrol", SqlDbType.DateTime).Value = dtKontrol;
                cmd.Parameters.Add("@strKontrol", SqlDbType.NVarChar).Value = strKontrol;
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
        public static void DoUpdate(int pkID, bool blPazarlama, DateTime dtPazarlama, string strPazarlama, bool pazarlama)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UPDATE [tblINTERNET_IadeFaturaTakip] SET [blPazarlama] = @blPazarlama,[dtPazarlama] = @dtPazarlama,[strPazarlama] = @strPazarlama WHERE pkID = @pkID", conn);
                cmd.Parameters.Add("@pkID", SqlDbType.Int).Value = pkID;
                cmd.Parameters.Add("@blPazarlama", SqlDbType.Bit).Value = blPazarlama;
                cmd.Parameters.Add("@dtPazarlama", SqlDbType.DateTime).Value = dtPazarlama;
                cmd.Parameters.Add("@strPazarlama", SqlDbType.NVarChar).Value = strPazarlama;
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
                SqlCommand cmd = new SqlCommand("DELETE FROM [tblINTERNET_IadeFaturaTakip] WHERE pkID = @pkID", conn);
                cmd.Parameters.Add("@pkID", SqlDbType.Int).Value = this._pkID;
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
        public static void GetObjects(DataTable dt)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT DISTINCT [pkID],[intMusteriID],(SELECT strAd + ' ' + strSoyad FROM tblINTERNET_Musteriler WHERE pkMusteriID = [intMusteriID]) AS strAdSoyad,[Web-Musteri].SMREF,[Web-Musteri].MUSTERI,[Web-Musteri].SUBE,[strFatNo],[dtGiris],[strAciklama],[blKontrol],[dtKontrol],[strKontrol],[blPazarlama],[dtPazarlama],[strPazarlama] FROM [tblINTERNET_IadeFaturaTakip] INNER JOIN [Web-Musteri] ON [tblINTERNET_IadeFaturaTakip].SMREF = [Web-Musteri].SMREF ORDER BY dtGiris DESC", conn);
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
        public static void GetObjects(DataTable dt, int SMREF)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT DISTINCT [pkID],[intMusteriID],(SELECT strAd + ' ' + strSoyad FROM tblINTERNET_Musteriler WHERE pkMusteriID = [intMusteriID]) AS strAdSoyad,[Web-Musteri].SMREF,[Web-Musteri].MUSTERI,[Web-Musteri].SUBE,[strFatNo],[dtGiris],[strAciklama],[blKontrol],[dtKontrol],[strKontrol],[blPazarlama],[dtPazarlama],[strPazarlama] FROM [tblINTERNET_IadeFaturaTakip] INNER JOIN [Web-Musteri] ON [tblINTERNET_IadeFaturaTakip].SMREF = [Web-Musteri].SMREF WHERE tblINTERNET_IadeFaturaTakip.SMREF = @SMREF ORDER BY dtGiris DESC", conn);
                try
                {
                    da.SelectCommand.Parameters.Add("@SMREF", SqlDbType.Int).Value = SMREF;
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
        public static IadeFaturaTakip GetObject(int ID)
        {
            IadeFaturaTakip donendeger = new IadeFaturaTakip();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT [pkID],[intMusteriID],SMREF,[strFatNo],[dtGiris],[strAciklama],[blKontrol],[dtKontrol],[strKontrol],[blPazarlama],[dtPazarlama],[strPazarlama] FROM [tblINTERNET_IadeFaturaTakip] WHERE pkID = @pkID", conn);
                cmd.Parameters.Add("@pkID", SqlDbType.Int).Value = ID;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        donendeger._pkID = Convert.ToInt32(dr[0]);
                        donendeger._intMusteriID = Convert.ToInt32(dr[1]);
                        donendeger._SMREF = Convert.ToInt32(dr[2]);
                        donendeger._strFatNo = dr[3].ToString();
                        donendeger._dtGiris = Convert.ToDateTime(dr[4]);
                        donendeger._strAciklama = dr[5].ToString();
                        donendeger._blKontrol = Convert.ToBoolean(dr[6]);
                        donendeger._dtKontrol = dr[7] != DBNull.Value ? Convert.ToDateTime(dr[7]) : DateTime.MinValue;
                        donendeger._strKontrol = dr[8].ToString();
                        donendeger._blPazarlama = Convert.ToBoolean(dr[9]);
                        donendeger._dtPazarlama = dr[10] != DBNull.Value ? Convert.ToDateTime(dr[10]) : DateTime.MinValue;
                        donendeger._strPazarlama = dr[11].ToString();
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

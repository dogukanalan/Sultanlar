using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Collections;
using System.Web.UI.WebControls;

namespace Sultanlar.DatabaseObject.Internet
{
    public class AlinanMesajlar : ISultanlar, IDisposable
    {
        //
        //
        //
        // Alanlar:
        //
        private int _pkMesajID;
        private int _intMusteriID;
        private byte _tintDepartmanID;
        private string _strKonu;
        private string _strIcerik;
        private DateTime _dtGondermeZamani;
        private DateTime _dtOkunmaZamani;
        private bool _blOkundu;
        private bool _blGonderenSil;
        private bool _blOkuyanSil;
        //
        //
        //
        // Constracter lar:
        //
        private AlinanMesajlar(int pkMesajID, int intMusteriID, byte tintDepartmanID, string strKonu, string strIcerik, DateTime dtGondermeZamani,
            DateTime dtOkunmaZamani, bool blOkundu, bool blGonderenSil, bool blOkuyanSil)
        {
            this._pkMesajID = pkMesajID;
            this._intMusteriID = intMusteriID;
            this._tintDepartmanID = tintDepartmanID;
            this._strKonu = strKonu;
            this._strIcerik = strIcerik;
            this._dtGondermeZamani = dtGondermeZamani;
            this._dtOkunmaZamani = dtOkunmaZamani;
            this._blOkundu = blOkundu;
            this._blGonderenSil = blGonderenSil;
            this._blOkuyanSil = blOkuyanSil;
        }
        //
        //
        public AlinanMesajlar(int intMusteriID, byte tintDepartmanID, string strKonu, string strIcerik, DateTime dtGondermeZamani,
            DateTime dtOkunmaZamani, bool blOkundu, bool blGonderenSil, bool blOkuyanSil)
        {
            this._intMusteriID = intMusteriID;
            this._tintDepartmanID = tintDepartmanID;
            this._strKonu = strKonu;
            this._strIcerik = strIcerik;
            this._dtGondermeZamani = dtGondermeZamani;
            this._dtOkunmaZamani = dtOkunmaZamani;
            this._blOkundu = blOkundu;
            this._blGonderenSil = blGonderenSil;
            this._blOkuyanSil = blOkuyanSil;
        }
        //
        //
        //
        // Özellikler:
        //
        public int pkMesajID { get { return this._pkMesajID; } }
        public int intMusteriID { get { return this._intMusteriID; } set { this._intMusteriID = value; } }
        public byte tintDepartmanID { get { return this._tintDepartmanID; } set { this._tintDepartmanID = value; } }
        public string strKonu { get { return this._strKonu; } set { this._strKonu = value; } }
        public string strIcerik { get { return this._strIcerik; } set { this._strIcerik = value; } }
        public DateTime dtGondermeZamani { get { return this._dtGondermeZamani; } set { this._dtGondermeZamani = value; } }
        public DateTime dtOkunmaZamani { get { return this._dtOkunmaZamani; } set { this._dtOkunmaZamani = value; } }
        public bool blOkundu { get { return this._blOkundu; } set { this._blOkundu = value; } }
        public bool blGonderenSil { get { return this._blGonderenSil; } set { this._blGonderenSil = value; } }
        public bool blOkuyanSil { get { return this._blOkuyanSil; } set { this._blOkuyanSil = value; } }
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
            return this._strKonu + " - " + this._dtGondermeZamani.ToString();
        }
        //
        //
        //
        // Metodlar:
        //
        public void DoInsert()
        {
            object GondermeZamani = DBNull.Value;
            object OkunmaZamani = DBNull.Value;
            if (_dtGondermeZamani != DateTime.MinValue)
                GondermeZamani = this._dtGondermeZamani;
            if (_dtOkunmaZamani != DateTime.MinValue)
                OkunmaZamani = this._dtOkunmaZamani;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_INTERNET_AlinanMesajEkle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@intMusteriID", SqlDbType.Int).Value = this._intMusteriID;
                cmd.Parameters.Add("@tintDepartmanID", SqlDbType.TinyInt).Value = this._tintDepartmanID;
                cmd.Parameters.Add("@strKonu", SqlDbType.NVarChar).Value = this._strKonu;
                cmd.Parameters.Add("@strIcerik", SqlDbType.NVarChar).Value = this._strIcerik;
                cmd.Parameters.Add("@dtGondermeZamani", SqlDbType.DateTime).Value = GondermeZamani;
                cmd.Parameters.Add("@dtOkunmaZamani", SqlDbType.DateTime).Value = OkunmaZamani;
                cmd.Parameters.Add("@blOkundu", SqlDbType.Bit).Value = this._blOkundu;
                cmd.Parameters.Add("@blGonderenSil", SqlDbType.Bit).Value = this._blGonderenSil;
                cmd.Parameters.Add("@blOkuyanSil", SqlDbType.Bit).Value = this._blOkuyanSil;
                cmd.Parameters.Add("@pkMesajID", SqlDbType.Int).Direction = ParameterDirection.Output;
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    this._pkMesajID = Convert.ToInt32(cmd.Parameters["@pkMesajID"].Value);
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
            object GondermeZamani = DBNull.Value;
            object OkunmaZamani = DBNull.Value;
            if (_dtGondermeZamani != DateTime.MinValue)
                GondermeZamani = this._dtGondermeZamani;
            if (_dtOkunmaZamani != DateTime.MinValue)
                OkunmaZamani = this._dtOkunmaZamani;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_INTERNET_AlinanMesajGuncelle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkMesajID", SqlDbType.Int).Value = this._pkMesajID;
                cmd.Parameters.Add("@intMusteriID", SqlDbType.Int).Value = this._intMusteriID;
                cmd.Parameters.Add("@tintDepartmanID", SqlDbType.TinyInt).Value = this._tintDepartmanID;
                cmd.Parameters.Add("@strKonu", SqlDbType.NVarChar).Value = this._strKonu;
                cmd.Parameters.Add("@strIcerik", SqlDbType.NVarChar).Value = this._strIcerik;
                cmd.Parameters.Add("@dtGondermeZamani", SqlDbType.DateTime).Value = GondermeZamani;
                cmd.Parameters.Add("@dtOkunmaZamani", SqlDbType.DateTime).Value = OkunmaZamani;
                cmd.Parameters.Add("@blOkundu", SqlDbType.Bit).Value = this._blOkundu;
                cmd.Parameters.Add("@blGonderenSil", SqlDbType.Bit).Value = this._blGonderenSil;
                cmd.Parameters.Add("@blOkuyanSil", SqlDbType.Bit).Value = this._blOkuyanSil;
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
        public static void DoUpdateOkundu(int MesajID, DateTime OkunmaZamani)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_INTERNET_AlinanMesajGuncelleOkundu", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkMesajID", SqlDbType.Int).Value = MesajID;
                cmd.Parameters.Add("@dtOkunmaZamani", SqlDbType.DateTime).Value = OkunmaZamani;
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
                SqlCommand cmd = new SqlCommand("sp_INTERNET_AlinanMesajSil", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkMesajID", SqlDbType.Int).Value = this._pkMesajID;
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
        public static void DoDelete(int MesajID, bool Gonderen)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_INTERNET_AlinanMesajSilOkuyan", conn);
                if (Gonderen)
                    cmd.CommandText = "sp_INTERNET_AlinanMesajSilGonderen";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkMesajID", SqlDbType.Int).Value = MesajID;
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

                SqlCommand cmd = new SqlCommand("sp_INTERNET_AlinanMesajlarGetir", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        DateTime GondermeZamani = DateTime.MinValue;
                        DateTime OkunmaZamani = DateTime.MinValue;
                        if (dr[5] != DBNull.Value)
                            GondermeZamani = Convert.ToDateTime(dr[5]);
                        if (dr[6] != DBNull.Value)
                            OkunmaZamani = Convert.ToDateTime(dr[6]);

                        List.Add(new AlinanMesajlar(Convert.ToInt32(dr[0]), Convert.ToInt32(dr[1]), Convert.ToByte(dr[2]), dr[3].ToString(),
                            dr[4].ToString(), GondermeZamani, OkunmaZamani, Convert.ToBoolean(dr[7]), Convert.ToBoolean(dr[8]), 
                            Convert.ToBoolean(dr[9])));
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
                SqlDataAdapter da = new SqlDataAdapter("sp_INTERNET_AlinanMesajlarGetirByMusteriID", conn);
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
        public static void GetObjects(DataTable dt, int MusteriID, int DepartmanID)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_INTERNET_AlinanMesajlarGetirByDepartmanIDMusteriID", conn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@intMusteriID", SqlDbType.Int).Value = MusteriID;
                da.SelectCommand.Parameters.Add("@tintDepartmanID", SqlDbType.TinyInt).Value = DepartmanID;
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
        public static void GetObjects(DataTable dt, byte DepartmanID, DateTime GondermeZamani)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_INTERNET_AlinanMesajlarGetirByDepartmanID", conn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@tintDepartmanID", SqlDbType.TinyInt).Value = DepartmanID;
                da.SelectCommand.Parameters.Add("@dtGondermeZamani", SqlDbType.DateTime).Value = GondermeZamani;
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

            for (int i = 0; i < dt.Rows.Count; i++)
                dt.Rows[i]["strIcerik"] = dt.Rows[i]["strIcerik"].ToString().Replace("<br />", "\r\n");
        }
        /// <summary>
        /// konu, içerik, gönderme zamanı
        /// </summary>
        public static ArrayList GetObject(int MesajID)
        {
            ArrayList donendeger = new ArrayList();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_INTERNET_AlinanMesajGetir", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkMesajID", SqlDbType.Int).Value = MesajID;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        donendeger.Add(dr[3].ToString());
                        donendeger.Add(dr[4].ToString());
                        donendeger.Add(dr[5].ToString());
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Sultanlar.DatabaseObject.Internet
{
    public class CariHesapEk : IDisposable, ISultanlar
    {
        public int _pkID { get; set; }
        public int _SMREF { get; set; }
        public string _strIadeIlgili { get; set; }
        //
        //
        //
        // Constracter lar:
        //
        private CariHesapEk(int pkID, int SMREF, string strIadeIlgili)
        {
            this._pkID = pkID;
            this._SMREF = SMREF;
            this._strIadeIlgili = strIadeIlgili;
        }
        //
        //
        private CariHesapEk(int SMREF, string strIadeIlgili)
        {
            this._SMREF = SMREF;
            this._strIadeIlgili = strIadeIlgili;
        }
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
        // Metodlar:
        //
        public void DoInsert()
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO tblINTERNET_CariHesapEk (SMREF,strIadeIlgili) VALUES (@SMREF,@strIadeIlgili) SELECT @pkID = SCOPE_IDENTITY()", conn);
                cmd.Parameters.Add("@SMREF", SqlDbType.Int).Value = this._SMREF;
                cmd.Parameters.Add("@strIadeIlgili", SqlDbType.NVarChar).Value = this._strIadeIlgili;
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
        public static int DoInsert(int SMREF, string strIadeIlgili)
        {
            int donendeger = 0;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO tblINTERNET_CariHesapEk (SMREF,strIadeIlgili) VALUES (@SMREF,@strIadeIlgili) SELECT @pkID = SCOPE_IDENTITY()", conn);
                cmd.Parameters.Add("@SMREF", SqlDbType.Int).Value = SMREF;
                cmd.Parameters.Add("@strIadeIlgili", SqlDbType.NVarChar).Value = strIadeIlgili;
                cmd.Parameters.Add("@pkID", SqlDbType.Int).Direction = ParameterDirection.Output;
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    donendeger = Convert.ToInt32(cmd.Parameters["@pkID"].Value);
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
        public void DoUpdate()
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UPDATE tblINTERNET_CariHesapEk SET SMREF = @SMREF, strIadeIlgili = @strIadeIlgili WHERE pkID = @pkID", conn);
                cmd.Parameters.Add("@pkID", SqlDbType.Int).Value = this._pkID;
                cmd.Parameters.Add("@SMREF", SqlDbType.Int).Value = this._SMREF;
                cmd.Parameters.Add("@strIadeIlgili", SqlDbType.NVarChar).Value = this._strIadeIlgili;
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
        public static void DoUpdateIadeIlgili(string Ilgili, int SMREF)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UPDATE tblINTERNET_CariHesapEk SET strIadeIlgili = @strIadeIlgili WHERE SMREF = @SMREF", conn);
                cmd.Parameters.Add("@SMREF", SqlDbType.Int).Value = SMREF;
                cmd.Parameters.Add("@strIadeIlgili", SqlDbType.NVarChar).Value = Ilgili;
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
                SqlCommand cmd = new SqlCommand("DELETE FROM tblINTERNET_CariHesapEk WHERE pkID = @pkID", conn);
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
        public static void DoDelete(int SMREF)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM tblINTERNET_CariHesapEk WHERE SMREF = @SMREF", conn);
                cmd.Parameters.Add("@SMREF", SqlDbType.Int).Value = SMREF;
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
        public static void GetObject(DataTable dt)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT pkID,SMREF,strIadeIlgili FROM tblINTERNET_CariHesapEk", conn);
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
        public static string GetIadeIlgiliBySMREF(int SMREF)
        {
            string donendeger = string.Empty;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT strIadeIlgili FROM tblINTERNET_CariHesapEk WHERE SMREF = @SMREF", conn);
                cmd.Parameters.Add("@SMREF", SqlDbType.Int).Value = SMREF;
                try
                {
                    conn.Open();
                    object obj = cmd.ExecuteScalar();
                    if (obj != null) donendeger = obj.ToString();
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
        public static bool GetIadeIlgiliVarMiBySMREF(int SMREF)
        {
            bool donendeger = false;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT count(*) FROM tblINTERNET_CariHesapEk WHERE SMREF = @SMREF", conn);
                cmd.Parameters.Add("@SMREF", SqlDbType.Int).Value = SMREF;
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

    public class WebMusteriEk
    {
        public static bool IsExist(int SMREF, int SLSREF)
        {
            bool donendeger = false;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT count(*) FROM [Web-Musteri-Ek] WHERE SMREF = @SMREF AND SLSREF = @SLSREF", conn);
                cmd.Parameters.Add("@SMREF", SqlDbType.Int).Value = SMREF;
                cmd.Parameters.Add("@SLSREF", SqlDbType.Int).Value = SLSREF;

                try
                {
                    conn.Open();
                    object obj = cmd.ExecuteScalar();
                    if (obj != null)
                        donendeger = Convert.ToBoolean(obj);
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

        public static bool GetBakiye(int SMREF, int SLSREF)
        {
            bool donendeger = false;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT blBakiye FROM [Web-Musteri-Ek] WHERE SMREF = @SMREF AND SLSREF = @SLSREF", conn);
                cmd.Parameters.Add("@SMREF", SqlDbType.Int).Value = SMREF;
                cmd.Parameters.Add("@SLSREF", SqlDbType.Int).Value = SLSREF;

                try
                {
                    conn.Open();
                    object obj = cmd.ExecuteScalar();
                    if (obj != null)
                        donendeger = Convert.ToBoolean(obj);
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

        public static void SetBakiye(int SMREF, int SLSREF, bool Bakiye, int MusteriID, DateTime Zaman)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.Parameters.Add("@SMREF", SqlDbType.Int).Value = SMREF;
                cmd.Parameters.Add("@SLSREF", SqlDbType.Int).Value = SLSREF;
                cmd.Parameters.Add("@blBakiye", SqlDbType.Bit).Value = Bakiye;

                SqlCommand cmdLog = new SqlCommand();
                cmdLog.Connection = conn;
                cmdLog.Parameters.Add("@SMREF", SqlDbType.Int).Value = SMREF;
                cmdLog.Parameters.Add("@SLSREF", SqlDbType.Int).Value = SLSREF;
                cmdLog.Parameters.Add("@blBakiye", SqlDbType.Bit).Value = Bakiye;
                cmdLog.Parameters.Add("@intMusteriID", SqlDbType.Int).Value = MusteriID;
                cmdLog.Parameters.Add("@dtZaman", SqlDbType.DateTime).Value = Zaman;

                cmdLog.CommandText = "INSERT INTO [Web-Musteri-Ek-Log] (SMREF,SLSREF,blBakiye,intMusteriID,dtZaman) VALUES (@SMREF,@SLSREF,@blBakiye,@intMusteriID,@dtZaman)";

                if (IsExist(SMREF, SLSREF))
                    cmd.CommandText = "UPDATE [Web-Musteri-Ek] SET blBakiye = @blBakiye WHERE SMREF = @SMREF AND SLSREF = @SLSREF";
                else
                    cmd.CommandText = "INSERT INTO [Web-Musteri-Ek] (SMREF,SLSREF,blBakiye) VALUES (@SMREF,@SLSREF,@blBakiye)";

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    cmdLog.ExecuteNonQuery();
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
}

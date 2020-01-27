using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Sultanlar.DatabaseObject.Kenton
{
    public class TarifGoruntuleme
    {
        public static long DoInsert(int TarifID, int UyeID, string IP)
        {
            long donendeger = 0;
            if (IP.IndexOf("::1") > -1)
                return 0;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO [tblKENTON_TarifGoruntuleme] (intTarifID,intUyeID,dtTarih,strIP) VALUES (@intTarifID,@intUyeID,@dtTarih,@strIP) SELECT @pkID = SCOPE_IDENTITY()", conn);
                cmd.Parameters.Add("@intTarifID", SqlDbType.Int).Value = TarifID;
                cmd.Parameters.Add("@intUyeID", SqlDbType.Int).Value = UyeID;
                cmd.Parameters.Add("@dtTarih", SqlDbType.SmallDateTime).Value = DateTime.Now;
                cmd.Parameters.Add("@strIP", SqlDbType.VarChar, 15).Value = IP;
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
    }

    public class Yerler
    {
        public static long DoInsert(int UyeID, string Sayfa, string SayfaID, string Tarayici, string IP)
        {
            long donendeger = 0;
            if (IP.IndexOf("::1") > -1)
                return 0;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO [tblKENTON_Yerler] (intUyeID,dtZaman,strSayfa,strSayfaID,strTarayici,strIP) VALUES (@intUyeID,@dtZaman,@strSayfa,@strSayfaID,@strTarayici,@strIP) SELECT @pkID = SCOPE_IDENTITY()", conn);
                
                cmd.Parameters.Add("@intUyeID", SqlDbType.Int).Value = UyeID;
                cmd.Parameters.Add("@dtZaman", SqlDbType.DateTime).Value = DateTime.Now;
                cmd.Parameters.Add("@strSayfa", SqlDbType.NVarChar, 100).Value = Sayfa;
                cmd.Parameters.Add("@strSayfaID", SqlDbType.NVarChar, 100).Value = SayfaID;
                cmd.Parameters.Add("@strTarayici", SqlDbType.NVarChar, 100).Value = Tarayici;
                cmd.Parameters.Add("@strIP", SqlDbType.VarChar, 50).Value = IP;
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
    }
}

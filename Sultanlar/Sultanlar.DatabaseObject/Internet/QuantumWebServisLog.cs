using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Sultanlar.DatabaseObject.Internet
{
    public class QuantumWebServisLog
    {
        public static void DoInsert(bool Yazildi, int SiparisID, string QuantumNo, int MusteriID, string Terminal, string SiparisTip)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO tblQuantumWebServisLog ([blYazildi],[intSiparisID],[strQuantumNo],[dtTarih],[intMusteriID],[strTerminal],[strSiparisTip]) VALUES (@blYazildi,@intSiparisID,@strQuantumNo,@dtTarih,@intMusteriID,@strTerminal,@strSiparisTip)", conn);
                cmd.Parameters.Add("@blYazildi", System.Data.SqlDbType.Bit).Value = Yazildi;
                cmd.Parameters.Add("@intSiparisID", System.Data.SqlDbType.Int).Value = SiparisID;
                cmd.Parameters.Add("@strQuantumNo", System.Data.SqlDbType.NVarChar).Value = QuantumNo;
                cmd.Parameters.Add("@dtTarih", System.Data.SqlDbType.DateTime).Value = DateTime.Now;
                cmd.Parameters.Add("@intMusteriID", System.Data.SqlDbType.Int).Value = MusteriID;
                cmd.Parameters.Add("@strTerminal", System.Data.SqlDbType.NVarChar).Value = Terminal;
                cmd.Parameters.Add("@strSiparisTip", System.Data.SqlDbType.NVarChar).Value = SiparisTip;
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
        public static int GetCount(bool yazilan)
        {
            int donendeger = 0;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT count(*) FROM tblQuantumWebServisLog WHERE blYazildi = @blYazildi", conn);
                cmd.Parameters.Add("@blYazildi", System.Data.SqlDbType.Bit).Value = yazilan;
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
    }
}

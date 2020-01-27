using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Sultanlar.DatabaseObject.Internet
{
    public class MesajlarCevaplar
    {
        public int intMesajID { get; set; }
        public bool blAlinan { get; set; }
        public int intCevapMesajID { get; set; }
        public MesajlarCevaplar()
        {

        }
        public MesajlarCevaplar(int intMesajID, bool blAlinan, int intCevapMesajID)
        {
            this.intMesajID = intMesajID;
            this.blAlinan = blAlinan;
            this.intCevapMesajID = intCevapMesajID;
        }
        public void DoInsert()
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO [tblINTERNET_MesajlarCevaplar] ([intMesajID],[blAlinan],[intCevapMesajID]) VALUES (@intMesajID,@blAlinan,@intCevapMesajID)", conn);
                cmd.Parameters.Add("@intMesajID", SqlDbType.Int).Value = this.intMesajID;
                cmd.Parameters.Add("@blAlinan", SqlDbType.Bit).Value = this.blAlinan;
                cmd.Parameters.Add("@intCevapMesajID", SqlDbType.Int).Value = this.intCevapMesajID;
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
        public static MesajlarCevaplar GetObject(int intMesajID, bool blAlinan)
        {
            MesajlarCevaplar donendeger = new MesajlarCevaplar();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT [intMesajID],[blAlinan],[intCevapMesajID] FROM [dbo].[tblINTERNET_MesajlarCevaplar] WHERE [intMesajID] = @intMesajID AND [blAlinan] = @blAlinan", conn);
                cmd.Parameters.Add("@intMesajID", SqlDbType.Int).Value = intMesajID;
                cmd.Parameters.Add("@blAlinan", SqlDbType.Bit).Value = blAlinan;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        donendeger.intMesajID = Convert.ToInt32(dr[0]);
                        donendeger.blAlinan = Convert.ToBoolean(dr[1]);
                        donendeger.intCevapMesajID = Convert.ToInt32(dr[2]);
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
        public static MesajlarCevaplar GetObject(bool blAlinan, int intCevapMesajID)
        {
            MesajlarCevaplar donendeger = new MesajlarCevaplar();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT [intMesajID],[blAlinan],[intCevapMesajID] FROM [dbo].[tblINTERNET_MesajlarCevaplar] WHERE [blAlinan] = @blAlinan AND [intCevapMesajID] = @intCevapMesajID", conn);
                cmd.Parameters.Add("@blAlinan", SqlDbType.Bit).Value = blAlinan;
                cmd.Parameters.Add("@intCevapMesajID", SqlDbType.Int).Value = intCevapMesajID;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        donendeger.intMesajID = Convert.ToInt32(dr[0]);
                        donendeger.blAlinan = Convert.ToBoolean(dr[1]);
                        donendeger.intCevapMesajID = Convert.ToInt32(dr[2]);
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

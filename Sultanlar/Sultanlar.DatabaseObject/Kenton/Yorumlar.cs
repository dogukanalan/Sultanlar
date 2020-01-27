using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Sultanlar.DatabaseObject.Kenton
{
    public class Yorumlar : ISultanlar
    {
        public int pkID { get; set; }
        public int intTarifID { get; set; }
        public int intUyeID { get; set; }
        public string strYorum { get; set; }
        public DateTime dtTarih { get; set; }
        public bool blOnayli { get; set; }

        private Yorumlar(int pkID, int intTarifID, int intUyeID, string strYorum, DateTime dtTarih, bool blOnayli)
        {
            this.pkID = pkID;
            this.intTarifID = intTarifID;
            this.intUyeID = intUyeID;
            this.strYorum = strYorum;
            this.dtTarih = dtTarih;
            this.blOnayli = blOnayli;
        }

        public Yorumlar(int intTarifID, int intUyeID, string strYorum, DateTime dtTarih, bool blOnayli)
        {
            this.intTarifID = intTarifID;
            this.intUyeID = intUyeID;
            this.strYorum = strYorum;
            this.dtTarih = dtTarih;
            this.blOnayli = blOnayli;
        }

        public Yorumlar()
        {

        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public override string ToString()
        {
            return this.pkID.ToString();
        }

        public void DoInsert()
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO [tblKENTON_Yorumlar] ([intTarifID],[intUyeID],[strYorum],[dtTarih],blOnayli) VALUES (@intTarifID,@intUyeID,@strYorum,@dtTarih,@blOnayli) SELECT @pkID = SCOPE_IDENTITY()", conn);
                cmd.Parameters.Add("@intTarifID", SqlDbType.Int).Value = this.intTarifID;
                cmd.Parameters.Add("@intUyeID", SqlDbType.Int).Value = this.intUyeID;
                cmd.Parameters.Add("@strYorum", SqlDbType.NVarChar).Value = this.strYorum;
                cmd.Parameters.Add("@dtTarih", SqlDbType.DateTime).Value = this.dtTarih;
                cmd.Parameters.Add("@blOnayli", SqlDbType.Bit).Value = this.blOnayli;
                cmd.Parameters.Add("@pkID", SqlDbType.Int).Direction = ParameterDirection.Output;
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    this.pkID = Convert.ToInt32(cmd.Parameters["@pkID"].Value);
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

        public void DoUpdate()
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UPDATE [tblKENTON_Yorumlar] SET [intTarifID] = @intTarifID,[intUyeID] = @intUyeID,[strYorum] = @strYorum,[dtTarih] = @dtTarih,blOnayli = @blOnayli WHERE pkID = @pkID", conn);
                cmd.Parameters.Add("@intTarifID", SqlDbType.Int).Value = this.intTarifID;
                cmd.Parameters.Add("@intUyeID", SqlDbType.Int).Value = this.intUyeID;
                cmd.Parameters.Add("@strYorum", SqlDbType.NVarChar).Value = this.strYorum;
                cmd.Parameters.Add("@dtTarih", SqlDbType.DateTime).Value = this.dtTarih;
                cmd.Parameters.Add("@blOnayli", SqlDbType.Bit).Value = this.blOnayli;
                cmd.Parameters.Add("@pkID", SqlDbType.Int).Value = this.pkID;
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

        public void DoDelete()
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("DELETE [tblKENTON_Yorumlar] WHERE pkID = @pkID", conn);
                cmd.Parameters.Add("@pkID", SqlDbType.Int).Value = this.pkID;
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

        public static void GetObjectsByTarifID(DataTable dt, int TarifID, int Kactane)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT TOP " + Kactane.ToString() + " tblKENTON_Yorumlar.[pkID],[intTarifID],strBaslik,[tblKENTON_Yorumlar].[intUyeID],strAd + ' ' + strSoyad AS strAdSoyad,[strYorum],tblKENTON_Yorumlar.[dtTarih],blOnayli FROM [tblKENTON_Yorumlar] INNER JOIN tblKENTON_Uyeler ON tblKENTON_Yorumlar.intUyeID = tblKENTON_Uyeler.pkID INNER JOIN tblKENTON_Tarifler ON tblKENTON_Yorumlar.intTarifID = tblKENTON_Tarifler.pkID WHERE blOnayli = 'True' AND intTarifID = @intTarifID ORDER BY pkID DESC", conn);
                da.SelectCommand.Parameters.Add("@intTarifID", SqlDbType.Int).Value = TarifID;
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

        public static Yorumlar GetObject(int ID)
        {
            Yorumlar donendeger = new Yorumlar();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT [pkID],[intTarifID],[intUyeID],[strYorum],[dtTarih],blOnayli FROM [tblKENTON_Yorumlar] WHERE pkID = @pkID", conn);
                cmd.Parameters.Add("@pkID", SqlDbType.Int).Value = ID;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        donendeger = new Yorumlar(Convert.ToInt32(dr[0]), Convert.ToInt32(dr[1]), Convert.ToInt32(dr[2]), dr[3].ToString(), Convert.ToDateTime(dr[4]), Convert.ToBoolean(dr[5]));
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

        public static List<Yorumlar> GetObjectsByTarifID(int TarifID, int Kactane)
        {
            List<Yorumlar> donendeger = new List<Yorumlar>();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT TOP " + Kactane.ToString() + " tblKENTON_Yorumlar.[pkID],[intTarifID],strBaslik,[tblKENTON_Yorumlar].[intUyeID],strAd + ' ' + strSoyad AS strAdSoyad,[strYorum],tblKENTON_Yorumlar.[dtTarih],blOnayli FROM [tblKENTON_Yorumlar] INNER JOIN tblKENTON_Uyeler ON tblKENTON_Yorumlar.intUyeID = tblKENTON_Uyeler.pkID INNER JOIN tblKENTON_Tarifler ON tblKENTON_Yorumlar.intTarifID = tblKENTON_Tarifler.pkID WHERE blOnayli = 'True' AND intTarifID = @intTarifID ORDER BY pkID DESC", conn);
                cmd.Parameters.Add("@intTarifID", SqlDbType.Int).Value = TarifID;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        donendeger.Add(new Yorumlar(Convert.ToInt32(dr[0]), Convert.ToInt32(dr[1]), Convert.ToInt32(dr[2]), dr[3].ToString(), Convert.ToDateTime(dr[4]), Convert.ToBoolean(dr[5])));
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

        public static void GetObjectsByUyeID(DataTable dt, int UyeID, int pkID, int Kactane)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT TOP " + Kactane.ToString() + " tblKENTON_Yorumlar.[pkID],[intTarifID],strBaslik,[tblKENTON_Yorumlar].[intUyeID],strAd + ' ' + strSoyad AS strAdSoyad,[strYorum],tblKENTON_Yorumlar.[dtTarih],blOnayli FROM [tblKENTON_Yorumlar] INNER JOIN tblKENTON_Uyeler ON tblKENTON_Yorumlar.intUyeID = tblKENTON_Uyeler.pkID INNER JOIN tblKENTON_Tarifler ON tblKENTON_Yorumlar.intTarifID = tblKENTON_Tarifler.pkID WHERE [tblKENTON_Yorumlar].intUyeID = @intUyeID AND tblKENTON_Yorumlar.pkID < @pkID ORDER BY tblKENTON_Yorumlar.pkID DESC", conn);
                da.SelectCommand.Parameters.Add("@intUyeID", SqlDbType.Int).Value = UyeID;
                da.SelectCommand.Parameters.Add("@pkID", SqlDbType.Int).Value = pkID;
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

        public static void GetObjects(DataTable dt, int pkID, int Kactane)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT TOP " + Kactane.ToString() + " tblKENTON_Yorumlar.[pkID],[intTarifID],strBaslik,[tblKENTON_Yorumlar].[intUyeID],strAd + ' ' + strSoyad AS strAdSoyad,[strYorum],tblKENTON_Yorumlar.[dtTarih],blOnayli FROM [tblKENTON_Yorumlar] INNER JOIN tblKENTON_Uyeler ON tblKENTON_Yorumlar.intUyeID = tblKENTON_Uyeler.pkID INNER JOIN tblKENTON_Tarifler ON tblKENTON_Yorumlar.intTarifID = tblKENTON_Tarifler.pkID WHERE tblKENTON_Yorumlar.pkID < @pkID ORDER BY tblKENTON_Yorumlar.pkID DESC", conn);
                da.SelectCommand.Parameters.Add("@pkID", SqlDbType.Int).Value = pkID;
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
    }
}

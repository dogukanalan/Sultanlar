using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Sultanlar.DatabaseObject.Kenton
{
    public class TarifFav
    {
        public int pkID { get; set; }
        public int intUyeID { get; set; }
        public int intTarifID { get; set; }
        public DateTime dtTarih { get; set; }

        private TarifFav(int pkID, int intUyeID, int intTarifID, DateTime dtTarih)
        {
            this.pkID = pkID;
            this.intUyeID = intUyeID;
            this.intTarifID = intTarifID;
            this.dtTarih = dtTarih;
        }

        public TarifFav(int intUyeID, int intTarifID, DateTime dtTarih)
        {
            this.intUyeID = intUyeID;
            this.intTarifID = intTarifID;
            this.dtTarih = dtTarih;
        }

        public TarifFav()
        {
            // TODO: Complete member initialization
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
                SqlCommand cmd = new SqlCommand("INSERT INTO [tblKENTON_TarifFav] ([intUyeID],[intTarifID],dtTarih) VALUES (@intUyeID,@intTarifID,@dtTarih) SELECT @pkID = SCOPE_IDENTITY()", conn);
                cmd.Parameters.Add("@intUyeID", SqlDbType.Int).Value = this.intUyeID;
                cmd.Parameters.Add("@intTarifID", SqlDbType.Int).Value = this.intTarifID;
                cmd.Parameters.Add("@dtTarih", SqlDbType.DateTime).Value = this.dtTarih;
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
                SqlCommand cmd = new SqlCommand("UPDATE [tblKENTON_TarifFav] SET [intUyeID] = @intUyeID,[intTarifID] = @intTarifID,dtTarih = @dtTarih WHERE pkID = @pkID", conn);
                cmd.Parameters.Add("@intUyeID", SqlDbType.Int).Value = this.intUyeID;
                cmd.Parameters.Add("@intTarifID", SqlDbType.Int).Value = this.intTarifID;
                cmd.Parameters.Add("@dtTarih", SqlDbType.DateTime).Value = this.dtTarih;
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
                SqlCommand cmd = new SqlCommand("DELETE [tblKENTON_TarifFav] WHERE pkID = @pkID", conn);
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

        public static void GetObjects(DataTable dt)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT [pkID],[intUyeID],[intTarifID],dtTarih FROM [tblKENTON_TarifFav] ORDER BY pkID DESC", conn);
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

        public static TarifFav GetObject(int ID)
        {
            TarifFav donendeger = new TarifFav();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT [pkID],[intUyeID],[intTarifID],dtTarih FROM [tblKENTON_TarifFav] WHERE pkID = @pkID", conn);
                cmd.Parameters.Add("@pkID", SqlDbType.Int).Value = ID;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        donendeger.pkID = ID;
                        donendeger.intUyeID = Convert.ToInt32(dr[1]);
                        donendeger.intTarifID = Convert.ToInt32(dr[2]);
                        donendeger.dtTarih = Convert.ToDateTime(dr[3]);
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

        public static TarifFav GetObjectByTarifIDUyeID(int UyeID, int TarifID)
        {
            TarifFav donendeger = new TarifFav();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT [pkID],[intUyeID],[intTarifID],dtTarih FROM [tblKENTON_TarifFav] WHERE intTarifID = @intTarifID AND intUyeID = @intUyeID", conn);
                cmd.Parameters.Add("@intTarifID", SqlDbType.Int).Value = TarifID;
                cmd.Parameters.Add("@intUyeID", SqlDbType.Int).Value = UyeID;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        donendeger.pkID = Convert.ToInt32(dr[0]);
                        donendeger.intUyeID = Convert.ToInt32(dr[1]);
                        donendeger.intTarifID = Convert.ToInt32(dr[2]);
                        donendeger.dtTarih = Convert.ToDateTime(dr[3]);
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

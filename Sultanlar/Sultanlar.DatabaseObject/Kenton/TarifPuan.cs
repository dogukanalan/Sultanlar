using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Sultanlar.DatabaseObject.Kenton
{
    public class TarifPuan
    {
        public int pkID { get; set; }
        public int intUyeID { get; set; }
        public int intTarifID { get; set; }
        public DateTime dtTarih { get; set; }
        public int intPuan { get; set; }

        private TarifPuan(int pkID, int intUyeID, int intTarifID, DateTime dtTarih, int intPuan)
        {
            this.pkID = pkID;
            this.intUyeID = intUyeID;
            this.intTarifID = intTarifID;
            this.dtTarih = dtTarih;
            this.intPuan = intPuan;
        }

        public TarifPuan(int intUyeID, int intTarifID, DateTime dtTarih, int intPuan)
        {
            this.intUyeID = intUyeID;
            this.intTarifID = intTarifID;
            this.dtTarih = dtTarih;
            this.intPuan = intPuan;
        }

        public TarifPuan()
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
                SqlCommand cmd = new SqlCommand("INSERT INTO [tblKENTON_TarifPuan] ([intUyeID],[intTarifID],dtTarih,intPuan) VALUES (@intUyeID,@intTarifID,@dtTarih,@intPuan) SELECT @pkID = SCOPE_IDENTITY()", conn);
                cmd.Parameters.Add("@intUyeID", SqlDbType.Int).Value = this.intUyeID;
                cmd.Parameters.Add("@intTarifID", SqlDbType.Int).Value = this.intTarifID;
                cmd.Parameters.Add("@dtTarih", SqlDbType.DateTime).Value = this.dtTarih;
                cmd.Parameters.Add("@intPuan", SqlDbType.Int).Value = this.intPuan;
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
                SqlCommand cmd = new SqlCommand("UPDATE [tblKENTON_TarifPuan] SET [intUyeID] = @intUyeID,[intTarifID] = @intTarifID,dtTarih = @dtTarih,intPuan = @intPuan WHERE pkID = @pkID", conn);
                cmd.Parameters.Add("@intUyeID", SqlDbType.Int).Value = this.intUyeID;
                cmd.Parameters.Add("@intTarifID", SqlDbType.Int).Value = this.intTarifID;
                cmd.Parameters.Add("@dtTarih", SqlDbType.DateTime).Value = this.dtTarih;
                cmd.Parameters.Add("@intPuan", SqlDbType.Int).Value = this.intPuan;
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
                SqlCommand cmd = new SqlCommand("DELETE [tblKENTON_TarifPuan] WHERE pkID = @pkID", conn);
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
                SqlDataAdapter da = new SqlDataAdapter("SELECT [pkID],[intUyeID],[intTarifID],dtTarih,intPuan FROM [tblKENTON_TarifPuan] ORDER BY pkID DESC", conn);
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

        public static TarifPuan GetObject(int ID)
        {
            TarifPuan donendeger = new TarifPuan();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT [pkID],[intUyeID],[intTarifID],dtTarih,intPuan FROM [tblKENTON_TarifPuan] WHERE pkID = @pkID", conn);
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
                        donendeger.intPuan = Convert.ToInt32(dr[4]);
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

        public static TarifPuan GetObjectByTarifIDUyeID(int UyeID, int TarifID)
        {
            TarifPuan donendeger = new TarifPuan();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT [pkID],[intUyeID],[intTarifID],dtTarih,intPuan FROM [tblKENTON_TarifPuan] WHERE intTarifID = @intTarifID AND intUyeID = @intUyeID", conn);
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
                        donendeger.intPuan = Convert.ToInt32(dr[4]);
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

        public static List<TarifPuan> GetObjectByTarifID(int TarifID)
        {
            List<TarifPuan> donendeger = new List<TarifPuan>();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT [pkID],[intUyeID],[intTarifID],dtTarih,intPuan FROM [tblKENTON_TarifPuan] WHERE intTarifID = @intTarifID", conn);
                cmd.Parameters.Add("@intTarifID", SqlDbType.Int).Value = TarifID;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        donendeger.Add(new TarifPuan(Convert.ToInt32(dr[0]), Convert.ToInt32(dr[1]),Convert.ToInt32(dr[2]), Convert.ToDateTime(dr[3]),Convert.ToInt32(dr[4])));
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

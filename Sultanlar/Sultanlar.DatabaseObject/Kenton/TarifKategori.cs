using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Sultanlar.DatabaseObject.Kenton
{
    public class TarifKategori
    {
        public int pkID { get; set; }
        public int intTarifID { get; set; }
        public int intKategoriID { get; set; }

        private TarifKategori(int pkID, int intTarifID, int intKategoriID)
        {
            this.pkID = pkID;
            this.intTarifID = intTarifID;
            this.intKategoriID = intKategoriID;
        }

        public TarifKategori(int intTarifID, int intKategoriID)
        {
            this.intTarifID = intTarifID;
            this.intKategoriID = intKategoriID;
        }

        public TarifKategori()
        {

        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public override string ToString()
        {
            return KategorilerTarif.GetObject(this.intKategoriID).strKategori;
        }

        public void DoInsert()
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO [tblKENTON_TarifKategori] ([intTarifID],intKategoriID) VALUES (@intTarifID,@intKategoriID) SELECT @pkID = SCOPE_IDENTITY()", conn);
                cmd.Parameters.Add("@intTarifID", SqlDbType.Int).Value = this.intTarifID;
                cmd.Parameters.Add("@intKategoriID", SqlDbType.Int).Value = this.intKategoriID;
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
                SqlCommand cmd = new SqlCommand("UPDATE [tblKENTON_TarifKategori] SET [intTarifID]=@intTarifID,intKategoriID=@intKategoriID WHERE pkID = @pkID", conn);
                cmd.Parameters.Add("@intTarifID", SqlDbType.Int).Value = this.intTarifID;
                cmd.Parameters.Add("@intKategoriID", SqlDbType.Int).Value = this.intKategoriID;
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
                SqlCommand cmd = new SqlCommand("DELETE FROM [tblKENTON_TarifKategori] WHERE pkID = @pkID", conn);
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

        public static void GetObjects(IList List)
        {
            List.Clear();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT [pkID],[intTarifID],intKategoriID FROM [tblKENTON_TarifKategori] ORDER BY [pkID] DESC", conn);
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                        List.Add(new TarifKategori(Convert.ToInt32(dr[0]), Convert.ToInt32(dr[1]), Convert.ToInt32(dr[2])));
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

        public static TarifKategori GetObject(int intTarifID, int intKategoriID)
        {
            TarifKategori donendeger = new TarifKategori();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT [pkID],[intTarifID],intKategoriID FROM [tblKENTON_TarifKategori] WHERE intTarifID = @intTarifID AND intKategoriID = @intKategoriID", conn);
                cmd.Parameters.Add("@intTarifID", SqlDbType.Int).Value = intTarifID;
                cmd.Parameters.Add("@intKategoriID", SqlDbType.Int).Value = intKategoriID;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        donendeger.pkID = Convert.ToInt32(dr[0]);
                        donendeger.intTarifID = Convert.ToInt32(dr[1]);
                        donendeger.intKategoriID = Convert.ToInt32(dr[2]);
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

        public static List<TarifKategori> GetObjectsByTarifID(int TarifID)
        {
            List<TarifKategori> donendeger = new List<TarifKategori>();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT [pkID],[intTarifID],intKategoriID FROM [tblKENTON_TarifKategori] WHERE intTarifID = @intTarifID", conn);
                cmd.Parameters.Add("@intTarifID", SqlDbType.Int).Value = TarifID;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        TarifKategori tk = new TarifKategori();
                        tk.pkID = Convert.ToInt32(dr[0]);
                        tk.intTarifID = Convert.ToInt32(dr[1]);
                        tk.intKategoriID = Convert.ToInt32(dr[2]);
                        donendeger.Add(tk);
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

        public static bool VarMi(int intTarifID, int intKategoriID)
        {
            bool donendeger = false;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT count(*) FROM [tblKENTON_TarifKategori] WHERE intTarifID = @intTarifID AND intKategoriID = @intKategoriID", conn);
                cmd.Parameters.Add("@intTarifID", SqlDbType.Int).Value = intTarifID;
                cmd.Parameters.Add("@intKategoriID", SqlDbType.Int).Value = intKategoriID;
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
}

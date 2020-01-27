using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Sultanlar.DatabaseObject.Kenton
{
    public class UrunKategori
    {
        public int pkID { get; set; }
        public int intUrunID { get; set; }
        public int intKategoriID { get; set; }

        private UrunKategori(int pkID, int intUrunID, int intKategoriID)
        {
            this.pkID = pkID;
            this.intUrunID = intUrunID;
            this.intKategoriID = intKategoriID;
        }

        public UrunKategori(int intUrunID, int intKategoriID)
        {
            this.intUrunID = intUrunID;
            this.intKategoriID = intKategoriID;
        }

        public UrunKategori()
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
                SqlCommand cmd = new SqlCommand("INSERT INTO [tblKENTON_UrunKategori] ([intUrunID],intKategoriID) VALUES (@intUrunID,@intKategoriID) SELECT @pkID = SCOPE_IDENTITY()", conn);
                cmd.Parameters.Add("@intUrunID", SqlDbType.Int).Value = this.intUrunID;
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
                SqlCommand cmd = new SqlCommand("UPDATE [tblKENTON_UrunKategori] SET [intUrunID]=@intUrunID,intKategoriID=@intKategoriID WHERE pkID = @pkID", conn);
                cmd.Parameters.Add("@intUrunID", SqlDbType.Int).Value = this.intUrunID;
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
                SqlCommand cmd = new SqlCommand("DELETE FROM [tblKENTON_UrunKategori] WHERE pkID = @pkID", conn);
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
                SqlCommand cmd = new SqlCommand("SELECT [pkID],[intUrunID],intKategoriID FROM [tblKENTON_UrunKategori] ORDER BY [pkID] DESC", conn);
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                        List.Add(new UrunKategori(Convert.ToInt32(dr[0]), Convert.ToInt32(dr[1]), Convert.ToInt32(dr[2])));
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

        public static UrunKategori GetObject(int intUrunID, int intKategoriID)
        {
            UrunKategori donendeger = new UrunKategori();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT [pkID],[intUrunID],intKategoriID FROM [tblKENTON_UrunKategori] WHERE intUrunID = @intUrunID AND intKategoriID = @intKategoriID", conn);
                cmd.Parameters.Add("@intUrunID", SqlDbType.Int).Value = intUrunID;
                cmd.Parameters.Add("@intKategoriID", SqlDbType.Int).Value = intKategoriID;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        donendeger.pkID = Convert.ToInt32(dr[0]);
                        donendeger.intUrunID = Convert.ToInt32(dr[1]);
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

        public static List<UrunKategori> GetObjectsByUrunID(int intUrunID)
        {
            List<UrunKategori> donendeger = new List<UrunKategori>();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT [pkID],[intUrunID],intKategoriID FROM [tblKENTON_UrunKategori] WHERE intUrunID = @intUrunID", conn);
                cmd.Parameters.Add("@intUrunID", SqlDbType.Int).Value = intUrunID;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        UrunKategori tk = new UrunKategori();
                        tk.pkID = Convert.ToInt32(dr[0]);
                        tk.intUrunID = Convert.ToInt32(dr[1]);
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

        public static bool VarMi(int intUrunID, int intKategoriID)
        {
            bool donendeger = false;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT count(*) FROM [tblKENTON_UrunKategori] WHERE intUrunID = @intUrunID AND intKategoriID = @intKategoriID", conn);
                cmd.Parameters.Add("@intUrunID", SqlDbType.Int).Value = intUrunID;
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

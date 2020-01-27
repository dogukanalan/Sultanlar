using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Collections;

namespace Sultanlar.DatabaseObject.Internet
{
    public class Resimler2 : ISultanlar, IDisposable
    {
        //
        //
        //
        // Alanlar ve Özellikler:
        //
        public int pkID { get; set; }
        public string strAciklama { get; set; }
        public byte[] binResim { get; set; }
        //
        //
        //
        // Constracter lar:
        //
        private Resimler2()
        {

        }
        //
        //
        private Resimler2(int pkID, string strAciklama, byte[] binResim)
        {
            this.pkID = pkID;
            this.strAciklama = strAciklama;
            this.binResim = binResim;
        }
        //
        //
        private Resimler2(int pkID, string strAciklama)
        {
            this.pkID = pkID;
            this.strAciklama = strAciklama;
            this.binResim = null;
        }
        //
        //
        public Resimler2(string strAciklama, byte[] binResim)
        {
            this.strAciklama = strAciklama;
            this.binResim = binResim;
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
        // ToString:
        //
        public override string ToString()
        {
            return this.strAciklama.ToString();
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
                SqlCommand cmd = new SqlCommand("INSERT INTO [tblINTERNET_Resimler2] ([strAciklama],[binResim]) VALUES (@strAciklama,@binResim) SELECT @pkID = SCOPE_IDENTITY()", conn);
                cmd.Parameters.Add("@strAciklama", SqlDbType.NVarChar, 100).Value = this.strAciklama;
                cmd.Parameters.Add("@binResim", SqlDbType.VarBinary).Value = this.binResim;
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
        //
        //
        public void DoUpdate()
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UPDATE [tblINTERNET_Resimler2] SET [strAciklama] = @strAciklama,[binResim] = @binResim WHERE pkID = @pkID", conn);
                cmd.Parameters.Add("@pkID", SqlDbType.Int).Value = this.pkID;
                cmd.Parameters.Add("@strAciklama", SqlDbType.NVarChar, 100).Value = this.strAciklama;
                cmd.Parameters.Add("@binResim", SqlDbType.VarBinary).Value = this.binResim;
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
                SqlCommand cmd = new SqlCommand("DELETE FROM [tblINTERNET_Resimler2] WHERE pkID = @pkID", conn);
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
        //
        //
        public static void GetObjects(IList List, string Baslik)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                List.Clear();

                string aranan = Baslik != string.Empty ? "WHERE strAciklama LIKE '%" + Baslik + "%' " : string.Empty;
                SqlCommand cmd = new SqlCommand("SELECT [pkID],[strAciklama] FROM [tblINTERNET_Resimler2] " + aranan + "ORDER BY [strAciklama]", conn);
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                        List.Add(new Resimler2(Convert.ToInt32(dr[0]), dr[1].ToString()));
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
        public static void GetObjects(ArrayList List, string Baslik)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                List.Clear();

                string aranan = Baslik != string.Empty ? "WHERE strAciklama LIKE '%" + Baslik + "%' " : string.Empty;
                SqlCommand cmd = new SqlCommand("SELECT [pkID],[strAciklama] FROM [tblINTERNET_Resimler2] " + aranan + "ORDER BY [strAciklama]", conn);
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                        List.Add(new Resimler2(Convert.ToInt32(dr[0]), dr[1].ToString()));
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
        public static Resimler2 GetObject(int ID)
        {
            Resimler2 donendeger = new Resimler2();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT [pkID],[strAciklama],[binResim] FROM [tblINTERNET_Resimler2]  WHERE pkID = @pkID", conn);
                cmd.Parameters.Add("@pkID", SqlDbType.Int).Value = ID;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                        donendeger = new Resimler2(Convert.ToInt32(dr[0]), dr[1].ToString(), (byte[])dr[2]);
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

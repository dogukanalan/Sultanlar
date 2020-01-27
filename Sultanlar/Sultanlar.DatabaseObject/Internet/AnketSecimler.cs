using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Sultanlar.DatabaseObject.Internet
{
    public class AnketSecimler : ISultanlar
    {
        public int pkID { get; set; }
        public int intAnketID { get; set; }
        public string strSecim { get; set; }

        //public Anketler Anket { get { return Anketler.GetObject(this.intAnketID); } }

        public AnketSecimler(int intAnketID, string strSecim)
        {
            this.intAnketID = intAnketID;
            this.strSecim = strSecim;
        }

        private AnketSecimler(int pkID, int intAnketID, string strSecim)
        {
            this.pkID = pkID;
            this.intAnketID = intAnketID;
            this.strSecim = strSecim;
        }

        public AnketSecimler()
        {

        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public override string ToString()
        {
            return this.strSecim;
        }

        public void DoInsert()
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO [tblINTERNET_AnketSecimler] ([intAnketID],[strSecim]) VALUES (@intAnketID,@strSecim) SELECT @pkID = SCOPE_IDENTITY()", conn);
                cmd.Parameters.Add("@intAnketID", SqlDbType.Int).Value = this.intAnketID;
                cmd.Parameters.Add("@strSecim", SqlDbType.NVarChar, 255).Value = this.strSecim;
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
                SqlCommand cmd = new SqlCommand("UPDATE [tblINTERNET_AnketSecimler] VALUES [intAnketID]=@intAnketID,[strSecim]=@strSecim WHERE pkID = @pkID", conn);
                cmd.Parameters.Add("@intAnketID", SqlDbType.Int).Value = this.intAnketID;
                cmd.Parameters.Add("@strSecim", SqlDbType.NVarChar, 255).Value = this.strSecim;
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
                SqlCommand cmd = new SqlCommand("DELETE FROM [tblINTERNET_AnketSecimler] WHERE pkID = @pkID", conn);
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

        public static List<AnketSecimler> GetObjects(int AnketID)
        {
            List<AnketSecimler> donendeger = new List<AnketSecimler>();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT pkID,[intAnketID],[strSecim] FROM [tblINTERNET_AnketSecimler] WHERE intAnketID = @intAnketID ORDER BY pkID", conn);
                cmd.Parameters.Add("@intAnketID", SqlDbType.Int).Value = AnketID;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        donendeger.Add(new AnketSecimler(Convert.ToInt32(dr[0]), Convert.ToInt32(dr[1]), dr[2].ToString()));
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

        public static AnketSecimler GetObject(int ID)
        {
            AnketSecimler donendeger = new AnketSecimler();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT pkID,[intAnketID],[strSecim] FROM [tblINTERNET_AnketSecimler] WHERE pkID = @pkID", conn);
                cmd.Parameters.Add("@pkID", SqlDbType.Int).Value = ID;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        donendeger = new AnketSecimler(Convert.ToInt32(dr[0]), Convert.ToInt32(dr[1]), dr[2].ToString());
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

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Sultanlar.DatabaseObject.Internet
{
    public class Anketler : ISultanlar
    {
        public int pkID { get; set; }
        public string strSoru { get; set; }
        public DateTime dtZaman { get; set; }
        public string strHazirlayan { get; set; }
        public bool blPasif { get; set; }
        public List<AnketSecimler> Secimler
        {
            get
            {
                return AnketSecimler.GetObjects(this.pkID);
            }
        }
        public List<AnketCevaplar> Cevaplar
        {
            get
            {
                return AnketCevaplar.GetObjects(this.pkID);
            }
        }

        public Anketler(string strSoru, DateTime dtZaman, string strHazirlayan, bool blPasif)
        {
            this.strSoru = strSoru;
            this.dtZaman = dtZaman;
            this.strHazirlayan = strHazirlayan;
            this.blPasif = blPasif;
        }

        private Anketler(int pkID, string strSoru, DateTime dtZaman, string strHazirlayan, bool blPasif)
        {
            this.pkID = pkID;
            this.strSoru = strSoru;
            this.dtZaman = dtZaman;
            this.strHazirlayan = strHazirlayan;
            this.blPasif = blPasif;
        }

        public Anketler()
        {

        }
        
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        
        public override string ToString()
        {
            return this.strSoru;
        }

        public void DoInsert()
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO [tblINTERNET_Anketler] ([strSoru],[dtZaman],[strHazirlayan],[blPasif]) VALUES (@strSoru,@dtZaman,@strHazirlayan,@blPasif) SELECT @pkID = SCOPE_IDENTITY()", conn);
                cmd.Parameters.Add("@strSoru", SqlDbType.NVarChar, 255).Value = this.strSoru;
                cmd.Parameters.Add("@dtZaman", SqlDbType.DateTime).Value = this.dtZaman;
                cmd.Parameters.Add("@strHazirlayan", SqlDbType.NVarChar, 100).Value = this.strHazirlayan;
                cmd.Parameters.Add("@blPasif", SqlDbType.Bit).Value = this.blPasif;
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
                SqlCommand cmd = new SqlCommand("UPDATE [tblINTERNET_Anketler] VALUES [strSoru]=@strSoru,[dtZaman]=@dtZaman,[strHazirlayan]=@strHazirlayan,[blPasif]=@blPasif WHERE pkID = @pkID", conn);
                cmd.Parameters.Add("@strSoru", SqlDbType.NVarChar, 255).Value = this.strSoru;
                cmd.Parameters.Add("@dtZaman", SqlDbType.DateTime).Value = this.dtZaman;
                cmd.Parameters.Add("@strHazirlayan", SqlDbType.NVarChar, 100).Value = this.strHazirlayan;
                cmd.Parameters.Add("@blPasif", SqlDbType.Bit).Value = this.blPasif;
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
                SqlCommand cmd = new SqlCommand("DELETE FROM [tblINTERNET_Anketler] WHERE pkID = @pkID", conn);
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

        public static List<Anketler> GetObjects()
        {
            List<Anketler> donendeger = new List<Anketler>();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT pkID,[strSoru],[dtZaman],[strHazirlayan],[blPasif] FROM [tblINTERNET_Anketler] ORDER BY dtZaman DESC", conn);
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        donendeger.Add(new Anketler(Convert.ToInt32(dr[0]), dr[1].ToString(), Convert.ToDateTime(dr[2]), dr[3].ToString(), Convert.ToBoolean(dr[4])));
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

        public static Anketler GetObject(int ID)
        {
            Anketler donendeger = new Anketler();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT pkID,[strSoru],[dtZaman],[strHazirlayan],[blPasif] FROM [tblINTERNET_Anketler] WHERE pkID = @pkID", conn);
                cmd.Parameters.Add("@pkID", SqlDbType.Int).Value = ID;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        donendeger = new Anketler(Convert.ToInt32(dr[0]), dr[1].ToString(), Convert.ToDateTime(dr[2]), dr[3].ToString(), Convert.ToBoolean(dr[4]));
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

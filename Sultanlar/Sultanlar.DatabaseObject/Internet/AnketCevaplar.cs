using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Sultanlar.DatabaseObject.Internet
{
    public class AnketCevaplar : ISultanlar
    {
        public int pkID { get; set; }
        public int intAnketID { get; set; }
        public int intSecimID { get; set; }
        public int intMusteriID { get; set; }
        public DateTime dtZaman { get; set; }

        //public Anketler Anket {  get { return Anketler.GetObject(this.intAnketID); } }
        public AnketSecimler Secim { get { return AnketSecimler.GetObject(this.intSecimID); } }
        public Musteriler Musteri { get { return Musteriler.GetMusteriByID(this.intMusteriID); } }

        public AnketCevaplar(int intAnketID, int intSecimID, int intMusteriID, DateTime dtZaman)
        {
            this.intAnketID = intAnketID;
            this.intSecimID = intSecimID;
            this.intMusteriID = intMusteriID;
            this.dtZaman = dtZaman;
        }

        private AnketCevaplar(int pkID, int intAnketID, int intSecimID, int intMusteriID, DateTime dtZaman)
        {
            this.pkID = pkID;
            this.intAnketID = intAnketID;
            this.intSecimID = intSecimID;
            this.intMusteriID = intMusteriID;
            this.dtZaman = dtZaman;
        }

        public AnketCevaplar()
        {

        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public override string ToString()
        {
            return Secim.strSecim + " (" +  Musteri.strAd + " " + Musteri.strSoyad + ")";
        }

        public void DoInsert()
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO [tblINTERNET_AnketCevaplar] ([intAnketID],[intSecimID],[intMusteriID],[dtZaman]) VALUES (@intAnketID,@intSecimID,@intMusteriID,@dtZaman) SELECT @pkID = SCOPE_IDENTITY()", conn);
                cmd.Parameters.Add("@intAnketID", SqlDbType.Int).Value = this.intAnketID;
                cmd.Parameters.Add("@intSecimID", SqlDbType.Int).Value = this.intSecimID;
                cmd.Parameters.Add("@intMusteriID", SqlDbType.Int).Value = this.intMusteriID;
                cmd.Parameters.Add("@dtZaman", SqlDbType.DateTime).Value = this.dtZaman;
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
                SqlCommand cmd = new SqlCommand("UPDATE [tblINTERNET_AnketCevaplar] VALUES [intAnketID]=@intAnketID,[intSecimID]=@intSecimID,[intMusteriID]=@intMusteriID,[dtZaman]=@dtZaman WHERE pkID = @pkID", conn);
                cmd.Parameters.Add("@intAnketID", SqlDbType.Int).Value = this.intAnketID;
                cmd.Parameters.Add("@intSecimID", SqlDbType.Int).Value = this.intSecimID;
                cmd.Parameters.Add("@intMusteriID", SqlDbType.Int).Value = this.intMusteriID;
                cmd.Parameters.Add("@dtZaman", SqlDbType.DateTime).Value = this.dtZaman;
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
                SqlCommand cmd = new SqlCommand("DELETE FROM [tblINTERNET_AnketCevaplar] WHERE pkID = @pkID", conn);
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

        public static List<AnketCevaplar> GetObjects(int AnketID)
        {
            List<AnketCevaplar> donendeger = new List<AnketCevaplar>();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT pkID,[intAnketID],[intSecimID],[intMusteriID],[dtZaman] FROM [tblINTERNET_AnketCevaplar] WHERE intAnketID = @intAnketID ORDER BY pkID", conn);
                cmd.Parameters.Add("@intAnketID", SqlDbType.Int).Value = AnketID;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        donendeger.Add(new AnketCevaplar(Convert.ToInt32(dr[0]), Convert.ToInt32(dr[1]), Convert.ToInt32(dr[2]), Convert.ToInt32(dr[3]), Convert.ToDateTime(dr[4])));
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

        public static AnketCevaplar GetObject(int ID)
        {
            AnketCevaplar donendeger = new AnketCevaplar();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT pkID,[intAnketID],[intSecimID],[intMusteriID],[dtZaman] FROM [tblINTERNET_AnketCevaplar] WHERE pkID = @pkID", conn);
                cmd.Parameters.Add("@pkID", SqlDbType.Int).Value = ID;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        donendeger = new AnketCevaplar(Convert.ToInt32(dr[0]), Convert.ToInt32(dr[1]), Convert.ToInt32(dr[2]), Convert.ToInt32(dr[3]), Convert.ToDateTime(dr[4]));
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

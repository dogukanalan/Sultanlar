using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Collections;
using Sultanlar.DatabaseObject.Internet;

namespace Sultanlar.DatabaseObject.Kenton
{
    public class TarifUrun
    {
        public int pkID { get; set; }
        public int intTarifID { get; set; }
        public Tarifler Tarif { get { return Tarifler.GetObject(this.intTarifID); } }
        public int intUrunID { get; set; }
        public string Urun { get { return Urunler.GetProductName(this.intUrunID); } }

        private TarifUrun(int pkID, int intTarifID, int intUrunID)
        {
            this.pkID = pkID;
            this.intTarifID = intTarifID;
            this.intUrunID = intUrunID;
        }

        public TarifUrun(int intTarifID, int intUrunID)
        {
            this.intTarifID = intTarifID;
            this.intUrunID = intUrunID;
        }

        public TarifUrun()
        {
            // TODO: Complete member initialization
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public override string ToString()
        {
            return this.Urun;
        }

        public void DoInsert()
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO [tblKENTON_TarifUrun] ([intTarifID],[intUrunID]) VALUES (@intTarifID,@intUrunID) SELECT @pkID = SCOPE_IDENTITY()", conn);
                cmd.Parameters.Add("@intTarifID", SqlDbType.Int).Value = this.intTarifID;
                cmd.Parameters.Add("@intUrunID", SqlDbType.Int).Value = this.intUrunID;
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
                SqlCommand cmd = new SqlCommand("UPDATE [tblKENTON_TarifUrun] SET [intTarifID] = @intTarifID,intUrunID = @intUrunID WHERE pkID = @pkID", conn);
                cmd.Parameters.Add("@intTarifID", SqlDbType.Int).Value = this.intTarifID;
                cmd.Parameters.Add("@intUrunID", SqlDbType.Int).Value = this.intUrunID;
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
                SqlCommand cmd = new SqlCommand("DELETE [tblKENTON_TarifUrun] WHERE pkID = @pkID", conn);
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
                SqlDataAdapter da = new SqlDataAdapter("SELECT [pkID],[intTarifID],intUrunID FROM [tblKENTON_TarifUrun] ORDER BY pkID DESC", conn);
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

        public static TarifUrun GetObject(int ID)
        {
            TarifUrun donendeger = new TarifUrun();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT [pkID],[intTarifID],intUrunID FROM [tblKENTON_TarifUrun] WHERE pkID = @pkID", conn);
                cmd.Parameters.Add("@pkID", SqlDbType.Int).Value = ID;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        donendeger.pkID = ID;
                        donendeger.intTarifID = Convert.ToInt32(dr[1]);
                        donendeger.intUrunID = Convert.ToInt32(dr[2]);
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

        public static void GetObjects(IList List, int TarifID)
        {
            List.Clear();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT [pkID],[intTarifID],intUrunID FROM [tblKENTON_TarifUrun] WHERE intTarifID = @intTarifID", conn);
                cmd.Parameters.Add("@intTarifID", SqlDbType.Int).Value = TarifID;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        List.Add(new TarifUrun(Convert.ToInt32(dr[0]), Convert.ToInt32(dr[1]), Convert.ToInt32(dr[2])));
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
        }
    }
}

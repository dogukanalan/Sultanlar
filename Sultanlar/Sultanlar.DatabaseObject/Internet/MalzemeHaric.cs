using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Sultanlar.DatabaseObject.Internet
{
    public class MalzemeHaric
    {
        public int ID { get; set; }
        public int SIRA { get; set; }
        public int ITEMREF { get; set; }
        public int AP { get; set; }
        public int ADET { get; set; }
        public string BASLIK { get; set; }
        public string ACIKLAMA { get; set; }
        public byte[] RESIM { get; set; }
        public double ISK { get; set; }

        public MalzemeHaric()
        { }

        public MalzemeHaric(int ID, int SIRA, int ITEMREF, int AP, int ADET, string BASLIK, string ACIKLAMA, byte[] RESIM, double ISK)
        {
            this.ID = ID;
            this.SIRA = SIRA;
            this.ITEMREF = ITEMREF;
            this.AP = AP;
            this.ADET = ADET;
            this.BASLIK = BASLIK;
            this.ACIKLAMA = ACIKLAMA;
            this.RESIM = RESIM;
            this.ISK = ISK;
        }

        public override string ToString()
        {
            return (SIRA == 1 && AP == 1 ? "[P] " : "") + BASLIK;
        }

        public void DoInsert()
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO [Web-Malzeme-Haric] ([ID],[SIRA],[ITEMREF],[AP],[ADET],[BASLIK],[ACIKLAMA],[RESIM],[ISK]) VALUES (@ID,@SIRA,@ITEMREF,@AP,@ADET,@BASLIK,@ACIKLAMA,@RESIM,@ISK)", conn);
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = this.ID;
                cmd.Parameters.Add("@SIRA", SqlDbType.Int).Value = this.SIRA;
                cmd.Parameters.Add("@ITEMREF", SqlDbType.Int).Value = this.ITEMREF;
                cmd.Parameters.Add("@AP", SqlDbType.Int).Value = this.AP;
                cmd.Parameters.Add("@ADET", SqlDbType.Int).Value = this.ADET;
                cmd.Parameters.Add("@BASLIK", SqlDbType.NVarChar).Value = this.BASLIK;
                cmd.Parameters.Add("@ACIKLAMA", SqlDbType.NVarChar).Value = this.ACIKLAMA;
                cmd.Parameters.Add("@RESIM", SqlDbType.VarBinary).Value = this.RESIM;
                cmd.Parameters.Add("@ISK", SqlDbType.Float).Value = this.ISK;
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

        public void DoUpdate()
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UPDATE [Web-Malzeme-Haric] SET [ITEMREF] = @ITEMREF,[AP] = @AP,[ADET] = @ADET,[BASLIK] = @BASLIK,[ACIKLAMA] = @ACIKLAMA,[RESIM] = @RESIM,[ISK] = @ISK WHERE [ID] = @ID AND [SIRA] = @SIRA", conn);
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = this.ID;
                cmd.Parameters.Add("@SIRA", SqlDbType.Int).Value = this.SIRA;
                cmd.Parameters.Add("@ITEMREF", SqlDbType.Int).Value = this.ITEMREF;
                cmd.Parameters.Add("@AP", SqlDbType.Int).Value = this.AP;
                cmd.Parameters.Add("@ADET", SqlDbType.Int).Value = this.ADET;
                cmd.Parameters.Add("@BASLIK", SqlDbType.NVarChar).Value = this.BASLIK;
                cmd.Parameters.Add("@ACIKLAMA", SqlDbType.NVarChar).Value = this.ACIKLAMA;
                cmd.Parameters.Add("@RESIM", SqlDbType.VarBinary).Value = this.RESIM;
                cmd.Parameters.Add("@ISK", SqlDbType.Float).Value = this.ISK;
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
                SqlCommand cmd = new SqlCommand("DELETE FROM [Web-Malzeme-Haric] WHERE ID = @ID AND SIRA = @SIRA", conn);
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = this.ID;
                cmd.Parameters.Add("@SIRA", SqlDbType.Int).Value = this.SIRA;
                cmd.Parameters.Add("@ITEMREF", SqlDbType.Int).Value = this.ITEMREF;
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
                SqlCommand cmd = new SqlCommand("SELECT [ID],[SIRA],[ITEMREF],[AP],[ADET],[BASLIK],[ACIKLAMA],[ISK] FROM [Web-Malzeme-Haric] WHERE SIRA = 1 ORDER BY ID DESC", conn);
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        List.Add(new MalzemeHaric(
                            Convert.ToInt32(dr[0]),
                            Convert.ToInt32(dr[1]),
                            Convert.ToInt32(dr[2]),
                            Convert.ToInt32(dr[3]),
                            Convert.ToInt32(dr[4]),
                            dr[5].ToString(),
                            dr[6].ToString(),
                            null,
                            Convert.ToDouble(dr[7])));
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

        public static void GetObjectsByAna(IList List, int ID)
        {
            List.Clear();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT [ID],[SIRA],[ITEMREF],[AP],[ADET],[BASLIK],[ACIKLAMA],[ISK] FROM [Web-Malzeme-Haric] WHERE ID = @ID ORDER BY SIRA", conn);
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        List.Add(new MalzemeHaric(
                            Convert.ToInt32(dr[0]),
                            Convert.ToInt32(dr[1]),
                            Convert.ToInt32(dr[2]),
                            Convert.ToInt32(dr[3]),
                            Convert.ToInt32(dr[4]),
                            dr[5].ToString(),
                            dr[6].ToString(),
                            null,
                            Convert.ToDouble(dr[7])));
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

        public static MalzemeHaric GetObject(int ID, int SIRA)
        {
            MalzemeHaric donendeger = new MalzemeHaric();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT [ID],[SIRA],[ITEMREF],[AP],[ADET],[BASLIK],[ACIKLAMA],[RESIM],[ISK] FROM [Web-Malzeme-Haric] WHERE ID = @ID AND SIRA = @SIRA", conn);
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
                cmd.Parameters.Add("@SIRA", SqlDbType.Int).Value = SIRA;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        donendeger = new MalzemeHaric(
                            Convert.ToInt32(dr[0]),
                            Convert.ToInt32(dr[1]),
                            Convert.ToInt32(dr[2]),
                            Convert.ToInt32(dr[3]),
                            Convert.ToInt32(dr[4]),
                            dr[5].ToString(),
                            dr[6].ToString(),
                            (byte[])dr[7],
                            Convert.ToDouble(dr[8]));
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

        public static int GetLastID()
        {
            int donendeger = 0;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT max([ID]) FROM [Web-Malzeme-Haric]", conn);
                try
                {
                    conn.Open();
                    donendeger = Convert.ToInt32(cmd.ExecuteScalar());
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

        public static int GetSonSira(int ID)
        {
            int donendeger = 0;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT max([SIRA]) FROM [Web-Malzeme-Haric] WHERE ID = @ID", conn);
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
                try
                {
                    conn.Open();
                    donendeger = Convert.ToInt32(cmd.ExecuteScalar());
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

        public static byte[] GetResim(int ID)
        {
            byte[] donendeger = null;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT RESIM FROM [Web-Malzeme-Haric] WHERE ID = @ID AND SIRA = 1", conn);
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
                try
                {
                    conn.Open();
                    object obj = cmd.ExecuteScalar();
                    if (obj != DBNull.Value)
                        donendeger = (byte[])obj;
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

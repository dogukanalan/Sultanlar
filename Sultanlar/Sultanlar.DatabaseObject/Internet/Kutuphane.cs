using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Collections;

namespace Sultanlar.DatabaseObject.Internet
{
    public class Kutuphane
    {
        public int pkID { get; set; }
        public string strAd { get; set; }
        public string strDosyaTur { get; set; }
        public DateTime dtTarih { get; set; }
        public byte[] binDosya { get; set; }

        private Kutuphane(int pkID, string strAd, string strDosyaTur, DateTime dtTarih, byte[] binDosya)
        {
            this.pkID = pkID;
            this.strAd = strAd;
            this.strDosyaTur = strDosyaTur;
            this.dtTarih = dtTarih;
            this.binDosya = binDosya;
        }

        public Kutuphane(string strAd, string strDosyaTur, DateTime dtTarih, byte[] binDosya)
        {
            this.strAd = strAd;
            this.strDosyaTur = strDosyaTur;
            this.dtTarih = dtTarih;
            this.binDosya = binDosya;
        }

        public Kutuphane()
        {
            // TODO: Complete member initialization
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public override string ToString()
        {
            return this.strAd;
        }

        public void DoInsert()
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO [tblINTERNET_Kutuphane] ([strAd],[strDosyaTur],dtTarih,binDosya) VALUES (@strAd,@strDosyaTur,@dtTarih,@binDosya) SELECT @pkID = SCOPE_IDENTITY()", conn);
                cmd.Parameters.Add("@strAd", SqlDbType.NVarChar, 100).Value = this.strAd;
                cmd.Parameters.Add("@strDosyaTur", SqlDbType.VarChar, 3).Value = this.strDosyaTur;
                cmd.Parameters.Add("@dtTarih", SqlDbType.DateTime).Value = this.dtTarih;
                cmd.Parameters.Add("@binDosya", SqlDbType.VarBinary).Value = this.binDosya;
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
                SqlCommand cmd = new SqlCommand("UPDATE [tblINTERNET_Kutuphane] SET [strAd] = @strAd,[strDosyaTur] = @strDosyaTur,dtTarih = @dtTarih,binDosya = @binDosya WHERE pkID = @pkID", conn);
                cmd.Parameters.Add("@strAd", SqlDbType.NVarChar, 100).Value = this.strAd;
                cmd.Parameters.Add("@strDosyaTur", SqlDbType.VarChar, 3).Value = this.strDosyaTur;
                cmd.Parameters.Add("@dtTarih", SqlDbType.DateTime).Value = this.dtTarih;
                cmd.Parameters.Add("@binDosya", SqlDbType.VarBinary).Value = this.binDosya;
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
                SqlCommand cmd = new SqlCommand("DELETE [tblINTERNET_Kutuphane] WHERE pkID = @pkID", conn);
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

        public static void GetObjects(DataTable dt, string Ad)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT [pkID],[strAd],[strDosyaTur],dtTarih FROM [tblINTERNET_Kutuphane] WHERE strAd LIKE '%" + Ad + "%' ORDER BY pkID DESC", conn);
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

        public static void GetObjects(IList List, bool liste, string Ad)
        {
            List.Clear();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT [pkID],[strAd],[strDosyaTur],dtTarih FROM [tblINTERNET_Kutuphane] WHERE strAd LIKE '%" + Ad + "%' ORDER BY pkID DESC", conn);
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        List.Add(new Kutuphane(Convert.ToInt32(dr[0]), dr[1].ToString(), dr[2].ToString(), Convert.ToDateTime(dr[3]), null));
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

        public static Kutuphane GetObject(int ID)
        {
            Kutuphane donendeger = new Kutuphane();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT [pkID],[strAd],[strDosyaTur],dtTarih,binDosya FROM [tblINTERNET_Kutuphane] WHERE pkID = @pkID", conn);
                cmd.Parameters.Add("@pkID", SqlDbType.Int).Value = ID;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        donendeger.pkID = ID;
                        donendeger.strAd = dr[1].ToString();
                        donendeger.strDosyaTur = dr[2].ToString();
                        donendeger.dtTarih = Convert.ToDateTime(dr[3]);
                        donendeger.binDosya = (byte[])dr[4];
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

        public static byte[] GetResim(int ID)
        {
            byte[] donendeger = new byte[] { };

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT [binDosya] FROM [tblINTERNET_Kutuphane] WHERE pkID = @pkID", conn);
                cmd.Parameters.Add("@pkID", SqlDbType.Int).Value = ID;
                try
                {
                    conn.Open();
                    donendeger = (byte[])cmd.ExecuteScalar();
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






    public class Kutuphane2
    {
        public int pkID { get; set; }
        public string strAd { get; set; }
        public string strDosyaTur { get; set; }
        public DateTime dtTarih { get; set; }
        public byte[] binDosya { get; set; }

        private Kutuphane2(int pkID, string strAd, string strDosyaTur, DateTime dtTarih, byte[] binDosya)
        {
            this.pkID = pkID;
            this.strAd = strAd;
            this.strDosyaTur = strDosyaTur;
            this.dtTarih = dtTarih;
            this.binDosya = binDosya;
        }

        public Kutuphane2(string strAd, string strDosyaTur, DateTime dtTarih, byte[] binDosya)
        {
            this.strAd = strAd;
            this.strDosyaTur = strDosyaTur;
            this.dtTarih = dtTarih;
            this.binDosya = binDosya;
        }

        public Kutuphane2()
        {
            // TODO: Complete member initialization
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public override string ToString()
        {
            return this.strAd;
        }

        public void DoInsert()
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO [tblINTERNET_Kutuphane2] ([strAd],[strDosyaTur],dtTarih,binDosya) VALUES (@strAd,@strDosyaTur,@dtTarih,@binDosya) SELECT @pkID = SCOPE_IDENTITY()", conn);
                cmd.Parameters.Add("@strAd", SqlDbType.NVarChar, 100).Value = this.strAd;
                cmd.Parameters.Add("@strDosyaTur", SqlDbType.VarChar, 3).Value = this.strDosyaTur;
                cmd.Parameters.Add("@dtTarih", SqlDbType.DateTime).Value = this.dtTarih;
                cmd.Parameters.Add("@binDosya", SqlDbType.VarBinary).Value = this.binDosya;
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
                SqlCommand cmd = new SqlCommand("UPDATE [tblINTERNET_Kutuphane2] SET [strAd] = @strAd,[strDosyaTur] = @strDosyaTur,dtTarih = @dtTarih,binDosya = @binDosya WHERE pkID = @pkID", conn);
                cmd.Parameters.Add("@strAd", SqlDbType.NVarChar, 100).Value = this.strAd;
                cmd.Parameters.Add("@strDosyaTur", SqlDbType.VarChar, 3).Value = this.strDosyaTur;
                cmd.Parameters.Add("@dtTarih", SqlDbType.DateTime).Value = this.dtTarih;
                cmd.Parameters.Add("@binDosya", SqlDbType.VarBinary).Value = this.binDosya;
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
                SqlCommand cmd = new SqlCommand("DELETE [tblINTERNET_Kutuphane2] WHERE pkID = @pkID", conn);
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

        public static void GetObjects(DataTable dt, string Ad)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT [pkID],[strAd],[strDosyaTur],dtTarih FROM [tblINTERNET_Kutuphane2] WHERE strAd LIKE '%" + Ad + "%' ORDER BY pkID DESC", conn);
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

        public static void GetObjects(IList List, bool liste, string Ad)
        {
            List.Clear();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT [pkID],[strAd],[strDosyaTur],dtTarih FROM [tblINTERNET_Kutuphane2] WHERE strAd LIKE '%" + Ad + "%' ORDER BY pkID DESC", conn);
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        List.Add(new Kutuphane2(Convert.ToInt32(dr[0]), dr[1].ToString(), dr[2].ToString(), Convert.ToDateTime(dr[3]), null));
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

        public static Kutuphane GetObject(int ID)
        {
            Kutuphane donendeger = new Kutuphane();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT [pkID],[strAd],[strDosyaTur],dtTarih,binDosya FROM [tblINTERNET_Kutuphane2] WHERE pkID = @pkID", conn);
                cmd.Parameters.Add("@pkID", SqlDbType.Int).Value = ID;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        donendeger.pkID = ID;
                        donendeger.strAd = dr[1].ToString();
                        donendeger.strDosyaTur = dr[2].ToString();
                        donendeger.dtTarih = Convert.ToDateTime(dr[3]);
                        donendeger.binDosya = (byte[])dr[4];
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

        public static byte[] GetResim(int ID)
        {
            byte[] donendeger = new byte[] { };

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT [binDosya] FROM [tblINTERNET_Kutuphane2] WHERE pkID = @pkID", conn);
                cmd.Parameters.Add("@pkID", SqlDbType.Int).Value = ID;
                try
                {
                    conn.Open();
                    donendeger = (byte[])cmd.ExecuteScalar();
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

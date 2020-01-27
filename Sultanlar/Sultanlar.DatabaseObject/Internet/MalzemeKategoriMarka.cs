using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace Sultanlar.DatabaseObject.Internet
{
    public class Marka
    {
        private int _REF; private string _MARKA; private string _ACIKLAMA;
        public Marka(int REF, string MARKA, string ACIKLAMA) { this._REF = REF; this._MARKA = MARKA; this._ACIKLAMA = ACIKLAMA; }
        public int REF { get { return this._REF; } } public string MARKA { get { return this._MARKA; } } public string ACIKLAMA { get { return this._ACIKLAMA; } }
        public override string ToString() { return this._MARKA; }
    }

    public class Cinsiyet
    {
        private int _REF; private string _CINSIYET; private string _ACIKLAMA;
        public Cinsiyet(int REF, string CINSIYET, string ACIKLAMA) { this._REF = REF; this._CINSIYET = CINSIYET; this._ACIKLAMA = ACIKLAMA; }
        public int REF { get { return this._REF; } } public string CINSIYET { get { return this._CINSIYET; } } public string ACIKLAMA { get { return this._ACIKLAMA; } }
        public override string ToString() { return this._CINSIYET; }
    }

    public class ReyonKategori
    {
        private int _REF; private string _KATEGORI; private string _ACIKLAMA;
        public ReyonKategori(int REF, string KATEGORI, string ACIKLAMA) { this._REF = REF; this._KATEGORI = KATEGORI; this._ACIKLAMA = ACIKLAMA; }
        public int REF { get { return this._REF; } } public string KATEGORI { get { return this._KATEGORI; } } public string ACIKLAMA { get { return this._ACIKLAMA; } }
        public override string ToString() { return this._KATEGORI; }
    }

    public class MalzemeKategoriMarka
    {
        /// <summary>
        /// 
        /// </summary>
        public static DataTable GetBaglanti(int ITEMREF)
        {
            DataTable donendeger = new DataTable();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT REF,ITEMREF,KATEGORIREF,MARKAREF,CINSIYETREF,ACIKLAMA FROM [Web-Malzeme-Aciklama] WHERE ITEMREF = @ITEMREF", conn);
                da.SelectCommand.Parameters.Add("@ITEMREF", SqlDbType.Int).Value = ITEMREF;
                try
                {
                    conn.Open();
                    da.Fill(donendeger);
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
        /// <summary>
        /// 
        /// </summary>
        public static void GetMarkalar(IList List)
        {
            List.Clear();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT REF,MARKA,ACIKLAMA FROM [Web-Malzeme-Marka] ORDER BY MARKA", conn);
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        List.Add(new Marka(Convert.ToInt32(dr[0]), dr[1].ToString(), dr[2].ToString()));
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
        /// <summary>
        /// 
        /// </summary>
        public static void GetCinsiyetler(IList List)
        {
            List.Clear();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT REF,CINSIYET,ACIKLAMA FROM [Web-Malzeme-Cinsiyet] ORDER BY CINSIYET", conn);
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        List.Add(new Cinsiyet(Convert.ToInt32(dr[0]), dr[1].ToString(), dr[2].ToString()));
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
        /// <summary>
        /// 
        /// </summary>
        public static void GetAnaKategoriler(IList List)
        {
            List.Clear();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT REF,KATEGORI,ACIKLAMA FROM [Web-Malzeme-ReyonKategori] WHERE USTREF = 0 ORDER BY KATEGORI", conn);
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        List.Add(new ReyonKategori(Convert.ToInt32(dr[0]), dr[1].ToString(), dr[2].ToString()));
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
        /// <summary>
        /// 
        /// </summary>
        public static void GetAltKategoriler(IList List, int USTREF)
        {
            List.Clear();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT REF,KATEGORI,ACIKLAMA FROM [Web-Malzeme-ReyonKategori] WHERE USTREF = @USTREF ORDER BY KATEGORI", conn);
                cmd.Parameters.Add("@USTREF", SqlDbType.Int).Value = USTREF;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        List.Add(new ReyonKategori(Convert.ToInt32(dr[0]), dr[1].ToString(), dr[2].ToString()));
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
        /// <summary>
        /// 
        /// </summary>
        public static int GetUSTREF(int REF)
        {
            int donendeger = 0;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT USTREF FROM [Web-Malzeme-ReyonKategori] WHERE REF = @REF", conn);
                cmd.Parameters.Add("@REF", SqlDbType.Int).Value = REF;
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
        /// <summary>
        /// 
        /// </summary>
        public static void DoInsertUpdate(int ITEMREF, int KATEGORIREF, int MARKAREF, int CINSIYETREF, string ACIKLAMA, string KULLANICI)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT count(REF) FROM [Web-Malzeme-Aciklama] WHERE ITEMREF = @ITEMREF", conn);
                cmd.Parameters.Add("@ITEMREF", SqlDbType.Int).Value = ITEMREF;

                SqlCommand cmd1 = new SqlCommand("INSERT INTO [Web-Malzeme-Aciklama] (ITEMREF,KATEGORIREF,MARKAREF,CINSIYETREF,ACIKLAMA,TARIH,KULLANICI) VALUES (@ITEMREF,@KATEGORIREF,@MARKAREF,@CINSIYETREF,@ACIKLAMA,@TARIH,@KULLANICI)", conn);
                cmd1.Parameters.Add("@ITEMREF", SqlDbType.Int).Value = ITEMREF;
                cmd1.Parameters.Add("@KATEGORIREF", SqlDbType.Int).Value = KATEGORIREF;
                cmd1.Parameters.Add("@MARKAREF", SqlDbType.Int).Value = MARKAREF;
                cmd1.Parameters.Add("@CINSIYETREF", SqlDbType.Int).Value = CINSIYETREF;
                cmd1.Parameters.Add("@ACIKLAMA", SqlDbType.NVarChar).Value = ACIKLAMA;
                cmd1.Parameters.Add("@TARIH", SqlDbType.DateTime).Value = DateTime.Now;
                cmd1.Parameters.Add("@KULLANICI", SqlDbType.NVarChar).Value = KULLANICI;

                SqlCommand cmd2 = new SqlCommand("UPDATE [Web-Malzeme-Aciklama] SET KATEGORIREF=@KATEGORIREF,MARKAREF=@MARKAREF,CINSIYETREF=@CINSIYETREF,ACIKLAMA=@ACIKLAMA,TARIH=@TARIH,KULLANICI=@KULLANICI WHERE ITEMREF=@ITEMREF", conn);
                cmd2.Parameters.Add("@KATEGORIREF", SqlDbType.Int).Value = KATEGORIREF;
                cmd2.Parameters.Add("@MARKAREF", SqlDbType.Int).Value = MARKAREF;
                cmd2.Parameters.Add("@CINSIYETREF", SqlDbType.Int).Value = CINSIYETREF;
                cmd2.Parameters.Add("@ACIKLAMA", SqlDbType.NVarChar).Value = ACIKLAMA;
                cmd2.Parameters.Add("@ITEMREF", SqlDbType.Int).Value = ITEMREF;
                cmd2.Parameters.Add("@TARIH", SqlDbType.DateTime).Value = DateTime.Now;
                cmd2.Parameters.Add("@KULLANICI", SqlDbType.NVarChar).Value = KULLANICI;

                try
                {
                    conn.Open();
                    if (Convert.ToBoolean(cmd.ExecuteScalar()))
                        cmd2.ExecuteNonQuery();
                    else
                        cmd1.ExecuteNonQuery();
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
        /// <summary>
        /// 
        /// </summary>
        public static void KategoriDoInsert(int USTREF, string KATEGORI, string ACIKLAMA)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO [Web-Malzeme-ReyonKategori] (USTREF,KATEGORI,ACIKLAMA) VALUES (@USTREF,@KATEGORI,@ACIKLAMA)", conn);
                cmd.Parameters.Add("@USTREF", SqlDbType.Int).Value = USTREF;
                cmd.Parameters.Add("@KATEGORI", SqlDbType.NVarChar).Value = KATEGORI;
                cmd.Parameters.Add("@ACIKLAMA", SqlDbType.NVarChar).Value = ACIKLAMA;

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
        /// <summary>
        /// 
        /// </summary>
        public static void MarkaDoInsert(string MARKA, string ACIKLAMA)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO [Web-Malzeme-Marka] (MARKA,ACIKLAMA) VALUES (@MARKA,@ACIKLAMA)", conn);
                cmd.Parameters.Add("@MARKA", SqlDbType.NVarChar).Value = MARKA;
                cmd.Parameters.Add("@ACIKLAMA", SqlDbType.NVarChar).Value = ACIKLAMA;

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
        /// <summary>
        /// 
        /// </summary>
        public static void CinsiyetDoInsert(string CINSIYET, string ACIKLAMA)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO [Web-Malzeme-Cinsiyet] (CINSIYET,ACIKLAMA) VALUES (@CINSIYET,@ACIKLAMA)", conn);
                cmd.Parameters.Add("@CINSIYET", SqlDbType.NVarChar).Value = CINSIYET;
                cmd.Parameters.Add("@ACIKLAMA", SqlDbType.NVarChar).Value = ACIKLAMA;

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
    }
}

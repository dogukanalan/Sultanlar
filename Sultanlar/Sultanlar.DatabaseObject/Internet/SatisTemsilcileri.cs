using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Web.UI.WebControls;
using Sultanlar.Class;

namespace Sultanlar.DatabaseObject.Internet
{
    public class SatisTemsilcileri
    {
        int _SLSREF; string _SATTEM;
        public SatisTemsilcileri(int SLSREF, string SATTEM) { this._SLSREF = SLSREF; this._SATTEM = SATTEM; }
        public int SLSREF { get { return this._SLSREF; } } public string SATTEM { get { return this._SATTEM; } }
        public override string ToString() { return this._SATTEM; }

        public static void GetObjects(DataTable dt)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT DISTINCT [Web-SatisTemsilcileri].[ACTIVE],[Web-SatisTemsilcileri].[SLSMANREF],[Web-SatisTemsilcileri].[SAT KOD],[Web-SatisTemsilcileri].[SAT KOD1],[Web-SatisTemsilcileri].[SAT TEM],[TELEFON] FROM [Web-SatisTemsilcileri] INNER JOIN [Web-Musteri] ON [Web-SatisTemsilcileri].SLSMANREF = [Web-Musteri].SLSREF WHERE [Web-Musteri].ACTIVE = 0 ORDER BY [SAT TEM]", conn);
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
        public static void GetObjects(IList List, bool UI)
        {
            List.Clear();

            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3))
            {
                SqlCommand cmd = new SqlCommand("SELECT DISTINCT [SLSMANREF],[Web-SatisTemsilcileri].[SAT TEM] FROM [Web-SatisTemsilcileri] INNER JOIN [Web-Musteri] ON [Web-SatisTemsilcileri].SLSMANREF = [Web-Musteri].SLSREF WHERE [Web-Musteri].ACTIVE = 0 ORDER BY [SAT TEM]", conn);
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        List.Add(new SatisTemsilcileri(Convert.ToInt32(dr[0]), dr[1].ToString()));
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
        public static void GetObjects(ListItemCollection lic, bool web, bool Tumu)
        {
            lic.Clear();

            lic.Add(new ListItem("Seçiniz", "0"));
            if (Tumu) lic.Add(new ListItem("Tümü", "1"));

            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3))
            {
                SqlCommand cmd = new SqlCommand("SELECT DISTINCT [SLSMANREF],[Web-SatisTemsilcileri].[SAT TEM] FROM [Web-SatisTemsilcileri] INNER JOIN [Web-Musteri] ON [Web-SatisTemsilcileri].SLSMANREF = [Web-Musteri].SLSREF WHERE [Web-Musteri].ACTIVE = 0 ORDER BY [SAT TEM]", conn);
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        lic.Add(new ListItem(dr[1].ToString(), dr[0].ToString()));
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
        public static void GetObjectsWS(DataTable dt)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT [SLSMANREF] AS 'salesman_ref',[SAT TEM] AS 'salesman' FROM [Web-SatisTemsilcileri] ORDER BY [SAT TEM]", conn);
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
        public static void GetObjectsBySLSREFs(ListItemCollection lic, ArrayList SLSREFs, bool Tumu)
        {
            lic.Clear();

            lic.Add(new ListItem("Seçiniz", "0"));

            if (Tumu)
                lic.Add(new ListItem("Tümü", "1"));

            string slsrefs = "WHERE ";
            for (int i = 0; i < SLSREFs.Count; i++)
            {
                slsrefs += "SLSMANREF = " + SLSREFs[i].ToString() + " OR ";
            }
            slsrefs = slsrefs.Substring(0, slsrefs.Length - 4);

            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3))
            {
                SqlCommand cmd = new SqlCommand("SELECT [SLSMANREF],[SAT TEM] FROM [Web-SatisTemsilcileri] " + slsrefs + " ORDER BY [SAT TEM]", conn);
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        lic.Add(new ListItem(dr[1].ToString(), dr[0].ToString()));
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
        public static void GetObjectsFromCariHesaplar(IList List, bool UI)
        {
            List.Clear();

            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3))
            {
                SqlCommand cmd = new SqlCommand("SELECT DISTINCT [SLSREF],[SAT TEM] FROM [KurumsalWebSAP].[dbo].[Web-Musteri] ORDER BY [SAT TEM]", conn);
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        List.Add(new SatisTemsilcileri(Convert.ToInt32(dr[0]), dr[1].ToString()));
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
        public static ArrayList GetObjectBySLSREF(int SLSREF)
        {
            ArrayList donendeger = new ArrayList();

            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3))
            {
                SqlCommand cmd = new SqlCommand("SELECT TOP 1 [SAT KOD1],[SAT TEM] FROM [Web-SatisTemsilcileri] WHERE [SLSMANREF] = @SLSMANREF", conn);
                cmd.Parameters.Add("@SLSMANREF", SqlDbType.Int).Value = SLSREF;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        donendeger.Add(dr[0].ToString());
                        donendeger.Add(dr[1].ToString());
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
        public static string GetObjectBySATKOD(string SATKOD)
        {
            string donendeger = string.Empty;

            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3))
            {
                SqlCommand cmd = new SqlCommand("SELECT [SAT TEM] FROM [Web-SatisTemsilcileri] WHERE [SAT KOD1] = @SATKOD1", conn);
                cmd.Parameters.Add("@SATKOD1", SqlDbType.VarChar, 11).Value = SATKOD;
                try
                {
                    conn.Open();
                    object obj = cmd.ExecuteScalar();
                    if (obj != null)
                        donendeger = obj.ToString();
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
        public static string GetObjectBySLSREF(string SLSREF)
        {
            string donendeger = string.Empty;

            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3))
            {
                SqlCommand cmd = new SqlCommand("SELECT [SAT TEM] FROM [Web-SatisTemsilcileri] WHERE [SLSMANREF] = @SLSREF", conn);
                cmd.Parameters.Add("@SLSREF", SqlDbType.Int).Value = SLSREF;
                try
                {
                    conn.Open();
                    object obj = cmd.ExecuteScalar();
                    if (obj != null)
                        donendeger = obj.ToString();
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
        public static void GetObjectsBySatisTemsilcisi(DataTable dt, string SatisTemsilcisiBaslangici)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT DISTINCT [ACTIVE],[SLSMANREF],[SAT KOD],[SAT KOD1],[SAT TEM],[TELEFON] FROM [Web-SatisTemsilcileri] WHERE [SAT TEM] LIKE '%" + SatisTemsilcisiBaslangici + "%'", conn);
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
        public static void GetObjectsBySatisTemsilcisi(ListItemCollection lic, string SatisTemsilcisi, bool Tumu)
        {
            lic.Clear();
            lic.Add(new ListItem("Seçiniz", "0"));
            if (Tumu) lic.Add(new ListItem("Tümü", "1"));

            ArrayList sattems = StringParcalama.TurkceKarakterPermutasyon(SatisTemsilcisi);
            string sonuc = "WHERE ";
            for (int i = 0; i < sattems.Count; i++)
            {
                sonuc += "[SAT TEM] LIKE '%" + sattems[i].ToString() + "%' OR ";
            }
            sonuc = sonuc.Substring(0, sonuc.Length - 4);

            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3))
            {
                SqlCommand cmd = new SqlCommand("SELECT DISTINCT [SLSMANREF],[SAT TEM] FROM [Web-SatisTemsilcileri] " + sonuc + " ORDER BY [SAT TEM]", conn);
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        lic.Add(new ListItem(dr[1].ToString(), dr[0].ToString()));
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
        public static string GetSATKODBySLSREF(int SLSREF)
        {
            string donendeger = string.Empty;

            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3))
            {
                SqlCommand cmd = new SqlCommand("SELECT [SAT KOD] FROM [Web-SatisTemsilcileri] WHERE [SLSMANREF] = @SLSREF", conn);
                cmd.Parameters.Add("@SLSREF", SqlDbType.Int).Value = SLSREF;
                try
                {
                    conn.Open();
                    object obj = cmd.ExecuteScalar();
                    if (obj != null)
                        donendeger = obj.ToString();
                    else
                        donendeger = "0";
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
        public static string GetSATKOD1BySLSREF(int SLSREF)
        {
            string donendeger = string.Empty;

            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3))
            {
                SqlCommand cmd = new SqlCommand("SELECT [SAT KOD1] FROM [Web-SatisTemsilcileri] WHERE [SLSMANREF] = @SLSREF", conn);
                cmd.Parameters.Add("@SLSREF", SqlDbType.Int).Value = SLSREF;
                try
                {
                    conn.Open();
                    object obj = cmd.ExecuteScalar();
                    if (obj != null)
                        donendeger = obj.ToString();
                    else
                        donendeger = "0";
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
        public static string GetTELEFONBySLSREF(int SLSREF)
        {
            string donendeger = string.Empty;

            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3))
            {
                SqlCommand cmd = new SqlCommand("SELECT [TELEFON] FROM [Web-SatisTemsilcileri] WHERE [SLSMANREF] = @SLSREF", conn);
                cmd.Parameters.Add("@SLSREF", SqlDbType.Int).Value = SLSREF;
                try
                {
                    conn.Open();
                    object obj = cmd.ExecuteScalar();
                    if (obj != null)
                        donendeger = obj.ToString();
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
        /// [Web-Musteri], seçiniz ve tümü yok
        /// </summary>
        public static void GetObjectsFromCariHesaplar(ListItemCollection lic)
        {
            lic.Clear();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT DISTINCT [SLSREF],[SAT TEM] FROM [Web-Musteri] WHERE ACTIVE = 0 ORDER BY [SAT TEM]", conn);
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        lic.Add(new ListItem(dr[1].ToString(), dr[0].ToString()));
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
        /// [Web-Musteri]
        /// </summary>
        public static void GetObjectsFromCariHesaplar(ListItemCollection lic, bool Seciniz, bool Tumu)
        {
            lic.Clear();

            if (Seciniz)
                lic.Add(new ListItem("Seçiniz", "0"));
            if (Tumu)
                lic.Add(new ListItem("Tümü", "1"));

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT DISTINCT [SLSREF],[SAT TEM] FROM [Web-Musteri] ORDER BY [SAT TEM]", conn);
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        lic.Add(new ListItem(dr[1].ToString(), dr[0].ToString()));
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
        /// [Web-Musteri], seçiniz ve tümü yok
        /// </summary>
        public static void GetObjectsFromCariHesaplarNot8(ListItemCollection lic, bool Seciniz)
        {
            lic.Clear();

            if (Seciniz)
                lic.Add(new ListItem("Seçiniz", "0"));

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT DISTINCT [SLSREF],[SAT TEM] FROM [Web-Musteri] WHERE [SAT KOD1] = 'VE' ORDER BY [SAT TEM]", conn); //[SAT KOD1] NOT LIKE '8%'
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        lic.Add(new ListItem(dr[1].ToString(), dr[0].ToString()));
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
        /// [Web-Musteri]
        /// </summary>
        public static ArrayList GetSLSREFsFromCariHesaplar()
        {
            ArrayList donendeger = new ArrayList();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT DISTINCT [SLSREF],[SAT TEM] FROM [Web-Musteri] ORDER BY [SAT TEM]", conn);
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        donendeger.Add(dr[0].ToString());
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
        public static int GetSLSREFBySATTEM(string SATTEM)
        {
            int donendeger = 0;

            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3))
            {
                SqlCommand cmd = new SqlCommand("SELECT [SLSMANREF] FROM [Web-SatisTemsilcileri] WHERE [SAT TEM] = @SATTEM", conn);
                cmd.Parameters.Add("@SATTEM", SqlDbType.VarChar, 41).Value = SATTEM;
                try
                {
                    conn.Open();
                    object obj = cmd.ExecuteScalar();
                    if (obj != null)
                        donendeger = Convert.ToInt32(obj);
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
        /// Bizdeki tek satış temsilcisi
        /// </summary>
        public static string GetSATTEMBySMREF(int SMREF)
        {
            string donendeger = string.Empty;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT TOP 1 [SAT TEM] FROM [Web-Musteri] WHERE [SAT KOD1] = 'VE' AND [SMREF] = @SMREF", conn); //[SAT KOD1] NOT LIKE '8%' AND SUBSTRING([SAT KOD], 11, 2) NOT LIKE '08' AND SUBSTRING([SAT KOD], 11, 2) NOT LIKE '16' AND SUBSTRING([SAT KOD], 11, 2) NOT LIKE '17' AND SUBSTRING([SAT KOD], 11, 2) NOT LIKE '18' AND [SAT KOD] NOT LIKE '00%'
                cmd.Parameters.Add("@SMREF", SqlDbType.Int).Value = SMREF;
                try
                {
                    conn.Open();
                    object obj = cmd.ExecuteScalar();
                    if (obj != null)
                        donendeger = obj.ToString();
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
        /// satış temsilcisi gibi gözüken bayi kartının slsrefini gmref vererek alıyoruz
        /// </summary>
        public static int GetSLSREFbyPOSITION(int GMREF)
        {
            int donendeger = 0;

            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3))
            {
                SqlCommand cmd = new SqlCommand("SELECT SLSMANREF FROM [Web-SatisTemsilcileri] WHERE [POSITION_] = @POSITION", conn);
                cmd.Parameters.Add("@POSITION", SqlDbType.VarChar).Value = GMREF.ToString();
                try
                {
                    conn.Open();
                    object obj = cmd.ExecuteScalar();
                    if (obj != null)
                        donendeger = Convert.ToInt32(obj);
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





        #region Yeni
        #region GetObjects()
        public static List<SatisTemsilcileri> GetObjects()
        {
            List<SatisTemsilcileri> donendeger = new List<SatisTemsilcileri>();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT DISTINCT [Web-SatisTemsilcileri].[SLSMANREF],[Web-SatisTemsilcileri].[SAT TEM] FROM [Web-SatisTemsilcileri] INNER JOIN [Web-Musteri] ON [Web-SatisTemsilcileri].SLSMANREF = [Web-Musteri].SLSREF WHERE [Web-Musteri].ACTIVE = 0 ORDER BY [SAT TEM]", conn);
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                        donendeger.Add(new SatisTemsilcileri(Convert.ToInt32(dr[0]), dr[1].ToString()));
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
        #endregion
        #region GetObject(int)
        public static SatisTemsilcileri GetObject(int SLSREF)
        {
            SatisTemsilcileri donendeger = new SatisTemsilcileri(0, "");

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT SLSMANREF,[SAT TEM] FROM [Web-SatisTemsilcileri] WHERE [SLSMANREF] = @SLSREF", conn);
                cmd.Parameters.Add("@SLSREF", SqlDbType.Int).Value = SLSREF;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                        donendeger = new SatisTemsilcileri(Convert.ToInt32(dr[0]), dr[1].ToString());
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
        #endregion
        #endregion
    }
}

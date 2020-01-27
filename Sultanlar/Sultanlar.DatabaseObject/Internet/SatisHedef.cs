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
    public class SatisHedef
    {
        /// <summary>
        /// [Web-Satis-Hedef]
        /// </summary>
        public static int GetObjectCount()
        {
            int donendeger = 0;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT count(*) FROM [Web-Satis-Hedef]", conn);
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
        public static void GetObjects(DataTable dt)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT [BOLGE],[GRUP],[EKP],[SLSREF],[SAT KOD],[SAT TEM],[TARIH],[AY],[AYLAR],[AYGNIS],[HF],[HAFTALAR],[HFGN],[GUN],[KATEGORI],[HD GN],[AD/KL],[AD/KL NT],[SAT GN],[SAT GN NT],[MUST AD],[AY AD],[GN AD],[AY AD NT],[GN AD NT] FROM [Web-Satis-Hedef] ORDER BY TARIH", conn);
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



        public static void GetKategoriler(ListItemCollection lic)
        {
            lic.Clear();
            lic.Add(new ListItem("Tümü", "0"));
            //lic.Add(new ListItem("AL-SAT Hariç Tümü", "1"));

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT DISTINCT [KATEGORI] FROM [Web-Satis-Hedef] ORDER BY KATEGORI", conn);
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                        lic.Add(new ListItem(dr[0].ToString(), dr[0].ToString()));
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



        // {
        public static int GetObjectCount(int SLSREF, string KATEGORI)
        {
            int donendeger = 0;

            string tablo = SatisTemsilcileri.GetSATKOD1BySLSREF(SLSREF).StartsWith("8") ? "[Web-Satis-Hedef-Nst]" : "[Web-Satis-Hedef]";

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT count(*) FROM " + tablo + " WHERE SLSREF = @SLSREF AND KATEGORI " + (KATEGORI != "0" ? "= '" + KATEGORI + "'": "IS NOT NULL "), conn);
                cmd.Parameters.Add("@SLSREF", SqlDbType.Int).Value = SLSREF;
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
        public static void GetObjects(DataTable dt, int SLSREF, string KATEGORI, int Baslangic, int Adet)
        {
            string tablo = SatisTemsilcileri.GetSATKOD1BySLSREF(SLSREF).StartsWith("8") ? "[Web-Satis-Hedef-Nst]" : "[Web-Satis-Hedef]";

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT [BOLGE],[GRUP],[EKP],[SLSREF],[SAT KOD],[SAT TEM],[TARIH],[AY],[AYLAR],[AYGNIS],[HF],[HAFTALAR],[HFGN],[GUN],[KATEGORI],[HD GN],[AD/KL],[AD/KL NT],[SAT GN],[SAT GN NT],[MUST AD],[AY AD],[GN AD],[AY AD NT],[GN AD NT] FROM " + tablo + " WHERE SLSREF = @SLSREF AND KATEGORI " + (KATEGORI != "0" ? "= '" + KATEGORI + "'": "IS NOT NULL ") + "ORDER BY TARIH", conn);
                da.SelectCommand.Parameters.Add("@SLSREF", SqlDbType.Int).Value = SLSREF;
                try
                {
                    conn.Open();
                    da.Fill(Baslangic, Adet, dt);
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
        public static ArrayList GetToplamlar(int SLSREF, string KATEGORI)
        {
            ArrayList donendeger = new ArrayList();

            string tablo = SatisTemsilcileri.GetSATKOD1BySLSREF(SLSREF).StartsWith("8") ? "[Web-Satis-Hedef-Nst]" : "[Web-Satis-Hedef]";

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT sum([HD GN]),sum([SAT GN]),sum([SAT GN NT]) FROM " + tablo + " WHERE [SLSREF] = @SLSREF AND KATEGORI " + (KATEGORI != "0" ? "= " + KATEGORI : "IS NOT NULL"), conn);
                cmd.Parameters.Add("@SLSREF", SqlDbType.Int).Value = SLSREF;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        object hedef = dr[0]; object satilan = dr[1]; object satilannet = dr[2];

                        if (hedef != DBNull.Value)
                            donendeger.Add(Convert.ToDecimal(hedef));
                        else
                            donendeger.Add(Convert.ToDecimal(0));

                        if (satilan != DBNull.Value)
                            donendeger.Add(Convert.ToDecimal(satilan));
                        else
                            donendeger.Add(Convert.ToDecimal(0));

                        if (satilannet != DBNull.Value)
                            donendeger.Add(Convert.ToDecimal(satilannet));
                        else
                            donendeger.Add(Convert.ToDecimal(0));
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

        public static int GetObjectCountByYil(int SLSREF, string KATEGORI, int Yil)
        {
            int donendeger = 0;

            string tablo = SatisTemsilcileri.GetSATKOD1BySLSREF(SLSREF).StartsWith("8") ? "[Web-Satis-Hedef-Nst]" : "[Web-Satis-Hedef]";

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT count(*) FROM " + tablo + " WHERE SLSREF = @SLSREF AND KATEGORI " + (KATEGORI != "0" ? "= '" + KATEGORI + "'": "IS NOT NULL ") + " AND YIL = @YIL", conn);
                cmd.Parameters.Add("@SLSREF", SqlDbType.Int).Value = SLSREF;
                cmd.Parameters.Add("@YIL", SqlDbType.Int).Value = Yil;
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
        public static void GetObjectsByYil(DataTable dt, int SLSREF, string KATEGORI, int Yil, int Baslangic, int Adet)
        {
            string tablo = SatisTemsilcileri.GetSATKOD1BySLSREF(SLSREF).StartsWith("8") ? "[Web-Satis-Hedef-Nst]" : "[Web-Satis-Hedef]";

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT [BOLGE],[GRUP],[EKP],[SLSREF],[SAT KOD],[SAT TEM],[TARIH],[AY],[AYLAR],[AYGNIS],[HF],[HAFTALAR],[HFGN],[GUN],[KATEGORI],[HD GN],[AD/KL],[AD/KL NT],[SAT GN],[SAT GN NT],[MUST AD],[AY AD],[GN AD],[AY AD NT],[GN AD NT] FROM " + tablo + " WHERE SLSREF = @SLSREF AND KATEGORI " + (KATEGORI != "0" ? "= '" + KATEGORI + "'": "IS NOT NULL ") + " AND YIL = @YIL ORDER BY TARIH", conn);
                da.SelectCommand.Parameters.Add("@SLSREF", SqlDbType.Int).Value = SLSREF;
                da.SelectCommand.Parameters.Add("@YIL", SqlDbType.Int).Value = Yil;
                try
                {
                    conn.Open();
                    da.Fill(Baslangic, Adet, dt);
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
        public static ArrayList GetToplamlarByYil(int SLSREF, string KATEGORI, int Yil)
        {
            ArrayList donendeger = new ArrayList();

            string tablo = SatisTemsilcileri.GetSATKOD1BySLSREF(SLSREF).StartsWith("8") ? "[Web-Satis-Hedef-Nst]" : "[Web-Satis-Hedef]";

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT sum([HD GN]),sum([SAT GN]),sum([SAT GN NT]) FROM " + tablo + " WHERE [SLSREF] = @SLSREF AND KATEGORI " + (KATEGORI != "0" ? "= '" + KATEGORI + "'": "IS NOT NULL ") + " AND YIL = @YIL", conn);
                cmd.Parameters.Add("@SLSREF", SqlDbType.Int).Value = SLSREF;
                cmd.Parameters.Add("@YIL", SqlDbType.Int).Value = Yil;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        object hedef = dr[0]; object satilan = dr[1]; object satilannet = dr[2];

                        if (hedef != DBNull.Value)
                            donendeger.Add(Convert.ToDecimal(hedef));
                        else
                            donendeger.Add(Convert.ToDecimal(0));

                        if (satilan != DBNull.Value)
                            donendeger.Add(Convert.ToDecimal(satilan));
                        else
                            donendeger.Add(Convert.ToDecimal(0));

                        if (satilannet != DBNull.Value)
                            donendeger.Add(Convert.ToDecimal(satilannet));
                        else
                            donendeger.Add(Convert.ToDecimal(0));
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
        public static void GetYillar(ListItemCollection lic, int SLSREF, string KATEGORI)
        {
            lic.Clear();
            //lic.Add(new ListItem("Tümü", "0"));

            string tablo = SatisTemsilcileri.GetSATKOD1BySLSREF(SLSREF).StartsWith("8") ? "[Web-Satis-Hedef-Nst]" : "[Web-Satis-Hedef]";

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT DISTINCT [YIL] AS DEGER,[YIL] AS AD FROM " + tablo + " WHERE SLSREF = @SLSREF AND KATEGORI " + (KATEGORI != "0" ? "= '" + KATEGORI + "'": "IS NOT NULL ") + " ORDER BY DEGER", conn);
                cmd.Parameters.Add("@SLSREF", SqlDbType.Int).Value = SLSREF;
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

        public static int GetObjectCountByAy(int SLSREF, string KATEGORI, int Yil, int Ay)
        {
            int donendeger = 0;

            string tablo = SatisTemsilcileri.GetSATKOD1BySLSREF(SLSREF).StartsWith("8") ? "[Web-Satis-Hedef-Nst]" : "[Web-Satis-Hedef]";

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT count(*) FROM " + tablo + " WHERE SLSREF = @SLSREF AND KATEGORI " + (KATEGORI != "0" ? "= '" + KATEGORI + "'": "IS NOT NULL ") + " AND YIL = @YIL AND AY = @AY", conn);
                cmd.Parameters.Add("@SLSREF", SqlDbType.Int).Value = SLSREF;
                cmd.Parameters.Add("@YIL", SqlDbType.Int).Value = Yil;
                cmd.Parameters.Add("@AY", SqlDbType.Int).Value = Ay;
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
        public static void GetObjectsByAy(DataTable dt, int SLSREF, string KATEGORI, int Yil, int Ay, int Baslangic, int Adet)
        {
            string tablo = SatisTemsilcileri.GetSATKOD1BySLSREF(SLSREF).StartsWith("8") ? "[Web-Satis-Hedef-Nst]" : "[Web-Satis-Hedef]";

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT [BOLGE],[GRUP],[EKP],[SLSREF],[SAT KOD],[SAT TEM],[TARIH],[AY],[AYLAR],[AYGNIS],[HF],[HAFTALAR],[HFGN],[GUN],[KATEGORI],[HD GN],[AD/KL],[AD/KL NT],[SAT GN],[SAT GN NT],[MUST AD],[AY AD],[GN AD],[AY AD NT],[GN AD NT] FROM " + tablo + " WHERE SLSREF = @SLSREF AND KATEGORI " + (KATEGORI != "0" ? "= '" + KATEGORI + "'": "IS NOT NULL ") + " AND YIL = @YIL AND AY = @AY ORDER BY TARIH", conn);
                da.SelectCommand.Parameters.Add("@SLSREF", SqlDbType.Int).Value = SLSREF;
                da.SelectCommand.Parameters.Add("@YIL", SqlDbType.Int).Value = Yil;
                da.SelectCommand.Parameters.Add("@AY", SqlDbType.Int).Value = Ay;
                try
                {
                    conn.Open();
                    da.Fill(Baslangic, Adet, dt);
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
        public static ArrayList GetToplamlarByAy(int SLSREF, string KATEGORI, int Yil, int Ay)
        {
            ArrayList donendeger = new ArrayList();

            string tablo = SatisTemsilcileri.GetSATKOD1BySLSREF(SLSREF).StartsWith("8") ? "[Web-Satis-Hedef-Nst]" : "[Web-Satis-Hedef]";

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT sum([HD GN]),sum([SAT GN]),sum([SAT GN NT]) FROM " + tablo + " WHERE [SLSREF] = @SLSREF AND KATEGORI " + (KATEGORI != "0" ? "= '" + KATEGORI + "'": "IS NOT NULL ") + " AND YIL = @YIL AND AY = @AY", conn);
                cmd.Parameters.Add("@SLSREF", SqlDbType.Int).Value = SLSREF;
                cmd.Parameters.Add("@YIL", SqlDbType.Int).Value = Yil;
                cmd.Parameters.Add("@AY", SqlDbType.Int).Value = Ay;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        object hedef = dr[0]; object satilan = dr[1]; object satilannet = dr[2];

                        if (hedef != DBNull.Value)
                            donendeger.Add(Convert.ToDecimal(hedef));
                        else
                            donendeger.Add(Convert.ToDecimal(0));

                        if (satilan != DBNull.Value)
                            donendeger.Add(Convert.ToDecimal(satilan));
                        else
                            donendeger.Add(Convert.ToDecimal(0));

                        if (satilannet != DBNull.Value)
                            donendeger.Add(Convert.ToDecimal(satilannet));
                        else
                            donendeger.Add(Convert.ToDecimal(0));
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
        public static void GetAylarByYil(ListItemCollection lic, int SLSREF, string KATEGORI, int Yil)
        {
            lic.Clear();
            lic.Add(new ListItem("Tümü", "0"));

            string tablo = SatisTemsilcileri.GetSATKOD1BySLSREF(SLSREF).StartsWith("8") ? "[Web-Satis-Hedef-Nst]" : "[Web-Satis-Hedef]";

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT DISTINCT [AY],[AYLAR] FROM " + tablo + " WHERE SLSREF = @SLSREF AND KATEGORI " + (KATEGORI != "0" ? "= '" + KATEGORI + "'": "IS NOT NULL ") + " AND YIL = @YIL ORDER BY [AY]", conn);
                cmd.Parameters.Add("@SLSREF", SqlDbType.Int).Value = SLSREF;
                cmd.Parameters.Add("@YIL", SqlDbType.Int).Value = Yil;
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

        public static int GetObjectCountByHafta(int SLSREF, string KATEGORI, int Yil, int Ay, int Hafta)
        {
            int donendeger = 0;

            string tablo = SatisTemsilcileri.GetSATKOD1BySLSREF(SLSREF).StartsWith("8") ? "[Web-Satis-Hedef-Nst]" : "[Web-Satis-Hedef]";

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT count(*) FROM " + tablo + " WHERE SLSREF = @SLSREF AND KATEGORI " + (KATEGORI != "0" ? "= '" + KATEGORI + "'": "IS NOT NULL ") + " AND YIL = @YIL AND AY = @AY AND HF = @HF", conn);
                cmd.Parameters.Add("@SLSREF", SqlDbType.Int).Value = SLSREF;
                cmd.Parameters.Add("@YIL", SqlDbType.Int).Value = Yil;
                cmd.Parameters.Add("@AY", SqlDbType.Int).Value = Ay;
                cmd.Parameters.Add("@HF", SqlDbType.Int).Value = Hafta;
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
        public static void GetObjectsByHafta(DataTable dt, int SLSREF, string KATEGORI, int Yil, int Ay, int Hafta, int Baslangic, int Adet)
        {
            string tablo = SatisTemsilcileri.GetSATKOD1BySLSREF(SLSREF).StartsWith("8") ? "[Web-Satis-Hedef-Nst]" : "[Web-Satis-Hedef]";

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT [BOLGE],[GRUP],[EKP],[SLSREF],[SAT KOD],[SAT TEM],[TARIH],[AY],[AYLAR],[AYGNIS],[HF],[HAFTALAR],[HFGN],[GUN],[KATEGORI],[HD GN],[AD/KL],[AD/KL NT],[SAT GN],[SAT GN NT],[MUST AD],[AY AD],[GN AD],[AY AD NT],[GN AD NT] FROM " + tablo + " WHERE SLSREF = @SLSREF AND KATEGORI " + (KATEGORI != "0" ? "= '" + KATEGORI + "'": "IS NOT NULL ") + " AND YIL = @YIL AND AY = @AY AND HF = @HF ORDER BY TARIH", conn);
                da.SelectCommand.Parameters.Add("@SLSREF", SqlDbType.Int).Value = SLSREF;
                da.SelectCommand.Parameters.Add("@YIL", SqlDbType.Int).Value = Yil;
                da.SelectCommand.Parameters.Add("@AY", SqlDbType.Int).Value = Ay;
                da.SelectCommand.Parameters.Add("@HF", SqlDbType.Int).Value = Hafta;
                try
                {
                    conn.Open();
                    da.Fill(Baslangic, Adet, dt);
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
        public static ArrayList GetToplamlarByHafta(int SLSREF, string KATEGORI, int Yil, int Ay, int Hafta)
        {
            ArrayList donendeger = new ArrayList();

            string tablo = SatisTemsilcileri.GetSATKOD1BySLSREF(SLSREF).StartsWith("8") ? "[Web-Satis-Hedef-Nst]" : "[Web-Satis-Hedef]";

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT sum([HD GN]),sum([SAT GN]),sum([SAT GN NT]) FROM " + tablo + " WHERE [SLSREF] = @SLSREF AND KATEGORI " + (KATEGORI != "0" ? "= '" + KATEGORI + "'": "IS NOT NULL ") + " AND YIL = @YIL AND AY = @AY AND HF = @HF", conn);
                cmd.Parameters.Add("@SLSREF", SqlDbType.Int).Value = SLSREF;
                cmd.Parameters.Add("@YIL", SqlDbType.Int).Value = Yil;
                cmd.Parameters.Add("@AY", SqlDbType.Int).Value = Ay;
                cmd.Parameters.Add("@HF", SqlDbType.Int).Value = Hafta;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        object hedef = dr[0]; object satilan = dr[1]; object satilannet = dr[2];

                        if (hedef != DBNull.Value)
                            donendeger.Add(Convert.ToDecimal(hedef));
                        else
                            donendeger.Add(Convert.ToDecimal(0));

                        if (satilan != DBNull.Value)
                            donendeger.Add(Convert.ToDecimal(satilan));
                        else
                            donendeger.Add(Convert.ToDecimal(0));

                        if (satilannet != DBNull.Value)
                            donendeger.Add(Convert.ToDecimal(satilannet));
                        else
                            donendeger.Add(Convert.ToDecimal(0));
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
        public static void GetHaftalarByAy(ListItemCollection lic, int SLSREF, string KATEGORI, int Yil, int Ay)
        {
            lic.Clear();
            lic.Add(new ListItem("Tümü", "0"));

            string tablo = SatisTemsilcileri.GetSATKOD1BySLSREF(SLSREF).StartsWith("8") ? "[Web-Satis-Hedef-Nst]" : "[Web-Satis-Hedef]";

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT DISTINCT [HF],[HAFTALAR] FROM " + tablo + " WHERE SLSREF = @SLSREF AND KATEGORI " + (KATEGORI != "0" ? "= '" + KATEGORI + "'": "IS NOT NULL ") + " AND YIL = @YIL AND AY = @AY ORDER BY [HF]", conn);
                cmd.Parameters.Add("@SLSREF", SqlDbType.Int).Value = SLSREF;
                cmd.Parameters.Add("@YIL", SqlDbType.Int).Value = Yil;
                cmd.Parameters.Add("@AY", SqlDbType.Int).Value = Ay;
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

        public static int GetObjectCountByGun(int SLSREF, string KATEGORI, int Yil, int Ay, int Hafta, int Gun)
        {
            int donendeger = 0;

            string tablo = SatisTemsilcileri.GetSATKOD1BySLSREF(SLSREF).StartsWith("8") ? "[Web-Satis-Hedef-Nst]" : "[Web-Satis-Hedef]";

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT count(*) FROM " + tablo + " WHERE SLSREF = @SLSREF AND KATEGORI " + (KATEGORI != "0" ? "= '" + KATEGORI + "'": "IS NOT NULL ") + " AND YIL = @YIL AND AY = @AY AND HF = @HF AND HFGN = @HFGN", conn);
                cmd.Parameters.Add("@SLSREF", SqlDbType.Int).Value = SLSREF;
                cmd.Parameters.Add("@YIL", SqlDbType.Int).Value = Yil;
                cmd.Parameters.Add("@AY", SqlDbType.Int).Value = Ay;
                cmd.Parameters.Add("@HF", SqlDbType.Int).Value = Hafta;
                cmd.Parameters.Add("@HFGN", SqlDbType.Int).Value = Gun;
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
        public static void GetObjectsByGun(DataTable dt, int SLSREF, string KATEGORI, int Yil, int Ay, int Hafta, int Gun, int Baslangic, int Adet)
        {
            string tablo = SatisTemsilcileri.GetSATKOD1BySLSREF(SLSREF).StartsWith("8") ? "[Web-Satis-Hedef-Nst]" : "[Web-Satis-Hedef]";

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT [BOLGE],[GRUP],[EKP],[SLSREF],[SAT KOD],[SAT TEM],[TARIH],[AY],[AYLAR],[AYGNIS],[HF],[HAFTALAR],[HFGN],[GUN],[KATEGORI],[HD GN],[AD/KL],[AD/KL NT],[SAT GN],[SAT GN NT],[MUST AD],[AY AD],[GN AD],[AY AD NT],[GN AD NT] FROM " + tablo + " WHERE SLSREF = @SLSREF AND KATEGORI " + (KATEGORI != "0" ? "= '" + KATEGORI + "'": "IS NOT NULL ") + " AND YIL = @YIL AND AY = @AY AND HF = @HF AND HFGN = @HFGN ORDER BY TARIH", conn);
                da.SelectCommand.Parameters.Add("@SLSREF", SqlDbType.Int).Value = SLSREF;
                da.SelectCommand.Parameters.Add("@YIL", SqlDbType.Int).Value = Yil;
                da.SelectCommand.Parameters.Add("@AY", SqlDbType.Int).Value = Ay;
                da.SelectCommand.Parameters.Add("@HF", SqlDbType.Int).Value = Hafta;
                da.SelectCommand.Parameters.Add("@HFGN", SqlDbType.Int).Value = Gun;
                try
                {
                    conn.Open();
                    da.Fill(Baslangic, Adet, dt);
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
        public static ArrayList GetToplamlarByGun(int SLSREF, string KATEGORI, int Yil, int Ay, int Hafta, int Gun)
        {
            ArrayList donendeger = new ArrayList();

            string tablo = SatisTemsilcileri.GetSATKOD1BySLSREF(SLSREF).StartsWith("8") ? "[Web-Satis-Hedef-Nst]" : "[Web-Satis-Hedef]";

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT sum([HD GN]),sum([SAT GN]),sum([SAT GN NT]) FROM " + tablo + " WHERE [SLSREF] = @SLSREF AND KATEGORI " + (KATEGORI != "0" ? "= '" + KATEGORI + "'": "IS NOT NULL ") + " AND YIL = @YIL AND AY = @AY AND HF = @HF AND HFGN = @HFGN", conn);
                cmd.Parameters.Add("@SLSREF", SqlDbType.Int).Value = SLSREF;
                cmd.Parameters.Add("@YIL", SqlDbType.Int).Value = Yil;
                cmd.Parameters.Add("@AY", SqlDbType.Int).Value = Ay;
                cmd.Parameters.Add("@HF", SqlDbType.Int).Value = Hafta;
                cmd.Parameters.Add("@HFGN", SqlDbType.Int).Value = Gun;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        object hedef = dr[0]; object satilan = dr[1]; object satilannet = dr[2];

                        if (hedef != DBNull.Value)
                            donendeger.Add(Convert.ToDecimal(hedef));
                        else
                            donendeger.Add(Convert.ToDecimal(0));

                        if (satilan != DBNull.Value)
                            donendeger.Add(Convert.ToDecimal(satilan));
                        else
                            donendeger.Add(Convert.ToDecimal(0));

                        if (satilannet != DBNull.Value)
                            donendeger.Add(Convert.ToDecimal(satilannet));
                        else
                            donendeger.Add(Convert.ToDecimal(0));
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
        public static void GetGunlerByAyHafta(ListItemCollection lic, int SLSREF, string KATEGORI, int Yil, int Ay, int Hafta)
        {
            lic.Clear();
            lic.Add(new ListItem("Tümü", "0"));

            string tablo = SatisTemsilcileri.GetSATKOD1BySLSREF(SLSREF).StartsWith("8") ? "[Web-Satis-Hedef-Nst]" : "[Web-Satis-Hedef]";

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT [HFGN],[GUN] FROM " + tablo + " WHERE SLSREF = @SLSREF AND KATEGORI " + (KATEGORI != "0" ? "= '" + KATEGORI + "'": "IS NOT NULL ") + " AND YIL = @YIL AND AY = @AY AND HF = @HF ORDER BY [HFGN]", conn);
                cmd.Parameters.Add("@SLSREF", SqlDbType.Int).Value = SLSREF;
                cmd.Parameters.Add("@YIL", SqlDbType.Int).Value = Yil;
                cmd.Parameters.Add("@AY", SqlDbType.Int).Value = Ay;
                cmd.Parameters.Add("@HF", SqlDbType.Int).Value = Hafta;
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
        /// Haftasız ayın günleri datatable da 1. gunden itibaren satır satır geliyor, grafik için yaptık bu fonksiyonu
        /// </summary>
        public static DataTable GetToplamlarGunGunByAy(int SLSREF, string KATEGORI, int Yil, int Ay)
        {
            DataTable donendeger = new DataTable();

            string tablo = SatisTemsilcileri.GetSATKOD1BySLSREF(SLSREF).StartsWith("8") ? "[Web-Satis-Hedef-Nst]" : "[Web-Satis-Hedef]";

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT [HD GN],[AD/KL],[AD/KL NT],[SAT GN],[SAT GN NT] FROM " + tablo + " WHERE [SLSREF] = @SLSREF AND KATEGORI " + (KATEGORI != "0" ? "= '" + KATEGORI + "'" : "IS NOT NULL ") + " AND YIL = @YIL AND AY = @AY ORDER BY [HAFTALAR],[HFGN]", conn);
                da.SelectCommand.Parameters.Add("@SLSREF", SqlDbType.Int).Value = SLSREF;
                da.SelectCommand.Parameters.Add("@YIL", SqlDbType.Int).Value = Yil;
                da.SelectCommand.Parameters.Add("@AY", SqlDbType.Int).Value = Ay;
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
        // }






        // yöneticiler için toplam (sadece grafik gösterimi olacağı için yıl ay yeterli diğerleri gereksiz) {
        public static int GetObjectTCountByYil(string KATEGORI, int Yil)
        {
            int donendeger = 0;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT count(*) FROM [Web-Satis-Hedef] WHERE YIL = @YIL AND KATEGORI " + (KATEGORI != "0" ? "= '" + KATEGORI + "'": "IS NOT NULL "), conn);
                cmd.Parameters.Add("@YIL", SqlDbType.Int).Value = Yil;
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
        public static void GetObjectsTByYil(DataTable dt, string KATEGORI, int Yil, int Baslangic, int Adet)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT [BOLGE],[GRUP],[EKP],[SLSREF],[SAT KOD],[SAT TEM],[TARIH],[AY],[AYLAR],[AYGNIS],[HF],[HAFTALAR],[HFGN],[GUN],[KATEGORI],[HD GN],[AD/KL],[AD/KL NT],[SAT GN],[SAT GN NT],[MUST AD],[AY AD],[GN AD],[AY AD NT],[GN AD NT] FROM [Web-Satis-Hedef] WHERE YIL = @YIL AND KATEGORI " + (KATEGORI != "0" ? "= '" + KATEGORI + "'": "IS NOT NULL ") + " ORDER BY TARIH", conn);
                da.SelectCommand.Parameters.Add("@YIL", SqlDbType.Int).Value = Yil;
                try
                {
                    conn.Open();
                    da.Fill(Baslangic, Adet, dt);
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
        public static ArrayList GetToplamlarTByYil(string KATEGORI, int Yil)
        {
            ArrayList donendeger = new ArrayList();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT sum([HD GN]),sum([SAT GN]),sum([SAT GN NT]) FROM [Web-Satis-Hedef] WHERE YIL = @YIL AND KATEGORI " + (KATEGORI != "0" ? "= '" + KATEGORI + "'": "IS NOT NULL "), conn);
                cmd.Parameters.Add("@YIL", SqlDbType.Int).Value = Yil;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        object hedef = dr[0]; object satilan = dr[1]; object satilannet = dr[2];

                        if (hedef != DBNull.Value)
                            donendeger.Add(Convert.ToDecimal(hedef));
                        else
                            donendeger.Add(Convert.ToDecimal(0));

                        if (satilan != DBNull.Value)
                            donendeger.Add(Convert.ToDecimal(satilan));
                        else
                            donendeger.Add(Convert.ToDecimal(0));

                        if (satilannet != DBNull.Value)
                            donendeger.Add(Convert.ToDecimal(satilannet));
                        else
                            donendeger.Add(Convert.ToDecimal(0));
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
        public static void GetYillarT(ListItemCollection lic, string KATEGORI)
        {
            lic.Clear();
            //lic.Add(new ListItem("Tümü", "0"));

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT DISTINCT [YIL] AS DEGER,[YIL] AS AD FROM [Web-Satis-Hedef] ORDER BY DEGER", conn);
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

        public static int GetObjectTCountByAy(string KATEGORI, int Yil, int Ay)
        {
            int donendeger = 0;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT count(*) FROM [Web-Satis-Hedef] WHERE YIL = @YIL AND KATEGORI " + (KATEGORI != "0" ? "= '" + KATEGORI + "'": "IS NOT NULL ") + " AND AY = @AY", conn);
                cmd.Parameters.Add("@YIL", SqlDbType.Int).Value = Yil;
                cmd.Parameters.Add("@AY", SqlDbType.Int).Value = Ay;
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
        public static void GetObjectsTByAy(DataTable dt, string KATEGORI, int Yil, int Ay, int Baslangic, int Adet)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT [BOLGE],[GRUP],[EKP],[SLSREF],[SAT KOD],[SAT TEM],[TARIH],[AY],[AYLAR],[AYGNIS],[HF],[HAFTALAR],[HFGN],[GUN],[KATEGORI],[HD GN],[AD/KL],[AD/KL NT],[SAT GN],[SAT GN NT],[MUST AD],[AY AD],[GN AD],[AY AD NT],[GN AD NT] FROM [Web-Satis-Hedef] WHERE YIL = @YIL AND KATEGORI " + (KATEGORI != "0" ? "= '" + KATEGORI + "'": "IS NOT NULL ") + " AND AY = @AY ORDER BY TARIH", conn);
                da.SelectCommand.Parameters.Add("@YIL", SqlDbType.Int).Value = Yil;
                da.SelectCommand.Parameters.Add("@AY", SqlDbType.Int).Value = Ay;
                try
                {
                    conn.Open();
                    da.Fill(Baslangic, Adet, dt);
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
        public static ArrayList GetToplamlarTByAy(string KATEGORI, int Yil, int Ay)
        {
            ArrayList donendeger = new ArrayList();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT sum([HD GN]),sum([SAT GN]),sum([SAT GN NT]) FROM [Web-Satis-Hedef] WHERE YIL = @YIL AND KATEGORI " + (KATEGORI != "0" ? "= '" + KATEGORI + "'": "IS NOT NULL ") + " AND AY = @AY", conn);
                cmd.Parameters.Add("@YIL", SqlDbType.Int).Value = Yil;
                cmd.Parameters.Add("@AY", SqlDbType.Int).Value = Ay;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        object hedef = dr[0]; object satilan = dr[1]; object satilannet = dr[2];

                        if (hedef != DBNull.Value)
                            donendeger.Add(Convert.ToDecimal(hedef));
                        else
                            donendeger.Add(Convert.ToDecimal(0));

                        if (satilan != DBNull.Value)
                            donendeger.Add(Convert.ToDecimal(satilan));
                        else
                            donendeger.Add(Convert.ToDecimal(0));

                        if (satilannet != DBNull.Value)
                            donendeger.Add(Convert.ToDecimal(satilannet));
                        else
                            donendeger.Add(Convert.ToDecimal(0));
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
        public static void GetAylarByYilT(ListItemCollection lic, string KATEGORI, int Yil)
        {
            lic.Clear();
            lic.Add(new ListItem("Tümü", "0"));

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT DISTINCT [AY],[AYLAR] FROM [Web-Satis-Hedef] WHERE YIL = @YIL AND KATEGORI " + (KATEGORI != "0" ? "= '" + KATEGORI + "'": "IS NOT NULL ") + " ORDER BY [AY]", conn);
                cmd.Parameters.Add("@YIL", SqlDbType.Int).Value = Yil;
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

        public static int GetObjectTCountByHafta(string KATEGORI, int Yil, int Ay, int Hafta)
        {
            int donendeger = 0;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT count(*) FROM [Web-Satis-Hedef] WHERE YIL = @YIL AND KATEGORI " + (KATEGORI != "0" ? "= '" + KATEGORI + "'": "IS NOT NULL ") + " AND AY = @AY AND HF = @HF", conn);
                cmd.Parameters.Add("@YIL", SqlDbType.Int).Value = Yil;
                cmd.Parameters.Add("@AY", SqlDbType.Int).Value = Ay;
                cmd.Parameters.Add("@HF", SqlDbType.Int).Value = Hafta;
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
        public static void GetObjectsTByHafta(DataTable dt, string KATEGORI, int Yil, int Ay, int Hafta, int Baslangic, int Adet)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT [BOLGE],[GRUP],[EKP],[SLSREF],[SAT KOD],[SAT TEM],[TARIH],[AY],[AYLAR],[AYGNIS],[HF],[HAFTALAR],[HFGN],[GUN],[KATEGORI],[HD GN],[AD/KL],[AD/KL NT],[SAT GN],[SAT GN NT],[MUST AD],[AY AD],[GN AD],[AY AD NT],[GN AD NT] FROM [Web-Satis-Hedef] WHERE YIL = @YIL AND KATEGORI " + (KATEGORI != "0" ? "= '" + KATEGORI + "'": "IS NOT NULL ") + " AND AY = @AY AND HF = @HF ORDER BY TARIH", conn);
                da.SelectCommand.Parameters.Add("@YIL", SqlDbType.Int).Value = Yil;
                da.SelectCommand.Parameters.Add("@AY", SqlDbType.Int).Value = Ay;
                da.SelectCommand.Parameters.Add("@HF", SqlDbType.Int).Value = Hafta;
                try
                {
                    conn.Open();
                    da.Fill(Baslangic, Adet, dt);
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
        public static ArrayList GetToplamlarTByHafta(string KATEGORI, int Yil, int Ay, int Hafta)
        {
            ArrayList donendeger = new ArrayList();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT sum([HD GN]),sum([SAT GN]),sum([SAT GN NT]) FROM [Web-Satis-Hedef] WHERE YIL = @YIL AND KATEGORI " + (KATEGORI != "0" ? "= '" + KATEGORI + "'": "IS NOT NULL ") + " AND AY = @AY AND HF = @HF", conn);
                cmd.Parameters.Add("@YIL", SqlDbType.Int).Value = Yil;
                cmd.Parameters.Add("@AY", SqlDbType.Int).Value = Ay;
                cmd.Parameters.Add("@HF", SqlDbType.Int).Value = Hafta;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        object hedef = dr[0]; object satilan = dr[1]; object satilannet = dr[2];

                        if (hedef != DBNull.Value)
                            donendeger.Add(Convert.ToDecimal(hedef));
                        else
                            donendeger.Add(Convert.ToDecimal(0));

                        if (satilan != DBNull.Value)
                            donendeger.Add(Convert.ToDecimal(satilan));
                        else
                            donendeger.Add(Convert.ToDecimal(0));

                        if (satilannet != DBNull.Value)
                            donendeger.Add(Convert.ToDecimal(satilannet));
                        else
                            donendeger.Add(Convert.ToDecimal(0));
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
        public static void GetHaftalarByAyT(ListItemCollection lic, string KATEGORI, int Yil, int Ay)
        {
            lic.Clear();
            lic.Add(new ListItem("Tümü", "0"));

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT DISTINCT [HF],[HAFTALAR] FROM [Web-Satis-Hedef] WHERE YIL = @YIL AND KATEGORI " + (KATEGORI != "0" ? "= '" + KATEGORI + "'": "IS NOT NULL ") + " AND AY = @AY ORDER BY [HF]", conn);
                cmd.Parameters.Add("@YIL", SqlDbType.Int).Value = Yil;
                cmd.Parameters.Add("@AY", SqlDbType.Int).Value = Ay;
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

        public static int GetObjectTCountByGun(string KATEGORI, int Yil, int Ay, int Hafta, int Gun)
        {
            int donendeger = 0;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT count(*) FROM [Web-Satis-Hedef] WHERE YIL = @YIL AND KATEGORI " + (KATEGORI != "0" ? "= '" + KATEGORI + "'": "IS NOT NULL ") + " AND AY = @AY AND HF = @HF AND HFGN = @HFGN", conn);
                cmd.Parameters.Add("@YIL", SqlDbType.Int).Value = Yil;
                cmd.Parameters.Add("@AY", SqlDbType.Int).Value = Ay;
                cmd.Parameters.Add("@HF", SqlDbType.Int).Value = Hafta;
                cmd.Parameters.Add("@HFGN", SqlDbType.Int).Value = Gun;
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
        public static void GetObjectsTByGun(DataTable dt, string KATEGORI, int Yil, int Ay, int Hafta, int Gun, int Baslangic, int Adet)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT [BOLGE],[GRUP],[EKP],[SLSREF],[SAT KOD],[SAT TEM],[TARIH],[AY],[AYLAR],[AYGNIS],[HF],[HAFTALAR],[HFGN],[GUN],[KATEGORI],[HD GN],[AD/KL],[AD/KL NT],[SAT GN],[SAT GN NT],[MUST AD],[AY AD],[GN AD],[AY AD NT],[GN AD NT] FROM [Web-Satis-Hedef] WHERE YIL = @YIL AND KATEGORI " + (KATEGORI != "0" ? "= '" + KATEGORI + "'": "IS NOT NULL ") + " AND AY = @AY AND HF = @HF AND HFGN = @HFGN ORDER BY TARIH", conn);
                da.SelectCommand.Parameters.Add("@YIL", SqlDbType.Int).Value = Yil;
                da.SelectCommand.Parameters.Add("@AY", SqlDbType.Int).Value = Ay;
                da.SelectCommand.Parameters.Add("@HF", SqlDbType.Int).Value = Hafta;
                da.SelectCommand.Parameters.Add("@HFGN", SqlDbType.Int).Value = Gun;
                try
                {
                    conn.Open();
                    da.Fill(Baslangic, Adet, dt);
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
        public static ArrayList GetToplamlarTByGun(string KATEGORI, int Yil, int Ay, int Hafta, int Gun)
        {
            ArrayList donendeger = new ArrayList();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT sum([HD GN]),sum([SAT GN]),sum([SAT GN NT]) FROM [Web-Satis-Hedef] WHERE YIL = @YIL AND KATEGORI " + (KATEGORI != "0" ? "= '" + KATEGORI + "'": "IS NOT NULL ") + " AND AY = @AY AND HF = @HF AND HFGN = @HFGN", conn);
                cmd.Parameters.Add("@YIL", SqlDbType.Int).Value = Yil;
                cmd.Parameters.Add("@AY", SqlDbType.Int).Value = Ay;
                cmd.Parameters.Add("@HF", SqlDbType.Int).Value = Hafta;
                cmd.Parameters.Add("@HFGN", SqlDbType.Int).Value = Gun;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        object hedef = dr[0]; object satilan = dr[1]; object satilannet = dr[2];

                        if (hedef != DBNull.Value)
                            donendeger.Add(Convert.ToDecimal(hedef));
                        else
                            donendeger.Add(Convert.ToDecimal(0));

                        if (satilan != DBNull.Value)
                            donendeger.Add(Convert.ToDecimal(satilan));
                        else
                            donendeger.Add(Convert.ToDecimal(0));

                        if (satilannet != DBNull.Value)
                            donendeger.Add(Convert.ToDecimal(satilannet));
                        else
                            donendeger.Add(Convert.ToDecimal(0));
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
        public static void GetGunlerByAyHaftaT(ListItemCollection lic, string KATEGORI, int Yil, int Ay, int Hafta)
        {
            lic.Clear();
            lic.Add(new ListItem("Tümü", "0"));

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT [HFGN],[GUN] FROM [Web-Satis-Hedef] WHERE YIL = @YIL AND KATEGORI " + (KATEGORI != "0" ? "= '" + KATEGORI + "'": "IS NOT NULL ") + " AND AY = @AY AND HF = @HF ORDER BY [HFGN]", conn);
                cmd.Parameters.Add("@YIL", SqlDbType.Int).Value = Yil;
                cmd.Parameters.Add("@AY", SqlDbType.Int).Value = Ay;
                cmd.Parameters.Add("@HF", SqlDbType.Int).Value = Hafta;
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
        /// Haftasız ayın günleri datatable da 1. gunden itibaren satır satır geliyor, grafik için yaptık bu fonksiyonu
        /// </summary>
        public static DataTable GetToplamlarTGunGunByAy(string KATEGORI, int Yil, int Ay)
        {
            DataTable donendeger = new DataTable();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT sum([HD GN]),sum([SAT GN]),sum([SAT GN NT]) FROM [Web-Satis-Hedef] WHERE YIL = @YIL AND AY = @AY AND KATEGORI " + (KATEGORI != "0" ? "= '" + KATEGORI + "'": "IS NOT NULL ") + " GROUP BY [HAFTALAR],[HFGN] ORDER BY [HAFTALAR],[HFGN]", conn);
                da.SelectCommand.Parameters.Add("@YIL", SqlDbType.Int).Value = Yil;
                da.SelectCommand.Parameters.Add("@AY", SqlDbType.Int).Value = Ay;
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
        // }






        // şefler için toplam (sadece grafik gösterimi olacağı için yıl ay yeterli) {
        public static int GetObjectTsCountByYil(ArrayList SLSREFs, string KATEGORI, int Yil)
        {
            int donendeger = 0;

            string tablo = SatisTemsilcileri.GetSATKOD1BySLSREF(Convert.ToInt32(SLSREFs[0])).StartsWith("8") ? "[Web-Satis-Hedef-Nst]" : "[Web-Satis-Hedef]";

            string slsrefs = "(";
            for (int i = 0; i < SLSREFs.Count; i++)
			{
                slsrefs += "SLSREF = " + SLSREFs[i].ToString() + " OR ";
            }

            if (slsrefs == "(")
                return 0;
            else
                slsrefs = slsrefs.Substring(0, slsrefs.Length - 4) + ") AND ";


            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT count(*) FROM " + tablo + " WHERE " + slsrefs + " KATEGORI " + (KATEGORI != "0" ? "= '" + KATEGORI + "'": "IS NOT NULL ") + " AND YIL = @YIL", conn);
                cmd.Parameters.Add("@YIL", SqlDbType.Int).Value = Yil;
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
        public static void GetObjectsTsByYil(DataTable dt, ArrayList SLSREFs, string KATEGORI, int Yil, int Baslangic, int Adet)
        {
            string slsrefs = "(";
            for (int i = 0; i < SLSREFs.Count; i++)
            {
                slsrefs += "SLSREF = " + SLSREFs[i].ToString() + " OR ";
            }

            if (slsrefs == "(")
                return;
            else
                slsrefs = slsrefs.Substring(0, slsrefs.Length - 4) + ") AND ";

            string tablo = SatisTemsilcileri.GetSATKOD1BySLSREF(Convert.ToInt32(SLSREFs[0])).StartsWith("8") ? "[Web-Satis-Hedef-Nst]" : "[Web-Satis-Hedef]";

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT [BOLGE],[GRUP],[EKP],[SLSREF],[SAT KOD],[SAT TEM],[TARIH],[AY],[AYLAR],[AYGNIS],[HF],[HAFTALAR],[HFGN],[GUN],[KATEGORI],[HD GN],[AD/KL],[AD/KL NT],[SAT GN],[SAT GN NT],[MUST AD],[AY AD],[GN AD],[AY AD NT],[GN AD NT] FROM " + tablo + " WHERE " + slsrefs + " KATEGORI " + (KATEGORI != "0" ? "= '" + KATEGORI + "'": "IS NOT NULL ") + " AND YIL = @YIL ORDER BY TARIH", conn);
                da.SelectCommand.Parameters.Add("@YIL", SqlDbType.Int).Value = Yil;
                try
                {
                    conn.Open();
                    da.Fill(Baslangic, Adet, dt);
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
        public static ArrayList GetToplamlarTsByYil(ArrayList SLSREFs, string KATEGORI, int Yil)
        {
            ArrayList donendeger = new ArrayList();

            string slsrefs = "(";
            for (int i = 0; i < SLSREFs.Count; i++)
            {
                slsrefs += "SLSREF = " + SLSREFs[i].ToString() + " OR ";
            }

            if (slsrefs == "(")
                return donendeger;
            else
                slsrefs = slsrefs.Substring(0, slsrefs.Length - 4) + ") AND ";

            string tablo = SatisTemsilcileri.GetSATKOD1BySLSREF(Convert.ToInt32(SLSREFs[0])).StartsWith("8") ? "[Web-Satis-Hedef-Nst]" : "[Web-Satis-Hedef]";

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT sum([HD GN]),sum([SAT GN]),sum([SAT GN NT]) FROM " + tablo + " WHERE " + slsrefs + " KATEGORI " + (KATEGORI != "0" ? "= '" + KATEGORI + "'": "IS NOT NULL ") + " AND YIL = @YIL", conn);
                cmd.Parameters.Add("@YIL", SqlDbType.Int).Value = Yil;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        object hedef = dr[0]; object satilan = dr[1]; object satilannet = dr[2];

                        if (hedef != DBNull.Value)
                            donendeger.Add(Convert.ToDecimal(hedef));
                        else
                            donendeger.Add(Convert.ToDecimal(0));

                        if (satilan != DBNull.Value)
                            donendeger.Add(Convert.ToDecimal(satilan));
                        else
                            donendeger.Add(Convert.ToDecimal(0));

                        if (satilannet != DBNull.Value)
                            donendeger.Add(Convert.ToDecimal(satilannet));
                        else
                            donendeger.Add(Convert.ToDecimal(0));
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
        public static void GetYillarTs(ListItemCollection lic, ArrayList SLSREFs, string KATEGORI)
        {
            lic.Clear();
            //lic.Add(new ListItem("Tümü", "0"));

            string slsrefs = "(";
            for (int i = 0; i < SLSREFs.Count; i++)
            {
                slsrefs += "SLSREF = " + SLSREFs[i].ToString() + " OR ";
            }

            if (slsrefs == "(")
                return;
            else
                slsrefs = slsrefs.Substring(0, slsrefs.Length - 4) + ")";

            string tablo = SatisTemsilcileri.GetSATKOD1BySLSREF(Convert.ToInt32(SLSREFs[0])).StartsWith("8") ? "[Web-Satis-Hedef-Nst]" : "[Web-Satis-Hedef]";

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT DISTINCT [YIL] AS DEGER,[YIL] AS AD FROM " + tablo + " WHERE " + slsrefs + " AND KATEGORI " + (KATEGORI != "0" ? "= '" + KATEGORI + "'": "IS NOT NULL ") + " ORDER BY DEGER", conn);
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

        public static int GetObjectTsCountByAy(ArrayList SLSREFs, string KATEGORI, int Yil, int Ay)
        {
            int donendeger = 0;

            string slsrefs = "(";
            for (int i = 0; i < SLSREFs.Count; i++)
            {
                slsrefs += "SLSREF = " + SLSREFs[i].ToString() + " OR ";
            }

            if (slsrefs == "(")
                return 0;
            else
                slsrefs = slsrefs.Substring(0, slsrefs.Length - 4) + ") AND ";

            string tablo = SatisTemsilcileri.GetSATKOD1BySLSREF(Convert.ToInt32(SLSREFs[0])).StartsWith("8") ? "[Web-Satis-Hedef-Nst]" : "[Web-Satis-Hedef]";

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT count(*) FROM " + tablo + " WHERE " + slsrefs + " KATEGORI " + (KATEGORI != "0" ? "= '" + KATEGORI + "'": "IS NOT NULL ") + " AND YIL = @YIL AND AY = @AY", conn);
                cmd.Parameters.Add("@YIL", SqlDbType.Int).Value = Yil;
                cmd.Parameters.Add("@AY", SqlDbType.Int).Value = Ay;
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
        public static void GetObjectsTsByAy(DataTable dt, ArrayList SLSREFs, string KATEGORI, int Yil, int Ay, int Baslangic, int Adet)
        {
            string slsrefs = "(";
            for (int i = 0; i < SLSREFs.Count; i++)
            {
                slsrefs += "SLSREF = " + SLSREFs[i].ToString() + " OR ";
            }

            if (slsrefs == "(")
                return;
            else
                slsrefs = slsrefs.Substring(0, slsrefs.Length - 4) + ") AND ";

            string tablo = SatisTemsilcileri.GetSATKOD1BySLSREF(Convert.ToInt32(SLSREFs[0])).StartsWith("8") ? "[Web-Satis-Hedef-Nst]" : "[Web-Satis-Hedef]";

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT [BOLGE],[GRUP],[EKP],[SLSREF],[SAT KOD],[SAT TEM],[TARIH],[AY],[AYLAR],[AYGNIS],[HF],[HAFTALAR],[HFGN],[GUN],[KATEGORI],[HD GN],[AD/KL],[AD/KL NT],[SAT GN],[SAT GN NT],[MUST AD],[AY AD],[GN AD],[AY AD NT],[GN AD NT] FROM " + tablo + " WHERE " + slsrefs + " KATEGORI " + (KATEGORI != "0" ? "= '" + KATEGORI + "'": "IS NOT NULL ") + " AND YIL = @YIL AND AY = @AY ORDER BY TARIH", conn);
                da.SelectCommand.Parameters.Add("@YIL", SqlDbType.Int).Value = Yil;
                da.SelectCommand.Parameters.Add("@AY", SqlDbType.Int).Value = Ay;
                try
                {
                    conn.Open();
                    da.Fill(Baslangic, Adet, dt);
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
        public static ArrayList GetToplamlarTsByAy(ArrayList SLSREFs, string KATEGORI, int Yil, int Ay)
        {
            ArrayList donendeger = new ArrayList();

            string slsrefs = "(";
            for (int i = 0; i < SLSREFs.Count; i++)
            {
                slsrefs += "SLSREF = " + SLSREFs[i].ToString() + " OR ";
            }

            if (slsrefs == "(")
                return donendeger;
            else
                slsrefs = slsrefs.Substring(0, slsrefs.Length - 4) + ") AND ";

            string tablo = SatisTemsilcileri.GetSATKOD1BySLSREF(Convert.ToInt32(SLSREFs[0])).StartsWith("8") ? "[Web-Satis-Hedef-Nst]" : "[Web-Satis-Hedef]";

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT sum([HD GN]),sum([SAT GN]),sum([SAT GN NT]) FROM " + tablo + " WHERE " + slsrefs + " KATEGORI " + (KATEGORI != "0" ? "= '" + KATEGORI + "'": "IS NOT NULL ") + " AND YIL = @YIL AND AY = @AY", conn);
                cmd.Parameters.Add("@YIL", SqlDbType.Int).Value = Yil;
                cmd.Parameters.Add("@AY", SqlDbType.Int).Value = Ay;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        object hedef = dr[0]; object satilan = dr[1]; object satilannet = dr[2];

                        if (hedef != DBNull.Value)
                            donendeger.Add(Convert.ToDecimal(hedef));
                        else
                            donendeger.Add(Convert.ToDecimal(0));

                        if (satilan != DBNull.Value)
                            donendeger.Add(Convert.ToDecimal(satilan));
                        else
                            donendeger.Add(Convert.ToDecimal(0));

                        if (satilannet != DBNull.Value)
                            donendeger.Add(Convert.ToDecimal(satilannet));
                        else
                            donendeger.Add(Convert.ToDecimal(0));
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
        public static void GetAylarByYilTs(ListItemCollection lic, ArrayList SLSREFs, string KATEGORI, int Yil)
        {
            lic.Clear();
            lic.Add(new ListItem("Tümü", "0"));

            string slsrefs = "(";
            for (int i = 0; i < SLSREFs.Count; i++)
            {
                slsrefs += "SLSREF = " + SLSREFs[i].ToString() + " OR ";
            }

            if (slsrefs == "(")
                return;
            else
                slsrefs = slsrefs.Substring(0, slsrefs.Length - 4) + ") AND ";

            string tablo = SatisTemsilcileri.GetSATKOD1BySLSREF(Convert.ToInt32(SLSREFs[0])).StartsWith("8") ? "[Web-Satis-Hedef-Nst]" : "[Web-Satis-Hedef]";

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT DISTINCT [AY],[AYLAR] FROM " + tablo + " WHERE " + slsrefs + " KATEGORI " + (KATEGORI != "0" ? "= '" + KATEGORI + "'": "IS NOT NULL ") + " AND YIL = @YIL ORDER BY [AY]", conn);
                cmd.Parameters.Add("@YIL", SqlDbType.Int).Value = Yil;
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
        /// Haftasız ayın günleri datatable da 1. gunden itibaren satır satır geliyor, grafik için yaptık bu fonksiyonu
        /// </summary>
        public static DataTable GetToplamlarTsGunGunByAy(ArrayList SLSREFs, string KATEGORI, int Yil, int Ay)
        {
            DataTable donendeger = new DataTable();

            string slsrefs = "(";
            for (int i = 0; i < SLSREFs.Count; i++)
            {
                slsrefs += "SLSREF = " + SLSREFs[i].ToString() + " OR ";
            }

            if (slsrefs == "(")
                return donendeger;
            else
                slsrefs = slsrefs.Substring(0, slsrefs.Length - 4) + ") AND ";

            string tablo = SatisTemsilcileri.GetSATKOD1BySLSREF(Convert.ToInt32(SLSREFs[0])).StartsWith("8") ? "[Web-Satis-Hedef-Nst]" : "[Web-Satis-Hedef]";

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT sum([HD GN]),sum([SAT GN]),sum([SAT GN NT]) FROM " + tablo + " WHERE " + slsrefs + " KATEGORI " + (KATEGORI != "0" ? "= '" + KATEGORI + "'": "IS NOT NULL ") + " AND YIL = @YIL AND AY = @AY AND KATEGORI " + (KATEGORI != "0" ? "= '" + KATEGORI + "'": "IS NOT NULL ") + " GROUP BY [HAFTALAR],[HFGN] ORDER BY [HAFTALAR],[HFGN]", conn);
                da.SelectCommand.Parameters.Add("@YIL", SqlDbType.Int).Value = Yil;
                da.SelectCommand.Parameters.Add("@AY", SqlDbType.Int).Value = Ay;
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
        // }
    }
}

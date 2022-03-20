using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Sultanlar.DatabaseObject.Internet
{
    public class DisVeri
    {
        public int pkID { get; set; }
        public int SMREF { get; set; }
        public string SUNUCU { get; set; }
        public string VERITABANI { get; set; }
        public string KULLANICI { get; set; }
        public string SIFRE { get; set; }
        public string VERISORGU { get; set; }
        public string STOKSORGU { get; set; }
        public string YILKOLON { get; set; }
        public string AYKOLON { get; set; }
        public string YILKOLON1 { get; set; }
        public string AYKOLON1 { get; set; }
        public string VERIXML { get; set; }
        public string STOKXML { get; set; }

        private static bool IsExist(int SMREF)
        {
            bool donendeger = false;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT count(*) FROM [Web-Dis-VeriCekme] WHERE SMREF = @SMREF", conn);
                cmd.Parameters.Add("@SMREF", SqlDbType.Int).Value = SMREF;
                try
                {
                    conn.Open();
                    donendeger = Convert.ToBoolean(cmd.ExecuteScalar());
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

        private static void DoDelete(int SMREF)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM [Web-Dis-VeriCekme] WHERE SMREF = @SMREF", conn);
                cmd.Parameters.Add("@SMREF", SqlDbType.Int).Value = SMREF;
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

        public static int DoInsert(int SMREF, string SUNUCU, string VERITABANI, string KULLANICI, string SIFRE, string VERISORGU, string STOKSORGU, string YILKOLON, string AYKOLON, string YILKOLON1, string AYKOLON1, string VERIXML, string STOKXML)
        {
            int donendeger = 0;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                if (IsExist(SMREF))
                    DoDelete(SMREF);

                SqlCommand cmd = new SqlCommand("INSERT INTO [Web-Dis-VeriCekme] ([SMREF],[SUNUCU],[VERITABANI],[KULLANICI],[SIFRE],[VERISORGU],[STOKSORGU],YILKOLON,AYKOLON,YILKOLON1,AYKOLON1,VERIXML,STOKXML) VALUES (@SMREF,@SUNUCU,@VERITABANI,@KULLANICI,@SIFRE,@VERISORGU,@STOKSORGU,@YILKOLON,@AYKOLON,@YILKOLON1,@AYKOLON1,@VERIXML,@STOKXML)", conn);
                cmd.Parameters.Add("@SMREF", SqlDbType.Int).Value = SMREF;
                cmd.Parameters.Add("@SUNUCU", SqlDbType.NVarChar).Value = SUNUCU;
                cmd.Parameters.Add("@VERITABANI", SqlDbType.NVarChar).Value = VERITABANI;
                cmd.Parameters.Add("@KULLANICI", SqlDbType.NVarChar).Value = KULLANICI;
                cmd.Parameters.Add("@SIFRE", SqlDbType.NVarChar).Value = SIFRE;
                cmd.Parameters.Add("@VERISORGU", SqlDbType.NVarChar).Value = VERISORGU;
                cmd.Parameters.Add("@STOKSORGU", SqlDbType.NVarChar).Value = STOKSORGU;
                cmd.Parameters.Add("@YILKOLON", SqlDbType.NVarChar).Value = YILKOLON;
                cmd.Parameters.Add("@AYKOLON", SqlDbType.NVarChar).Value = AYKOLON;
                cmd.Parameters.Add("@YILKOLON1", SqlDbType.NVarChar).Value = YILKOLON1;
                cmd.Parameters.Add("@AYKOLON1", SqlDbType.NVarChar).Value = AYKOLON1;
                cmd.Parameters.Add("@VERIXML", SqlDbType.NVarChar).Value = VERIXML;
                cmd.Parameters.Add("@STOKXML", SqlDbType.NVarChar).Value = STOKXML;
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

        public static DisVeri GetObject(int SMREF)
        {
            DisVeri donendeger = new DisVeri();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT pkID,[SMREF],[SUNUCU],[VERITABANI],[KULLANICI],[SIFRE],[VERISORGU],[STOKSORGU],YILKOLON,AYKOLON,YILKOLON1,AYKOLON1,VERIXML,STOKXML FROM [Web-Dis-VeriCekme] WHERE SMREF = @SMREF", conn);
                cmd.Parameters.Add("@SMREF", SqlDbType.Int).Value = SMREF;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        donendeger.pkID = Convert.ToInt32(dr[0]);
                        donendeger.SMREF = Convert.ToInt32(dr[1]);
                        donendeger.SUNUCU = dr[2].ToString();
                        donendeger.VERITABANI = dr[3].ToString();
                        donendeger.KULLANICI = dr[4].ToString();
                        donendeger.SIFRE = dr[5].ToString();
                        donendeger.VERISORGU = dr[6].ToString();
                        donendeger.STOKSORGU = dr[7].ToString();
                        donendeger.YILKOLON = dr[8].ToString();
                        donendeger.AYKOLON = dr[9].ToString();
                        donendeger.YILKOLON1 = dr[10].ToString();
                        donendeger.AYKOLON1 = dr[11].ToString();
                        donendeger.VERIXML = dr[12].ToString();
                        donendeger.STOKXML = dr[13].ToString();
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

        public static List<DisVeri> GetObjects()
        {
            List<DisVeri> donendeger = new List<DisVeri>();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT pkID,[SMREF],[SUNUCU],[VERITABANI],[KULLANICI],[SIFRE],[VERISORGU],[STOKSORGU],YILKOLON,AYKOLON,YILKOLON1,AYKOLON1,VERIXML,STOKXML FROM [Web-Dis-VeriCekme]", conn);
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        DisVeri dv = new DisVeri();

                        dv.pkID = Convert.ToInt32(dr[0]);
                        dv.SMREF = Convert.ToInt32(dr[1]);
                        dv.SUNUCU = dr[2].ToString();
                        dv.VERITABANI = dr[3].ToString();
                        dv.KULLANICI = dr[4].ToString();
                        dv.SIFRE = dr[5].ToString();
                        dv.VERISORGU = dr[6].ToString();
                        dv.STOKSORGU = dr[7].ToString();
                        dv.YILKOLON = dr[8].ToString();
                        dv.AYKOLON = dr[9].ToString();
                        dv.YILKOLON1 = dr[10].ToString();
                        dv.AYKOLON1 = dr[11].ToString();
                        dv.VERIXML = dr[12].ToString();
                        dv.STOKXML = dr[13].ToString();

                        donendeger.Add(dv);
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

        public static List<DisVeri> GetObjects(ArrayList bayiler)
        {
            List<DisVeri> donendeger = new List<DisVeri>();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT pkID,[SMREF],[SUNUCU],[VERITABANI],[KULLANICI],[SIFRE],[VERISORGU],[STOKSORGU],YILKOLON,AYKOLON,YILKOLON1,AYKOLON1,VERIXML,STOKXML FROM [Web-Dis-VeriCekme]", conn);
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        for (int i = 0; i < bayiler.Count; i++)
                        {
                            if (Convert.ToInt32(bayiler[i]) == Convert.ToInt32(dr[1]))
                            {
                                DisVeri dv = new DisVeri();

                                dv.pkID = Convert.ToInt32(dr[0]);
                                dv.SMREF = Convert.ToInt32(dr[1]);
                                dv.SUNUCU = dr[2].ToString();
                                dv.VERITABANI = dr[3].ToString();
                                dv.KULLANICI = dr[4].ToString();
                                dv.SIFRE = dr[5].ToString();
                                dv.VERISORGU = dr[6].ToString();
                                dv.STOKSORGU = dr[7].ToString();
                                dv.YILKOLON = dr[8].ToString();
                                dv.AYKOLON = dr[9].ToString();
                                dv.YILKOLON1 = dr[10].ToString();
                                dv.AYKOLON1 = dr[11].ToString();
                                dv.VERIXML = dr[12].ToString();
                                dv.STOKXML = dr[13].ToString();

                                donendeger.Add(dv);
                                break;
                            }
                        }
                    }
                }
                catch (SqlException ex)
                {
                    Hatalar.DoInsert(ex);
                }
            }

            return donendeger;
        }
        /// <summary>
        /// false dönerse sorgu sql hatası var
        /// </summary>
        /// <param name="sorgu"></param>
        /// <returns></returns>
        public static bool ExecNQ(string sorgu)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionStringDisVeri))
            {
                SqlCommand cmd = new SqlCommand(sorgu, conn);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    conn.Close();
                    Hatalar.DoInsert(ex);
                    return false;
                }
                finally
                {
                    conn.Close();
                }
            }

            return true;
        }

        public static object ExecSc(string sorgu)
        {
            object donendeger = 0;

            using (SqlConnection conn = new SqlConnection(General.ConnectionStringDisVeri))
            {
                SqlCommand cmd = new SqlCommand(sorgu, conn);
                try
                {
                    conn.Open();
                    donendeger = cmd.ExecuteScalar();
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
        /// false dönerse sql sorgu hatası var
        /// </summary>
        /// <param name="CommandText"></param>
        /// <param name="ParameterNames"></param>
        /// <param name="Parameters"></param>
        /// <returns></returns>
        public static bool ExecNQwp(string CommandText, ArrayList ParameterNames, object[] Parameters)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionStringDisVeri))
            {
                SqlCommand cmd = new SqlCommand(CommandText, conn);
                for (int i = 0; i < ParameterNames.Count; i++)
                    cmd.Parameters.AddWithValue(ParameterNames[i].ToString(), Parameters[i]);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    conn.Close();
                    Hatalar.DoInsert(ex);
                    return false;
                }
                finally
                {
                    conn.Close();
                }
            }

            return true;
        }

        public static DataTable ExecDaRe(string sorgu)
        {
            DataTable donendeger = new DataTable();

            using (SqlConnection conn = new SqlConnection(General.ConnectionStringDisVeri))
            {
                SqlDataAdapter da = new SqlDataAdapter(sorgu, conn);
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

        public static void TabloOlustur(string tabloadi, DataTable dt)
        {
            string sorgu = "IF OBJECT_ID('" + tabloadi + "', 'U') IS NOT NULL DROP TABLE " + tabloadi +
                           " CREATE TABLE " + tabloadi + " (";

            for (int i = 0; i < dt.Columns.Count; i++)
            {
                sorgu += "[" + dt.Columns[i].ColumnName.Replace("+", "").Replace("-", "").Replace(" ", "").Replace(".", "").Replace("?", "").Replace("!", "") + "] " + VeriDonustur(dt.Columns[i].DataType.Name) + " NULL,";
            }

            sorgu = sorgu.Substring(0, sorgu.Length - 1) + ")";

            ExecNQ(sorgu);
        }

        public static bool TabloYaz(string tabloadi, DataTable dt, string yilad, string yildeger, string ayad, string aydeger)
        {
            bool yenimi = false;
            if (!Convert.ToBoolean(ExecSc("SELECT CASE WHEN OBJECT_ID('" + tabloadi + "', 'U') IS NOT NULL THEN 1 ELSE 0 END"))) // tablo oluşmuş ise
            {
                TabloOlustur(tabloadi, dt);
                yenimi = true;
            }

            return VeriYaz(tabloadi, yenimi, dt, yilad, yildeger, ayad, aydeger);
        }

        public static bool VeriYaz(string tabloadi, bool yeniolustu, DataTable dt1, string yilad, string yildeger, string ayad, string aydeger)
        {
            ArrayList kolonlar = new ArrayList();
            string gelenkolonlar = string.Empty;
            for (int i = 0; i < dt1.Columns.Count; i++)
            {
                kolonlar.Add(dt1.Columns[i].ColumnName.Replace("+", "").Replace("-", "").Replace(" ", "").Replace(".", "").Replace("?", "").Replace("!", ""));
                gelenkolonlar += dt1.Columns[i].ColumnName.Replace("+", "").Replace("-", "").Replace(" ", "").Replace(".", "").Replace("?", "").Replace("!", "") + ",";
            }

            string varolankolonlar = string.Empty;
            if (!yeniolustu) //gelen kolonlar ile yazılmış tablodaki aynı mı kontrol et
            {
                bool hatali = false;
                DataTable dt = ExecDaRe("SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '" + tabloadi + "'");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    varolankolonlar += dt.Rows[i][0].ToString() + ",";
                    if (dt.Rows[i][0].ToString() != kolonlar[i].ToString())
                    {
                        hatali = true;
                    }
                }
                if (hatali)
                {
                    SAPs.LogYaz("bayi servis", true, tabloadi + " gelen veri ile varolan tablo alanları uyumlu değil. Gelen kolonlar: " + gelenkolonlar + " Var olan kolonlar: " + varolankolonlar + " Gelen tablo satır sayısı: " + dt.Rows.Count.ToString(), DateTime.Now, DateTime.Now);
                    return false;
                }
            }

            if (yilad != string.Empty && ayad != string.Empty)
                ExecNQ("DELETE FROM " + tabloadi + " WHERE " + yilad + "=" + yildeger + " AND " + ayad + "=" + aydeger);
            else
                ExecNQ("DELETE FROM " + tabloadi);

            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                string kolonsorgu = string.Empty;
                string eklesorgu = "INSERT INTO " + tabloadi + " (";

                object[] veriler = new object[kolonlar.Count];
                for (int j = 0; j < kolonlar.Count; j++)
                {
                    kolonsorgu += "[" + kolonlar[j] + "],";
                    veriler[j] = dt1.Rows[i][j];
                }

                kolonsorgu = kolonsorgu.Substring(0, kolonsorgu.Length - 1);
                eklesorgu += kolonsorgu + ") VALUES (" + kolonsorgu.Replace("[", "@").Replace("]", "") + ")";

                ExecNQwp(eklesorgu, kolonlar, veriler);
            }

            return true;
        }

        private static string VeriDonustur(string tip)
        {
            string donendeger = string.Empty;

            switch (tip)
            {
                case "Int16":
                    donendeger = "smallint";
                    break;
                case "Int32":
                    donendeger = "int";
                    break;
                case "String":
                    donendeger = "nvarchar(255)";
                    break;
                case "DateTime":
                    donendeger = "datetime";
                    break;
                case "Double":
                    donendeger = "float";
                    break;
                default:
                    break;
            }

            return donendeger;
        }

        public static string XmlParams(string server, string database, string user, string password, string YILAD, string YILDEGER, string AYAD, string AYDEGER)
        {
            string sunucu = "server=" + server + "&";
            string veritabani = "database=" + database + "&";
            string kullanici = "user=" + user + "&";
            string sifre = "password=" + password + "&";
            string paramn = "paramn=" + YILAD + ";" + AYAD + "&";
            string paramv = "paramv=" + YILDEGER + ";" + AYDEGER;
            return sunucu + veritabani + kullanici + sifre + paramn + paramv;
        }

        public static bool BayiServis(string YIL, string AY, bool satis, ArrayList bayiler)
        {
            bool donendeger = true;

            List<DisVeri> dvl = bayiler.Count == 0 ? GetObjects() : GetObjects(bayiler);
            foreach (DisVeri dv in dvl)
            {
                if (dv.SUNUCU != string.Empty && dv.VERITABANI != string.Empty && dv.KULLANICI != string.Empty && dv.SIFRE != string.Empty
                    && ((satis && dv.VERISORGU != string.Empty) || (!satis && dv.STOKSORGU != string.Empty)))
                {
                    DateTime baslangic = DateTime.Now;

                    SqlConnection conn = new SqlConnection("Server=" + dv.SUNUCU + "; Database=" + dv.VERITABANI + "; User Id=" + dv.KULLANICI + "; Password=" + dv.SIFRE + "; Trusted_Connection=False;");
                    SqlDataAdapter da = new SqlDataAdapter("", conn);
                    string sorgu = satis ? dv.VERISORGU : dv.STOKSORGU;
                    da.SelectCommand.CommandText = "SELECT * FROM (" + sorgu + ") AS TABLO" + (satis ? " WHERE " + dv.YILKOLON + "=" + YIL + " AND " + dv.AYKOLON + "=" + AY : "");
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    string tabloadi = "tbl_" + dv.SMREF.ToString() + (satis ? "_Satis" : "_Stok");
                    if (!TabloYaz(tabloadi, dt, satis ? dv.YILKOLON : dv.YILKOLON1, YIL, satis ? dv.AYKOLON : dv.AYKOLON1, AY))
                        donendeger = false;

                    SAPs.LogYaz("bayi servis sql " + (satis ? "satış" : "stok"), true, dv.SMREF.ToString() + " nolu bayi " + YIL + "-" + AY + " dönemi. Gelen satır: " + dt.Rows.Count.ToString(), baslangic, DateTime.Now);
                }
            }

            return donendeger;
        }

        public static bool BayiServisXML(string YIL, string AY, bool satis, ArrayList bayiler)
        {
            bool donendeger = true;

            List<DisVeri> dvl = bayiler.Count == 0 ? GetObjects() : GetObjects(bayiler);
            foreach (DisVeri dv in dvl)
            {
                if (dv.SUNUCU != string.Empty && dv.VERITABANI != string.Empty && dv.KULLANICI != string.Empty && dv.SIFRE != string.Empty
                    && ((satis && dv.VERIXML != string.Empty) || (!satis && dv.STOKXML != string.Empty)))
                {
                    DateTime baslangic = DateTime.Now;

                    System.Xml.XmlReader xmlFile;
                    xmlFile = System.Xml.XmlReader.Create((satis ? dv.VERIXML : dv.STOKXML) + "&" + 
                        XmlParams(dv.SUNUCU, dv.VERITABANI, dv.KULLANICI, dv.SIFRE, (satis ? dv.YILKOLON : dv.YILKOLON1), YIL, (satis ? dv.AYKOLON : dv.AYKOLON1), AY), new System.Xml.XmlReaderSettings());
                    DataSet ds = new DataSet("tbl_");
                    ds.ReadXml(xmlFile);
                    DataTable dt = ds.Tables[0];

                    string tabloadi = "tbl_" + dv.SMREF.ToString() + (satis ? "_Satis" : "_Stok");
                    if (!TabloYaz(tabloadi, dt, satis ? dv.YILKOLON : dv.YILKOLON1, YIL, satis ? dv.AYKOLON : dv.AYKOLON1, AY))
                        donendeger = false;

                    SAPs.LogYaz("bayi servis xml " + (satis ? "satış" : "stok"), true, dv.SMREF.ToString() + " nolu bayi " + YIL + "-" + AY + " dönemi. Gelen satır: " + dt.Rows.Count.ToString(), baslangic, DateTime.Now);
                }
            }

            return donendeger;
        }
    }
}

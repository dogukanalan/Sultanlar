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
    public class Malzeme2
    {
        public int AP { get; set; }
        public int ITEMREF { get; set; }
        public string MALKOD { get; set; }
        public string MALACIK { get; set; }
        public string URTKOD { get; set; }
        public string ESKOD { get; set; }
        public string BIRIMREF { get; set; }
        public string BIRIM { get; set; }
        public string GRUPKOD { get; set; }
        public string GRUPACIK { get; set; }
        public string OZELKOD { get; set; }
        public string HK { get; set; }
        public string OZELACIK { get; set; }
        public string REYKOD { get; set; }
        public string RK { get; set; }
        public string REYACIK { get; set; }
        public double KDV { get; set; }
        public double KOLI { get; set; }
        public string BARKOD { get; set; }
        public double STOK { get; set; }
        public int KYTM { get; set; }
        public int KANAL { get; set; }
        public int PRIMT { get; set; }
        public int PRIMB { get; set; }
        public string HYRS { get; set; }
        public string HYRS_TANIM { get; set; }
        public int DONUSUM { get; set; }
        public int MHDHB { get; set; }
        public int MHDRZ { get; set; }

        public Malzeme2()
        { }

        public Malzeme2(int AP, int ITEMREF, string MALKOD, string MALACIK, string URTKOD, string ESKOD, string BIRIMREF, string BIRIM, string GRUPKOD, string GRUPACIK, string OZELKOD, string HK, string OZELACIK, string REYKOD, string RK, string REYACIK, double KDV, double KOLI, string BARKOD, double STOK, int KYTM, int KANAL, int PRIMT, int PRIMB, string HYRS, string HYRS_TANIM, int DONUSUM, int MHDHB, int MHDRZ)
        {
            this.AP = AP;
            this.ITEMREF = ITEMREF;
            this.MALKOD = MALKOD;
            this.MALACIK = MALACIK;
            this.URTKOD = URTKOD;
            this.ESKOD = ESKOD;
            this.BIRIMREF = BIRIMREF;
            this.BIRIM = BIRIM;
            this.GRUPKOD = GRUPKOD;
            this.GRUPACIK = GRUPACIK;
            this.OZELKOD = OZELKOD;
            this.HK = HK;
            this.OZELACIK = OZELACIK;
            this.REYKOD = REYKOD;
            this.RK = RK;
            this.REYACIK = REYACIK;
            this.KDV = KDV;
            this.KOLI = KOLI;
            this.BARKOD = BARKOD;
            this.STOK = STOK;
            this.KYTM = KYTM;
            this.KANAL = KANAL;
            this.PRIMT = PRIMT;
            this.PRIMB = PRIMB;
            this.HYRS = HYRS;
            this.HYRS_TANIM = HYRS_TANIM;
            this.DONUSUM = DONUSUM;
            this.MHDHB = MHDHB;
            this.MHDRZ = MHDRZ;
        }

        public override string ToString()
        {
            return MALACIK;
        }

        public void DoInsert()
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO [Web-Malzeme-2] ([AP],[MAL KOD],[MAL ACIK],[URT KOD],[ES KOD],[BIRIMREF],[BIRIM],[GRUP KOD],[GRUP ACIK],[OZEL KOD],[HK],[OZEL ACIK],[REY KOD],[RK],[REY ACIK],[KDV],[KOLI],[BARKOD],[STOK],[KYTM],[KANAL],[PRIMT],[PRIMB],[HYRS],[HYRS_TANIM],[DONUSUM],[MHDHB],[MHDRZ]) VALUES (@AP, @MALKOD, @MALACIK, @URTKOD, @ESKOD, @BIRIMREF, @BIRIM, @GRUPKOD, @GRUPACIK, @OZELKOD, @HK, @OZELACIK, @REYKOD, @RK, @REYACIK, @KDV, @KOLI, @BARKOD, @STOK, @KYTM, @KANAL, @PRIMT, @PRIMB, @HYRS, @HYRS_TANIM, @DONUSUM, @MHDHB, @MHDRZ) SELECT @ITEMREF = SCOPE_IDENTITY", conn);
                cmd.Parameters.Add("@AP", SqlDbType.Int).Value = this.AP;
                cmd.Parameters.Add("@MALKOD", SqlDbType.NVarChar).Value = this.MALKOD;
                cmd.Parameters.Add("@MALACIK", SqlDbType.NVarChar).Value = this.MALACIK;
                cmd.Parameters.Add("@URTKOD", SqlDbType.NVarChar).Value = this.URTKOD;
                cmd.Parameters.Add("@ESKOD", SqlDbType.NVarChar).Value = this.ESKOD;
                cmd.Parameters.Add("@BIRIMREF", SqlDbType.NVarChar).Value = this.BIRIMREF;
                cmd.Parameters.Add("@BIRIM", SqlDbType.NVarChar).Value = this.BIRIM;
                cmd.Parameters.Add("@GRUPKOD", SqlDbType.NVarChar).Value = this.GRUPKOD;
                cmd.Parameters.Add("@GRUPACIK", SqlDbType.NVarChar).Value = this.GRUPACIK;
                cmd.Parameters.Add("@OZELKOD", SqlDbType.NVarChar).Value = this.OZELKOD;
                cmd.Parameters.Add("@HK", SqlDbType.NVarChar).Value = this.HK;
                cmd.Parameters.Add("@OZELACIK", SqlDbType.NVarChar).Value = this.OZELACIK;
                cmd.Parameters.Add("@REYKOD", SqlDbType.NVarChar).Value = this.REYKOD;
                cmd.Parameters.Add("@RK", SqlDbType.NVarChar).Value = this.RK;
                cmd.Parameters.Add("@REYACIK", SqlDbType.NVarChar).Value = this.REYACIK;
                cmd.Parameters.Add("@KDV", SqlDbType.Float).Value = this.KDV;
                cmd.Parameters.Add("@KOLI", SqlDbType.Float).Value = this.KOLI;
                cmd.Parameters.Add("@BARKOD", SqlDbType.NVarChar).Value = this.BARKOD;
                cmd.Parameters.Add("@STOK", SqlDbType.Float).Value = this.STOK;
                cmd.Parameters.Add("@KYTM", SqlDbType.Int).Value = this.KYTM;
                cmd.Parameters.Add("@KANAL", SqlDbType.Int).Value = this.KANAL;
                cmd.Parameters.Add("@PRIMB", SqlDbType.Int).Value = this.PRIMB;
                cmd.Parameters.Add("@PRIMT", SqlDbType.Int).Value = this.PRIMT;
                cmd.Parameters.Add("@HYRS", SqlDbType.NVarChar).Value = this.HYRS;
                cmd.Parameters.Add("@HYRS_TANIM", SqlDbType.NVarChar).Value = this.HYRS_TANIM;
                cmd.Parameters.Add("@DONUSUM", SqlDbType.Int).Value = this.DONUSUM;
                cmd.Parameters.Add("@MHDHB", SqlDbType.Int).Value = this.MHDHB;
                cmd.Parameters.Add("@MHDRZ", SqlDbType.Int).Value = this.MHDRZ;
                cmd.Parameters.Add("@ITEMREF", SqlDbType.Int).Direction = ParameterDirection.Output;
                try
                {
                    conn.Open();
                    this.ITEMREF = Convert.ToInt32(cmd.ExecuteScalar());
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
                SqlCommand cmd = new SqlCommand("UPDATE [dbo].[Web-Malzeme-2] SET [AP] = @AP,[MAL KOD] = @MALKOD,[MAL ACIK] = @MALACIK,[URT KOD] = @URTKOD,[ES KOD] = @ESKOD,[BIRIMREF] = @BIRIMREF,[BIRIM] = @BIRIM,[GRUP KOD] = @GRUPKOD,[GRUP ACIK] = @GRUPACIK,[OZEL KOD] = @OZELKOD,[HK] = @HK,[OZEL ACIK] = @OZELACIK,[REY KOD] = @REYKOD,[RK] = @RK,[REY ACIK] = @REYACIK,[KDV] = @KDV,[KOLI] = @KOLI,[BARKOD] = @BARKOD,[STOK] = @STOK,[KYTM] = @KYTM,[KANAL] = @KANAL,[PRIMT] = @PRIMT,[PRIMB] = @PRIMB,[HYRS] = @HYRS,[HYRS_TANIM] = @HYRS_TANIM,[DONUSUM] = @DONUSUM,[MHDHB] = @MHDHB,[MHDRZ] = @MHDRZ WHERE ITEMREF = @ITEMREF", conn);
                cmd.Parameters.Add("@AP", SqlDbType.Int).Value = this.AP;
                cmd.Parameters.Add("@MALKOD", SqlDbType.NVarChar).Value = this.MALKOD;
                cmd.Parameters.Add("@MALACIK", SqlDbType.NVarChar).Value = this.MALACIK;
                cmd.Parameters.Add("@URTKOD", SqlDbType.NVarChar).Value = this.URTKOD;
                cmd.Parameters.Add("@ESKOD", SqlDbType.NVarChar).Value = this.ESKOD;
                cmd.Parameters.Add("@BIRIMREF", SqlDbType.NVarChar).Value = this.BIRIMREF;
                cmd.Parameters.Add("@BIRIM", SqlDbType.NVarChar).Value = this.BIRIM;
                cmd.Parameters.Add("@GRUPKOD", SqlDbType.NVarChar).Value = this.GRUPKOD;
                cmd.Parameters.Add("@GRUPACIK", SqlDbType.NVarChar).Value = this.GRUPACIK;
                cmd.Parameters.Add("@OZELKOD", SqlDbType.NVarChar).Value = this.OZELKOD;
                cmd.Parameters.Add("@HK", SqlDbType.NVarChar).Value = this.HK;
                cmd.Parameters.Add("@OZELACIK", SqlDbType.NVarChar).Value = this.OZELACIK;
                cmd.Parameters.Add("@REYKOD", SqlDbType.NVarChar).Value = this.REYKOD;
                cmd.Parameters.Add("@RK", SqlDbType.NVarChar).Value = this.RK;
                cmd.Parameters.Add("@REYACIK", SqlDbType.NVarChar).Value = this.REYACIK;
                cmd.Parameters.Add("@KDV", SqlDbType.Float).Value = this.KDV;
                cmd.Parameters.Add("@KOLI", SqlDbType.Float).Value = this.KOLI;
                cmd.Parameters.Add("@BARKOD", SqlDbType.NVarChar).Value = this.BARKOD;
                cmd.Parameters.Add("@STOK", SqlDbType.Float).Value = this.STOK;
                cmd.Parameters.Add("@KYTM", SqlDbType.Int).Value = this.KYTM;
                cmd.Parameters.Add("@KANAL", SqlDbType.Int).Value = this.KANAL;
                cmd.Parameters.Add("@PRIMB", SqlDbType.Int).Value = this.PRIMB;
                cmd.Parameters.Add("@PRIMT", SqlDbType.Int).Value = this.PRIMT;
                cmd.Parameters.Add("@HYRS", SqlDbType.NVarChar).Value = this.HYRS;
                cmd.Parameters.Add("@HYRS_TANIM", SqlDbType.NVarChar).Value = this.HYRS_TANIM;
                cmd.Parameters.Add("@DONUSUM", SqlDbType.Int).Value = this.DONUSUM;
                cmd.Parameters.Add("@MHDHB", SqlDbType.Int).Value = this.MHDHB;
                cmd.Parameters.Add("@MHDRZ", SqlDbType.Int).Value = this.MHDRZ;
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

        public void DoDelete()
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM [Web-Malzeme-2] WHERE ITEMREF = @ITEMREF", conn);
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

        public static void GetObjects(DataTable dt)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT [AP],[MAL KOD],[MAL ACIK],[URT KOD],[ES KOD],[BIRIMREF],[BIRIM],[GRUP KOD],[GRUP ACIK],[OZEL KOD],[HK],[OZEL ACIK],[REY KOD],[RK],[REY ACIK],[KDV],[KOLI],[BARKOD],[STOK],[KYTM],[KANAL],[PRIMT],[PRIMB],[HYRS],[HYRS_TANIM],[DONUSUM],[MHDHB],[MHDRZ] FROM [Web-Malzeme-2] ORDER BY [MAL ACIK]", conn);
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

        public static Malzeme2 GetObject(int ITEMREF)
        {
            Malzeme2 donendeger = new Malzeme2();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT [AP],[MAL KOD],[MAL ACIK],[URT KOD],[ES KOD],[BIRIMREF],[BIRIM],[GRUP KOD],[GRUP ACIK],[OZEL KOD],[HK],[OZEL ACIK],[REY KOD],[RK],[REY ACIK],[KDV],[KOLI],[BARKOD],[STOK],[KYTM],[KANAL],[PRIMT],[PRIMB],[HYRS],[HYRS_TANIM],[DONUSUM],[MHDHB],[MHDRZ] FROM [Web-Malzeme-2] WHERE ITEMREF = @ITEMREF", conn);
                cmd.Parameters.Add("@ITEMREF", SqlDbType.Int).Value = ITEMREF;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        donendeger = new Malzeme2(
                            Convert.ToInt32(dr[0]),
                            Convert.ToInt32(dr[1]),
                            dr[2].ToString(),
                            dr[3].ToString(),
                            dr[4].ToString(),
                            dr[5].ToString(),
                            dr[6].ToString(),
                            dr[7].ToString(),
                            dr[8].ToString(),
                            dr[9].ToString(),
                            dr[10].ToString(),
                            dr[11].ToString(),
                            dr[12].ToString(),
                            dr[13].ToString(),
                            dr[14].ToString(),
                            dr[15].ToString(),
                            Convert.ToDouble(dr[16]),
                            Convert.ToDouble(dr[17]),
                            dr[18].ToString(),
                            Convert.ToDouble(dr[19]),
                            Convert.ToInt32(dr[20]),
                            Convert.ToInt32(dr[21]),
                            Convert.ToInt32(dr[22]),
                            Convert.ToInt32(dr[23]),
                            dr[24].ToString(),
                            dr[25].ToString(),
                            Convert.ToInt32(dr[26]),
                            Convert.ToInt32(dr[27]),
                            Convert.ToInt32(dr[28]));
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

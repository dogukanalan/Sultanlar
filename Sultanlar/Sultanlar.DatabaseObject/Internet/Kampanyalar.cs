using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Collections;
using System.Web.UI.WebControls;

namespace Sultanlar.DatabaseObject.Internet
{
    public class Kampanyalar
    {
        /// <summary>
        /// [Web-Kampanya-1] Sadece fiyat tipi filtreli bütün kampanyalar
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="FiyatTipi">Kampanya tablosunda fiyattipi int</param>
        public static void GetObjects(DataTable dt, short FiyatTipi)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT [KAMKARTREF], [KAMPNO], [FIYAT_TIPI], [ACIKLAMA], [ONCELIK], [BASLANGIC_TARIHI], [BITIS_TARIHI], " +
                    "[KAMP.NET+KDV] AS FIYAT, [HED.NET+KDV] AS HEDIYE, [ISK-%] AS ISKONTO, [KurumsalWebSAP].dbo.[Web-Kampanya-1].[KYTK] FROM [KurumsalWebSAP].dbo.[Web-Kampanya-1] WHERE [FIYAT_TIPI] = @FiyatTipi", conn);
                da.SelectCommand.Parameters.Add("@FiyatTipi", SqlDbType.Int).Value = FiyatTipi;
                da.SelectCommand.CommandTimeout = 200;
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
        /// <summary>
        /// [Web-Kampanya-1] [Web-Kampanya-2]
        /// </summary>
        public static void GetObjects(DataTable dt, short FiyatTipi, string UrunAdi, string TedarikciID, string TedarikciOperator,
            string KategoriID, string KategoriOperator, ArrayList OzelKodlar, ArrayList GrupKodlar, bool Yeni)
        {
            string ozelkodlar = string.Empty;
            string grupkodlar = string.Empty;

            for (int i = 0; i < OzelKodlar.Count; i++)
                ozelkodlar += "[KurumsalWebSAP].dbo.[Web-Kampanya-2].[OZEL KOD] = '" + OzelKodlar[i].ToString() + "' OR ";

            if (OzelKodlar.Count > 0)
                ozelkodlar = "(" + ozelkodlar.Substring(0, ozelkodlar.Length - 4) + ") AND ";

            for (int i = 0; i < GrupKodlar.Count; i++)
                grupkodlar += "[KurumsalWebSAP].dbo.[Web-Kampanya-2].[GRUP KOD] = '" + GrupKodlar[i].ToString() + "' OR ";

            if (GrupKodlar.Count > 0)
                grupkodlar = "(" + grupkodlar.Substring(0, grupkodlar.Length - 4) + ") AND ";

            string YeniKampanyalar = string.Empty;
            if (Yeni)
                YeniKampanyalar = " AND [KurumsalWebSAP].dbo.[Web-Kampanya-1].[KYTK] < 16";



            string Aranan = UrunAdi.ToUpper().Replace("İ", "I").Replace("Ü", "U").Replace("Ö", "O").Replace("Ş", "S").Replace("Ç", "C").Replace("Ğ", "G");

            string malacik = string.Empty;
            string[] aramakelimeler = Aranan.Split(new string[] { " " }, StringSplitOptions.None);

            for (int i = 0; i < aramakelimeler.Length; i++)
                malacik += "[KurumsalWebSAP].dbo.[Web-Kampanya-2].[MAL ACIK] LIKE '%" + aramakelimeler[i] + "%' AND ";



            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT [KurumsalWebSAP].dbo.[Web-Kampanya-1].[KAMKARTREF], [KurumsalWebSAP].dbo.[Web-Kampanya-1].[KAMPNO], [KurumsalWebSAP].dbo.[Web-Kampanya-2].[ITEMREF], " +
                    "[KurumsalWebSAP].dbo.[Web-Kampanya-2].[OZEL KOD], [KurumsalWebSAP].dbo.[Web-Kampanya-2].[REY KOD], [KurumsalWebSAP].dbo.[Web-Kampanya-1].[FIYAT_TIPI], [KurumsalWebSAP].dbo.[Web-Kampanya-1].[ACIKLAMA], " + 
                    "[KurumsalWebSAP].dbo.[Web-Kampanya-1].[ONCELIK], [KurumsalWebSAP].dbo.[Web-Kampanya-1].[BASLANGIC_TARIHI], [KurumsalWebSAP].dbo.[Web-Kampanya-1].[BITIS_TARIHI], " + 
                    "[KurumsalWebSAP].dbo.[Web-Kampanya-1].[KAMP.NET+KDV] AS FIYAT, [KurumsalWebSAP].dbo.[Web-Kampanya-1].[HED.NET+KDV] AS HEDIYE, " +
                    "[KurumsalWebSAP].dbo.[Web-Kampanya-1].[ISK-%] AS ISKONTO, [KurumsalWebSAP].dbo.[Web-Kampanya-1].[KYTK] FROM [KurumsalWebSAP].dbo.[Web-Kampanya-1] INNER JOIN [KurumsalWebSAP].dbo.[Web-Kampanya-2] ON " +
                    "[KurumsalWebSAP].dbo.[Web-Kampanya-1].[KAMKARTREF] = [KurumsalWebSAP].dbo.[Web-Kampanya-2].[KAMKARTREF] " +
                    "WHERE [KurumsalWebSAP].dbo.[Web-Kampanya-1].[FIYAT_TIPI] = @FiyatTipi AND " +
                    malacik +
                    ozelkodlar + grupkodlar +
                    "[KurumsalWebSAP].dbo.[Web-Kampanya-2].[OZEL KOD] " + TedarikciOperator + " " + TedarikciID +
                    " AND [KurumsalWebSAP].dbo.[Web-Kampanya-2].[REY KOD] " + KategoriOperator + " " + KategoriID + YeniKampanyalar +
                    " ORDER BY [KurumsalWebSAP].dbo.[Web-Kampanya-1].[ACIKLAMA]", conn);
                da.SelectCommand.Parameters.Add("@FiyatTipi", SqlDbType.SmallInt).Value = Convert.ToInt16(FiyatTipi);
                da.SelectCommand.CommandTimeout = 200;
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
        /// <summary>
        /// [Web-Kampanya-1] [Web-Kampanya-2]
        /// </summary>
        public static void GetObjectsByUrunID(DataTable dt, int UrunID, int FiyatTipi)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT [KurumsalWebSAP].dbo.[Web-Kampanya-1].[KAMKARTREF],[KurumsalWebSAP].dbo.[Web-Kampanya-1].[KAMPNO],[KurumsalWebSAP].dbo.[Web-Kampanya-1].[FIYAT_TIPI],[KurumsalWebSAP].dbo.[Web-Kampanya-1].[ACIKLAMA],[KurumsalWebSAP].dbo.[Web-Kampanya-1].[ONCELIK],[KurumsalWebSAP].dbo.[Web-Kampanya-1].[BASLANGIC_TARIHI],[KurumsalWebSAP].dbo.[Web-Kampanya-1].[BITIS_TARIHI],[KurumsalWebSAP].dbo.[Web-Kampanya-1].[KAMP.NET+KDV] AS FIYAT,[KurumsalWebSAP].dbo.[Web-Kampanya-1].[HED.NET+KDV] AS HEDIYE,[KurumsalWebSAP].dbo.[Web-Kampanya-1].[ISK-%] AS ISKONTO, [KurumsalWebSAP].dbo.[Web-Kampanya-1].[KYTK] FROM [KurumsalWebSAP].dbo.[Web-Kampanya-1] INNER JOIN [KurumsalWebSAP].dbo.[Web-Kampanya-2] ON [KurumsalWebSAP].dbo.[Web-Kampanya-1].[KAMKARTREF] = [KurumsalWebSAP].dbo.[Web-Kampanya-2].[KAMKARTREF] " + 
                    "WHERE [KurumsalWebSAP].dbo.[Web-Kampanya-2].[ITEMREF] = @UrunID AND [KurumsalWebSAP].dbo.[Web-Kampanya-1].[FIYAT_TIPI] = @FiyatTipi", conn);
                da.SelectCommand.Parameters.Add("@UrunID", SqlDbType.Int).Value = UrunID;
                da.SelectCommand.Parameters.Add("@FiyatTipi", SqlDbType.Int).Value = FiyatTipi;
                da.SelectCommand.CommandTimeout = 200;
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
        /// <summary>
        /// [Web-Malzeme] [Web-Kampanya-2]
        /// </summary>
        public static void GetAnaUrunlerByUrunID(DataTable dt, int UrunID, short FiyatTipi)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT [KurumsalWebSAP].dbo.[Web-Kampanya-2].[KAMKARTREF], [KurumsalWebSAP].dbo.[Web-Kampanya-2].[KAMPNO], [KurumsalWebSAP].dbo.[Web-Kampanya-2].[KAMPANASATREF], [KurumsalWebSAP].dbo.[Web-Kampanya-2].[TIP], [KurumsalWebSAP].dbo.[Web-Kampanya-2].[ITEMREF], [KurumsalWebSAP].dbo.[Web-Kampanya-2].[MIKTAR], [KurumsalWebSAP].dbo.[Web-Kampanya-2].[KAMP.NET+KDV] AS Fiyat, [KurumsalWebSAP].dbo.[Web-Malzeme].[MAL ACIK], [KurumsalWebSAP].dbo.[Web-Malzeme].[OZEL KOD], [KurumsalWebSAP].dbo.[Web-Malzeme].[OZEL ACIK], [KurumsalWebSAP].dbo.[Web-Malzeme].[REY KOD], [KurumsalWebSAP].dbo.[Web-Malzeme].[REY ACIK], [KurumsalWebSAP].dbo.[Web-Malzeme].[KOLI] FROM [KurumsalWebSAP].dbo.[Web-Kampanya-2] INNER JOIN [KurumsalWebSAP].dbo.[Web-Malzeme] ON [KurumsalWebSAP].dbo.[Web-Kampanya-2].[ITEMREF] = [KurumsalWebSAP].dbo.[Web-Malzeme].[ITEMREF] WHERE [KurumsalWebSAP].dbo.[Web-Kampanya-2].[ITEMREF] = @ITEMREF AND [KurumsalWebSAP].dbo.[Web-Kampanya-2].[TIP] = @TIP", conn);
                da.SelectCommand.Parameters.Add("@ITEMREF", SqlDbType.Int).Value = UrunID;
                da.SelectCommand.Parameters.Add("@TIP", SqlDbType.SmallInt).Value = FiyatTipi;
                da.SelectCommand.CommandTimeout = 200;
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
        /// <summary>
        /// [Web-Kampanya-2]
        /// </summary>
        public static void GetAnaUrunler(DataTable dt, Guid kamkartref)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT [KAMKARTREF],[KAMPNO],[KAMPANASATREF],[TIP],[ITEMREF],[MIKTAR],[KAMP.NET+KDV] AS Fiyat,[MAL ACIK],[OZEL KOD],[OZEL ACIK],[REY KOD],[REY ACIK],[KOLI] FROM [KurumsalWebSAP].dbo.[Web-Kampanya-2] WHERE [KAMKARTREF] = @KAMKARTREF", conn);
                da.SelectCommand.Parameters.Add("@KAMKARTREF", SqlDbType.UniqueIdentifier).Value = kamkartref;
                da.SelectCommand.CommandTimeout = 200;
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
        /// <summary>
        /// [Web-Kampanya-3]
        /// </summary>
        public static void GetHediyeUrunler(DataTable dt, Guid kamkartref)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT [KAMKARTREF],[KAMPNO],[KAMPHEDSATREF],[TIP],[ITEMREF],[MIKTAR],[HED.NET+KDV] AS Fiyat,[MAL ACIK],[OZEL KOD],[OZEL ACIK],[REY KOD],[REY ACIK],[KOLI] FROM [KurumsalWebSAP].dbo.[Web-Kampanya-3] WHERE [KAMKARTREF] = @KAMKARTREF", conn);
                da.SelectCommand.Parameters.Add("@KAMKARTREF", SqlDbType.UniqueIdentifier).Value = kamkartref;
                da.SelectCommand.CommandTimeout = 200;
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
        /// <summary>
        /// [Web-Kampanya-2]
        /// </summary>
        public static void GetAnaUrunlerForKampanyaDoInsert(DataTable dt, Guid kamkartref)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT [KAMKARTREF],[KAMPNO],[KAMPANASATREF],[TIP],[ITEMREF],[MIKTAR] FROM [KurumsalWebSAP].dbo.[Web-Kampanya-2] WHERE [KAMKARTREF] = @KAMKARTREF", conn);
                da.SelectCommand.Parameters.Add("@KAMKARTREF", SqlDbType.UniqueIdentifier).Value = kamkartref;
                da.SelectCommand.CommandTimeout = 200;
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
        /// <summary>
        /// [Web-Kampanya-3]
        /// </summary>
        public static void GetHediyeUrunlerForKampanyaDoInsert(DataTable dt, Guid kamkartref)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT [KAMKARTREF],[KAMPNO],[KAMPHEDSATREF],[TIP],[ITEMREF],[MIKTAR] FROM [KurumsalWebSAP].dbo.[Web-Kampanya-3] WHERE [KAMKARTREF] = @KAMKARTREF", conn);
                da.SelectCommand.Parameters.Add("@KAMKARTREF", SqlDbType.UniqueIdentifier).Value = kamkartref;
                da.SelectCommand.CommandTimeout = 200;
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
        /// <summary>
        /// [Web-Kampanya-1]
        /// </summary>
        public static bool KampanyaIsAvailable(Guid kamkartref)
        {
            bool donendeger = false;

            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3))
            {
                SqlCommand cmd = new SqlCommand("SELECT count(*) FROM [KurumsalWebSAP].dbo.[Web-Kampanya-1] WHERE [KAMKARTREF] = @KAMKARTREF", conn);
                cmd.Parameters.Add("@KAMKARTREF", SqlDbType.UniqueIdentifier).Value = kamkartref;
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
        /// <summary>
        /// [Web-Kampanya-4]
        /// </summary>
        public static decimal GetProductPrice(int UrunID, short FiyatTipi)
        {
            decimal donendeger = 0;

            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3))
            {
                SqlCommand cmd = new SqlCommand("SELECT [NET+KDV] FROM [KurumsalWebSAP].dbo.[Web-Fiyat] WHERE [ITEMREF] = @ITEMREF AND [TIP] = @TIP", conn);
                cmd.Parameters.Add("@ITEMREF", System.Data.SqlDbType.Int).Value = UrunID;
                cmd.Parameters.Add("@TIP", System.Data.SqlDbType.SmallInt).Value = FiyatTipi;
                try
                {
                    conn.Open();
                    donendeger = Convert.ToDecimal(cmd.ExecuteScalar());
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
        /// [eski] tek başına tedarikçi süzmesine göre sayı getiriyor
        /// </summary>
        public static void GetTedarikciler(string harf, ListItemCollection lic, int FiyatTipiID, ArrayList OzelKodlar, ArrayList GrupKodlar)
        {
            string ozelkodlar = string.Empty;
            string grupkodlar = string.Empty;

            for (int i = 0; i < OzelKodlar.Count; i++)
                ozelkodlar += "[Web-Malzeme].[OZEL KOD] = '" + OzelKodlar[i].ToString() + "' OR ";

            if (OzelKodlar.Count > 0)
                ozelkodlar = "(" + ozelkodlar.Substring(0, ozelkodlar.Length - 4) + ") AND ";

            for (int i = 0; i < GrupKodlar.Count; i++)
                grupkodlar += "[Web-Malzeme].[GRUP KOD] = '" + GrupKodlar[i].ToString() + "' OR ";

            if (GrupKodlar.Count > 0)
                grupkodlar = "(" + grupkodlar.Substring(0, grupkodlar.Length - 4) + ") AND ";

            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3))
            {
                SqlCommand cmd = new SqlCommand("SELECT count(DISTINCT [KurumsalWebSAP].dbo.[Web-Kampanya-1].[KAMKARTREF]),[Web-OzelKodlar].[OZEL KOD],[Web-OzelKodlar].[OZEL ACIK] FROM [KurumsalWebSAP].dbo.[Web-Kampanya-1] INNER JOIN [KurumsalWebSAP].dbo.[Web-Kampanya-2] ON [KurumsalWebSAP].dbo.[Web-Kampanya-1].[KAMKARTREF] = [KurumsalWebSAP].dbo.[Web-Kampanya-2].[KAMKARTREF] INNER JOIN [Web-Malzeme] ON [KurumsalWebSAP].dbo.[Web-Kampanya-2].[ITEMREF] = [Web-Malzeme].[ITEMREF] INNER JOIN [Web-OzelKodlar] ON [Web-Malzeme].[OZEL KOD] = [Web-OzelKodlar].[OZEL KOD] WHERE [Web-OzelKodlar].[OZEL KOD] IN (SELECT [OZEL KOD] FROM [Web-OzelKodlar] WHERE [OZEL ACIK] LIKE '" + harf + "%') AND " + ozelkodlar + grupkodlar + "[KurumsalWebSAP].dbo.[Web-Kampanya-2].[TIP] = " + FiyatTipiID.ToString() + "  GROUP BY [Web-OzelKodlar].[OZEL KOD],[Web-OzelKodlar].[OZEL ACIK] ORDER BY [Web-OzelKodlar].[OZEL ACIK]", conn);

                cmd.CommandTimeout = 600;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        ListItem lst = new ListItem();
                        lst.Text = dr[2].ToString() + " (" + dr[0].ToString() + ")";
                        lst.Value = dr[1].ToString();
                        lic.Add(lst);
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
        /// [eski] kategori süzmesini de katarak sayı getiriyor
        /// </summary>
        public static void GetTedarikciler(string harf, string KategoriID, ListItemCollection lic, int FiyatTipiID, ArrayList OzelKodlar, ArrayList GrupKodlar)
        {
            string kategoriid = "";
            if (KategoriID == "NOT NULL")
                kategoriid = "IS NOT NULL";
            else
                kategoriid = "= " + KategoriID;

            string ozelkodlar = string.Empty;
            string grupkodlar = string.Empty;

            for (int i = 0; i < OzelKodlar.Count; i++)
                ozelkodlar += "[Web-Malzeme].[OZEL KOD] = '" + OzelKodlar[i].ToString() + "' OR ";

            if (OzelKodlar.Count > 0)
                ozelkodlar = "(" + ozelkodlar.Substring(0, ozelkodlar.Length - 4) + ") AND ";

            for (int i = 0; i < GrupKodlar.Count; i++)
                grupkodlar += "[Web-Malzeme].[GRUP KOD] = '" + GrupKodlar[i].ToString() + "' OR ";

            if (GrupKodlar.Count > 0)
                grupkodlar = "(" + grupkodlar.Substring(0, grupkodlar.Length - 4) + ") AND ";

            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3))
            {
                SqlCommand cmd = new SqlCommand("SELECT count(DISTINCT [KurumsalWebSAP].dbo.[Web-Kampanya-1].[KAMKARTREF]),[Web-OzelKodlar].[OZEL KOD],[Web-OzelKodlar].[OZEL ACIK] FROM [KurumsalWebSAP].dbo.[Web-Kampanya-1] INNER JOIN [KurumsalWebSAP].dbo.[Web-Kampanya-2] ON [KurumsalWebSAP].dbo.[Web-Kampanya-1].[KAMKARTREF] = [KurumsalWebSAP].dbo.[Web-Kampanya-2].[KAMKARTREF] INNER JOIN [Web-Malzeme] ON [KurumsalWebSAP].dbo.[Web-Kampanya-2].[ITEMREF] = [Web-Malzeme].[ITEMREF] INNER JOIN [Web-Kategoriler] ON [Web-Malzeme].[REY KOD] = [Web-Kategoriler].[CODE] INNER JOIN [Web-OzelKodlar] ON [Web-Malzeme].[OZEL KOD] = [Web-OzelKodlar].[OZEL KOD] WHERE [Web-OzelKodlar].[OZEL KOD] IN (SELECT [OZEL KOD] FROM [Web-OzelKodlar] WHERE [OZEL ACIK] LIKE '" + harf + "%') AND [Web-Kategoriler].[CODE] " + kategoriid + " AND " + ozelkodlar + grupkodlar + "[KurumsalWebSAP].dbo.[Web-Kampanya-2].[TIP] = " + FiyatTipiID.ToString() + " GROUP BY [Web-OzelKodlar].[OZEL KOD],[Web-OzelKodlar].[OZEL ACIK] ORDER BY [Web-OzelKodlar].[OZEL ACIK]", conn);

                cmd.CommandTimeout = 600;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        ListItem lst = new ListItem();
                        lst.Text = dr[2].ToString() + " (" + dr[0].ToString() + ")";
                        lst.Value = dr[1].ToString();
                        lic.Add(lst);
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
        /// [eski] tek başına kategori süzmesine göre sayı getiriyor
        /// </summary>
        public static void GetKategoriler(string harf, ListItemCollection lic, int FiyatTipiID, ArrayList OzelKodlar, ArrayList GrupKodlar)
        {
            string ozelkodlar = string.Empty;
            string grupkodlar = string.Empty;

            for (int i = 0; i < OzelKodlar.Count; i++)
                ozelkodlar += "[Web-Malzeme].[OZEL KOD] = '" + OzelKodlar[i].ToString() + "' OR ";

            if (OzelKodlar.Count > 0)
                ozelkodlar = "(" + ozelkodlar.Substring(0, ozelkodlar.Length - 4) + ") AND ";

            for (int i = 0; i < GrupKodlar.Count; i++)
                grupkodlar += "[Web-Malzeme].[GRUP KOD] = '" + GrupKodlar[i].ToString() + "' OR ";

            if (GrupKodlar.Count > 0)
                grupkodlar = "(" + grupkodlar.Substring(0, grupkodlar.Length - 4) + ") AND ";

            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3))
            {
                SqlCommand cmd = new SqlCommand("SELECT count(DISTINCT [KurumsalWebSAP].dbo.[Web-Kampanya-1].[KAMKARTREF]),[Web-Kategoriler].[CODE],[Web-Kategoriler].[NAME] FROM [KurumsalWebSAP].dbo.[Web-Kampanya-1] INNER JOIN [KurumsalWebSAP].dbo.[Web-Kampanya-2] ON [KurumsalWebSAP].dbo.[Web-Kampanya-1].[KAMKARTREF] = [KurumsalWebSAP].dbo.[Web-Kampanya-2].[KAMKARTREF] INNER JOIN [Web-Malzeme] ON [KurumsalWebSAP].dbo.[Web-Kampanya-2].[ITEMREF] = [Web-Malzeme].[ITEMREF] INNER JOIN [Web-Kategoriler] ON [Web-Malzeme].[REY KOD] = [Web-Kategoriler].[CODE] WHERE [Web-Kategoriler].[NAME] LIKE '" + harf + "%' AND " + ozelkodlar + grupkodlar + "[KurumsalWebSAP].dbo.[Web-Kampanya-2].[TIP] = " + FiyatTipiID.ToString() + " GROUP BY [Web-Kategoriler].[CODE],[Web-Kategoriler].[NAME] ORDER BY [Web-Kategoriler].[NAME]", conn);
                cmd.CommandTimeout = 600;
                SqlDataReader dr;

                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        ListItem lst = new ListItem();
                        lst.Text = dr[2].ToString() + " (" + dr[0].ToString() + ")";
                        lst.Value = dr[1].ToString();
                        lic.Add(lst);
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
        /// [eski] tedarikçi süzmesini de katarak sayı getiriyor
        /// </summary>
        public static void GetKategoriler(string harf, string TedarikciID, ListItemCollection lic, int FiyatTipiID, ArrayList OzelKodlar, ArrayList GrupKodlar)
        {
            string tedarikciid = "";
            if (TedarikciID == "NOT NULL")
                tedarikciid = "IS NOT NULL";
            else
                tedarikciid = "= " + TedarikciID;

            string ozelkodlar = string.Empty;
            string grupkodlar = string.Empty;

            for (int i = 0; i < OzelKodlar.Count; i++)
                ozelkodlar += "[Web-Malzeme].[OZEL KOD] = '" + OzelKodlar[i].ToString() + "' OR ";

            if (OzelKodlar.Count > 0)
                ozelkodlar = "(" + ozelkodlar.Substring(0, ozelkodlar.Length - 4) + ") AND ";

            for (int i = 0; i < GrupKodlar.Count; i++)
                grupkodlar += "[Web-Malzeme].[GRUP KOD] = '" + GrupKodlar[i].ToString() + "' OR ";

            if (GrupKodlar.Count > 0)
                grupkodlar = "(" + grupkodlar.Substring(0, grupkodlar.Length - 4) + ") AND ";

            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3))
            {
                SqlCommand cmd = new SqlCommand("SELECT count(DISTINCT [KurumsalWebSAP].dbo.[Web-Kampanya-1].[KAMKARTREF]),[Web-Kategoriler].[CODE],[Web-Kategoriler].[NAME] FROM [KurumsalWebSAP].dbo.[Web-Kampanya-1] INNER JOIN [KurumsalWebSAP].dbo.[Web-Kampanya-2] ON [KurumsalWebSAP].dbo.[Web-Kampanya-1].[KAMKARTREF] = [KurumsalWebSAP].dbo.[Web-Kampanya-2].[KAMKARTREF] INNER JOIN [Web-Malzeme] ON [KurumsalWebSAP].dbo.[Web-Kampanya-2].[ITEMREF] = [Web-Malzeme].[ITEMREF] INNER JOIN [Web-Kategoriler] ON [Web-Malzeme].[REY KOD] = [Web-Kategoriler].[CODE] INNER JOIN [Web-OzelKodlar] ON [Web-Malzeme].[OZEL KOD] = [Web-OzelKodlar].[OZEL KOD] WHERE [Web-Kategoriler].[NAME] LIKE '" + harf + "%' AND [Web-OzelKodlar].[OZEL KOD] " + tedarikciid + " AND " + ozelkodlar + grupkodlar + "[KurumsalWebSAP].dbo.[Web-Kampanya-2].[TIP] = " + FiyatTipiID.ToString() + " GROUP BY [Web-Kategoriler].[CODE],[Web-Kategoriler].[NAME] ORDER BY [Web-Kategoriler].[NAME]", conn);
                cmd.CommandTimeout = 600;
                SqlDataReader dr;

                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        ListItem lst = new ListItem();
                        lst.Text = dr[2].ToString() + " (" + dr[0].ToString() + ")";
                        lst.Value = dr[1].ToString();
                        lic.Add(lst);
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
        //
        //
        //
        // Yeni Tedarikçi ve Kategori Süzmeleri:
        // [Web-Kampanya-2] 
        public static void GetTedarikciler2(string harf, string KategoriID, string Aranan, ListItemCollection lic, int FiyatTipiID, ArrayList OzelKodlar, ArrayList GrupKodlar)
        {
            string kategoriid = "";
            if (KategoriID == "NOT NULL")
                kategoriid = "IS NOT NULL";
            else
                kategoriid = "= " + KategoriID;

            string ozelkodlar = string.Empty;
            string grupkodlar = string.Empty;

            for (int i = 0; i < OzelKodlar.Count; i++)
                ozelkodlar += "[KurumsalWebSAP].dbo.[Web-Kampanya-2].[OZEL KOD] = '" + OzelKodlar[i].ToString() + "' OR ";

            if (OzelKodlar.Count > 0)
                ozelkodlar = "(" + ozelkodlar.Substring(0, ozelkodlar.Length - 4) + ") AND ";

            for (int i = 0; i < GrupKodlar.Count; i++)
                grupkodlar += "[KurumsalWebSAP].dbo.[Web-Kampanya-2].[GRUP KOD] = '" + GrupKodlar[i].ToString() + "' OR ";

            if (GrupKodlar.Count > 0)
                grupkodlar = "(" + grupkodlar.Substring(0, grupkodlar.Length - 4) + ") AND ";

            if (harf == "C")
                harf = harf + "' OR [KurumsalWebSAP].dbo.[Web-Kampanya-2].[HK] = 'Ç";
            else if (harf == "G")
                harf = harf + "' OR [KurumsalWebSAP].dbo.[Web-Kampanya-2].[HK] = 'Ğ";
            else if (harf == "I")
                harf = harf + "' OR [KurumsalWebSAP].dbo.[Web-Kampanya-2].[HK] = 'İ";
            else if (harf == "O")
                harf = harf + "' OR [KurumsalWebSAP].dbo.[Web-Kampanya-2].[HK] = 'Ö";
            else if (harf == "S")
                harf = harf + "' OR [KurumsalWebSAP].dbo.[Web-Kampanya-2].[HK] = 'Ş";
            else if (harf == "U")
                harf = harf + "' OR [KurumsalWebSAP].dbo.[Web-Kampanya-2].[HK] = 'Ü";

            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3))
            {
                SqlCommand cmd = new SqlCommand("SELECT count(DISTINCT [KurumsalWebSAP].dbo.[Web-Kampanya-2].[KAMKARTREF]),[KurumsalWebSAP].dbo.[Web-Kampanya-2].[OZEL KOD],[KurumsalWebSAP].dbo.[Web-Kampanya-2].[OZEL ACIK] FROM [KurumsalWebSAP].dbo.[Web-Kampanya-2] WHERE ([KurumsalWebSAP].dbo.[Web-Kampanya-2].[HK] = '" + harf + "') AND [KurumsalWebSAP].dbo.[Web-Kampanya-2].[REY KOD] " + kategoriid + " AND " + ozelkodlar + grupkodlar + "[KurumsalWebSAP].dbo.[Web-Kampanya-2].[TIP] = " + FiyatTipiID.ToString() + " AND [KurumsalWebSAP].dbo.[Web-Kampanya-2].[MAL ACIK] LIKE '%" + Aranan + "%' GROUP BY [KurumsalWebSAP].dbo.[Web-Kampanya-2].[OZEL KOD],[KurumsalWebSAP].dbo.[Web-Kampanya-2].[OZEL ACIK] ORDER BY [KurumsalWebSAP].dbo.[Web-Kampanya-2].[OZEL ACIK]", conn);
                cmd.CommandTimeout = 600;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        ListItem lst = new ListItem();
                        lst.Text = dr[2].ToString() + " (" + dr[0].ToString() + ")";
                        lst.Value = dr[1].ToString();
                        lic.Add(lst);
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
        public static void GetKategoriler2(string harf, string TedarikciID, string Aranan, ListItemCollection lic, int FiyatTipiID, ArrayList OzelKodlar, ArrayList GrupKodlar)
        {
            string tedarikciid = "";
            if (TedarikciID == "NOT NULL")
                tedarikciid = "IS NOT NULL";
            else
                tedarikciid = "= " + TedarikciID;

            string ozelkodlar = string.Empty;
            string grupkodlar = string.Empty;

            for (int i = 0; i < OzelKodlar.Count; i++)
                ozelkodlar += "[KurumsalWebSAP].dbo.[Web-Kampanya-2].[OZEL KOD] = '" + OzelKodlar[i].ToString() + "' OR ";

            if (OzelKodlar.Count > 0)
                ozelkodlar = "(" + ozelkodlar.Substring(0, ozelkodlar.Length - 4) + ") AND ";

            for (int i = 0; i < GrupKodlar.Count; i++)
                grupkodlar += "[KurumsalWebSAP].dbo.[Web-Kampanya-2].[GRUP KOD] = '" + GrupKodlar[i].ToString() + "' OR ";

            if (GrupKodlar.Count > 0)
                grupkodlar = "(" + grupkodlar.Substring(0, grupkodlar.Length - 4) + ") AND ";

            if (harf == "C")
                harf = harf + "' OR [KurumsalWebSAP].dbo.[Web-Kampanya-2].[RK] = 'Ç";
            else if (harf == "G")
                harf = harf + "' OR [KurumsalWebSAP].dbo.[Web-Kampanya-2].[RK] = 'Ğ";
            else if (harf == "I")
                harf = harf + "' OR [KurumsalWebSAP].dbo.[Web-Kampanya-2].[RK] = 'İ";
            else if (harf == "O")
                harf = harf + "' OR [KurumsalWebSAP].dbo.[Web-Kampanya-2].[RK] = 'Ö";
            else if (harf == "S")
                harf = harf + "' OR [KurumsalWebSAP].dbo.[Web-Kampanya-2].[RK] = 'Ş";
            else if (harf == "U")
                harf = harf + "' OR [KurumsalWebSAP].dbo.[Web-Kampanya-2].[RK] = 'Ü";

            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3))
            {
                SqlCommand cmd = new SqlCommand("SELECT count(DISTINCT [KurumsalWebSAP].dbo.[Web-Kampanya-2].[KAMKARTREF]),[KurumsalWebSAP].dbo.[Web-Kampanya-2].[REY KOD],[KurumsalWebSAP].dbo.[Web-Kampanya-2].[REY ACIK] FROM [KurumsalWebSAP].dbo.[Web-Kampanya-2] WHERE ([KurumsalWebSAP].dbo.[Web-Kampanya-2].[RK] = '" + harf + "') AND [KurumsalWebSAP].dbo.[Web-Kampanya-2].[OZEL KOD] " + tedarikciid + " AND " + ozelkodlar + grupkodlar + "[KurumsalWebSAP].dbo.[Web-Kampanya-2].[TIP] = " + FiyatTipiID.ToString() + " AND [KurumsalWebSAP].dbo.[Web-Kampanya-2].[MAL ACIK] LIKE '%" + Aranan + "%' GROUP BY [KurumsalWebSAP].dbo.[Web-Kampanya-2].[REY KOD],[KurumsalWebSAP].dbo.[Web-Kampanya-2].[REY ACIK] ORDER BY [KurumsalWebSAP].dbo.[Web-Kampanya-2].[REY ACIK]", conn);
                cmd.CommandTimeout = 600;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        ListItem lst = new ListItem();
                        lst.Text = dr[2].ToString() + " (" + dr[0].ToString() + ")";
                        lst.Value = dr[1].ToString();
                        lic.Add(lst);
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
        /// [Web-Kampanya-2]
        /// </summary>
        public static void GetTedarikciHangiHarfler(DataTable dt, short FiyatTipi, string UrunAdi,
            string KategoriID, string KategoriOperator, ArrayList OzelKodlar, ArrayList GrupKodlar)
        {
            string ozelkodlar = string.Empty;
            string grupkodlar = string.Empty;

            for (int i = 0; i < OzelKodlar.Count; i++)
                ozelkodlar += "[OZEL KOD] = '" + OzelKodlar[i].ToString() + "' OR ";

            if (OzelKodlar.Count > 0)
                ozelkodlar = "(" + ozelkodlar.Substring(0, ozelkodlar.Length - 4) + ") AND ";

            for (int i = 0; i < GrupKodlar.Count; i++)
                grupkodlar += "[GRUP KOD] = '" + GrupKodlar[i].ToString() + "' OR ";

            if (GrupKodlar.Count > 0)
                grupkodlar = "(" + grupkodlar.Substring(0, grupkodlar.Length - 4) + ") AND ";

            string YeniKampanyalar = string.Empty;
            //if (Yeni)
            //    YeniKampanyalar = " AND [KYTK] < 16";

            string Aranan = UrunAdi.ToUpper().Replace("İ", "I").Replace("Ü", "U").Replace("Ö", "O").Replace("Ş", "S").Replace("Ç", "C").Replace("Ğ", "G");

            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT DISTINCT [HK] FROM [KurumsalWebSAP].dbo.[Web-Kampanya-2] " +
                    "WHERE [TIP] = @FiyatTipi AND [MAL ACIK] LIKE '%" + Aranan + "%' AND " +
                    ozelkodlar + grupkodlar +
                    //"[OZEL KOD] " + TedarikciOperator + " " + TedarikciID + " AND " +
                    "[REY KOD] " + KategoriOperator + " " + KategoriID + YeniKampanyalar, conn);
                da.SelectCommand.Parameters.Add("@FiyatTipi", SqlDbType.SmallInt).Value = Convert.ToInt16(FiyatTipi);
                da.SelectCommand.CommandTimeout = 200;
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
        /// <summary>
        /// [Web-Kampanya-2]
        /// </summary>
        public static void GetKategoriHangiHarfler(DataTable dt, short FiyatTipi, string UrunAdi, string TedarikciID, string TedarikciOperator,
            ArrayList OzelKodlar, ArrayList GrupKodlar)
        {
            string ozelkodlar = string.Empty;
            string grupkodlar = string.Empty;

            for (int i = 0; i < OzelKodlar.Count; i++)
                ozelkodlar += "[OZEL KOD] = '" + OzelKodlar[i].ToString() + "' OR ";

            if (OzelKodlar.Count > 0)
                ozelkodlar = "(" + ozelkodlar.Substring(0, ozelkodlar.Length - 4) + ") AND ";

            for (int i = 0; i < GrupKodlar.Count; i++)
                grupkodlar += "[GRUP KOD] = '" + GrupKodlar[i].ToString() + "' OR ";

            if (GrupKodlar.Count > 0)
                grupkodlar = "(" + grupkodlar.Substring(0, grupkodlar.Length - 4) + ") AND ";

            string YeniKampanyalar = string.Empty;
            //if (Yeni)
            //    YeniKampanyalar = " AND [KYTK] < 16";

            string Aranan = UrunAdi.ToUpper().Replace("İ", "I").Replace("Ü", "U").Replace("Ö", "O").Replace("Ş", "S").Replace("Ç", "C").Replace("Ğ", "G");

            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT DISTINCT [RK] FROM [KurumsalWebSAP].dbo.[Web-Kampanya-2] " +
                    "WHERE [TIP] = @FiyatTipi AND [MAL ACIK] LIKE '%" + Aranan + "%' AND " +
                    ozelkodlar + grupkodlar +
                    "[OZEL KOD] " + TedarikciOperator + " " + TedarikciID +
                    /*" AND [REY KOD] " + KategoriOperator + " " + KategoriID +*/ YeniKampanyalar, conn);
                da.SelectCommand.Parameters.Add("@FiyatTipi", SqlDbType.SmallInt).Value = Convert.ToInt16(FiyatTipi);
                da.SelectCommand.CommandTimeout = 200;
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



        /// <summary>
        /// [Web-Kampanya-1] [Web-Kampanya-2]
        /// </summary>
        public static void GetObjects2(DataTable dt, string Tedarikciharf, string Kategoriharf, int FiyatTipiID, ArrayList OzelKodlar, ArrayList GrupKodlar)
        {
            string kategoriharf = "";
            if (Kategoriharf == "")
                kategoriharf = "IS NOT NULL";
            else
                kategoriharf = "= '" + Kategoriharf + "'";

            string tedarikciharf = "";
            if (Tedarikciharf == "")
                tedarikciharf = "IS NOT NULL";
            else
                tedarikciharf = "= '" + Tedarikciharf + "'";

            string ozelkodlar = string.Empty;
            string grupkodlar = string.Empty;

            for (int i = 0; i < OzelKodlar.Count; i++)
                ozelkodlar += "[KurumsalWebSAP].dbo.[Web-Kampanya-2].[OZEL KOD] = '" + OzelKodlar[i].ToString() + "' OR ";

            if (OzelKodlar.Count > 0)
                ozelkodlar = "(" + ozelkodlar.Substring(0, ozelkodlar.Length - 4) + ") AND ";

            for (int i = 0; i < GrupKodlar.Count; i++)
                grupkodlar += "[KurumsalWebSAP].dbo.[Web-Kampanya-2].[GRUP KOD] = '" + GrupKodlar[i].ToString() + "' OR ";

            if (GrupKodlar.Count > 0)
                grupkodlar = "(" + grupkodlar.Substring(0, grupkodlar.Length - 4) + ") AND ";

            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT [KurumsalWebSAP].dbo.[Web-Kampanya-2].[OZEL KOD],[KurumsalWebSAP].dbo.[Web-Kampanya-2].[OZEL ACIK],[KurumsalWebSAP].dbo.[Web-Kampanya-1].[KAMKARTREF],[KurumsalWebSAP].dbo.[Web-Kampanya-1].[KAMPNO],[KurumsalWebSAP].dbo.[Web-Kampanya-1].[FIYAT_TIPI],[KurumsalWebSAP].dbo.[Web-Kampanya-1].[ACIKLAMA],[KurumsalWebSAP].dbo.[Web-Kampanya-1].[ONCELIK],[KurumsalWebSAP].dbo.[Web-Kampanya-1].[BASLANGIC_TARIHI],[KurumsalWebSAP].dbo.[Web-Kampanya-1].[BITIS_TARIHI],[KurumsalWebSAP].dbo.[Web-Kampanya-1].[KAMP.NET+KDV] AS FIYAT,[KurumsalWebSAP].dbo.[Web-Kampanya-1].[HED.NET+KDV] AS HEDIYE,[KurumsalWebSAP].dbo.[Web-Kampanya-1].[ISK-%] AS ISKONTO FROM [KurumsalWebSAP].dbo.[Web-Kampanya-2] INNER JOIN [KurumsalWebSAP].dbo.[Web-Kampanya-1] ON [KurumsalWebSAP].dbo.[Web-Kampanya-2].[KAMKARTREF] = [KurumsalWebSAP].dbo.[Web-Kampanya-1].[KAMKARTREF] WHERE [KurumsalWebSAP].dbo.[Web-Kampanya-2].[HK] " + tedarikciharf + " AND [KurumsalWebSAP].dbo.[Web-Kampanya-2].[RK] " + kategoriharf + " AND " + ozelkodlar + grupkodlar + "[KurumsalWebSAP].dbo.[Web-Kampanya-2].[TIP] = " + FiyatTipiID.ToString() + " ORDER BY [KurumsalWebSAP].dbo.[Web-Kampanya-2].[OZEL ACIK]", conn);
                da.SelectCommand.CommandTimeout = 600;
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
    }
}

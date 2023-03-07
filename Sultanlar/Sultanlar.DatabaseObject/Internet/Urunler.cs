using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.WebControls;

namespace Sultanlar.DatabaseObject.Internet
{
    public class Urunler
    {
        private int _ITEMREF; private string _MALACIK; private string _OZELKOD; private string _OZELACIK; private string _REYKOD; private string _REYACIK; private string _GRUPKOD; private string _GRUPACIK; private string _BARKOD;
        private Urunler(int ITEMREF, string MALACIK, string OZELKOD, string OZELACIK, string REYKOD, string REYACIK, string GRUPKOD, string GRUPACIK, string BARKOD) { this._ITEMREF = ITEMREF; this._MALACIK = MALACIK; this._OZELKOD = OZELKOD; this._OZELACIK = OZELACIK; this._REYKOD = REYKOD; this._REYACIK = REYACIK; this._GRUPKOD = GRUPKOD; this._GRUPACIK = GRUPACIK; this._BARKOD = BARKOD; }
        public Urunler() { }
        public int ITEMREF { get { return this._ITEMREF; } } public string MALACIK { get { return this._MALACIK; } } public string OZELKOD { get { return this._OZELKOD; } } public string OZELACIK { get { return this._OZELACIK; } } public string REYKOD { get { return this._REYKOD; } } public string REYACIK { get { return this._REYACIK; } } public string GRUPKOD { get { return this._GRUPKOD; } } public string GRUPACIK { get { return this._GRUPACIK; } } public string BARKOD { get { return this._BARKOD; } }
        public override string ToString() { return this._MALACIK; }
        //
        //
        #region Products
        //
        //
        // [Web-Fiyat] [Web-Malzeme] **************
        public static void GetProducts(DataTable dt, int Start, int Count, string FiyatTipi, string TedarikciOperator, string Tedarikci,
            string KategoriOperator, string Kategori, string AramaBasi, string Aranan, string Siralama, string AzalanArtan, 
            ArrayList OzelKodlar, ArrayList GrupKodlar, bool Yeni)
        {
            string ozelkodlar = string.Empty;
            string grupkodlar = string.Empty;

            for (int i = 0; i < OzelKodlar.Count; i++)
                ozelkodlar += "[KurumsalWebSAP].dbo.[Web-Malzeme].[OZEL KOD] = '" + OzelKodlar[i].ToString() + "' OR ";

            if (OzelKodlar.Count > 0)
                ozelkodlar = "(" + ozelkodlar.Substring(0, ozelkodlar.Length - 4) + ") AND ";

            for (int i = 0; i < GrupKodlar.Count; i++)
                grupkodlar += "[KurumsalWebSAP].dbo.[Web-Malzeme].[GRUP KOD] = '" + GrupKodlar[i].ToString() + "' OR ";

            if (GrupKodlar.Count > 0)
                grupkodlar = "(" + grupkodlar.Substring(0, grupkodlar.Length - 4) + ") AND ";



            Aranan = Aranan.ToUpper().Replace("'", " ").Replace("%", "").Replace("--", "").Replace("/*", "").Replace("*/", "").Replace(" OR ", " ").Replace(" AND ", " ").Replace(" LIKE ", " ");
            //Aranan = Aranan.ToUpper().Replace("İ", "I").Replace("Ü", "U").Replace("Ö", "O").Replace("Ş", "S").Replace("Ç", "C").Replace("Ğ", "G");
            
            string malacik = string.Empty;
            string[] aramakelimeler = new string[1];

            if (AramaBasi == string.Empty)
                aramakelimeler[0] = Aranan;
            else
                aramakelimeler = Aranan.Split(new string[] { " " }, StringSplitOptions.None);

            for (int i = 0; i < aramakelimeler.Length; i++)
                malacik += "[KurumsalWebSAP].dbo.[Web-Malzeme].[MAL ACIK] LIKE '" + AramaBasi + aramakelimeler[i] + "%' AND ";

            if (malacik == string.Empty)
                malacik = "[KurumsalWebSAP].dbo.[Web-Malzeme].[MAL ACIK] IS NOT NULL ";
            else
                malacik = malacik.Substring(0, malacik.Length - 4);



            string YeniUrunler = string.Empty;
            if (Yeni)
                YeniUrunler = "AND [KurumsalWebSAP].dbo.[Web-Malzeme].[KYTM] < 60 ";

            string besyuzlufiltreleme = string.Empty;
            if (Convert.ToInt32(FiyatTipi) > 500)
                besyuzlufiltreleme = "INNER JOIN [Web-FiyatTip-Urun] ON [Web-Malzeme].ITEMREF = [Web-FiyatTip-Urun].ITEMREF AND [Web-FiyatTip-Urun].TIP = " + FiyatTipi + " ";

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT " +
                    "IsNull((SELECT TOP 1 intResimID FROM tblINTERNET_UrunResim WHERE ITEMREF = [KurumsalWebSAP].dbo.[Web-Malzeme].[ITEMREF]), 0) AS pkResimID, " +
                    "[KurumsalWebSAP].dbo.[Web-Malzeme].[ITEMREF] AS UrunID, [KurumsalWebSAP].dbo.[Web-Malzeme].[URT KOD] AS URTKOD, [KurumsalWebSAP].dbo.[Web-Malzeme].[MAL ACIK] AS Ad, [KurumsalWebSAP].dbo.[Web-Malzeme].[OZEL KOD] AS TedarikciID, [KurumsalWebSAP].dbo.[Web-Malzeme].[OZEL ACIK] AS TedarikciAdi, [KurumsalWebSAP].dbo.[Web-Malzeme].[REY KOD] AS KategoriID, [KurumsalWebSAP].dbo.[Web-Malzeme].[REY ACIK] AS KategoriAdi, [KurumsalWebSAP].dbo.[Web-Malzeme].[KOLI] AS Adet, [KurumsalWebSAP].dbo.[Web-Malzeme].[BARKOD] AS Barkod, dbo.PozitifGetir([KurumsalWebSAP].dbo.[Web-Malzeme].[STOK] - ISNULL((SELECT sum(BKL_AD) FROM [SAP_SIPARIS_STR_DRM] WHERE SIP_TAR >= DATEADD(month,-3,getdate()) AND MALZ_KOD = [Web-Malzeme].[ITEMREF]),0)) AS STOK, count([KurumsalWebSAP].dbo.[Web-Fiyat].[KAMKARTREF]) AS KamKartRefSayisi, [KurumsalWebSAP].dbo.[Web-Fiyat].[FIYAT] AS BRUT, [KurumsalWebSAP].dbo.[Web-Fiyat].[ISK1], [KurumsalWebSAP].dbo.[Web-Fiyat].[ISK2], [KurumsalWebSAP].dbo.[Web-Fiyat].[ISK3], [KurumsalWebSAP].dbo.[Web-Fiyat].[ISK4], [KurumsalWebSAP].dbo.[Web-Fiyat].[ISK5], [KurumsalWebSAP].dbo.[Web-Fiyat].[ISK6], [KurumsalWebSAP].dbo.[Web-Fiyat].[ISK7], [KurumsalWebSAP].dbo.[Web-Fiyat].[ISK8], [KurumsalWebSAP].dbo.[Web-Fiyat].[ISK9], [KurumsalWebSAP].dbo.[Web-Fiyat].[ISK10], [KurumsalWebSAP].dbo.[Web-Malzeme].[KDV], [KurumsalWebSAP].dbo.[Web-Fiyat].[NET+KDV] AS Fiyat, [KurumsalWebSAP].dbo.[Web-Malzeme].[KYTM],VADE " + 
                    "FROM [KurumsalWebSAP].dbo.[Web-Malzeme] INNER JOIN [KurumsalWebSAP].dbo.[Web-Fiyat] ON [KurumsalWebSAP].dbo.[Web-Malzeme].[ITEMREF] = [KurumsalWebSAP].dbo.[Web-Fiyat].[ITEMREF] " +
                    besyuzlufiltreleme +
                    "WHERE [KurumsalWebSAP].dbo.[Web-Fiyat].[TIP] = " + FiyatTipi + " AND [KurumsalWebSAP].dbo.[Web-Malzeme].[OZEL KOD] " +
                    TedarikciOperator + " " + Tedarikci + " AND " +
                    "[KurumsalWebSAP].dbo.[Web-Malzeme].[REY KOD] " + KategoriOperator + " " + Kategori + " AND " + ozelkodlar + grupkodlar +
                    malacik + 
                    YeniUrunler +
                    "GROUP BY [KurumsalWebSAP].dbo.[Web-Malzeme].[ITEMREF], [KurumsalWebSAP].dbo.[Web-Malzeme].[URT KOD], [KurumsalWebSAP].dbo.[Web-Malzeme].[MAL ACIK], [KurumsalWebSAP].dbo.[Web-Malzeme].[OZEL KOD], [KurumsalWebSAP].dbo.[Web-Malzeme].[OZEL ACIK], [KurumsalWebSAP].dbo.[Web-Malzeme].[REY KOD], [KurumsalWebSAP].dbo.[Web-Malzeme].[REY ACIK], [KurumsalWebSAP].dbo.[Web-Malzeme].[KOLI], [KurumsalWebSAP].dbo.[Web-Malzeme].[BARKOD], [KurumsalWebSAP].dbo.[Web-Malzeme].[STOK], [KurumsalWebSAP].dbo.[Web-Fiyat].[FIYAT], [KurumsalWebSAP].dbo.[Web-Fiyat].[ISK1], [KurumsalWebSAP].dbo.[Web-Fiyat].[ISK2], [KurumsalWebSAP].dbo.[Web-Fiyat].[ISK3], [KurumsalWebSAP].dbo.[Web-Fiyat].[ISK4], [KurumsalWebSAP].dbo.[Web-Fiyat].[ISK5], [KurumsalWebSAP].dbo.[Web-Fiyat].[ISK6], [KurumsalWebSAP].dbo.[Web-Fiyat].[ISK7], [KurumsalWebSAP].dbo.[Web-Fiyat].[ISK8], [KurumsalWebSAP].dbo.[Web-Fiyat].[ISK9], [KurumsalWebSAP].dbo.[Web-Fiyat].[ISK10], [KurumsalWebSAP].dbo.[Web-Malzeme].[KDV], [KurumsalWebSAP].dbo.[Web-Fiyat].[NET+KDV], [KurumsalWebSAP].dbo.[Web-Malzeme].[KYTM],VADE " +
                    "ORDER BY " + Siralama + " " + AzalanArtan + ", [KurumsalWebSAP].dbo.[Web-Malzeme].[MAL ACIK] ASC", conn);
                da.SelectCommand.CommandTimeout = 400;
                try
                {
                    conn.Open();
                    da.Fill(Start, Count, dt);
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
        /// [Web-Fiyat] [Web-Malzeme] çoklu tedarikçi ve kategori seçimi **************
        /// </summary>
        public static void GetProducts(DataTable dt, int Start, int Count, string FiyatTipi, ArrayList Tedarikciler, ArrayList Kategoriler, 
            string AramaBasi, string Aranan, string Siralama, string AzalanArtan, ArrayList OzelKodlar, ArrayList GrupKodlar, bool Yeni)
        {
            string ozelkodlar = string.Empty;
            string grupkodlar = string.Empty;
            string tedarikciler = string.Empty;
            string kategoriler = string.Empty;



            for (int i = 0; i < OzelKodlar.Count; i++)
                ozelkodlar += "[KurumsalWebSAP].dbo.[Web-Malzeme].[OZEL KOD] = '" + OzelKodlar[i].ToString() + "' OR ";

            if (OzelKodlar.Count > 0)
                ozelkodlar = "(" + ozelkodlar.Substring(0, ozelkodlar.Length - 4) + ") AND ";

            for (int i = 0; i < GrupKodlar.Count; i++)
                grupkodlar += "[KurumsalWebSAP].dbo.[Web-Malzeme].[GRUP KOD] = '" + GrupKodlar[i].ToString() + "' OR ";

            if (GrupKodlar.Count > 0)
                grupkodlar = "(" + grupkodlar.Substring(0, grupkodlar.Length - 4) + ") AND ";



            for (int i = 0; i < Tedarikciler.Count; i++)
                tedarikciler += "[KurumsalWebSAP].dbo.[Web-Malzeme].[OZEL KOD] = '" + Tedarikciler[i].ToString() + "' OR ";

            if (Tedarikciler.Count > 0)
                tedarikciler = "(" + tedarikciler.Substring(0, tedarikciler.Length - 4) + ") AND ";



            for (int i = 0; i < Kategoriler.Count; i++)
                kategoriler += "[KurumsalWebSAP].dbo.[Web-Malzeme].[REY KOD] = '" + Tedarikciler[i].ToString() + "' OR ";

            if (Kategoriler.Count > 0)
                kategoriler = "(" + kategoriler.Substring(0, kategoriler.Length - 4) + ") AND ";



            Aranan = Aranan.ToUpper().Replace("'", " ").Replace("%", "").Replace("--", "").Replace("/*", "").Replace("*/", "").Replace(" OR ", " ").Replace(" AND ", " ").Replace(" LIKE ", " ");
            //Aranan = Aranan.ToUpper().Replace("İ", "I").Replace("Ü", "U").Replace("Ö", "O").Replace("Ş", "S").Replace("Ç", "C").Replace("Ğ", "G");

            string malacik = string.Empty;
            string[] aramakelimeler = new string[1];

            if (AramaBasi == string.Empty)
                aramakelimeler[0] = Aranan;
            else
                aramakelimeler = Aranan.Split(new string[] { " " }, StringSplitOptions.None);

            for (int i = 0; i < aramakelimeler.Length; i++)
                malacik += "[KurumsalWebSAP].dbo.[Web-Malzeme].[MAL ACIK] LIKE '" + AramaBasi + aramakelimeler[i] + "%' AND ";

            if (malacik == string.Empty)
                malacik = "[KurumsalWebSAP].dbo.[Web-Malzeme].[MAL ACIK] IS NOT NULL ";
            else
                malacik = malacik.Substring(0, malacik.Length - 4);



            string YeniUrunler = string.Empty;
            if (Yeni)
                YeniUrunler = "AND [KurumsalWebSAP].dbo.[Web-Malzeme].[KYTM] < 60 ";

            string besyuzlufiltreleme = string.Empty;
            if (Convert.ToInt32(FiyatTipi) > 500)
                besyuzlufiltreleme = "INNER JOIN [Web-FiyatTip-Urun] ON [Web-Malzeme].ITEMREF = [Web-FiyatTip-Urun].ITEMREF AND [Web-FiyatTip-Urun].TIP = " + FiyatTipi + " ";

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT " +
                    "IsNull((SELECT TOP 1 intResimID FROM tblINTERNET_UrunResim WHERE ITEMREF = [KurumsalWebSAP].dbo.[Web-Malzeme].[ITEMREF]), 0) AS pkResimID, " +
                    "[KurumsalWebSAP].dbo.[Web-Malzeme].[ITEMREF] AS UrunID, [KurumsalWebSAP].dbo.[Web-Malzeme].[URT KOD] AS URTKOD, [KurumsalWebSAP].dbo.[Web-Malzeme].[MAL ACIK] AS Ad, [KurumsalWebSAP].dbo.[Web-Malzeme].[OZEL KOD] AS TedarikciID, [KurumsalWebSAP].dbo.[Web-Malzeme].[OZEL ACIK] AS TedarikciAdi, [KurumsalWebSAP].dbo.[Web-Malzeme].[REY KOD] AS KategoriID, [KurumsalWebSAP].dbo.[Web-Malzeme].[REY ACIK] AS KategoriAdi, [KurumsalWebSAP].dbo.[Web-Malzeme].[KOLI] AS Adet, [KurumsalWebSAP].dbo.[Web-Malzeme].[BARKOD] AS Barkod, [KurumsalWebSAP].dbo.[Web-Malzeme].[STOK], count([KurumsalWebSAP].dbo.[Web-Fiyat].[KAMKARTREF]) AS KamKartRefSayisi, [KurumsalWebSAP].dbo.[Web-Fiyat].[FIYAT] AS BRUT, [KurumsalWebSAP].dbo.[Web-Fiyat].[ISK1], [KurumsalWebSAP].dbo.[Web-Fiyat].[ISK2], [KurumsalWebSAP].dbo.[Web-Fiyat].[ISK3], [KurumsalWebSAP].dbo.[Web-Fiyat].[ISK4], [KurumsalWebSAP].dbo.[Web-Fiyat].[ISK5], [KurumsalWebSAP].dbo.[Web-Fiyat].[ISK6], [KurumsalWebSAP].dbo.[Web-Fiyat].[ISK7], [KurumsalWebSAP].dbo.[Web-Fiyat].[ISK8], [KurumsalWebSAP].dbo.[Web-Fiyat].[ISK9], [KurumsalWebSAP].dbo.[Web-Fiyat].[ISK10], [KurumsalWebSAP].dbo.[Web-Malzeme].[KDV], [KurumsalWebSAP].dbo.[Web-Fiyat].[NET+KDV] AS Fiyat, [KurumsalWebSAP].dbo.[Web-Malzeme].[KYTM],VADE " +
                    "FROM [KurumsalWebSAP].dbo.[Web-Malzeme] INNER JOIN [KurumsalWebSAP].dbo.[Web-Fiyat] ON [KurumsalWebSAP].dbo.[Web-Malzeme].[ITEMREF] = [KurumsalWebSAP].dbo.[Web-Fiyat].[ITEMREF] " +
                    besyuzlufiltreleme + 
                    "WHERE [KurumsalWebSAP].dbo.[Web-Fiyat].[TIP] = " + FiyatTipi + " AND " +
                    tedarikciler + kategoriler + ozelkodlar + grupkodlar + malacik + YeniUrunler +
                    "GROUP BY [KurumsalWebSAP].dbo.[Web-Malzeme].[ITEMREF], [KurumsalWebSAP].dbo.[Web-Malzeme].[URT KOD], [KurumsalWebSAP].dbo.[Web-Malzeme].[MAL ACIK], [KurumsalWebSAP].dbo.[Web-Malzeme].[OZEL KOD], [KurumsalWebSAP].dbo.[Web-Malzeme].[OZEL ACIK], [KurumsalWebSAP].dbo.[Web-Malzeme].[REY KOD], [KurumsalWebSAP].dbo.[Web-Malzeme].[REY ACIK], [KurumsalWebSAP].dbo.[Web-Malzeme].[KOLI], [KurumsalWebSAP].dbo.[Web-Malzeme].[BARKOD], [KurumsalWebSAP].dbo.[Web-Malzeme].[STOK], [KurumsalWebSAP].dbo.[Web-Fiyat].[FIYAT], [KurumsalWebSAP].dbo.[Web-Fiyat].[ISK1], [KurumsalWebSAP].dbo.[Web-Fiyat].[ISK2], [KurumsalWebSAP].dbo.[Web-Fiyat].[ISK3], [KurumsalWebSAP].dbo.[Web-Fiyat].[ISK4], [KurumsalWebSAP].dbo.[Web-Fiyat].[ISK5], [KurumsalWebSAP].dbo.[Web-Fiyat].[ISK6], [KurumsalWebSAP].dbo.[Web-Fiyat].[ISK7], [KurumsalWebSAP].dbo.[Web-Fiyat].[ISK8], [KurumsalWebSAP].dbo.[Web-Fiyat].[ISK9], [KurumsalWebSAP].dbo.[Web-Fiyat].[ISK10], [KurumsalWebSAP].dbo.[Web-Malzeme].[KDV], [KurumsalWebSAP].dbo.[Web-Fiyat].[NET+KDV], [KurumsalWebSAP].dbo.[Web-Malzeme].[KYTM],VADE " +
                    "ORDER BY " + Siralama + " " + AzalanArtan + ", [KurumsalWebSAP].dbo.[Web-Malzeme].[MAL ACIK] ASC", conn);
                da.SelectCommand.CommandTimeout = 400;
                try
                {
                    conn.Open();
                    da.Fill(Start, Count, dt);
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
        /// [Web-Fiyat] [Web-Malzeme] çoklu tedarikçi ve kategori seçimi
        /// </summary>
        public static void GetProducts(DataTable dt, int Start, int Count, string FiyatTipi, ArrayList Tedarikciler, ArrayList Kategoriler,
            string AramaBasi, string Aranan, string Siralama, string AzalanArtan, ArrayList OzelKodlar, ArrayList GrupKodlar, bool Yeni, ArrayList Hyrs)
        {
            string ozelkodlar = string.Empty;
            string grupkodlar = string.Empty;
            string tedarikciler = string.Empty;
            string hyrs = string.Empty;
            string kategoriler = string.Empty;



            for (int i = 0; i < OzelKodlar.Count; i++)
                ozelkodlar += "[KurumsalWebSAP].dbo.[Web-Malzeme].[OZEL KOD] = '" + OzelKodlar[i].ToString() + "' OR ";

            if (OzelKodlar.Count > 0)
                ozelkodlar = "(" + ozelkodlar.Substring(0, ozelkodlar.Length - 4) + ") AND ";

            for (int i = 0; i < GrupKodlar.Count; i++)
                grupkodlar += "[KurumsalWebSAP].dbo.[Web-Malzeme].[GRUP KOD] = '" + GrupKodlar[i].ToString() + "' OR ";

            if (GrupKodlar.Count > 0)
                grupkodlar = "(" + grupkodlar.Substring(0, grupkodlar.Length - 4) + ") AND ";



            for (int i = 0; i < Tedarikciler.Count; i++)
                tedarikciler += "[KurumsalWebSAP].dbo.[Web-Malzeme].[OZEL KOD] = '" + Tedarikciler[i].ToString() + "' OR ";

            if (Tedarikciler.Count > 0)
                tedarikciler = "(" + tedarikciler.Substring(0, tedarikciler.Length - 4) + ") AND ";



            for (int i = 0; i < Kategoriler.Count; i++)
                kategoriler += "[KurumsalWebSAP].dbo.[Web-Malzeme].[REY KOD] = '" + Tedarikciler[i].ToString() + "' OR ";

            if (Kategoriler.Count > 0)
                kategoriler = "(" + kategoriler.Substring(0, kategoriler.Length - 4) + ") AND ";



            for (int i = 0; i < Hyrs.Count; i++)
                hyrs += "[KurumsalWebSAP].dbo.[Web-Malzeme].[HYRS] = '" + Hyrs[i].ToString() + "' OR ";

            if (Hyrs.Count > 0)
                hyrs = "(" + hyrs.Substring(0, hyrs.Length - 4) + ") AND ";



            Aranan = Aranan.ToUpper().Replace("'", " ").Replace("%", "").Replace("--", "").Replace("/*", "").Replace("*/", "").Replace(" OR ", " ").Replace(" AND ", " ").Replace(" LIKE ", " ");
            //Aranan = Aranan.ToUpper().Replace("İ", "I").Replace("Ü", "U").Replace("Ö", "O").Replace("Ş", "S").Replace("Ç", "C").Replace("Ğ", "G");

            string malacik = string.Empty;
            string[] aramakelimeler = new string[1];

            if (AramaBasi == string.Empty)
                aramakelimeler[0] = Aranan;
            else
                aramakelimeler = Aranan.Split(new string[] { " " }, StringSplitOptions.None);

            for (int i = 0; i < aramakelimeler.Length; i++)
                malacik += "[KurumsalWebSAP].dbo.[Web-Malzeme].[MAL ACIK] LIKE '" + AramaBasi + aramakelimeler[i] + "%' AND ";

            if (malacik == string.Empty)
                malacik = "[KurumsalWebSAP].dbo.[Web-Malzeme].[MAL ACIK] IS NOT NULL ";
            else
                malacik = malacik.Substring(0, malacik.Length - 4);



            string YeniUrunler = string.Empty;
            if (Yeni)
                YeniUrunler = "AND [KurumsalWebSAP].dbo.[Web-Malzeme].[KYTM] < 60 ";

            string besyuzlufiltreleme = string.Empty;
            if (Convert.ToInt32(FiyatTipi) > 500)
                besyuzlufiltreleme = "INNER JOIN [Web-FiyatTip-Urun] ON [Web-Malzeme].ITEMREF = [Web-FiyatTip-Urun].ITEMREF AND [Web-FiyatTip-Urun].TIP = " + FiyatTipi + " ";

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT " +
                    "IsNull((SELECT TOP 1 intResimID FROM tblINTERNET_UrunResim WHERE ITEMREF = [KurumsalWebSAP].dbo.[Web-Malzeme].[ITEMREF]), 0) AS pkResimID, " +
                    "[KurumsalWebSAP].dbo.[Web-Malzeme].[ITEMREF] AS UrunID, [KurumsalWebSAP].dbo.[Web-Malzeme].[URT KOD] AS URTKOD, [KurumsalWebSAP].dbo.[Web-Malzeme].[MAL ACIK] AS Ad, [KurumsalWebSAP].dbo.[Web-Malzeme].[OZEL KOD] AS TedarikciID, [KurumsalWebSAP].dbo.[Web-Malzeme].[OZEL ACIK] AS TedarikciAdi, [KurumsalWebSAP].dbo.[Web-Malzeme].[REY KOD] AS KategoriID, [KurumsalWebSAP].dbo.[Web-Malzeme].[REY ACIK] AS KategoriAdi, [KurumsalWebSAP].dbo.[Web-Malzeme].[KOLI] AS Adet, [KurumsalWebSAP].dbo.[Web-Malzeme].[BARKOD] AS Barkod, [KurumsalWebSAP].dbo.[Web-Malzeme].[STOK], count([KurumsalWebSAP].dbo.[Web-Fiyat].[KAMKARTREF]) AS KamKartRefSayisi, [KurumsalWebSAP].dbo.[Web-Fiyat].[FIYAT] AS BRUT, [KurumsalWebSAP].dbo.[Web-Fiyat].[ISK1], [KurumsalWebSAP].dbo.[Web-Fiyat].[ISK2], [KurumsalWebSAP].dbo.[Web-Fiyat].[ISK3], [KurumsalWebSAP].dbo.[Web-Fiyat].[ISK4], [KurumsalWebSAP].dbo.[Web-Fiyat].[ISK5], [KurumsalWebSAP].dbo.[Web-Fiyat].[ISK6], [KurumsalWebSAP].dbo.[Web-Fiyat].[ISK7], [KurumsalWebSAP].dbo.[Web-Fiyat].[ISK8], [KurumsalWebSAP].dbo.[Web-Fiyat].[ISK9], [KurumsalWebSAP].dbo.[Web-Fiyat].[ISK10], [KurumsalWebSAP].dbo.[Web-Malzeme].[KDV], [KurumsalWebSAP].dbo.[Web-Fiyat].[NET+KDV] AS Fiyat, [KurumsalWebSAP].dbo.[Web-Malzeme].[KYTM],VADE " +
                    "FROM [KurumsalWebSAP].dbo.[Web-Malzeme] INNER JOIN [KurumsalWebSAP].dbo.[Web-Fiyat] ON [KurumsalWebSAP].dbo.[Web-Malzeme].[ITEMREF] = [KurumsalWebSAP].dbo.[Web-Fiyat].[ITEMREF] " +
                    besyuzlufiltreleme +
                    "WHERE [KurumsalWebSAP].dbo.[Web-Fiyat].[TIP] = " + FiyatTipi + " AND " +
                    tedarikciler + hyrs + kategoriler + ozelkodlar + grupkodlar + malacik + YeniUrunler +
                    "GROUP BY [KurumsalWebSAP].dbo.[Web-Malzeme].[ITEMREF], [KurumsalWebSAP].dbo.[Web-Malzeme].[URT KOD], [KurumsalWebSAP].dbo.[Web-Malzeme].[MAL ACIK], [KurumsalWebSAP].dbo.[Web-Malzeme].[OZEL KOD], [KurumsalWebSAP].dbo.[Web-Malzeme].[OZEL ACIK], [KurumsalWebSAP].dbo.[Web-Malzeme].[REY KOD], [KurumsalWebSAP].dbo.[Web-Malzeme].[REY ACIK], [KurumsalWebSAP].dbo.[Web-Malzeme].[KOLI], [KurumsalWebSAP].dbo.[Web-Malzeme].[BARKOD], [KurumsalWebSAP].dbo.[Web-Malzeme].[STOK], [KurumsalWebSAP].dbo.[Web-Fiyat].[FIYAT], [KurumsalWebSAP].dbo.[Web-Fiyat].[ISK1], [KurumsalWebSAP].dbo.[Web-Fiyat].[ISK2], [KurumsalWebSAP].dbo.[Web-Fiyat].[ISK3], [KurumsalWebSAP].dbo.[Web-Fiyat].[ISK4], [KurumsalWebSAP].dbo.[Web-Fiyat].[ISK5], [KurumsalWebSAP].dbo.[Web-Fiyat].[ISK6], [KurumsalWebSAP].dbo.[Web-Fiyat].[ISK7], [KurumsalWebSAP].dbo.[Web-Fiyat].[ISK8], [KurumsalWebSAP].dbo.[Web-Fiyat].[ISK9], [KurumsalWebSAP].dbo.[Web-Fiyat].[ISK10], [KurumsalWebSAP].dbo.[Web-Malzeme].[KDV], [KurumsalWebSAP].dbo.[Web-Fiyat].[NET+KDV], [KurumsalWebSAP].dbo.[Web-Malzeme].[KYTM],VADE " +
                    "ORDER BY " + Siralama + " " + AzalanArtan, conn);
                da.SelectCommand.CommandTimeout = 400;
                try
                {
                    conn.Open();
                    da.Fill(Start, Count, dt);
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
        /// [Web-Fiyat] [Web-Malzeme] **************
        /// </summary>
        public static void GetProducts(DataTable dt, string FiyatTipi, string Barkod, ArrayList OzelKodlar, ArrayList GrupKodlar)
        {
            string ozelkodlar = string.Empty;
            string grupkodlar = string.Empty;

            for (int i = 0; i < OzelKodlar.Count; i++)
                ozelkodlar += "[KurumsalWebSAP].dbo.[Web-Malzeme].[OZEL KOD] = '" + OzelKodlar[i].ToString() + "' OR ";

            if (OzelKodlar.Count > 0)
                ozelkodlar = "(" + ozelkodlar.Substring(0, ozelkodlar.Length - 4) + ") AND ";

            for (int i = 0; i < GrupKodlar.Count; i++)
                grupkodlar += "[KurumsalWebSAP].dbo.[Web-Malzeme].[GRUP KOD] = '" + GrupKodlar[i].ToString() + "' OR ";

            if (GrupKodlar.Count > 0)
                grupkodlar = "(" + grupkodlar.Substring(0, grupkodlar.Length - 4) + ") AND ";

            Barkod = Barkod.ToUpper().Replace("'", " ").Replace("%", "").Replace("--", "").Replace("/*", "").Replace("*/", "").Replace(" OR ", " ").Replace(" AND ", " ").Replace(" LIKE ", " ");

            string besyuzlufiltreleme = string.Empty;
            if (Convert.ToInt32(FiyatTipi) > 500)
                besyuzlufiltreleme = "INNER JOIN [Web-FiyatTip-Urun] ON [Web-Malzeme].ITEMREF = [Web-FiyatTip-Urun].ITEMREF AND [Web-FiyatTip-Urun].TIP = " + FiyatTipi + " ";

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT " +
                    "IsNull((SELECT TOP 1 intResimID FROM tblINTERNET_UrunResim WHERE ITEMREF = [KurumsalWebSAP].dbo.[Web-Malzeme].[ITEMREF]), 0) AS pkResimID, " +
                    "[KurumsalWebSAP].dbo.[Web-Malzeme].[ITEMREF] AS UrunID, [KurumsalWebSAP].dbo.[Web-Malzeme].[URT KOD] AS URTKOD, [KurumsalWebSAP].dbo.[Web-Malzeme].[MAL ACIK] AS Ad, [KurumsalWebSAP].dbo.[Web-Malzeme].[OZEL KOD] AS TedarikciID, [KurumsalWebSAP].dbo.[Web-Malzeme].[OZEL ACIK] AS TedarikciAdi, [KurumsalWebSAP].dbo.[Web-Malzeme].[REY KOD] AS KategoriID, [KurumsalWebSAP].dbo.[Web-Malzeme].[REY ACIK] AS KategoriAdi, [KurumsalWebSAP].dbo.[Web-Malzeme].[KOLI] AS Adet, [KurumsalWebSAP].dbo.[Web-Malzeme].[BARKOD] AS Barkod, dbo.PozitifGetir([KurumsalWebSAP].dbo.[Web-Malzeme].[STOK] - ISNULL((SELECT sum(BKL_AD) FROM [SAP_SIPARIS_STR_DRM] WHERE SIP_TAR >= DATEADD(month,-3,getdate()) AND MALZ_KOD = [Web-Malzeme].[ITEMREF]),0)) AS STOK, count([KurumsalWebSAP].dbo.[Web-Fiyat].[KAMKARTREF]) AS KamKartRefSayisi, [KurumsalWebSAP].dbo.[Web-Fiyat].[FIYAT] AS BRUT, [KurumsalWebSAP].dbo.[Web-Fiyat].[ISK1], [KurumsalWebSAP].dbo.[Web-Fiyat].[ISK2], [KurumsalWebSAP].dbo.[Web-Fiyat].[ISK3], [KurumsalWebSAP].dbo.[Web-Fiyat].[ISK4], [KurumsalWebSAP].dbo.[Web-Fiyat].[ISK5], [KurumsalWebSAP].dbo.[Web-Fiyat].[ISK6], [KurumsalWebSAP].dbo.[Web-Fiyat].[ISK7], [KurumsalWebSAP].dbo.[Web-Fiyat].[ISK8], [KurumsalWebSAP].dbo.[Web-Fiyat].[ISK9], [KurumsalWebSAP].dbo.[Web-Fiyat].[ISK10], [KurumsalWebSAP].dbo.[Web-Malzeme].[KDV], [KurumsalWebSAP].dbo.[Web-Fiyat].[NET+KDV] AS Fiyat, [KurumsalWebSAP].dbo.[Web-Malzeme].[KYTM],VADE " + 
                    "FROM [KurumsalWebSAP].dbo.[Web-Malzeme] INNER JOIN [KurumsalWebSAP].dbo.[Web-Fiyat] ON [KurumsalWebSAP].dbo.[Web-Malzeme].[ITEMREF] = [KurumsalWebSAP].dbo.[Web-Fiyat].[ITEMREF] " +
                    besyuzlufiltreleme + 
                    "WHERE [KurumsalWebSAP].dbo.[Web-Fiyat].[TIP] = " + FiyatTipi + " AND " + ozelkodlar + grupkodlar +
                    "[KurumsalWebSAP].dbo.[Web-Malzeme].[BARKOD] = '" + Barkod + "' " +
                    "GROUP BY [KurumsalWebSAP].dbo.[Web-Malzeme].[ITEMREF], [KurumsalWebSAP].dbo.[Web-Malzeme].[URT KOD], [KurumsalWebSAP].dbo.[Web-Malzeme].[MAL ACIK], [KurumsalWebSAP].dbo.[Web-Malzeme].[OZEL KOD], [KurumsalWebSAP].dbo.[Web-Malzeme].[OZEL ACIK], [KurumsalWebSAP].dbo.[Web-Malzeme].[REY KOD], [KurumsalWebSAP].dbo.[Web-Malzeme].[REY ACIK], [KurumsalWebSAP].dbo.[Web-Malzeme].[KOLI], [KurumsalWebSAP].dbo.[Web-Malzeme].[BARKOD], [KurumsalWebSAP].dbo.[Web-Malzeme].[STOK], [KurumsalWebSAP].dbo.[Web-Fiyat].[FIYAT], [KurumsalWebSAP].dbo.[Web-Fiyat].[ISK1], [KurumsalWebSAP].dbo.[Web-Fiyat].[ISK2], [KurumsalWebSAP].dbo.[Web-Fiyat].[ISK3], [KurumsalWebSAP].dbo.[Web-Fiyat].[ISK4], [KurumsalWebSAP].dbo.[Web-Fiyat].[ISK5], [KurumsalWebSAP].dbo.[Web-Fiyat].[ISK6], [KurumsalWebSAP].dbo.[Web-Fiyat].[ISK7], [KurumsalWebSAP].dbo.[Web-Fiyat].[ISK8], [KurumsalWebSAP].dbo.[Web-Fiyat].[ISK9], [KurumsalWebSAP].dbo.[Web-Fiyat].[ISK10], [KurumsalWebSAP].dbo.[Web-Malzeme].[KDV], [KurumsalWebSAP].dbo.[Web-Fiyat].[NET+KDV], [KurumsalWebSAP].dbo.[Web-Malzeme].[KYTM],VADE", conn);
                da.SelectCommand.CommandTimeout = 400;
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
        /// [Web-Fiyat] [Web-Malzeme] **************
        /// </summary>
        public static void GetProducts(DataTable dt, string FiyatTipi, string Malkod, ArrayList OzelKodlar, ArrayList GrupKodlar, bool malkod)
        {
            string ozelkodlar = string.Empty;
            string grupkodlar = string.Empty;

            for (int i = 0; i < OzelKodlar.Count; i++)
                ozelkodlar += "[KurumsalWebSAP].dbo.[Web-Malzeme].[OZEL KOD] = '" + OzelKodlar[i].ToString() + "' OR ";

            if (OzelKodlar.Count > 0)
                ozelkodlar = "(" + ozelkodlar.Substring(0, ozelkodlar.Length - 4) + ") AND ";

            for (int i = 0; i < GrupKodlar.Count; i++)
                grupkodlar += "[KurumsalWebSAP].dbo.[Web-Malzeme].[GRUP KOD] = '" + GrupKodlar[i].ToString() + "' OR ";

            if (GrupKodlar.Count > 0)
                grupkodlar = "(" + grupkodlar.Substring(0, grupkodlar.Length - 4) + ") AND ";

            Malkod = Malkod.ToUpper().Replace("'", " ").Replace("%", "").Replace("--", "").Replace("/*", "").Replace("*/", "").Replace(" OR ", " ").Replace(" AND ", " ").Replace(" LIKE ", " ");

            string besyuzlufiltreleme = string.Empty;
            if (Convert.ToInt32(FiyatTipi) > 500)
                besyuzlufiltreleme = "INNER JOIN [Web-FiyatTip-Urun] ON [Web-Malzeme].ITEMREF = [Web-FiyatTip-Urun].ITEMREF AND [Web-FiyatTip-Urun].TIP = " + FiyatTipi + " ";

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT " +
                    "IsNull((SELECT TOP 1 intResimID FROM tblINTERNET_UrunResim WHERE ITEMREF = [KurumsalWebSAP].dbo.[Web-Malzeme].[ITEMREF]), 0) AS pkResimID, " +
                    "[KurumsalWebSAP].dbo.[Web-Malzeme].[ITEMREF] AS UrunID, [KurumsalWebSAP].dbo.[Web-Malzeme].[URT KOD] AS URTKOD, [KurumsalWebSAP].dbo.[Web-Malzeme].[MAL ACIK] AS Ad, [KurumsalWebSAP].dbo.[Web-Malzeme].[OZEL KOD] AS TedarikciID, [KurumsalWebSAP].dbo.[Web-Malzeme].[OZEL ACIK] AS TedarikciAdi, [KurumsalWebSAP].dbo.[Web-Malzeme].[REY KOD] AS KategoriID, [KurumsalWebSAP].dbo.[Web-Malzeme].[REY ACIK] AS KategoriAdi, [KurumsalWebSAP].dbo.[Web-Malzeme].[KOLI] AS Adet, [KurumsalWebSAP].dbo.[Web-Malzeme].[BARKOD] AS Barkod, dbo.PozitifGetir([KurumsalWebSAP].dbo.[Web-Malzeme].[STOK] - ISNULL((SELECT sum(BKL_AD) FROM [SAP_SIPARIS_STR_DRM] WHERE SIP_TAR >= DATEADD(month,-3,getdate()) AND MALZ_KOD = [Web-Malzeme].[ITEMREF]),0)) AS STOK, count([KurumsalWebSAP].dbo.[Web-Fiyat].[KAMKARTREF]) AS KamKartRefSayisi, [KurumsalWebSAP].dbo.[Web-Fiyat].[FIYAT] AS BRUT, [KurumsalWebSAP].dbo.[Web-Fiyat].[ISK1], [KurumsalWebSAP].dbo.[Web-Fiyat].[ISK2], [KurumsalWebSAP].dbo.[Web-Fiyat].[ISK3], [KurumsalWebSAP].dbo.[Web-Fiyat].[ISK4], [KurumsalWebSAP].dbo.[Web-Fiyat].[ISK5], [KurumsalWebSAP].dbo.[Web-Fiyat].[ISK6], [KurumsalWebSAP].dbo.[Web-Fiyat].[ISK7], [KurumsalWebSAP].dbo.[Web-Fiyat].[ISK8], [KurumsalWebSAP].dbo.[Web-Fiyat].[ISK9], [KurumsalWebSAP].dbo.[Web-Fiyat].[ISK10], [KurumsalWebSAP].dbo.[Web-Malzeme].[KDV], [KurumsalWebSAP].dbo.[Web-Fiyat].[NET+KDV] AS Fiyat, [KurumsalWebSAP].dbo.[Web-Malzeme].[KYTM],VADE " +
                    "FROM [KurumsalWebSAP].dbo.[Web-Malzeme] INNER JOIN [KurumsalWebSAP].dbo.[Web-Fiyat] ON [KurumsalWebSAP].dbo.[Web-Malzeme].[ITEMREF] = [KurumsalWebSAP].dbo.[Web-Fiyat].[ITEMREF] " +
                    besyuzlufiltreleme + 
                    "WHERE [KurumsalWebSAP].dbo.[Web-Fiyat].[TIP] = " + FiyatTipi + " AND " + ozelkodlar + grupkodlar +
                    "[KurumsalWebSAP].dbo.[Web-Malzeme].[MAL KOD] = '" + Malkod + "' " +
                    "GROUP BY [KurumsalWebSAP].dbo.[Web-Malzeme].[ITEMREF], [KurumsalWebSAP].dbo.[Web-Malzeme].[URT KOD], [KurumsalWebSAP].dbo.[Web-Malzeme].[MAL ACIK], [KurumsalWebSAP].dbo.[Web-Malzeme].[OZEL KOD], [KurumsalWebSAP].dbo.[Web-Malzeme].[OZEL ACIK], [KurumsalWebSAP].dbo.[Web-Malzeme].[REY KOD], [KurumsalWebSAP].dbo.[Web-Malzeme].[REY ACIK], [KurumsalWebSAP].dbo.[Web-Malzeme].[KOLI], [KurumsalWebSAP].dbo.[Web-Malzeme].[BARKOD], [KurumsalWebSAP].dbo.[Web-Malzeme].[STOK], [KurumsalWebSAP].dbo.[Web-Fiyat].[FIYAT], [KurumsalWebSAP].dbo.[Web-Fiyat].[ISK1], [KurumsalWebSAP].dbo.[Web-Fiyat].[ISK2], [KurumsalWebSAP].dbo.[Web-Fiyat].[ISK3], [KurumsalWebSAP].dbo.[Web-Fiyat].[ISK4], [KurumsalWebSAP].dbo.[Web-Fiyat].[ISK5], [KurumsalWebSAP].dbo.[Web-Fiyat].[ISK6], [KurumsalWebSAP].dbo.[Web-Fiyat].[ISK7], [KurumsalWebSAP].dbo.[Web-Fiyat].[ISK8], [KurumsalWebSAP].dbo.[Web-Fiyat].[ISK9], [KurumsalWebSAP].dbo.[Web-Fiyat].[ISK10], [KurumsalWebSAP].dbo.[Web-Malzeme].[KDV], [KurumsalWebSAP].dbo.[Web-Fiyat].[NET+KDV], [KurumsalWebSAP].dbo.[Web-Malzeme].[KYTM],VADE", conn);
                da.SelectCommand.CommandTimeout = 400;
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
        /// [Web-Fiyat] [Web-Malzeme] **************
        /// </summary>
        public static void GetProducts(DataTable dt, string FiyatTipi, string Urtkod, ArrayList OzelKodlar, ArrayList GrupKodlar, bool urtkod, bool urtkod1)
        {
            string ozelkodlar = string.Empty;
            string grupkodlar = string.Empty;

            for (int i = 0; i < OzelKodlar.Count; i++)
                ozelkodlar += "[KurumsalWebSAP].dbo.[Web-Malzeme].[OZEL KOD] = '" + OzelKodlar[i].ToString() + "' OR ";

            if (OzelKodlar.Count > 0)
                ozelkodlar = "(" + ozelkodlar.Substring(0, ozelkodlar.Length - 4) + ") AND ";

            for (int i = 0; i < GrupKodlar.Count; i++)
                grupkodlar += "[KurumsalWebSAP].dbo.[Web-Malzeme].[GRUP KOD] = '" + GrupKodlar[i].ToString() + "' OR ";

            if (GrupKodlar.Count > 0)
                grupkodlar = "(" + grupkodlar.Substring(0, grupkodlar.Length - 4) + ") AND ";

            Urtkod = Urtkod.ToUpper().Replace("'", " ").Replace("%", "").Replace("--", "").Replace("/*", "").Replace("*/", "").Replace(" OR ", " ").Replace(" AND ", " ").Replace(" LIKE ", " ");

            string besyuzlufiltreleme = string.Empty;
            if (Convert.ToInt32(FiyatTipi) > 500)
                besyuzlufiltreleme = "INNER JOIN [Web-FiyatTip-Urun] ON [Web-Malzeme].ITEMREF = [Web-FiyatTip-Urun].ITEMREF AND [Web-FiyatTip-Urun].TIP = " + FiyatTipi + " ";

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT " +
                    "IsNull((SELECT TOP 1 intResimID FROM tblINTERNET_UrunResim WHERE ITEMREF = [KurumsalWebSAP].dbo.[Web-Malzeme].[ITEMREF]), 0) AS pkResimID, " +
                    "[KurumsalWebSAP].dbo.[Web-Malzeme].[ITEMREF] AS UrunID, [KurumsalWebSAP].dbo.[Web-Malzeme].[URT KOD] AS URTKOD, [KurumsalWebSAP].dbo.[Web-Malzeme].[MAL ACIK] AS Ad, [KurumsalWebSAP].dbo.[Web-Malzeme].[OZEL KOD] AS TedarikciID, [KurumsalWebSAP].dbo.[Web-Malzeme].[OZEL ACIK] AS TedarikciAdi, [KurumsalWebSAP].dbo.[Web-Malzeme].[REY KOD] AS KategoriID, [KurumsalWebSAP].dbo.[Web-Malzeme].[REY ACIK] AS KategoriAdi, [KurumsalWebSAP].dbo.[Web-Malzeme].[KOLI] AS Adet, [KurumsalWebSAP].dbo.[Web-Malzeme].[BARKOD] AS Barkod, dbo.PozitifGetir([KurumsalWebSAP].dbo.[Web-Malzeme].[STOK] - ISNULL((SELECT sum(BKL_AD) FROM [SAP_SIPARIS_STR_DRM] WHERE SIP_TAR >= DATEADD(month,-3,getdate()) AND MALZ_KOD = [Web-Malzeme].[ITEMREF]),0)) AS STOK, count([KurumsalWebSAP].dbo.[Web-Fiyat].[KAMKARTREF]) AS KamKartRefSayisi, [KurumsalWebSAP].dbo.[Web-Fiyat].[FIYAT] AS BRUT, [KurumsalWebSAP].dbo.[Web-Fiyat].[ISK1], [KurumsalWebSAP].dbo.[Web-Fiyat].[ISK2], [KurumsalWebSAP].dbo.[Web-Fiyat].[ISK3], [KurumsalWebSAP].dbo.[Web-Fiyat].[ISK4], [KurumsalWebSAP].dbo.[Web-Fiyat].[ISK5], [KurumsalWebSAP].dbo.[Web-Fiyat].[ISK6], [KurumsalWebSAP].dbo.[Web-Fiyat].[ISK7], [KurumsalWebSAP].dbo.[Web-Fiyat].[ISK8], [KurumsalWebSAP].dbo.[Web-Fiyat].[ISK9], [KurumsalWebSAP].dbo.[Web-Fiyat].[ISK10], [KurumsalWebSAP].dbo.[Web-Malzeme].[KDV], [KurumsalWebSAP].dbo.[Web-Fiyat].[NET+KDV] AS Fiyat, [KurumsalWebSAP].dbo.[Web-Malzeme].[KYTM],VADE " +
                    "FROM [KurumsalWebSAP].dbo.[Web-Malzeme] INNER JOIN [KurumsalWebSAP].dbo.[Web-Fiyat] ON [KurumsalWebSAP].dbo.[Web-Malzeme].[ITEMREF] = [KurumsalWebSAP].dbo.[Web-Fiyat].[ITEMREF] " +
                    besyuzlufiltreleme + 
                    "WHERE [KurumsalWebSAP].dbo.[Web-Fiyat].[TIP] = " + FiyatTipi + " AND " + ozelkodlar + grupkodlar +
                    "[KurumsalWebSAP].dbo.[Web-Malzeme].[URT KOD] = '" + Urtkod + "' " +
                    "GROUP BY [KurumsalWebSAP].dbo.[Web-Malzeme].[ITEMREF], [KurumsalWebSAP].dbo.[Web-Malzeme].[URT KOD], [KurumsalWebSAP].dbo.[Web-Malzeme].[MAL ACIK], [KurumsalWebSAP].dbo.[Web-Malzeme].[OZEL KOD], [KurumsalWebSAP].dbo.[Web-Malzeme].[OZEL ACIK], [KurumsalWebSAP].dbo.[Web-Malzeme].[REY KOD], [KurumsalWebSAP].dbo.[Web-Malzeme].[REY ACIK], [KurumsalWebSAP].dbo.[Web-Malzeme].[KOLI], [KurumsalWebSAP].dbo.[Web-Malzeme].[BARKOD], [KurumsalWebSAP].dbo.[Web-Malzeme].[STOK], [KurumsalWebSAP].dbo.[Web-Fiyat].[FIYAT], [KurumsalWebSAP].dbo.[Web-Fiyat].[ISK1], [KurumsalWebSAP].dbo.[Web-Fiyat].[ISK2], [KurumsalWebSAP].dbo.[Web-Fiyat].[ISK3], [KurumsalWebSAP].dbo.[Web-Fiyat].[ISK4], [KurumsalWebSAP].dbo.[Web-Fiyat].[ISK5], [KurumsalWebSAP].dbo.[Web-Fiyat].[ISK6], [KurumsalWebSAP].dbo.[Web-Fiyat].[ISK7], [KurumsalWebSAP].dbo.[Web-Fiyat].[ISK8], [KurumsalWebSAP].dbo.[Web-Fiyat].[ISK9], [KurumsalWebSAP].dbo.[Web-Fiyat].[ISK10], [KurumsalWebSAP].dbo.[Web-Malzeme].[KDV], [KurumsalWebSAP].dbo.[Web-Fiyat].[NET+KDV], [KurumsalWebSAP].dbo.[Web-Malzeme].[KYTM],VADE", conn);
                da.SelectCommand.CommandTimeout = 400;
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
        /// [Web-Malzeme]
        /// </summary>
        public static void GetProducts(IList List, int ITEMREF, string MALACIK, string OZELKOD, string REYKOD, string BARKOD, bool Tumu, 
            bool Resimli, bool Yeni, bool Alfabetik)
        {
            List.Clear();

            MALACIK = MALACIK.ToUpper().Replace("'", " ").Replace("%", "").Replace("--", "").Replace("/*", "").Replace("*/", "").Replace(" OR ", " ").Replace(" AND ", " ").Replace(" LIKE ", " ");

            string itemref = " IS NOT NULL ";
            string malacik = " IS NOT NULL ";
            string ozelkod = " IS NOT NULL ";
            string reykod = " IS NOT NULL ";
            string barkod = " IS NOT NULL ";
            string resimliresimsiz = "";
            if (ITEMREF != 0)
                itemref = " = " + ITEMREF.ToString();
            if (MALACIK != string.Empty)
                malacik = " LIKE '%" + MALACIK + "%' ";
            if (OZELKOD != string.Empty)
                ozelkod = " = '" + OZELKOD + "' ";
            if (REYKOD != string.Empty)
                reykod = " = '" + REYKOD + "' ";
            if (BARKOD != string.Empty)
                barkod = " = '" + BARKOD + "' ";
            if (!Tumu)
            {
                if (Resimli)
                    resimliresimsiz = "AND tblINTERNET_UrunResim.intResimID IS NOT NULL ";
                else
                    resimliresimsiz = "AND tblINTERNET_UrunResim.intResimID IS NULL ";
            }

            malacik = malacik.ToUpper(); //.Replace("İ", "I").Replace("Ü", "U").Replace("Ö", "O").Replace("Ş", "S").Replace("Ç", "C").Replace("Ğ", "G")

            string YeniUrunler = string.Empty;
            if (Yeni)
                YeniUrunler = "AND [Web-Malzeme].[KYTM] < 16 ";

            string Siralama = "IlkResimTarihi DESC";
            if (Alfabetik)
                Siralama = "[Web-Malzeme].[MAL ACIK]";

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand
                    ("SELECT DISTINCT [Web-Malzeme].[ITEMREF],[Web-Malzeme].[MAL ACIK],[Web-Malzeme].[OZEL KOD],[Web-Malzeme].[OZEL ACIK],[Web-Malzeme].[REY KOD],[Web-Malzeme].[REY ACIK],[Web-Malzeme].[GRUP KOD],[Web-Malzeme].[GRUP ACIK],[Web-Malzeme].[BARKOD],(SELECT TOP 1 [dtEklenme] FROM [tblINTERNET_UrunResim] WHERE [ITEMREF] = [Web-Malzeme].[ITEMREF]) AS IlkResimTarihi " +
                    "FROM [Web-Malzeme] LEFT OUTER JOIN tblINTERNET_UrunResim ON [Web-Malzeme].[ITEMREF] = tblINTERNET_UrunResim.[ITEMREF] " +
                    //"INNER JOIN [Web-Fiyat] ON [Web-Malzeme].[ITEMREF] = [Web-Fiyat].[ITEMREF] " +
                    "WHERE [Web-Malzeme].[ITEMREF]" + itemref +
                    "AND [Web-Malzeme].[MAL ACIK]" + malacik +
                    "AND [Web-Malzeme].[OZEL KOD]" + ozelkod +
                    "AND [Web-Malzeme].[REY KOD]" + reykod +
                    "AND [Web-Malzeme].[BARKOD]" + barkod + 
                    YeniUrunler +
                    resimliresimsiz +
                    "ORDER BY " + Siralama, conn);
                cmd.CommandTimeout = 400;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                        List.Add(new Urunler(Convert.ToInt32(dr[0]), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(),
                            dr[5].ToString(), dr[6].ToString(), dr[7].ToString(), dr[8].ToString()));
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
        /// [Web-Malzeme-Full]
        /// </summary>
        public static void GetProducts(IList List, int ITEMREF, string MALACIK, string OZELKOD, string REYKOD, string BARKOD, bool Tumu,
            bool Resimli, bool Yeni, bool Alfabetik, bool ButunUrunler)
        {
            List.Clear();

            MALACIK = MALACIK.ToUpper().Replace("'", " ").Replace("%", "").Replace("--", "").Replace("/*", "").Replace("*/", "").Replace(" OR ", " ").Replace(" AND ", " ").Replace(" LIKE ", " ");

            string itemref = " IS NOT NULL ";
            string malacik = " IS NOT NULL ";
            string ozelkod = " IS NOT NULL ";
            string reykod = " IS NOT NULL ";
            string barkod = " IS NOT NULL ";
            string resimliresimsiz = "";
            if (ITEMREF != 0)
                itemref = " = " + ITEMREF.ToString();
            if (MALACIK != string.Empty)
                malacik = " LIKE '%" + MALACIK + "%' ";
            if (OZELKOD != string.Empty)
                ozelkod = " = '" + OZELKOD + "' ";
            if (REYKOD != string.Empty)
                reykod = " = '" + REYKOD + "' ";
            if (BARKOD != string.Empty)
                barkod = " = '" + BARKOD + "' ";
            if (!Tumu)
            {
                if (Resimli)
                    resimliresimsiz = "AND tblINTERNET_UrunResim.intResimID IS NOT NULL ";
                else
                    resimliresimsiz = "AND tblINTERNET_UrunResim.intResimID IS NULL ";
            }

            malacik = malacik.ToUpper(); //.Replace("İ", "I").Replace("Ü", "U").Replace("Ö", "O").Replace("Ş", "S").Replace("Ç", "C").Replace("Ğ", "G")

            string YeniUrunler = string.Empty;
            if (Yeni)
                YeniUrunler = "AND [Web-Malzeme-Full].[KYTM] < 16 ";

            string Siralama = "IlkResimTarihi DESC";
            if (Alfabetik)
                Siralama = "[Web-Malzeme-Full].[MAL ACIK]";

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand
                    ("SELECT DISTINCT [Web-Malzeme-Full].[ITEMREF],[Web-Malzeme-Full].[MAL ACIK],[Web-Malzeme-Full].[OZEL KOD],[Web-Malzeme-Full].[OZEL ACIK],[Web-Malzeme-Full].[REY KOD],[Web-Malzeme-Full].[REY ACIK],[Web-Malzeme-Full].[GRUP KOD],[Web-Malzeme-Full].[GRUP ACIK],[Web-Malzeme-Full].[BARKOD],(SELECT TOP 1 [dtEklenme] FROM [tblINTERNET_UrunResim] WHERE [ITEMREF] = [Web-Malzeme-Full].[ITEMREF]) AS IlkResimTarihi " +
                    "FROM [Web-Malzeme-Full] LEFT OUTER JOIN tblINTERNET_UrunResim ON [Web-Malzeme-Full].[ITEMREF] = tblINTERNET_UrunResim.[ITEMREF] " +
                    //"INNER JOIN [Web-Fiyat] ON [Web-Malzeme].[ITEMREF] = [Web-Fiyat].[ITEMREF] " +
                    "WHERE [Web-Malzeme-Full].[ITEMREF]" + itemref +
                    "AND [Web-Malzeme-Full].[MAL ACIK]" + malacik +
                    "AND [Web-Malzeme-Full].[OZEL KOD]" + ozelkod +
                    "AND [Web-Malzeme-Full].[REY KOD]" + reykod +
                    "AND [Web-Malzeme-Full].[BARKOD]" + barkod +
                    YeniUrunler +
                    resimliresimsiz +
                    "ORDER BY " + Siralama, conn);
                cmd.CommandTimeout = 400;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                        List.Add(new Urunler(Convert.ToInt32(dr[0]), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(),
                            dr[5].ToString(), dr[6].ToString(), dr[7].ToString(), dr[8].ToString()));
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
        /// [Web-Malzeme]
        /// </summary>
        public static void GetProducts(IList List, string MALACIK, short FiyatTipi)
        {
            List.Clear();

            MALACIK = MALACIK.ToUpper().Replace("'", " ").Replace("%", "").Replace("--", "").Replace("/*", "").Replace("*/", "").Replace(" OR ", " ").Replace(" AND ", " ").Replace(" LIKE ", " ");

            string malacik = " LIKE '" + MALACIK + "%'";

            malacik = malacik.ToUpper(); //.Replace("İ", "I").Replace("Ü", "U").Replace("Ö", "O").Replace("Ş", "S").Replace("Ç", "C").Replace("Ğ", "G")

            string besyuzlufiltreleme = string.Empty;
            if (Convert.ToInt32(FiyatTipi) > 500)
                besyuzlufiltreleme = "INNER JOIN [Web-FiyatTip-Urun] ON [Web-Malzeme].ITEMREF = [Web-FiyatTip-Urun].ITEMREF AND [Web-FiyatTip-Urun].TIP = " + FiyatTipi + " ";

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand
                    ("SELECT DISTINCT [Web-Malzeme].[ITEMREF],[Web-Malzeme].[MAL ACIK] FROM [Web-Malzeme] " +
                    "INNER JOIN [Web-Fiyat] ON [Web-Malzeme].[ITEMREF] = [Web-Fiyat].[ITEMREF] " +
                    besyuzlufiltreleme + 
                    "WHERE [Web-Malzeme].[MAL ACIK]" + malacik +
                    " AND [Web-Fiyat].TIP = " + FiyatTipi.ToString() + 
                    " ORDER BY [MAL ACIK]" , conn);
                cmd.CommandTimeout = 400;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                        List.Add(dr[1].ToString());
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
        /// [Web-Fiyat] [Web-Malzeme], tümü
        /// </summary>
        public static void GetProducts(ListItemCollection lic, string Arama, ArrayList OzelKodlar, ArrayList GrupKodlar)
        {
            lic.Clear();
            lic.Add(new ListItem("Tümü", "0"));

            string ozelkodlar = string.Empty;
            string grupkodlar = string.Empty;

            for (int i = 0; i < OzelKodlar.Count; i++)
                ozelkodlar += "[KurumsalWebSAP].dbo.[Web-Malzeme].[OZEL KOD] = '" + OzelKodlar[i].ToString() + "' OR ";

            if (OzelKodlar.Count > 0)
                ozelkodlar = " AND (" + ozelkodlar.Substring(0, ozelkodlar.Length - 4) + ") ";

            for (int i = 0; i < GrupKodlar.Count; i++)
                grupkodlar += "[KurumsalWebSAP].dbo.[Web-Malzeme].[GRUP KOD] = '" + GrupKodlar[i].ToString() + "' OR ";

            if (GrupKodlar.Count > 0)
                grupkodlar = " AND (" + grupkodlar.Substring(0, grupkodlar.Length - 4) + ") ";

            Arama = Arama.ToUpper().Replace("'", " ").Replace("%", "").Replace("--", "").Replace("/*", "").Replace("*/", "").Replace(" OR ", " ").Replace(" AND ", " ").Replace(" LIKE ", " ");
            //Arama = Arama.ToUpper().Replace("İ", "I").Replace("Ü", "U").Replace("Ö", "O").Replace("Ş", "S").Replace("Ç", "C").Replace("Ğ", "G");

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT ITEMREF,[MAL ACIK] FROM [Web-Malzeme]" +
                    "WHERE [MAL ACIK] LIKE '%" + Arama + "%' " + ozelkodlar + grupkodlar + "ORDER BY [MAL ACIK]", conn);
                cmd.CommandTimeout = 400;
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
        /// [Web-Fiyat] [Web-Malzeme], webservice için
        /// </summary>
        public static void GetProducts(DataTable dt, int Start, int Count, string FiyatTipi, string Aranan)
        {
            Aranan = Aranan.ToUpper().Replace("'", " ").Replace("%", "").Replace("--", "").Replace("/*", "").Replace("*/", "").Replace(" OR ", " ").Replace(" AND ", " ").Replace(" LIKE ", " ");
            //Aranan = Aranan.ToUpper().Replace("İ", "I").Replace("Ü", "U").Replace("Ö", "O").Replace("Ş", "S").Replace("Ç", "C").Replace("Ğ", "G");

            string malacik = string.Empty;
            string[] aramakelimeler = new string[1];

            aramakelimeler = Aranan.Split(new string[] { " " }, StringSplitOptions.None);

            for (int i = 0; i < aramakelimeler.Length; i++)
                malacik += "[KurumsalWebSAP].dbo.[Web-Malzeme].[MAL ACIK] LIKE '%" + aramakelimeler[i] + "%' AND ";

            if (malacik == string.Empty)
                malacik = "[KurumsalWebSAP].dbo.[Web-Malzeme].[MAL ACIK] IS NOT NULL ";
            else
                malacik = malacik.Substring(0, malacik.Length - 4);

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT " +
                    "[KurumsalWebSAP].dbo.[Web-Malzeme].[ITEMREF] AS UrunID,[KurumsalWebSAP].dbo.[Web-Malzeme].[MAL ACIK] AS Ad, [KurumsalWebSAP].dbo.[Web-Malzeme].[BARKOD] AS Barkod, [KurumsalWebSAP].dbo.[Web-Malzeme].[STOK], [KurumsalWebSAP].dbo.[Web-Fiyat].[NET+KDV] AS Fiyat " +
                    "FROM [KurumsalWebSAP].dbo.[Web-Malzeme] INNER JOIN [KurumsalWebSAP].dbo.[Web-Fiyat] ON [KurumsalWebSAP].dbo.[Web-Malzeme].[ITEMREF] = [KurumsalWebSAP].dbo.[Web-Fiyat].[ITEMREF] " +
                    "WHERE [KurumsalWebSAP].dbo.[Web-Fiyat].[TIP] = " + FiyatTipi + " AND " + malacik +
                    "ORDER BY [KurumsalWebSAP].dbo.[Web-Malzeme].[MAL ACIK] ASC", conn);
                da.SelectCommand.CommandTimeout = 400;
                try
                {
                    conn.Open();
                    da.Fill(Start, Count, dt);
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
        /// [Web-Malzeme-Full], yeni kategori mantığı için
        /// </summary>
        public static void GetProducts(DataTable dt)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT " +
                    "[AP],[Web-Malzeme-Full].[ITEMREF],[MAL ACIK],[OZEL KOD],[OZEL ACIK],[REY KOD],[REY ACIK]," +
                    "(SELECT count(REF) FROM KurumsalWebSAP.dbo.[Web-Malzeme-Aciklama] WHERE ITEMREF = [Web-Malzeme-Full].ITEMREF AND [KATEGORIREF] != 0 AND [MARKAREF] != 0 AND [CINSIYETREF] != 0) AS BILGILI, " +
                    "(SELECT (SELECT KATEGORI FROM KurumsalWebSAP.dbo.[Web-Malzeme-ReyonKategori] WHERE REF = MRK.USTREF) FROM KurumsalWebSAP.dbo.[Web-Malzeme-ReyonKategori] AS MRK WHERE REF = KurumsalWebSAP.dbo.[Web-Malzeme-Aciklama].KATEGORIREF) AS USTKATEGORI, " +
                    "(SELECT KATEGORI FROM KurumsalWebSAP.dbo.[Web-Malzeme-ReyonKategori] WHERE REF = KurumsalWebSAP.dbo.[Web-Malzeme-Aciklama].KATEGORIREF) AS KATEGORI, " +
                    "(SELECT MARKA FROM KurumsalWebSAP.dbo.[Web-Malzeme-Marka] WHERE REF = KurumsalWebSAP.dbo.[Web-Malzeme-Aciklama].MARKAREF) AS MARKA, " +
                    "(SELECT CINSIYET FROM KurumsalWebSAP.dbo.[Web-Malzeme-Cinsiyet] WHERE REF = KurumsalWebSAP.dbo.[Web-Malzeme-Aciklama].CINSIYETREF) AS CINSIYET, " +
                    "(SELECT count(*) FROM KurumsalWebSAP.dbo.[tblINTERNET_UrunResim] WHERE ITEMREF = [Web-Malzeme-Full].ITEMREF) AS RESIMLI " +
                    "FROM [Web-Malzeme-Full] " +
                    "LEFT OUTER JOIN KurumsalWebSAP.dbo.[Web-Malzeme-Aciklama] ON [Web-Malzeme-Full].ITEMREF = KurumsalWebSAP.dbo.[Web-Malzeme-Aciklama].ITEMREF " +
                    "WHERE [GRUP KOD] != 'URT' " +
                    "ORDER BY [MAL ACIK] ASC", conn);
                da.SelectCommand.CommandTimeout = 400;
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
        /// [Web-Fiyat] [Web-Malzeme], webservice için bütün ürünler fiyatsız geliyor
        /// </summary>
        public static void GetProductsWS(DataTable dt)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT " +
                    "[ITEMREF] AS 'item_ref',[MAL ACIK] AS 'item',[BARKOD] AS 'barcode',[STOK] AS 'stock' " +
                    "FROM [Web-Malzeme] " +
                    "ORDER BY [MAL ACIK] ASC", conn);
                da.SelectCommand.CommandTimeout = 400;
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
        /// [Web-Fiyat] [Web-Malzeme], webservice için bütün ürünler bütün fiyatlarıyla geliyor
        /// </summary>
        public static void GetPricesWS(DataTable dt)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT " +
                    "[ITEMREF] AS 'ir',[TIP] AS 'tr',[NET+KDV] AS 'pr' " +
                    "FROM [Web-Fiyat] WHERE [NET+KDV] IS NOT NULL " +
                    "ORDER BY [TIP],ITEMREF ASC", conn);
                da.SelectCommand.CommandTimeout = 400;
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
        /// [Web-Fiyat] [Web-Malzeme], webservice için bütün ürünler bütün fiyatlarıyla geliyor
        /// </summary>
        public static void GetPricesWS(DataTable dt, ArrayList FiyatTipleri)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                string where = "WHERE ";
                for (int i = 0; i < FiyatTipleri.Count; i++)
                {
                    where += "TIP = " + FiyatTipleri[i].ToString() + " OR ";
                }
                where = where.Substring(0, where.Length - 3);

                SqlDataAdapter da = new SqlDataAdapter("SELECT " +
                    "[ITEMREF] AS 'ir',[TIP] AS 'tr',[NET+KDV] AS 'pr' " +
                    "FROM [Web-Fiyat] " + 
                    where +
                    "ORDER BY [TIP] ASC", conn);
                da.SelectCommand.CommandTimeout = 400;
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
        /// [Web-Fiyat] [Web-Malzeme], hizlisiparis icin **************
        /// </summary>
        public static void GetProductsHS(DataTable dt, string FiyatTipi, bool ButunUrunler, int SMREF)
        {
            string besyuzlufiltreleme = string.Empty;
            if (Convert.ToInt32(FiyatTipi) > 500 && !ButunUrunler)
                besyuzlufiltreleme = "INNER JOIN [Web-FiyatTip-Urun] ON [Web-Malzeme].ITEMREF = [Web-FiyatTip-Urun].ITEMREF AND [Web-FiyatTip-Urun].TIP = " + FiyatTipi + " ";

            string belliurunler = string.Empty;
            if (Convert.ToInt32(FiyatTipi) < 500 && !ButunUrunler)
                belliurunler = "AND [Web-Malzeme].ITEMREF IN (SELECT DISTINCT ITEMREF FROM [Web-Satis-Rapor] WHERE GMREF = " + CariHesaplar.GetGMREFBySMREF(SMREF).ToString() + ") ";

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT " +
                    "[Web-Malzeme].[OZEL KOD],[Web-Malzeme].[ITEMREF] AS UrunID,METIN AS Tedarikci,[Web-Malzeme].[MAL ACIK] AS Ad, [Web-Malzeme].[BARKOD] AS Barkod, dbo.PozitifGetir([KurumsalWebSAP].dbo.[Web-Malzeme].[STOK] - ISNULL((SELECT sum(BKL_AD) FROM [SAP_SIPARIS_STR_DRM] WHERE SIP_TAR >= DATEADD(month,-3,getdate()) AND MALZ_KOD = [Web-Malzeme].[ITEMREF]),0)) AS STOK, [Web-Malzeme].[KOLI], [Web-Fiyat].[NET+KDV] AS Fiyat, [Web-Fiyat].VADE " +
                    "FROM [Web-Malzeme] INNER JOIN [Web-Fiyat] ON [Web-Malzeme].[ITEMREF] = [Web-Fiyat].[ITEMREF] INNER JOIN [Web-Malzeme-Hiyerarsi] ON [Web-Malzeme].HYRS = [Web-Malzeme-Hiyerarsi].KOD " +
                    besyuzlufiltreleme + 
                    "WHERE [Web-Fiyat].[TIP] = " + FiyatTipi + " " +
                    belliurunler + 
                    "ORDER BY METIN ASC,[Web-Malzeme].[MAL ACIK] ASC", conn);
                da.SelectCommand.CommandTimeout = 400;
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
        /// [Web-Fiyat] [Web-Malzeme] **************
        /// </summary>
        public static int GetProductsCount(string FiyatTipi, string TedarikciOperator, string Tedarikci,
            string KategoriOperator, string Kategori, string AramaBasi, string Aranan, ArrayList OzelKodlar, ArrayList GrupKodlar, bool Yeni)
        {
            int donendeger = 0;

            string ozelkodlar = string.Empty;
            string grupkodlar = string.Empty;

            for (int i = 0; i < OzelKodlar.Count; i++)
                ozelkodlar += "[KurumsalWebSAP].dbo.[Web-Malzeme].[OZEL KOD] = '" + OzelKodlar[i].ToString() + "' OR ";

            if (OzelKodlar.Count > 0)
                ozelkodlar = "(" + ozelkodlar.Substring(0, ozelkodlar.Length - 4) + ") AND ";

            for (int i = 0; i < GrupKodlar.Count; i++)
                grupkodlar += "[KurumsalWebSAP].dbo.[Web-Malzeme].[GRUP KOD] = '" + GrupKodlar[i].ToString() + "' OR ";

            if (GrupKodlar.Count > 0)
                grupkodlar = "(" + grupkodlar.Substring(0, grupkodlar.Length - 4) + ") AND ";



            Aranan = Aranan.ToUpper().Replace("'", " ").Replace("%", "").Replace("--", "").Replace("/*", "").Replace("*/", "").Replace(" OR ", " ").Replace(" AND ", " ").Replace(" LIKE ", " ");
            //Aranan = Aranan.ToUpper().Replace("İ", "I").Replace("Ü", "U").Replace("Ö", "O").Replace("Ş", "S").Replace("Ç", "C").Replace("Ğ", "G");

            string malacik = string.Empty;
            string[] aramakelimeler = new string[1];

            if (AramaBasi == string.Empty)
                aramakelimeler[0] = Aranan;
            else
                aramakelimeler = Aranan.Split(new string[] { " " }, StringSplitOptions.None);

            for (int i = 0; i < aramakelimeler.Length; i++)
                malacik += "[KurumsalWebSAP].dbo.[Web-Malzeme].[MAL ACIK] LIKE '" + AramaBasi + aramakelimeler[i] + "%' AND ";

            if (malacik == string.Empty)
                malacik = "[KurumsalWebSAP].dbo.[Web-Malzeme].[MAL ACIK] IS NOT NULL ";
            else
                malacik = malacik.Substring(0, malacik.Length - 4);



            string YeniUrunler = string.Empty;
            if (Yeni)
                YeniUrunler = "AND [KurumsalWebSAP].dbo.[Web-Malzeme].[KYTM] < 60 ";

            string besyuzlufiltreleme = string.Empty;
            if (Convert.ToInt32(FiyatTipi) > 500)
                besyuzlufiltreleme = "INNER JOIN [Web-FiyatTip-Urun] ON [Web-Malzeme].ITEMREF = [Web-FiyatTip-Urun].ITEMREF AND [Web-FiyatTip-Urun].TIP = " + FiyatTipi + " ";

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT count([KurumsalWebSAP].dbo.[Web-Malzeme].[ITEMREF]) FROM [KurumsalWebSAP].dbo.[Web-Malzeme] " +
                    "INNER JOIN [KurumsalWebSAP].dbo.[Web-Fiyat] ON [KurumsalWebSAP].dbo.[Web-Malzeme].[ITEMREF] = [KurumsalWebSAP].dbo.[Web-Fiyat].[ITEMREF] " +
                    besyuzlufiltreleme + 
                    "WHERE [KurumsalWebSAP].dbo.[Web-Fiyat].[TIP] = " + FiyatTipi + " AND [KurumsalWebSAP].dbo.[Web-Malzeme].[OZEL KOD] "
                    + TedarikciOperator + " " + Tedarikci + " AND " +
                    "[KurumsalWebSAP].dbo.[Web-Malzeme].[REY KOD] " + KategoriOperator + " " + Kategori + " AND " + ozelkodlar + grupkodlar +
                    malacik + YeniUrunler, conn);
                cmd.CommandTimeout = 400;
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
        /// [Web-Fiyat] [Web-Malzeme] çoklu tedarikçi ve kategori seçimi
        /// </summary>
        public static int GetProductsCount(string FiyatTipi, ArrayList Tedarikciler, ArrayList Kategoriler, 
            string AramaBasi, string Aranan, ArrayList OzelKodlar, ArrayList GrupKodlar, bool Yeni)
        {
            int donendeger = 0;

            string ozelkodlar = string.Empty;
            string grupkodlar = string.Empty;
            string tedarikciler = string.Empty;
            string kategoriler = string.Empty;



            for (int i = 0; i < OzelKodlar.Count; i++)
                ozelkodlar += "[KurumsalWebSAP].dbo.[Web-Malzeme].[OZEL KOD] = '" + OzelKodlar[i].ToString() + "' OR ";

            if (OzelKodlar.Count > 0)
                ozelkodlar = "(" + ozelkodlar.Substring(0, ozelkodlar.Length - 4) + ") AND ";

            for (int i = 0; i < GrupKodlar.Count; i++)
                grupkodlar += "[KurumsalWebSAP].dbo.[Web-Malzeme].[GRUP KOD] = '" + GrupKodlar[i].ToString() + "' OR ";

            if (GrupKodlar.Count > 0)
                grupkodlar = "(" + grupkodlar.Substring(0, grupkodlar.Length - 4) + ") AND ";



            for (int i = 0; i < Tedarikciler.Count; i++)
                tedarikciler += "[KurumsalWebSAP].dbo.[Web-Malzeme].[OZEL KOD] = '" + Tedarikciler[i].ToString() + "' OR ";

            if (Tedarikciler.Count > 0)
                tedarikciler = "(" + tedarikciler.Substring(0, tedarikciler.Length - 4) + ") AND ";



            for (int i = 0; i < Kategoriler.Count; i++)
                kategoriler += "[KurumsalWebSAP].dbo.[Web-Malzeme].[REY KOD] = '" + Tedarikciler[i].ToString() + "' OR ";

            if (Kategoriler.Count > 0)
                kategoriler = "(" + kategoriler.Substring(0, kategoriler.Length - 4) + ") AND ";



            Aranan = Aranan.ToUpper().Replace("'", " ").Replace("%", "").Replace("--", "").Replace("/*", "").Replace("*/", "").Replace(" OR ", " ").Replace(" AND ", " ").Replace(" LIKE ", " ");
            //Aranan = Aranan.ToUpper().Replace("İ", "I").Replace("Ü", "U").Replace("Ö", "O").Replace("Ş", "S").Replace("Ç", "C").Replace("Ğ", "G");

            string malacik = string.Empty;
            string[] aramakelimeler = new string[1];

            if (AramaBasi == string.Empty)
                aramakelimeler[0] = Aranan;
            else
                aramakelimeler = Aranan.Split(new string[] { " " }, StringSplitOptions.None);

            for (int i = 0; i < aramakelimeler.Length; i++)
                malacik += "[KurumsalWebSAP].dbo.[Web-Malzeme].[MAL ACIK] LIKE '" + AramaBasi + aramakelimeler[i] + "%' AND ";

            if (malacik == string.Empty)
                malacik = "[KurumsalWebSAP].dbo.[Web-Malzeme].[MAL ACIK] IS NOT NULL ";
            else
                malacik = malacik.Substring(0, malacik.Length - 4);



            string YeniUrunler = string.Empty;
            if (Yeni)
                YeniUrunler = "AND [KurumsalWebSAP].dbo.[Web-Malzeme].[KYTM] < 60 ";

            string besyuzlufiltreleme = string.Empty;
            if (Convert.ToInt32(FiyatTipi) > 500)
                besyuzlufiltreleme = "INNER JOIN [Web-FiyatTip-Urun] ON [Web-Malzeme].ITEMREF = [Web-FiyatTip-Urun].ITEMREF AND [Web-FiyatTip-Urun].TIP = " + FiyatTipi + " ";

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT count([KurumsalWebSAP].dbo.[Web-Malzeme].[ITEMREF]) FROM [KurumsalWebSAP].dbo.[Web-Malzeme] " +
                    "INNER JOIN [KurumsalWebSAP].dbo.[Web-Fiyat] ON [KurumsalWebSAP].dbo.[Web-Malzeme].[ITEMREF] = [KurumsalWebSAP].dbo.[Web-Fiyat].[ITEMREF] " +
                    besyuzlufiltreleme + 
                    "WHERE [KurumsalWebSAP].dbo.[Web-Fiyat].[TIP] = " + FiyatTipi + " AND " +
                    tedarikciler + kategoriler + ozelkodlar + grupkodlar +
                    malacik + YeniUrunler, conn);
                cmd.CommandTimeout = 400;
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
        /// [Web-Fiyat] [Web-Malzeme] çoklu tedarikçi ve kategori seçimi
        /// </summary>
        public static int GetProductsCount(string FiyatTipi, ArrayList Tedarikciler, ArrayList Kategoriler,
            string AramaBasi, string Aranan, ArrayList OzelKodlar, ArrayList GrupKodlar, bool Yeni, ArrayList Hyrs)
        {
            int donendeger = 0;

            string ozelkodlar = string.Empty;
            string grupkodlar = string.Empty;
            string tedarikciler = string.Empty;
            string hyrs = string.Empty;
            string kategoriler = string.Empty;



            for (int i = 0; i < OzelKodlar.Count; i++)
                ozelkodlar += "[KurumsalWebSAP].dbo.[Web-Malzeme].[OZEL KOD] = '" + OzelKodlar[i].ToString() + "' OR ";

            if (OzelKodlar.Count > 0)
                ozelkodlar = "(" + ozelkodlar.Substring(0, ozelkodlar.Length - 4) + ") AND ";

            for (int i = 0; i < GrupKodlar.Count; i++)
                grupkodlar += "[KurumsalWebSAP].dbo.[Web-Malzeme].[GRUP KOD] = '" + GrupKodlar[i].ToString() + "' OR ";

            if (GrupKodlar.Count > 0)
                grupkodlar = "(" + grupkodlar.Substring(0, grupkodlar.Length - 4) + ") AND ";



            for (int i = 0; i < Tedarikciler.Count; i++)
                tedarikciler += "[KurumsalWebSAP].dbo.[Web-Malzeme].[OZEL KOD] = '" + Tedarikciler[i].ToString() + "' OR ";

            if (Tedarikciler.Count > 0)
                tedarikciler = "(" + tedarikciler.Substring(0, tedarikciler.Length - 4) + ") AND ";



            for (int i = 0; i < Kategoriler.Count; i++)
                kategoriler += "[KurumsalWebSAP].dbo.[Web-Malzeme].[REY KOD] = '" + Tedarikciler[i].ToString() + "' OR ";

            if (Kategoriler.Count > 0)
                kategoriler = "(" + kategoriler.Substring(0, kategoriler.Length - 4) + ") AND ";



            for (int i = 0; i < Hyrs.Count; i++)
                hyrs += "[KurumsalWebSAP].dbo.[Web-Malzeme].[HYRS] = '" + Hyrs[i].ToString() + "' OR ";

            if (Hyrs.Count > 0)
                hyrs = "(" + hyrs.Substring(0, hyrs.Length - 4) + ") AND ";



            Aranan = Aranan.ToUpper().Replace("'", " ").Replace("%", "").Replace("--", "").Replace("/*", "").Replace("*/", "").Replace(" OR ", " ").Replace(" AND ", " ").Replace(" LIKE ", " ");
            //Aranan = Aranan.ToUpper().Replace("İ", "I").Replace("Ü", "U").Replace("Ö", "O").Replace("Ş", "S").Replace("Ç", "C").Replace("Ğ", "G");

            string malacik = string.Empty;
            string[] aramakelimeler = new string[1];

            if (AramaBasi == string.Empty)
                aramakelimeler[0] = Aranan;
            else
                aramakelimeler = Aranan.Split(new string[] { " " }, StringSplitOptions.None);

            for (int i = 0; i < aramakelimeler.Length; i++)
                malacik += "[KurumsalWebSAP].dbo.[Web-Malzeme].[MAL ACIK] LIKE '" + AramaBasi + aramakelimeler[i] + "%' AND ";

            if (malacik == string.Empty)
                malacik = "[KurumsalWebSAP].dbo.[Web-Malzeme].[MAL ACIK] IS NOT NULL ";
            else
                malacik = malacik.Substring(0, malacik.Length - 4);



            string YeniUrunler = string.Empty;
            if (Yeni)
                YeniUrunler = "AND [KurumsalWebSAP].dbo.[Web-Malzeme].[KYTM] < 60 ";

            string besyuzlufiltreleme = string.Empty;
            if (Convert.ToInt32(FiyatTipi) > 500)
                besyuzlufiltreleme = "INNER JOIN [Web-FiyatTip-Urun] ON [Web-Malzeme].ITEMREF = [Web-FiyatTip-Urun].ITEMREF AND [Web-FiyatTip-Urun].TIP = " + FiyatTipi + " ";

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT count([KurumsalWebSAP].dbo.[Web-Malzeme].[ITEMREF]) FROM [KurumsalWebSAP].dbo.[Web-Malzeme] " +
                    "INNER JOIN [KurumsalWebSAP].dbo.[Web-Fiyat] ON [KurumsalWebSAP].dbo.[Web-Malzeme].[ITEMREF] = [KurumsalWebSAP].dbo.[Web-Fiyat].[ITEMREF] " +
                    besyuzlufiltreleme +
                    "WHERE [KurumsalWebSAP].dbo.[Web-Fiyat].[TIP] = " + FiyatTipi + " AND " +
                    tedarikciler + hyrs + kategoriler + ozelkodlar + grupkodlar +
                    malacik + YeniUrunler, conn);
                cmd.CommandTimeout = 400;
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
        /// [Web-Fiyat] [Web-Malzeme], webservice için
        /// </summary>
        public static int GetProductsCount(string FiyatTipi, string Aranan)
        {
            int donendeger = 0;

            Aranan = Aranan.ToUpper().Replace("'", " ").Replace("%", "").Replace("--", "").Replace("/*", "").Replace("*/", "").Replace(" OR ", " ").Replace(" AND ", " ").Replace(" LIKE ", " ");
            //Aranan = Aranan.ToUpper().Replace("İ", "I").Replace("Ü", "U").Replace("Ö", "O").Replace("Ş", "S").Replace("Ç", "C").Replace("Ğ", "G");

            string malacik = string.Empty;
            string[] aramakelimeler = new string[1];

            aramakelimeler = Aranan.Split(new string[] { " " }, StringSplitOptions.None);

            for (int i = 0; i < aramakelimeler.Length; i++)
                malacik += "[KurumsalWebSAP].dbo.[Web-Malzeme].[MAL ACIK] LIKE '%" + aramakelimeler[i] + "%' AND ";

            if (malacik == string.Empty)
                malacik = "[KurumsalWebSAP].dbo.[Web-Malzeme].[MAL ACIK] IS NOT NULL ";
            else
                malacik = malacik.Substring(0, malacik.Length - 4);

            string besyuzlufiltreleme = string.Empty;
            if (Convert.ToInt32(FiyatTipi) > 500)
                besyuzlufiltreleme = "INNER JOIN [Web-FiyatTip-Urun] ON [Web-Malzeme].ITEMREF = [Web-FiyatTip-Urun].ITEMREF AND [Web-FiyatTip-Urun].TIP = " + FiyatTipi + " ";

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT count([KurumsalWebSAP].dbo.[Web-Malzeme].[ITEMREF]) FROM [KurumsalWebSAP].dbo.[Web-Malzeme] " +
                    "INNER JOIN [KurumsalWebSAP].dbo.[Web-Fiyat] ON [KurumsalWebSAP].dbo.[Web-Malzeme].[ITEMREF] = [KurumsalWebSAP].dbo.[Web-Fiyat].[ITEMREF] " +
                    besyuzlufiltreleme + 
                    "WHERE [KurumsalWebSAP].dbo.[Web-Fiyat].[TIP] = " + FiyatTipi + " AND " + malacik, conn);
                cmd.CommandTimeout = 400;
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
        //
        //
        #endregion
        //
        //
        #region kullanılmıyor (ürün aktif pasif)
        /// <summary>
        /// [Web-Malzeme-Full]
        /// </summary>
        public static void GetProductsKullanimdakiler(DataTable dt, bool Kullanimdakiler)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT [OZEL KOD] AS OKOD,ITEMREF,[MAL ACIK] AS MALZEME FROM [Web-Malzeme-Full] WHERE AP = " + 
                    (Kullanimdakiler ? "0" : "1")
                    + " ORDER BY [MAL ACIK] ASC", conn);
                da.SelectCommand.CommandTimeout = 400;
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
        /// [Web-Malzeme-AP] [Web-Malzeme-Full] [Web-Malzeme], kullanım içi kullanım dışı sap yerine bizden yapmak için
        /// </summary>
        public static void SetKullanimda(int ITEMREF, bool Kullanimda, string Kullanici)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UPDATE [Web-Malzeme-AP] SET AP = @AP WHERE ITEMREF = @ITEMREF"
                    + " UPDATE [Web-Malzeme-Full] SET AP = @AP WHERE ITEMREF = @ITEMREF", conn);
                cmd.Parameters.Add("@AP", SqlDbType.Int).Value = Kullanimda ? 0 : 1;
                cmd.Parameters.Add("@ITEMREF", SqlDbType.Int).Value = ITEMREF;
                cmd.CommandTimeout = 400;

                SqlCommand cmd1 = new SqlCommand();
                cmd1.Connection = conn;
                cmd1.CommandTimeout = 400;
                cmd1.Parameters.Add("@ITEMREF", SqlDbType.Int).Value = ITEMREF;
                if (Kullanimda)
                    cmd1.CommandText = "INSERT INTO [Web-Malzeme] SELECT [ITEMREF],[MAL KOD],[MAL ACIK],[URT KOD],[ES KOD],[BIRIMREF],[BIRIM],[GRUP KOD],[GRUP ACIK],[OZEL KOD],[HK],[OZEL ACIK],[REY KOD],[RK],[REY ACIK],[KDV],[KOLI],[BARKOD],[STOK],[KYTM],[KANAL],[PRIMT],[PRIMB],[HYRS],[HYRS_TANIM] FROM [Web-Malzeme-Full] WHERE ITEMREF = @ITEMREF";
                else
                    cmd1.CommandText = "DELETE FROM [Web-Malzeme] WHERE ITEMREF = @ITEMREF";

                SqlCommand cmd2 = new SqlCommand("INSERT INTO [Web-Malzeme-AP-Log] (ITEMREF,AP,strKullanici,dtTarih) VALUES (@ITEMREF,@AP,@strKullanici,@dtTarih)", conn);
                cmd2.Connection = conn;
                cmd2.CommandTimeout = 400;
                cmd2.Parameters.Add("@ITEMREF", SqlDbType.Int).Value = ITEMREF;
                cmd2.Parameters.Add("@AP", SqlDbType.Int).Value = Kullanimda ? 0 : 1;
                cmd2.Parameters.Add("@strKullanici", SqlDbType.NVarChar, 20).Value = Kullanici;
                cmd2.Parameters.Add("@dtTarih", SqlDbType.DateTime).Value = DateTime.Now;

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    cmd1.ExecuteNonQuery();
                    cmd2.ExecuteNonQuery();
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
        /// [Web-Malzeme-Full], kullanım içi kullanım dışı log
        /// </summary>
        public static void GetProductsKullanimdakilerLog(DataTable dt, int ITEMREF)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT ITEMREF,CASE WHEN AP = 0 THEN CONVERT(bit,'True') ELSE CONVERT(bit,'False') END AS AP,strKullanici,dtTarih FROM [Web-Malzeme-AP-Log] WHERE ITEMREF = @ITEMREF ORDER BY dtTarih DESC", conn);
                da.SelectCommand.CommandTimeout = 400;
                da.SelectCommand.Parameters.Add("@ITEMREF", SqlDbType.Int).Value = ITEMREF;
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
        #endregion
        //
        //
        #region AKTİVİTE İÇİN DÖNEMLİ
        //
        //
        /// <summary>
        /// [Web-Fiyat-TP] [Web-Malzeme-Full]
        /// </summary>
        public static void GetProducts(DataTable dt, int Start, int Count, string FiyatTipi, string TedarikciOperator, string Tedarikci,
            string KategoriOperator, string Kategori, string AramaBasi, string Aranan, string Siralama, string AzalanArtan,
            ArrayList OzelKodlar, ArrayList GrupKodlar, bool Yeni, int Yil, int Ay)
        {
            string yil = string.Empty, ay = string.Empty;
            if (Yil > DateTime.Now.Year || (Yil == DateTime.Now.Year && Ay > DateTime.Now.Month))
            {
                yil = DateTime.Now.Year.ToString(); ay = DateTime.Now.Month.ToString();
            }
            else
            {
                yil = Yil.ToString(); ay = Ay.ToString();
            }

            string ozelkodlar = string.Empty;
            string grupkodlar = string.Empty;

            for (int i = 0; i < OzelKodlar.Count; i++)
                ozelkodlar += "[KurumsalWebSAP].dbo.[Web-Malzeme-Full].[OZEL KOD] = '" + OzelKodlar[i].ToString() + "' OR ";

            if (OzelKodlar.Count > 0)
                ozelkodlar = "(" + ozelkodlar.Substring(0, ozelkodlar.Length - 4) + ") AND ";

            for (int i = 0; i < GrupKodlar.Count; i++)
                grupkodlar += "[KurumsalWebSAP].dbo.[Web-Malzeme-Full].[GRUP KOD] = '" + GrupKodlar[i].ToString() + "' OR ";

            if (GrupKodlar.Count > 0)
                grupkodlar = "(" + grupkodlar.Substring(0, grupkodlar.Length - 4) + ") AND ";



            Aranan = Aranan.ToUpper().Replace("'", " ").Replace("%", "").Replace("--", "").Replace("/*", "").Replace("*/", "").Replace(" OR ", " ").Replace(" AND ", " ").Replace(" LIKE ", " ");
            //Aranan = Aranan.ToUpper().Replace("İ", "I").Replace("Ü", "U").Replace("Ö", "O").Replace("Ş", "S").Replace("Ç", "C").Replace("Ğ", "G");

            string malacik = string.Empty;
            string[] aramakelimeler = new string[1];

            if (AramaBasi == string.Empty)
                aramakelimeler[0] = Aranan;
            else
                aramakelimeler = Aranan.Split(new string[] { " " }, StringSplitOptions.None);

            for (int i = 0; i < aramakelimeler.Length; i++)
                malacik += "[KurumsalWebSAP].dbo.[Web-Malzeme-Full].[MAL ACIK] LIKE '" + AramaBasi + aramakelimeler[i] + "%' AND ";

            if (malacik == string.Empty)
                malacik = "[KurumsalWebSAP].dbo.[Web-Malzeme-Full].[MAL ACIK] IS NOT NULL ";
            else
                malacik = malacik.Substring(0, malacik.Length - 4);



            string YeniUrunler = string.Empty;
            if (Yeni)
                YeniUrunler = "AND [KurumsalWebSAP].dbo.[Web-Malzeme-Full].[KYTM] < 60 ";



            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT " +
                    "IsNull((SELECT TOP 1 intResimID FROM tblINTERNET_UrunResim WHERE ITEMREF = [KurumsalWebSAP].dbo.[Web-Malzeme-Full].[ITEMREF]), 0) AS pkResimID, " +
                    "[KurumsalWebSAP].dbo.[Web-Malzeme-Full].[ITEMREF] AS UrunID, [KurumsalWebSAP].dbo.[Web-Malzeme-Full].[URT KOD] AS URTKOD, [KurumsalWebSAP].dbo.[Web-Malzeme-Full].[MAL ACIK] AS Ad, [KurumsalWebSAP].dbo.[Web-Malzeme-Full].[OZEL KOD] AS TedarikciID, [KurumsalWebSAP].dbo.[Web-Malzeme-Full].[OZEL ACIK] AS TedarikciAdi, [KurumsalWebSAP].dbo.[Web-Malzeme-Full].[REY KOD] AS KategoriID, [KurumsalWebSAP].dbo.[Web-Malzeme-Full].[REY ACIK] AS KategoriAdi, [KurumsalWebSAP].dbo.[Web-Malzeme-Full].[KOLI] AS Adet, [KurumsalWebSAP].dbo.[Web-Malzeme-Full].[BARKOD] AS Barkod, [KurumsalWebSAP].dbo.[Web-Malzeme-Full].[STOK], count([KurumsalWebSAP].dbo.[Web-Fiyat-TP].[KAMKARTREF]) AS KamKartRefSayisi, [KurumsalWebSAP].dbo.[Web-Fiyat-TP].[FIYAT] AS BRUT, [KurumsalWebSAP].dbo.[Web-Fiyat-TP].[ISK1], [KurumsalWebSAP].dbo.[Web-Fiyat-TP].[ISK2], [KurumsalWebSAP].dbo.[Web-Fiyat-TP].[ISK3], [KurumsalWebSAP].dbo.[Web-Fiyat-TP].[ISK4], [KurumsalWebSAP].dbo.[Web-Fiyat-TP].[ISK5], [KurumsalWebSAP].dbo.[Web-Fiyat-TP].[ISK6], [KurumsalWebSAP].dbo.[Web-Fiyat-TP].[ISK7], [KurumsalWebSAP].dbo.[Web-Fiyat-TP].[ISK8], [KurumsalWebSAP].dbo.[Web-Fiyat-TP].[ISK9], [KurumsalWebSAP].dbo.[Web-Fiyat-TP].[ISK10], [KurumsalWebSAP].dbo.[Web-Malzeme-Full].[KDV], [KurumsalWebSAP].dbo.[Web-Fiyat-TP].[NET+KDV] AS Fiyat, [KurumsalWebSAP].dbo.[Web-Malzeme-Full].[KYTM] " +
                    "FROM [KurumsalWebSAP].dbo.[Web-Malzeme-Full] INNER JOIN [KurumsalWebSAP].dbo.[Web-Fiyat-TP] ON [KurumsalWebSAP].dbo.[Web-Malzeme-Full].[ITEMREF] = [KurumsalWebSAP].dbo.[Web-Fiyat-TP].[ITEMREF] " +
                    "WHERE [KurumsalWebSAP].dbo.[Web-Fiyat-TP].[TIP] = " + FiyatTipi +
                    " AND [KurumsalWebSAP].dbo.[Web-Fiyat-TP].YIL = " + yil + " AND [KurumsalWebSAP].dbo.[Web-Fiyat-TP].AY = " + ay +
                    " AND [KurumsalWebSAP].dbo.[Web-Malzeme-Full].[OZEL KOD] " +
                    TedarikciOperator + " " + Tedarikci + " AND " +
                    "[KurumsalWebSAP].dbo.[Web-Malzeme-Full].[REY KOD] " + KategoriOperator + " " + Kategori + " AND " + ozelkodlar + grupkodlar +
                    malacik +
                    YeniUrunler +
                    "GROUP BY [KurumsalWebSAP].dbo.[Web-Malzeme-Full].[ITEMREF], [KurumsalWebSAP].dbo.[Web-Malzeme-Full].[URT KOD], [KurumsalWebSAP].dbo.[Web-Malzeme-Full].[MAL ACIK], [KurumsalWebSAP].dbo.[Web-Malzeme-Full].[OZEL KOD], [KurumsalWebSAP].dbo.[Web-Malzeme-Full].[OZEL ACIK], [KurumsalWebSAP].dbo.[Web-Malzeme-Full].[REY KOD], [KurumsalWebSAP].dbo.[Web-Malzeme-Full].[REY ACIK], [KurumsalWebSAP].dbo.[Web-Malzeme-Full].[KOLI], [KurumsalWebSAP].dbo.[Web-Malzeme-Full].[BARKOD], [KurumsalWebSAP].dbo.[Web-Malzeme-Full].[STOK], [KurumsalWebSAP].dbo.[Web-Fiyat-TP].[FIYAT], [KurumsalWebSAP].dbo.[Web-Fiyat-TP].[ISK1], [KurumsalWebSAP].dbo.[Web-Fiyat-TP].[ISK2], [KurumsalWebSAP].dbo.[Web-Fiyat-TP].[ISK3], [KurumsalWebSAP].dbo.[Web-Fiyat-TP].[ISK4], [KurumsalWebSAP].dbo.[Web-Fiyat-TP].[ISK5], [KurumsalWebSAP].dbo.[Web-Fiyat-TP].[ISK6], [KurumsalWebSAP].dbo.[Web-Fiyat-TP].[ISK7], [KurumsalWebSAP].dbo.[Web-Fiyat-TP].[ISK8], [KurumsalWebSAP].dbo.[Web-Fiyat-TP].[ISK9], [KurumsalWebSAP].dbo.[Web-Fiyat-TP].[ISK10], [KurumsalWebSAP].dbo.[Web-Malzeme-Full].[KDV], [KurumsalWebSAP].dbo.[Web-Fiyat-TP].[NET+KDV], [KurumsalWebSAP].dbo.[Web-Malzeme-Full].[KYTM] " +
                    "ORDER BY " + Siralama + " " + AzalanArtan + ", [KurumsalWebSAP].dbo.[Web-Malzeme-Full].[MAL ACIK] ASC", conn);
                da.SelectCommand.CommandTimeout = 400;
                try
                {
                    conn.Open();
                    da.Fill(Start, Count, dt);
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
        /// [Web-Fiyat-TP] [Web-Malzeme-Full]
        /// </summary>
        public static void GetProducts(DataTable dt, string FiyatTipi, string Urtkod, ArrayList OzelKodlar, ArrayList GrupKodlar, 
            bool urtkod, bool urtkod1, int Yil, int Ay)
        {
            string yil = string.Empty, ay = string.Empty;
            if (Yil > DateTime.Now.Year || (Yil == DateTime.Now.Year && Ay > DateTime.Now.Month))
            {
                yil = DateTime.Now.Year.ToString(); ay = DateTime.Now.Month.ToString();
            }
            else
            {
                yil = Yil.ToString(); ay = Ay.ToString();
            }

            string ozelkodlar = string.Empty;
            string grupkodlar = string.Empty;

            for (int i = 0; i < OzelKodlar.Count; i++)
                ozelkodlar += "[KurumsalWebSAP].dbo.[Web-Malzeme-Full].[OZEL KOD] = '" + OzelKodlar[i].ToString() + "' OR ";

            if (OzelKodlar.Count > 0)
                ozelkodlar = "(" + ozelkodlar.Substring(0, ozelkodlar.Length - 4) + ") AND ";

            for (int i = 0; i < GrupKodlar.Count; i++)
                grupkodlar += "[KurumsalWebSAP].dbo.[Web-Malzeme-Full].[GRUP KOD] = '" + GrupKodlar[i].ToString() + "' OR ";

            if (GrupKodlar.Count > 0)
                grupkodlar = "(" + grupkodlar.Substring(0, grupkodlar.Length - 4) + ") AND ";

            Urtkod = Urtkod.ToUpper().Replace("'", " ").Replace("%", "").Replace("--", "").Replace("/*", "").Replace("*/", "").Replace(" OR ", " ").Replace(" AND ", " ").Replace(" LIKE ", " ");

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT " +
                    "IsNull((SELECT TOP 1 intResimID FROM tblINTERNET_UrunResim WHERE ITEMREF = [KurumsalWebSAP].dbo.[Web-Malzeme-Full].[ITEMREF]), 0) AS pkResimID, " +
                    "[KurumsalWebSAP].dbo.[Web-Malzeme-Full].[ITEMREF] AS UrunID, [KurumsalWebSAP].dbo.[Web-Malzeme-Full].[URT KOD] AS URTKOD, [KurumsalWebSAP].dbo.[Web-Malzeme-Full].[MAL ACIK] AS Ad, [KurumsalWebSAP].dbo.[Web-Malzeme-Full].[OZEL KOD] AS TedarikciID, [KurumsalWebSAP].dbo.[Web-Malzeme-Full].[OZEL ACIK] AS TedarikciAdi, [KurumsalWebSAP].dbo.[Web-Malzeme-Full].[REY KOD] AS KategoriID, [KurumsalWebSAP].dbo.[Web-Malzeme-Full].[REY ACIK] AS KategoriAdi, [KurumsalWebSAP].dbo.[Web-Malzeme-Full].[KOLI] AS Adet, [KurumsalWebSAP].dbo.[Web-Malzeme-Full].[BARKOD] AS Barkod, [KurumsalWebSAP].dbo.[Web-Malzeme-Full].[STOK], count([KurumsalWebSAP].dbo.[Web-Fiyat-TP].[KAMKARTREF]) AS KamKartRefSayisi, [KurumsalWebSAP].dbo.[Web-Fiyat-TP].[FIYAT] AS BRUT, [KurumsalWebSAP].dbo.[Web-Fiyat-TP].[ISK1], [KurumsalWebSAP].dbo.[Web-Fiyat-TP].[ISK2], [KurumsalWebSAP].dbo.[Web-Fiyat-TP].[ISK3], [KurumsalWebSAP].dbo.[Web-Fiyat-TP].[ISK4], [KurumsalWebSAP].dbo.[Web-Fiyat-TP].[ISK5], [KurumsalWebSAP].dbo.[Web-Fiyat-TP].[ISK6], [KurumsalWebSAP].dbo.[Web-Fiyat-TP].[ISK7], [KurumsalWebSAP].dbo.[Web-Fiyat-TP].[ISK8], [KurumsalWebSAP].dbo.[Web-Fiyat-TP].[ISK9], [KurumsalWebSAP].dbo.[Web-Fiyat-TP].[ISK10], [KurumsalWebSAP].dbo.[Web-Malzeme-Full].[KDV], [KurumsalWebSAP].dbo.[Web-Fiyat-TP].[NET+KDV] AS Fiyat, [KurumsalWebSAP].dbo.[Web-Malzeme-Full].[KYTM] " +
                    "FROM [KurumsalWebSAP].dbo.[Web-Malzeme-Full] INNER JOIN [KurumsalWebSAP].dbo.[Web-Fiyat-TP] ON [KurumsalWebSAP].dbo.[Web-Malzeme-Full].[ITEMREF] = [KurumsalWebSAP].dbo.[Web-Fiyat-TP].[ITEMREF] " +
                    "WHERE [KurumsalWebSAP].dbo.[Web-Fiyat-TP].[TIP] = " + FiyatTipi +
                    " AND [KurumsalWebSAP].dbo.[Web-Fiyat-TP].YIL = " + yil + " AND [KurumsalWebSAP].dbo.[Web-Fiyat-TP].AY = " + ay +
                    " AND " + ozelkodlar + grupkodlar +
                    "[KurumsalWebSAP].dbo.[Web-Malzeme-Full].[URT KOD] = '" + Urtkod + "' " +
                    "GROUP BY [KurumsalWebSAP].dbo.[Web-Malzeme-Full].[ITEMREF], [KurumsalWebSAP].dbo.[Web-Malzeme-Full].[URT KOD], [KurumsalWebSAP].dbo.[Web-Malzeme-Full].[MAL ACIK], [KurumsalWebSAP].dbo.[Web-Malzeme-Full].[OZEL KOD], [KurumsalWebSAP].dbo.[Web-Malzeme-Full].[OZEL ACIK], [KurumsalWebSAP].dbo.[Web-Malzeme-Full].[REY KOD], [KurumsalWebSAP].dbo.[Web-Malzeme-Full].[REY ACIK], [KurumsalWebSAP].dbo.[Web-Malzeme-Full].[KOLI], [KurumsalWebSAP].dbo.[Web-Malzeme-Full].[BARKOD], [KurumsalWebSAP].dbo.[Web-Malzeme-Full].[STOK], [KurumsalWebSAP].dbo.[Web-Fiyat-TP].[FIYAT], [KurumsalWebSAP].dbo.[Web-Fiyat-TP].[ISK1], [KurumsalWebSAP].dbo.[Web-Fiyat-TP].[ISK2], [KurumsalWebSAP].dbo.[Web-Fiyat-TP].[ISK3], [KurumsalWebSAP].dbo.[Web-Fiyat-TP].[ISK4], [KurumsalWebSAP].dbo.[Web-Fiyat-TP].[ISK5], [KurumsalWebSAP].dbo.[Web-Fiyat-TP].[ISK6], [KurumsalWebSAP].dbo.[Web-Fiyat-TP].[ISK7], [KurumsalWebSAP].dbo.[Web-Fiyat-TP].[ISK8], [KurumsalWebSAP].dbo.[Web-Fiyat-TP].[ISK9], [KurumsalWebSAP].dbo.[Web-Fiyat-TP].[ISK10], [KurumsalWebSAP].dbo.[Web-Malzeme-Full].[KDV], [KurumsalWebSAP].dbo.[Web-Fiyat-TP].[NET+KDV], [KurumsalWebSAP].dbo.[Web-Malzeme-Full].[KYTM]", conn);
                da.SelectCommand.CommandTimeout = 400;
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
        /// [Web-Fiyat-TP] [Web-Malzeme-Full]
        /// </summary>
        public static int GetProductsCount(string FiyatTipi, string TedarikciOperator, string Tedarikci,
            string KategoriOperator, string Kategori, string AramaBasi, string Aranan, ArrayList OzelKodlar, ArrayList GrupKodlar, bool Yeni, int Yil, int Ay)
        {
            int donendeger = 0;

            string yil = string.Empty, ay = string.Empty;
            if (Yil > DateTime.Now.Year || (Yil == DateTime.Now.Year && Ay > DateTime.Now.Month))
            {
                yil = DateTime.Now.Year.ToString(); ay = DateTime.Now.Month.ToString();
            }
            else
            {
                yil = Yil.ToString(); ay = Ay.ToString();
            }

            string ozelkodlar = string.Empty;
            string grupkodlar = string.Empty;

            for (int i = 0; i < OzelKodlar.Count; i++)
                ozelkodlar += "[KurumsalWebSAP].dbo.[Web-Malzeme-Full].[OZEL KOD] = '" + OzelKodlar[i].ToString() + "' OR ";

            if (OzelKodlar.Count > 0)
                ozelkodlar = "(" + ozelkodlar.Substring(0, ozelkodlar.Length - 4) + ") AND ";

            for (int i = 0; i < GrupKodlar.Count; i++)
                grupkodlar += "[KurumsalWebSAP].dbo.[Web-Malzeme-Full].[GRUP KOD] = '" + GrupKodlar[i].ToString() + "' OR ";

            if (GrupKodlar.Count > 0)
                grupkodlar = "(" + grupkodlar.Substring(0, grupkodlar.Length - 4) + ") AND ";



            Aranan = Aranan.ToUpper().Replace("'", " ").Replace("%", "").Replace("--", "").Replace("/*", "").Replace("*/", "").Replace(" OR ", " ").Replace(" AND ", " ").Replace(" LIKE ", " ");
            //Aranan = Aranan.ToUpper().Replace("İ", "I").Replace("Ü", "U").Replace("Ö", "O").Replace("Ş", "S").Replace("Ç", "C").Replace("Ğ", "G");

            string malacik = string.Empty;
            string[] aramakelimeler = new string[1];

            if (AramaBasi == string.Empty)
                aramakelimeler[0] = Aranan;
            else
                aramakelimeler = Aranan.Split(new string[] { " " }, StringSplitOptions.None);

            for (int i = 0; i < aramakelimeler.Length; i++)
                malacik += "[KurumsalWebSAP].dbo.[Web-Malzeme-Full].[MAL ACIK] LIKE '" + AramaBasi + aramakelimeler[i] + "%' AND ";

            if (malacik == string.Empty)
                malacik = "[KurumsalWebSAP].dbo.[Web-Malzeme-Full].[MAL ACIK] IS NOT NULL ";
            else
                malacik = malacik.Substring(0, malacik.Length - 4);



            string YeniUrunler = string.Empty;
            if (Yeni)
                YeniUrunler = "AND [KurumsalWebSAP].dbo.[Web-Malzeme-Full].[KYTM] < 60 ";

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT count([KurumsalWebSAP].dbo.[Web-Malzeme-Full].[ITEMREF]) FROM [KurumsalWebSAP].dbo.[Web-Malzeme-Full] " +
                    "INNER JOIN [KurumsalWebSAP].dbo.[Web-Fiyat-TP] ON [KurumsalWebSAP].dbo.[Web-Malzeme-Full].[ITEMREF] = [KurumsalWebSAP].dbo.[Web-Fiyat-TP].[ITEMREF] " +
                    "WHERE [KurumsalWebSAP].dbo.[Web-Fiyat-TP].[TIP] = " + FiyatTipi +
                    " AND [KurumsalWebSAP].dbo.[Web-Fiyat-TP].YIL = " + yil + " AND [KurumsalWebSAP].dbo.[Web-Fiyat-TP].AY = " + ay +
                    " AND [KurumsalWebSAP].dbo.[Web-Malzeme-Full].[OZEL KOD] "
                    + TedarikciOperator + " " + Tedarikci + " AND " +
                    "[KurumsalWebSAP].dbo.[Web-Malzeme-Full].[REY KOD] " + KategoriOperator + " " + Kategori + " AND " + ozelkodlar + grupkodlar +
                    malacik + YeniUrunler, conn);
                cmd.CommandTimeout = 400;
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
        /// [Web-Fiyat-TP], isk1 isk2 isk3 isk4 fiyat isk5 isk6 isk7 isk8 isk9 isk10
        /// </summary>
        public static double[] GetProductDiscountsAndPrice(int UrunID, int FiyatTipi, int Yil, int Ay)
        {
            double[] donendeger = new double[11];

            string yil = string.Empty, ay = string.Empty;
            if (Yil > DateTime.Now.Year || (Yil == DateTime.Now.Year && Ay > DateTime.Now.Month))
            {
                yil = DateTime.Now.Year.ToString(); ay = DateTime.Now.Month.ToString();
            }
            else
            {
                yil = Yil.ToString(); ay = Ay.ToString();
            }

            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3))
            {
                SqlCommand cmd = new SqlCommand("SELECT [ISK1],[ISK2],[ISK3],[ISK4],[FIYAT],[ISK5],[ISK6],[ISK7],[ISK8],[ISK9],[ISK10] FROM [KurumsalWebSAP].dbo.[Web-Fiyat-TP] WHERE YIL = @YIL AND AY = @AY AND [ITEMREF] = @ITEMREF AND TIP = @TIP", conn);
                cmd.Parameters.Add("@YIL", System.Data.SqlDbType.Int).Value = Convert.ToInt32(yil);
                cmd.Parameters.Add("@AY", System.Data.SqlDbType.Int).Value = Convert.ToInt32(ay);
                cmd.Parameters.Add("@ITEMREF", System.Data.SqlDbType.Int).Value = UrunID;
                cmd.Parameters.Add("@TIP", System.Data.SqlDbType.Int).Value = FiyatTipi;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        donendeger[0] = Convert.ToDouble(dr[0]);
                        donendeger[1] = Convert.ToDouble(dr[1]);
                        donendeger[2] = Convert.ToDouble(dr[2]);
                        donendeger[3] = Convert.ToDouble(dr[3]);
                        donendeger[4] = Convert.ToDouble(dr[4]);
                        donendeger[5] = Convert.ToDouble(dr[5]);
                        donendeger[6] = Convert.ToDouble(dr[6]);
                        donendeger[7] = Convert.ToDouble(dr[7]);
                        donendeger[8] = Convert.ToDouble(dr[8]);
                        donendeger[9] = Convert.ToDouble(dr[9]);
                        donendeger[10] = Convert.ToDouble(dr[10]);
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
        /// <summary>
        /// [Web-Fiyat-TP]
        /// </summary>
        public static decimal GetProductPrice(int UrunID, short FiyatTipi, int Yil, int Ay)
        {
            decimal donendeger = 0;

            string yil = string.Empty, ay = string.Empty;
            if (Yil > DateTime.Now.Year || (Yil == DateTime.Now.Year && Ay > DateTime.Now.Month))
            {
                yil = DateTime.Now.Year.ToString(); ay = DateTime.Now.Month.ToString();
            }
            else
            {
                yil = Yil.ToString(); ay = Ay.ToString();
            }

            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3))
            {
                SqlCommand cmd = new SqlCommand("SELECT [NET+KDV] FROM [KurumsalWebSAP].dbo.[Web-Fiyat-TP] WHERE YIL = @YIL AND AY = @AY AND [ITEMREF] = @ITEMREF AND [TIP] = @TIP", conn);
                cmd.Parameters.Add("@YIL", System.Data.SqlDbType.Int).Value = Convert.ToInt32(yil);
                cmd.Parameters.Add("@AY", System.Data.SqlDbType.Int).Value = Convert.ToInt32(ay);
                cmd.Parameters.Add("@ITEMREF", System.Data.SqlDbType.Int).Value = UrunID;
                cmd.Parameters.Add("@TIP", System.Data.SqlDbType.SmallInt).Value = FiyatTipi;
                try
                {
                    conn.Open();
                    object obj = cmd.ExecuteScalar();
                    if (obj != null)
                        donendeger = Convert.ToDecimal(obj);
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
        //
        //
        #endregion
        //
        //
        #region kategori tedarikci
        //
        //
        public static void GetKategoriler(string harf, ListItemCollection lic)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3))
            {
                SqlCommand cmd = new SqlCommand("SELECT CODE, NAME FROM [Web-Kategoriler] WHERE NAME LIKE '" + harf + "%' ORDER BY NAME", conn);
                SqlDataReader dr;
                
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        ListItem lst = new ListItem();
                        lst.Text = dr[1].ToString();
                        lst.Value = dr[0].ToString();
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
        public static void GetKategoriler(string harf, ListItemCollection lic, int FiyatTipiID)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3))
            {
                SqlCommand cmd = new SqlCommand("SELECT count([Web-Malzeme].[ITEMREF]),[Web-Kategoriler].[CODE],[Web-Kategoriler].[NAME] FROM [Web-Malzeme] INNER JOIN [Web-Kategoriler] ON [Web-Malzeme].[REY KOD] = [Web-Kategoriler].[CODE] INNER JOIN [Web-Fiyat] ON [Web-Malzeme].[ITEMREF] = [Web-Fiyat].[ITEMREF] WHERE [Web-Kategoriler].[NAME]  LIKE '" + harf + "%' AND [Web-Fiyat].[TIP] = " + FiyatTipiID.ToString() + " GROUP BY [Web-Kategoriler].[CODE],[Web-Kategoriler].[NAME] ORDER BY [Web-Kategoriler].[NAME]", conn);
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
        public static void GetKategoriler(ListItemCollection lic)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3))
            {
                SqlCommand cmd = new SqlCommand("SELECT CODE, NAME FROM [Web-Kategoriler] ORDER BY NAME", conn);
                SqlDataReader dr;

                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        ListItem lst = new ListItem();
                        lst.Text = dr[1].ToString();
                        lst.Value = dr[0].ToString();
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
        public static void GetTedarikciler(string harf, ListItemCollection lic)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3))
            {
                SqlCommand cmd = new SqlCommand("SELECT DISTINCT [OZEL KOD], [OZEL ACIK] FROM [Web-OzelKodlar] WHERE [OZEL ACIK] LIKE '" + harf + "%' ORDER BY [OZEL ACIK]", conn);
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        ListItem lst = new ListItem();
                        lst.Text = dr[1].ToString();
                        lst.Value = dr[0].ToString();
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
        public static void GetTedarikciler(string harf, ListItemCollection lic, int FiyatTipiID)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3))
            {
                SqlCommand cmd = new SqlCommand("SELECT count([Web-Malzeme].[ITEMREF]),[Web-OzelKodlar].[OZEL KOD],[Web-OzelKodlar].[OZEL ACIK] FROM [Web-Malzeme] INNER JOIN [Web-OzelKodlar] ON [Web-Malzeme].[OZEL KOD] = [Web-OzelKodlar].[OZEL KOD] WHERE [Web-OzelKodlar].[OZEL KOD] IN (SELECT [OZEL KOD] FROM [Web-OzelKodlar] WHERE [OZEL ACIK] LIKE '" + harf + "%') AND [Web-Malzeme].[ITEMREF] IN (SELECT [ITEMREF] FROM [Web-Fiyat] WHERE [Web-Fiyat].[TIP] = " + FiyatTipiID.ToString() + ") GROUP BY [Web-OzelKodlar].[OZEL KOD],[Web-OzelKodlar].[OZEL ACIK] ORDER BY [Web-OzelKodlar].[OZEL ACIK]", conn);
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
        public static void GetTedarikciler(ListItemCollection lic)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3))
            {
                SqlCommand cmd = new SqlCommand("SELECT DISTINCT [OZEL KOD], [OZEL ACIK] FROM [Web-OzelKodlar] ORDER BY [OZEL ACIK]", conn);
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        ListItem lst = new ListItem();
                        lst.Text = " " + dr[1].ToString();
                        lst.Value = dr[0].ToString();
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
        /// <summary>
        /// [WebMalzeme] [Web-Fiyat]
        /// </summary>
        public static void GetTedarikciHangiHarfler(DataTable dt, short FiyatTipi, /*string Tedarikci, string TedarikciOperator,*/
            string Kategori, string KategoriOperator, string AramaBasi, string Aranan, ArrayList OzelKodlar, ArrayList GrupKodlar)
        {
            string ozelkodlar = string.Empty;
            string grupkodlar = string.Empty;

            for (int i = 0; i < OzelKodlar.Count; i++)
                ozelkodlar += "[KurumsalWebSAP].dbo.[Web-Malzeme].[OZEL KOD] = '" + OzelKodlar[i].ToString() + "' OR ";

            if (OzelKodlar.Count > 0)
                ozelkodlar = "(" + ozelkodlar.Substring(0, ozelkodlar.Length - 4) + ") AND ";

            for (int i = 0; i < GrupKodlar.Count; i++)
                grupkodlar += "[KurumsalWebSAP].dbo.[Web-Malzeme].[GRUP KOD] = '" + GrupKodlar[i].ToString() + "' OR ";

            if (GrupKodlar.Count > 0)
                grupkodlar = "(" + grupkodlar.Substring(0, grupkodlar.Length - 4) + ") AND ";



            Aranan = Aranan.ToUpper().Replace("'", " ").Replace("%", "").Replace("--", "").Replace("/*", "").Replace("*/", "").Replace(" OR ", " ").Replace(" AND ", " ").Replace(" LIKE ", " ");
            //Aranan = Aranan.ToUpper().Replace("İ", "I").Replace("Ü", "U").Replace("Ö", "O").Replace("Ş", "S").Replace("Ç", "C").Replace("Ğ", "G");

            string malacik = string.Empty;
            string[] aramakelimeler = new string[1];

            if (AramaBasi == string.Empty)
                aramakelimeler[0] = Aranan;
            else
                aramakelimeler = Aranan.Split(new string[] { " " }, StringSplitOptions.None);

            for (int i = 0; i < aramakelimeler.Length; i++)
                malacik += "[KurumsalWebSAP].dbo.[Web-Malzeme].[MAL ACIK] LIKE '" + AramaBasi + aramakelimeler[i] + "%' AND ";

            if (malacik == string.Empty)
                malacik = "[KurumsalWebSAP].dbo.[Web-Malzeme].[MAL ACIK] IS NOT NULL ";
            else
                malacik = malacik.Substring(0, malacik.Length - 4);



            
            string YeniUrunler = string.Empty;
            //if (Yeni)
            //    YeniKampanyalar = " AND [KYTM] < 16";

            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT DISTINCT [KurumsalWebSAP].dbo.[Web-Malzeme].[HK] FROM [KurumsalWebSAP].dbo.[Web-Malzeme] " +
                    "INNER JOIN [KurumsalWebSAP].dbo.[Web-Fiyat] ON [KurumsalWebSAP].dbo.[Web-Malzeme].[ITEMREF] = [KurumsalWebSAP].dbo.[Web-Fiyat].[ITEMREF] " +
                    "WHERE [KurumsalWebSAP].dbo.[Web-Fiyat].[TIP] = @FiyatTipi AND " +
                    ozelkodlar + grupkodlar +
                    //"[KurumsalWebSAP].dbo.[Web-Malzeme].[OZEL KOD] " + TedarikciOperator + " " + Tedarikci + " AND " +
                    "[KurumsalWebSAP].dbo.[Web-Malzeme].[REY KOD] " + KategoriOperator + " " + Kategori + YeniUrunler +
                    " AND " + malacik, conn);
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
        /// [WebMalzeme] [Web-Fiyat]
        /// </summary>
        public static void GetKategoriHangiHarfler(DataTable dt, short FiyatTipi, string Tedarikci, string TedarikciOperator,
            /*string Kategori, string KategoriOperator, */string AramaBasi, string Aranan, ArrayList OzelKodlar, ArrayList GrupKodlar)
        {
            string ozelkodlar = string.Empty;
            string grupkodlar = string.Empty;

            for (int i = 0; i < OzelKodlar.Count; i++)
                ozelkodlar += "[KurumsalWebSAP].dbo.[Web-Malzeme].[OZEL KOD] = '" + OzelKodlar[i].ToString() + "' OR ";

            if (OzelKodlar.Count > 0)
                ozelkodlar = "(" + ozelkodlar.Substring(0, ozelkodlar.Length - 4) + ") AND ";

            for (int i = 0; i < GrupKodlar.Count; i++)
                grupkodlar += "[KurumsalWebSAP].dbo.[Web-Malzeme].[GRUP KOD] = '" + GrupKodlar[i].ToString() + "' OR ";

            if (GrupKodlar.Count > 0)
                grupkodlar = "(" + grupkodlar.Substring(0, grupkodlar.Length - 4) + ") AND ";



            Aranan = Aranan.ToUpper().Replace("'", " ").Replace("%", "").Replace("--", "").Replace("/*", "").Replace("*/", "").Replace(" OR ", " ").Replace(" AND ", " ").Replace(" LIKE ", " ");
            //Aranan = Aranan.ToUpper().Replace("İ", "I").Replace("Ü", "U").Replace("Ö", "O").Replace("Ş", "S").Replace("Ç", "C").Replace("Ğ", "G");

            string malacik = string.Empty;
            string[] aramakelimeler = new string[1];

            if (AramaBasi == string.Empty)
                aramakelimeler[0] = Aranan;
            else
                aramakelimeler = Aranan.Split(new string[] { " " }, StringSplitOptions.None);

            for (int i = 0; i < aramakelimeler.Length; i++)
                malacik += "[KurumsalWebSAP].dbo.[Web-Malzeme].[MAL ACIK] LIKE '" + AramaBasi + aramakelimeler[i] + "%' AND ";

            if (malacik == string.Empty)
                malacik = "[KurumsalWebSAP].dbo.[Web-Malzeme].[MAL ACIK] IS NOT NULL ";
            else
                malacik = malacik.Substring(0, malacik.Length - 4);




            string YeniUrunler = string.Empty;
            //if (Yeni)
            //    YeniKampanyalar = " AND [KYTM] < 16";

            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT DISTINCT [KurumsalWebSAP].dbo.[Web-Malzeme].[RK] FROM [KurumsalWebSAP].dbo.[Web-Malzeme] " +
                    "INNER JOIN [KurumsalWebSAP].dbo.[Web-Fiyat] ON [KurumsalWebSAP].dbo.[Web-Malzeme].[ITEMREF] = [KurumsalWebSAP].dbo.[Web-Fiyat].[ITEMREF] " +
                    "WHERE [KurumsalWebSAP].dbo.[Web-Fiyat].[TIP] = @FiyatTipi AND " +
                    ozelkodlar + grupkodlar +
                    "[KurumsalWebSAP].dbo.[Web-Malzeme].[OZEL KOD] " + TedarikciOperator + " " + Tedarikci +
                    /*" AND [KurumsalWebSAP].dbo.[Web-Malzeme].[REY KOD] " + KategoriOperator + " " + Kategori + */YeniUrunler +
                    " AND " + malacik, conn);
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
        //
        //
        #endregion
        //
        //
        #region Yeni Tedarikçi ve Kategori Süzmeleri:
        // [Web-Fiyat]
        public static void GetTedarikciler2(string harf, string KategoriID, string AramaBasi, string Aranan, ListItemCollection lic, int FiyatTipiID, ArrayList OzelKodlar, ArrayList GrupKodlar, bool UrunSayisiniYaz)
        {
            string kategoriid = "";
            if (KategoriID == "NOT NULL")
                kategoriid = "IS NOT NULL";
            else
                kategoriid = "= " + KategoriID;

            string ozelkodlar = string.Empty;
            string grupkodlar = string.Empty;

            for (int i = 0; i < OzelKodlar.Count; i++)
                ozelkodlar += "[KurumsalWebSAP].dbo.[Web-Fiyat].[OZEL KOD] = '" + OzelKodlar[i].ToString() + "' OR ";

            if (OzelKodlar.Count > 0)
                ozelkodlar = "(" + ozelkodlar.Substring(0, ozelkodlar.Length - 4) + ") AND ";

            for (int i = 0; i < GrupKodlar.Count; i++)
                grupkodlar += "[KurumsalWebSAP].dbo.[Web-Fiyat].[GRUP KOD] = '" + GrupKodlar[i].ToString() + "' OR ";

            if (GrupKodlar.Count > 0)
                grupkodlar = "(" + grupkodlar.Substring(0, grupkodlar.Length - 4) + ") AND ";

            if (harf == "C")
                harf = harf + "' OR [KurumsalWebSAP].dbo.[Web-Fiyat].[HK] = 'Ç";
            else if (harf == "G")
                harf = harf + "' OR [KurumsalWebSAP].dbo.[Web-Fiyat].[HK] = 'Ğ";
            else if (harf == "I")
                harf = harf + "' OR [KurumsalWebSAP].dbo.[Web-Fiyat].[HK] = 'İ";
            else if (harf == "O")
                harf = harf + "' OR [KurumsalWebSAP].dbo.[Web-Fiyat].[HK] = 'Ö";
            else if (harf == "S")
                harf = harf + "' OR [KurumsalWebSAP].dbo.[Web-Fiyat].[HK] = 'Ş";
            else if (harf == "U")
                harf = harf + "' OR [KurumsalWebSAP].dbo.[Web-Fiyat].[HK] = 'Ü";

            Aranan = Aranan.ToUpper().Replace("'", " ").Replace("%", "").Replace("--", "").Replace("/*", "").Replace("*/", "").Replace(" OR ", " ").Replace(" AND ", " ").Replace(" LIKE ", " ");
            //Aranan = Aranan.ToUpper().Replace("İ", "I").Replace("Ü", "U").Replace("Ö", "O").Replace("Ş", "S").Replace("Ç", "C").Replace("Ğ", "G");

            string malacik = string.Empty;
            string[] aramakelimeler = new string[1];

            if (AramaBasi == string.Empty)
                aramakelimeler[0] = Aranan;
            else
                aramakelimeler = Aranan.Split(new string[] { " " }, StringSplitOptions.None);

            for (int i = 0; i < aramakelimeler.Length; i++)
                malacik += "[KurumsalWebSAP].dbo.[Web-Fiyat].[MAL ACIK] LIKE '" + AramaBasi + aramakelimeler[i] + "%' AND ";

            if (malacik == string.Empty)
                malacik = "[KurumsalWebSAP].dbo.[Web-Fiyat].[MAL ACIK] IS NOT NULL ";
            else
                malacik = malacik.Substring(0, malacik.Length - 4);



            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3))
            {
                SqlCommand cmd = new SqlCommand("SELECT count(DISTINCT [KurumsalWebSAP].dbo.[Web-Fiyat].[ITEMREF]),[KurumsalWebSAP].dbo.[Web-Fiyat].[OZEL KOD],[KurumsalWebSAP].dbo.[Web-Fiyat].[OZEL ACIK] FROM [KurumsalWebSAP].dbo.[Web-Fiyat] INNER JOIN [KurumsalWebSAP].dbo.[Web-Malzeme] ON [KurumsalWebSAP].dbo.[Web-Fiyat].ITEMREF = [KurumsalWebSAP].dbo.[Web-Malzeme].ITEMREF WHERE ([KurumsalWebSAP].dbo.[Web-Fiyat].[HK] = '" + harf + "') AND [KurumsalWebSAP].dbo.[Web-Fiyat].[REY KOD] " + kategoriid + " AND " + ozelkodlar + grupkodlar + malacik + "AND [KurumsalWebSAP].dbo.[Web-Fiyat].[TIP] = " + FiyatTipiID.ToString() + " GROUP BY [KurumsalWebSAP].dbo.[Web-Fiyat].[OZEL KOD],[KurumsalWebSAP].dbo.[Web-Fiyat].[OZEL ACIK] ORDER BY [KurumsalWebSAP].dbo.[Web-Fiyat].[OZEL ACIK]", conn);
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        ListItem lst = new ListItem();
                        lst.Text = dr[2].ToString();
                        if (UrunSayisiniYaz)
                            lst.Text += " (" + dr[0].ToString() + ")";
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
        // [Web-Fiyat]
        public static void GetKategoriler2(string harf, string TedarikciID, string AramaBasi, string Aranan, ListItemCollection lic, int FiyatTipiID, ArrayList OzelKodlar, ArrayList GrupKodlar, bool UrunSayisiniYaz)
        {
            string tedarikciid = "";
            if (TedarikciID == "NOT NULL")
                tedarikciid = "IS NOT NULL";
            else
                tedarikciid = "= " + TedarikciID;

            string ozelkodlar = string.Empty;
            string grupkodlar = string.Empty;

            for (int i = 0; i < OzelKodlar.Count; i++)
                ozelkodlar += "[KurumsalWebSAP].dbo.[Web-Fiyat].[OZEL KOD] = '" + OzelKodlar[i].ToString() + "' OR ";

            if (OzelKodlar.Count > 0)
                ozelkodlar = "(" + ozelkodlar.Substring(0, ozelkodlar.Length - 4) + ") AND ";

            for (int i = 0; i < GrupKodlar.Count; i++)
                grupkodlar += "[KurumsalWebSAP].dbo.[Web-Fiyat].[GRUP KOD] = '" + GrupKodlar[i].ToString() + "' OR ";

            if (GrupKodlar.Count > 0)
                grupkodlar = "(" + grupkodlar.Substring(0, grupkodlar.Length - 4) + ") AND ";

            if (harf == "C")
                harf = harf + "' OR [KurumsalWebSAP].dbo.[Web-Fiyat].[RK] = 'Ç";
            else if (harf == "G")
                harf = harf + "' OR [KurumsalWebSAP].dbo.[Web-Fiyat].[RK] = 'Ğ";
            else if (harf == "I")
                harf = harf + "' OR [KurumsalWebSAP].dbo.[Web-Fiyat].[RK] = 'İ";
            else if (harf == "O")
                harf = harf + "' OR [KurumsalWebSAP].dbo.[Web-Fiyat].[RK] = 'Ö";
            else if (harf == "S")
                harf = harf + "' OR [KurumsalWebSAP].dbo.[Web-Fiyat].[RK] = 'Ş";
            else if (harf == "U")
                harf = harf + "' OR [KurumsalWebSAP].dbo.[Web-Fiyat].[RK] = 'Ü";

            Aranan = Aranan.ToUpper().Replace("'", " ").Replace("%", "").Replace("--", "").Replace("/*", "").Replace("*/", "").Replace(" OR ", " ").Replace(" AND ", " ").Replace(" LIKE ", " ");
            //Aranan = Aranan.ToUpper().Replace("İ", "I").Replace("Ü", "U").Replace("Ö", "O").Replace("Ş", "S").Replace("Ç", "C").Replace("Ğ", "G");

            string malacik = string.Empty;
            string[] aramakelimeler = new string[1];

            if (AramaBasi == string.Empty)
                aramakelimeler[0] = Aranan;
            else
                aramakelimeler = Aranan.Split(new string[] { " " }, StringSplitOptions.None);

            for (int i = 0; i < aramakelimeler.Length; i++)
                malacik += "[KurumsalWebSAP].dbo.[Web-Fiyat].[MAL ACIK] LIKE '" + AramaBasi + aramakelimeler[i] + "%' AND ";

            if (malacik == string.Empty)
                malacik = "[KurumsalWebSAP].dbo.[Web-Fiyat].[MAL ACIK] IS NOT NULL ";
            else
                malacik = malacik.Substring(0, malacik.Length - 4);



            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3))
            {
                SqlCommand cmd = new SqlCommand("SELECT count(DISTINCT [KurumsalWebSAP].dbo.[Web-Fiyat].[ITEMREF]),[KurumsalWebSAP].dbo.[Web-Fiyat].[REY KOD],[KurumsalWebSAP].dbo.[Web-Fiyat].[REY ACIK] FROM [KurumsalWebSAP].dbo.[Web-Fiyat] WHERE ([KurumsalWebSAP].dbo.[Web-Fiyat].[RK] = '" + harf + "') AND [KurumsalWebSAP].dbo.[Web-Fiyat].[OZEL KOD] " + tedarikciid + " AND " + ozelkodlar + grupkodlar + malacik + "AND [KurumsalWebSAP].dbo.[Web-Fiyat].[TIP] = " + FiyatTipiID.ToString() + " GROUP BY [KurumsalWebSAP].dbo.[Web-Fiyat].[REY KOD],[KurumsalWebSAP].dbo.[Web-Fiyat].[REY ACIK] ORDER BY [KurumsalWebSAP].dbo.[Web-Fiyat].[REY ACIK]", conn);
                SqlDataReader dr;

                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        ListItem lst = new ListItem();
                        lst.Text = dr[2].ToString();
                        if (UrunSayisiniYaz)
                            lst.Text += " (" + dr[0].ToString() + ")";
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
        /// GetTedarikciler()
        /// </summary>
        public static void GetOzelKodlar(IList List)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3))
            {
                List.Clear();

                SqlCommand cmd = new SqlCommand("SELECT DISTINCT [OZEL KOD], [OZEL ACIK] FROM [Web-OzelKodlar] ORDER BY [OZEL ACIK]", conn);
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        List.Add(new OzelKodlar(dr[0].ToString(), dr[1].ToString()));
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
        /// GetTedarikciler(), tümü var 0. indexte
        /// </summary>
        public static void GetOzelKodlar(ListItemCollection lic, bool web)
        {
            lic.Clear();

            lic.Add(new ListItem("Tümü", "1"));

            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3))
            {
                SqlCommand cmd = new SqlCommand("SELECT DISTINCT [OZEL KOD], [OZEL ACIK] FROM [Web-OzelKodlar] ORDER BY [OZEL ACIK]", conn);
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
        /// GetKategoriler()
        /// </summary>
        public static void GetReyonKodlar(IList List)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3))
            {
                List.Clear();

                SqlCommand cmd = new SqlCommand("SELECT DISTINCT [CODE], [NAME] FROM [Web-Kategoriler] ORDER BY [NAME]", conn);
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        List.Add(new ReyonKodlar(dr[0].ToString(), dr[1].ToString()));
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
        public static void GetGrupKodlar(IList List)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3))
            {
                List.Clear();

                SqlCommand cmd = new SqlCommand("SELECT [GRUP KOD], [GRUP ACIK] FROM [Web-GrupKodlar] ORDER BY [GRUP ACIK]", conn);
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        List.Add(new GrupKodlar(dr[0].ToString(), dr[1].ToString()));
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
        #endregion
        //
        //
        #region fiyatlarla ilgili
        /// <summary>
        /// [Web-Fiyat]
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
                    object obj = cmd.ExecuteScalar();
                    if (obj != null)
                        donendeger = Convert.ToDecimal(obj);
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
        /// [Web-Kampanya-2]
        /// </summary>
        public static bool GetProductKampanyaAnaMi(int UrunID)
        {
            bool donendeger = false;

            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3))
            {
                SqlCommand cmd = new SqlCommand("SELECT count([KAMKARTREF]) FROM [Web-Kampanya-2] WHERE [ITEMREF] = @ITEMREF", conn);
                cmd.Parameters.Add("@ITEMREF", System.Data.SqlDbType.Int).Value = UrunID;
                try
                {
                    conn.Open();
                    object obj = cmd.ExecuteScalar();
                    if (obj != null)
                        donendeger = Convert.ToBoolean(obj);
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
        /// [Web-Kampanya-3]
        /// </summary>
        public static bool GetProductKampanyaHediyesiMi(int UrunID)
        {
            bool donendeger = false;

            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3))
            {
                SqlCommand cmd = new SqlCommand("SELECT count([KAMKARTREF]) FROM [Web-Kampanya-3] WHERE [ITEMREF] = @ITEMREF", conn);
                cmd.Parameters.Add("@ITEMREF", System.Data.SqlDbType.Int).Value = UrunID;
                try
                {
                    conn.Open();
                    object obj = cmd.ExecuteScalar();
                    if (obj != null)
                        donendeger = Convert.ToBoolean(obj);
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
        /// kullanılmıyor
        /// </summary>
        public static ArrayList GetProductKamKartRefs(int UrunID, int FiyatTipi) 
        {
            ArrayList donendeger = new ArrayList();

            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3))
            {
                SqlCommand cmd = new SqlCommand("SELECT [Web-Fiyat].[KAMKARTREF] FROM [Web-Malzeme]  INNER JOIN [Web-Fiyat] ON [Web-Malzeme].[ITEMREF] = [Web-Fiyat].[ITEMREF] WHERE [ITEMREF] = @ITEMREF AND [Web-Fiyat].[TIP] = @TIP", conn);
                cmd.Parameters.Add("@ITEMREF", System.Data.SqlDbType.Int).Value = UrunID;
                cmd.Parameters.Add("@TIP", System.Data.SqlDbType.Int).Value = FiyatTipi;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                        if (dr[0].ToString() != string.Empty)
                            if (Guid.Parse(dr[0].ToString()) != Guid.Empty)
                                donendeger.Add(Guid.Parse(dr[0].ToString()));
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
        /// [Web-Fiyat], hatalar webgenele kaydoluyor
        /// </summary>
        public static int GetProductVade(int UrunID, int FiyatTipi)
        {
            int donendeger = 0;

            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3))
            {
                SqlCommand cmd = new SqlCommand("SELECT [VADE] FROM [KurumsalWebSAP].dbo.[Web-Fiyat] WHERE [ITEMREF] = @ITEMREF AND TIP = @TIP", conn);
                cmd.Parameters.Add("@ITEMREF", System.Data.SqlDbType.Int).Value = UrunID;
                cmd.Parameters.Add("@TIP", System.Data.SqlDbType.Int).Value = FiyatTipi;
                try
                {
                    conn.Open();
                    object obj = cmd.ExecuteScalar();
                    if (obj != null || obj != DBNull.Value)
                        donendeger = Convert.ToInt32(obj);
                    else
                        WebGenel.DoUpdateStrDENEME("Fiyat Tipi: " + FiyatTipi.ToString() + ", ITEMREF: " + UrunID.ToString());
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
        /// [Web-Fiyat], isk1 isk2 isk3 isk4 fiyat isk5 isk6 isk7 isk8 isk9 isk10
        /// </summary>
        public static double[] GetProductDiscountsAndPrice(int UrunID, int FiyatTipi)
        {
            double[] donendeger = new double[11];

            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3))
            {
                SqlCommand cmd = new SqlCommand("SELECT [ISK1],[ISK2],[ISK3],[ISK4],[FIYAT],[ISK5],[ISK6],[ISK7],[ISK8],[ISK9],[ISK10] FROM [KurumsalWebSAP].dbo.[Web-Fiyat] WHERE [ITEMREF] = @ITEMREF AND TIP = @TIP", conn);
                cmd.Parameters.Add("@ITEMREF", System.Data.SqlDbType.Int).Value = UrunID;
                cmd.Parameters.Add("@TIP", System.Data.SqlDbType.Int).Value = FiyatTipi;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        donendeger[0] = Convert.ToDouble(dr[0]);
                        donendeger[1] = Convert.ToDouble(dr[1]);
                        donendeger[2] = Convert.ToDouble(dr[2]);
                        donendeger[3] = Convert.ToDouble(dr[3]);
                        donendeger[4] = Convert.ToDouble(dr[4]);
                        donendeger[5] = Convert.ToDouble(dr[5]);
                        donendeger[6] = Convert.ToDouble(dr[6]);
                        donendeger[7] = Convert.ToDouble(dr[7]);
                        donendeger[8] = Convert.ToDouble(dr[8]);
                        donendeger[9] = Convert.ToDouble(dr[9]);
                        donendeger[10] = Convert.ToDouble(dr[10]);
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
        /// <summary>
        /// [Web-Fiyat-Full], isk1 isk2 isk3 isk4 fiyat isk5 isk6 isk7 isk8 isk9 isk10
        /// </summary>
        public static double[] GetProductDiscountsAndPriceFULL(int UrunID, int FiyatTipi)
        {
            double[] donendeger = new double[11];

            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3))
            {
                SqlCommand cmd = new SqlCommand("SELECT [ISK1],[ISK2],[ISK3],[ISK4],[FIYAT],[ISK5],[ISK6],[ISK7],[ISK8],[ISK9],[ISK10] FROM [KurumsalWebSAP].dbo.[Web-Fiyat-Full] WHERE [ITEMREF] = @ITEMREF AND TIP = @TIP", conn);
                cmd.Parameters.Add("@ITEMREF", System.Data.SqlDbType.Int).Value = UrunID;
                cmd.Parameters.Add("@TIP", System.Data.SqlDbType.Int).Value = FiyatTipi;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        donendeger[0] = Convert.ToDouble(dr[0]);
                        donendeger[1] = Convert.ToDouble(dr[1]);
                        donendeger[2] = Convert.ToDouble(dr[2]);
                        donendeger[3] = Convert.ToDouble(dr[3]);
                        donendeger[4] = Convert.ToDouble(dr[4]);
                        donendeger[5] = Convert.ToDouble(dr[5]);
                        donendeger[6] = Convert.ToDouble(dr[6]);
                        donendeger[7] = Convert.ToDouble(dr[7]);
                        donendeger[8] = Convert.ToDouble(dr[8]);
                        donendeger[9] = Convert.ToDouble(dr[9]);
                        donendeger[10] = Convert.ToDouble(dr[10]);
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
        /// <summary>
        /// [Web-Fiyat-Full]
        /// </summary>
        public static decimal GetProductNetFiyatFULL(int UrunID, int FiyatTipi)
        {
            decimal donendeger = 0;

            string fiyattip = FiyatTipi != 7 ? ("TIP = " + FiyatTipi.ToString()) : ("(TIP = 7 OR TIP > 500)"); // bazı ürünlerin sadece 500 lülerde fiyatı oluyor f7 de olmuyor örneğin hakmar ürünü migros ürünü

            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3))
            {
                SqlCommand cmd = new SqlCommand("SELECT [NET] FROM [KurumsalWebSAP].dbo.[Web-Fiyat-Full] WHERE [ITEMREF] = @ITEMREF AND " + fiyattip, conn);
                cmd.Parameters.Add("@ITEMREF", System.Data.SqlDbType.Int).Value = UrunID;
                try
                {
                    conn.Open();
                    object obj = cmd.ExecuteScalar();
                    if (obj != null)
                        donendeger = Convert.ToDecimal(obj);
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
        /// [Web-Fiyat]
        /// </summary>
        public static decimal GetProductPriceFULL(int UrunID, short FiyatTipi)
        {
            decimal donendeger = 0;

            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3))
            {
                SqlCommand cmd = new SqlCommand("SELECT [NET+KDV] FROM [KurumsalWebSAP].dbo.[Web-Fiyat-Full] WHERE [ITEMREF] = @ITEMREF AND [TIP] = @TIP", conn);
                cmd.Parameters.Add("@ITEMREF", System.Data.SqlDbType.Int).Value = UrunID;
                cmd.Parameters.Add("@TIP", System.Data.SqlDbType.SmallInt).Value = FiyatTipi;
                try
                {
                    conn.Open();
                    object obj = cmd.ExecuteScalar();
                    if (obj != null)
                        donendeger = Convert.ToDecimal(obj);
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
        /// [Web-Fiyat]
        /// </summary>
        public static int GetProductOdemeGun(int UrunID, int FiyatTipi)
        {
            int donendeger = 0;

            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3))
            {
                SqlCommand cmd = new SqlCommand("SELECT [ODEME_GUN] FROM [KurumsalWebSAP].dbo.[Web-Fiyat] WHERE [ITEMREF] = @ITEMREF AND TIP = @TIP", conn);
                cmd.Parameters.Add("@ITEMREF", System.Data.SqlDbType.Int).Value = UrunID;
                cmd.Parameters.Add("@TIP", System.Data.SqlDbType.Int).Value = FiyatTipi;
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
        /// [Web-Fiyat] Eğer ödeme gün 0 veya 0 dan küçük ise bunu çağırmayı dene yoksa null dönebilir
        /// </summary>
        public static DateTime GetProductOdemeTarih(int UrunID, int FiyatTipi)
        {
            DateTime donendeger = DateTime.MinValue;
            Object tarih = new Object();

            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3))
            {
                SqlCommand cmd = new SqlCommand("SELECT [ODEME_TARIH] FROM [KurumsalWebSAP].dbo.[Web-Fiyat] WHERE [ITEMREF] = @ITEMREF AND TIP = @TIP", conn);
                cmd.Parameters.Add("@ITEMREF", System.Data.SqlDbType.Int).Value = UrunID;
                cmd.Parameters.Add("@TIP", System.Data.SqlDbType.Int).Value = FiyatTipi;
                try
                {
                    conn.Open();
                    object obj = cmd.ExecuteScalar();
                    if (obj != null)
                        tarih = cmd.ExecuteScalar();
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

            if (tarih.ToString() != string.Empty)
                donendeger = Convert.ToDateTime(tarih);

            return donendeger;
        }
        #endregion
        //
        //
        #region tekli bilgi
        /// <summary>
        /// [Web-Malzeme]
        /// </summary>
        public static double GetProductStok(int UrunID)
        {
            double donendeger = 0;

            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3))
            {
                SqlCommand cmd = new SqlCommand("SELECT [STOK] FROM [KurumsalWebSAP].dbo.[Web-Malzeme] WHERE [ITEMREF] = @ITEMREF", conn);
                cmd.Parameters.Add("@ITEMREF", System.Data.SqlDbType.Int).Value = UrunID;
                try
                {
                    conn.Open();
                    object obj = cmd.ExecuteScalar();
                    if (obj != null)
                        donendeger = Convert.ToDouble(obj);
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
        /// [Web-Malzeme-Full] **
        /// </summary>
        public static string GetProductBirimRef(int UrunID)
        {
            string donendeger = "";

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT [BIRIMREF] FROM [Web-Malzeme-Full] WHERE [ITEMREF] = @ITEMREF", conn);
                cmd.Parameters.Add("@ITEMREF", System.Data.SqlDbType.Int).Value = UrunID;
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
        /// [Web-Malzeme-Full] ** Paket adedini birim alanına yazıyoruz
        /// </summary>
        public static string GetProductBirim(int UrunID)
        {
            string donendeger = "";

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT [BIRIM] FROM [Web-Malzeme-Full] WHERE [ITEMREF] = @ITEMREF", conn);
                cmd.Parameters.Add("@ITEMREF", System.Data.SqlDbType.Int).Value = UrunID;
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
        /// [Web-Malzeme-Full] *
        /// </summary>
        public static string GetProductName(int UrunID)
        {
            if (!ProductIsAvailable(UrunID))
                return "-hata-";

            string donendeger = string.Empty;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT [MAL ACIK] AS Ad FROM [KurumsalWebSAP].dbo.[Web-Malzeme-Full] WHERE [ITEMREF] = @ITEMREF", conn);
                cmd.Parameters.Add("@ITEMREF", System.Data.SqlDbType.Int).Value = UrunID;
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
        /// [Web-Malzeme-Full] *
        /// </summary>
        public static string GetProductOzelKod(int UrunID)
        {
            string donendeger = string.Empty;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT [OZEL KOD] FROM [KurumsalWebSAP].dbo.[Web-Malzeme-Full] WHERE [ITEMREF] = @ITEMREF", conn);
                cmd.Parameters.Add("@ITEMREF", System.Data.SqlDbType.Int).Value = UrunID;
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
        /// [Web-Malzeme-Full] *
        /// </summary>
        public static string GetProductOzelAcik(int UrunID)
        {
            string donendeger = string.Empty;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT [OZEL ACIK] FROM [KurumsalWebSAP].dbo.[Web-Malzeme-Full] WHERE [ITEMREF] = @ITEMREF", conn);
                cmd.Parameters.Add("@ITEMREF", System.Data.SqlDbType.Int).Value = UrunID;
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
        /// [Web-Malzeme-Full] *
        /// </summary>
        public static string GetProductReyKod(int UrunID)
        {
            string donendeger = string.Empty;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT [REY KOD] FROM [KurumsalWebSAP].dbo.[Web-Malzeme-Full] WHERE [ITEMREF] = @ITEMREF", conn);
                cmd.Parameters.Add("@ITEMREF", System.Data.SqlDbType.Int).Value = UrunID;
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
        /// [Web-Malzeme-Full] *
        /// </summary>
        public static string GetProductReyAcik(int UrunID)
        {
            string donendeger = string.Empty;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT [REY ACIK] FROM [KurumsalWebSAP].dbo.[Web-Malzeme-Full] WHERE [ITEMREF] = @ITEMREF", conn);
                cmd.Parameters.Add("@ITEMREF", System.Data.SqlDbType.Int).Value = UrunID;
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
        /// [Web-Malzeme-Full] *
        /// </summary>
        public static bool ProductIsAvailable(int UrunID)
        {
            bool donendeger = false;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT count([ITEMREF]) FROM [KurumsalWebSAP].dbo.[Web-Malzeme-Full] WHERE [ITEMREF] = @ITEMREF", conn);
                cmd.Parameters.Add("@ITEMREF", System.Data.SqlDbType.Int).Value = UrunID;
                try
                {
                    conn.Open();
                    object obj = cmd.ExecuteScalar();
                    if (obj != null)
                        donendeger = Convert.ToBoolean(obj);
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
        /// [Web-Malzeme-Full] *
        /// </summary>
        public static double GetProductKDV(int UrunID)
        {
            double donendeger = 0;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT [KDV] FROM [KurumsalWebSAP].dbo.[Web-Malzeme-Full] WHERE [ITEMREF] = @ITEMREF", conn);
                cmd.Parameters.Add("@ITEMREF", System.Data.SqlDbType.Int).Value = UrunID;
                try
                {
                    conn.Open();
                    object obj = cmd.ExecuteScalar();
                    if (obj != null)
                        donendeger = Convert.ToDouble(obj);
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
        /// [Web-Malzeme-Full] *
        /// </summary>
        public static string GetProductBarkod(int UrunID)
        {
            string donendeger = string.Empty;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT [BARKOD] FROM [KurumsalWebSAP].dbo.[Web-Malzeme-Full] WHERE [ITEMREF] = @ITEMREF", conn);
                cmd.Parameters.Add("@ITEMREF", System.Data.SqlDbType.Int).Value = UrunID;
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
        /// [Web-Malzeme-Full] *
        /// </summary>
        public static void GetResimsizTedarikciler(IList List)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                List.Clear();

                SqlCommand cmd = new SqlCommand("SELECT DISTINCT [OZEL ACIK] FROM [Web-Malzeme-Full] WHERE [OZEL ACIK] NOT IN (SELECT DISTINCT [OZEL ACIK] FROM [Web-Malzeme-Full] WHERE [ITEMREF] IN (SELECT [ITEMREF] FROM [KurumsalWebSAP].[dbo].[tblINTERNET_UrunResim])) ORDER BY [OZEL ACIK]", conn);
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        List.Add(dr[0].ToString());
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
        /// [Web-Malzeme-Full] *
        /// </summary>
        public static string GetProductTedarikciIlgili(int UrunID)
        {
            string donendeger = string.Empty;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT [ILGILI] + '<br />' + [TELEFON] + ' ' + [EMAIL] FROM [tblINTERNET_TedarikciIlgili] WHERE [OZELKOD] = (SELECT [OZEL KOD] FROM [Web-Malzeme-Full] WHERE [ITEMREF] = @ITEMREF)", conn);
                cmd.Parameters.Add("@ITEMREF", System.Data.SqlDbType.Int).Value = UrunID;
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
        /// [Web-Malzeme-Full] *
        /// </summary>
        public static string GetProductUrtKod(int UrunID)
        {
            string donendeger = string.Empty;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT [URT KOD] FROM [Web-Malzeme-Full] WHERE [ITEMREF] = @ITEMREF", conn);
                cmd.Parameters.Add("@ITEMREF", System.Data.SqlDbType.Int).Value = UrunID;
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
        /// [Web-Malzeme-Full] *
        /// </summary>
        public static string GetProductMalKod(int UrunID)
        {
            string donendeger = string.Empty;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT [MAL KOD] FROM [Web-Malzeme-Full] WHERE [ITEMREF] = @ITEMREF", conn);
                cmd.Parameters.Add("@ITEMREF", System.Data.SqlDbType.Int).Value = UrunID;
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
        /// [Web-Malzeme-Full] **
        /// </summary>
        public static int GetProductID(string UrunAdi)
        {
            int donendeger = 0;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT [ITEMREF] FROM [Web-Malzeme-Full] WHERE [MAL ACIK] = @MALACIK", conn);
                cmd.Parameters.Add("@MALACIK", System.Data.SqlDbType.VarChar, 51).Value = UrunAdi;
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
        /// [Web-Malzeme-Full] **
        /// </summary>
        public static double GetKoliAdedi(int UrunID)
        {
            double donendeger = 0;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT [KOLI] FROM [Web-Malzeme-Full] WHERE ITEMREF = @ITEMREF", conn);
                cmd.Parameters.Add("@ITEMREF", System.Data.SqlDbType.Int).Value = UrunID;
                try
                {
                    conn.Open();
                    object obj = cmd.ExecuteScalar();
                    if (obj != null)
                        donendeger = Convert.ToDouble(obj);
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
        /// [Web-Malzeme-Full] *
        /// </summary>
        public static int GetProductUrunID(string URTKOD)
        {
            int donendeger = 0;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT [ITEMREF] FROM [Web-Malzeme-Full] WHERE [URT KOD] = @URTKOD", conn);
                cmd.Parameters.Add("@URTKOD", System.Data.SqlDbType.VarChar, 25).Value = URTKOD;
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
        /// [Web-Malzeme-Full] *
        /// </summary>
        public static string GetProductGRPKOD(string URTKOD)
        {
            string donendeger = string.Empty;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT [GRUP KOD] FROM [Web-Malzeme-Full] WHERE [URT KOD] = @URTKOD", conn);
                cmd.Parameters.Add("@URTKOD", System.Data.SqlDbType.VarChar, 25).Value = URTKOD;
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
        /// [Web-Malzeme-Full] *
        /// </summary>
        public static string GetProductGRPKOD(int UrunID)
        {
            string donendeger = string.Empty;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT [GRUP KOD] FROM [Web-Malzeme-Full] WHERE [ITEMREF] = @ITEMREF", conn);
                cmd.Parameters.Add("@ITEMREF", System.Data.SqlDbType.Int).Value = UrunID;
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
        #endregion
        //
        //
        #region eş kod
        /// <summary>
        /// [Web-Malzeme-Full] *, gönderilen ürün itemref inin eş kodundaki itemref leri döndürüyor
        /// </summary>
        public static ArrayList GetProductEsKodITEMREFs(int UrunID)
        {
            ArrayList donendeger = new ArrayList();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT [ES KOD] FROM [Web-Malzeme-Full] WHERE [ITEMREF] = @ITEMREF", conn);
                SqlCommand cmd1 = new SqlCommand("SELECT [ITEMREF] FROM [Web-Malzeme-Full] WHERE [ES KOD] = @ESKOD", conn);
                cmd.Parameters.Add("@ITEMREF", System.Data.SqlDbType.Int).Value = UrunID;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    object eskod = cmd.ExecuteScalar();

                    if (eskod != null && eskod != DBNull.Value && eskod != string.Empty)
                    {
                        cmd1.Parameters.Add("@ESKOD", System.Data.SqlDbType.VarChar, 25).Value = eskod.ToString();
                        dr = cmd1.ExecuteReader();
                        while (dr.Read())
                            donendeger.Add(Convert.ToInt32(dr[0]));
                    }
                    else
                    {
                        donendeger.Add(UrunID);
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
        /// <summary>
        /// [Web-Malzeme-Full] *, gönderilen ürün urtkod unun eş kodundaki urtkod ları döndürüyor
        /// </summary>
        public static ArrayList GetProductEsKodURTKODs(string URTKOD)
        {
            ArrayList donendeger = new ArrayList();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT [ES KOD] FROM [Web-Malzeme-Full] WHERE [URT KOD] = @URTKOD", conn);
                SqlCommand cmd1 = new SqlCommand("SELECT [URT KOD] FROM [Web-Malzeme-Full] WHERE [ES KOD] = @ESKOD", conn);
                cmd.Parameters.Add("@URTKOD", System.Data.SqlDbType.VarChar, 25).Value = URTKOD;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    object eskod = cmd.ExecuteScalar();

                    if (eskod != null && eskod != DBNull.Value && eskod != string.Empty)
                    {
                        cmd1.Parameters.Add("@ESKOD", System.Data.SqlDbType.VarChar, 25).Value = eskod.ToString();
                        dr = cmd1.ExecuteReader();
                        while (dr.Read())
                            donendeger.Add(dr[0].ToString());
                    }
                    else
                    {
                        donendeger.Add(URTKOD);
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
        /// <summary>
        /// [Web-Malzeme-Full] *, gönderilen ürün itemref inin eş kodundaki ürünleri döndürüyor
        /// </summary>
        public static void GetProductEsKodProducts(DataTable dt, int UrunID)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT [ES KOD] FROM [Web-Malzeme-Full] WHERE [ITEMREF] = @ITEMREF", conn);
                SqlDataAdapter da = new SqlDataAdapter("SELECT [URT KOD],[MAL ACIK] FROM [Web-Malzeme-Full] WHERE [ES KOD] = @ESKOD ORDER BY [MAL ACIK]", conn);
                cmd.Parameters.Add("@ITEMREF", System.Data.SqlDbType.Int).Value = UrunID;
                try
                {
                    conn.Open();
                    object eskod = cmd.ExecuteScalar();

                    if (eskod != null && eskod != DBNull.Value && eskod != string.Empty)
                    {
                        da.SelectCommand.Parameters.Add("@ESKOD", System.Data.SqlDbType.VarChar, 25).Value = eskod.ToString();
                        da.Fill(dt);
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
        #endregion
        //
        //
        /// <summary>
        /// [Web-Malzeme-Full]
        /// </summary>
        public static void GetOlcuBirimleri(DataTable dt, int UrunID)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT CASE Meinh WHEN 'KI' THEN 'Koli' WHEN 'ST' THEN 'Adet' END AS TUR, Umrez AS MIKTAR, Ean11 AS BARKOD,Laeng AS EN, Breit AS BOY, Hoehe AS YUKSEKLIK, Meabm AS BIRIM, Volum AS HACIM, Voleh AS BIRIM2,Brgew AS AGIRLIK, Gewei AS BIRIM3 FROM [SAP_OLCUBIRIM] WHERE Matnr = @UrunID", conn);
                da.SelectCommand.Parameters.Add("@UrunID", System.Data.SqlDbType.Int).Value = UrunID;
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
        //
        //
        public static void GetAltKategoriler(ListItemCollection lic)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3))
            {
                SqlCommand cmd = new SqlCommand("SELECT DISTINCT KOD,METIN FROM [Web-Malzeme] INNER JOIN [Web-Malzeme-Hiyerarsi] ON [Web-Malzeme].HYRS = [Web-Malzeme-Hiyerarsi].KOD", conn);
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        ListItem lst = new ListItem();
                        lst.Text = " " + dr[1].ToString();
                        lst.Value = dr[0].ToString();
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
        // ------------- * olanlar web-malzeme idi, ** olanlar 36-400 idi (31.01.2014 de değiştirildi, birkaç gün sonra mahzur yoksa silinebilir bu açıklamalar)
        // ------------- sp_INTERNET_AktivitelerDetayGetirByAktiviteID de kullanılan Web-Malzeme, Web-Malzeme-Full oldu
        //
        //
        #region İADE İÇİN METHODLAR:
        /// <summary>
        /// İade için, web36 full urun listesi, fiyat tipi parametresi yok
        /// </summary>
        public static void GetProducts(DataTable dt, int Start, int Count, string TedarikciOperator, string Tedarikci,
            string KategoriOperator, string Kategori, string AramaBasi, string Aranan, string Siralama, string AzalanArtan,
            ArrayList OzelKodlar, ArrayList GrupKodlar/*, bool Yeni*/)
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

            Aranan = Aranan.ToUpper().Replace("'", " ").Replace("%", "").Replace("--", "").Replace("/*", "").Replace("*/", "").Replace(" OR ", " ").Replace(" AND ", " ").Replace(" LIKE ", " ");
            //Aranan = Aranan.ToUpper().Replace("İ", "I").Replace("Ü", "U").Replace("Ö", "O").Replace("Ş", "S").Replace("Ç", "C").Replace("Ğ", "G");

            string malacik = string.Empty;
            string[] aramakelimeler = new string[1];

            if (AramaBasi == string.Empty)
                aramakelimeler[0] = Aranan;
            else
                aramakelimeler = Aranan.Split(new string[] { " " }, StringSplitOptions.None);

            for (int i = 0; i < aramakelimeler.Length; i++)
                malacik += "[Web-Malzeme-Full].[MAL ACIK] LIKE '" + AramaBasi + aramakelimeler[i] + "%' AND ";

            if (malacik == string.Empty)
                malacik = "[Web-Malzeme-Full].[MAL ACIK] IS NOT NULL ";
            else
                malacik = malacik.Substring(0, malacik.Length - 4);



            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT " +
                    "IsNull((SELECT TOP 1 intResimID FROM [KurumsalWebSAP].dbo.tblINTERNET_UrunResim WHERE [KurumsalWebSAP].dbo.tblINTERNET_UrunResim.ITEMREF = [Web-Malzeme-Full].[ITEMREF]), 0) AS pkResimID, " +
                    "[AP] AS PASIF, [ITEMREF] AS UrunID, [MAL ACIK] AS Ad, [OZEL KOD] AS TedarikciID, [OZEL ACIK] AS TedarikciAdi, [REY KOD] AS KategoriID, [REY ACIK] AS KategoriAdi, [KOLI] AS Adet, [BARKOD] AS Barkod, [KDV], [KYTM] " +
                    "FROM [Web-Malzeme-Full] " +
                    "WHERE [OZEL KOD] " +
                    TedarikciOperator + " " + Tedarikci + " AND " +
                    "[REY KOD] " + KategoriOperator + " " + Kategori + " AND " + ozelkodlar + grupkodlar +
                    malacik +
                    "ORDER BY " + Siralama + " " + AzalanArtan + ", [MAL ACIK] ASC", conn);
                da.SelectCommand.CommandTimeout = 400;
                try
                {
                    conn.Open();
                    da.Fill(Start, Count, dt);
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
        /// Iade için, web36 full urun listesi, fiyat tipi parametresi yok
        /// </summary>
        public static int GetProductsCount(string TedarikciOperator, string Tedarikci,
            string KategoriOperator, string Kategori, string AramaBasi, string Aranan, ArrayList OzelKodlar, ArrayList GrupKodlar/*, bool Yeni*/)
        {
            int donendeger = 0;

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

            Aranan = Aranan.ToUpper().Replace("'", " ").Replace("%", "").Replace("--", "").Replace("/*", "").Replace("*/", "").Replace(" OR ", " ").Replace(" AND ", " ").Replace(" LIKE ", " ");
            //Aranan = Aranan.ToUpper().Replace("İ", "I").Replace("Ü", "U").Replace("Ö", "O").Replace("Ş", "S").Replace("Ç", "C").Replace("Ğ", "G");

            string malacik = string.Empty;
            string[] aramakelimeler = new string[1];

            if (AramaBasi == string.Empty)
                aramakelimeler[0] = Aranan;
            else
                aramakelimeler = Aranan.Split(new string[] { " " }, StringSplitOptions.None);

            for (int i = 0; i < aramakelimeler.Length; i++)
                malacik += "[Web-Malzeme-Full].[MAL ACIK] LIKE '" + AramaBasi + aramakelimeler[i] + "%' AND ";

            if (malacik == string.Empty)
                malacik = "[Web-Malzeme-Full].[MAL ACIK] IS NOT NULL ";
            else
                malacik = malacik.Substring(0, malacik.Length - 4);



            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3))
            {
                SqlCommand cmd = new SqlCommand("SELECT count([ITEMREF]) FROM [Web-Malzeme-Full] " +
                    "WHERE [OZEL KOD] " + TedarikciOperator + " " + Tedarikci + " AND " +
                    "[REY KOD] " + KategoriOperator + " " + Kategori + " AND " 
                    + ozelkodlar + grupkodlar +
                    malacik, conn);
                cmd.CommandTimeout = 400;
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
        /// Iade için, web36 full urun listesi, fiyat tipi parametresi yok
        /// </summary>
        public static void GetProducts(DataTable dt, string Barkod, ArrayList OzelKodlar, ArrayList GrupKodlar, bool barkod)
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

            Barkod = Barkod.ToUpper().Replace("'", " ").Replace("%", "").Replace("--", "").Replace("/*", "").Replace("*/", "").Replace(" OR ", " ").Replace(" AND ", " ").Replace(" LIKE ", " ");

            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT " +
                    "IsNull((SELECT TOP 1 intResimID FROM [KurumsalWebSAP].dbo.tblINTERNET_UrunResim WHERE [KurumsalWebSAP].dbo.tblINTERNET_UrunResim.ITEMREF = [Web-Malzeme-Full].[ITEMREF]), 0) AS pkResimID, " +
                    "[AP] AS PASIF, [ITEMREF] AS UrunID, [MAL ACIK] AS Ad, [OZEL KOD] AS TedarikciID, [OZEL ACIK] AS TedarikciAdi, [REY KOD] AS KategoriID, [REY ACIK] AS KategoriAdi, [KOLI] AS Adet, [BARKOD] AS Barkod, [KDV], [KYTM] " +
                    "FROM [Web-Malzeme-Full] " +
                    "WHERE " + ozelkodlar + grupkodlar +
                    "[BARKOD] = '" + Barkod + "' ", conn);
                da.SelectCommand.CommandTimeout = 400;
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
        /// Iade için, web36 full urun listesi, fiyat tipi parametresi yok
        /// </summary>
        public static void GetProducts(DataTable dt, string Malkod, ArrayList OzelKodlar, ArrayList GrupKodlar)
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

            Malkod = Malkod.ToUpper().Replace("'", " ").Replace("%", "").Replace("--", "").Replace("/*", "").Replace("*/", "").Replace(" OR ", " ").Replace(" AND ", " ").Replace(" LIKE ", " ");

            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT " +
                    "IsNull((SELECT TOP 1 intResimID FROM [KurumsalWebSAP].dbo.tblINTERNET_UrunResim WHERE [KurumsalWebSAP].dbo.tblINTERNET_UrunResim.ITEMREF = [Web-Malzeme-Full].[ITEMREF]), 0) AS pkResimID, " +
                    "[AP] AS PASIF, [ITEMREF] AS UrunID, [MAL ACIK] AS Ad, [OZEL KOD] AS TedarikciID, [OZEL ACIK] AS TedarikciAdi, [REY KOD] AS KategoriID, [REY ACIK] AS KategoriAdi, [KOLI] AS Adet, [BARKOD] AS Barkod, [KDV], [KYTM] " +
                    "FROM [Web-Malzeme-Full] " +
                    "WHERE " + ozelkodlar + grupkodlar +
                    "[MAL KOD] = '" + Malkod + "' ", conn);
                da.SelectCommand.CommandTimeout = 400;
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
        /// Iade için, web36 full urun listesi, fiyat tipi parametresi yok
        /// </summary>
        public static void GetProducts(DataTable dt, string Urtkod, ArrayList OzelKodlar, ArrayList GrupKodlar, bool urtkod, bool urtkod1)
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

            Urtkod = Urtkod.ToUpper().Replace("'", " ").Replace("%", "").Replace("--", "").Replace("/*", "").Replace("*/", "").Replace(" OR ", " ").Replace(" AND ", " ").Replace(" LIKE ", " ");

            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT " +
                    "IsNull((SELECT TOP 1 intResimID FROM [KurumsalWebSAP].dbo.tblINTERNET_UrunResim WHERE [KurumsalWebSAP].dbo.tblINTERNET_UrunResim.ITEMREF = [Web-Malzeme-Full].[ITEMREF]), 0) AS pkResimID, " +
                    "[AP] AS PASIF, [ITEMREF] AS UrunID, [MAL ACIK] AS Ad, [OZEL KOD] AS TedarikciID, [OZEL ACIK] AS TedarikciAdi, [REY KOD] AS KategoriID, [REY ACIK] AS KategoriAdi, [KOLI] AS Adet, [BARKOD] AS Barkod, [KDV], [KYTM] " +
                    "FROM [Web-Malzeme-Full] " +
                    "WHERE " + ozelkodlar + grupkodlar +
                    "[URT KOD] = '" + Urtkod + "' ", conn);
                da.SelectCommand.CommandTimeout = 400;
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
        /// Iade için, web36 full urun listesi, fiyat tipi parametresi yok
        /// </summary>
        public static void GetTedarikciHangiHarfler(DataTable dt, /*string Tedarikci, string TedarikciOperator,*/
            string Kategori, string KategoriOperator, string AramaBasi, string Aranan, ArrayList OzelKodlar, ArrayList GrupKodlar)
        {
            string ozelkodlar = string.Empty;
            string grupkodlar = string.Empty;

            for (int i = 0; i < OzelKodlar.Count; i++)
                ozelkodlar += "[Web-Malzeme-Full].[OZEL KOD] = '" + OzelKodlar[i].ToString() + "' OR ";

            if (OzelKodlar.Count > 0)
                ozelkodlar = "(" + ozelkodlar.Substring(0, ozelkodlar.Length - 4) + ") AND ";

            for (int i = 0; i < GrupKodlar.Count; i++)
                grupkodlar += "[Web-Malzeme-Full].[GRUP KOD] = '" + GrupKodlar[i].ToString() + "' OR ";

            if (GrupKodlar.Count > 0)
                grupkodlar = "(" + grupkodlar.Substring(0, grupkodlar.Length - 4) + ") AND ";



            Aranan = Aranan.ToUpper().Replace("'", " ").Replace("%", "").Replace("--", "").Replace("/*", "").Replace("*/", "").Replace(" OR ", " ").Replace(" AND ", " ").Replace(" LIKE ", " ");
            //Aranan = Aranan.ToUpper().Replace("İ", "I").Replace("Ü", "U").Replace("Ö", "O").Replace("Ş", "S").Replace("Ç", "C").Replace("Ğ", "G");

            string malacik = string.Empty;
            string[] aramakelimeler = new string[1];

            if (AramaBasi == string.Empty)
                aramakelimeler[0] = Aranan;
            else
                aramakelimeler = Aranan.Split(new string[] { " " }, StringSplitOptions.None);

            for (int i = 0; i < aramakelimeler.Length; i++)
                malacik += "[Web-Malzeme-Full].[MAL ACIK] LIKE '" + AramaBasi + aramakelimeler[i] + "%' AND ";

            if (malacik == string.Empty)
                malacik = "[Web-Malzeme-Full].[MAL ACIK] IS NOT NULL ";
            else
                malacik = malacik.Substring(0, malacik.Length - 4);




            string YeniUrunler = string.Empty;
            //if (Yeni)
            //    YeniKampanyalar = " AND [KYTM] < 16";

            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT DISTINCT [Web-Malzeme-Full].[HK] FROM [Web-Malzeme-Full] " +
                    "WHERE " +
                    ozelkodlar + grupkodlar +
                    //"[KurumsalWebSAP].dbo.[Web-Malzeme].[OZEL KOD] " + TedarikciOperator + " " + Tedarikci + " AND " +
                    "[Web-Malzeme-Full].[REY KOD] " + KategoriOperator + " " + Kategori + YeniUrunler +
                    " AND " + malacik, conn);
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
        /// Iade için, web36 full urun listesi, fiyat tipi parametresi yok
        /// </summary>
        public static void GetKategoriHangiHarfler(DataTable dt, string Tedarikci, string TedarikciOperator,
            /*string Kategori, string KategoriOperator, */string AramaBasi, string Aranan, ArrayList OzelKodlar, ArrayList GrupKodlar)
        {
            string ozelkodlar = string.Empty;
            string grupkodlar = string.Empty;

            for (int i = 0; i < OzelKodlar.Count; i++)
                ozelkodlar += "[Web-Malzeme-Full].[OZEL KOD] = '" + OzelKodlar[i].ToString() + "' OR ";

            if (OzelKodlar.Count > 0)
                ozelkodlar = "(" + ozelkodlar.Substring(0, ozelkodlar.Length - 4) + ") AND ";

            for (int i = 0; i < GrupKodlar.Count; i++)
                grupkodlar += "[Web-Malzeme-Full].[GRUP KOD] = '" + GrupKodlar[i].ToString() + "' OR ";

            if (GrupKodlar.Count > 0)
                grupkodlar = "(" + grupkodlar.Substring(0, grupkodlar.Length - 4) + ") AND ";



            Aranan = Aranan.ToUpper().Replace("'", " ").Replace("%", "").Replace("--", "").Replace("/*", "").Replace("*/", "").Replace(" OR ", " ").Replace(" AND ", " ").Replace(" LIKE ", " ");
            //Aranan = Aranan.ToUpper().Replace("İ", "I").Replace("Ü", "U").Replace("Ö", "O").Replace("Ş", "S").Replace("Ç", "C").Replace("Ğ", "G");

            string malacik = string.Empty;
            string[] aramakelimeler = new string[1];

            if (AramaBasi == string.Empty)
                aramakelimeler[0] = Aranan;
            else
                aramakelimeler = Aranan.Split(new string[] { " " }, StringSplitOptions.None);

            for (int i = 0; i < aramakelimeler.Length; i++)
                malacik += "[Web-Malzeme-Full].[MAL ACIK] LIKE '" + AramaBasi + aramakelimeler[i] + "%' AND ";

            if (malacik == string.Empty)
                malacik = "[Web-Malzeme-Full].[MAL ACIK] IS NOT NULL ";
            else
                malacik = malacik.Substring(0, malacik.Length - 4);




            string YeniUrunler = string.Empty;
            //if (Yeni)
            //    YeniKampanyalar = " AND [KYTM] < 16";

            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT DISTINCT [Web-Malzeme-Full].[RK] FROM [Web-Malzeme-Full] " +
                    "WHERE " +
                    ozelkodlar + grupkodlar +
                    "[Web-Malzeme-Full].[OZEL KOD] " + TedarikciOperator + " " + Tedarikci +
                    /*" AND [KurumsalWebSAP].dbo.[Web-Malzeme].[REY KOD] " + KategoriOperator + " " + Kategori + */YeniUrunler +
                    " AND " + malacik, conn);
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
        /// İade için, web36 full urun listesi
        /// </summary>
        public static string GetProductName(int UrunID, bool Web36)
        {
            string donendeger = string.Empty;

            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3))
            {
                SqlCommand cmd = new SqlCommand("SELECT [MAL ACIK] AS Ad FROM [Web-Malzeme-Full] WHERE [ITEMREF] = @ITEMREF", conn);
                cmd.Parameters.Add("@ITEMREF", System.Data.SqlDbType.Int).Value = UrunID;
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
        /// İade için, web36 full urun listesi
        /// </summary>
        public static string GetProductOzelKod(int UrunID, bool Web36)
        {
            string donendeger = string.Empty;

            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3))
            {
                SqlCommand cmd = new SqlCommand("SELECT [OZEL KOD] FROM [Web-Malzeme-Full] WHERE [ITEMREF] = @ITEMREF", conn);
                cmd.Parameters.Add("@ITEMREF", System.Data.SqlDbType.Int).Value = UrunID;
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
        /// İade için, web36 full urun listesi
        /// </summary>
        public static string GetProductBarkod(int UrunID, bool Web36)
        {
            string donendeger = string.Empty;

            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3))
            {
                SqlCommand cmd = new SqlCommand("SELECT [BARKOD] FROM [Web-Malzeme-Full] WHERE [ITEMREF] = @ITEMREF", conn);
                cmd.Parameters.Add("@ITEMREF", System.Data.SqlDbType.Int).Value = UrunID;
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
        /// İade için, web36 full urun listesi
        /// </summary>
        public static double GetProductKDV(int UrunID, bool Web36)
        {
            double donendeger = 0;

            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3))
            {
                SqlCommand cmd = new SqlCommand("SELECT [KDV] FROM [Web-Malzeme-Full] WHERE [ITEMREF] = @ITEMREF", conn);
                cmd.Parameters.Add("@ITEMREF", System.Data.SqlDbType.Int).Value = UrunID;
                try
                {
                    conn.Open();
                    object obj = cmd.ExecuteScalar();
                    if (obj != null)
                        donendeger = Convert.ToDouble(obj);
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
        //
        //
        // Yeni Tedarikçi ve Kategori Süzmeleri:
        // [Web-Malzeme-Full]
        public static void GetTedarikciler2iade(string harf, string KategoriID, string AramaBasi, string Aranan, ListItemCollection lic, ArrayList OzelKodlar, ArrayList GrupKodlar, bool UrunSayisiniYaz)
        {
            string kategoriid = "";
            if (KategoriID == "NOT NULL")
                kategoriid = "IS NOT NULL";
            else
                kategoriid = "= " + KategoriID;

            string ozelkodlar = string.Empty;
            string grupkodlar = string.Empty;

            for (int i = 0; i < OzelKodlar.Count; i++)
                ozelkodlar += "[Web-Malzeme-Full].[OZEL KOD] = '" + OzelKodlar[i].ToString() + "' OR ";

            if (OzelKodlar.Count > 0)
                ozelkodlar = "(" + ozelkodlar.Substring(0, ozelkodlar.Length - 4) + ") AND ";

            for (int i = 0; i < GrupKodlar.Count; i++)
                grupkodlar += "[Web-Malzeme-Full].[GRUP KOD] = '" + GrupKodlar[i].ToString() + "' OR ";

            if (GrupKodlar.Count > 0)
                grupkodlar = "(" + grupkodlar.Substring(0, grupkodlar.Length - 4) + ") AND ";

            if (harf == "C")
                harf = harf + "' OR [Web-Malzeme-Full].[HK] = 'Ç";
            else if (harf == "G")
                harf = harf + "' OR [Web-Malzeme-Full].[HK] = 'Ğ";
            else if (harf == "I")
                harf = harf + "' OR [Web-Malzeme-Full].[HK] = 'İ";
            else if (harf == "O")
                harf = harf + "' OR [Web-Malzeme-Full].[HK] = 'Ö";
            else if (harf == "S")
                harf = harf + "' OR [Web-Malzeme-Full].[HK] = 'Ş";
            else if (harf == "U")
                harf = harf + "' OR [Web-Malzeme-Full].[HK] = 'Ü";

            Aranan = Aranan.ToUpper().Replace("'", " ").Replace("%", "").Replace("--", "").Replace("/*", "").Replace("*/", "").Replace(" OR ", " ").Replace(" AND ", " ").Replace(" LIKE ", " ");
            //Aranan = Aranan.ToUpper().Replace("İ", "I").Replace("Ü", "U").Replace("Ö", "O").Replace("Ş", "S").Replace("Ç", "C").Replace("Ğ", "G");

            string malacik = string.Empty;
            string[] aramakelimeler = new string[1];

            if (AramaBasi == string.Empty)
                aramakelimeler[0] = Aranan;
            else
                aramakelimeler = Aranan.Split(new string[] { " " }, StringSplitOptions.None);

            for (int i = 0; i < aramakelimeler.Length; i++)
                malacik += "[Web-Malzeme-Full].[MAL ACIK] LIKE '" + AramaBasi + aramakelimeler[i] + "%' AND ";

            if (malacik == string.Empty)
                malacik = "[Web-Malzeme-Full].[MAL ACIK] IS NOT NULL ";
            else
                malacik = malacik.Substring(0, malacik.Length - 4);



            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3))
            {
                SqlCommand cmd = new SqlCommand("SELECT count(DISTINCT [Web-Malzeme-Full].[ITEMREF]),[Web-Malzeme-Full].[OZEL KOD],[Web-Malzeme-Full].[OZEL ACIK] FROM [Web-Malzeme-Full] WHERE ([Web-Malzeme-Full].[HK] = '" + harf + "') AND [Web-Malzeme-Full].[REY KOD] " + kategoriid + " AND " + ozelkodlar + grupkodlar + malacik + " GROUP BY [Web-Malzeme-Full].[OZEL KOD],[Web-Malzeme-Full].[OZEL ACIK] ORDER BY [Web-Malzeme-Full].[OZEL ACIK]", conn);
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        ListItem lst = new ListItem();
                        lst.Text = dr[2].ToString();
                        if (UrunSayisiniYaz)
                            lst.Text += " (" + dr[0].ToString() + ")";
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
        // [Web-Malzeme-Full]
        public static void GetKategoriler2iade(string harf, string TedarikciID, string AramaBasi, string Aranan, ListItemCollection lic, ArrayList OzelKodlar, ArrayList GrupKodlar, bool UrunSayisiniYaz)
        {
            string tedarikciid = "";
            if (TedarikciID == "NOT NULL")
                tedarikciid = "IS NOT NULL";
            else
                tedarikciid = "= " + TedarikciID;

            string ozelkodlar = string.Empty;
            string grupkodlar = string.Empty;

            for (int i = 0; i < OzelKodlar.Count; i++)
                ozelkodlar += "[Web-Malzeme-Full].[OZEL KOD] = '" + OzelKodlar[i].ToString() + "' OR ";

            if (OzelKodlar.Count > 0)
                ozelkodlar = "(" + ozelkodlar.Substring(0, ozelkodlar.Length - 4) + ") AND ";

            for (int i = 0; i < GrupKodlar.Count; i++)
                grupkodlar += "[Web-Malzeme-Full].[GRUP KOD] = '" + GrupKodlar[i].ToString() + "' OR ";

            if (GrupKodlar.Count > 0)
                grupkodlar = "(" + grupkodlar.Substring(0, grupkodlar.Length - 4) + ") AND ";

            if (harf == "C")
                harf = harf + "' OR [Web-Malzeme-Full].[RK] = 'Ç";
            else if (harf == "G")
                harf = harf + "' OR [Web-Malzeme-Full].[RK] = 'Ğ";
            else if (harf == "I")
                harf = harf + "' OR [Web-Malzeme-Full].[RK] = 'İ";
            else if (harf == "O")
                harf = harf + "' OR [Web-Malzeme-Full].[RK] = 'Ö";
            else if (harf == "S")
                harf = harf + "' OR [Web-Malzeme-Full].[RK] = 'Ş";
            else if (harf == "U")
                harf = harf + "' OR [Web-Malzeme-Full].[RK] = 'Ü";

            Aranan = Aranan.ToUpper().Replace("'", " ").Replace("%", "").Replace("--", "").Replace("/*", "").Replace("*/", "").Replace(" OR ", " ").Replace(" AND ", " ").Replace(" LIKE ", " ");
            //Aranan = Aranan.ToUpper().Replace("İ", "I").Replace("Ü", "U").Replace("Ö", "O").Replace("Ş", "S").Replace("Ç", "C").Replace("Ğ", "G");

            string malacik = string.Empty;
            string[] aramakelimeler = new string[1];

            if (AramaBasi == string.Empty)
                aramakelimeler[0] = Aranan;
            else
                aramakelimeler = Aranan.Split(new string[] { " " }, StringSplitOptions.None);

            for (int i = 0; i < aramakelimeler.Length; i++)
                malacik += "[Web-Malzeme-Full].[MAL ACIK] LIKE '" + AramaBasi + aramakelimeler[i] + "%' AND ";

            if (malacik == string.Empty)
                malacik = "[Web-Malzeme-Full].[MAL ACIK] IS NOT NULL ";
            else
                malacik = malacik.Substring(0, malacik.Length - 4);



            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3))
            {
                SqlCommand cmd = new SqlCommand("SELECT count(DISTINCT [Web-Malzeme-Full].[ITEMREF]),[Web-Malzeme-Full].[REY KOD],[Web-Malzeme-Full].[REY ACIK] FROM [Web-Malzeme-Full] WHERE ([Web-Malzeme-Full].[RK] = '" + harf + "') AND [Web-Malzeme-Full].[OZEL KOD] " + tedarikciid + " AND " + ozelkodlar + grupkodlar + malacik + " GROUP BY [Web-Malzeme-Full].[REY KOD],[Web-Malzeme-Full].[REY ACIK] ORDER BY [Web-Malzeme-Full].[REY ACIK]", conn);
                SqlDataReader dr;

                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        ListItem lst = new ListItem();
                        lst.Text = dr[2].ToString();
                        if (UrunSayisiniYaz)
                            lst.Text += " (" + dr[0].ToString() + ")";
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
        #endregion
        //
        //
        #region hedef
        public static double GetHedef(int SLSREF, int SMREF, int YIL, int AY, int PRIMB, bool bonus)
        {
            double donendeger = 0;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                string tablo = bonus ? "[Web-Hedef-2]" : "[Web-Hedef]";

                SqlCommand cmd = new SqlCommand("SELECT [HEDEF] FROM " + tablo + " WHERE SLSREF = @SLSREF AND SMREF = @SMREF AND YIL = @YIL AND AY = @AY AND  PRIMB = @PRIMB", conn);
                cmd.Parameters.Add("@SLSREF", System.Data.SqlDbType.Int).Value = SLSREF;
                cmd.Parameters.Add("@SMREF", System.Data.SqlDbType.Int).Value = SMREF;
                cmd.Parameters.Add("@YIL", System.Data.SqlDbType.Int).Value = YIL;
                cmd.Parameters.Add("@AY", System.Data.SqlDbType.Int).Value = AY;
                cmd.Parameters.Add("@PRIMB", System.Data.SqlDbType.Int).Value = PRIMB;
                try
                {
                    conn.Open();
                    donendeger = Convert.ToDouble(cmd.ExecuteScalar());
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

        public static void SetHedef(int SLSREF, int SMREF, int YIL, int AY, int PRIMB, double HEDEF, bool bonus)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                string tablo = bonus ? "[Web-Hedef-2]" : "[Web-Hedef]";

                SqlCommand cmd1 = new SqlCommand("SELECT count(*) FROM " + tablo + " WHERE SLSREF = @SLSREF AND SMREF = @SMREF AND YIL = @YIL AND AY = @AY AND PRIMB = @PRIMB", conn);
                cmd1.Parameters.Add("@SLSREF", System.Data.SqlDbType.Int).Value = SLSREF;
                cmd1.Parameters.Add("@SMREF", System.Data.SqlDbType.Int).Value = SMREF;
                cmd1.Parameters.Add("@YIL", System.Data.SqlDbType.Int).Value = YIL;
                cmd1.Parameters.Add("@AY", System.Data.SqlDbType.Int).Value = AY;
                cmd1.Parameters.Add("@PRIMB", System.Data.SqlDbType.Int).Value = PRIMB;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.Parameters.Add("@SLSREF", System.Data.SqlDbType.Int).Value = SLSREF;
                cmd.Parameters.Add("@SMREF", System.Data.SqlDbType.Int).Value = SMREF;
                cmd.Parameters.Add("@YIL", System.Data.SqlDbType.Int).Value = YIL;
                cmd.Parameters.Add("@AY", System.Data.SqlDbType.Int).Value = AY;
                cmd.Parameters.Add("@PRIMB", System.Data.SqlDbType.Int).Value = PRIMB;
                cmd.Parameters.Add("@HEDEF", System.Data.SqlDbType.Float).Value = HEDEF;
                try
                {
                    conn.Open();
                    if (Convert.ToBoolean(cmd1.ExecuteScalar()))
                        cmd.CommandText = "UPDATE " + tablo + " SET [HEDEF] = @HEDEF WHERE SLSREF = @SLSREF AND SMREF = @SMREF AND YIL = @YIL AND AY = @AY AND PRIMB = @PRIMB";
                    else
                        cmd.CommandText = "INSERT INTO " + tablo + " (SLSREF,SMREF,YIL,AY,PRIMB,HEDEF) VALUES (@SLSREF,@SMREF,@YIL,@AY,@PRIMB,@HEDEF)";
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

        public static void SilHedef(int SLSREF, int SMREF, int YIL, int AY, bool bonus)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                string tablo = bonus ? "[Web-Hedef-2]" : "[Web-Hedef]";

                SqlCommand cmd1 = new SqlCommand("DELETE FROM " + tablo + " WHERE SLSREF = @SLSREF AND SMREF = @SMREF AND YIL = @YIL AND AY = @AY", conn);
                cmd1.Parameters.Add("@SLSREF", System.Data.SqlDbType.Int).Value = SLSREF;
                cmd1.Parameters.Add("@SMREF", System.Data.SqlDbType.Int).Value = SMREF;
                cmd1.Parameters.Add("@YIL", System.Data.SqlDbType.Int).Value = YIL;
                cmd1.Parameters.Add("@AY", System.Data.SqlDbType.Int).Value = AY;

                try
                {
                    conn.Open();
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

        public static void GetHedefler(DataTable dt, bool bonus)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                string tablo = bonus ? "[Web-Hedef-2]" : "[Web-Hedef]";

                SqlDataAdapter da = new SqlDataAdapter("SELECT SLSREF,(SELECT [SAT TEM] FROM [Web-SatisTemsilcileri] WHERE SLSMANREF = " + tablo + ".SLSREF) AS PERSONEL,SMREF,(SELECT TOP 1 MUSTERI FROM [Web-Musteri] WHERE SMREF = " + tablo + ".SMREF) AS BAYI,YIL,AY,PRIMB,(SELECT [MAL ACIK] FROM [Web-Malzeme-Full] WHERE [ITEMREF] = " + tablo + ".PRIMB) AS PRIMGRUBU,HEDEF FROM " + tablo + " WHERE YIL = YEAR(getdate()) ORDER BY BAYI,PERSONEL,YIL,AY", conn);
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
        #endregion
    }

    public class PrimKategorileri
    {
        private string _PRIMB; private string _PRIM;
        public PrimKategorileri(string PRIMB, string PRIM) { this._PRIMB = PRIMB; this._PRIM = PRIM; }
        public string PRIMB { get { return this._PRIMB; } } public string PRIM { get { return this._PRIM; } }
        public override string ToString() { return this._PRIM; }

        public static void GetObjects(IList List)
        {
            List.Clear();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT [PG_B_Z],[PG_B_Z_ACIKLAMA] FROM [SAP_PRM_GRP] WHERE PG_B_Z_1 >= 12 ORDER BY [PG_B_Z_ACIKLAMA]", conn);
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        List.Add(new PrimKategorileri(dr[0].ToString(), dr[1].ToString()));
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

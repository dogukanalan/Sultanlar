using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sultanlar.DatabaseObject.Internet
{
    public class FiyatListeleri : ISultanlar, IDisposable
    {
        //
        //
        //
        // Alanlar:
        //
        private int _intFiyatTipi;
        private byte[] _binDosya;
        //
        //
        //
        // Constracter lar:
        //
        public FiyatListeleri(int intFiyatTipi, byte[] binDosya)
        {
            this._intFiyatTipi = intFiyatTipi;
            this._binDosya = binDosya;
        }
        //
        //
        //
        // Özellikler:
        //
        public int intFiyatTipi
        {
            get
            {
                return this._intFiyatTipi;
            }
        }
        //
        //
        public byte[] binDosya
        {
            get
            {
                return this._binDosya;
            }
            set
            {
                this._binDosya = value;
            }
        }
        //
        //
        //
        // Yoketme metodu:
        //
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        //
        //
        //
        // ToString:
        //
        public override string ToString()
        {
            return FiyatTipleri.GetObjectByID(Convert.ToInt16(this._intFiyatTipi));
        }
        //
        //
        //
        // Metodlar:
        //
        public void DoInsert()
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_INTERNET_FiyatListeEkle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@binDosya", SqlDbType.VarBinary).Value = this._binDosya;
                cmd.Parameters.Add("@intFiyatTipi", SqlDbType.Int).Value = this._intFiyatTipi;
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
        //
        //
        public void DoUpdate()
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_INTERNET_FiyatListeGuncelle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@intFiyatTipi", SqlDbType.Int).Value = this._intFiyatTipi;
                cmd.Parameters.Add("@binDosya", SqlDbType.VarBinary).Value = this._binDosya;
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
        //
        //
        public void DoDelete()
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_INTERNET_FiyatListeSil", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@intFiyatTipi", SqlDbType.Int).Value = this._intFiyatTipi;
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
        //
        //
        public static void GetObjects(IList List, bool UI)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                List.Clear();

                SqlCommand cmd = new SqlCommand("sp_INTERNET_FiyatListeleriGetir", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        List.Add(new FiyatListeleri(Convert.ToInt32(dr[0]), (byte[])dr[1]));
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
        public static byte[] GetObjectByFiyatTipiID(int FiyatTipi)
        {
            byte[] donendeger = null;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_INTERNET_FiyatListeGetirByFiyatTipiID", conn);
                cmd.Parameters.Add("@intFiyatTipi", SqlDbType.Int).Value = FiyatTipi;
                cmd.CommandType = CommandType.StoredProcedure;
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
        //
        //
        public static void GetObjects(DataTable dt, ArrayList YetkiliFiyatTipleri)
        {
            DataTable butundt = new DataTable();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT NOSU AS intFiyatTipi FROM [Web-FiyatTipleri] ORDER BY NOSU", conn);
                //da.SelectCommand.CommandType = CommandType.StoredProcedure;
                try
                {
                    conn.Open();
                    da.Fill(butundt);
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


            butundt.Columns.Add("ACIKLAMA", typeof(string));
            for (int i = 0; i < butundt.Columns.Count; i++)
                dt.Columns.Add(butundt.Columns[i].ColumnName, butundt.Columns[i].DataType);


            for (int i = 0; i < butundt.Rows.Count; i++)
            {
                butundt.Rows[i]["ACIKLAMA"] = FiyatTipleri.GetObjectByID(Convert.ToInt16(butundt.Rows[i]["intFiyatTipi"]));

                for (int j = 0; j < YetkiliFiyatTipleri.Count; j++)
                {
                    if (Convert.ToInt16(butundt.Rows[i]["intFiyatTipi"]) == Convert.ToInt16(YetkiliFiyatTipleri[j]))
                    {
                        DataRow drow = dt.NewRow();
                        drow.ItemArray = butundt.Rows[i].ItemArray;
                        dt.Rows.Add(drow);
                    }
                }
            }
        }
        /// <summary>
        /// FiyatTipi: 3,4,5,6,7,8,10,11,14,15,16,17,18,19,21
        /// where formatı "WHERE [ALT GRP] = '104' " gibi olacak, veya bir parametre gibi kullanılabilir where yok ise
        /// </summary>
        public static void GetObjectXml(DataTable dt, short FiyatTipi, string where)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter();

                if (FiyatTipi == 3 && where == "n11") // 0
                    da = new SqlDataAdapter("sp_xml_n11", conn);
                else if (FiyatTipi == 3 && where == "shupsy") // 0
                    da = new SqlDataAdapter("sp_xml_shupsy", conn);
                else if (FiyatTipi == 3 && where == "sefamerve") // 0
                    da = new SqlDataAdapter("sp_xml_sefamerve", conn);
                else if (FiyatTipi == 3 && where == "amazon") // 0
                    da = new SqlDataAdapter("sp_xml_amazon", conn);
                else if (FiyatTipi == 7 && where == "hepsiburada") // 0
                    da = new SqlDataAdapter("SELECT REYON AS KategoriAdi,[SUL_Fiyatlar_07_00_Stok].ITEMREF AS UrunID,dbo.IlkHarfBuyuk(dbo.UrunMalzemeKisaltmalar(MALZEME)) AS UrunAdi,'<![CDATA[' + CASE WHEN (SELECT ACIKLAMA FROM [Web-Malzeme-Aciklama] WHERE ITEMREF = KurumsalWebSAP.dbo.[SUL_Fiyatlar_07_00_Stok].ITEMREF) IS NULL THEN dbo.IlkHarfBuyuk(dbo.UrunMalzemeKisaltmalar(MALZEME)) WHEN (SELECT ACIKLAMA FROM [Web-Malzeme-Aciklama] WHERE ITEMREF = KurumsalWebSAP.dbo.[SUL_Fiyatlar_07_00_Stok].ITEMREF) = '' THEN dbo.IlkHarfBuyuk(dbo.UrunMalzemeKisaltmalar(MALZEME)) COLLATE DATABASE_DEFAULT ELSE (SELECT ACIKLAMA FROM [Web-Malzeme-Aciklama] WHERE ITEMREF = KurumsalWebSAP.dbo.[SUL_Fiyatlar_07_00_Stok].ITEMREF) END + ']]>' AS UrunAciklamasi,ISNULL((SELECT MARKA FROM [Web-Malzeme-Aciklama] INNER JOIN [Web-Malzeme-Marka] ON [Web-Malzeme-Aciklama].MARKAREF = [Web-Malzeme-Marka].REF WHERE ITEMREF = KurumsalWebSAP.dbo.[SUL_Fiyatlar_07_00_Stok].ITEMREF),'') AS Marka,KDV AS KDV,CONVERT(decimal(18,2),[NET] * 1.50) AS OzelFiyat,CONVERT(decimal(18,2),([NET ] * 1.60)) AS ListeFiyat,'TL' AS Kur,STOK AS StokAdedi,BARKOD AS Barcode,'https://www.sultanlar.com.tr/musteri/resim-' + IsNull(CONVERT(VARCHAR(MAX),max(intResimID)),'0') + '.html' AS ImageName1 FROM KurumsalWebSAP.dbo.[SUL_Fiyatlar_07_00_Stok] INNER JOIN tblINTERNET_UrunResim ON tblINTERNET_UrunResim.ITEMREF = [SUL_Fiyatlar_07_00_Stok].ITEMREF WHERE ([ANA GRP] = 'AHT' OR [ANA GRP] = 'YEG') AND (SELECT count(REF) FROM [Web-Malzeme-Aciklama] WHERE ITEMREF = [SUL_Fiyatlar_07_00_Stok].ITEMREF AND [KATEGORIREF] != 0 AND [MARKAREF] != 0 AND [CINSIYETREF] != 0) > 0 GROUP BY REYON,[SUL_Fiyatlar_07_00_Stok].ITEMREF,MALZEME,STOK,[NET],KDV,BARKOD ORDER BY MALZEME", conn);
                else if (FiyatTipi == 7 && where == "gg") // 0
                    da = new SqlDataAdapter("SELECT [SUL_Fiyatlar_07_00_Stok].ITEMREF AS 'Kod',dbo.IlkHarfBuyuk(dbo.UrunMalzemeKisaltmalar(MALZEME)) AS 'Baslik',ISNULL((SELECT MARKA FROM [Web-Malzeme-Aciklama] INNER JOIN [Web-Malzeme-Marka] ON [Web-Malzeme-Aciklama].MARKAREF = [Web-Malzeme-Marka].REF WHERE ITEMREF = KurumsalWebSAP.dbo.[SUL_Fiyatlar_07_00_Stok].ITEMREF),'') AS 'Marka',CASE WHEN (SELECT ACIKLAMA FROM [Web-Malzeme-Aciklama] WHERE ITEMREF = KurumsalWebSAP.dbo.[SUL_Fiyatlar_07_00_Stok].ITEMREF) IS NULL THEN dbo.IlkHarfBuyuk(dbo.UrunMalzemeKisaltmalar(MALZEME)) WHEN (SELECT ACIKLAMA FROM [Web-Malzeme-Aciklama] WHERE ITEMREF = KurumsalWebSAP.dbo.[SUL_Fiyatlar_07_00_Stok].ITEMREF) = '' THEN dbo.IlkHarfBuyuk(dbo.UrunMalzemeKisaltmalar(MALZEME)) COLLATE DATABASE_DEFAULT ELSE (SELECT ACIKLAMA FROM [Web-Malzeme-Aciklama] WHERE ITEMREF = KurumsalWebSAP.dbo.[SUL_Fiyatlar_07_00_Stok].ITEMREF) END AS Aciklama,ISNULL((SELECT KATEGORI FROM [Web-Malzeme-Aciklama] INNER JOIN [Web-Malzeme-ReyonKategori] ON [Web-Malzeme-Aciklama].KATEGORIREF = [Web-Malzeme-ReyonKategori].REF WHERE ITEMREF = KurumsalWebSAP.dbo.[SUL_Fiyatlar_07_00_Stok].ITEMREF),'') AS 'Kategori',CONVERT(decimal(18,2),([NET] * 1.50)) AS 'Fiyat',CONVERT(decimal(18,2),([NET ] * 1.60)) AS 'PSF',KDV AS 'KDV','Beyaz' AS 'Renk','https://www.sultanlar.com.tr/musteri/resim-' + IsNull(CONVERT(VARCHAR(MAX),max(intResimID)),'0') + '.jpg' AS 'ImageName1',STOK AS 'miktar' FROM KurumsalWebSAP.dbo.[SUL_Fiyatlar_07_00_Stok] INNER JOIN tblINTERNET_UrunResim ON tblINTERNET_UrunResim.ITEMREF = [SUL_Fiyatlar_07_00_Stok].ITEMREF WHERE ([ANA GRP] = 'AHT' OR [ANA GRP] = 'YEG') AND (SELECT count(REF) FROM [Web-Malzeme-Aciklama] WHERE ITEMREF = [SUL_Fiyatlar_07_00_Stok].ITEMREF AND [KATEGORIREF] != 0 AND [MARKAREF] != 0 AND [CINSIYETREF] != 0) > 0 GROUP BY REYON,[SUL_Fiyatlar_07_00_Stok].ITEMREF,MALZEME,STOK,[NET],KDV,BARKOD ORDER BY MALZEME", conn);
                else if (FiyatTipi == 3)
                    da = new SqlDataAdapter("SELECT [ANA GRP],[ALT GRP],[GRUP],[REYON],KurumsalWebSAP.dbo.[SUL_Fiyatlar_03_00_Stok].[ITEMREF],[KOD],[MALZEME],[BARKOD],[BIRIM],[KOLI],[KDV],[KMP],[F ACIK],[ FIY],[ISK1],[ISK2],[ISK3],[ISK4],[ISK5],[ISK6],[ISK7],[ISK8],[ISK9],[ISK10],[NET+KDV],[VD],STOK,max(IsNull(intResimID,0)) AS Resim FROM KurumsalWebSAP.dbo.[SUL_Fiyatlar_03_00_Stok] LEFT OUTER JOIN tblINTERNET_UrunResim ON KurumsalWebSAP.dbo.[SUL_Fiyatlar_03_00_Stok].ITEMREF = tblINTERNET_UrunResim.ITEMREF " + where + "GROUP BY [ANA GRP],[ALT GRP],[GRUP],[REYON],KurumsalWebSAP.dbo.[SUL_Fiyatlar_03_00_Stok].[ITEMREF],[KOD],[MALZEME],[BARKOD],[BIRIM],[KOLI],[KDV],[KMP],[F ACIK],[ FIY],[ISK1],[ISK2],[ISK3],[ISK4],[ISK5],[ISK6],[ISK7],[ISK8],[ISK9],[ISK10],[NET+KDV],[VD],[STOK] ORDER BY MALZEME", conn);
                else if (FiyatTipi == 4)
                    da = new SqlDataAdapter("SELECT [ANA GRP],[ALT GRP],[GRUP],[REYON],KurumsalWebSAP.dbo.[SUL_Fiyatlar_04_00_Stok].[ITEMREF],[KOD],[MALZEME],[BARKOD],[BIRIM],[KOLI],[KDV],[KMP],[F ACIK],[ FIY],[ISK1],[ISK2],[ISK3],[ISK4],[ISK5],[ISK6],[ISK7],[ISK8],[ISK9],[ISK10],[NET+KDV],[VD],STOK,'https://www.sultanlar.com.tr/musteri/resim-' + IsNull(CONVERT(VARCHAR(MAX),(SELECT TOP 1 intResimID FROM tblINTERNET_UrunResim WHERE ITEMREF = [SUL_Fiyatlar_04_00_Stok].ITEMREF ORDER BY intResimID DESC)),'0') + '.html' AS Resim FROM KurumsalWebSAP.dbo.[SUL_Fiyatlar_04_00_Stok] " + where + "ORDER BY MALZEME", conn);
                else if (FiyatTipi == 5)
                    da = new SqlDataAdapter("SELECT [ANA GRP],[ALT GRP],[GRUP],[REYON],KurumsalWebSAP.dbo.[SUL_Fiyatlar_05_00_Stok].[ITEMREF],[KOD],[MALZEME],[BARKOD],[BIRIM],[KOLI],[KDV],[KMP],[F ACIK],[ FIY],[ISK1],[ISK2],[ISK3],[ISK4],[ISK5],[ISK6],[ISK7],[ISK8],[ISK9],[ISK10],[NET+KDV],[VD],STOK,max(IsNull(intResimID,0)) AS Resim FROM KurumsalWebSAP.dbo.[SUL_Fiyatlar_05_00_Stok] LEFT OUTER JOIN tblINTERNET_UrunResim ON KurumsalWebSAP.dbo.[SUL_Fiyatlar_05_00_Stok].ITEMREF = tblINTERNET_UrunResim.ITEMREF " + where + "GROUP BY [ANA GRP],[ALT GRP],[GRUP],[REYON],KurumsalWebSAP.dbo.[SUL_Fiyatlar_05_00_Stok].[ITEMREF],[KOD],[MALZEME],[BARKOD],[BIRIM],[KOLI],[KDV],[KMP],[F ACIK],[ FIY],[ISK1],[ISK2],[ISK3],[ISK4],[ISK5],[ISK6],[ISK7],[ISK8],[ISK9],[ISK10],[NET+KDV],[VD],[STOK] ORDER BY MALZEME", conn);
                else if (FiyatTipi == 6)
                    da = new SqlDataAdapter("SELECT [ANA GRP],[ALT GRP],[GRUP],[REYON],KurumsalWebSAP.dbo.[SUL_Fiyatlar_06_00_Stok].[ITEMREF],[KOD],MALZEME,[BARKOD],[BIRIM],[KOLI],[KDV],[KMP],[F ACIK],[ FIY],[ISK1],[ISK2],[ISK3],[ISK4],[ISK5],[ISK6],[ISK7],[ISK8],[ISK9],[ISK10],[NET+KDV],[VD],STOK,'https://www.sultanlar.com.tr/musteri/resim-' + IsNull(CONVERT(VARCHAR(MAX),(SELECT TOP 1 intResimID FROM tblINTERNET_UrunResim WHERE ITEMREF = [SUL_Fiyatlar_06_00_Stok].ITEMREF ORDER BY intResimID DESC)),'0') + '.html' AS Resim FROM KurumsalWebSAP.dbo.[SUL_Fiyatlar_06_00_Stok] " + where + "ORDER BY MALZEME", conn);
                else if (FiyatTipi == 7 && where == "komsu") // 0
                    da = new SqlDataAdapter("SELECT [SUL_Fiyatlar_18_00_Stok].ITEMREF AS Kod,dbo.IlkHarfBuyuk(dbo.UrunMalzemeKisaltmalar(MALZEME)) AS Baslik,MALZEME AS AltBaslik,CASE WHEN [Web-Malzeme-Aciklama].ACIKLAMA = '' THEN MALZEME ELSE [Web-Malzeme-Aciklama].ACIKLAMA COLLATE DATABASE_DEFAULT END AS Aciklama,(SELECT KATEGORI FROM [Web-Malzeme-ReyonKategori] WHERE REF = [Web-Malzeme-Aciklama].KATEGORIREF) AS KategoriAdi1,/*CONVERT(decimal(18,2),([NET+KDV] / ((100 + KDV) / 100)) * 1.62) AS Fiyat,*/KDV AS Kdv,(SELECT MARKA FROM [Web-Malzeme-Marka] WHERE REF = [Web-Malzeme-Aciklama].MARKAREF) AS KategoriAdi,(SELECT MARKA FROM [Web-Malzeme-Marka] WHERE REF = [Web-Malzeme-Aciklama].MARKAREF) AS Marka,STOKE+STOK AS Stoklar,CONVERT(decimal(18,2),([NET+KDV] / ((100 + KDV) / 100)) * 1) AS Fiyat,'https://www.sultanlar.com.tr/musteri/resim-' + IsNull(CONVERT(VARCHAR(MAX),max(intResimID)),'0') + '.jpg' AS Resim FROM KurumsalWebSAP.dbo.[SUL_Fiyatlar_18_00_Stok] INNER JOIN [Web-Malzeme-Aciklama] ON KurumsalWebSAP.dbo.[SUL_Fiyatlar_18_00_Stok].ITEMREF = [Web-Malzeme-Aciklama].ITEMREF INNER JOIN tblINTERNET_UrunResim ON tblINTERNET_UrunResim.ITEMREF = [SUL_Fiyatlar_18_00_Stok].ITEMREF WHERE ([ANA GRP] = 'AHT' OR [ANA GRP] = 'YEG') AND (SELECT count(REF) FROM [Web-Malzeme-Aciklama] WHERE ITEMREF = [SUL_Fiyatlar_18_00_Stok].ITEMREF AND [KATEGORIREF] != 0 AND [MARKAREF] != 0 AND [CINSIYETREF] != 0) > 0 GROUP BY [SUL_Fiyatlar_18_00_Stok].ITEMREF,MALZEME,[Web-Malzeme-Aciklama].ACIKLAMA,[Web-Malzeme-Aciklama].KATEGORIREF,[Web-Malzeme-Aciklama].MARKAREF,STOKE,STOK,[NET+KDV],KDV ORDER BY MALZEME", conn);
                else if (FiyatTipi == 7) // 0
                    da = new SqlDataAdapter("SELECT [ANA GRP],[ALT GRP],[GRUP],[REYON],KurumsalWebSAP.dbo.[SUL_Fiyatlar_07_00_Stok].[ITEMREF],[KOD],[MALZEME],[BARKOD],[BIRIM],[KOLI],[KDV],[KMP],[F ACIK],[ FIY],[ISK1],[ISK2],[ISK3],[ISK4],[ISK5],[ISK6],[ISK7],[ISK8],[ISK9],[ISK10],[NET+KDV],[VD],STOK AS STOK,'https://www.sultanlar.com.tr/musteri/resim-' + IsNull(CONVERT(VARCHAR(MAX),max(intResimID)),'0') + '.jpg' AS Resim FROM KurumsalWebSAP.dbo.[SUL_Fiyatlar_07_00_Stok] LEFT OUTER JOIN tblINTERNET_UrunResim ON KurumsalWebSAP.dbo.[SUL_Fiyatlar_07_00_Stok].ITEMREF = tblINTERNET_UrunResim.ITEMREF " + where + "GROUP BY [ANA GRP],[ALT GRP],[GRUP],[REYON],KurumsalWebSAP.dbo.[SUL_Fiyatlar_07_00_Stok].[ITEMREF],[KOD],[MALZEME],[BARKOD],[BIRIM],[KOLI],[KDV],[KMP],[F ACIK],[ FIY],[ISK1],[ISK2],[ISK3],[ISK4],[ISK5],[ISK6],[ISK7],[ISK8],[ISK9],[ISK10],[NET+KDV],[VD],[STOK] ORDER BY MALZEME", conn);
                else if (FiyatTipi == 8)
                    da = new SqlDataAdapter("SELECT [ANA GRP],[ALT GRP],[GRUP],[REYON],KurumsalWebSAP.dbo.[SUL_Fiyatlar_08_00_Stok].[ITEMREF],[KOD],[MALZEME],[BARKOD],[BIRIM],[KOLI],[KDV],[KMP],[F ACIK],[ FIY],[ISK1],[ISK2],[ISK3],[ISK4],[ISK5],[ISK6],[ISK7],[ISK8],[ISK9],[ISK10],[NET+KDV],[VD],STOK,max(IsNull(intResimID,0)) AS Resim FROM KurumsalWebSAP.dbo.[SUL_Fiyatlar_08_00_Stok] LEFT OUTER JOIN tblINTERNET_UrunResim ON KurumsalWebSAP.dbo.[SUL_Fiyatlar_08_00_Stok].ITEMREF = tblINTERNET_UrunResim.ITEMREF " + where + "GROUP BY [ANA GRP],[ALT GRP],[GRUP],[REYON],KurumsalWebSAP.dbo.[SUL_Fiyatlar_08_00_Stok].[ITEMREF],[KOD],[MALZEME],[BARKOD],[BIRIM],[KOLI],[KDV],[KMP],[F ACIK],[ FIY],[ISK1],[ISK2],[ISK3],[ISK4],[ISK5],[ISK6],[ISK7],[ISK8],[ISK9],[ISK10],[NET+KDV],[VD],[STOK] ORDER BY MALZEME", conn);
                else if (FiyatTipi == 10)
                    da = new SqlDataAdapter("SELECT [ANA GRP],[ALT GRP],[GRUP],[REYON],KurumsalWebSAP.dbo.[SUL_Fiyatlar_10_00_Stok].[ITEMREF],[KOD],[MALZEME],[BARKOD],[BIRIM],[KOLI],[KDV],[KMP],[F ACIK],[ FIY],[ISK1],[ISK2],[ISK3],[ISK4],[ISK5],[ISK6],[ISK7],[ISK8],[ISK9],[ISK10],[NET+KDV],[VD],STOK,max(IsNull(intResimID,0)) AS Resim FROM KurumsalWebSAP.dbo.[SUL_Fiyatlar_10_00_Stok] LEFT OUTER JOIN tblINTERNET_UrunResim ON KurumsalWebSAP.dbo.[SUL_Fiyatlar_10_00_Stok].ITEMREF = tblINTERNET_UrunResim.ITEMREF " + where + "GROUP BY [ANA GRP],[ALT GRP],[GRUP],[REYON],KurumsalWebSAP.dbo.[SUL_Fiyatlar_10_00_Stok].[ITEMREF],[KOD],[MALZEME],[BARKOD],[BIRIM],[KOLI],[KDV],[KMP],[F ACIK],[ FIY],[ISK1],[ISK2],[ISK3],[ISK4],[ISK5],[ISK6],[ISK7],[ISK8],[ISK9],[ISK10],[NET+KDV],[VD],[STOK] ORDER BY MALZEME", conn);
                else if (FiyatTipi == 11)
                    da = new SqlDataAdapter("SELECT [ANA GRP],[ALT GRP],[GRUP],[REYON],KurumsalWebSAP.dbo.[SUL_Fiyatlar_11_00_Stok].[ITEMREF],[KOD],[MALZEME],[BARKOD],[BIRIM],[KOLI],[KDV],[KMP],[F ACIK],[ FIY],[ISK1],[ISK2],[ISK3],[ISK4],[ISK5],[ISK6],[ISK7],[ISK8],[ISK9],[ISK10],[NET+KDV],[VD],STOK,max(IsNull(intResimID,0)) AS Resim FROM KurumsalWebSAP.dbo.[SUL_Fiyatlar_11_00_Stok] LEFT OUTER JOIN tblINTERNET_UrunResim ON KurumsalWebSAP.dbo.[SUL_Fiyatlar_11_00_Stok].ITEMREF = tblINTERNET_UrunResim.ITEMREF " + where + "GROUP BY [ANA GRP],[ALT GRP],[GRUP],[REYON],KurumsalWebSAP.dbo.[SUL_Fiyatlar_11_00_Stok].[ITEMREF],[KOD],[MALZEME],[BARKOD],[BIRIM],[KOLI],[KDV],[KMP],[F ACIK],[ FIY],[ISK1],[ISK2],[ISK3],[ISK4],[ISK5],[ISK6],[ISK7],[ISK8],[ISK9],[ISK10],[NET+KDV],[VD],[STOK] ORDER BY MALZEME", conn);
                else if (FiyatTipi == 14)
                    da = new SqlDataAdapter("SELECT [ANA GRP],[ALT GRP],[GRUP],[REYON],KurumsalWebSAP.dbo.[SUL_Fiyatlar_14_00_Stok].[ITEMREF],[KOD],[MALZEME],[BARKOD],[BIRIM],[KOLI],[KDV],[KMP],[F ACIK],[ FIY],[ISK1],[ISK2],[ISK3],[ISK4],[ISK5],[ISK6],[ISK7],[ISK8],[ISK9],[ISK10],[NET+KDV],[VD],STOK,max(IsNull(intResimID,0)) AS Resim FROM KurumsalWebSAP.dbo.[SUL_Fiyatlar_14_00_Stok] LEFT OUTER JOIN tblINTERNET_UrunResim ON KurumsalWebSAP.dbo.[SUL_Fiyatlar_14_00_Stok].ITEMREF = tblINTERNET_UrunResim.ITEMREF " + where + "GROUP BY [ANA GRP],[ALT GRP],[GRUP],[REYON],KurumsalWebSAP.dbo.[SUL_Fiyatlar_14_00_Stok].[ITEMREF],[KOD],[MALZEME],[BARKOD],[BIRIM],[KOLI],[KDV],[KMP],[F ACIK],[ FIY],[ISK1],[ISK2],[ISK3],[ISK4],[ISK5],[ISK6],[ISK7],[ISK8],[ISK9],[ISK10],[NET+KDV],[VD],[STOK] ORDER BY MALZEME", conn);
                //else if (FiyatTipi == 19 && where == "hepsiburada")
                //    da = new SqlDataAdapter("SELECT REYON AS KategoriAdi,ITEMREF AS UrunID,dbo.IlkHarfBuyuk(dbo.UrunMalzemeKisaltmalar(MALZEME)) AS UrunAdi,'<![CDATA[' + CASE WHEN (SELECT ACIKLAMA FROM [Web-Malzeme-Aciklama] WHERE ITEMREF = KurumsalWebSAP.dbo.[SUL_Fiyatlar_19_00_Stok].ITEMREF) IS NULL THEN dbo.IlkHarfBuyuk(dbo.UrunMalzemeKisaltmalar(MALZEME)) WHEN (SELECT ACIKLAMA FROM [Web-Malzeme-Aciklama] WHERE ITEMREF = KurumsalWebSAP.dbo.[SUL_Fiyatlar_19_00_Stok].ITEMREF) = '' THEN dbo.IlkHarfBuyuk(dbo.UrunMalzemeKisaltmalar(MALZEME)) COLLATE DATABASE_DEFAULT ELSE (SELECT ACIKLAMA FROM [Web-Malzeme-Aciklama] WHERE ITEMREF = KurumsalWebSAP.dbo.[SUL_Fiyatlar_19_00_Stok].ITEMREF) END + ']]>' AS UrunAciklamasi,ISNULL((SELECT MARKA FROM [Web-Malzeme-Aciklama] INNER JOIN [Web-Malzeme-Marka] ON [Web-Malzeme-Aciklama].MARKAREF = [Web-Malzeme-Marka].REF WHERE ITEMREF = KurumsalWebSAP.dbo.[SUL_Fiyatlar_19_00_Stok].ITEMREF),'') AS Marka,KDV AS KDV,CONVERT(decimal(18,2),([NET+KDV] / ((100 + KDV) / 100))) AS OzelFiyat,CONVERT(decimal(18,2),([NET+KDV] / ((100 + KDV) / 100)) * 1.25) AS ListeFiyat,'TL' AS Kur,STOK AS StokAdedi,BARKOD AS Barcode,CONVERT(VARCHAR(MAX),[ITEMREF]) + '.jpg' AS ImageName1 FROM KurumsalWebSAP.dbo.[SUL_Fiyatlar_19_00_Stok] ORDER BY MALZEME", conn);
                //else if (FiyatTipi == 19 && where == "n11")
                //    da = new SqlDataAdapter("SELECT [SUL_Fiyatlar_19_00_Stok].ITEMREF AS Kod,dbo.IlkHarfBuyuk(dbo.UrunMalzemeKisaltmalar(MALZEME)) AS Baslik,MALZEME AS AltBaslik,CASE WHEN [Web-Malzeme-Aciklama].ACIKLAMA = '' THEN MALZEME ELSE [Web-Malzeme-Aciklama].ACIKLAMA COLLATE DATABASE_DEFAULT END AS Aciklama,(SELECT KATEGORI FROM [Web-Malzeme-ReyonKategori] WHERE REF = [Web-Malzeme-Aciklama].KATEGORIREF) AS KategoriAdi,CONVERT(decimal(18,2),[NET+KDV] * 1.20) AS Fiyat,KDV AS Kdv,(SELECT MARKA FROM [Web-Malzeme-Marka] WHERE REF = [Web-Malzeme-Aciklama].MARKAREF) AS Marka,STOK AS Stoklar,CONVERT(decimal(18,2),[NET+KDV]) AS IndirimliTutar,'https://www.sultanlar.com.tr/musteri/resim400-' + IsNull(CONVERT(VARCHAR(MAX),max(intResimID)),'0') + '.html' AS Resim FROM KurumsalWebSAP.dbo.[SUL_Fiyatlar_19_00_Stok] INNER JOIN [Web-Malzeme-Aciklama] ON KurumsalWebSAP.dbo.[SUL_Fiyatlar_19_00_Stok].ITEMREF = [Web-Malzeme-Aciklama].ITEMREF INNER JOIN tblINTERNET_UrunResim ON tblINTERNET_UrunResim.ITEMREF = [SUL_Fiyatlar_19_00_Stok].ITEMREF WHERE [ANA GRP] = 'AHT' OR [ANA GRP] = 'YEG' GROUP BY [SUL_Fiyatlar_19_00_Stok].ITEMREF,MALZEME,[Web-Malzeme-Aciklama].ACIKLAMA,[Web-Malzeme-Aciklama].KATEGORIREF,[Web-Malzeme-Aciklama].MARKAREF,STOK,[NET+KDV],KDV ORDER BY MALZEME", conn);
                //else if (FiyatTipi == 19 && where == "sanalpazar")
                //    da = new SqlDataAdapter("SELECT (SELECT KATEGORI FROM [Web-Malzeme-ReyonKategori] WHERE REF = [Web-Malzeme-Aciklama].KATEGORIREF) AS 'Category',[SUL_Fiyatlar_19_00_Stok].ITEMREF AS 'ID',(SELECT MARKA FROM [Web-Malzeme-Marka] WHERE REF = [Web-Malzeme-Aciklama].MARKAREF) AS 'Brand',dbo.IlkHarfBuyuk(dbo.UrunMalzemeKisaltmalar(MALZEME)) AS 'Name',[NET+KDV] AS 'Price',CASE WHEN [Web-Malzeme-Aciklama].ACIKLAMA = '' THEN MALZEME ELSE [Web-Malzeme-Aciklama].ACIKLAMA COLLATE DATABASE_DEFAULT END + '<br><br>(75TL üzeri kargo ücretsizdir.)' AS 'Description','http://www.sultanlar.com.tr/resim400j-' + IsNull(CONVERT(VARCHAR(MAX),max(intResimID)),'0') + '.jpg' AS 'Image',STOK AS 'Stock' FROM KurumsalWebSAP.dbo.[SUL_Fiyatlar_19_00_Stok] INNER JOIN [Web-Malzeme-Aciklama] ON KurumsalWebSAP.dbo.[SUL_Fiyatlar_19_00_Stok].ITEMREF = [Web-Malzeme-Aciklama].ITEMREF INNER JOIN tblINTERNET_UrunResim ON tblINTERNET_UrunResim.ITEMREF = [SUL_Fiyatlar_19_00_Stok].ITEMREF WHERE [ANA GRP] = 'AHT' OR [ANA GRP] = 'YEG' GROUP BY [SUL_Fiyatlar_19_00_Stok].ITEMREF,MALZEME,[Web-Malzeme-Aciklama].ACIKLAMA,[Web-Malzeme-Aciklama].KATEGORIREF,[Web-Malzeme-Aciklama].MARKAREF,STOK,[NET+KDV] ORDER BY MALZEME", conn);
                else if (FiyatTipi == 17)
                    da = new SqlDataAdapter("SELECT [ANA GRP],[ALT GRP],[GRUP],[REYON],KurumsalWebSAP.dbo.[SUL_Fiyatlar_17_00_Stok].[ITEMREF],[KOD],dbo.IlkHarfBuyuk(dbo.UrunMalzemeKisaltmalar(MALZEME)) AS MALZEME,[BARKOD],[BIRIM],[KOLI],[KDV],[KMP],[F ACIK],[ FIY],[ISK1],[ISK2],[ISK3],[ISK4],[ISK5],[ISK6],[ISK7],[ISK8],[ISK9],[ISK10],[NET+KDV],[VD],STOK,KG,DM3,'https://www.sultanlar.com.tr/musteri/resim-' + IsNull(CONVERT(VARCHAR(MAX),(SELECT TOP 1 intResimID FROM tblINTERNET_UrunResim WHERE ITEMREF = [SUL_Fiyatlar_17_00_Stok].ITEMREF ORDER BY intResimID DESC)),'0') + '.html' AS Resim FROM KurumsalWebSAP.dbo.[SUL_Fiyatlar_17_00_Stok] " + where + "ORDER BY MALZEME", conn);
                else if (FiyatTipi == 18)
                    da = new SqlDataAdapter("SELECT [ANA GRP],[ALT GRP],[GRUP],[REYON],KurumsalWebSAP.dbo.[SUL_Fiyatlar_18_00_Stok].[ITEMREF],[KOD],dbo.IlkHarfBuyuk(dbo.UrunMalzemeKisaltmalar(MALZEME)) AS MALZEME,[BARKOD],[BIRIM],[KOLI],[KDV],[KMP],[F ACIK],[ FIY],[ISK1],[ISK2],[ISK3],[ISK4],[ISK5],[ISK6],[ISK7],[ISK8],[ISK9],[ISK10],[NET+KDV],[VD],STOK,KG,DM3,'https://www.sultanlar.com.tr/musteri/resim-' + IsNull(CONVERT(VARCHAR(MAX),(SELECT TOP 1 intResimID FROM tblINTERNET_UrunResim WHERE ITEMREF = [SUL_Fiyatlar_18_00_Stok].ITEMREF ORDER BY intResimID DESC)),'0') + '.html' AS Resim FROM KurumsalWebSAP.dbo.[SUL_Fiyatlar_18_00_Stok] " + where + "ORDER BY MALZEME", conn);
                else if (FiyatTipi == 19)
                    da = new SqlDataAdapter("SELECT [ANA GRP],[ALT GRP],[GRUP],[REYON],KurumsalWebSAP.dbo.[SUL_Fiyatlar_07_00_Stok].[ITEMREF],[KOD],dbo.IlkHarfBuyuk(dbo.UrunMalzemeKisaltmalar(MALZEME)) AS MALZEME,[BARKOD],[BIRIM],[KOLI],[KDV],[KMP],[F ACIK],[ FIY] * 1.50 AS [ FIY],[ISK1],[ISK2],[ISK3],[ISK4],[ISK5],[ISK6],[ISK7],[ISK8],[ISK9],[ISK10],[NET+KDV] * 1.50 AS [NET+KDV],60 AS [VD],STOK,KG,DM3,'https://www.sultanlar.com.tr/musteri/resim-' + IsNull(CONVERT(VARCHAR(MAX),(SELECT TOP 1 intResimID FROM tblINTERNET_UrunResim WHERE ITEMREF = [SUL_Fiyatlar_07_00_Stok].ITEMREF ORDER BY intResimID DESC)),'0') + '.html' AS Resim FROM KurumsalWebSAP.dbo.[SUL_Fiyatlar_07_00_Stok] WHERE (SELECT count(REF) FROM [Web-Malzeme-Aciklama] WHERE ITEMREF = [SUL_Fiyatlar_07_00_Stok].ITEMREF AND [KATEGORIREF] != 0 AND [MARKAREF] != 0 AND [CINSIYETREF] != 0) > 0 ORDER BY MALZEME", conn);
                else if (FiyatTipi == 21)
                    da = new SqlDataAdapter("SELECT [GRUP],[REYON],KurumsalWebSAP.dbo.[SUL_Fiyatlar_21_00_Stok].[ITEMREF],[KOD],dbo.IlkHarfBuyuk(dbo.UrunMalzemeKisaltmalar(MALZEME)) AS MALZEME,[BARKOD],[BIRIM],[KOLI],[KDV],[ FIY] AS FIYAT,[ISK1],[ISK2],[ISK3],[ISK4],[ISK5],[ISK6],[ISK7],[ISK8],[ISK9],[ISK10],[NET+KDV] AS NETKDV,[VD],STOK,KG,DM3,'https://www.sultanlar.com.tr/musteri/resim-' + IsNull(CONVERT(VARCHAR(MAX),(SELECT TOP 1 intResimID FROM tblINTERNET_UrunResim WHERE ITEMREF = [SUL_Fiyatlar_21_00_Stok].ITEMREF ORDER BY intResimID DESC)),'0') + '.html' AS Resim FROM KurumsalWebSAP.dbo.[SUL_Fiyatlar_21_00_Stok] " + where + "ORDER BY MALZEME", conn);
                else if (FiyatTipi == 22)
                    da = new SqlDataAdapter("SELECT [GRUP],[KOD],dbo.IlkHarfBuyuk(dbo.UrunMalzemeKisaltmalar(MALZEME)) AS MALZEME,[BARKOD],[BIRIM] AS PAKET,[KOLI],[KDV],[ FIY] AS FIYAT,[ISK1],[ISK2],[ISK3],[ISK4],[ISK5],[ISK6],[ISK7],[ISK8],[ISK9],[ISK10],[NET+KDV] AS NETKDV,[VD],STOK,KG,DM3,'https://www.sultanlar.com.tr/musteri/resim-' + IsNull(CONVERT(VARCHAR(MAX),(SELECT TOP 1 intResimID FROM tblINTERNET_UrunResim WHERE ITEMREF = [SUL_Fiyatlar_22_00_Stok].ITEMREF ORDER BY intResimID DESC)),'0') + '.html' AS Resim FROM KurumsalWebSAP.dbo.[SUL_Fiyatlar_22_00_Stok] " + where + "ORDER BY MALZEME", conn);

                else if (FiyatTipi == 0) // 0
                    da = new SqlDataAdapter("SELECT [ANA GRP],[ALT GRP],[GRUP],[REYON],[ITEMREF],[KOD],[MALZEME],[BARKOD],[BIRIM],[KOLI],[KDV],[KMP],[F ACIK],[ FIY],[ISK1],[ISK2],[ISK3],[ISK4],[ISK5],[ISK6],[ISK7],[ISK8],[ISK9],[ISK10],[NET+KDV],[VD],STOK AS STOK FROM KurumsalWebSAP.dbo.[SUL_Fiyatlar_00_00_Stok] " + where + " ORDER BY MALZEME", conn);

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
        //
        //
        public static bool FiyatListesiVarMi(int FiyatTipi)
        {
            bool donendeger = false;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_INTERNET_FiyatListeleriDosyaVarMi", conn);
                cmd.Parameters.Add("@intFiyatTipi", SqlDbType.Int).Value = FiyatTipi;
                cmd.CommandType = CommandType.StoredProcedure;
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
    }
}

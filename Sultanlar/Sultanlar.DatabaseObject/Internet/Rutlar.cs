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
    public class Rutlar : ISultanlar, IDisposable
    {
        #region eski
        //
        //
        //
        // Alanlar:
        //
        private long _pkID;
        private int _SLSREF;
        private int _SMREF;
        private byte _tintRutTipiID;
        private DateTime _dtTarih;
        private string _strAciklama;
        private bool _blOnayli;
        //
        //
        //
        // Constracter lar:
        //
        private Rutlar(long pkID, int SLSREF, int SMREF, byte tintRutTipiID, DateTime dtTarih, string strAciklama, bool blOnayli)
        {
            this._pkID = pkID;
            this._SLSREF = SLSREF;
            this._SMREF = SMREF;
            this._tintRutTipiID = tintRutTipiID;
            this._dtTarih = dtTarih;
            this._strAciklama = strAciklama;
            this._blOnayli = blOnayli;
        }
        //
        //
        public Rutlar(int SLSREF, int SMREF, byte tintRutTipiID, DateTime dtTarih, string strAciklama, bool blOnayli)
        {
            this._SLSREF = SLSREF;
            this._SMREF = SMREF;
            this._tintRutTipiID = tintRutTipiID;
            this._dtTarih = dtTarih;
            this._strAciklama = strAciklama;
            this._blOnayli = blOnayli;
        }
        //
        //
        //
        // Özellikler:
        //
        public long pkID { get { return this._pkID; } }
        public int SLSREF { get { return this._SLSREF; } set { this._SLSREF = value; } }
        public int SMREF { get { return this._SMREF; } set { this._SMREF = value; } }
        public byte tintRutTipiID { get { return this._tintRutTipiID; } set { this._tintRutTipiID = value; } }
        public DateTime dtTarih { get { return this._dtTarih; } set { this._dtTarih = value; } }
        public string strAciklama { get { return this._strAciklama; } set { this._strAciklama = value; } }
        public bool blOnayli { get { return this._blOnayli; } set { this._blOnayli = value; } }
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
            return this._dtTarih.ToString();
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
                SqlCommand cmd = new SqlCommand("sp_INTERNET_RutEkle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@SLSREF", SqlDbType.Int).Value = this._SLSREF;
                cmd.Parameters.Add("@SMREF", SqlDbType.Int).Value = this._SMREF;
                cmd.Parameters.Add("@tintRutTipiID", SqlDbType.TinyInt).Value = this._tintRutTipiID;
                cmd.Parameters.Add("@dtTarih", SqlDbType.SmallDateTime).Value = this._dtTarih;
                cmd.Parameters.Add("@strAciklama", SqlDbType.NVarChar).Value = this._strAciklama;
                cmd.Parameters.Add("@blOnayli", SqlDbType.Bit).Value = this._blOnayli;
                cmd.Parameters.Add("@pkID", SqlDbType.BigInt).Direction = ParameterDirection.Output;
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    this._pkID = Convert.ToInt32(cmd.Parameters["@pkID"].Value);
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
                SqlCommand cmd = new SqlCommand("sp_INTERNET_RutGuncelle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkID", SqlDbType.BigInt).Value = this._pkID;
                cmd.Parameters.Add("@SLSREF", SqlDbType.Int).Value = this._SLSREF;
                cmd.Parameters.Add("@SMREF", SqlDbType.Int).Value = this._SMREF;
                cmd.Parameters.Add("@tintRutTipiID", SqlDbType.TinyInt).Value = this._tintRutTipiID;
                cmd.Parameters.Add("@dtTarih", SqlDbType.SmallDateTime).Value = this._dtTarih;
                cmd.Parameters.Add("@strAciklama", SqlDbType.NVarChar).Value = this._strAciklama;
                cmd.Parameters.Add("@blOnayli", SqlDbType.Bit).Value = this._blOnayli;
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
                SqlCommand cmd = new SqlCommand("sp_INTERNET_RutSil", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkID", SqlDbType.BigInt).Value = this._pkID;
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

                SqlCommand cmd = new SqlCommand("sp_INTERNET_RutlarGetir", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        List.Add(new Rutlar(Convert.ToInt64(dr[0]), Convert.ToInt32(dr[1]), Convert.ToInt32(dr[2]),
                            Convert.ToByte(dr[3]), Convert.ToDateTime(dr[4]),
                            dr[5].ToString(), Convert.ToBoolean(dr[6].ToString())));
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
        public static void GetObjects(ListItemCollection lic, int SLSREF)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                lic.Clear();

                SqlCommand cmd = new SqlCommand("sp_INTERNET_RutlarGetirBySLSREF", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@SLSREF", SqlDbType.Int).Value = SLSREF;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                        lic.Add(new ListItem(dr[4].ToString(), dr[0].ToString()));
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
        public static void GetObjects(DataTable dt, int SLSREF)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_INTERNET_RutlarGetirBySLSREF", conn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@SLSREF", SqlDbType.Int).Value = SLSREF;
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
        //
        // Logodan alınan:
        //
        public static void GetObjects(DataTable dt)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT DISTINCT [Web-Rutlar].[MTIP],[Web-Rutlar].[SLSREF],min([Web-Rutlar].[ZIYGUN]) AS ZIY,[Web-Rutlar].[SMREF],[Web-Rutlar].[BARKOD],[KurumsalWebSAP].dbo.[Web-Musteri].[SUBE] FROM [Web-Rutlar] INNER JOIN [KurumsalWebSAP].dbo.[Web-Musteri] ON [Web-Rutlar].[SMREF] = [KurumsalWebSAP].dbo.[Web-Musteri].[SMREF] WHERE [KurumsalWebSAP].dbo.[Web-Musteri].[SMREF] != [KurumsalWebSAP].dbo.[Web-Musteri].[GMREF] AND [Web-Rutlar].[ZIYGUN] >= getdate() GROUP BY [Web-Rutlar].[MTIP],[Web-Rutlar].[SLSREF],[Web-Rutlar].[BARKOD],[Web-Rutlar].[SMREF],[KurumsalWebSAP].dbo.[Web-Musteri].[SUBE] ORDER BY [KurumsalWebSAP].dbo.[Web-Musteri].[SUBE]", conn);
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
        /// Bugünkü rutlar
        /// </summary>
        public static void GetObjectsBySLSREF(DataTable dt, int SLSREF)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT DISTINCT [Web-Rutlar].[MTIP],[Web-Rutlar].[SLSREF],[Web-Rutlar].[ZIYGUN],[Web-Rutlar].[SMREF],[Web-Rutlar].[BARKOD],[KurumsalWebSAP].dbo.[Web-Musteri].[SUB KOD],[KurumsalWebSAP].dbo.[Web-Musteri].[SUBE] FROM [Web-Rutlar] INNER JOIN [KurumsalWebSAP].dbo.[Web-Musteri] ON [Web-Rutlar].[SMREF] = [KurumsalWebSAP].dbo.[Web-Musteri].[SMREF] WHERE [KurumsalWebSAP].dbo.[Web-Musteri].[SMREF] != [KurumsalWebSAP].dbo.[Web-Musteri].[GMREF] AND DATEADD(dd, 0, DATEDIFF(dd, 0, [Web-Rutlar].[ZIYGUN])) = DATEADD(dd, 0, DATEDIFF(dd, 0, GETDATE())) AND [Web-Rutlar].[SLSREF] = @SLSREF ORDER BY [Web-Rutlar].[ZIYGUN],[KurumsalWebSAP].dbo.[Web-Musteri].[SUBE]", conn);
                da.SelectCommand.Parameters.Add("@SLSREF", SqlDbType.Int).Value = SLSREF;
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

            dt.Columns.Add("BugunMu", typeof(bool));
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (Convert.ToDateTime(dt.Rows[i]["ZIYGUN"]).ToShortDateString() == DateTime.Now.ToShortDateString())
                    dt.Rows[i]["BugunMu"] = true;
                else
                    dt.Rows[i]["BugunMu"] = false;
            }
        }
        /// <summary>
        /// Tarih aralığındaki rutlar
        /// </summary>
        public static void GetObjectsBySLSREF(DataTable dt, int SLSREF, DateTime Baslangic, DateTime Bitis, bool bayi)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT DISTINCT [Web-Rutlar].[MTIP],[Web-Rutlar].[SLSREF],[Web-Rutlar].[ZIYGUN],[Web-Rutlar].[SMREF],[Web-Rutlar].[BARKOD],ISNULL(CASE WHEN [Web-Musteri].[SUB KOD] = '' THEN [Web-Musteri].[MUS KOD] ELSE [Web-Musteri].[SUB KOD] END,'') AS [SUB KOD],CASE WHEN [Web-Musteri].[SUBE] = '' THEN [Web-Musteri].[MUSTERI] ELSE [Web-Musteri].[SUBE] END AS [SUBE],(SELECT count(pkID) FROM KurumsalWebSAP.dbo.tblINTERNET_SatisTemsilcisiZiyaretler WHERE intSLSREF = [Web-Rutlar].[SLSREF] AND intSMREF = [Web-Rutlar].[SMREF] AND DATEADD(dd, 0, DATEDIFF(dd, 0, dtZIYGUN)) = DATEADD(dd, 0, DATEDIFF(dd, 0, [Web-Rutlar].[ZIYGUN]))) AS YAPILDI FROM [Web-Rutlar] INNER JOIN [Web-Musteri-1] AS [Web-Musteri] ON [Web-Rutlar].[SMREF] = [Web-Musteri].[SMREF] AND [Web-Rutlar].MTIP = [Web-Musteri].TIP WHERE DATEADD(dd, 0, DATEDIFF(dd, 0, [Web-Rutlar].[ZIYGUN])) >= DATEADD(dd, 0, DATEDIFF(dd, 0, @Baslangic)) AND DATEADD(dd, 0, DATEDIFF(dd, 0, [Web-Rutlar].[ZIYGUN])) <= DATEADD(dd, 0, DATEDIFF(dd, 0, @Bitis)) AND [Web-Rutlar].[SLSREF] = @SLSREF ORDER BY [Web-Rutlar].[ZIYGUN],[SUBE]", conn);
                //if (bayi)
                //    da = new SqlDataAdapter("SELECT DISTINCT [Web-Rutlar].[MTIP],[Web-Rutlar].[SLSREF],[Web-Rutlar].[ZIYGUN],[Web-Rutlar].[SMREF],[Web-Rutlar].[BARKOD],ISNULL(CASE WHEN [Web-Musteri-TP].[SUB KOD] = '' THEN [Web-Musteri-TP].[MUS KOD] ELSE [Web-Musteri-TP].[SUB KOD] END,'') AS [SUB KOD],CASE WHEN [Web-Musteri-TP].[SUBE] = '' THEN [Web-Musteri-TP].[MUSTERI] ELSE [Web-Musteri-TP].[SUBE] END AS [SUBE],(SELECT count(pkID) FROM KurumsalWebSAP.dbo.tblINTERNET_SatisTemsilcisiZiyaretler WHERE intSLSREF = [Web-Rutlar].[SLSREF] AND intSMREF = [Web-Rutlar].[SMREF] AND DATEADD(dd, 0, DATEDIFF(dd, 0, dtZIYGUN)) = DATEADD(dd, 0, DATEDIFF(dd, 0, [Web-Rutlar].[ZIYGUN]))) AS YAPILDI FROM [Web-Rutlar] INNER JOIN [Web-Musteri-TP] ON [Web-Rutlar].[SMREF] = [Web-Musteri-TP].[SMREF] WHERE DATEADD(dd, 0, DATEDIFF(dd, 0, [Web-Rutlar].[ZIYGUN])) >= DATEADD(dd, 0, DATEDIFF(dd, 0, @Baslangic)) AND DATEADD(dd, 0, DATEDIFF(dd, 0, [Web-Rutlar].[ZIYGUN])) <= DATEADD(dd, 0, DATEDIFF(dd, 0, @Bitis)) AND [Web-Rutlar].[SLSREF] = @SLSREF ORDER BY [Web-Rutlar].[ZIYGUN],[SUBE]", conn);
                da.SelectCommand.Parameters.Add("@SLSREF", SqlDbType.Int).Value = SLSREF;
                da.SelectCommand.Parameters.Add("@Baslangic", SqlDbType.DateTime).Value = Baslangic;
                da.SelectCommand.Parameters.Add("@Bitis", SqlDbType.DateTime).Value = Bitis;
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

            dt.Columns.Add("BugunMu", typeof(bool));
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (Convert.ToDateTime(dt.Rows[i]["ZIYGUN"]).ToShortDateString() == DateTime.Now.ToShortDateString())
                    dt.Rows[i]["BugunMu"] = true;
                else
                    dt.Rows[i]["BugunMu"] = false;
            }
        }
        /// <summary>
        /// SMREF den BARKOD u almak
        /// </summary>
        public static string GetBARKODBySMREF(int MTIP, int SLSREF, int SMREF)
        {
            string donendeger = string.Empty;

            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3))
            {
                SqlCommand cmd = new SqlCommand("SELECT [BARKOD] FROM [Web-Rutlar] WHERE MTIP = @MTIP AND SLSREF = @SLSREF AND SMREF = @SMREF", conn);
                cmd.Parameters.Add("@MTIP", SqlDbType.Int).Value = MTIP;
                cmd.Parameters.Add("@SLSREF", SqlDbType.Int).Value = SLSREF;
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
        //
        //
        public static void GetObjectsBySMREF(DataTable dt, int SMREF)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT DISTINCT [Web-Rutlar].[MTIP],[Web-Rutlar].[SLSREF],min([Web-Rutlar].[ZIYGUN]) AS ZIY,[Web-Rutlar].[SMREF],[Web-Rutlar].[BARKOD],[KurumsalWebSAP].dbo.[Web-Musteri].[SUBE] FROM [Web-Rutlar] INNER JOIN [KurumsalWebSAP].dbo.[Web-Musteri] ON [Web-Rutlar].[SMREF] = [KurumsalWebSAP].dbo.[Web-Musteri].[SMREF] WHERE [KurumsalWebSAP].dbo.[Web-Musteri].[SMREF] != [KurumsalWebSAP].dbo.[Web-Musteri].[GMREF] AND [Web-Rutlar].[ZIYGUN] >= getdate() AND [Web-Rutlar].[SMREF] = @SMREF GROUP BY [Web-Rutlar].[MTIP],[Web-Rutlar].[SLSREF],[Web-Rutlar].[BARKOD],[Web-Rutlar].[SMREF],[KurumsalWebSAP].dbo.[Web-Musteri].[SUBE] ORDER BY [KurumsalWebSAP].dbo.[Web-Musteri].[SUBE]", conn);
                da.SelectCommand.Parameters.Add("@SMREF", SqlDbType.Int).Value = SMREF;
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
        public static void GetObjectsByBARKOD(DataTable dt, string BARKOD)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT DISTINCT [Web-Rutlar].[MTIP],[Web-Rutlar].[SLSREF],min([Web-Rutlar].[ZIYGUN]) AS ZIY,[Web-Rutlar].[SMREF],[Web-Rutlar].[BARKOD],[KurumsalWebSAP].dbo.[Web-Musteri].[SUBE] FROM [Web-Rutlar] INNER JOIN [KurumsalWebSAP].dbo.[Web-Musteri] ON [Web-Rutlar].[SMREF] = [KurumsalWebSAP].dbo.[Web-Musteri].[SMREF] WHERE [KurumsalWebSAP].dbo.[Web-Musteri].[SMREF] != [KurumsalWebSAP].dbo.[Web-Musteri].[GMREF] AND [Web-Rutlar].[ZIYGUN] >= getdate() AND [Web-Rutlar].[BARKOD] = @BARKOD GROUP BY [Web-Rutlar].[MTIP],[Web-Rutlar].[SLSREF],[Web-Rutlar].[BARKOD],[Web-Rutlar].[SMREF],[KurumsalWebSAP].dbo.[Web-Musteri].[SUBE] ORDER BY [KurumsalWebSAP].dbo.[Web-Musteri].[SUBE]", conn);
                da.SelectCommand.Parameters.Add("@BARKOD", SqlDbType.NVarChar, 20).Value = BARKOD;
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



        public static void GetRutlar(DataTable dt, string Tip, int Kacinci)
        {
            string tip4inner = Tip == "4" ? "" : "LEFT OUTER JOIN SAP_FAT_Web_3_3 ON Web_Rut_01_S_M.GMREF = SAP_FAT_Web_3_3.GMREF AND Web_Rut_01_S_M.SMREF = dbo.SAP_FAT_Web_3_3.SMREF ";
            string tip4net = Tip == "4" ? "NULL AS NETT_2015,NULL AS KOLIT_2015,NULL AS NETT_2016,NULL AS KOLIT_2016,NULL AS NETT_2017,NULL AS KOLIT_2017," : "NETT_2015,KOLIT_2015,NETT_2016,KOLIT_2016,NETT_2017,KOLIT_2017,";

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT [Web_Rut_01_S_M].*,CONVERT(bit, CASE WHEN (SELECT TOP 1 [ID" + Kacinci.ToString() + "] FROM [WEB_RUT_3_GIRIS] WHERE SLSREF = [Web_Rut_01_S_M].intSLSREF AND GMREF = [Web_Rut_01_S_M].GMREF AND SMREF = [Web_Rut_01_S_M].SMREF) IS NULL OR (SELECT TOP 1 [ID" + Kacinci.ToString() + "] FROM [WEB_RUT_3_GIRIS] WHERE SLSREF = [Web_Rut_01_S_M].intSLSREF AND GMREF = [Web_Rut_01_S_M].GMREF AND SMREF = [Web_Rut_01_S_M].SMREF) = '' THEN 0 ELSE 1 END) AS RUT_VAR,(SELECT TOP 1 [RUT_" + Kacinci.ToString() + "] FROM [WEB_RUT_3_GIRIS] WHERE SLSREF = [Web_Rut_01_S_M].intSLSREF AND GMREF = [Web_Rut_01_S_M].GMREF AND SMREF = [Web_Rut_01_S_M].SMREF) AS RUT_DONGU,(SELECT TOP 1 [GUN_" + Kacinci.ToString() + "] FROM [WEB_RUT_3_GIRIS] WHERE SLSREF = [Web_Rut_01_S_M].intSLSREF AND GMREF = [Web_Rut_01_S_M].GMREF AND SMREF = [Web_Rut_01_S_M].SMREF) AS RUT_GUN," + tip4net + "[SAT KOD] AS PER_KOD,(SELECT [SAT TEM] FROM [Web-SatisTemsilcileri] WHERE SLSMANREF = MUS.[SAT KOD]) AS PER_TEM FROM [Web_Rut_0" + Tip + "_S_M] AS [Web_Rut_01_S_M] " + tip4inner + "INNER JOIN (SELECT DISTINCT [SAT KOD],GMREF FROM [Web-Musteri] WHERE GMREF = SMREF) AS MUS ON MUS.GMREF = [Web_Rut_01_S_M].GMREF", conn);
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
        public static void GetRut5(DataTable dt)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT [TABLO],[PER_KOD],[PER_TEM],[SAT_KOD],[SAT_TEM],[RVY],[A_P],[MUS_KOD],[MUSTERI],[SUB_KOD],[SUBE],[PRYD_KOD],[01],[02],[03],[04],[05],[06],[07],[08],[09],[10],[11],[12],[13],[14],[15],[16],[17],[18],[19],[20],[21],[22],[23],[24],[25],[26],[27],[28],[NETT_2015],[KOLIT_2015],[NETT_2016],[KOLIT_2016],[NETT_2017],[KOLIT_2017] FROM [Web_Rut_5_Rapor]", conn);
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
        public static void GetRut9(DataTable dt)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM [Web_Rut_9_Ziyaretler]", conn);
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
        public static void GetGirisler(DataTable dt)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM [WEB_RUT_3_GIRIS]", conn);
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
        public static void GetPeriyodlar(DataTable dt)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT [RUT_PRYD_KOD],[RUT_PRYD_ACIK] FROM [WEB_RUT_2_TANIM]", conn);
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
        public static void GetPeriyodlar(ListItemCollection lic, bool web)
        {
            lic.Clear();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT [RUT_PRYD_KOD],[RUT_PRYD_ACIK] FROM [WEB_RUT_2_TANIM] WHERE [RUT_PRYD_KOD] != ''", conn);
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                        lic.Add(new ListItem(dr[1].ToString(), dr[0].ToString()));
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
        public static void GetGunler(DataTable dt)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT [GUN_ID],[GUNLER] FROM [WEB_RUT_2_TANIM]", conn);
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
        public static void GetGunler(ListItemCollection lic, bool web)
        {
            lic.Clear();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT [GUN_ID],[GUNLER] FROM [WEB_RUT_2_TANIM] WHERE GUN_ID != '' AND GUN_ID != '7'", conn);
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                        lic.Add(new ListItem(dr[1].ToString(), dr[0].ToString()));
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
        public static bool RutVarMi(int SLSREF, int GMREF, int SMREF, int Kacinci)
        {
            bool donendeger = false;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT count([ID" + Kacinci.ToString() + "]) FROM [WEB_RUT_3_GIRIS] WHERE SLSREF = @SLSREF AND GMREF = @GMREF AND SMREF = @SMREF AND [BAS_TAR_" + Kacinci.ToString() + "] != [BIT_TAR_" + Kacinci.ToString() + "]", conn);
                cmd.Parameters.Add("@SLSREF", SqlDbType.Int).Value = SLSREF;
                cmd.Parameters.Add("@GMREF", SqlDbType.Int).Value = GMREF;
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
        //
        //
        public static void GetRutDetay(DataTable dt, int SLSREF, int GMREF, int SMREF, int Kacinci)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT [ID" + Kacinci.ToString() + "],[RUT_" + Kacinci.ToString() + "],[GUN_" + Kacinci.ToString() + "],[BAS_TAR_" + Kacinci.ToString() + "],[BIT_TAR_" + Kacinci.ToString() + "] FROM [WEB_RUT_3_GIRIS] WHERE SLSREF = @SLSREF AND GMREF = @GMREF AND SMREF = @SMREF", conn);
                da.SelectCommand.Parameters.Add("@SLSREF", SqlDbType.Int).Value = SLSREF;
                da.SelectCommand.Parameters.Add("@GMREF", SqlDbType.Int).Value = GMREF;
                da.SelectCommand.Parameters.Add("@SMREF", SqlDbType.Int).Value = SMREF;
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
        public static void Insert(int MTIP, int SLSREF, int GMREF, int SMREF, int Kacinci, string Rut, string Gun, DateTime Baslangic, DateTime Bitis, string IslemYapan, DateTime IslemTarih)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                SqlCommand cmd2 = new SqlCommand("", conn);
                cmd2.Parameters.Add("@MTIP", SqlDbType.Int).Value = MTIP;
                cmd2.Parameters.Add("@SLSREF", SqlDbType.Int).Value = SLSREF;
                cmd2.Parameters.Add("@GMREF", SqlDbType.Int).Value = GMREF;
                cmd2.Parameters.Add("@SMREF", SqlDbType.Int).Value = SMREF;

                cmd2.CommandText = "SELECT count(*) FROM [WEB_RUT_3_GIRIS] WHERE MTIP = @MTIP AND SLSREF = @SLSREF AND GMREF = @GMREF AND SMREF = @SMREF";
                conn.Open();
                bool varmi = Convert.ToBoolean(cmd2.ExecuteScalar());
                conn.Close();

                if (Kacinci == 1)
                {
                    if (varmi)
                        cmd = new SqlCommand("UPDATE [WEB_RUT_3_GIRIS] SET [ID1] = @ID1,[RUT_1] = @RUT_1,[GUN_1] = @GUN_1,[BAS_TAR_1] = @BAS_TAR_1,[BIT_TAR_1] = @BIT_TAR_1,[ISLEM_YAPAN] = @ISLEM_YAPAN,[ISLEM_TARIH] = @ISLEM_TARIH WHERE [MTIP] = @MTIP AND SLSREF = @SLSREF AND GMREF = @GMREF AND SMREF = @SMREF", conn);
                    else
                        cmd = new SqlCommand("INSERT INTO [WEB_RUT_3_GIRIS] ([MTIP],[ID1],[SLSREF],[GMREF],[SMREF],[RUT_1],[GUN_1],[BAS_TAR_1],[BIT_TAR_1],[ISLEM_YAPAN],[ISLEM_TARIH]) VALUES (@MTIP,@ID1,@SLSREF,@GMREF,@SMREF,@RUT_1,@GUN_1,@BAS_TAR_1,@BIT_TAR_1,@ISLEM_YAPAN,@ISLEM_TARIH)", conn);
                    cmd.Parameters.Add("@ID1", SqlDbType.NVarChar, 50).Value = SLSREF.ToString() + GMREF.ToString() + SMREF.ToString() + "." + Rut + "." + Gun;
                    cmd.Parameters.Add("@RUT_1", SqlDbType.NVarChar, 10).Value = Rut;
                    cmd.Parameters.Add("@GUN_1", SqlDbType.NVarChar, 50).Value = Gun;
                    cmd.Parameters.Add("@BAS_TAR_1", SqlDbType.DateTime).Value = Baslangic;
                    cmd.Parameters.Add("@BIT_TAR_1", SqlDbType.DateTime).Value = Bitis;
                }
                else if (Kacinci == 2)
                {
                    if (varmi)
                        cmd = new SqlCommand("UPDATE [WEB_RUT_3_GIRIS] SET [ID2] = @ID2,[RUT_2] = @RUT_2,[GUN_2] = @GUN_2,[BAS_TAR_2] = @BAS_TAR_2,[BIT_TAR_2] = @BIT_TAR_2,[ISLEM_YAPAN] = @ISLEM_YAPAN,[ISLEM_TARIH] = @ISLEM_TARIH WHERE [MTIP] = @MTIP AND SLSREF = @SLSREF AND GMREF = @GMREF AND SMREF = @SMREF", conn);
                    else
                        cmd = new SqlCommand("INSERT INTO [WEB_RUT_3_GIRIS] ([MTIP],[ID2],[SLSREF],[GMREF],[SMREF],[RUT_2],[GUN_2],[BAS_TAR_2],[BIT_TAR_2],[ISLEM_YAPAN],[ISLEM_TARIH]) VALUES (@MTIP,@ID2,@SLSREF,@GMREF,@SMREF,@RUT_2,@GUN_2,@BAS_TAR_2,@BIT_TAR_2,@ISLEM_YAPAN,@ISLEM_TARIH)", conn);
                    cmd.Parameters.Add("@ID2", SqlDbType.NVarChar, 50).Value = SLSREF.ToString() + GMREF.ToString() + SMREF.ToString() + "." + Rut + "." + Gun;
                    cmd.Parameters.Add("@RUT_2", SqlDbType.NVarChar, 10).Value = Rut;
                    cmd.Parameters.Add("@GUN_2", SqlDbType.NVarChar, 50).Value = Gun;
                    cmd.Parameters.Add("@BAS_TAR_2", SqlDbType.DateTime).Value = Baslangic;
                    cmd.Parameters.Add("@BIT_TAR_2", SqlDbType.DateTime).Value = Bitis;
                }
                else if (Kacinci == 3)
                {
                    if (varmi)
                        cmd = new SqlCommand("UPDATE [WEB_RUT_3_GIRIS] SET [ID3] = @ID3,[RUT_3] = @RUT_3,[GUN_3] = @GUN_3,[BAS_TAR_3] = @BAS_TAR_3,[BIT_TAR_3] = @BIT_TAR_3,[ISLEM_YAPAN] = @ISLEM_YAPAN,[ISLEM_TARIH] = @ISLEM_TARIH WHERE [MTIP] = @MTIP AND SLSREF = @SLSREF AND GMREF = @GMREF AND SMREF = @SMREF", conn);
                    else
                        cmd = new SqlCommand("INSERT INTO [WEB_RUT_3_GIRIS] ([MTIP],[ID3],[SLSREF],[GMREF],[SMREF],[RUT_3],[GUN_3],[BAS_TAR_3],[BIT_TAR_3],[ISLEM_YAPAN],[ISLEM_TARIH]) VALUES (@MTIP,@ID3,@SLSREF,@GMREF,@SMREF,@RUT_3,@GUN_3,@BAS_TAR_3,@BIT_TAR_3,@ISLEM_YAPAN,@ISLEM_TARIH)", conn);
                    cmd.Parameters.Add("@ID3", SqlDbType.NVarChar, 50).Value = SLSREF.ToString() + GMREF.ToString() + SMREF.ToString() + "." + Rut + "." + Gun;
                    cmd.Parameters.Add("@RUT_3", SqlDbType.NVarChar, 10).Value = Rut;
                    cmd.Parameters.Add("@GUN_3", SqlDbType.NVarChar, 50).Value = Gun;
                    cmd.Parameters.Add("@BAS_TAR_3", SqlDbType.DateTime).Value = Baslangic;
                    cmd.Parameters.Add("@BIT_TAR_3", SqlDbType.DateTime).Value = Bitis;
                }
                else if (Kacinci == 4)
                {
                    if (varmi)
                        cmd = new SqlCommand("UPDATE [WEB_RUT_3_GIRIS] SET [ID4] = @ID4,[RUT_4] = @RUT_4,[GUN_4] = @GUN_4,[BAS_TAR_4] = @BAS_TAR_4,[BIT_TAR_4] = @BIT_TAR_4,[ISLEM_YAPAN] = @ISLEM_YAPAN,[ISLEM_TARIH] = @ISLEM_TARIH WHERE [MTIP] = @MTIP AND SLSREF = @SLSREF AND GMREF = @GMREF AND SMREF = @SMREF", conn);
                    else
                        cmd = new SqlCommand("INSERT INTO [WEB_RUT_3_GIRIS] ([MTIP],[ID4],[SLSREF],[GMREF],[SMREF],[RUT_4],[GUN_4],[BAS_TAR_4],[BIT_TAR_4],[ISLEM_YAPAN],[ISLEM_TARIH]) VALUES (@MTIP,@ID4,@SLSREF,@GMREF,@SMREF,@RUT_4,@GUN_4,@BAS_TAR_4,@BIT_TAR_4,@ISLEM_YAPAN,@ISLEM_TARIH)", conn);
                    cmd.Parameters.Add("@ID4", SqlDbType.NVarChar, 50).Value = SLSREF.ToString() + GMREF.ToString() + SMREF.ToString() + "." + Rut + "." + Gun;
                    cmd.Parameters.Add("@RUT_4", SqlDbType.NVarChar, 10).Value = Rut;
                    cmd.Parameters.Add("@GUN_4", SqlDbType.NVarChar, 50).Value = Gun;
                    cmd.Parameters.Add("@BAS_TAR_4", SqlDbType.DateTime).Value = Baslangic;
                    cmd.Parameters.Add("@BIT_TAR_4", SqlDbType.DateTime).Value = Bitis;
                }
                else if (Kacinci == 5)
                {
                    if (varmi)
                        cmd = new SqlCommand("UPDATE [WEB_RUT_3_GIRIS] SET [ID5] = @ID5,[RUT_5] = @RUT_5,[GUN_5] = @GUN_5,[BAS_TAR_5] = @BAS_TAR_5,[BIT_TAR_5] = @BIT_TAR_5,[ISLEM_YAPAN] = @ISLEM_YAPAN,[ISLEM_TARIH] = @ISLEM_TARIH WHERE [MTIP] = @MTIP AND SLSREF = @SLSREF AND GMREF = @GMREF AND SMREF = @SMREF", conn);
                    else
                        cmd = new SqlCommand("INSERT INTO [WEB_RUT_3_GIRIS] ([MTIP],[ID5],[SLSREF],[GMREF],[SMREF],[RUT_5],[GUN_5],[BAS_TAR_5],[BIT_TAR_5],[ISLEM_YAPAN],[ISLEM_TARIH]) VALUES (@MTIP,@ID5,@SLSREF,@GMREF,@SMREF,@RUT_5,@GUN_5,@BAS_TAR_5,@BIT_TAR_5,@ISLEM_YAPAN,@ISLEM_TARIH)", conn);
                    cmd.Parameters.Add("@ID5", SqlDbType.NVarChar, 50).Value = SLSREF.ToString() + GMREF.ToString() + SMREF.ToString() + "." + Rut + "." + Gun;
                    cmd.Parameters.Add("@RUT_5", SqlDbType.NVarChar, 10).Value = Rut;
                    cmd.Parameters.Add("@GUN_5", SqlDbType.NVarChar, 50).Value = Gun;
                    cmd.Parameters.Add("@BAS_TAR_5", SqlDbType.DateTime).Value = Baslangic;
                    cmd.Parameters.Add("@BIT_TAR_5", SqlDbType.DateTime).Value = Bitis;
                }
                else if (Kacinci == 6)
                {
                    if (varmi)
                        cmd = new SqlCommand("UPDATE [WEB_RUT_3_GIRIS] SET [ID6] = @ID6,[RUT_6] = @RUT_6,[GUN_6] = @GUN_6,[BAS_TAR_6] = @BAS_TAR_6,[BIT_TAR_6] = @BIT_TAR_6,[ISLEM_YAPAN] = @ISLEM_YAPAN,[ISLEM_TARIH] = @ISLEM_TARIH WHERE [MTIP] = @MTIP AND SLSREF = @SLSREF AND GMREF = @GMREF AND SMREF = @SMREF", conn);
                    else
                        cmd = new SqlCommand("INSERT INTO [WEB_RUT_3_GIRIS] ([MTIP],[ID6],[SLSREF],[GMREF],[SMREF],[RUT_6],[GUN_6],[BAS_TAR_6],[BIT_TAR_6],[ISLEM_YAPAN],[ISLEM_TARIH]) VALUES (@MTIP,@ID6,@SLSREF,@GMREF,@SMREF,@RUT_6,@GUN_6,@BAS_TAR_6,@BIT_TAR_6,@ISLEM_YAPAN,@ISLEM_TARIH)", conn);
                    cmd.Parameters.Add("@ID6", SqlDbType.NVarChar, 50).Value = SLSREF.ToString() + GMREF.ToString() + SMREF.ToString() + "." + Rut + "." + Gun;
                    cmd.Parameters.Add("@RUT_6", SqlDbType.NVarChar, 10).Value = Rut;
                    cmd.Parameters.Add("@GUN_6", SqlDbType.NVarChar, 50).Value = Gun;
                    cmd.Parameters.Add("@BAS_TAR_6", SqlDbType.DateTime).Value = Baslangic;
                    cmd.Parameters.Add("@BIT_TAR_6", SqlDbType.DateTime).Value = Bitis;
                }

                cmd.Parameters.Add("@MTIP", SqlDbType.Int).Value = MTIP;
                cmd.Parameters.Add("@SLSREF", SqlDbType.Int).Value = SLSREF;
                cmd.Parameters.Add("@GMREF", SqlDbType.Int).Value = GMREF;
                cmd.Parameters.Add("@SMREF", SqlDbType.Int).Value = SMREF;
                cmd.Parameters.Add("@ISLEM_YAPAN", SqlDbType.NVarChar, 50).Value = IslemYapan;
                cmd.Parameters.Add("@ISLEM_TARIH", SqlDbType.DateTime).Value = IslemTarih;

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
        public static string GetBugunKonumluRutlar(DataTable dt, int SLSREF)
        {
            string donendeger = string.Empty;

            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT DISTINCT (SELECT DISTINCT SUBE FROM [Web-Musteri-1] WHERE SMREF = [WEB_RUT_4_LISTE].SMREF AND TIP = [WEB_RUT_4_LISTE].MTIP) AS [Şube],[KONUM] AS [Konum] FROM [WEB_RUT_4_LISTE] INNER JOIN [Web-Musteri-Acik] ON [WEB_RUT_4_LISTE].SMREF = [Web-Musteri-Acik].SMREF AND [Web-Musteri-Acik].TIP = [WEB_RUT_4_LISTE].MTIP WHERE SLSREF = @SLSREF AND CONVERT(VARCHAR(10),[WEB_RUT_4_LISTE].[TARIH],111) = CONVERT(VARCHAR(10),GETDATE(),111)", conn);
                da.SelectCommand.Parameters.Add("@SLSREF", SqlDbType.Int).Value = SLSREF;
                try
                {
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

            return donendeger;
        }
        /// <summary>
        /// 
        /// </summary>
        public static string GetTarihRutlar(DataTable dt, int SLSREF, DateTime Tarih)
        {
            string donendeger = string.Empty;

            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT DISTINCT (SELECT DISTINCT SUBE FROM [Web-Musteri-1] WHERE SMREF = [WEB_RUT_4_LISTE].SMREF AND TIP = [WEB_RUT_4_LISTE].MTIP) AS [Şube],[KONUM] AS [Konum] FROM [WEB_RUT_4_LISTE] INNER JOIN [Web-Musteri-Acik] ON [WEB_RUT_4_LISTE].SMREF = [Web-Musteri-Acik].SMREF AND [Web-Musteri-Acik].TIP = [WEB_RUT_4_LISTE].MTIP WHERE SLSREF = @SLSREF AND CONVERT(VARCHAR(10),[WEB_RUT_4_LISTE].[TARIH],111) = CONVERT(VARCHAR(10),@TARIH,111)", conn);
                da.SelectCommand.Parameters.Add("@SLSREF", SqlDbType.Int).Value = SLSREF;
                da.SelectCommand.Parameters.Add("@TARIH", SqlDbType.DateTime).Value = Tarih;
                try
                {
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

            return donendeger;
        }
        /// <summary>
        /// 
        /// </summary>
        public static string GetKonum(int SMREF, int TIP)
        {
            string donendeger = string.Empty;

            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3))
            {
                SqlCommand cmd = new SqlCommand("SELECT [KONUM] FROM [Web-Musteri-Acik] WHERE SMREF = @SMREF AND TIP = @TIP", conn);
                cmd.Parameters.Add("@SMREF", SqlDbType.Int).Value = SMREF;
                cmd.Parameters.Add("@TIP", SqlDbType.Int).Value = TIP;
                try
                {
                    conn.Open();
                    object obj = cmd.ExecuteScalar();
                    if (obj != null)
                        donendeger = obj.ToString();
                    else
                        donendeger = string.Empty;
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
        public static bool AciklamaVarMi(int SMREF, int TIP)
        {
            bool donendeger = false;

            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3))
            {
                SqlCommand cmd = new SqlCommand("SELECT count(*) FROM [Web-Musteri-Acik] WHERE SMREF = @SMREF AND TIP = @TIP", conn);
                cmd.Parameters.Add("@SMREF", SqlDbType.Int).Value = SMREF;
                cmd.Parameters.Add("@TIP", SqlDbType.Int).Value = TIP;
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
        /// 
        /// </summary>
        public static void SetKonum(int SMREF, int TIP, string KONUM)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3))
            {
                SqlCommand cmd = new SqlCommand("", conn);
                if (AciklamaVarMi(SMREF, TIP))
                    cmd.CommandText = "UPDATE [dbo].[Web-Musteri-Acik] SET [TARIH] = getdate(),[KONUM] = @KONUM WHERE SMREF = @SMREF AND TIP = @TIP";
                else
                    cmd.CommandText = "INSERT INTO [Web-Musteri-Acik] ([SMREF],[TIP],[TARIH],[PASIF],[KAYNAK_KOD],[KONUM],[KONUM_RESIM],[TABELA_UNVANI]) VALUES (@SMREF,@TIP,getdate(),'False',1,@KONUM,NULL,'')";
                cmd.Parameters.Add("@SMREF", SqlDbType.Int).Value = SMREF;
                cmd.Parameters.Add("@TIP", SqlDbType.Int).Value = TIP;
                cmd.Parameters.Add("@KONUM", SqlDbType.NVarChar).Value = KONUM;
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
        public static void SetKonumAdres(int SMREF, int TIP, string ADRES)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3))
            {
                SqlCommand cmd = new SqlCommand("", conn);
                if (AciklamaVarMi(SMREF, TIP))
                    cmd.CommandText = "UPDATE [dbo].[Web-Musteri-Acik] SET [TARIH] = getdate(),[KONUM_ADRES] = @KONUM_ADRES WHERE SMREF = @SMREF AND TIP = @TIP";
                else
                    cmd.CommandText = "INSERT INTO [Web-Musteri-Acik] ([SMREF],[TIP],[TARIH],[PASIF],[KAYNAK_KOD],[KONUM_ADRES],[KONUM_RESIM],[TABELA_UNVANI]) VALUES (@SMREF,@TIP,getdate(),'False',1,@KONUM_ADRES,NULL,'')";
                cmd.Parameters.Add("@SMREF", SqlDbType.Int).Value = SMREF;
                cmd.Parameters.Add("@TIP", SqlDbType.Int).Value = TIP;
                cmd.Parameters.Add("@KONUM_ADRES", SqlDbType.NVarChar).Value = ADRES;
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
        public static void GetRutlar4Liste(DataTable dt, int SLSREF, DateTime Tarih)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT [ID],[SLSREF],(SELECT [SAT TEM] FROM [Web-SatisTemsilcileri] WHERE SLSMANREF = [WEB_RUT_4_LISTE].SLSREF) AS SATTEM,[GMREF],(SELECT DISTINCT MUSTERI FROM [Web-Musteri] WHERE GMREF = SMREF AND GMREF = [WEB_RUT_4_LISTE].GMREF) AS MUSTERI,[SMREF],(SELECT DISTINCT SUBE FROM [Web-Musteri-1] WHERE SMREF = [WEB_RUT_4_LISTE].SMREF AND TIP = MTIP) AS SUBE,[RUT_PRD],[GUN],[TARIH],[RUT_GOREV_NOTLARI] FROM [WEB_RUT_4_LISTE] WHERE SLSREF = @SLSREF AND TARIH = @TARIH ORDER BY SATTEM,TARIH,MUSTERI,SUBE", conn);
                da.SelectCommand.Parameters.Add("@SLSREF", SqlDbType.Int).Value = SLSREF;
                da.SelectCommand.Parameters.Add("@TARIH", SqlDbType.DateTime).Value = Tarih;

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
        public static string GetRutNot4Liste(string ID)
        {
            string donendeger = string.Empty;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT RUT_GOREV_NOTLARI FROM [WEB_RUT_4_LISTE] WHERE ID = @ID", conn);
                cmd.Parameters.Add("@ID", SqlDbType.NVarChar, 50).Value = ID;
                try
                {
                    conn.Open();
                    donendeger = cmd.ExecuteScalar().ToString();
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
        public static void SetRutNot4Liste(string ID, string Not)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UPDATE [WEB_RUT_4_LISTE] SET RUT_GOREV_NOTLARI = @RUT_GOREV_NOTLARI WHERE ID = @ID", conn);
                cmd.Parameters.Add("@ID", SqlDbType.NVarChar, 50).Value = ID;
                cmd.Parameters.Add("@RUT_GOREV_NOTLARI", SqlDbType.NVarChar).Value = Not;
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
        public static void ZiyaretEkle(int MTIP, int RUT_TUR, string RUT_ID, int GMREF, int SMREF, int SLSREF, string BARKOD, DateTime ZIY_BAS_TAR, DateTime ZIY_BIT_TAR, int ZIY_NDN_ID, string ZIY_KONUM, string ZIY_KONUM_ADRES, string ZIY_KONUM_RESIM, string ZIY_NOTLARI, int ZIY_SIP, int ZIY_AKT, int ZIY_IAD, int ZIY_TAH)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO [WEB_RUT_5_ZIYARET] ([MTIP],[RUT_TUR],[RUT_ID],[GMREF],[SMREF],[SLSREF],[BARKOD],[ZIY_BAS_TAR],[ZIY_BIT_TAR],[ZIY_NDN_ID],[ZIY_KONUM],[ZIY_KONUM_ADRES],[ZIY_KONUM_RESIM],[ZIY_NOTLARI],[ZIY_SIP],[ZIY_AKT],[ZIY_IAD],[ZIY_TAH]) VALUES (@MTIP,@RUT_TUR,@RUT_ID,@GMREF,@SMREF,@SLSREF,@BARKOD,@ZIY_BAS_TAR,@ZIY_BIT_TAR,@ZIY_NDN_ID,@ZIY_KONUM,@ZIY_KONUM_ADRES,@ZIY_KONUM_RESIM,@ZIY_NOTLARI,@ZIY_SIP,@ZIY_AKT,@ZIY_IAD,@ZIY_TAH)", conn);
                cmd.Parameters.Add("@MTIP", SqlDbType.Int).Value = MTIP;
                cmd.Parameters.Add("@RUT_TUR", SqlDbType.Int).Value = RUT_TUR;
                cmd.Parameters.Add("@RUT_ID", SqlDbType.NVarChar, 50).Value = RUT_ID;
                cmd.Parameters.Add("@GMREF", SqlDbType.Int).Value = GMREF;
                cmd.Parameters.Add("@SMREF", SqlDbType.Int).Value = SMREF;
                cmd.Parameters.Add("@SLSREF", SqlDbType.Int).Value = SLSREF;
                cmd.Parameters.Add("@BARKOD", SqlDbType.NVarChar, 50).Value = BARKOD;
                cmd.Parameters.Add("@ZIY_BAS_TAR", SqlDbType.DateTime).Value = ZIY_BAS_TAR;
                cmd.Parameters.Add("@ZIY_BIT_TAR", SqlDbType.DateTime).Value = ZIY_BIT_TAR;
                cmd.Parameters.Add("@ZIY_NDN_ID", SqlDbType.Int).Value = ZIY_NDN_ID;
                cmd.Parameters.Add("@ZIY_KONUM", SqlDbType.NVarChar, 50).Value = ZIY_KONUM;
                cmd.Parameters.Add("@ZIY_KONUM_ADRES", SqlDbType.NVarChar).Value = ZIY_KONUM_ADRES;
                cmd.Parameters.Add("@ZIY_KONUM_RESIM", SqlDbType.VarBinary).Value = DBNull.Value;
                cmd.Parameters.Add("@ZIY_NOTLARI", SqlDbType.NVarChar).Value = ZIY_NOTLARI;
                cmd.Parameters.Add("@ZIY_SIP", SqlDbType.Int).Value = ZIY_SIP;
                cmd.Parameters.Add("@ZIY_AKT", SqlDbType.Int).Value = ZIY_AKT;
                cmd.Parameters.Add("@ZIY_IAD", SqlDbType.Int).Value = ZIY_IAD;
                cmd.Parameters.Add("@ZIY_TAH", SqlDbType.Int).Value = ZIY_TAH;
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
        public static void ZiyaretGuncelle(string BARKOD, DateTime ZIY_BIT_TAR, int ZIY_NDN_ID, string ZIY_KONUM_CIKIS, string ZIY_KONUM_ADRES_CIKIS, string FARK_KNM_ZIY, string ZIY_KONUM_RESIM, string ZIY_NOTLARI)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UPDATE [WEB_RUT_5_ZIYARET] SET [ZIY_BIT_TAR] = @ZIY_BIT_TAR,[ZIY_NDN_ID] = @ZIY_NDN_ID,ZIY_KONUM_CIKIS = @ZIY_KONUM_CIKIS,ZIY_KONUM_ADRES_CIKIS = @ZIY_KONUM_ADRES_CIKIS,FARK_KNM_ZIY = @FARK_KNM_ZIY,ZIY_KONUM_RESIM = @ZIY_KONUM_RESIM,[ZIY_NOTLARI] = @ZIY_NOTLARI WHERE [RUT_ID] = @RUT_ID", conn);
                cmd.Parameters.Add("@RUT_ID", SqlDbType.VarChar, 50).Value = BARKOD;
                cmd.Parameters.Add("@ZIY_BIT_TAR", SqlDbType.DateTime).Value = ZIY_BIT_TAR;
                cmd.Parameters.Add("@ZIY_NDN_ID", SqlDbType.Int).Value = ZIY_NDN_ID;
                cmd.Parameters.Add("@ZIY_KONUM_CIKIS", SqlDbType.VarChar, 50).Value = ZIY_KONUM_CIKIS;
                cmd.Parameters.Add("@ZIY_KONUM_ADRES_CIKIS", SqlDbType.VarChar).Value = ZIY_KONUM_ADRES_CIKIS;
                cmd.Parameters.Add("@FARK_KNM_ZIY", SqlDbType.Int).Value = Convert.ToInt32(FARK_KNM_ZIY);
                cmd.Parameters.Add("@ZIY_KONUM_RESIM", SqlDbType.VarBinary).Value = DBNull.Value;
                cmd.Parameters.Add("@ZIY_NOTLARI", SqlDbType.VarChar).Value = ZIY_NOTLARI;
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
        public static void ZiyaretSil(string BARKOD)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("DELETE [WEB_RUT_5_ZIYARET] WHERE [RUT_ID] = @RUT_ID", conn);
                cmd.Parameters.Add("@RUT_ID", SqlDbType.NVarChar, 50).Value = BARKOD;
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
        /// Ziyareti başlamış şubenin adı
        /// </summary>
        public static string GetSube(string BARKOD)
        {
            string donendeger = string.Empty;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT MTIP,SMREF FROM [WEB_RUT_5_ZIYARET] WHERE [RUT_ID] = @RUT_ID", conn);
                cmd.Parameters.Add("@RUT_ID", SqlDbType.NVarChar, 50).Value = BARKOD;
                SqlDataReader dr;
                int tip = 0;
                int smref = 0;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        tip = Convert.ToInt32(dr[0]);
                        smref = Convert.ToInt32(dr[1]);
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

                if (tip == 1)
                    donendeger = CariHesaplar.GetSUBEbySMREF(smref);
                else if (tip == 2 || tip == 3 || tip == 5)
                    donendeger = CariHesapZ.GetObject(smref, tip, true).SUBE;
                else if (tip == 4)
                    donendeger = CariHesaplarTP.GetObject(smref, false).SUBE;
            }

            return donendeger;
        }
        //
        //
        public static string JobCalistir()
        {
            string donendeger = "";

            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3sa))
            {
                SqlCommand cmd1 = new SqlCommand("EXEC master.dbo.xp_sqlagent_enum_jobs 1, sa, 0x2585868256758A4DB4B8A670C8DB4794", conn);
                SqlDataReader dr;

                SqlCommand cmd = new SqlCommand("EXEC msdb.dbo.sp_start_job Web_Rut_Sap_Yeni", conn);
                try
                {
                    bool zatencalisiyor = false;
                    conn.Open();
                    dr = cmd1.ExecuteReader();
                    if (dr.Read()) zatencalisiyor = Convert.ToBoolean(dr[9]);
                    dr.Close();

                    if (!zatencalisiyor)
                    {
                        cmd.ExecuteNonQuery();
                        donendeger = "İşlem başarıyla başlatıldı.\r\n\r\nTahmini tamamlanma süresi: 15 saniye";
                    }
                    else
                    {
                        donendeger = "İşlem şu anda zaten başlatılmış durumda. Tamamlanmadan ikinci kez başlatılamaz.";
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

    public class ZiyaretZ
    {
        public int MTIP { get; set; }
        public int RUT_TUR { get; set; }
        public string RUT_ID { get; set; }
        public int GMREF { get; set; }
        public int SMREF { get; set; }
        public int SLSREF { get; set; }
        public string BARKOD { get; set; }
        public DateTime ZIY_BAS_TAR { get; set; }
        public DateTime ZIY_BIT_TAR { get; set; }
        public int ZIY_NDN_ID { get; set; }
        public string ZIY_KONUM { get; set; }
        public string ZIY_KONUM_ADRES { get; set; }
        public string ZIY_KONUM_CIKIS { get; set; }
        public string ZIY_KONUM_ADRES_CIKIS { get; set; }
        public int FARK_KNM_ZIY { get; set; }
        public string ZIY_NOTLARI { get; set; }
        public ZiyaretZ(int MTIP, int RUT_TUR, string RUT_ID, int GMREF, int SMREF, int SLSREF, string BARKOD, DateTime ZIY_BAS_TAR, DateTime ZIY_BIT_TAR, int ZIY_NDN_ID, string ZIY_KONUM, string ZIY_KONUM_ADRES, string ZIY_KONUM_CIKIS, string ZIY_KONUM_ADRES_CIKIS, int FARK_KNM_ZIY, string ZIY_NOTLARI)
        {
            this.MTIP = MTIP;
            this.RUT_TUR = RUT_TUR;
            this.RUT_ID = RUT_ID;
            this.GMREF = GMREF;
            this.SMREF = SMREF;
            this.SLSREF = SLSREF;
            this.BARKOD = BARKOD;
            this.ZIY_BAS_TAR = ZIY_BAS_TAR;
            this.ZIY_BIT_TAR = ZIY_BIT_TAR;
            this.ZIY_NDN_ID = ZIY_NDN_ID;
            this.ZIY_KONUM = ZIY_KONUM;
            this.ZIY_KONUM_ADRES = ZIY_KONUM_ADRES;
            this.ZIY_KONUM_CIKIS = ZIY_KONUM_CIKIS;
            this.ZIY_KONUM_ADRES_CIKIS = ZIY_KONUM_ADRES_CIKIS;
            this.FARK_KNM_ZIY = FARK_KNM_ZIY;
            this.ZIY_NOTLARI = ZIY_NOTLARI;
        }
    }
}

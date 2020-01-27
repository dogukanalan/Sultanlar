using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace Sultanlar.DatabaseObject.Internet
{
    public class Ekstreler
    {
        /// <summary>
        /// [Web-Ekstre]
        /// </summary>
        public static ArrayList GetToplamFiyatlar(int GMREF, short Isyeri, DateTime BaslangicTarih, DateTime BitisTarih, bool VGB)
        {
            string Vgb = VGB ? " AND [VGB] > 0" : "";

            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT [FIS TAR],[FIS VD],[BORC],[ALACAK],[BAKIYE],[VGB] FROM [KurumsalWebSAP].dbo.[Web-Ekstre] WHERE [GMREF] = @GMREF AND [FIS TAR] >= @BaslangicTarih AND [FIS TAR] <= @BitisTarih" + Vgb + " ORDER BY [FIS TAR]", conn);
                da.SelectCommand.Parameters.Add("@GMREF", SqlDbType.Int).Value = GMREF;
                da.SelectCommand.Parameters.Add("@BaslangicTarih", SqlDbType.SmallDateTime).Value = BaslangicTarih;
                da.SelectCommand.Parameters.Add("@BitisTarih", SqlDbType.SmallDateTime).Value = BitisTarih;
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

            decimal borc = 0;
            decimal alacak = 0;
            decimal bakiye = 0;
            decimal vgb = 0;
            double vadecarpiborctoplami = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                borc += Convert.ToDecimal(dt.Rows[i]["BORC"]);
                alacak += Convert.ToDecimal(dt.Rows[i]["ALACAK"]);
                bakiye += Convert.ToDecimal(dt.Rows[i]["BAKIYE"]);
                vgb += Convert.ToDecimal(dt.Rows[i]["VGB"]);

                TimeSpan span = Convert.ToDateTime(dt.Rows[i]["FIS VD"]).Subtract(Convert.ToDateTime(DateTime.Now.ToShortDateString()));
                vadecarpiborctoplami += VGB ? Convert.ToDouble(dt.Rows[i]["VGB"]) * span.Days : Convert.ToDouble(dt.Rows[i]["BORC"]) * span.Days;
            }

            double ortvade = 0;
            if (VGB)
                ortvade = vgb != 0 ? vadecarpiborctoplami / Convert.ToDouble(vgb) : 0;
            else
                ortvade = borc != 0 ? vadecarpiborctoplami / Convert.ToDouble(borc) : 0;

            ArrayList donendeger = new ArrayList();
            donendeger.Add(borc);
            donendeger.Add(alacak);
            donendeger.Add(bakiye);
            donendeger.Add(vgb);
            donendeger.Add(ortvade);

            return donendeger;
        }
        /// <summary>
        /// [Web-Ekstre]
        /// </summary>
        public static int GetObjectsCountByGMREF(int GMREF, short Isyeri, DateTime BaslangicTarih, DateTime BitisTarih, bool VGB, string Ay)
        {
            int donendeger = 0;

            string Vgb = VGB ? " AND [VGB] > 0" : "";

            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3))
            {
                SqlCommand cmd = new SqlCommand("", conn);

                if (Ay != "0")
                    cmd.CommandText = "SELECT count(*) + 1 FROM [KurumsalWebSAP].dbo.[Web-Ekstre] WHERE [GMREF] = @GMREF AND [FIS TAR] >= @BaslangicTarih AND [FIS TAR] <= @BitisTarih AND YEAR([FIS TAR]) = YEAR(getdate()) AND MONTH([FIS TAR]) >= " + Ay + Vgb;
                else
                    cmd.CommandText = "SELECT count(*) FROM [KurumsalWebSAP].dbo.[Web-Ekstre] WHERE [GMREF] = @GMREF AND [FIS TAR] >= @BaslangicTarih AND [FIS TAR] <= @BitisTarih" + Vgb;

                cmd.Parameters.Add("@GMREF", SqlDbType.Int).Value = GMREF;
                cmd.Parameters.Add("@BaslangicTarih", SqlDbType.SmallDateTime).Value = BaslangicTarih;
                cmd.Parameters.Add("@BitisTarih", SqlDbType.SmallDateTime).Value = BitisTarih;
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
        /// [Web-Ekstre]
        /// </summary>
        public static void GetObjectsByGMREF(DataTable dt, int GMREF, int Baslangic, int Adet, short Isyeri, DateTime BaslangicTarih, DateTime BitisTarih, bool VGB, string Ay)
        {
            string Vgb = VGB ? " AND [VGB] > 0" : "";
            DateTime tar = Ay != "0" ? Convert.ToDateTime("01." + Ay + "." + DateTime.Now.Year.ToString()) : Convert.ToDateTime("01.01.2012");

            DataTable dt1 = new DataTable();

            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3))
            {
                SqlDataAdapter da = new SqlDataAdapter("", conn);

                if (Ay != "0")
                    da.SelectCommand.CommandText = "SELECT '-' AS [TUR],'Ö.TOPLAM' AS [FIS TUR],CONVERT(datetime,'01." + Ay + "." + DateTime.Now.Year.ToString() + "') AS [FIS TAR],'Ö.TOPLAM' AS [FIS NO],'Ö.TOPLAM' AS [MATBU_NO],CONVERT(datetime,'01." + Ay + "." + DateTime.Now.Year.ToString() + "') AS [FIS VD],'ÖNCEK TOPLAM' AS [FIS ACIKLAMA],0 AS SATICI,ISNULL(sum([BORC]),0) AS BORC,ISNULL(sum([ALACAK]),0) AS ALACAK,ISNULL(sum([BAKIYE]),0) AS BAKIYE,ISNULL(sum([VGB]),0) AS VGB FROM [KurumsalWebSAP].dbo.[Web-Ekstre] WHERE [GMREF] = @GMREF AND [FIS TAR] >= @BaslangicTarih AND [FIS TAR] <= @BitisTarih" + Vgb + " AND [FIS TAR] < @Tarih UNION ALL SELECT [TUR],[FIS TUR],[FIS TAR],[FIS NO],[MATBU_NO],[FIS VD],[FIS ACIKLAMA],0 AS SATICI,[BORC],[ALACAK],[BAKIYE],[VGB] FROM [KurumsalWebSAP].dbo.[Web-Ekstre] WHERE [GMREF] = @GMREF AND [FIS TAR] >= @BaslangicTarih AND [FIS TAR] <= @BitisTarih" + Vgb + " AND [FIS TAR] >= @Tarih ORDER BY [FIS TAR]";
                else
                    da.SelectCommand.CommandText = "SELECT [TUR],[FIS TUR],[FIS TAR],[FIS NO],[MATBU_NO],[FIS VD],[FIS ACIKLAMA],CASE WHEN [NST] IS NULL THEN [SAT TEM] ELSE [NST] END AS SATICI,[BORC],[ALACAK],[BAKIYE],[VGB] FROM [KurumsalWebSAP].dbo.[Web-Ekstre] WHERE [GMREF] = @GMREF AND [FIS TAR] >= @BaslangicTarih AND [FIS TAR] <= @BitisTarih" + Vgb + " ORDER BY [FIS TAR]";

                da.SelectCommand.Parameters.Add("@GMREF", SqlDbType.Int).Value = GMREF;
                da.SelectCommand.Parameters.Add("@BaslangicTarih", SqlDbType.SmallDateTime).Value = BaslangicTarih;
                da.SelectCommand.Parameters.Add("@BitisTarih", SqlDbType.SmallDateTime).Value = BitisTarih;
                da.SelectCommand.Parameters.Add("@Tarih", SqlDbType.SmallDateTime).Value = tar;
                try
                {
                    conn.Open();
                    da.Fill(dt1);
                }
                catch (SqlException ex)
                {
                    Hatalar.DoInsert(ex);
                }
                finally
                {
                    conn.Close();
                }
            }

            DataTable dt2 = new DataTable();

            for (int i = 0; i < dt1.Columns.Count; i++)
                dt2.Columns.Add(dt1.Columns[i].ColumnName, dt1.Columns[i].DataType);

            decimal oncekitoplam = 0;
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                oncekitoplam += Convert.ToDecimal(dt1.Rows[i]["BAKIYE"]);
                DataRow drow = dt2.NewRow();
                drow.ItemArray = dt1.Rows[i].ItemArray;
                drow["BAKIYE"] = oncekitoplam;
                dt2.Rows.Add(drow);
            }



            for (int i = 0; i < dt1.Columns.Count; i++)
                dt.Columns.Add(dt1.Columns[i].ColumnName, dt1.Columns[i].DataType);

            int maks = Baslangic + Adet;
            if (dt2.Rows.Count < maks)
                maks = dt2.Rows.Count;

            for (int i = Baslangic; i < maks; i++)
            {
                DataRow drow = dt.NewRow();
                drow.ItemArray = dt2.Rows[i].ItemArray;
                dt.Rows.Add(drow);
            }
        }
        /// <summary>
        /// [Web-Ekstre]
        /// </summary>
        public static int GetVgbByGMREF(int GMREF)
        {
            int donendeger = 0;

            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3))
            {
                SqlCommand cmd = new SqlCommand("SELECT [VGB] FROM [SAP_B_A_2017] WHERE [MUS KOD] = @GMREF", conn);
                cmd.Parameters.Add("@GMREF", SqlDbType.Int).Value = GMREF;
                try
                {
                    conn.Open();
                    object obj = cmd.ExecuteScalar();
                    if (obj != DBNull.Value)
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
    }
}

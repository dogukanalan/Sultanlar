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
    public class SatisRapor
    {
        /// <summary>
        /// [Web-Satis-Rapor]
        /// </summary>
        public static void GetObjects(DataTable dt)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT [LT],[BOLGE],[GRP],[EKP],[ABR NO],[AMBAR],[AY],[HAFTA],[FAT TAR],[FAT NO],[FAT VD],[TUR],[TUR ACK],[F TUR],[SLSREF],[SAT KOD],[SAT TEM],[TED EKP],[TED SAT TEM],[IL],[ILCE],[MT ACIKLAMA],[GMREF],[MUS KOD],[MUSTERI],[SMREF],[SUB KOD],[SUBE],[SEVK KOD],[SEVK ADRES],[REY KOD],[REYON],[ANA GRP],[GRP KOD],[GRUP],[TED GRP],[TED KISA MAL],[BARCODE],[MAL KOD],[URT KOD],[MALZEME],[KOLI],[KDV],[BRM],[AD T],[BRUT T],[ISK T],[NET T],[KDV T],[NET+KDV T] FROM [Web-Satis-Rapor]", conn);
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
        #region ByFisNo
        /// <summary>
        /// [Web-Satis-Rapor]
        /// </summary>
        public static int GetObjectCountByFisNo(string FisNo, string Urun, string OzelKod)
        {
            int donendeger = 0;

            string suzme = string.Empty;
            if (Urun != string.Empty)
                suzme += " AND ITEMREF = " + Urun;
            if (OzelKod != string.Empty)
                suzme += " AND [GRP KOD] = '" + OzelKod + "'";

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT count(*) FROM [Web-Satis-Rapor] WHERE [FAT NO] = @FATNO" + suzme, conn);
                cmd.Parameters.Add("@FATNO", SqlDbType.VarChar).Value = FisNo;
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
        /// [Web-Satis-Rapor]
        /// </summary>
        public static void GetObjectsByFisNo(DataTable dt, string FisNo, string Urun, string OzelKod)
        {
            string suzme = string.Empty;
            if (Urun != string.Empty)
                suzme += " AND ITEMREF = " + Urun;
            if (OzelKod != string.Empty)
                suzme += " AND [GRP KOD] = '" + OzelKod + "'";

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT [FAT TAR],[FAT NO],[TUR ACK],[F TUR],[GRP KOD],[GRUP],[URT KOD],[MALZEME],KOLI,[AD T],[BRUT T],[ISK T],[NET T],[NET+KDV T] FROM [Web-Satis-Rapor] WHERE [FAT NO] = @FATNO" + suzme + " ORDER BY [MALZEME]", conn);
                da.SelectCommand.Parameters.Add("@FATNO", SqlDbType.VarChar).Value = FisNo;
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
        /// [Web-Satis-Rapor], arraylist: brüt iskonto net net+kdv
        /// </summary>
        public static ArrayList GetToplamFiyatlarByFisNo(string FisNo, string Urun, string OzelKod)
        {
            ArrayList donendeger = new ArrayList();

            string suzme = string.Empty;
            if (Urun != string.Empty)
                suzme += " AND ITEMREF = " + Urun;
            if (OzelKod != string.Empty)
                suzme += " AND [GRP KOD] = '" + OzelKod + "'";

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT sum([BRUT T]),sum([ISK T]),sum([NET T]),sum([NET+KDV T]) FROM [Web-Satis-Rapor] WHERE [FAT NO] = @FATNO" + suzme, conn);
                cmd.Parameters.Add("@FATNO", SqlDbType.VarChar).Value = FisNo;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        if (dr[0] != DBNull.Value)
                            donendeger.Add(Convert.ToDecimal(dr[0]));
                        else
                            donendeger.Add(0);
                        if (dr[1] != DBNull.Value)
                            donendeger.Add(Convert.ToDecimal(dr[1]));
                        else
                            donendeger.Add(0);
                        if (dr[2] != DBNull.Value)
                            donendeger.Add(Convert.ToDecimal(dr[2]));
                        else
                            donendeger.Add(0);
                        if (dr[3] != DBNull.Value)
                            donendeger.Add(Convert.ToDecimal(dr[3]));
                        else
                            donendeger.Add(0);
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

            if (donendeger.Count == 0)
                donendeger.Add(0); donendeger.Add(0); donendeger.Add(0); donendeger.Add(0);

            return donendeger;
        }
        //
        //
        #endregion
        //
        //
        #region SMREF
        /// <summary>
        /// [Web-Satis-Rapor]
        /// </summary>
        public static int GetObjectCountBySMREF(int SMREF, int SLSREF, ListItemCollection Urunler, int lic_si, string OzelKod, string FiyatTip, bool Bedelsizler, bool Iadeler,
            ArrayList Ozelkodlar, ArrayList Grupkodlar, DateTime BaslangicTarih, DateTime BitisTarih, bool TED)
        {
            int donendeger = 0;

            string slsrefkolon = TED ? "TEDSLSREF" : "SLSREF";

            string suzme = string.Empty;
            if (Urunler.Count > 1 && lic_si == 0) // tümü seçiminden başka ürün varsa, yoksa zaten bu arama kriterine gerek yok
            {
                string Urun = string.Empty;
                for (int i = 0; i < Urunler.Count; i++)
                    Urun += "ITEMREF = " + Urunler[i].Value + " OR ";
                if (Urun != string.Empty)
                    suzme += " AND (" + Urun.Substring(0, Urun.Length - 4) + ")";
            }
            else if (Urunler.Count > 1)
            {
                suzme += " AND ITEMREF = " + Urunler[lic_si].Value;
            }
            if (OzelKod != string.Empty)
                suzme += " AND [GRP KOD] = '" + OzelKod + "'";
            if (FiyatTip != string.Empty)
                suzme += " AND [F TUR] = '" + FiyatTip + "'";
            if (Bedelsizler)
                suzme += " AND LT = 1";
            if (Iadeler)
                suzme += " AND TUR = 3";
            else
                suzme += " AND (TUR = 3 OR TUR = 8)";

            string tarih = " AND [FAT TAR] >= @BaslangicTarih AND [FAT TAR] <= @BitisTarih";

            string ozelkodlar = string.Empty;
            string grupkodlar = string.Empty;

            for (int i = 0; i < Ozelkodlar.Count; i++)
                ozelkodlar += "[GRP KOD] = '" + Ozelkodlar[i].ToString() + "' OR ";

            if (Ozelkodlar.Count > 0)
                ozelkodlar = " AND (" + ozelkodlar.Substring(0, ozelkodlar.Length - 4) + ") ";

            for (int i = 0; i < Grupkodlar.Count; i++)
                grupkodlar += "[ANA GRP] = '" + Grupkodlar[i].ToString() + "' OR ";

            if (Grupkodlar.Count > 0)
                grupkodlar = " AND (" + grupkodlar.Substring(0, grupkodlar.Length - 4) + ") ";

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT count(*) FROM [Web-Satis-Rapor] WHERE " + slsrefkolon + " = @" + slsrefkolon + " AND SMREF = @SMREF" + suzme + tarih + ozelkodlar + grupkodlar, conn);
                cmd.Parameters.Add("@SMREF", SqlDbType.Int).Value = SMREF;
                cmd.Parameters.Add("@" + slsrefkolon, SqlDbType.Int).Value = SLSREF;
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
        /// [Web-Satis-Rapor]
        /// </summary>
        public static void GetObjectsBySMREF(DataTable dt, int SMREF, int SLSREF, ListItemCollection Urunler, int lic_si, string OzelKod, string FiyatTip, bool Bedelsizler, bool Iadeler, 
            int Baslangic, int Adet, ArrayList Ozelkodlar, ArrayList Grupkodlar, DateTime BaslangicTarih, DateTime BitisTarih, bool TED)
        {
            string slsrefkolon = TED ? "TEDSLSREF" : "SLSREF";

            string suzme = string.Empty;
            if (Urunler.Count > 1 && lic_si == 0) // tümü seçiminden başka ürün varsa, yoksa zaten bu arama kriterine gerek yok
            {
                string Urun = string.Empty;
                for (int i = 0; i < Urunler.Count; i++)
                    Urun += "ITEMREF = " + Urunler[i].Value + " OR ";
                if (Urun != string.Empty)
                    suzme += " AND (" + Urun.Substring(0, Urun.Length - 4) + ")";
            }
            else if (Urunler.Count > 1)
            {
                suzme += " AND ITEMREF = " + Urunler[lic_si].Value;
            }
            if (OzelKod != string.Empty)
                suzme += " AND [GRP KOD] = '" + OzelKod + "'";
            if (FiyatTip != string.Empty)
                suzme += " AND [F TUR] = '" + FiyatTip + "'";
            if (Bedelsizler)
                suzme += " AND LT = 1";
            if (Iadeler)
                suzme += " AND TUR = 3";
            else
                suzme += " AND (TUR = 3 OR TUR = 8)";

            string tarih = " AND [FAT TAR] >= @BaslangicTarih AND [FAT TAR] <= @BitisTarih";

            string ozelkodlar = string.Empty;
            string grupkodlar = string.Empty;

            for (int i = 0; i < Ozelkodlar.Count; i++)
                ozelkodlar += "[GRP KOD] = '" + Ozelkodlar[i].ToString() + "' OR ";

            if (Ozelkodlar.Count > 0)
                ozelkodlar = " AND (" + ozelkodlar.Substring(0, ozelkodlar.Length - 4) + ") ";

            for (int i = 0; i < Grupkodlar.Count; i++)
                grupkodlar += "[ANA GRP] = '" + Grupkodlar[i].ToString() + "' OR ";

            if (Grupkodlar.Count > 0)
                grupkodlar = " AND (" + grupkodlar.Substring(0, grupkodlar.Length - 4) + ") ";

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT GRP,CASE WHEN SUBE = '' THEN MUSTERI ELSE SUBE END AS MUSTERI,[FAT TAR],[FAT NO],[TUR ACK],[F TUR],[GRUP],[URT KOD],[MALZEME],KOLI,[AD T],[BRUT T],[ISK T],[NET T],[NET+KDV T] FROM [Web-Satis-Rapor] WHERE " + slsrefkolon + " = @" + slsrefkolon + " AND SMREF = @SMREF" + suzme + tarih + ozelkodlar + grupkodlar + " ORDER BY [FAT TAR],[FAT NO],[URT KOD],[MALZEME]", conn);
                da.SelectCommand.Parameters.Add("@SMREF", SqlDbType.Int).Value = SMREF;
                da.SelectCommand.Parameters.Add("@" + slsrefkolon, SqlDbType.Int).Value = SLSREF;
                da.SelectCommand.Parameters.Add("@BaslangicTarih", SqlDbType.SmallDateTime).Value = BaslangicTarih;
                da.SelectCommand.Parameters.Add("@BitisTarih", SqlDbType.SmallDateTime).Value = BitisTarih;
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
        /// <summary>
        /// [Web-Satis-Rapor], arraylist: brüt iskonto net net+kdv
        /// </summary>
        public static ArrayList GetToplamFiyatlarBySMREF(int SMREF, int SLSREF, ListItemCollection Urunler, int lic_si, string OzelKod, string FiyatTip, bool Bedelsizler, bool Iadeler,
            ArrayList Ozelkodlar, ArrayList Grupkodlar, DateTime BaslangicTarih, DateTime BitisTarih, bool TED)
        {
            ArrayList donendeger = new ArrayList();

            string slsrefkolon = TED ? "TEDSLSREF" : "SLSREF";

            string suzme = string.Empty;
            if (Urunler.Count > 1 && lic_si == 0) // tümü seçiminden başka ürün varsa, yoksa zaten bu arama kriterine gerek yok
            {
                string Urun = string.Empty;
                for (int i = 0; i < Urunler.Count; i++)
                    Urun += "ITEMREF = " + Urunler[i].Value + " OR ";
                if (Urun != string.Empty)
                    suzme += " AND (" + Urun.Substring(0, Urun.Length - 4) + ")";
            }
            else if (Urunler.Count > 1)
            {
                suzme += " AND ITEMREF = " + Urunler[lic_si].Value;
            }
            if (OzelKod != string.Empty)
                suzme += " AND [GRP KOD] = '" + OzelKod + "'";
            if (FiyatTip != string.Empty)
                suzme += " AND [F TUR] = '" + FiyatTip + "'";
            if (Bedelsizler)
                suzme += " AND LT = 1";
            if (Iadeler)
                suzme += " AND TUR = 3";
            else
                suzme += " AND (TUR = 3 OR TUR = 8)";

            string tarih = " AND [FAT TAR] >= @BaslangicTarih AND [FAT TAR] <= @BitisTarih";

            string ozelkodlar = string.Empty;
            string grupkodlar = string.Empty;

            for (int i = 0; i < Ozelkodlar.Count; i++)
                ozelkodlar += "[GRP KOD] = '" + Ozelkodlar[i].ToString() + "' OR ";

            if (Ozelkodlar.Count > 0)
                ozelkodlar = " AND (" + ozelkodlar.Substring(0, ozelkodlar.Length - 4) + ") ";

            for (int i = 0; i < Grupkodlar.Count; i++)
                grupkodlar += "[ANA GRP] = '" + Grupkodlar[i].ToString() + "' OR ";

            if (Grupkodlar.Count > 0)
                grupkodlar = " AND (" + grupkodlar.Substring(0, grupkodlar.Length - 4) + ") ";

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT sum([BRUT T]),sum([ISK T]),sum([NET T]),sum([NET+KDV T]),sum([AD T]),sum([AD T] / KOLI) FROM [Web-Satis-Rapor] WHERE " + slsrefkolon + " = @" + slsrefkolon + " AND SMREF = @SMREF" + suzme + tarih + ozelkodlar + grupkodlar, conn);
                cmd.Parameters.Add("@SMREF", SqlDbType.Int).Value = SMREF;
                cmd.Parameters.Add("@" + slsrefkolon, SqlDbType.Int).Value = SLSREF;
                cmd.Parameters.Add("@BaslangicTarih", SqlDbType.SmallDateTime).Value = BaslangicTarih;
                cmd.Parameters.Add("@BitisTarih", SqlDbType.SmallDateTime).Value = BitisTarih;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        if (dr[0] != DBNull.Value)
                            donendeger.Add(Convert.ToDecimal(dr[0]));
                        else
                            donendeger.Add(0);
                        if (dr[1] != DBNull.Value)
                            donendeger.Add(Convert.ToDecimal(dr[1]));
                        else
                            donendeger.Add(0);
                        if (dr[2] != DBNull.Value)
                            donendeger.Add(Convert.ToDecimal(dr[2]));
                        else
                            donendeger.Add(0);
                        if (dr[3] != DBNull.Value)
                            donendeger.Add(Convert.ToDecimal(dr[3]));
                        else
                            donendeger.Add(0);
                        if (dr[4] != DBNull.Value)
                            donendeger.Add(Convert.ToInt32(dr[4]));
                        else
                            donendeger.Add(0);
                        if (dr[5] != DBNull.Value)
                            donendeger.Add(Convert.ToInt32(dr[5]));
                        else
                            donendeger.Add(0);
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

            if (donendeger.Count == 0)
                donendeger.Add(0); donendeger.Add(0); donendeger.Add(0); donendeger.Add(0); donendeger.Add(0);

            return donendeger;
        }
        //
        //
        #endregion
        //
        //
        #region GMREF
        /// <summary>
        /// [Web-Satis-Rapor]
        /// </summary>
        public static int GetObjectCountByGMREF(int GMREF, int SLSREF, ListItemCollection Urunler, int lic_si, string OzelKod, string FiyatTip, bool Bedelsizler, bool Iadeler,
            ArrayList Ozelkodlar, ArrayList Grupkodlar, DateTime BaslangicTarih, DateTime BitisTarih, bool TED)
        {
            int donendeger = 0;

            string slsrefkolon = TED ? "TEDSLSREF" : "SLSREF";

            string suzme = string.Empty;
            if (Urunler.Count > 1 && lic_si == 0) // tümü seçiminden başka ürün varsa, yoksa zaten bu arama kriterine gerek yok
            {
                string Urun = string.Empty;
                for (int i = 0; i < Urunler.Count; i++)
                    Urun += "ITEMREF = " + Urunler[i].Value + " OR ";
                if (Urun != string.Empty)
                    suzme += " AND (" + Urun.Substring(0, Urun.Length - 4) + ")";
            }
            else if (Urunler.Count > 1)
            {
                suzme += " AND ITEMREF = " + Urunler[lic_si].Value;
            }
            if (OzelKod != string.Empty)
                suzme += " AND [GRP KOD] = '" + OzelKod + "'";
            if (FiyatTip != string.Empty)
                suzme += " AND [F TUR] = '" + FiyatTip + "'";
            if (Bedelsizler)
                suzme += " AND LT = 1";
            if (Iadeler)
                suzme += " AND TUR = 3";
            else
                suzme += " AND (TUR = 3 OR TUR = 8)";

            string tarih = " AND [FAT TAR] >= @BaslangicTarih AND [FAT TAR] <= @BitisTarih";

            string ozelkodlar = string.Empty;
            string grupkodlar = string.Empty;

            for (int i = 0; i < Ozelkodlar.Count; i++)
                ozelkodlar += "[GRP KOD] = '" + Ozelkodlar[i].ToString() + "' OR ";

            if (Ozelkodlar.Count > 0)
                ozelkodlar = " AND (" + ozelkodlar.Substring(0, ozelkodlar.Length - 4) + ") ";

            for (int i = 0; i < Grupkodlar.Count; i++)
                grupkodlar += "[ANA GRP] = '" + Grupkodlar[i].ToString() + "' OR ";

            if (Grupkodlar.Count > 0)
                grupkodlar = " AND (" + grupkodlar.Substring(0, grupkodlar.Length - 4) + ") ";

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT count(*) FROM [Web-Satis-Rapor] WHERE " + slsrefkolon + " = @" + slsrefkolon + " AND GMREF = @GMREF" + suzme + tarih + ozelkodlar + grupkodlar, conn);
                cmd.Parameters.Add("@GMREF", SqlDbType.Int).Value = GMREF;
                cmd.Parameters.Add("@" + slsrefkolon, SqlDbType.Int).Value = SLSREF;
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
        /// [Web-Satis-Rapor]
        /// </summary>
        public static void GetObjectsByGMREF(DataTable dt, int GMREF, int SLSREF, ListItemCollection Urunler, int lic_si, string OzelKod, string FiyatTip, bool Bedelsizler, bool Iadeler, 
            int Baslangic, int Adet,
            ArrayList Ozelkodlar, ArrayList Grupkodlar, DateTime BaslangicTarih, DateTime BitisTarih, bool TED)
        {
            string slsrefkolon = TED ? "TEDSLSREF" : "SLSREF";

            string suzme = string.Empty;
            if (Urunler.Count > 1 && lic_si == 0) // tümü seçiminden başka ürün varsa, yoksa zaten bu arama kriterine gerek yok
            {
                string Urun = string.Empty;
                for (int i = 0; i < Urunler.Count; i++)
                    Urun += "ITEMREF = " + Urunler[i].Value + " OR ";
                if (Urun != string.Empty)
                    suzme += " AND (" + Urun.Substring(0, Urun.Length - 4) + ")";
            }
            else if (Urunler.Count > 1)
            {
                suzme += " AND ITEMREF = " + Urunler[lic_si].Value;
            }
            if (OzelKod != string.Empty)
                suzme += " AND [GRP KOD] = '" + OzelKod + "'";
            if (FiyatTip != string.Empty)
                suzme += " AND [F TUR] = '" + FiyatTip + "'";
            if (Bedelsizler)
                suzme += " AND LT = 1";
            if (Iadeler)
                suzme += " AND TUR = 3";
            else
                suzme += " AND (TUR = 3 OR TUR = 8)";

            string tarih = " AND [FAT TAR] >= @BaslangicTarih AND [FAT TAR] <= @BitisTarih";

            string ozelkodlar = string.Empty;
            string grupkodlar = string.Empty;

            for (int i = 0; i < Ozelkodlar.Count; i++)
                ozelkodlar += "[GRP KOD] = '" + Ozelkodlar[i].ToString() + "' OR ";

            if (Ozelkodlar.Count > 0)
                ozelkodlar = " AND (" + ozelkodlar.Substring(0, ozelkodlar.Length - 4) + ") ";

            for (int i = 0; i < Grupkodlar.Count; i++)
                grupkodlar += "[ANA GRP] = '" + Grupkodlar[i].ToString() + "' OR ";

            if (Grupkodlar.Count > 0)
                grupkodlar = " AND (" + grupkodlar.Substring(0, grupkodlar.Length - 4) + ") ";

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT GRP,CASE WHEN SUBE = '' THEN MUSTERI ELSE SUBE END AS MUSTERI,[FAT TAR],[FAT NO],[TUR ACK],[F TUR],[GRUP],[URT KOD],[MALZEME],KOLI,[AD T],[BRUT T],[ISK T],[NET T],[NET+KDV T] FROM [Web-Satis-Rapor] WHERE " + slsrefkolon + " = @" + slsrefkolon + " AND GMREF = @GMREF" + suzme + tarih + ozelkodlar + grupkodlar + " ORDER BY [FAT TAR],[FAT NO],[URT KOD],[MALZEME]", conn);
                da.SelectCommand.Parameters.Add("@GMREF", SqlDbType.Int).Value = GMREF;
                da.SelectCommand.Parameters.Add("@" + slsrefkolon, SqlDbType.Int).Value = SLSREF;
                da.SelectCommand.Parameters.Add("@BaslangicTarih", SqlDbType.SmallDateTime).Value = BaslangicTarih;
                da.SelectCommand.Parameters.Add("@BitisTarih", SqlDbType.SmallDateTime).Value = BitisTarih;
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
        /// <summary>
        /// [Web-Satis-Rapor], arraylist: brüt iskonto net net+kdv
        /// </summary>
        public static ArrayList GetToplamFiyatlarByGMREF(int GMREF, int SLSREF, ListItemCollection Urunler, int lic_si, string OzelKod, string FiyatTip, bool Bedelsizler, bool Iadeler,
            ArrayList Ozelkodlar, ArrayList Grupkodlar, DateTime BaslangicTarih, DateTime BitisTarih, bool TED)
        {
            ArrayList donendeger = new ArrayList();

            string slsrefkolon = TED ? "TEDSLSREF" : "SLSREF";

            string suzme = string.Empty;
            if (Urunler.Count > 1 && lic_si == 0) // tümü seçiminden başka ürün varsa, yoksa zaten bu arama kriterine gerek yok
            {
                string Urun = string.Empty;
                for (int i = 0; i < Urunler.Count; i++)
                    Urun += "ITEMREF = " + Urunler[i].Value + " OR ";
                if (Urun != string.Empty)
                    suzme += " AND (" + Urun.Substring(0, Urun.Length - 4) + ")";
            }
            else if (Urunler.Count > 1)
            {
                suzme += " AND ITEMREF = " + Urunler[lic_si].Value;
            }
            if (OzelKod != string.Empty)
                suzme += " AND [GRP KOD] = '" + OzelKod + "'";
            if (FiyatTip != string.Empty)
                suzme += " AND [F TUR] = '" + FiyatTip + "'";
            if (Bedelsizler)
                suzme += " AND LT = 1";
            if (Iadeler)
                suzme += " AND TUR = 3";
            else
                suzme += " AND (TUR = 3 OR TUR = 8)";

            string tarih = " AND [FAT TAR] >= @BaslangicTarih AND [FAT TAR] <= @BitisTarih";

            string ozelkodlar = string.Empty;
            string grupkodlar = string.Empty;

            for (int i = 0; i < Ozelkodlar.Count; i++)
                ozelkodlar += "[GRP KOD] = '" + Ozelkodlar[i].ToString() + "' OR ";

            if (Ozelkodlar.Count > 0)
                ozelkodlar = " AND (" + ozelkodlar.Substring(0, ozelkodlar.Length - 4) + ") ";

            for (int i = 0; i < Grupkodlar.Count; i++)
                grupkodlar += "[ANA GRP] = '" + Grupkodlar[i].ToString() + "' OR ";

            if (Grupkodlar.Count > 0)
                grupkodlar = " AND (" + grupkodlar.Substring(0, grupkodlar.Length - 4) + ") ";

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT sum([BRUT T]),sum([ISK T]),sum([NET T]),sum([NET+KDV T]),sum([AD T]),sum([AD T] / KOLI) FROM [Web-Satis-Rapor] WHERE " + slsrefkolon + " = @" + slsrefkolon + " AND GMREF = @GMREF" + suzme + tarih + ozelkodlar + grupkodlar, conn);
                cmd.Parameters.Add("@GMREF", SqlDbType.Int).Value = GMREF;
                cmd.Parameters.Add("@" + slsrefkolon, SqlDbType.Int).Value = SLSREF;
                cmd.Parameters.Add("@BaslangicTarih", SqlDbType.SmallDateTime).Value = BaslangicTarih;
                cmd.Parameters.Add("@BitisTarih", SqlDbType.SmallDateTime).Value = BitisTarih;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        if (dr[0] != DBNull.Value)
                            donendeger.Add(Convert.ToDecimal(dr[0]));
                        else
                            donendeger.Add(0);
                        if (dr[1] != DBNull.Value)
                            donendeger.Add(Convert.ToDecimal(dr[1]));
                        else
                            donendeger.Add(0);
                        if (dr[2] != DBNull.Value)
                            donendeger.Add(Convert.ToDecimal(dr[2]));
                        else
                            donendeger.Add(0);
                        if (dr[3] != DBNull.Value)
                            donendeger.Add(Convert.ToDecimal(dr[3]));
                        else
                            donendeger.Add(0);
                        if (dr[4] != DBNull.Value)
                            donendeger.Add(Convert.ToInt32(dr[4]));
                        else
                            donendeger.Add(0);
                        if (dr[5] != DBNull.Value)
                            donendeger.Add(Convert.ToInt32(dr[5]));
                        else
                            donendeger.Add(0);
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

            if (donendeger.Count == 0)
                donendeger.Add(0); donendeger.Add(0); donendeger.Add(0); donendeger.Add(0); donendeger.Add(0);

            return donendeger;
        }
        //
        //
        #endregion
        //
        //
        #region SLSREF
        /// <summary>
        /// [Web-Satis-Rapor]
        /// </summary>
        public static int GetObjectCountBySLSREF(int SLSREF, ListItemCollection Urunler, int lic_si, string OzelKod, string FiyatTip, bool Bedelsizler, bool Iadeler,
            ArrayList Ozelkodlar, ArrayList Grupkodlar, DateTime BaslangicTarih, DateTime BitisTarih, bool TED)
        {
            int donendeger = 0;
            
            string slsrefkolon = TED ? "TEDSLSREF" : "SLSREF";

            string suzme = string.Empty;
            if (Urunler.Count > 1 && lic_si == 0) // tümü seçiminden başka ürün varsa, yoksa zaten bu arama kriterine gerek yok
            {
                string Urun = string.Empty;
                for (int i = 0; i < Urunler.Count; i++)
                    Urun += "ITEMREF = " + Urunler[i].Value + " OR ";
                if (Urun != string.Empty)
                    suzme += " AND (" + Urun.Substring(0, Urun.Length - 4) + ")";
            }
            else if (Urunler.Count > 1)
            {
                suzme += " AND ITEMREF = " + Urunler[lic_si].Value;
            }
            if (OzelKod != string.Empty)
                suzme += " AND [GRP KOD] = '" + OzelKod + "'";
            if (FiyatTip != string.Empty)
                suzme += " AND [F TUR] = '" + FiyatTip + "'";
            if (Bedelsizler)
                suzme += " AND LT = 1";
            if (Iadeler)
                suzme += " AND TUR = 3";
            else
                suzme += " AND (TUR = 3 OR TUR = 8)";

            string tarih = " AND [FAT TAR] >= @BaslangicTarih AND [FAT TAR] <= @BitisTarih";

            string ozelkodlar = string.Empty;
            string grupkodlar = string.Empty;

            for (int i = 0; i < Ozelkodlar.Count; i++)
                ozelkodlar += "[GRP KOD] = '" + Ozelkodlar[i].ToString() + "' OR ";

            if (Ozelkodlar.Count > 0)
                ozelkodlar = " AND (" + ozelkodlar.Substring(0, ozelkodlar.Length - 4) + ") ";

            for (int i = 0; i < Grupkodlar.Count; i++)
                grupkodlar += "[ANA GRP] = '" + Grupkodlar[i].ToString() + "' OR ";

            if (Grupkodlar.Count > 0)
                grupkodlar = " AND (" + grupkodlar.Substring(0, grupkodlar.Length - 4) + ") ";

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT count(*) FROM [Web-Satis-Rapor] WHERE " + slsrefkolon + " = @" + slsrefkolon + suzme + tarih + ozelkodlar + grupkodlar, conn);
                cmd.Parameters.Add("@" + slsrefkolon, SqlDbType.Int).Value = SLSREF;
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
        /// [Web-Satis-Rapor]
        /// </summary>
        public static void GetObjectsBySLSREF(DataTable dt, int SLSREF, ListItemCollection Urunler, int lic_si, string OzelKod, string FiyatTip, bool Bedelsizler, bool Iadeler, 
            int Baslangic, int Adet,
            ArrayList Ozelkodlar, ArrayList Grupkodlar, DateTime BaslangicTarih, DateTime BitisTarih, bool TED)
        {
            string slsrefkolon = TED ? "TEDSLSREF" : "SLSREF";

            string suzme = string.Empty;
            if (Urunler.Count > 1 && lic_si == 0) // tümü seçiminden başka ürün varsa, yoksa zaten bu arama kriterine gerek yok
            {
                string Urun = string.Empty;
                for (int i = 0; i < Urunler.Count; i++)
                    Urun += "ITEMREF = " + Urunler[i].Value + " OR ";
                if (Urun != string.Empty)
                    suzme += " AND (" + Urun.Substring(0, Urun.Length - 4) + ")";
            }
            else if (Urunler.Count > 1)
            {
                suzme += " AND ITEMREF = " + Urunler[lic_si].Value;
            }
            if (OzelKod != string.Empty)
                suzme += " AND [GRP KOD] = '" + OzelKod + "'";
            if (FiyatTip != string.Empty)
                suzme += " AND [F TUR] = '" + FiyatTip + "'";
            if (Bedelsizler)
                suzme += " AND LT = 1";
            if (Iadeler)
                suzme += " AND TUR = 3";
            else
                suzme += " AND (TUR = 3 OR TUR = 8)";

            string tarih = " AND [FAT TAR] >= @BaslangicTarih AND [FAT TAR] <= @BitisTarih";

            string ozelkodlar = string.Empty;
            string grupkodlar = string.Empty;

            for (int i = 0; i < Ozelkodlar.Count; i++)
                ozelkodlar += "[GRP KOD] = '" + Ozelkodlar[i].ToString() + "' OR ";

            if (Ozelkodlar.Count > 0)
                ozelkodlar = " AND (" + ozelkodlar.Substring(0, ozelkodlar.Length - 4) + ") ";

            for (int i = 0; i < Grupkodlar.Count; i++)
                grupkodlar += "[ANA GRP] = '" + Grupkodlar[i].ToString() + "' OR ";

            if (Grupkodlar.Count > 0)
                grupkodlar = " AND (" + grupkodlar.Substring(0, grupkodlar.Length - 4) + ") ";

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT GRP,CASE WHEN SUBE = '' THEN MUSTERI ELSE SUBE END AS MUSTERI,[FAT TAR],[FAT NO],[TUR ACK],[F TUR],[GRUP],[URT KOD],[MALZEME],KOLI,[AD T],[BRUT T],[ISK T],[NET T],[NET+KDV T] FROM [Web-Satis-Rapor] WHERE " + slsrefkolon + " = @" + slsrefkolon + suzme + tarih + ozelkodlar + grupkodlar + " ORDER BY [FAT TAR],[FAT NO],[MALZEME]", conn);
                da.SelectCommand.Parameters.Add("@" + slsrefkolon, SqlDbType.Int).Value = SLSREF;
                da.SelectCommand.Parameters.Add("@BaslangicTarih", SqlDbType.SmallDateTime).Value = BaslangicTarih;
                da.SelectCommand.Parameters.Add("@BitisTarih", SqlDbType.SmallDateTime).Value = BitisTarih;
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
        /// <summary>
        /// [Web-Satis-Rapor], arraylist: brüt iskonto net net+kdv
        /// </summary>
        public static ArrayList GetToplamFiyatlarBySLSREF(int SLSREF, ListItemCollection Urunler, int lic_si, string OzelKod, string FiyatTip, bool Bedelsizler, bool Iadeler,
            ArrayList Ozelkodlar, ArrayList Grupkodlar, DateTime BaslangicTarih, DateTime BitisTarih, bool TED)
        {
            string slsrefkolon = TED ? "TEDSLSREF" : "SLSREF";

            ArrayList donendeger = new ArrayList();

            string suzme = string.Empty;
            if (Urunler.Count > 1 && lic_si == 0) // tümü seçiminden başka ürün varsa, yoksa zaten bu arama kriterine gerek yok
            {
                string Urun = string.Empty;
                for (int i = 0; i < Urunler.Count; i++)
                    Urun += "ITEMREF = " + Urunler[i].Value + " OR ";
                if (Urun != string.Empty)
                    suzme += " AND (" + Urun.Substring(0, Urun.Length - 4) + ")";
            }
            else if (Urunler.Count > 1)
            {
                suzme += " AND ITEMREF = " + Urunler[lic_si].Value;
            }
            if (OzelKod != string.Empty)
                suzme += " AND [GRP KOD] = '" + OzelKod + "'";
            if (FiyatTip != string.Empty)
                suzme += " AND [F TUR] = '" + FiyatTip + "'";
            if (Bedelsizler)
                suzme += " AND LT = 1";
            if (Iadeler)
                suzme += " AND TUR = 3";
            else
                suzme += " AND (TUR = 3 OR TUR = 8)";

            string tarih = " AND [FAT TAR] >= @BaslangicTarih AND [FAT TAR] <= @BitisTarih";

            string ozelkodlar = string.Empty;
            string grupkodlar = string.Empty;

            for (int i = 0; i < Ozelkodlar.Count; i++)
                ozelkodlar += "[GRP KOD] = '" + Ozelkodlar[i].ToString() + "' OR ";

            if (Ozelkodlar.Count > 0)
                ozelkodlar = " AND (" + ozelkodlar.Substring(0, ozelkodlar.Length - 4) + ") ";

            for (int i = 0; i < Grupkodlar.Count; i++)
                grupkodlar += "[ANA GRP] = '" + Grupkodlar[i].ToString() + "' OR ";

            if (Grupkodlar.Count > 0)
                grupkodlar = " AND (" + grupkodlar.Substring(0, grupkodlar.Length - 4) + ") ";

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT sum([BRUT T]),sum([ISK T]),sum([NET T]),sum([NET+KDV T]),sum([AD T]),sum([AD T] / KOLI) FROM [Web-Satis-Rapor] WHERE " + slsrefkolon + " = @" + slsrefkolon + suzme + tarih + ozelkodlar + grupkodlar, conn);
                cmd.Parameters.Add("@" + slsrefkolon, SqlDbType.Int).Value = SLSREF;
                cmd.Parameters.Add("@BaslangicTarih", SqlDbType.SmallDateTime).Value = BaslangicTarih;
                cmd.Parameters.Add("@BitisTarih", SqlDbType.SmallDateTime).Value = BitisTarih;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        if (dr[0] != DBNull.Value)
                            donendeger.Add(Convert.ToDecimal(dr[0]));
                        else
                            donendeger.Add(0);
                        if (dr[1] != DBNull.Value)
                            donendeger.Add(Convert.ToDecimal(dr[1]));
                        else
                            donendeger.Add(0);
                        if (dr[2] != DBNull.Value)
                            donendeger.Add(Convert.ToDecimal(dr[2]));
                        else
                            donendeger.Add(0);
                        if (dr[3] != DBNull.Value)
                            donendeger.Add(Convert.ToDecimal(dr[3]));
                        else
                            donendeger.Add(0);
                        if (dr[4] != DBNull.Value)
                            donendeger.Add(Convert.ToInt32(dr[4]));
                        else
                            donendeger.Add(0);
                        if (dr[5] != DBNull.Value)
                            donendeger.Add(Convert.ToInt32(dr[5]));
                        else
                            donendeger.Add(0);
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

            if (donendeger.Count == 0)
                donendeger.Add(0); donendeger.Add(0); donendeger.Add(0); donendeger.Add(0); donendeger.Add(0);

            return donendeger;
        }
        //
        //
        #endregion
        //
        //
        #region SLSREFs
        /// <summary>
        /// [Web-Satis-Rapor]
        /// </summary>
        public static int GetObjectCountBySLSREFs(ArrayList SLSREF, ListItemCollection Urunler, int lic_si, string OzelKod, string FiyatTip, bool Bedelsizler, bool Iadeler,
            ArrayList Ozelkodlar, ArrayList Grupkodlar, DateTime BaslangicTarih, DateTime BitisTarih, bool TED)
        {
            int donendeger = 0;

            string slsrefkolon = TED ? "TEDSLSREF" : "SLSREF";

            string slsrefs = string.Empty;
            for (int i = 0; i < SLSREF.Count; i++)
                slsrefs += slsrefkolon + " = " + SLSREF[i].ToString() + " OR ";
            if (SLSREF.Count > 0)
                slsrefs = "(" + slsrefs.Substring(0, slsrefs.Length - 4) + ")";
            else
                return 0;

            string suzme = string.Empty;
            if (Urunler.Count > 1 && lic_si == 0) // tümü seçiminden başka ürün varsa, yoksa zaten bu arama kriterine gerek yok
            {
                string Urun = string.Empty;
                for (int i = 0; i < Urunler.Count; i++)
                    Urun += "ITEMREF = " + Urunler[i].Value + " OR ";
                if (Urun != string.Empty)
                    suzme += " AND (" + Urun.Substring(0, Urun.Length - 4) + ")";
            }
            else if (Urunler.Count > 1)
            {
                suzme += " AND ITEMREF = " + Urunler[lic_si].Value;
            }
            if (OzelKod != string.Empty)
                suzme += " AND [GRP KOD] = '" + OzelKod + "'";
            if (FiyatTip != string.Empty)
                suzme += " AND [F TUR] = '" + FiyatTip + "'";
            if (Bedelsizler)
                suzme += " AND LT = 1";
            if (Iadeler)
                suzme += " AND TUR = 3";
            else
                suzme += " AND (TUR = 3 OR TUR = 8)";

            string tarih = " AND [FAT TAR] >= @BaslangicTarih AND [FAT TAR] <= @BitisTarih";

            string ozelkodlar = string.Empty;
            string grupkodlar = string.Empty;

            for (int i = 0; i < Ozelkodlar.Count; i++)
                ozelkodlar += "[GRP KOD] = '" + Ozelkodlar[i].ToString() + "' OR ";

            if (Ozelkodlar.Count > 0)
                ozelkodlar = " AND (" + ozelkodlar.Substring(0, ozelkodlar.Length - 4) + ") ";

            for (int i = 0; i < Grupkodlar.Count; i++)
                grupkodlar += "[ANA GRP] = '" + Grupkodlar[i].ToString() + "' OR ";

            if (Grupkodlar.Count > 0)
                grupkodlar = " AND (" + grupkodlar.Substring(0, grupkodlar.Length - 4) + ") ";

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT count(*) FROM [Web-Satis-Rapor] WHERE " + slsrefs + suzme + tarih + ozelkodlar + grupkodlar, conn);
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
        /// [Web-Satis-Rapor]
        /// </summary>
        public static void GetObjectsBySLSREFs(DataTable dt, ArrayList SLSREF, ListItemCollection Urunler, int lic_si, string OzelKod, string FiyatTip, bool Bedelsizler, bool Iadeler, 
            int Baslangic, int Adet,
            ArrayList Ozelkodlar, ArrayList Grupkodlar, DateTime BaslangicTarih, DateTime BitisTarih, bool TED)
        {
            string slsrefkolon = TED ? "TEDSLSREF" : "SLSREF";

            string slsrefs = string.Empty;
            for (int i = 0; i < SLSREF.Count; i++)
                slsrefs += slsrefkolon + " = " + SLSREF[i].ToString() + " OR ";
            if (SLSREF.Count > 0)
                slsrefs = "(" + slsrefs.Substring(0, slsrefs.Length - 4) + ")";
            else
                return;

            string suzme = string.Empty;
            if (Urunler.Count > 1 && lic_si == 0) // tümü seçiminden başka ürün varsa, yoksa zaten bu arama kriterine gerek yok
            {
                string Urun = string.Empty;
                for (int i = 0; i < Urunler.Count; i++)
                    Urun += "ITEMREF = " + Urunler[i].Value + " OR ";
                if (Urun != string.Empty)
                    suzme += " AND (" + Urun.Substring(0, Urun.Length - 4) + ")";
            }
            else if (Urunler.Count > 1)
            {
                suzme += " AND ITEMREF = " + Urunler[lic_si].Value;
            }
            if (OzelKod != string.Empty)
                suzme += " AND [GRP KOD] = '" + OzelKod + "'";
            if (FiyatTip != string.Empty)
                suzme += " AND [F TUR] = '" + FiyatTip + "'";
            if (Bedelsizler)
                suzme += " AND LT = 1";
            if (Iadeler)
                suzme += " AND TUR = 3";
            else
                suzme += " AND (TUR = 3 OR TUR = 8)";

            string tarih = " AND [FAT TAR] >= @BaslangicTarih AND [FAT TAR] <= @BitisTarih";

            string ozelkodlar = string.Empty;
            string grupkodlar = string.Empty;

            for (int i = 0; i < Ozelkodlar.Count; i++)
                ozelkodlar += "[GRP KOD] = '" + Ozelkodlar[i].ToString() + "' OR ";

            if (Ozelkodlar.Count > 0)
                ozelkodlar = " AND (" + ozelkodlar.Substring(0, ozelkodlar.Length - 4) + ") ";

            for (int i = 0; i < Grupkodlar.Count; i++)
                grupkodlar += "[ANA GRP] = '" + Grupkodlar[i].ToString() + "' OR ";

            if (Grupkodlar.Count > 0)
                grupkodlar = " AND (" + grupkodlar.Substring(0, grupkodlar.Length - 4) + ") ";

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT GRP,CASE WHEN SUBE = '' THEN MUSTERI ELSE SUBE END AS MUSTERI,[FAT TAR],[FAT NO],[TUR ACK],[F TUR],[GRUP],[URT KOD],[MALZEME],KOLI,[AD T],[BRUT T],[ISK T],[NET T],[NET+KDV T] FROM [Web-Satis-Rapor] WHERE " + slsrefs + suzme + tarih + ozelkodlar + grupkodlar + " ORDER BY [FAT TAR],[FAT NO],[MALZEME]", conn);
                da.SelectCommand.Parameters.Add("@BaslangicTarih", SqlDbType.SmallDateTime).Value = BaslangicTarih;
                da.SelectCommand.Parameters.Add("@BitisTarih", SqlDbType.SmallDateTime).Value = BitisTarih;
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
        /// <summary>
        /// [Web-Satis-Rapor], arraylist: brüt iskonto net net+kdv
        /// </summary>
        public static ArrayList GetToplamFiyatlarBySLSREFs(ArrayList SLSREF, ListItemCollection Urunler, int lic_si, string OzelKod, string FiyatTip, bool Bedelsizler, bool Iadeler,
            ArrayList Ozelkodlar, ArrayList Grupkodlar, DateTime BaslangicTarih, DateTime BitisTarih, bool TED)
        {
            ArrayList donendeger = new ArrayList();

            string slsrefkolon = TED ? "TEDSLSREF" : "SLSREF";

            string slsrefs = string.Empty;
            for (int i = 0; i < SLSREF.Count; i++)
                slsrefs += slsrefkolon + " = " + SLSREF[i].ToString() + " OR ";
            if (SLSREF.Count > 0)
                slsrefs = "(" + slsrefs.Substring(0, slsrefs.Length - 4) + ")";
            else
                return donendeger;

            string suzme = string.Empty;
            if (Urunler.Count > 1 && lic_si == 0) // tümü seçiminden başka ürün varsa, yoksa zaten bu arama kriterine gerek yok
            {
                string Urun = string.Empty;
                for (int i = 0; i < Urunler.Count; i++)
                    Urun += "ITEMREF = " + Urunler[i].Value + " OR ";
                if (Urun != string.Empty)
                    suzme += " AND (" + Urun.Substring(0, Urun.Length - 4) + ")";
            }
            else if (Urunler.Count > 1)
            {
                suzme += " AND ITEMREF = " + Urunler[lic_si].Value;
            }
            if (OzelKod != string.Empty)
                suzme += " AND [GRP KOD] = '" + OzelKod + "'";
            if (FiyatTip != string.Empty)
                suzme += " AND [F TUR] = '" + FiyatTip + "'";
            if (Bedelsizler)
                suzme += " AND LT = 1";
            if (Iadeler)
                suzme += " AND TUR = 3";
            else
                suzme += " AND (TUR = 3 OR TUR = 8)";

            string tarih = " AND [FAT TAR] >= @BaslangicTarih AND [FAT TAR] <= @BitisTarih";

            string ozelkodlar = string.Empty;
            string grupkodlar = string.Empty;

            for (int i = 0; i < Ozelkodlar.Count; i++)
                ozelkodlar += "[GRP KOD] = '" + Ozelkodlar[i].ToString() + "' OR ";

            if (Ozelkodlar.Count > 0)
                ozelkodlar = " AND (" + ozelkodlar.Substring(0, ozelkodlar.Length - 4) + ") ";

            for (int i = 0; i < Grupkodlar.Count; i++)
                grupkodlar += "[ANA GRP] = '" + Grupkodlar[i].ToString() + "' OR ";

            if (Grupkodlar.Count > 0)
                grupkodlar = " AND (" + grupkodlar.Substring(0, grupkodlar.Length - 4) + ") ";

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT sum([BRUT T]),sum([ISK T]),sum([NET T]),sum([NET+KDV T]),sum([AD T]),sum([AD T] / KOLI) FROM [Web-Satis-Rapor] WHERE " + slsrefs + suzme + tarih + ozelkodlar + grupkodlar, conn);
                cmd.Parameters.Add("@BaslangicTarih", SqlDbType.SmallDateTime).Value = BaslangicTarih;
                cmd.Parameters.Add("@BitisTarih", SqlDbType.SmallDateTime).Value = BitisTarih;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        if (dr[0] != DBNull.Value)
                            donendeger.Add(Convert.ToDecimal(dr[0]));
                        else
                            donendeger.Add(0);
                        if (dr[1] != DBNull.Value)
                            donendeger.Add(Convert.ToDecimal(dr[1]));
                        else
                            donendeger.Add(0);
                        if (dr[2] != DBNull.Value)
                            donendeger.Add(Convert.ToDecimal(dr[2]));
                        else
                            donendeger.Add(0);
                        if (dr[3] != DBNull.Value)
                            donendeger.Add(Convert.ToDecimal(dr[3]));
                        else
                            donendeger.Add(0);
                        if (dr[4] != DBNull.Value)
                            donendeger.Add(Convert.ToInt32(dr[4]));
                        else
                            donendeger.Add(0);
                        if (dr[5] != DBNull.Value)
                            donendeger.Add(Convert.ToInt32(dr[5]));
                        else
                            donendeger.Add(0);
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

            if (donendeger.Count == 0)
                donendeger.Add(0); donendeger.Add(0); donendeger.Add(0); donendeger.Add(0); donendeger.Add(0);

            return donendeger;
        }
        //
        //
        #endregion
        //
        //
        #region All
        /// <summary>
        /// [Web-Satis-Rapor]
        /// </summary>
        public static int GetObjectCount(ListItemCollection Urunler, int lic_si, string OzelKod, string FiyatTip, bool Bedelsizler, bool Iadeler,
            ArrayList Ozelkodlar, ArrayList Grupkodlar, DateTime BaslangicTarih, DateTime BitisTarih)
        {
            int donendeger = 0;

            string suzme = string.Empty;
            if (Urunler.Count > 1 && lic_si == 0) // tümü seçiminden başka ürün varsa, yoksa zaten bu arama kriterine gerek yok
            {
                string Urun = string.Empty;
                for (int i = 0; i < Urunler.Count; i++)
                    Urun += "ITEMREF = " + Urunler[i].Value + " OR ";
                if (Urun != string.Empty)
                    suzme += " AND (" + Urun.Substring(0, Urun.Length - 4) + ")";
            }
            else if (Urunler.Count > 1)
            {
                suzme += " AND ITEMREF = " + Urunler[lic_si].Value;
            }
            if (OzelKod != string.Empty)
                suzme += " AND [GRP KOD] = '" + OzelKod + "'";
            if (FiyatTip != string.Empty)
                suzme += " AND [F TUR] = '" + FiyatTip + "'";
            if (Bedelsizler)
                suzme += " AND LT = 1";
            if (Iadeler)
                suzme += " AND TUR = 3";
            else
                suzme += " AND (TUR = 3 OR TUR = 8)";

            string tarih = " AND [FAT TAR] >= @BaslangicTarih AND [FAT TAR] <= @BitisTarih";

            string ozelkodlar = string.Empty;
            string grupkodlar = string.Empty;

            for (int i = 0; i < Ozelkodlar.Count; i++)
                ozelkodlar += "[GRP KOD] = '" + Ozelkodlar[i].ToString() + "' OR ";

            if (Ozelkodlar.Count > 0)
                ozelkodlar = " AND (" + ozelkodlar.Substring(0, ozelkodlar.Length - 4) + ") ";

            for (int i = 0; i < Grupkodlar.Count; i++)
                grupkodlar += "[ANA GRP] = '" + Grupkodlar[i].ToString() + "' OR ";

            if (Grupkodlar.Count > 0)
                grupkodlar = " AND (" + grupkodlar.Substring(0, grupkodlar.Length - 4) + ") ";

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT count(*) FROM [Web-Satis-Rapor] WHERE ITEMREF IS NOT NULL " + suzme + tarih + ozelkodlar + grupkodlar, conn);
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
        /// [Web-Satis-Rapor]
        /// </summary>
        public static void GetObjects(DataTable dt, ListItemCollection Urunler, int lic_si, string OzelKod, string FiyatTip, bool Bedelsizler, bool Iadeler, int Baslangic, int Adet,
            ArrayList Ozelkodlar, ArrayList Grupkodlar, DateTime BaslangicTarih, DateTime BitisTarih)
        {
            string suzme = string.Empty;
            if (Urunler.Count > 1 && lic_si == 0) // tümü seçiminden başka ürün varsa, yoksa zaten bu arama kriterine gerek yok
            {
                string Urun = string.Empty;
                for (int i = 0; i < Urunler.Count; i++)
                    Urun += "ITEMREF = " + Urunler[i].Value + " OR ";
                if (Urun != string.Empty)
                    suzme += " AND (" + Urun.Substring(0, Urun.Length - 4) + ")";
            }
            else if (Urunler.Count > 1)
            {
                suzme += " AND ITEMREF = " + Urunler[lic_si].Value;
            }
            if (OzelKod != string.Empty)
                suzme += " AND [GRP KOD] = '" + OzelKod + "'";
            if (FiyatTip != string.Empty)
                suzme += " AND [F TUR] = '" + FiyatTip + "'";
            if (Bedelsizler)
                suzme += " AND LT = 1";
            if (Iadeler)
                suzme += " AND TUR = 3";
            else
                suzme += " AND (TUR = 3 OR TUR = 8)";

            string tarih = " AND [FAT TAR] >= @BaslangicTarih AND [FAT TAR] <= @BitisTarih";

            string ozelkodlar = string.Empty;
            string grupkodlar = string.Empty;

            for (int i = 0; i < Ozelkodlar.Count; i++)
                ozelkodlar += "[GRP KOD] = '" + Ozelkodlar[i].ToString() + "' OR ";

            if (Ozelkodlar.Count > 0)
                ozelkodlar = " AND (" + ozelkodlar.Substring(0, ozelkodlar.Length - 4) + ") ";

            for (int i = 0; i < Grupkodlar.Count; i++)
                grupkodlar += "[ANA GRP] = '" + Grupkodlar[i].ToString() + "' OR ";

            if (Grupkodlar.Count > 0)
                grupkodlar = " AND (" + grupkodlar.Substring(0, grupkodlar.Length - 4) + ") ";

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT GRP,CASE WHEN SUBE = '' THEN MUSTERI ELSE SUBE END AS MUSTERI,[FAT TAR],[FAT NO],[TUR ACK],[F TUR],[GRUP],[URT KOD],[MALZEME],KOLI,[AD T],[BRUT T],[ISK T],[NET T],[NET+KDV T] FROM [Web-Satis-Rapor] WHERE ITEMREF IS NOT NULL " + suzme + tarih + ozelkodlar + grupkodlar + " ORDER BY [FAT TAR],[FAT NO],[MALZEME]", conn);
                da.SelectCommand.Parameters.Add("@BaslangicTarih", SqlDbType.SmallDateTime).Value = BaslangicTarih;
                da.SelectCommand.Parameters.Add("@BitisTarih", SqlDbType.SmallDateTime).Value = BitisTarih;
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
        /// <summary>
        /// [Web-Satis-Rapor], arraylist: brüt iskonto net net+kdv
        /// </summary>
        public static ArrayList GetToplamFiyatlar(ListItemCollection Urunler, int lic_si, string OzelKod, string FiyatTip, bool Bedelsizler, bool Iadeler,
            ArrayList Ozelkodlar, ArrayList Grupkodlar, DateTime BaslangicTarih, DateTime BitisTarih)
        {
            ArrayList donendeger = new ArrayList();

            string suzme = string.Empty;
            if (Urunler.Count > 1 && lic_si == 0) // tümü seçiminden başka ürün varsa, yoksa zaten bu arama kriterine gerek yok
            {
                string Urun = string.Empty;
                for (int i = 0; i < Urunler.Count; i++)
                    Urun += "ITEMREF = " + Urunler[i].Value + " OR ";
                if (Urun != string.Empty)
                    suzme += " AND (" + Urun.Substring(0, Urun.Length - 4) + ")";
            }
            else if (Urunler.Count > 1)
            {
                suzme += " AND ITEMREF = " + Urunler[lic_si].Value;
            }
            if (OzelKod != string.Empty)
                suzme += " AND [GRP KOD] = '" + OzelKod + "'";
            if (FiyatTip != string.Empty)
                suzme += " AND [F TUR] = '" + FiyatTip + "'";
            if (Bedelsizler)
                suzme += " AND LT = 1";
            if (Iadeler)
                suzme += " AND TUR = 3";
            else
                suzme += " AND (TUR = 3 OR TUR = 8)";

            string tarih = " AND [FAT TAR] >= @BaslangicTarih AND [FAT TAR] <= @BitisTarih";

            string ozelkodlar = string.Empty;
            string grupkodlar = string.Empty;

            for (int i = 0; i < Ozelkodlar.Count; i++)
                ozelkodlar += "[GRP KOD] = '" + Ozelkodlar[i].ToString() + "' OR ";

            if (Ozelkodlar.Count > 0)
                ozelkodlar = " AND (" + ozelkodlar.Substring(0, ozelkodlar.Length - 4) + ") ";

            for (int i = 0; i < Grupkodlar.Count; i++)
                grupkodlar += "[ANA GRP] = '" + Grupkodlar[i].ToString() + "' OR ";

            if (Grupkodlar.Count > 0)
                grupkodlar = " AND (" + grupkodlar.Substring(0, grupkodlar.Length - 4) + ") ";

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT sum([BRUT T]),sum([ISK T]),sum([NET T]),sum([NET+KDV T]),sum([AD T]),sum([AD T] / KOLI) FROM [Web-Satis-Rapor] WHERE ITEMREF IS NOT NULL " + suzme + tarih + ozelkodlar + grupkodlar, conn);
                cmd.Parameters.Add("@BaslangicTarih", SqlDbType.SmallDateTime).Value = BaslangicTarih;
                cmd.Parameters.Add("@BitisTarih", SqlDbType.SmallDateTime).Value = BitisTarih;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        if (dr[0] != DBNull.Value)
                            donendeger.Add(Convert.ToDecimal(dr[0]));
                        else
                            donendeger.Add(0);
                        if (dr[1] != DBNull.Value)
                            donendeger.Add(Convert.ToDecimal(dr[1]));
                        else
                            donendeger.Add(0);
                        if (dr[2] != DBNull.Value)
                            donendeger.Add(Convert.ToDecimal(dr[2]));
                        else
                            donendeger.Add(0);
                        if (dr[3] != DBNull.Value)
                            donendeger.Add(Convert.ToDecimal(dr[3]));
                        else
                            donendeger.Add(0);
                        if (dr[4] != DBNull.Value)
                            donendeger.Add(Convert.ToInt32(dr[4]));
                        else
                            donendeger.Add(0);
                        if (dr[5] != DBNull.Value)
                            donendeger.Add(Convert.ToInt32(dr[5]));
                        else
                            donendeger.Add(0);
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

            if (donendeger.Count == 0)
                donendeger.Add(0); donendeger.Add(0); donendeger.Add(0); donendeger.Add(0); donendeger.Add(0);

            return donendeger;
        }
        //
        //
        #endregion








        /// <summary>
        /// [Web-Satis-Rapor]
        /// </summary>
        public static void GetObjectsBySLSREF(DataTable dt, int SLSREF)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT [LT],[BOLGE],[GRP],[EKP],[ABR NO],[AMBAR],[AY],[HAFTA],[FAT TAR],[FAT NO],[FAT VD],[TUR],[TUR ACK],[F TUR],[SLSREF],[SAT KOD],[SAT TEM],[TED EKP],[TED SAT TEM],[IL],[ILCE],[MT ACIKLAMA],[GMREF],[MUS KOD],[MUSTERI],[SMREF],[SUB KOD],[SUBE],[SEVK KOD],[SEVK ADRES],[REY KOD],[REYON],[ANA GRP],[GRP KOD],[GRUP],[TED GRP],[TED KISA MAL],[BARCODE],[MAL KOD],[URT KOD],[MALZEME],[KOLI],[KDV],[BRM],[AD T],[BRUT T],[ISK T],[NET T],[KDV T],[NET+KDV T] FROM [Web-Satis-Rapor] WHERE SLSREF = @SLSREF", conn);
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
        /// <summary>
        /// [Web-Satis-Rapor]
        /// </summary>
        public static int GetProductCountByGMREF(int GMREF, short FiyatTipi, ArrayList Ozelkodlar, ArrayList Grupkodlar)
        {
            int donendeger = 0;

            string ozelkodlar = string.Empty;
            string grupkodlar = string.Empty;

            for (int i = 0; i < Ozelkodlar.Count; i++)
                ozelkodlar += "[Web-Malzeme].[OZEL KOD] = '" + Ozelkodlar[i].ToString() + "' OR ";

            if (Ozelkodlar.Count > 0)
                ozelkodlar = " AND (" + ozelkodlar.Substring(0, ozelkodlar.Length - 4) + ") ";

            for (int i = 0; i < Grupkodlar.Count; i++)
                grupkodlar += "[Web-Malzeme].[GRUP KOD] = '" + Grupkodlar[i].ToString() + "' OR ";

            if (Grupkodlar.Count > 0)
                grupkodlar = " AND (" + grupkodlar.Substring(0, grupkodlar.Length - 4) + ") ";

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT count(DISTINCT [Web-Satis-Rapor].[ITEMREF]) FROM [Web-Satis-Rapor] INNER JOIN [Web-Malzeme] ON [Web-Satis-Rapor].[ITEMREF] = [Web-Malzeme].[ITEMREF] INNER JOIN [Web-Fiyat] ON [Web-Satis-Rapor].[ITEMREF] = [Web-Fiyat].[ITEMREF] WHERE [Web-Satis-Rapor].[LT] = 0 AND [Web-Satis-Rapor].[TUR] = 8 AND [Web-Satis-Rapor].GMREF = @GMREF /*AND [Web-Satis-Rapor].[F TUR] = @FiyatTipi*/ AND YIL >= 2017 AND ([Web-Malzeme].[OZEL KOD] = 'T1' OR [Web-Malzeme].[OZEL KOD] = 'T2' OR [Web-Malzeme].[OZEL KOD] = 'T3' OR [Web-Malzeme].[OZEL KOD] = 'T4') " + ozelkodlar + grupkodlar, conn);
                cmd.Parameters.Add("@GMREF", SqlDbType.Int).Value = GMREF;
                cmd.Parameters.Add("@FiyatTipi", SqlDbType.SmallInt).Value = FiyatTipi;
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
        /// [Web-Satis-Rapor]
        /// </summary>
        public static void GetProductsByGMREF(DataTable dt, int Baslangic, int Miktar, int GMREF, short FiyatTipi, ArrayList Ozelkodlar, ArrayList Grupkodlar)
        {
            string ozelkodlar = string.Empty;
            string grupkodlar = string.Empty;

            for (int i = 0; i < Ozelkodlar.Count; i++)
                ozelkodlar += "[Web-Malzeme].[OZEL KOD] = '" + Ozelkodlar[i].ToString() + "' OR ";

            if (Ozelkodlar.Count > 0)
                ozelkodlar = " AND (" + ozelkodlar.Substring(0, ozelkodlar.Length - 4) + ") ";

            for (int i = 0; i < Grupkodlar.Count; i++)
                grupkodlar += "[Web-Malzeme].[GRUP KOD] = '" + Grupkodlar[i].ToString() + "' OR ";

            if (Grupkodlar.Count > 0)
                grupkodlar = " AND (" + grupkodlar.Substring(0, grupkodlar.Length - 4) + ") ";

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                //SqlDataAdapter da = new SqlDataAdapter("SELECT DISTINCT [Web-Satis-Rapor].[ITEMREF],[Web-Malzeme].[BARKOD],[Web-Malzeme].[MAL ACIK] AS Ad,[Web-Satis-Rapor].[KOLI],sum([Web-Satis-Rapor].[AD T]) AS Adet,(SELECT [NET+KDV] FROM [Web-Fiyat] WHERE ITEMREF = [Web-Satis-Rapor].[ITEMREF] AND TIP = @FiyatTipi) AS BirimFiyat,(SELECT max([FAT TAR]) FROM [Web-Satis-Rapor] AS TABLO1 WHERE [LT] = 0 AND [TUR] = 8 AND GMREF = @GMREF AND [F TUR] = @FiyatTipi AND YIL >= 2014 AND ITEMREF = [Web-Satis-Rapor].[ITEMREF]) AS MaxFATTAR,(SELECT TOP 1 [NET+KDV T] / [AD T] FROM [Web-Satis-Rapor] AS TABLO1 WHERE [LT] = 0 AND [TUR] = 8 AND GMREF = @GMREF AND [F TUR] = @FiyatTipi AND YIL >= 2014 AND ITEMREF = [Web-Satis-Rapor].[ITEMREF] ORDER BY [FAT TAR] DESC) AS lastNETKDV,[Web-Satis-Rapor].[F TUR] AS Ftur,'False' AS Secili FROM [Web-Satis-Rapor] INNER JOIN [Web-Malzeme] ON [Web-Satis-Rapor].[ITEMREF] = [Web-Malzeme].[ITEMREF] WHERE [Web-Satis-Rapor].[LT] = 0 AND [Web-Satis-Rapor].[TUR] = 8 AND [Web-Satis-Rapor].GMREF = @GMREF AND [Web-Satis-Rapor].[F TUR] = @FiyatTipi AND YIL >= 2014 AND ([Web-Malzeme].[OZEL KOD] = 'T1' OR [Web-Malzeme].[OZEL KOD] = 'T2' OR [Web-Malzeme].[OZEL KOD] = 'T3' OR [Web-Malzeme].[OZEL KOD] = 'T4') " + ozelkodlar + grupkodlar + " GROUP BY [Web-Satis-Rapor].[ITEMREF],[Web-Malzeme].[BARKOD],[Web-Malzeme].[MAL ACIK],[Web-Satis-Rapor].[KOLI],[Web-Satis-Rapor].[F TUR] ORDER BY Ad", conn);
                SqlDataAdapter da = new SqlDataAdapter("SELECT DISTINCT [Web-Satis-Rapor].[ITEMREF],[Web-Malzeme].[BARKOD],[Web-Malzeme].[MAL ACIK] AS Ad,[Web-Satis-Rapor].[KOLI],sum([Web-Satis-Rapor].[AD T]) AS Adet,/*-(SELECT [NET+KDV] FROM [Web-Fiyat] WHERE ITEMREF = [Web-Satis-Rapor].[ITEMREF] AND TIP = [Web-Satis-Rapor].[F TUR]) AS BirimFiyat,*/max(TABLO1.[FAT TAR]) AS MaxFATTAR,max(TABLO1.[NET+KDV T] / TABLO1.[AD T]) AS lastNETKDV,/*[Web-Satis-Rapor].[F TUR] AS Ftur,*/'False' AS Secili FROM [Web-Satis-Rapor] INNER JOIN [Web-Malzeme] ON [Web-Satis-Rapor].[ITEMREF] = [Web-Malzeme].[ITEMREF] INNER JOIN [Web-Satis-Rapor] AS TABLO1 ON [Web-Satis-Rapor].[ITEMREF] = TABLO1.ITEMREF AND [Web-Satis-Rapor].SMREF = TABLO1.SMREF AND [Web-Satis-Rapor].[F TUR] = TABLO1.[F TUR] WHERE [Web-Satis-Rapor].[LT] = 0 AND [Web-Satis-Rapor].[TUR] = 8 AND [Web-Satis-Rapor].GMREF = @GMREF /*AND [Web-Satis-Rapor].[F TUR] = @FiyatTipi*/ AND [Web-Satis-Rapor].YIL >= 2017 AND ([Web-Malzeme].[OZEL KOD] = 'T1' OR [Web-Malzeme].[OZEL KOD] = 'T2' OR [Web-Malzeme].[OZEL KOD] = 'T3' OR [Web-Malzeme].[OZEL KOD] = 'T4') GROUP BY [Web-Satis-Rapor].[ITEMREF],[Web-Malzeme].[BARKOD],[Web-Malzeme].[MAL ACIK],[Web-Satis-Rapor].[KOLI]/*,[Web-Satis-Rapor].[F TUR]*/ ORDER BY Ad", conn);
                da.SelectCommand.Parameters.Add("@GMREF", SqlDbType.Int).Value = GMREF;
                da.SelectCommand.Parameters.Add("@FiyatTipi", SqlDbType.SmallInt).Value = FiyatTipi;
                try
                {
                    conn.Open();
                    da.Fill(Baslangic, Miktar, dt);
                }
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
        /// [Web-Satis-Rapor]
        /// </summary>
        public static int GetProductCountBySMREF(int SMREF, short FiyatTipi, ArrayList Ozelkodlar, ArrayList Grupkodlar)
        {
            int donendeger = 0;

            string ozelkodlar = string.Empty;
            string grupkodlar = string.Empty;

            for (int i = 0; i < Ozelkodlar.Count; i++)
                ozelkodlar += "[Web-Malzeme].[OZEL KOD] = '" + Ozelkodlar[i].ToString() + "' OR ";

            if (Ozelkodlar.Count > 0)
                ozelkodlar = " AND (" + ozelkodlar.Substring(0, ozelkodlar.Length - 4) + ") ";

            for (int i = 0; i < Grupkodlar.Count; i++)
                grupkodlar += "[Web-Malzeme].[GRUP KOD] = '" + Grupkodlar[i].ToString() + "' OR ";

            if (Grupkodlar.Count > 0)
                grupkodlar = " AND (" + grupkodlar.Substring(0, grupkodlar.Length - 4) + ") ";

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT count(DISTINCT [Web-Satis-Rapor].[ITEMREF]) FROM [Web-Satis-Rapor] INNER JOIN [Web-Malzeme] ON [Web-Satis-Rapor].[ITEMREF] = [Web-Malzeme].[ITEMREF] INNER JOIN [Web-Fiyat] ON [Web-Satis-Rapor].[ITEMREF] = [Web-Fiyat].[ITEMREF] WHERE [Web-Satis-Rapor].[LT] = 0 AND [Web-Satis-Rapor].[TUR] = 8 AND [Web-Satis-Rapor].SMREF = @SMREF /*AND [Web-Satis-Rapor].[F TUR] = @FiyatTipi */AND YIL >= 2017 AND ([Web-Malzeme].[OZEL KOD] = 'T1' OR [Web-Malzeme].[OZEL KOD] = 'T2' OR [Web-Malzeme].[OZEL KOD] = 'T3' OR [Web-Malzeme].[OZEL KOD] = 'T4') " + ozelkodlar + grupkodlar, conn);
                cmd.Parameters.Add("@SMREF", SqlDbType.Int).Value = SMREF;
                cmd.Parameters.Add("@FiyatTipi", SqlDbType.SmallInt).Value = FiyatTipi;
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
        /// [Web-Satis-Rapor]
        /// </summary>
        public static void GetProductsBySMREF(DataTable dt, int Baslangic, int Miktar, int SMREF, short FiyatTipi, ArrayList Ozelkodlar, ArrayList Grupkodlar)
        {
            string ozelkodlar = string.Empty;
            string grupkodlar = string.Empty;

            for (int i = 0; i < Ozelkodlar.Count; i++)
                ozelkodlar += "[Web-Malzeme].[OZEL KOD] = '" + Ozelkodlar[i].ToString() + "' OR ";

            if (Ozelkodlar.Count > 0)
                ozelkodlar = " AND (" + ozelkodlar.Substring(0, ozelkodlar.Length - 4) + ") ";

            for (int i = 0; i < Grupkodlar.Count; i++)
                grupkodlar += "[Web-Malzeme].[GRUP KOD] = '" + Grupkodlar[i].ToString() + "' OR ";

            if (Grupkodlar.Count > 0)
                grupkodlar = " AND (" + grupkodlar.Substring(0, grupkodlar.Length - 4) + ") ";

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                //SqlDataAdapter da = new SqlDataAdapter("SELECT DISTINCT [Web-Satis-Rapor].[ITEMREF],[Web-Malzeme].[BARKOD],[Web-Malzeme].[MAL ACIK] AS Ad,[Web-Satis-Rapor].[KOLI],sum([Web-Satis-Rapor].[AD T]) AS Adet,(SELECT [NET+KDV] FROM [Web-Fiyat] WHERE ITEMREF = [Web-Satis-Rapor].[ITEMREF] AND TIP = @FiyatTipi) AS BirimFiyat,(SELECT max([FAT TAR]) FROM [Web-Satis-Rapor] AS TABLO1 WHERE [LT] = 0 AND [TUR] = 8 AND SMREF = @SMREF AND [F TUR] = @FiyatTipi AND YIL >= 2014 AND ITEMREF = [Web-Satis-Rapor].[ITEMREF]) AS MaxFATTAR,(SELECT TOP 1 [NET+KDV T] / [AD T] FROM [Web-Satis-Rapor] AS TABLO1 WHERE [LT] = 0 AND [TUR] = 8 AND SMREF = @SMREF AND [F TUR] = @FiyatTipi AND YIL >= 2014 AND ITEMREF = [Web-Satis-Rapor].[ITEMREF] ORDER BY [FAT TAR] DESC) AS lastNETKDV,[Web-Satis-Rapor].[F TUR] AS Ftur,'False' AS Secili FROM [Web-Satis-Rapor] INNER JOIN [Web-Malzeme] ON [Web-Satis-Rapor].[ITEMREF] = [Web-Malzeme].[ITEMREF] WHERE [Web-Satis-Rapor].[LT] = 0 AND [Web-Satis-Rapor].[TUR] = 8 AND [Web-Satis-Rapor].SMREF = @SMREF AND [Web-Satis-Rapor].[F TUR] = @FiyatTipi AND YIL >= 2014 AND ([Web-Malzeme].[OZEL KOD] = 'T1' OR [Web-Malzeme].[OZEL KOD] = 'T2' OR [Web-Malzeme].[OZEL KOD] = 'T3' OR [Web-Malzeme].[OZEL KOD] = 'T4') " + ozelkodlar + grupkodlar + " GROUP BY [Web-Satis-Rapor].[ITEMREF],[Web-Malzeme].[BARKOD],[Web-Malzeme].[MAL ACIK],[Web-Satis-Rapor].[KOLI],[Web-Satis-Rapor].[F TUR] ORDER BY Ad", conn);
                SqlDataAdapter da = new SqlDataAdapter("SELECT DISTINCT [Web-Satis-Rapor].[ITEMREF],[Web-Malzeme].[BARKOD],[Web-Malzeme].[MAL ACIK] AS Ad,[Web-Satis-Rapor].[KOLI],sum([Web-Satis-Rapor].[AD T]) AS Adet,/*(SELECT [NET+KDV] FROM [Web-Fiyat] WHERE ITEMREF = [Web-Satis-Rapor].[ITEMREF] AND TIP = @FiyatTipi) AS BirimFiyat,*/max(TABLO1.[FAT TAR]) AS MaxFATTAR,max(TABLO1.[NET+KDV T] / TABLO1.[AD T]) AS lastNETKDV,/*[Web-Satis-Rapor].[F TUR] AS Ftur,*/'False' AS Secili FROM [Web-Satis-Rapor] INNER JOIN [Web-Malzeme] ON [Web-Satis-Rapor].[ITEMREF] = [Web-Malzeme].[ITEMREF] INNER JOIN [Web-Satis-Rapor] AS TABLO1 ON [Web-Satis-Rapor].[ITEMREF] = TABLO1.ITEMREF AND [Web-Satis-Rapor].SMREF = TABLO1.SMREF AND [Web-Satis-Rapor].[F TUR] = TABLO1.[F TUR] WHERE [Web-Satis-Rapor].[LT] = 0 AND [Web-Satis-Rapor].[TUR] = 8 AND [Web-Satis-Rapor].SMREF = @SMREF /*AND [Web-Satis-Rapor].[F TUR] = @FiyatTipi */AND [Web-Satis-Rapor].YIL >= 2017 AND ([Web-Malzeme].[OZEL KOD] = 'T1' OR [Web-Malzeme].[OZEL KOD] = 'T2' OR [Web-Malzeme].[OZEL KOD] = 'T3' OR [Web-Malzeme].[OZEL KOD] = 'T4') GROUP BY [Web-Satis-Rapor].[ITEMREF],[Web-Malzeme].[BARKOD],[Web-Malzeme].[MAL ACIK],[Web-Satis-Rapor].[KOLI]/*,[Web-Satis-Rapor].[F TUR]*/ ORDER BY Ad", conn);
                da.SelectCommand.Parameters.Add("@SMREF", SqlDbType.Int).Value = SMREF;
                da.SelectCommand.Parameters.Add("@FiyatTipi", SqlDbType.SmallInt).Value = FiyatTipi;
                try
                {
                    conn.Open();
                    da.Fill(Baslangic, Miktar, dt);
                }
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
        /// [Web-Satis-Rapor] 
        /// </summary>
        public static DateTime GetLastFATTAR()
        {
            DateTime donendeger = DateTime.MinValue;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT TOP 1 [FAT TAR] FROM [Web-Satis-Rapor] ORDER BY [FAT TAR] DESC", conn);
                try
                {
                    conn.Open();
                    donendeger = Convert.ToDateTime(cmd.ExecuteScalar());
                }
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

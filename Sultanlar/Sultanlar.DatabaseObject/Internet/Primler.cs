using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Sultanlar.DatabaseObject.Internet
{
    public class Primler
    {
        #region CariTip
        /// <summary>
        /// SELECT SUL_Cari_Tip
        /// </summary>
        public static void GetObjectsCariTip(DataTable dt)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT [MT_KOD],[MT_ACIKLAMA],[PRM_TAH],[PRM_SAT],[PRM_NOK],[PRM_4],[PRM_5] FROM [SUL_Cari_Tip] ORDER BY [MT_ACIKLAMA]", conn);
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
        /// UPDATE SUL_Cari_Tip
        /// </summary>
        //public static void SetCariTip(string MT_KOD, double PRM_TAH, double PRM_SAT, double PRM_NOK, double PRM_4, double PRM_5)
        //{
        //    using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3sa))
        //    {
        //        SqlCommand cmd = new SqlCommand("UPDATE [SUL_Cari_Tip] SET [PRM_TAH]=@PRM_TAH,[PRM_SAT]=@PRM_SAT,[PRM_NOK]=@PRM_NOK,[PRM_4]=@PRM_4,[PRM_5]=@PRM_5 WHERE MT_KOD = @MT_KOD AND [ONC1]=1", conn);
        //        SqlCommand cmd2 = new SqlCommand("UPDATE [SUL_MTBII_Kod] SET [PRM_TAH]=@PRM_TAH,[PRM_SAT]=@PRM_SAT,[PRM_NOK]=@PRM_NOK,[PRM_4]=@PRM_4,[PRM_5]=@PRM_5 WHERE MT_KOD = @MT_KOD AND [ONC1]=1", conn);
        //        SqlCommand cmd3 = new SqlCommand("UPDATE [SUL_Sat_Tem] SET [SUL_Sat_Tem].[PRM_TAH]=@PRM_TAH,[SUL_Sat_Tem].[PRM_SAT]=@PRM_SAT,[SUL_Sat_Tem].[PRM_NOK]=@PRM_NOK,[SUL_Sat_Tem].[PRM_4]=@PRM_4,[SUL_Sat_Tem].[PRM_5]=@PRM_5 FROM [SUL_Sat_Tem] INNER JOIN [SUL_C_H] ON [SUL_Sat_Tem].[SLSREF] = [SUL_C_H].[SLSREF] WHERE [SUL_C_H].[MT_KOD] = @MT_KOD AND [SUL_Sat_Tem].[ONC1]=1", conn);
        //        SqlCommand cmd4 = new SqlCommand("UPDATE [SUL_C_H] SET [PRM_TAH]=@PRM_TAH,[PRM_SAT]=@PRM_SAT,[PRM_NOK]=@PRM_NOK,[PRM_4]=@PRM_4,[PRM_5]=@PRM_5 WHERE MT_KOD = @MT_KOD AND [ONC1]=1", conn);

        //        cmd.Parameters.Add("@PRM_TAH", SqlDbType.Float).Value = PRM_TAH;
        //        cmd.Parameters.Add("@PRM_SAT", SqlDbType.Float).Value = PRM_SAT;
        //        cmd.Parameters.Add("@PRM_NOK", SqlDbType.Float).Value = PRM_NOK;
        //        cmd.Parameters.Add("@PRM_4", SqlDbType.Float).Value = PRM_4;
        //        cmd.Parameters.Add("@PRM_5", SqlDbType.Float).Value = PRM_5;
        //        cmd.Parameters.Add("@MT_KOD", SqlDbType.VarChar, 25).Value = MT_KOD;
        //        try
        //        {
        //            conn.Open();
        //            cmd.ExecuteNonQuery();
        //            cmd2.ExecuteNonQuery();
        //            cmd3.ExecuteNonQuery();
        //            cmd4.ExecuteNonQuery();
        //        }
        //        catch (SqlException ex)
        //        {
        //            Hatalar.DoInsert(ex);
        //        }
        //        finally
        //        {
        //            conn.Close();
        //        }
        //    }
        //}
        /// <summary>
        /// SET Tahsilat
        /// </summary>
        public static void SetCariTipTah(string MT_KOD, double PRM_TAH)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3sa))
            {
                SqlCommand cmd = new SqlCommand("UPDATE [SUL_Cari_Tip] SET [PRM_TAH]=@PRM_TAH WHERE MT_KOD = @MT_KOD", conn);
                SqlCommand cmd2 = new SqlCommand("UPDATE [SUL_MTBII_Kod] SET [PRM_TAH]=@PRM_TAH WHERE MT_KOD = @MT_KOD AND [ONC1]=1", conn);
                //SqlCommand cmd3 = new SqlCommand("UPDATE [SUL_Sat_Tem] SET [SUL_Sat_Tem].[PRM_TAH]=@PRM_TAH FROM [SUL_Sat_Tem] INNER JOIN [SUL_C_H] ON [SUL_Sat_Tem].[SLSREF] = [SUL_C_H].[SLSREF] WHERE [SUL_C_H].[MT_KOD] = @MT_KOD AND [SUL_Sat_Tem].[ONC1]=1", conn);
                SqlCommand cmd4 = new SqlCommand("UPDATE [SUL_C_H] SET [PRM_TAH]=@PRM_TAH WHERE MT_KOD = @MT_KOD AND [ONC1]=1", conn);

                cmd.Parameters.Add("@PRM_TAH", SqlDbType.Float).Value = PRM_TAH;
                cmd.Parameters.Add("@MT_KOD", SqlDbType.VarChar, 25).Value = MT_KOD;
                cmd2.Parameters.Add("@PRM_TAH", SqlDbType.Float).Value = PRM_TAH;
                cmd2.Parameters.Add("@MT_KOD", SqlDbType.VarChar, 25).Value = MT_KOD;
                //cmd3.Parameters.Add("@PRM_TAH", SqlDbType.Float).Value = PRM_TAH;
                //cmd3.Parameters.Add("@MT_KOD", SqlDbType.VarChar, 25).Value = MT_KOD;
                cmd4.Parameters.Add("@PRM_TAH", SqlDbType.Float).Value = PRM_TAH;
                cmd4.Parameters.Add("@MT_KOD", SqlDbType.VarChar, 25).Value = MT_KOD;

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    cmd2.ExecuteNonQuery();
                    //cmd3.ExecuteNonQuery();
                    cmd4.ExecuteNonQuery();
                }
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
        /// SET Satış
        /// </summary>
        public static void SetCariTipSat(string MT_KOD, double PRM_SAT)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3sa))
            {
                SqlCommand cmd = new SqlCommand("UPDATE [SUL_Cari_Tip] SET [PRM_SAT]=@PRM_SAT WHERE MT_KOD = @MT_KOD", conn);
                SqlCommand cmd2 = new SqlCommand("UPDATE [SUL_MTBII_Kod] SET [PRM_SAT]=@PRM_SAT WHERE MT_KOD = @MT_KOD AND [ONC2]=1", conn);
                //SqlCommand cmd3 = new SqlCommand("UPDATE [SUL_Sat_Tem] SET [SUL_Sat_Tem].[PRM_SAT]=@PRM_SAT FROM [SUL_Sat_Tem] INNER JOIN [SUL_C_H] ON [SUL_Sat_Tem].[SLSREF] = [SUL_C_H].[SLSREF] WHERE [SUL_C_H].[MT_KOD] = @MT_KOD AND [SUL_Sat_Tem].[ONC2]=1", conn);
                SqlCommand cmd4 = new SqlCommand("UPDATE [SUL_C_H] SET [PRM_SAT]=@PRM_SAT WHERE MT_KOD = @MT_KOD AND [ONC2]=1", conn);

                cmd.Parameters.Add("@PRM_SAT", SqlDbType.Float).Value = PRM_SAT;
                cmd.Parameters.Add("@MT_KOD", SqlDbType.VarChar, 25).Value = MT_KOD;
                cmd2.Parameters.Add("@PRM_SAT", SqlDbType.Float).Value = PRM_SAT;
                cmd2.Parameters.Add("@MT_KOD", SqlDbType.VarChar, 25).Value = MT_KOD;
                //cmd3.Parameters.Add("@PRM_SAT", SqlDbType.Float).Value = PRM_SAT;
                //cmd3.Parameters.Add("@MT_KOD", SqlDbType.VarChar, 25).Value = MT_KOD;
                cmd4.Parameters.Add("@PRM_SAT", SqlDbType.Float).Value = PRM_SAT;
                cmd4.Parameters.Add("@MT_KOD", SqlDbType.VarChar, 25).Value = MT_KOD;

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    cmd2.ExecuteNonQuery();
                    //cmd3.ExecuteNonQuery();
                    cmd4.ExecuteNonQuery();
                }
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
        /// SET Nokta
        /// </summary>
        public static void SetCariTipNok(string MT_KOD, double PRM_NOK)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3sa))
            {
                SqlCommand cmd = new SqlCommand("UPDATE [SUL_Cari_Tip] SET [PRM_NOK]=@PRM_NOK WHERE MT_KOD = @MT_KOD", conn);
                SqlCommand cmd2 = new SqlCommand("UPDATE [SUL_MTBII_Kod] SET [PRM_NOK]=@PRM_NOK WHERE MT_KOD = @MT_KOD AND [ONC3]=1", conn);
                //SqlCommand cmd3 = new SqlCommand("UPDATE [SUL_Sat_Tem] SET [SUL_Sat_Tem].[PRM_NOK]=@PRM_NOK FROM [SUL_Sat_Tem] INNER JOIN [SUL_C_H] ON [SUL_Sat_Tem].[SLSREF] = [SUL_C_H].[SLSREF] WHERE [SUL_C_H].[MT_KOD] = @MT_KOD AND [SUL_Sat_Tem].[ONC3]=1", conn);
                SqlCommand cmd4 = new SqlCommand("UPDATE [SUL_C_H] SET [PRM_NOK]=@PRM_NOK WHERE MT_KOD = @MT_KOD AND [ONC3]=1", conn);

                cmd.Parameters.Add("@PRM_NOK", SqlDbType.Float).Value = PRM_NOK;
                cmd.Parameters.Add("@MT_KOD", SqlDbType.VarChar, 25).Value = MT_KOD;
                cmd2.Parameters.Add("@PRM_NOK", SqlDbType.Float).Value = PRM_NOK;
                cmd2.Parameters.Add("@MT_KOD", SqlDbType.VarChar, 25).Value = MT_KOD;
                //cmd3.Parameters.Add("@PRM_NOK", SqlDbType.Float).Value = PRM_NOK;
                //cmd3.Parameters.Add("@MT_KOD", SqlDbType.VarChar, 25).Value = MT_KOD;
                cmd4.Parameters.Add("@PRM_NOK", SqlDbType.Float).Value = PRM_NOK;
                cmd4.Parameters.Add("@MT_KOD", SqlDbType.VarChar, 25).Value = MT_KOD;

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    cmd2.ExecuteNonQuery();
                    //cmd3.ExecuteNonQuery();
                    cmd4.ExecuteNonQuery();
                }
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
        /// SET Prim 4
        /// </summary>
        public static void SetCariTip4(string MT_KOD, double PRM_4)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3sa))
            {
                SqlCommand cmd = new SqlCommand("UPDATE [SUL_Cari_Tip] SET [PRM_4]=@PRM_4 WHERE MT_KOD = @MT_KOD", conn);
                SqlCommand cmd2 = new SqlCommand("UPDATE [SUL_MTBII_Kod] SET [PRM_4]=@PRM_4 WHERE MT_KOD = @MT_KOD AND [ONC4]=1", conn);
                //SqlCommand cmd3 = new SqlCommand("UPDATE [SUL_Sat_Tem] SET [SUL_Sat_Tem].[PRM_4]=@PRM_4 FROM [SUL_Sat_Tem] INNER JOIN [SUL_C_H] ON [SUL_Sat_Tem].[SLSREF] = [SUL_C_H].[SLSREF] WHERE [SUL_C_H].[MT_KOD] = @MT_KOD AND [SUL_Sat_Tem].[ONC4]=1", conn);
                SqlCommand cmd4 = new SqlCommand("UPDATE [SUL_C_H] SET [PRM_4]=@PRM_4 WHERE MT_KOD = @MT_KOD AND [ONC4]=1", conn);

                cmd.Parameters.Add("@PRM_4", SqlDbType.Float).Value = PRM_4;
                cmd.Parameters.Add("@MT_KOD", SqlDbType.VarChar, 25).Value = MT_KOD;
                cmd2.Parameters.Add("@PRM_4", SqlDbType.Float).Value = PRM_4;
                cmd2.Parameters.Add("@MT_KOD", SqlDbType.VarChar, 25).Value = MT_KOD;
                //cmd3.Parameters.Add("@PRM_4", SqlDbType.Float).Value = PRM_4;
                //cmd3.Parameters.Add("@MT_KOD", SqlDbType.VarChar, 25).Value = MT_KOD;
                cmd4.Parameters.Add("@PRM_4", SqlDbType.Float).Value = PRM_4;
                cmd4.Parameters.Add("@MT_KOD", SqlDbType.VarChar, 25).Value = MT_KOD;

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    cmd2.ExecuteNonQuery();
                    //cmd3.ExecuteNonQuery();
                    cmd4.ExecuteNonQuery();
                }
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
        /// SET Prim 5
        /// </summary>
        public static void SetCariTip5(string MT_KOD, double PRM_5)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3sa))
            {
                SqlCommand cmd = new SqlCommand("UPDATE [SUL_Cari_Tip] SET [PRM_5]=@PRM_5 WHERE MT_KOD = @MT_KOD", conn);
                SqlCommand cmd2 = new SqlCommand("UPDATE [SUL_MTBII_Kod] SET [PRM_5]=@PRM_5 WHERE MT_KOD = @MT_KOD AND [ONC5]=1", conn);
                //SqlCommand cmd3 = new SqlCommand("UPDATE [SUL_Sat_Tem] SET [SUL_Sat_Tem].[PRM_5]=@PRM_5 FROM [SUL_Sat_Tem] INNER JOIN [SUL_C_H] ON [SUL_Sat_Tem].[SLSREF] = [SUL_C_H].[SLSREF] WHERE [SUL_C_H].[MT_KOD] = @MT_KOD AND [SUL_Sat_Tem].[ONC5]=1", conn);
                SqlCommand cmd4 = new SqlCommand("UPDATE [SUL_C_H] SET [PRM_5]=@PRM_5 WHERE MT_KOD = @MT_KOD AND [ONC5]=1", conn);

                cmd.Parameters.Add("@PRM_5", SqlDbType.Float).Value = PRM_5;
                cmd.Parameters.Add("@MT_KOD", SqlDbType.VarChar, 25).Value = MT_KOD;
                cmd2.Parameters.Add("@PRM_5", SqlDbType.Float).Value = PRM_5;
                cmd2.Parameters.Add("@MT_KOD", SqlDbType.VarChar, 25).Value = MT_KOD;
                //cmd3.Parameters.Add("@PRM_5", SqlDbType.Float).Value = PRM_5;
                //cmd3.Parameters.Add("@MT_KOD", SqlDbType.VarChar, 25).Value = MT_KOD;
                cmd4.Parameters.Add("@PRM_5", SqlDbType.Float).Value = PRM_5;
                cmd4.Parameters.Add("@MT_KOD", SqlDbType.VarChar, 25).Value = MT_KOD;

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    cmd2.ExecuteNonQuery();
                    //cmd3.ExecuteNonQuery();
                    cmd4.ExecuteNonQuery();
                }
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
        #region Cari Tip Bölge
        /// <summary>
        /// SELECT SUL_MTBII_Kod
        /// </summary>
        public static void GetObjectsMTBIIKod(DataTable dt)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT [MTBII_KOD],[MT_KOD],[MT_ACIKLAMA],[BII_KOD],[B_KOD],[BOLGE],[BOLGE_TANIM],[IL_KOD],[IL],[ILC_KOD],[ILCE],[ONC1],[PRM_TAH],[ONC2],[PRM_SAT],[ONC3],[PRM_NOK],[ONC4],[PRM_4],[ONC5],[PRM_5] FROM [SUL_MTBII_Kod] ORDER BY [MT_ACIKLAMA],[BOLGE],[IL],[ILCE]", conn);
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
        /// UPDATE SUL_MTBII_Kod By CariTip
        /// </summary>
        public static void SetMTBIIKodByCariTip(string MT_KOD, double PRM_TAH, double PRM_SAT, double PRM_NOK, double PRM_4, double PRM_5)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3sa))
            {
                SqlCommand cmd = new SqlCommand("UPDATE [SUL_MTBII_Kod] SET [PRM_TAH]=@PRM_TAH WHERE [MT_KOD]=@MT_KOD AND [ONC1]=1", conn);
                SqlCommand cmd2 = new SqlCommand("UPDATE [SUL_MTBII_Kod] SET [PRM_SAT]=@PRM_SAT WHERE [MT_KOD]=@MT_KOD AND [ONC2]=1", conn);
                SqlCommand cmd3 = new SqlCommand("UPDATE [SUL_MTBII_Kod] SET [PRM_NOK]=@PRM_NOK WHERE [MT_KOD]=@MT_KOD AND [ONC3]=1", conn);
                SqlCommand cmd4 = new SqlCommand("UPDATE [SUL_MTBII_Kod] SET [PRM_4]=@PRM_4 WHERE [MT_KOD]=@MT_KOD AND [ONC4]=1", conn);
                SqlCommand cmd5 = new SqlCommand("UPDATE [SUL_MTBII_Kod] SET [PRM_5]=@PRM_5 WHERE [MT_KOD]=@MT_KOD AND [ONC5]=1", conn);

                cmd.Parameters.Add("@PRM_TAH", SqlDbType.Float).Value = PRM_TAH;
                cmd2.Parameters.Add("@PRM_SAT", SqlDbType.Float).Value = PRM_SAT;
                cmd3.Parameters.Add("@PRM_NOK", SqlDbType.Float).Value = PRM_NOK;
                cmd4.Parameters.Add("@PRM_4", SqlDbType.Float).Value = PRM_4;
                cmd5.Parameters.Add("@PRM_5", SqlDbType.Float).Value = PRM_5;
                cmd.Parameters.Add("@MT_KOD", SqlDbType.VarChar, 25).Value = MT_KOD;
                cmd2.Parameters.Add("@MT_KOD", SqlDbType.VarChar, 25).Value = MT_KOD;
                cmd3.Parameters.Add("@MT_KOD", SqlDbType.VarChar, 25).Value = MT_KOD;
                cmd4.Parameters.Add("@MT_KOD", SqlDbType.VarChar, 25).Value = MT_KOD;
                cmd5.Parameters.Add("@MT_KOD", SqlDbType.VarChar, 25).Value = MT_KOD;

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    cmd2.ExecuteNonQuery();
                    cmd3.ExecuteNonQuery();
                    cmd4.ExecuteNonQuery();
                    cmd5.ExecuteNonQuery();
                }
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
        /// SET Tahsilat
        /// </summary>
        public static void SetMTBIIKodTah(string MTBII_KOD, double PRM_TAH)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3sa))
            {
                SqlCommand cmd = new SqlCommand("UPDATE [SUL_MTBII_Kod] SET [PRM_TAH]=@PRM_TAH WHERE MTBII_KOD = @MTBII_KOD", conn);
                SqlCommand cmd2 = new SqlCommand("UPDATE [SUL_C_H] SET [PRM_TAH]=@PRM_TAH WHERE MTBII_KOD = @MTBII_KOD AND [ONC1]=2", conn);

                cmd.Parameters.Add("@PRM_TAH", SqlDbType.Float).Value = PRM_TAH;
                cmd.Parameters.Add("@MTBII_KOD", SqlDbType.VarChar, 25).Value = MTBII_KOD;
                cmd2.Parameters.Add("@PRM_TAH", SqlDbType.Float).Value = PRM_TAH;
                cmd2.Parameters.Add("@MTBII_KOD", SqlDbType.VarChar, 25).Value = MTBII_KOD;

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
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
        /// SET Satış
        /// </summary>
        public static void SetMTBIIKodSat(string MTBII_KOD, double PRM_SAT)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3sa))
            {
                SqlCommand cmd = new SqlCommand("UPDATE [SUL_MTBII_Kod] SET [PRM_SAT]=@PRM_SAT WHERE MTBII_KOD = @MTBII_KOD", conn);
                SqlCommand cmd2 = new SqlCommand("UPDATE [SUL_C_H] SET [PRM_SAT]=@PRM_SAT WHERE MTBII_KOD = @MTBII_KOD AND [ONC2]=2", conn);

                cmd.Parameters.Add("@PRM_SAT", SqlDbType.Float).Value = PRM_SAT;
                cmd.Parameters.Add("@MTBII_KOD", SqlDbType.VarChar, 25).Value = MTBII_KOD;
                cmd2.Parameters.Add("@PRM_SAT", SqlDbType.Float).Value = PRM_SAT;
                cmd2.Parameters.Add("@MTBII_KOD", SqlDbType.VarChar, 25).Value = MTBII_KOD;

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
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
        /// SET Nokta
        /// </summary>
        public static void SetMTBIIKodNok(string MTBII_KOD, double PRM_NOK)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3sa))
            {
                SqlCommand cmd = new SqlCommand("UPDATE [SUL_MTBII_Kod] SET [PRM_NOK]=@PRM_NOK WHERE MTBII_KOD = @MTBII_KOD", conn);
                SqlCommand cmd2 = new SqlCommand("UPDATE [SUL_C_H] SET [PRM_NOK]=@PRM_NOK WHERE MTBII_KOD = @MTBII_KOD AND [ONC3]=2", conn);

                cmd.Parameters.Add("@PRM_NOK", SqlDbType.Float).Value = PRM_NOK;
                cmd.Parameters.Add("@MTBII_KOD", SqlDbType.VarChar, 25).Value = MTBII_KOD;
                cmd2.Parameters.Add("@PRM_NOK", SqlDbType.Float).Value = PRM_NOK;
                cmd2.Parameters.Add("@MTBII_KOD", SqlDbType.VarChar, 25).Value = MTBII_KOD;

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
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
        /// SET Prim 4
        /// </summary>
        public static void SetMTBIIKod4(string MTBII_KOD, double PRM_4)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3sa))
            {
                SqlCommand cmd = new SqlCommand("UPDATE [SUL_MTBII_Kod] SET [PRM_4]=@PRM_4 WHERE MTBII_KOD = @MTBII_KOD", conn);
                SqlCommand cmd2 = new SqlCommand("UPDATE [SUL_C_H] SET [PRM_4]=@PRM_4 WHERE MTBII_KOD = @MTBII_KOD AND [ONC4]=2", conn);

                cmd.Parameters.Add("@PRM_4", SqlDbType.Float).Value = PRM_4;
                cmd.Parameters.Add("@MTBII_KOD", SqlDbType.VarChar, 25).Value = MTBII_KOD;
                cmd2.Parameters.Add("@PRM_4", SqlDbType.Float).Value = PRM_4;
                cmd2.Parameters.Add("@MTBII_KOD", SqlDbType.VarChar, 25).Value = MTBII_KOD;

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
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
        /// SET Prim 5
        /// </summary>
        public static void SetMTBIIKod5(string MTBII_KOD, double PRM_5)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3sa))
            {
                SqlCommand cmd = new SqlCommand("UPDATE [SUL_MTBII_Kod] SET [PRM_5]=@PRM_5 WHERE MTBII_KOD = @MTBII_KOD", conn);
                SqlCommand cmd2 = new SqlCommand("UPDATE [SUL_C_H] SET [PRM_5]=@PRM_5 WHERE MTBII_KOD = @MTBII_KOD AND [ONC5]=2", conn);

                cmd.Parameters.Add("@PRM_5", SqlDbType.Float).Value = PRM_5;
                cmd.Parameters.Add("@MTBII_KOD", SqlDbType.VarChar, 25).Value = MTBII_KOD;
                cmd2.Parameters.Add("@PRM_5", SqlDbType.Float).Value = PRM_5;
                cmd2.Parameters.Add("@MTBII_KOD", SqlDbType.VarChar, 25).Value = MTBII_KOD;

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
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
        /// SET ONC, YER = 1,2,3,4,5
        /// </summary>
        public static void SetMTBIIKodONC(string MTBII_KOD, string YER, int ONC)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3sa))
            {
                SqlCommand cmd = new SqlCommand("UPDATE [SUL_MTBII_Kod] SET [ONC" + YER + "]=@ONC WHERE MTBII_KOD = @MTBII_KOD", conn);
                cmd.Parameters.Add("@ONC", SqlDbType.Int).Value = ONC;
                cmd.Parameters.Add("@MTBII_KOD", SqlDbType.VarChar, 25).Value = MTBII_KOD;
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
        #endregion
        #region Satış Temsilcisi
        /// <summary>
        /// SELECT SUL_Sat_Tem
        /// </summary>
        public static void GetObjectsSatTem(DataTable dt)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT [SLSREF],[A_P],[BLG],[GRP],[EKP],[SAT_KOD],[SAT_KOD1],[SAT_TEM],[ARC_CRP],[ONC1],[PRM_TAH],[ONC2],[PRM_SAT],[ONC3],[PRM_NOK],[ONC4],[PRM_4],[ONC5],[PRM_5] FROM [SUL_Sat_Tem] ORDER BY [SAT_TEM]", conn);
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
        /// UPDATE SUL_C_H By CariTip
        /// </summary>
        //public static void SetSatTemByCariTip(string MT_KOD, double PRM_TAH, double PRM_SAT, double PRM_NOK, double PRM_4, double PRM_5)
        //{
        //    using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3sa))
        //    {
        //        SqlCommand cmd = new SqlCommand("UPDATE [SUL_Sat_Tem] SET [SUL_Sat_Tem].[PRM_TAH]=@PRM_TAH FROM [SUL_Sat_Tem] INNER JOIN [SUL_C_H] ON [SUL_Sat_Tem].[SLSREF] = [SUL_C_H].[SLSREF] WHERE [SUL_C_H].[MT_KOD]=@MT_KOD AND [SUL_Sat_Tem].[ONC1]=1", conn);
        //        SqlCommand cmd2 = new SqlCommand("UPDATE [SUL_Sat_Tem] SET [SUL_Sat_Tem].[PRM_SAT]=@PRM_SAT FROM [SUL_Sat_Tem] INNER JOIN [SUL_C_H] ON [SUL_Sat_Tem].[SLSREF] = [SUL_C_H].[SLSREF] WHERE [SUL_C_H].[MT_KOD]=@MT_KOD AND [SUL_Sat_Tem].[ONC2]=1", conn);
        //        SqlCommand cmd3 = new SqlCommand("UPDATE [SUL_Sat_Tem] SET [SUL_Sat_Tem].[PRM_NOK]=@PRM_NOK FROM [SUL_Sat_Tem] INNER JOIN [SUL_C_H] ON [SUL_Sat_Tem].[SLSREF] = [SUL_C_H].[SLSREF] WHERE [SUL_C_H].[MT_KOD]=@MT_KOD AND [SUL_Sat_Tem].[ONC3]=1", conn);
        //        SqlCommand cmd4 = new SqlCommand("UPDATE [SUL_Sat_Tem] SET [SUL_Sat_Tem].[PRM_4]=@PRM_4 FROM [SUL_Sat_Tem] INNER JOIN [SUL_C_H] ON [SUL_Sat_Tem].[SLSREF] = [SUL_C_H].[SLSREF] WHERE [SUL_C_H].[MT_KOD]=@MT_KOD AND [SUL_Sat_Tem].[ONC4]=1", conn);
        //        SqlCommand cmd5 = new SqlCommand("UPDATE [SUL_Sat_Tem] SET [SUL_Sat_Tem].[PRM_5]=@PRM_5 FROM [SUL_Sat_Tem] INNER JOIN [SUL_C_H] ON [SUL_Sat_Tem].[SLSREF] = [SUL_C_H].[SLSREF] WHERE [SUL_C_H].[MT_KOD]=@MT_KOD AND [SUL_Sat_Tem].[ONC5]=1", conn);

        //        cmd.Parameters.Add("@PRM_TAH", SqlDbType.Float).Value = PRM_TAH;
        //        cmd2.Parameters.Add("@PRM_SAT", SqlDbType.Float).Value = PRM_SAT;
        //        cmd3.Parameters.Add("@PRM_NOK", SqlDbType.Float).Value = PRM_NOK;
        //        cmd4.Parameters.Add("@PRM_4", SqlDbType.Float).Value = PRM_4;
        //        cmd5.Parameters.Add("@PRM_5", SqlDbType.Float).Value = PRM_5;
        //        cmd.Parameters.Add("@MT_KOD", SqlDbType.VarChar, 25).Value = MT_KOD;
        //        cmd2.Parameters.Add("@MT_KOD", SqlDbType.VarChar, 25).Value = MT_KOD;
        //        cmd3.Parameters.Add("@MT_KOD", SqlDbType.VarChar, 25).Value = MT_KOD;
        //        cmd4.Parameters.Add("@MT_KOD", SqlDbType.VarChar, 25).Value = MT_KOD;
        //        cmd5.Parameters.Add("@MT_KOD", SqlDbType.VarChar, 25).Value = MT_KOD;

        //        try
        //        {
        //            conn.Open();
        //            cmd.ExecuteNonQuery();
        //            cmd2.ExecuteNonQuery();
        //            cmd3.ExecuteNonQuery();
        //            cmd4.ExecuteNonQuery();
        //            cmd5.ExecuteNonQuery();
        //        }
        //        catch (SqlException ex)
        //        {
        //            Hatalar.DoInsert(ex);
        //        }
        //        finally
        //        {
        //            conn.Close();
        //        }
        //    }
        //}
        /// <summary>
        /// SET Tahsilat
        /// </summary>
        public static void SetSatTemTah(int SLSREF, double PRM_TAH)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3sa))
            {
                SqlCommand cmd = new SqlCommand("UPDATE [SUL_Sat_Tem] SET [PRM_TAH]=@PRM_TAH WHERE SLSREF = @SLSREF", conn);
                SqlCommand cmd2 = new SqlCommand("UPDATE [SUL_C_H] SET [PRM_TAH]=@PRM_TAH WHERE SLSREF = @SLSREF AND [ONC1]=3", conn);

                cmd.Parameters.Add("@PRM_TAH", SqlDbType.Float).Value = PRM_TAH;
                cmd.Parameters.Add("@SLSREF", SqlDbType.Int).Value = SLSREF;
                cmd2.Parameters.Add("@PRM_TAH", SqlDbType.Float).Value = PRM_TAH;
                cmd2.Parameters.Add("@SLSREF", SqlDbType.Int).Value = SLSREF;

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
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
        /// SET Satış
        /// </summary>
        public static void SetSatTemSat(int SLSREF, double PRM_SAT)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3sa))
            {
                SqlCommand cmd = new SqlCommand("UPDATE [SUL_Sat_Tem] SET [PRM_SAT]=@PRM_SAT WHERE SLSREF = @SLSREF", conn);
                SqlCommand cmd2 = new SqlCommand("UPDATE [SUL_C_H] SET [PRM_SAT]=@PRM_SAT WHERE SLSREF = @SLSREF AND [ONC2]=3", conn);

                cmd.Parameters.Add("@PRM_SAT", SqlDbType.Float).Value = PRM_SAT;
                cmd.Parameters.Add("@SLSREF", SqlDbType.Int).Value = SLSREF;
                cmd2.Parameters.Add("@PRM_SAT", SqlDbType.Float).Value = PRM_SAT;
                cmd2.Parameters.Add("@SLSREF", SqlDbType.Int).Value = SLSREF;

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
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
        /// SET Nokta
        /// </summary>
        public static void SetSatTemNok(int SLSREF, double PRM_NOK)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3sa))
            {
                SqlCommand cmd = new SqlCommand("UPDATE [SUL_Sat_Tem] SET [PRM_NOK]=@PRM_NOK WHERE SLSREF = @SLSREF", conn);
                SqlCommand cmd2 = new SqlCommand("UPDATE [SUL_C_H] SET [PRM_NOK]=@PRM_NOK WHERE SLSREF = @SLSREF AND [ONC3]=3", conn);

                cmd.Parameters.Add("@PRM_NOK", SqlDbType.Float).Value = PRM_NOK;
                cmd.Parameters.Add("@SLSREF", SqlDbType.Int).Value = SLSREF;
                cmd2.Parameters.Add("@PRM_NOK", SqlDbType.Float).Value = PRM_NOK;
                cmd2.Parameters.Add("@SLSREF", SqlDbType.Int).Value = SLSREF;

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
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
        /// SET Prim 4
        /// </summary>
        public static void SetSatTem4(int SLSREF, double PRM_4)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3sa))
            {
                SqlCommand cmd = new SqlCommand("UPDATE [SUL_Sat_Tem] SET [PRM_4]=@PRM_4 WHERE SLSREF = @SLSREF", conn);
                SqlCommand cmd2 = new SqlCommand("UPDATE [SUL_C_H] SET [PRM_4]=@PRM_4 WHERE SLSREF = @SLSREF AND [ONC4]=3", conn);

                cmd.Parameters.Add("@PRM_4", SqlDbType.Float).Value = PRM_4;
                cmd.Parameters.Add("@SLSREF", SqlDbType.Int).Value = SLSREF;
                cmd2.Parameters.Add("@PRM_4", SqlDbType.Float).Value = PRM_4;
                cmd2.Parameters.Add("@SLSREF", SqlDbType.Int).Value = SLSREF;

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
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
        /// SET Prim 5
        /// </summary>
        public static void SetSatTem5(int SLSREF, double PRM_5)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3sa))
            {
                SqlCommand cmd = new SqlCommand("UPDATE [SUL_Sat_Tem] SET [PRM_5]=@PRM_5 WHERE SLSREF = @SLSREF", conn);
                SqlCommand cmd2 = new SqlCommand("UPDATE [SUL_C_H] SET [PRM_5]=@PRM_5 WHERE SLSREF = @SLSREF AND [ONC5]=3", conn);

                cmd.Parameters.Add("@PRM_5", SqlDbType.Float).Value = PRM_5;
                cmd.Parameters.Add("@SLSREF", SqlDbType.Int).Value = SLSREF;
                cmd2.Parameters.Add("@PRM_5", SqlDbType.Float).Value = PRM_5;
                cmd2.Parameters.Add("@SLSREF", SqlDbType.Int).Value = SLSREF;

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
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
        /// SET Araç Çarpanı
        /// </summary>
        public static void SetSatTemARC_CRP(int SLSREF, double ARC_CRP)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3sa))
            {
                SqlCommand cmd = new SqlCommand("UPDATE [SUL_Sat_Tem] SET [ARC_CRP]=@ARC_CRP WHERE SLSREF = @SLSREF", conn);
                SqlCommand cmd2 = new SqlCommand("UPDATE [SUL_C_H] SET [ARC_CRP]=@ARC_CRP WHERE SLSREF = @SLSREF", conn);

                cmd.Parameters.Add("@ARC_CRP", SqlDbType.Float).Value = ARC_CRP;
                cmd.Parameters.Add("@SLSREF", SqlDbType.Int).Value = SLSREF;
                cmd2.Parameters.Add("@ARC_CRP", SqlDbType.Float).Value = ARC_CRP;
                cmd2.Parameters.Add("@SLSREF", SqlDbType.Int).Value = SLSREF;

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
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
        /// SET ONC, YER = 1,2,3,4,5
        /// </summary>
        public static void SetSatTemONC(int SLSREF, string YER, int ONC)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3sa))
            {
                SqlCommand cmd = new SqlCommand("UPDATE [SUL_Sat_Tem] SET [ONC" + YER + "]=@ONC WHERE SLSREF = @SLSREF", conn);
                cmd.Parameters.Add("@ONC", SqlDbType.Int).Value = ONC;
                cmd.Parameters.Add("@SLSREF", SqlDbType.Int).Value = SLSREF;
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
        #endregion
        #region Cari Hesap
        /// <summary>
        /// SELECT SUL_C_H
        /// </summary>
        public static void GetObjectsCH(DataTable dt)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT [A_P],[REF],[B_KOD],[BOLGE],[BOLGE_TANIM],[MTBII_KOD],[BII_KOD],[GRP],[EKP],[YTK_KOD],[IL_KOD],[IL],[ILC_KOD],[ILCE],[TIP],[SLSREF],[SAT_KOD],[SAT_KOD1],[SAT_TEM],[GMREF],[MT_KOD],[MT_ACIKLAMA],[MUS_KOD],[MUSTERI],[SMREF],[SUBE_KOD],[SUBE],[ARC_CRP],[ONC1],[PRM_TAH],[ONC2],[PRM_SAT],[ONC3],[PRM_NOK],[ONC4],[PRM_4],[ONC5],[PRM_5] FROM [SUL_C_H] ORDER BY [MT_ACIKLAMA],[BOLGE],[IL],[ILCE],[MUSTERI],[SUBE]", conn);
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
        /// UPDATE SUL_C_H By CariTip
        /// </summary>
        public static void SetCariHesapByCariTip(string MT_KOD, double PRM_TAH, double PRM_SAT, double PRM_NOK, double PRM_4, double PRM_5)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3sa))
            {
                SqlCommand cmd = new SqlCommand("UPDATE [SUL_C_H] SET [PRM_TAH]=@PRM_TAH WHERE [MT_KOD]=@MT_KOD AND [ONC1]=1", conn);
                SqlCommand cmd2 = new SqlCommand("UPDATE [SUL_C_H] SET [PRM_SAT]=@PRM_SAT WHERE [MT_KOD]=@MT_KOD AND [ONC2]=1", conn);
                SqlCommand cmd3 = new SqlCommand("UPDATE [SUL_C_H] SET [PRM_NOK]=@PRM_NOK WHERE [MT_KOD]=@MT_KOD AND [ONC3]=1", conn);
                SqlCommand cmd4 = new SqlCommand("UPDATE [SUL_C_H] SET [PRM_4]=@PRM_4 WHERE [MT_KOD]=@MT_KOD AND [ONC4]=1", conn);
                SqlCommand cmd5 = new SqlCommand("UPDATE [SUL_C_H] SET [PRM_5]=@PRM_5 WHERE [MT_KOD]=@MT_KOD AND [ONC5]=1", conn);

                cmd.Parameters.Add("@PRM_TAH", SqlDbType.Float).Value = PRM_TAH;
                cmd2.Parameters.Add("@PRM_SAT", SqlDbType.Float).Value = PRM_SAT;
                cmd3.Parameters.Add("@PRM_NOK", SqlDbType.Float).Value = PRM_NOK;
                cmd4.Parameters.Add("@PRM_4", SqlDbType.Float).Value = PRM_4;
                cmd5.Parameters.Add("@PRM_5", SqlDbType.Float).Value = PRM_5;
                cmd.Parameters.Add("@MT_KOD", SqlDbType.VarChar, 25).Value = MT_KOD;
                cmd2.Parameters.Add("@MT_KOD", SqlDbType.VarChar, 25).Value = MT_KOD;
                cmd3.Parameters.Add("@MT_KOD", SqlDbType.VarChar, 25).Value = MT_KOD;
                cmd4.Parameters.Add("@MT_KOD", SqlDbType.VarChar, 25).Value = MT_KOD;
                cmd5.Parameters.Add("@MT_KOD", SqlDbType.VarChar, 25).Value = MT_KOD;

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    cmd2.ExecuteNonQuery();
                    cmd3.ExecuteNonQuery();
                    cmd4.ExecuteNonQuery();
                    cmd5.ExecuteNonQuery();
                }
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
        /// SET Tahsilat
        /// </summary>
        public static void SetCariHesapTah(int SMREF, double PRM_TAH)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3sa))
            {
                SqlCommand cmd = new SqlCommand("UPDATE [SUL_C_H] SET [PRM_TAH]=@PRM_TAH WHERE SMREF = @SMREF", conn);

                cmd.Parameters.Add("@PRM_TAH", SqlDbType.Float).Value = PRM_TAH;
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
        /// <summary>
        /// SET Satış
        /// </summary>
        public static void SetCariHesapSat(int SMREF, double PRM_SAT)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3sa))
            {
                SqlCommand cmd = new SqlCommand("UPDATE [SUL_C_H] SET [PRM_SAT]=@PRM_SAT WHERE SMREF = @SMREF", conn);

                cmd.Parameters.Add("@PRM_SAT", SqlDbType.Float).Value = PRM_SAT;
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
        /// <summary>
        /// SET Nokta
        /// </summary>
        public static void SetCariHesapNok(int SMREF, double PRM_NOK)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3sa))
            {
                SqlCommand cmd = new SqlCommand("UPDATE [SUL_C_H] SET [PRM_NOK]=@PRM_NOK WHERE SMREF = @SMREF", conn);
                
                cmd.Parameters.Add("@PRM_NOK", SqlDbType.Float).Value = PRM_NOK;
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
        /// <summary>
        /// SET Prim 4
        /// </summary>
        public static void SetCariHesap4(int SMREF, double PRM_4)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3sa))
            {
                SqlCommand cmd = new SqlCommand("UPDATE [SUL_C_H] SET [PRM_4]=@PRM_4 WHERE SMREF = @SMREF", conn);
                
                cmd.Parameters.Add("@PRM_4", SqlDbType.Float).Value = PRM_4;
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
        /// <summary>
        /// SET Prim 5
        /// </summary>
        public static void SetCariHesap5(int SMREF, double PRM_5)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3sa))
            {
                SqlCommand cmd = new SqlCommand("UPDATE [SUL_C_H] SET [PRM_5]=@PRM_5 WHERE SMREF = @SMREF", conn);
                
                cmd.Parameters.Add("@PRM_5", SqlDbType.Float).Value = PRM_5;
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
        /// <summary>
        /// SET Araç Çarpanı
        /// </summary>
        public static void SetCariHesapARC_CRP(int SMREF, double ARC_CRP)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3sa))
            {
                SqlCommand cmd = new SqlCommand("UPDATE [SUL_C_H] SET [ARC_CRP]=@ARC_CRP WHERE SMREF = @SMREF", conn);
                
                cmd.Parameters.Add("@ARC_CRP", SqlDbType.Float).Value = ARC_CRP;
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
        /// <summary>
        /// SET ONC, YER = 1,2,3,4,5
        /// </summary>
        public static void SetCariHesapONC(int SMREF, string YER, int ONC)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3sa))
            {
                SqlCommand cmd = new SqlCommand("UPDATE [SUL_C_H] SET [ONC" + YER + "]=@ONC WHERE SMREF = @SMREF", conn);
                cmd.Parameters.Add("@ONC", SqlDbType.Int).Value = ONC;
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
        #endregion

        #region Fiyat Tipi
        /// <summary>
        /// SELECT SUL_F
        /// </summary>
        public static void GetObjectsF(DataTable dt)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT [FTIP],[FACIK],[PRM_TAH],[PRM_SAT],[PRM_NOK],[PRM_4],[PRM_5] FROM [SUL_F] ORDER BY [FTIP]", conn);
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
        /// SET Tahsilat
        /// </summary>
        public static void SetFiyatTipTah(string FTIP, double PRM_TAH)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3sa))
            {
                SqlCommand cmd = new SqlCommand("UPDATE [SUL_F] SET [PRM_TAH]=@PRM_TAH WHERE FTIP = @FTIP", conn);
                SqlCommand cmd2 = new SqlCommand("UPDATE [SUL_TF] SET [PRM_TAH]=@PRM_TAH WHERE FTIP = @FTIP AND [ONC1]=1", conn);

                cmd.Parameters.Add("@PRM_TAH", SqlDbType.Float).Value = PRM_TAH;
                cmd.Parameters.Add("@FTIP", SqlDbType.VarChar, 50).Value = FTIP;
                cmd2.Parameters.Add("@PRM_TAH", SqlDbType.Float).Value = PRM_TAH;
                cmd2.Parameters.Add("@FTIP", SqlDbType.VarChar, 50).Value = FTIP;

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
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
        /// SET Satış
        /// </summary>
        public static void SetFiyatTipSat(string FTIP, double PRM_SAT)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3sa))
            {
                SqlCommand cmd = new SqlCommand("UPDATE [SUL_F] SET [PRM_SAT]=@PRM_SAT WHERE FTIP = @FTIP", conn);
                SqlCommand cmd2 = new SqlCommand("UPDATE [SUL_TF] SET [PRM_SAT]=@PRM_SAT WHERE FTIP = @FTIP AND [ONC2]=1", conn);

                cmd.Parameters.Add("@PRM_SAT", SqlDbType.Float).Value = PRM_SAT;
                cmd.Parameters.Add("@FTIP", SqlDbType.VarChar, 50).Value = FTIP;
                cmd2.Parameters.Add("@PRM_SAT", SqlDbType.Float).Value = PRM_SAT;
                cmd2.Parameters.Add("@FTIP", SqlDbType.VarChar, 50).Value = FTIP;

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
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
        /// SET Nokta
        /// </summary>
        public static void SetFiyatTipNok(string FTIP, double PRM_NOK)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3sa))
            {
                SqlCommand cmd = new SqlCommand("UPDATE [SUL_F] SET [PRM_NOK]=@PRM_NOK WHERE FTIP = @FTIP", conn);
                SqlCommand cmd2 = new SqlCommand("UPDATE [SUL_TF] SET [PRM_NOK]=@PRM_NOK WHERE FTIP = @FTIP AND [ONC3]=1", conn);

                cmd.Parameters.Add("@PRM_NOK", SqlDbType.Float).Value = PRM_NOK;
                cmd.Parameters.Add("@FTIP", SqlDbType.VarChar, 50).Value = FTIP;
                cmd2.Parameters.Add("@PRM_NOK", SqlDbType.Float).Value = PRM_NOK;
                cmd2.Parameters.Add("@FTIP", SqlDbType.VarChar, 50).Value = FTIP;

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
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
        /// SET Prim 4
        /// </summary>
        public static void SetFiyatTip4(string FTIP, double PRM_4)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3sa))
            {
                SqlCommand cmd = new SqlCommand("UPDATE [SUL_F] SET [PRM_4]=@PRM_4 WHERE FTIP = @FTIP", conn);
                SqlCommand cmd2 = new SqlCommand("UPDATE [SUL_TF] SET [PRM_4]=@PRM_4 WHERE FTIP = @FTIP AND [ONC4]=1", conn);

                cmd.Parameters.Add("@PRM_4", SqlDbType.Float).Value = PRM_4;
                cmd.Parameters.Add("@FTIP", SqlDbType.VarChar, 50).Value = FTIP;
                cmd2.Parameters.Add("@PRM_4", SqlDbType.Float).Value = PRM_4;
                cmd2.Parameters.Add("@FTIP", SqlDbType.VarChar, 50).Value = FTIP;

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
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
        /// SET Prim 5
        /// </summary>
        public static void SetFiyatTip5(string FTIP, double PRM_5)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3sa))
            {
                SqlCommand cmd = new SqlCommand("UPDATE [SUL_F] SET [PRM_5]=@PRM_5 WHERE FTIP = @FTIP", conn);
                SqlCommand cmd2 = new SqlCommand("UPDATE [SUL_TF] SET [PRM_5]=@PRM_5 WHERE FTIP = @FTIP AND [ONC5]=1", conn);

                cmd.Parameters.Add("@PRM_5", SqlDbType.Float).Value = PRM_5;
                cmd.Parameters.Add("@FTIP", SqlDbType.VarChar, 50).Value = FTIP;
                cmd2.Parameters.Add("@PRM_5", SqlDbType.Float).Value = PRM_5;
                cmd2.Parameters.Add("@FTIP", SqlDbType.VarChar, 50).Value = FTIP;

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
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
        #endregion
        #region Tedarik Grupları
        /// <summary>
        /// SELECT SUL_TF
        /// </summary>
        public static void GetObjectsTF(DataTable dt)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT [ANA_GRP],[ALTGRP_KOD],[ALTGRP_ACIK],[FTIP],[FACIK],[ONC1],[PRM_TAH],[ONC2],[PRM_SAT],[ONC3],[PRM_NOK],[ONC4],[PRM_4],[ONC5],[PRM_5]FROM [SUL_TF] ORDER BY [ANA_GRP],[ALTGRP_ACIK],[FTIP]", conn);
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
        /// SET Tahsilat
        /// </summary>
        public static void SetTedarikGrupTah(string ALTGRP_KOD, string FTIP, double PRM_TAH)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3sa))
            {
                SqlCommand cmd = new SqlCommand("UPDATE [SUL_TF] SET [PRM_TAH]=@PRM_TAH WHERE ALTGRP_KOD = @ALTGRP_KOD AND FTIP = @FTIP", conn);

                cmd.Parameters.Add("@PRM_TAH", SqlDbType.Float).Value = PRM_TAH;
                cmd.Parameters.Add("@ALTGRP_KOD", SqlDbType.VarChar, 50).Value = ALTGRP_KOD;
                cmd.Parameters.Add("@FTIP", SqlDbType.VarChar, 50).Value = FTIP;

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
        /// SET Satış
        /// </summary>
        public static void SetTedarikGrupSat(string ALTGRP_KOD, string FTIP, double PRM_SAT)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3sa))
            {
                SqlCommand cmd = new SqlCommand("UPDATE [SUL_TF] SET [PRM_SAT]=@PRM_SAT WHERE ALTGRP_KOD = @ALTGRP_KOD AND FTIP = @FTIP", conn);

                cmd.Parameters.Add("@PRM_SAT", SqlDbType.Float).Value = PRM_SAT;
                cmd.Parameters.Add("@ALTGRP_KOD", SqlDbType.VarChar, 50).Value = ALTGRP_KOD;
                cmd.Parameters.Add("@FTIP", SqlDbType.VarChar, 50).Value = FTIP;

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
        /// SET Nokta
        /// </summary>
        public static void SetTedarikGrupNok(string ALTGRP_KOD, string FTIP, double PRM_NOK)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3sa))
            {
                SqlCommand cmd = new SqlCommand("UPDATE [SUL_TF] SET [PRM_NOK]=@PRM_NOK WHERE ALTGRP_KOD = @ALTGRP_KOD AND FTIP = @FTIP", conn);

                cmd.Parameters.Add("@PRM_NOK", SqlDbType.Float).Value = PRM_NOK;
                cmd.Parameters.Add("@ALTGRP_KOD", SqlDbType.VarChar, 50).Value = ALTGRP_KOD;
                cmd.Parameters.Add("@FTIP", SqlDbType.VarChar, 50).Value = FTIP;

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
        /// SET Prim 4
        /// </summary>
        public static void SetTedarikGrup4(string ALTGRP_KOD, string FTIP, double PRM_4)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3sa))
            {
                SqlCommand cmd = new SqlCommand("UPDATE [SUL_TF] SET [PRM_4]=@PRM_4 WHERE ALTGRP_KOD = @ALTGRP_KOD AND FTIP = @FTIP", conn);

                cmd.Parameters.Add("@PRM_4", SqlDbType.Float).Value = PRM_4;
                cmd.Parameters.Add("@ALTGRP_KOD", SqlDbType.VarChar, 50).Value = ALTGRP_KOD;
                cmd.Parameters.Add("@FTIP", SqlDbType.VarChar, 50).Value = FTIP;

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
        /// SET Prim 5
        /// </summary>
        public static void SetTedarikGrup5(string ALTGRP_KOD, string FTIP, double PRM_5)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3sa))
            {
                SqlCommand cmd = new SqlCommand("UPDATE [SUL_TF] SET [PRM_5]=@PRM_5 WHERE ALTGRP_KOD = @ALTGRP_KOD AND FTIP = @FTIP", conn);

                cmd.Parameters.Add("@PRM_5", SqlDbType.Float).Value = PRM_5;
                cmd.Parameters.Add("@ALTGRP_KOD", SqlDbType.VarChar, 50).Value = ALTGRP_KOD;
                cmd.Parameters.Add("@FTIP", SqlDbType.VarChar, 50).Value = FTIP;

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
        /// SET ONC, YER = 1,2,3,4,5
        /// </summary>
        public static void SetTedarikGrupONC(string ALTGRP_KOD, string FTIP, string YER, int ONC)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3sa))
            {
                SqlCommand cmd = new SqlCommand("UPDATE [SUL_TF] SET [ONC" + YER + "]=@ONC WHERE ALTGRP_KOD = @ALTGRP_KOD AND FTIP = @FTIP", conn);
                cmd.Parameters.Add("@ONC", SqlDbType.Int).Value = ONC;
                cmd.Parameters.Add("@ALTGRP_KOD", SqlDbType.VarChar, 50).Value = ALTGRP_KOD;
                cmd.Parameters.Add("@FTIP", SqlDbType.VarChar, 50).Value = FTIP;
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
        #endregion
    }
}

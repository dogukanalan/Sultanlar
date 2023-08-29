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
    public class IadelerQ
    {
        public static string GetQuantumNo(int IadeID)
        {
            string donendeger = string.Empty;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT QUANTUMNO FROM tblINTERNET_IadelerQ WHERE intIadeID = @intIadeID", conn);
                cmd.Parameters.Add("@intIadeID", SqlDbType.Int).Value = IadeID;
                try
                {
                    conn.Open();
                    object obj = cmd.ExecuteScalar();
                    if (obj != null)
                        donendeger = obj.ToString();
                    else
                        donendeger = "<i> -Yok- </i>";
                }
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
        public static int QuantumNoVarMi(string BAYIKOD, string QuantumNo)
        {
            int donendeger = 0;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT intIadeID FROM tblINTERNET_IadelerQ INNER JOIN tblINTERNET_Iadeler ON intIadeID = pkIadeID INNER JOIN (SELECT DISTINCT GMREF,SMREF,TIP FROM [Web-Musteri-1]) AS MUS ON MUS.TIP = tblINTERNET_Iadeler.TKSREF AND MUS.SMREF = tblINTERNET_Iadeler.SMREF WHERE GMREF = @BAYIKOD AND QUANTUMNO = @QUANTUMNO", conn);
                cmd.Parameters.Add("@BAYIKOD", SqlDbType.NVarChar).Value = BAYIKOD;
                cmd.Parameters.Add("@QUANTUMNO", SqlDbType.NVarChar).Value = QuantumNo;
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
        public static bool QuantumNoVarMi(int IadeID)
        {
            bool donendeger = false;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT count(*) FROM tblINTERNET_IadelerQ WHERE intIadeID = @intIadeID", conn);
                cmd.Parameters.Add("@intIadeID", SqlDbType.Int).Value = IadeID;
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
        public static void WriteQuantumNo(int IadeID, string QuantumNo, string Fatno, DateTime FATTAR)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO tblINTERNET_IadelerQ (intIadeID,QUANTUMNO,FATNO,FATTAR) VALUES (@intIadeID,@QUANTUMNO,@FATNO,@FATTAR)", conn);

                if (QuantumNoVarMi(IadeID))
                    cmd.CommandText = "UPDATE tblINTERNET_IadelerQ SET QUANTUMNO = @QUANTUMNO,FATNO = @FATNO WHERE intIadeID = @intIadeID";

                cmd.Parameters.Add("@intIadeID", SqlDbType.Int).Value = IadeID;
                cmd.Parameters.Add("@QUANTUMNO", SqlDbType.NVarChar, 50).Value = QuantumNo;
                cmd.Parameters.Add("@FATNO", SqlDbType.VarChar, 17).Value = Fatno;
                cmd.Parameters.Add("@FATTAR", SqlDbType.DateTime).Value = FATTAR;
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
        public static string QuantumAciklama4eYaz(int IadeID, string QuantumNo)
        {
            string donendeger = string.Empty;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UPDATE [QUANTUMNET].[dbo].[SATIS_SIPARIS_KART] SET [ACIKLAMA4] = @Aciklama4 WHERE KARTNO = @KARTNO SELECT ACIKLAMA4 FROM [QUANTUMNET].[dbo].[SATIS_SIPARIS_KART] WHERE KARTNO = @KARTNO", conn);
                cmd.Parameters.Add("@Aciklama4", SqlDbType.NVarChar, 51).Value = "Web İade No: " + IadeID.ToString();
                cmd.Parameters.Add("@KARTNO", SqlDbType.NVarChar, 50).Value = QuantumNo;
                try
                {
                    conn.Open();
                    object obj = cmd.ExecuteScalar();
                    if (obj != null || obj != DBNull.Value)
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
        public static void Delete(int IadeID)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM tblINTERNET_IadelerQ WHERE intIadeID = @intIadeID", conn);
                cmd.Parameters.Add("@intIadeID", SqlDbType.Int).Value = IadeID;
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
    }
}

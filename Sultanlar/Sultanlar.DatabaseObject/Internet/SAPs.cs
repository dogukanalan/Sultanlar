using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Sultanlar.DatabaseObject.Internet
{
    public class SAPs
    {
        public static void GetDurum(DataTable dt, int SiparisID, int SapSipID)
        {
            string where = " WHERE";

            if (SiparisID != 0)
                where += " (WEB_NO = " + SiparisID.ToString() + ") AND";
            if (SapSipID != 0)
                where += " (SIP_NO = " + SiparisID.ToString() + ") AND";

            if (where == " WHERE") where = string.Empty; else where = where.Substring(0, where.Length - 4);

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT [SNR],[YIL],[AY],[MUST_KOD],[SIP_TAR],[SIP_NO],[SIP_STR],[WEB_NO],[MALZ_KOD],[RED_KOD],[RED_NEDENI],[SIP_AD],[TSL_AD],[IRS_AD],[BKY_AD] FROM [SAP_SIPARIS_STR_DRM] " + where, conn);
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

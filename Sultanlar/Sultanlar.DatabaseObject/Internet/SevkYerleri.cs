using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Web.UI.WebControls;

namespace Sultanlar.DatabaseObject.Internet
{
    public class SevkYerleri
    {
        public static void GetObjects(DataTable dt)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT [GMREF],[SMREF],[KOD],[DEFINITION_],[SVREF],[CODE],[NAME] FROM [Web-SevkYerleri] ORDER BY NAME", conn);
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
        public static void GetObjectsBySMREF(DataTable dt, int SMREF)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT [GMREF],[SMREF],[KOD],[DEFINITION_],[SVREF],[CODE],[NAME] FROM [Web-SevkYerleri] WHERE SMREF = @SMREF ORDER BY NAME", conn);
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
        public static void GetObjectsBySMREF(ListItemCollection lic, int SMREF)
        {
            lic.Clear();
            ListItem lst = new ListItem("Seçim Yok", "0");
            lic.Add(lst);

            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3))
            {
                SqlCommand cmd = new SqlCommand("SELECT [GMREF],[SMREF],[KOD],[DEFINITION_],[SVREF],[CODE],[NAME] FROM [Web-SevkYerleri] WHERE SMREF = @SMREF ORDER BY NAME", conn);
                cmd.Parameters.Add("@SMREF", SqlDbType.Int).Value = SMREF;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        lst = new ListItem(dr[6].ToString(), dr[4].ToString());
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
    }
}

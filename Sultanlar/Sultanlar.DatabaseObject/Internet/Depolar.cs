using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Sultanlar.DatabaseObject.Internet
{
    public class Depolar
    {
        private int _pkDepoID;
        private byte _tintIlID;
        private string _strDepo;
        private Depolar(int pkDepoID, byte tintIlID, string strDepo)
        {
            this._pkDepoID = pkDepoID;
            this._tintIlID = tintIlID;
            this._strDepo = strDepo;
        }
        public Depolar(byte tintIlID, string strDepo)
        {
            this._tintIlID = tintIlID;
            this._strDepo = strDepo;
        }
        public int pkDepoID { get { return this._pkDepoID; } }
        public byte tintIlID { get { return this._tintIlID; } set { this._tintIlID = value; } }
        public string strDepo { get { return this._strDepo; } set { this._strDepo = value; } }
        public static void GetObjectsByIlID(ListItemCollection lic, byte IlID)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                lic.Clear();

                ListItem lst = new ListItem();
                lst.Text = "Sultanlar Merkez";
                lst.Value = "0";
                lic.Add(lst);

                SqlCommand cmd = new SqlCommand("SELECT pkDepoID, strDepo FROM tblINTERNET_Depolar WHERE tintIlID = @tintIlID", conn);
                cmd.Parameters.Add("@tintIlID", System.Data.SqlDbType.TinyInt).Value = IlID;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        ListItem lst1 = new ListItem();
                        lst1.Text = dr[1].ToString();
                        lst1.Value = dr[0].ToString();
                        lic.Add(lst1);
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
        public static string GetObject(int DepoID)
        {
            string donendeger = string.Empty;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT strDepo FROM tblINTERNET_Depolar WHERE pkDepoID = @pkDepoID", conn);
                cmd.Parameters.Add("@pkDepoID", System.Data.SqlDbType.Int).Value = DepoID;
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
    }
}

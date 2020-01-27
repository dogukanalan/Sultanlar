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

namespace Sultanlar.DatabaseObject
{
    public class YabanciDiller : IDisposable, ISultanlar
    {
        //
        //
        //
        // Alanlar:
        //
        private int _pkYabanciDilID;
        private int _intBasvuruID;
        private byte _tintDilID;
        private byte _tintOkumaDereceID;
        private byte _tintYazmaDereceID;
        private byte _tintKonusmaDereceID;
        //
        //
        //
        // Constracter lar:
        //
        private YabanciDiller(int pkYabanciDilID, int intBasvuruID, byte tintDilID, byte tintOkumaDereceID, byte tintYazmaDereceID, byte tintKonusmaDereceID)
        {
            this._pkYabanciDilID = pkYabanciDilID;
            this._intBasvuruID = intBasvuruID;
            this._tintDilID = tintDilID;
            this._tintOkumaDereceID = tintOkumaDereceID;
            this._tintYazmaDereceID = tintYazmaDereceID;
            this._tintKonusmaDereceID = tintKonusmaDereceID;
        }
        //
        //
        public YabanciDiller(int intBasvuruID, byte tintDilID, byte tintOkumaDereceID, byte tintYazmaDereceID, byte tintKonusmaDereceID)
        {
            this._intBasvuruID = intBasvuruID;
            this._tintDilID = tintDilID;
            this._tintOkumaDereceID = tintOkumaDereceID;
            this._tintYazmaDereceID = tintYazmaDereceID;
            this._tintKonusmaDereceID = tintKonusmaDereceID;
        }
        //
        //
        //
        // Özellikler:
        //
        public int pkYabanciDilID
        {
            get
            {
                return this._pkYabanciDilID;
            }
        }
        //
        //
        public int intBasvuruID
        {
            get
            {
                return this._intBasvuruID;
            }
            set
            {
                this._intBasvuruID = value;
            }
        }
        //
        //
        public byte tintDilID
        {
            get
            {
                return this._tintDilID;
            }
            set
            {
                this._tintDilID = value;
            }
        }
        //
        //
        public byte tintOkumaDereceID
        {
            get
            {
                return this._tintOkumaDereceID;
            }
            set
            {
                this._tintOkumaDereceID = value;
            }
        }
        //
        //
        public byte tintYazmaDereceID
        {
            get
            {
                return this._tintYazmaDereceID;
            }
            set
            {
                this._tintYazmaDereceID = value;
            }
        }
        //
        //
        public byte tintKonusmaDereceID
        {
            get
            {
                return this._tintKonusmaDereceID;
            }
            set
            {
                this._tintKonusmaDereceID = value;
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
        // Metodlar:
        //
        public void DoInsert()
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_YabanciDilEkle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@intBasvuruID", SqlDbType.Int).Value = this._intBasvuruID;
                cmd.Parameters.Add("@tintDilID", SqlDbType.TinyInt).Value = this._tintDilID;
                cmd.Parameters.Add("@tintOkumaDereceID", SqlDbType.TinyInt).Value = this._tintOkumaDereceID;
                cmd.Parameters.Add("@tintYazmaDereceID", SqlDbType.TinyInt).Value = this._tintYazmaDereceID;
                cmd.Parameters.Add("@tintKonusmaDereceID", SqlDbType.TinyInt).Value = this._tintKonusmaDereceID;
                cmd.Parameters.Add("@pkYabanciDilID", SqlDbType.Int).Direction = ParameterDirection.Output;
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    this._pkYabanciDilID = Convert.ToInt32(cmd.Parameters["@pkYabanciDilID"].Value);
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
                SqlCommand cmd = new SqlCommand("sp_YabanciDilGuncelle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkYabanciDilID", SqlDbType.Int).Value = this._pkYabanciDilID;
                cmd.Parameters.Add("@intBasvuruID", SqlDbType.Int).Value = this._intBasvuruID;
                cmd.Parameters.Add("@tintDilID", SqlDbType.TinyInt).Value = this._tintDilID;
                cmd.Parameters.Add("@tintOkumaDereceID", SqlDbType.TinyInt).Value = this._tintOkumaDereceID;
                cmd.Parameters.Add("@tintYazmaDereceID", SqlDbType.TinyInt).Value = this._tintYazmaDereceID;
                cmd.Parameters.Add("@tintKonusmaDereceID", SqlDbType.TinyInt).Value = this._tintKonusmaDereceID;
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
                SqlCommand cmd = new SqlCommand("sp_YabanciDilSil", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkYabanciDilID", SqlDbType.Int).Value = this._pkYabanciDilID;
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
        public static void GetObject(ListItemCollection lic)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                lic.Clear();

                SqlCommand cmd = new SqlCommand("sp_YabanciDilGetir", conn);
                cmd.CommandType = CommandType.StoredProcedure;
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
        public static void GetObject(DataTable dt)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_YabanciDilGetir", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        DataRow dtrow = dt.NewRow();
                        dtrow[0] = dr[0].ToString();
                        dtrow[1] = dr[1].ToString();
                        dtrow[2] = dr[2].ToString();
                        dtrow[3] = dr[3].ToString();
                        dtrow[4] = dr[4].ToString();
                        dtrow[5] = dr[5].ToString();
                        dt.Rows.Add(dtrow);
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
        public static void GetObject(DataTable dt, int BasvuruID)
        {
            dt.Clear();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_YabanciDilGetirByBasvuruID", conn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@intBasvuruID", SqlDbType.Int).Value = BasvuruID;
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

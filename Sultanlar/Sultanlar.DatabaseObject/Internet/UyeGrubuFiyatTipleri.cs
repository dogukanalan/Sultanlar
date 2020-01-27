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
    public class UyeGrubuFiyatTipleri : ISultanlar, IDisposable
    {
        //
        //
        //
        // Alanlar:
        //
        private int _pkID;
        private int _intUyeGrupID;
        private short _sintFiyatTipiID;
        //
        //
        //
        // Constracter lar:
        //
        private UyeGrubuFiyatTipleri(int pkID, int intUyeGrupID, short sintFiyatTipiID)
        {
            this._pkID = pkID;
            this._intUyeGrupID = intUyeGrupID;
            this._sintFiyatTipiID = sintFiyatTipiID;
        }
        //
        //
        public UyeGrubuFiyatTipleri(int intUyeGrupID, short sintFiyatTipiID)
        {
            this._intUyeGrupID = intUyeGrupID;
            this._sintFiyatTipiID = sintFiyatTipiID;
        }
        //
        //
        //
        // Özellikler:
        //
        public int pkID
        {
            get
            {
                return this._pkID;
            }
        }
        //
        //
        public int intUyeGrupID
        {
            get
            {
                return this._intUyeGrupID;
            }
            set
            {
                this._intUyeGrupID = value;
            }
        }
        //
        //
        public short sintFiyatTipiID
        {
            get
            {
                return this._sintFiyatTipiID;
            }
            set
            {
                this._sintFiyatTipiID = value;
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
            return FiyatTipleri.GetObjectByID(this._sintFiyatTipiID);
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
                SqlCommand cmd = new SqlCommand("sp_INTERNET_UyeGrubuFiyatTipiEkle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@intUyeGrupID", SqlDbType.Int).Value = this._intUyeGrupID;
                cmd.Parameters.Add("@sintFiyatTipiID", SqlDbType.SmallInt).Value = this._sintFiyatTipiID;
                cmd.Parameters.Add("@pkID", SqlDbType.Int).Direction = ParameterDirection.Output;
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
                SqlCommand cmd = new SqlCommand("sp_INTERNET_UyeGrubuFiyatTipiGuncelle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkID", SqlDbType.Int).Value = this._pkID;
                cmd.Parameters.Add("@intUyeGrupID", SqlDbType.Int).Value = this._intUyeGrupID;
                cmd.Parameters.Add("@sintFiyatTipiID", SqlDbType.SmallInt).Value = this._sintFiyatTipiID;
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
                SqlCommand cmd = new SqlCommand("sp_INTERNET_UyeGrubuFiyatTipiSil", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkID", SqlDbType.Int).Value = this._pkID;
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
        public static void GetObject(IList List, int intUyeGrupID, bool UI)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                List.Clear();

                SqlCommand cmd = new SqlCommand("sp_INTERNET_UyeGrubuFiyatTipleriGetir", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@intUyeGrupID", SqlDbType.Int).Value = intUyeGrupID;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        List.Add(new UyeGrubuFiyatTipleri(Convert.ToInt32(dr[0]), Convert.ToInt32(dr[1]), Convert.ToInt16(dr[2])));
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
        public static void GetObject(ListItemCollection lic, int intUyeGrupID)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                lic.Clear();

                ListItem lst1 = new ListItem();
                lst1.Text = "Seçiniz";
                lst1.Value = "0";
                lic.Add(lst1);

                SqlCommand cmd = new SqlCommand("sp_INTERNET_UyeGrubuFiyatTipleriGetir", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@intUyeGrupID", SqlDbType.Int).Value = intUyeGrupID;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        ListItem lst = new ListItem();
                        lst.Text = dr[2].ToString() + " - " + FiyatTipleri.GetObjectByID(Convert.ToInt16(dr[2].ToString()));
                        lst.Value = dr[2].ToString();
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
        public static void GetObjectOnlyFiyatTipler(IList List, int intUyeGrupID, bool UI)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                List.Clear();

                SqlCommand cmd = new SqlCommand("sp_INTERNET_UyeGrubuFiyatTipleriGetir", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@intUyeGrupID", SqlDbType.Int).Value = intUyeGrupID;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        List.Add(Convert.ToInt16(dr[2]));
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

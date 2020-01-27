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
using Sultanlar.Class;

namespace Sultanlar.DatabaseObject
{
    public class ArananGorevler : IDisposable, ISultanlar
    {
        //
        //
        //
        // Alanlar:
        //
        private int _pkArananGorevID;
        private byte _tintGorevID;
        private byte _tintOgrenimDurumuID;
        private byte _tintAskerlikDurumuID;
        private byte _tintMedeniDurumID;
        private byte _tintIlID;
        private short _sintIlceID;
        private string _strTecrube;
        private bool _blPasif;
        private DateTime _dtSonTarih;
        //
        //
        //
        // Constracter lar:
        //
        private ArananGorevler(int pkArananGorevID, byte tintGorevID, byte tintOgrenimDurumuID, byte tintAskerlikDurumuID, byte tintMedeniDurumID,
            byte tintIlID, short sintIlceID, string strTecrube, bool blPasif, DateTime dtSonTarih)
        {
            this._pkArananGorevID = pkArananGorevID;
            this._tintGorevID = tintGorevID;
            this._tintOgrenimDurumuID = tintOgrenimDurumuID;
            this._tintAskerlikDurumuID = tintAskerlikDurumuID;
            this._tintMedeniDurumID = tintMedeniDurumID;
            this._tintIlID = tintIlID;
            this._sintIlceID = sintIlceID;
            this._strTecrube = strTecrube;
            this._blPasif = blPasif;
            this._dtSonTarih = dtSonTarih;
        }
        //
        //
        public ArananGorevler(byte tintGorevID, byte tintOgrenimDurumuID, byte tintAskerlikDurumuID, byte tintMedeniDurumID,
            byte tintIlID, short sintIlceID, string strTecrube, bool blPasif, DateTime dtSonTarih)
        {
            this._tintGorevID = tintGorevID;
            this._tintOgrenimDurumuID = tintOgrenimDurumuID;
            this._tintAskerlikDurumuID = tintAskerlikDurumuID;
            this._tintMedeniDurumID = tintMedeniDurumID;
            this._tintIlID = tintIlID;
            this._sintIlceID = sintIlceID;
            this._strTecrube = strTecrube;
            this._blPasif = blPasif;
            this._dtSonTarih = dtSonTarih;
        }
        //
        //
        //
        // Özellikler:
        //
        public int pkArananGorevID
        {
            get
            {
                return this._pkArananGorevID;
            }
        }
        //
        //
        public byte tintGorevID
        {
            get
            {
                return this._tintGorevID;
            }
            set
            {
                this._tintGorevID = value;
            }
        }
        //
        //
        public byte tintOgrenimDurumuID
        {
            get
            {
                return this._tintOgrenimDurumuID;
            }
            set
            {
                this._tintOgrenimDurumuID = value;
            }
        }
        //
        //
        public byte tintAskerlikDurumuID
        {
            get
            {
                return this._tintAskerlikDurumuID;
            }
            set
            {
                this._tintAskerlikDurumuID = value;
            }
        }
        //
        //
        public byte tintMedeniDurumID
        {
            get
            {
                return this._tintMedeniDurumID;
            }
            set
            {
                this._tintMedeniDurumID = value;
            }
        }
        //
        //
        public byte tintIlID
        {
            get
            {
                return this._tintIlID;
            }
            set
            {
                this._tintIlID = value;
            }
        }
        //
        //
        public short sintIlceID
        {
            get
            {
                return this._sintIlceID;
            }
            set
            {
                this._sintIlceID = value;
            }
        }
        //
        //
        public string strTecrube
        {
            get
            {
                return this._strTecrube;
            }
            set
            {
                this._strTecrube = value;
            }
        }
        //
        //
        public bool blPasif
        {
            get
            {
                return this._blPasif;
            }
            set
            {
                this._blPasif = value;
            }
        }
        //
        //
        public DateTime dtSonTarih
        {
            get
            {
                return this._dtSonTarih;
            }
            set
            {
                this._dtSonTarih = value;
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
                SqlCommand cmd = new SqlCommand("sp_ArananGorevEkle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@tintGorevID", SqlDbType.TinyInt).Value = this._tintGorevID;
                cmd.Parameters.Add("@tintOgrenimDurumuID", SqlDbType.TinyInt).Value = this._tintOgrenimDurumuID;
                cmd.Parameters.Add("@tintAskerlikDurumuID", SqlDbType.TinyInt).Value = this._tintAskerlikDurumuID;
                cmd.Parameters.Add("@tintMedeniDurumID", SqlDbType.TinyInt).Value = this._tintMedeniDurumID;
                cmd.Parameters.Add("@tintIlID", SqlDbType.TinyInt).Value = this._tintIlID;
                cmd.Parameters.Add("@sintIlceID", SqlDbType.SmallInt).Value = this._sintIlceID;
                cmd.Parameters.Add("@strTecrube", SqlDbType.NVarChar, 20).Value = this._strTecrube;
                cmd.Parameters.Add("@blPasif", SqlDbType.Bit).Value = this._blPasif;
                cmd.Parameters.Add("@dtSonTarih", SqlDbType.SmallDateTime).Value = this._dtSonTarih;
                cmd.Parameters.Add("@pkArananGorevID", SqlDbType.Int).Direction = ParameterDirection.Output;
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    this._pkArananGorevID = Convert.ToInt32(cmd.Parameters["@pkArananGorevID"].Value);
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
                SqlCommand cmd = new SqlCommand("sp_ArananGorevGuncelle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkArananGorevID", SqlDbType.Int).Value = this._pkArananGorevID;
                cmd.Parameters.Add("@tintGorevID", SqlDbType.TinyInt).Value = this._tintGorevID;
                cmd.Parameters.Add("@tintOgrenimDurumuID", SqlDbType.TinyInt).Value = this._tintOgrenimDurumuID;
                cmd.Parameters.Add("@tintAskerlikDurumuID", SqlDbType.TinyInt).Value = this._tintAskerlikDurumuID;
                cmd.Parameters.Add("@tintMedeniDurumID", SqlDbType.TinyInt).Value = this._tintMedeniDurumID;
                cmd.Parameters.Add("@tintIlID", SqlDbType.TinyInt).Value = this._tintIlID;
                cmd.Parameters.Add("@sintIlceID", SqlDbType.SmallInt).Value = this._sintIlceID;
                cmd.Parameters.Add("@strTecrube", SqlDbType.NVarChar, 20).Value = this._strTecrube;
                cmd.Parameters.Add("@blPasif", SqlDbType.Bit).Value = this._blPasif;
                cmd.Parameters.Add("@dtSonTarih", SqlDbType.SmallDateTime).Value = this._dtSonTarih;
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
                SqlCommand cmd = new SqlCommand("sp_ArananGorevSil", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkArananGorevID", SqlDbType.Int).Value = this._pkArananGorevID;
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
        public static void DoDelete(int ArananGorevID)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_ArananGorevSil", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkArananGorevID", SqlDbType.Int).Value = ArananGorevID;
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
        public static void DoLikeDelete(int ArananGorevID)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_ArananGorevSilGibi", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkArananGorevID", SqlDbType.Int).Value = ArananGorevID;
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
        public static void DoUndoDelete(int ArananGorevID)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_ArananGorevSilmeGeriAl", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkArananGorevID", SqlDbType.Int).Value = ArananGorevID;
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
        public static void GetObject(IList List)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                List.Clear();

                SqlCommand cmd = new SqlCommand("sp_ArananGorevGetir", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        List.Add(new ArananGorevler(Convert.ToInt32(dr[0]), Convert.ToByte(dr[1]), Convert.ToByte(dr[2]), Convert.ToByte(dr[3]), Convert.ToByte(dr[4]),
                            Convert.ToByte(dr[5]), Convert.ToInt16(dr[6]), dr[7].ToString(), Convert.ToBoolean(dr[8]), DateTime.Parse(dr[9].ToString())));
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
        public static object GetObject(DateTime Simdi)
        {
            DataTable donendeger = new DataTable();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_ArananGorevGetir", conn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@dtSonTarih", SqlDbType.SmallDateTime).Value = Simdi;
                try
                {
                    conn.Open();
                    da.Fill(donendeger);
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

            donendeger.Columns.Add("Basvur");

            if (donendeger.Rows.Count > 0)
            {
                for (int i = 0; i < donendeger.Rows.Count; i++)
                {
                    donendeger.Rows[i][5] = StringParcalama.IlkHarfBuyuk(donendeger.Rows[i][5].ToString());
                    donendeger.Rows[i][6] = StringParcalama.IlkHarfBuyuk(donendeger.Rows[i][6].ToString());
                    donendeger.Rows[i][7] = StringParcalama.IlkHarfBuyuk(donendeger.Rows[i][7].ToString());
                    donendeger.Rows[i][8] = "<a href='isbasvuru.aspx?id=" + donendeger.Rows[i][0] + "'>Ba&#351;vur</a>";
                }
            }
            else
            {
                DataRow drow = donendeger.NewRow();
                drow[2] = "Şu anda bulunmamaktadır.";
                donendeger.Rows.Add(drow);
            }

            return donendeger;
        }
        //
        //
        public static object GetObject(bool UI)
        {
            DataTable donendeger = new DataTable();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_ArananGorevGetirUI", conn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                try
                {
                    conn.Open();
                    da.Fill(donendeger);
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

            for (int i = 0; i < donendeger.Rows.Count; i++)
            {
                donendeger.Rows[i][5] = StringParcalama.IlkHarfBuyuk(donendeger.Rows[i][5].ToString());
                donendeger.Rows[i][6] = StringParcalama.IlkHarfBuyuk(donendeger.Rows[i][6].ToString());
            }

            return donendeger;
        }
        //
        //
        public static int GetObjectByID(int ArananGorevID, DateTime Simdi)
        {
            int donendeger = 0;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_ArananGorevGetirArananGorevIDyeGore", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkArananGorevID", SqlDbType.Int).Value = ArananGorevID;
                cmd.Parameters.Add("@dtSonTarih", SqlDbType.SmallDateTime).Value = Simdi;
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
    }
}

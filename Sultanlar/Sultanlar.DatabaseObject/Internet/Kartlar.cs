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
    /// <summary>
    /// Buradaki SMREF, GMREF demektir çünkü ödeme gmref e yapılır dolayısıyla kartı da gmref için kaydedeceğiz
    /// </summary>
    public class Kartlar : ISultanlar, IDisposable
    {
        //
        //
        //
        // Alanlar:
        //
        private int _pkID;
        private int _intMusteriID;
        private int _SMREF;
        private int _intBankaID;
        private string _strAd;
        private string _strNumara;
        private string _strGuvenlik;
        private string _strYil;
        private string _strAy;
        private string _strTip;
        private DateTime _dtEklenmeZamani;
        //
        //
        //
        // Constracter lar:
        //
        private Kartlar(int pkID, int intMusteriID, int SMREF, int intBankaID, string strAd, string strNumara, string strGuvenlik, string strYil, 
            string strAy, string strTip, DateTime dtEklenmeZamani)
        {
            this._pkID = pkID;
            this._intMusteriID = intMusteriID;
            this._SMREF = SMREF;
            this._intBankaID = intBankaID;
            this._strAd = strAd;
            this._strNumara = strNumara;
            this._strGuvenlik = strGuvenlik;
            this._strYil = strYil;
            this._strAy = strAy;
            this._strTip = strTip;
            this._dtEklenmeZamani = dtEklenmeZamani;
        }
        //
        //
        public Kartlar(int intMusteriID, int SMREF, int intBankaID, string strAd, string strNumara, string strGuvenlik, string strYil, string strAy,
            string strTip, DateTime dtEklenmeZamani)
        {
            this._intMusteriID = intMusteriID;
            this._SMREF = SMREF;
            this._intBankaID = intBankaID;
            this._strAd = strAd;
            this._strNumara = strNumara;
            this._strGuvenlik = strGuvenlik;
            this._strYil = strYil;
            this._strAy = strAy;
            this._strTip = strTip;
            this._dtEklenmeZamani = dtEklenmeZamani;
        }
        //
        //
        //
        // Özellikler:
        //
        public int pkID { get { return this._pkID; } }
        public int intMusteriID { get { return this._intMusteriID; } set { this._intMusteriID = value; } }
        public int SMREF { get { return this._SMREF; } set { this._SMREF = value; } }
        public int intBankaID { get { return this._intBankaID; } set { this._intBankaID = value; } }
        public string strAd { get { return this._strAd; } set { this._strAd = value; } }
        public string strNumara { get { return this._strNumara; } set { this._strNumara = value; } }
        public string strGuvenlik { get { return this._strGuvenlik; } set { this._strGuvenlik = value; } }
        public string strYil { get { return this._strYil; } set { this._strYil = value; } }
        public string strAy { get { return this._strAy; } set { this._strAy = value; } }
        public string strTip { get { return this._strTip; } set { this._strTip = value; } }
        public DateTime dtEklenmeZamani { get { return this._dtEklenmeZamani; } set { this._dtEklenmeZamani = value; } }
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
            return this._strAd;
        }
        //
        //
        //
        // Metodlar:
        //
        public void DoInsert()
        {
            object EklenmeZamani = DBNull.Value;
            if (_dtEklenmeZamani != DateTime.MinValue)
                EklenmeZamani = this._dtEklenmeZamani;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_INTERNET_KartEkle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@intMusteriID", SqlDbType.Int).Value = this._intMusteriID;
                cmd.Parameters.Add("@SMREF", SqlDbType.Int).Value = this._SMREF;
                cmd.Parameters.Add("@intBankaID", SqlDbType.Int).Value = this._intBankaID;
                cmd.Parameters.Add("@strAd", SqlDbType.NVarChar).Value = this._strAd;
                cmd.Parameters.Add("@strNumara", SqlDbType.NVarChar).Value = this._strNumara;
                cmd.Parameters.Add("@strGuvenlik", SqlDbType.NVarChar).Value = this._strGuvenlik;
                cmd.Parameters.Add("@strYil", SqlDbType.NVarChar).Value = this._strYil;
                cmd.Parameters.Add("@strAy", SqlDbType.NVarChar).Value = this._strAy;
                cmd.Parameters.Add("@strTip", SqlDbType.NVarChar).Value = this._strTip;
                cmd.Parameters.Add("@dtEklenmeZamani", SqlDbType.DateTime).Value = EklenmeZamani;
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
            object EklenmeZamani = DBNull.Value;
            if (_dtEklenmeZamani != DateTime.MinValue)
                EklenmeZamani = this._dtEklenmeZamani;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_INTERNET_KartGuncelle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkID", SqlDbType.Int).Value = this._pkID;
                cmd.Parameters.Add("@intMusteriID", SqlDbType.Int).Value = this._intMusteriID;
                cmd.Parameters.Add("@SMREF", SqlDbType.Int).Value = this._SMREF;
                cmd.Parameters.Add("@intBankaID", SqlDbType.Int).Value = this._intBankaID;
                cmd.Parameters.Add("@strAd", SqlDbType.NVarChar).Value = this._strAd;
                cmd.Parameters.Add("@strNumara", SqlDbType.NVarChar).Value = this._strNumara;
                cmd.Parameters.Add("@strGuvenlik", SqlDbType.NVarChar).Value = this._strGuvenlik;
                cmd.Parameters.Add("@strYil", SqlDbType.NVarChar).Value = this._strYil;
                cmd.Parameters.Add("@strAy", SqlDbType.NVarChar).Value = this._strAy;
                cmd.Parameters.Add("@strTip", SqlDbType.NVarChar).Value = this._strTip;
                cmd.Parameters.Add("@dtEklenmeZamani", SqlDbType.DateTime).Value = EklenmeZamani;
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
                SqlCommand cmd = new SqlCommand("sp_INTERNET_KartSil", conn);
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
        public static void GetObjects(IList List, bool UI)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                List.Clear();

                SqlCommand cmd = new SqlCommand("sp_INTERNET_KartlarGetir", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        DateTime EklenmeZamani = DateTime.MinValue;
                        if (dr[10] != DBNull.Value)
                            EklenmeZamani = Convert.ToDateTime(dr[10]);

                        List.Add(new Kartlar(Convert.ToInt32(dr[0]), Convert.ToInt32(dr[1]), Convert.ToInt32(dr[2]), 
                            Convert.ToInt32(dr[3]), dr[4].ToString(),
                            dr[5].ToString(), dr[6].ToString(), dr[7].ToString(), dr[8].ToString(), dr[9].ToString(),
                            EklenmeZamani));
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
        public static void GetObjects(ListItemCollection lic, int MusteriID)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                lic.Clear();
                lic.Add(new ListItem("Yeni Kredi Kartı", "0"));

                SqlCommand cmd = new SqlCommand("sp_INTERNET_KartlarGetirByMusteriID", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@intMusteriID", SqlDbType.Int).Value = MusteriID;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                        lic.Add(new ListItem(dr[4].ToString(), dr[0].ToString()));
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
        public static void GetObjectsSATTEMMUSTERIADbySMREF(ListItemCollection lic, int SMREF)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                lic.Clear();
                lic.Add(new ListItem("Yeni Kredi Kartı", "0"));

                SqlCommand cmd = new SqlCommand("SELECT DISTINCT [KurumsalWebSAP].[dbo].[tblINTERNET_Kartlar].[pkID],[Web-SatisTemsilcileri].[SAT TEM],[Web-Musteri].[MUSTERI],[KurumsalWebSAP].[dbo].[tblINTERNET_Kartlar].[strAd] FROM [KurumsalWebSAP].[dbo].[tblINTERNET_Kartlar] INNER JOIN [Web-Musteri] ON [KurumsalWebSAP].[dbo].[tblINTERNET_Kartlar].[SMREF] = [Web-Musteri].[GMREF] INNER JOIN [Web-SatisTemsilcileri] ON [Web-Musteri].[SLSREF] = [Web-SatisTemsilcileri].[SLSMANREF] WHERE [KurumsalWebSAP].[dbo].[tblINTERNET_Kartlar].[SMREF] = @SMREF AND [Web-Musteri].[SAT KOD1] NOT LIKE '8%' ORDER BY [Web-SatisTemsilcileri].[SAT TEM],[Web-Musteri].[MUSTERI],[KurumsalWebSAP].[dbo].[tblINTERNET_Kartlar].[strAd]", conn);
                cmd.Parameters.Add("@SMREF", SqlDbType.Int).Value = SMREF;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                        lic.Add(new ListItem(dr[1].ToString() + " - " + dr[2].ToString() + " - " + dr[3].ToString(), dr[0].ToString()));
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
        public static void GetObjectsBySMREF(ListItemCollection lic, int SMREF)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                lic.Clear();
                lic.Add(new ListItem("Yeni Kredi Kartı", "0"));

                if (SMREF == 24479) // perakende satış kredi kartlarının hepsi gelmemesi için
                    return;

                SqlCommand cmd = new SqlCommand("sp_INTERNET_KartlarGetirBySMREF", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@SMREF", SqlDbType.Int).Value = SMREF;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                        lic.Add(new ListItem(dr[4].ToString(), dr[0].ToString()));
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
        public static ArrayList GetObject(int ID)
        {
            ArrayList donendeger = new ArrayList();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_INTERNET_KartGetir", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkID", SqlDbType.Int).Value = ID;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        donendeger.Add(dr[3].ToString());
                        donendeger.Add(dr[4].ToString());
                        donendeger.Add(dr[5].ToString());
                        donendeger.Add(dr[6].ToString());
                        donendeger.Add(dr[7].ToString());
                        donendeger.Add(dr[8].ToString());
                        donendeger.Add(dr[9].ToString());
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

            return donendeger;
        }
        //
        //
        public static void GetObjects(DataTable dt, int MusteriID)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_INTERNET_KartlarGetirByMusteriID", conn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@intMusteriID", SqlDbType.Int).Value = MusteriID;
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
        public static Kartlar GetObject(int ID, bool Class)
        {
            Kartlar donendeger = null;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_INTERNET_KartGetir", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkID", SqlDbType.Int).Value = ID;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        DateTime EklenmeZamani = DateTime.MinValue;
                        if (dr[10] != DBNull.Value)
                            EklenmeZamani = Convert.ToDateTime(dr[10]);

                        donendeger = new Kartlar(Convert.ToInt32(dr[0]), Convert.ToInt32(dr[1]), Convert.ToInt32(dr[2]),
                            Convert.ToInt32(dr[3]), dr[4].ToString(),
                            dr[5].ToString(), dr[6].ToString(), dr[7].ToString(), dr[8].ToString(), dr[9].ToString(),
                            EklenmeZamani);
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

            return donendeger;
        }
    }
}

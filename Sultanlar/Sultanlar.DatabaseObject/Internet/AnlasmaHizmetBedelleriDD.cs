using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Sultanlar.DatabaseObject.Internet
{
    public class AnlasmaHizmetBedelleriDD : ISultanlar, IDisposable
    {
        //
        //
        //
        // Alanlar:
        //
        private int _pkID;
        private DateTime _dtTarih;
        private int _GMREF;
        private int _intAnlasmaBedelAdID;
        private int _intAy;
        private int _intYil;
        private string _strFaturaNo;
        private DateTime _dtFaturaTarih;
        private string _strBolum;
        private decimal _mnNet;
        private decimal _mnKDV;
        private DateTime _dtMuhasebeTeslim;
        private string _strAciklama1;
        private string _strAciklama2;
        private string _strAciklama3;
        private string _strAciklama4;
        private bool _blMaliyetEtki;
        //
        //
        //
        // Constracter lar:
        //
        private AnlasmaHizmetBedelleriDD()
        {

        }
        //
        //
        private AnlasmaHizmetBedelleriDD(int pkID, DateTime dtTarih, int GMREF, int intAnlasmaBedelAdID, int intAy, int intYil, string strFaturaNo,
            DateTime dtFaturaTarih, string strBolum, decimal mnNet, decimal mnKDV, DateTime dtMuhasebeTeslim,
            string strAciklama1, string strAciklama2, string strAciklama3, string strAciklama4, bool blMaliyetEtki)
        {
            this._pkID = pkID;
            this._dtTarih = dtTarih;
            this._GMREF = GMREF;
            this._intAnlasmaBedelAdID = intAnlasmaBedelAdID;
            this._intAy = intAy;
            this._intYil = intYil;
            this._strFaturaNo = strFaturaNo;
            this._dtFaturaTarih = dtFaturaTarih;
            this._strBolum = strBolum;
            this._mnNet = mnNet;
            this._mnKDV = mnKDV;
            this._dtMuhasebeTeslim = dtMuhasebeTeslim;
            this._strAciklama1 = strAciklama1;
            this._strAciklama2 = strAciklama2;
            this._strAciklama3 = strAciklama3;
            this._strAciklama4 = strAciklama4;
            this._blMaliyetEtki = blMaliyetEtki;
        }
        //
        //
        public AnlasmaHizmetBedelleriDD(DateTime dtTarih, int GMREF, int intAnlasmaBedelAdID, int intAy, int intYil, string strFaturaNo,
            DateTime dtFaturaTarih, string strBolum, decimal mnNet, decimal mnKDV, DateTime dtMuhasebeTeslim,
            string strAciklama1, string strAciklama2, string strAciklama3, string strAciklama4, bool blMaliyetEtki)
        {
            this._dtTarih = dtTarih;
            this._GMREF = GMREF;
            this._intAnlasmaBedelAdID = intAnlasmaBedelAdID;
            this._intAy = intAy;
            this._intYil = intYil;
            this._strFaturaNo = strFaturaNo;
            this._dtFaturaTarih = dtFaturaTarih;
            this._strBolum = strBolum;
            this._mnNet = mnNet;
            this._mnKDV = mnKDV;
            this._dtMuhasebeTeslim = dtMuhasebeTeslim;
            this._strAciklama1 = strAciklama1;
            this._strAciklama2 = strAciklama2;
            this._strAciklama3 = strAciklama3;
            this._strAciklama4 = strAciklama4;
            this._blMaliyetEtki = blMaliyetEtki;
        }
        //
        //
        //
        // Özellikler:
        //
        public int pkID { get { return this._pkID; } }
        public DateTime dtTarih { get { return this._dtTarih; } set { this._dtTarih = value; } }
        public int GMREF { get { return this._GMREF; } set { this._GMREF = value; } }
        public int intAnlasmaBedelAdID { get { return this._intAnlasmaBedelAdID; } set { this._intAnlasmaBedelAdID = value; } }
        public int intAy { get { return this._intAy; } set { this._intAy = value; } }
        public int intYil { get { return this._intYil; } set { this._intYil = value; } }
        public string strFaturaNo { get { return this._strFaturaNo; } set { this._strFaturaNo = value; } }
        public DateTime dtFaturaTarih { get { return this._dtFaturaTarih; } set { this._dtFaturaTarih = value; } }
        public string strBolum { get { return this._strBolum; } set { this._strBolum = value; } }
        public decimal mnNet { get { return this._mnNet; } set { this._mnNet = value; } }
        public decimal mnKDV { get { return this._mnKDV; } set { this._mnKDV = value; } }
        public DateTime dtMuhasebeTeslim { get { return this._dtMuhasebeTeslim; } set { this._dtMuhasebeTeslim = value; } }
        public string strAciklama1 { get { return this._strAciklama1; } set { this._strAciklama1 = value; } }
        public string strAciklama2 { get { return this._strAciklama2; } set { this._strAciklama2 = value; } }
        public string strAciklama3 { get { return this._strAciklama3; } set { this._strAciklama3 = value; } }
        public string strAciklama4 { get { return this._strAciklama4; } set { this._strAciklama4 = value; } }
        public bool blMaliyetEtki { get { return this._blMaliyetEtki; } set { this._blMaliyetEtki = value; } }
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
            return this._pkID.ToString();
        }
        //
        //
        public void DoInsert()
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_INTERNET_AnlasmaHizmetBedeliDDEkle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@dtTarih", SqlDbType.DateTime).Value = this._dtTarih;
                cmd.Parameters.Add("@GMREF", SqlDbType.Int).Value = this._GMREF;
                cmd.Parameters.Add("@intAnlasmaBedelAdID", SqlDbType.Int).Value = this._intAnlasmaBedelAdID;
                cmd.Parameters.Add("@intAy", SqlDbType.Int).Value = this._intAy;
                cmd.Parameters.Add("@intYil", SqlDbType.Int).Value = this._intYil;
                cmd.Parameters.Add("@strFaturaNo", SqlDbType.VarChar, 25).Value = this._strFaturaNo;
                cmd.Parameters.Add("@dtFaturaTarihi", SqlDbType.SmallDateTime).Value = this._dtFaturaTarih;
                cmd.Parameters.Add("@strBolum", SqlDbType.VarChar, 20).Value = this._strBolum;
                cmd.Parameters.Add("@mnNet", SqlDbType.Money).Value = this._mnNet;
                cmd.Parameters.Add("@mnKDV", SqlDbType.Money).Value = this._mnKDV;
                cmd.Parameters.Add("@dtMuhasebeTeslim", SqlDbType.DateTime).Value = this._dtMuhasebeTeslim;
                cmd.Parameters.Add("@strAciklama", SqlDbType.NVarChar).Value = this._strAciklama1;
                cmd.Parameters.Add("@strAciklama2", SqlDbType.NVarChar).Value = this._strAciklama2;
                cmd.Parameters.Add("@strAciklama3", SqlDbType.NVarChar).Value = this._strAciklama3;
                cmd.Parameters.Add("@strAciklama4", SqlDbType.NVarChar).Value = this._strAciklama4;
                cmd.Parameters.Add("@blMaliyetEtki", SqlDbType.Bit).Value = this._blMaliyetEtki;
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
                SqlCommand cmd = new SqlCommand("sp_INTERNET_AnlasmaHizmetBedeliDDGuncelle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkID", SqlDbType.Int).Value = this._pkID;
                cmd.Parameters.Add("@dtTarih", SqlDbType.DateTime).Value = this._dtTarih;
                cmd.Parameters.Add("@GMREF", SqlDbType.Int).Value = this._GMREF;
                cmd.Parameters.Add("@intAnlasmaBedelAdID", SqlDbType.Int).Value = this._intAnlasmaBedelAdID;
                cmd.Parameters.Add("@intAy", SqlDbType.Int).Value = this._intAy;
                cmd.Parameters.Add("@intYil", SqlDbType.Int).Value = this._intYil;
                cmd.Parameters.Add("@strFaturaNo", SqlDbType.VarChar, 25).Value = this._strFaturaNo;
                cmd.Parameters.Add("@dtFaturaTarihi", SqlDbType.SmallDateTime).Value = this._dtFaturaTarih;
                cmd.Parameters.Add("@strBolum", SqlDbType.VarChar, 20).Value = this._strBolum;
                cmd.Parameters.Add("@mnNet", SqlDbType.Money).Value = this._mnNet;
                cmd.Parameters.Add("@mnKDV", SqlDbType.Money).Value = this._mnKDV;
                cmd.Parameters.Add("@dtMuhasebeTeslim", SqlDbType.DateTime).Value = this._dtMuhasebeTeslim;
                cmd.Parameters.Add("@strAciklama", SqlDbType.NVarChar).Value = this._strAciklama1;
                cmd.Parameters.Add("@strAciklama2", SqlDbType.NVarChar).Value = this._strAciklama2;
                cmd.Parameters.Add("@strAciklama3", SqlDbType.NVarChar).Value = this._strAciklama3;
                cmd.Parameters.Add("@strAciklama4", SqlDbType.NVarChar).Value = this._strAciklama4;
                cmd.Parameters.Add("@blMaliyetEtki", SqlDbType.Bit).Value = this._blMaliyetEtki;
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
                SqlCommand cmd = new SqlCommand("sp_INTERNET_AnlasmaHizmetBedeliDDSil", conn);
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
        public static void GetObjects(DataTable dt, string Kullanici)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_INTERNET_AnlasmaHizmetBedelleriDDGetir", conn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@Kullanici", SqlDbType.NVarChar, 50).Value = Kullanici;
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
        public static AnlasmaHizmetBedelleriDD GetObject(int ID)
        {
            AnlasmaHizmetBedelleriDD anlasmahizmetbedeli = new AnlasmaHizmetBedelleriDD();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_INTERNET_AnlasmaHizmetBedeliDDGetir", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkID", SqlDbType.Int).Value = ID;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        anlasmahizmetbedeli = new AnlasmaHizmetBedelleriDD(
                            Convert.ToInt32(dr[0]), Convert.ToDateTime(dr[1]), Convert.ToInt32(dr[2]), Convert.ToInt32(dr[3]),
                            Convert.ToInt32(dr[4]), Convert.ToInt32(dr[5]), dr[6].ToString(), Convert.ToDateTime(dr[7]), dr[8].ToString(),
                            Convert.ToDecimal(dr[9]), Convert.ToDecimal(dr[10]), Convert.ToDateTime(dr[11]), 
                            dr[12].ToString(), dr[13].ToString(), dr[14].ToString(), dr[15].ToString(), Convert.ToBoolean(dr[16]));
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

            return anlasmahizmetbedeli;
        }
        //
        //
        public static bool VarMi(string FatNo)
        {
            bool anlasmahizmetbedeli = false;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT count(*) FROM tblINTERNET_AnlasmaHizmetBedelleriDD WHERE strFaturaNo = @strFaturaNo", conn);
                cmd.Parameters.Add("@strFaturaNo", SqlDbType.VarChar, 25).Value = FatNo;
                try
                {
                    conn.Open();
                    anlasmahizmetbedeli = Convert.ToBoolean(cmd.ExecuteScalar());
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

            return anlasmahizmetbedeli;
        }
    }
}

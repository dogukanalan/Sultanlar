using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace Sultanlar.DatabaseObject.Internet
{
    public class AnlasmaBedeller : ISultanlar, IDisposable
    {
        //
        //
        //
        // Alanlar:
        //
        private int _pkID;
        private int _intAnlasmaID;
        private int _intAnlasmaBedelAdID;
        private int _intTAHAdet;
        private decimal _mnTAHBedel;
        private double _flTAHIsk;
        private int _intYEGAdet;
        private decimal _mnYEGBedel;
        private double _flYEGIsk;
        private string _strAciklama1;
        private string _strAciklama2;
        private string _strAciklama3;
        private string _strAciklama4;
        //
        //
        //
        // Constracter lar:
        //
        private AnlasmaBedeller(int pkID, int intAnlasmaID, int intAnlasmaBedelAdID, int intTAHAdet, decimal mnTAHBedel, double flTAHIsk,
            int intYEGAdet, decimal mnYEGBedel, double flYEGIsk, string strAciklama1, string strAciklama2, string strAciklama3, string strAciklama4)
        {
            this._pkID = pkID;
            this._intAnlasmaID = intAnlasmaID;
            this._intAnlasmaBedelAdID = intAnlasmaBedelAdID;
            this._intTAHAdet = intTAHAdet;
            this._mnTAHBedel = mnTAHBedel;
            this._flTAHIsk = flTAHIsk;
            this._intYEGAdet = intYEGAdet;
            this._mnYEGBedel = mnYEGBedel;
            this._flYEGIsk = flYEGIsk;
            this._strAciklama1 = strAciklama1;
            this._strAciklama2 = strAciklama2;
            this._strAciklama3 = strAciklama3;
            this._strAciklama4 = strAciklama4;
        }
        //
        //
        public AnlasmaBedeller(int intAnlasmaID, int intAnlasmaBedelAdID, int intTAHAdet, decimal mnTAHBedel, double flTAHIsk,
            int intYEGAdet, decimal mnYEGBedel, double flYEGIsk, string strAciklama1, string strAciklama2, string strAciklama3, string strAciklama4)
        {
            this._intAnlasmaID = intAnlasmaID;
            this._intAnlasmaBedelAdID = intAnlasmaBedelAdID;
            this._intTAHAdet = intTAHAdet;
            this._mnTAHBedel = mnTAHBedel;
            this._flTAHIsk = flTAHIsk;
            this._intYEGAdet = intYEGAdet;
            this._mnYEGBedel = mnYEGBedel;
            this._flYEGIsk = flYEGIsk;
            this._strAciklama1 = strAciklama1;
            this._strAciklama2 = strAciklama2;
            this._strAciklama3 = strAciklama3;
            this._strAciklama4 = strAciklama4;
        }
        //
        //
        //
        // Özellikler:
        //
        public int pkID { get { return this._pkID; } }
        public int intAnlasmaID { get { return this._intAnlasmaID; } set { this._intAnlasmaID = value; } }
        public int intAnlasmaBedelAdID { get { return this._intAnlasmaBedelAdID; } set { this._intAnlasmaBedelAdID = value; } }
        public int intTAHAdet { get { return this._intTAHAdet; } set { this._intTAHAdet = value; } }
        public decimal mnTAHBedel { get { return this._mnTAHBedel; } set { this._mnTAHBedel = value; } }
        public double flTAHIsk { get { return this._flTAHIsk; } set { this._flTAHIsk = value; } }
        public int intYEGAdet { get { return this._intYEGAdet; } set { this._intYEGAdet = value; } }
        public decimal mnYEGBedel { get { return this._mnYEGBedel; } set { this._mnYEGBedel = value; } }
        public double flYEGIsk { get { return this._flYEGIsk; } set { this._flYEGIsk = value; } }
        public string strAciklama1 { get { return this._strAciklama1; } set { this._strAciklama1 = value; } }
        public string strAciklama2 { get { return this._strAciklama2; } set { this._strAciklama2 = value; } }
        public string strAciklama3 { get { return this._strAciklama3; } set { this._strAciklama3 = value; } }
        public string strAciklama4 { get { return this._strAciklama4; } set { this._strAciklama4 = value; } }
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
            return AnlasmaBedelAdlari.GetObjectByID(this._intAnlasmaBedelAdID);
        }
        //
        //
        public void DoInsert()
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_INTERNET_AnlasmaBedelEkle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@intAnlasmaID", SqlDbType.Int).Value = this._intAnlasmaID;
                cmd.Parameters.Add("@intAnlasmaBedelAdID", SqlDbType.Int).Value = this._intAnlasmaBedelAdID;
                cmd.Parameters.Add("@intTAHAdet", SqlDbType.Int).Value = this._intTAHAdet;
                cmd.Parameters.Add("@mnTAHBedel", SqlDbType.Money).Value = this._mnTAHBedel;
                cmd.Parameters.Add("@flTAHIsk", SqlDbType.Float).Value = this._flTAHIsk;
                cmd.Parameters.Add("@intYEGAdet", SqlDbType.Int).Value = this._intYEGAdet;
                cmd.Parameters.Add("@mnYEGBedel", SqlDbType.Money).Value = this._mnYEGBedel;
                cmd.Parameters.Add("@flYEGIsk", SqlDbType.Float).Value = this._flYEGIsk;
                cmd.Parameters.Add("@strAciklama1", SqlDbType.NVarChar).Value = this._strAciklama1;
                cmd.Parameters.Add("@strAciklama2", SqlDbType.NVarChar).Value = this._strAciklama2;
                cmd.Parameters.Add("@strAciklama3", SqlDbType.NVarChar).Value = this._strAciklama3;
                cmd.Parameters.Add("@strAciklama4", SqlDbType.NVarChar).Value = this._strAciklama4;
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
                SqlCommand cmd = new SqlCommand("sp_INTERNET_AnlasmaBedelGuncelle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkID", SqlDbType.Int).Value = this._pkID;
                cmd.Parameters.Add("@intAnlasmaID", SqlDbType.Int).Value = this._intAnlasmaID;
                cmd.Parameters.Add("@intAnlasmaBedelAdID", SqlDbType.Int).Value = this._intAnlasmaBedelAdID;
                cmd.Parameters.Add("@intTAHAdet", SqlDbType.Int).Value = this._intTAHAdet;
                cmd.Parameters.Add("@mnTAHBedel", SqlDbType.Money).Value = this._mnTAHBedel;
                cmd.Parameters.Add("@flTAHIsk", SqlDbType.Float).Value = this._flTAHIsk;
                cmd.Parameters.Add("@intYEGAdet", SqlDbType.Int).Value = this._intYEGAdet;
                cmd.Parameters.Add("@mnYEGBedel", SqlDbType.Money).Value = this._mnYEGBedel;
                cmd.Parameters.Add("@flYEGIsk", SqlDbType.Float).Value = this._flYEGIsk;
                cmd.Parameters.Add("@strAciklama1", SqlDbType.NVarChar).Value = this._strAciklama1;
                cmd.Parameters.Add("@strAciklama2", SqlDbType.NVarChar).Value = this._strAciklama2;
                cmd.Parameters.Add("@strAciklama3", SqlDbType.NVarChar).Value = this._strAciklama3;
                cmd.Parameters.Add("@strAciklama4", SqlDbType.NVarChar).Value = this._strAciklama4;
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
                SqlCommand cmd = new SqlCommand("sp_INTERNET_AnlasmaBedelSil", conn);
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
        public static void GetObjects(DataTable dt, int AnlasmaID)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_INTERNET_AnlasmaBedellerGetir", conn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@intAnlasmaID", SqlDbType.Int).Value = AnlasmaID;
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
        public static void GetObjects(DataTable dt, int AnlasmaID, bool kapanankolonlari)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT tblINTERNET_AnlasmaBedeller.[pkID],[intAnlasmaID],[intAnlasmaBedelAdID],CASE WHEN (([mnTAHBedel] * intTAHAdet) - (SELECT sum(mnTAHBedel) FROM tblINTERNET_AnlasmaHizmetBedelleri WHERE intAnlasmaBedelID = [tblINTERNET_AnlasmaBedeller].pkID)) = 0 AND (([mnYEGBedel] * intYEGAdet) - (SELECT sum(mnYEGBedel) FROM tblINTERNET_AnlasmaHizmetBedelleri WHERE intAnlasmaBedelID = [tblINTERNET_AnlasmaBedeller].pkID)) = 0 THEN CONVERT(bit,'True') ELSE CONVERT(bit,'False') END AS Kapatilmis,(SELECT sum(mnTAHBedel) FROM tblINTERNET_AnlasmaHizmetBedelleri WHERE intAnlasmaBedelID = [tblINTERNET_AnlasmaBedeller].pkID) AS KapananTAH,(SELECT sum(mnYEGBedel) FROM tblINTERNET_AnlasmaHizmetBedelleri WHERE intAnlasmaBedelID = [tblINTERNET_AnlasmaBedeller].pkID) AS KapananYEG,([mnTAHBedel] * intTAHAdet) - (SELECT sum(mnTAHBedel) FROM tblINTERNET_AnlasmaHizmetBedelleri WHERE intAnlasmaBedelID = [tblINTERNET_AnlasmaBedeller].pkID) AS TAHFark,([mnYEGBedel] * intYEGAdet) - (SELECT sum(mnYEGBedel) FROM tblINTERNET_AnlasmaHizmetBedelleri WHERE intAnlasmaBedelID = [tblINTERNET_AnlasmaBedeller].pkID) AS YEGFark,[strBedel],[intTAHAdet],[mnTAHBedel],[flTAHIsk],[intYEGAdet],[mnYEGBedel],[flYEGIsk],[strAciklama1],[strAciklama2],[strAciklama3],[strAciklama4] FROM [KurumsalWebSAP].[dbo].[tblINTERNET_AnlasmaBedeller] INNER JOIN tblINTERNET_AnlasmaBedelAdlari ON [tblINTERNET_AnlasmaBedeller].[intAnlasmaBedelAdID] = tblINTERNET_AnlasmaBedelAdlari.pkID WHERE intAnlasmaID = @intAnlasmaID ORDER BY [strBedel]", conn);
                da.SelectCommand.Parameters.Add("@intAnlasmaID", SqlDbType.Int).Value = AnlasmaID;
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
        public static void GetObjects(IList List, int AnlasmaID)
        {
            List.Clear();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_INTERNET_AnlasmaBedellerGetir", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@intAnlasmaID", SqlDbType.Int).Value = AnlasmaID;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        List.Add(new AnlasmaBedeller(Convert.ToInt32(dr[0]), Convert.ToInt32(dr[1]), Convert.ToInt32(dr[2]),
                            Convert.ToInt32(dr[4]), Convert.ToDecimal(dr[5]), Convert.ToDouble(dr[6]), Convert.ToInt32(dr[7]), 
                            Convert.ToDecimal(dr[8]), Convert.ToDouble(dr[9]), dr[10].ToString(), dr[11].ToString(), dr[12].ToString(), 
                            dr[13].ToString()));
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
        public static AnlasmaBedeller GetObject(int ID)
        {
            AnlasmaBedeller anlasmabedel = null;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_INTERNET_AnlasmaBedelGetir", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkID", SqlDbType.Int).Value = ID;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        anlasmabedel = new AnlasmaBedeller(Convert.ToInt32(dr[0]), Convert.ToInt32(dr[1]), Convert.ToInt32(dr[2]),
                            Convert.ToInt32(dr[3]), Convert.ToDecimal(dr[4]), Convert.ToDouble(dr[5]), Convert.ToInt32(dr[6]), 
                            Convert.ToDecimal(dr[7]), Convert.ToDouble(dr[8]), dr[9].ToString(), dr[10].ToString(), dr[11].ToString(), 
                            dr[12].ToString());
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

            return anlasmabedel;
        }
    }
}

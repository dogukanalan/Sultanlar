using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace Sultanlar.DatabaseObject.Internet
{
    public class AnlasmaHizmetBedelleri : ISultanlar, IDisposable
    {
        //
        //
        //
        // Alanlar:
        //
        private int _pkID;
        private int _intMusteriID;
        private int _SMREF;
        private int _intAnlasmaBedelAdID;
        private int _intAy;
        private int _intYil;
        private string _strFaturaNo;
        private DateTime _dtFaturaTarih;
        private decimal _mnTAHBedel;
        private decimal _mnYEGBedel;
        private int _intAnlasmaBedelID;
        private string _strAciklama1;
        private string _strAciklama2;
        private string _strAciklama3;
        private string _strAciklama4;
        private decimal _mnMudurButce;
        private decimal _mnElemanButce;
        private bool _blKapamaEtki;
        private int _intTAHKDVoran;
        private int _intYEGKDVoran;
        //
        //
        //
        // Constracter lar:
        //
        public AnlasmaHizmetBedelleri()
        {

        }
        //
        //
        private AnlasmaHizmetBedelleri(int pkID, int SMREF, int intMusteriID, int intAnlasmaBedelAdID, int intAy, int intYil, string strFaturaNo, 
            DateTime dtFaturaTarih,
            decimal mnTAHBedel, decimal mnYEGBedel, int intAnlasmaBedelID, string strAciklama1, string strAciklama2, string strAciklama3,
            string strAciklama4, decimal mnMudurButce, decimal mnElemanButce, bool blKapamaEtki, int intTAHKDVoran, int intYEGKDVoran)
        {
            this._pkID = pkID;
            this._intMusteriID = intMusteriID;
            this._SMREF = SMREF;
            this._intAnlasmaBedelAdID = intAnlasmaBedelAdID;
            this._intAy = intAy;
            this._intYil = intYil;
            this._strFaturaNo = strFaturaNo;
            this._dtFaturaTarih = dtFaturaTarih;
            this._mnTAHBedel = mnTAHBedel;
            this._mnYEGBedel = mnYEGBedel;
            this._intAnlasmaBedelID = intAnlasmaBedelID;
            this._strAciklama1 = strAciklama1;
            this._strAciklama2 = strAciklama2;
            this._strAciklama3 = strAciklama3;
            this._strAciklama4 = strAciklama4;
            this._mnMudurButce = mnMudurButce;
            this._mnElemanButce = mnElemanButce;
            this._blKapamaEtki = blKapamaEtki;
            this._intTAHKDVoran = intTAHKDVoran;
            this._intYEGKDVoran = intYEGKDVoran;
        }
        //
        //
        public AnlasmaHizmetBedelleri(int SMREF, int intMusteriID, int intAnlasmaBedelAdID, int intAy, int intYil, string strFaturaNo, 
            DateTime dtFaturaTarih,
            decimal mnTAHBedel, decimal mnYEGBedel, int intAnlasmaBedelID, string strAciklama1, string strAciklama2, string strAciklama3,
            string strAciklama4, decimal mnMudurButce, decimal mnElemanButce, bool blKapamaEtki, int intTAHKDVoran, int intYEGKDVoran)
        {
            this._intMusteriID = intMusteriID;
            this._SMREF = SMREF;
            this._intAnlasmaBedelAdID = intAnlasmaBedelAdID;
            this._intAy = intAy;
            this._intYil = intYil;
            this._strFaturaNo = strFaturaNo;
            this._dtFaturaTarih = dtFaturaTarih;
            this._mnTAHBedel = mnTAHBedel;
            this._mnYEGBedel = mnYEGBedel;
            this._intAnlasmaBedelID = intAnlasmaBedelID;
            this._strAciklama1 = strAciklama1;
            this._strAciklama2 = strAciklama2;
            this._strAciklama3 = strAciklama3;
            this._strAciklama4 = strAciklama4;
            this._mnMudurButce = mnMudurButce;
            this._mnElemanButce = mnElemanButce;
            this._blKapamaEtki = blKapamaEtki;
            this._intTAHKDVoran = intTAHKDVoran;
            this._intYEGKDVoran = intYEGKDVoran;
        }
        //
        //
        //
        // Özellikler:
        //
        public int pkID { get { return this._pkID; } }
        public int intMusteriID { get { return this._intMusteriID; } set { this._intMusteriID = value; } }
        public int SMREF { get { return this._SMREF; } set { this._SMREF = value; } }
        public int intAnlasmaBedelAdID { get { return this._intAnlasmaBedelAdID; } set { this._intAnlasmaBedelAdID = value; } }
        public int intAy { get { return this._intAy; } set { this._intAy = value; } }
        public int intYil { get { return this._intYil; } set { this._intYil = value; } }
        public string strFaturaNo { get { return this._strFaturaNo; } set { this._strFaturaNo = value; } }
        public DateTime dtFaturaTarih { get { return this._dtFaturaTarih; } set { this._dtFaturaTarih = value; } }
        public decimal mnTAHBedel { get { return this._mnTAHBedel; } set { this._mnTAHBedel = value; } }
        public decimal mnYEGBedel { get { return this._mnYEGBedel; } set { this._mnYEGBedel = value; } }
        public int intAnlasmaBedelID { get { return this._intAnlasmaBedelID; } set { this._intAnlasmaBedelID = value; } }
        public string strAciklama1 { get { return this._strAciklama1; } set { this._strAciklama1 = value; } }
        public string strAciklama2 { get { return this._strAciklama2; } set { this._strAciklama2 = value; } }
        public string strAciklama3 { get { return this._strAciklama3; } set { this._strAciklama3 = value; } }
        public string strAciklama4 { get { return this._strAciklama4; } set { this._strAciklama4 = value; } }
        public decimal mnMudurButce { get { return this._mnMudurButce; } set { this._mnMudurButce = value; } }
        public decimal mnElemanButce { get { return this._mnElemanButce; } set { this._mnElemanButce = value; } }
        public bool blKapamaEtki { get { return this._blKapamaEtki; } set { this._blKapamaEtki = value; } }
        public int intTAHKDVoran { get { return this._intTAHKDVoran; } set { this._intTAHKDVoran = value; } }
        public int intYEGKDVoran { get { return this._intYEGKDVoran; } set { this._intYEGKDVoran = value; } }
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
                SqlCommand cmd = new SqlCommand("sp_INTERNET_AnlasmaHizmetBedeliEkle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@intMusteriID", SqlDbType.Int).Value = this._intMusteriID;
                cmd.Parameters.Add("@SMREF", SqlDbType.Int).Value = this._SMREF;
                cmd.Parameters.Add("@intAnlasmaBedelAdID", SqlDbType.Int).Value = this._intAnlasmaBedelAdID;
                cmd.Parameters.Add("@intAy", SqlDbType.Int).Value = this._intAy;
                cmd.Parameters.Add("@intYil", SqlDbType.Int).Value = this._intYil;
                cmd.Parameters.Add("@strFaturaNo", SqlDbType.NVarChar).Value = this._strFaturaNo;
                cmd.Parameters.Add("@dtFaturaTarih", SqlDbType.SmallDateTime).Value = this._dtFaturaTarih;
                cmd.Parameters.Add("@mnTAHBedel", SqlDbType.Money).Value = this._mnTAHBedel;
                cmd.Parameters.Add("@mnYEGBedel", SqlDbType.Money).Value = this._mnYEGBedel;
                cmd.Parameters.Add("@intAnlasmaBedelID", SqlDbType.Int).Value = this._intAnlasmaBedelID;
                cmd.Parameters.Add("@strAciklama1", SqlDbType.NVarChar).Value = this._strAciklama1;
                cmd.Parameters.Add("@strAciklama2", SqlDbType.NVarChar).Value = this._strAciklama2;
                cmd.Parameters.Add("@strAciklama3", SqlDbType.NVarChar).Value = this._strAciklama3;
                cmd.Parameters.Add("@strAciklama4", SqlDbType.NVarChar).Value = this._strAciklama4;
                cmd.Parameters.Add("@mnMudurButcesi", SqlDbType.Money).Value = this._mnMudurButce;
                cmd.Parameters.Add("@mnElemanButcesi", SqlDbType.Money).Value = this._mnElemanButce;
                cmd.Parameters.Add("@blKapamaEtki", SqlDbType.Bit).Value = this._blKapamaEtki;
                cmd.Parameters.Add("@intTAHKDVoran", SqlDbType.Int).Value = this._intTAHKDVoran;
                cmd.Parameters.Add("@intYEGKDVoran", SqlDbType.Int).Value = this._intYEGKDVoran;
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
                SqlCommand cmd = new SqlCommand("sp_INTERNET_AnlasmaHizmetBedeliGuncelle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkID", SqlDbType.Int).Value = this._pkID;
                cmd.Parameters.Add("@intMusteriID", SqlDbType.Int).Value = this._intMusteriID;
                cmd.Parameters.Add("@SMREF", SqlDbType.Int).Value = this._SMREF;
                cmd.Parameters.Add("@intAnlasmaBedelAdID", SqlDbType.Int).Value = this._intAnlasmaBedelAdID;
                cmd.Parameters.Add("@intAy", SqlDbType.Int).Value = this._intAy;
                cmd.Parameters.Add("@intYil", SqlDbType.Int).Value = this._intYil;
                cmd.Parameters.Add("@strFaturaNo", SqlDbType.NVarChar).Value = this._strFaturaNo;
                cmd.Parameters.Add("@dtFaturaTarih", SqlDbType.SmallDateTime).Value = this._dtFaturaTarih;
                cmd.Parameters.Add("@mnTAHBedel", SqlDbType.Money).Value = this._mnTAHBedel;
                cmd.Parameters.Add("@mnYEGBedel", SqlDbType.Money).Value = this._mnYEGBedel;
                cmd.Parameters.Add("@intAnlasmaBedelID", SqlDbType.Int).Value = this._intAnlasmaBedelID;
                cmd.Parameters.Add("@strAciklama1", SqlDbType.NVarChar).Value = this._strAciklama1;
                cmd.Parameters.Add("@strAciklama2", SqlDbType.NVarChar).Value = this._strAciklama2;
                cmd.Parameters.Add("@strAciklama3", SqlDbType.NVarChar).Value = this._strAciklama3;
                cmd.Parameters.Add("@strAciklama4", SqlDbType.NVarChar).Value = this._strAciklama4;
                cmd.Parameters.Add("@mnMudurButcesi", SqlDbType.Money).Value = this._mnMudurButce;
                cmd.Parameters.Add("@mnElemanButcesi", SqlDbType.Money).Value = this._mnElemanButce;
                cmd.Parameters.Add("@blKapamaEtki", SqlDbType.Bit).Value = this._blKapamaEtki;
                cmd.Parameters.Add("@intTAHKDVoran", SqlDbType.Int).Value = this._intTAHKDVoran;
                cmd.Parameters.Add("@intYEGKDVoran", SqlDbType.Int).Value = this._intYEGKDVoran;
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
                SqlCommand cmd = new SqlCommand("sp_INTERNET_AnlasmaHizmetBedeliSil", conn);
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
        public static int GetObjectCount(object Onayli, DateTime BaslangicTarih, DateTime BitisTarih)
        {
            int donendeger = 0;

            string onayli = string.Empty;
            if (Onayli != DBNull.Value)
            {
                if ((bool)Onayli == true)
                    onayli = "AND [intAnlasmaBedelID] > 0";
                else
                    onayli = "AND [intAnlasmaBedelID] = 0";
            }

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT count(*) FROM tblINTERNET_AnlasmaHizmetBedelleri WHERE [dtFaturaTarih] >= @BaslangicTarih AND [dtFaturaTarih] <= @BitisTarih " + onayli, conn);
                cmd.Parameters.Add("@BaslangicTarih", SqlDbType.SmallDateTime).Value = BaslangicTarih;
                cmd.Parameters.Add("@BitisTarih", SqlDbType.SmallDateTime).Value = BitisTarih;
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
        //
        //
        public static void GetObjects(DataTable dt, object Onayli, DateTime BaslangicTarih, DateTime BitisTarih, string Kullanici, int Baslangic, int Adet)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_INTERNET_AnlasmaHizmetBedelleriGetir", conn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@Onayli", SqlDbType.Bit).Value = Onayli;
                da.SelectCommand.Parameters.Add("@BaslangicTarih", SqlDbType.SmallDateTime).Value = BaslangicTarih;
                da.SelectCommand.Parameters.Add("@BitisTarih", SqlDbType.SmallDateTime).Value = BitisTarih;
                da.SelectCommand.Parameters.Add("@Kullanici", SqlDbType.NVarChar, 50).Value = Kullanici;
                try
                {
                    conn.Open();
                    da.Fill(Baslangic, Adet, dt);
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
        public static int GetObjectCount(int SMREF, object Onayli, DateTime BaslangicTarih, DateTime BitisTarih)
        {
            int donendeger = 0;

            string onayli = string.Empty;
            if (Onayli != DBNull.Value)
            {
                if ((bool)Onayli == true)
                    onayli = "AND [intAnlasmaBedelID] > 0";
                else
                    onayli = "AND [intAnlasmaBedelID] = 0";
            }

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT count(*) FROM tblINTERNET_AnlasmaHizmetBedelleri WHERE SMREF = @SMREF AND [dtFaturaTarih] >= @BaslangicTarih AND [dtFaturaTarih] <= @BitisTarih " + onayli, conn);
                cmd.Parameters.Add("@SMREF", SqlDbType.Int).Value = SMREF;
                cmd.Parameters.Add("@BaslangicTarih", SqlDbType.SmallDateTime).Value = BaslangicTarih;
                cmd.Parameters.Add("@BitisTarih", SqlDbType.SmallDateTime).Value = BitisTarih;
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
        //
        //
        public static void GetObjects(DataTable dt, int SMREF, object Onayli, DateTime BaslangicTarih, DateTime BitisTarih, int Baslangic, int Adet)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_INTERNET_AnlasmaHizmetBedelleriGetirBySMREF", conn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@SMREF", SqlDbType.Int).Value = SMREF;
                da.SelectCommand.Parameters.Add("@Onayli", SqlDbType.Bit).Value = Onayli;
                da.SelectCommand.Parameters.Add("@BaslangicTarih", SqlDbType.SmallDateTime).Value = BaslangicTarih;
                da.SelectCommand.Parameters.Add("@BitisTarih", SqlDbType.SmallDateTime).Value = BitisTarih;
                try
                {
                    conn.Open();
                    da.Fill(Baslangic, Adet, dt);
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
        public static int GetObjectCount(ArrayList SMREF, object Onayli, DateTime BaslangicTarih, DateTime BitisTarih)
        {
            int donendeger = 0;

            string onayli = string.Empty;
            if (Onayli != DBNull.Value)
            {
                if ((bool)Onayli == true)
                    onayli = "AND [intAnlasmaBedelID] > 0";
                else
                    onayli = "AND [intAnlasmaBedelID] = 0";
            }

            string smrefs = string.Empty;
            for (int i = 0; i < SMREF.Count; i++)
                smrefs += "SMREF = " + SMREF[i].ToString() + " OR ";
            if (SMREF.Count > 0)
                smrefs = smrefs.Substring(0, smrefs.Length - 3);
            else
                return 0;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT count(*) FROM tblINTERNET_AnlasmaHizmetBedelleri WHERE (" + smrefs + ") AND [dtFaturaTarih] >= @BaslangicTarih AND [dtFaturaTarih] <= @BitisTarih " + onayli, conn);
                cmd.Parameters.Add("@BaslangicTarih", SqlDbType.SmallDateTime).Value = BaslangicTarih;
                cmd.Parameters.Add("@BitisTarih", SqlDbType.SmallDateTime).Value = BitisTarih;
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
        //
        //
        public static void GetObjects(DataTable dt, ArrayList SMREF, object Onayli, DateTime BaslangicTarih, DateTime BitisTarih, int Baslangic, int Adet)
        {
            string onayli = string.Empty;
            if (Onayli != DBNull.Value)
            {
                if ((bool)Onayli == true)
                    onayli = "AND [intAnlasmaBedelID] > 0";
                else
                    onayli = "AND [intAnlasmaBedelID] = 0";
            }

            string smrefs = string.Empty;
            for (int i = 0; i < SMREF.Count; i++)
                smrefs += "tblINTERNET_AnlasmaHizmetBedelleri.SMREF = " + SMREF[i].ToString() + " OR ";
            if (SMREF.Count > 0)
                smrefs = smrefs.Substring(0, smrefs.Length - 3);
            else
                return;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT [pkID],intMusteriID,CASE WHEN [intAnlasmaBedelID] > 0 THEN CONVERT(bit,'True') ELSE CONVERT(bit,'False') END AS Kapatilmis,[SMREF],(SELECT [Web-Musteri-TP].MUSTERI FROM [Web-Musteri-TP] WHERE [Web-Musteri-TP].GMREF = [Web-Musteri-TP].SMREF AND [Web-Musteri-TP].GMREF = (SELECT MUSTERITP.GMREF FROM [Web-Musteri-TP] AS MUSTERITP WHERE MUSTERITP.SMREF = [tblINTERNET_AnlasmaHizmetBedelleri].SMREF)) AS BAYI,(SELECT TOP 1 SUBE FROM [Web-Musteri-TP] WHERE SMREF = [tblINTERNET_AnlasmaHizmetBedelleri].SMREF) AS MUSTERI,[intAnlasmaBedelAdID],(SELECT strBedel FROM tblINTERNET_AnlasmaBedelAdlari WHERE pkID = [tblINTERNET_AnlasmaHizmetBedelleri].[intAnlasmaBedelAdID]) AS Bedel,[intAy],[intYil],[strFaturaNo],[dtFaturaTarih],[mnTAHBedel],[mnYEGBedel],[intAnlasmaBedelID],[strAciklama1],[strAciklama2],[strAciklama3],[strAciklama4],mnMudurButcesi,mnElemanButcesi,blKapamaEtki,intTAHKDVoran,intYEGKDVoran FROM [KurumsalWebSAP].[dbo].[tblINTERNET_AnlasmaHizmetBedelleri] WHERE (" + smrefs + ") AND [dtFaturaTarih] >= @BaslangicTarih AND [dtFaturaTarih] <= @BitisTarih " + onayli + " ORDER BY [pkID] DESC", conn);
                da.SelectCommand.Parameters.Add("@BaslangicTarih", SqlDbType.SmallDateTime).Value = BaslangicTarih;
                da.SelectCommand.Parameters.Add("@BitisTarih", SqlDbType.SmallDateTime).Value = BitisTarih;
                try
                {
                    conn.Open();
                    da.Fill(Baslangic, Adet, dt);
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
        public static AnlasmaHizmetBedelleri GetObject(int ID)
        {
            AnlasmaHizmetBedelleri anlasmahizmetbedeli = null;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_INTERNET_AnlasmaHizmetBedeliGetir", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkID", SqlDbType.Int).Value = ID;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        anlasmahizmetbedeli = new AnlasmaHizmetBedelleri(Convert.ToInt32(dr[0]), Convert.ToInt32(dr[1]), Convert.ToInt32(dr[2]), 
                            Convert.ToInt32(dr[3]),
                            Convert.ToInt32(dr[4]), Convert.ToInt32(dr[5]), dr[6].ToString(), Convert.ToDateTime(dr[7]), Convert.ToDecimal(dr[8]),
                            Convert.ToDecimal(dr[9]), Convert.ToInt32(dr[10]), dr[11].ToString(), dr[12].ToString(), dr[13].ToString(),
                            dr[14].ToString(), Convert.ToDecimal(dr[15]), Convert.ToDecimal(dr[16]), Convert.ToBoolean(dr[17]), Convert.ToInt32(dr[18]), Convert.ToInt32(dr[19]));
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
    }
}

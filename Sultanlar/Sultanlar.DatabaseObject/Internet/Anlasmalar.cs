using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace Sultanlar.DatabaseObject.Internet
{
    public class Anlasmalar : ISultanlar, IDisposable
    {
        //
        //
        //
        // Alanlar:
        //
        private int _pkID;
        private int _SMREF;
        private int _intMusteriID;
        private DateTime _dtBaslangic;
        private DateTime _dtBitis;
        private int _intVadeTAH;
        private int _intVadeYEG;
        private int _intListSKUTAH;
        private int _intListSKUYEG;
        private double _flTAHIsk;
        private double _flTAHCiro;
        private double _flTAHCiro3;
        private double _flTAHCiro6;
        private double _flTAHCiro12;
        private double _flTAHCiroIsk;
        private decimal _mnTAHAnlasmaDisiBedeller;
        private decimal _mnTAHToplamCiro;
        private double _flYEGIsk;
        private double _flYEGCiro;
        private double _flYEGCiro3;
        private double _flYEGCiro6;
        private double _flYEGCiro12;
        private double _flYEGCiroIsk;
        private decimal _mnYEGAnlasmaDisiBedeller;
        private decimal _mnYEGToplamCiro;
        private string _strAciklama1;
        private string _strAciklama2;
        private string _strAciklama3;
        private string _strAciklama4;
        private int _intOnay; // 0 ise anlaşma işaretsiz 1 ise anlaşma onaylı 2 ise anlaşma onaysız
        //
        //
        //
        // Constracter lar:
        //
        private Anlasmalar(int pkID, int SMREF, int intMusteriID, DateTime dtBaslangic, DateTime dtBitis, int intVadeTAH, int intVadeYEG, int intListSKUTAH,
            int intListSKUYEG, double flTAHIsk, double flTAHCiro, double flTAHCiro3, double flTAHCiro6, double flTAHCiro12, double flTAHCiroIsk,
            decimal mnTAHAnlasmaDisiBedeller, decimal mnTAHToplamCiro, double flYEGIsk, double flYEGCiro, double flYEGCiro3, double flYEGCiro6,
            double flYEGCiro12, double flYEGCiroIsk, decimal mnYEGAnlasmaDisiBedeller, decimal mnYEGToplamCiro, string strAciklama1,
            string strAciklama2, string strAciklama3, string strAciklama4, int intOnay)
        {
            this._pkID = pkID;
            this._SMREF = SMREF;
            this._intMusteriID = intMusteriID;
            this._dtBaslangic = dtBaslangic;
            this._dtBitis = dtBitis;
            this._intVadeTAH = intVadeTAH;
            this._intVadeYEG = intVadeYEG;
            this._intListSKUTAH = intListSKUTAH;
            this._intListSKUYEG = intListSKUYEG;
            this._flTAHIsk = flTAHIsk;
            this._flTAHCiro = flTAHCiro;
            this._flTAHCiro3 = flTAHCiro3;
            this._flTAHCiro6 = flTAHCiro6;
            this._flTAHCiro12 = flTAHCiro12;
            this._flTAHCiroIsk = flTAHCiroIsk;
            this._mnTAHAnlasmaDisiBedeller = mnTAHAnlasmaDisiBedeller;
            this._mnTAHToplamCiro = mnTAHToplamCiro;
            this._flYEGIsk = flYEGIsk;
            this._flYEGCiro = flYEGCiro;
            this._flYEGCiro3 = flYEGCiro3;
            this._flYEGCiro6 = flYEGCiro6;
            this._flYEGCiro12 = flYEGCiro12;
            this._flYEGCiroIsk = flYEGCiroIsk;
            this._mnYEGAnlasmaDisiBedeller = mnYEGAnlasmaDisiBedeller;
            this._mnYEGToplamCiro = mnYEGToplamCiro;
            this._strAciklama1 = strAciklama1;
            this._strAciklama2 = strAciklama2;
            this._strAciklama3 = strAciklama3;
            this._strAciklama4 = strAciklama4;
            this._intOnay = intOnay;
        }
        //
        //
        public Anlasmalar(int SMREF, int intMusteriID, DateTime dtBaslangic, DateTime dtBitis, int intVadeTAH, int intVadeYEG, int intListSKUTAH,
            int intListSKUYEG, double flTAHIsk, double flTAHCiro, double flTAHCiro3, double flTAHCiro6, double flTAHCiro12, double flTAHCiroIsk,
            decimal mnTAHAnlasmaDisiBedeller, decimal mnTAHToplamCiro, double flYEGIsk, double flYEGCiro, double flYEGCiro3, double flYEGCiro6,
            double flYEGCiro12, double flYEGCiroIsk, decimal mnYEGAnlasmaDisiBedeller, decimal mnYEGToplamCiro, string strAciklama1,
            string strAciklama2, string strAciklama3, string strAciklama4, int intOnay)
        {
            this._pkID = 0;
            this._SMREF = SMREF;
            this._intMusteriID = intMusteriID;
            this._dtBaslangic = dtBaslangic;
            this._dtBitis = dtBitis;
            this._intVadeTAH = intVadeTAH;
            this._intVadeYEG = intVadeYEG;
            this._intListSKUTAH = intListSKUTAH;
            this._intListSKUYEG = intListSKUYEG;
            this._flTAHIsk = flTAHIsk;
            this._flTAHCiro = flTAHCiro;
            this._flTAHCiro3 = flTAHCiro3;
            this._flTAHCiro6 = flTAHCiro6;
            this._flTAHCiro12 = flTAHCiro12;
            this._flTAHCiroIsk = flTAHCiroIsk;
            this._mnTAHAnlasmaDisiBedeller = mnTAHAnlasmaDisiBedeller;
            this._mnTAHToplamCiro = mnTAHToplamCiro;
            this._flYEGIsk = flYEGIsk;
            this._flYEGCiro = flYEGCiro;
            this._flYEGCiro3 = flYEGCiro3;
            this._flYEGCiro6 = flYEGCiro6;
            this._flYEGCiro12 = flYEGCiro12;
            this._flYEGCiroIsk = flYEGCiroIsk;
            this._mnYEGAnlasmaDisiBedeller = mnYEGAnlasmaDisiBedeller;
            this._mnYEGToplamCiro = mnYEGToplamCiro;
            this._strAciklama1 = strAciklama1;
            this._strAciklama2 = strAciklama2;
            this._strAciklama3 = strAciklama3;
            this._strAciklama4 = strAciklama4;
            this._intOnay = intOnay;
        }
        //
        //
        //
        // Özellikler:
        //
        public int pkID { get { return this._pkID; } }
        public int SMREF { get { return this._SMREF; } set { this._SMREF = value; } }
        public int intMusteriID { get { return this._intMusteriID; } set { this.intMusteriID = value; } }
        public DateTime dtBaslangic { get { return this._dtBaslangic; } set { this._dtBaslangic = value; } }
        public DateTime dtBitis { get { return this._dtBitis; } set { this._dtBitis = value; } }
        public int intVadeTAH { get { return this._intVadeTAH; } set { this._intVadeTAH = value; } }
        public int intVadeYEG { get { return this._intVadeYEG; } set { this._intVadeYEG = value; } }
        public int intListSKUTAH { get { return this._intListSKUTAH; } set { this._intListSKUTAH = value; } }
        public int intListSKUYEG { get { return this._intListSKUYEG; } set { this._intListSKUYEG = value; } }
        public double flTAHIsk { get { return this._flTAHIsk; } set { this._flTAHIsk = value; } }
        public double flTAHCiro { get { return this._flTAHCiro; } set { this._flTAHCiro = value; } }
        public double flTAHCiro3 { get { return this._flTAHCiro3; } set { this._flTAHCiro3 = value; } }
        public double flTAHCiro6 { get { return this._flTAHCiro6; } set { this._flTAHCiro6 = value; } }
        public double flTAHCiro12 { get { return this._flTAHCiro12; } set { this._flTAHCiro12 = value; } }
        public double flTAHCiroIsk { get { return this._flTAHCiroIsk; } set { this._flTAHCiroIsk = value; } }
        public decimal mnTAHAnlasmaDisiBedeller { get { return this._mnTAHAnlasmaDisiBedeller; } set { this._mnTAHAnlasmaDisiBedeller = value; } }
        public decimal mnTAHToplamCiro { get { return this._mnTAHToplamCiro; } set { this._mnTAHToplamCiro = value; } }
        public double flYEGIsk { get { return this._flYEGIsk; } set { this._flYEGIsk = value; } }
        public double flYEGCiro { get { return this._flYEGCiro; } set { this._flYEGCiro = value; } }
        public double flYEGCiro3 { get { return this._flYEGCiro3; } set { this._flYEGCiro3 = value; } }
        public double flYEGCiro6 { get { return this._flYEGCiro6; } set { this._flYEGCiro6 = value; } }
        public double flYEGCiro12 { get { return this._flYEGCiro12; } set { this._flYEGCiro12 = value; } }
        public double flYEGCiroIsk { get { return this._flYEGCiroIsk; } set { this._flYEGCiroIsk = value; } }
        public decimal mnYEGAnlasmaDisiBedeller { get { return this._mnYEGAnlasmaDisiBedeller; } set { this._mnYEGAnlasmaDisiBedeller = value; } }
        public decimal mnYEGToplamCiro { get { return this._mnYEGToplamCiro; } set { this._mnYEGToplamCiro = value; } }
        public string strAciklama1 { get { return this._strAciklama1; } set { this._strAciklama1 = value; } }
        public string strAciklama2 { get { return this._strAciklama2; } set { this._strAciklama2 = value; } }
        public string strAciklama3 { get { return this._strAciklama3; } set { this._strAciklama3 = value; } }
        public string strAciklama4 { get { return this._strAciklama4; } set { this._strAciklama4 = value; } }
        public int intOnay { get { return this._intOnay; } set { this._intOnay = value; } }
        public decimal TAHTumBedellerToplami 
        {
            get
            {
                DataTable dt = new DataTable();
                AnlasmaBedeller.GetObjects(dt, this._pkID);
                decimal donendeger = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    double brut = Convert.ToDouble(dt.Rows[i]["mnTAHBedel"]) * Convert.ToInt32(dt.Rows[i]["intTAHAdet"]);
                    //double net = brut - ((brut / 100) * Convert.ToDouble(dt.Rows[i]["flTAHIsk"]));
                    donendeger += Convert.ToDecimal(brut);
                }
                return donendeger; 
            }
        }
        public decimal YEGTumBedellerToplami
        {
            get
            {
                DataTable dt = new DataTable();
                AnlasmaBedeller.GetObjects(dt, this._pkID);
                decimal donendeger = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    double brut = Convert.ToDouble(dt.Rows[i]["mnYEGBedel"]) * Convert.ToInt32(dt.Rows[i]["intYEGAdet"]);
                    //double net = brut - ((brut / 100) * Convert.ToDouble(dt.Rows[i]["flYEGIsk"]));
                    donendeger += Convert.ToDecimal(brut);
                }
                return donendeger;
            }
        }
        public double TAHYilSonuMaliyet { get { return this._mnTAHToplamCiro == 0 ? Convert.ToDouble(this.TAHTumBedellerToplami) : Convert.ToDouble((this.TAHTumBedellerToplami / this._mnTAHToplamCiro) * 100); } }
        public double YEGYilSonuMaliyet { get { return this._mnYEGToplamCiro == 0 ? Convert.ToDouble(this.YEGTumBedellerToplami) : Convert.ToDouble((this.YEGTumBedellerToplami / this._mnYEGToplamCiro) * 100); } }
        public double TAHCiroPrimiDahilNetMaliyet { get { return this._flTAHIsk + this._flTAHCiro + this._flTAHCiro3 + this._flTAHCiro6 + this._flTAHCiro12 + this._flTAHCiroIsk + TAHYilSonuMaliyet; } }
        public double YEGCiroPrimiDahilNetMaliyet { get { return this._flYEGIsk + this._flYEGCiro + this._flYEGCiro3 + this._flYEGCiro6 + this._flYEGCiro12 + this._flYEGCiroIsk + YEGYilSonuMaliyet; } }
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
                SqlCommand cmd = new SqlCommand("sp_INTERNET_AnlasmaEkle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@SMREF", SqlDbType.Int).Value = this._SMREF;
                cmd.Parameters.Add("@intMusteriID", SqlDbType.Int).Value = this._intMusteriID;
                cmd.Parameters.Add("@dtBaslangic", SqlDbType.SmallDateTime).Value = this._dtBaslangic;
                cmd.Parameters.Add("@dtBitis", SqlDbType.SmallDateTime).Value = this._dtBitis;
                cmd.Parameters.Add("@intVadeTAH", SqlDbType.Int).Value = this._intVadeTAH;
                cmd.Parameters.Add("@intVadeYEG", SqlDbType.Int).Value = this._intVadeYEG;
                cmd.Parameters.Add("@intListSKUTAH", SqlDbType.Int).Value = this._intListSKUTAH;
                cmd.Parameters.Add("@intListSKUYEG", SqlDbType.Int).Value = this._intListSKUYEG;
                cmd.Parameters.Add("@flTAHIsk", SqlDbType.Float).Value = this._flTAHIsk;
                cmd.Parameters.Add("@flTAHCiro", SqlDbType.Float).Value = this._flTAHCiro;
                cmd.Parameters.Add("@flTAHCiro3", SqlDbType.Float).Value = this._flTAHCiro3;
                cmd.Parameters.Add("@flTAHCiro6", SqlDbType.Float).Value = this._flTAHCiro6;
                cmd.Parameters.Add("@flTAHCiro12", SqlDbType.Float).Value = this._flTAHCiro12;
                cmd.Parameters.Add("@flTAHCiroIsk", SqlDbType.Float).Value = this._flTAHCiroIsk;
                cmd.Parameters.Add("@mnTAHAnlasmaDisiBedeller", SqlDbType.Money).Value = this._mnTAHAnlasmaDisiBedeller;
                cmd.Parameters.Add("@mnTAHToplamCiro", SqlDbType.Money).Value = this._mnTAHToplamCiro;
                cmd.Parameters.Add("@flYEGIsk", SqlDbType.Float).Value = this._flYEGIsk;
                cmd.Parameters.Add("@flYEGCiro", SqlDbType.Float).Value = this._flYEGCiro;
                cmd.Parameters.Add("@flYEGCiro3", SqlDbType.Float).Value = this._flYEGCiro3;
                cmd.Parameters.Add("@flYEGCiro6", SqlDbType.Float).Value = this._flYEGCiro6;
                cmd.Parameters.Add("@flYEGCiro12", SqlDbType.Float).Value = this._flYEGCiro12;
                cmd.Parameters.Add("@flYEGCiroIsk", SqlDbType.Float).Value = this._flYEGCiroIsk;
                cmd.Parameters.Add("@mnYEGAnlasmaDisiBedeller", SqlDbType.Money).Value = this._mnYEGAnlasmaDisiBedeller;
                cmd.Parameters.Add("@mnYEGToplamCiro", SqlDbType.Money).Value = this._mnYEGToplamCiro;
                cmd.Parameters.Add("@strAciklama1", SqlDbType.NVarChar).Value = this._strAciklama1;
                cmd.Parameters.Add("@strAciklama2", SqlDbType.NVarChar).Value = this._strAciklama2;
                cmd.Parameters.Add("@strAciklama3", SqlDbType.NVarChar).Value = this._strAciklama3;
                cmd.Parameters.Add("@strAciklama4", SqlDbType.NVarChar).Value = this._strAciklama4;
                cmd.Parameters.Add("@intOnay", SqlDbType.Int).Value = this._intOnay;
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
                SqlCommand cmd = new SqlCommand("sp_INTERNET_AnlasmaGuncelle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkID", SqlDbType.Int).Value = this._pkID;
                cmd.Parameters.Add("@SMREF", SqlDbType.Int).Value = this._SMREF;
                cmd.Parameters.Add("@intMusteriID", SqlDbType.Int).Value = this._intMusteriID;
                cmd.Parameters.Add("@dtBaslangic", SqlDbType.SmallDateTime).Value = this._dtBaslangic;
                cmd.Parameters.Add("@dtBitis", SqlDbType.SmallDateTime).Value = this._dtBitis;
                cmd.Parameters.Add("@intVadeTAH", SqlDbType.Int).Value = this._intVadeTAH;
                cmd.Parameters.Add("@intVadeYEG", SqlDbType.Int).Value = this._intVadeYEG;
                cmd.Parameters.Add("@intListSKUTAH", SqlDbType.Int).Value = this._intListSKUTAH;
                cmd.Parameters.Add("@intListSKUYEG", SqlDbType.Int).Value = this._intListSKUYEG;
                cmd.Parameters.Add("@flTAHIsk", SqlDbType.Float).Value = this._flTAHIsk;
                cmd.Parameters.Add("@flTAHCiro", SqlDbType.Float).Value = this._flTAHCiro;
                cmd.Parameters.Add("@flTAHCiro3", SqlDbType.Float).Value = this._flTAHCiro3;
                cmd.Parameters.Add("@flTAHCiro6", SqlDbType.Float).Value = this._flTAHCiro6;
                cmd.Parameters.Add("@flTAHCiro12", SqlDbType.Float).Value = this._flTAHCiro12;
                cmd.Parameters.Add("@flTAHCiroIsk", SqlDbType.Float).Value = this._flTAHCiroIsk;
                cmd.Parameters.Add("@mnTAHAnlasmaDisiBedeller", SqlDbType.Money).Value = this._mnTAHAnlasmaDisiBedeller;
                cmd.Parameters.Add("@mnTAHToplamCiro", SqlDbType.Money).Value = this._mnTAHToplamCiro;
                cmd.Parameters.Add("@flYEGIsk", SqlDbType.Float).Value = this._flYEGIsk;
                cmd.Parameters.Add("@flYEGCiro", SqlDbType.Float).Value = this._flYEGCiro;
                cmd.Parameters.Add("@flYEGCiro3", SqlDbType.Float).Value = this._flYEGCiro3;
                cmd.Parameters.Add("@flYEGCiro6", SqlDbType.Float).Value = this._flYEGCiro6;
                cmd.Parameters.Add("@flYEGCiro12", SqlDbType.Float).Value = this._flYEGCiro12;
                cmd.Parameters.Add("@flYEGCiroIsk", SqlDbType.Float).Value = this._flYEGCiroIsk;
                cmd.Parameters.Add("@mnYEGAnlasmaDisiBedeller", SqlDbType.Money).Value = this._mnYEGAnlasmaDisiBedeller;
                cmd.Parameters.Add("@mnYEGToplamCiro", SqlDbType.Money).Value = this._mnYEGToplamCiro;
                cmd.Parameters.Add("@strAciklama1", SqlDbType.NVarChar).Value = this._strAciklama1;
                cmd.Parameters.Add("@strAciklama2", SqlDbType.NVarChar).Value = this._strAciklama2;
                cmd.Parameters.Add("@strAciklama3", SqlDbType.NVarChar).Value = this._strAciklama3;
                cmd.Parameters.Add("@strAciklama4", SqlDbType.NVarChar).Value = this._strAciklama4;
                cmd.Parameters.Add("@intOnay", SqlDbType.Int).Value = this._intOnay;
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
                SqlCommand cmd = new SqlCommand("sp_INTERNET_AnlasmaSil", conn);
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
                    onayli = " AND [intOnay] = 1";
                else
                    onayli = " AND [intOnay] = 0";
            }

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT count(*) FROM tblINTERNET_Anlasmalar WHERE [dtBitis] >= @BaslangicTarih AND [dtBaslangic] <= @BitisTarih" + onayli, conn);
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
        public static void GetObjects(DataTable dt, object Onayli, DateTime BaslangicTarih, DateTime BitisTarih, int Baslangic, int Adet)
        {
            string onayli = string.Empty;
            if (Onayli != DBNull.Value)
            {
                if ((bool)Onayli == true)
                    onayli = " AND [intOnay] = 1";
                else
                    onayli = " AND [intOnay] = 0";
            }

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT [pkID],tblINTERNET_Anlasmalar.[SMREF],tblINTERNET_Anlasmalar.intMusteriID,CASE WHEN tblINTERNET_Anlasmalar.strAciklama2 = '1' THEN (SELECT TOP 1 MUSTERI FROM [Web-Musteri-TP] WHERE GMREF = SMREF AND GMREF = WebMusteriTP.GMREF) ELSE 'SULTANLAR PAZARLAMA A.Ş.' END AS BAYI,CASE WHEN tblINTERNET_Anlasmalar.strAciklama2 = '1' THEN WebMusteriTP.MUSTERI ELSE (SELECT TOP 1 MUSTERI FROM [Web-Musteri] WHERE GMREF = tblINTERNET_Anlasmalar.SMREF) END AS MUSTERI,[dtBaslangic],[dtBitis],[intVadeTAH],[intVadeYEG],[intListSKUTAH],[intListSKUYEG],[flTAHIsk],[flTAHCiro],[flTAHCiro3],[flTAHCiro6],[flTAHCiro12],[flTAHCiroIsk],[mnTAHAnlasmaDisiBedeller],[mnTAHToplamCiro],[flYEGIsk],[flYEGCiro],[flYEGCiro3],[flYEGCiro6],[flYEGCiro12],[flYEGCiroIsk],[mnYEGAnlasmaDisiBedeller],[mnYEGToplamCiro],[strAciklama1],[strAciklama2],[strAciklama3],[strAciklama4],[intOnay] FROM [KurumsalWebSAP].[dbo].[tblINTERNET_Anlasmalar] LEFT OUTER JOIN [Web-Musteri-TP] AS WebMusteriTP ON [tblINTERNET_Anlasmalar].SMREF = WebMusteriTP.SMREF WHERE [dtBitis] >= @BaslangicTarih AND [dtBaslangic] <= @BitisTarih" + onayli + " ORDER BY pkID DESC", conn);
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
        /// <summary>
        /// yanlış çalışıyor
        /// </summary>
        public static int GetObjectCount(string BayiSul, int SMREF, object Onayli, DateTime BaslangicTarih, DateTime BitisTarih)
        {
            int donendeger = 0;

            string onayli = string.Empty;
            if (Onayli != DBNull.Value)
            {
                if ((bool)Onayli == true)
                    onayli = " AND [intOnay] = 1";
                else
                    onayli = " AND [intOnay] = 0";
            }

            string bayisul = BayiSul != string.Empty ? " AND strAciklama2 = " + BayiSul : "";

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT count(*) FROM tblINTERNET_Anlasmalar WHERE SMREF IN (SELECT DISTINCT SMREF FROM [Web-Musteri] WHERE GMREF = (SELECT DISTINCT GMREF FROM [Web-Musteri] WHERE SMREF = @SMREF)) AND [dtBitis] >= @BaslangicTarih AND [dtBaslangic] <= @BitisTarih AND strAciklama3 != 'PASİF'" + bayisul + onayli, conn);
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
        public static void GetObjects(string BayiSul, DataTable dt, int SMREF, object Onayli, DateTime BaslangicTarih, DateTime BitisTarih, int Baslangic, int Adet)
        {
            string onayli = string.Empty;
            if (Onayli != DBNull.Value)
            {
                if ((bool)Onayli == true)
                    onayli = " AND [intOnay] = 1";
                else
                    onayli = " AND [intOnay] = 0";
            }

            string bayisul = BayiSul != string.Empty ? " AND strAciklama2 = " + BayiSul : "";

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT [pkID],tblINTERNET_Anlasmalar.[SMREF],tblINTERNET_Anlasmalar.intMusteriID,CASE WHEN tblINTERNET_Anlasmalar.strAciklama2 = '1' THEN (SELECT TOP 1 MUSTERI FROM [Web-Musteri-TP] WHERE GMREF = SMREF AND GMREF = WebMusteriTP.GMREF) ELSE 'SULTANLAR PAZARLAMA A.Ş.' END AS BAYI,CASE WHEN tblINTERNET_Anlasmalar.strAciklama2 = '1' THEN WebMusteriTP.MUSTERI ELSE (SELECT TOP 1 MUSTERI FROM [Web-Musteri] WHERE GMREF = tblINTERNET_Anlasmalar.SMREF) END AS MUSTERI,[dtBaslangic],[dtBitis],[intVadeTAH],[intVadeYEG],[intListSKUTAH],[intListSKUYEG],[flTAHIsk],[flTAHCiro],[flTAHCiro3],[flTAHCiro6],[flTAHCiro12],[flTAHCiroIsk],[mnTAHAnlasmaDisiBedeller],[mnTAHToplamCiro],[flYEGIsk],[flYEGCiro],[flYEGCiro3],[flYEGCiro6],[flYEGCiro12],[flYEGCiroIsk],[mnYEGAnlasmaDisiBedeller],[mnYEGToplamCiro],[strAciklama1],[strAciklama2],[strAciklama3],[strAciklama4],[intOnay] FROM [KurumsalWebSAP].[dbo].[tblINTERNET_Anlasmalar] LEFT OUTER JOIN [Web-Musteri-TP] AS WebMusteriTP ON [tblINTERNET_Anlasmalar].SMREF = WebMusteriTP.SMREF WHERE tblINTERNET_Anlasmalar.SMREF = @SMREF AND [dtBitis] >= @BaslangicTarih AND [dtBaslangic] <= @BitisTarih" + bayisul + onayli + " ORDER BY pkID DESC", conn);
                da.SelectCommand.Parameters.Add("@SMREF", SqlDbType.Int).Value = SMREF;
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
        public static int GetObjectCount(string BayiSul, ArrayList SMREF, object Onayli, DateTime BaslangicTarih, DateTime BitisTarih)
        {
            int donendeger = 0;

            string onayli = string.Empty;
            if (Onayli != DBNull.Value)
            {
                if ((bool)Onayli == true)
                    onayli = " AND [intOnay] = 1";
                else
                    onayli = " AND [intOnay] = 0";
            }

            string bayisul = BayiSul != string.Empty ? " AND strAciklama2 = " + BayiSul : "";

            string smrefs = string.Empty;
            for (int i = 0; i < SMREF.Count; i++)
                smrefs += "SMREF = " + SMREF[i].ToString() + " OR ";
            if (SMREF.Count > 0)
                smrefs = smrefs.Substring(0, smrefs.Length - 3);
            else
                return 0;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT count(*) FROM tblINTERNET_Anlasmalar WHERE (" + smrefs + ") AND [dtBitis] >= @BaslangicTarih AND [dtBaslangic] <= @BitisTarih" + bayisul + onayli, conn);
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
        public static void GetObjects(string BayiSul, DataTable dt, ArrayList SMREF, object Onayli, DateTime BaslangicTarih, DateTime BitisTarih, int Baslangic, int Adet)
        {
            string onayli = string.Empty;
            if (Onayli != DBNull.Value)
            {
                if ((bool)Onayli == true)
                    onayli = " AND [intOnay] = 1";
                else
                    onayli = " AND [intOnay] = 0";
            }

            string bayisul = BayiSul != string.Empty ? " AND strAciklama2 = " + BayiSul : "";

            string smrefs = string.Empty;
            for (int i = 0; i < SMREF.Count; i++)
                smrefs += "tblINTERNET_Anlasmalar.SMREF = " + SMREF[i].ToString() + " OR ";
            if (SMREF.Count > 0)
                smrefs = smrefs.Substring(0, smrefs.Length - 3);
            else
                return;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT [pkID],tblINTERNET_Anlasmalar.[SMREF],tblINTERNET_Anlasmalar.intMusteriID,CASE WHEN tblINTERNET_Anlasmalar.strAciklama2 = '1' THEN (SELECT TOP 1 MUSTERI FROM [Web-Musteri-TP] WHERE GMREF = SMREF AND GMREF = WebMusteriTP.GMREF) ELSE 'SULTANLAR PAZARLAMA A.Ş.' END AS BAYI,CASE WHEN tblINTERNET_Anlasmalar.strAciklama2 = '1' THEN WebMusteriTP.MUSTERI ELSE (SELECT TOP 1 MUSTERI FROM [Web-Musteri] WHERE GMREF = tblINTERNET_Anlasmalar.SMREF) END AS MUSTERI,[dtBaslangic],[dtBitis],[intVadeTAH],[intVadeYEG],[intListSKUTAH],[intListSKUYEG],[flTAHIsk],[flTAHCiro],[flTAHCiro3],[flTAHCiro6],[flTAHCiro12],[flTAHCiroIsk],[mnTAHAnlasmaDisiBedeller],[mnTAHToplamCiro],[flYEGIsk],[flYEGCiro],[flYEGCiro3],[flYEGCiro6],[flYEGCiro12],[flYEGCiroIsk],[mnYEGAnlasmaDisiBedeller],[mnYEGToplamCiro],[strAciklama1],[strAciklama2],[strAciklama3],[strAciklama4],[intOnay] FROM [KurumsalWebSAP].[dbo].[tblINTERNET_Anlasmalar] LEFT OUTER JOIN [Web-Musteri-TP] AS WebMusteriTP ON [tblINTERNET_Anlasmalar].SMREF = WebMusteriTP.SMREF WHERE (" + smrefs + ") AND [dtBitis] >= @BaslangicTarih AND [dtBaslangic] <= @BitisTarih AND strAciklama3 != 'PASİF'" + bayisul + onayli + " ORDER BY pkID DESC", conn);
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
        /// <summary>
        /// UI için
        /// </summary>
        public static void GetObjects(DataTable dt, object Onayli, string KAdi, string Pasif)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_INTERNET_AnlasmalarGetir", conn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandTimeout = 200;
                da.SelectCommand.Parameters.Add("@intOnay", SqlDbType.Int).Value = Onayli;
                da.SelectCommand.Parameters.Add("@Kullanici", SqlDbType.NVarChar, 50).Value = KAdi;
                da.SelectCommand.Parameters.Add("@PASIF", SqlDbType.NVarChar, 50).Value = Pasif;
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
        /// <summary>
        /// UI için
        /// </summary>
        public static void GetObjects(DataTable dt, int GMREF, object Onayli, bool Bayi)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_INTERNET_AnlasmalarGetirByGMREF", conn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@GMREF", SqlDbType.Int).Value = GMREF;
                da.SelectCommand.Parameters.Add("@intOnay", SqlDbType.Int).Value = Onayli;
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
        /// <summary>
        /// UI için
        /// </summary>
        public static void GetObjects(DataTable dt, int SMREF)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_INTERNET_AnlasmalarGetirBySMREF", conn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
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
        //
        //
        public static Anlasmalar GetObject(int ID)
        {
            Anlasmalar anlasma = null;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_INTERNET_AnlasmaGetir", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkID", SqlDbType.Int).Value = ID;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        anlasma = new Anlasmalar(Convert.ToInt32(dr[0]), Convert.ToInt32(dr[1]), Convert.ToInt32(dr[2]), Convert.ToDateTime(dr[3]),
                            Convert.ToDateTime(dr[4]), Convert.ToInt32(dr[5]), Convert.ToInt32(dr[6]), Convert.ToInt32(dr[7]),
                            Convert.ToInt32(dr[8]), Convert.ToDouble(dr[9]), Convert.ToDouble(dr[10]), Convert.ToDouble(dr[11]),
                            Convert.ToDouble(dr[12]), Convert.ToDouble(dr[13]), Convert.ToDouble(dr[14]), Convert.ToDecimal(dr[15]),
                            Convert.ToDecimal(dr[16]), Convert.ToDouble(dr[17]), Convert.ToDouble(dr[18]), Convert.ToDouble(dr[19]),
                            Convert.ToDouble(dr[20]), Convert.ToDouble(dr[21]), Convert.ToDouble(dr[22]), Convert.ToDecimal(dr[23]),
                            Convert.ToDecimal(dr[24]), dr[25].ToString(), dr[26].ToString(), dr[27].ToString(), dr[28].ToString(),
                            Convert.ToInt32(dr[29]));
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

            return anlasma;
        }
        //
        //
        public static int GetSonAnlasmaID(int SMREF, DateTime Tarih, string Tur) // bitiş >= eklediğimiz için tariharaligi ile ayni oldu artık son anlaşma gelmiyor
        {
            int donendeger = 0;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT TOP 1 pkID FROM tblINTERNET_Anlasmalar WHERE SMREF = @SMREF AND dtBaslangic <= @Tarih AND dtBitis >= @Tarih AND strAciklama2 = @strAciklama2 AND intOnay = 1 AND strAciklama3 != 'PASİF' ORDER BY pkID DESC", conn);
                cmd.Parameters.Add("@SMREF", SqlDbType.Int).Value = SMREF;
                cmd.Parameters.Add("@Tarih", SqlDbType.SmallDateTime).Value = Tarih;
                cmd.Parameters.Add("@strAciklama2", SqlDbType.NVarChar).Value = Tur;
                try
                {
                    conn.Open();
                    object obj = cmd.ExecuteScalar();
                    if (obj != null)
                        donendeger = Convert.ToInt32(obj);
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
        public static int GetSonAnlasmaID(int SMREF, string Tur) // tarihten bağımsız en son anlaşma id
        {
            int donendeger = 0;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT TOP 1 pkID FROM tblINTERNET_Anlasmalar WHERE SMREF = @SMREF AND strAciklama2 = @strAciklama2 AND intOnay = 1 AND strAciklama3 != 'PASİF' ORDER BY pkID DESC", conn);
                cmd.Parameters.Add("@SMREF", SqlDbType.Int).Value = SMREF;
                cmd.Parameters.Add("@strAciklama2", SqlDbType.NVarChar).Value = Tur;
                try
                {
                    conn.Open();
                    object obj = cmd.ExecuteScalar();
                    if (obj != null)
                        donendeger = Convert.ToInt32(obj);
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
        public static int GetTarihAraligiAnlasmaID(int SMREF, DateTime Tarih)
        {
            int donendeger = 0;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT TOP 1 pkID FROM tblINTERNET_Anlasmalar WHERE intOnay = 1 AND SMREF = @SMREF AND dtBaslangic <= @Tarih AND dtBitis >= @Tarih ORDER BY pkID DESC", conn);
                cmd.Parameters.Add("@SMREF", SqlDbType.Int).Value = SMREF;
                cmd.Parameters.Add("@Tarih", SqlDbType.SmallDateTime).Value = Tarih;
                try
                {
                    conn.Open();
                    object obj = cmd.ExecuteScalar();
                    if (obj != null)
                        donendeger = Convert.ToInt32(obj);
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
        public static int GetSonOnaylanmamisAnlasmaID(int SMREF, string Tur)
        {
            int donendeger = 0;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT TOP 1 pkID FROM tblINTERNET_Anlasmalar WHERE SMREF = @SMREF AND intOnay = 0 AND strAciklama2 = @strAciklama2 AND strAciklama3 != 'PASİF' ORDER BY pkID DESC", conn);
                cmd.Parameters.Add("@SMREF", SqlDbType.Int).Value = SMREF;
                cmd.Parameters.Add("@strAciklama2", SqlDbType.NVarChar).Value = Tur;
                try
                {
                    conn.Open();
                    object obj = cmd.ExecuteScalar();
                    if (obj != null)
                        donendeger = Convert.ToInt32(obj);
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
        public static string GetKat(int AnlasmaID)
        {
            string donendeger = "";

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT strKategori FROM tblINTERNET_Anlasmalar WHERE pkID = @AnlasmaID", conn);
                cmd.Parameters.Add("@AnlasmaID", SqlDbType.Int).Value = AnlasmaID;
                try
                {
                    conn.Open();
                    object obj = cmd.ExecuteScalar();
                    if (obj != null)
                        donendeger = obj.ToString();
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
        public static void SetKat(int AnlasmaID, string Kat)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UPDATE tblINTERNET_Anlasmalar SET strKategori = @Kat WHERE pkID = @AnlasmaID", conn);
                cmd.Parameters.Add("@AnlasmaID", SqlDbType.Int).Value = AnlasmaID;
                cmd.Parameters.Add("@Kat", SqlDbType.NVarChar, 50).Value = Kat;
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
    }
}

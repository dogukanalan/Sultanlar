using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Collections;

namespace Sultanlar.DatabaseObject.Internet
{
    public class CariHesapZ
    {
        #region Alanlar
        private short _ACTIVE;
        private string _BOLGE;
        private string _GRP;
        private string _EKP;
        private string _YTKKOD;
        private string _ILKOD;
        private string _IL;
        private string _ILCEKOD;
        private string _ILCE;
        private int _TIP;
        private string _MTKOD;
        private string _MTACIKLAMA;
        private string _UNVAN;
        private int _SLSREF;
        private string _SATKOD;
        private string _SATKOD1;
        private string _SATTEM;
        private int _GMREF;
        private string _MUSKOD;
        private string _MUSTERI;
        private int _SMREF;
        private string _SUBKOD;
        private string _SUBE;
        private string _ADRES;
        private string _SEHIR;
        private string _SEMT;
        private string _VRGDAIRE;
        private string _VRGNO;
        private string _TEL1;
        private string _FAX1;
        private string _EMAIL1;
        private string _ILGILI;
        private string _CEP1;
        private double _NETTOP;
        #endregion

        #region Constracter
        private CariHesapZ() { }
        public CariHesapZ(short ACTIVE, string BOLGE, string GRP, string EKP, string YTKKOD, string ILKOD, string IL, string ILCEKOD,
            string ILCE, int TIP, string MTKOD, string MTACIKLAMA, string UNVAN, int SLSREF, string SATKOD, string SATKOD1, string SATTEM,
            int GMREF, string MUSKOD, string MUSTERI, int SMREF, string SUBKOD, string SUBE, string ADRES, string SEHIR, string SEMT,
            string VRGDAIRE, string VRGNO, string TEL1, string FAX1, string EMAIL1, string ILGILI, string CEP1, double NETTOP) 
        {
            this._ACTIVE = ACTIVE;
            this._BOLGE = BOLGE;
            this._GRP = GRP;
            this._EKP = EKP;
            this._YTKKOD = YTKKOD;
            this._ILKOD = ILKOD;
            this._IL = IL;
            this._ILCEKOD = ILCEKOD;
            this._ILCE = ILCE;
            this._TIP = TIP;
            this._MTKOD = MTKOD;
            this._MTACIKLAMA = MTACIKLAMA;
            this._UNVAN = UNVAN;
            this._SLSREF = SLSREF;
            this._SATKOD = SATKOD;
            this._SATKOD1 = SATKOD1;
            this._SATTEM = SATTEM;
            this._GMREF = GMREF;
            this._MUSKOD = MUSKOD;
            this._MUSTERI = MUSTERI;
            this._SMREF = SMREF;
            this._SUBKOD = SUBKOD;
            this._SUBE = SUBE;
            this._ADRES = ADRES;
            this._SEHIR = SEHIR;
            this._SEMT = SEMT;
            this._VRGDAIRE = VRGDAIRE;
            this._VRGNO = VRGNO;
            this._TEL1 = TEL1;
            this._FAX1 = FAX1;
            this._EMAIL1 = EMAIL1;
            this._ILGILI = ILGILI;
            this._CEP1 = CEP1;
            this._NETTOP = NETTOP;
        }
        #endregion

        #region Özellikler
        public short ACTIVE { get { return this._ACTIVE; } set { this._ACTIVE = value; } }
        public string BOLGE { get { return this._BOLGE; } set { this._BOLGE = value; } }
        public string GRP { get { return this._GRP; } set { this._GRP = value; } }
        public string EKP { get { return this._EKP; } set { this._EKP = value; } }
        public string YTKKOD { get { return this._YTKKOD; } set { this._YTKKOD = value; } }
        public string ILKOD { get { return this._ILKOD; } set { this._ILKOD = value; } }
        public string IL { get { return this._IL; } set { this._IL = value; } }
        public string ILCEKOD { get { return this._ILCEKOD; } set { this._ILCEKOD = value; } }
        public string ILCE { get { return this._ILCE; } set { this._ILCE = value; } }
        public int TIP { get { return this._TIP; } set { this._TIP = value; } }
        public string MTKOD { get { return this._MTKOD; } set { this._MTKOD = value; } }
        public string MTACIKLAMA { get { return this._MTACIKLAMA; } set { this._MTACIKLAMA = value; } }
        public string UNVAN { get { return this._UNVAN; } set { this._UNVAN = value; } }
        public int SLSREF { get { return this._SLSREF; } set { this._SLSREF = value; } }
        public string SATKOD { get { return this._SATKOD; } set { this._SATKOD = value; } }
        public string SATKOD1 { get { return this._SATKOD1; } set { this._SATKOD1 = value; } }
        public string SATTEM { get { return this._SATTEM; } set { this._SATTEM = value; } }
        public int GMREF { get { return this._GMREF; } set { this._GMREF = value; } }
        public string MUSKOD { get { return this._MUSKOD; } set { this._MUSKOD = value; } }
        public string MUSTERI { get { return this._MUSTERI; } set { this._MUSTERI = value; } }
        public int SMREF { get { return this._SMREF; } set { this._SMREF = value; } }
        public string SUBKOD { get { return this._SUBKOD; } set { this._SUBKOD = value; } }
        public string SUBE { get { return this._SUBE; } set { this._SUBE = value; } }
        public string ADRES { get { return this._ADRES; } set { this._ADRES = value; } }
        public string SEHIR { get { return this._SEHIR; } set { this._SEHIR = value; } }
        public string SEMT { get { return this._SEMT; } set { this._SEMT = value; } }
        public string VRGDAIRE { get { return this._VRGDAIRE; } set { this._VRGDAIRE = value; } }
        public string VRGNO { get { return this._VRGNO; } set { this._VRGNO = value; } }
        public string TEL1 { get { return this._TEL1; } set { this._TEL1 = value; } }
        public string FAX1 { get { return this._FAX1; } set { this._FAX1 = value; } }
        public string EMAIL1 { get { return this._EMAIL1; } set { this._EMAIL1 = value; } }
        public string ILGILI { get { return this._ILGILI; } set { this._ILGILI = value; } }
        public string CEP1 { get { return this._CEP1; } set { this._CEP1 = value; } }
        public double NETTOP { get { return this._NETTOP; } set { this._NETTOP = value; } }
        #endregion

        public override string ToString() 
        { 
            return this._SUBE == string.Empty ? this._MUSTERI : this._SUBE; 
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public void DoInsert()
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO [Web-Musteri-Z] ([ACTIVE],[BOLGE],[GRP],[EKP],[YTK KOD],[IL KOD],[IL],[ILCE KOD],[ILCE],[TIP],[MT KOD],[MT ACIKLAMA],[UNVAN],[SLSREF],[SAT KOD],[SAT KOD1],[SAT TEM],[GMREF],[MUS KOD],[MUSTERI],[SMREF],[SUB KOD],[SUBE],[ADRES],[SEHIR],[SEMT],[VRG DAIRE],[VRG NO],[TEL-1],[FAX-1],[EMAIL-1],[ILGILI],[CEP-1],[NETTOP]) VALUES (@ACTIVE,@BOLGE,@GRP,@EKP,@YTKKOD,@ILKOD,@IL,@ILCEKOD,@ILCE,@TIP,@MTKOD,@MTACIKLAMA,@UNVAN,@SLSREF,@SATKOD,@SATKOD1,@SATTEM,@GMREF,@MUSKOD,@MUSTERI,@SMREF,@SUBKOD,@SUBE,@ADRES,@SEHIR,@SEMT,@VRGDAIRE,@VRGNO,@TEL1,@FAX1,@EMAIL1,@ILGILI,@CEP1,@NETTOP)", conn);
                cmd.Parameters.Add("@ACTIVE", SqlDbType.SmallInt).Value = this._ACTIVE;
                cmd.Parameters.Add("@BOLGE", SqlDbType.VarChar, 2).Value = this._BOLGE;
                cmd.Parameters.Add("@GRP", SqlDbType.VarChar, 2).Value = this._GRP;
                cmd.Parameters.Add("@EKP", SqlDbType.VarChar, 2).Value = this._EKP;
                cmd.Parameters.Add("@YTKKOD", SqlDbType.VarChar, 11).Value = this._YTKKOD;
                cmd.Parameters.Add("@ILKOD", SqlDbType.VarChar, 13).Value = this._ILKOD;
                cmd.Parameters.Add("@IL", SqlDbType.VarChar, 41).Value = this._IL;
                cmd.Parameters.Add("@ILCEKOD", SqlDbType.VarChar, 13).Value = this._ILCEKOD;
                cmd.Parameters.Add("@ILCE", SqlDbType.VarChar, 51).Value = this._ILCE;
                cmd.Parameters.Add("@TIP", SqlDbType.Int).Value = this._TIP;
                cmd.Parameters.Add("@MTKOD", SqlDbType.VarChar, 25).Value = this._MTKOD;
                cmd.Parameters.Add("@MTACIKLAMA", SqlDbType.VarChar, 41).Value = this._MTACIKLAMA;
                cmd.Parameters.Add("@UNVAN", SqlDbType.VarChar, 2).Value = this._UNVAN;
                cmd.Parameters.Add("@SLSREF", SqlDbType.Int).Value = this._SLSREF;
                cmd.Parameters.Add("@SATKOD", SqlDbType.VarChar, 25).Value = this._SATKOD;
                cmd.Parameters.Add("@SATKOD1", SqlDbType.VarChar, 11).Value = this._SATKOD1;
                cmd.Parameters.Add("@SATTEM", SqlDbType.VarChar, 51).Value = this._SATTEM;
                cmd.Parameters.Add("@GMREF", SqlDbType.Int).Value = this._GMREF;
                cmd.Parameters.Add("@MUSKOD", SqlDbType.VarChar, 17).Value = this._MUSKOD;
                cmd.Parameters.Add("@MUSTERI", SqlDbType.VarChar, 311).Value = this._MUSTERI;
                cmd.Parameters.Add("@SMREF", SqlDbType.Int).Value = this._SMREF;
                cmd.Parameters.Add("@SUBKOD", SqlDbType.VarChar, 17).Value = this._SUBKOD;
                cmd.Parameters.Add("@SUBE", SqlDbType.VarChar, 311).Value = this._SUBE;
                cmd.Parameters.Add("@ADRES", SqlDbType.VarChar, 405).Value = this._ADRES;
                cmd.Parameters.Add("@SEHIR", SqlDbType.VarChar, 21).Value = this._SEHIR;
                cmd.Parameters.Add("@SEMT", SqlDbType.VarChar, 51).Value = this._SEMT;
                cmd.Parameters.Add("@VRGDAIRE", SqlDbType.VarChar, 31).Value = this._VRGDAIRE;
                cmd.Parameters.Add("@VRGNO", SqlDbType.VarChar, 16).Value = this._VRGNO;
                cmd.Parameters.Add("@TEL1", SqlDbType.VarChar, 51).Value = this._TEL1;
                cmd.Parameters.Add("@FAX1", SqlDbType.VarChar, 51).Value = this._FAX1;
                cmd.Parameters.Add("@EMAIL1", SqlDbType.VarChar, 251).Value = this._EMAIL1;
                cmd.Parameters.Add("@ILGILI", SqlDbType.VarChar, 21).Value = this._ILGILI;
                cmd.Parameters.Add("@CEP1", SqlDbType.VarChar, 51).Value = this._CEP1;
                cmd.Parameters.Add("@NETTOP", SqlDbType.Float).Value = this._NETTOP;
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

        public void DoUpdate()
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UPDATE [Web-Musteri-Z] SET [ACTIVE] = @ACTIVE,[BOLGE] = @BOLGE,[GRP] = @GRP,[EKP] = @EKP,[YTK KOD] = @YTKKOD,[IL KOD] = @ILKOD,[IL] = @IL,[ILCE KOD] = @ILCEKOD,[ILCE] = @ILCE,[TIP] = @TIP,[MT KOD] = @MTKOD,[MT ACIKLAMA] = @MTACIKLAMA,[UNVAN] = @UNVAN,[SLSREF] = @SLSREF,[SAT KOD] = @SATKOD,[SAT KOD1] = @SATKOD1,[SAT TEM] = @SATTEM,[GMREF] = @GMREF,[MUS KOD] = @MUSKOD,[MUSTERI] = @MUSTERI,[SUB KOD] = @SUBKOD,[SUBE] = @SUBE,[ADRES] = @ADRES,[SEHIR] = @SEHIR,[SEMT] = @SEMT,[VRG DAIRE] = @VRGDAIRE,[VRG NO] = @VRGNO,[TEL-1] = @TEL1,[FAX-1] = @FAX1,[EMAIL-1] = @EMAIL1,[ILGILI] = @ILGILI,[CEP-1] = @CEP1,[NETTOP] = @NETTOP WHERE [SMREF] = @SMREF AND [SLSREF] = @SLSREF", conn);
                cmd.Parameters.Add("@ACTIVE", SqlDbType.SmallInt).Value = this._ACTIVE;
                cmd.Parameters.Add("@BOLGE", SqlDbType.VarChar, 2).Value = this._BOLGE;
                cmd.Parameters.Add("@GRP", SqlDbType.VarChar, 2).Value = this._GRP;
                cmd.Parameters.Add("@EKP", SqlDbType.VarChar, 2).Value = this._EKP;
                cmd.Parameters.Add("@YTKKOD", SqlDbType.VarChar, 11).Value = this._YTKKOD;
                cmd.Parameters.Add("@ILKOD", SqlDbType.VarChar, 13).Value = this._ILKOD;
                cmd.Parameters.Add("@IL", SqlDbType.VarChar, 41).Value = this._IL;
                cmd.Parameters.Add("@ILCEKOD", SqlDbType.VarChar, 13).Value = this._ILCEKOD;
                cmd.Parameters.Add("@ILCE", SqlDbType.VarChar, 51).Value = this._ILCE;
                cmd.Parameters.Add("@TIP", SqlDbType.Int).Value = this._TIP;
                cmd.Parameters.Add("@MTKOD", SqlDbType.VarChar, 25).Value = this._MTKOD;
                cmd.Parameters.Add("@MTACIKLAMA", SqlDbType.VarChar, 41).Value = this._MTACIKLAMA;
                cmd.Parameters.Add("@UNVAN", SqlDbType.VarChar, 2).Value = this._UNVAN;
                cmd.Parameters.Add("@SLSREF", SqlDbType.Int).Value = this._SLSREF;
                cmd.Parameters.Add("@SATKOD", SqlDbType.VarChar, 25).Value = this._SATKOD;
                cmd.Parameters.Add("@SATKOD1", SqlDbType.VarChar, 11).Value = this._SATKOD1;
                cmd.Parameters.Add("@SATTEM", SqlDbType.VarChar, 51).Value = this._SATTEM;
                cmd.Parameters.Add("@GMREF", SqlDbType.Int).Value = this._GMREF;
                cmd.Parameters.Add("@MUSKOD", SqlDbType.VarChar, 17).Value = this._MUSKOD;
                cmd.Parameters.Add("@MUSTERI", SqlDbType.VarChar, 311).Value = this._MUSTERI;
                cmd.Parameters.Add("@SUBKOD", SqlDbType.VarChar, 17).Value = this._SUBKOD;
                cmd.Parameters.Add("@SUBE", SqlDbType.VarChar, 311).Value = this._SUBE;
                cmd.Parameters.Add("@ADRES", SqlDbType.VarChar, 405).Value = this._ADRES;
                cmd.Parameters.Add("@SEHIR", SqlDbType.VarChar, 21).Value = this._SEHIR;
                cmd.Parameters.Add("@SEMT", SqlDbType.VarChar, 51).Value = this._SEMT;
                cmd.Parameters.Add("@VRGDAIRE", SqlDbType.VarChar, 31).Value = this._VRGDAIRE;
                cmd.Parameters.Add("@VRGNO", SqlDbType.VarChar, 16).Value = this._VRGNO;
                cmd.Parameters.Add("@TEL1", SqlDbType.VarChar, 51).Value = this._TEL1;
                cmd.Parameters.Add("@FAX1", SqlDbType.VarChar, 51).Value = this._FAX1;
                cmd.Parameters.Add("@EMAIL1", SqlDbType.VarChar, 251).Value = this._EMAIL1;
                cmd.Parameters.Add("@ILGILI", SqlDbType.VarChar, 21).Value = this._ILGILI;
                cmd.Parameters.Add("@CEP1", SqlDbType.VarChar, 51).Value = this._CEP1;
                cmd.Parameters.Add("@NETTOP", SqlDbType.Float).Value = this._NETTOP;
                cmd.Parameters.Add("@SMREF", SqlDbType.Int).Value = this._SMREF;
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

        public static void DoUpdateAll(short ACTIVE, string BOLGE, string GRP, string EKP, string YTKKOD, string ILKOD, string IL, string ILCEKOD,
            string ILCE, int TIP, string MTKOD, string MTACIKLAMA, string UNVAN, string SATKOD, string SATKOD1, 
            int GMREF, string MUSKOD, string MUSTERI, int SMREF, string SUBKOD, string SUBE, string ADRES, string SEHIR, string SEMT,
            string VRGDAIRE, string VRGNO, string TEL1, string FAX1, string EMAIL1, string ILGILI, string CEP1, double NETTOP)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UPDATE [Web-Musteri-Z] SET [ACTIVE] = @ACTIVE,[BOLGE] = @BOLGE,[GRP] = @GRP,[EKP] = @EKP,[YTK KOD] = @YTKKOD,[IL KOD] = @ILKOD,[IL] = @IL,[ILCE KOD] = @ILCEKOD,[ILCE] = @ILCE,[TIP] = @TIP,[MT KOD] = @MTKOD,[MT ACIKLAMA] = @MTACIKLAMA,[UNVAN] = @UNVAN,[SAT KOD] = @SATKOD,[SAT KOD1] = @SATKOD1,[GMREF] = @GMREF,[MUS KOD] = @MUSKOD,[MUSTERI] = @MUSTERI,[SUB KOD] = @SUBKOD,[SUBE] = @SUBE,[ADRES] = @ADRES,[SEHIR] = @SEHIR,[SEMT] = @SEMT,[VRG DAIRE] = @VRGDAIRE,[VRG NO] = @VRGNO,[TEL-1] = @TEL1,[FAX-1] = @FAX1,[EMAIL-1] = @EMAIL1,[ILGILI] = @ILGILI,[CEP-1] = @CEP1,[NETTOP] = @NETTOP WHERE [SMREF] = @SMREF", conn);
                cmd.Parameters.Add("@ACTIVE", SqlDbType.SmallInt).Value = ACTIVE;
                cmd.Parameters.Add("@BOLGE", SqlDbType.VarChar, 2).Value = BOLGE;
                cmd.Parameters.Add("@GRP", SqlDbType.VarChar, 2).Value = GRP;
                cmd.Parameters.Add("@EKP", SqlDbType.VarChar, 2).Value = EKP;
                cmd.Parameters.Add("@YTKKOD", SqlDbType.VarChar, 11).Value = YTKKOD;
                cmd.Parameters.Add("@ILKOD", SqlDbType.VarChar, 13).Value = ILKOD;
                cmd.Parameters.Add("@IL", SqlDbType.VarChar, 41).Value = IL;
                cmd.Parameters.Add("@ILCEKOD", SqlDbType.VarChar, 13).Value = ILCEKOD;
                cmd.Parameters.Add("@ILCE", SqlDbType.VarChar, 51).Value = ILCE;
                cmd.Parameters.Add("@TIP", SqlDbType.Int).Value = TIP;
                cmd.Parameters.Add("@MTKOD", SqlDbType.VarChar, 25).Value = MTKOD;
                cmd.Parameters.Add("@MTACIKLAMA", SqlDbType.VarChar, 41).Value = MTACIKLAMA;
                cmd.Parameters.Add("@UNVAN", SqlDbType.VarChar, 2).Value = UNVAN;
                cmd.Parameters.Add("@SATKOD", SqlDbType.VarChar, 25).Value = SATKOD;
                cmd.Parameters.Add("@SATKOD1", SqlDbType.VarChar, 11).Value = SATKOD1;
                cmd.Parameters.Add("@GMREF", SqlDbType.Int).Value = GMREF;
                cmd.Parameters.Add("@MUSKOD", SqlDbType.VarChar, 17).Value = MUSKOD;
                cmd.Parameters.Add("@MUSTERI", SqlDbType.VarChar, 311).Value = MUSTERI;
                cmd.Parameters.Add("@SUBKOD", SqlDbType.VarChar, 17).Value = SUBKOD;
                cmd.Parameters.Add("@SUBE", SqlDbType.VarChar, 311).Value = SUBE;
                cmd.Parameters.Add("@ADRES", SqlDbType.VarChar, 405).Value = ADRES;
                cmd.Parameters.Add("@SEHIR", SqlDbType.VarChar, 21).Value = SEHIR;
                cmd.Parameters.Add("@SEMT", SqlDbType.VarChar, 51).Value = SEMT;
                cmd.Parameters.Add("@VRGDAIRE", SqlDbType.VarChar, 31).Value = VRGDAIRE;
                cmd.Parameters.Add("@VRGNO", SqlDbType.VarChar, 16).Value = VRGNO;
                cmd.Parameters.Add("@TEL1", SqlDbType.VarChar, 51).Value = TEL1;
                cmd.Parameters.Add("@FAX1", SqlDbType.VarChar, 51).Value = FAX1;
                cmd.Parameters.Add("@EMAIL1", SqlDbType.VarChar, 251).Value = EMAIL1;
                cmd.Parameters.Add("@ILGILI", SqlDbType.VarChar, 21).Value = ILGILI;
                cmd.Parameters.Add("@CEP1", SqlDbType.VarChar, 51).Value = CEP1;
                cmd.Parameters.Add("@NETTOP", SqlDbType.Float).Value = NETTOP;
                cmd.Parameters.Add("@SMREF", SqlDbType.Int).Value = SMREF;
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

        public static void DoUpdateSLS(int SLSREF, int SMREF, int SLSREF2, string SATTEM)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UPDATE [Web-Musteri-Z] SET SLSREF = @SLSREF2, [SAT TEM] = @SATTEM WHERE [SMREF] = @SMREF AND SLSREF = @SLSREF", conn);
                cmd.Parameters.Add("@SLSREF", SqlDbType.Int).Value = SLSREF;
                cmd.Parameters.Add("@SMREF", SqlDbType.Int).Value = SMREF;
                cmd.Parameters.Add("@SLSREF2", SqlDbType.Int).Value = SLSREF2;
                cmd.Parameters.Add("@SATTEM", SqlDbType.VarChar, 51).Value = SATTEM;
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

        public static void GetObjects(DataTable dt, int TIP)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT [ACTIVE],[BOLGE],[GRP],[EKP],[YTK KOD],CASE WHEN [IL KOD] = '' THEN 0 ELSE [IL KOD] END AS [IL KOD],[IL],CASE WHEN [ILCE KOD] = '' THEN 0 ELSE [ILCE KOD] END AS [ILCE KOD],[ILCE],[TIP],TIP_ACIKLAMA,[MT KOD],[MT ACIKLAMA],[UNVAN],[SLSREF],[SAT KOD],[SAT KOD1],[SAT TEM],[GMREF],[MUS KOD],[MUSTERI],[SMREF],[SUB KOD],[SUBE],[ADRES],[SEHIR],[SEMT],[VRG DAIRE],[VRG NO],[TEL-1],[FAX-1],[EMAIL-1],[ILGILI],[CEP-1],[NETTOP]," + 
                    "CASE WHEN TIP = 5 THEN (SELECT DISTINCT SUBE FROM [Web-Musteri-TP] WHERE SMREF = [Web-Musteri-Z].NETTOP) ELSE (SELECT DISTINCT SUBE FROM [Web-Musteri] WHERE SMREF = [Web-Musteri-Z].NETTOP) END AS SUBE_ANA" +
                    " FROM [Web-Musteri-Z] INNER JOIN [Web-Musteri-Z-Tipler] ON [Web-Musteri-Z].[TIP] = [Web-Musteri-Z-Tipler].TIP_KOD WHERE TIP = @TIP ORDER BY [SUBE]", conn);

                if (TIP == 1)
                    da.SelectCommand.CommandText = "SELECT [ACTIVE],[BOLGE],[GRP],[EKP],[YTK KOD],CASE WHEN [IL KOD] = '' THEN 0 ELSE [IL KOD] END AS [IL KOD],[IL],CASE WHEN [ILCE KOD] = '' THEN 0 ELSE [ILCE KOD] END AS [ILCE KOD],[ILCE],1 AS [TIP],'SAP MUSTERILERI' AS TIP_ACIKLAMA,[MT KOD],[MT ACIKLAMA],[UNVAN],[SLSREF],[SAT KOD],[SAT KOD1],[SAT TEM],[GMREF],[MUS KOD],[MUSTERI],[SMREF],[SUB KOD],[SUBE],[ADRES],[SEHIR],[SEMT],[VRG DAIRE],[VRG NO],[TEL-1],[FAX-1],[EMAIL-1],[ILGILI],[CEP-1],[NETTOP],'' AS SUBE_ANA FROM [Web-Musteri] ORDER BY [SAT TEM],MUSTERI,[SUBE]";
                else if (TIP == 4)
                    da.SelectCommand.CommandText = "SELECT [ACTIVE],[BOLGE],[GRP],[EKP],[YTK KOD],CASE WHEN [IL KOD] = '' THEN 0 ELSE [IL KOD] END AS [IL KOD],[IL],CASE WHEN [ILCE KOD] = '' THEN 0 ELSE [ILCE KOD] END AS [ILCE KOD],[ILCE],4 AS [TIP],'BAYII ALT CARILERI' AS TIP_ACIKLAMA,[MT KOD],[MT ACIKLAMA],[UNVAN],[SLSREF],[SAT KOD],[SAT KOD1],(SELECT [SAT TEM] FROM [Web-SatisTemsilcileri] WHERE SLSMANREF = (SELECT DISTINCT [SAT KOD] FROM [Web-Musteri] WHERE GMREF = SMREF AND GMREF = [Web-Musteri-TP].GMREF)) AS [SAT TEM],[GMREF],[MUS KOD],(SELECT BAYIUNVAN FROM [Web-Musteri-TP-Bayikodlar] WHERE BAYIKOD = [Web-Musteri-TP].GMREF) AS [MUSTERI],[SMREF],[SUB KOD],[SUBE],[ADRES],[SEHIR],[SEMT],[VRG DAIRE],[VRG NO],[TEL-1],[FAX-1],[EMAIL-1],[ILGILI],[CEP-1],[NETTOP],'' AS SUBE_ANA FROM [Web-Musteri-TP] WHERE GMREF != SMREF ORDER BY [SAT TEM],MUSTERI,[SUBE]";

                if (TIP != 1 && TIP != 4)
                    da.SelectCommand.Parameters.Add("@TIP", SqlDbType.Int).Value = TIP;

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

        public static CariHesapZ GetObject(int SMREF, int SLSREF)
        {
            CariHesapZ donendeger = new CariHesapZ();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT [ACTIVE],[BOLGE],[GRP],[EKP],[YTK KOD],[IL KOD],[IL],[ILCE KOD],[ILCE],[TIP],[MT KOD],[MT ACIKLAMA],[UNVAN],[SLSREF],[SAT KOD],[SAT KOD1],[SAT TEM],[GMREF],[MUS KOD],[MUSTERI],[SMREF],[SUB KOD],[SUBE],[ADRES],[SEHIR],[SEMT],[VRG DAIRE],[VRG NO],[TEL-1],[FAX-1],[EMAIL-1],[ILGILI],[CEP-1],[NETTOP]" +
                    " FROM [Web-Musteri-Z] WHERE SMREF = @SMREF AND SLSREF = @SLSREF", conn);
                cmd.Parameters.Add("@SMREF", SqlDbType.Int).Value = SMREF;
                cmd.Parameters.Add("@SLSREF", SqlDbType.Int).Value = SLSREF;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        donendeger.ACTIVE = Convert.ToInt16(dr[0]);
                        donendeger.BOLGE = dr[1].ToString();
                        donendeger.GRP = dr[2].ToString();
                        donendeger.EKP = dr[3].ToString();
                        donendeger.YTKKOD = dr[4].ToString();
                        donendeger.ILKOD = dr[5].ToString();
                        donendeger.IL = dr[6].ToString();
                        donendeger.ILCEKOD = dr[7].ToString();
                        donendeger.ILCE = dr[8].ToString();
                        donendeger.TIP = Convert.ToInt32(dr[9]);
                        donendeger.MTKOD = dr[10].ToString();
                        donendeger.MTACIKLAMA = dr[11].ToString();
                        donendeger.UNVAN = dr[12].ToString();
                        donendeger.SLSREF = Convert.ToInt32(dr[13]);
                        donendeger.SATKOD = dr[14].ToString();
                        donendeger.SATKOD1 = dr[15].ToString();
                        donendeger.SATTEM = dr[16].ToString();
                        donendeger.GMREF = Convert.ToInt32(dr[17]);
                        donendeger.MUSKOD = dr[18].ToString();
                        donendeger.MUSTERI = dr[19].ToString();
                        donendeger.SMREF = Convert.ToInt32(dr[20]);
                        donendeger.SUBKOD = dr[21].ToString();
                        donendeger.SUBE = dr[22].ToString();
                        donendeger.ADRES = dr[23].ToString();
                        donendeger.SEHIR = dr[24].ToString();
                        donendeger.SEMT = dr[25].ToString();
                        donendeger.VRGDAIRE = dr[26].ToString();
                        donendeger.VRGNO = dr[27].ToString();
                        donendeger.TEL1 = dr[28].ToString();
                        donendeger.FAX1 = dr[29].ToString();
                        donendeger.EMAIL1 = dr[30].ToString();
                        donendeger.ILGILI = dr[31].ToString();
                        donendeger.CEP1 = dr[32].ToString();
                        donendeger.NETTOP = Convert.ToDouble(dr[33]);
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

        public static CariHesapZ GetObject(int SMREF, int TIP, bool fark)
        {
            CariHesapZ donendeger = new CariHesapZ();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT [ACTIVE],[BOLGE],[GRP],[EKP],[YTK KOD],[IL KOD],[IL],[ILCE KOD],[ILCE],[TIP],[MT KOD],[MT ACIKLAMA],[UNVAN],[SLSREF],[SAT KOD],[SAT KOD1],[SAT TEM],[GMREF],[MUS KOD],[MUSTERI],[SMREF],[SUB KOD],[SUBE],[ADRES],[SEHIR],[SEMT],[VRG DAIRE],[VRG NO],[TEL-1],[FAX-1],[EMAIL-1],[ILGILI],[CEP-1],[NETTOP]" +
                    " FROM [Web-Musteri-Z] WHERE SMREF = @SMREF AND TIP = @TIP", conn);
                cmd.Parameters.Add("@SMREF", SqlDbType.Int).Value = SMREF;
                cmd.Parameters.Add("@TIP", SqlDbType.Int).Value = TIP;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        donendeger.ACTIVE = Convert.ToInt16(dr[0]);
                        donendeger.BOLGE = dr[1].ToString();
                        donendeger.GRP = dr[2].ToString();
                        donendeger.EKP = dr[3].ToString();
                        donendeger.YTKKOD = dr[4].ToString();
                        donendeger.ILKOD = dr[5].ToString();
                        donendeger.IL = dr[6].ToString();
                        donendeger.ILCEKOD = dr[7].ToString();
                        donendeger.ILCE = dr[8].ToString();
                        donendeger.TIP = Convert.ToInt32(dr[9]);
                        donendeger.MTKOD = dr[10].ToString();
                        donendeger.MTACIKLAMA = dr[11].ToString();
                        donendeger.UNVAN = dr[12].ToString();
                        donendeger.SLSREF = Convert.ToInt32(dr[13]);
                        donendeger.SATKOD = dr[14].ToString();
                        donendeger.SATKOD1 = dr[15].ToString();
                        donendeger.SATTEM = dr[16].ToString();
                        donendeger.GMREF = Convert.ToInt32(dr[17]);
                        donendeger.MUSKOD = dr[18].ToString();
                        donendeger.MUSTERI = dr[19].ToString();
                        donendeger.SMREF = Convert.ToInt32(dr[20]);
                        donendeger.SUBKOD = dr[21].ToString();
                        donendeger.SUBE = dr[22].ToString();
                        donendeger.ADRES = dr[23].ToString();
                        donendeger.SEHIR = dr[24].ToString();
                        donendeger.SEMT = dr[25].ToString();
                        donendeger.VRGDAIRE = dr[26].ToString();
                        donendeger.VRGNO = dr[27].ToString();
                        donendeger.TEL1 = dr[28].ToString();
                        donendeger.FAX1 = dr[29].ToString();
                        donendeger.EMAIL1 = dr[30].ToString();
                        donendeger.ILGILI = dr[31].ToString();
                        donendeger.CEP1 = dr[32].ToString();
                        donendeger.NETTOP = Convert.ToDouble(dr[33]);
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

        public static int GetMaxSMREF(int TIP)
        {
            int donendeger = 0;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT max(SMREF) FROM [Web-Musteri-Z] WHERE TIP = @TIP", conn);
                cmd.Parameters.Add("@TIP", SqlDbType.Int).Value = TIP;
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

    public class CariHesapZTipler
    {
        public int TIP_KOD { get; set; }
        public string TIP_ACIKLAMA { get; set; }
        public CariHesapZTipler(int TIP_KOD, string TIP_ACIKLAMA)
        {
            this.TIP_KOD = TIP_KOD;
            this.TIP_ACIKLAMA = TIP_ACIKLAMA;
        }
        public override string ToString()
        {
            return this.TIP_ACIKLAMA;
        }
        public static void GetObjects(IList List)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                List.Clear();

                SqlCommand cmd = new SqlCommand("SELECT TIP_KOD,TIP_ACIKLAMA FROM [Web-Musteri-Z-Tipler] ORDER BY TIP_KOD", conn);
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        List.Add(new CariHesapZTipler(Convert.ToInt32(dr[0]), dr[1].ToString()));
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

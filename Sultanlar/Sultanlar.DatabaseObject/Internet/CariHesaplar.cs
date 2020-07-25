using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Web.UI.WebControls;
using Sultanlar.Class;

namespace Sultanlar.DatabaseObject.Internet
{
    public class CariHesaplar
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
        private CariHesaplar() { }
        public CariHesaplar(int GMREF, int SMREF, string MUSTERI, string SUBE) { this._GMREF = GMREF; this._SMREF = SMREF; this._MUSTERI = MUSTERI; this._SUBE = SUBE; }
        public CariHesaplar(short ACTIVE, string BOLGE, string GRP, string EKP, string YTKKOD, string ILKOD, string IL, string ILCEKOD,
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

        public override string ToString() { return /*"[" + this._SATTEM + "] " + */this._SUBE == string.Empty ? this._MUSTERI : this._SUBE; }
        /// <summary>
        /// [Web-Musteri]
        /// </summary>
        public static CariHesaplar GetObject(int SMREF)
        {
            CariHesaplar donendeger = new CariHesaplar();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT DISTINCT [ACTIVE],[BOLGE],[GRP],[EKP],[YTK KOD],[IL KOD],[IL],[ILCE KOD],[ILCE],[TIP],[MT KOD],[MT ACIKLAMA],[UNVAN],[SLSREF],[SAT KOD],[SAT KOD1],[SAT TEM],[GMREF],[MUS KOD],[MUSTERI],[SMREF],[SUB KOD],[SUBE],[ADRES],[SEHIR],[SEMT],[VRG DAIRE],[VRG NO],[TEL-1],[FAX-1],[EMAIL-1],[ILGILI],[CEP-1],[NETTOP] FROM [Web-Musteri] WHERE SMREF = @SMREF AND [SAT KOD1] = 'VE'", conn); // AND [SAT KOD1] NOT LIKE '8%' AND SUBSTRING([SAT KOD], 11, 2) NOT LIKE '08' AND SUBSTRING([SAT KOD], 11, 2) NOT LIKE '16' AND SUBSTRING([SAT KOD], 11, 2) NOT LIKE '17' AND SUBSTRING([SAT KOD], 11, 2) NOT LIKE '18' AND [SAT KOD] NOT LIKE '00%' AND [YTK KOD] != 'ZIY'
                cmd.Parameters.Add("@SMREF", SqlDbType.Int).Value = SMREF;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        donendeger = new CariHesaplar(Convert.ToInt16(dr[0]), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(),
                            dr[5].ToString(), dr[6].ToString(), dr[7].ToString(), dr[8].ToString(), Convert.ToInt32(dr[9]), dr[10].ToString(),
                            dr[11].ToString(), dr[12].ToString(), Convert.ToInt32(dr[13]), dr[14].ToString(), dr[15].ToString(), dr[16].ToString(),
                            Convert.ToInt32(dr[17]), dr[18].ToString(), dr[19].ToString(), Convert.ToInt32(dr[20]), dr[21].ToString(),
                            dr[22].ToString(), dr[23].ToString(), dr[24].ToString(), dr[25].ToString(), dr[26].ToString(),
                            dr[27].ToString(), dr[28].ToString(), dr[29].ToString(), dr[30].ToString(), dr[31].ToString(), dr[32].ToString(),
                            Convert.ToDouble(dr[33]));
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
        /// <summary>
        /// [Web-Musteri], şubeli müşterilerin ana şubesi gelsin diye
        /// </summary>
        public static CariHesaplar GetObject(int GMREF, bool Anasube)
        {
            CariHesaplar donendeger = new CariHesaplar();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT TOP 1 [ACTIVE],[BOLGE],[GRP],[EKP],[YTK KOD],[IL KOD],[IL],[ILCE KOD],[ILCE],[TIP],[MT KOD],[MT ACIKLAMA],[UNVAN],[SLSREF],[SAT KOD],[SAT KOD1],[SAT TEM],[GMREF],[MUS KOD],[MUSTERI],[SMREF],[SUB KOD],[SUBE],[ADRES],[SEHIR],[SEMT],[VRG DAIRE],[VRG NO],[TEL-1],[FAX-1],[EMAIL-1],[ILGILI],[CEP-1],[NETTOP] FROM [Web-Musteri] WHERE GMREF = @GMREF AND [SAT KOD1] = 'VE' ORDER BY [SUB KOD]", conn); // AND [SAT KOD1] NOT LIKE '8%' AND SUBSTRING([SAT KOD], 11, 2) NOT LIKE '08' AND SUBSTRING([SAT KOD], 11, 2) NOT LIKE '16' AND SUBSTRING([SAT KOD], 11, 2) NOT LIKE '17' AND SUBSTRING([SAT KOD], 11, 2) NOT LIKE '18' AND [SAT KOD] NOT LIKE '00%' AND [YTK KOD] != 'ZIY'
                cmd.Parameters.Add("@GMREF", SqlDbType.Int).Value = GMREF;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        donendeger = new CariHesaplar(Convert.ToInt16(dr[0]), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(),
                            dr[5].ToString(), dr[6].ToString(), dr[7].ToString(), dr[8].ToString(), Convert.ToInt32(dr[9]), dr[10].ToString(),
                            dr[11].ToString(), dr[12].ToString(), Convert.ToInt32(dr[13]), dr[14].ToString(), dr[15].ToString(), dr[16].ToString(),
                            Convert.ToInt32(dr[17]), dr[18].ToString(), dr[19].ToString(), Convert.ToInt32(dr[20]), dr[21].ToString(),
                            dr[22].ToString(), dr[23].ToString(), dr[24].ToString(), dr[25].ToString(), dr[26].ToString(),
                            dr[27].ToString(), dr[28].ToString(), dr[29].ToString(), dr[30].ToString(), dr[31].ToString(), dr[32].ToString(),
                            Convert.ToDouble(dr[33]));
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
        /// <summary>
        /// [Web-Musteri]
        /// </summary>
        public static void GetObjects(DataTable dt, bool UI)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT [ACTIVE],[BOLGE],[GRP],[EKP],[YTK KOD],[IL KOD],[IL],[ILCE KOD],[ILCE],[TIP],[MT KOD],[MT ACIKLAMA],[UNVAN],[SLSREF],[SAT KOD],[SAT KOD1],[SAT TEM],[GMREF],[MUS KOD],[MUSTERI],[SMREF],[SUB KOD],[SUBE],[ADRES],[SEHIR],[SEMT],[VRG DAIRE],[VRG NO],[TEL-1],[FAX-1],[EMAIL-1] FROM [Web-Musteri]", conn);
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
        /// [Web-Musteri], satıcı bilgileri yok distinct ile
        /// </summary>
        public static void GetObjects(IList List, bool UI)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                List.Clear();

                SqlCommand cmd = new SqlCommand("SELECT DISTINCT [ACTIVE],[BOLGE],[GRP],[EKP],[YTK KOD],[IL KOD],[IL],[ILCE KOD],[ILCE],[TIP],[MT KOD],[MT ACIKLAMA],[UNVAN],0 AS [SLSREF],'' AS [SAT KOD],'' AS [SAT KOD1],'' AS [SAT TEM],[GMREF],[MUS KOD],[MUSTERI],[SMREF],[SUB KOD],[SUBE],[ADRES],[SEHIR],[SEMT],[VRG DAIRE],[VRG NO],[TEL-1],[FAX-1],[EMAIL-1],[ILGILI],[CEP-1],[NETTOP] FROM [Web-Musteri] WHERE ACTIVE = 0 ORDER BY MUSTERI", conn);
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        List.Add(new CariHesaplar(Convert.ToInt16(dr[0]), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(),
                            dr[5].ToString(), dr[6].ToString(), dr[7].ToString(), dr[8].ToString(), Convert.ToInt32(dr[9]), dr[10].ToString(),
                            dr[11].ToString(), dr[12].ToString(), Convert.ToInt32(dr[13]), dr[14].ToString(), dr[15].ToString(), dr[16].ToString(),
                            Convert.ToInt32(dr[17]), dr[18].ToString(), dr[19].ToString(), Convert.ToInt32(dr[20]), dr[21].ToString(),
                            dr[22].ToString(), dr[23].ToString(), dr[24].ToString(), dr[25].ToString(), dr[26].ToString(),
                            dr[27].ToString(), dr[28].ToString(), dr[29].ToString(), dr[30].ToString(), dr[31].ToString(), dr[32].ToString(),
                            Convert.ToDouble(dr[33])));
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
        /// <summary>
        /// [Web-Musteri]
        /// </summary>
        public static void GetObjectsWS(DataTable dt, bool UI)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT [Web-Musteri].[SLSREF] AS 'salesman_ref',[Web-Musteri].[SMREF] AS 'substation_ref',CASE WHEN [Web-Musteri].[SUBE] != '' THEN [Web-Musteri].[SUBE] ELSE [Web-Musteri].[MUSTERI] END AS 'substation',[Web-Risk-2].[RISK LMT] AS 'risklimit' FROM [Web-Musteri] INNER JOIN [Web-Risk-2] ON [Web-Musteri].GMREF = [Web-Risk-2].GMREF ORDER BY [Web-Musteri].MUSTERI,[Web-Musteri].SUBE", conn);
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
        /// [Web-Musteri]
        /// </summary>
        public static void GetObjectsWS(DataTable dt, int SLSREF, bool UI)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT [Web-Musteri].[SLSREF] AS 'salesman_ref',[Web-Musteri].[SMREF] AS 'substation_ref',CASE WHEN [Web-Musteri].[SUBE] != '' THEN [Web-Musteri].[SUBE] ELSE [Web-Musteri].[MUSTERI] END AS 'substation',[Web-Risk-2].[RISK LMT] AS 'risklimit' FROM [Web-Musteri] INNER JOIN [Web-Risk-2] ON [Web-Musteri].GMREF = [Web-Risk-2].GMREF WHERE [Web-Musteri].SLSREF = @SLSREF ORDER BY [Web-Musteri].MUSTERI,[Web-Musteri].SUBE", conn);
                da.SelectCommand.Parameters.Add("@SLSREF", SqlDbType.Int).Value = SLSREF;
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
        /// [Web-Musteri]
        /// </summary>
        public static void GetMUSTERIs(IList List, string Musteri, bool sadeceaktifler)
        {
            List.Clear();

            string aktifler = sadeceaktifler ? "ACTIVE = 0 AND " : "";
            string where = Musteri != "" && char.IsDigit(Musteri, 0) ? "GMREF = " + Musteri : "[MUSTERI] LIKE '%" + Musteri + "%'";

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT DISTINCT [GMREF],[MUSTERI] FROM [Web-Musteri] WHERE " + aktifler + where + " ORDER BY MUSTERI", conn);
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        List.Add(new CariHesaplar(Convert.ToInt32(dr[0]), 0, dr[1].ToString(), ""));
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
        /// <summary>
        /// [Web-Musteri]
        /// </summary>
        public static void GetSUBEs(IList List, int GMREF)
        {
            List.Clear();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT DISTINCT [SMREF],[SUBE] FROM [Web-Musteri] WHERE ACTIVE = 0 AND GMREF = " + GMREF.ToString() + " ORDER BY SUBE", conn);
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        List.Add(new CariHesaplar(0, Convert.ToInt32(dr[0]), "", dr[1].ToString()));
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
        /// <summary>
        /// [Web-Musteri]
        /// </summary>
        public static void GetObjectsForCariHesapDuzenleme(DataTable dt, int SLSREF, string CariHesap, bool Baglilar)
        {
            //string musteri = CariHesap != string.Empty ? musteri = "AND [MUSTERI] LIKE '%" + CariHesap + "%' " : string.Empty;

            string sonuc = string.Empty;
            if (CariHesap != string.Empty)
            {
                ArrayList musteriler = StringParcalama.TurkceKarakterPermutasyon(CariHesap);
                sonuc = "AND (";
                for (int i = 0; i < musteriler.Count; i++)
                    sonuc += "MUSTERI LIKE '%" + musteriler[i].ToString() + "%' OR ";
                sonuc = sonuc.Substring(0, sonuc.Length - 4) + ") ";
            }

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                //SqlDataAdapter da = new SqlDataAdapter("SELECT DISTINCT [SMREF],[MUS KOD],CASE WHEN [SUBE] = '' THEN [MUSTERI] ELSE [SUBE] END AS MUSTERI,IsNull((SELECT blCikar FROM [Web-SatTemMusteriTalepleri] WHERE SMREF = [Web-Musteri].[SMREF]), 'False') AS EKSIZ,'False' AS SefOnay FROM [Web-Musteri] WHERE SLSREF = @SLSREF " + sonuc + "UNION SELECT DISTINCT [Web-Musteri].[SMREF],[Web-Musteri].[MUS KOD],CASE WHEN [Web-Musteri].[SUBE] = '' THEN [Web-Musteri].[MUSTERI] ELSE [Web-Musteri].[SUBE] END AS MUSTERI,IsNull((SELECT blCikar FROM [Web-SatTemMusteriTalepleri] WHERE SMREF = [Web-Musteri].[SMREF] AND SLSREF = @SLSREF), 'True') AS EKSIZ,IsNull([Web-SatTemMusteriTalepleri].blSefOnay, 'False') AS SefOnay FROM [Web-Musteri] LEFT OUTER JOIN [Web-SatTemMusteriTalepleri] ON [Web-Musteri].SMREF = [Web-SatTemMusteriTalepleri].SMREF WHERE [Web-Musteri].SLSREF != @SLSREF " + sonuc + "AND [Web-Musteri].SMREF NOT IN (SELECT DISTINCT [SMREF] FROM [Web-Musteri] WHERE SLSREF = @SLSREF) ORDER BY MUSTERI", conn);
                // parçalısı:
                SqlDataAdapter da = new SqlDataAdapter();
                if (Baglilar)
                    da = new SqlDataAdapter("SELECT DISTINCT [SMREF],[MUS KOD],CASE WHEN [SUBE] = '' THEN [MUSTERI] ELSE [SUBE] END AS MUSTERI,IsNull((SELECT blCikar FROM [Web-SatTemMusteriTalepleri] WHERE SMREF = [Web-Musteri].[SMREF]), 'False') AS EKSIZ,'False' AS SefOnay FROM [Web-Musteri] WHERE SLSREF = @SLSREF " + sonuc + " ORDER BY MUSTERI", conn);
                else
                    da = new SqlDataAdapter("SELECT DISTINCT [Web-Musteri].[SMREF],[Web-Musteri].[MUS KOD],CASE WHEN [Web-Musteri].[SUBE] = '' THEN [Web-Musteri].[MUSTERI] ELSE [Web-Musteri].[SUBE] END AS MUSTERI,IsNull((SELECT blCikar FROM [Web-SatTemMusteriTalepleri] WHERE SMREF = [Web-Musteri].[SMREF] AND SLSREF = @SLSREF), 'True') AS EKSIZ,IsNull([Web-SatTemMusteriTalepleri].blSefOnay, 'False') AS SefOnay FROM [Web-Musteri] LEFT OUTER JOIN [Web-SatTemMusteriTalepleri] ON [Web-Musteri].SMREF = [Web-SatTemMusteriTalepleri].SMREF WHERE [Web-Musteri].SLSREF != @SLSREF " + sonuc + "AND [Web-Musteri].SMREF NOT IN (SELECT DISTINCT [SMREF] FROM [Web-Musteri] WHERE SLSREF = @SLSREF) ORDER BY MUSTERI", conn);

                //SqlDataAdapter da1 = new SqlDataAdapter("SELECT DISTINCT [GMREF],[MUS KOD],[MUSTERI],IsNull((SELECT blCikar FROM [Web-SatTemMusteriTalepleri] WHERE GMREF = [Web-Musteri].[GMREF]), 'False') AS EKSIZ FROM [Web-Musteri] WHERE SLSREF = @SLSREF ORDER BY MUSTERI", conn);
                //SqlDataAdapter da2 = new SqlDataAdapter("SELECT DISTINCT [Web-Musteri].[GMREF],[Web-Musteri].[MUS KOD],[Web-Musteri].[MUSTERI],IsNull([Web-SatTemMusteriTalepleri].blCikar, 'True') AS EKSIZ FROM [Web-Musteri] LEFT OUTER JOIN [Web-SatTemMusteriTalepleri] ON [Web-Musteri].GMREF = [Web-SatTemMusteriTalepleri].GMREF WHERE [Web-Musteri].SLSREF != @SLSREF ORDER BY MUSTERI", conn);
                da.SelectCommand.Parameters.Add("@SLSREF", SqlDbType.Int).Value = SLSREF;
                //da1.SelectCommand.Parameters.Add("@SLSREF", SqlDbType.Int).Value = SLSREF;
                //da2.SelectCommand.Parameters.Add("@SLSREF", SqlDbType.Int).Value = SLSREF;
                try
                {
                    conn.Open();
                    da.Fill(dt);
                    //da1.Fill(dt);
                    //da2.Fill(dt);
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
        /// [Web-Musteri]
        /// </summary>
        public static void GetObjects(ListItemCollection lic)
        {
            lic.Clear();

            ListItem lst1 = new ListItem();
            lst1.Text = "Seçiniz";
            lst1.Value = "0";
            lic.Add(lst1);

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT DISTINCT [SMREF],[MUSTERI] + ' : ' + [SUBE],[MUSTERI] FROM [Web-Musteri] ORDER BY [MUSTERI]", conn);
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
        /// <summary>
        /// [Web-Musteri], CariHesaplarTP object i ile geliyor satırlar
        /// </summary>
        public static void GetObjectsLikeTP(IList List)
        {
            List.Clear();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT DISTINCT [GMREF],[MUSTERI] FROM [Web-Musteri] WHERE ACTIVE = 0 AND [YTK KOD] != 'ZIY' ORDER BY [MUSTERI]", conn);
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        List.Add(new CariHesaplarTP(0, "", "", "", "", "", "", "", "", 0, "", "", "", 0, "", "", "", 1, "", dr[1].ToString(),
                            Convert.ToInt32(dr[0]), "", dr[1].ToString(), "", "", "", "", "", "", "", "", "", "", 0));
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
        /// <summary>
        /// [Web-Musteri], CariHesaplarTP object i ile geliyor satırlar
        /// </summary>
        public static void GetObjectsLikeTP(DataTable dt)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT DISTINCT '' AS ACTIVE,'' AS BOLGE,'' AS GRP,'' AS EKP,'' AS [YTK KOD],'' AS [IL KOD],'' AS IL,'' AS [ILCE KOD],'' AS ILCE,'' AS TIP,'' AS [MT KOD],'' AS [MT ACIKLAMA],'' AS UNVAN,'' AS SLSREF,'' AS [SAT KOD],'' AS [SAT KOD1],'' AS [SAT TEM],1 AS GMREF,'' AS [MUS KOD],MUSTERI,[GMREF] AS SMREF,'' AS [SUB KOD],MUSTERI AS SUBE,'' AS ADRES,'' AS SEHIR,'' AS SEMT,'' AS [VRG DAIRE],'' AS [VRG NO],'' AS [TEL-1],'' AS [FAX-1],'' AS [EMAIL-1],'' AS ILGILI,'' AS [CEP-1],'' AS ILGILI FROM [Web-Musteri] WHERE ACTIVE = 0 AND [YTK KOD] != 'ZIY' ORDER BY [MUSTERI]", conn);
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
        /// [Web-Musteri]
        /// </summary>
        public static void GetObjects(ListItemCollection lic, ArrayList SLSREFs, bool Web)
        {
            lic.Clear();

            ListItem lst1 = new ListItem();
            lst1.Text = "Seçiniz";
            lst1.Value = "0";
            lic.Add(lst1);

            string slsrefs = string.Empty;
            if (SLSREFs.Count > 0)
                slsrefs = "WHERE ";
            for (int i = 0; i < SLSREFs.Count; i++)
                slsrefs += "SLSREF = " + SLSREFs[i].ToString() + " OR ";
            if (SLSREFs.Count > 0)
                slsrefs = slsrefs.Substring(0, slsrefs.Length - 3);

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT DISTINCT [SMREF],[MUSTERI] + ' : ' + [SUBE],[MUSTERI] FROM [Web-Musteri] " + slsrefs + "ORDER BY [MUSTERI]", conn);
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
        /// <summary>
        /// [Web-Musteri]
        /// </summary>
        public static void GetObjectsByVergiNo(DataTable dt, string VergiNo)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT DISTINCT [ACTIVE],[GMREF],[MT ACIKLAMA],[MUS KOD],[MUSTERI],[SAT TEM],[VRG DAIRE],[VRG NO],[ILGILI],[TEL-1] FROM [Web-Musteri] WHERE [VRG NO] = @VergiNo", conn);
                da.SelectCommand.Parameters.Add("@VergiNo", SqlDbType.VarChar, 16).Value = VergiNo;
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
        /// [Web-Musteri]
        /// </summary>
        public static void GetObjectsByMusteri(DataTable dt, string Musteri)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT DISTINCT [ACTIVE],[GMREF],[MT ACIKLAMA],[MUS KOD],[MUSTERI],[SAT TEM],[VRG DAIRE],[VRG NO],[ILGILI],[TEL-1] FROM [Web-Musteri] WHERE MUSTERI LIKE '%" + Musteri + "%' ORDER BY [MUSTERI]", conn);
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
        /// [Web-Musteri], carihesaplartp için, gmref = smref olanlar geliyor her müşteri bir defa geliyor (sadece bizdeki sattem ile) ziy ler yok
        /// </summary>
        public static void GetObjectsByMusteri(IList List, string Musteri, bool UI, bool carihesaplartp)
        {
            List.Clear();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT DISTINCT [ACTIVE],[BOLGE],[GRP],[EKP],[YTK KOD],[IL KOD],[IL],[ILCE KOD],[ILCE],[TIP],[MT KOD],[MT ACIKLAMA],[UNVAN],[SLSREF],[SAT KOD],[SAT KOD1],[SAT TEM],[GMREF],[MUS KOD],[MUSTERI],[SMREF],[SUB KOD],[SUBE],[ADRES],[SEHIR],[SEMT],[VRG DAIRE],[VRG NO],[TEL-1],[FAX-1],[EMAIL-1],[ILGILI],[CEP-1],[NETTOP] FROM [Web-Musteri] WHERE MUSTERI LIKE '%" + Musteri + "%' AND GMREF = SMREF AND [SAT KOD1] = 'VE' ORDER BY MUSTERI", conn); //AND [SAT KOD1] NOT LIKE '8%' AND SUBSTRING([SAT KOD], 11, 2) NOT LIKE '08' AND SUBSTRING([SAT KOD], 11, 2) NOT LIKE '16' AND SUBSTRING([SAT KOD], 11, 2) NOT LIKE '17' AND SUBSTRING([SAT KOD], 11, 2) NOT LIKE '18' AND [SAT KOD] NOT LIKE '00%' AND [YTK KOD] != 'ZIY' 
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        List.Add(new CariHesaplar(Convert.ToInt16(dr[0]), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(),
                            dr[5].ToString(), dr[6].ToString(), dr[7].ToString(), dr[8].ToString(), Convert.ToInt32(dr[9]), dr[10].ToString(),
                            dr[11].ToString(), dr[12].ToString(), Convert.ToInt32(dr[13]), dr[14].ToString(), dr[15].ToString(), dr[16].ToString(),
                            Convert.ToInt32(dr[17]), dr[18].ToString(), dr[19].ToString(), Convert.ToInt32(dr[20]), dr[21].ToString(),
                            dr[22].ToString(), dr[23].ToString(), dr[24].ToString(), dr[25].ToString(), dr[26].ToString(),
                            dr[27].ToString(), dr[28].ToString(), dr[29].ToString(), dr[30].ToString(), dr[31].ToString(), dr[32].ToString(),
                            dr[33] != DBNull.Value ? Convert.ToDouble(dr[33]) : 0));
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
        /// <summary>
        /// [Web-Musteri]
        /// </summary>
        public static void GetObjectsByMusteriSube(DataTable dt, string Musteri, string Sube)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT DISTINCT [ACTIVE],[GMREF],[MT ACIKLAMA],[MUS KOD],[MUSTERI],SMREF,SUBE,[SAT TEM],[VRG DAIRE],[VRG NO],[ILGILI],[TEL-1] FROM [Web-Musteri] WHERE MUSTERI LIKE '%" + Musteri + "%' AND SUBE LIKE '%" + Sube + "%' ORDER BY [MUSTERI],SUBE", conn);
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
        /// web-16-400 den geliyor, TIP != 3
        /// </summary>
        public static void GetObjectsByMusteri(DataTable dt, string MusteriBaslangici, bool viewweb16)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT DISTINCT [GMREF],[MUS KOD],[MUSTERI] FROM [Web-Musteri] WHERE TIP != 3 AND MUSTERI LIKE '" + MusteriBaslangici + "%' ORDER BY [MUSTERI]", conn);
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
        /// [Web-Musteri], ZİY ler gelmiyor
        /// </summary>
        public static void GetObjectsByMusteri(DataTable dt, string Musteri, int SLSREF)
        {
            ArrayList musteriler = Sultanlar.Class.StringParcalama.TurkceKarakterPermutasyon(Musteri);
            string musteri = string.Empty;
            if (musteriler.Count > 0)
                musteri = "(";
            for (int i = 0; i < musteriler.Count; i++)
                musteri += "MUSTERI LIKE '%" + musteriler[i].ToString() + "%' OR ";
            if (musteriler.Count > 0)
                musteri = musteri.Substring(0, musteri.Length - 4) + ") AND ";

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT DISTINCT [SMREF],CASE WHEN [SUB KOD] = '' THEN [MUS KOD] ELSE [SUB KOD] END AS [SUB KOD],CASE WHEN [SUBE] = '' THEN [MUSTERI] ELSE [SUBE] END AS SUBE FROM [Web-Musteri] WHERE ACTIVE = 0 AND [YTK KOD] != 'ZIY' AND " + musteri + "SLSREF = " + SLSREF.ToString() + " ORDER BY SUBE", conn);
                // eski ZİY (([MUS KOD] NOT LIKE '0%' AND GMREF = SMREF) OR ([MUS KOD] LIKE '0%' AND GMREF != SMREF))
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
        /// [Web-Musteri]
        /// </summary>
        public static ArrayList GetObjectByGMREF(int GMREF)
        {
            ArrayList donendeger = new ArrayList();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT TOP 1 [MUS KOD],[MUSTERI] FROM [Web-Musteri] WHERE [GMREF] = @GMREF", conn);
                cmd.Parameters.Add("@GMREF", SqlDbType.Int).Value = GMREF;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        donendeger.Add(dr[0].ToString());
                        donendeger.Add(dr[1].ToString());
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
        /// <summary>
        /// [Web-Musteri]
        /// </summary>
        public static ArrayList GetObjectBySMREF(int SMREF)
        {
            ArrayList donendeger = new ArrayList();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT DISTINCT [MUS KOD],[MUSTERI] FROM [Web-Musteri] WHERE [SMREF] = @SMREF", conn);
                cmd.Parameters.Add("@SMREF", SqlDbType.Int).Value = SMREF;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        donendeger.Add(dr[0].ToString());
                        donendeger.Add(dr[1].ToString());
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
        /// <summary>
        /// [Web-Musteri] Gönderilen SMREF eğer tek şubeli bir cari ise musteriyi ve musteri kodunu alıp getirecek sube ve sube kod yerine
        /// </summary>
        public static ArrayList GetSubeBySMREF(int SMREF)
        {
            ArrayList donendeger = new ArrayList();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT DISTINCT [SUB KOD],[SUBE],[MUS KOD],[MUSTERI] FROM [Web-Musteri] WHERE [SMREF] = @SMREF", conn);
                cmd.Parameters.Add("@SMREF", SqlDbType.Int).Value = SMREF;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        donendeger.Add(dr[0].ToString());
                        donendeger.Add(dr[1].ToString());

                        if (donendeger[0].ToString() == string.Empty && SMREF > 0)
                            donendeger[0] = dr[2].ToString();
                        if (donendeger[1].ToString() == string.Empty && SMREF > 0)
                            donendeger[1] = dr[3].ToString();
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
        /// <summary>
        /// [Web-Risk-2]
        /// </summary>
        public static void GetObjectByGMREF(DataTable dt, int GMREF)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT [RISK LMT],[BAKIYE],[ACK GUN],[C/S TOP],[IRS TOP],([SIP TOPL]+[SIP TOPQ]) AS [SIP TOP],[SIP TOPLB],[RISK BKY],[VB GUN],[VB TOP],[VGB GUN],[VGB TOP],[GMREF],[MUS KOD],[MUSTERI] FROM [Web-Risk-2] WHERE [GMREF] = @GMREF", conn);
                da.SelectCommand.Parameters.Add("@GMREF", SqlDbType.Int).Value = GMREF;
                da.SelectCommand.CommandTimeout = 400;
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
        /// [Web-Risk-2]
        /// </summary>
        public static ArrayList GetObjectByGMREF(int GMREF, bool bakiyeler)
        {
            ArrayList donendeger = new ArrayList();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT [RISK LMT],[BAKIYE],[ACK GUN],[C/S TOP],[IRS TOP],([SIP TOPL]+[SIP TOPQ]) AS [SIP TOP],[SIP TOPLB],[RISK BKY],[VGB GUN],[VGB TOP],[VB GUN],[VB TOP],[GMREF],[MUS KOD],[MUSTERI] FROM [Web-Risk-2] WHERE [GMREF] = @GMREF", conn);
                cmd.Parameters.Add("@GMREF", SqlDbType.Int).Value = GMREF;
                cmd.CommandTimeout = 400;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        if (dr[0] != DBNull.Value) donendeger.Add(Convert.ToDouble(dr[0])); else donendeger.Add(0);

                        if (dr[1] != DBNull.Value) donendeger.Add(Convert.ToDouble(dr[1])); else donendeger.Add(0);

                        if (dr[2] != DBNull.Value) donendeger.Add(Convert.ToInt32(dr[2])); else donendeger.Add(0);

                        if (dr[3] != DBNull.Value) donendeger.Add(Convert.ToDouble(dr[3])); else donendeger.Add(0);

                        if (dr[4] != DBNull.Value) donendeger.Add(Convert.ToDouble(dr[4])); else donendeger.Add(0);

                        if (dr[5] != DBNull.Value) donendeger.Add(Convert.ToDouble(dr[5])); else donendeger.Add(0);

                        if (dr[6] != DBNull.Value) donendeger.Add(Convert.ToDouble(dr[6])); else donendeger.Add(0);

                        if (dr[7] != DBNull.Value) donendeger.Add(Convert.ToDouble(dr[7])); else donendeger.Add(0);

                        if (dr[8] != DBNull.Value) donendeger.Add(Convert.ToInt32(dr[8])); else donendeger.Add(0);

                        if (dr[9] != DBNull.Value) donendeger.Add(Convert.ToDouble(dr[9])); else donendeger.Add(0);

                        if (dr[10] != DBNull.Value) donendeger.Add(Convert.ToDouble(dr[10])); else donendeger.Add(0);

                        if (dr[11] != DBNull.Value) donendeger.Add(Convert.ToDouble(dr[11])); else donendeger.Add(0);
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
        /// <summary>
        /// [SAP_SIPARIS_STR_DRM]
        /// </summary>
        public static double GetIrsTopByGMREF(int GMREF)
        {
            double donendeger = 0;
            SqlCommand cmd = new SqlCommand("SELECT ISNULL(sum(CASE WHEN KOLI != 0 THEN (IRS_AD - IPT) / KOLI END),0) FROM [SAP_SIPARIS_STR_DRM] INNER JOIN [Web-Malzeme-Full] ON [SAP_SIPARIS_STR_DRM].MALZ_KOD = [Web-Malzeme-Full].ITEMREF WHERE RED_KOD = 0 AND MUST_KOD = @GMREF", new SqlConnection(General.ConnectionString));
            cmd.Parameters.Add("@GMREF", SqlDbType.Int).Value = GMREF;
            cmd.Connection.Open(); donendeger = Convert.ToDouble(cmd.ExecuteScalar()); cmd.Connection.Close();
            return donendeger;
        }
        /// <summary>
        /// [SAP_SIPARIS_STR_DRM]
        /// </summary>
        public static double GetSipTopByGMREF(int GMREF)
        {
            double donendeger = 0;
            SqlCommand cmd = new SqlCommand("SELECT ISNULL(sum(CASE WHEN KOLI != 0 THEN (SIP_AD - IPT) / KOLI END),0) FROM [SAP_SIPARIS_STR_DRM] INNER JOIN [Web-Malzeme-Full] ON [SAP_SIPARIS_STR_DRM].MALZ_KOD = [Web-Malzeme-Full].ITEMREF WHERE RED_KOD = 0 AND TSL_AD = 0 AND IRS_AD = 0 AND BKY_AD = 0 AND MUST_KOD = @GMREF", new SqlConnection(General.ConnectionString));
            cmd.Parameters.Add("@GMREF", SqlDbType.Int).Value = GMREF;
            cmd.Connection.Open(); donendeger = Convert.ToDouble(cmd.ExecuteScalar()); cmd.Connection.Close();
            return donendeger;
        }
        /// <summary>
        /// [SAP_SIPARIS_STR_DRM]
        /// </summary>
        public static double GetBakTopByGMREF(int GMREF)
        {
            double donendeger = 0;
            SqlCommand cmd = new SqlCommand("SELECT ISNULL(sum(CASE WHEN KOLI != 0 THEN (BKY_AD - IPT) / KOLI END),0) FROM [SAP_SIPARIS_STR_DRM] INNER JOIN [Web-Malzeme-Full] ON [SAP_SIPARIS_STR_DRM].MALZ_KOD = [Web-Malzeme-Full].ITEMREF WHERE RED_KOD = 0 AND TSL_AD = 0 AND IRS_AD = 0 AND MUST_KOD = @GMREF", new SqlConnection(General.ConnectionString));
            cmd.Parameters.Add("@GMREF", SqlDbType.Int).Value = GMREF;
            cmd.Connection.Open(); donendeger = Convert.ToDouble(cmd.ExecuteScalar()); cmd.Connection.Close();
            return donendeger;
        }
        /// <summary>
        /// 
        /// </summary>
        public static double GetVgbTopByGMREF(int GMREF)
        {
            double donendeger = 0;
            SqlCommand cmd = new SqlCommand("SELECT ISNULL([VGB],0) FROM [dbo].[SAP_B_A_2017] WHERE [MUS KOD] = @GMREF", new SqlConnection(General.ConnectionString));
            cmd.Parameters.Add("@GMREF", SqlDbType.Int).Value = GMREF;
            cmd.Connection.Open(); donendeger = Convert.ToDouble(cmd.ExecuteScalar()); cmd.Connection.Close();
            return donendeger;
        }
        /// <summary>
        /// 
        /// </summary>
        public static double GetVgbVdByGMREF(int GMREF)
        {
            double donendeger = 0;
            SqlCommand cmd = new SqlCommand("SELECT ISNULL([VGB_VD],0) FROM [dbo].[SAP_B_A_2017] WHERE [MUS KOD] = @GMREF", new SqlConnection(General.ConnectionString));
            cmd.Parameters.Add("@GMREF", SqlDbType.Int).Value = GMREF;
            cmd.Connection.Open(); donendeger = Convert.ToDouble(cmd.ExecuteScalar()); cmd.Connection.Close();
            return donendeger;
        }
        /// <summary>
        /// [Web-Musteri]
        /// </summary>
        public static void GetObjectByGMREF(DataTable dt, int GMREF, bool SatisTemsilcisi)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT DISTINCT [GMREF],[MUS KOD],[MUSTERI],NULL AS SMREF,(SELECT sum(NETTOP) FROM (SELECT NETTOP FROM [Web-Musteri] WHERE [GMREF] = MUSTERILER.GMREF GROUP BY SMREF,NETTOP) AS NETTOPLAR) AS NETTOP,NULL AS TEDNETTOP,(SELECT TOP 1 [ADRES] FROM [Web-Musteri] WHERE [GMREF] = MUSTERILER.GMREF) AS [ADRES],(SELECT TOP 1 [SEHIR] FROM [Web-Musteri] WHERE [GMREF] = MUSTERILER.GMREF) AS [SEHIR],(SELECT TOP 1 [SEMT] FROM [Web-Musteri] WHERE [GMREF] = MUSTERILER.GMREF) AS [SEMT],(SELECT TOP 1 [TEL-1] FROM [Web-Musteri] WHERE [GMREF] = MUSTERILER.GMREF) AS [TEL-1],(SELECT TOP 1 [CEP-1] FROM [Web-Musteri] WHERE [GMREF] = MUSTERILER.GMREF) AS [CEP-1],(SELECT TOP 1 [EMAIL-1] FROM [Web-Musteri] WHERE [GMREF] = MUSTERILER.GMREF) AS [EMAIL-1],(SELECT TOP 1 [ILGILI] FROM [Web-Musteri] WHERE [GMREF] = MUSTERILER.GMREF) AS ILGILI FROM [Web-Musteri] AS MUSTERILER WHERE [GMREF] = @GMREF", conn);
                da.SelectCommand.Parameters.Add("@GMREF", SqlDbType.Int).Value = GMREF;
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
        /// [Web-Musteri], tednettop u default.aspx e ekleyebilmek icin slsrefe ihtiyac oldu
        /// </summary>
        public static void GetObjectByGMREF(DataTable dt, int GMREF, int SLSREF, bool SatisTemsilcisi)
        {
            /*SAP*/
            string nst = " AND SLSREF = " + SLSREF.ToString(); //SatisTemsilcileri.GetSATKOD1BySLSREF(SLSREF).StartsWith("8") || SatisTemsilcileri.GetSATKODBySLSREF(SLSREF).Substring(10).StartsWith("08") ? " AND SLSREF = " + SLSREF.ToString() : "";

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT DISTINCT [GMREF],[MUS KOD],[SUB KOD],[MUSTERI],NULL AS SMREF,SMREF AS SMREF1,(SELECT sum(NETTOP) FROM (SELECT NETTOP FROM [Web-Musteri] WHERE [GMREF] = MUSTERILER.GMREF" + nst + " GROUP BY SMREF,NETTOP) AS NETTOPLAR) AS NETTOP,'<b>İletişim bilgileri için ilgili şubeye bakınız.</b>' AS [ADRES],'-' AS [SEHIR],'-' AS [SEMT],'-' AS [TEL-1],'-' AS [CEP-1],'-' AS [EMAIL-1],'-' AS ILGILI FROM [Web-Musteri] AS MUSTERILER WHERE ACTIVE = 0 AND [GMREF] = @GMREF AND GMREF = SMREF ORDER BY [SUB KOD]", conn); //GMREF = SMREF ekledim çünkü default.aspx te anacariler kısmında aktivite girmek isterken SMREF1 alt carininki çıkıyordu
                // (SELECT sum([NET T]) FROM [KurumsalWebSAP].[dbo].[Web-Satis-Rapor] WHERE TEDSLSREF = " + SLSREF.ToString() + " AND GMREF = MUSTERILER.GMREF AND AY = (SELECT Month(getdate()))) AS TEDNETTOP,
                da.SelectCommand.Parameters.Add("@GMREF", SqlDbType.Int).Value = GMREF;
                da.SelectCommand.CommandTimeout = 400;
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
        /// [Web-Musteri]
        /// </summary>
        public static void GetObjectByGMREF(DataTable dt, int GMREF, bool SatisTemsilcisi, bool SatisTemsilcisiIsmiyle)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT DISTINCT [GMREF],[MUS KOD],[SAT TEM] + ' - ' + [MUSTERI] AS MUSTERI FROM [Web-Musteri] WHERE [GMREF] = @GMREF", conn);
                da.SelectCommand.Parameters.Add("@GMREF", SqlDbType.Int).Value = GMREF;
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
        /// [Web-Musteri], başta satış temsilcisi ismi var
        /// </summary>
        public static void GetObjectByGMREF(DataTable dt, int GMREF, int SLSREF, bool SatisTemsilcisi, bool SatisTemsilcisiIsmiyle)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT DISTINCT [GMREF],[MUS KOD],[SAT TEM] + ' - ' + [MUSTERI] FROM [Web-Musteri] WHERE [GMREF] = @GMREF AND [SLSREF] = @SLSREF", conn);
                da.SelectCommand.Parameters.Add("@GMREF", SqlDbType.Int).Value = GMREF;
                da.SelectCommand.Parameters.Add("@SLSREF", SqlDbType.Int).Value = SLSREF;
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
        /// [Web-Musteri], ZİY ler gelmiyor
        /// </summary>
        public static void GetSubeler(DataTable dt, int GMREF)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT DISTINCT [GMREF],[MUS KOD],[SMREF],[SUB KOD],[SUBE] FROM [Web-Musteri] WHERE ACTIVE = 0 AND [GMREF] = @GMREF AND [YTK KOD] != 'ZIY' ORDER BY [SUBE]", conn);
                da.SelectCommand.Parameters.Add("@GMREF", SqlDbType.Int).Value = GMREF;
                da.SelectCommand.CommandTimeout = 400;
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
        /// [Web-Musteri], ZİY ler gelmiyor, aktif pasif hepsi
        /// </summary>
        public static void GetSubelerTUMU(DataTable dt, int GMREF)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT DISTINCT [GMREF],[MUS KOD],[SMREF],[SUB KOD],[SUBE] FROM [Web-Musteri] WHERE [GMREF] = @GMREF AND [YTK KOD] != 'ZIY' ORDER BY [SUBE]", conn);
                da.SelectCommand.Parameters.Add("@GMREF", SqlDbType.Int).Value = GMREF;
                da.SelectCommand.CommandTimeout = 400;
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
        /// [Web-Musteri]
        /// </summary>
        public static void GetSubelerBySLSREF(DataTable dt, int GMREF, int SLSREF)
        {
            /*SAP*/
            string nst = " AND SLSREF = " + SLSREF.ToString(); //SatisTemsilcileri.GetSATKOD1BySLSREF(SLSREF).StartsWith("8") || SatisTemsilcileri.GetSATKODBySLSREF(SLSREF).Substring(10).StartsWith("08") ? " AND SLSREF = " + SLSREF.ToString() : "";

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                //SqlDataAdapter da = new SqlDataAdapter("SELECT DISTINCT [GMREF],[MUS KOD],[SMREF],[SUB KOD],[SUBE],NETTOP,(SELECT sum([NET T]) FROM [KurumsalWebSAP].[dbo].[Web-Satis-Rapor] WHERE TEDSLSREF = @SLSREF AND SMREF = MUSTERILER.SMREF AND AY = (SELECT Month(getdate()))) AS TEDNETTOP,(SELECT TOP 1 [ADRES] FROM [Web-Musteri] WHERE [SMREF] = MUSTERILER.SMREF) AS [ADRES],(SELECT TOP 1 [SEHIR] FROM [Web-Musteri] WHERE [SMREF] = MUSTERILER.SMREF) AS [SEHIR],(SELECT TOP 1 [SEMT] FROM [Web-Musteri] WHERE [SMREF] = MUSTERILER.SMREF) AS [SEMT],(SELECT TOP 1 [TEL-1] FROM [Web-Musteri] WHERE [SMREF] = MUSTERILER.SMREF) AS [TEL-1],(SELECT TOP 1 [CEP-1] FROM [Web-Musteri] WHERE [SMREF] = MUSTERILER.SMREF) AS [CEP-1],(SELECT TOP 1 [EMAIL-1] FROM [Web-Musteri] WHERE [SMREF] = MUSTERILER.SMREF) AS [EMAIL-1],(SELECT TOP 1 [ILGILI] FROM [Web-Musteri] WHERE [SMREF] = MUSTERILER.SMREF) AS ILGILI FROM [Web-Musteri] AS MUSTERILER WHERE [GMREF] = @GMREF AND SLSREF = @SLSREF ORDER BY [SUBE]", conn);
                SqlDataAdapter da = new SqlDataAdapter("SELECT DISTINCT [GMREF],[MUS KOD],[SMREF],[SUB KOD],[SUBE],sum(NETTOP) AS NETTOP,[ADRES],[SEHIR],[SEMT],[TEL-1],[CEP-1],[EMAIL-1],ILGILI FROM [Web-Musteri] AS MUSTERILER WHERE ACTIVE = 0 AND [GMREF] = @GMREF" + nst + " GROUP BY [GMREF],[MUS KOD],[SMREF],[SUB KOD],[SUBE],[ADRES],[SEHIR],[SEMT],[TEL-1],[CEP-1],[EMAIL-1],ILGILI ORDER BY [SUBE]", conn);
                // (SELECT sum([NET T]) FROM [KurumsalWebSAP].[dbo].[Web-Satis-Rapor] WHERE TEDSLSREF = @SLSREF AND SMREF = MUSTERILER.SMREF AND AY = (SELECT Month(getdate()))) AS TEDNETTOP,
                da.SelectCommand.CommandTimeout = 200;
                da.SelectCommand.Parameters.Add("@GMREF", SqlDbType.Int).Value = GMREF;
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
        /// [Web-Musteri], value nun başına text in ilk 3 hanesi yazılıyor
        /// </summary>
        public static void GetSubeler(ListItemCollection lic, int GMREF)
        {
            lic.Clear();

            ListItem lst1 = new ListItem();
            lst1.Text = "Seçiniz";
            lst1.Value = "HIC0";
            lic.Add(lst1);

            lst1 = new ListItem();
            lst1.Text = "Tümü";
            lst1.Value = "TUM1";
            lic.Add(lst1);

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT DISTINCT [SMREF],[SUBE] FROM [Web-Musteri] WHERE [GMREF] = @GMREF ORDER BY [SUBE]", conn);
                cmd.Parameters.Add("@GMREF", SqlDbType.Int).Value = GMREF;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        ListItem lst = new ListItem();
                        lst.Text = dr[1].ToString();
                        lst.Value = dr[1].ToString().Substring(0, 3) + dr[0].ToString();
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
        /// <summary>
        /// [Web-Musteri], value nun başına text in ilk 3 hanesi yazılıyor
        /// </summary>
        public static void GetSubelerBySLSREF(ListItemCollection lic, int GMREF, int SLSREF)
        {
            lic.Clear();

            ListItem lst1 = new ListItem();
            lst1.Text = "Seçiniz";
            lst1.Value = "0";
            lic.Add(lst1);

            lst1 = new ListItem();
            lst1.Text = "Tümü";
            lst1.Value = "1";
            lic.Add(lst1);

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT DISTINCT [SMREF],[SUBE] FROM [Web-Musteri] WHERE [GMREF] = @GMREF AND SLSREF = @SLSREF ORDER BY [SUBE]", conn);
                cmd.Parameters.Add("@GMREF", SqlDbType.Int).Value = GMREF;
                cmd.Parameters.Add("@SLSREF", SqlDbType.Int).Value = SLSREF;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        ListItem lst = new ListItem();
                        lst.Text = dr[1].ToString();
                        lst.Value = dr[1].ToString().Substring(0, 3) + dr[0].ToString();
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
        /// <summary>
        /// [Web-Musteri], value nun başına text in ilk 3 hanesi yazılıyor
        /// </summary>
        public static void GetSubelerBySLSREFs(ListItemCollection lic, int GMREF, ArrayList SLSREFs)
        {
            lic.Clear();

            ListItem lst1 = new ListItem();
            lst1.Text = "Seçiniz";
            lst1.Value = "0";
            lic.Add(lst1);

            lst1 = new ListItem();
            lst1.Text = "Tümü";
            lst1.Value = "1";
            lic.Add(lst1);

            string slsrefs = "AND (";
            for (int i = 0; i < SLSREFs.Count; i++)
            {
                slsrefs += "SLSREF = " + SLSREFs[i].ToString() + " OR ";
            }
            slsrefs = slsrefs.Substring(0, slsrefs.Length - 4) + ")";

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT DISTINCT [SMREF],[SUBE] FROM [Web-Musteri] WHERE [GMREF] <> [SMREF] AND [GMREF] = @GMREF AND " + slsrefs + " ORDER BY [SUBE]", conn);
                cmd.Parameters.Add("@GMREF", SqlDbType.Int).Value = GMREF;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        ListItem lst = new ListItem();
                        lst.Text = dr[1].ToString();
                        lst.Value = dr[1].ToString().Substring(0, 3) + dr[0].ToString();
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
        /// <summary>
        /// [Web-Musteri] [Web-Risk-2]
        /// </summary>
        public static void GetObjectsBySLSREF(DataTable dt, int SLSREF)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT [Web-Risk-2].[GMREF],[Web-Risk-2].[MUS KOD],[Web-Risk-2].[MUSTERI],[Web-Risk-2].[BAKIYE],[Web-Risk-2].[RISK BKY],[Web-Risk-2].[VGB GUN],[Web-Risk-2].[VGB TOP],[Web-Musteri].[MUS KOD],[Web-Musteri].[MUSTERI],[Web-Musteri].[SMREF],[Web-Musteri].[SUB KOD],[Web-Musteri].[SUBE] FROM [Web-Risk-2] INNER JOIN [Web-Musteri] ON [Web-Risk-2].[GMREF] = [Web-Musteri].[GMREF] WHERE [Web-Musteri].[SLSREF] = @SLSREF ORDER BY [Web-Risk-2].[MUSTERI],[Web-Musteri].[SUBE]", conn);
                da.SelectCommand.Parameters.Add("@SLSREF", SqlDbType.Int).Value = SLSREF;
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
        /// [Web-Musteri]
        /// </summary>
        public static void GetObjectsBySLSREFforFarkliZiyaretBaslat(DataTable dt, int SLSREF, string SUBE)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT TIP AS MTIP,[MUS KOD],[MUSTERI],[SMREF],[SUB KOD],[SUBE],(SELECT TOP 1 [ADRES] FROM [Web-Musteri] WHERE [SMREF] = MUSTERILER.SMREF) AS [ADRES],(SELECT TOP 1 [SEHIR] FROM [Web-Musteri] WHERE [SMREF] = MUSTERILER.SMREF) AS [SEHIR],(SELECT TOP 1 [SEMT] FROM [Web-Musteri] WHERE [SMREF] = MUSTERILER.SMREF) AS [SEMT],(SELECT TOP 1 [TEL-1] FROM [Web-Musteri] WHERE [SMREF] = MUSTERILER.SMREF) AS [TEL-1],(SELECT TOP 1 [CEP-1] FROM [Web-Musteri] WHERE [SMREF] = MUSTERILER.SMREF) AS [CEP-1],(SELECT TOP 1 [EMAIL-1] FROM [Web-Musteri] WHERE [SMREF] = MUSTERILER.SMREF) AS [EMAIL-1],(SELECT TOP 1 [ILGILI] FROM [Web-Musteri] WHERE [SMREF] = MUSTERILER.SMREF) AS ILGILI FROM [Web-Musteri-1] AS MUSTERILER WHERE ACTIVE = 0 AND [SLSREF] = @SLSREF AND SUBE LIKE '%" + SUBE + "%' ORDER BY [MUSTERI],[SUBE]", conn);
                da.SelectCommand.Parameters.Add("@SLSREF", SqlDbType.Int).Value = SLSREF;
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
        /// [Web-Musteri]
        /// </summary>
        public static void GetSMREFsBySLSREF(DataTable dt, int SLSREF)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT DISTINCT [SMREF] FROM [Web-Musteri] WHERE [SLSREF] = @SLSREF", conn);
                da.SelectCommand.Parameters.Add("@SLSREF", SqlDbType.Int).Value = SLSREF;
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
        /// [Web-Musteri]
        /// </summary>
        public static void GetSMREFsBySLSREF(ArrayList smrefs, int SLSREF)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT DISTINCT [SMREF] FROM [Web-Musteri] WHERE [SLSREF] = @SLSREF", conn);
                cmd.Parameters.Add("@SLSREF", SqlDbType.Int).Value = SLSREF;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        smrefs.Add(Convert.ToInt32(dr[0]));
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
        /// <summary>
        /// [Web-Musteri]
        /// </summary>
        public static void GetSMREFsBySLSREFs(ArrayList smrefs, ArrayList SLSREFs)
        {
            string slsrefs = string.Empty;
            if (SLSREFs.Count > 0)
            {
                slsrefs = " WHERE";
                for (int i = 0; i < SLSREFs.Count; i++)
                {
                    slsrefs += " SLSREF = " + SLSREFs[i].ToString() + " OR";
                }
                slsrefs = slsrefs.Substring(0, slsrefs.Length - 3);
            }

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT DISTINCT [SMREF] FROM [Web-Musteri]" + slsrefs, conn);
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        smrefs.Add(Convert.ToInt32(dr[0]));
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
        /// <summary>
        /// [Web-Musteri]
        /// </summary>
        public static int GetGMREFBySMREF(int SMREF)
        {
            int donendeger = 0;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT DISTINCT [GMREF] FROM [Web-Musteri] WHERE [SMREF] = @SMREF", conn);
                cmd.Parameters.Add("@SMREF", SqlDbType.Int).Value = SMREF;
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
        /// <summary>
        /// [Web-Musteri], sube kodu en küçük olan
        /// </summary>
        public static int GetSMREFByGMREF(int GMREF)
        {
            int donendeger = 0;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT TOP 1 [SMREF] FROM [Web-Musteri] WHERE [GMREF] = @GMREF ORDER BY [SUB KOD]", conn);
                cmd.Parameters.Add("@GMREF", SqlDbType.Int).Value = GMREF;
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
        /// <summary>
        /// [Web-Musteri] Satış temsilcisine bağlı ana carilerin GMREF leri geliyor
        /// </summary>
        public static ArrayList GetAnaCarilerGMREFBySLSREF(int SLSREF)
        {
            ArrayList donendeger = new ArrayList();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT DISTINCT [GMREF],[MUSTERI] FROM [Web-Musteri] WHERE ACTIVE = 0 AND [SLSREF] = @SLSREF AND [GMREF] <> [SMREF] AND (SELECT DISTINCT ACTIVE FROM [Web-Musteri] AS MUS WHERE GMREF = SMREF AND GMREF = [Web-Musteri].GMREF) = 0 ORDER BY [MUSTERI]", conn);
                cmd.Parameters.Add("@SLSREF", SqlDbType.Int).Value = SLSREF;
                cmd.CommandTimeout = 400;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        donendeger.Add(Convert.ToInt32(dr[0]));
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
        /// <summary>
        /// [Web-Musteri] Satış temsilcisine bağlı ana carilerin GMREF leri geliyor, ArrayList sıfırlanmıyor
        /// </summary>
        public static void GetAnaCarilerGMREFBySLSREF(ArrayList GMREFs, int SLSREF)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT DISTINCT [GMREF],[MUSTERI] FROM [Web-Musteri] WHERE ACTIVE = 0 AND [SLSREF] = @SLSREF AND [GMREF] <> [SMREF] ORDER BY [MUSTERI]", conn);
                cmd.Parameters.Add("@SLSREF", SqlDbType.Int).Value = SLSREF;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        GMREFs.Add(Convert.ToInt32(dr[0]));
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
        /// <summary>
        /// [Web-Musteri] [Web-Risk-2] Tek olan cariler, bir ana cariye bağlı olmayanlar
        /// </summary>
        public static void GetTekCarilerBySLSREF(DataTable dt, int SLSREF)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT DISTINCT [Web-Risk-2].[GMREF],[Web-Risk-2].[MUS KOD],[Web-Risk-2].[MUSTERI],[Web-Risk-2].[BAKIYE],[Web-Risk-2].[RISK BKY],[Web-Risk-2].[VGB GUN],[Web-Risk-2].[VGB TOP],[Web-Musteri].[SMREF] FROM [Web-Risk-2] INNER JOIN [Web-Musteri] ON [Web-Risk-2].[GMREF] = [Web-Musteri].[GMREF] WHERE [Web-Musteri].ACTIVE = 0 AND [Web-Musteri].[SLSREF] = @SLSREF AND (SELECT count(*) FROM [Web-Musteri] AS MUSTERILER1 WHERE GMREF != SMREF AND GMREF = [Web-Musteri].GMREF AND SLSREF = [Web-Musteri].SLSREF) = 0 AND [Web-Musteri].[GMREF] = [Web-Musteri].[SMREF] AND ACTIVE = 0", conn);
                da.SelectCommand.Parameters.Add("@SLSREF", SqlDbType.Int).Value = SLSREF;
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
        /// [Web-Musteri] Tek olan cariler, bir ana cariye bağlı olmayanlar, ZİY ler gelmiyor
        /// </summary>
        public static void GetTekCarilerBySLSREF(DataTable dt, int SLSREF, bool SatisTemsilcisi)
        {
            /*SAP*/
            string nst = " AND SLSREF = " + SLSREF.ToString(); //SatisTemsilcileri.GetSATKOD1BySLSREF(SLSREF).StartsWith("8") ? " AND SLSREF = " + SLSREF.ToString() : "";

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT DISTINCT [GMREF],[MUS KOD],[SUB KOD],[MUSTERI],[SMREF],SMREF AS SMREF1,(SELECT sum(NETTOP) FROM (SELECT NETTOP FROM [Web-Musteri] WHERE [GMREF] = MUSTERILER.GMREF" + nst + " GROUP BY SMREF,NETTOP) AS NETTOPLAR) AS NETTOP,[ADRES],[SEHIR],[SEMT],[TEL-1],[CEP-1],[EMAIL-1],ILGILI FROM [Web-Musteri] AS MUSTERILER WHERE ACTIVE = 0 AND (SELECT count(*) FROM [Web-Musteri] WHERE GMREF != SMREF AND GMREF = MUSTERILER.GMREF AND SLSREF = MUSTERILER.SLSREF) = 0 AND [SLSREF] = @SLSREF AND [GMREF] = [SMREF] AND ACTIVE = 0 ORDER BY [MUSTERI]", conn);
                // ,(SELECT sum([NET T]) FROM [KurumsalWebSAP].[dbo].[Web-Satis-Rapor] WHERE TEDSLSREF = " + SLSREF.ToString() + " AND GMREF = MUSTERILER.GMREF AND AY = (SELECT Month(getdate()))) AS TEDNETTOP
                da.SelectCommand.Parameters.Add("@SLSREF", SqlDbType.Int).Value = SLSREF;
                da.SelectCommand.CommandTimeout = 400;
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
        /// [Web-Musteri] Tek olan cariler, bir ana cariye bağlı olmayanlar, value nun başına text in ilk 3 hanesi yazılıyor, ZİY ler gelmiyor
        /// </summary>
        public static void GetTekCarilerBySLSREF(ListItemCollection lic, int SLSREF, bool SatisTemsilcisi, bool TumuOlsun)
        {
            lic.Clear();

            ListItem lst1 = new ListItem();
            lst1.Text = "Seçiniz";
            lst1.Value = "0";
            lic.Add(lst1);

            if (TumuOlsun)
            {
                ListItem lst2 = new ListItem("Tümü", "1");
                lic.Add(lst2);
            }

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT DISTINCT [GMREF],[MUSTERI] FROM [Web-Musteri] WHERE (SELECT count(*) FROM [Web-Musteri] AS MUSTERILER1 WHERE GMREF != SMREF AND GMREF = [Web-Musteri].GMREF AND SLSREF = [Web-Musteri].SLSREF) = 0 AND [SLSREF] = @SLSREF AND [GMREF] = [SMREF] AND ACTIVE = 0 ORDER BY [MUSTERI]", conn);
                cmd.Parameters.Add("@SLSREF", SqlDbType.Int).Value = SLSREF;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        ListItem lst = new ListItem();
                        lst.Text = dr[1].ToString();
                        lst.Value = dr[1].ToString().Substring(0, 3) + dr[0].ToString();
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
        /// <summary>
        /// [Web-Musteri] Tek olan cariler, bir ana cariye bağlı olmayanlar, value nun başına text in ilk 3 hanesi yazılıyor, ZİY ler gelmiyor, en basta musteri kodu var: muskod - musteri
        /// </summary>
        public static void GetTekCarilerBySLSREF(ListItemCollection lic, int SLSREF, bool SatisTemsilcisi, bool TumuOlsun, bool BastaKodVar, bool BastaKodvar)
        {
            lic.Clear();

            ListItem lst1 = new ListItem();
            lst1.Text = "Seçiniz";
            lst1.Value = "0";
            lic.Add(lst1);

            if (TumuOlsun)
            {
                ListItem lst2 = new ListItem("Tümü", "1");
                lic.Add(lst2);
            }

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                if (BastaKodVar)
                    cmd = new SqlCommand("SELECT DISTINCT [GMREF],[MUS KOD] + ' - ' + [MUSTERI],MUSTERI FROM [Web-Musteri] WHERE (SELECT count(*) FROM [Web-Musteri] AS MUSTERILER1 WHERE GMREF != SMREF AND GMREF = [Web-Musteri].GMREF AND SLSREF = [Web-Musteri].SLSREF) = 0 AND [SLSREF] = @SLSREF AND [GMREF] = [SMREF] AND ACTIVE = 0 ORDER BY [MUSTERI]", conn);
                else
                    cmd = new SqlCommand("SELECT DISTINCT [GMREF],[MUSTERI] FROM [Web-Musteri] WHERE (SELECT count(*) FROM [Web-Musteri] AS MUSTERILER1 WHERE GMREF != SMREF AND GMREF = [Web-Musteri].GMREF AND SLSREF = [Web-Musteri].SLSREF) = 0 AND [SLSREF] = @SLSREF AND [GMREF] = [SMREF] AND ACTIVE = 0 ORDER BY [MUSTERI]", conn);

                cmd.Parameters.Add("@SLSREF", SqlDbType.Int).Value = SLSREF;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        ListItem lst = new ListItem();
                        lst.Text = dr[1].ToString();
                        lst.Value = dr[1].ToString().Substring(0, 3) + dr[0].ToString();
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
        /// <summary>
        /// [Web-Musteri]
        /// </summary>
        public static bool AnaSubeMi(int GMREF)
        {
            bool donendeger = false;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT count(DISTINCT [MUSTERI]) FROM [Web-Musteri] WHERE [GMREF] <> [SMREF] AND [GMREF] = @GMREF", conn);
                cmd.Parameters.Add("@GMREF", SqlDbType.Int).Value = GMREF;
                try
                {
                    conn.Open();
                    object obj = cmd.ExecuteScalar();
                    if (obj != null)
                        donendeger = Convert.ToBoolean(obj);
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
        /// <summary>
        /// 
        /// </summary>
        public static void GetCHEkstresiByMusKod(DataTable dt, string MUSKOD, string SATTEM, string TEDSATTEM, string TARIHBAS, string TARIHSON)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3))
            {
                string musop = "=";
                string satop = "=";
                string tedop = "=";
                string tarih = string.Empty;

                if (MUSKOD == string.Empty)
                    musop = "IS NOT NULL";
                else
                    MUSKOD = "'" + MUSKOD + "'";

                if (SATTEM == string.Empty)
                    satop = "IS NOT NULL";
                else
                    SATTEM = "'" + SATTEM + "'";

                if (TEDSATTEM == string.Empty)
                    tedop = "IS NOT NULL";
                else
                    TEDSATTEM = "'" + TEDSATTEM + "'";

                if (TARIHBAS != string.Empty && TARIHSON != string.Empty)
                    tarih = " AND [FIS TAR] < '" + TARIHSON + "' AND [FIS TAR] > '" + TARIHBAS + "'";

                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM [FinansCariHesHarEks-1-380] WHERE [MUS KOD] " + musop + " " + MUSKOD +
                    " AND [SAT TEM] " + satop + " " + SATTEM + " AND [TED SAT TEM] " + tedop + " " + TEDSATTEM +
                    tarih, conn);
                da.SelectCommand.CommandTimeout = 200;
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
        /// 
        /// </summary>
        public static void GetCHEkstresi(DataTable dt)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM [FinansCariHesHarEks-1-380]", conn);
                da.SelectCommand.CommandTimeout = 500;
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
        /// [Web-Musteri]
        /// </summary>
        public static int GetSLSREFBySMREF(int SMREF)
        {
            int donendeger = 0;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT DISTINCT max([SAT KOD]) FROM [Web-Musteri] WHERE [SMREF] = @SMREF AND [SAT KOD1] = 'VE'", conn); //AND [SAT KOD1] NOT LIKE '8%' AND Substring([SAT KOD], 11, 2) != '08'
                cmd.Parameters.Add("@SMREF", SqlDbType.Int).Value = SMREF;
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
        /// <summary>
        /// [Web-Musteri]
        /// </summary>
        public static int GetSLSREFByGMREF(int GMREF)
        {
            int donendeger = 0;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT DISTINCT max([SAT KOD]) FROM [Web-Musteri] WHERE [GMREF] = @GMREF AND [SAT KOD1] = 'VE'", conn); // AND [SAT KOD1] NOT LIKE '8%'
                cmd.Parameters.Add("@GMREF", SqlDbType.Int).Value = GMREF;
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
        /// <summary>
        /// [Web-Musteri]
        /// </summary>
        public static void GetSatTemsInnerTblMusterilerBySMREF(IList List, int SMREF)
        {
            List.Clear();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT DISTINCT [SLSREF],[SAT TEM] FROM [Web-Musteri] INNER JOIN tblINTERNET_Musteriler ON [Web-Musteri].SLSREF = tblINTERNET_Musteriler.intSLSREF WHERE [SMREF] = @SMREF ORDER BY [SAT TEM]", conn);
                cmd.Parameters.Add("@SMREF", SqlDbType.Int).Value = SMREF;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        List.Add(dr[1].ToString());
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
        /// <summary>
        /// [Web-Musteri]
        /// </summary>
        public static void GetSatTemsInnerTblMusterilerByGMREF(IList List, int GMREF)
        {
            List.Clear();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT DISTINCT [SLSREF],[SAT TEM] FROM [Web-Musteri] INNER JOIN tblINTERNET_Musteriler ON [Web-Musteri].SLSREF = tblINTERNET_Musteriler.intSLSREF WHERE [GMREF] = @GMREF ORDER BY [SAT TEM]", conn);
                cmd.Parameters.Add("@GMREF", SqlDbType.Int).Value = GMREF;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        List.Add(dr[1].ToString());
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
        /// <summary>
        /// [Web-Musteri]
        /// </summary>
        public static void GetSatTemsBySMREF(ListItemCollection lic, int SMREF)
        {
            lic.Clear();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT DISTINCT [SLSREF],[SAT TEM] FROM [Web-Musteri] WHERE [SMREF] = @SMREF ORDER BY [SAT TEM]", conn);
                cmd.Parameters.Add("@SMREF", SqlDbType.Int).Value = SMREF;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        lic.Add(new ListItem(dr[1].ToString(), dr[0].ToString()));
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
        /// <summary>
        /// [Web-Musteri]
        /// </summary>
        public static void GetSatTemsByGMREF(ListItemCollection lic, int GMREF)
        {
            lic.Clear();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT DISTINCT [SLSREF],[SAT TEM] FROM [Web-Musteri] WHERE [GMREF] = @GMREF ORDER BY [SAT TEM]", conn);
                cmd.Parameters.Add("@GMREF", SqlDbType.Int).Value = GMREF;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        lic.Add(new ListItem(dr[1].ToString(), dr[0].ToString()));
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
        /// <summary>
        /// [Web-Musteri]
        /// </summary>
        public static void GetSatTemsByGMREF(IList List, int GMREF, bool UI)
        {
            List.Clear();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT DISTINCT [SLSREF],[SAT TEM] FROM [Web-Musteri] WHERE [GMREF] = @GMREF ORDER BY [SAT TEM]", conn);
                cmd.Parameters.Add("@GMREF", SqlDbType.Int).Value = GMREF;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        List.Add(new SatisTemsilcileri(Convert.ToInt32(dr[0]), dr[1].ToString()));
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
        /// <summary>
        /// [Web-Musteri]
        /// </summary>
        public static void GetSatTemsBySMREF(IList List, int SMREF, bool UI)
        {
            List.Clear();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT DISTINCT [SLSREF],[SAT TEM] FROM [Web-Musteri] WHERE [SMREF] = @SMREF ORDER BY [SAT TEM]", conn);
                cmd.Parameters.Add("@SMREF", SqlDbType.Int).Value = SMREF;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        List.Add(new SatisTemsilcileri(Convert.ToInt32(dr[0]), dr[1].ToString()));
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
        /// <summary>
        /// [Web-Risk-2]
        /// </summary>
        public static decimal GetRISKBKYByGMREF(int GMREF)
        {
            decimal donendeger = 0;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT [RISK BKY] FROM [Web-Risk-2] WHERE [GMREF] = @GMREF", conn);
                cmd.Parameters.Add("@GMREF", SqlDbType.Int).Value = GMREF;
                try
                {
                    conn.Open();
                    object obj = cmd.ExecuteScalar();
                    if (obj != null)
                        donendeger = Convert.ToDecimal(obj);
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
        /// <summary>
        /// [Web-Risk-2]
        /// </summary>
        public static decimal GetRISKLMTByGMREF(int GMREF)
        {
            decimal donendeger = 0;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT [RISK LMT] FROM [Web-Risk-2] WHERE [GMREF] = @GMREF", conn);
                cmd.Parameters.Add("@GMREF", SqlDbType.Int).Value = GMREF;
                try
                {
                    conn.Open();
                    object obj = cmd.ExecuteScalar();
                    if (obj != null)
                        donendeger = Convert.ToDecimal(obj);
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
        /// <summary>
        /// [Web-Musteri]
        /// </summary>
        public static string GetMUSTERIbySMREF(int SMREF)
        {
            string donendeger = string.Empty;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT TOP 1 MUSTERI FROM [Web-Musteri] WHERE SMREF = @SMREF", conn);
                cmd.Parameters.Add("@SMREF", SqlDbType.Int).Value = SMREF;
                try
                {
                    conn.Open();
                    object obj = cmd.ExecuteScalar();
                    if (obj != null)
                        donendeger = obj.ToString();
                    else
                        donendeger = "-c/h bulunamadı-";
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
        /// <summary>
        /// [Web-Musteri]
        /// </summary>
        public static string GetMUSTERIbyGMREF(int GMREF)
        {
            string donendeger = string.Empty;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT TOP 1 MUSTERI FROM [Web-Musteri] WHERE GMREF = @GMREF AND GMREF = SMREF", conn);
                cmd.Parameters.Add("@GMREF", SqlDbType.Int).Value = GMREF;
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
        /// <summary>
        /// [Web-Musteri]
        /// </summary>
        public static string GetSUBEbySMREF(int SMREF)
        {
            string donendeger = string.Empty;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT TOP 1 SUBE FROM [Web-Musteri] WHERE SMREF = @SMREF", conn);
                cmd.Parameters.Add("@SMREF", SqlDbType.Int).Value = SMREF;
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
        /// <summary>
        /// [Web-Musteri]
        /// </summary>
        public static string GetMUSTERIbySMREFmusterisube(int SMREF)
        {
            string donendeger = "-Kullanım Dışında-";

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT TOP 1 CASE WHEN [SUBE] = '' THEN [MUSTERI] ELSE [SUBE] END AS MUSTERI FROM [Web-Musteri] WHERE SMREF = @SMREF", conn);
                cmd.Parameters.Add("@SMREF", SqlDbType.Int).Value = SMREF;
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
        /// <summary>
        /// [Web-Musteri]
        /// </summary>
        public static string GetVRGNObySMREF(int SMREF)
        {
            string donendeger = string.Empty;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT TOP 1 [VRG NO] FROM [Web-Musteri] WHERE SMREF = @SMREF", conn);
                cmd.Parameters.Add("@SMREF", SqlDbType.Int).Value = SMREF;
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
        /// <summary>
        /// [Web-Musteri]
        /// </summary>
        public static string GetILGILIbySMREF(int SMREF)
        {
            string donendeger = string.Empty;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT TOP 1 ILGILI FROM [Web-Musteri] WHERE SMREF = @SMREF", conn);
                cmd.Parameters.Add("@SMREF", SqlDbType.Int).Value = SMREF;
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
        /// <summary>
        /// [Web-Musteri]
        /// </summary>
        public static string GetADRESbySMREF(int SMREF)
        {
            string donendeger = string.Empty;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT TOP 1 ADRES FROM [Web-Musteri] WHERE SMREF = @SMREF", conn);
                cmd.Parameters.Add("@SMREF", SqlDbType.Int).Value = SMREF;
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
        /// <summary>
        /// [Web-Musteri]
        /// </summary>
        public static string GetILbySMREF(int SMREF)
        {
            string donendeger = string.Empty;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT TOP 1 IL FROM [Web-Musteri] WHERE SMREF = @SMREF", conn);
                cmd.Parameters.Add("@SMREF", SqlDbType.Int).Value = SMREF;
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
        /// <summary>
        /// [Web-Musteri]
        /// </summary>
        public static string GetKODbySMREF(int SMREF)
        {
            string donendeger = string.Empty;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT CASE WHEN [SUB KOD] = '' THEN [MUS KOD] ELSE [SUB KOD] END AS [KOD] FROM [Web-Musteri] WHERE SMREF = @SMREF", conn);
                cmd.Parameters.Add("@SMREF", SqlDbType.Int).Value = SMREF;
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
        /// <summary>
        /// [Web-Musteri]
        /// </summary>
        public static string GetSUBKODbySMREF(int SMREF)
        {
            string donendeger = "-";

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT [SUB KOD] FROM [Web-Musteri] WHERE SMREF = @SMREF", conn);
                cmd.Parameters.Add("@SMREF", SqlDbType.Int).Value = SMREF;
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
        /// <summary>
        /// [Web-Musteri]
        /// </summary>
        public static string GetMUSKODbySMREF(int SMREF)
        {
            string donendeger = string.Empty;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT [MUS KOD] FROM [Web-Musteri] WHERE SMREF = @SMREF", conn);
                cmd.Parameters.Add("@SMREF", SqlDbType.Int).Value = SMREF;
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
        /// <summary>
        /// [Web-Risk-2]
        /// </summary>
        public static decimal GetVGBbyGMREF(int GMREF)
        {
            decimal donendeger = 0;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT [VGB TOP] FROM [Web-Risk-2] WHERE GMREF = @GMREF", conn);
                cmd.Parameters.Add("@GMREF", SqlDbType.Int).Value = GMREF;
                try
                {
                    conn.Open();
                    object obj = cmd.ExecuteScalar();
                    if (obj != null)
                        donendeger = Convert.ToDecimal(obj);
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
        /// <summary>
        /// [Web-Risk-2]
        /// </summary>
        public static int GetVGBGUNbyGMREF(int GMREF)
        {
            int donendeger = 0;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT [VGB GUN] FROM [Web-Risk-2] WHERE GMREF = @GMREF", conn);
                cmd.Parameters.Add("@GMREF", SqlDbType.Int).Value = GMREF;
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





        /// <summary>
        /// [Web-Musteri], ArrayList sıfırlanmıyor, GMREF <> SMREF veya GMREF = SMREF demeden, hepsini getiriyor, donen int kaç satır geldi onu söylüyor
        /// </summary>
        public static int GetGMREFsBySLSREF(ArrayList GMREFs, int SLSREF, bool ACTIVE)
        {
            int donendeger = 0;

            string active = ACTIVE ? " AND ACTIVE = 0" : "";

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT DISTINCT [GMREF],[MUSTERI] FROM [Web-Musteri] WHERE [SLSREF] = @SLSREF" + active + " ORDER BY [MUSTERI]", conn);
                cmd.Parameters.Add("@SLSREF", SqlDbType.Int).Value = SLSREF;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        GMREFs.Add(Convert.ToInt32(dr[0]));
                        donendeger++;
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
        /// <summary>
        /// [Web-Musteri], başta satış temsilcisi ismi var, ListItemCollection sıfırlanmıyor, seçiniz tümü yok, value nun başına text in ilk 3 hanesi yazılıyor,
        /// ZİY ler gelmiyor
        /// </summary>
        public static void GetObjectsBySLSREFs(ListItemCollection lic, ArrayList SLSREFs)
        {
            string slsrefs = "WHERE (";
            for (int i = 0; i < SLSREFs.Count; i++)
            {
                slsrefs += "SLSREF = " + SLSREFs[i].ToString() + " OR ";
            }
            slsrefs = slsrefs.Substring(0, slsrefs.Length - 4) + ")";

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT DISTINCT [GMREF],'' AS [MUS KOD],[SAT TEM] + ' - ' + [MUSTERI],[SAT TEM],[MUSTERI] FROM [Web-Musteri] " + slsrefs + " AND [YTK KOD] != 'ZIY' ORDER BY [SAT TEM],[MUSTERI]", conn);
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        lic.Add(new ListItem(dr[2].ToString(), dr[2].ToString().Substring(0, 3) + dr[0].ToString()));
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
        /// <summary>
        /// [Web-Musteri], başta satış temsilcisi ismi var, tek cariler için ZİY ler gelmiyor
        /// </summary>
        public static void GetObjectsBySLSREF(DataTable dt, int SLSREF, bool TekCariler)
        {
            //string nettop = ",0 AS NETTOP";

            /*SAP*/
            string nst = " AND SLSREF = " + SLSREF.ToString(); //SatisTemsilcileri.GetSATKOD1BySLSREF(SLSREF).StartsWith("8") || SatisTemsilcileri.GetSATKODBySLSREF(SLSREF).Substring(10).StartsWith("08") ? " AND SLSREF = " + SLSREF.ToString() : "";
            string tekcariler = " AND (GMREF <> SMREF)";
            string smref = "";
            string ilgili = "'<b>İletişim bilgileri için ilgili şubeye bakınız.</b>' AS [ADRES],'-' AS [SEHIR],'-' AS [SEMT],'-' AS [TEL-1],'-' AS [CEP-1],'-' AS [EMAIL-1],'-' AS ILGILI";
            if (TekCariler)
            {
                smref = "[SMREF],";
                tekcariler = " AND (GMREF = SMREF) AND (SELECT count(*) FROM [Web-Musteri] WHERE GMREF != SMREF AND GMREF = MUSTERILER.GMREF AND SLSREF = MUSTERILER.SLSREF) = 0";
                //ilgili = "(SELECT TOP 1 [ADRES] FROM [Web-Musteri] WHERE [GMREF] = MUSTERILER.GMREF) AS [ADRES],(SELECT TOP 1 [SEHIR] FROM [Web-Musteri] WHERE [GMREF] = MUSTERILER.GMREF) AS [SEHIR],(SELECT TOP 1 [SEMT] FROM [Web-Musteri] WHERE [GMREF] = MUSTERILER.GMREF) AS [SEMT],(SELECT TOP 1 [TEL-1] FROM [Web-Musteri] WHERE [GMREF] = MUSTERILER.GMREF) AS [TEL-1],(SELECT TOP 1 [CEP-1] FROM [Web-Musteri] WHERE [GMREF] = MUSTERILER.GMREF) AS [CEP-1],(SELECT TOP 1 [EMAIL-1] FROM [Web-Musteri] WHERE [GMREF] = MUSTERILER.GMREF) AS [EMAIL-1],(SELECT TOP 1 [ILGILI] FROM [Web-Musteri] WHERE [GMREF] = MUSTERILER.GMREF) AS ILGILI";
                ilgili = "[ADRES],[SEHIR],[SEMT],[TEL-1],[CEP-1],[EMAIL-1],ILGILI";

                //nettop = ",NETTOP";
            }

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT DISTINCT [GMREF],ISNULL((SELECT TOP 1 SMREF FROM [Web-Musteri] WHERE GMREF = MUSTERILER.GMREF AND (SUBE LIKE '%mrkz%' OR MUSTERI = SUBE)),(SELECT TOP 1 SMREF FROM [Web-Musteri] WHERE GMREF = MUSTERILER.GMREF ORDER BY [SUB KOD])) AS SMREF1," + smref + "'' AS [MUS KOD],[MUSTERI],(SELECT sum(NETTOP) FROM (SELECT NETTOP FROM [Web-Musteri] WHERE [GMREF] = MUSTERILER.GMREF" + nst + " GROUP BY SMREF,NETTOP) AS NETTOPLAR) AS NETTOP," + ilgili + " FROM [Web-Musteri] AS MUSTERILER WHERE ACTIVE = 0 AND SLSREF = " + SLSREF.ToString() + tekcariler + " ORDER BY [MUSTERI]", conn);
                da.SelectCommand.CommandTimeout = 400;
                // (SELECT sum([NET T]) FROM [KurumsalWebSAP].[dbo].[Web-Satis-Rapor] WHERE TEDSLSREF = " + SLSREF.ToString() + " AND GMREF = MUSTERILER.GMREF AND AY = (SELECT Month(getdate()))) AS TEDNETTOP,
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
        /// [Web-Musteri], sube bazinda bütün müşteriler geliyor, ZİY ler gelmiyor
        /// </summary>
        public static void GetObjectsBySLSREF(IList List, int SLSREF)
        {
            List.Clear();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT DISTINCT [GMREF],[SMREF],[MUSTERI],[SUBE] FROM [Web-Musteri] WHERE SLSREF = " + SLSREF.ToString() + " AND [YTK KOD] != 'ZIY' ORDER BY [MUSTERI],[SUBE]", conn);
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        List.Add(new CariHesaplar(Convert.ToInt32(dr[0]), Convert.ToInt32(dr[1]), dr[2].ToString(), dr[3].ToString()));
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
        /// <summary>
        /// [Web-Musteri], başta satış temsilcisi ismi var
        /// </summary>
        public static void GetObjectsBySLSREFs(DataTable dt, ArrayList SLSREFs, bool TekCariler)
        {
            string slsrefs = "WHERE (";
            for (int i = 0; i < SLSREFs.Count; i++)
            {
                slsrefs += "SLSREF = " + SLSREFs[i].ToString() + " OR ";
            }
            slsrefs = slsrefs.Substring(0, slsrefs.Length - 4) + ")";

            string tekcariler = " AND (GMREF <> SMREF)";
            string smref = "";
            if (TekCariler)
            {
                smref = "[SMREF],";
                tekcariler = " AND (GMREF = SMREF)";
            }

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT DISTINCT [GMREF]," + smref + "[MUS KOD],[SAT TEM] + ' - ' + [MUSTERI] AS MUSTERI,[SAT TEM],[MUSTERI] AS TEKMUSTERI FROM [Web-Musteri] " + slsrefs + tekcariler + " ORDER BY [SAT TEM],[MUSTERI]", conn);
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
        /// [Web-Musteri], seçiniz ve tümü hariç olması için ListItemCollection da 0 ve 1 yok
        /// gelen ListItemCollection da value ların başlarında text in ilk 3 hanesi olduğundan onları içerde çıkarıyoruz
        /// </summary>
        public static ArrayList GetSMREFsByGMREFs(ListItemCollection lic)
        {
            ArrayList donendeger = new ArrayList();

            string gmrefs = "WHERE ";
            for (int i = 2; i < lic.Count; i++) // seçiniz ve tümü hariç
            {
                gmrefs += "GMREF = " + lic[i].Value.Substring(3) + " OR ";
            }
            gmrefs = gmrefs.Substring(0, gmrefs.Length - 4);

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT DISTINCT [SMREF],[MUSTERI],[SUBE] FROM [Web-Musteri] " + gmrefs + " ORDER BY [MUSTERI],[SUBE]", conn);
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        donendeger.Add(dr[0].ToString());
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
        /// <summary>
        /// 
        /// </summary>
        public static ArrayList GetSMREFsByGMREF(int GMREF)
        {
            ArrayList donendeger = new ArrayList();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT DISTINCT [SMREF] FROM [Web-Musteri] WHERE GMREF = @GMREF", conn);
                cmd.Parameters.Add("@GMREF", SqlDbType.Int).Value = GMREF;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        donendeger.Add(dr[0].ToString());
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
        /// <summary>
        /// [Web-Musteri], [SMREF],[SAT TEM] + ' ' + [MUSTERI] + ' ' + [SUBE], seçiniz ve tümü hariç olması için ListItemCollection da 0 ve 1 yok,
        /// gelen ListItemCollection da value ların başlarında text in ilk 3 hanesi olduğundan onları içerde çıkarıyoruz, ZİY ler gelmiyor
        /// </summary>
        public static void GetSMREFandSATTEMMUSTERISUBEByGMREFsSLSREFs(ListItemCollection DoldurulacakListe, ListItemCollection lic, ArrayList SLSREFs)
        {
            string gmrefs = "WHERE (";
            for (int i = 2; i < lic.Count; i++) // seçiniz ve tümü hariç
            {
                gmrefs += "GMREF = " + lic[i].Value.Substring(3) + " OR ";
            }

            string slsrefs = " AND (";
            if (gmrefs == "WHERE (")
            {
                gmrefs = "";
                slsrefs = "WHERE (";
            }
            else
            {
                gmrefs = gmrefs.Substring(0, gmrefs.Length - 4) + ")";
            }

            for (int i = 0; i < SLSREFs.Count; i++)
            {
                slsrefs += "SLSREF = " + SLSREFs[i].ToString() + " OR ";
            }
            slsrefs = slsrefs.Substring(0, slsrefs.Length - 4) + ")";

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT DISTINCT [SMREF],[SAT TEM] + ' - ' +[MUSTERI] + ' : ' + [SUBE],[SAT TEM],[MUSTERI],[SUBE] FROM [Web-Musteri] " + gmrefs + slsrefs + " AND [YTK KOD] != 'ZIY' ORDER BY [SAT TEM],[MUSTERI],[SUBE]", conn);
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        DoldurulacakListe.Add(new ListItem(dr[1].ToString(), dr[0].ToString()));
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
        /// <summary>
        /// [Web-Musteri], [SMREF],[SAT TEM] + ' ' + [MUSTERI] + ' ' + [SUBE], seçiniz ve tümü hariç olması için ListItemCollection da 0 ve 1 yok,
        /// ZİY ler gelmiyor
        /// </summary>
        public static void GetSMREFandSATTEMMUSTERISUBE(ListItemCollection DoldurulacakListe)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT DISTINCT [SMREF],[SAT TEM] + ' - ' +[MUSTERI] + ' : ' + [SUBE],[SAT TEM],[MUSTERI],[SUBE] FROM [Web-Musteri] WHERE [SAT KOD1] = 'VE' ORDER BY [SAT TEM],[MUSTERI],[SUBE]", conn); //WHERE [SAT KOD1] NOT LIKE '8%' AND [YTK KOD] != 'ZIY' 
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        DoldurulacakListe.Add(new ListItem(dr[1].ToString(), dr[0].ToString()));
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
        /// <summary>
        /// [Web-Musteri], [SMREF],[SAT TEM] + ' ' + [MUSTERI] + ' ' + [SUBE], seçiniz ve tümü hariç olması için ListItemCollection da 0 ve 1 yok,
        /// ZİY ler gelmiyor
        /// </summary>
        public static void GetSMREFandSATTEMMUSTERISUBEforSiparisKopyala(ListItemCollection DoldurulacakListe)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT DISTINCT [SMREF],[MUSTERI] + ' : ' + [SUBE],[MUSTERI],[SUBE] FROM [Web-Musteri] ORDER BY [MUSTERI],[SUBE]", conn);
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        DoldurulacakListe.Add(new ListItem(dr[1].ToString(), dr[0].ToString()));
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
        /// <summary>
        /// [Web-Musteri], başta satış temsilcisi ismi var, value nun başına text in ilk 3 hanesi yazılıyor
        /// </summary>
        public static void GetGMREFSATTEMMUSTERIByMusteri(ListItemCollection lic, string Musteri, bool TumuOlsun)
        {
            lic.Clear();
            lic.Add(new ListItem("Seçiniz", "0"));
            if (TumuOlsun)
                lic.Add(new ListItem("Tümü", "1"));

            ArrayList musteriler = StringParcalama.TurkceKarakterPermutasyon(Musteri);
            string sonuc = "WHERE ";
            for (int i = 0; i < musteriler.Count; i++)
            {
                sonuc += "MUSTERI LIKE '%" + musteriler[i].ToString() + "%' OR ";
            }
            sonuc = sonuc.Substring(0, sonuc.Length - 4);

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT DISTINCT [GMREF],[SAT TEM],[MUSTERI] FROM [Web-Musteri] " + sonuc + " ORDER BY [SAT TEM],[MUSTERI]", conn);
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        lic.Add(new ListItem(dr[1].ToString() + " - " + dr[2].ToString(), dr[1].ToString().Substring(0, 3) + dr[0].ToString()));
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
        /// <summary>
        /// [Web-Musteri], başta satış temsilcisi ismi var, value nun başına text in ilk 3 hanesi yazılıyor
        /// </summary>
        public static void GetGMREFSATTEMMUSTERIBySATTEM(ListItemCollection lic, string Sattem, bool TumuOlsun)
        {
            lic.Clear();
            lic.Add(new ListItem("Seçiniz", "0"));
            if (TumuOlsun)
                lic.Add(new ListItem("Tümü", "1"));

            ArrayList sattemler = StringParcalama.TurkceKarakterPermutasyon(Sattem);
            string sonuc = "WHERE ";
            for (int i = 0; i < sattemler.Count; i++)
            {
                sonuc += "[SAT TEM] LIKE '%" + sattemler[i].ToString() + "%' OR ";
            }
            sonuc = sonuc.Substring(0, sonuc.Length - 4);

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT DISTINCT [GMREF],[SAT TEM],[MUSTERI] FROM [Web-Musteri] " + sonuc + " ORDER BY [SAT TEM],[MUSTERI]", conn);
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        lic.Add(new ListItem(dr[1].ToString() + " - " + dr[2].ToString(), dr[1].ToString().Substring(0, 3) + dr[0].ToString()));
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
        /// <summary>
        /// [Web-Risk-2]
        /// </summary>
        public static int GetBorcAlacakCount(int SLSREF, bool VGB)
        {
            int donendeger = 0;

            string Vgb = VGB ? " AND [VGB GUN] > 0" : "";

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT count([GMREF]) FROM [Web-Risk-2] WHERE [SLSREF] = @SLSREF" + Vgb, conn);
                cmd.Parameters.Add("@SLSREF", SqlDbType.Int).Value = SLSREF;
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
        /// <summary>
        /// [Web-Risk-2]
        /// </summary>
        public static void GetBorcAlacak(DataTable dt, int SLSREF, int Baslangic, int Adet, bool VGB)
        {
            string Vgb = VGB ? " AND [VGB GUN] > 0" : "";

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT [SLSREF],[GMREF],[MUS KOD],[MUSTERI],[RISK LMT],[RISK TOP],[RISK BKY],ISNULL([BAKIYE],0) AS [BAKIYE],[ACK GUN],[ACK TOP],[VB GUN],[VB TOP],ISNULL((SELECT TOP 1 [VGB_VD] FROM [dbo].[SAP_B_A_2017] WHERE [MUS KOD] = [Web-Risk-2].GMREF),0) AS [VGB GUN],ISNULL((SELECT TOP 1 [VGB] FROM [dbo].[SAP_B_A_2017] WHERE [MUS KOD] = [Web-Risk-2].GMREF),0) AS [VGB TOP],ISNULL([IRS TOP],0) AS [IRS TOP],[C/S TOP],ISNULL([SIP TOPL],0) AS [SIP TOPL],[SIP TOPLB],[SIP TOPQ],ISNULL([SIP TOPL]+[SIP TOPQ],0) AS [SIP TOP] FROM [Web-Risk-2] WHERE [SLSREF] = @SLSREF" + Vgb + " UNION ALL SELECT 0 AS SLSREF,0 AS GMREF,'' AS [MUS KOD],'zzzToplam' AS MUSTERI,IsNull(sum([RISK LMT]),0) AS [RISK LMT],IsNull(sum([RISK TOP]),0) AS [RISK TOP],IsNull(sum([RISK BKY]),0) AS [RISK BKY],IsNull(sum([BAKIYE]),0) AS [BAKIYE],0 AS [ACK GUN],IsNull(sum([ACK TOP]),0) AS [ACK TOP],0 AS [VB GUN],IsNull(sum([VB TOP]),0) AS [VB TOP],0 AS [VGB GUN],IsNull(sum([VGB TOP]),0) AS [VGB TOP],IsNull(sum([IRS TOP]),0) AS [IRS TOP],IsNull(sum([C/S TOP]),0) AS [C/S TOP],IsNull(sum([SIP TOPL]),0) AS [SIP TOPL],IsNull(sum([SIP TOPLB]),0) AS [SIP TOPLB],IsNull(sum([SIP TOPQ]),0) AS [SIP TOPQ], IsNull(sum([SIP TOPL]+[SIP TOPQ]),0) FROM [Web-Risk-2] WHERE [SLSREF] = @SLSREF" + Vgb + " ORDER BY [MUSTERI]", conn);
                da.SelectCommand.Parameters.Add("@SLSREF", SqlDbType.Int).Value = SLSREF;
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
        /// [Web-Musteri]
        /// </summary>
        public static void GetNSTsBySMREF(DataTable dt, int SMREF)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT DISTINCT [SAT TEM] FROM [Web-Musteri] WHERE [SMREF] = @SMREF AND [SAT KOD1] = 'VW' ORDER BY [SAT TEM]", conn); // AND [SAT KOD1] LIKE '8%'
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
        /// <summary>
        /// [Web-Musteri]
        /// </summary>
        public static string GetGRPBySMREF(int SMREF)
        {
            string donendeger = string.Empty;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT DISTINCT [GRP] FROM [Web-Musteri] WHERE [SMREF] = @SMREF", conn);
                cmd.Parameters.Add("@SMREF", SqlDbType.Int).Value = SMREF;
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
        /// <summary>
        /// [Web-Musteri]
        /// </summary>
        public static string GetYTKKODBySMREF(int SMREF)
        {
            string donendeger = string.Empty;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT DISTINCT [YTK KOD] FROM [Web-Musteri] WHERE [SMREF] = @SMREF", conn);
                cmd.Parameters.Add("@SMREF", SqlDbType.Int).Value = SMREF;
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
        /// <summary>
        /// 
        /// </summary>
        public static int GetSMREFBySUBE(string SUBE)
        {
            int donendeger = 0;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT DISTINCT [SMREF] FROM [Web-Musteri] WHERE [SUBE] = @SUBE", conn);
                cmd.Parameters.Add("@SUBE", SqlDbType.NVarChar).Value = SUBE;
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
        /// <summary>
        /// 
        /// </summary>
        public static string GetSATKOD1BySLSREF(int SLSREF)
        {
            string donendeger = string.Empty;

            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3))
            {
                SqlCommand cmd = new SqlCommand("SELECT [SAT KOD1] FROM [Web-Musteri] WHERE [SLSREF] = @SLSREF ORDER BY [SAT KOD1]", conn);
                cmd.Parameters.Add("@SLSREF", SqlDbType.Int).Value = SLSREF;
                try
                {
                    conn.Open();
                    object obj = cmd.ExecuteScalar();
                    if (obj != null)
                        donendeger = obj.ToString();
                    else
                        donendeger = "0";
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
        /// <summary>
        /// 
        /// </summary>
        public static void GetMusteriTurler(IList List)
        {
            List.Clear();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT DISTINCT [MT KOD],[MT ACIKLAMA] FROM [Web-Musteri] ORDER BY [MT ACIKLAMA]", conn);
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        List.Add(new MusteriTurler(dr[0].ToString(), dr[1].ToString()));
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
        /// <summary>
        /// 
        /// </summary>
        public static void GetMusteriTurler(IList List, int GMREF)
        {
            List.Clear();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT DISTINCT [MT KOD],[MT ACIKLAMA] FROM [Web-Musteri] WHERE SMREF = @GMREF ORDER BY [MT ACIKLAMA]", conn);
                cmd.Parameters.Add("@GMREF", SqlDbType.Int).Value = GMREF;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        List.Add(new MusteriTurler(dr[0].ToString(), dr[1].ToString()));
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
        /// <summary>
        /// 
        /// </summary>
        public static string GetMtAciklama(string KOD)
        {
            string donendeger = string.Empty;

            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3))
            {
                SqlCommand cmd = new SqlCommand("SELECT DISTINCT [MT ACIKLAMA] FROM [Web-Musteri] WHERE [MT KOD] = @MTKOD", conn);
                cmd.Parameters.Add("@MTKOD", SqlDbType.NVarChar).Value = KOD;
                try
                {
                    conn.Open();
                    object obj = cmd.ExecuteScalar();
                    if (obj != null)
                        donendeger = obj.ToString();
                    else
                        donendeger = string.Empty;
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
        /// <summary>
        /// 
        /// </summary>
        public static string GetMtAciklama(int SMREF)
        {
            string donendeger = string.Empty;

            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3))
            {
                SqlCommand cmd = new SqlCommand("SELECT DISTINCT [MT ACIKLAMA] FROM [Web-Musteri] WHERE SMREF = @SMREF", conn);
                cmd.Parameters.Add("@SMREF", SqlDbType.Int).Value = SMREF;
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
        /// <summary>
        /// 
        /// </summary>
        public static int GetYetkili(int SMREF)
        {
            int donendeger = 0;

            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3))
            {
                SqlCommand cmd = new SqlCommand("SELECT DISTINCT SLSREF FROM [Web-Musteri] WHERE SMREF = @SMREF AND [SAT KOD1] = 'ZM'", conn);
                cmd.Parameters.Add("@SMREF", SqlDbType.Int).Value = SMREF;
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
        /// <summary>
        /// [Web-Musteri-1]
        /// </summary>
        public static string GetSUBEbySMREF(int SMREF, int tip)
        {
            string donendeger = string.Empty;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT TOP 1 SUBE FROM [Web-Musteri-1] WHERE SMREF = @SMREF AND TIP = @TIP", conn);
                cmd.Parameters.Add("@SMREF", SqlDbType.Int).Value = SMREF;
                cmd.Parameters.Add("@TIP", SqlDbType.Int).Value = tip;
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
        /// <summary>
        /// [Web-Musteri-1]
        /// </summary>
        public static int GetGMREFBySMREF(int SMREF, int TIP)
        {
            int donendeger = 0;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT DISTINCT [GMREF] FROM [Web-Musteri-1] WHERE [SMREF] = @SMREF AND TIP = @TIP", conn);
                cmd.Parameters.Add("@SMREF", SqlDbType.Int).Value = SMREF;
                cmd.Parameters.Add("@TIP", SqlDbType.Int).Value = TIP;
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







        /// <summary>
        /// [Web-Musteri]
        /// </summary>
        public static void nGetObjectsWithGMREFeqSMREFBySLSREF(DataTable dt, int SLSREF)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT DISTINCT [GMREF],[MUSTERI],SMREF,SUBE,SLSREF,[SAT KOD],[SAT KOD1] FROM [Web-Musteri] WHERE GMREF = SMREF AND [SLSREF] = @SLSREF ORDER BY [MUSTERI],[SUBE]", conn);
                da.SelectCommand.Parameters.Add("@SLSREF", SqlDbType.Int).Value = SLSREF;
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

    public class MusteriTurler
    {
        public MusteriTurler(string KOD, string ACIKLAMA) { this.Kod = KOD; this.Aciklama = ACIKLAMA; }
        public string Kod { get; set; }
        public string Aciklama { get; set; }
        public override string ToString() { return this.Aciklama; }
    }
}

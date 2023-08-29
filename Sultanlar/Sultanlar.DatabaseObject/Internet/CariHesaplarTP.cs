using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Collections;
using System.Web.UI.WebControls;
using Sultanlar.Class;

namespace Sultanlar.DatabaseObject.Internet
{
    public class CariHesaplarTP : ISultanlar, IDisposable
    {
        //
        //
        //
        // Alanlar:
        //
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
        //
        //
        //
        // Constracter lar:
        //
        public CariHesaplarTP()
        {
            this._ACTIVE = 0;
            this._BOLGE = "";
            this._GRP = "";
            this._EKP = "";
            this._YTKKOD = "";
            this._ILKOD = "";
            this._IL = "";
            this._ILCEKOD = "";
            this._ILCE = "";
            this._TIP = 0;
            this._MTKOD = "";
            this._MTACIKLAMA = "";
            this._UNVAN = "";
            this._SLSREF = 0;
            this._SATKOD = "";
            this._SATKOD1 = "";
            this._SATTEM = "";
            this._GMREF = 0;
            this._MUSKOD = "";
            this._MUSTERI = "";
            this._SMREF = 0;
            this._SUBKOD = "";
            this._SUBE = "";
            this._ADRES = "";
            this._SEHIR = "";
            this._SEMT = "";
            this._VRGDAIRE = "";
            this._VRGNO = "";
            this._TEL1 = "";
            this._FAX1 = "";
            this._EMAIL1 = "";
            this._ILGILI = "";
            this._CEP1 = "";
            this._NETTOP = 0;
        }
        //
        //
        public CariHesaplarTP(short ACTIVE, string BOLGE, string GRP, string EKP, string YTKKOD, string ILKOD, string IL, string ILCEKOD,
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

        //
        //
        public CariHesaplarTP(int SMREF, string SUBE) { this._SMREF = SMREF; this._SUBE = SUBE; }
        //
        //
        //
        // Özellikler:
        //
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
        public string Metrekare { get { return CariHesaplar.GetYuzolcum(this._SMREF, 4); } }
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
            return this._GMREF == this._SMREF ? this._MUSTERI : this._SUBE;
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
                SqlCommand cmd = new SqlCommand("sp_WebMusteriTPEkle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
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
                cmd.Parameters.Add("@MUSKOD", SqlDbType.NVarChar, 17).Value = this._MUSKOD;
                cmd.Parameters.Add("@MUSTERI", SqlDbType.NVarChar, 331).Value = this._MUSTERI;
                cmd.Parameters.Add("@SMREF", SqlDbType.Int).Value = this._SMREF;
                cmd.Parameters.Add("@SUBKOD", SqlDbType.VarChar, 17).Value = this._SUBKOD;
                cmd.Parameters.Add("@SUBE", SqlDbType.NVarChar, 201).Value = this._SUBE;
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
        //
        //
        public void DoUpdate()
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_WebMusteriTPGuncelle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
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
                cmd.Parameters.Add("@MUSTERI", SqlDbType.NVarChar, 331).Value = this._MUSTERI;
                cmd.Parameters.Add("@SMREF", SqlDbType.Int).Value = this._SMREF;
                cmd.Parameters.Add("@SUBKOD", SqlDbType.VarChar, 17).Value = this._SUBKOD;
                cmd.Parameters.Add("@SUBE", SqlDbType.NVarChar, 201).Value = this._SUBE;
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
        /// <summary>
        /// ACTIVE neyse o, 1 ise siler 0 ise geri alır
        /// </summary>
        public void DoDelete()
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_WebMusteriTPSil", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ACTIVE", SqlDbType.SmallInt).Value = this._ACTIVE == 0 ? 1 : 0;
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
        /// <summary>
        /// 
        /// </summary>
        public void DoDelete(bool gerceksil)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM [Web-Musteri-TP] WHERE SMREF = @SMREF", conn);
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
        /// <summary>
        /// 
        /// </summary>
        public static void GetObjectsEslestirmeIcin(DataTable dt, string AltCari)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT [ACTIVE],[SMREF] AS GMREF,[MT ACIKLAMA],[MUS KOD],[MUSTERI],[SAT TEM],[VRG DAIRE],[VRG NO],[ILGILI],[TEL-1] FROM [Web-Musteri-TP] WHERE SUBE LIKE '%" + AltCari + "%' ORDER BY MUSTERI", conn);
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
        /// BayiID 0 ise ana bayiler, başka ise alt cariler
        /// </summary>
        public static void GetObjects(DataTable dt, int BayiID)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT [ACTIVE],[BOLGE],[GRP],[EKP],[YTK KOD],[IL KOD],[IL],[ILCE KOD],[ILCE],[TIP],[MT KOD],[MT ACIKLAMA],[UNVAN],[SLSREF],[SAT KOD],[SAT KOD1],[SAT TEM],[GMREF],[MUS KOD],[MUSTERI],[SMREF],[SUB KOD],[SUBE],[ADRES],[SEHIR],[SEMT],[VRG DAIRE],[VRG NO],[TEL-1],[FAX-1],[EMAIL-1],[ILGILI],[CEP-1],[NETTOP] FROM [Web-Musteri-TP] WHERE " + (BayiID == 0 ? "GMREF = SMREF" : "GMREF != SMREF AND GMREF = " + BayiID.ToString()) + " AND ACTIVE = 0 ORDER BY MUSTERI", conn);
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
        /// BayiID 0 ise ana bayiler, başka ise alt cariler, ACTIVE = 0 kaldırıldı
        /// </summary>
        public static void GetObjects(IList List, int BayiID)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                List.Clear();

                SqlCommand cmd = new SqlCommand("SELECT [ACTIVE],[BOLGE],[GRP],[EKP],[YTK KOD],[IL KOD],[IL],[ILCE KOD],[ILCE],[TIP],[MT KOD],[MT ACIKLAMA],[UNVAN],[SLSREF],[SAT KOD],[SAT KOD1],[SAT TEM],[GMREF],[MUS KOD],[MUSTERI],[SMREF],[SUB KOD],[SUBE],[ADRES],[SEHIR],[SEMT],[VRG DAIRE],[VRG NO],[TEL-1],[FAX-1],[EMAIL-1],[ILGILI],[CEP-1],[NETTOP] FROM [Web-Musteri-TP] WHERE " + (BayiID == 0 ? "GMREF = SMREF" : "GMREF != SMREF AND GMREF = " + BayiID.ToString()) + " ORDER BY MUSTERI", conn);
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        List.Add(new CariHesaplarTP(Convert.ToInt16(dr[0]), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(),
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
        /// BayiID 0 ise ana bayiler, başka ise alt cariler
        /// </summary>
        public static void GetObjects(ListItemCollection lic, int BayiID, bool web, bool web2)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                lic.Clear();
                lic.Add(new ListItem("Seçiniz", "0"));

                SqlCommand cmd = new SqlCommand("SELECT [MUSTERI],[SMREF] FROM [Web-Musteri-TP] WHERE " + (BayiID == 0 ? "GMREF = SMREF" : "GMREF != SMREF AND GMREF = " + BayiID.ToString()) + " AND ACTIVE = 0 ORDER BY MUSTERI", conn);
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        lic.Add(new ListItem(dr[0].ToString(), dr[1].ToString()));
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
        public static void GetObjects(IList List, int GMREF, string Nokta)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                List.Clear();

                SqlCommand cmd = new SqlCommand("SELECT [ACTIVE],[BOLGE],[GRP],[EKP],[YTK KOD],[IL KOD],[IL],[ILCE KOD],[ILCE],[TIP],[MT KOD],[MT ACIKLAMA],[UNVAN],[SLSREF],[SAT KOD],[SAT KOD1],[SAT TEM],[GMREF],[MUS KOD],[MUSTERI],[SMREF],[SUB KOD],[SUBE],[ADRES],[SEHIR],[SEMT],[VRG DAIRE],[VRG NO],[TEL-1],[FAX-1],[EMAIL-1],[ILGILI],[CEP-1],[NETTOP] FROM [Web-Musteri-TP] WHERE GMREF = " + GMREF.ToString() + " AND SUBE LIKE '%" + Nokta.Replace("'", "") + "%' ORDER BY MUSTERI", conn);
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        List.Add(new CariHesaplarTP(Convert.ToInt16(dr[0]), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(),
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
        /// 
        /// </summary>
        public static void GetBayiAltCariler(DataTable dt, ArrayList GMREFs)
        {
            string gmrefs = string.Empty;
            if (GMREFs.Count > 0)
            {
                gmrefs = " WHERE";
                for (int i = 0; i < GMREFs.Count; i++)
                {
                    gmrefs += " GMREF = " + GMREFs[i].ToString() + " OR";
                }
                gmrefs = gmrefs.Substring(0, gmrefs.Length - 3);
            }

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT 4 AS MTIP,[ACTIVE],[BOLGE],[GRP],[EKP],[YTK KOD],[IL KOD],[IL],[ILCE KOD],[ILCE],[TIP],[MT KOD],[MT ACIKLAMA],[UNVAN],[SLSREF],[SAT KOD],[SAT KOD1],[SAT TEM],[GMREF],[MUS KOD],[MUSTERI],[SMREF],[SUB KOD],[SUBE],[ADRES],[SEHIR],[SEMT],[VRG DAIRE],[VRG NO],[TEL-1],[FAX-1],[EMAIL-1],[ILGILI],[CEP-1],[NETTOP] FROM [Web-Musteri-TP]" + gmrefs + " ORDER BY MUSTERI", conn);
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
        public static CariHesaplarTP GetObject(int SMREF, bool Bayi)
        {
            CariHesaplarTP donendeger = new CariHesaplarTP();

            string where = string.Empty;
            if (Bayi)
                where = " WHERE GMREF = SMREF AND GMREF = " + CariHesaplarTP.GetGMREFBySMREF(SMREF).ToString();
            else
                where = " WHERE SMREF = " + SMREF.ToString();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT [ACTIVE],[BOLGE],[GRP],[EKP],[YTK KOD],[IL KOD],[IL],[ILCE KOD],[ILCE],[TIP],[MT KOD],[MT ACIKLAMA],[UNVAN],[SLSREF],[SAT KOD],[SAT KOD1],[SAT TEM],[GMREF],[MUS KOD],[MUSTERI],[SMREF],[SUB KOD],[SUBE],[ADRES],[SEHIR],[SEMT],[VRG DAIRE],[VRG NO],[TEL-1],[FAX-1],[EMAIL-1],[ILGILI],[CEP-1],[NETTOP] FROM [Web-Musteri-TP]" + where, conn);
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        donendeger = new CariHesaplarTP(Convert.ToInt16(dr[0]), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(),
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
        /// 
        /// </summary>
        public static CariHesaplarTP GetObject(int GMREF, string SUBE)
        {
            CariHesaplarTP donendeger = new CariHesaplarTP();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT [ACTIVE],[BOLGE],[GRP],[EKP],[YTK KOD],[IL KOD],[IL],[ILCE KOD],[ILCE],[TIP],[MT KOD],[MT ACIKLAMA],[UNVAN],[SLSREF],[SAT KOD],[SAT KOD1],[SAT TEM],[GMREF],[MUS KOD],[MUSTERI],[SMREF],[SUB KOD],[SUBE],[ADRES],[SEHIR],[SEMT],[VRG DAIRE],[VRG NO],[TEL-1],[FAX-1],[EMAIL-1],[ILGILI],[CEP-1],[NETTOP] FROM [Web-Musteri-TP] WHERE GMREF = @GMREF AND SUBE = @SUBE", conn);
                cmd.Parameters.Add("@GMREF", SqlDbType.Int).Value = GMREF;
                cmd.Parameters.Add("@SUBE", SqlDbType.NVarChar).Value = SUBE;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        donendeger = new CariHesaplarTP(Convert.ToInt16(dr[0]), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(),
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
        /// 
        /// </summary>
        public static CariHesaplarTP GetObjectByNOKTAKOD(int GMREF, string NOKTAKOD)
        {
            CariHesaplarTP donendeger = new CariHesaplarTP();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT [ACTIVE],[BOLGE],[GRP],[EKP],[YTK KOD],[IL KOD],[IL],[ILCE KOD],[ILCE],[TIP],[MT KOD],[MT ACIKLAMA],[UNVAN],[SLSREF],[SAT KOD],[SAT KOD1],[SAT TEM],[GMREF],[MUS KOD],[MUSTERI],[SMREF],[SUB KOD],[SUBE],[ADRES],[SEHIR],[SEMT],[VRG DAIRE],[VRG NO],[TEL-1],[FAX-1],[EMAIL-1],[ILGILI],[CEP-1],[NETTOP] FROM [Web-Musteri-TP] WHERE GMREF = @GMREF AND NOKTAKOD = @NOKTAKOD", conn);
                cmd.Parameters.Add("@GMREF", SqlDbType.Int).Value = GMREF;
                cmd.Parameters.Add("@NOKTAKOD", SqlDbType.NVarChar).Value = NOKTAKOD;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        donendeger = new CariHesaplarTP(Convert.ToInt16(dr[0]), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(),
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
        //
        //
        public static int GetLastSMREF()
        {
            int donendeger = 0;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT max(SMREF) FROM [Web-Musteri-TP]", conn);
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
        public static string GetNoktaVarMi2(string NoktaKod, int GMREF)
        {
            string donendeger = string.Empty;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT SUBE FROM [Web-Musteri-TP] WHERE [MUS KOD] = @MUSKOD AND GMREF = @GMREF", conn);
                cmd.Parameters.Add("@MUSKOD", SqlDbType.NVarChar).Value = NoktaKod;
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
        //
        //
        public static bool GetNoktaVarMi(string NoktaAdi, int GMREF)
        {
            bool donendeger = false;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT count(*) FROM [Web-Musteri-TP] WHERE UPPER(SUBE) = @NoktaAdi AND GMREF = @GMREF", conn);
                cmd.Parameters.Add("@NoktaAdi", SqlDbType.NVarChar).Value = NoktaAdi;
                cmd.Parameters.Add("@GMREF", SqlDbType.Int).Value = GMREF;
                try
                {
                    conn.Open();
                    donendeger = Convert.ToBoolean(cmd.ExecuteScalar());
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
        public static int GetGMREFBySMREF(int SMREF)
        {
            int donendeger = 0;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT DISTINCT [GMREF] FROM [Web-Musteri-TP] WHERE [SMREF] = @SMREF", conn);
                cmd.Parameters.Add("@SMREF", SqlDbType.Int).Value = SMREF;
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
        /// <summary>
        /// GMREF = SMREF
        /// </summary>
        public static void GetTekCarilerBySLSREF(DataTable dt, int SLSREF)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT DISTINCT [GMREF],[MUS KOD],[MUSTERI],[SMREF],0 AS NETTOP,[ADRES],[SEHIR],[SEMT],[TEL-1],[CEP-1],[EMAIL-1],ILGILI FROM [Web-Musteri-TP] WHERE [GMREF] = [SMREF] AND GMREF IN (SELECT SMREF FROM [Web-Musteri] WHERE SLSREF = @SLSREF) ORDER BY [MUSTERI]", conn);
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
        /// GMREF = SMREF, value nun başına text in ilk 3 hanesi yazılıyor
        /// </summary>
        public static void GetTekCarilerBySLSREF(ListItemCollection lic, int SLSREF, bool TumuOlsun)
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
                SqlCommand cmd = new SqlCommand("SELECT DISTINCT [GMREF],[MUSTERI] FROM [Web-Musteri-TP] WHERE [GMREF] = [SMREF] AND GMREF IN (SELECT SMREF FROM [Web-Musteri] WHERE SLSREF = @SLSREF) ORDER BY [MUSTERI]", conn);
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
        /// GMREF != SMREF, yani sadece şubeler gelsin
        /// </summary>
        public static void GetSMREFsBySLSREF(ArrayList smrefs, int SLSREF)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT DISTINCT [SMREF] FROM [Web-Musteri-TP] WHERE GMREF != SMREF AND GMREF IN (SELECT SMREF FROM [Web-Musteri] WHERE SLSREF = @SLSREF)", conn);
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
        /// GMREF != SMREF, yani sadece şubeler gelsin
        /// </summary>
        public static void GetSMREFsByGMREF(ArrayList smrefs, int GMREF)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT DISTINCT [SMREF] FROM [Web-Musteri-TP] WHERE [GMREF] = @GMREF AND GMREF != SMREF", conn);
                cmd.Parameters.Add("@GMREF", SqlDbType.Int).Value = GMREF;
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
        /// GMREF = SMREF, yani sadece bayiler gelsin (siparişler iadelerde kullanmak için)
        /// </summary>
        public static void GetSMREFsBySLSREF(ArrayList smrefs, int SLSREF, bool Bayi)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT DISTINCT [SMREF] FROM [Web-Musteri-TP] WHERE GMREF = SMREF AND GMREF IN (SELECT SMREF FROM [Web-Musteri] WHERE SLSREF = @SLSREF)", conn);
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
        /// Hepsi, yani bayi + şubeler
        /// </summary>
        public static void GetSMREFsBySLSREFHepsi(ArrayList smrefs, int SLSREF)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT DISTINCT [SMREF] FROM [Web-Musteri-TP] WHERE GMREF IN (SELECT SMREF FROM [Web-Musteri] WHERE SLSREF = @SLSREF)", conn);
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
        /// carihesaplar dan gmref leri eşleştirerek bu slsref e ait bütün smref leri carihesaplartp den getiriyor
        /// </summary>
        public static void GetSMREFsBySLSREFcarihesaplardaneslesmeli(ArrayList smrefs, int SLSREF)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT DISTINCT [SMREF] FROM [Web-Musteri-TP] WHERE GMREF IN (SELECT DISTINCT [GMREF] FROM [Web-Musteri] WHERE [SLSREF] = @SLSREF AND [GMREF] = [SMREF])", conn);
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
        //
        //
        public static ArrayList GetObjectBySMREF(int SMREF)
        {
            ArrayList donendeger = new ArrayList();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT DISTINCT [MUS KOD],[MUSTERI] FROM [Web-Musteri-TP] WHERE [SMREF] = @SMREF", conn);
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
        //
        //
        public static ArrayList GetSubelerBySMREF(int SMREF)
        {
            ArrayList donendeger = new ArrayList();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT DISTINCT [SUB KOD],[SUBE],[MUS KOD],[MUSTERI] FROM [Web-Musteri-TP] WHERE [SMREF] = @SMREF", conn);
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
        /// GMREF != SMREF, value nun başına text in ilk 3 hanesi yazılıyor
        /// </summary>
        public static void GetSubelerBySLSREF(ListItemCollection lic, int SLSREF, bool TumuOlsun)
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
                SqlCommand cmd = new SqlCommand("SELECT DISTINCT [SMREF],[SUBE] FROM [Web-Musteri-TP] WHERE [GMREF] != [SMREF] AND GMREF IN (SELECT SMREF FROM [Web-Musteri] WHERE SLSREF = @SLSREF) ORDER BY [SUBE]", conn);
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
        /// bayinin kendisinin alt carisinde genel anlaşmasız yazıyor (bayi - genel anlaşmasız), value nun başına text in ilk 3 hanesi yazılıyor
        /// </summary>
        public static void GetSubelerByGMREFs(ListItemCollection lic, ArrayList GMREFs, bool TumuOlsun)
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

            string gmrefs = string.Empty;
            for (int i = 0; i < GMREFs.Count; i++)
            {
                gmrefs += "GMREF = " + GMREFs[i].ToString() + " OR ";
            }
            gmrefs = gmrefs != string.Empty ? gmrefs.Substring(0, gmrefs.Length - 4) : string.Empty;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT DISTINCT [SMREF],(SELECT MUSTERI FROM [Web-Musteri-TP] WHERE GMREF = MUSTERILER.GMREF AND GMREF = SMREF) + ' - ' + (CASE WHEN [SUBE] != '' THEN [SUBE] ELSE '---!!! GENEL ANLAŞMASIZ AKTİVİTE !!!---' END) AS SUBE FROM [Web-Musteri-TP] AS MUSTERILER WHERE (" + gmrefs + ") ORDER BY [SUBE]", conn);
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
        /// başta satış temsilcisi ismi var, value nun başına text in ilk 3 hanesi yazılıyor
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
                SqlCommand cmd = new SqlCommand("SELECT DISTINCT [GMREF],[SAT TEM],[MUSTERI] FROM [Web-Musteri-TP] " + sonuc + " ORDER BY [SAT TEM],[MUSTERI]", conn);
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
        /// value nun başına text in ilk 3 hanesi yazılıyor
        /// </summary>
        public static void GetSubelerByGMREF(ListItemCollection lic, int GMREF)
        {
            lic.Clear();

            ListItem lst1 = new ListItem();
            lst1.Text = "Hiçbir alt cari";
            lst1.Value = "HIC0";
            lic.Add(lst1);

            lst1 = new ListItem();
            lst1.Text = "Tümü";
            lst1.Value = "TUM1";
            lic.Add(lst1);

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT DISTINCT [SMREF],[SUBE] FROM [Web-Musteri-TP] WHERE [GMREF] = @GMREF AND GMREF != SMREF ORDER BY [SUBE]", conn);
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
        /// value nun başına text in ilk 3 hanesi yazılıyor
        /// </summary>
        public static void GetSubelerByGMREF(IList List, int GMREF, bool UI)
        {
            List.Clear();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT DISTINCT [SMREF],[SUBE] FROM [Web-Musteri-TP] WHERE [GMREF] = @GMREF AND GMREF != SMREF ORDER BY [SUBE]", conn);
                cmd.Parameters.Add("@GMREF", SqlDbType.Int).Value = GMREF;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        List.Add(new CariHesaplarTP(Convert.ToInt32(dr[0]), dr[1].ToString()));
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
        public static int GetSMREFBySUBE(int GMREF, string SUBE)
        {
            int donendeger = 0;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT [SMREF] FROM [Web-Musteri-TP] WHERE GMREF = @GMREF AND UPPER([SUBE]) = @SUBE", conn);
                cmd.Parameters.Add("@GMREF", SqlDbType.Int).Value = GMREF;
                cmd.Parameters.Add("@SUBE", SqlDbType.NVarChar).Value = SUBE;
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
        /// <summary>
        /// 
        /// </summary>
        public static int GetSMREFByMUSKOD(int GMREF, string MUSKOD)
        {
            int donendeger = 0;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT [SMREF] FROM [Web-Musteri-TP] WHERE GMREF = @GMREF AND [MUS KOD] = @MUSKOD", conn);
                cmd.Parameters.Add("@GMREF", SqlDbType.Int).Value = GMREF;
                cmd.Parameters.Add("@MUSKOD", SqlDbType.NVarChar).Value = MUSKOD;
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
        /// <summary>
        /// doldurulacakliste sıfırlanmıyor
        /// </summary>
        public static void GetSMREFandMUSTERISUBE(ListItemCollection DoldurulacakListe)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT SMREF,(SELECT MUSTERI FROM [Web-Musteri-TP] WHERE GMREF = MUSTERILER.GMREF AND GMREF = SMREF) AS MUSTERI,[SUBE] FROM [Web-Musteri-TP] AS MUSTERILER ORDER BY [MUSTERI],[SUBE]", conn);
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        DoldurulacakListe.Add(new ListItem(dr[1].ToString() + " - " + dr[2].ToString(), dr[0].ToString()));
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
        public static string GetBAYIKODByGMREF(int GMREF)
        {
            string donendeger = string.Empty;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT [BAYIKOD] FROM [Web-Musteri-TP-Bayikodlar] WHERE [GMREF] = @GMREF", conn);
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
        /// 
        /// </summary>
        public static int GetGMREFByBAYIKOD(string BAYIKOD)
        {
            int donendeger = 0;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT [GMREF] FROM [Web-Musteri-TP-Bayikodlar] WHERE [BAYIKOD] = @BAYIKOD", conn);
                cmd.Parameters.Add("@BAYIKOD", SqlDbType.NVarChar).Value = BAYIKOD;
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
        /// <summary>
        /// 
        /// </summary>
        public static string GetErpByApikey(Guid Apikey)
        {
            string donendeger = string.Empty;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT [ERP] FROM [Web-Musteri-TP-Bayikodlar] WHERE [API] = @API", conn);
                cmd.Parameters.Add("@API", SqlDbType.UniqueIdentifier).Value = Apikey;
                try
                {
                    conn.Open();
                    donendeger = cmd.ExecuteScalar().ToString();
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
        public static void GetSUBEs(IList List, int GMREF, string Musteri)
        {
            List.Clear();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT DISTINCT [SMREF],[SUBE] FROM [Web-Musteri-TP] WHERE GMREF = @GMREF AND [MUSTERI] LIKE '%" + Musteri + "%' ORDER BY SUBE", conn);
                cmd.Parameters.Add("@GMREF", SqlDbType.Int).Value = GMREF;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        List.Add(new CariHesaplarTP(Convert.ToInt32(dr[0]), dr[1].ToString()));
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
        /// [Web-Musteri-TP]
        /// </summary>
        public static void GetObjectsBySLSREFforFarkliZiyaretBaslat(DataTable dt, int SLSREF, string SUBE)
        {
            string top100 = "";
            if (SUBE.Trim() == "")
                top100 = "TOP 100 ";

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT " + top100 + "TIP AS MTIP,'' AS [MUS KOD],(SELECT BAYIUNVAN FROM [Web-Musteri-TP-Bayikodlar] WHERE GMREF = MUSTERILER.GMREF) AS [MUSTERI],[SMREF],'' AS [SUB KOD],[SUBE],(SELECT TOP 1 [ADRES] FROM [Web-Musteri] WHERE [SMREF] = MUSTERILER.SMREF) AS [ADRES],(SELECT TOP 1 [SEHIR] FROM [Web-Musteri] WHERE [SMREF] = MUSTERILER.SMREF) AS [SEHIR],(SELECT TOP 1 [SEMT] FROM [Web-Musteri] WHERE [SMREF] = MUSTERILER.SMREF) AS [SEMT],(SELECT TOP 1 [TEL-1] FROM [Web-Musteri] WHERE [SMREF] = MUSTERILER.SMREF) AS [TEL-1],(SELECT TOP 1 [CEP-1] FROM [Web-Musteri] WHERE [SMREF] = MUSTERILER.SMREF) AS [CEP-1],(SELECT TOP 1 [EMAIL-1] FROM [Web-Musteri] WHERE [SMREF] = MUSTERILER.SMREF) AS [EMAIL-1],(SELECT TOP 1 [ILGILI] FROM [Web-Musteri] WHERE [SMREF] = MUSTERILER.SMREF) AS ILGILI FROM [Web-Musteri-1] AS MUSTERILER WHERE ACTIVE = 0 AND GMREF != SMREF AND SLSREF = @SLSREF AND SUBE LIKE '%" + SUBE + "%' ORDER BY [MUSTERI],[SUBE]", conn);
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

    public class CariHesaplarTPEk
    {
        public CariHesaplarTPEk()
        {

        }

        public CariHesaplarTPEk(int GMREF, double flTAHIskUyg, double flYEGIskUyg, double flTAHKar, double flYEGKar, string strUnvan,
            string strDisUnvan, DateTime dtTarih)
        {
            _GMREF = GMREF;
            _flTAHIskUyg = flTAHIskUyg;
            _flYEGIskUyg = flYEGIskUyg;
            _flTAHKar = flTAHKar;
            _flYEGKar = flYEGKar;
            _strUnvan = strUnvan;
            _strDisUnvan = strDisUnvan;
            _dtTarih = dtTarih;
        }

        #region props

        private int _GMREF;

        public int GMREF
        {
            get { return _GMREF; }
            set { _GMREF = value; }
        }

        private double _flTAHIskUyg;

        public double flTAHIskUyg
        {
            get { return _flTAHIskUyg; }
            set { _flTAHIskUyg = value; }
        }

        private double _flYEGIskUyg;

        public double flYEGIskUyg
        {
            get { return _flYEGIskUyg; }
            set { _flYEGIskUyg = value; }
        }

        private double _flTAHKar;

        public double flTAHKar
        {
            get { return _flTAHKar; }
            set { _flTAHKar = value; }
        }

        private double _flYEGKar;

        public double flYEGKar
        {
            get { return _flYEGKar; }
            set { _flYEGKar = value; }
        }

        private string _strUnvan;

        public string strUnvan
        {
            get { return _strUnvan; }
            set { _strUnvan = value; }
        }

        private string _strDisUnvan;

        public string strDisUnvan
        {
            get { return _strDisUnvan; }
            set { _strDisUnvan = value; }
        }

        private DateTime _dtTarih;

        public DateTime dtTarih
        {
            get { return _dtTarih; }
            set { _dtTarih = value; }
        }

        #endregion

        public void DoInsert()
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_WebMusteriTPEkle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@GMREF", SqlDbType.Int).Value = this._GMREF;
                cmd.Parameters.Add("@flTAHIskUyg", SqlDbType.Float).Value = this._flTAHIskUyg;
                cmd.Parameters.Add("@flYEGIskUyg", SqlDbType.Float).Value = this._flYEGIskUyg;
                cmd.Parameters.Add("@flTAHKar", SqlDbType.Float).Value = this._flTAHKar;
                cmd.Parameters.Add("@flYEGKar", SqlDbType.Float).Value = this._flYEGKar;
                cmd.Parameters.Add("@strUnvan", SqlDbType.NVarChar).Value = this._strUnvan;
                cmd.Parameters.Add("@strDisUnvan", SqlDbType.NVarChar).Value = this._strDisUnvan;
                cmd.Parameters.Add("@dtTarih", SqlDbType.DateTime).Value = this._dtTarih;
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
                SqlCommand cmd = new SqlCommand("UPDATE [Web-Musteri-TP-Ek] SET [flTAHIskUyg] = @flTAHIskUyg,[flYEGIskUyg] = @flYEGIskUyg,[flTAHKar] = @flTAHKar,[flYEGKar] = @flYEGKar,[strUnvan] = @strUnvan,[strDisUnvan] = @strDisUnvan,[dtTarih] = @dtTarih WHERE [GMREF] = @GMREF", conn);
                cmd.Parameters.Add("@GMREF", SqlDbType.Int).Value = this._GMREF;
                cmd.Parameters.Add("@flTAHIskUyg", SqlDbType.Float).Value = this._flTAHIskUyg;
                cmd.Parameters.Add("@flYEGIskUyg", SqlDbType.Float).Value = this._flYEGIskUyg;
                cmd.Parameters.Add("@flTAHKar", SqlDbType.Float).Value = this._flTAHKar;
                cmd.Parameters.Add("@flYEGKar", SqlDbType.Float).Value = this._flYEGKar;
                cmd.Parameters.Add("@strUnvan", SqlDbType.NVarChar).Value = this._strUnvan;
                cmd.Parameters.Add("@strDisUnvan", SqlDbType.NVarChar).Value = this._strDisUnvan;
                cmd.Parameters.Add("@dtTarih", SqlDbType.DateTime).Value = this._dtTarih;
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

        public void DoDelete()
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_WebMusteriTPSil", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@GMREF", SqlDbType.Int).Value = this._GMREF;
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

        public static CariHesaplarTPEk GetObject(int GMREF)
        {
            CariHesaplarTPEk donendeger = new CariHesaplarTPEk();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT GMREF,flTAHIskUyg,flYEGIskUyg,flTAHKar,flYEGKar,strUnvan,strDisUnvan,dtTarih FROM [Web-Musteri-TP-Ek] WHERE GMREF = @GMREF", conn);
                cmd.Parameters.Add("@GMREF", SqlDbType.Int).Value = GMREF;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        donendeger = new CariHesaplarTPEk(Convert.ToInt32(dr[0]), Convert.ToDouble(dr[1]), Convert.ToDouble(dr[2]),
                            Convert.ToDouble(dr[3]), Convert.ToDouble(dr[4]), dr[5].ToString(), dr[6].ToString(), Convert.ToDateTime(dr[7]));
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

        public static CariHesaplarTPEk GetObjectO(int GMREF) // kurumsalweb den alıyor çünkü 2015 başında yeg iskontosu düştüğü için hızlı bir yöntem olarak eski veritabanından alsın dedim kapama kasım ayı yapılıyor hala diye
        {
            CariHesaplarTPEk donendeger = new CariHesaplarTPEk();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT GMREF,flTAHIskUyg,flYEGIskUyg,flTAHKar,flYEGKar,strUnvan,strDisUnvan,dtTarih FROM KurumsalWeb.dbo.[Web-Musteri-TP-Ek] WHERE GMREF = (SELECT GMREF FROM KurumsalWeb.dbo.[Web-Musteri-TP-Bayikodlar] WHERE BAYIKOD = @GMREF)", conn);
                cmd.Parameters.Add("@GMREF", SqlDbType.Int).Value = GMREF;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        donendeger = new CariHesaplarTPEk(Convert.ToInt32(dr[0]), Convert.ToDouble(dr[1]), Convert.ToDouble(dr[2]),
                            Convert.ToDouble(dr[3]), Convert.ToDouble(dr[4]), dr[5].ToString(), dr[6].ToString(), Convert.ToDateTime(dr[7]));
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

        public static ArrayList GetAlternatifBayiler()
        {
            ArrayList donendeger = new ArrayList();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT GMREF FROM [Web-Musteri-TP-Bayikodlar-Alternatif]", conn);
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

        public static ArrayList GetDirekBayiler()
        {
            ArrayList donendeger = new ArrayList();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT GMREF FROM [Web-Musteri-TP-Bayikodlar-Direk]", conn);
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

        public static int GetBayiSiparisNo(int GMREF)
        {
            int donendeger = 0;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT SIPNO FROM [Web-Musteri-TP-Bayikodlar] WHERE GMREF = @GMREF", conn);
                cmd.Parameters.Add("@GMREF", SqlDbType.Int).Value = GMREF;
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

        public static void SetBayiSiparisNo(int GMREF, int SIPNO)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UPDATE [Web-Musteri-TP-Bayikodlar] SET SIPNO = @SIPNO WHERE GMREF = @GMREF", conn);
                cmd.Parameters.Add("@SIPNO", SqlDbType.Int).Value = SIPNO;
                cmd.Parameters.Add("@GMREF", SqlDbType.Int).Value = GMREF;
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

    public class CariHesaplarTPEk2
    {
        public CariHesaplarTPEk2()
        {

        }

        public CariHesaplarTPEk2(int GMREF, int YIL, int AY, double TAH_ISK, double YEG_ISK, double TAH_KAR, double YEG_KAR)
        {
            _GMREF = GMREF;
            _YIL = YIL;
            _AY = AY;
            _TAH_ISK = TAH_ISK;
            _YEG_ISK = YEG_ISK;
            _TAH_KAR = TAH_KAR;
            _YEG_KAR = YEG_KAR;
        }

        #region props

        private int _GMREF;

        public int GMREF
        {
            get { return _GMREF; }
            set { _GMREF = value; }
        }

        private int _YIL;

        public int YIL
        {
            get { return _YIL; }
            set { _YIL = value; }
        }

        private int _AY;

        public int AY
        {
            get { return _AY; }
            set { _AY = value; }
        }

        private double _TAH_ISK;

        public double TAH_ISK
        {
            get { return _TAH_ISK; }
            set { _TAH_ISK = value; }
        }

        private double _YEG_ISK;

        public double YEG_ISK
        {
            get { return _YEG_ISK; }
            set { _YEG_ISK = value; }
        }

        private double _TAH_KAR;

        public double TAH_KAR
        {
            get { return _TAH_KAR; }
            set { _TAH_KAR = value; }
        }

        private double _YEG_KAR;

        public double YEG_KAR
        {
            get { return _YEG_KAR; }
            set { _YEG_KAR = value; }
        }

        #endregion

        public void DoUpdate()
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UPDATE [Web-Musteri-TP-Ek2] SET [TAH_ISK] = @TAH_ISK,[YEG_ISK] = @YEG_ISK,[TAH_KAR] = @TAH_KAR,[YEG_KAR] = @YEG_KAR WHERE [GMREF] = @GMREF AND YIL = @YIL AND AY = @AY", conn);
                cmd.Parameters.Add("@GMREF", SqlDbType.Int).Value = this._GMREF;
                cmd.Parameters.Add("@YIL", SqlDbType.Int).Value = this._YIL;
                cmd.Parameters.Add("@AY", SqlDbType.Int).Value = this._AY;
                cmd.Parameters.Add("@TAH_ISK", SqlDbType.Float).Value = this.TAH_ISK;
                cmd.Parameters.Add("@YEG_ISK", SqlDbType.Float).Value = this.YEG_ISK;
                cmd.Parameters.Add("@TAH_KAR", SqlDbType.Float).Value = this.TAH_KAR;
                cmd.Parameters.Add("@YEG_KAR", SqlDbType.Float).Value = this.YEG_KAR;
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

        public static CariHesaplarTPEk2 GetObject(int GMREF, int YIL, int AY)
        {
            CariHesaplarTPEk2 donendeger = new CariHesaplarTPEk2();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT GMREF,YIL,AY,TAH_ISK,YEG_ISK,TAH_KAR,YEG_KAR FROM [Web-Musteri-TP-Ek2] WHERE GMREF = @GMREF AND YIL = @YIL AND AY = @AY", conn);
                cmd.Parameters.Add("@GMREF", SqlDbType.NVarChar).Value = GMREF;
                cmd.Parameters.Add("@YIL", SqlDbType.SmallInt).Value = YIL;
                cmd.Parameters.Add("@AY", SqlDbType.TinyInt).Value = AY;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        donendeger = new CariHesaplarTPEk2(Convert.ToInt32(dr[0]), Convert.ToInt32(dr[1]), Convert.ToInt32(dr[2]), 
                            Convert.ToDouble(dr[3]), Convert.ToDouble(dr[4]),
                            Convert.ToDouble(dr[5]), Convert.ToDouble(dr[6]));
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

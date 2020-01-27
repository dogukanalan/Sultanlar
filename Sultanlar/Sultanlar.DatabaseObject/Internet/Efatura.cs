using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Web.UI.WebControls;

namespace Sultanlar.DatabaseObject.Internet
{
    public class Efatura : ISultanlar, IDisposable
    {
        //
        //
        //
        // Alanlar:
        //
        private int _pkID;
        private int _intMusteriID;
        private string _strAd;
        private DateTime _dtTarih;
        private string _LT;
        private string _BOLGE;
        private string _GRP;
        private string _EKP;
        private string _ABRNO;
        private string _AMBAR;
        private string _AY;
        private string _HAFTA;
        private string _FATTAR;
        private string _FATNO;
        private string _FATVD;
        private string _TUR;
        private string _TURACK;
        private string _FTUR;
        private string _SLSREF;
        private string _SATKOD;
        private string _SATTEM;
        private string _TEDEKP;
        private string _TEDSLSREF;
        private string _TEDSATTEM;
        private string _IL;
        private string _ILCE;
        private string _MTACIKLAMA;
        private string _GMREF;
        private string _MUSKOD;
        private string _MUSTERI;
        private string _SMREF;
        private string _SUBKOD;
        private string _SUBE;
        private string _SEVKKOD;
        private string _SEVKADRES;
        private string _REYKOD;
        private string _REYON;
        private string _ANAGRP;
        private string _GRPKOD;
        private string _GRUP;
        private string _TEDGRP;
        private string _TEDKISAMAL;
        private string _BARCODE;
        private string _ITEMREF;
        private string _MALKOD;
        private string _MALZEME;
        private string _KOLI;
        private string _KDV;
        private string _BRM;
        private string _ADT;
        private string _ISK1;
        private string _ISK2;
        private string _ISK3;
        private string _ISK4;
        private string _ISK5;
        private string _ISKALT;
        private string _BRUTT;
        private string _ISKT;
        private string _NETT;
        private string _KDVT;
        private string _NETKDVT;
        //
        //
        //
        // Constracter lar:
        //
        private Efatura(int pkID, int intMusteriID, string strAd, DateTime dtTarih, string LT, string BOLGE, string GRP, string EKP, string ABRNO, string AMBAR, string AY, string HAFTA, string FATTAR,
            string FATNO, string FATVD, string TUR, string TURACK, string FTUR, string SLSREF, string SATKOD, string SATTEM, string TEDEKP,
            string TEDSLSREF, string TEDSATTEM, string IL, string ILCE, string MTACIKLAMA, string GMREF, string MUSKOD, string MUSTERI,
            string SMREF, string SUBKOD, string SUBE, string SEVKKOD, string SEVKADRES, string REYKOD, string REYON, string ANAGRP,
            string GRPKOD, string GRUP, string TEDGRP, string TEDKISAMAL, string BARCODE, string ITEMREF, string MALKOD, string MALZEME,
            string KOLI, string KDV, string BRM, string ADT, string ISK1, string ISK2, string ISK3, string ISK4, string ISK5, string ISKALT, string BRUTT,
            string ISKT, string NETT, string KDVT, string NETKDVT)
        {
            this._pkID = pkID;
            this._intMusteriID = intMusteriID;
            this._strAd = strAd;
            this._dtTarih = dtTarih;
            this._LT = LT;
            this._BOLGE = BOLGE;
            this._GRP = GRP;
            this._EKP = EKP;
            this._ABRNO = ABRNO;
            this._AMBAR = AMBAR;
            this._AY = AY;
            this._HAFTA = HAFTA;
            this._FATTAR = FATTAR;
            this._FATNO = FATNO;
            this._FATVD = FATVD;
            this._TUR = TUR;
            this._TURACK = TURACK;
            this._FTUR = FTUR;
            this._SLSREF = SLSREF;
            this._SATKOD = SATKOD;
            this._SATTEM = SATTEM;
            this._TEDEKP = TEDEKP;
            this._TEDSLSREF = TEDSLSREF;
            this._TEDSATTEM = TEDSATTEM;
            this._IL = IL;
            this._ILCE = ILCE;
            this._MTACIKLAMA = MTACIKLAMA;
            this._GMREF = GMREF;
            this._MUSKOD = MUSKOD;
            this._MUSTERI = MUSTERI;
            this._SMREF = SMREF;
            this._SUBKOD = SUBKOD;
            this._SUBE = SUBE;
            this._SEVKKOD = SEVKKOD;
            this._SEVKADRES = SEVKADRES;
            this._REYKOD = REYKOD;
            this._REYON = REYON;
            this._ANAGRP = ANAGRP;
            this._GRPKOD = GRPKOD;
            this._GRUP = GRUP;
            this._TEDGRP = TEDGRP;
            this._TEDKISAMAL = TEDKISAMAL;
            this._BARCODE = BARCODE;
            this._ITEMREF = ITEMREF;
            this._MALKOD = MALKOD;
            this._MALZEME = MALZEME;
            this._KOLI = KOLI;
            this._KDV = KDV;
            this._BRM = BRM;
            this._ADT = ADT;
            this._ISK1 = ISK1;
            this._ISK2 = ISK2;
            this._ISK3 = ISK3;
            this._ISK4 = ISK4;
            this._ISK5 = ISK5;
            this._ISKALT = ISKALT;
            this._BRUTT = BRUTT;
            this._ISKT = ISKT;
            this._NETT = NETT;
            this._KDVT = KDVT;
            this._NETKDVT = NETKDVT;
        }
        //
        //
        public Efatura(int intMusteriID, string strAd, DateTime dtTarih, string LT, string BOLGE, string GRP, string EKP, string ABRNO, string AMBAR, string AY, string HAFTA, string FATTAR,
            string FATNO, string FATVD, string TUR, string TURACK, string FTUR, string SLSREF, string SATKOD, string SATTEM, string TEDEKP,
            string TEDSLSREF, string TEDSATTEM, string IL, string ILCE, string MTACIKLAMA, string GMREF, string MUSKOD, string MUSTERI,
            string SMREF, string SUBKOD, string SUBE, string SEVKKOD, string SEVKADRES, string REYKOD, string REYON, string ANAGRP,
            string GRPKOD, string GRUP, string TEDGRP, string TEDKISAMAL, string BARCODE, string ITEMREF, string MALKOD, string MALZEME,
            string KOLI, string KDV, string BRM, string ADT, string ISK1, string ISK2, string ISK3, string ISK4, string ISK5, string ISKALT, string BRUTT,
            string ISKT, string NETT, string KDVT, string NETKDVT)
        {
            this._intMusteriID = intMusteriID;
            this._strAd = strAd;
            this._dtTarih = dtTarih;
            this._LT = LT;
            this._BOLGE = BOLGE;
            this._GRP = GRP;
            this._EKP = EKP;
            this._ABRNO = ABRNO;
            this._AMBAR = AMBAR;
            this._AY = AY;
            this._HAFTA = HAFTA;
            this._FATTAR = FATTAR;
            this._FATNO = FATNO;
            this._FATVD = FATVD;
            this._TUR = TUR;
            this._TURACK = TURACK;
            this._FTUR = FTUR;
            this._SLSREF = SLSREF;
            this._SATKOD = SATKOD;
            this._SATTEM = SATTEM;
            this._TEDEKP = TEDEKP;
            this._TEDSLSREF = TEDSLSREF;
            this._TEDSATTEM = TEDSATTEM;
            this._IL = IL;
            this._ILCE = ILCE;
            this._MTACIKLAMA = MTACIKLAMA;
            this._GMREF = GMREF;
            this._MUSKOD = MUSKOD;
            this._MUSTERI = MUSTERI;
            this._SMREF = SMREF;
            this._SUBKOD = SUBKOD;
            this._SUBE = SUBE;
            this._SEVKKOD = SEVKKOD;
            this._SEVKADRES = SEVKADRES;
            this._REYKOD = REYKOD;
            this._REYON = REYON;
            this._ANAGRP = ANAGRP;
            this._GRPKOD = GRPKOD;
            this._GRUP = GRUP;
            this._TEDGRP = TEDGRP;
            this._TEDKISAMAL = TEDKISAMAL;
            this._BARCODE = BARCODE;
            this._ITEMREF = ITEMREF;
            this._MALKOD = MALKOD;
            this._MALZEME = MALZEME;
            this._KOLI = KOLI;
            this._KDV = KDV;
            this._BRM = BRM;
            this._ADT = ADT;
            this._ISK1 = ISK1;
            this._ISK2 = ISK2;
            this._ISK3 = ISK3;
            this._ISK4 = ISK4;
            this._ISK5 = ISK5;
            this._ISKALT = ISKALT;
            this._BRUTT = BRUTT;
            this._ISKT = ISKT;
            this._NETT = NETT;
            this._KDVT = KDVT;
            this._NETKDVT = NETKDVT;
        }
        //
        //
        //
        // Özellikler:
        //
        public int pkID { get { return this._pkID; } set { value = this._pkID; } }
        public int intMusteriID { get { return this._intMusteriID; } set { value = this._intMusteriID; } }
        public string strAd { get { return this._strAd; } set { value = this._strAd; } }
        public DateTime dtTarih { get { return this._dtTarih; } set { value = this._dtTarih; } }
        public string LT { get { return this._LT; } set { value = this._LT; } }
        public string BOLGE { get { return this._BOLGE; } set { value = this._BOLGE; } }
        public string GRP { get { return this._GRP; } set { value = this._GRP; } }
        public string EKP { get { return this._EKP; } set { value = this._EKP; } }
        public string ABRNO { get { return this._ABRNO; } set { value = this._ABRNO; } }
        public string AMBAR { get { return this._AMBAR; } set { value = this._AMBAR; } }
        public string AY { get { return this._AY; } set { value = this._AY; } }
        public string HAFTA { get { return this._HAFTA; } set { value = this._HAFTA; } }
        public string FATTAR { get { return this._FATTAR; } set { value = this._FATTAR; } }
        public string FATNO { get { return this._FATNO; } set { value = this._FATNO; } }
        public string FATVD { get { return this._FATVD; } set { value = this._FATVD; } }
        public string TUR { get { return this._TUR; } set { value = this._TUR; } }
        public string TURACK { get { return this._TURACK; } set { value = this._TURACK; } }
        public string FTUR { get { return this._FTUR; } set { value = this._FTUR; } }
        public string SLSREF { get { return this._SLSREF; } set { value = this._SLSREF; } }
        public string SATKOD { get { return this._SATKOD; } set { value = this._SATKOD; } }
        public string SATTEM { get { return this._SATTEM; } set { value = this._SATTEM; } }
        public string TEDEKP { get { return this._TEDEKP; } set { value = this._TEDEKP; } }
        public string TEDSLSREF { get { return this._TEDSLSREF; } set { value = this._TEDSLSREF; } }
        public string TEDSATTEM { get { return this._TEDSATTEM; } set { value = this._TEDSATTEM; } }
        public string IL { get { return this._IL; } set { value = this._IL; } }
        public string ILCE { get { return this._ILCE; } set { value = this._ILCE; } }
        public string MTACIKLAMA { get { return this._MTACIKLAMA; } set { value = this._MTACIKLAMA; } }
        public string GMREF { get { return this._GMREF; } set { value = this._GMREF; } }
        public string MUSKOD { get { return this._MUSKOD; } set { value = this._MUSKOD; } }
        public string MUSTERI { get { return this._MUSTERI; } set { value = this._MUSTERI; } }
        public string SMREF { get { return this._SMREF; } set { value = this._SMREF; } }
        public string SUBKOD { get { return this._SUBKOD; } set { value = this._SUBKOD; } }
        public string SUBE { get { return this._SUBE; } set { value = this._SUBE; } }
        public string SEVKKOD { get { return this._SEVKKOD; } set { value = this._SEVKKOD; } }
        public string SEVKADRES { get { return this._SEVKADRES; } set { value = this._SEVKADRES; } }
        public string REYKOD { get { return this._REYKOD; } set { value = this._REYKOD; } }
        public string REYON { get { return this._REYON; } set { value = this._REYON; } }
        public string ANAGRP { get { return this._ANAGRP; } set { value = this._ANAGRP; } }
        public string GRPKOD { get { return this._GRPKOD; } set { value = this._GRPKOD; } }
        public string GRUP { get { return this._GRUP; } set { value = this._GRUP; } }
        public string TEDGRP { get { return this._TEDGRP; } set { value = this._TEDGRP; } }
        public string TEDKISAMAL { get { return this._TEDKISAMAL; } set { value = this._TEDKISAMAL; } }
        public string BARCODE { get { return this._BARCODE; } set { value = this._BARCODE; } }
        public string ITEMREF { get { return this._ITEMREF; } set { value = this._ITEMREF; } }
        public string MALKOD { get { return this._MALKOD; } set { value = this._MALKOD; } }
        public string MALZEME { get { return this._MALZEME; } set { value = this._MALZEME; } }
        public string KOLI { get { return this._KOLI; } set { value = this._KOLI; } }
        public string KDV { get { return this._KDV; } set { value = this._KDV; } }
        public string BRM { get { return this._BRM; } set { value = this._BRM; } }
        public string ADT { get { return this._ADT; } set { value = this._ADT; } }
        public string ISK1 { get { return this._ISK1; } set { value = this._ISK1; } }
        public string ISK2 { get { return this._ISK2; } set { value = this._ISK2; } }
        public string ISK3 { get { return this._ISK3; } set { value = this._ISK3; } }
        public string ISK4 { get { return this._ISK4; } set { value = this._ISK4; } }
        public string ISK5 { get { return this._ISK5; } set { value = this._ISK5; } }
        public string ISKALT { get { return this._ISKALT; } set { value = this._ISKALT; } }
        public string BRUTT { get { return this._BRUTT; } set { value = this._BRUTT; } }
        public string ISKT { get { return this._ISKT; } set { value = this._ISKT; } }
        public string NETT { get { return this._NETT; } set { value = this._NETT; } }
        public string KDVT { get { return this._KDVT; } set { value = this._KDVT; } }
        public string NETKDVT { get { return this._NETKDVT; } set { value = this._NETKDVT; } }
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
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_INTERNET_MusterilerEFaturaAliasEkle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@intMusteriID", SqlDbType.Int).Value = this._intMusteriID;
                cmd.Parameters.Add("@strAd", SqlDbType.NVarChar).Value = this._strAd;
                cmd.Parameters.Add("@dtTarih", SqlDbType.DateTime).Value = this._dtTarih;
                cmd.Parameters.Add("@LT", SqlDbType.NVarChar).Value = this._LT;
                cmd.Parameters.Add("@BOLGE", SqlDbType.NVarChar).Value = this._BOLGE;
                cmd.Parameters.Add("@GRP", SqlDbType.NVarChar).Value = this._GRP;
                cmd.Parameters.Add("@EKP", SqlDbType.NVarChar).Value = this._EKP;
                cmd.Parameters.Add("@ABRNO", SqlDbType.NVarChar).Value = this._ABRNO;
                cmd.Parameters.Add("@AMBAR", SqlDbType.NVarChar).Value = this._AMBAR;
                cmd.Parameters.Add("@AY", SqlDbType.NVarChar).Value = this._AY;
                cmd.Parameters.Add("@HAFTA", SqlDbType.NVarChar).Value = this._HAFTA;
                cmd.Parameters.Add("@FATTAR", SqlDbType.NVarChar).Value = this._FATTAR;
                cmd.Parameters.Add("@FATNO", SqlDbType.NVarChar).Value = this._FATNO;
                cmd.Parameters.Add("@FATVD", SqlDbType.NVarChar).Value = this._FATVD;
                cmd.Parameters.Add("@TUR", SqlDbType.NVarChar).Value = this._TUR;
                cmd.Parameters.Add("@TURACK", SqlDbType.NVarChar).Value = this._TURACK;
                cmd.Parameters.Add("@FTUR", SqlDbType.NVarChar).Value = this._FTUR;
                cmd.Parameters.Add("@SLSREF", SqlDbType.NVarChar).Value = this._SLSREF;
                cmd.Parameters.Add("@SATKOD", SqlDbType.NVarChar).Value = this._SATKOD;
                cmd.Parameters.Add("@SATTEM", SqlDbType.NVarChar).Value = this._SATTEM;
                cmd.Parameters.Add("@TEDEKP", SqlDbType.NVarChar).Value = this._TEDEKP;
                cmd.Parameters.Add("@TEDSLSREF", SqlDbType.NVarChar).Value = this._TEDSLSREF;
                cmd.Parameters.Add("@TEDSATTEM", SqlDbType.NVarChar).Value = this._TEDSATTEM;
                cmd.Parameters.Add("@IL", SqlDbType.NVarChar).Value = this._IL;
                cmd.Parameters.Add("@ILCE", SqlDbType.NVarChar).Value = this._ILCE;
                cmd.Parameters.Add("@MTACIKLAMA", SqlDbType.NVarChar).Value = this._MTACIKLAMA;
                cmd.Parameters.Add("@GMREF", SqlDbType.NVarChar).Value = this._GMREF;
                cmd.Parameters.Add("@MUSKOD", SqlDbType.NVarChar).Value = this._MUSKOD;
                cmd.Parameters.Add("@MUSTERI", SqlDbType.NVarChar).Value = this._MUSTERI;
                cmd.Parameters.Add("@SMREF", SqlDbType.NVarChar).Value = this._SMREF;
                cmd.Parameters.Add("@SUBKOD", SqlDbType.NVarChar).Value = this._SUBKOD;
                cmd.Parameters.Add("@SUBE", SqlDbType.NVarChar).Value = this._SUBE;
                cmd.Parameters.Add("@SEVKKOD", SqlDbType.NVarChar).Value = this._SEVKKOD;
                cmd.Parameters.Add("@SEVKADRES", SqlDbType.NVarChar).Value = this._SEVKADRES;
                cmd.Parameters.Add("@REYKOD", SqlDbType.NVarChar).Value = this._REYKOD;
                cmd.Parameters.Add("@REYON", SqlDbType.NVarChar).Value = this._REYON;
                cmd.Parameters.Add("@ANAGRP", SqlDbType.NVarChar).Value = this._ANAGRP;
                cmd.Parameters.Add("@GRPKOD", SqlDbType.NVarChar).Value = this._GRPKOD;
                cmd.Parameters.Add("@GRUP", SqlDbType.NVarChar).Value = this._GRUP;
                cmd.Parameters.Add("@TEDGRP", SqlDbType.NVarChar).Value = this._TEDGRP;
                cmd.Parameters.Add("@TEDKISAMAL", SqlDbType.NVarChar).Value = this._TEDKISAMAL;
                cmd.Parameters.Add("@BARCODE", SqlDbType.NVarChar).Value = this._BARCODE;
                cmd.Parameters.Add("@ITEMREF", SqlDbType.NVarChar).Value = this._ITEMREF;
                cmd.Parameters.Add("@MALKOD", SqlDbType.NVarChar).Value = this._MALKOD;
                cmd.Parameters.Add("@MALZEME", SqlDbType.NVarChar).Value = this._MALZEME;
                cmd.Parameters.Add("@KOLI", SqlDbType.NVarChar).Value = this._KOLI;
                cmd.Parameters.Add("@KDV", SqlDbType.NVarChar).Value = this._KDV;
                cmd.Parameters.Add("@BRM", SqlDbType.NVarChar).Value = this._BRM;
                cmd.Parameters.Add("@ADT", SqlDbType.NVarChar).Value = this._ADT;
                cmd.Parameters.Add("@ISK1", SqlDbType.NVarChar).Value = this._ISK1;
                cmd.Parameters.Add("@ISK2", SqlDbType.NVarChar).Value = this._ISK2;
                cmd.Parameters.Add("@ISK3", SqlDbType.NVarChar).Value = this._ISK3;
                cmd.Parameters.Add("@ISK4", SqlDbType.NVarChar).Value = this._ISK4;
                cmd.Parameters.Add("@ISK5", SqlDbType.NVarChar).Value = this._ISK5;
                cmd.Parameters.Add("@ISKALT", SqlDbType.NVarChar).Value = this._ISKALT;
                cmd.Parameters.Add("@BRUTT", SqlDbType.NVarChar).Value = this._BRUTT;
                cmd.Parameters.Add("@ISKT", SqlDbType.NVarChar).Value = this._ISKT;
                cmd.Parameters.Add("@NETT", SqlDbType.NVarChar).Value = this._NETT;
                cmd.Parameters.Add("@KDVT", SqlDbType.NVarChar).Value = this._KDVT;
                cmd.Parameters.Add("@NETKDVT", SqlDbType.NVarChar).Value = this._NETKDVT;
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
        /// <summary>
        /// Çalışmıyor içini doldurmadım
        /// </summary>
        public void DoUpdate()
        {

        }
        //
        //
        public void DoDelete()
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_INTERNET_MusterilerEFaturaAliasSil", conn);
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
        public static void GetObjects(DataTable dt)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_INTERNET_MusterilerEFaturaAliasGetir", conn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
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
        public static Efatura GetObject(int ID)
        {
            Efatura donendeger = null;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_INTERNET_MusterilerEFaturaAliasGetirByID", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkID", SqlDbType.Int).Value = ID;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        donendeger = new Efatura(Convert.ToInt32(dr[0]), Convert.ToInt32(dr[1]), dr[2].ToString(), Convert.ToDateTime(dr[3]),
                            dr[4].ToString(),
                            dr[5].ToString(),
                            dr[6].ToString(),
                            dr[7].ToString(),
                            dr[8].ToString(),
                            dr[9].ToString(),
                            dr[10].ToString(),
                            dr[11].ToString(),
                            dr[12].ToString(),
                            dr[13].ToString(),
                            dr[14].ToString(),
                            dr[15].ToString(),
                            dr[16].ToString(),
                            dr[17].ToString(),
                            dr[18].ToString(),
                            dr[19].ToString(),
                            dr[20].ToString(),
                            dr[21].ToString(),
                            dr[22].ToString(),
                            dr[23].ToString(),
                            dr[24].ToString(),
                            dr[25].ToString(),
                            dr[26].ToString(),
                            dr[27].ToString(),
                            dr[28].ToString(),
                            dr[29].ToString(),
                            dr[30].ToString(),
                            dr[31].ToString(),
                            dr[32].ToString(),
                            dr[33].ToString(),
                            dr[34].ToString(),
                            dr[35].ToString(),
                            dr[36].ToString(),
                            dr[37].ToString(),
                            dr[38].ToString(),
                            dr[39].ToString(),
                            dr[40].ToString(),
                            dr[41].ToString(),
                            dr[42].ToString(),
                            dr[43].ToString(),
                            dr[44].ToString(),
                            dr[45].ToString(),
                            dr[46].ToString(),
                            dr[47].ToString(),
                            dr[48].ToString(),
                            dr[49].ToString(),
                            dr[50].ToString(),
                            dr[51].ToString(),
                            dr[52].ToString(),
                            dr[53].ToString(),
                            dr[54].ToString(),
                            dr[55].ToString(),
                            dr[56].ToString(),
                            dr[57].ToString(),
                            dr[58].ToString(),
                            dr[59].ToString(),
                            dr[60].ToString());
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
        public static void GetIDAdByMusteriID(ListItemCollection list, int MusteriID)
        {
            list.Clear();

            list.Add(new ListItem(" ::: Yeni Seçim ::: ", "0"));

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_INTERNET_MusterilerEFaturaAliasGetirByMusteriID", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@intMusteriID", SqlDbType.Int).Value = MusteriID;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        list.Add(new ListItem(dr[2].ToString(), dr[0].ToString()));
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
        public static void GetFATNOFATTARByVRGNO(DataTable dt, string VRGNO, DateTime BaslangicTarih, DateTime BitisTarih)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT DISTINCT [FAT NO],[FAT TAR] FROM [Web-Satis-Rapor] WHERE (SELECT TOP 1 [VRG NO] FROM [Web-Musteri] WHERE GMREF = [Web-Satis-Rapor].GMREF) = @VRGNO AND [FAT TAR] >= @BaslangicTarih AND [FAT TAR] <= @BitisTarih ORDER BY [FAT TAR]", conn);
                da.SelectCommand.CommandTimeout = 600;
                da.SelectCommand.Parameters.Add("@VRGNO", SqlDbType.NVarChar).Value = VRGNO;
                da.SelectCommand.Parameters.Add("@BaslangicTarih", SqlDbType.SmallDateTime).Value = BaslangicTarih;
                da.SelectCommand.Parameters.Add("@BitisTarih", SqlDbType.SmallDateTime).Value = BitisTarih;
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
        public static void GetFATNOFATTARByGMREF(DataTable dt, int GMREF, DateTime BaslangicTarih, DateTime BitisTarih)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT DISTINCT [FAT NO],[FAT TAR] FROM [Web-Satis-Rapor] WHERE [GMREF] = @GMREF AND [FAT TAR] >= @BaslangicTarih AND [FAT TAR] <= @BitisTarih ORDER BY [FAT TAR]", conn);
                da.SelectCommand.CommandTimeout = 600;
                da.SelectCommand.Parameters.Add("@GMREF", SqlDbType.Int).Value = GMREF;
                da.SelectCommand.Parameters.Add("@BaslangicTarih", SqlDbType.SmallDateTime).Value = BaslangicTarih;
                da.SelectCommand.Parameters.Add("@BitisTarih", SqlDbType.SmallDateTime).Value = BitisTarih;
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
        public static void GetFATNOFATTARTURACKByGMREF(DataTable dt, int GMREF, DateTime BaslangicTarih, DateTime BitisTarih)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT DISTINCT [FAT TAR],[FAT NO],[TUR ACK] FROM [Web-Satis-Rapor] WHERE [GMREF] = @GMREF AND [FAT TAR] >= @BaslangicTarih AND [FAT TAR] <= @BitisTarih ORDER BY [FAT TAR]", conn);
                da.SelectCommand.CommandTimeout = 600;
                da.SelectCommand.Parameters.Add("@GMREF", SqlDbType.Int).Value = GMREF;
                da.SelectCommand.Parameters.Add("@BaslangicTarih", SqlDbType.SmallDateTime).Value = BaslangicTarih;
                da.SelectCommand.Parameters.Add("@BitisTarih", SqlDbType.SmallDateTime).Value = BitisTarih;
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
        public static void GetFATNOFATTARTURACKByGMREF(ListItemCollection list, int GMREF, DateTime BaslangicTarih, DateTime BitisTarih)
        {
            list.Clear();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT DISTINCT [FAT NO],' &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' + [FAT NO] + ' &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' + CONVERT(VARCHAR(10),[FAT TAR],110) + ' &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' + [TUR ACK],[FAT TAR] FROM [Web-Satis-Rapor] WHERE [GMREF] = @GMREF AND [FAT TAR] >= @BaslangicTarih AND [FAT TAR] <= @BitisTarih ORDER BY [FAT TAR]", conn);
                cmd.CommandTimeout = 600;
                cmd.Parameters.Add("@GMREF", SqlDbType.Int).Value = GMREF;
                cmd.Parameters.Add("@BaslangicTarih", SqlDbType.SmallDateTime).Value = BaslangicTarih;
                cmd.Parameters.Add("@BitisTarih", SqlDbType.SmallDateTime).Value = BitisTarih;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        list.Add(new ListItem(dr[1].ToString(), dr[0].ToString()));
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
        public static void GetFATNOFATTARTUTARByGMREF(DataTable dt, int GMREF, DateTime BaslangicTarih, DateTime BitisTarih)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT DISTINCT [FAT TAR] AS Tarih,[FAT NO] AS No,[NET+KDV T] AS Tutar FROM [Web-Satis-Rapor] WHERE [GMREF] = @GMREF AND [FAT TAR] >= @BaslangicTarih AND [FAT TAR] <= @BitisTarih ORDER BY [FAT TAR]", conn);
                da.SelectCommand.CommandTimeout = 600;
                da.SelectCommand.Parameters.Add("@GMREF", SqlDbType.Int).Value = GMREF;
                da.SelectCommand.Parameters.Add("@BaslangicTarih", SqlDbType.SmallDateTime).Value = BaslangicTarih;
                da.SelectCommand.Parameters.Add("@BitisTarih", SqlDbType.SmallDateTime).Value = BitisTarih;
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
        public static void GetObjectByFATNO(DataTable dt, string FATNO)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT LT,BOLGE,GRP,EKP,[ABR NO],AMBAR,AY,HAFTA,CONVERT(VARCHAR(10),[FAT TAR],104) AS [FAT TAR],[FAT NO],CONVERT(VARCHAR(10),[FAT VD],104) AS [FAT VD],TUR,[TUR ACK],[F TUR],SLSREF,[SAT KOD],[SAT TEM],[TED EKP],TEDSLSREF,[TED SAT TEM],IL,ILCE,[MT ACIKLAMA],GMREF,[MUS KOD],MUSTERI,SMREF,[SUB KOD],SUBE,[SEVK KOD],[SEVK ADRES],[REY KOD],REYON,[ANA GRP],[GRP KOD],GRUP,[TED GRP],[TED KISA MAL],BARCODE,ITEMREF,[MAL KOD],MALZEME,KOLI,KDV,BRM,[AD T],ISK1,ISK2,ISK3,ISK4,ISK5,ISKALT,[BRUT T],[ISK T],[NET T],[KDV T],[NET+KDV T] FROM [Web-Satis-Rapor] WHERE [FAT NO] = @FATNO ORDER BY MALZEME", conn);
                da.SelectCommand.CommandTimeout = 600;
                da.SelectCommand.Parameters.Add("@FATNO", SqlDbType.VarChar, 17).Value = FATNO;
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
        public static void GetObjectsByGMREF(DataTable dt, int GMREF, DateTime BaslangicTarih, DateTime BitisTarih)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT LT,BOLGE,GRP,EKP,[ABR NO],AMBAR,AY,HAFTA,[FAT TAR],[FAT NO],[FAT VD],TUR,[TUR ACK],[F TUR],SLSREF,[SAT KOD],[SAT TEM],[TED EKP],TEDSLSREF,[TED SAT TEM],IL,ILCE,[MT ACIKLAMA],GMREF,[MUS KOD],MUSTERI,SMREF,[SUB KOD],SUBE,[SEVK KOD],[SEVK ADRES],[REY KOD],REYON,[ANA GRP],[GRP KOD],GRUP,[TED GRP],[TED KISA MAL],BARCODE,ITEMREF,[MAL KOD],MALZEME,KOLI,KDV,BRM,[AD T],ISK1,ISK2,ISK3,ISK4,ISK5,ISKALT,[BRUT T],[ISK T],[NET T],[KDV T],[NET+KDV T] FROM [Web-Satis-Rapor] WHERE [GMREF] = @GMREF AND [FAT TAR] >= @BaslangicTarih AND [FAT TAR] <= @BitisTarih ORDER BY [FAT TAR]", conn);
                da.SelectCommand.CommandTimeout = 600;
                da.SelectCommand.Parameters.Add("@GMREF", SqlDbType.Int).Value = GMREF;
                da.SelectCommand.Parameters.Add("@BaslangicTarih", SqlDbType.SmallDateTime).Value = BaslangicTarih;
                da.SelectCommand.Parameters.Add("@BitisTarih", SqlDbType.SmallDateTime).Value = BitisTarih;
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
        public static void GetObjectsBySMREF(DataTable dt, int SMREF, DateTime BaslangicTarih, DateTime BitisTarih)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT LT,BOLGE,GRP,EKP,[ABR NO],AMBAR,AY,HAFTA,[FAT TAR],[FAT NO],[FAT VD],TUR,[TUR ACK],[F TUR],SLSREF,[SAT KOD],[SAT TEM],[TED EKP],TEDSLSREF,[TED SAT TEM],IL,ILCE,[MT ACIKLAMA],GMREF,[MUS KOD],MUSTERI,SMREF,[SUB KOD],SUBE,[SEVK KOD],[SEVK ADRES],[REY KOD],REYON,[ANA GRP],[GRP KOD],GRUP,[TED GRP],[TED KISA MAL],BARCODE,ITEMREF,[MAL KOD],MALZEME,KOLI,KDV,BRM,[AD T],ISK1,ISK2,ISK3,ISK4,ISK5,ISKALT,[BRUT T],[ISK T],[NET T],[KDV T],[NET+KDV T] FROM [Web-Satis-Rapor] WHERE [SMREF] = @SMREF AND [FAT TAR] >= @BaslangicTarih AND [FAT TAR] <= @BitisTarih ORDER BY [FAT TAR]", conn);
                da.SelectCommand.CommandTimeout = 600;
                da.SelectCommand.Parameters.Add("@SMREF", SqlDbType.Int).Value = SMREF;
                da.SelectCommand.Parameters.Add("@BaslangicTarih", SqlDbType.SmallDateTime).Value = BaslangicTarih;
                da.SelectCommand.Parameters.Add("@BitisTarih", SqlDbType.SmallDateTime).Value = BitisTarih;
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
}

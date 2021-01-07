using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace Sultanlar.DatabaseObject.Internet
{
    public class Aktiviteler : ISultanlar, IDisposable
    {
        //
        //
        //
        // Alanlar:
        //
        private int _pkID;
        private int _intMusteriID;
        private int _SMREF;
        private short _sintFiyatTipiID;
        private int _intAnlasmaID;
        private int _intAktiviteTipiID;
        private DateTime _dtOlusmaTarihi;
        private DateTime _dtOnaylamaTarihi;
        private bool _blAktarilmis;
        private DateTime _dtAktiviteBaslangic;
        private DateTime _dtAktiviteBitis;
        private string _strAciklama1;
        private string _strAciklama2;
        private string _strAciklama3;
        private string _strAciklama4;
        private decimal _mnTahSabitBedel;
        private decimal _mnYegSabitBedel;
        private decimal _mnTahHedefCiro;
        private decimal _mnYegHedefCiro;
        private decimal _mnAktiviteKarZarar;
        private double _flAktiviteKarZararYuzde;
        //
        //
        //
        // Constracter lar:
        //
        public Aktiviteler()
        {
            
        }
        //
        //
        private Aktiviteler(int pkID, int intMusteriID, int SMREF, short sintFiyatTipiID, int intAnlasmaID, int intAktiviteTipiID,
            DateTime dtOlusmaTarihi, DateTime dtOnaylamaTarihi, bool blAktarilmis, DateTime dtAktiviteBaslangic, DateTime dtAktiviteBitis,
            string strAciklama1, string strAciklama2, string strAciklama3, string strAciklama4, decimal mnTahSabitBedel, decimal mnYegSabitBedel,
            decimal mnTahHedefCiro, decimal mnYegHedefCiro, decimal mnAktiviteKarZarar, double flAktiviteKarZararYuzde)
        {
            this._pkID = pkID;
            this._intMusteriID = intMusteriID;
            this._SMREF = SMREF;
            this._sintFiyatTipiID = sintFiyatTipiID;
            this._intAnlasmaID = intAnlasmaID;
            this._intAktiviteTipiID = intAktiviteTipiID;
            this._dtOlusmaTarihi = dtOlusmaTarihi;
            this._dtOnaylamaTarihi = dtOnaylamaTarihi;
            this._blAktarilmis = blAktarilmis;
            this._dtAktiviteBaslangic = dtAktiviteBaslangic;
            this._dtAktiviteBitis = dtAktiviteBitis;
            this._strAciklama1 = strAciklama1;
            this._strAciklama2 = strAciklama2;
            this._strAciklama3 = strAciklama3;
            this._strAciklama4 = strAciklama4;
            this._mnTahSabitBedel = mnTahSabitBedel;
            this._mnYegSabitBedel = mnYegSabitBedel;
            this._mnTahHedefCiro = mnTahHedefCiro;
            this._mnYegHedefCiro = mnYegHedefCiro;
            this._mnAktiviteKarZarar = mnAktiviteKarZarar;
            this._flAktiviteKarZararYuzde = flAktiviteKarZararYuzde;
        }
        //
        //
        public Aktiviteler(int intMusteriID, int SMREF, short sintFiyatTipiID, int intAnlasmaID, int intAktiviteTipiID,
            DateTime dtOlusmaTarihi, DateTime dtOnaylamaTarihi, bool blAktarilmis, DateTime dtAktiviteBaslangic, DateTime dtAktiviteBitis,
            string strAciklama1, string strAciklama2, string strAciklama3, string strAciklama4, decimal mnTahSabitBedel, decimal mnYegSabitBedel,
            decimal mnTahHedefCiro, decimal mnYegHedefCiro, decimal mnAktiviteKarZarar, double flAktiviteKarZararYuzde)
        {
            this._intMusteriID = intMusteriID;
            this._SMREF = SMREF;
            this._sintFiyatTipiID = sintFiyatTipiID;
            this._intAnlasmaID = intAnlasmaID;
            this._intAktiviteTipiID = intAktiviteTipiID;
            this._dtOlusmaTarihi = dtOlusmaTarihi;
            this._dtOnaylamaTarihi = dtOnaylamaTarihi;
            this._blAktarilmis = blAktarilmis;
            this._dtAktiviteBaslangic = dtAktiviteBaslangic;
            this._dtAktiviteBitis = dtAktiviteBitis;
            this._strAciklama1 = strAciklama1;
            this._strAciklama2 = strAciklama2;
            this._strAciklama3 = strAciklama3;
            this._strAciklama4 = strAciklama4;
            this._mnTahSabitBedel = mnTahSabitBedel;
            this._mnYegSabitBedel = mnYegSabitBedel;
            this._mnTahHedefCiro = mnTahHedefCiro;
            this._mnYegHedefCiro = mnYegHedefCiro;
            this._mnAktiviteKarZarar = mnAktiviteKarZarar;
            this._flAktiviteKarZararYuzde = flAktiviteKarZararYuzde;
        }
        //
        //
        //
        // Özellikler:
        //
        public int pkID { get { return this._pkID; } }
        public int intMusteriID { get { return this._intMusteriID; } set { this._intMusteriID = value; } }
        public int SMREF { get { return this._SMREF; } set { this._SMREF = value; } }
        public short sintFiyatTipiID { get { return this._sintFiyatTipiID; } set { this._sintFiyatTipiID = value; } }
        public int intAnlasmaID { get { return this._intAnlasmaID; } set { this._intAnlasmaID = value; } }
        public int intAktiviteTipiID { get { return this._intAktiviteTipiID; } set { this._intAktiviteTipiID = value; } }
        public DateTime dtOlusmaTarihi { get { return this._dtOlusmaTarihi; } set { this._dtOlusmaTarihi = value; } }
        public DateTime dtOnaylamaTarihi { get { return this._dtOnaylamaTarihi; } set { this._dtOnaylamaTarihi = value; } }
        public bool blAktarilmis { get { return this._blAktarilmis; } set { this._blAktarilmis = value; } }
        public DateTime dtAktiviteBaslangic { get { return this._dtAktiviteBaslangic; } set { this._dtAktiviteBaslangic = value; } }
        public DateTime dtAktiviteBitis { get { return this._dtAktiviteBitis; } set { this._dtAktiviteBitis = value; } }
        public string strAciklama1 { get { return this._strAciklama1; } set { this._strAciklama1 = value; } }
        public string strAciklama2 { get { return this._strAciklama2; } set { this._strAciklama2 = value; } }
        public string strAciklama3 { get { return this._strAciklama3; } set { this._strAciklama3 = value; } }
        public string strAciklama4 { get { return this._strAciklama4; } set { this._strAciklama4 = value; } }
        public decimal mnTahSabitBedel { get { return this._mnTahSabitBedel; } set { this._mnTahSabitBedel = value; } }
        public decimal mnYegSabitBedel { get { return this._mnYegSabitBedel; } set { this._mnYegSabitBedel = value; } }
        public decimal mnTahHedefCiro { get { return this._mnTahHedefCiro; } set { this._mnTahHedefCiro = value; } }
        public decimal mnYegHedefCiro { get { return this._mnYegHedefCiro; } set { this._mnYegHedefCiro = value; } }
        public decimal mnAktiviteKarZarar { get { return this._mnAktiviteKarZarar; } set { this._mnAktiviteKarZarar = value; } }
        public double flAktiviteKarZararYuzde { get { return this._flAktiviteKarZararYuzde; } set { this._flAktiviteKarZararYuzde = value; } }
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
                SqlCommand cmd = new SqlCommand("sp_INTERNET_AktiviteEkle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@intMusteriID", SqlDbType.Int).Value = this._intMusteriID;
                cmd.Parameters.Add("@SMREF", SqlDbType.Int).Value = this._SMREF;
                cmd.Parameters.Add("@sintFiyatTipiID", SqlDbType.SmallInt).Value = this._sintFiyatTipiID;
                cmd.Parameters.Add("@intAnlasmaID", SqlDbType.Int).Value = this._intAnlasmaID;
                cmd.Parameters.Add("@intAktiviteTipiID", SqlDbType.Int).Value = this._intAktiviteTipiID;
                cmd.Parameters.Add("@dtOlusmaTarihi", SqlDbType.SmallDateTime).Value = this._dtOlusmaTarihi;
                cmd.Parameters.Add("@dtOnaylamaTarihi", SqlDbType.SmallDateTime).Value = this._dtOlusmaTarihi;
                cmd.Parameters.Add("@blAktarilmis", SqlDbType.Bit).Value = this._blAktarilmis;
                cmd.Parameters.Add("@dtAktiviteBaslangic", SqlDbType.SmallDateTime).Value = this._dtAktiviteBaslangic;
                cmd.Parameters.Add("@dtAktiviteBitis", SqlDbType.SmallDateTime).Value = this._dtAktiviteBitis;
                cmd.Parameters.Add("@strAciklama1", SqlDbType.NVarChar).Value = this._strAciklama1;
                cmd.Parameters.Add("@strAciklama2", SqlDbType.NVarChar).Value = this._strAciklama2;
                cmd.Parameters.Add("@strAciklama3", SqlDbType.NVarChar).Value = this._strAciklama3;
                cmd.Parameters.Add("@strAciklama4", SqlDbType.NVarChar).Value = this._strAciklama4;
                cmd.Parameters.Add("@mnTahSabitBedel", SqlDbType.Money).Value = this._mnTahSabitBedel;
                cmd.Parameters.Add("@mnYegSabitBedel", SqlDbType.Money).Value = this._mnYegSabitBedel;
                cmd.Parameters.Add("@mnTahHedefCiro", SqlDbType.Money).Value = this._mnTahHedefCiro;
                cmd.Parameters.Add("@mnYegHedefCiro", SqlDbType.Money).Value = this._mnYegHedefCiro;
                cmd.Parameters.Add("@mnAktiviteKarZarar", SqlDbType.Money).Value = this._mnAktiviteKarZarar;
                cmd.Parameters.Add("@flAktiviteKarZararYuzde", SqlDbType.Float).Value = this._flAktiviteKarZararYuzde;
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
                SqlCommand cmd = new SqlCommand("sp_INTERNET_AktiviteGuncelle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkID", SqlDbType.Int).Value = this._pkID;
                cmd.Parameters.Add("@intMusteriID", SqlDbType.Int).Value = this._intMusteriID;
                cmd.Parameters.Add("@SMREF", SqlDbType.Int).Value = this._SMREF;
                cmd.Parameters.Add("@sintFiyatTipiID", SqlDbType.SmallInt).Value = this._sintFiyatTipiID;
                cmd.Parameters.Add("@intAnlasmaID", SqlDbType.Int).Value = this._intAnlasmaID;
                cmd.Parameters.Add("@intAktiviteTipiID", SqlDbType.Int).Value = this._intAktiviteTipiID;
                cmd.Parameters.Add("@dtOlusmaTarihi", SqlDbType.SmallDateTime).Value = this._dtOlusmaTarihi;
                cmd.Parameters.Add("@dtOnaylamaTarihi", SqlDbType.SmallDateTime).Value = this._dtOnaylamaTarihi;
                cmd.Parameters.Add("@blAktarilmis", SqlDbType.Bit).Value = this._blAktarilmis;
                cmd.Parameters.Add("@dtAktiviteBaslangic", SqlDbType.SmallDateTime).Value = this._dtAktiviteBaslangic;
                cmd.Parameters.Add("@dtAktiviteBitis", SqlDbType.SmallDateTime).Value = this._dtAktiviteBitis;
                cmd.Parameters.Add("@strAciklama1", SqlDbType.NVarChar).Value = this._strAciklama1;
                cmd.Parameters.Add("@strAciklama2", SqlDbType.NVarChar).Value = this._strAciklama2;
                cmd.Parameters.Add("@strAciklama3", SqlDbType.NVarChar).Value = this._strAciklama3;
                cmd.Parameters.Add("@strAciklama4", SqlDbType.NVarChar).Value = this._strAciklama4;
                cmd.Parameters.Add("@mnTahSabitBedel", SqlDbType.Money).Value = this._mnTahSabitBedel;
                cmd.Parameters.Add("@mnYegSabitBedel", SqlDbType.Money).Value = this._mnYegSabitBedel;
                cmd.Parameters.Add("@mnTahHedefCiro", SqlDbType.Money).Value = this._mnTahHedefCiro;
                cmd.Parameters.Add("@mnYegHedefCiro", SqlDbType.Money).Value = this._mnYegHedefCiro;
                cmd.Parameters.Add("@mnAktiviteKarZarar", SqlDbType.Money).Value = this._mnAktiviteKarZarar;
                cmd.Parameters.Add("@flAktiviteKarZararYuzde", SqlDbType.Float).Value = this._flAktiviteKarZararYuzde;
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
        /// aktarılma durumunu update yapmaz çünkü null ise false yapmasın
        /// </summary>
        public void DoUpdate(bool aktarilmayielleme)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_INTERNET_AktiviteGuncelleAktarilmissiz", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkID", SqlDbType.Int).Value = this._pkID;
                cmd.Parameters.Add("@intMusteriID", SqlDbType.Int).Value = this._intMusteriID;
                cmd.Parameters.Add("@SMREF", SqlDbType.Int).Value = this._SMREF;
                cmd.Parameters.Add("@sintFiyatTipiID", SqlDbType.SmallInt).Value = this._sintFiyatTipiID;
                cmd.Parameters.Add("@intAnlasmaID", SqlDbType.Int).Value = this._intAnlasmaID;
                cmd.Parameters.Add("@intAktiviteTipiID", SqlDbType.Int).Value = this._intAktiviteTipiID;
                cmd.Parameters.Add("@dtOlusmaTarihi", SqlDbType.SmallDateTime).Value = this._dtOlusmaTarihi;
                cmd.Parameters.Add("@dtOnaylamaTarihi", SqlDbType.SmallDateTime).Value = this._dtOnaylamaTarihi;
                //cmd.Parameters.Add("@blAktarilmis", SqlDbType.Bit).Value = this._blAktarilmis;
                cmd.Parameters.Add("@dtAktiviteBaslangic", SqlDbType.SmallDateTime).Value = this._dtAktiviteBaslangic;
                cmd.Parameters.Add("@dtAktiviteBitis", SqlDbType.SmallDateTime).Value = this._dtAktiviteBitis;
                cmd.Parameters.Add("@strAciklama1", SqlDbType.NVarChar).Value = this._strAciklama1;
                cmd.Parameters.Add("@strAciklama2", SqlDbType.NVarChar).Value = this._strAciklama2;
                cmd.Parameters.Add("@strAciklama3", SqlDbType.NVarChar).Value = this._strAciklama3;
                cmd.Parameters.Add("@strAciklama4", SqlDbType.NVarChar).Value = this._strAciklama4;
                cmd.Parameters.Add("@mnTahSabitBedel", SqlDbType.Money).Value = this._mnTahSabitBedel;
                cmd.Parameters.Add("@mnYegSabitBedel", SqlDbType.Money).Value = this._mnYegSabitBedel;
                cmd.Parameters.Add("@mnTahHedefCiro", SqlDbType.Money).Value = this._mnTahHedefCiro;
                cmd.Parameters.Add("@mnYegHedefCiro", SqlDbType.Money).Value = this._mnYegHedefCiro;
                cmd.Parameters.Add("@mnAktiviteKarZarar", SqlDbType.Money).Value = this._mnAktiviteKarZarar;
                cmd.Parameters.Add("@flAktiviteKarZararYuzde", SqlDbType.Float).Value = this._flAktiviteKarZararYuzde;
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
                SqlCommand cmd = new SqlCommand("sp_INTERNET_AktiviteSil", conn);
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
        public void DoReddet()
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UPDATE tblINTERNET_Aktiviteler SET blAktarilmis = NULL WHERE pkID = @pkID", conn);
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
        #region SMREF
        //
        //
        #region GetAktiviteCountBySMREF
        public static int GetAktiviteCountBySMREF(short FiyatTipi, int SMREF, DateTime BaslangicTarih, DateTime BitisTarih, object Onayli, bool Hepsi)
        {
            int donendeger = 0;

            string onayli = string.Empty;
            if (Onayli != DBNull.Value)
                onayli = " AND blAktarilmis = '" + Onayli.ToString() + "'";
            else if (Onayli == DBNull.Value && !Hepsi)
                onayli = " AND blAktarilmis IS NULL";

            string fiyattipi = FiyatTipi == 0 ? "" : FiyatTipi == 7 ? " AND (sintFiyatTipiID = 7 OR sintFiyatTipiID >= 500)" : " AND sintFiyatTipiID = 25";

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT count(pkID) FROM tblINTERNET_Aktiviteler WHERE SMREF = @SMREF AND dtOlusmaTarihi >= @BaslangicTarih AND dtOlusmaTarihi <= @BitisTarih " + fiyattipi + onayli, conn);
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
        #endregion
        //
        //
        #region GetObjectsBySMREF
        public static void GetObjectsBySMREF(short FiyatTipi, DataTable dt, int SMREF, DateTime BaslangicTarih, DateTime BitisTarih, int Baslangic, int Adet, object Onayli, bool Hepsi)
        {
            string onayli = string.Empty;
            if (Onayli != DBNull.Value)
                onayli = " AND blAktarilmis = '" + Onayli.ToString() + "'";
            else if (Onayli == DBNull.Value && !Hepsi)
                onayli = " AND blAktarilmis IS NULL";

            string fiyattipi = FiyatTipi == 0 ? "" : FiyatTipi == 7 ? " AND (sintFiyatTipiID = 7 OR sintFiyatTipiID >= 500)" : " AND sintFiyatTipiID = 25";

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT tblINTERNET_Aktiviteler.pkID AS pkAktiviteID,tblINTERNET_Aktiviteler.intMusteriID,tblINTERNET_Musteriler.strAd,tblINTERNET_Musteriler.strSoyad,tblINTERNET_Aktiviteler.SMREF,CASE WHEN [intAktiviteTipiID] = 1 THEN (SELECT TOP 1 MUSTERI FROM [Web-Musteri-TP] WHERE GMREF = SMREF AND GMREF = WebMusteriTP.GMREF) ELSE 'SULTANLAR PAZARLAMA A.Ş.' END AS BAYI,CASE WHEN [intAktiviteTipiID] = 1 THEN WebMusteriTP.MUSTERI ELSE (SELECT TOP 1 MUSTERI FROM [Web-Musteri] WHERE SMREF = tblINTERNET_Aktiviteler.SMREF) END AS MUSTERI,tblINTERNET_Aktiviteler.sintFiyatTipiID,(SELECT SUBSTRING(ACIKLAMA,1,2) FROM [Web-FiyatTipleri] WHERE NOSU = tblINTERNET_Aktiviteler.sintFiyatTipiID) AS FiyatTipi,[intAnlasmaID],[intAktiviteTipiID],tblINTERNET_Aktiviteler.dtOlusmaTarihi,tblINTERNET_Aktiviteler.dtOnaylamaTarihi,tblINTERNET_Aktiviteler.blAktarilmis,tblINTERNET_Aktiviteler.dtAktiviteBaslangic,tblINTERNET_Aktiviteler.dtAktiviteBitis,tblINTERNET_Aktiviteler.strAciklama1,tblINTERNET_Aktiviteler.strAciklama2,tblINTERNET_Aktiviteler.strAciklama3,tblINTERNET_Aktiviteler.strAciklama4,[mnTahSabitBedel],[mnYegSabitBedel],[mnTahHedefCiro],[mnYegHedefCiro],[mnAktiviteKarZarar],[flAktiviteKarZararYuzde] " + 
                    "FROM tblINTERNET_Aktiviteler " +
                    "INNER JOIN tblINTERNET_Musteriler ON tblINTERNET_Aktiviteler.intMusteriID = tblINTERNET_Musteriler.pkMusteriID LEFT OUTER JOIN [Web-Musteri-TP] AS WebMusteriTP ON tblINTERNET_Aktiviteler.SMREF = WebMusteriTP.SMREF " +
                    "WHERE tblINTERNET_Aktiviteler.dtOlusmaTarihi >= @BaslangicTarih AND tblINTERNET_Aktiviteler.dtOlusmaTarihi <= @BitisTarih " + fiyattipi + " AND tblINTERNET_Aktiviteler.SMREF = @SMREF" + onayli + " ORDER BY tblINTERNET_Aktiviteler.pkID DESC", conn);
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
        #endregion
        //
        //
        #endregion
        //
        //
        #region SMREFs
        //
        //
        #region GetAktiviteCountBySMREFs
        public static int GetAktiviteCountBySMREFs(short FiyatTipi, ArrayList SMREF, DateTime BaslangicTarih, DateTime BitisTarih, object Onayli, bool Hepsi)
        {
            int donendeger = 0;

            string smrefs = string.Empty;
            for (int i = 0; i < SMREF.Count; i++)
                smrefs += "SMREF = " + SMREF[i].ToString() + " OR ";
            if (SMREF.Count > 0)
                smrefs = smrefs.Substring(0, smrefs.Length - 3);
            else
                return 0;

            string fiyattipi = FiyatTipi == 0 ? "" : FiyatTipi == 7 ? " AND (sintFiyatTipiID = 7 OR sintFiyatTipiID >= 500)" : " AND sintFiyatTipiID = 25";

            string onayli = string.Empty;
            if (Onayli != DBNull.Value)
                onayli = " AND blAktarilmis = '" + Onayli.ToString() + "'";
            else if (Onayli == DBNull.Value && !Hepsi)
                onayli = " AND blAktarilmis IS NULL";

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT count(pkID) FROM tblINTERNET_Aktiviteler " +
                    "WHERE dtOlusmaTarihi >= @BaslangicTarih AND " +
                    "dtOlusmaTarihi <= @BitisTarih " + fiyattipi + " AND (" + smrefs + ")" + onayli, conn);
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
        #endregion
        //
        //
        #region GetObjectsBySMREFs
        public static void GetObjectsBySMREFs(short FiyatTipi, DataTable dt, ArrayList SMREF, DateTime BaslangicTarih, DateTime BitisTarih, int Baslangic, int Adet, object Onayli, bool Hepsi)
        {
            string smrefs = string.Empty;
            for (int i = 0; i < SMREF.Count; i++)
                smrefs += "tblINTERNET_Aktiviteler.SMREF = " + SMREF[i].ToString() + " OR ";
            if (SMREF.Count > 0)
                smrefs = smrefs.Substring(0, smrefs.Length - 3);
            else
                return;

            string fiyattipi = FiyatTipi == 0 ? "" : FiyatTipi == 7 ? " AND (sintFiyatTipiID = 7 OR sintFiyatTipiID >= 500)" : " AND sintFiyatTipiID = 25";

            string onayli = string.Empty;
            if (Onayli != DBNull.Value)
                onayli = " AND blAktarilmis = '" + Onayli.ToString() + "'";
            else if (Onayli == DBNull.Value && !Hepsi)
                onayli = " AND blAktarilmis IS NULL";

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT tblINTERNET_Aktiviteler.pkID AS pkAktiviteID,tblINTERNET_Aktiviteler.intMusteriID,tblINTERNET_Musteriler.strAd,tblINTERNET_Musteriler.strSoyad,tblINTERNET_Aktiviteler.SMREF,CASE WHEN [intAktiviteTipiID] = 1 THEN (SELECT TOP 1 MUSTERI FROM [Web-Musteri-TP] WHERE GMREF = SMREF AND GMREF = WebMusteriTP.GMREF) ELSE 'SULTANLAR PAZARLAMA A.Ş.' END AS BAYI,CASE WHEN [intAktiviteTipiID] = 1 THEN WebMusteriTP.MUSTERI ELSE (SELECT TOP 1 MUSTERI FROM [Web-Musteri] WHERE SMREF = tblINTERNET_Aktiviteler.SMREF) END AS MUSTERI,tblINTERNET_Aktiviteler.sintFiyatTipiID,(SELECT SUBSTRING(ACIKLAMA,1,2) FROM [Web-FiyatTipleri] WHERE NOSU = tblINTERNET_Aktiviteler.sintFiyatTipiID) AS FiyatTipi,[intAnlasmaID],[intAktiviteTipiID],tblINTERNET_Aktiviteler.dtOlusmaTarihi,tblINTERNET_Aktiviteler.dtOnaylamaTarihi,tblINTERNET_Aktiviteler.blAktarilmis,tblINTERNET_Aktiviteler.dtAktiviteBaslangic,tblINTERNET_Aktiviteler.dtAktiviteBitis,tblINTERNET_Aktiviteler.strAciklama1,tblINTERNET_Aktiviteler.strAciklama2,tblINTERNET_Aktiviteler.strAciklama3,tblINTERNET_Aktiviteler.strAciklama4,[mnTahSabitBedel],[mnYegSabitBedel],[mnTahHedefCiro],[mnYegHedefCiro],[mnAktiviteKarZarar],[flAktiviteKarZararYuzde] " +
                    "FROM tblINTERNET_Aktiviteler " +
                    "INNER JOIN tblINTERNET_Musteriler ON tblINTERNET_Aktiviteler.intMusteriID = tblINTERNET_Musteriler.pkMusteriID LEFT OUTER JOIN [Web-Musteri-TP] AS WebMusteriTP ON tblINTERNET_Aktiviteler.SMREF = WebMusteriTP.SMREF " +
                    "WHERE tblINTERNET_Aktiviteler.dtOlusmaTarihi >= @BaslangicTarih AND " +
                    "tblINTERNET_Aktiviteler.dtOlusmaTarihi <= @BitisTarih " + fiyattipi + " AND ("
                    + smrefs +
                    ")" + onayli + " ORDER BY tblINTERNET_Aktiviteler.pkID DESC", conn);
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
        #endregion
        //
        //
        #endregion
        //
        //
        public static void DoDelete(int ID)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_INTERNET_AktiviteSil", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkID", SqlDbType.Int).Value = ID;
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
        public static void DoDeleteWithAktivitelerDetays(int ID)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_INTERNET_AktiviteSilAktiviteDetaylariyla", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkID", SqlDbType.Int).Value = ID;
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
        public static int GetAktiviteCount(DateTime BaslangicTarih, DateTime BitisTarih, object Onayli, bool Hepsi)
        {
            int donendeger = 0;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_INTERNET_AktivitelerCountByDate", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@BaslangicTarih", SqlDbType.SmallDateTime).Value = BaslangicTarih;
                cmd.Parameters.Add("@BitisTarih", SqlDbType.SmallDateTime).Value = BitisTarih;
                cmd.Parameters.Add("@blAktarilmis", SqlDbType.Bit).Value = Onayli;
                cmd.Parameters.Add("@blHepsi", SqlDbType.Bit).Value = Hepsi;
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
        public static void GetObjects(DataTable dt, DateTime BaslangicTarih, DateTime BitisTarih, int Baslangic, int Adet, object Onayli, bool Hepsi, string Kullanici)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_INTERNET_AktivitelerGetirByDate", conn);
                da.SelectCommand.Parameters.Add("@BaslangicTarih", SqlDbType.SmallDateTime).Value = BaslangicTarih;
                da.SelectCommand.Parameters.Add("@BitisTarih", SqlDbType.SmallDateTime).Value = BitisTarih;
                da.SelectCommand.Parameters.Add("@blAktarilmis", SqlDbType.Bit).Value = Onayli;
                da.SelectCommand.Parameters.Add("@blHepsi", SqlDbType.Bit).Value = Hepsi;
                da.SelectCommand.Parameters.Add("@Kullanici", SqlDbType.NVarChar, 50).Value = Kullanici;
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
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
        public static Aktiviteler GetObject(int ID)
        {
            Aktiviteler aktivite = null;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_INTERNET_AktiviteGetirByID", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkID", SqlDbType.Int).Value = ID;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        aktivite = new Aktiviteler(Convert.ToInt32(dr[0]), Convert.ToInt32(dr[1]), Convert.ToInt32(dr[2]),
                            Convert.ToInt16(dr[3]), Convert.ToInt32(dr[4]), Convert.ToInt32(dr[5]), Convert.ToDateTime(dr[6]),
                            Convert.ToDateTime(dr[7]), dr[8] != DBNull.Value ? Convert.ToBoolean(dr[8]) : false, Convert.ToDateTime(dr[9]), 
                            Convert.ToDateTime(dr[10]),
                            dr[11].ToString(), dr[12].ToString(), dr[13].ToString(), dr[14].ToString(), Convert.ToDecimal(dr[15]),
                            Convert.ToDecimal(dr[16]), Convert.ToDecimal(dr[17]), Convert.ToDecimal(dr[18]), Convert.ToDecimal(dr[19]),
                            Convert.ToDouble(dr[20]));
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

            return aktivite;
        }
        //
        //
        public static void GetObjectsBySMREF(DataTable dt, int SMREF)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_INTERNET_AktivitelerGetirBySMREF", conn);
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
        public static int GetTarihAraligiKacAktivite(int SMREF, DateTime Tarih)
        {
            int donendeger = 0;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT count(pkID) FROM tblINTERNET_Aktiviteler WHERE SMREF = @SMREF AND dtAktiviteBaslangic <= @Tarih AND dtAktiviteBitis >= @Tarih ORDER BY pkID DESC", conn);
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
        public static int GetTarihAraligiAktiviteID(int SMREF, DateTime Tarih)
        {
            int donendeger = 0;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT TOP 1 pkID FROM tblINTERNET_Aktiviteler WHERE SMREF = @SMREF AND dtAktiviteBaslangic <= @Tarih AND dtAktiviteBitis >= @Tarih ORDER BY pkID DESC", conn);
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
        public static int GetSonAktiviteID(int SMREF)
        {
            int donendeger = 0;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT TOP 1 pkID FROM tblINTERNET_Aktiviteler WHERE SMREF = @SMREF AND blAktarilmis = 'True' ORDER BY pkID DESC", conn);
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
        //
        //
        public static int GetSonOnaylanmamisAktiviteID(int SMREF)
        {
            int donendeger = 0;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT TOP 1 pkID FROM tblINTERNET_Aktiviteler WHERE SMREF = @SMREF AND blAktarilmis = 'False' ORDER BY pkID DESC", conn);
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
        //
        //
        public static int GetAktiviteCountByAnlasmaID(int AnlasmaID)
        {
            int donendeger = 0;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT count(pkID) FROM tblINTERNET_Aktiviteler WHERE intAnlasmaID = @intAnlasmaID", conn);
                cmd.Parameters.Add("@intAnlasmaID", SqlDbType.Int).Value = AnlasmaID;
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
        public static void FiyatKontrolEkle(int ITEMREF, double FIYAT, int YIL, int AY, int MUDUR)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd1 = new SqlCommand("SELECT count(*) FROM [Web-Fiyat-Aktivite-Kontrol] WHERE YIL = @YIL AND AY = @AY AND ITEMREF = @ITEMREF AND MUDUR = @MUDUR", conn);
                cmd1.Parameters.Add("@ITEMREF", SqlDbType.Int).Value = ITEMREF;
                cmd1.Parameters.Add("@YIL", SqlDbType.Int).Value = YIL;
                cmd1.Parameters.Add("@AY", SqlDbType.Int).Value = AY;
                cmd1.Parameters.Add("@MUDUR", SqlDbType.Int).Value = MUDUR;

                SqlCommand cmd = new SqlCommand("INSERT INTO [Web-Fiyat-Aktivite-Kontrol] (ITEMREF,FIYAT,YIL,AY,MUDUR) VALUES (@ITEMREF,@FIYAT,@YIL,@AY,@MUDUR)", conn);
                cmd.Parameters.Add("@ITEMREF", SqlDbType.Int).Value = ITEMREF;
                cmd.Parameters.Add("@FIYAT", SqlDbType.Float).Value = FIYAT;
                cmd.Parameters.Add("@YIL", SqlDbType.Int).Value = YIL;
                cmd.Parameters.Add("@AY", SqlDbType.Int).Value = AY;
                cmd.Parameters.Add("@MUDUR", SqlDbType.Int).Value = MUDUR;
                try
                {
                    conn.Open();
                    bool varmi = Convert.ToBoolean(cmd1.ExecuteScalar());
                    if (varmi)
                        cmd.CommandText = "UPDATE [Web-Fiyat-Aktivite-Kontrol] SET FIYAT = @FIYAT WHERE YIL = @YIL AND AY = @AY AND ITEMREF = @ITEMREF AND MUDUR = @MUDUR";
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

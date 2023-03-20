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
    public class Iadeler : ISultanlar, IDisposable
    {
        //
        //
        //
        // Alanlar:
        //
        private int _pkIadeID;
        private int _intMusteriID;
        private int _SMREF;
        private DateTime _dtOlusmaTarihi;
        private decimal _mnToplamTutar;
        private bool _blAktarilmis;
        private DateTime _dtOnaylamaTarihi;
        private string _strAciklama;
        //
        //
        //
        // Constracter lar:
        //
        private Iadeler(int pkIadeID, int intMusteriID, int SMREF, DateTime dtOlusmaTarihi,
            decimal mnToplamTutar, bool blAktarilmis, DateTime dtOnaylamaTarihi, string strAciklama)
        {
            this._pkIadeID = pkIadeID;
            this._intMusteriID = intMusteriID;
            this._SMREF = SMREF;
            this._dtOlusmaTarihi = dtOlusmaTarihi;
            this._mnToplamTutar = mnToplamTutar;
            this._blAktarilmis = blAktarilmis;
            this._dtOnaylamaTarihi = dtOnaylamaTarihi;
            this._strAciklama = strAciklama;
        }
        //
        //
        public Iadeler(int intMusteriID, int SMREF, DateTime dtOlusmaTarihi, decimal mnToplamTutar,
            bool blAktarilmis, DateTime dtOnaylamaTarihi, string strAciklama)
        {
            this._intMusteriID = intMusteriID;
            this._SMREF = SMREF;
            this._dtOlusmaTarihi = dtOlusmaTarihi;
            this._mnToplamTutar = mnToplamTutar;
            this._blAktarilmis = blAktarilmis;
            this._dtOnaylamaTarihi = dtOnaylamaTarihi;
            this._strAciklama = strAciklama;
        }
        //
        //
        //
        // Özellikler:
        //
        public int pkIadeID { get { return this._pkIadeID; } }
        public int intMusteriID { get { return this._intMusteriID; } set { this._intMusteriID = value; } }
        public int SMREF { get { return this._SMREF; } set { this._SMREF = value; } }
        public DateTime dtOlusmaTarihi { get { return this._dtOlusmaTarihi; } set { this._dtOlusmaTarihi = value; } }
        public decimal mnToplamTutar { get { return this._mnToplamTutar; } set { this._mnToplamTutar = value; } }
        public bool blAktarilmis { get { return this._blAktarilmis; } set { this._blAktarilmis = value; } }
        public DateTime dtOnaylamaTarihi { get { return this._dtOnaylamaTarihi; } set { this._dtOnaylamaTarihi = value; } }
        public string strAciklama { get { return this._strAciklama; } set { this._strAciklama = value; } }
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
            return this._pkIadeID.ToString();
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
                SqlCommand cmd = new SqlCommand("sp_INTERNET_IadeEkle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@intMusteriID", SqlDbType.Int).Value = this._intMusteriID;
                cmd.Parameters.Add("@SMREF", SqlDbType.Int).Value = this._SMREF;
                cmd.Parameters.Add("@dtOlusmaTarihi", SqlDbType.SmallDateTime).Value = this._dtOlusmaTarihi;
                cmd.Parameters.Add("@mnToplamTutar", SqlDbType.Money).Value = this._mnToplamTutar;
                cmd.Parameters.Add("@blAktarilmis", SqlDbType.Bit).Value = this._blAktarilmis;
                cmd.Parameters.Add("@dtOnaylamaTarihi", SqlDbType.SmallDateTime).Value = this._dtOlusmaTarihi;              ////////
                cmd.Parameters.Add("@strAciklama", SqlDbType.NVarChar).Value = this._strAciklama;
                cmd.Parameters.Add("@pkIadeID", SqlDbType.Int).Direction = ParameterDirection.Output;
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    this._pkIadeID = Convert.ToInt32(cmd.Parameters["@pkIadeID"].Value);
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
            object OnaylamaTarihi = _dtOlusmaTarihi;
            if (_dtOlusmaTarihi != _dtOnaylamaTarihi)
                OnaylamaTarihi = _dtOnaylamaTarihi;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_INTERNET_IadeGuncelle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkIadeID", SqlDbType.Int).Value = this._pkIadeID;
                cmd.Parameters.Add("@intMusteriID", SqlDbType.Int).Value = this._intMusteriID;
                cmd.Parameters.Add("@SMREF", SqlDbType.Int).Value = this._SMREF;
                cmd.Parameters.Add("@dtOlusmaTarihi", SqlDbType.SmallDateTime).Value = this._dtOlusmaTarihi;
                cmd.Parameters.Add("@mnToplamTutar", SqlDbType.Money).Value = this._mnToplamTutar;
                cmd.Parameters.Add("@blAktarilmis", SqlDbType.Bit).Value = this._blAktarilmis;
                cmd.Parameters.Add("@dtOnaylamaTarihi", SqlDbType.SmallDateTime).Value = OnaylamaTarihi;
                cmd.Parameters.Add("@strAciklama", SqlDbType.NVarChar).Value = this._strAciklama;
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
                SqlCommand cmd = new SqlCommand("sp_INTERNET_IadeSil", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkIadeID", SqlDbType.Int).Value = this._pkIadeID;
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
        public static void DoDelete(int IadeID)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_INTERNET_IadeSil", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkIadeID", SqlDbType.Int).Value = IadeID;
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
        public static void DoDeleteWithIadelerDetays(int IadeID)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_INTERNET_IadeSilIadeDetaylariyla", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkIadeID", SqlDbType.Int).Value = IadeID;
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
        public static int GetIadeCount(DateTime BaslangicTarih, DateTime BitisTarih, int Onayli)
        {
            int donendeger = 0;

            string suzme = string.Empty;
            if (Onayli == 1)
                suzme = " AND (mnToplamTutar = 0 AND blAktarilmis = 'False')";
            else if (Onayli == 2)
                suzme = " AND (mnToplamTutar = 0 AND blAktarilmis = 'True')";
            else if (Onayli == 3)
                suzme = " AND (mnToplamTutar > 0 AND blAktarilmis = 'True')";
            else if (Onayli == 4)
                suzme = " AND (mnToplamTutar > 0 AND blAktarilmis = 'False')";
            else if (Onayli == 5)
                suzme = " AND mnToplamTutar = -1";
            else if (Onayli == 6)
                suzme = " AND mnToplamTutar = -2";

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT count(pkIadeID) FROM tblINTERNET_Iadeler WHERE tblINTERNET_Iadeler.dtOlusmaTarihi >= @BaslangicTarih AND tblINTERNET_Iadeler.dtOlusmaTarihi <= @BitisTarih" + suzme, conn);
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
        public static void GetObjects(DataTable dt, DateTime BaslangicTarih, DateTime BitisTarih, int Baslangic, int Adet, int Onayli)
        {
            string suzme = string.Empty;
            if (Onayli == 1)
                suzme = " AND (mnToplamTutar = 0 AND blAktarilmis = 'False')";
            else if (Onayli == 2)
                suzme = " AND (mnToplamTutar = 0 AND blAktarilmis = 'True')";
            else if (Onayli == 3)
                suzme = " AND (mnToplamTutar > 0 AND blAktarilmis = 'True')";
            else if (Onayli == 4)
                suzme = " AND (mnToplamTutar > 0 AND blAktarilmis = 'False')";
            else if (Onayli == 5)
                suzme = " AND mnToplamTutar = -1";
            else if (Onayli == 6)
                suzme = " AND mnToplamTutar = -2";

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT tblINTERNET_Iadeler.pkIadeID, tblINTERNET_Iadeler.intMusteriID,tblINTERNET_Musteriler.strAd, tblINTERNET_Musteriler.strSoyad,tblINTERNET_Iadeler.SMREF,tblINTERNET_Iadeler.dtOlusmaTarihi, tblINTERNET_Iadeler.mnToplamTutar,tblINTERNET_Iadeler.blAktarilmis,tblINTERNET_Iadeler.dtOnaylamaTarihi,tblINTERNET_Iadeler.strAciklama FROM tblINTERNET_Iadeler INNER JOIN tblINTERNET_Musteriler ON tblINTERNET_Iadeler.intMusteriID = tblINTERNET_Musteriler.pkMusteriID WHERE tblINTERNET_Iadeler.dtOlusmaTarihi >= @BaslangicTarih AND tblINTERNET_Iadeler.dtOlusmaTarihi <= @BitisTarih" + suzme + " ORDER BY tblINTERNET_Iadeler.pkIadeID DESC", conn);
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

            dt.Columns.Add("MUSTERI", typeof(string));
            for (int i = 0; i < dt.Rows.Count; i++)
                if (Convert.ToInt32(dt.Rows[i]["SMREF"]) != 0)
                    dt.Rows[i]["MUSTERI"] = CariHesaplar.GetMUSTERIbySMREFmusterisube(Convert.ToInt32(dt.Rows[i]["SMREF"]));
        }
        //
        //
        public static void GetObjectsBySMREF(DataTable dt, int SMREF)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_INTERNET_IadelerGetirBySMREF", conn);
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

                dt.Columns.Add("MUSTERI", typeof(string));
                for (int i = 0; i < dt.Rows.Count; i++)
                    if (Convert.ToInt32(dt.Rows[i]["SMREF"]) != 0)
                        dt.Rows[i]["MUSTERI"] = CariHesaplar.GetMUSTERIbySMREF(Convert.ToInt32(dt.Rows[i]["SMREF"]));
            }
        }
        //
        //
        public static void GetObjectsByMusteriID(IList List, int MusteriID, bool UI)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                List.Clear();

                SqlCommand cmd = new SqlCommand("sp_INTERNET_IadelerGetirByMusteriID", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@intMusteriID", SqlDbType.Int).Value = MusteriID;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        List.Add(new Iadeler(Convert.ToInt32(dr[0]), Convert.ToInt32(dr[1]), Convert.ToInt32(dr[2]),
                            Convert.ToDateTime(dr[3]), Convert.ToDecimal(dr[4]), Convert.ToBoolean(dr[5]), 
                            Convert.ToDateTime(dr[6]), dr[7].ToString()));
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
        public static void GetObjectsByMusteriID(DataTable dt, int MusteriID)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_INTERNET_IadelerGetirByMusteriID", conn);
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

                dt.Columns.Add("MUSTERI", typeof(string));
                for (int i = 0; i < dt.Rows.Count; i++)
                    if (Convert.ToInt32(dt.Rows[i]["SMREF"]) != 0)
                        dt.Rows[i]["MUSTERI"] = CariHesaplar.GetMUSTERIbySMREF(Convert.ToInt32(dt.Rows[i]["SMREF"]));
            }
        }
        //
        //
        #region GetIadeCountByMusteriID
        public static int GetIadeCountByMusteriID(int MusteriID, DateTime BaslangicTarih, DateTime BitisTarih, int Onayli)
        {
            int donendeger = 0;

            string suzme = string.Empty;
            if (Onayli == 1)
                suzme = " AND (mnToplamTutar = 0 AND blAktarilmis = 'False')";
            else if (Onayli == 2)
                suzme = " AND (mnToplamTutar = 0 AND blAktarilmis = 'True')";
            else if (Onayli == 3)
                suzme = " AND (mnToplamTutar > 0 AND blAktarilmis = 'True')";
            else if (Onayli == 4)
                suzme = " AND (mnToplamTutar > 0 AND blAktarilmis = 'False')";
            else if (Onayli == 5)
                suzme = " AND mnToplamTutar = -1";
            else if (Onayli == 6)
                suzme = " AND mnToplamTutar = -2";

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT count(pkIadeID) FROM tblINTERNET_Iadeler WHERE intMusteriID = @intMusteriID AND tblINTERNET_Iadeler.dtOlusmaTarihi >= @BaslangicTarih AND tblINTERNET_Iadeler.dtOlusmaTarihi <= @BitisTarih" + suzme, conn);
                cmd.Parameters.Add("@intMusteriID", SqlDbType.Int).Value = MusteriID;
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
        #region GetObjectsByMusteriID
        public static void GetObjectsByMusteriID(DataTable dt, int MusteriID, DateTime BaslangicTarih, DateTime BitisTarih, int Baslangic, int Adet, int Onayli)
        {
            string suzme = string.Empty;
            if (Onayli == 1)
                suzme = " AND (mnToplamTutar = 0 AND blAktarilmis = 'False')";
            else if (Onayli == 2)
                suzme = " AND (mnToplamTutar = 0 AND blAktarilmis = 'True')";
            else if (Onayli == 3)
                suzme = " AND (mnToplamTutar > 0 AND blAktarilmis = 'True')";
            else if (Onayli == 4)
                suzme = " AND (mnToplamTutar > 0 AND blAktarilmis = 'False')";
            else if (Onayli == 5)
                suzme = " AND mnToplamTutar = -1";
            else if (Onayli == 6)
                suzme = " AND mnToplamTutar = -2";

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT tblINTERNET_Iadeler.pkIadeID, tblINTERNET_Iadeler.intMusteriID,tblINTERNET_Musteriler.strAd, tblINTERNET_Musteriler.strSoyad,tblINTERNET_Iadeler.SMREF,tblINTERNET_Iadeler.dtOlusmaTarihi, tblINTERNET_Iadeler.mnToplamTutar,tblINTERNET_Iadeler.blAktarilmis,tblINTERNET_Iadeler.dtOnaylamaTarihi, tblINTERNET_Iadeler.strAciklama FROM tblINTERNET_Iadeler INNER JOIN tblINTERNET_Musteriler ON tblINTERNET_Iadeler.intMusteriID = tblINTERNET_Musteriler.pkMusteriID WHERE tblINTERNET_Iadeler.intMusteriID = @intMusteriID AND tblINTERNET_Iadeler.dtOlusmaTarihi >= @BaslangicTarih AND tblINTERNET_Iadeler.dtOlusmaTarihi <= @BitisTarih" + suzme + " ORDER BY tblINTERNET_Iadeler.pkIadeID DESC", conn);
                da.SelectCommand.Parameters.Add("@intMusteriID", SqlDbType.Int).Value = MusteriID;
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

                dt.Columns.Add("MUSTERI", typeof(string));
                for (int i = 0; i < dt.Rows.Count; i++)
                    if (Convert.ToInt32(dt.Rows[i]["SMREF"]) != 0)
                        dt.Rows[i]["MUSTERI"] = CariHesaplar.GetMUSTERIbySMREF(Convert.ToInt32(dt.Rows[i]["SMREF"]));
            }
        }
        #endregion
        //
        //
        public static void GetObjectsByMusteriID(DataTable dt, int MusteriID, bool HesabaGore)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_INTERNET_IadelerGetirByMusteriID_OrderBySMREF", conn);
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

                dt.Columns.Add("MUSTERI", typeof(string));
                for (int i = 0; i < dt.Rows.Count; i++)
                    if (Convert.ToInt32(dt.Rows[i]["SMREF"]) != 0)
                        dt.Rows[i]["MUSTERI"] = CariHesaplar.GetMUSTERIbySMREF(Convert.ToInt32(dt.Rows[i]["SMREF"]));
            }
        }
        //
        //
        #region GetIadeCountBySMREF
        public static int GetIadeCountBySMREF(int SMREF, DateTime BaslangicTarih, DateTime BitisTarih, int Onayli)
        {
            int donendeger = 0;

            string suzme = string.Empty;
            if (Onayli == 1)
                suzme = " AND (mnToplamTutar = 0 AND blAktarilmis = 'False')";
            else if (Onayli == 2)
                suzme = " AND (mnToplamTutar = 0 AND blAktarilmis = 'True')";
            else if (Onayli == 3)
                suzme = " AND (mnToplamTutar > 0 AND blAktarilmis = 'True')";
            else if (Onayli == 4)
                suzme = " AND (mnToplamTutar > 0 AND blAktarilmis = 'False')";
            else if (Onayli == 5)
                suzme = " AND mnToplamTutar = -1";
            else if (Onayli == 6)
                suzme = " AND mnToplamTutar = -2";

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT count(pkIadeID) FROM tblINTERNET_Iadeler WHERE SMREF = @SMREF AND tblINTERNET_Iadeler.dtOlusmaTarihi >= @BaslangicTarih AND tblINTERNET_Iadeler.dtOlusmaTarihi <= @BitisTarih" + suzme, conn);
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
        public static void GetObjectsBySMREF(DataTable dt, int SMREF, DateTime BaslangicTarih, DateTime BitisTarih, int Baslangic, int Adet, int Onayli)
        {
            string suzme = string.Empty;
            if (Onayli == 1)
                suzme = " AND (mnToplamTutar = 0 AND blAktarilmis = 'False')";
            else if (Onayli == 2)
                suzme = " AND (mnToplamTutar = 0 AND blAktarilmis = 'True')";
            else if (Onayli == 3)
                suzme = " AND (mnToplamTutar > 0 AND blAktarilmis = 'True')";
            else if (Onayli == 4)
                suzme = " AND (mnToplamTutar > 0 AND blAktarilmis = 'False')";
            else if (Onayli == 5)
                suzme = " AND mnToplamTutar = -1";
            else if (Onayli == 6)
                suzme = " AND mnToplamTutar = -2";

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT tblINTERNET_Iadeler.pkIadeID, tblINTERNET_Iadeler.intMusteriID,tblINTERNET_Musteriler.strAd, tblINTERNET_Musteriler.strSoyad,tblINTERNET_Iadeler.SMREF,tblINTERNET_Iadeler.dtOlusmaTarihi, tblINTERNET_Iadeler.mnToplamTutar,tblINTERNET_Iadeler.blAktarilmis,tblINTERNET_Iadeler.dtOnaylamaTarihi,tblINTERNET_Iadeler.strAciklama FROM tblINTERNET_Iadeler INNER JOIN tblINTERNET_Musteriler ON tblINTERNET_Iadeler.intMusteriID = tblINTERNET_Musteriler.pkMusteriID WHERE tblINTERNET_Iadeler.dtOlusmaTarihi >= @BaslangicTarih AND tblINTERNET_Iadeler.dtOlusmaTarihi <= @BitisTarih AND tblINTERNET_Iadeler.SMREF = @SMREF" + suzme + " ORDER BY tblINTERNET_Iadeler.pkIadeID DESC", conn);
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

                dt.Columns.Add("MUSTERI", typeof(string));
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (Convert.ToInt32(dt.Rows[i]["SMREF"]) != 0)
                    {
                        if (CariHesaplar.GetGMREFBySMREF(Convert.ToInt32(dt.Rows[i]["SMREF"])) ==
                            Convert.ToInt32(dt.Rows[i]["SMREF"])) // bir ana carinin subesi mi yoksa tek cari mi bakmak icin
                            dt.Rows[i]["MUSTERI"] = CariHesaplar.GetMUSTERIbySMREF(Convert.ToInt32(dt.Rows[i]["SMREF"]));
                        else
                            dt.Rows[i]["MUSTERI"] = CariHesaplar.GetSUBEbySMREF(Convert.ToInt32(dt.Rows[i]["SMREF"]));
                    }
                }
            }
        }
        #endregion
        //
        //
        #region GetIadeCountBySMREFs
        public static int GetIadeCountBySMREFs(ArrayList SMREF, DateTime BaslangicTarih, DateTime BitisTarih, int Onayli)
        {
            int donendeger = 0;

            string smrefs = string.Empty;
            for (int i = 0; i < SMREF.Count; i++)
                smrefs += "tblINTERNET_Iadeler.SMREF = " + SMREF[i].ToString() + " OR ";
            smrefs = smrefs.Substring(0, smrefs.Length - 3);

            string suzme = string.Empty;
            if (Onayli == 1)
                suzme = " AND (mnToplamTutar = 0 AND blAktarilmis = 'False')";
            else if (Onayli == 2)
                suzme = " AND (mnToplamTutar = 0 AND blAktarilmis = 'True')";
            else if (Onayli == 3)
                suzme = " AND (mnToplamTutar > 0 AND blAktarilmis = 'True')";
            else if (Onayli == 4)
                suzme = " AND (mnToplamTutar > 0 AND blAktarilmis = 'False')";
            else if (Onayli == 5)
                suzme = " AND mnToplamTutar = -1";
            else if (Onayli == 6)
                suzme = " AND mnToplamTutar = -2";

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT count(pkIadeID) FROM tblINTERNET_Iadeler " +
                    "WHERE tblINTERNET_Iadeler.dtOlusmaTarihi >= @BaslangicTarih AND " +
                    "tblINTERNET_Iadeler.dtOlusmaTarihi <= @BitisTarih AND (" + smrefs + ")" + suzme, conn);
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
        public static void GetObjectsBySMREFs(DataTable dt, ArrayList SMREF, DateTime BaslangicTarih, DateTime BitisTarih, int Baslangic, int Adet, int Onayli)
        {
            string smrefs = string.Empty;
            for (int i = 0; i < SMREF.Count; i++)
                smrefs += "tblINTERNET_Iadeler.SMREF = " + SMREF[i].ToString() + " OR ";
            smrefs = smrefs.Substring(0, smrefs.Length - 3);

            string suzme = string.Empty;
            if (Onayli == 1)
                suzme = " AND (mnToplamTutar = 0 AND blAktarilmis = 'False')";
            else if (Onayli == 2)
                suzme = " AND (mnToplamTutar = 0 AND blAktarilmis = 'True')";
            else if (Onayli == 3)
                suzme = " AND (mnToplamTutar > 0 AND blAktarilmis = 'True')";
            else if (Onayli == 4)
                suzme = " AND (mnToplamTutar > 0 AND blAktarilmis = 'False')";
            else if (Onayli == 5)
                suzme = " AND mnToplamTutar = -1";
            else if (Onayli == 6)
                suzme = " AND mnToplamTutar = -2";

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT tblINTERNET_Iadeler.pkIadeID, tblINTERNET_Iadeler.intMusteriID, tblINTERNET_Musteriler.strAd, tblINTERNET_Musteriler.strSoyad,tblINTERNET_Iadeler.SMREF, tblINTERNET_Iadeler.dtOlusmaTarihi, tblINTERNET_Iadeler.mnToplamTutar, tblINTERNET_Iadeler.blAktarilmis, tblINTERNET_Iadeler.dtOnaylamaTarihi, tblINTERNET_Iadeler.strAciklama FROM tblINTERNET_Iadeler INNER JOIN tblINTERNET_Musteriler ON tblINTERNET_Iadeler.intMusteriID = tblINTERNET_Musteriler.pkMusteriID " +
                    "WHERE tblINTERNET_Iadeler.dtOlusmaTarihi >= @BaslangicTarih AND " +
                    "tblINTERNET_Iadeler.dtOlusmaTarihi <= @BitisTarih AND (" 
                    + smrefs +
                    ")" + suzme + " ORDER BY tblINTERNET_Iadeler.pkIadeID DESC", conn);
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

                dt.Columns.Add("MUSTERI", typeof(string));
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (Convert.ToInt32(dt.Rows[i]["SMREF"]) != 0)
                    {
                        if (CariHesaplar.GetGMREFBySMREF(Convert.ToInt32(dt.Rows[i]["SMREF"])) ==
                            Convert.ToInt32(dt.Rows[i]["SMREF"])) // bir ana carinin subesi mi yoksa tek cari mi bakmak icin
                            dt.Rows[i]["MUSTERI"] = CariHesaplar.GetMUSTERIbySMREF(Convert.ToInt32(dt.Rows[i]["SMREF"]));
                        else
                            dt.Rows[i]["MUSTERI"] = CariHesaplar.GetSUBEbySMREF(Convert.ToInt32(dt.Rows[i]["SMREF"]));
                    }
                }
            }
        }
        #endregion
        //
        //
        public static Iadeler GetObjectsByIadeID(int IadeID)
        {
            Iadeler Iade = null;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_INTERNET_IadeGetirByIadeID", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkIadeID", SqlDbType.Int).Value = IadeID;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        Iade = new Iadeler(Convert.ToInt32(dr[0]), Convert.ToInt32(dr[1]), Convert.ToInt32(dr[2]),
                            Convert.ToDateTime(dr[3]), Convert.ToDecimal(dr[4]), Convert.ToBoolean(dr[5]),
                            Convert.ToDateTime(dr[6]), dr[7].ToString());
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

            return Iade;
        }
        //
        //
        public static void GetObjectsVW(DataTable dt/*, DateTime BaslangicTarih, DateTime BitisTarih, int Baslangic, int Adet, object Onayli*/)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_INTERNET_IadelerGetirVW", conn);
                //da.SelectCommand.Parameters.Add("@BaslangicTarih", SqlDbType.SmallDateTime).Value = BaslangicTarih;
                //da.SelectCommand.Parameters.Add("@BitisTarih", SqlDbType.SmallDateTime).Value = BitisTarih;
                //da.SelectCommand.Parameters.Add("@blAktarilmis", SqlDbType.Bit).Value = Onayli;
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

            dt.Columns.Add("strAciklama2", typeof(string));
            dt.Columns.Add("strAciklama3", typeof(string));
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string[] Aciklamalar = dt.Rows[i]["strAciklama"].ToString().Split(new string[] { ";;;" }, StringSplitOptions.None);
                dt.Rows[i]["strAciklama2"] = Aciklamalar[1];
                dt.Rows[i]["strAciklama3"] = Aciklamalar[2];
            }
            dt.Columns.Remove("strAciklama");
        }
        //
        //
        public static void GetSevkBilgileri(DataTable dt, int IadeID)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT pkID,strSofor,strMuavin,dtTarihGidis,dtTarihGelis,strAciklama FROM tblINTERNET_IadelerSevk WHERE intIadeID = @intIadeID ORDER BY pkID DESC", conn);
                da.SelectCommand.Parameters.Add("@intIadeID", SqlDbType.Int).Value = IadeID;
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
        public static void DoDeleteSevkBilgisi(int ID)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM tblINTERNET_IadelerSevk WHERE pkID = @pkID", conn);
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
        public static void DoInsertSevkBilgisi(int IadeID, string Sofor, string Muavin, DateTime Gidis)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO tblINTERNET_IadelerSevk (intIadeID,strSofor,strMuavin,dtTarihGidis,strAciklama) VALUES (@intIadeID,@strSofor,@strMuavin,@dtTarihGidis,'')", conn);
                cmd.Parameters.Add("@intIadeID", SqlDbType.Int).Value = IadeID;
                cmd.Parameters.Add("@strSofor", SqlDbType.NVarChar).Value = Sofor;
                cmd.Parameters.Add("@strMuavin", SqlDbType.NVarChar).Value = Muavin;
                cmd.Parameters.Add("@dtTarihGidis", SqlDbType.DateTime).Value = Gidis;
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
        public static void DoUpdateSevkBilgisi(int ID, string Sofor, string Muavin, DateTime Gidis)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UPDATE tblINTERNET_IadelerSevk SET strSofor = @strSofor, strMuavin = @strMuavin, dtTarihGidis = @dtTarihGidis WHERE pkID = @pkID", conn);
                cmd.Parameters.Add("@strSofor", SqlDbType.NVarChar).Value = Sofor;
                cmd.Parameters.Add("@strMuavin", SqlDbType.NVarChar).Value = Muavin;
                cmd.Parameters.Add("@dtTarihGidis", SqlDbType.DateTime).Value = Gidis;
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
        public static void DoUpdateSevkBilgisi(int ID, DateTime Gelis)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UPDATE tblINTERNET_IadelerSevk SET dtTarihGelis = @dtTarihGelis WHERE pkID = @pkID", conn);
                cmd.Parameters.Add("@pkID", SqlDbType.Int).Value = ID;
                cmd.Parameters.Add("@dtTarihGelis", SqlDbType.DateTime).Value = Gelis;
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
        public static void DoUpdateSevkBilgisi(int ID, string Aciklama)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UPDATE tblINTERNET_IadelerSevk SET strAciklama = @strAciklama WHERE pkID = @pkID", conn);
                cmd.Parameters.Add("@pkID", SqlDbType.Int).Value = ID;
                cmd.Parameters.Add("@strAciklama", SqlDbType.NVarChar).Value = Aciklama;
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
        /// Satır varsa güncelliyor
        /// </summary>
        public static void DoInsertEk(int IadeID)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd1 = new SqlCommand("SELECT sintBasilma FROM tblINTERNET_IadelerEk WHERE intIadeID = @intIadeID", conn);
                cmd1.Parameters.Add("@intIadeID", SqlDbType.Int).Value = IadeID;

                conn.Open();
                object sayi = cmd1.ExecuteScalar();
                conn.Close();

                SqlCommand cmd = new SqlCommand();
                if (sayi != null)
                {
                    cmd = new SqlCommand("UPDATE tblINTERNET_IadelerEk SET sintBasilma = sintBasilma + 1 WHERE intIadeID = @intIadeID", conn);
                    cmd.Parameters.Add("@intIadeID", SqlDbType.Int).Value = IadeID;
                }
                else
                {
                    cmd = new SqlCommand("INSERT INTO tblINTERNET_IadelerEk (intIadeID,sintBasilma,blCopte,blSayimYapildi) VALUES (@intIadeID,1,'False','False')", conn);
                    cmd.Parameters.Add("@intIadeID", SqlDbType.Int).Value = IadeID;
                }

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
        /// isim yanlış Ek i güncelliyor
        /// </summary>
        public static void DoUpdateSevkBilgisi(int IadeID)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UPDATE tblINTERNET_IadelerEk SET sintBasilma = sintBasilma + 1 WHERE intIadeID = @intIadeID", conn);
                cmd.Parameters.Add("@intIadeID", SqlDbType.Int).Value = IadeID;
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
        /// Satır varsa güncelliyor
        /// </summary>
        public static void DoInsertEkSayimYapildi(int IadeID)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd1 = new SqlCommand("SELECT blSayimYapildi FROM tblINTERNET_IadelerEk WHERE intIadeID = @intIadeID", conn);
                cmd1.Parameters.Add("@intIadeID", SqlDbType.Int).Value = IadeID;

                conn.Open();
                object sayim = cmd1.ExecuteScalar();
                conn.Close();

                SqlCommand cmd = new SqlCommand();
                if (sayim != null)
                {
                    cmd = new SqlCommand("UPDATE tblINTERNET_IadelerEk SET blSayimYapildi = 'True',dtSayimTarihi = getdate() WHERE intIadeID = @intIadeID", conn);
                    cmd.Parameters.Add("@intIadeID", SqlDbType.Int).Value = IadeID;
                }
                else
                {
                    cmd = new SqlCommand("INSERT INTO tblINTERNET_IadelerEk (intIadeID,sintBasilma,blCopte,blSayimYapildi,dtSayimTarihi) VALUES (@intIadeID,0,'False','True',getdate())", conn);
                    cmd.Parameters.Add("@intIadeID", SqlDbType.Int).Value = IadeID;
                }

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
        /// Satır varsa güncelliyor
        /// </summary>
        public static void DoInsertEkSayimYapilmadi(int IadeID)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd1 = new SqlCommand("SELECT blSayimYapildi FROM tblINTERNET_IadelerEk WHERE intIadeID = @intIadeID", conn);
                cmd1.Parameters.Add("@intIadeID", SqlDbType.Int).Value = IadeID;

                conn.Open();
                object sayim = cmd1.ExecuteScalar();
                conn.Close();

                SqlCommand cmd = new SqlCommand();
                if (sayim != null)
                {
                    cmd = new SqlCommand("UPDATE tblINTERNET_IadelerEk SET blSayimYapildi = 'False',dtSayimTarihi = NULL WHERE intIadeID = @intIadeID", conn);
                    cmd.Parameters.Add("@intIadeID", SqlDbType.Int).Value = IadeID;
                }
                else
                {
                    cmd = new SqlCommand("INSERT INTO tblINTERNET_IadelerEk (intIadeID,sintBasilma,blCopte,blSayimYapildi,dtSayimTarihi) VALUES (@intIadeID,0,'False','False',NULL)", conn);
                    cmd.Parameters.Add("@intIadeID", SqlDbType.Int).Value = IadeID;
                }

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
        /// Satır varsa güncelliyor
        /// </summary>
        public static void DoInsertCopeAt(int IadeID)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd1 = new SqlCommand("SELECT blCopte FROM tblINTERNET_IadelerEk WHERE intIadeID = @intIadeID", conn);
                cmd1.Parameters.Add("@intIadeID", SqlDbType.Int).Value = IadeID;

                conn.Open();
                object copte = cmd1.ExecuteScalar();
                conn.Close();

                SqlCommand cmd = new SqlCommand();
                if (copte != null)
                {
                    cmd = new SqlCommand("UPDATE tblINTERNET_IadelerEk SET blCopte = 'True' WHERE intIadeID = @intIadeID", conn);
                    cmd.Parameters.Add("@intIadeID", SqlDbType.Int).Value = IadeID;
                }
                else
                {
                    cmd = new SqlCommand("INSERT INTO tblINTERNET_IadelerEk (intIadeID,sintBasilma,blCopte,blSayimYapildi,dtSayimTarihi) VALUES (@intIadeID,0,'True','False',NULL)", conn);
                    cmd.Parameters.Add("@intIadeID", SqlDbType.Int).Value = IadeID;
                }

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
        public static void DoInsertCoptenAl(int IadeID)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand("UPDATE tblINTERNET_IadelerEk SET blCopte = 'False' WHERE intIadeID = @intIadeID", conn);
                cmd.Parameters.Add("@intIadeID", SqlDbType.Int).Value = IadeID;

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
        /// iadelerde hangi seçenekte kaç satır var
        /// </summary>
        public static string GetIadelerTabsRowCount()
        {
            string donendeger = string.Empty;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT (SELECT count(*) FROM [KurumsalWebSAP].[dbo].[vw_tblINTERNET_Iadeler] WHERE dtOnaylamaTarihi >= '01.01.2014' AND ([blAktarilmis] = 'True' AND [mnToplamTutar] = 0)) AS 'Fiyatlandırılmamış',(SELECT count(*) FROM [KurumsalWebSAP].[dbo].[vw_tblINTERNET_Iadeler] WHERE dtOnaylamaTarihi >= '01.01.2014' AND ([blAktarilmis] = 'True' AND [mnToplamTutar] > 0)) AS 'Fiyatlandırılmış',(SELECT count(*) FROM [KurumsalWebSAP].[dbo].[vw_tblINTERNET_Iadeler] WHERE dtOnaylamaTarihi >= '01.01.2014' AND ([blAktarilmis] = 'False' AND [mnToplamTutar] > 0 AND FATNO IS NULL AND Copte = 'False' AND strAciklama NOT LIKE '%-IADE MERKEZDEN GIRILDI')) AS 'Sevk Bekleyen Tümü',(SELECT count(*) FROM [KurumsalWebSAP].[dbo].[vw_tblINTERNET_Iadeler] WHERE dtOnaylamaTarihi >= '01.01.2014' AND ([blAktarilmis] = 'False' AND [mnToplamTutar] > 0 AND FATNO IS NULL AND Copte = 'False' AND strAciklama NOT LIKE '%-IADE MERKEZDEN GIRILDI' AND (SELECT count(pkID) FROM tblINTERNET_IadelerSevk WHERE intIadeID = [vw_tblINTERNET_Iadeler].[pkIadeID]) = 0)) AS 'Sevk Bekleyen Araca Verilecek',(SELECT count(*) FROM [KurumsalWebSAP].[dbo].[vw_tblINTERNET_Iadeler] WHERE dtOnaylamaTarihi >= '01.01.2014' AND ([blAktarilmis] = 'False' AND [mnToplamTutar] > 0 AND FATNO IS NULL AND Copte = 'False' AND strAciklama NOT LIKE '%-IADE MERKEZDEN GIRILDI'  AND (SELECT TOP 1 CASE WHEN dtTarihGelis IS NOT NULL THEN 0 ELSE 1 END FROM tblINTERNET_IadelerSevk WHERE intIadeID = [vw_tblINTERNET_Iadeler].[pkIadeID] ORDER BY pkID DESC) > 0)) AS 'Sevk Bekleyen Araçta',(SELECT count(*) FROM [KurumsalWebSAP].[dbo].[vw_tblINTERNET_Iadeler] WHERE dtOnaylamaTarihi >= '01.01.2014' AND ([blAktarilmis] = 'False' AND [mnToplamTutar] > 0 AND FATNO IS NULL AND Copte = 'False' AND strAciklama NOT LIKE '%-IADE MERKEZDEN GIRILDI' AND (SELECT TOP 1 CASE WHEN dtTarihGelis IS NULL THEN 0 ELSE 1 END FROM tblINTERNET_IadelerSevk WHERE intIadeID = [vw_tblINTERNET_Iadeler].[pkIadeID] ORDER BY pkID DESC) > 0)) AS 'Sevkten Gelen',(SELECT count(*) FROM [KurumsalWebSAP].[dbo].[vw_tblINTERNET_Iadeler] WHERE dtOnaylamaTarihi >= '01.01.2014' AND ([blAktarilmis] = 'False' AND [mnToplamTutar] > 0 AND FATNO IS NULL AND strAciklama LIKE '%-IADE MERKEZDEN GIRILDI')) AS 'İade Girilen',(SELECT count(*) FROM [KurumsalWebSAP].[dbo].[vw_tblINTERNET_Iadeler] WHERE dtOnaylamaTarihi >= '01.01.2014' AND ([blAktarilmis] = 'False' AND [mnToplamTutar] > 0 AND FATNO IS NOT NULL AND (SELECT TOP 1 strAciklama FROM tblINTERNET_IadeHareketleri WHERE intIadeHareketTurID = 21 AND intIadeID = vw_tblINTERNET_Iadeler.pkIadeID ORDER BY pkID DESC) IS NULL)) AS 'İade Kabul',(SELECT count(*) FROM [KurumsalWebSAP].[dbo].[vw_tblINTERNET_Iadeler] WHERE dtOnaylamaTarihi >= '01.01.2014' AND ([blAktarilmis] = 'False' AND [mnToplamTutar] > 0 AND FATNO IS NOT NULL AND (SELECT TOP 1 strAciklama FROM tblINTERNET_IadeHareketleri WHERE intIadeHareketTurID = 21 AND intIadeID = vw_tblINTERNET_Iadeler.pkIadeID ORDER BY pkID DESC) LIKE 'Sat.Op. - %')) AS 'Sat.Op.',(SELECT count(*) FROM [KurumsalWebSAP].[dbo].[vw_tblINTERNET_Iadeler] WHERE dtOnaylamaTarihi >= '01.01.2014' AND ([blAktarilmis] = 'False' AND [mnToplamTutar] > 0 AND FATNO IS NOT NULL AND (SELECT TOP 1 strAciklama FROM tblINTERNET_IadeHareketleri WHERE intIadeHareketTurID = 21 AND intIadeID = vw_tblINTERNET_Iadeler.pkIadeID ORDER BY pkID DESC) LIKE 'S.T. - %')) AS 'S.T.',(SELECT count(*) FROM [KurumsalWebSAP].[dbo].[vw_tblINTERNET_Iadeler] WHERE dtOnaylamaTarihi >= '01.01.2014' AND ([blAktarilmis] = 'False' AND [mnToplamTutar] > 0 AND FATNO IS NOT NULL AND (SELECT TOP 1 strAciklama FROM tblINTERNET_IadeHareketleri WHERE intIadeHareketTurID = 21 AND intIadeID = vw_tblINTERNET_Iadeler.pkIadeID ORDER BY pkID DESC) LIKE 'C/H - %')) AS 'C/H',(SELECT count(*) FROM [KurumsalWebSAP].[dbo].[vw_tblINTERNET_Iadeler] WHERE dtOnaylamaTarihi >= '01.01.2014' AND ([blAktarilmis] = 'False' AND [mnToplamTutar] > 0 AND FATNO IS NOT NULL AND (SELECT TOP 1 strAciklama FROM tblINTERNET_IadeHareketleri WHERE intIadeHareketTurID = 21 AND intIadeID = vw_tblINTERNET_Iadeler.pkIadeID ORDER BY pkID DESC) LIKE 'Son - %')) AS 'Son',(SELECT count(*) FROM [KurumsalWebSAP].[dbo].[vw_tblINTERNET_Iadeler] WHERE dtOnaylamaTarihi >= '01.01.2014' AND ([blAktarilmis] = 'False' AND [mnToplamTutar] > 0 AND FATNO IS NULL AND strAciklama NOT LIKE '%-IADE MERKEZDEN GIRILDI' AND Copte = 'True')) AS 'Önemsiz',(SELECT count(*) FROM [KurumsalWebSAP].[dbo].[vw_tblINTERNET_Iadeler] WHERE dtOnaylamaTarihi >= '01.01.2014' AND ([blAktarilmis] = 'False' AND [mnToplamTutar] = -1)) AS 'Reddedilen',(SELECT count(*) FROM [KurumsalWebSAP].[dbo].[vw_tblINTERNET_Iadeler] WHERE dtOnaylamaTarihi >= '01.01.2014' AND ([blAktarilmis] = 'False' AND [mnToplamTutar] = -2)) AS 'Değişim'", conn);
                cmd.CommandTimeout = 400;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        donendeger = "Fiyatlandırılmamış: " + dr[0].ToString() + "\r\n";
                        donendeger += "Fiyatlandırılmış: " + dr[1].ToString() + "\r\n";
                        //donendeger += "Sevk Bekleyen Tümü: " + dr[2].ToString() + "\r\n";
                        donendeger += "Sevk Bekleyen Araca Verilecek: " + dr[3].ToString() + "\r\n";
                        donendeger += "Sevk Bekleyen Araçta: " + dr[4].ToString() + "\r\n";
                        donendeger += "Sevkten Gelen: " + dr[5].ToString() + "\r\n";
                        donendeger += "İade Girilen: " + dr[6].ToString() + "\r\n";
                        donendeger += "İade Kabul: " + dr[7].ToString() + "\r\n";
                        donendeger += "Sat.Op.: " + dr[8].ToString() + "\r\n";
                        donendeger += "S.T.: " + dr[9].ToString() + "\r\n";
                        donendeger += "C/H: " + dr[10].ToString() + "\r\n";
                        donendeger += "Son: " + dr[11].ToString() + "\r\n";
                        donendeger += "Reddedilen: " + dr[13].ToString() + "\r\n";
                        donendeger += "Değişim: " + dr[14].ToString() + "\r\n";
                        donendeger += "Önemsiz: " + dr[12].ToString() + "\r\n";
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
        /// ST kategorisinde hangi satıcılarda iade varsa o kişilere iade numaraları mesaj olarak gidiyor
        /// </summary>
        public static string STIadeleriSahiplerineMesaj()
        {
            string donendeger = string.Empty;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT DISTINCT (SELECT [SAT TEM] FROM [Web-Musteri] WHERE SMREF = [vw_tblINTERNET_Iadeler].SMREF AND [SAT KOD1] NOT LIKE '8%' AND SUBSTRING([SAT KOD], 11, 2) NOT LIKE '08' AND SUBSTRING([SAT KOD], 11, 2) NOT LIKE '16' AND SUBSTRING([SAT KOD], 11, 2) NOT LIKE '17' AND SUBSTRING([SAT KOD], 11, 2) NOT LIKE '18' AND [SAT KOD] NOT LIKE '00%') AS SATTEM,(SELECT pkMusteriID FROM tblINTERNET_Musteriler WHERE intSLSREF = (SELECT SLSREF FROM [Web-Musteri] WHERE SMREF = [vw_tblINTERNET_Iadeler].SMREF AND [SAT KOD1] NOT LIKE '8%' AND SUBSTRING([SAT KOD], 11, 2) NOT LIKE '08' AND SUBSTRING([SAT KOD], 11, 2) NOT LIKE '16' AND SUBSTRING([SAT KOD], 11, 2) NOT LIKE '17' AND SUBSTRING([SAT KOD], 11, 2) NOT LIKE '18' AND [SAT KOD] NOT LIKE '00%')) AS intMusteriID FROM [vw_tblINTERNET_Iadeler] WHERE dtOnaylamaTarihi >= '01.01.2014' AND ([blAktarilmis] = 'False' AND [mnToplamTutar] > 0 AND FATNO IS NOT NULL AND (SELECT TOP 1 strAciklama FROM tblINTERNET_IadeHareketleri WHERE intIadeHareketTurID = 21 AND intIadeID = vw_tblINTERNET_Iadeler.pkIadeID ORDER BY pkID DESC) LIKE 'S.T. - %') ORDER BY SATTEM", conn);
                da.SelectCommand.CommandTimeout = 400;
                DataTable dt = new DataTable();
                try
                {
                    conn.Open();
                    da.Fill(dt);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i]["intMusteriID"] != DBNull.Value)
                        {
                            Musteriler musteri = Musteriler.GetMusteriByID(Convert.ToInt32(dt.Rows[i]["intMusteriID"]));
                            donendeger += "<b> ### " + musteri.strAd.ToUpper() + " " + musteri.strSoyad.ToUpper() + " ### </b><br /><br />";

                            string icerik = string.Empty;
                            SqlDataAdapter da1 = new SqlDataAdapter("SELECT pkIadeID,CASE WHEN SUBE = '' THEN MUSTERI ELSE SUBE END AS MUSTERI,(SELECT TOP 1 dtTarih FROM tblINTERNET_IadeHareketleri WHERE intIadeHareketTurID = 21 AND intIadeID = vw_tblINTERNET_Iadeler.pkIadeID ORDER BY pkID DESC) AS Tarih FROM [vw_tblINTERNET_Iadeler] WHERE dtOnaylamaTarihi >= '01.01.2014' AND ([blAktarilmis] = 'False' AND [mnToplamTutar] > 0 AND FATNO IS NOT NULL AND (SELECT TOP 1 strAciklama FROM tblINTERNET_IadeHareketleri WHERE intIadeHareketTurID = 21 AND intIadeID = vw_tblINTERNET_Iadeler.pkIadeID ORDER BY pkID DESC) LIKE 'S.T. - %') AND intMusteriID = @intMusteriID", conn);
                            da1.SelectCommand.Parameters.Add("@intMusteriID", SqlDbType.Int).Value = Convert.ToInt32(dt.Rows[i]["intMusteriID"]);
                            DataTable dt1 = new DataTable();
                            da1.Fill(dt1);
                            for (int j = 0; j < dt1.Rows.Count; j++)
                            {
                                string ic = "<b>İade No:</b> " + dt1.Rows[j]["pkIadeID"].ToString() + "<br /><b>C/H:</b> " + dt1.Rows[j]["MUSTERI"].ToString() + "<br /><b>Dosyaya konulma tarihi:</b> " + dt1.Rows[j]["Tarih"].ToString() + "<br /><br />";
                                icerik += ic;
                            }
                            donendeger += dt1.Rows.Count.ToString() + " adet iade.<br /><br />";

                            //GonderilenMesajlar gm = new GonderilenMesajlar(
                            //    Convert.ToInt32(dt.Rows[i]["intMusteriID"]),
                            //    58, // iade kabul
                            //    "Dosyanızda bekleyen iadeler",
                            //    "Sayın satıcı,<br /><br />Dosyanıza konan fiyatlanmış iadeler (bir önceki akşam dahil) günlük olarak güncellenmektedir. Fiyatlamalar ile ilgili itirazınızı günlük yapmadığınız takdirde tarafınızdan teslim alınmış kabul edilecektir.<br /><br />" + icerik,
                            //    DateTime.Now,
                            //    DateTime.MinValue,
                            //    false,
                            //    false,
                            //    false);
                            //gm.DoInsert();
                        }
                    }
                    conn.Close();
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
        /// 0: logicalref, 1: clientref
        /// </summary>
        public static ArrayList QuantumdanGetir(string KartNo)
        {
            ArrayList donendeger = new ArrayList();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT LOGICALREF,CLIENTREF FROM [QUANTUMNET].[dbo].[SATIS_SIPARIS_KART] WHERE KARTNO = '" + KartNo + "'", conn);
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
        /// arraylist içinde arraylist var, 0: malzemeref, 1: miktar
        /// </summary>
        public static ArrayList QuantumdanGetirDetaylar(string LogicalRef)
        {
            ArrayList donendeger = new ArrayList();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT MALZEMEREF,MIKTAR FROM [QUANTUMNET].[dbo].[SATIS_SIPARIS_DETAY] WHERE SIPARIS_REF = '" + LogicalRef + "' AND SATIRNO IS NOT NULL AND SATIRNO != 0", conn);
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        ArrayList ic = new ArrayList();
                        ic.Add(dr[0].ToString());
                        ic.Add(dr[1].ToString());
                        donendeger.Add(ic);
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

        public static void SetSapDepo(string Neden, string Depo, string UY, string PartiNo, int IadeID)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UPDATE tblINTERNET_Iadeler SET strNedenKod = @strNedenKod, strDepoKod = @strDepoKod, strDepoUY = @strDepoUY, strPartiNo = @strPartiNo WHERE pkIadeID = @pkIadeID", conn);
                cmd.Parameters.Add("@strNedenKod", SqlDbType.VarChar, 5).Value = Neden;
                cmd.Parameters.Add("@strDepoKod", SqlDbType.VarChar, 5).Value = Depo;
                cmd.Parameters.Add("@strDepoUY", SqlDbType.VarChar, 5).Value = UY;
                cmd.Parameters.Add("@strPartiNo", SqlDbType.VarChar, 10).Value = PartiNo;
                cmd.Parameters.Add("@pkIadeID", SqlDbType.Int).Value = IadeID;
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

        public static void SetSapDepo(string Neden, int IadeID)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UPDATE tblINTERNET_Iadeler SET strNedenKod = @strNedenKod WHERE pkIadeID = @pkIadeID", conn);
                cmd.Parameters.Add("@strNedenKod", SqlDbType.VarChar, 5).Value = Neden;
                cmd.Parameters.Add("@pkIadeID", SqlDbType.Int).Value = IadeID;
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

        public static void SetTksref(int TKSREF, int IadeID)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UPDATE tblINTERNET_Iadeler SET TKSREF = @TKSREF WHERE pkIadeID = @pkIadeID", conn);
                cmd.Parameters.Add("@TKSREF", SqlDbType.Int).Value = TKSREF;
                cmd.Parameters.Add("@pkIadeID", SqlDbType.Int).Value = IadeID;
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
        /// Neden, Depo, UY, Parti
        /// </summary>
        /// <returns></returns>
        public static string[] GetSapDepo(int IadeID)
        {
            string[] donendeger = new string[4];

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT strNedenKod, strDepoKod, strDepoUY, strPartiNo FROM tblINTERNET_Iadeler WHERE pkIadeID = @pkIadeID", conn);
                cmd.Parameters.Add("@pkIadeID", SqlDbType.Int).Value = IadeID;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        donendeger[0] = dr[0].ToString();
                        donendeger[1] = dr[1].ToString();
                        donendeger[2] = dr[2].ToString();
                        donendeger[3] = dr[3].ToString();
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
        /// Tümü: 0, 
        /// Fiyatlandırılmamış: 1, 
        /// Fiyatlandırılmış: 2, 
        /// Sevk Bekleyen tümü: 3, 
        /// Sevk Bekleyen işaretli: 4, 
        /// Sevk Bekleyen işaretsiz: 5, 
        /// İade Kabul: 6,
        /// Reddedilen: 7, 
        /// Değişen: 8, 
        /// Sevk Bekleyen İade Kabul Arası: 9, 
        /// Önemsizler: 10, 
        /// İade Kabul Tümü: 11,
        /// Önemsizler 1 (onaylanacak iade): 12, 
        /// Sevk Bekleyen gelmiş: 13
        /// </summary>
        public static void GetObjectsVW(DataTable dt, int Tur, DateTime dtBaslangic,
            bool SatisOperasyonSonAciklama, bool SatisOperasyonSonIslemYapan, bool SatisOperasyonSonTarih, bool strSofor, bool strMuavin, 
            bool dtTarihGidis, bool FiyatlandirilmisSatirSayisi, bool SevkBilgisiSayisi, bool strSoyad, bool strAd, bool SatirSayisi, bool VGBLI, bool Istihbarat)
        {
            string tumustatu = "'' AS STATU,";
            string satisoperasyonsonaciklama = SatisOperasyonSonAciklama ? ",IsNull((SELECT TOP 1 strAciklama FROM tblINTERNET_IadeHareketleri WHERE intIadeHareketTurID = 21 AND intIadeID = vw_tblINTERNET_Iadeler.pkIadeID ORDER BY pkID DESC),'İade  Kabul') AS SatisOperasyonSonAciklama" : ",'' AS SatisOperasyonSonAciklama";
            string satisoperasyonsonislemyapan = SatisOperasyonSonIslemYapan ? ",(SELECT TOP 1 strIslemYapan FROM tblINTERNET_IadeHareketleri WHERE intIadeHareketTurID = 21 AND intIadeID = vw_tblINTERNET_Iadeler.pkIadeID ORDER BY pkID DESC) AS SatisOperasyonSonIslemYapan" : ",''  AS SatisOperasyonSonIslemYapan";
            string satisoperasyonsontarih = SatisOperasyonSonTarih ? ",(SELECT TOP 1 dtTarih FROM tblINTERNET_IadeHareketleri WHERE intIadeHareketTurID = 21 AND intIadeID = vw_tblINTERNET_Iadeler.pkIadeID ORDER BY pkID DESC) AS SatisOperasyonSonTarih" : ",'' AS SatisOperasyonSonTarih";
            string strsofor = strSofor ? ",(SELECT TOP 1 strSofor FROM [tblINTERNET_IadelerSevk] WHERE intIadeID = [vw_tblINTERNET_Iadeler].pkIadeID ORDER BY pkID DESC) AS 'strSofor'" : ",'' AS 'strSofor'";
            string strmuavin = strMuavin ? ",(SELECT TOP 1 strMuavin FROM [tblINTERNET_IadelerSevk] WHERE intIadeID = [vw_tblINTERNET_Iadeler].pkIadeID ORDER BY pkID DESC) AS 'strMuavin'" : ",'' AS 'strMuavin'";
            string dttarihgidis = dtTarihGidis ? ",(SELECT TOP 1 dtTarihGidis FROM [tblINTERNET_IadelerSevk] WHERE intIadeID = [vw_tblINTERNET_Iadeler].pkIadeID ORDER BY pkID DESC) AS 'dtTarihGidis'" : ",NULL AS 'dtTarihGidis'";
            string fiyatlandirilmissatirsayisi = FiyatlandirilmisSatirSayisi ? ",(SELECT count([pkIadeDetayID]) FROM [tblINTERNET_IadelerDetay] WHERE mnFiyat > 0 AND intIadeID = [vw_tblINTERNET_Iadeler].pkIadeID) AS 'FiyatlandirilmisSatirSayisi'" : ",0 AS 'FiyatlandirilmisSatirSayisi'";
            string sevkbilgisisayisi = SevkBilgisiSayisi ? ",(SELECT count([pkID]) FROM [tblINTERNET_IadelerSevk] WHERE intIadeID = [vw_tblINTERNET_Iadeler].pkIadeID) AS 'SevkBilgisiSayisi'" : ",0 AS 'SevkBilgisiSayisi'";
            string satici = strSoyad ? ",(SELECT TOP 1 [SAT TEM] FROM [Web-Musteri] WHERE [SMREF] = [vw_tblINTERNET_Iadeler].SMREF) AS 'strSoyad'" : ",'' AS 'strSoyad'";
            string uye = strAd ? ",(SELECT strAd FROM tblINTERNET_Musteriler WHERE pkMusteriID = vw_tblINTERNET_Iadeler.intMusteriID) + ' ' + (SELECT strSoyad FROM tblINTERNET_Musteriler WHERE pkMusteriID = vw_tblINTERNET_Iadeler.intMusteriID) AS 'strAd'" : ",'' AS 'strAd'";
            string satirsayisi = SatirSayisi ? ",(SELECT count(pkIadeDetayID) FROM tblINTERNET_IadelerDetay WHERE (intIadeID = vw_tblINTERNET_Iadeler.pkIadeID)) AS 'SatirSayisi'" : ",'' AS 'SatirSayisi'";
            string vgb = VGBLI ? ",(SELECT count(DISTINCT GMREF) FROM [Web-Risk] WHERE ([VGB TOP] > 100) AND (GMREF = vw_tblINTERNET_Iadeler.GMREF)) AS 'VGBLI'" : ",'' AS 'VGBLI'";
            string istihbarat = Istihbarat ? ",'' AS 'Istihbarat4','' AS 'Istihbarat5','' AS 'Istihbarat6'" : ",'' AS 'Istihbarat4','' AS 'Istihbarat5','' AS 'Istihbarat6'";

            string where = string.Empty;
            switch (Tur)
	        {
                case 0:
                    where = "WHERE NOT ([blAktarilmis] = 'False' AND [mnToplamTutar] = 0)";
                    tumustatu =
                        @"CASE 
WHEN ([blAktarilmis] = 'True' AND [mnToplamTutar] = 0) THEN 'Fiyatlandırılmamış' 
WHEN ([blAktarilmis] = 'True' AND [mnToplamTutar] > 0) THEN 'Fiyatlandırılmış' 
WHEN ([blAktarilmis] = 'False' AND [mnToplamTutar] > 0 AND FATNO IS NULL AND Copte = 'False' AND strAciklama NOT LIKE '%-IADE MERKEZDEN GIRILDI' AND ((SELECT count(pkID) FROM tblINTERNET_IadelerSevk WHERE intIadeID = [vw_tblINTERNET_Iadeler].[pkIadeID]) = 0 OR (SELECT TOP 1 CASE WHEN dtTarihGelis IS NOT NULL THEN 0 ELSE 1 END FROM tblINTERNET_IadelerSevk WHERE intIadeID = [vw_tblINTERNET_Iadeler].[pkIadeID] ORDER BY pkID DESC) > 0)) THEN 'Sevk Bekleyen' 
WHEN ([blAktarilmis] = 'False' AND [mnToplamTutar] > 0 AND FATNO IS NULL AND Copte = 'False' AND strAciklama NOT LIKE '%-IADE MERKEZDEN GIRILDI' AND (SELECT TOP 1 CASE WHEN dtTarihGelis IS NULL THEN 0 ELSE 1 END FROM tblINTERNET_IadelerSevk WHERE intIadeID = [vw_tblINTERNET_Iadeler].[pkIadeID] ORDER BY pkID DESC) > 0) THEN 'Sevkten Gelen' 
WHEN ([blAktarilmis] = 'False' AND [mnToplamTutar] > 0 AND FATNO IS NULL AND Copte = 'False' AND strAciklama NOT LIKE '%-IADE MERKEZDEN GIRILDI') THEN 'Sevk Bekleyen' WHEN ([blAktarilmis] = 'False' AND [mnToplamTutar] = -1) THEN 'Reddedilen' 
WHEN ([blAktarilmis] = 'False' AND [mnToplamTutar] = -2) THEN 'Son Fiyatlama' 
WHEN ([blAktarilmis] = 'False' AND [mnToplamTutar] > 0 AND FATNO IS NULL AND strAciklama LIKE '%-IADE MERKEZDEN GIRILDI') THEN 'İade Girilen' 
WHEN ([blAktarilmis] = 'False' AND [mnToplamTutar] > 0 AND FATNO IS NULL AND strAciklama NOT LIKE '%-IADE MERKEZDEN GIRILDI' AND Copte = 'True') THEN 'Yeni' 
WHEN ([blAktarilmis] = 'False' AND [mnToplamTutar] > 0 AND FATNO IS NOT NULL AND (SELECT TOP 1 strAciklama FROM tblINTERNET_IadeHareketleri WHERE intIadeHareketTurID = 21 AND intIadeID = vw_tblINTERNET_Iadeler.pkIadeID ORDER BY pkID DESC) IS NULL) THEN 'İade Kabul' WHEN ([blAktarilmis] = 'False' AND [mnToplamTutar] > 0 AND FATNO IS NOT NULL AND (SELECT TOP 1 strAciklama FROM tblINTERNET_IadeHareketleri WHERE intIadeHareketTurID = 21 AND intIadeID = vw_tblINTERNET_Iadeler.pkIadeID ORDER BY pkID DESC) LIKE 'Sat.Op. - %') THEN 'Sat.Op.' 
WHEN ([blAktarilmis] = 'False' AND [mnToplamTutar] > 0 AND FATNO IS NOT NULL AND (SELECT TOP 1 strAciklama FROM tblINTERNET_IadeHareketleri WHERE intIadeHareketTurID = 21 AND intIadeID = vw_tblINTERNET_Iadeler.pkIadeID ORDER BY pkID DESC) LIKE 'S.T. - %') THEN 'S.T.' WHEN ([blAktarilmis] = 'False' AND [mnToplamTutar] > 0 AND FATNO IS NOT NULL AND (SELECT TOP 1 strAciklama FROM tblINTERNET_IadeHareketleri WHERE intIadeHareketTurID = 21 AND intIadeID = vw_tblINTERNET_Iadeler.pkIadeID ORDER BY pkID DESC) LIKE 'C/H - %') THEN 'C/H' 
WHEN ([blAktarilmis] = 'False' AND [mnToplamTutar] > 0 AND FATNO IS NOT NULL AND (SELECT TOP 1 strAciklama FROM tblINTERNET_IadeHareketleri WHERE intIadeHareketTurID = 21 AND intIadeID = vw_tblINTERNET_Iadeler.pkIadeID ORDER BY pkID DESC) LIKE 'Son - %') THEN 'Son' 
ELSE '' END AS 'STATU',";
                    break;
                case 1:
                    where = "WHERE ([blAktarilmis] = 'True' AND [mnToplamTutar] = 0) ";
                    break;
                case 2:
                    where = "WHERE ([blAktarilmis] = 'True' AND [mnToplamTutar] > 0) ";
                    break;
                case 3:
                    where = "WHERE ([blAktarilmis] = 'False' AND [mnToplamTutar] > 0 AND FATNO IS NULL AND Copte = 'False' AND strAciklama NOT LIKE '%-IADE MERKEZDEN GIRILDI' AND ((SELECT count(pkID) FROM tblINTERNET_IadelerSevk WHERE intIadeID = [vw_tblINTERNET_Iadeler].[pkIadeID]) = 0 OR (SELECT TOP 1 CASE WHEN dtTarihGelis IS NOT NULL THEN 0 ELSE 1 END FROM tblINTERNET_IadelerSevk WHERE intIadeID = [vw_tblINTERNET_Iadeler].[pkIadeID] ORDER BY pkID DESC) > 0)) ";
                    break;
                case 4:
                    where = "WHERE ([blAktarilmis] = 'False' AND [mnToplamTutar] > 0 AND FATNO IS NULL AND Copte = 'False' AND strAciklama NOT LIKE '%-IADE MERKEZDEN GIRILDI' AND (SELECT TOP 1 CASE WHEN dtTarihGelis IS NOT NULL THEN 0 ELSE 1 END FROM tblINTERNET_IadelerSevk WHERE intIadeID = [vw_tblINTERNET_Iadeler].[pkIadeID] ORDER BY pkID DESC) > 0) ";
                    break;
                case 5:
                    where = "WHERE ([blAktarilmis] = 'False' AND [mnToplamTutar] > 0 AND FATNO IS NULL AND Copte = 'False' AND strAciklama NOT LIKE '%-IADE MERKEZDEN GIRILDI' AND (SELECT count(pkID) FROM tblINTERNET_IadelerSevk WHERE intIadeID = [vw_tblINTERNET_Iadeler].[pkIadeID]) = 0) ";
                    break;
                case 6:
                    where = "WHERE ([blAktarilmis] = 'False' AND [mnToplamTutar] > 0 AND FATNO IS NOT NULL) AND dtOnaylamaTarihi > DATEADD(DD,-10,GETDATE()) ";
                    break;
                case 7:
                    where = "WHERE ([blAktarilmis] = 'False' AND [mnToplamTutar] = -1) ";
                    break;
                case 8:
                    where = "WHERE ([blAktarilmis] = 'False' AND [mnToplamTutar] = -2) ";
                    break;
                case 9:
                    where = "WHERE ([blAktarilmis] = 'False' AND [mnToplamTutar] > 0 AND FATNO IS NULL AND strAciklama LIKE '%-IADE MERKEZDEN GIRILDI') ";
                    break;
                case 10:
                    where = "WHERE ([blAktarilmis] = 'False' AND [mnToplamTutar] > 0 AND FATNO IS NULL AND strAciklama NOT LIKE '%-IADE MERKEZDEN GIRILDI' AND Copte = 'True') ";
                    break;
                case 11:
                    where = "WHERE ([blAktarilmis] = 'False' AND [mnToplamTutar] > 0 AND FATNO IS NOT NULL AND Copte = 'False') ";
                    break;
                case 12:
                    where = "WHERE ([blAktarilmis] = 'False' AND [mnToplamTutar] > 0 AND Copte = 'True') ";
                    break;
                case 13:
                    where = "WHERE ([blAktarilmis] = 'False' AND [mnToplamTutar] > 0 AND FATNO IS NULL AND Copte = 'False' AND strAciklama NOT LIKE '%-IADE MERKEZDEN GIRILDI' AND (SELECT TOP 1 CASE WHEN dtTarihGelis IS NULL THEN 0 ELSE 1 END FROM tblINTERNET_IadelerSevk WHERE intIadeID = [vw_tblINTERNET_Iadeler].[pkIadeID] ORDER BY pkID DESC) > 0) ";
                    break;
	        }

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT " + 
                    tumustatu +
                    "[pkIadeID],[intMusteriID]" +
                    satici + 
                    uye +
                    ",[SMREF],YTKKOD,[MUS KOD],[MUSTERI]" +
                    ",[SUB KOD],[SUBE],[dtOlusmaTarihi],[dtOnaylamaTarihi],[blAktarilmis],[mnToplamTutar]" +
                    ",strAciklama AS strAciklama2, strAciklama AS strAciklama3" +
                    ",CASE WHEN strAciklama LIKE '%-IADE MERKEZDEN GIRILDI' THEN 1 ELSE 0 END AS IADEMERKEZDENGIRILDI" + 
                    ",QUANTUMNO,FATNO,FATTAR,blSayimYapildi,dtSayimTarihi" +
                    satisoperasyonsonaciklama +
                    satisoperasyonsonislemyapan +
                    satisoperasyonsontarih + 
                    ",BasilmaSayisi" +
                    satirsayisi +
                    vgb +
                    fiyatlandirilmissatirsayisi +
                    sevkbilgisisayisi +
                    istihbarat +
                    strsofor +
                    strmuavin +
                    dttarihgidis +
                    " FROM [KurumsalWebSAP].[dbo].[vw_tblINTERNET_Iadeler] " + 
                    where +
                    "AND dtOnaylamaTarihi >= @dtBaslangic ORDER BY [dtOnaylamaTarihi] DESC", conn);
                da.SelectCommand.Parameters.Add("@dtBaslangic", SqlDbType.DateTime).Value = dtBaslangic;
                da.SelectCommand.CommandTimeout = 1000;
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

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string[] Aciklamalar = dt.Rows[i]["strAciklama2"].ToString().Split(new string[] { ";;;" }, StringSplitOptions.None);
                dt.Rows[i]["strAciklama2"] = Aciklamalar[1];
                dt.Rows[i]["strAciklama3"] = Aciklamalar[2];
            }
        }
    }
}

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
    public class Siparisler : ISultanlar, IDisposable
    {
        //
        //
        //
        // Alanlar:
        //
        private int _pkSiparisID;
        private int _intMusteriID;
        private int _SMREF;
        private short _sintFiyatTipiID;
        private DateTime _dtOlusmaTarihi;
        private decimal _mnToplamTutar;
        private bool _blAktarilmis;
        private int _TKSREF;
        private DateTime _dtOnaylamaTarihi;
        private string _strAciklama;
        //
        //
        //
        // Constracter lar:
        //
        private Siparisler(int pkSiparisID, int intMusteriID, int SMREF, short sintFiyatTipiID, DateTime dtOlusmaTarihi,
            decimal mnToplamTutar, bool blAktarilmis, int TKSREF, DateTime dtOnaylamaTarihi, string strAciklama)
        {
            this._pkSiparisID = pkSiparisID;
            this._intMusteriID = intMusteriID;
            this._SMREF = SMREF;
            this._sintFiyatTipiID = sintFiyatTipiID;
            this._dtOlusmaTarihi = dtOlusmaTarihi;
            this._mnToplamTutar = mnToplamTutar;
            this._blAktarilmis = blAktarilmis;
            this._TKSREF = TKSREF;
            this._dtOnaylamaTarihi = dtOnaylamaTarihi;
            this._strAciklama = strAciklama;
        }
        //
        //
        public Siparisler(int intMusteriID, int SMREF, short sintFiyatTipiID, DateTime dtOlusmaTarihi, decimal mnToplamTutar,
            bool blAktarilmis, int TKSREF, DateTime dtOnaylamaTarihi, string strAciklama)
        {
            this._intMusteriID = intMusteriID;
            this._SMREF = SMREF;
            this._sintFiyatTipiID = sintFiyatTipiID;
            this._dtOlusmaTarihi = dtOlusmaTarihi;
            this._mnToplamTutar = mnToplamTutar;
            this._blAktarilmis = blAktarilmis;
            this._TKSREF = TKSREF;
            this._dtOnaylamaTarihi = dtOnaylamaTarihi;
            this._strAciklama = strAciklama;
        }
        //
        //
        public Siparisler()
        {

        }
        //
        //
        //
        // Özellikler:
        //
        public int pkSiparisID { get { return this._pkSiparisID; } }
        public int intMusteriID { get { return this._intMusteriID; } set { this._intMusteriID = value; } }
        public Musteriler Musteri { get { return Musteriler.GetMusteriByID(this._intMusteriID); } }
        public int SMREF { get { return this._SMREF; } set { this._SMREF = value; } }
        public CariHesaplar CariHesap { get { return CariHesaplar.GetObject(this._SMREF); } }
        public short sintFiyatTipiID { get { return this._sintFiyatTipiID; } set { this._sintFiyatTipiID = value; } }
        public DateTime dtOlusmaTarihi { get { return this._dtOlusmaTarihi; } set { this._dtOlusmaTarihi = value; } }
        public decimal mnToplamTutar { get { return this._mnToplamTutar; } set { this._mnToplamTutar = value; } }
        public bool blAktarilmis { get { return this._blAktarilmis; } set { this._blAktarilmis = value; } }
        /// <summary>
        /// MTIP
        /// </summary>
        public int TKSREF { get { return this._TKSREF; } set { this._TKSREF = value; } }
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
            return this._pkSiparisID.ToString();
        }
        //
        //
        //
        // Metodlar:
        //
        public void ToplamTutarGuncelle()
        {
            DataTable dt = new DataTable();
            SiparislerDetay.GetObjectsBySiparisID(dt, this._pkSiparisID);
            double toplam = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                double tutar = Convert.ToDouble(dt.Rows[i]["mnFiyat"]);
                if (dt.Rows[i]["strMiktarTur"].ToString() == "KI")
                {
                    tutar = tutar * Urunler.GetKoliAdedi(Convert.ToInt32(dt.Rows[i]["intUrunID"]));
                }
                toplam += tutar * Convert.ToInt32(dt.Rows[i]["intMiktar"]);
            }
            this._mnToplamTutar = Convert.ToDecimal(toplam);
            this.DoUpdate();
        }
        //
        //
        public void DoInsert()
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_INTERNET_SiparisEkle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@intMusteriID", SqlDbType.Int).Value = this._intMusteriID;
                cmd.Parameters.Add("@SMREF", SqlDbType.Int).Value = this._SMREF;
                cmd.Parameters.Add("@sintFiyatTipiID", SqlDbType.SmallInt).Value = this._sintFiyatTipiID;
                cmd.Parameters.Add("@dtOlusmaTarihi", SqlDbType.SmallDateTime).Value = this._dtOlusmaTarihi;
                cmd.Parameters.Add("@mnToplamTutar", SqlDbType.Money).Value = this._mnToplamTutar;
                cmd.Parameters.Add("@blAktarilmis", SqlDbType.Bit).Value = this._blAktarilmis;
                cmd.Parameters.Add("@TKSREF", SqlDbType.Int).Value = this._TKSREF;
                cmd.Parameters.Add("@dtOnaylamaTarihi", SqlDbType.SmallDateTime).Value = this._dtOlusmaTarihi;              ////////
                cmd.Parameters.Add("@strAciklama", SqlDbType.NVarChar).Value = this._strAciklama;
                cmd.Parameters.Add("@pkSiparisID", SqlDbType.Int).Direction = ParameterDirection.Output;
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    this._pkSiparisID = Convert.ToInt32(cmd.Parameters["@pkSiparisID"].Value);
                }
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
                SqlCommand cmd = new SqlCommand("sp_INTERNET_SiparisGuncelle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkSiparisID", SqlDbType.Int).Value = this._pkSiparisID;
                cmd.Parameters.Add("@intMusteriID", SqlDbType.Int).Value = this._intMusteriID;
                cmd.Parameters.Add("@SMREF", SqlDbType.Int).Value = this._SMREF;
                cmd.Parameters.Add("@sintFiyatTipiID", SqlDbType.SmallInt).Value = this._sintFiyatTipiID;
                cmd.Parameters.Add("@dtOlusmaTarihi", SqlDbType.SmallDateTime).Value = this._dtOlusmaTarihi;
                cmd.Parameters.Add("@mnToplamTutar", SqlDbType.Money).Value = this._mnToplamTutar;
                cmd.Parameters.Add("@blAktarilmis", SqlDbType.Bit).Value = this._blAktarilmis;
                cmd.Parameters.Add("@TKSREF", SqlDbType.Int).Value = this._TKSREF;
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
                SqlCommand cmd = new SqlCommand("sp_INTERNET_SiparisSil", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkSiparisID", SqlDbType.Int).Value = this._pkSiparisID;
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
        public static void DoDelete(int SiparisID)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_INTERNET_SiparisSil", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkSiparisID", SqlDbType.Int).Value = SiparisID;
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
        public static void DoDeleteWithSiparislerDetays(int SiparisID)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_INTERNET_SiparisSilSiparisDetaylariyla", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkSiparisID", SqlDbType.Int).Value = SiparisID;
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
        public static int GetSiparisCount(DateTime BaslangicTarih, DateTime BitisTarih, object Onayli, string Aciklama)
        {
            int donendeger = 0;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_INTERNET_SiparislerCountByDate", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@BaslangicTarih", SqlDbType.SmallDateTime).Value = BaslangicTarih;
                cmd.Parameters.Add("@BitisTarih", SqlDbType.SmallDateTime).Value = BitisTarih;
                cmd.Parameters.Add("@blAktarilmis", SqlDbType.Bit).Value = Onayli;
                cmd.Parameters.Add("@strAciklama", SqlDbType.NVarChar).Value = Aciklama;
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
        public static void GetObjects(DataTable dt, DateTime BaslangicTarih, DateTime BitisTarih, int Baslangic, int Adet, object Onayli, string Aciklama)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_INTERNET_SiparislerGetirByDate", conn);
                da.SelectCommand.Parameters.Add("@BaslangicTarih", SqlDbType.SmallDateTime).Value = BaslangicTarih;
                da.SelectCommand.Parameters.Add("@BitisTarih", SqlDbType.SmallDateTime).Value = BitisTarih;
                da.SelectCommand.Parameters.Add("@blAktarilmis", SqlDbType.Bit).Value = Onayli;
                da.SelectCommand.Parameters.Add("@strAciklama", SqlDbType.NVarChar).Value = Aciklama;
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

            dt.Columns.Add("VADE", typeof(string));
            dt.Columns.Add("FiyatTipi", typeof(string));
            dt.Columns.Add("MUSTERI", typeof(string));
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["VADE"] = TaksitPlanlari.GetOdemePlani(Convert.ToInt32(dt.Rows[i]["TKSREF"])).Replace("VADE", "");
                dt.Rows[i]["FiyatTipi"] = FiyatTipleri.GetObjectByID(Convert.ToInt16(dt.Rows[i]["sintFiyatTipiID"]));
                if (Convert.ToInt32(dt.Rows[i]["SMREF"]) != 0)
                    dt.Rows[i]["MUSTERI"] = CariHesaplar.GetMUSTERIbySMREFmusterisube(Convert.ToInt32(dt.Rows[i]["SMREF"]));
            }
        }
        //
        //
        public static void GetObjects(IList List)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                List.Clear();

                SqlCommand cmd = new SqlCommand("sp_INTERNET_SiparislerGetir", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        List.Add(new Siparisler(Convert.ToInt32(dr[0]), Convert.ToInt32(dr[1]), Convert.ToInt32(dr[4]),
                            Convert.ToInt16(dr[5]), Convert.ToDateTime(dr[6]), Convert.ToDecimal(dr[7]), Convert.ToBoolean(dr[8]),
                            Convert.ToInt32(dr[9]), Convert.ToDateTime(dr[10]), dr[11].ToString()));
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
        public static Siparisler GetObjectsBySiparisID(int SiparisID)
        {
            Siparisler siparis = new Siparisler();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_INTERNET_SiparisGetirBySiparisID", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkSiparisID", SqlDbType.Int).Value = SiparisID;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        siparis = new Siparisler(Convert.ToInt32(dr[0]), Convert.ToInt32(dr[1]), Convert.ToInt32(dr[2]),
                            Convert.ToInt16(dr[3]), Convert.ToDateTime(dr[4]), Convert.ToDecimal(dr[5]), Convert.ToBoolean(dr[6]),
                            Convert.ToInt32(dr[7]), Convert.ToDateTime(dr[8]), dr[9].ToString());
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

            return siparis;
        }
        //
        //
        public static void GetObjectsBySMREF(DataTable dt, int SMREF)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_INTERNET_SiparislerGetirBySMREF", conn);
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

                // vade, fiyat tipi ismini ve SMREF ismini yaz:
                dt.Columns.Add("VADE", typeof(string));
                dt.Columns.Add("FiyatTipi", typeof(string));
                dt.Columns.Add("MUSTERI", typeof(string));
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["VADE"] = TaksitPlanlari.GetOdemePlani(Convert.ToInt32(dt.Rows[i]["TKSREF"])).Replace("VADE", "");
                    dt.Rows[i]["FiyatTipi"] = FiyatTipleri.GetObjectByID(Convert.ToInt16(dt.Rows[i]["sintFiyatTipiID"]));
                    if (Convert.ToInt32(dt.Rows[i]["SMREF"]) != 0)
                        dt.Rows[i]["MUSTERI"] = CariHesaplar.GetMUSTERIbySMREF(Convert.ToInt32(dt.Rows[i]["SMREF"]));
                }
            }
        }
        //
        //
        public static void GetObjectsByMusteriID(IList List, int MusteriID, bool UI)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                List.Clear();

                SqlCommand cmd = new SqlCommand("sp_INTERNET_SiparislerGetirByMusteriID", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@intMusteriID", SqlDbType.Int).Value = MusteriID;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        List.Add(new Siparisler(Convert.ToInt32(dr[0]), Convert.ToInt32(dr[1]), Convert.ToInt32(dr[4]),
                            Convert.ToInt16(dr[5]), Convert.ToDateTime(dr[6]), Convert.ToDecimal(dr[7]), Convert.ToBoolean(dr[8]), 
                            Convert.ToInt32(dr[9]), Convert.ToDateTime(dr[10]), dr[11].ToString()));
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
                SqlDataAdapter da = new SqlDataAdapter("sp_INTERNET_SiparislerGetirByMusteriID", conn);
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

                // vade, fiyat tipi ismini ve SMREF ismini yaz:
                dt.Columns.Add("VADE", typeof(string));
                dt.Columns.Add("FiyatTipi", typeof(string));
                dt.Columns.Add("MUSTERI", typeof(string));
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["VADE"] = TaksitPlanlari.GetOdemePlani(Convert.ToInt32(dt.Rows[i]["TKSREF"])).Replace("VADE", "");
                    dt.Rows[i]["FiyatTipi"] = FiyatTipleri.GetObjectByID(Convert.ToInt16(dt.Rows[i]["sintFiyatTipiID"]));
                    if (Convert.ToInt32(dt.Rows[i]["SMREF"]) != 0)
                        dt.Rows[i]["MUSTERI"] = CariHesaplar.GetMUSTERIbySMREF(Convert.ToInt32(dt.Rows[i]["SMREF"]));
                }
            }
        }
        //
        //
        public static void GetObjectsByMusteriID(DataTable dt, int MusteriID, bool HesabaGore)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_INTERNET_SiparislerGetirByMusteriID_OrderBySMREF", conn);
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

                // vade, fiyat tipi ismini ve SMREF ismini yaz:
                dt.Columns.Add("VADE", typeof(string));
                dt.Columns.Add("FiyatTipi", typeof(string));
                dt.Columns.Add("MUSTERI", typeof(string));
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["VADE"] = TaksitPlanlari.GetOdemePlani(Convert.ToInt32(dt.Rows[i]["TKSREF"])).Replace("VADE", "");
                    dt.Rows[i]["FiyatTipi"] = FiyatTipleri.GetObjectByID(Convert.ToInt16(dt.Rows[i]["sintFiyatTipiID"]));
                    if (Convert.ToInt32(dt.Rows[i]["SMREF"]) != 0)
                        dt.Rows[i]["MUSTERI"] = CariHesaplar.GetMUSTERIbySMREF(Convert.ToInt32(dt.Rows[i]["SMREF"]));
                }
            }
        }
        //
        //
        public static void GetSiparisIDToplamTutarOnaylamaTarihiByMusteriID(ListItemCollection lic, int MusteriID)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                lic.Clear();
                lic.Add(new ListItem("Seçiniz", "0"));

                SqlCommand cmd = new SqlCommand("SELECT pkSiparisID,'Sip.No: ' + CONVERT(nvarchar(MAX),pkSiparisID) + ', Tutar: ' + CONVERT(nvarchar(MAX),mnToplamTutar) + ', Onay Tarihi: ' + CONVERT(nvarchar(MAX),dtOnaylamaTarihi,103) FROM tblINTERNET_Siparisler WHERE blAktarilmis='True' AND tblINTERNET_Siparisler.intMusteriID=@intMusteriID AND dtOnaylamaTarihi >= @dtOnaylamaTarihi AND pkSiparisID NOT IN (SELECT pkSiparisID FROM tblINTERNET_Siparisler INNER JOIN tblINTERNET_Odemeler ON tblINTERNET_Siparisler.pkSiparisID = tblINTERNET_Odemeler.intSiparisID WHERE blAktarilmis='True' AND tblINTERNET_Siparisler.intMusteriID=@intMusteriID)", conn);
                cmd.Parameters.Add("@intMusteriID", SqlDbType.Int).Value = MusteriID;
                cmd.Parameters.Add("@dtOnaylamaTarihi", SqlDbType.SmallDateTime).Value = Convert.ToDateTime("01.06.2012");
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
        //
        //
        #region MusteriID
        //
        //
        #region GetSiparisCountByMusteriID
        public static int GetSiparisCountByMusteriID(int MusteriID)
        {
            int donendeger = 0;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_INTERNET_SiparislerCountByMusteriID", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@intMusteriID", SqlDbType.Int).Value = MusteriID;
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
        /// TariheGore
        /// </summary>
        public static int GetSiparisCountByMusteriID(int MusteriID, DateTime BaslangicTarih, DateTime BitisTarih, object Onayli)
        {
            int donendeger = 0;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_INTERNET_SiparislerCountByMusteriIDByDate", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@intMusteriID", SqlDbType.Int).Value = MusteriID;
                cmd.Parameters.Add("@BaslangicTarih", SqlDbType.SmallDateTime).Value = BaslangicTarih;
                cmd.Parameters.Add("@BitisTarih", SqlDbType.SmallDateTime).Value = BitisTarih;
                cmd.Parameters.Add("@blAktarilmis", SqlDbType.Bit).Value = Onayli;
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
        public static void GetObjectsByMusteriID(DataTable dt, int MusteriID, int Baslangic, int Adet)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_INTERNET_SiparislerGetirByMusteriID", conn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@intMusteriID", SqlDbType.Int).Value = MusteriID;
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

                // vade, fiyat tipi ismini ve SMREF ismini yaz:
                dt.Columns.Add("VADE", typeof(string));
                dt.Columns.Add("FiyatTipi", typeof(string));
                dt.Columns.Add("MUSTERI", typeof(string));
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["VADE"] = TaksitPlanlari.GetOdemePlani(Convert.ToInt32(dt.Rows[i]["TKSREF"])).Replace("VADE", "");
                    dt.Rows[i]["FiyatTipi"] = FiyatTipleri.GetObjectByID(Convert.ToInt16(dt.Rows[i]["sintFiyatTipiID"]));
                    if (Convert.ToInt32(dt.Rows[i]["SMREF"]) != 0)
                        dt.Rows[i]["MUSTERI"] = CariHesaplar.GetMUSTERIbySMREF(Convert.ToInt32(dt.Rows[i]["SMREF"]));
                }
            }
        }
        /// <summary>
        /// Tarihe Gore
        /// </summary>
        public static void GetObjectsByMusteriID(DataTable dt, int MusteriID, DateTime BaslangicTarih, DateTime BitisTarih, int Baslangic, int Adet, object Onayli)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_INTERNET_SiparislerGetirByMusteriIDByDate", conn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@intMusteriID", SqlDbType.Int).Value = MusteriID;
                da.SelectCommand.Parameters.Add("@BaslangicTarih", SqlDbType.SmallDateTime).Value = BaslangicTarih;
                da.SelectCommand.Parameters.Add("@BitisTarih", SqlDbType.SmallDateTime).Value = BitisTarih;
                da.SelectCommand.Parameters.Add("@blAktarilmis", SqlDbType.Bit).Value = Onayli;
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

                // vade, fiyat tipi ismini ve SMREF ismini yaz:
                dt.Columns.Add("VADE", typeof(string));
                dt.Columns.Add("FiyatTipi", typeof(string));
                dt.Columns.Add("MUSTERI", typeof(string));
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["VADE"] = TaksitPlanlari.GetOdemePlani(Convert.ToInt32(dt.Rows[i]["TKSREF"])).Replace("VADE", "");
                    dt.Rows[i]["FiyatTipi"] = FiyatTipleri.GetObjectByID(Convert.ToInt16(dt.Rows[i]["sintFiyatTipiID"]));
                    if (Convert.ToInt32(dt.Rows[i]["SMREF"]) != 0)
                        dt.Rows[i]["MUSTERI"] = CariHesaplar.GetMUSTERIbySMREF(Convert.ToInt32(dt.Rows[i]["SMREF"]));
                }
            }
        }
        #endregion
        //
        //
        #endregion
        //
        //
        #region SMREF
        //
        //
        #region GetSiparisCountBySMREF
        public static int GetSiparisCountBySMREF(int SMREF)
        {
            int donendeger = 0;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_INTERNET_SiparislerCountBySMREF", conn);
                cmd.CommandType = CommandType.StoredProcedure;
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
        /// Tarihe gore
        /// </summary>
        public static int GetSiparisCountBySMREF(int SMREF, DateTime BaslangicTarih, DateTime BitisTarih, object Onayli)
        {
            int donendeger = 0;

            string onayli = string.Empty;
            if (Onayli != DBNull.Value)
                onayli = " AND blAktarilmis = '" + Onayli.ToString() + "'";

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT count(pkSiparisID) FROM tblINTERNET_Siparisler WHERE SMREF = @SMREF AND dtOlusmaTarihi >= @BaslangicTarih AND dtOlusmaTarihi <= @BitisTarih" + onayli, conn);
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
        public static void GetObjectsBySMREF(DataTable dt, int SMREF, int Baslangic, int Adet)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_INTERNET_SiparislerGetirBySMREF", conn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@SMREF", SqlDbType.Int).Value = SMREF;
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

                // vade, fiyat tipi ismini ve SMREF ismini yaz:
                dt.Columns.Add("VADE", typeof(string));
                dt.Columns.Add("FiyatTipi", typeof(string));
                dt.Columns.Add("MUSTERI", typeof(string));
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["VADE"] = TaksitPlanlari.GetOdemePlani(Convert.ToInt32(dt.Rows[i]["TKSREF"])).Replace("VADE", "");
                    dt.Rows[i]["FiyatTipi"] = FiyatTipleri.GetObjectByID(Convert.ToInt16(dt.Rows[i]["sintFiyatTipiID"]));
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
        /// <summary>
        /// Tarihe gore
        /// </summary>
        public static void GetObjectsBySMREF(DataTable dt, int SMREF, DateTime BaslangicTarih, DateTime BitisTarih, int Baslangic, int Adet, object Onayli)
        {
            string onayli = string.Empty;
            if (Onayli != DBNull.Value)
                onayli = " AND blAktarilmis = '" + Onayli.ToString() + "'";

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT tblINTERNET_Siparisler.pkSiparisID, tblINTERNET_Siparisler.intMusteriID,tblINTERNET_Musteriler.strAd, tblINTERNET_Musteriler.strSoyad,tblINTERNET_Siparisler.SMREF,tblINTERNET_Siparisler.sintFiyatTipiID,tblINTERNET_Siparisler.dtOlusmaTarihi, tblINTERNET_Siparisler.mnToplamTutar,tblINTERNET_Siparisler.blAktarilmis, tblINTERNET_Siparisler.TKSREF, tblINTERNET_Siparisler.dtOnaylamaTarihi, tblINTERNET_Siparisler.strAciklama,(SELECT count(intSiparisID) FROM tblINTERNET_Odemeler WHERE strResponse = 'Approved' AND intSiparisID = tblINTERNET_Siparisler.pkSiparisID) AS OdemeSayisi FROM tblINTERNET_Siparisler INNER JOIN tblINTERNET_Musteriler ON tblINTERNET_Siparisler.intMusteriID = tblINTERNET_Musteriler.pkMusteriID WHERE tblINTERNET_Siparisler.dtOlusmaTarihi >= @BaslangicTarih AND tblINTERNET_Siparisler.dtOlusmaTarihi <= @BitisTarih AND tblINTERNET_Siparisler.SMREF = @SMREF" + onayli + " ORDER BY tblINTERNET_Siparisler.pkSiparisID DESC", conn);
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

                // vade, fiyat tipi ismini ve SMREF ismini yaz:
                dt.Columns.Add("VADE", typeof(string));
                dt.Columns.Add("FiyatTipi", typeof(string));
                dt.Columns.Add("MUSTERI", typeof(string));
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["VADE"] = TaksitPlanlari.GetOdemePlani(Convert.ToInt32(dt.Rows[i]["TKSREF"])).Replace("VADE", "");
                    dt.Rows[i]["FiyatTipi"] = FiyatTipleri.GetObjectByID(Convert.ToInt16(dt.Rows[i]["sintFiyatTipiID"]));
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
        #endregion
        //
        //
        #region SMREFs
        //
        //
        #region GetSiparisCountBySMREFs
        public static int GetSiparisCountBySMREFs(ArrayList SMREF)
        {
            int donendeger = 0;

            string smrefs = string.Empty;
            for (int i = 0; i < SMREF.Count; i++)
                smrefs += "tblINTERNET_Siparisler.SMREF = " + SMREF[i].ToString() + " OR ";
            if (SMREF.Count > 0)
                smrefs = smrefs.Substring(0, smrefs.Length - 3);
            else
                return 0;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT count(pkSiparisID) FROM tblINTERNET_Siparisler " +
                    "WHERE " + smrefs, conn);
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
        /// Tarihe gore
        /// </summary>
        public static int GetSiparisCountBySMREFs(ArrayList SMREF, DateTime BaslangicTarih, DateTime BitisTarih, object Onayli)
        {
            int donendeger = 0;

            string smrefs = string.Empty;
            for (int i = 0; i < SMREF.Count; i++)
                smrefs += "tblINTERNET_Siparisler.SMREF = " + SMREF[i].ToString() + " OR ";
            if (SMREF.Count > 0)
                smrefs = smrefs.Substring(0, smrefs.Length - 3);
            else
                return 0;

            string onayli = string.Empty;
            if (Onayli != DBNull.Value)
                onayli = " AND blAktarilmis = '" + Onayli.ToString() + "'";

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT count(pkSiparisID) FROM tblINTERNET_Siparisler " +
                    "WHERE dtOlusmaTarihi >= @BaslangicTarih AND " +
                    "dtOlusmaTarihi <= @BitisTarih AND (" + smrefs + ")" + onayli, conn);
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
        public static void GetObjectsBySMREFs(DataTable dt, ArrayList SMREF, int Baslangic, int Adet)
        {
            string smrefs = string.Empty;
            for (int i = 0; i < SMREF.Count; i++)
                smrefs += "tblINTERNET_Siparisler.SMREF = " + SMREF[i].ToString() + " OR ";
            if (SMREF.Count > 0)
                smrefs = smrefs.Substring(0, smrefs.Length - 3);
            else
                return;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT tblINTERNET_Siparisler.pkSiparisID, tblINTERNET_Siparisler.intMusteriID, tblINTERNET_Musteriler.strAd, tblINTERNET_Musteriler.strSoyad,tblINTERNET_Siparisler.SMREF, tblINTERNET_Siparisler.sintFiyatTipiID, tblINTERNET_Siparisler.dtOlusmaTarihi, tblINTERNET_Siparisler.mnToplamTutar, tblINTERNET_Siparisler.blAktarilmis, tblINTERNET_Siparisler.TKSREF, tblINTERNET_Siparisler.dtOnaylamaTarihi, tblINTERNET_Siparisler.strAciklama, (SELECT count(intSiparisID) FROM tblINTERNET_Odemeler WHERE strResponse = 'Approved' AND intSiparisID = tblINTERNET_Siparisler.pkSiparisID) AS OdemeSayisi FROM tblINTERNET_Siparisler INNER JOIN tblINTERNET_Musteriler ON tblINTERNET_Siparisler.intMusteriID = tblINTERNET_Musteriler.pkMusteriID " + 
                    "WHERE " + smrefs + 
                    "ORDER BY tblINTERNET_Siparisler.pkSiparisID DESC", conn);
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

                // vade, fiyat tipi ismini ve SMREF ismini yaz:
                dt.Columns.Add("VADE", typeof(string));
                dt.Columns.Add("FiyatTipi", typeof(string));
                dt.Columns.Add("MUSTERI", typeof(string));
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["VADE"] = TaksitPlanlari.GetOdemePlani(Convert.ToInt32(dt.Rows[i]["TKSREF"])).Replace("VADE", "");
                    dt.Rows[i]["FiyatTipi"] = FiyatTipleri.GetObjectByID(Convert.ToInt16(dt.Rows[i]["sintFiyatTipiID"]));
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
        /// <summary>
        /// Tarihe gore
        /// </summary>
        public static void GetObjectsBySMREFs(DataTable dt, ArrayList SMREF, DateTime BaslangicTarih, DateTime BitisTarih, int Baslangic, int Adet, object Onayli)
        {
            string smrefs = string.Empty;
            for (int i = 0; i < SMREF.Count; i++)
                smrefs += "tblINTERNET_Siparisler.SMREF = " + SMREF[i].ToString() + " OR ";
            if (SMREF.Count > 0)
                smrefs = smrefs.Substring(0, smrefs.Length - 3);
            else
                return;

            string onayli = string.Empty;
            if (Onayli != DBNull.Value)
                onayli = " AND blAktarilmis = '" + Onayli.ToString() + "'";

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT tblINTERNET_Siparisler.pkSiparisID, tblINTERNET_Siparisler.intMusteriID, tblINTERNET_Musteriler.strAd, tblINTERNET_Musteriler.strSoyad,tblINTERNET_Siparisler.SMREF, tblINTERNET_Siparisler.sintFiyatTipiID, tblINTERNET_Siparisler.dtOlusmaTarihi, tblINTERNET_Siparisler.mnToplamTutar, tblINTERNET_Siparisler.blAktarilmis, tblINTERNET_Siparisler.TKSREF, tblINTERNET_Siparisler.dtOnaylamaTarihi, tblINTERNET_Siparisler.strAciklama, (SELECT count(intSiparisID) FROM tblINTERNET_Odemeler WHERE strResponse = 'Approved' AND intSiparisID = tblINTERNET_Siparisler.pkSiparisID) AS OdemeSayisi FROM tblINTERNET_Siparisler INNER JOIN tblINTERNET_Musteriler ON tblINTERNET_Siparisler.intMusteriID = tblINTERNET_Musteriler.pkMusteriID " +
                    "WHERE tblINTERNET_Siparisler.dtOlusmaTarihi >= @BaslangicTarih AND " +
                    "tblINTERNET_Siparisler.dtOlusmaTarihi <= @BitisTarih AND (" 
                    + smrefs +
                    ") " + onayli + " ORDER BY tblINTERNET_Siparisler.pkSiparisID DESC", conn);
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

                // vade, fiyat tipi ismini ve SMREF ismini yaz:
                dt.Columns.Add("VADE", typeof(string));
                dt.Columns.Add("FiyatTipi", typeof(string));
                dt.Columns.Add("MUSTERI", typeof(string));
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["VADE"] = TaksitPlanlari.GetOdemePlani(Convert.ToInt32(dt.Rows[i]["TKSREF"])).Replace("VADE", "");
                    dt.Rows[i]["FiyatTipi"] = FiyatTipleri.GetObjectByID(Convert.ToInt16(dt.Rows[i]["sintFiyatTipiID"]));
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
        #endregion
        //
        //
        #region SMREFMusteriID
        //
        //
        #region GetSiparisCountBySMREFsMusteriID
        /// <summary>
        /// Tarihe gore
        /// </summary>
        public static int GetSiparisCountBySMREFMusteriID(int SMREF, int MusteriID, DateTime BaslangicTarih, DateTime BitisTarih, object Onayli)
        {
            int donendeger = 0;

            string onayli = string.Empty;
            if (Onayli != DBNull.Value)
                onayli = " AND blAktarilmis = '" + Onayli.ToString() + "'";

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT count(pkSiparisID) FROM tblINTERNET_Siparisler " +
                    "WHERE dtOlusmaTarihi >= @BaslangicTarih AND " +
                    "dtOlusmaTarihi <= @BitisTarih AND intMusteriID = @MusteriID AND SMREF = @SMREF" + onayli, conn);
                cmd.Parameters.Add("@BaslangicTarih", SqlDbType.SmallDateTime).Value = BaslangicTarih;
                cmd.Parameters.Add("@BitisTarih", SqlDbType.SmallDateTime).Value = BitisTarih;
                cmd.Parameters.Add("@MusteriID", SqlDbType.Int).Value = MusteriID;
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
        #endregion
        //
        //
        #region GetObjectsBySMREFMusteriID
        /// <summary>
        /// Tarihe gore
        /// </summary>
        public static void GetObjectsBySMREFMusteriID(DataTable dt, int SMREF, int MusteriID, DateTime BaslangicTarih, DateTime BitisTarih, int Baslangic, int Adet, object Onayli)
        {
            string onayli = string.Empty;
            if (Onayli != DBNull.Value)
                onayli = " AND blAktarilmis = '" + Onayli.ToString() + "'";

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT tblINTERNET_Siparisler.pkSiparisID, tblINTERNET_Siparisler.intMusteriID, tblINTERNET_Musteriler.strAd, tblINTERNET_Musteriler.strSoyad,tblINTERNET_Siparisler.SMREF, tblINTERNET_Siparisler.sintFiyatTipiID, tblINTERNET_Siparisler.dtOlusmaTarihi, tblINTERNET_Siparisler.mnToplamTutar, tblINTERNET_Siparisler.blAktarilmis, tblINTERNET_Siparisler.TKSREF, tblINTERNET_Siparisler.dtOnaylamaTarihi, tblINTERNET_Siparisler.strAciklama, (SELECT count(intSiparisID) FROM tblINTERNET_Odemeler WHERE strResponse = 'Approved' AND intSiparisID = tblINTERNET_Siparisler.pkSiparisID) AS OdemeSayisi FROM tblINTERNET_Siparisler INNER JOIN tblINTERNET_Musteriler ON tblINTERNET_Siparisler.intMusteriID = tblINTERNET_Musteriler.pkMusteriID " +
                    "WHERE tblINTERNET_Siparisler.dtOlusmaTarihi >= @BaslangicTarih AND " +
                    "tblINTERNET_Siparisler.dtOlusmaTarihi <= @BitisTarih AND intMusteriID = @MusteriID AND " +
                    "tblINTERNET_Siparisler.SMREF = @SMREF" +
                    onayli + " ORDER BY tblINTERNET_Siparisler.pkSiparisID DESC", conn);
                da.SelectCommand.Parameters.Add("@BaslangicTarih", SqlDbType.SmallDateTime).Value = BaslangicTarih;
                da.SelectCommand.Parameters.Add("@BitisTarih", SqlDbType.SmallDateTime).Value = BitisTarih;
                da.SelectCommand.Parameters.Add("@MusteriID", SqlDbType.Int).Value = MusteriID;
                da.SelectCommand.Parameters.Add("@SMREF", SqlDbType.Int).Value = SMREF;
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

                // vade, fiyat tipi ismini ve SMREF ismini yaz:
                dt.Columns.Add("VADE", typeof(string));
                dt.Columns.Add("FiyatTipi", typeof(string));
                dt.Columns.Add("MUSTERI", typeof(string));
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["VADE"] = TaksitPlanlari.GetOdemePlani(Convert.ToInt32(dt.Rows[i]["TKSREF"])).Replace("VADE", "");
                    dt.Rows[i]["FiyatTipi"] = FiyatTipleri.GetObjectByID(Convert.ToInt16(dt.Rows[i]["sintFiyatTipiID"]));
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
        #endregion
        //
        //
        #region SMREFsMusteriID
        //
        //
        #region GetSiparisCountBySMREFsMusteriID
        /// <summary>
        /// Tarihe gore
        /// </summary>
        public static int GetSiparisCountBySMREFsMusteriID(ArrayList SMREF, int MusteriID, DateTime BaslangicTarih, DateTime BitisTarih, object Onayli)
        {
            int donendeger = 0;

            string smrefs = string.Empty;
            for (int i = 0; i < SMREF.Count; i++)
                smrefs += "tblINTERNET_Siparisler.SMREF = " + SMREF[i].ToString() + " OR ";
            if (SMREF.Count > 0)
                smrefs = smrefs.Substring(0, smrefs.Length - 3);
            else
                return 0;

            string onayli = string.Empty;
            if (Onayli != DBNull.Value)
                onayli = " AND blAktarilmis = '" + Onayli.ToString() + "'";

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT count(pkSiparisID) FROM tblINTERNET_Siparisler " +
                    "WHERE dtOlusmaTarihi >= @BaslangicTarih AND " +
                    "dtOlusmaTarihi <= @BitisTarih AND intMusteriID = @MusteriID AND (" + smrefs + ")" + onayli, conn);
                cmd.Parameters.Add("@BaslangicTarih", SqlDbType.SmallDateTime).Value = BaslangicTarih;
                cmd.Parameters.Add("@BitisTarih", SqlDbType.SmallDateTime).Value = BitisTarih;
                cmd.Parameters.Add("@MusteriID", SqlDbType.Int).Value = MusteriID;
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
        #region GetObjectsBySMREFsMusteriID
        /// <summary>
        /// Tarihe gore
        /// </summary>
        public static void GetObjectsBySMREFsMusteriID(DataTable dt, ArrayList SMREF, int MusteriID, DateTime BaslangicTarih, DateTime BitisTarih, int Baslangic, int Adet, object Onayli)
        {
            string smrefs = string.Empty;
            for (int i = 0; i < SMREF.Count; i++)
                smrefs += "tblINTERNET_Siparisler.SMREF = " + SMREF[i].ToString() + " OR ";
            if (SMREF.Count > 0)
                smrefs = smrefs.Substring(0, smrefs.Length - 3);
            else
                return;

            string onayli = string.Empty;
            if (Onayli != DBNull.Value)
                onayli = " AND blAktarilmis = '" + Onayli.ToString() + "'";

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT tblINTERNET_Siparisler.pkSiparisID, tblINTERNET_Siparisler.intMusteriID, tblINTERNET_Musteriler.strAd, tblINTERNET_Musteriler.strSoyad,tblINTERNET_Siparisler.SMREF, tblINTERNET_Siparisler.sintFiyatTipiID, tblINTERNET_Siparisler.dtOlusmaTarihi, tblINTERNET_Siparisler.mnToplamTutar, tblINTERNET_Siparisler.blAktarilmis, tblINTERNET_Siparisler.TKSREF, tblINTERNET_Siparisler.dtOnaylamaTarihi, tblINTERNET_Siparisler.strAciklama, (SELECT count(intSiparisID) FROM tblINTERNET_Odemeler WHERE strResponse = 'Approved' AND intSiparisID = tblINTERNET_Siparisler.pkSiparisID) AS OdemeSayisi FROM tblINTERNET_Siparisler INNER JOIN tblINTERNET_Musteriler ON tblINTERNET_Siparisler.intMusteriID = tblINTERNET_Musteriler.pkMusteriID " +
                    "WHERE tblINTERNET_Siparisler.dtOlusmaTarihi >= @BaslangicTarih AND " +
                    "tblINTERNET_Siparisler.dtOlusmaTarihi <= @BitisTarih AND intMusteriID = @MusteriID AND ("
                    + smrefs +
                    ") " + onayli + " ORDER BY tblINTERNET_Siparisler.pkSiparisID DESC", conn);
                da.SelectCommand.Parameters.Add("@BaslangicTarih", SqlDbType.SmallDateTime).Value = BaslangicTarih;
                da.SelectCommand.Parameters.Add("@BitisTarih", SqlDbType.SmallDateTime).Value = BitisTarih;
                da.SelectCommand.Parameters.Add("@MusteriID", SqlDbType.Int).Value = MusteriID;
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

                // vade, fiyat tipi ismini ve SMREF ismini yaz:
                dt.Columns.Add("VADE", typeof(string));
                dt.Columns.Add("FiyatTipi", typeof(string));
                dt.Columns.Add("MUSTERI", typeof(string));
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["VADE"] = TaksitPlanlari.GetOdemePlani(Convert.ToInt32(dt.Rows[i]["TKSREF"])).Replace("VADE", "");
                    dt.Rows[i]["FiyatTipi"] = FiyatTipleri.GetObjectByID(Convert.ToInt16(dt.Rows[i]["sintFiyatTipiID"]));
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
        #endregion
        //
        //
        #region SMREFsMusteriIDs
        //
        //
        #region GetSiparisCountBySMREFsMusteriIDs
        /// <summary>
        /// Tarihe gore
        /// </summary>
        public static int GetSiparisCountBySMREFsMusteriIDs(ArrayList SMREF, ArrayList MusteriID, DateTime BaslangicTarih, DateTime BitisTarih, object Onayli)
        {
            int donendeger = 0;

            string smrefs = string.Empty;
            for (int i = 0; i < SMREF.Count; i++)
                smrefs += "tblINTERNET_Siparisler.SMREF = " + SMREF[i].ToString() + " OR ";
            if (SMREF.Count > 0)
                smrefs = smrefs.Substring(0, smrefs.Length - 3);
            else
                return 0;

            string musteriids = string.Empty;
            for (int i = 0; i < MusteriID.Count; i++)
                musteriids += "tblINTERNET_Siparisler.intMusteriID = " + MusteriID[i].ToString() + " OR ";
            if (MusteriID.Count > 0)
                musteriids = musteriids.Substring(0, musteriids.Length - 3);
            else
                return 0;

            string onayli = string.Empty;
            if (Onayli != DBNull.Value)
                onayli = " AND blAktarilmis = '" + Onayli.ToString() + "'";

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT count(pkSiparisID) FROM tblINTERNET_Siparisler " +
                    "WHERE dtOlusmaTarihi >= @BaslangicTarih AND " +
                    "dtOlusmaTarihi <= @BitisTarih AND (" + musteriids + ") AND (" + smrefs + ")" + onayli, conn);
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
        #region GetObjectsBySMREFsMusteriIDs
        /// <summary>
        /// Tarihe gore
        /// </summary>
        public static void GetObjectsBySMREFsMusteriIDs(DataTable dt, ArrayList SMREF, ArrayList MusteriID, DateTime BaslangicTarih, DateTime BitisTarih, int Baslangic, int Adet, object Onayli)
        {
            string smrefs = string.Empty;
            for (int i = 0; i < SMREF.Count; i++)
                smrefs += "tblINTERNET_Siparisler.SMREF = " + SMREF[i].ToString() + " OR ";
            if (SMREF.Count > 0)
                smrefs = smrefs.Substring(0, smrefs.Length - 3);
            else
                return;

            string musteriids = string.Empty;
            for (int i = 0; i < MusteriID.Count; i++)
                musteriids += "tblINTERNET_Siparisler.intMusteriID = " + MusteriID[i].ToString() + " OR ";
            if (MusteriID.Count > 0)
                musteriids = musteriids.Substring(0, musteriids.Length - 3);
            else
                return;

            string onayli = string.Empty;
            if (Onayli != DBNull.Value)
                onayli = " AND blAktarilmis = '" + Onayli.ToString() + "'";

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT tblINTERNET_Siparisler.pkSiparisID, tblINTERNET_Siparisler.intMusteriID, tblINTERNET_Musteriler.strAd, tblINTERNET_Musteriler.strSoyad,tblINTERNET_Siparisler.SMREF, tblINTERNET_Siparisler.sintFiyatTipiID, tblINTERNET_Siparisler.dtOlusmaTarihi, tblINTERNET_Siparisler.mnToplamTutar, tblINTERNET_Siparisler.blAktarilmis, tblINTERNET_Siparisler.TKSREF, tblINTERNET_Siparisler.dtOnaylamaTarihi, tblINTERNET_Siparisler.strAciklama, (SELECT count(intSiparisID) FROM tblINTERNET_Odemeler WHERE strResponse = 'Approved' AND intSiparisID = tblINTERNET_Siparisler.pkSiparisID) AS OdemeSayisi FROM tblINTERNET_Siparisler INNER JOIN tblINTERNET_Musteriler ON tblINTERNET_Siparisler.intMusteriID = tblINTERNET_Musteriler.pkMusteriID " +
                    "WHERE tblINTERNET_Siparisler.dtOlusmaTarihi >= @BaslangicTarih AND " +
                    "tblINTERNET_Siparisler.dtOlusmaTarihi <= @BitisTarih AND (" + musteriids + ")  AND (" + smrefs + ") " + 
                    onayli + " ORDER BY tblINTERNET_Siparisler.pkSiparisID DESC", conn);
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

                // vade, fiyat tipi ismini ve SMREF ismini yaz:
                dt.Columns.Add("VADE", typeof(string));
                dt.Columns.Add("FiyatTipi", typeof(string));
                dt.Columns.Add("MUSTERI", typeof(string));
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["VADE"] = TaksitPlanlari.GetOdemePlani(Convert.ToInt32(dt.Rows[i]["TKSREF"])).Replace("VADE", "");
                    dt.Rows[i]["FiyatTipi"] = FiyatTipleri.GetObjectByID(Convert.ToInt16(dt.Rows[i]["sintFiyatTipiID"]));
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
        #endregion
        //
        //
        #region ToplamTutarlar
        /// <summary>
        /// Tarihe gore
        /// </summary>
        public static decimal GetSiparislerToplamBySMREF(int SMREF, DateTime BaslangicTarih, DateTime BitisTarih, object Onayli)
        {
            decimal donendeger = 0;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_INTERNET_SiparislerToplamBySMREFByDate", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@SMREF", SqlDbType.Int).Value = SMREF;
                cmd.Parameters.Add("@BaslangicTarih", SqlDbType.SmallDateTime).Value = BaslangicTarih;
                cmd.Parameters.Add("@BitisTarih", SqlDbType.SmallDateTime).Value = BitisTarih;
                cmd.Parameters.Add("@blAktarilmis", SqlDbType.Bit).Value = Onayli;
                try
                {
                    conn.Open();
                    object toplam = cmd.ExecuteScalar();
                    if (toplam != DBNull.Value)
                        donendeger = Convert.ToDecimal(cmd.ExecuteScalar());
                }
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
        public static decimal GetSiparislerToplamBySMREFs(ArrayList SMREF, DateTime BaslangicTarih, DateTime BitisTarih, object Onayli)
        {
            decimal donendeger = 0;

            string smrefs = string.Empty;
            for (int i = 0; i < SMREF.Count; i++)
                smrefs += "tblINTERNET_Siparisler.SMREF = " + SMREF[i].ToString() + " OR ";
            if (SMREF.Count > 0)
                smrefs = smrefs.Substring(0, smrefs.Length - 3);
            else
                return 0;

            string onayli = string.Empty;
            if (Onayli != DBNull.Value)
                onayli = " AND blAktarilmis = '" + Onayli.ToString() + "'";

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT sum(mnToplamTutar) FROM tblINTERNET_Siparisler " +
                    "WHERE dtOlusmaTarihi >= @BaslangicTarih AND " +
                    "dtOlusmaTarihi <= @BitisTarih AND (" + smrefs + ")" + onayli, conn);
                cmd.Parameters.Add("@BaslangicTarih", SqlDbType.SmallDateTime).Value = BaslangicTarih;
                cmd.Parameters.Add("@BitisTarih", SqlDbType.SmallDateTime).Value = BitisTarih;
                try
                {
                    conn.Open();
                    object toplam = cmd.ExecuteScalar();
                    if (toplam != DBNull.Value)
                        donendeger = Convert.ToDecimal(cmd.ExecuteScalar());
                }
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
        public static decimal GetSiparislerToplamByMusteriID(int MusteriID, DateTime BaslangicTarih, DateTime BitisTarih, object Onayli)
        {
            decimal donendeger = 0;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_INTERNET_SiparislerToplamByMusteriIDByDate", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@intMusteriID", SqlDbType.Int).Value = MusteriID;
                cmd.Parameters.Add("@BaslangicTarih", SqlDbType.SmallDateTime).Value = BaslangicTarih;
                cmd.Parameters.Add("@BitisTarih", SqlDbType.SmallDateTime).Value = BitisTarih;
                cmd.Parameters.Add("@blAktarilmis", SqlDbType.Bit).Value = Onayli;
                try
                {
                    conn.Open();
                    object toplam = cmd.ExecuteScalar();
                    if (toplam != DBNull.Value)
                        donendeger = Convert.ToDecimal(cmd.ExecuteScalar());
                }
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
        public static decimal GetSiparislerToplam(DateTime BaslangicTarih, DateTime BitisTarih, object Onayli)
        {
            decimal donendeger = 0;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_INTERNET_SiparislerToplamByDate", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@BaslangicTarih", SqlDbType.SmallDateTime).Value = BaslangicTarih;
                cmd.Parameters.Add("@BitisTarih", SqlDbType.SmallDateTime).Value = BitisTarih;
                cmd.Parameters.Add("@blAktarilmis", SqlDbType.Bit).Value = Onayli;
                try
                {
                    conn.Open();
                    object toplam = cmd.ExecuteScalar();
                    if (toplam != DBNull.Value)
                        donendeger = Convert.ToDecimal(cmd.ExecuteScalar());
                }
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
        public static decimal GetSiparislerToplamBySMREFMusteriID(int SMREF, int MusteriID, DateTime BaslangicTarih, DateTime BitisTarih, object Onayli)
        {
            decimal donendeger = 0;

            string onayli = string.Empty;
            if (Onayli != DBNull.Value)
                onayli = " AND blAktarilmis = '" + Onayli.ToString() + "'";

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT sum(mnToplamTutar) FROM tblINTERNET_Siparisler " +
                    "WHERE dtOlusmaTarihi >= @BaslangicTarih AND " +
                    "dtOlusmaTarihi <= @BitisTarih AND intMusteriID = @MusteriID AND SMREF = @SMREF" + onayli, conn);
                cmd.Parameters.Add("@BaslangicTarih", SqlDbType.SmallDateTime).Value = BaslangicTarih;
                cmd.Parameters.Add("@BitisTarih", SqlDbType.SmallDateTime).Value = BitisTarih;
                cmd.Parameters.Add("@MusteriID", SqlDbType.Int).Value = MusteriID;
                cmd.Parameters.Add("@SMREF", SqlDbType.Int).Value = SMREF;
                try
                {
                    conn.Open();
                    object toplam = cmd.ExecuteScalar();
                    if (toplam != DBNull.Value)
                        donendeger = Convert.ToDecimal(cmd.ExecuteScalar());
                }
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
        public static decimal GetSiparislerToplamBySMREFsMusteriID(ArrayList SMREF, int MusteriID, DateTime BaslangicTarih, DateTime BitisTarih, object Onayli)
        {
            decimal donendeger = 0;

            string smrefs = string.Empty;
            for (int i = 0; i < SMREF.Count; i++)
                smrefs += "tblINTERNET_Siparisler.SMREF = " + SMREF[i].ToString() + " OR ";
            if (SMREF.Count > 0)
                smrefs = smrefs.Substring(0, smrefs.Length - 3);
            else
                return 0;

            string onayli = string.Empty;
            if (Onayli != DBNull.Value)
                onayli = " AND blAktarilmis = '" + Onayli.ToString() + "'";

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT sum(mnToplamTutar) FROM tblINTERNET_Siparisler " +
                    "WHERE dtOlusmaTarihi >= @BaslangicTarih AND " +
                    "dtOlusmaTarihi <= @BitisTarih AND intMusteriID = @MusteriID AND (" + smrefs + ")" + onayli, conn);
                cmd.Parameters.Add("@BaslangicTarih", SqlDbType.SmallDateTime).Value = BaslangicTarih;
                cmd.Parameters.Add("@BitisTarih", SqlDbType.SmallDateTime).Value = BitisTarih;
                cmd.Parameters.Add("@MusteriID", SqlDbType.Int).Value = MusteriID;
                try
                {
                    conn.Open();
                    object toplam = cmd.ExecuteScalar();
                    if (toplam != DBNull.Value)
                        donendeger = Convert.ToDecimal(cmd.ExecuteScalar());
                }
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
        public static decimal GetSiparislerToplamBySMREFsMusteriIDs(ArrayList SMREF, ArrayList MusteriID, DateTime BaslangicTarih, DateTime BitisTarih, object Onayli)
        {
            decimal donendeger = 0;

            string smrefs = string.Empty;
            for (int i = 0; i < SMREF.Count; i++)
                smrefs += "tblINTERNET_Siparisler.SMREF = " + SMREF[i].ToString() + " OR ";
            if (SMREF.Count > 0)
                smrefs = smrefs.Substring(0, smrefs.Length - 3);
            else
                return 0;

            string musteriids = string.Empty;
            for (int i = 0; i < MusteriID.Count; i++)
                musteriids += "tblINTERNET_Siparisler.intMusteriID = " + MusteriID[i].ToString() + " OR ";
            if (MusteriID.Count > 0)
                musteriids = musteriids.Substring(0, musteriids.Length - 3);
            else
                return 0;

            string onayli = string.Empty;
            if (Onayli != DBNull.Value)
                onayli = " AND blAktarilmis = '" + Onayli.ToString() + "'";

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT sum(mnToplamTutar) FROM tblINTERNET_Siparisler " +
                    "WHERE dtOlusmaTarihi >= @BaslangicTarih AND " +
                    "dtOlusmaTarihi <= @BitisTarih AND (" + musteriids + ") AND (" + smrefs + ")" + onayli, conn);
                cmd.Parameters.Add("@BaslangicTarih", SqlDbType.SmallDateTime).Value = BaslangicTarih;
                cmd.Parameters.Add("@BitisTarih", SqlDbType.SmallDateTime).Value = BitisTarih;
                try
                {
                    conn.Open();
                    object toplam = cmd.ExecuteScalar();
                    if (toplam != DBNull.Value)
                        donendeger = Convert.ToDecimal(cmd.ExecuteScalar());
                }
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
        public static bool QuantumaYazildiMi(int SiparisID)
        {
            bool donendeger = false;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT count(*) FROM [QUANTUMNET].[dbo].[SATIS_SIPARIS_KART] WHERE [ACIKLAMA4] LIKE 'Web%' AND SUBSTRING([QUANTUMNET].[dbo].[SATIS_SIPARIS_KART].[ACIKLAMA4], 17, 7) = '" +  SiparisID.ToString() + "'", conn);
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
        public static bool QuantumaYazildiMi(string SiparisNo)
        {
            bool donendeger = false;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT count(*) FROM [QUANTUMNET].[dbo].[SATIS_SIPARIS_KART] WHERE [ACIKLAMA4] LIKE 'Web%' AND KARTNO = '" + SiparisNo + "'", conn);
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
        public static void DoInsertQ(int SiparisID, string QUANTUMNO, bool BAKIYE, string MTKOD)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                bool varmi = false;
                SqlCommand cmd1 = new SqlCommand("SELECT count(*) FROM tblINTERNET_SiparislerQ WHERE intSiparisID = @intSiparisID", conn);
                cmd1.Parameters.Add("@intSiparisID", SqlDbType.Int).Value = SiparisID;

                SqlCommand cmd = new SqlCommand("INSERT INTO tblINTERNET_SiparislerQ (intSiparisID,QUANTUMNO,BAKIYE,MTKOD) VALUES (@intSiparisID,@QUANTUMNO,@BAKIYE,@MTKOD)", conn);
                cmd.Parameters.Add("@intSiparisID", SqlDbType.Int).Value = SiparisID;
                cmd.Parameters.Add("@QUANTUMNO", SqlDbType.NVarChar, 50).Value = QUANTUMNO;
                cmd.Parameters.Add("@BAKIYE", SqlDbType.Bit).Value = BAKIYE;
                cmd.Parameters.Add("@MTKOD", SqlDbType.NVarChar, 50).Value = MTKOD;
                try
                {
                    conn.Open();
                    varmi = Convert.ToBoolean(cmd1.ExecuteScalar());
                    if (varmi)
                    {
                        cmd.CommandText = "UPDATE tblINTERNET_SiparislerQ SET QUANTUMNO = @QUANTUMNO,BAKIYE = @BAKIYE,MTKOD = @MTKOD WHERE intSiparisID = @intSiparisID";
                    }
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
        public static void DoDeleteQ(int SiparisID)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM tblINTERNET_SiparislerQ WHERE intSiparisID = @intSiparisID", conn);
                cmd.Parameters.Add("@intSiparisID", SqlDbType.Int).Value = SiparisID;
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
        public static string GetQ(int SiparisID)
        {
            string donendeger = string.Empty;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT QUANTUMNO FROM tblINTERNET_SiparislerQ WHERE intSiparisID=@intSiparisID", conn);
                cmd.Parameters.Add("@intSiparisID", SqlDbType.Int).Value = SiparisID;
                try
                {
                    conn.Open();
                    object obj = cmd.ExecuteScalar();
                    if (obj != null) donendeger = obj.ToString();
                }
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
        public static void DoInsertOffOnLog(int SiparisID, bool Offline, bool ButunUrunler)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO tblINTERNET_SiparislerOffOnLog (intSiparisID,blOffline,blButunUrunler) VALUES (@intSiparisID,@blOffline,@blButunUrunler)", conn);
                cmd.Parameters.Add("@intSiparisID", SqlDbType.Int).Value = SiparisID;
                cmd.Parameters.Add("@blOffline", SqlDbType.Bit).Value = Offline;
                cmd.Parameters.Add("@blButunUrunler", SqlDbType.Bit).Value = ButunUrunler;
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
        public static void GetSAPsiparisler(DataTable dt, int SLSREF)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT [Vbeln],[Erdat],[OKunnr],[OName1],[Kunnr],[Name1],[Vtext2],[Comm Text],[Pltyp],[Sip Aciklama],[Burut],[Isk],[Net],[Ad],[Koli] FROM [SAP_SIPARIS_BASLIK] WHERE YEAR(Erdat) = 2017 AND [Sipalan Kod] = @SLSREF", conn);
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
}

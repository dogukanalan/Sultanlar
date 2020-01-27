using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Sultanlar.DatabaseObject.Internet
{
    public class DisSiparisler : ISultanlar, IDisposable
    {
        //
        //
        //
        // Alanlar:
        //
        private int _pkID;
        private byte _tintSirketID;
        private string _strTC;
        private long _bintDisKod;
        private string _strDisNo;
        private DateTime _dtDisOlusmaTarihi;
        private DateTime _dtOlusmaTarihi;
        private short _sintOdemeTipi;
        private short _sintDurum;
        private decimal _mnTutar;
        private string _strEposta;
        private string _strFaturaAdresi;
        private string _strFaturaSehir;
        private string _strFaturaIlce;
        private string _strFaturaPostaKodu;
        private string _strFaturaAdSoyad;
        private string _strFaturaGSM;
        private long _bintDisMusteriKodu;
        private long _bintKargoKodu;
        private long _bintKargoSirketiKodu;
        private string _strKargoSirketi;
        private string _strKargoAdresi;
        private string _strKargoSehir;
        private string _strKargoIlce;
        private string _strKargoPostaKodu;
        private string _strKargoAdSoyad;
        private string _strKargoGSM;
        private string _strKargoTakip;
        //
        //
        //
        // Constracter lar:
        //
        private DisSiparisler(int pkID, byte tintSirketID, string strTC, long bintDisKod, string strDisNo, DateTime dtDisOlusmaTarihi,
            DateTime dtOlusmaTarihi, short sintOdemeTipi, short sintDurum, decimal mnTutar, string strEposta, string strFaturaAdresi,
            string strFaturaSehir, string strFaturaIlce, string strFaturaPostaKodu, string strFaturaAdSoyad, string strFaturaGSM,
            long bintDisMusteriKodu, long bintKargoKodu, long bintKargoSirketiKodu, string strKargoSirketi, string strKargoAdresi,
            string strKargoSehir, string strKargoIlce, string strKargoPostaKodu, string strKargoAdSoyad, string strKargoGSM, string strKargoTakip)
        {
            this._pkID = pkID;
            this._tintSirketID = tintSirketID;
            this._strTC = strTC;
            this._bintDisKod = bintDisKod;
            this._strDisNo = strDisNo;
            this._dtDisOlusmaTarihi = dtDisOlusmaTarihi;
            this._dtOlusmaTarihi = dtOlusmaTarihi;
            this._sintOdemeTipi = sintOdemeTipi;
            this._sintDurum = sintDurum;
            this._mnTutar = mnTutar;
            this._strEposta = strEposta;
            this._strFaturaAdresi = strFaturaAdresi;
            this._strFaturaSehir = strFaturaSehir;
            this._strFaturaIlce = strFaturaIlce;
            this._strFaturaPostaKodu = strFaturaPostaKodu;
            this._strFaturaAdSoyad = strFaturaAdSoyad;
            this._strFaturaGSM = strFaturaGSM;
            this._bintDisMusteriKodu = bintDisMusteriKodu;
            this._bintKargoKodu = bintKargoKodu;
            this._bintKargoSirketiKodu = bintKargoSirketiKodu;
            this._strKargoSirketi = strKargoSirketi;
            this._strKargoAdresi = strKargoAdresi;
            this._strKargoSehir = strKargoSehir;
            this._strKargoIlce = strKargoIlce;
            this._strKargoPostaKodu = strKargoPostaKodu;
            this._strKargoAdSoyad = strKargoAdSoyad;
            this._strKargoGSM = strKargoGSM;
            this._strKargoTakip = strKargoTakip;
        }
        //
        //
        public DisSiparisler(byte tintSirketID, string strTC, long bintDisKod, string strDisNo, DateTime dtDisOlusmaTarihi,
            DateTime dtOlusmaTarihi, short sintOdemeTipi, short sintDurum, decimal mnTutar, string strEposta, string strFaturaAdresi,
            string strFaturaSehir, string strFaturaIlce, string strFaturaPostaKodu, string strFaturaAdSoyad, string strFaturaGSM,
            long bintDisMusteriKodu, long bintKargoKodu, long bintKargoSirketiKodu, string strKargoSirketi, string strKargoAdresi,
            string strKargoSehir, string strKargoIlce, string strKargoPostaKodu, string strKargoAdSoyad, string strKargoGSM, string strKargoTakip)
        {
            this._tintSirketID = tintSirketID;
            this._strTC = strTC;
            this._bintDisKod = bintDisKod;
            this._strDisNo = strDisNo;
            this._dtDisOlusmaTarihi = dtDisOlusmaTarihi;
            this._dtOlusmaTarihi = dtOlusmaTarihi;
            this._sintOdemeTipi = sintOdemeTipi;
            this._sintDurum = sintDurum;
            this._mnTutar = mnTutar;
            this._strEposta = strEposta;
            this._strFaturaAdresi = strFaturaAdresi;
            this._strFaturaSehir = strFaturaSehir;
            this._strFaturaIlce = strFaturaIlce;
            this._strFaturaPostaKodu = strFaturaPostaKodu;
            this._strFaturaAdSoyad = strFaturaAdSoyad;
            this._strFaturaGSM = strFaturaGSM;
            this._bintDisMusteriKodu = bintDisMusteriKodu;
            this._bintKargoKodu = bintKargoKodu;
            this._bintKargoSirketiKodu = bintKargoSirketiKodu;
            this._strKargoSirketi = strKargoSirketi;
            this._strKargoAdresi = strKargoAdresi;
            this._strKargoSehir = strKargoSehir;
            this._strKargoIlce = strKargoIlce;
            this._strKargoPostaKodu = strKargoPostaKodu;
            this._strKargoAdSoyad = strKargoAdSoyad;
            this._strKargoGSM = strKargoGSM;
            this._strKargoTakip = strKargoTakip;
        }
        //
        //
        private DisSiparisler()
        {

        }
        //
        //
        //
        // Özellikler:
        //
        public int pkID { get { return this._pkID; } }
        public byte tintSirketID { get { return this._tintSirketID; } set { this._tintSirketID = value; } }
        public string strTC { get { return this._strTC; } set { this._strTC = value; } }
        public long bintDisKod { get { return this._bintDisKod; } set { this._bintDisKod = value; } }
        public string strDisNo { get { return this._strDisNo; } set { this._strDisNo = value; } }
        public DateTime dtDisOlusmaTarihi { get { return this._dtDisOlusmaTarihi; } set { this._dtDisOlusmaTarihi = value; } }
        public DateTime dtOlusmaTarihi { get { return this._dtOlusmaTarihi; } set { this._dtOlusmaTarihi = value; } }
        public short sintOdemeTipi { get { return this._sintOdemeTipi; } set { this._sintOdemeTipi = value; } }
        public short sintDurum { get { return this._sintDurum; } set { this._sintDurum = value; } }
        public decimal mnTutar { get { return this._mnTutar; } set { this._mnTutar = value; } }
        public string strEposta { get { return this._strEposta; } set { this._strEposta = value; } }
        public string strFaturaAdresi { get { return this._strFaturaAdresi; } set { this._strFaturaAdresi = value; } }
        public string strFaturaSehir { get { return this._strFaturaSehir; } set { this._strFaturaSehir = value; } }
        public string strFaturaIlce { get { return this._strFaturaIlce; } set { this._strFaturaIlce = value; } }
        public string strFaturaPostaKodu { get { return this._strFaturaPostaKodu; } set { this._strFaturaPostaKodu = value; } }
        public string strFaturaAdSoyad { get { return this._strFaturaAdSoyad; } set { this._strFaturaAdSoyad = value; } }
        public string strFaturaGSM { get { return this._strFaturaGSM; } set { this._strFaturaGSM = value; } }
        public long bintDisMusteriKodu { get { return this._bintDisMusteriKodu; } set { this._bintDisMusteriKodu = value; } }
        public long bintKargoKodu { get { return this._bintKargoKodu; } set { this._bintKargoKodu = value; } }
        public long bintKargoSirketiKodu { get { return this._bintKargoSirketiKodu; } set { this._bintKargoSirketiKodu = value; } }
        public string strKargoSirketi { get { return this._strKargoSirketi; } set { this._strKargoSirketi = value; } }
        public string strKargoAdresi { get { return this._strKargoAdresi; } set { this._strKargoAdresi = value; } }
        public string strKargoSehir { get { return this._strKargoSehir; } set { this._strKargoSehir = value; } }
        public string strKargoIlce { get { return this._strKargoIlce; } set { this._strKargoIlce = value; } }
        public string strKargoPostaKodu { get { return this._strKargoPostaKodu; } set { this._strKargoPostaKodu = value; } }
        public string strKargoAdSoyad { get { return this._strKargoAdSoyad; } set { this._strKargoAdSoyad = value; } }
        public string strKargoGSM { get { return this._strKargoGSM; } set { this._strKargoGSM = value; } }
        public string strKargoTakip { get { return this._strKargoTakip; } set { this._strKargoTakip = value; } }
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
            return this._bintDisKod.ToString();
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
                SqlCommand cmd = new SqlCommand("INSERT INTO [tblINTERNET_DisSiparisler] ([tintSirketID],[strTC],[bintDisKod],[strDisNo],[dtDisOlusmaTarihi],[dtOlusmaTarihi],[sintOdemeTipi],[sintDurum],[mnTutar],[strEposta],[strFaturaAdresi],[strFaturaSehir],[strFaturaIlce],[strFaturaPostaKodu],[strFaturaAdSoyad],[strFaturaGSM],[bintDisMusteriKodu],[bintKargoKodu],[bintKargoSirketiKodu],[strKargoSirketi],[strKargoAdresi],[strKargoSehir],[strKargoIlce],[strKargoPostaKodu],[strKargoAdSoyad],[strKargoGSM],strKargoTakip) VALUES (@tintSirketID,@strTC,@bintDisKod,@strDisNo,@dtDisOlusmaTarihi,@dtOlusmaTarihi,@sintOdemeTipi,@sintDurum,@mnTutar,@strEposta,@strFaturaAdresi,@strFaturaSehir,@strFaturaIlce,@strFaturaPostaKodu,@strFaturaAdSoyad,@strFaturaGSM,@bintDisMusteriKodu,@bintKargoKodu,@bintKargoSirketiKodu,@strKargoSirketi,@strKargoAdresi,@strKargoSehir,@strKargoIlce,@strKargoPostaKodu,@strKargoAdSoyad,@strKargoGSM,@strKargoTakip) SELECT @pkID = SCOPE_IDENTITY()", conn);
                cmd.Parameters.Add("@tintSirketID", SqlDbType.TinyInt).Value = this._tintSirketID;
                cmd.Parameters.Add("@strTC", SqlDbType.NVarChar).Value = this._strTC;
                cmd.Parameters.Add("@bintDisKod", SqlDbType.BigInt).Value = this._bintDisKod;
                cmd.Parameters.Add("@strDisNo", SqlDbType.NVarChar).Value = this._strDisNo;
                cmd.Parameters.Add("@dtDisOlusmaTarihi", SqlDbType.DateTime).Value = this._dtDisOlusmaTarihi;
                cmd.Parameters.Add("@dtOlusmaTarihi", SqlDbType.DateTime).Value = this._dtOlusmaTarihi;
                cmd.Parameters.Add("@sintOdemeTipi", SqlDbType.SmallInt).Value = this._sintOdemeTipi;
                cmd.Parameters.Add("@sintDurum", SqlDbType.SmallInt).Value = this._sintDurum;
                cmd.Parameters.Add("@mnTutar", SqlDbType.Money).Value = this._mnTutar;
                cmd.Parameters.Add("@strEposta", SqlDbType.NVarChar).Value = this._strEposta;
                cmd.Parameters.Add("@strFaturaAdresi", SqlDbType.NVarChar).Value = this._strFaturaAdresi;
                cmd.Parameters.Add("@strFaturaSehir", SqlDbType.NVarChar).Value = this._strFaturaSehir;
                cmd.Parameters.Add("@strFaturaIlce", SqlDbType.NVarChar).Value = this._strFaturaIlce;
                cmd.Parameters.Add("@strFaturaPostaKodu", SqlDbType.NVarChar).Value = this._strFaturaPostaKodu;
                cmd.Parameters.Add("@strFaturaAdSoyad", SqlDbType.NVarChar).Value = this._strFaturaAdSoyad;
                cmd.Parameters.Add("@strFaturaGSM", SqlDbType.NVarChar).Value = this._strFaturaGSM;
                cmd.Parameters.Add("@bintDisMusteriKodu", SqlDbType.BigInt).Value = this._bintDisMusteriKodu;
                cmd.Parameters.Add("@bintKargoKodu", SqlDbType.BigInt).Value = this._bintKargoKodu;
                cmd.Parameters.Add("@bintKargoSirketiKodu", SqlDbType.BigInt).Value = this._bintKargoSirketiKodu;
                cmd.Parameters.Add("@strKargoSirketi", SqlDbType.NVarChar).Value = this._strKargoSirketi;
                cmd.Parameters.Add("@strKargoAdresi", SqlDbType.NVarChar).Value = this._strKargoAdresi;
                cmd.Parameters.Add("@strKargoSehir", SqlDbType.NVarChar).Value = this._strKargoSehir;
                cmd.Parameters.Add("@strKargoIlce", SqlDbType.NVarChar).Value = this._strKargoIlce;
                cmd.Parameters.Add("@strKargoPostaKodu", SqlDbType.NVarChar).Value = this._strKargoPostaKodu;
                cmd.Parameters.Add("@strKargoAdSoyad", SqlDbType.NVarChar).Value = this._strKargoAdSoyad;
                cmd.Parameters.Add("@strKargoGSM", SqlDbType.NVarChar).Value = this._strKargoGSM;
                cmd.Parameters.Add("@strKargoTakip", SqlDbType.NVarChar).Value = this._strKargoTakip;
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
        /// 
        /// </summary>
        public void DoUpdate()
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UPDATE [tblINTERNET_DisSiparisler] SET [tintSirketID]=@tintSirketID,[strTC]=@strTC,[bintDisKod]=@bintDisKod,[strDisNo]=@strDisNo,[dtDisOlusmaTarihi]=@dtDisOlusmaTarihi,[dtOlusmaTarihi]=@dtOlusmaTarihi,[sintOdemeTipi]=@sintOdemeTipi,[sintDurum]=@sintDurum,[mnTutar]=@mnTutar,[strEposta]=@strEposta,[strFaturaAdresi]=@strFaturaAdresi,[strFaturaSehir]=@strFaturaSehir,[strFaturaIlce]=@strFaturaIlce,[strFaturaPostaKodu]=@strFaturaPostaKodu,[strFaturaAdSoyad]=@strFaturaAdSoyad,[strFaturaGSM]=@strFaturaGSM,[bintDisMusteriKodu]=@bintDisMusteriKodu,[bintKargoKodu]=@bintKargoKodu,[bintKargoSirketiKodu]=@bintKargoSirketiKodu,[strKargoSirketi]=@strKargoSirketi,[strKargoAdresi]=@strKargoAdresi,[strKargoSehir]=@strKargoSehir,[strKargoIlce]=@strKargoIlce,[strKargoPostaKodu]=@strKargoPostaKodu,[strKargoAdSoyad]=@strKargoAdSoyad,[strKargoGSM]=@strKargoGSM,strKargoTakip=@strKargoTakip WHERE pkID = @pkID", conn);
                cmd.Parameters.Add("@tintSirketID", SqlDbType.TinyInt).Value = this._tintSirketID;
                cmd.Parameters.Add("@strTC", SqlDbType.NVarChar).Value = this._strTC;
                cmd.Parameters.Add("@bintDisKod", SqlDbType.BigInt).Value = this._bintDisKod;
                cmd.Parameters.Add("@strDisNo", SqlDbType.NVarChar).Value = this._strDisNo;
                cmd.Parameters.Add("@dtDisOlusmaTarihi", SqlDbType.DateTime).Value = this._dtDisOlusmaTarihi;
                cmd.Parameters.Add("@dtOlusmaTarihi", SqlDbType.DateTime).Value = this._dtOlusmaTarihi;
                cmd.Parameters.Add("@sintOdemeTipi", SqlDbType.SmallInt).Value = this._sintOdemeTipi;
                cmd.Parameters.Add("@sintDurum", SqlDbType.SmallInt).Value = this._sintDurum;
                cmd.Parameters.Add("@mnTutar", SqlDbType.Money).Value = this._mnTutar;
                cmd.Parameters.Add("@strEposta", SqlDbType.NVarChar).Value = this._strEposta;
                cmd.Parameters.Add("@strFaturaAdresi", SqlDbType.NVarChar).Value = this._strFaturaAdresi;
                cmd.Parameters.Add("@strFaturaSehir", SqlDbType.NVarChar).Value = this._strFaturaSehir;
                cmd.Parameters.Add("@strFaturaIlce", SqlDbType.NVarChar).Value = this._strFaturaIlce;
                cmd.Parameters.Add("@strFaturaPostaKodu", SqlDbType.NVarChar).Value = this._strFaturaPostaKodu;
                cmd.Parameters.Add("@strFaturaAdSoyad", SqlDbType.NVarChar).Value = this._strFaturaAdSoyad;
                cmd.Parameters.Add("@strFaturaGSM", SqlDbType.NVarChar).Value = this._strFaturaGSM;
                cmd.Parameters.Add("@bintDisMusteriKodu", SqlDbType.BigInt).Value = this._bintDisMusteriKodu;
                cmd.Parameters.Add("@bintKargoKodu", SqlDbType.BigInt).Value = this._bintKargoKodu;
                cmd.Parameters.Add("@bintKargoSirketiKodu", SqlDbType.BigInt).Value = this._bintKargoSirketiKodu;
                cmd.Parameters.Add("@strKargoSirketi", SqlDbType.NVarChar).Value = this._strKargoSirketi;
                cmd.Parameters.Add("@strKargoAdresi", SqlDbType.NVarChar).Value = this._strKargoAdresi;
                cmd.Parameters.Add("@strKargoSehir", SqlDbType.NVarChar).Value = this._strKargoSehir;
                cmd.Parameters.Add("@strKargoIlce", SqlDbType.NVarChar).Value = this._strKargoIlce;
                cmd.Parameters.Add("@strKargoPostaKodu", SqlDbType.NVarChar).Value = this._strKargoPostaKodu;
                cmd.Parameters.Add("@strKargoAdSoyad", SqlDbType.NVarChar).Value = this._strKargoAdSoyad;
                cmd.Parameters.Add("@strKargoGSM", SqlDbType.NVarChar).Value = this._strKargoGSM;
                cmd.Parameters.Add("@strKargoTakip", SqlDbType.NVarChar).Value = this._strKargoTakip;
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
        /// <summary>
        /// 
        /// </summary>
        public void DoDelete()
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM [tblINTERNET_DisSiparisler] WHERE pkID = @pkID", conn);
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
        public static void GetObject(DataTable dt)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT pkID,[tintSirketID],[strTC],[bintDisKod],[strDisNo],[dtDisOlusmaTarihi],[dtOlusmaTarihi],[sintOdemeTipi],[sintDurum],[mnTutar],[strEposta],[strFaturaAdresi],[strFaturaSehir],[strFaturaIlce],[strFaturaPostaKodu],[strFaturaAdSoyad],[strFaturaGSM],[bintDisMusteriKodu],[bintKargoKodu],[bintKargoSirketiKodu],[strKargoSirketi],[strKargoAdresi],[strKargoSehir],[strKargoIlce],[strKargoPostaKodu],[strKargoAdSoyad],[strKargoGSM],strKargoTakip FROM [tblINTERNET_DisSiparisler] ORDER BY dtOlusmaTarihi DESC", conn);
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
        public static void GetObjectAyrintili(DataTable dt)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT [tintSirketID],strSirket,dtOlusmaTarihi,QUANTUMNO,[bintDisKod],[tblINTERNET_DisSiparisler].pkID,[strFaturaAdSoyad],strKargoSirketi,strKargoTakip FROM [tblINTERNET_DisSiparisler] INNER JOIN tblINTERNET_SiparislerQ ON (1000000000 + [tblINTERNET_DisSiparisler].pkID) = tblINTERNET_SiparislerQ.intSiparisID INNER JOIN tblINTERNET_DisSirketler ON [tblINTERNET_DisSiparisler].[tintSirketID] = tblINTERNET_DisSirketler.pkID WHERE [tblINTERNET_DisSiparisler].sintDurum = 2 ORDER BY dtOlusmaTarihi DESC", conn);
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
        public static DisSiparisler GetObject(int ID)
        {
            DisSiparisler donendeger = new DisSiparisler();
            DataTable dt = new DataTable();
            
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT pkID,[tintSirketID],[strTC],[bintDisKod],[strDisNo],[dtDisOlusmaTarihi],[dtOlusmaTarihi],[sintOdemeTipi],[sintDurum],[mnTutar],[strEposta],[strFaturaAdresi],[strFaturaSehir],[strFaturaIlce],[strFaturaPostaKodu],[strFaturaAdSoyad],[strFaturaGSM],[bintDisMusteriKodu],[bintKargoKodu],[bintKargoSirketiKodu],[strKargoSirketi],[strKargoAdresi],[strKargoSehir],[strKargoIlce],[strKargoPostaKodu],[strKargoAdSoyad],[strKargoGSM],strKargoTakip FROM [tblINTERNET_DisSiparisler] WHERE pkID = @pkID", conn);
                da.SelectCommand.Parameters.Add("@pkID", SqlDbType.Int).Value = ID;
                try
                {
                    conn.Open();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        donendeger._pkID = Convert.ToInt32(dt.Rows[0]["pkID"]);
                        donendeger._tintSirketID = Convert.ToByte(dt.Rows[0]["tintSirketID"]);
                        donendeger._strTC = dt.Rows[0]["strTC"].ToString();
                        donendeger._bintDisKod = Convert.ToInt64(dt.Rows[0]["bintDisKod"]);
                        donendeger._strDisNo = dt.Rows[0]["strDisNo"].ToString();
                        donendeger._dtDisOlusmaTarihi = Convert.ToDateTime(dt.Rows[0]["dtDisOlusmaTarihi"]);
                        donendeger._dtOlusmaTarihi = Convert.ToDateTime(dt.Rows[0]["dtOlusmaTarihi"]);
                        donendeger._sintOdemeTipi = Convert.ToInt16(dt.Rows[0]["sintOdemeTipi"]);
                        donendeger._sintDurum = Convert.ToInt16(dt.Rows[0]["sintDurum"]);
                        donendeger._mnTutar = Convert.ToDecimal(dt.Rows[0]["mnTutar"]);
                        donendeger._strEposta = dt.Rows[0]["strEposta"].ToString();
                        donendeger._strFaturaAdresi = dt.Rows[0]["strFaturaAdresi"].ToString();
                        donendeger._strFaturaSehir = dt.Rows[0]["strFaturaSehir"].ToString();
                        donendeger._strFaturaIlce = dt.Rows[0]["strFaturaIlce"].ToString();
                        donendeger._strFaturaPostaKodu = dt.Rows[0]["strFaturaPostaKodu"].ToString();
                        donendeger._strFaturaAdSoyad = dt.Rows[0]["strFaturaAdSoyad"].ToString();
                        donendeger._strFaturaGSM = dt.Rows[0]["strFaturaGSM"].ToString();
                        donendeger._bintDisMusteriKodu = Convert.ToInt64(dt.Rows[0]["bintDisMusteriKodu"]);
                        donendeger._bintKargoKodu = Convert.ToInt64(dt.Rows[0]["bintKargoKodu"]);
                        donendeger._bintKargoSirketiKodu = Convert.ToInt64(dt.Rows[0]["bintKargoSirketiKodu"]);
                        donendeger._strKargoSirketi = dt.Rows[0]["strKargoSirketi"].ToString();
                        donendeger._strKargoAdresi = dt.Rows[0]["strKargoAdresi"].ToString();
                        donendeger._strKargoSehir = dt.Rows[0]["strKargoSehir"].ToString();
                        donendeger._strKargoIlce = dt.Rows[0]["strKargoIlce"].ToString();
                        donendeger._strKargoPostaKodu = dt.Rows[0]["strKargoPostaKodu"].ToString();
                        donendeger._strKargoAdSoyad = dt.Rows[0]["strKargoAdSoyad"].ToString();
                        donendeger._strKargoGSM = dt.Rows[0]["strKargoGSM"].ToString();
                        donendeger._strKargoTakip = dt.Rows[0]["strKargoTakip"].ToString();
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
        public static bool VarMiByDisNo(string DisNo)
        {
            bool donendeger = false;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT count(*) FROM [tblINTERNET_DisSiparisler] WHERE strDisNo = @DisNo", conn);
                cmd.Parameters.Add("@DisNo", SqlDbType.NVarChar).Value = DisNo;
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
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sultanlar.DatabaseObject
{
    public class AT_Arabalar : IDisposable, ISultanlar
    {
        //
        //
        //
        // Alanlar:
        //
        private int _pkArabaID;
        private string _strArabaPlaka;
        private byte _tintYakitTuruID;
        private short _sintArabaMarkaID;
        private string _strArabaModeli;
        private short _sintArabaModelYili;
        private byte _tintArabaTuruID;
        private bool _blArabaK2Belge;
        private byte _tintDepartmanID;
        private bool _blArabaLogolu;
        private byte _tintArabaKimeAitID;
        private string _dtKiraBaslangic;
        private string _dtKiraBitis;
        private bool _blPasif;
        //
        //
        //
        // Constracter lar:
        //
        private AT_Arabalar(int pkArabaID, string strArabaPlaka, byte tintYakitTuruID, short sintArabaMarkaID, string strArabaModeli, short sintArabaModelYili,
            byte tintArabaTuruID, bool blArabaK2Belge, byte tintDepartmanID, bool blArabaLogolu, byte tintArabaKimeAitID, string dtKiraBaslangic, string dtKiraBitis, bool blPasif)
        {
            this._pkArabaID = pkArabaID;
            this._strArabaPlaka = strArabaPlaka;
            this._tintYakitTuruID = tintYakitTuruID;
            this._sintArabaMarkaID = sintArabaMarkaID;
            this._strArabaModeli = strArabaModeli;
            this._sintArabaModelYili = sintArabaModelYili;
            this._tintArabaTuruID = tintArabaTuruID;
            this._blArabaK2Belge = blArabaK2Belge;
            this._tintDepartmanID = tintDepartmanID;
            this._blArabaLogolu = blArabaLogolu;
            this._tintArabaKimeAitID = tintArabaKimeAitID;
            this._dtKiraBaslangic = dtKiraBaslangic;
            this._dtKiraBitis = dtKiraBitis;
            this._blPasif = blPasif;
        }
        //
        //
        public AT_Arabalar(string strArabaPlaka, byte tintYakitTuruID, short sintArabaMarkaID, string strArabaModeli, short sintArabaModelYili,
            byte tintArabaTuruID, bool blArabaK2Belge, byte tintDepartmanID, bool blArabaLogolu, byte tintArabaKimeAitID, string dtKiraBaslangic, string dtKiraBitis, bool blPasif)
        {
            this._strArabaPlaka = strArabaPlaka;
            this._tintYakitTuruID = tintYakitTuruID;
            this._sintArabaMarkaID = sintArabaMarkaID;
            this._strArabaModeli = strArabaModeli;
            this._sintArabaModelYili = sintArabaModelYili;
            this._tintArabaTuruID = tintArabaTuruID;
            this._blArabaK2Belge = blArabaK2Belge;
            this._tintDepartmanID = tintDepartmanID;
            this._blArabaLogolu = blArabaLogolu;
            this._tintArabaKimeAitID = tintArabaKimeAitID;
            this._dtKiraBaslangic = dtKiraBaslangic;
            this._dtKiraBitis = dtKiraBitis;
            this._blPasif = blPasif;
        }
        //
        //
        //
        // Özellikler:
        //
        public int pkArabaID
        {
            get
            {
                return this._pkArabaID;
            }
        }
        //
        //
        public string strArabaPlaka
        {
            get
            {
                return this._strArabaPlaka;
            }
            set
            {
                this._strArabaPlaka = value;
            }
        }
        //
        //
        public byte tintYakitTuruID
        {
            get
            {
                return this._tintYakitTuruID;
            }
            set
            {
                this._tintYakitTuruID = value;
            }
        }
        //
        //
        public short sintArabaMarkaID
        {
            get
            {
                return this._sintArabaMarkaID;
            }
            set
            {
                this._sintArabaMarkaID = value;
            }
        }
        //
        //
        public string strArabaModeli
        {
            get
            {
                return this._strArabaModeli;
            }
            set
            {
                this._strArabaModeli = value;
            }
        }
        //
        //
        public short sintArabaModelYili
        {
            get
            {
                return this._sintArabaModelYili;
            }
            set
            {
                this._sintArabaModelYili = value;
            }
        }
        //
        //
        public byte tintArabaTuruID
        {
            get
            {
                return this._tintArabaTuruID;
            }
            set
            {
                this._tintArabaTuruID = value;
            }
        }
        //
        //
        public bool blArabaK2Belge
        {
            get
            {
                return this._blArabaK2Belge;
            }
            set
            {
                this._blArabaK2Belge = value;
            }
        }
        //
        //
        public byte tintDepartmanID
        {
            get
            {
                return this._tintDepartmanID;
            }
            set
            {
                this._tintDepartmanID = value;
            }
        }
        //
        //
        public bool blArabaLogolu
        {
            get
            {
                return this._blArabaLogolu;
            }
            set
            {
                this._blArabaLogolu = value;
            }
        }
        //
        //
        public byte tintArabaKimeAitID
        {
            get
            {
                return this._tintArabaKimeAitID;
            }
            set
            {
                this._tintArabaKimeAitID = value;
            }
        }
        //
        //
        public string dtKiraBaslangic
        {
            get
            {
                return this._dtKiraBaslangic;
            }
            set
            {
                this._dtKiraBaslangic = value;
            }
        }
        //
        //
        public string dtKiraBitis
        {
            get
            {
                return this._dtKiraBitis;
            }
            set
            {
                this._dtKiraBitis = value;
            }
        }
        //
        //
        public bool blPasif
        {
            get
            {
                return this._blPasif;
            }
            set
            {
                this._blPasif = value;
            }
        }
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
            return this._strArabaPlaka;
        }
        //
        //
        //
        // Metodlar:
        //
        public void DoInsert()
        {
            object KiraBaslangic = DBNull.Value;
            object KiraBitis = DBNull.Value;
            if (_dtKiraBaslangic != string.Empty)
            {
                KiraBaslangic = DateTime.Parse(_dtKiraBaslangic);
            }
            if (_dtKiraBitis != string.Empty)
            {
                KiraBitis = DateTime.Parse(_dtKiraBitis);
            }

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_AT_ArabaEkle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@strArabaPlaka", SqlDbType.NVarChar).Value = this._strArabaPlaka;
                cmd.Parameters.Add("@tintYakitTuruID", SqlDbType.TinyInt).Value = this._tintYakitTuruID;
                cmd.Parameters.Add("@sintArabaMarkaID", SqlDbType.SmallInt).Value = this._sintArabaMarkaID;
                cmd.Parameters.Add("@strArabaModeli", SqlDbType.NVarChar).Value = this._strArabaModeli;
                cmd.Parameters.Add("@sintArabaModelYili", SqlDbType.SmallInt).Value = this._sintArabaModelYili;
                cmd.Parameters.Add("@tintArabaTuruID", SqlDbType.TinyInt).Value = this._tintArabaTuruID;
                cmd.Parameters.Add("@blArabaK2Belge", SqlDbType.Bit).Value = this._blArabaK2Belge;
                cmd.Parameters.Add("@tintDepartmanID", SqlDbType.TinyInt).Value = this._tintDepartmanID;
                cmd.Parameters.Add("@blArabaLogolu", SqlDbType.Bit).Value = this._blArabaLogolu;
                cmd.Parameters.Add("@tintArabaKimeAitID", SqlDbType.TinyInt).Value = this._tintArabaKimeAitID;
                cmd.Parameters.Add("@dtKiraBaslangic", SqlDbType.SmallDateTime).Value = KiraBaslangic;
                cmd.Parameters.Add("@dtKiraBitis", SqlDbType.SmallDateTime).Value = KiraBitis;
                cmd.Parameters.Add("@blPasif", SqlDbType.Bit).Value = this._blPasif;
                cmd.Parameters.Add("@pkArabaID", SqlDbType.Int).Direction = ParameterDirection.Output;
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    this._pkArabaID = Convert.ToByte(cmd.Parameters["@pkArabaID"].Value);
                }
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
            object KiraBaslangic = DBNull.Value;
            object KiraBitis = DBNull.Value;
            if (_dtKiraBaslangic != string.Empty)
            {
                KiraBaslangic = DateTime.Parse(_dtKiraBaslangic);
            }
            if (_dtKiraBitis != string.Empty)
            {
                KiraBitis = DateTime.Parse(_dtKiraBitis);
            }

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_AT_ArabaGuncelle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkArabaID", SqlDbType.Int).Value = this._pkArabaID;
                cmd.Parameters.Add("@strArabaPlaka", SqlDbType.NVarChar).Value = this._strArabaPlaka;
                cmd.Parameters.Add("@tintYakitTuruID", SqlDbType.TinyInt).Value = this._tintYakitTuruID;
                cmd.Parameters.Add("@sintArabaMarkaID", SqlDbType.SmallInt).Value = this._sintArabaMarkaID;
                cmd.Parameters.Add("@strArabaModeli", SqlDbType.NVarChar).Value = this._strArabaModeli;
                cmd.Parameters.Add("@sintArabaModelYili", SqlDbType.SmallInt).Value = this._sintArabaModelYili;
                cmd.Parameters.Add("@tintArabaTuruID", SqlDbType.TinyInt).Value = this._tintArabaTuruID;
                cmd.Parameters.Add("@blArabaK2Belge", SqlDbType.Bit).Value = this._blArabaK2Belge;
                cmd.Parameters.Add("@tintDepartmanID", SqlDbType.TinyInt).Value = this._tintDepartmanID;
                cmd.Parameters.Add("@blArabaLogolu", SqlDbType.Bit).Value = this._blArabaLogolu;
                cmd.Parameters.Add("@tintArabaKimeAitID", SqlDbType.TinyInt).Value = this._tintArabaKimeAitID;
                cmd.Parameters.Add("@dtKiraBaslangic", SqlDbType.SmallDateTime).Value = KiraBaslangic;
                cmd.Parameters.Add("@dtKiraBitis", SqlDbType.SmallDateTime).Value = KiraBitis;
                cmd.Parameters.Add("@blPasif", SqlDbType.Bit).Value = this._blPasif;
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
                SqlCommand cmd = new SqlCommand("sp_AT_ArabaSil", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkArabaID", SqlDbType.Int).Value = this._pkArabaID;
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
        public static void GetObject(IList List, bool UI)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                List.Clear();

                SqlCommand cmd = new SqlCommand("sp_AT_ArabaGetir", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        List.Add(new AT_Arabalar(Convert.ToInt32(dr[0]), dr[1].ToString(), Convert.ToByte(dr[2]), Convert.ToInt16(dr[3]), dr[4].ToString(),
                        Convert.ToInt16(dr[5]), Convert.ToByte(dr[6]), Convert.ToBoolean(dr[5]), Convert.ToByte(dr[8]), Convert.ToBoolean(dr[9]), Convert.ToByte(dr[10]),
                        dr[11].ToString(), dr[12].ToString(), Convert.ToBoolean(dr[13])));
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
        public static void GetObject(DataTable dt)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_AT_ArabaGetir", conn);
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
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Sultanlar.DatabaseObject.Internet
{
    public class DisSiparislerDetay : ISultanlar, IDisposable
    {
        //
        //
        //
        // Alanlar:
        //
        private long _pkID;
        private int _intDisSiparisID;
        private long _bintDisKod;
        private string _strDisUrunKod;
        private int _intUrunID;
        private string _strUrun;
        private int _intMiktar;
        private decimal _mnTutar;
        private short _sintDurum;
        private bool _blKabulEdildi;
        //
        //
        //
        // Constracter lar:
        //
        private DisSiparislerDetay(int pkID, int intDisSiparisID, long bintDisKod, string strDisUrunKod, int intUrunID, string strUrun, int intMiktar,
            decimal mnTutar, short sintDurum, bool blKabulEdildi)
        {
            this._pkID = pkID;
            this._intDisSiparisID = intDisSiparisID;
            this._bintDisKod = bintDisKod;
            this._strDisUrunKod = strDisUrunKod;
            this._intUrunID = intUrunID;
            this._strUrun = strUrun;
            this._intMiktar = intMiktar;
            this._mnTutar = mnTutar;
            this._sintDurum = sintDurum;
            this._blKabulEdildi = blKabulEdildi;
        }
        //
        //
        public DisSiparislerDetay(int intDisSiparisID, long bintDisKod, string strDisUrunKod, int intUrunID, string strUrun, int intMiktar,
            decimal mnTutar, short sintDurum, bool blKabulEdildi)
        {
            this._intDisSiparisID = intDisSiparisID;
            this._bintDisKod = bintDisKod;
            this._strDisUrunKod = strDisUrunKod;
            this._intUrunID = intUrunID;
            this._strUrun = strUrun;
            this._intMiktar = intMiktar;
            this._mnTutar = mnTutar;
            this._sintDurum = sintDurum;
            this._blKabulEdildi = blKabulEdildi;
        }
        //
        //
        private DisSiparislerDetay()
        {

        }
        //
        //
        //
        // Özellikler:
        //
        public long pkID { get { return this._pkID; } }
        public int intDisSiparisID { get { return this._intDisSiparisID; } set { this._intDisSiparisID = value; } }
        public long bintDisKod { get { return this._bintDisKod; } set { this._bintDisKod = value; } }
        public string strDisUrunKod { get { return this._strDisUrunKod; } set { this._strDisUrunKod = value; } }
        public int intUrunID { get { return this._intUrunID; } set { this._intUrunID = value; } }
        public string strUrun { get { return this._strUrun; } set { this._strUrun = value; } }
        public int intMiktar { get { return this._intMiktar; } set { this._intMiktar = value; } }
        public decimal mnTutar { get { return this._mnTutar; } set { this._mnTutar = value; } }
        public short sintDurum { get { return this._sintDurum; } set { this._sintDurum = value; } }
        public bool blKabulEdildi { get { return this._blKabulEdildi; } set { this._blKabulEdildi = value; } }
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
                SqlCommand cmd = new SqlCommand("INSERT INTO [tblINTERNET_DisSiparislerDetay] ([intDisSiparisID],[bintDisKod],[strDisUrunKod],[intUrunID],[strUrun],[intMiktar],[mnTutar],[sintDurum],blKabulEdildi) VALUES (@intDisSiparisID,@bintDisKod,@strDisUrunKod,@intUrunID,@strUrun,@intMiktar,@mnTutar,@sintDurum,@blKabulEdildi) SELECT @pkID = SCOPE_IDENTITY()", conn);
                cmd.Parameters.Add("@intDisSiparisID", SqlDbType.Int).Value = this._intDisSiparisID;
                cmd.Parameters.Add("@bintDisKod", SqlDbType.BigInt).Value = this._bintDisKod;
                cmd.Parameters.Add("@strDisUrunKod", SqlDbType.NVarChar).Value = this._strDisUrunKod;
                cmd.Parameters.Add("@intUrunID", SqlDbType.Int).Value = this._intUrunID;
                cmd.Parameters.Add("@strUrun", SqlDbType.NVarChar).Value = this._strUrun;
                cmd.Parameters.Add("@intMiktar", SqlDbType.Int).Value = this._intMiktar;
                cmd.Parameters.Add("@mnTutar", SqlDbType.Money).Value = this._mnTutar;
                cmd.Parameters.Add("@sintDurum", SqlDbType.SmallInt).Value = this._sintDurum;
                cmd.Parameters.Add("@blKabulEdildi", SqlDbType.Bit).Value = this._blKabulEdildi;
                cmd.Parameters.Add("@pkID", SqlDbType.BigInt).Direction = ParameterDirection.Output;
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    this._pkID = Convert.ToInt64(cmd.Parameters["@pkID"].Value);
                }
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
                SqlCommand cmd = new SqlCommand("UPDATE [tblINTERNET_DisSiparislerDetay] SET [intDisSiparisID]=@intDisSiparisID,[bintDisKod]=@bintDisKod,[strDisUrunKod]=@strDisUrunKod,[intUrunID]=@intUrunID,[strUrun]=@strUrun,[intMiktar]=@intMiktar,[mnTutar]=@mnTutar,[sintDurum]=@sintDurum,blKabulEdildi=@blKabulEdildi WHERE pkID=@pkID", conn);
                cmd.Parameters.Add("@intDisSiparisID", SqlDbType.Int).Value = this._intDisSiparisID;
                cmd.Parameters.Add("@bintDisKod", SqlDbType.BigInt).Value = this._bintDisKod;
                cmd.Parameters.Add("@strDisUrunKod", SqlDbType.NVarChar).Value = this._strDisUrunKod;
                cmd.Parameters.Add("@intUrunID", SqlDbType.Int).Value = this._intUrunID;
                cmd.Parameters.Add("@strUrun", SqlDbType.NVarChar).Value = this._strUrun;
                cmd.Parameters.Add("@intMiktar", SqlDbType.Int).Value = this._intMiktar;
                cmd.Parameters.Add("@mnTutar", SqlDbType.Money).Value = this._mnTutar;
                cmd.Parameters.Add("@sintDurum", SqlDbType.SmallInt).Value = this._sintDurum;
                cmd.Parameters.Add("@blKabulEdildi", SqlDbType.Bit).Value = this._blKabulEdildi;
                cmd.Parameters.Add("@pkID", SqlDbType.BigInt).Value = this._pkID;
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    this._pkID = Convert.ToInt64(cmd.Parameters["@pkID"].Value);
                }
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
        public static void DoUpdateKabul(long DisKod, bool Kabul)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UPDATE [tblINTERNET_DisSiparislerDetay] SET blKabulEdildi=@blKabulEdildi WHERE bintDisKod = @bintDisKod", conn);
                cmd.Parameters.Add("@blKabulEdildi", SqlDbType.Bit).Value = Kabul;
                cmd.Parameters.Add("@bintDisKod", SqlDbType.BigInt).Value = DisKod;
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
                SqlCommand cmd = new SqlCommand("DELETE FROM [tblINTERNET_DisSiparislerDetay] WHERE pkID = @pkID", conn);
                cmd.Parameters.Add("@pkID", SqlDbType.BigInt).Value = this._pkID;
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
        public static void GetObject(DataTable dt, int DisSiparisID)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT [pkID],[intDisSiparisID],[bintDisKod],[strDisUrunKod],[intUrunID],[strUrun],[intMiktar],[mnTutar],[sintDurum],blKabulEdildi FROM [tblINTERNET_DisSiparislerDetay] WHERE intDisSiparisID=@intDisSiparisID", conn);
                da.SelectCommand.Parameters.Add("@intDisSiparisID", SqlDbType.Int).Value = DisSiparisID;
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
        public static DisSiparislerDetay GetObject(long DisKod)
        {
            DisSiparislerDetay donendeger = new DisSiparislerDetay();
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT [pkID],[intDisSiparisID],[bintDisKod],[strDisUrunKod],[intUrunID],[strUrun],[intMiktar],[mnTutar],[sintDurum],blKabulEdildi FROM [tblINTERNET_DisSiparislerDetay] WHERE bintDisKod=@DisKod", conn);
                da.SelectCommand.Parameters.Add("@DisKod", SqlDbType.BigInt).Value = DisKod;
                try
                {
                    conn.Open();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        donendeger._pkID = Convert.ToInt64(dt.Rows[0]["pkID"]);
                        donendeger._intDisSiparisID = Convert.ToInt32(dt.Rows[0]["intDisSiparisID"]);
                        donendeger._bintDisKod = Convert.ToInt64(dt.Rows[0]["bintDisKod"]);
                        donendeger._strDisUrunKod = dt.Rows[0]["strDisUrunKod"].ToString();
                        donendeger._intUrunID = Convert.ToInt32(dt.Rows[0]["intUrunID"]);
                        donendeger._strUrun = dt.Rows[0]["strUrun"].ToString();
                        donendeger._intMiktar = Convert.ToInt32(dt.Rows[0]["intMiktar"]);
                        donendeger._mnTutar = Convert.ToDecimal(dt.Rows[0]["mnTutar"]);
                        donendeger._sintDurum = Convert.ToInt16(dt.Rows[0]["sintDurum"]);
                        donendeger._blKabulEdildi = Convert.ToBoolean(dt.Rows[0]["blKabulEdildi"]);
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

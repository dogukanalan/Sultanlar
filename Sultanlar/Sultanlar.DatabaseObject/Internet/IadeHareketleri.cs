using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace Sultanlar.DatabaseObject.Internet
{
    public class IadeHareketleri : ISultanlar, IDisposable
    {
        //
        //
        //
        // Alanlar:
        //
        private long _pkID;
        private int _intIadeID;
        private int _intIadeHareketTurID;
        private DateTime _dtTarih;
        private string _strIslemYapan;
        private string _strAciklama;
        //
        //
        //
        // Constracter lar:
        //
        public IadeHareketleri(long pkID, int intIadeID, int intIadeHareketTurID, DateTime dtTarih, string strIslemYapan, string strAciklama)
        {
            this._pkID = pkID;
            this._intIadeID = intIadeID;
            this._intIadeHareketTurID = intIadeHareketTurID;
            this._dtTarih = dtTarih;
            this._strIslemYapan = strIslemYapan;
            this._strAciklama = strAciklama;
        }
        //
        //
        private IadeHareketleri(int intIadeID, int intIadeHareketTurID, DateTime dtTarih, string strIslemYapan, string strAciklama)
        {
            this._intIadeID = intIadeID;
            this._intIadeHareketTurID = intIadeHareketTurID;
            this._dtTarih = dtTarih;
            this._strIslemYapan = strIslemYapan;
            this._strAciklama = strAciklama;
        }
        //
        //
        //
        // Özellikler:
        //
        public long pkID { get { return this._pkID; } }
        public int intIadeID { get { return this._intIadeID; } set { this._intIadeID = value; } }
        public int intIadeHareketTurID { get { return this._intIadeHareketTurID; } set { this._intIadeHareketTurID = value; } }
        public DateTime dtTarih { get { return this._dtTarih; } set { this._dtTarih = value; } }
        public string strIslemYapan { get { return this._strIslemYapan; } set { this._strIslemYapan = value; } }
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
            return this._pkID.ToString();
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
                SqlCommand cmd = new SqlCommand("INSERT INTO tblINTERNET_IadeHareketleri ([intIadeID],[intIadeHareketTurID],[dtTarih],[strIslemYapan],strAciklama) VALUES (@intIadeID,@intIadeHareketTurID,@dtTarih,@strIslemYapan,@strAciklama) SELECT @pkID = SCOPE_IDENTITY()", conn);
                cmd.Parameters.Add("@intIadeID", SqlDbType.Int).Value = this._intIadeID;
                cmd.Parameters.Add("@intIadeHareketTurID", SqlDbType.Int).Value = this._intIadeHareketTurID;
                cmd.Parameters.Add("@dtTarih", SqlDbType.DateTime).Value = this._dtTarih;
                cmd.Parameters.Add("@strIslemYapan", SqlDbType.NVarChar).Value = this._strIslemYapan;
                cmd.Parameters.Add("@strAciklama", SqlDbType.NVarChar).Value = this._strAciklama;
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
        //
        //
        public static void DoInsert(int IadeID, int IadeHareketTur, string IslemiYapan, string strAciklama)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO tblINTERNET_IadeHareketleri ([intIadeID],[intIadeHareketTurID],[dtTarih],[strIslemYapan],strAciklama) VALUES (@intIadeID,@intIadeHareketTurID,@dtTarih,@strIslemYapan,@strAciklama)", conn);
                cmd.Parameters.Add("@intIadeID", SqlDbType.Int).Value = IadeID;
                cmd.Parameters.Add("@intIadeHareketTurID", SqlDbType.Int).Value = IadeHareketTur;
                cmd.Parameters.Add("@dtTarih", SqlDbType.DateTime).Value = DateTime.Now;
                cmd.Parameters.Add("@strIslemYapan", SqlDbType.NVarChar).Value = IslemiYapan;
                cmd.Parameters.Add("@strAciklama", SqlDbType.NVarChar).Value = strAciklama;
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
                SqlCommand cmd = new SqlCommand("UPDATE tblINTERNET_IadeHareketleri SET [intIadeID] = @intIadeID,[intIadeHareketTurID] = @intIadeHareketTurID,[dtTarih] = @dtTarih,[strIslemYapan] = @strIslemYapan,strAciklama = @strAciklama WHERE pkID = @pkID", conn);
                cmd.Parameters.Add("@pkID", SqlDbType.BigInt).Value = this._pkID;
                cmd.Parameters.Add("@intIadeID", SqlDbType.Int).Value = this._intIadeID;
                cmd.Parameters.Add("@intIadeHareketTurID", SqlDbType.Int).Value = this._intIadeHareketTurID;
                cmd.Parameters.Add("@dtTarih", SqlDbType.DateTime).Value = this._dtTarih;
                cmd.Parameters.Add("@strIslemYapan", SqlDbType.NVarChar).Value = this._strIslemYapan;
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
                SqlCommand cmd = new SqlCommand("DELETE FROM tblINTERNET_IadeHareketleri WHERE pkID = @pkID", conn);
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
        public static void GetObjectByIadeID(int IadeID, DataTable dt)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT [pkID],[intIadeID],[intIadeHareketTurID],[strIadeHareketTur],[dtTarih],[strIslemYapan],strAciklama FROM [tblINTERNET_IadeHareketleri] INNER JOIN tblINTERNET_IadeHareketTurleri ON tblINTERNET_IadeHareketleri.intIadeHareketTurID = tblINTERNET_IadeHareketTurleri.pkIadeHareketTurID WHERE intIadeID = @intIadeID ORDER BY pkID DESC", conn);
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
    }
}

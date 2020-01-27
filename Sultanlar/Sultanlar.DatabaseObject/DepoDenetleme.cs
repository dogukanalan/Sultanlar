using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Sultanlar.DatabaseObject
{
    public class DepoDenetleme : IDisposable, ISultanlar
    {
        //
        //
        //
        // Alanlar:
        //
        private int _pkID;
        private int _GMREF;
        private DateTime _dtTarih;
        private string _strDenetleyen;
        private string _strUnvan;
        private string _strTespilter;
        //
        //
        //
        // Constracter lar:
        //
        private DepoDenetleme(int pkID, int GMREF, DateTime dtTarih, string strDenetleyen, string strUnvan, string strTespilter)
        {
            this._pkID = pkID;
            this._GMREF = GMREF;
            this._dtTarih = dtTarih;
            this._strDenetleyen = strDenetleyen;
            this._strUnvan = strUnvan;
            this._strTespilter = strTespilter;
        }
        //
        //
        public DepoDenetleme(int GMREF, DateTime dtTarih, string strDenetleyen, string strUnvan, string strTespilter)
        {
            this._GMREF = GMREF;
            this._dtTarih = dtTarih;
            this._strDenetleyen = strDenetleyen;
            this._strUnvan = strUnvan;
            this._strTespilter = strTespilter;
        }
        //
        //
        //
        // Özellikler:
        //
        public int pkID { get { return this._pkID; } }
        public int GMREF { get { return this._GMREF; } set { this._GMREF = value; } }
        public DateTime dtTarih { get { return this._dtTarih; } set { this._dtTarih = value; } }
        public string strDenetleyen { get { return this._strDenetleyen; } set { this._strDenetleyen = value; } }
        public string strUnvan { get { return this._strUnvan; } set { this._strUnvan = value; } }
        public string strTespilter { get { return this._strTespilter; } set { this._strTespilter = value; } }
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
            return this._strTespilter;
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
                SqlCommand cmd = new SqlCommand("INSERT INTO [tblDepoDenetleme] ([GMREF],[dtTarih],[strDenetleyen],[strUnvan],[strTespilter]) VALUES (@GMREF,@dtTarih,@strDenetleyen,@strUnvan,@strTespilter) SELECT @pkID = SCOPE_IDENTITY()", conn);
                cmd.Parameters.Add("@GMREF", SqlDbType.Int).Value = this._GMREF;
                cmd.Parameters.Add("@dtTarih", SqlDbType.DateTime).Value = this._dtTarih;
                cmd.Parameters.Add("@strDenetleyen", SqlDbType.NVarChar, 30).Value = this._strDenetleyen;
                cmd.Parameters.Add("@strUnvan", SqlDbType.NVarChar, 20).Value = this._strUnvan;
                cmd.Parameters.Add("@strTespilter", SqlDbType.NVarChar).Value = this._strTespilter;
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
                SqlCommand cmd = new SqlCommand("UPDATE [tblDepoDenetleme] SET [GMREF] = @GMREF,[dtTarih] = @dtTarih,[strDenetleyen] = @strDenetleyen,[strUnvan] = @strUnvan,[strTespilter] = @strTespilter WHERE pkID = @pkID", conn);
                cmd.Parameters.Add("@pkID", SqlDbType.Int).Value = this._pkID;
                cmd.Parameters.Add("@GMREF", SqlDbType.Int).Value = this._GMREF;
                cmd.Parameters.Add("@dtTarih", SqlDbType.DateTime).Value = this._dtTarih;
                cmd.Parameters.Add("@strDenetleyen", SqlDbType.NVarChar, 30).Value = this._strDenetleyen;
                cmd.Parameters.Add("@strUnvan", SqlDbType.NVarChar, 20).Value = this._strUnvan;
                cmd.Parameters.Add("@strTespilter", SqlDbType.NVarChar).Value = this._strTespilter;
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
                SqlCommand cmd = new SqlCommand("DELETE FROM [tblDepoDenetleme] WHERE pkID = @pkID", conn);
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
                SqlDataAdapter da = new SqlDataAdapter("SELECT [pkID],[GMREF],(SELECT TOP 1 MUSTERI FROM [Web-Musteri] WHERE GMREF = [tblDepoDenetleme].GMREF) AS MUSTERI,[dtTarih],[strDenetleyen],[strUnvan],[strTespilter] FROM [tblDepoDenetleme] ORDER BY pkID DESC", conn);
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

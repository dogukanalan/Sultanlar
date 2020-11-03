using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Sultanlar.DatabaseObject.Internet
{
    public class IadelerIslem : ISultanlar, IDisposable
    {
        //
        //
        //
        // Alanlar:
        //
        private int _intIadeID;
        private DateTime _dtIrsaliye;
        private string _strVerilen;
        private DateTime _dtVerilis;
        private DateTime _dtMuhasebeVerilis;
        private string _strFatNo;
        private bool _blIadeDegil;
        //
        //
        //
        // Constracter lar:
        //
        private IadelerIslem()
        {
            
        }
        //
        //
        public IadelerIslem(int intIadeID, DateTime dtIrsaliye, string strVerilen, DateTime dtVerilis, DateTime dtMuhasebeVerilis, string strFatNo, 
            bool blIadeDegil)
        {
            this._intIadeID = intIadeID;
            this._dtIrsaliye = dtIrsaliye;
            this._strVerilen = strVerilen;
            this._dtVerilis = dtVerilis;
            this._dtMuhasebeVerilis = dtMuhasebeVerilis;
            this._strFatNo = strFatNo;
            this._blIadeDegil = blIadeDegil;
        }
        //
        //
        public IadelerIslem(DateTime dtIrsaliye, string strVerilen, DateTime dtVerilis, DateTime dtMuhasebeVerilis, string strFatNo,
            bool blIadeDegil)
        {
            this._dtIrsaliye = dtIrsaliye;
            this._strVerilen = strVerilen;
            this._dtVerilis = dtVerilis;
            this._dtMuhasebeVerilis = dtMuhasebeVerilis;
            this._strFatNo = strFatNo;
            this._blIadeDegil = blIadeDegil;
        }
        //
        //
        //
        // Özellikler:
        //
        public int intIadeID { get { return this._intIadeID; } }
        public DateTime dtIrsaliye { get { return this._dtIrsaliye; } set { this._dtIrsaliye = value; } }
        public string strVerilen { get { return this._strVerilen; } set { this._strVerilen = value; } }
        public DateTime dtVerilis { get { return this._dtVerilis; } set { this._dtVerilis = value; } }
        public DateTime dtMuhasebeVerilis { get { return this._dtMuhasebeVerilis; } set { this._dtMuhasebeVerilis = value; } }
        public string strFatNo { get { return this._strFatNo; } set { this._strFatNo = value; } }
        public bool blIadeDegil { get { return this._blIadeDegil; } set { this._blIadeDegil = value; } }
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
            return this._intIadeID.ToString();
        }
        //
        //
        public void DoInsert()
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO [tblINTERNET_IadelerIslem] ([intIadeID],[dtIrsaliye],[strVerilen],[dtVerilis],[dtMuhasebeVerilis],[strFatNo],[blIadeDegil]) VALUES (@intIadeID,@dtIrsaliye,@strVerilen,@dtVerilis,@dtMuhasebeVerilis,@strFatNo,@blIadeDegil)", conn);
                cmd.Parameters.Add("@intIadeID", SqlDbType.Int).Value = this._intIadeID;
                cmd.Parameters.Add("@dtIrsaliye", SqlDbType.SmallDateTime).Value = this._dtIrsaliye == DateTime.MinValue ? (object)DBNull.Value : (object)this._dtIrsaliye;
                cmd.Parameters.Add("@strVerilen", SqlDbType.NVarChar, 50).Value = this._strVerilen;
                cmd.Parameters.Add("@dtVerilis", SqlDbType.DateTime).Value = this._dtVerilis == DateTime.MinValue ? (object)DBNull.Value : (object)this._dtVerilis;
                cmd.Parameters.Add("@dtMuhasebeVerilis", SqlDbType.DateTime).Value = this._dtMuhasebeVerilis == DateTime.MinValue ? (object)DBNull.Value : (object)this._dtMuhasebeVerilis;
                cmd.Parameters.Add("@strFatNo", SqlDbType.VarChar, 150).Value = this._strFatNo;
                cmd.Parameters.Add("@blIadeDegil", SqlDbType.Bit).Value = this._blIadeDegil;
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
                SqlCommand cmd = new SqlCommand("UPDATE [tblINTERNET_IadelerIslem] SET [dtIrsaliye] = @dtIrsaliye,[strVerilen] = @strVerilen,[dtVerilis] = @dtVerilis,[dtMuhasebeVerilis] = @dtMuhasebeVerilis,[strFatNo] = @strFatNo,[blIadeDegil] = @blIadeDegil WHERE [intIadeID] = @intIadeID", conn);
                cmd.Parameters.Add("@dtIrsaliye", SqlDbType.SmallDateTime).Value = this._dtIrsaliye == DateTime.MinValue ? (object)DBNull.Value : (object)this._dtIrsaliye;
                cmd.Parameters.Add("@strVerilen", SqlDbType.NVarChar, 50).Value = this._strVerilen;
                cmd.Parameters.Add("@dtVerilis", SqlDbType.DateTime).Value = this._dtVerilis == DateTime.MinValue ? (object)DBNull.Value : (object)this._dtVerilis;
                cmd.Parameters.Add("@dtMuhasebeVerilis", SqlDbType.DateTime).Value = this._dtMuhasebeVerilis == DateTime.MinValue ? (object)DBNull.Value : (object)this._dtMuhasebeVerilis;
                cmd.Parameters.Add("@strFatNo", SqlDbType.VarChar, 150).Value = this._strFatNo;
                cmd.Parameters.Add("@blIadeDegil", SqlDbType.Bit).Value = this._blIadeDegil;
                cmd.Parameters.Add("@intIadeID", SqlDbType.Int).Value = this._intIadeID;
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
                SqlCommand cmd = new SqlCommand("DELETE FROM [tblINTERNET_IadelerIslem] WHERE intIadeID = @intIadeID", conn);
                cmd.Parameters.Add("@intIadeID", SqlDbType.Int).Value = this._intIadeID;
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
        public static void DoDelete(string FatNo)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM [tblINTERNET_IadelerIslem] WHERE strFatNo = @strFatNo", conn);
                cmd.Parameters.Add("@strFatNo", SqlDbType.NVarChar, 50).Value = FatNo;
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
                SqlDataAdapter da = new SqlDataAdapter("SELECT [tblINTERNET_IadelerIslem].[intIadeID],tblINTERNET_Iadeler.SMREF,(SELECT TOP 1 MUSTERI FROM [Web-Musteri] WHERE SMREF = tblINTERNET_Iadeler.SMREF) AS MUSTERI,tblINTERNET_Iadeler.dtOnaylamaTarihi,[tblINTERNET_IadelerIslem].[dtIrsaliye],[tblINTERNET_IadelerIslem].[strVerilen],[tblINTERNET_IadelerIslem].[dtVerilis],[tblINTERNET_IadelerIslem].[dtMuhasebeVerilis],[tblINTERNET_IadelerIslem].[strFatNo],[tblINTERNET_IadelerIslem].[blIadeDegil],tblINTERNET_Iadeler.strAciklama,'' AS strAciklama2,'' AS strAciklama3,tblINTERNET_IadelerQ.QUANTUMNO FROM [tblINTERNET_IadelerIslem] INNER JOIN tblINTERNET_Iadeler ON [tblINTERNET_IadelerIslem].[intIadeID] = tblINTERNET_Iadeler.pkIadeID INNER JOIN tblINTERNET_IadelerQ ON tblINTERNET_Iadeler.pkIadeID = tblINTERNET_IadelerQ.intIadeID WHERE YEAR(tblINTERNET_Iadeler.dtOnaylamaTarihi) >= YEAR(DATEADD(YEAR, -1, getdate())) UNION ALL SELECT 0 AS [intIadeID],0 AS SMREF,'' AS MUSTERI,NULL AS dtOnaylamaTarihi,NULL AS [dtIrsaliye],'' AS [strVerilen],NULL AS [dtVerilis],NULL AS [dtMuhasebeVerilis],[strFatNo],[tblINTERNET_IadelerIslem].[blIadeDegil],'' AS strAciklama,'' AS strAciklama2,'' AS strAciklama3,'' AS QUANTUMNO FROM [tblINTERNET_IadelerIslem] WHERE intIadeID = 0 ORDER BY [blIadeDegil] ASC, [tblINTERNET_IadelerIslem].[intIadeID] DESC", conn);
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
                if (dt.Rows[i]["strAciklama"].ToString() != string.Empty)
                {
                    string[] Aciklamalar = dt.Rows[i]["strAciklama"].ToString().Split(new string[] { ";;;" }, StringSplitOptions.None);
                    dt.Rows[i]["strAciklama2"] = Aciklamalar[1];
                    dt.Rows[i]["strAciklama3"] = Aciklamalar[2];
                }
            }
        }
        //
        //
        public static IadelerIslem GetObject(int IadeID)
        {
            IadelerIslem donendeger = new IadelerIslem();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT [intIadeID],[dtIrsaliye],[strVerilen],[dtVerilis],[dtMuhasebeVerilis],[strFatNo],[blIadeDegil] FROM [tblINTERNET_IadelerIslem] WHERE [intIadeID] = @intIadeID", conn);
                cmd.Parameters.Add("@intIadeID", SqlDbType.Int).Value = IadeID;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        donendeger = new IadelerIslem(Convert.ToInt32(dr[0]), 
                            dr[1] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dr[1]), 
                            dr[2].ToString(),
                            dr[3] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dr[3]),
                            dr[4] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dr[4]), 
                            dr[5].ToString(), 
                            Convert.ToBoolean(dr[6]));
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
        public static IadelerIslem GetObject(string FatNo, bool IadeDegil)
        {
            IadelerIslem donendeger = new IadelerIslem();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT [intIadeID],[dtIrsaliye],[strVerilen],[dtVerilis],[dtMuhasebeVerilis],[strFatNo],[blIadeDegil] FROM [tblINTERNET_IadelerIslem] WHERE [strFatNo] = @strFatNo AND blIadeDegil = @blIadeDegil", conn);
                cmd.Parameters.Add("@strFatNo", SqlDbType.VarChar, 150).Value = FatNo;
                cmd.Parameters.Add("@blIadeDegil", SqlDbType.Bit).Value = IadeDegil;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        donendeger = new IadelerIslem(Convert.ToInt32(dr[0]),
                            dr[1] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dr[1]),
                            dr[2].ToString(),
                            dr[3] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dr[3]),
                            dr[4] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dr[4]),
                            dr[5].ToString(),
                            Convert.ToBoolean(dr[6]));
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
        public static bool IsExist(int IadeID)
        {
            bool donendeger = false;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT count(*) FROM [tblINTERNET_IadelerIslem] WHERE [intIadeID] = @intIadeID", conn);
                cmd.Parameters.Add("@intIadeID", SqlDbType.Int).Value = IadeID;
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
        public static bool IsExist(string FatNo, bool IadeDegil)
        {
            bool donendeger = false;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT count(*) FROM [tblINTERNET_IadelerIslem] WHERE [strFatNo] = @strFatNo AND [blIadeDegil] = @blIadeDegil", conn);
                cmd.Parameters.Add("@strFatNo", SqlDbType.VarChar, 150).Value = FatNo;
                cmd.Parameters.Add("@blIadeDegil", SqlDbType.Bit).Value = IadeDegil;
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

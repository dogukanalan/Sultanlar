using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Collections;

namespace Sultanlar.DatabaseObject
{
    public class DepoDenetlemeResimler : IDisposable, ISultanlar
    {
        //
        //
        //
        // Alanlar:
        //
        private int _pkID;
        private int _intDepoDenetlemeID;
        private byte[] _binResim;
        private string _strAciklama;
        //
        //
        //
        // Constracter lar:
        //
        private DepoDenetlemeResimler(int pkID, int intDepoDenetlemeID, byte[] binResim, string strAciklama)
        {
            this._pkID = pkID;
            this._intDepoDenetlemeID = intDepoDenetlemeID;
            this._binResim = binResim;
            this._strAciklama = strAciklama;
        }
        //
        //
        public DepoDenetlemeResimler(int intDepoDenetlemeID, byte[] binResim, string strAciklama)
        {
            this._intDepoDenetlemeID = intDepoDenetlemeID;
            this._binResim = binResim;
            this._strAciklama = strAciklama;
        }
        //
        //
        private DepoDenetlemeResimler()
        {

        }
        //
        //
        //
        // Özellikler:
        //
        public int pkID { get { return this._pkID; } }
        public int intDepoDenetlemeID { get { return this._intDepoDenetlemeID; } set { this._intDepoDenetlemeID = value; } }
        public byte[] binResim { get { return this._binResim; } set { this._binResim = value; } }
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
            return this._strAciklama;
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
                SqlCommand cmd = new SqlCommand("INSERT INTO [tblDepoDenetlemeResimler] ([intDepoDenetlemeID],[binResim],[strAciklama]) VALUES (@intDepoDenetlemeID,@binResim,@strAciklama) SELECT @pkID = SCOPE_IDENTITY()", conn);
                cmd.Parameters.Add("@intDepoDenetlemeID", SqlDbType.Int).Value = this._intDepoDenetlemeID;
                cmd.Parameters.Add("@binResim", SqlDbType.VarBinary).Value = this._binResim;
                cmd.Parameters.Add("@strAciklama", SqlDbType.NVarChar, 30).Value = this._strAciklama;
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
                SqlCommand cmd = new SqlCommand("UPDATE [tblDepoDenetlemeResimler] SET [intDepoDenetlemeID] = @intDepoDenetlemeID,[binResim] = @binResim,[strAciklama] = @strAciklama WHERE pkID = @pkID", conn);
                cmd.Parameters.Add("@pkID", SqlDbType.Int).Value = this._pkID; cmd.Parameters.Add("@intDepoDenetlemeID", SqlDbType.Int).Value = this._intDepoDenetlemeID;
                cmd.Parameters.Add("@binResim", SqlDbType.VarBinary).Value = this._binResim;
                cmd.Parameters.Add("@strAciklama", SqlDbType.NVarChar, 30).Value = this._strAciklama;
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
                SqlCommand cmd = new SqlCommand("DELETE FROM [tblDepoDenetlemeResimler] WHERE pkID = @pkID", conn);
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
        public static DepoDenetlemeResimler GetResimler(int ID)
        {
            DepoDenetlemeResimler donendeger = new DepoDenetlemeResimler();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT [pkID],[intDepoDenetlemeID],[binResim],[strAciklama] FROM [tblDepoDenetlemeResimler] WHERE pkID = @pkID", conn);
                cmd.Parameters.Add("@pkID", SqlDbType.Int).Value = ID;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        donendeger._pkID = ID;
                        donendeger._intDepoDenetlemeID = Convert.ToInt32(dr[1]);
                        donendeger._binResim = (byte[])dr[2];
                        donendeger._strAciklama = dr[3].ToString();
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
        public static byte[] GetResim(int ID)
        {
            byte[] donendeger = null;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT [binResim] FROM [tblDepoDenetlemeResimler] WHERE pkID = @pkID", conn);
                cmd.Parameters.Add("@pkID", SqlDbType.Int).Value = ID;
                try
                {
                    conn.Open();
                    object obj = cmd.ExecuteScalar();
                    if (obj != null)
                        donendeger = (byte[])obj;
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
        public static ArrayList GetResimlerByDepoDenetlemeID(int DepoDenetlemeID)
        {
            ArrayList donendeger = new ArrayList();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT [pkID],[intDepoDenetlemeID],[binResim],[strAciklama] FROM [tblDepoDenetlemeResimler] WHERE intDepoDenetlemeID = @intDepoDenetlemeID", conn);
                cmd.Parameters.Add("@intDepoDenetlemeID", SqlDbType.Int).Value = DepoDenetlemeID;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        donendeger.Add(new DepoDenetlemeResimler(Convert.ToInt32(dr[0]), Convert.ToInt32(dr[1]), (byte[])dr[2], dr[3].ToString()));
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

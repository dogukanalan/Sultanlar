using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace Sultanlar.DatabaseObject.Internet
{
    public class BayiCiroPrimleri : ISultanlar, IDisposable
    {
        //
        //
        //
        // Alanlar:
        //
        private int _SMREF;
        private int _intYil;
        private int _intAy;
        private decimal _mnTAH;
        private decimal _mnYEG;
        private string _strAciklama;
        //
        //
        //
        // Constracter lar:
        //
        public BayiCiroPrimleri(int SMREF, int intYil, int intAy, decimal mnTAH, decimal mnYEG, string strAciklama)
        {
            this._SMREF = SMREF;
            this._intYil = intYil;
            this._intAy = intAy;
            this._mnTAH = mnTAH;
            this._mnYEG = mnYEG;
            this._strAciklama = strAciklama;
        }
        //
        //
        private BayiCiroPrimleri()
        {

        }
        //
        //
        //
        // Özellikler:
        //
        public int SMREF { get { return this._SMREF; } set { this._SMREF = value; } }
        public int intYil { get { return this._intYil; } set { this._intYil = value; } }
        public int intAy { get { return this._intAy; } set { this._intAy = value; } }
        public decimal mnTAH { get { return this._mnTAH; } set { this._mnTAH = value; } }
        public decimal mnYEG { get { return this._mnYEG; } set { this._mnYEG = value; } }
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
            return this._SMREF.ToString();
        }
        //
        //
        public void DoInsert()
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO [tblINTERNET_BayiCiroPrimleri] ([SMREF],[intYil],[intAy],[mnTAH],[mnYEG],[strAciklama]) VALUES (@SMREF,@intYil,@intAy,@mnTAH,@mnYEG,@strAciklama)", conn);
                cmd.Parameters.Add("@SMREF", SqlDbType.Int).Value = this._SMREF;
                cmd.Parameters.Add("@intYil", SqlDbType.Int).Value = this._intYil;
                cmd.Parameters.Add("@intAy", SqlDbType.Int).Value = this._intAy;
                cmd.Parameters.Add("@mnTAH", SqlDbType.Money).Value = this._mnTAH;
                cmd.Parameters.Add("@mnYEG", SqlDbType.Money).Value = this._mnYEG;
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
        public void DoUpdate()
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UPDATE [dbo].[tblINTERNET_BayiCiroPrimleri] SET [mnTAH] = @mnTAH,[mnYEG] = @mnYEG,[strAciklama] = @strAciklama WHERE [SMREF] = @SMREF AND [intYil] = @intYil AND [intAy] = @intAy", conn);
                cmd.Parameters.Add("@SMREF", SqlDbType.Int).Value = this._SMREF;
                cmd.Parameters.Add("@intYil", SqlDbType.Int).Value = this._intYil;
                cmd.Parameters.Add("@intAy", SqlDbType.Int).Value = this._intAy;
                cmd.Parameters.Add("@mnTAH", SqlDbType.Money).Value = this._mnTAH;
                cmd.Parameters.Add("@mnYEG", SqlDbType.Money).Value = this._mnYEG;
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
                SqlCommand cmd = new SqlCommand("DELETE FROM tblINTERNET_BayiCiroPrimleri WHERE SMREF = @SMREF AND intYil = @intYil AND intAy = @intAy", conn);
                cmd.Parameters.Add("@SMREF", SqlDbType.Int).Value = this._SMREF;
                cmd.Parameters.Add("@intYil", SqlDbType.Int).Value = this._intYil;
                cmd.Parameters.Add("@intAy", SqlDbType.Int).Value = this._intAy;
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
                SqlDataAdapter da = new SqlDataAdapter("SELECT [SMREF],(SELECT TOP 1 MUSTERI FROM [Web-Musteri-TP] WHERE GMREF = SMREF AND SMREF = [tblINTERNET_BayiCiroPrimleri].SMREF) AS MUSTERI,[intYil],[intAy],[mnTAH],[mnYEG],[strAciklama] FROM [tblINTERNET_BayiCiroPrimleri] ORDER BY intYil,intAy,SMREF", conn);
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
        public static BayiCiroPrimleri GetObject(int SMREF,int Yil, int Ay)
        {
            BayiCiroPrimleri donendeger = new BayiCiroPrimleri();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT [SMREF],[intYil],[intAy],[mnTAH],[mnYEG],[strAciklama] FROM [tblINTERNET_BayiCiroPrimleri] WHERE SMREF = @SMREF AND intYil = @intYil AND intAy = @intAy", conn);
                cmd.Parameters.Add("@SMREF", SqlDbType.Int).Value = SMREF;
                cmd.Parameters.Add("@intYil", SqlDbType.Int).Value = Yil;
                cmd.Parameters.Add("@intAy", SqlDbType.Int).Value = Ay;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        donendeger._SMREF = Convert.ToInt32(dr[0]);
                        donendeger._intYil = Convert.ToInt32(dr[1]);
                        donendeger._intAy = Convert.ToInt32(dr[2]);
                        donendeger._mnTAH = Convert.ToDecimal(dr[3]);
                        donendeger._mnYEG = Convert.ToDecimal(dr[4]);
                        donendeger._strAciklama = dr[5].ToString();
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
        public static bool VarMi(int SMREF, int intYil, int intAy)
        {
            bool donendeger = false;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT count(*) FROM [tblINTERNET_BayiCiroPrimleri] WHERE SMREF = @SMREF AND intYil = @intYil AND intAy = @intAy", conn);
                cmd.Parameters.Add("@SMREF", SqlDbType.Int).Value = SMREF;
                cmd.Parameters.Add("@intYil", SqlDbType.Int).Value = intYil;
                cmd.Parameters.Add("@intAy", SqlDbType.Int).Value = intAy;
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

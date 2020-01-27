using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Sultanlar.DatabaseObject.Internet
{
    public class BayiNihaiKapamalar : ISultanlar, IDisposable
    {
        //
        //
        //
        // Alanlar:
        //
        private int _SMREF;
        private int _intYil;
        private int _intAy;
        private string _strFaturaNo;
        private DateTime _dtFaturaTarih;
        private string _strFaturaNoNF;
        private DateTime _dtFaturaTarihNF;
        private decimal _mnTAH;
        private decimal _mnYEG;
        private string _strAciklama;
        //
        //
        //
        // Constracter lar:
        //
        public BayiNihaiKapamalar(int SMREF, int intYil, int intAy, string strFaturaNo, DateTime dtFaturaTarih, string strFaturaNoNF, DateTime dtFaturaTarihNF, decimal mnTAH, decimal mnYEG, string strAciklama)
        {
            this._SMREF = SMREF;
            this._intYil = intYil;
            this._intAy = intAy;
            this._strFaturaNo = strFaturaNo;
            this._dtFaturaTarih = dtFaturaTarih;
            this._strFaturaNoNF = strFaturaNoNF;
            this._dtFaturaTarihNF = dtFaturaTarihNF;
            this._mnTAH = mnTAH;
            this._mnYEG = mnYEG;
            this._strAciklama = strAciklama;
        }
        //
        //
        private BayiNihaiKapamalar()
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
        public string strFaturaNo { get { return this._strFaturaNo; } set { this._strFaturaNo = value; } }
        public DateTime dtFaturaTarih { get { return this._dtFaturaTarih; } set { this._dtFaturaTarih = value; } }
        public string strFaturaNoNF { get { return this._strFaturaNoNF; } set { this._strFaturaNoNF = value; } }
        public DateTime dtFaturaTarihNF { get { return this._dtFaturaTarihNF; } set { this._dtFaturaTarihNF = value; } }
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
                SqlCommand cmd = new SqlCommand("INSERT INTO [tblINTERNET_BayiNihaiKapamalar] ([SMREF],[intYil],[intAy],strFaturaNo,dtFaturaTarih,strFaturaNoNF,dtFaturaTarihNF,[mnTAH],[mnYEG],[strAciklama]) VALUES (@SMREF,@intYil,@intAy,@strFaturaNo,@dtFaturaTarih,@strFaturaNoNF,@dtFaturaTarihNF,@mnTAH,@mnYEG,@strAciklama)", conn);
                cmd.Parameters.Add("@SMREF", SqlDbType.Int).Value = this._SMREF;
                cmd.Parameters.Add("@intYil", SqlDbType.Int).Value = this._intYil;
                cmd.Parameters.Add("@intAy", SqlDbType.Int).Value = this._intAy;
                cmd.Parameters.Add("@strFaturaNo", SqlDbType.NVarChar, 50).Value = this._strFaturaNo;
                cmd.Parameters.Add("@dtFaturaTarih", SqlDbType.SmallDateTime).Value = this._dtFaturaTarih;
                cmd.Parameters.Add("@strFaturaNoNF", SqlDbType.NVarChar, 50).Value = this._strFaturaNoNF;
                cmd.Parameters.Add("@dtFaturaTarihNF", SqlDbType.SmallDateTime).Value = this._dtFaturaTarihNF;
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
                SqlCommand cmd = new SqlCommand("UPDATE [dbo].[tblINTERNET_BayiNihaiKapamalar] SET dtFaturaTarih = @dtFaturaTarih,dtFaturaTarihNF = @dtFaturaTarihNF,[strFaturaNo] = @strFaturaNo,[strFaturaNoNF] = @strFaturaNoNF,[mnTAH] = @mnTAH,[mnYEG] = @mnYEG,[strAciklama] = @strAciklama WHERE [SMREF] = @SMREF AND [intYil] = @intYil AND [intAy] = @intAy AND [SMREF] = @SMREF AND [intYil] = @intYil", conn);
                cmd.Parameters.Add("@SMREF", SqlDbType.Int).Value = this._SMREF;
                cmd.Parameters.Add("@intYil", SqlDbType.Int).Value = this._intYil;
                cmd.Parameters.Add("@intAy", SqlDbType.Int).Value = this._intAy;
                cmd.Parameters.Add("@strFaturaNo", SqlDbType.NVarChar, 50).Value = this._strFaturaNo;
                cmd.Parameters.Add("@dtFaturaTarih", SqlDbType.SmallDateTime).Value = this._dtFaturaTarih;
                cmd.Parameters.Add("@strFaturaNoNF", SqlDbType.NVarChar, 50).Value = this._strFaturaNoNF;
                cmd.Parameters.Add("@dtFaturaTarihNF", SqlDbType.SmallDateTime).Value = this._dtFaturaTarihNF;
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
                SqlCommand cmd = new SqlCommand("DELETE FROM tblINTERNET_BayiNihaiKapamalar WHERE SMREF = @SMREF AND intYil = @intYil AND intAy = @intAy", conn);
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
                SqlDataAdapter da = new SqlDataAdapter("SELECT [SMREF],(SELECT TOP 1 MUSTERI FROM [Web-Musteri-TP] WHERE GMREF = SMREF AND SMREF = [tblINTERNET_BayiNihaiKapamalar].SMREF) AS MUSTERI,[intYil],[intAy],strFaturaNo,dtFaturaTarih,strFaturaNoNF,dtFaturaTarihNF,[mnTAH],[mnYEG],[strAciklama] FROM [tblINTERNET_BayiNihaiKapamalar] ORDER BY intYil,intAy,SMREF", conn);
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
        public static BayiNihaiKapamalar GetObject(int SMREF, int Yil, int Ay, string FatNo, string FatNoNF)
        {
            BayiNihaiKapamalar donendeger = new BayiNihaiKapamalar();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT [SMREF],[intYil],[intAy],strFaturaNo,dtFaturaTarih,strFaturaNoNF,dtFaturaTarihNF,[mnTAH],[mnYEG],[strAciklama] FROM [tblINTERNET_BayiNihaiKapamalar] WHERE SMREF = @SMREF AND intYil = @intYil AND intAy = @intAy AND strFaturaNo = @strFaturaNo AND strFaturaNoNF = @strFaturaNoNF", conn);
                cmd.Parameters.Add("@SMREF", SqlDbType.Int).Value = SMREF;
                cmd.Parameters.Add("@intYil", SqlDbType.Int).Value = Yil;
                cmd.Parameters.Add("@intAy", SqlDbType.Int).Value = Ay;
                cmd.Parameters.Add("@strFaturaNo", SqlDbType.NVarChar, 50).Value = FatNo;
                cmd.Parameters.Add("@strFaturaNoNF", SqlDbType.NVarChar, 50).Value = FatNoNF;
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
                        donendeger._strFaturaNo = dr[3].ToString();
                        donendeger._dtFaturaTarih = Convert.ToDateTime(dr[4]);
                        donendeger._strFaturaNoNF = dr[5].ToString();
                        donendeger._dtFaturaTarihNF = Convert.ToDateTime(dr[6]);
                        donendeger._mnTAH = Convert.ToDecimal(dr[7]);
                        donendeger._mnYEG = Convert.ToDecimal(dr[8]);
                        donendeger._strAciklama = dr[9].ToString();
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
        public static bool VarMi(int SMREF, int intYil, int intAy, string FatNo, string FatNoNF)
        {
            bool donendeger = false;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT count(*) FROM [tblINTERNET_BayiNihaiKapamalar] WHERE SMREF = @SMREF AND intYil = @intYil AND intAy = @intAy AND strFaturaNo = @strFaturaNo AND strFaturaNoNF = @strFaturaNoNF", conn);
                cmd.Parameters.Add("@SMREF", SqlDbType.Int).Value = SMREF;
                cmd.Parameters.Add("@intYil", SqlDbType.Int).Value = intYil;
                cmd.Parameters.Add("@intAy", SqlDbType.Int).Value = intAy;
                cmd.Parameters.Add("@strFaturaNo", SqlDbType.NVarChar, 50).Value = FatNo;
                cmd.Parameters.Add("@strFaturaNoNF", SqlDbType.NVarChar, 50).Value = FatNoNF;
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

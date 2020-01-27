using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Collections;

namespace Sultanlar.DatabaseObject
{
    public class AT2_AracBedeller
    {
        //
        //
        //
        // Alanlar:
        //
        private int _pkID;
        private int _intAracID;
        private int _intBolgeID;
        private bool _blPasif;
        private decimal _mnBedel;
        private DateTime _dtBaslangic;
        private DateTime _dtBitis;
        private bool _TipBedelEkle;
        //
        //
        //
        // Constracter lar:
        //
        public AT2_AracBedeller(int intAracID, int intBolgeID, bool blPasif, decimal mnBedel, bool TipBedelEkle, DateTime dtBaslangic, DateTime dtBitis)
        {
            this._intAracID = intAracID;
            this._intBolgeID = intBolgeID;
            this._blPasif = blPasif;
            this._mnBedel = mnBedel;
            this._TipBedelEkle = TipBedelEkle;
            this._dtBaslangic = dtBaslangic;
            this._dtBitis = dtBitis;
        }
        //
        //
        private AT2_AracBedeller(int pkID, int intAracID, int intBolgeID, bool blPasif, decimal mnBedel, bool TipBedelEkle, DateTime dtBaslangic, DateTime dtBitis)
        {
            this._pkID = pkID;
            this._intAracID = intAracID;
            this._intBolgeID = intBolgeID;
            this._blPasif = blPasif;
            this._mnBedel = mnBedel;
            this._TipBedelEkle = TipBedelEkle;
            this._dtBaslangic = dtBaslangic;
            this._dtBitis = dtBitis;
        }
        //
        //
        private AT2_AracBedeller()
        {

        }
        //
        //
        //
        // Özellikler:
        //
        public int pkID { get { return this._pkID; } }
        public int intAracID { get { return this._intAracID; } set { this._intAracID = value; } }
        public int intBolgeID { get { return this._intBolgeID; } set { this._intBolgeID = value; } }
        public bool blPasif { get { return this._blPasif; } set { this._blPasif = value; } }
        public decimal mnBedel { get { return this._mnBedel; } set { this._mnBedel = value; } }
        public DateTime dtBaslangic { get { return this._dtBaslangic; } set { this._dtBaslangic = value; } }
        public DateTime dtBitis { get { return this._dtBitis; } set { this._dtBitis = value; } }

        public string ToString2
        {
            get
            {
                string donendeger = string.Empty;
                AT2_Araclar arac = AT2_Araclar.GetObject(this._intAracID);
                AT2_Bolgeler bolge = AT2_Bolgeler.GetObject(this._intBolgeID);
                if (this._TipBedelEkle)
                    donendeger = AT2_Araclar.GetObject(this._intAracID).strPlaka + "  *  " + bolge.strBolge + "  *  " + AT2_AracTipler.GetObject(arac.intAracTipiID).strAracTip + "  *  " + this._mnBedel.ToString("C2");
                else
                    donendeger = AT2_Araclar.GetObject(this._intAracID).strPlaka + " " + bolge.strBolge;
                return donendeger;
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
            return this.ToString2;
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
                SqlCommand cmd = new SqlCommand("INSERT INTO [tblAT2_AracBedeller] ([intAracID],[intBolgeID],blPasif,[mnBedel],dtBaslangic,dtBitis) VALUES (@intAracID,@intBolgeID,@blPasif,@mnBedel,@dtBaslangic,@dtBitis) SELECT @pkID = SCOPE_IDENTITY()", conn);
                cmd.Parameters.Add("@intAracID", SqlDbType.Int).Value = this._intAracID;
                cmd.Parameters.Add("@intBolgeID", SqlDbType.Int).Value = this._intBolgeID;
                cmd.Parameters.Add("@blPasif", SqlDbType.Bit).Value = this._blPasif;
                cmd.Parameters.Add("@mnBedel", SqlDbType.Money).Value = this._mnBedel;
                cmd.Parameters.Add("@dtBaslangic", SqlDbType.DateTime).Value = this._dtBaslangic;
                cmd.Parameters.Add("@dtBitis", SqlDbType.DateTime).Value = this._dtBitis;
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
                SqlCommand cmd = new SqlCommand("UPDATE [tblAT2_AracBedeller] SET [intAracID] = @intAracID,[intBolgeID] = @intBolgeID,blPasif = @blPasif,[mnBedel] = @mnBedel,dtBaslangic = @dtBaslangic,dtBitis = @dtBitis WHERE pkID = @pkID", conn);
                cmd.Parameters.Add("@pkID", SqlDbType.Int).Value = this._pkID;
                cmd.Parameters.Add("@intAracID", SqlDbType.Int).Value = this._intAracID;
                cmd.Parameters.Add("@intBolgeID", SqlDbType.Int).Value = this._intBolgeID;
                cmd.Parameters.Add("@blPasif", SqlDbType.Bit).Value = this._blPasif;
                cmd.Parameters.Add("@mnBedel", SqlDbType.Money).Value = this._mnBedel;
                cmd.Parameters.Add("@dtBaslangic", SqlDbType.DateTime).Value = this._dtBaslangic;
                cmd.Parameters.Add("@dtBitis", SqlDbType.DateTime).Value = this._dtBitis;
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
                SqlCommand cmd = new SqlCommand("DELETE FROM [tblAT2_AracBedeller] WHERE pkID = @pkID", conn);
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
        public static void GetObjects(IList List, bool Pasif, bool UI, bool TipBedelEkle)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                List.Clear();

                SqlCommand cmd = new SqlCommand("SELECT [pkID],[intAracID],[intBolgeID],blPasif,[mnBedel],dtBaslangic,dtBitis FROM [tblAT2_AracBedeller] WHERE blPasif = @blPasif ORDER BY (SELECT strPlaka FROM tblAT2_Araclar WHERE pkID = [tblAT2_AracBedeller].intAracID),(SELECT strBolge FROM tblAT2_Bolgeler WHERE pkID = [tblAT2_AracBedeller].intBolgeID)", conn);
                cmd.Parameters.Add("@blPasif", SqlDbType.Bit).Value = Pasif;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        List.Add(new AT2_AracBedeller(Convert.ToInt32(dr[0]), Convert.ToInt32(dr[1]), Convert.ToInt32(dr[2]),
                            Convert.ToBoolean(dr[3]), Convert.ToDecimal(dr[4]), TipBedelEkle, Convert.ToDateTime(dr[5]), Convert.ToDateTime(dr[6])));
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
        public static void GetObjectsByAracID(IList List, bool Pasif, int AracID, bool UI, bool TipBedelEkle)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                List.Clear();

                SqlCommand cmd = new SqlCommand("SELECT [pkID],[intAracID],[intBolgeID],blPasif,[mnBedel],dtBaslangic,dtBitis FROM [tblAT2_AracBedeller] WHERE blPasif = @blPasif AND intAracID = @intAracID ORDER BY (SELECT strPlaka FROM tblAT2_Araclar WHERE pkID = [tblAT2_AracBedeller].intAracID),(SELECT strBolge FROM tblAT2_Bolgeler WHERE pkID = [tblAT2_AracBedeller].intBolgeID)", conn);
                cmd.Parameters.Add("@blPasif", SqlDbType.Bit).Value = Pasif;
                cmd.Parameters.Add("@intAracID", SqlDbType.Int).Value = AracID;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        List.Add(new AT2_AracBedeller(Convert.ToInt32(dr[0]), Convert.ToInt32(dr[1]), Convert.ToInt32(dr[2]),
                            Convert.ToBoolean(dr[3]), Convert.ToDecimal(dr[4]), TipBedelEkle, Convert.ToDateTime(dr[5]), Convert.ToDateTime(dr[6])));
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
        public static void GetObjectsByBolgeID(IList List, bool Pasif, int BolgeID, bool UI, bool TipBedelEkle)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                List.Clear();

                SqlCommand cmd = new SqlCommand("SELECT [pkID],[intAracID],[intBolgeID],blPasif,[mnBedel],dtBaslangic,dtBitis FROM [tblAT2_AracBedeller] WHERE blPasif = @blPasif AND intBolgeID = @intBolgeID ORDER BY (SELECT strPlaka FROM tblAT2_Araclar WHERE pkID = [tblAT2_AracBedeller].intAracID),(SELECT strBolge FROM tblAT2_Bolgeler WHERE pkID = [tblAT2_AracBedeller].intBolgeID)", conn);
                cmd.Parameters.Add("@blPasif", SqlDbType.Bit).Value = Pasif;
                cmd.Parameters.Add("@intBolgeID", SqlDbType.Int).Value = BolgeID;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        List.Add(new AT2_AracBedeller(Convert.ToInt32(dr[0]), Convert.ToInt32(dr[1]), Convert.ToInt32(dr[2]),
                            Convert.ToBoolean(dr[3]), Convert.ToDecimal(dr[4]), TipBedelEkle, Convert.ToDateTime(dr[5]), Convert.ToDateTime(dr[6])));
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
        public static void GetObjects(IList List, bool Pasif, int TipID, int LojistikFirmaID, bool UI, bool TipBedelEkle)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                List.Clear();

                //SqlCommand cmd = new SqlCommand("SELECT [pkID],[intAracID],[intBolgeID],blPasif,[mnBedel],dtBaslangic,dtBitis FROM [tblAT2_AracBedeller] WHERE blPasif = @blPasif AND intBolgeID = @intBolgeID AND intAracID IN (SELECT pkID FROM tblAT2_Araclar WHERE intLojistikFirmaID = @intLojistikFirmaID) ORDER BY (SELECT strPlaka FROM tblAT2_Araclar WHERE pkID = [tblAT2_AracBedeller].intAracID),(SELECT strBolge FROM tblAT2_Bolgeler WHERE pkID = [tblAT2_AracBedeller].intBolgeID)", conn);
                SqlCommand cmd = new SqlCommand("SELECT [tblAT2_AracBedeller].[pkID],[tblAT2_AracBedeller].[intAracID],[tblAT2_AracBedeller].[intBolgeID],[tblAT2_AracBedeller].blPasif,[tblAT2_AracBedeller].[mnBedel],[tblAT2_AracBedeller].dtBaslangic,[tblAT2_AracBedeller].dtBitis FROM [tblAT2_AracBedeller] INNER JOIN tblAT2_Araclar ON [tblAT2_AracBedeller].intAracID = tblAT2_Araclar.pkID WHERE [tblAT2_AracBedeller].blPasif = @blPasif AND tblAT2_Araclar.intAracTipiID = @intAracTipiID AND tblAT2_Araclar.intLojistikFirmaID = @intLojistikFirmaID ORDER BY tblAT2_Araclar.strPlaka,(SELECT strBolge FROM tblAT2_Bolgeler WHERE pkID = [tblAT2_AracBedeller].intBolgeID)", conn);
                cmd.Parameters.Add("@blPasif", SqlDbType.Bit).Value = Pasif;
                cmd.Parameters.Add("@intAracTipiID", SqlDbType.Int).Value = TipID;
                cmd.Parameters.Add("@intLojistikFirmaID", SqlDbType.Int).Value = LojistikFirmaID;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        List.Add(new AT2_AracBedeller(Convert.ToInt32(dr[0]), Convert.ToInt32(dr[1]), Convert.ToInt32(dr[2]),
                            Convert.ToBoolean(dr[3]), Convert.ToDecimal(dr[4]), TipBedelEkle, Convert.ToDateTime(dr[5]), Convert.ToDateTime(dr[6])));
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
        public static void GetObjects(DataTable dt, bool Pasif)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT [pkID],[intAracID],[intBolgeID],blPasif,[mnBedel],dtBaslangic,dtBitis FROM [tblAT2_AracBedeller] WHERE blPasif = @blPasif ORDER BY (SELECT strPlaka FROM tblAT2_Araclar WHERE pkID = [tblAT2_AracBedeller].intAracID),(SELECT strBolge FROM tblAT2_Bolgeler WHERE pkID = [tblAT2_AracBedeller].intBolgeID)", conn);
                da.SelectCommand.Parameters.Add("@blPasif", SqlDbType.Bit).Value = Pasif;
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
        public static AT2_AracBedeller GetObject(int pkID)
        {
            AT2_AracBedeller donendeger = new AT2_AracBedeller();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT [pkID],[intAracID],[intBolgeID],blPasif,[mnBedel],dtBaslangic,dtBitis FROM [tblAT2_AracBedeller] WHERE pkID = @pkID", conn);
                cmd.Parameters.Add("@pkID", SqlDbType.Int).Value = pkID;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        donendeger = new AT2_AracBedeller(Convert.ToInt32(dr[0]), Convert.ToInt32(dr[1]), Convert.ToInt32(dr[2]),
                            Convert.ToBoolean(dr[3]), Convert.ToDecimal(dr[4]), true, Convert.ToDateTime(dr[5]), Convert.ToDateTime(dr[6]));
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
        public static bool IsExist(int AracID, int BolgeID)
        {
            bool donendeger = false;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT count([pkID]) FROM [tblAT2_AracBedeller] WHERE [intAracID] = @intAracID AND [intBolgeID] = @intBolgeID AND blPasif = 'False'", conn);
                cmd.Parameters.Add("@intAracID", SqlDbType.Int).Value = AracID;
                cmd.Parameters.Add("@intBolgeID", SqlDbType.Int).Value = BolgeID;
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

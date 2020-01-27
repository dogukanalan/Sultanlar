using System;
using System.Data.SqlClient;
using System.Collections;

namespace Sultanlar.DatabaseObject.Internet
{
    public class OzelKodlar : IDisposable
    {
        private string _OZELKOD;
        private string _OZELACIK;
        private string _GRUPKOD;

        public OzelKodlar(string OZELKOD, string OZELACIK) { this._OZELKOD = OZELKOD; this._OZELACIK = OZELACIK; }

        public string OZELKOD { get { return this._OZELKOD; } set { this._OZELKOD = value; } }
        public string OZELACIK { get { return this._OZELACIK; } set { this._OZELACIK = value; } }
        public string GRUPKOD { get { return GetGrupKodByOzelKod(this._OZELKOD); } set { this._GRUPKOD = value; } }

        public void Dispose() { GC.SuppressFinalize(this); }

        public override string ToString() { return this._OZELACIK; }

        public static string GetObjectByOzelKod(string OzelKod)
        {
            string donendeger = string.Empty;
            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3))
            {
                SqlCommand cmd = new SqlCommand("SELECT [OZEL ACIK] FROM [Web-OzelKodlar] WHERE [OZEL KOD] = @OZELKOD", conn);
                cmd.Parameters.Add("@OZELKOD", System.Data.SqlDbType.VarChar, 25).Value = OzelKod;
                try { conn.Open(); object obj = cmd.ExecuteScalar(); if (obj != null) donendeger = obj.ToString(); }
                catch (SqlException ex) { Hatalar.DoInsert(ex); }
                finally { conn.Close(); }
            }
            return donendeger;
        }

        public static string GetGrupKodByOzelKod(string OzelKod)
        {
            string donendeger = string.Empty;
            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3))
            {
                SqlCommand cmd = new SqlCommand("SELECT [GRUP KOD] FROM [Web-OzelKodlar] WHERE [OZEL KOD] = @OZELKOD", conn);
                cmd.Parameters.Add("@OZELKOD", System.Data.SqlDbType.VarChar, 25).Value = OzelKod;
                try { conn.Open(); object obj = cmd.ExecuteScalar(); if (obj != null) donendeger = obj.ToString(); }
                catch (SqlException ex) { Hatalar.DoInsert(ex); }
                finally { conn.Close(); }
            }
            return donendeger;
        }

        public static ArrayList GetObjectsByGrupKod(string GrupKod)
        {
            ArrayList donendeger = new ArrayList();
            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3))
            {
                SqlCommand cmd = new SqlCommand("SELECT [OZEL KOD], [OZEL ACIK] FROM [Web-OzelKodlar] WHERE [GRUP KOD] = @GRUPKOD", conn);
                cmd.Parameters.Add("@GRUPKOD", System.Data.SqlDbType.VarChar, 25).Value = GrupKod;
                SqlDataReader dr;
                try 
                { 
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        donendeger.Add(new OzelKodlar(dr[0].ToString(), dr[1].ToString()));
                    }
                }
                catch (SqlException ex) { Hatalar.DoInsert(ex); }
                finally { conn.Close(); }
            }
            return donendeger;
        }
    }
    public class ReyonKodlar : IDisposable
    {
        private string _REYKOD;
        private string _REYACIK;

        public ReyonKodlar(string REYKOD, string REYACIK) { this._REYKOD = REYKOD; this._REYACIK = REYACIK; }

        public string REYKOD { get { return this._REYKOD; } set { this._REYKOD = value; } }
        public string REYACIK { get { return this._REYACIK; } set { this._REYACIK = value; } }

        public void Dispose() { GC.SuppressFinalize(this); }

        public override string ToString() { return this._REYACIK; }
    }

    public class GrupKodlar : IDisposable
    {
        private string _GRUPKOD;
        private string _GRUPACIK;

        public GrupKodlar(string GRUPKOD, string GRUPACIK) { this._GRUPKOD = GRUPKOD; this._GRUPACIK = GRUPACIK; }

        public string GRUPKOD { get { return this._GRUPKOD; } set { this._GRUPKOD = value; } }
        public string GRUPACIK { get { return this._GRUPACIK; } set { this._GRUPACIK = value; } }

        public void Dispose() { GC.SuppressFinalize(this); }

        public override string ToString() { return this._GRUPACIK; }

        public static string GetObjectByGrupKod(string GrupKod)
        {
            string donendeger = string.Empty;
            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3))
            {
                SqlCommand cmd = new SqlCommand("SELECT [GRUP ACIK] FROM [Web-GrupKodlar] WHERE [GRUP KOD] = @GRUPKOD", conn);
                cmd.Parameters.Add("@GRUPKOD", System.Data.SqlDbType.VarChar, 25).Value = GrupKod;
                try { conn.Open(); object obj = cmd.ExecuteScalar(); if (obj != null) donendeger = obj.ToString(); }
                catch (SqlException ex) { Hatalar.DoInsert(ex); }
                finally { conn.Close(); }
            }
            return donendeger;
        }
    }
}

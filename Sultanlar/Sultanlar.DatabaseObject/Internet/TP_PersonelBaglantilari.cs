using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace Sultanlar.DatabaseObject.Internet
{
    public class TP_PersonelBaglantilari
    {
        //
        //
        //
        // Alanlar:
        //
        private int _SMREF;
        private bool _blBayi;
        private int _intPersonelID;
        private string _strAciklama;
        //
        //
        //
        // Constracter lar:
        //
        public TP_PersonelBaglantilari(int SMREF, bool blBayi, int intPersonelID, string strAciklama)
        {
            this._SMREF = SMREF;
            this._blBayi = blBayi;
            this._intPersonelID = intPersonelID;
            this._strAciklama = strAciklama;
        }
        //
        //
        //
        // Özellikler:
        //
        public int SMREF { get { return this._SMREF; } }
        public bool blBayi { get { return this._blBayi; } }
        public int intPersonelID { get { return this._intPersonelID; } }
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
        public static void DoInsert(int SMREF, bool blBayi, int PersonelID, string strAciklama)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd2 = new SqlCommand("SELECT count(*) FROM [Web-Musteri-TP_PersonelBaglantilari] WHERE SMREF = @SMREF AND blBayi = @blBayi AND intPersonelID = @intPersonelID", conn);
                cmd2.Parameters.Add("@SMREF", SqlDbType.Int).Value = SMREF;
                cmd2.Parameters.Add("@blBayi", SqlDbType.Bit).Value = blBayi;
                cmd2.Parameters.Add("@intPersonelID", SqlDbType.Int).Value = PersonelID;

                conn.Open();
                bool var = Convert.ToBoolean(cmd2.ExecuteScalar());
                conn.Close();
                if (!var)
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO [Web-Musteri-TP_PersonelBaglantilari] (SMREF,blBayi,intPersonelID,strAciklama) VALUES (@SMREF,@blBayi,@intPersonelID,@strAciklama)", conn);
                    cmd.Parameters.Add("@SMREF", SqlDbType.Int).Value = SMREF;
                    cmd.Parameters.Add("@blBayi", SqlDbType.Bit).Value = blBayi;
                    cmd.Parameters.Add("@intPersonelID", SqlDbType.Int).Value = PersonelID;
                    cmd.Parameters.Add("@strAciklama", SqlDbType.NVarChar).Value = strAciklama;

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }
        //
        //
        public static void DoDelete(int SMREF, bool blBayi, int PersonelID)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM [Web-Musteri-TP_PersonelBaglantilari] WHERE SMREF = @SMREF AND blBayi = @blBayi AND intPersonelID = @intPersonelID", conn);
                cmd.Parameters.Add("@SMREF", SqlDbType.Int).Value = SMREF;
                cmd.Parameters.Add("@blBayi", SqlDbType.Bit).Value = blBayi;
                cmd.Parameters.Add("@intPersonelID", SqlDbType.Int).Value = PersonelID;

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
        //
        //
        public static void DoDelete(int PersonelID)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM [Web-Musteri-TP_PersonelBaglantilari] WHERE intPersonelID = @intPersonelID", conn);
                cmd.Parameters.Add("@intPersonelID", SqlDbType.Int).Value = PersonelID;

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
        //
        //
        public static void GetObjects(DataTable dt)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT (SELECT BAYIUNVAN FROM [Web-Musteri-TP-Bayikodlar] WHERE BAYIKOD = [Web-Musteri-TP].GMREF) AS BAYI,[SUBE] AS NOKTA,strAd + ' ' + strSoyad AS PERSONEL,strTur AS UNVAN FROM [Web-Musteri-TP] LEFT OUTER JOIN [Web-Musteri-TP_PersonelBaglantilari] ON [Web-Musteri-TP].SMREF = [Web-Musteri-TP_PersonelBaglantilari].SMREF LEFT OUTER JOIN [Web-Musteri-TP_Personeller] ON [Web-Musteri-TP_PersonelBaglantilari].intPersonelID = [Web-Musteri-TP_Personeller].pkID LEFT OUTER JOIN [Web-Musteri-TP_PersonelTurleri] ON [Web-Musteri-TP_Personeller].intTur = [Web-Musteri-TP_PersonelTurleri].pkID WHERE [Web-Musteri-TP].GMREF != [Web-Musteri-TP].SMREF ORDER BY BAYI,NOKTA,PERSONEL", conn);
                da.Fill(dt);
            }
        }
        //
        //
        public static void GetObjects(DataTable dt, int SMREF, bool blBayi)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT (SELECT BAYIUNVAN FROM [Web-Musteri-TP-Bayikodlar] WHERE BAYIKOD = [Web-Musteri-TP].GMREF) AS BAYI,[SUBE] AS NOKTA,strAd + ' ' + strSoyad AS PERSONEL,strTur AS UNVAN FROM [Web-Musteri-TP] LEFT OUTER JOIN [Web-Musteri-TP_PersonelBaglantilari] ON [Web-Musteri-TP].SMREF = [Web-Musteri-TP_PersonelBaglantilari].SMREF LEFT OUTER JOIN [Web-Musteri-TP_Personeller] ON [Web-Musteri-TP_PersonelBaglantilari].intPersonelID = [Web-Musteri-TP_Personeller].pkID LEFT OUTER JOIN [Web-Musteri-TP_PersonelTurleri] ON [Web-Musteri-TP_Personeller].intTur = [Web-Musteri-TP_PersonelTurleri].pkID WHERE [Web-Musteri-TP].GMREF != [Web-Musteri-TP].SMREF AND [Web-Musteri-TP].SMREF = @SMREF AND blBayi = @blBayi ORDER BY BAYI,NOKTA,PERSONEL", conn);
                da.SelectCommand.Parameters.Add("@SMREF", SqlDbType.Int).Value = SMREF;
                da.SelectCommand.Parameters.Add("@blBayi", SqlDbType.Bit).Value = blBayi;
                da.Fill(dt);
            }
        }
        //
        //
        public static void GetObjects(DataTable dt, int PersonelID)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT blBayi,[Web-Musteri-TP_PersonelBaglantilari].SMREF,CASE WHEN blBayi = 'True' THEN (SELECT BAYIUNVAN FROM [Web-Musteri-TP-Bayikodlar] WHERE BAYIKOD = [Web-Musteri-TP].GMREF) ELSE 'SULTANLAR PAZARLAMA A.Ş.' END AS BAYI,CASE WHEN blBayi = 'True' THEN [SUBE] ELSE (SELECT DISTINCT SUBE FROM [Web-Musteri] WHERE SMREF = [Web-Musteri-TP_PersonelBaglantilari].SMREF) END AS NOKTA,strAd + ' ' + strSoyad AS PERSONEL,strTur AS UNVAN FROM [Web-Musteri-TP] LEFT OUTER JOIN [Web-Musteri-TP_PersonelBaglantilari] ON [Web-Musteri-TP].SMREF = [Web-Musteri-TP_PersonelBaglantilari].SMREF LEFT OUTER JOIN [Web-Musteri-TP_Personeller] ON [Web-Musteri-TP_PersonelBaglantilari].intPersonelID = [Web-Musteri-TP_Personeller].pkID LEFT OUTER JOIN [Web-Musteri-TP_PersonelTurleri] ON [Web-Musteri-TP_Personeller].intTur = [Web-Musteri-TP_PersonelTurleri].pkID WHERE [Web-Musteri-TP].GMREF != [Web-Musteri-TP].SMREF AND [Web-Musteri-TP_PersonelBaglantilari].intPersonelID = @intPersonelID ORDER BY BAYI,NOKTA,PERSONEL", conn);
                da.SelectCommand.Parameters.Add("@intPersonelID", SqlDbType.Int).Value = PersonelID;
                da.Fill(dt);
            }
        }
    }
}

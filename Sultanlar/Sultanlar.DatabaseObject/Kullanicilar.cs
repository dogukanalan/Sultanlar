using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Collections;

namespace Sultanlar.DatabaseObject
{
    public class Kullanicilar
    {
        public Kullanicilar(string KAdi, string Sifre)
        {
            this.KAdi = KAdi;
            this.Sifre = Sifre;
        }

        public string KAdi { get; set; }
        public string Sifre { get; set; }

        public override string ToString()
        {
            return this.KAdi;
        }

        public static bool Login(string KAdi, string Sifre)
        {
            bool donendeger = false;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT count(*) FROM tblKullanicilar WHERE strKAdi = @strKAdi AND strSifre = @strSifre", conn);
                cmd.Parameters.Add("@strKAdi", SqlDbType.NVarChar, 50).Value = KAdi;
                cmd.Parameters.Add("@strSifre", SqlDbType.NVarChar, 50).Value = Sifre;
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

        public static void Get(IList List)
        {
            List.Clear();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT strKAdi,strSifre FROM tblKullanicilar ORDER BY strKAdi", conn);
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                        List.Add(new Kullanicilar(dr[0].ToString(), dr[1].ToString()));
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

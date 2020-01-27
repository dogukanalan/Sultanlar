using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Collections;

namespace Sultanlar.DatabaseObject.Kenton
{
    public class Tarifler : ISultanlar
    {
        public int pkID { get; set; }
        public int intUyeID { get; set; }
        public Uyeler Uye { get { return Uyeler.GetObject(this.intUyeID); } }
        public bool blOnay { get; set; }
        public string strBaslik { get; set; }
        public string strMalzemeler { get; set; }
        public string strHazirlanis { get; set; }
        public byte[] binResim { get; set; }
        public byte[] binResimUrunler { get; set; }
        public string strUrunlerLink { get; set; }
        public DateTime dtTarih { get; set; }
        public double OrtPuan
        {
            get
            {
                List<TarifPuan> puanlar = TarifPuan.GetObjectByTarifID(this.pkID);
                double Puan = 0;
                for (int i = 0; i < puanlar.Count; i++)
                {
                    Puan += puanlar[i].intPuan;
                }
                return puanlar.Count == 0 ? 0 : Puan / puanlar.Count;
            }
        }
        public List<TarifKategori> TarifKategoriler { get { return TarifKategori.GetObjectsByTarifID(this.pkID); } }

        private Tarifler(int pkID, int intUyeID, bool blOnay, string strBaslik, string strMalzemeler, string strHazirlanis, byte[] binResim,
            byte[] binResimUrunler, string strUrunlerLink, DateTime dtTarih)
        {
            this.pkID = pkID;
            this.intUyeID = intUyeID;
            this.blOnay = blOnay;
            this.strBaslik = strBaslik;
            this.strMalzemeler = strMalzemeler;
            this.strHazirlanis = strHazirlanis;
            this.binResim = binResim;
            this.binResimUrunler = binResimUrunler;
            this.strUrunlerLink = strUrunlerLink;
            this.dtTarih = dtTarih;
        }

        public Tarifler(int intUyeID, bool blOnay, string strBaslik, string strMalzemeler, string strHazirlanis, byte[] binResim, byte[] binResimUrunler,
            string strUrunlerLink, DateTime dtTarih)
        {
            this.intUyeID = intUyeID;
            this.blOnay = blOnay;
            this.strBaslik = strBaslik;
            this.strMalzemeler = strMalzemeler;
            this.strHazirlanis = strHazirlanis;
            this.binResim = binResim;
            this.binResimUrunler = binResimUrunler;
            this.strUrunlerLink = strUrunlerLink;
            this.dtTarih = dtTarih;
        }

        public Tarifler()
        {
            // TODO: Complete member initialization
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public override string ToString()
        {
            return this.strBaslik;
        }

        public void DoInsert()
        {
            object resimUrunler = this.binResimUrunler;
            if (resimUrunler == null)
                resimUrunler = DBNull.Value;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO [tblKENTON_Tarifler] ([intUyeID],[blOnay],[strBaslik],[strMalzemeler],[strHazirlanis],[binResim],binResimUrunler,strLinkUrunler,dtTarih) VALUES (@intUyeID,@blOnay,dbo.IlkHarfBuyuk2(@strBaslik),@strMalzemeler,@strHazirlanis,@binResim,@binResimUrunler,@strLinkUrunler,@dtTarih) SELECT @pkID = SCOPE_IDENTITY()", conn);
                cmd.Parameters.Add("@intUyeID", SqlDbType.Int).Value = this.intUyeID;
                cmd.Parameters.Add("@blOnay", SqlDbType.Bit).Value = this.blOnay;
                cmd.Parameters.Add("@strBaslik", SqlDbType.NVarChar, 50).Value = this.strBaslik;
                cmd.Parameters.Add("@strMalzemeler", SqlDbType.NVarChar).Value = this.strMalzemeler;
                cmd.Parameters.Add("@strHazirlanis", SqlDbType.NVarChar).Value = this.strHazirlanis;
                cmd.Parameters.Add("@binResim", SqlDbType.VarBinary).Value = this.binResim;
                cmd.Parameters.Add("@binResimUrunler", SqlDbType.VarBinary).Value = resimUrunler;
                cmd.Parameters.Add("@strLinkUrunler", SqlDbType.NVarChar, 100).Value = this.strUrunlerLink;
                cmd.Parameters.Add("@dtTarih", SqlDbType.DateTime).Value = this.dtTarih;
                cmd.Parameters.Add("@pkID", SqlDbType.Int).Direction = ParameterDirection.Output;
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    this.pkID = Convert.ToInt32(cmd.Parameters["@pkID"].Value);
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

        public void DoUpdate()
        {
            object resimUrunler = this.binResimUrunler;
            if (resimUrunler == null)
                resimUrunler = DBNull.Value;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UPDATE [tblKENTON_Tarifler] SET [intUyeID] = @intUyeID,[blOnay] = @blOnay,[strBaslik] = @strBaslik,[strMalzemeler] = @strMalzemeler,[strHazirlanis] = @strHazirlanis,[binResim] = @binResim,binResimUrunler = @binResimUrunler,strLinkUrunler = @strLinkUrunler,dtTarih = @dtTarih WHERE pkID = @pkID", conn);
                cmd.Parameters.Add("@intUyeID", SqlDbType.Int).Value = this.intUyeID;
                cmd.Parameters.Add("@blOnay", SqlDbType.Bit).Value = this.blOnay;
                cmd.Parameters.Add("@strBaslik", SqlDbType.NVarChar, 50).Value = this.strBaslik;
                cmd.Parameters.Add("@strMalzemeler", SqlDbType.NVarChar).Value = this.strMalzemeler;
                cmd.Parameters.Add("@strHazirlanis", SqlDbType.NVarChar).Value = this.strHazirlanis;
                cmd.Parameters.Add("@binResim", SqlDbType.VarBinary).Value = this.binResim;
                cmd.Parameters.Add("@binResimUrunler", SqlDbType.VarBinary).Value = resimUrunler;
                cmd.Parameters.Add("@strLinkUrunler", SqlDbType.NVarChar, 100).Value = this.strUrunlerLink;
                cmd.Parameters.Add("@dtTarih", SqlDbType.DateTime).Value = this.dtTarih;
                cmd.Parameters.Add("@pkID", SqlDbType.Int).Value = this.pkID;
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

        public void DoDelete()
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("DELETE [tblKENTON_Tarifler] WHERE pkID = @pkID DELETE [tblKENTON_TarifFav] WHERE intTarifID = @pkID DELETE [tblKENTON_TarifGoruntuleme] WHERE intTarifID = @pkID DELETE [tblKENTON_TarifKategori] WHERE intTarifID = @pkID DELETE [tblKENTON_TarifPuan] WHERE intTarifID = @pkID DELETE [tblKENTON_TarifUrun] WHERE intTarifID = @pkID DELETE [tblKENTON_Yorumlar] WHERE intTarifID = @pkID", conn);
                cmd.Parameters.Add("@pkID", SqlDbType.Int).Value = this.pkID;
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

        public static void GetObjects(IList List, bool kullanicilar)
        {
            List.Clear();

            string where = kullanicilar ? " WHERE intUyeID != 1" : " WHERE intUyeID = 1";

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT [pkID],[intUyeID],[blOnay],[strBaslik],[strMalzemeler],[strHazirlanis],[strLinkUrunler],[dtTarih] FROM [tblKENTON_Tarifler]" + where + " ORDER BY tblKENTON_Tarifler.dtTarih DESC", conn);
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                        List.Add(new Tarifler(Convert.ToInt32(dr[0]), Convert.ToInt32(dr[1]), Convert.ToBoolean(dr[2]), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), 
                            null, //(byte[])dr[6],
                            null, //(dr[7] == DBNull.Value ? null : (byte[])dr[7]),
                            dr[6].ToString(), Convert.ToDateTime(dr[7])));
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

        public static Tarifler GetObject(int ID)
        {
            Tarifler donendeger = new Tarifler();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT [pkID],[intUyeID],[blOnay],[strBaslik],[strMalzemeler],[strHazirlanis],binResim,binResimUrunler,strLinkUrunler,dtTarih FROM [tblKENTON_Tarifler] WHERE pkID = @pkID", conn);
                cmd.Parameters.Add("@pkID", SqlDbType.Int).Value = ID;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        donendeger.pkID = ID;
                        donendeger.intUyeID = Convert.ToInt32(dr[1]);
                        donendeger.blOnay = Convert.ToBoolean(dr[2]);
                        donendeger.strBaslik = dr[3].ToString();
                        donendeger.strMalzemeler = dr[4].ToString();
                        donendeger.strHazirlanis = dr[5].ToString();
                        donendeger.binResim = (byte[])dr[6];
                        donendeger.binResimUrunler = dr[7] != DBNull.Value ? (byte[])dr[7] : null;
                        donendeger.strUrunlerLink = dr[8].ToString();
                        donendeger.dtTarih = Convert.ToDateTime(dr[9]);
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

        public byte[] GetResim()
        {
            byte[] donendeger = new byte[] { };

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT [binResim] FROM [tblKENTON_Tarifler] WHERE pkID = @pkID", conn);
                cmd.Parameters.Add("@pkID", SqlDbType.Int).Value = this.pkID;
                try
                {
                    conn.Open();
                    donendeger = (byte[])cmd.ExecuteScalar();
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

        public static byte[] GetResim(int TarifID)
        {
            byte[] donendeger = new byte[] { };

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT [binResim] FROM [tblKENTON_Tarifler] WHERE pkID = @pkID", conn);
                cmd.Parameters.Add("@pkID", SqlDbType.Int).Value = TarifID;
                try
                {
                    conn.Open();
                    donendeger = (byte[])cmd.ExecuteScalar();
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

        public static byte[] GetResimUrunler(int TarifID)
        {
            byte[] donendeger = null;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT [binResimUrunler] FROM [tblKENTON_Tarifler] WHERE pkID = @pkID", conn);
                cmd.Parameters.Add("@pkID", SqlDbType.Int).Value = TarifID;
                try
                {
                    conn.Open();
                    object obj = cmd.ExecuteScalar();
                    if (obj != DBNull.Value)
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

        public static List<Tarifler> GetObjects(int baslangic, int kactane, string Aranan, int KatID , string Siralama)
        {
            List<Tarifler> donendeger = new List<Tarifler>();

            string aranan = Aranan != string.Empty ? "AND (strBaslik LIKE '%" + Aranan + "%' OR strMalzemeler LIKE '%" + Aranan + "%' OR strHazirlanis LIKE '%" + Aranan + "%') " : "";
            string siralama = Siralama == "puan" ? "ORDER BY (SELECT sum(CONVERT(float,intPuan)) / count(intTarifID) FROM tblKENTON_TarifPuan WHERE intTarifID = tblKENTON_Tarifler.pkID) DESC,tblKENTON_Tarifler.dtTarih DESC"
                : Siralama == "yorum" ? "ORDER BY (SELECT count(intTarifID) FROM tblKENTON_Yorumlar WHERE intTarifID = tblKENTON_Tarifler.pkID) DESC,tblKENTON_Tarifler.dtTarih DESC"
                : Siralama == "random" ? "ORDER BY NEWID()"
                : "ORDER BY tblKENTON_Tarifler.dtTarih DESC"; // hiçbiri değil ise en yeniye göre
            string top20 = Siralama == "random" ? "TOP 20 " : "";

            string kategori = KatID != 0 ? "INNER JOIN tblKENTON_TarifKategori ON [tblKENTON_Tarifler].[pkID] = tblKENTON_TarifKategori.intTarifID " : "";
            string kategori2 = KatID != 0 ? "AND intKategoriID = " + KatID.ToString() + " " : "";

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT " + top20 + "[tblKENTON_Tarifler].[pkID],[intUyeID],[blOnay],[strBaslik],[strMalzemeler],[strHazirlanis],dtTarih FROM [tblKENTON_Tarifler] " + kategori + "WHERE intUyeID = 1 AND blOnay = 'True' " + kategori2 + aranan + siralama, conn);
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    int index = 0;
                    while (dr.Read())
                    {
                        if (index >= baslangic && index < kactane + baslangic)
                        {
                            donendeger.Add(new Tarifler(Convert.ToInt32(dr[0]), Convert.ToInt32(dr[1]), Convert.ToBoolean(dr[2]), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), null, null, "", Convert.ToDateTime(dr[6])));
                        }
                        index++;
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

        public static List<Tarifler> GetObjectsOwn(int baslangic, int kactane, int UyeID, string Aranan, string Siralama)
        {
            List<Tarifler> donendeger = new List<Tarifler>();

            string aranan = Aranan != string.Empty ? "AND (strBaslik LIKE '%" + Aranan + "%' OR strMalzemeler LIKE '%" + Aranan + "%' OR strHazirlanis LIKE '%" + Aranan + "%') " : "";
            string siralama = Siralama == "puan" ? "ORDER BY (SELECT sum(CONVERT(float,intPuan)) / count(intTarifID) FROM tblKENTON_TarifPuan WHERE intTarifID = tblKENTON_Tarifler.pkID) DESC"
                : Siralama == "yorum" ? "ORDER BY (SELECT count(intTarifID) FROM tblKENTON_Yorumlar WHERE intTarifID = tblKENTON_Tarifler.pkID) DESC"
                : "ORDER BY tblKENTON_Tarifler.dtTarih DESC"; // hiçbiri değil ise en yeniye göre

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT [pkID],[intUyeID],[blOnay],[strBaslik],[strMalzemeler],[strHazirlanis],dtTarih FROM [tblKENTON_Tarifler] WHERE intUyeID = @intUyeID " + aranan + siralama, conn);
                cmd.Parameters.Add("@intUyeID", SqlDbType.Int).Value = UyeID;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    int index = 0;
                    while (dr.Read())
                    {
                        if (index >= baslangic && index < kactane + baslangic)
                        {
                            donendeger.Add(new Tarifler(Convert.ToInt32(dr[0]), Convert.ToInt32(dr[1]), Convert.ToBoolean(dr[2]), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), null, null, "", Convert.ToDateTime(dr[6])));
                        }
                        index++;
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

        public static List<Tarifler> GetObjectsFav(int baslangic, int kactane, int UyeID, string Aranan, string Siralama)
        {
            List<Tarifler> donendeger = new List<Tarifler>();

            string aranan = Aranan != string.Empty ? "AND (strBaslik LIKE '%" + Aranan + "%' OR strMalzemeler LIKE '%" + Aranan + "%' OR strHazirlanis LIKE '%" + Aranan + "%') " : "";
            string siralama = Siralama == "puan" ? "ORDER BY (SELECT sum(CONVERT(float,intPuan)) / count(intTarifID) FROM tblKENTON_TarifPuan WHERE intTarifID = tblKENTON_Tarifler.pkID) DESC"
                : Siralama == "yorum" ? "ORDER BY (SELECT count(intTarifID) FROM tblKENTON_Yorumlar WHERE intTarifID = tblKENTON_Tarifler.pkID) DESC"
                : "ORDER BY tblKENTON_Tarifler.dtTarih DESC"; // hiçbiri değil ise en yeniye göre

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT tblKENTON_Tarifler.[pkID],tblKENTON_Tarifler.[intUyeID],[blOnay],[strBaslik],[strMalzemeler],[strHazirlanis],tblKENTON_Tarifler.dtTarih FROM [tblKENTON_Tarifler] INNER JOIN tblKENTON_TarifFav ON tblKENTON_Tarifler.pkID = tblKENTON_TarifFav.intTarifID WHERE blOnay = 'True' AND tblKENTON_TarifFav.intUyeID = @intUyeID " + aranan + siralama, conn);
                cmd.Parameters.Add("@intUyeID", SqlDbType.Int).Value = UyeID;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    int index = 0;
                    while (dr.Read())
                    {
                        if (index >= baslangic && index < kactane + baslangic)
                        {
                            donendeger.Add(new Tarifler(Convert.ToInt32(dr[0]), Convert.ToInt32(dr[1]), Convert.ToBoolean(dr[2]), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), null, null, "", Convert.ToDateTime(dr[6])));
                        }
                        index++;
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

        public static List<Tarifler> GetObjectsKul(int baslangic, int kactane, string Aranan, int KatID, string Siralama)
        {
            List<Tarifler> donendeger = new List<Tarifler>();

            string aranan = Aranan != string.Empty ? "AND (strBaslik LIKE '%" + Aranan + "%' OR strMalzemeler LIKE '%" + Aranan + "%' OR strHazirlanis LIKE '%" + Aranan + "%') " : "";
            string siralama = Siralama == "puan" ? "ORDER BY (SELECT sum(CONVERT(float,intPuan)) / count(intTarifID) FROM tblKENTON_TarifPuan WHERE intTarifID = tblKENTON_Tarifler.pkID) DESC,tblKENTON_Tarifler.dtTarih DESC"
                : Siralama == "yorum" ? "ORDER BY (SELECT count(intTarifID) FROM tblKENTON_Yorumlar WHERE intTarifID = tblKENTON_Tarifler.pkID) DESC,tblKENTON_Tarifler.dtTarih DESC"
                : Siralama == "random" ? "ORDER BY NEWID()"
                : "ORDER BY tblKENTON_Tarifler.dtTarih DESC"; // hiçbiri değil ise en yeniye göre
            string top20 = Siralama == "random" ? "TOP 20 " : "";

            string kategori = KatID != 0 ? "INNER JOIN tblKENTON_TarifKategori ON [tblKENTON_Tarifler].[pkID] = tblKENTON_TarifKategori.intTarifID " : "";
            string kategori2 = KatID != 0 ? "AND intKategoriID = " + KatID.ToString() + " " : "";

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT " + top20 + "[tblKENTON_Tarifler].[pkID],[intUyeID],[blOnay],[strBaslik],[strMalzemeler],[strHazirlanis],dtTarih FROM [tblKENTON_Tarifler] " + kategori + "WHERE intUyeID != 1 AND blOnay = 'True' " + kategori2 + aranan + siralama, conn);
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    int index = 0;
                    while (dr.Read())
                    {
                        if (index >= baslangic && index < kactane + baslangic)
                        {
                            donendeger.Add(new Tarifler(Convert.ToInt32(dr[0]), Convert.ToInt32(dr[1]), Convert.ToBoolean(dr[2]), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), null, null, "", Convert.ToDateTime(dr[6])));
                        }
                        index++;
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

        public static List<Tarifler> GetObjectsByUrunID(int baslangic, int kactane, int UrunID, string Aranan, string Siralama)
        {
            List<Tarifler> donendeger = new List<Tarifler>();

            string aranan = Aranan != string.Empty ? "AND (strBaslik LIKE '%" + Aranan + "%' OR strMalzemeler LIKE '%" + Aranan + "%' OR strHazirlanis LIKE '%" + Aranan + "%') " : "";
            string siralama = Siralama == "puan" ? "ORDER BY (SELECT sum(CONVERT(float,intPuan)) / count(intTarifID) FROM tblKENTON_TarifPuan WHERE intTarifID = tblKENTON_Tarifler.pkID) DESC"
                : Siralama == "yorum" ? "ORDER BY (SELECT count(intTarifID) FROM tblKENTON_Yorumlar WHERE intTarifID = tblKENTON_Tarifler.pkID) DESC"
                : "ORDER BY tblKENTON_Tarifler.dtTarih DESC"; // hiçbiri değil ise en yeniye göre

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT [tblKENTON_Tarifler].[pkID],[intUyeID],[blOnay],[strBaslik],[strMalzemeler],[strHazirlanis],dtTarih FROM [tblKENTON_Tarifler] INNER JOIN tblKENTON_TarifUrun ON [tblKENTON_Tarifler].pkID = tblKENTON_TarifUrun.intTarifID WHERE blOnay = 'True' AND intUrunID = @UrunID " + aranan + siralama, conn);
                cmd.Parameters.Add("@UrunID", SqlDbType.Int).Value = UrunID;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    int index = 0;
                    while (dr.Read())
                    {
                        if (index >= baslangic && index < kactane + baslangic)
                        {
                            donendeger.Add(new Tarifler(Convert.ToInt32(dr[0]), Convert.ToInt32(dr[1]), Convert.ToBoolean(dr[2]), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), null, null, "", Convert.ToDateTime(dr[6])));
                        }
                        index++;
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

        public static DateTime GetLastObjectTime(bool tatli)
        {
            DateTime donendeger = new DateTime();

            string tarih = tatli ? "rssfeedtatlitarifxml" : "rssfeedtarifxml";

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT max(dtTarih) FROM [tblKENTON_Tarifler] WHERE intUyeID = 1 AND blOnay = 'True' AND strMalzemeler LIKE '%" + tarih + "%' AND DATEADD(dd, 0, DATEDIFF(dd, 0, dtTarih)) < DATEADD(dd, 0, DATEDIFF(dd, 0, GETDATE()))", conn);
                try
                {
                    conn.Open();
                    donendeger = Convert.ToDateTime(cmd.ExecuteScalar());
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sultanlar.DatabaseObject.Internet
{
    public class Resimler : ISultanlar, IDisposable
    {
        //
        //
        //
        // Alanlar:
        //
        private int _pkResimID;
        private byte[] _binResim;
        private byte[] _binResimK;
        private byte[] _binResimO;
        //
        //
        //
        // Constracter lar:
        //
        private Resimler(int pkResimID, byte[] binResim, byte[] binResimK, byte[] binResimO)
        {
            this._pkResimID = pkResimID;
            this._binResim = binResim;
            this._binResimK = binResimK;
            this._binResimO = binResimO;
        }
        //
        //
        public Resimler(byte[] binResim, byte[] binResimK, byte[] binResimO)
        {
            this._binResim = binResim;
            this._binResimK = binResimK;
            this._binResimO = binResimO;
        }
        //
        //
        //
        // Özellikler:
        //
        public int pkResimID
        {
            get
            {
                return this._pkResimID;
            }
        }
        //
        //
        public byte[] binResim
        {
            get
            {
                return this._binResim;
            }
            set
            {
                this._binResim = value;
            }
        }
        //
        //
        public byte[] binResimK
        {
            get
            {
                return this._binResimK;
            }
            set
            {
                this._binResimK = value;
            }
        }
        //
        //
        public byte[] binResimO
        {
            get
            {
                return this._binResimO;
            }
            set
            {
                this._binResimO = value;
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
            return this._pkResimID.ToString();
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
                SqlCommand cmd = new SqlCommand("sp_INTERNET_ResimEkle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@binResim", SqlDbType.VarBinary).Value = this._binResim;
                cmd.Parameters.Add("@binResimK", SqlDbType.VarBinary).Value = this._binResimK;
                cmd.Parameters.Add("@binResimO", SqlDbType.VarBinary).Value = this._binResimO;
                cmd.Parameters.Add("@pkResimID", SqlDbType.Int).Direction = ParameterDirection.Output;
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    this._pkResimID = Convert.ToInt32(cmd.Parameters["@pkResimID"].Value);
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
                SqlCommand cmd = new SqlCommand("sp_INTERNET_ResimGuncelle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkResimID", SqlDbType.Int).Value = this._pkResimID;
                cmd.Parameters.Add("@binResim", SqlDbType.VarBinary).Value = this._binResim;
                cmd.Parameters.Add("@binResimK", SqlDbType.VarBinary).Value = this._binResimK;
                cmd.Parameters.Add("@binResimO", SqlDbType.VarBinary).Value = this._binResimO;
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
                SqlCommand cmd = new SqlCommand("sp_INTERNET_ResimSil", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkResimID", SqlDbType.Int).Value = this._pkResimID;
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
        public static void DoDeleteByResimID(int ResimID)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_INTERNET_ResimSil", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pkResimID", SqlDbType.Int).Value = ResimID;
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
        public static void GetObjects(IList List, bool UI)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                List.Clear();

                SqlCommand cmd = new SqlCommand("sp_INTERNET_ResimlerGetir", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        List.Add(new Resimler(Convert.ToInt32(dr[0]), (byte[])dr[1], (byte[])dr[2], (byte[])dr[3]));
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
        public static void GetObjects(DataTable dt)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT [pkResimID] AS RESIMID,[Web-Malzeme].ITEMREF,[MAL ACIK] AS MALZEME,[OZEL ACIK] AS OZELACIK,dbo.YeniBolum(PRIMB) AS YENI,HYRS_TANIM AS MARKA,METIN,PG_B_Z_ACIKLAMA AS PRIM FROM [Web-Malzeme] INNER JOIN tblINTERNET_UrunResim ON tblINTERNET_UrunResim.ITEMREF = [Web-Malzeme].ITEMREF INNER JOIN [tblINTERNET_Resimler] ON [tblINTERNET_Resimler].pkResimID = tblINTERNET_UrunResim.intResimID INNER JOIN SAP_PRM_GRP ON [Web-Malzeme].PRIMB = SAP_PRM_GRP.PG_B_Z INNER JOIN [Web-Malzeme-Hiyerarsi] ON [Web-Malzeme].HYRS = [Web-Malzeme-Hiyerarsi].KOD GROUP BY [pkResimID],[Web-Malzeme].ITEMREF,[MAL ACIK],[OZEL ACIK],HYRS_TANIM,METIN,PG_B_Z_ACIKLAMA,PRIMB ORDER BY MALZEME", conn);
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
        public static byte[] GetObjectByResimID(int ResimID)
        {
            byte[] donendeger = null;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_INTERNET_ResimGetirByID", conn);
                cmd.Parameters.Add("@pkResimID", SqlDbType.Int).Value = ResimID;
                cmd.CommandType = CommandType.StoredProcedure;
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
        //
        //
        public static byte[] GetObjectKByResimID(int ResimID)
        {
            byte[] donendeger = null;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_INTERNET_ResimKGetirByID", conn);
                cmd.Parameters.Add("@pkResimID", SqlDbType.Int).Value = ResimID;
                cmd.CommandType = CommandType.StoredProcedure;
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
        //
        //
        public static byte[] GetObjectOByResimID(int ResimID)
        {
            byte[] donendeger = null;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_INTERNET_ResimOGetirByID", conn);
                cmd.Parameters.Add("@pkResimID", SqlDbType.Int).Value = ResimID;
                cmd.CommandType = CommandType.StoredProcedure;
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
    }

    public class ResimlerIndirmeler
    {
        public int intResimID { get; set; }
        public int intMusteriID { get; set; }
        public DateTime dtTarih { get; set; }
        public string strKAdi { get; set; }
        public ResimlerIndirmeler(int intResimID, int intMusteriID, DateTime dtTarih, string strKAdi)
        {
            this.intResimID = intResimID;
            this.intMusteriID = intMusteriID;
            this.dtTarih = dtTarih;
            this.strKAdi = strKAdi;
        }
        public void DoInsert()
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO [tblINTERNET_ResimlerIndirmeler] ([intResimID],[intMusteriID],[dtTarih],[strKAdi])  VALUES (@intResimID,@intMusteriID,@dtTarih,@strKAdi)", conn);
                cmd.Parameters.Add("@intResimID", SqlDbType.Int).Value = this.intResimID;
                cmd.Parameters.Add("@intMusteriID", SqlDbType.Int).Value = this.intMusteriID;
                cmd.Parameters.Add("@dtTarih", SqlDbType.DateTime).Value = this.dtTarih;
                cmd.Parameters.Add("@strKAdi", SqlDbType.NVarChar, 50).Value = this.strKAdi;
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
    }
}

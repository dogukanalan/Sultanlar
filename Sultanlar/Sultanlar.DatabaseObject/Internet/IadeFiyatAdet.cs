using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Sultanlar.DatabaseObject.Internet
{
    public class IadeFiyatAdet
    {
        private string _STRREF; private int _ITEMREF; private double _ADIADE; private bool _blAktif; private long _bintIadeDetayID; private string _strKolon; private decimal _mnFiyat;
        private IadeFiyatAdet(string STRREF, int ITEMREF, double ADIADE, bool blAktif, long bintIadeDetayID, string strKolon, decimal mnFiyat) { this._STRREF = STRREF; this._ITEMREF = ITEMREF; this._ADIADE = ADIADE; this._blAktif = blAktif; this._bintIadeDetayID = bintIadeDetayID; this._strKolon = strKolon; this._mnFiyat = mnFiyat; }
        public IadeFiyatAdet() { this._STRREF = string.Empty; }
        public string STRREF { get { return this._STRREF; } set { this._STRREF = value; } }
        public int ITEMREF { get { return this._ITEMREF; } set { this._ITEMREF = value; } }
        public double ADIADE { get { return this._ADIADE; } set { this._ADIADE = value; } }
        public bool blAktif { get { return this._blAktif; } set { this._blAktif = value; } }
        public long bintIadeDetayID { get { return this._bintIadeDetayID; } set { this._bintIadeDetayID = value; } }
        public string strKolon { get { return this._strKolon; } set { this._strKolon = value; } }
        public decimal mnFiyat { get { return this._mnFiyat; } set { this._mnFiyat = value; } }
        public static IadeFiyatAdet GetObject(string STRREF)
        {
            IadeFiyatAdet donendeger = new IadeFiyatAdet();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT STRREF,ITEMREF,[AD IADE],blAktif,bintIadeDetayID,strKolon,mnFiyat FROM [Web-IadeFiyat-Adet] WHERE STRREF = @STRREF", conn);
                cmd.Parameters.Add("@STRREF", SqlDbType.VarChar, 50).Value = STRREF;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        donendeger = new IadeFiyatAdet(dr[0].ToString(), Convert.ToInt32(dr[1]), Convert.ToDouble(dr[2]), Convert.ToBoolean(dr[3]), Convert.ToInt64(dr[4]), dr[5].ToString(), Convert.ToDecimal(dr[6]));
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
        public static IadeFiyatAdet GetObject(long IadeDetayID)
        {
            IadeFiyatAdet donendeger = new IadeFiyatAdet();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT [Web-IadeFiyat-Adet].STRREF,ITEMREF,[AD IADE],[Web-IadeFiyat-Adet-IadeDetayIDs].blAktif,[Web-IadeFiyat-Adet].bintIadeDetayID,strKolon,mnFiyat FROM [Web-IadeFiyat-Adet] INNER JOIN [Web-IadeFiyat-Adet-IadeDetayIDs] ON [Web-IadeFiyat-Adet].STRREF = [Web-IadeFiyat-Adet-IadeDetayIDs].STRREF WHERE bintIadeDetayID = @IadeDetayID", conn);
                cmd.Parameters.Add("@bintIadeDetayID", SqlDbType.BigInt).Value = IadeDetayID;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        donendeger = new IadeFiyatAdet(dr[0].ToString(), Convert.ToInt32(dr[1]), Convert.ToDouble(dr[2]), Convert.ToBoolean(dr[3]), Convert.ToInt64(dr[4]), dr[5].ToString(), Convert.ToDecimal(dr[6]));
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
        public static void GetObjectsByIadeDetayID(DataTable dt, long IadeDetayID)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT [Web-IadeFiyat-Adet].STRREF,ITEMREF,[AD IADE],[Web-IadeFiyat-Adet-IadeDetayIDs].blAktif,[Web-IadeFiyat-Adet].bintIadeDetayID,strKolon,mnFiyat,[Web-IadeFiyat-Adet-IadeDetayIDs].intMiktar FROM [Web-IadeFiyat-Adet] INNER JOIN [Web-IadeFiyat-Adet-IadeDetayIDs] ON [Web-IadeFiyat-Adet].STRREF = [Web-IadeFiyat-Adet-IadeDetayIDs].STRREF WHERE [Web-IadeFiyat-Adet-IadeDetayIDs].bintIadeDetayID = @IadeDetayID", conn);
                da.SelectCommand.Parameters.Add("@IadeDetayID", SqlDbType.BigInt).Value = IadeDetayID;
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
        public static int GetMiktarByIadeDetayID(long IadeDetayID)
        {
            int donendeger = 0;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT sum(intMiktar) FROM [Web-IadeFiyat-Adet-IadeDetayIDs] WHERE bintIadeDetayID = @IadeDetayID", conn);
                cmd.Parameters.Add("@IadeDetayID", SqlDbType.BigInt).Value = IadeDetayID;
                try
                {
                    conn.Open();
                    donendeger = Convert.ToInt32(cmd.ExecuteScalar());
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
        public void DoUpdate() // sadece ad iade
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UPDATE [Web-IadeFiyat-Adet] SET [AD IADE] = @ADIADE WHERE STRREF = @STRREF", conn);
                cmd.Parameters.Add("@STRREF", SqlDbType.VarChar, 50).Value = this._STRREF;
                cmd.Parameters.Add("@ADIADE", SqlDbType.Money).Value = this._ADIADE;

                SqlCommand cmd1 = new SqlCommand("DELETE FROM [Web-IadeFiyat-Adet-IadeDetayIDs] WHERE STRREF = @STRREF AND bintIadeDetayID = @IadeDetayID", conn);
                cmd1.Parameters.Add("@STRREF", SqlDbType.VarChar, 50).Value = this._STRREF;
                cmd1.Parameters.Add("@IadeDetayID", SqlDbType.BigInt).Value = this._bintIadeDetayID;
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    cmd1.ExecuteNonQuery();
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
                SqlCommand cmd1 = new SqlCommand("DELETE FROM [Web-IadeFiyat-Adet-IadeDetayIDs] WHERE bintIadeDetayID = @IadeDetayID", conn);
                cmd1.Parameters.Add("@IadeDetayID", SqlDbType.BigInt).Value = this._bintIadeDetayID;

                SqlCommand cmd = new SqlCommand("DELETE FROM [Web-IadeFiyat-Adet] WHERE STRREF = @STRREF", conn);
                cmd.Parameters.Add("@STRREF", SqlDbType.VarChar, 50).Value = this._STRREF;
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    cmd1.ExecuteNonQuery();
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



        public static void DoInsert(string STRREF, int ITEMREF, int Adet, bool Aktif, long IadeDetayID, string Kolon, decimal birimtutar)
        {
            //string donendeger = string.Empty;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO [Web-IadeFiyat-Adet] (STRREF,ITEMREF,[AD IADE],blAktif,bintIadeDetayID,strKolon,mnFiyat) VALUES (@STRREF,@ITEMREF,@ADIADE,@blAktif,@IadeDetayID,@strKolon,@mnFiyat)", conn);
                cmd.Parameters.Add("@STRREF", SqlDbType.VarChar, 50).Value = STRREF;
                cmd.Parameters.Add("@ITEMREF", SqlDbType.Int).Value = ITEMREF;
                cmd.Parameters.Add("@ADIADE", SqlDbType.Float).Value = Convert.ToDouble(Adet);
                cmd.Parameters.Add("@blAktif", SqlDbType.Bit).Value = Aktif;
                cmd.Parameters.Add("@IadeDetayID", SqlDbType.BigInt).Value = IadeDetayID;
                cmd.Parameters.Add("@strKolon", SqlDbType.NVarChar).Value = Kolon;
                cmd.Parameters.Add("@mnFiyat", SqlDbType.Money).Value = birimtutar;

                SqlCommand cmd1 = new SqlCommand("INSERT INTO [Web-IadeFiyat-Adet-IadeDetayIDs] (STRREF,bintIadeDetayID,blAktif,intMiktar) VALUES (@STRREF,@IadeDetayID,@blAktif,@intMiktar)", conn);
                cmd1.Parameters.Add("@STRREF", SqlDbType.VarChar, 50).Value = STRREF;
                cmd1.Parameters.Add("@IadeDetayID", SqlDbType.BigInt).Value = IadeDetayID;
                cmd1.Parameters.Add("@blAktif", SqlDbType.Bit).Value = Aktif;
                cmd1.Parameters.Add("@intMiktar", SqlDbType.Int).Value = Adet;
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    cmd1.ExecuteNonQuery();
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

            //return donendeger;
        }
        public static void DoUpdate(string STRREF, int Adet, bool Aktif, long IadeDetayID, string Kolon, decimal birimtutar)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UPDATE [Web-IadeFiyat-Adet] SET [AD IADE] = @ADIADE, blAktif = @blAktif, bintIadeDetayID = @IadeDetayID, strKolon = @strKolon, mnFiyat = @mnFiyat WHERE STRREF = @STRREF", conn);
                cmd.Parameters.Add("@STRREF", SqlDbType.VarChar, 50).Value = STRREF;
                cmd.Parameters.Add("@ADIADE", SqlDbType.Float).Value = Convert.ToDouble(Adet);
                cmd.Parameters.Add("@blAktif", SqlDbType.Bit).Value = Aktif;
                cmd.Parameters.Add("@IadeDetayID", SqlDbType.BigInt).Value = IadeDetayID;
                cmd.Parameters.Add("@strKolon", SqlDbType.NVarChar).Value = Kolon;
                cmd.Parameters.Add("@mnFiyat", SqlDbType.Money).Value = birimtutar;

                SqlCommand cmd1 = new SqlCommand("SELECT count(*) FROM [Web-IadeFiyat-Adet-IadeDetayIDs] WHERE STRREF = @STRREF AND bintIadeDetayID = @IadeDetayID AND blAktif = @blAktif", conn);
                cmd1.Parameters.Add("@STRREF", SqlDbType.VarChar, 50).Value = STRREF;
                cmd1.Parameters.Add("@IadeDetayID", SqlDbType.BigInt).Value = IadeDetayID;
                cmd1.Parameters.Add("@blAktif", SqlDbType.Bit).Value = Aktif;
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();

                    if (!Convert.ToBoolean(cmd1.ExecuteScalar())) // bu strref e iadedetayid yok ise ekle
                    {
                        SqlCommand cmd2 = new SqlCommand("INSERT INTO [Web-IadeFiyat-Adet-IadeDetayIDs] (STRREF,bintIadeDetayID,blAktif,intMiktar) VALUES (@STRREF,@IadeDetayID,@blAktif,@intMiktar)", conn);
                        cmd2.Parameters.Add("@STRREF", SqlDbType.VarChar, 50).Value = STRREF;
                        cmd2.Parameters.Add("@IadeDetayID", SqlDbType.BigInt).Value = IadeDetayID;
                        cmd2.Parameters.Add("@blAktif", SqlDbType.Bit).Value = Aktif;
                        cmd2.Parameters.Add("@intMiktar", SqlDbType.Int).Value = Adet;
                        cmd2.ExecuteNonQuery();
                    }
                    else // var ise update
                    {
                        SqlCommand cmd2 = new SqlCommand("UPDATE [Web-IadeFiyat-Adet-IadeDetayIDs] SET blAktif = @blAktif, intMiktar = @intMiktar WHERE STRREF = @STRREF AND bintIadeDetayID = @IadeDetayID", conn);
                        cmd2.Parameters.Add("@STRREF", SqlDbType.VarChar, 50).Value = STRREF;
                        cmd2.Parameters.Add("@IadeDetayID", SqlDbType.BigInt).Value = IadeDetayID;
                        cmd2.Parameters.Add("@blAktif", SqlDbType.Bit).Value = Aktif;
                        cmd2.Parameters.Add("@intMiktar", SqlDbType.Int).Value = Adet;
                        cmd2.ExecuteNonQuery();
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
        public static void DoUpdate(long IadeDetayID, bool Aktif)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                //DataTable dt = new DataTable();
                //SqlDataAdapter da = new SqlDataAdapter("SELECT STRREF FROM [Web-IadeFiyat-Adet-IadeDetayIDs] WHERE bintIadeDetayID = @bintIadeDetayID", conn);
                //da.SelectCommand.Parameters.Add("@bintIadeDetayID", SqlDbType.BigInt).Value = IadeDetayID;
                //da.Fill(dt);

                //for (int i = 0; i < dt.Rows.Count; i++)
                //{
                    //SqlCommand cmd = new SqlCommand("UPDATE [Web-IadeFiyat-Adet] SET blAktif = @blAktif WHERE STRREF = @STRREF", conn);
                    SqlCommand cmd = new SqlCommand("UPDATE [Web-IadeFiyat-Adet-IadeDetayIDs] SET blAktif = @blAktif WHERE bintIadeDetayID = @bintIadeDetayID", conn);
                    cmd.Parameters.Add("@blAktif", SqlDbType.Bit).Value = Aktif;
                    //cmd.Parameters.Add("@STRREF", SqlDbType.VarChar, 50).Value = dt.Rows[i]["STRREF"].ToString();
                    cmd.Parameters.Add("@bintIadeDetayID", SqlDbType.BigInt).Value = IadeDetayID;
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
                //}
            }
        }
        //public static void DoDelete(long IadeDetayID)
        //{
        //    using (SqlConnection conn = new SqlConnection(General.ConnectionString))
        //    {
        //        SqlCommand cmd = new SqlCommand("DELETE FROM [Web-IadeFiyat-Adet] WHERE bintIadeDetayID = @IadeDetayID", conn);
        //        cmd.Parameters.Add("@IadeDetayID", SqlDbType.BigInt).Value = IadeDetayID;
        //        try
        //        {
        //            conn.Open();
        //            cmd.ExecuteNonQuery();
        //        }
        //        catch (SqlException ex)
        //        {
        //            Hatalar.DoInsert(ex);
        //        }
        //        finally
        //        {
        //            conn.Close();
        //        }
        //    }
        //}
        public static void DoDeleteIadeDetayIDs(long IadeDetayID)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM [Web-IadeFiyat-Adet-IadeDetayIDs] WHERE bintIadeDetayID = @IadeDetayID", conn);
                cmd.Parameters.Add("@IadeDetayID", SqlDbType.BigInt).Value = IadeDetayID;
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

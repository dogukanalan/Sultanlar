using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Web.UI.WebControls;

namespace Sultanlar.DatabaseObject.Internet
{
    public class TaksitPlanlari : IDisposable
    {
        //
        //
        //
        // Alanlar:
        //
        private int _TKSREF;
        private string _TKSCODE;
        private string _TKSACIK;
        private double _YUZDE;
        private int _TIP;
        //
        //
        //
        // Constracter lar:
        //
        private TaksitPlanlari(int TKSREF, string TKSCODE, string TKSACIK, double YUZDE, int TIP)
        {
            this._TKSREF = TKSREF;
            this._TKSCODE = TKSCODE;
            this._TKSACIK = TKSACIK;
            this._YUZDE = YUZDE;
            this._TIP = TIP;
        }
        //
        //
        public TaksitPlanlari()
        {

        }
        //
        //
        //
        // Özellikler:
        //
        public int TKSREF
        {
            get
            {
                return this._TKSREF;
            }
        }
        //
        //
        public string TKSCODE
        {
            get
            {
                return this._TKSCODE;
            }
            set
            {
                this._TKSCODE = value;
            }
        }
        //
        //
        public string TKSACIK
        {
            get
            {
                return this._TKSACIK;
            }
            set
            {
                this._TKSACIK = value;
            }
        }
        //
        //
        public double YUZDE
        {
            get
            {
                return this._YUZDE;
            }
            set
            {
                this._YUZDE = value;
            }
        }
        //
        //
        public int TIP
        {
            get
            {
                return this._TIP;
            }
            set
            {
                this._TIP = value;
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
            return this._TKSCODE + " - " + this._TKSACIK + " (%" + this._YUZDE + ")";
        }
        //
        //
        //
        // Metodlar:
        //
        public static void GetObjects(IList List, bool UI)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3))
            {
                List.Clear();

                SqlCommand cmd = new SqlCommand("SELECT TKSREF, TKSCODE, TKSACIK, [%], TIP AS VADE FROM [Web-TaksitPlanlari]", conn);
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        List.Add(new TaksitPlanlari(Convert.ToInt32(dr[0]), dr[1].ToString(), dr[2].ToString(), Convert.ToDouble(dr[3]), Convert.ToInt32(dr[4])));
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
        public static void GetObjects(ListItemCollection lic, int FiyatTipi)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3))
            {
                lic.Clear();

                ListItem lst1 = new ListItem();
                lst1.Text = "Seçim Yok";
                lst1.Value = "0";
                lic.Add(lst1);

                SqlCommand cmd = new SqlCommand("SELECT TKSREF, TKSACIK, [%] AS YUZDE FROM [Web-TaksitPlanlari] WHERE TIP = @TIP", conn);
                cmd.Parameters.Add("@TIP", SqlDbType.Int).Value = FiyatTipi;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        ListItem lst = new ListItem();
                        lst.Text = dr[1].ToString() + " (%" + dr[2].ToString() + ")";
                        lst.Value = dr[0].ToString();
                        lic.Add(lst);
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
            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT TKSREF, TKSCODE, TKSACIK, [%] AS YUZDE, TIP FROM [Web-TaksitPlanlari]", conn);
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
        public static TaksitPlanlari GetObject(int TKSREF)
        {
            TaksitPlanlari tp = new TaksitPlanlari();

            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3))
            {
                SqlCommand cmd = new SqlCommand("SELECT TKSREF, TKSCODE, TKSACIK, [%] AS YUZDE, TIP FROM [Web-TaksitPlanlari] WHERE TKSREF = @TKSREF", conn);
                cmd.Parameters.Add("@TKSREF", SqlDbType.Int).Value = TKSREF;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                        tp = new TaksitPlanlari(Convert.ToInt32(dr[0]), dr[1].ToString(), dr[2].ToString(), Convert.ToDouble(dr[3]), Convert.ToInt32(dr[4]));
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

            return tp;
        }
        //
        //
        public static void GetOdemePlanlari(DataTable dt)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT ODMREF, ODMCODE, ODMACIK FROM [Web-OdemeTipleri]", conn);
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
        public static string GetOdemePlani(int ODMREF)
        {
            if (ODMREF == 0 || ODMREF == 1)
                ODMREF = 2;

            string donendeger = string.Empty;

            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3))
            {
                SqlCommand cmd = new SqlCommand("SELECT ODMACIK FROM [Web-OdemeTipleri] WHERE ODMREF = @ODMREF", conn);
                cmd.Parameters.Add("@ODMREF", SqlDbType.Int).Value = ODMREF;
                try
                {
                    conn.Open();
                    donendeger = cmd.ExecuteScalar().ToString();
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
        /// <summary>
        /// " GÜN VADE" kısmını atarak gün değerini int olarak döndürüyor. Mesela 01 GÜN VADE string dönecek değer 1 int olarak dönüyor.
        /// </summary>
        public static int GetVade(int ODMREF)
        {
            if (ODMREF == 0 || ODMREF == 1)
                ODMREF = 2;

            int donendeger = 0;

            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3))
            {
                SqlCommand cmd = new SqlCommand("SELECT ODMACIK FROM [Web-OdemeTipleri] WHERE ODMREF = @ODMREF", conn);
                cmd.Parameters.Add("@ODMREF", SqlDbType.Int).Value = ODMREF;
                try
                {
                    conn.Open();
                    donendeger = Convert.ToInt32(cmd.ExecuteScalar().ToString().Replace(" GÜN VADE", ""));
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
        public static int GetODMREF(int OrtVade)
        {
            int donendeger = 0;

            string vade = string.Empty;
            if (OrtVade.ToString().Length == 1)
                vade = "000" + OrtVade.ToString();
            else if (OrtVade.ToString().Length == 2)
                vade = "00" + OrtVade.ToString();
            else if (OrtVade.ToString().Length == 3)
                vade = "0" + OrtVade.ToString();

            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3))
            {
                SqlCommand cmd = new SqlCommand("SELECT ODMREF FROM [Web-OdemeTipleri] WHERE ODMCODE LIKE 'S%' AND ODMCODE LIKE '%" + vade + "'", conn);
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
        //
        //
        public static bool TaksitMi(int ODMREF)
        {
            if (ODMREF == 0)
                return false;

            bool donendeger = false;

            using (SqlConnection conn = new SqlConnection(General.ConnectionStringGOKW3))
            {
                SqlCommand cmd = new SqlCommand("SELECT count(ODMREF) FROM [Web-OdemeTipleri] WHERE ODMREF = @ODMREF AND ODMCODE NOT LIKE 'S%'", conn);
                cmd.Parameters.Add("@ODMREF", SqlDbType.Int).Value = ODMREF;
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

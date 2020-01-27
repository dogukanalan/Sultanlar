using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.WebControls;

namespace Sultanlar.DatabaseObject.Internet
{
    public class RutResim : ISultanlar
    {
        public int pkID { get; set; }
        public int SMREF { get; set; }
        public int intTip { get; set; }
        public int intMusteriID { get; set; }
        public int intTurID { get; set; }
        public string strRutID { get; set; }
        public int intZiyaretID { get; set; }
        public DateTime dtTarih { get; set; }
        public byte[] binResim { get; set; }
        public string strAciklama { get; set; }
        public string strNot { get; set; }

        public RutResim(int SMREF, int intTip, int intMusteriID, int intTurID, string strRutID, int intZiyaretID, DateTime dtTarih,
            byte[] binResim, string strAciklama, string strNot)
        {
            this.SMREF = SMREF;
            this.intTip = intTip;
            this.intMusteriID = intMusteriID;
            this.intTurID = intTurID;
            this.strRutID = strRutID;
            this.intZiyaretID = intZiyaretID;
            this.dtTarih = dtTarih;
            this.binResim = binResim;
            this.strAciklama = strAciklama;
            this.strNot = strNot;
        }

        private RutResim(int pkID, int SMREF, int intTip, int intMusteriID, int intTurID, string strRutID, int intZiyaretID, DateTime dtTarih,
            byte[] binResim, string strAciklama, string strNot)
        {
            this.pkID = pkID;
            this.SMREF = SMREF;
            this.intTip = intTip;
            this.intMusteriID = intMusteriID;
            this.intTurID = intTurID;
            this.strRutID = strRutID;
            this.intZiyaretID = intZiyaretID;
            this.dtTarih = dtTarih;
            this.binResim = binResim;
            this.strAciklama = strAciklama;
            this.strNot = strNot;
        }

        public RutResim()
        {
            // TODO: Complete member initialization
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public override string ToString()
        {
            return this.pkID.ToString();
        }

        public void DoInsert()
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO [Web-Rut-Resim] ([SMREF],intTip,[intMusteriID],[intTurID],[strRutID],[intZiyaretID],[dtTarih],[binResim],[strAciklama],[strNot]) VALUES (@SMREF,@intTip,@intMusteriID,@intTurID,@strRutID,@intZiyaretID,@dtTarih,@binResim,@strAciklama,@strNot) SELECT @pkID = SCOPE_IDENTITY()", conn);
                cmd.Parameters.Add("@SMREF", SqlDbType.Int).Value = this.SMREF;
                cmd.Parameters.Add("@intTip", SqlDbType.Int).Value = this.intTip;
                cmd.Parameters.Add("@intMusteriID", SqlDbType.Int).Value = this.intMusteriID;
                cmd.Parameters.Add("@intTurID", SqlDbType.Int).Value = this.intTurID;
                cmd.Parameters.Add("@strRutID", SqlDbType.NVarChar).Value = this.strRutID;
                cmd.Parameters.Add("@intZiyaretID", SqlDbType.Int).Value = this.intZiyaretID;
                cmd.Parameters.Add("@dtTarih", SqlDbType.DateTime).Value = this.dtTarih;
                cmd.Parameters.Add("@binResim", SqlDbType.VarBinary).Value = this.binResim;
                cmd.Parameters.Add("@strAciklama", SqlDbType.NVarChar).Value = this.strAciklama;
                cmd.Parameters.Add("@strNot", SqlDbType.NVarChar).Value = this.strNot;
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
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UPDATE [Web-Rut-Resim] SET [SMREF] = @SMREF,intTip = @intTip,[intMusteriID] = @intMusteriID,[intTurID] = @intTurID,[strRutID] = @strRutID,[intZiyaretID] = @intZiyaretID,[dtTarih] = @dtTarih,[binResim] = @binResim,[strAciklama] = @strAciklama,[strNot] = @strNot WHERE pkID = @pkID", conn);
                cmd.Parameters.Add("@pkID", SqlDbType.Int).Value = this.pkID;
                cmd.Parameters.Add("@SMREF", SqlDbType.Int).Value = this.SMREF;
                cmd.Parameters.Add("@intTip", SqlDbType.Int).Value = this.intTip;
                cmd.Parameters.Add("@intMusteriID", SqlDbType.Int).Value = this.intMusteriID;
                cmd.Parameters.Add("@intTurID", SqlDbType.Int).Value = this.intTurID;
                cmd.Parameters.Add("@strRutID", SqlDbType.NVarChar).Value = this.strRutID;
                cmd.Parameters.Add("@intZiyaretID", SqlDbType.Int).Value = this.intZiyaretID;
                cmd.Parameters.Add("@dtTarih", SqlDbType.DateTime).Value = this.dtTarih;
                cmd.Parameters.Add("@binResim", SqlDbType.VarBinary).Value = this.binResim;
                cmd.Parameters.Add("@strAciklama", SqlDbType.NVarChar).Value = this.strAciklama;
                cmd.Parameters.Add("@strNot", SqlDbType.NVarChar).Value = this.strNot;
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
                SqlCommand cmd = new SqlCommand("DELETE FROM [Web-Rut-Resim] WHERE pkID = @pkID", conn);
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

        public static void GetObjects(DataTable dt, int SMREF, int Tip)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT [Web-Rut-Resim].pkID AS ID,strAd + ' ' + strSoyad AS AdSoyad,strTur,[dtTarih],[Web-Rut-Resim].[strAciklama] FROM [Web-Rut-Resim] INNER JOIN tblINTERNET_Musteriler ON pkMusteriID = [intMusteriID] INNER JOIN [Web-Rut-Resim-Tur] ON [intTurID] = [Web-Rut-Resim-Tur].pkID WHERE SMREF = @SMREF AND intTip = @Tip", conn);
                da.SelectCommand.Parameters.Add("@SMREF", SqlDbType.Int).Value = SMREF;
                da.SelectCommand.Parameters.Add("@Tip", SqlDbType.Int).Value = Tip;
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

        public static void GetObjects(DataTable dt, string RutID, int MusteriID, int TurID, int Yil, int Ay, int kacincidan, int kactane)
        {
            string where = "";
            if (MusteriID != 0)
                where = " AND pkMusteriID = " + MusteriID.ToString();
            if (RutID != "0")
                where += " AND strRutID = '" + RutID + "'";
            if (TurID != 0)
                where += " AND intTurID = '" + TurID + "'";
            if (Yil != 0)
                where += " AND YEAR(dtTarih) = '" + Yil + "'";
            if (Ay != 0)
                where += " AND MONTH(dtTarih) = '" + Ay + "'";

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT TOP " + kactane.ToString() + " [Web-Rut-Resim].pkID AS ID,strAd + ' ' + strSoyad AS AdSoyad,(SELECT DISTINCT SUBE FROM [Web-Musteri-1] WHERE SMREF = [Web-Rut-Resim].SMREF AND TIP = intTip) AS SUBE,strTur,[dtTarih],[Web-Rut-Resim].[strAciklama] FROM [Web-Rut-Resim] INNER JOIN tblINTERNET_Musteriler ON pkMusteriID = [intMusteriID] INNER JOIN [Web-Rut-Resim-Tur] ON [intTurID] = [Web-Rut-Resim-Tur].pkID WHERE [Web-Rut-Resim].pkID < @pkID" + where + " ORDER BY [Web-Rut-Resim].pkID DESC", conn);
                da.SelectCommand.Parameters.Add("@pkID", SqlDbType.Int).Value = kacincidan;
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

        public static RutResim GetObject(int ID)
        {
            RutResim donendeger = new RutResim();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT [pkID],[SMREF],intTip,[intMusteriID],[intTurID],[strRutID],[intZiyaretID],[dtTarih],[binResim],[strAciklama],[strNot] FROM [Web-Rut-Resim] WHERE pkID = @pkID", conn);
                cmd.Parameters.Add("@pkID", SqlDbType.Int).Value = ID;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        donendeger = new RutResim(Convert.ToInt32(dr[0]), Convert.ToInt32(dr[1]), Convert.ToInt32(dr[2]), Convert.ToInt32(dr[3]), Convert.ToInt32(dr[4]), dr[5].ToString(), Convert.ToInt32(dr[6]), Convert.ToDateTime(dr[7]), (byte[])dr[8], dr[9].ToString(), dr[10].ToString());
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

        public static List<RutResim> GetObjects(int MusteriID, int kacincidan, int kactane)
        {
            List<RutResim> donendeger = new List<RutResim>();

            string where = "";
            if (MusteriID != 0)
                where = "AND intMusteriID = " + MusteriID.ToString();

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT TOP " + kactane.ToString() + " [pkID],[SMREF],intTip,[intMusteriID],[intTurID],[strRutID],[intZiyaretID],[dtTarih],NULL AS [binResim],[strAciklama],[strNot] FROM [Web-Rut-Resim] WHERE pkID < @pkID " + where + " ORDER BY pkID DESC", conn);
                cmd.Parameters.Add("@pkID", SqlDbType.Int).Value = kacincidan;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        donendeger.Add(new RutResim(Convert.ToInt32(dr[0]), Convert.ToInt32(dr[1]), Convert.ToInt32(dr[2]), Convert.ToInt32(dr[3]), Convert.ToInt32(dr[4]), dr[5].ToString(), Convert.ToInt32(dr[6]), Convert.ToDateTime(dr[7]), null, dr[9].ToString(), dr[10].ToString()));
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

        public static void GetObjectsTurler(ListItemCollection lic)
        {
            lic.Clear();
            lic.Add(new ListItem("Seçiniz", "0"));

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT pkID,strTur FROM [Web-Rut-Resim-Tur] ORDER BY strTur", conn);
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        lic.Add(new ListItem(dr[1].ToString(), dr[0].ToString()));
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



        public static bool GetResimVarMiByZiyaretID(long ZiyaretID)
        {
            bool donendeger = false;

            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT count(*) FROM [Web-Rut-Resim] WHERE intZiyaretID = @intZiyaretID", conn);
                cmd.Parameters.Add("@intZiyaretID", SqlDbType.BigInt).Value = ZiyaretID;
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

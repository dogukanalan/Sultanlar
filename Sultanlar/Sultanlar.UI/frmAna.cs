using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sultanlar.DatabaseObject;
using Microsoft.Win32;
using System.Xml;
using System.IO;
using Sultanlar.DatabaseObject.Internet;
using System.Data.SqlClient;
using Sultanlar.Class;
using Sultanlar.DatabaseObject.Kenton;
using System.Net.NetworkInformation;
using System.Deployment.Application;
using System.Net;
using System.Diagnostics;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Sultanlar.UI
{
    public partial class frmAna : Form
    {
        public frmAna()
        {
            InitializeComponent();
        }
        //
        //
        //
        //
        //
        internal static string KAdi;
        internal static string InputBox;
        FormErisimleri fe;
        Timer tmr;
        //
        //
        //
        //
        //
        private void frmAna_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;

            InputBox = string.Empty;

            AcilisSecenekleri();

            treeView1.ExpandAll();

            //for (int i = 0; i < treeView1.Nodes.Count; i++)
            //{
            //    MessageBox.Show(treeView1.Nodes[i].Name);
            //    for (int j = 0; j < treeView1.Nodes[i].Nodes.Count; j++)
            //    {
            //        MessageBox.Show(treeView1.Nodes[i].Nodes[j].Name);
            //    }
            //}

            fe = null;

            //System.Net.ServicePointManager.Expect100Continue = true;
            //System.Net.ServicePointManager.SecurityProtocol = (System.Net.SecurityProtocolType)3072;
            //RssKenton("https://www.kenton.com.tr/kategori/tarifler/feed/");
            //RssKenton("https://www.kenton.com.tr/kategori/tatli-tarifleri/feed/");
            //RssVideo("https://www.kenton.com.tr/kategori/kenton-video/feed/");
            //RssVideo("https://www.kenton.com.tr/kategori/tatli-sefi-video/feed/");

            /*if (ApplicationDeployment.IsNetworkDeployed) // yeni sürüm kontrolu
            {
                tmr = new Timer();
                tmr.Interval = 300000;
                tmr.Tick += new EventHandler(tmr_Tick);
                tmr.Start();
            }*/

            MusterilerC();
        }

        void GetEkstre(DateTime Baslangic)
        {
            string hata = string.Empty;
            string hata2 = string.Empty;
            DateTime baslangic = DateTime.Now;

            List<int> yillar = new List<int>();
            for (int i = 0; i < DateTime.Now.Year - Baslangic.Year + 1; i++)
                yillar.Add(Baslangic.Year + i);

            SqlConnection conn = new SqlConnection("Server=.; Database=KurumsalWebSAP; User Id=sa; Password=sdl580g5p9+-; Trusted_Connection=False;");
            for (int j = 0; j < yillar.Count; j++)
            {
                DateTime bas = DateTime.Now;


                selectekstreC.ZwebSelectEkstreService ekstre = new selectekstreC.ZwebSelectEkstreService();
                ekstre.Timeout = 6000000;
                ekstre.Credentials = new NetworkCredential("ngunay", "123456");
                selectekstreC.Zwebs023[] yirmiuc = null;
                selectekstreC.Zwebs023[] yirmiuc2 = null;

                try
                {
                    yirmiuc = ekstre.ZwebSelectEkstre("", yillar[j].ToString(), "", out yirmiuc2);
                    LogYaz(conn, "ekstre sonrasi", true, "sap yanıt verdi, " + yillar[j].ToString() + " yılı verisi alındı, " + (yirmiuc.Length + yirmiuc2.Length).ToString() + " satır", DateTime.Now, DateTime.Now);
                }
                catch (Exception ex)
                {
                    LogYaz(conn, "ekstre", true, "sap hata döndürdü:" + ex.Message, DateTime.Now, DateTime.Now);
                    return;
                }



                #region DataTable
                DataTable dt = new DataTable();
                dt.Columns.Add("Tur", typeof(string));
                dt.Columns.Add("Bukrs", typeof(string));
                dt.Columns.Add("Kunnr", typeof(int));
                dt.Columns.Add("Umsks", typeof(string));
                dt.Columns.Add("Umskz", typeof(string));
                dt.Columns.Add("Gjahr", typeof(int));
                dt.Columns.Add("Belnr", typeof(string));
                dt.Columns.Add("Buzei", typeof(int));
                dt.Columns.Add("Augdt", typeof(DateTime));
                dt.Columns.Add("Augbl", typeof(string));
                dt.Columns.Add("Zuonr", typeof(string));
                dt.Columns.Add("Budat", typeof(DateTime));
                dt.Columns.Add("Blart", typeof(string));
                dt.Columns.Add("Ltext", typeof(string));
                dt.Columns.Add("Sgtxt", typeof(string));
                dt.Columns.Add("Borc", typeof(double));
                dt.Columns.Add("Alacak", typeof(double));
                dt.Columns.Add("Shkzg", typeof(string));
                dt.Columns.Add("Waers", typeof(string));
                dt.Columns.Add("Lifnr", typeof(string));
                dt.Columns.Add("Awkey", typeof(string));
                dt.Columns.Add("Zfbdt", typeof(DateTime));
                dt.Columns.Add("Zbd1t", typeof(int));
                dt.Columns.Add("Xref1", typeof(string));
                dt.Columns.Add("Xref2", typeof(string));
                dt.Columns.Add("Kidno", typeof(string));
                dt.Columns.Add("Vbeln", typeof(int));
                dt.Columns.Add("Kunag", typeof(int));
                dt.Columns.Add("Ernam", typeof(string));
                dt.Columns.Add("Erdat", typeof(DateTime));
                dt.Columns.Add("Erzet", typeof(string));
                dt.Columns.Add("Xblnr", typeof(string));
                dt.Columns.Add("Rebzg", typeof(string));
                dt.Columns.Add("Rebzj", typeof(int));
                dt.Columns.Add("Rebzz", typeof(int));
                dt.Columns.Add("Hkont", typeof(string));
                #endregion

                #region Musteri
                for (int i = 0; i < yirmiuc.Length; i++)
                {
                    try
                    {
                        DataRow drow = dt.NewRow();
                        drow["Tur"] = "M";
                        drow["Bukrs"] = yirmiuc[i].Bukrs;
                        try { drow["Kunnr"] = Convert.ToInt32(yirmiuc[i].Kunnr); }
                        catch (Exception) { drow["Kunnr"] = 10; }
                        drow["Umsks"] = yirmiuc[i].Umsks;
                        drow["Umskz"] = yirmiuc[i].Umskz;
                        drow["Gjahr"] = yirmiuc[i].Gjahr;
                        drow["Belnr"] = yirmiuc[i].Belnr;
                        drow["Buzei"] = yirmiuc[i].Buzei;
                        if (yirmiuc[i].Augdt.StartsWith("00")) drow["Augdt"] = Convert.ToDateTime("01.01.1900"); else drow["Augdt"] = Convert.ToDateTime(yirmiuc[i].Augdt);
                        drow["Augbl"] = yirmiuc[i].Augbl;
                        drow["Zuonr"] = yirmiuc[i].Zuonr;
                        if (yirmiuc[i].Budat.StartsWith("00")) drow["Budat"] = Convert.ToDateTime("01.01.1900"); else drow["Budat"] = Convert.ToDateTime(yirmiuc[i].Budat);
                        drow["Blart"] = yirmiuc[i].Blart;
                        drow["Ltext"] = yirmiuc[i].Ltext;
                        drow["Sgtxt"] = yirmiuc[i].Sgtxt;
                        drow["Borc"] = yirmiuc[i].Borc;
                        drow["Alacak"] = yirmiuc[i].Alacak;
                        drow["Shkzg"] = yirmiuc[i].Shkzg;
                        drow["Waers"] = yirmiuc[i].Waers;
                        drow["Lifnr"] = yirmiuc[i].Lifnr;
                        drow["Awkey"] = yirmiuc[i].Awkey;
                        if (yirmiuc[i].Zfbdt.StartsWith("00")) drow["Zfbdt"] = Convert.ToDateTime("01.01.1900"); else drow["Zfbdt"] = Convert.ToDateTime(yirmiuc[i].Zfbdt);
                        drow["Zbd1t"] = yirmiuc[i].Zbd1t;
                        drow["Xref1"] = yirmiuc[i].Xref1;
                        drow["Xref2"] = yirmiuc[i].Xref2;
                        drow["Kidno"] = yirmiuc[i].Kidno;
                        try { drow["Vbeln"] = Convert.ToInt32(yirmiuc[i].Vbeln); }
                        catch (Exception) { drow["Vbeln"] = DBNull.Value; }
                        try { drow["Kunag"] = Convert.ToInt32(yirmiuc[i].Kunag); }
                        catch (Exception) { drow["Kunag"] = 10; }
                        drow["Ernam"] = yirmiuc[i].Ernam;
                        drow["Erdat"] = Convert.ToDateTime(yirmiuc[i].Erdat + " " + yirmiuc[i].Erzet);
                        drow["Erzet"] = yirmiuc[i].Erzet;
                        drow["Xblnr"] = yirmiuc[i].Xblnr;
                        drow["Rebzg"] = yirmiuc[i].Rebzg;
                        drow["Rebzj"] = yirmiuc[i].Rebzj == string.Empty ? 0 : Convert.ToInt32(yirmiuc[i].Rebzj);
                        drow["Rebzz"] = yirmiuc[i].Rebzz == string.Empty ? 0 : Convert.ToInt32(yirmiuc[i].Rebzz);
                        drow["Hkont"] = yirmiuc[i].Hkont;
                        dt.Rows.Add(drow);
                    }
                    catch (Exception ex)
                    {
                        hata = ex.Message;
                        LogYaz(conn, "ekstre sonrasi", true, "musteri ekstresi bellege alinirken bir satirda hata olustu: " + ex.Message, DateTime.Now, DateTime.Now);
                    }
                }
                #endregion

                #region Tedarikci
                for (int i = 0; i < yirmiuc2.Length; i++)
                {
                    try
                    {
                        DataRow drow = dt.NewRow();
                        drow["Tur"] = "T";
                        drow["Bukrs"] = yirmiuc2[i].Bukrs;
                        try { drow["Kunnr"] = Convert.ToInt32(yirmiuc2[i].Kunnr); }
                        catch (Exception) { drow["Kunnr"] = 10; }
                        drow["Umsks"] = yirmiuc2[i].Umsks;
                        drow["Umskz"] = yirmiuc2[i].Umskz;
                        drow["Gjahr"] = yirmiuc2[i].Gjahr;
                        drow["Belnr"] = yirmiuc2[i].Belnr;
                        drow["Buzei"] = yirmiuc2[i].Buzei;
                        if (yirmiuc2[i].Augdt.StartsWith("00")) drow["Augdt"] = Convert.ToDateTime("01.01.1900"); else drow["Augdt"] = Convert.ToDateTime(yirmiuc2[i].Augdt);
                        drow["Augbl"] = yirmiuc2[i].Augbl;
                        drow["Zuonr"] = yirmiuc2[i].Zuonr;
                        if (yirmiuc2[i].Budat.StartsWith("00")) drow["Budat"] = Convert.ToDateTime("01.01.1900"); else drow["Budat"] = Convert.ToDateTime(yirmiuc2[i].Budat);
                        drow["Blart"] = yirmiuc2[i].Blart;
                        drow["Ltext"] = yirmiuc2[i].Ltext;
                        drow["Sgtxt"] = yirmiuc2[i].Sgtxt;
                        drow["Borc"] = yirmiuc2[i].Borc;
                        drow["Alacak"] = yirmiuc2[i].Alacak;
                        drow["Shkzg"] = yirmiuc2[i].Shkzg;
                        drow["Waers"] = yirmiuc2[i].Waers;
                        drow["Lifnr"] = yirmiuc2[i].Lifnr;
                        drow["Awkey"] = yirmiuc2[i].Awkey;
                        if (yirmiuc2[i].Zfbdt.StartsWith("00")) drow["Zfbdt"] = Convert.ToDateTime("01.01.1900"); else drow["Zfbdt"] = Convert.ToDateTime(yirmiuc2[i].Zfbdt);
                        drow["Zbd1t"] = yirmiuc2[i].Zbd1t;
                        drow["Xref1"] = yirmiuc2[i].Xref1;
                        drow["Xref2"] = yirmiuc2[i].Xref2;
                        drow["Kidno"] = yirmiuc2[i].Kidno;
                        try { drow["Vbeln"] = Convert.ToInt32(yirmiuc2[i].Vbeln); }
                        catch (Exception) { drow["Vbeln"] = DBNull.Value; }
                        try { drow["Kunag"] = Convert.ToInt32(yirmiuc2[i].Kunag); }
                        catch (Exception) { drow["Kunag"] = 10; }
                        drow["Ernam"] = yirmiuc2[i].Ernam;
                        drow["Erdat"] = Convert.ToDateTime(yirmiuc2[i].Erdat + " " + yirmiuc2[i].Erzet);
                        drow["Erzet"] = yirmiuc2[i].Erzet;
                        drow["Xblnr"] = yirmiuc2[i].Xblnr;
                        drow["Rebzg"] = yirmiuc2[i].Rebzg;
                        drow["Rebzj"] = yirmiuc2[i].Rebzj == string.Empty ? 0 : Convert.ToInt32(yirmiuc[i].Rebzj);
                        drow["Rebzz"] = yirmiuc2[i].Rebzz == string.Empty ? 0 : Convert.ToInt32(yirmiuc[i].Rebzz);
                        drow["Hkont"] = yirmiuc2[i].Hkont;
                        dt.Rows.Add(drow);
                    }
                    catch (Exception ex)
                    {
                        hata2 = ex.Message;
                        LogYaz(conn, "ekstre sonrasi", true, "tedarikci ekstresi bellege alinirken bir satirda hata olustu: " + ex.Message, DateTime.Now, DateTime.Now);
                    }
                }
                #endregion

                #region silme ve yazma
                if (hata == string.Empty && hata2 == string.Empty)
                {
                    SqlCommand cmd1 = new SqlCommand("DELETE FROM [SAP_EKSTRE] WHERE Gjahr = @Gjahr", conn);
                    cmd1.Parameters.Add("@Gjahr", SqlDbType.Int).Value = yillar[j];
                    cmd1.CommandTimeout = 1000;
                    conn.Open(); cmd1.ExecuteNonQuery(); conn.Close();

                    LogYaz(conn, "ekstre sonrasi", true, "sap_ekstre tablosu " + yillar[j].ToString() + " yılı silindi", DateTime.Now, DateTime.Now);

                    try
                    {
                        SqlDataAdapter da = new SqlDataAdapter();
                        da.InsertCommand = new SqlCommand("INSERT INTO [SAP_EKSTRE] (Tur,[Bukrs],[Kunnr],[Umsks],[Umskz],[Gjahr],[Belnr],[Buzei],[Augdt],[Augbl],[Zuonr],[Budat],[Blart],[Ltext],[Sgtxt],[Borc],[Alacak],[Shkzg],[Waers],[Lifnr],[Awkey],[Zfbdt],[Zbd1t],[Xref1],[Xref2],[Kidno],[Vbeln],[Kunag],Ernam,Erdat,Erzet,Xblnr,Rebzg,Rebzj,Rebzz,Hkont) VALUES (@Tur,@Bukrs,@Kunnr,@Umsks,@Umskz,@Gjahr,@Belnr,@Buzei,@Augdt,@Augbl,@Zuonr,@Budat,@Blart,@Ltext,@Sgtxt,@Borc,@Alacak,@Shkzg,@Waers,@Lifnr,@Awkey,@Zfbdt,@Zbd1t,@Xref1,@Xref2,@Kidno,@Vbeln,@Kunag,@Ernam,@Erdat,@Erzet,@Xblnr,@Rebzg,@Rebzj,@Rebzz,@Hkont)", conn);
                        da.InsertCommand.Parameters.Add("@Tur", SqlDbType.Char, 1, "Tur");
                        da.InsertCommand.Parameters.Add("@Bukrs", SqlDbType.VarChar, 4, "Bukrs");
                        da.InsertCommand.Parameters.Add("@Kunnr", SqlDbType.Int, 4, "Kunnr");
                        da.InsertCommand.Parameters.Add("@Umsks", SqlDbType.VarChar, 1, "Umsks");
                        da.InsertCommand.Parameters.Add("@Umskz", SqlDbType.VarChar, 1, "Umskz");
                        da.InsertCommand.Parameters.Add("@Gjahr", SqlDbType.Int, 4, "Gjahr");
                        da.InsertCommand.Parameters.Add("@Belnr", SqlDbType.VarChar, 10, "Belnr");
                        da.InsertCommand.Parameters.Add("@Buzei", SqlDbType.Int, 4, "Buzei");
                        da.InsertCommand.Parameters.Add("@Augdt", SqlDbType.DateTime, 8, "Augdt");
                        da.InsertCommand.Parameters.Add("@Augbl", SqlDbType.VarChar, 10, "Augbl");
                        da.InsertCommand.Parameters.Add("@Zuonr", SqlDbType.VarChar, 18, "Zuonr");
                        da.InsertCommand.Parameters.Add("@Budat", SqlDbType.DateTime, 8, "Budat");
                        da.InsertCommand.Parameters.Add("@Blart", SqlDbType.VarChar, 2, "Blart");
                        da.InsertCommand.Parameters.Add("@Ltext", SqlDbType.NVarChar, 40, "Ltext");
                        da.InsertCommand.Parameters.Add("@Sgtxt", SqlDbType.NVarChar, 50, "Sgtxt");
                        da.InsertCommand.Parameters.Add("@Borc", SqlDbType.Float, 8, "Borc");
                        da.InsertCommand.Parameters.Add("@Alacak", SqlDbType.Float, 8, "Alacak");
                        da.InsertCommand.Parameters.Add("@Shkzg", SqlDbType.VarChar, 1, "Shkzg");
                        da.InsertCommand.Parameters.Add("@Waers", SqlDbType.NVarChar, 50, "Waers");
                        da.InsertCommand.Parameters.Add("@Lifnr", SqlDbType.VarChar, 10, "Lifnr");
                        da.InsertCommand.Parameters.Add("@Awkey", SqlDbType.VarChar, 20, "Awkey");
                        da.InsertCommand.Parameters.Add("@Zfbdt", SqlDbType.DateTime, 8, "Zfbdt");
                        da.InsertCommand.Parameters.Add("@Zbd1t", SqlDbType.Int, 4, "Zbd1t");
                        da.InsertCommand.Parameters.Add("@Xref1", SqlDbType.VarChar, 12, "Xref1");
                        da.InsertCommand.Parameters.Add("@Xref2", SqlDbType.NVarChar, 12, "Xref2");
                        da.InsertCommand.Parameters.Add("@Kidno", SqlDbType.VarChar, 30, "Kidno");
                        da.InsertCommand.Parameters.Add("@Vbeln", SqlDbType.Int, 4, "Vbeln");
                        da.InsertCommand.Parameters.Add("@Kunag", SqlDbType.Int, 4, "Kunag");
                        da.InsertCommand.Parameters.Add("@Ernam", SqlDbType.NVarChar, 12, "Ernam");
                        da.InsertCommand.Parameters.Add("@Erdat", SqlDbType.DateTime, 8, "Erdat");
                        da.InsertCommand.Parameters.Add("@Erzet", SqlDbType.NVarChar, 8, "Erzet");
                        da.InsertCommand.Parameters.Add("@Xblnr", SqlDbType.NVarChar, 16, "Xblnr");
                        da.InsertCommand.Parameters.Add("@Rebzg", SqlDbType.NVarChar, 10, "Rebzg");
                        da.InsertCommand.Parameters.Add("@Rebzj", SqlDbType.Int, 4, "Rebzj");
                        da.InsertCommand.Parameters.Add("@Rebzz", SqlDbType.Int, 4, "Rebzz");
                        da.InsertCommand.Parameters.Add("@Hkont", SqlDbType.NVarChar, 10, "Hkont");
                        da.Update(dt);

                        LogYaz(conn, "ekstre sonrasi", true, "sap_ekstre tablosu dolduruldu", DateTime.Now, DateTime.Now);
                    }
                    catch (Exception ex)
                    {
                        hata2 = ex.Message;
                        LogYaz(conn, "ekstre sonrasi", true, "sap_ekstre tablosu doldurulurken hata olustu: " + ex.Message, DateTime.Now, DateTime.Now);
                    }
                }
                #endregion

                LogYaz(conn, "ekstre", true, yillar[j].ToString() + " mali yılı silindi ve yazıldı", bas, DateTime.Now);
            }



            LogYaz(conn, "ekstre", hata != string.Empty && hata2 != string.Empty ? false : true, (hata + " " + hata2).Trim(), baslangic, DateTime.Now);




            if (hata == string.Empty && hata2 == string.Empty)
            {
                SqlCommand cmdEkstreJob = new SqlCommand("msdb.dbo.sp_start_job", conn);
                cmdEkstreJob.CommandTimeout = 1000;
                cmdEkstreJob.CommandType = CommandType.StoredProcedure;
                cmdEkstreJob.Parameters.AddWithValue("@job_name", "Web_Ekstre_Yeni");

                DateTime bastarih = DateTime.Now;
                string hataa = string.Empty;
                try
                {
                    conn.Open();
                    cmdEkstreJob.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    hataa = ex.Message;
                }
                finally
                {
                    conn.Close();
                    LogYaz(conn, "ekstre yeni", hataa != string.Empty ? false : true, hataa, bastarih, DateTime.Now);
                }
            }
        }

        private void PersonellerC()
        {
            SqlConnection conn = new SqlConnection("Server=.; Database=KurumsalWebSAP; Trusted_Connection=True;");

            SqlCommand cmdLog = new SqlCommand("INSERT INTO [KurumsalWebSAP].[dbo].[tblINTERNET_LogTabloGuncellemeler] ([dtBaslangic],[dtBitis],[strYer],[strLog]) VALUES (@dtBaslangic,@dtBitis,@strYer,@strLog)", conn);
            cmdLog.Parameters.AddWithValue("@dtBaslangic", DateTime.Now); cmdLog.Parameters.AddWithValue("@strYer", "SAP Personeller");



            NetworkCredential nc1 = new NetworkCredential("ngunay", "123456");

            getpersonalsC.ZwebGetPersonalsService clPersonals = new getpersonalsC.ZwebGetPersonalsService();
            clPersonals.Timeout = 6000000;
            clPersonals.Credentials = nc1;
            getpersonalsC.Zwebt003[] listPersonals = null;
            try
            {
                listPersonals = clPersonals.ZwebGetPersonals();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            cmdLog.Parameters.AddWithValue("@strLog", listPersonals.Length.ToString() + " Satır");

            SqlCommand cmd1 = new SqlCommand("DELETE FROM [Web-SatisTemsilcileri]", conn);
            cmd1.CommandTimeout = 1000;
            conn.Open();
            cmd1.ExecuteNonQuery();
            conn.Close();

            for (int i = 0; i < listPersonals.Length; i++)
            {
                int slsmanref = 0; try { slsmanref = Convert.ToInt32(listPersonals[i].Pernr); }
                catch { }
                string sattem = listPersonals[i].Vorna + " " + listPersonals[i].Nachn;

                SqlCommand cmd = new SqlCommand("INSERT INTO [Web-SatisTemsilcileri] " +
                    "([ACTIVE],[SLSMANREF],[SAT TEM])" +
                    "VALUES (0,@SLSMANREF,@SATTEM)", conn);
                cmd.CommandTimeout = 1000;
                cmd.Parameters.AddWithValue("@SLSMANREF", slsmanref);
                cmd.Parameters.AddWithValue("@SATTEM", sattem);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Hatalar.DoInsert(ex, "windows servis SAP personeller");
                }
                finally
                {
                    conn.Close();
                }
            }

            SqlCommand cmd2 = new SqlCommand("UPDATE [Web-SatisTemsilcileri] SET [SAT KOD1] = (SELECT TOP 1 [SAT KOD1] FROM [Web-Musteri] WHERE SLSREF = [Web-SatisTemsilcileri].SLSMANREF ORDER BY [SAT KOD1])", conn);
            cmd2.CommandTimeout = 1000;
            conn.Open();
            cmd2.ExecuteNonQuery();
            conn.Close();

            //SqlCommand cmd3 = new SqlCommand("DELETE FROM [Web-SatisTemsilcileri] WHERE [SAT KOD1] IS NULL", conn);
            //cmd3.CommandTimeout = 1000;
            //conn.Open();
            //cmd3.ExecuteNonQuery();
            //conn.Close();



            conn.Open(); cmdLog.Parameters.AddWithValue("@dtBitis", DateTime.Now); cmdLog.ExecuteNonQuery(); conn.Close();
        }

        private void MusterilerC()
        {
            SqlConnection conn = new SqlConnection("Server=.; Database=KurumsalWebSAP; Trusted_Connection=True;");

            SqlCommand cmdLog = new SqlCommand("INSERT INTO [KurumsalWebSAP].[dbo].[tblINTERNET_LogTabloGuncellemeler] ([dtBaslangic],[dtBitis],[strYer],[strLog]) VALUES (@dtBaslangic,@dtBitis,@strYer,@strLog)", conn);
            cmdLog.Parameters.AddWithValue("@dtBaslangic", DateTime.Now); cmdLog.Parameters.AddWithValue("@strYer", "SAP Musteriler");



            NetworkCredential nc1 = new NetworkCredential("ngunay", "123456");

            getcustomersC.ZwebGetCustomersService clCustomers = new getcustomersC.ZwebGetCustomersService();
            clCustomers.Timeout = 6000000;
            clCustomers.Credentials = nc1;
            getcustomersC.Zwebt002[] listCustomers;
            try
            {
                listCustomers = clCustomers.ZwebGetCustomers();
            }
            catch (Exception ex)
            {
                cmdLog.Parameters.AddWithValue("@strLog", ex.Message);
                conn.Open(); cmdLog.Parameters.AddWithValue("@dtBitis", DateTime.Now); cmdLog.ExecuteNonQuery(); conn.Close();
                return;
            }

            cmdLog.Parameters.AddWithValue("@strLog", listCustomers.Length.ToString() + " Satır");

            SqlCommand cmd1 = new SqlCommand("DELETE FROM [Web_Musteri] DELETE FROM [Web-Risk]", conn);
            cmd1.CommandTimeout = 1000;
            conn.Open();
            cmd1.ExecuteNonQuery();
            conn.Close();

            for (int i = 0; i < listCustomers.Length; i++)
            {
                string active = listCustomers[i].Aufsd == string.Empty ? "0" : "1";
                string bolgekod = listCustomers[i].Bzirk;
                string bolge = listCustomers[i].Bztxt;
                string ytkkod = listCustomers[i].Kdgrp;
                string ilkod = listCustomers[i].Regio;
                string il = listCustomers[i].Bezei;
                string ilcekod = listCustomers[i].PostCode1;
                string ilce = listCustomers[i].City1;
                string mtkod = listCustomers[i].Kdgrp;
                string mtaciklama = listCustomers[i].Kdgtx;
                int slsref = 0; try { slsref = Convert.ToInt32(listCustomers[i].Pernr); }
                catch { }
                string satkod = Convert.ToInt32(listCustomers[i].Perno).ToString();
                string satkod1 = listCustomers[i].Parvw;
                int gmref = 0; try { gmref = Convert.ToInt32(listCustomers[i].Kunag); }
                catch { }
                string musteri = listCustomers[i].Namag;
                int smref = 0; try { smref = Convert.ToInt32(listCustomers[i].Kunwe); }
                catch { }
                string sube = listCustomers[i].Namwe;
                string adres = listCustomers[i].Adres;
                string sehir = listCustomers[i].CommText;
                string semt = listCustomers[i].Name3;
                string vrgdaire = listCustomers[i].Stcd1;
                string vrgno = listCustomers[i].Stcd2;
                string tel = listCustomers[i].Telno;
                string fax = listCustomers[i].Faxno;
                string email = listCustomers[i].Email;
                string cep = listCustomers[i].Mobno;
                double risklimit = Convert.ToDouble(listCustomers[i].Klimk);
                int muskod = 0; try { muskod = listCustomers[i].Altkn != string.Empty ? Convert.ToInt32(listCustomers[i].Altkn) : 0; }
                catch { }

                SqlCommand cmd = new SqlCommand("INSERT INTO [Web_Musteri] " +
                    "([ACTIVE],BOLGE,[YTK KOD],[IL KOD],[IL],[ILCE KOD],[ILCE],[MT KOD],[MT ACIKLAMA],[SLSREF],[SAT KOD],[SAT KOD1],[GMREF],[MUS KOD],[SAT TEM],[MUSTERI],[SMREF],[SUB KOD],[SUBE],[ADRES],[SEHIR],SEMT,[VRG DAIRE],[VRG NO],[TEL-1],[FAX-1],[EMAIL-1],ILGILI,[CEP-1],[NETTOP])" +
                    "VALUES (@ACTIVE,@BOLGE,@YTKKOD,@ILKOD,@IL,@ILCEKOD,@ILCE,@MTKOD,@MTACIKLAMA,@SLSREF,@SATKOD,@SATKOD1,@GMREF,@MUSKOD,@SATTEM,@MUSTERI,@SMREF,@SUBKOD,@SUBE,@ADRES,@SEHIR,@SEMT,@VRGDAIRE,@VRGNO,@TEL,@FAX,@EMAIL,@ILGILI,@CEP,0)", conn);
                cmd.CommandTimeout = 1000;
                cmd.Parameters.AddWithValue("@ACTIVE", active);
                cmd.Parameters.AddWithValue("@BOLGE", bolgekod);
                cmd.Parameters.AddWithValue("@YTKKOD", ytkkod);
                cmd.Parameters.AddWithValue("@ILKOD", ilkod);
                cmd.Parameters.AddWithValue("@IL", il);
                cmd.Parameters.AddWithValue("@ILCEKOD", ilcekod);
                cmd.Parameters.AddWithValue("@ILCE", ilce);
                cmd.Parameters.AddWithValue("@MTKOD", mtkod);
                cmd.Parameters.AddWithValue("@MTACIKLAMA", mtaciklama);
                cmd.Parameters.AddWithValue("@SLSREF", slsref);
                cmd.Parameters.AddWithValue("@SATKOD", satkod);
                cmd.Parameters.AddWithValue("@SATKOD1", satkod1);
                cmd.Parameters.AddWithValue("@GMREF", gmref);
                cmd.Parameters.AddWithValue("@MUSKOD", muskod);
                cmd.Parameters.AddWithValue("@MUSTERI", musteri);
                cmd.Parameters.AddWithValue("@SMREF", smref);
                cmd.Parameters.AddWithValue("@SUBKOD", muskod);
                cmd.Parameters.AddWithValue("@SUBE", sube);
                cmd.Parameters.AddWithValue("@ADRES", adres);
                cmd.Parameters.AddWithValue("@SEHIR", sehir);
                cmd.Parameters.AddWithValue("@SEMT", semt);
                cmd.Parameters.AddWithValue("@VRGDAIRE", vrgdaire);
                cmd.Parameters.AddWithValue("@VRGNO", vrgno);
                cmd.Parameters.AddWithValue("@TEL", tel);
                cmd.Parameters.AddWithValue("@FAX", fax);
                cmd.Parameters.AddWithValue("@EMAIL", email);
                cmd.Parameters.AddWithValue("@ILGILI", bolge);
                cmd.Parameters.AddWithValue("@CEP", cep);

                /*SqlCommand cmd2 = new SqlCommand("SELECT count(GMREF) FROM [Web-Risk] WHERE GMREF = @GMREF", conn);
                cmd2.CommandTimeout = 1000;
                cmd2.Parameters.AddWithValue("@GMREF", gmref);

                SqlCommand cmd3 = new SqlCommand("INSERT INTO [Web-Risk] ([SLSREF],[GMREF],[MUS KOD],[MUSTERI],[RISK LMT],[RISK TOP],[RISK BKY],[BAKIYE],[ACK GUN],[ACK TOP],[VB GUN],[VB TOP],[VGB GUN],[VGB TOP],[IRS TOP],[C/S TOP],[SIP TOPL],[SIP TOPLB],[SIP TOPQ]) VALUES (@SLSREF,@GMREF,@GMREF,@MUSTERI,@RISKLMT,0,@RISKBKY,0,0,0,0,0,0,0,0,0,0,0,0)", conn);
                cmd3.CommandTimeout = 1000;
                cmd3.Parameters.AddWithValue("@SLSREF", slsref);
                cmd3.Parameters.AddWithValue("@GMREF", gmref);
                cmd3.Parameters.AddWithValue("@MUSTERI", musteri);
                cmd3.Parameters.AddWithValue("@RISKLMT", risklimit);
                cmd3.Parameters.AddWithValue("@RISKBKY", risklimit);*/

                SqlCommand cmd4 = new SqlCommand("SELECT [SAT TEM] FROM [Web-SatisTemsilcileri] WHERE SLSMANREF = @SLSMANREF", conn);
                cmd4.CommandTimeout = 1000;
                cmd4.Parameters.AddWithValue("@SLSMANREF", slsref);

                try
                {
                    conn.Open();
                    object sattemson = cmd4.ExecuteScalar();
                    string sattemsonn = sattemson != null ? sattemson.ToString() : "";
                    cmd.Parameters.AddWithValue("@SATTEM", sattemsonn);
                    cmd.ExecuteNonQuery();
                    /*if (!Convert.ToBoolean(cmd2.ExecuteScalar())) // risktablosunda yok ise
                    {
                        cmd3.ExecuteNonQuery();
                    }*/
                }
                catch (Exception ex)
                {
                    Hatalar.DoInsert(ex, "windows servis SAP musteriler");
                }
                finally
                {
                    conn.Close();
                }
            }

            SqlCommand cmd10 = new SqlCommand("DROP TABLE [Web-Musteri-Onceki] SELECT * INTO [Web-Musteri-Onceki] FROM [dbo].[Web-Musteri]", conn);
            cmd10.CommandTimeout = 1000;
            conn.Open();
            cmd10.ExecuteNonQuery();
            conn.Close();

            SqlCommand cmd5 = new SqlCommand("BEGIN TRANSACTION t_Transaction TRUNCATE TABLE [Web-Musteri] INSERT INTO [Web-Musteri] SELECT * FROM [Web_Musteri] WITH (HOLDLOCK) COMMIT TRANSACTION t_Transaction", conn);
            cmd5.CommandTimeout = 1000;
            conn.Open();
            cmd5.ExecuteNonQuery();
            conn.Close();

            //üşengeçlik
            SqlCommand cmd6 = new SqlCommand("UPDATE [KurumsalWebSAP].[dbo].[Web-Musteri] SET [GRP] = '',[EKP] = '',[TIP] = 0,UNVAN=''", conn);
            cmd6.CommandTimeout = 1000;
            conn.Open();
            cmd6.ExecuteNonQuery();
            conn.Close();

            /*SqlCommand cmd7 = new SqlCommand("BEGIN TRANSACTION t_Transaction TRUNCATE TABLE [Web-Risk-2] INSERT INTO [Web-Risk-2] ([SLSREF],[GMREF],[MUS KOD],[MUSTERI],[RISK LMT],[RISK TOP],[RISK BKY],[BAKIYE],[ACK GUN],[ACK TOP],[VB GUN],[VB TOP],[VGB GUN],[VGB TOP],[IRS TOP],[C/S TOP],[SIP TOPL],[SIP TOPLB],[SIP TOPQ]) SELECT [SAT KOD],[MUS KOD],[MUS KOD],[MUSTERI],[RISK LMT],0,[RISK LMT],[BAKIYE],0,0,0,0,0,0,[BORC],0,[ALACAK],0,0 FROM [SAP_B_A_2017] WITH (HOLDLOCK) WHERE [SAT KOD] IS NOT NULL COMMIT TRANSACTION t_Transaction", conn);
            cmd7.CommandTimeout = 1000;
            conn.Open();
            cmd7.ExecuteNonQuery();
            conn.Close();*/

            /*SqlCommand cmd8 = new SqlCommand("UPDATE [Web-Musteri] SET [Web-Musteri].BOLGE = ISNULL(SATRAP.BLG_KOD,''),[Web-Musteri].ILGILI = ISNULL(SATRAP.[BOLGE],'') FROM [Web-Musteri] LEFT OUTER JOIN (SELECT DISTINCT SMREF,BLG_KOD,[BOLGE] FROM [KurumsalWebSAP].[dbo].[Web-Satis-Rapor-1] WHERE YIL > YEAR(getdate()) - 4) AS SATRAP ON [Web-Musteri].SMREF = SATRAP.SMREF", conn);
            cmd8.CommandTimeout = 1000;
            conn.Open();
            cmd8.ExecuteNonQuery();
            conn.Close();*/

            SqlCommand cmd9 = new SqlCommand("DELETE dbo.Z_Musteri_Sb_Say INSERT INTO dbo.Z_Musteri_Sb_Say  (dbo.Z_Musteri_Sb_Say.MUS_KOD, dbo.Z_Musteri_Sb_Say.GMREF, dbo.Z_Musteri_Sb_Say.SB_SAY, dbo.Z_Musteri_Sb_Say.A_P) SELECT dbo.SUL_Musteri_G.[MUST KOD], dbo.SUL_Musteri_G.GMREF, dbo.SUL_Musteri_G.SB_SAY, dbo.SUL_Musteri_G.A_P FROM dbo.Z_Musteri_Sb_Say FULL OUTER JOIN dbo.SUL_Musteri_G ON dbo.Z_Musteri_Sb_Say.MUS_KOD = dbo.SUL_Musteri_G.[MUST KOD] WHERE (NOT (dbo.SUL_Musteri_G.[MUST KOD] IS NULL))", conn);
            cmd9.CommandTimeout = 1000;
            conn.Open();
            cmd9.ExecuteNonQuery();
            conn.Close();



            conn.Open(); cmdLog.Parameters.AddWithValue("@dtBitis", DateTime.Now); cmdLog.ExecuteNonQuery(); conn.Close();
        }

        void GetSAP2()
        {
            SqlConnection conn = new SqlConnection("Server=.; Database=KurumsalWebSAP; User Id=sa; Password=sdl580g5p9+-; Trusted_Connection=False;");
            NetworkCredential nc1 = new NetworkCredential("ngunay", "123456");

            bool vbfa = false;
            bool siparis = true;
            bool teslimat = false;
            bool nakilmalfatura = false;
            bool nakilsiparis = false;
            bool malcikis = false;
            bool fatura = false;
            bool kolietiket = false;
            bool accounting = false;
            bool efatura = false;
            bool ekstre = DateTime.Now.Hour == 12;



            #region VBFA
            if (vbfa)
            {
                DateTime maxtarih = MaxTarihGetir(conn, "SAP_Vbfa");
                DateTime bitistarih = DateTime.Now;
                bool hatavar = false;

                selectsalesvbfaC.ZwebSelectSalesVbfaService client = new selectsalesvbfaC.ZwebSelectSalesVbfaService();
                client.Timeout = 6000000;
                client.Credentials = nc1;

                DateTime cekilecektarih = maxtarih;
                DateTime simdikitarih = DateTime.Now;
                while (Convert.ToDateTime(cekilecektarih.ToShortDateString()) <= Convert.ToDateTime(simdikitarih.ToShortDateString()))
                {
                    selectsalesvbfaC.Zwebs009[] dokuz = null;

                    string hata = string.Empty;
                    string tarih = "";
                    string saat = "00:00:00";
                    try
                    {
                        TarihSaat(maxtarih, cekilecektarih, out tarih, out saat);

                        EventLog.WriteEntry("Sultanlar Windows Service", "vbfa sap " + tarih + " " + saat + " istek basladi " + DateTime.Now.ToLongTimeString(), EventLogEntryType.Information);
                        dokuz = client.ZwebSelectSalesVbfa(tarih, saat);
                        EventLog.WriteEntry("Sultanlar Windows Service", "vbfa sap " + tarih + " " + saat + " istek geldi " + DateTime.Now.ToLongTimeString(), EventLogEntryType.Information);
                    }
                    catch (Exception ex)
                    {
                        hata = ex.Message;
                        hatavar = true;
                        cekilecektarih = DateTime.Now; // while dan çıksın bir sonraki günü almasın max tarihi yenilemesin

                        EventLog.WriteEntry("Sultanlar Windows Service", "vbfa sap " + tarih + " " + saat + " istekte hata olustu " + DateTime.Now.ToLongTimeString() + " " + hata, EventLogEntryType.Information);
                    }
                    finally
                    {
                        LogYaz(conn, "select sales vbfa", hata != string.Empty ? false : true, hata, Convert.ToDateTime(cekilecektarih.ToShortDateString() + " " + saat), Convert.ToDateTime(cekilecektarih.ToShortDateString()) == Convert.ToDateTime(simdikitarih.ToShortDateString()) ? DateTime.Now : Convert.ToDateTime(cekilecektarih.AddDays(1).ToShortDateString() + " 00:00:00"));
                    }

                    if (dokuz != null)
                    {
                        EventLog.WriteEntry("Sultanlar Windows Service", "vbfa sap " + tarih + " " + saat + " yazma basladi (" + dokuz.Length.ToString() + " satır) " + DateTime.Now.ToLongTimeString(), EventLogEntryType.Information);
                        for (int j = 0; j < dokuz.Length; j++)
                        {
                            try
                            {
                                conn.Open();
                                SqlCommand cmd = new SqlCommand(
                                    "DELETE FROM [SAP_VBFA] WHERE Vbelv = @Vbelv AND Posnv = @Posnv AND Vbeln = @Vbeln AND Posnn = @Posnn AND [Vbtyp N] = @VbtypN " +
                                    "INSERT INTO [SAP_VBFA] (KAYIT_TARIHI,[Vbelv],[Posnv],[Vbeln],[Posnn],[Vbtyp N],[Rfmng],[Meins],[Rfwrt],[Waers],[Vbtyp V],[Plmin],[Taqui],[Erdat],[Erzet],[Matnr],[Bwart],[Bdart],[Plart],[Stufe],[Lgnum],[Aedat],[Fktyp],[Brgew],[Gewei],[Volum],[Voleh],[Fplnr],[Fpltr],[Rfmng Flo],[Rfmng Flt],[Vrkme],[Abges],[Sobkz],[Sonum],[Kzbef],[Ntgew],[Logsys],[Wbsta],[Cmeth],[Mjahr]) VALUES (@KAYIT_TARIHI,@Vbelv,@Posnv,@Vbeln,@Posnn,@VbtypN,@Rfmng,@Meins,@Rfwrt,@Waers,@VbtypV,@Plmin,@Taqui,@Erdat,@Erzet,@Matnr,@Bwart,@Bdart,@Plart,@Stufe,@Lgnum,@Aedat,@Fktyp,@Brgew,@Gewei,@Volum,@Voleh,@Fplnr,@Fpltr,@RfmngFlo,@RfmngFlt,@Vrkme,@Abges,@Sobkz,@Sonum,@Kzbef,@Ntgew,@Logsys,@Wbsta,@Cmeth,@Mjahr)", conn);
                                #region parameters
                                cmd.Parameters.AddWithValue("@KAYIT_TARIHI", DateTime.Now);
                                cmd.Parameters.AddWithValue("@Vbelv", Convert.ToInt64(dokuz[j].Vbelv));
                                cmd.Parameters.AddWithValue("@Posnv", Convert.ToInt32(dokuz[j].Posnv));
                                cmd.Parameters.AddWithValue("@Vbeln", Convert.ToInt64(dokuz[j].Vbeln));
                                cmd.Parameters.AddWithValue("@Posnn", Convert.ToInt32(dokuz[j].Posnn));
                                cmd.Parameters.AddWithValue("@VbtypN", dokuz[j].VbtypN);
                                cmd.Parameters.AddWithValue("@Rfmng", dokuz[j].Rfmng);
                                cmd.Parameters.AddWithValue("@Meins", dokuz[j].Meins);
                                cmd.Parameters.AddWithValue("@Rfwrt", dokuz[j].Rfwrt);
                                cmd.Parameters.AddWithValue("@Waers", dokuz[j].Waers);
                                cmd.Parameters.AddWithValue("@VbtypV", dokuz[j].VbtypV);
                                cmd.Parameters.AddWithValue("@Plmin", dokuz[j].Plmin);
                                cmd.Parameters.AddWithValue("@Taqui", dokuz[j].Taqui);
                                cmd.Parameters.AddWithValue("@Erdat", Convert.ToDateTime(dokuz[j].Erdat + " " + dokuz[j].Erzet));
                                cmd.Parameters.AddWithValue("@Erzet", dokuz[j].Erzet);
                                cmd.Parameters.AddWithValue("@Matnr", dokuz[j].Matnr == string.Empty ? 0 : Convert.ToInt32(dokuz[j].Matnr));
                                cmd.Parameters.AddWithValue("@Bwart", dokuz[j].Bwart);
                                cmd.Parameters.AddWithValue("@Bdart", dokuz[j].Bdart);
                                cmd.Parameters.AddWithValue("@Plart", dokuz[j].Plart);
                                cmd.Parameters.AddWithValue("@Stufe", dokuz[j].Stufe);
                                cmd.Parameters.AddWithValue("@Lgnum", dokuz[j].Lgnum);
                                cmd.Parameters.AddWithValue("@Aedat", dokuz[j].Aedat.StartsWith("0000") ? Convert.ToDateTime("01.01.1900") : Convert.ToDateTime(dokuz[j].Aedat));
                                cmd.Parameters.AddWithValue("@Fktyp", dokuz[j].Fktyp);
                                cmd.Parameters.AddWithValue("@Brgew", dokuz[j].Brgew);
                                cmd.Parameters.AddWithValue("@Gewei", dokuz[j].Gewei);
                                cmd.Parameters.AddWithValue("@Volum", dokuz[j].Volum);
                                cmd.Parameters.AddWithValue("@Voleh", dokuz[j].Voleh);
                                cmd.Parameters.AddWithValue("@Fplnr", dokuz[j].Fplnr);
                                cmd.Parameters.AddWithValue("@Fpltr", dokuz[j].Fpltr);
                                cmd.Parameters.AddWithValue("@RfmngFlo", dokuz[j].RfmngFlo);
                                cmd.Parameters.AddWithValue("@RfmngFlt", dokuz[j].RfmngFlt);
                                cmd.Parameters.AddWithValue("@Vrkme", dokuz[j].Vrkme);
                                cmd.Parameters.AddWithValue("@Abges", dokuz[j].Abges);
                                cmd.Parameters.AddWithValue("@Sobkz", dokuz[j].Sobkz);
                                cmd.Parameters.AddWithValue("@Sonum", dokuz[j].Sonum);
                                cmd.Parameters.AddWithValue("@Kzbef", dokuz[j].Kzbef);
                                cmd.Parameters.AddWithValue("@Ntgew", dokuz[j].Ntgew);
                                cmd.Parameters.AddWithValue("@Logsys", dokuz[j].Logsys);
                                cmd.Parameters.AddWithValue("@Wbsta", dokuz[j].Wbsta);
                                cmd.Parameters.AddWithValue("@Cmeth", dokuz[j].Cmeth);
                                cmd.Parameters.AddWithValue("@Mjahr", dokuz[j].Mjahr);
                                #endregion
                                cmd.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                HataYaz(conn, "SAP_VBFA", Convert.ToInt64(dokuz[j].Vbelv).ToString(), Convert.ToInt32(dokuz[j].Posnv).ToString(), Convert.ToInt64(dokuz[j].Vbeln).ToString(), Convert.ToInt32(dokuz[j].Posnn).ToString(), dokuz[j].VbtypN, ex.Message, cekilecektarih, cekilecektarih.AddDays(1));
                            }
                            conn.Close();
                        }
                        EventLog.WriteEntry("Sultanlar Windows Service", "vbfa sap " + tarih + " " + saat + " yazma bitti " + DateTime.Now.ToLongTimeString(), EventLogEntryType.Information);
                    }

                    cekilecektarih = cekilecektarih.AddDays(1);
                }

                if (!hatavar)
                    MaxTarihYaz(conn, "SAP_Vbfa", bitistarih);
            }
            #endregion



            #region SIPARIS
            if (siparis)
            {
                selectsalesorderC.ZwebSelectSalesOrderService client2 = new selectsalesorderC.ZwebSelectSalesOrderService();
                client2.Timeout = 6000000;
                client2.Credentials = nc1;

                DateTime cekilecektarih = Convert.ToDateTime("05.01.2021");
                if (true)
                {
                    selectsalesorderC.Zwebs009[] dokuz = null; // vbfa
                    selectsalesorderC.Zwebs005[] bes = null; // head
                    selectsalesorderC.Zwebs012[] oniki = null; // item
                    selectsalesorderC.Zwebs021[] yirmibir = null; // logdel

                    string hata = string.Empty;
                    string tarih = "";
                    string saat = "00:00:00";
                    try
                    {
                        TarihSaat(cekilecektarih.AddDays(1), cekilecektarih, out tarih, out saat);

                        EventLog.WriteEntry("Sultanlar Windows Service", "sap siparis " + tarih + " " + saat + " istek basladi " + DateTime.Now.ToLongTimeString(), EventLogEntryType.Information);
                        yirmibir = client2.ZwebSelectSalesOrder(tarih, "", saat, out bes, out oniki, out dokuz);
                        EventLog.WriteEntry("Sultanlar Windows Service", "sap siparis " + tarih + " " + saat + " istek geldi " + DateTime.Now.ToLongTimeString(), EventLogEntryType.Information);
                    }
                    catch (Exception ex)
                    {
                        hata = ex.Message;
                        //hatavar = true;
                        cekilecektarih = DateTime.Now; // while dan çıksın bir sonraki günü almasın max tarihi yenilemesin

                        EventLog.WriteEntry("Sultanlar Windows Service", "sap siparis " + tarih + " " + saat + " istekte hata olustu " + DateTime.Now.ToLongTimeString() + " " + hata, EventLogEntryType.Information);
                    }

                    EventLog.WriteEntry("Sultanlar Windows Service", "sap siparis " + tarih + " " + saat + " yazma basladi (" + bes.Length.ToString() + " satır) " + DateTime.Now.ToLongTimeString(), EventLogEntryType.Information);
                    #region logdel
                    if (yirmibir != null)
                    {
                        for (int j = 0; j < yirmibir.Length; j++)
                        {
                            try
                            {
                                conn.Open();
                                SqlCommand cmd = new SqlCommand("DELETE FROM [SAP_SIPARIS_BASLIK] WHERE Vbeln = @Vbeln DELETE FROM [SAP_SIPARIS_DETAY] WHERE Vbeln = @Vbeln DELETE FROM [SAP_VBFA] WHERE Vbelv = @Vbeln", conn);
                                cmd.Parameters.AddWithValue("@Vbeln", Convert.ToInt64(yirmibir[j].Vbeln));
                                cmd.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                HataYaz(conn, "SAP_SIPARIS_BASLIK", Convert.ToInt64(yirmibir[j].Vbeln).ToString(), "", "", "", "", "(LOGDEL) - " + ex.Message, cekilecektarih, cekilecektarih.AddDays(1));
                            }
                            conn.Close();
                        }
                    }
                    #endregion

                    #region head
                    if (bes != null)
                    {
                        for (int j = 0; j < bes.Length; j++)
                        {
                            try
                            {
                                conn.Open();
                                SqlCommand cmd = new SqlCommand(
                                    "DELETE FROM [SAP_SIPARIS_BASLIK] WHERE Vbeln = @Vbeln " +
                                    "DELETE FROM [SAP_SIPARIS_DETAY] WHERE Vbeln = @Vbeln " +
                                    "DELETE FROM [SAP_VBFA] WHERE Vbeln = @Vbeln " +
                                    "INSERT INTO [SAP_SIPARIS_BASLIK] (KAYIT_TARIHI,[Vbeln],[Auart],[Bezei],[Audat],[Erdat],[Erzet],[Ernam],[Netwr],[Waerk],[Vkorg],[Vtext],[Vtweg],[Bzirk],[Bztxt],[Bstnk],[Kunnr],[Aedat],[Spart],[Vtext2],[Vkgrp],[Vkbur],[Kdgrp],[Ktext],[Name1],[Name2],[Name3],[Name4],[Name Text],[Name Co],[City1],[City2],[Street],[Region],[Sort1],[Deflt Comm],[Comm Text],[Tel Number],[Fax Number],[Stcd1],[Stcd2],[Post Code1],[Smtp Addr],[Pltyp],[Ptext],[OKunnr],[OStcd1],[OStcd2],[OName1],[ODeflt Comm],[OSmtp Addr],[OComm Text],[Yetkili],[Sip Aciklama],[Netpr],[Knumv],[Yetkili Kod],[Yetkili Ad],[Yetkili Tel],[Satsor Kod],[Satsor Ad],[Satsor Tel],[Sipalan Kod],[Sipalan Ad],[Sipalan Tel],[NamaSatici],[NamaSaticiAd],Vdatu,Bstkd) VALUES (@KAYIT_TARIHI,@Vbeln,@Auart,@Bezei,@Audat,@Erdat,@Erzet,@Ernam,@Netwr,@Waerk,@Vkorg,@Vtext,@Vtweg,@Bzirk,@Bztxt,@Bstnk,@Kunnr,@Aedat,@Spart,@Vtext2,@Vkgrp,@Vkbur,@Kdgrp,@Ktext,@Name1,@Name2,@Name3,@Name4,@NameText,@NameCo,@City1,@City2,@Street,@Region,@Sort1,@DefltComm,@CommText,@TelNumber,@FaxNumber,@Stcd1,@Stcd2,@PostCode1,@SmtpAddr,@Pltyp,@Ptext,@OKunnr,@OStcd1,@OStcd2,@OName1,@ODefltComm,@OSmtpAddr,@OCommText,@Yetkili,@SipAciklama,@Netpr,@Knumv,@YetkiliKod,@YetkiliAd,@YetkiliTel,@SatsorKod,@SatsorAd,@SatsorTel,@SipalanKod,@SipalanAd,@SipalanTel,@NamaSatici,@NamaSaticiAd,@Vdatu,@Bstkd)", conn);
                                #region parameters
                                cmd.Parameters.AddWithValue("@KAYIT_TARIHI", DateTime.Now);
                                cmd.Parameters.AddWithValue("@Vbeln", Convert.ToInt64(bes[j].Vbeln));
                                cmd.Parameters.AddWithValue("@Auart", bes[j].Auart);
                                cmd.Parameters.AddWithValue("@Bezei", bes[j].Bezei);
                                cmd.Parameters.AddWithValue("@Audat", Convert.ToDateTime(bes[j].Audat));
                                cmd.Parameters.AddWithValue("@Erdat", Convert.ToDateTime(bes[j].Erdat + " " + bes[j].Erzet));
                                cmd.Parameters.AddWithValue("@Erzet", bes[j].Erzet);
                                cmd.Parameters.AddWithValue("@Ernam", bes[j].Ernam);
                                cmd.Parameters.AddWithValue("@Netwr", bes[j].Netwr);
                                cmd.Parameters.AddWithValue("@Waerk", bes[j].Waerk);
                                cmd.Parameters.AddWithValue("@Vkorg", bes[j].Vkorg);
                                cmd.Parameters.AddWithValue("@Vtext", bes[j].Vtext);
                                cmd.Parameters.AddWithValue("@Vtweg", bes[j].Vtweg);
                                cmd.Parameters.AddWithValue("@Bzirk", bes[j].Bzirk);
                                cmd.Parameters.AddWithValue("@Bztxt", bes[j].Bztxt);
                                cmd.Parameters.AddWithValue("@Bstnk", bes[j].Bstnk);
                                cmd.Parameters.AddWithValue("@Kunnr", bes[j].Kunnr.StartsWith("T") || bes[j].Kunnr == "" ? 10 : Convert.ToInt32(bes[j].Kunnr));
                                cmd.Parameters.AddWithValue("@Aedat", bes[j].Aedat.StartsWith("0000") ? Convert.ToDateTime(bes[j].Audat) : Convert.ToDateTime(bes[j].Aedat));
                                cmd.Parameters.AddWithValue("@Spart", bes[j].Spart);
                                cmd.Parameters.AddWithValue("@Vtext2", bes[j].Vtext2);
                                cmd.Parameters.AddWithValue("@Vkgrp", bes[j].Vkgrp);
                                cmd.Parameters.AddWithValue("@Vkbur", bes[j].Vkbur);
                                cmd.Parameters.AddWithValue("@Kdgrp", bes[j].Kdgrp);
                                cmd.Parameters.AddWithValue("@Ktext", bes[j].Ktext);
                                cmd.Parameters.AddWithValue("@Name1", bes[j].Name1);
                                cmd.Parameters.AddWithValue("@Name2", bes[j].Name2);
                                cmd.Parameters.AddWithValue("@Name3", bes[j].Name3);
                                cmd.Parameters.AddWithValue("@Name4", bes[j].Name4);
                                cmd.Parameters.AddWithValue("@NameText", bes[j].NameText);
                                cmd.Parameters.AddWithValue("@NameCo", bes[j].NameCo);
                                cmd.Parameters.AddWithValue("@City1", bes[j].City1);
                                cmd.Parameters.AddWithValue("@City2", bes[j].City2);
                                cmd.Parameters.AddWithValue("@Street", bes[j].Street);
                                cmd.Parameters.AddWithValue("@Region", bes[j].Region);
                                cmd.Parameters.AddWithValue("@Sort1", bes[j].Sort1);
                                cmd.Parameters.AddWithValue("@DefltComm", bes[j].DefltComm);
                                cmd.Parameters.AddWithValue("@CommText", bes[j].CommText);
                                cmd.Parameters.AddWithValue("@TelNumber", bes[j].TelNumber);
                                cmd.Parameters.AddWithValue("@FaxNumber", bes[j].FaxNumber);
                                cmd.Parameters.AddWithValue("@Stcd1", bes[j].Stcd1);
                                cmd.Parameters.AddWithValue("@Stcd2", bes[j].Stcd2);
                                cmd.Parameters.AddWithValue("@PostCode1", bes[j].PostCode1);
                                cmd.Parameters.AddWithValue("@SmtpAddr", bes[j].SmtpAddr);
                                cmd.Parameters.AddWithValue("@Pltyp", bes[j].Pltyp);
                                cmd.Parameters.AddWithValue("@Ptext", bes[j].Ptext);
                                cmd.Parameters.AddWithValue("@OKunnr", bes[j].OKunnr.StartsWith("T") || bes[j].OKunnr == "" ? 10 : Convert.ToInt32(bes[j].OKunnr));
                                cmd.Parameters.AddWithValue("@OStcd1", bes[j].OStcd1);
                                cmd.Parameters.AddWithValue("@OStcd2", bes[j].OStcd2);
                                cmd.Parameters.AddWithValue("@OName1", bes[j].OName1);
                                cmd.Parameters.AddWithValue("@ODefltComm", bes[j].ODefltComm);
                                cmd.Parameters.AddWithValue("@OSmtpAddr", bes[j].OSmtpAddr);
                                cmd.Parameters.AddWithValue("@OCommText", bes[j].OCommText);
                                cmd.Parameters.AddWithValue("@Yetkili", bes[j].Yetkili);
                                cmd.Parameters.AddWithValue("@SipAciklama", bes[j].SipAciklama);
                                cmd.Parameters.AddWithValue("@Netpr", bes[j].Netpr);
                                cmd.Parameters.AddWithValue("@Knumv", bes[j].Knumv.StartsWith("T") || bes[j].Knumv == "" ? 10 : Convert.ToInt32(bes[j].Knumv));
                                cmd.Parameters.AddWithValue("@YetkiliKod", Convert.ToInt32(bes[j].YetkiliKod));
                                cmd.Parameters.AddWithValue("@YetkiliAd", bes[j].YetkiliAd);
                                cmd.Parameters.AddWithValue("@YetkiliTel", bes[j].YetkiliTel);
                                cmd.Parameters.AddWithValue("@SatsorKod", Convert.ToInt32(bes[j].SatsorKod));
                                cmd.Parameters.AddWithValue("@SatsorAd", bes[j].SatsorAd);
                                cmd.Parameters.AddWithValue("@SatsorTel", bes[j].SatsorTel);
                                cmd.Parameters.AddWithValue("@SipalanKod", Convert.ToInt32(bes[j].SipalanKod));
                                cmd.Parameters.AddWithValue("@SipalanAd", bes[j].SipalanAd);
                                cmd.Parameters.AddWithValue("@SipalanTel", bes[j].SipalanTel);
                                cmd.Parameters.AddWithValue("@NamaSatici", bes[j].NamaSatici);
                                cmd.Parameters.AddWithValue("@NamaSaticiAd", bes[j].NamaSaticiAd);
                                cmd.Parameters.AddWithValue("@Vdatu", bes[j].Vdatu);
                                cmd.Parameters.AddWithValue("@Bstkd", bes[j].Bstkd);
                                #endregion
                                cmd.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                HataYaz(conn, "SAP_SIPARIS_BASLIK", Convert.ToInt64(bes[j].Vbeln).ToString(), "", "", "", "", ex.Message, cekilecektarih, cekilecektarih.AddDays(1));
                            }
                            conn.Close();
                        }
                    }
                    #endregion

                    #region item
                    if (oniki != null)
                    {
                        for (int j = 0; j < oniki.Length; j++)
                        {
                            try
                            {
                                conn.Open();
                                SqlCommand cmd = new SqlCommand(
                                    "DELETE FROM [SAP_SIPARIS_DETAY] WHERE Vbeln = @Vbeln AND Posnr = @Posnr " +
                                    "INSERT INTO [SAP_SIPARIS_DETAY] (KAYIT_TARIHI,[Vbeln],[Posnr],[Matnr],[Arktx],[Pltyp],[Ptext],[Zterm],[Netdt],[Matkl],[Wgbez],[Spart],[Vtext2],[Ean11],[Kwmeng],[Vrkme],[Vrkme Text],[Kwmeng2],[Vrkme2],[Vrkme2Text],[Ean112],[Yuz1],[Yuz2],[Yuz3],[Yuz4],[Yuz5],[Yuz6],[Yuz7],[Yuz8],[Yuz9],[Yuz10],[Brtpr],[Netpr],[Netwr],[Kzwi1],[Kdvoran],[Mwsbp],[Waerk],[Brgew],[Ntgew],[Gewei],[Volum],[Voleh],[Ksc1],[Ksc2],[Ksc3],[Ksc4],[Ksc5],[Ksc6],[Ksc7],[Ksc8],[Ksc9],[Ksc10],[Zzpirbz],[Zzpirgt],[Abgru],[Bezei_ab]) VALUES (@KAYIT_TARIHI,@Vbeln,@Posnr,@Matnr,@Arktx,@Pltyp,@Ptext,@Zterm,@Netdt,@Matkl,@Wgbez,@Spart,@Vtext2,@Ean11,@Kwmeng,@Vrkme,@VrkmeText,@Kwmeng2,@Vrkme2,@Vrkme2Text,@Ean112,@Yuz1,@Yuz2,@Yuz3,@Yuz4,@Yuz5,@Yuz6,@Yuz7,@Yuz8,@Yuz9,@Yuz10,@Brtpr,@Netpr,@Netwr,@Kzwi1,@Kdvoran,@Mwsbp,@Waerk,@Brgew,@Ntgew,@Gewei,@Volum,@Voleh,@Ksc1,@Ksc2,@Ksc3,@Ksc4,@Ksc5,@Ksc6,@Ksc7,@Ksc8,@Ksc9,@Ksc10,@Zzpirbz,@Zzpirgt,@Abgru,@Bezei_ab)", conn);
                                #region parameters
                                cmd.Parameters.AddWithValue("@KAYIT_TARIHI", DateTime.Now);
                                cmd.Parameters.AddWithValue("@Vbeln", Convert.ToInt64(oniki[j].Vbeln));
                                cmd.Parameters.AddWithValue("@Posnr", Convert.ToInt32(oniki[j].Posnr));
                                cmd.Parameters.AddWithValue("@Matnr", oniki[j].Matnr == string.Empty ? 0 : Convert.ToInt32(oniki[j].Matnr));
                                cmd.Parameters.AddWithValue("@Arktx", oniki[j].Arktx);
                                cmd.Parameters.AddWithValue("@Pltyp", oniki[j].Pltyp);
                                cmd.Parameters.AddWithValue("@Ptext", oniki[j].Ptext);
                                cmd.Parameters.AddWithValue("@Zterm", oniki[j].Zterm == string.Empty ? 0 : Convert.ToInt32(oniki[j].Zterm));
                                cmd.Parameters.AddWithValue("@Netdt", oniki[j].Netdt.StartsWith("0000") ? Convert.ToDateTime("01.01.1900") : Convert.ToDateTime(oniki[j].Netdt));
                                cmd.Parameters.AddWithValue("@Matkl", oniki[j].Matkl);
                                cmd.Parameters.AddWithValue("@Wgbez", oniki[j].Wgbez);
                                cmd.Parameters.AddWithValue("@Spart", oniki[j].Spart);
                                cmd.Parameters.AddWithValue("@Vtext2", oniki[j].Vtext2);
                                cmd.Parameters.AddWithValue("@Ean11", oniki[j].Ean11);
                                cmd.Parameters.AddWithValue("@Kwmeng", oniki[j].Kwmeng);
                                cmd.Parameters.AddWithValue("@Vrkme", oniki[j].Vrkme);
                                cmd.Parameters.AddWithValue("@VrkmeText", oniki[j].VrkmeText);
                                cmd.Parameters.AddWithValue("@Kwmeng2", oniki[j].Kwmeng2);
                                cmd.Parameters.AddWithValue("@Vrkme2", oniki[j].Vrkme2);
                                cmd.Parameters.AddWithValue("@Vrkme2Text", oniki[j].Vrkme2Text);
                                cmd.Parameters.AddWithValue("@Ean112", oniki[j].Ean112);
                                cmd.Parameters.AddWithValue("@Yuz1", oniki[j].Yuz1);
                                cmd.Parameters.AddWithValue("@Yuz2", oniki[j].Yuz2);
                                cmd.Parameters.AddWithValue("@Yuz3", oniki[j].Yuz3);
                                cmd.Parameters.AddWithValue("@Yuz4", oniki[j].Yuz4);
                                cmd.Parameters.AddWithValue("@Yuz5", oniki[j].Yuz5);
                                cmd.Parameters.AddWithValue("@Yuz6", oniki[j].Yuz6);
                                cmd.Parameters.AddWithValue("@Yuz7", oniki[j].Yuz7);
                                cmd.Parameters.AddWithValue("@Yuz8", oniki[j].Yuz8);
                                cmd.Parameters.AddWithValue("@Yuz9", oniki[j].Yuz9);
                                cmd.Parameters.AddWithValue("@Yuz10", oniki[j].Yuz10);
                                cmd.Parameters.AddWithValue("@Brtpr", oniki[j].Brtpr);
                                cmd.Parameters.AddWithValue("@Netpr", oniki[j].Netpr);
                                cmd.Parameters.AddWithValue("@Netwr", oniki[j].Netwr);
                                cmd.Parameters.AddWithValue("@Kzwi1", oniki[j].Kzwi1);
                                cmd.Parameters.AddWithValue("@Kdvoran", Convert.ToInt32(oniki[j].Kdvoran));
                                cmd.Parameters.AddWithValue("@Mwsbp", oniki[j].Mwsbp);
                                cmd.Parameters.AddWithValue("@Waerk", oniki[j].Waerk);
                                cmd.Parameters.AddWithValue("@Brgew", oniki[j].Brgew);
                                cmd.Parameters.AddWithValue("@Ntgew", oniki[j].Ntgew);
                                cmd.Parameters.AddWithValue("@Gewei", oniki[j].Gewei);
                                cmd.Parameters.AddWithValue("@Volum", oniki[j].Volum);
                                cmd.Parameters.AddWithValue("@Voleh", oniki[j].Voleh);
                                cmd.Parameters.AddWithValue("@Ksc1", oniki[j].Ksc1);
                                cmd.Parameters.AddWithValue("@Ksc2", oniki[j].Ksc2);
                                cmd.Parameters.AddWithValue("@Ksc3", oniki[j].Ksc3);
                                cmd.Parameters.AddWithValue("@Ksc4", oniki[j].Ksc4);
                                cmd.Parameters.AddWithValue("@Ksc5", oniki[j].Ksc5);
                                cmd.Parameters.AddWithValue("@Ksc6", oniki[j].Ksc6);
                                cmd.Parameters.AddWithValue("@Ksc7", oniki[j].Ksc7);
                                cmd.Parameters.AddWithValue("@Ksc8", oniki[j].Ksc8);
                                cmd.Parameters.AddWithValue("@Ksc9", oniki[j].Ksc9);
                                cmd.Parameters.AddWithValue("@Ksc10", oniki[j].Ksc10);
                                cmd.Parameters.AddWithValue("@Zzpirbz", oniki[j].Zzpirbz);
                                cmd.Parameters.AddWithValue("@Zzpirgt", oniki[j].Zzpirgt);
                                cmd.Parameters.AddWithValue("@Abgru", oniki[j].Abgru);
                                cmd.Parameters.AddWithValue("@Bezei_ab", oniki[j].BezeiAb);
                                #endregion
                                cmd.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                HataYaz(conn, "SAP_SIPARIS_DETAY", Convert.ToInt64(oniki[j].Vbeln).ToString(), Convert.ToInt32(oniki[j].Posnr).ToString(), "", "", "", ex.Message, cekilecektarih, cekilecektarih.AddDays(1));
                            }
                            conn.Close();
                        }
                    }
                    #endregion

                    #region vbfa
                    if (dokuz != null)
                    {
                        for (int j = 0; j < dokuz.Length; j++)
                        {
                            try
                            {
                                conn.Open();
                                SqlCommand cmd = new SqlCommand("sp_SAP_VBFA_InsertUpdate", conn);
                                cmd.CommandType = CommandType.StoredProcedure;
                                #region parameters
                                cmd.Parameters.AddWithValue("@KAYIT_TARIHI", DateTime.Now);
                                cmd.Parameters.AddWithValue("@Vbelv", Convert.ToInt64(dokuz[j].Vbelv));
                                cmd.Parameters.AddWithValue("@Posnv", Convert.ToInt32(dokuz[j].Posnv));
                                cmd.Parameters.AddWithValue("@Vbeln", Convert.ToInt64(dokuz[j].Vbeln));
                                cmd.Parameters.AddWithValue("@Posnn", Convert.ToInt32(dokuz[j].Posnn));
                                cmd.Parameters.AddWithValue("@VbtypN", dokuz[j].VbtypN);
                                cmd.Parameters.AddWithValue("@Rfmng", dokuz[j].Rfmng);
                                cmd.Parameters.AddWithValue("@Meins", dokuz[j].Meins);
                                cmd.Parameters.AddWithValue("@Rfwrt", dokuz[j].Rfwrt);
                                cmd.Parameters.AddWithValue("@Waers", dokuz[j].Waers);
                                cmd.Parameters.AddWithValue("@VbtypV", dokuz[j].VbtypV);
                                cmd.Parameters.AddWithValue("@Plmin", dokuz[j].Plmin);
                                cmd.Parameters.AddWithValue("@Taqui", dokuz[j].Taqui);
                                cmd.Parameters.AddWithValue("@Erdat", Convert.ToDateTime(dokuz[j].Erdat + " " + dokuz[j].Erzet));
                                cmd.Parameters.AddWithValue("@Erzet", dokuz[j].Erzet);
                                cmd.Parameters.AddWithValue("@Matnr", dokuz[j].Matnr == string.Empty ? 0 : Convert.ToInt32(dokuz[j].Matnr));
                                cmd.Parameters.AddWithValue("@Bwart", dokuz[j].Bwart);
                                cmd.Parameters.AddWithValue("@Bdart", dokuz[j].Bdart);
                                cmd.Parameters.AddWithValue("@Plart", dokuz[j].Plart);
                                cmd.Parameters.AddWithValue("@Stufe", dokuz[j].Stufe);
                                cmd.Parameters.AddWithValue("@Lgnum", dokuz[j].Lgnum);
                                cmd.Parameters.AddWithValue("@Aedat", dokuz[j].Aedat.StartsWith("0000") ? Convert.ToDateTime("01.01.1900") : Convert.ToDateTime(dokuz[j].Aedat));
                                cmd.Parameters.AddWithValue("@Fktyp", dokuz[j].Fktyp);
                                cmd.Parameters.AddWithValue("@Brgew", dokuz[j].Brgew);
                                cmd.Parameters.AddWithValue("@Gewei", dokuz[j].Gewei);
                                cmd.Parameters.AddWithValue("@Volum", dokuz[j].Volum);
                                cmd.Parameters.AddWithValue("@Voleh", dokuz[j].Voleh);
                                cmd.Parameters.AddWithValue("@Fplnr", dokuz[j].Fplnr);
                                cmd.Parameters.AddWithValue("@Fpltr", dokuz[j].Fpltr);
                                cmd.Parameters.AddWithValue("@RfmngFlo", dokuz[j].RfmngFlo);
                                cmd.Parameters.AddWithValue("@RfmngFlt", dokuz[j].RfmngFlt);
                                cmd.Parameters.AddWithValue("@Vrkme", dokuz[j].Vrkme);
                                cmd.Parameters.AddWithValue("@Abges", dokuz[j].Abges);
                                cmd.Parameters.AddWithValue("@Sobkz", dokuz[j].Sobkz);
                                cmd.Parameters.AddWithValue("@Sonum", dokuz[j].Sonum);
                                cmd.Parameters.AddWithValue("@Kzbef", dokuz[j].Kzbef);
                                cmd.Parameters.AddWithValue("@Ntgew", dokuz[j].Ntgew);
                                cmd.Parameters.AddWithValue("@Logsys", dokuz[j].Logsys);
                                cmd.Parameters.AddWithValue("@Wbsta", dokuz[j].Wbsta);
                                cmd.Parameters.AddWithValue("@Cmeth", dokuz[j].Cmeth);
                                cmd.Parameters.AddWithValue("@Mjahr", dokuz[j].Mjahr);
                                #endregion
                                cmd.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                HataYaz(conn, "SAP_VBFA", Convert.ToInt64(dokuz[j].Vbelv).ToString(), Convert.ToInt32(dokuz[j].Posnv).ToString(), Convert.ToInt64(dokuz[j].Vbeln).ToString(), Convert.ToInt32(dokuz[j].Posnn).ToString(), dokuz[j].VbtypN, "(SIPARIS) - " + ex.Message, cekilecektarih, cekilecektarih.AddDays(1));
                            }
                            conn.Close();
                        }
                    }
                    #endregion
                    EventLog.WriteEntry("Sultanlar Windows Service", "sap siparis " + tarih + " " + saat + " yazma bitti (" + bes.Length.ToString() + " satır) " + DateTime.Now.ToLongTimeString(), EventLogEntryType.Information);
                }
            }
            #endregion



            #region TESLIMAT
            if (teslimat)
            {
                DateTime maxtarih = MaxTarihGetir(conn, "SAP_Teslimat");
                DateTime bitistarih = DateTime.Now;
                bool hatavar = false;

                selectsalesdeliveryC.ZwebSelectSalesDeliveryService client3 = new selectsalesdeliveryC.ZwebSelectSalesDeliveryService();
                client3.Timeout = 6000000;
                client3.Credentials = nc1;

                DateTime cekilecektarih = maxtarih;
                DateTime simdikitarih = DateTime.Now;
                while (Convert.ToDateTime(cekilecektarih.ToShortDateString()) <= Convert.ToDateTime(simdikitarih.ToShortDateString()))
                {
                    selectsalesdeliveryC.Zwebs009[] dokuz = null; // vbfa
                    selectsalesdeliveryC.Zwebs006[] alti = null; // head
                    selectsalesdeliveryC.Zwebs013[] onuc = null; // item
                    selectsalesdeliveryC.Zwebs021[] yirmibir = null; // logdel

                    string hata = string.Empty;
                    string tarih = "";
                    string saat = "00:00:00";
                    try
                    {
                        TarihSaat(maxtarih, cekilecektarih, out tarih, out saat);
                        
                        EventLog.WriteEntry("Sultanlar Windows Service", "sap teslimat " + tarih + " " + saat + " istek basladi " + DateTime.Now.ToLongTimeString(), EventLogEntryType.Information);
                        alti = client3.ZwebSelectSalesDelivery(tarih, "", saat, out onuc, out yirmibir, out dokuz);
                        EventLog.WriteEntry("Sultanlar Windows Service", "sap teslimat " + tarih + " " + saat + " istek geldi " + DateTime.Now.ToLongTimeString(), EventLogEntryType.Information);
                    }
                    catch (Exception ex)
                    {
                        hata = ex.Message;
                        //hatavar = true;
                        cekilecektarih = DateTime.Now; // while dan çıksın bir sonraki günü almasın max tarihi yenilemesin

                        EventLog.WriteEntry("Sultanlar Windows Service", "sap teslimat " + tarih + " " + saat + " istekte hata olustu " + DateTime.Now.ToLongTimeString() + " " + hata, EventLogEntryType.Information);
                    }
                    finally
                    {
                        LogYaz(conn, "select sales delivery", hata != string.Empty ? false : true, hata, Convert.ToDateTime(cekilecektarih.ToShortDateString() + " " + saat), Convert.ToDateTime(cekilecektarih.ToShortDateString()) == Convert.ToDateTime(simdikitarih.ToShortDateString()) ? DateTime.Now : Convert.ToDateTime(cekilecektarih.AddDays(1).ToShortDateString() + " 00:00:00"));
                    }

                    EventLog.WriteEntry("Sultanlar Windows Service", "sap teslimat " + tarih + " " + saat + " yazma basladi (" + alti.Length.ToString() + " satır) " + DateTime.Now.ToLongTimeString(), EventLogEntryType.Information);
                    #region logdel
                    if (yirmibir != null)
                    {
                        for (int j = 0; j < yirmibir.Length; j++)
                        {
                            try
                            {
                                conn.Open();
                                SqlCommand cmd = new SqlCommand("DELETE FROM [SAP_TESLIMAT_BASLIK] WHERE Vbeln = @Vbeln DELETE FROM [SAP_TESLIMAT_DETAY] WHERE Vbeln = @Vbeln DELETE FROM [SAP_VBFA] WHERE Vbelv = @Vbeln DELETE FROM [SAP_VBFA] WHERE Vbeln = @Vbeln", conn);
                                cmd.Parameters.AddWithValue("@Vbeln", Convert.ToInt64(yirmibir[j].Vbeln));
                                cmd.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                HataYaz(conn, "SAP_TESLIMAT_BASLIK", Convert.ToInt64(yirmibir[j].Vbeln).ToString(), "", "", "", "", "(LOGDEL) - " + ex.Message, cekilecektarih, cekilecektarih.AddDays(1));
                            }
                            conn.Close();
                        }
                    }
                    #endregion

                    #region head
                    if (alti != null)
                    {
                        for (int j = 0; j < alti.Length; j++)
                        {
                            try
                            {
                                conn.Open();
                                SqlCommand cmd = new SqlCommand(
                                    "DELETE FROM [SAP_TESLIMAT_BASLIK] WHERE Vbeln = @Vbeln " +
                                    "DELETE FROM [SAP_TESLIMAT_DETAY] WHERE Vbeln = @Vbeln " +
                                    "DELETE FROM [SAP_VBFA] WHERE Vbeln = @Vbeln " +
                                    "DELETE FROM [SAP_VBFA] WHERE Vbelv = @Vbeln " +
                                    "INSERT INTO [SAP_TESLIMAT_BASLIK] (KAYIT_TARIHI,[Lfart],[Vtext],[Vbeln],[Ernam],[Erzet],[Erdat],[Sevkalani],[Sevkyeri],[Teslimat Aciklama],[Volum],[Btgew],[Voleh],[Gewei],[Lifex]) VALUES (@KAYIT_TARIHI,@Lfart,@Vtext,@Vbeln,@Ernam,@Erzet,@Erdat,@Sevkalani,@Sevkyeri,@TeslimatAciklama,@Volum,@Btgew,@Voleh,@Gewei,@Lifex)", conn);
                                #region parameters
                                cmd.Parameters.AddWithValue("@KAYIT_TARIHI", DateTime.Now);
                                cmd.Parameters.AddWithValue("@Lfart", alti[j].Lfart);
                                cmd.Parameters.AddWithValue("@Vtext", alti[j].Vtext);
                                cmd.Parameters.AddWithValue("@Vbeln", Convert.ToInt64(alti[j].Vbeln));
                                cmd.Parameters.AddWithValue("@Ernam", alti[j].Ernam);
                                cmd.Parameters.AddWithValue("@Erzet", alti[j].Erzet);
                                cmd.Parameters.AddWithValue("@Erdat", Convert.ToDateTime(alti[j].Erdat + " " + alti[j].Erzet));
                                cmd.Parameters.AddWithValue("@Sevkalani", alti[j].Sevkalani);
                                cmd.Parameters.AddWithValue("@Sevkyeri", alti[j].Sevkyeri);
                                cmd.Parameters.AddWithValue("@TeslimatAciklama", alti[j].TeslimatAciklama);
                                cmd.Parameters.AddWithValue("@Volum", alti[j].Volum);
                                cmd.Parameters.AddWithValue("@Btgew", alti[j].Btgew);
                                cmd.Parameters.AddWithValue("@Voleh", alti[j].Voleh);
                                cmd.Parameters.AddWithValue("@Gewei", alti[j].Gewei);
                                cmd.Parameters.AddWithValue("@Lifex", alti[j].Lifex);
                                #endregion
                                cmd.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                HataYaz(conn, "SAP_TESLIMAT_BASLIK", Convert.ToInt64(alti[j].Vbeln).ToString(), "", "", "", "", ex.Message, cekilecektarih, cekilecektarih.AddDays(1));
                            }
                            conn.Close();
                        }
                    }
                    #endregion

                    #region item
                    if (onuc != null)
                    {
                        for (int j = 0; j < onuc.Length; j++)
                        {
                            try
                            {
                                conn.Open();
                                SqlCommand cmd = new SqlCommand(
                                    "DELETE FROM [SAP_TESLIMAT_DETAY] WHERE Vbeln = @Vbeln AND Posnr = @Posnr " +
                                    "INSERT INTO [SAP_TESLIMAT_DETAY] (KAYIT_TARIHI,[Vbeln],[Posnr],[Matnr],[Ernam],[Erzet],[Erdat],[Matkl],[Werks],[Lgort],[Charg],[Lfimg],[Meins],[Meins Text],[Ntgew],[Brgew],[Gewei],[Volum],[Voleh],Hsdat) VALUES (@KAYIT_TARIHI,@Vbeln,@Posnr,@Matnr,@Ernam,@Erzet,@Erdat,@Matkl,@Werks,@Lgort,@Charg,@Lfimg,@Meins,@MeinsText,@Ntgew,@Brgew,@Gewei,@Volum,@Voleh,@Hsdat)", conn);
                                #region parameters
                                cmd.Parameters.AddWithValue("@KAYIT_TARIHI", DateTime.Now);
                                cmd.Parameters.AddWithValue("@Vbeln", Convert.ToInt64(onuc[j].Vbeln));
                                cmd.Parameters.AddWithValue("@Posnr", Convert.ToInt32(onuc[j].Posnr));
                                cmd.Parameters.AddWithValue("@Matnr", onuc[j].Matnr == string.Empty ? 0 : Convert.ToInt32(onuc[j].Matnr));
                                cmd.Parameters.AddWithValue("@Ernam", onuc[j].Ernam);
                                cmd.Parameters.AddWithValue("@Erzet", onuc[j].Erzet);
                                cmd.Parameters.AddWithValue("@Erdat", Convert.ToDateTime(onuc[j].Erdat + " " + onuc[j].Erzet));
                                cmd.Parameters.AddWithValue("@Matkl", onuc[j].Matkl);
                                cmd.Parameters.AddWithValue("@Werks", onuc[j].Werks);
                                cmd.Parameters.AddWithValue("@Lgort", onuc[j].Lgort);
                                cmd.Parameters.AddWithValue("@Charg", onuc[j].Charg);
                                cmd.Parameters.AddWithValue("@Lfimg", onuc[j].Lfimg);
                                cmd.Parameters.AddWithValue("@Meins", onuc[j].Meins);
                                cmd.Parameters.AddWithValue("@MeinsText", onuc[j].MeinsText);
                                cmd.Parameters.AddWithValue("@Ntgew", onuc[j].Ntgew);
                                cmd.Parameters.AddWithValue("@Brgew", onuc[j].Brgew);
                                cmd.Parameters.AddWithValue("@Gewei", onuc[j].Gewei);
                                cmd.Parameters.AddWithValue("@Volum", onuc[j].Volum);
                                cmd.Parameters.AddWithValue("@Voleh", onuc[j].Voleh);
                                cmd.Parameters.AddWithValue("@Hsdat", (onuc[j].Hsdat != "0000-00-00" ? (Convert.ToDateTime(onuc[j].Hsdat) < Convert.ToDateTime("01.01.1900") ? Convert.ToDateTime("01.01.1900") : Convert.ToDateTime(onuc[j].Hsdat)) : Convert.ToDateTime("01.01.1900")));
                                #endregion
                                cmd.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                HataYaz(conn, "SAP_TESLIMAT_DETAY", Convert.ToInt64(onuc[j].Vbeln).ToString(), Convert.ToInt32(onuc[j].Posnr).ToString(), "", "", "", ex.Message, cekilecektarih, cekilecektarih.AddDays(1));
                            }
                            conn.Close();
                        }
                    }
                    #endregion

                    #region vbfa
                    if (dokuz != null)
                    {
                        for (int j = 0; j < dokuz.Length; j++)
                        {
                            try
                            {
                                conn.Open();
                                SqlCommand cmd = new SqlCommand("sp_SAP_VBFA_InsertUpdate", conn);
                                cmd.CommandType = CommandType.StoredProcedure;
                                #region parameters
                                cmd.Parameters.AddWithValue("@KAYIT_TARIHI", DateTime.Now);
                                cmd.Parameters.AddWithValue("@Vbelv", Convert.ToInt64(dokuz[j].Vbelv));
                                cmd.Parameters.AddWithValue("@Posnv", Convert.ToInt32(dokuz[j].Posnv));
                                cmd.Parameters.AddWithValue("@Vbeln", Convert.ToInt64(dokuz[j].Vbeln));
                                cmd.Parameters.AddWithValue("@Posnn", Convert.ToInt32(dokuz[j].Posnn));
                                cmd.Parameters.AddWithValue("@VbtypN", dokuz[j].VbtypN);
                                cmd.Parameters.AddWithValue("@Rfmng", dokuz[j].Rfmng);
                                cmd.Parameters.AddWithValue("@Meins", dokuz[j].Meins);
                                cmd.Parameters.AddWithValue("@Rfwrt", dokuz[j].Rfwrt);
                                cmd.Parameters.AddWithValue("@Waers", dokuz[j].Waers);
                                cmd.Parameters.AddWithValue("@VbtypV", dokuz[j].VbtypV);
                                cmd.Parameters.AddWithValue("@Plmin", dokuz[j].Plmin);
                                cmd.Parameters.AddWithValue("@Taqui", dokuz[j].Taqui);
                                cmd.Parameters.AddWithValue("@Erdat", Convert.ToDateTime(dokuz[j].Erdat + " " + dokuz[j].Erzet));
                                cmd.Parameters.AddWithValue("@Erzet", dokuz[j].Erzet);
                                cmd.Parameters.AddWithValue("@Matnr", dokuz[j].Matnr == string.Empty ? 0 : Convert.ToInt32(dokuz[j].Matnr));
                                cmd.Parameters.AddWithValue("@Bwart", dokuz[j].Bwart);
                                cmd.Parameters.AddWithValue("@Bdart", dokuz[j].Bdart);
                                cmd.Parameters.AddWithValue("@Plart", dokuz[j].Plart);
                                cmd.Parameters.AddWithValue("@Stufe", dokuz[j].Stufe);
                                cmd.Parameters.AddWithValue("@Lgnum", dokuz[j].Lgnum);
                                cmd.Parameters.AddWithValue("@Aedat", dokuz[j].Aedat.StartsWith("0000") ? Convert.ToDateTime("01.01.1900") : Convert.ToDateTime(dokuz[j].Aedat));
                                cmd.Parameters.AddWithValue("@Fktyp", dokuz[j].Fktyp);
                                cmd.Parameters.AddWithValue("@Brgew", dokuz[j].Brgew);
                                cmd.Parameters.AddWithValue("@Gewei", dokuz[j].Gewei);
                                cmd.Parameters.AddWithValue("@Volum", dokuz[j].Volum);
                                cmd.Parameters.AddWithValue("@Voleh", dokuz[j].Voleh);
                                cmd.Parameters.AddWithValue("@Fplnr", dokuz[j].Fplnr);
                                cmd.Parameters.AddWithValue("@Fpltr", dokuz[j].Fpltr);
                                cmd.Parameters.AddWithValue("@RfmngFlo", dokuz[j].RfmngFlo);
                                cmd.Parameters.AddWithValue("@RfmngFlt", dokuz[j].RfmngFlt);
                                cmd.Parameters.AddWithValue("@Vrkme", dokuz[j].Vrkme);
                                cmd.Parameters.AddWithValue("@Abges", dokuz[j].Abges);
                                cmd.Parameters.AddWithValue("@Sobkz", dokuz[j].Sobkz);
                                cmd.Parameters.AddWithValue("@Sonum", dokuz[j].Sonum);
                                cmd.Parameters.AddWithValue("@Kzbef", dokuz[j].Kzbef);
                                cmd.Parameters.AddWithValue("@Ntgew", dokuz[j].Ntgew);
                                cmd.Parameters.AddWithValue("@Logsys", dokuz[j].Logsys);
                                cmd.Parameters.AddWithValue("@Wbsta", dokuz[j].Wbsta);
                                cmd.Parameters.AddWithValue("@Cmeth", dokuz[j].Cmeth);
                                cmd.Parameters.AddWithValue("@Mjahr", dokuz[j].Mjahr);
                                #endregion
                                cmd.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                HataYaz(conn, "SAP_VBFA", Convert.ToInt64(dokuz[j].Vbelv).ToString(), Convert.ToInt32(dokuz[j].Posnv).ToString(), Convert.ToInt64(dokuz[j].Vbeln).ToString(), Convert.ToInt32(dokuz[j].Posnn).ToString(), dokuz[j].VbtypN, "(TESLIMAT) - " + ex.Message, cekilecektarih, cekilecektarih.AddDays(1));
                            }
                            conn.Close();
                        }
                    }
                    #endregion
                    EventLog.WriteEntry("Sultanlar Windows Service", "sap teslimat " + tarih + " " + saat + " yazma bitti (" + alti.Length.ToString() + " satır) " + DateTime.Now.ToLongTimeString(), EventLogEntryType.Information);
                    cekilecektarih = cekilecektarih.AddDays(1);
                }

                if (!hatavar)
                    MaxTarihYaz(conn, "SAP_Teslimat", bitistarih);
            }
            #endregion



            #region NAKILSIPARIS MALCIKIS FATURA
            if (nakilmalfatura)
            {
                DateTime maxtarih = MaxTarihGetir(conn, "SAP_NakilMalFatura");
                DateTime bitistarih = DateTime.Now;
                bool hatavar = false;

                selectsalestransportC.ZwebSelectSalesTransportService client4 = new selectsalestransportC.ZwebSelectSalesTransportService();
                client4.Timeout = 6000000;
                client4.Credentials = nc1;

                DateTime cekilecektarih = maxtarih;
                DateTime simdikitarih = DateTime.Now;
                while (Convert.ToDateTime(cekilecektarih.ToShortDateString()) <= Convert.ToDateTime(simdikitarih.ToShortDateString()))
                {
                    selectsalestransportC.Zwebs007[] yedi = null;
                    selectsalestransportC.Zwebs014[] ondort = null;
                    selectsalestransportC.Zwebs015[] onbes = null;
                    selectsalestransportC.Zwebs016[] onalti = null;
                    selectsalestransportC.Zwebs017[] onyedi = null;
                    selectsalestransportC.Zwebs018[] onsekiz = null;

                    string hata = string.Empty;
                    string tarih = "";
                    string saat = "00:00:00";
                    try
                    {
                        TarihSaat(maxtarih, cekilecektarih, out tarih, out saat);
                        
                        EventLog.WriteEntry("Sultanlar Windows Service", "sap fatura " + tarih + " " + saat + " istek basladi " + DateTime.Now.ToLongTimeString(), EventLogEntryType.Information);
                        onbes = client4.ZwebSelectSalesTransport(tarih, saat, out onalti, out onyedi, out onsekiz, out yedi, out ondort);
                        EventLog.WriteEntry("Sultanlar Windows Service", "sap fatura " + tarih + " " + saat + " istek geldi " + DateTime.Now.ToLongTimeString(), EventLogEntryType.Information);
                    }
                    catch (Exception ex)
                    {
                        hata = ex.Message;
                        //hatavar = true;
                        cekilecektarih = DateTime.Now; // while dan çıksın bir sonraki günü almasın max tarihi yenilemesin

                        EventLog.WriteEntry("Sultanlar Windows Service", "sap fatura " + tarih + " " + saat + " istekte hata olustu " + DateTime.Now.ToLongTimeString() + " " + hata, EventLogEntryType.Information);
                    }
                    finally
                    {
                        LogYaz(conn, "select sales transport", hata != string.Empty ? false : true, hata, Convert.ToDateTime(cekilecektarih.ToShortDateString() + " " + saat), Convert.ToDateTime(cekilecektarih.ToShortDateString()) == Convert.ToDateTime(simdikitarih.ToShortDateString()) ? DateTime.Now : Convert.ToDateTime(cekilecektarih.AddDays(1).ToShortDateString() + " 00:00:00"));
                    }

                    EventLog.WriteEntry("Sultanlar Windows Service", "sap fatura " + tarih + " " + saat + " yazma basladi (" + onyedi.Length.ToString() + " satır) " + DateTime.Now.ToLongTimeString(), EventLogEntryType.Information);
                    #region nakilsiparis

                    #region head
                    if (nakilsiparis && yedi != null)
                    {
                        for (int j = 0; j < yedi.Length; j++)
                        {
                            try
                            {
                                conn.Open();
                                SqlCommand cmd = new SqlCommand(
                                    "DELETE FROM [SAP_NAKILSIPARIS_BASLIK] WHERE Lgnum = @Lgnum AND Tanum = @Tanum " +
                                    "INSERT INTO [SAP_NAKILSIPARIS_BASLIK] (KAYIT_TARIHI,[Lgnum],[Tanum],[Qdatu],[Lgtor],[Koliadet]) VALUES (@KAYIT_TARIHI,@Lgnum,@Tanum,@Qdatu,@Lgtor,@Koliadet)", conn);
                                #region parameters
                                cmd.Parameters.AddWithValue("@KAYIT_TARIHI", DateTime.Now);
                                cmd.Parameters.AddWithValue("@Lgnum", yedi[j].Lgnum);
                                cmd.Parameters.AddWithValue("@Tanum", Convert.ToInt32(yedi[j].Tanum));
                                cmd.Parameters.AddWithValue("@Qdatu", yedi[j].Qdatu.StartsWith("0000") ? Convert.ToDateTime("01.01.1900") : Convert.ToDateTime(yedi[j].Qdatu));
                                cmd.Parameters.AddWithValue("@Lgtor", yedi[j].Lgtor);
                                cmd.Parameters.AddWithValue("@Koliadet", yedi[j].Koliadet);
                                #endregion
                                cmd.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                HataYaz(conn, "SAP_NAKILSIPARIS_BASLIK", yedi[j].Lgnum, yedi[j].Tanum, "", "", "", ex.Message, cekilecektarih, cekilecektarih.AddDays(1));
                            }
                            conn.Close();
                        }
                    }
                    #endregion

                    #region item
                    if (nakilsiparis && ondort != null)
                    {
                        for (int j = 0; j < ondort.Length; j++)
                        {
                            try
                            {
                                conn.Open();
                                SqlCommand cmd = new SqlCommand(
                                    "DELETE FROM [SAP_NAKILSIPARIS_DETAY] WHERE Lgnum = @Lgnum AND Tanum = @Tanum AND Tapos = @Tapos " +
                                    "INSERT INTO [SAP_NAKILSIPARIS_DETAY] (KAYIT_TARIHI,[Lgnum],[Tanum],[Tapos],[Matnr],[Maktx],[Werks],[Charg],[Pquit],[Qdatu],[Qzeit],[Qname],[Brgew],[Gewei],[Ablad],[Volum],[Voleh],[Vbeln],[Vsolm],[Vistm],[Vdifm],[Meins],[Meins Text],[Vlber],[Vlpla],[Nlber],[Nlpla]) VALUES (@KAYIT_TARIHI,@Lgnum,@Tanum,@Tapos,@Matnr,@Maktx,@Werks,@Charg,@Pquit,@Qdatu,@Qzeit,@Qname,@Brgew,@Gewei,@Ablad,@Volum,@Voleh,@Vbeln,@Vsolm,@Vistm,@Vdifm,@Meins,@MeinsText,@Vlber,@Vlpla,@Nlber,@Nlpla)", conn);
                                #region parameters
                                cmd.Parameters.AddWithValue("@KAYIT_TARIHI", DateTime.Now);
                                cmd.Parameters.AddWithValue("@Lgnum", ondort[j].Lgnum);
                                cmd.Parameters.AddWithValue("@Tanum", Convert.ToInt32(ondort[j].Tanum));
                                cmd.Parameters.AddWithValue("@Tapos", Convert.ToInt32(ondort[j].Tapos));
                                cmd.Parameters.AddWithValue("@Matnr", ondort[j].Matnr == string.Empty ? 0 : Convert.ToInt32(ondort[j].Matnr));
                                cmd.Parameters.AddWithValue("@Maktx", ondort[j].Maktx);
                                cmd.Parameters.AddWithValue("@Werks", ondort[j].Werks);
                                cmd.Parameters.AddWithValue("@Charg", ondort[j].Charg);
                                cmd.Parameters.AddWithValue("@Pquit", ondort[j].Pquit);
                                cmd.Parameters.AddWithValue("@Qdatu", ondort[j].Qdatu.StartsWith("0000") ? Convert.ToDateTime("01.01.1900") : Convert.ToDateTime(ondort[j].Qdatu));
                                cmd.Parameters.AddWithValue("@Qzeit", ondort[j].Qzeit);
                                cmd.Parameters.AddWithValue("@Qname", ondort[j].Qname);
                                cmd.Parameters.AddWithValue("@Brgew", ondort[j].Brgew);
                                cmd.Parameters.AddWithValue("@Gewei", ondort[j].Gewei);
                                cmd.Parameters.AddWithValue("@Ablad", ondort[j].Ablad);
                                cmd.Parameters.AddWithValue("@Volum", ondort[j].Volum);
                                cmd.Parameters.AddWithValue("@Voleh", ondort[j].Voleh);
                                cmd.Parameters.AddWithValue("@Vbeln", ondort[j].Vbeln == string.Empty ? 0 : Convert.ToInt64(ondort[j].Vbeln));
                                cmd.Parameters.AddWithValue("@Vsolm", ondort[j].Vsolm);
                                cmd.Parameters.AddWithValue("@Vistm", ondort[j].Vistm);
                                cmd.Parameters.AddWithValue("@Vdifm", ondort[j].Vdifm);
                                cmd.Parameters.AddWithValue("@Meins", ondort[j].Meins);
                                cmd.Parameters.AddWithValue("@MeinsText", ondort[j].MeinsText);
                                cmd.Parameters.AddWithValue("@Vlber", ondort[j].Vlber);
                                cmd.Parameters.AddWithValue("@Vlpla", ondort[j].Vlpla);
                                cmd.Parameters.AddWithValue("@Nlber", ondort[j].Nlber);
                                cmd.Parameters.AddWithValue("@Nlpla", ondort[j].Nlpla);
                                #endregion
                                cmd.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                HataYaz(conn, "SAP_NAKILSIPARIS_DETAY", ondort[j].Lgnum, ondort[j].Tanum, ondort[j].Tapos, "", "", ex.Message, cekilecektarih, cekilecektarih.AddDays(1));
                            }
                            conn.Close();
                        }
                    }
                    #endregion

                    #endregion

                    #region malcikis

                    #region head
                    if (malcikis && onbes != null)
                    {
                        for (int j = 0; j < onbes.Length; j++)
                        {
                            try
                            {
                                conn.Open();
                                SqlCommand cmd = new SqlCommand(
                                    "DELETE FROM [SAP_MALCIKIS_BASLIK] WHERE Mblnr = @Mblnr AND Mjahr = @Mjahr " +
                                    "INSERT INTO [SAP_MALCIKIS_BASLIK] (KAYIT_TARIHI,[Mblnr],[Mjahr],[Blart],[Ltext],[Vgart],[Ltext2],[Bldat],[Budat],[Le Vbeln]) VALUES (@KAYIT_TARIHI,@Mblnr,@Mjahr,@Blart,@Ltext,@Vgart,@Ltext2,@Bldat,@Budat,@LeVbeln)", conn);
                                #region parameters
                                cmd.Parameters.AddWithValue("@KAYIT_TARIHI", DateTime.Now);
                                cmd.Parameters.AddWithValue("@Mblnr", Convert.ToInt64(onbes[j].Mblnr));
                                cmd.Parameters.AddWithValue("@Mjahr", Convert.ToInt32(onbes[j].Mjahr));
                                cmd.Parameters.AddWithValue("@Blart", onbes[j].Blart);
                                cmd.Parameters.AddWithValue("@Ltext", onbes[j].Ltext);
                                cmd.Parameters.AddWithValue("@Vgart", onbes[j].Vgart);
                                cmd.Parameters.AddWithValue("@Ltext2", onbes[j].Ltext2);
                                cmd.Parameters.AddWithValue("@Bldat", onbes[j].Bldat.StartsWith("0000") ? Convert.ToDateTime("01.01.1900") : Convert.ToDateTime(onbes[j].Bldat));
                                cmd.Parameters.AddWithValue("@Budat", onbes[j].Budat.StartsWith("0000") ? Convert.ToDateTime("01.01.1900") : Convert.ToDateTime(onbes[j].Budat));
                                cmd.Parameters.AddWithValue("@LeVbeln", onbes[j].LeVbeln);
                                #endregion
                                cmd.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                HataYaz(conn, "SAP_MALCIKIS_BASLIK", onbes[j].Mblnr, onbes[j].Mjahr, "", "", "", ex.Message, cekilecektarih, cekilecektarih.AddDays(1));
                            }
                            conn.Close();
                        }
                    }
                    #endregion

                    #region item
                    if (malcikis && onalti != null)
                    {
                        for (int j = 0; j < onalti.Length; j++)
                        {
                            try
                            {
                                conn.Open();
                                SqlCommand cmd = new SqlCommand(
                                    "DELETE FROM [SAP_MALCIKIS_DETAY] WHERE Mblnr = @Mblnr AND Mjahr = @Mjahr AND Zeile = @Zeile " +
                                    "INSERT INTO [SAP_MALCIKIS_DETAY] (KAYIT_TARIHI,[Mblnr],[Mjahr],[Zeile],[Matnr],[Werks],[Lgort],[Charg],[Kunnr],[Menge],[Meins],[Meins Text],[Lgnum],[Lgtyp],[Lgpla],[Sjahr],[Smbln],[Smblp],[Vbeln Vl],[Posnr Vl],[Vbeln],[Posnr]) VALUES (@KAYIT_TARIHI,@Mblnr,@Mjahr,@Zeile,@Matnr,@Werks,@Lgort,@Charg,@Kunnr,@Menge,@Meins,@MeinsText,@Lgnum,@Lgtyp,@Lgpla,@Sjahr,@Smbln,@Smblp,@VbelnVl,@PosnrVl,@Vbeln,@Posnr)", conn);
                                #region parameters
                                cmd.Parameters.AddWithValue("@KAYIT_TARIHI", DateTime.Now);
                                cmd.Parameters.AddWithValue("@Mblnr", Convert.ToInt64(onalti[j].Mblnr));
                                cmd.Parameters.AddWithValue("@Mjahr", Convert.ToInt32(onalti[j].Mjahr));
                                cmd.Parameters.AddWithValue("@Zeile", Convert.ToInt32(onalti[j].Zeile));
                                cmd.Parameters.AddWithValue("@Matnr", onalti[j].Matnr == string.Empty ? 0 : Convert.ToInt32(onalti[j].Matnr));
                                cmd.Parameters.AddWithValue("@Werks", onalti[j].Werks);
                                cmd.Parameters.AddWithValue("@Lgort", onalti[j].Lgort);
                                cmd.Parameters.AddWithValue("@Charg", onalti[j].Charg);
                                cmd.Parameters.AddWithValue("@Kunnr", onalti[j].Kunnr.StartsWith("T") || onalti[j].Kunnr == "" ? 10 : Convert.ToInt32(onalti[j].Kunnr));
                                cmd.Parameters.AddWithValue("@Menge", onalti[j].Menge);
                                cmd.Parameters.AddWithValue("@Meins", onalti[j].Meins);
                                cmd.Parameters.AddWithValue("@MeinsText", onalti[j].MeinsText);
                                cmd.Parameters.AddWithValue("@Lgnum", onalti[j].Lgnum);
                                cmd.Parameters.AddWithValue("@Lgtyp", onalti[j].Lgtyp);
                                cmd.Parameters.AddWithValue("@Lgpla", onalti[j].Lgpla);
                                cmd.Parameters.AddWithValue("@Sjahr", onalti[j].Sjahr);
                                cmd.Parameters.AddWithValue("@Smbln", onalti[j].Smbln);
                                cmd.Parameters.AddWithValue("@Smblp", onalti[j].Smblp);
                                cmd.Parameters.AddWithValue("@VbelnVl", onalti[j].VbelnVl);
                                cmd.Parameters.AddWithValue("@PosnrVl", onalti[j].PosnrVl);
                                cmd.Parameters.AddWithValue("@Vbeln", onalti[j].Vbeln);
                                cmd.Parameters.AddWithValue("@Posnr", onalti[j].Posnr);
                                #endregion
                                cmd.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                HataYaz(conn, "SAP_MALCIKIS_DETAY", onalti[j].Mblnr, onalti[j].Mjahr, onalti[j].Zeile, "", "", ex.Message, cekilecektarih, cekilecektarih.AddDays(1));
                            }
                            conn.Close();
                        }
                    }
                    #endregion

                    #endregion

                    #region fatura

                    #region head
                    if (fatura && onyedi != null)
                    {
                        for (int j = 0; j < onyedi.Length; j++)
                        {
                            try
                            {
                                conn.Open();
                                SqlCommand cmd = new SqlCommand(
                                    "DELETE FROM [SAP_FATURA_BASLIK] WHERE Vbeln = @Vbeln " +
                                    "INSERT INTO [SAP_FATURA_BASLIK] (KAYIT_TARIHI,[Vbeln],[Fkart],[Vtext],[Fktyp],[Fktyp Text],[Vbtyp],[Vbtyp Text],[Waerk],[Vkorg],[Vtweg],[Kalsm],[Knumv],[Vsbed],[Fkdat],[Bukrs],[Belnr],[Gjahr],[Poper],[Ernam],[Erzet],[Erdat],[Kunrg],[Sfakn],[Fksto],[Xblnr],[Zuonr]) VALUES (@KAYIT_TARIHI,@Vbeln,@Fkart,@Vtext,@Fktyp,@FktypText,@Vbtyp,@VbtypText,@Waerk,@Vkorg,@Vtweg,@Kalsm,@Knumv,@Vsbed,@Fkdat,@Bukrs,@Belnr,@Gjahr,@Poper,@Ernam,@Erzet,@Erdat,@Kunrg,@Sfakn,@Fksto,@Xblnr,@Zuonr)", conn);
                                #region parameters
                                cmd.Parameters.AddWithValue("@KAYIT_TARIHI", DateTime.Now);
                                cmd.Parameters.AddWithValue("@Vbeln", Convert.ToInt64(onyedi[j].Vbeln));
                                cmd.Parameters.AddWithValue("@Fkart", onyedi[j].Fkart);
                                cmd.Parameters.AddWithValue("@Vtext", onyedi[j].Vtext);
                                cmd.Parameters.AddWithValue("@Fktyp", onyedi[j].Fktyp);
                                cmd.Parameters.AddWithValue("@FktypText", onyedi[j].FktypText);
                                cmd.Parameters.AddWithValue("@Vbtyp", onyedi[j].Vbtyp);
                                cmd.Parameters.AddWithValue("@VbtypText", onyedi[j].VbtypText);
                                cmd.Parameters.AddWithValue("@Waerk", onyedi[j].Waerk);
                                cmd.Parameters.AddWithValue("@Vkorg", onyedi[j].Vkorg);
                                cmd.Parameters.AddWithValue("@Vtweg", onyedi[j].Vtweg);
                                cmd.Parameters.AddWithValue("@Kalsm", onyedi[j].Kalsm);
                                cmd.Parameters.AddWithValue("@Knumv", onyedi[j].Knumv.StartsWith("T") || onyedi[j].Knumv == "" ? 10 : Convert.ToInt32(onyedi[j].Knumv));
                                cmd.Parameters.AddWithValue("@Vsbed", onyedi[j].Vsbed);
                                cmd.Parameters.AddWithValue("@Fkdat", onyedi[j].Fkdat.StartsWith("0000") ? Convert.ToDateTime("01.01.1900") : Convert.ToDateTime(onyedi[j].Fkdat));
                                cmd.Parameters.AddWithValue("@Bukrs", onyedi[j].Bukrs);
                                cmd.Parameters.AddWithValue("@Belnr", onyedi[j].Belnr);
                                cmd.Parameters.AddWithValue("@Gjahr", onyedi[j].Gjahr);
                                cmd.Parameters.AddWithValue("@Poper", onyedi[j].Poper);
                                cmd.Parameters.AddWithValue("@Ernam", onyedi[j].Ernam);
                                cmd.Parameters.AddWithValue("@Erzet", onyedi[j].Erzet);
                                cmd.Parameters.AddWithValue("@Erdat", Convert.ToDateTime(onyedi[j].Erdat + " " + onyedi[j].Erzet));
                                cmd.Parameters.AddWithValue("@Kunrg", onyedi[j].Kunrg);
                                cmd.Parameters.AddWithValue("@Sfakn", onyedi[j].Sfakn);
                                cmd.Parameters.AddWithValue("@Fksto", onyedi[j].Fksto);
                                cmd.Parameters.AddWithValue("@Xblnr", onyedi[j].Xblnr);
                                cmd.Parameters.AddWithValue("@Zuonr", onyedi[j].Zuonr);
                                #endregion
                                cmd.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                HataYaz(conn, "SAP_FATURA_BASLIK", onyedi[j].Vbeln, "", "", "", "", ex.Message, cekilecektarih, cekilecektarih.AddDays(1));
                            }
                            conn.Close();
                        }
                    }
                    #endregion

                    #region item
                    if (fatura && onsekiz != null)
                    {
                        for (int j = 0; j < onsekiz.Length; j++)
                        {
                            try
                            {
                                conn.Open();
                                SqlCommand cmd = new SqlCommand(
                                    "DELETE FROM [SAP_FATURA_DETAY] WHERE Vbeln = @Vbeln AND Posnr = @Posnr " +
                                    "INSERT INTO [SAP_FATURA_DETAY] (KAYIT_TARIHI,[Vbeln],[Posnr],[Fkimg],[Vrkme],[Vrkme Text],[Ntgew],[Brgew],[Gewei],[Volum],[Voleh],[Vgbel],[Vgpos],[Vgtyp],[Aubel],[Aupos],[Auref],[Matnr],[Arktx],[Charg],[Netwr],[Brtwr],[Mwskz],[Sgtxt],[Kzwi1],[Kzwi4],[Lgort]) VALUES (@KAYIT_TARIHI,@Vbeln,@Posnr,@Fkimg,@Vrkme,@VrkmeText,@Ntgew,@Brgew,@Gewei,@Volum,@Voleh,@Vgbel,@Vgpos,@Vgtyp,@Aubel,@Aupos,@Auref,@Matnr,@Arktx,@Charg,@Netwr,@Brtwr,@Mwskz,@Sgtxt,@Kzwi1,@Kzwi4,@Lgort)", conn);
                                #region parameters
                                cmd.Parameters.AddWithValue("@KAYIT_TARIHI", DateTime.Now);
                                cmd.Parameters.AddWithValue("@Vbeln", Convert.ToInt64(onsekiz[j].Vbeln));
                                cmd.Parameters.AddWithValue("@Posnr", Convert.ToInt32(onsekiz[j].Posnr));
                                cmd.Parameters.AddWithValue("@Fkimg", onsekiz[j].Fkimg);
                                cmd.Parameters.AddWithValue("@Vrkme", onsekiz[j].Vrkme);
                                cmd.Parameters.AddWithValue("@VrkmeText", onsekiz[j].VrkmeText);
                                cmd.Parameters.AddWithValue("@Ntgew", onsekiz[j].Ntgew);
                                cmd.Parameters.AddWithValue("@Brgew", onsekiz[j].Brgew);
                                cmd.Parameters.AddWithValue("@Gewei", onsekiz[j].Gewei);
                                cmd.Parameters.AddWithValue("@Volum", onsekiz[j].Volum);
                                cmd.Parameters.AddWithValue("@Voleh", onsekiz[j].Voleh);
                                cmd.Parameters.AddWithValue("@Vgbel", onsekiz[j].Vgbel);
                                cmd.Parameters.AddWithValue("@Vgpos", onsekiz[j].Vgpos);
                                cmd.Parameters.AddWithValue("@Vgtyp", onsekiz[j].Vgtyp);
                                cmd.Parameters.AddWithValue("@Aubel", onsekiz[j].Aubel);
                                cmd.Parameters.AddWithValue("@Aupos", onsekiz[j].Aupos);
                                cmd.Parameters.AddWithValue("@Auref", onsekiz[j].Auref);
                                cmd.Parameters.AddWithValue("@Matnr", onsekiz[j].Matnr == string.Empty ? 0 : Convert.ToInt32(onsekiz[j].Matnr));
                                cmd.Parameters.AddWithValue("@Arktx", onsekiz[j].Arktx);
                                cmd.Parameters.AddWithValue("@Charg", onsekiz[j].Charg);
                                cmd.Parameters.AddWithValue("@Netwr", onsekiz[j].Netwr);
                                cmd.Parameters.AddWithValue("@Brtwr", onsekiz[j].Brtwr);
                                cmd.Parameters.AddWithValue("@Mwskz", onsekiz[j].Mwskz);
                                cmd.Parameters.AddWithValue("@Sgtxt", onsekiz[j].Sgtxt);
                                cmd.Parameters.AddWithValue("@Kzwi1", onsekiz[j].Kzwi1);
                                cmd.Parameters.AddWithValue("@Kzwi4", onsekiz[j].Kzwi4);
                                cmd.Parameters.AddWithValue("@Lgort", onsekiz[j].Lgort);
                                #endregion
                                cmd.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                HataYaz(conn, "SAP_FATURA_DETAY", onsekiz[j].Vbeln, onsekiz[j].Posnr, "", "", "", ex.Message, cekilecektarih, cekilecektarih.AddDays(1));
                            }
                            conn.Close();
                        }
                    }
                    #endregion

                    #endregion
                    EventLog.WriteEntry("Sultanlar Windows Service", "sap fatura " + tarih + " " + saat + " yazma bitti (" + onyedi.Length.ToString() + " satır) " + DateTime.Now.ToLongTimeString(), EventLogEntryType.Information);
                    cekilecektarih = cekilecektarih.AddDays(1);
                }

                if (!hatavar)
                    MaxTarihYaz(conn, "SAP_NakilMalFatura", bitistarih);
            }
            #endregion



            #region KOLIETIKET
            if (kolietiket)
            {
                DateTime maxtarih = MaxTarihGetir(conn, "SAP_KoliEtiket");
                DateTime bitistarih = DateTime.Now;
                bool hatavar = false;

                selectkolietiketC.ZwebSelectKoliEtiketService client5 = new selectkolietiketC.ZwebSelectKoliEtiketService();
                client5.Timeout = 6000000;
                client5.Credentials = nc1;

                DateTime cekilecektarih = maxtarih;
                DateTime simdikitarih = DateTime.Now;
                while (Convert.ToDateTime(cekilecektarih.ToShortDateString()) <= Convert.ToDateTime(simdikitarih.ToShortDateString()))
                {
                    selectkolietiketC.Zwebs019[] ondokuz = null;

                    string hata = string.Empty;
                    string tarih = "";
                    string saat = "00:00:00";
                    try
                    {
                        TarihSaat(maxtarih, cekilecektarih, out tarih, out saat);
                        ondokuz = client5.ZwebSelectKoliEtiket(tarih, saat);
                    }
                    catch (Exception ex)
                    {
                        hata = ex.Message;
                        hatavar = true;
                        cekilecektarih = DateTime.Now; // while dan çıksın bir sonraki günü almasın max tarihi yenilemesin
                    }
                    finally
                    {
                        LogYaz(conn, "select koli etiket", hata != string.Empty ? false : true, hata, Convert.ToDateTime(cekilecektarih.ToShortDateString() + " " + saat), Convert.ToDateTime(cekilecektarih.ToShortDateString()) == Convert.ToDateTime(simdikitarih.ToShortDateString()) ? DateTime.Now : Convert.ToDateTime(cekilecektarih.AddDays(1).ToShortDateString() + " 00:00:00"));
                    }

                    if (ondokuz != null)
                    {
                        for (int j = 0; j < ondokuz.Length; j++)
                        {
                            try
                            {
                                conn.Open();
                                SqlCommand cmd = new SqlCommand(
                                    "DELETE FROM [SAP_KOLIETIKET] WHERE Kolietiketno = @Kolietiketno " +
                                    "INSERT INTO [SAP_KOLIETIKET] (KAYIT_TARIHI,[Kolietiketno],[Kolisira],[Koliadet],[Vbeln],[Erdat],[Erzet],[Ernam],[Deleted]) VALUES (@KAYIT_TARIHI,@Kolietiketno,@Kolisira,@Koliadet,@Vbeln,@Erdat,@Erzet,@Ernam,@Deleted)", conn);
                                #region parameters
                                cmd.Parameters.AddWithValue("@KAYIT_TARIHI", DateTime.Now);
                                cmd.Parameters.AddWithValue("@Kolietiketno", ondokuz[j].Kolietiketno);
                                cmd.Parameters.AddWithValue("@Kolisira", ondokuz[j].Kolisira);
                                cmd.Parameters.AddWithValue("@Koliadet", ondokuz[j].Koliadet);
                                cmd.Parameters.AddWithValue("@Vbeln", Convert.ToInt64(ondokuz[j].Vbeln));
                                cmd.Parameters.AddWithValue("@Erdat", Convert.ToDateTime(ondokuz[j].Erdat + " " + ondokuz[j].Erzet));
                                cmd.Parameters.AddWithValue("@Erzet", ondokuz[j].Erzet);
                                cmd.Parameters.AddWithValue("@Ernam", ondokuz[j].Ernam);
                                cmd.Parameters.AddWithValue("@Deleted", ondokuz[j].Deleted);
                                #endregion
                                cmd.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                HataYaz(conn, "SAP_KOLIETIKET", ondokuz[j].Kolietiketno, "", "", "", "", ex.Message, cekilecektarih, cekilecektarih.AddDays(1));
                            }
                            conn.Close();
                        }
                    }

                    cekilecektarih = cekilecektarih.AddDays(1);
                }

                if (!hatavar)
                    MaxTarihYaz(conn, "SAP_KoliEtiket", bitistarih);
            }
            #endregion



            #region ACCOUNTING
            if (accounting)
            {
                DateTime maxtarih = MaxTarihGetir(conn, "SAP_Accounting");
                DateTime bitistarih = DateTime.Now;
                bool hatavar = false;

                selectaccountingC.ZwebSelectAccountingService client6 = new selectaccountingC.ZwebSelectAccountingService();
                //for (int i = maxtarih.Day; i <= DateTime.Now.Day; i++)
                //{
                selectaccountingC.Zwebs020[] yirmi = null;
                client6.Timeout = 6000000;
                client6.Credentials = nc1;

                string hata = string.Empty;
                try
                {
                    yirmi = client6.ZwebSelectAccounting(
                        maxtarih.Year.ToString() + (maxtarih.Month.ToString().Length == 1 ? "0" + maxtarih.Month.ToString() : maxtarih.Month.ToString()) + (maxtarih.Day.ToString().Length == 1 ? "0" + maxtarih.Day.ToString() : maxtarih.Day.ToString()),
                        DateTime.Now.AddDays(1).Year.ToString() + (DateTime.Now.AddDays(1).Month.ToString().Length == 1 ? "0" + DateTime.Now.AddDays(1).Month.ToString() : DateTime.Now.AddDays(1).Month.ToString()) + (DateTime.Now.AddDays(1).Day.ToString().Length == 1 ? "0" + DateTime.Now.AddDays(1).Day.ToString() : DateTime.Now.AddDays(1).Day.ToString()));
                }
                catch (Exception ex)
                {
                    hata = ex.Message;
                    //hatavar = true;
                }
                finally
                {
                    LogYaz(conn, "select accounting", hata != string.Empty ? false : true, hata, maxtarih, DateTime.Now);
                }

                if (yirmi != null)
                {
                    for (int j = 0; j < yirmi.Length; j++)
                    {
                        try
                        {
                            conn.Open();
                            SqlCommand cmd = new SqlCommand(
                                "DELETE FROM [SAP_ACCOUNTING] WHERE Bukrs = @Bukrs AND Belnr = @Belnr AND Gjahr = @Gjahr " +
                                "INSERT INTO [SAP_ACCOUNTING] (KAYIT_TARIHI,[Bukrs],[Belnr],[Gjahr],[Blart],[Bldat],[Budat],[Monat],[Cpudt],[Cputm],[Aedat],[Upddt],[Wwert],[Usnam],[Xblnr],[Stblg],[Stjah],[Bktxt],[Waers],[Awtyp],[Awkey],[Zzikincibelgeno],[Zzislemkd],[Zzreferans]) VALUES (@KAYIT_TARIHI,@Bukrs,@Belnr,@Gjahr,@Blart,@Bldat,@Budat,@Monat,@Cpudt,@Cputm,@Aedat,@Upddt,@Wwert,@Usnam,@Xblnr,@Stblg,@Stjah,@Bktxt,@Waers,@Awtyp,@Awkey,@Zzikincibelgeno,@Zzislemkd,@Zzreferans)", conn);
                            #region parameters
                            cmd.Parameters.AddWithValue("@KAYIT_TARIHI", DateTime.Now);
                            cmd.Parameters.AddWithValue("@Bukrs", yirmi[j].Bukrs);
                            cmd.Parameters.AddWithValue("@Belnr", yirmi[j].Belnr);
                            cmd.Parameters.AddWithValue("@Gjahr", Convert.ToInt32(yirmi[j].Gjahr));
                            cmd.Parameters.AddWithValue("@Blart", yirmi[j].Blart);
                            cmd.Parameters.AddWithValue("@Bldat", yirmi[j].Bldat.StartsWith("0000") ? Convert.ToDateTime("01.01.1900") : Convert.ToDateTime(yirmi[j].Bldat));
                            cmd.Parameters.AddWithValue("@Budat", yirmi[j].Budat.StartsWith("0000") ? Convert.ToDateTime("01.01.1900") : Convert.ToDateTime(yirmi[j].Budat));
                            cmd.Parameters.AddWithValue("@Monat", yirmi[j].Monat);
                            cmd.Parameters.AddWithValue("@Cpudt", yirmi[j].Cpudt.StartsWith("0000") ? Convert.ToDateTime("01.01.1900") : Convert.ToDateTime(yirmi[j].Cpudt + " " + yirmi[j].Cputm));
                            cmd.Parameters.AddWithValue("@Cputm", yirmi[j].Cputm);
                            cmd.Parameters.AddWithValue("@Aedat", yirmi[j].Aedat.StartsWith("0000") ? Convert.ToDateTime("01.01.1900") : Convert.ToDateTime(yirmi[j].Aedat));
                            cmd.Parameters.AddWithValue("@Upddt", yirmi[j].Upddt.StartsWith("0000") ? Convert.ToDateTime("01.01.1900") : Convert.ToDateTime(yirmi[j].Upddt));
                            cmd.Parameters.AddWithValue("@Wwert", yirmi[j].Wwert.StartsWith("0000") ? Convert.ToDateTime("01.01.1900") : Convert.ToDateTime(yirmi[j].Wwert));
                            cmd.Parameters.AddWithValue("@Usnam", yirmi[j].Usnam);
                            cmd.Parameters.AddWithValue("@Xblnr", yirmi[j].Xblnr);
                            cmd.Parameters.AddWithValue("@Stblg", yirmi[j].Stblg);
                            cmd.Parameters.AddWithValue("@Stjah", yirmi[j].Stjah);
                            cmd.Parameters.AddWithValue("@Bktxt", yirmi[j].Bktxt);
                            cmd.Parameters.AddWithValue("@Waers", yirmi[j].Waers);
                            cmd.Parameters.AddWithValue("@Awtyp", yirmi[j].Awtyp);
                            cmd.Parameters.AddWithValue("@Awkey", yirmi[j].Awkey);
                            cmd.Parameters.AddWithValue("@Zzikincibelgeno", yirmi[j].Zzikincibelgeno);
                            cmd.Parameters.AddWithValue("@Zzislemkd", yirmi[j].Zzislemkd);
                            cmd.Parameters.AddWithValue("@Zzreferans", yirmi[j].Zzreferans);
                            #endregion
                            cmd.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            hatavar = true;
                            HataYaz(conn, "SAP_ACCOUNTING", yirmi[j].Bukrs, yirmi[j].Belnr, yirmi[j].Gjahr, "", "", ex.Message, maxtarih, DateTime.Now);
                        }
                        conn.Close();
                    }
                }

                if (!hatavar)
                    MaxTarihYaz(conn, "SAP_Accounting", bitistarih);
                //}
            }
            #endregion
        }


        void GetSAP()
        {
            SqlConnection conn = new SqlConnection("Server=.; Database=KurumsalWebSAP; User Id=sa; Password=sdl580g5p9+-; Trusted_Connection=False;");
            NetworkCredential nc1 = new NetworkCredential("ngunay", "123456");

            bool vbfa = false;
            bool siparis = false;
            bool teslimat = false;
            bool nakilmalfatura = true;
            bool nakilsiparis = true;
            bool malcikis = true;
            bool fatura = true;
            bool kolietiket = false;
            bool accounting = false;
            bool efatura = false;
            bool ekstre = DateTime.Now.Hour == 12;



            #region VBFA
            if (vbfa)
            {
                DateTime maxtarih = MaxTarihGetir(conn, "SAP_Vbfa");
                DateTime bitistarih = DateTime.Now;
                bool hatavar = false;

                selectsalesvbfaC.ZwebSelectSalesVbfaService client = new selectsalesvbfaC.ZwebSelectSalesVbfaService();
                client.Timeout = 6000000;
                client.Credentials = nc1;

                DateTime cekilecektarih = maxtarih;
                DateTime simdikitarih = DateTime.Now;
                EventLog.WriteEntry("Sultanlar Windows Service", "vbfa bas " + DateTime.Now.ToLongTimeString(), EventLogEntryType.Information);
                while (Convert.ToDateTime(cekilecektarih.ToShortDateString()) <= Convert.ToDateTime(simdikitarih.ToShortDateString()))
                {
                    selectsalesvbfaC.Zwebs009[] dokuz = null;

                    string hata = string.Empty;
                    string tarih = "";
                    string saat = "00:00:00";
                    try
                    {
                        EventLog.WriteEntry("Sultanlar Windows Service", "vbfa 1 gun bas " + tarih + saat + DateTime.Now.ToLongTimeString(), EventLogEntryType.Information);
                        TarihSaat(maxtarih, cekilecektarih, out tarih, out saat);
                        dokuz = client.ZwebSelectSalesVbfa(tarih, saat);
                        EventLog.WriteEntry("Sultanlar Windows Service", "vbfa 1 gun bit " + tarih + saat + DateTime.Now.ToLongTimeString(), EventLogEntryType.Information);
                    }
                    catch (Exception ex)
                    {
                        hata = ex.Message;
                        hatavar = true;
                        cekilecektarih = DateTime.Now; // while dan çıksın bir sonraki günü almasın max tarihi yenilemesin
                    }
                    finally
                    {
                        LogYaz(conn, "select sales vbfa", hata != string.Empty ? false : true, hata, Convert.ToDateTime(cekilecektarih.ToShortDateString() + " " + saat), Convert.ToDateTime(cekilecektarih.ToShortDateString()) == Convert.ToDateTime(simdikitarih.ToShortDateString()) ? DateTime.Now : Convert.ToDateTime(cekilecektarih.AddDays(1).ToShortDateString() + " 00:00:00"));
                    }

                    if (dokuz != null)
                    {
                        for (int j = 0; j < dokuz.Length; j++)
                        {
                            try
                            {
                                conn.Open();
                                SqlCommand cmd = new SqlCommand(
                                    "DELETE FROM [SAP_VBFA] WHERE Vbelv = @Vbelv AND Posnv = @Posnv AND Vbeln = @Vbeln AND Posnn = @Posnn AND [Vbtyp N] = @VbtypN " +
                                    "INSERT INTO [SAP_VBFA] (KAYIT_TARIHI,[Vbelv],[Posnv],[Vbeln],[Posnn],[Vbtyp N],[Rfmng],[Meins],[Rfwrt],[Waers],[Vbtyp V],[Plmin],[Taqui],[Erdat],[Erzet],[Matnr],[Bwart],[Bdart],[Plart],[Stufe],[Lgnum],[Aedat],[Fktyp],[Brgew],[Gewei],[Volum],[Voleh],[Fplnr],[Fpltr],[Rfmng Flo],[Rfmng Flt],[Vrkme],[Abges],[Sobkz],[Sonum],[Kzbef],[Ntgew],[Logsys],[Wbsta],[Cmeth],[Mjahr]) VALUES (@KAYIT_TARIHI,@Vbelv,@Posnv,@Vbeln,@Posnn,@VbtypN,@Rfmng,@Meins,@Rfwrt,@Waers,@VbtypV,@Plmin,@Taqui,@Erdat,@Erzet,@Matnr,@Bwart,@Bdart,@Plart,@Stufe,@Lgnum,@Aedat,@Fktyp,@Brgew,@Gewei,@Volum,@Voleh,@Fplnr,@Fpltr,@RfmngFlo,@RfmngFlt,@Vrkme,@Abges,@Sobkz,@Sonum,@Kzbef,@Ntgew,@Logsys,@Wbsta,@Cmeth,@Mjahr)", conn);
                                #region parameters
                                cmd.Parameters.AddWithValue("@KAYIT_TARIHI", DateTime.Now);
                                cmd.Parameters.AddWithValue("@Vbelv", Convert.ToInt64(dokuz[j].Vbelv));
                                cmd.Parameters.AddWithValue("@Posnv", Convert.ToInt32(dokuz[j].Posnv));
                                cmd.Parameters.AddWithValue("@Vbeln", Convert.ToInt64(dokuz[j].Vbeln));
                                cmd.Parameters.AddWithValue("@Posnn", Convert.ToInt32(dokuz[j].Posnn));
                                cmd.Parameters.AddWithValue("@VbtypN", dokuz[j].VbtypN);
                                cmd.Parameters.AddWithValue("@Rfmng", dokuz[j].Rfmng);
                                cmd.Parameters.AddWithValue("@Meins", dokuz[j].Meins);
                                cmd.Parameters.AddWithValue("@Rfwrt", dokuz[j].Rfwrt);
                                cmd.Parameters.AddWithValue("@Waers", dokuz[j].Waers);
                                cmd.Parameters.AddWithValue("@VbtypV", dokuz[j].VbtypV);
                                cmd.Parameters.AddWithValue("@Plmin", dokuz[j].Plmin);
                                cmd.Parameters.AddWithValue("@Taqui", dokuz[j].Taqui);
                                cmd.Parameters.AddWithValue("@Erdat", Convert.ToDateTime(dokuz[j].Erdat + " " + dokuz[j].Erzet));
                                cmd.Parameters.AddWithValue("@Erzet", dokuz[j].Erzet);
                                cmd.Parameters.AddWithValue("@Matnr", dokuz[j].Matnr == string.Empty ? 0 : Convert.ToInt32(dokuz[j].Matnr));
                                cmd.Parameters.AddWithValue("@Bwart", dokuz[j].Bwart);
                                cmd.Parameters.AddWithValue("@Bdart", dokuz[j].Bdart);
                                cmd.Parameters.AddWithValue("@Plart", dokuz[j].Plart);
                                cmd.Parameters.AddWithValue("@Stufe", dokuz[j].Stufe);
                                cmd.Parameters.AddWithValue("@Lgnum", dokuz[j].Lgnum);
                                cmd.Parameters.AddWithValue("@Aedat", dokuz[j].Aedat.StartsWith("0000") ? Convert.ToDateTime("01.01.1900") : Convert.ToDateTime(dokuz[j].Aedat));
                                cmd.Parameters.AddWithValue("@Fktyp", dokuz[j].Fktyp);
                                cmd.Parameters.AddWithValue("@Brgew", dokuz[j].Brgew);
                                cmd.Parameters.AddWithValue("@Gewei", dokuz[j].Gewei);
                                cmd.Parameters.AddWithValue("@Volum", dokuz[j].Volum);
                                cmd.Parameters.AddWithValue("@Voleh", dokuz[j].Voleh);
                                cmd.Parameters.AddWithValue("@Fplnr", dokuz[j].Fplnr);
                                cmd.Parameters.AddWithValue("@Fpltr", dokuz[j].Fpltr);
                                cmd.Parameters.AddWithValue("@RfmngFlo", dokuz[j].RfmngFlo);
                                cmd.Parameters.AddWithValue("@RfmngFlt", dokuz[j].RfmngFlt);
                                cmd.Parameters.AddWithValue("@Vrkme", dokuz[j].Vrkme);
                                cmd.Parameters.AddWithValue("@Abges", dokuz[j].Abges);
                                cmd.Parameters.AddWithValue("@Sobkz", dokuz[j].Sobkz);
                                cmd.Parameters.AddWithValue("@Sonum", dokuz[j].Sonum);
                                cmd.Parameters.AddWithValue("@Kzbef", dokuz[j].Kzbef);
                                cmd.Parameters.AddWithValue("@Ntgew", dokuz[j].Ntgew);
                                cmd.Parameters.AddWithValue("@Logsys", dokuz[j].Logsys);
                                cmd.Parameters.AddWithValue("@Wbsta", dokuz[j].Wbsta);
                                cmd.Parameters.AddWithValue("@Cmeth", dokuz[j].Cmeth);
                                cmd.Parameters.AddWithValue("@Mjahr", dokuz[j].Mjahr);
                                #endregion
                                cmd.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                HataYaz(conn, "SAP_VBFA", Convert.ToInt64(dokuz[j].Vbelv).ToString(), Convert.ToInt32(dokuz[j].Posnv).ToString(), Convert.ToInt64(dokuz[j].Vbeln).ToString(), Convert.ToInt32(dokuz[j].Posnn).ToString(), dokuz[j].VbtypN, ex.Message, cekilecektarih, cekilecektarih.AddDays(1));
                            }
                            conn.Close();
                        }
                    }

                    cekilecektarih = cekilecektarih.AddDays(1);
                }
                EventLog.WriteEntry("Sultanlar Windows Service", "vbfa bit " + DateTime.Now.ToLongTimeString(), EventLogEntryType.Information);

                if (!hatavar)
                    MaxTarihYaz(conn, "SAP_Vbfa", bitistarih);
            }
            #endregion



            #region SIPARIS
            if (siparis)
            {
                DateTime maxtarih = MaxTarihGetir(conn, "SAP_Siparis");
                DateTime bitistarih = DateTime.Now;
                bool hatavar = false;

                selectsalesorderC.ZwebSelectSalesOrderService client2 = new selectsalesorderC.ZwebSelectSalesOrderService();
                client2.Timeout = 6000000;
                client2.Credentials = nc1;

                DateTime cekilecektarih = maxtarih;
                DateTime simdikitarih = DateTime.Now;
                while (Convert.ToDateTime(cekilecektarih.ToShortDateString()) <= Convert.ToDateTime(simdikitarih.ToShortDateString()))
                {
                    selectsalesorderC.Zwebs009[] dokuz = null; // vbfa
                    selectsalesorderC.Zwebs005[] bes = null; // head
                    selectsalesorderC.Zwebs012[] oniki = null; // item
                    selectsalesorderC.Zwebs021[] yirmibir = null; // logdel

                    string hata = string.Empty;
                    string tarih = "";
                    string saat = "00:00:00";
                    try
                    {
                        TarihSaat(maxtarih, cekilecektarih, out tarih, out saat);
                        yirmibir = client2.ZwebSelectSalesOrder(tarih, "", saat, out bes, out oniki, out dokuz);
                    }
                    catch (Exception ex)
                    {
                        hata = ex.Message;
                        hatavar = true;
                        cekilecektarih = DateTime.Now; // while dan çıksın bir sonraki günü almasın max tarihi yenilemesin
                    }
                    finally
                    {
                        LogYaz(conn, "select sales order", hata != string.Empty ? false : true, hata, Convert.ToDateTime(cekilecektarih.ToShortDateString() + " " + saat), Convert.ToDateTime(cekilecektarih.ToShortDateString()) == Convert.ToDateTime(simdikitarih.ToShortDateString()) ? DateTime.Now : Convert.ToDateTime(cekilecektarih.AddDays(1).ToShortDateString() + " 00:00:00"));
                    }

                    #region logdel
                    if (yirmibir != null)
                    {
                        for (int j = 0; j < yirmibir.Length; j++)
                        {
                            try
                            {
                                conn.Open();
                                SqlCommand cmd = new SqlCommand("DELETE FROM [SAP_SIPARIS_BASLIK] WHERE Vbeln = @Vbeln DELETE FROM [SAP_SIPARIS_DETAY] WHERE Vbeln = @Vbeln DELETE FROM [SAP_VBFA] WHERE Vbelv = @Vbeln", conn);
                                cmd.Parameters.AddWithValue("@Vbeln", Convert.ToInt64(yirmibir[j].Vbeln));
                                cmd.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                HataYaz(conn, "SAP_SIPARIS_BASLIK", Convert.ToInt64(yirmibir[j].Vbeln).ToString(), "", "", "", "", "(LOGDEL) - " + ex.Message, cekilecektarih, cekilecektarih.AddDays(1));
                            }
                            conn.Close();
                        }
                    }
                    #endregion

                    #region head
                    if (bes != null)
                    {
                        for (int j = 0; j < bes.Length; j++)
                        {
                            try
                            {
                                conn.Open();
                                SqlCommand cmd = new SqlCommand(
                                    "DELETE FROM [SAP_SIPARIS_BASLIK] WHERE Vbeln = @Vbeln " +
                                    "DELETE FROM [SAP_SIPARIS_DETAY] WHERE Vbeln = @Vbeln " +
                                    "DELETE FROM [SAP_VBFA] WHERE Vbeln = @Vbeln " +
                                    "INSERT INTO [SAP_SIPARIS_BASLIK] (KAYIT_TARIHI,[Vbeln],[Auart],[Bezei],[Audat],[Erdat],[Erzet],[Ernam],[Netwr],[Waerk],[Vkorg],[Vtext],[Vtweg],[Bzirk],[Bztxt],[Bstnk],[Kunnr],[Aedat],[Spart],[Vtext2],[Vkgrp],[Vkbur],[Kdgrp],[Ktext],[Name1],[Name2],[Name3],[Name4],[Name Text],[Name Co],[City1],[City2],[Street],[Region],[Sort1],[Deflt Comm],[Comm Text],[Tel Number],[Fax Number],[Stcd1],[Stcd2],[Post Code1],[Smtp Addr],[Pltyp],[Ptext],[OKunnr],[OStcd1],[OStcd2],[OName1],[ODeflt Comm],[OSmtp Addr],[OComm Text],[Yetkili],[Sip Aciklama],[Netpr],[Knumv],[Yetkili Kod],[Yetkili Ad],[Yetkili Tel],[Satsor Kod],[Satsor Ad],[Satsor Tel],[Sipalan Kod],[Sipalan Ad],[Sipalan Tel],[NamaSatici],[NamaSaticiAd],Vdatu,Bstkd) VALUES (@KAYIT_TARIHI,@Vbeln,@Auart,@Bezei,@Audat,@Erdat,@Erzet,@Ernam,@Netwr,@Waerk,@Vkorg,@Vtext,@Vtweg,@Bzirk,@Bztxt,@Bstnk,@Kunnr,@Aedat,@Spart,@Vtext2,@Vkgrp,@Vkbur,@Kdgrp,@Ktext,@Name1,@Name2,@Name3,@Name4,@NameText,@NameCo,@City1,@City2,@Street,@Region,@Sort1,@DefltComm,@CommText,@TelNumber,@FaxNumber,@Stcd1,@Stcd2,@PostCode1,@SmtpAddr,@Pltyp,@Ptext,@OKunnr,@OStcd1,@OStcd2,@OName1,@ODefltComm,@OSmtpAddr,@OCommText,@Yetkili,@SipAciklama,@Netpr,@Knumv,@YetkiliKod,@YetkiliAd,@YetkiliTel,@SatsorKod,@SatsorAd,@SatsorTel,@SipalanKod,@SipalanAd,@SipalanTel,@NamaSatici,@NamaSaticiAd,@Vdatu,@Bstkd)", conn);
                                #region parameters
                                cmd.Parameters.AddWithValue("@KAYIT_TARIHI", DateTime.Now);
                                cmd.Parameters.AddWithValue("@Vbeln", Convert.ToInt64(bes[j].Vbeln));
                                cmd.Parameters.AddWithValue("@Auart", bes[j].Auart);
                                cmd.Parameters.AddWithValue("@Bezei", bes[j].Bezei);
                                cmd.Parameters.AddWithValue("@Audat", Convert.ToDateTime(bes[j].Audat));
                                cmd.Parameters.AddWithValue("@Erdat", Convert.ToDateTime(bes[j].Erdat + " " + bes[j].Erzet));
                                cmd.Parameters.AddWithValue("@Erzet", bes[j].Erzet);
                                cmd.Parameters.AddWithValue("@Ernam", bes[j].Ernam);
                                cmd.Parameters.AddWithValue("@Netwr", bes[j].Netwr);
                                cmd.Parameters.AddWithValue("@Waerk", bes[j].Waerk);
                                cmd.Parameters.AddWithValue("@Vkorg", bes[j].Vkorg);
                                cmd.Parameters.AddWithValue("@Vtext", bes[j].Vtext);
                                cmd.Parameters.AddWithValue("@Vtweg", bes[j].Vtweg);
                                cmd.Parameters.AddWithValue("@Bzirk", bes[j].Bzirk);
                                cmd.Parameters.AddWithValue("@Bztxt", bes[j].Bztxt);
                                cmd.Parameters.AddWithValue("@Bstnk", bes[j].Bstnk);
                                cmd.Parameters.AddWithValue("@Kunnr", bes[j].Kunnr.StartsWith("T") || bes[j].Kunnr == "" ? 10 : Convert.ToInt32(bes[j].Kunnr));
                                cmd.Parameters.AddWithValue("@Aedat", bes[j].Aedat.StartsWith("0000") ? Convert.ToDateTime(bes[j].Audat) : Convert.ToDateTime(bes[j].Aedat));
                                cmd.Parameters.AddWithValue("@Spart", bes[j].Spart);
                                cmd.Parameters.AddWithValue("@Vtext2", bes[j].Vtext2);
                                cmd.Parameters.AddWithValue("@Vkgrp", bes[j].Vkgrp);
                                cmd.Parameters.AddWithValue("@Vkbur", bes[j].Vkbur);
                                cmd.Parameters.AddWithValue("@Kdgrp", bes[j].Kdgrp);
                                cmd.Parameters.AddWithValue("@Ktext", bes[j].Ktext);
                                cmd.Parameters.AddWithValue("@Name1", bes[j].Name1);
                                cmd.Parameters.AddWithValue("@Name2", bes[j].Name2);
                                cmd.Parameters.AddWithValue("@Name3", bes[j].Name3);
                                cmd.Parameters.AddWithValue("@Name4", bes[j].Name4);
                                cmd.Parameters.AddWithValue("@NameText", bes[j].NameText);
                                cmd.Parameters.AddWithValue("@NameCo", bes[j].NameCo);
                                cmd.Parameters.AddWithValue("@City1", bes[j].City1);
                                cmd.Parameters.AddWithValue("@City2", bes[j].City2);
                                cmd.Parameters.AddWithValue("@Street", bes[j].Street);
                                cmd.Parameters.AddWithValue("@Region", bes[j].Region);
                                cmd.Parameters.AddWithValue("@Sort1", bes[j].Sort1);
                                cmd.Parameters.AddWithValue("@DefltComm", bes[j].DefltComm);
                                cmd.Parameters.AddWithValue("@CommText", bes[j].CommText);
                                cmd.Parameters.AddWithValue("@TelNumber", bes[j].TelNumber);
                                cmd.Parameters.AddWithValue("@FaxNumber", bes[j].FaxNumber);
                                cmd.Parameters.AddWithValue("@Stcd1", bes[j].Stcd1);
                                cmd.Parameters.AddWithValue("@Stcd2", bes[j].Stcd2);
                                cmd.Parameters.AddWithValue("@PostCode1", bes[j].PostCode1);
                                cmd.Parameters.AddWithValue("@SmtpAddr", bes[j].SmtpAddr);
                                cmd.Parameters.AddWithValue("@Pltyp", bes[j].Pltyp);
                                cmd.Parameters.AddWithValue("@Ptext", bes[j].Ptext);
                                cmd.Parameters.AddWithValue("@OKunnr", bes[j].OKunnr.StartsWith("T") || bes[j].OKunnr == "" ? 10 : Convert.ToInt32(bes[j].OKunnr));
                                cmd.Parameters.AddWithValue("@OStcd1", bes[j].OStcd1);
                                cmd.Parameters.AddWithValue("@OStcd2", bes[j].OStcd2);
                                cmd.Parameters.AddWithValue("@OName1", bes[j].OName1);
                                cmd.Parameters.AddWithValue("@ODefltComm", bes[j].ODefltComm);
                                cmd.Parameters.AddWithValue("@OSmtpAddr", bes[j].OSmtpAddr);
                                cmd.Parameters.AddWithValue("@OCommText", bes[j].OCommText);
                                cmd.Parameters.AddWithValue("@Yetkili", bes[j].Yetkili);
                                cmd.Parameters.AddWithValue("@SipAciklama", bes[j].SipAciklama);
                                cmd.Parameters.AddWithValue("@Netpr", bes[j].Netpr);
                                cmd.Parameters.AddWithValue("@Knumv", bes[j].Knumv.StartsWith("T") || bes[j].Knumv == "" ? 10 : Convert.ToInt32(bes[j].Knumv));
                                cmd.Parameters.AddWithValue("@YetkiliKod", Convert.ToInt32(bes[j].YetkiliKod));
                                cmd.Parameters.AddWithValue("@YetkiliAd", bes[j].YetkiliAd);
                                cmd.Parameters.AddWithValue("@YetkiliTel", bes[j].YetkiliTel);
                                cmd.Parameters.AddWithValue("@SatsorKod", Convert.ToInt32(bes[j].SatsorKod));
                                cmd.Parameters.AddWithValue("@SatsorAd", bes[j].SatsorAd);
                                cmd.Parameters.AddWithValue("@SatsorTel", bes[j].SatsorTel);
                                cmd.Parameters.AddWithValue("@SipalanKod", Convert.ToInt32(bes[j].SipalanKod));
                                cmd.Parameters.AddWithValue("@SipalanAd", bes[j].SipalanAd);
                                cmd.Parameters.AddWithValue("@SipalanTel", bes[j].SipalanTel);
                                cmd.Parameters.AddWithValue("@NamaSatici", bes[j].NamaSatici);
                                cmd.Parameters.AddWithValue("@NamaSaticiAd", bes[j].NamaSaticiAd);
                                cmd.Parameters.AddWithValue("@Vdatu", bes[j].Vdatu);
                                cmd.Parameters.AddWithValue("@Bstkd", bes[j].Bstkd);
                                #endregion
                                cmd.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                HataYaz(conn, "SAP_SIPARIS_BASLIK", Convert.ToInt64(bes[j].Vbeln).ToString(), "", "", "", "", ex.Message, cekilecektarih, cekilecektarih.AddDays(1));
                            }
                            conn.Close();
                        }
                    }
                    #endregion

                    #region item
                    if (oniki != null)
                    {
                        for (int j = 0; j < oniki.Length; j++)
                        {
                            try
                            {
                                conn.Open();
                                SqlCommand cmd = new SqlCommand(
                                    "DELETE FROM [SAP_SIPARIS_DETAY] WHERE Vbeln = @Vbeln AND Posnr = @Posnr " +
                                    "INSERT INTO [SAP_SIPARIS_DETAY] (KAYIT_TARIHI,[Vbeln],[Posnr],[Matnr],[Arktx],[Pltyp],[Ptext],[Zterm],[Netdt],[Matkl],[Wgbez],[Spart],[Vtext2],[Ean11],[Kwmeng],[Vrkme],[Vrkme Text],[Kwmeng2],[Vrkme2],[Vrkme2Text],[Ean112],[Yuz1],[Yuz2],[Yuz3],[Yuz4],[Yuz5],[Yuz6],[Yuz7],[Yuz8],[Yuz9],[Yuz10],[Brtpr],[Netpr],[Netwr],[Kzwi1],[Kdvoran],[Mwsbp],[Waerk],[Brgew],[Ntgew],[Gewei],[Volum],[Voleh],[Ksc1],[Ksc2],[Ksc3],[Ksc4],[Ksc5],[Ksc6],[Ksc7],[Ksc8],[Ksc9],[Ksc10],[Zzpirbz],[Zzpirgt],[Abgru],[Bezei_ab]) VALUES (@KAYIT_TARIHI,@Vbeln,@Posnr,@Matnr,@Arktx,@Pltyp,@Ptext,@Zterm,@Netdt,@Matkl,@Wgbez,@Spart,@Vtext2,@Ean11,@Kwmeng,@Vrkme,@VrkmeText,@Kwmeng2,@Vrkme2,@Vrkme2Text,@Ean112,@Yuz1,@Yuz2,@Yuz3,@Yuz4,@Yuz5,@Yuz6,@Yuz7,@Yuz8,@Yuz9,@Yuz10,@Brtpr,@Netpr,@Netwr,@Kzwi1,@Kdvoran,@Mwsbp,@Waerk,@Brgew,@Ntgew,@Gewei,@Volum,@Voleh,@Ksc1,@Ksc2,@Ksc3,@Ksc4,@Ksc5,@Ksc6,@Ksc7,@Ksc8,@Ksc9,@Ksc10,@Zzpirbz,@Zzpirgt,@Abgru,@Bezei_ab)", conn);
                                #region parameters
                                cmd.Parameters.AddWithValue("@KAYIT_TARIHI", DateTime.Now);
                                cmd.Parameters.AddWithValue("@Vbeln", Convert.ToInt64(oniki[j].Vbeln));
                                cmd.Parameters.AddWithValue("@Posnr", Convert.ToInt32(oniki[j].Posnr));
                                cmd.Parameters.AddWithValue("@Matnr", oniki[j].Matnr == string.Empty ? 0 : Convert.ToInt32(oniki[j].Matnr));
                                cmd.Parameters.AddWithValue("@Arktx", oniki[j].Arktx);
                                cmd.Parameters.AddWithValue("@Pltyp", oniki[j].Pltyp);
                                cmd.Parameters.AddWithValue("@Ptext", oniki[j].Ptext);
                                cmd.Parameters.AddWithValue("@Zterm", oniki[j].Zterm == string.Empty ? 0 : Convert.ToInt32(oniki[j].Zterm));
                                cmd.Parameters.AddWithValue("@Netdt", oniki[j].Netdt.StartsWith("0000") ? Convert.ToDateTime("01.01.1900") : Convert.ToDateTime(oniki[j].Netdt));
                                cmd.Parameters.AddWithValue("@Matkl", oniki[j].Matkl);
                                cmd.Parameters.AddWithValue("@Wgbez", oniki[j].Wgbez);
                                cmd.Parameters.AddWithValue("@Spart", oniki[j].Spart);
                                cmd.Parameters.AddWithValue("@Vtext2", oniki[j].Vtext2);
                                cmd.Parameters.AddWithValue("@Ean11", oniki[j].Ean11);
                                cmd.Parameters.AddWithValue("@Kwmeng", oniki[j].Kwmeng);
                                cmd.Parameters.AddWithValue("@Vrkme", oniki[j].Vrkme);
                                cmd.Parameters.AddWithValue("@VrkmeText", oniki[j].VrkmeText);
                                cmd.Parameters.AddWithValue("@Kwmeng2", oniki[j].Kwmeng2);
                                cmd.Parameters.AddWithValue("@Vrkme2", oniki[j].Vrkme2);
                                cmd.Parameters.AddWithValue("@Vrkme2Text", oniki[j].Vrkme2Text);
                                cmd.Parameters.AddWithValue("@Ean112", oniki[j].Ean112);
                                cmd.Parameters.AddWithValue("@Yuz1", oniki[j].Yuz1);
                                cmd.Parameters.AddWithValue("@Yuz2", oniki[j].Yuz2);
                                cmd.Parameters.AddWithValue("@Yuz3", oniki[j].Yuz3);
                                cmd.Parameters.AddWithValue("@Yuz4", oniki[j].Yuz4);
                                cmd.Parameters.AddWithValue("@Yuz5", oniki[j].Yuz5);
                                cmd.Parameters.AddWithValue("@Yuz6", oniki[j].Yuz6);
                                cmd.Parameters.AddWithValue("@Yuz7", oniki[j].Yuz7);
                                cmd.Parameters.AddWithValue("@Yuz8", oniki[j].Yuz8);
                                cmd.Parameters.AddWithValue("@Yuz9", oniki[j].Yuz9);
                                cmd.Parameters.AddWithValue("@Yuz10", oniki[j].Yuz10);
                                cmd.Parameters.AddWithValue("@Brtpr", oniki[j].Brtpr);
                                cmd.Parameters.AddWithValue("@Netpr", oniki[j].Netpr);
                                cmd.Parameters.AddWithValue("@Netwr", oniki[j].Netwr);
                                cmd.Parameters.AddWithValue("@Kzwi1", oniki[j].Kzwi1);
                                cmd.Parameters.AddWithValue("@Kdvoran", Convert.ToInt32(oniki[j].Kdvoran));
                                cmd.Parameters.AddWithValue("@Mwsbp", oniki[j].Mwsbp);
                                cmd.Parameters.AddWithValue("@Waerk", oniki[j].Waerk);
                                cmd.Parameters.AddWithValue("@Brgew", oniki[j].Brgew);
                                cmd.Parameters.AddWithValue("@Ntgew", oniki[j].Ntgew);
                                cmd.Parameters.AddWithValue("@Gewei", oniki[j].Gewei);
                                cmd.Parameters.AddWithValue("@Volum", oniki[j].Volum);
                                cmd.Parameters.AddWithValue("@Voleh", oniki[j].Voleh);
                                cmd.Parameters.AddWithValue("@Ksc1", oniki[j].Ksc1);
                                cmd.Parameters.AddWithValue("@Ksc2", oniki[j].Ksc2);
                                cmd.Parameters.AddWithValue("@Ksc3", oniki[j].Ksc3);
                                cmd.Parameters.AddWithValue("@Ksc4", oniki[j].Ksc4);
                                cmd.Parameters.AddWithValue("@Ksc5", oniki[j].Ksc5);
                                cmd.Parameters.AddWithValue("@Ksc6", oniki[j].Ksc6);
                                cmd.Parameters.AddWithValue("@Ksc7", oniki[j].Ksc7);
                                cmd.Parameters.AddWithValue("@Ksc8", oniki[j].Ksc8);
                                cmd.Parameters.AddWithValue("@Ksc9", oniki[j].Ksc9);
                                cmd.Parameters.AddWithValue("@Ksc10", oniki[j].Ksc10);
                                cmd.Parameters.AddWithValue("@Zzpirbz", oniki[j].Zzpirbz);
                                cmd.Parameters.AddWithValue("@Zzpirgt", oniki[j].Zzpirgt);
                                cmd.Parameters.AddWithValue("@Abgru", oniki[j].Abgru);
                                cmd.Parameters.AddWithValue("@Bezei_ab", oniki[j].BezeiAb);
                                #endregion
                                cmd.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                HataYaz(conn, "SAP_SIPARIS_DETAY", Convert.ToInt64(oniki[j].Vbeln).ToString(), Convert.ToInt32(oniki[j].Posnr).ToString(), "", "", "", ex.Message, cekilecektarih, cekilecektarih.AddDays(1));
                            }
                            conn.Close();
                        }
                    }
                    #endregion

                    #region vbfa
                    if (dokuz != null)
                    {
                        for (int j = 0; j < dokuz.Length; j++)
                        {
                            try
                            {
                                conn.Open();
                                SqlCommand cmd = new SqlCommand("sp_SAP_VBFA_InsertUpdate", conn);
                                cmd.CommandType = CommandType.StoredProcedure;
                                #region parameters
                                cmd.Parameters.AddWithValue("@KAYIT_TARIHI", DateTime.Now);
                                cmd.Parameters.AddWithValue("@Vbelv", Convert.ToInt64(dokuz[j].Vbelv));
                                cmd.Parameters.AddWithValue("@Posnv", Convert.ToInt32(dokuz[j].Posnv));
                                cmd.Parameters.AddWithValue("@Vbeln", Convert.ToInt64(dokuz[j].Vbeln));
                                cmd.Parameters.AddWithValue("@Posnn", Convert.ToInt32(dokuz[j].Posnn));
                                cmd.Parameters.AddWithValue("@VbtypN", dokuz[j].VbtypN);
                                cmd.Parameters.AddWithValue("@Rfmng", dokuz[j].Rfmng);
                                cmd.Parameters.AddWithValue("@Meins", dokuz[j].Meins);
                                cmd.Parameters.AddWithValue("@Rfwrt", dokuz[j].Rfwrt);
                                cmd.Parameters.AddWithValue("@Waers", dokuz[j].Waers);
                                cmd.Parameters.AddWithValue("@VbtypV", dokuz[j].VbtypV);
                                cmd.Parameters.AddWithValue("@Plmin", dokuz[j].Plmin);
                                cmd.Parameters.AddWithValue("@Taqui", dokuz[j].Taqui);
                                cmd.Parameters.AddWithValue("@Erdat", Convert.ToDateTime(dokuz[j].Erdat + " " + dokuz[j].Erzet));
                                cmd.Parameters.AddWithValue("@Erzet", dokuz[j].Erzet);
                                cmd.Parameters.AddWithValue("@Matnr", dokuz[j].Matnr == string.Empty ? 0 : Convert.ToInt32(dokuz[j].Matnr));
                                cmd.Parameters.AddWithValue("@Bwart", dokuz[j].Bwart);
                                cmd.Parameters.AddWithValue("@Bdart", dokuz[j].Bdart);
                                cmd.Parameters.AddWithValue("@Plart", dokuz[j].Plart);
                                cmd.Parameters.AddWithValue("@Stufe", dokuz[j].Stufe);
                                cmd.Parameters.AddWithValue("@Lgnum", dokuz[j].Lgnum);
                                cmd.Parameters.AddWithValue("@Aedat", dokuz[j].Aedat.StartsWith("0000") ? Convert.ToDateTime("01.01.1900") : Convert.ToDateTime(dokuz[j].Aedat));
                                cmd.Parameters.AddWithValue("@Fktyp", dokuz[j].Fktyp);
                                cmd.Parameters.AddWithValue("@Brgew", dokuz[j].Brgew);
                                cmd.Parameters.AddWithValue("@Gewei", dokuz[j].Gewei);
                                cmd.Parameters.AddWithValue("@Volum", dokuz[j].Volum);
                                cmd.Parameters.AddWithValue("@Voleh", dokuz[j].Voleh);
                                cmd.Parameters.AddWithValue("@Fplnr", dokuz[j].Fplnr);
                                cmd.Parameters.AddWithValue("@Fpltr", dokuz[j].Fpltr);
                                cmd.Parameters.AddWithValue("@RfmngFlo", dokuz[j].RfmngFlo);
                                cmd.Parameters.AddWithValue("@RfmngFlt", dokuz[j].RfmngFlt);
                                cmd.Parameters.AddWithValue("@Vrkme", dokuz[j].Vrkme);
                                cmd.Parameters.AddWithValue("@Abges", dokuz[j].Abges);
                                cmd.Parameters.AddWithValue("@Sobkz", dokuz[j].Sobkz);
                                cmd.Parameters.AddWithValue("@Sonum", dokuz[j].Sonum);
                                cmd.Parameters.AddWithValue("@Kzbef", dokuz[j].Kzbef);
                                cmd.Parameters.AddWithValue("@Ntgew", dokuz[j].Ntgew);
                                cmd.Parameters.AddWithValue("@Logsys", dokuz[j].Logsys);
                                cmd.Parameters.AddWithValue("@Wbsta", dokuz[j].Wbsta);
                                cmd.Parameters.AddWithValue("@Cmeth", dokuz[j].Cmeth);
                                cmd.Parameters.AddWithValue("@Mjahr", dokuz[j].Mjahr);
                                #endregion
                                cmd.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                HataYaz(conn, "SAP_VBFA", Convert.ToInt64(dokuz[j].Vbelv).ToString(), Convert.ToInt32(dokuz[j].Posnv).ToString(), Convert.ToInt64(dokuz[j].Vbeln).ToString(), Convert.ToInt32(dokuz[j].Posnn).ToString(), dokuz[j].VbtypN, "(SIPARIS) - " + ex.Message, cekilecektarih, cekilecektarih.AddDays(1));
                            }
                            conn.Close();
                        }
                    }
                    #endregion

                    cekilecektarih = cekilecektarih.AddDays(1);
                }

                if (!hatavar)
                    MaxTarihYaz(conn, "SAP_Siparis", bitistarih);
            }
            #endregion



            #region TESLIMAT
            if (teslimat)
            {
                DateTime maxtarih = MaxTarihGetir(conn, "SAP_Teslimat");
                DateTime bitistarih = DateTime.Now;
                bool hatavar = false;

                selectsalesdeliveryC.ZwebSelectSalesDeliveryService client3 = new selectsalesdeliveryC.ZwebSelectSalesDeliveryService();
                client3.Timeout = 6000000;
                client3.Credentials = nc1;

                DateTime cekilecektarih = maxtarih;
                DateTime simdikitarih = DateTime.Now;
                while (Convert.ToDateTime(cekilecektarih.ToShortDateString()) <= Convert.ToDateTime(simdikitarih.ToShortDateString()))
                {
                    selectsalesdeliveryC.Zwebs009[] dokuz = null; // vbfa
                    selectsalesdeliveryC.Zwebs006[] alti = null; // head
                    selectsalesdeliveryC.Zwebs013[] onuc = null; // item
                    selectsalesdeliveryC.Zwebs021[] yirmibir = null; // logdel

                    string hata = string.Empty;
                    string tarih = "";
                    string saat = "00:00:00";
                    try
                    {
                        TarihSaat(maxtarih, cekilecektarih, out tarih, out saat);
                        alti = client3.ZwebSelectSalesDelivery(tarih, "", saat, out onuc, out yirmibir, out dokuz);
                    }
                    catch (Exception ex)
                    {
                        hata = ex.Message;
                        hatavar = true;
                        cekilecektarih = DateTime.Now; // while dan çıksın bir sonraki günü almasın max tarihi yenilemesin
                    }
                    finally
                    {
                        LogYaz(conn, "select sales delivery", hata != string.Empty ? false : true, hata, Convert.ToDateTime(cekilecektarih.ToShortDateString() + " " + saat), Convert.ToDateTime(cekilecektarih.ToShortDateString()) == Convert.ToDateTime(simdikitarih.ToShortDateString()) ? DateTime.Now : Convert.ToDateTime(cekilecektarih.AddDays(1).ToShortDateString() + " 00:00:00"));
                    }

                    #region logdel
                    if (yirmibir != null)
                    {
                        for (int j = 0; j < yirmibir.Length; j++)
                        {
                            try
                            {
                                conn.Open();
                                SqlCommand cmd = new SqlCommand("DELETE FROM [SAP_TESLIMAT_BASLIK] WHERE Vbeln = @Vbeln DELETE FROM [SAP_TESLIMAT_DETAY] WHERE Vbeln = @Vbeln DELETE FROM [SAP_VBFA] WHERE Vbelv = @Vbeln DELETE FROM [SAP_VBFA] WHERE Vbeln = @Vbeln", conn);
                                cmd.Parameters.AddWithValue("@Vbeln", Convert.ToInt64(yirmibir[j].Vbeln));
                                cmd.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                HataYaz(conn, "SAP_TESLIMAT_BASLIK", Convert.ToInt64(yirmibir[j].Vbeln).ToString(), "", "", "", "", "(LOGDEL) - " + ex.Message, cekilecektarih, cekilecektarih.AddDays(1));
                            }
                            conn.Close();
                        }
                    }
                    #endregion

                    #region head
                    if (alti != null)
                    {
                        for (int j = 0; j < alti.Length; j++)
                        {
                            try
                            {
                                conn.Open();
                                SqlCommand cmd = new SqlCommand(
                                    "DELETE FROM [SAP_TESLIMAT_BASLIK] WHERE Vbeln = @Vbeln " +
                                    "DELETE FROM [SAP_TESLIMAT_DETAY] WHERE Vbeln = @Vbeln " +
                                    "DELETE FROM [SAP_VBFA] WHERE Vbeln = @Vbeln " +
                                    "DELETE FROM [SAP_VBFA] WHERE Vbelv = @Vbeln " +
                                    "INSERT INTO [SAP_TESLIMAT_BASLIK] (KAYIT_TARIHI,[Lfart],[Vtext],[Vbeln],[Ernam],[Erzet],[Erdat],[Sevkalani],[Sevkyeri],[Teslimat Aciklama],[Volum],[Btgew],[Voleh],[Gewei],[Lifex]) VALUES (@KAYIT_TARIHI,@Lfart,@Vtext,@Vbeln,@Ernam,@Erzet,@Erdat,@Sevkalani,@Sevkyeri,@TeslimatAciklama,@Volum,@Btgew,@Voleh,@Gewei,@Lifex)", conn);
                                #region parameters
                                cmd.Parameters.AddWithValue("@KAYIT_TARIHI", DateTime.Now);
                                cmd.Parameters.AddWithValue("@Lfart", alti[j].Lfart);
                                cmd.Parameters.AddWithValue("@Vtext", alti[j].Vtext);
                                cmd.Parameters.AddWithValue("@Vbeln", Convert.ToInt64(alti[j].Vbeln));
                                cmd.Parameters.AddWithValue("@Ernam", alti[j].Ernam);
                                cmd.Parameters.AddWithValue("@Erzet", alti[j].Erzet);
                                cmd.Parameters.AddWithValue("@Erdat", Convert.ToDateTime(alti[j].Erdat + " " + alti[j].Erzet));
                                cmd.Parameters.AddWithValue("@Sevkalani", alti[j].Sevkalani);
                                cmd.Parameters.AddWithValue("@Sevkyeri", alti[j].Sevkyeri);
                                cmd.Parameters.AddWithValue("@TeslimatAciklama", alti[j].TeslimatAciklama);
                                cmd.Parameters.AddWithValue("@Volum", alti[j].Volum);
                                cmd.Parameters.AddWithValue("@Btgew", alti[j].Btgew);
                                cmd.Parameters.AddWithValue("@Voleh", alti[j].Voleh);
                                cmd.Parameters.AddWithValue("@Gewei", alti[j].Gewei);
                                cmd.Parameters.AddWithValue("@Lifex", alti[j].Lifex);
                                #endregion
                                cmd.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                HataYaz(conn, "SAP_TESLIMAT_BASLIK", Convert.ToInt64(alti[j].Vbeln).ToString(), "", "", "", "", ex.Message, cekilecektarih, cekilecektarih.AddDays(1));
                            }
                            conn.Close();
                        }
                    }
                    #endregion

                    #region item
                    if (onuc != null)
                    {
                        for (int j = 0; j < onuc.Length; j++)
                        {
                            try
                            {
                                conn.Open();
                                SqlCommand cmd = new SqlCommand(
                                    "DELETE FROM [SAP_TESLIMAT_DETAY] WHERE Vbeln = @Vbeln AND Posnr = @Posnr " +
                                    "INSERT INTO [SAP_TESLIMAT_DETAY] (KAYIT_TARIHI,[Vbeln],[Posnr],[Matnr],[Ernam],[Erzet],[Erdat],[Matkl],[Werks],[Lgort],[Charg],[Lfimg],[Meins],[Meins Text],[Ntgew],[Brgew],[Gewei],[Volum],[Voleh],Hsdat) VALUES (@KAYIT_TARIHI,@Vbeln,@Posnr,@Matnr,@Ernam,@Erzet,@Erdat,@Matkl,@Werks,@Lgort,@Charg,@Lfimg,@Meins,@MeinsText,@Ntgew,@Brgew,@Gewei,@Volum,@Voleh,@Hsdat)", conn);
                                #region parameters
                                cmd.Parameters.AddWithValue("@KAYIT_TARIHI", DateTime.Now);
                                cmd.Parameters.AddWithValue("@Vbeln", Convert.ToInt64(onuc[j].Vbeln));
                                cmd.Parameters.AddWithValue("@Posnr", Convert.ToInt32(onuc[j].Posnr));
                                cmd.Parameters.AddWithValue("@Matnr", onuc[j].Matnr == string.Empty ? 0 : Convert.ToInt32(onuc[j].Matnr));
                                cmd.Parameters.AddWithValue("@Ernam", onuc[j].Ernam);
                                cmd.Parameters.AddWithValue("@Erzet", onuc[j].Erzet);
                                cmd.Parameters.AddWithValue("@Erdat", Convert.ToDateTime(onuc[j].Erdat + " " + onuc[j].Erzet));
                                cmd.Parameters.AddWithValue("@Matkl", onuc[j].Matkl);
                                cmd.Parameters.AddWithValue("@Werks", onuc[j].Werks);
                                cmd.Parameters.AddWithValue("@Lgort", onuc[j].Lgort);
                                cmd.Parameters.AddWithValue("@Charg", onuc[j].Charg);
                                cmd.Parameters.AddWithValue("@Lfimg", onuc[j].Lfimg);
                                cmd.Parameters.AddWithValue("@Meins", onuc[j].Meins);
                                cmd.Parameters.AddWithValue("@MeinsText", onuc[j].MeinsText);
                                cmd.Parameters.AddWithValue("@Ntgew", onuc[j].Ntgew);
                                cmd.Parameters.AddWithValue("@Brgew", onuc[j].Brgew);
                                cmd.Parameters.AddWithValue("@Gewei", onuc[j].Gewei);
                                cmd.Parameters.AddWithValue("@Volum", onuc[j].Volum);
                                cmd.Parameters.AddWithValue("@Voleh", onuc[j].Voleh);
                                cmd.Parameters.AddWithValue("@Hsdat", (onuc[j].Hsdat != "0000-00-00" ? (Convert.ToDateTime(onuc[j].Hsdat) < Convert.ToDateTime("01.01.1900") ? Convert.ToDateTime("01.01.1900") : Convert.ToDateTime(onuc[j].Hsdat)) : Convert.ToDateTime("01.01.1900")));
                                #endregion
                                cmd.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                HataYaz(conn, "SAP_TESLIMAT_DETAY", Convert.ToInt64(onuc[j].Vbeln).ToString(), Convert.ToInt32(onuc[j].Posnr).ToString(), "", "", "", ex.Message, cekilecektarih, cekilecektarih.AddDays(1));
                            }
                            conn.Close();
                        }
                    }
                    #endregion

                    #region vbfa
                    if (dokuz != null)
                    {
                        for (int j = 0; j < dokuz.Length; j++)
                        {
                            try
                            {
                                conn.Open();
                                SqlCommand cmd = new SqlCommand("sp_SAP_VBFA_InsertUpdate", conn);
                                cmd.CommandType = CommandType.StoredProcedure;
                                #region parameters
                                cmd.Parameters.AddWithValue("@KAYIT_TARIHI", DateTime.Now);
                                cmd.Parameters.AddWithValue("@Vbelv", Convert.ToInt64(dokuz[j].Vbelv));
                                cmd.Parameters.AddWithValue("@Posnv", Convert.ToInt32(dokuz[j].Posnv));
                                cmd.Parameters.AddWithValue("@Vbeln", Convert.ToInt64(dokuz[j].Vbeln));
                                cmd.Parameters.AddWithValue("@Posnn", Convert.ToInt32(dokuz[j].Posnn));
                                cmd.Parameters.AddWithValue("@VbtypN", dokuz[j].VbtypN);
                                cmd.Parameters.AddWithValue("@Rfmng", dokuz[j].Rfmng);
                                cmd.Parameters.AddWithValue("@Meins", dokuz[j].Meins);
                                cmd.Parameters.AddWithValue("@Rfwrt", dokuz[j].Rfwrt);
                                cmd.Parameters.AddWithValue("@Waers", dokuz[j].Waers);
                                cmd.Parameters.AddWithValue("@VbtypV", dokuz[j].VbtypV);
                                cmd.Parameters.AddWithValue("@Plmin", dokuz[j].Plmin);
                                cmd.Parameters.AddWithValue("@Taqui", dokuz[j].Taqui);
                                cmd.Parameters.AddWithValue("@Erdat", Convert.ToDateTime(dokuz[j].Erdat + " " + dokuz[j].Erzet));
                                cmd.Parameters.AddWithValue("@Erzet", dokuz[j].Erzet);
                                cmd.Parameters.AddWithValue("@Matnr", dokuz[j].Matnr == string.Empty ? 0 : Convert.ToInt32(dokuz[j].Matnr));
                                cmd.Parameters.AddWithValue("@Bwart", dokuz[j].Bwart);
                                cmd.Parameters.AddWithValue("@Bdart", dokuz[j].Bdart);
                                cmd.Parameters.AddWithValue("@Plart", dokuz[j].Plart);
                                cmd.Parameters.AddWithValue("@Stufe", dokuz[j].Stufe);
                                cmd.Parameters.AddWithValue("@Lgnum", dokuz[j].Lgnum);
                                cmd.Parameters.AddWithValue("@Aedat", dokuz[j].Aedat.StartsWith("0000") ? Convert.ToDateTime("01.01.1900") : Convert.ToDateTime(dokuz[j].Aedat));
                                cmd.Parameters.AddWithValue("@Fktyp", dokuz[j].Fktyp);
                                cmd.Parameters.AddWithValue("@Brgew", dokuz[j].Brgew);
                                cmd.Parameters.AddWithValue("@Gewei", dokuz[j].Gewei);
                                cmd.Parameters.AddWithValue("@Volum", dokuz[j].Volum);
                                cmd.Parameters.AddWithValue("@Voleh", dokuz[j].Voleh);
                                cmd.Parameters.AddWithValue("@Fplnr", dokuz[j].Fplnr);
                                cmd.Parameters.AddWithValue("@Fpltr", dokuz[j].Fpltr);
                                cmd.Parameters.AddWithValue("@RfmngFlo", dokuz[j].RfmngFlo);
                                cmd.Parameters.AddWithValue("@RfmngFlt", dokuz[j].RfmngFlt);
                                cmd.Parameters.AddWithValue("@Vrkme", dokuz[j].Vrkme);
                                cmd.Parameters.AddWithValue("@Abges", dokuz[j].Abges);
                                cmd.Parameters.AddWithValue("@Sobkz", dokuz[j].Sobkz);
                                cmd.Parameters.AddWithValue("@Sonum", dokuz[j].Sonum);
                                cmd.Parameters.AddWithValue("@Kzbef", dokuz[j].Kzbef);
                                cmd.Parameters.AddWithValue("@Ntgew", dokuz[j].Ntgew);
                                cmd.Parameters.AddWithValue("@Logsys", dokuz[j].Logsys);
                                cmd.Parameters.AddWithValue("@Wbsta", dokuz[j].Wbsta);
                                cmd.Parameters.AddWithValue("@Cmeth", dokuz[j].Cmeth);
                                cmd.Parameters.AddWithValue("@Mjahr", dokuz[j].Mjahr);
                                #endregion
                                cmd.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                HataYaz(conn, "SAP_VBFA", Convert.ToInt64(dokuz[j].Vbelv).ToString(), Convert.ToInt32(dokuz[j].Posnv).ToString(), Convert.ToInt64(dokuz[j].Vbeln).ToString(), Convert.ToInt32(dokuz[j].Posnn).ToString(), dokuz[j].VbtypN, "(TESLIMAT) - " + ex.Message, cekilecektarih, cekilecektarih.AddDays(1));
                            }
                            conn.Close();
                        }
                    }
                    #endregion

                    cekilecektarih = cekilecektarih.AddDays(1);
                }

                if (!hatavar)
                    MaxTarihYaz(conn, "SAP_Teslimat", bitistarih);
            }
            #endregion



            #region NAKILSIPARIS MALCIKIS FATURA
            if (nakilmalfatura)
            {
                DateTime maxtarih = MaxTarihGetir(conn, "SAP_NakilMalFatura");
                DateTime bitistarih = DateTime.Now;
                bool hatavar = false;

                selectsalestransportC.ZwebSelectSalesTransportService client4 = new selectsalestransportC.ZwebSelectSalesTransportService();
                client4.Timeout = 6000000;
                client4.Credentials = nc1;

                DateTime cekilecektarih = maxtarih;
                DateTime simdikitarih = DateTime.Now;
                while (Convert.ToDateTime(cekilecektarih.ToShortDateString()) <= Convert.ToDateTime(simdikitarih.ToShortDateString()))
                {
                    selectsalestransportC.Zwebs007[] yedi = null;
                    selectsalestransportC.Zwebs014[] ondort = null;
                    selectsalestransportC.Zwebs015[] onbes = null;
                    selectsalestransportC.Zwebs016[] onalti = null;
                    selectsalestransportC.Zwebs017[] onyedi = null;
                    selectsalestransportC.Zwebs018[] onsekiz = null;

                    string hata = string.Empty;
                    string tarih = "";
                    string saat = "00:00:00";
                    try
                    {
                        TarihSaat(maxtarih, cekilecektarih, out tarih, out saat);
                        onbes = client4.ZwebSelectSalesTransport(tarih, saat, out onalti, out onyedi, out onsekiz, out yedi, out ondort);
                    }
                    catch (Exception ex)
                    {
                        hata = ex.Message;
                        hatavar = true;
                        cekilecektarih = DateTime.Now; // while dan çıksın bir sonraki günü almasın max tarihi yenilemesin
                    }
                    finally
                    {
                        LogYaz(conn, "select sales transport", hata != string.Empty ? false : true, hata, Convert.ToDateTime(cekilecektarih.ToShortDateString() + " " + saat), Convert.ToDateTime(cekilecektarih.ToShortDateString()) == Convert.ToDateTime(simdikitarih.ToShortDateString()) ? DateTime.Now : Convert.ToDateTime(cekilecektarih.AddDays(1).ToShortDateString() + " 00:00:00"));
                    }

                    #region nakilsiparis

                    #region head
                    if (nakilsiparis && yedi != null)
                    {
                        for (int j = 0; j < yedi.Length; j++)
                        {
                            try
                            {
                                conn.Open();
                                SqlCommand cmd = new SqlCommand(
                                    "DELETE FROM [SAP_NAKILSIPARIS_BASLIK] WHERE Lgnum = @Lgnum AND Tanum = @Tanum " +
                                    "INSERT INTO [SAP_NAKILSIPARIS_BASLIK] (KAYIT_TARIHI,[Lgnum],[Tanum],[Qdatu],[Lgtor],[Koliadet]) VALUES (@KAYIT_TARIHI,@Lgnum,@Tanum,@Qdatu,@Lgtor,@Koliadet)", conn);
                                #region parameters
                                cmd.Parameters.AddWithValue("@KAYIT_TARIHI", DateTime.Now);
                                cmd.Parameters.AddWithValue("@Lgnum", yedi[j].Lgnum);
                                cmd.Parameters.AddWithValue("@Tanum", Convert.ToInt32(yedi[j].Tanum));
                                cmd.Parameters.AddWithValue("@Qdatu", yedi[j].Qdatu.StartsWith("0000") ? Convert.ToDateTime("01.01.1900") : Convert.ToDateTime(yedi[j].Qdatu));
                                cmd.Parameters.AddWithValue("@Lgtor", yedi[j].Lgtor);
                                cmd.Parameters.AddWithValue("@Koliadet", yedi[j].Koliadet);
                                #endregion
                                cmd.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                HataYaz(conn, "SAP_NAKILSIPARIS_BASLIK", yedi[j].Lgnum, yedi[j].Tanum, "", "", "", ex.Message, cekilecektarih, cekilecektarih.AddDays(1));
                            }
                            conn.Close();
                        }
                    }
                    #endregion

                    #region item
                    if (nakilsiparis && ondort != null)
                    {
                        for (int j = 0; j < ondort.Length; j++)
                        {
                            try
                            {
                                conn.Open();
                                SqlCommand cmd = new SqlCommand(
                                    "DELETE FROM [SAP_NAKILSIPARIS_DETAY] WHERE Lgnum = @Lgnum AND Tanum = @Tanum AND Tapos = @Tapos " +
                                    "INSERT INTO [SAP_NAKILSIPARIS_DETAY] (KAYIT_TARIHI,[Lgnum],[Tanum],[Tapos],[Matnr],[Maktx],[Werks],[Charg],[Pquit],[Qdatu],[Qzeit],[Qname],[Brgew],[Gewei],[Ablad],[Volum],[Voleh],[Vbeln],[Vsolm],[Vistm],[Vdifm],[Meins],[Meins Text],[Vlber],[Vlpla],[Nlber],[Nlpla]) VALUES (@KAYIT_TARIHI,@Lgnum,@Tanum,@Tapos,@Matnr,@Maktx,@Werks,@Charg,@Pquit,@Qdatu,@Qzeit,@Qname,@Brgew,@Gewei,@Ablad,@Volum,@Voleh,@Vbeln,@Vsolm,@Vistm,@Vdifm,@Meins,@MeinsText,@Vlber,@Vlpla,@Nlber,@Nlpla)", conn);
                                #region parameters
                                cmd.Parameters.AddWithValue("@KAYIT_TARIHI", DateTime.Now);
                                cmd.Parameters.AddWithValue("@Lgnum", ondort[j].Lgnum);
                                cmd.Parameters.AddWithValue("@Tanum", Convert.ToInt32(ondort[j].Tanum));
                                cmd.Parameters.AddWithValue("@Tapos", Convert.ToInt32(ondort[j].Tapos));
                                cmd.Parameters.AddWithValue("@Matnr", ondort[j].Matnr == string.Empty ? 0 : Convert.ToInt32(ondort[j].Matnr));
                                cmd.Parameters.AddWithValue("@Maktx", ondort[j].Maktx);
                                cmd.Parameters.AddWithValue("@Werks", ondort[j].Werks);
                                cmd.Parameters.AddWithValue("@Charg", ondort[j].Charg);
                                cmd.Parameters.AddWithValue("@Pquit", ondort[j].Pquit);
                                cmd.Parameters.AddWithValue("@Qdatu", ondort[j].Qdatu.StartsWith("0000") ? Convert.ToDateTime("01.01.1900") : Convert.ToDateTime(ondort[j].Qdatu));
                                cmd.Parameters.AddWithValue("@Qzeit", ondort[j].Qzeit);
                                cmd.Parameters.AddWithValue("@Qname", ondort[j].Qname);
                                cmd.Parameters.AddWithValue("@Brgew", ondort[j].Brgew);
                                cmd.Parameters.AddWithValue("@Gewei", ondort[j].Gewei);
                                cmd.Parameters.AddWithValue("@Ablad", ondort[j].Ablad);
                                cmd.Parameters.AddWithValue("@Volum", ondort[j].Volum);
                                cmd.Parameters.AddWithValue("@Voleh", ondort[j].Voleh);
                                cmd.Parameters.AddWithValue("@Vbeln", ondort[j].Vbeln == string.Empty ? 0 : Convert.ToInt64(ondort[j].Vbeln));
                                cmd.Parameters.AddWithValue("@Vsolm", ondort[j].Vsolm);
                                cmd.Parameters.AddWithValue("@Vistm", ondort[j].Vistm);
                                cmd.Parameters.AddWithValue("@Vdifm", ondort[j].Vdifm);
                                cmd.Parameters.AddWithValue("@Meins", ondort[j].Meins);
                                cmd.Parameters.AddWithValue("@MeinsText", ondort[j].MeinsText);
                                cmd.Parameters.AddWithValue("@Vlber", ondort[j].Vlber);
                                cmd.Parameters.AddWithValue("@Vlpla", ondort[j].Vlpla);
                                cmd.Parameters.AddWithValue("@Nlber", ondort[j].Nlber);
                                cmd.Parameters.AddWithValue("@Nlpla", ondort[j].Nlpla);
                                #endregion
                                cmd.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                HataYaz(conn, "SAP_NAKILSIPARIS_DETAY", ondort[j].Lgnum, ondort[j].Tanum, ondort[j].Tapos, "", "", ex.Message, cekilecektarih, cekilecektarih.AddDays(1));
                            }
                            conn.Close();
                        }
                    }
                    #endregion

                    #endregion

                    #region malcikis

                    #region head
                    if (malcikis && onbes != null)
                    {
                        for (int j = 0; j < onbes.Length; j++)
                        {
                            try
                            {
                                conn.Open();
                                SqlCommand cmd = new SqlCommand(
                                    "DELETE FROM [SAP_MALCIKIS_BASLIK] WHERE Mblnr = @Mblnr AND Mjahr = @Mjahr " +
                                    "INSERT INTO [SAP_MALCIKIS_BASLIK] (KAYIT_TARIHI,[Mblnr],[Mjahr],[Blart],[Ltext],[Vgart],[Ltext2],[Bldat],[Budat],[Le Vbeln]) VALUES (@KAYIT_TARIHI,@Mblnr,@Mjahr,@Blart,@Ltext,@Vgart,@Ltext2,@Bldat,@Budat,@LeVbeln)", conn);
                                #region parameters
                                cmd.Parameters.AddWithValue("@KAYIT_TARIHI", DateTime.Now);
                                cmd.Parameters.AddWithValue("@Mblnr", Convert.ToInt64(onbes[j].Mblnr));
                                cmd.Parameters.AddWithValue("@Mjahr", Convert.ToInt32(onbes[j].Mjahr));
                                cmd.Parameters.AddWithValue("@Blart", onbes[j].Blart);
                                cmd.Parameters.AddWithValue("@Ltext", onbes[j].Ltext);
                                cmd.Parameters.AddWithValue("@Vgart", onbes[j].Vgart);
                                cmd.Parameters.AddWithValue("@Ltext2", onbes[j].Ltext2);
                                cmd.Parameters.AddWithValue("@Bldat", onbes[j].Bldat.StartsWith("0000") ? Convert.ToDateTime("01.01.1900") : Convert.ToDateTime(onbes[j].Bldat));
                                cmd.Parameters.AddWithValue("@Budat", onbes[j].Budat.StartsWith("0000") ? Convert.ToDateTime("01.01.1900") : Convert.ToDateTime(onbes[j].Budat));
                                cmd.Parameters.AddWithValue("@LeVbeln", onbes[j].LeVbeln);
                                #endregion
                                cmd.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                HataYaz(conn, "SAP_MALCIKIS_BASLIK", onbes[j].Mblnr, onbes[j].Mjahr, "", "", "", ex.Message, cekilecektarih, cekilecektarih.AddDays(1));
                            }
                            conn.Close();
                        }
                    }
                    #endregion

                    #region item
                    if (malcikis && onalti != null)
                    {
                        for (int j = 0; j < onalti.Length; j++)
                        {
                            try
                            {
                                conn.Open();
                                SqlCommand cmd = new SqlCommand(
                                    "DELETE FROM [SAP_MALCIKIS_DETAY] WHERE Mblnr = @Mblnr AND Mjahr = @Mjahr AND Zeile = @Zeile " +
                                    "INSERT INTO [SAP_MALCIKIS_DETAY] (KAYIT_TARIHI,[Mblnr],[Mjahr],[Zeile],[Matnr],[Werks],[Lgort],[Charg],[Kunnr],[Menge],[Meins],[Meins Text],[Lgnum],[Lgtyp],[Lgpla],[Sjahr],[Smbln],[Smblp],[Vbeln Vl],[Posnr Vl],[Vbeln],[Posnr]) VALUES (@KAYIT_TARIHI,@Mblnr,@Mjahr,@Zeile,@Matnr,@Werks,@Lgort,@Charg,@Kunnr,@Menge,@Meins,@MeinsText,@Lgnum,@Lgtyp,@Lgpla,@Sjahr,@Smbln,@Smblp,@VbelnVl,@PosnrVl,@Vbeln,@Posnr)", conn);
                                #region parameters
                                cmd.Parameters.AddWithValue("@KAYIT_TARIHI", DateTime.Now);
                                cmd.Parameters.AddWithValue("@Mblnr", Convert.ToInt64(onalti[j].Mblnr));
                                cmd.Parameters.AddWithValue("@Mjahr", Convert.ToInt32(onalti[j].Mjahr));
                                cmd.Parameters.AddWithValue("@Zeile", Convert.ToInt32(onalti[j].Zeile));
                                cmd.Parameters.AddWithValue("@Matnr", onalti[j].Matnr == string.Empty ? 0 : Convert.ToInt32(onalti[j].Matnr));
                                cmd.Parameters.AddWithValue("@Werks", onalti[j].Werks);
                                cmd.Parameters.AddWithValue("@Lgort", onalti[j].Lgort);
                                cmd.Parameters.AddWithValue("@Charg", onalti[j].Charg);
                                cmd.Parameters.AddWithValue("@Kunnr", onalti[j].Kunnr.StartsWith("T") || onalti[j].Kunnr == "" ? 10 : Convert.ToInt32(onalti[j].Kunnr));
                                cmd.Parameters.AddWithValue("@Menge", onalti[j].Menge);
                                cmd.Parameters.AddWithValue("@Meins", onalti[j].Meins);
                                cmd.Parameters.AddWithValue("@MeinsText", onalti[j].MeinsText);
                                cmd.Parameters.AddWithValue("@Lgnum", onalti[j].Lgnum);
                                cmd.Parameters.AddWithValue("@Lgtyp", onalti[j].Lgtyp);
                                cmd.Parameters.AddWithValue("@Lgpla", onalti[j].Lgpla);
                                cmd.Parameters.AddWithValue("@Sjahr", onalti[j].Sjahr);
                                cmd.Parameters.AddWithValue("@Smbln", onalti[j].Smbln);
                                cmd.Parameters.AddWithValue("@Smblp", onalti[j].Smblp);
                                cmd.Parameters.AddWithValue("@VbelnVl", onalti[j].VbelnVl);
                                cmd.Parameters.AddWithValue("@PosnrVl", onalti[j].PosnrVl);
                                cmd.Parameters.AddWithValue("@Vbeln", onalti[j].Vbeln);
                                cmd.Parameters.AddWithValue("@Posnr", onalti[j].Posnr);
                                #endregion
                                cmd.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                HataYaz(conn, "SAP_MALCIKIS_DETAY", onalti[j].Mblnr, onalti[j].Mjahr, onalti[j].Zeile, "", "", ex.Message, cekilecektarih, cekilecektarih.AddDays(1));
                            }
                            conn.Close();
                        }
                    }
                    #endregion

                    #endregion

                    #region fatura

                    #region head
                    if (fatura && onyedi != null)
                    {
                        for (int j = 0; j < onyedi.Length; j++)
                        {
                            try
                            {
                                conn.Open();
                                SqlCommand cmd = new SqlCommand(
                                    "DELETE FROM [SAP_FATURA_BASLIK] WHERE Vbeln = @Vbeln " +
                                    "INSERT INTO [SAP_FATURA_BASLIK] (KAYIT_TARIHI,[Vbeln],[Fkart],[Vtext],[Fktyp],[Fktyp Text],[Vbtyp],[Vbtyp Text],[Waerk],[Vkorg],[Vtweg],[Kalsm],[Knumv],[Vsbed],[Fkdat],[Bukrs],[Belnr],[Gjahr],[Poper],[Ernam],[Erzet],[Erdat],[Kunrg],[Sfakn],[Fksto],[Xblnr],[Zuonr]) VALUES (@KAYIT_TARIHI,@Vbeln,@Fkart,@Vtext,@Fktyp,@FktypText,@Vbtyp,@VbtypText,@Waerk,@Vkorg,@Vtweg,@Kalsm,@Knumv,@Vsbed,@Fkdat,@Bukrs,@Belnr,@Gjahr,@Poper,@Ernam,@Erzet,@Erdat,@Kunrg,@Sfakn,@Fksto,@Xblnr,@Zuonr)", conn);
                                #region parameters
                                cmd.Parameters.AddWithValue("@KAYIT_TARIHI", DateTime.Now);
                                cmd.Parameters.AddWithValue("@Vbeln", Convert.ToInt64(onyedi[j].Vbeln));
                                cmd.Parameters.AddWithValue("@Fkart", onyedi[j].Fkart);
                                cmd.Parameters.AddWithValue("@Vtext", onyedi[j].Vtext);
                                cmd.Parameters.AddWithValue("@Fktyp", onyedi[j].Fktyp);
                                cmd.Parameters.AddWithValue("@FktypText", onyedi[j].FktypText);
                                cmd.Parameters.AddWithValue("@Vbtyp", onyedi[j].Vbtyp);
                                cmd.Parameters.AddWithValue("@VbtypText", onyedi[j].VbtypText);
                                cmd.Parameters.AddWithValue("@Waerk", onyedi[j].Waerk);
                                cmd.Parameters.AddWithValue("@Vkorg", onyedi[j].Vkorg);
                                cmd.Parameters.AddWithValue("@Vtweg", onyedi[j].Vtweg);
                                cmd.Parameters.AddWithValue("@Kalsm", onyedi[j].Kalsm);
                                cmd.Parameters.AddWithValue("@Knumv", onyedi[j].Knumv.StartsWith("T") || onyedi[j].Knumv == "" ? 10 : Convert.ToInt32(onyedi[j].Knumv));
                                cmd.Parameters.AddWithValue("@Vsbed", onyedi[j].Vsbed);
                                cmd.Parameters.AddWithValue("@Fkdat", onyedi[j].Fkdat.StartsWith("0000") ? Convert.ToDateTime("01.01.1900") : Convert.ToDateTime(onyedi[j].Fkdat));
                                cmd.Parameters.AddWithValue("@Bukrs", onyedi[j].Bukrs);
                                cmd.Parameters.AddWithValue("@Belnr", onyedi[j].Belnr);
                                cmd.Parameters.AddWithValue("@Gjahr", onyedi[j].Gjahr);
                                cmd.Parameters.AddWithValue("@Poper", onyedi[j].Poper);
                                cmd.Parameters.AddWithValue("@Ernam", onyedi[j].Ernam);
                                cmd.Parameters.AddWithValue("@Erzet", onyedi[j].Erzet);
                                cmd.Parameters.AddWithValue("@Erdat", Convert.ToDateTime(onyedi[j].Erdat + " " + onyedi[j].Erzet));
                                cmd.Parameters.AddWithValue("@Kunrg", onyedi[j].Kunrg);
                                cmd.Parameters.AddWithValue("@Sfakn", onyedi[j].Sfakn);
                                cmd.Parameters.AddWithValue("@Fksto", onyedi[j].Fksto);
                                cmd.Parameters.AddWithValue("@Xblnr", onyedi[j].Xblnr);
                                cmd.Parameters.AddWithValue("@Zuonr", onyedi[j].Zuonr);
                                #endregion
                                cmd.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                HataYaz(conn, "SAP_FATURA_BASLIK", onyedi[j].Vbeln, "", "", "", "", ex.Message, cekilecektarih, cekilecektarih.AddDays(1));
                            }
                            conn.Close();
                        }
                    }
                    #endregion

                    #region item
                    if (fatura && onsekiz != null)
                    {
                        for (int j = 0; j < onsekiz.Length; j++)
                        {
                            try
                            {
                                conn.Open();
                                SqlCommand cmd = new SqlCommand(
                                    "DELETE FROM [SAP_FATURA_DETAY] WHERE Vbeln = @Vbeln AND Posnr = @Posnr " +
                                    "INSERT INTO [SAP_FATURA_DETAY] (KAYIT_TARIHI,[Vbeln],[Posnr],[Fkimg],[Vrkme],[Vrkme Text],[Ntgew],[Brgew],[Gewei],[Volum],[Voleh],[Vgbel],[Vgpos],[Vgtyp],[Aubel],[Aupos],[Auref],[Matnr],[Arktx],[Charg],[Netwr],[Brtwr],[Mwskz],[Sgtxt],[Kzwi1],[Kzwi4],[Lgort]) VALUES (@KAYIT_TARIHI,@Vbeln,@Posnr,@Fkimg,@Vrkme,@VrkmeText,@Ntgew,@Brgew,@Gewei,@Volum,@Voleh,@Vgbel,@Vgpos,@Vgtyp,@Aubel,@Aupos,@Auref,@Matnr,@Arktx,@Charg,@Netwr,@Brtwr,@Mwskz,@Sgtxt,@Kzwi1,@Kzwi4,@Lgort)", conn);
                                #region parameters
                                cmd.Parameters.AddWithValue("@KAYIT_TARIHI", DateTime.Now);
                                cmd.Parameters.AddWithValue("@Vbeln", Convert.ToInt64(onsekiz[j].Vbeln));
                                cmd.Parameters.AddWithValue("@Posnr", Convert.ToInt32(onsekiz[j].Posnr));
                                cmd.Parameters.AddWithValue("@Fkimg", onsekiz[j].Fkimg);
                                cmd.Parameters.AddWithValue("@Vrkme", onsekiz[j].Vrkme);
                                cmd.Parameters.AddWithValue("@VrkmeText", onsekiz[j].VrkmeText);
                                cmd.Parameters.AddWithValue("@Ntgew", onsekiz[j].Ntgew);
                                cmd.Parameters.AddWithValue("@Brgew", onsekiz[j].Brgew);
                                cmd.Parameters.AddWithValue("@Gewei", onsekiz[j].Gewei);
                                cmd.Parameters.AddWithValue("@Volum", onsekiz[j].Volum);
                                cmd.Parameters.AddWithValue("@Voleh", onsekiz[j].Voleh);
                                cmd.Parameters.AddWithValue("@Vgbel", onsekiz[j].Vgbel);
                                cmd.Parameters.AddWithValue("@Vgpos", onsekiz[j].Vgpos);
                                cmd.Parameters.AddWithValue("@Vgtyp", onsekiz[j].Vgtyp);
                                cmd.Parameters.AddWithValue("@Aubel", onsekiz[j].Aubel);
                                cmd.Parameters.AddWithValue("@Aupos", onsekiz[j].Aupos);
                                cmd.Parameters.AddWithValue("@Auref", onsekiz[j].Auref);
                                cmd.Parameters.AddWithValue("@Matnr", onsekiz[j].Matnr == string.Empty ? 0 : Convert.ToInt32(onsekiz[j].Matnr));
                                cmd.Parameters.AddWithValue("@Arktx", onsekiz[j].Arktx);
                                cmd.Parameters.AddWithValue("@Charg", onsekiz[j].Charg);
                                cmd.Parameters.AddWithValue("@Netwr", onsekiz[j].Netwr);
                                cmd.Parameters.AddWithValue("@Brtwr", onsekiz[j].Brtwr);
                                cmd.Parameters.AddWithValue("@Mwskz", onsekiz[j].Mwskz);
                                cmd.Parameters.AddWithValue("@Sgtxt", onsekiz[j].Sgtxt);
                                cmd.Parameters.AddWithValue("@Kzwi1", onsekiz[j].Kzwi1);
                                cmd.Parameters.AddWithValue("@Kzwi4", onsekiz[j].Kzwi4);
                                cmd.Parameters.AddWithValue("@Lgort", onsekiz[j].Lgort);
                                #endregion
                                cmd.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                HataYaz(conn, "SAP_FATURA_DETAY", onsekiz[j].Vbeln, onsekiz[j].Posnr, "", "", "", ex.Message, cekilecektarih, cekilecektarih.AddDays(1));
                            }
                            conn.Close();
                        }
                    }
                    #endregion

                    #endregion

                    cekilecektarih = cekilecektarih.AddDays(1);
                }

                if (!hatavar)
                    MaxTarihYaz(conn, "SAP_NakilMalFatura", bitistarih);
            }
            #endregion



            #region KOLIETIKET
            if (kolietiket)
            {
                DateTime maxtarih = MaxTarihGetir(conn, "SAP_KoliEtiket");
                DateTime bitistarih = DateTime.Now;
                bool hatavar = false;

                selectkolietiketC.ZwebSelectKoliEtiketService client5 = new selectkolietiketC.ZwebSelectKoliEtiketService();
                client5.Timeout = 6000000;
                client5.Credentials = nc1;

                DateTime cekilecektarih = maxtarih;
                DateTime simdikitarih = DateTime.Now;
                while (Convert.ToDateTime(cekilecektarih.ToShortDateString()) <= Convert.ToDateTime(simdikitarih.ToShortDateString()))
                {
                    selectkolietiketC.Zwebs019[] ondokuz = null;

                    string hata = string.Empty;
                    string tarih = "";
                    string saat = "00:00:00";
                    try
                    {
                        TarihSaat(maxtarih, cekilecektarih, out tarih, out saat);
                        ondokuz = client5.ZwebSelectKoliEtiket(tarih, saat);
                    }
                    catch (Exception ex)
                    {
                        hata = ex.Message;
                        hatavar = true;
                        cekilecektarih = DateTime.Now; // while dan çıksın bir sonraki günü almasın max tarihi yenilemesin
                    }
                    finally
                    {
                        LogYaz(conn, "select koli etiket", hata != string.Empty ? false : true, hata, Convert.ToDateTime(cekilecektarih.ToShortDateString() + " " + saat), Convert.ToDateTime(cekilecektarih.ToShortDateString()) == Convert.ToDateTime(simdikitarih.ToShortDateString()) ? DateTime.Now : Convert.ToDateTime(cekilecektarih.AddDays(1).ToShortDateString() + " 00:00:00"));
                    }

                    if (ondokuz != null)
                    {
                        for (int j = 0; j < ondokuz.Length; j++)
                        {
                            try
                            {
                                conn.Open();
                                SqlCommand cmd = new SqlCommand(
                                    "DELETE FROM [SAP_KOLIETIKET] WHERE Kolietiketno = @Kolietiketno " +
                                    "INSERT INTO [SAP_KOLIETIKET] (KAYIT_TARIHI,[Kolietiketno],[Kolisira],[Koliadet],[Vbeln],[Erdat],[Erzet],[Ernam],[Deleted]) VALUES (@KAYIT_TARIHI,@Kolietiketno,@Kolisira,@Koliadet,@Vbeln,@Erdat,@Erzet,@Ernam,@Deleted)", conn);
                                #region parameters
                                cmd.Parameters.AddWithValue("@KAYIT_TARIHI", DateTime.Now);
                                cmd.Parameters.AddWithValue("@Kolietiketno", ondokuz[j].Kolietiketno);
                                cmd.Parameters.AddWithValue("@Kolisira", ondokuz[j].Kolisira);
                                cmd.Parameters.AddWithValue("@Koliadet", ondokuz[j].Koliadet);
                                cmd.Parameters.AddWithValue("@Vbeln", Convert.ToInt64(ondokuz[j].Vbeln));
                                cmd.Parameters.AddWithValue("@Erdat", Convert.ToDateTime(ondokuz[j].Erdat + " " + ondokuz[j].Erzet));
                                cmd.Parameters.AddWithValue("@Erzet", ondokuz[j].Erzet);
                                cmd.Parameters.AddWithValue("@Ernam", ondokuz[j].Ernam);
                                cmd.Parameters.AddWithValue("@Deleted", ondokuz[j].Deleted);
                                #endregion
                                cmd.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                HataYaz(conn, "SAP_KOLIETIKET", ondokuz[j].Kolietiketno, "", "", "", "", ex.Message, cekilecektarih, cekilecektarih.AddDays(1));
                            }
                            conn.Close();
                        }
                    }

                    cekilecektarih = cekilecektarih.AddDays(1);
                }

                if (!hatavar)
                    MaxTarihYaz(conn, "SAP_KoliEtiket", bitistarih);
            }
            #endregion



            #region ACCOUNTING
            if (accounting)
            {
                DateTime maxtarih = MaxTarihGetir(conn, "SAP_Accounting");
                DateTime bitistarih = DateTime.Now;
                bool hatavar = false;

                selectaccountingC.ZwebSelectAccountingService client6 = new selectaccountingC.ZwebSelectAccountingService();
                //for (int i = maxtarih.Day; i <= DateTime.Now.Day; i++)
                //{
                selectaccountingC.Zwebs020[] yirmi = null;
                client6.Timeout = 6000000;
                client6.Credentials = nc1;

                string hata = string.Empty;
                try
                {
                    yirmi = client6.ZwebSelectAccounting(
                        maxtarih.Year.ToString() + (maxtarih.Month.ToString().Length == 1 ? "0" + maxtarih.Month.ToString() : maxtarih.Month.ToString()) + (maxtarih.Day.ToString().Length == 1 ? "0" + maxtarih.Day.ToString() : maxtarih.Day.ToString()),
                        DateTime.Now.AddDays(1).Year.ToString() + (DateTime.Now.AddDays(1).Month.ToString().Length == 1 ? "0" + DateTime.Now.AddDays(1).Month.ToString() : DateTime.Now.AddDays(1).Month.ToString()) + (DateTime.Now.AddDays(1).Day.ToString().Length == 1 ? "0" + DateTime.Now.AddDays(1).Day.ToString() : DateTime.Now.AddDays(1).Day.ToString()));
                }
                catch (Exception ex)
                {
                    hata = ex.Message;
                    hatavar = true;
                }
                finally
                {
                    LogYaz(conn, "select accounting", hata != string.Empty ? false : true, hata, maxtarih, DateTime.Now);
                }

                if (yirmi != null)
                {
                    for (int j = 0; j < yirmi.Length; j++)
                    {
                        try
                        {
                            conn.Open();
                            SqlCommand cmd = new SqlCommand(
                                "DELETE FROM [SAP_ACCOUNTING] WHERE Bukrs = @Bukrs AND Belnr = @Belnr AND Gjahr = @Gjahr " +
                                "INSERT INTO [SAP_ACCOUNTING] (KAYIT_TARIHI,[Bukrs],[Belnr],[Gjahr],[Blart],[Bldat],[Budat],[Monat],[Cpudt],[Cputm],[Aedat],[Upddt],[Wwert],[Usnam],[Xblnr],[Stblg],[Stjah],[Bktxt],[Waers],[Awtyp],[Awkey],[Zzikincibelgeno],[Zzislemkd],[Zzreferans]) VALUES (@KAYIT_TARIHI,@Bukrs,@Belnr,@Gjahr,@Blart,@Bldat,@Budat,@Monat,@Cpudt,@Cputm,@Aedat,@Upddt,@Wwert,@Usnam,@Xblnr,@Stblg,@Stjah,@Bktxt,@Waers,@Awtyp,@Awkey,@Zzikincibelgeno,@Zzislemkd,@Zzreferans)", conn);
                            #region parameters
                            cmd.Parameters.AddWithValue("@KAYIT_TARIHI", DateTime.Now);
                            cmd.Parameters.AddWithValue("@Bukrs", yirmi[j].Bukrs);
                            cmd.Parameters.AddWithValue("@Belnr", yirmi[j].Belnr);
                            cmd.Parameters.AddWithValue("@Gjahr", Convert.ToInt32(yirmi[j].Gjahr));
                            cmd.Parameters.AddWithValue("@Blart", yirmi[j].Blart);
                            cmd.Parameters.AddWithValue("@Bldat", yirmi[j].Bldat.StartsWith("0000") ? Convert.ToDateTime("01.01.1900") : Convert.ToDateTime(yirmi[j].Bldat));
                            cmd.Parameters.AddWithValue("@Budat", yirmi[j].Budat.StartsWith("0000") ? Convert.ToDateTime("01.01.1900") : Convert.ToDateTime(yirmi[j].Budat));
                            cmd.Parameters.AddWithValue("@Monat", yirmi[j].Monat);
                            cmd.Parameters.AddWithValue("@Cpudt", yirmi[j].Cpudt.StartsWith("0000") ? Convert.ToDateTime("01.01.1900") : Convert.ToDateTime(yirmi[j].Cpudt + " " + yirmi[j].Cputm));
                            cmd.Parameters.AddWithValue("@Cputm", yirmi[j].Cputm);
                            cmd.Parameters.AddWithValue("@Aedat", yirmi[j].Aedat.StartsWith("0000") ? Convert.ToDateTime("01.01.1900") : Convert.ToDateTime(yirmi[j].Aedat));
                            cmd.Parameters.AddWithValue("@Upddt", yirmi[j].Upddt.StartsWith("0000") ? Convert.ToDateTime("01.01.1900") : Convert.ToDateTime(yirmi[j].Upddt));
                            cmd.Parameters.AddWithValue("@Wwert", yirmi[j].Wwert.StartsWith("0000") ? Convert.ToDateTime("01.01.1900") : Convert.ToDateTime(yirmi[j].Wwert));
                            cmd.Parameters.AddWithValue("@Usnam", yirmi[j].Usnam);
                            cmd.Parameters.AddWithValue("@Xblnr", yirmi[j].Xblnr);
                            cmd.Parameters.AddWithValue("@Stblg", yirmi[j].Stblg);
                            cmd.Parameters.AddWithValue("@Stjah", yirmi[j].Stjah);
                            cmd.Parameters.AddWithValue("@Bktxt", yirmi[j].Bktxt);
                            cmd.Parameters.AddWithValue("@Waers", yirmi[j].Waers);
                            cmd.Parameters.AddWithValue("@Awtyp", yirmi[j].Awtyp);
                            cmd.Parameters.AddWithValue("@Awkey", yirmi[j].Awkey);
                            cmd.Parameters.AddWithValue("@Zzikincibelgeno", yirmi[j].Zzikincibelgeno);
                            cmd.Parameters.AddWithValue("@Zzislemkd", yirmi[j].Zzislemkd);
                            cmd.Parameters.AddWithValue("@Zzreferans", yirmi[j].Zzreferans);
                            #endregion
                            cmd.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            hatavar = true;
                            HataYaz(conn, "SAP_ACCOUNTING", yirmi[j].Bukrs, yirmi[j].Belnr, yirmi[j].Gjahr, "", "", ex.Message, maxtarih, DateTime.Now);
                        }
                        conn.Close();
                    }
                }

                if (!hatavar)
                    MaxTarihYaz(conn, "SAP_Accounting", bitistarih);
                //}
            }
            #endregion





            MalzemelerC(false, true); // ölçü birim tablo yenilemesi satisupdate ile çakışmaması için



            SatisUpdate(conn);



            if (ekstre)
            {
                //GetEkstre(DateTime.Now.AddYears(-1)); // Convert.ToDateTime("01.01.2014")
                GetSatisJob();
            }
        }


        private void MalzemelerC(bool malzeme, bool olcubirim)
        {
            SqlConnection conn = new SqlConnection("Server=.; Database=KurumsalWebSAP; User Id=sa; Password=sdl580g5p9+-; Trusted_Connection=False;");

            SqlCommand cmdLog = new SqlCommand("INSERT INTO [KurumsalWebSAP].[dbo].[tblINTERNET_LogTabloGuncellemeler] ([dtBaslangic],[dtBitis],[strYer],[strLog]) VALUES (@dtBaslangic,@dtBitis,@strYer,@strLog)", conn);
            cmdLog.Parameters.AddWithValue("@dtBaslangic", DateTime.Now); cmdLog.Parameters.AddWithValue("@strYer", "SAP Malzemeler");



            NetworkCredential nc1 = new NetworkCredential("ngunay", "123456");

            getmaterialsC.ZwebGetMaterialsService clMaterials = new getmaterialsC.ZwebGetMaterialsService();
            clMaterials.Timeout = 6000000;
            clMaterials.Credentials = nc1;
            getmaterialsC.Zwebs025[] yirmibes = null;
            getmaterialsC.Zwebt001St[] birst = null;
            getmaterialsC.Zwebt001[] listMaterials = clMaterials.ZwebGetMaterials(out yirmibes, out birst);

            cmdLog.Parameters.AddWithValue("@strLog", listMaterials.Length.ToString() + " Satır");

            if (malzeme)
            {
                SqlCommand cmd1 = new SqlCommand("DELETE FROM [Web_Malzeme] DELETE FROM [Web_Malzeme_Stock]", conn);
                cmd1.CommandTimeout = 1000;
                conn.Open();
                cmd1.ExecuteNonQuery();
                conn.Close();

                for (int i = 0; i < birst.Length; i++)
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO [Web_Malzeme_Stock] (Charg,Clabs,Lgort,Matnr,Meins,Werks) VALUES (@Charg,@Clabs,@Lgort,@Matnr,@Meins,@Werks)", conn);
                    cmd.CommandTimeout = 1000;
                    cmd.Parameters.AddWithValue("@Charg", birst[i].Charg);
                    cmd.Parameters.AddWithValue("@Clabs", birst[i].Clabs);
                    cmd.Parameters.AddWithValue("@Lgort", birst[i].Lgort);
                    try { cmd.Parameters.AddWithValue("@Matnr", Convert.ToInt32(birst[i].Matnr.Substring(11))); }
                    catch { cmd.Parameters.AddWithValue("@Matnr", 0); }
                    cmd.Parameters.AddWithValue("@Meins", birst[i].Meins);
                    cmd.Parameters.AddWithValue("@Werks", birst[i].Werks);
                    conn.Open();
                    try { cmd.ExecuteNonQuery(); }
                    catch (Exception ex) { Hatalar.DoInsert(ex, "windows servis SAP malzemeler stock"); }
                    conn.Close();
                }

                for (int i = 0; i < listMaterials.Length; i++)
                {
                    string ap = listMaterials[i].Vmsta;
                    int itemref = 0; try { itemref = Convert.ToInt32(listMaterials[i].Matnr.Substring(11)); }
                    catch { }
                    string malkod = listMaterials[i].Bismt;
                    string malacik = listMaterials[i].Zzumetin == string.Empty ? listMaterials[i].Maktx : listMaterials[i].Zzumetin;
                    string eskod = string.Empty; try { eskod = listMaterials[i].Zzyedurnum.Substring(11); }
                    catch { }
                    string birimref = listMaterials[i].Meins;
                    string birim = listMaterials[i].Pakad.ToString("N0");
                    string grupkod = listMaterials[i].Spart == "T1" || listMaterials[i].Spart == "T3" || listMaterials[i].Spart == "T4" ? "STG-1" : listMaterials[i].Spart == "T2" ? "STG-2" : listMaterials[i].Spart == "S1" ? "AL-SAT" : "DİĞER";
                    string grupacik = listMaterials[i].Spart == "T1" || listMaterials[i].Spart == "T3" || listMaterials[i].Spart == "T4" ? "AHT" : listMaterials[i].Spart == "T2" ? "YEG" : listMaterials[i].Spart == "S1" ? "AL-SAT GRUBU" : "DİĞER";
                    string ozelkod = listMaterials[i].Spart.StartsWith("T") ? listMaterials[i].Spart : listMaterials[i].Matkl;
                    string hk = listMaterials[i].Spart.StartsWith("T") ? (listMaterials[i].Spart == "T1" ? "T" : listMaterials[i].Spart == "T2" ? "Y" : listMaterials[i].Spart == "T3" ? "H" : listMaterials[i].Spart == "T4" ? "A" : "D") : listMaterials[i].Wgbez.Length > 0 ? listMaterials[i].Wgbez[0].ToString() : "";
                    string ozelacik = listMaterials[i].Spart.StartsWith("T") ? (listMaterials[i].Spart == "T1" ? "TİBET" : listMaterials[i].Spart == "T2" ? "YEG" : listMaterials[i].Spart == "T3" ? "HAYAT" : listMaterials[i].Spart == "T4" ? "ARI" : "DİĞER") : listMaterials[i].Wgbez;
                    string reykod = listMaterials[i].Extwg != string.Empty ? listMaterials[i].Extwg : "T";
                    string rk = listMaterials[i].Ewbez.Length > 0 ? listMaterials[i].Ewbez[0].ToString() : "T";
                    string reyacik = listMaterials[i].Ewbez != string.Empty ? listMaterials[i].Ewbez : "TİBET DİĞER";
                    double kdv = 0; try { kdv = Convert.ToDouble(listMaterials[i].Kbetr); }
                    catch { }
                    double koli = 0; try { koli = Convert.ToDouble(listMaterials[i].Kolad); }
                    catch { }
                    string barkod = listMaterials[i].Ean11;
                    double stok = 0; try { stok = Convert.ToDouble(listMaterials[i].Menge); }
                    catch { }
                    int kytm = 0; try { kytm = Convert.ToInt32((DateTime.Now - Convert.ToDateTime(listMaterials[i].Ersda)).TotalDays); }
                    catch { }
                    int kanal = 0; try { kanal = Convert.ToInt32(listMaterials[i].Zzmkanal); }
                    catch { }
                    int primt = 0; try { primt = Convert.ToInt32(listMaterials[i].Zzpirgt); }
                    catch { }
                    int primb = 0; try { primb = Convert.ToInt32(listMaterials[i].Zzpirbz); }
                    catch { }
                    string hyrs = listMaterials[i].Prdha;
                    string hyrstanim = listMaterials[i].Vtext;
                    int donusum = listMaterials[i].Zzmaldonusumno != string.Empty ? Convert.ToInt32(listMaterials[i].Zzmaldonusumno) : itemref;
                    int mhdhb = 0; try { mhdhb = Convert.ToInt32(listMaterials[i].Mhdhb); }
                    catch { }
                    int mhdrz = 0; try { mhdrz = Convert.ToInt32(listMaterials[i].Mhdrz); }
                    catch { }

                    SqlCommand cmd = new SqlCommand("INSERT INTO [Web_Malzeme] " +
                        "([AP],[ITEMREF],[MAL KOD],[MAL ACIK],[URT KOD],[ES KOD],[BIRIMREF],[BIRIM],[GRUP KOD],[GRUP ACIK],[OZEL KOD],[HK],[OZEL ACIK],[REY KOD],[RK],[REY ACIK],[KDV],KOLI,BARKOD,STOK,[KYTM],KANAL,PRIMT,PRIMB,HYRS,HYRS_TANIM,DONUSUM,MHDHB,MHDRZ)" +
                        "VALUES (@AP,@ITEMREF,@MALKOD,@MALACIK,@URTKOD,@ESKOD,@BIRIMREF,@BIRIM,@GRUPKOD,@GRUPACIK,@OZELKOD,@HK,@OZELACIK,@REYKOD,@RK,@REYACIK,@KDV,@KOLI,@BARKOD,@STOK,@KYTM,@KANAL,@PRIMT,@PRIMB,@HYRS,@HYRS_TANIM,@DONUSUM,@MHDHB,@MHDRZ)", conn);
                    cmd.CommandTimeout = 1000;
                    cmd.Parameters.AddWithValue("@AP", Convert.ToInt32(ap == string.Empty || ap == "A" ? "0" : "1"));
                    cmd.Parameters.AddWithValue("@ITEMREF", itemref);
                    cmd.Parameters.AddWithValue("@MALKOD", malkod);
                    cmd.Parameters.AddWithValue("@MALACIK", malacik.Trim().Replace("     ", " ").Replace("    ", " ").Replace("   ", " ").Replace("  ", " ").Trim());
                    cmd.Parameters.AddWithValue("@URTKOD", itemref);
                    cmd.Parameters.AddWithValue("@ESKOD", eskod == string.Empty ? itemref.ToString() : eskod);
                    cmd.Parameters.AddWithValue("@BIRIMREF", birimref);
                    cmd.Parameters.AddWithValue("@BIRIM", birim);
                    cmd.Parameters.AddWithValue("@GRUPKOD", grupkod);
                    cmd.Parameters.AddWithValue("@GRUPACIK", grupacik);
                    cmd.Parameters.AddWithValue("@OZELKOD", ozelkod);
                    cmd.Parameters.AddWithValue("@HK", hk);
                    cmd.Parameters.AddWithValue("@OZELACIK", ozelacik);
                    cmd.Parameters.AddWithValue("@REYKOD", ozelkod);
                    cmd.Parameters.AddWithValue("@RK", rk);
                    cmd.Parameters.AddWithValue("@REYACIK", reyacik);
                    cmd.Parameters.AddWithValue("@KDV", kdv);
                    cmd.Parameters.AddWithValue("@KOLI", koli);
                    cmd.Parameters.AddWithValue("@BARKOD", barkod);
                    cmd.Parameters.AddWithValue("@STOK", stok);
                    cmd.Parameters.AddWithValue("@KYTM", kytm);
                    cmd.Parameters.AddWithValue("@KANAL", kanal);
                    cmd.Parameters.AddWithValue("@PRIMT", primt);
                    cmd.Parameters.AddWithValue("@PRIMB", primb);
                    cmd.Parameters.AddWithValue("@HYRS", hyrs);
                    cmd.Parameters.AddWithValue("@HYRS_TANIM", hyrstanim);
                    cmd.Parameters.AddWithValue("@DONUSUM", donusum);
                    cmd.Parameters.AddWithValue("@MHDHB", mhdhb);
                    cmd.Parameters.AddWithValue("@MHDRZ", mhdrz);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Hatalar.DoInsert(ex, "windows servis SAP malzemeler");
                    }
                    finally
                    {
                        conn.Close();
                    }
                }

                SqlCommand cmd2 = new SqlCommand("BEGIN TRANSACTION t_Transaction TRUNCATE TABLE [Web-Malzeme-Full] INSERT INTO [Web-Malzeme-Full] SELECT * FROM [Web_Malzeme] WITH (HOLDLOCK) COMMIT TRANSACTION t_Transaction", conn);
                cmd2.CommandTimeout = 1000;
                SqlCommand cmd3 = new SqlCommand("DELETE FROM [Web-GrupKodlar] INSERT INTO [Web-GrupKodlar] SELECT DISTINCT [GRUP KOD],[GRUP ACIK] FROM [Web_Malzeme]   DELETE FROM [Web-OzelKodlar] INSERT INTO [Web-OzelKodlar] SELECT DISTINCT [OZEL KOD],[HK],[OZEL ACIK],[GRUP KOD] FROM [Web_Malzeme]   DELETE FROM [Web-Kategoriler] INSERT INTO [Web-Kategoriler] SELECT DISTINCT [REY KOD] AS CODE,[RK],[REY ACIK] AS NAME FROM [Web_Malzeme]", conn);
                cmd3.CommandTimeout = 1000;

                //SqlCommand cmd5 = new SqlCommand("INSERT INTO [Web-Malzeme-AP] SELECT ITEMREF,AP FROM [Web-Malzeme-Full] WHERE ITEMREF NOT IN (SELECT ITEMREF FROM [Web-Malzeme-AP])", conn);
                //cmd5.CommandTimeout = 1000;
                //SqlCommand cmd6 = new SqlCommand("UPDATE [Web-Malzeme-Full] SET [AP] = [Web-Malzeme-AP].AP FROM [Web-Malzeme-Full] INNER JOIN [Web-Malzeme-AP] ON [Web-Malzeme-Full].ITEMREF = [Web-Malzeme-AP].ITEMREF", conn);
                //cmd6.CommandTimeout = 1000;

                SqlCommand cmd4 = new SqlCommand("BEGIN TRANSACTION t_Transaction TRUNCATE TABLE [Web-Malzeme] INSERT INTO [Web-Malzeme] ([ITEMREF],[MAL KOD],[MAL ACIK],[URT KOD],[ES KOD],[BIRIMREF],[BIRIM],[GRUP KOD],[GRUP ACIK],[OZEL KOD],[HK],[OZEL ACIK],[REY KOD],[RK],[REY ACIK],[KDV],[KOLI],[BARKOD],[STOK],[KYTM],KANAL,PRIMT,PRIMB,HYRS,HYRS_TANIM,DONUSUM,MHDHB,MHDRZ) SELECT [ITEMREF],[MAL KOD],[MAL ACIK],[URT KOD],[ES KOD],[BIRIMREF],[BIRIM],[GRUP KOD],[GRUP ACIK],[OZEL KOD],[HK],[OZEL ACIK],[REY KOD],[RK],[REY ACIK],[KDV],[KOLI],[BARKOD],[STOK],[KYTM],KANAL,PRIMT,PRIMB,HYRS,HYRS_TANIM,DONUSUM,MHDHB,MHDRZ FROM [Web-Malzeme-Full] WITH (HOLDLOCK) WHERE AP = 0 COMMIT TRANSACTION t_Transaction", conn);
                cmd4.CommandTimeout = 1000;

                SqlCommand cmd7 = new SqlCommand("UPDATE [Web-Malzeme] SET [REY KOD] = (SELECT [OZEL KOD] FROM [Web-Malzeme-DOK] WHERE ITEMREF = [Web-Malzeme].ITEMREF) WHERE ITEMREF IN (SELECT ITEMREF FROM [Web-Malzeme-DOK])", conn);
                //SqlCommand cmd7 = new SqlCommand("UPDATE [Web-Malzeme] SET [OZEL KOD] = (SELECT [OZEL KOD] FROM [Web-Malzeme-DOK] WHERE ITEMREF = [Web-Malzeme].ITEMREF),[GRUP KOD] = 'STG-1',[GRUP ACIK] = 'AHT',HK = CASE WHEN (SELECT [OZEL KOD] FROM [Web-Malzeme-DOK] WHERE ITEMREF = [Web-Malzeme].ITEMREF) = 'T3' THEN 'H' ELSE 'T' END,[OZEL ACIK] = CASE WHEN (SELECT [OZEL KOD] FROM [Web-Malzeme-DOK] WHERE ITEMREF = [Web-Malzeme].ITEMREF) = 'T3' THEN 'HAYAT' ELSE 'TİBET' END WHERE ITEMREF IN (SELECT ITEMREF FROM [Web-Malzeme-DOK])", conn);
                cmd7.CommandTimeout = 1000;

                SqlCommand cmd8 = new SqlCommand("UPDATE [Web-Malzeme-Full] SET [REY KOD] = (SELECT [OZEL KOD] FROM [Web-Malzeme-DOK] WHERE ITEMREF = [Web-Malzeme-Full].ITEMREF) WHERE ITEMREF IN (SELECT ITEMREF FROM [Web-Malzeme-DOK])", conn);
                //SqlCommand cmd8 = new SqlCommand("UPDATE [Web-Malzeme-Full] SET [OZEL KOD] = (SELECT [OZEL KOD] FROM [Web-Malzeme-DOK] WHERE ITEMREF = [Web-Malzeme-Full].ITEMREF),[GRUP KOD] = 'STG-1',[GRUP ACIK] = 'AHT',HK = CASE WHEN (SELECT [OZEL KOD] FROM [Web-Malzeme-DOK] WHERE ITEMREF = [Web-Malzeme-Full].ITEMREF) = 'T3' THEN 'H' ELSE 'T' END,[OZEL ACIK] = CASE WHEN (SELECT [OZEL KOD] FROM [Web-Malzeme-DOK] WHERE ITEMREF = [Web-Malzeme-Full].ITEMREF) = 'T3' THEN 'HAYAT' ELSE 'TİBET' END WHERE ITEMREF IN (SELECT ITEMREF FROM [Web-Malzeme-DOK])", conn);
                cmd8.CommandTimeout = 1000;

                SqlCommand cmd9 = new SqlCommand("UPDATE [Web-Fiyat] SET [REY KOD] = (SELECT [OZEL KOD] FROM [Web-Malzeme-DOK] WHERE ITEMREF = [Web-Fiyat].ITEMREF) WHERE ITEMREF IN (SELECT ITEMREF FROM [Web-Malzeme-DOK])", conn);
                //SqlCommand cmd9 = new SqlCommand("UPDATE [Web-Fiyat] SET [OZEL KOD] = (SELECT [OZEL KOD] FROM [Web-Malzeme-DOK] WHERE ITEMREF = [Web-Fiyat].ITEMREF),[GRUP KOD] = 'STG-1',HK = CASE WHEN (SELECT [OZEL KOD] FROM [Web-Malzeme-DOK] WHERE ITEMREF = [Web-Fiyat].ITEMREF) = 'T3' THEN 'H' ELSE 'T' END,[OZEL ACIK] = CASE WHEN (SELECT [OZEL KOD] FROM [Web-Malzeme-DOK] WHERE ITEMREF = [Web-Fiyat].ITEMREF) = 'T3' THEN 'HAYAT' ELSE 'TİBET' END WHERE ITEMREF IN (SELECT ITEMREF FROM [Web-Malzeme-DOK])", conn);
                cmd9.CommandTimeout = 1000;

                SqlCommand cmd10 = new SqlCommand("UPDATE [Web-Fiyat-Full] SET [REY KOD] = (SELECT [OZEL KOD] FROM [Web-Malzeme-DOK] WHERE ITEMREF = [Web-Fiyat-Full].ITEMREF) WHERE ITEMREF IN (SELECT ITEMREF FROM [Web-Malzeme-DOK])", conn);
                //SqlCommand cmd10 = new SqlCommand("UPDATE [Web-Fiyat-Full] SET [OZEL KOD] = (SELECT [OZEL KOD] FROM [Web-Malzeme-DOK] WHERE ITEMREF = [Web-Fiyat-Full].ITEMREF),[GRUP KOD] = 'STG-1',HK = CASE WHEN (SELECT [OZEL KOD] FROM [Web-Malzeme-DOK] WHERE ITEMREF = [Web-Fiyat-Full].ITEMREF) = 'T3' THEN 'H' ELSE 'T' END,[OZEL ACIK] = CASE WHEN (SELECT [OZEL KOD] FROM [Web-Malzeme-DOK] WHERE ITEMREF = [Web-Fiyat-Full].ITEMREF) = 'T3' THEN 'HAYAT' ELSE 'TİBET' END WHERE ITEMREF IN (SELECT ITEMREF FROM [Web-Malzeme-DOK])", conn);
                cmd10.CommandTimeout = 1000;

                SqlCommand cmd11 = new SqlCommand("UPDATE [Web-Malzeme] SET STOKE = (SELECT sum([Clabs]) FROM [Web_Malzeme_Stock] WHERE Matnr = [Web-Malzeme].ITEMREF) FROM [Web-Malzeme] UPDATE [Web-Malzeme-Full] SET STOKE = (SELECT sum([Clabs]) FROM [Web_Malzeme_Stock] WHERE Matnr = [Web-Malzeme-Full].ITEMREF) FROM [Web-Malzeme-Full]", conn);
                cmd11.CommandTimeout = 1000;

                conn.Open();
                cmd2.ExecuteNonQuery();
                cmd3.ExecuteNonQuery();
                //cmd5.ExecuteNonQuery();
                //cmd6.ExecuteNonQuery();
                cmd4.ExecuteNonQuery();
                cmd7.ExecuteNonQuery();
                cmd8.ExecuteNonQuery();
                cmd9.ExecuteNonQuery();
                cmd10.ExecuteNonQuery();
                cmd11.ExecuteNonQuery();
                conn.Close();



                conn.Open(); cmdLog.Parameters.AddWithValue("@dtBitis", DateTime.Now); cmdLog.ExecuteNonQuery(); conn.Close();
            }



            if (olcubirim)
            {
                conn.Open();
                SqlCommand cmdSilOlcuBirim = new SqlCommand("DELETE FROM [SAP_OLCUBIRIM]", conn);
                cmdSilOlcuBirim.ExecuteNonQuery();
                conn.Close();

                for (int i = 0; i < yirmibes.Length; i++)
                {
                    string Matnr = yirmibes[i].Matnr;
                    string Meinh = yirmibes[i].Meinh;
                    double Umrez = Convert.ToDouble(yirmibes[i].Umrez);
                    double Umren = Convert.ToDouble(yirmibes[i].Umren);
                    string Eannr = yirmibes[i].Eannr;
                    string Ean11 = yirmibes[i].Ean11;
                    string Numtp = yirmibes[i].Numtp;
                    double Laeng = Convert.ToDouble(yirmibes[i].Laeng);
                    double Breit = Convert.ToDouble(yirmibes[i].Breit);
                    double Hoehe = Convert.ToDouble(yirmibes[i].Hoehe);
                    string Meabm = yirmibes[i].Meabm;
                    double Volum = Convert.ToDouble(yirmibes[i].Volum);
                    string Voleh = yirmibes[i].Voleh;
                    double Brgew = Convert.ToDouble(yirmibes[i].Brgew);
                    string Gewei = yirmibes[i].Gewei;
                    string Mesub = yirmibes[i].Mesub;
                    string Atinn = yirmibes[i].Atinn;
                    string Mesrt = yirmibes[i].Mesrt;
                    string Xfhdw = yirmibes[i].Xfhdw;
                    string Xbeww = yirmibes[i].Xbeww;
                    string Kzwso = yirmibes[i].Kzwso;
                    string Msehi = yirmibes[i].Msehi;
                    string BflmeMarm = yirmibes[i].BflmeMarm;
                    string GtinVariant = yirmibes[i].GtinVariant;
                    double NestFtr = Convert.ToDouble(yirmibes[i].NestFtr);
                    byte MaxStack = Convert.ToByte(yirmibes[i].MaxStack);
                    double Capause = Convert.ToDouble(yirmibes[i].Capause);
                    string Ty2tq = yirmibes[i].Ty2tq;

                    SqlCommand cmdOlcuBirim = new SqlCommand("INSERT INTO [SAP_OLCUBIRIM] " +
                        "([Matnr],[Meinh],[Umrez],[Umren],[Eannr],[Ean11],[Numtp],[Laeng],[Breit],[Hoehe],[Meabm],[Volum],[Voleh],[Brgew],[Gewei],[Mesub],[Atinn],[Mesrt],[Xfhdw],[Xbeww],[Kzwso],[Msehi],[BflmeMarm],[GtinVariant],[NestFtr],[MaxStack],[Capause],[Ty2tq]) " +
                        "VALUES (@Matnr,@Meinh,@Umrez,@Umren,@Eannr,@Ean11,@Numtp,@Laeng,@Breit,@Hoehe,@Meabm,@Volum,@Voleh,@Brgew,@Gewei,@Mesub,@Atinn,@Mesrt,@Xfhdw,@Xbeww,@Kzwso,@Msehi,@BflmeMarm,@GtinVariant,@NestFtr,@MaxStack,@Capause,@Ty2tq)", conn);
                    cmdOlcuBirim.CommandTimeout = 1000;
                    cmdOlcuBirim.Parameters.AddWithValue("@Matnr", Matnr);
                    cmdOlcuBirim.Parameters.AddWithValue("@Meinh", Meinh);
                    cmdOlcuBirim.Parameters.AddWithValue("@Umrez", Umrez);
                    cmdOlcuBirim.Parameters.AddWithValue("@Umren", Umren);
                    cmdOlcuBirim.Parameters.AddWithValue("@Eannr", Eannr);
                    cmdOlcuBirim.Parameters.AddWithValue("@Ean11", Ean11);
                    cmdOlcuBirim.Parameters.AddWithValue("@Numtp", Numtp);
                    cmdOlcuBirim.Parameters.AddWithValue("@Laeng", Laeng);
                    cmdOlcuBirim.Parameters.AddWithValue("@Breit", Breit);
                    cmdOlcuBirim.Parameters.AddWithValue("@Hoehe", Hoehe);
                    cmdOlcuBirim.Parameters.AddWithValue("@Meabm", Meabm);
                    cmdOlcuBirim.Parameters.AddWithValue("@Volum", Volum);
                    cmdOlcuBirim.Parameters.AddWithValue("@Voleh", Voleh);
                    cmdOlcuBirim.Parameters.AddWithValue("@Brgew", Brgew);
                    cmdOlcuBirim.Parameters.AddWithValue("@Gewei", Gewei);
                    cmdOlcuBirim.Parameters.AddWithValue("@Mesub", Mesub);
                    cmdOlcuBirim.Parameters.AddWithValue("@Atinn", Atinn);
                    cmdOlcuBirim.Parameters.AddWithValue("@Mesrt", Mesrt);
                    cmdOlcuBirim.Parameters.AddWithValue("@Xfhdw", Xfhdw);
                    cmdOlcuBirim.Parameters.AddWithValue("@Xbeww", Xbeww);
                    cmdOlcuBirim.Parameters.AddWithValue("@Kzwso", Kzwso);
                    cmdOlcuBirim.Parameters.AddWithValue("@Msehi", Msehi);
                    cmdOlcuBirim.Parameters.AddWithValue("@BflmeMarm", BflmeMarm);
                    cmdOlcuBirim.Parameters.AddWithValue("@GtinVariant", GtinVariant);
                    cmdOlcuBirim.Parameters.AddWithValue("@NestFtr", NestFtr);
                    cmdOlcuBirim.Parameters.AddWithValue("@MaxStack", MaxStack);
                    cmdOlcuBirim.Parameters.AddWithValue("@Capause", Capause);
                    cmdOlcuBirim.Parameters.AddWithValue("@Ty2tq", Ty2tq);

                    try
                    {
                        conn.Open();
                        cmdOlcuBirim.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Hatalar.DoInsert(ex, "windows servis SAP malzemeler olcubirim");
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
        }

        private void FiyatlarCsap()
        {
            SqlConnection conn = new SqlConnection("Server=.; Database=KurumsalWebSAP; User Id=sa; Password=sdl580g5p9+-; Trusted_Connection=False;");

            SqlCommand cmdLog = new SqlCommand("INSERT INTO [KurumsalWebSAP].[dbo].[tblINTERNET_LogTabloGuncellemeler] ([dtBaslangic],[dtBitis],[strYer],[strLog]) VALUES (@dtBaslangic,@dtBitis,@strYer,@strLog)", conn);
            cmdLog.Parameters.AddWithValue("@dtBaslangic", DateTime.Now); cmdLog.Parameters.AddWithValue("@strYer", "SAP Fiyatlar");



            NetworkCredential nc1 = new NetworkCredential("ngunay", "123456");

            getmaterialpricesC.ZwebGetMaterialPricesService clMaterialPrices = new getmaterialpricesC.ZwebGetMaterialPricesService();
            clMaterialPrices.Timeout = 6000000;
            clMaterialPrices.Credentials = nc1;
            getmaterialpricesC.Zwebt004[] listMaterialPrices;
            try
            {
                listMaterialPrices = clMaterialPrices.ZwebGetMaterialPrices();
            }
            catch (Exception ex)
            {
                cmdLog.Parameters.AddWithValue("@strLog", ex.Message);
                conn.Open(); cmdLog.Parameters.AddWithValue("@dtBitis", DateTime.Now); cmdLog.ExecuteNonQuery(); conn.Close();
                return;
            }

            cmdLog.Parameters.AddWithValue("@strLog", listMaterialPrices.Length.ToString() + " Satır");

            SqlCommand cmd1 = new SqlCommand("DELETE FROM [Web_Fiyat_SAP]", conn);
            cmd1.CommandTimeout = 1000;
            conn.Open();
            cmd1.ExecuteNonQuery();
            conn.Close();

            DateTime dt1 = DateTime.Now;

            /*DataTable dt = new DataTable();
            dt.Columns.Add("Aedat", typeof(string));
            dt.Columns.Add("Aezet", typeof(string));
            dt.Columns.Add("Kbetr", typeof(decimal));
            dt.Columns.Add("Kdgrp", typeof(string));
            dt.Columns.Add("Kmein", typeof(string));
            dt.Columns.Add("Konwa", typeof(string));
            dt.Columns.Add("Kpein", typeof(decimal));
            dt.Columns.Add("Kschl", typeof(string));
            dt.Columns.Add("Kunnr", typeof(string));
            dt.Columns.Add("Mandt", typeof(string));
            dt.Columns.Add("Matnr", typeof(string));
            dt.Columns.Add("Pltyp", typeof(string));
            dt.Columns.Add("Valdt", typeof(string));
            dt.Columns.Add("Zterm", typeof(string));*/

            /*Parallel.For(0, listMaterialPrices.Length, i =>
            {
                try
                {
                    DataRow drow = dt.NewRow();
                    drow["Aedat"] = listMaterialPrices[i].Aedat;
                    drow["Aezet"] = listMaterialPrices[i].Aezet;
                    drow["Kbetr"] = listMaterialPrices[i].Kbetr;
                    drow["Kdgrp"] = listMaterialPrices[i].Kdgrp;
                    drow["Kmein"] = listMaterialPrices[i].Kmein;
                    drow["Konwa"] = listMaterialPrices[i].Konwa;
                    drow["Kpein"] = listMaterialPrices[i].Kpein;
                    drow["Kschl"] = listMaterialPrices[i].Kschl;
                    drow["Kunnr"] = listMaterialPrices[i].Kunnr;
                    drow["Mandt"] = listMaterialPrices[i].Mandt;
                    drow["Matnr"] = listMaterialPrices[i].Matnr;
                    drow["Pltyp"] = listMaterialPrices[i].Pltyp;
                    drow["Valdt"] = listMaterialPrices[i].Valdt;
                    drow["Zterm"] = listMaterialPrices[i].Zterm;
                    dt.Rows.Add(drow);
                }
                catch (Exception ex)
                {

                }
            });*/

            /*var tasks = listMaterialPrices.Select(x => Task.Factory.StartNew(() => {

                DataRow drow = dt.NewRow();
                drow["Aedat"] = x.Aedat;
                drow["Aezet"] = x.Aezet;
                drow["Kbetr"] = x.Kbetr;
                drow["Kdgrp"] = x.Kdgrp;
                drow["Kmein"] = x.Kmein;
                drow["Konwa"] = x.Konwa;
                drow["Kpein"] = x.Kpein;
                drow["Kschl"] = x.Kschl;
                drow["Kunnr"] = x.Kunnr;
                drow["Mandt"] = x.Mandt;
                drow["Matnr"] = x.Matnr;
                drow["Pltyp"] = x.Pltyp;
                drow["Valdt"] = x.Valdt;
                drow["Zterm"] = x.Zterm;
                dt.Rows.Add(drow);

            })).ToArray();
            Task.WaitAll(tasks);*/

            /*Parallel.ForEach(listMaterialPrices, new ParallelOptions() { MaxDegreeOfParallelism = 30 }, x => {

                DataRow drow = dt.NewRow();
                drow["Aedat"] = x.Aedat;
                drow["Aezet"] = x.Aezet;
                drow["Kbetr"] = x.Kbetr;
                drow["Kdgrp"] = x.Kdgrp;
                drow["Kmein"] = x.Kmein;
                drow["Konwa"] = x.Konwa;
                drow["Kpein"] = x.Kpein;
                drow["Kschl"] = x.Kschl;
                drow["Kunnr"] = x.Kunnr;
                drow["Mandt"] = x.Mandt;
                drow["Matnr"] = x.Matnr;
                drow["Pltyp"] = x.Pltyp;
                drow["Valdt"] = x.Valdt;
                drow["Zterm"] = x.Zterm;
                dt.Rows.Add(drow);

            });*/

            /*string json = Newtonsoft.Json.JsonConvert.SerializeObject(listMaterialPrices);
            DataTable dt = JsonConvert.DeserializeObject<DataTable>(json);*/

            /*try
            {
                SqlDataAdapter da = new SqlDataAdapter();
                da.InsertCommand = new SqlCommand("INSERT INTO [Web_Fiyat_SAP] ([Aedat],[Aezet],[Kbetr],[Kdgrp],[Kmein],[Konwa],[Kpein],[Kschl],[Kunnr],[Mandt],[Matnr],[Pltyp],[Valdt],[Zterm]) VALUES (@Aedat,@Aezet,@Kbetr,@Kdgrp,@Kmein,@Konwa,@Kpein,@Kschl,@Kunnr,@Mandt,@Matnr,@Pltyp,@Valdt,@Zterm)", conn);
                da.InsertCommand.Parameters.Add("@Aedat", SqlDbType.NVarChar, 255, "Aedat");
                da.InsertCommand.Parameters.Add("@Aezet", SqlDbType.NVarChar, 255, "Aezet");
                da.InsertCommand.Parameters.Add("@Kbetr", SqlDbType.Decimal, 8, "Kbetr");
                da.InsertCommand.Parameters.Add("@Kdgrp", SqlDbType.NVarChar, 255, "Kdgrp");
                da.InsertCommand.Parameters.Add("@Kmein", SqlDbType.NVarChar, 255, "Kmein");
                da.InsertCommand.Parameters.Add("@Konwa", SqlDbType.NVarChar, 255, "Konwa");
                da.InsertCommand.Parameters.Add("@Kpein", SqlDbType.Decimal, 8, "Kpein");
                da.InsertCommand.Parameters.Add("@Kschl", SqlDbType.NVarChar, 255, "Kschl");
                da.InsertCommand.Parameters.Add("@Kunnr", SqlDbType.NVarChar, 255, "Kunnr");
                da.InsertCommand.Parameters.Add("@Mandt", SqlDbType.NVarChar, 255, "Mandt");
                da.InsertCommand.Parameters.Add("@Matnr", SqlDbType.NVarChar, 255, "Matnr");
                da.InsertCommand.Parameters.Add("@Pltyp", SqlDbType.NVarChar, 255, "Pltyp");
                da.InsertCommand.Parameters.Add("@Valdt", SqlDbType.NVarChar, 255, "Valdt");
                da.InsertCommand.Parameters.Add("@Zterm", SqlDbType.NVarChar, 255, "Zterm");

                da.Update(dt);
            }
            catch (Exception ex)
            {

            }*/



            //conn.Open();
            /*Parallel.ForEach(listMaterialPrices, new ParallelOptions() { MaxDegreeOfParallelism = 4 }, x => {

                SqlCommand cmd = new SqlCommand("INSERT INTO [Web_Fiyat_SAP] " +
                    "(Aedat,Aezet,Kbetr,Kdgrp,Kmein,Konwa,Kpein,Kschl,Kunnr,Mandt,Matnr,Pltyp,Valdt,Zterm)" +
                    "VALUES (@Aedat,@Aezet,@Kbetr,@Kdgrp,@Kmein,@Konwa,@Kpein,@Kschl,@Kunnr,@Mandt,@Matnr,@Pltyp,@Valdt,@Zterm)", conn);
                cmd.CommandTimeout = 1000;
                cmd.Parameters.AddWithValue("@Aedat", x.Aedat);
                cmd.Parameters.AddWithValue("@Aezet", x.Aezet);
                cmd.Parameters.AddWithValue("@Kbetr", x.Kbetr);
                cmd.Parameters.AddWithValue("@Kdgrp", x.Kdgrp);
                cmd.Parameters.AddWithValue("@Kmein", x.Kmein);
                cmd.Parameters.AddWithValue("@Konwa", x.Konwa);
                cmd.Parameters.AddWithValue("@Kpein", x.Kpein);
                cmd.Parameters.AddWithValue("@Kschl", x.Kschl);
                cmd.Parameters.AddWithValue("@Kunnr", x.Kunnr);
                cmd.Parameters.AddWithValue("@Mandt", x.Mandt);
                cmd.Parameters.AddWithValue("@Matnr", x.Matnr);
                cmd.Parameters.AddWithValue("@Pltyp", x.Pltyp);
                cmd.Parameters.AddWithValue("@Valdt", x.Valdt);
                cmd.Parameters.AddWithValue("@Zterm", x.Zterm);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Hatalar.DoInsert(ex, "windows servis SAP fiyatlar");
                }
                finally
                {
                }

            });*/



            /*var tasks = listMaterialPrices.Select(x => Task.Factory.StartNew(() => {
                
            })).ToArray();
            Task.WaitAll(tasks);*/



            /*
            Parallel.For(0, listMaterialPrices.Length, i =>
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO [Web_Fiyat_SAP] " +
                "(Aedat,Aezet,Kbetr,Kdgrp,Kmein,Konwa,Kpein,Kschl,Kunnr,Mandt,Matnr,Pltyp,Valdt,Zterm)" +
                "VALUES (@Aedat,@Aezet,@Kbetr,@Kdgrp,@Kmein,@Konwa,@Kpein,@Kschl,@Kunnr,@Mandt,@Matnr,@Pltyp,@Valdt,@Zterm)", conn);
                cmd.CommandTimeout = 1000;
                cmd.Parameters.AddWithValue("@Aedat", listMaterialPrices[i].Aedat);
                cmd.Parameters.AddWithValue("@Aezet", listMaterialPrices[i].Aezet);
                cmd.Parameters.AddWithValue("@Kbetr", listMaterialPrices[i].Kbetr);
                cmd.Parameters.AddWithValue("@Kdgrp", listMaterialPrices[i].Kdgrp);
                cmd.Parameters.AddWithValue("@Kmein", listMaterialPrices[i].Kmein);
                cmd.Parameters.AddWithValue("@Konwa", listMaterialPrices[i].Konwa);
                cmd.Parameters.AddWithValue("@Kpein", listMaterialPrices[i].Kpein);
                cmd.Parameters.AddWithValue("@Kschl", listMaterialPrices[i].Kschl);
                cmd.Parameters.AddWithValue("@Kunnr", listMaterialPrices[i].Kunnr);
                cmd.Parameters.AddWithValue("@Mandt", listMaterialPrices[i].Mandt);
                cmd.Parameters.AddWithValue("@Matnr", listMaterialPrices[i].Matnr);
                cmd.Parameters.AddWithValue("@Pltyp", listMaterialPrices[i].Pltyp);
                cmd.Parameters.AddWithValue("@Valdt", listMaterialPrices[i].Valdt);
                cmd.Parameters.AddWithValue("@Zterm", listMaterialPrices[i].Zterm);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Hatalar.DoInsert(ex, "windows servis SAP fiyatlar");
                }
                finally
                {
                }
            });
            */
            //conn.Close();



            for (int i = 0; i < listMaterialPrices.Length; i++)
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO [Web_Fiyat_SAP] " +
                "(Aedat,Aezet,Kbetr,Kdgrp,Kmein,Konwa,Kpein,Kschl,Kunnr,Mandt,Matnr,Pltyp,Valdt,Zterm)" +
                "VALUES (@Aedat,@Aezet,@Kbetr,@Kdgrp,@Kmein,@Konwa,@Kpein,@Kschl,@Kunnr,@Mandt,@Matnr,@Pltyp,@Valdt,@Zterm)", conn);
                cmd.CommandTimeout = 1000;
                cmd.Parameters.AddWithValue("@Aedat", listMaterialPrices[i].Aedat);
                cmd.Parameters.AddWithValue("@Aezet", listMaterialPrices[i].Aezet);
                cmd.Parameters.AddWithValue("@Kbetr", listMaterialPrices[i].Kbetr);
                cmd.Parameters.AddWithValue("@Kdgrp", listMaterialPrices[i].Kdgrp);
                cmd.Parameters.AddWithValue("@Kmein", listMaterialPrices[i].Kmein);
                cmd.Parameters.AddWithValue("@Konwa", listMaterialPrices[i].Konwa);
                cmd.Parameters.AddWithValue("@Kpein", listMaterialPrices[i].Kpein);
                cmd.Parameters.AddWithValue("@Kschl", listMaterialPrices[i].Kschl);
                cmd.Parameters.AddWithValue("@Kunnr", listMaterialPrices[i].Kunnr);
                cmd.Parameters.AddWithValue("@Mandt", listMaterialPrices[i].Mandt);
                cmd.Parameters.AddWithValue("@Matnr", listMaterialPrices[i].Matnr);
                cmd.Parameters.AddWithValue("@Pltyp", listMaterialPrices[i].Pltyp);
                cmd.Parameters.AddWithValue("@Valdt", listMaterialPrices[i].Valdt);
                cmd.Parameters.AddWithValue("@Zterm", listMaterialPrices[i].Zterm);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Hatalar.DoInsert(ex, "windows servis SAP fiyatlar");
                }
                finally
                {
                    conn.Close();
                }
            }



            SqlCommand cmd10 = new SqlCommand("DROP TABLE [Web-Fiyat-Onceki] SELECT * INTO [Web-Fiyat-Onceki] FROM [dbo].[Web-Fiyat]", conn);
            cmd10.CommandTimeout = 1000;
            conn.Open();
            cmd10.ExecuteNonQuery();
            conn.Close();

            SqlCommand cmd2 = new SqlCommand("BEGIN TRANSACTION t_Transaction TRUNCATE TABLE [Web-Fiyat] INSERT INTO [Web-Fiyat] SELECT *,NULL,NULL,NULL FROM [Web_Fiyat_SAP_aktarim2] WITH (HOLDLOCK) COMMIT TRANSACTION t_Transaction", conn);
            cmd2.CommandTimeout = 1000;
            conn.Open();
            cmd2.ExecuteNonQuery();
            conn.Close();

            SqlCommand cmd3 = new SqlCommand("DELETE FROM [Web-Fiyat] WHERE TIP = 21 " +
                "INSERT INTO [Web-Fiyat] ([TIP],[GMREF],[GRUP KOD],[OZEL KOD],[HK],[OZEL ACIK],[REY KOD],[RK],[REY ACIK],[ITEMREF],[MAL ACIK],[FIYAT],[ISK1],[ISK2],[ISK3],[ISK4],[ISK5],[ISK6],[ISK7],[ISK8],[ISK9],[ISK10],[NET],[NET+KDV],[VADE],[KAMKARTREF],[ODEME_GUN],[ODEME_TARIH])" +
                "SELECT 21,0,[Web-Fiyat].[GRUP KOD],[Web-Fiyat].[OZEL KOD],[Web-Fiyat].[HK],[Web-Fiyat].[OZEL ACIK],[Web-Fiyat].[REY KOD],[Web-Fiyat].[RK],[Web-Fiyat].[REY ACIK],[Web-Fiyat].[ITEMREF],[Web-Fiyat].[MAL ACIK],FIYAT,0,0,0,0,0,0,0,0,0,0,FIYAT - (FIYAT / 100 * (SELECT Xml_Haric_Kar FROM tblWebGenel)),(FIYAT - (FIYAT / 100 * (SELECT Xml_Haric_Kar FROM tblWebGenel))) * ((100 + KDV) / 100),[VADE],[KAMKARTREF],[ODEME_GUN],[ODEME_TARIH]FROM [Web-Fiyat] INNER JOIN [Web-Malzeme-Full] ON [Web-Fiyat].ITEMREF = [Web-Malzeme-Full].ITEMREF WHERE TIP = 7"
                , conn);
            cmd3.CommandTimeout = 1000;
            conn.Open();
            cmd3.ExecuteNonQuery();
            conn.Close();



            DateTime dt2 = DateTime.Now;

            MessageBox.Show(dt1.ToString() + " " + dt2.ToString());

            conn.Open(); cmdLog.Parameters.AddWithValue("@dtBitis", DateTime.Now); cmdLog.ExecuteNonQuery(); conn.Close();
        }

        private void HataYaz(SqlConnection conn, string tablo, string key1, string key2, string key3, string key4, string key5, string log, DateTime baslangic, DateTime bitis)
        {
            SqlCommand cmdLog = new SqlCommand("INSERT INTO [SAP_HATA_LOG] ([dtZaman],[strTablo],[strKey1],[strKey2],[strKey3],[strKey4],[strKey5],[strLog],dtBaslangic,dtBitis) VALUES (@dtZaman,@strTablo,@strKey1,@strKey2,@strKey3,@strKey4,@strKey5,@strLog,@dtBaslangic,@dtBitis)", conn);
            cmdLog.Parameters.AddWithValue("@dtZaman", DateTime.Now);
            cmdLog.Parameters.AddWithValue("@strTablo", tablo);
            cmdLog.Parameters.AddWithValue("@strKey1", key1);
            cmdLog.Parameters.AddWithValue("@strKey2", key2);
            cmdLog.Parameters.AddWithValue("@strKey3", key3);
            cmdLog.Parameters.AddWithValue("@strKey4", key4);
            cmdLog.Parameters.AddWithValue("@strKey5", key5);
            cmdLog.Parameters.AddWithValue("@strLog", log);
            cmdLog.Parameters.AddWithValue("@dtBaslangic", baslangic);
            cmdLog.Parameters.AddWithValue("@dtBitis", bitis);
            cmdLog.ExecuteNonQuery();
        }

        private DateTime MaxTarihGetir(SqlConnection conn, string alan)
        {
            SqlCommand cmd = new SqlCommand("SELECT " + alan + " FROM [tblWebGenel]", conn);
            conn.Open();
            DateTime donendeger = Convert.ToDateTime(cmd.ExecuteScalar());
            conn.Close();

            return donendeger;
        }

        private void MaxTarihYaz(SqlConnection conn, string alan, DateTime bitistarih)
        {
            SqlCommand cmd = new SqlCommand("UPDATE [tblWebGenel] SET " + alan + " = @Deger", conn);
            cmd.Parameters.Add("@Deger", SqlDbType.DateTime).Value = bitistarih;
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        private void TarihSaat(DateTime maxtarih, DateTime cekilecektarih, out string tarih, out string saat)
        {
            tarih = cekilecektarih.Year.ToString() +
                (cekilecektarih.Month.ToString().Length == 1 ? "0" + cekilecektarih.Month.ToString() : cekilecektarih.Month.ToString()) +
                (cekilecektarih.Day.ToString().Length == 1 ? "0" + cekilecektarih.Day.ToString() : cekilecektarih.Day.ToString());

            if (Convert.ToDateTime(maxtarih.ToShortDateString()) == Convert.ToDateTime(cekilecektarih.ToShortDateString()))
                saat = cekilecektarih.AddMinutes(-30).ToShortTimeString() + ":00"; // -30 değişirse gece fonksiyonunun saati olan 00:30:00 ıda değiştir
            else
                saat = "00:00:00";
        }

        private void GetSatisJob()
        {
            SqlConnection conn = new SqlConnection("Server=.; Database=KurumsalWebSAP; User Id=sa; Password=sdl580g5p9+-; Trusted_Connection=False;");
            SqlCommand cmdSatisJob = new SqlCommand("msdb.dbo.sp_start_job", conn);
            cmdSatisJob.CommandTimeout = 1000;
            cmdSatisJob.CommandType = CommandType.StoredProcedure;
            cmdSatisJob.Parameters.AddWithValue("@job_name", "Web_Satis_Yeni");

            DateTime bastarih = DateTime.Now;
            string hataa = string.Empty;
            try
            {
                conn.Open();
                cmdSatisJob.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                hataa = ex.Message;
            }
            finally
            {
                conn.Close();
                LogYaz(conn, "satis yeni", hataa != string.Empty ? false : true, hataa, bastarih, DateTime.Now);
            }
        }

        private void SatisUpdate(SqlConnection conn)
        {
            DateTime baslangic = DateTime.Now;
            string hata = string.Empty;

            try
            {
                SqlCommand cmd = new SqlCommand("sp_SAP_UPDATE", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 3600;
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                hata = ex.Message;
                conn.Close();
            }

            LogYaz(conn, "satis update", hata == string.Empty ? true : false, hata, baslangic, DateTime.Now);
        }

        private void LogYaz(SqlConnection conn, string servis, bool basarili, string log, DateTime baslangic, DateTime bitis)
        {
            SqlCommand cmdLog = new SqlCommand("INSERT INTO [SAP_SERVIS_LOG] ([dtZaman],[strServis],blBasarili,[strLog],dtBaslangic,dtBitis) VALUES (@dtZaman,@strServis,@blBasarili,@strLog,@dtBaslangic,@dtBitis)", conn);
            cmdLog.Parameters.AddWithValue("@dtZaman", DateTime.Now);
            cmdLog.Parameters.AddWithValue("@strServis", servis);
            cmdLog.Parameters.AddWithValue("@blBasarili", basarili);
            cmdLog.Parameters.AddWithValue("@strLog", log);
            cmdLog.Parameters.AddWithValue("@dtBaslangic", baslangic);
            cmdLog.Parameters.AddWithValue("@dtBitis", bitis);
            conn.Open();
            cmdLog.ExecuteNonQuery();
            conn.Close();
        }

        private void tmr_Tick(object sender, EventArgs e)
        {
            try
            {
                WebResponse wr = WebRequest.Create("https://www.sultanlar.com.tr/sultanlarui/index.htm").GetResponse();
                Stream stream = wr.GetResponseStream();
                StreamReader strR = new StreamReader(stream, Encoding.GetEncoding("iso-8859-9"));
                string sayfa = strR.ReadToEnd();
                strR.Close();
                wr.Close();

                int baslangic = sayfa.IndexOf("<TR><TD><B>Version:</B></TD><TD WIDTH=\"5\"><SPACER TYPE=\"block\" WIDTH=\"10\" /></TD><TD>") + 85;
                int bitis = sayfa.IndexOf("</TD>", baslangic);
                string surum = string.Empty;
                if (baslangic > 84 && bitis > 85)
                    surum = sayfa.Substring(baslangic, bitis - baslangic);

                string programsurum = ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString(4);
                
                if (surum != programsurum)
                {
                    this.Text = this.Text.Substring(0, 24) + " [Yeni sürüm mevcut]";
                    //MessageBox.Show("Uygulamanın daha yeni bir sürümü mevcut, lütfen uygulamayı kapatın. Tekrar açtığınızda otomatik güncellenecektir.", "Güncelleme Uyarısı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                Hatalar.DoInsert(ex, "frmAna sürüm kontrol. kul: " + KAdi);
            }
        }

        private void RssKenton(string url)
        {
            List<Tarifler> tarifler = new List<Tarifler>();
            Tarifler trf = new Tarifler();

            string tur = url == "https://www.kenton.com.tr/kategori/tarifler/feed/" ? "<span id='rssfeedtarifxml'></span>" : "<span id='rssfeedtatlitarifxml'></span>";

            XmlTextReader reader = new XmlTextReader(url);
            bool oku = false;
            bool itemicinde = false;
            bool baslik = true;
            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element:
                        //while (reader.MoveToNextAttribute())
                        //    MessageBox.Show(" " + reader.Name + "='" + reader.Value + "'");
                        if (reader.Name == "item")
                            itemicinde = true;
                        if (reader.Name == "title" || reader.Name == "pubDate" || reader.Name == "content:encoded")
                            oku = true;
                        break;

                    case XmlNodeType.CDATA: // içindekiler
                        if (oku && itemicinde)
                        {
                            string malzemeler = string.Empty;
                            string icerik = string.Empty;
                            string img = string.Empty;
                            string img2 = string.Empty;

                            int malzemeBas = reader.Value.IndexOf("<div class=\"wpb_wrapper\">", reader.Value.IndexOf("tarif-ozel")) + 25;
                            int malzemeBit = reader.Value.IndexOf("</div>", malzemeBas);
                            malzemeler = reader.Value.Substring(malzemeBas, malzemeBit - malzemeBas).Trim();
                            trf.strMalzemeler = tur + malzemeler;

                            int icerikBas = reader.Value.IndexOf("<div class=\"wpb_wrapper\">", reader.Value.IndexOf("justify")) + 25;
                            int icerikBit = reader.Value.IndexOf("</div>", icerikBas);
                            icerik = reader.Value.Substring(icerikBas, icerikBit - icerikBas).Trim();
                            trf.strHazirlanis = icerik;

                            int baskaimgvarmi = reader.Value.IndexOf("title=\"satınal\"");
                            int imgBas1 = 0;
                            if (baskaimgvarmi > -1)
                                imgBas1 = reader.Value.IndexOf("<img ", baskaimgvarmi);
                            else
                                imgBas1 = reader.Value.IndexOf("<img ");
                            int imgBas = reader.Value.IndexOf("src=\"", imgBas1) + 5;
                            int imgBit = reader.Value.IndexOf("\"", imgBas);
                            img = reader.Value.Substring(imgBas, imgBit - imgBas).Trim();
                            //trf.binResim = Resim.ImageToByte(Resim.ResimKucult(Resim.ByteToImage(new WebClient().DownloadData(img)), 400));

                            int img2Bas1 = reader.Value.IndexOf("<img ", imgBit);
                            if (img2Bas1 > -1)
                            {
                                int img2Bas = reader.Value.IndexOf("src=\"", img2Bas1) + 5;
                                int img2Bit = reader.Value.IndexOf("\"", img2Bas);
                                img2 = reader.Value.Substring(img2Bas, img2Bit - img2Bas).Trim();
                                //trf.binResimUrunler = Resim.ImageToByte(Resim.ResimKucult(Resim.ByteToImage(new WebClient().DownloadData(img2)), 400));
                            }

                            oku = false;
                        }
                        break;

                    case XmlNodeType.Text: // birincisi başlık ikincisi tarif
                        if (oku && itemicinde)
                        {
                            if (baslik)
                            {
                                trf.strBaslik = StringParcalama.IlkHarfBuyuk(reader.Value);
                                baslik = false;
                            }
                            else
                            {
                                trf.dtTarih = Convert.ToDateTime(reader.Value);
                                baslik = true;
                            }
                            oku = false;
                        }
                        break;

                    case XmlNodeType.EndElement:
                        if (reader.Name == "item")
                        {
                            if (trf.dtTarih <= Tarifler.GetLastObjectTime(url == "https://www.kenton.com.tr/kategori/tatli-tarifleri/feed/"))
                            {
                                //return;
                            }
                            else
                            {
                                trf.strUrunlerLink = string.Empty;
                                trf.blOnay = true;
                                trf.intUyeID = 1;
                                //trf.DoInsert();
                                tarifler.Add(trf);
                            }
                            trf = new Tarifler();
                        }
                        break;
                }
            }

            for (int i = 0; i < tarifler.Count; i++)
                MessageBox.Show(tarifler[i].strBaslik);
        }

        private void RssVideo(string url)
        {
            List<Videolar> tarifler = new List<Videolar>();
            Videolar trf = new Videolar();

            XmlTextReader reader = new XmlTextReader(url);
            bool oku = false;
            bool itemicinde = false;
            string nerede = "baslik";
            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element:
                        if (reader.Name == "item")
                            itemicinde = true;
                        if (reader.Name == "title" || reader.Name == "link" || reader.Name == "pubDate" || reader.Name == "content:encoded")
                            oku = true;
                        break;

                    case XmlNodeType.CDATA: // içindekiler
                        if (oku && itemicinde)
                        {
                            string video = string.Empty;

                            int videoBas = reader.Value.IndexOf("https://www.youtube.com/embed/") + 30;
                            video = reader.Value.Substring(videoBas, 11).Trim();
                            trf.strVideo = video;

                            oku = false;
                        }
                        break;

                    case XmlNodeType.Text: // birincisi başlık ikincisi tarih
                        if (oku && itemicinde)
                        {
                            if (nerede == "baslik")
                            {
                                trf.strBaslik = StringParcalama.IlkHarfBuyuk(reader.Value);
                                nerede = "link";
                            }
                            else if (nerede == "link")
                            {
                                trf.strLink = StringParcalama.IlkHarfBuyuk(reader.Value);
                                nerede = "";
                            }
                            else
                            {
                                trf.dtTarih = Convert.ToDateTime(reader.Value);
                                nerede = "baslik";
                            }
                            oku = false;
                        }
                        break;

                    case XmlNodeType.EndElement:
                        if (reader.Name == "item")
                        {
                            trf.intTarifID = 0;
                            trf.intUyeID = 1;
                            //trf.DoInsert();
                            tarifler.Add(trf);
                            trf = new Videolar();
                        }

                        break;
                }
            }

            for (int i = 0; i < tarifler.Count; i++)
                MessageBox.Show(tarifler[i].strBaslik + " " + tarifler[i].dtTarih.ToShortDateString());
        }



        private void cetinkaya(int AktiviteID, int Ay, int Yil)
        {
            DataTable dt = new DataTable();
            AktivitelerDetay.GetObjectsByAktiviteID(dt, AktiviteID);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                decimal fiyat = FiyatlarTP.GetFiyat(Convert.ToInt32(dt.Rows[i]["intUrunID"]), 22, Yil, Ay);
                double kdv = Urunler.GetProductKDV(Convert.ToInt32(dt.Rows[i]["intUrunID"]));
                dt.Rows[i]["mnBirimFiyatKDVli"] = fiyat * ((Convert.ToDecimal(kdv) + 100) / 100);
                decimal dusulmusfiyat = Convert.ToDecimal(dt.Rows[i]["mnBirimFiyatKDVli"]) - ((Convert.ToDecimal(dt.Rows[i]["mnBirimFiyatKDVli"]) / 100) * Convert.ToDecimal(dt.Rows[i]["strAciklama1"]));
                decimal dusulmusfiyat1 = dusulmusfiyat - ((dusulmusfiyat / 100) * Convert.ToDecimal(dt.Rows[i]["strAciklama2"]));
                decimal dusulmusfiyat2 = dusulmusfiyat1 - ((dusulmusfiyat1 / 100) * Convert.ToDecimal(dt.Rows[i]["strAciklama3"]));
                if (dusulmusfiyat2 == 0)
                    dt.Rows[i]["flEkIsk"] = 0.0;
                else
                    dt.Rows[i]["flEkIsk"] = (1 - (Convert.ToDouble(dt.Rows[i]["mnDusulmusBirimFiyatKDVli"]) / Convert.ToDouble(dusulmusfiyat2))) * 100;

                //decimal saglama = dusulmusfiyat2 - ((dusulmusfiyat2 / 100) * Convert.ToDecimal(dt.Rows[i]["flEkIsk"]));

                //MessageBox.Show("birim fiyat: " + dt.Rows[i]["mnBirimFiyatKDVli"].ToString() + " ek isk: " + dt.Rows[i]["flEkIsk"] + " saglama: " + saglama.ToString());

                AktivitelerDetay aktdet = AktivitelerDetay.GetObject(Convert.ToInt64(dt.Rows[i]["pkID"]));
                aktdet.mnBirimFiyatKDVli = Convert.ToDecimal(dt.Rows[i]["mnBirimFiyatKDVli"]);
                aktdet.flEkIsk = Convert.ToDouble(dt.Rows[i]["flEkIsk"]);
                aktdet.strAciklama4 = "0";
                aktdet.DoUpdate();
            }
        }

        private void AcilisSecenekleri()
        {
            /*RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Sultanlar", true);

            if (key != null)
            {
                if (key.GetValue("SolMenu").ToString() == "evet")
                {
                    treeView1.Visible = true;
                    cbSolMenu.Checked = true;
                }
                else if (key.GetValue("SolMenu").ToString() == "hayir")
                {
                    treeView1.Visible = false;
                    cbSolMenu.Checked = false;
                }
            }
            else
            {
                RegistryKey key1 = Registry.CurrentUser.CreateSubKey(@"Software\Sultanlar");
                RegistryKey key2 = Registry.CurrentUser.OpenSubKey(@"Software\Sultanlar", true);
                key2.SetValue("SolMenu", "evet");
                treeView1.Visible = true;
            }*/

            if (ApplicationDeployment.IsNetworkDeployed)
            {
                lblSurum.Text = ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString();
                this.Text = "Sultanlar UI - " + lblSurum.Text;
            }
            
            if (!Directory.Exists(Application.StartupPath + "\\temp"))
                Directory.CreateDirectory(Application.StartupPath + "\\temp");
            if (!Directory.Exists(Application.StartupPath + "\\temp\\Sultanlar"))
                Directory.CreateDirectory(Application.StartupPath + "\\temp\\Sultanlar");
        }
        //
        //
        private void FormuAktifEt(string formadi)
        {
            for (int i = 0; i < menuStrip1.Items.Count; i++)
            {
                if (menuStrip1.Items[i].Name == formadi)
                {
                    menuStrip1.Items[i].Enabled = true;
                }
                ToolStripMenuItem tsmi = (ToolStripMenuItem)menuStrip1.Items[i];

                if (tsmi.DropDownItems.Count > 0)
                {
                    for (int j = 0; j < tsmi.DropDownItems.Count; j++)
                    {
                        if (tsmi.DropDownItems[j].Name == formadi)
                        {
                            tsmi.DropDownItems[j].Enabled = true;
                        }
                        ToolStripMenuItem tsmi2 = (ToolStripMenuItem)tsmi.DropDownItems[j];

                        if (tsmi2.DropDownItems.Count > 0)
                        {
                            for (int k = 0; k < tsmi2.DropDownItems.Count; k++)
                            {
                                if (tsmi2.DropDownItems[k].Name == formadi)
                                {
                                    tsmi2.DropDownItems[k].Enabled = true;
                                }
                                //ToolStripMenuItem tsmi3 = (ToolStripMenuItem)tsmi2.DropDownItems[k];
                            }
                        }
                    }
                }
            }
        }
        //
        //
        public void FormKapanirken(string formadi)
        {
            foreach (ToolStripItem tsi in statusStrip1.Items)
            {
                if (tsi.Name == formadi)
                {
                    statusStrip1.Items.Remove(tsi);
                    return;
                }
            }
        }
        //
        //
        //
        // Olaylar:
        //
        private void frm_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormKapanirken(((Form)sender).Name);
        }
        //
        //
        #region MenuItemClick
        private void haberlerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmHaberler")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmHaberler frm = new frmHaberler();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();
            frm.BringToFront();

            ToolStripButton lll = new ToolStripButton("Haberler");
            lll.Name = "frmHaberler";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void tedarikçilerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmTedarikciler")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmTedarikciler frm = new frmTedarikciler();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();

            ToolStripButton lll = new ToolStripButton("Tedarikçiler");
            lll.Name = "frmTedarikciler";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void başvurularToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmBasvurular")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmBasvurular frm = new frmBasvurular(KAdi);
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();

            ToolStripButton lll = new ToolStripButton("Başvurular");
            lll.Name = "frmBasvurular";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void işİstekleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmArananGorevler")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmArananGorevler frm = new frmArananGorevler();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();

            ToolStripButton lll = new ToolStripButton("Eleman Talepleri");
            lll.Name = "frmArananGorevler";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void görevlerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmGorevler")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmGorevler frm = new frmGorevler();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();

            ToolStripButton lll = new ToolStripButton("Görevler");
            lll.Name = "frmGorevler";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void departmanlarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmDepartmanlar")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmDepartmanlar frm = new frmDepartmanlar();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();

            ToolStripButton lll = new ToolStripButton("Departmanlar");
            lll.Name = "frmDepartmanlar";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void yetkilerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmYetkiler")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmYetkiler frm = new frmYetkiler();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();

            ToolStripButton lll = new ToolStripButton("Yetkiler");
            lll.Name = "frmYetkiler";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void hatalarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmHatalar")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmHatalar frm = new frmHatalar();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();

            ToolStripButton lll = new ToolStripButton("Loglar");
            lll.Name = "frmHatalar";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void nöbetçiEczanelerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmNobetciEczaneler")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmNobetciEczaneler frm = new frmNobetciEczaneler();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();

            ToolStripButton lll = new ToolStripButton("Nöbetçi Eczaneler");
            lll.Name = "frmNobetciEczaneler";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void araçlarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmAraclar")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmAraclar frm = new frmAraclar();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();

            ToolStripButton lll = new ToolStripButton("Araçlar");
            lll.Name = "frmAraclar";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void personellerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmPersoneller")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmPersoneller frm = new frmPersoneller();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();

            ToolStripButton lll = new ToolStripButton("Personeller");
            lll.Name = "frmPersoneller";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void araçGiderleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmAracGiderleri")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmAracGiderleri frm = new frmAracGiderleri();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();

            ToolStripButton lll = new ToolStripButton("Araç Giderleri");
            lll.Name = "frmAracGiderleri";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void broşürHazırlamaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmBrosur")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmBrosur frm = new frmBrosur();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();

            ToolStripButton lll = new ToolStripButton("Broşür Hazırlama");
            lll.Name = "frmBrosur";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void kampanyaHazırlamaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmKampanya")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmKampanya frm = new frmKampanya();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();

            ToolStripButton lll = new ToolStripButton("Kampanya Hazırlama");
            lll.Name = "frmKampanya";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void markalarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmAracMarkalari")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmAracMarkalari frm = new frmAracMarkalari();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();

            ToolStripButton lll = new ToolStripButton("Markalar");
            lll.Name = "frmAracMarkalari";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void türlerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmAracTurleri")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmAracTurleri frm = new frmAracTurleri();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();

            ToolStripButton lll = new ToolStripButton("Türler");
            lll.Name = "frmAracTurleri";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void siparişlerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmTekUrunSiparisler")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmTekUrunSiparisler frm = new frmTekUrunSiparisler();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();

            ToolStripButton lll = new ToolStripButton("Tek Ürün Satışı : Siparişler");
            lll.Name = "frmTekUrunSiparisler";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void genelBilgilerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmTekUrunGenel")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmTekUrunGenel frm = new frmTekUrunGenel();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();

            ToolStripButton lll = new ToolStripButton("Tek Ürün Satışı : Genel Bilgiler");
            lll.Name = "frmTekUrunGenel";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void siparişDurumlarıListesiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmTekUrunSiparisDurumlari")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmTekUrunSiparisDurumlari frm = new frmTekUrunSiparisDurumlari();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();

            ToolStripButton lll = new ToolStripButton("Tek Ürün Satışı : Sipariş Durumları Listesi");
            lll.Name = "frmTekUrunSiparisDurumlari";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void kargoŞirketleriListesiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmTekUrunKargoSirketleri")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmTekUrunKargoSirketleri frm = new frmTekUrunKargoSirketleri();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();

            ToolStripButton lll = new ToolStripButton("Tek Ürün Satışı : Kargo Şirketleri Listesi");
            lll.Name = "frmTekUrunKargoSirketleri";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void üyelerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmINTERNETmusteriler")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmINTERNETmusteriler frm = new frmINTERNETmusteriler();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();

            ToolStripButton lll = new ToolStripButton("Üyeler");
            lll.Name = "frmINTERNETmusteriler";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void üyeGruplarıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmINTERNETuyegruplari")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmINTERNETuyegruplari frm = new frmINTERNETuyegruplari();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();

            ToolStripButton lll = new ToolStripButton("Üye Grupları");
            lll.Name = "frmINTERNETuyegruplari";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void cariHesapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmFinansCariHesapHareketler")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmFinansCariHesapHareketler frm = new frmFinansCariHesapHareketler();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();

            ToolStripButton lll = new ToolStripButton("Finans : Tahsilat Hareketleri");
            lll.Name = "frmFinansCariHesapHareketler";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void cHEkstresiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmCHEkstresi")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmCHEkstresi frm = new frmCHEkstresi();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();

            ToolStripButton lll = new ToolStripButton("Finans : C/H Ekstresi");
            lll.Name = "frmCHEkstresi";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void fiyatListeleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmINTERNETfiyatlisteleri")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmINTERNETfiyatlisteleri frm = new frmINTERNETfiyatlisteleri();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();

            ToolStripButton lll = new ToolStripButton("Web Satış Bölümü : Fiyat Listeleri");
            lll.Name = "frmINTERNETfiyatlisteleri";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void üyeKayıtFormuYetkileriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmUyeKayitFormuYetkileri")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmUyeKayitFormuYetkileri frm = new frmUyeKayitFormuYetkileri();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();

            ToolStripButton lll = new ToolStripButton("Üye Kayıt Formu Yetkileri");
            lll.Name = "frmUyeKayitFormuYetkileri";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void resimlerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmINTERNETresimler")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmINTERNETresimler frm = new frmINTERNETresimler();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();

            ToolStripButton lll = new ToolStripButton("Resimler");
            lll.Name = "frmINTERNETresimler";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void epostaGöndermeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmEpostaGonderme")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmEpostaGonderme frm = new frmEpostaGonderme();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();

            ToolStripButton lll = new ToolStripButton("Eposta Gönderme");
            lll.Name = "frmEpostaGonderme";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void mesajlarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmINTERNETmesajlar")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmINTERNETmesajlar frm = new frmINTERNETmesajlar();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();

            ToolStripButton lll = new ToolStripButton("Mesajlar");
            lll.Name = "frmINTERNETmesajlar";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void şifreSıfırlamaTalepleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmINTERNETmusterisifresifirlamatalepleri")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmINTERNETmusterisifresifirlamatalepleri frm = new frmINTERNETmusterisifresifirlamatalepleri();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();

            ToolStripButton lll = new ToolStripButton("Şifre Sıfırlama Talepleri");
            lll.Name = "frmINTERNETmusterisifresifirlamatalepleri";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void iadelerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmINTERNETiadeler")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmINTERNETiadeler frm = new frmINTERNETiadeler();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();

            ToolStripButton lll = new ToolStripButton("İadeler");
            lll.Name = "frmINTERNETiadeler";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void webSanalPosİşlemleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmFinansSanalPos")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmFinansSanalPos frm = new frmFinansSanalPos();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();

            ToolStripButton lll = new ToolStripButton("Finans : Web Sanal Pos İşlemleri");
            lll.Name = "frmFinansSanalPos";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void satışTemsilcisiŞeflerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmINTERNETsatistemsilcilerisefler")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmINTERNETsatistemsilcilerisefler frm = new frmINTERNETsatistemsilcilerisefler();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();

            ToolStripButton lll = new ToolStripButton("Satış Temsilcisi Şefler");
            lll.Name = "frmINTERNETsatistemsilcilerisefler";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void hizmetlerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmINTERNETsonradanhizmet")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmINTERNETsonradanhizmet frm = new frmINTERNETsonradanhizmet();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();

            ToolStripButton lll = new ToolStripButton("Hizmetler");
            lll.Name = "frmINTERNETsonradanhizmet";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void satışTemsilcisiCariHesapEklemeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmFinansCariHesapEklemeCikarma")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmFinansCariHesapEklemeCikarma frm = new frmFinansCariHesapEklemeCikarma();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();

            ToolStripButton lll = new ToolStripButton("Satış Temsilcisi Cari Hesap Ekleme");
            lll.Name = "frmFinansCariHesapEklemeCikarma";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void primOranlarıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmPrimler")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmPrimler frm = new frmPrimler();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();
            frm.BringToFront();

            ToolStripButton lll = new ToolStripButton("Primler");
            lll.Name = "frmPrimler";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void malzemeKategoriMarkaSeçimleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmINTERNETmalzemekategorimarka")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmINTERNETmalzemekategorimarka frm = new frmINTERNETmalzemekategorimarka();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();
            frm.BringToFront();

            ToolStripButton lll = new ToolStripButton("Malzeme Kategori Marka Seçimleri");
            lll.Name = "frmINTERNETmalzemekategorimarka";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void eTicaretSiparişleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmINTERNETentegra")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmINTERNETentegra frm = new frmINTERNETentegra();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();
            frm.BringToFront();

            ToolStripButton lll = new ToolStripButton("E-Ticaret Siparişleri");
            lll.Name = "frmINTERNETentegra";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void müşterilerVeAltCarilerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmINTERNETticaripazarlamamusteriler")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmINTERNETticaripazarlamamusteriler frm = new frmINTERNETticaripazarlamamusteriler();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();
            frm.BringToFront();

            ToolStripButton lll = new ToolStripButton("Ticari Pazarlama : Müşteriler ve Alt Cariler");
            lll.Name = "frmINTERNETticaripazarlamamusteriler";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void stokKartlarıVeFiyatlarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmINTERNETticaripazarlamastoklar")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmINTERNETticaripazarlamastoklar frm = new frmINTERNETticaripazarlamastoklar();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();
            frm.BringToFront();

            ToolStripButton lll = new ToolStripButton("Ticari Pazarlama : Stok Kartları ve Fiyatlar");
            lll.Name = "frmINTERNETticaripazarlamastoklar";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void aktivitelerToolStripMenuItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmINTERNETticaripazarlamaaktiviteler")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmINTERNETticaripazarlamaaktiviteler frm = new frmINTERNETticaripazarlamaaktiviteler();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();
            frm.BringToFront();

            ToolStripButton lll = new ToolStripButton("TP:Aktiviteler (TÜMÜ)");
            lll.Name = "frmINTERNETticaripazarlamaaktiviteler";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void hizmetBedelleriToolStripMenuItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmINTERNETticaripazarlamahizmetbedelleri")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmINTERNETticaripazarlamahizmetbedelleri frm = new frmINTERNETticaripazarlamahizmetbedelleri();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();
            frm.BringToFront();

            ToolStripButton lll = new ToolStripButton("TP:Hizmet Bedelleri (TÜMÜ)");
            lll.Name = "frmINTERNETticaripazarlamahizmetbedelleri";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void satışRaporuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmINTERNETticaripazarlamasatisrapor")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmINTERNETticaripazarlamasatisrapor frm = new frmINTERNETticaripazarlamasatisrapor();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();
            frm.BringToFront();

            ToolStripButton lll = new ToolStripButton("TP:Satış Raporu");
            lll.Name = "frmINTERNETticaripazarlamasatisrapor";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void anlaşmalarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmINTERNETticaripazarlamaanlasmalar")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmINTERNETticaripazarlamaanlasmalar frm = new frmINTERNETticaripazarlamaanlasmalar();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();
            frm.BringToFront();

            ToolStripButton lll = new ToolStripButton("TP:Anlaşmalar (TÜMÜ)");
            lll.Name = "frmINTERNETticaripazarlamaanlasmalar";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void lojistikFirmalarıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmAT2lojistikfirmalar")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmAT2lojistikfirmalar frm = new frmAT2lojistikfirmalar();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();
            frm.BringToFront();

            ToolStripButton lll = new ToolStripButton("Lojistik Firmaları");
            lll.Name = "frmAT2lojistikfirmalar";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void bölgelerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmAT2bolgeler")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmAT2bolgeler frm = new frmAT2bolgeler();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();
            frm.BringToFront();

            ToolStripButton lll = new ToolStripButton("Bölgeler");
            lll.Name = "frmAT2bolgeler";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void araçTipleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmAT2aractipler")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmAT2aractipler frm = new frmAT2aractipler();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();
            frm.BringToFront();

            ToolStripButton lll = new ToolStripButton("Araç Tipleri");
            lll.Name = "frmAT2aractipler";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void şoförVeMuavinlerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmAT2soforlermuavinler")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmAT2soforlermuavinler frm = new frmAT2soforlermuavinler();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();
            frm.BringToFront();

            ToolStripButton lll = new ToolStripButton("Şoför ve Muavinler");
            lll.Name = "frmAT2soforlermuavinler";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void araçlarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmAT2araclar")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmAT2araclar frm = new frmAT2araclar();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();
            frm.BringToFront();

            ToolStripButton lll = new ToolStripButton("Araçlar");
            lll.Name = "frmAT2araclar";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void araçBedelleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmAT2aracbedelleri")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmAT2aracbedelleri frm = new frmAT2aracbedelleri();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();
            frm.BringToFront();

            ToolStripButton lll = new ToolStripButton("Araç Bedelleri");
            lll.Name = "frmAT2aracbedelleri";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void siparişToplamaPersonelleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmAT2personeller")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmAT2personeller frm = new frmAT2personeller();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();
            frm.BringToFront();

            ToolStripButton lll = new ToolStripButton("Sipariş Toplama Personelleri");
            lll.Name = "frmAT2personeller";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void rotalarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmAT2rotalar")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmAT2rotalar frm = new frmAT2rotalar();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();
            frm.BringToFront();

            ToolStripButton lll = new ToolStripButton("Rotalar");
            lll.Name = "frmAT2rotalar";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void rotamusteribağlantılarıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmAT2rotamusteri")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmAT2rotamusteri frm = new frmAT2rotamusteri();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();
            frm.BringToFront();

            ToolStripButton lll = new ToolStripButton("Rota Müşteri Bağlantıları");
            lll.Name = "frmAT2rotamusteri";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void ürünFiyatTipiBağlantılarıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmINTERNETfiyaturunbaglanti")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmINTERNETfiyaturunbaglanti frm = new frmINTERNETfiyaturunbaglanti();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();
            frm.BringToFront();

            ToolStripButton lll = new ToolStripButton("Ürün Fiyat Tipi Bağlantıları");
            lll.Name = "frmINTERNETfiyaturunbaglanti";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void depoDenetlemeleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmDepoDenetlemeler")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmDepoDenetlemeler frm = new frmDepoDenetlemeler();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();
            frm.BringToFront();

            ToolStripButton lll = new ToolStripButton("Depo Denetlemeleri");
            lll.Name = "frmDepoDenetlemeler";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void ürünAktifPasifSeçimiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmINTERNETurunaktifpasif")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmINTERNETurunaktifpasif frm = new frmINTERNETurunaktifpasif();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();
            frm.BringToFront();

            ToolStripButton lll = new ToolStripButton("Ürün Aktif-Pasif Seçimi");
            lll.Name = "frmINTERNETurunaktifpasif";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void bayiCiroPrimleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmINTERNETticaripazarlamabayiciroprimleri")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmINTERNETticaripazarlamabayiciroprimleri frm = new frmINTERNETticaripazarlamabayiciroprimleri();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();
            frm.BringToFront();

            ToolStripButton lll = new ToolStripButton("Bayi Ciro Primleri");
            lll.Name = "frmINTERNETticaripazarlamabayiciroprimleri";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void hedeflerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmINTERNEThedef")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmINTERNEThedef frm = new frmINTERNEThedef();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();
            frm.BringToFront();

            ToolStripButton lll = new ToolStripButton("Hedefler");
            lll.Name = "frmINTERNEThedef";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void hizmetBedelleri2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmINTERNETticaripazarlamahizmetbedelleridd")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmINTERNETticaripazarlamahizmetbedelleridd frm = new frmINTERNETticaripazarlamahizmetbedelleridd();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();
            frm.BringToFront();

            ToolStripButton lll = new ToolStripButton("Hizmet Bedelleri 2");
            lll.Name = "frmINTERNETticaripazarlamahizmetbedelleridd";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void personelBağlantılarıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmINTERNETpersonelbaglantilari")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmINTERNETpersonelbaglantilari frm = new frmINTERNETpersonelbaglantilari();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();
            frm.BringToFront();

            ToolStripButton lll = new ToolStripButton("Personel Bağlantıları");
            lll.Name = "frmINTERNETpersonelbaglantilari";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void bayiNihaiKapamaFaturalarıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmINTERNETticaripazarlamabayinihaikapamalar")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmINTERNETticaripazarlamabayinihaikapamalar frm = new frmINTERNETticaripazarlamabayinihaikapamalar();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();
            frm.BringToFront();

            ToolStripButton lll = new ToolStripButton("Bayi Nihai Kapamaları");
            lll.Name = "frmINTERNETticaripazarlamabayinihaikapamalar";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void bayiStoklarıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmINTERNETticaripazarlamabayistoklar")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmINTERNETticaripazarlamabayistoklar frm = new frmINTERNETticaripazarlamabayistoklar();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();
            frm.BringToFront();

            ToolStripButton lll = new ToolStripButton("Bayi Stokları");
            lll.Name = "frmINTERNETticaripazarlamabayistoklar";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void iadeİşlemSüreciToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmINTERNETiadeislem")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmINTERNETiadeislem frm = new frmINTERNETiadeislem();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();
            frm.BringToFront();

            ToolStripButton lll = new ToolStripButton("İadeler İşlem Süreci");
            lll.Name = "frmINTERNETiadeislem";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void diğerMüşterilerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmINTERNETcarihesapz")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmINTERNETcarihesapz frm = new frmINTERNETcarihesapz();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();
            frm.BringToFront();

            ToolStripButton lll = new ToolStripButton("Diğer Müşteriler");
            lll.Name = "frmINTERNETcarihesapz";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void görsellerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmINTERNETresimler2")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmINTERNETresimler2 frm = new frmINTERNETresimler2();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();
            frm.BringToFront();

            ToolStripButton lll = new ToolStripButton("Görseller");
            lll.Name = "frmINTERNETresimler2";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void üyelerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmKENTON_Uyeler")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmKENTON_Uyeler frm = new frmKENTON_Uyeler();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();
            frm.BringToFront();

            ToolStripButton lll = new ToolStripButton("Kenton : Üyeler");
            lll.Name = "frmKENTON_Uyeler";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void tariflerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmKENTON_Tarifler")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmKENTON_Tarifler frm = new frmKENTON_Tarifler();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();
            frm.BringToFront();

            ToolStripButton lll = new ToolStripButton("Kenton : Tarifler");
            lll.Name = "frmKENTON_Tarifler";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void yorumlarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmKENTON_Yorumlar")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmKENTON_Yorumlar frm = new frmKENTON_Yorumlar();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();
            frm.BringToFront();

            ToolStripButton lll = new ToolStripButton("Kenton : Yorumlar");
            lll.Name = "frmKENTON_Yorumlar";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void kütüphaneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmINTERNETkutuphane")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmINTERNETkutuphane frm = new frmINTERNETkutuphane();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();
            frm.BringToFront();

            ToolStripButton lll = new ToolStripButton("Kütüphane");
            lll.Name = "frmINTERNETkutuphane";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void kütüphane2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmINTERNETkutuphane2")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmINTERNETkutuphane2 frm = new frmINTERNETkutuphane2();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();
            frm.BringToFront();

            ToolStripButton lll = new ToolStripButton("Kütüphane 2");
            lll.Name = "frmINTERNETkutuphane2";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void anketlerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmINTERNETanketler")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmINTERNETanketler frm = new frmINTERNETanketler();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();
            frm.BringToFront();

            ToolStripButton lll = new ToolStripButton("Anketler");
            lll.Name = "frmINTERNETanketler";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void şirketlerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmSirketler")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmSirketler frm = new frmSirketler();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();
            frm.BringToFront();

            ToolStripButton lll = new ToolStripButton("Şirketler");
            lll.Name = "frmSirketler";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void tatilGünleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmTatiller")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmTatiller frm = new frmTatiller();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();
            frm.BringToFront();

            ToolStripButton lll = new ToolStripButton("Tatil Günleri");
            lll.Name = "frmTatiller";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        //
        //
        private void çokluMalzemeXMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmINTERNETmalzemeharic")
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Focus();

                    return;
                }
            }
            frmINTERNETmalzemeharic frm = new frmINTERNETmalzemeharic();
            frm.MdiParent = this;
            frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
            frm.Show();
            frm.BringToFront();

            ToolStripButton lll = new ToolStripButton("Çoklu Malzeme XML");
            lll.Name = "frmINTERNETmalzemeharic";
            lll.MouseUp += new MouseEventHandler(lll_MouseUp);
            statusStrip1.Items.Add(lll);
        }
        #endregion
        //
        //
        #region treeView1_AfterSelect
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (treeView1.SelectedNode.Name == "ndHaberler")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmHaberler")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndTedarikciler")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmTedarikciler")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndNobetciEczaneler")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmNobetciEczaneler")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndBasvurular")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmBasvurular")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndGorevler")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmGorevler")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndDepartmanlar")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmDepartmanlar")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndIsIstekleri")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmArananGorevler")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndPersoneller")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmPersoneller")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndCariHesapHareketler")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmFinansCariHesapHareketler")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndCHEkstresi")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmCHEkstresi")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndAraclar")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmAraclar")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndAracGiderleri")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmAracGiderleri")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndAracMarkalari")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmAracMarkalari")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndAracTurleri")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmAracTurleri")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndBrosurHazirlama")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmBrosur")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndKampanyaHazirlama")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmKampanya")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndTekUrunSiparisler")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmTekUrunSiparisler")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndTekUrunGenelBilgiler")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmTekUrunGenel")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndTekUrunSiparisDurumlari")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmTekUrunSiparisDurumlari")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndTekUrunKargoSirketleri")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmTekUrunKargoSirketleri")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndYetkiler")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmYetkiler")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndHatalar")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmHatalar")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndUyeler")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmINTERNETmusteriler")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndUyeGruplari")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmINTERNETuyegruplari")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndFiyatListeleri")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmINTERNETfiyatlisteleri")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndUyeKayitFormuYetkileri")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmUyeKayitFormuYetkileri")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndResimler")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmINTERNETresimler")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndEpostaGonderme")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmEpostaGonderme")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndMesajlar")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmINTERNETmesajlar")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndSifreSifirlamaTalepleri")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmINTERNETmusterisifresifirlamatalepleri")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndIadeler")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmINTERNETiadeler")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndSanalPos")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmFinansSanalPos")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndSatisTemsilcisiSefler")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmINTERNETsatistemsilcilerisefler")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndHizmetler")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmINTERNETsonradanhizmet")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndFinansCariHesapEklemeCikarma")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmFinansCariHesapEklemeCikarma")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndPrimler")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmPrimler")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndMalzemeKategoriMarka")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmINTERNETmalzemekategorimarka")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndDisSiparisler")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmINTERNETentegra")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndTicariPazarlamaMusteriler")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmINTERNETticaripazarlamamusteriler")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndTicariPazarlamaStoklar")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmINTERNETticaripazarlamastoklar")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndTicariPazarlamaAktiviteler")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmINTERNETticaripazarlamaaktiviteler")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndTicariPazarlamaHizmetBedelleri")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmINTERNETticaripazarlamahizmetbedelleri")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndTicariPazarlamaSatisRaporu")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmINTERNETticaripazarlamasatisrapor")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndTicariPazarlamaAnlasmalar")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmINTERNETticaripazarlamaanlasmalar")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndLojistikFirmalar")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmAT2lojistikfirmalar")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndBolgeler")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmAT2bolgeler")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndAracTipleri")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmAT2aractipler")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndSoforlerMuavinler")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmAT2soforlermuavinler")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndAraclar")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmAT2araclar")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndAracBedelleri")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmAT2aracbedelleri")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndSiparisToplamaPersonelleri")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmAT2personeller")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndRotalar")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmAT2rotalar")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndRotaMusteri")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmAT2rotamusteri")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndUrunFiyatTipiBaglantilari")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmINTERNETfiyaturunbaglanti")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndDepoDenetlemeleri")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmDepoDenetlemeler")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndUrunAktifPasif")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmINTERNETurunaktifpasif")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndBayiCiroPrimleri")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmINTERNETticaripazarlamabayiciroprimleri")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndHedefler")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmINTERNEThedef")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndHizmetBedelleri2")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmINTERNETticaripazarlamahizmetbedelleridd")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndBayiNihaiKapama")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmINTERNETticaripazarlamabayinihaikapamalar")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndPersonelBaglantilari")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmINTERNETpersonelbaglantilari")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndBayiStoklari")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmINTERNETticaripazarlamabayistoklar")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndIadeIslem")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmINTERNETiadeislem")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndDigerMusteriler")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmINTERNETcarihesapz")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndGorseller")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmINTERNETresimler2")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndKentonUyeler")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmKENTON_Uyeler")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndKentonTarifler")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmKENTON_Tarifler")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndKentonYorumlar")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmKENTON_Yorumlar")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndKutuphane")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmINTERNETkutuphane")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndAnketler")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmINTERNETanketler")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndSirketler")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmSirketler")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndTatiller")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmTatiller")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
            else if (treeView1.SelectedNode.Name == "ndMalzemeHaric")
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmINTERNETmalzemeharic")
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
        }
        #endregion
        //
        //
        #region treeView1_DoubleClick
        private void treeView1_DoubleClick(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode.Name == "ndHaberler")
            {
                if (haberlerToolStripMenuItem.Enabled)
                    haberlerToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndTedarikciler")
            {
                if (tedarikçilerToolStripMenuItem.Enabled)
                    tedarikçilerToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndNobetciEczaneler")
            {
                if (nöbetçiEczanelerToolStripMenuItem.Enabled)
                    nöbetçiEczanelerToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndBasvurular")
            {
                if (başvurularToolStripMenuItem.Enabled)
                    başvurularToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndGorevler")
            {
                if (görevlerToolStripMenuItem.Enabled)
                    görevlerToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndDepartmanlar")
            {
                if (departmanlarToolStripMenuItem.Enabled)
                    departmanlarToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndIsIstekleri")
            {
                if (işİstekleriToolStripMenuItem.Enabled)
                    işİstekleriToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndPersoneller")
            {
                if (personellerToolStripMenuItem.Enabled)
                    personellerToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndCariHesapHareketler")
            {
                if (cariHesapToolStripMenuItem.Enabled)
                    cariHesapToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndCHEkstresi")
            {
                if (cHEkstresiToolStripMenuItem.Enabled)
                    cHEkstresiToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndAraclar")
            {
                if (araçTakipToolStripMenuItem.Enabled)
                    araçlarToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndAracGiderleri")
            {
                if (araçTakipToolStripMenuItem.Enabled)
                    araçGiderleriToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndAracMarkalari")
            {
                if (araçTakipToolStripMenuItem.Enabled)
                    markalarToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndAracTurleri")
            {
                if (araçTakipToolStripMenuItem.Enabled)
                    türlerToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndBrosurHazirlama")
            {
                if (tasarımToolStripMenuItem.Enabled)
                    broşürHazırlamaToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndKampanyaHazirlama")
            {
                if (tasarımToolStripMenuItem.Enabled)
                    kampanyaHazırlamaToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndTekUrunSiparisler")
            {
                if (tekÜrünSatışıToolStripMenuItem.Enabled)
                    siparişlerToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndTekUrunGenelBilgiler")
            {
                if (tekÜrünSatışıToolStripMenuItem.Enabled)
                    genelBilgilerToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndTekUrunSiparisDurumlari")
            {
                if (tekÜrünSatışıToolStripMenuItem.Enabled)
                    siparişDurumlarıListesiToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndTekUrunKargoSirketleri")
            {
                if (tekÜrünSatışıToolStripMenuItem.Enabled)
                    kargoŞirketleriListesiToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndYetkiler")
            {
                if (yetkilerToolStripMenuItem.Enabled)
                    yetkilerToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndHatalar")
            {
                if (hatalarToolStripMenuItem.Enabled)
                    hatalarToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndUyeKayitFormuYetkileri")
            {
                if (üyeKayıtFormuYetkileriToolStripMenuItem.Enabled)
                    üyeKayıtFormuYetkileriToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndUyeler")
            {
                if (üyelerToolStripMenuItem.Enabled)
                    üyelerToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndUyeGruplari")
            {
                if (üyeGruplarıToolStripMenuItem.Enabled)
                    üyeGruplarıToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndFiyatListeleri")
            {
                if (fiyatListeleriToolStripMenuItem.Enabled)
                    fiyatListeleriToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndResimler")
            {
                if (resimlerToolStripMenuItem.Enabled)
                    resimlerToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndEpostaGonderme")
            {
                if (epostaGöndermeToolStripMenuItem.Enabled)
                    epostaGöndermeToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndMesajlar")
            {
                if (mesajlarToolStripMenuItem.Enabled)
                    mesajlarToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndSifreSifirlamaTalepleri")
            {
                if (şifreSıfırlamaTalepleriToolStripMenuItem.Enabled)
                    şifreSıfırlamaTalepleriToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndIadeler")
            {
                if (iadelerToolStripMenuItem.Enabled)
                    iadelerToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndSanalPos")
            {
                if (webSanalPosİşlemleriToolStripMenuItem.Enabled)
                    webSanalPosİşlemleriToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndSatisTemsilcisiSefler")
            {
                if (satışTemsilcisiŞeflerToolStripMenuItem.Enabled)
                    satışTemsilcisiŞeflerToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndHizmetler")
            {
                if (hizmetlerToolStripMenuItem.Enabled)
                    hizmetlerToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndFinansCariHesapEklemeCikarma")
            {
                if (satışTemsilcisiCariHesapEklemeToolStripMenuItem.Enabled)
                    satışTemsilcisiCariHesapEklemeToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndPrimler")
            {
                if (primOranlarıToolStripMenuItem.Enabled)
                    primOranlarıToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndMalzemeKategoriMarka")
            {
                if (malzemeKategoriMarkaSeçimleriToolStripMenuItem.Enabled)
                    malzemeKategoriMarkaSeçimleriToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndDisSiparisler")
            {
                if (eTicaretSiparişleriToolStripMenuItem.Enabled)
                    eTicaretSiparişleriToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndTicariPazarlamaMusteriler")
            {
                if (müşterilerVeAltCarilerToolStripMenuItem.Enabled)
                    müşterilerVeAltCarilerToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndTicariPazarlamaMusteriler")
            {
                if (müşterilerVeAltCarilerToolStripMenuItem.Enabled)
                    müşterilerVeAltCarilerToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndTicariPazarlamaStoklar")
            {
                if (stokKartlarıVeFiyatlarToolStripMenuItem.Enabled)
                    stokKartlarıVeFiyatlarToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndTicariPazarlamaAktiviteler")
            {
                if (aktivitelerToolStripMenuItem.Enabled)
                    aktivitelerToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndTicariPazarlamaHizmetBedelleri")
            {
                if (hizmetBedelleriToolStripMenuItem.Enabled)
                    hizmetBedelleriToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndTicariPazarlamaSatisRaporu")
            {
                if (satışRaporuToolStripMenuItem.Enabled)
                    satışRaporuToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndTicariPazarlamaAnlasmalar")
            {
                if (anlaşmalarToolStripMenuItem.Enabled)
                    anlaşmalarToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndLojistikFirmalar")
            {
                if (lojistikFirmalarıToolStripMenuItem.Enabled)
                    lojistikFirmalarıToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndBolgeler")
            {
                if (bölgelerToolStripMenuItem.Enabled)
                    bölgelerToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndAracTipleri")
            {
                if (araçTipleriToolStripMenuItem.Enabled)
                    araçTipleriToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndSoforlerMuavinler")
            {
                if (şoförVeMuavinlerToolStripMenuItem.Enabled)
                    şoförVeMuavinlerToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndAraclar")
            {
                if (araçlarToolStripMenuItem.Enabled)
                    araçlarToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndAracBedelleri")
            {
                if (araçBedelleriToolStripMenuItem.Enabled)
                    araçBedelleriToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndSiparisToplamaPersonelleri")
            {
                if (siparişToplamaPersonelleriToolStripMenuItem.Enabled)
                    siparişToplamaPersonelleriToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndRotalar")
            {
                if (rotalarToolStripMenuItem.Enabled)
                    rotalarToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndRotaMusteri")
            {
                if (rotaMüşteriBağlantılarıToolStripMenuItem.Enabled)
                    rotaMüşteriBağlantılarıToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndUrunFiyatTipiBaglantilari")
            {
                if (ürünFiyatTipiBağlantılarıToolStripMenuItem.Enabled)
                    ürünFiyatTipiBağlantılarıToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndDepoDenetlemeleri")
            {
                if (depoDenetlemeleriToolStripMenuItem.Enabled)
                    depoDenetlemeleriToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndUrunAktifPasif")
            {
                if (ürünAktifPasifSeçimiToolStripMenuItem.Enabled)
                    ürünAktifPasifSeçimiToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndBayiCiroPrimleri")
            {
                if (bayiCiroPrimleriToolStripMenuItem.Enabled)
                    bayiCiroPrimleriToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndHedefler")
            {
                if (hedeflerToolStripMenuItem.Enabled)
                    hedeflerToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndHizmetBedelleri2")
            {
                if (hizmetBedelleri2ToolStripMenuItem.Enabled)
                    hizmetBedelleri2ToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndBayiNihaiKapama")
            {
                if (bayiNihaiKapamaFaturalarıToolStripMenuItem.Enabled)
                    bayiNihaiKapamaFaturalarıToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndPersonelBaglantilari")
            {
                if (personelBağlantılarıToolStripMenuItem.Enabled)
                    personelBağlantılarıToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndBayiStoklari")
            {
                if (bayiStoklarıToolStripMenuItem.Enabled)
                    bayiStoklarıToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndIadeIslem")
            {
                if (iadeİşlemSüreciToolStripMenuItem.Enabled)
                    iadeİşlemSüreciToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndDigerMusteriler")
            {
                if (diğerMüşterilerToolStripMenuItem.Enabled)
                    diğerMüşterilerToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndGorseller")
            {
                if (görsellerToolStripMenuItem.Enabled)
                    görsellerToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndKentonUyeler")
            {
                if (üyelerToolStripMenuItem1.Enabled)
                    üyelerToolStripMenuItem1.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndKentonTarifler")
            {
                if (tariflerToolStripMenuItem.Enabled)
                    tariflerToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndKentonYorumlar")
            {
                if (yorumlarToolStripMenuItem.Enabled)
                    yorumlarToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndKutuphane")
            {
                if (kütüphaneToolStripMenuItem.Enabled)
                    kütüphaneToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndAnketler")
            {
                if (anketlerToolStripMenuItem.Enabled)
                    anketlerToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndSirketler")
            {
                if (şirketlerToolStripMenuItem.Enabled)
                    şirketlerToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndTatiller")
            {
                if (tatilGünleriToolStripMenuItem.Enabled)
                    tatilGünleriToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (treeView1.SelectedNode.Name == "ndMalzemeHaric")
            {
                if (çokluMalzemeXMLToolStripMenuItem.Enabled)
                    çokluMalzemeXMLToolStripMenuItem.PerformClick();
                else
                    MessageBox.Show("Bu sayfayı görmeye yetkiniz yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion
        //
        //
        public void lll_MouseUp(object sender, MouseEventArgs e)
        {
            /*if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == ((ToolStripButton)sender).Name)
                    {
                        f.Dispose();
                        statusStrip1.Items.Remove(((ToolStripButton)sender));
                    }
                }
            }
            else */
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == ((ToolStripButton)sender).Name)
                    {
                        if (f.WindowState == FormWindowState.Minimized)
                        {
                            f.WindowState = FormWindowState.Normal;
                        }
                        f.Focus();
                    }
                }
            }
        }
        //
        //
        private void cbSolMenu_CheckedChanged(object sender, EventArgs e)
        {
            /*RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Sultanlar", true);
            if (cbSolMenu.Checked)
                key.SetValue("SolMenu", "evet");
            else
                key.SetValue("SolMenu", "hayir");

            treeView1.Visible = cbSolMenu.Checked;*/
        }
        //
        //
        private void btnSeceneklerKapat_Click(object sender, EventArgs e)
        {
            pnlSecenekler.Visible = false;
        }
        //
        //
        private void pnlSecenekler_SizeChanged(object sender, EventArgs e)
        {
            btnSeceneklerKapat.Location = new Point(pnlSecenekler.Size.Width - btnSeceneklerKapat.Size.Width - 12, 
                pnlSecenekler.Size.Height - btnSeceneklerKapat.Size.Height - 12);
            lblSeceneklerKapat.Location = new Point(pnlSecenekler.Size.Width - lblSeceneklerKapat.Size.Width - 11,
                lblSeceneklerKapat.Location.Y);
        }
        //
        //
        private void lblSeceneklerKapat_MouseHover(object sender, EventArgs e)
        {
            lblSeceneklerKapat.ForeColor = Color.Red;
        }
        //
        //
        private void lblSeceneklerKapat_MouseLeave(object sender, EventArgs e)
        {
            lblSeceneklerKapat.ForeColor = Color.Black;
        }
        //
        //
        private void lblSeceneklerKapat_Click(object sender, EventArgs e)
        {
            pnlSecenekler.Visible = false;
        }
        //
        //
        //private void cbIadeSagTusMenu_CheckedChanged(object sender, EventArgs e)
        //{
        //    RegistryKey key = Registry.LocalMachine.OpenSubKey(@"Software\Sultanlar", true);
        //    if (cbIadeSagTusMenu.Checked)
        //        key.SetValue("IadeSagTusMenu", "evet");
        //    else
        //        key.SetValue("IadeSagTusMenu", "hayir");
        //}
        //
        //
        private void seçeneklerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            pnlSecenekler.Visible = true;
        }
        //
        //
        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //
        //
        private void frmAna_Activated(object sender, EventArgs e)
        {
            foreach (Form form in this.MdiChildren)
            {
                if (form.Name == "frmINTERNETmalzemekategorimarka" || form.Name == "frmPrimler")
                {
                    form.Refresh();
                }
            }
        }
        //
        //
        private void txtSifre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnGiris.PerformClick();
            }
        }
        //
        //
        private void btnGiris_Click(object sender, EventArgs e)
        {
            if (Kullanicilar.Login(txtKAdi.Text.Trim(), txtSifre.Text))
            {
                ListBox lbFormlar = new ListBox();
                ListBox lbYetkiler = new ListBox();
                KAdi = txtKAdi.Text.Trim().ToUpper();
                lblKAdi.Text = KAdi.ToUpper();
                IList listFormlar = lbFormlar.Items;
                IList listYetkiler = lbYetkiler.Items;
                Formlar.GetObject(listFormlar, true);
                Yetkiler.GetObject(listYetkiler, true);

                for (int i = 0; i < listFormlar.Count; i++)
                    for (int j = 0; j < listYetkiler.Count; j++)
                        if (((Formlar)listFormlar[i]).pkFormID == ((Yetkiler)listYetkiler[j]).sintFormID && KAdi == ((Yetkiler)listYetkiler[j]).strKAdi)
                            FormuAktifEt(((Formlar)listFormlar[i]).strFormAdi);

                pnlLogin.Visible = false;

                fe = new FormErisimleri(KAdi.ToUpper(), DateTime.Now, DateTime.MinValue);
                fe.DoInsert();
            }
        }
        //
        //
        private void frmAna_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (fe != null)
            {
                fe.dtCikisTarihi = DateTime.Now;
                fe.DoUpdate();
            }
        }
    }
}

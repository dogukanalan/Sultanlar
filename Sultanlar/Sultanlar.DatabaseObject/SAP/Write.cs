using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Sultanlar.DatabaseObject.SAP
{
    public class Write
    {
    }

    public class Musteriler
    {
        public Musteriler()
        {
            SqlConnection conn = new SqlConnection(General.ConnectionString);

            SqlCommand cmdLog = new SqlCommand("INSERT INTO [KurumsalWebSAP].[dbo].[tblINTERNET_LogTabloGuncellemeler] ([dtBaslangic],[dtBitis],[strYer],[strLog]) VALUES (@dtBaslangic,@dtBitis,@strYer,@strLog)", conn);
            cmdLog.Parameters.AddWithValue("@dtBaslangic", DateTime.Now);

            SqlCommand cmd11 = new SqlCommand("SELECT count(*) FROM [Web-Musteri]", conn);
            conn.Open();
            int oncekimusterisayisi = Convert.ToInt32(cmd11.ExecuteScalar());
            conn.Close();

            Customers cus = new Customers(SapType.Single);
            List<ZwebGetCustomers> data = (List<ZwebGetCustomers>)cus.Get();

            if (oncekimusterisayisi - 2000 > data.Count)
                return;

            SqlCommand cmd1 = new SqlCommand("DELETE FROM [Web_Musteri] DELETE FROM [Web-Risk]", conn);
            cmd1.CommandTimeout = 600;
            conn.Open();
            cmd1.ExecuteNonQuery();
            conn.Close();

            for (int i = 0; i < data.Count; i++)
            {
                string active = data[i].aufsd == string.Empty ? "0" : "1";
                string bolgekod = data[i].bzirk;
                string bolge = data[i].bztxt;
                string ytkkod = data[i].kdgrp;
                string ilkod = data[i].regio;
                string il = data[i].bezei;
                string ilcekod = data[i].post_code1;
                string ilce = data[i].city1;
                string mtkod = data[i].kdgrp;
                string mtaciklama = data[i].kdgtx;
                int slsref = 0; try { slsref = Convert.ToInt32(data[i].pernr); }
                catch { }
                string satkod = Convert.ToInt32(data[i].perno).ToString();
                string satkod1 = data[i].parvw;
                int gmref = 0; try { gmref = Convert.ToInt32(data[i].kunag); }
                catch { }
                string musteri = data[i].namag;
                int smref = 0; try { smref = Convert.ToInt32(data[i].kunwe); }
                catch { }
                string sube = data[i].namwe;
                string adres = data[i].adres;
                string sehir = data[i].comm_text;
                string semt = data[i].name3 + " - " + data[i].name4;
                string vrgdaire = data[i].stcd1;
                string vrgno = data[i].stcd2;
                string tel = data[i].telno;
                string fax = data[i].faxno;
                string email = data[i].email;
                string cep = data[i].mobno;
                double risklimit = Convert.ToDouble(data[i].klimk);
                int muskod = 0; try { muskod = data[i].altkn != string.Empty ? Convert.ToInt32(data[i].altkn) : 0; }
                catch { }

                SqlCommand cmd = new SqlCommand("INSERT INTO [Web_Musteri] " +
                    "([ACTIVE],BOLGE,[YTK KOD],[IL KOD],[IL],[ILCE KOD],[ILCE],[MT KOD],[MT ACIKLAMA],[SLSREF],[SAT KOD],[SAT KOD1],[GMREF],[MUS KOD],[SAT TEM],[MUSTERI],[SMREF],[SUB KOD],[SUBE],[ADRES],[SEHIR],SEMT,[VRG DAIRE],[VRG NO],[TEL-1],[FAX-1],[EMAIL-1],ILGILI,[CEP-1],[NETTOP])" +
                    "VALUES (@ACTIVE,@BOLGE,@YTKKOD,@ILKOD,@IL,@ILCEKOD,@ILCE,@MTKOD,@MTACIKLAMA,@SLSREF,@SATKOD,@SATKOD1,@GMREF,@MUSKOD,@SATTEM,@MUSTERI,@SMREF,@SUBKOD,@SUBE,@ADRES,@SEHIR,@SEMT,@VRGDAIRE,@VRGNO,@TEL,@FAX,@EMAIL,@ILGILI,@CEP,0)", conn);
                //cmd.CommandTimeout = 1000;
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

                SqlCommand cmd2 = new SqlCommand("SELECT count(GMREF) FROM [Web-Risk] WHERE GMREF = @GMREF", conn);
                cmd2.Parameters.AddWithValue("@GMREF", gmref);

                SqlCommand cmd3 = new SqlCommand("INSERT INTO [Web-Risk] ([SLSREF],[GMREF],[MUS KOD],[MUSTERI],[RISK LMT],[RISK TOP],[RISK BKY],[BAKIYE],[ACK GUN],[ACK TOP],[VB GUN],[VB TOP],[VGB GUN],[VGB TOP],[IRS TOP],[C/S TOP],[SIP TOPL],[SIP TOPLB],[SIP TOPQ]) VALUES (@SLSREF,@GMREF,@GMREF,@MUSTERI,@RISKLMT,0,@RISKBKY,0,0,0,0,0,0,0,0,0,0,0,0)", conn);
                //cmd3.CommandTimeout = 1000;
                cmd3.Parameters.AddWithValue("@SLSREF", slsref);
                cmd3.Parameters.AddWithValue("@GMREF", gmref);
                cmd3.Parameters.AddWithValue("@MUSTERI", musteri);
                cmd3.Parameters.AddWithValue("@RISKLMT", risklimit);
                cmd3.Parameters.AddWithValue("@RISKBKY", risklimit);

                SqlCommand cmd4 = new SqlCommand("SELECT [SAT TEM] FROM [Web-SatisTemsilcileri] WHERE SLSMANREF = @SLSMANREF", conn);
                cmd4.Parameters.AddWithValue("@SLSMANREF", slsref);

                try
                {
                    conn.Open();

                    string sattemgelen = string.Empty;
                    object obj = cmd4.ExecuteScalar();
                    if (obj != null)
                        sattemgelen = obj.ToString();
                    cmd.Parameters.AddWithValue("@SATTEM", sattemgelen);

                    cmd.ExecuteNonQuery();
                    if (!Convert.ToBoolean(cmd2.ExecuteScalar())) // risktablosunda yok ise
                    {
                        cmd3.ExecuteNonQuery();
                    }
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
            cmd10.CommandTimeout = 600;
            conn.Open();
            cmd10.ExecuteNonQuery();
            conn.Close();

            SqlCommand cmd5 = new SqlCommand("BEGIN TRANSACTION t_Transaction TRUNCATE TABLE [Web-Musteri] INSERT INTO [Web-Musteri] SELECT [ACTIVE],[BOLGE],[GRP],[EKP],[YTK KOD],[IL KOD],[IL],[ILCE KOD],[ILCE],[TIP],(SELECT DISTINCT [MT KOD] FROM [Web_Musteri] AS MUS WHERE GMREF = SMREF AND GMREF = [Web_Musteri].GMREF) AS [MT KOD],(SELECT DISTINCT [MT ACIKLAMA] FROM [Web_Musteri] AS MUS WHERE GMREF = SMREF AND GMREF = [Web_Musteri].GMREF) AS [MT ACIKLAMA],[UNVAN],[SLSREF],(SELECT DISTINCT [SAT KOD] FROM [Web_Musteri] AS MUS WHERE GMREF = SMREF AND GMREF = [Web_Musteri].GMREF) AS [SAT KOD],[SAT KOD1],[SAT TEM],[GMREF],[MUS KOD],[MUSTERI],[SMREF],[SUB KOD],[SUBE],[ADRES],[SEHIR],[SEMT],[VRG DAIRE],[VRG NO],[TEL-1],[FAX-1],[EMAIL-1],[ILGILI],[CEP-1],[NETTOP] FROM [Web_Musteri] WITH (HOLDLOCK) COMMIT TRANSACTION t_Transaction", conn);
            cmd5.CommandTimeout = 600;
            conn.Open();
            cmd5.ExecuteNonQuery();
            conn.Close();

            //üşengeçlik
            SqlCommand cmd6 = new SqlCommand("UPDATE [KurumsalWebSAP].[dbo].[Web-Musteri] SET [GRP] = '',[EKP] = '',[TIP] = 0,UNVAN=''", conn);
            conn.Open();
            cmd6.ExecuteNonQuery();
            conn.Close();

            SqlCommand cmd9 = new SqlCommand("z_MusteriBayiEleman", conn);
            cmd9.CommandType = CommandType.StoredProcedure;
            conn.Open();
            cmd9.ExecuteNonQuery();
            conn.Close();

            try
            {
                SqlCommand cmd7 = new SqlCommand("TRUNCATE TABLE [Web-Risk-2] INSERT INTO [Web-Risk-2] ([SLSREF],[GMREF],[MUS KOD],[MUSTERI],[RISK LMT],[RISK TOP],[RISK BKY],[BAKIYE],[ACK GUN],[ACK TOP],[VB GUN],[VB TOP],[VGB GUN],[VGB TOP],[IRS TOP],[C/S TOP],[SIP TOPL],[SIP TOPLB],[SIP TOPQ]) SELECT [SAT KOD],[MUS KOD],[MUS KOD],[MUSTERI],[RISK LMT],0,[RISK LMT],[BAKIYE],0,0,0,0,0,0,[BORC],0,[ALACAK],0,0 FROM [SAP_B_A_2017] WHERE [SAT KOD] IS NOT NULL", conn);
                cmd7.CommandTimeout = 60;
                SqlCommand cmd8 = new SqlCommand("UPDATE [Web-Risk] SET [RISK TOP] = SAP_B_A_2017.[RISK_TOP], [BAKIYE] = SAP_B_A_2017.[BAKIYE], [VGB GUN] = SAP_B_A_2017.[VGB_VD], [VGB TOP] = SAP_B_A_2017.[VGB], [C/S TOP] = SAP_B_A_2017.[CEK] + SAP_B_A_2017.[SNT] FROM [Web-Risk] INNER JOIN SAP_B_A_2017 ON [Web-Risk].GMREF = SAP_B_A_2017.[MUS KOD]", conn);
                cmd8.CommandTimeout = 60;
                conn.Open();
                cmd7.ExecuteNonQuery();
                cmd8.ExecuteNonQuery();
                conn.Close();
                cmdLog.Parameters.AddWithValue("@strYer", "SAP Musteriler");
            }
            catch (Exception ex)
            {
                cmdLog.Parameters.AddWithValue("@strYer", "SAP Musteriler (web-risk-2 yazılamadı)");
                Hatalar.DoInsert(ex, "windows servis SAP musteriler web-risk-2");
            }

            /*SqlCommand cmd8 = new SqlCommand("UPDATE [Web-Musteri] SET [Web-Musteri].BOLGE = ISNULL(SATRAP.BLG_KOD,''),[Web-Musteri].ILGILI = ISNULL(SATRAP.[BOLGE],'') FROM [Web-Musteri] LEFT OUTER JOIN (SELECT DISTINCT SMREF,BLG_KOD,[BOLGE] FROM [KurumsalWebSAP].[dbo].[Web-Satis-Rapor-1] WHERE YIL > YEAR(getdate()) - 4) AS SATRAP ON [Web-Musteri].SMREF = SATRAP.SMREF", conn);
            cmd8.CommandTimeout = 1000;
            conn.Open();
            cmd8.ExecuteNonQuery();
            conn.Close();*/

            cmdLog.Parameters.AddWithValue("@strLog", data.Count.ToString() + " Satır");

            //WebRutJob();

            conn.Open(); cmdLog.Parameters.AddWithValue("@dtBitis", DateTime.Now); cmdLog.ExecuteNonQuery(); conn.Close();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Sultanlar.DbObj.Internet
{
    public class loglar
    {
        public static void DoInsert(int MusteriID, DateTime Tarih, string Host, string Path, string Method, string QueryString, string Body, int Auth, string Ticket, string Login, string LoginR, 
            string Eposta, string Uygulama, string IP)
        {
            using (SqlConnection conn = new SqlConnection(General.ConnectionString))
            {
                SqlCommand logcmd = new SqlCommand("INSERT INTO [Web-Log] ([intMusteriID],[dtTarih],[strHost],[strPath],[strMethod],[strQueryString],strBody,[intAuth],[strTicket],[strLogin],[strLoginR],strEposta,strUygulama,strIP) VALUES (@intMusteriID,@dtTarih,@strHost,@strPath,@strMethod,@strQueryString,@strBody,@intAuth,@strTicket,@strLogin,@strLoginR,@strEposta,@strUygulama,@strIP)", conn);
                logcmd.Parameters.Add("@intMusteriID", SqlDbType.Int).Value = MusteriID;
                logcmd.Parameters.Add("@dtTarih", SqlDbType.DateTime).Value = Tarih;
                logcmd.Parameters.Add("@strHost", SqlDbType.NVarChar).Value = Host;
                logcmd.Parameters.Add("@strPath", SqlDbType.NVarChar).Value = Path;
                logcmd.Parameters.Add("@strMethod", SqlDbType.NVarChar).Value = Method;
                logcmd.Parameters.Add("@strQueryString", SqlDbType.NVarChar).Value = QueryString;
                logcmd.Parameters.Add("@strBody", SqlDbType.NVarChar).Value = Body;
                logcmd.Parameters.Add("@intAuth", SqlDbType.Int).Value = Auth;
                logcmd.Parameters.Add("@strTicket", SqlDbType.NVarChar).Value = Ticket;
                logcmd.Parameters.Add("@strLogin", SqlDbType.NVarChar).Value = Login;
                logcmd.Parameters.Add("@strLoginR", SqlDbType.NVarChar).Value = LoginR;
                logcmd.Parameters.Add("@strEposta", SqlDbType.NVarChar).Value = Eposta;
                logcmd.Parameters.Add("@strUygulama", SqlDbType.NVarChar).Value = Uygulama;
                logcmd.Parameters.Add("@strIP", SqlDbType.NVarChar).Value = IP;
                conn.Open();
                logcmd.ExecuteNonQuery();
                conn.Close();
            }
        }
    }
}

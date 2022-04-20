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
                SqlCommand hatacmd = new SqlCommand("INSERT INTO [Web-Log] ([intMusteriID],[dtTarih],[strHost],[strPath],[strMethod],[strQueryString],strBody,[intAuth],[strTicket],[strLogin],[strLoginR],strEposta,strUygulama,strIP) VALUES (@intMusteriID,@dtTarih,@strHost,@strPath,@strMethod,@strQueryString,@strBody,@intAuth,@strTicket,@strLogin,@strLoginR,@strEposta,@strUygulama,@strIP)", conn);
                hatacmd.Parameters.Add("@intMusteriID", SqlDbType.Int).Value = MusteriID;
                hatacmd.Parameters.Add("@dtTarih", SqlDbType.DateTime).Value = Tarih;
                hatacmd.Parameters.Add("@strHost", SqlDbType.NVarChar).Value = Host;
                hatacmd.Parameters.Add("@strPath", SqlDbType.NVarChar).Value = Path;
                hatacmd.Parameters.Add("@strMethod", SqlDbType.NVarChar).Value = Method;
                hatacmd.Parameters.Add("@strQueryString", SqlDbType.NVarChar).Value = QueryString;
                hatacmd.Parameters.Add("@strBody", SqlDbType.NVarChar).Value = Body;
                hatacmd.Parameters.Add("@intAuth", SqlDbType.Int).Value = Auth;
                hatacmd.Parameters.Add("@strTicket", SqlDbType.NVarChar).Value = Ticket;
                hatacmd.Parameters.Add("@strLogin", SqlDbType.NVarChar).Value = Login;
                hatacmd.Parameters.Add("@strLoginR", SqlDbType.NVarChar).Value = LoginR;
                hatacmd.Parameters.Add("@strEposta", SqlDbType.NVarChar).Value = Eposta;
                hatacmd.Parameters.Add("@strUygulama", SqlDbType.NVarChar).Value = Uygulama;
                hatacmd.Parameters.Add("@strIP", SqlDbType.NVarChar).Value = IP;
                conn.Open();
                hatacmd.ExecuteNonQuery();
                conn.Close();
            }
        }
    }
}

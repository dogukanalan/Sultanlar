using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sultanlar.DatabaseObject.Kenton;
using Sultanlar.Class;
using System.Data;

namespace Sultanlar.WebUI.kenton
{
    public partial class yorumlar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(System.Web.HttpCacheability.NoCache);
            Response.Cache.SetNoStore();

            uyeid.Value = Session["Kenton"] != null ? Sifreleme.Encrypt(((Uyeler)Session["Kenton"]).pkID.ToString()) : Sifreleme.Encrypt("0");

            if (Request.QueryString["a"] != null)
            {
                if (Session["Kenton"] == null)
                    Response.Redirect("giris.aspx?nereden=yorumlar.aspx", true);

                if (Request.QueryString["a"] == "benim")
                {
                    actionA.Value = "benim";
                }
            }
        }

        [System.Web.Services.WebMethod()]
        [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        public static List<Yorumlarr> YorumlarGetir(int sonid, string action, string uyeid)
        {
            List<Yorumlarr> donendeger = new List<Yorumlarr>();

            DataTable dt = new DataTable();

            if (action == "")
                Yorumlar.GetObjects(dt, sonid, 20);
            else if (action == "benim")
                Yorumlar.GetObjectsByUyeID(dt, Convert.ToInt32(Sifreleme.Decrypt(uyeid)), sonid, 20);

            for (int i = 0; i < dt.Rows.Count; i++)
                donendeger.Add(new Yorumlarr(Convert.ToInt32(dt.Rows[i]["pkID"]), Convert.ToInt32(dt.Rows[i]["intTarifID"]), dt.Rows[i]["strBaslik"].ToString(), Convert.ToInt32(dt.Rows[i]["intUyeID"]), dt.Rows[i]["strAdSoyad"].ToString(), dt.Rows[i]["strYorum"].ToString(), Convert.ToDateTime(dt.Rows[i]["dtTarih"]).ToString(), Convert.ToBoolean(dt.Rows[i]["blOnayli"])));

            return donendeger;
        }
    }
}
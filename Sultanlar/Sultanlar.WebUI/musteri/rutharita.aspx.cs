using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sultanlar.DatabaseObject.Internet;
using System.Web.Security;
using System.Data;

namespace Sultanlar.WebUI.musteri
{
    public partial class rutharita : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Label1.Text = ((Musteriler)Session["Musteri"]).strAd + " " + ((Musteriler)Session["Musteri"]).strSoyad;

            if (!IsPostBack)
            {
                txtDate.Text = DateTime.Now.ToShortDateString().Replace(".", "/");

                if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 2)
                {
                    SatisTemsilcileri.GetObjects(ddlTemsilciler.Items, true, false);
                }
                else if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 4 || ((Musteriler)Session["Musteri"]).tintUyeTipiID == 6) // satış temsilcisi ise
                {
                    ddlTemsilciler.Items.Add(new ListItem(((Musteriler)Session["Musteri"]).strAd + " " + ((Musteriler)Session["Musteri"]).strSoyad, ((Musteriler)Session["Musteri"]).intSLSREF.ToString()));
                }
                else
                {
                    Response.Redirect("yetkiyok.aspx", true);
                }

                ddlTemsilciler.SelectedIndex = 0;
                DataTable dt = new DataTable();
                Rutlar.GetTarihRutlar(dt, Convert.ToInt32(ddlTemsilciler.SelectedValue), Convert.ToDateTime(txtDate.Text));
                string input = string.Empty;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string basharfler = dt.Rows[i]["Şube"].ToString()[0].ToString();
                    input += dt.Rows[i]["Konum"].ToString() + "," + dt.Rows[i]["Şube"].ToString() + "," + basharfler + "|||";
                }
                inputH.Value = input;
            }

            string alert = "<script type='text/javascript'>$(function () {$(\".kucukbilgiGoster\").tipTip({ activation: \"hover\" });});</script>";
            ScriptManager.RegisterStartupScript(form1, typeof(string), "kucukbilgi", alert, false);
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("cikis.aspx", true);
        }

        protected void btnGetir_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            Rutlar.GetTarihRutlar(dt, Convert.ToInt32(ddlTemsilciler.SelectedValue), Convert.ToDateTime(txtDate.Text));
            string input = string.Empty;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string basharfler = dt.Rows[i]["Şube"].ToString()[0].ToString();
                input += dt.Rows[i]["Konum"].ToString() + "," + dt.Rows[i]["Şube"].ToString() + "," + basharfler + "|||";
            }
            inputH.Value = input;
        }
    }
}
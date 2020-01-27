using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Sultanlar.DatabaseObject.Internet;
using System.Collections;
using System.Web.Security;

namespace Sultanlar.WebUI.musteri
{
    public partial class katalogsade : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Redirect("katalog.aspx", true);

            if (!IsPostBack)
            {
                Session["KatalogStart"] = 11364;
                Session["KatalogCount"] = 12;
                Session["KatalogMaxRecordCount"] = GetProductsCount();

                lblUrunKacinci.Text = Session["KatalogCount"].ToString();
                lblUrunKacinci2.Text = lblUrunKacinci.Text;
                lblUrunSayisi.Text = Session["KatalogMaxRecordCount"].ToString();
                lblUrunSayisi2.Text = lblUrunSayisi.Text;

                GetProducts(11364, (int)Session["KatalogCount"]);
            }
        }
        private void GetProducts(int baslangic, int adet)
        {
            UrunSayisiniYaz();

            DataTable dt = new DataTable();
            Urunler.GetProducts(dt, baslangic, adet, "1",
                new ArrayList(), new ArrayList(), "%", "", "UrunID", "DESC", new ArrayList(), new ArrayList(), false);
            dlResimli.DataSource = dt;

            dlResimli.DataBind();
        }
        private int GetProductsCount()
        {
            int donendeger = Urunler.GetProductsCount("1", new ArrayList(), new ArrayList(), "%", "", new ArrayList(), new ArrayList(), false);

            return donendeger;
        }
        private void UrunSayisiniYaz()
        {
            if ((int)Session["KatalogStart"] + (int)Session["KatalogCount"] > (int)Session["KatalogMaxRecordCount"])
                lblUrunKacinci.Text = Session["KatalogMaxRecordCount"].ToString();
            else
                lblUrunKacinci.Text = ((int)Session["KatalogStart"] + (int)Session["KatalogCount"]).ToString();

            lblUrunKacinci2.Text = lblUrunKacinci.Text;
            lblUrunSayisi.Text = Session["KatalogMaxRecordCount"].ToString();
            lblUrunSayisi2.Text = lblUrunSayisi.Text;

            if (lblUrunKacinci.Text == lblUrunSayisi.Text)
            {
                lbSonraki.Enabled = false;
            }
            else
            {
                lbSonraki.Enabled = true;
            }

            if ((int)Session["KatalogStart"] == 0)
            {
                lbOnceki.Enabled = false;
            }
            else
            {
                lbOnceki.Enabled = true;
            }
        }
        protected void lbOnceki_Click(object sender, EventArgs e)
        {
            Session["KatalogStart"] = (int)Session["KatalogStart"] - (int)Session["KatalogCount"];
            if ((int)Session["KatalogStart"] < 0)
                Session["KatalogStart"] = 0;

            GetProducts((int)Session["KatalogStart"], (int)Session["KatalogCount"]);
        }
        protected void lbSonraki_Click(object sender, EventArgs e)
        {
            Session["KatalogStart"] = (int)Session["KatalogStart"] + (int)Session["KatalogCount"];

            if ((int)Session["KatalogStart"] < 0)
                Session["KatalogStart"] = 0;

            GetProducts((int)Session["KatalogStart"], (int)Session["KatalogCount"]);

            string alert = "<script type='text/javascript'>window.scrollTo(0, 500);window.print();</script>";
            ScriptManager.RegisterStartupScript(this, typeof(string), "scriptSayfaasagi", alert, false);
        }
    }
}
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
    public partial class katalog : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetTedarikciler();

                if (Request.QueryString["kat"] != null)
                {
                    cblTedarikciler.ClearSelection();
                    for (int i = 0; i < cblTedarikciler.Items.Count; i++)
                    {
                        if (cblTedarikciler.Items[i].Text.ToLower()/*.Replace("ı", "i").Replace("ü", "u").Replace("ş", "s").Replace("ğ", "g").Replace("ö", "o").Replace("ç", "c")*/
                            .StartsWith(" " + Request.QueryString["kat"].ToString().Replace("-", " ").ToLower()))
                        {
                            cblTedarikciler.Items[i].Selected = true;
                        }
                    }
                }

                Session["KatalogStart"] = 0;
                Session["KatalogCount"] = 12;
                Session["KatalogMaxRecordCount"] = GetProductsCount();

                lblUrunKacinci.Text = Session["KatalogCount"].ToString();
                lblUrunKacinci2.Text = lblUrunKacinci.Text;
                lblUrunSayisi.Text = Session["KatalogMaxRecordCount"].ToString();
                lblUrunSayisi2.Text = lblUrunSayisi.Text;

                GetProducts(0, (int)Session["KatalogCount"]);
            }

            string alert = "<script type='text/javascript'>$(function () {$(\".kucukbilgiGoster\").tipTip({ activation: \"hover\" });});</script>";
            ScriptManager.RegisterStartupScript(DivAjax, typeof(string), "kucukbilgi", alert, false);
        }
        private void GetTedarikciler()
        {
            Urunler.GetAltKategoriler(cblTedarikciler.Items);

            for (int i = 0; i < cblTedarikciler.Items.Count; i++)
                cblTedarikciler.Items[i].Selected = true;
        }
        private void GetProducts(int baslangic, int adet)
        {
            UrunSayisiniYaz();

            bool enazbirisecili = false;
            ArrayList Tedarikciler = new ArrayList();
            for (int i = 0; i < cblTedarikciler.Items.Count; i++)
            {
                if (cblTedarikciler.Items[i].Selected)
                {
                    enazbirisecili = true;
                    Tedarikciler.Add(cblTedarikciler.Items[i].Value);
                }
            }

            if (enazbirisecili)
            {
                DataTable dt = new DataTable();
                Urunler.GetProducts(dt, baslangic, adet, "7",
                    new ArrayList(), new ArrayList(), "%", "", "[Ad]", "ASC", new ArrayList(), new ArrayList(), false, Tedarikciler);
                dlResimli.DataSource = dt;
            }
            dlResimli.DataBind();
        }
        private int GetProductsCount()
        {
            bool enazbirisecili = false;
            ArrayList Tedarikciler = new ArrayList();
            for (int i = 0; i < cblTedarikciler.Items.Count; i++)
            {
                if (cblTedarikciler.Items[i].Selected)
                {
                    enazbirisecili = true;
                    Tedarikciler.Add(cblTedarikciler.Items[i].Value);
                }
            }

            int donendeger = 0;
            if (enazbirisecili)
                donendeger = Urunler.GetProductsCount("7", new ArrayList(), new ArrayList(), "%", "", new ArrayList(), new ArrayList(), false, Tedarikciler);

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
                lbSonraki.Visible = false;
                lblSonraki.Visible = true;
                lbSonraki2.Visible = false;
                lblSonraki2.Visible = true;
            }
            else
            {
                lbSonraki.Visible = true;
                lblSonraki.Visible = false;
                lbSonraki2.Visible = true;
                lblSonraki2.Visible = false;
            }

            if ((int)Session["KatalogStart"] == 0)
            {
                lbOnceki.Visible = false;
                lblOnceki.Visible = true;
                lbOnceki2.Visible = false;
                lblOnceki2.Visible = true;
            }
            else
            {
                lbOnceki.Visible = true;
                lblOnceki.Visible = false;
                lbOnceki2.Visible = true;
                lblOnceki2.Visible = false;
            }
        }
        protected void lbOnceki_Click(object sender, EventArgs e)
        {
            Session["KatalogStart"] = (int)Session["KatalogStart"] - (int)Session["KatalogCount"];
            if ((int)Session["KatalogStart"] < 0)
                Session["KatalogStart"] = 0;

            GetProducts((int)Session["KatalogStart"], (int)Session["KatalogCount"]);

            string alert = "<script type='text/javascript'>$('html,body').stop().animate({ scrollTop: '0' }, 1000);</script>";
            ScriptManager.RegisterStartupScript(this, typeof(string), "scriptSayfayukaricikar", alert, false);
        }
        protected void lbSonraki_Click(object sender, EventArgs e)
        {
            Session["KatalogStart"] = (int)Session["KatalogStart"] + (int)Session["KatalogCount"];

            if ((int)Session["KatalogStart"] < 0)
                Session["KatalogStart"] = 0;

            GetProducts((int)Session["KatalogStart"], (int)Session["KatalogCount"]);

            string alert = "<script type='text/javascript'>$('html,body').stop().animate({ scrollTop: '0' }, 1000);</script>";
            ScriptManager.RegisterStartupScript(this, typeof(string), "scriptSayfayukaricikar", alert, false);
        }
        //protected void cblTedarikciler_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    Session["KatalogMaxRecordCount"] = GetProductsCount();
        //    GetProducts(0, (int)Session["KatalogCount"]);
        //}
        //protected void lbTedarikciSifirla_Click(object sender, EventArgs e)
        //{
        //    for (int i = 0; i < cblTedarikciler.Items.Count; i++)
        //        cblTedarikciler.Items[i].Selected = false;

        //    //Session["KatalogMaxRecordCount"] = 0;
        //    //UrunSayisiniYaz();
        //    //dlResimli.DataBind();
        //}
        //protected void lbTedarikciTumu_Click(object sender, EventArgs e)
        //{
        //    for (int i = 0; i < cblTedarikciler.Items.Count; i++)
        //        cblTedarikciler.Items[i].Selected = true;

        //    //Session["KatalogMaxRecordCount"] = GetProductsCount();
        //    //GetProducts(0, (int)Session["KatalogCount"]);
        //}
        protected void lbUygula_Click(object sender, EventArgs e)
        {
            Session["KatalogStart"] = 0;
            Session["KatalogMaxRecordCount"] = GetProductsCount();
            GetProducts(0, (int)Session["KatalogCount"]);

            if ((int)Session["KatalogStart"] + (int)Session["KatalogCount"] > (int)Session["KatalogMaxRecordCount"])
                lblUrunKacinci.Text = Session["KatalogMaxRecordCount"].ToString();
            else
                lblUrunKacinci.Text = ((int)Session["KatalogStart"] + (int)Session["KatalogCount"]).ToString();
            lblUrunKacinci2.Text = lblUrunKacinci.Text;
            lbOnceki.Visible = false;
            lblOnceki.Visible = true;
            lbOnceki2.Visible = false;
            lblOnceki2.Visible = true;
        }
    }
}
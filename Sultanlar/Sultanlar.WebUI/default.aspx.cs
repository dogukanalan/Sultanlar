using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sultanlar.DatabaseObject;
using Sultanlar.Class;

namespace Sultanlar.WebUI
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);

            if (!IsPostBack)
            {
                if (Request.QueryString["kv"] != null)
                {
                    divKartvizit.Visible = true;
                    imgKartvizit.ImageUrl = "~/kartvizitler/" + Request.QueryString["kv"].ToString() + ".jpg";
                }

                FillTarih();
                GetEczaneIlceleri();
                ddlEczaneIlce.SelectedIndex = 28;
                GetEczane(ddlEczaneIlce.SelectedValue, ddlHangiGun.SelectedValue);
            }
        }
        //
        //
        private void FillTarih()
        {
            int kacGunVar = Eczaneler.GetSonGun() - DateTime.Now.Day;

            for (int i = 0; i <= kacGunVar; i++)
            {
                if (DateTime.Now.Day + i < 10) // gunun basinda 0 yazmasi icin
                {
                    if (DateTime.Now.Month < 10) // ayin basinda 0 yazmasi icin
                    {
                        ddlHangiGun.Items.Add("0" + (DateTime.Now.Day + i) + "/0" + DateTime.Now.Month + "/" + DateTime.Now.Year);
                        ddlHangiGun.Items[i].Value = (DateTime.Now.Day + i).ToString();
                    }
                    else
                    {
                        ddlHangiGun.Items.Add("0" + (DateTime.Now.Day + i) + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year);
                        ddlHangiGun.Items[i].Value = (DateTime.Now.Day + i).ToString();
                    }
                }
                else
                {
                    if (DateTime.Now.Month < 10)
                    {
                        ddlHangiGun.Items.Add(DateTime.Now.Day + i + "/0" + DateTime.Now.Month + "/" + DateTime.Now.Year);
                        ddlHangiGun.Items[i].Value = (DateTime.Now.Day + i).ToString();
                    }
                    else
                    {
                        ddlHangiGun.Items.Add(DateTime.Now.Day + i + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year);
                        ddlHangiGun.Items[i].Value = (DateTime.Now.Day + i).ToString();
                    }
                }
            }
        }
        //
        //
        private void GetEczane(string ilce, string gun)
        {
            string[,] eczaneler = Eczaneler.GetObject(ilce, gun);

            for (int i = 0; i < 10; i++)
            {
                if (eczaneler[i, 2] != null)
                {
                    string isim = StringParcalama.IlkHarfBuyuk(eczaneler[i, 2]) + "<br />";
                    string adres = eczaneler[i, 3] + "<br />";
                    string telefon = "Telefon: " + eczaneler[i, 4] + "<br />";
                    string harita;
                    if (eczaneler[i, 5] == string.Empty)
                    {
                        harita = "</div><a href='#' class='btn'>Harita sistemde kayıtlı değil !</a> </div></div>";
                    }
                    else
                    {
                        harita = "</div><a href='" + eczaneler[i, 5] + "' target='_blank' class='btn'>Haritada göster</a> </div></div>";
                    }

                    lblEczaneler.Text += "<div class='grid_4' style='padding-top: 30px'><div class='pad1'><div style='height: 70px'>" + isim + adres + telefon + harita;
                }
            }
        }
        //
        //
        private void GetEczaneIlceleri()
        {
            string[,] ilceler = EczaneIlceler.GetObject();

            for (int i = 0; i < 39; i++)
            {
                ddlEczaneIlce.Items.Add(ilceler[i, 1]);
                ddlEczaneIlce.Items[i].Value = ilceler[i, 0];
            }
        }
        //
        //
        protected void ddlEczaneIlce_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblEczaneler.Text = string.Empty;
            GetEczane(ddlEczaneIlce.SelectedValue, ddlHangiGun.SelectedValue);
        }
        //
        //
        protected void ddlHangiGun_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblEczaneler.Text = string.Empty;
            GetEczane(ddlEczaneIlce.SelectedValue, ddlHangiGun.SelectedValue);
        }
        //
        //
        protected void lbKartvizitKapat_Click(object sender, EventArgs e)
        {
            divKartvizit.Visible = false;
        }
    }
}
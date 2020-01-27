using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sultanlar.DatabaseObject;
using Sultanlar.DatabaseObject.Internet;

namespace Sultanlar.WebUI.musteri
{
    public partial class ucAlt : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Musteri"] != null)
                {
                    if (Session["Sifre"] != null && this.Parent.Page.Title != "Sultanlar : Üyelik İşlemleri")
                        Response.Redirect("uyelik.aspx", true);

                    if (Request.Cookies["sulSatTemLog"] != null && Request.Cookies["sulSatTemLog1"] != null && Request.Cookies["sulSatTemLogD"] != null && Request.Cookies["sulSatTemLogS"] != null)
                    {
                        if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 4 || ((Musteriler)Session["Musteri"]).tintUyeTipiID == 6)
                        {
                            if (Session["YoneticiGirdi"] == null) // eğer ben değilsem
                            {
                                string SLSREF = ((Musteriler)Session["Musteri"]).intSLSREF.ToString();
                                string ZAMAN = Request.Cookies["sulSatTemLogD"].Value;
                                string COORD = Request.Cookies["sulSatTemLog1"].Value;
                                string YER = Request.Cookies["sulSatTemLog"].Value;
                                string SAYFA = Request.Cookies["sulSatTemLogS"].Value;
                                WebGenel.Sorgu("INSERT INTO [Web-SatisTemsilcileri-Log] (SLSREF,ZAMAN,COORD,YER,SAYFA) VALUES (" +
                                    SLSREF + ",'" + ZAMAN + "','" + COORD + "','" + YER.Replace("'", "").Replace("%", "") + "','" + SAYFA + "')");
                            }
                        }
                    }

                    if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 6 && Musteriler.BirdenFazlaHesabiVarMi(((Musteriler)Session["Musteri"]).intSLSREF))
                        ddlTur.SelectedIndex = 0;
                    else if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 4 && Musteriler.BirdenFazlaHesabiVarMi(((Musteriler)Session["Musteri"]).intSLSREF))
                        ddlTur.SelectedIndex = 1;
                    else
                        ddlTur.Visible = false;
                }
                else
                {
                    ddlTur.Visible = false;
                }
            }
        }

        protected void ddlTur_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlTur.SelectedValue == "1")
                ((Musteriler)Session["Musteri"]).tintUyeTipiID = 6;
            else
                ((Musteriler)Session["Musteri"]).tintUyeTipiID = 4;

            Response.Redirect("default.aspx", true);
        }
    }
}
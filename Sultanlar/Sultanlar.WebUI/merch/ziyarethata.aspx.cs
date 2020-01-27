using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Sultanlar.DatabaseObject.Internet;

namespace Sultanlar.WebUI.merch
{
    public partial class ziyarethata : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(System.Web.HttpCacheability.NoCache);
            Response.Cache.SetNoStore();

            if (Session["Musteri"] == null)
                Response.Redirect("giris.aspx", true);

            if (!IsPostBack)
            {
                DataTable dt = new DataTable();
                SatisTemsilcisiZiyaretler.GetObjectLast(dt, ((Musteriler)Session["Musteri"]).intSLSREF);
                if (dt.Rows.Count > 0)
                {
                    lbSonZiyaretSonlandir.ToolTip = dt.Rows[0]["pkID"].ToString();

                    SatisTemsilcisiZiyaretler stz = SatisTemsilcisiZiyaretler.GetObject(Convert.ToInt32(dt.Rows[0]["pkID"]));
                    int MTIP = Convert.ToInt32(stz.strMekan.Substring(0, 1));
                    lblSonZiyaretMusteri.Text = MTIP == 1 ? CariHesaplar.GetMUSTERIbySMREF(stz.intSMREF) : MTIP == 4 ? CariHesaplarTP.GetSubelerBySMREF(stz.intSMREF)[1].ToString() : CariHesapZ.GetObject(stz.intSMREF, MTIP, true).SUBE;
                    lblSonZiyaretMusteri.Text += "<br><br>" + dt.Rows[0]["dtZiyaretBaslangic"].ToString();

                    txtCoords1.Text = stz.strMekan.Split(new string[] { ";;;" }, StringSplitOptions.None)[1];
                    txtCoords.Text = stz.strMekan.Split(new string[] { ";;;" }, StringSplitOptions.None)[2];
                    txtCoords1onceki.Text = Rutlar.GetKonum(stz.intSMREF, MTIP);

                    if (dt.Rows[0]["dtZiyaretBitis"].ToString() == "")
                        lbSonZiyaretSonlandir.Visible = true;
                }
            }
        }

        protected void lbSonZiyaretSonlandir_Click(object sender, EventArgs e)
        {
            SatisTemsilcisiZiyaretler stz = SatisTemsilcisiZiyaretler.GetObject(Convert.ToInt64(((LinkButton)sender).ToolTip));
            Session["Ziyaret"] = stz;

            //txtCoords1onceki.Text = stz.strMekan.Split(new string[] { ";;;" }, StringSplitOptions.None)[1];

            SatisTemsilcisiZiyaretler.GetZiyaretSonlandırmaSebepleri(rblZiyaretSonlandirmaSebepleri.Items, false);
            rblZiyaretSonlandirmaSebepleri.SelectedIndex = 0;
            divZiyaretSonlandirmaSebep.Visible = true;
        }

        protected void lbZiyaretSonlandirmaSebep_Click(object sender, EventArgs e)
        {
            SatisTemsilcisiZiyaretler stz = (SatisTemsilcisiZiyaretler)Session["Ziyaret"];
            stz.dtZiyaretBitis = DateTime.Now;
            stz.unSebep = Guid.Parse(rblZiyaretSonlandirmaSebepleri.SelectedValue);
            stz.strAciklama = txtZiyaretSonlandirmaSebepAciklama.Text + "-s-mobil";
            stz.DoUpdate();

            Rutlar.ZiyaretGuncelle(stz.strBARKOD, stz.dtZiyaretBitis,
                SatisTemsilcisiZiyaretler.GetZiyaretSonlandırmaSebepID(Guid.Parse(rblZiyaretSonlandirmaSebepleri.SelectedValue)),
                txtCoords1.Text,
                txtCoords.Text,
                txtCoordsFark.Text,
                "mobil", stz.strAciklama);

            Response.Cookies.Remove("sulZiyBaslangic");

            Session["Ziyaret"] = null;
            Session["Ziy"] = null;

            Response.Redirect("rutbugun.aspx", true);
        }
    }
}
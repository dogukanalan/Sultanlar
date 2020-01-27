using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data;
using Sultanlar.DatabaseObject.Internet;
using System.Collections;
using Sultanlar.DatabaseObject;

namespace Sultanlar.WebUI.musteri
{
    public partial class sattemcariduzenleme : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Redirect("default.aspx", true);

            Label1.Text = ((Musteriler)Session["Musteri"]).strAd + " " + ((Musteriler)Session["Musteri"]).strSoyad;

            if (!IsPostBack)
            {
                if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 1 || ((Musteriler)Session["Musteri"]).tintUyeTipiID == 5 || 
                    ((Musteriler)Session["Musteri"]).tintUyeTipiID == 6) // müşteri ise veya perakende müşteri ise veya bayi yöneticisi ise
                    Response.Redirect("yetkiyok.aspx", true);

                if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 2 && Session["SatTemCariDuzenlemeYoneticininSectigiSLSREF"] == null) Response.Redirect("default.aspx", true);

                GetSatisTemsilcileri();

                //hlSatistaOnAdim.Visible = ((Musteriler)Session["Musteri"]).tintUyeTipiID == 2 || ((Musteriler)Session["Musteri"]).tintUyeTipiID == 4;

                if (ddlSefAltlar.Items.Count == 0) Response.Redirect("default.aspx", true);

                Session["SatTemCariDuzenlemeCariHesapArama"] = "";
                GetCariHesaplar(Convert.ToInt32(ddlSefAltlar.Items[0].Value));
            }
        }

        private void GetSatisTemsilcileri()
        {
            if (((Musteriler)Session["Musteri"]).intSLSREF > 0 && SatisTemsilcileri.GetSATKOD1BySLSREF(((Musteriler)Session["Musteri"]).intSLSREF).StartsWith("8"))
                SatisTemsilcileriSefler.GetAltlar(ddlSefAltlar.Items, ((Musteriler)Session["Musteri"]).intSLSREF);
            else
                ddlSefAltlar.Items.Add(new ListItem(SatisTemsilcileri.GetObjectBySLSREF(Session["SatTemCariDuzenlemeYoneticininSectigiSLSREF"].ToString()), Session["SatTemCariDuzenlemeYoneticininSectigiSLSREF"].ToString()));
        }

        private void GetCariHesaplar(int SLSREF)
        {
            DataTable dt = new DataTable();
            CariHesaplar.GetObjectsForCariHesapDuzenleme(dt, SLSREF, Session["SatTemCariDuzenlemeCariHesapArama"].ToString(), rbBaglilar.Checked);
            GridView1.DataSource = dt;
            GridView1.DataKeyNames = new string[] { "SMREF", "EKSIZ" };
            GridView1.DataBind();
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("cikis.aspx", true);
        }

        protected void ddlSefAltlar_SelectedIndexChanged(object sender, EventArgs e)
        {
            //int musteriid = Musteriler.GetMusteriIDbySLSREF(Convert.ToInt32(ddlSefAltlar.SelectedValue));
            //if (musteriid > 0)
            //{
                GetCariHesaplar(Convert.ToInt32(ddlSefAltlar.SelectedValue));
            //}
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GetCariHesaplar(Convert.ToInt32(ddlSefAltlar.SelectedValue));
        }

        protected void Ekle_Changed(object sender, EventArgs e)
        {
            int smref = Convert.ToInt32(((CheckBox)sender).ToolTip);
            SatTemMusteriTalepleri stmt = SatTemMusteriTalepleri.GetObject(smref, Convert.ToInt32(ddlSefAltlar.SelectedValue));

            if (stmt.SMREF != smref)
            {
                stmt = new SatTemMusteriTalepleri(smref, Convert.ToInt32(ddlSefAltlar.SelectedValue), false, 0, 0);
                stmt.DoInsert();

                SatTemMusteriTalepleriLog stmtl = new SatTemMusteriTalepleriLog(smref, Convert.ToInt32(ddlSefAltlar.SelectedValue), 
                    ((Musteriler)Session["Musteri"]).pkMusteriID, false, DateTime.Now, 0, "");
                stmtl.DoInsert();

                lblIslem.Text = CariHesaplar.GetMUSTERIbySMREFmusterisube(smref) + "<br /><br /> isimli cari hesabın listeye eklenme talebi alındı.";
                divIslem.Visible = true;
            }
            else
            {
                if (stmt.blSefOnay == false)
                {
                    stmt.blCikar = !((CheckBox)sender).Checked;
                    stmt.blSefOnay = false;
                    stmt.DoUpdate();

                    SatTemMusteriTalepleriLog stmtl = new SatTemMusteriTalepleriLog(smref, Convert.ToInt32(ddlSefAltlar.SelectedValue),
                        ((Musteriler)Session["Musteri"]).pkMusteriID, false, DateTime.Now, 0, "");
                    stmtl.DoInsert();

                    lblIslem.Text = CariHesaplar.GetMUSTERIbySMREFmusterisube(smref) + "<br /><br /> isimli cari hesabın listeye eklenme talebi alındı.";
                    divIslem.Visible = true;
                }
            }

            GetCariHesaplar(Convert.ToInt32(ddlSefAltlar.SelectedValue));
        }

        protected void Cikar_Changed(object sender, EventArgs e)
        {
            int smref = Convert.ToInt32(((CheckBox)sender).ToolTip);
            SatTemMusteriTalepleri stmt = SatTemMusteriTalepleri.GetObject(smref, Convert.ToInt32(ddlSefAltlar.SelectedValue));

            if (stmt.SMREF != smref)
            {
                stmt = new SatTemMusteriTalepleri(smref, Convert.ToInt32(ddlSefAltlar.SelectedValue), true, 0, 0);
                stmt.DoInsert();

                SatTemMusteriTalepleriLog stmtl = new SatTemMusteriTalepleriLog(smref, Convert.ToInt32(ddlSefAltlar.SelectedValue),
                    ((Musteriler)Session["Musteri"]).pkMusteriID, true, DateTime.Now, 0, "");
                stmtl.DoInsert();

                lblIslem.Text = CariHesaplar.GetMUSTERIbySMREFmusterisube(smref) + "<br /><br /> isimli cari hesabın listeden çıkarma talebi alındı.";
                divIslem.Visible = true;
            }
            else
            {
                if (stmt.blSefOnay == false)
                {
                    stmt.blCikar = ((CheckBox)sender).Checked;
                    stmt.blSefOnay = false;
                    stmt.DoUpdate();

                    SatTemMusteriTalepleriLog stmtl = new SatTemMusteriTalepleriLog(smref, Convert.ToInt32(ddlSefAltlar.SelectedValue),
                        ((Musteriler)Session["Musteri"]).pkMusteriID, true, DateTime.Now, 0, "");
                    stmtl.DoInsert();

                    lblIslem.Text = CariHesaplar.GetMUSTERIbySMREFmusterisube(smref) + "<br /><br /> isimli cari hesabın listeden çıkarma talebi alındı.";
                    divIslem.Visible = true;
                }
            }

            GetCariHesaplar(Convert.ToInt32(ddlSefAltlar.SelectedValue));
        }

        protected void btnCariHesapAra_Click(object sender, EventArgs e)
        {
            if (txtCariHesapAra.Text.Trim() == string.Empty)
                return;

            Session["SatTemCariDuzenlemeCariHesapArama"] = txtCariHesapAra.Text.Trim();
            GetCariHesaplar(Convert.ToInt32(ddlSefAltlar.SelectedValue));
        }

        protected void btnCariHesapTemizle_Click(object sender, EventArgs e)
        {
            txtCariHesapAra.Text = string.Empty;
            Session["SatTemCariDuzenlemeCariHesapArama"] = "";
            GetCariHesaplar(Convert.ToInt32(ddlSefAltlar.SelectedValue));
        }

        protected void rbTumu_CheckedChanged(object sender, EventArgs e)
        {
            GetCariHesaplar(Convert.ToInt32(ddlSefAltlar.SelectedValue));
        }

        protected void lbIslemKapat_Click(object sender, EventArgs e)
        {
            divIslem.Visible = false;
        }

        protected void btnTumunuAktar_Click(object sender, EventArgs e)
        {

        }
    }
}
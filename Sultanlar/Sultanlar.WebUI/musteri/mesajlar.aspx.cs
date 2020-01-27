using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data;
using Sultanlar.DatabaseObject;
using Sultanlar.DatabaseObject.Internet;
using System.Collections;

namespace Sultanlar.WebUI.musteri
{
    public partial class mesajlar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Label1.Text = ((Musteriler)Session["Musteri"]).strAd + " " + ((Musteriler)Session["Musteri"]).strSoyad;
            GetOkunmamisMesajSayisi();

            if (!IsPostBack)
            {
                GetDepartmanlar();
                GetMesajlar();
                //hlSatistaOnAdim.Visible = ((Musteriler)Session["Musteri"]).tintUyeTipiID == 2 || ((Musteriler)Session["Musteri"]).tintUyeTipiID == 4;
                inputCevaplanan.Value = "0";
            }
        }

        private void GetDepartmanlar()
        {
            Departmanlar.GetObject(RadioButtonList1.Items);
            RadioButtonList1.Items.Add(new ListItem("Hepsi", "0"));
            RadioButtonList1.SelectedIndex = 0;
        }

        private void GetOkunmamisMesajSayisi()
        {

        }

        private void GetMesajlar()
        {
            DataTable dt = new DataTable();
            if (RadioButtonList1.SelectedValue != "0")
                GonderilenMesajlar.GetObjects(dt, ((Musteriler)Session["Musteri"]).pkMusteriID, Convert.ToInt32(RadioButtonList1.SelectedValue), 1000);
            else
                GonderilenMesajlar.GetObjects(dt, ((Musteriler)Session["Musteri"]).pkMusteriID, 1000);
            GridView1.DataSource = dt;
            GridView1.DataKeyNames = new string[] {"pkMesajID"};
            GridView1.DataBind();
        }

        private void GetGidenMesajlar()
        {
            DataTable dt = new DataTable();
            if (RadioButtonList1.SelectedValue == "0")
                AlinanMesajlar.GetObjects(dt, ((Musteriler)Session["Musteri"]).pkMusteriID);
            else
                AlinanMesajlar.GetObjects(dt, ((Musteriler)Session["Musteri"]).pkMusteriID, Convert.ToInt32(RadioButtonList1.SelectedValue));
            GridView1.DataSource = dt;
            GridView1.DataKeyNames = new string[] { "pkMesajID" };
            GridView1.DataBind();
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("cikis.aspx", true);
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;

            if (rbGelenKutusu.Checked)
                GetMesajlar();
            else if (rbGidenKutusu.Checked)
                GetGidenMesajlar();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            if (rbGelenKutusu.Checked)
            {
                int MesajID = Convert.ToInt32(GridView1.DataKeys[e.NewEditIndex]["pkMesajID"]);
                divMesaj.Visible = true;
                GonderilenMesajlar.DoUpdateOkundu(MesajID, DateTime.Now);
                ArrayList al = GonderilenMesajlar.GetObject(MesajID);
                lblKonu.Text = al[0].ToString();
                lblIcerik.Text = al[1].ToString();
                lblZaman.Text = al[2].ToString();
            }
            else if (rbGidenKutusu.Checked)
            {
                int MesajID = Convert.ToInt32(GridView1.DataKeys[e.NewEditIndex]["pkMesajID"]);
                divMesaj.Visible = true;
                
                ArrayList al = AlinanMesajlar.GetObject(MesajID);
                lblKonu.Text = al[0].ToString();
                lblIcerik.Text = al[1].ToString();
                lblZaman.Text = al[2].ToString();
            }
        }

        protected void lbMesajKapat_Click(object sender, EventArgs e)
        {
            divMesaj.Visible = false;

            if (rbGelenKutusu.Checked)
                GetMesajlar();
            else if (rbGidenKutusu.Checked)
                GetGidenMesajlar();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Sil")
            {
                if (rbGelenKutusu.Checked)
                {
                    GonderilenMesajlar.DoDelete(Convert.ToInt32(e.CommandArgument), false);
                    GetMesajlar();
                }
                else if (rbGidenKutusu.Checked)
                {
                    AlinanMesajlar.DoDelete(Convert.ToInt32(e.CommandArgument), true);
                    GetGidenMesajlar();
                }
            }
            else if (e.CommandName == "Cevapla")
            {
                if (rbGelenKutusu.Checked)
                {
                    int MesajID = Convert.ToInt32(e.CommandArgument);
                    inputCevaplanan.Value = MesajID.ToString();
                    GonderilenMesajlar.DoUpdateOkundu(MesajID, DateTime.Now);

                    ArrayList mesaj = GonderilenMesajlar.GetObject(Convert.ToInt32(e.CommandArgument));
                    txtKonu.Text = "Re: " + mesaj[0].ToString();
                    txtMesaj.Text = "---- Bir önceki mesaj ----\nTarih: " + mesaj[2].ToString() + "\n" + mesaj[1].ToString().Replace("<br />", "\n") + "\n--------------------------\n";

                    Departmanlar.GetObject(ddlDepartmanlar.Items);
                    for (int i = 0; i < ddlDepartmanlar.Items.Count; i++)
                    {
                        if (ddlDepartmanlar.Items[i].Value == mesaj[3].ToString())
                        {
                            ddlDepartmanlar.SelectedIndex = i;
                            ddlDepartmanlar.Enabled = false;
                            break;
                        }
                    }

                    divMesajYaz.Visible = true;
                    txtMesaj.Focus();
                }
            }
        }

        protected void btnMesajYaz_Click(object sender, EventArgs e)
        {
            divMesajYaz.Visible = true;
            Departmanlar.GetObject(ddlDepartmanlar.Items);
            ddlDepartmanlar.Enabled = true;

            ArrayList silinecekler = new ArrayList();
            silinecekler.Add("Depo");
            silinecekler.Add("Mali İşler");

            for (int i = 0; i < silinecekler.Count; i++)
            {
                for (int j = 0; j < ddlDepartmanlar.Items.Count; j++)
                {
                    if (ddlDepartmanlar.Items[j].Text == silinecekler[i].ToString())
                    {
                        ddlDepartmanlar.Items.RemoveAt(j);
                        break;
                    }
                }
            }

            txtKonu.Text = string.Empty;
            txtMesaj.Text = string.Empty;
        }

        protected void lbMesajYazKapat_Click(object sender, EventArgs e)
        {
            divMesajYaz.Visible = false;

            if (rbGelenKutusu.Checked)
                GetMesajlar();
            else if (rbGidenKutusu.Checked)
                GetGidenMesajlar();
        }

        protected void btnMesajGonder_Click(object sender, EventArgs e)
        {
            string konu = "-Konu Yok-";
            if (txtKonu.Text.Trim() != string.Empty)
                konu = txtKonu.Text.Trim();

            AlinanMesajlar am = new AlinanMesajlar(
                ((Musteriler)Session["Musteri"]).pkMusteriID,
                Convert.ToByte(ddlDepartmanlar.SelectedValue),
                konu,
                txtMesaj.Text.Replace("\n", "<br />"),
                DateTime.Now,
                DateTime.MinValue,
                false,
                false,
                false);
            am.DoInsert();

            if (inputCevaplanan.Value != "0")
            {
                MesajlarCevaplar mc = new MesajlarCevaplar(Convert.ToInt32(inputCevaplanan.Value), false, am.pkMesajID);
                mc.DoInsert();
            }

            divMesajYaz.Visible = false;
            if (rbGelenKutusu.Checked)
                GetMesajlar();
            else if (rbGidenKutusu.Checked)
                GetGidenMesajlar();
        }

        protected void rbGelenKutusu_CheckedChanged(object sender, EventArgs e)
        {
            GetMesajlar();
        }

        protected void rbGidenKutusu_CheckedChanged(object sender, EventArgs e)
        {
            GetGidenMesajlar();
        }

        protected void RadioButtonList1_CheckedChanged(object sender, EventArgs e)
        {
            if (rbGelenKutusu.Checked) 
                GetMesajlar();
            else 
                GetGidenMesajlar();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sultanlar.DatabaseObject.Internet;
using System.Web.Security;
using System.Collections;
using Sultanlar.Class;
using Sultanlar.DatabaseObject;

namespace Sultanlar.WebUI.musteri
{
    public partial class kartlar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);

            if (Session["Musteri"] == null)
                Response.Redirect("giris.aspx", true);

            Label1.Text = ((Musteriler)Session["Musteri"]).strAd + " " + ((Musteriler)Session["Musteri"]).strSoyad;

            if (!IsPostBack)
            {
                GetKartlar();
                GetBankalar();
            }
        }

        private void GetBankalar()
        {
            Bankalar.GetObject(ddlBankalar.Items);
        }

        private void GetKartlar()
        {
            Kartlar.GetObjects(ddlKartlar.Items, ((Musteriler)Session["Musteri"]).pkMusteriID);
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("cikis.aspx", true);
        }

        protected void ddlKartlar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlKartlar.SelectedIndex == 0)
            {
                btnEkle.Enabled = true;
                btnGuncelle.Enabled = false;
                btnSil.Enabled = false;

                txtTanim.Text = "";
                ddlBankalar.SelectedIndex = 0;
                txtNumara.Text = "";
                txtGuvenlik.Text = "";
                txtAy.Text = "";
                txtYil.Text = "";
                ddlVisaMC.SelectedIndex = 0;
            }
            else
            {
                btnEkle.Enabled = false;
                btnGuncelle.Enabled = true;
                btnSil.Enabled = true;

                ArrayList kart = Kartlar.GetObject(Convert.ToInt32(ddlKartlar.SelectedValue));
                txtTanim.Text = kart[1].ToString();
                txtNumara.Text = Sifreleme.Decrypt(kart[2].ToString());
                txtGuvenlik.Text = Sifreleme.Decrypt(kart[3].ToString());
                txtYil.Text = Sifreleme.Decrypt(kart[4].ToString());
                txtAy.Text = Sifreleme.Decrypt(kart[5].ToString());

                for (int i = 0; i < ddlBankalar.Items.Count; i++)
                {
                    if (ddlBankalar.Items[i].Value == kart[0].ToString())
                    {
                        ddlBankalar.SelectedIndex = i;
                        break;
                    }
                }

                if (Sifreleme.Decrypt(kart[6].ToString()) == "1")
                    ddlVisaMC.SelectedIndex = 0;
                else if (Sifreleme.Decrypt(kart[6].ToString()) == "2")
                    ddlVisaMC.SelectedIndex = 1;
            }
        }

        protected void btnEkle_Click(object sender, EventArgs e)
        {
            Kartlar kart = new Kartlar(
                ((Musteriler)Session["Musteri"]).pkMusteriID,
                24479,
                Convert.ToInt32(ddlBankalar.SelectedValue),
                txtTanim.Text.Trim(),
                Sifreleme.Encrypt(txtNumara.Text),
                Sifreleme.Encrypt(txtGuvenlik.Text),
                Sifreleme.Encrypt(txtYil.Text),
                Sifreleme.Encrypt(txtAy.Text),
                Sifreleme.Encrypt(ddlVisaMC.SelectedValue),
                DateTime.Now);

            kart.DoInsert();
            Response.Redirect("kartlar.aspx", true);
        }

        protected void btnGuncelle_Click(object sender, EventArgs e)
        {
            Kartlar kart = Kartlar.GetObject(Convert.ToInt32(ddlKartlar.SelectedValue), true);
            kart.intBankaID = Convert.ToInt32(ddlBankalar.SelectedValue);
            kart.strAd = txtTanim.Text.Trim();
            kart.strNumara = Sifreleme.Encrypt(txtNumara.Text);
            kart.strGuvenlik = Sifreleme.Encrypt(txtGuvenlik.Text);
            kart.strYil = Sifreleme.Encrypt(txtYil.Text);
            kart.strAy = Sifreleme.Encrypt(txtAy.Text);
            kart.strTip = Sifreleme.Encrypt(ddlVisaMC.SelectedValue);
            kart.dtEklenmeZamani = DateTime.Now;

            kart.DoUpdate();
            Response.Redirect("kartlar.aspx", true);
        }

        protected void btnSil_Click(object sender, EventArgs e)
        {
            Kartlar kart = Kartlar.GetObject(Convert.ToInt32(ddlKartlar.SelectedValue), true);

            kart.DoDelete();
            Response.Redirect("kartlar.aspx", true);
        }
    }
}
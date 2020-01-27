using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sultanlar.DatabaseObject;
using Sultanlar.DatabaseObject.Internet;
using Sultanlar.Class;

namespace Sultanlar.WebUI.musteri
{
    public partial class kayit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);

            if (User.Identity.Name != string.Empty)
            {
                Response.Redirect("default.aspx", true);
            }

            Iller.GetObject(ddlIl.Items);
            ddlIl.Items.RemoveAt(0);
            for (int i = 0; i < ddlIl.Items.Count; i++)
            {
                if (ddlIl.Items[i].Value == "34")
                {
                    ddlIl.Items[i].Selected = true;
                    break;
                }
            }
        }

        protected void btnGeri_Click(object sender, EventArgs e)
        {
            Response.Redirect("giris.html", true);
        }

        protected void btnGonder_Click(object sender, EventArgs e)
        {
            if (txtEposta.Text.Trim() == string.Empty)
                return;

            DateTime date = DateTime.Now;

            if (Musteriler.MusteriVarMi(txtEposta.Text.Trim()))
            {
                lblHata.Visible = true;
                lblHata.Text = "<script type='text/javascript'>alert('Kullanıcı adı kayıtlı, başka bir kullanıcı adı belirleyin.');</script>";
                txtEposta.Text = string.Empty;
                return;
            }
            else if (txtTelefon2.Text == string.Empty || txtTelefon3.Text == string.Empty || 
                txtTelefon4.Text == string.Empty || txtTelefon5.Text == string.Empty)
            {
                lblHata.Visible = true;
                lblHata.Text = "<script type='text/javascript'>alert('Telefon formatı yanlış.');</script>";
                txtTelefon2.Text = string.Empty;
                txtTelefon3.Text = string.Empty;
                txtTelefon4.Text = string.Empty;
                txtTelefon5.Text = string.Empty;
                return;
            }

            string telefon = txtTelefon1.Text + txtTelefon2.Text + " " + txtTelefon3.Text + " " + txtTelefon4.Text + " " + txtTelefon5.Text;

            Musteriler mus = new Musteriler(1, 5, 
                StringParcalama.IlkHarfBuyuk(txtAd.Text.Trim()), 
                StringParcalama.IlkHarfBuyuk(txtSoyad.Text.Trim()), 
                txtVergi.Text.Trim(), 
                txtVergiTC.Text.Trim(), 
                telefon, 
                txtEposta.Text.Trim(), 
                "", 
                txtSifre.Text.Trim(), 
                false, 
                false, 
                date, 
                date, 
                date, 
                false, 
                0, 
                0, 
                0, 
                false, 
                false, 
                false, 
                1, 
                false, 
                rbCHvar.Checked, 
                StringParcalama.IlkHarfBuyuk(txtUnvan.Text.Trim()),
                Convert.ToByte(ddlIl.SelectedValue),
                15,
                rbOdemeEvet.Checked, 50, 25, 25);
            mus.DoInsert();

            Session["KayitBasarili"] = true;

            if (mus.pkMusteriID > 0)
                Response.Redirect("kayitbasarili.html", true);
        }
    }
}
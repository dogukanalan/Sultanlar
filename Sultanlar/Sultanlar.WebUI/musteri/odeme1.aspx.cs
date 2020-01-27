using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sultanlar.DatabaseObject.Internet;
using Sultanlar.Class;
using System.Collections;

namespace Sultanlar.WebUI.musteri
{
    public partial class odeme1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["OdemeTutari"] == null || Session["OdemeGMREF"] == null)
                Response.Redirect("hata.htm", true);

            if (!IsPostBack)
            {
                Bankalar.GetObject(ddlBankalar.Items);

                if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 4 || 
                    ((Musteriler)Session["Musteri"]).tintUyeTipiID == 2) // satış temsilcisi ise veya yonetici ise
                    Kartlar.GetObjectsBySMREF(DropDownList1.Items, Convert.ToInt32(Session["OdemeGMREF"]));
                //else if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 2) // yonetici ise
                //    Kartlar.GetObjectsSATTEMMUSTERIADbySMREF(DropDownList1.Items, Convert.ToInt32(Session["OdemeGMREF"]));
                else
                    Kartlar.GetObjects(DropDownList1.Items, ((Musteriler)Session["Musteri"]).pkMusteriID);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Kartlar kart = null;

            if (DropDownList1.SelectedIndex == 0)
            {
                int MusteriID = 0;

                if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 4) // satış temsilcisi ise
                    MusteriID = Musteriler.GetMusteriIDbyGMREF(Convert.ToInt32(Session["OdemeGMREF"]));
                else
                    MusteriID = ((Musteriler)Session["Musteri"]).pkMusteriID;

                kart = new Kartlar(
                    MusteriID,
                    Convert.ToInt32(Session["OdemeGMREF"]),
                    Convert.ToInt32(ddlBankalar.SelectedValue),
                    TextBox1.Text.Trim(),
                    Sifreleme.Encrypt(txtNumara.Text),
                    Sifreleme.Encrypt(txtGuvenlik.Text),
                    Sifreleme.Encrypt(txtYil.Text),
                    Sifreleme.Encrypt(txtAy.Text),
                    Sifreleme.Encrypt(ddlVisaMC.SelectedValue),
                    DateTime.Now);

                if (CheckBox1.Checked)
                    kart.DoInsert();
            }
            else
            {
                kart = Kartlar.GetObject(Convert.ToInt32(DropDownList1.SelectedValue), true);
            }

            Session["KrediKart"] = kart;

            Response.Redirect("odeme.aspx", true);
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedIndex == 0)
            {
                TextBox1.Enabled = true;
                ddlBankalar.Enabled = true;
                txtNumara.Enabled = true;
                txtGuvenlik.Enabled = true;
                txtYil.Enabled = true;
                txtAy.Enabled = true;
                ddlVisaMC.Enabled = true;
                CheckBox1.Checked = true;
                CheckBox1.Enabled = true;

                RequiredFieldValidator1.Enabled = true;
                RegularExpressionValidator1.Enabled = true;
                RequiredFieldValidator2.Enabled = true;
                RegularExpressionValidator2.Enabled = true;
                RequiredFieldValidator4.Enabled = true;
                RegularExpressionValidator4.Enabled = true;
                RequiredFieldValidator3.Enabled = true;
                RegularExpressionValidator3.Enabled = true;

                TextBox1.Text = "";
                ddlBankalar.SelectedIndex = 0;
                txtNumara.Text = "";
                txtGuvenlik.Text = "";
                txtYil.Text = "";
                txtAy.Text = "";
                ddlVisaMC.SelectedIndex = 0;
            }
            else
            {
                TextBox1.Enabled = false;
                ddlBankalar.Enabled = false;
                txtNumara.Enabled = false;
                txtGuvenlik.Enabled = false;
                txtYil.Enabled = false;
                txtAy.Enabled = false;
                ddlVisaMC.Enabled = false;
                CheckBox1.Checked = false;
                CheckBox1.Enabled = false;

                RequiredFieldValidator1.Enabled = false;
                RegularExpressionValidator1.Enabled = false;
                RequiredFieldValidator2.Enabled = false;
                RegularExpressionValidator2.Enabled = false;
                RequiredFieldValidator4.Enabled = false;
                RegularExpressionValidator4.Enabled = false;
                RequiredFieldValidator3.Enabled = false;
                RegularExpressionValidator3.Enabled = false;

                ArrayList kart = Kartlar.GetObject(Convert.ToInt32(DropDownList1.SelectedValue));
                TextBox1.Text = kart[1].ToString();
                txtNumara.Text = Sifreleme.Decrypt(kart[2].ToString()).Substring(0, 6) + "********" + Sifreleme.Decrypt(kart[2].ToString()).Substring(14);
                txtGuvenlik.Text = "*" + Sifreleme.Decrypt(kart[3].ToString())[1] + "*";
                txtAy.Text = Sifreleme.Decrypt(kart[5].ToString())[0] + "*";
                txtYil.Text = "*" + Sifreleme.Decrypt(kart[4].ToString())[1];

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

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox1.Checked)
            {
                TextBox1.Enabled = true;
                RequiredFieldValidator5.Enabled = true;
            }
            else
            {
                TextBox1.Enabled = false;
                RequiredFieldValidator5.Enabled = false;
            }
        }
    }
}
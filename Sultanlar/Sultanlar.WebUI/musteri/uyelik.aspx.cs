using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using Sultanlar.DatabaseObject.Internet;
using Sultanlar.DatabaseObject;
using Sultanlar.Class;
using System.Collections;

namespace Sultanlar.WebUI.musteri
{
    public partial class uyelik : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Label1.Text = ((Musteriler)Session["Musteri"]).strAd + " " + ((Musteriler)Session["Musteri"]).strSoyad;

            if (!IsPostBack)
            {
                GetObjects();
            }

            if (Session["Sifre"] != null)
                lblSifreZorunlu.Visible = true;

            if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 1)
            {
                btnKartlarim.Visible = true;
            }
            else if (((Musteriler)Session["Musteri"]).tintUyeTipiID == 5)
            {
                btnAdreslerim.Visible = true;
                btnKartlarim.Visible = true;
            }
            else
            {
                //hlSatistaOnAdim.Visible = true;
                btnAdreslerim.Visible = false;
                btnKartlarim.Visible = false;
            }
        }

        private void GetObjects()
        {
            Musteriler musteri = (Musteriler)Session["Musteri"];

            txtAd.Text = musteri.strAd;
            txtSoyad.Text = musteri.strSoyad;
            txtVergiDairesi.Text = musteri.strVergiDairesi;
            txtVergiNo.Text = musteri.strVergiNo;
            txtTelefon.Text = musteri.strTelefon;
            txtEposta.Text = musteri.strEposta;
            txtOnerilenFiyatYuzde.Text = musteri.tintOnerilenFiyatYuzde.ToString();
            txtSiparisUrunSayisi.Text = musteri.intSiparisUrunSayisi.ToString();
            txtRaporSatirSayisi.Text = musteri.intRaporSatirSayisi.ToString();
            txtSiparisSatirSayisi.Text = musteri.intSiparisSatirSayisi.ToString();

            Iller.GetObject(ddlIl.Items);
            ddlIl.Items.RemoveAt(0);
            for (int i = 0; i < ddlIl.Items.Count; i++)
            {
                if (ddlIl.Items[i].Value == musteri.tintIlID.ToString())
                {
                    ddlIl.Items[i].Selected = true;
                    break;
                }
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("cikis.aspx", true);
        }

        protected void btnGuncelle_Click(object sender, EventArgs e)
        {
            Musteriler musteri = (Musteriler)Session["Musteri"];

            if (txtSifre.Text != string.Empty)
                musteri.binSifre = txtSifre.Text;

            musteri.strAd = txtAd.Text.Trim();
            musteri.strSoyad = txtSoyad.Text.Trim();
            musteri.strVergiDairesi = txtVergiDairesi.Text.Trim();
            musteri.strVergiNo = txtVergiNo.Text.Trim();
            musteri.strTelefon = txtTelefon.Text.Trim();
            musteri.strEposta = txtEposta.Text.Trim();
            musteri.tintIlID = Convert.ToByte(ddlIl.SelectedValue);
            musteri.tintOnerilenFiyatYuzde = txtOnerilenFiyatYuzde.Text != string.Empty ? Convert.ToByte(txtOnerilenFiyatYuzde.Text) : (byte)0;
            musteri.intSiparisUrunSayisi = txtSiparisUrunSayisi.Text != string.Empty ? Convert.ToInt32(txtSiparisUrunSayisi.Text) : 0;
            musteri.intRaporSatirSayisi = txtRaporSatirSayisi.Text != string.Empty ? Convert.ToInt32(txtRaporSatirSayisi.Text) : 0;
            musteri.intSiparisSatirSayisi = txtSiparisSatirSayisi.Text != string.Empty ? Convert.ToInt32(txtSiparisSatirSayisi.Text) : 0;
            musteri.DoUpdate();
            Session["Musteri"] = musteri;
            lblGuncellendi.Visible = true;
            if (txtSifre.Text != "123456")
            {
                lblSifreZorunlu.Visible = false;
                Session["Sifre"] = null;
            }
        }

        protected void btnAdreslerim_Click(object sender, EventArgs e)
        {
            divAdreslerim.Visible = true;

            MusteriAdresler.GetObjects(ddlAdresler.Items, ((Musteriler)Session["Musteri"]).pkMusteriID);
            ddlAdresler.SelectedIndex = 0;

            Iller.GetObject(ddlIller.Items);
            ddlIller.Items.RemoveAt(0);
            for (int i = 0; i < ddlIller.Items.Count; i++)
            {
                if (ddlIller.Items[i].Value == "34")
                {
                    ddlIller.Items[i].Selected = true;
                    break;
                }
            }

            Ilceler.GetObject(ddlIlceler.Items, ddlIller.SelectedValue);
            ddlIlceler.Items.RemoveAt(0);
            ddlIlceler.SelectedIndex = 0;
        }

        protected void lbAdreslerimKapat_Click(object sender, EventArgs e)
        {
            divAdreslerim.Visible = false;
            txtBaslik.Text = string.Empty;
            txtAdres.Text = string.Empty;
        }

        protected void btnAdresSil_Click(object sender, EventArgs e)
        {
            MusteriAdresler ma = MusteriAdresler.GetObject(Convert.ToInt32(ddlAdresler.SelectedValue));
            ma.DoDelete();

            lblAdresBilgi.Text = "Adres silindi.";

            MusteriAdresler.GetObjects(ddlAdresler.Items, ((Musteriler)Session["Musteri"]).pkMusteriID);

            btnAdres.Text = "Ekle";
            txtBaslik.Text = string.Empty;
            txtAdres.Text = string.Empty;

            Iller.GetObject(ddlIller.Items);
            ddlIller.Items.RemoveAt(0);
            for (int i = 0; i < ddlIller.Items.Count; i++)
            {
                if (ddlIller.Items[i].Value == "34")
                {
                    ddlIller.Items[i].Selected = true;
                    break;
                }
            }

            Ilceler.GetObject(ddlIlceler.Items, ddlIller.SelectedValue);
            ddlIlceler.Items.RemoveAt(0);
            ddlIlceler.SelectedIndex = 0;
        }

        protected void btnAdres_Click(object sender, EventArgs e)
        {
            if (btnAdres.Text == "Ekle" && ddlAdresler.SelectedIndex == 0)
            {
                MusteriAdresler ma = new MusteriAdresler(
                    ((Musteriler)Session["Musteri"]).pkMusteriID, txtBaslik.Text.Trim(), txtAdres.Text.Trim(),
                    Convert.ToByte(ddlIller.SelectedValue), Convert.ToInt16(ddlIlceler.SelectedValue));
                ma.DoInsert();

                MusteriAdresler.GetObjects(ddlAdresler.Items, ((Musteriler)Session["Musteri"]).pkMusteriID);

                for (int i = 0; i < ddlAdresler.Items.Count; i++)
                {
                    if (ddlAdresler.Items[i].Value == ma.pkAdresID.ToString())
                    {
                        ddlAdresler.Items[i].Selected = true;
                        break;
                    }
                }

                lblAdresBilgi.Text = "Adres eklendi.";
            }
            else if (btnAdres.Text == "Güncelle" && ddlAdresler.SelectedIndex > 0)
            {
                MusteriAdresler ma = MusteriAdresler.GetObject(Convert.ToInt32(ddlAdresler.SelectedValue));
                ma.strBaslik = txtBaslik.Text.Trim();
                ma.strAdres = txtAdres.Text.Trim();
                ma.tintIlID = Convert.ToByte(ddlIller.SelectedValue);
                ma.sintIlceID = Convert.ToInt16(ddlIlceler.SelectedValue);
                ma.DoUpdate();

                lblAdresBilgi.Text = "Adres güncellendi.";
            }
        }

        protected void ddlAdresler_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlAdresler.SelectedIndex > 0)
            {
                btnAdresSil.Visible = true;
                btnAdres.Text = "Güncelle";
                MusteriAdresler ma = MusteriAdresler.GetObject(Convert.ToInt32(ddlAdresler.SelectedValue));
                txtBaslik.Text = ma.strBaslik;
                txtAdres.Text = ma.strAdres;

                Iller.GetObject(ddlIller.Items);
                ddlIller.Items.RemoveAt(0);
                for (int i = 0; i < ddlIller.Items.Count; i++)
                {
                    if (Convert.ToByte(ddlIller.Items[i].Value) == ma.tintIlID)
                    {
                        ddlIller.Items[i].Selected = true;
                        break;
                    }
                }

                Ilceler.GetObject(ddlIlceler.Items, ddlIller.SelectedValue);
                ddlIlceler.Items.RemoveAt(0);
                for (int i = 0; i < ddlIlceler.Items.Count; i++)
                {
                    if (Convert.ToInt16(ddlIlceler.Items[i].Value) == ma.sintIlceID)
                    {
                        ddlIlceler.Items[i].Selected = true;
                        break;
                    }
                }
            }
            else if (ddlAdresler.SelectedIndex == 0)
            {
                btnAdresSil.Visible = false;
                btnAdres.Text = "Ekle";
                txtBaslik.Text = string.Empty;
                txtAdres.Text = string.Empty;

                for (int i = 0; i < ddlIller.Items.Count; i++)
                {
                    if (ddlIller.Items[i].Value == "34")
                    {
                        ddlIller.Items[i].Selected = true;
                        break;
                    }
                }

                Ilceler.GetObject(ddlIlceler.Items, ddlIller.SelectedValue);
                ddlIlceler.Items.RemoveAt(0);
                ddlIlceler.SelectedIndex = 0;
            }
        }

        protected void ddlIller_SelectedIndexChanged(object sender, EventArgs e)
        {
            Ilceler.GetObject(ddlIlceler.Items, ddlIller.SelectedValue);
            ddlIlceler.Items.RemoveAt(0);
            ddlIlceler.SelectedIndex = 0;
        }

        protected void btnKartlarim_Click(object sender, EventArgs e)
        {
            divKartlar.Visible = true;

            Kartlar.GetObjects(ddlKartlar.Items, ((Musteriler)Session["Musteri"]).pkMusteriID);
            Bankalar.GetObject(ddlBankalar.Items);
        }

        protected void lbKartlarKapat_Click(object sender, EventArgs e)
        {
            divKartlar.Visible = false;

            ddlKartlar.SelectedIndex = 0;

            btnKartEkle.Enabled = true;
            btnKartGuncelle.Enabled = false;
            btnKartSil.Enabled = false;

            txtTanim.Text = "";
            ddlBankalar.SelectedIndex = 0;
            txtNumara.Text = "";
            txtGuvenlik.Text = "";
            txtAy.Text = "";
            txtYil.Text = "";
            ddlVisaMC.SelectedIndex = 0;
        }

        protected void ddlKartlar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlKartlar.SelectedIndex == 0)
            {
                btnKartEkle.Enabled = true;
                btnKartGuncelle.Enabled = false;
                btnKartSil.Enabled = false;

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
                btnKartEkle.Enabled = false;
                btnKartGuncelle.Enabled = true;
                btnKartSil.Enabled = true;

                ArrayList kart = Kartlar.GetObject(Convert.ToInt32(ddlKartlar.SelectedValue));
                txtTanim.Text = kart[1].ToString();
                txtNumara.Text = Sifreleme.Decrypt(kart[2].ToString()).Substring(0, 4) + "********";
                txtGuvenlik.Text = Sifreleme.Decrypt(kart[3].ToString()).Substring(0, 1) + "**";
                txtYil.Text = "*" + Sifreleme.Decrypt(kart[4].ToString()).Substring(1);
                txtAy.Text = "*" + Sifreleme.Decrypt(kart[5].ToString()).Substring(1);

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

        protected void btnKartEkle_Click(object sender, EventArgs e)
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
            //Response.Redirect("kartlar.aspx", true);

            Kartlar.GetObjects(ddlKartlar.Items, ((Musteriler)Session["Musteri"]).pkMusteriID);

            ddlKartlar.SelectedIndex = 0;

            btnKartEkle.Enabled = true;
            btnKartGuncelle.Enabled = false;
            btnKartSil.Enabled = false;

            txtTanim.Text = "";
            ddlBankalar.SelectedIndex = 0;
            txtNumara.Text = "";
            txtGuvenlik.Text = "";
            txtAy.Text = "";
            txtYil.Text = "";
            ddlVisaMC.SelectedIndex = 0;
        }

        protected void btnKartGuncelle_Click(object sender, EventArgs e)
        {
            if (txtNumara.Text.IndexOf("*") > -1 || txtGuvenlik.Text.IndexOf("*") > -1 || txtYil.Text.IndexOf("*") > -1 || txtAy.Text.IndexOf("*") > -1)
                Response.Redirect("uyelik.aspx", true);

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
            //Response.Redirect("kartlar.aspx", true);

            Kartlar.GetObjects(ddlKartlar.Items, ((Musteriler)Session["Musteri"]).pkMusteriID);

            ddlKartlar.SelectedIndex = 0;

            btnKartEkle.Enabled = true;
            btnKartGuncelle.Enabled = false;
            btnKartSil.Enabled = false;

            txtTanim.Text = "";
            ddlBankalar.SelectedIndex = 0;
            txtNumara.Text = "";
            txtGuvenlik.Text = "";
            txtAy.Text = "";
            txtYil.Text = "";
            ddlVisaMC.SelectedIndex = 0;
        }

        protected void btnKartSil_Click(object sender, EventArgs e)
        {
            Kartlar kart = Kartlar.GetObject(Convert.ToInt32(ddlKartlar.SelectedValue), true);

            kart.DoDelete();
            //Response.Redirect("kartlar.aspx", true);

            Kartlar.GetObjects(ddlKartlar.Items, ((Musteriler)Session["Musteri"]).pkMusteriID);

            ddlKartlar.SelectedIndex = 0;

            btnKartEkle.Enabled = true;
            btnKartGuncelle.Enabled = false;
            btnKartSil.Enabled = false;

            txtTanim.Text = "";
            ddlBankalar.SelectedIndex = 0;
            txtNumara.Text = "";
            txtGuvenlik.Text = "";
            txtAy.Text = "";
            txtYil.Text = "";
            ddlVisaMC.SelectedIndex = 0;
        }
    }
}
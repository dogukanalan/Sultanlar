using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sultanlar.DatabaseObject;
using Sultanlar.Class;

namespace Sultanlar.WebUI
{
    public partial class isbasvuru : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetIller();
                ddlNufusIlce.Items.Clear();
                //Ilceler.GetObject(ddlNufusIlce.Items, "1");
                ddlAdresIlce.Items.Clear();
                //Ilceler.GetObject(ddlAdresIlce.Items, "1");

                GetSurucuBelgeleri();
                GetMedeniDurumlar();
                GetAskerlikDurumlari();
                GetAskerlikTipleri();
                GetOgrenimDurumlari();
                GetBilgisayarProgramlari();
                GetGorevler();
                GetYabanciDiller();
                GetGelirler();

                if (Request.QueryString["id"] != null)
                {
                    Session["ArananGorevID"] = Convert.ToInt32(Request.QueryString["id"]);
                }
            }
        }
        //
        //
        //
        // Methodlar:
        //
        #region Methodlar
        private void GetGelirler()
        {
            GelirTurleri.GetObject(cblGelirler.Items);
        }
        //
        //
        private void GetYabanciDiller()
        {
            Diller.GetObject(cblYabanciDiller.Items);
        }
        //
        //
        private void GetGorevler()
        {
            Gorevler.GetObject(cblGorevler.Items);
        }
        //
        //
        private void GetBilgisayarProgramlari()
        {
            BilgisayarProgramlari.GetObject(cblBilgisayarProgramlari.Items);
        }
        //
        //
        private void GetOgrenimDurumlari()
        {
            OgrenimDurumlari.GetObject(ddlOgrenimDurumu.Items);
        }
        //
        //
        private void GetAskerlikTipleri()
        {
            AskerlikTipleri.GetObject(ddlAskerlikTipi.Items);
        }
        //
        //
        private void GetAskerlikDurumlari()
        {
            AskerlikDurumlari.GetObject(ddlAskerlikDurumu.Items);
        }
        //
        //
        private void GetMedeniDurumlar()
        {
            MedeniDurumlar.GetObject(ddlMedeniDurum.Items);
        }
        //
        //
        private void GetSurucuBelgeleri()
        {
            SurucuBelgeSiniflari.GetObject(ddlSurucuBelgeSinif.Items);
        }
        //
        //
        private void GetIller()
        {
            Iller.GetObject(ddlDogumYeriIl.Items);
            Iller.GetObject(ddlAdresIl.Items);
            Iller.GetObject(ddlNufusIl.Items);
        }
        //
        // Sayfa postback olmadan ajax ile verileri getirdiğinde, bir önceki ajax ile gelenler kaybolmasin diye: --- kullanılmıyor
        private void SonradanOlusanlar()
        {
            GelirleriOlustur();
            YabanciDilleriOlustur();
        }
        #endregion
        //
        //
        //
        // Karmaşık Methodlar:
        //
        #region Gelirleri Olustur (kullanilmiyor)
        private void GelirleriOlustur()
        {
            byte kacTaneSecili = 0;

            foreach (ListItem li in cblGelirler.Items)
            {
                if (li.Selected)
                {
                    pnlGelirler.Visible = true;

                    Label lbl = new Label();
                    lbl.Text = "<table style='width: 400px'><tr><td style='width: 100px'>" + li.Text + ": </td><td style='width: 140px'>";

                    TextBox txt = new TextBox();
                    txt.ID = "txt" + li.Value + "Tutar";
                    txt.MaxLength = 20;
                    txt.Width = new Unit("110");

                    Label lbl2 = new Label();
                    lbl2.Text = "</td><td style='width: 160px'>";

                    TextBox txt2 = new TextBox();
                    txt2.ID = "txt" + li.Value + "Aciklama";
                    txt2.MaxLength = 50;
                    txt2.Width = new Unit("150");

                    Label lbl3 = new Label();
                    lbl3.Text = "</td></tr></table>";

                    pnlGelirler.Controls.Add(lbl);
                    pnlGelirler.Controls.Add(txt);
                    pnlGelirler.Controls.Add(lbl2);
                    pnlGelirler.Controls.Add(txt2);
                    pnlGelirler.Controls.Add(lbl3);

                    kacTaneSecili++;
                }
            }
        }
        #endregion
        //
        //
        #region Yabanci Dilleri Olustur
        private void YabanciDilleriOlustur()
        {
            byte kacTaneSecili = 0;

            foreach (ListItem li in cblYabanciDiller.Items)
            {
                if (li.Selected)
                {
                    pnlYabanciDiller.Visible = true;

                    Label lbl = new Label();
                    lbl.Text = "<table><tr><td style='width: 150px'>" + li.Text + ": </td><td style='width: 90px'>";

                    DropDownList ddl = new DropDownList();
                    ddl.ID = "ddl" + li.Value + "OkumaDerece";
                    Dereceler.GetObject(ddl.Items);

                    Label lbl2 = new Label();
                    lbl2.Text = "</td><td style='width: 90px'>";

                    DropDownList ddl2 = new DropDownList();
                    ddl2.ID = "ddl" + li.Value + "YazmaDerece";
                    Dereceler.GetObject(ddl2.Items);

                    Label lbl3 = new Label();
                    lbl3.Text = "</td><td style='width: 90px'>";

                    DropDownList ddl3 = new DropDownList();
                    ddl3.ID = "ddl" + li.Value + "KonusmaDerece";
                    Dereceler.GetObject(ddl3.Items);

                    Label lbl4 = new Label();
                    lbl4.Text = "</td></tr></table>";

                    pnlYabanciDiller.Controls.Add(lbl);
                    pnlYabanciDiller.Controls.Add(ddl);
                    pnlYabanciDiller.Controls.Add(lbl2);
                    pnlYabanciDiller.Controls.Add(ddl2);
                    pnlYabanciDiller.Controls.Add(lbl3);
                    pnlYabanciDiller.Controls.Add(ddl3);
                    pnlYabanciDiller.Controls.Add(lbl4);

                    kacTaneSecili++;
                }
            }

            if (kacTaneSecili == 0)
            {
                
            }
        }
        # endregion
        //
        //
        //
        // Olaylar:
        //
        #region Olaylar
        protected void ddlNufusIl_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlNufusIlce.Items.Clear();

            Ilceler.GetObject(ddlNufusIlce.Items, ddlNufusIl.SelectedValue);

            //SonradanOlusanlar();
        }
        //
        //
        protected void ddlAdresIl_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlAdresIlce.Items.Clear();

            Ilceler.GetObject(ddlAdresIlce.Items, ddlAdresIl.SelectedValue);

            //SonradanOlusanlar();
        }
        //
        //
        protected void cblGelirler_SelectedIndexChanged(object sender, EventArgs e)
        {
            tblGelir.Visible = false;

            for (int i = 0; i < cblGelirler.Items.Count; i++)
            {
                if (cblGelirler.Items[i].Selected)
                {
                    tblGelir.Visible = true;
                }
            }

            foreach (ListItem li in cblGelirler.Items)
            {
                foreach (Control ctrl in pnlGelirler.Controls)
                {
                    if (ctrl.ID == "divGelir" + li.Value)
                    {
                        if (li.Selected)
                        {
                            ctrl.Visible = true;

                            foreach (Control ctrl2 in ctrl.Controls)
                            {
                                if (ctrl2.ID == "lblGelir" + li.Value)
                                {
                                    ((Label)ctrl2).Text = li.Text;
                                }
                            }
                        }
                        else
                        {
                            ctrl.Visible = false;
                        }
                    }
                }
            }



            //GelirleriOlustur();

            //YabanciDilleriOlustur();
        }
        //
        //
        protected void cblYabanciDiller_SelectedIndexChanged(object sender, EventArgs e)
        {
            tblDil.Visible = false;

            for (int i = 0; i < cblYabanciDiller.Items.Count; i++)
            {
                if (cblYabanciDiller.Items[i].Selected)
                {
                    tblDil.Visible = true;
                }
            }

            foreach (ListItem li in cblYabanciDiller.Items)
            {
                foreach (Control ctrl in pnlYabanciDiller.Controls)
                {
                    if (ctrl.ID == "divDil" + li.Value)
                    {
                        if (li.Selected)
                        {
                            ctrl.Visible = true;

                            foreach (Control ctrl2 in ctrl.Controls)
                            {
                                if (ctrl2.ID == "lblDil" + li.Value)
                                {
                                    ((Label)ctrl2).Text = li.Text;
                                }
                                else if (ctrl2.ID == "ddlDil" + li.Value + "Okuma" || ctrl2.ID == "ddlDil" + li.Value + "Yazma" || ctrl2.ID == "ddlDil" + li.Value + "Konusma")
                                {
                                    Dereceler.GetObject(((DropDownList)ctrl2).Items);
                                }
                            }
                        }
                        else
                        {
                            ctrl.Visible = false;
                        }
                    }
                }
            }




            //YabanciDilleriOlustur();

            //GelirleriOlustur(); 
        }
        //
        //
        protected void cblBilgisayarProgramlari_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cblBilgisayarProgramlari.SelectedItem.Value == "1") // diğer seçili ise
            {
                if (cblBilgisayarProgramlari.SelectedItem.Selected)
                {
                    txtBildigiBilgisayarProgramiDiger.ReadOnly = false;
                }
                else
                {
                    txtBildigiBilgisayarProgramiDiger.ReadOnly = true;
                }
            }
        }
        #endregion
        //
        //
        //
        // Basvuruyu tamamla:
        //
        protected void lbGonder_Click(object sender, EventArgs e)
        {
            bool KrediKartiTakibat = false;
            bool SurenHastalik = false;
            bool OnemliAmeliyat = false;
            bool Sakatlik = false;
            if (txtKrediKartiTakibat.Text.Trim() != string.Empty)
            {
                KrediKartiTakibat = true;
            }
            if (txtSurenHastalik.Text.Trim() != string.Empty)
            {
                SurenHastalik = true;
            }
            if (txtOnemliAmeliyat.Text.Trim() != string.Empty)
            {
                OnemliAmeliyat = true;
            }
            if (txtSakatlik.Text.Trim() != string.Empty)
            {
                Sakatlik = true;
            }
            byte[] yeniresim = null;
            if (fuResim.HasFile && fuResim.FileName.IndexOf(".exe") < 0 && fuResim.PostedFile.ContentLength < 1048576)
            {
                if (fuResim.FileName.IndexOf(".jpg") > 0 || fuResim.FileName.IndexOf(".jpeg") > 0 || fuResim.FileName.IndexOf(".png") > 0 ||
                    fuResim.FileName.IndexOf(".bmp") > 0 || fuResim.FileName.IndexOf(".gif") > 0)
                {
                    string resimformati = fuResim.PostedFile.ContentType;
                    yeniresim = Resim.ImageToByte(
                                            Resim.ResimKucult(
                                                System.Drawing.Image.FromStream(
                                                    fuResim.PostedFile.InputStream), 120), resimformati);
                }
            }


            int BasvuruID = 0;
            if (Session["ArananGorevID"] != null)
            {
                if (Session["ArananGorevID"].ToString() != "0")
                {
                    BasvuruID = ArananGorevler.GetObjectByID(Convert.ToInt32(Session["ArananGorevID"]), DateTime.Now);
                    Session["ArananGorevID"] = "0";
                }
            }


            Basvurular bas = new Basvurular(txtAd.Text.Trim(), txtSoyad.Text.Trim(), txtDogumTarihi.Text, Convert.ToByte(ddlDogumYeriIl.SelectedValue),
                rbCinsiyetBay.Checked, txtTCKimlik.Text.Trim(), Convert.ToByte(ddlNufusIl.SelectedValue), Convert.ToInt16(ddlNufusIlce.SelectedValue),
                Convert.ToByte(ddlMedeniDurum.SelectedValue), txtAnneAdi.Text.Trim() + ", " + txtBabaAdi.Text.Trim(), rbSurucuBelgesiEvet.Checked, Convert.ToByte(ddlSurucuBelgeSinif.SelectedValue),
                txtSurucuBelgeTarih.Text, rbPsikoEvet.Checked, Convert.ToByte(ddlSRC.SelectedValue), txtBoy.Text.Trim(), txtKilo.Text.Trim(),
                txtKardesSayisi.Text.Trim(), txtAdres.Text.Trim(), txtEvTelefonu.Text.Trim(), txtCepTelefonu.Text.Trim(), Convert.ToInt16(ddlAdresIlce.SelectedValue),
                Convert.ToByte(ddlAdresIl.SelectedValue), txtEpostaAdresi.Text.Trim(), txtWebSayfasi.Text.Trim(), txtEsAd.Text.Trim(), txtEsSoyad.Text.Trim(),
                txtEsMeslek.Text.Trim(), txtEsDogumTarihi.Text, Convert.ToByte(ddlAskerlikDurumu.SelectedValue), Convert.ToByte(ddlAskerlikTipi.SelectedValue),
                txtAskerlikTerhisTarihi.Text, txtAskerlikTecilTarihi.Text, txtMuafNedeni.Text.Trim(), txtAskerlikSinifi.Text.Trim(),
                Convert.ToByte(ddlOgrenimDurumu.SelectedValue), rbMahkemeVar.Checked, txtMahkemeNedeni.Text.Trim(), txtMahkemeDurusmaTarihi.Text,
                rbMahkumiyetVar.Checked, txtMahkumiyetNedeni.Text.Trim(), txtMahkumiyetTahliyeTarihi.Text, txtBakmaklaYukumluYakin.Text.Trim(),
                txtTedaviyeMuhtacYakin.Text.Trim(), KrediKartiTakibat, txtKrediKartiTakibat.Text.Trim(), SurenHastalik, txtSurenHastalik.Text.Trim(), OnemliAmeliyat,
                txtOnemliAmeliyat.Text.Trim(), Sakatlik, txtSakatlik.Text.Trim(), rbEvSizinEvet.Checked, rbBaskaEvEvet.Checked, txtBaskaEvAdresDurum.Text.Trim(),
                rbOtomobilVar.Checked, txtOtomobilMarkaModelDurum.Text.Trim(), txtUyeDernekKlupKurulus.Text.Trim(), txtOzelMerakHobi.Text.Trim(),
                txtBildigiBilgisayarProgramiDiger.Text.Trim(), txtMeslekBasarisi.Text.Trim(), txtSirketTanidik.Text.Trim(), rbDahaOnceBasvuruEvet.Checked,
                txtTalepUcret.Text.Trim(), txtIsBaslangicTarihi.Text, rbSigaraEvet.Checked, txtIsOzelBeklenti.Text.Trim(), rbVardiyaliCalismaEvet.Checked,
                rbSehirDisiCalismaEvet.Checked, txtSehirDisiCalismaKisitlama.Text.Trim(), txtCalismaHayatiBeklenti.Text.Trim(), DateTime.Now,
                "", false, yeniresim, BasvuruID, false);
            bas.DoInsert();



            // cocuklar:
            if (Convert.ToInt32(ddlKacCocukVar.SelectedValue) == 1)
            {
                Cocuklar cc = new Cocuklar(bas.pkBasvuruID, txtCocuk1Ad.Text.Trim(), rbCocuk1CinsiyetErkek.Checked, txtCocuk1DogumTarihi.Text, txtCocuk1Okul.Text.Trim());
                cc.DoInsert();
            }
            else if (Convert.ToInt32(ddlKacCocukVar.SelectedValue) == 2)
            {
                Cocuklar cc = new Cocuklar(bas.pkBasvuruID, txtCocuk1Ad.Text.Trim(), rbCocuk1CinsiyetErkek.Checked, txtCocuk1DogumTarihi.Text, txtCocuk1Okul.Text.Trim());
                cc.DoInsert();
                cc = new Cocuklar(bas.pkBasvuruID, txtCocuk2Ad.Text.Trim(), rbCocuk2CinsiyetErkek.Checked, txtCocuk2DogumTarihi.Text, txtCocuk2Okul.Text.Trim());
                cc.DoInsert();
            }
            else if (Convert.ToInt32(ddlKacCocukVar.SelectedValue) == 3)
            {
                Cocuklar cc = new Cocuklar(bas.pkBasvuruID, txtCocuk1Ad.Text.Trim(), rbCocuk1CinsiyetErkek.Checked, txtCocuk1DogumTarihi.Text, txtCocuk1Okul.Text.Trim());
                cc.DoInsert();
                cc = new Cocuklar(bas.pkBasvuruID, txtCocuk2Ad.Text.Trim(), rbCocuk2CinsiyetErkek.Checked, txtCocuk2DogumTarihi.Text, txtCocuk2Okul.Text.Trim());
                cc.DoInsert();
                cc = new Cocuklar(bas.pkBasvuruID, txtCocuk3Ad.Text.Trim(), rbCocuk3CinsiyetErkek.Checked, txtCocuk3DogumTarihi.Text, txtCocuk3Okul.Text.Trim());
                cc.DoInsert();
            }
            else if (Convert.ToInt32(ddlKacCocukVar.SelectedValue) == 4)
            {
                Cocuklar cc = new Cocuklar(bas.pkBasvuruID, txtCocuk1Ad.Text.Trim(), rbCocuk1CinsiyetErkek.Checked, txtCocuk1DogumTarihi.Text, txtCocuk1Okul.Text.Trim());
                cc.DoInsert();
                cc = new Cocuklar(bas.pkBasvuruID, txtCocuk2Ad.Text.Trim(), rbCocuk2CinsiyetErkek.Checked, txtCocuk2DogumTarihi.Text, txtCocuk2Okul.Text.Trim());
                cc.DoInsert();
                cc = new Cocuklar(bas.pkBasvuruID, txtCocuk3Ad.Text.Trim(), rbCocuk3CinsiyetErkek.Checked, txtCocuk3DogumTarihi.Text, txtCocuk3Okul.Text.Trim());
                cc.DoInsert();
                cc = new Cocuklar(bas.pkBasvuruID, txtCocuk4Ad.Text.Trim(), rbCocuk4CinsiyetErkek.Checked, txtCocuk4DogumTarihi.Text, txtCocuk4Okul.Text.Trim());
                cc.DoInsert();
            }
            else if (Convert.ToInt32(ddlKacCocukVar.SelectedValue) == 5)
            {
                Cocuklar cc = new Cocuklar(bas.pkBasvuruID, txtCocuk1Ad.Text.Trim(), rbCocuk1CinsiyetErkek.Checked, txtCocuk1DogumTarihi.Text, txtCocuk1Okul.Text.Trim());
                cc.DoInsert();
                cc = new Cocuklar(bas.pkBasvuruID, txtCocuk2Ad.Text.Trim(), rbCocuk2CinsiyetErkek.Checked, txtCocuk2DogumTarihi.Text, txtCocuk2Okul.Text.Trim());
                cc.DoInsert();
                cc = new Cocuklar(bas.pkBasvuruID, txtCocuk3Ad.Text.Trim(), rbCocuk3CinsiyetErkek.Checked, txtCocuk3DogumTarihi.Text, txtCocuk3Okul.Text.Trim());
                cc.DoInsert();
                cc = new Cocuklar(bas.pkBasvuruID, txtCocuk4Ad.Text.Trim(), rbCocuk4CinsiyetErkek.Checked, txtCocuk4DogumTarihi.Text, txtCocuk4Okul.Text.Trim());
                cc.DoInsert();
                cc = new Cocuklar(bas.pkBasvuruID, txtCocuk5Ad.Text.Trim(), rbCocuk5CinsiyetErkek.Checked, txtCocuk5DogumTarihi.Text, txtCocuk5Okul.Text.Trim());
                cc.DoInsert();
            }




            // egitimler:
            if (Convert.ToInt32(ddlOgrenimDurumu.SelectedValue) == 1)
            {
                Egitimler eg = new Egitimler(bas.pkBasvuruID, 1, txtIlkokulAdi.Text.Trim(), txtIlkokulBolum.Text.Trim(), txtIlkokulBitirmeYili.Text.Trim());
                eg.DoInsert();
            }
            else if (Convert.ToInt32(ddlOgrenimDurumu.SelectedValue) == 2)
            {
                Egitimler eg = new Egitimler(bas.pkBasvuruID, 1, txtIlkokulAdi.Text.Trim(), txtIlkokulBolum.Text.Trim(), txtIlkokulBitirmeYili.Text.Trim());
                eg.DoInsert();
                eg = new Egitimler(bas.pkBasvuruID, 2, txtOrtaokulAdi.Text.Trim(), txtOrtaokulBolum.Text.Trim(), txtOrtaokulBitirmeYili.Text.Trim());
                eg.DoInsert();
            }
            else if (Convert.ToInt32(ddlOgrenimDurumu.SelectedValue) == 3)
            {
                Egitimler eg = new Egitimler(bas.pkBasvuruID, 1, txtIlkokulAdi.Text.Trim(), txtIlkokulBolum.Text.Trim(), txtIlkokulBitirmeYili.Text.Trim());
                eg.DoInsert();
                eg = new Egitimler(bas.pkBasvuruID, 2, txtOrtaokulAdi.Text.Trim(), txtOrtaokulBolum.Text.Trim(), txtOrtaokulBitirmeYili.Text.Trim());
                eg.DoInsert();
                eg = new Egitimler(bas.pkBasvuruID, 3, txtLiseAdi.Text.Trim(), txtLiseBolum.Text.Trim(), txtLiseBitirmeYili.Text.Trim());
                eg.DoInsert();
            }
            else if (Convert.ToInt32(ddlOgrenimDurumu.SelectedValue) == 4)
            {
                Egitimler eg = new Egitimler(bas.pkBasvuruID, 1, txtIlkokulAdi.Text.Trim(), txtIlkokulBolum.Text.Trim(), txtIlkokulBitirmeYili.Text.Trim());
                eg.DoInsert();
                eg = new Egitimler(bas.pkBasvuruID, 2, txtOrtaokulAdi.Text.Trim(), txtOrtaokulBolum.Text.Trim(), txtOrtaokulBitirmeYili.Text.Trim());
                eg.DoInsert();
                eg = new Egitimler(bas.pkBasvuruID, 3, txtLiseAdi.Text.Trim(), txtLiseBolum.Text.Trim(), txtLiseBitirmeYili.Text.Trim());
                eg.DoInsert();
                eg = new Egitimler(bas.pkBasvuruID, 4, txtUniversiteAdi.Text.Trim(), txtUniversiteBolum.Text.Trim(), txtUniversiteBitirmeYili.Text.Trim());
                eg.DoInsert();
            }
            else if (Convert.ToInt32(ddlOgrenimDurumu.SelectedValue) == 5 || Convert.ToInt32(ddlOgrenimDurumu.SelectedValue) == 6)
            {
                Egitimler eg = new Egitimler(bas.pkBasvuruID, 1, txtIlkokulAdi.Text.Trim(), txtIlkokulBolum.Text.Trim(), txtIlkokulBitirmeYili.Text.Trim());
                eg.DoInsert();
                eg = new Egitimler(bas.pkBasvuruID, 2, txtOrtaokulAdi.Text.Trim(), txtOrtaokulBolum.Text.Trim(), txtOrtaokulBitirmeYili.Text.Trim());
                eg.DoInsert();
                eg = new Egitimler(bas.pkBasvuruID, 3, txtLiseAdi.Text.Trim(), txtLiseBolum.Text.Trim(), txtLiseBitirmeYili.Text.Trim());
                eg.DoInsert();
                eg = new Egitimler(bas.pkBasvuruID, 4, txtUniversiteAdi.Text.Trim(), txtUniversiteBolum.Text.Trim(), txtUniversiteBitirmeYili.Text.Trim());
                eg.DoInsert();
                eg = new Egitimler(bas.pkBasvuruID, 5, txtLisansUstuAdi.Text.Trim(), txtLisansUstuBolum.Text.Trim(), txtLisansUstuBitirmeYili.Text.Trim());
                eg.DoInsert();
            }
            else if (Convert.ToInt32(ddlOgrenimDurumu.SelectedValue) == 8)
            {
                Egitimler eg = new Egitimler(bas.pkBasvuruID, 1, txtIlkokulAdi.Text.Trim(), txtIlkokulBolum.Text.Trim(), txtIlkokulBitirmeYili.Text.Trim());
                eg.DoInsert();
                eg = new Egitimler(bas.pkBasvuruID, 2, txtOrtaokulAdi.Text.Trim(), txtOrtaokulBolum.Text.Trim(), txtOrtaokulBitirmeYili.Text.Trim());
                eg.DoInsert();
                eg = new Egitimler(bas.pkBasvuruID, 3, txtLiseAdi.Text.Trim(), txtLiseBolum.Text.Trim(), txtLiseBitirmeYili.Text.Trim());
                eg.DoInsert();
                eg = new Egitimler(bas.pkBasvuruID, 8, txtYuksekOkulAdi.Text.Trim(), txtYuksekOkulBolum.Text.Trim(), txtYuksekOkulBitirmeYili.Text.Trim());
                eg.DoInsert();
            }




            // kurslar:
            if (Convert.ToInt32(ddlKacProgramKatildi.SelectedValue) == 1)
            {
                Kurslar kr = new Kurslar(bas.pkBasvuruID, txtKurs1Konusu.Text.Trim(), txtKurs1VerenKurulus.Text.Trim(), txtKurs1Suresi.Text.Trim(), txtKurs1Yili.Text.Trim());
                kr.DoInsert();
            }
            else if (Convert.ToInt32(ddlKacProgramKatildi.SelectedValue) == 2)
            {
                Kurslar kr = new Kurslar(bas.pkBasvuruID, txtKurs1Konusu.Text.Trim(), txtKurs1VerenKurulus.Text.Trim(), txtKurs1Suresi.Text.Trim(), txtKurs1Yili.Text.Trim());
                kr.DoInsert();
                kr = new Kurslar(bas.pkBasvuruID, txtKurs2Konusu.Text.Trim(), txtKurs2VerenKurulus.Text.Trim(), txtKurs2Suresi.Text.Trim(), txtKurs2Yili.Text.Trim());
                kr.DoInsert();
            }
            else if (Convert.ToInt32(ddlKacProgramKatildi.SelectedValue) == 3)
            {
                Kurslar kr = new Kurslar(bas.pkBasvuruID, txtKurs1Konusu.Text.Trim(), txtKurs1VerenKurulus.Text.Trim(), txtKurs1Suresi.Text.Trim(), txtKurs1Yili.Text.Trim());
                kr.DoInsert();
                kr = new Kurslar(bas.pkBasvuruID, txtKurs2Konusu.Text.Trim(), txtKurs2VerenKurulus.Text.Trim(), txtKurs2Suresi.Text.Trim(), txtKurs2Yili.Text.Trim());
                kr.DoInsert();
                kr = new Kurslar(bas.pkBasvuruID, txtKurs3Konusu.Text.Trim(), txtKurs3VerenKurulus.Text.Trim(), txtKurs3Suresi.Text.Trim(), txtKurs3Yili.Text.Trim());
                kr.DoInsert();
            }
            else if (Convert.ToInt32(ddlKacProgramKatildi.SelectedValue) == 4)
            {
                Kurslar kr = new Kurslar(bas.pkBasvuruID, txtKurs1Konusu.Text.Trim(), txtKurs1VerenKurulus.Text.Trim(), txtKurs1Suresi.Text.Trim(), txtKurs1Yili.Text.Trim());
                kr.DoInsert();
                kr = new Kurslar(bas.pkBasvuruID, txtKurs2Konusu.Text.Trim(), txtKurs2VerenKurulus.Text.Trim(), txtKurs2Suresi.Text.Trim(), txtKurs2Yili.Text.Trim());
                kr.DoInsert();
                kr = new Kurslar(bas.pkBasvuruID, txtKurs3Konusu.Text.Trim(), txtKurs3VerenKurulus.Text.Trim(), txtKurs3Suresi.Text.Trim(), txtKurs3Yili.Text.Trim());
                kr.DoInsert();
                kr = new Kurslar(bas.pkBasvuruID, txtKurs4Konusu.Text.Trim(), txtKurs4VerenKurulus.Text.Trim(), txtKurs4Suresi.Text.Trim(), txtKurs4Yili.Text.Trim());
                kr.DoInsert();
            }
            else if (Convert.ToInt32(ddlKacProgramKatildi.SelectedValue) == 5)
            {
                Kurslar kr = new Kurslar(bas.pkBasvuruID, txtKurs1Konusu.Text.Trim(), txtKurs1VerenKurulus.Text.Trim(), txtKurs1Suresi.Text.Trim(), txtKurs1Yili.Text.Trim());
                kr.DoInsert();
                kr = new Kurslar(bas.pkBasvuruID, txtKurs2Konusu.Text.Trim(), txtKurs2VerenKurulus.Text.Trim(), txtKurs2Suresi.Text.Trim(), txtKurs2Yili.Text.Trim());
                kr.DoInsert();
                kr = new Kurslar(bas.pkBasvuruID, txtKurs3Konusu.Text.Trim(), txtKurs3VerenKurulus.Text.Trim(), txtKurs3Suresi.Text.Trim(), txtKurs3Yili.Text.Trim());
                kr.DoInsert();
                kr = new Kurslar(bas.pkBasvuruID, txtKurs4Konusu.Text.Trim(), txtKurs4VerenKurulus.Text.Trim(), txtKurs4Suresi.Text.Trim(), txtKurs4Yili.Text.Trim());
                kr.DoInsert();
                kr = new Kurslar(bas.pkBasvuruID, txtKurs5Konusu.Text.Trim(), txtKurs5VerenKurulus.Text.Trim(), txtKurs5Suresi.Text.Trim(), txtKurs5Yili.Text.Trim());
                kr.DoInsert();
            }




            // tecrubeler:
            if (rbSuAndaCalisiyorMuEvet.Checked)
            {
                Tecrubeler tc = new Tecrubeler(bas.pkBasvuruID, txtSimdikiIsIsyeriAdi.Text.Trim(), txtSimdikiIsGorev.Text.Trim(), txtSimdikiIsGirisTarihi.Text,
                    txtSimdikiIsCikisTarihi.Text, txtSimdikiIsUcret.Text.Trim(), txtSimdikiIsAyrilmaNedeni.Text.Trim(), true);
                tc.DoInsert();
            }
            if (Convert.ToInt32(ddlKacIsYeri.SelectedValue) == 1)
            {
                Tecrubeler tc = new Tecrubeler(bas.pkBasvuruID, txtIsIsyeri1Adi.Text.Trim(), txtIsIsyeri1Gorev.Text.Trim(), txtIsIsyeri1GirisTarihi.Text,
                    txtIsIsyeri1CikisTarihi.Text, txtIsIsyeri1Ucret.Text.Trim(), txtIsIsyeri1AyrilmaNedeni.Text.Trim(), false);
                tc.DoInsert();
            }
            else if (Convert.ToInt32(ddlKacIsYeri.SelectedValue) == 2)
            {
                Tecrubeler tc = new Tecrubeler(bas.pkBasvuruID, txtIsIsyeri1Adi.Text.Trim(), txtIsIsyeri1Gorev.Text.Trim(), txtIsIsyeri1GirisTarihi.Text,
                    txtIsIsyeri1CikisTarihi.Text, txtIsIsyeri1Ucret.Text.Trim(), txtIsIsyeri1AyrilmaNedeni.Text.Trim(), false);
                tc.DoInsert();
                tc = new Tecrubeler(bas.pkBasvuruID, txtIsIsyeri2Adi.Text.Trim(), txtIsIsyeri2Gorev.Text.Trim(), txtIsIsyeri2GirisTarihi.Text,
                    txtIsIsyeri2CikisTarihi.Text, txtIsIsyeri2Ucret.Text.Trim(), txtIsIsyeri2AyrilmaNedeni.Text.Trim(), false);
                tc.DoInsert();
            }
            else if (Convert.ToInt32(ddlKacIsYeri.SelectedValue) == 3)
            {
                Tecrubeler tc = new Tecrubeler(bas.pkBasvuruID, txtIsIsyeri1Adi.Text.Trim(), txtIsIsyeri1Gorev.Text.Trim(), txtIsIsyeri1GirisTarihi.Text,
                    txtIsIsyeri1CikisTarihi.Text, txtIsIsyeri1Ucret.Text.Trim(), txtIsIsyeri1AyrilmaNedeni.Text.Trim(), false);
                tc.DoInsert();
                tc = new Tecrubeler(bas.pkBasvuruID, txtIsIsyeri2Adi.Text.Trim(), txtIsIsyeri2Gorev.Text.Trim(), txtIsIsyeri2GirisTarihi.Text,
                    txtIsIsyeri2CikisTarihi.Text, txtIsIsyeri2Ucret.Text.Trim(), txtIsIsyeri2AyrilmaNedeni.Text.Trim(), false);
                tc.DoInsert();
                tc = new Tecrubeler(bas.pkBasvuruID, txtIsIsyeri3Adi.Text.Trim(), txtIsIsyeri3Gorev.Text.Trim(), txtIsIsyeri3GirisTarihi.Text,
                    txtIsIsyeri3CikisTarihi.Text, txtIsIsyeri3Ucret.Text.Trim(), txtIsIsyeri3AyrilmaNedeni.Text.Trim(), false);
                tc.DoInsert();
            }
            else if (Convert.ToInt32(ddlKacIsYeri.SelectedValue) == 4)
            {
                Tecrubeler tc = new Tecrubeler(bas.pkBasvuruID, txtIsIsyeri1Adi.Text.Trim(), txtIsIsyeri1Gorev.Text.Trim(), txtIsIsyeri1GirisTarihi.Text,
                    txtIsIsyeri1CikisTarihi.Text, txtIsIsyeri1Ucret.Text.Trim(), txtIsIsyeri1AyrilmaNedeni.Text.Trim(), false);
                tc.DoInsert();
                tc = new Tecrubeler(bas.pkBasvuruID, txtIsIsyeri2Adi.Text.Trim(), txtIsIsyeri2Gorev.Text.Trim(), txtIsIsyeri2GirisTarihi.Text,
                    txtIsIsyeri2CikisTarihi.Text, txtIsIsyeri2Ucret.Text.Trim(), txtIsIsyeri2AyrilmaNedeni.Text.Trim(), false);
                tc.DoInsert();
                tc = new Tecrubeler(bas.pkBasvuruID, txtIsIsyeri3Adi.Text.Trim(), txtIsIsyeri3Gorev.Text.Trim(), txtIsIsyeri3GirisTarihi.Text,
                    txtIsIsyeri3CikisTarihi.Text, txtIsIsyeri3Ucret.Text.Trim(), txtIsIsyeri3AyrilmaNedeni.Text.Trim(), false);
                tc.DoInsert();
                tc = new Tecrubeler(bas.pkBasvuruID, txtIsIsyeri4Adi.Text.Trim(), txtIsIsyeri4Gorev.Text.Trim(), txtIsIsyeri4GirisTarihi.Text,
                    txtIsIsyeri4CikisTarihi.Text, txtIsIsyeri4Ucret.Text.Trim(), txtIsIsyeri4AyrilmaNedeni.Text.Trim(), false);
                tc.DoInsert();
            }




            // kredi kartlari:
            if (Convert.ToInt32(ddlKacKrediKarti.SelectedValue) == 1)
            {
                KrediKartlari kk = new KrediKartlari(bas.pkBasvuruID, txtKrediKarti1.Text.Trim(), txtKrediKarti1Limiti.Text.Trim());
                kk.DoInsert();
            }
            else if (Convert.ToInt32(ddlKacKrediKarti.SelectedValue) == 2)
            {
                KrediKartlari kk = new KrediKartlari(bas.pkBasvuruID, txtKrediKarti1.Text.Trim(), txtKrediKarti1Limiti.Text.Trim());
                kk.DoInsert();
                kk = new KrediKartlari(bas.pkBasvuruID, txtKrediKarti2.Text.Trim(), txtKrediKarti2Limiti.Text.Trim());
                kk.DoInsert();
            }
            else if (Convert.ToInt32(ddlKacKrediKarti.SelectedValue) == 3)
            {
                KrediKartlari kk = new KrediKartlari(bas.pkBasvuruID, txtKrediKarti1.Text.Trim(), txtKrediKarti1Limiti.Text.Trim());
                kk.DoInsert();
                kk = new KrediKartlari(bas.pkBasvuruID, txtKrediKarti2.Text.Trim(), txtKrediKarti2Limiti.Text.Trim());
                kk.DoInsert();
                kk = new KrediKartlari(bas.pkBasvuruID, txtKrediKarti3.Text.Trim(), txtKrediKarti3Limiti.Text.Trim());
                kk.DoInsert();
            }




            // referanslar:
            if (Convert.ToInt32(ddlKacReferans.SelectedValue) == 1)
            {
                Referanslar rf = new Referanslar(bas.pkBasvuruID, txtReferans1Adi.Text.Trim(), txtReferans1Sirketi.Text.Trim(), txtReferans1Gorevi.Text.Trim(),
                    txtReferans1Telefonu.Text.Trim());
                rf.DoInsert();
            }
            else if (Convert.ToInt32(ddlKacReferans.SelectedValue) == 2)
            {
                Referanslar rf = new Referanslar(bas.pkBasvuruID, txtReferans1Adi.Text.Trim(), txtReferans1Sirketi.Text.Trim(), txtReferans1Gorevi.Text.Trim(),
                    txtReferans1Telefonu.Text.Trim());
                rf.DoInsert();
                rf = new Referanslar(bas.pkBasvuruID, txtReferans2Adi.Text.Trim(), txtReferans2Sirketi.Text.Trim(), txtReferans2Gorevi.Text.Trim(),
                    txtReferans2Telefonu.Text.Trim());
                rf.DoInsert();
            }
            else if (Convert.ToInt32(ddlKacReferans.SelectedValue) == 3)
            {
                Referanslar rf = new Referanslar(bas.pkBasvuruID, txtReferans1Adi.Text.Trim(), txtReferans1Sirketi.Text.Trim(), txtReferans1Gorevi.Text.Trim(),
                    txtReferans1Telefonu.Text.Trim());
                rf.DoInsert();
                rf = new Referanslar(bas.pkBasvuruID, txtReferans2Adi.Text.Trim(), txtReferans2Sirketi.Text.Trim(), txtReferans2Gorevi.Text.Trim(),
                    txtReferans2Telefonu.Text.Trim());
                rf.DoInsert();
                rf = new Referanslar(bas.pkBasvuruID, txtReferans3Adi.Text.Trim(), txtReferans3Sirketi.Text.Trim(), txtReferans3Gorevi.Text.Trim(),
                    txtReferans3Telefonu.Text.Trim());
                rf.DoInsert();
            }




            // gorevler:
            for (int i = 0; i < cblGorevler.Items.Count; i++)
            {
                if (cblGorevler.Items[i].Selected)
                {
                    SecilenGorevler sg = new SecilenGorevler(bas.pkBasvuruID, Convert.ToByte(cblGorevler.Items[i].Value));
                    sg.DoInsert();
                }
            }





            // bilgisayar programlari:
            for (int i = 0; i < cblBilgisayarProgramlari.Items.Count; i++)
            {
                if (cblBilgisayarProgramlari.Items[i].Selected)
                {
                    BildigiBilgisayarProgramlari bbp = new BildigiBilgisayarProgramlari(bas.pkBasvuruID, Convert.ToByte(cblBilgisayarProgramlari.Items[i].Value));
                    bbp.DoInsert();
                }
            }





            // gelirler:
            for (int i = 0; i < cblGelirler.Items.Count; i++) // butun gelir turlerine bak
            {
                if (cblGelirler.Items[i].Selected) // hangi gelir turu secili
                {
                    foreach (Control ctrl in pnlGelirler.Controls) // paneldeki kontrollere bak (divlere)
                    {
                        if (ctrl.ID != "tblGelir" && ctrl.Visible == true)
                        {
                            string tutar = string.Empty;
                            string aciklama = string.Empty;

                            foreach (Control ctrl2 in ctrl.Controls) // panelin icindeki kontrolun (divin) icindeki kontrollere bak
                            {
                                if (ctrl2.ID == "txtGelir" + cblGelirler.Items[i].Value + "Tutar")
                                {
                                    tutar = ((TextBox)ctrl2).Text;
                                }
                                else if (ctrl2.ID == "txtGelir" + cblGelirler.Items[i].Value + "Aciklama")
                                {
                                    aciklama = ((TextBox)ctrl2).Text;
                                }
                            }


                            if (tutar != string.Empty && aciklama != string.Empty)
                            {
                                Gelirler glr = new Gelirler(bas.pkBasvuruID, Convert.ToByte(cblGelirler.Items[i].Value), tutar, aciklama);
                                glr.DoInsert();
                            }
                        }
                    }
                }
            }





            // yabancidiller:
            for (int i = 0; i < cblYabanciDiller.Items.Count; i++) // butun dillere bak
            {
                if (cblYabanciDiller.Items[i].Selected) // hangi diller secili
                {
                    foreach (Control ctrl in pnlYabanciDiller.Controls) // paneldeki kontrollere bak (divlere)
                    {
                        if (ctrl.ID != "tblDil" && ctrl.Visible == true)
                        {
                            byte okuma = 0;
                            byte yazma = 0;
                            byte konusma = 0;

                            foreach (Control ctrl2 in ctrl.Controls) // panelin icindeki kontrolun (divin) icindeki kontrollere bak
                            {
                                if (ctrl2.ID == "ddlDil" + cblYabanciDiller.Items[i].Value + "Okuma")
                                {
                                    okuma = Convert.ToByte(((DropDownList)ctrl2).SelectedValue);
                                }
                                else if (ctrl2.ID == "ddlDil" + cblYabanciDiller.Items[i].Value + "Yazma")
                                {
                                    yazma = Convert.ToByte(((DropDownList)ctrl2).SelectedValue);
                                }
                                else if (ctrl2.ID == "ddlDil" + cblYabanciDiller.Items[i].Value + "Konusma")
                                {
                                    konusma = Convert.ToByte(((DropDownList)ctrl2).SelectedValue);
                                }
                            }


                            if (okuma != 0 && yazma != 0 && konusma != 0)
                            {
                                YabanciDiller yd = new YabanciDiller(bas.pkBasvuruID, Convert.ToByte(cblYabanciDiller.Items[i].Value), okuma, yazma, konusma);
                                yd.DoInsert();
                            }
                        }
                    }
                }
            }




            string[] nerelere = new string[1];
            nerelere[0] = txtEpostaAdresi.Text.Trim();
            Eposta.EpostaYolla("sultanlar@sultanlar.com.tr", "", nerelere, "Sultanlar Pazarlama A.Ş.", "İş Başvurusu", "İş başvurunuz alınmıştır. Teşekkür ederiz.<br /><br />Sultanlar Pazarlama A.Ş.");
            Session["BasvuruTamam"] = 1;
            Response.Redirect("isbasvurutam.html");
        }
    }
}
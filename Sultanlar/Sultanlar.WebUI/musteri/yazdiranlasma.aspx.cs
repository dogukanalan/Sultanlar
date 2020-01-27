using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Sultanlar.DatabaseObject.Internet;

namespace Sultanlar.WebUI.musteri
{
    public partial class yazdiranlasma : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Anlasmalar anlasma = Anlasmalar.GetObject(Convert.ToInt32(Request.QueryString["id"]));

            if (anlasma.strAciklama2 == "1")
            {
                CariHesaplarTP musteri = CariHesaplarTP.GetObject(Convert.ToInt32(anlasma.SMREF), false);
                txtAnlasmaMusteri.Text = musteri.SUBE;
                txtAnlasmaIl.Text = musteri.IL;
                txtAnlasmaBayi.Text = CariHesaplarTP.GetObject(Convert.ToInt32(anlasma.SMREF), true).MUSTERI;
            }
            else if (anlasma.strAciklama2 == "2")
            {
                txtAnlasmaBayi.Text = "SULTANLAR PAZARLAMA A.Ş.";
                txtAnlasmaIl.Text = "İSTANBUL";
                txtAnlasmaMusteri.Text = CariHesaplar.GetMUSTERIbySMREF(anlasma.SMREF);
            }

            txtAnlasmaSubeSayisi.Text = anlasma.strAciklama4;
            datepickerAnlasmaBaslangic.Value = anlasma.dtBaslangic.ToShortDateString();
            datepickerAnlasmaBitis.Value = anlasma.dtBitis.ToShortDateString();
            txtAnlasmaVadeTAH.Text = anlasma.intVadeTAH.ToString();
            txtAnlasmaVadeYEG.Text = anlasma.intVadeYEG.ToString();
            txtAnlasmaSKUTAH.Text = anlasma.intListSKUTAH.ToString();
            txtAnlasmaSKUYEG.Text = anlasma.intListSKUYEG.ToString();

            txtAnlasmaTAHIsk.Text = anlasma.flTAHIsk.ToString("N1");
            txtAnlasmaTAHCiro.Text = anlasma.flTAHCiro.ToString("N1");
            txtAnlasmaTAHCiro3.Text = anlasma.flTAHCiro3.ToString("N1");
            txtAnlasmaTAHCiro6.Text = anlasma.flTAHCiro6.ToString("N1");
            txtAnlasmaTAHCiro12.Text = anlasma.flTAHCiro12.ToString("N1");
            txtAnlasmaTAHCiroIsk.Text = anlasma.flTAHCiroIsk.ToString("N1");
            txtAnlasmaYEGIsk.Text = anlasma.flYEGIsk.ToString("N1");
            txtAnlasmaYEGCiro.Text = anlasma.flYEGCiro.ToString("N1");
            txtAnlasmaYEGCiro3.Text = anlasma.flYEGCiro3.ToString("N1");
            txtAnlasmaYEGCiro6.Text = anlasma.flYEGCiro6.ToString("N1");
            txtAnlasmaYEGCiro12.Text = anlasma.flYEGCiro12.ToString("N1");
            txtAnlasmaYEGCiroIsk.Text = anlasma.flYEGCiroIsk.ToString("N1");

            txtAnlasmaTAHAnlasmaDisiBedeller.Text = anlasma.mnTAHAnlasmaDisiBedeller.ToString("C2");
            txtAnlasmaYEGAnlasmaDisiBedeller.Text = anlasma.mnYEGAnlasmaDisiBedeller.ToString("C2");
            txtAnlasmaTAHTumBedeller.Text = (anlasma.mnTAHAnlasmaDisiBedeller + anlasma.TAHTumBedellerToplami).ToString("C2");
            txtAnlasmaYEGTumBedeller.Text = (anlasma.mnYEGAnlasmaDisiBedeller + anlasma.YEGTumBedellerToplami).ToString("C2");
            txtAnlasmaTAHToplamCiro.Text = anlasma.mnTAHToplamCiro.ToString("C2");
            txtAnlasmaYEGToplamCiro.Text = anlasma.mnYEGToplamCiro.ToString("C2");
            txtAnlasmaTAHYilSonuMaliyet.Text = anlasma.TAHYilSonuMaliyet.ToString("N1");
            txtAnlasmaYEGYilSonuMaliyet.Text = anlasma.YEGYilSonuMaliyet.ToString("N1");
            txtAnlasmaTAHCiroPrimiDahil.Text = anlasma.TAHCiroPrimiDahilNetMaliyet.ToString("N1");
            txtAnlasmaYEGCiroPrimiDahil.Text = anlasma.YEGCiroPrimiDahilNetMaliyet.ToString("N1");
            txtAnlasmaAciklama.Text = anlasma.strAciklama1;

            DataTable dt = new DataTable();
            AnlasmaBedeller.GetObjects(dt, anlasma.pkID);
            rptHizmetBedelleri.DataSource = dt;
            rptHizmetBedelleri.DataBind();
        }
    }
}
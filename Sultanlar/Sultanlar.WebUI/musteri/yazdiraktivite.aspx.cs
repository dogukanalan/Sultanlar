using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sultanlar.DatabaseObject.Internet;
using System.Data;

namespace Sultanlar.WebUI.musteri
{
    public partial class yazdiraktivite : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["yazdiraktiviteid"] != null && Session["yazdiraktiviteid"] != Session["oncekiyazdiraktiviteid"])
            {
                Label1.Visible = false;
                divYazdir.Visible = true;

                int aktiviteid = Convert.ToInt32(Session["yazdiraktiviteid"]);
                Session["yazdiraktiviteid"] = null;

                Aktiviteler aktivite = Aktiviteler.GetObject(aktiviteid);

                lblCariHesap.Text = aktivite.intAktiviteTipiID == 1 ? CariHesaplarTP.GetObject(CariHesaplarTP.GetGMREFBySMREF(aktivite.SMREF), true).MUSTERI : "SULTANLAR PAZARLAMA A.Ş.";
                lblAltCari.Text = aktivite.intAktiviteTipiID == 1 ? CariHesaplarTP.GetObject(aktivite.SMREF, false).MUSTERI : CariHesaplar.GetMUSTERIbySMREF(aktivite.SMREF);
                lblOlusmaTarihi.Text = aktivite.dtOnaylamaTarihi.ToShortDateString();
                lblBaslangic.Text = aktivite.dtAktiviteBaslangic.ToShortDateString();
                lblBitis.Text = aktivite.dtAktiviteBitis.ToShortDateString();
                lblAciklama.Text = aktivite.strAciklama1;
                lblAciklama2.Text = aktivite.strAciklama2;
                lblAciklama3.Text = aktivite.strAciklama3;
                lblAciklama4.Text = aktivite.strAciklama4;

                DataTable dt = new DataTable();
                AktivitelerDetay.GetObjectsByAktiviteID(dt, aktiviteid);

                AktiviteListe1 aktlist = new AktiviteListe1(aktivite.intMusteriID, aktivite.SMREF, aktivite.sintFiyatTipiID, aktivite.intAktiviteTipiID, false);
                aktlist._AktiviteID = aktiviteid;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    long aktivitedetayid = Convert.ToInt64(dt.Rows[i]["pkID"]);
                    aktlist.Add(aktivitedetayid);
                }

                Repeater1.DataSource = aktlist;
                Repeater1.DataBind();
            }
            else
            {
                Label1.Visible = true;
                divYazdir.Visible = false;
                Response.AddHeader("REFRESH", "5");
            }
        }
    }
}
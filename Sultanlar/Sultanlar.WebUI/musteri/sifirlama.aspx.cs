using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sultanlar.DatabaseObject;
using Sultanlar.DatabaseObject.Internet;

namespace Sultanlar.WebUI.musteri
{
    public partial class sifirlama : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnGonder_Click(object sender, EventArgs e)
        {
            int MusteriID = Musteriler.GetMusteriIDbyEposta(txtEposta.Text.Trim());

            if (MusteriID == 0)
            {
                Panel1.Visible = false;
                Panel3.Visible = true;
                return;
            }
            else if (MusteriSifreSifirlamaTalepler.GetLastDateByMusteri(MusteriID))
            {
                Panel1.Visible = false;
                Panel4.Visible = true;
                return;
            }
            else if (Musteriler.GetMusteriByID(MusteriID).blPasif)
            {
                Panel1.Visible = false;
                Panel5.Visible = true;
                return;
            }

            MusteriSifreSifirlamaTalepler msst = new MusteriSifreSifirlamaTalepler(MusteriID, DateTime.Now, false);
            msst.DoInsert();

            Panel1.Visible = false;
            Panel2.Visible = true;
        }

        protected void btnGeri_Click(object sender, EventArgs e)
        {
            Response.Redirect("giris.html", true);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sultanlar.WebUI.musteri
{
    public partial class ucUrunAyrinti : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void ResimAc(int ResimID)
        {
            imgResim.ImageUrl = "resim.aspx?uid=" + ResimID.ToString();
            imgTedarikci.ImageUrl = "resim.aspx?tid=" + Session["UrunAyrintiTedarikciResimID"].ToString();
        }

        public void ResimAc(int ResimID, int TedarikciResimID)
        {
            Session["UrunAyrintiTedarikciResimID"] = TedarikciResimID;
            imgResim.ImageUrl = "resim.aspx?uid=" + ResimID.ToString();
            imgTedarikci.ImageUrl = "resim.aspx?tid=" + TedarikciResimID.ToString();
        }
    }
}
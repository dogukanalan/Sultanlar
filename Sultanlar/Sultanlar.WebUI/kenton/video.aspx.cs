using Sultanlar.DatabaseObject.Kenton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sultanlar.WebUI.kenton
{
    public partial class video : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(System.Web.HttpCacheability.NoCache);
            Response.Cache.SetNoStore();

            int vid = Convert.ToInt32(Request.QueryString["vid"]);
            TarifVideo tv = TarifVideo.GetObjectByVideo(vid);
            if (tv.intTarifID > 0)
            {
                divContent.Visible = true;
                Tarifler tarif = Tarifler.GetObject(tv.intTarifID);
                spanMalzemeler.InnerHtml = tarif.strMalzemeler;
                spanHazirlanis.InnerHtml = tarif.strHazirlanis;
            }
        }
    }
}
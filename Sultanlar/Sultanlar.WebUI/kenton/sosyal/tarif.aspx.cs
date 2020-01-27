using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sultanlar.DatabaseObject.Kenton;

namespace Sultanlar.WebUI.kenton.sosyal
{
    public partial class tarif : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int tid = Convert.ToInt32(Request.QueryString["id"]);
            Tarifler tarif = Tarifler.GetObject(tid);
            spanBaslik.InnerHtml = tarif.strBaslik;
            spanHazirlanis.InnerHtml = tarif.strHazirlanis;
            spanMalzemeler.InnerHtml = tarif.strMalzemeler;
            imgResim.Src = "../../../kenton/resim.aspx?tarif=" + tid.ToString();

            if (tarif.strUrunlerLink != string.Empty)
            {
                imgUrunler.Src = "../../../kenton/resim.aspx?tarifU=" + tid.ToString();
                aUrunler.HRef = "https://www.komsu.com.tr/index.php?p=search&search=" + tarif.strUrunlerLink;
            }
            else
            {
                divSatinAl.Visible = false;
            }

            tarifid.Value = tid.ToString();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sultanlar.DatabaseObject.Internet;

namespace Sultanlar.WebUI.merch
{
    public partial class resim : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [System.Web.Services.WebMethod()]
        public static void UploadPicMerch(string imageData, string smref, string tip, string tur, string musteri, string ziyaret, string rut, string aciklama)
        {
            byte[] resim = Convert.FromBase64String(imageData);
            int SMREF = Convert.ToInt32(smref);
            int TIP = Convert.ToInt32(tip);
            int MUSTERI = Convert.ToInt32(musteri);
            int TUR = Convert.ToInt32(tur);
            int ZIYARET = Convert.ToInt32(ziyaret);
            RutResim rr = new RutResim(SMREF, TIP, MUSTERI, TUR, rut, ZIYARET, DateTime.Now, resim, aciklama, "");
            rr.DoInsert();
        }
    }
}
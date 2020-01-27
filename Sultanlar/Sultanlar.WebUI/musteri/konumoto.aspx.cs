using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Sultanlar.DatabaseObject;
using Sultanlar.DatabaseObject.Internet;

namespace Sultanlar.WebUI.musteri
{
    public partial class konumoto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dt = new DataTable();
                WebGenel.Sorgu(dt, "SELECT TOP 2500 SMREF AS Kod,TIP AS TIP_KOD,KONUM AS Adres FROM [Web-Musteri-Acik] WHERE KONUM_ADRES IS NULL"); // SELECT DISTINCT SMREF AS Kod,UPPER(IL) + ' ' + ILCE + ' ' + ADRES AS Adres,1 AS TIP_KOD FROM [Web-Musteri] WHERE SMREF NOT IN (SELECT SMREF FROM [Web-Musteri-Acik]) ORDER BY SMREF
                repe.DataSource = dt;
                repe.DataBind();
            }
        }
    }
}
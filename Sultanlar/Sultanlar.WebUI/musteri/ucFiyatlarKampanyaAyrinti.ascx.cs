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
    public partial class ucFiyatlarKampanyaAyrinti : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public event EventHandler UserControlButtonClicked;
        private void OnUserControlButtonClick()
        {
            if (UserControlButtonClicked != null)
            {
                UserControlButtonClicked(this, EventArgs.Empty);
            }
        }


        public void GetObject()
        {
            if (Session["KampanyaAyrinti"] != null)
            {
                Guid kampanyaid = new Guid();

                try
                {
                    kampanyaid = System.Guid.Parse(Session["KampanyaAyrinti"].ToString());
                }
                catch (Exception)
                {
                    Response.Write("Hatalı kampanya!");
                }

                DataTable dt = new DataTable();
                Kampanyalar.GetAnaUrunler(dt, kampanyaid);
                dlListe.DataSource = dt;

                dt = new DataTable();
                Kampanyalar.GetHediyeUrunler(dt, kampanyaid);
                dlHediye.DataSource = dt;

                DataBind();
            }
            else
            {
                Response.Write("Hatalı kampanya!");
            }
        }
    }
}
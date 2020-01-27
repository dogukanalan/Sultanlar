using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sultanlar.DatabaseObject;
using Sultanlar.Class;

namespace Sultanlar.WebUI
{
    public partial class iletisim : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Departmanlar.GetObject(ddlDepartman.Items);
            }
        }

        protected void btnGonder_Click(object sender, EventArgs e)
        {
            try
            {
                string[] nerelere = new string[2];
                nerelere[0] = Departmanlar.GetEmailByID(ddlDepartman.SelectedValue);
                nerelere[1] = "sultanlar@sultanlar.com.tr";
                Eposta.EpostaAl(txtEposta.Value.Trim(), nerelere, txtAdSoyad.Value.Trim(), ddlDepartman.SelectedItem.Text + " - Telefon: " + txtTelefon.Value.Trim(),
                    txtIleti.Value.Trim() + "<br /><br /><i><span style='font-size: 11px'>Bu eposta sitedeki iletişim formu kullanılarak yollanmıştır.</span></i>");

                divOldu.Visible = true;
                fieldsetForm.Visible = false;

                //string alert = "<script type='text/javascript'>alert('Mesajınız ilgili departmana gönderilmiştir, teşekkür ederiz.');window.location.href='iletisim.html';</script>";
                //ScriptManager.RegisterStartupScript(form1, typeof(string), "alert", alert, false);
            }
            catch (Exception)
            {
                divHata.Visible = true;
                fieldsetForm.Visible = false;
            }
        }
    }
}
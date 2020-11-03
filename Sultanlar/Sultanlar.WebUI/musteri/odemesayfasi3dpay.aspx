<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="odemesayfasi3dpay.aspx.cs" Inherits="Sultanlar.WebUI.musteri.odemesayfasi3dpay" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Ödeme Sayfası</title>
</head>
<body style="font-family: Verdana">
    <h2>
        Ödeme İşlem Sonucu</h2>
    <%--<h3>
        3D Dönen Parametreler</h3>--%>
<%--    <table border="1">
        <tr>
            <td>
                <b>Parametre İsmi:</b>
            </td>
            <td>
                <b>Parametre Değeri:</b>
            </td>
        </tr>--%>
        <%
            Sultanlar.DatabaseObject.Internet.Odemeler odm = new Sultanlar.DatabaseObject.Internet.Odemeler(
                Convert.ToInt32(Session["OdemeGMREF"]),
                ((Sultanlar.DatabaseObject.Internet.Musteriler)Session["Musteri"]).pkMusteriID,
                Convert.ToInt32(Session["OdemeSiparisNo"]),
                Convert.ToDecimal(Session["OdemeTutari"]),
                DateTime.Now
                );
            Session["OdemeTutari"] = null;
            Session["OdemeGMREF"] = null;
            Session["KrediKart"] = null;

            odm.strmdStatus = "1";
            odm.strReturnOid = Request.QueryString["orderid"];
            odm.strMaskedPan = Request.QueryString["maskedpan"];
            
            /*String[] odemeparametreleri = new String[] { "AuthCode", "Response", "HostRefNum", "ProcReturnCode", "TransId", "ErrMsg" };
            IEnumerator e = Request.Form.GetEnumerator();
            while (e.MoveNext())
            {
                String xkey = (String)e.Current;
                String xval = Request.Form.Get(xkey);
                bool ok = true;
                for (int i = 0; i < odemeparametreleri.Length; i++)
                {
                    if (xkey.Equals(odemeparametreleri[i]))
                    {
                        ok = false;
                        break;
                    }
                }
                if (ok)
                {
                    if (xkey == "mdStatus")
                        odm.strmdStatus = xval;
                    else if (xkey == "ReturnOid")
                        odm.strReturnOid = xval;
                    else if (xkey == "MaskedPan")
                        odm.strMaskedPan = xval;
                    //Response.Write("<tr><td>" + xkey + "</td><td>" + xval + "</td></tr>");
                }
            }*/
        %>
<%--    </table>--%>
    <%
        /*
        String hashparams = Request.Form.Get("HASHPARAMS");
        String hashparamsval = Request.Form.Get("HASHPARAMSVAL");
        String storekey = "sultanlaRTeb3d";
        String paramsval = "";
        int index1 = 0, index2 = 0;
        // hash hesaplamada kullanılacak değerler ayrıştırılıp değerleri birleştiriliyor.
        if (hashparams != null)
        {
            do
            {
                index2 = hashparams.IndexOf(":", index1);
                String val = Request.Form.Get(hashparams.Substring(index1, index2 - index1)) == null ? "" : Request.Form.Get(hashparams.Substring(index1, index2 - index1));
                paramsval += val;
                index1 = index2 + 1;
            }
            while (index1 < hashparams.Length);

            //out.println("hashparams="+hashparams+"<br/>");
            //out.println("hashparamsval="+hashparamsval+"<br/>");
            //out.println("paramsval="+paramsval+"<br/>");
            String hashval = paramsval + storekey;         //elde edilecek hash değeri için paramsval e store key ekleniyor. (işyeri anahtarı)
            String hashparam = Request.Form.Get("HASH");

            System.Security.Cryptography.SHA1 sha = new System.Security.Cryptography.SHA1CryptoServiceProvider();
            byte[] hashbytes = System.Text.Encoding.GetEncoding("ISO-8859-9").GetBytes(hashval);
            byte[] inputbytes = sha.ComputeHash(hashbytes);

            String hash = Convert.ToBase64String(inputbytes); //Güvenlik ve kontrol amaçlı oluşturulan hash

            if (!paramsval.Equals(hashparamsval) || !hash.Equals(hashparam)) //oluşturulan hash ile gelen hash ve hash parametreleri değerleri ile ayrıştırılıp edilen edilen aynı olmalı.
            {
                Response.Write("<h4>Güvenlik Uyarısı. Sayısal İmza Geçerli Değil</h4>");
            }
        }
        else
        {
            Response.Write("<h4>Hash değeri hatası. Bilgi işlem ile bağlantı kurunuz. <br><br>Hata ayrıntısı: 'Lütfen 3D sayfasına ilettiğiniz parametreleri kontrol ediniz.'</h4>");
        }



        String mdStatus = Request.Form.Get("mdStatus"); // 3d işlemin sonucu
        

        if (mdStatus.Equals("1") || mdStatus.Equals("2") || mdStatus.Equals("3") || mdStatus.Equals("4"))
        {
        */
    %>
        <%

                    odm.strAuthCode = Request.QueryString["authCode"];
                    odm.strResponse = (Request.QueryString["approved"] == "1" ? "Approved" : "Declined");
                    odm.strHostRefNum = Request.QueryString["hostlogkey"];
                    odm.strProcReturnCode = Request.QueryString["respCode"];
                    odm.strTransId = Request.QueryString["tranDate"];
                    odm.strErrMsg = Request.QueryString["respText"];
                
            odm.DoInsert();
    
        %>
    <%
        if (Request.QueryString["approved"] == "1")
        {
            Session["OdemeYapildi"] = true;
    %>
    <h4>
        <span style="color: Green">Ödeme İşlemi Başarılıyla Tamamlandı</span></h4>
    <%
        }
            else
            {
    %>
    <h4>
        <span style="color: Red">Ödeme İşlemi Başarısız</span></h4>
    <br /><br />Hata: <%=Request.QueryString["respText"] %>
    <%
        }
    %>

    <center>
    
    <% 
        if (Session["OdemeSiparisNo"] != null)
       {
           Response.Write("<span style=\"font-style: italic; font-size: 12px; color: #DD0000\">Sipariş onaylama bir sonraki sayfadadır. Bu sayfayı kapatmak için alttaki &quot;Ödeme Ekranını Kapat&quot; tuşuna basınız, sonraki sayfada adres belirterek siparişi onaylayınız.</span>");
       }

       Session["OdemeSiparisNo"] = null; 
        
        %>
        </center>
</body>
</html>

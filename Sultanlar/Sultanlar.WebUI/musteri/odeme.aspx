<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="odeme.aspx.cs" Inherits="Sultanlar.WebUI.musteri.odeme" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>3D Pay</title>
        <script type="text/javascript">
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;

            return true;
        }
        </script>
</head>
<body style="font-family: Verdana; font-size: 11px">

        <center>
            <form runat="server">
<%
    if (Session["OdemeTutari"] == null || Session["OdemeGMREF"] == null || Session["KrediKart"] == null)
        Response.Redirect("hata.htm", true);

        /**************           GEREKLİ  PARAMETRELER       ********************/
        /*
        String clientId = "400359354";   //Banka tarafından verilen işyeri numarası     
        String oid = Session["OdemeSiparisNo"] != null ? Session["OdemeSiparisNo"].ToString() : "";                 //Sipariş Numarası
        String okUrl = "https://www.sultanlar.com.tr/musteri/odemesayfasi3dpay.aspx";     //İşlem başarılıysa dönülecek sayfa
        String failUrl = "https://www.sultanlar.com.tr/musteri/odemesayfasi3dpay.aspx";   //İşlem başarısızsa dönülecek sayfa
        String rnd = DateTime.Now.ToString();  //Kontrol ve güvenlik amaçlı sürekli değişen bir değer tarih gibi
        
        String taksit = "";      //Taksit sayısı
        String islemtipi = "Auth"; //İşlem tipi
        String storekey = "sultanlaRTeb3d";  //İş yeri anahtarı
        String hashstr = clientId + oid + amount + okUrl + failUrl + islemtipi + taksit + rnd + storekey;
        System.Security.Cryptography.SHA1 sha = new System.Security.Cryptography.SHA1CryptoServiceProvider();
        byte[] hashbytes = System.Text.Encoding.GetEncoding("ISO-8859-9").GetBytes(hashstr);
        byte[] inputbytes = sha.ComputeHash(hashbytes);
        
        String hash = Convert.ToBase64String(inputbytes);  //Güvenlik amaçlı hash değeri
    */
        String amount1 = Convert.ToDecimal(Session["OdemeTutari"]).ToString("N2");

        String Numara = Sultanlar.Class.Sifreleme.Decrypt(((Sultanlar.DatabaseObject.Internet.Kartlar)Session["KrediKart"]).strNumara);
        String Guvenlik = Sultanlar.Class.Sifreleme.Decrypt(((Sultanlar.DatabaseObject.Internet.Kartlar)Session["KrediKart"]).strGuvenlik);
        String Yil = Sultanlar.Class.Sifreleme.Decrypt(((Sultanlar.DatabaseObject.Internet.Kartlar)Session["KrediKart"]).strYil);
        String Ay = Sultanlar.Class.Sifreleme.Decrypt(((Sultanlar.DatabaseObject.Internet.Kartlar)Session["KrediKart"]).strAy);
    
        String Tip = Sultanlar.Class.Sifreleme.Decrypt(((Sultanlar.DatabaseObject.Internet.Kartlar)Session["KrediKart"]).strTip);
        String Visa = string.Empty;
        String MasterCard = string.Empty;
        String VM = string.Empty;
        if (Tip == "1")
        {
            Visa = "selected=\"selected\"";
            VM = "Visa";
        }
        else if (Tip == "2")
        {
            MasterCard = "selected=\"selected\"";
            VM = "MasterCard";
        }
    %>

                <table cellpadding="3" cellspacing="0" 
                    style="text-align: left; width: 350px;">
                    <tr>
                        <td align="right">Ödeme Tutarı:</td>
                        <td><strong><%=amount1%> TL</strong></td>
                    </tr>
                    
                    <tr>
                        <td align="right">&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    
                    <tr style="display: none">
                        <td align="right">Kredi Kart Numarası:</td>
                        <td><input type="text" name="pan" size="20" maxlength="16" value="<%=Numara%>"
                                style="color:#006699;border-color:#A3B5C9;border-width:1px;border-style:Solid;font-size:12px;
                                padding: 3px 3px 3px 3px" onkeypress="return isNumberKey(event)"/> </td>
                    </tr>
                    
                    <tr style="display: none">
                        <td align="right">Güvenlik Kodu:</td>
                        <td><input type="text" name="cv2" size="3" maxlength="3" value="<%=Guvenlik%>"
                        style="color:#006699;border-color:#A3B5C9;border-width:1px;border-style:Solid;font-size:12px;
                                padding: 3px 3px 3px 3px" onkeypress="return isNumberKey(event)"/></td>
                    </tr>
                    
                    <tr style="display: none">
                        <td align="right">Son Kullanma Yılı:</td>
                        <td><input type="text" name="Ecom_Payment_Card_ExpDate_Year" value="<%=Yil%>"
                        size="2" maxlength="2"
                        style="color:#006699;border-color:#A3B5C9;border-width:1px;border-style:Solid;font-size:12px;
                                padding: 3px 3px 3px 3px" onkeypress="return isNumberKey(event)"/> 
                            (örnek 2012 için: 12)</td>
                    </tr>
                    
                    <tr style="display: none">
                        <td align="right">Son Kullanma Ayı:</td>
                        <td><input type="text" name="Ecom_Payment_Card_ExpDate_Month" value="<%=Ay%>"
                        size="2" maxlength="2"
                        style="color:#006699;border-color:#A3B5C9;border-width:1px;border-style:Solid;font-size:12px;
                                padding: 3px 3px 3px 3px" onkeypress="return isNumberKey(event)"/> 
                            (örnek 6. ay için: 06)</td>
                    </tr>
                    
                    <tr style="display: none">
                        <td align="right">Visa/MC Seçimi:</td>
                        <td><select name="cardType" style="padding: 3px 3px 3px 3px;color:#006699;font-size:12px;
                                font-weight:normal;font-style:normal;text-decoration:none;">
                            <option value="1" <%=Visa%>>Visa</option>
                            <option value="2" <%=MasterCard%>>MasterCard</option>
                        </select>
                        </td>
                    </tr>

                    <tr>
                        <td align="right">Kredi Kart Numarası:</td>
                        <td><%=Numara.ToString()%></td>
                    </tr>
                    
                    <tr>
                        <td align="right">Güvenlik Kodu:</td>
                        <td><%=Guvenlik%></td>
                    </tr>
                    
                    <tr>
                        <td align="right">Son Kullanma Ayı:</td>
                        <td><%=Ay%></td>
                    </tr>
                    
                    <tr>
                        <td align="right">Son Kullanma Yılı:</td>
                        <td><%=Yil%></td>
                    </tr>
                    
                    <tr style="display: none">
                        <td align="right">Visa/MC Seçimi:</td>
                        <td><%=VM%></td>
                    </tr>
                    
                    <tr>
                        <td align="center" colspan="2" style="font-size: 14px">
                            <br /><br />
                            <asp:LinkButton runat="server" ID="lbTamamla" OnClick="lbTamamla_Click"
                                style="color:#284775; background-color:#FFFBFF; width:160px; border-color:#CCCCCC;border-width:1px;border-style:Solid;font-family:Verdana;font-size:14px;font-weight:bold" 
                                OnClientClick="this.style.display = 'none'">Ödemeyi Tamamla</asp:LinkButton>
                            
                        </td>
                    </tr>
                    
                </table>

                <%--<input type="hidden" name="clientid" value="<%=clientId%>">
                <input type="hidden" name="amount" value="<%=amount%>">
                <input type="hidden" name="oid" value="<%=oid%>">	
                <input type="hidden" name="okUrl" value="<%=okUrl%>">
                <input type="hidden" name="failUrl" value="<%=failUrl%>">
                <input type="hidden" name="rnd" value="<%=rnd%>" >
                <input type="hidden" name="hash" value="<%=hash%>" >
                <input type="hidden" name="islemtipi" value="<%=islemtipi %>" />
                <input type="hidden" name="taksit" value="<%=taksit %>" />
                <input type="hidden" name="storetype" value="3d_pay" >	
                
                <input type="hidden" name="lang" value="tr">
				<input type="hidden" name="currency" value="949">
                <input type="hidden" name="firmaadi" value="Sultanlar Pazarlama A.S.">
                
                <input type="hidden" name="Fismi" value="is">
                <input type="hidden" name="faturaFirma" value="faturaFirma">
                <input type="hidden" name="Fadres" value="XXX">
                <input type="hidden" name="Fadres2" value="XXX">
                <input type="hidden" name="Fil" value="XXX">
                <input type="hidden" name="Filce" value="XXX">
                <input type="hidden" name="Fpostakodu" value="postakod34000">
                
                <input type="hidden" name="tel" value="XXX">
                <input type="hidden" name="fulkekod" value="tr">
                
                <input type="hidden" name="nakliyeFirma" value="nakliyeFirma">
                <input type="hidden" name="tismi" value="XXX">
                <input type="hidden" name="tadres" value="XXX">
                <input type="hidden" name="tadres2" value="XXX">
                <input type="hidden" name="til" value="XXX">
                <input type="hidden" name="tilce" value="XXX">
                
                <input type="hidden" name="tpostakodu" value="ttt postakod34000">
                <input type="hidden" name="tulkekod" value="tr">
                
                <input type="hidden" name="itemnumber1" value="a1">
                <input type="hidden" name="productcode1" value="a2">
                <input type="hidden" name="qty1" value="3">
                <input type="hidden" name="desc1" value="a4 desc">
                <input type="hidden" name="id1" value="a5">
                <input type="hidden" name="price1" value="0.00">
                <input type="hidden" name="total1" value="0.00">--%>
                
            </form>

            <%--<b>Kullanılan Hidden Parametreler</b>
            <br>
            &lt;input type="hidden" name="clientid" value=""&gt;<br>
            &lt;input type="hidden" name="amount" value=""&gt;<br>
            &lt;input type="hidden" name="oid" value=""&gt;	<br>
            &lt;input type="hidden" name="okUrl" value=""&gt;<br>
            &lt;input type="hidden" name="failUrl" value=""&gt;<br>
            &lt;input type="hidden" name="rnd" value="" &gt;<br>
            &lt;input type="hidden" name="hash" value="" &gt;<br>
            
            &lt;input type="hidden" name="storetype" value="3d_pay" &gt;<br>	
            
            &lt;input type="hidden" name="lang" value=""&gt;<br>
            &lt;input type="hidden" name="firmaadi" value=""&gt;<br>
            
            &lt;input type="hidden" name="Fismi" value=""&gt;<br>
            &lt;input type="hidden" name="faturaFirma" value=""&gt;<br>
            &lt;input type="hidden" name="Fadres" value=""&gt;<br>
            &lt;input type="hidden" name="Fadres2" value=""&gt;<br>
            &lt;input type="hidden" name="Fil" value=""&gt;<br>
            &lt;input type="hidden" name="Filce" value=""&gt;<br>
            &lt;input type="hidden" name="Fpostakodu" value=""&gt;<br>
            
            &lt;input type="hidden" name="tel" value=""&gt;<br>
            &lt;input type="hidden" name="fulkekod" value=""&gt;<br>
            
            &lt;input type="hidden" name="nakliyeFirma" value=""&gt;<br>
            &lt;input type="hidden" name="tismi" value=""&gt;<br>
            &lt;input type="hidden" name="tadres" value=""&gt;<br>
            &lt;input type="hidden" name="tadres2" value=""&gt;<br>
            &lt;input type="hidden" name="til" value=""&gt;<br>
            &lt;input type="hidden" name="tilce" value=""&gt;<br>
            
            &lt;input type="hidden" name="tpostakodu" value=""&gt;<br>
            &lt;input type="hidden" name="tulkekod" value=""&gt;<br>
            
            &lt;input type="hidden" name="itemnumber1" value=""&gt;<br>
            &lt;input type="hidden" name="productcode1" value=""&gt;<br>
            &lt;input type="hidden" name="qty1" value=""&gt;<br>
            &lt;input type="hidden" name="desc1" value=""&gt;<br>
            &lt;input type="hidden" name="id1" value=""&gt;<br>
            &lt;input type="hidden" name="price1" value=""&gt;<br>
            &lt;input type="hidden" name="total1" value=""&gt;<br>--%>
        </center>
    </body>
</html>

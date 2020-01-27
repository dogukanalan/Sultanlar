<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="yetkiyok.aspx.cs" Inherits="Sultanlar.WebUI.musteri.yetkiyok" %>

<%@ Register src="ucAlt.ascx" tagname="ucAlt" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta http-equiv="REFRESH" content="3;url=default.aspx" />
    <title>Sultanlar : Yetki Yok</title>
    <link rel="stylesheet" type="text/css" href="StyleSheet.css" />
    <script type="text/javascript" src="js/jquery-1.2.6.pack.js"></script>
    <script type="text/javascript" src="js/jquery-1.8.3.js"></script>
    <script type="text/javascript" src="js/jquery-ui.js"></script>
    <link rel="stylesheet" href="js/jquery-ui.css" />
    <script type="text/javascript" src="js/scripts.js"></script>
    <script type="text/javascript">
        function baslangic() {
            $("input[type=submit], input[type=button]").button();
        }
    </script>
</head>
<body style="margin: 0 0 0 0;background-color: #EFEEEA;" onload="baslangic()">
    <form id="form1" runat="server">

<div style="padding-top: 300px; filter: alpha(opacity=40); -moz-opacity: .40; opacity: .40;
    background-color: #000000; position: fixed; width: 100%; height: 100%; z-index: 9;
    left: 0; top: 0;">
</div>
<div style="padding-top: 75px; position: fixed; width: 100%; height: 100%; z-index: 10;
    left: 0; top: 0;">
    <table style="width: 400px; height: 300px; margin-left: 300px; background-color: #ffffff; border: 1px solid #D1D1D1; border-radius: 5px; padding: 5px;">
        <tr>
            <td style="text-align: center; border-bottom: 1px dotted #CCCCCC; height: 50px; font-size: 18px; font-family: Gisha">
                Sayfa görüntülenemiyor
            </td>
        </tr>
        <tr>
            <td style="text-align: center; height: 100%">
                <img alt="" src="img/hata.png" />
                <br />
                <br />
                <span style="font-family: Tahoma; font-size: 16px; color: #C5670B">Erişmeye çalıştığınız sayfaya yetkiniz yok.<br />Ana sayfaya yönlendiriliyorsunuz.</span><br />
                <br />
            </td>
        </tr>
    </table>
</div>

    <div style="width: 100%; font-size: 9px; font-family: Verdana; background-color: #EFEEEA; border-bottom: 1px solid #FFCFB2"">
    <table cellpadding="5" cellspacing="0">
    <tr>
    <td style="width: 800px;" valign="middle">
        <table cellpadding="0" cellspacing="0"><tr><td>
        <input type="button" value="Giriş" onclick="javascript:window.location.href='default.aspx'" /> 
        <input type="button" value="Aktiviteler" onclick="javascript:window.location.href='aktiviteler.aspx'" /> 
        <input type="button" value="Hizmet Bedelleri" onclick="javascript:window.location.href='hizmetbedelleri.aspx'" /> 
        <input type="button" value="Anlaşmalar" onclick="javascript:window.location.href='anlasmalar.aspx'" /> 
        <input type="button" value="Siparişler" onclick="javascript:window.location.href='siparisler.aspx'" /> 
        <input type="button" value="İadeler" onclick="javascript:window.location.href='iadeler.aspx'" /> 
        <input type="button" value="Tahsilatlar" onclick="javascript:window.location.href='odemeler.aspx'" /> 
        <input type="button" value="Raporlar" onclick="javascript:window.location.href='hesapayrinti.aspx'" /> 
        <input type="button" value="Üye İşlemleri" onclick="javascript:window.location.href='uyelik.aspx'" /> 
        <input type="button" value='Mesajlar (<%= Sultanlar.DatabaseObject.Internet.GonderilenMesajlar.GetObjectCount(((Sultanlar.DatabaseObject.Internet.Musteriler)Session["Musteri"]).pkMusteriID).ToString() %>)' onclick="javascript:window.location.href='mesajlar.aspx'" /></td><td align="left"></td></tr></table>
    </td>
    <td style="width: 200px; font-family: Gisha; font-size: 12px" align="right">
        <table cellpadding="0" cellspacing="0"><tr><td><asp:Label ID="Label1" runat="server"></asp:Label>&nbsp;&nbsp;&nbsp;</td><td><asp:ImageButton runat="server" ID="ImageButton1" OnClick="ImageButton1_Click" ImageUrl="img/ic_logout.png" /></td></tr></table>
    </td>
    </tr>
    </table>
    </div>
    <div style="width: 100%; height: 400px; background-color: #FFFFFF">
    </div>
    <uc1:ucAlt ID="ucAlt1" runat="server" />
    </form>
</body>
</html>

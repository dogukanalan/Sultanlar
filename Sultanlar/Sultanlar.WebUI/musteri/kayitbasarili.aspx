<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="kayitbasarili.aspx.cs" Inherits="Sultanlar.WebUI.musteri.kayitbasarili" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Sultanlar : Kayıt</title>
</head>
<body style="margin: 0 0 0 0;background-color: #EFEEEA;">
    <form id="form1" runat="server" action="kayitbasarili.html">
    <div style="background-position: center center; padding: 10px 10px 10px 10px; background-image: url('img/bg-logo.jpg'); 
        background-repeat: no-repeat; background-color: #FFFFFF">
        <table style="width: 100%"><tr><td align="center">
    <table cellpadding="10" cellspacing="0" 
            style="border: 1px solid #CCCCCC; font-family: Verdana; font-size: 12px; width: 500px; text-align: left; 
            margin-top: 30px; margin-bottom: 30px; height: 300px; border-radius: 5px" 
            border="0"><tr><td valign="top" 
                
                style="padding-top: 50px; padding-left: 20px; background-image: url('img/bg-giris-div.png'); background-repeat: repeat; color: #4C4C4C;">
            Kaydınız alınmıştır. Onaylandıktan sonra 
            eposta adresiniz ve şifreniz ile sisteme 
            giriş yapabilirsiniz.
            <br />
            <br />
            Ana sayfaya dönmek için <a href="giris.html">tıklayınız.</a></td></tr></table></td></tr></table><br /></div>

        <div style="background-color: #EFEEEA; height: 100px; padding: 10px; border-top: 1px solid #FFCFB2">
            <img src="img/logo.png" alt="" style="padding: 0 20px 0 10px; cursor: pointer" onclick="window.location.href='http://www.sultanlar.com.tr'" />
            <img src="img/ssl.gif" alt="" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <img src="img/logoSAP.png" alt="" style="padding-bottom: 7px" />
            <div style="margin-top: 5px; width: 100%; text-align: center; font-family: Tahoma;
                font-size: 12px; color: #808080">
                Copyright © 2011-2018 Sultanlar Pazarlama A.Ş. Tüm hakları saklıdır.
                <br />
                Sitede yer alan resim, yazı ve içerikler kaynak gösterilerek dahi olsa kopyalanamaz.
            </div>
        </div>
    </form>
</body>
</html>

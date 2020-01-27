<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="giris.aspx.cs" Inherits="Sultanlar.WCF.giris" %>

<%@ Register src="ucProgress.ascx" tagname="ucProgress" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="cache-control" content="no-cache" />
    <title></title>
    <link rel="Stylesheet" type="text/css" href="StyleSheet.css" />
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script type="text/javascript" src="JScript.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="login-page">
            <div class="form">
                <a class="button" href="matruska.aspx" onclick="Goster()">İlk Yüz Müşteri</a>
                <a class="button" href="hedefanadolu.aspx?bolge=anadolu" onclick="Goster()">Hedef - Satış Anadolu</a>
                <a class="button" href="hedefanadolu.aspx?bolge=avrupa" onclick="Goster()">Hedef - Satış Avrupa</a>
                <a class="button" href="hedefanadolu.aspx?bolge=bati" onclick="Goster()">Hedef - Satış Batı</a>
                <a class="button" href="hedefanadolu.aspx?bolge=guneydogu" onclick="Goster()">Hedef - Satış Güneydoğu</a>
                <a class="button" href="hedefanadolu.aspx?bolge=dogu" onclick="Goster()">Hedef - Satış Doğu</a>
                <a class="button" href="hedefanadolu.aspx?bolge=ulusal" onclick="Goster()">Hedef - Satış Ulusal</a>
                <%--<a class="button" href="cikis.aspx" onclick="Goster()">Çıkış</a>
                <a class="button" href="rutbugun.aspx" onclick="Goster()">Bugünkü Rut</a>
                <a class="button" href="rutlar.aspx" onclick="Goster()">Bütün Rutlar</a>
                <a class="button" href="musteriler.aspx" onclick="Goster()">Müşteriler</a>
                <a class="button" href="konumlar.aspx" onclick="Goster()">Konumlar</a>
                <a class="button" href="ziyaretler.aspx" onclick="Goster()">Ziyaret Geçmişi</a>--%>
            </div>
        </div>
        <uc1:ucProgress ID="ucProgress1" runat="server" />
    </form>
</body>
</html>

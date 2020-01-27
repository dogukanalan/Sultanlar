<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="menu.aspx.cs" Inherits="Sultanlar.WebUI.merch.menu" %>

<%@ Register src="ucProgress.ascx" tagname="ucProgress" tagprefix="uc1" %>
<%@ Register src="ucUst.ascx" tagname="ucUst" tagprefix="uc2" %>
<%@ Register src="ucAlt.ascx" tagname="ucAlt" tagprefix="uc3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="cache-control" content="no-cache" />
    <meta name="viewport" content="width=device-width,initial-scale=1">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="StyleSheet.css" />
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script type="text/javascript" src="JScript.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="login-page">
            <div class="form">
                <uc2:ucUst ID="ucUst" runat="server" />
                <a class="button" href="rutbugun.aspx" onclick="Goster()">Bugünkü Rut</a>
                <a class="button" href="rutlar.aspx" onclick="Goster()">Bütün Rutlar</a>
                <a class="button" href="musteriler.aspx" onclick="Goster()" runat="server" id="aMusteri">Müşteriler</a>
                <a class="button" href="konumlar.aspx" onclick="Goster()">Konumlar</a>
                <a class="button" href="ziyaretler.aspx" onclick="Goster()">Ziyaret Geçmişi</a>
                <a class="button" href="kutuphane.aspx" onclick="Goster()">Kütüphane</a>
                
                <uc3:ucAlt ID="ucAlt1" runat="server" />
            </div>
        </div>
        <uc1:ucProgress ID="ucProgress1" runat="server" />
    </form>
</body>
</html>

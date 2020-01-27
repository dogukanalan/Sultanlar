<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="konumal.aspx.cs" Inherits="Sultanlar.WebUI.merch.konumal" %>

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
    <script type="text/javascript" src="coord.js"></script>
    <script type="text/javascript">
        function KonumGonder() {
            $.ajax({
                type: 'POST',
                url: 'konumal.aspx/KonumSet',
                data: '{ smref: "' + $('#txtSMREF').val() + '", tip: "' + $('#txtTip').val() + '", Coords: "' + $('#txtCoords').val() + '", Coords1: "' + $('#txtCoords1').val() + '" }',
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                success: function (msg) {
                    alert("Konum alındı.");
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    alert(textStatus + "\n" + errorThrown + "\n" + XMLHttpRequest.responseText);
                }
            });
        }
    </script>
</head>
<body onload="KoordinatBaslat()">
    <form id="form1" runat="server">
        <div class="login-page">
            <div class="form">
                <uc2:ucUst ID="ucUst" runat="server" />
                <asp:TextBox runat="server" ID="txtSMREF" style="display: none"></asp:TextBox>
                <asp:TextBox runat="server" ID="txtTip" style="display: none"></asp:TextBox>
                - Nokta -
                <asp:TextBox runat="server" ID="txtMusteri" Enabled="false"></asp:TextBox>
                - Adres -
                <asp:TextBox runat="server" ID="txtCoords" Enabled="false"></asp:TextBox>
                <asp:TextBox runat="server" ID="txtCoords1" style="display: none"></asp:TextBox>
                <div id="iframeMap"></div><br />
                <%--<asp:Button runat="server" Text="Konumu Kaydet" ID="btnKonumKaydet" OnClick="btnKonumKaydet_Click" />--%>
                <%--<input type="button" id="btnKonumGonder" value="Konumu Kaydet" />--%>
                <a class="button" href="javascript:KonumGonder()">Konumu Kaydet</a>
                <br /><br />
                <asp:Button runat="server" Text="Adres arayarak konum girmek için tıklayınız." ID="btnKonum2" OnClick="btnKonum2_Click" />
                <script type="text/javascript" src="https://maps.googleapis.com/maps/api/js?key=AIzaSyDXm_Z4J-I9jrTO72lGvx1jRzTWsP6qi7Q&libraries=geometry"></script>
                <script type="text/javascript">
                    $("#btnKonumGonder").click(function () {
                        
                    });
                </script>
                <uc3:ucAlt ID="ucAlt1" runat="server" />
            </div>
        </div>
        <uc1:ucProgress ID="ucProgress1" runat="server" />
    </form>
</body>
</html>

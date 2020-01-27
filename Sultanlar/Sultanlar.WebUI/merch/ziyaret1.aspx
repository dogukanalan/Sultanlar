<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ziyaret1.aspx.cs" Inherits="Sultanlar.WebUI.merch.ziyaret1" %>

<%@ Register Src="ucProgress.ascx" TagName="ucProgress" TagPrefix="uc1" %>
<%@ Register Src="ucUst.ascx" TagName="ucUst" TagPrefix="uc2" %>
<%@ Register Src="ucAlt.ascx" TagName="ucAlt" TagPrefix="uc3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="cache-control" content="no-cache" />
    <meta name="viewport" content="width=device-width,initial-scale=1">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="StyleSheet.css" />
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script type="text/javascript" src="JScript.js"></script>
    <script type="text/javascript" src="coord.js"></script>
    <script type="text/javascript" src="../musteri/js/jquery.tipTip.js"></script>
    <link rel="stylesheet" type="text/css" href="../musteri/js/tipTip.css" />
</head>
<body onload="KoordinatBaslat()">
    <form id="form1" runat="server">
        <div class="login-page">
            <div class="form">
                <uc2:ucUst ID="ucUst" runat="server" />
                <br /><br />Ziyaret Başlatılacak Şube
                <asp:TextBox runat="server" ID="txtSube" Text="" Enabled="false"></asp:TextBox>
                <div runat="server" id="divKonumHata" style="border: 1px solid #D1D1D1; border-radius: 5px; padding: 25px;" visible="false">
                <span style="color: #ff0000; font-style: italic">Müşterinin konum bilgisi sistemde bulunmuyor. Konum bilgisi almak için aşağıdaki "Konum Al" bağlantısını kullanabilirsiniz.</span><br /><br />
                <a id="aKonum" class="button" href='#' runat="server" visible="false">Konum Al</a>
                </div>
                <asp:TextBox runat="server" ID="txtCoords1" Text="0,0" Style="display: none"></asp:TextBox>
                <br /><br />Konumunuz
                <asp:TextBox runat="server" ID="txtCoords" Text="Konum bekleniyor..." onkeypress="return yazma(event)"></asp:TextBox>
                <br /><br />
                <span id="spanBekleniyor" class="button">Konumunuz bulunmadan ziyaret başlatamazsınız.</span>
                <asp:LinkButton class="button" ID="lbFarkliZiyaretBaslat" runat="server" OnClick="lbFarkliZiyaretBaslat_Click" style="display: none">Ziyareti Başlat</asp:LinkButton>
                <script type="text/javascript" src="https://maps.googleapis.com/maps/api/js?key=AIzaSyDXm_Z4J-I9jrTO72lGvx1jRzTWsP6qi7Q&libraries=geometry"></script>
                <uc3:ucAlt ID="ucAlt1" runat="server" />
                <uc1:ucProgress ID="ucProgress1" runat="server" />
            </div>
        </div>
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="siparisicerik.aspx.cs" Inherits="Sultanlar.WebUI.merch.siparisicerik" %>

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
    <script>
        
        function VeriGetir() {
            AndroidProgress(true);
            $.ajax(
                {
                    type: 'POST',
                    url: 'siparisicerik.aspx/SiparislerGetir',
                    data: '{ siparisid: "' + $('#siparisid').val() + '" }',
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'json',
                    success: function (data) {
                        var htmlText = '<table style="width: 100%; font-size: 12px" cellpadding="2px">';
                        for (var key1 in data) {
                            for (var key in data[key1]) {
                                htmlText += '<tr>';
                                htmlText += '<td style="width: 60%; height: 40px; text-align: left">' + data[key1][key].strUrunAdi + '</td><td style="width: 20%">' + data[key1][key].intMiktar + '</td><td style="width: 20%; text-align: right">' + parseFloat(data[key1][key].mnFiyat).toFixed(2) + '</td>';
                                htmlText += '</tr>';
                            }
                        }
                        htmlText += "</table>";

                        divData.innerHTML = htmlText;

                        AndroidProgress(false);
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        alert(XMLHttpRequest.responseText);
                    }
                }
            );
        }

        $(document).ready(function () {
            VeriGetir();
        });

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="login-page">
            <div class="form">
                <uc2:ucUst ID="ucUst" runat="server" />
                
                <table cellpadding="2px" style="width: 100%"><tr style="color: #a80000">
                <td style="width: 60%">Ürün</td><td style="width: 20%">Miktar</td><td style="width: 20%">Tutar</td>
                </tr></table>
                <div id="divData"></div>
                <span id="spanYukleniyor" style="font-style: italic; display: none"><br />Yükleniyor...</span>
                <input type="hidden" runat="server" id="siparisid" value="" clientidmode="Static" />
                <uc3:ucAlt ID="ucAlt1" runat="server" />
                <uc1:ucProgress ID="ucProgress1" runat="server" />
            </div>
        </div>
    </form>
</body>
</html>

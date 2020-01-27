<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="anketler.aspx.cs" Inherits="Sultanlar.WebUI.merch.anketler" %>

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
    <link rel="stylesheet" href="https://code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script type="text/javascript" src="https://code.jquery.com/ui/1.12.1/jquery-ui.min.js"></script>
    <script type="text/javascript" src="JScript.js"></script>
    <script type="text/javascript" src="../musteri/js/jquery.tipTip.js"></script>
    <link rel="stylesheet" type="text/css" href="../musteri/js/tipTip.css" />
    <script>

        function Getir() {
            $.ajax(
                {
                    type: 'POST',
                    url: 'anketler.aspx/AnketlerGetir',
                    data: '{ uye: "' + $('#uyeid').val() + '" }',
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'json',
                    success: function (data) {
                        //alert(JSON.stringify(data.d[0].Soru));
                        var htmlText = '';
                        for (var key1 in data) {
                            for (var key in data[key1]) {
                                htmlText += '<div style="border: 1px solid #C0C0C0; padding: 5px; margin: 5px; border-radius: 5px"><br /><span runat="server" id="spanSoru">' + data[key1][key].Soru + '</span><br />';
                                htmlText += '<span runat="server" id="spanZaman" style="color: #808080">(' + data[key1][key].Zaman + ')</span><br /><br />';

                                var cevaplanmisID = 0;
                                for (var cevap in data[key1][key].cevaplar) {
                                    if (data[key1][key].cevaplar[cevap].intMusteriID == $("#uyeid").val()) {
                                        cevaplanmisID = data[key1][key].cevaplar[cevap].intSecimID;
                                    }
                                }

                                for (var secim in data[key1][key].secimler) {
                                    if (cevaplanmisID != 0 && data[key1][key].secimler[secim].pkID == cevaplanmisID)
                                        htmlText += '<span class="spanAnketSec">' + data[key1][key].secimler[secim].strSecim + '</span>';
                                    else
                                        htmlText += '<span class="spanAnketBos">' + data[key1][key].secimler[secim].strSecim + '</span>';
                                }
                                htmlText += '</div><br />';
                            }
                        }
                        divData.innerHTML = htmlText;
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        alert(XMLHttpRequest.responseText);
                    }
                });
        }

        $(function () {
            Getir();
        });

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="login-page">
            <div class="form">
                <uc2:ucUst ID="ucUst" runat="server" />

                <div id="divData"></div>

                <input type="hidden" runat="server" id="uyeid" />
                <uc3:ucAlt ID="ucAlt1" runat="server" />
                <uc1:ucProgress ID="ucProgress1" runat="server" />
            </div>
        </div>
    </form>
</body>
</html>

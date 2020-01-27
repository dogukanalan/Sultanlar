<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="siparisler.aspx.cs" Inherits="Sultanlar.WebUI.merch.siparisler" %>

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
        
        function VeriGetir(ilk) {
            AndroidProgress(true);

            var veriyok = true;
            
            var sonid = parseInt($('#sonId').val());
            if (ilk) {
                sonid = 0;
                $('#sonId').val('0');
            }

            $.ajax(
                {
                    type: 'POST',
                    url: 'siparisler.aspx/SiparislerGetir',
                    data: '{ sonid: "' + $('#sonId').val() + '", musteriid: "' + $('#musteriid').val() + '" }',
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'json',
                    success: function (data) {
                        var htmlText = '<table style="width: 100%; font-size: 12px" cellpadding="5px">';
                        for (var key1 in data) {
                            for (var key in data[key1]) {
                                sonid++;
                                
                                htmlText += '<tr ' + (data[key1][key].blAktarilmis ? 'style="color: #000526"' : '') + ' onclick="window.location.href = \'siparisicerik.aspx?siparisid=' + data[key1][key].pkSiparisID + '\'">';
                                htmlText += '<td style="width: 50%; height: 40px; text-align: left">' + data[key1][key].CariHesap.SUBE + '</td><td style="width: 10%">' + data[key1][key].sintFiyatTipiID + '</td><td style="width: 20%">' + data[key1][key].strAciklama + '</td><td style="width: 20%; text-align: right">' + parseFloat(data[key1][key].mnToplamTutar).toFixed(2) + '</td>';
                                htmlText += '</tr>';

                                veriyok = false;
                            }
                        }
                        htmlText += "</table>";

                        $('#sonId').val(sonid);
                        
                        if (!ilk)
                            divData.innerHTML += htmlText;
                        else
                            divData.innerHTML = htmlText;

                        //$(".kucukbilgiGoster").tipTip({ activation: "hover" });

                        AndroidProgress(false);
            
                        if (veriyok)
                            $('#spanVeriYok').css("display", "");
                        else
                            $('#spanVeriYok').css("display", "none");

                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        alert(XMLHttpRequest.responseText);
                    }
                }
            );
        }

        $(document).ready(function () {
            VeriGetir(true);
        });

        $(window).scroll(function () {
            if ($(window).scrollTop() == $(document).height() - $(window).height()) {
                VeriGetir(false);
            }
        });

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="login-page">
            <div class="form">
                <uc2:ucUst ID="ucUst" runat="server" />

                <table cellpadding="2px" style="width: 100%"><tr style="color: #a80000">
                <td style="width: 50%">Cari Hesap</td><td style="width: 10%;">F.Tip</td><td style="width: 20%">Tarih</td><td style="width: 20%">Tutar</td>
                </tr></table>
                <div id="divData"></div>
                <span id="spanYukleniyor" style="font-style: italic;"><br />Yükleniyor...</span>
                <span id="spanVeriYok" style="font-style: italic; display: none"><br />- Bulunamadı -</span>
                
                <input type="hidden" id="sonId" value="0" />
                <input type="hidden" runat="server" id="musteriid" value="" clientidmode="Static" />
                <uc3:ucAlt ID="ucAlt1" runat="server" />
                <uc1:ucProgress ID="ucProgress1" runat="server" />
            </div>
        </div>
    </form>
</body>
</html>

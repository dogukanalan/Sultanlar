<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="siparisgoster.aspx.cs" Inherits="Sultanlar.WebUI.merch.siparisgoster" %>

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

        function Guncelle() {
            var siparis = JSON.parse(readCookie("siparisliste"));
            for (var i in siparis) {
                for (var j in siparis[i]) {
                    if (siparis[i][j].ad) {
                        siparis[i][j].adet = $('#in' + siparis[i][j].itemref).val();
                    }
                }
            }
            eraseCookie("siparisliste");
            createCookie("siparisliste", JSON.stringify(siparis), 1);
            Getir();
            
            AndroidToast('Güncellendi.');
        }

        function Tamamla() {
            var siparis = JSON.parse(readCookie("siparisliste"));
            var jsonData = JSON.stringify(siparis);
            alert(jsonData);
            $.ajax(
                {
                    type: 'POST',
                    url: 'siparisgoster.aspx/SiparisEkle',
                    data: jsonData,
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'json',
                    success: function (data) {
                        if (data.d == "") {
                            alert('Sipariş onaylandı.');
                            eraseCookie('siparisliste');
                            history.back();
                        }
                        else {
                            alert(data.d);
                        }
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        alert(XMLHttpRequest.responseText);
                    }
                });
        }

        $(document).ready(function () {
            Getir();
        });

        function Getir() {
            var siparis = JSON.parse(readCookie("siparisliste"));
            var htmlText = '<div>';
            for (var i in siparis) {
                for (var j in siparis[i]) {
                    if (siparis[i][j].ad) {
                        $('#sipTamamla').css("visibility", "visible");
                        htmlText += '<div style="display: block; width: 100%; height: 50px;"><div style="float: left; width: 55%; text-align: left; font-size: 12px;"><p>' + siparis[i][j].ad + '</p></div>';
                        htmlText += '<div style="float: left; width: 15%"><input type="text" value="' + siparis[i][j].adet + '" id="in' + siparis[i][j].itemref + '" /></div>';
                        htmlText += '<div style="float: left; width: 15%; font-size: 12px;"><p>' + siparis[i][j].fiyat + '</p></div>';
                        htmlText += '<div style="float: right; font-size: 12px; width: 15%;"><a class="button1" href="javascript:UrunSil(' + siparis[i][j].itemref + ')">Sil</a></div></div>';
                    }
                }
            }
            htmlText += '</div>';
            divData.innerHTML = htmlText;
        }

        function UrunSil(itemref) {
            var siparis = JSON.parse(readCookie("siparisliste"));
            
            for (var i = 0; i < siparis.siparisliste.length; i++) {
                if (siparis.siparisliste[i].itemref == itemref) {
                    siparis.siparisliste.splice(i, 1);
                }
            }

            eraseCookie("siparisliste");
            createCookie("siparisliste", JSON.stringify(siparis), 1);
            
            AndroidToast('Silindi.');
            Getir();
        }

        function GeriDon() {
            parent.SiparisiGizle();
        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="login-page">
            <div class="form">
                <uc2:ucUst ID="ucUst" runat="server" />
                <br />
                <br />
                <a class="button1" href="javascript:GeriDon()">Seçime Dön</a>
                <a class="button1" href="javascript:Guncelle()">Siparişi Güncelle</a>
                <br /><br /><br />
                <a class="button1" id="sipTamamla" href="javascript:Tamamla()" style="visibility: hidden">Siparişi Tamamla</a>
                <br />
                <br />
                <br />
                <div id="divData"></div>
                <input type="hidden" runat="server" id="smref" />
                <input type="hidden" runat="server" id="fiyattip" />
                <uc3:ucAlt ID="ucAlt1" runat="server" />
                <uc1:ucProgress ID="ucProgress1" runat="server" />
            </div>
        </div>
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="anket.aspx.cs" Inherits="Sultanlar.WebUI.merch.anket" %>

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

        function Gonder() {
            if ($('#rblCevaplar input:checked').val() == null) {
                alert('Seçim yapmadınız.');
                return;
            }
            $("#aGonder").css("display", "none");
            $.ajax(
                {
                    type: 'POST',
                    url: 'anket.aspx/CevapEkle',
                    data: '{ anket: "' + $('#anketid').val() + '", secim: "' + $('#rblCevaplar input:checked').val() + '", uye: "' + $('#uyeid').val() + '" }',
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'json',
                    success: function (data) {
                        alert('Cevabınız kaydedildi. Teşekkürler.');
                        window.history.back();
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        alert(XMLHttpRequest.responseText);
                    }
                });
        }

        $(function () {
            $('#rblCevaplar input[type="radio"]').checkboxradio({
                icon: false
            });
            $('#rblCevaplar').children().css("display", "block");
            $('#rblCevaplar').children().css("width", "100%");
            $('#rblCevaplar').children().children().css("display", "block");
            $('#rblCevaplar').children().children().css("width", "100%");
            $('#rblCevaplar').children().children().children().css("display", "block");
            $('#rblCevaplar').children().children().children().css("width", "100%");
        });

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="login-page">
            <div class="form">
                <uc2:ucUst ID="ucUst" runat="server" />
                <div style="border: 1px solid #C0C0C0; padding: 5px; margin: 5px; border-radius: 5px">
                    <br />
                    <span runat="server" id="spanSoru">Soru</span>
                    <br />
                    (<span runat="server" id="spanZaman" style="color: #808080">Zaman</span>)
                    <br />
                    <br />
                    <asp:RadioButtonList runat="server" ID="rblCevaplar" Style="display: block; width: 100%"></asp:RadioButtonList>
                    <br />
                    <a href="javascript:Gonder()" class="button" id="aGonder" runat="server">Gönder</a>
                </div>
                <br />
                <br />
                <a href="anketler.aspx" class="button1" runat="server">Geçmiş Formlar</a><br />
                <input type="hidden" runat="server" id="uyeid" />
                <input type="hidden" runat="server" id="anketid" />
                <uc3:ucAlt ID="ucAlt1" runat="server" />
                <uc1:ucProgress ID="ucProgress1" runat="server" />
            </div>
        </div>
    </form>
</body>
</html>

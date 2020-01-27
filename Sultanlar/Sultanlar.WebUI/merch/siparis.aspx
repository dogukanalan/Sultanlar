<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="siparis.aspx.cs" Inherits="Sultanlar.WebUI.merch.siparis" %>

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
        var veriyok = false;

        function VeriGetir(ilk) {

            if (!ilk && veriyok)
                return;

            veriyok = true;

            if (ilk) {
                sonid = 0;
                $('#sonId').val('0');
            }

            var urunarama = "";
            if (getParameterByName("urunarama")) {
                urunarama = getParameterByName("urunarama");
                $('#urunarama').val(getParameterByName("urunarama"));
            }
            else {
                urunarama = $('#urunarama').val();
            }

            $.ajax(
                {
                    type: 'POST',
                    url: 'siparis.aspx/UrunlerGetir',
                    data: '{ sonid: "' + $('#sonId').val() + '", fiyattip: ' + $('#fiyattip').val() + ', arama: "' + urunarama + '" }',
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'json',
                    success: function (data) {
                        var htmlText = '<div>';

                        for (var key1 in data) {
                            for (var key in data[key1]) {
                                sonid++;

                                htmlText += '<div style="display: block; width: 100%; height: 50px"><div style="float: left; width: 60%; text-align: left; font-size: 12px;"><span>' + data[key1][key].Ad + '</span></div>';
                                htmlText += '<div style="float: left; font-size: 12px; width: 20%;"><span>' + data[key1][key].Fiyat + '</span></div>';
                                htmlText += '<div style="float: right; font-size: 12px; width: 20%;"><a class="button1" href="javascript:Konus2(' + data[key1][key].ID + ',\'' + data[key1][key].Ad.split("'").join(" ") + '\',\'' + data[key1][key].Fiyat + '\',1)">Ekle</a></div></div>';

                                veriyok = false;
                            }
                        }

                        htmlText += "</div>";

                        $('#sonId').val(sonid);

                        if (!ilk)
                            divData.innerHTML += htmlText;
                        else
                            divData.innerHTML = htmlText;
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        alert(XMLHttpRequest.responseText);
                    }
                }
            );

            if (ilk && getParameterByName("aktar")) {
                var adet = 1;
                if (!isNaN(parseFloat(getParameterByName("adet"))) && isFinite(getParameterByName("adet"))) {
                    adet = parseInt(getParameterByName("adet"));
                }
                else {
                    AndroidToast('Miktar anlaşılamadı, 1 adet eklendi.');
                }

                var itemref = getParameterByName("itemref");
                var ad = getParameterByName("ad");
                var fiyat = getParameterByName("fiyat");
                UrunEkle(itemref, ad, fiyat, adet);
            }
        }

        function Konus() {
            var parametre = 'smref=' + getParameterByName("smref") + '&fiyattip=' + getParameterByName("fiyattip") + '&urunarama';
            Konustur(window.location.href, parametre);
        }

        function Konus2(itemref, ad, fiyat, adet) {
            try {
                var parametre = 'smref=' + getParameterByName("smref") + '&fiyattip=' + getParameterByName("fiyattip") + '&aktar=true&itemref=' + itemref + '&fiyat=' + fiyat + '&ad=' + ad + '&adet';
                if (getParameterByName("urunarama")) {
                    parametre = 'urunarama=' + getParameterByName("urunarama") + '&' + parametre;
                }
                Android.konustur(window.location.href.split('?')[0], parametre);
            } catch (e) {
                UrunEkle(itemref, ad, fiyat, adet);
            }
        }

        function UrunEkle(itemref, ad, fiyat, adet) {
            var siparis;
            var vardi = false;

            if (readCookie("siparisliste")) {
                siparis = JSON.parse(readCookie("siparisliste"));
                vardi = true;
            }
            else {
                siparis = {
                    musteriid: $('#musteriid').val(),
                    fiyattip: $('#fiyattip').val(),
                    smref: $('#smref').val(),
                    siparisliste: []
                };
            }

            var urunvar = false;
            for (var i = 0; i < siparis.siparisliste.length; i++) {
                if (siparis.siparisliste[i].itemref == itemref) {
                    urunvar = true;
                    siparis.siparisliste[i].adet = siparis.siparisliste[i].adet + adet;
                }
            }

            if (!urunvar) {
                var siparisdetay = { itemref: itemref, ad: ad, adet: adet, fiyat: fiyat };
                siparis.siparisliste.push(siparisdetay);
            }

            if (vardi)
                eraseCookie("siparisliste");
            createCookie("siparisliste", JSON.stringify(siparis), 1);

            document.getElementById('siparisGoster').innerText = "Siparişi Göster (" + Object.keys(siparis.siparisliste).length + ")";

            AndroidToast(adet + ' adet eklendi.');
        }

        $(window).scroll(function () {
            if ($(window).scrollTop() == $(document).height() - $(window).height()) {
                VeriGetir(false);
            }
        });

        $(document).ready(function () {
            if (getParameterByName("smref"))
                $('#smref').val(getParameterByName("smref"));

            if (getParameterByName("fiyattip")) {
                $('#fiyattip').val(getParameterByName("fiyattip"));
                $('#ddlFiyatTipleri').css("display", "none");
                $('#divUrunArama').css("display", "");
				VeriGetir(true);
            }

            if (readCookie("siparisliste")) {
                document.getElementById('siparisGoster').innerText = "Siparişi Göster (" + Object.keys(JSON.parse(readCookie("siparisliste")).siparisliste).length + ")";
            }
        });

        function Temizle() {
            eraseCookie('siparisliste');
            AndroidToast('Sipariş temizlendi.');
            document.getElementById('siparisGoster').innerText = 'Siparişi Göster (0)';
        }

        function SiparisiGoster() {
            $('#divSepet').css('display', '');
            document.getElementById('iframeSip').contentWindow.location.reload();
        }

        function SiparisiGizle() {
            $('#divSepet').css('display', 'none');
        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="login-page">
            <div class="form">
                <uc2:ucUst ID="ucUst" runat="server" />
                <asp:DropDownList runat="server" ID="ddlFiyatTipleri" Height="25px" ForeColor="#006699"
                        Width="100%" Style="padding: 3px 3px 3px 3px; border: 1px solid #CCCCCC; background: #ededed;">
                    </asp:DropDownList>
                <br />
                <div id="divUrunArama" style="display: none">
                <a class="button1" href="javascript:Konus()" style="float: left; padding: 9px">
                    <img style="width: 28px" src="microphone.png" /></a>
                <input type="text" id="urunarama" placeholder="Buradan arayabilirsiniz..." autocomplete="off" onkeydown="return clickButton(event,'aAra')" style="width: 55%" />
                <a class="button1" id="aAra" href="javascript:VeriGetir(true)">&nbsp;&nbsp;&nbsp;Ara&nbsp;&nbsp;&nbsp;</a>
                <br />
                <br />
                <a id="siparisGoster" class="button1" href="javascript:SiparisiGoster()">Siparişi Göster (0)</a>
                <a class="button1" href="javascript:Temizle()">Siparişi Temizle</a>
                <br />
                <br />
                <br />
                </div>
                <div id="divData"></div>
                <input type="hidden" id="sonId" value="0" />
                <input type="hidden" runat="server" id="musteriid" value="0" />
                <input type="hidden" runat="server" id="smref" value="0" />
                <input type="hidden" runat="server" id="fiyattip" value="0" />

                <div id="divSepet" style="position: fixed; width: 100%; height: 100%; z-index: 100; left: 0; top: 0; display: none">
                    <iframe id="iframeSip" src="siparisgoster.aspx" style="width: 100%; height: 100%; border: 0px;"></iframe>
                </div>

                <script type="text/javascript">
                    $('#ddlFiyatTipleri').change(function () {
                        Temizle();
                        //$('#fiyattip').val($('#ddlFiyatTipleri').val());
                        //VeriGetir(true);
                        //document.getElementById("ddlFiyatTipleri").remove(0);
                        window.location.href = window.location.href + "&fiyattip=" + $('#ddlFiyatTipleri').val();
                    });
                </script>
                <uc3:ucAlt ID="ucAlt1" runat="server" />
                <uc1:ucProgress ID="ucProgress1" runat="server" />
            </div>
        </div>
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="konumlar.aspx.cs" Inherits="Sultanlar.WebUI.merch.konumlar" %>

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
    <script type="text/javascript" src="../musteri/js/wmBox.js"></script>
    <script type="text/javascript" src="../musteri/js/jquery.tipTip.js"></script>
    <link rel="stylesheet" type="text/css" href="../musteri/js/tipTip.css" />
    <script type="text/javascript">
        var veriyok = false;

        function VeriGetir(ilk) {
            var sonid = parseInt($('#sonId').val());

            if (!ilk && veriyok)
                return;

            veriyok = true;

            if (ilk) {
                sonid = 0;
                $('#sonId').val('0');
            }

            var subearama = "";
            if (getParameterByName("sube")) {
                subearama = getParameterByName("sube");
                $('#inputSube').val(getParameterByName("sube"));
            }
            else {
                subearama = $('#inputSube').val();
            }

            var slsmanref = "";
            if (getParameterByName("slsref")) {
                slsmanref = getParameterByName("slsref");
                $('#slsref').val(getParameterByName("slsref"));
                $('#ddlTemsilciler').val(getParameterByName("slsref"));
            }
            else {
                slsmanref = $('#slsref').val();
            }

            AndroidProgress(true);
            $.ajax(
                {
                    type: 'POST',
                    url: 'konumlar.aspx/KonumlarGetir',
                    data: '{ sonid: "' + $('#sonId').val() + '", slsref: "' + slsmanref + '", sube: "' + subearama + '" }',
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'json',
                    success: function (data) {
                        var htmlText = '<table style="font-size: 12px;">';

                        for (var key1 in data) {
                            for (var key in data[key1]) {
                                sonid++;

                                htmlText += '<tr><td style="width: 40%"><span class="kucukbilgiGoster" title="' + data[key1][key].Musteri + ' - ' + data[key1][key].Sube + '">' + data[key1][key].Sube + '</span></td><td style="width: 30%; text-align: center">';
                                htmlText += data[key1][key].KONUM != "" ? '<a style="float: left" class="wmBox button" href="../musteri/map.aspx?lat=' + data[key1][key].KONUM.substring(0, data[key1][key].KONUM.indexOf(",") - 1) + '&lng=' + data[key1][key].KONUM.substring(data[key1][key].KONUM.indexOf(",") + 1) + '&title=' + TurkceKarakter(data[key1][key].Sube.split(" ").join("-")) + '&label=' + TurkceKarakter(data[key1][key].Sube[0]) + '">Gös.</a><a style="float: right" class="button" href="konumal2.aspx?smref=' + data[key1][key].Kod + '&tip=' + data[key1][key].TIP_KOD + '">Değ.</a>' : '';
                                htmlText += data[key1][key].KONUM == "" ? '<a class="button" href="konumal.aspx?smref=' + data[key1][key].Kod + '&tip=' + data[key1][key].TIP_KOD + '">Konum Al</a>' : '';
                                htmlText += '</td><td style="width: 20%; text-align: center"><span class="kucukbilgiGoster" onclick="AndroidToast($(this).prop(\'title\'))" title="' + data[key1][key].Adres + '">' + (data[key1][key].Adres != "" ? data[key1][key].Adres.substring(0, 10) + "..." : "") + '</span></td></tr>';

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
                        //$.wmBox();
                        //$('[data-popup]').click(function (e) {
                        //    e.preventDefault();
                        //    $('.wmBox_overlay').fadeIn(750);
                        //    var mySrc = $(this).attr('data-popup');
                        //    $('.wmBox_overlay .wmBox_scaleWrap').append('<iframe src="' + mySrc + '">');

                        //    $('.wmBox_overlay iframe').click(function (e) {
                        //        e.stopPropagation();
                        //    });
                        //    $('.wmBox_overlay').click(function (e) {
                        //        e.preventDefault();
                        //        $('.wmBox_overlay').fadeOut(750, function () {
                        //            $(this).find('iframe').remove();
                        //        });
                        //    });
                        //});

                        AndroidProgress(false);
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        alert(XMLHttpRequest.responseText);
                    }
                }
            );
        }

        $(document).ready(function () {
            $.wmBox();
            //if (getParameterByName('slsref') == null) {
            //    document.getElementById('ddlTemsilciler').value = 0;
            //}
            //else {
            //    document.getElementById('ddlTemsilciler').value = getParameterByName('slsref');
            //}
            VeriGetir(true);
        });

        $(window).scroll(function () {
            if ($(window).scrollTop() == $(document).height() - $(window).height()) {
                VeriGetir(false);
            }
        });

        //function Ara() {
        //    Goster();
        //    var val = $("#ddlTemsilciler option:selected").val();
        //    var val2 = $("#txtFarkliZiyaretSube").val();
        //    window.location.href = 'konumlar.aspx?slsref=' + val + '&sube=' + val2;
        //}

        function TurkceKarakter(Ham)
        {
            return Ham.split("İ").join("I").split("Ğ").join("G").split("Ü").join("U").split("Ş").join("S").split("Ö").join("O").split("Ç").join("C").split("&").join("-").split(" ").join("-");
        }

        function Konus() {
            Konustur(window.location.href, 'sube');
        }

        function musAra() {
            if (getParameterByName("slsref")) {
                window.location.href = 'konumlar.aspx?slsref=' + getParameterByName("slsref") + '&sube=' + $('#inputSube').val();
            } else {
                window.location.href = 'konumlar.aspx?sube=' + $('#inputSube').val();
                }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="login-page">
            <div class="form">
                <uc2:ucUst ID="ucUst" runat="server" />
                <%--<a class="button" href="menu.aspx" onclick="Goster()">Ana Menüye Dön</a><br />--%>
                <div runat="server" id="divTemsilciler">
                <asp:DropDownList runat="server" ID="ddlTemsilciler" Height="25px" ForeColor="#006699" 
                    Width="100%" style="padding: 3px 3px 3px 3px;border:1px solid #CCCCCC;background:#ededed;"></asp:DropDownList>
                </div>
                <br />
                <%--<asp:TextBox runat="server" ID="txtFarkliZiyaretSube" Width="70%" placeholder="Buradan arayabilirsiniz..." onkeypress="return clickButton(event,'aAra')"></asp:TextBox>--%>
                <%--<asp:Button runat="server" ID="btnFarkliZiyaretAra" Width="20%" Text="Ara" OnClientClick="Goster()" OnClick="btnFarkliZiyaretAra_Click" />--%>
                <a class="button1" href="javascript:Konus()" style="float: left; padding: 9px"><img style="width: 28px" src="microphone.png" /></a>
                <input type="text" id="inputSube" style="width: 55%" placeholder="Buradan arayabilirsiniz..." autocomplete="off" onkeydown="return clickButton(event,'aAra')" />
                <a class="button1" id="aAra" href="javascript:musAra()">&nbsp;&nbsp;&nbsp;Ara&nbsp;&nbsp;&nbsp;</a>
                
                <div id="divData"></div>
                <span id="spanYukleniyor" style="font-style: italic; display: none"><br />Yükleniyor...</span>
                <input type="hidden" id="sonId" value="0" />
                <input type="hidden" runat="server" id="slsref" value="" clientidmode="Static" />
                <script type="text/javascript">
                    //(function ($) {
                    //    $.wmBox = function () {
                    //        $('body').prepend('<div class="wmBox_overlay"><div class="wmBox_centerWrap"><div class="wmBox_centerer"><div class="wmBox_contentWrap" style="width: 80%"><div class="wmBox_scaleWrap"><div class="wmBox_closeBtn"><p>x</p></div>');
                    //    };
                    //    $('[data-popup]').click(function (e) {
                    //        e.preventDefault();
                    //        $('.wmBox_overlay').fadeIn(750);
                    //        var mySrc = $(this).attr('data-popup');
                    //        $('.wmBox_overlay .wmBox_scaleWrap').append('<iframe src="' + mySrc + '">');

                    //        $('.wmBox_overlay iframe').click(function (e) {
                    //            e.stopPropagation();
                    //        });
                    //        $('.wmBox_overlay').click(function (e) {
                    //            e.preventDefault();
                    //            $('.wmBox_overlay').fadeOut(750, function () {
                    //                $(this).find('iframe').remove();
                    //            });
                    //        });
                    //    });
                    //} (jQuery));
                </script>
                <script type="text/javascript">
                    $('#ddlTemsilciler').change(function () {
                        //$('#slsref').val($('#ddlTemsilciler').val());
                        //VeriGetir(true);
                        window.location.href = "konumlar.aspx?slsref=" + $('#ddlTemsilciler').val();
                    });
                </script>
                <uc3:ucAlt ID="ucAlt1" runat="server" />
                <uc1:ucProgress ID="ucProgress1" runat="server" />
            </div>
        </div>
    </form>
</body>
</html>

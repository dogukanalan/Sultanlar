<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="haritaurun.aspx.cs" Inherits="Sultanlar.WebUI.musteri.haritaurun" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="cache-control" content="no-cache" />
    <meta name="viewport" content="width=device-width,initial-scale=1" />
    <title></title>
    <link rel="stylesheet" href="https://code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script type="text/javascript" src="https://code.jquery.com/ui/1.12.1/jquery-ui.min.js"></script>
    <style type="text/css">
@charset "utf-8";
/* CSS Document */
  .ui-autocomplete {
            height: 200px;
            overflow-y: scroll;
            overflow-x: hidden;
        }

        @import url(https://fonts.googleapis.com/css?family=Open+Sans:400,700,600,300,800);

        html,
        body {
            overflow-x: hidden;
            font-family: "Open Sans", sans-serif;
            font-weight: 300;
            color: #fff;
            background: #fff;
            margin: 0;
        }
#divMusteriler { width: 100%;
                    font-size: 0.8em;
    color: #ffffff;
    text-shadow: 0 1px 0 rgba(206, 201, 201, 0.7);
    }
        .row {
            position: relative;
            max-width: 800px;
            margin: 10px auto;
            padding: 0px 17%;
            background: #ffffff;
            text-align: center;
            z-index: 1;
        }

        .row:before {
            position: absolute;
            content: "";
            display: block;
            top: 0;
            left: -5000px;
            height: 100%;
            width: 15000px;
            z-index: -1;
            background: inherit;
        }

        .row span {
            position: relative;
            display: grid;
            margin: 3px 1px;
        }

        .basic-slide {
  position: relative;
  display: inline-block;
  width: 100%;
  padding: 10px 0 10px 15px;
  /*font-family: "Open Sans", sans;*/
  font-weight: 400;
  color: #ffffff;
  background: #de4949;
  border: 0;
  border-radius: 3px;
  outline: 0;
  text-indent: 60px; 
  transition: all .3s ease-in-out;
        }

        .basic-slide::-webkit-input-placeholder {
            color: #de4949;
    text-indent: 0;
    font-weight: 300;
        }

        .basic-slide + label {
display: inline-block;
    position: absolute;
    transform: translateX(0);
    top: 0;
    left: 0;
    bottom: 0;
    padding: 13px 15px;
    font-size: 11px;
    font-weight: 700;
    text-transform: uppercase;
    color: #fff;
    text-align: left;
    /*text-shadow: 0 1px 0 rgba(255,255,255,.4);*/
    transition: all .3s ease-in-out, color .3s ease-out;
    border-top-left-radius: 3px;
    border-bottom-left-radius: 3px;
    overflow: hidden;
        }
        .basic-slide + label:after {
      content: "";
      position: absolute;
      top: 0;
      right: 100%;
      bottom: 0;
      width: 100%;
            background: #de4949;
      z-index: -1;
      transform: translate(0);
      transition: all .3s ease-in-out;
      border-top-left-radius: 3px;
      border-bottom-left-radius: 3px;
        }
        .basic-slide:focus,
        .basic-slide:active {
  color: #377D6A;
  text-indent: 0;
  background: #f3f3f3;
  border-top-left-radius: 0;
  border-bottom-left-radius: 0;
        }

        .basic-slide:active::-webkit-input-placeholder {
            color: #aaa;
        }

        .basic-slide:active + label {
                color: #fff;
    text-shadow: 0 1px 0 rgba(19,74,70,.4);
    transform: translateX(-100%);
        }

        .basic-slide:active + label:after {
                transform: translate(100%);
        }

        .basic-slide:focus::-webkit-input-placeholder {
            color: #aaa;
        }

        .basic-slide:focus + label {
                color: #fff;
    text-shadow: 0 1px 0 rgba(19,74,70,.4);
    transform: translateX(-100%);
        }

        .basic-slide:focus + label:after {
                transform: translate(100%);
        }

        a {
            color: #3c3d40;
            text-decoration: none;
            transition: all .3s ease-in-out;
        }

        a:hover {
            color: #df4949;
        }

    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="row">
                <span>
                    <input type="text" class="basic-slide" id="inputUrun" placeholder="Ürün arayınız..." /><label for="inputUrun">ÜRÜN</label></span>
            </div>
            <div class="row">
                <span>
                    <input type="text" class="basic-slide" id="inputIl" placeholder="İl yazınız..." disabled="disabled" /><label for="inputIl">ŞEHİR</label></span>
            </div>
            <div class="row">
                <span>
                    <input type="text" class="basic-slide" id="inputIlce" placeholder="İlçe yazınız..." disabled="disabled" /><label for="inputIlce">İLÇE</label></span>
            </div>
            <div id="divMusteriler"></div>

            <script type="text/javascript">
                var sourceUrun;
                var sourceIl;
                var sourceIlce;

                var selectUrun;
                var selectIl;
                var selectIlce;

                var marka = "";
                if (getParameterByName("marka")) {
                    marka = getParameterByName("marka");
                }

                $(function () {
                    $.ajax(
                        {
                            type: 'POST',
                            url: 'haritaurun.aspx/UrunGetir',
                            contentType: 'application/json; charset=utf-8',
                            data: '{ marka: "' + marka + '" }',
                            dataType: 'json',
                            success: function (data) {
                                sourceUrun = data.d;
                                Ayarla("#inputUrun");
                                $('#divProgress').css("display", "none");
                            },
                            error: function (XMLHttpRequest, textStatus, errorThrown) {
                                alert(XMLHttpRequest.responseText);
                            }
                        }
                    );

                    $.ajax(
                        {
                            type: 'POST',
                            url: 'haritaurun.aspx/IlGetir',
                            contentType: 'application/json; charset=utf-8',
                            dataType: 'json',
                            success: function (data) {
                                sourceIl = data.d;
                                Ayarla("#inputIl");
                            },
                            error: function (XMLHttpRequest, textStatus, errorThrown) {
                                alert(XMLHttpRequest.responseText);
                            }
                        }
                    );
                });

                function Ayarla(kontrol) {
                    var dataSource = $.map((kontrol == "#inputUrun" ? sourceUrun : kontrol == "#inputIl" ? sourceIl : sourceIlce), function (item) {
                        return { label: item.aciklama, value: item.aciklama, value1: item.id };
                    });
                    $(kontrol).autocomplete({
                        source: dataSource,
                        minLength: 2,
                        select: function (event, ui) {
                            if (kontrol == "#inputUrun") {
                                selectUrun = ui.item.value1;
                                $("#inputIl").prop('disabled', false);
                            }
                            else if (kontrol == "#inputIl") {
                                selectIl = ui.item.value1.toString().length == 1 ? "0" + ui.item.value1.toString() : ui.item.value1.toString();
                                IlceGetir();
                                $("#inputIlce").prop('disabled', false);
                                $("#inputIlce").val("");
                                $('#inputIl').blur();
                                selectIlce = "Tümü";
                                MusteriGetir();
                                $("#inputUrun").prop('disabled', true);
                            }
                            else {
                                selectIlce = ui.item.label;
                                MusteriGetir();
                                $('#inputIlce').blur();
                                $("#inputUrun").prop('disabled', true);
                                $("#inputIl").prop('disabled', true);
                                $("#inputIlce").prop('disabled', true);
                            }
                        }
                    });
                }

                function IlceGetir() {
                    $.ajax(
                        {
                            type: 'POST',
                            url: 'haritaurun.aspx/IlceGetir',
                            data: '{ ilkod: "' + selectIl + '" }',
                            contentType: 'application/json; charset=utf-8',
                            dataType: 'json',
                            success: function (data) {
                                sourceIlce = data.d;
                                Ayarla("#inputIlce");
                            },
                            error: function (XMLHttpRequest, textStatus, errorThrown) {
                                alert(XMLHttpRequest.responseText);
                            }
                        }
                    );
                }

                function MusteriGetir() {
                    $.ajax(
                        {
                            xhr: function () {
                                var xhr = new window.XMLHttpRequest();

                                xhr.upload.addEventListener("progress", function (evt) { // Upload progress
                                    if (evt.lengthComputable) {
                                        var percentComplete = evt.loaded / evt.total;
                                        $('#divProgress').css("display", "");
                                    }
                                }, false);

                                xhr.addEventListener("progress", function (evt) { // Download progress
                                    if (evt.lengthComputable) {
                                        var percentComplete = evt.loaded / evt.total;
                                        $('#divProgress').css("display", "");
                                    }
                                }, false);

                                return xhr;
                            },
                            type: 'POST',
                            url: 'haritaurun.aspx/MusteriGetir',
                            data: '{ ilkod: "' + selectIl + '", ilcekod: "' + selectIlce + '", urunid: "' + selectUrun + '" }',
                            contentType: 'application/json; charset=utf-8',
                            dataType: 'json',
                            success: function (data) {

                                var htmlText = '<table style="width: 100%; background: #a7a7a7" cellpadding="5px">';
                                        htmlText += '<tr>';
                                        htmlText += '<td style="width: 40%; height: 30px; text-align: center; border-bottom: 1px solid #ffffff">MARKET</td><td style="width: 60%; text-align: center; border-bottom: 1px solid #ffffff">ADRES</td>';
                                        htmlText += '</tr>';
                                var colour = true;
                                var sonucvar = false;
                                for (var key1 in data) {
                                    for (var key in data[key1]) {
                                        sonucvar = true;

                                        var color = '';
                                        if (colour) {
                                            color = 'background-color: white;';
                                            colour = false;
                                        }
                                        else {
                                            color = 'background-color: lightgray;';
                                            colour = true;
                                        }
                                        htmlText += '<tr style="color: #943e3e; ' + color + '">';
                                        htmlText += '<td style="height: 50px; text-align: left;">' + data[key1][key].SUBE + '</td><td style="text-align: left;"><a target="_blank" href="https://www.google.com/maps?q=' + data[key1][key].KONUM + '">' + data[key1][key].KONUM_ADRES + '</a></td>';
                                        htmlText += '</tr>';
                                    }
                                }
                                if (!sonucvar) {
                                    htmlText += '<tr><td style="width: 40%; height: 30px; text-align: center; border-bottom: 1px solid #ffffff" colspan="2">Sonuç bulunamadı</td></tr>';
                                }
                                htmlText += "</table>";
                                divMusteriler.innerHTML = htmlText;

                                $('#divProgress').css("display", "none");
                            },
                            error: function (XMLHttpRequest, textStatus, errorThrown) {
                                alert(XMLHttpRequest.responseText);
                            }
                        }
                    );
                }

                $(function () {
                    $('input').keyup(function () {
                        this.value = this.value.toLocaleUpperCase();
                    });
                });


                function getParameterByName(name, url) {
                    if (!url) url = window.location.href;
                    name = name.replace(/[\[\]]/g, "\\$&");
                    var regex = new RegExp("[?&]" + name + "(=([^&#]*)|&|#|$)"),
                        results = regex.exec(url);
                    if (!results) return null;
                    if (!results[2]) return '';
                    return decodeURIComponent(results[2].replace(/\+/g, " "));
                }
            </script>

            <div id="divProgress">
                <div style="padding-top: 50px; filter: alpha(opacity=40); -moz-opacity: .60; opacity: .60; background-color: #fff; position: fixed; width: 100%; height: 100%; z-index: 99; left: 0; top: 0;">
                </div>
                <div style="padding-top: 50px; position: fixed; width: 100%; height: 100%; z-index: 100; left: 0; top: 0;">
                    <table style="width: 100%; height: 100px; background-color: #ffffff; border: 1px solid #D1D1D1; padding: 5px;">
                        <tr>
                            <td style="text-align: center; border-bottom: 1px dotted #CCCCCC; height: 50px; font-size: 18px; font-family: Gisha">Yükleniyor
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: center; height: 100%">
                                <br />
                                <span style="font-family: Tahoma; font-size: 16px; color: #C5670B">lütfen bekleyin...</span><br />
                                <br />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
    </form>
</body>
</html>

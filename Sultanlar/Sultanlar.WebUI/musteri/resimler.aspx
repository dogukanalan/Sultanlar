<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="resimler.aspx.cs" Inherits="Sultanlar.WebUI.musteri.resimler" %>

<%@ Register Src="ucAlt.ascx" TagName="ucAlt" TagPrefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Sultanlar : Resimler</title>
    <link rel="stylesheet" type="text/css" href="StyleSheet.css" />

    <script type="text/javascript" src="js/jquery-1.2.6.pack.js"></script>
    <script type="text/javascript" src="js/jquery-1.8.3.js"></script>
    <script type="text/javascript" src="js/jquery-ui.js"></script>
    <link rel="stylesheet" href="js/jquery-ui.css" />
    <script type="text/javascript" src="js/scripts.js"></script>
    <style type="text/css">
        #top {
            bottom: 5px;
            right: 5px;
            background: #147;
            padding: 5px;
            color: #fff;
            font: bold 11px verdana;
            position: fixed;
            display: none;
            cursor: default;
        }

        [class*=dxgvTable] [class*=dxeCalendarFooter] tr {
            visibility: hidden !important;
        }

.urunResimQtip {
    max-width: 800px;
    max-height: 800px;
}
    </style>

    <script type="text/javascript" src="js/jquery.tipTip.js"></script>
    <script type="text/javascript" src="js/jquery.tipTip.minified.js"></script>
    <link rel="stylesheet" type="text/css" href="js/tipTip.css" />

      <script type='text/javascript' src="js/jquery.qtip.js"></script>
      <link rel="stylesheet" type="text/css" href="js/jquery.qtip.css"/>

    <script type="text/javascript">
        $(document).ready(function () {
            $("input[type=submit], input[type=button], a[class=button]").button();
            if (getParameterByName('slsref') == null) {
                //document.getElementById('ddlTemsilciler').value = 0;
            }
            else {
                document.getElementById('ddlTemsilciler').value = getParameterByName('slsref');
                if (getParameterByName('tur') != null)
                    document.getElementById('ddlTurler').value = getParameterByName('tur');
                if (getParameterByName('yil') != null)
                    document.getElementById('ddlYil').value = getParameterByName('yil');
                if (getParameterByName('ay') != null)
                    document.getElementById('ddlAy').value = getParameterByName('ay');
            }

            if (getParameterByName('rutid') != null)
                document.getElementById('rutId').value = getParameterByName('rutid');

            VeriGetir(true);
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

        function qtip() {
            $('.urunResim').each(function () {
                $(this).qtip({
                    content: '<img src="' + $(this).attr('rel') + '" class="urunResimQtip" />',
                    position: { my: 'top right', at: 'top left' }
                });
            });
        }
    </script>
    <script type="text/javascript">
        function VeriGetir(ilk) {
            var sonid = parseInt($('#sonId').val());
            var veriyok = true;

            $.ajax(
                {
                    xhr: function () {
                        var xhr = new window.XMLHttpRequest();
                        //Upload progress
                        xhr.upload.addEventListener("progress", function (evt) {
                            if (evt.lengthComputable) {
                                var percentComplete = evt.loaded / evt.total;
                                $('#divLoading').css("display", "block");
                            }
                        }, false);
                        //Download progress
                        xhr.addEventListener("progress", function (evt) {
                            if (evt.lengthComputable) {
                                var percentComplete = evt.loaded / evt.total;
                                $('#divLoading').css("display", "block");
                            }
                        }, false);
                        return xhr;
                    },
                    type: 'POST',
                    url: 'resimler.aspx/ResimlerGetir',
                    data: '{ slsref: "' + document.getElementById('ddlTemsilciler').value + '", turid: "' + document.getElementById('ddlTurler').value + '", yil: "' + document.getElementById('ddlYil').value + '", ay: "' + document.getElementById('ddlAy').value + '", kacincidan: "' + $('#sonId').val() + '", rutid: "' + $('#rutId').val() + '" }',
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'json',
                    success: function (data) {
                        var htmlText = '';
                        $('#divLoading').css("display", "none");

                        if (ilk)
                            htmlText += '<table cellpadding="5" cellspacing="0" style="width: 100%"><tr style="color: Red">' +
                                '<td style="width: 15%; text-align: center; border-bottom: 1px solid Gray">Kişi</td>' +
                                '<td style="width: 30%; text-align: center; border-bottom: 1px solid Gray">Nokta</td>' +
                                '<td style="width: 10%; text-align: center; border-bottom: 1px solid Gray">Tür</td>' +
                                '<td style="width: 20%; text-align: center; border-bottom: 1px solid Gray">Açıklama</td>' +
                                '<td style="width: 10%; text-align: center; border-bottom: 1px solid Gray">Tarih</td>' +
                                '<td style="width: 10%; text-align: center; border-bottom: 1px solid Gray">Resim</td></tr></table>';

                        var grituruncu = false;
                        for (var key1 in data) {
                            for (var key in data[key1]) {
                                grituruncu = !grituruncu;
                                sonid = data[key1][key].ID;
                                htmlText += '<table cellpadding="5" cellspacing="0" style="width: 100%">';
                                htmlText += '<tr style="background-color: #' + (grituruncu ? 'EFEEEA' : 'FFF6ED') + '">' +
                                    '<td style="width: 15%;" valign="middle"><span>' + data[key1][key].AdSoyad +
                                    '</span></td>' +

                                    '<td style="width: 30%;" valign="middle"><span>' + data[key1][key].SUBE +
                                    '</span></td>' +

                                    '<td style="width: 10%; text-align: center" valign="middle"><span class="hotspotCizgisiz">' + data[key1][key].strTur +
                                    '</span></td>' +

                                    '<td style="width: 20%;" valign="middle"><span>' + data[key1][key].strAciklama +
                                    '</span></td>' +

                                    '<td style="width: 10%; font-size: 12px; text-align: center" valign="middle">' + data[key1][key].dtTarih + '</td>' +

                                    '<td style="width: 10%; text-align: center"><a href="resim2.aspx?str=musres-' + data[key1][key].ID + '"><img src="resim.aspx?musres=' +
                                    data[key1][key].ID + '" alt="' + data[key1][key].strAciklama + '" style="height: 120px; max-width: 90px" rel="resim.aspx?musres=' +
                                    data[key1][key].ID + '" class="urunResim" /></a></td></tr>';
                                htmlText += '</table>';
                                veriyok = false;
                            }
                        }

                        $('#sonId').val(sonid);
                        divData.innerHTML += htmlText;
                        if (veriyok) {
                            $('#aDaha').css("display", "none");
                            $('#spanDaha').css("display", "block");
                        }
                        $(".kucukbilgiGoster").tipTip({ activation: "hover" });
                        qtip();
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        alert(XMLHttpRequest.responseText);
                    }
                });

            return veriyok;
        }
    </script>
</head>
<body style="margin: 0 0 0 0;background-color: #EFEEEA;">
    <form id="form1" runat="server">
        

    <div style="width: 100%; font-size: 9px; font-family: Verdana; background-color: #EFEEEA; border-bottom: 1px solid #FFCFB2"">
    <table cellpadding="5" cellspacing="0">
    <tr>
    <td style="width: 800px;" valign="middle">
        <table cellpadding="0" cellspacing="0"><tr><td>
        <input type="button" value="Giriş" onclick="javascript: window.location.href = 'default.aspx'" /> 
        <input type="button" value="Aktiviteler" onclick="javascript: window.location.href = 'aktiviteler.aspx'" /> 
        <input type="button" value="H.Bedelleri" onclick="javascript: window.location.href = 'hizmetbedelleri.aspx'" /> 
        <input type="button" value="Anlaşmalar" onclick="javascript: window.location.href = 'anlasmalar.aspx'" /> 
        <input type="button" value="Siparişler" onclick="javascript: window.location.href = 'siparisler.aspx'" /> 
        <input type="button" value="İadeler" onclick="javascript: window.location.href = 'iadeler.aspx'" /> 
        <input type="button" value="Tahsilatlar" onclick="javascript: window.location.href = 'odemeler.aspx'" /> 
        <input type="button" value="Raporlar" onclick="javascript: window.location.href = 'hesapayrinti.aspx'" /> 
        <input type="button" value="Üye İşlemleri" onclick="javascript: window.location.href = 'uyelik.aspx'" /> 
        <input type="button" value='Mesajlar (<%= Sultanlar.DatabaseObject.Internet.GonderilenMesajlar.GetObjectCount(((Sultanlar.DatabaseObject.Internet.Musteriler)Session["Musteri"]).pkMusteriID).ToString() %>)' onclick="javascript: window.location.href = 'mesajlar.aspx'" /></td><td align="left"></td></tr></table>
    </td>
    <td style="width: 200px; font-family: Gisha; font-size: 12px" align="right">
        <table cellpadding="0" cellspacing="0"><tr><td><asp:Label ID="Label1" runat="server"></asp:Label>&nbsp;&nbsp;&nbsp;</td><td><asp:ImageButton runat="server" ID="ImageButton1" OnClick="ImageButton1_Click" ImageUrl="img/ic_logout.png" /></td></tr></table>
    </td>
    </tr>
    </table>
    </div>
        <div style="font-family: Verdana; font-size: 12px; padding: 10px 10px 10px 10px;">
        <div runat="server" id="divTemsilciler">
            <asp:DropDownList runat="server" ID="ddlTemsilciler" Height="25px" ForeColor="#006699"
                Width="300px" Style="padding: 3px 3px 3px 3px; border: 1px solid #CCCCCC; background: #ededed;">
            </asp:DropDownList>
        </div>
        <br />
        <asp:DropDownList runat="server" ID="ddlTurler" AutoPostBack="false" ForeColor="#006699"
            Style="padding: 3px 3px 3px 3px; border: 1px solid #CCCCCC; background: #ededed; font-size: 16px">
        </asp:DropDownList>
        <asp:DropDownList runat="server" ID="ddlYil" AutoPostBack="false" ForeColor="#006699"
            Style="padding: 3px 3px 3px 3px; border: 1px solid #CCCCCC; background: #ededed; font-size: 16px">
            <asp:ListItem Text="Tümü" Value="0"></asp:ListItem>
            <asp:ListItem Text="2018" Value="2018"></asp:ListItem>
            <asp:ListItem Text="2019" Value="2019"></asp:ListItem>
        </asp:DropDownList>
        <asp:DropDownList runat="server" ID="ddlAy" AutoPostBack="false" ForeColor="#006699"
            Style="padding: 3px 3px 3px 3px; border: 1px solid #CCCCCC; background: #ededed; font-size: 16px">
            <asp:ListItem Text="Tümü" Value="0"></asp:ListItem>
            <asp:ListItem Text="1" Value="1"></asp:ListItem>
            <asp:ListItem Text="2" Value="2"></asp:ListItem>
            <asp:ListItem Text="3" Value="3"></asp:ListItem>
            <asp:ListItem Text="4" Value="4"></asp:ListItem>
            <asp:ListItem Text="5" Value="5"></asp:ListItem>
            <asp:ListItem Text="6" Value="6"></asp:ListItem>
            <asp:ListItem Text="7" Value="7"></asp:ListItem>
            <asp:ListItem Text="8" Value="8"></asp:ListItem>
            <asp:ListItem Text="9" Value="9"></asp:ListItem>
            <asp:ListItem Text="10" Value="10"></asp:ListItem>
            <asp:ListItem Text="11" Value="11"></asp:ListItem>
            <asp:ListItem Text="12" Value="12"></asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
        <div id="divData"></div>
        <div id="divLoading" style="display: none; text-align: center">
            <br />
            <i>yükleniyor...</i><br />
            <br />
        </div>
            <br />
        <a id="aDaha" class='button' href='javascript:VeriGetir(false);' style="display: block; text-align: center;">Daha fazla görüntüle</a>
        <span id="spanDaha" class="fs-14" style="display: none; text-align: center;">
            <br />
            <i>Bulunamadı...</i></span>
        <input type="hidden" id="sonId" value="1000000" />
        <input type="hidden" id="rutId" value="0" />

        </div>
        <script type="text/javascript">
            $('#ddlTemsilciler').change(function () {
                var val = $("#ddlTemsilciler option:selected").val();
                var val2 = $("#ddlTurler option:selected").val();
                var val3 = $("#ddlYil option:selected").val();
                var val4 = $("#ddlAy option:selected").val();
                window.location.href = 'resimler.aspx?slsref=' + val + '&tur=' + val2 + '&yil=' + val3 + '&ay=' + val4;
            });
            $('#ddlTurler').change(function () {
                var val = $("#ddlTemsilciler option:selected").val();
                var val2 = $("#ddlTurler option:selected").val();
                var val3 = $("#ddlYil option:selected").val();
                var val4 = $("#ddlAy option:selected").val();
                window.location.href = 'resimler.aspx?slsref=' + val + '&tur=' + val2 + '&yil=' + val3 + '&ay=' + val4;
            });
            $('#ddlYil').change(function () {
                var val = $("#ddlTemsilciler option:selected").val();
                var val2 = $("#ddlTurler option:selected").val();
                var val3 = $("#ddlYil option:selected").val();
                if (val3 == "0")
                    $("#ddlAy option:selected").val("0")
                var val4 = $("#ddlAy option:selected").val();
                window.location.href = 'resimler.aspx?slsref=' + val + '&tur=' + val2 + '&yil=' + val3 + '&ay=' + val4;
            });
            $('#ddlAy').change(function () {
                var val = $("#ddlTemsilciler option:selected").val();
                var val2 = $("#ddlTurler option:selected").val();
                var val3 = $("#ddlYil option:selected").val();
                var val4 = $("#ddlAy option:selected").val();
                window.location.href = 'resimler.aspx?slsref=' + val + '&tur=' + val2 + '&yil=' + val3 + '&ay=' + val4;
            });
        </script>
        <uc1:ucAlt ID="ucAlt1" runat="server" />
        <div style="height: 600px; background-color: #EFEEEA"></div>
    </form>
</body>
</html>

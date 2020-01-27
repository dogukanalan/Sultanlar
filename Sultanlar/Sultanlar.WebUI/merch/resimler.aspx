<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="resimler.aspx.cs" Inherits="Sultanlar.WebUI.merch.resimler" %>

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
    <link rel="stylesheet" type="text/css" href="../musteri/js/tipTip.css" />
    <link rel="stylesheet" href="https://code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script type="text/javascript" src="https://code.jquery.com/ui/1.12.1/jquery-ui.min.js"></script>
    <script type="text/javascript" src="JScript.js"></script>
    <script type="text/javascript" src="../musteri/js/jquery.tipTip.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
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
                                htmlText += '<table cellpadding="5" cellspacing="0" style="width: 98%"><tr style="color: Red"><td style="width: 35%; text-align: center; border-bottom: 1px solid Gray">Nokta</td><td style="width: 20%; text-align: center; border-bottom: 1px solid Gray">Tür</td><td style="width: 20%; text-align: center; border-bottom: 1px solid Gray">Tarih</td><td style="width: 25%; text-align: center; border-bottom: 1px solid Gray">Resim</td></tr></table>';

                            for (var key1 in data) {
                                for (var key in data[key1]) {
                                    sonid = data[key1][key].ID;
                                    htmlText += '<table cellpadding="5" cellspacing="0" style="width: 98%">';
                                    htmlText += '<tr><td style="width: 35%;" valign="middle"><span class="hotspotCizgisiz" onclick="AndroidToast(\'' + data[key1][key].AdSoyad + '\')" title="' + data[key1][key].AdSoyad + '<br><br>' + data[key1][key].SUBE + '">' + (data[key1][key].SUBE.length > 20 ? data[key1][key].SUBE.substring(0, 20) + "..." : data[key1][key].SUBE) + '</span></td><td style="width: 20%;" valign="middle"><span class="hotspotCizgisiz" onclick="AndroidToast(\'' + data[key1][key].strAciklama + '\')" title="' + data[key1][key].strAciklama + '">' + data[key1][key].strTur + '</span></td><td style="width: 20%; font-size: 12px" valign="middle">' + data[key1][key].dtTarih + '</td><td style="width: 25%;"><a href="../musteri/resim2.aspx?str=musres-' + data[key1][key].ID + '"><img src="../musteri/resim.aspx?musresK=' + data[key1][key].ID + '" alt="' + data[key1][key].strAciklama + '" style="height: 60px; max-width: 45px" /></a></td></tr>';
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
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            alert(XMLHttpRequest.responseText);
                        }
                    });

                return veriyok;
            }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="login-page">
            <div class="form">
                <uc2:ucUst ID="ucUst" runat="server" />
                <div runat="server" id="divTemsilciler">
                <asp:DropDownList runat="server" ID="ddlTemsilciler" Height="25px" ForeColor="#006699" 
                    Width="100%" style="padding: 3px 3px 3px 3px;border:1px solid #CCCCCC;background:#ededed;"></asp:DropDownList>
                </div>
                <br />
                <asp:DropDownList runat="server" ID="ddlTurler" AutoPostBack="false" ForeColor="#006699" 
                    style="padding: 3px 3px 3px 3px;border:1px solid #CCCCCC;background:#ededed; font-size: 16px"></asp:DropDownList>
                <asp:DropDownList runat="server" ID="ddlYil" AutoPostBack="false" ForeColor="#006699" 
                    style="padding: 3px 3px 3px 3px;border:1px solid #CCCCCC;background:#ededed; font-size: 16px">
                    <asp:ListItem Text="Tümü" Value="0"></asp:ListItem>
                    <asp:ListItem Text="2018" Value="2018"></asp:ListItem>
                    <asp:ListItem Text="2019" Value="2019"></asp:ListItem>
                </asp:DropDownList>
                <asp:DropDownList runat="server" ID="ddlAy" AutoPostBack="false" ForeColor="#006699" 
                    style="padding: 3px 3px 3px 3px;border:1px solid #CCCCCC;background:#ededed; font-size: 16px">
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
                <br /><br />
                <%--<asp:Label runat="server" ID="lblYok" Visible="false" Text="<br />Seçilen personele ait resim bulunmamaktadır.<br />" Font-Italic="true"></asp:Label>--%>
                <div id="divData"></div>
                <div id="divLoading" style="display: none; text-align: center">
                    <br /><i>yükleniyor...</i><br /><br />
                </div>
                <a id="aDaha" class='button' href='javascript:VeriGetir(false);' style="display: block">Daha fazla görüntüle</a>
                <span id="spanDaha" class="fs-14" style="display: none; text-align: center;"><br /><i>Bulunamadı...</i></span>
                <input type="hidden" id="sonId" value="1000000" />
                <input type="hidden" id="rutId" value="0" />
                <uc3:ucAlt ID="ucAlt1" runat="server" />
            </div>
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
        <uc1:ucProgress ID="ucProgress1" runat="server" />
    </form>
</body>
</html>

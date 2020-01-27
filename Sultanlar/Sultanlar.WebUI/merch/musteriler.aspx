<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="musteriler.aspx.cs" Inherits="Sultanlar.WebUI.merch.musteriler" %>

<%@ Register Src="ucProgress.ascx" TagName="ucProgress" TagPrefix="uc1" %>
<%@ Register Src="ucUst.ascx" TagName="ucUst" TagPrefix="uc2" %>
<%@ Register Src="ucAlt.ascx" TagName="ucAlt" TagPrefix="uc3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="cache-control" content="no-cache" />
    <meta name="viewport" content="width=device-width,initial-scale=1">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="StyleSheet.css" />
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script type="text/javascript" src="JScript.js"></script>
    <script type="text/javascript" src="coord.js"></script>
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
            if (getParameterByName("subearama")) {
                subearama = getParameterByName("subearama");
                $('#inputSube').val(getParameterByName("subearama"));
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
                    url: 'musteriler.aspx/MusterilerGetir',
                    data: '{ sonid: "' + $('#sonId').val() + '", slsref: "' + slsmanref + '", sube: "' + subearama + '" }',
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'json',
                    success: function (data) {
                        var htmlText = '<table>';

                        for (var key1 in data) {
                            for (var key in data[key1]) {
                                sonid++;

                                htmlText += '<tr><td style="width: 37%; height: 40px"><span class="kucukbilgiGoster" style="font-size: 12px" onclick="AndroidToast($(this).prop(\'title\'))" title="' + data[key1][key].SEHIR + '">'; /* title="' + data[key1][key].MUSTERI + '</b><br><br><i>İlgili:</i> ' + data[key1][key].ILGILI + '<br><i>Telefon:</i> ' + data[key1][key].TEL1 + '<br><i>Cep Tel.:</i> ' + data[key1][key].CEP1 + '<br><i>Eposta:</i> ' + data[key1][key].EMAIL1 + '<br><br>' + data[key1][key].ADRES + '<br>' + data[key1][key].SEHIR + '/' + data[key1][key].SEMT + '"*/
                                htmlText += data[key1][key].MUSTERI + '</span>';
                                htmlText += '<td style="width: 37%; height: 40px"><span class="kucukbilgiGoster" style="font-size: 12px" onclick="AndroidToast($(this).prop(\'title\'))" title="' + data[key1][key].SEHIR + '">'; /* title="' + data[key1][key].SUBE + '</b><br><br><i>İlgili:</i> ' + data[key1][key].ILGILI + '<br><i>Telefon:</i> ' + data[key1][key].TEL1 + '<br><i>Cep Tel.:</i> ' + data[key1][key].CEP1 + '<br><i>Eposta:</i> ' + data[key1][key].EMAIL1 + '<br><br>' + data[key1][key].ADRES + '<br>' + data[key1][key].SEHIR + '/' + data[key1][key].SEMT + '"*/
                                htmlText += data[key1][key].SUBE + '</span>';
                                if (data[key1][key].MTIP == 1 && $('#sdemi').val() == "0")
                                    htmlText += '</td><td style="width: 26%; font-size: 10px"><table><tr><td><a class="button" href="ziyaret1.aspx?mtip=' + data[key1][key].MTIP + '&smref=' + data[key1][key].SMREF + '">Ziy</a></td><td><a class="button" href="siparis.aspx?smref=' + data[key1][key].SMREF + '">Sip</a></td></tr></table></td></tr>';
                                else
                                    htmlText += '</td><td style="width: 26%"><a class="button" href="ziyaret1.aspx?mtip=' + data[key1][key].MTIP + '&smref=' + data[key1][key].SMREF + '">Ziyaret</a></td></tr>';

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
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        alert(XMLHttpRequest.responseText);
                    }
                }
            );
        }

        $(document).ready(function () {
            //if (getParameterByName('slsref') == null) {
            //    document.getElementById('ddlTemsilciler').value = 0;
            //}
            //else {
            //    document.getElementById('ddlTemsilciler').value = getParameterByName('slsref');
            //}
            //document.getElementById('ddlTemsilciler').value = 0;
            //$('#slsref').val(0);
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
        //    window.location.href = 'musteriler.aspx?slsref=' + val + '&sube=' + val2;
        //}

        function Konus() {
            Konustur(window.location.href, 'subearama');
        }

        function musAra() {
            if (getParameterByName("slsref")) {
                window.location.href = 'musteriler.aspx?slsref=' + getParameterByName("slsref") + '&subearama=' + $('#inputSube').val();
            } else {
                window.location.href = 'musteriler.aspx?subearama=' + $('#inputSube').val();
                }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="login-page">
            <div class="form">
                <uc2:ucUst ID="ucUst" runat="server" />
                <%--<a class="button" href="menu.aspx" onclick="Goster()">Geri Dön</a>--%>
                <div runat="server" id="divTemsilciler">
                    <asp:DropDownList runat="server" ID="ddlTemsilciler" Height="25px" ForeColor="#006699"
                        Width="100%" Style="padding: 3px 3px 3px 3px; border: 1px solid #CCCCCC; background: #ededed;">
                    </asp:DropDownList>
                </div>
                <br />
                <%--<asp:TextBox runat="server" ID="txtFarkliZiyaretSube" Width="70%" placeholder="Buradan arayabilirsiniz..." onkeypress="return clickButton(event,'aAra')"></asp:TextBox>--%>
                <a class="button1" href="javascript:Konus()" style="float: left; padding: 9px"><img style="width: 28px" src="microphone.png" /></a>
                <input type="text" id="inputSube" style="width: 55%" placeholder="Buradan arayabilirsiniz..." autocomplete="off" onkeydown="return clickButton(event,'aAra')" />
                <a class="button1" id="aAra" href="javascript:musAra()">&nbsp;&nbsp;&nbsp;Ara&nbsp;&nbsp;&nbsp;</a>
                <asp:Repeater runat="server" ID="rpZiyaretCariler">
                    <HeaderTemplate>
                        <table cellpadding="4" cellspacing="0">
                            <tr style="color: #D00000">
                                <td style="border-bottom: 1px solid #CCCCCC; height: 20px; width: 40%">Ana Cari</td>
                                <td style="border-bottom: 1px solid #CCCCCC; height: 20px; width: 40%">Şube</td>
                                <td style="border-bottom: 1px solid #CCCCCC; height: 20px; width: 20%">İşlem</td>
                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td style="width: 40%">

                                <span class="kucukbilgiGoster" title="<b><%#Eval("MUSTERI").ToString()%></b><br><br><i>İlgili:</i> <%#Eval("ILGILI")%><br><i>Telefon:</i> <%#Eval("[TEL-1]")%><br><i>Cep Tel.:</i> <%#Eval("[CEP-1]")%><br><i>Eposta:</i> <%#Eval("[EMAIL-1]")%><br><br><%#Eval("ADRES").ToString()%><br><%#Eval("SEHIR")%>/<%#Eval("SEMT")%>">
                                    <%#Eval("MUSTERI").ToString().Length > 20 ? Eval("MUSTERI").ToString().Substring(0, 20).Trim() + "..." : Eval("MUSTERI")%>
                                </span>

                            </td>

                            <td style="width: 40%">

                                <span class="kucukbilgiGoster" title="<b><%#Eval("SUBE").ToString()%></b><br><br><i>İlgili:</i> <%#Eval("ILGILI")%><br><i>Telefon:</i> <%#Eval("[TEL-1]")%><br><i>Cep Tel.:</i> <%#Eval("[CEP-1]")%><br><i>Eposta:</i> <%#Eval("[EMAIL-1]")%><br><br><%#Eval("ADRES").ToString()%><br><%#Eval("SEHIR")%>/<%#Eval("SEMT")%>">
                                    <%#Eval("SUBE").ToString().Length > 20 ? Eval("SUBE").ToString().Substring(0, 20).Trim() + "..." : Eval("SUBE")%>
                                </span>

                            </td>

                            <td style="width: 20%">
                                <input runat="server" type="hidden" id="SMREF" value='<%#Eval("SMREF") %>' /><input runat="server" type="hidden" id="MTIP" value='<%#Eval("MTIP") %>' /><asp:LinkButton class="button" ID="lbFarkliZiyaretBaslat" runat="server" OnClientClick="Goster()" OnClick="lbFarkliZiyaretBaslat_Click">Başlat</asp:LinkButton></td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate></table></FooterTemplate>
                </asp:Repeater>
                <%--<div><table cellpadding="4" cellspacing="0"><tr style="color: #D00000"><td style="border-bottom: 1px solid #CCCCCC; height: 20px; width: 40%">Ana Cari</td><td style="border-bottom: 1px solid #CCCCCC; height: 20px; width: 40%">Şube</td><td style="border-bottom: 1px solid #CCCCCC; height: 20px; width: 20%">Ziyaret</td></tr></table></div>--%>
                <div id="divData"></div>
                <span id="spanYukleniyor" style="font-style: italic; display: none"><br />Yükleniyor...</span>
                <input type="hidden" id="sonId" value="0" />
                <input type="hidden" runat="server" id="slsref" value="" clientidmode="Static" />
                <input type="hidden" runat="server" id="sdemi" value="" clientidmode="Static" />
                <script type="text/javascript" src="https://maps.googleapis.com/maps/api/js?key=AIzaSyDXm_Z4J-I9jrTO72lGvx1jRzTWsP6qi7Q&libraries=geometry"></script>
                <script type="text/javascript">
                    $('#ddlTemsilciler').change(function () {
                        //$('#slsref').val($('#ddlTemsilciler').val());
                        //VeriGetir(true);
                        window.location.href = "musteriler.aspx?slsref=" + $('#ddlTemsilciler').val();
                    });
                </script>
                <uc3:ucAlt ID="ucAlt1" runat="server" />
                <uc1:ucProgress ID="ucProgress1" runat="server" />
            </div>
        </div>
    </form>
</body>
</html>

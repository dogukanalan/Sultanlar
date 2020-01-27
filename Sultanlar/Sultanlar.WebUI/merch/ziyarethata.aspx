<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ziyarethata.aspx.cs" Inherits="Sultanlar.WebUI.merch.ziyarethata" %>

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
    <link rel="stylesheet" href="https://code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script type="text/javascript" src="https://code.jquery.com/ui/1.12.1/jquery-ui.min.js"></script>
    <script type="text/javascript" src="JScript.js"></script>
    <script type="text/javascript" src="coord.js"></script>
    <script type="text/javascript">
        function lbZiyaretSonlandirClick() {
            Goster();
            var oncekinokta = "";
            if (document.getElementById("txtCoords1onceki").value != "0,0") {
                oncekinokta = document.getElementById("txtCoords1onceki").value;
            }
            else {
                oncekinokta = readCookie("sulZiyBaslangic");
            }
            
            var p11 = parseFloat(document.getElementById("txtCoords1").value.substring(0, document.getElementById("txtCoords1").value.indexOf(",")));
            var p12 = parseFloat(document.getElementById("txtCoords1").value.substring(document.getElementById("txtCoords1").value.indexOf(",") + 1));
            var p21 = parseFloat(oncekinokta.substring(0, oncekinokta.indexOf(",")));
            var p22 = parseFloat(oncekinokta.substring(oncekinokta.indexOf(",") + 1));
            var p1 = new google.maps.LatLng(p11, p12);
            var p2 = new google.maps.LatLng(p21, p22);
            var mesafe = (google.maps.geometry.spherical.computeDistanceBetween(p1, p2)).toFixed(0).toString();
            if (isNaN(mesafe)) {
                mesafe = "-1";
            }
            document.getElementById("txtCoordsFark").value = mesafe;
            //eraseCookie("sulZiyBaslangic");
        }
    </script>
    <script type="text/javascript">
        $(function () {
            $('#rblZiyaretSonlandirmaSebepleri').buttonset().find('label').width(260);
        });
    </script>
</head>
<body onload="KoordinatBaslat()">
    <form id="form1" runat="server">
        <div class="login-page">
            <div class="form">
                <uc2:ucUst ID="ucUst" runat="server" />
                <%--<a class="button" href="menu.aspx" onclick="Goster()">Geri Dön</a>--%>
                <br />
                <table style="width: 100%; height: 100%; background-color: #ffffff; font-family: Tahoma;
                    border: 1px solid #D1D1D1; border-radius: 5px; padding: 5px;">
                <tr>
                <td align="center" valign="middle" style="padding-top: 15px; padding-bottom: 15px">
                    <span style="color: #C00000;">Son Ziyaret</span>
                    <br /><br />
                    <asp:Label runat="server" ID="lblSonZiyaretMusteri"></asp:Label>
                    <br /><br />
                    <asp:LinkButton class="button" ID="lbSonZiyaretSonlandir" Text="Son ziyaretiniz sonlandırılmamış. Ziyareti sonlandırmadan başka bir ziyaret başlatamazsınız. Ziyareti sonlandırmak için tıklayınız." runat="server" Visible="false" OnClientClick="lbZiyaretSonlandirClick()" OnClick="lbSonZiyaretSonlandir_Click" />
                </td>
                </tr>
                </table>
                <asp:TextBox runat="server" ID="txtCoords1onceki" Text="0,0" style="display: none"></asp:TextBox>
                <asp:TextBox runat="server" ID="txtCoords1" Text="0,0" style="display: none"></asp:TextBox>
                <asp:TextBox runat="server" ID="txtCoords" Text="Konum Bekleniyor..." onkeypress="return yazma(event)" style="width: 98%"></asp:TextBox>
                <asp:TextBox runat="server" ID="txtCoordsFark" Text="0" style="display: none"></asp:TextBox>
                <uc3:ucAlt ID="ucAlt1" runat="server" />
                <uc1:ucProgress ID="ucProgress1" runat="server" />

                <div style="position: absolute; width: 95%; z-index: 10;
                top: 20px" runat="server" id="divZiyaretSonlandirmaSebep" visible="false" class="suruklenebilir">
                <div style="position: fixed; width: 100%; height: 100%; z-index: -1; left: 0; top: 0;
                    filter: alpha(opacity=40); -moz-opacity: .40; opacity: .40; background-color: #000000"></div>
                <table cellpadding="5" style="width: 100%; height: 100%; background-color: #ffffff; font-family: Tahoma; font-size: 12px;
                    border: 1px solid #D1D1D1; border-radius: 5px; padding: 5px;">
                <tr>
                <td align="center" valign="middle">
                    <strong style="color: #C00000; font-size: 20px;">Ziyaret Sonlandırma Sebebi Belirleyiniz</strong>
                </td>
                </tr>
                <tr>
                <td align="center" valign="middle" style="font-size: 16px;">
                    <asp:RadioButtonList runat="server" ID="rblZiyaretSonlandirmaSebepleri" RepeatLayout="Table"></asp:RadioButtonList>
                </td>
                </tr>
                <tr>
                <td align="center" valign="middle" style="font-size: 10px;">
                    <asp:TextBox runat="server" ID="txtZiyaretSonlandirmaSebepAciklama" Width="98%"
                            ForeColor="#006699" BorderColor="#A3B5C9" style="padding: 3px 3px 3px 3px;"
                            BorderStyle="Solid" BorderWidth="1px" placeholder="Açıklama..." autocomplete="off"></asp:TextBox>
                </td>
                </tr>
                <tr>
                <td align="center" valign="middle">
                <span id="spanBekleniyor" class="button">Konumunuz bulunmadan ziyaret başlatamazsınız.</span>
                    <asp:LinkButton class="button" runat="server" ID="lbZiyaretSonlandirmaSebep" OnClick="lbZiyaretSonlandirmaSebep_Click" style="display: none">Ziyareti Sonlandır</asp:LinkButton>
                </td>
                </tr>
                </table>
            </div>
            </div>
            <script type="text/javascript" src="https://maps.googleapis.com/maps/api/js?key=AIzaSyDXm_Z4J-I9jrTO72lGvx1jRzTWsP6qi7Q&libraries=geometry"></script>
        </div>
    </form>
</body>
</html>

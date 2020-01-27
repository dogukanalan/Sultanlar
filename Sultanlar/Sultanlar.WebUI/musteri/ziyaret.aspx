<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ziyaret.aspx.cs" Inherits="Sultanlar.WebUI.musteri.ziyaret" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sultanlar : Ziyaret</title>
    <script type="text/javascript" src="js/jquery-1.2.6.pack.js"></script>
    <script type="text/javascript" src="js/jquery-1.8.3.js"></script>
    <script type="text/javascript">

        function KoordinatBaslat() {
            if (navigator.geolocation) {
                navigator.geolocation.getCurrentPosition(displayPosition, displayError, { maximumAge: 60000, timeout: 5000, enableHighAccuracy: true });
            } else {
                document.getElementById('txtCoords1').value = '0,0';
                document.getElementById('txtCoords').value = 'Tarayıcı konuma erişmeyi desteklemiyor.';
            }
        }

        function displayPosition(position) {
            positionSuccess(position);
        }

        function positionSuccess(position) {
            var coords = position.coords || position.coordinate || position;
            var latLng = new google.maps.LatLng(coords.latitude, coords.longitude);
            document.getElementById('txtCoords1').value = coords.latitude + ',' + coords.longitude;
            (new google.maps.Geocoder()).geocode({ latLng: latLng }, function (resp) {
                document.getElementById('txtCoords').value = document.getElementById('txtCoords1').value; //resp[0].formatted_address;
            });
        }

        function displayError(positionError) {
            switch (positionError.code) {
                case positionError.PERMISSION_DENIED:
                    document.getElementById('txtCoords1').value = "0,0" //User denied the request for Geolocation.
                    document.getElementById('txtCoords').value = "-Konuma Erişilemedi-(1)" //User denied the request for Geolocation.
                    break;
                case positionError.POSITION_UNAVAILABLE:
                    document.getElementById('txtCoords1').value = "0,0" //Location information is unavailable.
                    document.getElementById('txtCoords').value = "-Konuma Erişilemedi-(2)" //Location information is unavailable.
                    break;
                case positionError.TIMEOUT:
                    document.getElementById('txtCoords1').value = "0,0" //The request to get user location timed out.
                    document.getElementById('txtCoords').value = "-Konuma Erişilemedi-(3)" //The request to get user location timed out.
                    break;
                case positionError.UNKNOWN_ERROR:
                    document.getElementById('txtCoords1').value = "0,0" //The request to get user location timed out.
                    document.getElementById('txtCoords').value = "-Konuma Erişilemedi-(3)" //The request to get user location timed out.
                    break;
            }
        }

        function lbZiyaretSonlandirClick() {
            var p11 = parseFloat(document.getElementById("txtCoords1").value.substring(0, document.getElementById("txtCoords1").value.indexOf(",")));
            var p12 = parseFloat(document.getElementById("txtCoords1").value.substring(document.getElementById("txtCoords1").value.indexOf(",") + 1));
            var p21 = parseFloat(readCookie("sulZiyBaslangic").substring(0, readCookie("sulZiyBaslangic").indexOf(",")));
            var p22 = parseFloat(readCookie("sulZiyBaslangic").substring(readCookie("sulZiyBaslangic").indexOf(",") + 1));
            var p1 = new google.maps.LatLng(p11, p12);
            var p2 = new google.maps.LatLng(p21, p22);
            var mesafe = (google.maps.geometry.spherical.computeDistanceBetween(p1, p2)).toFixed(0).toString();
            if (isNaN(mesafe)) {
                mesafe = "-1";
            }
            document.getElementById("txtCoordsFark").value = mesafe;
            eraseCookie("sulZiyBaslangic");
        }
        
    </script>
</head>
<body onload="KoordinatBaslat()">
    <form id="form1" runat="server">

        <div style="position: absolute; width: 400px; height: 520px; z-index: 3; left: 300px;
            top: 20px" runat="server" id="divZiyaretSonlandirmaSebep" visible="false">
            <div style="position: fixed; width: 100%; height: 100%; z-index: -1; left: 0; top: 0;
            filter: alpha(opacity=40); -moz-opacity: .40; opacity: .40; background-color: #000000"></div>
            <table cellpadding="5" style="width: 100%; height: 100%; background-color: #ffffff; font-family: Tahoma; font-size: 12px;
                border: 1px solid #D1D1D1; border-radius: 5px; padding: 5px;">
            <tr>
            <td align="center" valign="middle">
                <strong style="color: #C00000">Ziyaret Sonlandırma Sebebi Belirleyiniz</strong>
            </td>
            </tr>
            <tr>
            <td align="center" valign="middle" style="font-size: 10px;">
                <asp:RadioButtonList runat="server" ID="rblZiyaretSonlandirmaSebepleri"></asp:RadioButtonList>
            </td>
            </tr>
            <tr>
            <td align="center" valign="middle" style="font-size: 10px;">
                Açıklama: <asp:TextBox runat="server" ID="txtZiyaretSonlandirmaSebepAciklama" Width="300px"
                                    ForeColor="#006699" BorderColor="#A3B5C9" style="padding: 3px 3px 3px 3px;"
                                    BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
            </td>
            </tr>
            <tr>
            <td align="center" valign="middle">
                <asp:LinkButton runat="server" ID="lbZiyaretSonlandirmaSebep" OnClick="lbZiyaretSonlandirmaSebep_Click">Ziyareti Sonlandır</asp:LinkButton>
            </td>
            </tr>
            </table>
        </div>

        <div style="width: 450px; height: 150px; font-family: Verdana; font-size: 10px;" runat="server" id="divZiyaret" visible="true">
            <div style="font-size: 18px; padding: 10px 10px 10px 10px; vertical-align: middle">Ziyaret Ayrıntıları</div>
            <asp:Label  runat="server" Width="20px"></asp:Label>
            <span style="color: #D00000">Ziyaret Başlatılan Şube:</span> 
            <asp:Label runat="server" ID="lblZiyaretSubesi"></asp:Label>
            <br />
            <asp:Label runat="server" Width="20px"></asp:Label>
            <span style="color: #D00000">Ziyaret Başlama Zamanı:</span> 
            <asp:Label runat="server" ID="lblZiyaretBaslangic"></asp:Label>
            <br /><br />
            <asp:LinkButton runat="server" ID="lbZiyaretIptal" OnClick="lbZiyaretIptal_Click" style="color: Red; font-size: 12px">Ziyareti İptal Et</asp:LinkButton>
            <asp:Label runat="server" Width="100px"></asp:Label>
            <asp:LinkButton runat="server" ID="lbZiyaretSonlandirUst" style="color: Green; font-size: 12px" OnClientClick="lbZiyaretSonlandirClick()" OnClick="lbZiyaretSonlandirUst_Click">Ziyaret Sonlandır</asp:LinkButton>
        </div>

        <script type="text/javascript" src="https://maps.googleapis.com/maps/api/js?key=AIzaSyDXm_Z4J-I9jrTO72lGvx1jRzTWsP6qi7Q&libraries=geometry"></script>

        <asp:TextBox runat="server" ID="txtCoords1" Text="0,0" style="visibility: hidden"></asp:TextBox>
        <asp:TextBox runat="server" ID="txtCoords" Text="-Konum Alınamadı-" style="visibility: hidden"></asp:TextBox>
        <asp:TextBox runat="server" ID="txtCoordsFark" Text="0" style="visibility: hidden"></asp:TextBox>

    </form>
</body>
</html>

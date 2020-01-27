<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="defaultsd.aspx.cs" Inherits="Sultanlar.WebUI.musteri.defaultsd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sultanlar Pazarlama A.Ş.</title>
    <script type="text/javascript" src="js/jquery-1.2.6.pack.js"></script>
    <script type="text/javascript" src="js/jquery-1.8.3.js"></script>
    <script type="text/javascript" src="js/jquery-ui.js"></script>
    <link rel="stylesheet" href="js/jquery-ui.css" />

    <script type="text/javascript">
        function lbZiyaretSonlandirClick() {
            var p11 = parseFloat(document.getElementById("txtCoords1").value.substring(0, document.getElementById("txtCoords1").value.indexOf(",")));
            var p12 = parseFloat(document.getElementById("txtCoords1").value.substring(document.getElementById("txtCoords1").value.indexOf(",") + 1));
            var p21 = parseFloat(readCookie("sulSdZiyBaslangic").substring(0, readCookie("sulSdZiyBaslangic").indexOf(",")));
            var p22 = parseFloat(readCookie("sulSdZiyBaslangic").substring(readCookie("sulSdZiyBaslangic").indexOf(",") + 1));
            var p1 = new google.maps.LatLng(p11, p12);
            var p2 = new google.maps.LatLng(p21, p22);
            var mesafe = (google.maps.geometry.spherical.computeDistanceBetween(p1, p2)).toFixed(0).toString();
            if (isNaN(mesafe)) {
                mesafe = "0";
            }
            document.getElementById("txtCoordsFark").value = mesafe;
            eraseCookie("sulSdZiyBaslangic");
        }

        function createCookie(name, value, days) {
            var expires = "";
            if (days) {
                var date = new Date();
                date.setTime(date.getTime() + (days * 24 * 60 * 60 * 1000));
                expires = "; expires=" + date.toUTCString();
            }
            document.cookie = name + "=" + value + expires + "; path=/";
        }

        function readCookie(name) {
            var nameEQ = name + "=";
            var ca = document.cookie.split(';');
            for (var i = 0; i < ca.length; i++) {
                var c = ca[i];
                while (c.charAt(0) == ' ') c = c.substring(1, c.length);
                if (c.indexOf(nameEQ) == 0) return c.substring(nameEQ.length, c.length);
            }
            return null;
        }

        function eraseCookie(name) {
            createCookie(name, "", -1);
        }
    </script>

    <script type="text/javascript" src="js/scripts.js"></script>
    <script type="text/javascript" src="js/jquery.tipTip.js"></script>
    <script type="text/javascript" src="js/jquery.tipTip.minified.js"></script>
    <link rel="stylesheet" type="text/css" href="js/tipTip.css" />

    <link rel="stylesheet" type="text/css" href="StyleSheet.css" />
    
    <script type="text/javascript" src="https://maps.google.com/maps/api/js?sensor=true"></script>
    <script type="text/javascript">
        var gl;
        var map;

        function initialise() {
            var latlng = new google.maps.LatLng(-25.363882, 131.044922);
            var myOptions = {
                zoom: 4,
                center: latlng,
                mapTypeId: google.maps.MapTypeId.TERRAIN,
                disableDefaultUI: true
            }
            map = new google.maps.Map(document.getElementById("map_canvas"), myOptions);
        }

        function displayPosition(position) {
//            document.getElementById('txtCoords1').value = position.coords.latitude + "," + position.coords.longitude; document.getElementById('txtCoords').value = "<table border='1' cellpadding='1' cellspacing='0'><tr><th>Timestamp</th><td>" + position.timestamp +
//            "<tr><th>Latitude (WGS84)</th><td>" + position.coords.latitude + " deg</td></tr>" +
//            "<tr><th>Longitude (WGS84)</th><td>" + position.coords.longitude + " deg</td></tr></table>";

            positionSuccess(position);
        }

        function displayError(positionError) {

            switch (positionError.code) {
                case positionError.PERMISSION_DENIED:
                    document.getElementById('txtCoords1').value = "-Konuma Erişilemedi-(1)" //User denied the request for Geolocation.
                    document.getElementById('txtCoords').value = "-Konuma Erişilemedi-(1)" //User denied the request for Geolocation.
                    break;
                case positionError.POSITION_UNAVAILABLE:
                    document.getElementById('txtCoords1').value = "-Konuma Erişilemedi-(2)" //Location information is unavailable.
                    document.getElementById('txtCoords').value = "-Konuma Erişilemedi-(2)" //Location information is unavailable.
                    break;
                case positionError.TIMEOUT:
                    document.getElementById('txtCoords1').value = "-Konuma Erişilemedi-(3)" //The request to get user location timed out.
                    document.getElementById('txtCoords').value = "-Konuma Erişilemedi-(3)" //The request to get user location timed out.
                    break;
                case positionError.UNKNOWN_ERROR:
                    document.getElementById('txtCoords1').value = "-Konuma Erişilemedi-(3)" //The request to get user location timed out.
                    document.getElementById('txtCoords').value = "-Konuma Erişilemedi-(3)" //The request to get user location timed out.
                    break;
            }

            //writeCookie('Coords', document.getElementById('infoCoords').innerHTML, 30);
        }

        function KoordinatBaslat() {
//            initialise();
//            try {
//                if (typeof navigator.geolocation === 'undefined') {
//                    gl = google.gears.factory.create('beta.geolocation');
//                } else {
//                    gl = navigator.geolocation;
//                }
//            } catch (e) { }

            if (navigator.geolocation) {
                navigator.geolocation.getCurrentPosition(displayPosition, displayError, { maximumAge: 60000, timeout: 5000, enableHighAccuracy: true });
            } else {
                document.getElementById('txtCoords1').value = 'Tarayıcı konuma erişmeyi desteklemiyor.';
                document.getElementById('txtCoords').value = 'Tarayıcı konuma erişmeyi desteklemiyor.';
                //writeCookie('Coords', 'Tarayici konuma erismeyi desteklemiyor.', 30);
            }
        }





        function positionSuccess(position) {
            // Centre the map on the new location
            var coords = position.coords || position.coordinate || position;
            var latLng = new google.maps.LatLng(coords.latitude, coords.longitude);
//            map.setCenter(latLng);
//            map.setZoom(12);
//            var marker = new google.maps.Marker({
//                map: map,
//                position: latLng,
//                title: 'Burada!'
//            });
            document.getElementById('txtCoords1').value = coords.latitude + ',' + coords.longitude;
            document.getElementById('txtCoords').value = 'Aranıyor: <b>' +
            coords.latitude + ', ' + coords.longitude + '</b>...';

            // And reverse geocode.
            (new google.maps.Geocoder()).geocode({ latLng: latLng }, function (resp) {
//                var place = "Buralarda biryerde!";
//                if (resp[0]) {
//                    var bits = [];
//                    for (var i = 0, I = resp[0].address_components.length; i < I; ++i) {
//                        var component = resp[0].address_components[i];
//                        if (contains(component.types, 'political')) {
//                            bits.push(component.long_name);
//                        }
//                    }
//                    if (bits.length) {
//                        place = bits.join(' > ');
//                    }
//                    marker.setTitle(resp[0].formatted_address);
//                }
//                document.getElementById('txtCoords').value = place.toUpperCase().replace('Ö', 'O').replace('Ç', 'C').replace('Ş', 'S').replace('İ', 'I').replace('Ğ', 'G').replace('Ü', 'U');

                document.getElementById('txtCoords').value = resp[0].formatted_address;
                //writeCookie('Coords', place.toUpperCase().replace('Ö', 'O').replace('Ç', 'C').replace('Ş', 'S').replace('İ', 'I').replace('Ğ', 'G').replace('Ü', 'U'), 30);
            });
        }

        function contains(array, item) {
            for (var i = 0, I = array.length; i < I; ++i) {
                if (array[i] == item) return true;
            }
            return false;
        }
  </script>

</head>
<body style="font-size: 9px; font-family: Verdana; background-color: #EFEEEA;" onload="KoordinatBaslat()">
    <form id="form1" runat="server">

        <div id="infoCoords" style="display: none" runat="server">Yeriniz belirleniyor...</div>
        <div id="map_canvas" style="display: none"></div>

        <div style="position: absolute; width: 400px; height: 520px; z-index: 3; left: 150px;
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

        <div style="width: 450px; height: 150px; z-index: 1; left: 275px;
            top: 50px; font-family: Verdana; font-size: 10px;" runat="server" id="divZiyaret" visible="false">
            <div style="font-size: 18px; padding: 10px 10px 10px 10px; vertical-align: middle">Ziyaret Ayrıntıları</div>
            <asp:Label runat="server" Width="20px"></asp:Label>
            <span style="color: #D00000">Ziyaret Başlatılan Şube:</span> 
            <asp:Label runat="server" ID="lblZiyaretSubesi"></asp:Label>
            <br />
            <asp:Label runat="server" Width="20px"></asp:Label>
            <span style="color: #D00000">Ziyaret Başlama Zamanı:</span> 
            <asp:Label runat="server" ID="lblZiyaretBaslangic"></asp:Label>
            <br /><br />
            <asp:Label runat="server" Width="100px"></asp:Label>
            <asp:LinkButton runat="server" ID="lbZiyaretSonlandirUst" OnClientClick="lbZiyaretSonlandirClick()" OnClick="lbZiyaretSonlandirUst_Click">Ziyaret Sonlandır</asp:LinkButton>
        </div>

        <asp:LinkButton runat="server" ID="lbGeri" Text="Bayi Listesine Geri Dön" Visible="false" OnClick="lbGeri_Click"></asp:LinkButton>
        <table><tr><td style="width: 700px; text-align: center"><asp:Label runat="server" ID="lblBayi"></asp:Label></td></tr></table>

        <asp:DataList ID="dlBayiler" runat="server">
            <HeaderTemplate><table cellpadding="4" cellspacing="0">
                <tr style="color: #D00000">
                    <td style="width: 80px; text-align: center; height: 20px; border-bottom: 1px solid #CCCCCC">Bayi Kod</td>
                    <td style="width: 300px; text-align: center; height: 20px; border-bottom: 1px solid #CCCCCC">Bayi Ünvan</td>
                    <td style="width: 50px; text-align: center; height: 20px; border-bottom: 1px solid #CCCCCC"">İşlem</td>
                </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr onmouseover="Satir(this,true)" onmouseout="Satir(this,false)">
                    <td style="width: 80px; text-align: center;">
                        <%#Convert.ToInt32(Eval("[GMREF]")) != 0 ? Eval("[GMREF]").ToString() : ""%>
                    </td>
                    <td style="width: 300px; text-align: left;">
                        <%#Eval("[MUSTERI]")%>
                    </td>
                    <td style="padding-left: 5px; text-align: center;">
                        <asp:LinkButton CommandArgument='<%#Eval("[GMREF]") %>' runat="server" OnClick="AltCariler_Click">Alt Cariler</asp:LinkButton>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate></table></FooterTemplate>
        </asp:DataList>

        <asp:DataList ID="dlAltCariler" runat="server" Visible="false">
            <HeaderTemplate><table cellpadding="4" cellspacing="0">
                <tr style="color: #D00000">
                    <td style="width: 30px;"></td>
                    <td style="width: 550px; text-align: center; height: 20px; border-bottom: 1px solid #CCCCCC">Alt Cari Ünvan</td>
                    <td style="width: 100px; text-align: center; height: 20px; border-bottom: 1px solid #CCCCCC"">İşlem</td>
                </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr onmouseover="Satir(this,true)" onmouseout="Satir(this,false)">
                    <td style="width: 30px; text-align: center;">
                        <%--<asp:ImageButton runat="server" CommandArgument='<%#Eval("[SEMT]").ToString()%>' Enabled='<%#Eval("[SEMT]").ToString() != "" && Eval("[SEMT]").ToString() != "-Konum Alınmadı" && Eval("[SEMT]").ToString() != "-Konuma Erişilemedi-(1)" && Eval("[SEMT]").ToString() != "-Konuma Erişilemedi-(2)" && Eval("[SEMT]").ToString() != "-Konuma Erişilemedi-(3)" && Eval("[SEMT]").ToString() != "Tarayıcı konuma erişmeyi desteklemiyor." && Eval("[SEMT]").ToString() != "-Konum Alınamadı-" %>' ImageUrl='<%#Eval("[SEMT]").ToString() == "" || Eval("[SEMT]").ToString() == "-Konum Alınmadı" || Eval("[SEMT]").ToString() == "-Konuma Erişilemedi-(1)" || Eval("[SEMT]").ToString() == "-Konuma Erişilemedi-(2)" || Eval("[SEMT]").ToString() == "-Konuma Erişilemedi-(3)" || Eval("[SEMT]").ToString() == "Tarayıcı konuma erişmeyi desteklemiyor." || Eval("[SEMT]").ToString() == "-Konum Alınamadı-" ? "img/kapali.png" : "img/checkmark.png" %>' OnClick="Map_Click" />--%>
                    </td>
                    <td style="width: 550px; text-align: left;">
                        <%#Eval("[SUBE]")%>
                    </td>
                    <td style="padding-left: 5px; text-align: center;">
                        <asp:LinkButton CommandArgument='<%#Eval("[SMREF]") %>' runat="server" OnClick="Konum_Click">Ziyaret Başlat</asp:LinkButton>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate></table></FooterTemplate>
        </asp:DataList>
        
        <input type="hidden" runat="server" id="inputBayiGibi" value="0" />
        <asp:TextBox runat="server" ID="txtCoords" Text="-Konum Alınamadı-" style="visibility: hidden"></asp:TextBox>
        <asp:TextBox runat="server" ID="txtCoords1" Text="-Konum Alınamadı-" style="visibility: hidden"></asp:TextBox>
        <asp:TextBox runat="server" ID="txtCoordsFark" Text="-Konum Alınamadı-" style="visibility: hidden"></asp:TextBox>
        <script type="text/javascript" src="https://maps.googleapis.com/maps/api/js?key=AIzaSyDXm_Z4J-I9jrTO72lGvx1jRzTWsP6qi7Q&libraries=geometry"></script>
    </form>
</body>
</html>

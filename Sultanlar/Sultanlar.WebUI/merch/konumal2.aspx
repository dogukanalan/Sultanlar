<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="konumal2.aspx.cs" Inherits="Sultanlar.WebUI.merch.konumal2" %>

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
    <script type="text/javascript" src="coord.js"></script>
    <script type="text/javascript">

        var map;
        var markers = [];

        function myMap() {
            var mapProp = {
                center: new google.maps.LatLng(39.477068, 35.135621),
                zoom: 8,
                styles: [{ "featureType": "landscape", "elementType": "geometry", "stylers": [{ "saturation": "-100"}] }, { "featureType": "poi", "elementType": "labels", "stylers": [{ "visibility": "on"}] }, { "featureType": "poi", "elementType": "labels.text.stroke", "stylers": [{ "visibility": "on"}] }, { "featureType": "road", "elementType": "labels.text", "stylers": [{ "color": "#545454"}] }, { "featureType": "road", "elementType": "labels.text.stroke", "stylers": [{ "visibility": "off"}] }, { "featureType": "road.highway", "elementType": "geometry.fill", "stylers": [{ "saturation": "-87" }, { "lightness": "-40" }, { "color": "#ffffff"}] }, { "featureType": "road.highway", "elementType": "geometry.stroke", "stylers": [{ "visibility": "off"}] }, { "featureType": "road.highway.controlled_access", "elementType": "geometry.fill", "stylers": [{ "color": "#f0f0f0" }, { "saturation": "-22" }, { "lightness": "-16"}] }, { "featureType": "road.highway.controlled_access", "elementType": "geometry.stroke", "stylers": [{ "visibility": "off"}] }, { "featureType": "road.highway.controlled_access", "elementType": "labels.icon", "stylers": [{ "visibility": "on"}] }, { "featureType": "road.arterial", "elementType": "geometry.stroke", "stylers": [{ "visibility": "off"}] }, { "featureType": "road.local", "elementType": "geometry.stroke", "stylers": [{ "visibility": "off"}] }, { "featureType": "transit", "elementType": "labels.icon", "stylers": [{ "visibility": "off"}] }, { "featureType": "water", "elementType": "geometry.fill", "stylers": [{ "saturation": "-52" }, { "hue": "#00e4ff" }, { "lightness": "-16"}]}]
            };
            map = new google.maps.Map(document.getElementById("googleMap"), mapProp);
            if (document.getElementById("inputLat").value != '') { // eğer noktanin konumu var ise onu cikarsin adresten aramasin
                var marker = new google.maps.Marker({ position: { lat: parseFloat(document.getElementById("inputLat").value), lng: parseFloat(document.getElementById("inputLng").value) }, title: "", label: "", draggable: true });
                geocodePosition(marker.getPosition());
                google.maps.event.addListener(marker, 'dragend', function (evt) {
                    document.getElementById("txtCoords1").value = evt.latLng.lat().toFixed(6) + ", " + evt.latLng.lng().toFixed(6);
                    geocodePosition(evt.latLng);
                    document.getElementById("btnKonumKaydet").style.visibility = 'visible';
                });
                google.maps.event.addListener(marker, 'click', function () {
                    map.setZoom(16);
                    map.setCenter(marker.getPosition());
                });
                marker.setMap(map);
                markers.push(marker);
                map.setCenter(marker.getPosition());
            }
            document.getElementById("btnKonumKaydet").style.visibility = 'hidden';
        }

        function geocodePosition(pos) {
            var geocoder = new google.maps.Geocoder();
            geocoder.geocode({
                latLng: pos
            }, function (responses) {
                if (responses && responses.length > 0) {
                    document.getElementById("txtCoords").value = responses[0].formatted_address;
                } else {
                    document.getElementById("txtCoords").value = "Adres bulunamadı.";
                }
            });
        }

        function SifirlaMarkers() {
            for (var i = 0; i < markers.length; i++) {
                markers[i].setMap(null);
            }
        }

        function Ara() {
            document.getElementById("btnKonumKaydet").style.visibility = 'visible';
            SifirlaMarkers();
            AdresGetir(document.getElementById("inputAdresArama").value);
        }

        function AdresGetir(adres) {
            var geocoder = new google.maps.Geocoder();
            var address = adres;
            if (geocoder) {
                geocoder.geocode({ 'address': address }, function (results, status) {
                    if (status == google.maps.GeocoderStatus.OK) {
                        if (status != google.maps.GeocoderStatus.ZERO_RESULTS) {
                            map.setCenter(results[0].geometry.location);
                            var infowindow = new google.maps.InfoWindow(
                                { content: '<b>' + address + '</b>',
                                    size: new google.maps.Size(150, 50)
                                });
                            var marker = new google.maps.Marker({
                                position: results[0].geometry.location,
                                map: map,
                                title: address,
                                draggable: true
                            });
                            google.maps.event.addListener(marker, 'click', function () {
                                infowindow.open(map, marker);
                                map.setZoom(16);
                                map.setCenter(marker.getPosition());
                            });
                            google.maps.event.addListener(marker, 'dragend', function (evt) {
                                document.getElementById("txtCoords1").value = evt.latLng.lat().toFixed(6) + ", " + evt.latLng.lng().toFixed(6);
                                geocodePosition(evt.latLng);
                            });

                            marker.setMap(map);
                            markers.push(marker);
                            map.setZoom(10);

                            document.getElementById("txtCoords1").value = results[0].geometry.location.lat().toFixed(6) + ", " + results[0].geometry.location.lng().toFixed(6);
                            document.getElementById("txtCoords").value = results[0].formatted_address;
                            document.getElementById("btnKonumKaydet").style.visibility = 'visible';
                        } else {
                            alert("Adres bulunamadı.");
                        }
                    } else {
                        map.setZoom(6);
                        alert("Adres bulunamadı.");
                        document.getElementById("btnKonumKaydet").style.visibility = 'hidden';
                    }
                });
            }
        }

        function KonumGonder() {
            $.ajax({
                type: 'POST',
                url: 'konumal.aspx/KonumSet',
                data: '{ smref: "' + $('#txtSMREF').val() + '", tip: "' + $('#txtTip').val() + '", Coords: "' + $('#txtCoords').val() + '", Coords1: "' + $('#txtCoords1').val() + '" }',
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                success: function (msg) {
                    alert("Konum alındı.");
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    alert(textStatus + "\n" + errorThrown + "\n" + XMLHttpRequest.responseText);
                }
            });
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="login-page">
            <div class="form">
                <uc2:ucUst ID="ucUst" runat="server" />
                <asp:TextBox runat="server" ID="txtSMREF" style="display: none"></asp:TextBox>
                <asp:TextBox runat="server" ID="txtTip" style="display: none"></asp:TextBox>
                - Nokta -
                <asp:TextBox runat="server" ID="txtMusteri" Enabled="false"></asp:TextBox>
                - Adres -
                <asp:TextBox runat="server" ID="txtCoords" Enabled="false"></asp:TextBox>
                <asp:TextBox runat="server" ID="txtCoords1" style="display: none"></asp:TextBox>
                <br /><br />
                - Konum Arama -
                <input placeholder="Adres girerek arayın; Örnek: İstanbul Pendik Ankara Caddesi" autocomplete="off" onkeydown="return clickButton(event,'btnAra')" type="text" id="inputAdresArama" style="margin-bottom: 3px" />
                <a class="button" style="border-radius: 0px" id="btnAra" href="javascript:Ara()">Ara</a>
                <div id="googleMap" style="width:100%; height:200px;"></div>
                <a class="button" style="border-radius: 0px" href="javascript:KoordinatBaslat()">Mevcut Konumu Göster</a>
                <br />
                <%--<asp:Button ID="btnKonumKaydet" runat="server" Text="Konumu Kaydet" onclick="btnKonumKaydet_Click" />--%>
                <a class="button" id="btnKonumKaydet" href="javascript:KonumGonder()">Konumu Kaydet</a>
                <input type="hidden" id="inputLat" runat="server" />
                <input type="hidden" id="inputLng" runat="server" />
                <script type="text/javascript" src="https://maps.googleapis.com/maps/api/js?key=AIzaSyDXm_Z4J-I9jrTO72lGvx1jRzTWsP6qi7Q&callback=myMap"></script>
                <uc3:ucAlt ID="ucAlt1" runat="server" />
                <uc1:ucProgress ID="ucProgress1" runat="server" />
            </div>
        </div>
    </form>
</body>
</html>

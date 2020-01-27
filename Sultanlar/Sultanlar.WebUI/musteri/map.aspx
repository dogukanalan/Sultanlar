<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="map.aspx.cs" Inherits="Sultanlar.WebUI.musteri.map" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sultanlar : Harita</title>
    <script type="text/javascript" src="js/jquery-1.2.6.pack.js"></script>
    <script type="text/javascript" src="js/jquery-1.8.3.js"></script>
    <script type="text/javascript" src="js/scripts.js"></script>
    <script type="text/javascript">

        function MapStyle() {
            return '[{ "featureType": "landscape", "elementType": "geometry", "stylers": [{ "saturation": "-100"}] }, { "featureType": "poi", "elementType": "labels", "stylers": [{ "visibility": "on"}] }, { "featureType": "poi", "elementType": "labels.text.stroke", "stylers": [{ "visibility": "on"}] }, { "featureType": "road", "elementType": "labels.text", "stylers": [{ "color": "#545454"}] }, { "featureType": "road", "elementType": "labels.text.stroke", "stylers": [{ "visibility": "off"}] }, { "featureType": "road.highway", "elementType": "geometry.fill", "stylers": [{ "saturation": "-87" }, { "lightness": "-40" }, { "color": "#ffffff"}] }, { "featureType": "road.highway", "elementType": "geometry.stroke", "stylers": [{ "visibility": "off"}] }, { "featureType": "road.highway.controlled_access", "elementType": "geometry.fill", "stylers": [{ "color": "#f0f0f0" }, { "saturation": "-22" }, { "lightness": "-16"}] }, { "featureType": "road.highway.controlled_access", "elementType": "geometry.stroke", "stylers": [{ "visibility": "off"}] }, { "featureType": "road.highway.controlled_access", "elementType": "labels.icon", "stylers": [{ "visibility": "on"}] }, { "featureType": "road.arterial", "elementType": "geometry.stroke", "stylers": [{ "visibility": "off"}] }, { "featureType": "road.local", "elementType": "geometry.stroke", "stylers": [{ "visibility": "off"}] }, { "featureType": "transit", "elementType": "labels.icon", "stylers": [{ "visibility": "off"}] }, { "featureType": "water", "elementType": "geometry.fill", "stylers": [{ "saturation": "-52" }, { "hue": "#00e4ff" }, { "lightness": "-16"}]}]';
        }

        function myMap() {

            if (getUrlVars()["lat"] != null) { // lat lng gosterme ise
                var marker = new google.maps.Marker({ position: { lat: parseFloat(getUrlVars()["lat"]), lng: parseFloat(getUrlVars()["lng"]) }, title: getUrlVars()["title"], label: getUrlVars()["label"] });
                var mapProp = {
                    center: marker.position,
                    zoom: 14,
                    styles: JSON.parse(MapStyle())
                };
                var map = new google.maps.Map(document.getElementById("googleMap"), mapProp);
                var infowindow = new google.maps.InfoWindow(
                { content: '<b>' + marker.title + '</b>',
                    size: new google.maps.Size(150, 50)
                });
                google.maps.event.addListener(marker, 'click', function () {
                    infowindow.open(map, marker);
                    map.setZoom(16);
                    map.setCenter(marker.getPosition());
                });
                marker.setMap(map);
                document.getElementById('googleMap').style.height = '400px';
            }
            else { // polyline ise
                var p11 = parseFloat(getUrlVars()["konum1"].substring(0, getUrlVars()["konum1"].indexOf(",")));
                var p12 = parseFloat(getUrlVars()["konum1"].substring(getUrlVars()["konum1"].indexOf(",") + 1));
                var p21 = parseFloat(getUrlVars()["konum2"].substring(0, getUrlVars()["konum2"].indexOf(",")));
                var p22 = parseFloat(getUrlVars()["konum2"].substring(getUrlVars()["konum2"].indexOf(",") + 1));
                var p1 = new google.maps.LatLng(p11, p12);
                var p2 = new google.maps.LatLng(p21, p22);
                var p3 = new google.maps.LatLng((p11 + p21) / 2, (p12 + p22) / 2);

                var marker = new google.maps.Marker({ position: p1, title: "MUSTERI", label: "M" });
                var marker1 = new google.maps.Marker({ position: p2, title: "SATICI", label: "S" });
                //var marker2 = new google.maps.Marker({ position: p3, title: "ORTA", label: "O" });

                var mesafe = google.maps.geometry.spherical.computeDistanceBetween(p1, p2); // parseFloat(getUrlVars()["fark"]);
                var inBetween = google.maps.geometry.spherical.interpolate(p1, p2, 0.5);
                var marker2 = new google.maps.Marker({ position: inBetween, title: "MESAFE", label: mesafe.toFixed(0).toString() + "mt",
                    icon: {
                        path: google.maps.SymbolPath.CIRCLE,
                        scale: 0
                    } });

                var mapProp = {
                    center: p3,
                    zoom: mesafe > 2000 ? 12 : mesafe > 1000 ? 13 : mesafe > 150 ? 14 : mesafe > 50 ? 16 : 18,
                    styles: JSON.parse(MapStyle())
                };
                var map = new google.maps.Map(document.getElementById("googleMap"), mapProp);

                var Coordinates = [
                  { lat: p11, lng: p12 },
                  { lat: p21, lng: p22 }
                ];
                var Path = new google.maps.Polyline({
                    path: Coordinates,
                    geodesic: true,
                    strokeColor: '#FFD800',
                    strokeOpacity: 1.0,
                    strokeWeight: 2
                });

                Path.setMap(map);
                marker.setMap(map);
                marker1.setMap(map);
                marker2.setMap(map);
                //marker2.setMap(map);
                document.getElementById('googleMap').style.height = $(window).height() + 'px';
            }
        }

        function getUrlVars() {
            var vars = [], hash;
            var hashes = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
            for (var i = 0; i < hashes.length; i++) {
                hash = hashes[i].split('=');
                vars.push(hash[0]);
                vars[hash[0]] = hash[1];
            }
            return vars;
        }

        var h = 0;
        $(window).load(function () {
            h = $(window).height();
            document.getElementById('googleMap').style.height = h.toString() + 'px';
        });
        $(window).resize(function () {
            if (h != $(window).height()) {
                h = $(window).height();
                document.getElementById('googleMap').style.height = h.toString() + 'px';
            }
        });
    </script>
</head>
<body style="margin: 0 0 0 0; width:100%;height:100%;">
    <form id="form1" runat="server">
        <div id="googleMap" style="width:100%;height:1080px;"></div>
        <script type="text/javascript" src="https://maps.googleapis.com/maps/api/js?key=AIzaSyDXm_Z4J-I9jrTO72lGvx1jRzTWsP6qi7Q&libraries=geometry&callback=myMap"></script>
    </form>
</body>
</html>

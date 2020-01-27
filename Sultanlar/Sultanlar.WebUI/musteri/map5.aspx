<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="map5.aspx.cs" Inherits="Sultanlar.WebUI.musteri.map5" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Sultanlar : Ziyaret Harita</title>
    <script type="text/javascript" src="js/jquery-1.2.6.pack.js"></script>
    <script type="text/javascript" src="js/jquery-1.8.3.js"></script>
    <script type="text/javascript" src="js/jquery-ui.js"></script>
    <link rel="stylesheet" href="js/jquery-ui.css" />
    <script type="text/javascript" src="js/scripts.js"></script>
    <script type="text/javascript">
        var infowindows = [];
        function SifirlaWindows(markers) {
            for (var i = 0; i < infowindows.length; i++) {
                infowindows[i].close();
            }
        }

        function myMap() {
            $("#txtDate").datepicker({ changeMonth: true, changeYear: true, dateFormat: 'dd/mm/yy' });

            var mapProp = {
                center: new google.maps.LatLng(35.128811, 35.129644),
                zoom: 6,
                styles: [{ "featureType": "landscape", "elementType": "geometry", "stylers": [{ "saturation": "-100"}] }, { "featureType": "poi", "elementType": "labels", "stylers": [{ "visibility": "on"}] }, { "featureType": "poi", "elementType": "labels.text.stroke", "stylers": [{ "visibility": "on"}] }, { "featureType": "road", "elementType": "labels.text", "stylers": [{ "color": "#545454"}] }, { "featureType": "road", "elementType": "labels.text.stroke", "stylers": [{ "visibility": "off"}] }, { "featureType": "road.highway", "elementType": "geometry.fill", "stylers": [{ "saturation": "-87" }, { "lightness": "-40" }, { "color": "#ffffff"}] }, { "featureType": "road.highway", "elementType": "geometry.stroke", "stylers": [{ "visibility": "off"}] }, { "featureType": "road.highway.controlled_access", "elementType": "geometry.fill", "stylers": [{ "color": "#f0f0f0" }, { "saturation": "-22" }, { "lightness": "-16"}] }, { "featureType": "road.highway.controlled_access", "elementType": "geometry.stroke", "stylers": [{ "visibility": "off"}] }, { "featureType": "road.highway.controlled_access", "elementType": "labels.icon", "stylers": [{ "visibility": "on"}] }, { "featureType": "road.arterial", "elementType": "geometry.stroke", "stylers": [{ "visibility": "off"}] }, { "featureType": "road.local", "elementType": "geometry.stroke", "stylers": [{ "visibility": "off"}] }, { "featureType": "transit", "elementType": "labels.icon", "stylers": [{ "visibility": "off"}] }, { "featureType": "water", "elementType": "geometry.fill", "stylers": [{ "saturation": "-52" }, { "hue": "#00e4ff" }, { "lightness": "-16"}]}]
            };
            var map = new google.maps.Map(document.getElementById("googleMap"), mapProp);



            var diziler = document.getElementById('inputH').value.split("|||");
            var markers = [];
            //var WayPoints = [];
            var nokta1;
            var nokta2;

            var onceki = 0;
            for (var i = 0; i < diziler.length - 1; i++) {
                var diziic = diziler[i].split(",");
                //if (onceki != parseInt(diziic[3])) {
                var marker = new google.maps.Marker({ position: { lat: parseFloat(diziic[0]), lng: parseFloat(diziic[1]) }, title: diziic[2], label: diziic[3] });

                var infowindow = new google.maps.InfoWindow({ size: new google.maps.Size(150, 50) });
                infowindows.push(infowindow);
                var content = '<b>' + diziic[2] + '</b>';
                google.maps.event.addListener(marker, 'click', (function (marker, content, infowindow) {
                    return function () {
                        SifirlaWindows(markers);
                        infowindow.setContent(content);
                        infowindow.open(map, marker);
                    };
                })(marker, content, infowindow));

                if (onceki == 0)
                    nokta1 = marker;

                markers.push(marker);
                marker.setMap(map);
                //}

                nokta2 = marker;
                onceki = parseInt(diziic[3]);
            }

            if (nokta1) {
                nokta1.setIcon(new google.maps.MarkerImage("https://chart.apis.google.com/chart?chst=d_map_pin_letter&chld=" + nokta1.getLabel() + "|0094FF", new google.maps.Size(41, 34), new google.maps.Point(0, 0), new google.maps.Point(10, 34)));
                nokta1.label = diziler.length - 1 == 1 ? nokta1.label : '';
            }
            if (nokta2) {
                nokta2.setIcon(new google.maps.MarkerImage("https://chart.apis.google.com/chart?chst=d_map_pin_letter&chld=" + nokta2.getLabel() + "|4CFF00", new google.maps.Size(41, 34), new google.maps.Point(0, 0), new google.maps.Point(10, 34)));
                nokta2.label = '';
            }

            for (var i = 0; i < markers.length; i++) {
                //                WayPoints.push({
                //                    location: markers[i].getPosition(),
                //                    stopover: true
                //                });

                if (i > 0) {
                    var Coordinates = [
                      { lat: markers[i].getPosition().lat(), lng: markers[i].getPosition().lng() },
                      { lat: markers[i - 1].getPosition().lat(), lng: markers[i - 1].getPosition().lng() }
                    ];
                    var Path = new google.maps.Polyline({
                        path: Coordinates,
                        geodesic: true,
                        strokeColor: '#FFD800',
                        strokeOpacity: 1.0,
                        strokeWeight: 2,
                        icons: [{
                            icon: { path: google.maps.SymbolPath.BACKWARD_CLOSED_ARROW },
                            offset: '100%',
                            repeat: '30px'
                        }]
                    });
                    Path.setMap(map);
                }
            }

            //            var directionsService = new google.maps.DirectionsService;
            //            var directionsDisplay = new google.maps.DirectionsRenderer({ suppressMarkers: true, polylineOptions: { strokeColor: '#4E85B7', strokeWeight: 3, icons: [{ repeat: '50px', icon: { path: google.maps.SymbolPath.FORWARD_CLOSED_ARROW }, offset: '100%'}]} });
            //            directionsDisplay.setMap(map);

            //            directionsService.route({
            //                origin: nokta1.getPosition(),
            //                destination: nokta2.getPosition(),
            //                provideRouteAlternatives: true,
            //                waypoints: WayPoints,
            //                optimizeWaypoints: true,
            //                travelMode: 'DRIVING'
            //            }, function (response, status) {
            //                if (status === 'OK') {
            //                    directionsDisplay.setDirections(response);
            //                    var route = response.routes[0];
            //                } else {
            //                    window.alert('Yol tarifi alınamadı, teknik ayrıntı: ' + status);
            //                }
            //            });
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

        function yazma(evt) {
            return false;
        }

    </script>
</head>
<body style="margin: 0 0 0 0;background-color: #EFEEEA;">
    <form id="form1" runat="server">
    <input type="hidden" runat="server" id="inputH" />
    <asp:DropDownList runat="server" ID="ddlTemsilciler" AutoPostBack="false" Height="30px" ForeColor="#006699" OnSelectedIndexChanged="ddlTemsilciler_SelectedIndexChanged"
        Width="250px" style="position: absolute; z-index: 1; left: 110px; top: 10px; padding: 3px 3px 3px 3px;border:1px solid #CCCCCC;background:#ededed; margin-bottom: 10px"></asp:DropDownList>
    <asp:TextBox runat="server" ID="txtDate" Text="01.01.2017" ForeColor="#006699" Width="75px" Height="26px" style="position: absolute; z-index: 1; left: 369px; top: 10px; background:#ededed; border:1px solid #CCCCCC; text-align: center" onkeypress="return yazma(event)"></asp:TextBox>
    <asp:Button runat="server" id="btnGetir" Text="Getir" ForeColor="#006699" Width="50px" Height="30px" style="position: absolute; z-index: 1; left: 454px; top: 10px; background:#ededed; border:1px solid #CCCCCC; text-align: center" />
        <input type="button" value="Geri" onclick="javascript:window.location.href='rutlar.aspx'" style="position: absolute; z-index: 1; left: 512px; top: 10px; background:#ededed; border:1px solid #CCCCCC; text-align: center; width: 50px; height: 30px" />
    <div id="googleMap" style="width:100%;height: 1080px;"></div>
    <script type="text/javascript" src="https://maps.googleapis.com/maps/api/js?key=AIzaSyDXm_Z4J-I9jrTO72lGvx1jRzTWsP6qi7Q&libraries=geometry&callback=myMap"></script>
    </form>
</body>
</html>

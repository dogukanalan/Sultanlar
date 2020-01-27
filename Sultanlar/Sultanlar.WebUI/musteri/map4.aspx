<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="map4.aspx.cs" Inherits="Sultanlar.WebUI.musteri.map4" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" src="js/jquery-1.2.6.pack.js"></script>
    <script type="text/javascript" src="js/jquery-1.8.3.js"></script>
    <script type="text/javascript" src="js/scripts.js"></script>
    <script type="text/javascript">

        function MapStyle() {
            return '[{ "featureType": "landscape", "elementType": "geometry", "stylers": [{ "saturation": "-100"}] }, { "featureType": "poi", "elementType": "labels", "stylers": [{ "visibility": "on"}] }, { "featureType": "poi", "elementType": "labels.text.stroke", "stylers": [{ "visibility": "on"}] }, { "featureType": "road", "elementType": "labels.text", "stylers": [{ "color": "#545454"}] }, { "featureType": "road", "elementType": "labels.text.stroke", "stylers": [{ "visibility": "off"}] }, { "featureType": "road.highway", "elementType": "geometry.fill", "stylers": [{ "saturation": "-87" }, { "lightness": "-40" }, { "color": "#ffffff"}] }, { "featureType": "road.highway", "elementType": "geometry.stroke", "stylers": [{ "visibility": "off"}] }, { "featureType": "road.highway.controlled_access", "elementType": "geometry.fill", "stylers": [{ "color": "#f0f0f0" }, { "saturation": "-22" }, { "lightness": "-16"}] }, { "featureType": "road.highway.controlled_access", "elementType": "geometry.stroke", "stylers": [{ "visibility": "off"}] }, { "featureType": "road.highway.controlled_access", "elementType": "labels.icon", "stylers": [{ "visibility": "on"}] }, { "featureType": "road.arterial", "elementType": "geometry.stroke", "stylers": [{ "visibility": "off"}] }, { "featureType": "road.local", "elementType": "geometry.stroke", "stylers": [{ "visibility": "off"}] }, { "featureType": "transit", "elementType": "labels.icon", "stylers": [{ "visibility": "off"}] }, { "featureType": "water", "elementType": "geometry.fill", "stylers": [{ "saturation": "-52" }, { "hue": "#00e4ff" }, { "lightness": "-16"}]}]';
        }

        var map;
        var measure;
        var itends;

        function myMap() {
            itends = false;
            var mapProp = {
                center: new google.maps.LatLng(39.336146, 35.316959),
                zoom: 8,
                styles: JSON.parse(MapStyle())
            };
            map = new google.maps.Map(document.getElementById("googleMap"), mapProp);
            google.maps.event.addListener(map, "click", function (evt) {
                measureAdd(evt.latLng);
            });
            measure = {
                mvcLine: new google.maps.MVCArray(),
                mvcPolygon: new google.maps.MVCArray(),
                mvcMarkers: new google.maps.MVCArray(),
                line: null,
                polygon: null
            };
        }

        function measureAdd(latLng) {
            var marker = new google.maps.Marker({
                map: map,
                position: latLng,
                draggable: true,
                raiseOnDrag: false,
                title: "Sürüklenebilir",
                icon: new google.maps.MarkerImage("https://chart.googleapis.com/chart?chst=d_map_pin_letter&chld=|FF0000|000000", new google.maps.Size(41, 34), new google.maps.Point(0, 0), new google.maps.Point(10, 34))
            });

            measure.mvcLine.push(latLng);
            measure.mvcPolygon.push(latLng);
            measure.mvcMarkers.push(marker);

            var latLngIndex = measure.mvcLine.getLength() - 1;

//            google.maps.event.addListener(marker, "mouseover", function () {
//                marker.setIcon(new google.maps.MarkerImage("https://chart.googleapis.com/chart?chst=d_map_pin_letter&chld=|FF0000|000000", new google.maps.Size(41, 34), new google.maps.Point(0, 0), new google.maps.Point(10, 34)));
//            });

//            google.maps.event.addListener(marker, "mouseout", function () {
//                marker.setIcon(new google.maps.MarkerImage("https://chart.googleapis.com/chart?chst=d_map_pin_letter&chld=|FF0000|000000", new google.maps.Size(41, 34), new google.maps.Point(0, 0), new google.maps.Point(10, 34)));
//            });

            google.maps.event.addListener(marker, "drag", function (evt) {
                measure.mvcLine.setAt(latLngIndex, evt.latLng);
                measure.mvcPolygon.setAt(latLngIndex, evt.latLng);
            });

            google.maps.event.addListener(marker, "dragend", function () {
                if (measure.mvcLine.getLength() > 1) {
                    measureCalc();
                }
            });

            if (measure.mvcLine.getLength() > 1) {
                if (!measure.line) {
                    measure.line = new google.maps.Polyline({
                        map: map,
                        clickable: false,
                        strokeColor: "#FF0000",
                        strokeOpacity: 1,
                        strokeWeight: 2,
                        path: measure.mvcLine
                    });
                }

                if (measure.mvcPolygon.getLength() > 2) {
                    if (!measure.polygon) {
                        measure.polygon = new google.maps.Polygon({
                            clickable: false,
                            map: map,
                            fillOpacity: 0.25,
                            strokeOpacity: 0,
                            paths: measure.mvcPolygon
                        });
                    }
                }
            }

            if (measure.mvcLine.getLength() > 1) {
                measureCalc();
            }
        }

        function measureCalc() {
            var length = google.maps.geometry.spherical.computeLength(measure.line.getPath());
            jQuery("#span-length").text(length.toFixed(1));

            if (measure.mvcPolygon.getLength() > 2) {
                var area = google.maps.geometry.spherical.computeArea(measure.polygon.getPath());
                jQuery("#span-area").text(area.toFixed(1));
            }
        }

        function measureEnd() {
            if (!itends) {
                var cizgiler = new google.maps.MVCArray();
                var birinci;
                var sonuncu;
                var girdi = false;
                var kactane = 0;
                measure.mvcLine.forEach(function (elem, index) {
                    if (!girdi) {
                        birinci = elem;
                        girdi = true;
                    }
                    sonuncu = elem;
                    kactane++;
                });

                if (kactane > 2) {
                    cizgiler.push(birinci);
                    cizgiler.push(sonuncu);
                    measure.line = new google.maps.Polyline({
                        map: map,
                        clickable: false,
                        strokeColor: "#000000",
                        strokeOpacity: 1,
                        strokeWeight: 2,
                        path: cizgiler
                    });

                    google.maps.event.clearListeners(map, 'click');
                    measure.mvcMarkers.forEach(function (elem, index) {
                        elem.draggable = false;
                        elem.title = 'Sürüklenemez!';
                        google.maps.event.clearListeners(elem, 'drag');
                        google.maps.event.clearListeners(elem, 'dragend');
                    });
                    itends = true;
                }
                else {
                    alert('en az 3 nokta seçilmeli!');
                }
            }
        }

        function measureReset() {
            if (itends) {
                if (measure.polygon) {
                    measure.polygon.setMap(null);
                    measure.polygon = null;
                }
                if (measure.line) {
                    measure.line.setMap(null);
                    measure.line = null;
                }

                measure.mvcLine.clear();
                measure.mvcPolygon.clear();

                measure.mvcMarkers.forEach(function (elem, index) {
                    elem.setMap(null);
                });
                measure.mvcMarkers.clear();

                jQuery("#span-length,#span-area").text(0);

                itends = false;
                google.maps.event.addListener(map, "click", function (evt) {
                    measureAdd(evt.latLng);
                });
            }
            else {
                alert('çizim tamamlanmadı!');
            }
        }

        var h = 0;
        $(window).load(function () {
            document.getElementById('googleMap').style.height = '300px';
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
<body style="margin: 0 0 0 0; width: 100%; height: 100%;">
    <form id="form1" runat="server">
    <div id="googleMap" style="width: 100%; height: 398px;">
    </div>
    <script type="text/javascript" src="https://maps.googleapis.com/maps/api/js?key=AIzaSyDXm_Z4J-I9jrTO72lGvx1jRzTWsP6qi7Q&libraries=geometry&callback=myMap"></script>
    <span id="span-length">0</span>
    <span id="span-area">0</span>
    <a href="javascript:measureReset();">Sıfırla</a>
    <a href="javascript:measureEnd();">Bitir</a>
    </form>
</body>
</html>

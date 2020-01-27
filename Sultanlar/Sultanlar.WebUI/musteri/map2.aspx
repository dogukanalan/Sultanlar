<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="map2.aspx.cs" Inherits="Sultanlar.WebUI.musteri.map2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Sultanlar : Rut Harita</title>
    <script type="text/javascript" src="js/jquery-1.2.6.pack.js"></script>
    <script type="text/javascript" src="js/jquery-1.8.3.js"></script>
    <script type="text/javascript" src="js/scripts.js"></script>
    <script type="text/javascript">

        var colors = [];
        var slsrefs = [];
        function getRandomColor() {
            var letters = '0123456789ABCDEF';
            var color = '';
            for (var i = 0; i < 6; i++) {
                color += letters[Math.floor(Math.random() * 16)];
            }
            return color;
        }

        function hashCode(str) { // java String#hashCode
            var hash = 0;
            for (var i = 0; i < str.length; i++) {
                hash = str.charCodeAt(i) + ((hash << 5) - hash);
            }
            return hash;
        }

        function intToRGB(i) {
            var c = (i & 0x00FFFFFF)
        .toString(16)
        .toUpperCase();

            return "00000".substring(0, 6 - c.length) + c;
        }

        function myMap() {
            var mapProp = {
                center: new google.maps.LatLng(35.128811, 35.129644),
                zoom: 6,
                styles: [{ "featureType": "landscape", "elementType": "geometry", "stylers": [{ "saturation": "-100"}] }, { "featureType": "poi", "elementType": "labels", "stylers": [{ "visibility": "off"}] }, { "featureType": "poi", "elementType": "labels.text.stroke", "stylers": [{ "visibility": "off"}] }, { "featureType": "road", "elementType": "labels.text", "stylers": [{ "color": "#545454"}] }, { "featureType": "road", "elementType": "labels.text.stroke", "stylers": [{ "visibility": "off"}] }, { "featureType": "road.highway", "elementType": "geometry.fill", "stylers": [{ "saturation": "-87" }, { "lightness": "-40" }, { "color": "#ffffff"}] }, { "featureType": "road.highway", "elementType": "geometry.stroke", "stylers": [{ "visibility": "off"}] }, { "featureType": "road.highway.controlled_access", "elementType": "geometry.fill", "stylers": [{ "color": "#f0f0f0" }, { "saturation": "-22" }, { "lightness": "-16"}] }, { "featureType": "road.highway.controlled_access", "elementType": "geometry.stroke", "stylers": [{ "visibility": "off"}] }, { "featureType": "road.highway.controlled_access", "elementType": "labels.icon", "stylers": [{ "visibility": "off"}] }, { "featureType": "road.arterial", "elementType": "geometry.stroke", "stylers": [{ "visibility": "off"}] }, { "featureType": "road.local", "elementType": "geometry.stroke", "stylers": [{ "visibility": "off"}] }, { "featureType": "transit", "elementType": "labels.icon", "stylers": [{ "visibility": "off"}] }, { "featureType": "water", "elementType": "geometry.fill", "stylers": [{ "saturation": "-52" }, { "hue": "#00e4ff" }, { "lightness": "-16"}]}]
            };
            var map = new google.maps.Map(document.getElementById("googleMap"), mapProp);



            if (document.getElementById("cbBolgesel").checked) {
                var data = JSON.parse(document.getElementById("inputB").value);
                map.data.addGeoJson(data);
                map.data.setStyle(function (feature) {
                    var color = feature.getProperty('fillColor');
                    return {
                        fillColor: color,
                        strokeWeight: 0.2
                    };
                });
                var elem = document.getElementById('inputB');
                elem.parentNode.removeChild(elem);
            }



            var diziler = document.getElementById('inputH').value.split("|||");

            for (var i = 0; i < diziler.length - 1; i++) {
                var diziic = diziler[i].split(",");
                var varmi = false;
                for (var j = 0; j < slsrefs.length; j++) {
                    if (diziic[4] == slsrefs[j]) {
                        varmi = true;
                    }
                }
                if (!varmi) {
                    slsrefs.push(diziic[4]);
                    colors.push(getRandomColor());
                }
            }

            for (var i = 0; i < diziler.length - 1; i++) {

                try {
                    var diziic = diziler[i].split(",");
                    var marker = new google.maps.Marker({ position: { lat: parseFloat(diziic[0]), lng: parseFloat(diziic[1]) }, title: diziic[2] });
                    var color = intToRGB(hashCode(diziic[5]));
                    marker.setIcon(new google.maps.MarkerImage("https://chart.apis.google.com/chart?chst=d_map_pin_letter&chld=" + diziic[5][0] + diziic[5].split(' ')[1][0] + "|" + color + "", new google.maps.Size(41, 34), new google.maps.Point(0, 0), new google.maps.Point(10, 34)));

                    var infowindow = new google.maps.InfoWindow(
                    { content: '<b>' + diziic[5] + '</b><br>' + diziic[2],
                        size: new google.maps.Size(150, 50)
                    });

                    var content = '<b>' + diziic[5] + '</b><br>' + diziic[2];

                    google.maps.event.addListener(marker, 'click', (function (marker, content, infowindow) {
                        return function () {
                            infowindow.setContent(content);
                            infowindow.open(map, marker);
                        };
                    })(marker, content, infowindow));

                    marker.setMap(map);
                } catch (e) {
                    //alert(diziler[i] + ' ' + e);
                }
            }
        }

        var h = 0;
        $(window).load(function () {
            $("#divFl").hide(1);
            h = $(window).height();
            document.getElementById('googleMap').style.height = h.toString() + 'px';
        });
        $(window).resize(function () {
            if (h != $(window).height()) {
                h = $(window).height();
                document.getElementById('googleMap').style.height = h.toString() + 'px';
            }
        });

        var gizlendi = true;
        function AcKapa() {
            if (gizlendi)
                flGoster();
            else
                flGizle();
        }
        function flGoster() {
            $("#divFl").show(500);
            gizlendi = false;
        }
        function flGizle() {
            $("#divFl").hide(500);
            gizlendi = true;
        }
    </script>
    <style type="text/css">
        input[type=checkbox] {
            cursor:pointer;
            -webkit-appearance: none;
	        background-color: #fafafa;
	        border: 1px solid #cacece;
	        box-shadow: 0 1px 2px rgba(0,0,0,0.05), inset 0px -15px 10px -12px rgba(0,0,0,0.05);
	        padding: 5px;
	        border-radius: 3px;
	        display: inline-block;
	        position: relative;
        }
        input[type=checkbox]:checked {
	        background-color: #99a1a7;
	        border: 1px solid #adb8c0;
	        box-shadow: 0 1px 2px rgba(0,0,0,0.05), inset 0px -15px 10px -12px rgba(0,0,0,0.05), inset 15px 10px -12px rgba(255,255,255,0.1);
	        color: #99a1a7;
        }
        input[type=checkbox]:active {
	        box-shadow: 0 1px 2px rgba(0,0,0,0.05), inset 0px 1px 3px rgba(0,0,0,0.1);
        }
        label {
            cursor:pointer;
            vertical-align: top;
        }
        input[type=button],input[type=submit] {
            font-size: 11px; 
            color: #666666;
            width: 46px; 
            height: 29px; 
            background:#ffffff; 
            border: 0px; 
            border-left: 1px solid #e2e2e2; 
            border-radius: 2px; -webkit-border-radius: 2px; 
            padding: 3px 3px 3px 3px; 
            cursor:pointer;
        }
        input[type=button]:hover,input[type=submit]:hover {
            color: #000000;
            background: #eaeaea;
        }
    </style>
</head>
<body style="margin: 0 0 0 0; width: 100%; height: 100%;">
    <form id="form1" runat="server">
    <input type="hidden" runat="server" id="inputH" value="" />
    <input type="hidden" runat="server" id="inputB" value="" />
    <div style="position: absolute; z-index: 1; left: 180px; top: 10px;">
        <input type="button" id="flHide" value="Filtrele" onclick="AcKapa()" style="height: 40px; width: 80px; font-size: 18px" />
        <input type="button" value="Geri" onclick="javascript:window.location.href='rutlar.aspx'" style="height: 40px; width: 80px; font-size: 18px" />
    </div>
    <div style="position: absolute; z-index: 1; left: 10px; top: 44px;">
        <div id="divFl" style="background: #ffffff; font-size: 10px; font-family: Verdana; border: 1px solid #ccc; border-radius: 5px; -webkit-border-radius: 5px; margin-top: 5px">
            <%--<asp:DropDownList runat="server" ID="ddlTemsilciler" AutoPostBack="true" Height="30px" ForeColor="#006699" 
                Width="200px" style="padding: 3px 3px 3px 3px;border:1px solid #CCCCCC; background:#ededed;"></asp:DropDownList>--%>
            <br />
            <asp:CheckBox runat="server" ID="cbAktifler" Text="Yalnızca Aktifler Gelsin" Checked="true" />
            <asp:CheckBox runat="server" ID="cbBolgesel" Text="Bölgesel Dağılım" Checked="false" />
            <br /><br />
            <asp:CheckBoxList ID="cblSaticilar" runat="server" AutoPostBack="false" RepeatDirection="Horizontal" RepeatColumns="6"></asp:CheckBoxList>
            <asp:Button ID="btnUygula" runat="server" Text="Uygula" style="font-size: 11px; width: 100px; height: 28px; border: 1px solid #ccc; border-radius: 5px; -webkit-border-radius: 5px; padding: 3px 3px 3px 3px; margin: 5px 5px 5px 5px" />
        </div>
    </div>
    <div id="googleMap" style="width: 100%; height: 1080px;">
    </div>
    <script type="text/javascript" src="https://maps.googleapis.com/maps/api/js?key=AIzaSyDXm_Z4J-I9jrTO72lGvx1jRzTWsP6qi7Q&libraries=geometry&callback=myMap"></script>
    </form>
</body>
</html>

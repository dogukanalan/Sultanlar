<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="rutharita.aspx.cs" Inherits="Sultanlar.WebUI.musteri.rutharita" %>

<%@ Register src="ucAlt.ascx" tagname="ucAlt" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
	<meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Sultanlar : Rutlar</title>
    <link rel="stylesheet" type="text/css" href="StyleSheet.css" />
    
    <script type="text/javascript" src="js/jquery-1.2.6.pack.js"></script>
    <script type="text/javascript" src="js/jquery-1.8.3.js"></script>
    <script type="text/javascript" src="js/jquery-ui.js"></script>
    <link rel="stylesheet" href="js/jquery-ui.css" />
    <script type="text/javascript" src="js/scripts.js"></script>

    <script type="text/javascript">
        $(function () {
            $("#top").click(function YukariIttir() {
                $("html,body").stop().animate({ scrollTop: "0" }, 1000);
            });
        });
        $(window).scroll(function () {
            var uzunluk = $(document).scrollTop();
            if (uzunluk > 300) $("#top").fadeIn(500);
            else { $("#top").fadeOut(500); }
        });

        function clickButton(e, buttonid) {
            var evt = e ? e : window.event;
            var bt = document.getElementById(buttonid);
            if (bt) {
                if (evt.keyCode == 13) {
                    bt.click();
                    return false;
                }
            }
        }

        function yazma(evt) {
            return false;
        }
    </script>
    <style type="text/css">
        #top{bottom:5px;right:5px;background:#147;padding:5px;color:#fff;font:bold 11px verdana;position:fixed;display:none;cursor:default;}
        [class*=dxgvTable] [class*=dxeCalendarFooter] tr { visibility: hidden !important; }
    </style>

    <script type="text/javascript" src="js/jquery.tipTip.js"></script>
    <script type="text/javascript" src="js/jquery.tipTip.minified.js"></script>
    <link rel="stylesheet" type="text/css" href="js/tipTip.css" />
    
    <%--<script type="text/javascript" src="https://maps.google.com/maps/api/js?sensor=false&libraries=geometry"></script>--%>
</head>
<body style="margin: 0 0 0 0;background-color: #EFEEEA;">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="AjaxScripts" runat="server" AsyncPostBackTimeout="1000">
    </asp:ScriptManager>
    <script type="text/javascript">
        Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(function (evt, args) {
            $("input[type=submit], input[type=button]").button();
            $("#txtDate").datepicker({ changeMonth: true, changeYear: true, dateFormat: 'dd/mm/yy' });
        });

        var baslangickonum = "40.976598,29.232106";
        var bitiskonum = "40.977926, 29.232567";
        var map;
        var trafficLayer;

        function myMap() {
            var mapProp= {
                center: new google.maps.LatLng(41.060795, 29.006857),
                zoom: 10,
                styles: [{ "featureType": "landscape", "elementType": "geometry", "stylers": [{ "saturation": "-100"}] }, { "featureType": "poi", "elementType": "labels", "stylers": [{ "visibility": "on"}] }, { "featureType": "poi", "elementType": "labels.text.stroke", "stylers": [{ "visibility": "on"}] }, { "featureType": "road", "elementType": "labels.text", "stylers": [{ "color": "#545454"}] }, { "featureType": "road", "elementType": "labels.text.stroke", "stylers": [{ "visibility": "off"}] }, { "featureType": "road.highway", "elementType": "geometry.fill", "stylers": [{ "saturation": "-87" }, { "lightness": "-40" }, { "color": "#ffffff"}] }, { "featureType": "road.highway", "elementType": "geometry.stroke", "stylers": [{ "visibility": "off"}] }, { "featureType": "road.highway.controlled_access", "elementType": "geometry.fill", "stylers": [{ "color": "#f0f0f0" }, { "saturation": "-22" }, { "lightness": "-16"}] }, { "featureType": "road.highway.controlled_access", "elementType": "geometry.stroke", "stylers": [{ "visibility": "off"}] }, { "featureType": "road.highway.controlled_access", "elementType": "labels.icon", "stylers": [{ "visibility": "on"}] }, { "featureType": "road.arterial", "elementType": "geometry.stroke", "stylers": [{ "visibility": "off"}] }, { "featureType": "road.local", "elementType": "geometry.stroke", "stylers": [{ "visibility": "off"}] }, { "featureType": "transit", "elementType": "labels.icon", "stylers": [{ "visibility": "off"}] }, { "featureType": "water", "elementType": "geometry.fill", "stylers": [{ "saturation": "-52" }, { "hue": "#00e4ff" }, { "lightness": "-16"}]}]
            };
            
            if (readCookie("sulRutBaslangic") != null) {
                baslangickonum = readCookie("sulRutBaslangic");
            }
            if (readCookie("sulRutBitis") != null) {
                bitiskonum = readCookie("sulRutBitis");
            }

            var markers = [];
            var diziler = document.getElementById('inputH').value.split("|||");
            map = new google.maps.Map(document.getElementById("googleMap"), mapProp);
            for (var i = 0; i < diziler.length - 1; i++) {
                var diziic = diziler[i].split(",");
                var marker = new google.maps.Marker({ position: { lat: parseFloat(diziic[0]), lng: parseFloat(diziic[1]) }, title: diziic[2], label: diziic[3] });
                var infowindow = new google.maps.InfoWindow({ size: new google.maps.Size(150, 50) });
                var content = '<b>' + diziic[2] + '</b>';
                google.maps.event.addListener(marker, 'click', (function (marker, content, infowindow) {
                    return function () {
                        infowindow.setContent(content);
                        infowindow.open(map, marker);
                    };
                })(marker, content, infowindow));
                marker.setMap(map);
                markers.push(marker);
            }

            // başlangıç
            var diziic = (baslangickonum + ",Başlangıç,S").split(",");
            var marker = new google.maps.Marker({ position: { lat: parseFloat(diziic[0]), lng: parseFloat(diziic[1]) }, title: diziic[2], label: diziic[3], draggable: true });
            var infowindow = new google.maps.InfoWindow({ size: new google.maps.Size(150, 50) });
            var content = '<b>' + diziic[2] + '</b>';
            google.maps.event.addListener(marker, 'click', (function (marker, content, infowindow) {
                return function () {
                    infowindow.setContent(content);
                    infowindow.open(map, marker);
                };
            })(marker, content, infowindow));
            google.maps.event.addListener(marker, 'dragend', function (evt) {
                eraseCookie("sulRutBaslangic");
                baslangickonum = evt.latLng.lat().toFixed(6) + "," + evt.latLng.lng().toFixed(6);
                myMap();
            });
            marker.setIcon(new google.maps.MarkerImage("https://chart.apis.google.com/chart?chst=d_map_pin_letter&chld=" + marker.getLabel() + "|A0D6FF", new google.maps.Size(41, 34), new google.maps.Point(0, 0), new google.maps.Point(10, 34)));
            marker.setLabel('');
            marker.setMap(map);

            // bitiş
            var diziic1 = (bitiskonum + ",Bitiş,E").split(",");
            var marker1 = new google.maps.Marker({ position: { lat: parseFloat(diziic1[0]), lng: parseFloat(diziic1[1]) }, title: diziic1[2], label: diziic1[3], draggable: true });
            var infowindow1 = new google.maps.InfoWindow({ size: new google.maps.Size(150, 50) });
            var content1 = '<b>' + diziic1[2] + '</b>';
            google.maps.event.addListener(marker1, 'click', (function (marker1, content1, infowindow1) {
                return function () {
                    infowindow.setContent(content1);
                    infowindow.open(map, marker1);
                };
            })(marker1, content1, infowindow1));
            google.maps.event.addListener(marker1, 'dragend', function (evt) {
                eraseCookie("sulRutBitis");
                bitiskonum = evt.latLng.lat().toFixed(6) + "," + evt.latLng.lng().toFixed(6);
                myMap();
            });
            marker1.setIcon(new google.maps.MarkerImage("https://chart.apis.google.com/chart?chst=d_map_pin_letter&chld=" + marker1.getLabel() + "|00FF21", new google.maps.Size(41, 34), new google.maps.Point(0, 0), new google.maps.Point(10, 34)));
            marker1.setLabel('');
            marker1.setMap(map);
            
            var WayPoints = [];
            for (var i = 0; i < markers.length; i++) {
                WayPoints.push({
                    location: markers[i].getPosition(),
                    stopover: true
                });
            }

            var directionsService = new google.maps.DirectionsService;
            var directionsDisplay = new google.maps.DirectionsRenderer({ suppressMarkers: true, polylineOptions: { strokeColor: '#4E85B7', strokeWeight: 3, icons: [{ repeat: '50px', icon: { path: google.maps.SymbolPath.FORWARD_CLOSED_ARROW }, offset: '100%'}]} });
            directionsDisplay.setMap(map);

            directionsService.route({
                origin: marker.getPosition(),
                destination: marker1.getPosition(),
                provideRouteAlternatives: true,
                waypoints: WayPoints,
                optimizeWaypoints: true,
                travelMode: 'DRIVING'
            }, function (response, status) {
                if (status === 'OK') {
                    directionsDisplay.setDirections(response);
                    var route = response.routes[0];

                } else {
                    window.alert('Yol tarifi alınamadı, teknik ayrıntı: ' + status);
                }
            });

            trafficLayer = new google.maps.TrafficLayer();
            //trafficLayer.setMap(map);

            GetLoc();
            
            window.setInterval(function () { GetLoc(); }, 60000);
        }

        function calcDistance(p1, p2) {
            return parseInt((google.maps.geometry.spherical.computeDistanceBetween(p1, p2)).toFixed(2)); //  / 1000
        }

        function getIcon(color) {
            return MapIconMaker.createMarkerIcon({ width: 20, height: 34, primaryColor: color, cornercolor: color });
        }

        function Ara() {
            AdresGetir(document.getElementById("inputAdresArama").value, true);
        }

        function Ara2() {
            AdresGetir(document.getElementById("inputAdresArama2").value, false);
        }

        function AdresGetir(adres,baslangicmi) {
            var geocoder = new google.maps.Geocoder();
            var address = adres;
            if (geocoder) {
                geocoder.geocode({ 'address': address }, function (results, status) {
                    if (status == google.maps.GeocoderStatus.OK) {
                        if (status != google.maps.GeocoderStatus.ZERO_RESULTS) {
                            if (baslangicmi) {
                                baslangickonum = results[0].geometry.location.lat().toFixed(6) + ',' + results[0].geometry.location.lng().toFixed(6);
                                if (document.getElementById('cbCookie').checked) {
                                    eraseCookie("sulRutBaslangic");
                                    createCookie("sulRutBaslangic", baslangickonum, 30);
                                }
                            }
                            else {
                                bitiskonum = results[0].geometry.location.lat().toFixed(6) + ',' + results[0].geometry.location.lng().toFixed(6);
                                if (document.getElementById('cbCookie2').checked) {
                                    eraseCookie("sulRutBitis");
                                    createCookie("sulRutBitis", bitiskonum, 30);
                                }
                            }
                            myMap();
                        } else {
                            alert("Adres bulunamadı.");
                        }
                    } else {
                        alert("Adres bulunamadı.");
                    }
                });
            }
        }

        function GetLoc() {
            if (navigator.geolocation) {
                navigator.geolocation.getCurrentPosition(function (position) {

                    var goldStar = {
                        path: 'M 125,5 155,90 245,90 175,145 200,230 125,180 50,230 75,145 5,90 95,90 z',
                        fillColor: 'yellow',
                        fillOpacity: 0.8,
                        scale: 0.1,
                        strokeColor: 'gold',
                        strokeWeight: 1
                    };

                    var markerHere = new google.maps.Marker({ position: { lat: position.coords.latitude, lng: position.coords.longitude }, title: 'Buradasınız'/*, label: '*'*/ });
                    markerHere.setIcon(new google.maps.MarkerImage("https://maps.google.com/mapfiles/kml/shapes/info-i_maps.png", new google.maps.Size(41, 34), new google.maps.Point(0, 0), new google.maps.Point(10, 34)));
                    markerHere.setMap(map);
                }, function () {
                    handleLocationError(true, infoWindow, map.getCenter());
                });
            } else {
                alert('Tarayıcı konumu desteklemiyor');
            }
        }

        function GetTraffic() {
            if (document.getElementById('inputTrafik').checked) {
                trafficLayer.setMap(map);
            }
            else {
                trafficLayer.setMap(null);
            }
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

    <input type="hidden" runat="server" id="inputH" value="" />
    
    <div id="tiptip_holder">
    <div id="tiptip_content">
    <div id="tiptip_arrow">
    <div id="tiptip_arrow_inner"></div>
    </div>
    </div>
    </div>

    <div style="width: 100%; font-size: 9px; font-family: Verdana; background-color: #EFEEEA; border-bottom: 1px solid #FFCFB2"">
    <table cellpadding="5" cellspacing="0">
    <tr>
    <td style="width: 800px;" valign="middle">
        <table cellpadding="0" cellspacing="0"><tr><td>
        <input type="button" value="Giriş" onclick="javascript:window.location.href='default.aspx'" /> 
        <input type="button" value="Aktiviteler" onclick="javascript:window.location.href='aktiviteler.aspx'" /> 
        <input type="button" value="H.Bedelleri" onclick="javascript:window.location.href='hizmetbedelleri.aspx'" /> 
        <input type="button" value="Anlaşmalar" onclick="javascript:window.location.href='anlasmalar.aspx'" /> 
        <input type="button" value="Siparişler" onclick="javascript:window.location.href='siparisler.aspx'" /> 
        <input type="button" value="İadeler" onclick="javascript:window.location.href='iadeler.aspx'" /> 
        <input type="button" value="Tahsilatlar" onclick="javascript:window.location.href='odemeler.aspx'" /> 
        <input type="button" value="Raporlar" onclick="javascript:window.location.href='hesapayrinti.aspx'" /> 
        <input type="button" value="Üye İşlemleri" onclick="javascript:window.location.href='uyelik.aspx'" /> 
        <input type="button" value='Mesajlar (<%= Sultanlar.DatabaseObject.Internet.GonderilenMesajlar.GetObjectCount(((Sultanlar.DatabaseObject.Internet.Musteriler)Session["Musteri"]).pkMusteriID).ToString() %>)' onclick="javascript:window.location.href='mesajlar.aspx'" /></td><td align="left"></td></tr></table>
    </td>
    <td style="width: 200px; font-family: Gisha; font-size: 12px" align="right">
        <table cellpadding="0" cellspacing="0"><tr><td><asp:Label ID="Label1" runat="server"></asp:Label>&nbsp;&nbsp;&nbsp;</td><td><asp:ImageButton runat="server" ID="ImageButton1" OnClick="ImageButton1_Click" ImageUrl="img/ic_logout.png" /></td></tr></table>
    </td>
    </tr>
    </table>
    </div>
    
    <div style="width: 100%; background-color: #FFFFFF">
    <table cellpadding="0" cellspacing="0" style="width: 1000px; height: 400px; font-size: 10px; font-family: Verdana;
        background-position: center center; background-image: url('img/bg-logo.jpg'); background-repeat: no-repeat;">
        <tr>
            <td valign="top">
            <div class="Baslik">
                <table cellpadding="0" cellspacing="0">
                <tr>
                <td><img src="img/ic_rutlar.png" /></td>
                <td style="width: 100%">Rutlar : Harita<asp:Label runat="server" Width="30px"></asp:Label>
                <input style="font-size: 10px; font-style: italic" type="button" value="Geri Dön" onclick="javascript:window.location.href='rutlar.aspx'" />
                </td>
                </tr>
                </table>

                <asp:DropDownList runat="server" ID="ddlTemsilciler" Height="25px" ForeColor="#006699" 
                    Width="500px" style="padding: 3px 3px 3px 3px;border:1px solid #CCCCCC;background:#ededed; margin-bottom: 10px"></asp:DropDownList>
                <asp:TextBox runat="server" ID="txtDate" Text="01.01.2017" ForeColor="#006699" Width="75px" Height="23px" 
                    style="background:#ededed; border:1px solid #CCCCCC; text-align: center" onkeypress="return yazma(event)"></asp:TextBox>
                <asp:DropDownList Visible="false" runat="server" ID="ddlTemsilcilerSecim" AutoPostBack="true" Height="25px" ForeColor="#006699"
                    Width="100px" style="padding: 3px 3px 3px 3px;border:1px solid #CCCCCC;background:#ededed;">
                    <asp:ListItem Text="Satıcı" Value="0" Selected="True"></asp:ListItem>
                    <asp:ListItem Text="Bayi Yön." Value="1"></asp:ListItem>
                </asp:DropDownList>
                <asp:Button runat="server" id="btnGetir" Text="Getir" ForeColor="#006699" Width="50px" Height="27px"
                    style="background:#ededed; border:1px solid #CCCCCC; text-align: center; font-size: 10px" OnClick="btnGetir_Click" />
                <br />
                <span class="kucukbilgiGoster" style="font-size: 12px;">Başlangıç Noktası:</span>
        <input placeholder="Adres girebilirsiniz; Örnek: İstanbul Pendik Ankara Caddesi" onkeydown="return clickButton(event,'btnAra')" type="text" id="inputAdresArama" style="width: 400px;margin-bottom: 10px" />
        <input type="checkbox" id="cbCookie" class="classCbInput" /> <span class="kucukbilgiGoster" title="Bir ay boyunca kaydeder" style="font-size: 12px">Kaydet</span>
        <input type="button" id="btnAra" value="Ara" onclick="Ara()" style="font-size: 10px" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="kucukbilgiGoster" style="font-size: 12px">Trafik gösterilsin:</span>
            <input type="checkbox" id="inputTrafik" class="classCbInput" onchange="GetTraffic()" />
                <br />
                <span class="kucukbilgiGoster" style="font-size: 12px;">Bitiş Noktası:</span><span style="display:inline-block; width: 25px"></span>
                <input placeholder="Adres girebilirsiniz; Örnek: İstanbul Pendik Ankara Caddesi" onkeydown="return clickButton(event,'btnAra2')" type="text" id="inputAdresArama2" style="width: 400px;margin-bottom: 10px" />
                <input type="checkbox" id="cbCookie2" class="classCbInput" /> <span class="kucukbilgiGoster" title="Bir ay boyunca kaydeder" style="font-size: 12px">Kaydet</span>
                <input type="button" id="btnAra2" value="Ara" onclick="Ara2()" style="font-size: 10px" />
                <br />

    <div id="googleMap" style="width:100%;height:400px;"></div>
    <script type="text/javascript">
    </script>
    <script type="text/javascript" src="https://maps.googleapis.com/maps/api/js?key=AIzaSyDXm_Z4J-I9jrTO72lGvx1jRzTWsP6qi7Q&libraries=geometry&callback=myMap"></script>

                </div>
            </td>
        </tr>
    </table>
    </div>
    <%--<uc1:ucAlt ID="ucAlt1" runat="server" />--%>
    <div style="background-color: #EFEEEA; height: 100px; padding: 10px; border-top: 1px solid #FFCFB2">
    <img src="img/logo.png" alt="" style="padding: 0 20px 0 10px; cursor: pointer" onclick="window.location.href='https://www.sultanlar.com.tr'" />
    <img src="img/ssl.gif" alt="" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <img src="img/logoSAP.png" alt="" style="padding-bottom: 7px" />
    <div style="margin-top: 5px; width: 100%; text-align: center; font-family: Tahoma;
        font-size: 12px; color: #808080">
        Copyright © 2011-2018 Sultanlar Pazarlama A.Ş. Tüm hakları saklıdır.
        <br />
        Sitede yer alan resim, yazı ve içerikler kaynak gösterilerek dahi olsa kopyalanamaz.
    </div>
        </div>
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="konumal.aspx.cs" Inherits="Sultanlar.WebUI.musteri.konumal" %>

<%@ Register src="ucAlt.ascx" tagname="ucAlt" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Sultanlar : Konum Al</title>
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
			myMap();
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

        function getParameterByName(name, url) {
            if (!url) url = window.location.href;
            name = name.replace(/[\[\]]/g, "\\$&");
            var regex = new RegExp("[?&]" + name + "(=([^&#]*)|&|#|$)"),
        results = regex.exec(url);
            if (!results) return null;
            if (!results[2]) return '';
            return decodeURIComponent(results[2].replace(/\+/g, " "));
        }
    </script>
    <style type="text/css">
        #top{bottom:5px;right:5px;background:#147;padding:5px;color:#fff;font:bold 11px verdana;position:fixed;display:none;cursor:default;}
        [class*=dxgvTable] [class*=dxeCalendarFooter] tr { visibility: hidden !important; }
    </style>

    <script type="text/javascript" src="js/jquery.tipTip.js"></script>
    <script type="text/javascript" src="js/jquery.tipTip.minified.js"></script>
    <link rel="stylesheet" type="text/css" href="js/tipTip.css" />
    <script type="text/javascript">

        function Ara() {
            document.getElementById("btnAlBakalim").style.visibility = 'visible';
            SifirlaMarkers();
            AdresGetir(document.getElementById("inputAdresArama").value);
        }

        function SifirlaMarkers() {
            for (var i = 0; i < markers.length; i++) {
                markers[i].setMap(null);
            }
        }

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
                    document.getElementById('inputLat').value = evt.latLng.lat().toFixed(6);
                    document.getElementById('inputLng').value = evt.latLng.lng().toFixed(6);
                    geocodePosition(evt.latLng);
                    document.getElementById("btnAlBakalim").style.visibility = 'visible';
                });
                google.maps.event.addListener(marker, 'click', function () {
                    map.setZoom(16);
                    map.setCenter(marker.getPosition());
                });
                marker.setMap(map);
                markers.push(marker);
                map.setCenter(marker.getPosition());
            }
            else {
                AdresGetir(document.getElementById("inputAdres").value);
            }
        }

        function geocodePosition(pos) {
            var geocoder = new google.maps.Geocoder();
            geocoder.geocode({
                latLng: pos
            }, function (responses) {
                if (responses && responses.length > 0) {
                    document.getElementById("inputMapAdres").value = responses[0].formatted_address;
                    document.getElementById("inputMapAdres2").value = responses[0].formatted_address;
                } else {
                    document.getElementById("inputMapAdres").value = "Adres bulunamadı.";
                    document.getElementById("inputMapAdres2").value = "Adres bulunamadı.";
                }
            });
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
                                document.getElementById('inputLat').value = evt.latLng.lat().toFixed(6);
                                document.getElementById('inputLng').value = evt.latLng.lng().toFixed(6);
                                geocodePosition(evt.latLng);
                            });

                            marker.setMap(map);
                            markers.push(marker);
                            map.setZoom(10);

                            document.getElementById("inputLat").value = results[0].geometry.location.lat().toFixed(6);
                            document.getElementById("inputLng").value = results[0].geometry.location.lng().toFixed(6);

                            document.getElementById("inputMapAdres").value = results[0].formatted_address;
                            document.getElementById('inputMapAdres2').value = results[0].formatted_address;

                            //document.getElementById("btnAlBakalim").setAttribute("disabled", "");
                            //document.getElementById('btnAlBakalim').disabled = false;
                            //$('#btnAlBakalim').prop('disabled', false);
                            document.getElementById("btnAlBakalim").style.visibility = 'visible';
                        } else {
                            alert("Adres bulunamadı.");
                        }
                    } else {
                        map.setZoom(6);
                        alert("Adres bulunamadı.");
                        //document.getElementById("btnAlBakalim").setAttribute("disabled", "disabled");
                        //document.getElementById('btnAlBakalim').disabled = true;
                        //$('#btnAlBakalim').prop('disabled', true);
                        document.getElementById("btnAlBakalim").style.visibility = 'hidden';
                    }
                });
            }
            //map.setZoom(16);
        }
    </script>
</head>
<body style="margin: 0 0 0 0;background-color: #EFEEEA;">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="AjaxScripts" runat="server" AsyncPostBackTimeout="1000">
    </asp:ScriptManager>
    <script type="text/javascript">
        Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(function (evt, args) {
            $("input[type=submit], input[type=button]").button();
            if (getParameterByName("lat") != null && getParameterByName("lng") != null)
                document.getElementById("btnAlBakalim").style.visibility = 'hidden';
        });
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
                <td><img src="img/marker.png" /></td>
                <td style="width: 100%">&nbsp;Konum<asp:Label runat="server" Width="30px"></asp:Label><input style="font-size: 10px; font-style: italic" type="button" value="Geri Dön" onclick="javascript:window.location.href='konumlar.aspx'" /></td>
                </tr>
                </table>
        </div>
        <input type="hidden" runat="server" id="inputSMREF" />
        <input type="hidden" runat="server" id="inputTIP" />
        <input type="hidden" runat="server" id="inputUnvan" />
        <input type="hidden" runat="server" id="inputAdres" />
        <input type="hidden" runat="server" id="inputLat" />
        <input type="hidden" runat="server" id="inputLng" />
        <input type="hidden" runat="server" id="inputMapAdres2" />
        <asp:Label runat="server" ID="lblMusteri" Font-Size="14px" Font-Bold="true" style="margin-left: 25px"></asp:Label><br />
        <asp:Label runat="server" ID="lblAdres" Font-Size="12px" style="margin-left: 25px"></asp:Label><br /><br />
        <input placeholder="Adres girerek arayın; Örnek: İstanbul Pendik Ankara Caddesi" onkeydown="return clickButton(event,'btnAra')" type="text" id="inputAdresArama" style="margin-left: 25px; width: 400px" />
        <input type="button" id="btnAra" value="Ara" onclick="Ara()" />
        <br /><br />
        <div id="googleMap" style="width:100%;height:400px; margin-left: 10px"></div>
        <input id="inputMapAdres" type="text" disabled="disabled" runat="server" value="" style="margin-left: 10px; width: 100%; margin-right: 5px;" />
    <br /><br />
    <asp:Button ID="btnAlBakalim" runat="server" Text="Konumu Kaydet" style="margin-left: 10px; font-size: 16px" onclick="btnAlBakalim_Click" />
    <br /><br />
        </td>
        </tr>
        </table>
        </div>
    <uc1:ucAlt ID="ucAlt1" runat="server" />
    </form>
</body>
</html>

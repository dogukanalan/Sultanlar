<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Sultanlar.WebUI.musteri._default" %>

<%@ Register src="ucAlt.ascx" tagname="ucAlt" tagprefix="uc1" %>

<%@ Register src="ucProgress.ascx" tagname="ucProgress" tagprefix="uc2" %>

<%@ Register src="ucMesajlar.ascx" tagname="ucMesajlar" tagprefix="uc3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Sultanlar : Ana Sayfa</title>
    <meta name="description" content="Sultanlar Ev ihtiyaç Maddeleri Pazarlama A.Ş. bünyesinde bir çok ticari ve sınai kuruluşları bulunduran Sultanlar Şirketler Grubu içerisinde yer almaktadır." />
    <meta name="keywords" content="sultanlar a.ş., sultanlar grup, happy family, bulgurium, johnson wax, scj, tibet, henkel, türk Henkel kimya, vileda, fhp, st grup, korozo, aktif kozmetik, sultanlar grup, arımama, sultanlar" />
    <script type="text/javascript">
        function invisible() {
            if (document.getElementById('divFiyatTipi') != null) {
                window.location.href = document.getElementById('lbFiyatTipiKapat').href;
                return false;
            }
            else if (document.getElementById('divAnlasma') != null) {
                window.location.href = document.getElementById('btnAltCariEkleVazgec').href;
                return false;
            }
            else if (document.getElementById('divAnlasmaHata') != null) {
                window.location.href = document.getElementById('lbAnlasmaHata').href;
                return false;
            }
            else if (document.getElementById('divAnlasmaKaydedildiKapat') != null) {
                window.location.href = document.getElementById('lbAnlasmaKaydedildiKapat').href;
                return false;
            }
            else if (document.getElementById('divAltCariHata') != null) {
                window.location.href = document.getElementById('lbAltCariHataKapat').href;
                return false;
            }
            else if (document.getElementById('divAktiviteHata') != null) {
                window.location.href = document.getElementById('lbAktiviteHata').href;
                return false;
            }
            else if (document.getElementById('divAltCariEkle') != null) {
                window.location.href = document.getElementById('btnAltCariKapat').href;
                return false;
            }
            else if (document.getElementById('divSatTemAnaCariSubeleri') != null) {
                window.location.href = document.getElementById('lbSatTemAnaCariSubeleri').href;
                return false;
            }
            else if (document.getElementById('divTarih') != null) {
                window.location.href = document.getElementById('lbTarihKapat').href;
                return false;
            }
            else if (document.getElementById('divFarkliZiyaret') != null) {
                window.location.href = document.getElementById('lbFarkliZiyaretKapat').href;
                return false;
            }
            else if (document.getElementById('divRiskLimitHata') != null) {
                window.location.href = document.getElementById('lbRiskLimitHata').href;
                return false;
            }
            else if (document.getElementById('divAnlasmaliFiyatHata') != null) {
                window.location.href = document.getElementById('lbAnlasmaliFiyatHata').href;
                return false;
            }
            else if (document.getElementById('divFiyatlarFiyatTipi') != null) {
                window.location.href = document.getElementById('lbFiyatlarFiyatTipiKapat').href;
                return false;
            }
            else if (document.getElementById('divMesaj') != null) {
                window.location.href = document.getElementById('lbMesajKapat').href;
                return false;
            }
            else if (document.getElementById('divMusteriArama') != null) {
                window.location.href = document.getElementById('lbMusteriAramaKapat').href;
                return false;
            }
            else if (document.getElementById('divSonZiyaret') != null) {
                window.location.href = document.getElementById('lbSonZiyaretKapat').href;
                return false;
            }
            else if (document.getElementById('divZiyaretHata') != null) {
                window.location.href = document.getElementById('lbZiyaretHataKapat').href;
                return false;
            }
            else if (document.getElementById('divZiyaretHata2') != null) {
                window.location.href = document.getElementById('lbZiyaretHataKapat2').href;
                return false;
            }
            else if (document.getElementById('divZiyaretHata3') != null) {
                window.location.href = document.getElementById('lbZiyaretHataKapat3').href;
                return false;
            }
        }
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
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;

            return true;
        }
        function BilgiGoster(bilgi) {
            document.getElementById('spanBilgi').innerHTML = bilgi;
        }
        function SayfaYukari() {
            if (asagi) {
                //alert(scrollnerede);
                //window.scroll(0, document.getElementById('inputScroolY').value);
            }
            else {
                scrollnerede = document.body.scrollTop;
                //alert(scrollnerede);
                window.scroll(0, 0);
            }
        }
        function startWin(win) {
//            if (navigator.appName == "Microsoft Internet Explorer") {
//                var param = "toolbar=no,location=no,status=no,menubar=no,scrollbars=yes,width=800,height=150,noresize";
//                window.open("fiyatlisteindir.aspx?fid=" + win.toString(), "_blank", param);
//            }
//            else {
//                yenipencere = window.open("fiyatlisteindir.aspx?fid=" + win.toString(), "Fiyat Liste İndirme", "toolbar=no,location=no,status=no,menubar=no,scrollbars=yes,width=800,height=150,noresize");
//                yenipencere.moveTo(0, 0);
//            }
            window.location.href = "fiyatlisteindir.aspx?fid=" + win.toString();
        }
        function startWinXML(win) {
//            if (navigator.appName == "Microsoft Internet Explorer") {
//                var param = "toolbar=no,location=no,status=no,menubar=no,scrollbars=yes,width=800,height=150,noresize";
//                window.open("fiyatlisteindir.aspx?fid=" + win.toString() + "&xml=yes", "_blank", param);
//            }
//            else {
//                yenipencere = window.open("fiyatlisteindir.aspx?fid=" + win.toString() + "&xml=yes", "Fiyat Liste İndirme", "toolbar=no,location=no,status=no,menubar=no,scrollbars=yes,width=800,height=150,noresize");
//                yenipencere.moveTo(0, 0);
//            }
            window.location.href = "fiyatlisteindir.aspx?fid=" + win.toString() + "&xml=yes";
        }
        function startWinIsXML(win) {
            //            if (navigator.appName == "Microsoft Internet Explorer") {
            //                var param = "toolbar=no,location=no,status=no,menubar=no,scrollbars=yes,width=800,height=150,noresize";
            //                window.open("fiyatlisteindir.aspx?fid=" + win.toString() + "&xml=yes", "_blank", param);
            //            }
            //            else {
            //                yenipencere = window.open("fiyatlisteindir.aspx?fid=" + win.toString() + "&xml=yes", "Fiyat Liste İndirme", "toolbar=no,location=no,status=no,menubar=no,scrollbars=yes,width=800,height=150,noresize");
            //                yenipencere.moveTo(0, 0);
            //            }
            window.location.href = "fiyatlisteindir.aspx?fid=" + win.toString() + "&isxml=yes";
        }
        function startWinPtXML(win) {
            //            if (navigator.appName == "Microsoft Internet Explorer") {
            //                var param = "toolbar=no,location=no,status=no,menubar=no,scrollbars=yes,width=800,height=150,noresize";
            //                window.open("fiyatlisteindir.aspx?fid=" + win.toString() + "&xml=yes", "_blank", param);
            //            }
            //            else {
            //                yenipencere = window.open("fiyatlisteindir.aspx?fid=" + win.toString() + "&xml=yes", "Fiyat Liste İndirme", "toolbar=no,location=no,status=no,menubar=no,scrollbars=yes,width=800,height=150,noresize");
            //                yenipencere.moveTo(0, 0);
            //            }
            window.location.href = "fiyatlisteindir.aspx?fid=" + win.toString() + "&ptxml=yes";
        }
        function Checkboxes(controlname, value) {
            var elm = document.getElementById(controlname);
            var checkBoxes = elm.getElementsByTagName("input");
            for (i = 0; i < checkBoxes.length; i++) {
                checkBoxes[i].checked = value;
            }
        }
        function yazma(evt) {
            return false;
        }

        function flGoster() {
            $("#divFl").show(1000);
        }

        function flGizle() {
            $("#divFl").hide(1000);
        }

        function handleClick(cb) {
            if (cb.checked) {
                document.getElementById('cbButunUrunler').style.visibility = 'visible';
                document.getElementById('labelButunUrunler').style.visibility = 'visible';
            }
            else {
                document.getElementById('cbButunUrunler').style.visibility = 'hidden';
                document.getElementById('labelButunUrunler').style.visibility = 'hidden';
            }
        }

        function lbZiyaretBaslat_Click() {
            //createCookie("sulZiyBaslangic", document.getElementById("txtCoords1").value, 1);
        }

        function onclientclickdeneme() {
            alert('');
        }

        function lbZiyaretSonlandirClick() {
            var oncekinokta = "0,0";
            //if (document.getElementById("txtCoords1onceki").value != "0,0") {
            //    oncekinokta = document.getElementById("txtCoords1onceki").value;
            //}
            //else {
                oncekinokta = readCookie("sulZiyBaslangic");
            //}

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
    </script>        <script type="text/javascript" src="js/jquery-1.2.6.pack.js"></script>
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
            else $("#top").fadeOut(500);
        });
    </script>    <style type="text/css">
        #top{bottom:5px;right:5px;background:#147;padding:5px;color:#fff;font:bold 11px verdana;position:fixed;display:none;cursor:default;}
        .rutArkaTrue { background: #D3EAFF; filter: alpha(opacity=80); -moz-opacity: .80; opacity: .80; }
    </style>
    <link rel="stylesheet" type="text/css" href="StyleSheet.css" />

    <%--<script type="text/javascript" src="https://maps.google.com/maps/api/js?sensor=true"></script>--%>
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
//            document.getElementById('txtCoords1').value = position.coords.latitude + "," + position.coords.longitude;
//            document.getElementById('txtCoords').value = "<table border='1' cellpadding='1' cellspacing='0'><tr><th>Timestamp</th><td>" + position.timestamp +
//            "<tr><th>Latitude (WGS84)</th><td>" + position.coords.latitude + " deg</td></tr>" +
//            "<tr><th>Longitude (WGS84)</th><td>" + position.coords.longitude + " deg</td></tr></table>";

            positionSuccess(position);
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
                navigator.geolocation.getCurrentPosition(displayPosition, displayError, { maximumAge: 60000, timeout: 30000, enableHighAccuracy: false });

            } else {
                document.getElementById('txtCoords1').value = '0,0';
                document.getElementById('txtCoords').value = 'Tarayıcı konuma erişmeyi desteklemiyor.';
            }
        }

        function MapStyle() {
            return '[{ "featureType": "landscape", "elementType": "geometry", "stylers": [{ "saturation": "-100"}] }, { "featureType": "poi", "elementType": "labels", "stylers": [{ "visibility": "on"}] }, { "featureType": "poi", "elementType": "labels.text.stroke", "stylers": [{ "visibility": "on"}] }, { "featureType": "road", "elementType": "labels.text", "stylers": [{ "color": "#545454"}] }, { "featureType": "road", "elementType": "labels.text.stroke", "stylers": [{ "visibility": "off"}] }, { "featureType": "road.highway", "elementType": "geometry.fill", "stylers": [{ "saturation": "-87" }, { "lightness": "-40" }, { "color": "#ffffff"}] }, { "featureType": "road.highway", "elementType": "geometry.stroke", "stylers": [{ "visibility": "off"}] }, { "featureType": "road.highway.controlled_access", "elementType": "geometry.fill", "stylers": [{ "color": "#f0f0f0" }, { "saturation": "-22" }, { "lightness": "-16"}] }, { "featureType": "road.highway.controlled_access", "elementType": "geometry.stroke", "stylers": [{ "visibility": "off"}] }, { "featureType": "road.highway.controlled_access", "elementType": "labels.icon", "stylers": [{ "visibility": "on"}] }, { "featureType": "road.arterial", "elementType": "geometry.stroke", "stylers": [{ "visibility": "off"}] }, { "featureType": "road.local", "elementType": "geometry.stroke", "stylers": [{ "visibility": "off"}] }, { "featureType": "transit", "elementType": "labels.icon", "stylers": [{ "visibility": "off"}] }, { "featureType": "water", "elementType": "geometry.fill", "stylers": [{ "saturation": "-52" }, { "hue": "#00e4ff" }, { "lightness": "-16"}]}]';
        }

        function KisiyiGoster() {
                var p11 = parseFloat(document.getElementById("txtCoords1").value.substring(0, document.getElementById("txtCoords1").value.indexOf(",")));
                var p12 = parseFloat(document.getElementById("txtCoords1").value.substring(document.getElementById("txtCoords1").value.indexOf(",") + 1));
                
                var marker = new google.maps.Marker({ position: { lat: p11, lng: p12 }, title: "Buradasınız", label: "B" });
                var mapProp = {
                    center: marker.position,
                    disableDefaultUI: true,
                    zoom: 14,
                    styles: JSON.parse(MapStyle())
                };
                var map = new google.maps.Map(document.getElementById("divMapBurada"), mapProp);
                marker.setMap(map);
        }

        function HaritaBuyutKucult() {
            var buyut = document.getElementById('divInsert').style.left == '732px';

            if (buyut) {
                document.getElementById('divInsert').style.zIndex = '200';
                document.getElementById('divInsert').style.position = 'fixed';
                document.getElementById('divInsert').style.left = '0px';
                document.getElementById('divInsert').style.top = '0px';
                document.getElementById('divMapBurada').style.height = $(window).height() + 'px';
                document.getElementById('divMapBurada').style.width = ($(window).width() - 2) + 'px';
            }
            else {
                document.getElementById('divInsert').style.zIndex = '0';
                document.getElementById('divInsert').style.position = 'absolute';
                document.getElementById('divInsert').style.left = '732px';
                document.getElementById('divInsert').style.top = '35px';
                document.getElementById('divMapBurada').style.height = '280px';
                document.getElementById('divMapBurada').style.width = '280px';
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
            document.getElementById('txtCoords1').value = coords.latitude.toFixed(6) + ',' + coords.longitude.toFixed(6);

            
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
                document.getElementById('txtCoords').value = resp[0].formatted_address;
            });

            KisiyiGoster();
        }

        function contains(array, item) {
            for (var i = 0, I = array.length; i < I; ++i) {
                if (array[i] == item) return true;
            }
            return false;
        }

    </script>

<script type="text/javascript" src="js/jquery.tipTip.js"></script>
<script type="text/javascript" src="js/jquery.tipTip.minified.js"></script>
<link rel="stylesheet" type="text/css" href="js/tipTip.css" />

</head>
<body style="margin: 0 0 0 0;background-color: #EFEEEA;" onload="KoordinatBaslat()"><%----%>
    <form id="form1" runat="server"><div id="top" style="z-index: 20;">Yukarı Çık</div>
    <div id="infoCoords" style="display: none" runat="server">Yeriniz belirleniyor...</div>
    <div id="map_canvas" style="display: none"></div>
    <asp:ScriptManager ID="AjaxScripts" runat="server" AsyncPostBackTimeout="500">
    </asp:ScriptManager>
    <script type="text/javascript">
        Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(function (evt, args) {
            $("input[type=submit], input[type=button]").button();
            $("a[id$='lbSatTemAnaCariSubeleri']").button();
            $('#cbEFaturaAliasKaydet').button();
            $('#rblZiyaretSonlandirmaSebepleri').buttonset().find('label').width(300);
            $('#cbTariheGore').button();
            $('#rbEFaturaAliasBelirleme').button();
            $('#rbEFaturaAliasIlon').button();
            $('#rbEFaturaAliasEczanem').button();
            $('#rbEFaturaAliasTebeos').button();
            $(".suruklenebilir").draggable();

            $("#datepickerAnlasmaBaslangic").datepicker({ changeMonth: true, changeYear: true, dateFormat: 'dd/mm/yy' });
            $("#datepickerAnlasmaBitis").datepicker({ changeMonth: true, changeYear: true, dateFormat: 'dd/mm/yy' });
            $("a[id$='lbAnlasmaHesapla']").button();
            $("a[id$='lbAnlasmaGir']").button();
            $("a[id$='lbAnlasmaKapat']").button();
            $("a[id$='btnAltCariEkle']").button();
            $("a[id$='btnAltCariEkleVazgec']").button();

            $(document).ready(function () {
                $("#dlSatTemAnaCariSubeleri input:radio").attr("name", "grSecim");
                $("#divFl").hide();
            });
            
        });
    </script>
    <asp:UpdateProgress ID="DivAjaxProg" runat="server">
        <ProgressTemplate>
            <uc2:ucProgress ID="ucProgress1" runat="server" />
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdatePanel runat="server" ID="divAjaxDefault">
        <Triggers>
        <asp:PostBackTrigger ControlID="lbAnlasmaGir" />
        </Triggers>
        <ContentTemplate>

    <div id="tiptip_holder">
    <div id="tiptip_content">
    <div id="tiptip_arrow">
    <div id="tiptip_arrow_inner"></div>
    </div>
    </div>
    </div>

    <div style="width: 100%; font-size: 9px; font-family: Verdana; background-color: #EFEEEA; border-bottom: 1px solid #FFCFB2">
    <table cellpadding="5" cellspacing="0">
    <tr>
    <td style="width: 800px;" valign="middle">
        <table cellpadding="0" cellspacing="0"><tr><td>
        <input type="button" value="Giriş" disabled="disabled" /> 
        <input type="button" value="Aktiviteler" onclick="javascript:window.location.href='aktiviteler.aspx'" /> 
        <input type="button" value="H.Bedelleri" onclick="javascript:window.location.href='hizmetbedelleri.aspx'" /> 
        <input type="button" value="Anlaşmalar" onclick="javascript:window.location.href='anlasmalar.aspx'" /> 
        <input type="button" value="Siparişler" onclick="javascript:window.location.href='siparisler.aspx'" /> 
        <input type="button" value="İadeler" onclick="javascript:window.location.href='iadeler.aspx'" /> 
        <input type="button" value="Tahsilatlar" onclick="javascript:window.location.href='odemeler.aspx'" /> 
        <input type="button" value="Raporlar" onclick="javascript:window.location.href='hesapayrinti.aspx'" /> 
        <input type="button" value="Üye İşlemleri" onclick="javascript:window.location.href='uyelik.aspx'" /> 
        <input type="button" value='Mesajlar (<%= Sultanlar.DatabaseObject.Internet.GonderilenMesajlar.GetObjectCount(((Sultanlar.DatabaseObject.Internet.Musteriler)Session["Musteri"]).pkMusteriID).ToString() %>)' onclick="javascript:window.location.href='mesajlar.aspx'" /></td><td align="left"></td></tr></table>
        <span id="spanBilgi"></span>
        <%--<b><i><asp:HyperLink ID="hlSatistaOnAdim" runat="server" NavigateUrl="img/satista10adim.jpg" Target="_blank" Text="Satışta On Adım" Visible="false"></asp:HyperLink></i></b>--%>
    </td>
    <td style="width: 200px; font-family: Gisha; font-size: 12px" align="right">
        <table cellpadding="0" cellspacing="0"><tr><td><asp:Label ID="Label1" runat="server"></asp:Label>&nbsp;&nbsp;&nbsp;</td><td><asp:ImageButton runat="server" ID="ImageButton1" OnClick="ImageButton1_Click" ImageUrl="img/ic_logout.png" /></td></tr></table>
    </td>
    </tr>
    </table>
    </div>

            <uc3:ucMesajlar ID="ucMesajlar1" runat="server" />
            
            <div runat="server" id="divInsert" style="position: absolute; width: 60px; height: 50px; 
                z-index: 0; left: 732px; top: 35px; padding: 2px; font-family: Tahoma; font-size: 10px">
                 <table cellpadding="0" cellspacing="0" style="width:100%">
                 <tr>
                 <td></td>
                 <td align="left">
                    <%--<a href="saticikampanya.html"><img src="temp/54.jpg" width="278px" alt="ZIPBAG" /></a>--%>
                    <button type="button" onclick="HaritaBuyutKucult()" style="width: 100%; height: 24px; border: solid 0px black; color: dimgrey; font-size: 10px">Haritayı Büyüt - Küçült</button>
                    <div id="divMapBurada" style="width: 280px; height: 280px"></div>
                 </td>
                 </tr>
                 </table>
            </div>

            <div style="position: absolute; width: 450px; height: 150px; z-index: 1; left: 275px;
                top: 50px; font-family: Verdana; font-size: 10px;" runat="server" id="divZiyaret" visible="false" class="suruklenebilir">
                <div style="font-size: 18px; padding: 10px 10px 10px 10px; vertical-align: middle">Ziyaret Ayrıntıları</div>
                <asp:Label runat="server" Width="20px"></asp:Label>
                <span style="color: #D00000">Ziyaret Başlatılan Şube:</span> 
                <asp:Label runat="server" ID="lblZiyaretSubesi"></asp:Label>
                <br />
                <asp:Label runat="server" Width="20px"></asp:Label>
                <span style="color: #D00000">Ziyaret Başlama Zamanı:</span> 
                <asp:Label runat="server" ID="lblZiyaretBaslangic"></asp:Label>
                <br /><br /><br />
                <asp:Label runat="server" Width="150px"></asp:Label>
                <a href="musteriresim.aspx" style="color: Green; font-size: 12px; 
                    height: 12px; border: 1px solid #4E9CAF; padding: 5px; text-align: center; border-radius: 5px; 
                    font-weight: bold; text-decoration: none; margin: 5px;">Resim Çek</a>
                <br /><br /><br />
                <asp:Label runat="server" Width="40px"></asp:Label>
                <asp:LinkButton runat="server" ID="lbZiyaretIptal" OnClick="lbZiyaretIptal_Click" style="color: Red; font-size: 12px;
                    height: 12px; border: 1px solid #4E9CAF; padding: 5px; text-align: center; border-radius: 5px; 
                    font-weight: bold; text-decoration: none; margin: 5px;">Ziyareti İptal Et</asp:LinkButton>
                <asp:Label runat="server" Width="50px"></asp:Label>
                <asp:LinkButton runat="server" ID="lbZiyaretSonlandirUst" style="color: Green; font-size: 12px;
                    height: 12px; border: 1px solid #4E9CAF; padding: 5px; text-align: center; border-radius: 5px; 
                    font-weight: bold; text-decoration: none; margin: 5px;" OnClientClick="lbZiyaretSonlandirClick()" OnClick="lbZiyaretSonlandirUst_Click">Ziyaret Sonlandır</asp:LinkButton>
            </div>
            
            <div style="position: absolute; width: 400px; height: 100px; z-index: 4; left: 300px;
                top: 150px;" runat="server" id="divZiyaretHata" visible="false" class="suruklenebilir">
                <div style="position: fixed; width: 100%; height: 100%; z-index: -1; left: 0; top: 0;
                filter: alpha(opacity=40); -moz-opacity: .40; opacity: .40; background-color: #000000" onclick="invisible()"></div>
                <table style="width: 100%; height: 100%; background-color: #ffffff; font-family: Tahoma; font-size: 12px;
                    border: 1px solid #D1D1D1; border-radius: 5px; padding: 5px;">
                <tr>
                <td align="center" valign="middle" style="padding-top: 15px; padding-bottom: 15px">
                    <span style="color: #C00000">Bir ziyareti bitirmeden başka bir ziyaret başlatamazsınız. Ziyareti sonlandırmak için "Son Ziyaretim" ekranını kullanabilirsiniz.</span>
                    <br /><br />
                    <asp:LinkButton runat="server" ID="lbZiyaretHataKapat" 
                        onclick="lbZiyaretHataKapat_Click">Kapat</asp:LinkButton>
                </td>
                </tr>
                </table>
            </div>
            
            <div style="position: absolute; width: 400px; height: 100px; z-index: 4; left: 300px;
                top: 150px;" runat="server" id="divZiyaretHata2" visible="false" class="suruklenebilir">
                <div style="position: fixed; width: 100%; height: 100%; z-index: -1; left: 0; top: 0;
                filter: alpha(opacity=40); -moz-opacity: .40; opacity: .40; background-color: #000000" onclick="invisible()"></div>
                <table style="width: 100%; height: 100%; background-color: #ffffff; font-family: Tahoma; font-size: 12px;
                    border: 1px solid #D1D1D1; border-radius: 5px; padding: 5px;">
                <tr>
                <td align="center" valign="middle" style="padding-top: 15px; padding-bottom: 15px">
                    <input type="hidden" runat="server" id="inputZiyaretHata2smref" />
                    <input type="hidden" runat="server" id="inputZiyaretHata2tip" />
                    <input type="hidden" runat="server" id="inputZiyaretHata2barkod" />
                    <input type="hidden" runat="server" id="inputZiyaretHata2ziygun" />
                    <span style="color: #C00000">Ziyaret yapılacak olan müşterinin konum bilgisi sistemde kayıtlı değil. Konumu kayıtlı olmayan bir müşteriye ziyaret başlatılamaz.</span>
                    <br /><br />
                    <asp:LinkButton Text="Mevcut konumunuzu müşterinin konumu olarak kaydetmek ve ziyareti başlatabilmek için tıklayın." runat="server" ID="lbZiyaretHata2konum" OnClick="lbZiyaretHata2konum_Click" />
                    <br /><br />
                    Mevcut konumunuz: <asp:Label runat="server" ID="lblZiyaretHata2konum"></asp:Label><br /><br />
                    <asp:LinkButton runat="server" ID="lbZiyaretHataKapat2" 
                        onclick="lbZiyaretHataKapat2_Click">Kapat</asp:LinkButton>
                </td>
                </tr>
                </table>
            </div>
            
            <div style="position: absolute; width: 400px; height: 100px; z-index: 4; left: 300px;
                top: 150px;" runat="server" id="divZiyaretHata3" visible="false" class="suruklenebilir">
                <div style="position: fixed; width: 100%; height: 100%; z-index: -1; left: 0; top: 0;
                filter: alpha(opacity=40); -moz-opacity: .40; opacity: .40; background-color: #000000" onclick="invisible()"></div>
                <table style="width: 100%; height: 100%; background-color: #ffffff; font-family: Tahoma; font-size: 12px;
                    border: 1px solid #D1D1D1; border-radius: 5px; padding: 5px;">
                <tr>
                <td align="center" valign="middle" style="padding-top: 15px; padding-bottom: 15px">
                    <span style="color: #C00000">Konum bilginiz alınamadığı için ziyaret başlatılamaz. Telefonun konum bilgisinin açık olduğundan ve bu sayfaya izin verildiğinden emin olup tekrar deneyiniz.</span>
                    <br /><br />
                    <asp:LinkButton runat="server" ID="lbZiyaretHataKapat3" 
                        onclick="lbZiyaretHataKapat3_Click">Kapat</asp:LinkButton>
                </td>
                </tr>
                </table>
            </div>

            <div style="position: absolute; width: 960px; min-height: 200px; z-index: 4; left: 20px;
                top: 50px;" runat="server" id="divFiyatTipi" visible="false" class="suruklenebilir">
                <div style="position: fixed; width: 100%; height: 100%; z-index: -1; left: 0; top: 0;
                filter: alpha(opacity=40); -moz-opacity: .40; opacity: .40; background-color: #000000" onclick="invisible()"></div>
                <%--<div style="position: absolute; z-index: 5; left: 91; top: 60;"><img src="img/eksi.png" alt="Eksi" /></div>
                <div style="position: absolute; z-index: 5; left: 217; top: 60;"><img src="img/arti.png" alt="Artı" /></div>
                <div style="position: absolute; z-index: 5; left: 353; top: 60;"><img src="img/esittir.png" alt="Eşittir" /></div>
                <div style="position: absolute; z-index: 5; left: 513; top: 60;"><img src="img/arti.png" alt="Artı" /></div>
                <div style="position: absolute; z-index: 5; left: 603; top: 60;"><img src="img/arti.png" alt="Artı" /></div>
                <div style="position: absolute; z-index: 5; left: 687; top: 60;"><img src="img/arti.png" alt="Artı" /></div>
                <div style="position: absolute; z-index: 5; left: 767; top: 60;"><img src="img/arti.png" alt="Artı" /></div>
                <div style="position: absolute; z-index: 5; left: 852; top: 60;"><img src="img/esittir.png" alt="Eşittir" /></div>--%>
                <table style="width: 100%; height: 100%; background-color: #ffffff; font-family: Tahoma; font-size: 12px;
                    border: 1px solid #D1D1D1; border-radius: 5px; padding: 5px;">
                <tr>
                <td>
                    <div style="width: 960px; text-align: center;">
                    <br />
                    <asp:Label runat="server" ID="lblFiyatTipCH" style="color: #26237A" Font-Bold="true"></asp:Label><br /><br /><br />
                    </div>
                    <table cellpadding="1" cellspacing="0" runat="server" id="tblFiyatTipiPanelindeBakiyeler" style="font-size: 10px">
                        <tr style="color: #D00000">
                            <td style="width: 100px; text-align: center; border-left: 1px dotted Red; border-top: 1px dotted Red;">Kredi Limiti</td>
                            <td style="width: 50px; text-align: center; border-left: 1px dotted Black; border-top: 1px dotted Black;">VB Vd.</td>
                            <td style="width: 80px; text-align: center; border-top: 1px dotted Black;">VB Top.</td>
                            <td style="width: 50px; text-align: center; border-top: 1px dotted Black;">VGB Vd.</td>
                            <td style="width: 80px; text-align: center; border-top: 1px dotted Black;">VGB Top.</td>
                            <td style="width: 80px; text-align: center; border-top: 1px dotted Black;">Top.B/A Vd.</td>
                            <td style="width: 80px; text-align: center; border-top: 1px dotted Black;">Top.B/A</td>
                            <td style="width: 90px; text-align: center; border-top: 1px dotted Black; border-right: 1px dotted Red;">Ç/S Riski</td>
                            <td style="width: 85px; text-align: center; border-top: 1px dotted Red;">İrs.Top.(Koli)</td>
                            <td style="width: 85px; text-align: center; border-top: 1px dotted Red;">Açık Sip.(Koli)</td>
                            <td style="width: 80px; text-align: center; border-top: 1px dotted Red;">Bak.Sip.(Koli)</td>
                            <td style="width: 100px; text-align: center; border-left: 1px dotted Red; border-top: 1px dotted Red; border-right: 1px dotted Red;"><%--<asp:Label runat="server" ID="lblRiskBakiyesiBaslik" Width="120px">--%>Kullanılabilir Limit<%--</asp:Label>--%></td>
                        </tr>
                        <tr>
                            <td style="width: 100px; text-align: center; border-left: 1px dotted Red; border-bottom: 1px dotted Red"><asp:Label runat="server" ID="lblRiskLimiti"></asp:Label></td>
                            <td style="width: 50px; text-align: center; border-left: 1px dotted Black; border-bottom: 1px dotted Black"><asp:Label runat="server" ID="lblVBVd"></asp:Label></td>
                            <td style="width: 80px; text-align: center; border-bottom: 1px dotted Black"><asp:Label runat="server" ID="lblVBTop"></asp:Label></td>
                            <td style="width: 50px; text-align: center; border-bottom: 1px dotted Black"><asp:Label runat="server" ID="lblVGBGun"></asp:Label></td>
                            <td style="width: 80px; text-align: center; border-bottom: 1px dotted Black"><asp:Label runat="server" ID="lblVGBToplam"></asp:Label></td>
                            <td style="width: 80px; text-align: center; border-bottom: 1px dotted Black"><asp:Label runat="server" ID="lblBakiyeVade"></asp:Label></td>
                            <td style="width: 80px; text-align: center; border-bottom: 1px dotted Black"><asp:Label runat="server" ID="lblBakiye"></asp:Label></td>
                            <td style="width: 90px; text-align: center; border-bottom: 1px dotted Black; border-right: 1px dotted Red;"><asp:Label runat="server" ID="lblCekSenetRisk"></asp:Label></td>
                            <td style="width: 85px; text-align: center; border-bottom: 1px dotted Red"><asp:Label runat="server" ID="lblIrs"></asp:Label></td>
                            <td style="width: 85px; text-align: center; border-bottom: 1px dotted Red"><asp:Label runat="server" ID="lblSiparisToplam"></asp:Label></td>
                            <td style="width: 80px; text-align: center; border-bottom: 1px dotted Red"><asp:Label runat="server" ID="lblSiparisToplamBakiye"></asp:Label></td>
                            <td style="width: 100px; text-align: center; border-left: 1px dotted Red; border-bottom: 1px dotted Red; border-right: 1px dotted Red;"><asp:Label runat="server" ID="lblRiskBakiyesi"></asp:Label></td>
                        </tr>
                    </table>
                </td>
                </tr>
                <tr>
                <td align="left" valign="middle" style="padding-top: 15px; padding-left: 600px; padding-right: 100px">
                <fieldset style="border: 1px solid #CCCCCC; margin: 0px 10px 0px 10px; border-radius: 5px; padding: 5px;">
                <legend style="color: #C00000">Diğer Satış Temsilcileri</legend>
                <asp:DataList runat="server" ID="dlFiyatTipiNSTs" OnItemDataBound="dlFiyatTipiNSTs_DataBound">
                <HeaderTemplate><table cellpadding="1" cellspacing="0"></HeaderTemplate>
                <ItemTemplate>
                        <tr>
                            <td style="padding-left: 15px"><%#Eval("[SAT TEM]")%></td>
                        </tr>
                </ItemTemplate>
                <FooterTemplate></table></FooterTemplate>
                </asp:DataList>
                <asp:Label runat="server" ID="lblFiyatTipiNSTsYok" Text=" - Satış temsilcisi bulunamadı - " Font-Italic="true" Visible="false"></asp:Label>
                </fieldset>
                </td>
                </tr>
                <tr>
                <td align="center" valign="middle">
                    <br />
                    <span style="color: #C00000">Fiyat Tipini Belirleyiniz</span><br /><br />
                    <asp:CheckBox runat="server" AutoPostBack="false" ID="cbButunUrunler" Text="" Visible="false" style="visibility: hidden; zoom: 1.5" />
                    <label id="labelButunUrunler" style="visibility: hidden">Bütün Ürünler Gelsin</label>
                    <asp:CheckBox runat="server" AutoPostBack="false" ID="cbHizliSiparis" Text="Offline" Visible="false" onclick='handleClick(this);' />
                    <asp:DropDownList runat="server" ID="ddlFiyatTipleri" Height="25px" ForeColor="#006699"
                        onselectedindexchanged="ddlFiyatTipleri_SelectedIndexChanged" style="padding: 3px 3px 3px 3px;border:1px solid #CCCCCC;background:#ededed;"
                        Width="150px" AutoPostBack="True" ></asp:DropDownList><br /><br />
                    <asp:LinkButton runat="server" ID="lbFiyatTipiKapat" 
                        onclick="lbFiyatTipiKapat_Click">Kapat</asp:LinkButton>
                    <br /><br />
                    Sultanlar Whatsapp hattı: 0532 519 50 00
                    <br /><br />
                </td>
                </tr>
                </table>
            </div>

            <div style="position: absolute; width: 400px; height: 150px; z-index: 4; left: 300px;
                top: 150px;" runat="server" id="divFiyatlarFiyatTipi" visible="false" class="suruklenebilir">
                <div style="position: fixed; width: 100%; height: 100%; z-index: -1; left: 0; top: 0;
                filter: alpha(opacity=40); -moz-opacity: .40; opacity: .40; background-color: #000000" onclick="invisible()"></div>
                <table style="width: 100%; height: 100%; background-color: #ffffff; font-family: Tahoma; font-size: 12px;
                    border: 1px solid #D1D1D1; border-radius: 5px; padding: 5px;">
                <tr>
                <td align="center" valign="middle" style="padding-top: 15px">
                    <asp:Label runat="server" style="color: #26237A" Font-Bold="true"></asp:Label><br /><br />
                    <span style="color: #C00000">Fiyat Tipini Belirleyiniz</span><br /><br />
                    <asp:DropDownList runat="server" ID="ddlFiyatlarFiyatTipleri" Height="25px" ForeColor="#006699" 
                        onselectedindexchanged="ddlFiyatlarFiyatTipleri_SelectedIndexChanged" style="padding: 3px 3px 3px 3px;border:1px solid #CCCCCC;background:#ededed;"
                        Width="150px" AutoPostBack="True" ></asp:DropDownList><br /><br />
                    <asp:LinkButton runat="server" ID="lbFiyatlarFiyatTipiKapat" 
                        onclick="lbFiyatlarFiyatTipiKapat_Click">Kapat</asp:LinkButton>
                    <br /><br />
                    Sultanlar Whatsapp hattı: 0532 519 50 00
                </td>
                </tr>
                </table>
            </div>

            <div style="position: absolute; width: 960px; z-index: 2; left: 20px;
                top: 50px;" runat="server" id="divSatTemAnaCariSubeleri" visible="false" class="suruklenebilir">
                <div style="position: fixed; width: 100%; height: 100%; z-index: -1; left: 0; top: 0;
                filter: alpha(opacity=40); -moz-opacity: .40; opacity: .40; background-color: #000000" onclick="invisible()"></div>
                <%--<div style="position: absolute; z-index: 3; left: 93; top: 18;"><img src="img/eksi.png" alt="Eksi" /></div>
                <div style="position: absolute; z-index: 3; left: 219; top: 18;"><img src="img/arti.png" alt="Artı" /></div>
                <div style="position: absolute; z-index: 3; left: 355; top: 18;"><img src="img/esittir.png" alt="Eşittir" /></div>
                <div style="position: absolute; z-index: 3; left: 515; top: 18;"><img src="img/arti.png" alt="Artı" /></div>
                <div style="position: absolute; z-index: 3; left: 605; top: 18;"><img src="img/arti.png" alt="Artı" /></div>
                <div style="position: absolute; z-index: 3; left: 689; top: 18;"><img src="img/arti.png" alt="Artı" /></div>
                <div style="position: absolute; z-index: 3; left: 769; top: 18;"><img src="img/arti.png" alt="Artı" /></div>
                <div style="position: absolute; z-index: 3; left: 853; top: 18;"><img src="img/esittir.png" alt="Eşittir" /></div>--%>
                <input type="hidden" runat="server" id="inputGMREF" />
                <table style="width: 100%; background-color: #ffffff; font-family: Tahoma; font-size: 10px;
                    border: 1px solid #D1D1D1; border-radius: 5px; padding: 5px; margin-bottom: 20px;">
                <tr>
                    <td style="padding-top: 15px;" align="center">
                        <asp:Button runat="server" ID="btnAltCari" Width="200px" Text="Alt Cari Ekle" OnClick="btnAltCari_Click" 
                            BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" ForeColor="#6D8AAA" Visible="false" />
                            <asp:Label runat="server" Width="100px"></asp:Label>
                        <asp:Button runat="server" ID="btnGenelAktivite" Width="200px" Text="Genel Anlaşmasız Aktivite Gir" OnClick="btnGenelAktivite_Click" 
                            BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" ForeColor="#6D8AAA" Visible="false" />
                        <table cellpadding="1" cellspacing="0" style="width: 960px">
                        <tr style="color: #D00000">
                            <td style="width: 100px; text-align: center; border-left: 1px dotted Red; border-top: 1px dotted Red;">Kredi Limiti</td>
                            <td style="width: 50px; text-align: center; border-left: 1px dotted Black; border-top: 1px dotted Black;">VB Vd.</td>
                            <td style="width: 80px; text-align: center; border-top: 1px dotted Black;">VB Top.</td>
                            <td style="width: 50px; text-align: center; border-top: 1px dotted Black;">VGB Vd.</td>
                            <td style="width: 80px; text-align: center; border-top: 1px dotted Black;">VGB Top.</td>
                            <td style="width: 80px; text-align: center; border-top: 1px dotted Black;">Top.B/A Vd.</td>
                            <td style="width: 80px; text-align: center; border-top: 1px dotted Black; border-right: 1px dotted Black;">Top.B/A</td>
                            <td style="width: 90px; text-align: center; border-top: 1px dotted Red;">Ç/S Riski</td>
                            <td style="width: 85px; text-align: center; border-top: 1px dotted Red;">İrs.Top.</td>
                            <td style="width: 85px; text-align: center; border-top: 1px dotted Red;">Sip.Top.</td>
                            <td style="width: 80px; text-align: center; border-top: 1px dotted Red;">Bakiye Sip.Top.</td>
                            <td style="width: 100px; text-align: center; border-left: 1px dotted Red; border-top: 1px dotted Red; border-right: 1px dotted Red;">Kullanılabilir Limit</td>
                        </tr>
                        <tr>
                            <td style="width: 100px; text-align: center; border-left: 1px dotted Red; border-bottom: 1px dotted Red"><asp:Label runat="server" ID="lblSatTemRiskLimiti"></asp:Label></td>
                            <td style="width: 50px; text-align: center; border-left: 1px dotted Black; border-bottom: 1px dotted Black"><asp:Label runat="server" ID="lblSatTemVBVd"></asp:Label></td>
                            <td style="width: 80px; text-align: center; border-bottom: 1px dotted Black"><asp:Label runat="server" ID="lblSatTemVBTop"></asp:Label></td>
                            <td style="width: 50px; text-align: center; border-bottom: 1px dotted Black"><asp:Label runat="server" ID="lblSatTemVGBGun"></asp:Label></td>
                            <td style="width: 80px; text-align: center; border-bottom: 1px dotted Black"><asp:Label runat="server" ID="lblSatTemVGBToplam"></asp:Label></td>
                            <td style="width: 80px; text-align: center; border-bottom: 1px dotted Black"><asp:Label runat="server" ID="lblSatTemBakiyeVade"></asp:Label></td>
                            <td style="width: 80px; text-align: center; border-bottom: 1px dotted Black; border-right: 1px dotted Black;"><asp:Label runat="server" ID="lblSatTemBakiye"></asp:Label></td>
                            <td style="width: 90px; text-align: center; border-bottom: 1px dotted Red"><asp:Label runat="server" ID="lblSatTemCekSenetRisk"></asp:Label></td>
                            <td style="width: 85px; text-align: center; border-bottom: 1px dotted Red"><asp:Label runat="server" ID="lblSatTemIrs"></asp:Label></td>
                            <td style="width: 85px; text-align: center; border-bottom: 1px dotted Red"><asp:Label runat="server" ID="lblSatTemSiparisToplam"></asp:Label></td>
                            <td style="width: 80px; text-align: center; border-bottom: 1px dotted Red"><asp:Label runat="server" ID="lblSatTemSiparisToplamBakiye"></asp:Label></td>
                            <td style="width: 100px; text-align: center; border-left: 1px dotted Red; border-bottom: 1px dotted Red; border-right: 1px dotted Red;"><asp:Label runat="server" ID="lblSatTemRiskBakiyesi"></asp:Label></td>
                        </tr>
                    </table>
                    </td>
                </tr>
                <tr>
                <td valign="top" style="padding-top: 15px">
                    <table cellpadding="5" cellspacing="0">
                        <tr style="color: #D00000;">
                            <td style="width: 50px; text-align: center; height: 20px; border-bottom: 1px solid #CCCCCC"></td>
                            <td style="width: 100px; text-align: center; height: 20px; border-bottom: 1px solid #CCCCCC"><span class="kucukbilgiGoster" title="Siparişlerin bakiye kalmasını istiyorsanız işaretleyiniz">Bakiye Sipariş</span></td>
                            <%--<td style="width: 100px; text-align: center; height: 20px; border-bottom: 1px solid #CCCCCC">NST Son Ay Net S.</td>--%>
                            <td style="width: 80px; text-align: center; height: 20px; border-bottom: 1px solid #CCCCCC">Cari Kod</td>
                            <td style="width: 400px; text-align: center; height: 20px; border-bottom: 1px solid #CCCCCC">Cari Ünvan</td>
                            <td style="width: 80px;"></td>
                            <td></td>
                        </tr></table>
                    <div style="width: 100%; height: 100%;">
                    <asp:DataList ID="dlSatTemAnaCariSubeleri" runat="server">
                    <HeaderTemplate><table cellpadding="4" cellspacing="0">
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr onmouseover="Satir(this,true)" onmouseout="Satir(this,false)">
                            <td style="width: 50px; text-align: center">
                                <asp:LinkButton runat="server" OnClick="CariDuzenle_Click" CommandArgument='<%#Eval("SMREF") %>' Visible='<%#Convert.ToInt32(inputBayiGibi.Value) == 1%>'>Düzenle</asp:LinkButton>
                                <asp:LinkButton runat="server" OnClick="CariDuzenle_Click" CommandArgument='<%#Eval("SMREF") %>' Visible='<%#Convert.ToInt32(inputBayiGibi.Value) == 0%>'>Konum</asp:LinkButton>
                            </td>
                            <td style="width: 100px; text-align: center"><asp:CheckBox runat="server" AutoPostBack="true" Checked='<%# Sultanlar.DatabaseObject.Internet.WebMusteriEk.GetBakiye(Convert.ToInt32(Eval("SMREF")), (((Sultanlar.DatabaseObject.Internet.Musteriler)Session["Musteri"]).intSLSREF == 0 ? Convert.ToInt32(ddlSefAltlar.SelectedValue) : ((Sultanlar.DatabaseObject.Internet.Musteriler)Session["Musteri"]).intSLSREF)) %>' /></td>
                            <%--<td style="width: 100px; text-align: right;"><span runat="server" visible='<%#Eval("[MUS KOD]") != "--------"%>'><%#Eval("[TEDNETTOP]") != DBNull.Value ? Convert.ToDecimal(Eval("[TEDNETTOP]")).ToString("C3") : 0.ToString("C3")%></span></td>--%>
                            <td style="width: 80px; text-align: center"><%#Eval("[SMREF]")%></td>
                            <td style="width: 400px; text-align: left">
                            <asp:ImageButton runat="server" class="kucukbilgiGosterSade" ToolTip="İade ile ilgili kişiyi görmek için tıklayın" CommandArgument='<%#Eval("[SMREF]")%>' ImageUrl="img/iadeilgilivar.gif" AlternateText="İ" OnClick="ibIadeIlgili_Click" Visible='<%#Convert.ToBoolean(Eval("[SMREF]") != DBNull.Value) && Sultanlar.DatabaseObject.Internet.CariHesapEk.GetIadeIlgiliVarMiBySMREF(Convert.ToInt32(Eval("[SMREF]")))%>' />
                            <asp:ImageButton runat="server" class="kucukbilgiGosterSade" ToolTip="İade ile ilgili kişiyi görmek için tıklayın" CommandArgument='<%#Eval("[SMREF]")%>' ImageUrl="img/iadeilgiliyok.gif" AlternateText="İ" OnClick="ibIadeIlgili_Click" Visible='<%#Convert.ToBoolean(Eval("[SMREF]") != DBNull.Value) && !Sultanlar.DatabaseObject.Internet.CariHesapEk.GetIadeIlgiliVarMiBySMREF(Convert.ToInt32(Eval("[SMREF]")))%>' />
                            <span class="kucukbilgiGoster" title="<i>İlgili:</i> <%#Eval("ILGILI")%><br><i>Telefon:</i> <%#Eval("[TEL-1]")%><br><i>Cep Tel.:</i> <%#Eval("[CEP-1]")%><br><i>Eposta:</i> <%#Eval("[EMAIL-1]")%><br><br><%#Eval("ADRES").ToString()%><br><%#Eval("SEHIR")%>/<%#Eval("SEMT")%>"><%#Eval("[SUBE]")%></span>
                            </td>
                            <td style="width: 80px;">
                                <%--<asp:ImageButton runat="server" class="kucukbilgiGosterSade" ToolTip="Konum bilgisini almak için tıklayın" CommandArgument='<%#Eval("[SMREF]")%>' ImageUrl="img/iadeilgilivar.gif" AlternateText="K" OnClick="ibKonum_Click" Visible='<%#Convert.ToBoolean(Eval("[SMREF]") != DBNull.Value) && Sultanlar.DatabaseObject.Internet.Rutlar.GetKonum(Convert.ToInt32(Eval("[SMREF]")), Convert.ToInt32(inputBayiGibi.Value) == 1 ? 4 : 1) != string.Empty %>' />--%>
                                <%--<asp:ImageButton runat="server" class="kucukbilgiGosterSade" ToolTip="Konum bilgisini almak için tıklayın" CommandArgument='<%#Eval("[SMREF]")%>' ImageUrl="img/iadeilgiliyok.gif" AlternateText="K" OnClick="ibKonum_Click" Visible='<%#Convert.ToBoolean(Eval("[SMREF]") != DBNull.Value) && Sultanlar.DatabaseObject.Internet.Rutlar.GetKonum(Convert.ToInt32(Eval("[SMREF]")), Convert.ToInt32(inputBayiGibi.Value) == 1 ? 4 : 1) == string.Empty %>' />--%>
                                <asp:HyperLink CssClass="kucukbilgiGosterSade" ToolTip="Konumu Göster" Target="_blank" runat="server" NavigateUrl='<%#GetKonum(Convert.ToInt32(Eval("[SMREF]") != DBNull.Value ? Eval("[SMREF]") : "0"), Convert.ToInt32(inputBayiGibi.Value) == 1 ? 4 : 1)%>' Visible='<%#Convert.ToBoolean(Eval("[SMREF]") != DBNull.Value) && Sultanlar.DatabaseObject.Internet.Rutlar.GetKonum(Convert.ToInt32(Eval("[SMREF]")), Convert.ToInt32(inputBayiGibi.Value) == 1 ? 4 : 1) != string.Empty %>' Text="(KG)"></asp:HyperLink>
                                <%--<asp:LinkButton CssClass="kucukbilgiGosterSade" ToolTip="Konumu Sil" Target="_blank" runat="server" OnClick="KonumSil_Click" CommandArgument='<%#Eval("[SMREF]").ToString() + (Convert.ToInt32(inputBayiGibi.Value) == 1 ? 4 : 1).ToString()%>' Visible='<%#Convert.ToBoolean(Eval("[SMREF]") != DBNull.Value) && Sultanlar.DatabaseObject.Internet.Rutlar.GetKonum(Convert.ToInt32(Eval("[SMREF]")), 1) != string.Empty %>' Text="(KS)"></asp:LinkButton>--%>
                            </td>
                            <td>
                            <input type="hidden" value="false" id="inputBakiyeCikarma" runat="server" />
                            <input type="hidden" value='<%#Eval("[SMREF]") %>' id="SMREF" runat="server" />
                            <asp:LinkButton runat="server" OnClick="SiparisVer_Click" Visible='<%#Convert.ToInt32(inputBayiGibi.Value) == 0%>'>Sipariş ver</asp:LinkButton>
                            <asp:LinkButton runat="server" OnClick="Aktivite_Click" Visible='<%#Convert.ToInt32(inputBayiGibi.Value) == 1%>'>Aktivite</asp:LinkButton>
                            <asp:Label runat="server" Width="20px"></asp:Label>
                            <asp:LinkButton runat="server" OnClick="IadeVer_Click" Visible='<%#Convert.ToInt32(inputBayiGibi.Value) == 0%>'>İade talep</asp:LinkButton>
                            <asp:LinkButton runat="server" OnClick="Anlasma_Click" Visible='<%#Convert.ToInt32(inputBayiGibi.Value) == 1%>'>Anlaşma talep</asp:LinkButton>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate></table></FooterTemplate>
                </asp:DataList>
                </div>
                </td>
                </tr>
                <tr><td align="center" valign="bottom" style="padding-bottom: 15px; font-size: 12px;">
                    <asp:LinkButton runat="server" ID="lbSatTemAnaCariSubeleri" 
                        onclick="lbSatTemAnaCariSubeleri_Click">Kapat</asp:LinkButton></td>
                </tr>
                </table>
            </div>

            <div style="position: absolute; width: 400px; height: 270px; z-index: 3; left: 300px;
                top: 150px" runat="server" id="divTarih" visible="false" class="suruklenebilir">
                <div style="position: fixed; width: 100%; height: 100%; z-index: -1; left: 0; top: 0;
                filter: alpha(opacity=40); -moz-opacity: .40; opacity: .40; background-color: #000000" onclick="invisible()"></div>
                <table cellpadding="5" style="width: 100%; height: 100%; background-color: #ffffff; font-family: Tahoma; font-size: 12px;
                    border: 1px solid #D1D1D1; border-radius: 5px; padding: 5px;">
                <tr>
                <td align="center" valign="middle" colspan="2" style="font-size: 10px;">
                    <asp:CheckBox runat="server" ID="cbTariheGore" Checked="true" Text="Tarih süzmesi aktif" 
                        AutoPostBack="true" OnCheckedChanged="cbTariheGore_CheckedChanged" />
                </td>
                </tr>
                <tr>
                <td align="center" valign="middle">
                    <asp:Calendar ID="Calendar1" runat="server" BackColor="White" 
                        BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" 
                        Font-Names="Verdana" Font-Size="7pt" ForeColor="Black" Height="170px" 
                        Width="170px">
                        <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                        <NextPrevStyle VerticalAlign="Bottom" />
                        <OtherMonthDayStyle ForeColor="#808080" />
                        <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                        <SelectorStyle BackColor="#CCCCCC" />
                        <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                        <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                        <WeekendDayStyle BackColor="#FFFFCC" />
                    </asp:Calendar>
                </td>
                <td align="center" valign="middle">
                    <asp:Calendar ID="Calendar2" runat="server" BackColor="White" 
                        BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" 
                        Font-Names="Verdana" Font-Size="7pt" ForeColor="Black" Height="170px" 
                        Width="170px">
                        <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                        <NextPrevStyle VerticalAlign="Bottom" />
                        <OtherMonthDayStyle ForeColor="#808080" />
                        <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                        <SelectorStyle BackColor="#CCCCCC" />
                        <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                        <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                        <WeekendDayStyle BackColor="#FFFFCC" />
                    </asp:Calendar>
                </td>
                </tr>
                <tr>
                <td align="center" valign="middle" colspan="2">
                    <asp:LinkButton runat="server" ID="lbTarihKapat" OnClick="lbTarihKapat_Click">Uygula</asp:LinkButton>
                </td>
                </tr>
                </table>
            </div>

            <div style="position: absolute; width: 400px; height: 520px; z-index: 3; left: 300px;
                top: 20px" runat="server" id="divZiyaretSonlandirmaSebep" visible="false" class="suruklenebilir">
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

            <div style="position: absolute; width: 900px; z-index: 3; left: 50px;
                top: 50px" runat="server" id="divFarkliZiyaret" visible="false">
                <div style="position: fixed; width: 100%; height: 100%; z-index: -1; left: 0; top: 0;
                filter: alpha(opacity=40); -moz-opacity: .40; opacity: .40; background-color: #000000" onclick="invisible()"></div>
                <table cellpadding="5" style="width: 100%; height: 100%; background-color: #ffffff; font-family: Tahoma; font-size: 12px;
                    border: 1px solid #D1D1D1; border-radius: 5px; padding: 5px; margin-bottom: 20px;">
                <tr>
                <td align="center" valign="middle">
                    <asp:Label runat="server" ForeColor="#D00000" Font-Bold="true">Müşteri Seçiniz</asp:Label>
                </td>
                </tr>
                <tr>
                <td align="left" valign="middle" style="font-size: 10px;">
                    <div style="width: 100%; height: 100%">
                    <asp:TextBox runat="server" ID="txtFarkliZiyaretSube" Width="300px" placeholder="Müşteriyi buradan arayabilirsiniz..." onkeypress="return clickButton(event,'btnFarkliZiyaretAra')"></asp:TextBox>
                    <asp:Button runat="server" ID="btnFarkliZiyaretAra" Width="100px" Text="Ara" OnClick="lbFarkliZiyaretAc_Click" />
                    <br /><br />
                    <asp:Repeater runat="server" ID="rpZiyaretCariler">
                    <HeaderTemplate><table cellpadding="4" cellspacing="0"></HeaderTemplate>
                    <ItemTemplate>
                        <tr onmouseover="Satir(this,true)" onmouseout="Satir(this,false)">
                            <td style="width: 330px"><span class="kucukbilgiGoster" title="<i>İlgili:</i> <%#Eval("ILGILI")%><br><i>Telefon:</i> <%#Eval("[TEL-1]")%><br><i>Cep Tel.:</i> <%#Eval("[CEP-1]")%><br><i>Eposta:</i> <%#Eval("[EMAIL-1]")%><br><br><%#Eval("ADRES").ToString()%><br><%#Eval("SEHIR")%>/<%#Eval("SEMT")%>"><%#Eval("MUSTERI") %></span></td>
                            <td><span class="kucukbilgiGoster" title="<i>İlgili:</i> <%#Eval("ILGILI")%><br><i>Telefon:</i> <%#Eval("[TEL-1]")%><br><i>Cep Tel.:</i> <%#Eval("[CEP-1]")%><br><i>Eposta:</i> <%#Eval("[EMAIL-1]")%><br><br><%#Eval("ADRES").ToString()%><br><%#Eval("SEHIR")%>/<%#Eval("SEMT")%>"><%#Eval("SUBE") %></span></td>
                            <td style="width: 100px; text-align: right"><input runat="server" type="hidden" id="SMREF" value='<%#Eval("SMREF") %>' /><input runat="server" type="hidden" id="MTIP" value='<%#Eval("MTIP") %>' /><asp:LinkButton ID="lbFarkliZiyaretBaslat" runat="server" OnClientClick="lbZiyaretBaslat_Click()" OnClick="lbFarkliZiyaretBaslat_Click">Ziyaret Başlat</asp:LinkButton></td></tr>
                    </ItemTemplate>
                    <FooterTemplate></table></FooterTemplate>
                    </asp:Repeater>
                    </div>
                </td>
                </tr>
                <%--<tr>
                <td align="center" valign="middle">
                    <asp:DropDownList runat="server" ID="ddlZiyaretCariSubeler"></asp:DropDownList>
                </td>
                </tr>--%>
                <tr>
                <td align="center" valign="middle">
                    <asp:LinkButton runat="server" ID="lbFarkliZiyaretKapat" OnClick="lbFarkliZiyaretKapat_Click">Kapat</asp:LinkButton>
                </td>
                </tr>
                </table>
            </div>

            <div style="position: absolute; width: 850px; height: 350px; z-index: 2; left: 75px;
                top: 50px;" runat="server" id="divMusteriArama" visible="false" class="suruklenebilir">
                <div style="position: fixed; width: 100%; height: 100%; z-index: -1; left: 0; top: 0;
                filter: alpha(opacity=40); -moz-opacity: .40; opacity: .40; background-color: #000000" onclick="invisible()"></div>
                <table style="width: 100%; height: 340px; background-color: #ffffff; font-family: Verdana; font-size: 10px;
                    border: 1px solid #D1D1D1; border-radius: 5px; padding: 5px; margin-bottom: 20px;">
                <tr>
                <td valign="top" style="padding-top: 15px">
                    <table cellpadding="5" cellspacing="0">
                        <tr style="color: #D00000">
                            <td style="width: 80px; text-align: center; height: 20px; border-bottom: 1px solid #CCCCCC">Cari Kod</td>
                            <td style="width: 520px; text-align: center; height: 20px; border-bottom: 1px solid #CCCCCC">Cari Ünvan</td>
                            <td></td>
                        </tr></table>
                    <div style="width: 100%;">
                    <asp:DataList ID="dlMusteriArama" runat="server">
                    <HeaderTemplate><table cellpadding="4" cellspacing="0">
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr onmouseover="Satir(this,true)" onmouseout="Satir(this,false)">
                            <td style="width: 80px; text-align: center"><%#Eval("[SMREF]")%></td>
                            <td style="width: 520px; text-align: left"><%#Eval("[SUBE]")%></td>
                            <td>
                            <input type="hidden" value='<%#Eval("[SMREF]") %>' id="SMREF" runat="server" />
                            <asp:LinkButton runat="server" OnClick="SiparisVer_Click">Sipariş ver</asp:LinkButton>
                            <asp:Label runat="server" Width="20px"></asp:Label>
                            <asp:LinkButton runat="server" OnClick="IadeVer_Click">İade talep</asp:LinkButton>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate></table></FooterTemplate>
                </asp:DataList>
                </div>
                </td>
                </tr>
                <tr><td align="center" valign="bottom" style="padding-bottom: 15px;">
                    <asp:LinkButton runat="server" ID="lbMusteriAramaKapat" 
                        onclick="lbMusteriAramaKapat_Click">Kapat</asp:LinkButton></td>
                </tr>
                </table>
            </div>
            
            <div style="position: absolute; width: 400px; height: 100px; z-index: 4; left: 300px;
                top: 150px;" runat="server" id="divRiskLimitHata" visible="false" class="suruklenebilir">
                <div style="position: fixed; width: 100%; height: 100%; z-index: -1; left: 0; top: 0;
                filter: alpha(opacity=40); -moz-opacity: .40; opacity: .40; background-color: #000000" onclick="invisible()"></div>
                <table style="width: 100%; height: 100%; background-color: #ffffff; font-family: Tahoma; font-size: 12px;
                    border: 1px solid #D1D1D1; border-radius: 5px; padding: 5px;">
                <tr>
                <td align="center" valign="middle" style="padding-top: 15px; padding-bottom: 15px">
                    <span style="color: #C00000">Kredi limitiniz yetersiz olduğundan sipariş veremezsiniz.</span>
                    <br /><br />
                    <asp:LinkButton runat="server" ID="lbRiskLimitHata" 
                        onclick="lbRiskLimitHata_Click">Kapat</asp:LinkButton>
                </td>
                </tr>
                </table>
            </div>
            
            <div style="position: absolute; width: 400px; height: 100px; z-index: 4; left: 300px;
                top: 150px;" runat="server" id="divAnlasmaliFiyatHata" visible="false" class="suruklenebilir">
                <div style="position: fixed; width: 100%; height: 100%; z-index: -1; left: 0; top: 0;
                filter: alpha(opacity=40); -moz-opacity: .40; opacity: .40; background-color: #000000" onclick="invisible()"></div>
                <table style="width: 100%; height: 100%; background-color: #ffffff; font-family: Tahoma; font-size: 12px;
                    border: 1px solid #D1D1D1; border-radius: 5px; padding: 5px;">
                <tr>
                <td align="center" valign="middle" style="padding-top: 15px; padding-bottom: 15px">
                    <span style="color: #C00000">Anlaşmalı müşteriye toptan veya market fiyat tipinden sipariş giremezsiniz. (Not: 500'lü müşteriye de özel fiyattan sipariş girilemez.)</span>
                    <br /><br />
                    <asp:LinkButton runat="server" ID="lbAnlasmaliFiyatHata" 
                        onclick="lbAnlasmaliFiyatHata_Click">Kapat</asp:LinkButton>
                </td>
                </tr>
                </table>
            </div>
            
            <div style="position: absolute; width: 650px; height: 150px; z-index: 3; left: 175px;
                top: 150px;" runat="server" id="divSonZiyaret" visible="false" class="suruklenebilir">
                <div style="position: fixed; width: 100%; height: 100%; z-index: -1; left: 0; top: 0;
                filter: alpha(opacity=40); -moz-opacity: .40; opacity: .40; background-color: #000000" onclick="invisible()"></div>
                <table style="width: 100%; height: 100%; background-color: #ffffff; font-family: Tahoma; font-size: 11px;
                    border: 1px solid #D1D1D1; border-radius: 5px; padding: 5px;">
                <tr>
                <td align="center" valign="middle" style="padding-top: 15px; padding-bottom: 15px">
                    <span style="color: #C00000; font-size: 12px">Son Ziyaret</span>
                    <br /><br />
                    <asp:Label runat="server" ID="lblSonZiyaretMusteri"></asp:Label>
                    <br /><br />
                    <asp:LinkButton ID="lbSonZiyaretSonlandir" Text="Bu ziyaret sonlandırılmamış. Sonlandırmak için tıklayınız." runat="server" Visible="false" OnClientClick="lbZiyaretSonlandirClick()" OnClick="lbSonZiyaretSonlandir_Click" />
                    <br /><br /><br /><br />
                    <asp:LinkButton runat="server" ID="lbSonZiyaretKapat" Font-Size="12px"
                        onclick="lbSonZiyaretKapat_Click">Kapat</asp:LinkButton>
                </td>
                </tr>
                </table>
            </div>
            
            <div style="position: absolute; width: 400px; height: 100px; z-index: 4; left: 300px;
                top: 150px;" runat="server" id="divZiyaretKonumAlinamadi" visible="false" class="suruklenebilir">
                <div style="position: fixed; width: 100%; height: 100%; z-index: -1; left: 0; top: 0;
                filter: alpha(opacity=40); -moz-opacity: .40; opacity: .40; background-color: #000000" onclick="invisible()"></div>
                <table style="width: 100%; height: 100%; background-color: #ffffff; font-family: Tahoma; font-size: 12px;
                    border: 1px solid #D1D1D1; border-radius: 5px; padding: 5px;">
                <tr>
                <td align="center" valign="middle" style="padding-top: 15px; padding-bottom: 15px">
                    <span style="color: #C00000">Ziyaret, konum bilgisi alınamadığından dolayı başlatılamadı. Lütfen tekrar deneyiniz.</span>
                    <br /><br />
                    <asp:LinkButton runat="server" ID="lbZiyaretKonumAlinamadi" 
                        onclick="lbZiyaretKonumAlinamadi_Click">Kapat</asp:LinkButton>
                </td>
                </tr>
                </table>
            </div>
            
            <div style="position: absolute; width: 400px; height: 100px; z-index: 4; left: 300px;
                top: 150px;" runat="server" id="divAnlasmaHata" visible="false" class="suruklenebilir">
                <div style="position: fixed; width: 100%; height: 100%; z-index: -1; left: 0; top: 0;
                filter: alpha(opacity=40); -moz-opacity: .40; opacity: .40; background-color: #000000" onclick="invisible()"></div>
                <table style="width: 100%; height: 100%; background-color: #ffffff; font-family: Tahoma; font-size: 12px;
                    border: 1px solid #D1D1D1; border-radius: 5px; padding: 5px;">
                <tr>
                <td align="center" valign="middle" style="padding-top: 15px; padding-bottom: 15px">
                    <span style="color: #C00000">Seçilen müşteriye ait onaylanmayı bekleyen bir anlaşma var, yeni anlaşma girilemez.</span>
                    <br /><br />
                    <asp:LinkButton runat="server" ID="lbAnlasmaHata" 
                        onclick="lbAnlasmaHata_Click">Kapat</asp:LinkButton>
                </td>
                </tr>
                </table>
            </div>
            
            <div style="position: absolute; width: 400px; height: 100px; z-index: 4; left: 300px;
                top: 150px;" runat="server" id="divAktiviteHata" visible="false" class="suruklenebilir">
                <div style="position: fixed; width: 100%; height: 100%; z-index: -1; left: 0; top: 0;
                filter: alpha(opacity=40); -moz-opacity: .40; opacity: .40; background-color: #000000" onclick="invisible()"></div>
                <table style="width: 100%; height: 100%; background-color: #ffffff; font-family: Tahoma; font-size: 12px;
                    border: 1px solid #D1D1D1; border-radius: 5px; padding: 5px;">
                <tr>
                <td align="center" valign="middle" style="padding-top: 15px; padding-bottom: 15px">
                    <span style="color: #C00000">Seçilen müşteriye ait onaylanmayı bekleyen bir aktivite var, yeni aktivite girilemez.</span>
                    <br /><br />
                    <asp:LinkButton runat="server" ID="lbAktiviteHata" 
                        onclick="lbAktiviteHata_Click">Kapat</asp:LinkButton>
                </td>
                </tr>
                </table>
            </div>
            
            <div style="position: absolute; width: 400px; height: 100px; z-index: 4; left: 300px;
                top: 150px;" runat="server" id="divIadeIlgili" visible="false" class="suruklenebilir">
                <div style="position: fixed; width: 100%; height: 100%; z-index: -1; left: 0; top: 0;
                filter: alpha(opacity=40); -moz-opacity: .40; opacity: .40; background-color: #000000" onclick="invisible()"></div>
                <table style="width: 100%; height: 100%; background-color: #ffffff; font-family: Tahoma; font-size: 12px;
                    border: 1px solid #D1D1D1; border-radius: 5px; padding: 5px;">
                <tr>
                <td align="center" valign="middle" style="padding-top: 15px; padding-bottom: 15px">
                    <input type="hidden" runat="server" id="inputIadeIlgiliSMREF" />
                    <span style="color: #C00000"><asp:Label runat="server" ID="lblIadeIlgiliMusteri"></asp:Label></span>
                    <br /><br />
                    İade için ilgili kişi ve telefonu: <asp:TextBox runat="server" ID="txtIadeIlgili" Width="300px"
                                     ForeColor="#006699" BorderColor="#A3B5C9" style="padding: 3px 3px 3px 3px;"
                                        BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                    <br /><br />
                    <asp:LinkButton runat="server" ID="lbIadeIlgiliKapat" onclick="lbIadeIlgiliKapat_Click">Kaydet ve Kapat</asp:LinkButton>
                </td>
                </tr>
                </table>
            </div>
            
            <div style="position: absolute; width: 400px; height: 270px; z-index: 3; left: 300px;
                top: 50px" runat="server" id="divEFaturaTarih" visible="false">
                <div style="position: fixed; width: 100%; height: 100%; z-index: -1; left: 0; top: 0;
                filter: alpha(opacity=40); -moz-opacity: .40; opacity: .40; background-color: #000000" onclick="invisible()"></div>
                <table cellpadding="5" style="width: 100%; height: 100%; background-color: #ffffff; font-family: Tahoma; font-size: 12px;
                    border: 1px solid #D1D1D1; border-radius: 5px; padding: 5px;">
                <tr>
                <td align="center" valign="middle" colspan="2">
                    <span style="color: #C00000; font-family: Gisha; font-size: 16px">Tarih Aralığı Belirleyiniz</span>
                    <br />
                </td>
                </tr>
                <tr>
                <td align="center" valign="middle">
                    <asp:Calendar ID="Calendar3" runat="server" BackColor="White" 
                        BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" 
                        Font-Names="Verdana" Font-Size="7pt" ForeColor="Black" Height="170px" 
                        Width="170px" OnSelectionChanged="Calendar3_SelectionChanged">
                        <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                        <NextPrevStyle VerticalAlign="Bottom" />
                        <OtherMonthDayStyle ForeColor="#808080" />
                        <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                        <SelectorStyle BackColor="#CCCCCC" />
                        <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                        <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                        <WeekendDayStyle BackColor="#FFFFCC" />
                    </asp:Calendar>
                </td>
                <td align="center" valign="middle">
                    <asp:Calendar ID="Calendar4" runat="server" BackColor="White" 
                        BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" 
                        Font-Names="Verdana" Font-Size="7pt" ForeColor="Black" Height="170px" 
                        Width="170px" OnSelectionChanged="Calendar4_SelectionChanged">
                        <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                        <NextPrevStyle VerticalAlign="Bottom" />
                        <OtherMonthDayStyle ForeColor="#808080" />
                        <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                        <SelectorStyle BackColor="#CCCCCC" />
                        <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                        <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                        <WeekendDayStyle BackColor="#FFFFCC" />
                    </asp:Calendar>
                </td>
                </tr>
                <tr>
                <td align="center" valign="middle" colspan="2">
                    Seçim yapılan tarih aralığı: 
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label runat="server" ID="lblEFaturaTarihSecim1" ForeColor="Red"></asp:Label>
                    &nbsp;&nbsp;&nbsp;
                    <asp:Label runat="server" ID="lblEFaturaTarihSecim2" ForeColor="Red"></asp:Label>
                </td>
                </tr>
                <tr>
                <td align="center" valign="middle" colspan="2">
                    <asp:Button runat="server" ID="lbEFaturaTarihIptal" OnClick="lbEFaturaIptal_Click" Text="İptal Et" Font-Size="11px" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button runat="server" ID="lbEFaturaTarihDevam" OnClick="lbEFaturaTarihDevam_Click" Text="Devam Et" Font-Size="11px" />
                </td>
                </tr>
                </table>
            </div>
            
            <div style="position: absolute; width: 450px; height: 400px; z-index: 3; left: 275px;
                top: 50px;" runat="server" id="divEFaturaFaturalar" visible="false">
                <div style="position: fixed; width: 100%; height: 100%; z-index: -1; left: 0; top: 0;
                filter: alpha(opacity=40); -moz-opacity: .40; opacity: .40; background-color: #000000" onclick="invisible()"></div>
                <table cellpadding="5" style="width: 100%; height: 100%; background-color: #ffffff; font-family: Tahoma; font-size: 12px;
                    border: 1px solid #D1D1D1; border-radius: 5px; padding: 5px;">
                <tr>
                <td align="center" valign="middle">
                    <span style="color: #C00000; font-family: Gisha; font-size: 16px">Fatura Seçimi Yapınız</span>
                    <br /><br />
                     <table style="width: 100%" cellpadding="0" cellspacing="0"><tr><td align="left"><span style="color: #D00000">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Fatura No &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Fatura Tarihi &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Açıklama</span></td></tr></table>
                </td>
                </tr>
                <tr>
                <td>
                    <div style="height: 350px; overflow: auto; font-family: Lucida Console; font-size: 11px">
                    <asp:CheckBoxList runat="server" ID="cblEFaturaFaturalar" RepeatDirection="Vertical"></asp:CheckBoxList>
                    <%--<asp:Repeater runat="server" ID="rpEFaturaFaturalar">
                    <HeaderTemplate>
                        <table cellpadding="3" cellspacing="0" style="font-size: 11px">
                        <tr style="text-decoration: 'underline'; color: Red">
                        <td align="center" style="width: 100px">Seçim</td>
                        <td align="center" style="width: 150px">Fatura No</td>
                        <td align="center" style="width: 150px">Tarih</td>
                        <td align="center" style="width: 200px">Tür</td>
                        </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td align="center"><asp:CheckBox runat="server" ToolTip='<%# Eval("[FAT NO]") %>' /></td>
                            <td align="center"><%# Eval("[FAT NO]") %></td>
                            <td align="center"><%# Convert.ToDateTime(Eval("[FAT TAR]")).ToShortDateString() %></td>
                            <td align="center"><%# Eval("[TUR ACK]") %></td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate></table></FooterTemplate>
                    </asp:Repeater>--%>
                    </div>
                    <br />
                    <table style="width: 100%"><tr>
                    <td align="center">
                    <span class="kucukbilgiGoster" title="Önemli Not: 100'den fazla fatura seçimi yapmanız durumunda işlem uzun sürebilir.">Fatura Sayısı: </span>
                    <asp:Label runat="server" ID="lblEFaturaFaturalarSayi" ForeColor="Red" class="kucukbilgiGoster" title="Önemli Not: 100'den fazla fatura seçimi yapmanız durumunda işlem uzun sürebilir."></asp:Label>
                    </td>
                    <td align="center">
                    <span class="kucukbilgiGoster" title="Önemli Not: 100'den fazla fatura seçimi yapmanız durumunda işlem uzun sürebilir." onclick="Checkboxes('cblEFaturaFaturalar',true)">Tümünü Seç</span>
                    </td>
                    <td align="center">
                    <span class="kucukbilgiGoster" title="Önemli Not: 100'den fazla fatura seçimi yapmanız durumunda işlem uzun sürebilir." onclick="Checkboxes('cblEFaturaFaturalar',false)">Seçimi Temizle</span>
                    </td></tr></table>
                </td>
                </tr>
                <tr>
                <td align="center" valign="middle">
                    <asp:Button runat="server" ID="lbEFaturaFaturalarIptal" OnClick="lbEFaturaIptal_Click" Text="İptal Et" Font-Size="11px" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button runat="server" ID="lbEFaturaFaturalarDevam" OnClick="lbEFaturaFaturalarDevam_Click" Text="Devam Et" Font-Size="11px" />
                </td>
                </tr>
                </table>
            </div>
            
            <div style="position: absolute; width: 650px; height: 50px; z-index: 3; left: 175px;
                top: 50px;" runat="server" id="divEFaturaAlias" visible="false">
                <div style="position: fixed; width: 100%; height: 100%; z-index: -1; left: 0; top: 0;
                filter: alpha(opacity=40); -moz-opacity: .40; opacity: .40; background-color: #000000" onclick="invisible()"></div>
                <table style="width: 100%; height: 100%; background-color: #ffffff; font-family: Tahoma; font-size: 12px;
                    border: 1px solid #D1D1D1; border-radius: 5px; padding: 5px;">
                <tr>
                    <td align="center" valign="middle" style="height: 30px">
                        <span style="color: #C00000; font-family: Gisha; font-size: 16px">Kullandığınız Programı Seçiniz</span>
                    </td>
                </tr>
                <tr>
                    <td align="center" valign="middle" style="height: 30px; font-size: 10px">
                        <asp:RadioButton runat="server" ID="rbEFaturaAliasBelirleme" Text="Alanları kendim belirlemek istiyorum" Checked="true" 
                            AutoPostBack="true" OnCheckedChanged="rbEFaturaAliasBelirleme_CheckedChanged" GroupName="grEFaturaAliasBelirleme" />
                        <asp:Label runat="server" Width="10px"></asp:Label>
                        <asp:RadioButton runat="server" ID="rbEFaturaAliasIlon" Text="İlon" AutoPostBack="true" 
                            OnCheckedChanged="rbEFaturaAliasBelirleme_CheckedChanged" GroupName="grEFaturaAliasBelirleme" />
                        <asp:Label runat="server" Width="10px"></asp:Label>
                        <asp:RadioButton runat="server" ID="rbEFaturaAliasEczanem" Text="Eczanem" AutoPostBack="true" 
                            OnCheckedChanged="rbEFaturaAliasBelirleme_CheckedChanged" GroupName="grEFaturaAliasBelirleme" />
                        <asp:Label runat="server" Width="10px"></asp:Label>
                        <asp:RadioButton runat="server" ID="rbEFaturaAliasTebeos" Text="Tebeos" AutoPostBack="true" 
                            OnCheckedChanged="rbEFaturaAliasBelirleme_CheckedChanged" GroupName="grEFaturaAliasBelirleme" />
                        <br /><br />
                        <span style="font-style: italic; font-weight: bold; font-size: 11px">(Sultanlar Pazarlama A.Ş. GLN No: 8691014000012)</span>
                    </td>
                </tr>
                <tr>
                <td align="center" valign="middle" style="padding-top: 5px; padding-bottom: 15px">
                    <div runat="server" id="divEFaturaAliasBelirleme">
                    <table cellpadding="3" cellspacing="0" style="width: 100%; text-align: left; font-size: 11px;">
                    <tr>
                    <td style="width: 350px">
                    </td>
                    <td></td>
                    </tr>
                    <tr>
                    <td><span style="color: Red; padding-left: 50px">Açıklama</span></td>
                    <td><asp:LinkButton runat="server" ID="lbEFaturaAliasSil" Text="Tümünü Sil" OnClick="lbEFaturaAliasSil_Click"></asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:LinkButton runat="server" ID="lbEFaturaAliasVarsayilan" Text="Varsayılan Yap" OnClick="lbEFaturaAliasVarsayilan_Click"></asp:LinkButton></td>
                    </tr>
                    </table>
                    <div style="height: 300px; overflow: auto; font-size: 11px;">
                    <table cellpadding="3" cellspacing="0" style="text-align: left; margin-left: 20px" runat="server" id="tblEFaturaAlias">
                    <tr><td style="width: 350px">Satır Tipi</td><td style="width: 280px"><asp:TextBox runat="server" ID="txtEFaturaAliasLT">LT</asp:TextBox></td></tr>
                    <tr><td>Bölge</td><td><asp:TextBox runat="server" ID="txtEFaturaAliasBOLGE">BOLGE</asp:TextBox></td></tr>
                    <tr><td>Grup</td><td><asp:TextBox runat="server" ID="txtEFaturaAliasGRP">GRP</asp:TextBox></td></tr>
                    <tr><td>Ekp</td><td><asp:TextBox runat="server" ID="txtEFaturaAliasEKP">EKP</asp:TextBox></td></tr>
                    <tr><td>Ambar No</td><td><asp:TextBox runat="server" ID="txtEFaturaAliasABRNO">ABRNO</asp:TextBox></td></tr>
                    <tr><td>Ambar</td><td><asp:TextBox runat="server" ID="txtEFaturaAliasAMBAR">AMBAR</asp:TextBox></td></tr>
                    <tr><td>Ay</td><td><asp:TextBox runat="server" ID="txtEFaturaAliasAY">AY</asp:TextBox></td></tr>
                    <tr><td>Hafta</td><td><asp:TextBox runat="server" ID="txtEFaturaAliasHAFTA">HAFTA</asp:TextBox></td></tr>
                    <tr><td>Fatura Tarihi</td><td><asp:TextBox runat="server" ID="txtEFaturaAliasFATTAR">FATTAR</asp:TextBox></td></tr>
                    <tr><td>Fatura No</td><td><asp:TextBox runat="server" ID="txtEFaturaAliasFATNO">FATNO</asp:TextBox></td></tr>
                    <tr><td>Fatura Vade</td><td><asp:TextBox runat="server" ID="txtEFaturaAliasFATVD">FATVD</asp:TextBox></td></tr>
                    <tr><td>Tür</td><td><asp:TextBox runat="server" ID="txtEFaturaAliasTUR">TUR</asp:TextBox></td></tr>
                    <tr><td>Tür Açıklama</td><td><asp:TextBox runat="server" ID="txtEFaturaAliasTURACK">TURACK</asp:TextBox></td></tr>
                    <tr><td>Fiyat Türü</td><td><asp:TextBox runat="server" ID="txtEFaturaAliasFTUR">FTUR</asp:TextBox></td></tr>
                    <tr><td>Satış Temsilcisi No</td><td><asp:TextBox runat="server" ID="txtEFaturaAliasSLSREF">SLSREF</asp:TextBox></td></tr>
                    <tr><td>Satış Temsilcisi Kod</td><td><asp:TextBox runat="server" ID="txtEFaturaAliasSATKOD">SATKOD</asp:TextBox></td></tr>
                    <tr><td>Satış Temsilcisi</td><td><asp:TextBox runat="server" ID="txtEFaturaAliasSATTEM">SATTEM</asp:TextBox></td></tr>
                    <tr><td>Tedarikçi Ekip No</td><td><asp:TextBox runat="server" ID="txtEFaturaAliasTEDEKP">TEDEKP</asp:TextBox></td></tr>
                    <tr><td>Tedarikçi Satış Temsilcisi No</td><td><asp:TextBox runat="server" ID="txtEFaturaAliasTEDSLSREF">TEDSLSREF</asp:TextBox></td></tr>
                    <tr><td>Tedarikçi Satış Temsilcisi</td><td><asp:TextBox runat="server" ID="txtEFaturaAliasTEDSATTEM">TEDSATTEM</asp:TextBox></td></tr>
                    <tr><td>İl</td><td><asp:TextBox runat="server" ID="txtEFaturaAliasIL">IL</asp:TextBox></td></tr>
                    <tr><td>İlçe</td><td><asp:TextBox runat="server" ID="txtEFaturaAliasILCE">ILCE</asp:TextBox></td></tr>
                    <tr><td>Müşteri C/H Açıklaması</td><td><asp:TextBox runat="server" ID="txtEFaturaAliasMTACIKLAMA">MTACIKLAMA</asp:TextBox></td></tr>
                    <tr><td>Müşteri No</td><td><asp:TextBox runat="server" ID="txtEFaturaAliasGMREF">GMREF</asp:TextBox></td></tr>
                    <tr><td>Müşteri Kod</td><td><asp:TextBox runat="server" ID="txtEFaturaAliasMUSKOD">MUSKOD</asp:TextBox></td></tr>
                    <tr><td>Müşteri</td><td><asp:TextBox runat="server" ID="txtEFaturaAliasMUSTERI">MUSTERI</asp:TextBox></td></tr>
                    <tr><td>Şube No</td><td><asp:TextBox runat="server" ID="txtEFaturaAliasSMREF">SMREF</asp:TextBox></td></tr>
                    <tr><td>Şube Kod</td><td><asp:TextBox runat="server" ID="txtEFaturaAliasSUBKOD">SUBKOD</asp:TextBox></td></tr>
                    <tr><td>Şube</td><td><asp:TextBox runat="server" ID="txtEFaturaAliasSUBE">SUBE</asp:TextBox></td></tr>
                    <tr><td>Sevk Kod</td><td><asp:TextBox runat="server" ID="txtEFaturaAliasSEVKKOD">SEVKKOD</asp:TextBox></td></tr>
                    <tr><td>Sevk Adresi</td><td><asp:TextBox runat="server" ID="txtEFaturaAliasSEVKADRES">SEVKADRES</asp:TextBox></td></tr>
                    <tr><td>Reyon Kod</td><td><asp:TextBox runat="server" ID="txtEFaturaAliasREYKOD">REYKOD</asp:TextBox></td></tr>
                    <tr><td>Reyon</td><td><asp:TextBox runat="server" ID="txtEFaturaAliasREYON">REYON</asp:TextBox></td></tr>
                    <tr><td>Ana Grup</td><td><asp:TextBox runat="server" ID="txtEFaturaAliasANAGRP">ANAGRP</asp:TextBox></td></tr>
                    <tr><td>Grup Kod</td><td><asp:TextBox runat="server" ID="txtEFaturaAliasGRPKOD">GRPKOD</asp:TextBox></td></tr>
                    <tr><td>Grup</td><td><asp:TextBox runat="server" ID="txtEFaturaAliasGRUP">GRUP</asp:TextBox></td></tr>
                    <tr><td>Tedarikçi Grup</td><td><asp:TextBox runat="server" ID="txtEFaturaAliasTEDGRP">TEDGRP</asp:TextBox></td></tr>
                    <tr><td>Tedarikçi Kısa Malzeme</td><td><asp:TextBox runat="server" ID="txtEFaturaAliasTEDKISAMAL">TEDKISAMAL</asp:TextBox></td></tr>
                    <tr><td>Barkod</td><td><asp:TextBox runat="server" ID="txtEFaturaAliasBARCODE">BARCODE</asp:TextBox></td></tr>
                    <tr><td>Malzeme No</td><td><asp:TextBox runat="server" ID="txtEFaturaAliasITEMREF">ITEMREF</asp:TextBox></td></tr>
                    <tr><td>Malzeme Kod</td><td><asp:TextBox runat="server" ID="txtEFaturaAliasMALKOD">MALKOD</asp:TextBox></td></tr>
                    <tr><td>Malzeme</td><td><asp:TextBox runat="server" ID="txtEFaturaAliasMALZEME">MALZEME</asp:TextBox></td></tr>
                    <tr><td>Koli</td><td><asp:TextBox runat="server" ID="txtEFaturaAliasKOLI">KOLI</asp:TextBox></td></tr>
                    <tr><td>KDV Oranı</td><td><asp:TextBox runat="server" ID="txtEFaturaAliasKDV">KDV</asp:TextBox></td></tr>
                    <tr><td>Birim No</td><td><asp:TextBox runat="server" ID="txtEFaturaAliasBRM">BRM</asp:TextBox></td></tr>
                    <tr><td>Adet Toplam</td><td><asp:TextBox runat="server" ID="txtEFaturaAliasADT">ADT</asp:TextBox></td></tr>
                    <tr><td>İskonto 1</td><td><asp:TextBox runat="server" ID="txtEFaturaAliasISK1">ISK1</asp:TextBox></td></tr>
                    <tr><td>İskonto 2</td><td><asp:TextBox runat="server" ID="txtEFaturaAliasISK2">ISK2</asp:TextBox></td></tr>
                    <tr><td>İskonto 3</td><td><asp:TextBox runat="server" ID="txtEFaturaAliasISK3">ISK3</asp:TextBox></td></tr>
                    <tr><td>İskonto 4</td><td><asp:TextBox runat="server" ID="txtEFaturaAliasISK4">ISK4</asp:TextBox></td></tr>
                    <tr><td>İskonto 5</td><td><asp:TextBox runat="server" ID="txtEFaturaAliasISK5">ISK5</asp:TextBox></td></tr>
                    <tr><td>Alt İskonto</td><td><asp:TextBox runat="server" ID="txtEFaturaAliasISKALT">ISKALT</asp:TextBox></td></tr>
                    <tr><td>Brüt Toplam</td><td><asp:TextBox runat="server" ID="txtEFaturaAliasBRUTT">BRUTT</asp:TextBox></td></tr>
                    <tr><td>İskonto Toplam</td><td><asp:TextBox runat="server" ID="txtEFaturaAliasISKT">ISKT</asp:TextBox></td></tr>
                    <tr><td>Net Toplam</td><td><asp:TextBox runat="server" ID="txtEFaturaAliasNETT">NETT</asp:TextBox></td></tr>
                    <tr><td>KDV Toplam</td><td><asp:TextBox runat="server" ID="txtEFaturaAliasKDVT">KDVT</asp:TextBox></td></tr>
                    <tr><td>Net+KDV Toplam</td><td><asp:TextBox runat="server" ID="txtEFaturaAliasNETKDVT">NETKDVT</asp:TextBox></td></tr>
                    </table>
                    </div>
                    <br />
                    <table cellpadding="3" cellspacing="0" style="width: 100%; text-align: left; font-size: 11px;"><tr><td>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:DropDownList runat="server" ID="ddlEFaturaAliasSecim" ForeColor="#006699" AutoPostBack="true" Font-Size="11px" OnSelectedIndexChanged="ddlEFaturaAliasSecim_SelectedIndexChanged" Width="200px" style=" padding: 3px 3px 3px 3px;border:1px solid #CCCCCC;background:#ededed;"></asp:DropDownList> 
                    &nbsp;&nbsp;&nbsp;
                    <asp:LinkButton runat="server" ID="lbEFaturaAliasSecimSil" Text="Seçimi Sil" Visible="false" OnClick="lbEFaturaAliasSecimSil_Click"></asp:LinkButton>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:CheckBox runat="server" ID="cbEFaturaAliasKaydet" Font-Size="9px" Text="Seçimi Kaydet" AutoPostBack="true" OnCheckedChanged="cbEFaturaAliasKaydet_CheckedChanged" /> 
                    <asp:TextBox runat="server" ID="txtEFaturaAliasKaydetAd" Enabled="false" Font-Size="11px"></asp:TextBox>
                    </td></tr></table>
                    <br />
                    </div>
                    <br />
                    <asp:Button runat="server" ID="lbEFaturaAliasIptal" OnClick="lbEFaturaIptal_Click" Text="İptal Et" Font-Size="11px" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button runat="server" ID="lbEFaturaIndir" onclick="lbEFaturaIndir_Click" Text="E-Fatura İndir" Font-Size="11px" />
                </td>
                </tr>
                </table>
            </div>

            <div style="position: absolute; width: 500px; height: 100px; z-index: 3; left: 250px;
                top: 30px" runat="server" id="divAltCariEkle" visible="false">
                <div style="position: fixed; width: 100%; height: 100%; z-index: -1; left: 0; top: 0;
                filter: alpha(opacity=40); -moz-opacity: .40; opacity: .40; background-color: #000000" onclick="invisible()"></div>
                <table style="width: 420px; height: 100px; background-color: #ffffff; font-family: Tahoma; font-size: 12px;
                    border: 1px solid #D1D1D1; border-radius: 5px; padding: 5px;">
                    <tr>
                        <td style="width: 500px; text-align: center" colspan="2"><span style="color: #C00000; font-family: Gisha; font-size: 16px">Alt Cari Bilgileri</span></td>
                    </tr>
                    <tr>
                        <td style="width: 200px">Cari İsmi:</td>
                        <td align="left" style="width: 300px">
                            <asp:TextBox runat="server" ID="txtAltCariEkleCari" Width="300px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                                BorderWidth="1px" Height="23px" style="padding: 0px 3px 0px 3px" Text=""></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 200px">İl:</td>
                        <td align="left" style="width: 300px">
                            <asp:DropDownList runat="server" ID="ddlAltCariEkleIl" AutoPostBack="true" Width="300px"
                                Font-Bold="False" Font-Italic="False" Height="25px" OnSelectedIndexChanged="ddlAltCariEkleIl_SelectedIndexChanged"
                                Font-Overline="False" Font-Size="12px" Font-Strikeout="False" 
                                Font-Underline="False" style="padding: 3px 3px 3px 3px;border:1px solid #CCCCCC;background:#ededed;" ForeColor="#006699"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 200px">İlçe:</td>
                        <td align="left" style="width: 300px">
                            <asp:DropDownList runat="server" ID="ddlAltCariEkleIlce" Width="300px"
                                Font-Bold="False" Font-Italic="False" Height="25px" 
                                Font-Overline="False" Font-Size="12px" Font-Strikeout="False" 
                                Font-Underline="False" style="padding: 3px 3px 3px 3px;border:1px solid #CCCCCC;background:#ededed;" ForeColor="#006699"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 200px">Açıklama:</td>
                        <td align="left" style="width: 300px">
                            <asp:TextBox runat="server" ID="txtAltCariEkleAciklama" Width="300px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                                BorderWidth="1px" Height="23px" style="padding: 0px 3px 0px 3px" Text=""></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 200px">Adres:</td>
                        <td align="left" style="width: 300px">
                            <asp:TextBox runat="server" ID="txtAltCariEkleAdres" Width="300px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                                BorderWidth="1px" Height="23px" style="padding: 0px 3px 0px 3px" Text=""></asp:TextBox>
                        </td>
                    </tr>
                    <tr style="visibility: hidden">
                        <td style="width: 200px">Konum:</td>
                        <td align="left" style="width: 300px">
                            <asp:RadioButton runat="server" ID="rbKonumAl" GroupName="grKonum" Checked="false" Text="Konum bilgisini al" />
                            <br />
                            <asp:RadioButton runat="server" ID="rbKonumAlma" GroupName="grKonum" Checked="true" Text="Konum bilgisini alma (değiştirme)" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 200px">Vergi Dairesi:</td>
                        <td align="left" style="width: 300px">
                            <asp:TextBox runat="server" ID="txtAltCariEkleVergiDairesi" Width="300px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                                BorderWidth="1px" Height="23px" style="padding: 0px 3px 0px 3px" Text=""></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 200px">Vergi No:</td>
                        <td align="left" style="width: 300px">
                            <asp:TextBox runat="server" ID="txtAltCariEkleVergiNo" Width="300px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                                BorderWidth="1px" Height="23px" style="padding: 0px 3px 0px 3px" Text=""></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 200px">Telefon:</td>
                        <td align="left" style="width: 300px">
                            <asp:TextBox runat="server" ID="txtAltCariEkleTelefon" Width="300px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                                BorderWidth="1px" Height="23px" style="padding: 0px 3px 0px 3px" Text=""></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 200px">Mobil Telefon:</td>
                        <td align="left" style="width: 300px">
                            <asp:TextBox runat="server" ID="txtAltCariEkleCep" Width="300px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                                BorderWidth="1px" Height="23px" style="padding: 0px 3px 0px 3px" Text=""></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 200px">Fax:</td>
                        <td align="left" style="width: 300px">
                            <asp:TextBox runat="server" ID="txtAltCariEkleFax" Width="300px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                                BorderWidth="1px" Height="23px" style="padding: 0px 3px 0px 3px" Text=""></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 200px">Eposta:</td>
                        <td align="left" style="width: 300px">
                            <asp:TextBox runat="server" ID="txtAltCariEkleEposta" Width="300px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                                BorderWidth="1px" Height="23px" style="padding: 0px 3px 0px 3px" Text=""></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 200px"></td>
                        <td align="left" style="width: 300px">
                            <asp:LinkButton runat="server" ID="btnAltCariEkle" Text="Ekle" OnClick="btnAltCariEkle_Click" />
                            <asp:Label runat="server" Width="50px"></asp:Label>
                            <asp:LinkButton runat="server" ID="btnAltCariEkleVazgec" Text="Vazgeç" OnClick="btnAltCariEkleVazgec_Click" />
                        </td>
                    </tr>
                </table>
            </div>

            <div style="position: absolute; width: 300px; height: 100px; z-index: 3; left: 350px;
                top: 150px" runat="server" id="divAltCariHata" visible="false">
                <div style="position: fixed; width: 100%; height: 100%; z-index: -1; left: 0; top: 0;
                filter: alpha(opacity=40); -moz-opacity: .40; opacity: .40; background-color: #000000" onclick="invisible()"></div>
                <table style="width: 420px; height: 100px; background-color: #ffffff; font-family: Tahoma; font-size: 12px;
                    border: 1px solid #D1D1D1; border-radius: 5px; padding: 5px;">
                <tr>
                <td align="center" valign="middle" style="padding-top: 15px; padding-bottom: 15px">
                    Seçilen bayide bu isimde bir alt nokta zaten var.
                    <br /><br />
                    <asp:LinkButton runat="server" ID="lbAltCariHataKapat" 
                        onclick="lbAltCariHataKapat_Click">Kapat</asp:LinkButton>
                </td>
                </tr>
                </table>
            </div>

            <div style="position: absolute; width: 300px; height: 100px; z-index: 3; left: 350px;
                top: 150px" runat="server" id="divAnlasmaKaydedildi" visible="false">
                <div style="position: fixed; width: 100%; height: 100%; z-index: -1; left: 0; top: 0;
                filter: alpha(opacity=40); -moz-opacity: .40; opacity: .40; background-color: #000000" onclick="invisible()"></div>
                <table style="width: 420px; height: 100px; background-color: #ffffff; font-family: Tahoma; font-size: 12px;
                    border: 1px solid #D1D1D1; border-radius: 5px; padding: 5px;">
                <tr>
                <td align="center" valign="middle" style="padding-top: 15px; padding-bottom: 15px">
                    Anlaşma talebi merkeze iletilmiştir.
                    <br /><br />
                    <asp:LinkButton runat="server" ID="lbAnlasmaKaydedildiKapat" 
                        onclick="lbAnlasmaKaydedildiKapat_Click">Kapat</asp:LinkButton>
                </td>
                </tr>
                </table>
            </div>

            <div style="position: absolute; width: 520px; z-index: 3; left: 240px;
                top: 50px" runat="server" id="divAnlasma" visible="false">
                <div style="position: fixed; width: 100%; height: 100%; z-index: -1; left: 0; top: 0;
                filter: alpha(opacity=40); -moz-opacity: .40; opacity: .40; background-color: #000000" onclick="invisible()"></div>
                <table style="width: 100%; background-color: #ffffff; font-family: Tahoma; font-size: 12px;
                    border: 1px solid #D1D1D1; border-radius: 5px; padding: 5px; margin-bottom: 20px;">
                <tr>
                <td align="center" valign="middle" style="padding-top: 15px; padding-bottom: 15px">
                <input type="hidden" runat="server" id="AnlasmaSMREF" value="0" />
                <span style="color: #C00000; font-family: Gisha; font-size: 16px">Anlaşma Formu</span>
                <div style="height: 10px"></div>
                    <table cellpadding="3" cellspacing="0">
                    <tr>
                        <td style="width: 200px">Müşteri:</td>
                        <td align="left" style="width: 300px">
                            <asp:TextBox runat="server" ID="txtAnlasmaMusteri" Width="200px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                                BorderWidth="1px" Height="23px" style="padding: 0px 3px 0px 3px" Text="" Enabled="false"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Şube Sayısı:</td>
                        <td align="left">
                            <asp:TextBox runat="server" ID="txtAnlasmaSubeSayisi" Width="200px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                                BorderWidth="1px" Height="23px" style="padding: 0px 3px 0px 3px" Text="1" onkeypress="return isNumberKey(event)"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>İl:</td>
                        <td align="left">
                            <asp:TextBox runat="server" ID="txtAnlasmaIl" Width="200px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                                BorderWidth="1px" Height="23px" style="padding: 0px 3px 0px 3px" Text="" Enabled="false"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Bayi:</td>
                        <td align="left">
                            <asp:TextBox runat="server" ID="txtAnlasmaBayi" Width="200px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                                BorderWidth="1px" Height="23px" style="padding: 0px 3px 0px 3px" Text="" Enabled="false"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Başlangıç:</td>
                        <td align="left">
                            <input type="text" id="datepickerAnlasmaBaslangic" runat="server" onkeypress="return yazma(event)" style="width: 200px" autocomplete="off" />
                        </td>
                    </tr>
                    <tr>
                        <td>Bitiş:</td>
                        <td align="left">
                            <input type="text" id="datepickerAnlasmaBitis" runat="server" onkeypress="return yazma(event)" style="width: 200px" autocomplete="off" />
                        </td>
                    </tr>
                    <tr>
                        <td>Anlaşma Vade KGT:</td>
                        <td align="left">
                            <asp:TextBox runat="server" ID="txtAnlasmaVadeTAH" Width="200px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                                BorderWidth="1px" Height="23px" Text="0" style="padding: 0px 3px 0px 3px" onkeypress="return isNumberKey(event)"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Anlaşma Vade NF:</td>
                        <td align="left">
                            <asp:TextBox runat="server" ID="txtAnlasmaVadeYEG" Width="200px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                                BorderWidth="1px" Height="23px" Text="0" style="padding: 0px 3px 0px 3px" onkeypress="return isNumberKey(event)"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Listelenecek SKU KGT:</td>
                        <td align="left">
                            <asp:TextBox runat="server" ID="txtAnlasmaSKUTAH" Width="200px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                                BorderWidth="1px" Height="23px" Text="0" style="padding: 0px 3px 0px 3px" onkeypress="return isNumberKey(event)"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Listelenecek SKU NF:</td>
                        <td align="left">
                            <asp:TextBox runat="server" ID="txtAnlasmaSKUYEG" Width="200px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                                BorderWidth="1px" Height="23px" Text="0" style="padding: 0px 3px 0px 3px" onkeypress="return isNumberKey(event)"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top; padding-top: 30px">Hizmet Bedelleri:</td>
                        <td align="left">
                            <div style="height: 10px"></div>
                            <asp:CheckBoxList ID="cblAnlasmaHizmetBedelleri" runat="server" AutoPostBack="True" 
                                OnSelectedIndexChanged="cblAnlasmaHizmetBedelleri_SelectedIndexChanged" RepeatDirection="Horizontal" RepeatLayout="Flow">
                            </asp:CheckBoxList>
                            <div style="height: 10px"></div>
                            <table cellpadding="0" cellspacing="0" style="text-align: center" runat="server" id="tblAnlasmaHizmetBedelleri" visible="false">
                                <tr>
                                    <td style="width: 80px">
                                    </td>
                                    <td style="width: 110px">
                                        KGT
                                    </td>
                                    <td style="width: 110px">
                                        NF
                                    </td>
                                </tr>
                            </table>
                            <asp:Panel ID="pnlAnlasmaHizmetBedelleri" runat="server">
                            <div runat="server" id="divAnlasmaHizmetBedeli1" style="padding: 3px; padding-left: 5px; padding-right: 5px" visible="false">
                                <table cellpadding="0" cellspacing="0" style="text-align: center">
                                    <tr style="text-align: center">
                                        <td style="width: 110px"></td>
                                        <td colspan="2"><asp:Label runat="server" ID="lblAnlasmaHizmetBedeli1" Width="160px"></asp:Label><br /></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 110px">
                                            Adet:
                                        </td>
                                        <td style="width: 110px">
                                            <asp:TextBox runat="server" ID="txtAnlasmaHizmetBedeli1TAHadet" Width="100px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                                                BorderWidth="1px" Height="23px" Text="0" style="padding: 0px 3px 0px 3px" onkeypress="return isNumberKey(event)"></asp:TextBox>
                                        </td>
                                        <td style="width: 110px">
                                            <asp:TextBox runat="server" ID="txtAnlasmaHizmetBedeli1YEGadet" Width="100px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                                                BorderWidth="1px" Height="23px" Text="0" style="padding: 0px 3px 0px 3px" onkeypress="return isNumberKey(event)"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 110px">
                                            Bedel:
                                        </td>
                                        <td style="width: 110px">
                                            <asp:TextBox runat="server" ID="txtAnlasmaHizmetBedeli1TAHbedel" Width="100px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                                                BorderWidth="1px" Height="23px" Text="0" style="padding: 0px 3px 0px 3px"></asp:TextBox>
                                        </td>
                                        <td style="width: 110px">
                                            <asp:TextBox runat="server" ID="txtAnlasmaHizmetBedeli1YEGbedel" Width="100px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                                                BorderWidth="1px" Height="23px" Text="0" style="padding: 0px 3px 0px 3px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <%--<tr>
                                        <td style="width: 110px">
                                            İskonto:
                                        </td>
                                        <td style="width: 110px">
                                            <asp:TextBox runat="server" ID="txtAnlasmaHizmetBedeli1TAHiskonto" Width="100px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                                                BorderWidth="1px" Height="23px" Text="0" style="padding: 0px 3px 0px 3px"></asp:TextBox>
                                        </td>
                                        <td style="width: 110px">
                                            <asp:TextBox runat="server" ID="txtAnlasmaHizmetBedeli1YEGiskonto" Width="100px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                                                BorderWidth="1px" Height="23px" Text="0" style="padding: 0px 3px 0px 3px"></asp:TextBox>
                                        </td>
                                    </tr>--%>
                                </table>
                            </div>
                            <div runat="server" id="divAnlasmaHizmetBedeli2" style="padding: 3px; padding-left: 5px; padding-right: 5px" visible="false">
                                <table cellpadding="0" cellspacing="0" style="text-align: center">
                                    <tr style="text-align: center">
                                        <td style="width: 110px"></td>
                                        <td colspan="2"><asp:Label runat="server" ID="lblAnlasmaHizmetBedeli2" Width="160px"></asp:Label><br /></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 110px">
                                            Adet:
                                        </td>
                                        <td style="width: 110px">
                                            <asp:TextBox runat="server" ID="txtAnlasmaHizmetBedeli2TAHadet" Width="100px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                                                BorderWidth="1px" Height="23px" Text="0" style="padding: 0px 3px 0px 3px" onkeypress="return isNumberKey(event)"></asp:TextBox>
                                        </td>
                                        <td style="width: 110px">
                                            <asp:TextBox runat="server" ID="txtAnlasmaHizmetBedeli2YEGadet" Width="100px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                                                BorderWidth="1px" Height="23px" Text="0" style="padding: 0px 3px 0px 3px" onkeypress="return isNumberKey(event)"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 110px">
                                            Bedel:
                                        </td>
                                        <td style="width: 110px">
                                            <asp:TextBox runat="server" ID="txtAnlasmaHizmetBedeli2TAHbedel" Width="100px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                                                BorderWidth="1px" Height="23px" Text="0" style="padding: 0px 3px 0px 3px"></asp:TextBox>
                                        </td>
                                        <td style="width: 110px">
                                            <asp:TextBox runat="server" ID="txtAnlasmaHizmetBedeli2YEGbedel" Width="100px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                                                BorderWidth="1px" Height="23px" Text="0" style="padding: 0px 3px 0px 3px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <%--<tr>
                                        <td style="width: 110px">
                                            İskonto:
                                        </td>
                                        <td style="width: 110px">
                                            <asp:TextBox runat="server" ID="txtAnlasmaHizmetBedeli2TAHiskonto" Width="100px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                                                BorderWidth="1px" Height="23px" Text="0" style="padding: 0px 3px 0px 3px"></asp:TextBox>
                                        </td>
                                        <td style="width: 110px">
                                            <asp:TextBox runat="server" ID="txtAnlasmaHizmetBedeli2YEGiskonto" Width="100px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                                                BorderWidth="1px" Height="23px" Text="0" style="padding: 0px 3px 0px 3px"></asp:TextBox>
                                        </td>
                                    </tr>--%>
                                </table>
                            </div>
                            <div runat="server" id="divAnlasmaHizmetBedeli3" style="padding: 3px; padding-left: 5px; padding-right: 5px" visible="false">
                                <table cellpadding="0" cellspacing="0" style="text-align: center">
                                    <tr style="text-align: center">
                                        <td style="width: 110px"></td>
                                        <td colspan="2"><asp:Label runat="server" ID="lblAnlasmaHizmetBedeli3" Width="160px"></asp:Label><br /></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 110px">
                                            Adet:
                                        </td>
                                        <td style="width: 110px">
                                            <asp:TextBox runat="server" ID="txtAnlasmaHizmetBedeli3TAHadet" Width="100px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                                                BorderWidth="1px" Height="23px" Text="0" style="padding: 0px 3px 0px 3px" onkeypress="return isNumberKey(event)"></asp:TextBox>
                                        </td>
                                        <td style="width: 110px">
                                            <asp:TextBox runat="server" ID="txtAnlasmaHizmetBedeli3YEGadet" Width="100px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                                                BorderWidth="1px" Height="23px" Text="0" style="padding: 0px 3px 0px 3px" onkeypress="return isNumberKey(event)"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 110px">
                                            Bedel:
                                        </td>
                                        <td style="width: 110px">
                                            <asp:TextBox runat="server" ID="txtAnlasmaHizmetBedeli3TAHbedel" Width="100px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                                                BorderWidth="1px" Height="23px" Text="0" style="padding: 0px 3px 0px 3px"></asp:TextBox>
                                        </td>
                                        <td style="width: 110px">
                                            <asp:TextBox runat="server" ID="txtAnlasmaHizmetBedeli3YEGbedel" Width="100px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                                                BorderWidth="1px" Height="23px" Text="0" style="padding: 0px 3px 0px 3px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <%--<tr>
                                        <td style="width: 110px">
                                            İskonto:
                                        </td>
                                        <td style="width: 110px">
                                            <asp:TextBox runat="server" ID="txtAnlasmaHizmetBedeli3TAHiskonto" Width="100px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                                                BorderWidth="1px" Height="23px" Text="0" style="padding: 0px 3px 0px 3px"></asp:TextBox>
                                        </td>
                                        <td style="width: 110px">
                                            <asp:TextBox runat="server" ID="txtAnlasmaHizmetBedeli3YEGiskonto" Width="100px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                                                BorderWidth="1px" Height="23px" Text="0" style="padding: 0px 3px 0px 3px"></asp:TextBox>
                                        </td>
                                    </tr>--%>
                                </table>
                            </div>
                            <div runat="server" id="divAnlasmaHizmetBedeli4" style="padding: 3px; padding-left: 5px; padding-right: 5px" visible="false">
                                <table cellpadding="0" cellspacing="0" style="text-align: center">
                                    <tr style="text-align: center">
                                        <td style="width: 110px"></td>
                                        <td colspan="2"><asp:Label runat="server" ID="lblAnlasmaHizmetBedeli4" Width="160px"></asp:Label><br /></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 110px">
                                            Adet:
                                        </td>
                                        <td style="width: 110px">
                                            <asp:TextBox runat="server" ID="txtAnlasmaHizmetBedeli4TAHadet" Width="100px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                                                BorderWidth="1px" Height="23px" Text="0" style="padding: 0px 3px 0px 3px" onkeypress="return isNumberKey(event)"></asp:TextBox>
                                        </td>
                                        <td style="width: 110px">
                                            <asp:TextBox runat="server" ID="txtAnlasmaHizmetBedeli4YEGadet" Width="100px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                                                BorderWidth="1px" Height="23px" Text="0" style="padding: 0px 3px 0px 3px" onkeypress="return isNumberKey(event)"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 110px">
                                            Bedel:
                                        </td>
                                        <td style="width: 110px">
                                            <asp:TextBox runat="server" ID="txtAnlasmaHizmetBedeli4TAHbedel" Width="100px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                                                BorderWidth="1px" Height="23px" Text="0" style="padding: 0px 3px 0px 3px"></asp:TextBox>
                                        </td>
                                        <td style="width: 110px">
                                            <asp:TextBox runat="server" ID="txtAnlasmaHizmetBedeli4YEGbedel" Width="100px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                                                BorderWidth="1px" Height="23px" Text="0" style="padding: 0px 3px 0px 3px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <%--<tr>
                                        <td style="width: 110px">
                                            İskonto:
                                        </td>
                                        <td style="width: 110px">
                                            <asp:TextBox runat="server" ID="txtAnlasmaHizmetBedeli4TAHiskonto" Width="100px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                                                BorderWidth="1px" Height="23px" Text="0" style="padding: 0px 3px 0px 3px"></asp:TextBox>
                                        </td>
                                        <td style="width: 110px">
                                            <asp:TextBox runat="server" ID="txtAnlasmaHizmetBedeli4YEGiskonto" Width="100px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                                                BorderWidth="1px" Height="23px" Text="0" style="padding: 0px 3px 0px 3px"></asp:TextBox>
                                        </td>
                                    </tr>--%>
                                </table>
                            </div>
                            <div runat="server" id="divAnlasmaHizmetBedeli5" style="padding: 3px; padding-left: 5px; padding-right: 5px" visible="false">
                                <table cellpadding="0" cellspacing="0" style="text-align: center">
                                    <tr style="text-align: center">
                                        <td style="width: 110px"></td>
                                        <td colspan="2"><asp:Label runat="server" ID="lblAnlasmaHizmetBedeli5" Width="160px"></asp:Label><br /></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 110px">
                                            Adet:
                                        </td>
                                        <td style="width: 110px">
                                            <asp:TextBox runat="server" ID="txtAnlasmaHizmetBedeli5TAHadet" Width="100px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                                                BorderWidth="1px" Height="23px" Text="0" style="padding: 0px 3px 0px 3px" onkeypress="return isNumberKey(event)"></asp:TextBox>
                                        </td>
                                        <td style="width: 110px">
                                            <asp:TextBox runat="server" ID="txtAnlasmaHizmetBedeli5YEGadet" Width="100px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                                                BorderWidth="1px" Height="23px" Text="0" style="padding: 0px 3px 0px 3px" onkeypress="return isNumberKey(event)"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 110px">
                                            Bedel:
                                        </td>
                                        <td style="width: 110px">
                                            <asp:TextBox runat="server" ID="txtAnlasmaHizmetBedeli5TAHbedel" Width="100px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                                                BorderWidth="1px" Height="23px" Text="0" style="padding: 0px 3px 0px 3px"></asp:TextBox>
                                        </td>
                                        <td style="width: 110px">
                                            <asp:TextBox runat="server" ID="txtAnlasmaHizmetBedeli5YEGbedel" Width="100px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                                                BorderWidth="1px" Height="23px" Text="0" style="padding: 0px 3px 0px 3px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <%--<tr>
                                        <td style="width: 110px">
                                            İskonto:
                                        </td>
                                        <td style="width: 110px">
                                            <asp:TextBox runat="server" ID="txtAnlasmaHizmetBedeli5TAHiskonto" Width="100px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                                                BorderWidth="1px" Height="23px" Text="0" style="padding: 0px 3px 0px 3px"></asp:TextBox>
                                        </td>
                                        <td style="width: 110px">
                                            <asp:TextBox runat="server" ID="txtAnlasmaHizmetBedeli5YEGiskonto" Width="100px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                                                BorderWidth="1px" Height="23px" Text="0" style="padding: 0px 3px 0px 3px"></asp:TextBox>
                                        </td>
                                    </tr>--%>
                                </table>
                            </div>
                            <div runat="server" id="divAnlasmaHizmetBedeli6" style="padding: 3px; padding-left: 5px; padding-right: 5px" visible="false">
                                <table cellpadding="0" cellspacing="0" style="text-align: center">
                                    <tr style="text-align: center">
                                        <td style="width: 110px"></td>
                                        <td colspan="2"><asp:Label runat="server" ID="lblAnlasmaHizmetBedeli6" Width="160px"></asp:Label><br /></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 110px">
                                            Adet:
                                        </td>
                                        <td style="width: 110px">
                                            <asp:TextBox runat="server" ID="txtAnlasmaHizmetBedeli6TAHadet" Width="100px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                                                BorderWidth="1px" Height="23px" Text="0" style="padding: 0px 3px 0px 3px" onkeypress="return isNumberKey(event)"></asp:TextBox>
                                        </td>
                                        <td style="width: 110px">
                                            <asp:TextBox runat="server" ID="txtAnlasmaHizmetBedeli6YEGadet" Width="100px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                                                BorderWidth="1px" Height="23px" Text="0" style="padding: 0px 3px 0px 3px" onkeypress="return isNumberKey(event)"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 110px">
                                            Bedel:
                                        </td>
                                        <td style="width: 110px">
                                            <asp:TextBox runat="server" ID="txtAnlasmaHizmetBedeli6TAHbedel" Width="100px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                                                BorderWidth="1px" Height="23px" Text="0" style="padding: 0px 3px 0px 3px"></asp:TextBox>
                                        </td>
                                        <td style="width: 110px">
                                            <asp:TextBox runat="server" ID="txtAnlasmaHizmetBedeli6YEGbedel" Width="100px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                                                BorderWidth="1px" Height="23px" Text="0" style="padding: 0px 3px 0px 3px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <%--<tr>
                                        <td style="width: 110px">
                                            İskonto:
                                        </td>
                                        <td style="width: 110px">
                                            <asp:TextBox runat="server" ID="txtAnlasmaHizmetBedeli6TAHiskonto" Width="100px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                                                BorderWidth="1px" Height="23px" Text="0" style="padding: 0px 3px 0px 3px"></asp:TextBox>
                                        </td>
                                        <td style="width: 110px">
                                            <asp:TextBox runat="server" ID="txtAnlasmaHizmetBedeli6YEGiskonto" Width="100px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                                                BorderWidth="1px" Height="23px" Text="0" style="padding: 0px 3px 0px 3px"></asp:TextBox>
                                        </td>
                                    </tr>--%>
                                </table>
                            </div>
                            <div runat="server" id="divAnlasmaHizmetBedeli7" style="padding: 3px; padding-left: 5px; padding-right: 5px" visible="false">
                                <table cellpadding="0" cellspacing="0" style="text-align: center">
                                    <tr style="text-align: center">
                                        <td style="width: 110px"></td>
                                        <td colspan="2"><asp:Label runat="server" ID="lblAnlasmaHizmetBedeli7" Width="160px"></asp:Label><br /></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 110px">
                                            Adet:
                                        </td>
                                        <td style="width: 110px">
                                            <asp:TextBox runat="server" ID="txtAnlasmaHizmetBedeli7TAHadet" Width="100px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                                                BorderWidth="1px" Height="23px" Text="0" style="padding: 0px 3px 0px 3px" onkeypress="return isNumberKey(event)"></asp:TextBox>
                                        </td>
                                        <td style="width: 110px">
                                            <asp:TextBox runat="server" ID="txtAnlasmaHizmetBedeli7YEGadet" Width="100px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                                                BorderWidth="1px" Height="23px" Text="0" style="padding: 0px 3px 0px 3px" onkeypress="return isNumberKey(event)"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 110px">
                                            Bedel:
                                        </td>
                                        <td style="width: 110px">
                                            <asp:TextBox runat="server" ID="txtAnlasmaHizmetBedeli7TAHbedel" Width="100px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                                                BorderWidth="1px" Height="23px" Text="0" style="padding: 0px 3px 0px 3px"></asp:TextBox>
                                        </td>
                                        <td style="width: 110px">
                                            <asp:TextBox runat="server" ID="txtAnlasmaHizmetBedeli7YEGbedel" Width="100px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                                                BorderWidth="1px" Height="23px" Text="0" style="padding: 0px 3px 0px 3px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <%--<tr>
                                        <td style="width: 110px">
                                            İskonto:
                                        </td>
                                        <td style="width: 110px">
                                            <asp:TextBox runat="server" ID="txtAnlasmaHizmetBedeli7TAHiskonto" Width="100px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                                                BorderWidth="1px" Height="23px" Text="0" style="padding: 0px 3px 0px 3px"></asp:TextBox>
                                        </td>
                                        <td style="width: 110px">
                                            <asp:TextBox runat="server" ID="txtAnlasmaHizmetBedeli7YEGiskonto" Width="100px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                                                BorderWidth="1px" Height="23px" Text="0" style="padding: 0px 3px 0px 3px"></asp:TextBox>
                                        </td>
                                    </tr>--%>
                                </table>
                            </div>
                            <div runat="server" id="divAnlasmaHizmetBedeli8" style="padding: 3px; padding-left: 5px; padding-right: 5px" visible="false">
                                <table cellpadding="0" cellspacing="0" style="text-align: center">
                                    <tr style="text-align: center">
                                        <td style="width: 110px"></td>
                                        <td colspan="2"><asp:Label runat="server" ID="lblAnlasmaHizmetBedeli8" Width="160px"></asp:Label><br /></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 110px">
                                            Adet:
                                        </td>
                                        <td style="width: 110px">
                                            <asp:TextBox runat="server" ID="txtAnlasmaHizmetBedeli8TAHadet" Width="100px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                                                BorderWidth="1px" Height="23px" Text="0" style="padding: 0px 3px 0px 3px" onkeypress="return isNumberKey(event)"></asp:TextBox>
                                        </td>
                                        <td style="width: 110px">
                                            <asp:TextBox runat="server" ID="txtAnlasmaHizmetBedeli8YEGadet" Width="100px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                                                BorderWidth="1px" Height="23px" Text="0" style="padding: 0px 3px 0px 3px" onkeypress="return isNumberKey(event)"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 110px">
                                            Bedel:
                                        </td>
                                        <td style="width: 110px">
                                            <asp:TextBox runat="server" ID="txtAnlasmaHizmetBedeli8TAHbedel" Width="100px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                                                BorderWidth="1px" Height="23px" Text="0" style="padding: 0px 3px 0px 3px"></asp:TextBox>
                                        </td>
                                        <td style="width: 110px">
                                            <asp:TextBox runat="server" ID="txtAnlasmaHizmetBedeli8YEGbedel" Width="100px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                                                BorderWidth="1px" Height="23px" Text="0" style="padding: 0px 3px 0px 3px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <%--<tr>
                                        <td style="width: 110px">
                                            İskonto:
                                        </td>
                                        <td style="width: 110px">
                                            <asp:TextBox runat="server" ID="txtAnlasmaHizmetBedeli8TAHiskonto" Width="100px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                                                BorderWidth="1px" Height="23px" Text="0" style="padding: 0px 3px 0px 3px"></asp:TextBox>
                                        </td>
                                        <td style="width: 110px">
                                            <asp:TextBox runat="server" ID="txtAnlasmaHizmetBedeli8YEGiskonto" Width="100px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                                                BorderWidth="1px" Height="23px" Text="0" style="padding: 0px 3px 0px 3px"></asp:TextBox>
                                        </td>
                                    </tr>--%>
                                </table>
                            </div>
                            <div runat="server" id="divAnlasmaHizmetBedeli9" style="padding: 3px; padding-left: 5px; padding-right: 5px" visible="false">
                                <table cellpadding="0" cellspacing="0" style="text-align: center">
                                    <tr style="text-align: center">
                                        <td style="width: 110px"></td>
                                        <td colspan="2"><asp:Label runat="server" ID="lblAnlasmaHizmetBedeli9" Width="160px"></asp:Label><br /></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 110px">
                                            Adet:
                                        </td>
                                        <td style="width: 110px">
                                            <asp:TextBox runat="server" ID="txtAnlasmaHizmetBedeli9TAHadet" Width="100px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                                                BorderWidth="1px" Height="23px" Text="0" style="padding: 0px 3px 0px 3px" onkeypress="return isNumberKey(event)"></asp:TextBox>
                                        </td>
                                        <td style="width: 110px">
                                            <asp:TextBox runat="server" ID="txtAnlasmaHizmetBedeli9YEGadet" Width="100px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                                                BorderWidth="1px" Height="23px" Text="0" style="padding: 0px 3px 0px 3px" onkeypress="return isNumberKey(event)"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 110px">
                                            Bedel:
                                        </td>
                                        <td style="width: 110px">
                                            <asp:TextBox runat="server" ID="txtAnlasmaHizmetBedeli9TAHbedel" Width="100px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                                                BorderWidth="1px" Height="23px" Text="0" style="padding: 0px 3px 0px 3px"></asp:TextBox>
                                        </td>
                                        <td style="width: 110px">
                                            <asp:TextBox runat="server" ID="txtAnlasmaHizmetBedeli9YEGbedel" Width="100px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                                                BorderWidth="1px" Height="23px" Text="0" style="padding: 0px 3px 0px 3px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <%--<tr>
                                        <td style="width: 110px">
                                            İskonto:
                                        </td>
                                        <td style="width: 110px">
                                            <asp:TextBox runat="server" ID="txtAnlasmaHizmetBedeli9TAHiskonto" Width="100px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                                                BorderWidth="1px" Height="23px" Text="0" style="padding: 0px 3px 0px 3px"></asp:TextBox>
                                        </td>
                                        <td style="width: 110px">
                                            <asp:TextBox runat="server" ID="txtAnlasmaHizmetBedeli9YEGiskonto" Width="100px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                                                BorderWidth="1px" Height="23px" Text="0" style="padding: 0px 3px 0px 3px"></asp:TextBox>
                                        </td>
                                    </tr>--%>
                                </table>
                            </div>
                            <div runat="server" id="divAnlasmaHizmetBedeli10" style="padding: 3px; padding-left: 5px; padding-right: 5px" visible="false">
                                <table cellpadding="0" cellspacing="0" style="text-align: center">
                                    <tr style="text-align: center">
                                        <td style="width: 110px"></td>
                                        <td colspan="2"><asp:Label runat="server" ID="lblAnlasmaHizmetBedeli10" Width="160px"></asp:Label><br /></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 110px">
                                            Adet:
                                        </td>
                                        <td style="width: 110px">
                                            <asp:TextBox runat="server" ID="txtAnlasmaHizmetBedeli10TAHadet" Width="100px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                                                BorderWidth="1px" Height="23px" Text="0" style="padding: 0px 3px 0px 3px" onkeypress="return isNumberKey(event)"></asp:TextBox>
                                        </td>
                                        <td style="width: 110px">
                                            <asp:TextBox runat="server" ID="txtAnlasmaHizmetBedeli10YEGadet" Width="100px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                                                BorderWidth="1px" Height="23px" Text="0" style="padding: 0px 3px 0px 3px" onkeypress="return isNumberKey(event)"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 110px">
                                            Bedel:
                                        </td>
                                        <td style="width: 110px">
                                            <asp:TextBox runat="server" ID="txtAnlasmaHizmetBedeli10TAHbedel" Width="100px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                                                BorderWidth="1px" Height="23px" Text="0" style="padding: 0px 3px 0px 3px"></asp:TextBox>
                                        </td>
                                        <td style="width: 110px">
                                            <asp:TextBox runat="server" ID="txtAnlasmaHizmetBedeli10YEGbedel" Width="100px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                                                BorderWidth="1px" Height="23px" Text="0" style="padding: 0px 3px 0px 3px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <%--<tr>
                                        <td style="width: 110px">
                                            İskonto:
                                        </td>
                                        <td style="width: 110px">
                                            <asp:TextBox runat="server" ID="txtAnlasmaHizmetBedeli10TAHiskonto" Width="100px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                                                BorderWidth="1px" Height="23px" Text="0" style="padding: 0px 3px 0px 3px"></asp:TextBox>
                                        </td>
                                        <td style="width: 110px">
                                            <asp:TextBox runat="server" ID="txtAnlasmaHizmetBedeli10YEGiskonto" Width="100px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                                                BorderWidth="1px" Height="23px" Text="0" style="padding: 0px 3px 0px 3px"></asp:TextBox>
                                        </td>
                                    </tr>--%>
                                </table>
                            </div>
                            <div runat="server" id="divAnlasmaHizmetBedeli11" style="padding: 3px; padding-left: 5px; padding-right: 5px" visible="false">
                                <table cellpadding="0" cellspacing="0" style="text-align: center">
                                    <tr style="text-align: center">
                                        <td style="width: 110px"></td>
                                        <td colspan="2"><asp:Label runat="server" ID="lblAnlasmaHizmetBedeli11" Width="160px"></asp:Label><br /></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 110px">
                                            Adet:
                                        </td>
                                        <td style="width: 110px">
                                            <asp:TextBox runat="server" ID="txtAnlasmaHizmetBedeli11TAHadet" Width="100px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                                                BorderWidth="1px" Height="23px" Text="0" style="padding: 0px 3px 0px 3px" onkeypress="return isNumberKey(event)"></asp:TextBox>
                                        </td>
                                        <td style="width: 110px">
                                            <asp:TextBox runat="server" ID="txtAnlasmaHizmetBedeli11YEGadet" Width="100px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                                                BorderWidth="1px" Height="23px" Text="0" style="padding: 0px 3px 0px 3px" onkeypress="return isNumberKey(event)"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 110px">
                                            Bedel:
                                        </td>
                                        <td style="width: 110px">
                                            <asp:TextBox runat="server" ID="txtAnlasmaHizmetBedeli11TAHbedel" Width="100px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                                                BorderWidth="1px" Height="23px" Text="0" style="padding: 0px 3px 0px 3px"></asp:TextBox>
                                        </td>
                                        <td style="width: 110px">
                                            <asp:TextBox runat="server" ID="txtAnlasmaHizmetBedeli11YEGbedel" Width="100px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                                                BorderWidth="1px" Height="23px" Text="0" style="padding: 0px 3px 0px 3px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <%--<tr>
                                        <td style="width: 110px">
                                            İskonto:
                                        </td>
                                        <td style="width: 110px">
                                            <asp:TextBox runat="server" ID="txtAnlasmaHizmetBedeli11TAHiskonto" Width="100px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                                                BorderWidth="1px" Height="23px" Text="0" style="padding: 0px 3px 0px 3px"></asp:TextBox>
                                        </td>
                                        <td style="width: 110px">
                                            <asp:TextBox runat="server" ID="txtAnlasmaHizmetBedeli11YEGiskonto" Width="100px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                                                BorderWidth="1px" Height="23px" Text="0" style="padding: 0px 3px 0px 3px"></asp:TextBox>
                                        </td>
                                    </tr>--%>
                                </table>
                            </div>
                            <div runat="server" id="divAnlasmaHizmetBedeli12" style="padding: 3px; padding-left: 5px; padding-right: 5px" visible="false">
                                <table cellpadding="0" cellspacing="0" style="text-align: center">
                                    <tr style="text-align: center">
                                        <td style="width: 110px"></td>
                                        <td colspan="2"><asp:Label runat="server" ID="lblAnlasmaHizmetBedeli12" Width="160px"></asp:Label><br /></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 110px">
                                            Adet:
                                        </td>
                                        <td style="width: 110px">
                                            <asp:TextBox runat="server" ID="txtAnlasmaHizmetBedeli12TAHadet" Width="100px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                                                BorderWidth="1px" Height="23px" Text="0" style="padding: 0px 3px 0px 3px" onkeypress="return isNumberKey(event)"></asp:TextBox>
                                        </td>
                                        <td style="width: 110px">
                                            <asp:TextBox runat="server" ID="txtAnlasmaHizmetBedeli12YEGadet" Width="100px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                                                BorderWidth="1px" Height="23px" Text="0" style="padding: 0px 3px 0px 3px" onkeypress="return isNumberKey(event)"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 110px">
                                            Bedel:
                                        </td>
                                        <td style="width: 110px">
                                            <asp:TextBox runat="server" ID="txtAnlasmaHizmetBedeli12TAHbedel" Width="100px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                                                BorderWidth="1px" Height="23px" Text="0" style="padding: 0px 3px 0px 3px"></asp:TextBox>
                                        </td>
                                        <td style="width: 110px">
                                            <asp:TextBox runat="server" ID="txtAnlasmaHizmetBedeli12YEGbedel" Width="100px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                                                BorderWidth="1px" Height="23px" Text="0" style="padding: 0px 3px 0px 3px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <%--<tr>
                                        <td style="width: 110px">
                                            İskonto:
                                        </td>
                                        <td style="width: 110px">
                                            <asp:TextBox runat="server" ID="txtAnlasmaHizmetBedeli12TAHiskonto" Width="100px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                                                BorderWidth="1px" Height="23px" Text="0" style="padding: 0px 3px 0px 3px"></asp:TextBox>
                                        </td>
                                        <td style="width: 110px">
                                            <asp:TextBox runat="server" ID="txtAnlasmaHizmetBedeli12YEGiskonto" Width="100px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                                                BorderWidth="1px" Height="23px" Text="0" style="padding: 0px 3px 0px 3px"></asp:TextBox>
                                        </td>
                                    </tr>--%>
                                </table>
                            </div>
                            <div runat="server" id="divAnlasmaHizmetBedeli13" style="padding: 3px; padding-left: 5px; padding-right: 5px" visible="false">
                                <table cellpadding="0" cellspacing="0" style="text-align: center">
                                    <tr style="text-align: center">
                                        <td style="width: 110px"></td>
                                        <td colspan="2"><asp:Label runat="server" ID="lblAnlasmaHizmetBedeli13" Width="160px"></asp:Label><br /></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 110px">
                                            Adet:
                                        </td>
                                        <td style="width: 110px">
                                            <asp:TextBox runat="server" ID="txtAnlasmaHizmetBedeli13TAHadet" Width="100px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                                                BorderWidth="1px" Height="23px" Text="0" style="padding: 0px 3px 0px 3px" onkeypress="return isNumberKey(event)"></asp:TextBox>
                                        </td>
                                        <td style="width: 110px">
                                            <asp:TextBox runat="server" ID="txtAnlasmaHizmetBedeli13YEGadet" Width="100px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                                                BorderWidth="1px" Height="23px" Text="0" style="padding: 0px 3px 0px 3px" onkeypress="return isNumberKey(event)"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 110px">
                                            Bedel:
                                        </td>
                                        <td style="width: 110px">
                                            <asp:TextBox runat="server" ID="txtAnlasmaHizmetBedeli13TAHbedel" Width="100px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                                                BorderWidth="1px" Height="23px" Text="0" style="padding: 0px 3px 0px 3px"></asp:TextBox>
                                        </td>
                                        <td style="width: 110px">
                                            <asp:TextBox runat="server" ID="txtAnlasmaHizmetBedeli13YEGbedel" Width="100px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                                                BorderWidth="1px" Height="23px" Text="0" style="padding: 0px 3px 0px 3px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <%--<tr>
                                        <td style="width: 110px">
                                            İskonto:
                                        </td>
                                        <td style="width: 110px">
                                            <asp:TextBox runat="server" ID="txtAnlasmaHizmetBedeli13TAHiskonto" Width="100px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                                                BorderWidth="1px" Height="23px" Text="0" style="padding: 0px 3px 0px 3px"></asp:TextBox>
                                        </td>
                                        <td style="width: 110px">
                                            <asp:TextBox runat="server" ID="txtAnlasmaHizmetBedeli13YEGiskonto" Width="100px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                                                BorderWidth="1px" Height="23px" Text="0" style="padding: 0px 3px 0px 3px"></asp:TextBox>
                                        </td>
                                    </tr>--%>
                                </table>
                            </div>
                            <div runat="server" id="divAnlasmaHizmetBedeli14" style="padding: 3px; padding-left: 5px; padding-right: 5px" visible="false">
                                <table cellpadding="0" cellspacing="0" style="text-align: center">
                                    <tr style="text-align: center">
                                        <td style="width: 110px"></td>
                                        <td colspan="2"><asp:Label runat="server" ID="lblAnlasmaHizmetBedeli14" Width="160px"></asp:Label><br /></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 110px">
                                            Adet:
                                        </td>
                                        <td style="width: 110px">
                                            <asp:TextBox runat="server" ID="txtAnlasmaHizmetBedeli14TAHadet" Width="100px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                                                BorderWidth="1px" Height="23px" Text="0" style="padding: 0px 3px 0px 3px" onkeypress="return isNumberKey(event)"></asp:TextBox>
                                        </td>
                                        <td style="width: 110px">
                                            <asp:TextBox runat="server" ID="txtAnlasmaHizmetBedeli14YEGadet" Width="100px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                                                BorderWidth="1px" Height="23px" Text="0" style="padding: 0px 3px 0px 3px" onkeypress="return isNumberKey(event)"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 110px">
                                            Bedel:
                                        </td>
                                        <td style="width: 110px">
                                            <asp:TextBox runat="server" ID="txtAnlasmaHizmetBedeli14TAHbedel" Width="100px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                                                BorderWidth="1px" Height="23px" Text="0" style="padding: 0px 3px 0px 3px"></asp:TextBox>
                                        </td>
                                        <td style="width: 110px">
                                            <asp:TextBox runat="server" ID="txtAnlasmaHizmetBedeli14YEGbedel" Width="100px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                                                BorderWidth="1px" Height="23px" Text="0" style="padding: 0px 3px 0px 3px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <%--<tr>
                                        <td style="width: 110px">
                                            İskonto:
                                        </td>
                                        <td style="width: 110px">
                                            <asp:TextBox runat="server" ID="txtAnlasmaHizmetBedeli14TAHiskonto" Width="100px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                                                BorderWidth="1px" Height="23px" Text="0" style="padding: 0px 3px 0px 3px"></asp:TextBox>
                                        </td>
                                        <td style="width: 110px">
                                            <asp:TextBox runat="server" ID="txtAnlasmaHizmetBedeli14YEGiskonto" Width="100px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                                                BorderWidth="1px" Height="23px" Text="0" style="padding: 0px 3px 0px 3px"></asp:TextBox>
                                        </td>
                                    </tr>--%>
                                </table>
                            </div>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td align="left"><asp:Label runat="server" Width="40px"></asp:Label>KGT<asp:Label runat="server" Width="90px"></asp:Label>NF</td>
                    </tr>
                    <tr>
                        <td>Fatura Altı İskonto:</td>
                        <td align="left">
                            <asp:TextBox runat="server" ID="txtAnlasmaTAHIsk" Width="100px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                                BorderWidth="1px" Height="23px" Text="0" style="padding: 0px 3px 0px 3px"></asp:TextBox>
                            <asp:TextBox runat="server" ID="txtAnlasmaYEGIsk" Width="100px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                                BorderWidth="1px" Height="23px" Text="0" style="padding: 0px 3px 0px 3px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Ciro Primi Aylık:</td>
                        <td align="left">
                            <asp:TextBox runat="server" ID="txtAnlasmaTAHCiro" Width="100px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                                BorderWidth="1px" Height="23px" Text="0" style="padding: 0px 3px 0px 3px"></asp:TextBox>
                            <asp:TextBox runat="server" ID="txtAnlasmaYEGCiro" Width="100px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                                BorderWidth="1px" Height="23px" Text="0" style="padding: 0px 3px 0px 3px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Ciro Primi 3 Aylık:</td>
                        <td align="left">
                            <asp:TextBox runat="server" ID="txtAnlasmaTAHCiro3" Width="100px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                                BorderWidth="1px" Height="23px" Text="0" style="padding: 0px 3px 0px 3px"></asp:TextBox>
                            <asp:TextBox runat="server" ID="txtAnlasmaYEGCiro3" Width="100px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                                BorderWidth="1px" Height="23px" Text="0" style="padding: 0px 3px 0px 3px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Ciro Primi 6 Aylık:</td>
                        <td align="left">
                            <asp:TextBox runat="server" ID="txtAnlasmaTAHCiro6" Width="100px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                                BorderWidth="1px" Height="23px" Text="0" style="padding: 0px 3px 0px 3px"></asp:TextBox>
                            <asp:TextBox runat="server" ID="txtAnlasmaYEGCiro6" Width="100px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                                BorderWidth="1px" Height="23px" Text="0" style="padding: 0px 3px 0px 3px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Ciro Primi Yıllık:</td>
                        <td align="left">
                            <asp:TextBox runat="server" ID="txtAnlasmaTAHCiro12" Width="100px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                                BorderWidth="1px" Height="23px" Text="0" style="padding: 0px 3px 0px 3px"></asp:TextBox>
                            <asp:TextBox runat="server" ID="txtAnlasmaYEGCiro12" Width="100px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                                BorderWidth="1px" Height="23px" Text="0" style="padding: 0px 3px 0px 3px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Ciro Primi Fatura Altı:</td>
                        <td align="left">
                            <asp:TextBox runat="server" ID="txtAnlasmaTAHCiroIsk" Width="100px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                                BorderWidth="1px" Height="23px" Text="0" style="padding: 0px 3px 0px 3px"></asp:TextBox>
                            <asp:TextBox runat="server" ID="txtAnlasmaYEGCiroIsk" Width="100px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                                BorderWidth="1px" Height="23px" Text="0" style="padding: 0px 3px 0px 3px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Anlaşma Dışı Bedeller:</td>
                        <td align="left">
                            <asp:TextBox runat="server" ID="txtAnlasmaTAHAnlasmaDisiBedeller" Width="100px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                                BorderWidth="1px" Height="23px" Text="0" style="padding: 0px 3px 0px 3px"></asp:TextBox>
                            <asp:TextBox runat="server" ID="txtAnlasmaYEGAnlasmaDisiBedeller" Width="100px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                                BorderWidth="1px" Height="23px" Text="0" style="padding: 0px 3px 0px 3px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Öngörülen Toplam Ciro:</td>
                        <td align="left">
                            <asp:TextBox runat="server" ID="txtAnlasmaTAHToplamCiro" Width="100px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                                BorderWidth="1px" Height="23px" Text="0" style="padding: 0px 3px 0px 3px"></asp:TextBox>
                            <asp:TextBox runat="server" ID="txtAnlasmaYEGToplamCiro" Width="100px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                                BorderWidth="1px" Height="23px" Text="0" style="padding: 0px 3px 0px 3px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>* Tüm Bedeller Toplamı:</td>
                        <td align="left">
                            <asp:TextBox runat="server" ID="txtAnlasmaTAHTumBedeller" Width="100px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                                BorderWidth="1px" Height="23px" style="padding: 0px 3px 0px 3px" Text="" Enabled="false"></asp:TextBox>
                            <asp:TextBox runat="server" ID="txtAnlasmaYEGTumBedeller" Width="100px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                                BorderWidth="1px" Height="23px" style="padding: 0px 3px 0px 3px" Text="" Enabled="false"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>* Toplam Yıl Sonu Maliyet:</td>
                        <td align="left">
                            <asp:TextBox runat="server" ID="txtAnlasmaTAHYilSonuMaliyet" Width="100px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                                BorderWidth="1px" Height="23px" style="padding: 0px 3px 0px 3px" Text="" Enabled="false"></asp:TextBox>
                            <asp:TextBox runat="server" ID="txtAnlasmaYEGYilSonuMaliyet" Width="100px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                                BorderWidth="1px" Height="23px" style="padding: 0px 3px 0px 3px" Text="" Enabled="false"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>* Ciro Primi Dahil Net Maliyet:</td>
                        <td align="left">
                            <asp:TextBox runat="server" ID="txtAnlasmaTAHCiroPrimiDahil" Width="100px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                                BorderWidth="1px" Height="23px" style="padding: 0px 3px 0px 3px" Text="" Enabled="false"></asp:TextBox>
                            <asp:TextBox runat="server" ID="txtAnlasmaYEGCiroPrimiDahil" Width="100px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                                BorderWidth="1px" Height="23px" style="padding: 0px 3px 0px 3px" Text="" Enabled="false"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Açıklama:</td>
                        <td align="left">
                            <asp:TextBox runat="server" ID="txtAnlasmaAciklama" Width="200px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                                BorderWidth="1px" Height="23px" style="padding: 0px 3px 0px 3px" Text=""></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Geçici anlaşma:</td>
                        <td align="left"><br />
                            <asp:CheckBox runat="server" ID="cbAnlasmaGecici" Checked="false" Text=" Bu anlaşma geçici anlaşmadır" /><br /><br />
                        </td>
                    </tr>
                    <tr>
                        <td>Resim dosyası:</td>
                        <td align="left">
                            <asp:FileUpload ID="fuAnlasma" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td align="left">
                            <asp:Label runat="server" ID="lblAnlasmaHata" ForeColor="Red"></asp:Label>
                        </td>
                    </tr>
                    </table>
                    <br />
                    <asp:LinkButton runat="server" ID="lbAnlasmaHesapla" 
                        onclick="lbAnlasmaHesapla_Click">Maliyeti Hesapla</asp:LinkButton>
                    <asp:Label ID="Label3" runat="server" Width="50px"></asp:Label>
                    <asp:LinkButton runat="server" ID="lbAnlasmaGir" 
                        onclick="lbAnlasmaGir_Click">Anlaşma Talebi Yap</asp:LinkButton>
                    <asp:Label ID="Label2" runat="server" Width="50px"></asp:Label>
                    <asp:LinkButton runat="server" ID="lbAnlasmaKapat" 
                        onclick="lbAnlasmaKapat_Click">Kapat</asp:LinkButton>
                </td>
                </tr>
                </table>
            </div>

       <table cellpadding="0" cellspacing="0" style="width: 100%; font-size: 10px; font-family: Verdana; background-color: #FFFFFF">
        <tr>
            <td>
                <div style="font-size: 12px; vertical-align: middle; width: 1000px; text-align: left; padding-bottom: 15px">
                <div class="Baslik" style="padding: 15px 10px 0px 10px; vertical-align: middle;"><table cellpadding="0" cellspacing="0"><tr><td><img src="img/ic_uygulamalar.png" /></td><td>Uygulamalar</td></tr></table></div>
                <table cellpadding="0" cellspacing="0" style="margin-left: 25px">
                <tr><td style="width: 33%" align="left"><table><tr><td><img src="img/ic_katalog.png" width="16px" /></td><td><a href="katalog.aspx">Ürün Kataloğu</a></td></tr></table></td></tr>
                <tr><td style="width: 33%" align="left" runat="server" id="tdEFatura"><table><tr><td><img src="img/ic_efatura.png" width="16px" /></td><td><asp:LinkButton runat="server" ID="lbEFatura" OnClick="lbEFatura_Click">E-Fatura XML Entegrasyonu</asp:LinkButton></td></tr><tr><td><img src="img/ic_help.png" width="16px" /></td><td><a href="efaturayardim.html">E-Fatura Yardım Sayfası</a></td></tr></table></td></tr>
                <tr><td style="width: 33%" align="left" runat="server" id="tdSaticiKampanya"><table><tr><td><img src="img/ic_saticikampanya.png" width="16px" /></td><td><a href="saticikampanya.html">Kampanya</a></td></tr></table></td></tr>
                <tr><td style="width: 33%" align="left" runat="server" id="tdFiyatInceleme"><table><tr><td><img src="img/ic_fiyatinceleme.png" width="16px" /></td><td><asp:LinkButton runat="server" ID="lbFiyatlar" OnClick="lbFiyatlar_Click">Ürün Fiyat İnceleme</asp:LinkButton></td></tr></table></td></tr>
                <tr><td style="width: 33%" align="left" runat="server" id="td500"><table><tr><td><img src="img/ic_fiyatlisteleri.png" width="16px" /></td><td><asp:LinkButton runat="server" ID="lb500" OnClick="lb500_Click">500'lü Fiyat Ürün Aktarımı</asp:LinkButton></td></tr></table></td></tr>
                <tr><td style="width: 33%" align="left" runat="server" id="tdGorseller"><table><tr><td><img src="img/ic_katalog.png" width="16px" /></td><td><asp:LinkButton runat="server" ID="lbGorseller" OnClick="lbGorseller_Click">Görseller</asp:LinkButton></td></tr></table></td></tr>
                <tr><td style="width: 33%" align="left" runat="server" id="tdBrosurler"><table><tr><td><img src="img/ic_katalog.png" width="16px" /></td><td><asp:LinkButton runat="server" ID="lbBrosurler" OnClick="lbBrosurler_Click">Broşürler</asp:LinkButton></td></tr></table></td></tr>
                <tr><td style="width: 33%" align="left" runat="server" id="tdBrosurler2"><table><tr><td><img src="img/ic_katalog.png" width="16px" /></td><td><asp:LinkButton runat="server" ID="lbBrosurler2" OnClick="lbBrosurler2_Click">Katalogda olmayan ürünler</asp:LinkButton></td></tr></table></td></tr>
                <tr><td style="width: 33%" align="left" runat="server" id="tdBrosurler3"><table><tr><td><img src="img/ic_katalog.png" width="16px" /></td><td><asp:LinkButton runat="server" ID="lbBrosurler3" OnClick="lbBrosurler3_Click">Teşhir Örnekleri</asp:LinkButton></td></tr></table></td></tr>
                <tr><td style="width: 33%" align="left" runat="server" id="tdBrosurler4"><table><tr><td><img src="img/ic_katalog.png" width="16px" /></td><td><asp:LinkButton runat="server" ID="lbBrosurler4" OnClick="lbBrosurler4_Click">Sunumlar</asp:LinkButton></td></tr></table></td></tr>
                <tr><td style="width: 33%" align="left" runat="server" id="tdBrosurler5"><table><tr><td><img src="img/ic_fiyatinceleme.png" width="16px" /></td><td><asp:LinkButton runat="server" ID="lbBrosurler5" OnClick="lbBrosurler5_Click">Sosyal Medya Hesapları</asp:LinkButton></td></tr></table></td></tr>
                <tr><td style="width: 33%" align="left" runat="server" id="tdBrosurler6"><table><tr><td><img src="img/ic_fiyatinceleme.png" width="16px" /></td><td><asp:LinkButton runat="server" ID="lbBrosurler6" OnClick="lbBrosurler6_Click">Ödeme Sistemleri</asp:LinkButton></td></tr></table></td></tr>
                <tr><td style="width: 33%" align="left" runat="server" id="tdFormlar"><table><tr><td><img src="img/ic_saticikampanya.png" width="16px" /></td><td><asp:LinkButton runat="server" ID="lbFormlar" OnClick="lbFormlar_Click">Formlar</asp:LinkButton></td></tr></table></td></tr>
                <tr><td style="width: 33%" align="left" runat="server" id="tdKimNe"><table><tr><td><img src="img/ic_saticikampanya.png" width="16px" /></td><td><asp:LinkButton runat="server" ID="lbKimNe" OnClick="lbKimNe_Click">Kim Hangi İşi Yapıyor?</asp:LinkButton></td></tr></table></td></tr>
                <tr><td style="width: 33%" align="left" runat="server" id="tdAdresBankasi"><table><tr><td><img src="img/ic_saticikampanya.png" width="16px" /></td><td><asp:LinkButton runat="server" ID="lbAdresBankasi" OnClick="lbAdresBankasi_Click">Adres Bankası</asp:LinkButton></td></tr></table></td></tr>
                <tr><td style="width: 33%" align="left" runat="server" id="tdRutlar"><table><tr><td><img src="img/ic_rutlar.png" width="16px" /></td><td><asp:LinkButton runat="server" ID="lbRutlar" OnClick="lbRutlar_Click">Rutlar</asp:LinkButton></td></tr></table></td></tr>
                <tr><td style="width: 33%" align="left" runat="server" id="tdKonumlar"><table><tr><td><img src="img/marker.png" width="16px" /></td><td><asp:LinkButton ID="lbKonumlar" runat="server" OnClick="lbKonumlar_Click">Konumlar</asp:LinkButton></td></tr></table></td></tr>
                <tr><td style="width: 33%" align="left" runat="server" id="tdDestek"><table><tr><td><img src="img/ic_rutlar.png" width="16px" /></td><td><a href='http://95.0.47.130/Sulchat/index.html?kul=<%=((Sultanlar.DatabaseObject.Internet.Musteriler)Session["Musteri"]).strAd + "_" + ((Sultanlar.DatabaseObject.Internet.Musteriler)Session["Musteri"]).strSoyad %>' target="_blank">Canlı Destek</a></td></tr></table></td></tr>
                <tr><td style="width: 33%" align="left" runat="server" id="tdResimler"><table><tr><td><img src="img/ic_fiyatlisteleri.png" width="16px" /></td><td><asp:LinkButton ID="lbResimler" runat="server" OnClick="lbResimler_Click">Müşteri Resimleri</asp:LinkButton></td></tr></table></td></tr>
                </table>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <div class="Baslik" style="padding: 15px 10px 0px 10px; vertical-align: middle;">
                <table cellpadding="0" cellspacing="0">
                <tr>
                <td><img src="img/ic_fiyatlisteleri.png" /></td>
                <td>Fiyat Listeleri</td>
                <td style="padding-left: 20px"><input type="button" id="flHide" value="Gizle" onclick="flGizle()" style="font-size: 10px" />&nbsp;<input type="button" id="flShow" value="Göster" onclick="flGoster()" style="font-size: 10px" /></td>
                </tr>
                </table>
                </div>
            </td>
        </tr>
        <tr>
            <td style="padding-left: 25px">
            <div id="divFl" style="z-index: 1;">
                <asp:Repeater runat="server" ID="rpFiyatListeleri">
                    <HeaderTemplate>
                    <table cellpadding="4" cellspacing="0">
                    <tr style="color: #D00000">
                    <td style="width: 150px; border-bottom: 1px solid #CCCCCC; text-align: center">
                        Fiyat Tipi
                    </td>
                    <td style="width: 150px; border-bottom: 1px solid #CCCCCC; text-align: center">
                        İşlem
                    </td>
                    </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr onmouseover="Satir(this,true)" onmouseout="Satir(this,false)">
                            <td style="width: 150px; text-align: left">
                                <%#Eval("ACIKLAMA")%>
                            </td>
                            <td style="width: 550px">
                                <a href='fiyatlisteindir.aspx?fid=<%#Eval("intFiyatTipi") %>'>Excel İndir</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <a href='fiyatlisteindir.aspx?fid=<%#Eval("intFiyatTipi") %>&xml=yes'><asp:Label runat="server" Text="XML İndir"></asp:Label></a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <%--<%#Eval("intFiyatTipi").ToString() == "3" || Eval("intFiyatTipi").ToString() == "4" || Eval("intFiyatTipi").ToString() == "5" || Eval("intFiyatTipi").ToString() == "6" || Eval("intFiyatTipi").ToString() == "7" || Eval("intFiyatTipi").ToString() == "8" || Eval("intFiyatTipi").ToString() == "10" || Eval("intFiyatTipi").ToString() == "11" || Eval("intFiyatTipi").ToString() == "17" || Eval("intFiyatTipi").ToString() == "18"%>--%>
                                <a href='fiyatlisteindir.aspx?fid=<%#Eval("intFiyatTipi") %>&isxml=yes'><asp:Label runat="server" Text="Ideasoft Uyumlu XML İndir"></asp:Label></a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <a href='fiyatlisteindir.aspx?fid=<%#Eval("intFiyatTipi") %>&ptxml=yes'><asp:Label runat="server" Text="Proticaret Uyumlu XML İndir"></asp:Label></a>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate></table></FooterTemplate>
                </asp:Repeater>
            </div>
            </td>
        </tr>
    </table>
    <div style="width: 100%; background-color: #FFFFFF">
    <div style="width: 1000px; background-position: center center; background-image: url('img/bg-logo.jpg'); background-repeat: no-repeat;">
    <table cellpadding="0" cellspacing="0" style="width: 1000px; font-size: 10px; font-family: Verdana" runat="server" id="tblRutlar" visible="false">
        <tr>
            <td style="padding-top: 15px">
                <div class="Baslik" style="padding: 15px 10px 0px 10px; vertical-align: middle;"><table cellpadding="0" cellspacing="0"><tr><td><img src="img/ic_rutlar.png" /></td><td>Ziyaret <asp:Label runat="server" Width="45px"></asp:Label><asp:ImageButton Visible="false" runat="server" ID="ibTarih" ImageUrl="img/tarih.gif" OnClick="ibTarih_Click" /></td></tr></table></div>
            </td>
        </tr>
        <tr>
            <td style="padding-left: 25px">
                <asp:DataList ID="dlRutlar" runat="server">
                    <HeaderTemplate><table cellpadding="4" cellspacing="0">
                        <tr style="color: #D00000">
                            <td style="width: 80px; text-align: center; height: 20px; border-bottom: 1px solid #CCCCCC">Ziyaret Günü</td>
                            <td style="width: 80px; text-align: center; height: 20px; border-bottom: 1px solid #CCCCCC">Cari Kod</td>
                            <td style="width: 284px; text-align: center; height: 20px; border-bottom: 1px solid #CCCCCC">Cari Ünvan</td>
                            <td style="width: 200px; text-align: center; height: 20px; border-bottom: 1px solid #CCCCCC">Not</td>
                            <td style="width: 300px; text-align: center; height: 20px; border-bottom: 1px solid #CCCCCC">İşlemler</td>
                        </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr onmouseover="Satir(this,true)" onmouseout="Satir(this,false)" runat="server" title='<%#Eval("[SMREF]") %>' class='<%#"rutArka" + (Convert.ToInt32(Eval("[YAPILDI]")) > 0).ToString()%>'>
                            <td style="width: 80px; text-align: center"><%#Convert.ToDateTime(Eval("[ZIYGUN]")).ToShortDateString()%></td>
                            <td style="width: 80px; text-align: center"><%#Eval("[SMREF]")%></td>
                            <td style="width: 284px; text-align: left"><%#Eval("[SUBE]")%><asp:Label runat="server" Font-Bold="true" ForeColor="Red" Text=" (Ziy.Yapıldı)" Visible='<%#Convert.ToInt32(Eval("[YAPILDI]")) > 0%>'></asp:Label></td>
                            <td style="width: 200px; text-align: center"><%#Sultanlar.DatabaseObject.Internet.Rutlar.GetRutNot4Liste(Eval("BARKOD").ToString())%></td>
                            <td style="width: 300px; text-align: center">
                                <input type="hidden" value='<%#Eval("[SMREF]") %>' id="SMREF" runat="server" />
                                <input type="hidden" value='<%#Eval("[BARKOD]") %>' id="BARKOD" runat="server" />
                                <input type="hidden" value='<%#Eval("[MTIP]") %>' id="MTIP" runat="server" />
                                <input type="hidden" value='<%#Convert.ToDateTime(Eval("[ZIYGUN]")).ToShortDateString()%>' id="ZIYGUN" runat="server" />
                                <asp:LinkButton ID="lbSatTemRutZiyaretBaslat" runat="server" Text="Ziyaret Başlat" OnClientClick="lbZiyaretBaslat_Click()" OnClick="ZiyaretBaslat_Click" Visible='<%#Convert.ToBoolean(Eval("[BugunMu]")) && (((Sultanlar.DatabaseObject.Internet.Musteriler)Session["Musteri"]).tintUyeTipiID == 4 || ((Sultanlar.DatabaseObject.Internet.Musteriler)Session["Musteri"]).tintUyeTipiID == 6)%>'></asp:LinkButton>
                                <asp:Label runat="server" Width="20px"></asp:Label>
                                <asp:LinkButton ID="lbSatTemRutSiparisVer" runat="server" Text="Sipariş Ver" OnClick="SiparisVer_Click" Visible='<%#Convert.ToBoolean(Eval("[BugunMu]")) && (((Sultanlar.DatabaseObject.Internet.Musteriler)Session["Musteri"]).tintUyeTipiID == 4)%>'></asp:LinkButton>
                                <asp:Label runat="server" Width="20px"></asp:Label>
                                <asp:LinkButton ID="lbSatTemRutZiyaretSonlandir" Enabled="false" runat="server" Text="Ziyaret Sonlandır" OnClientClick="lbZiyaretSonlandirClick()" OnClick="ZiyaretSonlandir_Click" Visible='<%#Convert.ToBoolean(Eval("[BugunMu]")) && (((Sultanlar.DatabaseObject.Internet.Musteriler)Session["Musteri"]).tintUyeTipiID == 4 || ((Sultanlar.DatabaseObject.Internet.Musteriler)Session["Musteri"]).tintUyeTipiID == 6)%>'></asp:LinkButton>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate></table></FooterTemplate>
                </asp:DataList>
                <asp:Label runat="server" ID="lblRutYok" Font-Italic="true" Text="- Bulunamadı -" Visible="false" style="padding-left: 100px"></asp:Label>
            </td>
        </tr>
    </table>
    <table cellpadding="0" cellspacing="0" style="width: 1000px; font-size: 10px; font-family: Verdana"><tr><td>
    <div style="font-size: 12px; font-weight: bold; padding: 15px 10px 5px 50px; vertical-align: middle">
        <asp:LinkButton runat="server" id="lbSonZiyaret" OnClick="lbSonZiyaret_Click">Son Ziyaretim</asp:LinkButton>
        <asp:Label runat="server" Width="100px"></asp:Label>
        <asp:LinkButton runat="server" id="lbFarkliZiyaretAc" OnClick="lbFarkliZiyaretAc_Click">Rut dışı ziyaret başlat</asp:LinkButton>
    </div>
    </td></tr></table>
    <table runat="server" id="tableAsagi" cellpadding="0" cellspacing="0" style="width: 1000px; height: 400px; font-size: 10px; font-family: Verdana">
        <tr>
            <td valign="top">
                <div class="Baslik" style="padding: 15px 10px 0px 10px;">
                <table cellpadding="0" cellspacing="0"><tr><td>
                <img src="img/ic_hesaplar.png" /></td><td>Hesaplar
                <asp:Label runat="server" Width="25px"></asp:Label>
                <asp:ImageButton runat="server" ID="ibCHduzenle" ImageUrl="img/chduzenle.gif" OnClick="ibCHduzenle_Click" Visible="false" />
                <%--<span style="font-size: 11px; font-weight:bold; font-style: italic" runat="server" id="spanCHeklemecikarma" Visible="false">C/H Ekleme-Çıkarma (Sadece NST)</span>--%>
                </td></tr></table>
                </div>
                <asp:DataList ID="dlCariHesaplar" runat="server" Visible="true">
                    <HeaderTemplate><table cellpadding="4" cellspacing="0">
                        <tr style="color: #D00000">
                            <td style="width: 80px; text-align: center; height: 20px; border-bottom: 1px solid #CCCCCC">Cari Kod</td>
                            <td style="width: 380px; text-align: center; height: 20px; border-bottom: 1px solid #CCCCCC">Cari Ünvan</td>
                            <td style="width: 120px; text-align: center; height: 20px; border-bottom: 1px solid #CCCCCC">Toplam B/A</td>
                            <%--<td style="width: 120px; text-align: center; height: 20px; border-bottom: 1px solid #CCCCCC">Kullanılabilir Limit</td>--%>
                            <td style="width: 80px; text-align: center; height: 20px; border-bottom: 1px solid #CCCCCC">VGB Gün</td>
                            <td style="width: 80px; text-align: center; height: 20px; border-bottom: 1px solid #CCCCCC">VGB Toplam</td>
                        </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr onmouseover="Satir(this,true)" onmouseout="Satir(this,false)">
                            <td style="width: 80px; text-align: center"><%#Eval("[GMREF]")%></td>
                            <td style="width: 380px; text-align: left"><%#Eval("[MUSTERI]")%></td>
                            <td style="width: 120px; text-align: center"><%#Eval("[BAKIYE]") != DBNull.Value ? Convert.ToDecimal(Eval("[BAKIYE]")).ToString("C3") : ""%></td>
                            <%--<td style="width: 120px; text-align: right"><%#Eval("[RISK BKY]") != DBNull.Value ? Convert.ToDecimal(Eval("[RISK BKY]")).ToString("C3") : ""%></td>--%>
                            <td style="width: 80px; text-align: center"><%#Eval("[VGB GUN]")%></td>
                            <td style="width: 80px; text-align: right"><%#Eval("[VGB TOP]") != DBNull.Value ? Convert.ToDecimal(Eval("[VGB TOP]")).ToString("C3") : ""%></td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate></table></FooterTemplate>
                </asp:DataList>
                
                <asp:DataList ID="dlCariHesaplarSube" runat="server" Visible="false">
                    <HeaderTemplate><table cellpadding="4" cellspacing="0" style="margin-top: 15px">
                        <tr style="color: #D00000">
                            <td style="width: 80px; text-align: center; height: 20px; border-bottom: 1px solid #CCCCCC">Cari Kod</td>
                            <td style="width: 480px; text-align: center; height: 20px; border-bottom: 1px solid #CCCCCC">Cari Ünvan</td>
                            <td></td>
                        </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr onmouseover="Satir(this,true)" onmouseout="Satir(this,false)">
                            <td style="width: 80px; text-align: center"><%#Eval("[SMREF]")%></td>
                            <td style="width: 480px; text-align: left"><%#Eval("[SUBE]")%></td>
                            <td><input type="hidden" value='<%#Eval("[SMREF]") %>' id="SMREF" runat="server" />
                            <asp:LinkButton runat="server" OnClick="SiparisVer_Click">Sipariş ver</asp:LinkButton>
                            <%--<asp:Label runat="server" Width="20px"></asp:Label>
                            <asp:LinkButton runat="server" OnClick="IadeVer_Click">İade talep</asp:LinkButton>--%>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate></table></FooterTemplate>
                </asp:DataList>
                <div runat="server" id="divMusteriSiparisIadeButton">
                <br />
                <table cellpadding="0" cellspacing="0" style="margin-left: 650px; font-size: 12px; font-weight: bold">
                <tr>
                <td style="padding-left: 30px"><img src="img/ic_siparis.png" /></td><td style="padding-left: 5px"><asp:LinkButton ID="lbSiparis" runat="server" onclick="SiparisVer_Click">Sipariş ver</asp:LinkButton></td>
                <td style="padding-left: 30px; display: none; visibility: collapse"><img src="img/ic_iade.png" /></td><td style="padding-left: 5px; display: none; visibility: collapse"><asp:LinkButton ID="lbIade" runat="server" onclick="IadeVer_Click">İade talep</asp:LinkButton></td>
                </tr>
                </table>
                </div>

                <div runat="server" id="divSefAltlar" visible="false" style="padding-left: 30px; padding-bottom: 10px">
                Satış Temsilcileri:
                <asp:Label runat="server" Width="10px"></asp:Label>
                <asp:DropDownList runat="server" ID="ddlSefAltlar" AutoPostBack="true" Width="400px"
                    Font-Bold="False" Font-Italic="False" Height="25px" OnSelectedIndexChanged="ddlSefAltlar_SelectedIndexChanged"
                    Font-Overline="False" Font-Size="12px" Font-Strikeout="False" 
                    Font-Underline="False" style="padding: 3px 3px 3px 3px;border:1px solid #CCCCCC;background:#ededed;" ForeColor="#006699"></asp:DropDownList>
                <asp:Label runat="server" Width="10px"></asp:Label>
                <asp:DropDownList runat="server" ID="ddlSefAltlarBayiSatici" AutoPostBack="true" Width="100px"
                    Font-Bold="False" Font-Italic="False" Height="25px" OnSelectedIndexChanged="ddlSefAltlar_SelectedIndexChanged"
                    Font-Overline="False" Font-Size="12px" Font-Strikeout="False" 
                    Font-Underline="False" style="padding: 3px 3px 3px 3px;border:1px solid #CCCCCC;background:#ededed;" ForeColor="#006699">
                    <asp:ListItem Text="Satıcı" Value="0" Selected="True"></asp:ListItem>
                    <asp:ListItem Text="Bayi" Value="1"></asp:ListItem>
                </asp:DropDownList>
                </div>

                <div runat="server" id="divCHarama" visible="false" style="padding-left:30px; padding-bottom: 20px">
                    C/H Arama:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                    <asp:TextBox runat="server" ID="txtMusteriAra" Width="150px" onkeypress="return clickButton(event,'btnMusteriAra')"
                        ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" BorderWidth="1px" style="padding: 3px 3px 3px 3px"></asp:TextBox>&nbsp;
                    <asp:Button runat="server" ID="btnMusteriAra" Width="100px" Text="Ara" OnClick="btnMusteriAra_Click" 
                        BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" ForeColor="#6D8AAA" />
                </div>

                <input type="hidden" runat="server" id="inputBayiGibi" value="0" />
                <asp:DataList ID="dlSatTemCariler" runat="server" Visible="false">
                    <HeaderTemplate><table cellpadding="4" cellspacing="0">
                        <tr style="color: #D00000">
                            <td style="width: 100px; text-align: center; height: 20px; border-bottom: 1px solid #CCCCCC"><span class="kucukbilgiGoster" title="Siparişin bakiye kalmasını istiyorsanız işaretleyiniz">Bakiye Sipariş</span></td>
                            <%--<td style="width: 100px; text-align: center; height: 20px; border-bottom: 1px solid #CCCCCC"><u>NST Son Ay Net S.</u></td>--%>
                            <td style="width: 80px; text-align: center; height: 20px; border-bottom: 1px solid #CCCCCC">Cari Kod</td>
                            <td style="width: 300px; text-align: center; height: 20px; border-bottom: 1px solid #CCCCCC">Cari Ünvan</td>
                            <%--<td style="width: 100px;"></td>--%>
                            <td style="width: 80px;"></td>
                            <td style="width: 350px;"></td>
                            <%--<td style="width: 100px;"></td>--%>
                        </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr onmouseover="Satir(this,true)" onmouseout="Satir(this,false)"> <%--runat="server" id="trtrtr" title='<%#Eval("[SMREF]") %>'--%>
                            <td style="width: 100px; text-align: center;"><div runat="server" visible='<%#Eval("[MUS KOD]") != "--------"%>'><asp:CheckBox runat="server" AutoPostBack="true" ToolTip='<%# Eval("SMREF") != DBNull.Value ? Eval("SMREF") : Eval("GMREF") %>' OnCheckedChanged="cbBakiye_OnCheckedChanged" Checked='<%# Sultanlar.DatabaseObject.Internet.WebMusteriEk.GetBakiye(Convert.ToInt32(Eval("SMREF") != DBNull.Value ? Eval("SMREF") : Eval("GMREF")), (((Sultanlar.DatabaseObject.Internet.Musteriler)Session["Musteri"]).intSLSREF == 0 ? Convert.ToInt32(ddlSefAltlar.SelectedValue) : ((Sultanlar.DatabaseObject.Internet.Musteriler)Session["Musteri"]).intSLSREF)) %>' /></div></td>
                            <%--<td style="width: 100px; text-align: right;"><span runat="server" visible='<%#Eval("[MUS KOD]") != "--------"%>'><%#Eval("[TEDNETTOP]") != DBNull.Value ? Convert.ToDecimal(Eval("[TEDNETTOP]")).ToString("C3") : 0.ToString("C3")%></span></td>--%>
                            <td style="width: 80px; text-align: center;"><%#Convert.ToInt32(Eval("[GMREF]")) != 0 ? Eval("[GMREF]").ToString() : ""%></td>
                            <td style="width: 300px; text-align: left;">
                            <div runat="server" visible='<%#Eval("[MUS KOD]") != "--------"%>'>
                            <asp:ImageButton runat="server" class="kucukbilgiGosterSade" ToolTip="İade ile ilgili kişiyi görmek için tıklayın" CommandArgument='<%#Eval("[SMREF]")%>' ImageUrl="img/iadeilgilivar.gif" AlternateText="İ" OnClick="ibIadeIlgili_Click" Visible='<%#Convert.ToBoolean(Eval("[SMREF]") != DBNull.Value) && Sultanlar.DatabaseObject.Internet.CariHesapEk.GetIadeIlgiliVarMiBySMREF(Convert.ToInt32(Eval("[SMREF]")))%>' />
                            <asp:ImageButton runat="server" class="kucukbilgiGosterSade" ToolTip="İade ile ilgili kişiyi görmek için tıklayın" CommandArgument='<%#Eval("[SMREF]")%>' ImageUrl="img/iadeilgiliyok.gif" AlternateText="İ" OnClick="ibIadeIlgili_Click" Visible='<%#Convert.ToBoolean(Eval("[SMREF]") != DBNull.Value) && !Sultanlar.DatabaseObject.Internet.CariHesapEk.GetIadeIlgiliVarMiBySMREF(Convert.ToInt32(Eval("[SMREF]")))%>' />
                            <span class="kucukbilgiGoster" title="<i>İlgili:</i> <%#Eval("ILGILI")%><br><i>Telefon:</i> <%#Eval("[TEL-1]")%><br><i>Cep Tel.:</i> <%#Eval("[CEP-1]")%><br><i>Eposta:</i> <%#Eval("[EMAIL-1]")%><br><br><%#Eval("ADRES").ToString()%><br><%#Eval("SEHIR")%>/<%#Eval("SEMT")%>"><%#Eval("[MUSTERI]")%></span>
                            
                            </div>
                            <div runat="server" visible='<%#Eval("[MUS KOD]") == "--------"%>'><%#Eval("[MUSTERI]")%></div></td>
<%--                            <td style="width: 100px; padding-left: 5px;">
                                <input type="hidden" value='<%#Eval("[GMREF]") %>' id="GMREFF" runat="server" />
                                <input type="hidden" value='<%#Eval("[SMREF]") %>' id="SMREFF" runat="server" />
                                <asp:LinkButton runat="server" ID="lbSatTemRutZiyaretBaslat" OnClick="ZiyaretBaslat_Click" Enabled='true' Visible='<%#Convert.ToBoolean(Eval("[SMREF]") != DBNull.Value && Eval("[MUS KOD]") != "--------")%>'>Ziyaret Başlat</asp:LinkButton>
                            </td>--%>
                            <td style="width: 80px;">
                            <div runat="server" visible='<%#Eval("[MUS KOD]") != "--------"%>'>
                            <%--<asp:ImageButton runat="server" class="kucukbilgiGosterSade" ToolTip="Konum bilgisini almak için tıklayın" CommandArgument='<%#Eval("[SMREF]")%>' ImageUrl="img/iadeilgilivar.gif" AlternateText="K" OnClick="ibKonum_Click" Visible='<%#Convert.ToBoolean(Eval("[SMREF]") != DBNull.Value) && Sultanlar.DatabaseObject.Internet.Rutlar.GetKonum(Convert.ToInt32(Eval("[SMREF]")), 1) != string.Empty %>' />--%>
                            <%--<asp:ImageButton runat="server" class="kucukbilgiGosterSade" ToolTip="Konum bilgisini almak için tıklayın" CommandArgument='<%#Eval("[SMREF]")%>' ImageUrl="img/iadeilgiliyok.gif" AlternateText="K" OnClick="ibKonum_Click" Visible='<%#Convert.ToBoolean(Eval("[SMREF]") != DBNull.Value) && Sultanlar.DatabaseObject.Internet.Rutlar.GetKonum(Convert.ToInt32(Eval("[SMREF]")), 1) == string.Empty %>' />--%>
                            <asp:HyperLink CssClass="kucukbilgiGosterSade" ToolTip="Konumu Göster" Target="_blank" runat="server" NavigateUrl='<%#GetKonum(Convert.ToInt32(Eval("[SMREF]") != DBNull.Value ? Eval("[SMREF]") : "0"), 1)%>' Visible='<%#Convert.ToBoolean(Eval("[SMREF]") != DBNull.Value) && Sultanlar.DatabaseObject.Internet.Rutlar.GetKonum(Convert.ToInt32(Eval("[SMREF]")), 1) != string.Empty %>' Text="(KG)"></asp:HyperLink>
                            <%--<asp:LinkButton CssClass="kucukbilgiGosterSade" ToolTip="Konumu Sil" Target="_blank" runat="server" OnClick="KonumSil_Click" CommandArgument='<%#Eval("[SMREF]").ToString() + "1"%>' Visible='<%#Convert.ToBoolean(Eval("[SMREF]") != DBNull.Value) && Sultanlar.DatabaseObject.Internet.Rutlar.GetKonum(Convert.ToInt32(Eval("[SMREF]")), 1) != string.Empty %>' Text="(KS)"></asp:LinkButton>--%>
                            </div>
                            </td>
                            <td style="width: 350px; padding-left: 5px; text-align: center;">
                                <input type="hidden" value='<%#Eval("[GMREF]") %>' id="GMREF" runat="server" />
                                <input type="hidden" value='<%#Eval("[SMREF]") %>' id="SMREF" runat="server" />
                                <input type="hidden" value='<%#Eval("[SMREF1]") %>' id="SMREF1" runat="server" />
                                <asp:LinkButton runat="server" OnClick="AnlasmaSul_Click" Visible='<%#Convert.ToBoolean(Eval("[MUS KOD]") != "--------") && (Convert.ToInt32(inputBayiGibi.Value) != 1 || Convert.ToBoolean(Eval("[SMREF]") == DBNull.Value))%>'>Anlaşma talep&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</asp:LinkButton>

                                <asp:LinkButton runat="server" OnClick="AktiviteSul_Click" Visible='<%#Convert.ToBoolean(Eval("[MUS KOD]") != "--------") && (Convert.ToInt32(inputBayiGibi.Value) != 1 || Convert.ToBoolean(Eval("[SMREF]") == DBNull.Value))%>'>Aktivite&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</asp:LinkButton>
                                
                                <asp:LinkButton runat="server" OnClick="SiparisVer_Click" Visible='<%#(Convert.ToInt32(inputBayiGibi.Value) == 1 && Convert.ToBoolean(Eval("[SMREF]") != DBNull.Value && Eval("[MUS KOD]") != "--------")) || (Convert.ToInt32(inputBayiGibi.Value) != 1 && Convert.ToBoolean(Eval("[SMREF]") != DBNull.Value) && Eval("[MUS KOD]") != "--------")%>'>Sipariş ver&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</asp:LinkButton><%--ID="lbSatTemSiparis"--%>
                                
                                <asp:LinkButton runat="server" OnClick="IadeVer_Click" Visible='<%#(Convert.ToInt32(inputBayiGibi.Value) == 1 && Convert.ToBoolean(Eval("[SMREF]") != DBNull.Value && Eval("[MUS KOD]") != "--------")) || (Convert.ToInt32(inputBayiGibi.Value) != 1 && Convert.ToBoolean(Eval("[SMREF]") != DBNull.Value) && Eval("[MUS KOD]") != "--------")%>'>İade talep&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</asp:LinkButton><%--ID="lbSatTemIade"--%>
                                
                                <asp:LinkButton runat="server" OnClick="SatTemSiparisVer_Click" Visible='<%#Convert.ToBoolean(Eval("[MUS KOD]") != "--------") && (Convert.ToInt32(inputBayiGibi.Value) == 1 || Convert.ToBoolean(Eval("[SMREF]") == DBNull.Value))%>'>Alt Cariler</asp:LinkButton><%--ID="lbSatTemRutSiparis"--%>
                            </td><%-- $('html,body').stop().animate({ scrollTop: '0' }, 1000); window.scrollTo(0,0);--%>
<%--                            <td style="width: 100px; padding-left: 5px;">
                                <input type="hidden" value='<%#Eval("[GMREF]") %>' id="GMREFFF" runat="server" />
                                <input type="hidden" value='<%#Eval("[SMREF]") %>' id="SMREFFF" runat="server" />
                                <asp:LinkButton runat="server" ID="lbSatTemRutZiyaretSonlandir" OnClick="ZiyaretSonlandir_Click" Enabled='false' Visible='<%#Convert.ToBoolean(Eval("[SMREF]") != DBNull.Value && Eval("[MUS KOD]") != "--------")%>'>Ziyaret Sonlandır</asp:LinkButton>
                            </td>--%>
                            
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate></table></FooterTemplate>
                </asp:DataList>
            </td>
        </tr>
    </table>
    <br />
    </div>
    </div>
    </ContentTemplate></asp:UpdatePanel>
    <asp:TextBox runat="server" ID="txtCoords1onceki" Text="0,0" style="visibility: hidden"></asp:TextBox>
    <asp:TextBox runat="server" ID="txtCoords1" Text="0,0" style="visibility: hidden"></asp:TextBox>
    <asp:TextBox runat="server" ID="txtCoords" Text="-Konum Alınamadı-" style="visibility: hidden"></asp:TextBox>
    <asp:TextBox runat="server" ID="txtCoordsFark" Text="0" style="visibility: hidden"></asp:TextBox>
<uc1:ucAlt ID="ucAlt1" runat="server" />
    <%--<script type="text/javascript" src="https://maps.googleapis.com/maps/api/js?key=AIzaSyD2oHmY5S1zlnnoEpOZMwEFougXqHys7B4&libraries=geometry"></script>--%>
    </form>
</body>
</html>

<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucAlt.ascx.cs" Inherits="Sultanlar.WebUI.musteri.ucAlt" %>
<asp:DropDownList ID="ddlTur" runat="server" Width="100px" AutoPostBack="true" Height="25px" ForeColor="#006699" 
OnSelectedIndexChanged="ddlTur_SelectedIndexChanged"
style="position: absolute; z-index: 1; left: 750px; top: 5px; padding: 3px 3px 3px 3px;border:1px solid #CCCCCC;background:#ededed;">
<asp:ListItem Text="Bayi Müş." Value="1"></asp:ListItem>
<asp:ListItem Text="Sap.Müş." Value="2" />
</asp:DropDownList>
<div style="background-color: #EFEEEA; height: 100px; padding: 10px; border-top: 1px solid #FFCFB2">
    <img src="img/logo.png" alt="" style="padding: 0 20px 0 10px; cursor: pointer" onclick="window.location.href='http://www.sultanlar.com.tr'" />
    <img src="img/ssl.gif" alt="" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <img src="img/logoSAP.png" alt="" style="padding-bottom: 7px" />
    <div style="margin-top: 5px; width: 100%; text-align: center; font-family: Tahoma;
        font-size: 12px; color: #808080">
        Copyright © 2011-2019 Sultanlar Pazarlama A.Ş. Tüm hakları saklıdır.
        <br />
        Sitede yer alan resim, yazı ve içerikler kaynak gösterilerek dahi olsa kopyalanamaz.
    </div>
    <script type="text/javascript" src="https://maps.googleapis.com/maps/api/js?key=AIzaSyDXm_Z4J-I9jrTO72lGvx1jRzTWsP6qi7Q&libraries=geometry"></script>
    <script type="text/javascript">

        $(document).ready(function () {
            var now = new Date();
            var ay = (now.getMonth() + 1).toString();
            ay = ay.length == 1 ? "0" + ay : ay;
            var gun = now.getDate().toString();
            gun = gun.length == 1 ? "0" + gun : gun;
            var saat = now.getHours().toString();
            saat = saat.length == 1 ? "0" + saat : saat;
            var dakika = now.getMinutes().toString();
            dakika = dakika.length == 1 ? "0" + dakika : dakika;
            var saniye = now.getSeconds().toString();
            saniye = saniye.length == 1 ? "0" + saniye : saniye;

            var tarih = (gun + "." + ay + "." + now.getFullYear() + " " + saat + ":" + dakika + ":" + saniye).toString();

            createCookie("sulSatTemLogD", tarih, 1); // new Date().toLocaleDateString() + " " + new Date().toLocaleTimeString()
            createCookie("sulSatTemLogS", window.location.href.substring(window.location.href.lastIndexOf("/") + 1, window.location.href.indexOf(".aspx")), 1);
            if (navigator.geolocation) {
                navigator.geolocation.getCurrentPosition(positionSuccess1, displayError1, { maximumAge: 60000, timeout: 30000, enableHighAccuracy: false });
            } else {
                //document.getElementById('ucAlt1_txtCoords1').value = '0,0';
                createCookie("sulSatTemLog1", '0,0', 1);
                //document.getElementById('ucAlt1_txtCoords').value = 'Tarayıcı konuma erişmeyi desteklemiyor.';
                createCookie("sulSatTemLog", 'Tarayıcı konuma erişmeyi desteklemiyor.', 1);
            }
        });

        function displayError1(positionError) {
            switch (positionError.code) {
                case positionError.PERMISSION_DENIED:
                    //document.getElementById('ucAlt1_txtCoords1').value = "0,0" //User denied the request for Geolocation.
                    createCookie("sulSatTemLog1", '0,0', 1);
                    //document.getElementById('ucAlt1_txtCoords').value = "-Konuma Erişilemedi-(1)" //User denied the request for Geolocation.
                    createCookie("sulSatTemLog", "-Konuma Erişilemedi-(1)", 1);
                    break;
                case positionError.POSITION_UNAVAILABLE:
                    //document.getElementById('ucAlt1_txtCoords1').value = "0,0" //Location information is unavailable.
                    createCookie("sulSatTemLog1", '0,0', 1);
                    //document.getElementById('ucAlt1_txtCoords').value = "-Konuma Erişilemedi-(2)" //Location information is unavailable.
                    createCookie("sulSatTemLog", "-Konuma Erişilemedi-(2)", 1);
                    break;
                case positionError.TIMEOUT:
                    //document.getElementById('ucAlt1_txtCoords1').value = "0,0" //The request to get user location timed out.
                    createCookie("sulSatTemLog1", '0,0', 1);
                    //document.getElementById('ucAlt1_txtCoords').value = "-Konuma Erişilemedi-(3)" //The request to get user location timed out.
                    createCookie("sulSatTemLog", "-Konuma Erişilemedi-(3)", 1);
                    break;
                case positionError.UNKNOWN_ERROR:
                    //document.getElementById('ucAlt1_txtCoords1').value = "0,0" //The request to get user location timed out.
                    createCookie("sulSatTemLog1", '0,0', 1);
                    //document.getElementById('ucAlt1_txtCoords').value = "-Konuma Erişilemedi-(3)" //The request to get user location timed out.
                    createCookie("sulSatTemLog", "-Konuma Erişilemedi-(3)", 1);
                    break;
            }
        }

        function positionSuccess1(position) {
            var coords = position.coords || position.coordinate || position;
            var latLng = new google.maps.LatLng(coords.latitude, coords.longitude);
            createCookie("sulSatTemLog1", coords.latitude.toFixed(6) + ',' + coords.longitude.toFixed(6), 1);
            createCookie("sulSatTemLog", "", 1);
            (new google.maps.Geocoder()).geocode({ latLng: latLng }, function (resp) {
                createCookie("sulSatTemLog", resp[0].formatted_address, 1);
            });
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
</div>
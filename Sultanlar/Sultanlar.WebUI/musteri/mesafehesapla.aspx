<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="mesafehesapla.aspx.cs" Inherits="Sultanlar.WebUI.musteri.mesafehesapla" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" src="js/jquery-1.2.6.pack.js"></script>
    <script type="text/javascript" src="js/jquery-1.8.3.js"></script>
    <script type="text/javascript">
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
</head>
<body onload="calcDistance()">
    <form id="form1" runat="server">
    <script type="text/javascript">
        function calcDistance() {
            alert(getParameterByName("bir"));
            alert(getParameterByName("iki"));
            var p11 = parseFloat(getParameterByName("bir").substring(0, getParameterByName("bir").indexOf(",")));
            var p12 = parseFloat(getParameterByName("bir").substring(getParameterByName("bir").indexOf(",") + 1));
            var p21 = parseFloat(getParameterByName("iki").substring(0, getParameterByName("iki").indexOf(",")));
            var p22 = parseFloat(getParameterByName("iki").substring(getParameterByName("iki").indexOf(",") + 1));
            var p1 = new google.maps.LatLng(p11, p12);
            var p2 = new google.maps.LatLng(p21, p22);
            alert((google.maps.geometry.spherical.computeDistanceBetween(p1, p2)).toFixed(2).toString());
            var mesafe = (google.maps.geometry.spherical.computeDistanceBetween(p1, p2)).toFixed(2).toString();
            window.open("mesafehesapla2.aspx?mesafe=" + mesafe);
        }
    </script>
    <input type="hidden" runat="server" id="inputMesafe" />
    <script type="text/javascript" src="https://maps.googleapis.com/maps/api/js?key=AIzaSyDXm_Z4J-I9jrTO72lGvx1jRzTWsP6qi7Q&libraries=geometry"></script>
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="konumoto.aspx.cs" Inherits="Sultanlar.WebUI.musteri.konumoto" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
    <script type="text/javascript" src="js/jquery-1.2.6.pack.js"></script>
    <script type="text/javascript" src="js/jquery-1.8.3.js"></script>
    <script type="text/javascript">

        function sleep(ms) {
            var start = new Date().getTime(), expire = start + ms;
            while (new Date().getTime() < expire) { }
            return;
        }

        var i = 0;
        function Basla() {
            var container = document.getElementById("tasiyici");
            var inputs = container.getElementsByTagName("input");
            //alert('tanimlamalar yapildi');
            var maks = inputs.length;
            var i5 = 0;
            //alert('i: ' + i.toString());
            while (i5 < 5 && i < maks) {
                var dizi = inputs[i].value.split(";;;");
                AdresGetir2(dizi[0], dizi[1], parseFloat(dizi[2].substring(0, dizi[2].indexOf(","))), parseFloat(dizi[2].substring(dizi[2].indexOf(",") + 1)));
                //alert(i.toString() + '. input. ' + dizi[0] + dizi[1] + dizi[2]);
                i++;
                i5++;
                document.getElementById("bitenler").innerHTML += dizi[1] + "-";
            }

            if (i == maks)
                document.getElementById("bitenler").innerHTML += "bitti";

            setTimeout(function () { Basla(); }, 10000);
        }

        function AdresGetir(tip, smref, adres) {
            var geocoder = new google.maps.Geocoder();
            if (geocoder) {
                geocoder.geocode({ 'address': adres.toString() }, function (results, status) {
                    if (status == google.maps.GeocoderStatus.OK) {
                        if (status != google.maps.GeocoderStatus.ZERO_RESULTS) {
                            window.open("konumoto2.aspx?smref=" + smref.toString() + "&tip=" + tip.toString() + "&lat=" + results[0].geometry.location.lat().toFixed(6) + "&lng=" + results[0].geometry.location.lng().toFixed(6));
                        } else {
                            //alert("Adres bulunamadı.");
                        }
                    }
                    else if (status == "OVER_QUERY_LIMIT") {
                        document.getElementById("bitenler2").innerHTML += "AŞTI-";
                    }
                    else {
                        document.getElementById("bitenler2").innerHTML += smref.toString() + " " + status + "-";
                    }
                });
            }
        }


        function AdresGetir2(tip, smref, lat, lng) {
            var latLng = new google.maps.LatLng(lat, lng);
            (new google.maps.Geocoder()).geocode({ latLng: latLng }, function (resp, status) {
                    if (status == google.maps.GeocoderStatus.OK) {
                        window.open("konumoto2.aspx?smref=" + smref.toString() + "&tip=" + tip.toString() + "&adres=" + resp[0].formatted_address);
                    }
                    else {
                        document.getElementById("bitenler2").innerHTML += smref.toString() + " " + status + "-";
                    }
            });
        }
        
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="tasiyici">
            <asp:Repeater runat="server" ID="repe">
                <ItemTemplate>
                    <input type="text" value='<%#Eval("TIP_KOD") + ";;;" + Eval("Kod") + ";;;" + Eval("Adres")%>' />
                </ItemTemplate>
            </asp:Repeater>
        </div>

        <input type="button" value="başla" onclick="Basla()" />
        <br /><br />
        <span id="bitenler"></span>
        <br /><br />
        <span id="bitenler2"></span>
            
        <script type="text/javascript" src="https://maps.googleapis.com/maps/api/js?key=AIzaSyDXm_Z4J-I9jrTO72lGvx1jRzTWsP6qi7Q"></script>

    </form>
</body>
</html>

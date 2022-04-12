
function KoordinatBaslat() {
    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(displayPosition, displayError, { maximumAge: 0, timeout: 30000, enableHighAccuracy: false });
    } else {
        document.getElementById('txtCoords1').value = '0,0';
        document.getElementById('txtCoords').value = 'Konuma erişim desteklenmiyor.';
    }
}

function displayPosition(position) {
    positionSuccess(position);
}

function displayError(positionError) {
    //alert('Konum bilginiz alınamadı. Telefonunuzun konum ayarının açık olduğundan emin olunuz.Açık olduğu halde konum alınamıyorsa telefonu yeniden başlatmayı deneyiniz.');
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

    if (document.getElementById('btnKonumKaydet')) {
        document.getElementById('btnKonumKaydet').style.display = 'none';
    }
}

function positionSuccess(position) {
    var coords = position.coords || position.coordinate || position;
    var latLng = new google.maps.LatLng(coords.latitude, coords.longitude);
    document.getElementById('txtCoords1').value = coords.latitude.toFixed(6) + ',' + coords.longitude.toFixed(6);
    document.getElementById('txtCoords').value = 'Aranıyor: ' +
            coords.latitude + ', ' + coords.longitude + '...';

    (new google.maps.Geocoder()).geocode({ latLng: latLng }, function (resp) {
        document.getElementById('txtCoords').value = resp[0].formatted_address;
        createCookie("EnSonKonum", resp[0].formatted_address, "1");
        KonumEkle(coords.latitude.toFixed(6) + ',' + coords.longitude.toFixed(6), resp[0].formatted_address);

        if (window.location.href.indexOf("konumal2.aspx") > -1) {
            SifirlaMarkers();
            //document.getElementById("inputAdresArama").value = document.getElementById("txtCoords").value;
            AdresGetir(document.getElementById("txtCoords").value);
        }
        else if (window.location.href.indexOf("ziyaret1.aspx") > -1) {
            document.getElementById('spanBekleniyor').style.display = 'none';
            document.getElementById('lbFarkliZiyaretBaslat').style.display = '';
        }
        else if (window.location.href.indexOf("ziyarethata.aspx") > -1) {
            document.getElementById('spanBekleniyor').style.display = 'none';
            document.getElementById('lbZiyaretSonlandirmaSebep').style.display = '';
        }
    });


    if (document.getElementById('iframeMap'))
        document.getElementById('iframeMap').innerHTML = "<iframe frameBorder='0' style='width: 100%; height: 200px' src='../musteri/map.aspx?lat=" + coords.latitude.toFixed(6) + "&lng=" + coords.longitude.toFixed(6) + "&title=Konum' />";

}

function KonumEkle(coord, yer) {
    if (readCookie("sdeSLSREF")) {
        if (readCookie("sdeSLSREF") != "0") {
            AndroidProgress(true);
            $.ajax(
                    {
                        type: 'POST',
                        url: 'menu.aspx/KonumEkle',
                        data: '{ slsref: "' + readCookie("sdeSLSREF") + '", coord: "' + coord + '", yer: "' + yer.split("'").join("").split("\"").join("") + '", sayfa: "mobil" }',
                        contentType: 'application/json; charset=utf-8',
                        dataType: 'json',
                        success: function (data) {

                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            alert(XMLHttpRequest.responseText);
                        }
                    });
            AndroidProgress(false);
        }
    }
}
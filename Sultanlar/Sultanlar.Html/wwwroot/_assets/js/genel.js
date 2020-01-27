
var girissayfasi = false;
var cikissayfasi = false;

$(document).ready(function () {
    if (!girissayfasi && !cikissayfasi)
        MesajSayisi();
});

function MesajSayisi() {
    $.ajax(
        {
            xhr: function () { return xhrDownloadUpload(); },
            beforeSend: function (xhr) { xhrTicket(xhr); },
            url: apiurl + "mesaj/GetMesajCount/" + window.localStorage["uyeid"],
            success: function (data, textStatus, response) {
                checkAuth2(response);

                $("#spanMesaj").html("Mesajlar (" + data + ")");
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) { console.log('hata'); }
        }
    );
}

function check(yap) {
    $.ajax(
        {
            xhr: function () { return xhrDownloadUpload(); },
            beforeSend: function (xhr) { xhrTicket(xhr); },
            url: apiurl + "genel/ticket/" + readCookie("sulLoginR"),
            success: function (data, textStatus, response) { // yanıt verme süresi 20-60 milisaniye
                if (yap)
                    checkAuth(response);
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) { console.log('hata'); }
        }
    );
}
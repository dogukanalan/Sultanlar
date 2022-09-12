
function getCari(tip, smref, callback, controlid) {
    $.ajax(
        {
            beforeSend: function (xhr) { xhrTicket(xhr); },
            url: apiurl + 'Cari/GetCari/' + tip + '/' + smref,
            success: function (data, textStatus, response) {
                callback(data, controlid);
            }
        });
}

function hataekle(yer, json) {
    $.ajax(
        {
            beforeSend: function (xhr) { xhrTicket(xhr); },
            url: apiurl + 'Genel/HataEkle/' + yer + '/' + json,
            success: function (data, textStatus, response) {
                console.log(data);
            }
        });
}

function getCariSube(data, controlid) {
    $("#" + controlid).val(data.sube);
    document.getElementById(controlid).innerHTML = data.sube;
}

function getCariMusteri(data, controlid) {
    $("#" + controlid).val(data.musteri);
    document.getElementById(controlid).innerHTML = data.musteri;
}

function getCariIl(data, controlid) {
    $("#" + controlid).val(data.il);
    document.getElementById(controlid).innerHTML = data.il;
}

function SaticilarGetir(tumudahil) {
    var uyeid = window.localStorage["uyeid"];
    $.ajax(
        {
            xhr: function () { return xhrDownloadUpload(); },
            beforeSend: function (xhr) { xhrTicket(xhr); },
            type: 'POST',
            url: apiurl + "satici" + (tumudahil ? "/true" : ""),
            data: '{ "uyeid": "' + uyeid + '" }',
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            success: function (data, textStatus, response) {
                checkAuth(response);

                $.each(data, function (index, item) {
                    $("#selectSaticilar").append(
                        $("<option></option>")
                            .text(item.sattem)
                            .val(item.slsmanref)
                    );
                });
                $("#selectSaticilar").val(window.localStorage["slsref"]);

                CarilerGetir();
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) { console.log('hata'); }
        }
    );
}

function siparisdbGetir(siparisid) {
    $.ajax(
        {
            xhr: function () { return xhrDownloadUpload(); },
            beforeSend: function (xhr) { xhrTicket(xhr); },
            url: apiurl + "siparis/get/" + siparisid,
            success: function (data, textStatus, response) {
                checkAuth(response);

                if (data.blAktarilmis) {
                    alert("Sipariş onaylı. Onaylı sipariş düzenlenemez.");
                    window.location.href = 'Siparisler';
                    return;
                }

                siparisdbSenkRoot(data, data.smref, data.pkSiparisID.toString(), data.sintFiyatTipiID.toString(), data.tksref.toString());
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) { console.log('hata'); }
        }
    );
}

function sipariskaydet(paramsmref, paramftip, parammtip, siparisid, paramonay, yonlendir) {
    var arrayFromCookie = JSON.parse(window.localStorage['sepet']);

    var yenisiparis = 0;
    $.ajax(
        {
            xhr: function () { return xhrDownloadUpload(); },
            beforeSend: function (xhr) { xhrTicket(xhr); },
            type: 'POST',
            url: apiurl + "siparis/kaydet",
            data: stringifySepet(arrayFromCookie, paramsmref, paramftip, parammtip, siparisid),
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            success: function (data, textStatus, response) {
                checkAuth(response);

                sipSil(arrayFromCookie);
                yenisiparis = data;
                if (paramonay == 1) {
                    window.location.href = 'Onayla?siparisid=' + data;
                }
                else {
                    if (yonlendir) {
                        document.getElementById("sipNo").innerHTML = "Sipariş kaydedildi.<br><br>Sipariş no: " + yenisiparis;
                    }
                }
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) { console.log('hata'); }
        }
    ).then(() => {
        console.log(yenisiparis);
        if (paramonay != 1 && !yonlendir) { // siparis kaydet devamet
            siparissil(siparisid, false);
            siparisdbGetir(yenisiparis);
        }
    });
}

function siparissil(siparisid, yonlendir) {
    $.ajax(
        {
            xhr: function () { return xhrDownloadUpload(); },
            beforeSend: function (xhr) { xhrTicket(xhr); },
            url: apiurl + "siparis/sil/" + siparisid,
            success: function (data, textStatus, response) {
                checkAuth(response);
                if (data == "") {
                    if (yonlendir) {
                        window.location.href = 'Siparisler';
                    }
                }
                else {
                    alert(data);
                }
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) { console.log('hata'); }
        }
    );
}
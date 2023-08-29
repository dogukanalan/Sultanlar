
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

    if (document.getElementById("divCariAcikGunler")) {
        $.each(data.acik.gunler, function (index, item) {
            document.getElementById("divCariAcikGunler").innerHTML = item.gunack.aciklama + ' ' + item.gunack.haftaningunu + ' (' + item.baslangic.substring(0, 10) + ' : ' + item.bitis.substring(0, 10) + ')<br>';
        });
    }

    if (document.getElementById("divCariAcikYetkililer")) {
        $.each(data.acik.yetkililer, function (index, item) {
            document.getElementById("divCariAcikYetkililer").innerHTML = item.isim + ' ' + item.soyisim + ' (' + item.turack.aciklama + ': ' + item.unvan + ') (' + item.cep + ' ' + item.eposta + ')<br>';
        });
    }
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
                    if (yenisiparis == "hata") {
                        alert("Bir hata oluştu, sipariş kaydedilemedi.");
                        return;
                    }

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

function UyeYetkileri(uyeid) {
    $.ajax(
        {
            xhr: function () { return xhrDownloadUpload(); },
            beforeSend: function (xhr) { xhrTicket(xhr); },
            url: apiurl + "uyeyetki/" + uyeid,
            success: function (data, textStatus, response) {
                checkAuth(response);

                var rootData = Object.keys(data.fiyatTipleri).length == 0 ? data.grupFiyatTipleri : data.fiyatTipleri;
                $.each(rootData, function (index, item) {

                    if (paramftip < 500) {
                        $("#fiyattipleri").append(
                            $("<option></option>")
                                .text(item.fiyatTipi.aciklama)
                                .val(item.sintFiyatTipiID)
                        );
                    }
                    else {
                        if (paramftip == item.sintFiyatTipiID) {
                            $("#fiyattipleri").append(
                                $("<option></option>")
                                    .text(item.fiyatTipi.aciklama)
                                    .val(item.sintFiyatTipiID)
                            );
                        }
                    }
                });

                $.ajax(
                    {
                        xhr: function () { return xhrDownloadUpload(); },
                        beforeSend: function (xhr) { xhrTicket(xhr); },
                        url: apiurl + "fiyat/getfiyattipler500birlikte",
                        async: false,
                        success: function (data2, textStatus, response) {
                            $.each(data2, function (i, item2) {
                                $("#fiyattipleri").append(
                                    $("<option></option>")
                                        .text(item2.aciklama)
                                        .val(item2.nosu)
                                );
                            });
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) { console.log('hata'); }
                    });
                $('select[id=fiyattipleri]').val(paramftip);
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) { console.log('hata'); }
        }
    );
}

function getSonFaturaTarih(gmref, tip, smref, controlid) {
    $.ajax(
        {
            beforeSend: function (xhr) { xhrTicket(xhr); },
            url: apiurl + 'satisraporu/sonalim/' + gmref + '/' +  + tip + '/' + smref,
            success: function (data, textStatus, response) {
                document.getElementById(controlid).innerHTML = data.substring(0, 10);
            }
        });
}

function getSonFaturaTarihDetay(gmref, tip, smref, itemref, controlid) {
    $.ajax(
        {
            xhr: function () { return xhrDownloadUpload2(); },
            beforeSend: function (xhr) { xhrTicket(xhr); },
            url: apiurl + 'satisraporu/sonalimdetay/' + gmref + '/' + + tip + '/' + smref + '/' + itemref,
            success: function (data, textStatus, response) {
                if (document.getElementById(controlid)) {
                    console.log(data);
                    document.getElementById(controlid).innerHTML = data.substring(0, 10);
                }
            }
        });
}

function getBase64Image(url) {
    if (url == undefined)
        return "iVBORw0KGgoAAAANSUhEUgAAAGQAAABkCAYAAABw4pVUAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAA+SURBVHhe7cExAQAAAMKg9U9tCy8gAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAADgqAacpAAB5eVcggAAAABJRU5ErkJggg==";

    var request = new XMLHttpRequest();

    var url1 = url.indexOf("getTObase64") == -1 ? url.replace("getTO", "getTObase64") : url;

    request.open('GET', url1, false);
    request.send(null);

    if (request.status === 200) {
        return request.responseText.trim();
    }
}
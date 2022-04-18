
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
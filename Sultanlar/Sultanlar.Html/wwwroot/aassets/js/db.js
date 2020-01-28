
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
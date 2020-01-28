
function baslangic() {
    add_header('Sultanlar', 'Müşteriler');
    add_footer();



    // {{{{{{{{{{{{{{{{{{

    window.onclick = function (event) {
        if (!event.target.matches('.dropbtn')) {
            var dropdowns = document.getElementsByClassName("subMenu");
            var i;
            for (i = 0; i < dropdowns.length; i++) {
                var openDropdown = dropdowns[i];
                if (openDropdown.classList.contains('show')) {
                    openDropdown.classList.remove('show');
                }
            }
        }
    };
    initDt(1, true, true, true);
    SaticilarGetir(window.localStorage["uyeid"]);
    $('#selectSaticilar').on('change', function (e) {
        MusterilerGetir(this.value);
    });

    // }}}}}}}}}}}}}}}}}}


    
}

function SaticilarGetir(uyeid) {
    $.ajax(
        {
            xhr: function () { return xhrDownloadUpload(); },
            beforeSend: function (xhr) { xhrTicket(xhr); },
            type: 'POST',
            url: apiurl + "satici",
            data: '{ "uyeid": "' + uyeid + '" }',
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            success: function (data, textStatus, response) {
                checkAuth(response);

                $("#selectSaticilar option").remove();
                $.each(data, function (index, item) {
                    $("#selectSaticilar").append(
                        $("<option></option>")
                            .text(item.sattem)
                            .val(item.slsmanref)
                    );
                });
                MusterilerGetir($('select[name=selectSaticilar]').val());
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) { console.log('hata'); }
        }
    );
}

function MusterilerGetir(slsref) {
    $.ajax(
        {
            xhr: function () { return xhrDownloadUpload(); },
            beforeSend: function (xhr) { xhrTicket(xhr); },
            url: apiurl + "cari/getana/" + slsref,
            success: function (data, textStatus, response) {
                checkAuth(response);

                var htmlText = '<table id="dtTable" class="table table-striped table-bordered" style="width:100%"><thead><tr><th class="keyTd hidewhenmobile">Kod</th><th class="keyTd">Müşteri</th><th></th></tr></thead><tbody>';
                $.each(data, function (i, item) {
                    htmlText += '<tr>';
                    htmlText += '<td class="keyTd hidewhenmobile"><span class="sinirli">' + data[i].gmref + '</span></td>';
                    htmlText += '<td class="valueTd"><span class="sinirli3">' + data[i].musteri + '</span></td>';
                    htmlText += '<td class="keyTd"><a href="javascript:showSubMenu(div' + data[i].gmref + ')" class="btn btn-primary">İşlemler</a><div class="subMenu" id="div' + data[i].gmref + '">' +
                        '<a href="Musteri/Musteri?gmref=' + data[i].gmref + '&slsref=' + slsref + '">Alt Cariler</a>' +
                        (data[i].mtkod != "Z1" ? '<a href="Anlasma/?smref=' + data[i].gmref + '&tip=' + data[i].tip + '">Anlaşma</a>' : "") +
                        '<a href="Aktivite/?smref=' + data[i].gmref + '&ftip=' + (data[i].mtkod == "Z1" ? "25" : "7") + '&tip=' + (data[i].mtkod == "Z1" ? "1" : "2") + '&aktiviteid=0">Aktivite</a>' +
                        '<a href="Ziyaret/?smref=' + data[i].gmref + '&gmref=' + data[i].gmref + '&slsref=' + slsref + '&tip=' + data[i].tip + '">Ziyaret</a>' +
                        '<a href="Siparis/?smref=' + data[i].gmref + '">Sipariş</a>' +
                        '<a href="Iade/?smref=' + data[i].gmref + '">İade</a></div>';
                    htmlText += '</td></tr>';
                });
                divData.innerHTML = htmlText + '</table>';
                initDt(1, true, true, true);
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) { console.log('hata'); }
        }
    );
}
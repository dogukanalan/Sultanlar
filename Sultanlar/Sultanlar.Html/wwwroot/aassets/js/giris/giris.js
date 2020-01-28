
girissayfasi = true;

function baslangic() {
    //jsload("genel", "db", "lazyload");
    //cssload("bootstrap", "site", "main");

    add_header('Sultanlar', 'Üye Girişi');
    add_footer();



    // {{{{{{{{{{{{{{{{{{

    $('#divProgress').css('display', 'none');
    $(".wrap").css("width", 560);

    $('.validate-form .input100').each(function () {
        $(this).focus(function () {
            hideValidate(this);
        });
    });

    var showPass = 0;
    $('.btn-show-pass').on('click', function () {
        if (showPass === 0) {
            $(this).next('input').attr('type', 'text');
            $(this).find('i').removeClass('fa-eye');
            $(this).find('i').addClass('fa-eye-slash');
            showPass = 1;
        }
        else {
            $(this).next('input').attr('type', 'password');
            $(this).find('i').removeClass('fa-eye-slash');
            $(this).find('i').addClass('fa-eye');
            showPass = 0;
        }
    });

    // }}}}}}}}}}}}}}}}}}



}

function GirisYap() {
    var input = $('.validate-input .input100');
    for (var i = 0; i < input.length; i++) {
        if (validate(input[i]) == false) {
            showValidate(input[i]);
            return;
        }
    }

    $('#divProgress').css("display", "block");
    $("#girisBasarisiz").css("visibility", "hidden");

    $.ajax(
        {
            xhr: function () { return xhrDownloadUpload(); },
            type: 'POST',
            url: apiurl + "giris",
            data: '{ "strEposta": "' + $('#email').val() + '", "strSifre": "' + $('#pass').val() + '", "blBirGun": "' + ($('#ckb1').is(':checked') ? "true" : "false") + '" }',
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            success: function (data) {
                if (!data.pkID) {
                    $("#girisBasarisiz").css("visibility", "visible");
                    return;
                }
                window.localStorage["eposta"] = $('#email').val();
                window.localStorage["uyeid"] = data.pkID;
                window.localStorage["uyetipiid"] = data.intUyeTipiID;
                window.localStorage["slsref"] = data.intSLSREF;
                window.localStorage["gmref"] = data.intGMREF;
                window.localStorage["token"] = data.token;
                createCookie("sulLogin", data.tokenCr, 1);
                createCookie("sulLoginR", $('#ckb1').is(':checked') ? "true" : "false", 1);
                var bas = window.location.href.indexOf("site") > -1 ? window.location.href.substring(0, window.location.href.indexOf("/")) + "/site" : window.location.href.substring(0, window.location.href.indexOf("/"));
                window.location.href = bas + "/" + (getParameterByName("returnurl") ? getParameterByName("returnurl") : "Musteri");
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) { alert(errorThrown); }
        }
    );
}
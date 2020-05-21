
(function ($) {
    "use strict";


    /*==================================================================
    [ Focus input ]*/
    $('.input100').each(function () {
        $(this).on('blur', function () {
            if ($(this).val().trim() != "") {
                $(this).addClass('has-val');
            }
            else {
                $(this).removeClass('has-val');
            }
        })
    })
    $('.ta100').each(function () {
        $(this).on('blur', function () {
            if ($(this).val().trim() != "") {
                $(this).addClass('has-val');
            }
            else {
                $(this).removeClass('has-val');
            }
        })
    })

    // ilk açýlýþta eðer içinde veri varsa yukarý çýkartsýn
    $('.input100').each(function () {
        if ($(this).val().trim() != "") {
            $(this).addClass('has-val');
        }
        else {
            $(this).removeClass('has-val');
        }
    });

    /*==================================================================
    [ Validate ]*/
    var input = $('.validate-input .input100');

    $('.validate-form').on('submit', function () {
        var check = true;

        for (var i = 0; i < input.length; i++) {
            if (validate(input[i]) == false) {
                showValidate(input[i]);
                check = false;
            }
        }

        if (check) {
            if (window.location.href.indexOf('uyeol.aspx') > 0) {
                /*AndroidProgress(true);
                $.ajax(
                    {
                        type: 'POST',
                        url: 'uyeol.aspx/UyeOl',
                        data: '{ isim: "' + $('#isim').val() + '", soyisim: "' + $('#soyisim').val() + '", email: "' + $('#email').val() + '", sifre: "' + $('#pass1').val() + '", dogum: "' + $('#dogum').val() + '" }',
                        contentType: 'application/json; charset=utf-8',
                        dataType: 'json',
                        success: function (data) {
                            AndroidProgress(false);
                            if (data.d == "dogumhata")
								AndroidToast("Dogum tarihini hatali girdiniz.");
                            else
							{
								AndroidToast("Uyelik basarili, giris ekranina yonlendiriliyorsunuz.");
								document.location.href = 'uyelik.aspx?eposta=' + $('#email').val() + '&sifre=' + data.d;
							}
                        },
                        error: function (data) {
                            AndroidProgress(false);
							if (data.readyState == 0 && data.status == 0)
							{
								//AndroidToast("Uyelik basarili, giris ekranina yonlendiriliyorsunuz.");
								//history.go(-1);
								//setTimeout(function(){document.location.href = 'giris.aspx';},2500);
								//AndroidToast("giris ekrani");
							}
							else {
								AndroidToast("hata olustu: " + JSON.stringify(data));
							}
                        }
                    });*/
            }
            else if (window.location.href.indexOf('uyelik.aspx') > 0) {
                AndroidProgress(true);
                $.ajax(
                    {
                        type: 'POST',
                        url: 'uyelik.aspx/UyeGuncelle',
                        data: '{ id: "' + $('#uyeid').val() + '", isim: "' + $('#isim').val() + '", soyisim: "' + $('#soyisim').val() + '", dogum: "' + $('#dogum').val() + '", sifre: "' + $('#pass1').val() + '" }',
                        contentType: 'application/json; charset=utf-8',
                        dataType: 'json',
                        success: function (data) {
                            AndroidToast('Uyelik bilgileri guncellendi.');
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            AndroidToast(XMLHttpRequest.responseText);
                        }
                    });
                AndroidProgress(false);
            }
            /*else if (window.location.href.indexOf('giris.aspx') > 0) {
                AndroidProgress(true);
                $.ajax(
                    {
                        type: 'POST',
                        url: 'giris.aspx/Giris',
                        data: '{ email: "' + $('#email').val() + '", sifre: "' + $('#pass1').val() + '" }',
                        contentType: 'application/json; charset=utf-8',
                        dataType: 'json',
                        success: function (data) {
                            AndroidProgress(false);
                            if (parseInt(data.d[0]) > 0)
                                window.location.href = 'panel.aspx?eposta=' + $('#email').val() + '&sifre=' + data.d[1].replace("+", "%2B").replace("&", "%41");
                            else
                                window.location.href = 'giris.aspx?hata=hata';
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            AndroidProgress(false);
                            alert(XMLHttpRequest.responseText);
                        }
                    });
            }*/
            /*else if (window.location.href.indexOf('tarif.aspx') > 0) {
                AndroidProgress(true);
                $.ajax(
                    {
                        type: 'POST',
                        url: 'tarif.aspx/YorumEkle',
                        data: '{ uyeid: "' + $('#uyeid').val() + '", tarifid: "' + $('#tarifid').val() + '", yorum: "' + $('#yorumTa').val() + '" }',
                        contentType: 'application/json; charset=utf-8',
                        dataType: 'json',
                        success: function (data) {
                            AndroidProgress(false);
                            window.location.href = 'yorum.aspx';
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            AndroidProgress(false);
                            alert(XMLHttpRequest.responseText);
                        }
                    });
            }*/
            /*else if (window.location.href.indexOf('tarifekle.aspx') > 0) {
                if (!resimyuklendi) {
                    alert('Resim yüklemediniz.');
                    return;
                }
                AndroidProgress(true);
                var Pic = canvas.toDataURL('image/jpeg', 0.85);
                Pic = Pic.replace(/^data:image\/(png|jpeg);base64,/, "");
                $.ajax(
                    {
                        type: 'POST',
                        url: 'tarifekle.aspx/TarifEkle',
                        data: '{ "imageData" : "' + Pic + '", uyeid: "' + $('#uyeid').val() + '", baslik: "' + $('#baslik').val() + '", malzemeler: "' + $('#malzemelerTa').val() + '", hazirlanis: "' + $('#hazirlanisTa').val() + '" }',
                        contentType: 'application/json; charset=utf-8',
                        dataType: 'json',
                        success: function (data) {
                            AndroidProgress(false);
                            alert('Tarif eklendi.');
                            window.location.href = 'tarif.aspx?id=' + data.d;
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            AndroidProgress(false);
                            alert(XMLHttpRequest.responseText);
                        }
                    });
            }*/
        }

        return check;
    });


    $('.validate-form .input100').each(function () {
        $(this).focus(function () {
            hideValidate(this);
        });
    });

    function validate(input) {
        if ($(input).attr('type') == 'email' || $(input).attr('name') == 'email') {
            if ($(input).val().trim().match(/^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{1,5}|[0-9]{1,3})(\]?)$/) == null) {
                return false;
            }
        }
        else if ($(input).attr('type') == 'pass' || $(input).attr('type') == 'password') {
            var val1 = document.getElementById('pass1');
            var val2 = document.getElementById('pass2');
            if (val2) {
                if (val1.value == val2.value) {
                    //val1.parent().removeClass('alert-validate');
                    //val2.parent().removeClass('alert-validate');
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        else {
            if ($(input).val().trim() == '') {
                return false;
            }
        }
    }

    function showValidate(input) {
        var thisAlert = $(input).parent();

        $(thisAlert).addClass('alert-validate');
    }

    function hideValidate(input) {
        var thisAlert = $(input).parent();

        $(thisAlert).removeClass('alert-validate');
    }

    /*==================================================================
    [ Show pass ]*/
    var showPass = 0;
    $('.btn-show-pass').on('click', function () {
        if (showPass == 0) {
            $(this).next('input').attr('type', 'text');
            $(this).find('i').removeClass('fa-eye');
            $(this).find('i').addClass('fa-eye-slash');
            showPass = 1;
        }
        else {
            $(this).next('input').attr('type', 'password');
            $(this).find('i').addClass('fa-eye');
            $(this).find('i').removeClass('fa-eye-slash');
            showPass = 0;
        }

    });


})(jQuery);



function yazma(evt) {
    return false;
}



(function (factory) {
    if (typeof define === "function" && define.amd) {

        // AMD. Register as an anonymous module.
        define(["../widgets/datepicker"], factory);
    } else {

        // Browser globals
        factory(jQuery.datepicker);
    }
}(function (datepicker) {

    datepicker.regional.tr = {
        closeText: "kapat",
        prevText: "&#x3C;geri",
        nextText: "ileri&#x3e",
        currentText: "bugün",
        monthNames: ["Ocak", "Subat", "Mart", "Nisan", "Mayýs", "Haziran",
            "Temmuz", "Agustos", "Eylül", "Ekim", "Kasým", "Aralýk"],
        monthNamesShort: ["Oca", "Sub", "Mar", "Nis", "May", "Haz",
            "Tem", "Agu", "Eyl", "Eki", "Kas", "Ara"],
        dayNames: ["Pazar", "Pazartesi", "Salý", "Carþamba", "Perþembe", "Cuma", "Cumartesi"],
        dayNamesShort: ["Pz", "Pt", "Sa", "Ca", "Pe", "Cu", "Ct"],
        dayNamesMin: ["Pz", "Pt", "Sa", "Ca", "Pe", "Cu", "Ct"],
        weekHeader: "Hf",
        dateFormat: "dd.mm.yy",
        firstDay: 1,
        isRTL: false,
        showMonthAfterYear: false,
        yearSuffix: ""
    };
    datepicker.setDefaults(datepicker.regional.tr);

    return datepicker.regional.tr;

}));


function AndroidProgress(goster) {
    try {
        if (goster) {
            Android.showProgress();
            //window.location = "foobar://fizz?show_activity_indicator=true";
        }
        else {
            Android.hideProgress();
            //window.location = "foobar://fizz?show_activity_indicator=false";
        }
    } catch (e) {

    }
}

function AndroidToast(ileti) {
    try {
        Android.ShowToast(ileti);
    } catch (e) {
        var iframe = document.createElement("IFRAME");
        iframe.setAttribute("src", 'data:text/plain,');
        document.documentElement.appendChild(iframe);
        window.frames[0].window.alert(ileti);
        iframe.parentNode.removeChild(iframe);
        //alert(ileti);
    }
}


function getParameterByName(name, url) {
    if (!url) url = window.location.href;
    name = name.replace(/[\[\]]/g, "\\$&");
    var regex = new RegExp("[?&]" + name + "(=([^&#]*)|&|#|$)"),
        results = regex.exec(url);
    if (!results) return null;
    if (!results[2]) return '';
    return decodeURIComponent(results[2].replace(/\+/g, " "));
}

function preloadImages(srcs) {
    if (!preloadImages.cache) {
        preloadImages.cache = [];
    }
    var img;
    for (var i = 0; i < srcs.length; i++) {
        img = new Image();
        img.src = srcs[i];
        preloadImages.cache.push(img);
    }
}
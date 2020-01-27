var surum = '1.6.1';

$(document).ready(function () {
    $("#divProgress").hide(1);
    if ($.fn.tipTip) {
        $(".kucukbilgiGoster").tipTip({ activation: "hover" });
    }
});
function Goster() {
    //$("#divProgress").show(250);
}

function clickButton(e, buttonid) {
    var evt = e ? e : window.event;
    var bt = document.getElementById(buttonid);
    if (bt) {
        if (evt.keyCode == 13) {
            bt.click();
            return false;
        }
    }
}

    function yazma(evt) {
            return false;
        }


function createCookie(name, value, days) {
    var expires = "";
    if (days) {
        var date = new Date();
        date.setTime(date.getTime() + (days * 24 * 60 * 60 * 1000));
        expires = "; expires=" + date.toUTCString();
    }
    document.cookie = name + "=" + value + expires + "; path=/";
}

function readCookie(name) {
    var nameEQ = name + "=";
    var ca = document.cookie.split(';');
    for (var i = 0; i < ca.length; i++) {
        var c = ca[i];
        while (c.charAt(0) == ' ') c = c.substring(1, c.length);
        if (c.indexOf(nameEQ) == 0) return c.substring(nameEQ.length, c.length);
    }
    return null;
}

function eraseCookie(name) {
    createCookie(name, "", -1);
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

(function (factory) {
    if (jQuery.datepicker) {
        if (typeof define === "function" && define.amd) {

            // AMD. Register as an anonymous module.
            define(["../widgets/datepicker"], factory);
        } else {

            // Browser globals
            factory(jQuery.datepicker);
        }
    }
} (function (datepicker) {

    datepicker.regional.tr = {
        closeText: "kapat",
        prevText: "&#x3C;geri",
        nextText: "ileri&#x3e",
        currentText: "bugün",
        monthNames: ["Ocak", "Subat", "Mart", "Nisan", "Mayıs", "Haziran",
	"Temmuz", "Agustos", "Eylül", "Ekim", "Kasım", "Aralık"],
        monthNamesShort: ["Oca", "Sub", "Mar", "Nis", "May", "Haz",
	"Tem", "Agu", "Eyl", "Eki", "Kas", "Ara"],
        dayNames: ["Pazar", "Pazartesi", "Salı", "Carşamba", "Perşembe", "Cuma", "Cumartesi"],
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
            if ($('#spanYukleniyor'))
                $('#spanYukleniyor').css("display", "");
            Android.showProgress();
        }
        else {
            if ($('#spanYukleniyor'))
                $('#spanYukleniyor').css("display", "none");
            Android.hideProgress();
        }
    } catch (e) {
        console.log(e);
    }
}

function Konustur(url, parametre) {
    if (url.indexOf('?') > -1)
        if (getParameterByName("slsref")) {
            Android.konustur(url.split('?')[0] + '?slsref=' + getParameterByName("slsref"), parametre);
        }
        else {
            Android.konustur(url.split('?')[0], parametre);
        }
    else {
        Android.konustur(url, parametre);
    }
}

function AndroidToast(ileti) {
    try {
        Android.ShowToast(ileti);
    } catch (e) {
        alert(ileti);
    }
}

function GetDateNow() {
    var today = new Date();
    var dd = today.getDate();
    var mm = today.getMonth() + 1;
    var yyyy = today.getFullYear();

    if (dd < 10) {
        dd = '0' + dd;
    }

    if (mm < 10) {
        mm = '0' + mm;
    }

    return dd + '.' + mm + '.' + yyyy;
}
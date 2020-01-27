
function Satir(kontrol, uzerinde) {
    if (uzerinde) {
        var d = new Date();
        if (d.getHours() >= 0 && d.getHours() <= 6) {
            kontrol.style.cssText = "filter: alpha(opacity=80); -moz-opacity: .80; opacity: .80; background-color: #E5E5E5";
        }
        else if (d.getHours() > 6 && d.getHours() <= 12) {
            kontrol.style.cssText = "filter: alpha(opacity=80); -moz-opacity: .80; opacity: .80; background-color: #FFE4D3";
        }
        else if (d.getHours() > 12 && d.getHours() <= 18) {
            kontrol.style.cssText = "filter: alpha(opacity=80); -moz-opacity: .80; opacity: .80; background-color: #DDEFFF";
        }
        else if (d.getHours() > 18 && d.getHours() <= 23) {
            kontrol.style.cssText = "filter: alpha(opacity=80); -moz-opacity: .80; opacity: .80; background-color: #F2FFCC";
        }
        //kontrol.style.backgroundColor = "#D3F0FF";
    }
    else
        kontrol.style.cssText = "";
}

function mapStyle() {
    return '[{ "featureType": "landscape", "elementType": "geometry", "stylers": [{ "saturation": "-100"}] }, { "featureType": "poi", "elementType": "labels", "stylers": [{ "visibility": "on"}] }, { "featureType": "poi", "elementType": "labels.text.stroke", "stylers": [{ "visibility": "on"}] }, { "featureType": "road", "elementType": "labels.text", "stylers": [{ "color": "#545454"}] }, { "featureType": "road", "elementType": "labels.text.stroke", "stylers": [{ "visibility": "off"}] }, { "featureType": "road.highway", "elementType": "geometry.fill", "stylers": [{ "saturation": "-87" }, { "lightness": "-40" }, { "color": "#ffffff"}] }, { "featureType": "road.highway", "elementType": "geometry.stroke", "stylers": [{ "visibility": "off"}] }, { "featureType": "road.highway.controlled_access", "elementType": "geometry.fill", "stylers": [{ "color": "#f0f0f0" }, { "saturation": "-22" }, { "lightness": "-16"}] }, { "featureType": "road.highway.controlled_access", "elementType": "geometry.stroke", "stylers": [{ "visibility": "off"}] }, { "featureType": "road.highway.controlled_access", "elementType": "labels.icon", "stylers": [{ "visibility": "on"}] }, { "featureType": "road.arterial", "elementType": "geometry.stroke", "stylers": [{ "visibility": "off"}] }, { "featureType": "road.local", "elementType": "geometry.stroke", "stylers": [{ "visibility": "off"}] }, { "featureType": "transit", "elementType": "labels.icon", "stylers": [{ "visibility": "off"}] }, { "featureType": "water", "elementType": "geometry.fill", "stylers": [{ "saturation": "-52" }, { "hue": "#00e4ff" }, { "lightness": "-16"}]}]';
}

(function (factory) {
    if (typeof define === "function" && define.amd) {

        // AMD. Register as an anonymous module.
        define(["../widgets/datepicker"], factory);
    } else {

        // Browser globals
        factory(jQuery.datepicker);
    }
} (function (datepicker) {

    if (datepicker) {
        datepicker.regional.tr = {
            closeText: "kapat",
            prevText: "&#x3C;geri",
            nextText: "ileri&#x3e",
            currentText: "bugün",
            monthNames: ["Ocak", "Şubat", "Mart", "Nisan", "Mayıs", "Haziran",
                "Temmuz", "Ağustos", "Eylül", "Ekim", "Kasım", "Aralık"],
            monthNamesShort: ["Oca", "Şub", "Mar", "Nis", "May", "Haz",
                "Tem", "Ağu", "Eyl", "Eki", "Kas", "Ara"],
            dayNames: ["Pazar", "Pazartesi", "Salı", "Çarşamba", "Perşembe", "Cuma", "Cumartesi"],
            dayNamesShort: ["Pz", "Pt", "Sa", "Ça", "Pe", "Cu", "Ct"],
            dayNamesMin: ["Pz", "Pt", "Sa", "Ça", "Pe", "Cu", "Ct"],
            weekHeader: "Hf",
            dateFormat: "dd.mm.yy",
            firstDay: 1,
            isRTL: false,
            showMonthAfterYear: false,
            yearSuffix: ""
        };
        datepicker.setDefaults(datepicker.regional.tr);

        return datepicker.regional.tr;
    }

}));
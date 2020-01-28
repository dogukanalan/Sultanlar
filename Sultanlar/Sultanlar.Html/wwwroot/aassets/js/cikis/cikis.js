
cikissayfasi = true;

function baslangic() {
    add_header('Sultanlar', 'Çıkış');
    add_footer();



    // {{{{{{{{{{{{{{{{{{

    $('#divProgress').css("display", "none");
    CikisYap();

    // }}}}}}}}}}}}}}}}}}



}

function CikisYap() {
    window.localStorage.removeItem("eposta");
    window.localStorage.removeItem("sifre");
    window.localStorage.removeItem("uyeid");
    window.localStorage.removeItem("uyetipiid");
    window.localStorage.removeItem("slsref");
    window.localStorage.removeItem("gmref");
    window.localStorage.removeItem("token");
    window.localStorage["sepet"] = "[]";
    window.localStorage["sepetI"] = "[]";
    window.localStorage["sepetA"] = "[]";
    eraseCookie("sulLogin");
}
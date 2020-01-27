<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="hizlisiparis.aspx.cs" Inherits="Sultanlar.WebUI.musteri.hizlisiparis" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
	<meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Sultanlar : Hızlı Sipariş</title>
    
    <style type="text/css">
@font-face {
  font-family: 'Patua One';
  font-style: normal;
  font-weight: 400;
  src: local('Patua One'), local('PatuaOne-Regular'), url(hs/yAXhog6uK3bd3OwBILv_SD8E0i7KZn-EPnyo3HZu7kw.woff) format('woff');
}
@font-face {
  font-family: 'Titillium Web';
  font-style: normal;
  font-weight: 400;
  src: local('Titillium Web'), local('TitilliumWeb-Regular'), url(hs/7XUFZ5tgS-tD6QamInJTcYp67VRGBZnLJtqE-R4vad8.woff) format('woff');
}
@font-face {
  font-family: 'Titillium Web';
  font-style: normal;
  font-weight: 600;
  src: local('Titillium WebSemiBold'), local('TitilliumWeb-SemiBold'), url(hs/anMUvcNT0H1YN4FII8wpr01BFkczmy2u5hEk7x1peg4.woff) format('woff');
}
@font-face {
  font-family: 'Titillium Web';
  font-style: italic;
  font-weight: 400;
  src: local('Titillium WebItalic'), local('TitilliumWeb-Italic'), url(hs/r9OmwyQxrgzUAhaLET_KOzUd9nSPaIPDEKUjMzkuNks.woff) format('woff');
}
@font-face {
  font-family: 'Titillium Web';
  font-style: italic;
  font-weight: 700;
  src: local('Titillium WebBold Italic'), local('TitilliumWeb-BoldItalic'), url(hs/RZunN20OBmkvrU7sA4GPPn7AeccaDB5K039idtUe2Ic.woff) format('woff');
}
    </style>

    <script type="text/javascript">
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
                kontrol.style.cssText = "background-color: " + kontrol.lang;
        }
    </script>

    <script type="text/javascript">
        function clickButton(e, buttonid) {
            var evt = e ? e : window.event;
            var bt = document.getElementById(buttonid);
            if (bt) {
                if (evt.keyCode == 13) {
                    bt.click();
                    document.getElementById('btnAktar2').focus();
                    return false;
                }
            }
        }





        var urunidler = [];
        var urunler = [];
        var fiyatlar = [];
        var tedarikciler = [];

        var tedarikcilistesi = [];

        var siparisurunid = [];
        var siparisurun = [];
        var siparisurunmiktar = [];





        function SiparisiGoster() {
            document.getElementById('siparissepeti').style.visibility = 'visible';

            var sonuc = "<table><tr style='color: Blue; font-weight: bold;'><td style='width: 660px; text-align: center'>Malzeme</td><td style='width: 50px; text-align: center'>Adet</td><td style='width: 110px; text-align: center'>Birim Fiyat</td><td style='width: 120px; text-align: center'>Toplam Fiyat</td><td style='width: 60px; text-align: center'>İşlem</td></tr>";
            var toplamtutar = 0;
            for (var i = 0; i < siparisurunid.length; i++) {
                var tutar = parseFloat(siparisurunmiktar[i]) * parseFloat(fiyatlar[GetUrunSira(siparisurunid[i])].replace(",", "."));
                toplamtutar += tutar;
                sonuc += "<tr><td style='text-align: left; color: Black; font-size: 12px'>" + siparisurun[i].toString().replace("(", "<span style='color: Gray'>(").replace(")", ")</span>").replace("{", "<span style='color: Purple'>{").replace("}", "}</span>").replace("[", "<span style='color: Green'>[").replace("]", "]</span>") +
                "</td><td style='text-align: center; color: Orange; font-weight: bold'>" + siparisurunmiktar[i] + "</td>" +
                "</td><td style='text-align: right; color: Red; font-weight: bold'>" + fiyatlar[GetUrunSira(siparisurunid[i])] + " <span style='color: Gray'>TL</span></td>" +
                "</td><td style='text-align: right; color: Maroon; font-weight: bold'>" + tutar.toFixed(3).toString() + " <span style='color: Gray'>TL</span></td>" +
                "</td><td style='text-align: center'><input type='button' value='Sil' onclick='SiparistenSil(\"" + siparisurunid[i] + "\")' /></td></tr>";
            }
            sonuc += "<tr><td></td><td></td><td></td><td style='text-align: right; color: Maroon; font-weight: bold'>" + toplamtutar.toFixed(3).toString() + " <span style='color: Gray'>TL</span></td><td></td></tr></table>";
            siparisliste.innerHTML = sonuc;
            window.scrollTo(0, 0);
        }





        function SipariseAktar() {
            var elems = document.getElementsByTagName('input');
            for (var i = 0; i < elems.length; i++) {
                if (elems[i].type == "text" && elems[i].id != "ara" && elems[i].id != "inputAciklama1" && elems[i].id != "inputAciklama2") {
                    if (elems[i].value != "") {

                        var icerdevar = false;
                        //                        for (var i = 0; i < siparisurunid.length; i++) {
                        //                            if (siparisurunid[i] == elems[i].id) {
                        //                                icerdevar = true;
                        //                                siparisurunmiktar[i] = siparisurunmiktar[i] + elems[i].value;
                        //                            }
                        //                        }

                        if (!icerdevar) {
                            siparisurunid.push(urunidler[GetUrunSira(elems[i].id)]);
                            siparisurun.push(urunler[GetUrunSira(elems[i].id)]);
                            siparisurunmiktar.push(elems[i].value);

                            document.getElementById('siparisurunidler').value += urunidler[GetUrunSira(elems[i].id)] + ";";
                            document.getElementById('siparisurunmiktarlar').value += elems[i].value + ";";
                        }

                        elems[i].value = "";
                    }
                }
            }
            //alert("Aktarıldı.");
        }





        function SiparistenSil(urunid) {
            document.getElementById('siparissepeti').style.visibility = 'hidden';

            for (var i = 0; i < siparisurunid.length; i++) {
                if (siparisurunid[i] == urunid) {
                    siparisurunmiktar[i] = "0";
                }
            }

            var siparisurunid2 = [];
            var siparisurun2 = [];
            var siparisurunmiktar2 = [];
            for (var i = 0; i < siparisurunid.length; i++) {
                if (siparisurunmiktar[i] != "0") {
                    siparisurunid2.push(siparisurunid[i]);
                    siparisurun2.push(siparisurun[i]);
                    siparisurunmiktar2.push(siparisurunmiktar[i]);
                }
            }
            siparisurunid = siparisurunid2;
            siparisurun = siparisurun2;
            siparisurunmiktar = siparisurunmiktar2;

            document.getElementById('siparisurunidler').value = "";
            document.getElementById('siparisurunmiktarlar').value = "";
            for (var i = 0; i < siparisurunid.length; i++) {
                document.getElementById('siparisurunidler').value += siparisurunid[i] + ";";
                document.getElementById('siparisurunmiktarlar').value += siparisurunmiktar[i] + ";";
            }

            SiparisiGoster();
        }





        function SiparisiKapat() {
            document.getElementById('siparissepeti').style.visibility = 'hidden';
        }





        function GetUrunSira(id) {
            for (var i = 0; i < urunidler.length - 1; i++) { // son satır null
                if (urunidler[i] == id) {
                    return i;
                }
            }
        }





        function UrunAra() {
            if (urunidler.length == null || urunidler.length < 1) { // ilk seferde urunleri arraylara doldurmasi icin
                UrunlerTedarikciler();
            }

            var aranan = document.getElementById('ara').value;

            var urunid = 0;
            var urun = "";
            var sonuc = "<table><tr style='color: Blue; font-weight: bold;'><td style='width: 50px; text-align: center'>Adet</td><td style='width: 840px; text-align: center'>Malzeme</td><td style='width: 110px; text-align: center'>Birim Fiyat</td></tr>";
            var urunsayisi = 0;
            var oncekiurunilkuchane = '';
            for (var i = 0; i < urunler.length - 1; i++) { // son satır null
                if (urunler[i].indexOf(aranan.toUpperCase()) > -1) {

                    if (tedarikciler[i] != oncekiurunilkuchane) {
                        sonuc += "<tr style='background-color: #FFFFFF'>" +
                        "<td></td><td style='text-align: center; color: Black; font-style: italic'>" + tedarikciler[i] + "</td><td><span style='color: #FFFFFF'>-</span></td></tr>";
                    }

                    sonuc += "<tr onmouseover='Satir(this,true)' onmouseout='Satir(this,false)' lang='" + (i % 2 == 0 ? '#FFFAE5' : '#E5FFE8') + "' style='background-color: " + (i % 2 == 0 ? '#FFFAE5' : '#E5FFE8') + "'>" + 
                    "<td style='width: 50px; text-align: center'><input id='" + urunidler[i] + "' type='text' onkeydown='return clickButton(event,\"btnAktar\")' style='width: 25px; text-align: center' /></td>" + 
                    "<td style='text-align: left; color: Black'>" + urunler[i].toString().replace("(", "<span style='color: Gray'>(").replace(")", ")</span>").replace("{", "<span style='color: Purple'>{").replace("}", "}</span>").replace("[", "<span style='color: Green'>[").replace("]", "]</span>") +
                    "</td><td style='text-align: right; color: Red; font-weight: bold'>" + fiyatlar[i] + " <span style='color: Gray'>TL</span>" +
                    "</td></tr>";

                    oncekiurunilkuchane = tedarikciler[i].toString();
                    urunsayisi++;

                }
            }
            sonuc += "</table>";
            liste.innerHTML = sonuc;
            spanUrunSayisi.innerHTML = "(Bulunan ürün sayısı: " + urunsayisi.toString() + ")";
        }





        function Temizle() {
            document.getElementById('ara').value = '';
        }





        function UrunlerTedarikciler() {
            var database = document.getElementById('db').value;
            var satirlar = database.split(';');

            urunidler = [];
            urunler = [];
            fiyatlar = [];
            tedarikciler = [];
            for (var i = 0; i < satirlar.length; i++) {
                var satir = satirlar[i];
                var idurun = satir.split('!');
                urunidler.push(idurun[0]);
                urunler.push(idurun[1]);
                fiyatlar.push(idurun[2]);
                tedarikciler.push(idurun[3]);
            }

            var sonuc1 = "<table><tr style='color: Blue; font-weight: bold;'><td style='width: 840px; text-align: center'>Malzeme</td><td style='width: 110px; text-align: center'>Birim Fiyat</td><td style='width: 50px; text-align: center'>Adet</td></tr>";
            for (var i = 0; i < 25; i++) { // son satır null   urunler.length - 1
                sonuc1 += "<tr><td style='text-align: left; color: Black'>" + urunler[i].toString().replace("(", "<span style='color: Gray'>(").replace(")", ")</span>").replace("{", "<span style='color: Purple'>{").replace("}", "}</span>").replace("[", "<span style='color: Green'>[").replace("]", "]</span>") +
                    "</td><td style='text-align: right; color: Red; font-weight: bold'>" + fiyatlar[i] + " <span style='color: Gray'>TL</span>" +
                    "</td><td style='width: 50px; text-align: center'><input id='" + urunidler[i] + "' type='text' onkeydown='return clickButton(event,\"btnAktar\")' style='width: 25px; text-align: center' /></td></tr>";
            }
            sonuc1 += "</table>";
            liste.innerHTML = sonuc1;



            /*var teddatabase = document.getElementById('teddb').value;
            var satirlar1 = teddatabase.split(';');

            tedarikcilistesi = [];
            for (var i = 0; i < satirlar1.length; i++) {
            tedarikcilistesi.push(satirlar1[i]);
            }

            var sonuc = "<ul class='portfolio-menu'><li><a href='' class='current' data-filter='*'>Hepsi</a></li>";
            for (var i = 0; i < tedarikcilistesi.length - 1; i++) { // son satır null
            sonuc += "<li><a href='' data-filter='." + tedarikcilistesi[i] + "'>" + tedarikcilistesi[i] + "</a></li>";
            }
            sonuc += "</ul>";
            tedarikcilerliste.innerHTML = sonuc;*/
        }
    </script>        <script type="text/javascript" src="js/jquery-1.2.6.pack.js"></script>
    <script type="text/javascript" src="js/jquery-1.8.3.js"></script>
    <script type="text/javascript" src="js/jquery-ui.js"></script>
    <link rel="stylesheet" href="js/jquery-ui.css" />

</head>
<body style="font-family: 'Titillium Web', 'Open Sans', Tahoma; font-size: 12px">
    <form id="form1" runat="server">
    <div class="wrapper">
    <div class="portfolio-content">	 
    
        <table cellpadding="3" cellspacing="0" border="0">
            <tr>
                <td style="width: 150px; color: Blue">Sipariş Sahibi:</td>
                <td style="width: 650px; color: Gray"><span runat="server" id="spanUye"></span></td>
                <td style="width: 150px; color: Blue; text-align: center">Açıklama ve Tsl.Tarihi</td>
            </tr>
            <tr>
                <td style="color: Blue">Müşteri:</td>
                <td style="color: Gray"><span runat="server" id="spanMusteri"></span></td>
                <td><input type="text" runat="server" id="inputAciklama1" style="width: 150px" maxlength="40" /></td>
            </tr>
            <tr>
                <td style="color: Blue">Fiyat Tipi:</td>
                <td style="color: Gray"><span runat="server" id="spanFiyatTipi"></span></td>
                <td><input type="text" runat="server" id="inputAciklama2" style="width: 150px" maxlength="40" /></td>
            </tr>
        </table>
        <br />

        <input type="hidden" runat="server" id="inputButunUrunler" />
        <input type="hidden" runat="server" id="db" />
        <input type="hidden" runat="server" id="teddb" />
        <input type="text" id="ara" style="width: 300px" onkeydown="return clickButton(event,'btnAra')" placeholder="Ürün ismi, ürün kodu ya da barkod arayın" />
        <input type="button" id="btnAra" value="Ara" onclick="UrunAra()" />
        <input type="button" id="btnTemizle" value="Temizle" onclick="Temizle()" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <span id="spanUrunSayisi" style="color: Red"></span>
        <br /><br />

        <input type="button" id="btnAktar2" value="Seçimleri Siparişe Aktar" onclick="SipariseAktar()" style="color: Orange; font-weight: bold" />
        <input type="button" value="Siparişi Göster" onclick="SiparisiGoster()" style="color: Black; font-weight: bold" />

        <br />

        <div id="tedarikcilerliste"></div>
        
        <div id="liste"></div>

        <br />
        <input type="button" id="btnAktar" value="Seçimleri Siparişe Aktar" onclick="SipariseAktar()" style="color: Orange; font-weight: bold" />
        <input type="button" value="Siparişi Göster" onclick="SiparisiGoster()" style="color: Black; font-weight: bold" />
        <br /><br />
        
        <input type="hidden" runat="server" id="siparissahibimusteriid" />
        <input type="hidden" runat="server" id="fiyattipi" />
        <input type="hidden" runat="server" id="smref" />

        <input type="hidden" runat="server" id="siparisurunidler" />
        <input type="hidden" runat="server" id="siparisurunmiktarlar" />

        <div id="siparissepeti" style="visibility: hidden">
            <div style="filter: alpha(opacity=40); -moz-opacity: .40; opacity: .40;
                background-color: #000000; position: fixed; width: 100%; height: 100%; z-index: 9;
                left: 0; top: 0;" onclick="SiparisiKapat();">
            </div>
            <div style="padding-top: 5px; position: absolute; z-index: 10;
                left: 0; top: 0;">
                <table style="width: 980px; height: 300px; margin-left: 10px; background-color: #ffffff; border: 1px solid #D1D1D1; border-radius: 5px; padding: 5px;">
                    <tr>
                        <td style="text-align: center; border-bottom: 1px dotted #CCCCCC; height: 50px; font-size: 18px; font-family: Gisha">
                            <input type="button" value="Siparişe Geri Dön" onclick="SiparisiKapat()" style="color: Black; font-weight: bold" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button runat="server" ID="btnSiparisTamamla" Text="Siparişi Tamamla" style="color: Red; font-weight: bold"
                                onclick="btnSiparisTamamla_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: center; height: 100%; vertical-align: top">
                            <%--<div style="height: 300px; overflow: auto">
                            </div>--%>
                            <span id="siparisliste"></span>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
    </div>
    <script type="text/javascript">
        UrunlerTedarikciler();
        UrunAra();
        $("#inputAciklama2").datepicker({ changeMonth: true, changeYear: true, dateFormat: 'dd/mm/yy' });
    </script>
    </form>
</body>
</html>

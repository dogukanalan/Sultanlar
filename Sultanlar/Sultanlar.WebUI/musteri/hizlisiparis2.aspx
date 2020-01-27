<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="hizlisiparis2.aspx.cs" Inherits="Sultanlar.WebUI.musteri.hizlisiparis2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sultanlar : Hızlı Sipariş</title>
    <style type="text/css">
        * {
          -webkit-box-sizing: border-box;
             -moz-box-sizing: border-box;
                  box-sizing: border-box;
        }

        body {
          font-family: sans-serif;
        }

        /* ---- input ---- */

        input[type="text"] {
          font-size: 20px;
        }

        input[type="button"] {
          font-size: 20px;
        }

        /* ---- isotope ---- */

        .isotope {
          /*border: 1px solid #333;*/
        }

        /* clear fix */
        .isotope:after {
          content: '';
          display: block;
          clear: both;
        }

        /* ---- .element-item ---- */

        .element-item {
          position: relative;
          float: left;
          width: 100px;
          height: 100px;
          margin: 5px;
          padding: 10px;
          background: #888;
          color: #262524;
        }

        .element-item > * {
          margin: 0;
          padding: 0;
        }

        .element-item .name {
          position: absolute;

          left: 1px;
          top: 19px;
          text-transform: none;
          letter-spacing: 0;
          font-size: 10px;
          font-weight: normal;
          max-width: 98px;
          color: White;
        }

        .element-item .symbol {
          position: absolute;
          left: 1px;
          top: 1px;
          font-size: 10px;
          font-weight: bold;
          color: #CCCCCC;
        }

        .element-item .number {
          position: absolute;
          right: 1px;
          top: 1px;
        }

        .element-item .weight {
          position: absolute;
          left: 10px;
          top: 76px;
          font-size: 12px;
          font-weight: bold;
          color: #FFD8D8;
        }

        /*.element-item.transition      { background: #FF8800; }*/
    </style>
    <script type="text/javascript">
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





        var siparisurunid = [];
        var siparisurun = [];
        var siparisurunmiktar = [];





        function SiparisiGoster() {
            document.getElementById('siparissepeti').style.visibility = 'visible';

            var sonuc = "<table><tr><td style='width: 600px; text-align: center'><b><u>Malzeme</u></b></td><td style='width: 50px; text-align: left'><b><u>Adet</u></b></td><td style='width: 80px; text-align: center'><b><u>İşlem</u></b></td></tr>";
            for (var i = 0; i < siparisurunid.length; i++) {
                sonuc += "<tr><td style='text-align: left'>" + siparisurun[i] +
                "</td><td style='text-align: center'>" + siparisurunmiktar[i] + "</td>" +
                "</td><td style='text-align: center'><input type='button' value='Sil' onclick='SiparistenSil(\"" + siparisurunid[i] + "\")' /></td></tr>";
            }
            sonuc += "</table>";
            siparisliste.innerHTML = sonuc;
        }



        function SiparisiKapat() {
            document.getElementById('siparissepeti').style.visibility = 'hidden';
        }





        function SipariseAktar() {
            var elems = document.getElementsByTagName('input');
            for (var i = 0; i < elems.length; i++) {
                if (elems[i].type == "text" && elems[i].id != "quicksearch") {
                    if (elems[i].value != "") {

                        var icerdevar = false;
                        //                        for (var i = 0; i < siparisurunid.length; i++) {
                        //                            if (siparisurunid[i] == elems[i].id) {
                        //                                icerdevar = true;
                        //                                siparisurunmiktar[i] = siparisurunmiktar[i] + elems[i].value;
                        //                            }
                        //                        }

                        if (!icerdevar) {
                            siparisurunid.push(elems[i].id);
                            siparisurun.push(elems[i].title);
                            siparisurunmiktar.push(elems[i].value);

                            document.getElementById('siparisurunidler').value += elems[i].id + ";";
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
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <p><input type="text" id="quicksearch" placeholder="Arama" onkeydown="return clickButton(event,'quickbutton')" /><input type="button" id="quickbutton" value="Ara" onclick="document.getElementById('isoisoiso').style.display = 'inherit'" /></p>
    <input type="button" id="btnAktar" value="Siparişe Aktar" onclick="SipariseAktar()" />
    <input type="button" value="Siparişi Göster" onclick="SiparisiGoster()" />

    <%= GetUrunler() %>

    <input type="hidden" runat="server" id="siparissahibimusteriid" />
    <input type="hidden" runat="server" id="fiyattipi" />
    <input type="hidden" runat="server" id="smref" />
    <input type="hidden" runat="server" id="siparisurunidler" />
    <input type="hidden" runat="server" id="siparisurunmiktarlar" />
    <br />
    <asp:Button runat="server" ID="btnSiparisTamamla" Text="Siparişi Tamamla" onclick="btnSiparisTamamla_Click" />

    <div id="siparissepeti" style="visibility: hidden">
        <div style="padding-top: 300px; filter: alpha(opacity=40); -moz-opacity: .40; opacity: .40;
            background-color: #000000; position: fixed; width: 100%; height: 100%; z-index: 9;
            left: 0; top: 0;">
        </div>
        <div style="padding-top: 5px; position: fixed; width: 100%; height: 100%; z-index: 10;
            left: 0; top: 0;">
            <table style="width: 900px; margin-left: 10px; background-color: #ffffff; border: 1px solid #D1D1D1; border-radius: 5px; padding: 5px;">
                <tr>
                    <td style="text-align: center; border-bottom: 1px dotted #CCCCCC; height: 50px; font-size: 18px; font-family: Gisha">
                        <input type="button" value="Siparişe Geri Dön" onclick="SiparisiKapat()" />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center; height: 100%; vertical-align: top">
                        <span id="siparisliste"></span>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    </div>
    <script src='hs/jquery.min.js'></script><script src='hs/jquery.isotope.min.js'></script>
    <script>        $(function () {
            // quick search regex
            var qsRegex;

            // init Isotope
            var $container = $('.isotope').isotope({
                itemSelector: '.element-item',
                layoutMode: 'fitRows',
                filter: function () {
                    return qsRegex ? $(this).text().match(qsRegex) : true;
                }
            });

            // use value of search field to filter
            var $quicksearch = $('#quickbutton').click(debounce(function () {
                qsRegex = new RegExp($('#quicksearch').val(), 'gi');
                $container.isotope();
            }));
        });

        // debounce so filtering doesn't happen every millisecond
        function debounce(fn, threshold) {
            var timeout;
            return function debounced() {
                if (timeout) {
                    clearTimeout(timeout);
                }
                function delayed() {
                    fn();
                    timeout = null;
                }
                setTimeout(delayed, threshold || 100);
            }
        }
        //@ sourceURL=pen.js
</script>
    </form>
</body>
</html>

<%@ Page Title="" Language="C#" MasterPageFile="~/kenton/Site1.Master" AutoEventWireup="true" CodeBehind="tarif.aspx.cs" Inherits="Sultanlar.WebUI.kenton.tarif" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function VeriGetir(ilk) {
            var tarifid = parseInt($('#tarifid').val());
            var veriyok = true;

            AndroidProgress(true);
            $.ajax(
                {
                    type: 'POST',
                    url: 'tarif.aspx/YorumlarGetir',
                    data: '{ tarifid: "' + tarifid + '" }',
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'json',
                    success: function (data) {

                        var htmlText = '';
                        var index = true;

                        for (var key1 in data) {
                            for (var key in data[key1]) {

                                var color = '';
                                if (index) {
                                    color = 'background-color: #f5f5f5;';
                                    index = false;
                                }
                                else {
                                    color = '';
                                    index = true;
                                }

                                htmlText += '<table style="width: 100%; font-size: 0.8em; ' + color + '"><tr><td align="left" style="padding: 5px"><br /><span"><i>' + data[key1][key].strAdSoyad + '</i></span></td>';
                                htmlText += '<td align="right" style="padding: 5px"><br /><span"><i>' + data[key1][key].dtTarih + '</i></span></td></tr>';
                                htmlText += '<tr><td colspan="2" style="padding: 0 10px"><span>' + data[key1][key].strYorum + '</span><br /><br /></td></tr></table>';
                                veriyok = false;
                            }
                        }

                        divData.innerHTML += htmlText;
                        if (veriyok) {
                            $('#spanYorumYok').css("display", "block");
                        }
                        $("img").unveil();

                        AndroidProgress(false);
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        AndroidProgress(false);
						AndroidToast(XMLHttpRequest.responseText);
                    }
                });

            return veriyok;
        }

        function FavEkle() {
            var uyeid = parseInt($('#uyeid').val());
            if (uyeid == 0) {
                //document.getElementById('spanFavEklendi').innerHTML = "Üye girişi yapmanız gerekiyor.";
                AndroidToast("Üye girişi yapmanız gerekiyor.");
                //$('#spanFavEklendi').show(300);
                return;
            }
            var tarifid = parseInt($('#tarifid').val());
            var eklecikar = $('#i1').hasClass("favori2") ? "cikar" : "ekle";

            AndroidProgress(true);
            $.ajax(
                {
                    type: 'POST',
                    url: 'tarif.aspx/FavEkle',
                    data: '{ uyeid: "' + uyeid + '", tarifid: "' + tarifid + '", eklecikar: "' + eklecikar + '" }',
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'json',
                    success: function (data) {
                        if (eklecikar == "ekle") {
                            //document.getElementById('spanFavEklendi').innerHTML = "Favorilere eklendi.";
                            AndroidToast("Favorilere eklendi.");
                            $('#i1').removeClass("favori1");
                            $('#i1').addClass("favori2");
                        }
                        else {
                            //document.getElementById('spanFavEklendi').innerHTML = "Favorilerden çıkarıldı.";
                            AndroidToast("Favorilerden çıkarıldı.");
                            $('#i1').removeClass("favori2");
                            $('#i1').addClass("favori1");
                        }
                        //$('#spanFavEklendi').show(300);

                        AndroidProgress(false);
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        AndroidProgress(false);
						AndroidToast(XMLHttpRequest.responseText);
                    }
                });
        }

        function PuanVer() {
            var uyeid = parseInt($('#uyeid').val());
            if (uyeid == 0) {
                //document.getElementById('spanPuanEklendi').innerHTML = "Üye girişi yapmanız gerekiyor.";
                AndroidToast("Üye girişi yapmanız gerekiyor.");
                //$('#spanPuanEklendi').show(300);
                return;
            }
            if (!$('input[name="ctl00$ContentPlaceHolder1$radio1"]:checked', '#form1').val()) {
                AndroidToast("Bir puan seçmeniz gerekiyor.");
                return;
            }
            var tarifid = parseInt($('#tarifid').val());

            AndroidProgress(true);
            $.ajax(
                {
                    type: 'POST',
                    url: 'tarif.aspx/PuanEkle',
                    data: '{ uyeid: "' + uyeid + '", tarifid: "' + tarifid + '", puan: "' + $('input[name="ctl00$ContentPlaceHolder1$radio1"]:checked', '#form1').val() + '" }',
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'json',
                    success: function (data) {
                        //document.getElementById('spanPuanEklendi').innerHTML = "Puan Kaydedildi.";
                        //$('#spanPuanEklendi').show(300);
                        AndroidToast("Puan Kaydedildi.");
                        document.getElementById('spanOrtPuan').innerHTML = data.d.OrtPuan.toFixed(1);
                        AndroidProgress(false);
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        AndroidProgress(false);
						AndroidToast(XMLHttpRequest.responseText);
                    }
                });
        }

        function YorumEkle() {
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
						AndroidToast(XMLHttpRequest.responseText);
                    }
                });
        }

        
        function TariflerGetir() {
            var katid = $('#digerkatid').val();
            AndroidProgress(true);
            $.ajax(
                {
                    type: 'POST',
                    url: 'tarif.aspx/TariflerGetir',
                    data: '{ sonid: "0", kactane: "3", action: "", uyeid: "", urunid: "' + $('#tarifid').val() + '", aranan: "", katid: "' + katid + '", order: "" }',
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'json',
                    success: function (data) {
                        var htmlText = '';
                        htmlText += '<div class="digertarifler">';
                        for (var key1 in data) {
                            for (var key in data[key1]) {
                                htmlText += '<div class="digertarifler-ic"><div class="home-box" onclick="window.location.href = \'tarif.aspx?id=' + data[key1][key].pkID + '\'"><div class="home-box-imgsiz" style="background-image: url(resim.aspx?tarif=' + data[key1][key].pkID + '); height: 150px">';
                                htmlText += '<div class="baslik-15"><span class="title-2">' + data[key1][key].strBaslik + '</span>';
                                htmlText += '</div><div class="gradient2"></div></div></div></div>';
                            }
                        }

                        htmlText += "</div>";

                        divTarifler.innerHTML = htmlText;
                        AndroidProgress(false);
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        AndroidProgress(false);
						AndroidToast(XMLHttpRequest.responseText);
                    }
                }
            );
        }

        $(window).scroll(function () {
            if ($(window).scrollTop() >= 100) {
                //$("#divTop").css("position", "fixed");
            }
            else {
                //$("#divTop").css("position", "");
            }
        });
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            //$('#spanFavEklendi').hide(1);
            $('#spanPuanEklendi').hide(1);
            VeriGetir(true);
            TariflerGetir();

            //$("input[type='button']").button();
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


        <div id="divFav" runat="server" clientidmode="Static" style="vertical-align: middle; width: 99%">

            <div class="share" style="padding-top: 5px; float: left; font-size: 23px" onclick="if ($('#divPaylas').css('display') == 'none') $('#divPaylas').show(300); else $('#divPaylas').hide(300);"><i class="fa fa-share-alt"></i></div>
            <div id="divPaylas" runat="server" clientidmode="Static" style="border-radius: 5px; background-color: #fafafa; margin-left: 10px; margin-top: 10px; padding-top: 10px; opacity: 0.9; vertical-align: middle; width: 55%; text-align: center; float: left; display: none">
                <div style="margin-left: auto; margin-right: auto; display: block;">
                    <a target="_blank" href='https://www.facebook.com/sharer/sharer.php?u=https%3A%2F%2Fwww.sultanlar.com.tr/pratikcozumler/tarif/<%= Request.QueryString["id"] %>'>
                        <img src="images/sm/fb.png" runat="server" id="img6" style="width: 32px; margin-left: auto; margin-right: auto; padding-right: 5px; padding-bottom: 5px" /></a>
                    <a target="_blank" href='http://twitter.com/share?text=Kenton Tarif&url=https://www.sultanlar.com.tr/pratikcozumler/tarif/<%= Request.QueryString["id"] %>&hashtags=kenton,tarif,pratikcozumler'>
                        <img src="images/sm/tw.png" runat="server" id="img7" style="width: 32px; margin-left: auto; margin-right: auto; padding-right: 5px; padding-bottom: 5px" /></a>
                    <a target="_blank" href='https://www.linkedin.com/shareArticle?mini=true&url=https%3A%2F%2Fwww.sultanlar.com.tr/pratikcozumler/tarif/<%= Request.QueryString["id"] %>&source=Kenton'>
                        <img src="images/sm/li.png" runat="server" id="img8" style="width: 32px; margin-left: auto; margin-right: auto; padding-right: 5px; padding-bottom: 5px" /></a>
                    <a target="_blank" href='https://plus.google.com/share?url=https://www.sultanlar.com.tr/pratikcozumler/tarif/<%= Request.QueryString["id"] %>'>
                        <img src="images/sm/gp.png" runat="server" id="img9" style="width: 32px; margin-left: auto; margin-right: auto; padding-right: 5px; padding-bottom: 5px" /></a>
                    <a target="_blank" href='http://pinterest.com/pin/create/button/?url=https%3A%2F%2Fwww.sultanlar.com.tr/pratikcozumler/tarif/<%= Request.QueryString["id"] %>&media=https%3A%2F%2Fwww.sultanlar.com.tr/kenton/resim.aspx?tarif=<%= Request.QueryString["id"] %>&description=Kenton'>
                        <img src="images/sm/pi.png" runat="server" id="img10" style="width: 32px; margin-left: auto; margin-right: auto; padding-right: 5px; padding-bottom: 5px" /></a>
                </div>
            </div>



            <a href="javascript:FavEkle()" style="float: right; margin-top: 5px"><i class="fa fa-gratipay imgFav" aria-hidden="true" runat="server" id="i1" clientidmode="Static" style="padding-right: 30px"></i></a>

            <%--<span class="tarifbaslik2" id="spanFavEklendi" style="padding-top: 8px; padding-left: 8px; font-style: italic; font-size: 12px;">Favorilere eklendi.</span>--%>
        </div>


        <img style="width: 100%" src="images/loading.jpg" runat="server" id="imgResim" alt="Tarif" />
        <div class="gradient1"></div>

        <div runat="server" id="divPuan" style="font-size: 11px" clientidmode="Static">
            <div class="favoriler" style="width: 80%; auto; display: block;">
                <input type="radio" id="puan1" value="1" name="radio1" runat="server" clientidmode="Static" onclick="PuanVer()" /><label for="puan1"></label>
                <input type="radio" id="puan2" value="2" name="radio1" runat="server" clientidmode="Static" onclick="PuanVer()" /><label for="puan2"></label>
                <input type="radio" id="puan3" value="3" name="radio1" runat="server" clientidmode="Static" onclick="PuanVer()" /><label for="puan3"></label>
                <input type="radio" id="puan4" value="4" name="radio1" runat="server" clientidmode="Static" onclick="PuanVer()" /><label for="puan4"></label>
                <input type="radio" id="puan5" value="5" name="radio1" runat="server" clientidmode="Static" onclick="PuanVer()" /><label for="puan5"></label>
                <input type="button" value="Kaydet" onclick="PuanVer()" style="display: none" />
                <span class="tarifbaslik2" id="spanPuanEklendi" style="font-style: italic; font-size: 12px;">(Eklendi)</span>
                <div class="tarifbaslik2" style="font-size: 12px">Puan: <span id="spanOrtPuan" runat="server" clientidmode="Static">Ort</span></div>
            </div>
        </div>


        <span runat="server" id="spanBaslik" class="login100-form-title tarifbaslik">Başlık</span>


    <div class="main-content">
        <h3 class="ribbon paddingyok">Malzemeler</h3><br />
        <p runat="server" id="spanMalzemeler" style="text-align: justify">(MalzemelerBurada)</p>
        <br />
        <br />
        <h3 class="ribbon paddingyok">Hazırlanış</h3><br />
        <p runat="server" id="spanHazirlanis" style="text-align: justify">(HazırlanışBurada)</p>
        <span id="spanOnay1" runat="server" clientidmode="Static" style="font-size: 0.8em">
            <br />
            <br />
            Onay Durumu: <span id="spanOnay" runat="server" clientidmode="Static" style="color: Green">(Onay)</span></span>
    </div>
    <div runat="server" id="divVideo" visible="false">
        <h3 class="ribbon">Tarifin Videosu</h3>
        <div runat="server" id="divVideoI"></div>
        <br />
    </div>
    <div runat="server" id="divSatinAl">

        <%--<div id="divPaylas" runat="server" clientidmode="Static" style="vertical-align: middle; width: 100%; text-align: center">
<div style="width: 70%; margin-left: auto; margin-right: auto; display: block;">
<a target="_blank" href='https://www.facebook.com/sharer/sharer.php?u=https%3A%2F%2Fwww.sultanlar.com.tr/pratikcozumler/tarif/<%= Request.QueryString["id"] %>'><img src="images/sm/fb.png" runat="server" id="img1" style="width: 32px; margin-left: auto; margin-right: auto; padding-right: 5px; padding-bottom: 5px" /></a>
<a target="_blank" href='http://twitter.com/share?text=Kenton Tarif&url=https://www.sultanlar.com.tr/pratikcozumler/tarif/<%= Request.QueryString["id"] %>&hashtags=kenton,tarif,pratikcozumler'><img src="images/sm/tw.png" runat="server" id="img2" style="width: 32px; margin-left: auto; margin-right: auto; padding-right: 5px; padding-bottom: 5px" /></a>
<a target="_blank" href='https://www.linkedin.com/shareArticle?mini=true&url=https%3A%2F%2Fwww.sultanlar.com.tr/pratikcozumler/tarif/<%= Request.QueryString["id"] %>&source=Kenton'><img src="images/sm/li.png" runat="server" id="img3" style="width: 32px; margin-left: auto; margin-right: auto; padding-right: 5px; padding-bottom: 5px" /></a>
<a target="_blank" href='https://plus.google.com/share?url=https://www.sultanlar.com.tr/pratikcozumler/tarif/<%= Request.QueryString["id"] %>'><img src="images/sm/gp.png" runat="server" id="img4" style="width: 32px; margin-left: auto; margin-right: auto; padding-right: 5px; padding-bottom: 5px" /></a>
<a target="_blank" href='http://pinterest.com/pin/create/button/?url=https%3A%2F%2Fwww.sultanlar.com.tr/pratikcozumler/tarif/<%= Request.QueryString["id"] %>&media=https%3A%2F%2Fwww.sultanlar.com.tr/kenton/resim.aspx?tarif=<%= Request.QueryString["id"] %>&description=Kenton'><img src="images/sm/pi.png" runat="server" id="img5" style="width: 32px; margin-left: auto; margin-right: auto; padding-right: 5px; padding-bottom: 5px" /></a>
</div>
</div>--%>
        <h3 class="ribbon">Ürünleri Satın Alın</h3>
        <a runat="server" id="aUrunler">
            <img style="width: 100%; padding: 15px 0px 15px 0px" src="images/gif-load.gif" data-src='' runat="server" id="imgUrunler" /></a>
    </div>
    <%--<div runat="server" id="divPuan" style="font-size: 11px">
<br /><br />
<span class="login100-form-title">Puanlama</span>
<br />
<div class="favoriler" style="width: 80%; margin-left: auto; margin-right: auto; display: block;">
 <div style="font-size: 12px">Tarifin Ortalama Puanı: <span id="spanOrtPuan" runat="server" clientidmode="Static">Ort</span></div><br />
<input type="radio" id="puan1" value="1" name="radio1" runat="server" clientidmode="Static" /><label for="puan1"></label>
<input type="radio" id="puan2" value="2" name="radio1" runat="server" clientidmode="Static" /><label for="puan2"></label>
<input type="radio" id="puan3" value="3" name="radio1" runat="server" clientidmode="Static" /><label for="puan3"></label>
<input type="radio" id="puan4" value="4" name="radio1" runat="server" clientidmode="Static" /><label for="puan4"></label>
<input type="radio" id="puan5" value="5" name="radio1" runat="server" clientidmode="Static" /><label for="puan5"></label>
<input type="button" value="Kaydet" onclick="PuanVer()" />
<span id="spanPuanEklendi" style="float: left; padding-top: 8px; padding-left: 8px; font-style: italic; font-size: 12px;">(Eklendi)</span>
</div>
</div>--%>
    <%--<div id="divFav" runat="server" clientidmode="Static" style="vertical-align: middle;">
<br /><br />
<span class="login100-form-title" style="font-size: 16px">Favorilerinize Ekleyin</span>
<br />
<table style="width: 100%"><tr><td align="center" valign="middle">
<a href="javascript:FavEkle()"><img src="images/star_bos.png" runat="server" id="imgFav" style="width: 32px;" /></a>
</td></tr><tr><td align="center" valign="middle" style="height: 30px">
<span id="spanFavEklendi" style="padding-top: 8px; padding-left: 8px; font-style: italic; font-size: 12px;">Favorilere eklendi.</span>
</td></tr></table>
</div>--%>
    

        <h3 class="ribbon">Beğenebileceğiniz Tarifler</h3>
    
    <div id="divTarifler"></div>

    <div class="yorumlar">
    <span class="login100-form-title">Yorumlar</span>
    <br />
    <div id="divData" style="<%--padding: 7px--%>"></div>
    <span runat="server" id="spanYorumYok" visible="true" style="font-size: 14px; display: none; padding-left: 7px" clientidmode="Static"><i>Henüz hiç yorum yapılmamış.<br />
        <br />
    </i></span>

    </div>
    <input type="hidden" runat="server" id="tarifid" clientidmode="Static" />
    <input type="hidden" runat="server" id="uyeid" clientidmode="Static" />
    <input type="hidden" runat="server" id="digerkatid" clientidmode="Static" />

    <div runat="server" id="divYorum">
        <%--<span class="login100-form-title" style="font-size: 14px">Yorum Ekleyin</span><br />--%>
        <div class="wrap-input100 validate-input" style="margin-bottom: 0px">
            <textarea class="ta100" cols="40" rows="10" runat="server" id="yorumTa" clientidmode="Static" style="width: 100%;" placeholder="Yorumunuzu lütfen bizimle paylaşın..."></textarea>
            <span class="focus-ta100"></span>
        </div>
        <div class="container-login100-form-btn1" onclick="YorumEkle()">
            <div class="wrap-login100-form-btn1" style="color: #ffffff">
                <div class="login100-form-bgbtn1"></div>
                GÖNDER
            </div>
        </div>
        <br /><br />
    </div>
</asp:Content>

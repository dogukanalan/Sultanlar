<%@ Page Title="" Language="C#" MasterPageFile="~/kenton/Site1.Master" AutoEventWireup="true"
    CodeBehind="tarifler.aspx.cs" Inherits="Sultanlar.WebUI.kenton.tarifler" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var veriyok = false;

        function VeriGetir(ilk) {
            var sonid = parseInt($('#sonId').val());
            var xhr = new XMLHttpRequest();

            if (!ilk && veriyok)
                return;
            
            veriyok = true;

            var kactane = 5;

            if (getParameterByName("tariftext")) {
                $('#aranan').val(getParameterByName("tariftext"));
            }

            var siralama = "";
            if (getParameterByName("o")) {
                siralama = getParameterByName("o");
                if (siralama == "random")
                    kactane = 1000;
            }

            var katid = 0;
            if (getParameterByName("kat")) {
                katid = parseInt(getParameterByName("kat"));
            }

            if (ilk) {
                sonid = 0;
                $('#sonId').val('0');
                //$('#aDaha').css("display", "");
                //$('#spanDaha').css("display", "none");
            }

            AndroidProgress(true);
            $.ajax(
                {
                    xhr: function () {
                        var xhr = new window.XMLHttpRequest();
                        //Upload progress
                        xhr.upload.addEventListener("progress", function (evt) {
                            if (evt.lengthComputable) {
                                var percentComplete = evt.loaded / evt.total;
                                $('#divProgress').css("display", "block");
                            }
                        }, false);
                        //Download progress
                        xhr.addEventListener("progress", function (evt) {
                            if (evt.lengthComputable) {
                                var percentComplete = evt.loaded / evt.total;
                                $('#divProgress').css("display", "block");
                            }
                        }, false);
                        return xhr;
                    },
                    type: 'POST',
                    url: 'tarifler.aspx/TariflerGetir',
                    data: '{ sonid: "' + $('#sonId').val() + '", kactane: ' + kactane + ', action: "' + $('#actionA').val() + '", uyeid: "' + $('#uyeid').val() + '", urunid: "' + getParameterByName("urunid") + '", aranan: "' + $('#aranan').val() + '", katid: "' + katid + '", order: "' + siralama + '" }', //$('input[name="radio1"]:checked', '#form1').val()
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'json',
                    success: function (data) {
                        //divData.innerHTML = JSON.stringify(data);
                        
                        var htmlText = '';
                        $('#divProgress').css("display", "none");

                        //htmlText += '<table style="width: 100%">';
                        //var kolon = 0;

                        htmlText += '<div style="width: 100%">';

                        for (var key1 in data) {
                            for (var key in data[key1]) {
                                sonid++; // data[key1][key].pkID

                                /*htmlText += '<table id="tariff' + sonid.toString() + '" style="border-bottom: 1px solid #CCE9FF"><tr><td><span class="login100-form-title" style="font-size: 14px">' + data[key1][key].strBaslik + '</span>';
                                htmlText += '<span class="login100-form-title"><img style="width: 100%; padding: 15px 0px 15px 0px" src="images/gif-load.gif" data-src="resim.aspx?tarif=' + data[key1][key].pkID + '" alt="' + data[key1][key].strBaslik + '" /></span>';
                                htmlText += '<span style="font-size: 12px">' + data[key1][key].strMalzemeler.toString().split("<br>").join(", ").substring(0, data[key1][key].strMalzemeler.toString().split("<br>").join(", ").length) + '</span><br /><br />';
                                htmlText += '<span style="font-size: 12px">' + data[key1][key].strHazirlanis.toString().substring(0, 200) + '...</span><br><br>';
                                htmlText += '<span style="font-size: 14px;"><i>Tarif Puanı: <b>' + (data[key1][key].OrtPuan == 0 ? 'Henüz puanlanmadı.' : data[key1][key].OrtPuan) + '</b></i></span><br /><br />';
                                htmlText += '<div class="container-login100-form-btn"><div class="wrap-login100-form-btn"><div class="login100-form-bgbtn"></div><a class="login100-form-btn" href="tarif.aspx?id=' + data[key1][key].pkID + '">TARİFİ GÖRÜNTÜLEYİN</a></div></div><br />';
                                htmlText += '</td></tr></table><br />';*/

                                //kolon++;
                                //if (kolon == 1) {
                                //    htmlText += '<tr><td style="width: 50%; padding: 5px" valign="top"><div onclick="window.location.href = \'tarif.aspx?id=' + data[key1][key].pkID + '\'" style="width: 100%; height: 100%; background-color: #E5F4FF; color: #606060; border-radius: 5px"><div style="width: 100%; height: 150px; background-size:cover; background-repeat:no-repeat; background-position: center; background-image: url(resim.aspx?tarif=' + data[key1][key].pkID + ');"></div><div style="height: 55px; font-size: 14px; vertical-align: middle; padding: 5px">' + data[key1][key].strBaslik + '</div></div></td>';
                                //}
                                //else if (kolon == 2) {
                                //    htmlText += '<td style="width: 50%; padding: 5px" valign="top"><div onclick="window.location.href = \'tarif.aspx?id=' + data[key1][key].pkID + '\'" style="width: 100%; height: 100%; background-color: #E5F4FF; color: #606060; border-radius: 5px"><div style="width: 100%; height: 150px; background-size:cover; background-repeat:no-repeat; background-position: center; background-image: url(resim.aspx?tarif=' + data[key1][key].pkID + ');"></div><div style="height: 55px; font-size: 14px; vertical-align: middle; padding: 5px">' + data[key1][key].strBaslik + '</div></div></td></tr>';
                                //    kolon = 0;
                                //}

                                htmlText += '<div style="width: 100%;"><div class="home-box" onclick="window.location.href = \'tarif.aspx?id=' + data[key1][key].pkID + '\'"><div class="home-box-img lazyload" data-src="url(resim.aspx?tarif=' + data[key1][key].pkID + ')" style="background-image: url(images/loading.jpg);">';
                                htmlText += '<div class="baslik-14"><span class="title-1">' + data[key1][key].strBaslik + '</span>';
                                htmlText += '<span class="sub-title1"> ' + data[key1][key].Uye.strAd + ' '  + data[key1][key].Uye.strSoyad + '</span></div><div class="gradient1"></div></div></div></div>';
                                
                                //var imageSrcs = ['resim.aspx?tarif=' + data[key1][key].ResimID];
                                //preloadImages(imageSrcs);

                                veriyok = false;
                            }
                        }

                        htmlText += "</div>";

                        $('#sonId').val(sonid);

                        if (!ilk)
                            divData.innerHTML += htmlText;
                        else
                            divData.innerHTML = htmlText;

                        if (veriyok) {
                            //$('#aDaha').css("display", "none");
                            //$('#spanDaha').css("display", "block");
                        }
                        
                        //$(".home-box-img").unveil2();
                        $(".home-box-img").unveil2(0, function() { $(this).css('opacity', '1'); });
                        //$("div.lazyload").lazyload();

                        /*if (sonid != 0 && !ilk)
                        $("body, html").animate({ scrollTop: $('#tariff' + sonid.toString()).offset().top }, 200);*/

                        AndroidProgress(false);
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        AndroidProgress(false);
						AndroidToast(XMLHttpRequest.responseText);
                    }
                }
            );
            
            //$(window).scrollTop($('#tariff' + sonid.toString()).offset().top);
        }

        $(window).scroll(function () {
            if ($(window).scrollTop() + $(window).height() >= $(document).height() - 100) {
                VeriGetir(false);
            }
        });

    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            if (document.location.href.indexOf("tarifler.aspx?a=benim") > -1) {
                $("#imgHead").attr("src", "images/headers/3.png");
                $("#pBaslik").html("BENİM TARİFLERİM");
            }
            else if (document.location.href.indexOf("tarifler.aspx?a=fav") > -1) {
                $("#imgHead").attr("src", "images/headers/4.png");
                $("#pBaslik").html("FAVORİ TARİFLERİM");
            }
            else {
                $("#imgHead").css("display", "hidden");
                $("#pBaslik").css("display", "hidden");
            }

            VeriGetir(true);
            //$("input[type='radio']").checkboxradio({
            //    icon: false
            //});
            $("label").css("padding", "1em");
            //document.getElementById("sira1").checked = checked;
            //$('#sira1').attr("checked", true).button("refresh");
            $('input[type="radio"]').change(
                function () {
                    VeriGetir(true);
                }
            );
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="divana">
    <%--<span class="login100-form-title p-b-26">Tarifler </span>--%>
        <img src="" class="imgheader" id="imgHead" />
        <p class="favtarif" id="pBaslik"></p>
    <div class="wrap-input100 validate-input" style="margin-bottom: 10px; margin-top: 30px; display: none;">
        <input class="input100" type="text" name="aranan" runat="server" id="aranan" autocomplete="off" clientidmode="Static" />
        <span class="focus-input100" data-placeholder="Tarif arayın..."></span>
    </div>
    <div class="container-login100-form-btn" style="padding-top: 0px; display: none">
        <div class="wrap-login100-form-btn">
            <div class="login100-form-bgbtn"></div>
            <a class='login100-form-btn' href='javascript:VeriGetir(true);'>
                <img class="srch1" src="images/search.png" /></a>
        </div>
    </div>
    <div id="divFiltre" style="padding: 5px; display: none">
        <div class="head-button">
            <input type="radio" id="sira1" value="yeni" name="radio1" /><label class="buton50" for="sira1">En Yeni</label>
            <input type="radio" id="sira2" value="puan" name="radio1" /><label class="buton50" for="sira2">En Yüksek Puanlı</label>
            <input type="radio" id="sira3" value="yorum" name="radio1" /><label class="buton50" for="sira3">En Çok Yorum Alan</label>
        </div>
    </div>
    <div class="container-login100-form-btn1" runat="server" id="divTarifEkle" onclick="window.location.href = 'tarifekle.aspx'" visible='false'>
        <div class="wrap-login100-form-btn1">
            <div class="login100-form-bgbtn1"></div>
            <a id="a1" class='login100-form-btn1' href='#'>TARİF EKLE</a>
        </div>
    </div>
    <div id="divData"></div>
    <%--<div class="container-login100-form-btn" style="padding-top: 0px">
	<div class="wrap-login100-form-btn">
    <div class="login100-form-bgbtn"></div>
    <a id="aDaha" class='login100-form-btn' href='javascript:VeriGetir(false);'>Daha fazla görüntüle</a></div></div>
    <span id="spanDaha" class="fs-14" style="text-align: center;"><br /><i>Bulunamadı...</i></span>
    <div id="divLoading" style="display: none">
        <img style="width: 100%; padding: 15px 0px 15px 0px;" src="images/gif-load.gif" alt="yükleniyor..." />
    </div>--%>
    <input type="hidden" id="sonId" value="0" />
    <input type="hidden" runat="server" id="actionA" value="" clientidmode="Static" />
    <input type="hidden" runat="server" id="uyeid" value="" clientidmode="Static" />

    </div>
</asp:Content>

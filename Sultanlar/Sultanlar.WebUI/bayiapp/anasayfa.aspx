<%@ Page Title="" Language="C#" MasterPageFile="Site1.Master" AutoEventWireup="true" CodeBehind="anasayfa.aspx.cs" Inherits="Sultanlar.WebUI.bayiapp.anasayfa" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var veriyok = false;
        
        $(document).ready(function () {
            VeriGetir(true);
        });

        function VeriGetir(ilk) {
            var sonid = parseInt($('#sonId').val());

            if (!ilk && veriyok)
                return;
            
            veriyok = true;

            if (getParameterByName("uruntext")) {
                $('#aranan').val(getParameterByName("uruntext"));
            }

            if (getParameterByName("kat")) {
                $('#katid').val(getParameterByName("kat"));
            }

            if (ilk) {
                sonid = 0;
                $('#sonId').val('0');
                $('#spanDaha').css("display", "none");
            }

            AndroidProgress(true);
            $.ajax(
                {
                    type: 'POST',
                    url: 'anasayfa.aspx/UrunlerGetir',
                    data: '{ sonid: "' + $('#sonId').val() + '", aranan: "' + $('#aranan').val() + '", katid: "' + $('#katid').val() + '" }',
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'json',
                    success: function (data) {
                        var htmlText = '';
                        for (var key1 in data) {
                            for (var key in data[key1]) {
                                sonid++;
                                ////htmlText += '<span class="login100-form-title" style="font-size: 12px;">' + data[key1][key].Ad + '</span>';
                                //htmlText += '<span class="login100-form-title"><img style="width: 100%; padding: 15px 0px 15px 0px" src="images/gif-load.gif" data-src="../musteri/resim.aspx?uid400=' + data[key1][key].ResimID + '" alt="' + data[key1][key].Ad + '" /></span>';
                                //htmlText += '<div class="container-login100-form-btn1" style="display: block; float: left; width: 48%; margin-bottom: 7px"><div class="wrap-login100-form-btn1"><div class="login100-form-bgbtn1"></div><a class="login100-form-btn1" href="tarifler.aspx?a=urun&urunid=' + data[key1][key].ID + '">Tarifler</a></div></div>';
                                //htmlText += '<div class="container-login100-form-btn1" style="display: block; float: right; width: 48%; margin-bottom: 7px"><div class="wrap-login100-form-btn1"><div class="login100-form-bgbtn1"></div><a class="login100-form-btn1" target="_blank" href="https://www.komsu.com.tr/index.php?p=search&search=' + data[key1][key].ID + '">Satın Al</a></div></div>';

                                htmlText += '<div class="bolum"><span class="login100-form-title"><img class="lazyload" style="width: 100%; padding: 15px 0px 15px 0px" src="images/loading.jpg" data-src="resim.aspx?resim=' + data[key1][key].ResimID + '" alt="' + data[key1][key].Ad + '" /></span>';
                                htmlText += '<div class="button1" onclick="window.location.href = \'tarifler.aspx?a=urun&urunid=' + data[key1][key].ID + '\'"><span><i class="fa fa-book"></i>Tarifler</span></div>';
                                htmlText += '<div class="button2" onclick="window.location.href = \'https://www.komsu.com.tr/index.php?p=search&search=' + data[key1][key].ID + '\'"><span><i class="fa fa-shopping-bag"></i>Satın Al</span></div></div>';

                                //var imageSrcs = ['resim.aspx?resim=' + data[key1][key].ResimID];
                                //preloadImages(imageSrcs);

                                veriyok = false;
                            }
                        }

                        $('#sonId').val(sonid);

                        if (!ilk)
                            divData.innerHTML += htmlText;
                        else
                            divData.innerHTML = htmlText;

                        if (veriyok) {
                            $('#divLoading').css("display", "none");
                            $('#spanDaha').css("display", "block");
                        }
                        $("img").unveil(0, function () { $(this).one("load", function () { $(this).css('opacity', '1'); $(this).removeAttr('data-src'); }); });
                        //$("img").lazyload();

                            //if (sonid != 0 && !ilk)
                            //    $("body, html").animate({ scrollTop: $('#tariff' + sonid.toString()).offset().top }, 200);
                            
                            AndroidProgress(false);
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            AndroidProgress(false);
                            alert(XMLHttpRequest.responseText);
                        }
                }
            );
        }

        $(window).scroll(function () {
            if ($(window).scrollTop() + $(window).height() >= $(document).height() - 100) {
                VeriGetir(false);
            }
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="wrap-input100 validate-input" style="margin-bottom: 10px; display: none">
		<input class="input100" type="text" name="aranan" runat="server" id="aranan" autocomplete="off" clientidmode="Static" />
		<span class="focus-input100" data-placeholder="Ürün arayın..."></span>
	</div>
    <div class="container-login100-form-btn" style="padding-top: 0px; display: none">
	<div class="wrap-login100-form-btn">
    <div class="login100-form-bgbtn"></div>
    <a class='login100-form-btn' href='javascript:VeriGetir(true);'><img class="srch1" src="images/search.png"/></a>
    </div>
    </div>
    <div id="divData"></div>
    <div id="divLoading" style="display: block">
        <i style="display: block; text-align: center"></i>
    </div>
    <span id="spanDaha" class="fs-14" style="display: none; text-align: center;"><i></i></span>
    <input type="hidden" id="sonId" value="0" />
    <input type="hidden" id="katid" value="0" />
</asp:Content>

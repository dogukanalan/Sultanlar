<%@ Page Title="" Language="C#" MasterPageFile="~/kenton/Site1.Master" AutoEventWireup="true" CodeBehind="videolar.aspx.cs" Inherits="Sultanlar.WebUI.kenton.videolar" %>
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
            var siralama = '';

            if (getParameterByName("videotext")) {
                $('#aranan').val(getParameterByName("videotext"));
            }

            if (ilk) {
                sonid = 0;
                $('#sonId').val('0');
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
                                console.log(percentComplete);
                            }
                        }, false);
                        //Download progress
                        xhr.addEventListener("progress", function (evt) {
                            if (evt.lengthComputable) {
                                var percentComplete = evt.loaded / evt.total;
                                $('#divProgress').css("display", "block");
                                console.log(percentComplete);
                            }
                        }, false);
                        return xhr;
                    },
                    type: 'POST',
                    url: 'videolar.aspx/VideolarGetir',
                    data: '{ sonid: "' + $('#sonId').val() + '", kactane: ' + kactane + ', aranan: "' + $('#aranan').val() + '", order: "' + siralama + '" }',
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'json',
                    success: function (data) {
                        var htmlText = '';
                        $('#divProgress').css("display", "none");

                        htmlText += '<div style="width: 100%">';
                        
                        for (var key1 in data) {
                            for (var key in data[key1]) {
                                sonid++;

                                htmlText += '<div style="width: 100%;"><div class="home-box"><div class="home-box-imgsiz-1" onclick="window.location.href = \'https://www.youtube.com/watch?v=' + data[key1][key].strVideo + /*'&vid=' + data[key1][key].pkID + */'\'" style="background-image: url(https://img.youtube.com/vi/' + data[key1][key].strVideo + '/mqdefault.jpg)">';
                                htmlText += '<div class="baslik-14-1"><span class="title-1">' + data[key1][key].strBaslik + '</span>';
                                htmlText += '<span class="sub-title1"> ' + data[key1][key].Uye.strAd + ' '  + data[key1][key].Uye.strSoyad + '</span></div><div class="gradient1-1"></div></div></div></div>';
                                
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

                        }

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
    <script type="text/javascript">
        $(document).ready(function () {
            VeriGetir(true);
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="divData"></div>
    <input type="hidden" id="sonId" value="0" clientidmode="Static" />
    <input type="hidden" runat="server" id="actionA" value="" clientidmode="Static" />
    <input type="hidden" runat="server" id="uyeid" value="" clientidmode="Static" />
        <input class="input100" type="text" name="aranan" runat="server" id="aranan" autocomplete="off" clientidmode="Static" />
</asp:Content>

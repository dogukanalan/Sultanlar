<%@ Page Title="" Language="C#" MasterPageFile="~/kenton/Site1.Master" AutoEventWireup="true" CodeBehind="tarifekle.aspx.cs" Inherits="Sultanlar.WebUI.kenton.tarifekle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  <meta http-equiv="cache-control" content="no-cache, must-revalidate, post-check=0, pre-check=0" />
  <meta http-equiv="cache-control" content="max-age=0" />
  <meta http-equiv="expires" content="0" />
  <meta http-equiv="expires" content="Tue, 01 Jan 1980 1:00:00 GMT" />
  <meta http-equiv="pragma" content="no-cache" />

    <script type="text/javascript">
        var canvas;
        var resimyuklendi = false;

        $(document).ready(function () {



            var input = document.getElementById('fu');
            input.addEventListener('change', handleFiles);
            
            function handleFiles(e) {
                canvas = document.getElementById('canvas');
                var ctx = document.getElementById('canvas').getContext('2d');
                var img = new Image;
                img.src = URL.createObjectURL(e.target.files[0]);
                img.onload = function () {
                    try {
                    Android.showProgress();
                    } catch (e) {

                    }
                    canvas.height = 700; //img.height
                    canvas.width = 700 * img.width / img.height; //img.width
                    var w=img.width;
                    var h=img.height;
                    var sizer = scalePreserveAspectRatio(w, h, canvas.width, canvas.height);
                    //ctx.drawImage(img, 0, 0);
                    ctx.drawImage(img,0,0,w,h,0,0,w*sizer,h*sizer);
                    try {
                    Android.hideProgress();
                    } catch (e) {

                    }
                    alert('Resim yüklendi.');
                    resimyuklendi = true;
                }
            }
        });

        function scalePreserveAspectRatio(imgW,imgH,maxW,maxH){
            return(Math.min((maxW/imgW),(maxH/imgH)));
        }

        function Gonder(control) {
            if (!resimyuklendi) {
                alert('Resim yüklemediniz.');
                return;
            }
            AndroidProgress(true);

            control.style.display = 'none';
            $('#barloading').css("display", "block");

            var Pic = canvas.toDataURL('image/jpeg', 0.65);
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
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div runat="server" id="divYorum" class="divana">
    <img src="images/headers/2.png" class="imgheader" />
        <p class="favtarif">TARİFİNİZİ OLUŞTURUN</p>
        <div class="divform">
        <div class="wrap-input100 validate-input" data-validate="Başlık boş olmamalı" style="margin-bottom: 25px">
            <input type="text" class="input100" runat="server" name="baslik" id="baslik" clientidmode="Static" />
            <span class="focus-input100" data-placeholder="Başlık"></span>
        </div>
        <div class="wrap-input100 validate-input" style="margin-bottom: 25px">
            <textarea class="ta100" cols="40" rows="10" runat="server" id="malzemelerTa" clientidmode="Static" style="width: 100%; height: 300px; padding: 5px 5px 5px 5px;"></textarea>
            <span class="focus-ta100" data-placeholder="Malzemeler"></span>
        </div>
        <div class="wrap-input100 validate-input" style="margin-bottom: 25px">
            <textarea class="ta100" cols="40" rows="10" runat="server" id="hazirlanisTa" clientidmode="Static" style="width: 100%; height: 200px; padding: 5px 5px 5px 5px;"></textarea>
            <span class="focus-ta100" data-placeholder="Hazırlanış"></span>
        </div>
        <div class="wrap-input100 validate-input" style="margin-bottom: 25px">
            <input type="file" class="input100" id="fu" />
            <canvas id="canvas" style="width: 100%"></canvas>
        </div>
        <div class="container-login100-form-btn1" onclick="Gonder(this)">
            <div class="wrap-login100-form-btn1" style="color: #ffffff">
                <div class="login100-form-bgbtn1"></div>
                GÖNDER
            </div>
        </div>
        <img id="barloading" src="images/lg.gif" style="display: none" />
            </div>
    </div>
    <input type="hidden" runat="server" id="uyeid" clientidmode="Static" />
</asp:Content>

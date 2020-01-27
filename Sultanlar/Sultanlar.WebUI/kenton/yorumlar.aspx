<%@ Page Title="" Language="C#" MasterPageFile="~/kenton/Site1.Master" AutoEventWireup="true" CodeBehind="yorumlar.aspx.cs" Inherits="Sultanlar.WebUI.kenton.yorumlar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function VeriGetir(ilk) {
            var sonid = parseInt($('#sonId').val());
            var veriyok = true;
            var xhr = new XMLHttpRequest();

            AndroidProgress(true);
            $.ajax(
                    {
                        xhr: function () {
                            var xhr = new window.XMLHttpRequest();
                            //Upload progress
                            xhr.upload.addEventListener("progress", function (evt) {
                                if (evt.lengthComputable) {
                                    var percentComplete = evt.loaded / evt.total;
                                    $('#divLoading').css("display", "block");
                                    console.log(percentComplete);
                                }
                            }, false);
                            //Download progress
                            xhr.addEventListener("progress", function (evt) {
                                if (evt.lengthComputable) {
                                    var percentComplete = evt.loaded / evt.total;
                                    $('#divLoading').css("display", "block");
                                    console.log(percentComplete);
                                }
                            }, false);
                            return xhr;
                        },
                        type: 'POST',
                        url: 'yorumlar.aspx/YorumlarGetir',
                        data: '{ sonid: "' + $('#sonId').val() + '", action: "' + $('#actionA').val() + '", uyeid: "' + $('#uyeid').val() + '" }',
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
                                        color = 'background-color: #ffffff;';
                                        index = true;
                                    }

                                    sonid = data[key1][key].pkID;
                                    htmlText += '<table style="width: 100%; padding: 7px; ' + color + '">';
                                    htmlText += '<tr><td colspan="2" style="text-align: center; font-weight: bold"><span style="font-size: 14px;"><a href="tarif.aspx?id=' + data[key1][key].intTarifID + '" style="color: #000000">' + data[key1][key].strBaslik + '</a></span></td></tr>';
                                    htmlText += '<tr><td align="left"><span style="font-size: 12px"><i>' + data[key1][key].strAdSoyad + '</i></span></td>';
                                    htmlText += '<td align="right"><span style="font-size: 12px"><i>' + data[key1][key].dtTarih + '</i></span></td></tr>';
                                    htmlText += '<tr><td colspan="2" style="padding-top: 5px"><span style="font-size: 12px">' + data[key1][key].strYorum + '</span></td></tr>';
                                    htmlText += '<tr><td colspan="2" style="padding-top: 5px"><span style="font-size: 12px"><i>"Onay Durumu: ' + (data[key1][key].blOnayli ? "<span style='color: Green'>Onaylı" : "<span style='color: Red'>Henüz Onaylanmadı") + '</span>"</i></span></td></tr></table>';
                                    veriyok = false;
                                }
                            }

                            $('#sonId').val(sonid);
                            divData.innerHTML += htmlText;
                            if (veriyok) {
                                $('#aDaha').css("display", "none");
                                $('#spanDaha').css("display", "block");
                            }
                            $('#divLoading').css("display", "none");
                            
                            AndroidProgress(false);
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            AndroidProgress(false);
                            alert(XMLHttpRequest.responseText);
                        }
                    });

            return veriyok;
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
    <div class="divana">
    
    <img src="images/headers/1.png" class="imgheader" />
    <%--<br /><br /><span class="login100-form-title p-b-26">Yorumlar</span>--%>
    <div id="divData"></div>
    <%--<div class="container-login100-form-btn1">
	<div class="wrap-login100-form-btn1">
    <div class="login100-form-bgbtn1"></div>
    <a id="aDaha" class='login100-form-btn1' href='javascript:VeriGetir(false);'>Daha fazla görüntüle</a>
	</div></div>--%>
    <span id="spanDaha" class="fs-14" style="display: none; text-align: center; color: white"><i>Henüz hiç yorum eklenmedi...</i><br /><br /></span>
    <div id="divLoading" style="display: none; text-align: center; color: white">
        <br /><i>yükleniyor...</i><br /><br />
    </div>
    <input type="hidden" id="sonId" value="1000000" />
    <input type="hidden" runat="server" id="actionA" value="" clientidmode="Static" />
    <input type="hidden" runat="server" id="uyeid" value="" clientidmode="Static" />
        </div>
</asp:Content>

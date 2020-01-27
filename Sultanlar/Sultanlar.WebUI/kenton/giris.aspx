<%@ Page Title="" Language="C#" MasterPageFile="~/kenton/Site1.Master" AutoEventWireup="true" CodeBehind="giris.aspx.cs" Inherits="Sultanlar.WebUI.kenton.giris" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            if (getParameterByName('hata') != null) {
                document.getElementById('hata').innerHTML = "<br>Giriş başarısız. Lütfen tekrar deneyin.";
            }
        });

        function GirisYap() {
            AndroidProgress(true);
            $.ajax(
                    {
                        type: 'POST',
                        url: 'giris.aspx/Giris',
                        data: '{ email: "' + $('#email').val() + '", sifre: "' + $('#pass1').val() + '" }',
                        contentType: 'application/json; charset=utf-8',
                        dataType: 'json',
                        success: function (data) {
                            AndroidProgress(false);
                            if (parseInt(data.d[0]) > 0)
                                window.location.href = 'panel.aspx?eposta=' + $('#email').val() + '&sifre=' + data.d[1].replace("+", "%2B").replace("&", "%41");
                            else
                                window.location.href = 'giris.aspx?hata=hata';
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
    <div class="divana">
    <img src="images/headers/5.png" class="imgheader" />
    <div style="width: 65%; margin: 0 auto;">

    <%--<span class="login100-form-title p-b-15 m-b-15">
		                    <img src="images/kenton.png" alt="Kenton" style="width: 200px" />
	                    </span>--%>
	<div class="wrap-input100 validate-input" data-validate="Geçerli eposta: a@b.c">
		<input class="input100" type="text" name="email" runat="server" id="email" autocomplete="off" clientidmode="Static" />
		<span class="focus-input100" data-placeholder="E-posta"></span>
	</div>

	<div class="wrap-input100 validate-input" data-validate="Şifre giriniz">
		<span class="btn-show-pass">
			<i class="fa fa-eye"></i>
		</span>
		<input class="input100" type="password" name="pass" runat="server" id="pass1" autocomplete="off" clientidmode="Static" />
		<span class="focus-input100" data-placeholder="Şifre"></span>
	</div>

<%--	<div class="container-login100-form-btn" style="padding-top: 0px">
		<div class="wrap-login100-form-btn">
			<div class="login100-form-bgbtn"></div>
			<button id="girisyap" class="login100-form-btn">GİRİŞ YAP</button>
		</div>
	</div>--%>
    <div class="container-login100-form-btn1" onclick="GirisYap()">
		<div class="wrap-login100-form-btn1">
			<div class="login100-form-bgbtn1"></div>
			<a href="#" class="login100-form-btn1">GİRİŞ YAP</a>
		</div>
	</div>
    <br />
	<div class="container-login100-form-btn1" onclick="window.location.href = 'uyeol.aspx'">
		<div class="wrap-login100-form-btn1">
			<div class="login100-form-bgbtn1"></div>
			<a href="#" class="login100-form-btn1">ÜYE OL</a>
		</div>
	</div>
    <br />
	<span id="hata" class="login100-form-title" style="font-size: 14px; color: lightcoral"></span>
    <br />
			<center><a href="sifre.aspx" style="font-size: 14px;">Şifremi unuttum</a></center>

    <%--<span class="p-t-25 m-t-25" style="display: block; text-align: center; font-size: 14px">
		                    Tibet A.Ş. 2018 © Tüm hakları saklıdır.
	                    </span><br /><br />--%>
    </div>
        </div>
</asp:Content>

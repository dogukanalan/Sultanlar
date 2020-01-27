<%@ Page Title="" Language="C#" MasterPageFile="~/kenton/Site1.Master" AutoEventWireup="true"
    CodeBehind="uyeol.aspx.cs" Inherits="Sultanlar.WebUI.kenton.uyeol" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="divana">
    <div style="width: 65%; margin: 0 auto;">
    <img src="images/headers/5.png" class="imgheader" />
    <div class="wrap-input100 validate-input" data-validate="İsim boş olmamalı">
        <input class="input100" type="text" name="isim" runat="server" id="isim" clientidmode="Static" autocomplete="off" />
        <span class="focus-input100" data-placeholder="İsim"></span>
    </div>
    <div class="wrap-input100 validate-input" data-validate="Soyisim boş olmamalı">
        <input class="input100" type="text" name="soyisim" runat="server" id="soyisim" clientidmode="Static" autocomplete="off" />
        <span class="focus-input100" data-placeholder="Soyisim"></span>
    </div>
    <div class="wrap-input100" data-validate="Doğum tarihi boş olmamalı">
        <input class="input100" type="text" name="dogum" runat="server" id="dogum" clientidmode="Static" autocomplete="off" />
        <span class="focus-input100" data-placeholder="Doğum Tarihi (01/01/1990)"></span>
    </div>
    <div class="wrap-input100 validate-input" data-validate="Geçerli eposta: a@b.c">
        <input class="input100" type="text" name="email" runat="server" id="email" clientidmode="Static" autocomplete="off" />
        <span class="focus-input100" data-placeholder="E-posta"></span>
    </div>
    <div class="wrap-input100 validate-input" data-validate="Şifre giriniz">
        <span class="btn-show-pass"><i class="zmdi zmdi-eye"></i></span>
        <input class="input100" type="password" name="pass" runat="server" id="pass1" clientidmode="Static" />
        <span class="focus-input100" data-placeholder="Şifre"></span>
    </div>
    <div class="wrap-input100 validate-input" data-validate="Şifreyi tekrar giriniz">
        <span class="btn-show-pass"><i class="zmdi zmdi-eye"></i></span>
        <input class="input100" type="password" name="pass" runat="server" id="pass2" clientidmode="Static" />
        <span class="focus-input100" data-placeholder="Şifre tekrarı"></span>
    </div>
    <div class="container-login100-form-btn1">
        <div class="wrap-login100-form-btn1">
            <div class="login100-form-bgbtn1">
            </div>
            <!--<button id="yorumgonder" class="login100-form-btn1">ÜYE OL</button>-->
			<a href="javascript:UyeOll()" class="login100-form-btn1" style="color: white">ÜYE OL</a>
        </div>
    </div>
	<br><br>
    <script type="text/javascript">
        //$("#dogum").datepicker({ onSelect: function (date) {
        //    $("#dogum").addClass('has-val');
        //}, changeMonth: true, changeYear: true, dateFormat: 'dd/mm/yy'
        //});
        //$(".ui-datepicker").css('font-size', 12);

        //        $("button").click(function () {
        //            $.ajax({
        //                type: 'POST',
        //                url: 'uyeol.aspx/UyeOl',
        //                data: '{ isim: "' + $('#isim').val() + '", soyisim: "' + $('#soyisim').val() + '", email: "' + $('#email').val() + '", sifre: "' + $('#pass1').val() + '", dogum: "' + $('#dogum').val() + '" }',
        //                contentType: 'application/json; charset=utf-8',
        //                dataType: 'json',
        //                success: function (data) {
        //                    window.location.href = 'anasayfa.aspx?eposta=' + $('#email').val() + '&sifre=' + data.d;
        //                },
        //                error: function (XMLHttpRequest, textStatus, errorThrown) {
        //                    alert(XMLHttpRequest.responseText);
        //                }
        //            });
        //        });
		function UyeOll() {
			AndroidProgress(true);
                $.ajax(
                    {
                        type: 'POST',
                        url: 'uyeol.aspx/UyeOl',
                        data: '{ isim: "' + $('#isim').val() + '", soyisim: "' + $('#soyisim').val() + '", email: "' + $('#email').val() + '", sifre: "' + $('#pass1').val() + '", dogum: "' + $('#dogum').val() + '" }',
                        contentType: 'application/json; charset=utf-8',
                        dataType: 'json',
                        success: function (data) {
                            AndroidProgress(false);
                            if (data.d == "dogumhata")
                                AndroidToast("Dogum tarihini hatali girdiniz.");
                            else if (data.d == "epostahata")
								AndroidToast("Bu eposta ile daha once kayit yapilmis.");
                            else
							{
								AndroidToast("Uyelik basarili, giris ekranina yonlendiriliyorsunuz.");
								document.location.href = 'uyelik.aspx?eposta=' + $('#email').val() + '&sifre=' + data.d;
							}
                        },
                        error: function (data) {
                            AndroidProgress(false);
							AndroidToast("hata olustu: " + JSON.stringify(data));
                        }
                    });
		}
    </script>
        </div>
        </div>
</asp:Content>

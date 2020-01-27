<%@ Page Title="" Language="C#" MasterPageFile="~/kenton/Site1.Master" AutoEventWireup="true" CodeBehind="uyelik.aspx.cs" Inherits="Sultanlar.WebUI.kenton.uyelik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="divana">
    <div style="width: 65%; margin: 0 auto;">
    <img src="images/headers/5.png" class="imgheader" />
    <div class="wrap-input100 validate-input" data-validate="İsim boş olmamalı">
        <input class="input100" type="text" name="isim" runat="server" id="isim" autocomplete="off" clientidmode="Static" />
        <span class="focus-input100" data-placeholder="İsim"></span>
    </div>
    <div class="wrap-input100 validate-input" data-validate="Soyisim boş olmamalı">
        <input class="input100" type="text" name="soyisim" runat="server" id="soyisim" autocomplete="off" clientidmode="Static" />
        <span class="focus-input100" data-placeholder="Soyisim"></span>
    </div>
    <div class="wrap-input100 validate-input" data-validate="Doğum tarihi boş olmamalı">
        <input class="input100" type="text" name="dogum" runat="server" id="dogum" clientidmode="Static"
            onkeypress="return yazma(event)" />
        <span class="focus-input100" data-placeholder="Doğum Tarihi"></span>
    </div>
    <div class="wrap-input100 validate-input" data-validate="Geçerli eposta: a@b.c">
        <input class="input100" type="text" name="email" runat="server" id="email" clientidmode="Static" disabled />
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
            <button id="yorumgonder" class="login100-form-btn1">GÜNCELLE</button>
        </div>
    </div>
        <br /><br />
    <input type="hidden" runat="server" id="uyeid" value="0" clientidmode="Static" />
    <script type="text/javascript">
        $("#dogum").datepicker({ onSelect: function (date) {
            $("#dogum").addClass('has-val');
        }, changeMonth: true, changeYear: true, dateFormat: 'dd/mm/yy'
        });
    $(".ui-datepicker").css('font-size', 12);
    </script>
        </div>
        </div>
</asp:Content>

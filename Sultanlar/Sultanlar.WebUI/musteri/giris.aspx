<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="giris.aspx.cs" Inherits="Sultanlar.WebUI.musteri.giris" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Sultanlar : Üye Girişi</title>
    <meta name="description" content="Sultanlar Ev ihtiyaç Maddeleri Pazarlama A.Ş. bünyesinde bir çok ticari ve sınai kuruluşları bulunduran Sultanlar Şirketler Grubu içerisinde yer almaktadır." />
    <meta name="keywords" content="sultanlar a.ş., sultanlar grup, happy family, bulgurium, johnson wax, scj, tibet, henkel, türk Henkel kimya, vileda, fhp, st grup, korozo, aktif kozmetik, sultanlar grup, arımama, sultanlar" />        <script type="text/javascript" src="js/jquery-1.2.6.pack.js"></script>
    <script type="text/javascript" src="js/jquery-1.8.3.js"></script>
    <script type="text/javascript" src="js/jquery-ui.js"></script>
    <link rel="stylesheet" href="js/jquery-ui.css" />

    <script type="text/javascript">

        $(function () {
            $("#s_container").hover(function () {
                $("img", this).stop().animate({ opacity: .4 }, { queue: false, duration: 300 });
            }, function () {
                $("img", this).stop().animate({ opacity: 1 }, { queue: false, duration: 300 });
            });
        });


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

        var girisacik = true;

        function kaydir() {
            if(girisacik){gizle();girisacik=false;}else{goster();girisacik=true;}
        }

        function gizle() {
            $(function () {
                $("#kompile").draggable();
                $("#divGiris").hide("blind", { easing: "easeOutExpo" }, 1500, callback);
                function callback() { };
            });
        }

        function goster() {
            $(function () {
                $("#kompile").draggable("destroy");
                $("#divGiris").show("blind", { easing: "easeOutExpo" }, 1500, callback);
                function callback() { };
            });
        }

        function gizleilk() {
            $(function () {
                $("#divGiris").hide("blind", { easing: "easeOutExpo" }, 1, callback);
                function callback() { };
            });

            document.getElementById('divGiris').style.display = "block";
        }

        function gosterilk() {
            $(function () {
                $("#divGiris").delay(500).show("blind", { easing: "easeOutExpo" }, 1500, callback);
                function callback() { };
            });
        }
    </script>
    <style type="text/css">
input[type=checkbox],
          input[type=radio] {
          -webkit-appearance: none;
          appearance: none;
          width: 13px;
          height: 13px;
          margin: 0;
          cursor: pointer;
          vertical-align: bottom;
          background: #fff;
          border: 1px solid #dcdcdc;
          -webkit-border-radius: 1px;
          -moz-border-radius: 1px;
          border-radius: 1px;
          -webkit-box-sizing: border-box;
          -moz-box-sizing: border-box;
          box-sizing: border-box;
          position: relative;
          }
          input[type=checkbox]:active,
          input[type=radio]:active {
          border-color: #c6c6c6;
          background: #ebebeb;
          }
          input[type=checkbox]:hover {
          border-color: #c6c6c6;
          -webkit-box-shadow: inset 0 1px 1px rgba(0,0,0,0.1);
          -moz-box-shadow: inset 0 1px 1px rgba(0,0,0,0.1);
          box-shadow: inset 0 1px 1px rgba(0,0,0,0.1);
          }
          input[type=radio] {
          -webkit-border-radius: 1em;
          -moz-border-radius: 1em;
          border-radius: 1em;
          width: 15px;
          height: 15px;
          }
          input[type=checkbox]:checked,
          input[type=radio]:checked {
          background: #fff;
          }
          input[type=radio]:checked::after {
          content: '';
          display: block;
          position: relative;
          top: 3px;
          left: 3px;
          width: 7px;
          height: 7px;
          background: #666;
          -webkit-border-radius: 1em;
          -moz-border-radius: 1em;
          border-radius: 1em;
          }
          input[type=checkbox]:checked::after {
          content: url(img/checkmark.png);
          display: block;
          position: absolute;
          top: -3px;
          left: -2px;
          }
          input[type=checkbox]:focus {
          outline: none;
          border-color:#4d90fe;
          }
        
          .sul-button {
          display: inline-block;
          min-width: 46px;
          text-align: center;
          color: #444;
          font-size: 11px;
          font-weight: bold;
          height: 27px;
          padding: 0 8px;
          line-height: 27px;
          -webkit-border-radius: 2px;
          -moz-border-radius: 2px;
          border-radius: 2px;
          -webkit-transition: all 0.218s;
          -moz-transition: all 0.218s;
          -ms-transition: all 0.218s;
          -o-transition: all 0.218s;
          transition: all 0.218s;
          border: 1px solid #dcdcdc;
          background-color: #f5f5f5;
          background-image: -webkit-gradient(linear,left top,left bottom,from(#f5f5f5),to(#f1f1f1));
          background-image: -webkit-linear-gradient(top,#f5f5f5,#f1f1f1);
          background-image: -moz-linear-gradient(top,#f5f5f5,#f1f1f1);
          background-image: -ms-linear-gradient(top,#f5f5f5,#f1f1f1);
          background-image: -o-linear-gradient(top,#f5f5f5,#f1f1f1);
          background-image: linear-gradient(top,#f5f5f5,#f1f1f1);
          -webkit-user-select: none;
          -moz-user-select: none;
          user-select: none;
          cursor: default;
          }

          *+html .sul-button {
          min-width: 70px;
          }
          button.sul-button,
          input[type=submit].sul-button {
          height: 29px;
          line-height: 29px;
          vertical-align: bottom;
          margin: 0;
          }
          *+html button.sul-button,
          *+html input[type=submit].sul-button {
          overflow: visible;
          }
          .sul-button:hover {
          border: 1px solid #c6c6c6;
          color: #333;
          text-decoration: none;
          -webkit-transition: all 0.0s;
          -moz-transition: all 0.0s;
          -ms-transition: all 0.0s;
          -o-transition: all 0.0s;
          transition: all 0.0s;
          background-color: #f8f8f8;
          background-image: -webkit-gradient(linear,left top,left bottom,from(#f8f8f8),to(#f1f1f1));
          background-image: -webkit-linear-gradient(top,#f8f8f8,#f1f1f1);
          background-image: -moz-linear-gradient(top,#f8f8f8,#f1f1f1);
          background-image: -ms-linear-gradient(top,#f8f8f8,#f1f1f1);
          background-image: -o-linear-gradient(top,#f8f8f8,#f1f1f1);
          background-image: linear-gradient(top,#f8f8f8,#f1f1f1);
          -webkit-box-shadow: 0 1px 1px rgba(0,0,0,0.1);
          -moz-box-shadow: 0 1px 1px rgba(0,0,0,0.1);
          box-shadow: 0 1px 1px rgba(0,0,0,0.1);
          }
          .sul-button:active {
          background-color: #f6f6f6;
          background-image: -webkit-gradient(linear,left top,left bottom,from(#f6f6f6),to(#f1f1f1));
          background-image: -webkit-linear-gradient(top,#f6f6f6,#f1f1f1);
          background-image: -moz-linear-gradient(top,#f6f6f6,#f1f1f1);
          background-image: -ms-linear-gradient(top,#f6f6f6,#f1f1f1);
          background-image: -o-linear-gradient(top,#f6f6f6,#f1f1f1);
          background-image: linear-gradient(top,#f6f6f6,#f1f1f1);
          -webkit-box-shadow: inset 0 1px 2px rgba(0,0,0,0.1);
          -moz-box-shadow: inset 0 1px 2px rgba(0,0,0,0.1);
          box-shadow: inset 0 1px 2px rgba(0,0,0,0.1);
          }
          .sul-button:visited {
          color: #666;
          }
          .sul-button-submit {
          cursor:pointer;
          border: 1px solid #3079ed;
          color: #fff;
          text-shadow: 0 1px rgba(0,0,0,0.1);
          background-color: #4d90fe;
          background-image: -webkit-gradient(linear,left top,left bottom,from(#4d90fe),to(#4787ed));
          background-image: -webkit-linear-gradient(top,#4d90fe,#4787ed);
          background-image: -moz-linear-gradient(top,#4d90fe,#4787ed);
          background-image: -ms-linear-gradient(top,#4d90fe,#4787ed);
          background-image: -o-linear-gradient(top,#4d90fe,#4787ed);
          background-image: linear-gradient(top,#4d90fe,#4787ed);
          }
          .sul-button-submit:hover {
          border: 1px solid #2f5bb7;
          color: #fff;
          text-shadow: 0 1px rgba(0,0,0,0.3);
          background-color: #357ae8;
          background-image: -webkit-gradient(linear,left top,left bottom,from(#4d90fe),to(#357ae8));
          background-image: -webkit-linear-gradient(top,#4d90fe,#357ae8);
          background-image: -moz-linear-gradient(top,#4d90fe,#357ae8);
          background-image: -ms-linear-gradient(top,#4d90fe,#357ae8);
          background-image: -o-linear-gradient(top,#4d90fe,#357ae8);
          background-image: linear-gradient(top,#4d90fe,#357ae8);
          }
          .sul-button-submit:active {
          background-color: #357ae8;
          background-image: -webkit-gradient(linear,left top,left bottom,from(#4d90fe),to(#357ae8));
          background-image: -webkit-linear-gradient(top,#4d90fe,#357ae8);
          background-image: -moz-linear-gradient(top,#4d90fe,#357ae8);
          background-image: -ms-linear-gradient(top,#4d90fe,#357ae8);
          background-image: -o-linear-gradient(top,#4d90fe,#357ae8);
          background-image: linear-gradient(top,#4d90fe,#357ae8);
          -webkit-box-shadow: inset 0 1px 2px rgb	a(0,0,0,0.3);
          -moz-box-shadow: inset 0 1px 2px rgba(0,0,0,0.3);
          box-shadow: inset 0 1px 2px rgba(0,0,0,0.3);
          }
          .sul-button-share {
          border: 1px solid #29691d;
          color: #fff;
          text-shadow: 0 1px rgba(0,0,0,0.1);
          background-color: #3d9400;
          background-image: -webkit-gradient(linear,left top,left bottom,from(#3d9400),to(#398a00));
          background-image: -webkit-linear-gradient(top,#3d9400,#398a00);
          background-image: -moz-linear-gradient(top,#3d9400,#398a00);
          background-image: -ms-linear-gradient(top,#3d9400,#398a00);
          background-image: -o-linear-gradient(top,#3d9400,#398a00);
          background-image: linear-gradient(top,#3d9400,#398a00);
          }
          .sul-button-share:hover {
          border: 1px solid #2d6200;
          color: #fff;
          text-shadow: 0 1px rgba(0,0,0,0.3);
          background-color: #368200;
          background-image: -webkit-gradient(linear,left top,left bottom,from(#3d9400),to(#368200));
          background-image: -webkit-linear-gradient(top,#3d9400,#368200);
          background-image: -moz-linear-gradient(top,#3d9400,#368200);
          background-image: -ms-linear-gradient(top,#3d9400,#368200);
          background-image: -o-linear-gradient(top,#3d9400,#368200);
          background-image: linear-gradient(top,#3d9400,#368200);
          }
          .sul-button-share:active {
          -webkit-box-shadow: inset 0 1px 2px rgba(0,0,0,0.3);
          -moz-box-shadow: inset 0 1px 2px rgba(0,0,0,0.3);
          box-shadow: inset 0 1px 2px rgba(0,0,0,0.3);
          }
          .sul-button-red {
          cursor:pointer;
          border: 1px solid transparent;
          color: #fff;
          text-shadow: 0 1px rgba(0,0,0,0.1);
          background-color: #d14836;
          background-image: -webkit-gradient(linear,left top,left bottom,from(#dd4b39),to(#d14836));
          background-image: -webkit-linear-gradient(top,#dd4b39,#d14836);
          background-image: -moz-linear-gradient(top,#dd4b39,#d14836);
          background-image: -ms-linear-gradient(top,#dd4b39,#d14836);
          background-image: -o-linear-gradient(top,#dd4b39,#d14836);
          background-image: linear-gradient(top,#dd4b39,#d14836);
          }
          .sul-button-red:hover {
          border: 1px solid #b0281a;
          color: #fff;
          text-shadow: 0 1px rgba(0,0,0,0.3);
          background-color: #c53727;
          background-image: -webkit-gradient(linear,left top,left bottom,from(#dd4b39),to(#c53727));
          background-image: -webkit-linear-gradient(top,#dd4b39,#c53727);
          background-image: -moz-linear-gradient(top,#dd4b39,#c53727);
          background-image: -ms-linear-gradient(top,#dd4b39,#c53727);
          background-image: -o-linear-gradient(top,#dd4b39,#c53727);
          background-image: linear-gradient(top,#dd4b39,#c53727);
          -webkit-box-shadow: 0 1px 1px rgba(0,0,0,0.2);
          -moz-box-shadow: 0 1px 1px rgba(0,0,0,0.2);
          -ms-box-shadow: 0 1px 1px rgba(0,0,0,0.2);
          -o-box-shadow: 0 1px 1px rgba(0,0,0,0.2);
          box-shadow: 0 1px 1px rgba(0,0,0,0.2);
          }
          .sul-button-red:active {
          border: 1px solid #992a1b;
          background-color: #b0281a;
          background-image: -webkit-gradient(linear,left top,left bottom,from(#dd4b39),to(#b0281a));
          background-image: -webkit-linear-gradient(top,#dd4b39,#b0281a);
          background-image: -moz-linear-gradient(top,#dd4b39,#b0281a);
          background-image: -ms-linear-gradient(top,#dd4b39,#b0281a);
          background-image: -o-linear-gradient(top,#dd4b39,#b0281a);
          background-image: linear-gradient(top,#dd4b39,#b0281a);
          -webkit-box-shadow: inset 0 1px 2px rgba(0,0,0,0.3);
          -moz-box-shadow: inset 0 1px 2px rgba(0,0,0,0.3);
          box-shadow: inset 0 1px 2px rgba(0,0,0,0.3);
          color: #fff
          }
          .sul-button-white {
          border: 1px solid #dcdcdc;
          color: #666;
          background: #fff;
          }
          .sul-button-white:hover {
          border: 1px solid #c6c6c6;
          color: #333;
          background: #fff;
          -webkit-box-shadow: 0 1px 1px rgba(0,0,0,0.1);
          -moz-box-shadow: 0 1px 1px rgba(0,0,0,0.1);
          box-shadow: 0 1px 1px rgba(0,0,0,0.1);
          }
          .sul-button-white:active {
          background: #fff;
          -webkit-box-shadow: inset 0 1px 2px rgba(0,0,0,0.1);
          -moz-box-shadow: inset 0 1px 2px rgba(0,0,0,0.1);
          box-shadow: inset 0 1px 2px rgba(0,0,0,0.1);
          }
          .sul-button-red:visited,
          .sul-button-share:visited,
          .sul-button-submit:visited {
          color: #fff;
          }
          .sul-button-submit:focus,
          .sul-button-share:focus,
          .sul-button-red:focus {
          -webkit-box-shadow: inset 0 0 0 1px #fff;
          -moz-box-shadow: inset 0 0 0 1px #fff;
          box-shadow: inset 0 0 0 1px #fff;
          }
          .sul-button-share:focus {
          border-color: #29691d;
          }
          .sul-button-red:focus {
          border-color: #d14836;
          }
          .sul-button-submit:focus:hover,
          .sul-button-share:focus:hover,
          .sul-button-red:focus:hover {
          -webkit-box-shadow: inset 0 0 0 1px #fff, 0 1px 1px rgba(0,0,0,0.1);
          -moz-box-shadow: inset 0 0 0 1px #fff, 0 1px 1px rgba(0,0,0,0.1);
          box-shadow: inset 0 0 0 1px #fff, 0 1px 1px rgba(0,0,0,0.1);
          }
          .sul-button.selected {
          background-color: #eee;
          background-image: -webkit-gradient(linear,left top,left bottom,from(#eee),to(#e0e0e0));
          background-image: -webkit-linear-gradient(top,#eee,#e0e0e0);
          background-image: -moz-linear-gradient(top,#eee,#e0e0e0);
          background-image: -ms-linear-gradient(top,#eee,#e0e0e0);
          background-image: -o-linear-gradient(top,#eee,#e0e0e0);
          background-image: linear-gradient(top,#eee,#e0e0e0);
          -webkit-box-shadow: inset 0 1px 2px rgba(0,0,0,0.1);
          -moz-box-shadow: inset 0 1px 2px rgba(0,0,0,0.1);
          box-shadow: inset 0 1px 2px rgba(0,0,0,0.1);
          border: 1px solid #ccc;
          color: #333;
          }
          .sul-button img {
          display: inline-block;
          margin: -3px 0 0;
          opacity: .55;
          filter: alpha(opacity=55);
          vertical-align: middle;
          pointer-events: none;
          }
          *+html .sul-button img {
          margin: 4px 0 0;
          }
          .sul-button:hover img {
          opacity: .72;
          filter: alpha(opacity=72);
          }
          .sul-button:active img {
          opacity: 1;
          filter: alpha(opacity=100);
          }
          .sul-button.disabled img {
          opacity: .5;
          filter: alpha(opacity=50);
          }
          .sul-button.disabled,
          .sul-button.disabled:hover,
          .sul-button.disabled:active,
          .sul-button-submit.disabled,
          .sul-button-submit.disabled:hover,
          .sul-button-submit.disabled:active,
          .sul-button-share.disabled,
          .sul-button-share.disabled:hover,
          .sul-button-share.disabled:active,
          .sul-button-red.disabled,
          .sul-button-red.disabled:hover,
          .sul-button-red.disabled:active,
          input[type=submit][disabled].sul-button {
          background-color: none;
          opacity: .5;
          filter: alpha(opacity=50);
          cursor: default;
          pointer-events: none;
          }
          /* google rulez whooooo hoo */
    </style>

    <!--[if IE]>
    <style type="text/css">
          input[type=checkbox],
          input[type=radio] {
          width: 20px;
          height: 20px;
          }
    </style>
    <![endif]-->
    
</head>
<body style="margin: 0 0 0 0; background-color: #EFEEEA;">
    <form id="form1" runat="server" action="giris.html">
    <table cellpadding="0" cellspacing="0" style="width: 100%"><tr>
        <td align="center" 
            style="background-position: center bottom; height: 400px; background-image: url('img/bg-logo.jpg'); background-repeat: no-repeat; background-color: #FFFFFF;" 
            valign="top">
        <asp:Login ID="Login1" runat="server" onauthenticate="Login1_Authenticate" 
            FailureText="Giriş işlemi başarısız oldu. Lütfen tekrar deneyin." 
            LoginButtonText="Giriş" PasswordLabelText="Şifre:" 
            PasswordRequiredErrorMessage="Şifre gereklidir." RememberMeText="Bir gün boyunca bağlı kal" 
            TitleText="Kullanıcı Girişi" UserNameLabelText="Eposta Adresi:" 
            UserNameRequiredErrorMessage="Kullanıcı Adı gereklidir." 
            style="text-align: left" Width="400px">
            <InstructionTextStyle />
            <LayoutTemplate>

                <script type="text/javascript">
                    jQuery(document).ready(function () {
                        gizleilk();
                        gosterilk();
                    });
                </script>

    <div id="kompile" style="width: 400px; margin-top: 28px; border: 1px solid #E5E5E5; background-image: url('img/bg-giris-div.png'); background-repeat: repeat; font-family: Tahoma; border-radius: 5px">
        <table cellpadding="0" cellspacing="0">
            <tr>
                <td style="width: 400px; padding: 20px 20px 20px 20px">
                    <table cellpadding="0" cellspacing="0" style="width: 100%">
                        <tr>
                            <td style="font-size: 17px; color: #26238C; text-align: left; padding-left: 5px">Üye girişi</td>
                            <td align="right" style="padding-right: 5px"><div id="s_container" style="width: 23px"><img src="img/s_sultanlar.png" onclick="kaydir()" style="cursor: pointer;" /></div></td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <div id="divGiris" style="display: none">
        <table cellpadding="0" cellspacing="0">
            <tr>
                <td style="width: 400px; padding: 0px 20px 2px 20px">
                    <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName" style="font-size: 12px; font-weight: bold; color: #515151; padding-left: 3px">Eposta adresi</asp:Label>
                    <asp:RequiredFieldValidator Font-Size="10px" ForeColor="#D34836" ID="UserNameRequired" runat="server" ControlToValidate="UserName" ErrorMessage="Eposta gereklidir" ToolTip="Eposta gereklidir" ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="width: 400px; padding: 0px 36px 0px 20px">
                    
                    <asp:TextBox ID="UserName" runat="server" style="width: 100%; border: 1px solid #E5E5E5; padding: 7px 7px 7px 7px; border-radius: 5px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 400px; padding: 20px 20px 2px 20px">
                    <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password" style="font-size: 12px; font-weight: bold; color: #515151; padding-left: 3px">Şifre</asp:Label>
                    <asp:RequiredFieldValidator Font-Size="10px" ForeColor="#D34836" ID="PasswordRequired" runat="server" ControlToValidate="Password" ErrorMessage="Şifre gereklidir" ToolTip="Şifre gereklidir" ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="width: 400px; padding: 0px 36px 0px 20px">
                    <asp:TextBox ID="Password" runat="server" 
                        style="width: 100%; border: 1px solid #E5E5E5; padding: 7px 7px 7px 7px; border-radius: 5px" 
                        TextMode="Password"></asp:TextBox>
                    <div style="font-family: Tahoma; font-size: 12px; color: #D34836; padding-top: 10px; padding-bottom: 10px"><asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal></div>
                </td>
            </tr>
            <tr>
                <td style="width: 400px; padding: 0px 20px 20px 20px">
                    <table cellpadding="0" cellspacing="0" style="width: 100%; padding-left: 3px">
                        <tr>
                            <td style="text-align: left">
                                <asp:CheckBox ID="RememberMe" runat="server" Text=" Bir gün boyunca bağlı kal" style="font-size: 12px; color: #666666" />
                                <%--<asp:CheckBox ID="cbNST" runat="server" Text=" NST" style="font-size: 12px; color: #666666" />--%>
                            </td>
                            <td style="text-align: right">
                                <asp:Button class="sul-button sul-button-submit" ID="LoginButton" runat="server"
                                    style="border: solid 1px #3179ED; background-color: #4E8FFD; color: #FFFFFF; font-weight: bold; width: 100px; height: 30px; border-radius: 5px"
                                    CommandName="Login" Text="Oturum aç" ValidationGroup="Login1" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="width: 400px; padding: 0px 20px 20px 20px">
                    <table cellpadding="0" cellspacing="0" style="width: 100%; border-top: 1px solid #E5E5E5">
                        <tr>
                            <td style="text-align: left; padding-top: 20px">
                                <asp:Button class="sul-button sul-button-submit" runat="server" style="border: solid 1px #3179ED; background-color: #4E8FFD; color: #FFFFFF; font-weight: bold; width: 65px; height: 30px; border-radius: 5px"
                                    onclick="Button3_Click" OnClientClick="gizle()"
                                    Text="Yardım" />
                            </td>
                            <td style="text-align: center; padding-top: 20px">
                                <asp:Button class="sul-button sul-button-submit" runat="server" style="border: solid 1px #3179ED; background-color: #4E8FFD; color: #FFFFFF; font-weight: bold; width: 135px; height: 30px; border-radius: 5px"
                                    onclick="Button2_Click" OnClientClick="gizle()"
                                    Text="Şifre sıfırlama" />
                            </td>
                            <td style="text-align: right; padding-top: 20px">
                                <asp:Button class="sul-button sul-button-red" runat="server" style="border: solid 1px #D34836; background-color: #DD4B39; color: #FFFFFF; font-weight: bold; width: 135px; height: 30px; border-radius: 5px"
                                    onclick="Button1_Click" OnClientClick="gizle()"
                                    Text="Yeni üye kaydı" />
                            </td>
                        </tr>
                    </table>
                    
                </td>
            </tr>
        </table>
        </div>
    </div>
            </LayoutTemplate>
        </asp:Login>
        </td></tr></table>

        <div style="background-color: #EFEEEA; height: 100px; padding: 10px; border-top: 1px solid #FFCFB2">
            <img src="img/logo.png" alt="" style="padding: 0 20px 0 10px; cursor: pointer" onclick="window.location.href='http://www.sultanlar.com.tr'" />
            <img src="img/ssl.gif" alt="" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <img src="img/logoSAP.png" alt="" style="padding-bottom: 7px" />
            <div style="margin-top: 5px; width: 100%; text-align: center; font-family: Tahoma;
                font-size: 12px; color: #808080">
                Copyright © 2011-2021 Sultanlar Pazarlama A.Ş. Tüm hakları saklıdır.
                <br />
                Sitede yer alan resim, yazı ve içerikler kaynak gösterilerek dahi olsa kopyalanamaz.
            </div>
        </div>

        <script type="text/javascript">
            var expires = "";
            var days = -1;
            if (days) {
                var date = new Date();
                date.setTime(date.getTime() + (days * 24 * 60 * 60 * 1000));
                expires = "; expires=" + date.toUTCString();
            }
            document.cookie = "sulSatTemLogD=" + expires + "; path=/";
            document.cookie = "sulSatTemLog1=" + expires + "; path=/";
            document.cookie = "sulSatTemLog=" + expires + "; path=/";
            document.cookie = "sulSatTemLogS=" + expires + "; path=/";
        </script>

    </form>
</body>
</html>

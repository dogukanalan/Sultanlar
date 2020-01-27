<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="katalog.aspx.cs" Inherits="Sultanlar.WebUI.musteri.katalog" %>

<%@ Register src="ucProgress.ascx" tagname="ucProgress" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Sultanlar : Katalog</title>
    <meta name="keywords" content="katalog, insert, brosur, ürün, resim, resimler, ürün resimleri, ürün resmi, ürün katalogu, ürün kataloğu, ürün brosuru, insört, sultanlar a.ş., sultanlar grup, happy family, bulgurium, tibet, henkel, türk Henkel kimya, vileda, fhp, st grup, korozo, aktif kozmetik, sultanlar grup, arı, arımama, sultanlar" />
    <link rel="stylesheet" type="text/css" href="StyleSheet.css" />
    <script type="text/javascript">
        var buyukluk = "";
        if (navigator.appName.indexOf("Internet Explorer") > 0) {
            buyukluk = "850px";
        }
        else {
            buyukluk = "480px";
        }

        function Buyut() {
            goster();
            //document.getElementById('fieldsetTed').style.height = '1250px';

            document.getElementById('aBuyut').style.display = 'none';
            document.getElementById('aKucult').style.display = 'inline';
        }
        function Kucult() {
            gizle();
            //document.getElementById('fieldsetTed').style.height = '96px';

            document.getElementById('aKucult').style.display = 'none';
            document.getElementById('aBuyut').style.display = 'inline';
        }

        function gizle() {
            $("#divTed").animate({
                height: "66px"
            }, 1500);
        }

        function goster() {
            $("#divTed").animate({
                height: buyukluk
            }, 1500);
        }

        function Checkboxes(value) {
            var elm = document.getElementById("cblTedarikciler");
            var checkBoxes = elm.getElementsByTagName("input");
            for (i = 0; i < checkBoxes.length; i++) {
                checkBoxes[i].checked = value;
            }
        }
    </script>
    <script type="text/javascript" src="js/jquery-1.2.6.pack.js"></script>
    <script type="text/javascript" src="js/jquery-1.8.3.js"></script>
    <script type="text/javascript" src="js/jquery-ui.js"></script>
    <link rel="stylesheet" href="js/jquery-ui.css" />

    <![if !IE]>
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
          top: -6px;
          left: -5px;
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
    <![endif]>

    <script type="text/javascript" src="js/jquery.tipTip.js"></script>
    <script type="text/javascript" src="js/jquery.tipTip.minified.js"></script>
    <link rel="stylesheet" type="text/css" href="js/tipTip.css" />
</head>
<body style="font-family: Tahoma; font-size: 10px; background-color: #FFFFFF; text-shadow: #C0C0C0 0px 1px 0px;">
    <form id="form1" runat="server" action="katalog.html">
    <asp:ScriptManager ID="AjaxScripts" runat="server" AsyncPostBackTimeout="500">
    </asp:ScriptManager>
    <script type="text/javascript">
        Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(function (evt, args) {
            //$("#divTed").resizable();
        });
    </script>
    <asp:UpdateProgress ID="DivAjaxProg" runat="server">
        <ProgressTemplate>
            <uc1:ucProgress ID="ucProgress1" runat="server" />
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdatePanel ID="DivAjax" runat="server">
    <ContentTemplate>
    <asp:Label runat="server" ID="lblHistoryData" />
    <fieldset id="fieldsetTed" style="border: 1px solid #CCCCCC; border-radius: 5px; padding: 5px; width: 900px;">
    <legend style="font-size: 13px; font-family: Gisha; font-weight: bold; color: #EE7A0B"> S ü z m e &nbsp;&nbsp;&nbsp; S e ç e n e k l e r i </legend>
                <div id="divTed" style="overflow: hidden; width: 900px; height: 66px; background-color: #FFFFFF; resize: vertical;
                    min-width: 900px; max-width: 900px; min-height: 66px; max-height: 1490px;">
                    <table cellpadding="0" cellspacing="0" border="0" style="width: 900px;">
                        <tr>
                            <td style="text-align: left;">
                                    <asp:CheckBoxList runat="server" ID="cblTedarikciler" RepeatColumns="5" RepeatDirection="Horizontal"
                                        CellPadding="3"></asp:CheckBoxList>
                            </td>
                        </tr>
                    </table>
                </div>
                <div style="width: 900px; height: 20px; font-size: 12px; padding-top: 3px">
                <table cellpadding="0" cellspacing="0" style="width:900px;">
                <tr>
                <td align="left"><a href="javascript:window.history.back()" class="hotspot">Geri dön</a></td>
                <td align="right">
                <span onclick="Buyut()" id="aBuyut" class="hotspot">Listeyi büyüt</span>
                <span onclick="Kucult()" id="aKucult" style="display: none" class="hotspot">Listeyi küçült</span>
                <asp:Label  runat="server" Width="200px"></asp:Label>
                <span onclick="Checkboxes(false)" class="hotspot">Seçimi Temizle</span>
                <%--<asp:LinkButton runat="server" ID="lbTedarikciSifirla" Text="Seçimi Temizle" OnClick="lbTedarikciSifirla_Click"></asp:LinkButton>--%>
                &nbsp;
                <span onclick="Checkboxes(true)" class="hotspot">Tümünü Seç</span>
                <%--<asp:LinkButton runat="server" ID="lbTedarikciTumu" Text="Tümünü Seç" OnClick="lbTedarikciTumu_Click"></asp:LinkButton>--%>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:LinkButton runat="server" ID="lbUygula" Text="Uygula" OnClick="lbUygula_Click" class="hotspot"></asp:LinkButton>
                </td>
                </tr>
                </table>
                </div>
    </fieldset>
    <table cellpadding="0" cellspacing="0" border="0" style="width: 916px; height: 36px">
        <tr>
            <td style="text-align: left; padding-bottom: 2px; padding-top: 5px" valign="middle">
                <asp:Button ID="lbOnceki2" runat="server" onclick="lbOnceki_Click" Text="Önceki Sayfa" Width="150px" 
                    class="sul-button sul-button-red" />
                <asp:Label runat="server" ID="lblOnceki2" Width="150px" Visible="false"></asp:Label>
            </td>
            <td style="text-align: center; padding-bottom: 2px; padding-top: 5px; color: Red; font-size: 12px" valign="middle">
                <asp:Label runat="server" ID="lblUrunKacinci2" Text="0"></asp:Label> / <asp:Label runat="server" ID="lblUrunSayisi2" Text="0"></asp:Label>
            </td>
            <td style="text-align: right; padding-bottom: 2px; padding-top: 5px" valign="middle">
                <asp:Button ID="lbSonraki2" runat="server" onclick="lbSonraki_Click" Text="Sonraki Sayfa" Width="150px" 
                    class="sul-button sul-button-red" />
                <asp:Label runat="server" ID="lblSonraki2" Width="150px" Visible="false"></asp:Label>
            </td>
        </tr>
    </table>
    <asp:DataList ID="dlResimli" runat="server" RepeatDirection="Horizontal" RepeatColumns="3">
        <ItemTemplate>
            <table cellpadding="0" cellspacing="0" style="width: 300px; height: 300px; border: 1px solid #bfbfbf;
                margin: 2px;border-radius: 5px; padding: 5px;">
                <tr>
                    <td colspan="2" style="border-bottom: 1px solid #bfbfbf; height: 105px">
                        <table>
                            <tr>
                                <td style="width: 275px; height: 235px; background-color: #FFFFFF" align="center" rowspan="3">
                                    <asp:Image style="max-width: 210px; max-height: 210px" runat="server" ImageUrl='<%# Eval("pkResimID", "resim.aspx?uidO={0}")%>' />
                                </td>
                                <td style="width: 25px; height: 30px; border-left: 1px solid #bfbfbf;"
                                    valign="middle" align="center">
                                    <asp:Image runat="server" ToolTip="Yeni Ürün" ImageUrl="img/yeni.png" Visible='<%#Convert.ToBoolean(Convert.ToInt32(Eval("KYTM")) < 16)%>' class="kucukbilgiGoster" />
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 25px; border-left: 1px solid #bfbfbf; border-top: 1px solid #bfbfbf; color: Gray"
                                    valign="middle" align="center">
                                    K<br />
                                    O<br />
                                    L<br />
                                    İ<br />
                                    <br />
                                    İ<br />
                                    Ç<br />
                                    İ<br />
                                    <br />
                                    A<br />
                                    D<br />
                                    E<br />
                                    T<br />
                                    <br />
                                    <span style="color: #000000"><%#Eval("Adet") %></span>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 25px; height: 25px; border-left: 1px solid #bfbfbf; border-top: 1px solid #bfbfbf;"
                                    valign="middle" align="center">
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="2" style="border-bottom: 1px solid #bfbfbf; height: 30px;">
                        <input type="hidden" value='<%#Eval("pkResimID") %>' id="ResimID" runat="server" />
                        <input type="hidden" value='<%#Eval("UrunID") %>' id="UrunID" runat="server" />
                        <span style="font-size: 11px"><%# Eval("Ad") %></span>
                    </td>
                </tr>
                <tr>
                    <td align="center" style="border-right: 1px solid #bfbfbf; color: #EE7A0B; min-width: 138px; height: 30px">
                        <input type="hidden" value='<%#Eval("TedarikciAdi") %>' id="TedarikciAdi" runat="server" />
                        <input type="hidden" value='<%#Eval("TedarikciID") %>' id="TedarikciID" runat="server" />
                        <%# Eval("TedarikciAdi") %>
                    </td>
                    <td align="center" style="color: #26237A; min-width: 138px;">
                        <input type="hidden" value='<%#Eval("KategoriAdi") %>' id="KategoriAdi" runat="server" />
                        <input type="hidden" value='<%#Eval("KategoriID") %>' id="KategoriID" runat="server" />
                        <%# Eval("KategoriAdi") %>
                    </td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:DataList>
    <table cellpadding="0" cellspacing="0" border="0" style="width: 916px; height: 36px">
        <tr>
            <td style="text-align: left; padding-bottom: 2px" valign="middle">
                <asp:Button ID="lbOnceki" runat="server" onclick="lbOnceki_Click" Text="Önceki Sayfa" Width="150px" 
                    class="sul-button sul-button-red" />
                <asp:Label runat="server" ID="lblOnceki" Width="150px" Visible="false"></asp:Label>
            </td>
            <td style="text-align: center; padding-bottom: 2px; color: Red; font-size: 12px" valign="middle">
                <asp:Label runat="server" ID="lblUrunKacinci" Text="0"></asp:Label> / <asp:Label runat="server" ID="lblUrunSayisi" Text="0"></asp:Label>
            </td>
            <td style="text-align: right; padding-bottom: 2px" valign="middle">
                <asp:Button ID="lbSonraki" runat="server" onclick="lbSonraki_Click" Text="Sonraki Sayfa" Width="150px" 
                    class="sul-button sul-button-red" />
                <asp:Label runat="server" ID="lblSonraki" Width="150px" Visible="false"></asp:Label>
            </td>
        </tr>
    </table>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>

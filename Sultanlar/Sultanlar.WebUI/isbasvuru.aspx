<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="isbasvuru.aspx.cs" Inherits="Sultanlar.WebUI.isbasvuru" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>Sultanlar Ev İhtiyaç Malzemeleri Pazarlama A.Ş.</title>
    <meta name="robots" content="index, follow" />
    <meta name="description" content="Sultanlar Ev ihtiyaç Maddeleri Pazarlama A.Ş. bünyesinde bir çok ticari ve sınai kuruluşları bulunduran Sultanlar Şirketler Grubu içerisinde yer almaktadır." />
    <meta name="keywords" content="sultanlar a.ş., sultanlar grup, happy family, bulgurium, johnson wax, scj, tibet, henkel, türk Henkel kimya, vileda, fhp, st grup, korozo, aktif kozmetik, sultanlar grup, arımama, sultanlar" />
    <link rel="shortcut icon" href="images/sultanlar.ico" type="image/x-icon" />

    <link rel="stylesheet" href="css/reset.css" />
    <link rel="stylesheet" href="css/style2.css" />
    <link rel="stylesheet" href="css/slider.css" />
    <link rel="stylesheet" href="css/superfish.css" />
    <link rel="stylesheet" href="css/grid.css" />

    
    <script src="js/jquery.tools.min.js"></script>
    <script src="js/superfish.js"></script>
    <script src="js/jquery.ui.totop.js"></script>
    <script src="js/jquery.easing.1.3.js"></script>

    <script>
        jQuery(document).ready(function () {
            $().UItoTop({ easingType: 'easeOutQuart' });
        });
    </script>

    <style type="text/css">
        img, div, a, input { behavior: url(js/iepngfix.htc) }
    </style>
    <style type="text/css">
        .doldurulmasilazim
        {
            color: #d25900;
        }
    </style>
    <script type="text/javascript">

        function ValidateEt(source, args) {
            args.IsValid = false
            if (args.Value > 0)
            {
                args.IsValid = true;
            }
            return;
        }

</script>
    <script type="text/javascript">
        function formYuklendi() {
            document.getElementById('ortaokul').style.display = 'none';
            document.getElementById('lise').style.display = 'none';
            document.getElementById('universite').style.display = 'none';
            document.getElementById('lisansustu').style.display = 'none';
            document.getElementById('yuksekokul').style.display = 'none';

            document.getElementById('cocukbaslik').style.display = 'none';
            document.getElementById('cocuk1').style.display = 'none';
            document.getElementById('cocuk2').style.display = 'none';
            document.getElementById('cocuk3').style.display = 'none';
            document.getElementById('cocuk4').style.display = 'none';
            document.getElementById('cocuk5').style.display = 'none';

            document.getElementById('kacprogrambaslik').style.display = 'none';
            document.getElementById('kacprogram1').style.display = 'none';
            document.getElementById('kacprogram2').style.display = 'none';
            document.getElementById('kacprogram3').style.display = 'none';
            document.getElementById('kacprogram4').style.display = 'none';
            document.getElementById('kacprogram5').style.display = 'none';

            document.getElementById('suandacalisiyor').style.display = 'none';

            document.getElementById('isyeribaslik').style.display = 'none';
            document.getElementById('isyeri1').style.display = 'none';
            document.getElementById('isyeri2').style.display = 'none';
            document.getElementById('isyeri3').style.display = 'none';
            document.getElementById('isyeri4').style.display = 'none';

            document.getElementById('kredikartibaslik').style.display = 'none';
            document.getElementById('kredikarti1').style.display = 'none';
            document.getElementById('kredikarti2').style.display = 'none';
            document.getElementById('kredikarti3').style.display = 'none';

//            document.getElementById('referansbaslik').style.display = 'none';
//            document.getElementById('referans1').style.display = 'none';
            document.getElementById('referans2').style.display = 'none';
            document.getElementById('referans3').style.display = 'none';
        }

        function ddlEgitimDurumu_click() {
            if (document.getElementById('ddlOgrenimDurumu').value == '1') {
                document.getElementById('ilkokul').style.display = 'inline-table';
                document.getElementById('ortaokul').style.display = 'none';
                document.getElementById('lise').style.display = 'none';
                document.getElementById('universite').style.display = 'none';
                document.getElementById('lisansustu').style.display = 'none';
                document.getElementById('yuksekokul').style.display = 'none';
            }
            else if (document.getElementById('ddlOgrenimDurumu').value == '2') {
                document.getElementById('ilkokul').style.display = 'inline-table';
                document.getElementById('ortaokul').style.display = 'inline-table';
                document.getElementById('lise').style.display = 'none';
                document.getElementById('universite').style.display = 'none';
                document.getElementById('lisansustu').style.display = 'none';
                document.getElementById('yuksekokul').style.display = 'none';
            }
            else if (document.getElementById('ddlOgrenimDurumu').value == '3') {
                document.getElementById('ilkokul').style.display = 'inline-table';
                document.getElementById('ortaokul').style.display = 'inline-table';
                document.getElementById('lise').style.display = 'inline-table';
                document.getElementById('universite').style.display = 'none';
                document.getElementById('lisansustu').style.display = 'none';
                document.getElementById('yuksekokul').style.display = 'none';
            }
            else if (document.getElementById('ddlOgrenimDurumu').value == '4') {
                document.getElementById('ilkokul').style.display = 'inline-table';
                document.getElementById('ortaokul').style.display = 'inline-table';
                document.getElementById('lise').style.display = 'inline-table';
                document.getElementById('universite').style.display = 'inline-table';
                document.getElementById('lisansustu').style.display = 'none';
                document.getElementById('yuksekokul').style.display = 'none';
            }
            else if (document.getElementById('ddlOgrenimDurumu').value == '5') {
                document.getElementById('ilkokul').style.display = 'inline-table';
                document.getElementById('ortaokul').style.display = 'inline-table';
                document.getElementById('lise').style.display = 'inline-table';
                document.getElementById('universite').style.display = 'inline-table';
                document.getElementById('lisansustu').style.display = 'inline-table';
                document.getElementById('yuksekokul').style.display = 'none';
            }
            else if (document.getElementById('ddlOgrenimDurumu').value == '6') {
                document.getElementById('ilkokul').style.display = 'inline-table';
                document.getElementById('ortaokul').style.display = 'inline-table';
                document.getElementById('lise').style.display = 'inline-table';
                document.getElementById('universite').style.display = 'inline-table';
                document.getElementById('lisansustu').style.display = 'inline-table';
                document.getElementById('yuksekokul').style.display = 'none';
            }
            else if (document.getElementById('ddlOgrenimDurumu').value == '8') {
                document.getElementById('ilkokul').style.display = 'inline-table';
                document.getElementById('ortaokul').style.display = 'inline-table';
                document.getElementById('lise').style.display = 'inline-table';
                document.getElementById('universite').style.display = 'none';
                document.getElementById('lisansustu').style.display = 'none';
                document.getElementById('yuksekokul').style.display = 'inline-table';
            }
        }

        function ddlKacCocukVar_onclick() {
            if (document.getElementById('ddlKacCocukVar').value == '0') {
                document.getElementById('cocukbaslik').style.display = 'none';
                document.getElementById('cocuk1').style.display = 'none';
                document.getElementById('cocuk2').style.display = 'none';
                document.getElementById('cocuk3').style.display = 'none';
                document.getElementById('cocuk4').style.display = 'none';
                document.getElementById('cocuk5').style.display = 'none';
            }
            else if (document.getElementById('ddlKacCocukVar').value == '1') {
                document.getElementById('cocukbaslik').style.display = 'inline-table';
                document.getElementById('cocuk1').style.display = 'inline-table';
                document.getElementById('cocuk2').style.display = 'none';
                document.getElementById('cocuk3').style.display = 'none';
                document.getElementById('cocuk4').style.display = 'none';
                document.getElementById('cocuk5').style.display = 'none';
            }
            else if (document.getElementById('ddlKacCocukVar').value == '2') {
                document.getElementById('cocukbaslik').style.display = 'inline-table';
                document.getElementById('cocuk1').style.display = 'inline-table';
                document.getElementById('cocuk2').style.display = 'inline-table';
                document.getElementById('cocuk3').style.display = 'none';
                document.getElementById('cocuk4').style.display = 'none';
                document.getElementById('cocuk5').style.display = 'none';
            }
            else if (document.getElementById('ddlKacCocukVar').value == '3') {
                document.getElementById('cocukbaslik').style.display = 'inline-table';
                document.getElementById('cocuk1').style.display = 'inline-table';
                document.getElementById('cocuk2').style.display = 'inline-table';
                document.getElementById('cocuk3').style.display = 'inline-table';
                document.getElementById('cocuk4').style.display = 'none';
                document.getElementById('cocuk5').style.display = 'none';
            }
            else if (document.getElementById('ddlKacCocukVar').value == '4') {
                document.getElementById('cocukbaslik').style.display = 'inline-table';
                document.getElementById('cocuk1').style.display = 'inline-table';
                document.getElementById('cocuk2').style.display = 'inline-table';
                document.getElementById('cocuk3').style.display = 'inline-table';
                document.getElementById('cocuk4').style.display = 'inline-table';
                document.getElementById('cocuk5').style.display = 'none';
            }
            else if (document.getElementById('ddlKacCocukVar').value == '5') {
                document.getElementById('cocukbaslik').style.display = 'inline-table';
                document.getElementById('cocuk1').style.display = 'inline-table';
                document.getElementById('cocuk2').style.display = 'inline-table';
                document.getElementById('cocuk3').style.display = 'inline-table';
                document.getElementById('cocuk4').style.display = 'inline-table';
                document.getElementById('cocuk5').style.display = 'inline-table';
            }
        }

        function ddlKacProgramKatildi_onclick() {
            if (document.getElementById('ddlKacProgramKatildi').value == '0') {
                document.getElementById('kacprogrambaslik').style.display = 'none';
                document.getElementById('kacprogram1').style.display = 'none';
                document.getElementById('kacprogram2').style.display = 'none';
                document.getElementById('kacprogram3').style.display = 'none';
                document.getElementById('kacprogram4').style.display = 'none';
                document.getElementById('kacprogram5').style.display = 'none';
            }
            else if (document.getElementById('ddlKacProgramKatildi').value == '1') {
                document.getElementById('kacprogrambaslik').style.display = 'inline-table';
                document.getElementById('kacprogram1').style.display = 'inline-table';
                document.getElementById('kacprogram2').style.display = 'none';
                document.getElementById('kacprogram3').style.display = 'none';
                document.getElementById('kacprogram4').style.display = 'none';
                document.getElementById('kacprogram5').style.display = 'none';
            }
            else if (document.getElementById('ddlKacProgramKatildi').value == '2') {
                document.getElementById('kacprogrambaslik').style.display = 'inline-table';
                document.getElementById('kacprogram1').style.display = 'inline-table';
                document.getElementById('kacprogram2').style.display = 'inline-table';
                document.getElementById('kacprogram3').style.display = 'none';
                document.getElementById('kacprogram4').style.display = 'none';
                document.getElementById('kacprogram5').style.display = 'none';
            }
            else if (document.getElementById('ddlKacProgramKatildi').value == '3') {
                document.getElementById('kacprogrambaslik').style.display = 'inline-table';
                document.getElementById('kacprogram1').style.display = 'inline-table';
                document.getElementById('kacprogram2').style.display = 'inline-table';
                document.getElementById('kacprogram3').style.display = 'inline-table';
                document.getElementById('kacprogram4').style.display = 'none';
                document.getElementById('kacprogram5').style.display = 'none';
            }
            else if (document.getElementById('ddlKacProgramKatildi').value == '4') {
                document.getElementById('kacprogrambaslik').style.display = 'inline-table';
                document.getElementById('kacprogram1').style.display = 'inline-table';
                document.getElementById('kacprogram2').style.display = 'inline-table';
                document.getElementById('kacprogram3').style.display = 'inline-table';
                document.getElementById('kacprogram4').style.display = 'inline-table';
                document.getElementById('kacprogram5').style.display = 'none';
            }
            else if (document.getElementById('ddlKacProgramKatildi').value == '5') {
                document.getElementById('kacprogrambaslik').style.display = 'inline-table';
                document.getElementById('kacprogram1').style.display = 'inline-table';
                document.getElementById('kacprogram2').style.display = 'inline-table';
                document.getElementById('kacprogram3').style.display = 'inline-table';
                document.getElementById('kacprogram4').style.display = 'inline-table';
                document.getElementById('kacprogram5').style.display = 'inline-table';
            }
        }

        function rbSuAndaCalisiyorMu_click() {
            if (document.getElementById('rbSuAndaCalisiyorMuEvet').checked) {
                document.getElementById('suandacalisiyor').style.display = 'inline-table';
            }
            else {
                document.getElementById('suandacalisiyor').style.display = 'none';
            }
        }

        function ddlKacIsYeri_click() {
            if (document.getElementById('ddlKacIsYeri').value == '0') {
                document.getElementById('isyeribaslik').style.display = 'none';
                document.getElementById('isyeri1').style.display = 'none';
                document.getElementById('isyeri2').style.display = 'none';
                document.getElementById('isyeri3').style.display = 'none';
                document.getElementById('isyeri4').style.display = 'none';
            }
            else if (document.getElementById('ddlKacIsYeri').value == '1') {
                document.getElementById('isyeribaslik').style.display = 'inline-table';
                document.getElementById('isyeri1').style.display = 'inline-table';
                document.getElementById('isyeri2').style.display = 'none';
                document.getElementById('isyeri3').style.display = 'none';
                document.getElementById('isyeri4').style.display = 'none';
            }
            else if (document.getElementById('ddlKacIsYeri').value == '2') {
                document.getElementById('isyeribaslik').style.display = 'inline-table';
                document.getElementById('isyeri1').style.display = 'inline-table';
                document.getElementById('isyeri2').style.display = 'inline-table';
                document.getElementById('isyeri3').style.display = 'none';
                document.getElementById('isyeri4').style.display = 'none';
            }
            else if (document.getElementById('ddlKacIsYeri').value == '3') {
                document.getElementById('isyeribaslik').style.display = 'inline-table';
                document.getElementById('isyeri1').style.display = 'inline-table';
                document.getElementById('isyeri2').style.display = 'inline-table';
                document.getElementById('isyeri3').style.display = 'inline-table';
                document.getElementById('isyeri4').style.display = 'none';
            }
            else if (document.getElementById('ddlKacIsYeri').value == '4') {
                document.getElementById('isyeribaslik').style.display = 'inline-table';
                document.getElementById('isyeri1').style.display = 'inline-table';
                document.getElementById('isyeri2').style.display = 'inline-table';
                document.getElementById('isyeri3').style.display = 'inline-table';
                document.getElementById('isyeri4').style.display = 'inline-table';
            }
        }

        function ddlKacKrediKarti_onclick() {
            if (document.getElementById('ddlKacKrediKarti').value == '0') {
                document.getElementById('kredikartibaslik').style.display = 'none';
                document.getElementById('kredikarti1').style.display = 'none';
                document.getElementById('kredikarti2').style.display = 'none';
                document.getElementById('kredikarti3').style.display = 'none';
            }
            else if (document.getElementById('ddlKacKrediKarti').value == '1') {
                document.getElementById('kredikartibaslik').style.display = 'inline-table';
                document.getElementById('kredikarti1').style.display = 'inline-table';
                document.getElementById('kredikarti2').style.display = 'none';
                document.getElementById('kredikarti3').style.display = 'none';
            }
            else if (document.getElementById('ddlKacKrediKarti').value == '2') {
                document.getElementById('kredikartibaslik').style.display = 'inline-table';
                document.getElementById('kredikarti1').style.display = 'inline-table';
                document.getElementById('kredikarti2').style.display = 'inline-table';
                document.getElementById('kredikarti3').style.display = 'none';
            }
            else if (document.getElementById('ddlKacKrediKarti').value == '3') {
                document.getElementById('kredikartibaslik').style.display = 'inline-table';
                document.getElementById('kredikarti1').style.display = 'inline-table';
                document.getElementById('kredikarti2').style.display = 'inline-table';
                document.getElementById('kredikarti3').style.display = 'inline-table';
            }
        }

        function ddlKacReferans_click() {
            if (document.getElementById('ddlKacReferans').value == '0') {
                document.getElementById('referansbaslik').style.display = 'none';
                document.getElementById('referans1').style.display = 'none';
                document.getElementById('referans2').style.display = 'none';
                document.getElementById('referans3').style.display = 'none';
            }
            else if (document.getElementById('ddlKacReferans').value == '1') {
                document.getElementById('referansbaslik').style.display = 'inline-table';
                document.getElementById('referans1').style.display = 'inline-table';
                document.getElementById('referans2').style.display = 'none';
                document.getElementById('referans3').style.display = 'none';
            }
            else if (document.getElementById('ddlKacReferans').value == '2') {
                document.getElementById('referansbaslik').style.display = 'inline-table';
                document.getElementById('referans1').style.display = 'inline-table';
                document.getElementById('referans2').style.display = 'inline-table';
                document.getElementById('referans3').style.display = 'none';
            }
            else if (document.getElementById('ddlKacReferans').value == '3') {
                document.getElementById('referansbaslik').style.display = 'inline-table';
                document.getElementById('referans1').style.display = 'inline-table';
                document.getElementById('referans2').style.display = 'inline-table';
                document.getElementById('referans3').style.display = 'inline-table';
            }
        }

        function functionGonder() {
            window.location.href = document.getElementById('lbGonder').href;

            if (document.getElementById('ValidationSummary1').style.display == 'none')
                document.getElementById('btnGonderClient').disabled = 'disabled';
        }
    </script>
    <script type="text/javascript">        AC_FL_RunContent = 0; </script>
    <script type="text/javascript">        DetectFlashVer = 0; </script>
    <script src="scripts/AC_RunActiveContent.js" type="text/javascript"></script>
    <script type="text/javascript">
<!--
        // -----------------------------------------------------------------------------
        // Globals
        // Major version of Flash required
        var requiredMajorVersion = 9;
        // Minor version of Flash required
        var requiredMinorVersion = 0;
        // Revision of Flash required
        var requiredRevision = 45;
        // -----------------------------------------------------------------------------
// -->
    </script>
</head>
<body onload="formYuklendi()">
    <form id="form1" runat="server" action="isbasvuru.html">


    
<!--[if IE 6]><div class="heaader"><![endif]--><!--[if IE 7]><div class="heaader"><![endif]--><!--[if IE 8]><div class="heaader"><![endif]-->
<header>
  <div class="container_12">
    <div class="grid_12">
      <img alt="Sultanlar Pazarlama" src="images/logo.png" onclick="window.location.href='index.html'" style="cursor:pointer;" />
      <nav>
      <!--[if IE 6]><span style="width: 300px; display: inline-block"></span><![endif]-->
      <!--[if IE 7]><span style="width: 300px; display: inline-block"></span><![endif]-->
      <!--[if IE 8]><span style="width: 300px; display: inline-block"></span><![endif]-->
        <ul class="sf-menu">
          <li><a href="index.html">ANA SAYFA</a></li>
          <li><a href="kurumsal.html">KURUMSAL</a>
            <ul>
              <li><a href="kurumsal.html#hakkimizda">HAKKIMIZDA</a></li>
              <li><a href="kurumsal.html#grubumuzunamaclari">GRUBUMUZUN AMAÇLARI</a></li>
              <li><a href="kurumsal.html#vizyonmisyon">VİZYON & MİSYON</a></li>
              <li><a href="kurumsal.html#sirketprofili">ŞİRKET PROFİLİ</a></li>
              <li><a href="kurumsal.html#organizasyonsemasi">ORGANİZASYON ŞEMASI</a>
              </li>
            </ul>
          </li>
          <li><a href="musteri/giris.html">MÜŞTERİ GİRİŞİ</a></li>
          <li class="current"><a href="insankaynaklari.html">İNSAN KAYNAKLARI</a></li>
          <li><a href="iletisim.html">İLETİŞİM</a></li>
        </ul>
        <div class="clear"></div>
      </nav>
      <div class="clear"></div>
    </div>
    <div class="clear"></div>
  </div>
</header>
<!--[if IE 6]></div><![endif]--><!--[if IE 7]></div><![endif]--><!--[if IE 8]></div><![endif]-->

<div class="main">
<!--main-->
    <div class="main pad0">
    <div class="content">
    	<div class="container_12">
    		<div class="grid_12">
            	<h4><span style="font-family: Tahoma; font-weight: bold">İş</span> Ba<span style="font-family: Tahoma; font-weight: bold">ş</span>vurusu</h4>
            </div>
        </div>
    </div>
    </div>



        <table align="center" width="100%" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td align="center">
                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td style="width: 920px;">
                                <asp:ScriptManager ID="ScriptManager1" runat="server">
                                </asp:ScriptManager>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top" align="center">
                                <table border="0" cellpadding="0" cellspacing="0" style="width: 920px; height: 580px">
                                    <tr>
                                        <td valign="top" align="center">
                                            <table style="width: 100%">
                                                <tr>
                                                    <td colspan="2" align="center">
                                                        <table cellpadding="0" cellspacing="0">
                                                            <tr>
                                                                <td style="padding: 10px; width: 100%;" align="center">
                                                                        <table cellpadding="5" cellspacing="0" style="width: 800px; text-align: left;">
                                                                            <tr>
                                                                                <td style="padding: 15px;" colspan="3">
                                                                                    <span class="doldurulmasilazim">*</span>
                                                                                    &#304;le gösterilen alanlar&#305;n doldurulmas&#305; 
                                                                                    zorunludur.</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 314px; padding-top: 15px; padding-bottom: 8px;">
                                                                                    <span style="font-size: 15px; font-weight: bold; color: #726F6D">K&#304;&#350;&#304;SEL B&#304;LG&#304;LER</span>
                                                                                </td>
                                                                                <td style="width: 6px; padding-top: 15px; padding-bottom: 8px;">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td style="width: 470px">
                                                                                    &nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    Ad&#305;n&#305;z
                                                                                </td>
                                                                                <td>
                                                                                    <span class="doldurulmasilazim">*</span>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="txtAd" runat="server" MaxLength="50" Width="250px"></asp:TextBox>
                                                                                    &nbsp;<asp:RequiredFieldValidator ID="rfvAd" runat="server" ControlToValidate="txtAd"
                                                                                        ErrorMessage="Ad alan&#305; bo&#351; b&#305;rak&#305;lamaz" ToolTip="Ad alan&#305; bo&#351; b&#305;rak&#305;lamaz">*</asp:RequiredFieldValidator>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    Soyad&#305;n&#305;z
                                                                                </td>
                                                                                <td>
                                                                                    <span class="doldurulmasilazim">*</span>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="txtSoyad" runat="server" MaxLength="50" Width="250px"></asp:TextBox>
                                                                                    &nbsp;<asp:RequiredFieldValidator ID="rfvSoyad" runat="server" ControlToValidate="txtSoyad"
                                                                                        ErrorMessage="Soyad alan&#305; bo&#351; b&#305;rak&#305;lamaz" ToolTip="Soyad alan&#305; bo&#351; b&#305;rak&#305;lamaz">*</asp:RequiredFieldValidator>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    Do&#287;um Tarihiniz
                                                                                </td>
                                                                                <td>
                                                                                    <span class="doldurulmasilazim">*</span>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="txtDogumTarihi" runat="server" MaxLength="10" Width="250px"></asp:TextBox>
                                                                                    &nbsp;(örnek: 22/02/1980)
                                                                                    <asp:RegularExpressionValidator ID="revDogumTarihi1" runat="server" 
                                                                                        ControlToValidate="txtDogumTarihi" ErrorMessage="Tarih format&#305; yanl&#305;&#351;" 
                                                                                        ToolTip="Tarih format&#305; yanl&#305;&#351;" 
                                                                                        ValidationExpression="^(((0[1-9]|[12]\d|3[01])\/(0[13578]|1[02])\/((19|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\/(0[13456789]|1[012])\/((19|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\/02\/((19|[2-9]\d)\d{2}))|(29\/02\/((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$">*</asp:RegularExpressionValidator>
                                                                                    <asp:RequiredFieldValidator ID="rfvDogumTarihi1" runat="server" 
                                                                                        ControlToValidate="txtDogumTarihi" ErrorMessage="Tarih alan&#305; bo&#351; b&#305;rak&#305;lamaz" 
                                                                                        ToolTip="Tarih alan&#305; bo&#351; b&#305;rak&#305;lamaz">*</asp:RequiredFieldValidator>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    Do&#287;um Yeriniz
                                                                                </td>
                                                                                <td>
                                                                                    <span class="doldurulmasilazim">*</span>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:DropDownList ID="ddlDogumYeriIl" runat="server" Width="256px">
                                                                                    </asp:DropDownList>
                                                                                    <asp:CustomValidator ID="cvDogumYeriIl" runat="server" 
                                                                                        ControlToValidate="ddlDogumYeriIl" ErrorMessage="Do&#287;um yeri seçilmedi" 
                                                                                        ClientValidationFunction="ValidateEt" ToolTip="Do&#287;um yeri seçilmedi">*</asp:CustomValidator>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    Cinsiyet
                                                                                </td>
                                                                                <td>
                                                                                    <span class="doldurulmasilazim">*</span>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:RadioButton ID="rbCinsiyetBay" runat="server" Checked="True" GroupName="grCinsiyet"
                                                                                        Text="Bay" />
                                                                                    <asp:RadioButton ID="rbCinsiyetBayan" runat="server" GroupName="grCinsiyet" Text="Bayan" />
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    TC Kimlik No
                                                                                </td>
                                                                                <td>
                                                                                    <span class="doldurulmasilazim">*</span>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="txtTCKimlik" runat="server" MaxLength="11" Width="250px"></asp:TextBox>
                                                                                    &nbsp;<asp:RequiredFieldValidator ID="rfvTCKimlik" runat="server" ControlToValidate="txtTCKimlik"
                                                                                        ErrorMessage="TC Kimlik alan&#305; bo&#351; b&#305;rak&#305;lamaz" ToolTip="TC Kimlik alan&#305; bo&#351; b&#305;rak&#305;lamaz">*</asp:RequiredFieldValidator>
                                                                                    <asp:RegularExpressionValidator ID="revTCKimlikNo" runat="server" ControlToValidate="txtTCKimlik"
                                                                                        ErrorMessage="TC Kimlik No format&#305; yanl&#305;&#351;" ToolTip="TC Kimlik No format&#305; yanl&#305;&#351;"
                                                                                        ValidationExpression="\d{11}">*</asp:RegularExpressionValidator>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    Nüfusa Kay&#305;tl&#305; &#304;l/&#304;lçe
                                                                                </td>
                                                                                <td>
                                                                                    <span class="doldurulmasilazim">*</span>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:UpdatePanel ID="upNufus" runat="server">
                                                                                        <ContentTemplate>
                                                                                            <asp:DropDownList ID="ddlNufusIl" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlNufusIl_SelectedIndexChanged"
                                                                                                Width="150px">
                                                                                            </asp:DropDownList>
                                                                                            &nbsp;<asp:DropDownList ID="ddlNufusIlce" runat="server" Width="150px">
                                                                                            </asp:DropDownList>
                                                                                            &nbsp;<asp:CustomValidator ID="cvNufusIl" runat="server" 
                                                                                                ClientValidationFunction="ValidateEt" ControlToValidate="ddlNufusIl" 
                                                                                                ErrorMessage="Nüfusa ba&#287;l&#305; il seçilmedi" ToolTip="Nüfusa ba&#287;l&#305; il seçilmedi">*</asp:CustomValidator>
                                                                                            <asp:CustomValidator ID="cvNufusIlce" runat="server" 
                                                                                                ClientValidationFunction="ValidateEt" ControlToValidate="ddlNufusIlce" 
                                                                                                ErrorMessage="Nüfusa ba&#287;l&#305; ilçe seçilmedi" 
                                                                                                ToolTip="Nüfusa ba&#287;l&#305; ilçe seçilmedi">*</asp:CustomValidator>
                                                                                        </ContentTemplate>
                                                                                    </asp:UpdatePanel>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    Medeni Durum
                                                                                </td>
                                                                                <td>
                                                                                    <span class="doldurulmasilazim">*</span>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:DropDownList ID="ddlMedeniDurum" runat="server" Width="256px">
                                                                                    </asp:DropDownList>
                                                                                    &nbsp;<asp:CustomValidator ID="cvMedeniDurum" runat="server" 
                                                                                        ClientValidationFunction="ValidateEt" ControlToValidate="ddlMedeniDurum" 
                                                                                        ErrorMessage="Medeni durum seçilmedi" ToolTip="Medeni durum seçilmedi">*</asp:CustomValidator>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    Anne Baba adlar&#305; (S&#305;ras&#305;yla)
                                                                                </td>
                                                                                <td>
                                                                                    <span class="doldurulmasilazim">*</span>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="txtAnneAdi" runat="server" MaxLength="20" Width="125px"></asp:TextBox>
                                                                                    &nbsp;<asp:TextBox ID="txtBabaAdi" runat="server" MaxLength="20" Width="125px"></asp:TextBox>
                                                                                    &nbsp;<asp:RequiredFieldValidator ID="rfvAnneAdi" runat="server" ControlToValidate="txtAnneAdi"
                                                                                        ErrorMessage="Anne ad&#305; bo&#351; b&#305;rak&#305;lamaz" ToolTip="Anne ad&#305; bo&#351; b&#305;rak&#305;lamaz">*</asp:RequiredFieldValidator>
                                                                                    <asp:RequiredFieldValidator ID="rfvBabaAdi" runat="server" 
                                                                                        ControlToValidate="txtBabaAdi" ErrorMessage="Baba ad&#305; bo&#351; b&#305;rak&#305;lamaz" 
                                                                                        ToolTip="Baba ad&#305; bo&#351; b&#305;rak&#305;lamaz">*</asp:RequiredFieldValidator>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    Ba&#351;vurmak &#304;stedi&#287;iniz Görev
                                                                                </td>
                                                                                <td>
                                                                                    <span class="doldurulmasilazim">*</span>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:CheckBoxList ID="cblGorevler" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                                                                                    </asp:CheckBoxList>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    Sürücü belgeniz var m&#305;?
                                                                                </td>
                                                                                <td>
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td>
                                                                                    <asp:RadioButton ID="rbSurucuBelgesiEvet" runat="server" GroupName="grSurucuBelgesi"
                                                                                        Text="Evet" />
                                                                                    <asp:RadioButton ID="rbSurucuBelgesiHayir" runat="server" Checked="True" GroupName="grSurucuBelgesi"
                                                                                        Text="Hay&#305;r" />
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    &nbsp;&nbsp;&nbsp;&nbsp; Var ise; S&#305;n&#305;f&#305; ve Verili&#351; Tarihi
                                                                                </td>
                                                                                <td>
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td>
                                                                                    <asp:DropDownList ID="ddlSurucuBelgeSinif" runat="server" Width="150px">
                                                                                    </asp:DropDownList>
                                                                                    &nbsp;<asp:TextBox ID="txtSurucuBelgeTarih" runat="server" MaxLength="10" Width="150px"></asp:TextBox>
                                                                                    &nbsp;(örnek: 22/02/2001)
                                                                                    <asp:RegularExpressionValidator ID="revSurucuBelgeTarihi" runat="server" ControlToValidate="txtSurucuBelgeTarih"
                                                                                        ErrorMessage="Tarih format&#305; yanl&#305;&#351;" ToolTip="Tarih format&#305; yanl&#305;&#351;"
                                                                                        ValidationExpression="^(((0[1-9]|[12]\d|3[01])\/(0[13578]|1[02])\/((19|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\/(0[13456789]|1[012])\/((19|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\/02\/((19|[2-9]\d)\d{2}))|(29\/02\/((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$">*</asp:RegularExpressionValidator>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    Psikoteknik belgeniz var m&#305;?
                                                                                </td>
                                                                                <td>
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td>
                                                                                    <asp:RadioButton ID="rbPsikoEvet" runat="server" GroupName="grPsiko" Text="Evet" />
                                                                                    <asp:RadioButton ID="rbPsikoHayir" runat="server" Checked="True" GroupName="grPsiko"
                                                                                        Text="Hay&#305;r" />
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    SRC belgeniz var ise s&#305;n&#305;f&#305;n&#305; belirtiniz
                                                                                </td>
                                                                                <td>
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td>
                                                                                    <asp:DropDownList ID="ddlSRC" runat="server" Width="256px">
                                                                                        <asp:ListItem Selected="True" Value="0">Yok</asp:ListItem>
                                                                                        <asp:ListItem Value="1"></asp:ListItem>
                                                                                        <asp:ListItem Value="2"></asp:ListItem>
                                                                                        <asp:ListItem Value="3"></asp:ListItem>
                                                                                        <asp:ListItem Value="4"></asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    Boyunuz
                                                                                </td>
                                                                                <td>
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="txtBoy" runat="server" MaxLength="5" Width="250px"></asp:TextBox>
                                                                                    &nbsp;(örnek: 1.75)
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    Kilonuz
                                                                                </td>
                                                                                <td>
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="txtKilo" runat="server" MaxLength="5" Width="250px"></asp:TextBox>
                                                                                    &nbsp;(örnek: 78)
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    Siz hariç karde&#351;lerinizin say&#305;s&#305;
                                                                                </td>
                                                                                <td>
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="txtKardesSayisi" runat="server" MaxLength="2" Width="250px"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    Ev Adresiniz
                                                                                </td>
                                                                                <td>
                                                                                    <span class="doldurulmasilazim">*</span>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="txtAdres" runat="server" Height="70px" MaxLength="200" TextMode="MultiLine"
                                                                                        Width="250px"></asp:TextBox>
                                                                                    &nbsp;<asp:RequiredFieldValidator ID="rfvEvAdresi" runat="server" ControlToValidate="txtAdres"
                                                                                        ErrorMessage="Ev adresi bo&#351; b&#305;rak&#305;lamaz" ToolTip="Ev adresi bo&#351; b&#305;rak&#305;lamaz">*</asp:RequiredFieldValidator>
                                                                                    &nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    &nbsp;&nbsp;&nbsp;&nbsp; &#350;ehir
                                                                                </td>
                                                                                <td>
                                                                                    <span class="doldurulmasilazim">*</span>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:DropDownList ID="ddlAdresIl" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlAdresIl_SelectedIndexChanged"
                                                                                        Width="256px">
                                                                                    </asp:DropDownList>
                                                                                    &nbsp;<asp:CustomValidator ID="cvAdresIl" runat="server" 
                                                                                        ClientValidationFunction="ValidateEt" ControlToValidate="ddlAdresIl" 
                                                                                        ErrorMessage="Adres için il seçilmedi" ToolTip="Adres için il seçilmedi">*</asp:CustomValidator>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    &nbsp;&nbsp;&nbsp;&nbsp; &#304;lçe
                                                                                </td>
                                                                                <td>
                                                                                    <span class="doldurulmasilazim">*</span>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:UpdatePanel ID="upAdresIlce" runat="server">
                                                                                        <Triggers>
                                                                                            <asp:AsyncPostBackTrigger ControlID="ddlAdresIl" EventName="SelectedIndexChanged" />
                                                                                        </Triggers>
                                                                                        <ContentTemplate>
                                                                                            <asp:DropDownList ID="ddlAdresIlce" runat="server" Width="256px">
                                                                                            </asp:DropDownList>
                                                                                            &nbsp;<asp:CustomValidator ID="cvAdresIlce" runat="server" 
                                                                                                ClientValidationFunction="ValidateEt" ControlToValidate="ddlAdresIlce" 
                                                                                                ErrorMessage="Adres için ilçe seçilmedi" ToolTip="Adres için ilçe seçilmedi">*</asp:CustomValidator>
                                                                                        </ContentTemplate>
                                                                                    </asp:UpdatePanel>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    Ev Telefonu
                                                                                </td>
                                                                                <td>
                                                                                    <span class="doldurulmasilazim">*</span>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="txtEvTelefonu" runat="server" MaxLength="15" Width="250px"></asp:TextBox>
                                                                                    &nbsp;<asp:RequiredFieldValidator ID="rfvEvTelefonu" runat="server" ControlToValidate="txtEvTelefonu"
                                                                                        ErrorMessage="Ev telefonu bo&#351; b&#305;rak&#305;lamaz" ToolTip="Ev telefonu bo&#351; b&#305;rak&#305;lamaz">*</asp:RequiredFieldValidator>
                                                                                    <asp:RegularExpressionValidator ID="revEvTelefonu" runat="server" 
                                                                                        ControlToValidate="txtEvTelefonu" ErrorMessage="Telefon Format&#305; Yanl&#305;&#351;" 
                                                                                        ToolTip="Telefon Format&#305; Yanl&#305;&#351;" ValidationExpression="[+\d ]*">*</asp:RegularExpressionValidator>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    Cep Telefonu
                                                                                </td>
                                                                                <td>
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="txtCepTelefonu" runat="server" MaxLength="15" Width="250px"></asp:TextBox>
                                                                                    &nbsp;<asp:RegularExpressionValidator ID="revCevTelefonu" runat="server" 
                                                                                        ControlToValidate="txtCepTelefonu" ErrorMessage="Telefon Format&#305; Yanl&#305;&#351;" 
                                                                                        ToolTip="Telefon Format&#305; Yanl&#305;&#351;" ValidationExpression="[+\d ]*">*</asp:RegularExpressionValidator>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    E-posta Adresi
                                                                                </td>
                                                                                <td>
                                                                                    <span class="doldurulmasilazim">*</span>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="txtEpostaAdresi" runat="server" MaxLength="50" Width="250px"></asp:TextBox>
                                                                                    &nbsp;<asp:RequiredFieldValidator ID="rfvEpostaAdresi" runat="server" 
                                                                                        ControlToValidate="txtEpostaAdresi" ErrorMessage="Eposta alan&#305; bo&#351; b&#305;rak&#305;lamaz" 
                                                                                        ToolTip="Eposta alan&#305; bo&#351; b&#305;rak&#305;lamaz">*</asp:RequiredFieldValidator>
                                                                                    <asp:RegularExpressionValidator ID="revEpostaAdresi" runat="server" ControlToValidate="txtEpostaAdresi"
                                                                                        ErrorMessage="Eposta format&#305; do&#287;ru de&#287;il" ToolTip="Eposta format&#305; do&#287;ru de&#287;il"
                                                                                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    Ki&#351;isel Web Sayfas&#305;
                                                                                </td>
                                                                                <td>
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="txtWebSayfasi" runat="server" MaxLength="50" Width="250px"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    Vesikal&#305;k Bir Resminiz</td>
                                                                                <td>
                                                                                    &nbsp;</td>
                                                                                <td>
                                                                                    <asp:FileUpload ID="fuResim" runat="server" Width="258px" />
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="padding-top: 15px; padding-bottom: 8px;">
                                                                                    <span style="font-size: 15px; font-weight: bold; color: #726F6D">A&#304;LE B&#304;LG&#304;LER&#304;</span>
                                                                                </td>
                                                                                <td style="padding-top: 15px; padding-bottom: 8px;">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td>
                                                                                    &nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    E&#351;inizin Ad&#305;
                                                                                </td>
                                                                                <td>
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="txtEsAd" runat="server" MaxLength="50" Width="250px"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Evlilik Öncesi Soyad&#305;
                                                                                </td>
                                                                                <td>
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="txtEsSoyad" runat="server" MaxLength="50" Width="250px"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Mesle&#287;i
                                                                                </td>
                                                                                <td>
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="txtEsMeslek" runat="server" MaxLength="80" Width="250px"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Do&#287;um Tarihi
                                                                                </td>
                                                                                <td>
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="txtEsDogumTarihi" runat="server" MaxLength="10" Width="250px"></asp:TextBox>
                                                                                    &nbsp;(örnek: 22/02/1980)
                                                                                    <asp:RegularExpressionValidator ID="revEsDogumTarihi" runat="server" ControlToValidate="txtEsDogumTarihi"
                                                                                        ErrorMessage="Tarih format&#305; yanl&#305;&#351;" ToolTip="Tarih format&#305; yanl&#305;&#351;"
                                                                                        ValidationExpression="^(((0[1-9]|[12]\d|3[01])\/(0[13578]|1[02])\/((19|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\/(0[13456789]|1[012])\/((19|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\/02\/((19|[2-9]\d)\d{2}))|(29\/02\/((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$">*</asp:RegularExpressionValidator>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td valign="top">
                                                                                    <br />
                                                                                    Çocuklar&#305;n&#305;z
                                                                                </td>
                                                                                <td valign="top">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td>
                                                                                    <table cellpadding="5" cellspacing="0" style="width: 100%">
                                                                                        <tr>
                                                                                            <td style="width: 30%">
                                                                                                Kaç çocu&#287;unuz var:
                                                                                            </td>
                                                                                            <td style="width: 70%">
                                                                                                <asp:DropDownList ID="ddlKacCocukVar" runat="server" onchange="ddlKacCocukVar_onclick()"
                                                                                                    Width="50px">
                                                                                                    <asp:ListItem Selected="True">0</asp:ListItem>
                                                                                                    <asp:ListItem Value="1">1</asp:ListItem>
                                                                                                    <asp:ListItem Value="2">2</asp:ListItem>
                                                                                                    <asp:ListItem Value="3">3</asp:ListItem>
                                                                                                    <asp:ListItem Value="4">4</asp:ListItem>
                                                                                                    <asp:ListItem Value="5">5</asp:ListItem>
                                                                                                </asp:DropDownList>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                    <table id="cocukbaslik" cellpadding="5" cellspacing="0" style="text-align: center"
                                                                                        visible="false">
                                                                                        <tr>
                                                                                            <td style="width: 100px">
                                                                                                Ad
                                                                                            </td>
                                                                                            <td style="width: 96px">
                                                                                                Cinsiyet
                                                                                            </td>
                                                                                            <td style="width: 90px">
                                                                                                Do&#287;um Tarihi
                                                                                            </td>
                                                                                            <td style="width: 120px">
                                                                                                Varsa Devam Etti&#287;i Okul
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                    <table id="cocuk1" cellpadding="5" cellspacing="0" style="text-align: center" visible="false">
                                                                                        <tr>
                                                                                            <td>
                                                                                                <asp:TextBox ID="txtCocuk1Ad" runat="server" MaxLength="30" Width="100px"></asp:TextBox>
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:RadioButton ID="rbCocuk1CinsiyetKiz" runat="server" Checked="True" GroupName="grCocuk1Cinsiyet"
                                                                                                    Text="K&#305;z" />
                                                                                                <asp:RadioButton ID="rbCocuk1CinsiyetErkek" runat="server" GroupName="grCocuk1Cinsiyet"
                                                                                                    Text="Erkek" />
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:TextBox ID="txtCocuk1DogumTarihi" runat="server" MaxLength="10" Width="80px"></asp:TextBox>
                                                                                                &nbsp;<asp:RegularExpressionValidator ID="revCocuk1DogumTarihi" runat="server" ControlToValidate="txtCocuk1DogumTarihi"
                                                                                                    ErrorMessage="Tarih format&#305; yanl&#305;&#351;" ToolTip="Tarih format&#305; yanl&#305;&#351;"
                                                                                                    ValidationExpression="^(((0[1-9]|[12]\d|3[01])\/(0[13578]|1[02])\/((19|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\/(0[13456789]|1[012])\/((19|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\/02\/((19|[2-9]\d)\d{2}))|(29\/02\/((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$">*</asp:RegularExpressionValidator>
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:TextBox ID="txtCocuk1Okul" runat="server" MaxLength="70" Width="120px"></asp:TextBox>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                    <table id="cocuk2" cellpadding="5" cellspacing="0" style="text-align: center" visible="false">
                                                                                        <tr>
                                                                                            <td>
                                                                                                <asp:TextBox ID="txtCocuk2Ad" runat="server" MaxLength="30" Width="100px"></asp:TextBox>
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:RadioButton ID="rbCocuk2CinsiyetKiz" runat="server" Checked="True" GroupName="grCocuk2Cinsiyet"
                                                                                                    Text="K&#305;z" />
                                                                                                <asp:RadioButton ID="rbCocuk2CinsiyetErkek" runat="server" GroupName="grCocuk2Cinsiyet"
                                                                                                    Text="Erkek" />
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:TextBox ID="txtCocuk2DogumTarihi" runat="server" MaxLength="10" Width="80px"></asp:TextBox>
                                                                                                &nbsp;<asp:RegularExpressionValidator ID="revCocuk2DogumTarihi" runat="server" ControlToValidate="txtCocuk2DogumTarihi"
                                                                                                    ErrorMessage="Tarih format&#305; yanl&#305;&#351;" ToolTip="Tarih format&#305; yanl&#305;&#351;"
                                                                                                    ValidationExpression="^(((0[1-9]|[12]\d|3[01])\/(0[13578]|1[02])\/((19|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\/(0[13456789]|1[012])\/((19|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\/02\/((19|[2-9]\d)\d{2}))|(29\/02\/((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$">*</asp:RegularExpressionValidator>
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:TextBox ID="txtCocuk2Okul" runat="server" MaxLength="70" Width="120px"></asp:TextBox>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                    <table id="cocuk3" cellpadding="5" cellspacing="0" style="text-align: center" visible="false">
                                                                                        <tr>
                                                                                            <td>
                                                                                                <asp:TextBox ID="txtCocuk3Ad" runat="server" MaxLength="30" Width="100px"></asp:TextBox>
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:RadioButton ID="rbCocuk3CinsiyetKiz" runat="server" Checked="True" GroupName="grCocuk3Cinsiyet"
                                                                                                    Text="K&#305;z" />
                                                                                                <asp:RadioButton ID="rbCocuk3CinsiyetErkek" runat="server" GroupName="grCocuk3Cinsiyet"
                                                                                                    Text="Erkek" />
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:TextBox ID="txtCocuk3DogumTarihi" runat="server" MaxLength="10" Width="80px"></asp:TextBox>
                                                                                                &nbsp;<asp:RegularExpressionValidator ID="revCocuk3DogumTarihi" runat="server" ControlToValidate="txtCocuk3DogumTarihi"
                                                                                                    ErrorMessage="Tarih format&#305; yanl&#305;&#351;" ToolTip="Tarih format&#305; yanl&#305;&#351;"
                                                                                                    ValidationExpression="^(((0[1-9]|[12]\d|3[01])\/(0[13578]|1[02])\/((19|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\/(0[13456789]|1[012])\/((19|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\/02\/((19|[2-9]\d)\d{2}))|(29\/02\/((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$">*</asp:RegularExpressionValidator>
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:TextBox ID="txtCocuk3Okul" runat="server" MaxLength="70" Width="120px"></asp:TextBox>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                    <table id="cocuk4" cellpadding="5" cellspacing="0" style="text-align: center" visible="false">
                                                                                        <tr>
                                                                                            <td>
                                                                                                <asp:TextBox ID="txtCocuk4Ad" runat="server" MaxLength="30" Width="100px"></asp:TextBox>
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:RadioButton ID="rbCocuk4CinsiyetKiz" runat="server" Checked="True" GroupName="grCocuk4Cinsiyet"
                                                                                                    Text="K&#305;z" />
                                                                                                <asp:RadioButton ID="rbCocuk4CinsiyetErkek" runat="server" GroupName="grCocuk4Cinsiyet"
                                                                                                    Text="Erkek" />
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:TextBox ID="txtCocuk4DogumTarihi" runat="server" MaxLength="10" Width="80px"></asp:TextBox>
                                                                                                &nbsp;<asp:RegularExpressionValidator ID="revCocuk4DogumTarihi" runat="server" ControlToValidate="txtCocuk4DogumTarihi"
                                                                                                    ErrorMessage="Tarih format&#305; yanl&#305;&#351;" ToolTip="Tarih format&#305; yanl&#305;&#351;"
                                                                                                    ValidationExpression="^(((0[1-9]|[12]\d|3[01])\/(0[13578]|1[02])\/((19|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\/(0[13456789]|1[012])\/((19|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\/02\/((19|[2-9]\d)\d{2}))|(29\/02\/((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$">*</asp:RegularExpressionValidator>
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:TextBox ID="txtCocuk4Okul" runat="server" MaxLength="70" Width="120px"></asp:TextBox>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                    <table id="cocuk5" cellpadding="5" cellspacing="0" style="text-align: center" visible="false">
                                                                                        <tr>
                                                                                            <td>
                                                                                                <asp:TextBox ID="txtCocuk5Ad" runat="server" MaxLength="30" Width="100px"></asp:TextBox>
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:RadioButton ID="rbCocuk5CinsiyetKiz" runat="server" Checked="True" GroupName="grCocuk5Cinsiyet"
                                                                                                    Text="K&#305;z" />
                                                                                                <asp:RadioButton ID="rbCocuk5CinsiyetErkek" runat="server" GroupName="grCocuk5Cinsiyet"
                                                                                                    Text="Erkek" />
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:TextBox ID="txtCocuk5DogumTarihi" runat="server" MaxLength="10" Width="80px"></asp:TextBox>
                                                                                                &nbsp;<asp:RegularExpressionValidator ID="revCocuk5DogumTarihi" runat="server" ControlToValidate="txtCocuk5DogumTarihi"
                                                                                                    ErrorMessage="Tarih format&#305; yanl&#305;&#351;" ToolTip="Tarih format&#305; yanl&#305;&#351;"
                                                                                                    ValidationExpression="^(((0[1-9]|[12]\d|3[01])\/(0[13578]|1[02])\/((19|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\/(0[13456789]|1[012])\/((19|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\/02\/((19|[2-9]\d)\d{2}))|(29\/02\/((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$">*</asp:RegularExpressionValidator>
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:TextBox ID="txtCocuk5Okul" runat="server" MaxLength="70" Width="120px"></asp:TextBox>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="padding-top: 15px; padding-bottom: 8px;">
                                                                                    <span style="font-size: 15px; font-weight: bold; color: #726F6D">ASKERL&#304;K DURUMU</span>
                                                                                </td>
                                                                                <td style="padding-top: 15px; padding-bottom: 8px;">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td>
                                                                                    &nbsp;&nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    Durumunuz
                                                                                </td>
                                                                                <td>
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td>
                                                                                    <asp:DropDownList ID="ddlAskerlikDurumu" runat="server" Width="256px">
                                                                                    </asp:DropDownList>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    Tip
                                                                                </td>
                                                                                <td>
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td>
                                                                                    <asp:DropDownList ID="ddlAskerlikTipi" runat="server" Width="256px">
                                                                                    </asp:DropDownList>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    Terhis Tarihi
                                                                                </td>
                                                                                <td>
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="txtAskerlikTerhisTarihi" runat="server" MaxLength="10" Width="250px"></asp:TextBox>
                                                                                    &nbsp;(örnek: 22/02/2001)
                                                                                    <asp:RegularExpressionValidator ID="revAskerlikTerhisTarihi" runat="server" ControlToValidate="txtAskerlikTerhisTarihi"
                                                                                        ErrorMessage="Tarih format&#305; yanl&#305;&#351;" ToolTip="Tarih format&#305; yanl&#305;&#351;"
                                                                                        ValidationExpression="^(((0[1-9]|[12]\d|3[01])\/(0[13578]|1[02])\/((19|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\/(0[13456789]|1[012])\/((19|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\/02\/((19|[2-9]\d)\d{2}))|(29\/02\/((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$">*</asp:RegularExpressionValidator>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    Tecil Tarihi
                                                                                </td>
                                                                                <td>
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="txtAskerlikTecilTarihi" runat="server" MaxLength="10" Width="250px"></asp:TextBox>
                                                                                    &nbsp;(örnek: 22/02/2001)
                                                                                    <asp:RegularExpressionValidator ID="revAskerlikTecilTarihi" runat="server" ControlToValidate="txtAskerlikTecilTarihi"
                                                                                        ErrorMessage="Tarih format&#305; yanl&#305;&#351;" ToolTip="Tarih format&#305; yanl&#305;&#351;"
                                                                                        ValidationExpression="^(((0[1-9]|[12]\d|3[01])\/(0[13578]|1[02])\/((19|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\/(0[13456789]|1[012])\/((19|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\/02\/((19|[2-9]\d)\d{2}))|(29\/02\/((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$">*</asp:RegularExpressionValidator>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    S&#305;n&#305;f&#305;n&#305;z (Topçu, Piyade vs)
                                                                                </td>
                                                                                <td>
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="txtAskerlikSinifi" runat="server" MaxLength="30" Width="250px"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    Muafiyet Nedeni
                                                                                </td>
                                                                                <td>
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="txtMuafNedeni" runat="server" MaxLength="80" Width="250px"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="padding-top: 15px; padding-bottom: 8px;">
                                                                                    <span style="font-size: 15px; font-weight: bold; color: #726F6D">E&#286;&#304;T&#304;M ÖZGEÇM&#304;&#350;&#304;</span>
                                                                                </td>
                                                                                <td style="padding-top: 15px; padding-bottom: 8px;">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td>
                                                                                    &nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    Ö&#287;renim Durumu
                                                                                </td>
                                                                                <td>
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td>
                                                                                    <asp:DropDownList ID="ddlOgrenimDurumu" runat="server" onchange="ddlEgitimDurumu_click()"
                                                                                        Width="256px">
                                                                                    </asp:DropDownList>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="3">
                                                                                    <table style="width: 780px" cellpadding="5px" id="ilkokul">
                                                                                        <tr>
                                                                                            <td style="width: 300px">
                                                                                                &#304;lkokul
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:TextBox ID="txtIlkokulAdi" runat="server" MaxLength="70" Width="250px"></asp:TextBox>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td>
                                                                                                &nbsp;&nbsp;&nbsp;&nbsp; Bölüm&nbsp;
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:TextBox ID="txtIlkokulBolum" runat="server" MaxLength="60" Width="250px"></asp:TextBox>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td>
                                                                                                &nbsp;&nbsp;&nbsp;&nbsp; Bitirme Y&#305;l&#305;&nbsp;
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:TextBox ID="txtIlkokulBitirmeYili" runat="server" MaxLength="4" Width="250px"></asp:TextBox>
                                                                                                &nbsp;(örnek: 1992)
                                                                                                <asp:RegularExpressionValidator ID="revIlkokulBitirmeYili" runat="server" ControlToValidate="txtIlkokulBitirmeYili"
                                                                                                    ErrorMessage="Y&#305;l format&#305; yanl&#305;&#351;" ToolTip="Y&#305;l format&#305; yanl&#305;&#351;"
                                                                                                    ValidationExpression="\d{4}">*</asp:RegularExpressionValidator>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                    <table style="width: 780px" cellpadding="5px" id="ortaokul">
                                                                                        <tr>
                                                                                            <td style="width: 300px">
                                                                                                Ortaokul
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:TextBox ID="txtOrtaokulAdi" runat="server" MaxLength="70" Width="250px"></asp:TextBox>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td>
                                                                                                &nbsp;&nbsp;&nbsp;&nbsp; Bölüm&nbsp;
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:TextBox ID="txtOrtaokulBolum" runat="server" MaxLength="60" Width="250px"></asp:TextBox>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td>
                                                                                                &nbsp;&nbsp;&nbsp;&nbsp; Bitirme Y&#305;l&#305;&nbsp;
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:TextBox ID="txtOrtaokulBitirmeYili" runat="server" MaxLength="4" Width="250px"></asp:TextBox>
                                                                                                &nbsp;(örnek: 1992)
                                                                                                <asp:RegularExpressionValidator ID="revOrtaokulBitirmeYili" runat="server" ControlToValidate="txtOrtaokulBitirmeYili"
                                                                                                    ErrorMessage="Y&#305;l format&#305; yanl&#305;&#351;" ToolTip="Y&#305;l format&#305; yanl&#305;&#351;"
                                                                                                    ValidationExpression="\d{4}">*</asp:RegularExpressionValidator>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                    <table style="width: 780px" cellpadding="5px" id="lise">
                                                                                        <tr>
                                                                                            <td style="width: 300px">
                                                                                                Lise
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:TextBox ID="txtLiseAdi" runat="server" MaxLength="70" Width="250px"></asp:TextBox>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td>
                                                                                                &nbsp;&nbsp;&nbsp;&nbsp; Bölüm&nbsp;
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:TextBox ID="txtLiseBolum" runat="server" MaxLength="60" Width="250px"></asp:TextBox>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td>
                                                                                                &nbsp;&nbsp;&nbsp;&nbsp; Bitirme Y&#305;l&#305;&nbsp;
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:TextBox ID="txtLiseBitirmeYili" runat="server" MaxLength="4" Width="250px"></asp:TextBox>
                                                                                                &nbsp;(örnek: 1992)
                                                                                                <asp:RegularExpressionValidator ID="revLiseBitirmeYili" runat="server" ControlToValidate="txtLiseBitirmeYili"
                                                                                                    ErrorMessage="Y&#305;l format&#305; yanl&#305;&#351;" ToolTip="Y&#305;l format&#305; yanl&#305;&#351;"
                                                                                                    ValidationExpression="\d{4}">*</asp:RegularExpressionValidator>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                    <table style="width: 780px" cellpadding="5px" id="universite">
                                                                                        <tr>
                                                                                            <td style="width: 300px">
                                                                                                Üniversite
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:TextBox ID="txtUniversiteAdi" runat="server" MaxLength="70" Width="250px"></asp:TextBox>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td>
                                                                                                &nbsp;&nbsp;&nbsp;&nbsp; Bölüm&nbsp;
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:TextBox ID="txtUniversiteBolum" runat="server" MaxLength="60" Width="250px"></asp:TextBox>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td>
                                                                                                &nbsp;&nbsp;&nbsp;&nbsp; Bitirme Y&#305;l&#305;&nbsp;
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:TextBox ID="txtUniversiteBitirmeYili" runat="server" MaxLength="4" Width="250px"></asp:TextBox>
                                                                                                &nbsp;(örnek: 1992)
                                                                                                <asp:RegularExpressionValidator ID="revUniversiteBitirmeYili" runat="server" ControlToValidate="txtUniversiteBitirmeYili"
                                                                                                    ErrorMessage="Y&#305;l format&#305; yanl&#305;&#351;" ToolTip="Y&#305;l format&#305; yanl&#305;&#351;"
                                                                                                    ValidationExpression="\d{4}">*</asp:RegularExpressionValidator>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                    <table style="width: 780px" cellpadding="5px" id="lisansustu">
                                                                                        <tr>
                                                                                            <td style="width: 300px">
                                                                                                Lisans Üstü
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:TextBox ID="txtLisansUstuAdi" runat="server" MaxLength="70" Width="250px"></asp:TextBox>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td>
                                                                                                &nbsp;&nbsp;&nbsp;&nbsp; Bölüm&nbsp;
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:TextBox ID="txtLisansUstuBolum" runat="server" MaxLength="60" Width="250px"></asp:TextBox>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td>
                                                                                                &nbsp;&nbsp;&nbsp;&nbsp; Bitirme Y&#305;l&#305;&nbsp;
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:TextBox ID="txtLisansUstuBitirmeYili" runat="server" MaxLength="4" Width="250px"></asp:TextBox>
                                                                                                &nbsp;(örnek: 1992)
                                                                                                <asp:RegularExpressionValidator ID="revLisansUstuBitirmeYili" runat="server" ControlToValidate="txtLisansUstuBitirmeYili"
                                                                                                    ErrorMessage="Y&#305;l format&#305; yanl&#305;&#351;" ToolTip="Y&#305;l format&#305; yanl&#305;&#351;"
                                                                                                    ValidationExpression="\d{4}">*</asp:RegularExpressionValidator>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                    <table style="width: 780px" cellpadding="5px" id="yuksekokul">
                                                                                        <tr>
                                                                                            <td style="width: 300px">
                                                                                                Yüksek Okul</td>
                                                                                            <td>
                                                                                                <asp:TextBox ID="txtYuksekOkulAdi" runat="server" MaxLength="70" Width="250px"></asp:TextBox>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td>
                                                                                                &nbsp;&nbsp;&nbsp;&nbsp; Bölüm&nbsp;
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:TextBox ID="txtYuksekOkulBolum" runat="server" MaxLength="60" Width="250px"></asp:TextBox>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td>
                                                                                                &nbsp;&nbsp;&nbsp;&nbsp; Bitirme Y&#305;l&#305;&nbsp;
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:TextBox ID="txtYuksekOkulBitirmeYili" runat="server" MaxLength="4" Width="250px"></asp:TextBox>
                                                                                                &nbsp;(örnek: 1992)
                                                                                                <asp:RegularExpressionValidator ID="revYuksekOkulBitirmeYili" runat="server" ControlToValidate="txtYuksekOkulBitirmeYili"
                                                                                                    ErrorMessage="Y&#305;l format&#305; yanl&#305;&#351;" ToolTip="Y&#305;l format&#305; yanl&#305;&#351;"
                                                                                                    ValidationExpression="\d{4}">*</asp:RegularExpressionValidator>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="padding-top: 15px; padding-bottom: 8px;">
                                                                                    <span style="font-size: 15px; font-weight: bold; color: #726F6D">KURS, SEM&#304;NER VE E&#286;&#304;T&#304;MLER</span>
                                                                                </td>
                                                                                <td style="padding-top: 15px; padding-bottom: 8px;">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td>
                                                                                    &nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td valign="top">
                                                                                    <br />
                                                                                    Kat&#305;ld&#305;&#287;&#305;n&#305;z Programlar
                                                                                </td>
                                                                                <td valign="top">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td>
                                                                                    <table cellpadding="5" cellspacing="0" style="width: 100%">
                                                                                        <tr>
                                                                                            <td style="width: 60%">
                                                                                                Kat&#305;ld&#305;&#287;&#305;n&#305;z kurs, seminer veya e&#287;itimlerin say&#305;s&#305;:
                                                                                            </td>
                                                                                            <td style="width: 40%">
                                                                                                <asp:DropDownList ID="ddlKacProgramKatildi" runat="server" onchange="ddlKacProgramKatildi_onclick()"
                                                                                                    Width="50px">
                                                                                                    <asp:ListItem Selected="True">0</asp:ListItem>
                                                                                                    <asp:ListItem Value="1">1</asp:ListItem>
                                                                                                    <asp:ListItem Value="2">2</asp:ListItem>
                                                                                                    <asp:ListItem Value="3">3</asp:ListItem>
                                                                                                    <asp:ListItem Value="4">4</asp:ListItem>
                                                                                                    <asp:ListItem Value="5">5</asp:ListItem>
                                                                                                </asp:DropDownList>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                    <table id="kacprogrambaslik" cellpadding="5" cellspacing="0" style="text-align: center"
                                                                                        visible="false">
                                                                                        <tr>
                                                                                            <td style="width: 120px">
                                                                                                Konusu
                                                                                            </td>
                                                                                            <td style="width: 130px">
                                                                                                Veren Kurulu&#351;
                                                                                            </td>
                                                                                            <td style="width: 110px">
                                                                                                Süresi
                                                                                            </td>
                                                                                            <td style="width: 50px">
                                                                                                Y&#305;l&#305;
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                    <table id="kacprogram1" cellpadding="5" cellspacing="0" style="text-align: center"
                                                                                        visible="false">
                                                                                        <tr>
                                                                                            <td>
                                                                                                <asp:TextBox ID="txtKurs1Konusu" runat="server" MaxLength="80" Width="120px"></asp:TextBox>
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:TextBox ID="txtKurs1VerenKurulus" runat="server" MaxLength="60" Width="120px"></asp:TextBox>
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:TextBox ID="txtKurs1Suresi" runat="server" MaxLength="20" Width="100px"></asp:TextBox>
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:TextBox ID="txtKurs1Yili" runat="server" MaxLength="4" Width="50px"></asp:TextBox>
                                                                                                &nbsp;<asp:RegularExpressionValidator ID="revKurs1Yili" runat="server" ControlToValidate="txtKurs1Yili"
                                                                                                    ErrorMessage="Y&#305;l format&#305; yanl&#305;&#351;" ToolTip="Y&#305;l format&#305; yanl&#305;&#351;"
                                                                                                    ValidationExpression="\d{4}">*</asp:RegularExpressionValidator>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                    <table id="kacprogram2" cellpadding="5" cellspacing="0" style="text-align: center"
                                                                                        visible="false">
                                                                                        <tr>
                                                                                            <td>
                                                                                                <asp:TextBox ID="txtKurs2Konusu" runat="server" MaxLength="80" Width="120px"></asp:TextBox>
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:TextBox ID="txtKurs2VerenKurulus" runat="server" MaxLength="60" Width="120px"></asp:TextBox>
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:TextBox ID="txtKurs2Suresi" runat="server" MaxLength="20" Width="100px"></asp:TextBox>
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:TextBox ID="txtKurs2Yili" runat="server" MaxLength="4" Width="50px"></asp:TextBox>
                                                                                                &nbsp;<asp:RegularExpressionValidator ID="revKurs2Yili" runat="server" ControlToValidate="txtKurs2Yili"
                                                                                                    ErrorMessage="Y&#305;l format&#305; yanl&#305;&#351;" ToolTip="Y&#305;l format&#305; yanl&#305;&#351;"
                                                                                                    ValidationExpression="\d{4}">*</asp:RegularExpressionValidator>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                    <table id="kacprogram3" cellpadding="5" cellspacing="0" style="text-align: center"
                                                                                        visible="false">
                                                                                        <tr>
                                                                                            <td>
                                                                                                <asp:TextBox ID="txtKurs3Konusu" runat="server" MaxLength="80" Width="120px"></asp:TextBox>
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:TextBox ID="txtKurs3VerenKurulus" runat="server" MaxLength="60" Width="120px"></asp:TextBox>
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:TextBox ID="txtKurs3Suresi" runat="server" MaxLength="20" Width="100px"></asp:TextBox>
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:TextBox ID="txtKurs3Yili" runat="server" MaxLength="4" Width="50px"></asp:TextBox>
                                                                                                &nbsp;<asp:RegularExpressionValidator ID="revKurs3Yili" runat="server" ControlToValidate="txtKurs3Yili"
                                                                                                    ErrorMessage="Y&#305;l format&#305; yanl&#305;&#351;" ToolTip="Y&#305;l format&#305; yanl&#305;&#351;"
                                                                                                    ValidationExpression="\d{4}">*</asp:RegularExpressionValidator>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                    <table id="kacprogram4" cellpadding="5" cellspacing="0" style="text-align: center"
                                                                                        visible="false">
                                                                                        <tr>
                                                                                            <td>
                                                                                                <asp:TextBox ID="txtKurs4Konusu" runat="server" MaxLength="80" Width="120px"></asp:TextBox>
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:TextBox ID="txtKurs4VerenKurulus" runat="server" MaxLength="60" Width="120px"></asp:TextBox>
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:TextBox ID="txtKurs4Suresi" runat="server" MaxLength="20" Width="100px"></asp:TextBox>
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:TextBox ID="txtKurs4Yili" runat="server" MaxLength="4" Width="50px"></asp:TextBox>
                                                                                                &nbsp;<asp:RegularExpressionValidator ID="revKurs4Yili" runat="server" ControlToValidate="txtKurs4Yili"
                                                                                                    ErrorMessage="Y&#305;l format&#305; yanl&#305;&#351;" ToolTip="Y&#305;l format&#305; yanl&#305;&#351;"
                                                                                                    ValidationExpression="\d{4}">*</asp:RegularExpressionValidator>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                    <table id="kacprogram5" cellpadding="5" cellspacing="0" style="text-align: center"
                                                                                        visible="false">
                                                                                        <tr>
                                                                                            <td>
                                                                                                <asp:TextBox ID="txtKurs5Konusu" runat="server" MaxLength="80" Width="120px"></asp:TextBox>
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:TextBox ID="txtKurs5VerenKurulus" runat="server" MaxLength="60" Width="120px"></asp:TextBox>
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:TextBox ID="txtKurs5Suresi" runat="server" MaxLength="20" Width="100px"></asp:TextBox>
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:TextBox ID="txtKurs5Yili" runat="server" MaxLength="4" Width="50px"></asp:TextBox>
                                                                                                &nbsp;<asp:RegularExpressionValidator ID="revKurs5Yili" runat="server" ControlToValidate="txtKurs5Yili"
                                                                                                    ErrorMessage="Y&#305;l format&#305; yanl&#305;&#351;" ToolTip="Y&#305;l format&#305; yanl&#305;&#351;"
                                                                                                    ValidationExpression="\d{4}">*</asp:RegularExpressionValidator>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="padding-top: 8px; padding-bottom: 8px;">
                                                                                    <span style="font-size: 15px; font-weight: bold; color: #726F6D">YABANCI D&#304;L B&#304;LG&#304;S&#304;</span>
                                                                                </td>
                                                                                <td style="padding-top: 8px; padding-bottom: 8px;">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td>
                                                                                    &nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    Bildi&#287;iniz Yabanc&#305; Diller
                                                                                </td>
                                                                                <td>
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td>
                                                                                    <asp:CheckBoxList ID="cblYabanciDiller" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cblYabanciDiller_SelectedIndexChanged"
                                                                                        RepeatDirection="Horizontal" RepeatLayout="Flow">
                                                                                    </asp:CheckBoxList>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td>
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td>
                                                                                    <asp:UpdatePanel ID="upYabanciDiller" runat="server">
                                                                                        <ContentTemplate>
                                                                                            <asp:Panel ID="pnlYabanciDiller" runat="server">
                                                                                                <table cellpadding="0" cellspacing="0" style="text-align: center" runat="server" id="tblDil" visible="false">
                                                                                                    <tr>
                                                                                                        <td style="width: 150px">
                                                                                                        </td>
                                                                                                        <td style="width: 90px">
                                                                                                            Okuma
                                                                                                        </td>
                                                                                                        <td style="width: 90px">
                                                                                                            Yazma
                                                                                                        </td>
                                                                                                        <td style="width: 90px">
                                                                                                            Konu&#351;ma
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                                <div runat="server" id="divDil1" style="padding: 3px; padding-left: 5px; padding-right: 5px" visible="false">
                                                                                                    <asp:Label runat="server" ID="lblDil1" Width="160px"></asp:Label>
                                                                                                    <asp:DropDownList ID="ddlDil1Okuma" runat="server" Width="60px">
                                                                                                    </asp:DropDownList>
                                                                                                    <img alt="spacer" src="images/spacer.gif" width="24px" height="1px" />
                                                                                                    <asp:DropDownList ID="ddlDil1Yazma" runat="server" Width="60px">
                                                                                                    </asp:DropDownList>
                                                                                                    <img alt="spacer" src="images/spacer.gif" width="24px" height="1px" />
                                                                                                    <asp:DropDownList ID="ddlDil1Konusma" runat="server" Width="60px">
                                                                                                    </asp:DropDownList>
                                                                                                </div>
                                                                                                <div runat="server" id="divDil2" style="padding: 3px; padding-left: 5px; padding-right: 5px" visible="false">
                                                                                                    <asp:Label runat="server" ID="lblDil2" Width="160px"></asp:Label>
                                                                                                    <asp:DropDownList ID="ddlDil2Okuma" runat="server" Width="60px">
                                                                                                    </asp:DropDownList>
                                                                                                    <img alt="spacer" src="images/spacer.gif" width="24px" height="1px" />
                                                                                                    <asp:DropDownList ID="ddlDil2Yazma" runat="server" Width="60px">
                                                                                                    </asp:DropDownList>
                                                                                                    <img alt="spacer" src="images/spacer.gif" width="24px" height="1px" />
                                                                                                    <asp:DropDownList ID="ddlDil2Konusma" runat="server" Width="60px">
                                                                                                    </asp:DropDownList>
                                                                                                </div>
                                                                                                <div runat="server" id="divDil3" style="padding: 3px; padding-left: 5px; padding-right: 5px" visible="false">
                                                                                                    <asp:Label runat="server" ID="lblDil3" Width="160px"></asp:Label>
                                                                                                    <asp:DropDownList ID="ddlDil3Okuma" runat="server" Width="60px">
                                                                                                    </asp:DropDownList>
                                                                                                    <img alt="spacer" src="images/spacer.gif" width="24px" height="1px" />
                                                                                                    <asp:DropDownList ID="ddlDil3Yazma" runat="server" Width="60px">
                                                                                                    </asp:DropDownList>
                                                                                                    <img alt="spacer" src="images/spacer.gif" width="24px" height="1px" />
                                                                                                    <asp:DropDownList ID="ddlDil3Konusma" runat="server" Width="60px">
                                                                                                    </asp:DropDownList>
                                                                                                </div>
                                                                                                <div runat="server" id="divDil4" style="padding: 3px; padding-left: 5px; padding-right: 5px" visible="false">
                                                                                                    <asp:Label runat="server" ID="lblDil4" Width="160px"></asp:Label>
                                                                                                    <asp:DropDownList ID="ddlDil4Okuma" runat="server" Width="60px">
                                                                                                    </asp:DropDownList>
                                                                                                    <img alt="spacer" src="images/spacer.gif" width="24px" height="1px" />
                                                                                                    <asp:DropDownList ID="ddlDil4Yazma" runat="server" Width="60px">
                                                                                                    </asp:DropDownList>
                                                                                                    <img alt="spacer" src="images/spacer.gif" width="24px" height="1px" />
                                                                                                    <asp:DropDownList ID="ddlDil4Konusma" runat="server" Width="60px">
                                                                                                    </asp:DropDownList>
                                                                                                </div>
                                                                                                <div runat="server" id="divDil5" style="padding: 3px; padding-left: 5px; padding-right: 5px" visible="false">
                                                                                                    <asp:Label runat="server" ID="lblDil5" Width="160px"></asp:Label>
                                                                                                    <asp:DropDownList ID="ddlDil5Okuma" runat="server" Width="60px">
                                                                                                    </asp:DropDownList>
                                                                                                    <img alt="spacer" src="images/spacer.gif" width="24px" height="1px" />
                                                                                                    <asp:DropDownList ID="ddlDil5Yazma" runat="server" Width="60px">
                                                                                                    </asp:DropDownList>
                                                                                                    <img alt="spacer" src="images/spacer.gif" width="24px" height="1px" />
                                                                                                    <asp:DropDownList ID="ddlDil5Konusma" runat="server" Width="60px">
                                                                                                    </asp:DropDownList>
                                                                                                </div>
                                                                                                <div runat="server" id="divDil6" style="padding: 3px; padding-left: 5px; padding-right: 5px" visible="false">
                                                                                                    <asp:Label runat="server" ID="lblDil6" Width="160px"></asp:Label>
                                                                                                    <asp:DropDownList ID="ddlDil6Okuma" runat="server" Width="60px">
                                                                                                    </asp:DropDownList>
                                                                                                    <img alt="spacer" src="images/spacer.gif" width="24px" height="1px" />
                                                                                                    <asp:DropDownList ID="ddlDil6Yazma" runat="server" Width="60px">
                                                                                                    </asp:DropDownList>
                                                                                                    <img alt="spacer" src="images/spacer.gif" width="24px" height="1px" />
                                                                                                    <asp:DropDownList ID="ddlDil6Konusma" runat="server" Width="60px">
                                                                                                    </asp:DropDownList>
                                                                                                </div>
                                                                                                <div runat="server" id="divDil7" style="padding: 3px; padding-left: 5px; padding-right: 5px" visible="false">
                                                                                                    <asp:Label runat="server" ID="lblDil7" Width="160px"></asp:Label>
                                                                                                    <asp:DropDownList ID="ddlDil7Okuma" runat="server" Width="60px">
                                                                                                    </asp:DropDownList>
                                                                                                    <img alt="spacer" src="images/spacer.gif" width="24px" height="1px" />
                                                                                                    <asp:DropDownList ID="ddlDil7Yazma" runat="server" Width="60px">
                                                                                                    </asp:DropDownList>
                                                                                                    <img alt="spacer" src="images/spacer.gif" width="24px" height="1px" />
                                                                                                    <asp:DropDownList ID="ddlDil7Konusma" runat="server" Width="60px">
                                                                                                    </asp:DropDownList>
                                                                                                </div>
                                                                                                <div runat="server" id="divDil8" style="padding: 3px; padding-left: 5px; padding-right: 5px" visible="false">
                                                                                                    <asp:Label runat="server" ID="lblDil8" Width="160px"></asp:Label>
                                                                                                    <asp:DropDownList ID="ddlDil8Okuma" runat="server" Width="60px">
                                                                                                    </asp:DropDownList>
                                                                                                    <img alt="spacer" src="images/spacer.gif" width="24px" height="1px" />
                                                                                                    <asp:DropDownList ID="ddlDil8Yazma" runat="server" Width="60px">
                                                                                                    </asp:DropDownList>
                                                                                                    <img alt="spacer" src="images/spacer.gif" width="24px" height="1px" />
                                                                                                    <asp:DropDownList ID="ddlDil8Konusma" runat="server" Width="60px">
                                                                                                    </asp:DropDownList>
                                                                                                </div>
                                                                                                <div runat="server" id="divDil9" style="padding: 3px; padding-left: 5px; padding-right: 5px" visible="false">
                                                                                                    <asp:Label runat="server" ID="lblDil9" Width="160px"></asp:Label>
                                                                                                    <asp:DropDownList ID="ddlDil9Okuma" runat="server" Width="60px">
                                                                                                    </asp:DropDownList>
                                                                                                    <img alt="spacer" src="images/spacer.gif" width="24px" height="1px" />
                                                                                                    <asp:DropDownList ID="ddlDil9Yazma" runat="server" Width="60px">
                                                                                                    </asp:DropDownList>
                                                                                                    <img alt="spacer" src="images/spacer.gif" width="24px" height="1px" />
                                                                                                    <asp:DropDownList ID="ddlDil9Konusma" runat="server" Width="60px">
                                                                                                    </asp:DropDownList>
                                                                                                </div>
                                                                                                <div runat="server" id="divDil10" style="padding: 3px; padding-left: 5px; padding-right: 5px" visible="false">
                                                                                                    <asp:Label runat="server" ID="lblDil10" Width="160px"></asp:Label>
                                                                                                    <asp:DropDownList ID="ddlDil10Okuma" runat="server" Width="60px">
                                                                                                    </asp:DropDownList>
                                                                                                    <img alt="spacer" src="images/spacer.gif" width="24px" height="1px" />
                                                                                                    <asp:DropDownList ID="ddlDil10Yazma" runat="server" Width="60px">
                                                                                                    </asp:DropDownList>
                                                                                                    <img alt="spacer" src="images/spacer.gif" width="24px" height="1px" />
                                                                                                    <asp:DropDownList ID="ddlDil10Konusma" runat="server" Width="60px">
                                                                                                    </asp:DropDownList>
                                                                                                </div>
                                                                                            </asp:Panel>
                                                                                        </ContentTemplate>
                                                                                        <Triggers>
                                                                                            <asp:AsyncPostBackTrigger ControlID="cblYabanciDiller" EventName="SelectedIndexChanged" />
                                                                                        </Triggers>
                                                                                    </asp:UpdatePanel>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="padding-top: 15px; padding-bottom: 8px;">
                                                                                    <span style="font-size: 15px; font-weight: bold; color: #726F6D">ÇALI&#350;MA YA&#350;AMI (&#304;&#350; DENEY&#304;MLER&#304;)</span>
                                                                                </td>
                                                                                <td style="padding-top: 15px; padding-bottom: 8px;">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td>
                                                                                    &nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="3">
                                                                                    &#350;u anda çal&#305;&#351;&#305;yor musunuz:
                                                                                    <asp:RadioButton ID="rbSuAndaCalisiyorMuEvet" runat="server" Style="padding-left: 180px"
                                                                                        GroupName="grSuAndaCalisiyorMu" Text="Evet" onclick="rbSuAndaCalisiyorMu_click()" />
                                                                                    <asp:RadioButton ID="rbSuAndaCalisiyorMuHayir" runat="server" Checked="True" GroupName="grSuAndaCalisiyorMu"
                                                                                        Text="Hay&#305;r" onclick="rbSuAndaCalisiyorMu_click()" />
                                                                                    <table id="suandacalisiyor" cellpadding="5" cellspacing="0" style="text-align: center"
                                                                                        visible="false">
                                                                                        <tr>
                                                                                            <td style="padding-top: 15px">
                                                                                                &#304;&#351;yeri Ad&#305;
                                                                                            </td>
                                                                                            <td style="padding-top: 15px">
                                                                                                Göreviniz
                                                                                            </td>
                                                                                            <td style="padding-top: 15px">
                                                                                                Giri&#351; Tarihi
                                                                                                <asp:RegularExpressionValidator ID="revSimdikiIsGirisTarihi" runat="server" ControlToValidate="txtSimdikiIsGirisTarihi"
                                                                                                    ErrorMessage="Tarih format&#305; yanl&#305;&#351;" ToolTip="Tarih format&#305; yanl&#305;&#351;"
                                                                                                    ValidationExpression="^(((0[1-9]|[12]\d|3[01])\/(0[13578]|1[02])\/((19|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\/(0[13456789]|1[012])\/((19|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\/02\/((19|[2-9]\d)\d{2}))|(29\/02\/((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$">*</asp:RegularExpressionValidator>
                                                                                            </td>
                                                                                            <td style="padding-top: 15px">
                                                                                                Ç&#305;kaca&#287;&#305;n&#305;z Tarih
                                                                                                <asp:RegularExpressionValidator ID="revSimdikiIsCikisTarihi" runat="server" ControlToValidate="txtSimdikiIsCikisTarihi"
                                                                                                    ErrorMessage="Tarih format&#305; yanl&#305;&#351;" ToolTip="Tarih format&#305; yanl&#305;&#351;"
                                                                                                    ValidationExpression="^(((0[1-9]|[12]\d|3[01])\/(0[13578]|1[02])\/((19|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\/(0[13456789]|1[012])\/((19|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\/02\/((19|[2-9]\d)\d{2}))|(29\/02\/((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$">*</asp:RegularExpressionValidator>
                                                                                            </td>
                                                                                            <td style="padding-top: 15px">
                                                                                                Ücret
                                                                                            </td>
                                                                                            <td style="padding-top: 15px">
                                                                                                Ayr&#305;lma Nedeni
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td>
                                                                                                <asp:TextBox ID="txtSimdikiIsIsyeriAdi" runat="server" MaxLength="25" 
                                                                                                    Width="120px"></asp:TextBox>
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:TextBox ID="txtSimdikiIsGorev" runat="server" MaxLength="25" Width="120px"></asp:TextBox>
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:TextBox ID="txtSimdikiIsGirisTarihi" runat="server" MaxLength="10" Width="100px"></asp:TextBox>
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:TextBox ID="txtSimdikiIsCikisTarihi" runat="server" MaxLength="10" Width="100px"></asp:TextBox>
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:TextBox ID="txtSimdikiIsUcret" runat="server" MaxLength="50" Width="100px"></asp:TextBox>
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:TextBox ID="txtSimdikiIsAyrilmaNedeni" runat="server" MaxLength="150" Width="150px"></asp:TextBox>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    Önceki &#304;&#351;yerleriniz
                                                                                </td>
                                                                                <td>
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td>
                                                                                    Çal&#305;&#351;t&#305;&#287;&#305;n&#305;z i&#351;yeri say&#305;s&#305;:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                                    <asp:DropDownList ID="ddlKacIsYeri" runat="server" onchange="ddlKacIsYeri_click()"
                                                                                        Width="50px">
                                                                                        <asp:ListItem Selected="True" Value="0">0</asp:ListItem>
                                                                                        <asp:ListItem Value="1">1</asp:ListItem>
                                                                                        <asp:ListItem Value="2">2</asp:ListItem>
                                                                                        <asp:ListItem Value="3">3</asp:ListItem>
                                                                                        <asp:ListItem Value="4">4</asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="3">
                                                                                    <table id="isyeribaslik" cellpadding="5" cellspacing="0" style="text-align: center"
                                                                                        visible="false">
                                                                                        <tr>
                                                                                            <td style="padding-top: 15px; width: 120px;">
                                                                                                &#304;&#351;yeri Ad&#305;
                                                                                            </td>
                                                                                            <td style="padding-top: 15px; width: 130px;">
                                                                                                Göreviniz
                                                                                            </td>
                                                                                            <td style="padding-top: 15px; width: 110px;">
                                                                                                Giri&#351; Tarihi
                                                                                            </td>
                                                                                            <td style="padding-top: 15px; width: 80px;">
                                                                                                Ç&#305;k&#305;&#351; Tarihi
                                                                                            </td>
                                                                                            <td style="padding-top: 15px; width: 110px;">
                                                                                                Ücret
                                                                                            </td>
                                                                                            <td style="padding-top: 15px; width: 150px;">
                                                                                                Ayr&#305;lma Nedeni
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                    <table id="isyeri1" cellpadding="5" cellspacing="0" style="text-align: center" visible="false">
                                                                                        <tr>
                                                                                            <td>
                                                                                                <asp:TextBox ID="txtIsIsyeri1Adi" runat="server" MaxLength="25" Width="120px"></asp:TextBox>
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:TextBox ID="txtIsIsyeri1Gorev" runat="server" MaxLength="25" Width="120px"></asp:TextBox>
                                                                                            </td>
                                                                                            <td>
                                                                                                &nbsp;&nbsp;
                                                                                                <asp:TextBox ID="txtIsIsyeri1GirisTarihi" runat="server" MaxLength="10" Width="80px"></asp:TextBox>
                                                                                                &nbsp;<asp:RegularExpressionValidator ID="revIsIsyeri1GirisTarihi" runat="server"
                                                                                                    ControlToValidate="txtIsIsyeri1GirisTarihi" ErrorMessage="Tarih format&#305; yanl&#305;&#351;"
                                                                                                    ToolTip="Tarih format&#305; yanl&#305;&#351;" ValidationExpression="^(((0[1-9]|[12]\d|3[01])\/(0[13578]|1[02])\/((19|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\/(0[13456789]|1[012])\/((19|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\/02\/((19|[2-9]\d)\d{2}))|(29\/02\/((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$">*</asp:RegularExpressionValidator>
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:TextBox ID="txtIsIsyeri1CikisTarihi" runat="server" MaxLength="10" Width="80px"></asp:TextBox>
                                                                                                &nbsp;<asp:RegularExpressionValidator ID="revIsIsyeri1CikisTarihi" runat="server"
                                                                                                    ControlToValidate="txtIsIsyeri1CikisTarihi" ErrorMessage="Tarih format&#305; yanl&#305;&#351;"
                                                                                                    ToolTip="Tarih format&#305; yanl&#305;&#351;" ValidationExpression="^(((0[1-9]|[12]\d|3[01])\/(0[13578]|1[02])\/((19|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\/(0[13456789]|1[012])\/((19|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\/02\/((19|[2-9]\d)\d{2}))|(29\/02\/((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$">*</asp:RegularExpressionValidator>
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:TextBox ID="txtIsIsyeri1Ucret" runat="server" MaxLength="50" Width="100px"></asp:TextBox>
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:TextBox ID="txtIsIsyeri1AyrilmaNedeni" runat="server" MaxLength="150" Width="150px"></asp:TextBox>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                    <table id="isyeri2" cellpadding="5" cellspacing="0" style="text-align: center" visible="false">
                                                                                        <tr>
                                                                                            <td>
                                                                                                <asp:TextBox ID="txtIsIsyeri2Adi" runat="server" MaxLength="25" Width="120px"></asp:TextBox>
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:TextBox ID="txtIsIsyeri2Gorev" runat="server" MaxLength="25" Width="120px"></asp:TextBox>
                                                                                            </td>
                                                                                            <td>
                                                                                                &nbsp;&nbsp;
                                                                                                <asp:TextBox ID="txtIsIsyeri2GirisTarihi" runat="server" MaxLength="10" Width="80px"></asp:TextBox>
                                                                                                &nbsp;<asp:RegularExpressionValidator ID="revIsIsyeri2GirisTarihi" runat="server"
                                                                                                    ControlToValidate="txtIsIsyeri2GirisTarihi" ErrorMessage="Tarih format&#305; yanl&#305;&#351;"
                                                                                                    ToolTip="Tarih format&#305; yanl&#305;&#351;" ValidationExpression="^(((0[1-9]|[12]\d|3[01])\/(0[13578]|1[02])\/((19|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\/(0[13456789]|1[012])\/((19|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\/02\/((19|[2-9]\d)\d{2}))|(29\/02\/((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$">*</asp:RegularExpressionValidator>
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:TextBox ID="txtIsIsyeri2CikisTarihi" runat="server" MaxLength="10" Width="80px"></asp:TextBox>
                                                                                                &nbsp;<asp:RegularExpressionValidator ID="revIsIsyeri2CikisTarihi" runat="server"
                                                                                                    ControlToValidate="txtIsIsyeri2CikisTarihi" ErrorMessage="Tarih format&#305; yanl&#305;&#351;"
                                                                                                    ToolTip="Tarih format&#305; yanl&#305;&#351;" ValidationExpression="^(((0[1-9]|[12]\d|3[01])\/(0[13578]|1[02])\/((19|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\/(0[13456789]|1[012])\/((19|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\/02\/((19|[2-9]\d)\d{2}))|(29\/02\/((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$">*</asp:RegularExpressionValidator>
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:TextBox ID="txtIsIsyeri2Ucret" runat="server" MaxLength="50" Width="100px"></asp:TextBox>
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:TextBox ID="txtIsIsyeri2AyrilmaNedeni" runat="server" MaxLength="150" Width="150px"></asp:TextBox>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                    <table id="isyeri3" cellpadding="5" cellspacing="0" style="text-align: center" visible="false">
                                                                                        <tr>
                                                                                            <td>
                                                                                                <asp:TextBox ID="txtIsIsyeri3Adi" runat="server" MaxLength="25" Width="120px"></asp:TextBox>
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:TextBox ID="txtIsIsyeri3Gorev" runat="server" MaxLength="25" Width="120px"></asp:TextBox>
                                                                                            </td>
                                                                                            <td>
                                                                                                &nbsp;&nbsp;
                                                                                                <asp:TextBox ID="txtIsIsyeri3GirisTarihi" runat="server" MaxLength="10" Width="80px"></asp:TextBox>
                                                                                                &nbsp;<asp:RegularExpressionValidator ID="revIsIsyeri3GirisTarihi" runat="server"
                                                                                                    ControlToValidate="txtIsIsyeri3GirisTarihi" ErrorMessage="Tarih format&#305; yanl&#305;&#351;"
                                                                                                    ToolTip="Tarih format&#305; yanl&#305;&#351;" ValidationExpression="^(((0[1-9]|[12]\d|3[01])\/(0[13578]|1[02])\/((19|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\/(0[13456789]|1[012])\/((19|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\/02\/((19|[2-9]\d)\d{2}))|(29\/02\/((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$">*</asp:RegularExpressionValidator>
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:TextBox ID="txtIsIsyeri3CikisTarihi" runat="server" MaxLength="10" Width="80px"></asp:TextBox>
                                                                                                &nbsp;<asp:RegularExpressionValidator ID="revIsIsyeri3CikisTarihi" runat="server"
                                                                                                    ControlToValidate="txtIsIsyeri3CikisTarihi" ErrorMessage="Tarih format&#305; yanl&#305;&#351;"
                                                                                                    ToolTip="Tarih format&#305; yanl&#305;&#351;" ValidationExpression="^(((0[1-9]|[12]\d|3[01])\/(0[13578]|1[02])\/((19|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\/(0[13456789]|1[012])\/((19|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\/02\/((19|[2-9]\d)\d{2}))|(29\/02\/((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$">*</asp:RegularExpressionValidator>
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:TextBox ID="txtIsIsyeri3Ucret" runat="server" MaxLength="50" Width="100px"></asp:TextBox>
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:TextBox ID="txtIsIsyeri3AyrilmaNedeni" runat="server" MaxLength="150" Width="150px"></asp:TextBox>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                    <table id="isyeri4" cellpadding="5" cellspacing="0" style="text-align: center" visible="false">
                                                                                        <tr>
                                                                                            <td>
                                                                                                <asp:TextBox ID="txtIsIsyeri4Adi" runat="server" MaxLength="25" Width="120px"></asp:TextBox>
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:TextBox ID="txtIsIsyeri4Gorev" runat="server" MaxLength="25" Width="120px"></asp:TextBox>
                                                                                            </td>
                                                                                            <td>
                                                                                                &nbsp;&nbsp;
                                                                                                <asp:TextBox ID="txtIsIsyeri4GirisTarihi" runat="server" MaxLength="10" Width="80px"></asp:TextBox>
                                                                                                &nbsp;<asp:RegularExpressionValidator ID="revIsIsyeri4GirisTarihi" runat="server"
                                                                                                    ControlToValidate="txtIsIsyeri4GirisTarihi" ErrorMessage="Tarih format&#305; yanl&#305;&#351;"
                                                                                                    ToolTip="Tarih format&#305; yanl&#305;&#351;" ValidationExpression="^(((0[1-9]|[12]\d|3[01])\/(0[13578]|1[02])\/((19|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\/(0[13456789]|1[012])\/((19|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\/02\/((19|[2-9]\d)\d{2}))|(29\/02\/((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$">*</asp:RegularExpressionValidator>
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:TextBox ID="txtIsIsyeri4CikisTarihi" runat="server" MaxLength="10" Width="80px"></asp:TextBox>
                                                                                                &nbsp;<asp:RegularExpressionValidator ID="revIsIsyeri4CikisTarihi" runat="server"
                                                                                                    ControlToValidate="txtIsIsyeri4CikisTarihi" ErrorMessage="Tarih format&#305; yanl&#305;&#351;"
                                                                                                    ToolTip="Tarih format&#305; yanl&#305;&#351;" ValidationExpression="^(((0[1-9]|[12]\d|3[01])\/(0[13578]|1[02])\/((19|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\/(0[13456789]|1[012])\/((19|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\/02\/((19|[2-9]\d)\d{2}))|(29\/02\/((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$">*</asp:RegularExpressionValidator>
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:TextBox ID="txtIsIsyeri4Ucret" runat="server" MaxLength="50" Width="100px"></asp:TextBox>
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:TextBox ID="txtIsIsyeri4AyrilmaNedeni" runat="server" MaxLength="150" Width="150px"></asp:TextBox>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="padding-top: 15px; padding-bottom: 8px;">
                                                                                    <span style="font-size: 15px; font-weight: bold; color: #726F6D">D&#304;&#286;ER B&#304;LG&#304;LER</span>
                                                                                </td>
                                                                                <td style="padding-top: 15px; padding-bottom: 8px;">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td>
                                                                                    &nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    Herhangi bir nedenle devam eden mahkemeniz var m&#305;?
                                                                                </td>
                                                                                <td>
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td>
                                                                                    <asp:RadioButton ID="rbMahkemeVar" runat="server" GroupName="grMahkeme" Text="Var" />
                                                                                    <asp:RadioButton ID="rbMahkemeYok" runat="server" Checked="True" GroupName="grMahkeme"
                                                                                        Text="Yok" />
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    &nbsp;&nbsp;&nbsp;&nbsp; Varsa neden?&nbsp;
                                                                                </td>
                                                                                <td>
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="txtMahkemeNedeni" runat="server" MaxLength="100" Width="250px"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    &nbsp;&nbsp;&nbsp;&nbsp; En yak&#305;n duru&#351;ma tarihi&nbsp;
                                                                                </td>
                                                                                <td>
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="txtMahkemeDurusmaTarihi" runat="server" MaxLength="10" Width="250px"></asp:TextBox>
                                                                                    &nbsp;(örnek: 15/05/2011)
                                                                                    <asp:RegularExpressionValidator ID="revMahkemeDurusmaTarihi" runat="server" ControlToValidate="txtMahkemeDurusmaTarihi"
                                                                                        ErrorMessage="Tarih format&#305; yanl&#305;&#351;" ToolTip="Tarih format&#305; yanl&#305;&#351;"
                                                                                        ValidationExpression="^(((0[1-9]|[12]\d|3[01])\/(0[13578]|1[02])\/((19|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\/(0[13456789]|1[012])\/((19|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\/02\/((19|[2-9]\d)\d{2}))|(29\/02\/((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$">*</asp:RegularExpressionValidator>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    Herhangi bir nedenle devam eden mahkumiyetiniz var m&#305;?
                                                                                </td>
                                                                                <td>
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td>
                                                                                    <asp:RadioButton ID="rbMahkumiyetVar" runat="server" GroupName="grMahkumiyet" Text="Var" />
                                                                                    <asp:RadioButton ID="rbMahkumiyetYok" runat="server" Checked="True" GroupName="grMahkumiyet"
                                                                                        Text="Yok" />
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    &nbsp;&nbsp;&nbsp;&nbsp; Varsa nedeni, süresi&nbsp;
                                                                                </td>
                                                                                <td>
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="txtMahkumiyetNedeni" runat="server" MaxLength="100" Width="250px"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    &nbsp;&nbsp;&nbsp;&nbsp; Tahliye tarihi&nbsp;
                                                                                </td>
                                                                                <td>
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="txtMahkumiyetTahliyeTarihi" runat="server" MaxLength="10" Width="250px"></asp:TextBox>
                                                                                    &nbsp;(örnek: 15/05/2011)
                                                                                    <asp:RegularExpressionValidator ID="revMahkumiyetTahliyeTarihi" runat="server" ControlToValidate="txtMahkumiyetTahliyeTarihi"
                                                                                        ErrorMessage="Tarih format&#305; yanl&#305;&#351;" ToolTip="Tarih format&#305; yanl&#305;&#351;"
                                                                                        ValidationExpression="^(((0[1-9]|[12]\d|3[01])\/(0[13578]|1[02])\/((19|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\/(0[13456789]|1[012])\/((19|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\/02\/((19|[2-9]\d)\d{2}))|(29\/02\/((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$">*</asp:RegularExpressionValidator>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    Bakmakla yükümlü oldu&#287;unuz 1. ve 2. derece yak&#305;nlar&#305;n&#305;z
                                                                                </td>
                                                                                <td>
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="txtBakmaklaYukumluYakin" runat="server" MaxLength="100" Width="250px"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    Sürekli tedaviye muhtaç 1. ve 2. derece yak&#305;nlar&#305;n&#305;z
                                                                                </td>
                                                                                <td>
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="txtTedaviyeMuhtacYakin" runat="server" MaxLength="100" Width="250px"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    Ücret D&#305;&#351;&#305; Di&#287;er Gelirleriniz
                                                                                </td>
                                                                                <td>
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td>
                                                                                    <asp:CheckBoxList ID="cblGelirler" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cblGelirler_SelectedIndexChanged"
                                                                                        RepeatDirection="Horizontal" RepeatLayout="Flow">
                                                                                    </asp:CheckBoxList>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                </td>
                                                                                <td>
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td>
                                                                                    <asp:UpdatePanel ID="upGelirler" runat="server">
                                                                                        <ContentTemplate>
                                                                                            <asp:Panel ID="pnlGelirler" runat="server">
                                                                                                <table runat="server" id="tblGelir" visible="false">
                                                                                                    <tr>
                                                                                                        <td style="width: 140px">
                                                                                                        </td>
                                                                                                        <td style="width: 140px" align="center">
                                                                                                            Tutar
                                                                                                        </td>
                                                                                                        <td style="width: 200px" align="center">
                                                                                                            Aç&#305;klama
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                                <div runat="server" id="divGelir1" visible="false" style="padding: 3px">
                                                                                                            <asp:Label ID="lblGelir1" runat="server" Width="140px"></asp:Label>
                                                                                                            <asp:TextBox ID="txtGelir1Tutar" runat="server" Width="130px"></asp:TextBox>&nbsp;
                                                                                                            <asp:TextBox ID="txtGelir1Aciklama" runat="server" Width="160px"></asp:TextBox>
                                                                                                </div>
                                                                                                <div runat="server" id="divGelir2" visible="false" style="padding: 3px">
                                                                                                            <asp:Label ID="lblGelir2" runat="server" Width="140px"></asp:Label>
                                                                                                            <asp:TextBox ID="txtGelir2Tutar" runat="server" Width="130px"></asp:TextBox>&nbsp;
                                                                                                            <asp:TextBox ID="txtGelir2Aciklama" runat="server" Width="160px"></asp:TextBox>
                                                                                                </div>
                                                                                                <div runat="server" id="divGelir3" visible="false" style="padding: 3px">
                                                                                                            <asp:Label ID="lblGelir3" runat="server" Width="140px"></asp:Label>
                                                                                                            <asp:TextBox ID="txtGelir3Tutar" runat="server" Width="130px"></asp:TextBox>&nbsp;
                                                                                                            <asp:TextBox ID="txtGelir3Aciklama" runat="server" Width="160px"></asp:TextBox>
                                                                                                </div>
                                                                                                <div runat="server" id="divGelir4" visible="false" style="padding: 3px">
                                                                                                            <asp:Label ID="lblGelir4" runat="server" Width="140px"></asp:Label>
                                                                                                            <asp:TextBox ID="txtGelir4Tutar" runat="server" Width="130px"></asp:TextBox>&nbsp;
                                                                                                            <asp:TextBox ID="txtGelir4Aciklama" runat="server" Width="160px"></asp:TextBox>
                                                                                                </div>
                                                                                                <div runat="server" id="divGelir5" visible="false" style="padding: 3px">
                                                                                                            <asp:Label ID="lblGelir5" runat="server" Width="140px"></asp:Label>
                                                                                                            <asp:TextBox ID="txtGelir5Tutar" runat="server" Width="130px"></asp:TextBox>&nbsp;
                                                                                                            <asp:TextBox ID="txtGelir5Aciklama" runat="server" Width="160px"></asp:TextBox>
                                                                                                </div>
                                                                                            </asp:Panel>
                                                                                        </ContentTemplate>
                                                                                        <Triggers>
                                                                                            <asp:AsyncPostBackTrigger ControlID="cblGelirler" EventName="SelectedIndexChanged" />
                                                                                        </Triggers>
                                                                                    </asp:UpdatePanel>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    Tedavisi süren herhangi bir hastal&#305;&#287;&#305;n&#305;z var m&#305;?
                                                                                </td>
                                                                                <td>
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="txtSurenHastalik" runat="server" MaxLength="100" Width="250px"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    Varsa geçirdi&#287;iniz önemli hastal&#305;klar ve/veya t&#305;bbi ameliyatlar
                                                                                </td>
                                                                                <td>
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="txtOnemliAmeliyat" runat="server" MaxLength="100" Width="250px"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    Herhangi bir sakatl&#305;&#287;&#305;n&#305;z var m&#305;? Varsa oran&#305;?
                                                                                </td>
                                                                                <td>
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="txtSakatlik" runat="server" MaxLength="100" Width="250px"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    Kredi kart&#305;ndan dolay&#305; yasal takibata ugrad&#305;n&#305;z m&#305;? Aç&#305;klay&#305;n&#305;z
                                                                                </td>
                                                                                <td>
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="txtKrediKartiTakibat" runat="server" MaxLength="150" Width="250px"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td valign="top">
                                                                                    <br />
                                                                                    Kredi Kartlar&#305;n&#305;z
                                                                                </td>
                                                                                <td valign="top">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td>
                                                                                    <table cellpadding="5" cellspacing="0" style="width: 100%">
                                                                                        <tr>
                                                                                            <td style="width: 43%">
                                                                                                Kaç tane kredi kart&#305;na sahipsiniz:
                                                                                            </td>
                                                                                            <td style="width: 57%">
                                                                                                <asp:DropDownList ID="ddlKacKrediKarti" runat="server" onchange="ddlKacKrediKarti_onclick()"
                                                                                                    Width="50px">
                                                                                                    <asp:ListItem Selected="True" Value="0">0</asp:ListItem>
                                                                                                    <asp:ListItem Value="1">1</asp:ListItem>
                                                                                                    <asp:ListItem Value="2">2</asp:ListItem>
                                                                                                    <asp:ListItem Value="3">3</asp:ListItem>
                                                                                                </asp:DropDownList>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                    <table id="kredikartibaslik" cellpadding="5" cellspacing="0" style="text-align: center"
                                                                                        visible="false">
                                                                                        <tr>
                                                                                            <td style="width: 180px">
                                                                                                Kredi Kart&#305;
                                                                                            </td>
                                                                                            <td style="width: 180px">
                                                                                                Limiti
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                    <table id="kredikarti1" cellpadding="5" cellspacing="0" style="text-align: center"
                                                                                        visible="false">
                                                                                        <tr>
                                                                                            <td>
                                                                                                <asp:TextBox ID="txtKrediKarti1" runat="server" MaxLength="30" Width="180px"></asp:TextBox>
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:TextBox ID="txtKrediKarti1Limiti" runat="server" MaxLength="20" Width="180px"></asp:TextBox>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                    <table id="kredikarti2" cellpadding="5" cellspacing="0" style="text-align: center"
                                                                                        visible="false">
                                                                                        <tr>
                                                                                            <td>
                                                                                                <asp:TextBox ID="txtKrediKarti2" runat="server" MaxLength="30" Width="180px"></asp:TextBox>
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:TextBox ID="txtKrediKarti2Limiti" runat="server" MaxLength="20" Width="180px"></asp:TextBox>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                    <table id="kredikarti3" cellpadding="5" cellspacing="0" style="text-align: center"
                                                                                        visible="false">
                                                                                        <tr>
                                                                                            <td>
                                                                                                <asp:TextBox ID="txtKrediKarti3" runat="server" MaxLength="30" Width="180px"></asp:TextBox>
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:TextBox ID="txtKrediKarti3Limiti" runat="server" MaxLength="20" Width="180px"></asp:TextBox>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    Oturdu&#287;unuz ev size mi ait?
                                                                                </td>
                                                                                <td>
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td>
                                                                                    <asp:RadioButton ID="rbEvSizinEvet" runat="server" GroupName="grEvSizin" Text="Evet" />
                                                                                    <asp:RadioButton ID="rbEvSizinHayir" runat="server" Checked="True" GroupName="grEvSizin"
                                                                                        Text="Hay&#305;r" />
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    Oturdu&#287;unuz ev d&#305;&#351;&#305;nda gayri menkulünüz var m&#305;?
                                                                                </td>
                                                                                <td>
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td>
                                                                                    <asp:RadioButton ID="rbBaskaEvEvet" runat="server" GroupName="grBaskaEv" Text="Evet" />
                                                                                    <asp:RadioButton ID="rbBaskaEvHayir" runat="server" Checked="True" GroupName="grBaskaEv"
                                                                                        Text="Hay&#305;r" />
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    &nbsp;&nbsp;&nbsp;&nbsp; Varsa adresi ve durumu&nbsp;
                                                                                </td>
                                                                                <td>
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="txtBaskaEvAdresDurum" runat="server" MaxLength="200" Width="250px"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    Otomobiliniz var m&#305;?
                                                                                </td>
                                                                                <td>
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td>
                                                                                    <asp:RadioButton ID="rbOtomobilVar" runat="server" GroupName="grOtomobil" Text="Var" />
                                                                                    <asp:RadioButton ID="rbOtomobilYok" runat="server" Checked="True" GroupName="grOtomobil"
                                                                                        Text="Yok" />
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    &nbsp;&nbsp;&nbsp;&nbsp; Varsa markas&#305;, modeli ve durumu&nbsp;
                                                                                </td>
                                                                                <td>
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="txtOtomobilMarkaModelDurum" runat="server" MaxLength="150" Width="250px"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    Üyesi Oldu&#287;unuz Dernek, Klüp ve Kurulu&#351;lar
                                                                                </td>
                                                                                <td>
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="txtUyeDernekKlupKurulus" runat="server" MaxLength="100" Width="250px"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    Özel Meraklar&#305;n&#305;z, Hobileriniz
                                                                                </td>
                                                                                <td>
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="txtOzelMerakHobi" runat="server" MaxLength="100" Width="250px"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    Bilgisayar kullan&#305;yorsan&#305;z bildi&#287;iniz programlama dillerini ve/veya
                                                                                    paket programlar&#305;n&#305; belirtiniz
                                                                                </td>
                                                                                <td>
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td>
                                                                                    <asp:CheckBoxList ID="cblBilgisayarProgramlari" runat="server" OnSelectedIndexChanged="cblBilgisayarProgramlari_SelectedIndexChanged"
                                                                                        RepeatDirection="Horizontal" RepeatLayout="Flow">
                                                                                    </asp:CheckBoxList>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    &nbsp;&nbsp;&nbsp;&nbsp; Di&#287;er&nbsp;
                                                                                </td>
                                                                                <td>
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="txtBildigiBilgisayarProgramiDiger" runat="server" MaxLength="70"
                                                                                        Width="250px"></asp:TextBox>
                                                                                    &nbsp;(Lütfen araya virgül koyarak yaz&#305;n.)</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    Mesleki hayat&#305;n&#305;zdaki en büyük ba&#351;ar&#305;n&#305;z&#305; k&#305;saca
                                                                                    özetleyiniz
                                                                                </td>
                                                                                <td>
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="txtMeslekBasarisi" runat="server" MaxLength="100" Width="250px"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    &#350;irketimizde/&#350;irketler Toplulu&#287;umuzda akraba ya da tan&#305;d&#305;klar&#305;n&#305;z
                                                                                    varsa isimlerini belirtiniz
                                                                                </td>
                                                                                <td>
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="txtSirketTanidik" runat="server" MaxLength="150" Width="250px"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    Daha önce &#351;irketimize ba&#351;vurunuz oldu mu?
                                                                                </td>
                                                                                <td>
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td>
                                                                                    <asp:RadioButton ID="rbDahaOnceBasvuruEvet" runat="server" GroupName="grDahaOnceBasvuru"
                                                                                        Text="Evet" />
                                                                                    <asp:RadioButton ID="rbDahaOnceBasvuruHayir" runat="server" Checked="True" GroupName="grDahaOnceBasvuru"
                                                                                        Text="Hay&#305;r" />
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    Talep Etti&#287;iniz Ücret (Net)
                                                                                </td>
                                                                                <td>
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="txtTalepUcret" runat="server" MaxLength="50" Width="250px"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    Kabul Edildi&#287;iniz Tarihte Ba&#351;layabilece&#287;iniz Tarih
                                                                                </td>
                                                                                <td>
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="txtIsBaslangicTarihi" runat="server" MaxLength="10" Width="250px"></asp:TextBox>
                                                                                    &nbsp;(örnek: 15/05/2011)
                                                                                    <asp:RegularExpressionValidator ID="revIsBaslangicTarihi" runat="server" ControlToValidate="txtIsBaslangicTarihi"
                                                                                        ErrorMessage="Tarih format&#305; yanl&#305;&#351;" ToolTip="Tarih format&#305; yanl&#305;&#351;"
                                                                                        ValidationExpression="^(((0[1-9]|[12]\d|3[01])\/(0[13578]|1[02])\/((19|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\/(0[13456789]|1[012])\/((19|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\/02\/((19|[2-9]\d)\d{2}))|(29\/02\/((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$">*</asp:RegularExpressionValidator>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    Sigara içiyor musunuz?
                                                                                </td>
                                                                                <td>
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td>
                                                                                    <asp:RadioButton ID="rbSigaraEvet" runat="server" GroupName="grSigara" Text="Evet" />
                                                                                    <asp:RadioButton ID="rbSigaraHayir" runat="server" Checked="True" GroupName="grSigara"
                                                                                        Text="Hay&#305;r, bundan sonra da içmeyi dü&#351;ünmüyorum." />
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    &#304;&#351; ve Çal&#305;&#351;ma &#350;artlar&#305; ile &#304;lgili Özel Beklentileriniz
                                                                                </td>
                                                                                <td>
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="txtIsOzelBeklenti" runat="server" MaxLength="100" Width="250px"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    Gerekti&#287;inde vardiyal&#305; olarak çal&#305;&#351;abilir misiniz?
                                                                                </td>
                                                                                <td>
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td>
                                                                                    <asp:RadioButton ID="rbVardiyaliCalismaEvet" runat="server" GroupName="grVardiyaliCalisma"
                                                                                        Text="Evet" />
                                                                                    <asp:RadioButton ID="rbVardiyaliCalismaHayir" runat="server" Checked="True" GroupName="grVardiyaliCalisma"
                                                                                        Text="Hay&#305;r" />
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    Görev verildi&#287;i takdirde &#351;ehir d&#305;&#351;&#305;nda görev yapabilir
                                                                                    misiniz?<br />
                                                                                </td>
                                                                                <td>
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td>
                                                                                    <asp:RadioButton ID="rbSehirDisiCalismaEvet" runat="server" GroupName="grSehirDisiCalisma"
                                                                                        Text="Evet" />
                                                                                    <asp:RadioButton ID="rbSehirDisiCalismaHayir" runat="server" Checked="True" GroupName="grSehirDisiCalisma"
                                                                                        Text="Hay&#305;r" />
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    &nbsp;&nbsp;&nbsp;&nbsp; K&#305;s&#305;tlamalar&#305;n&#305;z nelerdir?&nbsp;
                                                                                </td>
                                                                                <td>
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="txtSehirDisiCalismaKisitlama" runat="server" MaxLength="100" Width="250px"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="padding-top: 15px; padding-bottom: 8px;">
                                                                                    <span style="font-size: 15px; font-weight: bold; color: #726F6D">REFERANSLAR</span>
                                                                                </td>
                                                                                <td style="padding-top: 15px; padding-bottom: 8px;">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td>
                                                                                    &nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td valign="top">
                                                                                    <br />
                                                                                    Verebilece&#287;iniz Referanslar&#305;n&#305;z
                                                                                </td>
                                                                                <td valign="top">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td>
                                                                                    <table cellpadding="5" cellspacing="0" style="width: 100%">
                                                                                        <tr>
                                                                                            <td style="width: 50%">
                                                                                                Kaç adet referans girmek istiyorsunuz:
                                                                                            </td>
                                                                                            <td style="width: 50%">
                                                                                                <asp:DropDownList ID="ddlKacReferans" runat="server" onchange="ddlKacReferans_click()"
                                                                                                    Width="50px">
                                                                                                    <asp:ListItem Value="0">0</asp:ListItem>
                                                                                                    <asp:ListItem Value="1" Selected="True">1</asp:ListItem>
                                                                                                    <asp:ListItem Value="2">2</asp:ListItem>
                                                                                                    <asp:ListItem Value="3">3</asp:ListItem>
                                                                                                </asp:DropDownList>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                    <table id="referansbaslik" cellpadding="5" cellspacing="0" style="text-align: center">
                                                                                        <tr>
                                                                                            <td style="width: 110px">
                                                                                                Ad&#305; Soyad&#305;
                                                                                            </td>
                                                                                            <td style="width: 120px">
                                                                                                Çal&#305;&#351;t&#305;&#287;&#305; &#350;irket
                                                                                            </td>
                                                                                            <td style="width: 110px">
                                                                                                Görevi
                                                                                            </td>
                                                                                            <td style="width: 50px">
                                                                                                Telefonu
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                    <table id="referans1" cellpadding="5" cellspacing="0" style="text-align: center">
                                                                                        <tr>
                                                                                            <td>
                                                                                                <asp:TextBox ID="txtReferans1Adi" runat="server" MaxLength="50" Width="100px"></asp:TextBox>
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:TextBox ID="txtReferans1Sirketi" runat="server" MaxLength="100" Width="120px"></asp:TextBox>
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:TextBox ID="txtReferans1Gorevi" runat="server" MaxLength="50" Width="100px"></asp:TextBox>
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:TextBox ID="txtReferans1Telefonu" runat="server" MaxLength="15" Width="80px"></asp:TextBox>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                    <table id="referans2" cellpadding="5" cellspacing="0" style="text-align: center"
                                                                                        visible="false">
                                                                                        <tr>
                                                                                            <td>
                                                                                                <asp:TextBox ID="txtReferans2Adi" runat="server" MaxLength="50" Width="100px"></asp:TextBox>
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:TextBox ID="txtReferans2Sirketi" runat="server" MaxLength="100" Width="120px"></asp:TextBox>
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:TextBox ID="txtReferans2Gorevi" runat="server" MaxLength="50" Width="100px"></asp:TextBox>
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:TextBox ID="txtReferans2Telefonu" runat="server" MaxLength="15" Width="80px"></asp:TextBox>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                    <table id="referans3" cellpadding="5" cellspacing="0" style="text-align: center"
                                                                                        visible="false">
                                                                                        <tr>
                                                                                            <td>
                                                                                                <asp:TextBox ID="txtReferans3Adi" runat="server" MaxLength="50" Width="100px"></asp:TextBox>
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:TextBox ID="txtReferans3Sirketi" runat="server" MaxLength="100" Width="120px"></asp:TextBox>
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:TextBox ID="txtReferans3Gorevi" runat="server" MaxLength="50" Width="100px"></asp:TextBox>
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:TextBox ID="txtReferans3Telefonu" runat="server" MaxLength="15" Width="80px"></asp:TextBox>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="3">
                                                                                    Çal&#305;&#351;ma hayat&#305;n&#305;zdaki beklentilerinizi k&#305;saca özetleyiniz:
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="3">
                                                                                    <asp:TextBox ID="txtCalismaHayatiBeklenti" runat="server" Height="100px" MaxLength="300"
                                                                                        TextMode="MultiLine" Width="100%"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="right" colspan="3">
                                                                                    <table cellpadding="0" cellspacing="0">
                                                                                        <tr>
                                                                                            <td style="width: 660px; text-align: left;">
                                                                                            <br /><br />
                                                                                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                                                                                                    ForeColor="#000000" HeaderText=" ::: Eksik Alanlar ::: " ShowMessageBox="True" /></td>
                                                                                            <td valign="top">

                                                                                                <a class="btn" href="javascript:functionGonder()" style="width: 200px">Gönder</a>
                                                                                        
                                                                                                <asp:LinkButton runat="server" ID="lbGonder" onclick="lbGonder_Click"></asp:LinkButton>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>




    <div class="main pad0">
    <div class="content">
    	<div class="container_12">
    		<div class="grid_12">
            	
            </div>
        </div>
    </div>
    </div>





<div class="foooter">
  <div class="container_12">
    <div class="grid_4">
      <h4>Telif hakkı</h4>
      Site içerisindeki içerikler <br />Sultanlar Pazarlama A.Ş.'ye aittir.<br /><br />Tüm hakları saklıdır &copy; 2011-2015
    </div>
    <div class="grid_4">
      <h4>Hakkımızda</h4>
      <p>Sultanlar Ev ihtiyaç Maddeleri Pazarlama A.Ş. bünyesinde bir çok ticari ve sınai kuruluşları bulunduran Sultanlar Şirketler Grubu içerisinde yer almaktadır.</p>
    </div>
    <div class="grid_4 socials">
      <h4>Bizi takip edin</h4>
      <a href="#"></a> <a href="https://www.facebook.com/sultanlargrup" target="_blank"></a> <a href="https://twitter.com/sultanlargrup" target="_blank"></a> <a href="#"></a>
      <div class="clear"></div>
    </div>
    <div class="clear"></div>
  </div>
</div>

<script type="text/javascript">
    (function () {
        var ga = document.createElement('script'); ga.type = 'text/javascript'; ga.async = true;
        ga.src = ('https:' == document.location.protocol ? 'https://ssl' : 'http://www') + '.google-analytics.com/ga.js';
        var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(ga, s);
    })();
</script>



    </form>
</body>
</html>

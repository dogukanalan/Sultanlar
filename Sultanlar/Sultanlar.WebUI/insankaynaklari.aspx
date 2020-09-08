<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="insankaynaklari.aspx.cs" Inherits="Sultanlar.WebUI.insankaynaklari" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8" />
    <meta http-equiv="REFRESH" content="0;url=https://www.tibet.com.tr/">
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

    
    <script type="text/javascript" src="js/jquery.tools.min.js"></script>
    <script type="text/javascript" src="js/superfish.js"></script>
    <script type="text/javascript" src="js/jquery.ui.totop.js"></script>
    <script type="text/javascript" src="js/jquery.easing.1.3.js"></script>

    <script>
        jQuery(document).ready(function () {
            $().UItoTop({ easingType: 'easeOutQuart' });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server" action="insankaynaklari.html">


    
    <div style="background-color: white; z-index: 999; position:fixed; width: 100%; height: 2000px"></div>
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
    <div class="main pad0" style="height: 400px">
    <div class="content">
    	<div class="container_12">
    		<div class="grid_12">
            	<h4><span style="font-family: Tahoma; font-weight: bold">İ</span>nsan Kaynakları</h4>
            </div>
    		<div class="clear"></div>
            <div class="grid_12">
                <div class="text1">İhtiyaç olan bölümler:</div>
                <div class="clear"></div>
                <br />
                <div style="text-align:center; font-size: 10px">
                    <asp:Repeater runat="server" ID="rpArananGorevler">
                        <HeaderTemplate>
                            <div style="display:inline;float:left;position:relative;width: 100px; border-bottom-width: 1px; border-bottom-style: dotted; border-bottom-color: #CCCCCC;">
                                Görev
                            </div>
                            <div style="display:inline;float:left;position:relative;width: 150px; border-bottom-width: 1px; border-bottom-style: dotted; border-bottom-color: #CCCCCC;">
                                Eğitim Durumu
                            </div>
                            <div style="display:inline;float:left;position:relative;width: 130px; border-bottom-width: 1px; border-bottom-style: dotted; border-bottom-color: #CCCCCC;">
                                Askerlik Durumu
                            </div>
                            <div style="display:inline;float:left;position:relative;width: 100px; border-bottom-width: 1px; border-bottom-style: dotted; border-bottom-color: #CCCCCC;">
                                Medeni Durum
                            </div>
                            <div style="display:inline;float:left;position:relative;width: 100px; border-bottom-width: 1px; border-bottom-style: dotted; border-bottom-color: #CCCCCC;">
                                Adres İl
                            </div>
                            <div style="display:inline;float:left;position:relative;width: 100px; border-bottom-width: 1px; border-bottom-style: dotted; border-bottom-color: #CCCCCC;">
                                Adres İlçe
                            </div>
                            <div style="display:inline;float:left;position:relative;width: 150px; border-bottom-width: 1px; border-bottom-style: dotted; border-bottom-color: #CCCCCC;">
                                Tecrübe
                            </div>
                            <div style="display:inline;float:left;position:relative;width: 90px; border-bottom-width: 1px; border-bottom-style: dotted; border-bottom-color: #CCCCCC;">
                                .
                            </div>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <div style="display:inline;float:left;position:relative;width: 100px;padding-top: 10px">
                                <span style="color: #4D4A47"><%# Eval("strGorev") %></span>
                            </div>
                            <div style="display:inline;float:left;position:relative;width: 150px;padding-top: 10px">
                                <span style="color: #4D4A47"><%# Eval("strOgrenimDurumu") %></span>
                            </div>
                            <div style="display:inline;float:left;position:relative;width: 130px;padding-top: 10px">
                                <span style="color: #4D4A47"><%# Eval("strAskerlikDurumu") %></span>
                            </div>
                            <div style="display:inline;float:left;position:relative;width: 100px;padding-top: 10px">
                                <span style="color: #4D4A47"><%# Eval("strMedeniDurum") %></span>
                            </div>
                            <div style="display:inline;float:left;position:relative;width: 100px;padding-top: 10px">
                                <span style="color: #4D4A47"><%# Eval("strIl") %></span>
                            </div>
                            <div style="display:inline;float:left;position:relative;width: 100px;padding-top: 10px">
                                <span style="color: #4D4A47"><%# Eval("strIlce") %></span>
                            </div>
                            <div style="display:inline;float:left;position:relative;width: 150px;padding-top: 10px">
                                <span style="color: #4D4A47"><%# Eval("strTecrube") %></span>
                            </div>
                            <div style="display:inline;float:left;position:relative;width: 90px;padding-top: 10px">
                                <%# Eval("Basvur") %>
                            </div>
                        </ItemTemplate>
                        <FooterTemplate>
                        </FooterTemplate>
                    </asp:Repeater>
                </div>
            </div>
            <div class="clear"></div>
            <div class="text1" style="width: 100%; text-align: center; padding-top: 100px"><a href="isbasvuru.html">İş başvurusu yapmak için tıklayınız.</a></div>
            <div class="clear"></div>
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

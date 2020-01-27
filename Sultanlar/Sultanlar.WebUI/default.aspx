<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Sultanlar.WebUI._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>Sultanlar Ev İhtiyaç Malzemeleri Pazarlama A.Ş.</title>
    <meta name="robots" content="index, follow" />
    <meta name="description" content="Sultanlar Ev İhtiyaç Maddeleri Pazarlama A.Ş. bünyesinde bir çok ticari ve sınai kuruluşları bulunduran Sultanlar Şirketler Grubu içerisinde yer almaktadır." />
    <meta name="keywords" content="sultanlar a.ş., sultanlar grup, happy family, bulgurium, tibet, henkel, türk Henkel kimya, vileda, fhp, st grup, korozo, aktif kozmetik, sultanlar grup, arı, arımama, sultanlar, katalog, insert, brosur, ürün katalogu, ürün resimleri, ürün brosuru" />
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

    <script type="text/javascript">
        jQuery(document).ready(function () {
            $().UItoTop({ easingType: 'easeOutQuart' });
        });
        $(document).ready(function () {
            $("ul.tabs-nav").tabs(".tab-content");
        });
    </script>
	<!-- Start WOWSlider.com HEAD section -->
	<link rel="stylesheet" type="text/css" href="engine1/style.css" />
	<!-- End WOWSlider.com HEAD section -->
</head>
<body>
    <form id="form1" runat="server" action="index.html">
    <asp:ScriptManager runat="server" ID="ajaxScripts"></asp:ScriptManager>



    <div id="divKartvizit" runat="server" visible="false">
        <div style="padding-top: 300px; filter: alpha(opacity=40); -moz-opacity: .40; opacity: .40;
            background-color: #000000; position: fixed; width: 100%; height: 100%; z-index: 99;
            left: 0; top: 0;">
        </div>
        <div style="padding-top: 25px; position: fixed; width: 100%; height: 100%; z-index: 100; filter: alpha(opacity=90); -moz-opacity: .90; opacity: .90;
            left: 0; top: 0;">
            <table style="width: 100%; height: 300px; text-align: center;">
                <tr>
                    <td align="center">
                        <table style="background-color: #ffffff; border-radius: 5px; padding: 5px;">
                            <tr>
                                <td style="border-bottom: 1px dotted #CCCCCC; width: 30px">
                                    
                                </td>
                                <td style="text-align: center; border-bottom: 1px dotted #CCCCCC; height: 50px; font-size: 34px; font-family: Gisha">
                                    Kartvizit Bilgisi
                                </td>
                                <td style="border-bottom: 1px dotted #CCCCCC; font-size: 22px; font-weight: bold; width: 30px; color: Red;">
                                    <asp:LinkButton runat="server" ID="lbKartvizitKapat" OnClick="lbKartvizitKapat_Click" Text="X"></asp:LinkButton>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: center; height: 100%; padding: 10px 10px 10px 10px;" colspan="3">
                                    <asp:Image runat="server" ID="imgKartvizit" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </div>




<!--[if IE 6]><div class="heaader"><![endif]--><!--[if IE 7]><div class="heaader"><![endif]--><!--[if IE 8]><div class="heaader"><![endif]-->
<header>
  <div class="container_12">
    <div class="grid_12">
      <%--<h1><a href="default.aspx">Sultanlar Pazarlama</a></h1>--%>
      
      <img alt="Sultanlar Pazarlama" src="images/logo.png" onclick="window.location.href='index.html'" style="cursor:pointer;" />
      <img alt="E-Fatura" src="images/efatura1.png" />
      <nav>
      <!--[if IE 6]><span style="width: 300px; display: inline-block"></span><![endif]-->
      <!--[if IE 7]><span style="width: 300px; display: inline-block"></span><![endif]-->
      <!--[if IE 8]><span style="width: 300px; display: inline-block"></span><![endif]-->
        <ul class="sf-menu">
          <li class="current"><a href="index.html">ANA SAYFA</a></li>
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
          <li><a href="insankaynaklari.html">İNSAN KAYNAKLARI</a></li>
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
<!-- <div style="height: 35px; text-align: center; vertical-align: middle">
<h4 style="font-size: 22px; color: Red">S U L T A N L A R &nbsp;&nbsp;E - F A T U R A &nbsp;&nbsp;M Ü K E L L E F i D i R</h4>
</div> -->
<!-- Start WOWSlider.com BODY section -->
<div id="wowslider-container1">
<div class="ws_images"><ul>
<li><a href="https://www.sultanlar.com.tr/musteri/katalog-MAMALAR.html"><img src="data1/images/arimama.jpg" alt="Arı Mama" title="Arı Mama" id="wows1_2"/></a>Türkiye'nin İlk Bebek Maması!</li>

<li><a href="https://www.sultanlar.com.tr/musteri/katalog-HARÇLAR.html"><img src="data1/images/bunsa.png" alt="Bünsa" title="Bünsa" id="Img1"/></a>Tibet ve Hayat ürünleri başlıca kenton, camsil, ernet, flore, piknik, saloon, bünsa, tibtrap markalarından oluşmaktadır.</li>
<li><a href="https://www.sultanlar.com.tr/musteri/katalog-CAM-TEMİZLEYİCİLER.html"><img src="data1/images/camsil.png" alt="Camsil" title="Camsil" id="Img2"/></a>Tibet ve Hayat ürünleri başlıca kenton, camsil, ernet, flore, piknik, saloon, bünsa, tibtrap markalarından oluşmaktadır.</li>
<li><a href="https://www.sultanlar.com.tr/musteri/katalog-SÜPER-TEMİZLEYİCİLER.html"><img src="data1/images/ernet.png" alt="Ernet" title="Ernet" id="Img3"/></a>Tibet ve Hayat ürünleri başlıca kenton, camsil, ernet, flore, piknik, saloon, bünsa, tibtrap markalarından oluşmaktadır.</li>
<li><a href="https://www.sultanlar.com.tr/musteri/katalog-KOZMETİK-DİĞER.html"><img src="data1/images/flore.png" alt="Flore" title="Flore" id="Img4"/></a>Tibet ve Hayat ürünleri başlıca kenton, camsil, ernet, flore, piknik, saloon, bünsa, tibtrap markalarından oluşmaktadır.</li>
<li><a href="https://www.sultanlar.com.tr/musteri/katalog-KREM-ŞANTİLER.html"><img src="data1/images/hayat.png" alt="Hayat" title="Hayat" id="Img5"/></a>Tibet ve Hayat ürünleri başlıca kenton, camsil, ernet, flore, piknik, saloon, bünsa, tibtrap markalarından oluşmaktadır.</li>
<li><a href="https://www.sultanlar.com.tr/musteri/katalog-PUDİNGLER.html"><img src="data1/images/kenton.png" alt="Kenton" title="Kenton" id="Img6"/></a>Tibet ve Hayat ürünleri başlıca kenton, camsil, ernet, flore, piknik, saloon, bünsa, tibtrap markalarından oluşmaktadır.</li>
<li><a href="https://www.sultanlar.com.tr/musteri/katalog-KREM-ŞANTİLER.html"><img src="data1/images/piknik.png" alt="Piknik" title="Piknik" id="Img7"/></a>Tibet ve Hayat ürünleri başlıca kenton, camsil, ernet, flore, piknik, saloon, bünsa, tibtrap markalarından oluşmaktadır.</li>
<li><a href="https://www.sultanlar.com.tr/musteri/katalog-SIVI-SABUNLAR.html"><img src="data1/images/saloon.png" alt="Saloon" title="Saloon" id="Img8"/></a>Tibet ve Hayat ürünleri başlıca kenton, camsil, ernet, flore, piknik, saloon, bünsa, tibtrap markalarından oluşmaktadır.</li>
<li><a href="https://www.sultanlar.com.tr/musteri/katalog-KOKU-GİDERİCİ-KLASİK-BLOKLAR.html"><img src="data1/images/tibet.png" alt="Tibet" title="Tibet" id="Img9"/></a>Tibet ve Hayat ürünleri başlıca kenton, camsil, ernet, flore, piknik, saloon, bünsa, tibtrap markalarından oluşmaktadır.</li>
<li><a href="https://www.sultanlar.com.tr/musteri/katalog-HAŞERE-ÖNLEYİCİLER.html"><img src="data1/images/tibtrap.png" alt="Tibtrap" title="Tibtrap" id="Img10"/></a>Tibet ve Hayat ürünleri başlıca kenton, camsil, ernet, flore, piknik, saloon, bünsa, tibtrap markalarından oluşmaktadır.</li>

<li><a href="https://www.sultanlar.com.tr/musteri/katalog-DİĞER.html"><img src="data1/images/happy_family.jpg" alt="Happy Family" title="Happy Family" id="wows1_0"/></a>Happy Family markasının ürünlerinden olan alvin, bulgurium, macun-i mesir gibi markalarının çeşitlerini burada bulabilirsiniz.</li>
<%--<li><a href="https://www.sultanlar.com.tr/musteri/katalog-Happy-Family-Bulgurium.html"><img src="data1/images/scj.jpg" alt="Bulgurium" title="Bulgurium" id="wows1_1"/></a>"Eline Sağlık Anadolu."</li>
<li><a href="https://www.sultanlar.com.tr/musteri/katalog-Fhp.html"><img src="data1/images/vileda.jpg" alt="Vileda" title="Vileda" id="wows1_3"/></a>Evdeki temizlik işleri hakkında genel önerilerden, belirli problemler için en uygun çözümü sunan ürünlere kadar tüm cevaplar burada.</li>
<li><a href="https://www.sultanlar.com.tr/musteri/katalog-Girisim.html"><img src="data1/images/girisim.jpg" alt="Girişim Pazarlama" title="Girişim Pazarlama" id="wows1_5"/></a>Eczacıbaşı Girişim'in amacı tüm insanların yaşam standartlarını ileriye taşıyacak en güvenilir ve sağlıklı ürünleri her gün daha çok kişi ile buluşturmak.</li>
<li><a href="https://www.sultanlar.com.tr/musteri/katalog-Europap-Kagit.html"><img src="data1/images/europap.jpg" alt="Europap Kağıt" title="Europap Kağıt" id="wows1_6"/></a>Europap Kağıt çağdaş ve sağlıklı yaşamın kaçınılmaz bir parçası haline gelen temizlik kağıdı ürünlerini tam entegre olarak üretmektedir.</li>
<li><a href="https://www.sultanlar.com.tr/musteri/katalog-Aktif-Kozmetik.html"><img src="data1/images/omegapharma.jpg" alt="Omega Pharma" title="Omega Pharma" id="wows1_7"/></a>Omega Pharma Kişisel Bakım Ürünleri olarak , sağlık ve kişisel bakım ürünleri alanında müşterilerimizin beklentilerini kalite ve güvenilirlikten ödün vermeden karşılamak üzere hizmet vermekteyiz.</li>
<li><a href="https://www.sultanlar.com.tr/musteri/katalog-Avrupa-Tekstil.html"><img src="data1/images/pierrecardin.jpg" alt="Pierre Cardin" title="Pierre Cardin" id="wows1_8"/></a>Pierre Cardin bayan çorapları şıklığı ve zerafetiyle, seçkin ve kendini farklı hissetmek isteyen Türk tüketicilerinin hizmetine sunulmuştur.</li>
<li><a href="https://www.sultanlar.com.tr/musteri/katalog-Nrc.html"><img src="data1/images/nrc.jpg" alt="NRC Kişisel Bakım" title="NRC Kişisel Bakım" id="wows1_9"/></a>Kişisel bakım ürünleri alanındaki deneyimi ile NRC Kişisel bakım ürünleri olarak Türkiye pazarına kazandırmak istediği daha nice markaları tüketicilerimize sunmak için çalışmaktayız.</li>--%>
</ul></div>
<div class="ws_thumbs">
<div>
<a href="#" title="Arı Mama"><img src="data1/tooltips/arimama_k.jpg" alt="" /></a>

<a href="#" title="Bünsa"><img src="data1/tooltips/bunsa.png" alt="" /></a>
<a href="#" title="Camsil"><img src="data1/tooltips/camsil.png" alt="" /></a>
<a href="#" title="Ernet"><img src="data1/tooltips/ernet.png" alt="" /></a>
<a href="#" title="Flore"><img src="data1/tooltips/flore.png" alt="" /></a>
<a href="#" title="Hayat"><img src="data1/tooltips/hayat.png" alt="" /></a>
<a href="#" title="Kenton"><img src="data1/tooltips/kenton.png" alt="" /></a>
<a href="#" title="Piknik"><img src="data1/tooltips/piknik.png" alt="" /></a>
<a href="#" title="Saloon"><img src="data1/tooltips/saloon.png" alt="" /></a>
<a href="#" title="Tibet"><img src="data1/tooltips/tibet.png" alt="" /></a>
<a href="#" title="Tibtrap"><img src="data1/tooltips/tibtrap.png" alt="" /></a>

<a href="#" title="Happy Family"><img src="data1/tooltips/happy_family.jpg" alt="" /></a>
<%--<a href="#" title="Bulgurium"><img src="data1/tooltips/scj.jpg" alt="" /></a>
<a href="#" title="Vileda"><img src="data1/tooltips/vileda.jpg" alt="" /></a>
<a href="#" title="Girişim Pazarlama"><img src="data1/tooltips/girisim_k.jpg" alt="" /></a>
<a href="#" title="Europap Kağıt"><img src="data1/tooltips/europap_k.jpg" alt="" /></a>
<a href="#" title="Omega Pharma"><img src="data1/tooltips/omegapharma_k.jpg" alt="" /></a>
<a href="#" title="Pierre Cardin"><img src="data1/tooltips/pierrecardin_k.jpg" alt="" /></a>
<a href="#" title="NRC Kişisel Bakım"><img src="data1/tooltips/nrc_k.jpg" alt="" /></a>--%>
</div>
</div>
<a class="wsl" href="http://wowslider.com">Javascript Image Transition by WOWSlider.com v2.8</a>
<div class="ws_shadow"></div>
</div>
<script type="text/javascript" src="engine1/wowslider.js"></script>
<script type="text/javascript" src="engine1/script.js"></script>
<!-- End WOWSlider.com BODY section -->

<div class="top_block">
    <div class="container_12">
        <h4 style="font-size: 20px"><a href="https://www.sultanlar.com.tr/musteri/katalog.html">Ürün katalogunu görmek için tıklayınız</a></h4>
    </div>
</div>

<div class="content">
	<div class="container_12 ver_separator">
		<div class="supp_links">
			<ul class="tabs-nav">
			<li><a href="#" class="btn"><span></span>Hakkımızda</a></li>
			<li><a href="#" class="btn"><span></span>Grubumuzun Amaçları</a></li>
			<li><a href="#" class="btn"><span></span>Vizyon & Misyon</a></li>
			<li><a href="#" class="btn"><span></span>Şirket Profili</a></li>
			<li><a href="#" class="btn"><span></span>Organizasyon Şeması</a></li>
			</ul>
		</div>
	<div class="tab-content-bg consulting">
	  <div class="tab-content tab-1">
	    <h4>Hakkımız<span style="font-family: Tahoma; font-weight: bold">d</span>a</h4>
        <div style="height: 100px">
	    <p>Sultanlar Ev ihtiyaç Maddeleri Pazarlama A.Ş. bünyesinde bir çok ticari ve sınai kuruluşları bulunduran Sultanlar Şirketler Grubu içerisinde yer almaktadır. Grubun kurucusu Sultan Yıldız, aynı zamanda topluluğun alameti farikası olmuştur.</p>
        </div>
        <div style="width: 100%; text-align: right;"><p><a href="kurumsal.html#hakkimizda" class="btn">Devamını oku</a><span style="display:inline-block; width: 50px"></span></p></div>
	  </div>
      <div class="tab-content tab-2">
	    <h4>Grubumuzun Amaçlar<span style="font-family: Tahoma; font-weight: bold">ı</span></h4>
        <div style="height: 100px">
	    <p>Grubumuz, Türk ve Dünya Tüketicisine Temizlik, Kozmetik, Gıda mevzularında kaliteli mallar üretmek ve satmak için kurulmuş şirketlerden oluşmaktadır. Şirketlerimiz, bu işlerini sürdürürken 4 gruba hizmet etmeyi amaç edinmiştir.</p>
        </div>
        <div style="width: 100%; text-align: right;"><p><a href="kurumsal.html#grubumuzunamaclari" class="btn">Devamını oku</a><span style="display:inline-block; width: 50px"></span></p></div>
	  </div>
      <div class="tab-content tab-3">
	    <h4>Vizyon <span style="font-family: Tahoma; font-weight: bold">&</span> Misyon</h4>
        <div style="height: 100px">
	    <p>Sultanlar Şirketler Grubu olarak misyonumuz; insana değer vermek ve onun en temel ihtiyaçları olan gıda ve temizlik ürünlerini en uygun şartlarda sunmak. Önce insan ilkesiyle tüm müşterilerimizin istek ve beklentilerinin tüm çalışanlarımız ve tedarikçilerimizin etkin katılımıyla sürekli olarak, en düşük maliyetle ve istenilen kalitede, karşılamaktır.</p>
        </div>
        <div style="width: 100%; text-align: right;"><p><a href="kurumsal.html#vizyonmisyon" class="btn">Devamını oku</a><span style="display:inline-block; width: 50px"></span></p></div>
	  </div>
      <div class="tab-content tab-4">
	    <h4><span style="font-family: Tahoma; font-weight: bold">Ş</span>irket Profili</h4>
        <div class="kurumsalsirketprofili" style="height: 100px">
	    <dl>
	    <dd><p><span style="color: #5B5B5B; font-weight: bold">Şirket Unvanı:</span> Sultanlar Ev İhtiyaç Maddeleri Pazarlama A.Ş.</p></dd>
        <dd><p><span style="color: #5B5B5B; font-weight: bold">Adres Merkez:</span> Eyüp Sultan Mah.Sekmen Cad.No:14 34885 Sancaktepe / </p></dd>
        <dd><p><span style="color: #5B5B5B; font-weight: bold"></span> İSTANBUL</p></dd>
        <dd><p><span style="color: #5B5B5B; font-weight: bold">Telefon:</span> +90 216 561 50 00 (pbx)</p></dd>
        <dd><p><span style="color: #5B5B5B; font-weight: bold">Faks:</span> +90 216 561 45 10</p></dd>
        </dl>
        </div>
        <div style="width: 100%; text-align: right;"><p><a href="kurumsal.html#sirketprofili" class="btn">Devamını oku</a><span style="display:inline-block; width: 50px"></span></p></div>
	  </div>
      <div class="tab-content tab-5">
	    <h4>Organizasyon <span style="font-family: Tahoma; font-weight: bold">Ş</span>eması</h4>
        <div style="height: 100px">
        </div>
	    <div style="width: 100%; text-align: right;"><p><a href="kurumsal.html#organizasyonsemasi" class="btn">Devamını oku</a><span style="display:inline-block; width: 50px"></span></p></div>
	  </div>
	  </div>
	  <div class="clear"></div>
	</div>
</div>

<div class="bottom_block">
  <div class="container_12">
<asp:UpdatePanel runat="server" ID="ajaxEczaneler">
<ContentTemplate>
    <div style="display:inline;float:left;position:relative;margin:0 10px;width: 450px">
    <div class='pad0'>
    <div style='height: 40px' align="left">
        <h4 style="padding-left: 20px">Nöbetçi Eczaneler</h4>
    </div>
    </div>
    </div>
    <div style="display:inline;float:left;position:relative;margin:0 10px;width: 200px">
    <div class='pad0'>
    <div style='height: 40px' align="right">
        <div class="styled-select"><asp:DropDownList ID="ddlEczaneIlce" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlEczaneIlce_SelectedIndexChanged"></asp:DropDownList></div>
    </div>
    </div>
    </div>
    <div style="display:inline;float:left;position:relative;margin:0 10px;width: 200px">
    <div class='pad0'>
    <div style='height: 40px' align="left">
        <div class="styled-select"><asp:DropDownList ID="ddlHangiGun" runat="server" AutoPostBack="True" onselectedindexchanged="ddlHangiGun_SelectedIndexChanged"></asp:DropDownList></div>
    </div>
    </div>
    </div>
    <asp:Label runat="server" ID="lblEczaneler"></asp:Label>
</ContentTemplate>
</asp:UpdatePanel>
    <div class="clear"></div>
<div style="height: 20px">
<asp:UpdateProgress ID="ajaxProgress" runat="server" ViewStateMode="Enabled"><ProgressTemplate><div style="width: 900px; text-align: right;">yükleniyor...</div></ProgressTemplate></asp:UpdateProgress>
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

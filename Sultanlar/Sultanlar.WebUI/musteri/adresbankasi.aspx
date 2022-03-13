<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="adresbankasi.aspx.cs" Inherits="Sultanlar.WebUI.musteri.adresbankasi" %>

<%@ Register src="ucAlt.ascx" tagname="ucAlt" tagprefix="uc1" %>

<%@ Register assembly="DevExpress.Web.v12.2, Version=12.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v12.2, Version=12.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sultanlar : Adres Bankası</title>
    <link rel="stylesheet" type="text/css" href="StyleSheet.css" />
    
    <script type="text/javascript" src="js/jquery-1.2.6.pack.js"></script>
    <script type="text/javascript" src="js/jquery-1.8.3.js"></script>
    <script type="text/javascript" src="js/jquery-ui.js"></script>
    <link rel="stylesheet" href="js/jquery-ui.css" />
    <script type="text/javascript" src="js/scripts.js"></script>

    <script type="text/javascript">
        $(function () {
            $("#top").click(function YukariIttir() {
                $("html,body").stop().animate({ scrollTop: "0" }, 1000);
            });
        });
        $(window).scroll(function () {
            var uzunluk = $(document).scrollTop();
            if (uzunluk > 300) $("#top").fadeIn(500);
            else { $("#top").fadeOut(500); }
        }); 
    </script>
    <style type="text/css">
        #top{bottom:5px;right:5px;background:#147;padding:5px;color:#fff;font:bold 11px verdana;position:fixed;display:none;cursor:default;}
        [class*=dxgvTable] [class*=dxeCalendarFooter] tr { visibility: hidden !important; }
    </style>

    <script type="text/javascript" src="js/jquery.tipTip.js"></script>
    <script type="text/javascript" src="js/jquery.tipTip.minified.js"></script>
    <link rel="stylesheet" type="text/css" href="js/tipTip.css" />

    <script type="text/javascript">

//        function GetGeo(map,adres) {
//            var geocoder = new google.maps.Geocoder();
//            var address = adres;
//            if (geocoder) {
//                geocoder.geocode({ 'address': address }, function (results, status) {
//                    if (status == google.maps.GeocoderStatus.OK) {
//                        if (status != google.maps.GeocoderStatus.ZERO_RESULTS) {
//                            //map.setCenter(results[0].geometry.location);
//                            var infowindow = new google.maps.InfoWindow(
//                                { content: '<b>' + address + '</b>',
//                                    size: new google.maps.Size(150, 50)
//                                });
//                            var marker = new google.maps.Marker({
//                                position: results[0].geometry.location,
//                                map: map,
//                                title: address
//                            });
//                            google.maps.event.addListener(marker, 'click', function () {
//                                infowindow.open(map, marker);
//                            });
//                            marker.setMap(map);
//                        } else {
//                            //document.getElementById('spanBulunamayanlar').innerHTML += results[0] + "<br>";

//                        }
//                    } else {
//                        //document.getElementById('spanBulunamayanlar').innerHTML += "Geocode was not successful for the following reason: " + status + "<br>";
//                    }
//                });
//            }
//        }

//        function myMap() {
//            var mapProp = {
//                center: new google.maps.LatLng(39.821280, 34.807866),
//                zoom: 8,
//                styles: [{ "featureType": "landscape", "elementType": "geometry", "stylers": [{ "saturation": "-100"}] }, { "featureType": "poi", "elementType": "labels", "stylers": [{ "visibility": "off"}] }, { "featureType": "poi", "elementType": "labels.text.stroke", "stylers": [{ "visibility": "off"}] }, { "featureType": "road", "elementType": "labels.text", "stylers": [{ "color": "#545454"}] }, { "featureType": "road", "elementType": "labels.text.stroke", "stylers": [{ "visibility": "off"}] }, { "featureType": "road.highway", "elementType": "geometry.fill", "stylers": [{ "saturation": "-87" }, { "lightness": "-40" }, { "color": "#ffffff"}] }, { "featureType": "road.highway", "elementType": "geometry.stroke", "stylers": [{ "visibility": "off"}] }, { "featureType": "road.highway.controlled_access", "elementType": "geometry.fill", "stylers": [{ "color": "#f0f0f0" }, { "saturation": "-22" }, { "lightness": "-16"}] }, { "featureType": "road.highway.controlled_access", "elementType": "geometry.stroke", "stylers": [{ "visibility": "off"}] }, { "featureType": "road.highway.controlled_access", "elementType": "labels.icon", "stylers": [{ "visibility": "on"}] }, { "featureType": "road.arterial", "elementType": "geometry.stroke", "stylers": [{ "visibility": "off"}] }, { "featureType": "road.local", "elementType": "geometry.stroke", "stylers": [{ "visibility": "off"}] }, { "featureType": "transit", "elementType": "labels.icon", "stylers": [{ "visibility": "off"}] }, { "featureType": "water", "elementType": "geometry.fill", "stylers": [{ "saturation": "-52" }, { "hue": "#00e4ff" }, { "lightness": "-16"}]}]
//            };
//            var map = new google.maps.Map(document.getElementById("googleMap"), mapProp);

//            var diziler = document.getElementById('inputH').value.split("|||");
//            var limit = diziler.length > 51 ? 50 : (diziler.length != 0 ? diziler.length - 1 : 0);
//            for (var i = 0; i < limit; i++) {
//                GetGeo(map, diziler[0]);
//            }
//            map.setZoom(6);
//        }

    </script>

</head>
<body style="margin: 0 0 0 0;background-color: #EFEEEA;">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="AjaxScripts" runat="server" AsyncPostBackTimeout="1000">
    </asp:ScriptManager>
    <script type="text/javascript">
        Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(function (evt, args) {
            $("input[type=submit], input[type=button]").button();
        });
    </script>

    <input type="hidden" runat="server" id="inputH" value="" />

    <div id="tiptip_holder">
    <div id="tiptip_content">
    <div id="tiptip_arrow">
    <div id="tiptip_arrow_inner"></div>
    </div>
    </div>
    </div>

    <div style="width: 100%; font-size: 9px; font-family: Verdana; background-color: #EFEEEA; border-bottom: 1px solid #FFCFB2"">
    <table cellpadding="5" cellspacing="0">
    <tr>
    <td style="width: 800px;" valign="middle">
        <table cellpadding="0" cellspacing="0"><tr><td>
        <input type="button" value="Giriş" onclick="javascript:window.location.href='default.aspx'" /> 
        <input type="button" value="Aktiviteler" onclick="javascript:window.location.href='aktiviteler.aspx'" /> 
        <input type="button" value="H.Bedelleri" onclick="javascript:window.location.href='hizmetbedelleri.aspx'" /> 
        <input type="button" value="Anlaşmalar" onclick="javascript:window.location.href='anlasmalar.aspx'" /> 
        <input type="button" value="Siparişler" onclick="javascript:window.location.href='siparisler.aspx'" /> 
        <input type="button" value="İadeler" onclick="javascript:window.location.href='iadeler.aspx'" /> 
        <input type="button" value="Tahsilatlar" onclick="javascript:window.location.href='odemeler.aspx'" /> 
        <input type="button" value="Raporlar" onclick="javascript:window.location.href='hesapayrinti.aspx'" /> 
        <input type="button" value="Üye İşlemleri" onclick="javascript:window.location.href='uyelik.aspx'" /> 
        <input type="button" value='Mesajlar (<%= Sultanlar.DatabaseObject.Internet.GonderilenMesajlar.GetObjectCount(((Sultanlar.DatabaseObject.Internet.Musteriler)Session["Musteri"]).pkMusteriID).ToString() %>)' onclick="javascript:window.location.href='mesajlar.aspx'" /></td><td align="left"></td></tr></table>
    </td>
    <td style="width: 200px; font-family: Gisha; font-size: 12px" align="right">
        <table cellpadding="0" cellspacing="0"><tr><td><asp:Label ID="Label1" runat="server"></asp:Label>&nbsp;&nbsp;&nbsp;</td><td><asp:ImageButton runat="server" ID="ImageButton1" OnClick="ImageButton1_Click" ImageUrl="img/ic_logout.png" /></td></tr></table>
    </td>
    </tr>
    </table>
    </div>
    
    <div style="width: 100%; background-color: #FFFFFF">
    <table cellpadding="0" cellspacing="0" style="width: 1000px; height: 400px; font-size: 10px; font-family: Verdana;
        background-position: center center; background-image: url('img/bg-logo.jpg'); background-repeat: no-repeat;">
        <tr>
            <td valign="top">
            <div class="Baslik">
                <table cellpadding="0" cellspacing="0">
                <tr>
                <td><img src="img/ic_saticikampanya.png" /></td>
                <td style="width: 100%">&nbsp;Adres Bankası<asp:Label runat="server" Width="30px"></asp:Label><input style="font-size: 10px; font-style: italic" type="button" value="Geri Dön" onclick="javascript:window.location.href='default.aspx'" /></td>
                </tr>
                </table>
                <br />
                <asp:DropDownList runat="server" ID="ddlTemsilciler" AutoPostBack="true" Height="25px" ForeColor="#006699" 
                    Width="500px" style="padding: 3px 3px 3px 3px;border:1px solid #CCCCCC;background:#ededed;"
                    OnSelectedIndexChanged="ddlTemsilciler_SelectedIndexChanged"></asp:DropDownList>
                <br /><br />

                <dx:ASPxGridView ID="ASPxGridView1" runat="server" 
                    DataSourceID="SqlDataSource1">
                    <TotalSummary>
                    <dx:ASPxSummaryItem FieldName="Net" ShowInGroupFooterColumn="Net"  
                        SummaryType="Sum" DisplayFormat="{0:###,###,##0.##;-0.##;0}" />
                    <dx:ASPxSummaryItem FieldName="Koli" ShowInGroupFooterColumn="Koli" 
                        SummaryType="Sum" DisplayFormat="{0:###,###,##0.##;-0.##;0}" />
                    </TotalSummary>
                    <SettingsPager NumericButtonCount="20" PageSize="50" Position="TopAndBottom">
                        <Summary Text="Sayfa {0} / {1} ({2} Toplam Sayfa)" />
                        <Summary Text="Sayfa {0} / {1} ({2} Toplam Sayfa)"></Summary>
                    </SettingsPager>
                    <Settings ShowFilterRow="True" ShowFooter="True" ShowHeaderFilterButton="true" />
                    <SettingsText EmptyDataRow="Gösterilecek veri bulunamadı." />
                    <SettingsText HeaderFilterSelectAll="(Hepsini Seç)" 
                        HeaderFilterShowAll="(Hepsini Göster)" HeaderFilterShowBlanks="(Boşları Göster)" 
                        HeaderFilterShowNonBlanks="(Boş Olmayanları Göster)" />
                    <SettingsLoadingPanel Text="Yükleniyor&amp;hellip;" />
                    <SettingsLoadingPanel Text="Y&#252;kleniyor&amp;hellip;"></SettingsLoadingPanel>
                </dx:ASPxGridView>

                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ProviderName="System.Data.SqlClient" 
                ConnectionString="Data Source=10.10.41.2;Initial Catalog=KurumsalWebSAP;User ID=sa;Password=sdl580g5p9+-" 
                SelectCommand="SELECT * FROM [zWeb-Musteri-Adres] WHERE [Sat.Kod] = @SLSREF ORDER BY Şehir,İlçe,Adres">
                <SelectParameters>
                    <asp:ControlParameter ControlID="ddlTemsilciler" DefaultValue="0" Name="SLSREF" 
                        PropertyName="SelectedValue" />
                </SelectParameters>
                </asp:SqlDataSource>

<%--                <br />
                
    <div id="googleMap" style="width:100%;height:400px;"></div>
    <script type="text/javascript">
    </script>
    <script type="text/javascript" src="https://maps.googleapis.com/maps/api/js?key=AIzaSyD2oHmY5S1zlnnoEpOZMwEFougXqHys7B4&callback=myMap"></script>

    <span id="spanBulunamayanlar"></span>--%>

            </div>
            </td>
        </tr>
    </table>
    </div>
    <uc1:ucAlt ID="ucAlt1" runat="server" />
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="siparisler.aspx.cs" Inherits="Sultanlar.WebUI.musteri.siparisler" %>

<%@ Register src="ucAlt.ascx" tagname="ucAlt" tagprefix="uc1" %>

<%@ Register src="ucProgress.ascx" tagname="ucProgress" tagprefix="uc2" %>

<%@ Register src="ucMesajlar.ascx" tagname="ucMesajlar" tagprefix="uc3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Sultanlar : Siparişler</title>
    <script type="text/javascript">
        function invisible() {
            if (document.getElementById('divSiparisKopyala') != null) {
                window.location.href = document.getElementById('lbSiparisKopyalaKapat').href;
                return false;
            }
            if (document.getElementById('divFiyatTipi') != null) {
                window.location.href = document.getElementById('lbFiyatTipiKapat').href;
                return false;
            }
            if (document.getElementById('divOdemeYap') != null) {
                window.location.href = document.getElementById('lbOdemeYapKapat').href;
                return false;
            }
            if (document.getElementById('divTarih') != null) {
                window.location.href = document.getElementById('lbTarihKapat').href;
                return false;
            }
            if (document.getElementById('divFiyatTipiYetkisiYok') != null) {
                window.location.href = document.getElementById('lbFiyatTipiYetkisiYokKapat').href;
                return false;
            }
//            if (document.getElementById('divSevkYerleri') != null) {
//                window.location.href = document.getElementById('lbOnaylaKapat').href;
//                return false;
//            }
            if (document.getElementById('divSiparis') != null) {
                window.location.href = document.getElementById('lbSiparisKapat').href;
                return false;
            }
            if (document.getElementById('divSiparisKaydet') != null) {
                window.location.href = document.getElementById('lbSiparisKaydetKapat').href;
                return false;
            }
            if (document.getElementById('divSiparisEposta') != null) {
                window.location.href = document.getElementById('lbSiparisEpostaKapat').href;
                return false;
            }
            if (document.getElementById('divRiskBakiyeHata') != null) {
                window.location.href = document.getElementById('lbRiskBakiyeHataKapat').href;
                return false;
            }
            if (document.getElementById('divOdemeAyrinti') != null) {
                window.location.href = document.getElementById('lbOdemeAyrintiKapat').href;
                return false;
            }
            if (document.getElementById('divToplamTutarSifir') != null) {
                window.location.href = document.getElementById('lbToplamTutarSifirKapat').href;
                return false;
            }
            if (document.getElementById('divSiparisAktarilmisHata') != null) {
                window.location.href = document.getElementById('lbSiparisAktarilmisHata').href;
                return false;
            }
            if (document.getElementById('divSiparisOnaylanamadi') != null || document.getElementById('divSiparisOnaylamama') != null) {
                window.location.href = document.getElementById('lbSiparisOnaylanamadiKapat').href;
                return false;
            }
            if (document.getElementById('divMesaj') != null) {
                window.location.href = document.getElementById('lbMesajKapat').href;
                return false;
            }
            if (document.getElementById('divDurum') != null) {
                window.location.href = document.getElementById('lbDurumKapat').href;
                return false;
            }
        }
        function Yazdir() {
            yenipen = window.open('yazdir.aspx', '_blank', 'toolbar=yes,location=no,status=no,menubar=yes,scrollbars=yes,width=1024,height=480,noresize');
            yenipen.moveTo(0, 0);
        }
        function OdemeAyrintiYazdir() {
            yenipen = window.open('odemeyazdir.aspx', '_blank', 'toolbar=no,location=no,status=no,menubar=no,scrollbars=yes,width=1024,height=480,noresize');
            yenipen.moveTo(0, 0);
        }
//        function EpostaOlustur() {
//            var body = ReadCookie('SultanlarSiparisEposta')
//            window.location = "mailto:?body=" + body;
//        }
//        function ReadCookie(cookieName) {
//            var theCookie = " " + document.cookie;
//            var ind = theCookie.indexOf(" " + cookieName + "=");
//            if (ind == -1) ind = theCookie.indexOf(";" + cookieName + "=");
//            if (ind == -1 || cookieName == "") return "";
//            var ind1 = theCookie.indexOf(";", ind + 1);
//            if (ind1 == -1) ind1 = theCookie.length;
//            return unescape(theCookie.substring(ind + cookieName.length + 2, ind1));
//        }
        function Sinir(text, uzunluk) {
            if (text.value.length > uzunluk) {
                text.value = text.value.substring(0, uzunluk);
                alert(" En fazla " + uzunluk + " karakter girebilirsiniz.");
            }
        }
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
        function TusBasildiGizle(control) {
            control.style.display = 'none';
        }
        function btTarihClick() {
            window.location.href = document.getElementById('lbTarih').href;
            return false;
        }



        function topluislemgostergizle() {
            var acik = document.getElementById("inputTopluIslemGosterGizle").value == "acik" ? true : false;

            if (acik) {
                document.getElementById("inputTopluIslemGosterGizle").value = "kapali";
                $("#tblTopluIslemler").fadeOut(); //.hide("blind", { easing: "easeOutExpo" }, 1500, callback);
                function callback() { };
            }
            else {
                document.getElementById("inputTopluIslemGosterGizle").value = "acik";
                $("#tblTopluIslemler").fadeIn(); //.show("blind", { easing: "easeOutExpo" }, 1500, callback);
                function callback() { };
            }
        }
    </script>
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
    </script>    <style type="text/css">
        #top{bottom:5px;right:5px;background:#147;padding:5px;color:#fff;font:bold 11px verdana;position:fixed;display:none;cursor:default;}
    </style>

    <script type="text/javascript" src="js/jquery.tipTip.js"></script>
    <script type="text/javascript" src="js/jquery.tipTip.minified.js"></script>
    <link rel="stylesheet" type="text/css" href="js/tipTip.css" />

</head>
<body style="margin: 0 0 0 0;background-color: #EFEEEA;">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="AjaxScripts" runat="server" AsyncPostBackTimeout="1000">
    </asp:ScriptManager>
    <script type="text/javascript">
        Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(function (evt, args) {
            $("#tblTopluIslemler").hide("blind", { easing: "easeOutExpo" }, 100, callback);
            function callback() { };

            $('#rbCariHesapAraMusteri').button();
            $('#rbCariHesapAraSattem').button();
            $('#rbCariHesapUye').button();
            $('#rbSiparislerHepsi').button();
            $('#rbSiparislerOnaylilar').button();
            $('#rbSiparislerOnaysizlar').button();
            $('#rblSevkYerleri').buttonset().find('label').width(300);
            $("input[type=submit], input[type=button]").button();
            $('#cbTariheGore').button();
            $('#btTarih').button({ icons: { primary: 'ui-icon-tarih', secondary: null} });

            $("a[id$='lbTarihKapat']").button();
            $("a[id$='lbFiyatTipiKapat']").button();
            $("a[id$='lbSiparisKopyalaTamamla']").button();
            $("a[id$='lbSiparisKopyalaKapat']").button();
            $("a[id$='lbFiyatTipiYetkisiYokKapat']").button();
            $("a[id$='lbToplamTutarSifirKapat']").button();
            $("a[id$='lbRiskBakiyeHataKapat']").button();
            $("a[id$='lbSiparisOnaylanamadiKapat']").button();
            $("a[id$='lbOnaylaBitir']").button();
            $("a[id$='lbOnaylaKapat']").button();
            $("a[id$='lbSiparisSilEvet']").button();
            $("a[id$='lbSiparisSilHayir']").button();
            $("a[id$='lbSiparisKaydetKapat']").button();
            $("a[id$='lbSiparisEpostaKapat']").button();
            $("a[id$='lbOdemeVazgec']").button();
            $("a[id$='lbOdemeAyrintiKapat']").button();
            $("a[id$='lbSiparisAktarilmisHata']").button();
            $("a[id$='lbStokYetersizEvet']").button();
            $("a[id$='lbStokYetersizHayir']").button();
            $("a[id$='lbAyniMusteriyeSiparisEvet']").button();
            $("a[id$='lbAyniMusteriyeSiparisHayir']").button();
            $("a[id$='lbOdemeYapKapat']").button();
            $("a[id$='lbOdemeYapTutarDevamEt']").button();
        });
    </script>
    <asp:UpdateProgress ID="DivAjaxProg" runat="server">
        <ProgressTemplate>
            <uc2:ucProgress ID="ucProgress1" runat="server" />
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdatePanel runat="server" ID="upSiparisler"><ContentTemplate>

    <div id="tiptip_holder">
    <div id="tiptip_content">
    <div id="tiptip_arrow">
    <div id="tiptip_arrow_inner"></div>
    </div>
    </div>
    </div>

            <uc3:ucMesajlar ID="ucMesajlar1" runat="server" />

            <div style="position: absolute; width: 420px; height: 150px; z-index: 3; left: 290px;
                top: 150px;" runat="server" id="divFiyatTipi" visible="false">
                <div style="position: fixed; width: 100%; height: 100%; z-index: -1; left: 0; top: 0;
                filter: alpha(opacity=40); -moz-opacity: .40; opacity: .40; background-color: #000000" onclick="invisible()"></div>
                <table style="width: 100%; height: 100%; background-color: #ffffff; font-family: Tahoma; font-size: 12px;
                    border: 1px solid #D1D1D1; border-radius: 5px; padding: 5px;">
                <tr>
                <td align="center" valign="middle" style="padding-top: 15px">
                    <span style="color: #C00000">Fiyat Tipini Belirleyiniz</span><br /><br />
                    <asp:DropDownList runat="server" ID="ddlFiyatTipleri" style="padding: 3px 3px 3px 3px;border:1px solid #CCCCCC;background:#ededed;"
                        onselectedindexchanged="ddlFiyatTipleri_SelectedIndexChanged" Height="25px" ForeColor="#006699" 
                        Width="150px" AutoPostBack="True" ></asp:DropDownList><br /><br />
                    <asp:LinkButton runat="server" ID="lbFiyatTipiKapat" 
                        onclick="lbFiyatTipiKapat_Click">Kapat</asp:LinkButton>
                </td>
                </tr>
                </table>
            </div>

            <div style="position: absolute; width: 800px; z-index: 3; left: 100px;
                top: 20px" runat="server" id="divSiparisKopyala" visible="false">
                <div style="position: fixed; width: 100%; height: 100%; z-index: -1; left: 0; top: 0;
                filter: alpha(opacity=40); -moz-opacity: .40; opacity: .40; background-color: #000000" onclick="invisible()"></div>
                <table style="width: 100%; height: 100%; background-color: #ffffff; font-family: Tahoma; margin-bottom: 20px; font-size: 12px;
                    border: 1px solid #D1D1D1; border-radius: 5px; padding: 5px;">
                <tr>
                <td align="center" valign="middle" style="padding-top: 15px; padding-bottom: 15px">
                    <span style="color: #C00000">Siparişi kopyalayacağınız şubeleri seçiniz</span>
                    <br /><br />

                    <table cellpadding="0" cellspacing="0" style="width: 100%"><tr><td align="left">
                    <div style="padding-left: 10px; height: 100%">
                    <asp:CheckBoxList runat="server" ID="cblSiparisKopyalaSubeler" style="font-size: 10px"></asp:CheckBoxList>
                    </div>
                    </td></tr></table>

                    <br /><br />
                    <asp:LinkButton runat="server" ID="lbSiparisKopyalaTamamla" 
                        onclick="lbSiparisKopyalaTamamla_Click">Kopyala</asp:LinkButton>
                    <asp:Label runat="server" ID="lblAralik" Width="100px"></asp:Label>
                    <asp:LinkButton runat="server" ID="lbSiparisKopyalaKapat" 
                        onclick="lbSiparisKopyalaKapat_Click">Kapat</asp:LinkButton>
                </td>
                </tr>
                </table>
            </div>

            <div style="position: absolute; width: 800px; z-index: 3; left: 100px;
                top: 20px" runat="server" id="divSiparisKopyala2" visible="false">
                <div style="position: fixed; width: 100%; height: 100%; z-index: -1; left: 0; top: 0;
                filter: alpha(opacity=40); -moz-opacity: .40; opacity: .40; background-color: #000000" onclick="invisible()"></div>
                <table style="width: 100%; height: 100%; background-color: #ffffff; font-family: Tahoma; margin-bottom: 20px; font-size: 12px;
                    border: 1px solid #D1D1D1; border-radius: 5px; padding: 5px;">
                <tr>
                <td align="center" valign="middle" style="padding-top: 15px; padding-bottom: 15px">
                    <span style="color: #C00000">Siparişi kopyalayacağınız sevk yerlerini seçiniz (Siparişler kopyalandığında otomatik onaylanacaktır)</span>
                    <br /><br />

                    <table cellpadding="0" cellspacing="0" style="width: 100%"><tr><td align="left">
                    <div style="padding-left: 10px; height: 100%">
                    <asp:CheckBoxList runat="server" ID="cblSiparisKopyala2SevkYerleri" style="font-size: 10px"></asp:CheckBoxList>
                    </div>
                    </td></tr></table>

                    <br /><br />
                    <asp:LinkButton runat="server" ID="lbSiparisKopyala2Tamamla" 
                        onclick="lbSiparisKopyala2Tamamla_Click">Kopyala</asp:LinkButton>
                    <asp:Label runat="server" Width="100px"></asp:Label>
                    <asp:LinkButton runat="server" ID="lbSiparisKopyala2Kapat" 
                        onclick="lbSiparisKopyala2Kapat_Click">Kapat</asp:LinkButton>
                </td>
                </tr>
                </table>
            </div>

            <div style="position: absolute; width: 400px; height: 270px; z-index: 3; left: 300px;
                top: 50px" runat="server" id="divTarih" visible="false">
                <div style="position: fixed; width: 100%; height: 100%; z-index: -1; left: 0; top: 0;
                filter: alpha(opacity=40); -moz-opacity: .40; opacity: .40; background-color: #000000" onclick="invisible()"></div>
                <table cellpadding="5" style="width: 100%; height: 100%; background-color: #ffffff; font-family: Tahoma; font-size: 12px;
                    border: 1px solid #D1D1D1; border-radius: 5px; padding: 5px;">
                <tr>
                <td align="center" valign="middle" colspan="2" style="font-size: 10px;">
                    <asp:CheckBox runat="server" ID="cbTariheGore" Checked="true" Text="Tarih süzmesi aktif" 
                        AutoPostBack="true" OnCheckedChanged="cbTariheGore_CheckedChanged" />
                </td>
                </tr>
                <tr>
                <td align="center" valign="middle">
                    <asp:Calendar ID="Calendar1" runat="server" BackColor="White" 
                        BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" 
                        Font-Names="Verdana" Font-Size="7pt" ForeColor="Black" Height="170px" 
                        Width="170px" OnSelectionChanged="Calendar1_SelectionChanged">
                        <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                        <NextPrevStyle VerticalAlign="Bottom" />
                        <OtherMonthDayStyle ForeColor="#808080" />
                        <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                        <SelectorStyle BackColor="#CCCCCC" />
                        <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                        <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                        <WeekendDayStyle BackColor="#FFFFCC" />
                    </asp:Calendar>
                </td>
                <td align="center" valign="middle">
                    <asp:Calendar ID="Calendar2" runat="server" BackColor="White" 
                        BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" 
                        Font-Names="Verdana" Font-Size="7pt" ForeColor="Black" Height="170px" 
                        Width="170px" OnSelectionChanged="Calendar2_SelectionChanged">
                        <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                        <NextPrevStyle VerticalAlign="Bottom" />
                        <OtherMonthDayStyle ForeColor="#808080" />
                        <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                        <SelectorStyle BackColor="#CCCCCC" />
                        <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                        <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                        <WeekendDayStyle BackColor="#FFFFCC" />
                    </asp:Calendar>
                </td>
                </tr>
                <tr>
                <td align="center" valign="middle" colspan="2">
                    Seçim yapılan tarih aralığı: 
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label runat="server" ID="lblTarihSecim1" ForeColor="Red"></asp:Label>
                    &nbsp;&nbsp;&nbsp;
                    <asp:Label runat="server" ID="lblTarihSecim2" ForeColor="Red"></asp:Label>
                </td>
                </tr>
                <tr>
                <td align="center" valign="middle" colspan="2">
                    <asp:LinkButton runat="server" ID="lbTarihKapat" OnClick="lbTarihKapat_Click">Uygula</asp:LinkButton>
                </td>
                </tr>
                </table>
            </div>

            <div style="position: absolute; width: 420px; height: 100px; z-index: 3; left: 290px;
                top: 150px" runat="server" id="divFiyatTipiYetkisiYok" visible="false">
                <div style="position: fixed; width: 100%; height: 100%; z-index: -1; left: 0; top: 0;
                filter: alpha(opacity=40); -moz-opacity: .40; opacity: .40; background-color: #000000" onclick="invisible()"></div>
                <table style="width: 100%; height: 100%; background-color: #ffffff; font-family: Tahoma; font-size: 12px;
                    border: 1px solid #D1D1D1; border-radius: 5px; padding: 5px;">
                <tr>
                <td align="center" valign="middle" style="padding-top: 15px; padding-bottom: 15px">
                    Bu siparişin fiyat tipine yetkili değilsiniz. Siparişi yalnızca inceleyebilir, yazdırabilir veya kaydedebilirsiniz.
                    <br /><br />
                    <asp:LinkButton runat="server" ID="lbFiyatTipiYetkisiYokKapat" 
                        onclick="lbFiyatTipiYetkisiYokKapat_Click">Kapat</asp:LinkButton>
                </td>
                </tr>
                </table>
            </div>

            <div style="position: absolute; width: 420px; height: 100px; z-index: 3; left: 290px;
                top: 150px" runat="server" id="divToplamTutarSifir" visible="false">
                <div style="position: fixed; width: 100%; height: 100%; z-index: -1; left: 0; top: 0;
                filter: alpha(opacity=40); -moz-opacity: .40; opacity: .40; background-color: #000000" onclick="invisible()"></div>
                <table style="width: 100%; height: 100%; background-color: #ffffff; font-family: Tahoma; font-size: 12px;
                    border: 1px solid #D1D1D1; border-radius: 5px; padding: 5px;">
                <tr>
                <td align="center" valign="middle" style="padding-top: 15px; padding-bottom: 15px">
                    Siparişte bir ürün bulunmuyor.
                    <br /><br />
                    <asp:LinkButton runat="server" ID="lbToplamTutarSifirKapat" 
                        onclick="lbToplamTutarSifirKapat_Click">Kapat</asp:LinkButton>
                </td>
                </tr>
                </table>
            </div>

            <div style="position: absolute; width: 420px; height: 100px; z-index: 4; left: 290px;
                top: 150px" runat="server" id="divRiskBakiyeHata" visible="false">
                <div style="position: fixed; width: 100%; height: 100%; z-index: -1; left: 0; top: 0;
                filter: alpha(opacity=40); -moz-opacity: .40; opacity: .40; background-color: #000000" onclick="invisible()"></div>
                <table style="width: 100%; height: 100%; background-color: #ffffff; font-family: Tahoma; font-size: 12px;
                    border: 1px solid #D1D1D1; border-radius: 5px; padding: 5px;">
                <tr>
                <td align="center" valign="middle" style="padding-top: 15px; padding-bottom: 15px">
                    Bir hata oluştu, lütfen daha sonra tekrar deneyiniz.
                    <br /><br />
                    <asp:LinkButton runat="server" ID="lbRiskBakiyeHataKapat" 
                        onclick="lbRiskBakiyeHataKapat_Click">Kapat</asp:LinkButton>
                </td>
                </tr>
                </table>
            </div>

            <div style="position: absolute; width: 500px; height: 300px; z-index: 3; left: 250px;
                top: 50px" runat="server" id="divSevkYerleri" visible="false">
                <div style="position: fixed; width: 100%; height: 100%; z-index: -1; left: 0; top: 0;
                filter: alpha(opacity=40); -moz-opacity: .40; opacity: .40; background-color: #000000"></div>
                <table cellpadding="5" cellspacing="0" style="width: 100%; height: 100%; background-color: #ffffff; font-family: Tahoma; font-size: 12px;
                    border: 1px solid #D1D1D1; border-radius: 5px; padding: 5px;">
                <tr><td align="center"><strong>Siparişi Onayla</strong><br /><br /></td></tr>
                <tr><td>
                <table runat="server" id="tblSevk" style="width: 100%; height: 100%;">
                    <tr>
                    <td>
                        <table cellpadding="1" cellspacing="0">
                            <tr style="color: #D00000">
                                <td style="width: 120px; text-align: center"><u>Toplam B/A</u></td>
                                <td style="width: 120px; text-align: center"><u>Kullanılabilir Limit</u></td>
                                <td style="width: 80px; text-align: center"><u>VGB Gün</u></td>
                                <td style="width: 80px; text-align: center"><u>VGB Toplam</u></td>
                            </tr>
                            <tr>
                                <td style="width: 120px; text-align: center"><asp:Label runat="server" ID="lblSevkYeriBakiye"></asp:Label></td>
                                <td style="width: 120px; text-align: center"><asp:Label runat="server" ID="lblSevkYeriRiskBakiyesi"></asp:Label></td>
                                <td style="width: 80px; text-align: center"><asp:Label runat="server" ID="lblSevkYeriVGBGun"></asp:Label></td>
                                <td style="width: 80px; text-align: center"><asp:Label runat="server" ID="lblSevkYeriVGBToplam"></asp:Label></td>
                            </tr>
                        </table>
                    </td>
                    </tr>
                    <tr>
                    <td align="center" valign="middle" style="padding-top: 15px; padding-bottom: 15px">
                        <span style="color: #C00000">Sevk Yerini Seçiniz</span>
                        <br />
                        <table cellpadding="0" cellspacing="0"><tr><td align="center" valign="middle" style="height: 200px;">
                            <asp:RadioButtonList runat="server" ID="rblSevkYerleri" AutoPostBack="false"></asp:RadioButtonList>
                        </td></tr></table>
                    </td>
                    </tr>
                </table>
                <table runat="server" id="tblDepolar" style="width: 100%; height: 100%;" visible="false">
                    <tr>
                    <td align="center" valign="middle" style="padding-top: 15px; padding-bottom: 15px">
                        <span style="color: #C00000">Siparişinizin Gönderileceği Depo Seçiniz</span>
                        <br /><br />
                        <div style="width: 100%; height: 200px; overflow: auto; font-size: 10px; text-align: left">
                            <asp:RadioButtonList runat="server" ID="rblDepolar" AutoPostBack="false"></asp:RadioButtonList>
                        </div>
                    </td>
                    </tr>
                </table>
                <table runat="server" id="tblAdresler" style="width: 100%; height: 100%;" visible="false">
                    <tr>
                    <td align="center" valign="middle" style="padding-top: 15px; padding-bottom: 15px">
                        <span style="color: #C00000">Siparişinizin Gönderileceği Adresi Seçiniz</span>
                        <br /><br />

                        <table cellpadding="5" cellspacing="0">
                    <tr>
                        <td>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlAdresler" runat="server" Width="300px" AutoPostBack="True" 
                                Font-Bold="False" Font-Italic="False" Height="25px" OnSelectedIndexChanged="ddlAdresler_SelectedIndexChanged"
                                Font-Overline="False" Font-Size="12px" Font-Strikeout="False" 
                                Font-Underline="False" style="padding: 3px 3px 3px 3px" ForeColor="#006699">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            Adres Adı:
                        </td>
                        <td>
                            <asp:TextBox ID="txtBaslik" runat="server" Height="22px" Width="395px" AutoPostBack="false"
                                ForeColor="#006699" BorderColor="#A3B5C9"
                                BorderStyle="Solid" BorderWidth="1px" style="padding: 3px 3px 3px 3px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" align="right">
                            <br />
                            &nbsp; 
                            Adres:
                        </td>
                        <td>
                            <asp:TextBox ID="txtAdres" runat="server" Height="30px" Width="395px" AutoPostBack="false"
                                ForeColor="#006699" BorderColor="#A3B5C9" style="padding: 3px 3px 3px 3px"
                                BorderStyle="Solid" BorderWidth="1px" TextMode="MultiLine"
                                onKeyUp="Sinir(this,60)" onChange="Count(Sinir,60)"></asp:TextBox>
                            <br /><span style="font-size: 10px; font-style: italic">(En fazla 60 karakter girebilirsiniz.)</span>
                        </td>
                    </tr>
                    <tr>
                        <td valign="middle" align="right">
                            İl:
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlIller" runat="server" Width="400px" AutoPostBack="True" 
                                Font-Bold="False" Font-Italic="False" Height="25px" 
                                Font-Overline="False" Font-Size="12px" Font-Strikeout="False" 
                                Font-Underline="False" style="padding: 3px 3px 3px 3px" 
                                ForeColor="#006699" onselectedindexchanged="ddlIller_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td valign="middle" align="right">
                            İlçe:
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlIlceler" runat="server" Width="400px" 
                                Font-Bold="False" Font-Italic="False" Height="25px" 
                                Font-Overline="False" Font-Size="12px" Font-Strikeout="False" 
                                Font-Underline="False" style="padding: 3px 3px 3px 3px" 
                                ForeColor="#006699">
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>

                    </td>
                    </tr>
                </table>
                </td></tr>
                <tr><td align="center">
                    <span style="color: Red; font-size: 16px" runat="server" id="spanBakiyeSiparis">
                        Siparişinizin bakiye kalmasını istiyorsanız aşağıdaki <strong>"Bakiye Siparişi"</strong> kutusunu onaylayınız.
                    </span>
                </td></tr>
                <tr><td align="center">
                    <asp:CheckBox runat="server" ID="cbSicakSatis" Checked="false" Text=" Sıcak satış" Visible="false" />
                    <asp:Label runat="server" Width="10px" Visible="false"></asp:Label>
                    <asp:CheckBox runat="server" ID="cbBakiyeSiparis" Text=" Bakiye siparişi" Visible="true" />
                    <br /><br />
                    <asp:LinkButton runat="server" ID="lbOnaylaBitir"
                        onclick="lbOnaylaBitir_Click" OnClientClick="TusBasildiGizle(this)">Onayla</asp:LinkButton>
                    <asp:Label runat="server" Width="50px"></asp:Label>
                    <asp:LinkButton runat="server" ID="lbOnaylaKapat"
                        onclick="lbOnaylaKapat_Click">Vazgeç</asp:LinkButton>
                </td></tr>
                </table>
            </div>

            <div style="position: absolute; width: 420px; height: 100px; z-index: 3; left: 290px;
                top: 150px" runat="server" id="divSiparisSil" visible="false">
                <div style="position: fixed; width: 100%; height: 100%; z-index: -1; left: 0; top: 0;
                filter: alpha(opacity=40); -moz-opacity: .40; opacity: .40; background-color: #000000" onclick="invisible()"></div>
                <table style="width: 420px; height: 100px; background-color: #ffffff; font-family: Tahoma; font-size: 12px;
                    border: 1px solid #D1D1D1; border-radius: 5px; padding: 5px;">
                <tr>
                <td align="center" valign="middle" style="padding-top: 15px; padding-bottom: 15px">
                    Siparişi silmek istediğinize emin misiniz?
                    <br /><br />
                    <asp:LinkButton runat="server" ID="lbSiparisSilEvet" 
                        onclick="lbSiparisSilEvet_Click">Evet</asp:LinkButton>
                        <asp:Label runat="server" Width="50px"></asp:Label>
                    <asp:LinkButton runat="server" ID="lbSiparisSilHayir" 
                        onclick="lbSiparisSilHayir_Click">Hayır</asp:LinkButton>
                </td>
                </tr>
                </table>
            </div>

            <div style="position: absolute; width: 420px; height: 100px; z-index: 3; left: 290px;
                top: 150px;" runat="server" id="divSiparisKaydet" visible="false">
                <div style="position: fixed; width: 100%; height: 100%; z-index: -1; left: 0; top: 0;
                filter: alpha(opacity=40); -moz-opacity: .40; opacity: .40; background-color: #000000" onclick="invisible()"></div>
                <table style="width: 100%; height: 100%; background-color: #ffffff; font-family: Tahoma; font-size: 12px;
                    border: 1px solid #D1D1D1; border-radius: 5px; padding: 5px;">
                <tr>
                <td align="center" valign="middle" style="padding-top: 15px; padding-bottom: 15px">
                    <iframe frameborder="0" src="indir.aspx" width="100%" height="120px"></iframe>
                    <asp:LinkButton runat="server" ID="lbSiparisKaydetKapat" 
                        onclick="lbSiparisKaydetKapat_Click">Kapat</asp:LinkButton>
                </td>
                </tr>
                </table>
            </div>

            <div style="position: absolute; width: 550px; height: 100px; z-index: 3; left: 225px;
                top: 150px" runat="server" id="divSiparisEposta" visible="false">
                <div style="position: fixed; width: 100%; height: 100%; z-index: -1; left: 0; top: 0;
                filter: alpha(opacity=40); -moz-opacity: .40; opacity: .40; background-color: #000000" onclick="invisible()"></div>
                <table style="width: 100%; height: 100%; background-color: #ffffff; font-family: Tahoma; font-size: 12px;
                    border: 1px solid #D1D1D1; border-radius: 5px; padding: 5px;">
                <tr>
                <td align="center" valign="middle" style="padding-top: 15px; padding-bottom: 15px">
                    <asp:Label runat="server" ID="lblEpostaGonder"></asp:Label>
                    <br /><br /><br />
                    <asp:LinkButton runat="server" ID="lbSiparisEpostaKapat" 
                        onclick="lbSiparisEpostaKapat_Click">Kapat</asp:LinkButton>
                </td>
                </tr>
                </table>
            </div>

            <div style="position: absolute; width: 700px; height: 550px; z-index: 4; left: 150px;
                top: 5px" runat="server" id="divOdeme" visible="false">
                <div style="position: fixed; width: 100%; height: 100%; z-index: -1; left: 0; top: 0;
                filter: alpha(opacity=40); -moz-opacity: .40; opacity: .40; background-color: #000000" onclick="invisible()"></div>
                <table style="width: 100%; height: 100%; background-color: #ffffff; font-family: Tahoma; font-size: 12px;
                    border: 1px solid #D1D1D1; border-radius: 5px; padding: 5px;">
                <tr>
                <td align="center" style="padding-top: 10px;">
                    <span style="color: #C00000">Ödeme</span>
                </td>
                </tr>
                <tr>
                <td align="center" style="font-style: italic; font-size: 10px; padding-top: 5px;">
                    <%--* Ödeme yapmadan siparişi onaylamak için, altta bulunan "Ödeme Ekranını Kapat"ı tıklayınız.--%>
                </td>
                </tr>
                <tr>
                <td align="center" valign="middle" style="padding-top: 10px; padding-bottom: 10px">
                    <iframe frameborder="0" src="odeme1.aspx" width="650px" height="500px"></iframe>
                </td>
                </tr>
                <tr>
                <td align="center" style="padding-bottom: 10px;">
                    <asp:LinkButton runat="server" ID="lbOdemeVazgec" 
                        onclick="lbOdemeVazgec_Click">Ödeme Ekranını Kapat</asp:LinkButton>
                </td>
                </tr>
                </table>
            </div>

            <div style="position: absolute; width: 400px; height: 300px; z-index: 3; left: 300px;
                top: 150px" runat="server" id="divOdemeAyrinti" visible="false">
                <div style="position: fixed; width: 100%; height: 100%; z-index: -1; left: 0; top: 0;
                filter: alpha(opacity=40); -moz-opacity: .40; opacity: .40; background-color: #000000" onclick="invisible()"></div>
                <table style="width: 100%; height: 100%; background-color: #ffffff; font-family: Tahoma; font-size: 12px;
                    border: 1px solid #D1D1D1; border-radius: 5px; padding: 5px;">
                <tr>
                <td align="center" style="padding-top: 10px;">
                <table cellpadding="0" cellspacing="0">
                <tr>
                    <td style="width: 100%; text-align: center">
                        <span style="color: #C00000">Ödeme Ayrıntıları</span>
                    </td>
                    <td align="right" style="padding-right: 5px">
                        <asp:ImageButton ID="ibOdemeAyrintiYazdir" runat="server" ToolTip="Yazdır" ImageUrl="img/yazdir.gif" OnClientClick="OdemeAyrintiYazdir();" OnClick="ibOdemeAyrintiYazdir_Click" />
                    </td>
                </tr>
                </table>
                </td>
                </tr>
                <tr>
                <td align="center" valign="middle" style="padding-top: 10px; padding-bottom: 10px">
                    <table cellpadding="5" cellspacing="0">
                        <tr><td align="right">Sipariş No:</td><td align="left"><asp:Label runat="server" ID="lblOdemeAyrintiSiparisNo"></asp:Label></td></tr>
                        <tr><td align="right">Kredi Kartı:</td><td align="left"><asp:Label runat="server" ID="lblOdemeAyrintiKrediKart"></asp:Label></td></tr>
                        <tr><td align="right">Tutar:</td><td align="left"><asp:Label runat="server" ID="lblOdemeAyrintiTutar"></asp:Label></td></tr>
                        <tr><td align="right">Ödeme Tarihi:</td><td align="left"><asp:Label runat="server" ID="lblOdemeAyrintiTarih"></asp:Label></td></tr>
                        <tr><td align="right">Provizyon No:</td><td align="left"><asp:Label runat="server" ID="lblOdemeAyrintiAuth"></asp:Label></td></tr>
                        <tr><td align="right">Referans No:</td><td align="left"><asp:Label runat="server" ID="lblOdemeAyrintiHostRef"></asp:Label></td></tr>
                        <tr><td align="right">İşlem No:</td><td align="left"><asp:Label runat="server" ID="lblOdemeAyrintiTransID"></asp:Label></td></tr>
                    </table>
                </td>
                </tr>
                <tr>
                <td align="center" style="padding-bottom: 10px;">
                    <asp:LinkButton runat="server" ID="lbOdemeAyrintiKapat"
                        onclick="lbOdemeAyrintiKapat_Click">Kapat</asp:LinkButton>
                </td>
                </tr>
                </table>
            </div>

            <div style="position: absolute; width: 420px; height: 100px; z-index: 4; left: 290px;
                top: 150px" runat="server" id="divSiparisAktarilmisHata" visible="false">
                <div style="position: fixed; width: 100%; height: 100%; z-index: -1; left: 0; top: 0;
                filter: alpha(opacity=40); -moz-opacity: .40; opacity: .40; background-color: #000000" onclick="invisible()"></div>
                <table style="width: 100%; height: 100%; background-color: #ffffff; font-family: Tahoma; font-size: 12px;
                    border: 1px solid #D1D1D1; border-radius: 5px; padding: 5px;">
                <tr>
                <td align="center" valign="middle" style="padding-top: 15px; padding-bottom: 15px">
                    Bu sipariş zaten onaylanmış.
                    <br /><br />
                    <asp:LinkButton runat="server" ID="lbSiparisAktarilmisHata" 
                        onclick="lbSiparisAktarilmisHata_Click">Kapat</asp:LinkButton>
                </td>
                </tr>
                </table>
            </div>

            <div style="position: absolute; width: 420px; height: 100px; z-index: 3; left: 290px;
                top: 150px" runat="server" id="divStokYetersiz" visible="false">
                <div style="position: fixed; width: 100%; height: 100%; z-index: -1; left: 0; top: 0;
                filter: alpha(opacity=40); -moz-opacity: .40; opacity: .40; background-color: #000000" onclick="invisible()"></div>
                <table style="width: 100%; height: 100%; background-color: #ffffff; font-family: Tahoma; font-size: 12px;
                    border: 1px solid #D1D1D1; border-radius: 5px; padding: 5px;">
                <tr>
                <td align="center" valign="middle" style="padding-top: 15px; padding-bottom: 15px">
                    <asp:Label runat="server" ID="lblYetersizStokluUrunler" Font-Italic="true"></asp:Label>
                    <br />
                    Bu ürün veya ürünlerde stok durumu yetersiz görünüyor. Yine de devam etmek istiyor musunuz?
                    <br /><br />
                    <asp:LinkButton runat="server" ID="lbStokYetersizEvet" 
                        onclick="lbStokYetersizEvet_Click">Evet</asp:LinkButton>
                        <asp:Label runat="server" Width="50px"></asp:Label>
                    <asp:LinkButton runat="server" ID="lbStokYetersizHayir" 
                        onclick="lbStokYetersizHayir_Click">Hayır</asp:LinkButton>
                </td>
                </tr>
                </table>
            </div>

            <div style="position: absolute; width: 420px; height: 100px; z-index: 3; left: 290px;
                top: 150px" runat="server" id="divAyniMusteriyeSiparis" visible="false">
                <div style="position: fixed; width: 100%; height: 100%; z-index: -1; left: 0; top: 0;
                filter: alpha(opacity=40); -moz-opacity: .40; opacity: .40; background-color: #000000" onclick="invisible()"></div>
                <table style="width: 100%; height: 100%; background-color: #ffffff; font-family: Tahoma; font-size: 12px;
                    border: 1px solid #D1D1D1; border-radius: 5px; padding: 5px;">
                <tr>
                <td align="center" valign="middle" style="padding-top: 15px; padding-bottom: 15px">
                    Aynı müşteriye tekrar sipariş girmek istiyor musunuz?
                    <br /><br />
                    <asp:LinkButton runat="server" ID="lbAyniMusteriyeSiparisEvet" 
                        onclick="lbAyniMusteriyeSiparisEvet_Click">Evet</asp:LinkButton>
                        <asp:Label runat="server" Width="50px"></asp:Label>
                    <asp:LinkButton runat="server" ID="lbAyniMusteriyeSiparisHayir" 
                        onclick="lbAyniMusteriyeSiparisHayir_Click">Hayır</asp:LinkButton>
                </td>
                </tr>
                </table>
            </div>

            <div style="position: absolute; width: 420px; height: 100px; z-index: 4; left: 290px;
                top: 150px" runat="server" id="divSiparisOnaylamama" visible="false">
                <div style="position: fixed; width: 100%; height: 100%; z-index: -1; left: 0; top: 0;
                filter: alpha(opacity=40); -moz-opacity: .40; opacity: .40; background-color: #000000" onclick="invisible()"></div>
                <table style="width: 100%; height: 100%; background-color: #ffffff; font-family: Tahoma; font-size: 12px;
                    border: 1px solid #D1D1D1; border-radius: 5px; padding: 5px;">
                <tr>
                <td align="center" valign="middle" style="padding-top: 15px; padding-bottom: 15px">
                    Bazı siparişleriniz onaylanamamaktadır, lütfen daha sonra tekrar deneyiniz.
                    <br /><br />
                    <asp:LinkButton runat="server" 
                        onclick="lbSiparisOnaylanamadiKapat_Click">Kapat</asp:LinkButton>
                </td>
                </tr>
                </table>
            </div>

            <div style="position: absolute; width: 420px; height: 100px; z-index: 4; left: 290px;
                top: 150px" runat="server" id="divSiparisOnaylanamadi" visible="false">
                <div style="position: fixed; width: 100%; height: 100%; z-index: -1; left: 0; top: 0;
                filter: alpha(opacity=40); -moz-opacity: .40; opacity: .40; background-color: #000000" onclick="invisible()"></div>
                <table style="width: 100%; height: 100%; background-color: #ffffff; font-family: Tahoma; font-size: 12px;
                    border: 1px solid #D1D1D1; border-radius: 5px; padding: 5px;">
                <tr>
                <td align="center" valign="middle" style="padding-top: 15px; padding-bottom: 15px">
                    Sipariş (eğer sipariş bölünmüş ise siparişlerden en az birisi, veya toplu onaylama ise siparişlerden en az birisi) onaylanamadı, lütfen daha sonra tekrar deneyiniz.
                    <br /><br />
                    <asp:Label runat="server" ID="lblSiparisOnaylanamadiHata" ForeColor="DarkRed" Font-Bold="true"></asp:Label>
                    <br /><br />
                    <asp:LinkButton runat="server" ID="lbSiparisOnaylanamadiKapat" 
                        onclick="lbSiparisOnaylanamadiKapat_Click">Kapat</asp:LinkButton>
                </td>
                </tr>
                </table>
            </div>

            <div style="position: absolute; width: 420px; height: 100px; z-index: 4; left: 290px;
                top: 150px" runat="server" id="divExcelSiparisHata" visible="false">
                <div style="position: fixed; width: 100%; height: 100%; z-index: -1; left: 0; top: 0;
                filter: alpha(opacity=40); -moz-opacity: .40; opacity: .40; background-color: #000000" onclick="invisible()"></div>
                <table style="width: 100%; height: 100%; background-color: #ffffff; font-family: Tahoma; font-size: 12px;
                    border: 1px solid #D1D1D1; border-radius: 5px; padding: 5px;">
                <tr>
                <td align="center" valign="middle" style="padding-top: 15px; padding-bottom: 15px">
                    Excel formatında hata var veya müşteri yada fiyat tipine yetkili değilsiniz.
                    <br /><br />
                    <asp:LinkButton ID="lbExcelSiparisKapat" runat="server" 
                        onclick="lbExcelSiparisKapat_Click">Kapat</asp:LinkButton>
                </td>
                </tr>
                </table>
            </div>

            <div style="position: absolute; z-index: 4; left: 804px; top: 252px" id="divTopluIslemler">
                <table style="width: 100%; height: 100%; background-color: #ffffff; font-family: Tahoma; font-size: 10px;
                    border: 1px solid #D1D1D1; border-radius: 5px; padding: 5px;" id="tblTopluIslemler">
                <tr>
                <td align="center" valign="middle">
                    <asp:Button runat="server" ID="btnTumunuOnayla" Text="Onayla" OnClientClick="TusBasildiGizle(this)" OnClick="btnTumunuOnayla_Click" Enabled="false" Width="170px" />
                </td>
                </tr>
                <tr>
                <td align="center" valign="middle">
                    <asp:Button runat="server" ID="btnTumunuSil" Text="Sil" OnClientClick="TusBasildiGizle(this)" OnClick="btnTumunuSil_Click" Enabled="true" Width="170px" />
                </td>
                </tr>
                </table>
            </div>

            <div style="position: absolute; width: 420px; height: 150px; z-index: 4; left: 290px;
                top: 150px" runat="server" id="divOdemeYap" visible="false">
                <div style="position: fixed; width: 100%; height: 100%; z-index: -1; left: 0; top: 0;
                filter: alpha(opacity=40); -moz-opacity: .40; opacity: .40; background-color: #000000" onclick="invisible()"></div>
                <table style="width: 100%; height: 100%; background-color: #ffffff; font-family: Tahoma; font-size: 12px;
                    border: 1px solid #D1D1D1; border-radius: 5px; padding: 5px;">
                <tr>
                <td align="center" valign="middle" style="padding-top: 15px; padding-bottom: 15px">
                    <span style="color: #C00000">Ödeme</span>
                    <br /><br />
                    <div runat="server" id="divOdemeYapUyari" visible="false" style="color: White; background-color: Red; font-size: 24px"><u>Uyarı:</u> Finans biriminden siparişinizin hazırlanıp faturası kesildiğine dair bilgi almadıkça lütfen ödeme yapmayınız!</div><br /><br />
                    <asp:DropDownList ID="ddlOdemeYapSiparisler" runat="server" Width="400px" AutoPostBack="True" 
                    Font-Bold="False" Font-Italic="False" Height="25px"
                    Font-Overline="False" Font-Size="11px" Font-Strikeout="False" 
                    Font-Underline="False" style="filter: alpha(opacity=80); -moz-opacity: .80; opacity: .80; padding: 3px 3px 3px 3px;border:1px solid #CCCCCC;background:#ededed;" 
                    onselectedindexchanged="ddlOdemeYapSiparisler_SelectedIndexChanged" 
                    ForeColor="#006699">
                    </asp:DropDownList>
                    <br /><br />
                    <asp:LinkButton runat="server" ID="lbOdemeYapKapat" onclick="lbOdemeYapKapat_Click">Kapat</asp:LinkButton>
                </td>
                </tr>
                </table>
            </div>

            <div style="position: absolute; width: 420px; height: 150px; z-index: 4; left: 290px;
                top: 150px" runat="server" id="divOdemeYap2" visible="false">
                <div style="position: fixed; width: 100%; height: 100%; z-index: -1; left: 0; top: 0;
                filter: alpha(opacity=40); -moz-opacity: .40; opacity: .40; background-color: #000000" onclick="invisible()"></div>
                <table style="width: 100%; height: 100%; background-color: #ffffff; font-family: Tahoma; font-size: 12px;
                    border: 1px solid #D1D1D1; border-radius: 5px; padding: 5px;">
                <tr>
                <td align="center" valign="middle" style="padding-top: 15px; padding-bottom: 15px">
                    <span style="color: #C00000">Ödeme</span>
                    <br /><br />
                    Siparişin ne kadarlık tutarını ödemek istiyorsunuz?
                    <br /><br />
                    <asp:TextBox runat="server" ID="txtOdemeYapTutar" Width="150px" ForeColor="#006699" BorderColor="#A3B5C9" 
                        BorderStyle="Solid" BorderWidth="1px" Height="23px" style="padding: 0px 3px 0px 3px"></asp:TextBox>
                    (Örnek: 20,00)
                    <br /><br />
                    <div runat="server" id="divOdemeYap2Uyari" visible="false" style="color: Red"><u>Uyarı:</u> Ödeme tutarı sipariş tutarından büyük olamaz!<br /><br /></div>
                    <asp:LinkButton runat="server" ID="lbOdemeYapTutarDevamEt" onclick="lbOdemeYapTutarDevamEt_Click">Devam et</asp:LinkButton>
                </td>
                </tr>
                </table>
            </div>



            <div style="position: absolute; width: 800px; height: 416px; z-index: 4; left: 100px; background-color: #ffffff;
                top: 50px;" runat="server" id="divSiparis" visible="false">
                <div style="position: fixed; width: 100%; height: 100%; z-index: -1; left: 0; top: 0;
                filter: alpha(opacity=40); -moz-opacity: .40; opacity: .40; background-color: #000000" onclick="invisible()"></div>
                <div style="width: 100%; height: 100%; background-color: #ffffff;border: 1px solid #D1D1D1; border-radius: 5px; padding: 5px;">
                <table cellpadding="10" cellspacing="0" style="font-family: Tahoma; font-size:14px; width: 800px; height: 40px">
                <tr>
                <td valign="middle">
                <asp:Label runat="server" ID="lblSiparisDetaylari" Font-Bold="true" Visible="true">Sipariş Detayları</asp:Label><asp:Label runat="server" ID="lblSiparisSonDurum" Font-Bold="true" Visible="false">Siparişinizin Son Durumu</asp:Label>
                <asp:Label runat="server" Width="180px"></asp:Label>
                <asp:LinkButton runat="server" ID="lbOnaylamayaDevam" Font-Underline="true" Font-Size="16px" Font-Bold="true" Text="Devam Et" OnClick="lbOnaylamayaDevam_Click" Visible="false"></asp:LinkButton></td>
                <td valign="middle" align="right"><asp:LinkButton runat="server" ID="lbSiparisKapat" OnClick="lbSiparisKapat_Click" Font-Underline="False" Font-Bold="true" Text="X" /></td>
                </tr>
                </table>
                <table width="780px" cellpadding="10" cellspacing="0" style="font-family: Tahoma; font-size: 11px; height: 40px">
                    <tr style="color: #C00000">
                        <td style="width: 500px; font-size:12px;">
                            <asp:Label runat="server" Width="70px"></asp:Label>Ürün
                        </td>
                        <td align="center" style="width: 60px; font-size:12px">
                            Miktar
                        </td>
                        <td align="center" style="width: 60px; font-size:12px">
                            Fiyat
                        </td>
                        <td align="center" style="width: 70px; font-size:12px">
                            Toplam
                        </td>
                        <td align="center" style="width: 50px; font-size:12px">
                            Koli
                        </td>
                    </tr>
                </table>
                <div style="overflow: auto; width:800px; height: 280px">
                <asp:Repeater ID="Repeater1" runat="server">
                    <HeaderTemplate>
                        <table width="780px" cellpadding="10" cellspacing="0" style="font-family: Tahoma; font-size: 11px">
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr style="background-color: #E8E8E8">
                            <td style="width: 500px">
                                <%#Eval("Ad") %></td>
                            <td align="center" style="width: 60px;">
                                <%#Eval("Miktar")%> (<%#Eval("MiktarTur").ToString() == "ST" ? "Adet" : Eval("MiktarTur").ToString() == "KI" ? "Koli" : Eval("MiktarTur").ToString() == "PAK" ? "Paket" : "Adet" %>)
                            </td>
                            <td align="right" style="width: 60px;">
                                <%#Convert.ToDecimal(Eval("BirimFiyat")).ToString("N3")%> TL
                            </td>
                            <td align="right" style="width: 70px;">
                                <%#Convert.ToBoolean(Eval("KampanyaHediye")) ? "0,000 TL" :  (Convert.ToInt32(Eval("Miktar")) * Convert.ToDecimal(Eval("BirimFiyat"))).ToString("C3")%>
                            </td>
                            <td align="center" style="width: 50px;">
                                <%#Sultanlar.DatabaseObject.Internet.SiparislerDetay.GetKoliToplam(Convert.ToInt64(Eval("SiparisDetayID"))).ToString("N1")%>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                        <tr style="background-color: #FFE2C6">
                            <td style="width: 500px">
                                <%#Eval("Ad") %></td>
                            <td align="center" style="width: 60px;">
                                <%#Eval("Miktar")%>  (<%#Eval("MiktarTur").ToString() == "ST" ? "Adet" : Eval("MiktarTur").ToString() == "KI" ? "Koli" : Eval("MiktarTur").ToString() == "PAK" ? "Paket" : "Adet" %>)
                            </td>
                            <td align="right" style="width: 60px;">
                                <%#Convert.ToDecimal(Eval("BirimFiyat")).ToString("N3")%> TL
                            </td>
                            <td align="right" style="width: 70px;">
                                <%#Convert.ToBoolean(Eval("KampanyaHediye")) ? "0,000 TL" :  (Convert.ToInt32(Eval("Miktar")) * Convert.ToDecimal(Eval("BirimFiyat"))).ToString("C3")%>
                            </td>
                            <td align="center" style="width: 50px;">
                                <%#Sultanlar.DatabaseObject.Internet.SiparislerDetay.GetKoliToplam(Convert.ToInt64(Eval("SiparisDetayID"))).ToString("N1")%>
                            </td>
                        </tr>
                    </AlternatingItemTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
                </div>
                <table cellpadding="10" cellspacing="0" style="font-family: Tahoma; font-size:12px; width: 800px; height: 40px">
                <tr>
                <td valign="middle">
                <table cellpadding="0" cellspacing="0" width="100%">
                <tr>
                <td>
                <asp:Label runat="server" ID="lblSiparisAciklama" Font-Size="11px" />
                <asp:Label runat="server" Width="100px" />
                <asp:Label runat="server" ID="lblOrtalamaVade" />
                </td>
                <td align="right">Sip.Toplamı: </td>
                </tr>
                </table>
                </td>
                <td valign="middle" align="right" style="width: 120px"><asp:Label runat="server" ID="lblSiparisToplam" Font-Bold="true" /></td>
                </tr>
                </table>
                </div>
            </div>



            <div style="position: absolute; width: 920px; height: 416px; z-index: 4; left: 40px; background-color: #ffffff;
                top: 50px;" runat="server" id="divDurum" visible="false">
                <div style="position: fixed; width: 100%; height: 100%; z-index: -1; left: 0; top: 0;
                filter: alpha(opacity=40); -moz-opacity: .40; opacity: .40; background-color: #000000" onclick="invisible()"></div>
                <div style="width: 100%; height: 100%; background-color: #ffffff;border: 1px solid #D1D1D1; border-radius: 5px; padding: 5px;">
                <table cellpadding="10" cellspacing="0" style="font-family: Tahoma; font-size:14px; width: 920px; height: 40px">
                <tr>
                <td valign="middle">
                <asp:Label runat="server" Font-Bold="true" Visible="true">Sipariş Durumu</asp:Label> (<asp:LinkButton ID="lbDurumSiparisNo" runat="server" Font-Bold="true" OnClick="lbDurumSiparisNo_Click" ToolTip="Bakiye ürünlerden yeni bir sipariş oluştur"></asp:LinkButton>)
                </td>
                <td valign="middle" align="right"><asp:LinkButton runat="server" ID="lbDurumKapat" OnClick="lbDurumKapat_Click" Font-Underline="False" Font-Bold="true" Text="X" /></td>
                </tr>
                </table>

                <table runat="server" id="tblDurumBaslik" visible="false" width="920px" cellpadding="10" cellspacing="0" style="font-family: Tahoma; font-size: 11px; height: 40px">
                    <tr>
                        <td align="center" style="width: 80px; font-size:12px;">
                            Web No:
                        </td>
                        <td align="center" style="width: 100px; font-size:12px;">
                            <asp:TextBox runat="server" ID="txtDurumWebNo" Width="100px"></asp:TextBox>
                        </td>
                        <td align="center" style="width: 80px; font-size:12px;">
                            Sap No:
                        </td>
                        <td align="center" style="width: 100px; font-size:12px;">
                            <asp:TextBox runat="server" ID="txtDurumSapNo" Width="100px"></asp:TextBox>
                        </td>
                        <td align="center" style="width: 100px; font-size:12px;">
                            <asp:Button runat="server" ID="btnDurumGetir" Text="Getir" OnClick="lbDurumGetir_Click" />
                        </td>
                    </tr>
                </table>

                <table width="920px" cellpadding="10" cellspacing="0" style="font-family: Tahoma; font-size: 11px; height: 40px">
                    <tr style="color: #C00000">
                        <td align="center" style="width: 80px; font-size:12px;">
                            Kod
                        </td>
                        <td align="center"  style="width: 450px; font-size:12px;">
                            Ürün
                        </td>
                        <td align="center" style="width: 85px; font-size:12px">
                            Sip.Ad.
                        </td>
                        <td align="center" style="width: 85px; font-size:12px">
                            Tsl.Ad.
                        </td>
                        <td align="center" style="width: 85px; font-size:12px">
                            İrs.Ad.
                        </td>
                        <td align="center" style="width: 85px; font-size:12px">
                            Bky.Ad.
                        </td>
                    </tr>
                </table>
                <div style="overflow: auto; width:920px; height: 280px">
                <asp:Repeater ID="rptDurum" runat="server">
                    <HeaderTemplate>
                        <table width="900px" cellpadding="10" cellspacing="0" style="font-family: Tahoma; font-size: 11px">
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr style="background-color: #E8E8E8">
                            <td align="center" style="width: 80px">
                                <%#Eval("MALZ_KOD")%></td>
                            <td style="width: 500px">
                                <%#Sultanlar.DatabaseObject.Internet.Urunler.GetProductName(Convert.ToInt32(Eval("MALZ_KOD")), true)%></td>
                            <td align="center" style="width: 85px;">
                                <%#Eval("SIP_AD")%>
                            </td>
                            <td align="center" style="width: 85px;">
                                <%#Eval("TSL_AD")%>
                            </td>
                            <td align="center" style="width: 85px;">
                                <%#Eval("IRS_AD")%>
                            </td>
                            <td align="center" style="width: 85px;">
                                <asp:Label runat="server" class="kucukbilgiGoster" ToolTip='<%#Eval("RED_NEDENI").ToString() == string.Empty ? "---" : Eval("RED_NEDENI")%>'><%#Eval("BKY_AD")%></asp:Label> 
                            </td>
                        </tr>
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                        <tr style="background-color: #FFE2C6">
                            <td align="center"  style="width: 80px">
                                <%#Eval("MALZ_KOD")%></td>
                            <td style="width: 500px">
                                <%#Sultanlar.DatabaseObject.Internet.Urunler.GetProductName(Convert.ToInt32(Eval("MALZ_KOD")), true)%></td>
                            <td align="center" style="width: 85px;">
                                <%#Eval("SIP_AD")%>
                            </td>
                            <td align="center" style="width: 85px;">
                                <%#Eval("TSL_AD")%>
                            </td>
                            <td align="center" style="width: 85px;">
                                <%#Eval("IRS_AD")%>
                            </td>
                            <td align="center" style="width: 85px;">
                                <asp:Label runat="server" class="kucukbilgiGoster" ToolTip='<%#Eval("RED_NEDENI")%>'><%#Eval("BKY_AD")%></asp:Label> 
                            </td>
                        </tr>
                    </AlternatingItemTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
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
        <input type="button" value="Siparişler" disabled="disabled" /> 
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
            <table cellpadding="0" cellspacing="0"><tr>
            <td><img src="img/ic_siparisler.png" /></td>
            <td style="width: 500px">Siparişler<asp:Label runat="server" Width="30px"></asp:Label><input style="font-size: 10px; font-style: italic" type="button" value="Sistemdeki Siparişler" onclick="javascript:window.location.href='siparislersap.aspx'" /><input style="font-size: 10px; font-style: italic" type="button" value="Sistemdeki Siparişler Detayı" onclick="javascript:window.location.href='siparislersapdetay.aspx'" /><input style="font-size: 10px; font-style: italic" type="button" value="Sipariş Durumları" onclick="javascript:window.location.href='siparislerdurum.aspx'" />
            </td>
            <td align="right" style="width: 200px">
            <div runat="server" id="divSiparisVer" visible="false">
                <asp:Button runat="server" ID="btnOdemeYap" Text="Ödeme Yap" Font-Bold="true" Font-Size="14px" Width="150px" 
                    onclick="btnOdemeYap_Click" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" ForeColor="#6D8AAA" />
                <asp:Button runat="server" ID="btnSiparisVer" Text="Sipariş Ver" Font-Bold="true" Font-Size="14px" Width="150px" 
                    onclick="btnSiparisVer_Click" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" ForeColor="#6D8AAA" />
            </div>
            </td>
            </tr></table>
            </div>
            <div style="padding: 10px 10px 0px 25px; font-size: 12px" runat="server" id="divHesapSecim">
            <div runat="server" id="divCariHesapArama" visible="false" style="padding: 5px 5px 5px 0px;">
                <asp:RadioButton runat="server" ID="rbCariHesapAraMusteri" GroupName="grCariHesapAra" Text="Müşteri" />&nbsp;
                <asp:RadioButton runat="server" ID="rbCariHesapAraSattem" Checked="true" GroupName="grCariHesapAra" Text="Satış Temsilcisi" />&nbsp;
                <asp:RadioButton runat="server" ID="rbCariHesapUye" Checked="true" GroupName="grCariHesapAra" Text="Üye" />&nbsp;
                <asp:TextBox runat="server" ID="txtCariHesapAra" Width="150px" onkeypress="return clickButton(event,'btnCariHesapAra')"
                    ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" BorderWidth="1px" Height="23px" style="padding: 0px 3px 0px 3px"></asp:TextBox>&nbsp;
                <asp:Button runat="server" ID="btnCariHesapAra" Width="100px" Text="Ara" OnClick="btnCariHesapAra_Click" 
                    BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" ForeColor="#6D8AAA" BackColor="#ededed" />&nbsp;
                <%--<asp:Button runat="server" ID="btnCariHesapTemizle" Width="100px" Text="Tümünü Getir" OnClick="btnCariHesapTemizle_Click"
                    BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" ForeColor="#6D8AAA" />&nbsp;--%>
                <asp:Label runat="server" Width="100px"></asp:Label>
                <asp:DropDownList runat="server" ID="ddlSefAltlarBayiSatici" AutoPostBack="true" Width="100px"
                    Font-Bold="False" Font-Italic="False" Height="25px" OnSelectedIndexChanged="ddlSefAltlar_SelectedIndexChanged"
                    Font-Overline="False" Font-Size="12px" Font-Strikeout="False" 
                    Font-Underline="False" style="padding: 3px 3px 3px 3px;border:1px solid #CCCCCC;background:#ededed;" ForeColor="#006699">
                    <asp:ListItem Text="Satıcı" Value="0" Selected="True"></asp:ListItem>
                    <asp:ListItem Text="Bayi" Value="1"></asp:ListItem>
                </asp:DropDownList>
            </div>
                <table cellpadding="0" cellspacing="0">
                <tr>
                <td valign="middle">
                <asp:DropDownList ID="ddlTemsilciler" runat="server" Width="200px" AutoPostBack="True" 
                    Font-Bold="False" Font-Italic="False" Height="25px"
                    Font-Overline="False" Font-Size="11px" Font-Strikeout="False" 
                    Font-Underline="False" style="filter: alpha(opacity=80); -moz-opacity: .80; opacity: .80; padding: 3px 3px 3px 3px;border:1px solid #CCCCCC;background:#ededed;" 
                    onselectedindexchanged="ddlTemsilciler_SelectedIndexChanged" 
                    ForeColor="#006699">
                </asp:DropDownList>
                <asp:Label runat="server" Width="3px"></asp:Label>
                <asp:DropDownList ID="ddlCariHesaplar" runat="server" Width="500px" AutoPostBack="True" 
                                                    Font-Bold="False" Font-Italic="False" Height="25px"
                    Font-Overline="False" Font-Size="11px" 
                                                    Font-Strikeout="False" 
                    Font-Underline="False" style="filter: alpha(opacity=80); -moz-opacity: .80; opacity: .80; padding: 3px 3px 3px 3px;border:1px solid #CCCCCC;background:#ededed;"
                    onselectedindexchanged="ddlCariHesaplar_SelectedIndexChanged" 
                    ForeColor="#006699">
                </asp:DropDownList>
                </td>
                <td valign="middle"><asp:Label runat="server" Width="3px"></asp:Label>
                <asp:ImageButton Visible="false" ImageUrl="img/ic_tarih.png" runat="server" ID="ibTarih" OnClick="ibTarih_Click" ToolTip="Tarihe Göre" class="kucukbilgiGoster" />
                <button type="button" id="btTarih" name="btTarih" onclick="btTarihClick()">Tarih Aralığı</button><asp:LinkButton Text="" runat="server" ID="lbTarih" OnClick="lbTarih_Click" />
                <asp:Label runat="server" Width="3px"></asp:Label>
                <asp:Button runat="server" ID="btnDurumlar" Text="Sip.Durum" OnClick="btnDurumlar_Click" />
                </td>
                </tr>
                </table>
                <asp:Label runat="server" Width="207px"></asp:Label>
                <asp:DropDownList ID="ddlCariHesaplarSubeler" runat="server" 
                    AutoPostBack="True" Font-Bold="False" Font-Italic="False" Font-Overline="False" Height="25px"
                    Font-Size="11px" Font-Strikeout="False" 
                    Font-Underline="False" style="filter: alpha(opacity=80); -moz-opacity: .80; opacity: .80; padding: 3px 3px 3px 3px;border:1px solid #CCCCCC;background:#ededed;" 
                    onselectedindexchanged="ddlCariHesaplarSubeler_SelectedIndexChanged" 
                    Width="500px" ForeColor="#006699" Visible="false">
                </asp:DropDownList>
                </div>
                <div style="padding: 3px 3px 3px 25px; font-size: 11px">
                    <asp:RadioButton runat="server" ID="rbSiparislerHepsi" Text="Hepsi" AutoPostBack="true" 
                        GroupName="grOnaySuzme" OnCheckedChanged="rbSiparislerHepsi_Checked" />
                    <asp:RadioButton runat="server" ID="rbSiparislerOnaylilar" Text="Onaylanmış" AutoPostBack="true" 
                        GroupName="grOnaySuzme" OnCheckedChanged="rbSiparislerHepsi_Checked" />
                    <asp:RadioButton runat="server" ID="rbSiparislerOnaysizlar" Text="Onaylanmamış" AutoPostBack="true" Checked="true"
                        GroupName="grOnaySuzme" OnCheckedChanged="rbSiparislerHepsi_Checked" />
                    <%--<asp:LinkButton runat="server" ID="lbTarih" OnClick="lbTarih_Click">Tarihe Göre</asp:LinkButton>--%>
                    <asp:Label runat="server" Width="100px"></asp:Label>
                    <span class="kucukbilgiGoster" title="Örnek excel dosyasına 'Giriş' sayfasında 'Uygulamalar' başlığı altındaki 'Formlar' bağlantısıyla ulaşabilirsiniz.<br>Dosya ismi: 'ORNEK EXCEL SIPARISI'">Excel'den sipariş:</span>
                    <asp:FileUpload ID="fuExcel" runat="server" Width="150px" />
                    <asp:Button runat="server" ID="btnExceldenSiparis" Text="Excel'den Sipariş Al" OnClick="btnExceldenSiparis_Click" />
                </div>
                <div style="width: 970px; text-align: right" runat="server" id="divTopluIslemlerTus">
                    <input type="hidden" value="kapali" runat="server" id="inputTopluIslemGosterGizle" />
                    <input type="button" value="Toplu İşlemler" style="width: 150px" onclick="topluislemgostergizle()" />
                </div>
                <table cellpadding="1" cellspacing="0" style="margin-left: 10px; margin-bottom: 5px">
                        <tr style="color: #D00000">
                            <td style="width: 30px; text-align: center; height: 20px; border-bottom: 1px solid #CCCCCC"><asp:CheckBox runat="server" ID="cbSiparislerSecimTumu" AutoPostBack="true" OnCheckedChanged="cbSiparislerSecimTumu_CheckedChanged" ToolTip="Tümünü Seç / Seçimi Temizle" class="kucukbilgiGoster" /></td>
                            <td style="width: 50px; text-align: center; height: 20px; border-bottom: 1px solid #CCCCCC">Sip.No</td>
                            <td style="width: 110px; text-align: left; height: 20px; border-bottom: 1px solid #CCCCCC">Sip.Sahibi</td>
                            <td style="width: 110px; text-align: left; height: 20px; border-bottom: 1px solid #CCCCCC">Sip.Gir.</td>
                            <td style="width: 230px; text-align: left; height: 20px; border-bottom: 1px solid #CCCCCC">C/H Açıklaması</td>
                            <td style="width: 70px; text-align: center; height: 20px; border-bottom: 1px solid #CCCCCC">Sip.Tar.</td>
                            <td style="text-align: center; height: 20px; border-bottom: 1px solid #CCCCCC"><asp:Label runat="server" ID="lblVadeBaslik" Width="40px">Vade</asp:Label></td>
                            <td style="width: 30px; text-align: left; height: 20px; border-bottom: 1px solid #CCCCCC">F.Tip</td>
                            <td style="width: 100px; text-align: right; height: 20px; border-bottom: 1px solid #CCCCCC">Sip.Top.</td>
                            <td style="width: 180px; text-align: center;"></td>
                        </tr></table>
                <asp:DataList ID="dlSiparisler" runat="server" OnItemDataBound="dlSiparisler_DataBound">
                    <HeaderTemplate><table cellpadding="1" cellspacing="0" style="margin-left: 10px">
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr onmouseover="Satir(this,true)" onmouseout="Satir(this,false)">
                            <td style="width: 30px; text-align: center; height: 30px; vertical-align: top">
                                <asp:CheckBox runat="server" AutoPostBack="false" ToolTip='<%#Eval("pkSiparisID")%>' />
                            </td>
                            <td style="width: 50px; text-align: center; height: 30px; vertical-align: top"><%#Eval("pkSiparisID")%></td>
                            <td style="width: 110px; text-align: left; height: 30px; vertical-align: top"><input type="hidden" value='<%#Eval("intMusteriID") %>' id="MusteriID" runat="server" /><%#Eval("strAd")%> <%#Eval("strSoyad")%></td>
                            <td style="width: 110px; text-align: left; height: 30px; vertical-align: top"><%#Eval("strAciklama").ToString().Split(new string[] { ";;;" }, StringSplitOptions.None)[0]%></td>
                            <td style="width: 230px; text-align: left; height: 30px; vertical-align: top; font-size: 8px"><%#Eval("MUSTERI")%></td>
                            <td style="width: 70px; text-align: center; height: 30px; vertical-align: top"><span class="kucukbilgiGoster" title="Onaylama Tarihi: <%#Convert.ToBoolean(Eval("blAktarilmis")) ? Convert.ToDateTime(Eval("dtOnaylamaTarihi")).ToString() : "<i>Sipariş henüz onaylanmamış.</i>"%>"><%#Convert.ToDateTime(Eval("dtOlusmaTarihi")).ToShortDateString()%><br /><%#Convert.ToDateTime(Eval("dtOlusmaTarihi")).ToShortTimeString()%></span></td>
                            <td style="width: 40px; text-align: center; height: 30px; vertical-align: top" runat="server" visible='<%#Convert.ToBoolean(((Sultanlar.DatabaseObject.Internet.Musteriler)Session["Musteri"]).tintUyeTipiID != 1)%>'><%#Eval("VADE").ToString()%></td>
                            <td style="width: 30px; text-align: center; height: 30px; vertical-align: top"><%#Eval("FiyatTipi")%></td>
                            <td style="width: 100px; text-align: right; height: 30px; vertical-align: top"><%#Convert.ToDecimal(Eval("mnToplamTutar")).ToString("C3")%></td>
                            <td style="width: 20px; text-align: center; height: 30px; vertical-align: top">
                                <asp:ImageButton class="kucukbilgiGoster" runat="server" ToolTip="İncele" ImageUrl="img/incele.gif" OnClick="ibIncele_Click" />
                            </td>
                            <td style="width: 20px; text-align: center; height: 30px; vertical-align: top">
                                <asp:ImageButton class="kucukbilgiGoster" runat="server" ToolTip="Kopyala" ImageUrl="img/kopyala.gif" OnClick="ibKopyala_Click" />
                                <%--<asp:LinkButton ID="LinkButton4" runat="server" OnClick="SiparisKopyala_Click" ToolTip="Kopyala">K</asp:LinkButton>--%>
                            </td>
                            <td style="width: 20px; text-align: center; height: 30px; vertical-align: top">
                                <input type="hidden" value='<%#Eval("pkSiparisID") %>' id="SiparisID" runat="server" />
                                <input type="hidden" value='<%#Eval("SMREF") %>' id="SMREF" runat="server" />
                                <asp:ImageButton class="kucukbilgiGoster" runat="server" Visible='<%#Convert.ToBoolean(Convert.ToBoolean(Eval("blAktarilmis")) == false)%>' ToolTip="Değiştir" ImageUrl="img/degistir.gif" OnClick="ibDegistir_Click" />
                                <%--<asp:LinkButton ID="LinkButton2" runat="server" OnClick="SiparisDegistir_Click" Enabled='<%#!Convert.ToBoolean(Eval("blAktarilmis"))%>' ToolTip="Değiştir">D</asp:LinkButton>--%>
                            </td>
                            <td style="width: 20px; text-align: center; height: 30px; vertical-align: top">
                                <asp:ImageButton class="kucukbilgiGoster" runat="server" Visible='<%#!Convert.ToBoolean(Eval("blAktarilmis")) && Eval("FiyatTipi").ToString() != "02-Özel Fiyat" && (((Sultanlar.DatabaseObject.Internet.Musteriler)Session["Musteri"]).tintUyeTipiID != 1 || ((Sultanlar.DatabaseObject.Internet.Musteriler)Session["Musteri"]).blSicakSatis == true)%>' ToolTip="Onayla" ImageUrl="img/onayla.gif" OnClick="ibOnayla_Click" OnClientClick="" />
                                <%--<asp:LinkButton ID="LinkButton3" runat="server" OnClick="SiparisOnayla_Click" Enabled='<%#!Convert.ToBoolean(Eval("blAktarilmis"))%>' ToolTip="Onayla">O</asp:LinkButton>--%>
                            </td>
                            <td style="width: 20px; text-align: center; height: 30px; vertical-align: top">
                                <asp:ImageButton class="kucukbilgiGoster" runat="server" Visible='<%#!Convert.ToBoolean(Eval("blAktarilmis"))%>' ToolTip="Sil" ImageUrl="img/sil.gif" OnClick="ibSil_Click" />
                            </td>
                            <td style="width: 20px; text-align: center; height: 30px; vertical-align: top">
                                <asp:ImageButton class="kucukbilgiGoster" runat="server" ToolTip="Yazdır" ImageUrl="img/yazdir.gif" OnClientClick="Yazdir()" OnClick="ibYazdir_Click" />
                            </td>
                            <td style="width: 20px; text-align: center; height: 30px; vertical-align: top">
                                <asp:ImageButton class="kucukbilgiGoster" runat="server" ToolTip="Kaydet" ImageUrl="img/kaydet.gif" OnClick="ibKaydet_Click" />
                            </td>
                            <td style="width: 20px; text-align: center; height: 30px; vertical-align: top">
                                <%--<asp:ImageButton runat="server" ToolTip="Eposta ile gönder" ImageUrl="img/eposta.gif" OnClick="ibEposta_Click" />--%>
                                <%--<a href='mailto:?Subject=Sipariş&Body=Sipariş No: <%#Eval("pkSiparisID")%>%0D%0A'><img alt="Eposta ile gönder" src="img/eposta.gif" border="0" /></a>--%>
                                <asp:ImageButton class="kucukbilgiGoster" runat="server" ToolTip="Ödeme Detayı" ImageUrl="img/odeme.gif" OnClick="ibOdemeDetayi_Click" Visible='<%#Convert.ToBoolean(Eval("OdemeSayisi"))%>' />
                            </td>
                            <td style="width: 20px; text-align: center; height: 30px; vertical-align: top">
                                <input type="hidden" runat="server" id="mnToplamTutar" value='<%#Eval("mnToplamTutar")%>' />
                                <asp:ImageButton class="kucukbilgiGoster" runat="server" Visible='<%#Convert.ToBoolean(Eval("blAktarilmis"))%>' ToolTip="Durum" ImageUrl="img/durum.gif" OnClick="ibDurum_Click" />
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate></table></FooterTemplate>
                </asp:DataList>
                <br />
                <asp:Label runat="server" ID="lblSiparisYok" Visible="false" Text="- Listenecek sipariş bulunamadı. -" Font-Italic="true" style="padding-left: 200px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <table cellpadding="0" cellspacing="0" style="width: 968px; margin-left: 10px; margin-top: 5px">
                <tr>
                <td align="left"><asp:ImageButton runat="server" ID="ibOnceki" 
                        ImageUrl="img/sol_ok.gif" onclick="ibOnceki_Click" /></td>
                <td align="center">
                <asp:Label runat="server" ID="lblSiparisKacinci">0</asp:Label>
                /
                <asp:Label runat="server" ID="lblSiparisSayisi">0</asp:Label></td>
                <td align="right"><asp:ImageButton runat="server" ID="ibSonraki" 
                        ImageUrl="img/sag_ok.gif" onclick="ibSonraki_Click" /></td>
                </tr>
                </table>
                <div style="padding-left: 583px; font-size: 11px">
                    <%--Sayfa Toplamı: <asp:Label runat="server" ID="lblSayfaToplami" style="padding-right: 20px" Font-Bold="true"></asp:Label>--%>
                    <span style="color: #D00000">Sip.Tutarlar Toplamı:</span> 
                    <asp:Label runat="server" ID="lblDipToplam" Text="0,000 TL"></asp:Label>
                </div>
                <br />
            </td>
        </tr>
    </table>
    </div>
    </ContentTemplate>
    <Triggers>
        <asp:PostBackTrigger ControlID="btnExceldenSiparis" />
    </Triggers>
    </asp:UpdatePanel>
<uc1:ucAlt ID="ucAlt1" runat="server" />
    </form>
</body>
</html>

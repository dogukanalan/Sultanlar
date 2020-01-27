<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="aktiviteler.aspx.cs" Inherits="Sultanlar.WebUI.musteri.aktiviteler" %>

<%@ Register src="ucAlt.ascx" tagname="ucAlt" tagprefix="uc1" %>

<%@ Register src="ucProgress.ascx" tagname="ucProgress" tagprefix="uc2" %>

<%@ Register src="ucMesajlar.ascx" tagname="ucMesajlar" tagprefix="uc3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
	<meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Sultanlar : Aktiviteler</title>
    <script type="text/javascript">
        function invisible() {
            if (document.getElementById('divSiparisKopyala') != null) {
                window.location.href = document.getElementById('lbSiparisKopyalaKapat').href;
                return false;
            }
            if (document.getElementById('divAktiviteKaydedildi') != null) {
                window.location.href = document.getElementById('lbAktiviteKaydedildiKapat').href;
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
            if (document.getElementById('divSiparisOnaylanamadi') != null) {
                window.location.href = document.getElementById('lbSiparisOnaylanamadiKapat').href;
                return false;
            }
            if (document.getElementById('divMesaj') != null) {
                window.location.href = document.getElementById('lbMesajKapat').href;
                return false;
            }
        }
        function Yazdir() {
            yenipen = window.open('yazdiraktivite.aspx', '_blank', 'toolbar=yes,location=no,status=no,menubar=yes,scrollbars=yes,width=1024,height=480,noresize');
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
    <asp:ScriptManager ID="AjaxScripts" runat="server" AsyncPostBackTimeout="600">
    </asp:ScriptManager>
    <script type="text/javascript">
        Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(function (evt, args) {
            $("#tblTopluIslemler").hide("blind", { easing: "easeOutExpo" }, 100, callback);
            function callback() { };

            $('#rbCariHesapAraMusteri').button();
            $('#rbCariHesapAraSattem').button();
            $('#rbSiparislerHepsi').button();
            $('#rbSiparislerOnaylilar').button();
            $('#rbSiparislerOnaysizlar').button();
            $('#rbSiparislerRedler').button();
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
            
            <div style="position: absolute; width: 800px; z-index: 3; left: 100px;
                top: 20px" runat="server" id="divSiparisKopyala" visible="false">
                <div style="position: fixed; width: 100%; height: 100%; z-index: -1; left: 0; top: 0;
                filter: alpha(opacity=40); -moz-opacity: .40; opacity: .40; background-color: #000000" onclick="invisible()"></div>
                <table style="width: 100%; height: 100%; background-color: #ffffff; font-family: Tahoma; margin-bottom: 20px; font-size: 12px;
                    border: 1px solid #D1D1D1; border-radius: 5px; padding: 5px;">
                <tr>
                <td align="center" valign="middle" style="padding-top: 15px; padding-bottom: 15px">
                    <span style="color: #C00000">Aktiviteyi kopyalayacağınız şubeleri ve <span style="font-weight: bold; font-size: 18px; color: Red">fiyat dönemini</span> seçiniz</span>
                    <br /><br />
                    <asp:DropDownList runat="server" ID="ddlDonemYil" Height="25px" ForeColor="#006699"
                        style="padding: 3px 3px 3px 3px;border:1px solid #CCCCCC;background:#ededed;"
                        Width="150px" AutoPostBack="False">
                        <asp:ListItem Text="2014" Value="2014"></asp:ListItem>
                        <asp:ListItem Text="2015" Value="2015"></asp:ListItem>
                        <asp:ListItem Text="2016" Value="2016"></asp:ListItem>
                        <asp:ListItem Text="2017" Value="2017"></asp:ListItem>
                        <asp:ListItem Text="2018" Value="2018"></asp:ListItem>
                        <asp:ListItem Text="2019" Value="2019"></asp:ListItem>
                        <asp:ListItem Text="2020" Value="2020" Selected="True"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:DropDownList runat="server" ID="ddlDonemAy" Height="25px" ForeColor="#006699"
                        style="padding: 3px 3px 3px 3px;border:1px solid #CCCCCC;background:#ededed;"
                        Width="150px" AutoPostBack="False">
                        <asp:ListItem Text="1" Value="1"></asp:ListItem>
                        <asp:ListItem Text="2" Value="2"></asp:ListItem>
                        <asp:ListItem Text="3" Value="3"></asp:ListItem>
                        <asp:ListItem Text="4" Value="4"></asp:ListItem>
                        <asp:ListItem Text="5" Value="5"></asp:ListItem>
                        <asp:ListItem Text="6" Value="6"></asp:ListItem>
                        <asp:ListItem Text="7" Value="7"></asp:ListItem>
                        <asp:ListItem Text="8" Value="8"></asp:ListItem>
                        <asp:ListItem Text="9" Value="9"></asp:ListItem>
                        <asp:ListItem Text="10" Value="10"></asp:ListItem>
                        <asp:ListItem Text="11" Value="11"></asp:ListItem>
                        <asp:ListItem Text="12" Value="12"></asp:ListItem>
                    </asp:DropDownList>
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
                    Bu aktivitenin fiyat tipine yetkili değilsiniz. Aktiviteyi yalnızca inceleyebilir, yazdırabilir veya kaydedebilirsiniz.
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
                    Aktivitede bir ürün bulunmuyor.
                    <br /><br />
                    <asp:LinkButton runat="server" ID="lbToplamTutarSifirKapat" 
                        onclick="lbToplamTutarSifirKapat_Click">Kapat</asp:LinkButton>
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
                <tr><td align="center"><strong>Aktivite Onay Talep</strong><br /><br /></td></tr>
                <tr><td>
                </td></tr>
                <tr><td align="center">
                    <asp:LinkButton runat="server" ID="lbOnaylaBitir" OnClientClick="TusBasildiGizle(this)"
                        onclick="lbOnaylaBitir_Click">Onay Talep Et</asp:LinkButton>
                    <asp:Label ID="Label3" runat="server" Width="50px"></asp:Label>
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
                    Aktiviteyi silmek istediğinize emin misiniz?
                    <br /><br />
                    <asp:LinkButton runat="server" ID="lbSiparisSilEvet" 
                        onclick="lbSiparisSilEvet_Click">Evet</asp:LinkButton>
                        <asp:Label ID="Label4" runat="server" Width="50px"></asp:Label>
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

            <div style="position: absolute; width: 420px; height: 100px; z-index: 4; left: 290px;
                top: 150px" runat="server" id="divSiparisAktarilmisHata" visible="false">
                <div style="position: fixed; width: 100%; height: 100%; z-index: -1; left: 0; top: 0;
                filter: alpha(opacity=40); -moz-opacity: .40; opacity: .40; background-color: #000000" onclick="invisible()"></div>
                <table style="width: 100%; height: 100%; background-color: #ffffff; font-family: Tahoma; font-size: 12px;
                    border: 1px solid #D1D1D1; border-radius: 5px; padding: 5px;">
                <tr>
                <td align="center" valign="middle" style="padding-top: 15px; padding-bottom: 15px">
                    Bu aktivite zaten onaylanmış.
                    <br /><br />
                    <asp:LinkButton runat="server" ID="lbSiparisAktarilmisHata" 
                        onclick="lbSiparisAktarilmisHata_Click">Kapat</asp:LinkButton>
                </td>
                </tr>
                </table>
            </div>

            <div style="position: absolute; width: 300px; height: 100px; z-index: 3; left: 350px;
                top: 150px" runat="server" id="divAktiviteKaydedildi" visible="false">
                <div style="position: fixed; width: 100%; height: 100%; z-index: -1; left: 0; top: 0;
                filter: alpha(opacity=40); -moz-opacity: .40; opacity: .40; background-color: #000000" onclick="invisible()"></div>
                <table style="width: 420px; height: 100px; background-color: #ffffff; font-family: Tahoma; font-size: 12px;
                    border: 1px solid #D1D1D1; border-radius: 5px; padding: 5px;">
                <tr>
                <td align="center" valign="middle" style="padding-top: 15px; padding-bottom: 15px">
                    Aktivite talebi merkeze iletilmiştir.
                    <br /><br />
                    <asp:LinkButton runat="server" ID="lbAktiviteKaydedildiKapat" 
                        onclick="lbAktiviteKaydedildiKapat_Click">Kapat</asp:LinkButton>
                </td>
                </tr>
                </table>
            </div>

            <div style="position: absolute; z-index: 4; left: 804px; top: 252px" id="divTopluIslemler">
                <table style="width: 100%; height: 100%; background-color: #ffffff; font-family: Tahoma; font-size: 10px;
                    border: 1px solid #D1D1D1; border-radius: 5px; padding: 5px;" id="tblTopluIslemler">
                <tr>
                <td align="center" valign="middle">
                    <asp:Button runat="server" ID="btnTumunuOnayla" Text="Onayla" OnClientClick="TusBasildiGizle(this)" OnClick="btnTumunuOnayla_Click" Enabled="true" Width="170px" />
                </td>
                </tr>
                <tr>
                <td align="center" valign="middle">
                    <asp:Button runat="server" ID="btnTumunuSil" Text="Sil" OnClientClick="TusBasildiGizle(this)" OnClick="btnTumunuSil_Click" Enabled="true" Width="170px" />
                </td>
                </tr>
                </table>
            </div>



            <div style="position: absolute; width: 980px; height: 416px; z-index: 4; left: 10px; background-color: #ffffff;
                top: 10px;" runat="server" id="divSiparis" visible="false">
                <div style="position: fixed; width: 100%; height: 100%; z-index: -1; left: 0; top: 0;
                filter: alpha(opacity=40); -moz-opacity: .40; opacity: .40; background-color: #000000" onclick="invisible()"></div>
                <div style="width: 100%; height: 100%; background-color: #ffffff;border: 1px solid #D1D1D1; border-radius: 5px; padding: 5px;">
                <table cellpadding="10" cellspacing="0" style="font-family: Tahoma; font-size:14px; width: 980px; height: 40px">
                <tr>
                <td valign="middle">
                <asp:Label runat="server" ID="lblSiparisDetaylari" Font-Bold="true" Visible="true">Aktivite Detayları</asp:Label><asp:Label runat="server" ID="lblSiparisSonDurum" Font-Bold="true" Visible="false">Siparişinizin Son Durumu</asp:Label>
                <asp:Label ID="Label7" runat="server" Width="180px"></asp:Label>
                <asp:LinkButton runat="server" ID="lbOnaylamayaDevam" Font-Underline="true" Font-Size="16px" Font-Bold="true" Text="Devam Et" OnClick="lbOnaylamayaDevam_Click" Visible="false"></asp:LinkButton></td>
                <td valign="middle" align="right"><asp:LinkButton runat="server" ID="lbSiparisKapat" OnClick="lbSiparisKapat_Click" Font-Underline="False" Font-Bold="true" Text="X" /></td>
                </tr>
                </table>
                <table width="960px" cellpadding="3" cellspacing="0" style="font-family: Tahoma; font-size: 11px">
                            <tr style="color: #C00000">
                                <td align="center" style="width: 40px; font-size:12px;">
                                    Ürt.Kod
                                </td>
                                <td align="center" style="width: 160px; font-size:12px">
                                    Ürün
                                </td>
                                <td align="center" style="width: 50px; font-size:12px">
                                    Koli İçi
                                </td>
                                <td align="center" style="width: 50px; font-size:12px">
                                    F.Alt.<br />İsk.
                                </td>
                                <td align="center" style="width: 50px; font-size:12px">
                                    F.Alt.<br />Ciro
                                </td>
                                <td align="center" style="width: 50px; font-size:12px">
                                    Paz.<br />İsk.
                                </td>
                                <td align="center" style="width: 50px; font-size:12px">
                                    C.P.<br />D.Y.
                                </td>
                                <td align="center" style="width: 60px; font-size:12px">
                                    Birim Fiyat
                                </td>
                                <td align="center" style="width: 80px; font-size:12px">
                                    Ön.Aks.<br />Fiyatı
                                </td>
                                <td align="center" style="width: 60px; font-size:12px">
                                    Satış Hedefi Koli
                                </td>
                                <td align="center" style="width: 60px; font-size:12px">
                                    Ek İsk.
                                </td>
                                <td align="center" style="width: 60px; font-size:12px">
                                    C.P.D.<br />KDV D.B.F.
                                </td>
                                <td align="center" style="width: 70px; font-size:12px">
                                    Fat.Bas.B.<br />F.Kdv'siz
                                </td>
                                <td align="center" style="width: 70px; font-size:12px">
                                    Fat.Bas.B.<br />F.Kdv'li
                                </td>
                            </tr>
                        </table>
                <div style="overflow: auto; width:980px; height: 280px">
                <asp:Repeater ID="Repeater1" runat="server">
                    <HeaderTemplate>
                        <table width="960px" cellpadding="3" cellspacing="0" style="font-family: Tahoma; font-size: 11px;">
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr <%# "style='" + (Eval("Aciklama4").ToString() == "1" ? "background-color: #99D4FF" : "background-color: #E8E8E8" ) + ";'" %>>
                            <td align="center" style="width: 40px;">
                                <%#Eval("UrtKod")%>
                            </td>
                            <td align="left" style="width: 160px">
                                <%#Eval("UrunAdi")%>
                            </td>
                            <td align="left" style="width: 50px">
                                <%#Eval("KoliAdet")%>
                            </td>
                            <td align="center" style="width: 50px;">
                                <%#Convert.ToDecimal(Eval("FatAltIsk")).ToString("N1")%>
                            </td>
                            <td align="center" style="width: 50px;">
                                <%#Convert.ToDecimal(Eval("FatAltCiro")).ToString("N1")%>
                            </td>
                            <td align="center" style="width: 50px;">
                                <%#Convert.ToDouble(Eval("PazIsk")).ToString("N1")%>
                            </td>
                            <td align="center" style="width: 50px;">
                                <%#Convert.ToDouble(Eval("CiroPrimDonusYuzde")).ToString("N1")%>
                            </td>
                            <td align="right" style="width: 60px;">
                                <%#Convert.ToDecimal(Eval("BirimFiyatKDVli")).ToString("N3")%> TL
                            </td>
                            <td align="right" style="width: 80px;">
                                <%#Convert.ToDecimal(Eval("AksiyonFiyati")).ToString("N3")%> TL
                            </td>
                            <td align="center" style="width: 60px;">
                                <%#Eval("SatisHedefi")%>
                            </td>
                            <td align="center" style="width: 60px;">
                                <%#Convert.ToDouble(Eval("EkIsk")).ToString("N1")%>
                            </td>
                            <td align="right" style="width: 60px;">
                                <%#Convert.ToDecimal(Eval("CiroPrimiDusulmusKDVDahil")).ToString("C3")%>
                            </td>
                            <td align="right" style="width: 70px;">
                                <%#(Convert.ToDecimal(Eval("DusulmusBirimFiyatKDVli")) / ((100 + Convert.ToDecimal(Sultanlar.DatabaseObject.Internet.Urunler.GetProductKDV(Convert.ToInt32(Eval("UrunID"))))) / 100)).ToString("C3")%>
                            </td>
                            <td align="right" style="width: 70px;">
                                <span class="kucukbilgiGoster" title='Toplam: <%#(Convert.ToInt32(Eval("SatisHedefi")) * Convert.ToDecimal(Sultanlar.DatabaseObject.Internet.Urunler.GetKoliAdedi(Convert.ToInt32(Eval("UrunID")))) * Convert.ToDecimal(Eval("DusulmusBirimFiyatKDVli"))).ToString("C3")%>'>
                                <%#Convert.ToDecimal(Eval("DusulmusBirimFiyatKDVli")).ToString("C3")%></span>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                        <tr <%# "style='" + (Eval("Aciklama4").ToString() == "1" ? "background-color: #99D4FF" : "background-color: #FFE2C6" ) + ";'" %>>
                            <td align="center" style="width: 40px">
                                <%#Eval("UrtKod")%>
                            </td>
                            <td align="left" style="width: 160px">
                                <%#Eval("UrunAdi")%>
                            </td>
                            <td align="left" style="width: 50px">
                                <%#Eval("KoliAdet")%>
                            </td>
                            <td align="center" style="width: 50px;">
                                <%#Convert.ToDecimal(Eval("FatAltIsk")).ToString("N1")%>
                            </td>
                            <td align="center" style="width: 50px;">
                                <%#Convert.ToDecimal(Eval("FatAltCiro")).ToString("N1")%>
                            </td>
                            <td align="center" style="width: 50px;">
                                <%#Convert.ToDouble(Eval("PazIsk")).ToString("N1")%>
                            </td>
                            <td align="center" style="width: 50px;">
                                <%#Convert.ToDouble(Eval("CiroPrimDonusYuzde")).ToString("N1")%>
                            </td>
                            <td align="right" style="width: 60px;">
                                <%#Convert.ToDecimal(Eval("BirimFiyatKDVli")).ToString("N3")%> TL
                            </td>
                            <td align="right" style="width: 80px;">
                                <%#Convert.ToDecimal(Eval("AksiyonFiyati")).ToString("N3")%> TL
                            </td>
                            <td align="center" style="width: 60px;">
                                <%#Eval("SatisHedefi")%>
                            </td>
                            <td align="center" style="width: 60px;">
                                <%#Convert.ToDouble(Eval("EkIsk")).ToString("N1")%>
                            </td>
                            <td align="right" style="width: 60px;">
                                <%#Convert.ToDecimal(Eval("CiroPrimiDusulmusKDVDahil")).ToString("C3")%>
                            </td>
                            <td align="right" style="width: 70px;">
                                <%#(Convert.ToDecimal(Eval("DusulmusBirimFiyatKDVli")) / ((100 + Convert.ToDecimal(Sultanlar.DatabaseObject.Internet.Urunler.GetProductKDV(Convert.ToInt32(Eval("UrunID"))))) / 100)).ToString("C3")%>
                            </td>
                            <td align="right" style="width: 70px;">
                                <span class="kucukbilgiGoster" title='Toplam: <%#(Convert.ToInt32(Eval("SatisHedefi")) * Convert.ToDecimal(Sultanlar.DatabaseObject.Internet.Urunler.GetKoliAdedi(Convert.ToInt32(Eval("UrunID")))) * Convert.ToDecimal(Eval("DusulmusBirimFiyatKDVli"))).ToString("C3")%>'>
                                <%#Convert.ToDecimal(Eval("DusulmusBirimFiyatKDVli")).ToString("C3")%></span>
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
                <asp:Label ID="Label8" runat="server" Width="100px" />
                <asp:Label runat="server" ID="lblOrtalamaVade" />
                </td>
                <td align="right">Akt.Toplamı: </td>
                </tr>
                </table>
                </td>
                <td valign="middle" align="right" style="width: 120px"><asp:Label runat="server" ID="lblSiparisToplam" Font-Bold="true" /></td>
                </tr>
                </table>
                </div>
            </div>



    <div style="width: 100%; font-size: 9px; font-family: Verdana; background-color: #EFEEEA; border-bottom: 1px solid #FFCFB2"">
    <table cellpadding="5" cellspacing="0">
    <tr>
    <td style="width: 800px;" valign="middle">
        <table cellpadding="0" cellspacing="0"><tr><td>
        <input type="button" value="Giriş" onclick="javascript:window.location.href='default.aspx'" /> 
        <input type="button" value="Aktiviteler" disabled="disabled" /> 
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
            <table cellpadding="0" cellspacing="0"><tr>
            <td><img src="img/ic_siparisler.png" /></td>
            <td>Aktiviteler</td>
            <td align="right" style="width: 100%">
            </td>
            </tr></table>
            </div>
            <div style="padding: 10px 10px 0px 25px; font-size: 12px" runat="server" id="divHesapSecim">
            <div runat="server" id="divCariHesapArama" visible="false" style="padding: 5px 5px 5px 0px;">
                <asp:RadioButton runat="server" ID="rbCariHesapAraMusteri" GroupName="grCariHesapAra" Text="Müşteri" />&nbsp;
                <asp:RadioButton runat="server" ID="rbCariHesapAraSattem" Checked="true" GroupName="grCariHesapAra" Text="Satış Temsilcisi" />&nbsp;
                <asp:TextBox runat="server" ID="txtCariHesapAra" Width="150px" onkeypress="return clickButton(event,'btnCariHesapAra')"
                    ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" BorderWidth="1px" Height="23px" style="padding: 0px 3px 0px 3px"></asp:TextBox>&nbsp;
                <asp:Button runat="server" ID="btnCariHesapAra" Width="100px" Text="Ara" OnClick="btnCariHesapAra_Click" 
                    BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" ForeColor="#6D8AAA" BackColor="#ededed" />&nbsp;
                <%--<asp:Button runat="server" ID="btnCariHesapTemizle" Width="100px" Text="Tümünü Getir" OnClick="btnCariHesapTemizle_Click"
                    BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" ForeColor="#6D8AAA" />&nbsp;--%>
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
                <asp:Label ID="Label10" runat="server" Width="3px"></asp:Label>
                <asp:DropDownList ID="ddlCariHesaplar" runat="server" Width="500px" AutoPostBack="true" 
                                                    Font-Bold="False" Font-Italic="False" Height="25px"
                    Font-Overline="False" Font-Size="11px" 
                                                    Font-Strikeout="False" 
                    Font-Underline="False" style="filter: alpha(opacity=80); -moz-opacity: .80; opacity: .80; padding: 3px 3px 3px 3px;border:1px solid #CCCCCC;background:#ededed;"
                    onselectedindexchanged="ddlCariHesaplar_SelectedIndexChanged" 
                    ForeColor="#006699">
                </asp:DropDownList>
                </td>
                <td valign="middle"><asp:Label ID="Label11" runat="server" Width="3px"></asp:Label>
                <asp:ImageButton Visible="false" ImageUrl="img/ic_tarih.png" runat="server" ID="ibTarih" OnClick="ibTarih_Click" ToolTip="Tarihe Göre" class="kucukbilgiGoster" />
                <button type="button" id="btTarih" name="btTarih" onclick="btTarihClick()">Tarih Aralığı</button><asp:LinkButton Text="" runat="server" ID="lbTarih" OnClick="lbTarih_Click" />
                </td>
                </tr>
                </table>
                <asp:Label ID="Label12" runat="server" Width="207px"></asp:Label>
                <asp:DropDownList ID="ddlCariHesaplarSubeler" runat="server" 
                    AutoPostBack="true" Font-Bold="False" Font-Italic="False" Font-Overline="False" Height="25px"
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
                    <asp:RadioButton runat="server" ID="rbSiparislerRedler" Text="Onay Talep Edilmişler" AutoPostBack="true"
                        GroupName="grOnaySuzme" OnCheckedChanged="rbSiparislerHepsi_Checked" />
                    <asp:RadioButton runat="server" ID="rbSiparislerOnaysizlar" Text="Onaylanmamış" AutoPostBack="true" Checked="true"
                        GroupName="grOnaySuzme" OnCheckedChanged="rbSiparislerHepsi_Checked" />
                </div>
                <div style="width: 970px; text-align: right" runat="server" id="divTopluIslemlerTus">
                    <input type="hidden" value="kapali" runat="server" id="inputTopluIslemGosterGizle" />
                    <input type="button" value="Toplu İşlemler" style="width: 150px" onclick="topluislemgostergizle()" />
                </div>
                <table cellpadding="1" cellspacing="0" style="margin-left: 10px; margin-bottom: 5px">
                        <tr style="color: #D00000">
                            <td style="width: 30px; text-align: center; height: 20px; border-bottom: 1px solid #CCCCCC"><asp:CheckBox runat="server" ID="cbSiparislerSecimTumu" AutoPostBack="true" OnCheckedChanged="cbSiparislerSecimTumu_CheckedChanged" ToolTip="Tümünü Seç / Seçimi Temizle" class="kucukbilgiGoster" /></td>
                            <td style="width: 50px; text-align: center; height: 20px; border-bottom: 1px solid #CCCCCC">A.No</td>
                            <td style="width: 100px; text-align: left; height: 20px; border-bottom: 1px solid #CCCCCC">Akt.Sahibi</td>
                            <td style="width: 200px; text-align: left; height: 20px; border-bottom: 1px solid #CCCCCC">Bayi</td>
                            <td style="width: 190px; text-align: left; height: 20px; border-bottom: 1px solid #CCCCCC">Alt Cari</td>
                            <td style="width: 70px; text-align: center; height: 20px; border-bottom: 1px solid #CCCCCC">Akt.Gir.Tar.</td>
                            <td style="width: 70px; text-align: center; height: 20px; border-bottom: 1px solid #CCCCCC">Akt.Bas.Tar.</td>
                            <td style="width: 70px; text-align: center; height: 20px; border-bottom: 1px solid #CCCCCC">Akt.Bit.Tar.</td>
                            <td style="width: 180px; text-align: center;"></td>
                        </tr></table>
                <asp:DataList ID="dlSiparisler" runat="server" OnItemDataBound="dlSiparisler_DataBound">
                    <HeaderTemplate><table cellpadding="1" cellspacing="0" style="margin-left: 10px">
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr onmouseover="Satir(this,true)" onmouseout="Satir(this,false)">
                            <td style="width: 30px; text-align: center; height: 30px; vertical-align: top">
                                <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="false" ToolTip='<%#Eval("pkAktiviteID")%>' />
                            </td>
                            <td style="width: 50px; text-align: center; height: 30px; vertical-align: top"><%#Eval("pkAktiviteID")%></td>
                            <td style="width: 110px; text-align: left; height: 30px; vertical-align: top"><input type="hidden" value='<%#Eval("intMusteriID") %>' id="MusteriID" runat="server" /><%#Eval("strAd")%> <%#Eval("strSoyad")%></td>
                            <td style="width: 230px; text-align: left; height: 30px; vertical-align: top; font-size: 8px"><%#Eval("BAYI")%></td>
                            <td style="width: 230px; text-align: left; height: 30px; vertical-align: top; font-size: 8px"><%#Eval("MUSTERI")%></td>
                            <td style="width: 70px; text-align: center; height: 30px; vertical-align: top"><span class="kucukbilgiGoster" title="Onaylama Tarihi: <%#Eval("blAktarilmis") == DBNull.Value || Convert.ToBoolean(Eval("blAktarilmis")) ? Convert.ToDateTime(Eval("dtOnaylamaTarihi")).ToString() : "<i>Aktivite henüz onaylanmamış.</i>"%>"><%#Convert.ToDateTime(Eval("dtOlusmaTarihi")).ToShortDateString()%><br /><%#Convert.ToDateTime(Eval("dtOlusmaTarihi")).ToShortTimeString()%></span></td>
                            <td style="width: 70px; text-align: center; height: 30px; vertical-align: top"><%#Convert.ToDateTime(Eval("dtAktiviteBaslangic")).ToShortDateString()%></span></td>
                            <td style="width: 70px; text-align: center; height: 30px; vertical-align: top"><%#Convert.ToDateTime(Eval("dtAktiviteBitis")).ToShortDateString()%></span></td>
                            <td style="width: 20px; text-align: center; height: 30px; vertical-align: top">
                                <asp:ImageButton ID="ImageButton1" class="kucukbilgiGoster" runat="server" ToolTip="İncele" ImageUrl="img/incele.gif" OnClick="ibIncele_Click" />
                            </td>
                            <td style="width: 20px; text-align: center; height: 30px; vertical-align: top">
                                <asp:ImageButton ID="ImageButton2" class="kucukbilgiGoster" runat="server" ToolTip="Kopyala" ImageUrl="img/kopyala.gif" OnClick="ibKopyala_Click" />
                            </td>
                            <td style="width: 20px; text-align: center; height: 30px; vertical-align: top">
                                <input type="hidden" value='<%#Eval("pkAktiviteID") %>' id="AktiviteID" runat="server" />
                                <input type="hidden" value='<%#Eval("SMREF") %>' id="SMREF" runat="server" />
                                <asp:ImageButton ID="ImageButton3" class="kucukbilgiGoster" runat="server" Visible='<%#Eval("blAktarilmis") != DBNull.Value && !Convert.ToBoolean(Eval("blAktarilmis"))%>' ToolTip="Değiştir" ImageUrl="img/degistir.gif" OnClick="ibDegistir_Click" />
                            </td>
                            <td style="width: 20px; text-align: center; height: 30px; vertical-align: top">
                                <asp:ImageButton ID="ImageButton4" class="kucukbilgiGoster" runat="server" Visible='<%#Eval("blAktarilmis") != DBNull.Value && !Convert.ToBoolean(Eval("blAktarilmis"))%>' ToolTip="Onay Talep Et" ImageUrl="img/onayla.gif" OnClick="ibOnayla_Click" OnClientClick="" />
                            </td>
                            <td style="width: 20px; text-align: center; height: 30px; vertical-align: top">
                                <asp:ImageButton ID="ImageButton5" class="kucukbilgiGoster" runat="server" Visible='<%#Eval("blAktarilmis") != DBNull.Value && !Convert.ToBoolean(Eval("blAktarilmis"))%>' ToolTip="Sil" ImageUrl="img/sil.gif" OnClick="ibSil_Click" />
                            </td>
                            <td style="width: 20px; text-align: center; height: 30px; vertical-align: top">
                                <asp:ImageButton ID="ImageButton6" class="kucukbilgiGoster" runat="server" ToolTip="Yazdır" ImageUrl="img/yazdir.gif" OnClientClick="Yazdir()" OnClick="ibYazdir_Click" />
                            </td>
                            <td style="width: 20px; text-align: center; height: 30px; vertical-align: top">
                                <asp:ImageButton ID="ImageButton7" class="kucukbilgiGoster" runat="server" Visible='<%#Eval("blAktarilmis") == DBNull.Value || (Eval("blAktarilmis") != DBNull.Value && Convert.ToBoolean(Eval("blAktarilmis")))%>' ToolTip="Kaydet" ImageUrl="img/kaydet.gif" OnClick="ibKaydet_Click" />
                            </td>
                            <td style="width: 20px; text-align: center; height: 30px; vertical-align: top">
                                
                            </td>
                            <td style="width: 20px; text-align: center; height: 30px; vertical-align: top">
                                <asp:ImageButton ID="ImageButton9" class="kucukbilgiGoster" runat="server" ToolTip="Durum" ImageUrl="img/durum.gif" OnClick="ibDurum_Click" />
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate></table></FooterTemplate>
                </asp:DataList>
                <br />
                <asp:Label runat="server" ID="lblSiparisYok" Visible="true" Text="- Listenecek aktivite bulunamadı. -" Font-Italic="true" style="padding-left: 200px"></asp:Label>
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
                <br />
            </td>
        </tr>
    </table>
    </div>
    </ContentTemplate></asp:UpdatePanel>
<uc1:ucAlt ID="ucAlt1" runat="server" />
    </form>
</body>
</html>

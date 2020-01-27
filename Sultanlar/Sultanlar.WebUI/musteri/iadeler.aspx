<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="iadeler.aspx.cs" Inherits="Sultanlar.WebUI.musteri.iadeler" %>

<%@ Register src="ucAlt.ascx" tagname="ucAlt" tagprefix="uc1" %>

<%@ Register src="ucProgress.ascx" tagname="ucProgress" tagprefix="uc2" %>

<%@ Register src="ucMesajlar.ascx" tagname="ucMesajlar" tagprefix="uc3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Sultanlar : İadeler</title>
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
            if (document.getElementById('divTarih') != null) {
                window.location.href = document.getElementById('lbTarihKapat').href;
                return false;
            }
            if (document.getElementById('divFiyatTipiYetkisiYok') != null) {
                window.location.href = document.getElementById('lbFiyatTipiYetkisiYokKapat').href;
                return false;
            }
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
            if (document.getElementById('divSiparisOnaylanamadi') != null) {
                window.location.href = document.getElementById('lbSiparisOnaylanamadiKapat').href;
                return false;
            }
            if (document.getElementById('divMesaj') != null) {
                window.location.href = document.getElementById('lbMesajKapat').href;
                return false;
            }
            if (document.getElementById('divFaturaTakip') != null) {
                window.location.href = document.getElementById('lbFaturaTakipKapat').href;
                return false;
            }
        }
        function Yazdir() {
            yenipen = window.open('yazdir.aspx', '_blank', 'toolbar=yes,location=no,status=no,menubar=yes,scrollbars=yes,width=1024,height=480,noresize');
            yenipen.moveTo(0, 0);
        }
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
                $("#tblTopluIslemler").hide("blind", { easing: "easeOutExpo" }, 1500, callback);
                function callback() { };
            }
            else {
                document.getElementById("inputTopluIslemGosterGizle").value = "acik";
                $("#tblTopluIslemler").show("blind", { easing: "easeOutExpo" }, 1500, callback);
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

      <script type='text/javascript' src="js/jquery.qtip.js"></script>
      <link rel="stylesheet" type="text/css" href="js/jquery.qtip.css"/>

</head>
<body style="margin: 0 0 0 0;background-color: #EFEEEA;">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="AjaxScripts" runat="server">
    </asp:ScriptManager>
    <script type="text/javascript">
        Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(function (evt, args) {
            $("#tblTopluIslemler").hide("blind", { easing: "easeOutExpo" }, 100, callback);
            function callback() { };

            $('#rbCariHesapAraMusteri').button();
            $('#rbCariHesapAraSattem').button();
            $('#rbSiparislerHepsi').button();
            $('#rbKaydedilmisler').button();
            $('#rbOnayTalepEdilmisler').button();
            $('#rbOnayTaleptenGelenler').button();
            $('#rbOnaylanmislar').button();
            $('#rbReddedilmis').button();
            $('#rbDegisimler').button();
            $('#rblIadeNedenleri').buttonset().find('label').width(200);
            $("input[type=submit], input[type=button]").button();
            $('#cbTariheGore').button();
            $('#btTarih').button({ icons: { primary: 'ui-icon-tarih', secondary: null} });

            $("a[id$='lbTarihKapat']").button();
            $("a[id$='lbSiparisKopyalaTamamla']").button();
            $("a[id$='lbSiparisKopyalaKapat']").button();
            $("a[id$='lbSiparisOnaylanamadiKapat']").button();
            $("a[id$='lbOnaylaBitir']").button();
            $("a[id$='lbOnaylaKapat']").button();
            $("a[id$='lbSiparisSilEvet']").button();
            $("a[id$='lbSiparisSilHayir']").button();
            $("a[id$='lbSiparisKaydetKapat']").button();
            $("a[id$='lbSiparisEpostaKapat']").button();
            $("a[id$='lbFiyatlandirilmisOnaylaBitir']").button();
            $("a[id$='lbFiyatlandirilmisOnaylaKapat']").button();

            $('strong').each(function () {
                if ($(this).attr('class') == 'classurtkod') {
                    $(this).qtip({
                        content: {
                            text: function (event, api) {
                                $.ajax({
                                    url: api.elements.target.attr('title') // Use href attribute as URL
                                })
                            .then(function (content) {
                                // Set the tooltip content upon successful retrieval
                                api.set('content.text', content);
                            }, function (xhr, status, error) {
                                // Upon failure... set the tooltip content to error
                                api.set('content.text', status + ': ' + error);
                            });

                                return 'Yükleniyor...'; // Set some initial text
                            }
                        },
                        position: {
                            viewport: $(window)
                        },
                        style: 'qtip'
                    });
                }
            });
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

            <div style="position: absolute; width: 800px; height: 400px; z-index: 3; left: 100px;
                top: 20px" runat="server" id="divSiparisKopyala" visible="false">
                <div style="position: fixed; width: 100%; height: 100%; z-index: -1; left: 0; top: 0;
                filter: alpha(opacity=40); -moz-opacity: .40; opacity: .40; background-color: #000000" onclick="invisible()"></div>
                <table style="width: 100%; height: 100%; background-color: #ffffff; font-family: Tahoma; font-size: 12px;
                    border: 1px solid #D1D1D1; border-radius: 5px; padding: 5px; margin-bottom: 20px;">
                <tr>
                <td align="center" valign="middle" style="padding-top: 15px; padding-bottom: 15px">
                    <span style="color: #C00000">İadenin kopyalayacağınız şubeleri seçiniz</span>
                    <br /><br />

                    <table cellpadding="0" cellspacing="0" style="width: 100%"><tr><td align="left">
                    <div style="padding-left: 10px; overflow: auto; height: 350px">
                    <asp:CheckBoxList runat="server" ID="cblSiparisKopyalaSubeler" style="font-size: 9px"></asp:CheckBoxList>
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

            <div style="position: absolute; width: 420px; height: 100px; z-index: 3; left: 290px;
                top: 150px" runat="server" id="divSiparisKaydet" visible="false">
                <div style="position: fixed; width: 100%; height: 100%; z-index: -1; left: 0; top: 0;
                filter: alpha(opacity=40); -moz-opacity: .40; opacity: .40; background-color: #000000" onclick="invisible()"></div>
                <table style="width: 100%; height: 100%; background-color: #ffffff; font-family: Tahoma; font-size: 12px;
                    border: 1px solid #D1D1D1; border-radius: 5px; padding: 5px; margin-bottom: 20px;">
                <tr>
                <td align="center" valign="middle" style="padding-top: 15px; padding-bottom: 15px">
                    <iframe frameborder="0" src="indir.aspx" width="100%" height="120px"></iframe>
                    <asp:LinkButton runat="server" ID="lbSiparisKaydetKapat" 
                        onclick="lbSiparisKaydetKapat_Click">Kapat</asp:LinkButton>
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
                <tr><td align="center"><strong>İadeyi Onayla</strong><br /><br /></td></tr>
                <%--<tr><td align="center">
                <asp:RadioButtonList runat="server" ID="rblIadeNedenleri">
                <asp:ListItem Text="HASARLI" Selected="True"></asp:ListItem>
                <asp:ListItem Text="HAZIRLAMA HATASI"></asp:ListItem>
                <asp:ListItem Text="ONAYLANMAMIŞ SİPARİŞ"></asp:ListItem>
                <asp:ListItem Text="ÖDEME PROBLEMİ"></asp:ListItem>
                <asp:ListItem Text="SEVKİYAT GECİKMESİ"></asp:ListItem>
                <asp:ListItem Text="SON KULLANIM TARİHİ"></asp:ListItem>
                <asp:ListItem Text="TESLİMAT HATASI"></asp:ListItem>
                <asp:ListItem Text="ÜRÜN DEĞİŞİM"></asp:ListItem>
                <asp:ListItem Text="BARKOD OKUMUYOR"></asp:ListItem>
                <asp:ListItem Text="RAFTAN SATIŞI YOK"></asp:ListItem>
                <asp:ListItem Text="GİDEN FATURADAN İADE"></asp:ListItem>
                <asp:ListItem Text="HATALI SİPARİŞ"></asp:ListItem>
                </asp:RadioButtonList>
                </td></tr>--%>
                <tr><td align="center">
                    <br /><br />
                    <asp:RadioButton runat="server" ID="rbOnaylaSevke" Text="Ürünler aldırılacak" GroupName="grOnaylaSevk" Checked="true" />
                    <asp:Label runat="server" Width="50px"></asp:Label>
                    <asp:RadioButton runat="server" ID="rbOnaylaKabule" Text="Ürünler merkezde" GroupName="grOnaylaSevk" Enabled="false" />
                </td></tr>
                <tr><td align="center">
                    <br /><br />
                    <asp:LinkButton runat="server" ID="lbOnaylaBitir" 
                        onclick="lbOnaylaBitir_Click">Onayla</asp:LinkButton>
                    <asp:Label ID="Label4" runat="server" Width="50px"></asp:Label>
                    <asp:LinkButton runat="server" ID="lbOnaylaKapat"
                        onclick="lbOnaylaKapat_Click">Vazgeç</asp:LinkButton>
                </td></tr>
                </table>
            </div>

            <div style="position: absolute; width: 420px; height: 100px; z-index: 3; left: 290px;
                top: 150px" runat="server" id="divSiparisSil" visible="false">
                <div style="position: fixed; width: 100%; height: 100%; z-index: -1; left: 0; top: 0;
                filter: alpha(opacity=40); -moz-opacity: .40; opacity: .40; background-color: #000000" onclick="invisible()"></div>
                <table style="width: 100%; height: 100%; background-color: #ffffff; font-family: Tahoma; font-size: 12px;
                    border: 1px solid #D1D1D1; border-radius: 5px; padding: 5px;">
                <tr>
                <td align="center" valign="middle" style="padding-top: 15px; padding-bottom: 15px">
                    İadeyi silmek istediğinize emin misiniz?
                    <br /><br />
                    <asp:LinkButton runat="server" ID="lbSiparisSilEvet" 
                        onclick="lbSiparisSilEvet_Click">Evet</asp:LinkButton>
                        <asp:Label ID="Label5" runat="server" Width="50px"></asp:Label>
                    <asp:LinkButton runat="server" ID="lbSiparisSilHayir" 
                        onclick="lbSiparisSilHayir_Click">Hayır</asp:LinkButton>
                </td>
                </tr>
                </table>
            </div>

            <div style="position: absolute; width: 420px; height: 100px; z-index: 3; left: 290px;
                top: 150px" runat="server" id="divFiyatlandirilmisOnayla" visible="false">
                <div style="position: fixed; width: 100%; height: 100%; z-index: -1; left: 0; top: 0;
                filter: alpha(opacity=40); -moz-opacity: .40; opacity: .40; background-color: #000000" onclick="invisible()"></div>
                <table style="width: 100%; height: 100%; background-color: #ffffff; font-family: Tahoma; font-size: 12px;
                    border: 1px solid #D1D1D1; border-radius: 5px; padding: 5px;">
                <tr>
                <td align="center" valign="middle" style="padding-top: 15px; padding-bottom: 15px">
                    Fiyatlandırılmış iadeyi onaylamak istediğinize emin misiniz?
                    <br /><br />
                    <asp:LinkButton runat="server" ID="lbFiyatlandirilmisOnaylaBitir" 
                        onclick="lbFiyatlandirilmisOnaylaBitir_Click">Evet</asp:LinkButton>
                        <asp:Label ID="Label6" runat="server" Width="50px"></asp:Label>
                    <asp:LinkButton runat="server" ID="lbFiyatlandirilmisOnaylaKapat" 
                        onclick="lbFiyatlandirilmisOnaylaKapat_Click">Hayır</asp:LinkButton>
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
                    Sistemdeki yoğunluktan dolayı iade (toplu onaylama ise iadelerden en az birisi) onaylanamadı, lütfen daha sonra tekrar deneyiniz.
                    <br /><br />
                    <asp:LinkButton runat="server" ID="lbSiparisOnaylanamadiKapat" 
                        onclick="lbSiparisOnaylanamadiKapat_Click">Kapat</asp:LinkButton>
                </td>
                </tr>
                </table>
            </div>

            <div style="position: absolute; z-index: 4; left: 760px; top: 282px" id="divTopluIslemler">
                <table style="width: 100%; height: 100%; background-color: #ffffff; font-family: Tahoma; font-size: 10px;
                    border: 1px solid #D1D1D1; border-radius: 5px; padding: 5px;" id="tblTopluIslemler">
                <tr>
                <td align="center" valign="middle">
                    <asp:Button runat="server" ID="btnTumunuOnayla" Text="Onayla" OnClientClick="TusBasildiGizle(this)" OnClick="btnTumunuOnayla_Click" Enabled="false" Width="170px" />
                </td>
                </tr>
                <tr>
                <td align="center" valign="middle">
                    <asp:Button runat="server" ID="btnTumunuFiyatlandirilmisOnayla" Text="Fiyatlandırmayı Onayla" OnClientClick="TusBasildiGizle(this)" OnClick="btnTumunuFiyatlandirilmisOnayla_Click" Enabled="true" Visible="false" Width="170px" />
                </td>
                </tr>
                <tr>
                <td align="center" valign="middle">
                    <asp:Button runat="server" ID="btnTumunuSil" Text="Sil" OnClientClick="TusBasildiGizle(this)" OnClick="btnTumunuSil_Click" Enabled="false" Width="170px" />
                </td>
                </tr>
                </table>
            </div>
            
            <div style="position: absolute; width: 800px; height: 400px; z-index: 4; left: 100px; background-color: #ffffff;
                top: 70px;" runat="server" id="divSiparis" visible="false">
                <div style="position: fixed; width: 100%; height: 100%; z-index: -1; left: 0; top: 0;
                filter: alpha(opacity=40); -moz-opacity: .40; opacity: .40; background-color: #000000" onclick="invisible()"></div>
                <div style="width: 100%; height: 100%; background-color: #ffffff; border: 1px solid #D1D1D1; border-radius: 5px; padding: 5px;">
                <table cellpadding="10" cellspacing="0" style="font-family: Tahoma; font-size:14px; width: 800px; height: 40px">
                <tr>
                <td valign="middle">
                <asp:Label runat="server" ID="lblSiparisDetaylari" Font-Bold="true" Visible="true">İade Detayları</asp:Label><asp:Label runat="server" ID="lblSiparisSonDurum" Font-Bold="true" Visible="false">İadenizin Son Durumu</asp:Label>
                <asp:Label ID="Label2" runat="server" Width="180px"></asp:Label>
                <asp:LinkButton runat="server" ID="lbOnaylamayaDevam" Font-Underline="true" Font-Size="16px" Font-Bold="true" Text="Devam Et" OnClick="lbOnaylamayaDevam_Click" Visible="false"></asp:LinkButton></td>
                <td valign="middle" align="right"><asp:LinkButton runat="server" ID="lbSiparisKapat" OnClick="lbSiparisKapat_Click" Font-Underline="False" Font-Bold="true" Text="X" /></td>
                </tr>
                </table>
                <table width="780px" cellpadding="10" cellspacing="0" style="font-family: Tahoma; font-size: 11px; height: 40px">
                            <tr style="color: #C00000">
                                <td style="width: 400px; font-size:12px; padding-left: 70px">
                                    Ürün
                                </td>
                                <td align="center" style="width: 60px; font-size:12px">
                                    Adet
                                </td>
                                <td align="center" style="width: 80px; font-size:12px">
                                    Net
                                </td>
                                <td align="center" style="width: 100px; font-size:12px">
                                    Net Top.
                                </td>
                                <td align="center" style="width: 100px; font-size:12px">
                                    Net+KDV Top.
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
                            <td style="width: 400px">
                                <%#Eval("Ad") %></td>
                            <td align="center" style="width: 60px;">
                                <%#Eval("Miktar")%>
                            </td>
                            <td align="right" style="width: 80px;">
                                <%#Convert.ToInt32(Eval("BirimFiyat")) == -1 || Convert.ToInt32(Eval("BirimFiyat")) == -2 ? "<i>Sonlandı</i>" : ((Convert.ToDouble(Eval("BirimFiyat")) * 100) / (100 + Convert.ToDouble(Eval("KDV")))).ToString("C3")%>
                            </td>
                            <td align="right" style="width: 100px;">
                                <%#Convert.ToInt32(Eval("BirimFiyat")) == -1 || Convert.ToInt32(Eval("BirimFiyat")) == -2 ? "<i>Sonlandı</i>" : (Convert.ToInt32(Eval("Miktar")) * ((Convert.ToDouble(Eval("BirimFiyat")) * 100) / (100 + Convert.ToDouble(Eval("KDV"))))).ToString("C3")%>
                            </td>
                            <td align="right" style="width: 100px;">
                                <%#Convert.ToInt32(Eval("BirimFiyat")) == -1 || Convert.ToInt32(Eval("BirimFiyat")) == -2 ? "<i>Sonlandı</i>" : (Convert.ToInt32(Eval("Miktar")) * Convert.ToDecimal(Eval("BirimFiyat"))).ToString("C3")%>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                        <tr style="background-color: #FFE2C6">
                            <td style="width: 400px">
                                <%#Eval("Ad") %></td>
                            <td align="center" style="width: 60px;">
                                <%#Eval("Miktar")%>
                            </td>
                            <td align="right" style="width: 80px;">
                                <%#Convert.ToInt32(Eval("BirimFiyat")) == -1 || Convert.ToInt32(Eval("BirimFiyat")) == -2 ? "<i>Sonlandı</i>" : ((Convert.ToDouble(Eval("BirimFiyat")) * 100) / (100 + Convert.ToDouble(Eval("KDV")))).ToString("C3")%>
                            </td>
                            <td align="right" style="width: 100px;">
                                <%#Convert.ToInt32(Eval("BirimFiyat")) == -1 || Convert.ToInt32(Eval("BirimFiyat")) == -2 ? "<i>Sonlandı</i>" : (Convert.ToInt32(Eval("Miktar")) * ((Convert.ToDouble(Eval("BirimFiyat")) * 100) / (100 + Convert.ToDouble(Eval("KDV"))))).ToString("C3")%>
                            </td>
                            <td align="right" style="width: 100px;">
                                <%#Convert.ToInt32(Eval("BirimFiyat")) == -1 || Convert.ToInt32(Eval("BirimFiyat")) == -2 ? "<i>Sonlandı</i>" : (Convert.ToInt32(Eval("Miktar")) * Convert.ToDecimal(Eval("BirimFiyat"))).ToString("C3")%>
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
                <asp:Label ID="Label3" runat="server" Width="100px" />
                <asp:Label runat="server" ID="lblOrtalamaVade" />
                </td>
                <td align="right">İade Toplamı: </td>
                </tr>
                </table>
                </td>
                <td valign="middle" align="right" style="width: 120px"><asp:Label runat="server" ID="lblSiparisToplam" Font-Bold="true" /></td>
                </tr>
                </table>
                </div>
            </div>

            <div style="position: absolute; width: 920px; height: 416px; z-index: 4; left: 40px; background-color: #ffffff;
                top: 50px;" runat="server" id="divFaturaTakip" visible="false">
                <div style="position: fixed; width: 100%; height: 100%; z-index: -1; left: 0; top: 0;
                filter: alpha(opacity=40); -moz-opacity: .40; opacity: .40; background-color: #000000" onclick="invisible()"></div>
                <div style="width: 100%; height: 100%; background-color: #ffffff;border: 1px solid #D1D1D1; border-radius: 5px; padding: 5px;">
                <table cellpadding="10" cellspacing="0" style="font-family: Tahoma; font-size:14px; width: 920px; height: 40px">
                <tr>
                <td valign="middle">
                <asp:Label ID="Label7" runat="server" Font-Bold="true" Visible="true">Fatura Takip</asp:Label>
                </td>
                <td valign="middle" align="right"><asp:LinkButton runat="server" ID="lbFaturaTakipKapat" OnClick="lbFaturaTakipKapat_Click" Font-Underline="False" Font-Bold="true" Text="X" /></td>
                </tr>
                </table>

                <table width="920px" cellpadding="10" cellspacing="0" style="font-family: Tahoma; font-size: 11px; height: 40px">
                    <tr>
                        <td align="center" style="width: 80px; font-size:12px;">
                            Fat.No:
                        </td>
                        <td align="center" style="width: 100px; font-size:12px;">
                            <asp:TextBox runat="server" ID="txtFaturaTakip" Width="100px"></asp:TextBox>
                        </td>
                        <td align="center" style="width: 80px; font-size:12px;">
                            Açıklama:
                        </td>
                        <td align="center" style="width: 200px; font-size:12px;">
                            <asp:TextBox runat="server" ID="txtFaturaTakipAciklama" Width="200px"></asp:TextBox>
                        </td>
                        <td align="center" style="width: 80px; font-size:12px;">
                            Müşteri:
                        </td>
                        <td align="left" style="width: 400px; font-size:12px;">
                            <input type="hidden" runat="server" id="inputFaturaTakipSMREF" value="0" />
                            <asp:Label runat="server" ID="lblFaturaTakipMusteri"></asp:Label>
                        </td>
                        <td align="center" style="width: 100px; font-size:12px;">
                            <asp:Button runat="server" ID="btnFaturaTakipGir" Text="Giriş Yap" OnClick="btnFaturaTakipGir_Click" />
                        </td>
                    </tr>
                </table>

                
                <div style="overflow: auto; width:920px; height: 280px">
                <asp:Repeater ID="rptFaturaTakip" runat="server">
                    <HeaderTemplate>
                        <table width="900px" cellpadding="3" cellspacing="0" style="font-family: Tahoma; font-size: 11px; height: 40px">
                        <tr style="color: #C00000">
                            <td align="center" style="width: 40px; font-size:12px;">
                                Fat.No
                            </td>
                            <td align="center"  style="width: 100px; font-size:12px;">
                                Giriş Tarihi
                            </td>
                            <td align="center" style="width: 120px; font-size:12px">
                                Açıklama
                            </td>
                            <td align="center" style="width: 75px; font-size:12px">
                                Kont.
                            </td>
                            <td align="center" style="width: 100px; font-size:12px">
                                Kont.Gönd.Tarihi
                            </td>
                            <td align="center" style="width: 140px; font-size:12px">
                                Kontrol Açıklama
                            </td>
                            <td align="center" style="width: 75px; font-size:12px">
                                Paz.
                            </td>
                            <td align="center" style="width: 100px; font-size:12px">
                                Paz.Gönd.Tarihi
                            </td>
                            <td align="center" style="width: 140px; font-size:12px">
                                Paz.Açıklama
                            </td>
                            <td align="center" style="width: 20px; font-size:12px">
                                
                            </td>
                        </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr style="background-color: #E8E8E8">
                            <td align="center" style="width: 40px">
                                <%#Eval("strFatNo")%>
                            </td>
                            <td align="center"  style="width: 100px;">
                                <%#Eval("dtGiris")%>
                            </td>
                            <td align="center" style="width: 140px;">
                                <%#Eval("strAciklama")%>
                            </td>
                            <td align="center" style="width: 75px;">
                                <asp:Image runat="server" ImageUrl="img/checkmark.png" Visible='<%# Convert.ToBoolean(Eval("blKontrol"))%>' />
                            </td>
                            <td align="center" style="width: 100px;">
                                <%#Eval("dtKontrol")%>
                            </td>
                            <td align="center" style="width: 140px;">
                                <%#Eval("strKontrol")%>
                            </td>
                            <td align="center" style="width: 75px;">
                                <asp:Image runat="server" ImageUrl="img/checkmark.png" Visible='<%# Convert.ToBoolean(Eval("blPazarlama"))%>' />
                            </td>
                            <td align="center" style="width: 100px;">
                                <%#Eval("dtPazarlama")%>
                            </td>
                            <td align="center" style="width: 140px;">
                                <%#Eval("strPazarlama")%>
                            </td>
                            <td align="center" style="width: 20px;">
                                <asp:LinkButton runat="server" Text="Sil" OnClick="lbFaturaTakipSil_Click" CommandArgument='<%#Eval("pkID")%>'></asp:LinkButton>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                        <tr style="background-color: #FFE2C6">
                            <td align="center" style="width: 40px">
                                <%#Eval("strFatNo")%>
                            </td>
                            <td align="center"  style="width: 100px;">
                                <%#Eval("dtGiris")%>
                            </td>
                            <td align="center" style="width: 140px;">
                                <%#Eval("strAciklama")%>
                            </td>
                            <td align="center" style="width: 75px;">
                                <asp:Image runat="server" ImageUrl="img/checkmark.png" Visible='<%# Convert.ToBoolean(Eval("blKontrol"))%>' />
                            </td>
                            <td align="center" style="width: 100px;">
                                <%#Eval("dtKontrol")%>
                            </td>
                            <td align="center" style="width: 140px;">
                                <%#Eval("strKontrol")%>
                            </td>
                            <td align="center" style="width: 75px;">
                                <asp:Image runat="server" ImageUrl="img/checkmark.png" Visible='<%# Convert.ToBoolean(Eval("blPazarlama"))%>' />
                            </td>
                            <td align="center" style="width: 100px;">
                                <%#Eval("dtPazarlama")%>
                            </td>
                            <td align="center" style="width: 140px;">
                                <%#Eval("strPazarlama")%>
                            </td>
                            <td align="center" style="width: 20px;">
                                <asp:LinkButton runat="server" Text="Sil" OnClick="lbFaturaTakipSil_Click" CommandArgument='<%#Eval("pkID")%>'></asp:LinkButton>
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

    <div style="width: 100%; font-size: 9px; font-family: Verdana; background-color: #EFEEEA; border-bottom: 1px solid #FFCFB2">
    <table cellpadding="5" cellspacing="0">
    <tr>
    <td style="width: 800px;" valign="middle">
        <table cellpadding="0" cellspacing="0"><tr><td>
        <input type="button" value="Giriş" onclick="javascript:window.location.href='default.aspx'" /> 
        <input type="button" value="Aktiviteler" onclick="javascript:window.location.href='aktiviteler.aspx'" /> 
        <input type="button" value="H.Bedelleri" onclick="javascript:window.location.href='hizmetbedelleri.aspx'" /> 
        <input type="button" value="Anlaşmalar" onclick="javascript:window.location.href='anlasmalar.aspx'" /> 
        <input type="button" value="Siparişler" onclick="javascript:window.location.href='siparisler.aspx'" /> 
        <input type="button" value="İadeler" disabled="disabled" /> 
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
            <td><img src="img/ic_iadeler.png" /></td>
            <td>İadeler</td>
            </tr></table>
            </div>
            <div style="padding: 10px 10px 0px 25px; font-size: 12px" runat="server" id="divHesapSecim">
            <div runat="server" id="divCariHesapArama" visible="false" style="padding: 5px 5px 5px 0px;">
                <asp:RadioButton runat="server" ID="rbCariHesapAraMusteri" Checked="false" GroupName="grCariHesapAra" Text="Müşteri" />&nbsp;
                <asp:RadioButton runat="server" ID="rbCariHesapAraSattem" Checked="true" GroupName="grCariHesapAra" Text="Satış Temsilcisi" />&nbsp;
                <asp:TextBox runat="server" ID="txtCariHesapAra" Width="150px" onkeypress="return clickButton(event,'btnCariHesapAra')"
                    ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" BorderWidth="1px" Height="23px" style="padding: 0px 3px 0px 3px"></asp:TextBox>&nbsp;
                <asp:Button runat="server" ID="btnCariHesapAra" Width="100px" Text="Ara" OnClick="btnCariHesapAra_Click" 
                    BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" ForeColor="#6D8AAA" />&nbsp;
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
                <asp:Button runat="server" ID="btnFaturaTakip" Text="Fat.Takip" OnClick="btnFaturaTakip_Click" />
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
                    <asp:RadioButton runat="server" ID="rbKaydedilmisler" Text="Kaydedilmiş İade Talepleri" AutoPostBack="true"
                        GroupName="grOnaySuzme" OnCheckedChanged="rbSiparislerHepsi_Checked" Checked="true" />
                    <asp:RadioButton runat="server" ID="rbOnayTalepEdilmisler" Text="Onay Talep Edilmiş İadeler" AutoPostBack="true"
                        GroupName="grOnaySuzme" OnCheckedChanged="rbSiparislerHepsi_Checked" />
                    <asp:RadioButton runat="server" ID="rbOnayTaleptenGelenler" Text="Onay Talepten Gelen Fiyatlanmış İadeler" AutoPostBack="true"
                        GroupName="grOnaySuzme" OnCheckedChanged="rbSiparislerHepsi_Checked" />
                </div>
                <div style="padding: 0px 3px 3px 25px; font-size: 11px">
                    <asp:RadioButton runat="server" ID="rbOnaylanmislar" Text="Onaylanmış İadeler" AutoPostBack="true"
                        GroupName="grOnaySuzme" OnCheckedChanged="rbSiparislerHepsi_Checked" />
                    <asp:RadioButton runat="server" ID="rbDegisimler" Text="Sonlananlar" AutoPostBack="true"
                        GroupName="grOnaySuzme" OnCheckedChanged="rbSiparislerHepsi_Checked" />
                    <asp:RadioButton runat="server" ID="rbReddedilmis" Text="Kabul Edilmemiş İadeler" AutoPostBack="true"
                        GroupName="grOnaySuzme" OnCheckedChanged="rbSiparislerHepsi_Checked" />
                </div>
                <div style="width: 930px; text-align: right">
                    <input type="hidden" value="kapali" runat="server" id="inputTopluIslemGosterGizle" />
                    <input type="button" value="Toplu İşlemler" style="width: 150px" onclick="topluislemgostergizle()" />
                </div>
                <table cellpadding="1" cellspacing="0" style="margin-left: 10px; margin-bottom: 5px">
                    <tr style="color: #D00000">
                        <td style="width: 30px; text-align: center; height: 20px; border-bottom: 1px solid #CCCCCC"><asp:CheckBox runat="server" ID="cbSiparislerSecimTumu" AutoPostBack="true" OnCheckedChanged="cbSiparislerSecimTumu_CheckedChanged" ToolTip="Tümünü Seç / Seçimi Temizle" class="kucukbilgiGoster" /></td>
                        <td style="width: 50px; text-align: center; height: 20px; border-bottom: 1px solid #CCCCCC">İade No</td>
                        <td style="width: 110px; text-align: left; height: 20px; border-bottom: 1px solid #CCCCCC">İade Sahibi</td>
                        <td style="width: 110px; text-align: left; height: 20px; border-bottom: 1px solid #CCCCCC">İade Gir.</td>
                        <td style="width: 260px; text-align: left; height: 20px; border-bottom: 1px solid #CCCCCC">C/H Açıklaması</td>
                        <td style="width: 70px; text-align: center; height: 20px; border-bottom: 1px solid #CCCCCC">İade Tar.</td>
                        <td style="width: 100px; text-align: right; height: 20px; border-bottom: 1px solid #CCCCCC">İade Top.</td>
                        <td style="width: 180px; text-align: center;"></td>
                    </tr>
                </table>
                <asp:DataList ID="dlSiparisler" runat="server" OnItemDataBound="dlSiparisler_DataBound">
                    <HeaderTemplate><table cellpadding="1" cellspacing="0" style="margin-left: 10px">
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr onmouseover="Satir(this,true)" onmouseout="Satir(this,false)">
                            <td style="width: 30px; text-align: center; height: 30px; vertical-align: top">
                                <asp:CheckBox runat="server" AutoPostBack="false" ToolTip='<%#Eval("pkIadeID")%>' />
                            </td>
                            <td style="width: 50px; text-align: center; height: 30px; vertical-align: top"><strong class="classurtkod" title='iadegecmis.aspx?id=<%#Eval("pkIadeID") %>' style="cursor: pointer; color: #C10000"><span style="font-weight: bold"><%#Eval("pkIadeID")%></span></strong></td>
                            <td style="width: 110px; text-align: left; height: 30px; vertical-align: top"><input type="hidden" value='<%#Eval("intMusteriID") %>' id="MusteriID" runat="server" /><%#Eval("strAd")%> <%#Eval("strSoyad")%></td>
                            <td style="width: 110px; text-align: left; height: 30px; vertical-align: top"><%#Eval("strAciklama").ToString().Split(new string[] { ";;;" }, StringSplitOptions.None)[0]%></td>
                            <td style="width: 260px; text-align: left; height: 30px; vertical-align: top; font-size: 8px"><%#Eval("MUSTERI")%></td>
                            <td style="width: 70px; text-align: center; height: 30px; vertical-align: top"><span class="kucukbilgiGoster" title="Onaylama Tarihi: <%#(Convert.ToDateTime(Eval("dtOlusmaTarihi")).ToString() != Convert.ToDateTime(Eval("dtOnaylamaTarihi")).ToString()) ? Convert.ToDateTime(Eval("dtOnaylamaTarihi")).ToString() : "<i>Henüz onaylanmamış.</i>"%>"><%#Convert.ToDateTime(Eval("dtOlusmaTarihi")).ToShortDateString()%><br /><%#Convert.ToDateTime(Eval("dtOlusmaTarihi")).ToShortTimeString()%></span></td>
                            <td style="width: 100px; text-align: right; height: 30px; vertical-align: top"><%#Convert.ToInt32(Eval("mnToplamTutar")) == -1 || Convert.ToInt32(Eval("mnToplamTutar")) == -2 ? "<i>Sonlandı</i>" : Convert.ToDecimal(Eval("mnToplamTutar")).ToString("C3")%></td>
                            <td style="width: 20px; text-align: center; height: 30px; vertical-align: top">
                                <asp:ImageButton class="kucukbilgiGoster" runat="server" ToolTip="İncele" ImageUrl="img/incele.gif" OnClick="ibIncele_Click" />
                            </td>
                            <td style="width: 20px; text-align: center; height: 30px; vertical-align: top">
                                <asp:ImageButton class="kucukbilgiGoster" runat="server" Visible='<%#(Convert.ToBoolean(((Sultanlar.DatabaseObject.Internet.Musteriler)Session["Musteri"]).tintUyeTipiID != 1))%>' ToolTip="Kopyala" ImageUrl="img/kopyala.gif" OnClick="ibKopyala_Click" />
                            </td>
                            <td style="width: 20px; text-align: center; height: 30px; vertical-align: top">
                                <input type="hidden" value='<%#Eval("pkIadeID") %>' id="IadeID" runat="server" />
                                <input type="hidden" value='<%#Eval("SMREF") %>' id="SMREF" runat="server" />
                                <asp:ImageButton class="kucukbilgiGoster" runat="server" Visible='<%#(!Convert.ToBoolean(Eval("blAktarilmis")) && Convert.ToDecimal(Eval("mnToplamTutar")) == 0 && Convert.ToBoolean(((Sultanlar.DatabaseObject.Internet.Musteriler)Session["Musteri"]).tintUyeTipiID != 1))%>' ToolTip="Değiştir" ImageUrl="img/degistir.gif" OnClick="ibDegistir_Click" />
                            </td>
                            <td style="width: 20px; text-align: center; height: 30px; vertical-align: top">
                                <asp:ImageButton class="kucukbilgiGoster" runat="server" Visible='<%#(!Convert.ToBoolean(Eval("blAktarilmis")) && Convert.ToDecimal(Eval("mnToplamTutar")) == 0 && Convert.ToBoolean(((Sultanlar.DatabaseObject.Internet.Musteriler)Session["Musteri"]).tintUyeTipiID != 1))%>' ToolTip="Onay Talebi Yap" ImageUrl="img/onayla.gif" OnClick="ibOnayla_Click" />
                            </td>
                            <td style="width: 20px; text-align: center; height: 30px; vertical-align: top">
                                <asp:ImageButton class="kucukbilgiGoster" runat="server" Visible='<%#(!Convert.ToBoolean(Eval("blAktarilmis")) && Convert.ToDecimal(Eval("mnToplamTutar")) == 0 && Convert.ToBoolean(((Sultanlar.DatabaseObject.Internet.Musteriler)Session["Musteri"]).tintUyeTipiID != 1))%>' ToolTip="Sil" ImageUrl="img/sil.gif" OnClick="ibSil_Click" />
                            </td>
                            <td style="width: 20px; text-align: center; height: 30px; vertical-align: top">
                                <asp:ImageButton class="kucukbilgiGoster" runat="server" ToolTip="Yazdır" ImageUrl="img/yazdir.gif" OnClientClick="Yazdir()" OnClick="ibYazdir_Click" />
                            </td>
                            <td style="width: 20px; text-align: center; height: 30px; vertical-align: top">
                                <asp:ImageButton class="kucukbilgiGoster" runat="server" ToolTip="Kaydet" ImageUrl="img/kaydet.gif" OnClick="ibKaydet_Click" />
                            </td>
                            <td style="width: 20px; text-align: center; height: 30px; vertical-align: top">
                                
                            </td>
                            <td style="width: 20px; text-align: center; height: 30px; vertical-align: top">
                                <%--<asp:ImageButton class="kucukbilgiGoster" runat="server" ToolTip="Fiyatlandırılmış İadeyi Onayla" ImageUrl="img/fiyatlionayla.gif" OnClick="ibDurum_Click" Visible='<%#(Convert.ToBoolean(Eval("blAktarilmis")) && Convert.ToDecimal(Eval("mnToplamTutar")) > 0 && Convert.ToBoolean(((Sultanlar.DatabaseObject.Internet.Musteriler)Session["Musteri"]).tintUyeTipiID != 1))%>' title="Fiyatlandırılmış İadeyi Onayla" />--%>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate></table></FooterTemplate>
                </asp:DataList>
                <asp:Label runat="server" ID="lblSiparisYok" Visible="false" Text="- Listenecek iade bulunamadı. -" Font-Italic="true" style="padding-left: 200px"></asp:Label>
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
                <br />
            </td>
        </tr>
        <tr>
            <td align="left" style="padding-left: 30px; font-size: 12px">
            </td>
        </tr>
        <tr>
            <td>
                <br />
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

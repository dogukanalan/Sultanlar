<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="odemeler.aspx.cs" Inherits="Sultanlar.WebUI.musteri.odemeler" %>

<%@ Register src="ucAlt.ascx" tagname="ucAlt" tagprefix="uc1" %>

<%@ Register src="ucProgress.ascx" tagname="ucProgress" tagprefix="uc2" %>

<%@ Register src="ucMesajlar.ascx" tagname="ucMesajlar" tagprefix="uc3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Sultanlar : Tahsilatlar</title>
    <script type="text/javascript">
        function invisible() {
            if (document.getElementById('divOdemeAyrinti') != null) {
                window.location.href = document.getElementById('lbOdemeAyrintiKapat').href;
                return false;
            }
            if (document.getElementById('divOdemeKaydet') != null) {
                window.location.href = document.getElementById('lbOdemeKaydetKapat').href;
                return false;
            }
            if (document.getElementById('divSiparis') != null) {
                window.location.href = document.getElementById('lbSiparisKapat').href;
                return false;
            }
            if (document.getElementById('divMesaj') != null) {
                window.location.href = document.getElementById('lbMesajKapat').href;
                return false;
            }
        }
        function OdemeAyrintiYazdir() {
            yenipen = window.open('odemeyazdir.aspx', '_blank', 'toolbar=yes,location=no,status=no,menubar=yes,scrollbars=yes,width=1024,height=480,noresize');
            yenipen.moveTo(0, 0);
        }
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;

            return true;
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
    </script>
    <style type="text/css">
        #top
        {
            bottom: 5px;
            right: 5px;
            background: #147;
            padding: 5px;
            color: #fff;
            font: bold 11px verdana;
            position: fixed;
            display: none;
            cursor: default;
        }
    </style>

    <script type="text/javascript" src="js/jquery.tipTip.js"></script>
    <script type="text/javascript" src="js/jquery.tipTip.minified.js"></script>
    <link rel="stylesheet" type="text/css" href="js/tipTip.css" />

</head>
<body style="margin: 0 0 0 0;">
    <form id="form1" runat="server"><div id="top" style="z-index: 50;">Yukarı Çık</div>
    <asp:ScriptManager ID="AjaxScripts" runat="server">
    </asp:ScriptManager>
    <script type="text/javascript">
        Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(function (evt, args) {
            $('#rbCariHesapAraMusteri').button();
            $('#rbCariHesapAraSattem').button();
            $("input[type=submit], input[type=button]").button();
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

    <div style="position: absolute; width: 700px; height: 550px; z-index: 5; left: 150px;
        top: 5px" runat="server" id="divOdeme1" visible="false">
        <div style="position: fixed; width: 100%; height: 100%; z-index: -1; left: 0; top: 0;
        filter: alpha(opacity=40); -moz-opacity: .40; opacity: .40; background-color: #000000" onclick="invisible()"></div>
        <table style="width: 100%; height: 100%; background-color: #ffffff; font-family: Tahoma; font-size: 12px;
            border: 1px solid #D1D1D1; border-radius: 5px; padding: 5px;">
        <tr>
        <td align="center" style="padding-top: 10px;">
            <strong>Ödeme</strong>
        </td>
        </tr>
        <tr>
        <td align="center" style="font-style: italic; font-size: 10px; padding-top: 5px;">
            <%--* Ödeme yapmadan siparişi onaylamak için, altta bulunan "Ödeme Ekranını Kapat"ı tıklayınız.--%>
        </td>
        </tr>
        <tr>
        <td align="center" valign="middle" style="padding-top: 10px; padding-bottom: 10px">
            Ödeme Yapmak İstediğiniz Tutarı Belirleyiniz: 
            <asp:Label runat="server" Width="20px"></asp:Label>
            <asp:TextBox ID="txtOdemeTutar" runat="server" Width="50px" BorderColor="#A3B5C9" 
                BorderStyle="Solid" BorderWidth="1px" ForeColor="#006699"
                style="padding: 3px 3px 3px 3px" Font-Size="10px"></asp:TextBox> 
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                ControlToValidate="txtOdemeTutar" ErrorMessage="Gerekli alan" 
                ToolTip="Gerekli alan" ValidationGroup="cgOdemeAdim1">*</asp:RequiredFieldValidator>
            <asp:RangeValidator ID="RangeValidator1" runat="server" 
                ControlToValidate="txtOdemeTutar" ErrorMessage="Girilen değerin formatı yanlış" 
                MaximumValue="999999" MinimumValue="0,01" 
                ToolTip="Girilen değerin formatı yanlış" Type="Double" 
                ValidationGroup="cgOdemeAdim1">*</asp:RangeValidator>
            (Örnek: 20,00)
            <br /><br />
            <asp:ValidationSummary runat="server" ValidationGroup="cgOdemeAdim1" EnableClientScript="true" DisplayMode="BulletList"
                ForeColor="DarkRed" />
        </td>
        </tr>
        <tr>
        <td align="center" valign="bottom" style="padding-top: 10px; padding-bottom: 10px">
            <asp:Button runat="server" ID="btnOdemeTutarDevam" Text="Sonraki Adım" 
                Font-Bold="true" Font-Size="14px" Width="150px" ForeColor="#6D8AAA" BorderWidth="1px"
                BorderColor="#CCCCCC" BorderStyle="Solid" OnClick="btnOdemeTutarDevam_Click" ValidationGroup="cgOdemeAdim1" />
        </td>
        </tr>
        <tr>
        <td align="center" style="padding-bottom: 10px;">
            <asp:LinkButton runat="server" ID="lbOdemeVazgec1" 
                onclick="lbOdemeVazgec1_Click">Ödeme Ekranını Kapat</asp:LinkButton>
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
            <strong>Ödeme</strong>
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
                    <td style="width: 100%; text-align: center"><strong>Ödeme Ayrıntıları</strong></td>
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

            <div style="position: absolute; width: 420px; height: 100px; z-index: 3; left: 290px;
                top: 150px" runat="server" id="divOdemeKaydet" visible="false">
                <div style="position: fixed; width: 100%; height: 100%; z-index: -1; left: 0; top: 0;
                filter: alpha(opacity=40); -moz-opacity: .40; opacity: .40; background-color: #000000" onclick="invisible()"></div>
                <table style="width: 100%; height: 100%; background-color: #ffffff; font-family: Tahoma; font-size: 12px;
                    border: 1px solid #D1D1D1; border-radius: 5px; padding: 5px;">
                <tr>
                <td align="center" valign="middle" style="padding-top: 15px; padding-bottom: 15px">
                    <iframe frameborder="0" src="indir.aspx" width="100%" height="120px"></iframe>
                    <asp:LinkButton runat="server" ID="lbOdemeKaydetKapat" 
                        onclick="lbOdemeKaydetKapat_Click">Kapat</asp:LinkButton>
                </td>
                </tr>
                </table>
            </div>


            <div style="position: absolute; width: 800px; height: 416px; z-index: 4; left: 100px; background-color: #ffffff;
                top: 70px;" runat="server" id="divSiparis" visible="false">
                <div style="position: fixed; width: 100%; height: 100%; z-index: -1; left: 0; top: 0;
                filter: alpha(opacity=40); -moz-opacity: .40; opacity: .40; background-color: #000000" onclick="invisible()"></div>
                <div style="width: 100%; height: 100%; background-color: #ffffff;border: 1px solid #D1D1D1; border-radius: 5px; padding: 5px;">
                <table cellpadding="10" cellspacing="0" style="font-family: Tahoma; font-size:14px; width: 800px; height: 40px">
                <tr>
                <td valign="middle">
                <asp:Label runat="server" ID="lblSiparisDetaylari" Font-Bold="true">Sipariş Detayları</asp:Label>
                <asp:Label runat="server" Width="180px"></asp:Label>
                </td>
                <td valign="middle" align="right"><asp:LinkButton runat="server" ID="lbSiparisKapat" OnClick="lbSiparisKapat_Click" Font-Underline="False" Font-Bold="true" Text="X" /></td>
                </tr>
                </table>
                <table width="780px" cellpadding="10" cellspacing="0" style="font-family: Tahoma; font-size: 11px; height: 40px">
                            <tr style="color: #C00000">
                                <td style="width: 500px; font-size:12px; padding-left: 70px">
                                    Ürün
                                </td>
                                <td align="center" style="width: 60px; font-size:12px">
                                    Adet
                                </td>
                                <td align="center" style="width: 80px; font-size:12px">
                                    Fiyat
                                </td>
                                <td align="center" style="width: 100px; font-size:12px">
                                    Toplam
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
                                <%#Eval("Miktar")%>
                            </td>
                            <td align="right" style="width: 80px;">
                                <%#Convert.ToDecimal(Eval("BirimFiyat")).ToString("N3")%> TL
                            </td>
                            <td align="right" style="width: 100px;">
                                <%#Convert.ToBoolean(Eval("KampanyaHediye")) ? "0,000 TL" :  (Convert.ToInt32(Eval("Miktar")) * Convert.ToDecimal(Eval("BirimFiyat"))).ToString("C3")%>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                        <tr style="background-color: #FFE2C6">
                            <td style="width: 500px">
                                <%#Eval("Ad") %></td>
                            <td align="center" style="width: 60px;">
                                <%#Eval("Miktar")%>
                            </td>
                            <td align="right" style="width: 80px;">
                                <%#Convert.ToDecimal(Eval("BirimFiyat")).ToString("N3")%> TL
                            </td>
                            <td align="right" style="width: 100px;">
                                <%#Convert.ToBoolean(Eval("KampanyaHediye")) ? "0,000 TL" :  (Convert.ToInt32(Eval("Miktar")) * Convert.ToDecimal(Eval("BirimFiyat"))).ToString("C3")%>
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
        <input type="button" value="Tahsilatlar" disabled="disabled" /> 
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
    <table cellpadding="0" cellspacing="0" style="width: 1000px; height: 400px; font-size: 10px;
        font-family: Verdana; background-position: center center; background-image: url('img/bg-logo.jpg');
        background-repeat: no-repeat;">
        <tr>
            <td valign="top">
                <div class="Baslik">
                <table cellpadding="0" cellspacing="0"><tr>
                <td><img src="img/ic_tahsilatlar.png" /></td>
                <td>Tahsilatlar</td>
                <td align="right" style="width: 100%">
                <div runat="server"
                    id="divOdemeYap" visible="true">
                    <asp:Button runat="server" ID="btnOdemeYap" Text="Ödeme Yap" Font-Bold="true" Font-Size="12px"
                        Width="150px" OnClick="btnOdemeYap_Click" BorderColor="#CCCCCC" BorderStyle="Solid"
                        BorderWidth="1px" ForeColor="#6D8AAA" />
                </div>
                </td>
                </tr></table>
                </div>
                <div style="padding: 10px 10px 10px 25px; font-size: 12px" runat="server" id="divHesapSecim">
                <div runat="server" id="divCariHesapArama" visible="false" style="padding: 5px 5px 5px 0px;">
                    <asp:RadioButton runat="server" ID="rbCariHesapAraMusteri" Checked="true" GroupName="grCariHesapAra" Text="Müşteri" />&nbsp;
                    <asp:RadioButton runat="server" ID="rbCariHesapAraSattem" Checked="false" GroupName="grCariHesapAra" Text="Satış Temsilcisi" />&nbsp;
                    <asp:TextBox runat="server" ID="txtCariHesapAra" Width="150px" onkeypress="return clickButton(event,'btnCariHesapAra')"
                        ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" BorderWidth="1px" Height="23px" style="padding: 0px 3px 0px 3px"></asp:TextBox>&nbsp;
                    <asp:Button runat="server" ID="btnCariHesapAra" Width="100px" Text="Ara" OnClick="btnCariHesapAra_Click" 
                        BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" ForeColor="#6D8AAA" />&nbsp;
                    <%--<asp:Button runat="server" ID="btnCariHesapTemizle" Width="100px" Text="Tümünü Getir" OnClick="btnCariHesapTemizle_Click"
                        BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" ForeColor="#6D8AAA" />&nbsp;--%>
                </div>
                <asp:DropDownList ID="ddlTemsilciler" runat="server" Width="200px" AutoPostBack="True" 
                    Font-Bold="False" Font-Italic="False" Height="25px"
                    Font-Overline="False" Font-Size="11px" Font-Strikeout="False" 
                    Font-Underline="False" style="filter: alpha(opacity=80); -moz-opacity: .80; opacity: .80; padding: 3px 3px 3px 3px;border:1px solid #CCCCCC;background:#ededed;" 
                    onselectedindexchanged="ddlTemsilciler_SelectedIndexChanged" 
                    ForeColor="#006699">
                </asp:DropDownList>
                <asp:Label runat="server" Width="20px"></asp:Label>
                <asp:DropDownList ID="ddlCariHesaplar" runat="server" Width="500px" AutoPostBack="True" 
                    Font-Bold="False" Font-Italic="False" Height="25px"
                    Font-Overline="False" Font-Size="11px" Font-Strikeout="False" 
                    Font-Underline="False" style="filter: alpha(opacity=80); -moz-opacity: .80; opacity: .80; padding: 3px 3px 3px 3px;border:1px solid #CCCCCC;background:#ededed;"
                    onselectedindexchanged="ddlCariHesaplar_SelectedIndexChanged" 
                    ForeColor="#006699">
                </asp:DropDownList>
                </div>
                <table cellpadding="1" cellspacing="0" style="margin-left: 10px; margin-bottom: 5px">
                    <tr style="color: #D00000">
                        <td style="width: 70px; text-align: center; height: 20px; border-bottom: 1px solid #CCCCCC">
                            Sip. No
                        </td>
                        <td style="width: 170px; text-align: left; height: 20px; border-bottom: 1px solid #CCCCCC">
                            Ödm. Gir.
                        </td>
                        <td style="width: 280px; text-align: left; height: 20px; border-bottom: 1px solid #CCCCCC">
                            C/H Açıklaması
                        </td>
                        <td style="width: 70px; text-align: center; height: 20px; border-bottom: 1px solid #CCCCCC">
                            Ödm. Tar.
                        </td>
                        <td style="width: 100px; text-align: center; height: 20px; border-bottom: 1px solid #CCCCCC">
                            Kredi Kartı
                        </td>
                        <td style="width: 130px; text-align: center; height: 20px; border-bottom: 1px solid #CCCCCC">
                            İşlem No
                        </td>
                        <td style="width: 90px; text-align: right; height: 20px; border-bottom: 1px solid #CCCCCC">
                            Ödm. Top.
                        </td>
                        <td style="width: 40px; text-align: center">
                        </td>
                    </tr>
                </table>
                <asp:DataList ID="dlOdemeler" runat="server" OnItemDataBound="dlOdemeler_DataBound">
                    <HeaderTemplate>
                        <table cellpadding="1" cellspacing="0" style="margin-left: 10px">
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr onmouseover="Satir(this,true)" onmouseout="Satir(this,false)">
                            <td style="width: 70px; text-align: center; height: 30px; vertical-align: top">
                            <input type="hidden" value='<%#Eval("pkOdemeID") %>' id="OdemeID" runat="server" />
                            <input type="hidden" value='<%#Eval("intSiparisID") %>' id="SiparisID" runat="server" />
                            <asp:LinkButton runat="server" CommandArgument='<%#Eval("intSiparisID")%>' Text='<%#Eval("intSiparisID")%>' OnClick="lbSiparisIncele_Click"></asp:LinkButton>
                            <%--<asp:Label runat="server" Text='-' Visible='<%#Convert.ToBoolean(((Sultanlar.DatabaseObject.Internet.Musteriler)Session["Musteri"]).tintUyeTipiID != 5)%>'></asp:Label>--%>
                            </td>
                            <td style="width: 170px; text-align: left; height: 30px; vertical-align: top">
                                <input type="hidden" value='<%#Eval("intMusteriID") %>' id="MusteriID" runat="server" /><%#Eval("AdSoyad")%>
                            </td>
                            <td style="width: 280px; text-align: left; height: 30px; vertical-align: top">
                                <%#Eval("MUSTERI")%>
                            </td>
                            <td style="width: 70px; text-align: center; height: 30px; vertical-align: top">
                                <span class="kucukbilgiGoster" title="<%#Convert.ToDateTime(Eval("dtOdemeZamani")).ToShortTimeString()%>">
                                    <%#Convert.ToDateTime(Eval("dtOdemeZamani")).ToShortDateString()%>
                            </td>
                            <td style="width: 100px; text-align: center; height: 30px; vertical-align: top">
                                <%#Eval("strMaskedPan").ToString()%>
                            </td>
                            <td style="width: 130px; text-align: center; height: 30px; vertical-align: top">
                                <%#Eval("strTransId")%>
                            </td>
                            <td style="width: 90px; text-align: right; height: 30px; vertical-align: top">
                                <%#Convert.ToDecimal(Eval("mnTutar")).ToString("C3")%>
                            </td>
                            <td style="width: 20px; text-align: center; height: 30px; vertical-align: top">
                                <asp:ImageButton class="kucukbilgiGoster" runat="server" ToolTip="Kaydet" ImageUrl="img/kaydet.gif" OnClick="ibKaydet_Click" />
                            </td>
                            <td style="width: 20px; text-align: center; height: 30px; vertical-align: top">
                                <asp:ImageButton class="kucukbilgiGoster" runat="server" ToolTip="Ödeme Detayı" ImageUrl="img/odeme.gif" OnClick="ibOdemeDetayi_Click" />
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </table></FooterTemplate>
                </asp:DataList>
                <br />
                <asp:Label runat="server" ID="lblSiparisYok" Visible="false" Text="- Listenecek tahsilat bulunamadı. -" Font-Italic="true" style="padding-left: 200px"></asp:Label>
            </td>
            </tr>
            <tr>
            <td>
                <table cellpadding="0" cellspacing="0" style="width: 968px; margin-left: 10px; margin-top: 5px">
                    <tr>
                        <td align="left">
                            <asp:ImageButton runat="server" ID="ibOnceki" ImageUrl="img/sol_ok.gif" OnClick="ibOnceki_Click" />
                        </td>
                        <td align="center">
                            <asp:Label runat="server" ID="lblOdemeKacinci">0</asp:Label>
                            /
                            <asp:Label runat="server" ID="lblOdemeSayisi">0</asp:Label>
                        </td>
                        <td align="right">
                            <asp:ImageButton runat="server" ID="ibSonraki" ImageUrl="img/sag_ok.gif" OnClick="ibSonraki_Click" />
                        </td>
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

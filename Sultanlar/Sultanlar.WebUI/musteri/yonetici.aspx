<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="yonetici.aspx.cs" Inherits="Sultanlar.WebUI.musteri.yonetici" %>

<%@ Register src="ucAlt.ascx" tagname="ucAlt" tagprefix="uc1" %>

<%@ Register src="ucProgress.ascx" tagname="ucProgress" tagprefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sultanlar : Yönetim Sayfası</title>
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
            if (document.getElementById('divSevkYerleri') != null) {
                window.location.href = document.getElementById('lbOnaylaKapat').href;
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
        }
        function Satir(kontrol, uzerinde) {
            if (uzerinde) {
                kontrol.style.cssText = "filter: alpha(opacity=80); -moz-opacity: .80; opacity: .80; background-color: #E5E5E5";
                //kontrol.style.backgroundColor = "#D3F0FF";
            }
            else
                kontrol.style.cssText = "filter: alpha(opacity=80); -moz-opacity: .80; opacity: .80;";
        }
        function Yazdir() {
            yenipen = window.open('yazdir.aspx', '_blank', 'toolbar=no,location=no,status=no,menubar=no,scrollbars=yes,width=1024,height=480,noresize');
            yenipen.moveTo(0, 0);
        }
        function KisilerGoster() {
            document.getElementById('divKisiler').style.visibility = 'visible';
        }
        function KisilerGizle() {
            document.getElementById('divKisiler').style.visibility = 'hidden';
        }
    </script>
    <script type="text/javascript" src="img/jquery-1.2.6.pack.js"></script>
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
    <link rel="stylesheet" type="text/css" href="StyleSheet.css" />
    <script type="text/javascript" src="js/tooltip.js"></script>
</head>
<body style="margin: 0 0 0 0; background-color: #EBEAE6">
    <form id="form1" runat="server">
    <div id="top" style="z-index: 20;">
        Yukarı Çık</div>
    <asp:ScriptManager ID="AjaxScripts" runat="server">
    </asp:ScriptManager>
    <asp:UpdateProgress ID="DivAjaxProg" runat="server">
        <ProgressTemplate>
            <uc2:ucProgress ID="ucProgress1" runat="server" />
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdatePanel runat="server" ID="divAjaxDefault">
        <ContentTemplate>
        <div style="position: absolute; z-index: 3; left: 443px;
            top: 45px; visibility: hidden; filter: alpha(opacity=60); -moz-opacity: .60; opacity: .60;" 
                id="divKisiler">
            <table style="width: 100%; height: 100%; background-color: #000000; font-family: Tahoma; font-size: 11px; color: #FFFFFF">
            <tr>
            <td align="left" valign="top" style="padding: 10px 10px 10px 10px">
                <asp:Label runat="server" ID="lblKisiler"></asp:Label>
            </td>
            </tr>
            </table>
        </div>
        <div style="position: absolute; width: 420px; height: 100px; z-index: 3; left: 230px;
                top: 200px" runat="server" id="divSiparisKaydet" visible="false">
                <div style="position: fixed; width: 100%; height: 100%; z-index: -1; left: 0; top: 0;
                filter: alpha(opacity=40); -moz-opacity: .40; opacity: .40; background-color: #000000" onclick="invisible()"></div>
                <table style="width: 100%; height: 100%; background-color: #ffffff; font-family: Tahoma; font-size: 12px;">
                <tr>
                <td align="center" valign="middle" style="padding-top: 15px; padding-bottom: 15px">
                    <iframe frameborder="0" src="indir.aspx" width="100%" height="100%"></iframe>
                    <asp:LinkButton runat="server" ID="lbSiparisKaydetKapat" 
                        onclick="lbSiparisKaydetKapat_Click">Kapat</asp:LinkButton>
                </td>
                </tr>
                </table>
            </div>
            <div style="position: absolute; width: 420px; height: 100px; z-index: 3; left: 230px;
                top: 200px" runat="server" id="divSiparisSil" visible="false">
                <div style="position: fixed; width: 100%; height: 100%; z-index: -1; left: 0; top: 0;
                filter: alpha(opacity=40); -moz-opacity: .40; opacity: .40; background-color: #000000" onclick="invisible()"></div>
                <table style="width: 100%; height: 100%; background-color: #ffffff; font-family: Tahoma; font-size: 12px;">
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
            <div style="position: absolute; width: 800px; height: 400px; z-index: 3; left: 80px; background-color: #ffffff;
                top: 100px;" runat="server" id="divSiparis" visible="false">
                <div style="position: fixed; width: 100%; height: 100%; z-index: -1; left: 0; top: 0;
                filter: alpha(opacity=40); -moz-opacity: .40; opacity: .40; background-color: #000000" onclick="invisible()"></div>
                <div style="width: 100%; height: 100%; background-color: #ffffff">
                <table cellpadding="10" cellspacing="0" style="font-family: Tahoma; font-size:14px; width: 800px; height: 40px">
                <tr>
                <td valign="middle"><strong>Sipariş Detayları</strong></td>
                <td valign="middle" align="right"><asp:LinkButton runat="server" ID="lbSiparisKapat" OnClick="lbSiparisKapat_Click" Font-Underline="False" Font-Bold="true" Text="X" /></td>
                </tr>
                </table>
                <table width="780px" cellpadding="10" cellspacing="0" style="font-family: Tahoma; font-size: 11px; height: 40px">
                    <tr>
                        <td style="width: 500px; font-size:12px; padding-left: 70px">
                            <u>Ürün</u>
                        </td>
                        <td align="left" style="width: 60px; font-size:12px">
                            <u>Adet</u>
                        </td>
                        <td align="center" style="width: 80px; font-size:12px">
                            <u>Fiyat</u>
                        </td>
                        <td align="center" style="width: 100px; font-size:12px">
                            <u>Toplam</u>
                        </td>
                    </tr>
                </table>
                <div style="overflow: auto; width:800px; height: 280px">
                <asp:Repeater ID="Repeater1" runat="server">
                    <HeaderTemplate>
                        <table width="780px" cellpadding="10" cellspacing="0" style="font-family: Tahoma; font-size: 11px">
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr style="background-color: #DDDDDD">
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
                        <tr style="background-color: #FFDAB2">
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
                <table cellpadding="10" cellspacing="0" style="font-family: Tahoma; font-size:14px; width: 800px; height: 40px">
                <tr>
                <td valign="middle" align="right">
                <table cellpadding="0" cellspacing="0" width="100%">
                <tr>
                <td><asp:Label runat="server" ID="lblOrtalamaVade" /></td>
                <td align="right">Sip.Toplamı: </td>
                </tr>
                </table>
                </td>
                <td valign="middle" align="right" style="width: 120px"><asp:Label runat="server" ID="lblSiparisToplam" Font-Bold="true" /></td>
                </tr>
                </table>
                </div>
            </div>
            <div style="position: absolute; width: 400px; height: 270px; z-index: 3; left: 230px;
                top: 50px" runat="server" id="divTarih" visible="false">
                <div style="position: fixed; width: 100%; height: 100%; z-index: -1; left: 0; top: 0;
                filter: alpha(opacity=40); -moz-opacity: .40; opacity: .40; background-color: #000000" onclick="invisible()"></div>
                <table cellpadding="5" style="width: 100%; height: 100%; background-color: #ffffff; font-family: Tahoma; font-size: 12px;">
                <tr>
                <td align="center" valign="middle" colspan="2">
                    Tarih Aralığı Belirleyiniz
                </td>
                </tr>
                <tr>
                <td align="left" valign="middle" colspan="2" style="font-size: 10px;">
                    <%--<asp:CheckBox runat="server" ID="cbTariheGore" Checked="true" Text="Tarih süzmesi aktif" 
                        AutoPostBack="true" OnCheckedChanged="cbTariheGore_CheckedChanged" />--%>
                </td>
                </tr>
                <tr>
                <td align="center" valign="middle">
                    <asp:Calendar ID="Calendar1" runat="server" BackColor="White" 
                        BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" 
                        Font-Names="Verdana" Font-Size="7pt" ForeColor="Black" Height="170px" 
                        Width="170px">
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
                        Width="170px">
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
                    <asp:LinkButton runat="server" ID="lbTarihKapat" OnClick="lbTarihKapat_Click">Uygula</asp:LinkButton>
                </td>
                </tr>
                </table>
            </div>



            <div style="width: 100%; font-size: 11px; font-family: Verdana; background-color: #FFCFB2;
                border-bottom: 1px solid #EBEAE6">
                <table cellpadding="5" cellspacing="0">
                    <tr>
                        <td style="width: 700px;">
                            Yönetim Paneli Ana Sayfa
                            <%--<asp:Label runat="server" Width="150px"></asp:Label>
                            <i>Siteye bağlı kişi sayısı: <span class="hotspot" onmouseover="KisilerGoster();" onmouseout="KisilerGizle();"><asp:Label ID="lblKisiSayisi" runat="server"></asp:Label></span></i>--%>
                        </td>
                        <td style="width: 300px; text-align: right;">
                            <asp:Label runat="server" ID="Label1" Font-Bold="true"></asp:Label>
                            -
                            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Çıkış</asp:LinkButton>
                        </td>
                    </tr>
                </table>
            </div>
            <div style="background-position: center center; background-image: url('img/bg-logo.jpg');
                background-repeat: no-repeat; background-color: #FFFFFF">
                <table cellpadding="0" cellspacing="0" style="width: 1000px; font-size: 10px; font-family: Verdana;">
                    <tr>
                        <td>
                            <div style="font-size: 18px; padding: 10px 10px 10px 10px; vertical-align: middle">
                                Siparişler</div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div style="vertical-align: middle">
                                <asp:RadioButton runat="server" ID="rbTumu" Text="Tümü" 
                                    AutoPostBack="true" ForeColor="#006699" GroupName="grCariMusteri" 
                                    Checked="True" oncheckedchanged="rbTumu_CheckedChanged" />
                                <asp:Label runat="server" Width="10px"></asp:Label>
                                <asp:RadioButton runat="server" ID="rbCariHesap" Text="Cari Hesap" 
                                    AutoPostBack="true" ForeColor="#006699" GroupName="grCariMusteri" 
                                    oncheckedchanged="rbCariHesap_CheckedChanged" />
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                <asp:DropDownList runat="server" ID="ddlCariHesaplar" Width="580px" AutoPostBack="True" 
                                    Font-Bold="False" Font-Italic="False" Height="25px" ForeColor="#006699"
                                    Font-Overline="False" Font-Size="11px" Font-Strikeout="False" Font-Underline="False" 
                                    style="filter: alpha(opacity=80); -moz-opacity: .80; opacity: .80; padding: 3px 3px 3px 3px"
                                    OnSelectedIndexChanged="ddlCariHesaplar_SelectedIndexChanged"
                                    Enabled="False"></asp:DropDownList>
                                <asp:Label runat="server" Width="10px"></asp:Label>
                                <asp:RadioButton runat="server" ID="rbMusteri" Text="Üye" 
                                    AutoPostBack="true" ForeColor="#006699" GroupName="grCariMusteri" 
                                    oncheckedchanged="rbMusteri_CheckedChanged" />
                                    <asp:Label runat="server" Width="5px"></asp:Label>
                                <asp:DropDownList runat="server" ID="ddlMusteriler" Width="180px" AutoPostBack="True" 
                                    Font-Bold="False" Font-Italic="False" Height="25px" ForeColor="#006699"
                                    Font-Overline="False" Font-Size="11px" Font-Strikeout="False" Font-Underline="False" 
                                    style="filter: alpha(opacity=80); -moz-opacity: .80; opacity: .80; padding: 3px 3px 3px 3px"
                                    OnSelectedIndexChanged="ddlMusteriler_SelectedIndexChanged"
                                    Enabled="False"></asp:DropDownList>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div style="padding: 8px 3px 8px 25px; font-size: 12px">
                                Süz: <asp:Label runat="server" Width="80px"></asp:Label>
                                <asp:RadioButton runat="server" ID="rbSiparislerHepsi" Text="Hepsi" Checked="true" AutoPostBack="true" 
                                    GroupName="grOnaySuzme" OnCheckedChanged="rbSiparislerHepsi_Checked" />
                                <asp:RadioButton runat="server" ID="rbSiparislerOnaylilar" Text="Onaylanmış" AutoPostBack="true" 
                                    GroupName="grOnaySuzme" OnCheckedChanged="rbSiparislerHepsi_Checked" />
                                <asp:RadioButton runat="server" ID="rbSiparislerOnaysizlar" Text="Onaylanmamış" AutoPostBack="true" 
                                    GroupName="grOnaySuzme" OnCheckedChanged="rbSiparislerHepsi_Checked" />
                                <asp:Label runat="server" Width="150px"></asp:Label>
                                <asp:ImageButton ImageUrl="img/tarih.gif" runat="server" ID="ibTarih" OnClick="ibTarih_Click" />
                                <asp:LinkButton runat="server" ID="lbTarih" OnClick="lbTarih_Click">Tarihe Göre</asp:LinkButton>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 500px; vertical-align: top">
                            <table cellpadding="1" cellspacing="0" style="margin-left: 10px; margin-bottom: 5px">
                                <tr style="color: #D00000">
                                    <td style="width: 50px; text-align: center"><u>Sip. No</u></td>
                                    <td style="width: 140px; text-align: left"><u>Sip. Gir.</u></td>
                                    <td style="width: 260px; text-align: left"><u>C/H Açıklaması</u></td>
                                    <td style="width: 70px; text-align: center"><u>Sip. Tar.</u></td>
                                    <td style="width: 40px; text-align: center"><u>Vade</u></td>
                                    <td style="width: 110px; text-align: left"><u>Fiyat Tip</u></td>
                                    <td style="width: 100px; text-align: right"><u>Sip. Top.</u></td>
                                    <td style="width: 180px; text-align: center"></td>
                                </tr>
                            </table>
                            <asp:DataList ID="dlSiparisler" runat="server">
                                <HeaderTemplate><table cellpadding="1" cellspacing="0" style="margin-left: 10px">
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr onmouseover="Satir(this,true)" onmouseout="Satir(this,false)" runat="server" class='<%#Convert.ToBoolean(Eval("blAktarilmis"))%>'>
                                        <td style="width: 50px; text-align: center; height: 30px; vertical-align: top">
                                            <%#Eval("pkSiparisID")%>
                                            <input type="hidden" value='<%#Eval("pkSiparisID") %>' id="SiparisID" runat="server" />
                                            <input type="hidden" value='<%#Eval("SMREF") %>' id="SMREF" runat="server" />
                                            <input type="hidden" value='<%#Eval("intMusteriID") %>' id="MusteriID" runat="server" />
                                        </td>
                                        <td style="width: 140px; text-align: left; height: 30px; vertical-align: top"><%#Eval("strAd")%> <%#Eval("strSoyad")%></td>
                                        <td style="width: 260px; text-align: left; height: 30px; vertical-align: top"><%#Eval("MUSTERI")%></td>
                                        <td style="width: 70px; text-align: center; height: 30px; vertical-align: top"><span class="hotspot" onmouseover="tooltip.show('Onaylama Tarihi: <%#Convert.ToBoolean(Eval("blAktarilmis")) ? Convert.ToDateTime(Eval("dtOnaylamaTarihi")).ToString() : "<i>Sipariş henüz onaylanmamış.</i>"%>');" onmouseout="tooltip.hide();"><%#Convert.ToDateTime(Eval("dtOlusmaTarihi")).ToShortDateString()%><br /><%#Convert.ToDateTime(Eval("dtOlusmaTarihi")).ToShortTimeString()%></span></td>
                                        <td style="width: 40px; text-align: center; height: 30px; vertical-align: top"><%#Eval("VADE").ToString()%></td>
                                        <td style="width: 110px; text-align: left; height: 30px; vertical-align: top"><%#Eval("FiyatTipi")%></td>
                                        <td style="width: 100px; text-align: right; height: 30px; vertical-align: top"><%#Convert.ToDecimal(Eval("mnToplamTutar")).ToString("C3")%></td>
                                        <td style="width: 20px; text-align: center; height: 30px; vertical-align: top">
                                            <asp:ImageButton runat="server" ToolTip="İncele" ImageUrl="img/incele.gif" OnClick="ibIncele_Click" />
                                        </td>
                                        <td style="width: 20px; text-align: center; height: 30px; vertical-align: top">
                                            <%--<asp:ImageButton runat="server" ToolTip="Kopyala" ImageUrl="img/kopyala.gif" OnClick="ibKopyala_Click" />--%>
                                        </td>
                                        <td style="width: 20px; text-align: center; height: 30px; vertical-align: top">
                                            <%--<asp:ImageButton runat="server" Visible='<%#Convert.ToBoolean(Convert.ToBoolean(Eval("blAktarilmis")) == false)%>' ToolTip="Değiştir" ImageUrl="img/degistir.gif" OnClick="ibDegistir_Click" />--%>
                                        </td>
                                        <td style="width: 20px; text-align: center; height: 30px; vertical-align: top">
                                            <%--<asp:ImageButton runat="server" Visible='<%#Convert.ToBoolean(Eval("blAktarilmis"))%>' ToolTip="Onayla" ImageUrl="img/onayla.gif" OnClick="ibOnayla_Click" />--%>
                                        </td>
                                        <td style="width: 20px; text-align: center; height: 30px; vertical-align: top">
                                            <asp:ImageButton runat="server" ToolTip="Sil" ImageUrl="img/sil.gif" OnClick="ibSil_Click" />
                                        </td>
                                        <td style="width: 20px; text-align: center; height: 30px; vertical-align: top">
                                            <asp:ImageButton runat="server" ToolTip="Yazdır" ImageUrl="img/yazdir.gif" OnClientClick="Yazdir()" OnClick="ibYazdir_Click" />
                                        </td>
                                        <td style="width: 20px; text-align: center; height: 30px; vertical-align: top">
                                            <asp:ImageButton runat="server" ToolTip="Kaydet" ImageUrl="img/kaydet.gif" OnClick="ibKaydet_Click" />
                                        </td>
                                        <td style="width: 20px; text-align: center; height: 30px; vertical-align: top">
                                            
                                        </td>
                                        <td style="width: 20px; text-align: center; height: 30px; vertical-align: top">
                                            <asp:ImageButton runat="server" ToolTip="Durum" ImageUrl="img/durum.gif" />
                                        </td>
                                    </tr>
                                </ItemTemplate>
                                <FooterTemplate></table></FooterTemplate>
                            </asp:DataList>
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
                            <br /><br /><br />
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
<uc1:ucAlt ID="ucAlt1" runat="server" />
    </form>
</body>
</html>

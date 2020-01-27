<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="hesapayrinti.aspx.cs" Inherits="Sultanlar.WebUI.musteri.hesapayrinti" %>

<%@ Register src="ucAlt.ascx" tagname="ucAlt" tagprefix="uc1" %>

<%@ Register src="ucProgress.ascx" tagname="ucProgress" tagprefix="uc2" %>

<%@ Register src="ucMesajlar.ascx" tagname="ucMesajlar" tagprefix="uc3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Sultanlar : Ekstre</title>
    <script type="text/javascript">
        function invisible() {
            if (document.getElementById('divEkstreKaydet') != null) {
                window.location.href = document.getElementById('lbEkstreKaydetKapat').href;
                return false;
            }
            if (document.getElementById('divTarih') != null) {
                window.location.href = document.getElementById('lbTarihKapat').href;
                return false;
            }
            if (document.getElementById('divSatisRapor') != null) {
                window.location.href = document.getElementById('lbSatisRaporKapat').href;
                return false;
            }
            if (document.getElementById('divSatisRaporHata') != null) {
                window.location.href = document.getElementById('lbSatisRaporHataKapat').href;
                return false;
            }
            if (document.getElementById('divMesaj') != null) {
                window.location.href = document.getElementById('lbMesajKapat').href;
                return false;
            }
        }
        function Yazdir() {
            yenipen = window.open('ekstreyazdir.aspx', '_blank', 'toolbar=yes,location=no,status=no,menubar=yes,scrollbars=yes,width=1024,height=480,noresize');
            yenipen.moveTo(0, 0);
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
        #top{bottom:5px;right:5px;background:#147;padding:5px;color:#fff;font:bold 11px verdana;position:fixed;display:none;cursor:default;}
    </style>

    <script type="text/javascript" src="js/jquery.tipTip.js"></script>
    <script type="text/javascript" src="js/jquery.tipTip.minified.js"></script>
    <link rel="stylesheet" type="text/css" href="js/tipTip.css" />

</head>
<body style="margin: 0 0 0 0;background-color: #EFEEEA;">
    <form id="form1" runat="server"><div id="top" style="z-index: 50;">Yukarı Çık</div>
    <asp:ScriptManager ID="AjaxScripts" runat="server">
    </asp:ScriptManager>
    <script type="text/javascript">
        Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(function (evt, args) {
            $('#rbCariHesapAraMusteri').button();
            $('#rbCariHesapAraSattem').button();
            $('#cbVGB').button();
            $('#cbTumu').button();
            $("input[type=submit], input[type=button]").button();
        });
    </script>
    <asp:UpdateProgress ID="DivAjaxProg" runat="server">
        <ProgressTemplate>
            <uc2:ucProgress ID="ucProgress1" runat="server" />
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdatePanel runat="server" ID="upHesapAyrintilari"><ContentTemplate>

    <div id="tiptip_holder">
    <div id="tiptip_content">
    <div id="tiptip_arrow">
    <div id="tiptip_arrow_inner"></div>
    </div>
    </div>
    </div>

            <uc3:ucMesajlar ID="ucMesajlar1" runat="server" />

            <div style="position: absolute; width: 420px; height: 100px; z-index: 3; left: 290px;
                top: 150px" runat="server" id="divEkstreKaydet" visible="false">
                <div style="position: fixed; width: 100%; height: 100%; z-index: -1; left: 0; top: 0;
                filter: alpha(opacity=40); -moz-opacity: .40; opacity: .40; background-color: #000000" onclick="invisible()"></div>
                <table style="width: 100%; height: 100%; background-color: #ffffff; font-family: Tahoma; font-size: 12px;
                    border: 1px solid #D1D1D1; border-radius: 5px; padding: 5px;">
                <tr>
                <td align="center" valign="middle" style="padding-top: 15px; padding-bottom: 15px">
                    <iframe frameborder="0" src="indir.aspx" width="100%" height="120px"></iframe>
                    <asp:LinkButton runat="server" ID="lbEkstreKaydetKapat" 
                        onclick="lbEkstreKaydetKapat_Click">Kapat</asp:LinkButton>
                </td>
                </tr>
                </table>
            </div>

            <div style="position: absolute; width: 400px; height: 270px; z-index: 3; left: 300px;
                top: 150px" runat="server" id="divTarih" visible="false">
                <div style="position: fixed; width: 100%; height: 100%; z-index: -1; left: 0; top: 0;
                filter: alpha(opacity=40); -moz-opacity: .40; opacity: .40; background-color: #000000" onclick="invisible()"></div>
                <table cellpadding="5" style="width: 100%; height: 100%; background-color: #ffffff; font-family: Tahoma; font-size: 12px;
                    border: 1px solid #D1D1D1; border-radius: 5px; padding: 5px;">
                <tr>
                <td align="center" valign="middle" colspan="2">
                    <span style="color: #C00000">Tarih Aralığı Belirleyiniz</span>
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

            <div style="position: absolute; width: 420px; height: 100px; z-index: 3; left: 290px;
                top: 150px" runat="server" id="divSatisRaporHata" visible="false">
                <div style="position: fixed; width: 100%; height: 100%; z-index: -1; left: 0; top: 0;
                filter: alpha(opacity=40); -moz-opacity: .40; opacity: .40; background-color: #000000" onclick="invisible()"></div>
                <table style="width: 100%; height: 100%; background-color: #ffffff; font-family: Tahoma; font-size: 12px;
                    border: 1px solid #D1D1D1; border-radius: 5px; padding: 5px;">
                <tr>
                <td align="center" valign="middle" style="padding-top: 15px; padding-bottom: 15px">
                    Bu içeriği görmeye yetkiniz yoktur.
                    <br /><br />
                    <asp:LinkButton runat="server" ID="lbSatisRaporHataKapat" 
                        onclick="lbSatisRaporHataKapat_Click">Kapat</asp:LinkButton>
                </td>
                </tr>
                </table>
            </div>

            <div style="position: absolute; width: 920px; z-index: 3; left: 40px;
                top: 28px" runat="server" id="divSatisRapor" visible="false">
                <div style="position: fixed; width: 100%; height: 100%; z-index: -1; left: 0; top: 0;
                filter: alpha(opacity=40); -moz-opacity: .40; opacity: .40; background-color: #000000" onclick="invisible()"></div>
                <table style="width: 100%; height: 100%; background-color: #ffffff; font-family: Tahoma; font-size: 10px;
                    border: 1px solid #D1D1D1; border-radius: 5px; padding: 5px;">
                <tr>
                <td align="center" valign="top" style="padding-top: 15px; padding-bottom: 15px">
                    <span style="color: #b45c0e; font-weight: bold; font-size: 12px;">
                        <asp:Label runat="server" ID="lblFaturaNo" Text=" Nolu Fatura İçeriği"></asp:Label>
                    </span>
                    <br /><br />
                    <div style="overflow: auto; width:920px">
                    <asp:DataList ID="DataList2" runat="server">
                    <HeaderTemplate>
                        <table cellpadding="1" cellspacing="0">
                        <tr style="color: #D00000;">
                            <td style="width: 70px; text-align: center; height: 20px; border-bottom: 1px solid #CCCCCC">Fat.Tar.</td>
                            <td style="width: 50px; text-align: center; height: 20px; border-bottom: 1px solid #CCCCCC">Tür</td>
                            <td style="width: 130px; text-align: center; height: 20px; border-bottom: 1px solid #CCCCCC">Tedarikçi</td>
                            <td style="width: 200px; text-align: center; height: 20px; border-bottom: 1px solid #CCCCCC">Ürün</td>
                            <td style="width: 30px; text-align: center; height: 20px; border-bottom: 1px solid #CCCCCC">F.Tip</td>
                            <td style="width: 30px; text-align: center; height: 20px; border-bottom: 1px solid #CCCCCC">Adet</td>
                            <td style="width: 100px; text-align: center; height: 20px; border-bottom: 1px solid #CCCCCC">Brüt</td>
                            <td style="width: 100px; text-align: center; height: 20px; border-bottom: 1px solid #CCCCCC">İskonto</td>
                            <td style="width: 100px; text-align: center; height: 20px; border-bottom: 1px solid #CCCCCC">Net</td>
                            <td style="width: 100px; text-align: center; height: 20px; border-bottom: 1px solid #CCCCCC">Net+KDV</td>
                        </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr onmouseover="Satir(this,true)" onmouseout="Satir(this,false)">
                            <td style="width: 70px; height: 25px; text-align: center"><%#Convert.ToDateTime(Eval("[FAT TAR]")).ToShortDateString()%></td>
                            <td style="width: 50px; height: 25px; text-align: center"><%#Eval("[TUR ACK]")%></td>
                            <td style="width: 130px; height: 25px; text-align: center"><%#Eval("[GRUP]")%></td>
                            <td style="width: 200px; height: 25px; text-align: left"><%#Eval("[MALZEME]")%></td>
                            <td style="width: 30px; height: 25px; text-align: center"><%#Eval("[F TUR]")%></td>
                            <td style="width: 30px; height: 25px; text-align: center"><%#Eval("[AD T]")%></td>
                            <td style="width: 100px; height: 25px; text-align: right"><%#Convert.ToDecimal(Eval("[BRUT T]")).ToString("C2")%></td>
                            <td style="width: 100px; height: 25px; text-align: right"><%#Convert.ToDecimal(Eval("[ISK T]")).ToString("C2")%></td>
                            <td style="width: 100px; height: 25px; text-align: right"><%#Convert.ToDecimal(Eval("[NET T]")).ToString("C2")%></td>
                            <td style="width: 100px; height: 25px; text-align: right"><%#Convert.ToDecimal(Eval("[NET+KDV T]")).ToString("C2")%></td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate></table></FooterTemplate>
                </asp:DataList>
                </div>
                <table cellpadding="1" cellspacing="0" runat="server" id="tblToplamlar" visible="false">
                        <tr style="color: #000000; font-weight: bold; padding-bottom: 10px">
                            <td style="width: 70px; height: 25px; text-align: center"></td>
                            <td style="width: 50px; height: 25px; text-align: center"></td>
                            <td style="width: 130px; height: 25px; text-align: center"></td>
                            <td style="width: 200px; height: 25px; text-align: left"></td>
                            <td style="width: 30px; height: 25px; text-align: center"></td>
                            <td style="width: 30px; text-align: center; border-top: 1px solid #CCCCCC">Toplam: </td>
                            <td style="width: 100px; text-align: right; border-top: 1px solid #CCCCCC"><asp:Label runat="server" ID="lblToplamBrut"></asp:Label></td>
                            <td style="width: 100px; text-align: right; border-top: 1px solid #CCCCCC"><asp:Label runat="server" ID="lblToplamIskonto"></asp:Label></td>
                            <td style="width: 100px; text-align: right; border-top: 1px solid #CCCCCC"><asp:Label runat="server" ID="lblToplamNet"></asp:Label></td>
                            <td style="width: 100px; text-align: right; border-top: 1px solid #CCCCCC"><asp:Label runat="server" ID="lblToplamNETKDV"></asp:Label></td>
                        </tr>
                </table>
                <br />
                <div style="font-size: 12px">
                    <i>Satır Sayısı: <asp:Label runat="server" ID="lblRaporSayisi">0</asp:Label></i>
                    <br /><br />
                    <asp:LinkButton runat="server" ID="lbSatisRaporKapat" 
                        onclick="lbSatisRaporKapat_Click">Kapat</asp:LinkButton>
                </div>
                </td>
                </tr>
                </table>
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
        <input type="button" value="Raporlar" disabled="disabled" /> 
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
            <td>
                <div class="Baslik">
                <table cellpadding="0" cellspacing="0"><tr>
                <td><img src="img/ic_ekstre.png" /></td>
                <td>Ekstre<asp:Label runat="server" Width="40px"></asp:Label></td>
                <td><img src="img/ic_satis.png" /></td>
                <td><a href="satisrapor.aspx" style="color: #A0A0A0">Satış Raporu</a><asp:Label runat="server" Width="40px"></asp:Label></td>
                <td><asp:Image runat="server" ID="imgBorcAlacak" ImageUrl="img/ic_borcalacak.png" Visible="false" /></td>
                <td><asp:HyperLink runat="server" ID="hlBorcAlacak" NavigateUrl="borcalacakrapor.aspx" Visible="false" style="color: #A0A0A0">Borç Alacak Raporu</asp:HyperLink><asp:Label runat="server" Width="40px"></asp:Label></td>
                <td><asp:Image runat="server" ID="imgSatisHedef" ImageUrl="img/ic_satishedef.png" Visible="false" /></td>
                <td><asp:HyperLink runat="server" ID="hlSatisHedef" NavigateUrl="satishedef.aspx" Visible="false" style="color: #A0A0A0">Satış Hedef Raporu</asp:HyperLink><asp:Label runat="server" Width="40px"></asp:Label></td>
                <td><asp:Image runat="server" ID="imgStok" ImageUrl="img/ic_satis.png" Visible="false" /></td>
                <td><asp:HyperLink runat="server" ID="hlStok" NavigateUrl="stok.aspx" Visible="false" style="color: #A0A0A0">Stok Raporu</asp:HyperLink><asp:Label runat="server" Width="40px"></asp:Label></td>
                </tr></table>
                </div>
                <div style="width: 1000px; text-align: right;">
                    <asp:ImageButton runat="server" ID="ibYazdir" ImageUrl="img/yazdir.gif" OnClick="ibYazdir_Click" OnClientClick="Yazdir()" />
                    <asp:Label runat="server" Width="5px"></asp:Label>
                    <asp:ImageButton ID="ibKaydet" runat="server" ToolTip="Kaydet" ImageUrl="img/kaydet.gif" OnClick="ibKaydet_Click" />
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <div style="padding: 10px 10px 10px 25px; font-size: 12px" runat="server" id="divCariHesaplar">
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
                <asp:Label runat="server" Width="20px"></asp:Label>
                <asp:DropDownList ID="ddlCariHesaplar" runat="server" Width="490px" AutoPostBack="True" 
                    Font-Bold="False" Font-Italic="False" Height="25px"
                    Font-Overline="False" Font-Size="11px" Font-Strikeout="False" 
                    Font-Underline="False" style="filter: alpha(opacity=80); -moz-opacity: .80; opacity: .80; padding: 3px 3px 3px 3px;border:1px solid #CCCCCC;background:#ededed;" 
                    onselectedindexchanged="ddlCariHesaplar_SelectedIndexChanged" 
                    ForeColor="#006699">
                </asp:DropDownList>
                </td>
                <td valign="middle">
                <asp:Label runat="server" Width="10px"></asp:Label>
                <asp:CheckBox runat="server" ID="cbVGB" AutoPostBack="true" Text="VGB" OnCheckedChanged="cbVGB_CheckedChanged" title="Sadece VGBliler" class="kucukbilgiGosterSade" />
                </td>
                <td valign="middle">
                <asp:Label runat="server" Width="10px"></asp:Label>
                <asp:ImageButton Visible="false" ImageUrl="img/ic_tarih.png" runat="server" ID="ibTarih" OnClick="ibTarih_Click" ToolTip="Tarihe Göre" class="kucukbilgiGoster" />
                </td>
                <td valign="middle">
                <asp:Label runat="server" Width="10px"></asp:Label>
                <asp:CheckBox Visible="false" runat="server" ID="cbTumu" AutoPostBack="true" Checked="false" Text="İşyeri tümü" OnCheckedChanged="cbTumu_CheckedChanged" title="Bütün kayıtları getir" class="kucukbilgiGosterSade" />
                <asp:DropDownList ID="ddlIsyerleri" runat="server" AutoPostBack="True" 
                            Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Size="11px" Height="25px"
                            Font-Strikeout="False" Font-Underline="False" ToolTip="Önceki Yılları Kısıtlama" class="kucukbilgiGosterSade"
                            Width="120px" ForeColor="#006699" style="padding: 3px 3px 3px 3px;border:1px solid #CCCCCC;background:#ededed;"
                            onselectedindexchanged="ddlIsyerleri_SelectedIndexChanged">
                <asp:ListItem Text="Tamamı" Value="0"></asp:ListItem>
                <asp:ListItem Text="1. Aydan itibaren" Value="01" Selected="True"></asp:ListItem>
                <asp:ListItem Text="2. Aydan itibaren" Value="02"></asp:ListItem>
                <asp:ListItem Text="3. Aydan itibaren" Value="03"></asp:ListItem>
                <asp:ListItem Text="4. Aydan itibaren" Value="04"></asp:ListItem>
                <asp:ListItem Text="5. Aydan itibaren" Value="05"></asp:ListItem>
                <asp:ListItem Text="6. Aydan itibaren" Value="06"></asp:ListItem>
                <asp:ListItem Text="7. Aydan itibaren" Value="07"></asp:ListItem>
                <asp:ListItem Text="8. Aydan itibaren" Value="08"></asp:ListItem>
                <asp:ListItem Text="9. Aydan itibaren" Value="09"></asp:ListItem>
                <asp:ListItem Text="10. Aydan itibaren" Value="10"></asp:ListItem>
                <asp:ListItem Text="11. Aydan itibaren" Value="11"></asp:ListItem>
                <asp:ListItem Text="12. Aydan itibaren" Value="12"></asp:ListItem>
                </asp:DropDownList>
                </td>
                </tr>
                </table>
                </div>
            </td>
        </tr>
        <tr>
            <td valign="top" style="height: 100%">
                
                <asp:DataList ID="DataList1" runat="server" OnItemDataBound="DataList1_DataBound">

                    <HeaderTemplate>
                        <table cellpadding="1" cellspacing="0">
                        <tr style="color: #D00000;">
                            <td style="width: 80px; text-align: center; height: 20px; border-bottom: 1px solid #CCCCCC">Tarih</td>
                            <td style="width: 70px; text-align: center; height: 20px; border-bottom: 1px solid #CCCCCC">Fiş No</td>
                            <td style="width: 75px; text-align: center; height: 20px; border-bottom: 1px solid #CCCCCC"><span runat="server" visible='<%#Convert.ToBoolean(((Sultanlar.DatabaseObject.Internet.Musteriler)Session["Musteri"]).tintUyeTipiID != 1)%>'>Vade</span><span style="color: #FFFFFF">.</span></td>
                            <td style="width: 105px; text-align: center; height: 20px; border-bottom: 1px solid #CCCCCC">Fiş Türü</td>
                            <td style="width: 300px; text-align: center; height: 20px; border-bottom: 1px solid #CCCCCC">Açıklama</td>
                            <%--<td style="width: 130px; text-align: center; height: 20px; border-bottom: 1px solid #CCCCCC">Sat.Tem.</td>--%>
                            <td style="width: 110px; text-align: center; height: 20px; border-bottom: 1px solid #CCCCCC">Borç</td>
                            <td style="width: 110px; text-align: center; height: 20px; border-bottom: 1px solid #CCCCCC">Alacak</td>
                            <td style="width: 110px; text-align: center; height: 20px; border-bottom: 1px solid #CCCCCC">Bakiye</td>
                            <%--<td style="width: 90px; text-align: center; height: 20px; border-bottom: 1px solid #CCCCCC">VGB</td>--%>
                        </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr onmouseover="Satir(this,true)" onmouseout="Satir(this,false)">
                            <td style="width: 80px; height: 25px; text-align: center"><%#Convert.ToDateTime(Eval("[FIS TAR]")).ToShortDateString()%></td>
                            <td style="width: 70px; height: 25px; text-align: center"><asp:LinkButton runat="server" CommandArgument='<%#Eval("[FIS NO]")%>' Text='<%#Eval("[MATBU_NO]")%>' OnClick="lbSatisRapor_Click" Visible='<%#(Eval("[TUR]").ToString() == "8" || Eval("[TUR]").ToString() == "3")%>'></asp:LinkButton><asp:Label runat="server" Text='<%#Eval("[MATBU_NO]")%>' Visible='<%#(Eval("[TUR]").ToString() != "8" && Eval("[TUR]").ToString() != "3")%>'></asp:Label></td>
                            <td style="width: 75px; height: 25px; text-align: center"><span runat="server" visible='<%#Convert.ToBoolean(((Sultanlar.DatabaseObject.Internet.Musteriler)Session["Musteri"]).tintUyeTipiID != 1)%>'><%#Convert.ToDateTime(Eval("[FIS VD]")).ToShortDateString()%></span></td>
                            <td style="width: 105px; height: 25px; text-align: center"><%#Eval("[FIS TUR]")%></td>
                            <td style="width: 300px; height: 25px; text-align: center"><%#Eval("[FIS ACIKLAMA]")%></td>
                            <%--<td style="width: 130px; height: 25px; text-align: center"><%#Eval("[SATICI]")%></td>--%>
                            <td style="width: 110px; height: 25px; text-align: right"><%#Convert.ToDecimal(Eval("BORC")).ToString("C2")%></td>
                            <td style="width: 110px; height: 25px; text-align: right"><%#Convert.ToDecimal(Eval("ALACAK")).ToString("C2")%></td>
                            <td style="width: 110px; height: 25px; text-align: right"><%#Convert.ToDecimal(Eval("BAKIYE")).ToString("C2")%></td>
                            <%--<td style="width: 90px; height: 25px; text-align: right"><%#Convert.ToDecimal(Eval("VGB")).ToString("C2")%></td>--%>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate></table></FooterTemplate>

                </asp:DataList>
                <table cellpadding="1" cellspacing="0" runat="server" id="tblToplam" visible="false">
                        <tr style="color: #000000; font-weight: bold; padding-bottom: 10px">
                            <td style="width: 80px; text-align: center; border-top: 1px solid #CCCCCC"><span style="color: #ffffff">-</span></td>
                            <td style="width: 70px; text-align: right; border-top: 1px solid #CCCCCC"><asp:Label runat="server" Visible='<%# ((Sultanlar.DatabaseObject.Internet.Musteriler)Session["Musteri"]).tintUyeTipiID != 1 %>' Text="Ort.Vade: "></asp:Label></td>
                            <td style="width: 75px; text-align: center; border-top: 1px solid #CCCCCC"><asp:Label runat="server" ID="lblToplamOrtVade" Visible='<%# ((Sultanlar.DatabaseObject.Internet.Musteriler)Session["Musteri"]).tintUyeTipiID != 1 %>'></asp:Label></td>
                            <td style="width: 105px; text-align: center; border-top: 1px solid #CCCCCC"><span style="color: #ffffff">-</span></td>
                            <td style="width: 300px; text-align: center; border-top: 1px solid #CCCCCC"><span style="color: #ffffff">-</span></td>
                            <%--<td style="width: 60px; text-align: center; border-top: 1px solid #CCCCCC">Toplam: </td>--%>
                            <td style="width: 110px; text-align: right; border-top: 1px solid #CCCCCC"><asp:Label runat="server" ID="lblToplamBorc"></asp:Label></td>
                            <td style="width: 110px; text-align: right; border-top: 1px solid #CCCCCC"><asp:Label runat="server" ID="lblToplamAlacak"></asp:Label></td>
                            <td style="width: 110px; text-align: right; border-top: 1px solid #CCCCCC"><asp:Label runat="server" ID="lblToplamBakiye"></asp:Label></td>
                            <%--<td style="width: 90px; text-align: right; border-top: 1px solid #CCCCCC"><asp:Label runat="server" ID="lblToplamVGB"></asp:Label></td>--%>
                        </tr>
                </table>
                <br />
                <asp:Label runat="server" ID="lblEkstreYok" Visible="false" Text="- Listenecek satır bulunamadı. -" Font-Italic="true" style="padding-left: 200px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <table cellpadding="0" cellspacing="0" style="width: 950px; margin-left: 10px">
                <tr style="padding-top: 15px">
                <td align="left"><asp:ImageButton runat="server" ID="ibOnceki" 
                        ImageUrl="img/sol_ok.gif" onclick="ibOnceki_Click" />
                        <asp:Label runat="server" Width="20px"></asp:Label>
                        <asp:ImageButton runat="server" ID="ibIlk" 
                        ImageUrl="img/sol_2ok.gif" onclick="ibIlk_Click" /></td>
                <td align="center">
                <asp:Label runat="server" ID="lblEkstreKacinci">0</asp:Label>
                /
                <asp:Label runat="server" ID="lblEkstreSayisi">0</asp:Label></td>
                <td>
                    <asp:DropDownList runat="server" ID="ddlSayfa" AutoPostBack="true" Width="60px" ToolTip="Sayfalar" class="kucukbilgiGosterSade"
                        Font-Bold="False" Font-Italic="False" Height="25px"
                        Font-Overline="False" Font-Size="11px" Font-Strikeout="False" 
                        Font-Underline="False" style="filter: alpha(opacity=80); -moz-opacity: .80; opacity: .80; padding: 3px 3px 3px 3px;border:1px solid #CCCCCC;background:#ededed;" 
                        onselectedindexchanged="ddlSayfa_SelectedIndexChanged" 
                        ForeColor="#006699"></asp:DropDownList>
                </td>
                <td align="right">
                        <asp:ImageButton runat="server" ID="ibSon" 
                        ImageUrl="img/sag_2ok.gif" onclick="ibSon_Click" />
                        <asp:Label runat="server" Width="20px"></asp:Label>
                        <asp:ImageButton runat="server" ID="ibSonraki" 
                        ImageUrl="img/sag_ok.gif" onclick="ibSonraki_Click" /></td>
                </tr>
                </table>
            </td>
        </tr>
    </table><br /></div>
    </ContentTemplate></asp:UpdatePanel>
<uc1:ucAlt ID="ucAlt1" runat="server" />
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="iade.aspx.cs" Inherits="Sultanlar.WebUI.musteri.iade" %>

<%@ Register src="ucUrunAyrinti.ascx" tagname="ucUrunAyrinti" tagprefix="uc2" %>

<%@ Register src="ucAlt.ascx" tagname="ucAlt" tagprefix="uc1" %>

<%@ Register src="ucProgress.ascx" tagname="ucProgress" tagprefix="uc3" %>

<%@ Register src="ucMesajlar.ascx" tagname="ucMesajlar" tagprefix="uc4" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Sultanlar : İade Ürün Seçimi</title>
    <style type="text/css">
        .alfabetikTDss
        {
            text-align: center;
            width: 30px;
            height: 30px;
        }
        .alfabetikTDss2
        {
            width: 30px;
            height: 30px;
            background-color: #EE7A0B;
        }
    </style>
    <link rel="stylesheet" type="text/css" href="StyleSheet.css" />        <script type="text/javascript" src="js/jquery-1.2.6.pack.js"></script>
    <script type="text/javascript" src="js/jquery-1.8.3.js"></script>
    <script type="text/javascript" src="js/jquery-ui.js"></script>
    <link rel="stylesheet" href="js/jquery-ui.css" />
    <script type="text/javascript" src="js/scripts.js"></script>

    <script type="text/javascript" src="js/tooltip.js"></script>

    <script type="text/javascript">
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

        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;

            return true;
        }

        function bas(buttonid) {
//            window.location.href = document.getElementById(buttonid).href;
//            return false;
        }

        function invisible() {
            if (document.getElementById('divTedarikci') != null) {
                window.location.href = document.getElementById('lbTedarikciKapat').href;
                return false;
            }

            if (document.getElementById('ucKampanyalar1_divTedarikci') != null) {
                window.location.href = document.getElementById('ucKampanyalar1_lbTedarikciKapat').href;
                return false;
            }

            if (document.getElementById('ucKampanyalar1_divKategori') != null) {
                window.location.href = document.getElementById('ucKampanyalar1_lbKategoriKapat').href;
                return false;
            }

            if (document.getElementById('divKategori') != null) {
                window.location.href = document.getElementById('lbKategoriKapat').href;
                return false;
            }

            if (document.getElementById('divSepet') != null) {
                window.location.href = document.getElementById('lbSepetKapat').href;
                return false;
            }

            if (document.getElementById('divUrunAyrinti') != null) {
                window.location.href = document.getElementById('lbUrunAyrintiKapat').href;
                return false;
            }

            if (document.getElementById('divMesaj') != null) {
                window.location.href = document.getElementById('lbMesajKapat').href;
                return false;
            }
        }

        function AramaSecili() {
            if (document.getElementById('rbBarkodaGore').checked)
                document.getElementById('txtArama').focus();
        }
    </script>

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
<body style="margin: 0 0 0 0; background-color: #FFFFFF">
    <form id="form1" runat="server"><div id="top" style="z-index: 50;">Yukarı Çık</div>
    <asp:ScriptManager ID="AjaxScripts" runat="server">
    </asp:ScriptManager>
    <script type="text/javascript">
        Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(function (evt, args) {
            $('#rbMalzemeler').button();
            $('#rbIcinde').button();
            $('#rbBaslangicaGore').button();
            $('#rbBarkodaGore').button();
            $('#rbMalzemeKodunaGore').button();
            $('#rbUrtKodunaGore').button();
            $('#cbBarkodHemenAra').button();
            $('#cbBarkodHemenEkle').button();
            $('#cbYeniUrunler').button();
            $('#rbSiralamaAzalan').button();
            $('#rbSiralamaArtan').button();
            $('#rbResimDuzeni').button();
            $('#rbListeDuzeni').button();
            $('#rbTariheGoreSiralama').button();
            $('#rbABCSiralama').button();
            $('#rbFYTSiralama').button();
            $('#rblTedarikciler').buttonset().find('label').width(300);
            $('#rblKategoriler').buttonset().find('label').width(300);
            $("input[type=submit], input[type=button]").button();
        });
    </script>
    <asp:UpdateProgress ID="DivAjaxProg" runat="server">
        <ProgressTemplate>
            <uc3:ucProgress ID="ucProgress1" runat="server" />
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdatePanel ID="DivAjax" runat="server">
        <ContentTemplate>

            <uc4:ucMesajlar ID="ucMesajlar1" runat="server" />

            <div style="position: absolute; width: 300px; height: 500px; z-index: 3; left: 240px;
                top: 285px;" runat="server" id="divKategori" visible="false">
                <table style="border: 1px solid #000000; width: 300px; height: 500px; font-family: Tahoma;
                    font-size: 10px; background-color: #EEEEEE; border: 1px solid #D1D1D1; border-radius: 5px; padding: 5px;">
                    <tr>
                        <td style="border-bottom: 1px solid #CCCCCC; width: 300px; height: 20px; padding-left: 5px;
                            padding-right: 5px" valign="middle">
                            <table style="width: 100%">
                                <tr>
                                    <td align="left">
                                        Kategoriler (<asp:Label runat="server" ID="lblKategoriHarf"></asp:Label>)
                                    </td>
                                    <td align="right">
                                        <asp:LinkButton Font-Bold="true" Text="X" runat="server" ID="lbKategoriKapat" OnClick="lbKategoriKapat_Click"
                                            Font-Underline="False" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 300px; height: 480px; padding: 10px"
                            valign="top">
                            <asp:RadioButtonList ID="rblKategoriler" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rblKategoriler_SelectedIndexChanged">
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                </table>
            </div>

            <div style="position: fixed; width: 100%; height: 100%; z-index: 1; left: 0; top: 0;
                filter: alpha(opacity=60); -moz-opacity: .60; opacity: .60; background-color: #000000"
                runat="server" id="divTedarikciKategoriDis" visible="false" onclick="invisible()">
            </div>

            <div style="position: absolute; width: 300px; height: 500px; z-index: 2; left: 560px;
                top: 220px;" runat="server" id="divTedarikci" visible="false">
                <table style="border: 1px solid #000000; width: 300px; height: 500px; font-family: Tahoma;
                    font-size: 10px; background-color: #EEEEEE; border: 1px solid #D1D1D1; border-radius: 5px; padding: 5px;">
                    <tr>
                        <td style="border-bottom: 1px solid #CCCCCC; width: 300px; height: 20px; padding-left: 5px;
                            padding-right: 5px" valign="middle">
                            <table style="width: 100%">
                                <tr>
                                    <td align="left">
                                        Tedarikçiler (<asp:Label runat="server" ID="lblTedarikciHarf"></asp:Label>)
                                    </td>
                                    <td align="right">
                                        <asp:LinkButton Font-Bold="true" Text="X" runat="server" ID="lbTedarikciKapat" OnClick="lbTedarikciKapat_Click"
                                            Font-Underline="False" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 300px; height: 480px; padding: 10px"
                            valign="top">
                            <asp:RadioButtonList ID="rblTedarikciler" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rblTedarikciler_SelectedIndexChanged">
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                </table>
            </div>

            <div runat="server" id="divSepetBuyut" style="position: absolute; width: 60px; height: 50px; 
                z-index: 0; left: 40px; top: 240px; padding: 2px; font-family: Tahoma; font-size: 10px">
                 <table cellpadding="0" cellspacing="0" style="width:100%">
                 <tr>
                 <td></td>
                 <td align="left">
                    <asp:ImageButton ImageUrl="img/sepet.png" runat="server" ID="ibSepetBuyut" OnClick="ibSepetBuyut_Click" />
                    <%--<asp:LinkButton ID="lbSepetBuyut" runat="server" OnClick="lbSepetBuyut_Click" Font-Underline="false">Sipariş Detayları</asp:LinkButton>--%>
                 </td>
                 </tr>
                 </table>
            </div>

            <div style="position: absolute; width: 300px; height: 100px; z-index: 4; left: 320px;
                top: 231px;" runat="server" id="divAktarim" visible="false">
                <table style="width: 100%; height: 100%; background-color: #ffffff; font-family: Tahoma; font-size: 12px;
                    border: 1px solid #D1D1D1; border-radius: 5px; padding: 5px;">
                <tr>
                <td align="center" valign="middle">
                    Girilen ürünleri sepete aktarmadınız. Devam etmek istiyor musunuz?<br /><br />
                    <asp:Button runat="server" ID="btnAktarimDevam" Text="Evet" Width="50px" OnClick="btnAktarimDevam_Click"
                        BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" ForeColor="#6D8AAA" />
                    <asp:Button runat="server" ID="btnAktarimDur" Text="Hayır" Width="50px" OnClick="btnAktarimDur_Click" 
                        BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" ForeColor="#6D8AAA" />
                </td>
                </tr>
                </table>
            </div>

            <div style="position: absolute; width: 300px; height: 100px; z-index: 5; left: 320px;
                top: 231px;" runat="server" id="divSiparisSepettenSil" visible="false">
            <div style="position: fixed; width: 100%; height: 100%; z-index: -1; left: 0; top: 0;
                filter: alpha(opacity=60); -moz-opacity: .60; opacity: .60; background-color: #000000">
            </div>
                <table style="width: 100%; height: 100%; background-color: #ffffff; font-family: Tahoma; font-size: 12px;
                    border: 1px solid #D1D1D1; border-radius: 5px; padding: 5px;">
                <tr>
                <td align="center" valign="middle">
                    <%--Silinen kampanyanın bütün ürünleri silinecek.--%>Ürünler silinecek. Devam etmek istiyor musunuz?<br /><br />
                    <asp:Button runat="server" ID="btnSiparisSepettenSilDevam" Text="Evet" Width="50px" OnClick="btnSiparisSepettenSilDevam_Click" 
                        BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" ForeColor="#6D8AAA" />
                    <asp:Button runat="server" ID="btnSiparisSepettenSilDur" Text="Hayır" Width="50px" OnClick="btnSiparisSepettenSilDur_Click" 
                        BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" ForeColor="#6D8AAA"/>
                </td>
                </tr>
                </table>
            </div>

            <div style="position: absolute; width: 300px; height: 100px; z-index: 5; left: 320px;
                top: 231px;" runat="server" id="divSepetiBosalt" visible="false">
            <div style="position: fixed; width: 100%; height: 100%; z-index: -1; left: 0; top: 0;
                filter: alpha(opacity=60); -moz-opacity: .60; opacity: .60; background-color: #000000">
            </div>
                <table style="width: 100%; height: 100%; background-color: #ffffff; font-family: Tahoma; font-size: 12px;
                    border: 1px solid #D1D1D1; border-radius: 5px; padding: 5px;">
                <tr>
                <td align="center" valign="middle">
                    Listedeki bütün ürünler silinecek, devam etmek istiyor musunuz?<br /><br />
                    <asp:Button runat="server" ID="btnSepetiBosaltEvet" Text="Evet" Width="50px" OnClick="btnSepetiBosaltEvet_Click" 
                        BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" ForeColor="#6D8AAA" />
                    <asp:Button runat="server" ID="btnSepetiBosaltHayir" Text="Hayır" Width="50px" OnClick="btnSepetiBosaltHayir_Click" 
                        BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" ForeColor="#6D8AAA"/>
                </td>
                </tr>
                </table>
            </div>

            <div style="position: absolute; width: 300px; height: 100px; z-index: 5; left: 320px;
                top: 231px;" runat="server" id="divSiparisIptal" visible="false">
            <div style="position: fixed; width: 100%; height: 100%; z-index: -1; left: 0; top: 0;
                filter: alpha(opacity=60); -moz-opacity: .60; opacity: .60; background-color: #000000">
            </div>
                <table style="width: 100%; height: 100%; background-color: #ffffff; font-family: Tahoma; font-size: 12px;
                    border: 1px solid #D1D1D1; border-radius: 5px; padding: 5px;">
                <tr>
                <td align="center" valign="middle">
                    Liste iptal edilecek, devam etmek istiyor musunuz?<br /><br />
                    <asp:Button runat="server" ID="btnSiparisIptalEvet" Text="Evet" Width="50px" OnClick="btnSiparisIptalEvet_Click" 
                        BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" ForeColor="#6D8AAA" />
                    <asp:Button runat="server" ID="btnSiparisIptalHayir" Text="Hayır" Width="50px" OnClick="btnSiparisIptalHayir_Click" 
                        BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" ForeColor="#6D8AAA"/>
                </td>
                </tr>
                </table>
            </div>

            <div style="position: absolute; width: 300px; height: 100px; z-index: 4; left: 320px;
                top: 231px;" runat="server" id="divSiparisKalemFazla" visible="false">
                <div style="position: fixed; width: 100%; height: 100%; z-index: -1; left: 0; top: 0;
                filter: alpha(opacity=40); -moz-opacity: .40; opacity: .40; background-color: #000000" onclick="invisible()"></div>
                <table style="width: 100%; height: 100%; background-color: #ffffff; font-family: Tahoma; font-size: 12px;
                    border: 1px solid #D1D1D1; border-radius: 5px; padding: 5px;">
                <tr>
                <td align="center" valign="middle">
                    Bir iade listesine en fazla 100 kalem ürün girebilirsiniz. Ürün eklemek için yeni bir iade talebi açıp devam edebilirsiniz.<br /><br />
                    <asp:Button runat="server" ID="btnSiparisKalemFazlaKapat" Text="Evet" Width="50px" OnClick="btnSiparisKalemFazlaKapat_Click"
                        BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" ForeColor="#6D8AAA" />
                </td>
                </tr>
                </table>
            </div>

            <div style="position: absolute; width: 800px; z-index: 3; left: 80px;
                top: 100px;" runat="server" id="divSepet" visible="false">
            <div style="width: 100%; height: 100%; background-color: #ffffff; border: 1px solid #D1D1D1; border-radius: 5px; padding: 5px; margin-bottom: 20px;">
                <table cellpadding="10" cellspacing="0" style="font-family: Tahoma; width: 800px; height: 40px">
                <tr>
                <td valign="middle">
                <asp:Button Width="110px" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Font-Size="10px" ID="btnSiparisiIptalEt" runat="server" Text="İadeyi İptal Et" OnClick="btnSiparisiIptalEt_Click" ForeColor="Red" />
                <asp:Label runat="server" Width="1px"></asp:Label>
                <asp:Button Width="150px" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Font-Size="10px" ID="btnSepetiBosalt" runat="server" Text="İade Sepetini Boşalt" OnClick="btnSepetiBosalt_Click" ForeColor="Red" />
                <asp:Label runat="server" Width="1px"></asp:Label>
                <asp:Button Width="150px" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Font-Size="10px" ID="btnSepetKapat" runat="server" Text="İadeye Devam Et" OnClick="lbSepetKapat_Click" />
                </td>
                <td valign="middle" align="center" style="font-size:12px;">
                </td>
                <td valign="middle" align="right"><asp:LinkButton runat="server" ID="lbSepetKapat" OnClick="lbSepetKapat_Click" Font-Underline="False" Font-Bold="true" /></td>
                </tr>
                </table>
                <table width="780px" cellpadding="10" cellspacing="0" style="font-family: Tahoma; font-size: 12px; height: 40px">
                    <tr style="color: #C00000">
                        <td style="width: 390px; padding-left: 70px">
                            Ürün
                        </td>
                        <td align="center" style="width: 290px;">
                            Adet
                        </td>
                        <td style="width: 90px">
                                    
                        </td>
                    </tr>
                </table>
                <div style="width:800px; min-height: 300px">
                <asp:Repeater ID="Repeater1" runat="server" onitemcommand="Repeater1_ItemCommand">
                    <HeaderTemplate>
                        <table width="780px" cellpadding="10" cellspacing="0" style="font-family: Tahoma; font-size: 11px">
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr style="background-color: #E8E8E8">
                            <td style="width: 390px">
                                <input type="hidden" value='<%#Eval("IadeDetayID") %>' id="IadeDetayID" runat="server" />
                                <input type="hidden" value='<%#Eval("UrunID") %>' id="UrunID" runat="server" />
                                &nbsp;<%#Eval("Ad") %></td>
                            <td align="center" style="width: 290px;">
                                <asp:Button ID="Button1" Width="25px" Height="25px" runat="server" Text="+" CommandName="Arttir" BorderColor="#FFFFFF" BorderStyle="Solid" BorderWidth="1px" ForeColor="#FFFFFF" Font-Size="12px" Font-Bold="true" BackColor="SlateGray"></asp:Button>
                                <input id="Miktar" type="text" runat="server" value='<%#Eval("Miktar")%>' onkeypress="return isNumberKey(event)"
                                    style="width: 35px; color: #006699; border: 1px solid #A3B5C9; text-align: right" />
                                <asp:Button ID="Button2" Width="25px" Height="25px" runat="server" Text="-" CommandName="Azalt" BorderColor="#FFFFFF" BorderStyle="Solid" BorderWidth="1px" ForeColor="#FFFFFF" Font-Size="12px" Font-Bold="true" BackColor="SlateGray"></asp:Button>
                            </td>
                            <td align="center" style="width: 90px">
                                <asp:LinkButton ID="LinkButton8" runat="server" Text="Güncelle" CommandName="Guncelle" />
                                &nbsp;&nbsp;&nbsp;
                                <asp:LinkButton ID="LinkButton2" runat="server" Text="Sil" CommandName="Sil" Width="15px" />
                            </td>
                        </tr>
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                        <tr style="background-color: #FFE2C6">
                            <td style="width: 390px">
                                <input type="hidden" value='<%#Eval("IadeDetayID") %>' id="IadeDetayID" runat="server" />
                                <input type="hidden" value='<%#Eval("UrunID") %>' id="UrunID" runat="server" />
                                &nbsp;<%#Eval("Ad") %></td>
                            <td align="center" style="width: 290px;">
                                <asp:Button ID="Button3" Width="25px" Height="25px" runat="server" Text="+" CommandName="Arttir" BorderColor="#FFFFFF" BorderStyle="Solid" BorderWidth="1px" ForeColor="#FFFFFF" Font-Size="12px" Font-Bold="true" BackColor="SlateGray"></asp:Button>
                                <input id="Miktar" type="text" runat="server" value='<%#Eval("Miktar")%>' onkeypress="return isNumberKey(event)" 
                                    style="width: 35px; color: #006699; border: 1px solid #A3B5C9; text-align: right" />
                                <asp:Button ID="Button4" Width="25px" Height="25px" runat="server" Text="-" CommandName="Azalt" BorderColor="#FFFFFF" BorderStyle="Solid" BorderWidth="1px" ForeColor="#FFFFFF" Font-Size="12px" Font-Bold="true" BackColor="SlateGray"></asp:Button>
                            </td>
                            <td align="center" style="width: 90px">
                                <asp:LinkButton ID="LinkButton8" runat="server" Text="Güncelle" CommandName="Guncelle" />
                                &nbsp;&nbsp;&nbsp;
                                <asp:LinkButton ID="LinkButton3" runat="server" Text="Sil" CommandName="Sil" Width="15px" />
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
                <td valign="middle" align="right">
                <table cellpadding="0" cellspacing="0" width="100%">
                <tr>
                <td align="left" valign="middle">
                    <asp:Button Width="110px" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" ForeColor="#6D8AAA" Font-Size="10px" runat="server" ID="btnSiparisiTamamla" onclick="btnSiparisiTamamla_Click" Text="İadeyi Kaydet"></asp:Button>
                    <asp:Label ID="Label8" runat="server" Width="1px"></asp:Label>
                    <asp:Button Width="170px" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" ForeColor="#6D8AAA" Font-Size="10px"  runat="server" ID="btnSiparisiTamamlaOnayla" onclick="btnSiparisiTamamlaOnayla_Click" Text="İadeyi Kaydet ve Onayla"></asp:Button>
                </td>
                </tr>
                </table>
                </tr>
                </table>
            </div>
            </div>

            <div style="position: absolute; width: 700px; height: 500px; z-index: 5; left: 150px; text-align: center;
                top: 5px;" runat="server" id="divUrunAyrinti" visible="false">
            <div style="position: fixed; width: 100%; height: 100%; z-index: -1; left: 0; top: 0;
                filter: alpha(opacity=60); -moz-opacity: .60; opacity: .60; background-color: #000000" onclick="invisible()">
            </div>
            <table cellpadding="0" cellspacing="0" style="width: 700px; height: 500px; background-color: #FFFFFF;
                border: 1px solid #D1D1D1; border-radius: 5px; padding: 5px;">
                <tr>
                    <td align="right" style="font-family: Verdana; font-size: 12px; padding-right: 10px; padding-top: 10px">
                        <table cellpadding="0" cellspacing="0" style="width: 100%;">
                            <tr>
                                <td align="left" style="padding-left: 20px; font-family: Verdana; font-size: 11px;">
                                    <asp:Label runat="server" ID="lblResimlerBaslik" Text="Resimler: " Visible="false" ForeColor="DarkRed"></asp:Label>
                                </td>
                                <td align="left" style="width: 100%">
                                    <asp:RadioButtonList style="padding-left: 60px" runat="server" ID="rblResimler" AutoPostBack="true" RepeatDirection="Horizontal" OnSelectedIndexChanged="rblResimler_SelectedIndexChanged"></asp:RadioButtonList>
                                </td>
                                <td align="right" valign="top">
                                    <asp:LinkButton Font-Bold="true" Text="X" runat="server" ID="lbUrunAyrintiKapat" OnClick="lbUrunAyrintiKapat_Click"
                                        Font-Underline="False" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td align="center" style="font-family: Verdana; font-size: 11px; font-weight: bold; padding-bottom: 5px">
                                    <asp:Label runat="server" ID="lblUrunAyrintiBarkod" Font-Size="10px" ForeColor="DarkRed"></asp:Label>
                        <asp:Label runat="server" ID="lblUrunAyrintiAd"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <uc2:ucUrunAyrinti ID="ucUrunAyrinti1" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td align="right" style="font-family: Verdana; font-size: 12px; padding-top: 5px; padding-right: 5px; padding-bottom: 5px">
                        Adet:
                        <asp:TextBox runat="server" ID="txtUrunAyrintiMiktar" Width="30px" onkeypress="return isNumberKey(event)" class="kucukbilgiGoster" ToolTip="Seçim Adedi"
                            ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" BorderWidth="1px" onkeydown="return clickButton(event,'btnUrunAyrintiSiparisVer')"
                            Visible="true"></asp:TextBox>
                        <asp:Image ID="imgUrunAyrintiPasif" ImageUrl="img/kapali.png" class="kucukbilgiGoster" ToolTip="Ürün kullanımda değil!<br/>Seçim yapabilmek için ürünü müşteri ilişkilerinden kullanıma açtırınız." runat="server" Visible="false" />
                        <asp:Label ID="Label10" runat="server" Width="20px"></asp:Label>
                        <asp:Button runat="server" ID="btnUrunAyrintiSiparisVer" Text="Aktar" 
                            onclick="btnUrunAyrintiSiparisVer_Click" BorderColor="#CCCCCC" BorderStyle="Solid" 
                            BorderWidth="1px" ForeColor="#6D8AAA" Font-Bold="true" Enabled="true" />
                    </td>
                </tr>
            </table>
            </div>








            <div style="font-size: 9px; font-family: Verdana; width: 100%; background-color: #EFEEEA; border-bottom: 1px solid #FFCFB2">
                <table cellpadding="5" cellspacing="0" style="width: 1000px;">
                <tr>
                <td style="width: 800px; text-align: left">
                    <asp:Button runat="server" ID="lbAnaSayfayaGit" OnClick="lbSayfayaGit_Click" Text="Giriş" />
                    <asp:Button runat="server" ID="lbAktivitelerGit" OnClick="lbSayfayaGit_Click" Text="Aktiviteler" />
                    <asp:Button runat="server" ID="lbHizmetBedelleriGit" OnClick="lbSayfayaGit_Click" Text="H.Bedelleri" />
                    <asp:Button runat="server" ID="lbAnlasmalarGit" OnClick="lbSayfayaGit_Click" Text="Anlaşmalar" />
                    <asp:Button runat="server" ID="lbSiparislerGit" OnClick="lbSayfayaGit_Click" Text="Siparişler" />
                    <asp:Button runat="server" ID="lbIadelerGit" OnClick="lbSayfayaGit_Click" Text="İadeler" />
                    <asp:Button runat="server" ID="lbOdemelerGit" OnClick="lbSayfayaGit_Click" Text="Tahsilatlar" />
                    <asp:Button runat="server" ID="lbHesapAyrintiGit" OnClick="lbSayfayaGit_Click" Text="Raporlar" />
                    <asp:Button runat="server" ID="lbUyelikIslemleriGit" OnClick="lbSayfayaGit_Click" Text="Üye İşlemleri" />
                    <asp:Button runat="server" ID="lbMesajlarGit" OnClick="lbSayfayaGit_Click" ToolTip="Sorularınızı bize yazın" Text="Mesajlar" />
                </td>
                <td style="width: 200px; font-family: Gisha; font-size: 12px;" align="right">
                    <table cellpadding="0" cellspacing="0"><tr><td><asp:Label ID="Label1" runat="server"></asp:Label>&nbsp;&nbsp;&nbsp;</td><td><asp:ImageButton runat="server" ID="ImageButton1" OnClick="ImageButton1_Click" ImageUrl="img/ic_logout.png" /></td></tr></table>
                </td>
                </tr>
                </table>
            </div>
            <div style="width: 1000px; text-align: right; font-size: 10px; font-family: Verdana">
            <table cellpadding="0" cellspacing="0" style="width: 1000px; margin-top: 5px;">
                <tr>
                    <td style="width: 850px; text-align: left; padding-left: 10px; font-size: 12px">
                        <asp:Label ID="lblCariHesap" runat="server" style="color: #D00000"></asp:Label></td>
                    <td style="width: 150px; text-align: left">
                        </td>
                </tr>
                <tr>
                    <td>
                        <table cellpadding="5" cellspacing="0">
                            <tr>
                                <td style="width: 256px; text-align: left">
                                    <%--Fiyat Tipi:
                                    <asp:DropDownList ID="ddlFiyatTipleri" runat="server" AutoPostBack="True" 
                                                    Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Size="9px" 
                                                    Font-Strikeout="False" Font-Underline="False"
                                                    Width="180px" ForeColor="#006699"
                                        onselectedindexchanged="ddlFiyatTipleri_SelectedIndexChanged">
                                    </asp:DropDownList>--%>
                                </td>
                                <td style="width: 256px; text-align: center">
                                    <%--Taksit Planı:
                                    <asp:DropDownList ID="ddlTaksitPlanlari" runat="server" AutoPostBack="True" 
                                                    Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Size="9px" 
                                                    Font-Strikeout="False" Font-Underline="False"
                                                    Width="180px" ForeColor="#006699" Enabled="false"
                                        onselectedindexchanged="ddlTaksitPlanlari_SelectedIndexChanged">
                                    </asp:DropDownList>--%>
                                </td>
                                <td style="width: 130px; text-align: center">
                                </td>
                                <td style="width: 130px; text-align: center">
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td></td>
                </tr>
            </table>
            </div>
            <table cellpadding="0" cellspacing="0" style="width: 1000px; height:28px; font-family: Tahoma;
                font-size: 10px;">
                <tr>
                    <td align="center" style="width: 1000px">
                        <asp:RadioButton ID="rbMalzemeler" runat="server" Checked="True" 
                            GroupName="grpSecim" Text="Malzemeler" Font-Bold="True" Font-Size="12px" 
                            oncheckedchanged="rbMalzemeler_CheckedChanged" AutoPostBack="True" />
                    </td>
                </tr>
            </table>
            <table runat="server" id="tblURUNLER" cellpadding="0" cellspacing="0" style="width: 1000px; font-family: Tahoma;
                font-size: 10px; height: 1000px;">
                <tr>
                    <td colspan="2" style="height: 110px; padding-bottom: 6px;" valign="bottom">
                        <table cellpadding="0" cellspacing="0">
                            <tr>
                                <td align="left" rowspan="2" style="padding: 5px; padding-left: 10px; width: 710px;">
                                    <fieldset style="border: 1px solid #CCCCCC; width: 680px; margin: 0px 10px 0px 10px; border-radius: 5px; padding: 5px;">
                                    <legend style="font-size: 14px; font-family: Gisha; font-weight: bold; color: #EE7A0B">Ürün Arama</legend>
                                    <table cellpadding="0" cellspacing="0" style="font-size: 8px;">
                                    <tr>
                                        <td align="left" style="width: 100px">
                                            <asp:RadioButton ID="rbIcinde" runat="server" AutoPostBack="true" GroupName="grpArama" Checked="True" 
                                                Text="İçinde arama" OnCheckedChanged="rbAramaSecimleri_CheckedChanged" />
                                        </td>
                                        <td align="left" style="width: 150px">
                                            <asp:RadioButton ID="rbBaslangicaGore" runat="server" AutoPostBack="true" 
                                                GroupName="grpArama" Text="Başlangıca göre arama" OnCheckedChanged="rbAramaSecimleri_CheckedChanged" />
                                        </td>
                                        <td align="left" style="width: 90px">
                                            <asp:RadioButton ID="rbUrtKodunaGore" runat="server" AutoPostBack="true" 
                                                GroupName="grpArama" Text="Ürt.kod arama" OnCheckedChanged="rbAramaSecimleri_CheckedChanged" />
                                        </td>
                                        <td align="left" style="width: 90px">
                                            <asp:RadioButton ID="rbMalzemeKodunaGore" runat="server" AutoPostBack="true" 
                                                GroupName="grpArama" Text="Mal.kod arama" OnCheckedChanged="rbAramaSecimleri_CheckedChanged" />
                                        </td>
                                        <td align="left" style="width: 250px">
                                        <table cellpadding="0" cellspacing="0">
                                        <tr>
                                        <td>
                                            <asp:RadioButton ID="rbBarkodaGore" runat="server" AutoPostBack="true"
                                                GroupName="grpArama" Text="Barkod arama" OnCheckedChanged="rbAramaSecimleri_CheckedChanged" />
                                        </td>
                                        <td style="padding-left: 5px">
                                            <asp:CheckBox ID="cbBarkodHemenAra" runat="server" AutoPostBack="true" Enabled="false" Checked="false"
                                                Text="Otomatik ara" OnCheckedChanged="cbBarkodHemenAra_CheckedChanged" />
                                        </td>
                                        <td style="padding-left: 5px">
                                            <asp:CheckBox ID="cbBarkodHemenEkle" runat="server" AutoPostBack="true" Enabled="false" Checked="false"
                                                Text="Otomatik ekle" OnCheckedChanged="cbBarkodHemenEkle_CheckedChanged" />
                                        </td>
                                        </tr>
                                        </table>
                                        </td>
                                    </tr>
                                </table>
                                <br />
                                <table cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td align="left" style="width: 400px">
                                            <asp:TextBox ID="txtArama" runat="server" Width="376px" AutoPostBack="false"
                                            onkeypress="return clickButton(event,'btnAra')" ForeColor="#006699" BorderColor="#A3B5C9" style="padding: 3px 3px 3px 3px;"
                                            BorderStyle="Solid" BorderWidth="1px" OnTextChanged="txtArama_TextChanged"></asp:TextBox>
                                        </td>
                                        <td align="left" style="width: 300px">
                                            <asp:Button ID="btnAra" runat="server" Text="Ara" Width="135px" OnClick="btnAra_Click" 
                                            BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" ForeColor="#6D8AAA" />
                                            &nbsp;
                                            <asp:Button ID="btnAramaTemizle" runat="server" OnClick="btnAramaTemizle_Click"
                                                Text="Temizle" Width="135px" BorderColor="#CCCCCC" 
                                                BorderStyle="Solid" BorderWidth="1px" ForeColor="#6D8AAA" />
                                        </td>
                                    </tr>
                                </table>
                                </fieldset>

                                </td>
                                <td align="center" style="width: 270px; padding: 5px;">
                                </td>
                            </tr>
                            <tr>
                                <td align="left" style="width: 270px; padding: 5px;">
                                <div runat="server" visible='<%# ((Sultanlar.DatabaseObject.Internet.Musteriler)Session["Musteri"]).tintUyeTipiID != 5 %>'>
                                    <fieldset style="border: 1px solid #CCCCCC; width: 220px; margin: 0px 10px 0px 10px; border-radius: 5px; padding: 5px;">
                                    <legend style="font-size: 14px; font-family: Gisha; font-weight: bold; color: #EE7A0B">Açıklama Alanları</legend>
                                    <div style="width: 100%; text-align: center">
                                    <asp:TextBox runat="server" ID="txtSiparisAciklama2" ForeColor="#006699" BorderColor="#A3B5C9"
                                                BorderStyle="Solid" BorderWidth="1px" Width="200px" MaxLength="40"></asp:TextBox>
                                    <br />
                                    <asp:TextBox runat="server" ID="txtSiparisAciklama3" ForeColor="#006699" BorderColor="#A3B5C9" Visible="false"
                                                BorderStyle="Solid" BorderWidth="1px" Width="200px" MaxLength="40"></asp:TextBox>
                                    </div>
                                    </fieldset>
                                </div>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px 5px 5px 20px" align="left">
                                </td>
                                <td style="padding: 5px;" align="center">
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td style="width: 900px; height: 100px;" align="center" valign="top">
                    <table style="width: 900px; height: 100px;">
                    <tr>
                    <td align="left" valign="top" style="width: 202px; padding-left: 20px">
                        <table cellpadding="3" cellspacing="0"><tr><td>





                        <asp:Panel ID="pnlSepet" runat="server" Height="89px" Width="202px">
                        İade No: <asp:Label ID="lblSiparisID" runat="server" style="color: #D00000"></asp:Label>
                        </asp:Panel>







                        </td></tr>
                        </table>
                    </td>
                    <td align="right" valign="top" style="width: 700px;">
                        <table cellpadding="0" cellspacing="0" runat="server" id="tblTedarikciSecimi" style="border: 1px solid #CCCCCC;
                            border-radius: 5px; padding: 5px;">
                            <tr>
                                <td colspan="24" style="font-size: 14px; font-family: Gisha; font-weight: bold; color: #EE7A0B;
                                    border-bottom: 1px solid #CCCCCC; padding-bottom: 3px">
                                    &nbsp; R e y o n &nbsp; &amp; &nbsp; K a t e g o r i &nbsp; S e ç i m i &nbsp; Y a p
                                </td>
                            </tr>
                            <tr>
                                <td class="alfabetikTDss">
                                    <asp:LinkButton ID="lb0" runat="server" OnClick="Kategori_Click">0</asp:LinkButton>
                                </td>
                                <td class="alfabetikTDss">
                                    <asp:LinkButton ID="lbA" runat="server" OnClick="Kategori_Click">A</asp:LinkButton>
                                </td>
                                <td class="alfabetikTDss">
                                    <asp:LinkButton ID="lbB" runat="server" OnClick="Kategori_Click">B</asp:LinkButton>
                                </td>
                                <td class="alfabetikTDss">
                                    <asp:LinkButton ID="lbC" runat="server" OnClick="Kategori_Click">C</asp:LinkButton>
                                </td>
                                <td class="alfabetikTDss" >
                                    <asp:LinkButton ID="lbD" runat="server" OnClick="Kategori_Click">D</asp:LinkButton>
                                </td>
                                <td class="alfabetikTDss">
                                    <asp:LinkButton ID="lbE" runat="server" OnClick="Kategori_Click">E</asp:LinkButton>
                                </td>
                                <td class="alfabetikTDss">
                                    <asp:LinkButton ID="lbF" runat="server" OnClick="Kategori_Click">F</asp:LinkButton>
                                </td>
                                <td class="alfabetikTDss">
                                    <asp:LinkButton ID="lbG" runat="server" OnClick="Kategori_Click">G</asp:LinkButton>
                                </td>
                                <td class="alfabetikTDss">
                                    <asp:LinkButton ID="lbH" runat="server" OnClick="Kategori_Click">H</asp:LinkButton>
                                </td>
                                <td class="alfabetikTDss">
                                    <asp:LinkButton ID="lbI" runat="server" OnClick="Kategori_Click">I</asp:LinkButton>
                                </td>
                                <td class="alfabetikTDss">
                                    <asp:LinkButton ID="lbJ" runat="server" OnClick="Kategori_Click">J</asp:LinkButton>
                                </td>
                                <td class="alfabetikTDss">
                                    <asp:LinkButton ID="lbK" runat="server" OnClick="Kategori_Click">K</asp:LinkButton>
                                </td>
                                <td class="alfabetikTDss">
                                    <asp:LinkButton ID="lbL" runat="server" OnClick="Kategori_Click">L</asp:LinkButton>
                                </td>
                                <td class="alfabetikTDss">
                                    <asp:LinkButton ID="lbM" runat="server" OnClick="Kategori_Click">M</asp:LinkButton>
                                </td>
                                <td class="alfabetikTDss">
                                    <asp:LinkButton ID="lbN" runat="server" OnClick="Kategori_Click">N</asp:LinkButton>
                                </td>
                                <td class="alfabetikTDss">
                                    <asp:LinkButton ID="lbO" runat="server" OnClick="Kategori_Click">O</asp:LinkButton>
                                </td>
                                <td class="alfabetikTDss">
                                    <asp:LinkButton ID="lbP" runat="server" OnClick="Kategori_Click">P</asp:LinkButton>
                                </td>
                                <td class="alfabetikTDss">
                                    <asp:LinkButton ID="lbR" runat="server" OnClick="Kategori_Click">R</asp:LinkButton>
                                </td>
                                <td class="alfabetikTDss">
                                    <asp:LinkButton ID="lbS" runat="server" OnClick="Kategori_Click">S</asp:LinkButton>
                                </td>
                                <td class="alfabetikTDss">
                                    <asp:LinkButton ID="lbT" runat="server" OnClick="Kategori_Click">T</asp:LinkButton>
                                </td>
                                <td class="alfabetikTDss">
                                    <asp:LinkButton ID="lbU" runat="server" OnClick="Kategori_Click">U</asp:LinkButton>
                                </td>
                                <td class="alfabetikTDss">
                                    <asp:LinkButton ID="lbV" runat="server" OnClick="Kategori_Click">V</asp:LinkButton>
                                </td>
                                <td class="alfabetikTDss">
                                    <asp:LinkButton ID="lbY" runat="server" OnClick="Kategori_Click">Y</asp:LinkButton>
                                </td>
                                <td class="alfabetikTDss">
                                    <asp:LinkButton ID="lbZ" runat="server" OnClick="Kategori_Click">Z</asp:LinkButton>
                                </td>
                            </tr>
                        </table>
                        </td>
                        </tr>
                        </table>
                    </td>
                    <td align="center" rowspan="2" style="width: 100px; padding-top: 3px" valign="top">
                        <table cellpadding="0" cellspacing="0" runat="server" id="tblKategoriSecimi" style="border: 1px solid #CCCCCC;
                            border-radius: 5px; padding: 5px;">
                            <tr>
                                <td class="alfabetikTDss">
                                    <asp:LinkButton ID="lb2" runat="server" OnClick="Tedarikci_Click">0</asp:LinkButton>
                                </td>
                                <td rowspan="24" style="padding: 8px; 
                                    font-size: 14px; font-family: Gisha; font-weight: bold; color: #EE7A0B;
                                    border-left: 1px solid #CCCCCC;" valign="top">
                                    T<br />
                                    e<br />
                                    d<br />
                                    a<br />
                                    r<br />
                                    i<br />
                                    k<br />
                                    ç<br />
                                    i<br />
                                    <br />
                                    S<br />
                                    e<br />
                                    ç<br />
                                    i<br />
                                    m<br />
                                    i<br />
                                    <br />
                                    Y<br />
                                    a<br />
                                    p
                                </td>
                            </tr>
                            <tr>
                                <td class="alfabetikTDss">
                                    <asp:LinkButton ID="lbA2" runat="server" OnClick="Tedarikci_Click">A</asp:LinkButton>
                                </td>
                            </tr>
                            <tr>
                                <td class="alfabetikTDss">
                                    <asp:LinkButton ID="lbB2" runat="server" OnClick="Tedarikci_Click">B</asp:LinkButton>
                                </td>
                            </tr>
                            <tr>
                                <td class="alfabetikTDss">
                                    <asp:LinkButton ID="lbC2" runat="server" OnClick="Tedarikci_Click">C</asp:LinkButton>
                                </td>
                            </tr>
                            <tr>
                                <td class="alfabetikTDss">
                                    <asp:LinkButton ID="lbD2" runat="server" OnClick="Tedarikci_Click">D</asp:LinkButton>
                                </td>
                            </tr>
                            <tr>
                                <td class="alfabetikTDss">
                                    <asp:LinkButton ID="lbE2" runat="server" OnClick="Tedarikci_Click">E</asp:LinkButton>
                                </td>
                            </tr>
                            <tr>
                                <td class="alfabetikTDss">
                                    <asp:LinkButton ID="lbF2" runat="server" OnClick="Tedarikci_Click">F</asp:LinkButton>
                                </td>
                            </tr>
                            <tr>
                                <td class="alfabetikTDss">
                                    <asp:LinkButton ID="lbG2" runat="server" OnClick="Tedarikci_Click">G</asp:LinkButton>
                                </td>
                            </tr>
                            <tr>
                                <td class="alfabetikTDss">
                                    <asp:LinkButton ID="lbH2" runat="server" OnClick="Tedarikci_Click">H</asp:LinkButton>
                                </td>
                            </tr>
                            <tr>
                                <td class="alfabetikTDss">
                                    <asp:LinkButton ID="lbI2" runat="server" OnClick="Tedarikci_Click">I</asp:LinkButton>
                                </td>
                            </tr>
                            <tr>
                                <td class="alfabetikTDss">
                                    <asp:LinkButton ID="lbJ2" runat="server" OnClick="Tedarikci_Click">J</asp:LinkButton>
                                </td>
                            </tr>
                            <tr>
                                <td class="alfabetikTDss">
                                    <asp:LinkButton ID="lbK2" runat="server" OnClick="Tedarikci_Click">K</asp:LinkButton>
                                </td>
                            </tr>
                            <tr>
                                <td class="alfabetikTDss">
                                    <asp:LinkButton ID="lbL2" runat="server" OnClick="Tedarikci_Click">L</asp:LinkButton>
                                </td>
                            </tr>
                            <tr>
                                <td class="alfabetikTDss">
                                    <asp:LinkButton ID="lbM2" runat="server" OnClick="Tedarikci_Click">M</asp:LinkButton>
                                </td>
                            </tr>
                            <tr>
                                <td class="alfabetikTDss">
                                    <asp:LinkButton ID="lbN2" runat="server" OnClick="Tedarikci_Click">N</asp:LinkButton>
                                </td>
                            </tr>
                            <tr>
                                <td class="alfabetikTDss">
                                    <asp:LinkButton ID="lbO2" runat="server" OnClick="Tedarikci_Click">O</asp:LinkButton>
                                </td>
                            </tr>
                            <tr>
                                <td class="alfabetikTDss">
                                    <asp:LinkButton ID="lbP2" runat="server" OnClick="Tedarikci_Click">P</asp:LinkButton>
                                </td>
                            </tr>
                            <tr>
                                <td class="alfabetikTDss">
                                    <asp:LinkButton ID="lbR2" runat="server" OnClick="Tedarikci_Click">R</asp:LinkButton>
                                </td>
                            </tr>
                            <tr>
                                <td class="alfabetikTDss">
                                    <asp:LinkButton ID="lbS2" runat="server" OnClick="Tedarikci_Click">S</asp:LinkButton>
                                </td>
                            </tr>
                            <tr>
                                <td class="alfabetikTDss">
                                    <asp:LinkButton ID="lbT2" runat="server" OnClick="Tedarikci_Click">T</asp:LinkButton>
                                </td>
                            </tr>
                            <tr>
                                <td class="alfabetikTDss">
                                    <asp:LinkButton ID="lbU2" runat="server" OnClick="Tedarikci_Click">U</asp:LinkButton>
                                </td>
                            </tr>
                            <tr>
                                <td class="alfabetikTDss">
                                    <asp:LinkButton ID="lbV2" runat="server" OnClick="Tedarikci_Click">V</asp:LinkButton>
                                </td>
                            </tr>
                            <tr>
                                <td class="alfabetikTDss">
                                    <asp:LinkButton ID="lbY2" runat="server" OnClick="Tedarikci_Click">Y</asp:LinkButton>
                                </td>
                            </tr>
                            <tr>
                                <td class="alfabetikTDss">
                                    <asp:LinkButton ID="lbZ2" runat="server" OnClick="Tedarikci_Click">Z</asp:LinkButton>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td style="height: 750px;" valign="top" align="center">
                        
                        <div style="width: 100%; text-align: left">
                        <fieldset style="border: 1px solid #CCCCCC; margin: 0px 10px 10px 10px; border-radius: 5px; padding: 5px;">
                        <legend style="font-size: 14px; font-family: Gisha; font-weight: bold; color: #EE7A0B">Süzme İşlemleri</legend>

                        <table cellpadding="3">
                            <tr>
                                <td style="width: 325px" align="left">
                                    Tedarikçi:
                                    <span style="color: Red;"><asp:Label runat="server" ID="lblTedarikciSecim" Font-Bold="false" Font-Size="11px"
                                        Style="padding-left: 20px">-</asp:Label></span>
                                </td>
                                <td style="width: 325px" align="left">
                                    Reyon & Kategori:
                                    <span style="color: Red;"><asp:Label runat="server" ID="lblKategoriSecim" Font-Bold="false" Font-Size="11px"
                                        Style="padding-left: 20px">-</asp:Label></span>
                                </td>
                                <td align="left">
                                    Arama:
                                    <span style="color: Red;"><asp:Label runat="server" ID="lblAramaSecim" Font-Bold="false" Font-Size="11px" 
                                        Style="padding-left: 20px">-</asp:Label></span>
                                </td>
                            </tr>
                        </table>
                        </fieldset>
                        </div>

                        <div style="width: 100%; text-align: left; padding: 0px 10px 10px 10px">
                        <table cellpadding="0" cellspacing="0">
                        <tr>
                        <td style="padding-right: 5px">
                            <fieldset style="border: 1px solid #CCCCCC; border-radius: 5px; padding: 5px; height: 50px">
                            <legend style="font-size: 14px; font-family: Gisha; font-weight: bold; color: #EE7A0B">Düzen</legend>
                            <table cellpadding="0" cellspacing="0" style="padding: 3px; font-size: 9px">
                                <tr>
                                    <td style="width: 140px; text-align: center;">
                                        <asp:RadioButton ID="rbResimDuzeni" runat="server" GroupName="grpDuzen"
                                            Text="Resim Düzeni" AutoPostBack="True" OnCheckedChanged="Duzen_CheckedChanged" />
                                    </td>
                                    <td style="width: 140px; text-align: center;">
                                        <asp:RadioButton ID="rbListeDuzeni" runat="server" Checked="True" GroupName="grpDuzen" Text="Liste Düzeni"
                                            AutoPostBack="True" OnCheckedChanged="Duzen_CheckedChanged" />
                                    </td>
                                </tr>
                            </table>
                            </fieldset>
                        </td>
                        <td style="padding-left: 5px">
                            <fieldset style="border: 1px solid #CCCCCC; border-radius: 5px; padding: 5px; height: 50px">
                            <legend style="font-size: 14px; font-family: Gisha; font-weight: bold; color: #EE7A0B">Sıralama</legend>
                            <table cellpadding="0" cellspacing="0" style="padding: 3px; font-size: 9px">
                                <tr>
                                    <td style="width: 130px; text-align: center;">
                                        <asp:RadioButton ID="rbSiralamaAzalan" runat="server" Checked="False" GroupName="grpAzalanArtan"
                                            Text="Azalan" AutoPostBack="True" OnCheckedChanged="SiralamaAzalanArtan_CheckedChanged" />
                                    </td>
                                    <td style="width: 140px; text-align: center;">
                                        <asp:RadioButton ID="rbSiralamaArtan" runat="server" Checked="True" GroupName="grpAzalanArtan"
                                            Text="Artan" AutoPostBack="True" OnCheckedChanged="SiralamaAzalanArtan_CheckedChanged" />
                                    </td>
                                    <td style="width: 140px; text-align: center;">
                                        <asp:RadioButton ID="rbTariheGoreSiralama" runat="server" GroupName="grpSiralama"
                                            Text="Eklenme Tarihine Göre" AutoPostBack="True" OnCheckedChanged="Siralama_CheckedChanged" Visible="false" />
                                        <asp:RadioButton ID="rbFYTSiralama" runat="server" GroupName="grpSiralama" Text="Fiyata Göre"
                                            AutoPostBack="True" OnCheckedChanged="Siralama_CheckedChanged" />
                                    </td>
                                    <td style="width: 140px; text-align: center;">
                                        <asp:RadioButton ID="rbABCSiralama" runat="server" Checked="True" GroupName="grpSiralama" Text="ABC (Ted.göre)"
                                            AutoPostBack="True" OnCheckedChanged="Siralama_CheckedChanged" />
                                    </td>
                                </tr>
                            </table>
                            </fieldset>
                        </td>
                        </tr>
                        </table>
                        </div>

                        <table cellpadding="0" cellspacing="0" style="width: 100%; height: 50px">
                                <tr>
                                <td align="left" style="padding-left: 30px">
                                </td>
                                <td align="center">
                                    <asp:Button ID="btnSipariseAktar" runat="server" BorderColor="#FFA968" BackColor="#FFE7D8"
                                        BorderStyle="Solid" BorderWidth="1px" ForeColor="#EE7A0B" Height="22px" Font-Bold="true"
                                        onclick="btnSipariseAktar_Click" Text="Seçimi Listeye Aktar" Width="230px" />
                                </td>
                                <td align="left" style="padding-left: 50px">
                                </td>
                                </tr>
                                    <tr>
                                        <td align="left" style="padding-left: 30px">
                                            <asp:Button ID="btnTedarikciTemizle" runat="server" BorderColor="#CCCCCC" 
                                                BorderStyle="Solid" BorderWidth="1px" ForeColor="#6D8AAA" Height="22px" 
                                                onclick="btnTedarikciTemizle_Click" Text="Tedarikçi Seçimini Temizle" 
                                                Width="230px" />
                                        </td>
                                        <td align="center" style="padding-top: 10px; padding-bottom: 10px;">
                                            <asp:Button ID="btnHepsiniTemizle" runat="server" 
                                                BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" ForeColor="#6D8AAA" 
                                                Height="22px" onclick="btnHepsiniTemizle_Click" 
                                                Text="Tüm Seçimi Temizle" Width="230px" />
                                        </td>
                                        <td align="right" style="padding-right: 30px">
                                            <asp:Button ID="btnKategoriTemizle" runat="server" BorderColor="#CCCCCC" 
                                                BorderStyle="Solid" BorderWidth="1px" ForeColor="#6D8AAA" Height="22px" 
                                                onclick="btnKategoriTemizle_Click" Text="Reyon&amp;Kategori Seçimini Temizle" 
                                                Width="230px" />
                                        </td>
                                    </tr>
                                </table>
                        <asp:DataList ID="dlResimli" runat="server" RepeatDirection="Horizontal" RepeatColumns="5">
                            <ItemTemplate>
                                <table cellpadding="0" cellspacing="0" style="width: 165px; height: 200px; border: 1px solid #bfbfbf;
                                    margin: 2px;border-radius: 5px; padding: 5px;">
                                    <tr>
                                        <td colspan="2" style="border-bottom: 1px solid #bfbfbf; height: 105px">
                                            <table>
                                                <tr>
                                                    <td style="width: 140px; height: 105px; background-color: #FFFFFF" align="center" rowspan="3">
                                                        <asp:ImageButton ID="ImageButton1" runat="server" CommandName='<%#Eval("UrunID")%>' CommandArgument='<%#Eval("pkResimID")%>' ImageUrl='<%# Eval("pkResimID", "resim.aspx?uidO={0}")%>' OnClick="ibUrunAyrinti_Click" BorderStyle="None" />
                                                    </td>
                                                    <td style="width: 25px; height: 30px; border-left: 1px solid #bfbfbf;"
                                                        valign="middle" align="center">
                                                        <span id="Span1" runat="server" style="color: Red; visibility: collapse"><%# Eval("UrunID") %></span>
                                                        <asp:Image ID="Image1" runat="server" ToolTip="Yeni Ürün" ImageUrl="img/yeni.png" Visible='<%#Convert.ToBoolean(Convert.ToInt32(Eval("KYTM")) < 60)%>' class="kucukbilgiGoster" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 25px; height: 55px; border-left: 1px solid #bfbfbf; border-top: 1px solid #bfbfbf;"
                                                        valign="middle" align="center">
                                                        A<br />
                                                        D<br />
                                                        <br />
                                                        <strong><%#Eval("Adet") %></strong>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 25px; height: 25px; border-left: 1px solid #bfbfbf; border-top: 1px solid #bfbfbf;"
                                                        valign="middle" align="center">
                                                        <asp:TextBox ToolTip="Seçim Adedi" class="kucukbilgiGoster" runat="server" ForeColor="#006699" BorderColor="#A3B5C9"
                                                            BorderStyle="Solid" BorderWidth="1px" Width="20px" Height="20px" onkeypress="return isNumberKey(event)" onkeydown="return clickButton(event,'btnSipariseAktar')">
                                                            </asp:TextBox>
                                                        <%--<asp:Image ImageUrl="img/kapali.png" class="kucukbilgiGoster" ToolTip="Ürün kullanımda değil!<br/>Seçim yapabilmek için ürünü müşteri ilişkilerinden kullanıma açtırınız." runat="server" Visible='<%# Convert.ToInt32(Eval("PASIF")) == 1 %>' />--%>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="2" style="border-bottom: 1px solid #bfbfbf; height: 45px">
                                            <div style="width: 150px; height: 45px; overflow: hidden; vertical-align: middle">
                                            <input type="hidden" value='<%#Eval("pkResimID") %>' id="ResimID" runat="server" />
                                            <input type="hidden" value='<%#Eval("UrunID") %>' id="UrunID" runat="server" />
                                            <asp:LinkButton ID="LinkButton1" runat="server" Text='<%# Eval("Ad") %>' OnClick="lbUrunAyrinti_Click" />
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" style="width: 75px; height: 15px">
                                            <input type="hidden" value='<%#Eval("TedarikciAdi") %>' id="TedarikciAdi" runat="server" />
                                            <input type="hidden" value='<%#Eval("TedarikciID") %>' id="TedarikciID" runat="server" />
                                            <asp:LinkButton ID="LinkButton4" runat="server" OnClick="TedarikciIsmindenSecim_Click" Enabled='<%#!rbBarkodaGore.Checked%>'><%# Eval("TedarikciAdi") %></asp:LinkButton>
                                        </td>
                                        <td align="center" style="width: 75px">
                                            <input type="hidden" value='<%#Eval("KategoriAdi") %>' id="KategoriAdi" runat="server" />
                                            <input type="hidden" value='<%#Eval("KategoriID") %>' id="KategoriID" runat="server" />
                                            <asp:LinkButton ID="LinkButton5" runat="server" OnClick="KategoriIsmindenSecim_Click" Enabled='<%#!rbBarkodaGore.Checked%>'><%# Eval("KategoriAdi") %></asp:LinkButton>
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:DataList>
                        <asp:DataList ID="dlListe" runat="server" Enabled="False">
                            <HeaderTemplate>
                                <table cellpadding="0" cellspacing="0" style="width: 850px;">
                                    <tr>
                                        <td align="center" style="width: 50px; height: 35px; border-bottom-style: solid; border-bottom-width: 1px;
                                            border-bottom-color: #BFBFBF; font-weight: bold">
                                            Resim
                                        </td>
                                        <td align="center" style="width: 400px; border-bottom-style: solid; border-bottom-width: 1px;
                                            border-bottom-color: #BFBFBF; font-weight: bold">
                                            Ürün Adı
                                        </td>
                                        <td align="center" style="width: 150px; border-bottom-style: solid; border-bottom-width: 1px;
                                            border-bottom-color: #BFBFBF; font-weight: bold">
                                            Tedarikçi
                                        </td>
                                        <td align="center" style="width: 150px; border-bottom-style: solid; border-bottom-width: 1px;
                                            border-bottom-color: #BFBFBF; font-weight: bold">
                                            Reyon & Kategori
                                        </td>
                                        <td align="center" style="width: 45px; border-bottom-style: solid; border-bottom-width: 1px;
                                            border-bottom-color: #BFBFBF; font-weight: bold">
                                            Koli Ad.
                                        </td>
                                        <td align="center" style="width: 35px; border-bottom-style: solid; border-bottom-width: 1px;
                                            border-bottom-color: #BFBFBF; font-weight: bold">
                                            Seçim
                                        </td>
                                    </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr onmouseover="Satir(this,true)" onmouseout="Satir(this,false)">
                                    <td align="center" style="width: 50px; height: 50px;">
                                        <div style="width: 50px; height: 50px"><asp:ImageButton ID="ImageButton3" runat="server" style="max-width: 100%; max-height: 100%;" CommandArgument='<%#Eval("pkResimID")%>' CommandName='<%#Eval("UrunID")%>' ImageUrl='<%# Eval("pkResimID", "resim.aspx?uidO={0}")%>' OnClick="ibUrunAyrinti_Click" BorderStyle="None" /></div>
                                    </td>
                                    <td align="left" style="width: 400px; padding-left: 5px">
                                        <asp:Image ID="Image2" runat="server" ToolTip="Yeni Ürün" ImageUrl="img/yeni.png" Visible='<%#Convert.ToBoolean(Convert.ToInt32(Eval("KYTM")) < 60)%>' class="kucukbilgiGoster" />
                                        <input type="hidden" value='<%#Eval("pkResimID") %>' id="ResimID" runat="server" />
                                        <input type="hidden" value='<%#Eval("UrunID") %>' id="UrunID" runat="server" />
                                        <asp:LinkButton ID="LinkButton2" runat="server" Text='<%# Eval("Ad") %>' OnClick="lbUrunAyrinti_Click" />
                                        <span id="Span3" runat="server" style="color: Red; visibility: hidden"><%# Eval("UrunID") %></span>
                                    </td>
                                    <td align="center" style="width: 150px;">
                                        <input type="hidden" value='<%#Eval("TedarikciAdi") %>' id="TedarikciAdi" runat="server" />
                                        <input type="hidden" value='<%#Eval("TedarikciID") %>' id="TedarikciID" runat="server" />
                                        <asp:LinkButton ID="LinkButton3" Font-Bold="true" runat="server" OnClick="TedarikciIsmindenSecim_Click" Enabled='<%#!rbBarkodaGore.Checked%>'><%# Eval("TedarikciAdi") %></asp:LinkButton>
                                    </td>
                                    <td align="center" style="width: 150px;">
                                        <input type="hidden" value='<%#Eval("KategoriAdi") %>' id="KategoriAdi" runat="server" />
                                        <input type="hidden" value='<%#Eval("KategoriID") %>' id="KategoriID" runat="server" />
                                        <asp:LinkButton ID="LinkButton4" Font-Bold="true" runat="server" OnClick="KategoriIsmindenSecim_Click" Enabled='<%#!rbBarkodaGore.Checked%>'><%# Eval("KategoriAdi") %></asp:LinkButton>
                                    </td>
                                    <td align="center" style="width: 45px;">
                                        <strong><%#Eval("Adet") %></strong>
                                    </td>
                                    <td align="center" style="width: 35px;">
                                        <asp:TextBox ToolTip="Seçim Adedi" class="kucukbilgiGoster" runat="server" ForeColor="#006699" BorderColor="#A3B5C9"
                                            BorderStyle="Solid" BorderWidth="1px" Width="20px" Height="20px" onkeypress="return isNumberKey(event)" onkeydown="return clickButton(event,'btnSipariseAktar')">
                                            </asp:TextBox>
                                        <%--<asp:Image ImageUrl="img/kapali.png" class="kucukbilgiGoster" ToolTip="Ürün kullanımda değil!<br/>Seçim yapabilmek için ürünü müşteri ilişkilerinden kullanıma açtırınız." runat="server" Visible='<%# Convert.ToInt32(Eval("PASIF")) == 1 %>' />--%>
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                </table>
                            </FooterTemplate>
                        </asp:DataList>
                        <asp:Label ID="lblEmpty" Text="<br />Seçim yapılmadı." Font-Italic="true" runat="server"></asp:Label>

                                    <br />
                                    <asp:Button ID="btnSipariseAktar2" runat="server" BorderColor="#FFA968" BackColor="#FFE7D8"
                                        BorderStyle="Solid" BorderWidth="1px" ForeColor="#EE7A0B" Height="22px" Font-Bold="true"
                                        onclick="btnSipariseAktar_Click" Text="Seçimi Listeye Aktar" Width="230px" />

                        <table cellpadding="0" cellspacing="0" border="0" style="width: 850px; height: 30px; font-size: 14px;">
                            <tr>
                                <td style="width: 50px; padding-right: 5px" valign="middle" align="right">
                                    <asp:ImageButton ID="ibOnceki" runat="server" ImageUrl="img/sol_ok.gif" onclick="lbOnceki_Click" />
                                </td>
                                <td style="text-align: left; padding-bottom: 3px" valign="middle">
                                    <asp:LinkButton ID="lbOnceki" runat="server" onclick="lbOnceki_Click">Önceki Sayfa</asp:LinkButton>
                                </td>
                                <td style="text-align: right; padding-bottom: 3px" valign="middle">
                                    <asp:LinkButton ID="lbSonraki" runat="server" onclick="lbSonraki_Click">Sonraki Sayfa</asp:LinkButton>
                                </td>
                                <td style="width: 50px; padding-left: 5px" valign="middle" align="left">
                                    <asp:ImageButton ID="ibSonraki" runat="server" ImageUrl="img/sag_ok.gif" onclick="lbSonraki_Click" />
                                </td>
                            </tr>
                        </table>
                        <table cellpadding="0" cellspacing="0" border="0" style="width: 850px; font-size: 12px; ">
                            <tr>
                                <td style="text-align: center">
                                    <asp:Label runat="server" ID="lblUrunSayisi"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    <br />
<uc1:ucAlt ID="ucAlt1" runat="server" />
    </form>
</body>
</html>

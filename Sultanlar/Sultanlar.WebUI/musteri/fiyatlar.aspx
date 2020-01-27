<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="fiyatlar.aspx.cs" Inherits="Sultanlar.WebUI.musteri.fiyatlar" %>

<%@ Register src="ucUrunAyrinti.ascx" tagname="ucUrunAyrinti" tagprefix="uc1" %>

<%@ Register src="ucFiyatlarKampanyalar.ascx" tagname="ucKampanyalar" tagprefix="uc2" %>

<%@ Register src="ucAlt.ascx" tagname="ucAlt" tagprefix="uc3" %>

<%@ Register src="ucProgress.ascx" tagname="ucProgress" tagprefix="uc4" %>

<%@ Register src="ucMesajlar.ascx" tagname="ucMesajlar" tagprefix="uc5" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
	<meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Sultanlar : Fiyatlar</title>
    <%--<meta http-equiv="refresh" content="1800" />--%>
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
            background-color: #FFFFFF;
        }

        .qtip-eskod{
            max-width: 550px;
        }
    </style>
    <link rel="stylesheet" type="text/css" href="StyleSheet.css" />        <script type="text/javascript" src="js/jquery-1.2.6.pack.js"></script>
    <script type="text/javascript" src="js/jquery-1.8.3.js"></script>
    <script type="text/javascript" src="js/jquery-ui.js"></script>
    <link rel="stylesheet" href="js/jquery-ui.css" />
    <script type="text/javascript" src="js/scripts.js"></script>

    <script type="text/javascript" src="js/tooltip.js"></script>

    <script type="text/javascript">
        //        function startWin(win) {
        //            if (navigator.appName == "Microsoft Internet Explorer") {
        //                var param = "toolbar=no,location=no,status=no,menubar=no,scrollbars=yes,width=900,height=480,noresize"
        //                window.open("kampanyaayrinti.aspx?kid=" + win.toString(), "_blank", param);
        //            }
        //            else {
        //                yenipencere = window.open("kampanyaayrinti.aspx?kid=" + win.toString(), "Kampanya Ayrıntısı", "toolbar=no,location=no,status=no,menubar=no,scrollbars=yes,width=900,height=480,noresize");
        //                yenipencere.moveTo(0, 0);
        //            }
        //        }

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

        document.onkeydown = keyDown;
        function keyDown(evt) {
            if (document.getElementById('divUrunAyrinti') != null) {
                var key;
                if (!evt) {
                    evt = window.event;
                    if (!evt.which) {
                        key = evt.keyCode;
                    }
                } else if (evt) {
                    key = evt.which;
                }
                switch (key) {
                    case 37:
                        var bt = document.getElementById('btnUrunAyrintiOnceki');
                        bt.click();
                        break;
                    case 39:
                        var bt = document.getElementById('btnUrunAyrintiSonraki');
                        bt.click();
                        break;
                }
            }
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

      <script type='text/javascript' src="js/jquery.qtip.js"></script>
      <link rel="stylesheet" type="text/css" href="js/jquery.qtip.css"/>

</head>
<body style="margin: 0 0 0 0; background-color: #FFFFFF">
    <form id="form1" runat="server"><div id="top" style="z-index: 50;">Yukarı Çık</div><div id="dek" style="padding-left: 350px; padding-top: 25px"></div><script type="text/javascript" src="js/popup.js"></script>
    <asp:ScriptManager ID="AjaxScripts" runat="server" AsyncPostBackTimeout="300">
    </asp:ScriptManager>
    <script type="text/javascript">
        Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(function (evt, args) {
            $('#rbMalzemeler').button();
            $('#rbKampanyalar').button();
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
            $('#ucKampanyalar1_cbKampanyaYeniUrunler').button();
            $('#ucKampanyalar1_rblKategorilerKamp').buttonset().find('label').width(300);
            $('#ucKampanyalar1_rblTedarikcilerKamp').buttonset().find('label').width(300);
            $("input[type=submit], input[type=button]").button();
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
            <uc4:ucProgress ID="ucProgress1" runat="server" />
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdatePanel ID="DivAjax" runat="server">
        <ContentTemplate>

    <div id="tiptip_holder">
    <div id="tiptip_content">
    <div id="tiptip_arrow">
    <div id="tiptip_arrow_inner"></div>
    </div>
    </div>
    </div>

            <uc5:ucMesajlar ID="ucMesajlar1" runat="server" />

            <div style="position: absolute; width: 300px; height: 500px; z-index: 3; left: 219px;
                top: 285px;" runat="server" id="divKategori" visible="false">
                <table style="border: 1px solid #CCCCCC; width: 300px; height: 500px; font-family: Tahoma;
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
                            <asp:RadioButtonList ID="rblKategoriler" runat="server" AutoPostBack="True" 
                                OnSelectedIndexChanged="rblKategoriler_SelectedIndexChanged">
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
                <table style="border: 1px solid #CCCCCC; width: 300px; height: 500px; font-family: Tahoma;
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

            <div style="position: absolute; width: 900px; height: 500px; z-index: 5; left: 50px; text-align: center;
                top: 5px;" runat="server" id="divUrunAyrinti" visible="false">
            <div style="position: fixed; width: 100%; height: 100%; z-index: -1; left: 0; top: 0;
                filter: alpha(opacity=60); -moz-opacity: .60; opacity: .60; background-color: #000000" onclick="invisible()">
            </div>
            <table cellpadding="0" cellspacing="0" style="width: 900px; height: 500px; background-color: #FFFFFF; border: 1px solid #D1D1D1; border-radius: 5px; padding: 5px;">
                <tr>
                    <td align="right" style="font-family: Verdana; font-size: 12px; padding-right: 10px; padding-top: 10px">
                        <table cellpadding="0" cellspacing="0" style="width: 100%; height: 25px">
                            <tr>
                                <td align="left" style="width: 50px; padding-left: 20px; font-family: Verdana; font-size: 11px;">
                                    <asp:Label runat="server" ID="lblResimlerBaslik" Text="Resimler: " Visible="false" ForeColor="DarkRed"></asp:Label>
                                </td>
                                <td align="left" style="width: 100px">
                                    <asp:RadioButtonList style="padding-left: 20px" runat="server" ID="rblResimler" AutoPostBack="true" RepeatDirection="Horizontal" OnSelectedIndexChanged="rblResimler_SelectedIndexChanged"></asp:RadioButtonList>
                                </td>
                                <td align="right" valign="top" style="width: 700px; padding-right: 20px; font-size: 11px">
                                    <asp:Label runat="server" ID="lblUrunAyrintiTedarikciIlgili" ForeColor="DarkRed" Visible="false"></asp:Label>
                                </td>
                                <td align="right" valign="top" style="width: 30px">
                                    <asp:LinkButton Font-Bold="true" Text="X" runat="server" ID="lbUrunAyrintiKapat" OnClick="lbUrunAyrintiKapat_Click"
                                        Font-Underline="False" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td align="center" style="font-family: Verdana; font-size: 11px; font-weight: bold; padding-bottom: 5px">
                        <table cellpadding="0" cellspacing="0" style="width: 100%">
                            <tr>
                                <td align="left" style="padding-left: 5px">
                                    <asp:Button runat="server" ID="btnUrunAyrintiOnceki" BorderColor="#CCCCCC" BorderStyle="Solid" 
                                        BorderWidth="1px" ForeColor="#6D8AAA" Text="<<" ToolTip="Önceki Ürün" 
                                        OnClick="btnUrunAyrintiOnceki_Click" /> 
                                </td>
                                <td align="center" style="width: 100%">
                                    <asp:Label runat="server" ID="lblUrunAyrintiID" Visible="false"></asp:Label>
                                    <asp:Label runat="server" ID="lblUrunAyrintiBarkod" Font-Size="10px" ForeColor="DarkRed"></asp:Label>
                                    <asp:Label runat="server" ID="lblUrunAyrintiAd"></asp:Label>
                                </td>
                                <td align="right" style="padding-right: 5px">
                                    <asp:Button runat="server" ID="btnUrunAyrintiSonraki" BorderColor="#CCCCCC" BorderStyle="Solid" 
                                        BorderWidth="1px" ForeColor="#6D8AAA" Text=">>" ToolTip="Sonraki Ürün"
                                        OnClick="btnUrunAyrintiSonraki_Click" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <uc1:ucUrunAyrinti ID="ucUrunAyrinti1" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td align="center">
                    <div id="divOnerilenFiyatAciklama" style="padding: 3px 3px 3px 3px; font-family: Verdana; font-size: 10px;
                        color: #FFFFFF; background-color: Red; ">
                        Önerilen Satış Fiyatında hesaplanan fiyattaki şarzlama yüzdesini "Üye İşlemleri" menüsünden değiştirebilirsiniz.
                    </div>
                    <table style="font-family: Verdana; font-size: 11px; color: #D00000"><tr>
                        <td style="width: 90px; text-align: center; text-decoration: underline">Brüt Fiyat</td>
                        <td style="width: 20px; text-align: center; text-decoration: underline">İ.1</td>
                        <td style="width: 20px; text-align: center; text-decoration: underline">İ.2</td>
                        <td style="width: 20px; text-align: center; text-decoration: underline">İ.3</td>
                        <td style="width: 20px; text-align: center; text-decoration: underline">İ.4</td>
                        <td style="width: 20px; text-align: center; text-decoration: underline">İ.5</td>
                        <td style="width: 20px; text-align: center; text-decoration: underline">İ.6</td>
                        <td style="width: 20px; text-align: center; text-decoration: underline">İ.7</td>
                        <td style="width: 20px; text-align: center; text-decoration: underline">İ.8</td>
                        <td style="width: 20px; text-align: center; text-decoration: underline">İ.9</td>
                        <td style="width: 20px; text-align: center; text-decoration: underline">İ.10</td>
                        <td style="width: 50px; text-align: center; text-decoration: underline">KDV</td>
                        <td style="width: 50px; text-align: center; text-decoration: underline"><asp:Label runat="server" Text="Vade" Visible='<%# ((Sultanlar.DatabaseObject.Internet.Musteriler)Session["Musteri"]).tintUyeTipiID != 1 %>'></asp:Label></td>
                        <td style="width: 90px; text-align: center; text-decoration: underline">NET+KDV</td>
                        <td style="width: 150px; text-align: center; text-decoration: underline">Önerilen Satış Fiyatı<%--<span class="hotspot" onmouseover="document.getElementById('divOnerilenFiyatAciklama').style.visibility = 'visible'" onmouseout="document.getElementById('divOnerilenFiyatAciklama').style.visibility = 'hidden'">Önerilen Satış Fiyatı</span>--%></td>
                        <td style="width: 170px; text-align: center; font-size: 12px; color: #000000">
                        </td>
                    </tr></table>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                    <table style="font-family: Verdana; font-size: 11px;"><tr>
                        <td style="width: 90px; text-align: center"><asp:Label runat="server" ID="lblUrunAyrintiBrut"></asp:Label></td>
                        <td style="width: 20px; text-align: center"><asp:Label runat="server" ID="lblUrunAyrintiIsk1"></asp:Label></td>
                        <td style="width: 20px; text-align: center"><asp:Label runat="server" ID="lblUrunAyrintiIsk2"></asp:Label></td>
                        <td style="width: 20px; text-align: center"><asp:Label runat="server" ID="lblUrunAyrintiIsk3"></asp:Label></td>
                        <td style="width: 20px; text-align: center"><asp:Label runat="server" ID="lblUrunAyrintiIsk4"></asp:Label></td>
                        <td style="width: 20px; text-align: center"><asp:Label runat="server" ID="lblUrunAyrintiIsk5"></asp:Label></td>
                        <td style="width: 20px; text-align: center"><asp:Label runat="server" ID="lblUrunAyrintiIsk6"></asp:Label></td>
                        <td style="width: 20px; text-align: center"><asp:Label runat="server" ID="lblUrunAyrintiIsk7"></asp:Label></td>
                        <td style="width: 20px; text-align: center"><asp:Label runat="server" ID="lblUrunAyrintiIsk8"></asp:Label></td>
                        <td style="width: 20px; text-align: center"><asp:Label runat="server" ID="lblUrunAyrintiIsk9"></asp:Label></td>
                        <td style="width: 20px; text-align: center"><asp:Label runat="server" ID="lblUrunAyrintiIsk10"></asp:Label></td>
                        <td style="width: 50px; text-align: center"><asp:Label runat="server" ID="lblUrunAyrintiKDV"></asp:Label></td>
                        <td style="width: 50px; text-align: center"><asp:Label runat="server" ID="lblUrunAyrintiVade" Visible='<%# ((Sultanlar.DatabaseObject.Internet.Musteriler)Session["Musteri"]).tintUyeTipiID != 1 %>'></asp:Label></td>
                        <td style="width: 90px; text-align: center"><asp:Label runat="server" ID="lblUrunAyrintiFiyat"></asp:Label></td>
                        <td style="width: 150px; text-align: center"><asp:Label runat="server" ID="lblUrunAyrintiOnerilenFiyat"></asp:Label></td>
                        <td style="width: 170px; text-align: center">
                        </td>
                    </tr></table>
                    </td>
                </tr>
            </table>
            </div>


            <div style="width: 100%; font-size: 9px; font-family: Verdana; background-color: #EFEEEA; border-bottom: 1px solid #FFCFB2">
            <table cellpadding="5" cellspacing="0">
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
            <table cellpadding="5" cellspacing="0" style="width: 1000px; font-family: Tahoma;
                font-size: 10px;">
                <tr>
                    <td align="left">
                        <asp:DropDownList ID="ddlFiyatTipleri" runat="server" AutoPostBack="True" 
                            Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Size="9px" 
                            Font-Strikeout="False" Font-Underline="False" ToolTip="Fiyat Tipi" class="kucukbilgiGoster"
                            Width="180px" ForeColor="#006699" style="padding: 3px 3px 3px 3px;border:1px solid #CCCCCC;background:#ededed;"
                            onselectedindexchanged="ddlFiyatTipleri_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:DropDownList ID="ddlTaksitPlanlari" runat="server" AutoPostBack="True" 
                            Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Size="9px" 
                            Font-Strikeout="False" Font-Underline="False" ToolTip="Taksit Planı" class="kucukbilgiGoster"
                            Width="180px" ForeColor="#006699" style="padding: 3px 3px 3px 3px;border:1px solid #CCCCCC;background:#ededed;"
                            Enabled="false" Visible="false"
                            onselectedindexchanged="ddlTaksitPlanlari_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:RadioButton ID="rbMalzemeler" runat="server" Checked="True" 
                            GroupName="grpSecim" Text="Malzemeler" Font-Bold="True" Font-Size="12px" 
                            oncheckedchanged="rbMalzemeler_CheckedChanged" AutoPostBack="True" />
                        <asp:Label runat="server" Width="50px"></asp:Label>
                        <asp:RadioButton ID="rbKampanyalar" runat="server" GroupName="grpSecim" 
                            Text="Kampanyalar" Font-Bold="True" Font-Size="12px" AutoPostBack="True" 
                            oncheckedchanged="rbMalzemeler_CheckedChanged" />
                    </td>
                </tr>
            </table>
            <table runat="server" id="tblURUNLER" cellpadding="0" cellspacing="0" style="width: 1000px; font-family: Tahoma;
                font-size: 10px; height: 1000px;">
                <tr>
                    <td colspan="2" style="height: 110px; padding-bottom: 6px;" valign="bottom">
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
                </tr>
                <tr>
                    <td style="width: 900px;" align="center" valign="top">
                    <table style="width: 900px;">
                    <tr>
                    <td align="left" style="width: 202px;" valign="middle">
                        <div style="padding-right: 80px; padding-left: 7px; text-align: center; vertical-align: middle">
                            <asp:CheckBox runat="server" ID="cbYeniUrunler" Checked="false" AutoPostBack="true" OnCheckedChanged="cbYeniUrunler_CheckedChanged" ToolTip="Sadece Yeni Ürünler" class="kucukbilgiGosterSade" Text="Sadece Yeni Ürünler" />
                        </div>
                    </td>
                    <td align="left" valign="top" style="width: 700px;">
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
                        
                        <div style="width: 100%; text-align: left; padding: 0px 10px 0px 10px">
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
                                                        <%--<asp:Image runat="server" ImageUrl = '<%# Eval("pkResimID", "resim.aspx?uidO={0}")%>' BorderStyle="None" />--%>
                                                        <asp:ImageButton ID="ImageButton1" runat="server" CommandName='<%#Eval("UrunID")%>' CommandArgument='<%#Eval("pkResimID")%>' ImageUrl='<%# Eval("pkResimID", "resim.aspx?uidO={0}")%>' OnClick="ibUrunAyrinti_Click" BorderStyle="None" />
                                                    </td>
                                                    <td style="width: 25px; height: 30px; border-left: 1px solid #bfbfbf;"
                                                        valign="middle" align="center">
                                                        <span id="Span1" runat="server" style="color: Red; visibility: collapse"><%# Eval("UrunID") %></span>
                                                        <asp:ImageButton ID="ImageButton2" runat="server" CommandArgument='<%#Eval("UrunID")%>' ToolTip="Kampanyalı Ürün" ImageUrl="img/gul.png" Visible='<%#Convert.ToBoolean(Convert.ToInt32(Eval("KamKartRefSayisi")) > 0)%>' OnClick="KampanyaliUrun_Click" class="kucukbilgiGoster" />
                                                        <asp:Image ID="Image1" runat="server" ToolTip="Yeni Ürün" ImageUrl="img/yeni.png" Visible='<%#Convert.ToBoolean(Convert.ToInt32(Eval("KYTM")) < 60)%>' class="kucukbilgiGoster" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 25px; height: 55px; border-left: 1px solid #bfbfbf; border-top: 1px solid #bfbfbf;"
                                                        valign="middle" align="center">
                                                        <div runat="server" visible='<%#Convert.ToBoolean(((Sultanlar.DatabaseObject.Internet.Musteriler)Session["Musteri"]).tintUyeTipiID != 1)%>'>S<br />T<br /><br /></div>
                                                        <div runat="server" visible='<%#Convert.ToBoolean(((Sultanlar.DatabaseObject.Internet.Musteriler)Session["Musteri"]).tintUyeTipiID == 1)%>'>A<br />D<br /><br /></div>
                                                        <div runat="server" visible='<%#Convert.ToBoolean(((Sultanlar.DatabaseObject.Internet.Musteriler)Session["Musteri"]).tintUyeTipiID != 1)%>'><%--<span class="kucukbilgiGoster" title="<strong>Koli Adedi:</strong> ">--%><strong><%#Eval("Adet")%></strong><%--</span>--%></div><%--<%#Eval("STOK").ToString() != "0" ? Convert.ToInt32(Eval("STOK")).ToString("#,#") : "0"%>--%>
                                                        <div runat="server" visible='<%#Convert.ToBoolean(((Sultanlar.DatabaseObject.Internet.Musteriler)Session["Musteri"]).tintUyeTipiID == 1)%>'><strong><%#Eval("Adet")%></strong></div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 25px; height: 25px; border-left: 1px solid #bfbfbf; border-top: 1px solid #bfbfbf;"
                                                        valign="middle" align="center">
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="2" style="height: 45px">
                                            <div style="width: 150px; height: 45px; overflow: hidden; vertical-align: middle">
                                            <input type="hidden" value='<%#Eval("pkResimID") %>' id="ResimID" runat="server" />
                                            <input type="hidden" value='<%#Eval("UrunID") %>' id="UrunID" runat="server" />
                                            <asp:LinkButton ID="LinkButton1" runat="server" Text='<%# Eval("Ad") %>' OnClick="lbUrunAyrinti_Click" />
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="2" style="border-bottom: 1px solid #bfbfbf; height: 15px">
                                            <span class="kucukbilgiGoster" title=" &nbsp;&nbsp;<strong>BRÜT</strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<strong>ISK1</strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<strong>ISK2</strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<strong>ISK3</strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<strong>ISK4</strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<strong>ISK5</strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<strong>ISK6</strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<strong>ISK7</strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<strong>ISK8</strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<strong>ISK9</strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<strong>ISK10</strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<strong>KDV</strong> <br><%#Convert.ToDecimal(Eval("BRUT")).ToString("C3")%>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<%#Convert.ToDouble(Eval("ISK1")).ToString("N1")%>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<%#Convert.ToDouble(Eval("ISK2")).ToString("N1")%>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<%#Convert.ToDouble(Eval("ISK3")).ToString("N1")%>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<%#Convert.ToDouble(Eval("ISK4")).ToString("N1")%>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<%#Convert.ToDouble(Eval("ISK5")).ToString("N1")%>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<%#Convert.ToDouble(Eval("ISK6")).ToString("N1")%>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<%#Convert.ToDouble(Eval("ISK7")).ToString("N1")%>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<%#Convert.ToDouble(Eval("ISK8")).ToString("N1")%>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<%#Convert.ToDouble(Eval("ISK9")).ToString("N1")%>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<%#Convert.ToDouble(Eval("ISK10")).ToString("N1")%>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<%#Eval("KDV")%>" style="font-weight: bold"><span id="Span5" runat="server" style="color: #C00000"><%# Convert.ToDecimal(Eval("Fiyat")).ToString("N3") %></span> <span style="color: #C00000">TL</span></span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" style="width: 75px; border-right: 1px solid #bfbfbf; height: 30px">
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
                                    <tr style="color: #D00000">
                                        <td align="center" style="width: 50px; height: 35px; border-bottom-style: solid; border-bottom-width: 1px;
                                            border-bottom-color: #BFBFBF; font-weight: bold">
                                            Resim
                                        </td>
                                        <td align="center" style="width: 255px; border-bottom-style: solid; border-bottom-width: 1px;
                                            border-bottom-color: #BFBFBF; font-weight: bold">
                                            Ürün Adı
                                        </td>
                                        <td align="center" style="width: 100px; border-bottom-style: solid; border-bottom-width: 1px;
                                            border-bottom-color: #BFBFBF; font-weight: bold">
                                            <span title="NET + KDV Dahil" class="kucukbilgiGoster">Fiyat</span>
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
                                            <div runat="server" visible='<%#Convert.ToBoolean(((Sultanlar.DatabaseObject.Internet.Musteriler)Session["Musteri"]).tintUyeTipiID != 1)%>'>Vade</div>
                                        </td>
                                        <td align="center" style="width: 45px; border-bottom-style: solid; border-bottom-width: 1px;
                                            border-bottom-color: #BFBFBF; font-weight: bold">
                                            <div runat="server" visible='<%#Convert.ToBoolean(((Sultanlar.DatabaseObject.Internet.Musteriler)Session["Musteri"]).tintUyeTipiID != 1)%>'>Koli</div>
                                            <div runat="server" visible='<%#Convert.ToBoolean(((Sultanlar.DatabaseObject.Internet.Musteriler)Session["Musteri"]).tintUyeTipiID == 1)%>'>Koli</div>
                                        </td>
                                        <td align="center" style="width: 35px; border-bottom-style: solid; border-bottom-width: 1px;
                                            border-bottom-color: #BFBFBF; font-weight: bold">
                                            
                                        </td>
                                    </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr onmouseover="Satir(this,true)" onmouseout="Satir(this,false)">
                                    <td align="center" style="width: 50px; height: 50px;">
                                        <%--<asp:Image runat="server" height="25px" ImageUrl = '<%# Eval("pkResimID", "resim.aspx?uidK={0}")%>' BorderStyle="None" />--%>
                                        <div style="width:50px; height: 50px"><asp:ImageButton ID="ImageButton3" runat="server" style="max-width: 100%; max-height: 100%;" CommandArgument='<%#Eval("pkResimID")%>' CommandName='<%#Eval("UrunID")%>' ImageUrl='<%# Eval("pkResimID", "resim.aspx?uidO={0}")%>' OnClick="ibUrunAyrinti_Click" BorderStyle="None" /></div>
                                    </td>
                                    <td align="left" style="width: 255px; padding-left: 5px">
                                        <asp:ImageButton ID="ImageButton4" runat="server" CommandArgument='<%#Eval("UrunID")%>' ToolTip="Kampanyalı Ürün" ImageUrl="img/gul.png" Visible='<%#Convert.ToBoolean(Convert.ToInt32(Eval("KamKartRefSayisi")) > 0)%>' OnClick="KampanyaliUrun_Click" class="kucukbilgiGoster" />
                                        <asp:Image ID="Image2" runat="server" ToolTip="Yeni Ürün" ImageUrl="img/yeni.png" Visible='<%#Convert.ToBoolean(Convert.ToInt32(Eval("KYTM")) < 60)%>' class="kucukbilgiGoster" />
                                        <%--<asp:Panel runat="server" Visible='<%#Convert.ToBoolean(Convert.ToInt32(Eval("KamKartRefSayisi")) > 0)%>'><img src="img/gul.png" border="0" title="Kampanyalı Ürün" alt="Kampanyalı Ürün" /></asp:Panel>--%>
                                        <input type="hidden" value='<%#Eval("pkResimID") %>' id="ResimID" runat="server" />
                                        <input type="hidden" value='<%#Eval("UrunID") %>' id="UrunID" runat="server" />
                                        <strong class="classurtkod" title='olcu.aspx?id=<%#Eval("UrunID") %>' style="cursor: pointer; color: #C10000"><span style="font-weight: bold">[ÖLÇÜLER]</span></strong>
                                        <asp:LinkButton ID="LinkButton2" runat="server" Text='<%# Eval("Ad") %>' OnClick="lbUrunAyrinti_Click" />
                                        <span id="Span3" runat="server" style="color: Red; visibility: hidden"><%# Eval("UrunID") %></span>
                                    </td>
                                    <td align="center" style="width: 85px;">
                                        <span class="kucukbilgiGoster" title=" &nbsp;&nbsp;<strong>BRÜT</strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<strong>ISK1</strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<strong>ISK2</strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<strong>ISK3</strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<strong>ISK4</strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<strong>ISK5</strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<strong>ISK6</strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<strong>ISK7</strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<strong>ISK8</strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<strong>ISK9</strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<strong>ISK10</strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<strong>KDV</strong> <br><%#Convert.ToDecimal(Eval("BRUT")).ToString("C3")%>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<%#Convert.ToDouble(Eval("ISK1")).ToString("N1")%>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<%#Convert.ToDouble(Eval("ISK2")).ToString("N1")%>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<%#Convert.ToDouble(Eval("ISK3")).ToString("N1")%>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<%#Convert.ToDouble(Eval("ISK4")).ToString("N1")%>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<%#Convert.ToDouble(Eval("ISK5")).ToString("N1")%>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<%#Convert.ToDouble(Eval("ISK6")).ToString("N1")%>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<%#Convert.ToDouble(Eval("ISK7")).ToString("N1")%>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<%#Convert.ToDouble(Eval("ISK8")).ToString("N1")%>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<%#Convert.ToDouble(Eval("ISK9")).ToString("N1")%>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<%#Convert.ToDouble(Eval("ISK10")).ToString("N1")%>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<%#Eval("KDV")%>" style="font-weight: bold"><span id="Span5" runat="server" style="color: #C00000"><%# Convert.ToDecimal(Eval("Fiyat")).ToString("N3") %></span> <span style="color: #C00000">TL</span></span>
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
                                        <div runat="server" visible='<%#Convert.ToBoolean(((Sultanlar.DatabaseObject.Internet.Musteriler)Session["Musteri"]).tintUyeTipiID != 1)%>'><span class="kucukbilgiGoster"><%# Eval("VADE") %></span></div>
                                    </td>
                                    <td align="center" style="width: 45px;">
                                        <div runat="server" visible='<%#Convert.ToBoolean(((Sultanlar.DatabaseObject.Internet.Musteriler)Session["Musteri"]).tintUyeTipiID != 1)%>'><%--<span class="kucukbilgiGoster" title="<strong>Koli Adedi:</strong> ">--%><strong><%#Eval("Adet")%></strong><%--</span>--%></div><%--<%#Eval("STOK").ToString() != "0" ? Convert.ToInt32(Eval("STOK")).ToString("#,#") : "0"%>--%>
                                        <div runat="server" visible='<%#Convert.ToBoolean(((Sultanlar.DatabaseObject.Internet.Musteriler)Session["Musteri"]).tintUyeTipiID == 1)%>'><strong><%#Eval("Adet") %></strong></div>
                                    </td>
                                    <td align="center" style="width: 35px;">
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                </table>
                            </FooterTemplate>
                        </asp:DataList>
                        <asp:Label ID="lblEmpty" Text="<br />Seçilen kriterlere göre ürün bulunamadı.<br /><br />" Font-Italic="true" runat="server"></asp:Label>

                                    <br />

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
                        <table cellpadding="0" cellspacing="0" border="0" style="width: 850px; font-size: 12px">
                            <tr>
                                <td style="text-align: center">
                                    <asp:Label runat="server" ID="lblUrunSayisi"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <uc2:ucKampanyalar ID="ucKampanyalar1" runat="server" Visible="false" />
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:Button runat="server" ID="btnMalzemelereGeriDon" Text="Malzeme Listesine Geri Dön" 
                            onclick="btnMalzemelereGeriDon_Click" BorderColor="#CCCCCC" BorderStyle="Solid" 
                            BorderWidth="1px" ForeColor="#6D8AAA" Visible="False" />
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    <br />
<uc3:ucAlt ID="ucAlt1" runat="server" />
    </form>
</body>
</html>

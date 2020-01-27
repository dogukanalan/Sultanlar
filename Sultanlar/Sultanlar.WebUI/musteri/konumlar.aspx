<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="konumlar.aspx.cs" Inherits="Sultanlar.WebUI.musteri.konumlar" %>

<%@ Register src="ucAlt.ascx" tagname="ucAlt" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Sultanlar : Konumlar</title>
    <link rel="stylesheet" type="text/css" href="StyleSheet.css" />
    
    <script type="text/javascript" src="js/jquery-1.2.6.pack.js"></script>
    <script type="text/javascript" src="js/jquery-1.8.3.js"></script>
    <script type="text/javascript" src="js/jquery-ui.js"></script>
    <link rel="stylesheet" href="js/jquery-ui.css" />
    <script type="text/javascript" src="js/scripts.js"></script>
    <script type="text/javascript" src="js/wmBox.js"></script>

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

        $(document).ready(function () {
            $.wmBox();
        });

    </script>
    <style type="text/css">
        #top{bottom:5px;right:5px;background:#147;padding:5px;color:#fff;font:bold 11px verdana;position:fixed;display:none;cursor:default;}
        [class*=dxgvTable] [class*=dxeCalendarFooter] tr { visibility: hidden !important; }
        iframe {
            border: none;
        }
        
        .wmBox_overlay{
	position:fixed;
	width:100%;
	height:100%;
	display:none;
	top:0;
	left:0;
	background:rgba(0,0,0,0.5);
}
.wmBox_centerWrap{
	display:table;
	position:absolute;
	width:100%;
	height:100%;
}
.wmBox_centerer{
	display:table-cell;
	vertical-align:middle;
}
.wmBox_centerer iframe{
	width:95%;
	display:table;
	margin:0 auto;
	position:relative;
}
.wmBox_contentWrap{
	width:50%;
	margin:0 auto;
	position:relative;
}
.wmBox_scaleWrap{
	position:relative;
	height:0;
	padding-top:20px;
	padding-bottom: 56.25%;
	width:100%;
}
.wmBox_centerer iframe{
	position:absolute;
	top:0;
	border:0;
	outline:0;
	box-shadow:0px 0px 10px rgba(0,0,0,0.5);
	left:0;
	width:100%;
	height:100%;
}
.wmBox_closeBtn{
	z-index:2;
	position:relative;
	margin-top:-40px;
}
.wmBox_closeBtn p{
	line-height:0;
	margin:0;
	padding:0.5em 0 0.75em;
	color:#FFF;
	background:#000;
	width:1.3em;
	font-size:25px;
	border-radius:100%;
	text-align:center;
	font-family:Verdana, serif;
	position:relative;
	bottom:-0.5em;
	right:-0.5em;
	cursor:pointer;
	float:right;
	box-shadow:0px 0px 10px rgba(0,0,0,0.5);
	transition:color 0.2s ease-out, background 0.2s ease-out;
}
.wmBox_closeBtn p:hover{
	background:#FFF;
	color:#000;
}
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
                <td><img src="img/marker.png" /></td>
                <td style="width: 100%">&nbsp;Konumlar<asp:Label runat="server" Width="30px"></asp:Label><input style="font-size: 10px; font-style: italic" type="button" value="Geri Dön" onclick="javascript:window.location.href='default.aspx'" /></td>
                </tr>
                </table>
                 </div>
                <br />
                <asp:DropDownList runat="server" ID="ddlTemsilciler" AutoPostBack="true" Height="25px" ForeColor="#006699" 
                    Width="500px" style="padding: 3px 3px 3px 3px;border:1px solid #CCCCCC;background:#ededed; margin-left: 10px"
                    OnSelectedIndexChanged="ddlTemsilciler_SelectedIndexChanged"></asp:DropDownList>
                <br /><br />
                <div style="font-size: 11px">
                <asp:Repeater runat="server" ID="repe">
                    <HeaderTemplate><table><tr>
                    <td style="text-align: center; width: 150px"><strong>Tip</strong></td>
                    <td style="text-align: center; width: 250px"><strong>Müşteri</strong></td>
                    <td style="text-align: center; width: 350px"><strong>Şube</strong></td>
                    <td style="text-align: center; width: 125px"><strong>Konum</strong></td>
                    <td style="text-align: center; width: 125px"><strong>Adres</strong></td>
                    </tr></HeaderTemplate>
                    <ItemTemplate><tr onmouseover="Satir(this,true)" onmouseout="Satir(this,false)">
                    <td style="text-align: center"><%#Eval("Tip") %></td>
                    <td><span><%#Eval("Müşteri") %></span></td>
                    <td><span><%#Eval("Şube") %></span></td>
                    <td style="text-align: center">

                    <%#Eval("KONUM").ToString() != string.Empty ? "<a class='wmBox' href='#' data-popup='map.aspx?lat=" + GetLat(Eval("KONUM").ToString()) + "&lng=" + GetLng(Eval("KONUM").ToString()) + "&title=" + TurkceKarakter(Eval("Şube").ToString()) + "&label=" + TurkceKarakter(Eval("Şube").ToString()[0].ToString()) + "'>GÖSTER</a>" : ""%>
                    <%#Eval("KONUM").ToString() != string.Empty ? "<a" + (((Sultanlar.DatabaseObject.Internet.Musteriler)Session["Musteri"]).tintUyeTipiID == 2 ? " target='_blank'" : "") + " href='konumal.aspx?smref=" + Eval("Kod").ToString() + "&tip=" + Eval("TIP_KOD").ToString() + "&lat=" + GetLat(Eval("KONUM").ToString()) + "&lng=" + GetLng(Eval("KONUM").ToString()) + "'>DEĞİŞTİR</a>" : ""%>
                    <%#Eval("KONUM").ToString() == string.Empty ? "<a" + (((Sultanlar.DatabaseObject.Internet.Musteriler)Session["Musteri"]).tintUyeTipiID == 2 ? " target='_blank'" : "") + " href='konumal.aspx?smref=" + Eval("Kod").ToString() + "&tip=" + Eval("TIP_KOD").ToString() + "'>KONUM AL</a>" : ""%>

                    </td>
                    <td style="text-align: center">

                    <span class="kucukbilgiGoster" title='<%#Eval("ADRES").ToString() != string.Empty ? Eval("ADRES").ToString() : ""%>'>
                    <%#Eval("ADRES").ToString() != string.Empty ? Eval("ADRES").ToString().Substring(0, 10) + "..." : ""%>
                    </span>

                    </td>
                    </tr></ItemTemplate>
                    <FooterTemplate></table></FooterTemplate>
                </asp:Repeater>
                </div>
                <br />

                <script type="text/javascript">
                    (function ($) {
                        $.wmBox = function () {
                            $('body').prepend('<div class="wmBox_overlay"><div class="wmBox_centerWrap"><div class="wmBox_centerer"><div class="wmBox_contentWrap"><div class="wmBox_scaleWrap"><div class="wmBox_closeBtn"><p>x</p></div>');
                        };
                        $('[data-popup]').click(function (e) {
                            e.preventDefault();
                            $('.wmBox_overlay').fadeIn(750);
                            var mySrc = $(this).attr('data-popup');
                            $('.wmBox_overlay .wmBox_scaleWrap').append('<iframe src="' + mySrc + '">');

                            $('.wmBox_overlay iframe').click(function (e) {
                                e.stopPropagation();
                            });
                            $('.wmBox_overlay').click(function (e) {
                                e.preventDefault();
                                $('.wmBox_overlay').fadeOut(750, function () {
                                    $(this).find('iframe').remove();
                                });
                            });
                        });
                    } (jQuery));
                </script>

            </td>
        </tr>
    </table>
    </div>
    <uc1:ucAlt ID="ucAlt1" runat="server" />
    </form>
</body>
</html>

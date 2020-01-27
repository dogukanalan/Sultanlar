<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="siparislerdurum.aspx.cs" Inherits="Sultanlar.WebUI.musteri.siparislerdurum" %>

<%@ Register src="ucAlt.ascx" tagname="ucAlt" tagprefix="uc1" %>

<%@ Register assembly="DevExpress.Web.v12.2, Version=12.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v12.2, Version=12.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
	<meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Sultanlar : Siparişler Durumu</title>
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
                <table cellpadding="0" cellspacing="0">
                <tr>
                <td><img src="img/ic_siparisler.png" /></td>
                <td style="width: 100%">Siparişler Durumu<asp:Label runat="server" Width="30px"></asp:Label><input style="font-size: 10px; font-style: italic" type="button" value="Geri Dön" onclick="javascript:window.location.href='siparisler.aspx'" /></td>
                </tr>
                </table>
                <asp:DropDownList runat="server" ID="ddlTemsilciler" AutoPostBack="true" Height="25px" ForeColor="#006699" 
                    Width="500px" style="padding: 3px 3px 3px 3px;border:1px solid #CCCCCC;background:#ededed;"></asp:DropDownList>
                <br /><br />
                <dx:ASPxGridView ID="ASPxGridView1" runat="server" 
                    DataSourceID="SqlDataSource1">
                    <SettingsText HeaderFilterSelectAll="(Hepsini Seç)" 
                        HeaderFilterShowAll="(Hepsini Göster)" HeaderFilterShowBlanks="(Boşları Göster)" 
                        HeaderFilterShowNonBlanks="(Boş Olmayanları Göster)" />
                    <SettingsLoadingPanel Text="Y&#252;kleniyor&amp;hellip;"></SettingsLoadingPanel>
                    <TotalSummary>
                    <dx:ASPxSummaryItem FieldName="Sip.Ad." ShowInGroupFooterColumn="Sip.Ad."  
                        SummaryType="Sum" DisplayFormat="{0:###,###,##0.##;-0.##;0}" />
                    <dx:ASPxSummaryItem FieldName="Tsl.Ad." ShowInGroupFooterColumn="Tsl.Ad." 
                        SummaryType="Sum" DisplayFormat="{0:###,###,##0.##;-0.##;0}" />
                    <dx:ASPxSummaryItem FieldName="İrs.Ad." ShowInGroupFooterColumn="İrs.Ad." 
                        SummaryType="Sum" DisplayFormat="{0:###,###,##0.##;-0.##;0}" />
                    <dx:ASPxSummaryItem FieldName="Bky.Ad." ShowInGroupFooterColumn="Bky.Ad." 
                        SummaryType="Sum" DisplayFormat="{0:###,###,##0.##;-0.##;0}" />
                    <dx:ASPxSummaryItem FieldName="İpt.Ad." ShowInGroupFooterColumn="İpt.Ad." 
                        SummaryType="Sum" DisplayFormat="{0:###,###,##0.##;-0.##;0}" />
                    </TotalSummary>
                    <SettingsBehavior ColumnResizeMode="Control" />
                    <SettingsPager NumericButtonCount="20" PageSize="50" Position="TopAndBottom">
                        <Summary Text="Sayfa {0} / {1} ({2} Toplam Sayfa)" />
                        <Summary Text="Sayfa {0} / {1} ({2} Toplam Sayfa)"></Summary>
                    </SettingsPager>
                    <Settings ShowFilterRow="True" ShowFooter="True" ShowHeaderFilterButton="true" />
                    <SettingsText EmptyDataRow="Gösterilecek veri bulunamadı." 
                        HeaderFilterCancelButton="İptal" HeaderFilterOkButton="Tamam" />
                    <SettingsLoadingPanel Text="Yükleniyor&amp;hellip;" />
                    <SettingsPopup>
                        <HeaderFilter Height="250px" />
                    </SettingsPopup>
                </dx:ASPxGridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ProviderName="System.Data.SqlClient" 
                ConnectionString="Data Source=10.1.1.14;Initial Catalog=KurumsalWebSAP;User ID=sultanlar;Password=megastar" 
                SelectCommand="SELECT SIP_TAR AS [Sip.Tar.],WEB_NO AS [Sip.No],SIP_NO AS [SAP No],MUST_KOD AS [M.Kod],(SELECT DISTINCT SUBE FROM [Web-Musteri] WHERE SMREF = MUST_KOD) AS [Şube],MALZ_KOD AS [Mal.Kod],[MAL ACIK] AS [Malzeme],SIP_AD AS [Sip.Ad.],TSL_AD AS [Tsl.Ad.],IRS_AD AS [İrs.Ad.],BKY_AD AS [Bky.Ad.],IPT AS [İpt.Ad.],RED_NEDENI AS [Red Nedeni] FROM SAP_SIPARIS_STR_DRM INNER JOIN [Web-Malzeme-Full] ON SAP_SIPARIS_STR_DRM.MALZ_KOD = [Web-Malzeme-Full].ITEMREF WHERE ITEMREF < 1600000 AND SIPALN_KOD = @SLSREF ORDER BY SIP_TAR DESC">
                <SelectParameters>
                    <asp:ControlParameter ControlID="ddlTemsilciler" DefaultValue="0" Name="SLSREF" 
                        PropertyName="SelectedValue" />
                </SelectParameters>
                </asp:SqlDataSource>
                
            </div>
            </td>
        </tr>
    </table>
    </div>
    <uc1:ucAlt ID="ucAlt1" runat="server" />
    </form>
</body>
</html>

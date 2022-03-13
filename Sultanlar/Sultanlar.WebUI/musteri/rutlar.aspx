<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="rutlar.aspx.cs" Inherits="Sultanlar.WebUI.musteri.rutlar" %>

<%@ Register src="ucAlt.ascx" tagname="ucAlt" tagprefix="uc1" %>

<%@ Register assembly="DevExpress.Web.v12.2, Version=12.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v12.2, Version=12.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
	<meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Sultanlar : Rutlar</title>
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
                <td><img src="img/ic_rutlar.png" /></td>
                <td style="width: 100%">Rutlar<asp:Label runat="server" Width="30px"></asp:Label>
                <input style="font-size: 10px; font-style: italic" type="button" value="Harita Rut Bugün" onclick="javascript:window.location.href='rutharita.aspx'" />
                <asp:Button runat="server" ID="btnMap2" Text="Harita Rut" OnClick="btnMap2_Click" style="font-size: 10px; font-style: italic" />
                <asp:Button runat="server" ID="btnMap5" Text="Harita Ziyaret" OnClick="btnMap5_Click" Visible="false" style="font-size: 10px; font-style: italic" />
                <input style="font-size: 10px; font-style: italic" type="button" value="Rapor Ziyaret" onclick="javascript:window.location.href='rutdagilim.aspx'" />
                <input style="font-size: 10px; font-style: italic" type="button" value="Rapor Rutlar" onclick="javascript:window.location.href='rutdagilim2.aspx'" />
                <input style="font-size: 10px; font-style: italic" type="button" value="Geri Dön" onclick="javascript:window.location.href='default.aspx'" />
                </td>
                </tr>
                </table>
                <asp:DropDownList runat="server" ID="ddlTemsilciler" AutoPostBack="true" Height="25px" ForeColor="#006699" 
                    Width="500px" style="padding: 3px 3px 3px 3px;border:1px solid #CCCCCC;background:#ededed;"></asp:DropDownList>
                <asp:DropDownList runat="server" ID="ddlTemsilcilerSecim" AutoPostBack="true" Height="25px" ForeColor="#006699" 
                    Width="100px" style="padding: 3px 3px 3px 3px;border:1px solid #CCCCCC;background:#ededed;" visible="false">
                    <asp:ListItem Text="Satıcı" Value="0" Selected="True"></asp:ListItem>
                    <asp:ListItem Text="Bayi Yön." Value="1"></asp:ListItem>
                </asp:DropDownList>
                <br /><br />

                <dx:ASPxGridView ID="ASPxGridView1" runat="server" 
                    DataSourceID="SqlDataSource1">
                    <SettingsText HeaderFilterSelectAll="(Hepsini Seç)" 
                        HeaderFilterShowAll="(Hepsini Göster)" HeaderFilterShowBlanks="(Boşları Göster)" 
                        HeaderFilterShowNonBlanks="(Boş Olmayanları Göster)" />
                    <SettingsLoadingPanel Text="Y&#252;kleniyor&amp;hellip;"></SettingsLoadingPanel>
                    <TotalSummary>
                    <dx:ASPxSummaryItem FieldName="Net" ShowInGroupFooterColumn="Net"  
                        SummaryType="Sum" DisplayFormat="{0:###,###,##0.##;-0.##;0}" />
                    <dx:ASPxSummaryItem FieldName="Koli" ShowInGroupFooterColumn="Koli" 
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
                ConnectionString="Data Source=10.10.41.2;Initial Catalog=KurumsalWebSAP;User ID=sa;Password=sdl580g5p9+-" 
                SelectCommand="
                
SELECT DISTINCT [WEB_RUT_4_LISTE].[GMREF] AS [Müş.Kod]

,[Web-Musteri-1].MUSTERI AS [Müşteri]

,[WEB_RUT_4_LISTE].[SMREF] AS [Şub.Kod]

,[Web-Musteri-1].SUBE AS [Şube]

,[TARIH] AS [Tarih],[GUN] AS [Gün]
,CASE [Web-Musteri-1].TIP WHEN 1 THEN (SELECT sum(NETT_2017) FROM [Web-Satis-Rapor-3] WHERE SMREF = [WEB_RUT_4_LISTE].SMREF) ELSE NULL END AS [Net]
,CASE [Web-Musteri-1].TIP WHEN 1 THEN (SELECT sum(KOLIT_2017) FROM [Web-Satis-Rapor-3] WHERE SMREF = [WEB_RUT_4_LISTE].SMREF) ELSE NULL END AS [Koli] 
FROM [WEB_RUT_4_LISTE] 
INNER JOIN [Web-Musteri-1] ON [WEB_RUT_4_LISTE].MTIP = [Web-Musteri-1].TIP AND [WEB_RUT_4_LISTE].SMREF = [Web-Musteri-1].SMREF
WHERE [WEB_RUT_4_LISTE].SLSREF = @SLSREF AND [TARIH] BETWEEN DATEADD(day,-1,GETDATE()) AND DATEADD(week,4,GETDATE()) 
ORDER BY [Tarih],[Müşteri],[Şube]

">
                <SelectParameters>
                    <asp:ControlParameter ControlID="ddlTemsilciler" DefaultValue="0" Name="SLSREF" 
                        PropertyName="SelectedValue" />
                    <asp:ControlParameter ControlID="ddlTemsilcilerSecim" DefaultValue="0" Name="SATICITIP" 
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

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="satishedef.aspx.cs" Inherits="Sultanlar.WebUI.musteri.satishedef" %>

<%@ Register src="ucAlt.ascx" tagname="ucAlt" tagprefix="uc1" %>

<%@ Register assembly="DevExpress.Web.v12.2, Version=12.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v12.2, Version=12.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>

<%@ Register src="ucProgress.ascx" tagname="ucProgress" tagprefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Sultanlar : Satış Hedef Raporu</title>
    <link rel="stylesheet" type="text/css" href="StyleSheet.css" />
    <script type="text/javascript">
        function invisible() {
            if (document.getElementById('divMesaj') != null) {
                window.location.href = document.getElementById('lbMesajKapat').href;
                return false;
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
    </script>

    <script type="text/javascript" src="js/jquery-1.2.6.pack.js"></script>
    <script type="text/javascript" src="js/jquery-1.8.3.js"></script>
    <script type="text/javascript" src="js/jquery-ui.js"></script>
    <link rel="stylesheet" href="js/jquery-ui.css" />
    <script type="text/javascript" src="js/scripts.js"></script>

    <script type="text/javascript" src="js/jquery.tipTip.js"></script>
    <script type="text/javascript" src="js/jquery.tipTip.minified.js"></script>
    <link rel="stylesheet" type="text/css" href="js/tipTip.css" />

</head>
<body style="margin: 0 0 0 0;background-color: #EFEEEA;">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="AjaxScripts" runat="server">
    </asp:ScriptManager>
    <script type="text/javascript">
        Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(function (evt, args) {
            $("input[type=submit], input[type=button]").button();
            $('#rbTablo').button({ icons: { primary: 'ui-icon-table', secondary: null} });
            $('#rbGrafik').button({ icons: { primary: 'ui-icon-chart', secondary: null} });
            $('#cbTumu').button({ icons: { primary: 'ui-icon-chart', secondary: null} });
        });
    </script>
    <asp:UpdateProgress runat="server" ID="upProgress"><ProgressTemplate>
        <uc2:ucProgress ID="ucProgress1" runat="server" />
    </ProgressTemplate></asp:UpdateProgress>
    <asp:UpdatePanel runat="server" ID="upSatisHedef"><ContentTemplate>
    <%--<uc3:ucMesajlar ID="ucMesajlar1" runat="server" />--%>
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
                <div style="font-size: 20px; padding: 10px 10px 10px 10px; font-family: Gisha">
                <table cellpadding="0" cellspacing="0"><tr>
                <td><img src="img/ic_ekstre.png" /></td>
                <td><a href="hesapayrinti.aspx" style="color: #A0A0A0">Ekstre</a><asp:Label runat="server" Width="40px"></asp:Label></td>
                <td><img src="img/ic_satis.png" /></td>
                <td><a href="satisrapor.aspx" style="color: #A0A0A0">Satış Raporu</a><asp:Label runat="server" Width="40px"></asp:Label></td>
                <td><asp:Image runat="server" ID="imgBorcAlacak" ImageUrl="img/ic_borcalacak.png" /></td>
                <td><asp:HyperLink runat="server" ID="hlBorcAlacak" NavigateUrl="borcalacakrapor.aspx" style="color: #A0A0A0">Borç Alacak Raporu</asp:HyperLink><asp:Label runat="server" Width="40px"></asp:Label></td>
                <td><asp:Image runat="server" ID="imgSatisHedef" ImageUrl="img/ic_satishedef.png" /></td>
                <td>Satış Hedef Raporu<asp:Label runat="server" Width="40px"></asp:Label></td>
                <td><asp:Image runat="server" ID="imgStok" ImageUrl="img/ic_satis.png" /></td>
                <td><asp:HyperLink runat="server" ID="hlStok" NavigateUrl="stok.aspx" style="color: #A0A0A0">Stok Raporu</asp:HyperLink><asp:Label ID="Label2" runat="server" Width="40px"></asp:Label></td>
                </tr></table>
                </div>
            </td>
        </tr>
        <tr>
            <td valign="top" style="height: 100%; padding-left: 20px">
                
                <asp:Label runat="server" ID="lblSatKod" style="visibility: hidden" Text="0"></asp:Label>
                <asp:Label runat="server" ID="lblBayiKod" style="visibility: hidden" Text="0"></asp:Label>

                <asp:CheckBox ID="cbSiparisci" runat="server" Checked="false" Text="Sadece siparişler" AutoPostBack="true" OnCheckedChanged="cbSiparisci_CheckedChanged" />
                <asp:DropDownList runat="server" ID="ddlBayiler" style="padding: 3px 3px 3px 3px;border:1px solid #CCCCCC;background:#ededed;"
                    OnSelectedIndexChanged="ddlBayiler_SelectedIndexChanged" Height="25px" ForeColor="#006699" 
                    Width="500px" AutoPostBack="True" Visible="false">
                </asp:DropDownList><br /><br />
                
            <dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" 
                DataSourceID="SqlDataSource1" EnableCallBacks="False"
                onsummarydisplaytext="ASPxGridView1_SummaryDisplayText" 
                onprocesscolumnautofilter="ASPxGridView1_ProcessColumnAutoFilter" 
                onpageindexchanged="ASPxGridView1_PageIndexChanged" Width="950px">
            <TotalSummary>
                <dx:ASPxSummaryItem FieldName="HEDEF" ShowInGroupFooterColumn="HEDEF" 
                    SummaryType="Sum" ValueDisplayFormat="N2" />
                <dx:ASPxSummaryItem FieldName="BEKLEYEN_TOPLAM" 
                    ShowInGroupFooterColumn="BEKLEYEN_TOPLAM" SummaryType="Sum" 
                    ValueDisplayFormat="N2" />
                <dx:ASPxSummaryItem FieldName="KOLI_TOPLAM" 
                    ShowInGroupFooterColumn="KOLI_TOPLAM" SummaryType="Sum" 
                    ValueDisplayFormat="N2" />
                <dx:ASPxSummaryItem FieldName="SATIŞ_BEKLEYEN_TOPLAM" 
                    ShowInGroupFooterColumn="SATIŞ_BEKLEYEN_TOPLAM" SummaryType="Sum" 
                    ValueDisplayFormat="N2" />
                <dx:ASPxSummaryItem DisplayFormat="1" FieldName="SATISYUZDE" 
                    ShowInGroupFooterColumn="SATISYUZDE" SummaryType="Average" 
                    ValueDisplayFormat="N2" />
                <dx:ASPxSummaryItem DisplayFormat="2" FieldName="SATISBEKLEYENYUZDE" 
                    ShowInGroupFooterColumn="SATISBEKLEYENYUZDE" SummaryType="Average" 
                    ValueDisplayFormat="N2" />
            </TotalSummary>
            <Columns>
                <dx:GridViewDataTextColumn Caption="Yıl" FieldName="YIL" VisibleIndex="1" 
                    Width="40px">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn Caption="Ay" FieldName="AY" VisibleIndex="2" 
                    Width="25px">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn Caption="İlgili" FieldName="SAT_TEM" ReadOnly="True" 
                    VisibleIndex="3" Width="150px">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn Caption="Prim Grubu" FieldName="PRIM_GRUBU" 
                    ReadOnly="True" VisibleIndex="4" Width="275px">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn Caption="Hedef (Koli)" FieldName="HEDEF" 
                    VisibleIndex="5" Width="70px">
                    <PropertiesTextEdit DisplayFormatString="N2">
                    </PropertiesTextEdit>
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn Caption="Satış (Koli)" FieldName="KOLI_TOPLAM" 
                    VisibleIndex="6" Width="70px">
                    <PropertiesTextEdit DisplayFormatString="N2">
                    </PropertiesTextEdit>
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn Caption="Bekleyen (Koli)" 
                    FieldName="BEKLEYEN_TOPLAM" VisibleIndex="7" Width="70px">
                    <PropertiesTextEdit DisplayFormatString="N2">
                    </PropertiesTextEdit>
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn Caption="Satış + Bekleyen (Koli)" 
                    FieldName="SATIŞ_BEKLEYEN_TOPLAM" VisibleIndex="8" Width="70px">
                    <PropertiesTextEdit DisplayFormatString="N2">
                    </PropertiesTextEdit>
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn Caption="Satış / Hedef (%)" FieldName="SATISYUZDE" 
                    VisibleIndex="9" Width="75px">
                    <PropertiesTextEdit DisplayFormatString="p">
                    </PropertiesTextEdit>
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn Caption="Satış + Bekleyen / Hedef (%)" 
                    FieldName="SATISBEKLEYENYUZDE" VisibleIndex="10" Width="75px">
                    <PropertiesTextEdit DisplayFormatString="p">
                    </PropertiesTextEdit>
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" />
                </dx:GridViewDataTextColumn>
            </Columns>
            <SettingsBehavior ColumnResizeMode="Control" />
            <SettingsPager NumericButtonCount="20" PageSize="168" Position="TopAndBottom">
                <Summary Text="Sayfa {0} / {1} ({2} Toplam Sayfa)" />
                <Summary Text="Sayfa {0} / {1} ({2} Toplam Sayfa)"></Summary>
            </SettingsPager>
            <Settings ShowFilterRow="True" ShowFooter="True" ShowHeaderFilterButton="true" />
            <SettingsText EmptyDataRow="Gösterilecek veri bulunamadı."
                HeaderFilterCancelButton="İptal" HeaderFilterOkButton="Tamam" />
            <SettingsText HeaderFilterSelectAll="(Hepsini Seç)" 
                HeaderFilterShowAll="(Hepsini Göster)" HeaderFilterShowBlanks="(Boşları Göster)" 
                HeaderFilterShowNonBlanks="(Boş Olmayanları Göster)" />
            <SettingsLoadingPanel Text="Yükleniyor&amp;hellip;" />
            <SettingsLoadingPanel Text="Y&#252;kleniyor&amp;hellip;"></SettingsLoadingPanel>
                <SettingsPopup>
                    <HeaderFilter Height="250px" />
                </SettingsPopup>
            </dx:ASPxGridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ProviderName="System.Data.SqlClient" 
            ConnectionString="Data Source=10.1.1.14;Initial Catalog=KurumsalWebSAP;User ID=sultanlar;Password=megastar" 
            SelectCommand="
                    
SELECT YEAR(GETDATE()) AS [YIL], 
MONTH(GETDATE()) AS [AY], 
[PERSONEL] AS SAT_TEM, 
[PRIM_GR] AS PRIM_GRUBU, 
sum([HEDEF]) AS HEDEF, 
sum([KOLI]) AS KOLI_TOPLAM, 
sum([BEKLEYEN]) AS BEKLEYEN_TOPLAM, 
sum([KOLI] + [BEKLEYEN]) AS SATIŞ_BEKLEYEN_TOPLAM, 
CASE sum([HEDEF]) WHEN 0 THEN 0 ELSE sum([KOLI]) / sum([HEDEF]) END AS SATISYUZDE, 
CASE sum([HEDEF]) WHEN 0 THEN 0 ELSE (sum([KOLI]) + sum([BEKLEYEN])) / sum([HEDEF]) END AS SATISBEKLEYENYUZDE
FROM (
SELECT [SATIS_YIL]
      ,[SATIS_AY]
      ,[BEKLEYEN_YIL]
      ,[BEKLEYEN_AY]
      ,[HEDEF_YIL]
      ,[HEDEF_AY]
      ,[YETKILI]
      ,[SAT_KOD]
      ,[PERSONEL]
      ,[SAT_KOD2]
      ,[SIPARISCI]
      ,[MUS_KOD]
      ,[MUSTERI]
      ,[KATEGORI]
      ,[ALT_KATEGORI]
      ,[PRIM_GR]
      ,[GRUP]
      ,[BOLUM]
      ,[MALZEME]
      ,[NET]
      ,[KOLI]
      ,[BEKLEYEN]
      ,[HEDEF]
FROM [dbo].[zzWeb-Satis]

UNION ALL

SELECT [SATIS_YIL]
      ,[SATIS_AY]
      ,[BEKLEYEN_YIL]
      ,[BEKLEYEN_AY]
      ,[HEDEF_YIL]
      ,[HEDEF_AY]
      ,[YETKILI]
      ,[SAT_KOD]
      ,[PERSONEL]
      ,[SAT_KOD2]
      ,[SIPARISCI]
      ,[MUS_KOD]
      ,[MUSTERI]
      ,[KATEGORI]
      ,[ALT_KATEGORI]
      ,[PRIM_GR]
      ,[GRUP]
      ,[BOLUM]
      ,[MALZEME]
      ,[NET]
      ,[KOLI]
      ,[BEKLEYEN]
      ,[HEDEF]
FROM [dbo].[zzWeb-Bekleyen]

UNION ALL

SELECT [SATIS_YIL]
      ,[SATIS_AY]
      ,[BEKLEYEN_YIL]
      ,[BEKLEYEN_AY]
      ,[HEDEF_YIL]
      ,[HEDEF_AY]
      ,[YETKILI]
      ,[SAT_KOD]
      ,[PERSONEL]
      ,[SAT_KOD2]
      ,[SIPARISCI]
      ,[MUS_KOD]
      ,[MUSTERI]
      ,[KATEGORI]
      ,[ALT_KATEGORI]
      ,[PRIM_GR]
      ,[GRUP]
      ,[BOLUM]
      ,[MALZEME]
      ,[NET]
      ,[KOLI]
      ,[BEKLEYEN]
      ,[HEDEF]
FROM [dbo].[zzWeb-Hedef]
) AS TABLO
WHERE ([SATIS_YIL] = YEAR(GETDATE()) OR [SATIS_YIL] = 0)  AND ([BEKLEYEN_YIL] = YEAR(GETDATE()) OR [BEKLEYEN_YIL] = 0) AND ([HEDEF_YIL] = YEAR(GETDATE()) OR [HEDEF_YIL] = 0)
AND ([SATIS_AY] = MONTH(GETDATE()) OR [SATIS_AY] = 0) 
AND ([HEDEF_AY] = MONTH(GETDATE()) OR [HEDEF_AY] = 0) 
AND ([BEKLEYEN_AY] = 0 OR [BEKLEYEN_AY] = MONTH(GETDATE()) OR [BEKLEYEN_AY] = MONTH(GETDATE()) - 1 OR [BEKLEYEN_AY] = MONTH(GETDATE()) - 2)
AND SAT_KOD = @SAT_KOD
GROUP BY [PERSONEL], [PRIM_GR]

                    " onselecting="SqlDataSource1_Selecting">
            <SelectParameters>
                <asp:ControlParameter ControlID="lblSatKod" Name="SAT_KOD" />
            </SelectParameters>
                </asp:SqlDataSource>

                
            </td>
        </tr>
    </table><br /></div>
    </ContentTemplate></asp:UpdatePanel>
<uc1:ucAlt ID="ucAlt1" runat="server" />
    </form>
</body>
</html>

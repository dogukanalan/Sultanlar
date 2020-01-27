<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="borcalacakrapor.aspx.cs" Inherits="Sultanlar.WebUI.musteri.borcalacakrapor" %>

<%@ Register src="ucAlt.ascx" tagname="ucAlt" tagprefix="uc1" %>

<%@ Register src="ucProgress.ascx" tagname="ucProgress" tagprefix="uc2" %>

<%@ Register src="ucMesajlar.ascx" tagname="ucMesajlar" tagprefix="uc3" %>

<%@ Register assembly="DevExpress.Web.v12.2, Version=12.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v12.2, Version=12.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Sultanlar : Borç Alacak Raporu</title>
<link rel="stylesheet" type="text/css" href="StyleSheet.css" />
    <script type="text/javascript">
        function invisible() {
            if (document.getElementById('divEkstreKaydet') != null) {
                window.location.href = document.getElementById('lbEkstreKaydetKapat').href;
                return false;
            }
        }
        function Yazdir() {
            yenipen = window.open('ekstreyazdir.aspx', '_blank', 'toolbar=no,location=no,status=no,menubar=no,scrollbars=yes,width=1024,height=480,noresize');
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
            $('#cbVGB').button();
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

    <uc3:ucMesajlar ID="ucMesajlar1" runat="server" />
    
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
                <td><a href="hesapayrinti.aspx" style="color: #A0A0A0">Ekstre</a><asp:Label runat="server" Width="40px"></asp:Label></td>
                <td><img src="img/ic_satis.png" /></td>
                <td><a href="satisrapor.aspx" style="color: #A0A0A0">Satış Raporu</a><asp:Label runat="server" Width="40px"></asp:Label></td>
                <td><asp:Image runat="server" ID="imgBorcAlacak" ImageUrl="img/ic_borcalacak.png" /></td>
                <td>Borç Alacak Raporu<asp:Label runat="server" Width="40px"></asp:Label></td>
                <td><asp:Image runat="server" ID="imgSatisHedef" ImageUrl="img/ic_satishedef.png" Visible="false" /></td>
                <td><asp:HyperLink runat="server" ID="hlSatisHedef" NavigateUrl="satishedef.aspx" Visible="false" style="color: #A0A0A0">Satış Hedef Raporu</asp:HyperLink><asp:Label ID="Label5" runat="server" Width="40px"></asp:Label></td>
                <td><asp:Image runat="server" ID="imgStok" ImageUrl="img/ic_satis.png" Visible="false" /></td>
                <td><asp:HyperLink runat="server" ID="hlStok" NavigateUrl="stok.aspx" Visible="false" style="color: #A0A0A0">Stok Raporu</asp:HyperLink><asp:Label ID="Label2" runat="server" Width="40px"></asp:Label></td>
                </tr></table>
                </div>
            </td>
        </tr>
        <tr>
            <td valign="top" style="height: 100%; padding-left: 5px">
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
                    <dx:ASPxSummaryItem FieldName="BORC" ShowInGroupFooterColumn="BORC"  
                        SummaryType="Sum" DisplayFormat="{0:###,###,##0.##;-###,###,##0.##;0}" />
                    <dx:ASPxSummaryItem FieldName="ALACAK" ShowInGroupFooterColumn="ALACAK" 
                        SummaryType="Sum" DisplayFormat="{0:###,###,##0.##;-###,###,##0.##;0}" />
                    <dx:ASPxSummaryItem FieldName="BAKIYE" ShowInGroupFooterColumn="BAKIYE" 
                        SummaryType="Sum" DisplayFormat="{0:###,###,##0.##;-###,###,##0.##;0}" />
                    <dx:ASPxSummaryItem FieldName="VGB" ShowInGroupFooterColumn="VGB" 
                        SummaryType="Sum" DisplayFormat="{0:###,###,##0.##;-###,###,##0.##;0}" />
                    <dx:ASPxSummaryItem FieldName="CEK" ShowInGroupFooterColumn="CEK" 
                        SummaryType="Sum" DisplayFormat="{0:###,###,##0.##;-###,###,##0.##;0}" />
                    <dx:ASPxSummaryItem FieldName="SNT" ShowInGroupFooterColumn="SNT" 
                        SummaryType="Sum" DisplayFormat="{0:###,###,##0.##;-###,###,##0.##;0}" />
                    <dx:ASPxSummaryItem FieldName="RISK_TOP" ShowInGroupFooterColumn="RISK_TOP" 
                        SummaryType="Sum" DisplayFormat="{0:###,###,##0.##;-###,###,##0.##;0}" />
                    <dx:ASPxSummaryItem FieldName="RISK LMT" ShowInGroupFooterColumn="RISK LMT" 
                        SummaryType="Sum" DisplayFormat="{0:###,###,##0.##;-###,###,##0.##;0}" />
                    <dx:ASPxSummaryItem FieldName="TEMINAT" ShowInGroupFooterColumn="TEMINAT" 
                        SummaryType="Sum" DisplayFormat="{0:###,###,##0.##;-###,###,##0.##;0}" />
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
                <br />
                <asp:Button runat="server" ID="btnExport" Text="Excel'e Aktar" OnClick="btnExport_Click" />
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ProviderName="System.Data.SqlClient" 
                ConnectionString="Data Source=10.1.1.14;Initial Catalog=KurumsalWebSAP;User ID=sultanlar;Password=megastar" 
                SelectCommand="SELECT [DRM],[MUSTERI],[BORC],[ALACAK],[BAKIYE],[BKY_TAR] AS 'ORT_VD',[VGB],[VGB_VD],[CEK],[SNT],[RISK_TOP],[RISK LMT],[TEMINAT] FROM [SAP_B_A_Web] WHERE DRM = 'AKT' AND [SAT KOD] = @SLSREF ORDER BY MUSTERI">
                <SelectParameters>
                    <asp:ControlParameter ControlID="ddlTemsilciler" DefaultValue="0" Name="SLSREF" 
                        PropertyName="SelectedValue" />
                </SelectParameters>
                </asp:SqlDataSource>
            </td>
        </tr>
    </table><br /></div>

<uc1:ucAlt ID="ucAlt1" runat="server" />
    </form>
</body>
</html>

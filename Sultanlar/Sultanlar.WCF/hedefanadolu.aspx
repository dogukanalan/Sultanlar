<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="hedefanadolu.aspx.cs" Inherits="Sultanlar.WCF.hedefanadolu" %>

<%@ Register assembly="DevExpress.Web.v12.2, Version=12.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v12.2, Version=12.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="cache-control" content="no-cache" />
    <title></title>
    <script type="text/javascript" src="JScript.js"></script>
    <link rel="Stylesheet" type="text/css" href="StyleSheet.css" />
</head>
<body>
    <form id="form1" runat="server">
    <a class="button" href="giris.aspx" onclick="Goster()">Geri Dön</a>
        <dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" 
        DataSourceID="SqlDataSource1" Font-Size="10px" Width="100%"
        onsummarydisplaytext="ASPxGridView1_SummaryDisplayText">
        <Columns>
            <dx:GridViewCommandColumn VisibleIndex="0" MinWidth="5" Width="1%">
                <ClearFilterButton Visible="True">
                </ClearFilterButton>
            </dx:GridViewCommandColumn>
            <dx:GridViewDataTextColumn FieldName="MUSTERI" VisibleIndex="2" 
                Caption="Müşteri" MinWidth="50" Width="39%">
                <Settings HeaderFilterMode="CheckedList" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="HEDEF" VisibleIndex="3" 
                Caption="Hedef" MinWidth="30" Width="25%">
                    <PropertiesTextEdit DisplayFormatString="N0">
                    </PropertiesTextEdit>
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="SATIS" VisibleIndex="4" 
                Caption="Sat+Bek" MinWidth="30" Width="25%">
                    <PropertiesTextEdit DisplayFormatString="N0">
                    </PropertiesTextEdit>
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="ORAN" VisibleIndex="5" Caption="Oran" 
                MinWidth="20" Width="10%">
                    <PropertiesTextEdit DisplayFormatString="P2">
                    </PropertiesTextEdit>
            </dx:GridViewDataTextColumn>
        </Columns>
            <TotalSummary>
                <dx:ASPxSummaryItem FieldName="HEDEF" ShowInGroupFooterColumn="HEDEF" 
                    SummaryType="Sum" ValueDisplayFormat="N0" />
                <dx:ASPxSummaryItem FieldName="SATIS" ShowInGroupFooterColumn="SATIS" 
                    SummaryType="Sum" ValueDisplayFormat="N0" />
                <dx:ASPxSummaryItem FieldName="ORAN" ShowInGroupFooterColumn="ORAN" 
                    SummaryType="Average" ValueDisplayFormat="P2" DisplayFormat="1" />
            </TotalSummary>
        <SettingsPager PageSize="100">
        </SettingsPager>
        <Settings ShowFilterRow="True" ShowFooter="True" ShowHeaderFilterButton="true" />

<Settings ShowFilterRow="True" ShowFooter="True" columnminwidth="30"></Settings>
    </dx:ASPxGridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="Data Source=10.1.1.14;Initial Catalog=KurumsalWebSAP;Persist Security Info=True;User ID=sultanlar;Password=pazarlama" 
        ProviderName="System.Data.SqlClient" SelectCommand="">
    </asp:SqlDataSource>
    </form>
</body>
</html>

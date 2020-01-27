<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="matruska.aspx.cs" Inherits="Sultanlar.WCF.matruska" %>

<%@ Register assembly="DevExpress.Web.v12.2, Version=12.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v12.2, Version=12.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
            <dx:GridViewDataTextColumn FieldName="MUSTERI" VisibleIndex="1" 
                Caption="Müşteri" MinWidth="50" Width="39%">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="CIRO_2017" VisibleIndex="2" 
                Caption="Ciro 2016" MinWidth="30" Width="25%">
                    <PropertiesTextEdit DisplayFormatString="N0">
                    </PropertiesTextEdit>
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="CIRO_2018" VisibleIndex="3" 
                Caption="Ciro 2017" MinWidth="30" Width="25%">
                    <PropertiesTextEdit DisplayFormatString="N0">
                    </PropertiesTextEdit>
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="BUYUME" VisibleIndex="4" Caption="Büyüme" 
                MinWidth="20" Width="10%">
                    <PropertiesTextEdit DisplayFormatString="P2">
                    </PropertiesTextEdit>
            </dx:GridViewDataTextColumn>
        </Columns>
            <TotalSummary>
                <dx:ASPxSummaryItem FieldName="CIRO_2017" ShowInGroupFooterColumn="CIRO_2017" 
                    SummaryType="Sum" ValueDisplayFormat="N0" />
                <dx:ASPxSummaryItem FieldName="CIRO_2018" ShowInGroupFooterColumn="CIRO_2018" 
                    SummaryType="Sum" ValueDisplayFormat="N0" />
                <dx:ASPxSummaryItem FieldName="BUYUME" ShowInGroupFooterColumn="BUYUME" 
                    SummaryType="Average" ValueDisplayFormat="P2" DisplayFormat="1" />
            </TotalSummary>
        <SettingsPager PageSize="100">
        </SettingsPager>
        <Settings ShowFilterRow="True" ShowFooter="True" />

<Settings ShowFilterRow="True" ShowFooter="True" columnminwidth="30"></Settings>
    </dx:ASPxGridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="Data Source=10.1.1.14;Initial Catalog=KurumsalWebSAP;Persist Security Info=True;User ID=sultanlar;Password=pazarlama" 
        ProviderName="System.Data.SqlClient" SelectCommand="SELECT * FROM [_1_Ilk100]">
    </asp:SqlDataSource>
    </form>
</body>
</html>

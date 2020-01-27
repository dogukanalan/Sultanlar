<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="hedef.aspx.cs" Inherits="Sultanlar.WebUI.musteri.hedef" %>

<%@ Register assembly="DevExpress.Web.v12.2, Version=12.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v12.2, Version=12.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" 
            DataSourceID="SqlDataSource1" EnableTheming="True" 
            onsummarydisplaytext="ASPxGridView1_SummaryDisplayText" Theme="Aqua">
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
                <dx:GridViewCommandColumn ShowSelectCheckbox="True" VisibleIndex="0">
                </dx:GridViewCommandColumn>
                <dx:GridViewDataTextColumn Caption="Yıl" FieldName="YIL" VisibleIndex="1" 
                    Width="40px">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn Caption="Ay" FieldName="AY" VisibleIndex="2" 
                    Width="25px">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn Caption="Satıcı" FieldName="SAT_TEM" ReadOnly="True" 
                    VisibleIndex="3" Width="100px">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn Caption="Prim Grubu" FieldName="PRIM_GRUBU" 
                    ReadOnly="True" VisibleIndex="4" Width="120px">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn Caption="Hedef (Koli)" FieldName="HEDEF" 
                    VisibleIndex="5" Width="75px">
                    <PropertiesTextEdit DisplayFormatString="N2">
                    </PropertiesTextEdit>
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn Caption="Satış (Koli)" FieldName="KOLI_TOPLAM" 
                    VisibleIndex="6" Width="75px">
                    <PropertiesTextEdit DisplayFormatString="N2">
                    </PropertiesTextEdit>
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn Caption="Bekleyen (Koli)" 
                    FieldName="BEKLEYEN_TOPLAM" VisibleIndex="7" Width="75px">
                    <PropertiesTextEdit DisplayFormatString="N2">
                    </PropertiesTextEdit>
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn Caption="Satış + Bekleyen (Koli)" 
                    FieldName="SATIŞ_BEKLEYEN_TOPLAM" VisibleIndex="8" Width="75px">
                    <PropertiesTextEdit DisplayFormatString="N2">
                    </PropertiesTextEdit>
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn Caption="Satış / Hedef (%)" FieldName="SATISYUZDE" 
                    VisibleIndex="9" Width="100px">
                    <PropertiesTextEdit DisplayFormatString="N2">
                    </PropertiesTextEdit>
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn Caption="Satış + Bekleyen / Hedef (%)" 
                    FieldName="SATISBEKLEYENYUZDE" VisibleIndex="10" Width="100px">
                    <PropertiesTextEdit DisplayFormatString="N2">
                    </PropertiesTextEdit>
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </dx:GridViewDataTextColumn>
            </Columns>
            <SettingsPager NumericButtonCount="20" PageSize="168" Position="TopAndBottom">
                <Summary Text="Sayfa {0} / {1} ({2} Toplam Sayfa)" />
            </SettingsPager>
            <Settings ShowFilterRow="True" ShowFooter="True" />
            <SettingsLoadingPanel Text="Yükleniyor&amp;hellip;" />
        </dx:ASPxGridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="Data Source=SERVERDB01;Initial Catalog=KurumsalWebSAP;User ID=rapor;Password=rapor" 
            SelectCommand="SELECT [YIL], [AY], [SAT TEM] AS SAT_TEM, [PRIM GRUBU] AS PRIM_GRUBU, [HEDEF], [KOLI TOPLAM] AS KOLI_TOPLAM, [BEKLEYEN TOPLAM] AS BEKLEYEN_TOPLAM, [SATIŞ BEKLEYEN TOPLAM] AS SATIŞ_BEKLEYEN_TOPLAM, [KOLI / HEDEF YÜZDE] AS SATISYUZDE, [SATIŞ BEKLEYEN / HEDEF YÜZDE] AS SATISBEKLEYENYUZDE FROM [Web-Hedef-Satis-Personel]
WHERE [SAT KOD] = @Satkod">
            <SelectParameters>
                <asp:Parameter DefaultValue="1351" Name="Satkod" />
            </SelectParameters>
        </asp:SqlDataSource>
    </div>
    </form>
</body>
</html>

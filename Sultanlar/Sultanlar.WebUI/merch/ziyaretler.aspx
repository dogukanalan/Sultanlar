<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ziyaretler.aspx.cs" Inherits="Sultanlar.WebUI.merch.ziyaretler" %>

<%@ Register src="ucProgress.ascx" tagname="ucProgress" tagprefix="uc1" %>
<%@ Register src="ucUst.ascx" tagname="ucUst" tagprefix="uc2" %>
<%@ Register src="ucAlt.ascx" tagname="ucAlt" tagprefix="uc3" %>

<%@ Register assembly="DevExpress.Web.v12.2, Version=12.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v12.2, Version=12.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="cache-control" content="no-cache" />
    <meta name="viewport" content="width=device-width,initial-scale=1">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="StyleSheet.css" />
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script type="text/javascript" src="JScript.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            if (getParameterByName('slsref') == null) {
                document.getElementById('ddlTemsilciler').value = 0;
            }
            else {
                document.getElementById('ddlTemsilciler').value = getParameterByName('slsref');
            }
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="login-page">
            <div class="form">
                <uc2:ucUst ID="ucUst" runat="server" />
                <%--<a class="button" href="menu.aspx" onclick="Goster()">Geri Dön</a>--%>
                <asp:DropDownList runat="server" ID="ddlTemsilciler" Height="25px" ForeColor="#006699" 
                    Width="100%" style="padding: 3px 3px 3px 3px;border:1px solid #CCCCCC;background:#ededed;"></asp:DropDownList>
                <dx:ASPxGridView ID="ASPxGridView1" runat="server" 
                    DataSourceID="SqlDataSource1">
                    <SettingsText HeaderFilterSelectAll="(Hepsini Seç)" 
                        HeaderFilterShowAll="(Hepsini Göster)" HeaderFilterShowBlanks="(Boşları Göster)" 
                        HeaderFilterShowNonBlanks="(Boş Olmayanları Göster)" />
                    <SettingsLoadingPanel Text="Y&#252;kleniyor&amp;hellip;"></SettingsLoadingPanel>
                    <TotalSummary>
                    </TotalSummary>
                    <SettingsBehavior ColumnResizeMode="Control" />
                    <SettingsPager NumericButtonCount="2" PageSize="50" Position="TopAndBottom">
                        <Summary Text="Sayfa {0} / {1} ({2} Satır)" />
                        <Summary Text="Sayfa {0} / {1} ({2} Satır)"></Summary>
                    </SettingsPager>
                    <Settings ShowFilterRow="True" ShowFooter="True" ShowHeaderFilterButton="true" />
                    <SettingsText EmptyDataRow="Gösterilecek veri bulunamadı." 
                        HeaderFilterCancelButton="İptal" HeaderFilterOkButton="Tamam" />
                    <SettingsLoadingPanel Text="Yükleniyor&amp;hellip;" />
                    <SettingsPopup>
                        <HeaderFilter Height="250px" />
                    </SettingsPopup>
                    <Columns>
                        <dx:GridViewDataTextColumn Caption="R.Tip" FieldName="RUT_ TIP" VisibleIndex="1" 
                            Width="10%">
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Şube" FieldName="SUBE" VisibleIndex="2" 
                            Width="32%">
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" />
                            <DataItemTemplate>
                                <%# "<a style='text-decoration: none; color: gray' href='resimler.aspx?rutid=" + Eval("RUT_ID_E").ToString() + "'>" + Eval("SUBE").ToString() + "</a>"%>
                            </DataItemTemplate>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataDateColumn Caption="Tarih" FieldName="TARIH" VisibleIndex="3" 
                            Width="22%">
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" />
                        </dx:GridViewDataDateColumn>
                        <dx:GridViewDataTextColumn Caption="Ziy.Baş." FieldName="ZIY_BAS" VisibleIndex="4" 
                            Width="12%">
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Ziy.Bit." FieldName="ZIY_BIT" VisibleIndex="5" 
                            Width="12%">
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Fark" FieldName="FARK" VisibleIndex="6"
                            Width="12%">
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" />
                            <DataItemTemplate>
                                <%# "<a style='text-decoration: none; color: gray' href='../musteri/map.aspx?konum1=" + Eval("RUT_KONUM").ToString() + "&konum2=" + Eval("ZIY_KONUM").ToString() + "&fark=" + Eval("FARK").ToString() + "'>" + Eval("FARK").ToString() + "</a>"%>
                            </DataItemTemplate>
                        </dx:GridViewDataTextColumn>
                    </Columns>
                </dx:ASPxGridView>
                
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ProviderName="System.Data.SqlClient" 
                ConnectionString="Data Source=10.1.1.14;Initial Catalog=KurumsalWebSAP;User ID=sultanlar;Password=megastar" 
                SelectCommand="
                
SELECT RUT_ID_E,[RUT_ TIP],[SB_ACK] AS SUBE,[TARIH]
,convert(char(5), [ZIY_BAS_TAR], 108) AS ZIY_BAS,convert(char(5), [ZIY_BIT_TAR], 108) AS ZIY_BIT
,FARK_KNM_ZIY AS FARK,RUT_KONUM,ZIY_KONUM
FROM [Web_Rut_9_Ziyaretler] 
WHERE SAT_KOD = @SLSREF ORDER BY [ZIY_BAS_TAR] DESC

                ">
                <SelectParameters>
                    <asp:ControlParameter ControlID="ddlTemsilciler" DefaultValue="0" Name="SLSREF" 
                        PropertyName="SelectedValue" />
                </SelectParameters>
                </asp:SqlDataSource>
                <script type="text/javascript">
                    $('#ddlTemsilciler').change(function () {
                        var val = $("#ddlTemsilciler option:selected").val();
                        window.location.href = 'ziyaretler.aspx?slsref=' + val;
                    });
                </script>
                <uc3:ucAlt ID="ucAlt1" runat="server" />
                <uc1:ucProgress ID="ucProgress1" runat="server" />
            </div>
        </div>
    </form>
</body>
</html>

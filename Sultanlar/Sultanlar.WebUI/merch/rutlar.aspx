<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="rutlar.aspx.cs" Inherits="Sultanlar.WebUI.merch.rutlar" %>

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
                </dx:ASPxGridView>

                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ProviderName="System.Data.SqlClient" 
                ConnectionString="Data Source=10.1.1.14;Initial Catalog=KurumsalWebSAP;User ID=sultanlar;Password=megastar" 
                SelectCommand="
                
SELECT DISTINCT MUSTERI AS [Müşteri],SUBE AS [Şube]
,[TARIH] AS [Tarih],[GUN] AS [Gün] 
FROM [WEB_RUT_4_LISTE] 
INNER JOIN [Web-Musteri-1] ON [WEB_RUT_4_LISTE].MTIP = [Web-Musteri-1].TIP AND [WEB_RUT_4_LISTE].SMREF = [Web-Musteri-1].SMREF
WHERE [WEB_RUT_4_LISTE].SLSREF = @SLSREF AND [TARIH] BETWEEN DATEADD(day,-1,GETDATE()) AND DATEADD(week,4,GETDATE()) 
ORDER BY [Tarih],[Müşteri],[Şube]

">
                <SelectParameters>
                    <asp:ControlParameter ControlID="ddlTemsilciler" DefaultValue="0" Name="SLSREF" 
                        PropertyName="SelectedValue" />
                </SelectParameters>
                </asp:SqlDataSource>
                <script type="text/javascript">
                    $('#ddlTemsilciler').change(function () {
                        var val = $("#ddlTemsilciler option:selected").val();
                        window.location.href = 'rutlar.aspx?slsref=' + val;
                    });
                </script>
                <uc3:ucAlt ID="ucAlt1" runat="server" />
                <uc1:ucProgress ID="ucProgress1" runat="server" />
            </div>
        </div>
    </form>
</body>
</html>

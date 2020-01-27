<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="gorseller.aspx.cs" Inherits="Sultanlar.WebUI.musteri.gorseller" %>

<%@ Register assembly="DevExpress.Web.v12.2, Version=12.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v12.2, Version=12.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>

<%@ Register src="ucAlt.ascx" tagname="ucAlt" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Sultanlar : Görseller</title>
    <link rel="stylesheet" type="text/css" href="StyleSheet.css" />

    <script type="text/javascript" src="js/jquery-1.2.6.pack.js"></script>
    <script type="text/javascript" src="js/jquery-1.8.3.js"></script>
    <script type="text/javascript" src="js/jquery-ui.js"></script>
    <link rel="stylesheet" href="js/jquery-ui.css" />
    <script type="text/javascript" src="js/scripts.js"></script>
</head>
<body style="margin: 0 0 0 0;background-color: #EFEEEA;">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <script type="text/javascript">
        Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(function (evt, args) {
            $('#rbGelenKutusu').button();
            $('#rbGidenKutusu').button();
            $("input[type=submit], input[type=button]").button();
        });
        function grid_SelectionChanged(s, e) {
            var id = s.GetRowKey(e.visibleIndex);
            ASPxGridView1.PerformCallback(id);
        }
    </script>

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
    <div style="width: 1000px; background-position: center center; background-image: url('img/bg-logo.jpg'); background-repeat: no-repeat;">
        <div class="Baslik">
        <table cellpadding="0" cellspacing="0"><tr>
        <td><img src="img/ic_rutlar.png" /></td>
        <td>Ürün Görselleri</td>
        </tr></table>
        </div>
        <div style="padding-left: 10px">

            <table><tr><td align="center" valign="top">Malzemeler
            <dx:ASPxGridView ID="ASPxGridView1" runat="server" 
                    AutoGenerateColumns="False" 
                    KeyFieldName="RESIMID" 
                    onrowdeleting="ASPxGridView1_RowDeleting" DataSourceID="SqlDataSource1">
                <Columns>
                    <dx:GridViewCommandColumn VisibleIndex="1" Visible="False">
                        <DeleteButton Text="İndir" Visible="True">
                        </DeleteButton>
                    </dx:GridViewCommandColumn>
                    <dx:GridViewDataTextColumn Visible="false" FieldName="RESIMID">
                        <CellStyle Font-Size="9px">
                        </CellStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Kod" FieldName="ITEMREF" VisibleIndex="2"
                        Width="70px">
                        <HeaderStyle HorizontalAlign="Center" />
                        <CellStyle Font-Size="9px" HorizontalAlign="Center">
                        </CellStyle>
                        <DataItemTemplate><a href='resim.aspx?fid=<%#Eval("RESIMID")%>&count=1'><%#Eval("ITEMREF")%></a></DataItemTemplate>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Ürün" FieldName="MALZEME" VisibleIndex="3" 
                        Width="400px">
                        <HeaderStyle HorizontalAlign="Center" />
                        <CellStyle Font-Size="9px">
                        </CellStyle>
                    <Settings AutoFilterCondition="Contains" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Grup" FieldName="OZELACIK" VisibleIndex="4"
                        Width="60px">
                        <HeaderStyle HorizontalAlign="Center" />
                        <CellStyle Font-Size="9px" HorizontalAlign="Center">
                        </CellStyle>
                    <Settings AutoFilterCondition="Contains" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Kategori" FieldName="YENI" VisibleIndex="5"
                        Width="80px">
                        <HeaderStyle HorizontalAlign="Center" />
                        <CellStyle Font-Size="9px" HorizontalAlign="Center">
                        </CellStyle>
                    <Settings AutoFilterCondition="Contains" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Alt Kategori" FieldName="METIN" VisibleIndex="6"
                        Width="190px">
                        <HeaderStyle HorizontalAlign="Center" />
                        <CellStyle Font-Size="9px">
                        </CellStyle>
                    <Settings AutoFilterCondition="Contains" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Marka" FieldName="MARKA" VisibleIndex="7"
                        Width="80px">
                        <HeaderStyle HorizontalAlign="Center" />
                        <CellStyle Font-Size="9px" HorizontalAlign="Center">
                        </CellStyle>
                    <Settings AutoFilterCondition="Contains" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Prim Grubu" FieldName="PRIM" Visible="false">
                    <Settings AutoFilterCondition="Contains" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewCommandColumn Caption="İnd." ShowSelectCheckbox="True" VisibleIndex="0" Width="30px">
                        <ClearFilterButton Visible="True">
                        </ClearFilterButton>
                    </dx:GridViewCommandColumn>
                </Columns>
                <SettingsBehavior ProcessSelectionChangedOnServer="True" />
                <SettingsPager PageSize="100">
                    <Summary AllPagesText="Sayfalar: {0} - {1} ({2} toplam sayfa)" 
                        Text="{0}. sayfa {1} ({2})" />
                </SettingsPager>
                <Settings ShowFilterRow="True" />
                <SettingsText EmptyDataRow="Gösterilecek veri yok." CommandClearFilter="Temizle" />
                <SettingsLoadingPanel Text="Yükleniyor&amp;hellip;" />
                <ClientSideEvents SelectionChanged="grid_SelectionChanged" />
            </dx:ASPxGridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ProviderName="System.Data.SqlClient" 
                ConnectionString="Data Source=10.1.1.14;Initial Catalog=KurumsalWebSAP;User ID=sultanlar;Password=megastar" 
                SelectCommand="SELECT [pkResimID] AS RESIMID,[Web-Malzeme].ITEMREF,[MAL ACIK] AS MALZEME,[OZEL ACIK] AS OZELACIK,dbo.YeniBolum(PRIMB) AS YENI,HYRS_TANIM AS MARKA,METIN,PG_B_Z_ACIKLAMA AS PRIM FROM [Web-Malzeme] INNER JOIN tblINTERNET_UrunResim ON tblINTERNET_UrunResim.ITEMREF = [Web-Malzeme].ITEMREF INNER JOIN [tblINTERNET_Resimler] ON [tblINTERNET_Resimler].pkResimID = tblINTERNET_UrunResim.intResimID INNER JOIN SAP_PRM_GRP ON [Web-Malzeme].PRIMB = SAP_PRM_GRP.PG_B_Z INNER JOIN [Web-Malzeme-Hiyerarsi] ON [Web-Malzeme].HYRS = [Web-Malzeme-Hiyerarsi].KOD GROUP BY [pkResimID],[Web-Malzeme].ITEMREF,[MAL ACIK],[OZEL ACIK],HYRS_TANIM,METIN,PG_B_Z_ACIKLAMA,PRIMB ORDER BY MALZEME">
                </asp:SqlDataSource>
                <asp:Button ID="btnIndir" runat="server" Text="Seçilenleri İndir" 
                    onclick="btnIndir_Click" Visible="false" />
            </td></tr></table>
            
        </div>
    </div>
    </div>
    <uc1:ucAlt ID="ucAlt1" runat="server" />

    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="anlasmalifiyatlar.aspx.cs" Inherits="Sultanlar.WebUI.musteri.anlasmalifiyatlar" %>

<%@ Register assembly="DevExpress.Web.v12.2, Version=12.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v12.2, Version=12.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>

<%@ Register src="ucAlt.ascx" tagname="ucAlt" tagprefix="uc1" %>

<%@ Register src="ucProgress.ascx" tagname="ucProgress" tagprefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Sultanlar : Anlaşmalı Müşteri Fiyatları</title>
    <script type="text/javascript">
        function invisible() {
            if (document.getElementById('divMesaj') != null) {
                window.location.href = document.getElementById('lbMesajKapat').href;
                return false;
            }
            if (document.getElementById('divMesajYaz') != null) {
                window.location.href = document.getElementById('lbMesajYazKapat').href;
                return false;
            }
        }
    </script>
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
    </script>

    <asp:UpdateProgress ID="DivAjaxProg" runat="server">
    <ProgressTemplate>
        
        <uc2:ucProgress ID="ucProgress1" runat="server" />
        
    </ProgressTemplate>
    </asp:UpdateProgress>
    
    <asp:UpdatePanel runat="server" ID="divAjax">
    <ContentTemplate>

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
        <td><img src="img/ic_fiyatlisteleri.png" /></td>
        <td>Ürün Aktarımı</td>
        </tr></table>
        </div>
        <div style="padding-left: 10px">

            <asp:DropDownList runat="server" ID="ddlFiyatTipleri" style="padding: 3px 3px 3px 3px;border:1px solid #CCCCCC;background:#ededed;"
                OnSelectedIndexChanged="ddlFiyatTipleri_SelectedIndexChanged" Height="25px" ForeColor="#006699" 
                Width="200px" AutoPostBack="True">
            </asp:DropDownList>
            <asp:Label runat="server" Width="600px"></asp:Label>
            <asp:Button runat="server" ID="btnYenile" Text="Yenile" Font-Bold="true" Font-Size="14px" Width="150px" visible="false"
                onclick="btnYenile_Click" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" ForeColor="#6D8AAA" />
            <br /><br />
            <table><tr><td align="center" valign="top">Açık Ürünler
            <dx:ASPxGridView ID="ASPxGridView1" runat="server" 
                    AutoGenerateColumns="False" Width="475px" 
                    KeyFieldName="ITEMREF;MALZEME;TIP" 
                    onrowdeleting="ASPxGridView1_RowDeleting" EnableCallBacks="False">
                <Columns>
                    <dx:GridViewCommandColumn VisibleIndex="0">
                        <DeleteButton Text="Kaldır" Visible="True">
                        </DeleteButton>
                    </dx:GridViewCommandColumn>
                    <dx:GridViewDataTextColumn FieldName="TIP" Visible="False" VisibleIndex="3">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Kod" FieldName="ITEMREF" VisibleIndex="1">
                        <CellStyle Font-Size="9px">
                        </CellStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Ürün" FieldName="MALZEME" VisibleIndex="2" 
                        Width="400px">
                        <CellStyle Font-Size="9px">
                        </CellStyle>
                    <Settings AutoFilterCondition="Contains" />
                    </dx:GridViewDataTextColumn>
                </Columns>
                <SettingsBehavior ProcessFocusedRowChangedOnServer="True" 
                    ProcessSelectionChangedOnServer="True" />
                <SettingsPager PageSize="50">
                    <Summary AllPagesText="Sayfalar: {0} - {1} ({2} toplam sayfa)" 
                        Text="{0}. sayfa {1} ({2})" />
                </SettingsPager>
                <Settings ShowFilterRow="True" />
                <SettingsText EmptyDataRow="Gösterilecek veri yok." CommandClearFilter="Temizle" />
                <SettingsLoadingPanel Text="Yükleniyor&amp;hellip;" />
            </dx:ASPxGridView>
            </td><td align="center" valign="top">Açık Olmayan Ürünler
            <dx:ASPxGridView ID="ASPxGridView2" runat="server" 
                        AutoGenerateColumns="False" KeyFieldName="ITEMREF;MALZEME;TIP" 
                        EnableTheming="True" Width="475px" 
                        onrowdeleting="ASPxGridView2_RowDeleting" EnableCallBacks="False">
                <Columns>
                    <dx:GridViewCommandColumn VisibleIndex="0">
                        <DeleteButton Visible="True" Text="Ekle">
                        </DeleteButton>
                        <ClearFilterButton Visible="True">
                        </ClearFilterButton>
                    </dx:GridViewCommandColumn>
                    <dx:GridViewDataTextColumn FieldName="TIP" Visible="False" VisibleIndex="3">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Kod" FieldName="ITEMREF" VisibleIndex="1">
                        <CellStyle Font-Size="9px">
                        </CellStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Ürün" FieldName="MALZEME" VisibleIndex="2" 
                        Width="400px">
                        <CellStyle Font-Size="9px">
                        </CellStyle>
                    <Settings AutoFilterCondition="Contains" />
                    </dx:GridViewDataTextColumn>
                </Columns>
                <SettingsBehavior ProcessFocusedRowChangedOnServer="True" 
                    ProcessSelectionChangedOnServer="True" />
                <SettingsPager PageSize="50">
                    <Summary AllPagesText="Sayfalar: {0} - {1} ({2} toplam sayfa)" 
                        Text="{0}. sayfa {1} ({2})" />
                </SettingsPager>
                <Settings ShowFilterRow="True" />
                <SettingsText EmptyDataRow="Gösterilecek veri yok." 
                    CommandClearFilter="Temizle" />
                <SettingsLoadingPanel Text="Yükleniyor&amp;hellip;" />
            </dx:ASPxGridView>
            </td></tr></table>
            
        </div>
    </div>
    </div>
    </ContentTemplate>
    </asp:UpdatePanel>
    <uc1:ucAlt ID="ucAlt1" runat="server" />
    </form>
</body>
</html>

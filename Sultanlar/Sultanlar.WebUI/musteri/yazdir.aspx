<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="yazdir.aspx.cs" Inherits="Sultanlar.WebUI.musteri.yazdir" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        function Print() {
            window.print();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="font-size: 11px; font-family: Verdana; width: 100%">
        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Italic="True" 
                        ForeColor="Red" Text="Lütfen bekleyin... Sipariş gösterilmeye hazırlanıyor." 
                        Visible="False"></asp:Label>
        <div runat="server" id="divYazdir">
        <table cellpadding="5" cellspacing="0">
            <tr>
                <td style="width: 200px; font-weight: bold">
                    Siparişi Giren:</td>
                <td style="width: 800px">
                    <asp:Label runat="server" ID="lblSipGir"></asp:Label></td>
            </tr>
            <tr>
                <td style="font-weight: bold">
                    Cari Hesap:</td>
                <td>
                    <asp:Label runat="server" ID="lblCariHesap"></asp:Label></td>
            </tr>
            <tr>
                <td style="font-weight: bold">
                    Fiyat Tipi:</td>
                <td>
                    <asp:Label runat="server" ID="lblFiyatTipi"></asp:Label></td>
            </tr>
            <tr>
                <td style="font-weight: bold">
                    Sipariş Oluşturma Tarihi:</td>
                <td>
                    <asp:Label runat="server" ID="lblOlusmaTarihi"></asp:Label></td>
            </tr>
            <tr>
                <td style="font-weight: bold">
                    Sipariş Onay Tarihi:</td>
                <td>
                    <asp:Label runat="server" ID="lblOnayTarihi"></asp:Label></td>
            </tr>
            <%--<tr>
                <td style="font-weight: bold">
                    Vade:</td>
                <td>
                    <asp:Label runat="server" ID="lblVade"></asp:Label></td>
            </tr>--%>
            <tr>
                <td style="font-weight: bold">
                    Açıklama:</td>
                <td>
                    <asp:Label runat="server" ID="lblAciklama"></asp:Label></td>
            </tr>
            <tr>
                <td style="font-weight: bold">
                    &nbsp;</td>
                <td>
                    
                </td>
            </tr>
        </table>
    
        <br />
        <br />
    
        <asp:Repeater ID="Repeater1" runat="server">
        <HeaderTemplate>
            <table cellpadding="3" cellspacing="0" style="font-size: 10px">
            <tr style="font-weight: bold">
                <td style="width: 120px">
                    Barkod</td>
                <td style="width: 300px">
                    Ürün Açıklama</td>
                <td style="width: 50px">
                    KDV</td>
                <td style="width: 50px">
                    Miktar</td>
                <td style="width: 100px; text-align: right">
                    Brüt Fiyat</td>
                <td style="width: 70px; text-align: right">
                    İskonto 1</td>
                <td style="width: 70px; text-align: right">
                    İskonto 2</td>
                <td style="width: 70px; text-align: right">
                    İskonto 3</td>
                <td style="width: 70px; text-align: right">
                    İskonto 4</td>
                <td style="width: 100px; text-align: right">
                    Toplam + KDV</td>
            </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <%#Eval("BARKOD")%></td>
                <td>
                    <%#Eval("strUrunAdi")%></td>
                <td>
                    <%#Eval("KDV")%></td>
                <td>
                    <%#Eval("intMiktar")%></td>
                <td style="text-align: right">
                    <%#Convert.ToDecimal(Eval("FIYAT")).ToString("C3")%></td>
                <td style="text-align: center">
                    <%#Convert.ToDouble(Eval("ISK1")).ToString("N1")%></td>
                <td style="text-align: center">
                    <%#Convert.ToDouble(Eval("ISK2")).ToString("N1")%></td>
                <td style="text-align: center">
                    <%#Convert.ToDouble(Eval("ISK3")).ToString("N1")%></td>
                <td style="text-align: center">
                    <%#Convert.ToDouble(Eval("ISK4")).ToString("N1")%></td>
                <td style="text-align: right">
                    <%#Convert.ToDecimal(Convert.ToInt32(Eval("intMiktar")) * Convert.ToDecimal(Eval("mnFiyat"))).ToString("C3")%></td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
        </asp:Repeater>
    
        <br /><br />
    
        <table cellpadding="5" cellspacing="0">
            <tr>
                <td style="width: 850px; font-weight: bold; text-align: right">
                    Genel Toplam + KDV:
                    </td>
                <td style="width: 150px; text-align: right">
                    <asp:Label runat="server" ID="lblToplamTutar"></asp:Label>
                    </td>
            </tr>
        </table>
    <script type="text/javascript">
            window.print();
    </script>
        </div>
    </div>
    </form>
</body>
</html>

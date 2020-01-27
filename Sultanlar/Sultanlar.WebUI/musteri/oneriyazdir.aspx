<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="oneriyazdir.aspx.cs" Inherits="Sultanlar.WebUI.musteri.oneriyazdir" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="font-size: 11px; font-family: Verdana; width: 100%">
    <table cellpadding="0" cellspacing="0">
        <tr>
            <td align="center" style="width: 960px" colspan="3"><h3>Öneri Siparişi</h3></td>
        </tr>
        <tr>
            <td align="right" style="width: 960px" colspan="3"><asp:Label runat="server" ID="lblTarih"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 320px"><asp:Label runat="server" ID="lblSatTem"></asp:Label></td>
            <td style="width: 320px"><asp:Label runat="server" ID="lblMusteri"></asp:Label></td>
            <td style="width: 320px"><asp:Label runat="server" ID="lblSube"></asp:Label></td>
        </tr>
    </table>
    <br />
        <asp:Repeater ID="Repeater1" runat="server">
        <HeaderTemplate>
            <table cellpadding="3" cellspacing="0" style="font-size: 10px">
            <tr style="font-weight: bold">
                <td style="width: 120px; text-align: center; border-bottom: 1px solid #808080">
                    Barkod</td>
                <td style="width: 350px; text-align: center; border-bottom: 1px solid #808080">
                    Ürün</td>
                <td style="width: 50px; text-align: center; border-bottom: 1px solid #808080">
                    Koli Ad.</td>
                <td style="width: 50px; text-align: center; border-bottom: 1px solid #808080">
                    Adet</td>
                <%--<td style="width: 100px; text-align: center; border-bottom: 1px solid #808080">
                    Fiyat</td>--%>
                <td style="width: 120px; text-align: center; border-bottom: 1px solid #808080">
                    Son Satış Tarihi</td>
                <td style="width: 120px; text-align: center; border-bottom: 1px solid #808080">
                    Satış Adedi</td>
                <td style="width: 50px; text-align: center; border-bottom: 1px solid #808080">
                    Fat.Fiyatı
                </td>
            </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td style="text-align: center; border-bottom: 1px solid #C0C0C0">
                    <%#Eval("BARKOD")%></td>
                <td style="border-bottom: 1px solid #C0C0C0">
                    <%#Eval("Ad")%></td>
                <td style="text-align: center; border-bottom: 1px solid #C0C0C0">
                    <%#Eval("KOLI")%></td>
                <td style="border-bottom: 1px solid #C0C0C0">
                    </td>
                <%--<td style="text-align: right; border-bottom: 1px solid #C0C0C0">
                    <%#Convert.ToDecimal(Eval("BirimFiyat")).ToString("C3")%></td>--%>
                <td style="text-align: center; border-bottom: 1px solid #C0C0C0">
                    <%#Convert.ToDateTime(Eval("MaxFATTAR")).ToShortDateString()%></td>
                <td style="text-align: center; border-bottom: 1px solid #C0C0C0">
                    <%#Eval("Adet")%></td>
                <td style="text-align: center; border-bottom: 1px solid #C0C0C0">
                    <%#Convert.ToDecimal(Eval("lastNETKDV")).ToString("N2")%> TL
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
        </asp:Repeater>
    
    <script type="text/javascript">
        function Print() {
            window.print();
        }
    </script>
    </div>
    </form>
</body>
</html>

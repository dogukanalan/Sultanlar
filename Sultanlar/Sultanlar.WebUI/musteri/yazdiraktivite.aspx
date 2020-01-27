<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="yazdiraktivite.aspx.cs" Inherits="Sultanlar.WebUI.musteri.yazdiraktivite" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="font-size: 11px; font-family: Verdana; width: 100%">
        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Italic="True" 
                        ForeColor="Red" Text="Lütfen bekleyin... Aktivite gösterilmeye hazırlanıyor." 
                        Visible="False"></asp:Label>
        <div runat="server" id="divYazdir">
        <table cellpadding="5" cellspacing="0">
            <%--<tr>
                <td style="width: 200px; font-weight: bold">
                    Aktiviteyi Giren:</td>
                <td style="width: 800px">
                    <asp:Label runat="server" ID="lblSipGir"></asp:Label></td>
            </tr>--%>
            <tr>
                <td style="font-weight: bold">
                    Bayi:</td>
                <td>
                    <asp:Label runat="server" ID="lblCariHesap"></asp:Label></td>
            </tr>
            <tr>
                <td style="font-weight: bold">
                    Alt Cari:</td>
                <td>
                    <asp:Label runat="server" ID="lblAltCari"></asp:Label></td>
            </tr>
            <%--<tr>
                <td style="font-weight: bold">
                    Fiyat Tipi:</td>
                <td>
                    <asp:Label runat="server" ID="lblFiyatTipi"></asp:Label></td>
            </tr>--%>
            <tr>
                <td style="font-weight: bold">
                    Aktivite Tarihi:</td>
                <td>
                    <asp:Label runat="server" ID="lblOlusmaTarihi"></asp:Label></td>
            </tr>
            <%--<tr>
                <td style="font-weight: bold">
                    Aktivite Onay Tarihi:</td>
                <td>
                    <asp:Label runat="server" ID="lblOnayTarihi"></asp:Label></td>
            </tr>--%>
            <tr>
                <td style="font-weight: bold">
                    Aktivite Başlangıç Tarihi:</td>
                <td>
                    <asp:Label runat="server" ID="lblBaslangic"></asp:Label></td>
            </tr>
            <tr>
                <td style="font-weight: bold">
                    Aktivite Bitiş Tarihi:</td>
                <td>
                    <asp:Label runat="server" ID="lblBitis"></asp:Label></td>
            </tr>
            <%--<tr>
                <td style="font-weight: bold">
                    Vade:</td>
                <td>
                    <asp:Label runat="server" ID="lblVade"></asp:Label></td>
            </tr>--%>
            <tr>
                <td style="font-weight: bold">
                    Açıklama 1:</td>
                <td>
                    <asp:Label runat="server" ID="lblAciklama"></asp:Label></td>
            </tr>
            <tr>
                <td style="font-weight: bold">
                    Açıklama 2:</td>
                <td>
                    <asp:Label runat="server" ID="lblAciklama2"></asp:Label></td>
            </tr>
            <tr>
                <td style="font-weight: bold">
                    Açıklama 3:</td>
                <td>
                    <asp:Label runat="server" ID="lblAciklama3"></asp:Label></td>
            </tr>
            <tr>
                <td style="font-weight: bold">
                    Dönem:</td>
                <td>
                    <asp:Label runat="server" ID="lblAciklama4"></asp:Label></td>
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
                    Kod</td>
                <td style="width: 300px">
                    Ürün Açıklama</td>
                <td style="width: 50px">
                    Koli İçi</td>
                <td style="width: 50px">
                    Satış Hedefi</td>
                <td style="width: 100px; text-align: right">
                    Birim Fiyat Kdv'li</td>
                <td style="width: 70px; text-align: right">
                    Fat.Altı</td>
                <td style="width: 70px; text-align: right">
                    Fat.Altı</td>
                <td style="width: 70px; text-align: right">
                    Paz.İsk.</td>
                <td style="width: 70px; text-align: right">
                    Ek İsk.</td>
                <td style="width: 100px; text-align: right">
                    Kdv'li Net Fiyat</td>
            </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <%#Eval("UrtKod")%></td>
                <td>
                    <%#Eval("UrunAdi")%></td>
                <td>
                    <%#Eval("KoliAdet")%></td>
                <td>
                    <%#Eval("SatisHedefi")%></td>
                <td style="text-align: right">
                    <%#Convert.ToDecimal(Eval("BirimFiyatKDVli")).ToString("N3")%></td>
                <td style="text-align: center">
                    <%#Convert.ToDecimal(Eval("FatAltIsk")).ToString("N1")%></td>
                <td style="text-align: center">
                    <%#Convert.ToDecimal(Eval("FatAltCiro")).ToString("N1")%></td>
                <td style="text-align: center">
                    <%#Convert.ToDouble(Eval("PazIsk")).ToString("N1")%></td>
                <td style="text-align: center">
                    <%#Convert.ToDouble(Eval("EkIsk")).ToString("N1")%></td>
                <td style="text-align: right">
                    <%#Convert.ToDecimal(Eval("DusulmusBirimFiyatKDVli")).ToString("C3")%></td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
        </asp:Repeater>
    
        <br /><br />

    <script type="text/javascript">
        window.print();
    </script>
        </div>
    </div>
    </form>
</body>
</html>

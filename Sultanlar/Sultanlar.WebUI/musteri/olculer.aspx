<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="olculer.aspx.cs" Inherits="Sultanlar.WebUI.musteri.olculer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="font-family: Verdana; font-size: 10px">
    <asp:Repeater runat="server" ID="repeater1">
    <HeaderTemplate>
        <table cellpadding="1" cellspacing="0">
        <tr>
        <td style="width: 45px; text-align: center; color: #C10000">Tür</td>
        <td style="width: 45px; text-align: center; color: #C10000">Miktar</td>
        <td style="width: 95px; text-align: center; color: #C10000">Barkod</td>
        <td style="width: 45px; text-align: center; color: #C10000">Uzunluk</td>
        <td style="width: 45px; text-align: center; color: #C10000">Genişlik</td>
        <td style="width: 45px; text-align: center; color: #C10000">Yükseklik</td>
        <td style="width: 45px; text-align: center; color: #C10000">Birim</td>
        <td style="width: 45px; text-align: center; color: #C10000">Hacim</td>
        <td style="width: 45px; text-align: center; color: #C10000">Birim</td>
        <td style="width: 45px; text-align: center; color: #C10000">Ağırlık</td>
        <td style="width: 45px; text-align: center; color: #C10000">Birim</td>
        </tr>
    </HeaderTemplate>
    <ItemTemplate>
        <tr>
            <td style="text-align: center; color: #404040"><%#Eval("TUR")%></td>
            <td style="text-align: center; color: #404040"><%#Eval("MIKTAR")%></td>
            <td style="text-align: center; color: #404040"><%#Eval("BARKOD")%></td>
            <td style="text-align: center; color: #404040"><%#Eval("EN")%></td>
            <td style="text-align: center; color: #404040"><%#Eval("BOY")%></td>
            <td style="text-align: center; color: #404040"><%#Eval("YUKSEKLIK")%></td>
            <td style="text-align: center; color: #404040"><%#Eval("BIRIM")%></td>
            <td style="text-align: center; color: #404040"><%#Eval("HACIM")%></td>
            <td style="text-align: center; color: #404040"><%#Eval("BIRIM2")%></td>
            <td style="text-align: center; color: #404040"><%#Eval("AGIRLIK")%></td>
            <td style="text-align: center; color: #404040"><%#Eval("BIRIM3")%></td>
        </tr>
    </ItemTemplate>
    <FooterTemplate>
        </table>
    </FooterTemplate>
    </asp:Repeater>
    </div>
    </form>
</body>
</html>

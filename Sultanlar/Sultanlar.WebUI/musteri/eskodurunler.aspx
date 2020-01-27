<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="eskodurunler.aspx.cs" Inherits="Sultanlar.WebUI.musteri.eskodurunler" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="font-family: Verdana; font-size: 10px">
    <asp:Repeater runat="server" ID="repeater1">
    <HeaderTemplate>
        <table cellpadding="1" cellspacing="0"><tr><td style="width: 70px; text-align: center; color: #C10000">Ürt.Kod</td><td style="width: 430px; text-align: center; color: #C10000">Malzeme</td></tr>
    </HeaderTemplate>
    <ItemTemplate>
        <tr>
            <td style="text-align: center; color: #404040"><%#Eval("URT KOD")%></td>
            <td style="color: #404040"><%#Eval("MAL ACIK")%></td>
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

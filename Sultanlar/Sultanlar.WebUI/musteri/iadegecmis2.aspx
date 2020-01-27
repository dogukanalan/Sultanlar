<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="iadegecmis2.aspx.cs" Inherits="Sultanlar.WebUI.musteri.iadegecmis2" %>

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
        <table cellpadding="1" cellspacing="0">
        <tr>
        <td style="width: 200px; text-align: center; color: #C10000">Hareket</td>
        <td style="width: 150px; text-align: center; color: #C10000">İşlem Tarihi</td>
        <td style="width: 130px; text-align: center; color: #C10000">İşlemi Yapan</td>
        <td style="width: 120px; text-align: center; color: #C10000"></td>
        </tr>
    </HeaderTemplate>
    <ItemTemplate>
        <tr>
            <td style="color: #404040"><%#Eval("strIadeHareketTur")%></td>
            <td style="color: #404040"><strong><%#Convert.ToDateTime(Eval("dtTarih")).ToShortDateString()%></strong> <i><%#Convert.ToDateTime(Eval("dtTarih")).ToShortTimeString()%></i></td>
            <td style="color: #404040"><%#Eval("strIslemYapan")%></td>
            <td style="color: #404040"><%#Eval("strAciklama")%></td>
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

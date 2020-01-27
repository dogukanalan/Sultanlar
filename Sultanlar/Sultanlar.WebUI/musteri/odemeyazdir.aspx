<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="odemeyazdir.aspx.cs" Inherits="Sultanlar.WebUI.musteri.odemeyazdir" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Italic="True" 
                        ForeColor="Red" Text="Lütfen bekleyin... Ödeme ayrıntısı gösterilmeye hazırlanıyor." 
                        Visible="False"></asp:Label>
                        <center>
    <div runat="server" id="divYazdir" style="font-size: 10px; font-family: Verdana;">
                <table cellpadding="5" cellspacing="0">
                        <tr><td align="right">Sipariş No:</td><td align="left"><asp:Label runat="server" ID="lblSiparisNo"></asp:Label></td></tr>
                        <tr><td align="right">Kredi Kartı:</td><td align="left"><asp:Label runat="server" ID="lblKrediKart"></asp:Label></td></tr>
                        <tr><td align="right">Tutar:</td><td align="left"><asp:Label runat="server" ID="lblTutar"></asp:Label></td></tr>
                        <tr><td align="right">Ödeme Tarihi:</td><td align="left"><asp:Label runat="server" ID="lblTarih"></asp:Label></td></tr>
                        <tr><td align="right">Provizyon No:</td><td align="left"><asp:Label runat="server" ID="lblAuth"></asp:Label></td></tr>
                        <tr><td align="right">Referans No:</td><td align="left"><asp:Label runat="server" ID="lblHostRef"></asp:Label></td></tr>
                        <tr><td align="right">İşlem No:</td><td align="left"><asp:Label runat="server" ID="lblTransID"></asp:Label></td></tr>
                    </table>
    <script type="text/javascript">
        window.print();
    </script>
    </div></center>
    </form>
</body>
</html>

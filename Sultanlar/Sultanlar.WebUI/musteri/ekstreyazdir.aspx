<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ekstreyazdir.aspx.cs" Inherits="Sultanlar.WebUI.musteri.ekstreyazdir" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Italic="True" 
                        ForeColor="Red" Text="Lütfen bekleyin... Ekstre gösterilmeye hazırlanıyor." 
                        Visible="False"></asp:Label>
    <div runat="server" id="divYazdir" style="font-size: 10px; font-family: Verdana;">

    <asp:Label runat="server" id="lblMusteri"></asp:Label><br /><br />

                <asp:DataList ID="DataList1" runat="server">
                    <HeaderTemplate>
                        <table cellpadding="1" cellspacing="0">
                        <tr style="text-decoration: underline">
                            <td style="width: 80px; text-align: center">Tarih</td>
                            <td style="width: 80px; text-align: center">Fiş No</td>
                            <td style="width: 80px; text-align: center">Fiş Türü</td>
                            <%--<td style="width: 180px; text-align: center">Açıklama</td>--%>
                            <td style="width: 100px; text-align: center">Borç</td>
                            <td style="width: 100px; text-align: center">Alacak</td>
                            <td style="width: 100px; text-align: center">Bakiye</td>
                            <%--<td style="width: 80px; text-align: center">Vade</td>--%>
                            <td style="width: 100px; text-align: center">VGB</td>
                        </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td style="width: 80px; height: 25px; text-align: center"><%#Convert.ToDateTime(Eval("[FIS TAR]")).ToShortDateString()%></td>
                            <td style="width: 80px; height: 25px; text-align: center"><%#Eval("[MATBU_NO]")%></td>
                            <td style="width: 80px; height: 25px; text-align: center"><%#Eval("[FIS TUR]")%></td>
                            <%--<td style="width: 180px; height: 25px; text-align: center"><%#Eval("[FIS ACIKLAMA]")%></td>--%>
                            <td style="width: 100px; height: 25px; text-align: right"><%#Convert.ToDecimal(Eval("BORC")).ToString("C2")%></td>
                            <td style="width: 100px; height: 25px; text-align: right"><%#Convert.ToDecimal(Eval("ALACAK")).ToString("C2")%></td>
                            <td style="width: 100px; height: 25px; text-align: right"><%#Convert.ToDecimal(Eval("BAKIYE")).ToString("C2")%></td>
                            <%--<td style="width: 80px; height: 25px; text-align: center"><%#Convert.ToDateTime(Eval("[FIS VD]")).ToShortDateString()%></td>--%>
                            <td style="width: 100px; height: 25px; text-align: right"><%#Convert.ToDecimal(Eval("VGB")).ToString("C2")%></td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate></table></FooterTemplate>
                </asp:DataList>
                <table cellpadding="1" cellspacing="0" runat="server" id="tblToplam">
                        <tr style="color: #000000; font-weight: bold; padding-bottom: 10px">
                            <td style="width: 80px; text-align: center"></td>
                            <td style="width: 80px; text-align: center"></td>
                            <%--<td style="width: 200px; text-align: center"></td>--%>
                            <td style="width: 60px; text-align: center; border-top: 1px solid #000000">Toplam: </td>
                            <td style="width: 100px; text-align: right; border-top: 1px solid #000000"><asp:Label runat="server" ID="lblToplamBorc"></asp:Label></td>
                            <td style="width: 100px; text-align: right; border-top: 1px solid #000000"><asp:Label runat="server" ID="lblToplamAlacak"></asp:Label></td>
                            <td style="width: 100px; text-align: right; border-top: 1px solid #000000"><asp:Label runat="server" ID="lblToplamBakiye"></asp:Label></td>
                            <%--<td style="width: 80px; text-align: center; border-top: 1px solid #000000">-</td>--%>
                            <td style="width: 100px; text-align: right; border-top: 1px solid #000000"><asp:Label runat="server" ID="lblToplamVGB"></asp:Label></td>
                        </tr>
                </table>
    <script type="text/javascript">
        window.print();
    </script>
    </div>
    </form>
</body>
</html>

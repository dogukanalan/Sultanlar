<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="satisraporyazdir.aspx.cs" Inherits="Sultanlar.WebUI.musteri.satisraporyazdir" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Italic="True" 
                        ForeColor="Red" Text="Lütfen bekleyin... Rapor gösterilmeye hazırlanıyor." 
                        Visible="False"></asp:Label>
    <div runat="server" id="divYazdir" style="font-size: 10px; font-family: Verdana;">
                <asp:DataList ID="DataList1" runat="server">
                    <HeaderTemplate>
                        <table cellpadding="1" cellspacing="0">
                        <tr style="text-decoration: underline">
                            <td style="width: 70px; text-align: center">Fat.Tar.</td>
                            <td style="width: 70px; text-align: center">Fat.No</td>
                            <td style="width: 50px; text-align: center">Tür</td>
                            <td style="width: 100px; text-align: center">Tedarikçi</td>
                            <td style="width: 200px; text-align: center">Ürün</td>
                            <td style="width: 30px; text-align: center">F.Tip</td>
                            <td style="width: 30px; text-align: center">Adet</td>
                            <td style="width: 30px; text-align: center">Koli</td>
                            <td style="width: 100px; text-align: center">Brüt</td>
                            <td style="width: 100px; text-align: center">İksonto</td>
                            <td style="width: 100px; text-align: center">Net</td>
                            <td style="width: 100px; text-align: center">Net+KDV</td>
                        </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td style="width: 70px; height: 25px; text-align: center"><%#Convert.ToDateTime(Eval("[FAT TAR]")).ToShortDateString()%></td>
                            <td style="width: 70px; height: 25px; text-align: center"><%#Eval("[FAT NO]")%></td>
                            <td style="width: 50px; height: 25px; text-align: center"><%#Eval("[TUR ACK]")%></td>
                            <td style="width: 100px; height: 25px; text-align: center"><%#Eval("[GRUP]")%></td>
                            <td style="width: 200px; height: 25px; text-align: left"><%#Eval("[MALZEME]")%></td>
                            <td style="width: 30px; height: 25px; text-align: center"><%#Eval("[F TUR]")%></td>
                            <td style="width: 30px; height: 25px; text-align: center"><%#Eval("[AD T]")%></td>
                            <td style="width: 30px; height: 25px; text-align: center"><%#(Convert.ToDouble(Eval("[AD T]")) / Convert.ToDouble(Eval("[KOLI]"))).ToString("N1")%></td>
                            <td style="width: 100px; height: 25px; text-align: right"><%#Convert.ToDecimal(Eval("[BRUT T]")).ToString("C2")%></td>
                            <td style="width: 100px; height: 25px; text-align: right"><%#Convert.ToDecimal(Eval("[ISK T]")).ToString("C2")%></td>
                            <td style="width: 100px; height: 25px; text-align: right"><%#Convert.ToDecimal(Eval("[NET T]")).ToString("C2")%></td>
                            <td style="width: 100px; height: 25px; text-align: right"><%#Convert.ToDecimal(Eval("[NET+KDV T]")).ToString("C2")%></td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate></table></FooterTemplate>
                </asp:DataList>
                <table cellpadding="1" cellspacing="0" runat="server" id="tblToplam">
                        <tr style="color: #000000; font-weight: bold; padding-bottom: 10px">
                            <td style="width: 70px; height: 25px; text-align: center"></td>
                            <td style="width: 70px; height: 25px; text-align: center"></td>
                            <td style="width: 50px; height: 25px; text-align: center"></td>
                            <td style="width: 100px; height: 25px; text-align: center"></td>
                            <td style="width: 150px; height: 25px; text-align: left"></td>
                            <td style="width: 80px; height: 25px; text-align: left; border-top: 1px solid #000000">Toplam: </td>
                            <td style="width: 30px; text-align: center; border-top: 1px solid #000000"><asp:Label runat="server" ID="lblToplamAdet"></asp:Label></td>
                            <td style="width: 30px; text-align: center; border-top: 1px solid #000000"><asp:Label runat="server" ID="lblToplamKoli"></asp:Label></td>
                            <td style="width: 100px; text-align: right; border-top: 1px solid #000000"><asp:Label runat="server" ID="lblToplamBrut"></asp:Label></td>
                            <td style="width: 100px; text-align: right; border-top: 1px solid #000000"><asp:Label runat="server" ID="lblToplamIskonto"></asp:Label></td>
                            <td style="width: 100px; text-align: right; border-top: 1px solid #000000"><asp:Label runat="server" ID="lblToplamNet"></asp:Label></td>
                            <td style="width: 100px; text-align: right; border-top: 1px solid #000000"><asp:Label runat="server" ID="lblToplamNETKDV"></asp:Label></td>
                        </tr>
                </table>
    <script type="text/javascript">
        window.print();
    </script>
    </div>
    </form>
</body>
</html>

<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucMesajlar.ascx.cs" Inherits="Sultanlar.WebUI.musteri.ucMesajlar" %>
<div style="position: absolute; width: 620px; height: 300px; z-index: 5; left: 200px;
    top: 50px" runat="server" id="divMesaj" visible="false">
    <div style="position: fixed; width: 100%; height: 100%; z-index: -1; left: 0; top: 0;
    filter: alpha(opacity=40); -moz-opacity: .40; opacity: .40; background-color: #000000" onclick="invisible()"></div>
    <table cellpadding="5" cellspacing="0" style="width: 100%; height: 100%; background-color: #ffffff; font-family: Tahoma; font-size: 12px;
        border: 1px solid #D1D1D1; border-radius: 5px; padding: 5px;">
    <tr>
    <td align="center" valign="top">
        <table cellpadding="3" cellspacing="0" style="width: 100%;">
            <tr>
                <td align="left" valign="top" style="color: #D00000; font-weight: bold">Yeni Mesajınız Var</td>
                <td align="right" valign="top"><asp:LinkButton runat="server" ID="lbMesajKapat" OnClick="lbMesajKapat_Click" Font-Underline="False" Font-Bold="true" Text="X" /></td>
            </tr>
        </table>
        <asp:Label runat="server" ID="lblMesajKonu" ForeColor="#b45c0e" Font-Bold="true"></asp:Label>
        <br /><br />
        <div style="width: 100%; text-align: left; padding: 5px">
            <asp:Label runat="server" ID="lblMesajIcerik"></asp:Label>
        </div>
    </td>
    </tr>
    <tr>
    <td valign="bottom">
        <table cellpadding="3" cellspacing="0" style="width: 100%; height: 20px">
            <tr>
                <td align="left" valign="middle" style="width: 200px; height: 20px">
                    <asp:Label runat="server" ID="lblMesajZaman" Font-Italic="true"></asp:Label>
                </td>
                <td align="center" valign="middle" style="height: 20px">
                    <asp:Label runat="server" ID="lblMesajDepartman" ForeColor="#b45c0e" Font-Bold="true"></asp:Label>
                </td>
                <td align="right" valign="middle" style="width: 200px; height: 20px">
                    <asp:Button runat="server" ID="btnMesajCevapla" Text="Cevapla" Font-Bold="true" Font-Size="12px" Width="100px" 
                        onclick="btnMesajCevapla_Click" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" ForeColor="#6D8AAA" />
                </td>
            </tr>
        </table>
    </td>
    </tr>
    </table>
</div>
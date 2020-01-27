<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucYeniMesaj.ascx.cs" Inherits="Sultanlar.WebUI.musteri.ucYeniMesaj" %>

            
                <div style="width: 100%; text-align: center">
                    <asp:Label ID="Label1" style="padding: 5px 15px 0px 15px; background-color: #ffffff; font-family: Verdana" runat="server" 
                        ForeColor="#D00000" Font-Size="14px" Font-Bold="true" Text="Yeni Mesajınız Var"></asp:Label>
                </div>
                <table cellpadding="5" cellspacing="0" style="width: 100%; height: 100%; background-color: #ffffff; font-family: Tahoma; font-size: 12px;">
                <tr>
                <td align="center" valign="top" style="width: 230px">
                    <table cellpadding="3" cellspacing="0" style="width: 100%;">
                        <tr>
                            <td align="left" valign="top"><asp:Label runat="server" ID="lblMesajZaman" Font-Italic="true"></asp:Label></td>
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
                <td align="center" valign="middle" style="height: 20px">
                    <asp:Label runat="server" ID="lblMesajDepartman" ForeColor="#b45c0e" Font-Bold="true"></asp:Label>
                </td>
                </tr>
                <tr>
                <td align="right" valign="middle" style="height: 20px">
                    <asp:Button runat="server" ID="btnMesajCevapla" Text="Cevapla" Font-Bold="true" Font-Size="12px" Width="100px" 
                        onclick="btnMesajCevapla_Click" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" ForeColor="#6D8AAA" />
                </td>
                </tr>
                </table>
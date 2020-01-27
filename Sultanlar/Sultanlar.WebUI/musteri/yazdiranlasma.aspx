<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="yazdiranlasma.aspx.cs" Inherits="Sultanlar.WebUI.musteri.yazdiranlasma" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        function Print() {
            window.print();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="font-size: 11px; font-family: Verdana; width: 100%" >
        <table style="width: 100%; background-color: #ffffff; font-family: Tahoma; font-size: 12px;
            border: 1px solid #D1D1D1; border-radius: 5px; padding: 5px; margin-bottom: 20px;">
        <tr>
        <td align="center" valign="middle" style="padding-top: 15px; padding-bottom: 15px">
        <span style="color: #C00000; font-family: Gisha; font-size: 16px">Anlaşma Formu</span>
        <div style="height: 10px; width: 100%; text-align: right"></div>
            <table cellpadding="3" cellspacing="0">
            <tr>
                <td style="width: 200px">Müşteri:</td>
                <td align="left" style="width: 230px">
                    <asp:TextBox runat="server" ID="txtAnlasmaMusteri" Width="400px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                        BorderWidth="1px" Height="23px" style="padding: 0px 3px 0px 3px" Text="" Enabled="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Şube Sayısı:</td>
                <td align="left">
                    <asp:TextBox runat="server" ID="txtAnlasmaSubeSayisi" Width="400px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                        BorderWidth="1px" Height="23px" style="padding: 0px 3px 0px 3px" Text="" Enabled="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>İl:</td>
                <td align="left">
                    <asp:TextBox runat="server" ID="txtAnlasmaIl" Width="400px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                        BorderWidth="1px" Height="23px" style="padding: 0px 3px 0px 3px" Text="" Enabled="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Bayi:</td>
                <td align="left">
                    <asp:TextBox runat="server" ID="txtAnlasmaBayi" Width="400px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                        BorderWidth="1px" Height="23px" style="padding: 0px 3px 0px 3px" Text="" Enabled="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Başlangıç:</td>
                <td align="left">
                    <input type="text" id="datepickerAnlasmaBaslangic" runat="server" onkeypress="return yazma(event)" style="width: 400px" disabled="disabled" />
                </td>
            </tr>
            <tr>
                <td>Bitiş:</td>
                <td align="left">
                    <input type="text" id="datepickerAnlasmaBitis" runat="server" onkeypress="return yazma(event)" style="width: 400px" disabled="disabled" />
                </td>
            </tr>
            <tr>
                <td>Anlaşma Vade KGT:</td>
                <td align="left">
                    <asp:TextBox runat="server" ID="txtAnlasmaVadeTAH" Width="400px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                        BorderWidth="1px" Height="23px" style="padding: 0px 3px 0px 3px" Text="" Enabled="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Anlaşma Vade NF:</td>
                <td align="left">
                    <asp:TextBox runat="server" ID="txtAnlasmaVadeYEG" Width="400px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                        BorderWidth="1px" Height="23px" style="padding: 0px 3px 0px 3px" Text="" Enabled="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Listelenecek SKU KGT:</td>
                <td align="left">
                    <asp:TextBox runat="server" ID="txtAnlasmaSKUTAH" Width="400px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                        BorderWidth="1px" Height="23px" style="padding: 0px 3px 0px 3px" Text="" Enabled="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Listelenecek SKU NF:</td>
                <td align="left">
                    <asp:TextBox runat="server" ID="txtAnlasmaSKUYEG" Width="400px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                        BorderWidth="1px" Height="23px" style="padding: 0px 3px 0px 3px" Text="" Enabled="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="vertical-align: top; padding-top: 30px">Hizmet Bedelleri:</td>
                <td align="left">
                    <asp:Repeater runat="server" ID="rptHizmetBedelleri">
                    <HeaderTemplate>
                    </HeaderTemplate>
                    <ItemTemplate>
                    <table width="400px" cellpadding="3" cellspacing="0" style="font-family: Tahoma; font-size: 10px; background-color: #E8E8E8">
                        <tr>
                            <td align="left" style="width: 100px">
                            </td>
                            <td align="center" style="width: 100px; font-weight: bold">
                                <span style="color: Red"><%#Eval("strBedel")%></span>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" style="width: 100px; font-weight: bold">
                                KGT Adet:
                            </td>
                            <td align="center" style="width: 100px;">
                                <%#Eval("intTAHAdet")%>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" style="width: 100px; font-weight: bold">
                                KGT Bedel:
                            </td>
                            <td align="center" style="width: 100px;">
                                <%#Convert.ToDecimal(Eval("mnTAHBedel")).ToString("C2")%>
                            </td>
                        </tr>
                        <%--<tr>
                            <td align="left" style="width: 100px; font-weight: bold">
                                TAH İskonto:
                            </td>
                            <td align="center" style="width: 100px;">
                                <%#Convert.ToDouble(Eval("flTAHIsk")).ToString("N1")%>
                            </td>
                        </tr>--%>
                        <tr>
                            <td align="left" style="width: 100px; font-weight: bold">
                                NF Adet:
                            </td>
                            <td align="center" style="width: 100px;">
                                <%#Eval("intYEGAdet")%>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" style="width: 100px; font-weight: bold">
                                NF Bedel:
                            </td>
                            <td align="center" style="width: 100px;">
                                <%#Convert.ToDecimal(Eval("mnYEGBedel")).ToString("C2")%>
                            </td>
                        </tr>
                        <%--<tr>
                            <td align="left" style="width: 100px; font-weight: bold">
                                YEG İskonto:
                            </td>
                            <td align="center" style="width: 100px;">
                                <%#Convert.ToDouble(Eval("flYEGIsk")).ToString("N1")%>
                            </td>
                        </tr>--%>
                    </table>
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                    <table width="400px" cellpadding="3" cellspacing="0" style="font-family: Tahoma; font-size: 10px; background-color: #FFE2C6">
                        <tr>
                            <td align="left" style="width: 100px">
                            </td>
                            <td align="center" style="width: 100px; font-weight: bold">
                                <span style="color: Red"><%#Eval("strBedel")%></span>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" style="width: 100px; font-weight: bold">
                                KGT Adet:
                            </td>
                            <td align="center" style="width: 100px;">
                                <%#Eval("intTAHAdet")%>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" style="width: 100px; font-weight: bold">
                                KGT Bedel:
                            </td>
                            <td align="center" style="width: 100px;">
                                <%#Convert.ToDecimal(Eval("mnTAHBedel")).ToString("C2")%>
                            </td>
                        </tr>
                        <%--<tr>
                            <td align="left" style="width: 100px; font-weight: bold">
                                TAH İskonto:
                            </td>
                            <td align="center" style="width: 100px;">
                                <%#Convert.ToDouble(Eval("flTAHIsk")).ToString("N1")%>
                            </td>
                        </tr>--%>
                        <tr>
                            <td align="left" style="width: 100px; font-weight: bold">
                                NF Adet:
                            </td>
                            <td align="center" style="width: 100px;">
                                <%#Eval("intYEGAdet")%>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" style="width: 100px; font-weight: bold">
                                NF Bedel:
                            </td>
                            <td align="center" style="width: 100px;">
                                <%#Convert.ToDecimal(Eval("mnYEGBedel")).ToString("C2")%>
                            </td>
                        </tr>
                        <%--<tr>
                            <td align="left" style="width: 100px; font-weight: bold">
                                YEG İskonto:
                            </td>
                            <td align="center" style="width: 100px;">
                                <%#Convert.ToDouble(Eval("flYEGIsk")).ToString("N1")%>
                            </td>
                        </tr>--%>
                    </table>
                    </AlternatingItemTemplate>
                    <FooterTemplate></FooterTemplate>
                    </asp:Repeater>
                </td>
            </tr>
            <tr>
                <td></td>
                <td align="left"><asp:Label ID="Label2" runat="server" Width="80px"></asp:Label>KGT<asp:Label ID="Label3" runat="server" Width="180px"></asp:Label>NF</td>
            </tr>
            <tr>
                <td>Fatura Altı İskonto:</td>
                <td align="left">
                    <asp:TextBox runat="server" ID="txtAnlasmaTAHIsk" Width="190px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                        BorderWidth="1px" Height="23px" style="padding: 0px 3px 0px 3px" Text="" Enabled="false"></asp:TextBox>
                    <asp:TextBox runat="server" ID="txtAnlasmaYEGIsk" Width="190px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                        BorderWidth="1px" Height="23px" style="padding: 0px 3px 0px 3px" Text="" Enabled="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Ciro Primi Aylık:</td>
                <td align="left">
                    <asp:TextBox runat="server" ID="txtAnlasmaTAHCiro" Width="190px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                        BorderWidth="1px" Height="23px" style="padding: 0px 3px 0px 3px" Text="" Enabled="false"></asp:TextBox>
                    <asp:TextBox runat="server" ID="txtAnlasmaYEGCiro" Width="190px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                        BorderWidth="1px" Height="23px" style="padding: 0px 3px 0px 3px" Text="" Enabled="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Ciro Primi 3 Aylık:</td>
                <td align="left">
                    <asp:TextBox runat="server" ID="txtAnlasmaTAHCiro3" Width="190px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                        BorderWidth="1px" Height="23px" style="padding: 0px 3px 0px 3px" Text="" Enabled="false"></asp:TextBox>
                    <asp:TextBox runat="server" ID="txtAnlasmaYEGCiro3" Width="190px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                        BorderWidth="1px" Height="23px" style="padding: 0px 3px 0px 3px" Text="" Enabled="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Ciro Primi 6 Aylık:</td>
                <td align="left">
                    <asp:TextBox runat="server" ID="txtAnlasmaTAHCiro6" Width="190px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                        BorderWidth="1px" Height="23px" style="padding: 0px 3px 0px 3px" Text="" Enabled="false"></asp:TextBox>
                    <asp:TextBox runat="server" ID="txtAnlasmaYEGCiro6" Width="190px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                        BorderWidth="1px" Height="23px" style="padding: 0px 3px 0px 3px" Text="" Enabled="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Ciro Primi Yıllık:</td>
                <td align="left">
                    <asp:TextBox runat="server" ID="txtAnlasmaTAHCiro12" Width="190px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                        BorderWidth="1px" Height="23px" style="padding: 0px 3px 0px 3px" Text="" Enabled="false"></asp:TextBox>
                    <asp:TextBox runat="server" ID="txtAnlasmaYEGCiro12" Width="190px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                        BorderWidth="1px" Height="23px" style="padding: 0px 3px 0px 3px" Text="" Enabled="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Ciro Primi Fatura Altı:</td>
                <td align="left">
                    <asp:TextBox runat="server" ID="txtAnlasmaTAHCiroIsk" Width="190px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                        BorderWidth="1px" Height="23px" style="padding: 0px 3px 0px 3px" Text="" Enabled="false"></asp:TextBox>
                    <asp:TextBox runat="server" ID="txtAnlasmaYEGCiroIsk" Width="190px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                        BorderWidth="1px" Height="23px" style="padding: 0px 3px 0px 3px" Text="" Enabled="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Anlaşma Dışı Bedeller:</td>
                <td align="left">
                    <asp:TextBox runat="server" ID="txtAnlasmaTAHAnlasmaDisiBedeller" Width="190px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                        BorderWidth="1px" Height="23px" style="padding: 0px 3px 0px 3px" Text="" Enabled="false"></asp:TextBox>
                    <asp:TextBox runat="server" ID="txtAnlasmaYEGAnlasmaDisiBedeller" Width="190px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                        BorderWidth="1px" Height="23px" style="padding: 0px 3px 0px 3px" Text="" Enabled="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Tüm Bedeller Toplamı:</td>
                <td align="left">
                    <asp:TextBox runat="server" ID="txtAnlasmaTAHTumBedeller" Width="190px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                        BorderWidth="1px" Height="23px" style="padding: 0px 3px 0px 3px" Text="" Enabled="false"></asp:TextBox>
                    <asp:TextBox runat="server" ID="txtAnlasmaYEGTumBedeller" Width="190px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                        BorderWidth="1px" Height="23px" style="padding: 0px 3px 0px 3px" Text="" Enabled="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Toplam Ciro:</td>
                <td align="left">
                    <asp:TextBox runat="server" ID="txtAnlasmaTAHToplamCiro" Width="190px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                        BorderWidth="1px" Height="23px" style="padding: 0px 3px 0px 3px" Text="" Enabled="false"></asp:TextBox>
                    <asp:TextBox runat="server" ID="txtAnlasmaYEGToplamCiro" Width="190px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                        BorderWidth="1px" Height="23px" style="padding: 0px 3px 0px 3px" Text="" Enabled="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Toplam Yıl Sonu Maliyet:</td>
                <td align="left">
                    <asp:TextBox runat="server" ID="txtAnlasmaTAHYilSonuMaliyet" Width="190px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                        BorderWidth="1px" Height="23px" style="padding: 0px 3px 0px 3px" Text="" Enabled="false"></asp:TextBox>
                    <asp:TextBox runat="server" ID="txtAnlasmaYEGYilSonuMaliyet" Width="190px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                        BorderWidth="1px" Height="23px" style="padding: 0px 3px 0px 3px" Text="" Enabled="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Ciro Primi Dahil Net Maliyet:</td>
                <td align="left">
                    <asp:TextBox runat="server" ID="txtAnlasmaTAHCiroPrimiDahil" Width="190px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                        BorderWidth="1px" Height="23px" style="padding: 0px 3px 0px 3px" Text="" Enabled="false"></asp:TextBox>
                    <asp:TextBox runat="server" ID="txtAnlasmaYEGCiroPrimiDahil" Width="190px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                        BorderWidth="1px" Height="23px" style="padding: 0px 3px 0px 3px" Text="" Enabled="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Açıklama:</td>
                <td align="left">
                    <asp:TextBox runat="server" ID="txtAnlasmaAciklama" Width="400px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                        BorderWidth="1px" Height="23px" style="padding: 0px 3px 0px 3px" Text="" Enabled="false"></asp:TextBox>
                </td>
            </tr>
            </table>
        </td>
        </tr>
        </table>
    <script type="text/javascript">
        window.print();
    </script>
    </div>
    </form>
</body>
</html>

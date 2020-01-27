<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="kartlar.aspx.cs" Inherits="Sultanlar.WebUI.musteri.kartlar" %>

<%@ Register src="ucAlt.ascx" tagname="ucAlt" tagprefix="uc1" %>

<%@ Register src="ucProgress.ascx" tagname="ucProgress" tagprefix="uc2" %>

<%@ Register src="ucMesajlar.ascx" tagname="ucMesajlar" tagprefix="uc3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sultanlar : Kartlar</title>
    <link rel="stylesheet" type="text/css" href="StyleSheet.css" />
    <script type="text/javascript">
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;

            return true;
        }
    </script>
</head>
<body style="margin: 0 0 0 0;background-color: #EFEEEA;">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="AjaxScripts" runat="server">
    </asp:ScriptManager>
    <asp:UpdateProgress ID="DivAjaxProg" runat="server">
        <ProgressTemplate>
            <uc2:ucProgress ID="ucProgress1" runat="server" />
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdatePanel runat="server" ID="upKartlar"><ContentTemplate>
    <uc3:ucMesajlar ID="ucMesajlar1" runat="server" />
    <div style="width: 100%; font-size: 11px; font-family: Verdana; background-color: #FFCFB2; border-bottom: 1px solid #EBEAE6">
    <table cellpadding="5" cellspacing="0">
    <tr>
    <td style="width: 700px;">
        <a href="default.aspx">Giriş</a> :: <a href="siparisler.aspx">Siparişler</a> :: <a href="iadeler.aspx">İadeler</a> :: <a href="odemeler.aspx">Tahsilatlar</a> :: <a href="hesapayrinti.aspx">Raporlar</a> :: Kredi Kartları :: <a href="uyelik.aspx">Üyelik İşlemleri</a> :: <a title="Sorularınızı bize yazın" href="mesajlar.aspx">Mesajlar</a> <asp:Label runat="server" ID="lblMesajSayisi"></asp:Label>
        <asp:Label runat="server" Width="70px"></asp:Label><b><i><asp:HyperLink ID="hlSatistaOnAdim" runat="server" NavigateUrl="img/satista10adim.jpg" Target="_blank" Text="Satışta On Adım" Visible="false"></asp:HyperLink></i></b>
    </td>
    <td style="width: 300px; text-align: right;">
        <asp:Label ID="Label1" runat="server" Font-Bold="true"></asp:Label>
        -
        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Çıkış</asp:LinkButton>
    </td>
    </tr>
    </table>
    </div>
    <table cellpadding="0" cellspacing="0" style="width: 100%; height: 400px; font-size: 10px; font-family: Verdana;
        background-position: center center; background-image: url('img/bg-logo.jpg'); background-repeat: no-repeat; background-color: #FFFFFF">
    <tr>
        <td valign="top">
            <div style="font-size: 18px; padding: 10px 10px 10px 10px">Kredi Kartları</div>
            <div style="padding: 10px 10px 0px 25px; font-size: 12px" runat="server" id="divHesapSecim">Kartlar: 
                <asp:DropDownList ID="ddlKartlar" runat="server" Width="400px" AutoPostBack="True" 
                                                    Font-Bold="False" Font-Italic="False" Height="25px"
                    Font-Overline="False" Font-Size="12px" 
                                                    Font-Strikeout="False" 
                    Font-Underline="False" style="filter: alpha(opacity=80); -moz-opacity: .80; opacity: .80; padding: 3px 3px 3px 3px"
                    onselectedindexchanged="ddlKartlar_SelectedIndexChanged" 
                    ForeColor="#006699">
                </asp:DropDownList>
            </div>
            <table cellpadding="0" cellspacing="0" style="width: 100%; padding: 10px 3px 3px 100px; font-size: 11px;">
            <tr>
            <td align="left">
                <table cellpadding="5" cellspacing="0">
                    <tr>
                        <td align="right">
                            Kart Tanımı:
                        </td>
                        <td align="left">
                            <asp:TextBox runat="server" ID="txtTanim" Width="140px" 
                                style="color:#006699;border-color:#A3B5C9;border-width:1px;border-style:Solid;font-size:12px;
                                padding: 3px 3px 3px 3px" ValidationGroup="vgKart"></asp:TextBox>
                        </td>
                        <td align="left" style="width: 50px">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                                ControlToValidate="txtTanim" Display="Dynamic" ErrorMessage="Gerekli Alan" 
                                ValidationGroup="vgKart">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            Banka:
                        </td>
                        <td align="left">
                            <asp:DropDownList runat="server" ID="ddlBankalar" Height="24px" 
                                style="padding: 3px 3px 3px 3px;color:#006699;font-size:12px;
                                font-weight:normal;font-style:normal;text-decoration:none;" Width="140px"></asp:DropDownList>
                        </td>
                        <td align="left">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td align="right">
                            Kredi Kart Numarası:
                        </td>
                        <td align="left">
                            <asp:TextBox runat="server" ID="txtNumara" Width="140px" onkeypress="return isNumberKey(event)"
                                style="color:#006699;border-color:#A3B5C9;border-width:1px;border-style:Solid;font-size:12px;
                                padding: 3px 3px 3px 3px" MaxLength="16" ValidationGroup="vgKart"></asp:TextBox>
                        </td>
                        <td align="left">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                ControlToValidate="txtNumara" Display="Dynamic" ErrorMessage="Gerekli Alan" 
                                ToolTip="Gerekli Alan" ValidationGroup="vgKart">*</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                ControlToValidate="txtNumara" Display="Dynamic" ErrorMessage="16 Hane Olmalı" 
                                ToolTip="16 Hane Olmalı" ValidationExpression="\d{16}" ValidationGroup="vgKart">*</asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            Güvenlik Kodu:
                        </td>
                        <td align="left">
                            <asp:TextBox runat="server" ID="txtGuvenlik" Width="40px" onkeypress="return isNumberKey(event)"
                                style="color:#006699;border-color:#A3B5C9;border-width:1px;border-style:Solid;font-size:12px;
                                padding: 3px 3px 3px 3px" MaxLength="3" ValidationGroup="vgKart"></asp:TextBox>
                        </td>
                        <td align="left">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                ControlToValidate="txtGuvenlik" Display="Dynamic" ErrorMessage="Gerekli Alan" 
                                ToolTip="Gerekli Alan" ValidationGroup="vgKart">*</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                                ControlToValidate="txtGuvenlik" Display="Dynamic" ErrorMessage="3 Hane Olmalı" 
                                ToolTip="3 Hane Olmalı" ValidationExpression="\d{3}" ValidationGroup="vgKart">*</asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            Son Kullanma Ayı:
                        </td>
                        <td align="left">
                            <asp:TextBox runat="server" ID="txtAy" Width="30px" onkeypress="return isNumberKey(event)"
                                style="color:#006699;border-color:#A3B5C9;border-width:1px;border-style:Solid;font-size:12px;
                                padding: 3px 3px 3px 3px" MaxLength="2" ValidationGroup="vgKart"></asp:TextBox>
                        </td>
                        <td align="left">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                ControlToValidate="txtAy" Display="Dynamic" ErrorMessage="Gerekli Alan" 
                                ToolTip="Gerekli Alan" ValidationGroup="vgKart">*</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" 
                                ControlToValidate="txtAy" Display="Dynamic" ErrorMessage="2 Hane Olmalı" 
                                ToolTip="2 Hane Olmalı" ValidationExpression="\d{2}" ValidationGroup="vgKart">*</asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            Son Kullanma Yılı:
                        </td>
                        <td align="left">
                            <asp:TextBox runat="server" ID="txtYil" Width="30px" onkeypress="return isNumberKey(event)"
                                style="color:#006699;border-color:#A3B5C9;border-width:1px;border-style:Solid;font-size:12px;
                                padding: 3px 3px 3px 3px" MaxLength="2" ValidationGroup="vgKart"></asp:TextBox>
                        </td>
                        <td align="left">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                ControlToValidate="txtYil" Display="Dynamic" ErrorMessage="Gerekli Alan" 
                                ToolTip="Gerekli Alan" ValidationGroup="vgKart">*</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" 
                                ControlToValidate="txtYil" Display="Dynamic" ErrorMessage="2 Hane Olmalı" 
                                ToolTip="2 Hane Olmalı" ValidationExpression="\d{2}" ValidationGroup="vgKart">*</asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            Visa/MC Seçimi:
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlVisaMC" runat="server" Height="24px" Width="140px"
                                style="padding: 3px 3px 3px 3px;color:#006699;font-size:12px;
                                font-weight:normal;font-style:normal;text-decoration:none;" 
                                AutoPostBack="False" ValidationGroup="vgKart">
                                <asp:ListItem Value="1">Visa</asp:ListItem>
                                <asp:ListItem Value="2">MasterCard</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td align="left">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2" style="padding-top: 10px">
                            <asp:Button ID="btnEkle" runat="server" Text="Ekle"
                                style="color:#284775;background-color:#FFFBFF;
                                border-color:#CCCCCC;border-width:1px;border-style:Solid;font-family:Verdana;font-size:12px;" 
                                ValidationGroup="vgKart" onclick="btnEkle_Click" />
                            <asp:Label runat="server" Width="50px"></asp:Label>
                            <asp:Button ID="btnGuncelle" runat="server" Text="Güncelle" Enabled="false"
                                style="color:#284775;background-color:#FFFBFF;
                                border-color:#CCCCCC;border-width:1px;border-style:Solid;font-family:Verdana;font-size:12px;" 
                                ValidationGroup="vgKart" onclick="btnGuncelle_Click" />
                            <asp:Label runat="server" Width="50px"></asp:Label>
                            <asp:Button ID="btnSil" runat="server" Text="Sil" Enabled="false"
                                
                                style="color:#284775;background-color:#FFFBFF;
                                border-color:#CCCCCC;border-width:1px;border-style:Solid;font-family:Verdana;font-size:12px;" 
                                onclick="btnSil_Click" />
                        </td>
                        <td align="center" style="padding-top: 10px">
                            &nbsp;</td>
                    </tr>
                </table>
            </td>
            </tr>
            </table>
        </td>
    </tr>
    </table>
    </ContentTemplate></asp:UpdatePanel>
<uc1:ucAlt ID="ucAlt1" runat="server" />
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="odeme1.aspx.cs" Inherits="Sultanlar.WebUI.musteri.odeme1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <script type="text/javascript">
            function isNumberKey(evt) {
                var charCode = (evt.which) ? evt.which : event.keyCode
                if (charCode > 31 && (charCode < 48 || charCode > 57))
                    return false;

                return true;
            }
        </script>
</head>
<body style="font-family: Verdana; font-size: 11px">
    <form id="form1" runat="server">
    <asp:ScriptManager runat="server" ID="ajaxscripts"></asp:ScriptManager>
    <asp:UpdateProgress ID="DivAjaxProg" runat="server">
        <ProgressTemplate>
            <%--<div style="padding-top: 300px; filter: alpha(opacity=60); -moz-opacity: .60; opacity: .60;
                background-color: #000000; position: fixed; width: 100%; height: 100%; z-index: 20;
                left: 0; top: 0;">
            </div>
            <div style="padding-top: 300px; position: fixed; width: 100%; height: 100%; z-index: 21;
                left: 0; top: 0;">
                <table width="100%">
                    <tr>
                        <td style="text-align: center; background-color: #ffffff; width: 100%">
                            <br />
                            <br />
                            <img alt="" src="img/yukleniyor.gif" /><br />
                            <br />
                            <span style="font-family: Tahoma; font-size: 16px;">yükleniyor...</span><br />
                            <br />
                        </td>
                    </tr>
                </table>
            </div>--%>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdatePanel runat="server" ID="ajaxPanel">
        <ContentTemplate>
    <center>
                <table cellpadding="3" cellspacing="0" 
                    style="text-align: left; width: 350px;">
                    <tr>
                        <td align="right">Ödeme Tutarı:</td>
                        <td><strong><%=Session["OdemeTutari"].ToString()%> TL</strong></td>
                    </tr>

                    <tr>
                        <td align="right"><br /><br /></td>
                        <td><br /><br /></td>
                    </tr>
                    
                    <tr>
                        <td align="right">Seçiniz:</td>
                        <td>
                            <asp:DropDownList ID="DropDownList1" runat="server" Height="24px" Width="140px"
                                style="padding: 3px 3px 3px 3px;color:#006699;font-size:12px;
                                font-weight:normal;font-style:normal;text-decoration:none;" 
                                AutoPostBack="True" 
                                onselectedindexchanged="DropDownList1_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label1" runat="server" Text="Kart Tanımı:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TextBox1" runat="server" Width="140px" 
                                style="color:#006699;border-color:#A3B5C9;border-width:1px;border-style:Solid;font-size:12px;
                                padding: 3px 3px 3px 3px" ValidationGroup="vgKart"></asp:TextBox>
                            &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                                ControlToValidate="TextBox1" Display="Dynamic" ErrorMessage="Gerekli Alan" 
                                ValidationGroup="vgKart">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    
                    <tr>
                        <td align="right">
                            Banka:</td>
                        <td>
                            <asp:DropDownList ID="ddlBankalar" runat="server" Height="24px" style="padding: 3px 3px 3px 3px;color:#006699;font-size:12px;
                                font-weight:normal;font-style:normal;text-decoration:none;" Width="140px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    
                    <tr>
                        <td align="right">
                            Kredi Kart Numarası:</td>
                        <td>
                            <asp:TextBox ID="txtNumara" runat="server" Width="140px" onkeypress="return isNumberKey(event)"
                                style="color:#006699;border-color:#A3B5C9;border-width:1px;border-style:Solid;font-size:12px;
                                padding: 3px 3px 3px 3px" MaxLength="16" ValidationGroup="vgKart"></asp:TextBox>
                            &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                ControlToValidate="txtNumara" Display="Dynamic" ErrorMessage="Gerekli Alan" 
                                ValidationGroup="vgKart" ToolTip="Gerekli Alan">*</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                ControlToValidate="txtNumara" Display="Dynamic" ErrorMessage="16 Hane Olmalı" 
                                ToolTip="16 Hane Olmalı" ValidationExpression="\d{16}" ValidationGroup="vgKart">*</asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    
                    <tr>
                        <td align="right">
                            Güvenlik Kodu:</td>
                        <td>
                            <asp:TextBox ID="txtGuvenlik" runat="server" Width="40px" onkeypress="return isNumberKey(event)"
                                style="color:#006699;border-color:#A3B5C9;border-width:1px;border-style:Solid;font-size:12px;
                                padding: 3px 3px 3px 3px" MaxLength="3" ValidationGroup="vgKart"></asp:TextBox>
                            &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                ControlToValidate="txtGuvenlik" Display="Dynamic" ErrorMessage="Gerekli Alan" 
                                ValidationGroup="vgKart" ToolTip="Gerekli Alan">*</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                                ControlToValidate="txtGuvenlik" Display="Dynamic" ErrorMessage="3 Hane Olmalı" 
                                ToolTip="3 Hane Olmalı" ValidationExpression="\d{3}" ValidationGroup="vgKart">*</asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    
                    <tr>
                        <td align="right">
                            Son Kullanma Ayı:</td>
                        <td>
                            <asp:TextBox ID="txtAy" runat="server" Width="30px" onkeypress="return isNumberKey(event)"
                                style="color:#006699;border-color:#A3B5C9;border-width:1px;border-style:Solid;font-size:12px;
                                padding: 3px 3px 3px 3px" MaxLength="2" ValidationGroup="vgKart"></asp:TextBox>
                            &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                ControlToValidate="txtAy" Display="Dynamic" ErrorMessage="Gerekli Alan" 
                                ValidationGroup="vgKart" ToolTip="Gerekli Alan">*</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" 
                                ControlToValidate="txtAy" Display="Dynamic" ErrorMessage="2 Hane Olmalı" 
                                ToolTip="2 Hane Olmalı" ValidationExpression="\d{2}" ValidationGroup="vgKart">*</asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    
                    <tr>
                        <td align="right">
                            Son Kullanma Yılı:</td>
                        <td>
                            <asp:TextBox ID="txtYil" runat="server" Width="30px" onkeypress="return isNumberKey(event)"
                                style="color:#006699;border-color:#A3B5C9;border-width:1px;border-style:Solid;font-size:12px;
                                padding: 3px 3px 3px 3px" MaxLength="2" ValidationGroup="vgKart"></asp:TextBox>
                            &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                ControlToValidate="txtYil" Display="Dynamic" ErrorMessage="Gerekli Alan" 
                                ValidationGroup="vgKart" ToolTip="Gerekli Alan">*</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" 
                                ControlToValidate="txtYil" Display="Dynamic" ErrorMessage="2 Hane Olmalı" 
                                ToolTip="2 Hane Olmalı" ValidationExpression="\d{2}" ValidationGroup="vgKart">*</asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    
                    <tr>
                        <td align="right">
                            Visa/MC Seçimi:</td>
                        <td>
                            <asp:DropDownList ID="ddlVisaMC" runat="server" Height="24px" Width="140px"
                                style="padding: 3px 3px 3px 3px;color:#006699;font-size:12px;
                                font-weight:normal;font-style:normal;text-decoration:none;" 
                                AutoPostBack="False" ValidationGroup="vgKart">
                                <asp:ListItem Value="1">Visa</asp:ListItem>
                                <asp:ListItem Value="2">MasterCard</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    
                    <tr>
                        <td align="center" colspan="2">
                            <asp:CheckBox ID="CheckBox1" runat="server" Checked="True" 
                                Text="Kart Numaram Kaydedilsin" AutoPostBack="True" 
                                oncheckedchanged="CheckBox1_CheckedChanged" />
                        </td>
                    </tr>
                    
                    <tr>
                        <td align="center" colspan="2">
                            <br /><br />
                            <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
                                Font-Bold="true" Font-Size="14px" Width="150px" ForeColor="#6D8AAA" BorderWidth="1px"
                                BorderColor="#CCCCCC" BorderStyle="Solid" Text="Sonraki Adım" ValidationGroup="vgKart" />
                        </td>
                    </tr>
                    
                    <tr>
                        <td align="center" colspan="2">
                            &nbsp;</td>
                    </tr>
                    
                    </table>
                    </center>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>

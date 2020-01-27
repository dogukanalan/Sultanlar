<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="uyelik.aspx.cs" Inherits="Sultanlar.WebUI.musteri.uyelik" %>

<%@ Register src="ucAlt.ascx" tagname="ucAlt" tagprefix="uc1" %>

<%@ Register src="ucProgress.ascx" tagname="ucProgress" tagprefix="uc2" %>

<%@ Register src="ucMesajlar.ascx" tagname="ucMesajlar" tagprefix="uc3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
	<meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Sultanlar : Üyelik İşlemleri</title>
    <script type="text/javascript">
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;

            return true;
        }
        function invisible() {
            if (document.getElementById('divAdreslerim') != null) {
                window.location.href = document.getElementById('lbAdreslerimKapat').href;
                return false;
            }
            if (document.getElementById('divKartlar') != null) {
                window.location.href = document.getElementById('lbKartlarKapat').href;
                return false;
            }
            if (document.getElementById('divMesaj') != null) {
                window.location.href = document.getElementById('lbMesajKapat').href;
                return false;
            }
        }
        function Sinir(text, uzunluk) {
            if (text.value.length > uzunluk) {
                text.value = text.value.substring(0, uzunluk);
                alert(" En fazla " + uzunluk + " karakter girebilirsiniz.");
            }
        } 
    </script>
    <link rel="stylesheet" type="text/css" href="StyleSheet.css" />

    <script type="text/javascript" src="js/jquery-1.2.6.pack.js"></script>
    <script type="text/javascript" src="js/jquery-1.8.3.js"></script>
    <script type="text/javascript" src="js/jquery-ui.js"></script>
    <link rel="stylesheet" href="js/jquery-ui.css" />
    <script type="text/javascript" src="js/scripts.js"></script>

</head>
<body style="margin: 0 0 0 0;background-color: #EFEEEA;">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="AjaxScripts" runat="server">
    </asp:ScriptManager>
    <script type="text/javascript">
        Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(function (evt, args) {
            $("input[type=submit], input[type=button]").button();
        });
    </script>
    <asp:UpdateProgress ID="DivAjaxProg" runat="server">
        <ProgressTemplate>
            <uc2:ucProgress ID="ucProgress1" runat="server" />
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdatePanel runat="server" ID="upSiparisler"><ContentTemplate>
    <uc3:ucMesajlar ID="ucMesajlar1" runat="server" />
    <div style="position: absolute; height: 300px; z-index: 4; left: 300px;
        top: 70px" runat="server" id="divAdreslerim" visible="false">
        <div style="position: fixed; width: 100%; height: 100%; z-index: -1; left: 0; top: 0;
        filter: alpha(opacity=40); -moz-opacity: .40; opacity: .40; background-color: #000000" onclick="invisible()"></div>
        <table style="height: 100%; background-color: #ffffff; font-family: Tahoma; font-size: 12px; padding-top: 10px; padding-bottom: 10px;
            border: 1px solid #D1D1D1; border-radius: 5px; padding: 5px;">
        <tr>
            <td align="center" style="color: #C00000">
                <strong>Sevk Adreslerim</strong>
            </td>
        </tr>
        <tr>
            <td align="left" valign="middle">
                <table cellpadding="5" cellspacing="0">
                    <tr>
                        <td>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlAdresler" runat="server" Width="300px" AutoPostBack="True" 
                                Font-Bold="False" Font-Italic="False" Height="25px" OnSelectedIndexChanged="ddlAdresler_SelectedIndexChanged"
                                Font-Overline="False" Font-Size="12px" Font-Strikeout="False" 
                                Font-Underline="False" style="padding: 3px 3px 3px 3px;border:1px solid #CCCCCC;background:#ededed;" ForeColor="#006699">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            Adres Adı:
                        </td>
                        <td>
                            <asp:TextBox ID="txtBaslik" runat="server" Height="22px" Width="395px" AutoPostBack="false"
                                ForeColor="#006699" BorderColor="#A3B5C9"
                                BorderStyle="Solid" BorderWidth="1px" style="padding: 3px 3px 3px 3px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" align="right">
                            <br />
                            &nbsp; 
                            Adres:
                        </td>
                        <td>
                            <asp:TextBox ID="txtAdres" runat="server" Height="30px" Width="395px" AutoPostBack="false"
                                ForeColor="#006699" BorderColor="#A3B5C9" style="padding: 3px 3px 3px 3px"
                                BorderStyle="Solid" BorderWidth="1px" TextMode="MultiLine" 
                                onKeyUp="Sinir(this,60)" onChange="Count(Sinir,60)"></asp:TextBox>
                            <br /><span style="font-size: 10px; font-style: italic">(En fazla 60 karakter girebilirsiniz.)</span>
                        </td>
                    </tr>
                    <tr>
                        <td valign="middle" align="right">
                            İl:
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlIller" runat="server" Width="400px" AutoPostBack="True" 
                                Font-Bold="False" Font-Italic="False" Height="25px" 
                                Font-Overline="False" Font-Size="12px" Font-Strikeout="False" 
                                Font-Underline="False" style="padding: 3px 3px 3px 3px;border:1px solid #CCCCCC;background:#ededed;" 
                                ForeColor="#006699" onselectedindexchanged="ddlIller_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td valign="middle" align="right">
                            İlçe:
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlIlceler" runat="server" Width="400px" 
                                Font-Bold="False" Font-Italic="False" Height="25px" 
                                Font-Overline="False" Font-Size="12px" Font-Strikeout="False" 
                                Font-Underline="False" style="padding: 3px 3px 3px 3px;border:1px solid #CCCCCC;background:#ededed;" 
                                ForeColor="#006699">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            
                        </td>
                        <td align="right">
                            <table cellpadding="0" cellspacing="0" style="width: 100%">
                            <tr>
                            <td align="left"><asp:Label runat="server" ID="lblAdresBilgi" ForeColor="DarkRed"></asp:Label></td>
                            <td align="right">
                            <asp:Button ID="btnAdresSil" runat="server" Height="22px" Text="Sil" 
                                Width="100px" OnClick="btnAdresSil_Click" 
                                BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" 
                                ForeColor="#6D8AAA" Visible="False" />
                            <asp:Label runat="server" Width="50px"></asp:Label>
                            <asp:Button ID="btnAdres" runat="server" Height="22px" Text="Ekle" 
                                Width="100px" OnClick="btnAdres_Click" 
                                BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" 
                                ForeColor="#6D8AAA" />
                            </td>
                            </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="center"><asp:LinkButton runat="server" ID="lbAdreslerimKapat" Font-Bold="true" onclick="lbAdreslerimKapat_Click">Kapat</asp:LinkButton></td>
        </tr>
        </table>
    </div>
    <div style="position: absolute; height: 300px; z-index: 4; left: 300px;
        top: 70px" runat="server" id="divKartlar" visible="false">
        <div style="position: fixed; width: 100%; height: 100%; z-index: -1; left: 0; top: 0;
        filter: alpha(opacity=40); -moz-opacity: .40; opacity: .40; background-color: #000000" onclick="invisible()"></div>
        <table style="height: 100%; background-color: #ffffff; font-family: Tahoma; font-size: 12px; padding-top: 10px; padding-bottom: 10px;
            border: 1px solid #D1D1D1; border-radius: 5px; padding: 5px;">
        <tr>
            <td align="center" style="color: #C00000">
                <strong>Kredi Kartlarım</strong>
            </td>
        </tr>
        <tr>
            <td align="left" valign="middle">
                <table cellpadding="5" cellspacing="0">
                    <tr>
                        <td align="right">
                            Kartlar: 
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlKartlar" runat="server" Width="250px" AutoPostBack="True" 
                                Font-Bold="False" Font-Italic="False" Height="25px"
                                Font-Overline="False" Font-Size="12px" Font-Strikeout="False" 
                                Font-Underline="False" style="filter: alpha(opacity=80); -moz-opacity: .80; opacity: .80; padding: 3px 3px 3px 3px;border:1px solid #CCCCCC;background:#ededed;"
                                onselectedindexchanged="ddlKartlar_SelectedIndexChanged" 
                                ForeColor="#006699">
                            </asp:DropDownList>
                        </td>
                        <td align="left" style="width: 50px">
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            Kart Tanımı:
                        </td>
                        <td align="left">
                            <asp:TextBox runat="server" ID="txtTanim" Width="250px" 
                                style="color:#006699;border-color:#A3B5C9;border-width:1px;border-style:Solid;font-size:12px;
                                padding: 3px 3px 3px 3px" ValidationGroup="vgKart"></asp:TextBox>
                        </td>
                        <td align="left" style="width: 50px">
                            <asp:RequiredFieldValidator runat="server" 
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
                                style="padding: 3px 3px 3px 3px;border:1px solid #CCCCCC;background:#ededed;color:#006699;font-size:12px;
                                font-weight:normal;font-style:normal;text-decoration:none;" Width="250px"></asp:DropDownList>
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
                            <asp:RequiredFieldValidator runat="server" 
                                ControlToValidate="txtNumara" Display="Dynamic" ErrorMessage="Gerekli Alan" 
                                ToolTip="Gerekli Alan" ValidationGroup="vgKart">*</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator runat="server" 
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
                            <asp:RequiredFieldValidator runat="server" 
                                ControlToValidate="txtGuvenlik" Display="Dynamic" ErrorMessage="Gerekli Alan" 
                                ToolTip="Gerekli Alan" ValidationGroup="vgKart">*</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator runat="server" 
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
                            <asp:RequiredFieldValidator runat="server" 
                                ControlToValidate="txtAy" Display="Dynamic" ErrorMessage="Gerekli Alan" 
                                ToolTip="Gerekli Alan" ValidationGroup="vgKart">*</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator runat="server" 
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
                            <asp:RequiredFieldValidator runat="server" 
                                ControlToValidate="txtYil" Display="Dynamic" ErrorMessage="Gerekli Alan" 
                                ToolTip="Gerekli Alan" ValidationGroup="vgKart">*</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator  runat="server" 
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
                                style="padding: 3px 3px 3px 3px;border:1px solid #CCCCCC;background:#ededed;color:#006699;font-size:12px;
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
                            <asp:Button ID="btnKartEkle" runat="server" Text="Ekle"
                                style="color:#284775;background-color:#FFFBFF;
                                border-color:#CCCCCC;border-width:1px;border-style:Solid;font-family:Verdana;font-size:12px;" 
                                ValidationGroup="vgKart" onclick="btnKartEkle_Click" />
                            <asp:Label runat="server" Width="50px"></asp:Label>
                            <asp:Button ID="btnKartGuncelle" runat="server" Text="Güncelle" Enabled="false"
                                style="color:#284775;background-color:#FFFBFF;
                                border-color:#CCCCCC;border-width:1px;border-style:Solid;font-family:Verdana;font-size:12px;" 
                                ValidationGroup="vgKart" onclick="btnKartGuncelle_Click" />
                            <asp:Label runat="server" Width="50px"></asp:Label>
                            <asp:Button ID="btnKartSil" runat="server" Text="Sil" Enabled="false"
                                style="color:#284775;background-color:#FFFBFF;
                                border-color:#CCCCCC;border-width:1px;border-style:Solid;font-family:Verdana;font-size:12px;" 
                                onclick="btnKartSil_Click" />
                        </td>
                        <td align="center" style="padding-top: 10px">
                            &nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="center"><asp:LinkButton runat="server" ID="lbKartlarKapat" Font-Bold="true" onclick="lbKartlarKapat_Click">Kapat</asp:LinkButton></td>
        </tr>
        </table>
    </div>
    <div style="width: 100%; font-size: 9px; font-family: Verdana; background-color: #EFEEEA; border-bottom: 1px solid #FFCFB2"">
    <table cellpadding="5" cellspacing="0">
    <tr>
    <td style="width: 800px;" valign="middle">
        <table cellpadding="0" cellspacing="0"><tr><td>
        <input type="button" value="Giriş" onclick="javascript:window.location.href='default.aspx'" /> 
        <input type="button" value="Aktiviteler" onclick="javascript:window.location.href='aktiviteler.aspx'" /> 
        <input type="button" value="H.Bedelleri" onclick="javascript:window.location.href='hizmetbedelleri.aspx'" /> 
        <input type="button" value="Anlaşmalar" onclick="javascript:window.location.href='anlasmalar.aspx'" /> 
        <input type="button" value="Siparişler" onclick="javascript:window.location.href='siparisler.aspx'" /> 
        <input type="button" value="İadeler" onclick="javascript:window.location.href='iadeler.aspx'" /> 
        <input type="button" value="Tahsilatlar" onclick="javascript:window.location.href='odemeler.aspx'" /> 
        <input type="button" value="Raporlar" onclick="javascript:window.location.href='hesapayrinti.aspx'" /> 
        <input type="button" value="Üye İşlemleri" disabled="disabled" /> 
        <input type="button" value='Mesajlar (<%= Sultanlar.DatabaseObject.Internet.GonderilenMesajlar.GetObjectCount(((Sultanlar.DatabaseObject.Internet.Musteriler)Session["Musteri"]).pkMusteriID).ToString() %>)' onclick="javascript:window.location.href='mesajlar.aspx'" /></td><td align="left"></td></tr></table>
    </td>
    <td style="width: 200px; font-family: Gisha; font-size: 12px" align="right">
        <table cellpadding="0" cellspacing="0"><tr><td><asp:Label ID="Label1" runat="server"></asp:Label>&nbsp;&nbsp;&nbsp;</td><td><asp:ImageButton runat="server" ID="ImageButton1" OnClick="ImageButton1_Click" ImageUrl="img/ic_logout.png" /></td></tr></table>
    </td>
    </tr>
    </table>
    </div>
    <div style="width: 100%; background-color: #FFFFFF">
    <table cellpadding="0" cellspacing="0" style="font-size: 10px; font-family: Verdana; 
        background-position: center center; background-image: url('img/bg-logo.jpg'); background-repeat: no-repeat; ">
        <tr>
            <td>
            <div class="Baslik">
            <table cellpadding="0" cellspacing="0"><tr>
            <td><img src="img/ic_uyelik.png" /></td>
            <td>Üyelik İşlemleri</td>
            </tr></table>
            </div>
            </td>
        </tr>
        <tr>
            <td align="center">
            <div style="font-size: 11px; font-weight: bold; padding: 0px 10px 10px 10px; color: #C00000">
            <asp:Label runat="server" ID="lblGuncellendi" Visible="False">Bilgileriniz güncellenmiştir.
            </asp:Label>
            <h2><asp:Label runat="server" ID="lblSifreZorunlu" Visible="False">Aşağıdaki menüden şifrenizi değiştirmeniz gerekmektedir.
            </asp:Label></h2>
            </div>
            </td>
        </tr>
        <tr>
            <td align="center">
                
                <table cellpadding="3" cellspacing="0" 
                    style="border: 1px solid #CCCCCC; font-family: Verdana; font-size: 9px; width: 500px; text-align: left; color: #6D8AAA; 
                    background-image: url('img/bg-table.png'); background-repeat: repeat; border: 1px solid #D1D1D1; border-radius: 5px; padding: 5px;" 
                    border="0">
                    <tr>
                        <td style="width: 150px; text-align: right; padding-top: 10px;">
                            Yeni
                            Şifre:</td>
                        <td style="text-align: right; padding-top: 10px;">
                            &nbsp;</td>
                        <td style="padding-top: 10px;">
                            <asp:TextBox ID="txtSifre" runat="server" Width="300px" TextMode="Password" 
                                BorderColor="#A3B5C9" BorderStyle="Solid" BorderWidth="1px" MaxLength="16" 
                                Font-Size="12px" ForeColor="#006699" style="padding: 3px 3px 3px 3px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right;">
                            Yeni
                            Şifre Tekrar:</td>
                        <td style="text-align: right">
                            <asp:CompareValidator ID="CompareValidator1" runat="server" 
                                ControlToCompare="txtSifre" ControlToValidate="txtSifreTekrar" 
                                Display="Dynamic" ErrorMessage="Şifre tekrarı yanlış girildi." ToolTip="Tekrar yanlış" 
                                ValidationGroup="vgKayit">*</asp:CompareValidator>
                        </td>
                        <td>
                            <asp:TextBox ID="txtSifreTekrar" runat="server" Width="300px" 
                                TextMode="Password" BorderColor="#A3B5C9" BorderStyle="Solid" 
                                BorderWidth="1px" MaxLength="16" Font-Size="12px" ForeColor="#006699" style="padding: 3px 3px 3px 3px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right;">
                            Ad:</td>
                        <td style="text-align: right">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                ControlToValidate="txtAd" Display="Dynamic" ErrorMessage="Ad gereklidir." 
                                ToolTip="Gerekli alan" ValidationGroup="vgKayit">*</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:TextBox ID="txtAd" runat="server" Width="300px" BorderColor="#A3B5C9" 
                                BorderStyle="Solid" BorderWidth="1px" MaxLength="80" Font-Size="12px" 
                                ForeColor="#006699" Enabled="False" ReadOnly="True" style="padding: 3px 3px 3px 3px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right;">
                            Soyad:</td>
                        <td style="text-align: right">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                                ControlToValidate="txtSoyad" Display="Dynamic" ErrorMessage="Soyad gereklidir." 
                                ToolTip="Gerekli alan" ValidationGroup="vgKayit">*</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:TextBox ID="txtSoyad" runat="server" Width="300px" BorderColor="#A3B5C9" 
                                BorderStyle="Solid" BorderWidth="1px" MaxLength="80" Font-Size="12px" 
                                ForeColor="#006699" Enabled="False" ReadOnly="True" style="padding: 3px 3px 3px 3px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right;">
                            İl:</td>
                        <td style="text-align: right">
                            &nbsp;</td>
                        <td>
                   		<asp:DropDownList ID="ddlIl" runat="server" Width="300px" 
                                                    Font-Bold="False" Font-Italic="False" Height="25px"
                    		Font-Overline="False" Font-Size="12px" 
                                                    Font-Strikeout="False" 
                    		Font-Underline="False" style="filter: alpha(opacity=80); -moz-opacity: .80; opacity: .80; padding: 3px 3px 3px 3px;border:1px solid #CCCCCC;background:#ededed;"
                    		ForeColor="#006699" Enabled="False">
                		</asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right;">
                            Telefon:</td>
                        <td style="text-align: right">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                                ControlToValidate="txtTelefon" Display="Dynamic" ErrorMessage="Telefon gereklidir." 
                                ToolTip="Gerekli alan" ValidationGroup="vgKayit">*</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:TextBox ID="txtTelefon" runat="server" Width="300px" BorderColor="#A3B5C9" 
                                BorderStyle="Solid" BorderWidth="1px" MaxLength="15" Font-Size="12px" 
                                ForeColor="#006699" style="padding: 3px 3px 3px 3px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right;">
                            Eposta:</td>
                        <td style="text-align: right">
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                ControlToValidate="txtEposta" ErrorMessage="Eposta formatı yanlış." 
                                ToolTip="Format yanlış" 
                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                                ValidationGroup="vgKayit">*</asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                                ControlToValidate="txtEposta" ErrorMessage="Eposta gereklidir." 
                                ToolTip="Gerekli alan" ValidationGroup="vgKayit">*</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:TextBox ID="txtEposta" runat="server" Width="300px" BorderColor="#A3B5C9" 
                                BorderStyle="Solid" BorderWidth="1px" MaxLength="80" Font-Size="12px" 
                                ForeColor="#006699" Enabled="False" ReadOnly="True" style="padding: 3px 3px 3px 3px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right;">
                            Vergi no veya TC kimlik no:</td>
                        <td style="text-align: right">
                            &nbsp;</td>
                        <td>
                            <asp:TextBox ID="txtVergiNo" runat="server" Width="300px" BorderColor="#A3B5C9" 
                                BorderStyle="Solid" BorderWidth="1px" MaxLength="16" Font-Size="12px" 
                                ForeColor="#006699" Enabled="False" ReadOnly="True" style="padding: 3px 3px 3px 3px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right;">
                            Vergi dairesi:</td>
                        <td style="text-align: right">
                            &nbsp;</td>
                        <td>
                            <asp:TextBox ID="txtVergiDairesi" runat="server" Width="300px" 
                                BorderColor="#A3B5C9" BorderStyle="Solid" BorderWidth="1px" MaxLength="31" 
                                Font-Size="12px" ForeColor="#006699" Enabled="False" ReadOnly="True" style="padding: 3px 3px 3px 3px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right;">
                            Önerilen satış fiyatı yüzdesi:</td>
                        <td style="text-align: right">
                            &nbsp;</td>
                        <td>
                            <asp:TextBox ID="txtOnerilenFiyatYuzde" runat="server" Width="300px" onkeypress="return isNumberKey(event)"
                                BorderColor="#A3B5C9" BorderStyle="Solid" BorderWidth="1px" MaxLength="2" 
                                Font-Size="12px" ForeColor="#006699" style="padding: 3px 3px 3px 3px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right;">
                            Sipariş sayfası ürün sayısı:</td>
                        <td style="text-align: right">
                            &nbsp;</td>
                        <td>
                            <asp:TextBox ID="txtSiparisUrunSayisi" runat="server" Width="300px" onkeypress="return isNumberKey(event)"
                                BorderColor="#A3B5C9" BorderStyle="Solid" BorderWidth="1px" MaxLength="3" 
                                Font-Size="12px" ForeColor="#006699" style="padding: 3px 3px 3px 3px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right;">
                            Rapor sayfaları satır sayısı:</td>
                        <td style="text-align: right">
                            &nbsp;</td>
                        <td>
                            <asp:TextBox ID="txtRaporSatirSayisi" runat="server" Width="300px" onkeypress="return isNumberKey(event)"
                                BorderColor="#A3B5C9" BorderStyle="Solid" BorderWidth="1px" MaxLength="3" 
                                Font-Size="12px" ForeColor="#006699" style="padding: 3px 3px 3px 3px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right;">
                            Siparişler sayfalası satır sayısı:</td>
                        <td style="text-align: right">
                            &nbsp;</td>
                        <td>
                            <asp:TextBox ID="txtSiparisSatirSayisi" runat="server" Width="300px" onkeypress="return isNumberKey(event)"
                                BorderColor="#A3B5C9" BorderStyle="Solid" BorderWidth="1px" MaxLength="3" 
                                Font-Size="12px" ForeColor="#006699" style="padding: 3px 3px 3px 3px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right;">
                            &nbsp;</td>
                        <td style="text-align: right">
                            &nbsp;</td>
                        <td align="right" style="padding-right: 14px; padding-bottom: 10px;">
                    
                            <asp:Button ID="btnGuncelle" runat="server" Text="Güncelle" Width="100px" 
                                onclick="btnGuncelle_Click" BorderColor="#CCCCCC" BorderStyle="Solid" 
                                BorderWidth="1px" Font-Bold="False" ForeColor="#6D8AAA" 
                                ValidationGroup="vgKayit" />
                    
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: center; padding-bottom: 10px;" colspan="3">
                                <asp:Button ID="btnKartlarim" runat="server" Text="Kredi Kartlarım" Width="150px" 
                                onclick="btnKartlarim_Click" BorderColor="#CCCCCC" BorderStyle="Solid" 
                                BorderWidth="1px" Font-Bold="False" ForeColor="#6D8AAA" Visible="false"  />
                        <asp:Label runat="server" Width="100px"></asp:Label>
                                <asp:Button ID="btnAdreslerim" runat="server" Text="Sevk Adreslerim" Width="150px" 
                                onclick="btnAdreslerim_Click" BorderColor="#CCCCCC" BorderStyle="Solid" 
                                BorderWidth="1px" Font-Bold="False" ForeColor="#6D8AAA" Visible="false"  />
                        </td>
                    </tr>
                </table>

            </td>
        </tr>
        <tr>
            <td style="padding: 20px 20px 20px 50px; font-size: 11px">
                <span style="color: #C00000; font-weight: bold">Not:</span>
                Yeni şifre belirlemek istemiyorsanız, &quot;Yeni Şifre&quot; ve &quot;Yeni Şifre Tekrar&quot; 
                bölümlerini <u>boş bırakınız.</u>
                <br /></td>
        </tr>
    </table>
    </div>
    </ContentTemplate></asp:UpdatePanel>
<uc1:ucAlt ID="ucAlt1" runat="server" />
    </form>
</body>
</html>
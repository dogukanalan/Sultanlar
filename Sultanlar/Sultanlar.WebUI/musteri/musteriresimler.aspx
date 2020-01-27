<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="musteriresimler.aspx.cs" Inherits="Sultanlar.WebUI.musteri.musteriresimler" %>

<%@ Register src="ucAlt.ascx" tagname="ucAlt" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
        <title>Sultanlar : Müşteri Resimleri</title>
    <link rel="stylesheet" type="text/css" href="StyleSheet.css" />
    <script type="text/javascript" src="js/jquery-1.2.6.pack.js"></script>
    <script type="text/javascript" src="js/jquery-1.8.3.js"></script>
    <script type="text/javascript" src="js/jquery-ui.js"></script>
    <link rel="stylesheet" href="js/jquery-ui.css" />
    <script type="text/javascript" src="js/scripts.js"></script>
</head>
<body style="margin: 0 0 0 0;background-color: #EFEEEA;">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <script type="text/javascript">
        Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(function (evt, args) {
            $("input[type=submit], input[type=button]").button();
        });
    </script>

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
        <input type="button" value="Üye İşlemleri" onclick="javascript:window.location.href='uyelik.aspx'" /> 
        <input type="button" value='Mesajlar (<%= Sultanlar.DatabaseObject.Internet.GonderilenMesajlar.GetObjectCount(((Sultanlar.DatabaseObject.Internet.Musteriler)Session["Musteri"]).pkMusteriID).ToString() %>)' onclick="javascript:window.location.href='mesajlar.aspx'" /></td><td align="left"></td></tr></table>
    </td>
    <td style="width: 200px; font-family: Gisha; font-size: 12px" align="right">
        <table cellpadding="0" cellspacing="0"><tr><td><asp:Label ID="Label1" runat="server"></asp:Label>&nbsp;&nbsp;&nbsp;</td><td><asp:ImageButton runat="server" ID="ImageButton1" OnClick="ImageButton1_Click" ImageUrl="img/ic_logout.png" /></td></tr></table>
    </td>
    </tr>
    </table>
    </div>

    <div style="width: 100%; background-color: #FFFFFF; font-size: 10px; font-family: Verdana; ">
    <div style="width: 1000px; background-position: center center; background-image: url('img/bg-logo.jpg'); background-repeat: no-repeat;">

        <div class="Baslik">
        <table cellpadding="0" cellspacing="0"><tr>
        <td><img src="img/ic_rutlar.png" /></td>
        <td>Müşteri Resimleri</td>
        </tr></table>
        </div>
        <table cellpadding="5" cellspacing="0">
        <tr>
        <td>
            <span>Personel:</span>
        </td>
        <td>
            <asp:DropDownList runat="server" ID="ddlTemsilciler" AutoPostBack="true" ForeColor="#006699" OnSelectedIndexChanged="btnAra_Changed"
                Width="800px" style="padding: 3px 3px 3px 3px;border:1px solid #CCCCCC;background:#ededed;"></asp:DropDownList>
        </td>
        </tr>
        <tr>
        <td>
            <span>Müşteri:</span>
        </td>
        <td>
            <asp:TextBox runat="server" ID="txtMusteriAra" ForeColor="#006699" 
                Width="100px" style="padding: 3px 3px 3px 3px;border:1px solid #CCCCCC;background:#ededed;"></asp:TextBox>
            <asp:Button runat="server" Text="Ara" OnClick="btnAra_Changed" Width="60px" />
            <asp:DropDownList runat="server" ID="ddlMusteriler" AutoPostBack="false" ForeColor="#006699"
                Width="600px" style="padding: 3px 3px 3px 3px;border:1px solid #CCCCCC;background:#ededed;"></asp:DropDownList>
            <asp:Button runat="server" Text="Getir" OnClick="btnGetir_Changed" Width="60px" />
        </td>
        </tr>
        </table>
        <br />
        <asp:Repeater runat="server" ID="rp1">
        <HeaderTemplate><table cellpadding="5" cellspacing="0"><tr style="color: Red">
            <td style="width: 100px; text-align: center; border-bottom: 1px solid Gray">Ekleyen</td>
            <td style="width: 120px; text-align: center; border-bottom: 1px solid Gray">Tür</td>
            <td style="width: 80px; text-align: center; border-bottom: 1px solid Gray">Tarih</td>
            <td style="width: 500px; text-align: center; border-bottom: 1px solid Gray">Açıklama</td>
            <td style="width: 50px; text-align: center; border-bottom: 1px solid Gray">Resim</td>
        </tr></HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td valign="middle"><%# Eval("AdSoyad")%></td>
                <td valign="middle"><%# Eval("strTur")%></td>
                <td valign="middle"><%# Eval("dtTarih")%></td>
                <td valign="middle"><%# Eval("strAciklama")%></td>
                <td><a href='resim2.aspx?str=musres-<%# Eval("ID")%>'><img src='resim.aspx?musres=<%# Eval("ID")%>' alt='<%# Eval("strAciklama")%>' style="height: 50px;" /></a></td>
            </tr>
        </ItemTemplate>
        <FooterTemplate></table></FooterTemplate>
        </asp:Repeater>
        <br />
        <asp:Label runat="server" ID="lblYok" Visible="false" Text="Seçilen müşteriye ait resim bulunmamaktadır." Font-Italic="true"></asp:Label>
        <br /><br /><br />
        </div></div>
        <uc1:ucAlt ID="ucAlt1" runat="server" />
    </form>
</body>
</html>

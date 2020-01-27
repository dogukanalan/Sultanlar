<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="brosur.aspx.cs" Inherits="Sultanlar.WebUI.musteri.brosur" %>

<%@ Register src="ucAlt.ascx" tagname="ucAlt" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Sultanlar : Broşürler</title>
    <script type="text/javascript" src="js/jquery-1.8.3.js"></script>
    <script type="text/javascript" src="js/jquery.jflip-0.4.js"></script>
    <script type="text/javascript" src="js/jquery-ui.js"></script>
    <link rel="stylesheet" href="js/jquery-ui.css" />
    <script type="text/javascript">
        (function ($) {
            $(function () {
                $("#g1").jFlip(750, 750, { background: "white", cornersTop: false })
            });
        })(jQuery);
    </script>
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
        <div style="width: 1000px; background-position: center center; background-image: url('img/bg-logo.jpg'); background-repeat: no-repeat; text-align: center">
        <div runat="server" id="divIcerik"></div>
        </div>
        <uc1:ucAlt ID="ucAlt1" runat="server" />

    </form>
</body>
</html>

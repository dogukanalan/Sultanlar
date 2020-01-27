<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="mesaj.aspx.cs" Inherits="Sultanlar.WebUI.merch.mesaj" %>

<%@ Register src="ucProgress.ascx" tagname="ucProgress" tagprefix="uc1" %>
<%@ Register src="ucUst.ascx" tagname="ucUst" tagprefix="uc2" %>
<%@ Register src="ucAlt.ascx" tagname="ucAlt" tagprefix="uc3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="cache-control" content="no-cache" />
    <meta name="viewport" content="width=device-width,initial-scale=1">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="StyleSheet.css" />
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script type="text/javascript" src="JScript.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="login-page">
            <div class="form">
                <uc2:ucUst ID="ucUst" runat="server" />
                <table cellpadding="5" cellspacing="0" style="width: 100%; height: 100%; background-color: #ffffff; font-family: Tahoma; font-size: 12px;
                    padding: 5px;" runat="server" id="tableMesaj">
                <tr>
                <td align="center" valign="top">
                    <table cellpadding="3" cellspacing="0" style="width: 100%;">
                        <tr>
                            <td align="left" valign="top"><asp:Label runat="server" ID="lblZaman" Font-Italic="true"></asp:Label></td>
                        </tr>
                    </table>
					<br />
                    <asp:Label runat="server" ID="lblKonu" ForeColor="#b45c0e" Font-Bold="true"></asp:Label>
                    <br /><br />
                    <div style="width: 100%; text-align: left; padding: 5px">
                        <asp:Label runat="server" ID="lblIcerik"></asp:Label>
                    </div>
                </td>
                </tr>
                </table>
                <table cellpadding="5" cellspacing="0" style="width: 100%; height: 100%; background-color: #ffffff; font-family: Tahoma; font-size: 12px;
                    padding: 5px;" runat="server" id="tableSil">
                <tr>
                <td align="center" valign="top">
                    Mesaj silinmiştir.<br /><br />
                    <a href="javascript:window.history.back();" class="button">Geri Dön</a>
                </td>
                </tr>
                </table>
                <uc3:ucAlt ID="ucAlt1" runat="server" />
            </div>
        </div>
        <uc1:ucProgress ID="ucProgress1" runat="server" />
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="kutuphane.aspx.cs" Inherits="Sultanlar.WebUI.merch.kutuphane" %>

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
    <link rel="stylesheet" href="https://code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script type="text/javascript" src="https://code.jquery.com/ui/1.12.1/jquery-ui.min.js"></script>
    <script type="text/javascript" src="JScript.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="login-page">
            <div class="form">
                <uc2:ucUst ID="ucUst" runat="server" />
                    <br />
                    <asp:TextBox runat="server" ID="txtFarkliZiyaretSube" Width="70%" placeholder="Buradan arayabilirsiniz..." autocomplete="off" onkeypress="return clickButton(event,'btnFarkliZiyaretAra')"></asp:TextBox>
                    <asp:Button runat="server" ID="btnFarkliZiyaretAra" Width="20%" Text="Ara" OnClientClick="Goster()" OnClick="btnFarkliZiyaretAra_Click" />
                    <br />
                    <asp:Repeater runat="server" ID="rpZiyaretCariler">
                    <HeaderTemplate><table cellpadding="4" cellspacing="0">
                    <tr style="color: #D00000">
                        <td style="border-bottom: 1px solid #CCCCCC; height: 20px; width: 40%">Dosya</td>
                        <td style="border-bottom: 1px solid #CCCCCC; height: 20px; width: 20%">Tür</td>
                        <td style="border-bottom: 1px solid #CCCCCC; height: 20px; width: 20%">Tarih</td>
                        <td style="border-bottom: 1px solid #CCCCCC; height: 20px; width: 20%">İşlem</td>
                    </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td style="width: 40%"><%#Eval("strAd").ToString()%></td>
                            
                            <td style="width: 20%"><%#Eval("strDosyaTur").ToString()%></td>

                            <td style="width: 20%"><%#Eval("dtTarih").ToString()%></td>

                            <td style="width: 20%"><a href='download.aspx?kutupid=<%#Eval("pkID").ToString()%>&kac=1&tur=<%#Eval("strDosyaTur").ToString()%>&ad=<%#Eval("strAd").ToString().Replace(" ", "_")%>' class="button">indir</a></td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate></table></FooterTemplate>
                    </asp:Repeater>
                    <asp:Label runat="server" ID="lblDosyaYok" Font-Italic="true" Text="<br><br>- Dosya Bulunamadı -<br><br>" Visible="false" style="padding-left: 100px"></asp:Label>

                <uc3:ucAlt ID="ucAlt1" runat="server" />
            </div>
        </div>
        <uc1:ucProgress ID="ucProgress1" runat="server" />
    </form>
</body>
</html>

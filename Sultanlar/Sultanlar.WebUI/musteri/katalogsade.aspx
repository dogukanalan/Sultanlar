<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="katalogsade.aspx.cs" Inherits="Sultanlar.WebUI.musteri.katalogsade" %>

<%@ Register src="ucProgress.ascx" tagname="ucProgress" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Sultanlar : Katalog</title>
    <meta name="keywords" content="katalog, insert, brosur, ürün, resim, resimler, ürün resimleri, ürün resmi, ürün katalogu, ürün kataloğu, ürün brosuru, insört, sultanlar a.ş., sultanlar grup, happy family, bulgurium, tibet, henkel, türk Henkel kimya, vileda, fhp, st grup, korozo, aktif kozmetik, sultanlar grup, arı, arımama, sultanlar" />
    <link rel="stylesheet" type="text/css" href="StyleSheet.css" />
    <script type="text/javascript">
        document.onkeydown = keyDown;
        function keyDown(evt) {
            var key;
            if (!evt) {
                evt = window.event;
                if (!evt.which) {
                    key = evt.keyCode;
                }
            } else if (evt) {
                key = evt.which;
            }
            switch (key) {
                case 37:
                    var bt = document.getElementById('lbOnceki');
                    bt.click();
                    break;
                case 39:
                    var bt = document.getElementById('lbSonraki');
                    bt.click();
                    break;
            }
        }
    </script>

    <script type="text/javascript" src="js/jquery-1.2.6.pack.js"></script>
    <script type="text/javascript" src="js/jquery-1.8.3.js"></script>
    <script type="text/javascript" src="js/jquery-ui.js"></script>
    <link rel="stylesheet" href="js/jquery-ui.css" />
</head>
<body style="font-family: Tahoma; font-size: 10px; background-color: #FFFFFF">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="AjaxScripts" runat="server" AsyncPostBackTimeout="500">
    </asp:ScriptManager>
    <asp:UpdateProgress ID="DivAjaxProg" runat="server">
        <ProgressTemplate>
            <uc1:ucProgress ID="ucProgress1" runat="server" />
        </ProgressTemplate>
    </asp:UpdateProgress>
    
    <asp:UpdatePanel ID="DivAjax" runat="server">
    <ContentTemplate>
    <table cellpadding="0" cellspacing="0" border="0" style="width: 900px">
        <tr>
            <td style="text-align: center">
                <asp:Label runat="server" ID="lblUrunKacinci2" Text="0"></asp:Label> / <asp:Label runat="server" ID="lblUrunSayisi2" Text="0"></asp:Label>
                <br /><br />
            </td>
        </tr>
    </table>
    <table cellpadding="0" cellspacing="0" border="0" style="width: 900px; height: 30px; visibility: collapse; display: none">
        <tr>
            <td style="text-align: left; padding-bottom: 3px" valign="middle">
                <asp:Button ID="Button1" runat="server" onclick="lbOnceki_Click" Text="Önceki Sayfa" Width="150px" 
                    BorderColor="#FFA968" BackColor="#FFE7D8" BorderStyle="Solid" BorderWidth="1px" ForeColor="#EE7A0B" />
            </td>
            <td style="text-align: right; padding-bottom: 3px" valign="middle">
                <asp:Button ID="Button2" runat="server" onclick="lbSonraki_Click" Text="Sonraki Sayfa" Width="150px" 
                    BorderColor="#FFA968" BackColor="#FFE7D8" BorderStyle="Solid" BorderWidth="1px" ForeColor="#EE7A0B" />
            </td>
        </tr>
    </table>
    <asp:DataList ID="dlResimli" runat="server" RepeatDirection="Horizontal" RepeatColumns="3">
        <ItemTemplate>
            <table cellpadding="0" cellspacing="0" style="width: 300px; height: 300px; border: 1px solid #bfbfbf;
                margin: 2px;border-radius: 5px; padding: 5px;">
                <tr>
                    <td colspan="2" style="border-bottom: 1px solid #bfbfbf; height: 105px">
                        <table>
                            <tr>
                                <td style="width: 275px; height: 235px; background-color: #FFFFFF" align="center" rowspan="3">
                                    <asp:Image ID="Image1" style="max-width: 210px; max-height: 210px" runat="server" ImageUrl='<%# Eval("pkResimID", "resim.aspx?uid={0}")%>' />
                                </td>
                                <td style="width: 25px; height: 30px; border-left: 1px solid #bfbfbf;"
                                    valign="middle" align="center">
                                    <asp:Image ID="Image2" runat="server" ToolTip="Yeni Ürün" ImageUrl="img/yeni.png" Visible='<%#Convert.ToBoolean(Convert.ToInt32(Eval("KYTM")) < 16)%>' />
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 25px; height: 55px; border-left: 1px solid #bfbfbf; border-top: 1px solid #bfbfbf;"
                                    valign="middle" align="center">
                                    A<br />
                                    D<br />
                                    <br />
                                    <strong><%#Eval("Adet") %></strong>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 25px; height: 25px; border-left: 1px solid #bfbfbf; border-top: 1px solid #bfbfbf;"
                                    valign="middle" align="center">
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="2" style="border-bottom: 1px solid #bfbfbf; height: 30px">
                        <input type="hidden" value='<%#Eval("pkResimID") %>' id="ResimID" runat="server" />
                        <input type="hidden" value='<%#Eval("UrunID") %>' id="UrunID" runat="server" />
                        <%# Eval("Ad") %>
                    </td>
                </tr>
                <tr>
                    <td align="center" style="border-right: 1px solid #bfbfbf; height: 30px">
                        <input type="hidden" value='<%#Eval("TedarikciAdi") %>' id="TedarikciAdi" runat="server" />
                        <input type="hidden" value='<%#Eval("TedarikciID") %>' id="TedarikciID" runat="server" />
                        <%# Eval("TedarikciAdi") %>
                    </td>
                    <td align="center" style="">
                        <input type="hidden" value='<%#Eval("KategoriAdi") %>' id="KategoriAdi" runat="server" />
                        <input type="hidden" value='<%#Eval("KategoriID") %>' id="KategoriID" runat="server" />
                        <%# Eval("KategoriAdi") %>
                    </td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:DataList>
    <table cellpadding="0" cellspacing="0" border="0" style="width: 900px; height: 30px; visibility: collapse; display: none">
        <tr>
            <td style="text-align: left; padding-bottom: 3px" valign="middle">
                <asp:Button ID="lbOnceki" runat="server" onclick="lbOnceki_Click" Text="Önceki Sayfa" Width="150px" 
                    BorderColor="#FFA968" BackColor="#FFE7D8" BorderStyle="Solid" BorderWidth="1px" ForeColor="#EE7A0B" />
            </td>
            <td style="text-align: right; padding-bottom: 3px" valign="middle">
                <asp:Button ID="lbSonraki" runat="server" onclick="lbSonraki_Click" Text="Sonraki Sayfa" Width="150px" 
                    BorderColor="#FFA968" BackColor="#FFE7D8" BorderStyle="Solid" BorderWidth="1px" ForeColor="#EE7A0B" />
            </td>
        </tr>
    </table>
    <table cellpadding="0" cellspacing="0" border="0" style="width: 900px">
        <tr>
            <td style="text-align: center">
                <br />
                <asp:Label runat="server" ID="lblUrunKacinci" Text="0"></asp:Label> / <asp:Label runat="server" ID="lblUrunSayisi" Text="0"></asp:Label>
            </td>
        </tr>
    </table>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>

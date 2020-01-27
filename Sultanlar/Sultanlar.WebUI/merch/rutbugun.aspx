<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="rutbugun.aspx.cs" Inherits="Sultanlar.WebUI.merch.rutbugun" %>

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
    <script type="text/javascript" src="coord.js"></script>
    <script type="text/javascript" src="../musteri/js/jquery.tipTip.js"></script>
    <link rel="stylesheet" type="text/css" href="../musteri/js/tipTip.css" />
    <script type="text/javascript">
        $(document).ready(function () {
            if (getParameterByName('slsref') == null) {
                document.getElementById('ddlTemsilciler').value = 0;
            }
            else {
                document.getElementById('ddlTemsilciler').value = getParameterByName('slsref');
            }
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="login-page">
            <div class="form">
                <uc2:ucUst ID="ucUst" runat="server" />
                <%--<a class="button" href="menu.aspx" onclick="Goster()">Geri Dön</a>--%>
                <asp:DropDownList runat="server" ID="ddlTemsilciler" Height="25px" ForeColor="#006699" 
                    Width="100%" style="padding: 3px 3px 3px 3px;border:1px solid #CCCCCC;background:#ededed;"></asp:DropDownList>
                <br /><br />
                <asp:DataList ID="dlRutlar" runat="server">
                    <HeaderTemplate><table cellpadding="4" cellspacing="0">
                        <tr style="color: #D00000">
                            <td style="width: 80px; text-align: center; height: 20px; border-bottom: 1px solid #CCCCCC; display: none">Gün</td>
                            <td style="width: 80px; text-align: center; height: 20px; border-bottom: 1px solid #CCCCCC; display: none">Cari Kod</td>
                            <td style="width: 50%; text-align: center; height: 20px; border-bottom: 1px solid #CCCCCC">Cari Ünvan</td>
                            <td style="width: 30%; text-align: center; height: 20px; border-bottom: 1px solid #CCCCCC">Not</td>
                            <td style="width: 20%; text-align: center; height: 20px; border-bottom: 1px solid #CCCCCC">İşlem</td>
                        </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr runat="server" class='<%#"rutArka" + (Convert.ToInt32(Eval("[YAPILDI]")) > 0).ToString()%>'>
                            <td style="width: 80px; text-align: center; display: none"><%#Convert.ToDateTime(Eval("[ZIYGUN]")).ToShortDateString()%></td>
                            <td style="width: 80px; text-align: center; display: none"><%#Eval("[SMREF]")%></td>
                            <td style="width: 50%; font-size: 12px; text-align: left">

                            <span class="kucukbilgiGoster" title="<%#Eval("SUBE").ToString()%>">
                            <%#Eval("SUBE")%>
                            </span>
                            
                            <asp:Label runat="server" Font-Bold="true" ForeColor="Red" Text=" (Ziy.Yapıldı)" Visible='<%#Convert.ToInt32(Eval("[YAPILDI]")) > 0%>'></asp:Label></td>
                            <td style="width: 30%; text-align: center"><%#Sultanlar.DatabaseObject.Internet.Rutlar.GetRutNot4Liste(Eval("BARKOD").ToString())%></td>
                            <td style="width: 20%; text-align: center">
                                <input type="hidden" value='<%#Eval("[SMREF]") %>' id="SMREF" runat="server" />
                                <input type="hidden" value='<%#Eval("[BARKOD]") %>' id="BARKOD" runat="server" />
                                <input type="hidden" value='<%#Eval("[MTIP]") %>' id="MTIP" runat="server" />
                                <input type="hidden" value='<%#Convert.ToDateTime(Eval("[ZIYGUN]")).ToShortDateString()%>' id="ZIYGUN" runat="server" />
                                <%--<asp:LinkButton class="button" ID="lbSatTemRutZiyaretBaslat" runat="server" Text="Başlat" OnClientClick="Goster()" OnClick="ZiyaretBaslat_Click" Visible='<%#Convert.ToBoolean(Eval("[BugunMu]")) && (((Sultanlar.DatabaseObject.Internet.Musteriler)Session["Musteri"]).tintUyeTipiID == 4 || ((Sultanlar.DatabaseObject.Internet.Musteriler)Session["Musteri"]).tintUyeTipiID == 6)%>'></asp:LinkButton>--%>
                                <a class="button" href='ziyaret1.aspx?mtip=<%#Eval("[MTIP]") %>&smref=<%#Eval("[SMREF]") %>&barkod=<%#Eval("[BARKOD]") %>&ziygun=<%#Convert.ToDateTime(Eval("[ZIYGUN]")).ToShortDateString() %>'>Ziyaret</a>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate></table></FooterTemplate>
                </asp:DataList>
                <asp:Label runat="server" ID="lblRutYok" Font-Italic="true" Text="<br><br>- Bulunamadı -<br><br>" Visible="false" style="padding-left: 100px"></asp:Label>
                <br />
                <asp:TextBox runat="server" ID="txtCoords1" Text="0,0" style="display: none"></asp:TextBox>
                <asp:TextBox runat="server" ID="txtCoords" Text="- Konum Alınamadı -" style="display: none"></asp:TextBox>
                <script type="text/javascript" src="https://maps.googleapis.com/maps/api/js?key=AIzaSyDXm_Z4J-I9jrTO72lGvx1jRzTWsP6qi7Q&libraries=geometry"></script>
                
                <script type="text/javascript">
                    $('#ddlTemsilciler').change(function () {
                        var val = $("#ddlTemsilciler option:selected").val();
                        window.location.href = 'rutbugun.aspx?slsref=' + val;
                    });
                </script>

                <uc3:ucAlt ID="ucAlt1" runat="server" />
                <uc1:ucProgress ID="ucProgress1" runat="server" />
            </div>
        </div>
    </form>
</body>
</html>

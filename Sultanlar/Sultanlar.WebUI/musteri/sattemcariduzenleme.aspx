<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sattemcariduzenleme.aspx.cs" Inherits="Sultanlar.WebUI.musteri.sattemcariduzenleme" %>

<%@ Register src="ucAlt.ascx" tagname="ucAlt" tagprefix="uc1" %>

<%@ Register src="ucProgress.ascx" tagname="ucProgress" tagprefix="uc2" %>

<%@ Register src="ucMesajlar.ascx" tagname="ucMesajlar" tagprefix="uc3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sultanlar : Cari Hesap Düzenleme</title>    <script type="text/javascript">
        function clickButton(e, buttonid) {
            var evt = e ? e : window.event;
            var bt = document.getElementById(buttonid);
            if (bt) {
                if (evt.keyCode == 13) {
                    bt.click();
                    return false;
                }
            }
        }
        function invisible() {
            if (document.getElementById('divMesaj') != null) {
                window.location.href = document.getElementById('lbMesajKapat').href;
                return false;
            }
            else if (document.getElementById('divIslem') != null) {
                window.location.href = document.getElementById('lbIslemKapat').href;
                return false;
            }
        }    </script>        <script type="text/javascript" src="js/jquery-1.2.6.pack.js"></script>
    <script type="text/javascript" src="js/jquery-1.8.3.js"></script>
    <script type="text/javascript" src="js/jquery-ui.js"></script>
    <link rel="stylesheet" href="js/jquery-ui.css" />
    <script type="text/javascript" src="js/scripts.js"></script>    
    <script type="text/javascript">
        $(function () {
            $("#top").click(function YukariIttir() {
                $("html,body").stop().animate({ scrollTop: "0" }, 1000);
            });
        });
        $(window).scroll(function () {
            var uzunluk = $(document).scrollTop();
            if (uzunluk > 300) $("#top").fadeIn(500);
            else { $("#top").fadeOut(500); }
        });
    </script>    <style type="text/css">
        #top{bottom:5px;right:5px;background:#147;padding:5px;color:#fff;font:bold 11px verdana;position:fixed;display:none;cursor:default;}
    </style>
    <link rel="stylesheet" type="text/css" href="StyleSheet.css" />
</head>
<body style="margin: 0 0 0 0;background-color: #EFEEEA;">
    <form id="form1" runat="server"><div id="top" style="z-index: 20;">Yukarı Çık</div>
    <asp:ScriptManager ID="AjaxScripts" runat="server">
    </asp:ScriptManager>
    <script type="text/javascript">
        Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(function (evt, args) {
            $("input[type=submit], input[type=button]").button();
            $("#rbBaglilar").button();
            $("#rbBagsizlar").button();
        });
    </script>
    <asp:UpdateProgress ID="DivAjaxProg" runat="server">
        <ProgressTemplate>
            <uc2:ucProgress ID="ucProgress1" runat="server" />
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdatePanel runat="server" ID="divAjaxDefault"><ContentTemplate>

            <uc3:ucMesajlar ID="ucMesajlar1" runat="server" />

            <div style="position: absolute; width: 420px; height: 100px; z-index: 3; left: 230px;
                top: 150px" runat="server" id="divIslem" visible="false">
                <div style="position: fixed; width: 100%; height: 100%; z-index: -1; left: 0; top: 0;
                filter: alpha(opacity=40); -moz-opacity: .40; opacity: .40; background-color: #000000" onclick="invisible()"></div>
                <table style="width: 100%; height: 100%; background-color: #ffffff; font-family: Tahoma; font-size: 12px;
                    border: 1px solid #D1D1D1; border-radius: 5px; padding: 5px;">
                <tr>
                <td align="center" valign="middle" style="padding-top: 15px; padding-bottom: 15px">
                    <asp:Label runat="server" ID="lblIslem"></asp:Label>
                    <br /><br />
                    <asp:LinkButton runat="server" ID="lbIslemKapat" 
                        onclick="lbIslemKapat_Click">Kapat</asp:LinkButton>
                </td>
                </tr>
                </table>
            </div>

    <div style="width: 100%; font-size: 9px; font-family: Verdana; background-color: #EFEEEA; border-bottom: 1px solid #FFCFB2">
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
    <div style="width: 100%; background-color: #FFFFFF">
    <table cellpadding="0" cellspacing="0" style="width: 1000px; height: 400px; font-size: 10px; font-family: Verdana;">
        <tr>
            <td align="center">
                <br /><br />
                <div runat="server" id="divSefAltlar" style="padding-left: 30px; padding-bottom: 20px">
                <asp:DropDownList runat="server" ID="ddlSefAltlar" AutoPostBack="true" Width="400px"
                    Font-Bold="False" Font-Italic="False" Height="25px" OnSelectedIndexChanged="ddlSefAltlar_SelectedIndexChanged"
                    Font-Overline="False" Font-Size="12px" Font-Strikeout="False" 
                    Font-Underline="False" style="padding: 3px 3px 3px 3px;border:1px solid #CCCCCC;background:#ededed;" ForeColor="#006699"></asp:DropDownList>
                </div>
                <div runat="server" id="divCariHesapArama" style="padding: 5px 5px 5px 30px;">
                    <%--<asp:RadioButton runat="server" ID="rbTumu" Text="Tümü" GroupName="grCariler" AutoPostBack="true" />&nbsp;--%>
                    <asp:RadioButton runat="server" ID="rbBaglilar" Checked="true" Text="Bağlı Hesaplar (Çıkarmak İçin)" GroupName="grCariler" AutoPostBack="true" OnCheckedChanged="rbTumu_CheckedChanged" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:RadioButton runat="server" ID="rbBagsizlar" Text="Bağlı Olmayan Hesaplar (Eklemek İçin)" GroupName="grCariler" AutoPostBack="true" OnCheckedChanged="rbTumu_CheckedChanged" />&nbsp;
                    <br /><br />
                    <asp:TextBox runat="server" ID="txtCariHesapAra" Width="150px" onkeypress="return clickButton(event,'btnCariHesapAra')"
                        ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" BorderWidth="1px" style="padding: 3px 3px 3px 3px"></asp:TextBox>&nbsp;
                    <asp:Button runat="server" ID="btnCariHesapAra" Width="100px" Text="Ara" OnClick="btnCariHesapAra_Click" 
                        BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" ForeColor="#6D8AAA" />&nbsp;
                    <asp:Button runat="server" ID="btnCariHesapTemizle" Width="120px" Text="Aramayı Temizle" OnClick="btnCariHesapTemizle_Click"
                        BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" ForeColor="#6D8AAA" />&nbsp;
                    <br /><br />
                    <asp:Button runat="server" ID="btnTumunuAktar" Width="120px" Text="Bu satış temsilcisinin bütün müşterilerini aktar" OnClick="btnTumunuAktar_Click"
                        BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" ForeColor="#6D8AAA" Visible="false" />
                </div>
                <br />
                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                    AllowSorting="True" AutoGenerateColumns="False" CellPadding="3" 
                    ForeColor="#333333" GridLines="None" 
                    onpageindexchanging="GridView1_PageIndexChanging" PageSize="50">
                    <Columns>
                        <asp:BoundField DataField="MUS KOD" HeaderText="Cari Kod" ReadOnly="True"></asp:BoundField>
                        <asp:BoundField DataField="MUSTERI" HeaderText="Cari Ünvan" ReadOnly="True">
                        <ItemStyle HorizontalAlign="Left" Width="400px" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Ekle">
                            <ItemTemplate>
                                <asp:CheckBox runat="server" AutoPostBack="true" Checked='<%# !Convert.ToBoolean(Eval("EKSIZ")) %>' 
                                    OnCheckedChanged="Ekle_Changed" ToolTip='<%# Eval("SMREF") %>' Enabled='<%# Convert.ToBoolean(Eval("EKSIZ")) %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Çıkar">
                            <ItemTemplate>
                                <asp:CheckBox runat="server" AutoPostBack="true" Checked='<%# Convert.ToBoolean(Eval("EKSIZ")) %>' 
                                    OnCheckedChanged="Cikar_Changed" ToolTip='<%# Eval("SMREF") %>' Enabled='<%# !Convert.ToBoolean(Eval("EKSIZ")) %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EditRowStyle BackColor="#999999" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerSettings Mode="NumericFirstLast" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" 
                        Width="400px" Font-Bold="True" Font-Italic="False" Font-Size="12px" 
                        Wrap="True" />
                    <RowStyle BackColor="#EFEFEF" ForeColor="#333333" />
                    <AlternatingRowStyle BackColor="#FFE6CC" ForeColor="#284775" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                </asp:GridView>
                <br /><br />
            </td>
        </tr>
    </table></div></ContentTemplate></asp:UpdatePanel>
<uc1:ucAlt ID="ucAlt1" runat="server" />
    </form>
</body>
</html>

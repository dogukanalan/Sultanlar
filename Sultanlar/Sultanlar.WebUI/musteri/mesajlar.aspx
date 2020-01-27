<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="mesajlar.aspx.cs" Inherits="Sultanlar.WebUI.musteri.mesajlar" %>

<%@ Register src="ucAlt.ascx" tagname="ucAlt" tagprefix="uc1" %>

<%@ Register src="ucProgress.ascx" tagname="ucProgress" tagprefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Sultanlar : Mesajlar</title>
    <script type="text/javascript">
//        function isNumberKey(evt,kontrol) {
//            var charCode = (evt.which) ? evt.which : event.keyCode
//            if (charCode == 13)
//                kontrol.value += "_";
//        }
//        function enterle() {
//            document.getElementById('txtMesaj').value = document.getElementById('txtMesaj').value.replace("\r\n", "<br />");
//            WebForm_DoPostBackWithOptions(new WebForm_PostBackOptions("btnMesajGonder", "", true, "grMesajYaz", "", false, false));
//        }
        function invisible() {
            if (document.getElementById('divMesaj') != null) {
                window.location.href = document.getElementById('lbMesajKapat').href;
                return false;
            }
            if (document.getElementById('divMesajYaz') != null) {
                window.location.href = document.getElementById('lbMesajYazKapat').href;
                return false;
            }
        }
    </script>
    <link rel="stylesheet" type="text/css" href="StyleSheet.css" />

    <script type="text/javascript" src="js/jquery-1.2.6.pack.js"></script>
    <script type="text/javascript" src="js/jquery-1.8.3.js"></script>
    <script type="text/javascript" src="js/jquery-ui.js"></script>
    <link rel="stylesheet" href="js/jquery-ui.css" />
    <script type="text/javascript" src="js/scripts.js"></script>

    <style type="text/css">

    </style>

</head>
<body style="margin: 0 0 0 0;background-color: #EFEEEA;">
    <form id="form1" runat="server">
    <asp:ScriptManager runat="server">
    </asp:ScriptManager>
    <script type="text/javascript">
        Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(function (evt, args) {
            $('#rbGelenKutusu').button();
            $('#rbGidenKutusu').button();
            $("input[type=submit], input[type=button]").button();
            //$('#RadioButtonList1').button();

        });
    </script>
    <asp:UpdateProgress ID="DivAjaxProg" runat="server">
        <ProgressTemplate>
            <uc2:ucProgress ID="ucProgress1" runat="server" />
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdatePanel runat="server" ID="divAjax">
    <ContentTemplate>

    <div style="position: absolute; width: 620px; height: 300px; z-index: 1; left: 190px;
        top: 100px" runat="server" id="divMesaj" visible="false">
        <div style="position: fixed; width: 100%; height: 100%; z-index: -1; left: 0; top: 0;
        filter: alpha(opacity=40); -moz-opacity: .40; opacity: .40; background-color: #000000" onclick="invisible()"></div>
        <table cellpadding="5" cellspacing="0" style="width: 100%; height: 100%; background-color: #ffffff; font-family: Tahoma; font-size: 12px;
            border: 1px solid #D1D1D1; border-radius: 5px; padding: 5px;">
        <tr>
        <td align="center" valign="top">
            <table cellpadding="3" cellspacing="0" style="width: 100%;">
                <tr>
                    <td align="left" valign="top"><asp:Label runat="server" ID="lblZaman" Font-Italic="true"></asp:Label></td>
                    <td align="right" valign="top"><asp:LinkButton runat="server" ID="lbMesajKapat" OnClick="lbMesajKapat_Click" Font-Underline="False" Font-Bold="true" Text="X" /></td>
                </tr>
            </table>
            <asp:Label runat="server" ID="lblKonu" ForeColor="#b45c0e" Font-Bold="true"></asp:Label>
            <br /><br />
            <div style="width: 100%; text-align: left; padding: 5px">
                <asp:Label runat="server" ID="lblIcerik"></asp:Label>
            </div>
        </td>
        </tr>
        </table>
    </div>

    <div style="position: absolute; width: 620px; height: 300px; z-index: 1; left: 190px;
        top: 100px" runat="server" id="divMesajYaz" visible="false">
        <div style="position: fixed; width: 100%; height: 100%; z-index: -1; left: 0; top: 0;
        filter: alpha(opacity=40); -moz-opacity: .40; opacity: .40; background-color: #000000" onclick="invisible()"></div>
        <table cellpadding="5" cellspacing="0" style="width: 100%; height: 100%; background-color: #ffffff; font-family: Tahoma; font-size: 12px;
            border: 1px solid #D1D1D1; border-radius: 5px; padding: 5px;">
        <tr>
        <td align="center" valign="top">
            <table cellpadding="3" cellspacing="0" style="width: 100%;">
                <tr>
                    <td align="left"></td>
                    <td align="right"><asp:LinkButton runat="server" ID="lbMesajYazKapat" OnClick="lbMesajYazKapat_Click" Font-Underline="False" Font-Bold="true" Text="X" /></td>
                </tr>
                <tr>
                    <td align="left">Departman:</td>
                    <td><asp:DropDownList ID="ddlDepartmanlar" runat="server" Width="400px" 
                                Font-Bold="False" Font-Italic="False" Height="25px"
                                Font-Overline="False" Font-Size="12px" Font-Strikeout="False" 
                                Font-Underline="False" style="filter: alpha(opacity=80); -moz-opacity: .80; opacity: .80; padding: 3px 3px 3px 3px;border:1px solid #CCCCCC;background:#ededed;" 
                                ForeColor="#006699">
                            </asp:DropDownList></td>
                </tr>
                <tr>
                    <td align="left">Konu:</td>
                    <td><asp:TextBox ID="txtKonu" runat="server" Height="22px" Width="400px" AutoPostBack="false"
                                ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" BorderWidth="1px">
                            </asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="left" valign="top">Mesaj:
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                            ControlToValidate="txtMesaj" Display="Dynamic" ErrorMessage="Gerekli Alan" 
                            ForeColor="Red" ToolTip="Gerekli Alan" ValidationGroup="grMesajYaz">*</asp:RequiredFieldValidator>
                    </td>
                    <td><asp:TextBox ID="txtMesaj" runat="server" Height="170px" Width="400px" AutoPostBack="false" 
                                ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" BorderWidth="1px" TextMode="MultiLine"
                                onfocus="this.value = this.value;">
                            </asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td align="right" style="padding-right: 60px">
<%--                    <input type="button" value="Gönder" onclick="enterle()" 
                        style="font-size: 12px; border: 1px solid #CCCCCC; color: #6D8AAA; width: 150px" />--%>
                    <asp:Button runat="server"
                            ID="btnMesajGonder" Text="Gönder" Font-Size="12px" Width="150px" 
                            onclick="btnMesajGonder_Click" BorderColor="#CCCCCC" BorderStyle="Solid" 
                            BorderWidth="1px" ForeColor="#6D8AAA" ValidationGroup="grMesajYaz" /></td>
                </tr>
            </table>
            <div style="width: 100%; text-align: left; padding: 5px">
                
            </div>
        </td>
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
        <input type="button" value="Üye İşlemleri" onclick="javascript:window.location.href='uyelik.aspx'" /> 
        <input type="button" value='Mesajlar (<%= Sultanlar.DatabaseObject.Internet.GonderilenMesajlar.GetObjectCount(((Sultanlar.DatabaseObject.Internet.Musteriler)Session["Musteri"]).pkMusteriID).ToString() %>)' disabled="disabled" /></td><td align="left"></td></tr></table>
    </td>
    <td style="width: 200px; font-family: Gisha; font-size: 12px" align="right">
        <table cellpadding="0" cellspacing="0"><tr><td><asp:Label ID="Label1" runat="server"></asp:Label>&nbsp;&nbsp;&nbsp;</td><td><asp:ImageButton runat="server" ID="ImageButton1" OnClick="ImageButton1_Click" ImageUrl="img/ic_logout.png" /></td></tr></table>
    </td>
    </tr>
    </table>
    </div>

    <div style="width: 100%; background-color: #FFFFFF">
    <div style="width: 1000px; background-position: center center; background-image: url('img/bg-logo.jpg'); background-repeat: no-repeat;">
        <div class="Baslik">
        <table cellpadding="0" cellspacing="0"><tr>
        <td><img src="img/ic_mesajlar.png" /></td>
        <td>Mesajlar</td>
        </tr></table>
        </div>
        <center>
        <table cellpadding="0" cellspacing="0" style="width: 710px; height: 400px; font-size: 10px; font-family: Verdana;">
        <tr>
            <td>
            <div class="radiobuttoncontainer">
                <asp:RadioButtonList ID="RadioButtonList1" RepeatColumns="6" RepeatLayout="Table" RepeatDirection="Horizontal" runat="server" 
                    OnSelectedIndexChanged="RadioButtonList1_CheckedChanged" AutoPostBack="true" CssClass="radiobuttonlist"></asp:RadioButtonList><br />
            </div>
            </td>
        </tr>
        <tr>
            <td valign="top" align="center" style="width: 100%; height: 100%; font-size: 12px">
            <div style="width: 100%; text-align: center" runat="server">
                <asp:Button runat="server" ID="btnMesajYaz" Text="Mesaj Yaz" Font-Bold="true" Font-Size="14px" Width="150px" 
                    onclick="btnMesajYaz_Click" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" ForeColor="#6D8AAA" />
            </div>
            <div style="padding: 10px 10px 10px 10px; width: 100%; text-align: center" runat="server">
                <asp:RadioButton runat="server" ID="rbGelenKutusu" GroupName="gKutular" AutoPostBack="true" Text="Gelen Mesajlar" 
                    OnCheckedChanged="rbGelenKutusu_CheckedChanged" Checked="true" />
                <asp:Label runat="server" Width="150px"></asp:Label>
                <asp:RadioButton runat="server" ID="rbGidenKutusu" GroupName="gKutular" AutoPostBack="true" Text="Giden Mesajlar"
                     OnCheckedChanged="rbGidenKutusu_CheckedChanged" />
            </div>
                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                    Width="700px" CellPadding="4" ForeColor="#333333" GridLines="None" 
                    onpageindexchanging="GridView1_PageIndexChanging" PageSize="20"
                    onrowediting="GridView1_RowEditing" onrowcommand="GridView1_RowCommand">
                    <Columns>
                        <asp:TemplateField>
                            <ItemStyle HorizontalAlign="Center" Width="50px" />
                            <ItemTemplate>
                                <asp:Image runat="server" ImageUrl="img/yeni.png" Visible='<%# !Convert.ToBoolean(Eval("blOkundu")) %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Departman">
                            <ItemStyle HorizontalAlign="Center" Width="180px" />
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%# Eval("strDepartman") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Konu" ShowHeader="False">
                            <ItemStyle HorizontalAlign="Left" Width="200px" CssClass="iobox" />
                            <ItemTemplate>
                                <asp:LinkButton runat="server" CausesValidation="false" CommandName="Edit"
                                    Text='<%# String.Format("{0}",Eval("strKonu")) %>'></asp:LinkButton>
                            </ItemTemplate>
                            <ControlStyle CssClass="iobox" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Tarih">
                            <ItemStyle HorizontalAlign="Center" Width="150px" />
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%# Eval("dtGondermeZamani") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemStyle HorizontalAlign="Center" Width="70px" />
                            <ItemTemplate>
                                <asp:LinkButton runat="server" CausesValidation="false" CommandName="Cevapla"
                                    Text="Cevapla" CommandArgument='<%# Eval("pkMesajID") %>' Visible='<%#rbGelenKutusu.Checked%>'></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemStyle HorizontalAlign="Center" Width="50px" />
                            <ItemTemplate>
                                <asp:LinkButton runat="server" CausesValidation="false" CommandName="Sil"
                                    Text="Sil" CommandArgument='<%# Eval("pkMesajID") %>'></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <RowStyle BackColor="#EFF3FB" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" CssClass="box" />
                    <AlternatingRowStyle BackColor="White" />
                    <EmptyDataRowStyle BackColor="Transparent" Font-Italic="true" HorizontalAlign="Center" />
                    <EmptyDataTemplate><br /><br />Mesaj Bulunmadı.</EmptyDataTemplate>
                </asp:GridView>
                <input type="hidden" runat="server" id="inputCevaplanan" />
                <br />
            </td>
        </tr>
        </table></center>
    </div>
    </div>

    </ContentTemplate>
    </asp:UpdatePanel>

<uc1:ucAlt ID="ucAlt1" runat="server" />
    </form>
</body>
</html>

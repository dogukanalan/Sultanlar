<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="anlasmalar.aspx.cs" Inherits="Sultanlar.WebUI.musteri.anlasmalar" %>

<%@ Register src="ucAlt.ascx" tagname="ucAlt" tagprefix="uc1" %>

<%@ Register src="ucProgress.ascx" tagname="ucProgress" tagprefix="uc2" %>

<%@ Register src="ucMesajlar.ascx" tagname="ucMesajlar" tagprefix="uc3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Sultanlar : Anlaşmalar</title>

    <link rel="stylesheet" type="text/css" href="StyleSheet.css" />
    <script type="text/javascript" src="js/jquery-1.2.6.pack.js"></script>
    <script type="text/javascript" src="js/jquery-1.8.3.js"></script>
    <script type="text/javascript" src="js/jquery-ui.js"></script>
    <link rel="stylesheet" href="js/jquery-ui.css" />
    <script type="text/javascript" src="js/scripts.js"></script>

    <script type="text/javascript" src="js/jquery.tipTip.js"></script>
    <script type="text/javascript" src="js/jquery.tipTip.minified.js"></script>
    <link rel="stylesheet" type="text/css" href="js/tipTip.css" />

    <script type="text/javascript">
        function invisible() {
            if (document.getElementById('divTarih') != null) {
                window.location.href = document.getElementById('lbTarihKapat').href;
                return false;
            }
            else if (document.getElementById('divAnlasma') != null) {
                window.location.href = document.getElementById('lbAnlasmaKapat').href;
                return false;
            }
        }
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
        function btTarihClick() {
            window.location.href = document.getElementById('lbTarih').href;
            return false;
        }
        function yazma(evt) {
            return false;
        }
    </script>

</head>
<body style="margin: 0 0 0 0;background-color: #EFEEEA;">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="AjaxScripts" runat="server">
    </asp:ScriptManager>
    <script type="text/javascript">
        Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(function (evt, args) {
            function callback() { };

            $('#rbCariHesapAraMusteri').button();
            $('#rbCariHesapAraSattem').button();
            $('#rbHepsi').button();
            $('#rbOnaylilar').button();
            $('#rbOnaysizlar').button();
            $("input[type=submit], input[type=button]").button();
            $('#cbTariheGore').button();
            $('#btTarih').button({ icons: { primary: 'ui-icon-tarih', secondary: null} });

            $("a[id$='lbTarihKapat']").button();
            $("a[id$='lbSilEvet']").button();
            $("a[id$='lbSilHayir']").button();
            $("a[id$='lbAnlasmaKapat']").button();
        });
    </script>
    <asp:UpdateProgress ID="DivAjaxProg" runat="server">
        <ProgressTemplate>
            <uc2:ucProgress ID="ucProgress1" runat="server" />
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdatePanel runat="server" ID="upSiparisler"><ContentTemplate>

    <uc3:ucMesajlar ID="ucMesajlar1" runat="server" />

    <div style="position: absolute; width: 420px; height: 100px; z-index: 3; left: 290px;
        top: 150px" runat="server" id="divAnlasmaSil" visible="false">
        <div style="position: fixed; width: 100%; height: 100%; z-index: -1; left: 0; top: 0;
        filter: alpha(opacity=40); -moz-opacity: .40; opacity: .40; background-color: #000000" onclick="invisible()"></div>
        <table style="width: 420px; height: 100px; background-color: #ffffff; font-family: Tahoma; font-size: 12px;
            border: 1px solid #D1D1D1; border-radius: 5px; padding: 5px;">
        <tr>
        <td align="center" valign="middle" style="padding-top: 15px; padding-bottom: 15px">
            Anlaşmayı silmek istediğinize emin misiniz?
            <br /><br />
            <asp:LinkButton runat="server" ID="lbSilEvet" 
                onclick="lbSilEvet_Click">Evet</asp:LinkButton>
                <asp:Label ID="Label4" runat="server" Width="50px"></asp:Label>
            <asp:LinkButton runat="server" ID="lbSilHayir" 
                onclick="lbSilHayir_Click">Hayır</asp:LinkButton>
        </td>
        </tr>
        </table>
    </div>

    <div style="position: absolute; width: 400px; height: 270px; z-index: 3; left: 300px;
        top: 50px" runat="server" id="divTarih" visible="false">
        <div style="position: fixed; width: 100%; height: 100%; z-index: -1; left: 0; top: 0;
        filter: alpha(opacity=40); -moz-opacity: .40; opacity: .40; background-color: #000000" onclick="invisible()"></div>
        <table cellpadding="5" style="width: 100%; height: 100%; background-color: #ffffff; font-family: Tahoma; font-size: 12px;
            border: 1px solid #D1D1D1; border-radius: 5px; padding: 5px;">
        <tr>
        <td align="center" valign="middle" colspan="2" style="font-size: 10px;">
            <asp:CheckBox runat="server" ID="cbTariheGore" Checked="true" Text="Tarih süzmesi aktif" 
                AutoPostBack="true" OnCheckedChanged="cbTariheGore_CheckedChanged" />
        </td>
        </tr>
        <tr>
        <td align="center" valign="middle">
            <asp:Calendar ID="Calendar1" runat="server" BackColor="White" 
                BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" 
                Font-Names="Verdana" Font-Size="7pt" ForeColor="Black" Height="170px" 
                Width="170px" OnSelectionChanged="Calendar1_SelectionChanged">
                <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                <NextPrevStyle VerticalAlign="Bottom" />
                <OtherMonthDayStyle ForeColor="#808080" />
                <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                <SelectorStyle BackColor="#CCCCCC" />
                <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                <WeekendDayStyle BackColor="#FFFFCC" />
            </asp:Calendar>
        </td>
        <td align="center" valign="middle">
            <asp:Calendar ID="Calendar2" runat="server" BackColor="White" 
                BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" 
                Font-Names="Verdana" Font-Size="7pt" ForeColor="Black" Height="170px" 
                Width="170px" OnSelectionChanged="Calendar2_SelectionChanged">
                <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                <NextPrevStyle VerticalAlign="Bottom" />
                <OtherMonthDayStyle ForeColor="#808080" />
                <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                <SelectorStyle BackColor="#CCCCCC" />
                <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                <WeekendDayStyle BackColor="#FFFFCC" />
            </asp:Calendar>
        </td>
        </tr>
        <tr>
        <td align="center" valign="middle" colspan="2">
            Seçim yapılan tarih aralığı: 
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label runat="server" ID="lblTarihSecim1" ForeColor="Red"></asp:Label>
            &nbsp;&nbsp;&nbsp;
            <asp:Label runat="server" ID="lblTarihSecim2" ForeColor="Red"></asp:Label>
        </td>
        </tr>
        <tr>
        <td align="center" valign="middle" colspan="2">
            <asp:LinkButton runat="server" ID="lbTarihKapat" OnClick="lbTarihKapat_Click">Uygula</asp:LinkButton>
        </td>
        </tr>
        </table>
    </div>

    <div style="position: absolute; width: 430px; z-index: 3; left: 285px; margin-bottom: 20px;
        top: 10px" runat="server" id="divAnlasma" visible="false">
        <div style="position: fixed; width: 100%; height: 100%; z-index: -1; left: 0; top: 0;
        filter: alpha(opacity=40); -moz-opacity: .40; opacity: .40; background-color: #000000" onclick="invisible()"></div>
        <table style="width: 100%; background-color: #ffffff; font-family: Tahoma; font-size: 12px;
            border: 1px solid #D1D1D1; border-radius: 5px; padding: 5px; margin-bottom: 20px;">
        <tr>
        <td align="center" valign="middle" style="padding-top: 15px; padding-bottom: 15px">
        <div style="height: 10px; width: 100%; text-align: right"><asp:ImageButton ID="ibYazdir" runat="server" ImageUrl="img/yazdir.gif" alt="Yazdır" OnClick="ibYazdir_Click" /></div>
        <span style="color: #C00000; font-family: Gisha; font-size: 16px">Anlaşma Formu</span>
        <div style="height: 10px; width: 100%; text-align: right"></div>
            <table cellpadding="3" cellspacing="0">
            <tr>
                <td style="width: 200px">Müşteri:</td>
                <td align="left" style="width: 230px">
                    <asp:TextBox runat="server" ID="txtAnlasmaMusteri" Width="200px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                        BorderWidth="1px" Height="23px" style="padding: 0px 3px 0px 3px" Text="" Enabled="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Şube Sayısı:</td>
                <td align="left">
                    <asp:TextBox runat="server" ID="txtAnlasmaSubeSayisi" Width="200px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                        BorderWidth="1px" Height="23px" style="padding: 0px 3px 0px 3px" Text="" Enabled="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>İl:</td>
                <td align="left">
                    <asp:TextBox runat="server" ID="txtAnlasmaIl" Width="200px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                        BorderWidth="1px" Height="23px" style="padding: 0px 3px 0px 3px" Text="" Enabled="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Bayi:</td>
                <td align="left">
                    <asp:TextBox runat="server" ID="txtAnlasmaBayi" Width="200px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                        BorderWidth="1px" Height="23px" style="padding: 0px 3px 0px 3px" Text="" Enabled="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Başlangıç:</td>
                <td align="left">
                    <input type="text" id="datepickerAnlasmaBaslangic" runat="server" onkeypress="return yazma(event)" style="width: 200px" disabled="disabled" />
                </td>
            </tr>
            <tr>
                <td>Bitiş:</td>
                <td align="left">
                    <input type="text" id="datepickerAnlasmaBitis" runat="server" onkeypress="return yazma(event)" style="width: 200px" disabled="disabled" />
                </td>
            </tr>
            <tr>
                <td>Anlaşma Vade KGT:</td>
                <td align="left">
                    <asp:TextBox runat="server" ID="txtAnlasmaVadeTAH" Width="200px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                        BorderWidth="1px" Height="23px" style="padding: 0px 3px 0px 3px" Text="" Enabled="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Anlaşma Vade NF:</td>
                <td align="left">
                    <asp:TextBox runat="server" ID="txtAnlasmaVadeYEG" Width="200px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                        BorderWidth="1px" Height="23px" style="padding: 0px 3px 0px 3px" Text="" Enabled="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Listelenecek SKU KGT:</td>
                <td align="left">
                    <asp:TextBox runat="server" ID="txtAnlasmaSKUTAH" Width="200px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                        BorderWidth="1px" Height="23px" style="padding: 0px 3px 0px 3px" Text="" Enabled="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Listelenecek SKU NF:</td>
                <td align="left">
                    <asp:TextBox runat="server" ID="txtAnlasmaSKUYEG" Width="200px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                        BorderWidth="1px" Height="23px" style="padding: 0px 3px 0px 3px" Text="" Enabled="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="vertical-align: top; padding-top: 30px">Hizmet Bedelleri:</td>
                <td align="left">
                    <asp:Repeater runat="server" ID="rptHizmetBedelleri">
                    <HeaderTemplate>
                    </HeaderTemplate>
                    <ItemTemplate>
                    <table width="200px" cellpadding="3" cellspacing="0" style="font-family: Tahoma; font-size: 10px; background-color: #E8E8E8">
                        <tr>
                            <td align="left" style="width: 100px">
                            </td>
                            <td align="center" style="width: 100px; font-weight: bold">
                                <span style="color: Red"><%#Eval("strBedel")%></span>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" style="width: 100px; font-weight: bold">
                                KGT Adet:
                            </td>
                            <td align="center" style="width: 100px;">
                                <%#Eval("intTAHAdet")%>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" style="width: 100px; font-weight: bold">
                                KGT Bedel:
                            </td>
                            <td align="center" style="width: 100px;">
                                <%#Convert.ToDecimal(Eval("mnTAHBedel")).ToString("C2")%>
                            </td>
                        </tr>
                        <%--<tr>
                            <td align="left" style="width: 100px; font-weight: bold">
                                TAH İskonto:
                            </td>
                            <td align="center" style="width: 100px;">
                                <%#Convert.ToDouble(Eval("flTAHIsk")).ToString("N1")%>
                            </td>
                        </tr>--%>
                        <tr>
                            <td align="left" style="width: 100px; font-weight: bold">
                                NF Adet:
                            </td>
                            <td align="center" style="width: 100px;">
                                <%#Eval("intYEGAdet")%>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" style="width: 100px; font-weight: bold">
                                NF Bedel:
                            </td>
                            <td align="center" style="width: 100px;">
                                <%#Convert.ToDecimal(Eval("mnYEGBedel")).ToString("C2")%>
                            </td>
                        </tr>
                        <%--<tr>
                            <td align="left" style="width: 100px; font-weight: bold">
                                YEG İskonto:
                            </td>
                            <td align="center" style="width: 100px;">
                                <%#Convert.ToDouble(Eval("flYEGIsk")).ToString("N1")%>
                            </td>
                        </tr>--%>
                    </table>
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                    <table width="200px" cellpadding="3" cellspacing="0" style="font-family: Tahoma; font-size: 10px; background-color: #FFE2C6">
                        <tr>
                            <td align="left" style="width: 100px">
                            </td>
                            <td align="center" style="width: 100px; font-weight: bold">
                                <span style="color: Red"><%#Eval("strBedel")%></span>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" style="width: 100px; font-weight: bold">
                                KGT Adet:
                            </td>
                            <td align="center" style="width: 100px;">
                                <%#Eval("intTAHAdet")%>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" style="width: 100px; font-weight: bold">
                                KGT Bedel:
                            </td>
                            <td align="center" style="width: 100px;">
                                <%#Convert.ToDecimal(Eval("mnTAHBedel")).ToString("C2")%>
                            </td>
                        </tr>
                        <%--<tr>
                            <td align="left" style="width: 100px; font-weight: bold">
                                TAH İskonto:
                            </td>
                            <td align="center" style="width: 100px;">
                                <%#Convert.ToDouble(Eval("flTAHIsk")).ToString("N1")%>
                            </td>
                        </tr>--%>
                        <tr>
                            <td align="left" style="width: 100px; font-weight: bold">
                                NF Adet:
                            </td>
                            <td align="center" style="width: 100px;">
                                <%#Eval("intYEGAdet")%>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" style="width: 100px; font-weight: bold">
                                NF Bedel:
                            </td>
                            <td align="center" style="width: 100px;">
                                <%#Convert.ToDecimal(Eval("mnYEGBedel")).ToString("C2")%>
                            </td>
                        </tr>
                        <%--<tr>
                            <td align="left" style="width: 100px; font-weight: bold">
                                YEG İskonto:
                            </td>
                            <td align="center" style="width: 100px;">
                                <%#Convert.ToDouble(Eval("flYEGIsk")).ToString("N1")%>
                            </td>
                        </tr>--%>
                    </table>
                    </AlternatingItemTemplate>
                    <FooterTemplate></FooterTemplate>
                    </asp:Repeater>
                </td>
            </tr>
            <tr>
                <td></td>
                <td align="left"><asp:Label ID="Label2" runat="server" Width="40px"></asp:Label>KGT<asp:Label ID="Label3" runat="server" Width="90px"></asp:Label>NF</td>
            </tr>
            <tr>
                <td>Fatura Altı İskonto:</td>
                <td align="left">
                    <asp:TextBox runat="server" ID="txtAnlasmaTAHIsk" Width="100px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                        BorderWidth="1px" Height="23px" style="padding: 0px 3px 0px 3px" Text="" Enabled="false"></asp:TextBox>
                    <asp:TextBox runat="server" ID="txtAnlasmaYEGIsk" Width="100px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                        BorderWidth="1px" Height="23px" style="padding: 0px 3px 0px 3px" Text="" Enabled="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Ciro Primi Aylık:</td>
                <td align="left">
                    <asp:TextBox runat="server" ID="txtAnlasmaTAHCiro" Width="100px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                        BorderWidth="1px" Height="23px" style="padding: 0px 3px 0px 3px" Text="" Enabled="false"></asp:TextBox>
                    <asp:TextBox runat="server" ID="txtAnlasmaYEGCiro" Width="100px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                        BorderWidth="1px" Height="23px" style="padding: 0px 3px 0px 3px" Text="" Enabled="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Ciro Primi 3 Aylık:</td>
                <td align="left">
                    <asp:TextBox runat="server" ID="txtAnlasmaTAHCiro3" Width="100px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                        BorderWidth="1px" Height="23px" style="padding: 0px 3px 0px 3px" Text="" Enabled="false"></asp:TextBox>
                    <asp:TextBox runat="server" ID="txtAnlasmaYEGCiro3" Width="100px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                        BorderWidth="1px" Height="23px" style="padding: 0px 3px 0px 3px" Text="" Enabled="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Ciro Primi 6 Aylık:</td>
                <td align="left">
                    <asp:TextBox runat="server" ID="txtAnlasmaTAHCiro6" Width="100px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                        BorderWidth="1px" Height="23px" style="padding: 0px 3px 0px 3px" Text="" Enabled="false"></asp:TextBox>
                    <asp:TextBox runat="server" ID="txtAnlasmaYEGCiro6" Width="100px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                        BorderWidth="1px" Height="23px" style="padding: 0px 3px 0px 3px" Text="" Enabled="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Ciro Primi Yıllık:</td>
                <td align="left">
                    <asp:TextBox runat="server" ID="txtAnlasmaTAHCiro12" Width="100px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                        BorderWidth="1px" Height="23px" style="padding: 0px 3px 0px 3px" Text="" Enabled="false"></asp:TextBox>
                    <asp:TextBox runat="server" ID="txtAnlasmaYEGCiro12" Width="100px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                        BorderWidth="1px" Height="23px" style="padding: 0px 3px 0px 3px" Text="" Enabled="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Ciro Primi Fatura Altı:</td>
                <td align="left">
                    <asp:TextBox runat="server" ID="txtAnlasmaTAHCiroIsk" Width="100px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                        BorderWidth="1px" Height="23px" style="padding: 0px 3px 0px 3px" Text="" Enabled="false"></asp:TextBox>
                    <asp:TextBox runat="server" ID="txtAnlasmaYEGCiroIsk" Width="100px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                        BorderWidth="1px" Height="23px" style="padding: 0px 3px 0px 3px" Text="" Enabled="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Anlaşma Dışı Bedeller:</td>
                <td align="left">
                    <asp:TextBox runat="server" ID="txtAnlasmaTAHAnlasmaDisiBedeller" Width="100px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                        BorderWidth="1px" Height="23px" style="padding: 0px 3px 0px 3px" Text="" Enabled="false"></asp:TextBox>
                    <asp:TextBox runat="server" ID="txtAnlasmaYEGAnlasmaDisiBedeller" Width="100px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                        BorderWidth="1px" Height="23px" style="padding: 0px 3px 0px 3px" Text="" Enabled="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Tüm Bedeller Toplamı:</td>
                <td align="left">
                    <asp:TextBox runat="server" ID="txtAnlasmaTAHTumBedeller" Width="100px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                        BorderWidth="1px" Height="23px" style="padding: 0px 3px 0px 3px" Text="" Enabled="false"></asp:TextBox>
                    <asp:TextBox runat="server" ID="txtAnlasmaYEGTumBedeller" Width="100px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                        BorderWidth="1px" Height="23px" style="padding: 0px 3px 0px 3px" Text="" Enabled="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Toplam Ciro:</td>
                <td align="left">
                    <asp:TextBox runat="server" ID="txtAnlasmaTAHToplamCiro" Width="100px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                        BorderWidth="1px" Height="23px" style="padding: 0px 3px 0px 3px" Text="" Enabled="false"></asp:TextBox>
                    <asp:TextBox runat="server" ID="txtAnlasmaYEGToplamCiro" Width="100px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                        BorderWidth="1px" Height="23px" style="padding: 0px 3px 0px 3px" Text="" Enabled="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Toplam Yıl Sonu Maliyet:</td>
                <td align="left">
                    <asp:TextBox runat="server" ID="txtAnlasmaTAHYilSonuMaliyet" Width="100px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                        BorderWidth="1px" Height="23px" style="padding: 0px 3px 0px 3px" Text="" Enabled="false"></asp:TextBox>
                    <asp:TextBox runat="server" ID="txtAnlasmaYEGYilSonuMaliyet" Width="100px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                        BorderWidth="1px" Height="23px" style="padding: 0px 3px 0px 3px" Text="" Enabled="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Ciro Primi Dahil Net Maliyet:</td>
                <td align="left">
                    <asp:TextBox runat="server" ID="txtAnlasmaTAHCiroPrimiDahil" Width="100px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                        BorderWidth="1px" Height="23px" style="padding: 0px 3px 0px 3px" Text="" Enabled="false"></asp:TextBox>
                    <asp:TextBox runat="server" ID="txtAnlasmaYEGCiroPrimiDahil" Width="100px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                        BorderWidth="1px" Height="23px" style="padding: 0px 3px 0px 3px" Text="" Enabled="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Açıklama:</td>
                <td align="left">
                    <asp:TextBox runat="server" ID="txtAnlasmaAciklama" Width="200px" ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" 
                        BorderWidth="1px" Height="23px" style="padding: 0px 3px 0px 3px" Text="" Enabled="false"></asp:TextBox>
                </td>
            </tr>
            </table>
            <br />
            <asp:LinkButton runat="server" ID="lbAnlasmaKapat" 
                onclick="lbAnlasmaKapat_Click">Kapat</asp:LinkButton>
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
        <input type="button" value="Anlaşmalar" disabled="disabled" /> 
        <input type="button" value="Siparişler" onclick="javascript:window.location.href='siparisler.aspx'" /> 
        <input type="button" value="İadeler" onclick="javascript:window.location.href='iadeler.aspx'" /> 
        <input type="button" value="Tahsilatlar" onclick="javascript:window.location.href='odemeler.aspx'" /> 
        <input type="button" value="Raporlar" onclick="javascript:window.location.href='hesapayrinti.aspx'" /> 
        <input type="button" value="Üye İşlemleri" onclick="javascript:window.location.href='uyeislemleri.aspx" /> 
        <input type="button" value='Mesajlar (<%= Sultanlar.DatabaseObject.Internet.GonderilenMesajlar.GetObjectCount(((Sultanlar.DatabaseObject.Internet.Musteriler)Session["Musteri"]).pkMusteriID).ToString() %>)' onclick="javascript:window.location.href='mesajlar.aspx'" /></td><td align="left"></td></tr></table>
    </td>
    <td style="width: 200px; font-family: Gisha; font-size: 12px" align="right">
        <table cellpadding="0" cellspacing="0"><tr><td><asp:Label ID="Label1" runat="server"></asp:Label>&nbsp;&nbsp;&nbsp;</td><td><asp:ImageButton runat="server" ID="ImageButton1" OnClick="ImageButton1_Click" ImageUrl="img/ic_logout.png" /></td></tr></table>
    </td>
    </tr>
    </table>
    </div>
    <div style="width: 100%; background-color: #FFFFFF">
    <table cellpadding="0" cellspacing="0" style="width: 1000px; height: 400px; font-size: 10px; font-family: Verdana; 
        background-position: center center; background-image: url('img/bg-logo.jpg'); background-repeat: no-repeat; ">
        <tr>
            <td valign="top">
                <div class="Baslik">
                <table cellpadding="0" cellspacing="0"><tr>
                <td><img src="img/ic_siparisler.png" /></td>
                <td style="width: 200px">Anlaşmalar</td>
                <td align="right" style="width: 800px">
                    
                </td>
                </tr></table>
                </div>
                <div style="padding: 10px 10px 0px 25px; font-size: 12px" runat="server" id="divHesapSecim">
                <div runat="server" id="divCariHesapArama" visible="false" style="padding: 5px 5px 5px 0px;">
                    <asp:RadioButton runat="server" ID="rbCariHesapAraMusteri" GroupName="grCariHesapAra" Text="Müşteri" />&nbsp;
                    <asp:RadioButton runat="server" ID="rbCariHesapAraSattem" Checked="true" GroupName="grCariHesapAra" Text="Satış Temsilcisi" />&nbsp;
                    <asp:TextBox runat="server" ID="txtCariHesapAra" Width="150px" onkeypress="return clickButton(event,'btnCariHesapAra')"
                        ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" BorderWidth="1px" Height="23px" style="padding: 0px 3px 0px 3px"></asp:TextBox>&nbsp;
                    <asp:Button runat="server" ID="btnCariHesapAra" Width="100px" Text="Ara" OnClick="btnCariHesapAra_Click" 
                        BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" ForeColor="#6D8AAA" BackColor="#ededed" />&nbsp;
                    <%--<asp:Button runat="server" ID="btnCariHesapTemizle" Width="100px" Text="Tümünü Getir" OnClick="btnCariHesapTemizle_Click"
                        BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" ForeColor="#6D8AAA" />&nbsp;--%>
                </div>
                <table cellpadding="0" cellspacing="0">
                <tr>
                <td valign="middle">
                <asp:DropDownList ID="ddlTemsilciler" runat="server" Width="200px" AutoPostBack="True" 
                    Font-Bold="False" Font-Italic="False" Height="25px"
                    Font-Overline="False" Font-Size="11px" Font-Strikeout="False" 
                    Font-Underline="False" style="filter: alpha(opacity=80); -moz-opacity: .80; opacity: .80; padding: 3px 3px 3px 3px;border:1px solid #CCCCCC;background:#ededed;" 
                    onselectedindexchanged="ddlTemsilciler_SelectedIndexChanged" 
                    ForeColor="#006699">
                </asp:DropDownList>
                <asp:Label ID="Label10" runat="server" Width="3px"></asp:Label>
                <asp:DropDownList ID="ddlCariHesaplar" runat="server" Width="500px" AutoPostBack="true" 
                                                    Font-Bold="False" Font-Italic="False" Height="25px"
                    Font-Overline="False" Font-Size="11px" 
                                                    Font-Strikeout="False" 
                    Font-Underline="False" style="filter: alpha(opacity=80); -moz-opacity: .80; opacity: .80; padding: 3px 3px 3px 3px;border:1px solid #CCCCCC;background:#ededed;"
                    onselectedindexchanged="ddlCariHesaplar_SelectedIndexChanged" 
                    ForeColor="#006699">
                </asp:DropDownList>
                </td>
                <td valign="middle"><asp:Label ID="Label11" runat="server" Width="3px"></asp:Label>
                <asp:ImageButton Visible="false" ImageUrl="img/ic_tarih.png" runat="server" ID="ibTarih" OnClick="ibTarih_Click" ToolTip="Tarihe Göre" class="kucukbilgiGoster" />
                <button type="button" id="btTarih" name="btTarih" onclick="btTarihClick()">Tarih Aralığı</button><asp:LinkButton Text="" runat="server" ID="lbTarih" OnClick="lbTarih_Click" />
                </td>
                </tr>
                </table>
                <asp:Label ID="Label12" runat="server" Width="207px"></asp:Label>
                <asp:DropDownList ID="ddlCariHesaplarSubeler" runat="server" 
                    AutoPostBack="true" Font-Bold="False" Font-Italic="False" Font-Overline="False" Height="25px"
                    Font-Size="11px" Font-Strikeout="False" 
                    Font-Underline="False" style="filter: alpha(opacity=80); -moz-opacity: .80; opacity: .80; padding: 3px 3px 3px 3px;border:1px solid #CCCCCC;background:#ededed;" 
                    onselectedindexchanged="ddlCariHesaplarSubeler_SelectedIndexChanged" 
                    Width="500px" ForeColor="#006699" Visible="false">
                </asp:DropDownList>
                </div>
                <div style="padding: 3px 3px 3px 25px; font-size: 11px">
                    <asp:RadioButton runat="server" ID="rbHepsi" Text="Hepsi" AutoPostBack="true" 
                        GroupName="grOnaySuzme" OnCheckedChanged="rbHepsi_Checked" />
                    <asp:RadioButton runat="server" ID="rbOnaylilar" Text="Onaylanmış" AutoPostBack="true" 
                        GroupName="grOnaySuzme" OnCheckedChanged="rbHepsi_Checked" />
                    <asp:RadioButton runat="server" ID="rbOnaysizlar" Text="Onaylanmamış" AutoPostBack="true" Checked="true"
                        GroupName="grOnaySuzme" OnCheckedChanged="rbHepsi_Checked" />
                </div>
                <div style="width: 970px; text-align: right">
                </div>
                <table cellpadding="1" cellspacing="0" style="margin-left: 10px; margin-bottom: 5px">
                        <tr style="color: #D00000">
                            <td style="width: 30px; text-align: center; height: 20px; border-bottom: 1px solid #CCCCCC">No</td>
                            <td style="width: 180px; text-align: left; height: 20px; border-bottom: 1px solid #CCCCCC">C/H Açıklaması</td>
                            <td style="width: 60px; text-align: center; height: 20px; border-bottom: 1px solid #CCCCCC">Şu.Say.</td>
                            <td style="width: 60px; text-align: center; height: 20px; border-bottom: 1px solid #CCCCCC">KGT Vade</td>
                            <td style="width: 60px; text-align: center; height: 20px; border-bottom: 1px solid #CCCCCC">NF Vade</td>
                            <td style="width: 60px; text-align: center; height: 20px; border-bottom: 1px solid #CCCCCC">KGT SKU</td>
                            <td style="width: 60px; text-align: center; height: 20px; border-bottom: 1px solid #CCCCCC">NF SKU</td>
                            <td style="width: 60px; text-align: right; height: 20px; border-bottom: 1px solid #CCCCCC">KGT F.Altı</td>
                            <td style="width: 60px; text-align: right; height: 20px; border-bottom: 1px solid #CCCCCC">NF F.Altı</td>
                            <td style="width: 60px; text-align: right; height: 20px; border-bottom: 1px solid #CCCCCC">K.C.P.F.A.</td>
                            <td style="width: 60px; text-align: right; height: 20px; border-bottom: 1px solid #CCCCCC">N.C.P.F.A.</td>
                            <td style="width: 80px; text-align: center; height: 20px; border-bottom: 1px solid #CCCCCC">Başlangıç</td>
                            <td style="width: 80px; text-align: center; height: 20px; border-bottom: 1px solid #CCCCCC">Bitiş</td>
                            <td style="width: 30px; text-align: center;"></td>
                        </tr></table>
                <asp:DataList ID="dataList" runat="server" OnItemDataBound="dataList_DataBound">
                    <HeaderTemplate><table cellpadding="1" cellspacing="0" style="margin-left: 10px">
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr onmouseover="Satir(this,true)" onmouseout="Satir(this,false)">
                            <td style="width: 30px; text-align: center; height: 30px; vertical-align: top"><%#Eval("pkID")%></td>
                            <td style="width: 170px; text-align: center; height: 30px; vertical-align: top"><%#Eval("MUSTERI")%></td>
                            <td style="width: 60px; text-align: center; height: 30px; vertical-align: top"><%#Eval("strAciklama4")%></td>
                            <td style="width: 60px; text-align: center; height: 30px; vertical-align: top"><%#Eval("intVadeTAH")%></td>
                            <td style="width: 60px; text-align: center; height: 30px; vertical-align: top"><%#Eval("intVadeYEG")%></td>
                            <td style="width: 60px; text-align: center; height: 30px; vertical-align: top"><%#Eval("intListSKUTAH")%></td>
                            <td style="width: 60px; text-align: center; height: 30px; vertical-align: top"><%#Eval("intListSKUYEG")%></td>
                            <td style="width: 60px; text-align: center; height: 30px; vertical-align: top"><%#Eval("flTAHIsk")%></td>
                            <td style="width: 60px; text-align: center; height: 30px; vertical-align: top"><%#Eval("flYEGIsk")%></td>
                            <td style="width: 60px; text-align: center; height: 30px; vertical-align: top"><%#Eval("flTAHCiroIsk")%></td>
                            <td style="width: 60px; text-align: center; height: 30px; vertical-align: top"><%#Eval("flYEGCiroIsk")%></td>
                            <td style="width: 80px; text-align: center; height: 30px; vertical-align: top"><%#Convert.ToDateTime(Eval("dtBaslangic")).ToShortDateString()%></td>
                            <td style="width: 80px; text-align: center; height: 30px; vertical-align: top"><%#Convert.ToDateTime(Eval("dtBitis")).ToShortDateString()%></td>
                            <td style="width: 20px; text-align: center; height: 30px; vertical-align: top">
                                <input type="hidden" value='<%#Eval("pkID") %>' id="pkID" runat="server" />
                                <asp:ImageButton ID="ImageButton5" class="kucukbilgiGoster" runat="server" Visible='true' ToolTip="İncele" ImageUrl="img/incele.gif" OnClick="ibIncele_Click" />
                            </td>
                            <td style="width: 20px; text-align: center; height: 30px; vertical-align: top">
                                <asp:ImageButton ID="ImageButton6" class="kucukbilgiGoster" runat="server" Visible='false' ToolTip="Sil" ImageUrl="img/sil.gif" OnClick="ibSil_Click" /><%--<%#!Convert.ToBoolean(Convert.ToInt32(Eval("intOnay")) == 1)%>--%>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate></table></FooterTemplate>
                </asp:DataList>
                <asp:Label runat="server" ID="lblAnlasmaYok" Visible="false" Text="- Listenecek satır bulunamadı. -" Font-Italic="true" style="padding-left: 200px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <table cellpadding="0" cellspacing="0" style="width: 968px; margin-left: 10px; margin-top: 5px">
                <tr>
                <td align="left"><asp:ImageButton runat="server" ID="ibOnceki" 
                        ImageUrl="img/sol_ok.gif" onclick="ibOnceki_Click" /></td>
                <td align="center">
                <asp:Label runat="server" ID="lblAnlasmaKacinci">0</asp:Label>
                /
                <asp:Label runat="server" ID="lblAnlasmaSayisi">0</asp:Label></td>
                <td align="right"><asp:ImageButton runat="server" ID="ibSonraki" 
                        ImageUrl="img/sag_ok.gif" onclick="ibSonraki_Click" /></td>
                </tr>
                </table>
                <br />
            </td>
        </tr>
    </table>
    </div>
    </ContentTemplate></asp:UpdatePanel>
    <uc1:ucAlt ID="ucAlt1" runat="server" />
    </form>
</body>
</html>

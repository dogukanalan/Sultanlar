<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucFiyatlarKampanyaAyrinti.ascx.cs" Inherits="Sultanlar.WebUI.musteri.ucFiyatlarKampanyaAyrinti" %>
<%--<script type="text/javascript">
    function clickButtonKA(e, buttonid) {
        var evt = e ? e : window.event;
        var bt = document.getElementById(buttonid);
        if (bt) {
            if (evt.keyCode == 13) {
                bt.click();
                return false;
            }
        }
    }
</script>--%>
<div style="font-size: 10px; font-family: Tahoma; width: 850px">
    <div style="width: 850px; text-align: right; padding: 10px 10px 10px 10px">
    </div>
                        <asp:DataList ID="dlListe" runat="server">
                            <HeaderTemplate>
                                <table cellpadding="0" cellspacing="0" style="width: 850px;">
                                    <tr>
                                        <td align="center" style="width: 50px; height: 35px;
                                            border-bottom-style: solid; border-bottom-width: 1px;border-bottom-color: #BFBFBF;">
                                            Resim
                                        </td>
                                        <td align="center" style="width: 300px;
                                            border-bottom-style: solid; border-bottom-width: 1px;border-bottom-color: #BFBFBF;">
                                            Ana Ürün Adı
                                        </td>
                                        <td align="center" style="width: 165px;
                                            border-bottom-style: solid; border-bottom-width: 1px;border-bottom-color: #BFBFBF;">
                                            Tedarikçi
                                        </td>
                                        <td align="center" style="width: 165px;
                                            border-bottom-style: solid; border-bottom-width: 1px;border-bottom-color: #BFBFBF;">
                                            Reyon & Kategori
                                        </td>
                                        <td align="center" style="width: 45px;
                                            border-bottom-style: solid; border-bottom-width: 1px;border-bottom-color: #BFBFBF;">
                                            Koli Ad.
                                        </td>
                                        <td align="center" style="width: 35px;
                                            border-bottom-style: solid; border-bottom-width: 1px;border-bottom-color: #BFBFBF;">
                                            Miktar
                                        </td>
                                        <td align="center" style="width: 90px;
                                            border-bottom-style: solid; border-bottom-width: 1px;border-bottom-color: #BFBFBF;">
                                            Toplam Fiyat
                                        </td>
                                    </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td align="center" style="width: 50px; height: 35px;">
                                        <img border="0" alt="" height="25px" src="img/resimyok.png" />
                                    </td>
                                    <td align="left" style="width: 300px; padding-left: 5px">
                                        <%# Eval("[MAL ACIK]")%> 
                                    </td>
                                    <td align="center" style="width: 165px;">
                                        <%# Eval("[OZEL ACIK]")%>
                                    </td>
                                    <td align="center" style="width: 165px;">
                                        <%# Eval("[REY ACIK]")%>
                                    </td>
                                    <td align="center" style="width: 45px;">
                                        <%#Eval("[KOLI]")%>
                                    </td>
                                    <td align="center" style="width: 35px;">
                                        <%#Eval("[MIKTAR]") %>
                                    </td>
                                    <td align="center" style="width: 90px;">
                                        <span id="Span2" runat="server"><%# Convert.ToDecimal(Eval("Fiyat")).ToString("N3")%></span> TL
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                </table>
                            </FooterTemplate>
                        </asp:DataList>
    <br /><br /><br />
                        <asp:DataList ID="dlHediye" runat="server">
                            <HeaderTemplate>
                                <table cellpadding="0" cellspacing="0" style="width: 850px;">
                                    <tr>
                                        <td align="center" style="width: 50px; height: 35px;
                                            border-bottom-style: solid; border-bottom-width: 1px;border-bottom-color: #BFBFBF;">
                                            Resim
                                        </td>
                                        <td align="center" style="width: 300px;
                                            border-bottom-style: solid; border-bottom-width: 1px;border-bottom-color: #BFBFBF;">
                                            Hediye Ürün Adı
                                        </td>
                                        <td align="center" style="width: 165px;
                                            border-bottom-style: solid; border-bottom-width: 1px;border-bottom-color: #BFBFBF;">
                                            Tedarikçi
                                        </td>
                                        <td align="center" style="width: 165px;
                                            border-bottom-style: solid; border-bottom-width: 1px;border-bottom-color: #BFBFBF;">
                                            Reyon & Kategori
                                        </td>
                                        <td align="center" style="width: 45px;
                                            border-bottom-style: solid; border-bottom-width: 1px;border-bottom-color: #BFBFBF;">
                                            Koli Ad.
                                        </td>
                                        <td align="center" style="width: 35px;
                                            border-bottom-style: solid; border-bottom-width: 1px;border-bottom-color: #BFBFBF;">
                                            Miktar
                                        </td>
                                        <td align="center" style="width: 90px;
                                            border-bottom-style: solid; border-bottom-width: 1px;border-bottom-color: #BFBFBF;">
                                            Toplam Fiyat
                                        </td>
                                    </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td align="center" style="width: 50px; height: 35px;">
                                        <img border="0" alt="" height="25px" src="img/resimyok.png" />
                                    </td>
                                    <td align="left" 
                                        
                                        style="width: 300px; padding-left: 5px">
                                        <%# Eval("[MAL ACIK]")%>
                                    </td>
                                    <td align="center" style="width: 165px;">
                                        <%# Eval("[OZEL ACIK]")%>
                                    </td>
                                    <td align="center" style="width: 165px;">
                                        <%# Eval("[REY ACIK]")%>
                                    </td>
                                    <td align="center" style="width: 45px;">
                                        <%#Eval("[KOLI]") %>
                                    </td>
                                    <td align="center" style="width: 35px;">
                                        <%#Eval("[MIKTAR]") %>
                                    </td>
                                    <td align="center" style="width: 90px;">
                                        <span id="Span4" runat="server"><%# Convert.ToDecimal(Eval("Fiyat")).ToString("N3")%></span> TL
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                </table>
                            </FooterTemplate>
                        </asp:DataList>
    
    </div>
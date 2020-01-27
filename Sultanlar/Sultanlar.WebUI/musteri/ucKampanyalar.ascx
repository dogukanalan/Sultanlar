<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucKampanyalar.ascx.cs" Inherits="Sultanlar.WebUI.musteri.ucKampanyalar" %>
<%@ Register src="ucKampanyaAyrinti.ascx" tagname="ucKampanyaAyrinti" tagprefix="uc2" %>
<asp:UpdateProgress ID="DivAjaxKampanyalarProg" runat="server">
    <ProgressTemplate>
        <%--            <div style="padding-top: 300px; filter: alpha(opacity=40); -moz-opacity: .40; opacity: .40;
                background-color: #000000; position: fixed; width: 100%; height: 100%; z-index: 9;
                left: 0; top: 0;">
            </div>
            <div style="padding-top: 75px; position: fixed; width: 100%; height: 100%; z-index: 10;
                left: 0; top: 0;">
                <table style="width: 300px; height: 300px; margin-left: 300px; background-color: #ffffff; border: 1px solid #D1D1D1; border-radius: 5px; padding: 5px;">
                    <tr>
                        <td style="text-align: center; border-bottom: 1px dotted #CCCCCC; height: 50px; font-size: 18px; font-family: Gisha">
                            Yükleniyor
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: center; height: 100%">
                            <br />
                            <img alt="" src="img/yukleniyor.gif" /><br />
                            <br />
                            <span style="font-family: Tahoma; font-size: 16px; color: #C5670B">lütfen bekleyin...</span><br />
                            <br />
                        </td>
                    </tr>
                </table>
            </div>--%>
    </ProgressTemplate>
</asp:UpdateProgress>
<asp:UpdatePanel ID="DivAjaxKampanyalar" runat="server">
    <ContentTemplate>
            <div style="position: absolute; width: 900px; height: 400px; z-index: 5; left: 50px; text-align: center;
                top: 50px;" runat="server" id="divKampanyaAyrinti" visible="false">
            <div style="position: fixed; width: 100%; height: 100%; z-index: -1; left: 0; top: 0;
                filter: alpha(opacity=60); -moz-opacity: .60; opacity: .60; background-color: #000000">
            </div>
            <div style="background-color: #FFFFFF; padding-top: 10px; padding-bottom: 10px; width: 900px;
                border: 1px solid #D1D1D1; border-radius: 5px; padding: 5px; font-size: 12px">
            <div style="overflow: auto; width: 900px; height: 380px;" id="divKampanyaAyrintiIc">
            <%--<iframe frameborder="0" src="kampanyaayrinti.aspx" width="900px" height="350px"></iframe>--%>
            <uc2:ucKampanyaAyrinti ID="ucKampanyaAyrinti1" runat="server" />
            </div>
            <asp:Button runat="server" ID="btnKampanyaAyrintiKapat" Text="Kapat" Width="200px" OnClick="btnKampanyaAyrintiKapat_Click" 
                BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" ForeColor="#6D8AAA" Font-Bold="true" />
            </div>
            </div>

            <div style="position: absolute; width: 300px; height: 500px; z-index: 3; left: 200px;
                top: 161px;" runat="server" id="divKategori" visible="false">
                <table style="border: 1px solid #000000; width: 300px; height: 500px; font-family: Tahoma; font-size: 10px; background-color: #EEEEEE;
                    border: 1px solid #D1D1D1; border-radius: 5px; padding: 5px;">
                    <tr>
                        <td style="border-bottom: 1px solid #CCCCCC; width: 300px; height: 20px; padding-left: 5px;
                            padding-right: 5px" valign="middle">
                            <table style="width: 100%">
                                <tr>
                                    <td align="left">
                                        Kategoriler (<asp:Label runat="server" ID="lblKategoriHarf"></asp:Label>)
                                    </td>
                                    <td align="right">
                                        <asp:LinkButton Font-Bold="true" Text="X" runat="server" ID="lbKategoriKapat" OnClick="lbKategoriKapat_Click"
                                            Font-Underline="False" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 300px; height: 480px; padding: 10px"
                            valign="top">
                            <asp:RadioButtonList ID="rblKategorilerKamp" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rblKategoriler_SelectedIndexChanged">
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                </table>
            </div>
            <div style="position: fixed; width: 100%; height: 100%; z-index: 1; left: 0; top: 0;
                filter: alpha(opacity=60); -moz-opacity: .60; opacity: .60; background-color: #000000"
                runat="server" id="divTedarikciKategoriDis" visible="false" onclick="invisible()">
            </div>
            <div style="position: absolute; width: 300px; height: 500px; z-index: 2; left: 575px;
                top: 118px;" runat="server" id="divTedarikci" visible="false">
                <table style="border: 1px solid #000000; width: 300px; height: 500px; font-family: Tahoma; font-size: 10px; background-color: #EEEEEE;
                    border: 1px solid #D1D1D1; border-radius: 5px; padding: 5px;">
                    <tr>
                        <td style="border-bottom: 1px solid #CCCCCC; width: 300px; height: 20px; padding-left: 5px;
                            padding-right: 5px" valign="middle">
                            <table style="width: 100%">
                                <tr>
                                    <td align="left">
                                        Tedarikçiler (<asp:Label runat="server" ID="lblTedarikciHarf"></asp:Label>)
                                    </td>
                                    <td align="right">
                                        <asp:LinkButton Font-Bold="true" Text="X" runat="server" ID="lbTedarikciKapat" OnClick="lbTedarikciKapat_Click"
                                            Font-Underline="False" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 300px; height: 480px; padding: 10px"
                            valign="top">
                            <asp:RadioButtonList ID="rblTedarikcilerKamp" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rblTedarikciler_SelectedIndexChanged">
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                </table>
            </div>
        <table cellpadding="0" cellspacing="0" style="width: 1000px; font-family: Tahoma;
            font-size: 10px;">
            <tr>
                <td>
                    <table cellpadding="1" cellspacing="0" style="margin-top: 5px">
                        <tr>
                            <td valign="top">
                            <table cellpadding="1" cellspacing="0">
                            <tr>
                            <td valign="middle" style="padding-left: 20px">
                            <div>


                                <asp:Panel ID="pnlSepet" runat="server" Height="60px" Width="202px">



                                Sipariş No: <asp:Label runat="server" ID="lblSiparisID1" style="color: #D00000"></asp:Label>

                                <div style="padding-left: 100px; text-align: center; vertical-align: middle">
                                    <asp:CheckBox runat="server" ID="cbKampanyaYeniUrunler" Checked="true" AutoPostBack="true" OnCheckedChanged="cbKampanyaYeniUrunler_CheckedChanged" ToolTip="Sadece Yeni Kampanyalar" Text="Sadece Yeni Kampanyalar" />
                                </div>
                                <br />
                                Toplam Tutar: <asp:Label runat="server" ID="lblToplamTutar1" Font-Bold="true">0,000 TL</asp:Label>
                                </asp:Panel>


                            </div>
                            </td>
                            <td valign="top" style="width: 600px">
                                <table cellpadding="0" cellspacing="0" style="border: 1px solid #CCCCCC;
                                    border-radius: 5px; padding: 5px;">
                                        <tr>
                                            <td colspan="24" style="font-size: 14px; font-family: Gisha; font-weight: bold; color: #EE7A0B;
                                        border-bottom: 1px solid #CCCCCC; padding-bottom: 3px">
                                                &nbsp; R e y o n &nbsp; &amp; &nbsp; K a t e g o r i &nbsp; S e ç i m i &nbsp; Y a p
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="alfabetikTDss">
                                                <asp:LinkButton ID="lbKamp0" runat="server" OnClick="Kategori_Click">0</asp:LinkButton>
                                            </td>
                                            <td class="alfabetikTDss">
                                                <asp:LinkButton ID="lbKampA" runat="server" OnClick="Kategori_Click">A</asp:LinkButton>
                                            </td>
                                            <td class="alfabetikTDss">
                                                <asp:LinkButton ID="lbKampB" runat="server" OnClick="Kategori_Click">B</asp:LinkButton>
                                            </td>
                                            <td class="alfabetikTDss">
                                                <asp:LinkButton ID="lbKampC" runat="server" OnClick="Kategori_Click">C</asp:LinkButton>
                                            </td>
                                            <td class="alfabetikTDss">
                                                <asp:LinkButton ID="lbKampD" runat="server" OnClick="Kategori_Click">D</asp:LinkButton>
                                            </td>
                                            <td class="alfabetikTDss">
                                                <asp:LinkButton ID="lbKampE" runat="server" OnClick="Kategori_Click">E</asp:LinkButton>
                                            </td>
                                            <td class="alfabetikTDss">
                                                <asp:LinkButton ID="lbKampF" runat="server" OnClick="Kategori_Click">F</asp:LinkButton>
                                            </td>
                                            <td class="alfabetikTDss">
                                                <asp:LinkButton ID="lbKampG" runat="server" OnClick="Kategori_Click">G</asp:LinkButton>
                                            </td>
                                            <td class="alfabetikTDss">
                                                <asp:LinkButton ID="lbKampH" runat="server" OnClick="Kategori_Click">H</asp:LinkButton>
                                            </td>
                                            <td class="alfabetikTDss">
                                                <asp:LinkButton ID="lbKampI" runat="server" OnClick="Kategori_Click">I</asp:LinkButton>
                                            </td>
                                            <td class="alfabetikTDss">
                                                <asp:LinkButton ID="lbKampJ" runat="server" OnClick="Kategori_Click">J</asp:LinkButton>
                                            </td>
                                            <td class="alfabetikTDss">
                                                <asp:LinkButton ID="lbKampK" runat="server" OnClick="Kategori_Click">K</asp:LinkButton>
                                            </td>
                                            <td class="alfabetikTDss">
                                                <asp:LinkButton ID="lbKampL" runat="server" OnClick="Kategori_Click">L</asp:LinkButton>
                                            </td>
                                            <td class="alfabetikTDss">
                                                <asp:LinkButton ID="lbKampM" runat="server" OnClick="Kategori_Click">M</asp:LinkButton>
                                            </td>
                                            <td class="alfabetikTDss">
                                                <asp:LinkButton ID="lbKampN" runat="server" OnClick="Kategori_Click">N</asp:LinkButton>
                                            </td>
                                            <td class="alfabetikTDss">
                                                <asp:LinkButton ID="lbKampO" runat="server" OnClick="Kategori_Click">O</asp:LinkButton>
                                            </td>
                                            <td class="alfabetikTDss">
                                                <asp:LinkButton ID="lbKampP" runat="server" OnClick="Kategori_Click">P</asp:LinkButton>
                                            </td>
                                            <td class="alfabetikTDss">
                                                <asp:LinkButton ID="lbKampR" runat="server" OnClick="Kategori_Click">R</asp:LinkButton>
                                            </td>
                                            <td class="alfabetikTDss">
                                                <asp:LinkButton ID="lbKampS" runat="server" OnClick="Kategori_Click">S</asp:LinkButton>
                                            </td>
                                            <td class="alfabetikTDss">
                                                <asp:LinkButton ID="lbKampT" runat="server" OnClick="Kategori_Click">T</asp:LinkButton>
                                            </td>
                                            <td class="alfabetikTDss">
                                                <asp:LinkButton ID="lbKampU" runat="server" OnClick="Kategori_Click">U</asp:LinkButton>
                                            </td>
                                            <td class="alfabetikTDss">
                                                <asp:LinkButton ID="lbKampV" runat="server" OnClick="Kategori_Click">V</asp:LinkButton>
                                            </td>
                                            <td class="alfabetikTDss">
                                                <asp:LinkButton ID="lbKampY" runat="server" OnClick="Kategori_Click">Y</asp:LinkButton>
                                            </td>
                                            <td class="alfabetikTDss">
                                                <asp:LinkButton ID="lbKampZ" runat="server" OnClick="Kategori_Click">Z</asp:LinkButton>
                                            </td>
                                        </tr>
                                    </table>
                            </td>
                            </tr>
                            </table>
                                
                            </td>
                            <td rowspan="2" valign="top">
                                <table cellpadding="0" cellspacing="0" runat="server" id="tblKategoriSecimi" style="border: 1px solid #CCCCCC;
                                    border-radius: 5px; padding: 5px;">
                                    <tr>
                                        <td class="alfabetikTDss">
                                            <asp:LinkButton ID="lbKamp2" runat="server" OnClick="Tedarikci_Click">0</asp:LinkButton>
                                        </td>
                                        <td rowspan="24" style="padding: 8px; 
                                            font-size: 14px; font-family: Gisha; font-weight: bold; color: #EE7A0B;
                                            border-left: 1px solid #CCCCCC;" valign="top">
                                            T<br />
                                            e<br />
                                            d<br />
                                            a<br />
                                            r<br />
                                            i<br />
                                            k<br />
                                            ç<br />
                                            i<br />
                                            <br />
                                            S<br />
                                            e<br />
                                            ç<br />
                                            i<br />
                                            m<br />
                                            i<br />
                                            <br />
                                            Y<br />
                                            a<br />
                                            p
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="alfabetikTDss">
                                            <asp:LinkButton ID="lbKampA2" runat="server" OnClick="Tedarikci_Click">A</asp:LinkButton>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="alfabetikTDss">
                                            <asp:LinkButton ID="lbKampB2" runat="server" OnClick="Tedarikci_Click">B</asp:LinkButton>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="alfabetikTDss">
                                            <asp:LinkButton ID="lbKampC2" runat="server" OnClick="Tedarikci_Click">C</asp:LinkButton>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="alfabetikTDss">
                                            <asp:LinkButton ID="lbKampD2" runat="server" OnClick="Tedarikci_Click">D</asp:LinkButton>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="alfabetikTDss">
                                            <asp:LinkButton ID="lbKampE2" runat="server" OnClick="Tedarikci_Click">E</asp:LinkButton>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="alfabetikTDss">
                                            <asp:LinkButton ID="lbKampF2" runat="server" OnClick="Tedarikci_Click">F</asp:LinkButton>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="alfabetikTDss">
                                            <asp:LinkButton ID="lbKampG2" runat="server" OnClick="Tedarikci_Click">G</asp:LinkButton>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="alfabetikTDss">
                                            <asp:LinkButton ID="lbKampH2" runat="server" OnClick="Tedarikci_Click">H</asp:LinkButton>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="alfabetikTDss">
                                            <asp:LinkButton ID="lbKampI2" runat="server" OnClick="Tedarikci_Click">I</asp:LinkButton>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="alfabetikTDss">
                                            <asp:LinkButton ID="lbKampJ2" runat="server" OnClick="Tedarikci_Click">J</asp:LinkButton>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="alfabetikTDss">
                                            <asp:LinkButton ID="lbKampK2" runat="server" OnClick="Tedarikci_Click">K</asp:LinkButton>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="alfabetikTDss">
                                            <asp:LinkButton ID="lbKampL2" runat="server" OnClick="Tedarikci_Click">L</asp:LinkButton>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="alfabetikTDss">
                                            <asp:LinkButton ID="lbKampM2" runat="server" OnClick="Tedarikci_Click">M</asp:LinkButton>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="alfabetikTDss">
                                            <asp:LinkButton ID="lbKampN2" runat="server" OnClick="Tedarikci_Click">N</asp:LinkButton>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="alfabetikTDss">
                                            <asp:LinkButton ID="lbKampO2" runat="server" OnClick="Tedarikci_Click">O</asp:LinkButton>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="alfabetikTDss">
                                            <asp:LinkButton ID="lbKampP2" runat="server" OnClick="Tedarikci_Click">P</asp:LinkButton>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="alfabetikTDss">
                                            <asp:LinkButton ID="lbKampR2" runat="server" OnClick="Tedarikci_Click">R</asp:LinkButton>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="alfabetikTDss">
                                            <asp:LinkButton ID="lbKampS2" runat="server" OnClick="Tedarikci_Click">S</asp:LinkButton>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="alfabetikTDss">
                                            <asp:LinkButton ID="lbKampT2" runat="server" OnClick="Tedarikci_Click">T</asp:LinkButton>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="alfabetikTDss">
                                            <asp:LinkButton ID="lbKampU2" runat="server" OnClick="Tedarikci_Click">U</asp:LinkButton>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="alfabetikTDss">
                                            <asp:LinkButton ID="lbKampV2" runat="server" OnClick="Tedarikci_Click">V</asp:LinkButton>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="alfabetikTDss">
                                            <asp:LinkButton ID="lbKampY2" runat="server" OnClick="Tedarikci_Click">Y</asp:LinkButton>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="alfabetikTDss">
                                            <asp:LinkButton ID="lbKampZ2" runat="server" OnClick="Tedarikci_Click">Z</asp:LinkButton>
                                        </td>
                                    </tr>
                            </table>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top" align="center" style="padding-top: 10px; height: 600px; background-position: center center; 
                                background-image: url('img/bg-logo.jpg'); background-repeat: no-repeat;">
                                <%--<table cellpadding="0" cellspacing="0">
                                <tr>
                                <td><asp:RadioButton runat="server" ID="rbListeGorunumu" Checked="true" GroupName="grDuzen" Visible="false"
                                            AutoPostBack="true" Text="Liste Görünümü" OnCheckedChanged="rbResimListeGorunumu_CheckedChanged" /></td>
                                <td><asp:RadioButton runat="server" ID="rbResimGorunumu" GroupName="grDuzen"  Visible="false"
                                            AutoPostBack="true" Text="Resim Görünümü" OnCheckedChanged="rbResimListeGorunumu_CheckedChanged" /></td>
                                </tr>
                                </table>--%>
                                <br /><br />
                                <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td align="right" style="padding-left: 10px; padding-right: 10px; padding-bottom: 10px; width: 120px">
                                        Ana Ürün Arama:
                                    </td>
                                    <td align="center" style="padding-bottom: 10px; width: 220px">
                                        <asp:TextBox runat="server" ID="txtAnaUrunArama" Height="22px" Width="220px"
                                                onkeypress="return clickButton(event,'ucKampanyalar1_btnAnaUrunArama')" 
                                                ForeColor="#006699" BorderColor="#A3B5C9" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                                    </td>
                                    <td align="left" style="padding-left: 10px; padding-bottom: 10px; width: 400px;">
                                        <asp:Button ID="btnAnaUrunArama" runat="server" BorderColor="#CCCCCC"
                                            BorderStyle="Solid" BorderWidth="1px" ForeColor="#6D8AAA" Height="22px" Font-Bold="true"
                                            onclick="btnAnaUrunArama_Click" Text="Ara" Width="50px" />
                                        <asp:Label runat="server" Width="5px"></asp:Label>
                                        <asp:Button ID="btnAnaUrunAramaTemizle" runat="server" BorderColor="#CCCCCC"
                                            BorderStyle="Solid" BorderWidth="1px" ForeColor="#6D8AAA" Height="22px" Font-Bold="true"
                                            onclick="btnAnaUrunAramaTemizle_Click" Text="Temizle" Width="80px" />
                                        <asp:Label runat="server" Width="30px"></asp:Label>
                                        Aranan Kelime:
                                        <asp:Label ID="lblAnaUrunArama" runat="server" ForeColor="Red" Text="-"></asp:Label>
                                    </td>
                                </tr>
                                </table>
                                <table cellpadding="0" cellspacing="0" style="width: 100%; height: 50px">
                                <tr>
                                    <td align="left" style="padding-left: 30px">
                                        Tedarikçi:
                                        <asp:Label ID="lblTedarikciSecim" runat="server" ForeColor="Red" Text="-"></asp:Label>
                                    </td>
                                    <td align="center">
                                        <asp:Button ID="btnSipariseAktar" runat="server" BorderColor="#FFA968" BackColor="#FFE7D8"
                                            BorderStyle="Solid" BorderWidth="1px" ForeColor="#EE7A0B" Height="22px" Font-Bold="true"
                                            onclick="btnSipariseAktar_Click" Text="Seçimi Siparişe Aktar" Width="230px" />
                                    </td>
                                    <td align="left" style="padding-left: 50px">
                                        Reyon &amp; Kategori:
                                        <asp:Label ID="lblKategoriSecim" runat="server" ForeColor="Red" Text="-"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" style="padding-left: 30px">
                                        <asp:Button ID="btnTedarikciTemizle" runat="server" BorderColor="#CCCCCC" 
                                            BorderStyle="Solid" BorderWidth="1px" ForeColor="#6D8AAA" Height="22px" 
                                            onclick="btnTedarikciTemizle_Click" Text="Tedarikçi Seçimini Temizle" 
                                            Width="230px" />
                                    </td>
                                    <td align="center" style="padding-top: 10px; padding-bottom: 10px;">
                                        <asp:Button ID="btnTedarikciKategoriTemizle" runat="server" 
                                            BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" ForeColor="#6D8AAA" 
                                            Height="22px" onclick="btnTedarikciKategoriTemizle_Click" 
                                            Text="Tüm Seçimi Temizle" Width="230px" />
                                    </td>
                                    <td align="right" style="padding-right: 30px">
                                        <asp:Button ID="btnKategoriTemizle" runat="server" BorderColor="#CCCCCC" 
                                            BorderStyle="Solid" BorderWidth="1px" ForeColor="#6D8AAA" Height="22px" 
                                            onclick="btnKategoriTemizle_Click" Text="Reyon&amp;Kategori Seçimini Temizle" 
                                            Width="230px" />
                                    </td>
                                </tr>
                                </table>
                                <asp:DataList ID="dlListe" runat="server" OnItemDataBound="dlListe_DataBound">
                                    <HeaderTemplate>
                                        <table cellpadding="0" cellspacing="0" style="width: 850px;">
                                            <tr style="color: #D00000">
                                                <td align="center" style="width: 50px; height: 35px; border-bottom-style: solid;
                                                    border-bottom-width: 1px; border-bottom-color: #BFBFBF; font-weight: bold">
                                                </td>
                                                <td align="center" style="width: 230px; border-bottom-style: solid;
                                                    border-bottom-width: 1px; border-bottom-color: #BFBFBF; font-weight: bold">
                                                    Kampanya Açıklaması
                                                </td>
                                                <td align="center" style="width: 90px; border-bottom-style: solid;
                                                    border-bottom-width: 1px; border-bottom-color: #BFBFBF; font-weight: bold">
                                                    Fiyat
                                                </td>
                                                <td align="center" style="width: 90px; border-bottom-style: solid;
                                                    border-bottom-width: 1px; border-bottom-color: #BFBFBF; font-weight: bold">
                                                    Hediye Tutarı
                                                </td>
                                                <td align="center" style="width: 60px; border-bottom-style: solid;
                                                    border-bottom-width: 1px; border-bottom-color: #BFBFBF; font-weight: bold">
                                                    İnd. %
                                                </td>
                                                <td align="center" style="width: 135px; border-bottom-style: solid;
                                                    border-bottom-width: 1px; border-bottom-color: #BFBFBF; font-weight: bold">
                                                    Başlangıç Tarihi
                                                </td>
                                                <td align="center" style="width: 135px; border-bottom-style: solid;
                                                    border-bottom-width: 1px; border-bottom-color: #BFBFBF; font-weight: bold">
                                                    Bitiş Tarihi
                                                </td>
                                                <td align="center" style="width: 30px; border-bottom-style: solid;
                                                    border-bottom-width: 1px; border-bottom-color: #BFBFBF; font-weight: bold">
                                                    Adet
                                                </td>
                                            </tr>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>
                                            <td align="center" style="width: 50px; height: 35px;">
                                                <asp:Image runat="server" Height="25" ImageUrl="img/resimyok.png" />
                                            </td>
                                            <td align="left" style="width: 230px; padding-left: 5px">
                                                <input type="hidden" runat="server" id="KAMKARTREF" value='<%# Eval("KAMKARTREF") %>' />
                                                <asp:Image runat="server" ToolTip="Yeni Kampanya" ImageUrl="img/yeni.png" Visible='<%#Convert.ToBoolean(Convert.ToInt32(Eval("KYTK")) < 16)%>' />
                                                <asp:LinkButton runat="server" OnClick="lbKampanyaAyrinti_Click"><%# Eval("KAMPNO") %> - <%# Eval("ACIKLAMA") %></asp:LinkButton>
                                               <%-- <a href='javascript:startWin("<%# Eval("KAMKARTREF") %>")'>
                                                    <%# Eval("ACIKLAMA") %></a>--%>
                                                <%--<a href="kampanyaayrinti.aspx?kid=<%# Eval("KAMKARTREF") %>"><%# Eval("ACIKLAMA") %></a>--%>
                                            </td>
                                            <td align="center" style="width: 100px;">
                                                <span id="Span1" runat="server">
                                                    <%# Convert.ToDecimal(Eval("FIYAT")).ToString("C3")%></span>
                                            </td>
                                            <td align="center" style="width: 100px;">
                                                <span id="Span2" runat="server">
                                                    <%# Convert.ToDecimal(Eval("HEDIYE")).ToString("C3")%></span>
                                            </td>
                                            <td align="center" style="width: 60px;">
                                                %<%#Eval("ISKONTO") %></td>
                                            <td align="center" style="width: 135px;">
                                                <%#Convert.ToDateTime(Eval("BASLANGIC_TARIHI")).ToShortDateString() %>
                                            </td>
                                            <td align="center" style="width: 135px;">
                                                <%#Convert.ToDateTime(Eval("BITIS_TARIHI")).ToShortDateString() %>
                                            </td>
                                            <td align="center" style="width: 30px;">
                                                <asp:TextBox runat="server" Width="20px" Height="20px" ForeColor="#006699" BorderColor="#A3B5C9"
                                                    BorderStyle="Solid" BorderWidth="1px" ToolTip="Seçim Adedi" onkeypress="return isNumberKey(event)"
                                                    class="kucukbilgiGoster"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        </table>
                                    </FooterTemplate>
                                </asp:DataList>
                                <br />
                                <asp:Label runat="server" ID="lblKampanyaYok" Font-Italic="true" Text="- Yapılan seçime göre kampanya bulunamadı -" Visible="false" style="padding-left: 100px"></asp:Label>



                                <%--<asp:DataList ID="dlResimli" runat="server" RepeatDirection="Horizontal" RepeatColumns="5">
                            <ItemTemplate>
                                <table cellpadding="0" cellspacing="0" style="width: 165px; height: 170px; border: 1px solid #bfbfbf;
                                    margin: 2px">
                                    <tr>
                                        <td colspan="2" style="border-bottom: 1px solid #bfbfbf; height: 105px">
                                            <table>
                                                <tr>
                                                    <td style="width: 140px; height: 105px" align="center" rowspan="3">
                                                        <img border="0" alt="" src="img/resimyok.png" />
                                                    </td>
                                                    <td style="width: 25px; height: 30px; border-left: 1px solid #bfbfbf;"
                                                        valign="middle" align="center">
                                                        <span id="Span1" runat="server" style="color: Red; visibility: collapse"><%# Eval("UrunID") %></span>
                                                        <asp:ImageButton ID="ImageButton1" runat="server" CommandArgument='<%#Eval("UrunID")%>' ToolTip="Kampanyalı Ürün" ImageUrl="img/gul.png" Visible='<%#Convert.ToBoolean(Convert.ToInt32(Eval("KamKartRefSayisi")) > 0)%>' OnClick="KampanyaliUrun_Click" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 25px; height: 55px; border-left: 1px solid #bfbfbf; border-top: 1px solid #bfbfbf;"
                                                        valign="middle" align="center">
                                                        A<br />
                                                        D<br />
                                                        <br />
                                                        <%#Eval("Adet") %>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 25px; height: 25px; border-left: 1px solid #bfbfbf; border-top: 1px solid #bfbfbf;"
                                                        valign="middle" align="center">
                                                        <asp:TextBox ID="TextBox1" ToolTip="Seçim Adedi" runat="server" BorderColor="#A3B5C9" 
                                                        BorderStyle="Solid" BorderWidth="1px" Width="20px" Height="20px" onkeypress="return isNumberKey(event)">
                                                        </asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="2" style="border-bottom: 1px solid #bfbfbf; height: 30px">
                                            <span onmouseover="fadeBox.showTooltip(event,'BRÜT:<%#Convert.ToDecimal(Eval("BRUT")).ToString("C3")%> --- ISK1:<%#Eval("ISK1")%> --- ISK2:<%#Eval("ISK2")%> --- ISK3:<%#Eval("ISK3")%> --- ISK4:<%#Eval("ISK4")%> --- KDV:<%#Eval("KDV")%>')"><%# Eval("Ad") %></span>
                                            <span id="Span2" runat="server" style="color: #C00000"><%# Convert.ToDecimal(Eval("Fiyat")).ToString("N3") %></span> <span style="color: #C00000">TL</span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" style="width: 75px; border-right: 1px solid #bfbfbf; height: 30px">
                                            <input type="hidden" value='<%#Eval("TedarikciAdi") %>' id="TedarikciAdi" runat="server" />
                                            <input type="hidden" value='<%#Eval("TedarikciID") %>' id="TedarikciID" runat="server" />
                                            <asp:LinkButton ID="LinkButton4" runat="server" OnClick="TedarikciIsmindenSecim_Click" Enabled='<%#!rbBarkodaGore.Checked%>'><%# Eval("TedarikciAdi") %></asp:LinkButton>
                                        </td>
                                        <td align="center" style="width: 75px">
                                            <input type="hidden" value='<%#Eval("KategoriAdi") %>' id="KategoriAdi" runat="server" />
                                            <input type="hidden" value='<%#Eval("KategoriID") %>' id="KategoriID" runat="server" />
                                            <asp:LinkButton ID="LinkButton5" runat="server" OnClick="KategoriIsmindenSecim_Click" Enabled='<%#!rbBarkodaGore.Checked%>'><%# Eval("KategoriAdi") %></asp:LinkButton>
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:DataList>--%>



                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </ContentTemplate>
</asp:UpdatePanel>


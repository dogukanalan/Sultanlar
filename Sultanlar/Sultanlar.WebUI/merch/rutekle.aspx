<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="rutekle.aspx.cs" Inherits="Sultanlar.WebUI.merch.rutekle" %>

<%@ Register src="ucProgress.ascx" tagname="ucProgress" tagprefix="uc1" %>
<%@ Register src="ucUst.ascx" tagname="ucUst" tagprefix="uc2" %>
<%@ Register src="ucAlt.ascx" tagname="ucAlt" tagprefix="uc3" %>

<%@ Import Namespace="Sultanlar.DatabaseObject.Internet" %>

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
    <%--<script type="text/javascript" src="../musteri/js/jquery.tipTip.js"></script>
    <link rel="stylesheet" type="text/css" href="../musteri/js/tipTip.css" />--%>
    <style type="text/css">
.rbller input[type="radio"] {
  opacity: 0;
  -moz-opacity: 0;
  -webkit-opacity: 0;
  -o-opacity: 0;
}

.rbller input[type="radio"] + label {
  position: relative;
  padding: 0 0 0 25px;
  font-size: 12px;
  line-height: 15px;
  margin: 0 0 10px 0;
}

.rbller input[type="radio"] + label:before {
  content: "";
  display: block;
  position: absolute;
  top: 2px;
  height: 14px;
  width: 14px;
  background: white;
  border: 1px solid gray;
  box-shadow: inset 0px 0px 0px 2px white;
  -webkit-box-shadow: inset 0px 0px 0px 2px white;
  -moz-box-shadow: inset 0px 0px 0px 2px white;
  -o-box-shadow: inset 0px 0px 0px 2px white;
  -webkit-border-radius: 8px;
  -moz-border-radius: 8px;
  -o-border-radius: 8px;
}

.rbller input[type="radio"]:checked + label:before {
  background: #ef8700;
}
    </style>
    <script type="text/javascript">
        function MusteriSec(evt, mtip, slsref, gmref, smref, sube) {
            
            //slsref = document.getElementById('ddlTemsilciler').value;

            $('#mtip').val(mtip);
            $('#slsref').val(slsref);
            $('#gmref').val(gmref);
            $('#smref').val(smref);
            $('#tSecilen').val(sube);

            $("a").css("background", "#C0C0C0");
            $(evt).css("background", "#000000");

            $.ajax(
                    {
                        type: 'POST',
                        url: 'rutekle.aspx/RutGetir',
                        data: '{ slsref: "' + slsref + '", gmref: "' + gmref + '", smref: "' + smref + '", kacinci: "' + $('#rblKacinci input:checked').val() + '" }',
                        contentType: 'application/json; charset=utf-8',
                        dataType: 'json',
                        success: function (data) {
                            if (data.d.ID != "") {
                                $('#buttonRutEkle').val("Rutu Güncelle");
                                $("#rblPeriyodlar input").each(function () {
                                    if ($.trim($(this).val()) == $.trim(data.d.Rut)) {
                                        $(this).prop('checked', true);
                                    }
                                    else {
                                        $(this).prop('checked', false);
                                    }
                                });
                                $("#rblGunler input").each(function () {
                                    if ($.trim($(this).val()) == $.trim(data.d.Gun)) {
                                        $(this).prop('checked', true);
                                    }
                                    else {
                                        $(this).prop('checked', false);
                                    }
                                });
                                $('#dtBaslangic').val(data.d.BasTar);
                                $('#dtBitis').val(data.d.BitTar);
                                alert('Seçime ilişkin rut tanımı bulunmaktadır. "Rut Ayrıntısı" ekranından güncelleme yapabilirsiniz.');
                            }
                            else {
                                $('#buttonRutEkle').val("Rutu Ekle");
                                var i = 0;
                                $("#rblPeriyodlar input").each(function () {
                                    if (i == 0)
                                        $(this).prop('checked', true);
                                    else
                                        $(this).prop('checked', false);
                                    i++;
                                });
                                i = 0;
                                $("#rblGunler input").each(function () {
                                    if (i == 0)
                                        $(this).prop('checked', true);
                                    else
                                        $(this).prop('checked', false);
                                    i++;
                                });
                                $('#dtBaslangic').val("");
                                $('#dtBitis').val("");
                            }
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            alert(XMLHttpRequest.responseText);
                        }
                    });

            $("#RutAyrinti").show(1);
            //document.getElementById("rblKacinci").disabled = true;
            $( '#rblKacinci input[type="radio"]' ).attr( "disabled", true );
            $('#rblKacinci').css("visibility", "hidden");
            document.getElementById("spanRutSirasi").innerHTML = $('#rblKacinci input:checked').val();
        }

        function Temizle() {
            $("a").css("background", "#4E9CAF");
            //$("#RutAyrinti").css("display", "none");
            $("#RutAyrinti").hide(1);
            $( '#rblKacinci input[type="radio"]' ).attr( "disabled", false );
            $( '#rblKacinci' ).css( "visibility", "visible" );
            document.getElementById("spanRutSirasi").innerHTML = "";
            //$("#dtBitis").val("01.01.2023");
        }

        var bugun = new Date().setDate(new Date().getDate() - 1);
        //var bugun = new Date(bugun1.getUTCDate(), bugun1.getUTCMonth(), bugun1.getUTCFullYear());
        function Degisti(evt) {
            var from = evt.value.split("/");
            var event = new Date(from[2], from[1] - 1, from[0]);
            if (bugun > Date.parse(event)) {
                evt.value = '';
            }
        }

        function Gonder(button) {
            if ($(button).prop("id") == "buttonRutBaslat") {
                $('#dtBaslangic').val(GetDateNow());
                $('#dtBitis').val("01.01.2023");
            }
            else if ($(button).prop("id") == "buttonRutBitir") {
                $('#dtBitis').val(GetDateNow());
            }

            $.ajax(
                    {
                        type: 'POST',
                        url: 'rutekle.aspx/RutEkle',
                        data: '{ mtip: "' + $('#mtip').val() + '", slsref: "' + $('#slsref').val() + '", gmref: "' + $('#gmref').val() + '", smref: "' + $('#smref').val() + '", kacinci: "' + $('#rblKacinci input:checked').val() + '", periyod: "' + $('#rblPeriyodlar input:checked').val() + '", gun: "' + $('#rblGunler input:checked').val() + '", baslangic: "' + $('#dtBaslangic').val() + '", bitis: "' + $('#dtBitis').val() + '", islemyapan: "' + $('#islemci').val() + '" }',
                        contentType: 'application/json; charset=utf-8',
                        dataType: 'json',
                        success: function (data) {
                            if (data.d == "") {
                                alert('Rut başarıyla eklendi.');
                                Temizle();
                            }
                            else
                                alert(data.d);
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            alert(XMLHttpRequest.responseText);
                        }
                    });
        }

        $(function () {
            $('#rblKacinci input[type="radio"]').checkboxradio({
                icon: false
            });
            $('#rblRutlu input[type="radio"]').checkboxradio({
                icon: false
            });
            
            $('#rblRutlu input').attr('checked', false);
            if (getParameterByName("rutlu") == "1") {
                $('#rblRutlu').find('input[value="1"]').attr('checked', true);
            }
            else if (getParameterByName("rutlu") == "2") {
                $('#rblRutlu').find('input[value="2"]').attr('checked',true);
            }
            else if (getParameterByName("rutlu") == "3") {
                $('#rblRutlu').find('input[value="3"]').attr('checked',true);
            }
            else {
                $('#rblRutlu').find('input[value="1"]').attr('checked', true);
            }

            $("input:radio").next('label').removeClass("ui-checkboxradio-checked");
            $("input:radio").next('label').removeClass("ui-state-active");
            $("input:radio:checked").next('label').addClass("ui-checkboxradio-checked");
            $("input:radio:checked").next('label').addClass("ui-state-active");

            $('#rblRutlu input').change(function () {
                Ara();
            });

            //$('#rblGunler input[type="radio"]').checkboxradio({
            //    icon: false
            //});
            //$('#rblGunler').find('label').width(80);
            //$('#rblPeriyodlar input[type="radio"]').checkboxradio({
            //    icon: false
            //});
            //$('#rblPeriyodlar').find('label').width(100);
            //$('#rblPeriyodlar').find('label').height(30);
            //$("input:radio").checkboxradio();
            $("#RutAyrinti").hide(1);
            
            if (getParameterByName('slsref') == null) {
                document.getElementById('ddlTemsilciler').value = 0;
            }
            else {
                document.getElementById('ddlTemsilciler').value = getParameterByName('slsref');
            }
        });

        function Ara() {
            Goster();
            var val = $("#ddlTemsilciler option:selected").val();
            var val2 = $("#txtFarkliZiyaretSube").val();
            var val3 = $('#rblRutlu input:checked').val();
            window.location.href = 'rutekle.aspx?slsref=' + val + '&sube=' + val2 + '&rutlu=' + val3;
        }

        function Konus() {
            Konustur(window.location.href, 'rutlu=' + $('#rblRutlu input:checked').val() + '&sube');
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="login-page">
            <div class="form">
                <uc2:ucUst ID="ucUst" runat="server" />
                <%--<a class="button" href="menu.aspx" onclick="Goster()">Geri Dön</a>--%>
                    <div id="RutAyrinti" style="display: none; border: 1px solid #D1D1D1; border-radius: 5px; padding: 5px; margin-top: 10px">
                        <br /><span style="color: #D00000;">Rut Ayrıntı</span><br /><br />
                        <span runat="server" id="spanBugunRutPryd" style="font-style: italic; font-size: 12px"></span><br /><br />
                        <input type="text" runat="server" id="tSecilen" disabled />
                        <div style="width: 100%">
                        <div style="float: left; width: 50%">
                            <input type="text" runat="server" id="dtBaslangic" placeholder="Baş.(Bugünden büyük)" autocomplete="off" onchange="Degisti(this)" />
                        </div>
                        <div style="float: left; width: 50%">
                            <input type="text" runat="server" id="dtBitis" placeholder="Bit.(Boş bırakılabilir)" autocomplete="off" />
                        </div>
                        </div>
                        <div style="width: 100%;">
                        <div style="float: left; width: 60%; text-align: center">
                            <asp:RadioButtonList CssClass="rbller" ID="rblPeriyodlar" runat="server" style="font-size: 12px;"></asp:RadioButtonList>
                        </div>
                        <div style="float: left; width: 40%; text-align: center">
                            <asp:RadioButtonList CssClass="rbller" ID="rblGunler" runat="server" style="font-size: 12px;"></asp:RadioButtonList>
                        </div>
                        </div>
                        <input type="text" style="background-color: #ffffff; height: 15px" disabled />
                        <input type="button" id="buttonRutEkle" class="button" style="background: #4E9CAF; cursor: pointer" value="Rutu Ekle" onclick="Gonder(this)" />
                        <input type="button" id="buttonRutBaslat" class="button" style="background: #4E9CAF; cursor: pointer" value="Rutu Başlat" onclick="Gonder(this)" />
                        <input type="button" id="buttonRutBitir" class="button" style="background: #4E9CAF; cursor: pointer" value="Rutu Bitir" onclick="Gonder(this)" />
                        <input type="button" class="button" style="background: #4E9CAF; cursor: pointer" value="Seçimi Temizle" onclick="Temizle()" />
                    </div>
                    <br />
                    <div runat="server" id="divTemsilciler">
                    <asp:DropDownList runat="server" ID="ddlTemsilciler" Height="25px" ForeColor="#006699" 
                        Width="100%" style="padding: 3px 3px 3px 3px;border:1px solid #CCCCCC;background:#ededed;"></asp:DropDownList>
                    </div>
                <br /> 
                <asp:RadioButtonList ID="rblRutlu" runat="server" RepeatColumns="3" style="font-size: 11px; margin-left: 50px">
                        <asp:ListItem Text="Hepsi" Value="1" Selected="True"></asp:ListItem>
                        <asp:ListItem Text="Rutlu" Value="2"></asp:ListItem>
                        <asp:ListItem Text="Rutsuz" Value="3"></asp:ListItem>
                    </asp:RadioButtonList>
                <br />
                    <a class="button1" href="javascript:Konus()" style="float: left; padding: 9px"><img style="width: 28px" src="microphone.png" /></a>
                    <asp:TextBox runat="server" ID="txtFarkliZiyaretSube" Width="55%" placeholder="Buradan arayabilirsiniz..." autocomplete="off" onkeypress="return clickButton(event,'aAra')"></asp:TextBox>
                    <a class="button1" id="aAra" href="#" onclick="Ara()">&nbsp;&nbsp;&nbsp;Ara&nbsp;&nbsp;&nbsp;</a>
                <br /><br /> Rut Sırası: <span id="spanRutSirasi"></span>
                <asp:RadioButtonList ID="rblKacinci" runat="server" RepeatColumns="6" style="font-size: 12px; margin-left: 30px">
                        <asp:ListItem Text="1" Value="1" Selected="True"></asp:ListItem>
                        <asp:ListItem Text="2" Value="2"></asp:ListItem>
                        <asp:ListItem Text="3" Value="3"></asp:ListItem>
                        <asp:ListItem Text="4" Value="4"></asp:ListItem>
                        <asp:ListItem Text="5" Value="5"></asp:ListItem>
                        <asp:ListItem Text="6" Value="6"></asp:ListItem>
                    </asp:RadioButtonList>
                    <br />
                    <asp:Repeater runat="server" ID="rpZiyaretCariler">
                    <HeaderTemplate><table cellpadding="4" cellspacing="0">
                    <tr style="color: #D00000">
                        <td style="border-bottom: 1px solid #CCCCCC; height: 20px; width: 40%">Ana Cari</td>
                        <td style="border-bottom: 1px solid #CCCCCC; height: 20px; width: 40%">Şube</td>
                        <td style="border-bottom: 1px solid #CCCCCC; height: 20px; width: 20%">Seçim</td>
                    </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr class='<%#"rutVar" + (Convert.ToInt32(Eval("[RUTVAR]")) > 0).ToString()%>'>
                            <td style="width: 40%; font-size: 10px; border-bottom: solid 1px #ffffff">
                            
                            <span class="kucukbilgiGoster">
                            <%#Eval("MUSTERI")%>
                            </span>
                            
                            </td>
                            
                            <td style="width: 40%; font-size: 10px; border-bottom: solid 1px #ffffff">
                            
                            <span class="kucukbilgiGoster" onclick="AndroidToast($(this).prop(\'title\'))" title='<%#Eval("ADRES").ToString()%> <%#Eval("SEHIR")%>/<%#Eval("SEMT")%>'>
                            <%#Eval("SUBE")%>
                            </span>

                            </td>

                            <td style="width: 20%; border-bottom: solid 1px #ffffff"><a class="button" href="#" onclick='javascript:MusteriSec(this,<%#Eval("MTIP") %>,<%#((Musteriler)Session["Musteri"]).tintUyeTipiID != 2 ? ((Musteriler)Session["Musteri"]).intSLSREF : Convert.ToInt32(Request.QueryString["slsref"]) %>,<%#CariHesaplar.GetGMREFBySMREF(Convert.ToInt32(Eval("SMREF")),Convert.ToInt32(Eval("MTIP"))) %>,<%#Eval("SMREF") %>,"<%#Eval("SUBE") %>")'>Seç<a></td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate></table></FooterTemplate>
                    </asp:Repeater>
                    
                    <input type="hidden" runat="server" id="mtip" />
                    <input type="hidden" runat="server" id="slsref" />
                    <input type="hidden" runat="server" id="gmref" />
                    <input type="hidden" runat="server" id="smref" />
                    <input type="hidden" runat="server" id="islemci" />
                <uc3:ucAlt ID="ucAlt1" runat="server" />
            </div>
        </div>
        
        <script type="text/javascript">
            $("#dtBaslangic").datepicker({ changeMonth: true, changeYear: true, dateFormat: 'dd/mm/yy' });
            $("#dtBitis").datepicker({ changeMonth: true, changeYear: true, dateFormat: 'dd/mm/yy' });
            $(".ui-datepicker").css('font-size', 12);
        </script>
        <script type="text/javascript">
            $('#ddlTemsilciler').change(function () {
                Ara();
            });
        </script>
        <uc1:ucProgress ID="ucProgress1" runat="server" />
    </form>
</body>
</html>

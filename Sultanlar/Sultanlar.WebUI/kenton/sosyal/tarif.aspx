<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="tarif.aspx.cs" Inherits="Sultanlar.WebUI.kenton.sosyal.tarif" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Kenton - Pratik Çözümler</title>
    <link href="../../../kenton/sosyal/main.css" rel="stylesheet" type="text/css" />
</head>
<body>
	    <div class="limiter">
		    <div class="container-login100">
			    <div class="wrap-login100">
    <form id="form1" runat="server">
<span runat="server" id="spanBaslik" class="login100-form-title">Başlık</span>
<br />
<div style="width: 100%;">
<img style="padding: 15px 0px 15px 0px; margin-left: auto; margin-right: auto; display: block; max-width: 800px; width: 100%" src='' runat="server" id="imgResim" alt="Tarif" />
</div>
<br />
<span class="login100-form-title" style="font-size: 16px">Malzemeler</span><br />
<span runat="server" id="spanMalzemeler" style="font-size: 14px">(MalzemelerBurada)</span>
<br /><br />
<span class="login100-form-title" style="font-size: 16px">Hazırlanış</span><br />
<span runat="server" id="spanHazirlanis" style="font-size: 14px">(HazırlanışBurada)</span>
<div runat="server" id="divSatinAl">
<br /><br />
<span class="login100-form-title" style="font-size: 16px">Ürünleri Satın Alın</span>
<a runat="server" id="aUrunler" target="_blank"><img style="padding: 15px 0px 15px 0px; margin-left: auto; margin-right: auto; display: block; max-width: 800px; width: 100%" src='' runat="server" id="imgUrunler" /></a>
</div>
<div id="divPaylas" style="vertical-align: middle; width: 100%; text-align: center">
<br />
<span class="login100-form-title" style="font-size: 16px">Paylaşın</span>
<br />
<div style="margin-left: auto; margin-right: auto; display: block;">
<a target="_blank" href='https://www.facebook.com/sharer/sharer.php?u=https%3A%2F%2Fwww.sultanlar.com.tr/pratikcozumler/tarif/<%= Request.QueryString["id"] %>'><img src="../../../kenton/images/sm/fb.png" runat="server" id="img1" style="width: 32px; margin-left: auto; margin-right: auto; padding-right: 5px; padding-bottom: 5px" /></a>
<a target="_blank" href='http://twitter.com/share?text=Kenton Tarif&url=https://www.sultanlar.com.tr/pratikcozumler/tarif/<%= Request.QueryString["id"] %>&hashtags=kenton,tarif,pratikcozumler'><img src="../../../kenton/images/sm/tw.png" runat="server" id="img2" style="width: 32px; margin-left: auto; margin-right: auto; padding-right: 5px; padding-bottom: 5px" /></a>
<a target="_blank" href='https://www.linkedin.com/shareArticle?mini=true&url=https%3A%2F%2Fwww.sultanlar.com.tr/pratikcozumler/tarif/<%= Request.QueryString["id"] %>&source=Kenton'><img src="../../../kenton/images/sm/li.png" runat="server" id="img3" style="width: 32px; margin-left: auto; margin-right: auto; padding-right: 5px; padding-bottom: 5px" /></a>
<a target="_blank" href='https://plus.google.com/share?url=https://www.sultanlar.com.tr/pratikcozumler/tarif/<%= Request.QueryString["id"] %>'><img src="../../../kenton/images/sm/gp.png" runat="server" id="img4" style="width: 32px; margin-left: auto; margin-right: auto; padding-right: 5px; padding-bottom: 5px" /></a>
<a target="_blank" href='http://pinterest.com/pin/create/button/?url=https%3A%2F%2Fwww.sultanlar.com.tr/pratikcozumler/tarif/<%= Request.QueryString["id"] %>&media=https%3A%2F%2Fwww.sultanlar.com.tr/kenton/resim.aspx?tarif=<%= Request.QueryString["id"] %>&description=Kenton'><img src="../../../kenton/images/sm/pi.png" runat="server" id="img5" style="width: 32px; margin-left: auto; margin-right: auto; padding-right: 5px; padding-bottom: 5px" /></a>
<%--<a target="_blank" href="#"><img src="../../../kenton/images/sm/wa.png" runat="server" id="img6" style="width: 32px; float: left; padding-right: 5px; padding-bottom: 5px" /></a>--%>
<%--<a target="_blank" href="#"><img src="../../../kenton/images/sm/em.png" runat="server" id="img7" style="width: 32px; float: left; padding-right: 5px; padding-bottom: 5px" /></a>--%>
</div>
</div>
<input type="hidden" runat="server" id="tarifid" clientidmode="Static" />
    </form>
    </div></div></div>
</body>
</html>

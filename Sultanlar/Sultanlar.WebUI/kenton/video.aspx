<%@ Page Title="" Language="C#" MasterPageFile="~/kenton/Site1.Master" AutoEventWireup="true" CodeBehind="video.aspx.cs" Inherits="Sultanlar.WebUI.kenton.video" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        
        $(document).ready(function () {
        var key = '';
            if (getParameterByName("id")) {
                key = getParameterByName("id");
            }
        document.getElementById('iframeVideo').src = "https://www.youtube.com/embed/" + key + "?rel=0&amp;modestbranding=1&;controls=1&autohide=1&showinfo=0";
        });

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <iframe id="iframeVideo" width="100%" height="201" src="" frameborder="0" allow="autoplay; encrypted-media" allowfullscreen></iframe>
    <div class="main-content" runat="server" id="divContent" visible="false">
        <h3 class="ribbon paddingyok">Malzemeler</h3><br />
        <p runat="server" id="spanMalzemeler" style="font-size: 0.8em; text-align: justify">(MalzemelerBurada)</p>
        <br />
        <br />
        <h3 class="ribbon paddingyok">Hazırlanış</h3><br />
        <div runat="server" id="spanHazirlanis" style="text-align: justify">(HazırlanışBurada)</div>
    </div>
</asp:Content>

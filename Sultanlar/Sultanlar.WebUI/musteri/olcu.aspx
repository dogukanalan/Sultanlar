<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="olcu.aspx.cs" Inherits="Sultanlar.WebUI.musteri.olcu" %>

<div style="font-family: Verdana">
    <%--<img src='resim.aspx?uidK=<%=Request.QueryString["id"]%>' alt="" />--%>
    <div>
        <h1>Ölçü Birimleri (<%=Request.QueryString["id"]%>)</h1>
        <p>
            <iframe src='olculer.aspx?id=<%=Request.QueryString["id"]%>' height="100" width="500" frameborder="0" scrolling="no"></iframe>
        </p>
    </div>
</div>
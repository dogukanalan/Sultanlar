<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="iadegecmis.aspx.cs" Inherits="Sultanlar.WebUI.musteri.iadegecmis" %>

<div style="font-family: Verdana; height: 200px; width: 600px">
    <%--<img src='resim.aspx?uidK=<%=Request.QueryString["id"]%>' alt="" />--%>
    <div>
        <h1><%=Request.QueryString["id"]%> No'lu İade Geçmişi:</h1>
        <p>
            <iframe src='iadegecmis2.aspx?id=<%=Request.QueryString["id"]%>' height="300" width="500" frameborder="0" scrolling="no"></iframe>
        </p>
    </div>
</div>

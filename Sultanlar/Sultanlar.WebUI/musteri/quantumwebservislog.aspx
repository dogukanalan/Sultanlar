<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="quantumwebservislog.aspx.cs" Inherits="Sultanlar.WebUI.musteri.quantumwebservislog" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server" action="quantumwebservislog.html">
    <div align="center">
    
        <asp:GridView ID="GridView1" runat="server" CellPadding="5" 
            DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" 
            AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" 
            DataKeyNames="pkID" BackImageUrl="~/musteri/img/bg-logo.jpg" 
            PageSize="50" Width="700px" Font-Size="12px">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="pkID" HeaderText="ID" ReadOnly="True" 
                    InsertVisible="False" SortExpression="pkID" >
                <HeaderStyle Wrap="True" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="50px" />
                </asp:BoundField>
                <asp:BoundField DataField="blYazildi" HeaderText="Q.Yazıldı" 
                    SortExpression="blYazildi">
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="50px" />
                </asp:BoundField>
                <asp:BoundField DataField="intSiparisID" HeaderText="Sipariş No" 
                    SortExpression="intSiparisID" >
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="75px" />
                </asp:BoundField>
                <asp:BoundField DataField="strQuantumNo" HeaderText="Quantum No" 
                    SortExpression="strQuantumNo" >
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                </asp:BoundField>
                <asp:BoundField DataField="dtTarih" HeaderText="Tarih" 
                    SortExpression="dtTarih" DataFormatString="{0:dd/MM/yyyy HH:mm:ss}" >
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="75px" />
                </asp:BoundField>
                <asp:BoundField DataField="strAdSoyad" HeaderText="Web Üye" 
                    SortExpression="strAdSoyad" >
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="150px" />
                </asp:BoundField>
                <asp:BoundField DataField="strTerminal" HeaderText="Act.Dir.Name" 
                    SortExpression="strTerminal">
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                </asp:BoundField>
                <asp:BoundField DataField="strSiparisTip" HeaderText="Sipariş Tip" 
                    SortExpression="strSiparisTip">
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                </asp:BoundField>
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="Data Source=serverdb01;Initial Catalog=KurumsalWebSAP;User ID=sultanlar; Password=pazarlama" 
            ProviderName="System.Data.SqlClient" 
            SelectCommand="SELECT [pkID],[blYazildi],[intSiparisID],[strQuantumNo],[dtTarih],[intMusteriID],
(SELECT [strAd] + ' ' + [strSoyad] FROM tblINTERNET_Musteriler WHERE pkMusteriID = [intMusteriID]) AS strAdSoyad,
[strTerminal],[strSiparisTip] FROM [tblQuantumWebServisLog] ORDER BY [pkID] DESC" 
            DeleteCommand="DELETE FROM [tblQuantumWebServisLog] WHERE [pkID] = @pkID" 
            
            UpdateCommand="UPDATE [tblQuantumWebServisLog] SET [blYazildi] = @blYazildi,[intSiparisID] = @intSiparisID,[strQuantumNo] = @strQuantumNo,[dtTarih] = @dtTarih,[intMusteriID] = @intMusteriID,[strTerminal] = @strTerminal,[strSiparisTip] = @strSiparisTip WHERE [pkID] = @pkID" 
            
            
            
            InsertCommand="INSERT INTO [tblQuantumWebServisLog] ([blYazildi],[intSiparisID],[strQuantumNo],[dtTarih],[intMusteriID],[strTerminal],[strSiparisTip]) VALUES (@blYazildi,@intSiparisID,@strQuantumNo,@dtTarih,@intMusteriID,@strTerminal,@strSiparisTip)">
            <DeleteParameters>
                <asp:Parameter Name="pkID" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="blYazildi" Type="Boolean" />
                <asp:Parameter Name="intSiparisID" Type="Int32" />
                <asp:Parameter Name="strQuantumNo" Type="String" />
                <asp:Parameter Name="dtTarih" Type="DateTime" />
                <asp:Parameter Name="intMusteriID" Type="Int32" />
                <asp:Parameter Name="strTerminal" Type="String" />
                <asp:Parameter Name="strSiparisTip" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="blYazildi" Type="Boolean" />
                <asp:Parameter Name="intSiparisID" Type="Int32" />
                <asp:Parameter Name="strQuantumNo" Type="String" />
                <asp:Parameter Name="dtTarih" Type="DateTime" />
                <asp:Parameter Name="intMusteriID" Type="Int32" />
                <asp:Parameter Name="strTerminal" Type="String" />
                <asp:Parameter Name="strSiparisTip" Type="String" />
                <asp:Parameter Name="pkID" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
    
        <br />
        <table>
        <tr>
        <td>Quantum'a Yazılan Sayısı:</td>
        <td align="right"><asp:Label runat="server" ID="lblYazilan" ForeColor="Red"></asp:Label></td>
        </tr>
        <tr>
        <td>Quantum'a Yazılamayan Sayısı:</td>
        <td align="right"><asp:Label runat="server" ID="lblYazilmayan" ForeColor="Red"></asp:Label></td></tr></table>
        </div>
    </form>
</body>
</html>

<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="consulta.aspx.cs" Inherits="wed.consulta" %>
<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
    <br />
        <table class="auto-style2">
            <tr>
                <td>
    <p class="auto-style3">
        <strong>Consultar usuario por ID</strong></p>
                </td>
            </tr>
        </table>
</p>
    <p>
        &nbsp;</p>
<table class="auto-style2">
    <tr>
        <td>
<p class="auto-style4">
        Buscar por id.</p>
    <style>
        body{
            background-color:#BADCFF
        }
    .auto-style2 {
        width: 100%;
        background-color: #FCF8E3;
    }
    .auto-style3 {
        font-size: x-large;
    }
    .auto-style4 {
        font-size: x-large;
    }
</style>
<p>
    <asp:SqlDataSource ID="SqlDataSource1_consulta" runat="server" ConnectionString="<%$ ConnectionStrings:BibliotecaConnectionString %>" SelectCommand="SELECT [idusuario], [nombre], [nivel] FROM [Tabla de datos]"></asp:SqlDataSource>
    <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1_consulta" DataTextField="idusuario" DataValueField="idusuario" AutoPostBack="True" style="margin-left: 0">
    </asp:DropDownList>
</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <center>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource_consul" Height="160px" Width="477px" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" GridLines="Horizontal">
            <Columns>
                <asp:BoundField DataField="idusuario" HeaderText="idusuario" SortExpression="idusuario" />
                <asp:BoundField DataField="nombre" HeaderText="nombre" SortExpression="nombre" />
                <asp:BoundField DataField="clave" HeaderText="clave" SortExpression="clave" />
                <asp:BoundField DataField="nivel" HeaderText="nivel" SortExpression="nivel" />
            </Columns>
            <FooterStyle BackColor="White" ForeColor="#333333" />
            <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="White" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F7F7F7" />
            <SortedAscendingHeaderStyle BackColor="#487575" />
            <SortedDescendingCellStyle BackColor="#E5E5E5" />
            <SortedDescendingHeaderStyle BackColor="#275353" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource_consul" runat="server" ConnectionString="<%$ ConnectionStrings:BibliotecaConnectionString %>" SelectCommand="SELECT [idusuario], [nombre], [clave], [nivel] FROM [Tabla de datos] WHERE ([idusuario] = @idusuario)">
            <SelectParameters>
                <asp:ControlParameter ControlID="DropDownList1" Name="idusuario" PropertyName="SelectedValue" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" BackColor="#339933" Font-Size="Large" ForeColor="White" Text="Inicio" />
        <br />
</center>
        </td>
    </tr>
</table>
     <a href="Default.aspx"><input type="button" value="volver"style="background-color:aquamarine;height: 37px; width: 175px;">
</asp:Content>

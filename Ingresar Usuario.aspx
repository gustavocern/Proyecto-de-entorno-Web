<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Ingresar Usuario.aspx.cs" Inherits="wed.Ingresar_Usuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <br />
        </p>
    <p>
        &nbsp;</p>
     <style>
        body{
            background-color:#BADCFF
        }
         .auto-style1 {
        width: 100%;
        background-color: #FCF8E3;
    }
    .auto-style2 {
        color: #000000;
        font-size: xx-large;
    }
    .auto-style3 {
        font-size: x-large;
    }
        </style>
    <table class="auto-style1">
        <tr>
            <td>
    <p class="text-center">
        <strong><span class="auto-style2">Agregar Usuarios</span></strong></p>
                <p class="text-center">
                    &nbsp;</p>
                <p class="text-center">
                    <span class="auto-style3">Nombre:&nbsp;
        </span>
        <asp:TextBox ID="TextBox1" runat="server" CssClass="auto-style3"></asp:TextBox>
    </p>
    <p class="text-center">
        <span class="auto-style3">Clave:&nbsp;&nbsp; </span> <asp:TextBox ID="TextBox2" runat="server" Width="202px" CssClass="auto-style3"></asp:TextBox>
    </p>
    <p class="text-center">
        <span class="auto-style3">Contactos:&nbsp;&nbsp; </span> <asp:TextBox ID="TextBox3" runat="server" Width="248px" CssClass="auto-style3"></asp:TextBox>
    </p>
    <p class="text-center">
        <span class="auto-style3">Direccion :</span><asp:TextBox ID="TextBox4" runat="server" CssClass="auto-style3" Width="272px"></asp:TextBox>
    </p>
    <p class="text-center">
        <span class="auto-style3">Identificador :</span><asp:TextBox ID="TextBox5" runat="server" CssClass="auto-style3" Width="242px"></asp:TextBox>
    </p>
                <p class="text-center">
                    &nbsp;</p>
                <p class="text-center">
                    &nbsp;</p>
                <p class="text-center">
                    &nbsp;</p>
            </td>
        </tr>
</table>
    <p>
        &nbsp;</p>
<p>
        &nbsp;</p>
<table class="auto-style1">
    <tr>
        <td class="text-center">
            <br />
            <br />
        <asp:Button ID="Button1" runat="server" BackColor="#339933" BorderStyle="Inset" Text="Nuevo " Font-Size="Large" ForeColor="White" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button2" runat="server" BackColor="#339933" BorderStyle="Inset" Text="Eliminar " Font-Size="Large" ForeColor="White" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button3" runat="server" BackColor="#339933" BorderStyle="Inset" Text="Modificar " Font-Size="Large" ForeColor="White" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button4" runat="server" BackColor="#339933" BorderStyle="Inset" Text="Inicio" OnClick="Button4_Click" Font-Size="Large" ForeColor="White" Width="65px" />
            <br />
            <br />
        </td>
    </tr>
</table>
     <a href="Default.aspx"><input type="button" value="volver"style="background-color:aquamarine;height: 37px; width: 175px;">
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="wed.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <style>
        body{
            background-color:#BADCFF
        }
    </style>
    <p>
        &nbsp;</p>
    <p>
        INGRESO DE USUARIO</p>
    <p>
        &nbsp;</p>
    <table style="width: 100%; border: 1px solid #000000; background-color: #FCF8E3">
        <tr>
            <td class="text-right" style="width: 136px">Usuario</td>
            <td>
                <asp:TextBox ID="txtusuario" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="text-right" style="width: 136px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="text-right" style="width: 136px">Clave</td>
            <td>
                <asp:TextBox ID="txtclave" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="text-right" style="width: 136px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="text-right" style="width: 136px">Nivel</td>
            <td>
                <asp:DropDownList ID="lstnivel" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource_nivel" DataTextField="nivel" DataValueField="nivel">
                    <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                    <asp:ListItem>4</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="text-right" style="width: 136px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="text-right" style="width: 136px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="text-right" style="width: 136px">&nbsp;</td>
            <td>
                <asp:Button ID="bnuevo" runat="server" Text="Nuevo" OnClick="bnuevo_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="bmodificar" runat="server" Text="Modificar" OnClick="bmodificar_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="beliminar" runat="server" Text="Eliminar" OnClick="beliminar_Click" />
                <br />
            </td>
        </tr>
        <tr>
            <td class="text-right" style="width: 136px; height: 20px"></td>
            <td style="height: 20px">
                <asp:Button ID="bguardar" runat="server" Text="Guardar" OnClick="bguardar_Click" />
&nbsp;&nbsp;&nbsp;
                <asp:Button ID="bactualizar" runat="server" Text="Actualizar" OnClick="bactualizar_Click" />
                <br />
            </td>
        </tr>
        <tr>
            <td class="text-right" style="width: 136px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="text-right" style="width: 136px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="text-right" style="width: 136px">&nbsp;</td>
            <td>
                <asp:TextBox ID="txtbuscar" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="text-right" style="width: 136px; height: 20px"></td>
            <td style="height: 20px">
                <asp:Button ID="Button6" runat="server" Text="Buscar por codigo" OnClick="Button6_Click" />
            </td>
        </tr>
        <tr>
            <td class="text-right" style="width: 136px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="text-right" style="width: 136px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
    <br />
    <asp:GridView ID="GridView1" runat="server">
    </asp:GridView>
    <br />
</asp:Content>

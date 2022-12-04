<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Acerca de.aspx.cs" Inherits="wed.Acerca_de" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p class="auto-style1">
        <br />
    </p>
<br />
<br />
<table class="auto-style3">
    <tr>
        <td>
    <p class="auto-style1">
        &nbsp;</p>
            <p class="auto-style4">
                Acerca de</p>
            <p class="auto-style1">
                &nbsp;</p>
            <p class="auto-style1">
                &nbsp;</p>
    <style>
        body{
            background-color:#BADCFF
        }
        .auto-style1 {
            font-size: x-large;
            color: #0000FF;
        }
        .auto-style3 {
        width: 100%;
        background-color: #FCF8E3;
    }
        .auto-style4 {
            font-size: x-large;
            color: #000000;
        }
    </style>
    <p>
        SIatema Bibliotecario Lectores Sin Rumbo.</p>
    <p>
         <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagenes/VC_lbro.jpeg" />
</p>

    <p>
        Version 1.0.0.0</p>
    <p>
        &nbsp;</p>
    <p>
        Grupo 4. </p>
    <p>
        &nbsp;</p>
    <p>
        El siguiente proyecto es basado en formularios web, tambien contiene un Menu de opciones dando cada opcion </p>
    <p>
        permite dirigirse a un nuevo Formulario o clase.</p>
    <p>
        Algunos de los cambios realizados son de diseño en los formulario web.</p>
        </td>
    </tr>
</table>
     <a href="Default.aspx"><input type="button" value="volver"style="background-color:aquamarine;height: 37px; width: 175px;">
    </asp:Content>

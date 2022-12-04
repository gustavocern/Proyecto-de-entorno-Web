<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="wed._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <style>
        body{
            background-color:#BADCFF
        }
        .auto-style1 {
            color: inherit;
            text-align: center;
            margin-top: 20px;
            margin-bottom: 30px;
            padding-top: 48px;
            padding-bottom: 48px;
            background-color: #eeeeee;
        }
    </style>

    <div class="auto-style1">
        <h1>Lectores Sin Rumbo</h1>
        <p>&nbsp;</p>

        <p class="lead">Este es un sitio web donde podras reservar y prestar tu libro favorito para que puedas </p>
        
            <img alt="" src="Imagenes/VC_lbro.jpeg" style="width: 369px; height: 340px" /></p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>UGB Verde</h2>
            <p>
                Cuidemos el medio ambiente ya que es donde habitamos es por ello que debemos plantar muchos 
                arboles y no talarlos.
            </p>
            <p>
                <a class="btn btn-default" href="https://www.gob.mx/aprendemx/articulos/7-formas-sencillas-para-proteger-el-medio-ambiente?idiom=es">Cuidar el medio ambiente. &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Get more libraries</h2>
            <p>
                NuGet is a free Visual Studio extension that makes it easy to add, remove, and update libraries and tools in Visual Studio projects.
            </p>
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301949">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Web Hosting</h2>
            <p>
                You can easily find a web hosting company that offers the right mix of features and price for your applications.
            </p>
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301950"> Cuidar el medio ambiente. &raquo;</a>
            </p>
        </div>
    </div>
     

</a></asp:Content>

<%@ Page Title="Login Administrador Agility KB" Language="C#" AutoEventWireup="true"
    MasterPageFile="~/BackOffice/BackOffice.Master" CodeBehind="Login.aspx.cs" Inherits="AgilityKB.BackOffice.Login" %>

<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeaderContent" runat="server">
    <link href="Css/Login.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div id="ConteudoForm" class="conteudoForm">
        <div id="ConteudoLogin" class="conteudoLogin">
            <asp:Label ID="LblLogin" runat="server" CssClass="lblLogin" Text="Login:" />
            <asp:TextBox ID="TxtLogin" runat="server" CssClass="txtLogin" />
        </div>
        <div id="ConteudoSenha" class="conteudoLogin">
            <asp:Label ID="LblSenha" runat="server" CssClass="lblLogin" Text="Senha:" />
            <asp:TextBox ID="TxtSenha" runat="server" TextMode="Password" CssClass="txtLogin" />
        </div>
        <div id="ConteudoBtns" class="conteudoLogin">
            <asp:Button ID="BtnEnviar" runat="server" CssClass="btnEnviar" Text="Enviar" OnClick="BtnEnviar_Click" />
        </div>
        <div id="ConteudoErros" class="conteudoErros">
            <asp:Label ID="LblErros" CssClass="lblErros" runat="server" />
        </div>
    </div>
</asp:Content>

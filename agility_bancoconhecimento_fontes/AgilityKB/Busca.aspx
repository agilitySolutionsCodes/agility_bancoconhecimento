<%@ Page Title="Busca de Conteudo Base de Conhecimento Agility Solutions" Language="C#" MasterPageFile="~/AgilityKB.Master" AutoEventWireup="true"
    CodeBehind="Busca.aspx.cs" Inherits="AgilityKB.Busca" %>

<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="Styles/Css/Busca.css" rel="stylesheet" type="text/css" />
    <title>Resultado de Busca Agility KB</title>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div id="DvBodySearch" runat="server" class="dvBodySearch">
        <asp:Label runat="server" ID="LblTitulo" CssClass="lblTitulo" Text="Resultados da Busca"></asp:Label>
        <div id="ContentSearch" class="contentSearch" runat="server">
        </div>
    </div>
</asp:Content>

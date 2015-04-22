<%@ Page Title="" Language="C#" MasterPageFile="~/AgilityKB.Master" AutoEventWireup="true"
    CodeBehind="Contatos.aspx.cs" Inherits="AgilityKB.Contatos" %>

<%@ Register TagPrefix="Uc" TagName="MenuLateral" Src="~/Controles/MenuLateral.ascx" %>
<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="Styles/Css/MenuLateral.css" rel="stylesheet" type="text/css" />
    <link href="Styles/Css/Contatos.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="http://download.skype.com/share/skypebuttons/js/skypeCheck.js"></script>
    <title>Contatos</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="ContentRight" class="menuRight">
        <div id="ContatosList" class="contatosList" runat="server">
            <asp:Literal ID="LtlConteudo" runat="server" />
        </div>
    </div>
</asp:Content>

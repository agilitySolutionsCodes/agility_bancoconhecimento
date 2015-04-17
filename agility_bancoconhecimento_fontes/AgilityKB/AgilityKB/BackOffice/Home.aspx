<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="AgilityKB.BackOffice.Home"
    MasterPageFile="~/BackOffice/BackOffice.Master" %>

<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeaderContent" runat="server">
    <link href="Css/Home.css" rel="stylesheet" type="text/css" />
    <title>Back Office Base de Conhecimento Agility Solutions</title>
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div id="Conteudo" class="conteudo">
        <div id="Opcoes" class="opcoes">
            <a href="~/BackOffice/CadastroUsuarios.aspx" id="LnkBtnOpcaoA" runat="server" class="linkOpcao">
                <div id="OpcaoA" class="opcaoCadastroA">
                    Cadastro Usuários
                </div>
            </a>
            <%--<a href="~/Home.aspx" id="LnkBtnOpcaoB" runat="server" class="linkOpcao">
                <div id="OpcaoB" class="opcaoCadastroB">
                    Relatórios
                </div>
            </a><a href="~/Home.aspx" id="LnkBtnOpcaoC" runat="server" class="linkOpcao">
                <div id="OpcaoC" class="opcaoCadastroA">
                    Home Page
                </div>
            </a><a href="~/BackOffice/Login.aspx" id="LnkBtnOpcaoD" runat="server" class="linkOpcao">
                <div id="OpcaoD" class="opcaoCadastroB">
                    Permissões de Usuários
                </div>
            </a>--%>
        </div>
    </div>
</asp:Content>

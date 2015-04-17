<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="AgilityKB.BackOffice.Home"
    MasterPageFile="~/BackOffice/BackOffice.Master" %>

<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeaderContent" runat="server">
    <link href="Css/Home.css" rel="stylesheet" type="text/css" />
    <title>Back Office Base de Conhecimento Agility Solutions</title>
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div id="Conteudo" class="conteudo">
        <div id="Opcoes" class="opcoes">
            <a href="~/BackOffice/CadastroUsuarios.aspx" id="LnkBtnOpcaoA" runat="server">
                <div id="OpcaoA" class="opcaoCadastroA">
                    <h3 class="menuHome">Cadastro de Usuários</h3>
                </div>
            </a>
            <a href="~/Home.aspx" id="LnkBtnOpcaoB" runat="server">
                <div id="OpcaoB" class="opcaoCadastroB">
                    <h3 class="menuHome">Voltar a Base</h3>
                </div>
            </a>
            <a href="~/BackOffice/CadastroCategorias.aspx" id="LnkBtnOpcaoC" runat="server">
                <div id="OpcaoC" class="opcaoCadastroA">
                    <h3 class="menuHome">Cadastro de Categorias</h3>
                </div>
            </a>
            <%--<a href="~/BackOffice/Login.aspx" id="LnkBtnOpcaoD" runat="server" class="linkOpcao">
                <div id="OpcaoD" class="opcaoCadastroB">
                    <h3 class="menuHome">Permissões de Usuários</h3>
                </div>
            </a>--%>
        </div>
    </div>
</asp:Content>

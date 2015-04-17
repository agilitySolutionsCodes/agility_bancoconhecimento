<%@ Page Title="" Language="C#" MasterPageFile="~/BackOffice/BackOffice.Master" AutoEventWireup="true" CodeBehind="CadastroCategorias.aspx.cs" Inherits="AgilityKB.BackOffice.CategoriasCadastro" %>

<%@ Register TagPrefix="Uc" TagName="PostArvore" Src="~/Controles/ControleArvore.ascx" %>
<%@ Register TagPrefix="ControleAjax" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<asp:Content ID="HeadContent" ContentPlaceHolderID="HeaderContent" runat="server">
    <title>Cadastro de Categorias Base de Conheciment</title>
    <link href="Css/CadastroCategorias.css" rel="stylesheet" />
    <link href="../Styles/Css/MenuLateral.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
    </script>
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div id="Conteudo" class="conteudo" runat="server">
        <div class="dvCadastro">
            <div id="DvTituloPost" class="dvTituloPost" runat="server">
                <label id="lblTitulo" class="lblTitulo">
                    Nome da Categoria:</label>
                <asp:TextBox ID="TxtTitulo" CssClass="txtTitulo" runat="server" />
            </div>
            <div id="ControleArvore" class="controleArvore" runat="server">
                <label id="lblContexto" class="lblContexto">
                    Contexto:</label><br />
                <Uc:PostArvore ID="arvoreControl" runat="server" />
            </div>
            <div id="DvBtns" class="dvBtns" runat="server">
                <asp:Button ID="BtnEnviar" CssClass="btnEnviar" runat="server" Text="Enviar" OnClick="BtnEnviar_Click" />
            </div>
            <div id="DvErros" runat="server" class="dvErros">
                <asp:Label ID="LblErros" CssClass="lblErros" runat="server" />
            </div>
        </div>
    </div>
</asp:Content>


<%@ Page Title="Criação de Post Base de Conhecimento Agility Solutions" Language="C#"
    MasterPageFile="~/AgilityKB.Master" AutoEventWireup="true" CodeBehind="CriacaoPosts.aspx.cs"
    Inherits="AgilityKB.CriacaoPosts" %>

<%@ Register TagPrefix="Uc" TagName="PostArvore" Src="~/Controles/ControleArvore.ascx" %>
<%@ Register TagPrefix="ControleAjax" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="Scripts/Customizado/AgilityKB.js" type="text/javascript"></script>
    <link href="Styles/Css/MenuLateral.css" rel="stylesheet" type="text/css" />
    <link href="Styles/Css/Posts.css" rel="stylesheet" type="text/css" />
    <title>Crie Seu Post e contribua com a Base de Conhecimento</title>
    <script type="text/javascript">
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="Conteudo" class="conteudoPage">
        <div id="ContentRight" class="menuRight">
            <div id="ConteudoPosts" class="conteudoPosts">
                <div id="DvErros" runat="server" class="dvErros">
                    <asp:Label ID="LblErros" CssClass="lblErros" runat="server" />
                </div>
                <div id="DvTituloPost" class="dvTituloPost" runat="server">
                    <label id="lblTitulo" class="lblTitulo">
                        Título do Post:</label>
                    <asp:TextBox ID="TxtTitulo" CssClass="txtTitulo" runat="server" />
                </div>
                <div id="DvConteudoPost" class="dvConteudoPost" runat="server" title="Conteúdo deste Post">
                    <div id="ControleAjax" class="controleAjax" runat="server">
                        <ControleAjax:ToolkitScriptManager ID="ToolkitScriptManager" runat="server" />
                        <asp:TextBox ID="TxtConteudo" TextMode="MultiLine" CssClass="txtConteudo" runat="server" />
                        <ControleAjax:HtmlEditorExtender ID="HtmlEditorExtender1" TargetControlID="TxtConteudo"
                            runat="server" EnableSanitization="false" />
                    </div>
                </div>
                <div id="DvUploadPost" class="dvTituloPost" runat="server" title="Upload de Arquivo">
                    <asp:Label ID="LblUploadArquivo" runat="server" CssClass="lblUpload">
                    Upload de Arquivo:</asp:Label>
                    <asp:FileUpload ID="PostUpload" CssClass="postUpload" runat="server" />
                </div>
                <div id="DvContextoPost" class="dvTituloPost" runat="server" title="Contexto do Post">
                </div>
                <div id="DvBtns" class="dvBtns" runat="server">
                    <asp:Button ID="BtnLimpar" CssClass="btnLimpar" runat="server" Text="Limpar" />
                    <asp:Button ID="BtnEnviar" CssClass="btnEnviar" runat="server" Text="Enviar" OnClick="BtnEnviar_Click" />
                </div>
            </div>
        </div>
        <div id="ControleArvore" class="controleArvore" runat="server">
            <label id="lblContexto" class="lblContexto">
                Contexto do Post:</label><br />
            <Uc:PostArvore ID="arvoreControl" runat="server" />
        </div>
    </div>
</asp:Content>

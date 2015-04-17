<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ops.aspx.cs" Inherits="AgilityKB.Ops" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="Styles/Css/Error.css" rel="stylesheet" />
    <title>Opppss</title>
</head>
<body>
    <form id="FormErro" runat="server">
        <div class="CorpoPagina">
            <h2 class="tituloExp">Opps</h2>
            <p class="conteudoExp">
                Um erro inesperado aconteceu pedimos desculpas por favor tente acessar a página
            novamente mais tarde
            </p>
            <asp:Button ID="BtnVoltar" CssClass="btnVoltar" Text="Voltar" runat="server" OnClick="BtnVoltar_Click" />
        </div>
    </form>
</body>
</html>

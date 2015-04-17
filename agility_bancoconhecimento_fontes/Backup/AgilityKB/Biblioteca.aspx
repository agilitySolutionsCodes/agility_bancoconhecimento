<%@ Page Title="Biblioteca Agility Base de Conhecimento Agility Solutions" Language="C#"
    MasterPageFile="~/AgilityKB.Master" AutoEventWireup="true" CodeBehind="Biblioteca.aspx.cs"
    Inherits="AgilityKB.Biblioteca" %>

<%@ Register TagPrefix="Uc" TagName="MenuLateral" Src="~/Controles/MenuLateral.ascx" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link href="Styles/Css/Biblioteca.css" rel="stylesheet" type="text/css" />
    <link href="Styles/Css/MenuLateral.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/Customizado/AgilityKB.js" type="text/javascript"></script>
    <title>Biblioteca Base de Conhecimento</title>
    <script type="text/javascript">
        function ChamaPost(IdPost) {
            var servico = "Servicos/ServicosBC.asmx/GetLink";
            var params = "{'idPost':'" + IdPost + "'}";

            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: servico,
                data: params,
                dataType: "json",
                async: true,
                success: function (data) {
                    document.getElementById("<%=LblTitulo.ClientID%>").innerHTML = data.d.Titulo;
                    document.getElementById("<%=ConteudoPost.ClientID%>").innerHTML = data.d.Conteudo;
                    document.getElementById("<%=LblData.ClientID%>").innerHTML = data.d.NomeUsuario + data.d.Data;

                    document.getElementById("<%=lnkArq.ClientID%>").innerHTML = data.d.NomeArq;
                    document.getElementById("<%=lnkArq.ClientID%>").href = data.d.CaminhoArq;
                },
                error: function (result) {
                    alert(result.response);
                }
            });
        }
        
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScrpPost" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel UpdateMode="Conditional" ID="PnlPost" runat="server">
        <ContentTemplate>
            <div id="Body" class="bibliotecaBody">
                <div id="MenuCLeft" class="menuLeft">
                    <div id="MenuLeft" class="menuLeft">
                        <Uc:MenuLateral ID="menuLateral" runat="server" />
                    </div>
                </div>
                <div id="ContentRight" class="menuRight" runat="server">
                    <div id="TituloPost" class="tituloPost" runat="server">
                        <h2>
                            <asp:Label ID="LblTitulo" runat="server" Text=""></asp:Label>
                        </h2>
                    </div>
                    <div id="ConteudoPost" class="conteudoPost" runat="server">
                        <asp:Literal ID="litPost" runat="server" />
                    </div>
                    <div id="DataPost" class="dataPost" runat="server">
                        <a href id="lnkArq" class="btnDownloadFonte" runat="server" target="http://192.168.61.20/BancoConhecimento/Uploads/Arquivos/">
                        </a>
                        <asp:Label ID="LblData" CssClass="lblData" runat="server"></asp:Label>
                    </div>
                </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

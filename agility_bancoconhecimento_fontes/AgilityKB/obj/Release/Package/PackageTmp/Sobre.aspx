<%@ Page Title="Sobre a Base de Conhecimento Agility Solutions" Language="C#" MasterPageFile="~/AgilityKB.master"
    AutoEventWireup="true" CodeBehind="Sobre.aspx.cs" Inherits="AgilityKB.About" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link href="Styles/Css/Sobre.css" rel="stylesheet" type="text/css" />
    <title>Sobre a Base de Conhecimento</title>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="conteudoS">
        <h2>Sobre a Base de Conhecimento
        </h2>
        <p>
            Este sistema foi criado dada a necessidade de compartilhamento de conhecimento entre os consultores da Agility, 
            tais como sucessos obtidos, anotações importantes, erros a evitar, riscos do projeto, pontos de atenção, soluções desenvolvidas, etc., 
            visando a evolução uniforme da equipe e evitando a perda de tempo na busca por soluções que outros usuários já desenvolveram antes. 
        </p>
        <p>
            Permite ainda que versões mais atualizadas de arquivos sejam disponibilizadas logo após o seu recebimento, 
            garantindo que todos os consultores estejam alinhados quanto à correta informação.
        </p>
        <p>
            Uma vez conectado ao sistema, será possível buscar e ler os posts existentes, criar novos posts contando as experiências pessoais, 
            centralizar a disponibilização de arquivos e manter contato com os demais usuários cadastrados.
        </p>
    </div>
</asp:Content>

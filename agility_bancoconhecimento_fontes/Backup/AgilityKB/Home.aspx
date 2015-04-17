﻿<%@ Page Title="Base de Conhecimento Agility Solutions" Language="C#" MasterPageFile="~/AgilityKB.master"
    AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="AgilityKB._Default" %>

<%@ MasterType VirtualPath="~/AgilityKB.Master" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Base de Conhecimento Agility Solutions</title>
    <script src="Scripts/JQuery/jquery-1.7.2.js" type="text/javascript"></script>
    <script src="Scripts/Customizado/AgilityKB.js" type="text/javascript"></script>
    <link href="Styles/Css/Home.css" rel="stylesheet" type="text/css" />
    <link href="Styles/Css/JQueryCarrousel.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:Panel ID="pnlModal" runat="server" Visible="false">
        <%--Script Para Chamada do Modal Load Page --%>
        <script type="text/javascript">
            $(document).ready(function () {
                var id = '#dialog';

                //Get the screen height and width
                var maskHeight = $(document).height();
                var maskWidth = $(window).width();

                //Set heigth and width to mask to fill up the whole screen
                $('#mask').css({ 'width': maskWidth, 'height': maskHeight });

                //transition effect		
                $('#mask').fadeIn(1000);
                $('#mask').fadeTo("slow", 0.8);

                //Get the window height and width
                var winH = $(window).height();
                var winW = $(window).width();

                //Set the popup window to center
                $(id).css('top', winH / 2 - $(id).height() / 2);
                $(id).css('left', winW / 2 - $(id).width() / 2);

                //transition effect
                $(id).fadeIn(2000);

                //if close button is clicked
                $('.window .close').click(function (e) {
                    //Cancel the link behavior
                    e.preventDefault();

                    $('#mask').hide();
                    $('.window').hide();
                });

                //if mask is clicked
                $('#').click(function () {
                    $(this).hide();
                    $('.window').hide();
                });
            });

        </script>
    </asp:Panel>
    <div id="boxes">
        <div id="dialog" class="window">
            <div id="logoLogin" class="logoModal">
                <img alt="Agility Solutions" src="Styles/Images/ImagensPersonalizadas/LogoAgility_Reduzido.png"
                    class="imgLogoModal" />
            </div>
            <div id="LoginModal" class="loginModal">
                <div title="Informe seu Login para acesso ao sistema">
                    <label id="lblLogin" class="labelGen">
                        Login:</label>
                    <asp:TextBox ID="TxtEmail" CssClass="txtLogin" runat="server" />
                </div>
                <div title="Informe sua Senha para acesso ao sistema">
                    <label id="lblSenha" class="labelGen">
                        Senha:</label>
                    <asp:TextBox ID="TxtSenha" CssClass="txtSenha" TextMode="Password" runat="server" />
                </div>
                <div id="DvBtn" class="DvBtnEnviar">
                    <asp:Button ID="BtnEnviar" CssClass="btnEnviar" Text="Entrar" runat="server" OnClick="BtnEnviar_Click" />
                </div>
                <div id="DvErros" runat="server" class="dvErros">
                    <asp:Label ID="LblErros" CssClass="lblErros" runat="server" />
                </div>
            </div>
        </div>
        <!-- Máscara para cobrir toda a Tela -->
        <div id="mask" style="width: 1478px; height: 602px; display: none;">
        </div>
    </div>
    <div id="HomePageC" runat="server" class="HomeConteudo">
        <div id="ConteudoExp" class="conteudoExp" title="Explore seu conhecimento nas plataformas abaixo">
            <h2 class="tituloExp">
                Explore Seu Conhecimento nas Plataformas
            </h2>
        </div>
        <div id="carousel">
            <div id="buttons">
                <a id="prev"></a><a id="next"></a>
                <div class="clear">
                </div>
            </div>
            <div class="clear">
            </div>
            <div id="slides">
                <ul>
                    <li><a href="Biblioteca.aspx">
                        <img src="Styles/Images/ImagensPersonalizadas/slide1.gif" width="272" height="240"
                            alt="Slide 1" title="Exemplo Módulo 1" /></a></li>
                    <li><a href="Biblioteca.aspx">
                        <img src="Styles/Images/ImagensPersonalizadas/slide2.gif" width="272" height="240"
                            alt="Slide 2" title="Exemplo Módulo 2" /></a></li>
                    <li><a href="Biblioteca.aspx">
                        <img src="Styles/Images/ImagensPersonalizadas/slide3.gif" width="272" height="240"
                            alt="Slide 3" title="Exemplo Módulo 3" /></a></li>
                    <li><a href="Biblioteca.aspx">
                        <img src="Styles/Images/ImagensPersonalizadas/slide2.gif" width="272" height="240"
                            alt="Slide 4" title="Exemplo Módulo 2" /></a></li>
                </ul>
            </div>
        </div>
    </div>
</asp:Content>

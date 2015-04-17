<%@ Page Title="" Language="C#" MasterPageFile="~/AgilityKB.Master" AutoEventWireup="true"
    CodeBehind="CadastroUsuarios.aspx.cs" Inherits="AgilityKB.CadastroContatos" EnableEventValidation="false" %>

<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="../Scripts/Customizado/AgilityKB.js" type="text/javascript"></script>
    <link href="Css/CadastroUsuarios.css" rel="stylesheet" type="text/css" />
    <title>Cadastro de Contatos</title>
    <script id="scptConfirmacao" runat="server">
    </script>
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div id="Conteudo" class="conteudo" runat="server">
        <div id="DvCadastro" class="dvCadastro" runat="server" title="Cadastro de Contatos">
            <div id="DvNome" class="dvEstiloGenerico" runat="server" title="Nome">
                <asp:Label ID="LblNome" runat="server" CssClass="lblEstiloGenerico">
                    Nome:</asp:Label>
                <asp:TextBox ID="TxtNome" CssClass="txtEstiloGenerico" runat="server" />
            </div>
            <div id="DvEmail" class="dvEstiloGenerico" runat="server" title="E-mail">
                <asp:Label runat="server" ID="LblEmail" CssClass="lblEstiloGenerico">
                    E-mail:</asp:Label>
                <asp:TextBox ID="TxtEmail" CssClass="txtEstiloGenerico" runat="server" />
            </div>
            <div id="DvDpto" class="dvEstiloGenerico" runat="server" title="E-mail">
                <asp:Label runat="server" ID="Label1" CssClass="lblEstiloGenerico">
                    Departamento:</asp:Label>
                <asp:TextBox ID="TxtDpto" CssClass="txtEstiloGenerico" runat="server" />
            </div>
            <div id="DvTelefone" class="dvEstiloGenerico" runat="server" title="Telefone">
                <label runat="server" id="LblTelefone" cssclass="lblEstiloGenerico">
                    Telefone:</label>
                <asp:TextBox ID="TxtTelefone" CssClass="txtEstiloTelefone" runat="server" />
                <asp:TextBox ID="TxtRamal" CssClass="txtRamal" runat="server" />
            </div>
            <div id="DvCelular" class="dvEstiloGenerico" runat="server" title="Celular">
                <label id="LblCelular" runat="server" cssclass="lblEstiloGenerico">
                    Celular:</label>
                <asp:TextBox ID="TxtCelular" CssClass="txtEstiloGenerico" runat="server" />
            </div>
            <div id="DvSkype" class="dvEstiloGenerico" runat="server" title="Skype Name">
                <asp:Label ID="LblSkype" runat="server" class="lblEstiloGenerico">
                    Skype Name:</asp:Label>
                <asp:TextBox ID="TxtSkype" CssClass="txtEstiloGenerico" runat="server" />
            </div>
            <div id="DvFoto" class="dvEstiloGenerico" runat="server">
                <asp:Label ID="LblUpload" runat="server" CssClass="lblEstiloGenerico">
                    Foto:</asp:Label>
                <asp:FileUpload ID="UsuarioFtUpload" CssClass="postUpload" runat="server" />
            </div>
            <div id="DvSenha" class="dvEstiloGenerico" runat="server" title="Senha">
                <asp:Label ID="LblSenha" runat="server" CssClass="lblEstiloGenerico">
                    Senha:</asp:Label>
                <asp:TextBox ID="TxtSenha" CssClass="txtEstiloGenericoSenha" runat="server" TextMode="Password" />
            </div>
            <div id="DvConfirmaSenha" class="dvEstiloGenerico" runat="server" title="Confirmação de Senha">
                <asp:Label id="LblConfirmaSenha" runat="server" CssClass="lblEstiloGenerico">
                    Confirmação de Senha:</asp:Label>
                <asp:TextBox ID="TxtConfirmacaoSenha" CssClass="txtEstiloGenericoSenha" runat="server"
                    TextMode="Password" />
            </div>
            <div id="DvAtivo" class="dvEstiloGenerico" runat="server">
                <asp:Label runat="server" ID="LblAtivo" class="lblEstiloGenerico">
                    Aitvo:</asp:Label>
                <asp:CheckBox ID="ChkbAtivo" CssClass="chkbAtivo" runat="server" />
            </div>
            <div id="DvBtns" class="dvEstiloGenerico" runat="server" title="Foto">
                <asp:Button ID="BtnLimpar" CssClass="btnLimpar" Text="Limpar" runat="server" OnClick="BtnLimpar_Click" />
                <asp:Button ID="BtnEnviar" CssClass="btnEnviar" Text="Enviar" runat="server" OnClick="BtnEnviar_Click" />
            </div>
        </div>
        <div id="DvErros" runat="server" class="dvErros">
            <asp:Label ID="LblErros" CssClass="lblErros" runat="server" />
            <asp:Label ID="LblSucesso" CssClass="lblSucesso" runat="server" />
        </div>
        <div id="GrdContatos" class="dvContatosCadastrados" runat="server">
            <asp:GridView ID="GrdUsuarios" runat="server" CssClass="GridViewStyle" AutoGenerateColumns="false"
                RowStyle-HorizontalAlign="NotSet" ShowFooter="false" AllowPaging="true" OnRowDeleting="GrdUsuarios_RowDeleting">
                <Columns>
                    <asp:TemplateField HeaderText="Ações">
                        <ItemTemplate>
                            <asp:ImageButton runat="server" ID="BtnDeletar" OnClick="BtnDeletar_Click" OnClientClick="javascript:return confirm('Deseja excluir este registro?');"
                                CausesValidation="false" CommandName="Deletar" CommandArgument='<%# Bind("IdUsuario")  %>'
                                ImageUrl="~/Styles/Images/ImagensGenericas/Img_Excluir.png" />
                            <asp:ImageButton runat="server" ID="BtnEditar" OnClick="BtnEditar_Click" OnClientClick="javascript:return confirm('Deseja alterar este registro?');"
                                CausesValidation="false" CommandName="Editar" ImageUrl="~/Styles/Images/ImagensGenericas/Img_Editar.gif" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Id" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblIdUsuario" runat="server" Text='<%# Bind("IdUsuario")  %>' />
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Nome" Visible="true">
                        <ItemTemplate>
                            <asp:Label ID="lblNome" runat="server" Text='<%# Bind("Nome")  %>' />
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Email" Visible="true">
                        <ItemTemplate>
                            <asp:Label ID="lblEmail" runat="server" Text='<%# Bind("Email")  %>' />
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Telefone" Visible="true">
                        <ItemTemplate>
                            <asp:Label ID="lblTelefone" runat="server" Text='<%# Bind("Telefone")  %>' />
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Ramal" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblRamal" runat="server" Text='<%# Bind("Ramal")  %>' />
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Celular" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblCelular" runat="server" Text='<%# Bind("Celular")  %>' />
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Nome Skype" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblNomeSkype" runat="server" Text='<%# Bind("NomeSkype")  %>' />
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Foto" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblFoto" runat="server" Text='<%# Bind("Foto")  %>' />
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Senha" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblSenha" runat="server" Text='<%# Bind("Senha")  %>' />
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Imagem" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblImagem" runat="server" Text='<%# Bind("Imagem")  %>' />
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Departamento" Visible="true">
                        <ItemTemplate>
                            <asp:Label ID="lblDpto" runat="server" Text='<%# Bind("Departamento")  %>' />
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/BackOffice/BackOffice.Master" AutoEventWireup="true"
    CodeBehind="CadastroUsuarios.aspx.cs" Inherits="AgilityKB.CadastroContatos" EnableEventValidation="false"
    meta:resourcekey="PageResource1" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="HeaderContent" runat="server">
    <title>Cadastro de Contatos</title>
    <link href="Css/CadastroUsuarios.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/JQuery/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../Scripts/Customizado/autoNumeric.js" type="text/javascript"></script>
    <script id="scptConfirmacao" runat="server">
    </script>
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div id="Conteudo" class="conteudo" runat="server">
        <div id="DvErros" runat="server" class="dvErros">
            <asp:Label ID="LblErros" CssClass="lblErros" runat="server" />
        </div>
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
                <asp:Label runat="server" ID="LblTelefone" CssClass="lblEstiloGenerico">
                    Telefone:</asp:Label>
                <asp:TextBox ID="TxtTelefone" CssClass="txtEstiloTelefone" runat="server" MaxLength="14" />
                <asp:TextBox ID="TxtRamal" CssClass="txtRamal" runat="server" />
            </div>
            <div id="DvCelular" class="dvEstiloGenerico" runat="server" title="Celular">
                <asp:Label ID="LblCelular" runat="server" CssClass="lblEstiloGenerico">
                    Celular:</asp:Label>
                <asp:TextBox ID="TxtCelular" CssClass="txtEstiloGenerico" runat="server" MaxLength="9" />
            </div>
            <div id="DvSkype" class="dvEstiloGenerico" runat="server" title="Skype Name">
                <asp:Label ID="LblSkype" runat="server" CssClass="lblEstiloGenerico">
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
                <asp:TextBox ID="TxtSenha" CssClass="txtEstiloGenericoSenha" runat="server" TextMode="Password" MaxLength="6" />
            </div>
            <div id="DvConfirmaSenha" class="dvEstiloGenerico" runat="server" title="Confirmação de Senha">
                <asp:Label ID="LblConfirmaSenha" runat="server" CssClass="lblEstiloGenerico">
                    Confirmação de Senha:</asp:Label>
                <asp:TextBox ID="TxtConfirmacaoSenha" CssClass="txtEstiloGenericoSenha" runat="server"
                    TextMode="Password" MaxLength="6" />
            </div>
            <div id="DvAdministrador" class="dvEstiloGenerico" runat="server" title="Possui perfil administrador?">
                <asp:Label ID="LblAdministrador" runat="server" CssClass="lblEstiloGenerico">
                    Perfil Administrador:</asp:Label>
                <asp:CheckBox ID="ChkAdministradorS" runat="server" CssClass="chkbAtivo" />
                <asp:Label ID="LblSim" runat="server" CssClass="lblEstiloGenericoChk">
                    Sim</asp:Label>
                <asp:CheckBox ID="ChkAdministradorN" runat="server" CssClass="chkbAtivo" />
                <asp:Label ID="LblNao" runat="server" CssClass="lblEstiloGenericoChk">
                    Não</asp:Label>
            </div>
            <div id="DvBtns" class="dvEstiloGenerico" runat="server" title="Foto">
                <asp:Button ID="BtnLimpar" CssClass="btnLimpar" Text="Limpar" runat="server" OnClick="BtnLimpar_Click" />
                <asp:Button ID="BtnEnviar" CssClass="btnEnviar" Text="Enviar" runat="server" OnClick="BtnEnviar_Click" />
            </div>
        </div>
        <div id="GrdContatos" class="dvContatosCadastrados" runat="server">
            <asp:GridView ID="GrdUsuarios" runat="server" CssClass="GridViewStyle" AutoGenerateColumns="False"
                RowStyle-HorizontalAlign="NotSet" AllowPaging="True" OnRowDeleting="GrdUsuarios_RowDeleting"
                OnPageIndexChanging="GrdUsuarios_PageIndexChanging" PageSize="10"
                meta:resourcekey="GrdUsuariosResource1">
                <Columns>
                    <asp:TemplateField HeaderText="Ações" meta:resourcekey="TemplateFieldResource1">
                        <ItemTemplate>
                            <asp:ImageButton runat="server" ID="BtnDeletar" OnClick="BtnDeletar_Click" OnClientClick="javascript:return confirm('Deseja excluir este registro?');"
                                CausesValidation="False" CommandName="Deletar" CommandArgument='<%# Bind("IdUsuario") %>'
                                ImageUrl="~/Styles/Images/ImagensGenericas/Img_Excluir.png" meta:resourcekey="BtnDeletarResource1" />
                            <asp:ImageButton runat="server" ID="BtnEditar" OnClick="BtnEditar_Click" OnClientClick="javascript:return confirm('Deseja alterar este registro?');"
                                CausesValidation="False" CommandName="Editar" ImageUrl="~/Styles/Images/ImagensGenericas/Img_Editar.gif"
                                meta:resourcekey="BtnEditarResource1" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Id" Visible="false" meta:resourcekey="TemplateFieldResource2">
                        <ItemTemplate>
                            <asp:Label ID="lblIdUsuario" runat="server" Text='<%# Bind("IdUsuario") %>' meta:resourcekey="lblIdUsuarioResource1" />
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Nome" Visible="true" meta:resourcekey="TemplateFieldResource3">
                        <ItemTemplate>
                            <asp:Label ID="lblNome" runat="server" Text='<%# Bind("Nome") %>' meta:resourcekey="lblNomeResource2" />
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Email" Visible="true" meta:resourcekey="TemplateFieldResource4">
                        <ItemTemplate>
                            <asp:Label ID="lblEmail" runat="server" Text='<%# Bind("Email") %>' meta:resourcekey="lblEmailResource2" />
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Telefone" Visible="true" meta:resourcekey="TemplateFieldResource5">
                        <ItemTemplate>
                            <asp:Label ID="lblTelefone" runat="server" Text='<%# Bind("Telefone") %>' meta:resourcekey="lblTelefoneResource2" />
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Ramal" Visible="false" meta:resourcekey="TemplateFieldResource6">
                        <ItemTemplate>
                            <asp:Label ID="lblRamal" runat="server" Text='<%# Bind("Ramal") %>' meta:resourcekey="lblRamalResource1" />
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Celular" Visible="false" meta:resourcekey="TemplateFieldResource7">
                        <ItemTemplate>
                            <asp:Label ID="lblCelular" runat="server" Text='<%# Bind("Celular") %>' meta:resourcekey="lblCelularResource2" />
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Nome Skype" Visible="false" meta:resourcekey="TemplateFieldResource8">
                        <ItemTemplate>
                            <asp:Label ID="lblNomeSkype" runat="server" Text='<%# Bind("NomeSkype") %>' meta:resourcekey="lblNomeSkypeResource1" />
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Foto" Visible="false" meta:resourcekey="TemplateFieldResource9">
                        <ItemTemplate>
                            <asp:Label ID="lblFoto" runat="server" Text='<%# Bind("Foto") %>' meta:resourcekey="lblFotoResource1" />
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Senha" Visible="false" meta:resourcekey="TemplateFieldResource10">
                        <ItemTemplate>
                            <asp:Label ID="lblSenha" runat="server" Text='<%# Bind("Senha") %>' meta:resourcekey="lblSenhaResource2" />
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Imagem" Visible="false" meta:resourcekey="TemplateFieldResource11">
                        <ItemTemplate>
                            <asp:Label ID="lblImagem" runat="server" Text='<%# Bind("Imagem") %>' meta:resourcekey="lblImagemResource1" />
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Departamento" Visible="true" meta:resourcekey="TemplateFieldResource12">
                        <ItemTemplate>
                            <asp:Label ID="lblDpto" runat="server" Text='<%# Bind("Departamento") %>' meta:resourcekey="lblDptoResource1" />
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>

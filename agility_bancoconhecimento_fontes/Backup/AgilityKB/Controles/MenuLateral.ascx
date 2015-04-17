<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MenuLateral.ascx.cs"
    Inherits="AgilityKB.Controles.MenuLateral" %>
<div id="BodyLeft" runat="server" class="bodyLeft">
    <div id="CampoBusca" class="campoBusca" title="Digite aqui o que você esta procurando">
        <asp:TextBox ID="TxtBusca" CssClass="txtBusca" runat="server" MaxLength="200"></asp:TextBox>
        <asp:ImageButton ID="BtnBuscar" runat="server" CssClass="imgBusca" ImageUrl="../Styles/Images/ImagensGenericas/Icon_Search.png"
            Width="16px" OnClick="BtnBuscar_Click" />
    </div>
    <asp:TreeView ID="ArvoreBiblioteca" runat="server" CssClass="arvoreBiblioteca" Width="278px"
        ImageSet="Msdn" NodeIndent="10" NodeStyle-CssClass="arvore" OnSelectedNodeChanged="ArvoreBiblioteca_SelectedNodeChanged">
        <HoverNodeStyle BackColor="Transparent" BorderColor="#3A4F63" BorderStyle="Solid"
            Font-Underline="True" />
        <NodeStyle HorizontalPadding="5px" CssClass="arvore" NodeSpacing="1px" VerticalPadding="2px" />
        <ParentNodeStyle Font-Bold="False" />
        <SelectedNodeStyle ForeColor="#666" BorderStyle="Solid" Font-Underline="False" HorizontalPadding="3px"
            CssClass="arvore" VerticalPadding="1px" />
    </asp:TreeView>
</div>

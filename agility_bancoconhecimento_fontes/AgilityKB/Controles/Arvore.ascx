<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Arvore.ascx.cs" Inherits="AgilityKB.Controles.Arvore" %>
<asp:TreeView ID="ArvoreBiblioteca" runat="server" CssClass="arvoreBiblioteca" Width="278px"
    ImageSet="Msdn" NodeIndent="10" NodeStyle-CssClass="arvore" OnSelectedNodeChanged="ArvoreBiblioteca_SelectedNodeChanged">
    <HoverNodeStyle BackColor="Transparent" BorderColor="#3A4F63" BorderStyle="Solid"
        Font-Underline="True" />
    <NodeStyle HorizontalPadding="5px" CssClass="arvore" NodeSpacing="1px" VerticalPadding="2px" />
    <ParentNodeStyle Font-Bold="False" />
    <SelectedNodeStyle ForeColor="#666" BorderStyle="Solid" Font-Underline="False" HorizontalPadding="3px"
        CssClass="arvore" VerticalPadding="1px" />
</asp:TreeView>

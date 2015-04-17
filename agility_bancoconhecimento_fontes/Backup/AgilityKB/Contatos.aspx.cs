using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using AgilityKB.Entity;
using AgilityKB.Business;

namespace AgilityKB
{
    public partial class Contatos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["CodUsuario"] == null)
                {
                    Response.Redirect("~/Home.aspx");
                }

                else
                {
                    CarregaUsuarios();
                }   
            }            
        }

        public UsuarioBusiness CarregaUsuarios()
        {
            String vConteudo = string.Empty;
            UsuarioBusiness usuarioB = new UsuarioBusiness();
            DataTable dt = new DataTable();

            dt = usuarioB.ListaUsuarios();

            if (dt.Rows.Count == 0)
            {
                String erro = string.Empty;
                erro = "Colocar lógica aqui caso a exibição de resultados seja 0";
            }

            foreach (DataRow dr in dt.Rows)
            {
                vConteudo += "<div class='contatoMoldura'>";
                vConteudo += "<div class='contatofoto' title='" + dr["Departamento"].ToString();
                vConteudo += " '>";
                vConteudo += "<img id='ImgContatos' style='width:130px; height: 97px; margin: 2px 1px 1px 1px; border: 1px solid #9D9D9D;' src=" +
                                Request.ApplicationPath + "/Uploads/Imgs/";
                vConteudo += dr["Imagem"].ToString();
                vConteudo += " />";
                vConteudo += "</div>";
                vConteudo += "<div class='infoContato'>";
                vConteudo += "<p class='fonteInfoC'>";
                vConteudo += dr["Nome"].ToString();
                vConteudo += "</p>";
                vConteudo += "<p class='fonteInfoEmail'>";
                vConteudo += "<a href='" + "mailto:" + dr["Email"].ToString() + "?subject=Post Base de Conhecimento Agility" + "'" + "class='fonteInfoEmail' >" + dr                                        ["Email"].ToString() + "</a>";
                vConteudo += "</p>";
                vConteudo += "<p class='fonteInfo'>";
                vConteudo += "Tel: (11) " + dr["Telefone"].ToString();
                vConteudo += " Ramal: " + dr["Ramal"].ToString();
                vConteudo += "</p>";
                vConteudo += "<p class='fonteInfoSkype'>";
                vConteudo += "<a href='skype:";
                vConteudo += dr["NomeSkype"].ToString();
                vConteudo += "?add'>";
                vConteudo += "<img src='http://download.skype.com/share/skypebuttons/buttons/add_green_transparent_118x23.png'";
                vConteudo += "style='border: none; margin-top: 5px;' width='118'height='23' alt='Adicionar no Skype' /></a></p>";
                vConteudo += "</div>";
                vConteudo += "</div>";
            }

            LtlConteudo.Text = vConteudo;

            return usuarioB;
        }
    }
}
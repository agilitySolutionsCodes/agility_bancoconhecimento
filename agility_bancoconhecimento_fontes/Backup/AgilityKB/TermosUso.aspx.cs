using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using AgilityKB.Entity;
using AgilityKB.Business;

namespace AgilityKB
{
    public partial class TermosUso : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["CodUsuario"] == null)
                {
                    Response.Redirect("~/Home.aspx");
                }
            }
        }

        protected void ChkAceite_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void ChkRecusa_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void BtnEnviar_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();
            UsuarioBusiness usuarioB = new UsuarioBusiness();

            if (ChkAceite.Checked == true)
            {
                usuario.IdUsuario = Convert.ToInt32(Session["CodUsuario"].ToString());
                usuario.Ativo = true;

                usuarioB.AceitaTermos(usuario.IdUsuario, usuario.Ativo);
                ScriptManager.RegisterClientScriptBlock(BtnEnviar, BtnEnviar.GetType(), "msgSucesso", "alert('Bem Vindo a Base de Conhecimento Agility Solutions.');", true);
                
                Response.Redirect("~/Home.aspx");
            }

            else
            {
                if (ChkRecusa.Checked == true)
                {
                    Session.RemoveAll();
                    Response.Redirect("~/Home.aspx");
                }
            }
        }
    }
}
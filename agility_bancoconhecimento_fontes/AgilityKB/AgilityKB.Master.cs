using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Data;
using System.Threading;

using AgilityKB.Entity;
using AgilityKB.Business;

namespace AgilityKB
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)    
        {
            if (!Page.IsPostBack)
            {
                if (Session["CodUsuario"] != null)
                {
                    DvUsuario.Visible = true;
                    ImgUsuarioLogado.Visible = true;
                    ImgUsuarioLogadoBig.Visible = true;

                    ImgUsuarioLogado.ImageUrl = Request.ApplicationPath + "/Uploads/Imgs/" + Session["ImagemUsuario"].ToString();
                    ImgUsuarioLogadoBig.ImageUrl = Request.ApplicationPath + "/Uploads/Imgs/" + Session["ImagemUsuario"].ToString();
                    
                    LblUserLogado.Visible = true;
                    LblUserLogadoBig.Visible = true;
                    LblUserUltimoPost.Visible = true;
                    LblPerfilUsuario.Visible = true;

                    LblUserLogado.Text = Session["NomeUsuario"].ToString();
                    LblUserLogadoBig.Text = Session["NomeUsuario"].ToString();

                    if (Session["UltimoPost"].ToString() != "")
                    {
                        string dataUltimoPost;
                        dataUltimoPost = Session["UltimoPost"].ToString();
                        LblUserUltimoPost.Text = "Ultimo Post:" + " " + Convert.ToDateTime(dataUltimoPost).ToString("dd/MM/yyyy");
                    }

                    else
                    {
                        LblUserUltimoPost.Visible = false;
                    }

                    //Valida se o perfil do usuário logado é ou não de administrador
                    if (Session["PerfilUsuario"] != null)
                    {
                        if (Session["PerfilUsuario"].ToString() != "1")
                        {
                            LblPerfilUsuario.Text = "Perfil: Usuário";
                        }
                    }

                    else
                    {
                        LblPerfilUsuario.Text = "Perfil: Administrador";
                    }

                    LnkLogout.Visible = true;
                }
            }
        }

        protected void LnkLogout_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("~/default.aspx");
        }

        protected void BtnDocumentacao_Click(object sender, EventArgs e)
        {
            Response.ContentType = "Application/msword";
            Response.AppendHeader("Content-Disposition", "attachment; filename=Manual.pdf");
            Response.TransmitFile(Server.MapPath("~/Uploads/Arquivos/Manual.pdf"));
            Response.End();
        }

        protected void BtnPolitica_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/PoliticaPrivacidade.aspx");
        }

        protected void BtnTermosUso_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/TermosUso.aspx");
        }

        protected void BtnAdministrador_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();
            UsuarioBusiness usuarioB = new UsuarioBusiness();

            usuario = usuarioB.AutenticarUsuarioLogado(Session["EmailUsuario"].ToString());

            if (usuario.Logado == true)
            {
                Response.Redirect("~/BackOffice/Home.aspx");
            }

            else
            {
                Response.Redirect("~/BackOffice/Login.aspx");
                Session.RemoveAll();
            }
        }

    }
}

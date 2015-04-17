using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Data;

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
                    ImgUsuarioLogado.ImageUrl = Request.ApplicationPath + "/Uploads/Imgs/" + Session["ImagemUsuario"].ToString();
                    LblUserLogado.Visible = true;
                    LblUserLogado.Text = Session["NomeUsuario"].ToString();
                    LnkLogout.Visible = true;
                }
            }
        }

        protected void LnkLogout_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("~/Home.aspx");
        }

        protected void BtnDocumentacao_Click(object sender, EventArgs e)
        {
            Response.ContentType = "Application/msword";
            Response.AppendHeader("Content-Disposition", "attachment; filename=Documentacao Base Conhecimento.docx");
            Response.TransmitFile(Server.MapPath("~/BancoConhecimento/Uploads/Arquivos/Documentacao Base Conhecimento.docx"));
            Response.End();
        }

        protected void BtnPolitica_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/PoliticaPrivacidade.aspx");
        }

        protected void BtnTermosUso_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/TermosDeUso.aspx");
        }

        protected void BtnAdministrador_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("~/BackOffice/Login.aspx");
        }
    }
}

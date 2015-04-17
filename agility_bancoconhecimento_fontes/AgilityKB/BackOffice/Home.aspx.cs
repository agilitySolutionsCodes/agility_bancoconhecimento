using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AgilityKB.BackOffice
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["CodUsuario"] != null)
                {
                    Image imgUsuarioLogado = (Image)Master.FindControl("ImgUsuarioLogado");
                    Image imgUsuarioLogadoBig = (Image)Master.FindControl("ImgUsuarioLogadoBig");

                    imgUsuarioLogado.ImageUrl = "../Uploads/Imgs/" + Session["ImagemUsuario"].ToString();
                    imgUsuarioLogadoBig.ImageUrl = "../Uploads/Imgs/" + Session["ImagemUsuario"].ToString();

                    Label lblUsuarioLogado = (Label)Master.FindControl("LblUserLogado");
                    Label lblUsuarioLogadoBig = (Label)Master.FindControl("LblUserLogadoBig");

                    lblUsuarioLogado.Text = Session["NomeUsuario"].ToString();
                    lblUsuarioLogadoBig.Text = Session["NomeUsuario"].ToString();
                }

                else
                {
                    Response.Redirect("~/BackOffice/Login.aspx");
                }
                
            }
        }

        protected void LnkBtnOpcaoA_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/CadastroUsuarios.aspx");
        }

        protected void LnkBtnOpcaoB_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Home.aspx");
        }

    }
}
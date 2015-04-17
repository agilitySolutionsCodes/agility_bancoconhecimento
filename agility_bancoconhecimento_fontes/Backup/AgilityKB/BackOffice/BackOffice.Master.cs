using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AgilityKB.BackOffice
{
    public partial class BackOffice : System.Web.UI.MasterPage
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
            Response.Redirect("~/BackOffice/Login.aspx");
        }
    }
}
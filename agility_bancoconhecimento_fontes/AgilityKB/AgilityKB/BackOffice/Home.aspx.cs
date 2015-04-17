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
    }
}
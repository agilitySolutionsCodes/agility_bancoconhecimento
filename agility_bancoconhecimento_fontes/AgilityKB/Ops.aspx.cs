using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AgilityKB
{
    public partial class Ops : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BtnVoltar.Attributes.Add("onClick", "javascript:history.back(); return false;");
        }

        protected void BtnVoltar_Click(object sender, EventArgs e)
        {

        }
    }
}
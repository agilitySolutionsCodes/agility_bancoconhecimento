using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

using AgilityKB.Entity;
using AgilityKB.Business;
using AgilityKB.Controles;


namespace AgilityKB.BackOffice
{
    public partial class CategoriasCadastro : System.Web.UI.Page
    {
        Posts post = new Posts();

        protected void Page_Load(object sender, EventArgs e)
        {
            arvoreControl.OnSelecionarContexto += new SelecionarContexto(ControleArvore_OnSelecionarContexto);

            if (!Page.IsPostBack)
            {
                DvErros.Visible = false;
                
            }
        }

        protected void BtnEnviar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos() == false)
            {
                DvErros.Visible = true;   
            }

            else
            {
                PostsBusiness postB = new PostsBusiness();
                postB.RegistrarCategoria(TxtTitulo.Text, arvoreControl.IdSelecionado, 1);
                ScriptManager.RegisterClientScriptBlock(BtnEnviar, BtnEnviar.GetType(), "msgSucesso", "alert('Cadastro efetuado com Sucesso.');", true);

                Response.Redirect("~/BackOffice/CadastroCategorias.aspx");

            }              
        }
        
        protected void ControleArvore_OnSelecionarContexto(string IdNode)
        {
            post.IdContexto = Convert.ToInt32(IdNode);
        }

        public Boolean ValidarCampos()
        {
            //Variável de erros
            string erros = string.Empty;

            //Retorno da Validação = False
            bool valid = false;

            if (string.IsNullOrEmpty(TxtTitulo.Text))
            {
                erros = "<br />" + "* É necessário um nome a categoria que será cadastrada!";
            }

            if (arvoreControl.IdSelecionado == -1)
            {
                erros = erros + "<br />" + "* É necessário selecionar um contexto para o cadastro!";
            }

            else
                valid = true;

            //Prrenche a propriedade text do Label com o valor da variável erros
            LblErros.Text = erros;
            //Retorno da Validação True/False
            return valid;
        }
    }
}
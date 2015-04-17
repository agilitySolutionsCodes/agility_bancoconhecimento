using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Text;

using AgilityKB.Entity;
using AgilityKB.Business;
using AgilityKB.Controles;

namespace AgilityKB
{
    public partial class CriacaoPosts : System.Web.UI.Page
    {
        Posts post = new Posts();

        protected void Page_Load(object sender, EventArgs e)
        {
            arvoreControl.OnSelecionarContexto += new SelecionarContexto(ControleArvore_OnSelecionarContexto);

            if (!Page.IsPostBack)
            {
                DvErros.Visible = false;
            }

            else
            {
                if (PostUpload.HasFile)
                {
                    Session["ArquivoSelecionado"] = PostUpload;
                    LblUploadArquivo.Text = PostUpload.FileName;
                }
            }
        }

        public Boolean ValidarCampos()
        {
            //Variável de erros
            string erros = string.Empty;

            //Retorno da Validação = False
            bool valid = false;

            if (string.IsNullOrEmpty(TxtTitulo.Text))
            {
                erros = "<br />" + "* O campo Título do Post é obrigatório";
            }

            if (string.IsNullOrEmpty(TxtConteudo.Text))
            {
                erros = erros + "<br />" + "* Este Post Deve possuir algum conteúdo";
            }

            else
                valid = true;

            //Prrenche a propriedade text do Label com o valor da variável erros
            LblErros.Text = erros;
            //Retorno da Validação True/False
            return valid;
        }

        protected void BtnEnviar_Click(object sender, EventArgs e)
        {
            //Valida se campos obrigatórios estão preenchidos
            if (!ValidarCampos() == true)
            {
                ScriptManager.RegisterClientScriptBlock(BtnEnviar, BtnEnviar.GetType(), "msgFalha", "alert('Erro ao cadastrar Post verifique preenchimento dos campos.');", true);
                DvErros.Visible = true;
            }

            else
            {
                //Checa se existe um arquivo para ser salvo
                if (Session["ArquivoSelecionado"].ToString() != string.Empty || PostUpload.HasFile)
                {
                    PostUpload.SaveAs(Server.MapPath("~/Uploads/Arquivos/") + LblUploadArquivo.Text);
                }

                //Variáveis de Data e Hora do Post
                var dataHoje = DateTime.Today.Date;
                var dataHora = DateTime.Now.ToString("HH:MM");

                PostsBusiness postsB = new PostsBusiness();
                //Chamada do Método RegistrarPost com os parametros
                postsB.RegistrarPost(TxtTitulo.Text, TxtConteudo.Text, LblUploadArquivo.Text, dataHoje, Convert.ToString(dataHora), Session["CodUsuario"].ToString(),
                                      arvoreControl.IdSelecionado);
                LimparCampos();
                DvErros.Visible = true;
                LblErros.Visible = false;

                ScriptManager.RegisterClientScriptBlock(BtnEnviar, BtnEnviar.GetType(), "msgSucesso", "alert('Post cadastrado com sucesso.');", true);
            }
        }

        protected void BtnLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        public void LimparCampos()
        {
            TxtTitulo.Text = string.Empty;
            TxtConteudo.Text = string.Empty;
        }

        string ArquivoUpload = string.Empty;
       
        public void ControleArvore_OnSelecionarContexto(string IdNo)
        {
            Session.Add("ArquivoSelecionado", PostUpload.FileName);
            post.IdContexto = Convert.ToInt32(IdNo);
        }
    }
}
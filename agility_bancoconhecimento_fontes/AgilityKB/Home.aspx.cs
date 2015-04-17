using System;
using System.Web;
using System.Data;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Security.Cryptography;

using AgilityKB.Entity;
using AgilityKB.Business;

namespace AgilityKB
{
    public partial class _Default : System.Web.UI.Page, IRequiresSessionState
    {
        #region Objetos instânciados para Criptografia de Senha
        TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
        MD5CryptoServiceProvider md5Crypto = new MD5CryptoServiceProvider();

        //Chave para criptografia
        String Chave = "Agility";
        Categoria categoria = new Categoria();
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //Caso não exista um usuário loga modal de login é exibida
                if (Session["CodUsuario"] == null || Session["Ativo"] == null)
                {
                    pnlModal.Visible = true;
                }

                else
                {
                    //Preenche controles com propriedades criadas no login
                    Image imgUsuarioLogado = (Image)Master.FindControl("ImgUsuarioLogado");
                    Image imgUsuarioLogadoBig = (Image)Master.FindControl("ImgUsuarioLogadoBig");

                    imgUsuarioLogado.ImageUrl = "Uploads/Imgs/" + Session["ImagemUsuario"].ToString();
                    imgUsuarioLogadoBig.ImageUrl = "Uploads/Imgs/" + Session["ImagemUsuario"].ToString();

                    Label lblUsuarioLogado = (Label)Master.FindControl("LblUserLogado");
                    Label lblUsuarioLogadoBig = (Label)Master.FindControl("LblUserLogadoBig");

                    lblUsuarioLogado.Text = Session["NomeUsuario"].ToString();
                    lblUsuarioLogadoBig.Text = Session["NomeUsuario"].ToString();
                }
            }

            else
            {
                MontaCategorias();
            }
        }

        public String DescriptografarSenha(string senha)
        {
            des.Key = md5Crypto.ComputeHash(ASCIIEncoding.ASCII.GetBytes(Chave));
            des.Mode = CipherMode.ECB;
            ICryptoTransform desdencrypt = des.CreateEncryptor();
            ASCIIEncoding MyASCIIEncoding = new ASCIIEncoding();
            var buff = ASCIIEncoding.ASCII.GetBytes(senha);
            senha = Convert.ToBase64String(desdencrypt.TransformFinalBlock(buff, 0, buff.Length));

            return senha;
        }

        public Boolean ValidarCampos()
        {
            //Variável de erros
            string erros = string.Empty;

            //Retorno da Validação = False
            bool valid = false;

            if (string.IsNullOrEmpty(TxtEmail.Text))
            {
                erros = "<br />" + "* O campo E-mail é obrigatório";
            }

            if (string.IsNullOrEmpty(TxtSenha.Text))
            {
                erros = erros + "<br />" + "* Por Favor Digite uma Senha";
            }

            else
                valid = true;

            //Prrenche a propriedade text do Label com o valor da variável erros
            LblErros.Text = erros;
            //Retorno da Validação True/False
            return valid;
        }

        protected void BtnLogar_Click(object sender, EventArgs e)
        {
            //Instância objeto usuario
            Usuario usuario = new Usuario();

            //Instância objeto usuario business 
            UsuarioBusiness usuarioB = new UsuarioBusiness();

            //Método de validação de campos modal login
            ValidarCampos();

            if (!ValidarCampos() == true)
            {
                DvErros.Visible = true;
            }

            else
            {
                var vSenha = DescriptografarSenha(TxtSenha.Text);
                usuario = usuarioB.AutenticaUsuario(TxtEmail.Text, vSenha);

                //Valida se o usuário esta logado
                if (usuario.Logado == true)
                {
                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, Convert.ToString(usuario.IdUsuario), DateTime.Now,
                                                                                     DateTime.Now.AddMinutes(20), true, "");
                    
                    //Cria sessões e preenche as váriaveis com as propriedades retornadas no objeto usuário
                    Session.Add("CodUsuario", usuario.IdUsuario);
                    Session.Add("NomeUsuario", " " + usuario.Nome);
                    Session.Add("EmailUsuario", usuario.Email.Trim());
                    Session.Add("ImagemUsuario", usuario.Imagem);
                    Session.Add("Ativo", usuario.Ativo);
                    Session.Add("UltimoPost", usuario.UltimoPost);

                    if (usuario.Administrador == true)
                    {
                        Session.Add("PerfilUsuario", 1);
                    }
                    else
                    {
                        Session.Add("PerfilUsuario", 0);
                    }
                    

                    Image imgUsuarioLogado = (Image)Master.FindControl("ImgUsuarioLogado");
                    Image imgUsuarioLogadoBig = (Image)Master.FindControl("ImgUsuarioLogadoBig");

                    imgUsuarioLogado.Visible = true;
                    imgUsuarioLogadoBig.Visible = true;

                    imgUsuarioLogado.ImageUrl = Request.ApplicationPath + "/Uploads/Imgs/" + Session["ImagemUsuario"].ToString();
                    imgUsuarioLogadoBig.ImageUrl = Request.ApplicationPath + "/Uploads/Imgs/" + Session["ImagemUsuario"].ToString();

                    Label lblUsuarioLogado = (Label)Master.FindControl("LblUserLogado");
                    lblUsuarioLogado.Visible = true;

                    Label LblUserLogadoBig = (Label)Master.FindControl("LblUserLogadoBig");
                    LblUserLogadoBig.Visible = true;

                    Label LblUserUltimoPost = (Label)Master.FindControl("LblUserUltimoPost");
                    LblUserUltimoPost.Visible = true;

                    Label LblPerfilUsuario = (Label)Master.FindControl("LblPerfilUsuario");
                    LblPerfilUsuario.Visible = true;

                    lblUsuarioLogado.Text = Session["NomeUsuario"].ToString();
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


                    LinkButton lnkLogout = (LinkButton)Master.FindControl("LnkLogout");
                    lnkLogout.Visible = true;

                    if (usuario.Ativo == false)
                    {
                        Session.Add("SenhaAtual", vSenha);
                        Response.Redirect("TermosUso.aspx");
                    }

                    else
                    {
                        pnlModal.Visible = false;
                    }
                }

                else
                {
                    LblErros.Text = "<br />" + "Login Inválido Por Favor Contate o Administrador";
                    DvErros.Visible = true;
                }
            }
        }

        public void MontaCategorias()
        {
            ArvoreBusiness arvoreB = new ArvoreBusiness();
            DataTable dt = arvoreB.ListaCategoriasHome();

            foreach (DataRow dr in dt.Rows)
            {
                categoria.Imagem = dr["ImgCategoria"].ToString();
            }
        }
    }
}

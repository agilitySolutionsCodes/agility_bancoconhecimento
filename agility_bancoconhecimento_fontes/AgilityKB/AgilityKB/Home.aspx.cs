using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Text;
using System.Web.UI.WebControls;
using System.Web.SessionState;
using System.Web.Security;
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
        String Chave = "Agility";
        Categoria categoria = new Categoria();
        #endregion 

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["CodUsuario"] == null)
                {
                    pnlModal.Visible = true;
                }
                else
                {
                    Image imgUsuarioLogado = (Image)Master.FindControl("ImgUsuarioLogado");
                    imgUsuarioLogado.ImageUrl = "../../Uploads/Imgs/" + Session["ImagemUsuario"].ToString();
                    Label lblUsuarioLogado = (Label)Master.FindControl("LblUserLogado");
                    lblUsuarioLogado.Text = Session["NomeUsuario"].ToString();
                }
            }

            else
            {
                MontaCategorias();
            }
        }

        public void Logar(object sender, AuthenticateEventArgs autArgs)
        {

        }

        public String Criptografar(string senha)
        {
            des.Key = md5Crypto.ComputeHash(ASCIIEncoding.ASCII.GetBytes(Chave));
            des.Mode = CipherMode.ECB;
            ICryptoTransform desdencrypt = des.CreateEncryptor();
            ASCIIEncoding MyASCIIEncoding = new ASCIIEncoding();
            var buff = ASCIIEncoding.ASCII.GetBytes(senha);
            senha = Convert.ToBase64String(desdencrypt.TransformFinalBlock(buff, 0, buff.Length));

            return senha;
        }

        public String DescriptografarSenha(string senha)
        {
            des.Key = md5Crypto.ComputeHash(ASCIIEncoding.ASCII.GetBytes(Chave));
            des.Mode = CipherMode.ECB;
            ICryptoTransform desdencrypt = des.CreateDecryptor();
            var buff = Convert.FromBase64String(senha);
            senha = ASCIIEncoding.ASCII.GetString(desdencrypt.TransformFinalBlock(buff, 0, buff.Length));

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

        protected void BtnEnviar_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();
            UsuarioBusiness usuarioB = new UsuarioBusiness();

            ValidarCampos();

            if (!ValidarCampos() == true)
            {
                DvErros.Visible = true;
            }

            else
            {

                var vSenha = Criptografar(TxtSenha.Text);
                usuario = usuarioB.AutenticaUsuario(TxtEmail.Text, vSenha);

                if (usuario.Logado == true)
                {
                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, Convert.ToString(usuario.IdUsuario), DateTime.Now,
                                                                                     DateTime.Now.AddMinutes(20), true, "");

                    Session.Add("CodUsuario", usuario.IdUsuario);
                    Session.Add("NomeUsuario", " " + usuario.Nome);
                    Session.Add("EmailUsuario", usuario.Email.Trim());
                    Session.Add("ImagemUsuario", usuario.Imagem);

                    Image imgUsuarioLogado = (Image)Master.FindControl("ImgUsuarioLogado");
                    imgUsuarioLogado.Visible = true;
                    imgUsuarioLogado.ImageUrl = Request.ApplicationPath + "/Uploads/Imgs/" + Session["ImagemUsuario"].ToString();
                    Label lblUsuarioLogado = (Label)Master.FindControl("LblUserLogado");
                    lblUsuarioLogado.Visible = true;
                    lblUsuarioLogado.Text = Session["NomeUsuario"].ToString();
                    LinkButton lnkLogout = (LinkButton)Master.FindControl("LnkLogout");
                    lnkLogout.Visible = true;

                    pnlModal.Visible = false;
                }

                else
                {
                    LblErros.Text = "<br />" + "Login Inválido";
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

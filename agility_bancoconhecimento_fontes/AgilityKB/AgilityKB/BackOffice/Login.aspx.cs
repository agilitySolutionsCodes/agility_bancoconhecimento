using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.SessionState;
using System.Web.Security;
using System.Security.Cryptography;

using AgilityKB.Entity;
using AgilityKB.Business;

namespace AgilityKB.BackOffice
{
    public partial class Login : System.Web.UI.Page
    {
        #region Objetos instânciados para Criptografia de Senha
        TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
        MD5CryptoServiceProvider md5Crypto = new MD5CryptoServiceProvider();
        String Chave = "Agility";
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

            }
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

        protected void BtnEnviar_Click(object sender, EventArgs e)
        {
            if (ValidaLogin() == true)
            {
                Usuario usuario = new Usuario();
                UsuarioBusiness usuarioB = new UsuarioBusiness();

                var vSenha = Criptografar(TxtSenha.Text);
                usuario = usuarioB.AutenticaUsuarioAdmin(TxtLogin.Text, vSenha);

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


                    Response.Redirect("~/BackOffice/Home.aspx");
                }

                else
                {
                    LblErros.Text = "<br />" + "Login Inválido";
                    //DvErros.Visible = true;
                }
            }
        }

        public Boolean ValidaLogin()
        {
            string erros = string.Empty;
            bool valid = false;

            if (string.IsNullOrEmpty(TxtLogin.Text) && (string.IsNullOrEmpty(TxtSenha.Text)))
            {
                erros = "<br />" + "* Os campos Login e Senha são obrigatórios";
            }

            else
            {
                valid = true;
            }

            LblErros.Text = erros;
            return valid;
        }
    }
}
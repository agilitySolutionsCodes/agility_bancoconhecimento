using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Text;
using System.Security.Cryptography;

using AgilityKB.Entity;
using AgilityKB.Business;

namespace AgilityKB
{
    public partial class TermosUso : System.Web.UI.Page
    {
        #region Objetos instânciados para Criptografia de Senha
        TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
        MD5CryptoServiceProvider md5Crypto = new MD5CryptoServiceProvider();

        //Chave para criptografia
        String Chave = "Agility";

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            BtnVoltar.Attributes.Add("onClick", "javascript:history.back(); return false;");

            if (Convert.ToBoolean(Session["Ativo"]) == false)
            {
                DvTrocaSenha.Visible = true;
                DvTermos.Visible = true;

                if (!Page.IsPostBack)
                {
                    if (Session["CodUsuario"] == null)
                    {
                        Response.Redirect("~/default.aspx");
                    }
                }
            }

            else
            {
                DvTrocaSenha.Visible = false; ;
                DvTermos.Visible = false;
            }
        }

        protected void BtnEnviar_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();
            UsuarioBusiness usuarioB = new UsuarioBusiness();

            if (!ValidarCampos() == true)
            {
                ScriptManager.RegisterClientScriptBlock(BtnEnviar, BtnEnviar.GetType(), "msgFailed", "alert('Algo saiu errado por favor corrija os erros e tente novamente.');", true);
                DvErros.Visible = true;
            }

            else
            {
                if (ChkAceite.Checked == true)
                {
                    ValidarCampos();

                    usuario.IdUsuario = Convert.ToInt32(Session["CodUsuario"].ToString());
                    usuario.Ativo = true;

                    var vNovaSenha = CriptografarSenha(TxtConfirmacaoSenha.Text);

                    usuarioB.AceitaTermos(usuario.IdUsuario, usuario.Ativo, vNovaSenha);
                    ScriptManager.RegisterClientScriptBlock(BtnEnviar, BtnEnviar.GetType(), "msgSucesso", "alert('Bem Vindo a Base de Conhecimento Agility Solutions.');", true);

                    Response.Redirect("~/default.aspx");                   
                }

                else
                {
                    if (ChkRecusa.Checked == true)
                    {
                        Session.RemoveAll();
                        Response.Redirect("~/default.aspx");
                    }
                }
            }
        }

        public String CriptografarSenha(string senha)
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
            ICryptoTransform desdencrypt = des.CreateEncryptor();
            ASCIIEncoding MyASCIIEncoding = new ASCIIEncoding();
            var buff = ASCIIEncoding.ASCII.GetBytes(senha);
            senha = Convert.ToBase64String(desdencrypt.TransformFinalBlock(buff, 0, buff.Length));

            return senha;
        }

        public Boolean ValidarCampos()
        {
            string erros = string.Empty;
            bool valid = false;

            var vSenha = DescriptografarSenha(TxtSenhaAtual.Text);

            if (string.IsNullOrEmpty(TxtSenhaAtual.Text))
            {
                erros = "<br />" + "* Por favor digite sua senha atual";
            }

            if (vSenha != Session["SenhaAtual"].ToString())
            {
                erros = erros + "<br />" + "* A senha atual não confere";
            }

            if (string.IsNullOrEmpty(TxtSenha.Text) && string.IsNullOrEmpty(TxtConfirmacaoSenha.Text))
            {
                erros = erros + "<br />" + "* Por Favor digite uma nova senha" + "<br />";
            }

            if (ChkAceite.Checked == false && ChkRecusa.Checked == false)
            {
                erros = erros + "<br />" + "* Você deve aceitar os termos de uso para continuar";
            }

            else if (TxtSenha.Text != TxtConfirmacaoSenha.Text)
            {
                erros = erros + "<br />" + "* As senhas não conferem" + "<br />";
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
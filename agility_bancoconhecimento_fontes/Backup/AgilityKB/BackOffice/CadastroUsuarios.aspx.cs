using System;
using System.Text;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.Security;
using System.Security.Cryptography;
using System.IO;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Threading;
using System.Globalization;

using AgilityKB.Entity;
using AgilityKB.Business;

namespace AgilityKB
{
    public partial class CadastroContatos : System.Web.UI.Page
    {
        TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
        MD5CryptoServiceProvider md5Crypto = new MD5CryptoServiceProvider();
        String Chave = "Agility";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DvErros.Visible = false;
                CarregaUsuarios();
            }

            else
            {
                if (UsuarioFtUpload.HasFile)
                {
                    Session["FotoSelecionada"] = UsuarioFtUpload;
                    LblUpload.Text = UsuarioFtUpload.FileName;
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

        public Boolean ValidarCampos()
        {
            string erros = string.Empty;
            bool valid = false;

            if (string.IsNullOrEmpty(TxtNome.Text))
            {
                erros = "<br />" + "* O campo Nome é obrigatório";
            }

            if (string.IsNullOrEmpty(TxtEmail.Text))
            {
                erros = "<br />" + "* Digite um e-mail válido";
            }

            if (string.IsNullOrEmpty(TxtTelefone.Text))
            {
                erros = erros + "<br />" + "* O campo telefone é obrigatório";
            }

            if (string.IsNullOrEmpty(TxtSkype.Text))
            {
                erros = erros + "<br />" + "* É necessário o cadastramento de seu nome skype";
            }

            if (string.IsNullOrEmpty(TxtSenha.Text) && string.IsNullOrEmpty(TxtConfirmacaoSenha.Text))
            {
                erros = erros + "<br />" + "* Por Favor Digite uma senha" + "<br />";
            }

            else if (TxtSenha.Text != TxtConfirmacaoSenha.Text)
            {
                erros = erros + "<br />" + "* As senhas não conferem" + "<br />";
            }

            else
            {
                CriptografarSenha(TxtConfirmacaoSenha.Text);
                valid = true;
            }

            LblErros.Text = erros;
            return valid;
        }

        public void LimpaCampos()
        {
            TxtNome.Text = string.Empty;
            TxtEmail.Text = string.Empty;
            TxtDpto.Text = string.Empty;
            TxtTelefone.Text = string.Empty;
            TxtRamal.Text = string.Empty;
            TxtCelular.Text = string.Empty;
            TxtSkype.Text = string.Empty;

            TxtSenha.Text = string.Empty;
            TxtConfirmacaoSenha.Text = string.Empty;
            LblErros.Text = string.Empty;
        }

        public UsuarioBusiness CarregaUsuarios()
        {
            UsuarioBusiness usuarioB = new UsuarioBusiness();
            DataTable dt = usuarioB.ListaUsuarios();

            GrdUsuarios.DataSource = dt;
            GrdUsuarios.DataBind();
            return usuarioB;
        }

        protected void BtnEnviar_Click(object sender, EventArgs e)
        {
            ValidarCampos();

            if (!ValidarCampos() == true)
            {
                ScriptManager.RegisterClientScriptBlock(BtnEnviar, BtnEnviar.GetType(), "msgFalha", "alert('Erro ao efetuar cadastro.');", true);
                DvErros.Visible = true;
                CarregaUsuarios();
            }

            else
            {
                if (Session["FotoSelecionada"].ToString() != string.Empty || UsuarioFtUpload.HasFile )
                {
                    UsuarioFtUpload.SaveAs(Server.MapPath("~/Uploads/Imgs/") + LblUpload.Text);
                }

                UsuarioBusiness usuarioB = new UsuarioBusiness();
                usuarioB.RegistrarUsuario(TxtNome.Text, TxtEmail.Text, TxtTelefone.Text, TxtRamal.Text, TxtCelular.Text, TxtSkype.Text, LblUpload.Text,
                                          TxtSenha.Text, "TesteImg", TxtDpto.Text);

                LimpaCampos();
                CarregaUsuarios();

                ScriptManager.RegisterClientScriptBlock(BtnEnviar, BtnEnviar.GetType(), "msgSucesso", "alert('Cadastro efetuado com Sucesso.');", true);
            }
        }

        protected void BtnLimpar_Click(object sender, EventArgs e)
        {
            TxtNome.Text = string.Empty;
            TxtEmail.Text = string.Empty;
            TxtTelefone.Text = string.Empty;
            TxtRamal.Text = string.Empty;
            TxtCelular.Text = string.Empty;
            TxtSkype.Text = string.Empty;
            TxtDpto.Text = string.Empty;
            TxtSenha.Text = string.Empty;
            UsuarioFtUpload.Dispose();            
        }

        protected void BtnTraduzir_Click(object sender, EventArgs e)
        {
            
        }

        protected void GrdUsuarios_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            RemoverItem(GrdUsuarios.Rows[e.RowIndex]);
        }

        protected void GrdUsuarios_RowCommand(object sender, GridViewRowEventArgs e)
        {

        }

        public void RemoverItem(GridViewRow oRow)
        {
            string IdUsuario = ((Label)oRow.FindControl("lblIdUsuario")).Text;

            UsuarioBusiness usuarioB = new UsuarioBusiness();
            if (!string.IsNullOrEmpty(IdUsuario))
            {
                usuarioB.DeletaUsuario(Convert.ToInt32(IdUsuario));
                ScriptManager.RegisterClientScriptBlock(GrdUsuarios, GrdUsuarios.GetType(), "msgSucesso", "alert('Cadastro realizado com Sucesso.');", true);
                CarregaUsuarios();
            }
        }

        public void AtualizarItem(GridViewRow oRow)
        {
            string IdUsuario = ((Label)oRow.FindControl("lblIdUsuario")).Text;
            UsuarioBusiness usuarioB = new UsuarioBusiness();
            if (!string.IsNullOrEmpty(IdUsuario))
            {
                usuarioB.ListaUsuarioById(Convert.ToInt32(IdUsuario));

                TxtNome.Text = ((Label)oRow.FindControl("lblNome")).Text;
                TxtEmail.Text = ((Label)oRow.FindControl("lblEmail")).Text;
                TxtTelefone.Text = ((Label)oRow.FindControl("lblTelefone")).Text;
                TxtRamal.Text = ((Label)oRow.FindControl("lblRamal")).Text;
                TxtCelular.Text = ((Label)oRow.FindControl("lblCelular")).Text;
                TxtSkype.Text = ((Label)oRow.FindControl("lblNomeSkype")).Text;

                TxtSenha.Text = ((Label)oRow.FindControl("lblSenha")).Text;
                TxtDpto.Text = ((Label)oRow.FindControl("lblDpto")).Text;
            }

            CarregaUsuarios();
        }

        protected void GrdUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void BtnDeletar_Click(object sender, EventArgs e)
        {
            int nIndice = ((GridViewRow)((Control)sender).NamingContainer).RowIndex;
            GridViewRow gvr = GrdUsuarios.Rows[nIndice];
            RemoverItem(gvr);
        }

        protected void BtnEditar_Click(object sender, EventArgs e)
        {
            int nIndice = ((GridViewRow)((Control)sender).NamingContainer).RowIndex;
            GridViewRow gvr = GrdUsuarios.Rows[nIndice];
            AtualizarItem(gvr);
        }
    }
}
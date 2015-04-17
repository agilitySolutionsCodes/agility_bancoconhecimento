using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;

using AgilityKB.Entity;
using AgilityKB.DAO;

namespace AgilityKB.Business
{

    public class UsuarioBusiness
    {
        public Usuario RegistrarUsuario(string nome, string email, string telefone, string ramal, string celular,
                                        string nomeSkype, string foto, string senha, string img, string dpto, bool ativo, bool administrador)
        {
            Usuario usuario = new Usuario();
            UsuarioDAO usuarioDao = new UsuarioDAO();

            usuarioDao.IncluirUsuario(nome, email, telefone, ramal, celular, nomeSkype, foto, senha, img, dpto, ativo, administrador);
            return usuario;
        }


        public Usuario AtualizarUsuario(int idUsuario, string nomeUsuario, string emailUsuario, string telefoneUsuario, string ramalUsuario, string celularUsuario,
                                            string nomeSkypeUsuario, string novaFotoUsuario, string novaSenhaUsuario, string img, string dptoUsuario, bool ativo, bool adm)
        {
            Usuario usuario = new Usuario();
            UsuarioDAO usuarioDAO = new UsuarioDAO();

            usuarioDAO.AtualizarUsuario(idUsuario, nomeUsuario, emailUsuario, telefoneUsuario, ramalUsuario, celularUsuario, nomeSkypeUsuario, novaFotoUsuario,
                                        novaSenhaUsuario, img, dptoUsuario, ativo, adm);
            return usuario;
        }

        public DataTable ListaUsuarios()
        {
            DataTable dt;
            UsuarioDAO usuarioDAO = new UsuarioDAO();

            dt = usuarioDAO.ListaUsuarios();

            return dt;
        }

        public DataTable ListaUsuarioById(int IdUsuario)
        {
            DataTable dt;
            UsuarioDAO usuarioDAO = new UsuarioDAO();

            dt = usuarioDAO.ListaUsuarioById(IdUsuario);
            return dt;
        }

        public void DeletaUsuario(int IdUsuario)
        {
            Usuario usuario = new Usuario();
            UsuarioDAO usuarioDAO = new UsuarioDAO();

            usuarioDAO.DeletaUsuario(IdUsuario);
        }

        public void AceitaTermos(int IdUsuario, Boolean Ativo, string novaSenha)
        {
            Usuario usuario = new Usuario();
            UsuarioDAO usuarioDAO = new UsuarioDAO();

            usuarioDAO.AceitaTermosUso(IdUsuario, Ativo, novaSenha);
        }

        public Usuario AutenticaUsuario(string email, string senha)
        {
            Usuario usuario = new Usuario();

            UsuarioDAO usuarioDAO = new UsuarioDAO();
            usuario =  usuarioDAO.AutenticarUsuario(email, senha);

            return usuario;
        }

        public Usuario AutenticaUsuarioAdmin(string email, string senha)
        {
            Usuario usuario = new Usuario();

            UsuarioDAO usuarioDAO = new UsuarioDAO();
            usuario = usuarioDAO.AutenticarUsuarioAdmin(email, senha);

            return usuario;
        }

        public Usuario AutenticarUsuarioLogado(string email)
        {
            Usuario usuario = new Usuario();
            UsuarioDAO usuarioDAO = new UsuarioDAO();
            usuario = usuarioDAO.AutenticaAdminLogado(email);

            return usuario;
        }
    }
}

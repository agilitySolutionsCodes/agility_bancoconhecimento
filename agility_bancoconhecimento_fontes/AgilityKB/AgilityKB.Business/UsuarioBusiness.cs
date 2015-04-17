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
                                        string nomeSkype, string foto, string senha, string img, string dpto)
        {
            Usuario usuario = new Usuario();
            UsuarioDAO usuarioDao = new UsuarioDAO();

            usuarioDao.IncluirUsuario(nome, email, telefone, ramal, celular, nomeSkype, foto, senha, img, dpto);
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
    }
}
